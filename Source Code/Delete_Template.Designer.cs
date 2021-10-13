using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Communicating_Vessels
{
    partial class Delete_Template
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
            this.delete = new Button();
            this.names = new ListBox();
            this.SuspendLayout();
            // 
            // close
            // 
            this.close.Location = new Point(177, 164);
            this.close.Name = "close";
            this.close.Size = new Size(111, 24);
            this.close.TabIndex = 0;
            this.close.TabStop = true;
            this.close.Text = "Закрыть";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += (s, e) => Close();
            //
            // delete
            //
            this.delete.Location = new Point(12, 164);
            this.delete.Name = "delete";
            this.delete.Size = new Size(111, 24);
            this.delete.TabIndex = 2;
            this.delete.TabStop = true;
            this.delete.Text = "Удалить";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new EventHandler(this.Delete_Click);
            //
            // names
            //
            this.names.Location = new Point(12, 12);
            this.names.Name = "names";
            this.names.Size = new Size(276, 118);
            this.names.TabIndex = 1;
            this.names.TabStop = true;
            foreach (KeyValuePair <string, Default_Liquid> liquid in Default_Liquid.default_liquids)
            {
                if (!this.names.Items.Contains(liquid.Key))
                    this.names.Items.Add(liquid.Key);
            }
            // 
            // Info
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(300, 200);
            this.Controls.Add(this.close);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.names);
            this.Icon = Properties.Resources.Icon;
            this.Name = "Delete_Template";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Удаление шаблона";
            this.ResumeLayout(false);
        }

        private Button close;
        private Button delete;
        private ListBox names;
    }
}