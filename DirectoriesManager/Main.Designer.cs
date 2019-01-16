namespace DirectoriesManager
{
    partial class Main
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
            this.sideBareMenu1 = new DirectoriesManager.SideBareMenu();
            this.Pnl_Container = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // sideBareMenu1
            // 
            this.sideBareMenu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBareMenu1.Location = new System.Drawing.Point(0, 0);
            this.sideBareMenu1.MaximumSize = new System.Drawing.Size(45, 0);
            this.sideBareMenu1.MinimumSize = new System.Drawing.Size(45, 421);
            this.sideBareMenu1.Name = "sideBareMenu1";
            this.sideBareMenu1.Size = new System.Drawing.Size(45, 421);
            this.sideBareMenu1.TabIndex = 3;
            this.sideBareMenu1.OnMenuClicked += new System.EventHandler<DirectoriesManager.OnMenuClickedEventArgs>(this.OnMenuClicked);
            // 
            // Pnl_Container
            // 
            this.Pnl_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pnl_Container.Location = new System.Drawing.Point(45, 0);
            this.Pnl_Container.Name = "Pnl_Container";
            this.Pnl_Container.Size = new System.Drawing.Size(479, 421);
            this.Pnl_Container.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 421);
            this.Controls.Add(this.Pnl_Container);
            this.Controls.Add(this.sideBareMenu1);
            this.MinimumSize = new System.Drawing.Size(540, 460);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Directories Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private SideBareMenu sideBareMenu1;
        private System.Windows.Forms.Panel Pnl_Container;
    }
}

