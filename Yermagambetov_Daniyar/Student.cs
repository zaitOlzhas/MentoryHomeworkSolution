using MainHomeworkRequirements.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yermagambetov_Daniyar
{
    public class Student : Person
    {
        public int StudentId { get; set; }

        public Student(string name, int age, int id) : base(name, age)
        {
            StudentId = id; 
        }
        public int CompareTo(Student? person)
        {
            if (person is null) throw new ArgumentException("Некорректное значение параметра");
            return StudentId.CompareTo(person.StudentId);
        }
        public override string ToString()
        {
            return $"StudentId: {StudentId}, Name: {Name}, Age: {Age}";
        }
    }
}
