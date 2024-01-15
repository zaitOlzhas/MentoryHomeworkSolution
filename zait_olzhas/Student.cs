using MainHomeworkRequirements.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zait_olzhas
{
    public class Student : Person
    {
        public int StudentId { get; set; }
        public Student(string name, int age, int id) : base(name, age)
        {
            StudentId = id;
        }
        public override string ToString()
        {
            return $"StudentId: {StudentId}, Name: {Name}, Age: {Age}";
        }
    }
}
