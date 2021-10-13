using System;
using System.Windows.Forms;

namespace Communicating_Vessels
{
    internal partial class Delete_Template: Form
    {
        internal Delete_Template()
        {
            InitializeComponent();
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            if (names.SelectedItem != null)
            {
                DialogResult apply_delete = MessageBox.Show("Удалить шаблон?", "Сообщение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (apply_delete == DialogResult.OK)
                {
                    Default_Liquid.Remove(names.SelectedItem.ToString());
                    MessageBox.Show("Шаблон удалён", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    Close();
                }
                else if (apply_delete == DialogResult.Cancel)
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Не выбран шаблон", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}