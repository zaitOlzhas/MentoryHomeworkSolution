using MainHomeworkRequirements.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timur_naskenov
{
    public class Student : Person, IComparable<Student>
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

        public int CompareTo(Student? other)
        {
            if (other is null) throw new ArgumentNullException("Input value cannot be null.");
            else return StudentId.CompareTo(other.StudentId);
        }
    }
    
}
