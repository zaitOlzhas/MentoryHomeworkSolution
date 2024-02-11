using MainHomeworkRequirements;

namespace AbzalOrazbek
{
    internal class Clock : IClock
    {
        private bool isRunning = false;
        public DateTime ClockTime => _currentTime;
        public DateTime AlarmTime
        {
            get => _alarmTime;
            set
            {
                _alarmTime = value;
                AlarmSet?.Invoke(this);
            }
        }
        private DateTime _alarmTime { get; set; }
        private DateTime _currentTime { get; set; }

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

        public void Snooze()
        {
            AlarmTime = DateTime.Now.AddSeconds(5);
            SnoozeActivated?.Invoke(this);
        }

        public void Start()
        {
            if (isRunning)
            {
                FalseStart?.Invoke(this);
                AlarmSet?.Invoke(this);
            }
            else
            {
                AlarmSet?.Invoke(this);
                ClockStarted?.Invoke(this);
                isRunning = true;
                _ = RunClock();
            }
        }

        public void Stop()
        {
            if (!isRunning)
            {
                FalseStop?.Invoke(this);
            }
            else
            {
                isRunning = false;
                ClockStopped?.Invoke(this);
            }
        }
        private async Task RunClock()
        {
            while (isRunning)
            {
                await Task.Delay(1000);
                if (_currentTime.Second != DateTime.Now.Second)
                {
                    SecondChanged?.Invoke(this);
                }
                if (_currentTime.Minute != DateTime.Now.Minute)
                {
                    MinuteChanged?.Invoke(this);
                }
                if (_currentTime.Hour != DateTime.Now.Hour)
                {
                    HourChanged?.Invoke(this);
                }
                if (AlarmTime == DateTime.Now)
                {
                    Alarm?.Invoke(this);
                }
                _currentTime = DateTime.Now;
            }
        }
    }
}
