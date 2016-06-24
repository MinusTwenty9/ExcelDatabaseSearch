using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Drawing;

namespace PortaCellTec_Database
{
    public class Settings
    {
        public Form_Main form;
        public string settings_path = Environment.CurrentDirectory + "\\settings.conf";
        public string xls_info_path = Environment.CurrentDirectory + "\\xls_info.conf";

        public Settings(Form_Main form)
        {
            this.form = form;
        }

        public void Load_Settings()
        {
            if (!File.Exists(settings_path))
                return;

            using (StreamReader stream = new StreamReader(settings_path))
            { 
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] line_split = line.Split('=');

                    if (line_split.Length < 2) continue;

                    // ROUND
                    if (line_split[0].ToLower() == "round")
                    {
                        decimal val = 2;
                        decimal.TryParse(line_split[1], out val);
                        form.numeric_round_vals.Value = val;
                    }
                    // HIDE_EMPTY_VALUES
                    else if (line_split[0].ToLower() == "hide_empty_values")
                    {
                        bool val = false;
                        bool.TryParse(line_split[1], out val);
                        form.check_box_hide_empty_vals.Checked = val;
                    }
                    // REVERSE_SORT
                    else if (line_split[0].ToLower() == "reverse_sort")
                    {
                        bool val = false;
                        bool.TryParse(line_split[1], out val);
                        form.check_box_reverse_sort.Checked = val;
                    }
                    // MIN_VAL
                    else if (line_split[0].ToLower() == "min_val")
                    {
                        decimal val = 2;
                        decimal.TryParse(line_split[1], out val);
                        form.numeric_min_val.Value = val;
                    }
                    // MAX_VAL
                    else if (line_split[0].ToLower() == "max_val")
                    {
                        decimal val = 2;
                        decimal.TryParse(line_split[1], out val);
                        form.numeric_max_val.Value = val;
                    }
                    // FONT
                    else if (line_split[0].ToLower() == "font")
                    {
                        try
                        {
                            string font_string = line.Substring(5);
                            form.list_view_display.Font = (Font)TypeDescriptor.GetConverter(typeof(Font)).ConvertFromString(font_string);
                        }
                        catch
                        { }
                    }
                    // COLOR
                    else if (line_split[0].ToLower() == "color")
                    {
                        try
                        {
                            string color_string = line.Substring(6);
                            form.color[1] = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(color_string);
                        }
                        catch
                        { }
                    }
                }

                stream.Close();
                stream.Dispose();
            }
        }

        public void Save_Settings()
        {
            // Check-Create file
            if (File.Exists(settings_path))
                File.Delete(settings_path);

            int cd = 100;
            while (File.Exists(settings_path) && cd > 0)
            {
                Thread.Sleep(10);
                cd--;
            }
            if (cd <= 0) return;

            using (StreamWriter stream = new StreamWriter(settings_path))
            {
                stream.WriteLine("Round=" + form.numeric_round_vals.Value.ToString());
                stream.WriteLine("Hide_Empty_Values=" + form.check_box_hide_empty_vals.Checked.ToString());
                stream.WriteLine("Reverse_Sort=" + form.check_box_reverse_sort.Checked.ToString());
                stream.WriteLine("Min_Val=" + form.numeric_min_val.Value.ToString());
                stream.WriteLine("Max_Val=" + form.numeric_max_val.Value.ToString());
                stream.WriteLine("Font=" + TypeDescriptor.GetConverter(typeof(Font)).ConvertToString(form.list_view_display.Font));
                stream.WriteLine("Color=" + TypeDescriptor.GetConverter(typeof(Color)).ConvertToString(form.color[1]));

                stream.Close();
                stream.Dispose();
            }
        }

        public void Load_Xls_Info()
        {
            if (!File.Exists(xls_info_path))
                return;

            using (StreamReader stream = new StreamReader(xls_info_path))
            {
                string line;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] line_split = line.Split('=');

                    if (line_split.Length < 2) continue;

                    // DEFAULT_XLS
                    if (line_split[0].ToLower() == "default_xls")
                    {
                        form.default_xls = line_split[1];
                    }
                }

                stream.Close();
                stream.Dispose();
            }
        }

        public void Save_Xls_Info()
        {
            // Check-Create file
            if (File.Exists(xls_info_path))
                File.Delete(xls_info_path);

            int cd = 100;
            while (File.Exists(xls_info_path) && cd > 0)
            {
                Thread.Sleep(10);
                cd--;
            }
            if (cd <= 0) return;

            using (StreamWriter stream = new StreamWriter(xls_info_path))
            {
                stream.WriteLine("Default_Xls=" + form.default_xls.ToString());

                stream.Close();
                stream.Dispose();
            }            
        }

    }
}
