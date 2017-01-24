using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace MilkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Milk m1 = new Milk(1.5, 1.5);
            Milk m2 = new Milk(2.5, 1.9);
            Console.WriteLine(m1);
            Milk m3 = m1 + m2;
            Console.WriteLine(m3);
            Milk m4 = m1 * 5;
            Console.WriteLine(m4);
            //double f = (1.5 * 1.5 + 2.5 * 1.9) / (1.5 + 2.5);
            double f = (m1.fatness + m2.fatness) / (m1.mass + m2.mass);
            Console.WriteLine(f);
            Console.ReadKey();
        }
    }
    class Milk
    {
        public double mass;
        public double fatness;
        public Milk(double m, double f)
        {
            mass = m;
            fatness = f;
        }
        public static Milk operator + (Milk m1, Milk m2)
        {
            double f = (m1.fatness + m2.fatness) / (m1.mass + m2.mass);
            return new Milk(m1.mass + m2.mass, f);
        }
        public static Milk operator * (Milk m1, int n)
        {
            
            return new Milk(m1.mass*n, m1.fatness);
        }
        public override string ToString()
        {
            return "Mass "+mass+" Fatness " +fatness + "%";
        }
    }
}
