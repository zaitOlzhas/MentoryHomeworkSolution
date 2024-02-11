namespace AbzalOrazbek
{
    public class Student : IComparable<Student>, IComparer<Student>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public Student() { }
        public Student(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public int CompareTo(Student? other)
        {
            return Id.CompareTo(other?.Id);
        }

        public int Compare(Student? x, Student? y)
        {
            return x!.Id.CompareTo(y?.Id);
        }
    }
}
