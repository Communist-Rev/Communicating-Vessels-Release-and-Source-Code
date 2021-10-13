using System;
using Timer = System.Timers.Timer;

namespace Communicating_Vessels
{
    internal static class Animation
    {
        private static Timer timer;
        private static bool pause;
        internal static int tick = 0;

        internal static void Start()
        {
            Physics.Start();
            bool move_stop = false;
            bool change_stop = false;
            timer = new Timer()
            {
                Interval = 40,
                AutoReset = true,
                Enabled = true
            };
            timer.Start();
            timer.Elapsed += (s, e) =>
            {
                if (!pause)
                {
                    timer.Enabled = false;
                    if (tick % 10 == 0)
                        change_stop = Physics.Change();
                    if (tick % 10 == 0)
                        Physics.Unite();
                    if(tick % 10 == 0)
                        Physics.Garbage_Collect();
                    else
                    {
                        Physics.Bridge();
                        move_stop = Physics.Move();
                        Physics.Create();
                    }
                    timer.Enabled = true;
                    if (move_stop && change_stop)
                    {
                        timer.Enabled = false;
                        Stop();
                    }
                    tick++;
                }
            };
        }
        internal static void Resume()
        {
            pause = false;
            timer.Enabled = true;
        }
        internal static void Stop()
        {           
            Main_Code.main_window.Invoke(new Action(() => {
                Main_Code.main_window.Stop();
            }));
            timer.Dispose();
            tick = 0;
        }
        
        internal static void Pause()
        {
            pause = true;
        }
    }
}