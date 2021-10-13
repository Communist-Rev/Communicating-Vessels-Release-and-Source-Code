using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Communicating_Vessels
{
    partial class Main_Window
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Main_Window));
            this.exit_button = new Button();
            this.instructions = new Button();
            this.start = new Button();
            this.add_liquid = new Button();
            this.reset = new Button();
            this.animation_box = new PictureBox();
            this.vessels = new PictureBox();
            this.bridge = new PictureBox();
            this.left_cell = new PictureBox();
            this.right_cell = new PictureBox();
            this.bridge_cell = new PictureBox();
            // 
            // animation_box
            // 
            ((ISupportInitialize)(this.animation_box)).BeginInit();
            this.animation_box.Image = Properties.Resources.Background;
            this.animation_box.Location = new Point(12, 12);
            this.animation_box.Name = "animation_box";
            this.animation_box.Size = new Size(1001, 581);
            this.Controls.Add(this.animation_box);
            this.animation_box.Controls.Add(this.vessels);
            this.animation_box.Controls.Add(this.left_cell);
            this.animation_box.Controls.Add(this.right_cell);
            this.animation_box.Controls.Add(this.bridge_cell);
            this.animation_box.Controls.Add(this.bridge);
            //
            //vessels
            //
            Get_Graphics_Path(this.vessels, Properties.Resources.Vessels);
            this.vessels.Location = new Point(299, 60);
            this.vessels.Name = "vessels";
            this.vessels.Size = new Size(1001, 581);
            //
            // bridge
            //
            this.bridge.Image = Properties.Resources.Bridge;
            this.bridge.Location = new Point(399, 491);
            this.bridge.Name = "bridge";
            this.bridge.Size = new Size(202, 9);
            //
            // left_cell
            //
            Get_Graphics_Path(this.left_cell, Properties.Resources.Cell);
            this.left_cell.Location = new Point(301, 60);
            this.left_cell.Name = "left_cell";
            this.left_cell.Size = new Size(98, 439);
            //
            // right_cell
            //
            Get_Graphics_Path(this.right_cell, Properties.Resources.Cell);
            this.right_cell.Location = new Point(601, 60);
            this.right_cell.Name = "right_cell";
            this.right_cell.Size = new Size(98, 439);
            //
            // bridge_cell
            //
            Get_Graphics_Path(this.bridge_cell, Properties.Resources.Bridge);
            this.bridge_cell.Location = new Point(399, 491);
            this.bridge_cell.Name = "bridge_cell";
            this.bridge_cell.Size = new Size(202, 9);
            this.SuspendLayout();
            // 
            // exit_button
            // 
            this.exit_button.Location = new Point(852, 649);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new Size(160, 40);
            this.exit_button.TabIndex = 4;
            this.exit_button.Text = "Выход";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += (s, e) => Close();
            // 
            // instructions
            // 
            this.instructions.Location = new Point(12, 649);
            this.instructions.Name = "instructions";
            this.instructions.Size = new Size(160, 40);
            this.instructions.TabIndex = 3;
            this.instructions.Text = "?";
            this.instructions.UseVisualStyleBackColor = true;
            this.instructions.Click += (s, e) => new Info().ShowDialog();
            // 
            // start
            // 
            this.start.Enabled = false;
            this.start.Location = new Point(344, 603);
            this.start.Name = "start";
            this.start.Size = new Size(668, 40);
            this.start.TabIndex = 2;
            this.start.Text = "СТАРТ";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new EventHandler(this.Start_Click);
            // 
            // add_liquid
            // 
            this.add_liquid.Location = new Point(12, 603);
            this.add_liquid.Name = "add_liquid";
            this.add_liquid.Size = new Size(160, 40);
            this.add_liquid.TabIndex = 0;
            this.add_liquid.Text = "Добавить жидкость";
            this.add_liquid.UseVisualStyleBackColor = true;
            this.add_liquid.Click += (s, e) => new Add_Liquid().ShowDialog();;
            // 
            // reset
            // 
            this.reset.Location = new Point(178, 603);
            this.reset.Name = "reset";
            this.reset.Size = new Size(160, 40);
            this.reset.TabIndex = 1;
            this.reset.Text = "Сброс";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new EventHandler(Liquid.Reset);
            this.reset.Click += new EventHandler(Physics.Reset);
            this.reset.Click += new EventHandler(this.Reset_Click);
            this.reset.Click += new EventHandler(Add_Liquid.Reset);
            // 
            // Main_Window
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1024, 701);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.add_liquid);
            this.Controls.Add(this.start);
            this.Controls.Add(this.instructions);
            this.Controls.Add(this.exit_button);
            this.Icon = Properties.Resources.Icon;
            this.Name = "Main_Window";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Сообщающиеся сосуды";
            ((ISupportInitialize)(this.animation_box)).EndInit();
            this.ResumeLayout(true);
            this.left_cell.BringToFront();
            this.right_cell.BringToFront();
            this.vessels.BringToFront();
            this.bridge.BringToFront();
            this.bridge_cell.BringToFront();
        }
        private void Get_Graphics_Path(PictureBox box, Image file)
        {
            Bitmap bitmap = new Bitmap(file);
            GraphicsPath gp = new GraphicsPath();
            Color mask = bitmap.GetPixel(5, 5);
            for (int x = 0; x < bitmap.Width; x++)
                for (int y = 0; y < bitmap.Height; y++)
                    if (!bitmap.GetPixel(x, y).Equals(mask))
                    gp.AddRectangle(new Rectangle(x, y, 1, 1));
            bitmap.Dispose();
            box.Region = new Region(gp);
            box.Image = file;
        }

        private Button exit_button;
        private Button instructions;
        private Button start;
        private Button add_liquid;
        private Button reset;
        internal PictureBox animation_box;
        internal PictureBox vessels;
        internal PictureBox bridge;
        internal PictureBox left_cell;
        internal PictureBox right_cell;
        internal PictureBox bridge_cell;
    }
}