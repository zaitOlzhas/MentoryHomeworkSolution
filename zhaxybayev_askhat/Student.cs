using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zhaxybayev_askhat
{
    public class Student : IComparable<Student>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Student(string name, int age, int id) {
            Name = name;
            Age = age;
            Id = id;
        }
        public int CompareTo(Student? student)
        {
            if (student is null) throw new ArgumentException("Некорректное значение параметра");
            return Id - student.Id;
        }
        public override string ToString()
        {
            return $"StudentId: {Id}, Name: {Name}, Age: {Age}";
        }
    }
}
