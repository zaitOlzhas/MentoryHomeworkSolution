using MainHomeworkRequirements;
using System;

namespace issakov_alexey
{
    public class Clock : IClock
    {
        public event TimeHandler? ClockStarted;
        public event TimeHandler? ClockStopped;
        public event TimeHandler? Alarm;
        public event TimeHandler? AlarmSet;
        public event TimeHandler? HourChanged;
        public event TimeHandler? MinuteChanged;
        public event TimeHandler? SecondChanged;
        public event TimeHandler? SnoozeActivated;
        public event TimeHandler? FalseStop;
        public event TimeHandler? FalseStart;

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
                Console.WriteLine("Часы запущены.");
            }
            else
            {
                FalseStart?.Invoke(this);
                Console.WriteLine("Часы уже работают.");
            }
        }

        public void Stop()
        {
            if (_isRunning)
            {
                _isRunning = false;
                ClockStopped?.Invoke(this);
                Console.WriteLine("Часы остановлены.");
            }
            else
            {
                FalseStop?.Invoke(this);
                Console.WriteLine("Часы уже остановлены.");
            }
        }

        public void Snooze()
        {
            SnoozeActivated?.Invoke(this);
            Console.WriteLine("Режим сна активирован.");
        }

        private void OnTimeChanged()
        {
            HourChanged?.Invoke(this);
            MinuteChanged?.Invoke(this);
            SecondChanged?.Invoke(this);
            CheckAlarm();
            Console.WriteLine($"Время изменено: {ClockTime}");
        }

        private void OnAlarmSet()
        {
            AlarmSet?.Invoke(this);
            Console.WriteLine($"Будильник установлен на: {AlarmTime}");
        }

        private void CheckAlarm()
        {
            if (ClockTime.Hour == AlarmTime.Hour && ClockTime.Minute == AlarmTime.Minute)
            {
                Alarm?.Invoke(this);
                Console.WriteLine("Будильник!");
            }
        }
    }
}
