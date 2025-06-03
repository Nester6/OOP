namespace MyWinApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem newDocMenu;
        private System.Windows.Forms.ToolStripMenuItem languageMenu;
        private System.Windows.Forms.ToolStripMenuItem langEnMenu;
        private System.Windows.Forms.ToolStripMenuItem langUkMenu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newDocMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.languageMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.langEnMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.langUkMenu = new System.Windows.Forms.ToolStripMenuItem();

            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.fileMenu,
                this.languageMenu
            });

            // File menu
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.newDocMenu
            });

            // Language menu
            this.languageMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.langEnMenu,
                this.langUkMenu
            });

            // Підключаємо обробники подій
            this.newDocMenu.Click += new System.EventHandler(this.newDocMenu_Click);
            this.langEnMenu.Click += new System.EventHandler(this.langEnMenu_Click);
            this.langUkMenu.Click += new System.EventHandler(this.langUkMenu_Click);

            // Додаємо меню на форму
            this.Controls.Add(this.menuStrip1);

            this.MainMenuStrip = this.menuStrip1;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();

            this.Text = "Text Editor";
            this.ClientSize = new System.Drawing.Size(800, 450);
        }
    }
}
