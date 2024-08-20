using Amazon.S3;
using CoreProjects.Domain.AWS.S3;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProjects.Infrastructure.AWS.S3
{
    internal class ConfigurationAmazonS3Client : AmazonS3Client
    {
        public ConfigurationAmazonS3Client(IConfiguration configuration) 
            : this(configuration, 
                    new AmazonS3Config
                    {
                        ServiceURL = configuration.GetValue<string>(S3Constants.Url) ?? throw new Exception("Service url is empty.")
                    })
        {
            
        }

        private ConfigurationAmazonS3Client(IConfiguration configuration, AmazonS3Config amazonS3Config)
            : base(configuration.GetValue<string>(S3Constants.AccessKeyEnvName) ?? throw new Exception("Access key is empty."),
                  configuration.GetValue<string>(S3Constants.SecretKeyEnvName) ?? throw new Exception("Secret ket is empty."),
                  amazonS3Config)
        {

        }
    }
}
