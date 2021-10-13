using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Communicating_Vessels
{
    internal static class Physics
    {
        private static Graphics graphics = Graphics.FromImage(Main_Code.main_window.animation_box.Image);
        internal static bool create = true;

        private static double Pressure(int density, int height) => density * height;
        private static void Direction(ref bool left_to_right, ref bool right_to_left)
        {
            if (Left_Pressure() > Right_Pressure())
            {
                left_to_right = true;
                right_to_left = false;
            }
            else if (Right_Pressure() > Left_Pressure())
            {
                right_to_left = true;
                left_to_right = false;
            }
        }
        private static void Move_Up(Liquid liquid) => liquid.Picture.Location = new Point(liquid.Left_coord, --liquid.Top_coord);
        private static void Move_Down(Liquid liquid) => liquid.Picture.Location = new Point(liquid.Left_coord, ++liquid.Top_coord);
        private static void Change_Pair(int i, byte vessel)
        {
            List<Liquid>liquids = Liquid.Liquids[vessel];
            Liquid bottom = liquids[i - 1];
            Liquid top = liquids[i];
            Main_Code.main_window.animation_box.Invoke((MethodInvoker) (() =>
            {
                top.Picture.Size = new Size(98, top.Height -= 10);
                top.Bottom_coord -= 10;
                bottom.Picture.Size = new Size(98, bottom.Height -= 10);
                bottom.Picture.Location = new Point(bottom.Left_coord, bottom.Top_coord += 10);
                if (vessel == 0)
                    Liquid.left_top = bottom.Top_coord;
                else if (vessel == 1)
                    Liquid.right_top = bottom.Top_coord;
                liquids.Insert(i, new Liquid(0.1, top.Density, bottom.Color, vessel));
                liquids.Insert(i + 1, new Liquid(0.1, bottom.Density, top.Color, vessel));
            }));
            Animate_Change(liquids[i], liquids[i + 1]);
        }
        private static void Animate_Change(Liquid bottom, Liquid top)
        {
            Main_Code.main_window.animation_box.BeginInvoke((MethodInvoker) (async() => 
            {
                Color bc = new Color();
                Color tc = new Color();
                tc = top.Color;
                bc = bottom.Color;
                for (int i = 0; i <= 8; i++, await Task.Delay(10))
                {
                    int br = i * tc.R / 8 + (8 - i) * bc.R / 8;
                    int bg = i * tc.G / 8 + (8 - i) * bc.G / 8;
                    int bb = i * tc.B / 8 + (8 - i) * bc.B / 8;
                    bottom.Picture.BackColor = Color.FromArgb(128, br, bg, bb);
                    bottom.Picture.Refresh();
                    int tr = i * bc.R / 8 + (8 - i) * tc.R / 8;
                    int tg = i * bc.G / 8 + (8 - i) * tc.G / 8;
                    int tb = i * bc.B / 8 + (8 - i) * tc.B / 8;
                    top.Picture.BackColor = Color.FromArgb(128, tr, tg, tb);
                    top.Picture.Refresh();
                }
                bottom.Color = tc;
                top.Color = bc;
            }));
        }
        internal static double Left_Pressure()
        {
            double left_pressure = 0;
            foreach (Liquid liquid in Liquid.Liquids[0])
                left_pressure += Pressure(liquid.Density, liquid.Height);
            return left_pressure;
        }
        internal static double Right_Pressure()
        {
            double right_pressure = 0;
            foreach (Liquid liquid in Liquid.Liquids[1])
                right_pressure += Pressure(liquid.Density, liquid.Height);
            return right_pressure;
        }
        internal static void Unite()
        {
            foreach (List<Liquid> liquids in Liquid.Liquids)
            {
                
                if (liquids.Count > 1)
                {
                    int i = 0;
                    while (i < liquids.Count - 1)
                    {
                        Liquid top = liquids[i + 1];
                        Liquid bottom = liquids[i];
                        if ((bottom.Density == top.Density) && (bottom.Color == top.Color))
                        {
                            Main_Code.main_window.animation_box.Invoke((MethodInvoker)(() =>
                            {
                                top += bottom;
                            }));
                        }
                        else
                            i++;
                    }
                }
            }
        }
        internal static bool Change()
        {
            bool correct_order = true;
            for (byte vessel = 0; vessel < 2; vessel++)
            {
                List<Liquid> liquids = Liquid.Liquids[vessel];
                if (liquids.Count > 1)
                {
                    for (int i = liquids.Count - 1; i > 0; i--)
                    {
                        Liquid top = liquids[i];
                        Liquid bottom = liquids[i -1];
                        if (top.Density > bottom.Density && bottom.Height >=10 && (liquids.IndexOf(bottom) != 0 || bottom.Height > 10 || (Left_Pressure() == Right_Pressure())))
                        {
                            correct_order = false;
                            Change_Pair(i, vessel);
                        }
                    }
                }
            }
            return correct_order;
        }
        internal static void Garbage_Collect()
        {
            foreach (List<Liquid> liquids in Liquid.Liquids)
                if (liquids.Count != 0)
                {
                    for (int i = liquids.Count - 1; i >=0; i--)
                    {
                        Liquid liquid = liquids[i];
                        if (liquid.Height == 0)
                        {
                            Main_Code.main_window.animation_box.Invoke((MethodInvoker) (() =>
                            {
                                Liquid.Liquid_Boxes.Remove(liquid.Picture);
                                liquid.Picture.Dispose();
                                liquids.Remove(liquid);
                            }));
                        }
                    }
                }
        }
        internal static void Start()
        {
            create = true;
            Direction(ref left_to_right, ref right_to_left);
        }
        internal static void Reset(object sender, EventArgs e)
        {
            create = true;
            graphics = Graphics.FromImage(Main_Code.main_window.animation_box.Image);
        }
        internal static void Create()
        {
            if (create)
            {
                Main_Code.main_window.animation_box.Invoke((MethodInvoker) (() =>
                {
                    Liquid.left_top = 500;
                    Liquid.right_top = 500;
                    Liquid liquid = Liquid.Liquids[heavy][0];
                    Liquid.Liquids[light].Insert(0, new Liquid(0.01, liquid.Density, liquid.Color, light));
                    create = false;
                }));
            }
        }
        internal static void Bridge()
        {
            Main_Code.main_window.bridge.Invoke((MethodInvoker) (() =>
            {
                if (Liquid.Liquids[0].Count > 0 && Liquid.Liquids[1].Count > 0)
                {
                    Graphics G = Graphics.FromImage(Main_Code.main_window.bridge.Image);
                    G.Clear(Color.Transparent);
                    Rectangle bridge_image = new Rectangle(0, 0, 203, 9);
                    Color left_grad = Liquid.Liquids[0][0].Color;
                    Color right_grad = Liquid.Liquids[1][0].Color;
                    LinearGradientBrush grad = new LinearGradientBrush(bridge_image, left_grad, right_grad, LinearGradientMode.Horizontal);
                    G.FillRectangle(grad, bridge_image);
                    G.Dispose();
                    Main_Code.main_window.bridge.Refresh();
                }
            }));
        }
        
        private static byte heavy;
        private static byte light;
        private static bool left_to_right;
        private static bool right_to_left;

        internal static bool Move()
        {
            if ((float) Left_Pressure() > (float) Right_Pressure() && left_to_right)
            {
                heavy = 0;
                light = 1;
            }
            else if ((float) Right_Pressure() > (float) Left_Pressure() && right_to_left)
            {
                heavy = 1;
                light = 0;
            }
            else
            {
                return true;
            }
            if (Liquid.Liquids[heavy].Count != 0)
            {
                for (int i = Liquid.Liquids[heavy].IndexOf(Liquid.Liquids[heavy][^1]); i >= 0; i--)
                {
                    Liquid liquid = Liquid.Liquids[heavy][i];
                    Main_Code.main_window.animation_box.Invoke((MethodInvoker) (() =>
                    {
                        if (i != 0)
                        {
                            Move_Down(liquid);
                            liquid.Bottom_coord++;
                        }
                        else
                        {
                            liquid.Picture.Size = new Size(98, --liquid.Height);
                            Move_Down(liquid);
                            if (liquid.Height == 0 && Liquid.Liquids[heavy].IndexOf(liquid) == 0)
                            {
                                Liquid.Liquid_Boxes.Remove(liquid.Picture);
                                liquid.Picture.Dispose();
                                Liquid.Liquids[heavy].RemoveAt(0);
                                create = true;
                            }
                        }
                    }));
                }
            }
            if (Liquid.Liquids[light].Count != 0)
            {
                for (int i = Liquid.Liquids[light].IndexOf(Liquid.Liquids[light][^1]); i >= 0; i--)
                {
                    Liquid liquid = Liquid.Liquids[light][i];
                    Main_Code.main_window.animation_box.Invoke((MethodInvoker) (() =>
                    {
                        if (i == 0 && !create)
                        {
                            liquid.Picture.Size = new Size(98, ++liquid.Height);
                            Move_Up(liquid);
                        }
                        else if (liquid.Top_coord > 60)
                        {
                            Move_Up(liquid);
                            liquid.Bottom_coord--;
                        }
                        else
                        {
                            Animation.Stop();
                            MessageBox.Show("Превышение допустимого объёма", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }));
                }
            }
            return false;
        }
    }
}