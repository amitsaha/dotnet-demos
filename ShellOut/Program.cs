using System;
using System.Diagnostics;
using System.IO;

namespace ShellOut
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Process myProcess = new Process())
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = args[0];
                myProcess.StartInfo.RedirectStandardOutput = true;

                if (args.Length >=1 )
                {
                    for(var i=1; i < args.Length; i++)
                    {
                        myProcess.StartInfo.Arguments += args[i] + " ";
                    }
                }
                
                myProcess.Start();
                StreamReader reader = myProcess.StandardOutput;
                string output = reader.ReadToEnd();
                Console.WriteLine(output);
                myProcess.WaitForExit();
                Console.WriteLine("Process exited with exit code: " + myProcess.ExitCode);
            }
            // continue with https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process.exitcode?view=netcore-2.1
        }
    }
    
}
