using MainHomeworkRequirements.Classes;

namespace orazbek_abzal
{
    public class Student : Person, IComparable<Student>
    {
        private static int _id = 0;
        public int Id { get; set; }

        public Student(string name, int age) : base(name, age)
        {
            Id = _id++;
        }
        public Student(string name, int age, int id) : base(name, age)
        {
            Id = id;
        }
        public int CompareTo(Student? other)
        {
            return Id.CompareTo(other?.Id);
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}";
        }
    }
}
