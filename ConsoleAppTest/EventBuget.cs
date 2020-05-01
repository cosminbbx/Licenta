using System;
using Microsoft.ML.Data;
namespace ConsoleAppTest
{
    public class EventBuget
    {
        [LoadColumn(0)]
        public float EventId;

        [LoadColumn(1)]
        public float UserId;

        [LoadColumn(2)]
        public float NumberOfServices;

        [LoadColumn(3)]
        public float Participants;

        [LoadColumn(4)]
        public float BugetNeeded;

    }
    public class EventBugetPrediction
    {
        [ColumnName("Score")]
        public float BugetNeeded;
    }
}
