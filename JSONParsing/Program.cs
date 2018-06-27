using System;
using Newtonsoft.Json;

namespace JSONParsing
{
    class Program
    {
        static void Main(string[] args)
        {
           var jsonData =  JsonConvert.SerializeObject(new
            {
                key1 = "value1",
                Payload = JsonConvert.SerializeObject(new
                {
                    Id = 1,
                }),
             });
            Console.WriteLine(jsonData);
            // Deserialize json encoded string to an object
            var jsonObject = JsonConvert.DeserializeObject(jsonData);
            Console.WriteLine(jsonObject);           
        }
    }
}
