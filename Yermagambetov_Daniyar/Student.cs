using MainHomeworkRequirements.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yermagambetov_Daniyar
{
    public class Student : Person,  IComparable<Student>
    {
        public int StudentId { get; set; }

        public Student(string name, int age, int id) : base(name, age)
        {
            StudentId = id; 
        }

        public int CompareTo(Student? other)
        {
            throw new NotImplementedException();
        }
    }
}
