using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4
{   
    [Serializable]
    class Student
    {
        public string name;
        public int age;
        public double gpa=2.0;
        public Student(string n, int a)
        {
            name = n;
            age = a;
        }
        public override string ToString()
        {
            return name + " " + age + " " + gpa; ;
        }
    }
}
