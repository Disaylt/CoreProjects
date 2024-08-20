using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProjects.Domain.AWS.S3
{
    public static class S3Constants
    {
        private const string _AccessKeyEnvName = "s3AccessKey";
        public static string AccessKeyEnvName => _AccessKeyEnvName;

        private const string _secretKeyEnvName = "s3SecretKey";
        public static string SecretKeyEnvName => _secretKeyEnvName;

        private const string _url = "s3Url";
        public static string Url => _url;

        private const string _bucketEnvName = "s3Bucket";
        public static string BucketEnvName => _bucketEnvName;
    }
}
