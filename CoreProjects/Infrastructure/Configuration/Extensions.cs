using CoreProjects.Application.Configuration;
using CoreProjects.Domain.Configuration;
using CoreProjects.Infrastructure.Configuration.Section;
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

        public static async Task AddApplicationConfigurationsFromRoutesAsync(this IConfigurationManager configuration, string applicationName, ConfigurationTemplateType type)
        {
            IEnumerable<string> paths = configuration
                .GetRequiredSection("ConfigRoutes")
                .GetValueRequired<IEnumerable<string>>(applicationName);

            await _configurationFactory.Create(type, configuration)
                .LoadRangeAsync(paths);
        }

        public static async Task AddConfigurationByPathAsync(this IConfigurationManager configuration, string key, ConfigurationTemplateType type)
        {
            IConfigurationTemplate configurationTemplate = _configurationFactory.Create(type, configuration);
            string path = configuration.GetValueRequired<string>(key);

            await _configurationFactory.Create(type, configuration)
                .LoadAsync(path);
        }
    }
}
