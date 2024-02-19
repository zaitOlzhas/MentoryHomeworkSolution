using MainHomeworkRequirements;

namespace aituar_erzhan
{
    public class Clock : IClock
    {
        private bool _isStarted = false;
        private bool _isSnoozed = true;
        private DateTime _alarmTime;
        public Clock()
        {
            AlarmTime = ClockTime;
        }
        public TimeSpan SnoozeDuration = TimeSpan.FromSeconds(10);

        public DateTime ClockTime { get => DateTime.Now; }
        public DateTime AlarmTime
        {
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
            }
            else
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
            }
            else
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
                        }
                        else
                        {
                            Stop();
                        }
                    }
                }
            });

        }
    }
}
