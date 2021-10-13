using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Communicating_Vessels
{
    internal class Liquid
    {
        internal static List<Liquid>[] Liquids = 
        {
            new List<Liquid>(), 
            new List<Liquid>()
        };
        internal static List<PictureBox> Liquid_Boxes = new List<PictureBox>();
        internal static int left_top = 500;
        internal static int right_top = 500;
        private static readonly int lo = 301;
        private static readonly int ri = 601;
        private static readonly int width = 98;
        public static Liquid operator +(Liquid top, Liquid bottom)
        {
            top.Height += bottom.Height;
            top.Picture.Size = new Size(98, top.Height);
            Liquid.Liquid_Boxes.Remove(bottom.Picture);
            bottom.Picture.Dispose();
            foreach (List<Liquid> liquids in Liquids)
            {
                if (liquids.Contains(bottom))
                    liquids.Remove(bottom);
            }
            return top;
        }

        internal Liquid(double value, int density, Color color, byte vessel)
        {
            Height = (int) (100 * value);
            Color = color;
            Density = density;
            if (vessel == 0)
            {
                left_top -= Height;
                Top_coord = left_top;
                Left_coord = lo;
                Draw_Liquid(color, this, width, Height, lo, left_top);
            }
            else if (vessel == 1)
            {
                right_top -= Height;
                Top_coord = right_top;
                Left_coord = ri;
                Draw_Liquid(color, this, width, Height, ri, right_top);
                
            }
            Bottom_coord = Top_coord + Height;
        }

        internal static void Reset(object sender, EventArgs e)
        {
            left_top = 500;
            right_top = 500;
        }
        internal void Draw_Liquid(Color color, Liquid liquid, int width, int height, int left, int top)
        {
            Liquid_Boxes.Add(new PictureBox());
            Picture = Liquid_Boxes[^1];
            Picture.BackColor = color;
            Picture.Name = $"Liquid { Liquid_Boxes.IndexOf(Liquid_Boxes[^1]) }";
            Picture.Size = new Size(width, height);
            Picture.Location = new Point(left, top);
            Main_Code.main_window.animation_box.Invoke((MethodInvoker)(()=>
            {
                Main_Code.main_window.animation_box.Controls.Add(Liquid_Boxes[^1]);
                Liquid_Boxes[^1].BringToFront();
                Main_Code.main_window.left_cell.BringToFront();
                Main_Code.main_window.right_cell.BringToFront();
                Main_Code.main_window.vessels.BringToFront();
            }));
        }

        internal int Bottom_coord { get; set; }
        internal int Top_coord { get; set; }
        internal int Left_coord { get; set; }
        internal int Height { get; set; }
        internal int Density { get; set; }
        internal Color Color { get; set; }
        internal PictureBox Picture { get; set; }
    }
}