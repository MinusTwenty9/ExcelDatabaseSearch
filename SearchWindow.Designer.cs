namespace PortaCellTec_Database
{
    partial class SearchWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchWindow));
            this.button_search = new System.Windows.Forms.Button();
            this.checked_list_box = new System.Windows.Forms.CheckedListBox();
            this.button_select_all = new System.Windows.Forms.Button();
            this.button_deselect_all = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_search
            // 
            this.button_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_search.Location = new System.Drawing.Point(225, 390);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(105, 23);
            this.button_search.TabIndex = 1;
            this.button_search.Text = "Show Selected";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // checked_list_box
            // 
            this.checked_list_box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checked_list_box.CheckOnClick = true;
            this.checked_list_box.FormattingEnabled = true;
            this.checked_list_box.Location = new System.Drawing.Point(-1, 0);
            this.checked_list_box.Name = "checked_list_box";
            this.checked_list_box.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.checked_list_box.Size = new System.Drawing.Size(335, 379);
            this.checked_list_box.TabIndex = 3;
            this.checked_list_box.Click += new System.EventHandler(this.checked_list_box_Click);
            // 
            // button_select_all
            // 
            this.button_select_all.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_select_all.Location = new System.Drawing.Point(114, 390);
            this.button_select_all.Name = "button_select_all";
            this.button_select_all.Size = new System.Drawing.Size(105, 23);
            this.button_select_all.TabIndex = 4;
            this.button_select_all.Text = "Select All";
            this.button_select_all.UseVisualStyleBackColor = true;
            this.button_select_all.Click += new System.EventHandler(this.button_select_all_Click);
            // 
            // button_deselect_all
            // 
            this.button_deselect_all.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_deselect_all.Location = new System.Drawing.Point(3, 390);
            this.button_deselect_all.Name = "button_deselect_all";
            this.button_deselect_all.Size = new System.Drawing.Size(105, 23);
            this.button_deselect_all.TabIndex = 5;
            this.button_deselect_all.Text = "Deselect All";
            this.button_deselect_all.UseVisualStyleBackColor = true;
            this.button_deselect_all.Click += new System.EventHandler(this.button_deselect_all_Click);
            // 
            // SearchWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 415);
            this.Controls.Add(this.button_deselect_all);
            this.Controls.Add(this.button_select_all);
            this.Controls.Add(this.checked_list_box);
            this.Controls.Add(this.button_search);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(339, 185);
            this.Name = "SearchWindow";
            this.Text = "SearchWindow";
            this.Load += new System.EventHandler(this.SearchWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.CheckedListBox checked_list_box;
        private System.Windows.Forms.Button button_select_all;
        private System.Windows.Forms.Button button_deselect_all;
    }
}