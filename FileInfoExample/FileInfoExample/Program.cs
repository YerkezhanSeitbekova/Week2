using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileInfoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo ourDir = new DirectoryInfo(@"C:\Program Files");

            Console.WriteLine("Directory: {0}", ourDir.FullName);

            foreach (FileInfo file in ourDir.GetFiles()) // file is iterator
            {
                Console.WriteLine("File: {0}", file.Name);
            }
            int n = 0;
            while (true)
            {
                Console.Clear();
                int i = 0;
                foreach (DirectoryInfo dir in ourDir.GetDirectories()) // dir is iterator
                {
                    i++;
                    if (i == n) Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Directory: {0} {1}", i, dir.Name); // Console.WriteLine("Directory: " + i + " " + dir.Name);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                ConsoleKeyInfo k = Console.ReadKey();
                if (k.Key.Equals(ConsoleKey.DownArrow) && n<ourDir.GetDirectories().Length ) n++; //down
                if (k.Key.Equals(ConsoleKey.UpArrow) && n!=0) n--;  // up
                if (k.Key.Equals(ConsoleKey.Enter)) ourDir = ourDir.GetDirectories()[n - 1]; // open current directory
                if (k.Key.Equals(ConsoleKey.LeftArrow)) ourDir = ourDir.Parent;
            }
            
            /*
            ConsoleKeyInfo k = Console.ReadKey();
            int n = (int)k.KeyChar - 48; // '0' = 48
            Console.Clear();
            ourDir = ourDir.GetDirectories()[n-1];
            i = 0;
            foreach (DirectoryInfo dir in ourDir.GetDirectories()) // dir is iterator
            {
                i++;
                Console.WriteLine("Directory: {0} {1}", i, dir.Name); // Console.WriteLine("Directory: " + i + " " + dir.Name);
            }
            */
            Console.ReadKey();
        }
    }
}
