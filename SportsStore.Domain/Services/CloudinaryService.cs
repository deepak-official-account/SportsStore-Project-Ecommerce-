using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Configuration;

namespace SportsStore.Domain.Services
{
    public class CloudinaryService
        {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService()
            {
            var cloudName = ConfigurationManager.AppSettings["CloudinaryCloudName"];
            var apiSecret = ConfigurationManager.AppSettings["CloudinaryApiSecret"];
            var apiKey = ConfigurationManager.AppSettings["CloudinaryApiKey"];

            //To create an instance for cloudinary object
            var account = new Account(cloudName, apiKey, apiSecret);
            _cloudinary = new Cloudinary(account);
            }

        public dynamic UploadImage(Stream fileStream, string fileName)
            {
            var transformation = new Transformation().Height(200).Crop("fit");
            var uploadParams = new ImageUploadParams()
                {
                File = new FileDescription(fileName, fileStream),
                Transformation = transformation
                };

            var uploadResponse = this._cloudinary.Upload(uploadParams);
            
            return uploadResponse;
            }
        }
}