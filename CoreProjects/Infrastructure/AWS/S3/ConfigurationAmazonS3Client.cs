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
                        ServiceURL = configuration.GetValue<string>(S3Constants.Url)
                    })
        {
            
        }

        private ConfigurationAmazonS3Client(IConfiguration configuration, AmazonS3Config amazonS3Config)
            : base(configuration.GetValue<string>(S3Constants.AccessKeyEnvName),
                  configuration.GetValue<string>(S3Constants.SecretKeyEnvName),
                  amazonS3Config)
        {

        }
    }
}
