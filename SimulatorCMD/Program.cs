using System;
using System.Collections.Generic;
using System.IO;

namespace SimulatorCMD
{
    class Program
    {
        private static string command;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path:");
            new GetInfo();
            Console.WriteLine("\nEnter the command:\n1. cd\n2. new\n3. delete");
            command = Console.ReadLine();
            SetCommand();
            
        }
        private static void SetCommand()
        {
            if (command == "cd")
            {
                Commands.CdCommand();
            }
            else
            {
                if (command == "new")
                {
                    Console.WriteLine("Write the name of file and extension with dot:");

                    Commands.CreateNew();
                }
                else if (command == "delete")
                {
                    Console.WriteLine("Write the name of file, which you wanna delete:");
                    Commands.Delete();
                }
            }
        }
    }
    public class GetInfo
    {
        public static string catalogPath = Console.ReadLine();
        public static string[] files { get; set; }
        public static string[] directories { get; set; }
        public GetInfo()
        {
            GetFiles();
            GetFolders();
        }
        private static void GetFiles()
        {
            files = (Directory.GetFiles(catalogPath));
            Console.WriteLine("\nIn this path i see these files:");
            foreach (string s in files)
            {

                Console.WriteLine(s);
            }
        }
        private static void GetFolders()
        {
            directories = (Directory.GetDirectories(catalogPath));

            Console.WriteLine("\nIn this path i see these folders: ");
            foreach (string i in directories)
            {
                Console.WriteLine(i);
            }
        }
    }
    public class Commands
    {
        private static string name = Console.ReadLine();
        private static string extension = Console.ReadLine();
        public static void CdCommand()
        {
            do
            {
                GetInfo.catalogPath = Path.GetDirectoryName(GetInfo.catalogPath);

                GetInfo.files = (Directory.GetFiles(GetInfo.catalogPath));

                GetInfo.directories = (Directory.GetDirectories(GetInfo.catalogPath));

                foreach (string c in GetInfo.files)
                {
                    foreach (string m in GetInfo.directories)
                    {
                            Console.WriteLine(c + "\n" + m);
                    }
                }
            } while (1 > 0);
        }
        public static void CreateNew()
        {
            File.Create(GetInfo.catalogPath + "\\" + name + extension);
        }
        public static void Delete()
        {
            File.Delete(GetInfo.catalogPath + "\\" + name + extension);
        }
        
    }
}
