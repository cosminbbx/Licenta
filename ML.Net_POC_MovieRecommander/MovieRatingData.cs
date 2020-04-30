using System;
using Microsoft.ML.Data;
namespace ML.Net_POC_MovieRecommander
{
    public class MovieRating
    {
        [LoadColumn(0)]
        public float userId;
        [LoadColumn(1)]
        public float movieId;
        [LoadColumn(2)]
        public float Label;
    }
}
