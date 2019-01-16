namespace DirectoriesManager
{
    partial class CompareOptionsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RadioName = new System.Windows.Forms.RadioButton();
            this.RD_TotalSize = new System.Windows.Forms.RadioButton();
            this.RD_DateCreation = new System.Windows.Forms.RadioButton();
            this.RD_fullName = new System.Windows.Forms.RadioButton();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RadioName);
            this.groupBox3.Controls.Add(this.RD_TotalSize);
            this.groupBox3.Controls.Add(this.RD_DateCreation);
            this.groupBox3.Controls.Add(this.RD_fullName);
            this.groupBox3.Location = new System.Drawing.Point(2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(336, 40);
            this.groupBox3.TabIndex = 77;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Compare Options";
            // 
            // RadioName
            // 
            this.RadioName.AutoSize = true;
            this.RadioName.Location = new System.Drawing.Point(9, 15);
            this.RadioName.Name = "RadioName";
            this.RadioName.Size = new System.Drawing.Size(53, 17);
            this.RadioName.TabIndex = 0;
            this.RadioName.TabStop = true;
            this.RadioName.Text = "Name";
            this.RadioName.UseVisualStyleBackColor = true;
            this.RadioName.CheckedChanged += new System.EventHandler(this.RadioName_CheckedChanged);
            // 
            // RD_TotalSize
            // 
            this.RD_TotalSize.AutoSize = true;
            this.RD_TotalSize.Location = new System.Drawing.Point(249, 15);
            this.RD_TotalSize.Name = "RD_TotalSize";
            this.RD_TotalSize.Size = new System.Drawing.Size(72, 17);
            this.RD_TotalSize.TabIndex = 3;
            this.RD_TotalSize.TabStop = true;
            this.RD_TotalSize.Text = "Total Size";
            this.RD_TotalSize.UseVisualStyleBackColor = true;
            this.RD_TotalSize.CheckedChanged += new System.EventHandler(this.RD_TotalSize_CheckedChanged);
            // 
            // RD_DateCreation
            // 
            this.RD_DateCreation.AutoSize = true;
            this.RD_DateCreation.Location = new System.Drawing.Point(153, 15);
            this.RD_DateCreation.Name = "RD_DateCreation";
            this.RD_DateCreation.Size = new System.Drawing.Size(90, 17);
            this.RD_DateCreation.TabIndex = 2;
            this.RD_DateCreation.TabStop = true;
            this.RD_DateCreation.Text = "Date Creation";
            this.RD_DateCreation.UseVisualStyleBackColor = true;
            this.RD_DateCreation.CheckedChanged += new System.EventHandler(this.RD_DateCreation_CheckedChanged);
            // 
            // RD_fullName
            // 
            this.RD_fullName.AutoSize = true;
            this.RD_fullName.Location = new System.Drawing.Point(73, 15);
            this.RD_fullName.Name = "RD_fullName";
            this.RD_fullName.Size = new System.Drawing.Size(72, 17);
            this.RD_fullName.TabIndex = 1;
            this.RD_fullName.TabStop = true;
            this.RD_fullName.Text = "Full Name";
            this.RD_fullName.UseVisualStyleBackColor = true;
            this.RD_fullName.CheckedChanged += new System.EventHandler(this.RD_fullName_CheckedChanged);
            // 
            // CompareOptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBox3);
            this.Name = "CompareOptionsControl";
            this.Size = new System.Drawing.Size(340, 43);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton RadioName;
        private System.Windows.Forms.RadioButton RD_TotalSize;
        private System.Windows.Forms.RadioButton RD_DateCreation;
        private System.Windows.Forms.RadioButton RD_fullName;
    }
}
