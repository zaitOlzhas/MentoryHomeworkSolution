using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yermagambetov_Daniyar
{
    public class Student : IComparable<Student>
    {
        public string Name { get; }
        public int Age { get; set; }
        public int StudentId { get; set; }

        public Student(string name, int age, int id)
        {
            StudentId = id; Name = name; Age = age;
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
