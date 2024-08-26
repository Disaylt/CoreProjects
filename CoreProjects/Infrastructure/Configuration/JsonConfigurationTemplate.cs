using CoreProjects.Application.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProjects.Infrastructure.Configuration
{
    internal class JsonConfigurationTemplate : IConfigurationTemplate
    {
        protected IConfigurationManager ConfigurationManager { get; }
        public JsonConfigurationTemplate(IConfigurationManager configurationManager)
        {
            ConfigurationManager = configurationManager;
        }

        public virtual Task LoadAsync(string filePath)
        {
            ConfigurationManager.AddJsonFile(filePath);

            return Task.CompletedTask;
        }
    }
}
