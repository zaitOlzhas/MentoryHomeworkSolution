namespace AbzalOrazbek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new(1, "Abzal", 20),
                new(5, "Orazbek", 21),
                new(4, "Another Student 1", 19),
                new(2, "Test student", 22),
                new(3, "Student)", 23)
            };
            students.ForEach(student => Console.Write(student.Name + " "));
            Console.WriteLine();
            students.Sort();
            students.ForEach(student => Console.Write(student.Name + " "));
            Console.WriteLine();
        }
    }
}
