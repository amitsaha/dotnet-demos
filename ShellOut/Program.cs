using System;
using System.Diagnostics;

namespace ShellOut
{
    class Program
    {
        static void Main(string[] args)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.FileName = args[0];
            foreach(string a in args)
            {
                myProcess.StartInfo.Arguments += a + " ";
            }
            myProcess.Start();
            myProcess.WaitForExit();

            Console.WriteLine("Process exited with exit code: " + myProcess.ExitCode);

            // continue with https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process.exitcode?view=netcore-2.1
        }
    }
    
}
