using CoreProjects.Application.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProjects.Infrastructure.Configuration
{
    internal abstract class BaseConfigurationTemplate : IConfigurationTemplate
    {
        public abstract Task LoadAsync(string filePath);

        public virtual async Task LoadRangeAsync(IEnumerable<string> filePath)
        {
            List<Task> tasks = new List<Task>();

            foreach(string path in filePath)
            {
                Task task = LoadAsync(path);
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
        }
    }
}
