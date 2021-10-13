using System;
using System.Drawing;
using System.Windows.Forms;

namespace Communicating_Vessels
{
    internal partial class Add_Liquid : Form
    {
        internal Add_Liquid()
        {
            Main_Code.add_Liquid = this;
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
        private void Color_pick_button_Click(object sender, EventArgs e)
        {
            if (Color_Dialog.ShowDialog() == DialogResult.OK)
                color.BackColor = Color.FromArgb(128, Color_Dialog.Color.R, Color_Dialog.Color.G, Color_Dialog.Color.B);
        }
        private void Default_Liquid_Apply_Click(object sender, EventArgs e)
        {
            try {
                if (Default_Liquid_List.SelectedItem.ToString() == "Создать новый шаблон")
                {
                    new Add_Template().ShowDialog();
                }
                else if (Default_Liquid_List.SelectedItem.ToString() == "Удалить существующий шаблон")
                {
                    new Delete_Template().ShowDialog();
                }
                else
                {
                    string key = Default_Liquid_List.SelectedItem.ToString();
                    Default_Liquid liquid = Default_Liquid.default_liquids[key];
                    Value_input.Text = liquid.Value;
                    Density_input.Text = liquid.Density;
                    color.BackColor = liquid.Color;
                }
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Не выбрана жидкость", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private static int value_remaining_left = 4;
        private static int value_remaining_right = 4;

        private void Save_Click(object sender, EventArgs e)
        {
            if ((Liquid_to_left.Checked || Liquid_to_right.Checked) && Density_input.Text != "" && Value_input.Text != "" && color.BackColor != Color.Transparent)
            {
                if (Value_input.Text != "0")
                {
                    if (Liquid_to_left.Checked)
                        if (Convert.ToInt32(Value_input.Text) <= value_remaining_left)
                        {
                            value_remaining_left -= Convert.ToInt32(Value_input.Text);
                            Liquid.Liquids[0].Add(new Liquid(Convert.ToDouble(Value_input.Text), Convert.ToInt32(Density_input.Text), color.BackColor, 0));
                            Main_Code.main_window.Enable_Start();
                        }
                        else
                        {
                            MessageBox.Show($"Превышение допустимого объёма. Осталось { value_remaining_left } л", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    if (Liquid_to_right.Checked)
                        if (Convert.ToInt32(Value_input.Text) <= value_remaining_right)
                        {
                            value_remaining_right -= Convert.ToInt32(Value_input.Text);
                            Liquid.Liquids[1].Add(new Liquid(Convert.ToDouble(Value_input.Text), Convert.ToInt32(Density_input.Text), color.BackColor, 1));
                            Main_Code.main_window.Enable_Start();
                        }
                        else
                        {
                            MessageBox.Show($"Превышение допустимого объёма. Осталось { value_remaining_right } л", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
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

        internal static void Reset(object sender, EventArgs e)
        {
            value_remaining_left = 4;
            value_remaining_right = 4;
        }
        
    }
}