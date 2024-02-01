using MainHomeworkRequirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zhaxybayev_askhat
{
    public class Clock : IClock
    {
        public DateTime ClockTime { get=>DateTime.Now; }
        bool ClockStart = false;
        private int Second = DateTime.Now.Second, Minute = DateTime.Now.Minute, Hour = DateTime.Now.Hour;
        public DateTime AlarmTime { get; set; }

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
            SnoozeActivated?.Invoke(this);
            AlarmTime=DateTime.Now.AddSeconds(30);
        }

        public void Start()
        {
            if (ClockStart)
            {
                FalseStart?.Invoke(this);
                AlarmSet?.Invoke(this);
            }
            else
            {
                AlarmSet?.Invoke(this);
                ClockStarted?.Invoke(this);
                ClockStart = true;
                Starting();
                
            }
        }

        public void Stop()
        {
            if (!ClockStart)
            {
                FalseStop?.Invoke(this);
            }
            else
            {
                ClockStart = false;
                ClockStopped?.Invoke(this);
            }
        }
        public async void Starting()
        {
          await Task.Run(delegate
          {
              while (ClockStart)
              {
                  if (Hour != ClockTime.Hour)
                  {
                      HourChanged?.Invoke(this);
                      Hour = ClockTime.Hour;
                  }
                  if (Minute != ClockTime.Minute)
                  {
                      MinuteChanged?.Invoke(this);
                      Minute = ClockTime.Minute;
                  }
                  if (Second != ClockTime.Second)
                  {
                      SecondChanged?.Invoke(this);
                      Second = ClockTime.Second;
                  }
                  if (ClockTime == AlarmTime)
                  {
                      Alarm?.Invoke(this);
                  }
              }
          }
          );
          
        }
        /*
          IClock clock = new Clock();
            clock.AlarmTime = DateTime.Now.AddSeconds(30);
            //Console.WriteLine(clock.AlarmTime);
            clock.ClockStarted += ClockStartt;
            clock.ClockStopped += ClockStop;
            clock.Alarm += Alarm;
            clock.AlarmSet += AlarmSet;
            clock.HourChanged += HourChanged;
            clock.MinuteChanged += MinuteChanged;
            clock.SecondChanged += SecondChanged;
            clock.FalseStart += FalseStart;
            clock.FalseStop += FalseStop;
            clock.SnoozeActivated += SnoozeActivated;
            clock.Start();
            clock.Start();
            Console.ReadKey();
            clock.Stop();

            void ClockStartt(IClock sender) 
            {
                Console.WriteLine($"{sender.ClockTime}");
            }
            void ClockStop(IClock sender)
            {
                Console.WriteLine($"Clock stopped at {sender.ClockTime}");
            }
            void Alarm(IClock sender)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"!!! Alarm !!!\n{sender.ClockTime}");
                Console.ResetColor();
                sender.Snooze();
            }
            void AlarmSet(IClock sender)
            {
                Console.WriteLine($"Alarm set at {sender.AlarmTime}");
            }
            void HourChanged(IClock sender)
            {
                Console.WriteLine($"Hour changed{sender.ClockTime}");
            }
            void MinuteChanged(IClock sender)
            {
                Console.WriteLine($"Minute changed {sender.ClockTime}");
            }
            void SecondChanged(IClock sender)
            {
                Console.WriteLine($"Second changed {sender.ClockTime}");
            }
            void SnoozeActivated(IClock sender)
            {
                Console.WriteLine($"Snooze activate(Alarm after 30 seconds) {sender.ClockTime}");
            }
            void FalseStop(IClock sender)
            {
                Console.WriteLine($"Clocl already stopped {sender.ClockTime}");
            }
            void FalseStart(IClock sender)
            {
                Console.WriteLine($"Clock already started {sender.ClockTime}");
            }
         */
    }
}
