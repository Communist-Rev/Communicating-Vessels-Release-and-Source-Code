using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Communicating_Vessels
{
    internal class Default_Liquid {
        internal static Dictionary <string, Default_Liquid> default_liquids = new Dictionary<string, Default_Liquid>();

        internal static void Remove(string delete_name)
        {
            default_liquids.Remove(delete_name);
            FileStream read = new FileStream("Default_Liquids.txt", FileMode.Open);
            StreamReader reader = new StreamReader(read);
            string line;
            List<string> lines = new List<string>();
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Remove(line.IndexOf(',')) != delete_name)
                {
                    lines.Add(line);
                }
            }
            reader.Close();
            read.Close();
            FileStream write = new FileStream("Default_Liquids.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(write);
            lines.ForEach((string line) =>
            {
                if (lines.IndexOf(line) != lines.Count - 1)
                    writer.WriteLine(line);
                else
                writer.Write(line);
            });
            writer.Close();
            write.Close();
            Main_Code.add_Liquid.Default_Liquid_List.Items.Remove(delete_name);
            Main_Code.add_Liquid.Default_Liquid_List.Refresh();
        }

        internal Default_Liquid(string set_name, string set_value, string set_density, Color set_color)
        {
            Name = set_name;
            Value = set_value;
            Density = set_density;
            Color = set_color;
            default_liquids.Add(this.Name, this);
        }
        
        internal string Name { get; set; }
        internal string Value { get; set; }
        internal string Density { get; set; }
        internal Color Color { get; set; }
    }
}