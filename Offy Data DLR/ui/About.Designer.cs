namespace Offy.ui
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.pic_logo = new System.Windows.Forms.PictureBox();
            this.lbl_productName = new System.Windows.Forms.Label();
            this.lbl_version = new System.Windows.Forms.Label();
            this.lbl_copyR = new System.Windows.Forms.Label();
            this.lbl_doneBy = new System.Windows.Forms.Label();
            this.lbl_link = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_logo
            // 
            this.pic_logo.Image = global::Offy.Properties.Resources.offy_data_dlr;
            this.pic_logo.Location = new System.Drawing.Point(12, 12);
            this.pic_logo.Name = "pic_logo";
            this.pic_logo.Size = new System.Drawing.Size(100, 100);
            this.pic_logo.TabIndex = 0;
            this.pic_logo.TabStop = false;
            // 
            // lbl_productName
            // 
            this.lbl_productName.AutoSize = true;
            this.lbl_productName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_productName.Location = new System.Drawing.Point(130, 12);
            this.lbl_productName.Name = "lbl_productName";
            this.lbl_productName.Size = new System.Drawing.Size(41, 13);
            this.lbl_productName.TabIndex = 1;
            this.lbl_productName.Text = "label1";
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.Location = new System.Drawing.Point(130, 25);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(35, 13);
            this.lbl_version.TabIndex = 2;
            this.lbl_version.Text = "label2";
            // 
            // lbl_copyR
            // 
            this.lbl_copyR.AutoSize = true;
            this.lbl_copyR.Location = new System.Drawing.Point(130, 59);
            this.lbl_copyR.Name = "lbl_copyR";
            this.lbl_copyR.Size = new System.Drawing.Size(35, 13);
            this.lbl_copyR.TabIndex = 3;
            this.lbl_copyR.Text = "label3";
            // 
            // lbl_doneBy
            // 
            this.lbl_doneBy.AutoSize = true;
            this.lbl_doneBy.Location = new System.Drawing.Point(130, 79);
            this.lbl_doneBy.Name = "lbl_doneBy";
            this.lbl_doneBy.Size = new System.Drawing.Size(35, 13);
            this.lbl_doneBy.TabIndex = 4;
            this.lbl_doneBy.Text = "label4";
            // 
            // lbl_link
            // 
            this.lbl_link.AutoSize = true;
            this.lbl_link.Location = new System.Drawing.Point(130, 99);
            this.lbl_link.Name = "lbl_link";
            this.lbl_link.Size = new System.Drawing.Size(55, 13);
            this.lbl_link.TabIndex = 5;
            this.lbl_link.TabStop = true;
            this.lbl_link.Text = "linkLabel1";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(414, 126);
            this.Controls.Add(this.lbl_link);
            this.Controls.Add(this.lbl_doneBy);
            this.Controls.Add(this.lbl_copyR);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.lbl_productName);
            this.Controls.Add(this.pic_logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_logo;
        private System.Windows.Forms.Label lbl_productName;
        private System.Windows.Forms.Label lbl_version;
        private System.Windows.Forms.Label lbl_copyR;
        private System.Windows.Forms.Label lbl_doneBy;
        private System.Windows.Forms.LinkLabel lbl_link;
    }
}