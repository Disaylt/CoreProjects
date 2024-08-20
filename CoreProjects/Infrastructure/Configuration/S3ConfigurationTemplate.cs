using Amazon.S3;
using CoreProjects.Application.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProjects.Infrastructure.Configuration
{
    internal class S3ConfigurationTemplate : IConfigurationTemplate
    {
        protected IAmazonS3 Client { get; }
        protected IConfigurationManager ConfigurationManager { get; }

        public S3ConfigurationTemplate(IConfigurationManager configurationManager)
        {
            ConfigurationManager = configurationManager;
        }

        public Task LoadAsync(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
