namespace PortaCellTec_Database
{
    partial class LoadManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadManager));
            this.checked_list_box = new System.Windows.Forms.CheckedListBox();
            this.button_add = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_select_all = new System.Windows.Forms.Button();
            this.button_deselect_all = new System.Windows.Forms.Button();
            this.button_set_default = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checked_list_box
            // 
            this.checked_list_box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checked_list_box.CheckOnClick = true;
            this.checked_list_box.FormattingEnabled = true;
            this.checked_list_box.Location = new System.Drawing.Point(0, 2);
            this.checked_list_box.Name = "checked_list_box";
            this.checked_list_box.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.checked_list_box.Size = new System.Drawing.Size(712, 454);
            this.checked_list_box.TabIndex = 4;
            this.checked_list_box.Click += new System.EventHandler(this.checked_list_box_Click);
            // 
            // button_add
            // 
            this.button_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_add.Location = new System.Drawing.Point(718, 2);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(107, 23);
            this.button_add.TabIndex = 5;
            this.button_add.Text = "Add Excel File";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_update
            // 
            this.button_update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_update.Location = new System.Drawing.Point(718, 31);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(107, 23);
            this.button_update.TabIndex = 6;
            this.button_update.Text = "Replace Excel File";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_delete
            // 
            this.button_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_delete.Location = new System.Drawing.Point(718, 60);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(107, 23);
            this.button_delete.TabIndex = 7;
            this.button_delete.Text = "Delete Excel File";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.Location = new System.Drawing.Point(718, 234);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(107, 23);
            this.button_ok.TabIndex = 8;
            this.button_ok.Text = "Show Selected";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_select_all
            // 
            this.button_select_all.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_select_all.Location = new System.Drawing.Point(718, 147);
            this.button_select_all.Name = "button_select_all";
            this.button_select_all.Size = new System.Drawing.Size(107, 23);
            this.button_select_all.TabIndex = 9;
            this.button_select_all.Text = "Select All";
            this.button_select_all.UseVisualStyleBackColor = true;
            this.button_select_all.Click += new System.EventHandler(this.button_select_all_Click);
            // 
            // button_deselect_all
            // 
            this.button_deselect_all.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_deselect_all.Location = new System.Drawing.Point(718, 176);
            this.button_deselect_all.Name = "button_deselect_all";
            this.button_deselect_all.Size = new System.Drawing.Size(107, 23);
            this.button_deselect_all.TabIndex = 10;
            this.button_deselect_all.Text = "Deselect All";
            this.button_deselect_all.UseVisualStyleBackColor = true;
            this.button_deselect_all.Click += new System.EventHandler(this.button_deselect_all_Click);
            // 
            // button_set_default
            // 
            this.button_set_default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_set_default.Location = new System.Drawing.Point(718, 89);
            this.button_set_default.Name = "button_set_default";
            this.button_set_default.Size = new System.Drawing.Size(107, 23);
            this.button_set_default.TabIndex = 11;
            this.button_set_default.Text = "Set As Startup";
            this.button_set_default.UseVisualStyleBackColor = true;
            this.button_set_default.Click += new System.EventHandler(this.button_set_default_Click);
            // 
            // LoadManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 457);
            this.Controls.Add(this.button_set_default);
            this.Controls.Add(this.button_deselect_all);
            this.Controls.Add(this.button_select_all);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.checked_list_box);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(370, 286);
            this.Name = "LoadManager";
            this.Text = "Load Manager";
            this.Load += new System.EventHandler(this.LoadManager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checked_list_box;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_select_all;
        private System.Windows.Forms.Button button_deselect_all;
        private System.Windows.Forms.Button button_set_default;
    }
}