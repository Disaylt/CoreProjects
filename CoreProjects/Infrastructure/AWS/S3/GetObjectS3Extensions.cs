using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProjects.Infrastructure.AWS.S3
{
    public static class GetObjectS3Extensions
    {
        public static async Task<string> ReadAsStringAsync(this GetObjectResponse value)
        {
            using(StreamReader reader = new StreamReader(value.ResponseStream, Encoding.UTF8))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
