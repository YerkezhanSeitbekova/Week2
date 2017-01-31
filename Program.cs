using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week3
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo ourDir = new DirectoryInfo(@"C:\Program Files");
            Console.SetWindowSize(90, 69);
            Stack<DirectoryInfo> stack = new Stack<DirectoryInfo>();
            int n = 1;
            int prevN = -1;
            while (true)
            {
                Console.CursorLeft = 0;
                if (prevN == -1)
                {
                    print(ourDir);
                }   else
                {
                    Console.CursorTop = prevN - 1;
                    Console.BackgroundColor = ConsoleColor.Black;
                    if (prevN <= ourDir.GetDirectories().Length)
                    {
                        Console.WriteLine("Directory: {0} {1} ", prevN, ourDir.GetDirectories()[prevN - 1]);
                    }
                    else
                    {
                        int fileIndex = prevN - ourDir.GetDirectories().Length - 1;
                        Console.WriteLine("File: {0} {1} ", prevN, ourDir.GetFiles()[fileIndex]);
                    }
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.CursorTop = n - 1;
                        if (n <= ourDir.GetDirectories().Length)
                    {
                        Console.WriteLine("Directory: {0} {1} ", n, ourDir.GetDirectories()[n - 1]);
                    }
                    else
                    {
                        int fileIndex = n - ourDir.GetDirectories().Length - 1;
                        Console.WriteLine("File: {0} {1} ", n, ourDir.GetFiles()[fileIndex]);
                    }
                }

                Console.CursorTop = ourDir.GetFileSystemInfos().Length;
                Console.BackgroundColor = ConsoleColor.Black;
                ConsoleKeyInfo k = Console.ReadKey();
                switch (k.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (n < ourDir.GetFileSystemInfos().Length)
                        {
                            prevN = n;
                            n++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (n != 1 )
                        {
                            prevN = n;
                            n--;
                        }
                        break;
                    case ConsoleKey.Enter:
                        prevN = -1;
                        if (n <= ourDir.GetDirectories().Length)
                        {
                            stack.Push(ourDir);
                            ourDir = ourDir.GetDirectories()[n - 1];
                        }
                        else
                        {
                            int fileIndex = n - ourDir.GetDirectories().Length - 1;
                            Console.Clear();
                            Console.WriteLine(ourDir.GetFiles()[fileIndex].FullName); //replace!!
                            //StreamReader sr = ourDir.GetFiles()[fileIndex].OpenText();
                            while (true)
                            {
                                ConsoleKeyInfo key = Console.ReadKey();
                                if (key.Key.Equals(ConsoleKey.Escape)) break;
                            }
                        }
                        n = 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (stack.Count != 0)
                        {
                            ourDir = stack.Pop();
                            prevN = -1;
                        }
                        break;
                }
                               
            }

            
        }
        private static void print(DirectoryInfo ourDir)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            int n = 1;
            int i = 0;
            foreach (DirectoryInfo dir in ourDir.GetDirectories()) // dir is iterator
            {
                i++;
                if (i == n) Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("Directory: {0} {1} ", i, dir.Name);
                Console.BackgroundColor = ConsoleColor.Black;
            }

            foreach (FileInfo file in ourDir.GetFiles()) // file is iterator
            {
                i++;
                if (i == n) Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("File: {0} {1} ", i, file.Name);
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}
