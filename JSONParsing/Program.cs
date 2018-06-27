using System;
using Newtonsoft.Json;

namespace JSONParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonData = @"{""Id"":""06094ea0-1aa4-47b8-9c11-ad18cb18ee72""}";
            
           // Deserialize json encoded string to an object
           var jsonObject = JsonConvert.DeserializeObject(jsonData);
           Console.WriteLine(jsonObject);
        }
    }
}
