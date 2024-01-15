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
            Console.WriteLine(string.Join("\r\n", students));
            Console.WriteLine();
            students.Sort();
            Console.WriteLine(string.Join("\r\n", students));
        }
    }
}