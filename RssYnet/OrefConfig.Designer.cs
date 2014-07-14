namespace rssYnet
{
    partial class OrefConfig
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
            this.btnOk = new System.Windows.Forms.Button();
            this.ddInterval = new System.Windows.Forms.DomainUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRss = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(131, 128);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 41);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "אישור";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ddInterval
            // 
            this.ddInterval.Items.Add("1");
            this.ddInterval.Items.Add("2");
            this.ddInterval.Items.Add("3");
            this.ddInterval.Items.Add("4");
            this.ddInterval.Items.Add("5");
            this.ddInterval.Items.Add("6");
            this.ddInterval.Items.Add("7");
            this.ddInterval.Items.Add("8");
            this.ddInterval.Items.Add("9");
            this.ddInterval.Items.Add("10");
            this.ddInterval.Items.Add("15");
            this.ddInterval.Items.Add("20");
            this.ddInterval.Items.Add("25");
            this.ddInterval.Items.Add("30");
            this.ddInterval.Items.Add("35");
            this.ddInterval.Location = new System.Drawing.Point(98, 23);
            this.ddInterval.Name = "ddInterval";
            this.ddInterval.Size = new System.Drawing.Size(120, 20);
            this.ddInterval.TabIndex = 1;
            this.ddInterval.Text = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "זמני קריאה";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "עורך כתובת";
            // 
            // txtRss
            // 
            this.txtRss.Location = new System.Drawing.Point(98, 64);
            this.txtRss.Name = "txtRss";
            this.txtRss.Size = new System.Drawing.Size(215, 20);
            this.txtRss.TabIndex = 2;
            // 
            // OrefConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 181);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRss);
            this.Controls.Add(this.ddInterval);
            this.Controls.Add(this.btnOk);
            this.Name = "OrefConfig";
            this.Text = "Config";
            this.Load += new System.EventHandler(this.Config_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DomainUpDown ddInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRss;
    }
}