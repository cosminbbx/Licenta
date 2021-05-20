using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalEventPlaner.Services.Services.FaceRecognition
{
    public interface IFaceRecognitionService
    {
        Task<double> GetSmartRateForImages(List<string> imageFileNames);
    }
}
