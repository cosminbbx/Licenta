using System;
using DataLayer.Context;
using DataLayer.Entities;
using DataLayer.Infrastructure;

namespace ConsoleAppTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var context = new DataContext();
            var test = new Repository<User>(context);
            var list = test.GetAll();
        }
    }
}
    