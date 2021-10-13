using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Communicating_Vessels
{
    internal partial class Add_Template : Form
    {
        public Add_Template()
        {
            InitializeComponent();
        }
        private void Value_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((number < 48 || number > 52) && number != 8 && number != 127 || number != 8 && number != 127 && Value_input.Text.Length >= 1)
            {
                e.Handled = true;
            }
        }
        private void Density_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8 && number != 127 || number != 8 && number != 127 && Density_input.Text.Length > 4)
            {
                e.Handled = true;
            }
            if (Density_input.Text.Length > 4)
            {
                Density_input.Text = "99999";
            }
        }
        private void Name_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }
        private void Color_pick_button_Click(object sender, EventArgs e)
        {
            if (Color_Dialog.ShowDialog() == DialogResult.OK)
                color.BackColor = Color.FromArgb(128, Color_Dialog.Color.R, Color_Dialog.Color.G, Color_Dialog.Color.B);
        }
        private void Save_Click(object sender, EventArgs e)
        {
            if (Density_input.Text != "" && Value_input.Text != "" && color.BackColor != Color.Transparent)
            {
                if (Value_input.Text != "0")
                {
                    FileStream file = new FileStream("Default_Liquids.txt", FileMode.Append);
                    StreamWriter writer = new StreamWriter(file);
                    writer.WriteLine();
                    writer.Write($"{Name_input.Text},{Value_input.Text},{Density_input.Text},{color.BackColor.R},{color.BackColor.G},{color.BackColor.B},");
                    writer.Close();
                    file.Close();
                    Main_Code.add_Liquid.Default_Liquid_List.Items.Add(new Default_Liquid(Name_input.Text, Value_input.Text, Density_input.Text, color.BackColor).Name);
                    MessageBox.Show("Шаблон добавлен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    Close();
                }
                else
                {
                    MessageBox.Show("Объём не может быть равен нулю", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("Неполные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}