using CoreProjects.Application.Configuration;
using CoreProjects.Domain.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProjects.Infrastructure.Configuration
{
    public static class Extensions
    {
        private static readonly ConfigurationFactory _configurationFactory = new ConfigurationFactory();

        public static T GetValueRequired<T>(this IConfigurationManager configurationManager, string key)
        {
            return configurationManager.GetValue<T>(key)
                ?? throw new NullReferenceException($"Key {key} not found");
        }

        public static T GetRequired<T>(this IConfigurationManager configurationManager)
        {
            return configurationManager.Get<T>()
                ?? throw new NullReferenceException("Configuration not found.");
        }

        public static async Task AddApplicationConfiguration(this IConfigurationManager configuration, string applicationName, ConfigurationTemplateType type)
        {
            List<Task> tasks = new List<Task>();
            IConfigurationTemplate configurationTemplate = _configurationFactory.Create(type, configuration);
            IEnumerable<string> paths = configuration.GetValueRequired<IEnumerable<string>>(applicationName);

            foreach (string path in paths)
            {
                Task task = configurationTemplate.LoadAsync(path);
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }
    }
}
