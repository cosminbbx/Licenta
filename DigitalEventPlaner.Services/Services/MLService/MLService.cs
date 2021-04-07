using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.ML;

namespace DigitalEventPlaner.Services.Services.MLService
{
    public class MLService :IMLService
    {
        private readonly IConfiguration configuration;

        public MLService(IConfiguration config)
        {
            this.configuration = config;
        }

        public float BugetEstimation()
        {
            MLContext mlContext = new MLContext(seed: 0);

            var trainPath = Path.Combine(configuration.GetValue<string>("CsvPath:Train"), "event-train.csv");

            var model = Train(mlContext, trainPath);

            Evaluate(mlContext, model);

            return TestSinglePrediction(mlContext, model);
        }

        public ITransformer Train(MLContext mlContext, string dataPath)
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

        private void Evaluate(MLContext mlContext, ITransformer model)
        {
            var testPath = Path.Combine(configuration.GetValue<string>("CsvPath:Test"), "event-test.csv");

            IDataView dataView = mlContext.Data.LoadFromTextFile<EventBuget>(testPath, hasHeader: true, separatorChar: ',');

            var predictions = model.Transform(dataView);

            var metrics = mlContext.Regression.Evaluate(predictions, "Label", "Score");

            Console.WriteLine();
            Console.WriteLine($"*************************************************");
            Console.WriteLine($"*       Model quality metrics evaluation         ");
            Console.WriteLine($"*------------------------------------------------");
            Console.WriteLine($"*       RSquared Score:      {metrics.RSquared:0.##}");
            Console.WriteLine($"*       Root Mean Squared Error:      {metrics.RootMeanSquaredError:#.##}");
        }

        private float TestSinglePrediction(MLContext mlContext, ITransformer model)
        {
            Random random = new Random();

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

            return prediction.BugetNeeded;
        }
    }
}
