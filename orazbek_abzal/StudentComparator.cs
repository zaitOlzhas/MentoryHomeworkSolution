using MainHomeworkRequirements.Classes;

namespace orazbek_abzal
{
    public class StudentComparator : PersonComparer, IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            if (x is null || y is null) throw new ArgumentException("Некорректное значение параметра");
            return x.Id.CompareTo(y.Id);
        }
    }
}
