using MainHomeworkRequirements.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace issakov_alexey
{
    public class Student : Person
    {
        public int StudentId { get; }

        public Student(string name, int age, int studentId) : base(name, age)
        {
            StudentId = studentId;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, StudentId: {StudentId}";
        }
    }
}
