using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MainHomeworkRequirements;

namespace timur_naskenov
{
    public class Clock : IClock
    {
        private bool _isStarted = false;
        private bool _isSnoozed = true;
        private DateTime _alarmTime;
        public Clock() {
            AlarmTime = ClockTime;
        }
        public TimeSpan SnoozeDuration = TimeSpan.FromSeconds(10);
        
        public DateTime ClockTime { get => DateTime.Now; }
        public DateTime AlarmTime {
            get { return _alarmTime; }
            set
            {
                _alarmTime = value;
                AlarmSet?.Invoke(this);
            } 
        }

        public event TimeHandler ClockStarted;
        public event TimeHandler ClockStopped;
        public event TimeHandler Alarm;
        public event TimeHandler AlarmSet;
        public event TimeHandler HourChanged;
        public event TimeHandler MinuteChanged;
        public event TimeHandler SecondChanged;
        public event TimeHandler SnoozeActivated;
        public event TimeHandler FalseStop;
        public event TimeHandler FalseStart;

        public void Snooze()
        {
            _alarmTime += SnoozeDuration;
            SnoozeActivated?.Invoke(this);
            _isSnoozed = false;
        }

        public void Start()
        {
            if (_isStarted)
            {
                FalseStart?.Invoke(this);
            } else
            {
                _isStarted = true;
                StartClockAsync();
                ClockStarted?.Invoke(this);
            }
        }

        public void Stop()
        {
            if (!_isStarted) 
            {
                FalseStop?.Invoke(this);
            } else
            {
                _isStarted = false;
                ClockStopped?.Invoke(this);
            }
        }

        private async void StartClockAsync()
        {
            await Task.Run(delegate ()
            {
                int hour = ClockTime.Hour;
                int minute = ClockTime.Minute;
                int second = ClockTime.Second;
                while (_isStarted)
                {
                    if (hour != ClockTime.Hour)
                    {
                        HourChanged?.Invoke(this);
                        hour = ClockTime.Hour;
                    }
                    if (minute != ClockTime.Minute) 
                    {
                        MinuteChanged?.Invoke(this);
                        minute = ClockTime.Minute;
                    }
                    if (second != ClockTime.Second)
                    {
                        SecondChanged?.Invoke(this);
                        second = ClockTime.Second;
                    }
                    if (_alarmTime <= ClockTime)
                    {
                        Alarm?.Invoke(this);
                        if (_isSnoozed)
                        {
                            Snooze();
                        } else
                        {
                            Stop();
                        }
                    }
                    }
                });
            
        }
    }
}

/* static void Main(string[] args)
        {
            Clock clock = new Clock();
            clock.Alarm += (x) => Console.WriteLine($"ALARMING! at {x.ClockTime.ToString("dd.MM.yyyy hh:mm:ss")}");
            clock.AlarmSet += (x) => Console.WriteLine($"Alarm set at {x.AlarmTime.ToString("dd.MM.yyyy hh:mm:ss")}");
            clock.ClockStarted += (x) => Console.WriteLine($"Clock started. Current time is {x.ClockTime.ToString("dd.MM.yyyy hh:mm:ss")}");
            clock.ClockStopped += (x) => Console.WriteLine("Clock stopped.");
            clock.FalseStart += (x) => Console.WriteLine("False start! Clock already started.");
            clock.FalseStop += (x) => Console.WriteLine("False stop! Clock haven't been started yet.");
            clock.HourChanged += (x) => Console.WriteLine($"Hour changed. Curent time is {x.ClockTime.ToString("dd.MM.yyyy hh:mm:ss")}");
            clock.MinuteChanged += (x) => Console.WriteLine($"Minute changed. Curent time is {x.ClockTime.ToString("dd.MM.yyyy hh:mm:ss")}");
            clock.SecondChanged += (x) => Console.WriteLine($"Second changed. Curent time is {x.ClockTime.ToString("dd.MM.yyyy hh:mm:ss")}");
            clock.SnoozeActivated += (x) => Console.WriteLine($"Snooze activated! Next alarm at {x.AlarmTime.ToString("dd.MM.yyyy hh:mm:ss")}");
            clock.AlarmTime = DateTime.Now.AddSeconds(12);
            clock.Stop();
            clock.Start();
            Thread.Sleep(1000);
            clock.Start();
            Thread.Sleep(60000);

            Console.WriteLine("End of programm");

        }

*/
