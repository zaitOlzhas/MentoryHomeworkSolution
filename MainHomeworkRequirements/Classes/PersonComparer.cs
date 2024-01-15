using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainHomeworkRequirements.Classes
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person? x, Person? y)
        {
            if (x is null || y is null) throw new ArgumentException("Некорректное значение параметра");
            return x.Age.CompareTo(y.Age);
        }
    }
}
