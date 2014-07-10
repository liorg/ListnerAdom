namespace rssYnet
{
    partial class frmSearch
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(13, 23);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(58, 20);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "הוסף חיפוש";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstItems
            // 
            this.lstItems.FormattingEnabled = true;
            this.lstItems.Location = new System.Drawing.Point(24, 59);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(280, 186);
            this.lstItems.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Location = new System.Drawing.Point(24, 255);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(58, 39);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "אשר";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(77, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(227, 20);
            this.txtName.TabIndex = 3;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(97, 255);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(58, 39);
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "מחק";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 306);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.btnAdd);
            this.Name = "frmSearch";
            this.Text = "frmSearch";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnDel;
    }
}