using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DigitalEventPlaner.Services.Services.ContainerName;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace DigitalEventPlaner.Services.Services.BlobService
{
    public class BlobService :IBlobService
    {
        private readonly CloudBlobClient blobClient;
        private readonly List<string> extensions = new List<string>() { ".gif", ".png", ".jpg", ".jpeg" };
        private readonly IConfiguration config;
        private readonly IContainerNameService containerNameService;
        public BlobService(IConfiguration config, IContainerNameService containerNameService)
        {
            this.config = config;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(config.GetValue<string>("StorageSettings:AzureConnectionString")); ;
            this.blobClient = storageAccount.CreateCloudBlobClient();
            this.containerNameService = containerNameService;
        }

        //cod preluat de pe https://docs.microsoft.com apoi prelucrat pentru cazul curent
        public async Task<List<string>> GetProfilePicture(int id)
        {
            var profilePicture = containerNameService.GetProfilePictureByUserId(id);

            var blob = await blobClient.GetContainerReference("profilepicture").ListBlobsSegmentedAsync(null);

            var urilist = new List<string>();
            foreach (var image in blob.Results)
            {
                if (image is CloudBlockBlob)
                {
                    if(((CloudBlockBlob)image).Name == profilePicture.Name)
                    {
                        urilist.Add(image.Uri.AbsoluteUri);
                    }
                }
            }
            return urilist;
        }

        public async Task<CloudBlobContainer> CreateSampleContainerAsync(string containerName)
        {

            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            try
            {
                bool result = await container.CreateIfNotExistsAsync();
                if (result == true)
                {
                    Console.WriteLine("Created container {0}", container.Name);
                }
            }
            catch (StorageException e)
            {
                Console.WriteLine("HTTP error code {0}: {1}",
                                    e.RequestInformation.HttpStatusCode,
                                    e.RequestInformation.ErrorCode);
                Console.WriteLine(e.Message);
            }

            return container;
        }
        public async Task<string> UploadProfilePicture(byte[] image, string name, string profileImageGuid)
        {
            var ext = Path.GetExtension(name);
            if (!extensions.Contains(ext.ToLower()))
            {
                throw new Exception("Error");
            }
            CloudBlobContainer container = blobClient.GetContainerReference("profilepicture");
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(profileImageGuid);

            await blockBlob.UploadFromByteArrayAsync(image, 0, image.Length);

            return blockBlob.Uri.AbsoluteUri;
        }

        public async Task<string> UploadSmartRateImage(byte[] image, string name, string profileImageGuid)
        {
            var ext = Path.GetExtension(name);
            if (!extensions.Contains(ext.ToLower()))
            {
                throw new Exception("Error");
            }
            CloudBlobContainer container = blobClient.GetContainerReference("smartrate");
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(profileImageGuid);

            await blockBlob.UploadFromByteArrayAsync(image, 0, image.Length);

            return blockBlob.Uri.AbsoluteUri;
        }
    }
}
