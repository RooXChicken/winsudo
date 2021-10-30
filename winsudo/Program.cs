using System;
using System.Diagnostics;

namespace winsudo
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";

            foreach(string s in args)
            {
                command += s + " ";
            }

            if(command == "")
            {
                Console.WriteLine("Provide a command dummy!");
            }
            else
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.UseShellExecute = true;
                info.Verb = "runas";
                info.WorkingDirectory = @"C:\Windows\System32";
                info.FileName = @"C:\Windows\System32\cmd.exe";
                info.Arguments = "/C" + command + " && pause";

                try
                {
                    Process.Start(info);
                    Console.WriteLine($"Running command as administrator!");
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Failed to run command as administrator. No permission!");
                }
            }
        }
    }
}
