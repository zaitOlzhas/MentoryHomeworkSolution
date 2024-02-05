using MainHomeworkRequirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zait_olzhas.ClockTask
{
    internal class Clock1 : IClock
    {
        public DateTime ClockTime => throw new NotImplementedException();

        public DateTime AlarmTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
