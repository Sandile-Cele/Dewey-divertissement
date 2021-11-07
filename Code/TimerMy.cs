using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Dewey_divertissement
{
    class TimerMy
    {

        static DispatcherTimer dispatcherTimer = new DispatcherTimer();

        private static TimeSpan userCounter = new TimeSpan(0, 0, 0, 0);

        public static bool timerRunning = false;//In replacingBooks.cs i want to know if the timer is running

        public static void start()
        {
            //If the timer is running already just start it 
            if (timerRunning)
            {
                dispatcherTimer.Start();
            }

            timerRunning = true;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        //Stop timer and return the current time
        public static TimeSpan stop()
        {
            dispatcherTimer.Stop();
            timerRunning = false;

            return userCounter;
        }

        public static void reset()
        {
            userCounter = new TimeSpan(0, 0, 0, 0);
        }



    }
}
