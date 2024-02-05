using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yermagambetov_Daniyar
{
    internal class IComparer : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            if (x is null || y is null) throw new ArgumentException("Пустые значения.");

            return x.StudentId.CompareTo(y.StudentId);
        }
    }
}
