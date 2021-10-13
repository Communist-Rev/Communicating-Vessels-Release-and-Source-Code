using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Communicating_Vessels
{
    partial class Add_Template
    {
        private System.ComponentModel.IContainer components = null;

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
            this.Value_input = new TextBox();
            this.value = new Label();
            this.Density_input = new TextBox();
            this.density = new Label();
            this.Name_input = new TextBox();
            this.Liquid_Name = new GroupBox();
            this.Parameters = new GroupBox();
            this.Color_Pick = new GroupBox();
            this.Color_pick_button = new Button();
            this.color = new PictureBox();
            this.Color_Dialog = new ColorDialog();
            this.Save = new Button();
            this.Parameters.SuspendLayout();
            this.Color_Pick.SuspendLayout();
            ((ISupportInitialize)(this.color)).BeginInit();
            this.SuspendLayout();
            // 
            // close
            // 
            this.close.Location = new Point(249, 231);
            this.close.Name = "close";
            this.close.Size = new Size(111, 24);
            this.close.TabIndex = 0;
            this.close.TabStop = true;
            this.close.Text = "Закрыть";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += (s, e) => Close();
            // 
            // Value_input
            // 
            this.Value_input.Location = new Point(75, 18);
            this.Value_input.Name = "Value_input";
            this.Value_input.Size = new Size(61, 23);
            this.Value_input.TabIndex = 0;
            this.Value_input.TabStop = true;
            this.Value_input.KeyPress += new KeyPressEventHandler(this.Value_input_KeyPress);
            // 
            // value
            // 
            this.value.AutoSize = true;
            this.value.Font = new Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.value.Location = new Point(6, 21);
            this.value.Name = "value";
            this.value.Size = new Size(63, 15);
            this.value.Text = "Объём (л)";
            this.value.TabStop = false;
            // 
            // Density_input
            //
            this.Density_input.Location = new Point(287, 18);
            this.Density_input.Name = "Density_input";
            this.Density_input.Size = new Size(62, 23);
            this.Density_input.TabIndex = 1;
            this.Density_input.TabStop = true;
            this.Density_input.KeyPress += new KeyPressEventHandler(this.Density_input_KeyPress);
            // 
            // density
            // 
            this.density.AutoSize = true;
            this.density.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            this.density.Location = new Point(175, 21);
            this.density.Name = "density";
            this.density.Size = new Size(106, 15);
            this.density.Text = "Плотность (кг/м³)";
            this.density.TabStop = false;
            // 
            // Parameters
            // 
            this.Parameters.Controls.Add(this.density);
            this.Parameters.Controls.Add(this.value);
            this.Parameters.Controls.Add(this.Value_input);
            this.Parameters.Controls.Add(this.Density_input);
            this.Parameters.Location = new Point(12, 12);
            this.Parameters.Name = "Parameters";
            this.Parameters.Size = new Size(360, 53);
            this.Parameters.Text = "Параметры жидкости";
            this.Parameters.TabIndex = 1;
            this.Parameters.TabStop = false;
            // 
            // Color_Pick
            // 
            this.Color_Pick.Controls.Add(this.Color_pick_button);
            this.Color_Pick.Controls.Add(this.color);
            this.Color_Pick.Location = new Point(12, 71);
            this.Color_Pick.Name = "Color_pick";
            this.Color_Pick.Size = new Size(360, 77);
            this.Color_Pick.Text = "Цвет жидкости";
            this.Color_Pick.TabIndex = 2;
            this.Color_Pick.TabStop = false;
            // 
            // Color_pick_button
            // 
            this.Color_pick_button.Location = new Point(6, 17);
            this.Color_pick_button.Name = "Color_pick_button";
            this.Color_pick_button.Size = new Size(289, 48);
            this.Color_pick_button.TabIndex = 0;
            this.Color_pick_button.TabStop = true;
            this.Color_pick_button.Text = "Выбрать";
            this.Color_pick_button.UseVisualStyleBackColor = true;
            this.Color_pick_button.Click += new EventHandler(this.Color_pick_button_Click);
            // 
            // color
            // 
            this.color.BackColor = Color.Transparent;
            this.color.BorderStyle = BorderStyle.FixedSingle;
            this.color.Location = new Point(301, 17);
            this.color.Name = "color";
            this.color.Size = new Size(49, 49);
            this.color.TabStop = false;
            // 
            // Color_Dialog
            // 
            this.Color_Dialog.AnyColor = true;
            this.Color_Dialog.Color = Color.Transparent;
            // 
            // Liquid_Name
            // 
            this.Liquid_Name.Controls.Add(this.Name_input);
            this.Liquid_Name.Location = new Point(12, 152);
            this.Liquid_Name.Name = "Liquid_Name";
            this.Liquid_Name.Size = new Size(359, 73);
            this.Liquid_Name.TabIndex = 3;
            this.Liquid_Name.TabStop = false;
            this.Liquid_Name.Text = "Название";
            // 
            // Name_input
            // 
            this.Name_input.Location = new Point(6, 31);
            this.Name_input.Name = "Name_input";
            this.Name_input.Size = new Size(342, 23);
            this.Name_input.TabIndex = 0;
            this.Name_input.TabStop = true;
            this.Name_input.KeyPress += new KeyPressEventHandler(this.Name_input_KeyPress);
            // 
            // Save
            // 
            this.Save.Location = new Point(18, 231);
            this.Save.Name = "Save";
            this.Save.Size = new Size(112, 24);
            this.Save.TabIndex = 4;
            this.Save.TabStop = true;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new EventHandler(this.Save_Click);
            // 
            // Add_Template
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode =AutoScaleMode.Font;
            this.ClientSize = new Size(384, 261);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Color_Pick);
            this.Controls.Add(this.Liquid_Name);
            this.Controls.Add(this.Parameters);
            this.Controls.Add(this.close);
            this.Icon = Properties.Resources.Icon;
            this.Name = "Add_Template";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Создание нового шаблона";
            this.Parameters.ResumeLayout(false);
            this.Parameters.PerformLayout();
            this.Color_Pick.ResumeLayout(false);
            ((ISupportInitialize)(this.color)).EndInit();
            this.ResumeLayout(false);

        }

        private Button close;
        private TextBox Value_input;
        private Label value;
        private TextBox Density_input;
        private Label density;
        private TextBox Name_input;
        private GroupBox Liquid_Name;
        private GroupBox Parameters;
        private GroupBox Color_Pick;
        private Button Color_pick_button;
        private PictureBox color;
        private ColorDialog Color_Dialog;
        private Button Save;
    }
}