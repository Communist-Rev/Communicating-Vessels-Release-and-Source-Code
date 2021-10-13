using System;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Communicating_Vessels
{
    internal partial class Opening : Form
    {
        internal Opening()
        {
            InitializeComponent();
            Dispose_Opening();
        }
        private void Dispose_Opening()
        {
            Timer timer = new Timer() 
            { 
                Interval = 3000,
                AutoReset = false,
                Enabled = true,
            };
            timer.Start();
            timer.Elapsed += (s, e) =>
            {
                timer.Interval = 20;
                timer.Enabled = true;
                timer.AutoReset = true;
                timer.Elapsed += (s, e) =>
                {
                    if (Opacity > 0)
                        Invoke(new Action(() =>
                        {
                            Opacity -= 0.005;
                        }));
                    else
                    {
                        timer.Enabled = false;
                        Close();
                    }
                };
            };
        }
    }
}