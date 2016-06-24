using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel;
using Excel.Core;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace PortaCellTec_Database
{
    public class DataBase
    {
        private Form_Main form;
        public string path = "";
        private DataSet data_set;
        public List<InfoTile> info_tiles = new List<InfoTile>();

        // Filter Apply function
        private List<SearchResult> f_search_info_tiles = new List<SearchResult>();
        private List<int> f_focus = new List<int>();

        private string[] header_names = null;

        private string[] value_names = null;

        private int value_column_offset = 3;
        private int sort_field = 3;
        private bool reverse = false;

        public DataBase(Form_Main form)
        {
            this.form = form; 
            header_names = new string[4] {"Transporter","Genes","Sub. Classes","Substances"};

            this.form.list_view_display.ColumnClick += new ColumnClickEventHandler(header_click);
        }

        // Load's the Database form the excel file at path
        public void Load_DataBase()
        {
            info_tiles.Clear();

            ///CHANGE
            if (!File.Exists(path))
            {
                //if (!load_excel_file())
                return;
            }

            //try
            //{
                // Load xls file
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    IExcelDataReader reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    data_set = reader.AsDataSet();
                    //File.WriteAllText(Environment.CurrentDirectory + "\\test.xml", data_set.GetXml());

                    // No data
                    if (data_set.Tables.Count == 0 || !table_error_ok(data_set)) return;

                    // Vars
                    object[] transporter_array = data_set.Tables[0].Rows[0].ItemArray;
                    object[] t_class_array = data_set.Tables[0].Rows[1].ItemArray;
                    object[] value_names = data_set.Tables[0].Rows[2].ItemArray;

                    header_names[0] = transporter_array[1].ToString();
                    header_names[1] = t_class_array[1].ToString();
                    header_names[2] = value_names[1].ToString();
                    header_names[3] = value_names[0].ToString();

                    // Calculate Value length
                    int value_length = get_value_length(transporter_array);

                    // Set the combobox values
                    initialize_value_names(value_names, value_length);

                    sort_field = 3;
                    // Draw list_view_headers
                    create_list_view_headers();


                    List<string> transporter = new List<string>();
                    List<string> t_class = new List<string>();
                    List<object[]> substances = new List<object[]>();

                    // Calculate transporter count
                    int t_length = (transporter_array.Length - 2) / value_length;
                    for (int i = 0; i < t_length; i++)
                        if (transporter_array[2 + (i * value_length)].ToString() == "")
                        {
                            t_length = i;
                            break;
                        }

                    int t_class_length = t_length;
                    int substance_length = 0;

                    // Load substances (and details)
                    for (int s = 3; s < data_set.Tables[0].Rows.Count; s++)
                    {
                        if (data_set.Tables[0].Rows[s].ItemArray.Length <= 1 ||
                            data_set.Tables[0].Rows[s].ItemArray[1].GetType() != typeof(string))
                        { break; }

                        substances.Add(data_set.Tables[0].Rows[s].ItemArray);
                        substance_length++;
                    }

                    // Load transformers (and detail names)
                    for (int t = 0; t < t_length; t++)
                    {
                        transporter.Add(transporter_array[2 + (t * value_length)].ToString());
                        t_class.Add(t_class_array[2 + (t * value_length)].ToString());
                    }


                    // Load InfoTiles
                    load_info_tiles(substances, transporter, t_class, value_length, substance_length);

                    stream.Close();
                    stream.Dispose();
                }

                form.settings.Load_Settings();

                // Form title
                string[] name_split = path.Split('\\');
                form.Text = "PortaCellTec Database - " + name_split[name_split.Length - 1];
            
                Search("", false,true);
            //}
            //catch
            //{
            //    MessageBox.Show("Error loading excel file, \n maybe wrong format.");
            //}
        }

        public void Search(string query, bool show_search_window = true, bool calc_min_max = false)
        {
            query = query.ToLower();

            string[] query_split = query.Split(' ');
            //string[] query_split = new string[mem_query_split.Length+1];
            //query_split[query_split.Length - 1] = query.Replace(" ","");

            //for (int i = 0; i < mem_query_split.Length; i++) 
            //    query_split[i] = mem_query_split[i];

            int focus_count = 4;
            double max_score = (query == "" ? 0 : 1);
            List<SearchResult> search_results = new List<SearchResult>();
            List<string> search_strings = new List<string>();

            #region Compute Score

            // Search for the querys and 
            // Sort them for there category if they fit in it
                for (int f = 0; f < focus_count && !(query == "" && f >= 2); f++)
                {
                    for (int i = 0; i < info_tiles.Count; i++)
                    {
                        string search_string = info_tiles[i].Get_Search_String(f); 
                        double ss_score = 0;
                        for (int q = 0; q < query_split.Length; q++)
                        {
                            ss_score += search_string.ToLower().Split(new string[] { query_split[q] }, StringSplitOptions.None).Length - 1;
                            ss_score += search_string.Replace(" ","").ToLower().Split(new string[] { query_split[q] }, StringSplitOptions.None).Length - 1;
                        }
                            
                        if (search_string == "") continue;

                        // Search Filters
                        if (ss_score >= max_score)
                        {
                            if (ss_score > 0)
                                ss_score /= ss_score;

                            bool found = false;
                            for (int y = 0; y < search_results.Count; y++)
                                if (search_results[y].focus_name == search_string)
                                {
                                    // Transporter
                                    if (((f == 0 || f == 2) && search_results[y].info_tiles[0].t_id == info_tiles[i].t_id) ||
                                        ((f == 1 || f == 3) && search_results[y].info_tiles[0].s_id == info_tiles[i].s_id))
                                    {
                                        found = true;
                                        search_results[y].Add(info_tiles[i]);
                                        break;
                                    }
                                    else 
                                    { }
                                }

                            // Add new category
                            if (found == false)
                            {
                                search_results.Add(new SearchResult(search_string, ss_score));
                                search_results[search_results.Count - 1].Add(info_tiles[i]);
                            }
                        }

                        if (ss_score > max_score) max_score = ss_score;
                    }
                }


            // Get rid of SearchResults with scores under_max_score
            // Set the search strings
            for (int i = 0; i < search_results.Count; i++)
                if (search_results[i].score < max_score)
                {
                    search_results.RemoveAt(i);
                    i--;
                }
                else search_strings.Add(search_results[i].focus_name);

            #endregion

            #region Show SearchWindow

                form.list_view_display.Items.Clear();

            // Evaluate score
                bool[] selected_search_results = null;


                // More then 1 search result, show SearchWindow
                if (search_results.Count > 1)
                {
                    if (show_search_window == true)
                    {
                        using (SearchWindow search_window = new SearchWindow(search_strings, form.list_view_display.Font))
                        {
                            search_window.ShowDialog();
                            selected_search_results = search_window.selected_search_results;
                            search_window.Dispose();
                        }
                    }
                    else
                    {
                        selected_search_results = new bool[search_results.Count];
                        for (int i = 0; i < search_results.Count; i++)
                            selected_search_results[i] = true;
                    }
                }
                // 1 or 0 results
                else if (search_results.Count == 1)
                    selected_search_results = new bool[1] { true };
                else return;

                f_search_info_tiles.Clear();

                if (calc_min_max == false)
                {
                    // Display the selected
                    for (int i = 0; i < selected_search_results.Length; i++)
                    {
                        if (selected_search_results[i])
                        {
                            // Save for apply filters
                            f_search_info_tiles.Add(search_results[i]);

                            display_result(search_results[i]);
                        }
                    }
                }
                else
                {
                    // Display the selected
                    for (int i = 0; i < selected_search_results.Length; i++)
                        if (selected_search_results[i])
                            // Save for apply filters
                            f_search_info_tiles.Add(search_results[i]);

                    double[] min_max = Calculate_Min_Max();

                    form.numeric_min_val.Value = (min_max[0] == double.MaxValue ? 0 : (long)min_max[0]);
                    form.numeric_max_val.Value = (min_max[1] == double.MinValue ? 100 : (long)min_max[1]);

                    // Display the selected
                    for (int i = 0; i < selected_search_results.Length; i++)
                        if (selected_search_results[i])
                            display_result(search_results[i]);
                }

            #endregion
        }

        public void Load_New_Excel_File()
        {
            if (!load_excel_file())
                return;
            Load_DataBase();
        }

        public void Apply_Filters()
        {
            form.list_view_display.Items.Clear();
            
            // Display the selected
            for (int i = 0; i < f_search_info_tiles.Count; i++)
                display_result(f_search_info_tiles[i]);
        }

        private void display_result(SearchResult search_result)   // focus = t_name (0) || s_name (1)
        {
            DataValueType data_value_type = search_result.data_value_type;

            /// Sort
            // [Checkbox] Reverse Sort
            int sort_index = (form.combo_box_oder_by.SelectedIndex == -1 ? 0 : form.combo_box_oder_by.SelectedIndex);
            IEnumerable<InfoTile> info_tiles_orderd = null;

            // T_NAME || T_CLASS || S_NAME || S_CLASS
            if (sort_field < value_column_offset || sort_field == value_column_offset + search_result.info_tiles[0].values.Length)
            {
                if (sort_field == 0) info_tiles_orderd = search_result.info_tiles.OrderBy(f => f.t_name);
                else if (sort_field == 1) info_tiles_orderd = search_result.info_tiles.OrderBy(f => f.t_class);
                else if (sort_field == 2) info_tiles_orderd = search_result.info_tiles.OrderBy(f => f.s_name);
                else info_tiles_orderd = search_result.info_tiles.OrderBy(f => f.s_class);
            }
            // DataValues
            else
            {
                if (data_value_type == DataValueType.String) info_tiles_orderd = search_result.info_tiles.OrderBy(f => f.values[sort_field-value_column_offset].str_value);
                else if (data_value_type == DataValueType.Double) info_tiles_orderd = search_result.info_tiles.OrderBy(f => f.values[sort_field - value_column_offset].d_value);
                else if (data_value_type == DataValueType.Date) info_tiles_orderd = search_result.info_tiles.OrderBy(f => f.values[sort_field - value_column_offset].d_value);
            }

            // Reverse or not
            if (this.reverse == false)
                search_result.info_tiles = info_tiles_orderd.Reverse().ToList();
            else
                search_result.info_tiles = info_tiles_orderd.ToList();


            // Group
            ListViewGroup group = new ListViewGroup();
            group.Header = search_result.focus_name;
            int color_index = 1;

            for (int i = 0; i < search_result.info_tiles.Count; i++)
            {
                InfoTile info_tile = search_result.info_tiles[i];

                // Double
                if (data_value_type == DataValueType.Double)
                {
                    // [Checkbox] Hide Empty Vals
                    if (info_tile.values[sort_index].d_value == double.MinValue && form.check_box_hide_empty_vals.Checked == true) continue;

                    // [Numeric] Max Percent
                    if (info_tile.values[sort_index].d_value != double.MinValue)
                    {
                        if (info_tile.values[sort_index].d_value > (int)form.numeric_max_val.Value) continue;
                        else if (info_tile.values[sort_index].d_value < (int)form.numeric_min_val.Value) continue;
                    }
                }
                else if (data_value_type == DataValueType.String || data_value_type == DataValueType.Date)
                {
                    if (info_tile.values[sort_index].str_value.Replace(" ","") == "" && form.check_box_hide_empty_vals.Checked == true) continue;
                }

                ListViewItem item = new ListViewItem();
                item.BackColor = form.color[(color_index++)%2];

                // [Numeric] Round Percent
                string[] c_values = new string[info_tile.values.Length];
                for (int y = 0; y < c_values.Length; y++)
                {
                    if (info_tile.values[y].data_value_type == DataValueType.Double) c_values[y] = Math.Round(info_tile.values[y].d_value, (int)form.numeric_round_vals.Value).ToString();
                    else if (info_tile.values[y].data_value_type == DataValueType.String || info_tile.values[y].data_value_type == DataValueType.Date) c_values[y] = info_tile.values[y].str_value;
                }

                item.Text = info_tile.t_name;
                item.SubItems.Add(info_tile.t_class);
                item.SubItems.Add(info_tile.s_name);

                for (int y = 0; y < c_values.Length; y++)
                    item.SubItems.Add((c_values[y] == double.MinValue.ToString() ? "" : c_values[y]));

                item.SubItems.Add(info_tile.s_class);

                group.Items.Add(item);
                form.list_view_display.Items.Add(item);
            }

            form.list_view_display.Groups.Add(group);
        }

        private bool load_excel_file()
        {
            bool back = false;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel File (*.xls)|*.xls|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    back = true;
                    try
                    {
                        File.Copy(ofd.FileName, path, true);
                    }
                    catch { back = false; }
                }

                ofd.Dispose();
            }

            return back;
        }


        // Returns the count of different value_names
        private int get_value_length(object[] transporter_array)
        {
            int value_length = 1;
            for (int i = 3; i < transporter_array.Length; i++)
            {
                if (transporter_array[i].ToString() != "")
                    break;
                value_length++;
            }
            return value_length;
        }

        // Initilize this.value_names
        // Fill the value_names combobox
        private void initialize_value_names(object[] value_names, int value_length)
        {
            form.combo_box_oder_by.Items.Clear();           // Clear Combobox
            this.value_names = new string[value_length];    // initialize the this.value_names string

            // Write value_names to this.value_names and combobox
            for (int i = 0; i < value_length; i++)
            {
                this.value_names[i] = value_names[i + 2].ToString();
                form.combo_box_oder_by.Items.Add(this.value_names[i]);
            }

            // Select first combobox index
            if (form.combo_box_oder_by.Items.Count > 0)
                form.combo_box_oder_by.SelectedIndex = 0;
        }

        // Load's the infotiles from the previousely collected information
        private void load_info_tiles(List<object[]> substances, List<string> transporter, List<string> t_class, int value_length,int substance_length)
        {
            info_tiles.Clear();
            string l_s_class = "";

            for (int i = 0; i < substance_length; i++)
            {
                // Add substance class
                if (substances[i][0].ToString() != "")
                    l_s_class = substances[i][0].ToString();

                // Itterate through all transporters
                for (int t = 0; t < transporter.Count; t++)
                {
                    bool is_date = false;

                    string param_t_name = transporter[t].ToString();
                    string param_t_class = t_class[t].ToString();
                    string param_s_name = substances[i][1].ToString();
                    string param_s_class = l_s_class;
                    int t_id = t;
                    int s_id = i;
                    DataValue[] values = new DataValue[value_length];


                    int t_start_index = param_t_name.ToLower().IndexOf("[date]");
                    int s_start_index = param_s_name.ToLower().IndexOf("[date]");

                    // Check for date
                    if (t_start_index != -1 && t_start_index + 6 <= param_t_name.Length && param_t_name.Substring(t_start_index+6).Replace(" ","") == "")
                    {
                        is_date = true;
                        param_t_name = param_t_name.Substring(0, t_start_index);
                    }
                    if (param_s_name.Length >= 6 && param_s_name.Replace(" ", "").Substring(param_s_name.Length - 6).ToLower() == "[date]")
                    {
                        is_date = true;
                        param_s_name = param_s_name.Substring(0, param_s_name.Length - 6);
                    }
                    
                    // Asign values
                    for (int y = 0; y < value_length; y++)
                    {
                        string data_string = substances[i][2 + y + (t * value_length)].ToString();

                        // Empty Value (no value, could be numbers)
                        if (data_string.Replace(" ", "") == "")
                            values[y] = new DataValue(double.MinValue);
                        // Numbers or strings
                        else
                        {
                            double value;
                            // String
                            if (!double.TryParse(data_string, out value))
                                values[y] = new DataValue(data_string);
                            // Number or date
                            else
                            {
                                string[] date_split = data_string.Split('.');
                                if (is_date == true && date_split.Length == 3)
                                {
                                    int year;
                                    int month;
                                    int day;

                                    if (!(int.TryParse(date_split[0], out day)
                                        && int.TryParse(date_split[1], out month)
                                        && int.TryParse(date_split[2], out year)))
                                    {
                                        values[y] = new DataValue(data_string);
                                        continue;
                                    }

                                    DateTime dt = new DateTime(year, month, day);
                                    value = dt.ToOADate();
                                }

                                values[y] = new DataValue(value, is_date);
                            }
                        }
                    }

                    ///CHANGE
                    InfoTile info_tile = new InfoTile(param_t_name, param_s_name, param_t_class, param_s_class, t_id, s_id, values);
                    info_tiles.Add(info_tile);
                }
            }
        }

        // Draws the List_View headers according to the value_names
        private void create_list_view_headers()
        {
            if (value_names == null) return;

            ColumnHeader b_header = new ColumnHeader();
            ColumnHeader[] col_header = new ColumnHeader[value_names.Length + 4];

            b_header.Width = 200;
            for (int i = 0; i < col_header.Length; i++)
                col_header[i] = (ColumnHeader)b_header.Clone();

            col_header[0].Text = header_names[0];
            col_header[1].Text = header_names[1];
            col_header[2].Text = header_names[2];

            for (int i = 0; i < value_names.Length; i++)
                col_header[i + 3].Text = value_names[i];

            col_header[col_header.Length - 1].Text = header_names[3];

            form.list_view_display.Columns.Clear();
            for (int i = 0; i < col_header.Length; i++)
                form.list_view_display.Columns.Add(col_header[i]);
        }

        private void header_click(object sender, ColumnClickEventArgs e)
        {
            if (this.sort_field == e.Column) this.reverse = !reverse;
            else reverse = e.Column < 3 || e.Column == 2+value_column_offset;

            this.sort_field = e.Column;
            Apply_Filters();
        }

        private bool table_error_ok(DataSet data_set)
        {
            object[] line_0 = data_set.Tables[0].Rows[0].ItemArray;

            if (line_0.Length < 3) return false;
            if (data_set.Tables[0].Rows.Count < 4) return false;

            return true;
        }

        public double[] Calculate_Min_Max()
        {
            double min = double.MaxValue;
            double max = double.MinValue;

            int value_index = (form.combo_box_oder_by.SelectedIndex == -1? 0 : form.combo_box_oder_by.SelectedIndex);

            for (int i = 0; i < f_search_info_tiles.Count; i++)
            {
                if (f_search_info_tiles[i].data_value_type != DataValueType.Double) continue;

                for (int y = 0; y < f_search_info_tiles[i].info_tiles.Count; y++)
                {
                    double c_val = f_search_info_tiles[i].info_tiles[y].values[value_index].d_value;
                    if (c_val == double.MinValue) continue;

                    if (c_val > max)
                        max = c_val;
                    else if (c_val < min)
                        min = c_val;
                }
            }

            return new double[] { Math.Floor(min), Math.Ceiling(max) };
        }
    }
}
