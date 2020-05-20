using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;

namespace DigitalEventPlaner.Services.Services.BlobService
{
    public interface IBlobService
    {

        Task<CloudBlobContainer> CreateSampleContainerAsync(string guid);
        Task<string> UploadProfilePicture(byte[] image, string name, string profileImageGuid);
        Task<string> UploadSmartRateImage(byte[] image, string name, string profileImageGuid);
        Task<List<string>> GetProfilePicture(int id);
    }
}
