using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace docker_dircp
{
    class Program
    {
        static async Task<IList<ContainerListResponse>> ListContainersAsync(DockerClient client)
        {
            Console.WriteLine("Listing containers");           
            return await client.Containers.ListContainersAsync(new ContainersListParameters() { Limit = 10, });            
            
        }           


        static void Main(string[] args)
        {            
            DockerClient client = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient();
            var containers = ListContainersAsync(client);
            foreach (var c in containers.Result)
            {
                Console.WriteLine(c.Names[0]);
            }

        }
    }
}
