using MainHomeworkRequirements;
using System.Timers;
using Timer = System.Timers.Timer;

namespace zait_olzhas.ClockTask
{
    public class Clock : IClock
    {
        private bool isRunning = false;
        private Timer timer;
        private DateTime alarmTime;
        public DateTime AlarmTime
        {
            get
            {
                return alarmTime;
            }
            set
            {
                if (alarmTime != value)
                {
                    alarmTime = value;
                    AlarmSet?.Invoke(this);
                }
            }
        }
        public TimeSpan SnoozeTime { get; set; } = TimeSpan.FromMinutes(1); 

        public DateTime ClockTime { get; private set; }

        public event TimeHandler? ClockStarted;
        public event TimeHandler? ClockStopped;
        public event TimeHandler? SecondChanged;
        public event TimeHandler? MinuteChanged;
        public event TimeHandler? HourChanged;
        public event TimeHandler? Alarm;
        public event TimeHandler? AlarmSet;
        public event TimeHandler? SnoozeActivated;
        public event TimeHandler? FalseStop;
        public event TimeHandler? FalseStart;

        public Clock()
        {
            timer = new Timer(1000); 
            timer.Elapsed += TimerElapsed;
        }
        public void Start()
        {
            if (isRunning)
            {
                FalseStart?.Invoke(this);
                return;
            }

            timer.Start();
            isRunning = true;
            ClockStarted?.Invoke(this);
        }
        public void Stop()
        {
            if (!isRunning)
            {
                FalseStop?.Invoke(this);
                return;
            }

            timer.Stop();
            isRunning = false;
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

