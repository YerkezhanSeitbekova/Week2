using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileExample
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file = new FileStream(@"D:\new_txtfile.txt", FileMode.Open);
            StreamReader sr = new StreamReader(file);
            while (!sr.EndOfStream)
            {   
                Console.WriteLine(sr.ReadLine());
            }
            sr.Close();
            
            /*StreamWriter sw = new StreamWriter(file);
            sw.Write("Hello students ");
            sw.WriteLine(5);
            sw.WriteLine("The end!");
            sw.Close();  
             */ 
            file.Close();
            Console.ReadKey();
        }
    }
}
