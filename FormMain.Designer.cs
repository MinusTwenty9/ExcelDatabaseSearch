namespace PortaCellTec_Database
{
    partial class Form_Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.text_box_search = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.list_view_display = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.combo_box_oder_by = new System.Windows.Forms.ComboBox();
            this.group_box_filter = new System.Windows.Forms.GroupBox();
            this.button_reset_settings = new System.Windows.Forms.Button();
            this.button_change_color = new System.Windows.Forms.Button();
            this.button_save_settings = new System.Windows.Forms.Button();
            this.button_apply = new System.Windows.Forms.Button();
            this.check_box_reverse_sort = new System.Windows.Forms.CheckBox();
            this.numeric_max_val = new System.Windows.Forms.NumericUpDown();
            this.numeric_min_val = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_font = new System.Windows.Forms.Button();
            this.check_box_hide_empty_vals = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numeric_round_vals = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button_load_manager = new System.Windows.Forms.Button();
            this.button_calc_min_max = new System.Windows.Forms.Button();
            this.group_box_filter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_max_val)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_min_val)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_round_vals)).BeginInit();
            this.SuspendLayout();
            // 
            // text_box_search
            // 
            this.text_box_search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.text_box_search.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_box_search.Location = new System.Drawing.Point(114, 5);
            this.text_box_search.Name = "text_box_search";
            this.text_box_search.Size = new System.Drawing.Size(1118, 26);
            this.text_box_search.TabIndex = 0;
            this.text_box_search.Enter += new System.EventHandler(this.text_box_search_Enter);
            this.text_box_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_box_search_KeyDown);
            this.text_box_search.KeyUp += new System.Windows.Forms.KeyEventHandler(this.text_box_search_KeyUp);
            // 
            // button_search
            // 
            this.button_search.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_search.Location = new System.Drawing.Point(5, 5);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(103, 26);
            this.button_search.TabIndex = 2;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // list_view_display
            // 
            this.list_view_display.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.list_view_display.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.list_view_display.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.list_view_display.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_view_display.FullRowSelect = true;
            this.list_view_display.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.list_view_display.LabelWrap = false;
            this.list_view_display.Location = new System.Drawing.Point(5, 37);
            this.list_view_display.Name = "list_view_display";
            this.list_view_display.Size = new System.Drawing.Size(1227, 714);
            this.list_view_display.TabIndex = 3;
            this.list_view_display.UseCompatibleStateImageBehavior = false;
            this.list_view_display.View = System.Windows.Forms.View.Details;
            this.list_view_display.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_view_display_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Transporter";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Substance";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Gene";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Sub. Class";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Percent";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "SEM";
            this.columnHeader6.Width = 200;
            // 
            // combo_box_oder_by
            // 
            this.combo_box_oder_by.FormattingEnabled = true;
            this.combo_box_oder_by.Location = new System.Drawing.Point(9, 38);
            this.combo_box_oder_by.Name = "combo_box_oder_by";
            this.combo_box_oder_by.Size = new System.Drawing.Size(173, 21);
            this.combo_box_oder_by.TabIndex = 4;
            this.combo_box_oder_by.KeyDown += new System.Windows.Forms.KeyEventHandler(this.settings_KeyDown);
            // 
            // group_box_filter
            // 
            this.group_box_filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.group_box_filter.Controls.Add(this.button_calc_min_max);
            this.group_box_filter.Controls.Add(this.button_reset_settings);
            this.group_box_filter.Controls.Add(this.button_change_color);
            this.group_box_filter.Controls.Add(this.button_save_settings);
            this.group_box_filter.Controls.Add(this.button_apply);
            this.group_box_filter.Controls.Add(this.check_box_reverse_sort);
            this.group_box_filter.Controls.Add(this.numeric_max_val);
            this.group_box_filter.Controls.Add(this.numeric_min_val);
            this.group_box_filter.Controls.Add(this.label5);
            this.group_box_filter.Controls.Add(this.label1);
            this.group_box_filter.Controls.Add(this.button_font);
            this.group_box_filter.Controls.Add(this.check_box_hide_empty_vals);
            this.group_box_filter.Controls.Add(this.label3);
            this.group_box_filter.Controls.Add(this.numeric_round_vals);
            this.group_box_filter.Controls.Add(this.label2);
            this.group_box_filter.Controls.Add(this.combo_box_oder_by);
            this.group_box_filter.Location = new System.Drawing.Point(1238, 33);
            this.group_box_filter.Name = "group_box_filter";
            this.group_box_filter.Size = new System.Drawing.Size(189, 718);
            this.group_box_filter.TabIndex = 5;
            this.group_box_filter.TabStop = false;
            this.group_box_filter.Text = "Filter";
            // 
            // button_reset_settings
            // 
            this.button_reset_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_reset_settings.Location = new System.Drawing.Point(9, 426);
            this.button_reset_settings.Name = "button_reset_settings";
            this.button_reset_settings.Size = new System.Drawing.Size(173, 23);
            this.button_reset_settings.TabIndex = 22;
            this.button_reset_settings.Text = "Reset Settings";
            this.button_reset_settings.UseVisualStyleBackColor = true;
            this.button_reset_settings.Click += new System.EventHandler(this.button_reset_settings_Click);
            // 
            // button_change_color
            // 
            this.button_change_color.Location = new System.Drawing.Point(9, 233);
            this.button_change_color.Name = "button_change_color";
            this.button_change_color.Size = new System.Drawing.Size(173, 23);
            this.button_change_color.TabIndex = 21;
            this.button_change_color.Text = "Change Color";
            this.button_change_color.UseVisualStyleBackColor = true;
            this.button_change_color.Click += new System.EventHandler(this.button_change_color_Click);
            // 
            // button_save_settings
            // 
            this.button_save_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save_settings.Location = new System.Drawing.Point(9, 683);
            this.button_save_settings.Name = "button_save_settings";
            this.button_save_settings.Size = new System.Drawing.Size(174, 23);
            this.button_save_settings.TabIndex = 20;
            this.button_save_settings.Text = "Save Settings";
            this.button_save_settings.UseVisualStyleBackColor = true;
            this.button_save_settings.Click += new System.EventHandler(this.button_save_settings_Click);
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(9, 506);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(115, 23);
            this.button_apply.TabIndex = 19;
            this.button_apply.Text = "Apply Settings";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // check_box_reverse_sort
            // 
            this.check_box_reverse_sort.AutoSize = true;
            this.check_box_reverse_sort.Location = new System.Drawing.Point(9, 162);
            this.check_box_reverse_sort.Name = "check_box_reverse_sort";
            this.check_box_reverse_sort.Size = new System.Drawing.Size(88, 17);
            this.check_box_reverse_sort.TabIndex = 18;
            this.check_box_reverse_sort.Text = "Reverse Sort";
            this.check_box_reverse_sort.UseVisualStyleBackColor = true;
            this.check_box_reverse_sort.Visible = false;
            this.check_box_reverse_sort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.settings_KeyDown);
            // 
            // numeric_max_val
            // 
            this.numeric_max_val.Location = new System.Drawing.Point(72, 352);
            this.numeric_max_val.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numeric_max_val.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numeric_max_val.Name = "numeric_max_val";
            this.numeric_max_val.Size = new System.Drawing.Size(110, 20);
            this.numeric_max_val.TabIndex = 16;
            this.numeric_max_val.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numeric_max_val.ValueChanged += new System.EventHandler(this.numeric_max_percent_ValueChanged);
            this.numeric_max_val.KeyDown += new System.Windows.Forms.KeyEventHandler(this.settings_KeyDown);
            // 
            // numeric_min_val
            // 
            this.numeric_min_val.Location = new System.Drawing.Point(72, 327);
            this.numeric_min_val.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numeric_min_val.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numeric_min_val.Name = "numeric_min_val";
            this.numeric_min_val.Size = new System.Drawing.Size(110, 20);
            this.numeric_min_val.TabIndex = 15;
            this.numeric_min_val.ValueChanged += new System.EventHandler(this.numeric_min_percent_ValueChanged);
            this.numeric_min_val.KeyDown += new System.Windows.Forms.KeyEventHandler(this.settings_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 354);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Max Value:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Min Value:";
            // 
            // button_font
            // 
            this.button_font.Location = new System.Drawing.Point(9, 204);
            this.button_font.Name = "button_font";
            this.button_font.Size = new System.Drawing.Size(173, 23);
            this.button_font.TabIndex = 11;
            this.button_font.Text = "Change Font";
            this.button_font.UseVisualStyleBackColor = true;
            this.button_font.Click += new System.EventHandler(this.button_font_Click);
            // 
            // check_box_hide_empty_vals
            // 
            this.check_box_hide_empty_vals.AutoSize = true;
            this.check_box_hide_empty_vals.Location = new System.Drawing.Point(9, 139);
            this.check_box_hide_empty_vals.Name = "check_box_hide_empty_vals";
            this.check_box_hide_empty_vals.Size = new System.Drawing.Size(115, 17);
            this.check_box_hide_empty_vals.TabIndex = 10;
            this.check_box_hide_empty_vals.Text = "Hide Empty Values";
            this.check_box_hide_empty_vals.UseVisualStyleBackColor = true;
            this.check_box_hide_empty_vals.KeyDown += new System.Windows.Forms.KeyEventHandler(this.settings_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Round values to decimalpoint:";
            // 
            // numeric_round_vals
            // 
            this.numeric_round_vals.Location = new System.Drawing.Point(9, 88);
            this.numeric_round_vals.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numeric_round_vals.Name = "numeric_round_vals";
            this.numeric_round_vals.Size = new System.Drawing.Size(147, 20);
            this.numeric_round_vals.TabIndex = 6;
            this.numeric_round_vals.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numeric_round_vals.KeyDown += new System.Windows.Forms.KeyEventHandler(this.settings_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filter Element:";
            // 
            // button_load_manager
            // 
            this.button_load_manager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_load_manager.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_load_manager.Location = new System.Drawing.Point(1238, 3);
            this.button_load_manager.Name = "button_load_manager";
            this.button_load_manager.Size = new System.Drawing.Size(189, 28);
            this.button_load_manager.TabIndex = 6;
            this.button_load_manager.Text = "Load Manager";
            this.button_load_manager.UseVisualStyleBackColor = true;
            this.button_load_manager.Click += new System.EventHandler(this.button_load_manager_Click);
            // 
            // button_calc_min_max
            // 
            this.button_calc_min_max.Location = new System.Drawing.Point(9, 299);
            this.button_calc_min_max.Name = "button_calc_min_max";
            this.button_calc_min_max.Size = new System.Drawing.Size(173, 23);
            this.button_calc_min_max.TabIndex = 23;
            this.button_calc_min_max.Text = "Calculate Min/Max";
            this.button_calc_min_max.UseVisualStyleBackColor = true;
            this.button_calc_min_max.Click += new System.EventHandler(this.button_calc_min_max_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 751);
            this.Controls.Add(this.button_load_manager);
            this.Controls.Add(this.group_box_filter);
            this.Controls.Add(this.list_view_display);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.text_box_search);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(693, 634);
            this.Name = "Form_Main";
            this.Text = "Database";
            this.group_box_filter.ResumeLayout(false);
            this.group_box_filter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_max_val)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_min_val)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_round_vals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox text_box_search;
        public System.Windows.Forms.Button button_search;
        public System.Windows.Forms.ListView list_view_display;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.ColumnHeader columnHeader3;
        public System.Windows.Forms.ColumnHeader columnHeader4;
        public System.Windows.Forms.ColumnHeader columnHeader5;
        public System.Windows.Forms.ColumnHeader columnHeader6;
        public System.Windows.Forms.ComboBox combo_box_oder_by;
        public System.Windows.Forms.GroupBox group_box_filter;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.NumericUpDown numeric_round_vals;
        public System.Windows.Forms.Button button_font;
        public System.Windows.Forms.CheckBox check_box_hide_empty_vals;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown numeric_max_val;
        public System.Windows.Forms.NumericUpDown numeric_min_val;
        public System.Windows.Forms.CheckBox check_box_reverse_sort;
        public System.Windows.Forms.Button button_load_manager;
        public System.Windows.Forms.Button button_apply;
        public System.Windows.Forms.Button button_save_settings;
        public System.Windows.Forms.Button button_change_color;
        public System.Windows.Forms.Button button_reset_settings;
        public System.Windows.Forms.Button button_calc_min_max;
    }
}

