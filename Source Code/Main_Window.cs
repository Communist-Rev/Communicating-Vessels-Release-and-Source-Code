using System.Diagnostics;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Communicating_Vessels
{
    internal partial class Main_Window : Form
    {
        internal Main_Window()
        {
            Main_Code.main_window = this;
            InitializeComponent();
            #if RELEASE
            new Opening.ShowDialog();
            #endif
        }
        private void Start_Click(object sender, EventArgs e)
        {
            start.Text = "СТОП";
            add_liquid.Enabled = false;
            instructions.Enabled = false;
            reset.Enabled = false;
            start.Click -= Start_Click;
            start.Click += Stop_Click;
            Animation.Start();
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            start.Text = "ВОЗОБНОВИТЬ";
            add_liquid.Enabled = true;
            instructions.Enabled = true;
            reset.Enabled = true;
            start.Click -= Stop_Click;
            start.Click += Resume_Click;
            Animation.Pause();
        }
        private void Resume_Click(object sender, EventArgs e)
        {
            start.Text = "СТОП";
            reset.Enabled = false;
            add_liquid.Enabled = false;
            instructions.Enabled = false;
            reset.Enabled = false;
            start.Click -= Resume_Click;
            start.Click += Stop_Click;
            Animation.Resume();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            start.Text = "СТАРТ";
            start.Enabled = false;
            add_liquid.Enabled = true;
            instructions.Enabled = true;
            for (int i = (Liquid.Liquid_Boxes.Count - 1); i >= 0; i--)
            {
                Liquid.Liquid_Boxes[i].Dispose();
                Liquid.Liquid_Boxes.RemoveAt(i);
            }
            Liquid.Liquids[0].Clear();
            Liquid.Liquids[1].Clear();
            bridge.Image = Properties.Resources.Bridge;
            if (start.Text == "СТОП")
            {
                start.Click -= Stop_Click;
            }
            else if (start.Text == "ВОЗОБНОВИТЬ")
            {
                start.Click -= Resume_Click;
                start.Click += Start_Click;
            }
        }
        internal void Stop()
        {
            start.Click += Start_Click;
            start.Click -= Resume_Click;
            start.Click -= Stop_Click;
            start.Enabled = false;
            reset.Enabled = true;
        }
        internal void Enable_Start()
        {
            start.Enabled = true;
        }
    }
}