namespace DirectoriesManager
{
    partial class CompareFoldersView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.COB = new DirectoriesManager.CompareOptionsControl();
            this.Txt_cmp_FolderToCompare = new System.Windows.Forms.TextBox();
            this.Txt_Cmp_src = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Btn_Compare = new System.Windows.Forms.Button();
            this.Btn_Reverse_Cmp = new System.Windows.Forms.Button();
            this.PB_Browes_FolderToCompaire = new System.Windows.Forms.PictureBox();
            this.PB_Browes_Src_Cmp = new System.Windows.Forms.PictureBox();
            this.Btn_Clear_Cmp = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.LB_outputCompare = new System.Windows.Forms.ListBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.OutputOptions = new System.Windows.Forms.GroupBox();
            this.RD_Matching = new System.Windows.Forms.RadioButton();
            this.RD_NonMatching = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.Btn_CopySelected = new System.Windows.Forms.Button();
            this.Btn_copyAll = new System.Windows.Forms.Button();
            this.Btn_Cmp_Clearoutput = new System.Windows.Forms.Button();
            this.Btn_Cmp_MoveSelected = new System.Windows.Forms.Button();
            this.Btn_Cmp_MoveAll = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Txt_Cmp_Destination = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.LblTotalCompareFound = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.PB_Browse_Destination = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Browes_FolderToCompaire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Browes_Src_Cmp)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.OutputOptions.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Browse_Destination)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 148);
            this.panel1.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label7);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(482, 148);
            this.panel9.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 23);
            this.label7.TabIndex = 56;
            this.label7.Text = "Compare folders";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.COB);
            this.panel10.Controls.Add(this.Txt_cmp_FolderToCompare);
            this.panel10.Controls.Add(this.Txt_Cmp_src);
            this.panel10.Controls.Add(this.label9);
            this.panel10.Controls.Add(this.label8);
            this.panel10.Controls.Add(this.panel4);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(0, 37);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(482, 111);
            this.panel10.TabIndex = 0;
            // 
            // COB
            // 
            this.COB.BackColor = System.Drawing.Color.Transparent;
            this.COB.Location = new System.Drawing.Point(11, 60);
            this.COB.Name = "COB";
            this.COB.SelectedCompareOption = System.IO.Expand.CompareOptions.Name;
            this.COB.Size = new System.Drawing.Size(346, 43);
            this.COB.TabIndex = 2;
            // 
            // Txt_cmp_FolderToCompare
            // 
            this.Txt_cmp_FolderToCompare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_cmp_FolderToCompare.Location = new System.Drawing.Point(129, 34);
            this.Txt_cmp_FolderToCompare.Name = "Txt_cmp_FolderToCompare";
            this.Txt_cmp_FolderToCompare.Size = new System.Drawing.Size(223, 20);
            this.Txt_cmp_FolderToCompare.TabIndex = 1;
            // 
            // Txt_Cmp_src
            // 
            this.Txt_Cmp_src.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Cmp_src.Location = new System.Drawing.Point(129, 6);
            this.Txt_Cmp_src.Name = "Txt_Cmp_src";
            this.Txt_Cmp_src.Size = new System.Drawing.Size(223, 20);
            this.Txt_Cmp_src.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 81;
            this.label9.Text = "Folder To Compare";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 80;
            this.label8.Text = "Source Folder";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Btn_Compare);
            this.panel4.Controls.Add(this.Btn_Reverse_Cmp);
            this.panel4.Controls.Add(this.PB_Browes_FolderToCompaire);
            this.panel4.Controls.Add(this.PB_Browes_Src_Cmp);
            this.panel4.Controls.Add(this.Btn_Clear_Cmp);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(361, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(121, 111);
            this.panel4.TabIndex = 0;
            // 
            // Btn_Compare
            // 
            this.Btn_Compare.Location = new System.Drawing.Point(37, 63);
            this.Btn_Compare.Name = "Btn_Compare";
            this.Btn_Compare.Size = new System.Drawing.Size(75, 23);
            this.Btn_Compare.TabIndex = 2;
            this.Btn_Compare.Text = "Compare";
            this.Btn_Compare.UseVisualStyleBackColor = true;
            // 
            // Btn_Reverse_Cmp
            // 
            this.Btn_Reverse_Cmp.Location = new System.Drawing.Point(37, 34);
            this.Btn_Reverse_Cmp.Name = "Btn_Reverse_Cmp";
            this.Btn_Reverse_Cmp.Size = new System.Drawing.Size(75, 23);
            this.Btn_Reverse_Cmp.TabIndex = 1;
            this.Btn_Reverse_Cmp.Text = "Reverse";
            this.Btn_Reverse_Cmp.UseVisualStyleBackColor = true;
            this.Btn_Reverse_Cmp.Click += new System.EventHandler(this.Btn_Reverse_Cmp_Click);
            // 
            // PB_Browes_FolderToCompaire
            // 
            this.PB_Browes_FolderToCompaire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PB_Browes_FolderToCompaire.Image = global::DirectoriesManager.Properties.Resources.browse_folder;
            this.PB_Browes_FolderToCompaire.Location = new System.Drawing.Point(6, 32);
            this.PB_Browes_FolderToCompaire.Name = "PB_Browes_FolderToCompaire";
            this.PB_Browes_FolderToCompaire.Size = new System.Drawing.Size(23, 23);
            this.PB_Browes_FolderToCompaire.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_Browes_FolderToCompaire.TabIndex = 73;
            this.PB_Browes_FolderToCompaire.TabStop = false;
            this.PB_Browes_FolderToCompaire.Click += new System.EventHandler(this.PB_Browes_Click);
            // 
            // PB_Browes_Src_Cmp
            // 
            this.PB_Browes_Src_Cmp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PB_Browes_Src_Cmp.Image = global::DirectoriesManager.Properties.Resources.browse_folder;
            this.PB_Browes_Src_Cmp.Location = new System.Drawing.Point(6, 5);
            this.PB_Browes_Src_Cmp.Name = "PB_Browes_Src_Cmp";
            this.PB_Browes_Src_Cmp.Size = new System.Drawing.Size(23, 23);
            this.PB_Browes_Src_Cmp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_Browes_Src_Cmp.TabIndex = 72;
            this.PB_Browes_Src_Cmp.TabStop = false;
            this.PB_Browes_Src_Cmp.Click += new System.EventHandler(this.PB_Browes_Click);
            // 
            // Btn_Clear_Cmp
            // 
            this.Btn_Clear_Cmp.Location = new System.Drawing.Point(37, 5);
            this.Btn_Clear_Cmp.Name = "Btn_Clear_Cmp";
            this.Btn_Clear_Cmp.Size = new System.Drawing.Size(75, 23);
            this.Btn_Clear_Cmp.TabIndex = 0;
            this.Btn_Clear_Cmp.Text = "Clear";
            this.Btn_Clear_Cmp.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 148);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(482, 227);
            this.panel2.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.LB_outputCompare);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(361, 227);
            this.panel8.TabIndex = 1;
            // 
            // LB_outputCompare
            // 
            this.LB_outputCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_outputCompare.FormattingEnabled = true;
            this.LB_outputCompare.Location = new System.Drawing.Point(12, 1);
            this.LB_outputCompare.Name = "LB_outputCompare";
            this.LB_outputCompare.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.LB_outputCompare.Size = new System.Drawing.Size(340, 225);
            this.LB_outputCompare.TabIndex = 67;
            this.LB_outputCompare.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LB_outputCompare_MouseDown);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(361, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(121, 227);
            this.panel5.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.OutputOptions);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(121, 67);
            this.panel7.TabIndex = 1;
            // 
            // OutputOptions
            // 
            this.OutputOptions.Controls.Add(this.RD_Matching);
            this.OutputOptions.Controls.Add(this.RD_NonMatching);
            this.OutputOptions.Location = new System.Drawing.Point(5, -2);
            this.OutputOptions.Name = "OutputOptions";
            this.OutputOptions.Size = new System.Drawing.Size(110, 63);
            this.OutputOptions.TabIndex = 77;
            this.OutputOptions.TabStop = false;
            this.OutputOptions.Text = "Output Options";
            // 
            // RD_Matching
            // 
            this.RD_Matching.AutoSize = true;
            this.RD_Matching.Location = new System.Drawing.Point(10, 40);
            this.RD_Matching.Name = "RD_Matching";
            this.RD_Matching.Size = new System.Drawing.Size(69, 17);
            this.RD_Matching.TabIndex = 1;
            this.RD_Matching.TabStop = true;
            this.RD_Matching.Text = "Matching";
            this.RD_Matching.UseVisualStyleBackColor = true;
            // 
            // RD_NonMatching
            // 
            this.RD_NonMatching.AutoSize = true;
            this.RD_NonMatching.Location = new System.Drawing.Point(10, 20);
            this.RD_NonMatching.Name = "RD_NonMatching";
            this.RD_NonMatching.Size = new System.Drawing.Size(92, 17);
            this.RD_NonMatching.TabIndex = 0;
            this.RD_NonMatching.TabStop = true;
            this.RD_NonMatching.Text = "Non Matching";
            this.RD_NonMatching.UseVisualStyleBackColor = true;
            this.RD_NonMatching.CheckedChanged += new System.EventHandler(this.RD_NonMatching_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.Btn_CopySelected);
            this.panel6.Controls.Add(this.Btn_copyAll);
            this.panel6.Controls.Add(this.Btn_Cmp_Clearoutput);
            this.panel6.Controls.Add(this.Btn_Cmp_MoveSelected);
            this.panel6.Controls.Add(this.Btn_Cmp_MoveAll);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 67);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(121, 160);
            this.panel6.TabIndex = 0;
            // 
            // Btn_CopySelected
            // 
            this.Btn_CopySelected.Location = new System.Drawing.Point(8, 37);
            this.Btn_CopySelected.Name = "Btn_CopySelected";
            this.Btn_CopySelected.Size = new System.Drawing.Size(98, 23);
            this.Btn_CopySelected.TabIndex = 1;
            this.Btn_CopySelected.Text = "Copy";
            this.Btn_CopySelected.UseVisualStyleBackColor = true;
            // 
            // Btn_copyAll
            // 
            this.Btn_copyAll.Location = new System.Drawing.Point(8, 65);
            this.Btn_copyAll.Name = "Btn_copyAll";
            this.Btn_copyAll.Size = new System.Drawing.Size(98, 23);
            this.Btn_copyAll.TabIndex = 2;
            this.Btn_copyAll.Text = "Copy All";
            this.Btn_copyAll.UseVisualStyleBackColor = true;
            // 
            // Btn_Cmp_Clearoutput
            // 
            this.Btn_Cmp_Clearoutput.Location = new System.Drawing.Point(8, 9);
            this.Btn_Cmp_Clearoutput.Name = "Btn_Cmp_Clearoutput";
            this.Btn_Cmp_Clearoutput.Size = new System.Drawing.Size(98, 23);
            this.Btn_Cmp_Clearoutput.TabIndex = 0;
            this.Btn_Cmp_Clearoutput.Text = "Clear";
            this.Btn_Cmp_Clearoutput.UseVisualStyleBackColor = true;
            // 
            // Btn_Cmp_MoveSelected
            // 
            this.Btn_Cmp_MoveSelected.Location = new System.Drawing.Point(8, 93);
            this.Btn_Cmp_MoveSelected.Name = "Btn_Cmp_MoveSelected";
            this.Btn_Cmp_MoveSelected.Size = new System.Drawing.Size(98, 23);
            this.Btn_Cmp_MoveSelected.TabIndex = 3;
            this.Btn_Cmp_MoveSelected.Text = "Move";
            this.Btn_Cmp_MoveSelected.UseVisualStyleBackColor = true;
            // 
            // Btn_Cmp_MoveAll
            // 
            this.Btn_Cmp_MoveAll.Location = new System.Drawing.Point(8, 121);
            this.Btn_Cmp_MoveAll.Name = "Btn_Cmp_MoveAll";
            this.Btn_Cmp_MoveAll.Size = new System.Drawing.Size(98, 23);
            this.Btn_Cmp_MoveAll.TabIndex = 4;
            this.Btn_Cmp_MoveAll.Text = "Move All";
            this.Btn_Cmp_MoveAll.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Txt_Cmp_Destination);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.panel12);
            this.panel3.Controls.Add(this.panel11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 375);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(482, 42);
            this.panel3.TabIndex = 1;
            // 
            // Txt_Cmp_Destination
            // 
            this.Txt_Cmp_Destination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Cmp_Destination.Location = new System.Drawing.Point(219, 12);
            this.Txt_Cmp_Destination.Name = "Txt_Cmp_Destination";
            this.Txt_Cmp_Destination.Size = new System.Drawing.Size(213, 20);
            this.Txt_Cmp_Destination.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(147, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 74;
            this.label11.Text = "Destination :";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.LblTotalCompareFound);
            this.panel12.Controls.Add(this.label10);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(118, 42);
            this.panel12.TabIndex = 1;
            // 
            // LblTotalCompareFound
            // 
            this.LblTotalCompareFound.AutoSize = true;
            this.LblTotalCompareFound.Location = new System.Drawing.Point(94, 15);
            this.LblTotalCompareFound.Name = "LblTotalCompareFound";
            this.LblTotalCompareFound.Size = new System.Drawing.Size(16, 13);
            this.LblTotalCompareFound.TabIndex = 70;
            this.LblTotalCompareFound.Text = "0 ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 69;
            this.label10.Text = "Total Found : ";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.PB_Browse_Destination);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(435, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(47, 42);
            this.panel11.TabIndex = 0;
            // 
            // PB_Browse_Destination
            // 
            this.PB_Browse_Destination.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PB_Browse_Destination.Image = global::DirectoriesManager.Properties.Resources.browse_folder;
            this.PB_Browse_Destination.Location = new System.Drawing.Point(4, 9);
            this.PB_Browse_Destination.Name = "PB_Browse_Destination";
            this.PB_Browse_Destination.Size = new System.Drawing.Size(23, 23);
            this.PB_Browse_Destination.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_Browse_Destination.TabIndex = 75;
            this.PB_Browse_Destination.TabStop = false;
            this.PB_Browse_Destination.Click += new System.EventHandler(this.PB_Browes_Click);
            // 
            // CompareFoldersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.MinimumSize = new System.Drawing.Size(482, 417);
            this.Name = "CompareFoldersView";
            this.Size = new System.Drawing.Size(482, 417);
            this.panel1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Browes_FolderToCompaire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Browes_Src_Cmp)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.OutputOptions.ResumeLayout(false);
            this.OutputOptions.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Browse_Destination)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button Btn_CopySelected;
        private System.Windows.Forms.Button Btn_copyAll;
        private System.Windows.Forms.Button Btn_Cmp_Clearoutput;
        private System.Windows.Forms.Button Btn_Cmp_MoveSelected;
        private System.Windows.Forms.Button Btn_Cmp_MoveAll;
        private System.Windows.Forms.GroupBox OutputOptions;
        private System.Windows.Forms.RadioButton RD_Matching;
        private System.Windows.Forms.RadioButton RD_NonMatching;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ListBox LB_outputCompare;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button Btn_Compare;
        private System.Windows.Forms.Button Btn_Reverse_Cmp;
        private System.Windows.Forms.PictureBox PB_Browes_FolderToCompaire;
        private System.Windows.Forms.PictureBox PB_Browes_Src_Cmp;
        private System.Windows.Forms.Button Btn_Clear_Cmp;
        private CompareOptionsControl COB;
        private System.Windows.Forms.TextBox Txt_cmp_FolderToCompare;
        private System.Windows.Forms.TextBox Txt_Cmp_src;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.PictureBox PB_Browse_Destination;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label LblTotalCompareFound;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Txt_Cmp_Destination;
        private System.Windows.Forms.Label label11;
    }
}
