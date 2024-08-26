using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProjects.Infrastructure.Configuration.Section
{
    public static class Extensions
    {
        public static T GetValueRequired<T>(this IConfigurationSection section, string key)
        {
            return section.GetValue<T>(key)
                ?? throw new NullReferenceException($"Key {key} not found");
        }
    }
}
