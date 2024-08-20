using CoreProjects.Application.Configuration;
using CoreProjects.Domain.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProjects.Infrastructure.Configuration
{
    public class ConfigurationFactory
    {
        public virtual IConfigurationTemplate Create(ConfigurationTemplateType type, IConfigurationManager configurationManager)
        {
            return type switch
            {
                ConfigurationTemplateType.S3 => new S3ConfigurationTemplate(configurationManager),
                _ => throw new Exception($"Type {type} is not registered.")
            };
        }
    }
}
