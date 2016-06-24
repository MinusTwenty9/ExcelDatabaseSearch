using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel;
using Excel.Core;
using System.IO;

namespace PortaCellTec_Database
{
    public partial class Form_Main : Form
    {
        DataBase db;
        public Settings settings;
        public string default_xls = "";
        public Color[] color;

        public Form_Main()
        {
            InitializeComponent();

            numeric_min_val.Minimum = long.MinValue;
            numeric_max_val.Minimum = long.MinValue;
            numeric_min_val.Maximum = long.MaxValue;
            numeric_max_val.Maximum = long.MaxValue;

            color = new Color[2];
            color[0] = Color.FromArgb(255, 255, 255);
            color[1] = Color.FromArgb(255, 255, 255);

            settings = new Settings(this);
            settings.Load_Xls_Info();
            
            db = new DataBase(this);
            load_default_xls();
            db.Load_DataBase();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            db.Search(text_box_search.Text);
        }

        private void text_box_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                db.Search(text_box_search.Text);
            }
        }

        private void text_box_search_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void text_box_search_Enter(object sender, EventArgs e)
        {
            // Select text when reentering the textbox
            text_box_search.SelectionStart = 0;
            text_box_search.SelectionLength = text_box_search.Text.Length;
        }

        private void button_font_Click(object sender, EventArgs e)
        {
            using (FontDialog fd = new FontDialog())
            {
                fd.Font = list_view_display.Font;
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    list_view_display.Font = fd.Font;
                }
            }
        }

        private void numeric_max_percent_ValueChanged(object sender, EventArgs e)
        {
            if (numeric_max_val.Value < numeric_min_val.Value)
                numeric_max_val.Value = numeric_min_val.Value;

        }

        private void numeric_min_percent_ValueChanged(object sender, EventArgs e)
        {
            if (numeric_min_val.Value > numeric_max_val.Value)
                numeric_min_val.Value = numeric_max_val.Value;
        }

        private void button_load_manager_Click(object sender, EventArgs e)
        {
            using (LoadManager lm = new LoadManager(list_view_display.Font,default_xls))
            {
                lm.ShowDialog();

                string excel_path = "";

                for (int i = 0; i < lm.file_names.Count; i++)
                    if (lm.selected[i] == true)
                    {
                        excel_path = lm.dir_path + lm.file_names[i];
                        break;
                    }

                // Save default_xls and check if it still exists
                default_xls = (!File.Exists(lm.dir_path + lm.default_xls) ? "" : lm.default_xls);
                settings.Save_Xls_Info();

                db.path = excel_path;
                if (excel_path != "")
                {
                    if (lm.ok == true)
                        db.Load_DataBase();
                }

                lm.Dispose();
            }
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            db.Apply_Filters();
        }
        
        private void button_save_settings_Click(object sender, EventArgs e)
        {
            settings.Save_Settings();
        }

        #region Settings Enter Press

        private void settings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                db.Apply_Filters();
        }

        private void list_view_display_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                db.Search("", true);
        }

        #endregion

        private void load_default_xls()
        { 
            string dir_path = Environment.CurrentDirectory + "\\ExcelFiles\\";
            if (!Directory.Exists(dir_path)) return;

            DirectoryInfo di = new DirectoryInfo(dir_path);
            FileInfo[] fi = di.GetFiles();

            for (int i = 0; i < fi.Length; i++)
                if (fi[i].Name == default_xls)
                {
                    db.path = dir_path + default_xls;
                    db.Load_DataBase();
                    break;
                }
        }

        private void button_change_color_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                if (cd.ShowDialog() == DialogResult.OK && cd.Color != Color.Black)
                {
                    color[1] = cd.Color;
                    db.Apply_Filters();
                }
                cd.Dispose();
            }
        }

        private void button_reset_settings_Click(object sender, EventArgs e)
        {
            settings.Load_Settings();
            db.Apply_Filters();
        }

        private void button_calc_min_max_Click(object sender, EventArgs e)
        {
            if (db == null) return;
            double[] min_max = db.Calculate_Min_Max();

            numeric_min_val.Value = (min_max[0] == double.MaxValue ? 0 : (long)min_max[0]);
            numeric_max_val.Value = (min_max[1] == double.MinValue ? 100 : (long)min_max[1]);
        }

    }
}
