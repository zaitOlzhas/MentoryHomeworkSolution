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

            Clock clock = new Clock();
            clock.ClockStarted += (sender) => Console.WriteLine("Clock started");
            clock.ClockStopped += (sender) => Console.WriteLine("Clock stopped");
            clock.Alarm += (sender) => Console.WriteLine("Alarm");
            clock.AlarmSet += (sender) => Console.WriteLine("Alarm set");
            clock.HourChanged += (sender) => Console.WriteLine("Hour changed");
            clock.MinuteChanged += (sender) => Console.WriteLine("Minute changed");
            clock.SecondChanged += (sender) => Console.WriteLine("Second changed");
            clock.SnoozeActivated += (sender) => Console.WriteLine("Snooze activated");
            clock.FalseStop += (sender) => Console.WriteLine("False stop");
            clock.FalseStart += (sender) => Console.WriteLine("False start");
            clock.Start();
            clock.AlarmTime = DateTime.Now.AddSeconds(5);
            clock.Snooze();
            Thread.Sleep(60000); // Sleep for 1 minute while clock is running
            clock.Stop();
        }
    }
}
