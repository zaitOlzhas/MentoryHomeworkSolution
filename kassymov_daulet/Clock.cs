using MainHomeworkRequirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace kassymov_daulet
{
    public class Clock : IClock
    {
        public TimeSpan SnoozeTime { get; set; } = TimeSpan.FromMinutes(1);

        private DateTime _alarmTime;
        private bool timeIsRunning = false;
        private System.Timers.Timer timer;

        public event TimeHandler? AlarmSet;
        public event TimeHandler? FalseStart;
        public event TimeHandler? FalseStop;
        public event TimeHandler? ClockStarted;
        public event TimeHandler? ClockStopped;
        public event TimeHandler? SecondChanged;
        public event TimeHandler? MinuteChanged;
        public event TimeHandler? HourChanged;
        public event TimeHandler? Alarm;
        public event TimeHandler? SnoozeActivated;

        public DateTime ClockTime
        {
            get
            {
                return DateTime.Now;
            }
            private set { }
        }


        public DateTime AlarmTime
        {
            get
            {
                return _alarmTime;
            }
            set
            {
                _alarmTime = value;
                AlarmSet?.Invoke(this);
            }
        }
        public Clock()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += TimerElapsed;
        }

        public void Start()
        {
            if (timeIsRunning)
            {
                FalseStart?.Invoke(this);
                return;
            }

            timer.Start();
            timeIsRunning = true;
            ClockStarted?.Invoke(this);
        }

        public void Stop()
        {
            if (!timeIsRunning)
            {
                FalseStop?.Invoke(this);
                return;
            }

            timer.Stop();
            timeIsRunning = false;
            ClockStopped?.Invoke(this);
        }

        public void Snooze()
        {
            AlarmTime = DateTime.Now.Add(SnoozeTime);
            SnoozeActivated?.Invoke(this);
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            ClockTime = DateTime.Now;
            SecondChanged?.Invoke(this);

            if (ClockTime.Second == 0)
            {
                MinuteChanged?.Invoke(this);
            }

            if (ClockTime.Minute == 0 && ClockTime.Second == 0)
            {
                HourChanged?.Invoke(this);
            }

            if (ClockTime.Hour == AlarmTime.Hour && ClockTime.Minute == AlarmTime.Minute && ClockTime.Second == AlarmTime.Second)
            {
                Alarm?.Invoke(this);
            }
        }
    }
}
