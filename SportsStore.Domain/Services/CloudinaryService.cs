using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Configuration;
//using DotNetEnv;
using System.Security.Principal;
namespace SportsStore.Domain.Services
{
    public class CloudinaryService
        {
        private readonly Cloudinary _cloudinary;
       
        public CloudinaryService()
            {
            var response = DotNetEnv.Env.Load("C:\\Users\\bisht.deepak\\source\\repos\\SportsStore\\SportsStore.Domain\\.env");
            string CloudName = Environment.GetEnvironmentVariable("CLOUDINARY_CLOUD_NAME");
            string ApiKey = Environment.GetEnvironmentVariable("CLOUDINARY_API_KEY");
            string ApiSecret = Environment.GetEnvironmentVariable("CLOUDINARY_API_SECRET");
            Account account = new Account(CloudName, ApiKey, ApiSecret);
            _cloudinary = new Cloudinary(account);
            }



        private string CloudName = Environment.GetEnvironmentVariable("CLOUDINARY_CLOUD_NAME");
        private string ApiKey = Environment.GetEnvironmentVariable("CLOUDINARY_API_KEY");
        private string ApiSecret = Environment.GetEnvironmentVariable("CLOUDINARY_API_SECRET");


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