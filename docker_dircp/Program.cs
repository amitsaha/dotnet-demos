using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace docker_dircp
{
    class Program
    {
        static async Task<IList<ContainerListResponse>> ListContainersAsync(DockerClient client)
        {
            return await client.Containers.ListContainersAsync(new ContainersListParameters() { Limit = 100, });

        }

        static ContainerListResponse CheckContainerExists(DockerClient client, String ContainerId)
        {
            var containers = ListContainersAsync(client);
            foreach (var c in containers.Result)
            {
                // Reliable enough?
                if (c.ID.StartsWith(ContainerId))
                {
                    return c;
                }
            }
            return null;
        }

        static void CopyDirectoryFromContainer(DockerClient client, String ContainerId, String DirToCopy)
        {
            var container = CheckContainerExists(client, ContainerId);

            if (container == null)
            {
                Console.WriteLine("Container doesn't exist");
            }
            else
            {
                GetArchiveFromContainerParameters ArchiveParameters = new GetArchiveFromContainerParameters
                {
                    Path = DirToCopy
                };
                try
                {
                    var TaskResult = client.Containers.GetArchiveFromContainerAsync(container.ID, ArchiveParameters, false);
                    var data = TaskResult.Result.Stream;                    

                    MemoryStream ms = new MemoryStream();
                    data.CopyTo(ms);
                    ms.Dispose();

                    var DestFilename = Path.GetFileName(DirToCopy) + ".tar";
                    Console.WriteLine("Writing: " + DestFilename);
                    File.WriteAllBytes(DestFilename, ms.ToArray());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error when retrieving files: " + e.Message);
                }
            }
        }


        static void Main(string[] args)
        {
            DockerClient client = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient();
            CopyDirectoryFromContainer(client, args[0], args[1]);

        }
    }
}
