using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace JWTCrafterDemo
{
    [DataContract]  
    internal class Header
    {  
        [DataMember]  
        internal string alg;  

        [DataMember]  
        internal string typ;  
    }
    [DataContract(Namespace="")]
    [KnownType(typeof(string))]
    [KnownType(typeof(Payload))]
    internal class Payload
    {  
        [DataMember]  
        internal string username;  

    }

    
    class Program
    {

        // https://www.jokecamp.com/blog/examples-of-creating-base64-hashes-using-hmac-sha256-in-different-languages/#csharp
        private  static string CreateSignature(string message, string secret)
        {
            secret = secret ?? "";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Base64UrlEncoder.Encode(hashmessage.ToString());
            }
        }

        static void Main(string[] args)
        {
            Header h = new Header();
            h.alg = "HMAC256";
            h.typ = "JWT";

            MemoryStream stream1 = new MemoryStream();  
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Header));
            ser.WriteObject(stream1, h);
            stream1.Position = 0;  
            StreamReader sr = new StreamReader(stream1);
            String header = Base64UrlEncoder.Encode(sr.ReadToEnd());

            Payload p = new Payload();
            p.username = "echorand";
            MemoryStream stream2 = new MemoryStream();  
            DataContractJsonSerializer ser2 = new DataContractJsonSerializer(typeof(Payload));
            ser.WriteObject(stream2, p);
            stream2.Position = 0;  
            StreamReader sr2 = new StreamReader(stream2);
            String payload = Base64UrlEncoder.Encode(sr2.ReadToEnd());

            
            String signature = CreateSignature(header + "." + payload, "supersecret");

            String jwt = header + "." + payload + "." + signature;
            Console.WriteLine(jwt);

        }
    }
}
