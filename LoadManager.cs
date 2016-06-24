using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace PortaCellTec_Database
{
    public partial class LoadManager : Form
    {
        public List<string> file_names = new List<string>();
        public List<bool> selected = new List<bool>();
        public string dir_path = Environment.CurrentDirectory + "\\ExcelFiles\\";
        public string default_xls = "";
        public bool ok = false;

        public LoadManager(Font font, string default_xls)
        {
            InitializeComponent();

            checked_list_box.Font = font;
            this.default_xls = default_xls;
        }

        private void LoadManager_Load(object sender, EventArgs e)
        {
            // Check and create ExcelFile Directory
            if (!Directory.Exists(dir_path))
                Directory.CreateDirectory(dir_path);

            int cd = 100;
            while (!Directory.Exists(dir_path) && cd > 0)
            {
                cd--;
                Thread.Sleep(10);
            }
            if (cd == 0) return;

            // Load Files
            DirectoryInfo di = new DirectoryInfo(dir_path);
            FileInfo[] fi = di.GetFiles();

            for (int i = 0; i < fi.Length; i++)
                add_index(fi[i].Name);

        }

        private void checked_list_box_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checked_list_box.Items.Count; i++)
            {
                if (checked_list_box.GetItemRectangle(i).Contains(checked_list_box.PointToClient(MousePosition)))
                {
                    switch (checked_list_box.GetItemCheckState(i))
                    {
                        case CheckState.Checked:
                            checked_list_box.SetItemCheckState(i, CheckState.Unchecked);
                            break;
                        case CheckState.Indeterminate:
                        case CheckState.Unchecked:
                            checked_list_box.SetItemCheckState(i, CheckState.Checked);
                            break;
                    }
                    selected[i] = (checked_list_box.GetItemCheckState(i) == CheckState.Checked ? true : false);
                }
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            int selected = get_selected();
            if (selected == -2)
            {
                MessageBox.Show("You can only select 1 item.");
                return;
            }
            ok = true;
            this.Close();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            string name = load_excel_file();
            if (name != "")
                add_index(name);
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            int selected = get_selected();
            if (selected < 0)
            {
                error_selection(selected);
                return;
            }
            try
            {
                // Loading the excel file
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Excel File (*.xls)|*.xls|All files (*.*)|*.*";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            string[] name_split = ofd.FileName.Split('\\');
                            string name = name_split[name_split.Length - 1];

                            // Test if the file has the same name if so:
                            // write the new file according to the write rules (_2, _3, _...)
                            // and manuly delete the old one
                            if (name != file_names[selected])
                            {
                                name = name.Substring(0, name.Length - 4);
                                int index = 1;

                                while (File.Exists(dir_path + name + (index == 1 ? "" : "_" + index.ToString()) + ".xls") && name + "_" + index + ".xls" != file_names[selected]) index++;

                                name = name + (index == 1 ? "" : "_" + index.ToString()) + ".xls";
                                
                                if (File.Exists(dir_path + file_names[selected]))
                                    File.Delete(dir_path + file_names[selected]);

                                int cd = 100;
                                while (File.Exists(dir_path + file_names[selected]) && cd > 0)
                                {
                                    cd--;
                                    Thread.Sleep(10);
                                }
                                if (cd == 0) return;
                            }

                            // Write/Override the file
                            File.Copy(ofd.FileName, dir_path + name, true);

                            file_names[selected] = name;
                            checked_list_box.Items[selected] = name;

                        }
                        catch { return; }
                    }
                    ofd.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("Could not update file, \nplease try again.");
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < selected.Count; i++)
                if (selected[i])
                {
                    try 
                    {
                        File.Delete(dir_path + file_names[i]);
                        selected.RemoveAt(i);
                        file_names.RemoveAt(i);
                        checked_list_box.Items.RemoveAt(i);
                        i--;
                    }
                    catch 
                    {
                        MessageBox.Show("Could not delete file, \nplease try again.");
                    }
                }
        }

        private void button_select_all_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < selected.Count; i++)
            {
                selected[i] = true;
                checked_list_box.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void button_deselect_all_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < selected.Count; i++)
            {
                selected[i] = false;
                checked_list_box.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void button_set_default_Click(object sender, EventArgs e)
        {
            int selected = get_selected();
            if (selected < 0)
            {
                error_selection(selected); 
                return;
            }

            default_xls = file_names[selected];
        }


        private string load_excel_file()
        {
            string back = "";
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel File (*.xls)|*.xls|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] name_split = ofd.FileName.Split('\\');
                        string name = name_split[name_split.Length - 1];
                        name = name.Substring(0,name.Length-4);
                        int index = 1;

                        while (File.Exists(dir_path + name + (index == 1 ? "" : "_" + index.ToString()) + ".xls")) index++;

                        name = name + (index == 1 ? "" : "_" + index.ToString()) + ".xls";

                        File.Copy(ofd.FileName, dir_path + name, true);

                        back = name;
                    }
                    catch { back = ""; }
                }

                ofd.Dispose();
            }

            return back;
        }

        private int get_selected()
        {
            int back = -1;
            for (int i = 0; i < selected.Count; i++)
                if (selected[i])
                {
                    if (back == -1)
                        back = i;
                    else { back = -2; break; }
                }
            return back;
        }

        private void error_selection(int selected)
        {
            if (selected == -1) MessageBox.Show("Nothing selected.");
            else MessageBox.Show("You can only select 1 item.");
        }

        private void add_index(string file_name, bool is_selected = false)
        {
            file_names.Add(file_name);
            selected.Add(is_selected);
            checked_list_box.Items.Add(file_name);
        }

    }
}
