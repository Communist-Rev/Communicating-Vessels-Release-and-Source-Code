using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Communicating_Vessels
{
    partial class Info
    {

        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.close = new Button();
            this.info = new RichTextBox();
            this.SuspendLayout();
            // 
            // close
            // 
            this.close.Dock = DockStyle.Bottom;
            this.close.Location = new Point(0, 521);
            this.close.Name = "close";
            this.close.Size = new Size(784, 40);
            this.close.TabIndex = 0;
            this.close.Text = "Закрыть";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += (s, e) => Close();
            //
            // info
            //
            Process p = new Process();
            this.info.Location = new Point(12, 12);
            this.info.Name = "Value_input";
            this.info.Size = new Size(576, 388);
            this.info.Multiline = true;
            this.info.ScrollBars = RichTextBoxScrollBars.Vertical;
            this.info.KeyPress += (object sender, KeyPressEventArgs e) => e.Handled = true;
            this.info.Text = Properties.Resources.README;
            this.info.LinkClicked += (s, e) =>
            {
                p = Process.Start(new ProcessStartInfo("cmd", $"/c start {e.LinkText}") {CreateNoWindow = true});
                p.Exited += (s, e) => {
                    p.Kill();
                };
            };
            // 
            // Info
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(600, 450);
            this.Controls.Add(this.close);
            this.Controls.Add(this.info);
            this.Icon = Properties.Resources.info;
            this.Name = "Info";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Инструкции";
            this.ResumeLayout(false);
        }

        private Button close;
        private RichTextBox info;
    }
}