namespace StoreMgmtSystem
{
    partial class Guide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Guide));
            this.txtHuongDan = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtHuongDan
            // 
            this.txtHuongDan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHuongDan.Location = new System.Drawing.Point(26, 25);
            this.txtHuongDan.Multiline = true;
            this.txtHuongDan.Name = "txtHuongDan";
            this.txtHuongDan.ReadOnly = true;
            this.txtHuongDan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHuongDan.Size = new System.Drawing.Size(346, 297);
            this.txtHuongDan.TabIndex = 0;
            this.txtHuongDan.Text = resources.GetString("txtHuongDan.Text");
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(165, 328);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Guide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 358);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtHuongDan);
            this.Name = "Guide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hướng dẫn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHuongDan;
        private System.Windows.Forms.Button btnOK;
    }
}