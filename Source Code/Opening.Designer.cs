using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Communicating_Vessels
{
    partial class Opening
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
            this.Opening_Picture = new PictureBox();
            this.SuspendLayout();
            //
            // Opening_Picture
            //
            this.Opening_Picture.Image = Properties.Resources.Opening;
            this.Opening_Picture.Location = new Point(0, 0);
            this.Opening_Picture.Name = "Opening_Picture";
            this.Opening_Picture.Size = new Size(400, 400);
            // 
            // Opening
            // 
            this.FormBorderStyle = FormBorderStyle.None;
            this.Controls.Add(Opening_Picture);
            this.TopMost = true;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Icon = Properties.Resources.Icon;
            this.ClientSize = new Size(400, 400);
            this.Name = "Opening";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }
        PictureBox Opening_Picture;
    }
}