using MainHomeworkRequirements.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
            if (other is null) throw new ArgumentNullException("Не присвоено значение.");
            else return StudentId.CompareTo(other.StudentId);
        }
    }
}
