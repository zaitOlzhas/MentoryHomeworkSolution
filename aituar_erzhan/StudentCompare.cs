namespace aituar_erzhan
{
    public class StudentComparer : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            if (x is null || y is null) throw new ArgumentException("Некорректное значение параметра");

            return x.StudentId.CompareTo(y.StudentId);

        }
    }
}
