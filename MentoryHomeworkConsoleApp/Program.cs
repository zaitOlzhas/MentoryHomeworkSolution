using MainHomeworkRequirements;
using Daulet_Abdikerim;
namespace MentoryHomeworkConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IClock clock = new Clock();
            clock.Start();
            clock.ClockStarted += Clock_ClockStarted;
            clock.ClockStopped += Clock_ClockStopped;
            clock.Alarm += Clock_Alarm;
            clock.HourChanged += Clock_HourChanged;
            clock.MinuteChanged += Clock_MinuteChanged;
            clock.SecondChanged += Clock_SecondChanged;
            clock.AlarmSet += Clock_AlarmSet;
            clock.FalseStart += Clock_FalseStart;
            clock.FalseStop += Clock_FalseStop;
            clock.SnoozeActivated += Clock_SnoozeActivated;
            clock.AlarmTime = DateTime.Now.AddMinutes(1);
            clock.Start();
            Console.ReadKey();
            clock.Stop();
        }

        private static void Clock_FalseStop(IClock sender)
        {
            Console.WriteLine($"Clock is already stopped {sender.ClockTime}");
        }

        private static void Clock_SnoozeActivated(IClock sender)
        {
            Console.WriteLine($"Snooze activated {sender.ClockTime}");
        }

        private static void Clock_FalseStart(IClock sender)
        {
           Console.WriteLine($"Clock is already running {DateTime.Now}");
        }

        private static void Clock_AlarmSet(IClock sender)
        {
           Console.WriteLine($"Alarm set {sender.AlarmTime}");
        }

        private static void Clock_ClockStopped(IClock sender)
        {
            Console.WriteLine($"Clock stopped {sender.ClockTime}");
        }

        private static void Clock_ClockStarted(IClock sender)
        {
            Console.WriteLine($"Clock started {sender.ClockTime}");
        }

        private static void Clock_SecondChanged(IClock sender)
        {
            Console.WriteLine($"Second changed {sender.ClockTime}");
        }

        private static void Clock_MinuteChanged(IClock sender)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Minute changed {sender.ClockTime}");
            Console.ResetColor();
        }

        private static void Clock_HourChanged(IClock sender)
        {
            Console.WriteLine($"Hour changed {sender.ClockTime}");
        }

        private static void Clock_Alarm(IClock sender)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Alarm { sender.ClockTime}"); 
            Console.ResetColor();
            Console.Beep(500, 1000); 
            sender.Snooze();
        }
    }
}