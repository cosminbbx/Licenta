using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalEventPlaner.Services.Services.FaceRecognition
{
    public interface IFaceRecognitionService
    {
        Task<List<double>> GetSmartRateForImages(List<string> imageFileNames);
    }
}
