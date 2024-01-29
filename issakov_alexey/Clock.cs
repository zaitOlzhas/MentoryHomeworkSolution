using MainHomeworkRequirements;
using System;

namespace issakov_alexey
{
    public class Clock : IClock
    {
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

        private DateTime _clockTime;
        public DateTime ClockTime
        {
            get { return _clockTime; }
            private set
            {
                _clockTime = value;
                OnTimeChanged();
            }
        }

        private DateTime _alarmTime;
        public DateTime AlarmTime
        {
            get { return _alarmTime; }
            set
            {
                _alarmTime = value;
                OnAlarmSet();
            }
        }

        private bool _isRunning;

        public void Start()
        {
            if (!_isRunning)
            {
                _isRunning = true;
                ClockStarted?.Invoke(this);
                Console.WriteLine("Clock started.");
            }
            else
            {
                FalseStart?.Invoke(this);
                Console.WriteLine("Clock is already running.");
            }
        }

        public void Stop()
        {
            if (_isRunning)
            {
                _isRunning = false;
                ClockStopped?.Invoke(this);
                Console.WriteLine("Clock stopped.");
            }
            else
            {
                FalseStop?.Invoke(this);
                Console.WriteLine("Clock is already stopped.");
            }
        }

        public void Snooze()
        {
            SnoozeActivated?.Invoke(this);
            Console.WriteLine("Snooze activated.");
        }

        private void OnTimeChanged()
        {
            HourChanged?.Invoke(this);
            MinuteChanged?.Invoke(this);
            SecondChanged?.Invoke(this);
            CheckAlarm();
            Console.WriteLine($"Time changed: {ClockTime}");
        }

        private void OnAlarmSet()
        {
            AlarmSet?.Invoke(this);
            Console.WriteLine($"Alarm set for: {AlarmTime}");
        }

        private void CheckAlarm()
        {
            if (ClockTime.Hour == AlarmTime.Hour && ClockTime.Minute == AlarmTime.Minute)
            {
                Alarm?.Invoke(this);
                Console.WriteLine("Alarm!");
            }
        }
    }
}
