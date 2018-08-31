using System;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

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
            Console.WriteLine("Hello World!");
            using (AmazonS3Client client = new AmazonS3Client(RegionEndpoint.APSoutheast2))
            {
                var response = client.ListBucketsAsync();
                foreach (S3Bucket bucket in response.Result.Buckets)
                {
                    Console.WriteLine("You own Bucket with name: {0}", bucket.BucketName);
                }
            }
        }
    }
}
