using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;


namespace Week4
{
    class Program
    {
        static void Main(string[] args)
        {
            //serialize();
            deserialize();
            Console.ReadKey();
            
        }
        static void serialize()
        {
            Student[] students = new Student[5];
            students[0] = new Student("Ali", 19);
            students[1] = new Student("Bota", 18);
            students[2] = new Student("Erik", 20);
            students[3] = new Student("Beibut", 17);
            FileStream sW = File.Create("Data.txt");
            //SoapFormatter sf = new SoapFormatter();
            BinaryFormatter binF = new BinaryFormatter();
            Student s = new Student("Alina", 30);
            binF.Serialize(sW, students);
            binF.Serialize(sW, s);
        }
        static void deserialize()
        {
            Student[] students = new Student[5];
            
            FileStream sW = File.OpenRead("Data.txt");
            //SoapFormatter sf = new SoapFormatter();
            BinaryFormatter binF = new BinaryFormatter();
            Student s; 
            students = (Student[])binF.Deserialize(sW);
            s = (Student)binF.Deserialize(sW);
            foreach (Student ss in students)
            {
                Console.WriteLine(ss);
            }
            Console.WriteLine(s);

            sW.Close();
            Console.ReadKey();
        }
    }
   
}
