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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "load helper";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboCodes
            // 
            this.cboCodes.FormattingEnabled = true;
            this.cboCodes.Location = new System.Drawing.Point(28, 24);
            this.cboCodes.Name = "cboCodes";
            this.cboCodes.Size = new System.Drawing.Size(217, 21);
            this.cboCodes.TabIndex = 1;
            this.cboCodes.SelectedIndexChanged += new System.EventHandler(this.cboCodes_SelectedIndexChanged);
            // 
            // lstDsec
            // 
            this.lstDsec.FormattingEnabled = true;
            this.lstDsec.Location = new System.Drawing.Point(28, 51);
            this.lstDsec.Name = "lstDsec";
            this.lstDsec.Size = new System.Drawing.Size(217, 95);
            this.lstDsec.TabIndex = 2;
            // 
            // lstFilters
            // 
            this.lstFilters.FormattingEnabled = true;
            this.lstFilters.Location = new System.Drawing.Point(343, 24);
            this.lstFilters.Name = "lstFilters";
            this.lstFilters.Size = new System.Drawing.Size(217, 121);
            this.lstFilters.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(262, 24);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = ">>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(262, 68);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "<<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(476, 161);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "שמור";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 253);
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

    }
}