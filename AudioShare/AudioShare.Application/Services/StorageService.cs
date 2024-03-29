﻿using AudioShare.Application.Abstract;
using AudioShare.Application.Exceptions;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace AudioShare.Application.Services
{
    public class StorageService : IStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IConfiguration _configuration;

        public StorageService(
            BlobServiceClient blobServiceClient,
            IConfiguration configuration)
        {
            _blobServiceClient = blobServiceClient;
            _configuration = configuration;
        }

        public void Upload(IFormFile formFile)
        {
            var containerName = _configuration.GetSection("Storage:ContainerName").Value;

            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(formFile.FileName);

            using var stream = formFile.OpenReadStream();
            blobClient.Upload(stream, true);
        }

        public void Delete(string fileName)
        {
            try
            {
                var containerName = _configuration.GetSection("Storage:ContainerName").Value;
                var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
                if (fileName == "")
                {
                    throw new NoFilesSelectedException();
                }

                var blobClient = containerClient.GetBlobClient(fileName);
                blobClient.Delete();
            }
            catch (NoFilesSelectedException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
