﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.Infrastructure;
using Microsoft.ML;
using System.Security.Cryptography;
using DigitalEventPlaner.Services.Services.User;
using DigitalEventPlaner.Services.Services.User.Dto;

namespace ConsoleAppTest
{
    public class Program
    {
        public static DataContext context = new DataContext();
        public static Repository<User> userRepo = new Repository<User>(context);
        public static Repository<Event> eventRepo = new Repository<Event>(context);
        public static Repository<Service>  serviceRepo = new Repository<Service>(context);
        public static Repository<EventService> eventServiceRepo = new Repository<EventService>(context);
        public static UnitOfWork unit = new UnitOfWork(context);
        public static IUserService userService = new UserService(userRepo, unit);

        static readonly string _trainDataPath = Path.Combine("/Users/macbook1/Projects/Licenta/ConsoleAppTest/Data/", "event-train.csv");
        static readonly string _testDataPath = Path.Combine("/Users/macbook1/Projects/Licenta/ConsoleAppTest/Data/", "event-test.csv");
        static readonly string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "Model.zip");

        public static Random random = new Random();
        static void Main(string[] args)
        {
            var source = "Test";
            MD5 md5Hash = MD5.Create();

            string hash = GetMd5Hash(md5Hash, source);

            Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".");

            Console.WriteLine("Verifying the hash...");

            if (VerifyMd5Hash(md5Hash, source, hash))
            {
                Console.WriteLine("The hashes are the same.");
            }
            else
            {
                Console.WriteLine("The hashes are not same.");
            }

            var user = new UserDto()
            {
                UserName = "Service",
                Address = "Street Test",
                DateCreated = DateTime.Now,
                Email = "email@email",
                FirstName = "FirstNameTest",
                IsDeleted = false,
                LastName = "LastNameTest",
                Password = "password",
                Phone = "098765483",
                UserType = DataLayer.Enumerations.UserType.Service
            };
            userService.Create(user);
            //var userTest = userService.Login(user.UserName,"Test");
            //unit.Commit();
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void MLExemple()
        {
            MLContext mlContext = new MLContext(seed: 0);

            var model = Train(mlContext, _trainDataPath);

            Evaluate(mlContext, model);

            TestSinglePrediction(mlContext, model);
        }

        public static ITransformer Train(MLContext mlContext, string dataPath)
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<EventBuget>(dataPath, hasHeader: true, separatorChar: ',');

            var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "BugetNeeded")
            //.Append(mlContext.Transforms.Text.FeaturizeText("EventIdF", "EventId"))
            //.Append(mlContext.Transforms.Text.FeaturizeText("UserIdF", "UserId"))
            //.Append(mlContext.Transforms.Text.FeaturizeText("NumberOfServicesF", "NumberOfServices"))
            //.Append(mlContext.Transforms.Text.FeaturizeText("ParticipantsF", "Participants"))
            .Append(mlContext.Transforms.Concatenate("Features", "UserId", "NumberOfServices", "Participants"))
            .Append(mlContext.Regression.Trainers.FastTree());

            var model = pipeline.Fit(dataView);
            return model;
        }

        private static void Evaluate(MLContext mlContext, ITransformer model)
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<EventBuget>(_testDataPath, hasHeader: true, separatorChar: ',');

            var predictions = model.Transform(dataView);

            var metrics = mlContext.Regression.Evaluate(predictions, "Label", "Score");

            Console.WriteLine();
            Console.WriteLine($"*************************************************");
            Console.WriteLine($"*       Model quality metrics evaluation         ");
            Console.WriteLine($"*------------------------------------------------");
            Console.WriteLine($"*       RSquared Score:      {metrics.RSquared:0.##}");
            Console.WriteLine($"*       Root Mean Squared Error:      {metrics.RootMeanSquaredError:#.##}");
        }

        private static void TestSinglePrediction(MLContext mlContext, ITransformer model)
        {
            var predictionFunction = mlContext.Model.CreatePredictionEngine<EventBuget, EventBugetPrediction>(model);

            var eventEntity = new EventBuget()
            {
                UserId = random.Next(1, 50),
                NumberOfServices = random.Next(1, 5),
                Participants = random.Next(100, 400),
                BugetNeeded = 0
            };

            var prediction = predictionFunction.Predict(eventEntity);
            Console.WriteLine($"**********************************************************************");
            Console.WriteLine($"Predicted fare: {prediction.BugetNeeded}, actual fare: 15.5");
            Console.WriteLine($"**********************************************************************");
        }

        static void GenerateCsv()
        {
            var trainPath = Path.Combine("/Users/macbook1/Projects/Licenta/ConsoleAppTest/Data/", "event-train.csv");
            var testPath = Path.Combine("/Users/macbook1/Projects/Licenta/ConsoleAppTest/Data/", "event-test.csv");

            var header = "EventId,UserId,NumberOfServices,Participants,BugetNeeded" + Environment.NewLine;

            var csvTrain = new StringBuilder();
            var csvTest = new StringBuilder();

            csvTrain.Append(header);
            csvTest.Append(header);

            var eventList = eventRepo.GetAll();

            //for (var i = 0; i <= (eventList.Count / 2) - 1; i++)
            //{
            //    var eventLine = eventList[i];
            //    var line = eventLine.EventId.ToString() + "," +
            //               eventLine.UserId.ToString() + "," +
            //               eventLine.NumberOfServices.ToString() + "," +
            //               eventLine.Participants.ToString() + "," +
            //               eventLine.BugetNeeded.ToString() +
            //               Environment.NewLine;
            //    csvTrain.Append(line);
            //}

            //for (var i = (eventList.Count / 2); i <= eventList.Count - 1; i++)
            //{
            //    var eventLine = eventList[i];
            //    var line = eventLine.EventId.ToString() + "," +
            //               eventLine.UserId.ToString() + "," +
            //               eventLine.NumberOfServices.ToString() + "," +
            //               eventLine.Participants.ToString() + "," +
            //               eventLine.BugetNeeded.ToString() +
            //               Environment.NewLine;
            //    csvTest.Append(line);
            //}
            //using (var stream = File.CreateText(trainPath))
            //{
            //    stream.WriteLine(csvTrain);
            //}
            //using (var stream = File.CreateText(testPath))
            //{
            //    stream.WriteLine(csvTest);
            //}
        }
        static void GenerateEvents(int number)
        {
            //for (var i = 0; i < number; i++)
            //{
            //    var eventEntity = new Event()
            //    {
            //        UserId = random.Next(1, 50),
            //        NumberOfServices = random.Next(1, 5),
            //        Participants = random.Next(100, 400),
            //    };

            //    var buget = 0;

            //    var list = GetRandomServicesId(eventEntity.NumberOfServices);

            //    foreach (var item in list)
            //    {
            //        var service = serviceRepo.GetById(item);
            //        buget = buget + (service.PricePerPerson * eventEntity.Participants);

            //        var eventServiceEntity = new EventService()
            //        {
            //            ServiceId = service.ServiceId,
            //            UserId = eventEntity.UserId
            //        };
            //        eventServiceRepo.Add(eventServiceEntity);
            //    }

            //    eventEntity.BugetNeeded = buget;
            //    eventRepo.Add(eventEntity);
            //}


            //var eventServiceEntity = new EventService()
            //{
            //    ServiceId = 1,
            //    UserId = eventEntity.UserId
            //};

            //eventRepo.Add(eventEntity);
            //serviceRepo.Add(serviceEntity);
            //eventServiceRepo.Add(eventServiceEntity);
            unit.Commit();
        }
        static List<int> GetRandomServicesId(int numberOfServices)
        {
            var list = new List<int>();
            var random = new Random();
            while (list.Count < numberOfServices)
            {
                var serviceID = random.Next(1,7);
                if (!list.Contains(serviceID))
                {
                    list.Add(serviceID);
                }
            }
            return list;
        }
    }
}
    