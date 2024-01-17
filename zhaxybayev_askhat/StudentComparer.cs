using MainHomeworkRequirements.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zhaxybayev_askhat
{
    public class IdStudentComparer : IComparer<Student>
    {
        public int Compare(Student? s1, Student? s2)
        {
            if (s1 is null || s2 is null)
                throw new ArgumentException("Некорректное значение параметра");
            return s1.Id - s2.Id;
        }
    }
}
