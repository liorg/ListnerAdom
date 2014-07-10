namespace rssYnet
{
    partial class RssEventSearch
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
            this.txtTS = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnExcute = new System.Windows.Forms.Button();
            this.listBox1 = new ImprovedListBox();
            this.SuspendLayout();
            // 
            // txtTS
            // 
            this.txtTS.Location = new System.Drawing.Point(560, 51);
            this.txtTS.Name = "txtTS";
            this.txtTS.Size = new System.Drawing.Size(161, 20);
            this.txtTS.TabIndex = 7;
            this.txtTS.TabStop = false;
            this.txtTS.Text = "2";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(462, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(259, 20);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.Text = " אזעקה + גוש דן +אזעקת";
            // 
            // btnExcute
            // 
            this.btnExcute.Location = new System.Drawing.Point(316, 79);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(144, 32);
            this.btnExcute.TabIndex = 8;
            this.btnExcute.Text = "הפעל";
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // listBox1
            // 
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 117);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(710, 134);
            this.listBox1.TabIndex = 5;
            // 
            // RssEventSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 260);
            this.Controls.Add(this.btnExcute);
            this.Controls.Add(this.txtTS);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.listBox1);
            this.Name = "RssEventSearch";
            this.Text = "RssEventSearch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImprovedListBox listBox1;
        private System.Windows.Forms.TextBox txtTS;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnExcute;

    }
}