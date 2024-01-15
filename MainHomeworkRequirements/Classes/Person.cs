using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainHomeworkRequirements.Classes
{
    public class Person : IComparable<Person>
    {
        public string Name { get; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name; Age = age;
        }
        public int CompareTo(Person? person)
        {
            if (person is null) throw new ArgumentException("Некорректное значение параметра");
            return Name.CompareTo(person.Name);
        }
    }
}
