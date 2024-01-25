using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainHomeworkRequirements
{
    public delegate void TimeHandler(IClock sender);
    public interface IClock
    {
        /// <summary>
        /// Property to get clock time, set time is private so can only be set by derived classes
        /// </summary>
        DateTime ClockTime { get; }
        /// <summary>
        /// Property to set alarm time and fire AlarmSet event
        /// </summary>
        DateTime AlarmTime { get; set; }
        /// <summary>
        /// Method to start clock and fire ClockStarted event
        /// </summary>
        void Start();
        /// <summary>
        /// Method to stop clock and fire ClockStopped event
        /// </summary>
        void Stop();
        /// <summary>
        /// Method to snooze alarm and fire SnoozeActivated event
        /// </summary>
        void Snooze();
        /// <summary>
        /// Event to fire when clock starts
        /// </summary>
        event TimeHandler ClockStarted;
        /// <summary>
        /// Event to fire when clock stops
        /// </summary>
        event TimeHandler ClockStopped;
        /// <summary>
        /// Event to fire when alarm time is reached
        /// </summary>
        event TimeHandler Alarm;
        /// <summary>
        /// Event to fire when AlarmTime property is set
        /// </summary>
        event TimeHandler AlarmSet;
        /// <summary>
        /// Event to fire when hour changes
        /// </summary>
        event TimeHandler HourChanged;
        /// <summary>
        /// Event to fire when minute changes
        /// </summary>
        event TimeHandler MinuteChanged;
        /// <summary>
        /// Event to fire when second changes
        /// </summary>
        event TimeHandler SecondChanged;
        /// <summary>
        /// Event to fire when snooze is activated
        /// </summary>
        event TimeHandler SnoozeActivated;
        /// <summary>
        /// Event to fire when clock is already running and start is called
        /// </summary>
        event TimeHandler FalseStop;
        /// <summary>
        /// Event to fire when clock is already stopped and stop is called
        /// </summary>
        event TimeHandler FalseStart;
    }
}
