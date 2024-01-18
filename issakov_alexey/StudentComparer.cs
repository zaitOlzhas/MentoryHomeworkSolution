using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace issakov_alexey
{
    public class StudentIdComparer : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            if (x is null || y is null) throw new ArgumentException("Input value cannot be null.");
            return x.StudentId.CompareTo(y.StudentId);
        }
    }
}
