using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PortaCellTec_Database
{
    public partial class SearchWindow : Form
    {
        private List<string> search_results;
        public bool[] selected_search_results;
        private Font font;

        public SearchWindow(List<string> search_results, Font font)
        {
            InitializeComponent();

            this.search_results = search_results;
            selected_search_results = new bool[search_results.Count];
            this.font = font;
        }

        private void SearchWindow_Load(object sender, EventArgs e)
        {
            checked_list_box.Font = font;

            load_list_view();
        }

        private void load_list_view()
        {
            for (int i = 0; i < search_results.Count; i++)
            {
                checked_list_box.Items.Add(search_results[i]);
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_select_all_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checked_list_box.Items.Count; i++)
            {
                checked_list_box.SetItemCheckState(i, CheckState.Checked);
                selected_search_results[i] = true;
            }
        }

        private void button_deselect_all_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checked_list_box.Items.Count; i++)
            {
                checked_list_box.SetItemCheckState(i, CheckState.Unchecked);
                selected_search_results[i] = false;
            }
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
                    selected_search_results[i] = checked_list_box.GetSelected(i);
                }
            }
        }
    }
}
