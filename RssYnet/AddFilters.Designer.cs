namespace rssYnet
{
    partial class AddFilters
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.cboCodes = new System.Windows.Forms.ComboBox();
            this.lstDsec = new System.Windows.Forms.ListBox();
            this.lstFilters = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtYeshuv = new System.Windows.Forms.TextBox();
            this.lblFind = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(-3, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "load helper";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboCodes
            // 
            this.cboCodes.FormattingEnabled = true;
            this.cboCodes.Location = new System.Drawing.Point(19, 58);
            this.cboCodes.Name = "cboCodes";
            this.cboCodes.Size = new System.Drawing.Size(217, 21);
            this.cboCodes.TabIndex = 1;
            this.cboCodes.SelectedIndexChanged += new System.EventHandler(this.cboCodes_SelectedIndexChanged);
            // 
            // lstDsec
            // 
            this.lstDsec.FormattingEnabled = true;
            this.lstDsec.Location = new System.Drawing.Point(19, 85);
            this.lstDsec.Name = "lstDsec";
            this.lstDsec.Size = new System.Drawing.Size(217, 95);
            this.lstDsec.TabIndex = 2;
            // 
            // lstFilters
            // 
            this.lstFilters.FormattingEnabled = true;
            this.lstFilters.Location = new System.Drawing.Point(334, 58);
            this.lstFilters.Name = "lstFilters";
            this.lstFilters.Size = new System.Drawing.Size(217, 121);
            this.lstFilters.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(253, 58);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = ">>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(253, 102);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "<<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(78, 198);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "שמור";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Text files (*.json)|";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(193, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "חפש";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtYeshuv
            // 
            this.txtYeshuv.AutoCompleteCustomSource.AddRange(new string[] {
            "aaa",
            "xxx",
            "vv"});
            this.txtYeshuv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtYeshuv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtYeshuv.Location = new System.Drawing.Point(274, 12);
            this.txtYeshuv.Name = "txtYeshuv";
            this.txtYeshuv.Size = new System.Drawing.Size(210, 20);
            this.txtYeshuv.TabIndex = 8;
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(16, 15);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(31, 13);
            this.lblFind.TabIndex = 9;
            this.lblFind.Text = "******";
            this.lblFind.Click += new System.EventHandler(this.lblFind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(490, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "בחר יישוב";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(476, 198);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "אישור";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // AddFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 237);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFind);
            this.Controls.Add(this.txtYeshuv);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstFilters);
            this.Controls.Add(this.lstDsec);
            this.Controls.Add(this.cboCodes);
            this.Controls.Add(this.button1);
            this.Name = "AddFilters";
            this.Text = "AddFilters";
            this.Load += new System.EventHandler(this.AddFilters_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboCodes;
        private System.Windows.Forms.ListBox lstDsec;
        private System.Windows.Forms.ListBox lstFilters;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtYeshuv;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;

    }
}