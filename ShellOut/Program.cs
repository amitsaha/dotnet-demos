using System;
using System.Diagnostics;
using System.IO;

namespace ShellOut
{
    class Program
    {
        static void Main(string[] args)
        {
             // Define variables to track the peak
            // memory usage of the process.
            long peakPagedMem = 0,
                peakWorkingSet = 0,
                peakVirtualMem = 0;
            
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
                do
                {
                    if (!myProcess.HasExited)
                    {
                        // Refresh the current process property values.
                        myProcess.Refresh();

                        Console.WriteLine();

                        // Display current process statistics.

                        Console.WriteLine("{0} -", myProcess.ToString());
                        Console.WriteLine("-------------------------------------");

                        Console.WriteLine("  physical memory usage: {0}",
                            myProcess.WorkingSet64);
                        Console.WriteLine("  base priority: {0}",
                            myProcess.BasePriority);
                        Console.WriteLine("  priority class: {0}",
                            myProcess.PriorityClass);
                        Console.WriteLine("  user processor time: {0}",
                            myProcess.UserProcessorTime);
                        Console.WriteLine("  privileged processor time: {0}",
                            myProcess.PrivilegedProcessorTime);
                        Console.WriteLine("  total processor time: {0}",
                            myProcess.TotalProcessorTime);
                        Console.WriteLine("  PagedSystemMemorySize64: {0}",
                            myProcess.PagedSystemMemorySize64);
                        Console.WriteLine("  PagedMemorySize64: {0}",
                           myProcess.PagedMemorySize64);

                        // Update the values for the overall peak memory statistics.
                        peakPagedMem = myProcess.PeakPagedMemorySize64;
                        peakVirtualMem = myProcess.PeakVirtualMemorySize64;
                        peakWorkingSet = myProcess.PeakWorkingSet64;

                        if (myProcess.Responding)
                        {
                            Console.WriteLine("Status = Running");
                        }
                        else
                        {
                            Console.WriteLine("Status = Not Responding");
                        }
                    }
                }
                while (!myProcess.WaitForExit(10000));

                string output = reader.ReadToEnd();
                Console.WriteLine(output);
                Console.WriteLine("Process exit code: {0}", myProcess.ExitCode);

                // Display peak memory statistics for the process.
                Console.WriteLine("Peak physical memory usage of the process: {0}",
                    peakWorkingSet);
                Console.WriteLine("Peak paged memory usage of the process: {0}",
                    peakPagedMem);
                Console.WriteLine("Peak virtual memory usage of the process: {0}",
                    peakVirtualMem);

            }
        }
    }
}
