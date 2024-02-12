using MainHomeworkRequirements.Classes;

namespace aituar_erzhan
{
    public class Student : Person, IComparable<Student>
    {
        public int StudentId { get; set; }
        public Student(string name, int age, int id) : base(name, age)
        {
            StudentId = id;
        }
        public override string ToString()
        {
            return $"StudentId: {StudentId}, Name: {Name}, Age: {Age}";
        }

        public int CompareTo(Student? other)
        {
            if (other is null) throw new ArgumentNullException("Некорректное значение параметра");
            else return StudentId.CompareTo(other.StudentId);
        }
    }
}
