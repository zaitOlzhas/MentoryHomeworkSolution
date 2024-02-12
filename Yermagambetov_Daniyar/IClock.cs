using MainHomeworkRequirements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yermagambetov_Daniyar
{
    public class Clock : IClock
    {
        private DateTime _clockTime;
        private DateTime _alarmTime;
        private bool _isRunning;

        public DateTime ClockTime
        {
            get { return _clockTime; }
            private set
            {
                _clockTime = value;
                OnHourChanged();
                OnMinuteChanged();
                OnSecondChanged();
            }
        }

        public DateTime AlarmTime
        {
            get { return _alarmTime; }
            set
            {
                _alarmTime = value;
                OnAlarmSet();
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

        public Clock()
        {
            // Инициализация ClockTime в конструкторе
            ClockTime = DateTime.Now;
        }

        public void Start()
        {
            if (!_isRunning)
            {
                _isRunning = true;
                OnClockStarted();
                UpdateClock();
            }
            else
            {
                OnFalseStart();
            }
        }

        public void Stop()
        {
            if (_isRunning)
            {
                _isRunning = false;
                OnClockStopped();
            }
            else
            {
                OnFalseStop();
            }
        }

        public void Snooze()
        {
            OnSnoozeActivated();
        }

        private void UpdateClock()
        {
            while (_isRunning)
            {
                ClockTime = DateTime.Now;
                System.Threading.Thread.Sleep(1000); // Обновление каждую секунду
            }
        }

        protected virtual void OnClockStarted()
        {
            ClockStarted?.Invoke(this);
        }

        protected virtual void OnClockStopped()
        {
            ClockStopped?.Invoke(this);
        }

        protected virtual void OnAlarm()
        {
            Alarm?.Invoke(this);
        }

        protected virtual void OnAlarmSet()
        {
            AlarmSet?.Invoke(this);
        }

        protected virtual void OnHourChanged()
        {
            HourChanged?.Invoke(this);
        }

        protected virtual void OnMinuteChanged()
        {
            MinuteChanged?.Invoke(this);
        }

        protected virtual void OnSecondChanged()
        {
            SecondChanged?.Invoke(this);
        }

        protected virtual void OnSnoozeActivated()
        {
            SnoozeActivated?.Invoke(this);
        }

        protected virtual void OnFalseStop()
        {
            FalseStop?.Invoke(this);
        }

        protected virtual void OnFalseStart()
        {
            FalseStart?.Invoke(this);
        }
    }
}
/*
 using MainHomeworkRequirements;
using Yermagambetov_Daniyar;
using System.Runtime.InteropServices;
namespace MentoryHomeworkConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            // Подписка на события
            clock.ClockStarted += ClockStartedHandler;
            clock.ClockStopped += ClockStoppedHandler;
            clock.Alarm += AlarmHandler;
            clock.AlarmSet += AlarmSetHandler;
            clock.HourChanged += HourChangedHandler;
            clock.MinuteChanged += MinuteChangedHandler;
            clock.SecondChanged += SecondChangedHandler;
            clock.SnoozeActivated += SnoozeActivatedHandler;
            clock.FalseStop += FalseStopHandler;
            clock.FalseStart += FalseStartHandler;
            // Установка начального времени и будильника
            clock.AlarmTime = DateTime.Now.AddMinutes(1); // Будильник через 1 минуту
            // Запуск часов
            clock.Start();
            // Симуляция остановки и запуска часов
            System.Threading.Thread.Sleep(3000); // Ждем 3 секунды
            clock.Stop();
            System.Threading.Thread.Sleep(2000); // Ждем 2 секунды
            clock.Start();
            // Симуляция установки будильника
            clock.AlarmTime = DateTime.Now.AddMinutes(2);
            // Симуляция отсрочки будильника
            System.Threading.Thread.Sleep(3000); // Ждем 3 секунды
            clock.Snooze();
            // Остановка часов
            clock.Stop();
            Console.ReadLine(); // Держим консольное окно открытым
        }
        // Обработчики событий
        static void ClockStartedHandler(IClock sender)
        {
            Console.WriteLine("Часы запущены");
        }
        static void ClockStoppedHandler(IClock sender)
        {
            Console.WriteLine("Часы остановлены");
        }
        static void AlarmHandler(IClock sender)
        {
            Console.WriteLine("Будильник!");
        }
        static void AlarmSetHandler(IClock sender)
        {
            Console.WriteLine("Будильник установлен на: " + sender.AlarmTime);
        }
        static void HourChangedHandler(IClock sender)
        {
            Console.WriteLine("Изменение часа: " + sender.ClockTime.Hour);
        }
        static void MinuteChangedHandler(IClock sender)
        {
            Console.WriteLine("Изменение минуты: " + sender.ClockTime.Minute);
        }
        static void SecondChangedHandler(IClock sender)
        {
            Console.WriteLine("Изменение секунды: " + sender.ClockTime.Second);
        }
        static void SnoozeActivatedHandler(IClock sender)
        {
            Console.WriteLine("Отложено");
        }
        static void FalseStopHandler(IClock sender)
        {
            Console.WriteLine("Попытка ложной остановки");
        }
        static void FalseStartHandler(IClock sender)
        {
            Console.WriteLine("Попытка ложного запуска");
        }
    }
}
 */
}
