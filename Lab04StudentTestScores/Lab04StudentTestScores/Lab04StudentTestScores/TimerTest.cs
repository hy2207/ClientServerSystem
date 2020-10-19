using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace StudentTestScores
{
    partial class StudentTestScoresProgram
    {
        static int ticks = 0;  // keep the number of seconds ticked by the timer

        /// <summary>
        /// Set the timer to go off every second.
        /// <para>Every time the timer event fires, display the clock tick, and then increment the ticks</para>
        /// <para>AutoReset must be enabled for the timer event to keep firing.</para>
        /// <para>The timer must be started at the end of the method.</para>
        /// <para>To cancel the timer, the caller must use the Timer Stop() method.</para>
        /// Use a lambda to set the Elapsed event handler, can be done in one line of code
        /// </summary>
        /// <returns>
        /// A Timer started with Elapsed event firing every second and event handler
        /// reporting the clock ticks
        /// </returns>
        static Timer TimerTest()
        {
            // create a timer with 1 second interval
            Timer timer = new Timer(1000);
            timer.AutoReset = true; //set auto reset to true
            //set elapse event handler
            timer.Elapsed += async (sender, e) =>
            {
                ticks++;
                Console.WriteLine("Clock tick {0}", ticks);
            };
                
            timer.Start(); //start the timer
            Console.WriteLine("Clock started at {0}", DateTime.Now);

            return timer; // return timer
        }
    }
}
