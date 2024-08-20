using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProjects.Application.Configuration
{
    public interface IConfigurationTemplate
    {
        public Task LoadAsync(string filePath);
    }
}
