using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProjects.Infrastructure.Configuration
{
    public static class Extensions
    {
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
    }
}
