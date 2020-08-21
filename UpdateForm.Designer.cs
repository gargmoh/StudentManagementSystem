namespace studentfeemanagmentsystem
{
    partial class UpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.srchId = new System.Windows.Forms.TextBox();
            this.btnsrchupdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(179, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Student ID ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Student Id";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // srchId
            // 
            this.srchId.Location = new System.Drawing.Point(199, 109);
            this.srchId.Multiline = true;
            this.srchId.Name = "srchId";
            this.srchId.Size = new System.Drawing.Size(107, 20);
            this.srchId.TabIndex = 2;
            // 
            // btnsrchupdate
            // 
            this.btnsrchupdate.Image = ((System.Drawing.Image)(resources.GetObject("btnsrchupdate.Image")));
            this.btnsrchupdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsrchupdate.Location = new System.Drawing.Point(373, 109);
            this.btnsrchupdate.Name = "btnsrchupdate";
            this.btnsrchupdate.Size = new System.Drawing.Size(107, 29);
            this.btnsrchupdate.TabIndex = 11;
            this.btnsrchupdate.Text = "Update";
            this.btnsrchupdate.UseVisualStyleBackColor = true;
            this.btnsrchupdate.Click += new System.EventHandler(this.btnsrchupdate_Click);
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(501, 313);
            this.Controls.Add(this.btnsrchupdate);
            this.Controls.Add(this.srchId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UpdateForm";
            this.Text = "UpdateForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnsrchupdate;
        public System.Windows.Forms.TextBox srchId;
    }
}