using Amazon;
using Amazon.Runtime;
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;

namespace AWSSDKDemo
{
    class Program
    {
        static string bucketName;
        static string keyName;
        
        static void Main(string[] args)
        {
            AmazonKeyManagementServiceClient kmsClient = new AmazonKeyManagementServiceClient(new InstanceProfileAWSCredentials(), RegionEndpoint.APSoutheast2);

            var ciphertext = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            var stream = new MemoryStream(ciphertext);
            var request = new DecryptRequest
            {
                CiphertextBlob = stream
            };

            var result = kmsClient.DecryptAsync(request);

            // The above is a async call, so do this to actually invoke the call
            // and hence produce the traceback
            Console.WriteLine(result.Result);
        }
    }
}
