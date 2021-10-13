using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace Communicating_Vessels
{
    partial class Add_Liquid
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
            this.Parameters = new GroupBox();
            this.Liquid_to_vessel = new GroupBox();
            this.Liquid_to_right = new RadioButton();
            this.Liquid_to_left = new RadioButton();
            this.Color_Pick = new GroupBox();
            this.Color_pick_button = new Button();
            this.color = new PictureBox();
            this.Color_Dialog = new ColorDialog();
            this.Default_Liquid_List = new ComboBox();
            this.Default_Liquids = new GroupBox();
            this.Default_Liquid_Apply = new Button();
            this.Save = new Button();
            this.Parameters.SuspendLayout();
            this.Liquid_to_vessel.SuspendLayout();
            this.Color_Pick.SuspendLayout();
            ((ISupportInitialize)(this.color)).BeginInit();
            this.Default_Liquids.SuspendLayout();
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
            // Liquid_to_vessel
            // 
            this.Liquid_to_vessel.Controls.Add(this.Liquid_to_right);
            this.Liquid_to_vessel.Controls.Add(this.Liquid_to_left);
            this.Liquid_to_vessel.Location = new Point(12, 71);
            this.Liquid_to_vessel.Name = "Liquid_to_vessel";
            this.Liquid_to_vessel.Size = new Size(130, 78);
            this.Liquid_to_vessel.Text = "Залить жидкость в";
            this.Liquid_to_vessel.TabIndex = 2;
            this.Liquid_to_vessel.TabStop = false;
            // 
            // Liquid_to_right
            // 
            this.Liquid_to_right.AutoSize = true;
            this.Liquid_to_right.Location = new Point(6, 47);
            this.Liquid_to_right.Name = "Liquid_to_right";
            this.Liquid_to_right.Size = new Size(101, 19);
            this.Liquid_to_right.TabIndex = 1;
            this.Liquid_to_right.TabStop = true;
            this.Liquid_to_right.Text = "Правый сосуд";
            this.Liquid_to_right.UseVisualStyleBackColor = true;
            // 
            // Liquid_to_left
            // 
            this.Liquid_to_left.AutoSize = true;
            this.Liquid_to_left.Location = new Point(6, 22);
            this.Liquid_to_left.Name = "Liquid_to_left";
            this.Liquid_to_left.Size = new Size(94, 19);
            this.Liquid_to_left.TabIndex = 0;
            this.Liquid_to_left.TabStop = true;
            this.Liquid_to_left.Text = "Левый сосуд";
            this.Liquid_to_left.UseVisualStyleBackColor = true;
            // 
            // Color_Pick
            // 
            this.Color_Pick.Controls.Add(this.Color_pick_button);
            this.Color_Pick.Controls.Add(this.color);
            this.Color_Pick.Location = new Point(148, 71);
            this.Color_Pick.Name = "Color_pick";
            this.Color_Pick.Size = new Size(223, 77);
            this.Color_Pick.Text = "Цвет жидкости";
            this.Color_Pick.TabIndex = 3;
            this.Color_Pick.TabStop = false;
            // 
            // Color_pick_button
            // 
            this.Color_pick_button.Location = new Point(6, 17);
            this.Color_pick_button.Name = "Color_pick_button";
            this.Color_pick_button.Size = new Size(152, 48);
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
            this.color.Location = new Point(164, 17);
            this.color.Name = "color";
            this.color.Size = new Size(49, 49);
            this.color.TabStop = false;
            // 
            // Color_Dialog
            // 
            this.Color_Dialog.AnyColor = true;
            this.Color_Dialog.Color = Color.Transparent;
            // 
            // Default_Liquid_List
            //
            StreamReader reader = new StreamReader("Default_Liquids.txt");
            string name, value, density, line;
            int r, g, b;
            while ((line = reader.ReadLine()) != null)
            {
                name = line.Remove(line.IndexOf(','));
                if (Default_Liquid.default_liquids.ContainsKey(name))
                    continue;
                line = line.Remove(0, line.IndexOf(',') + 1);
                value = line.Remove(line.IndexOf(','));
                line = line.Remove(0, line.IndexOf(',') + 1);
                density = line.Remove(line.IndexOf(','));
                line = line.Remove(0, line.IndexOf(',') + 1);
                r = Convert.ToInt32(line.Remove(line.IndexOf(',')));
                line = line.Remove(0, line.IndexOf(',') + 1);
                g = Convert.ToInt32(line.Remove(line.IndexOf(',')));
                line = line.Remove(0, line.IndexOf(',') + 1);
                b = Convert.ToInt32(line.Remove(line.IndexOf(',')));
                line = line.Remove(0, line.IndexOf(',') + 1);
                new Default_Liquid(name, value, density, Color.FromArgb(128, r, g, b));
            }
            reader.Close();
            this.Default_Liquid_List.Items.AddRange(new object[] {
                "Создать новый шаблон",
                "Удалить существующий шаблон"
            });
            this.Default_Liquid_List.FormattingEnabled = false;
            foreach (KeyValuePair <string, Default_Liquid> liquid in Default_Liquid.default_liquids)
            {
                if (!this.Default_Liquid_List.Items.Contains(liquid.Key))
                    this.Default_Liquid_List.Items.Add(liquid.Key);
            }
            this.Default_Liquid_List.Location = new Point(6, 31);
            this.Default_Liquid_List.Name = "Default_Liquid_List";
            this.Default_Liquid_List.Size = new Size(160, 23);
            this.Default_Liquid_List.TabIndex = 0;
            this.Default_Liquid_List.TabStop = true;
            this.Default_Liquid_List.KeyPress += (sender, e) => e.Handled = true;
            // 
            // Default_Liquids
            // 
            this.Default_Liquids.Controls.Add(this.Default_Liquid_Apply);
            this.Default_Liquids.Controls.Add(this.Default_Liquid_List);
            this.Default_Liquids.Location = new Point(12, 152);
            this.Default_Liquids.Name = "Default_Liquid";
            this.Default_Liquids.Size = new Size(359, 73);
            this.Default_Liquids.Text = "Существущие жидкости";
            this.Default_Liquids.TabIndex = 4;
            this.Default_Liquids.TabStop = false;
            // 
            // Default_Liquid_Apply
            // 
            this.Default_Liquid_Apply.Location = new Point(183, 31);
            this.Default_Liquid_Apply.Name = "Default_Liquid_Apply";
            this.Default_Liquid_Apply.Size = new Size(165, 23);
            this.Default_Liquid_Apply.TabIndex = 1;
            this.Default_Liquid_Apply.TabStop = true;
            this.Default_Liquid_Apply.Text = "Применить";
            this.Default_Liquid_Apply.UseVisualStyleBackColor = true;
            this.Default_Liquid_Apply.Click += new EventHandler(this.Default_Liquid_Apply_Click);
            // 
            // Save
            // 
            this.Save.Location = new Point(18, 231);
            this.Save.Name = "Save";
            this.Save.Size = new Size(112, 24);
            this.Save.TabIndex = 5;
            this.Save.TabStop = true;
            this.Save.Text = "Добавить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new EventHandler(this.Save_Click);
            // 
            // Add_Liquid
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode =AutoScaleMode.Font;
            this.ClientSize = new Size(384, 261);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Default_Liquids);
            this.Controls.Add(this.Color_Pick);
            this.Controls.Add(this.Liquid_to_vessel);
            this.Controls.Add(this.Parameters);
            this.Controls.Add(this.close);
            this.Icon = Properties.Resources.Icon;
            this.Name = "Add_Liquid";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Добавление жидкости";
            this.Parameters.ResumeLayout(false);
            this.Parameters.PerformLayout();
            this.Liquid_to_vessel.ResumeLayout(false);
            this.Liquid_to_vessel.PerformLayout();
            this.Color_Pick.ResumeLayout(false);
            ((ISupportInitialize)(this.color)).EndInit();
            this.Default_Liquids.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Button close;
        private TextBox Value_input;
        private Label value;
        private TextBox Density_input;
        private Label density;
        private GroupBox Parameters;
        private GroupBox Liquid_to_vessel;
        private RadioButton Liquid_to_right;
        private RadioButton Liquid_to_left;
        private GroupBox Color_Pick;
        private Button Color_pick_button;
        private PictureBox color;
        private ColorDialog Color_Dialog;
        internal ComboBox Default_Liquid_List;
        private GroupBox Default_Liquids;
        private Button Default_Liquid_Apply;
        private Button Save;
    }
}