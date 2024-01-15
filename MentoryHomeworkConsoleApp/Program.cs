using MainHomeworkRequirements.Classes;
using zait_olzhas;

namespace MentoryHomeworkConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>();
            students.Add(new Student("Erzhan", 18, 42));
            students.Add(new Student("Alexey", 19, 51));
            students.Add(new Student("Daulet", 20, 26));
            students.Add(new Student("Ernurr", 21, 14));
            students.Add(new Student("Olzhas", 22, 19));
            students.Add(new Student("Askhat", 23, 11));

            Console.WriteLine("Original list.");
            Console.WriteLine(string.Join("\r\n", students));
            Console.WriteLine();

            Console.WriteLine("Sort by age list.");
            students.Sort();
            Console.WriteLine(string.Join("\r\n", students));
            Console.WriteLine();

            Console.WriteLine("Sort by student id list via IComparer.");
            students.Sort(new PersonComparer());
            Console.WriteLine(string.Join("\r\n", students));
        }
    }
}