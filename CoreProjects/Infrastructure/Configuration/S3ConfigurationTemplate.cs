using Amazon.S3;
using Amazon.S3.Model;
using CoreProjects.Application.Configuration;
using CoreProjects.Domain.AWS.S3;
using CoreProjects.Infrastructure.AWS.S3;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProjects.Infrastructure.Configuration
{
    internal class S3ConfigurationTemplate : BaseConfigurationTemplate, IConfigurationTemplate
    {
        protected IAmazonS3 Client { get; }
        protected IConfigurationManager ConfigurationManager { get; }
        protected string Bucket { get; }

        public S3ConfigurationTemplate(IConfigurationManager configurationManager)
        {
            ConfigurationManager = configurationManager;
            Client = new ConfigurationAmazonS3Client(ConfigurationManager);
            Bucket = configurationManager.GetValue<string>(S3Constants.BucketEnvName) ?? throw new Exception("Bucket is empty.");
        }

        public override async Task LoadAsync(string filePath)
        {
            GetObjectResponse response = await Client.GetObjectAsync(Bucket, filePath);
            ConfigurationManager.AddJsonStream(response.ResponseStream);
        }
    }
}
