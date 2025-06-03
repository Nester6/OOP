namespace SimpleTextEditor
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ukrainianToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton leftToolStripButton;
        private System.Windows.Forms.ToolStripButton centerToolStripButton;
        private System.Windows.Forms.ToolStripButton rightToolStripButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            richTextBox1 = new System.Windows.Forms.RichTextBox { Dock = System.Windows.Forms.DockStyle.Fill };

            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ukrainianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            fileToolStripMenuItem.DropDownItems.AddRange(new[] {
                newToolStripMenuItem,
                openToolStripMenuItem,
                saveToolStripMenuItem
            });

            languageToolStripMenuItem.DropDownItems.AddRange(new[] {
                englishToolStripMenuItem,
                ukrainianToolStripMenuItem
            });

            menuStrip1.Items.AddRange(new[] {
                fileToolStripMenuItem,
                languageToolStripMenuItem
            });

            newToolStripMenuItem.Click += new System.EventHandler(newToolStripMenuItem_Click);
            openToolStripMenuItem.Click += new System.EventHandler(openToolStripMenuItem_Click);
            saveToolStripMenuItem.Click += new System.EventHandler(saveToolStripMenuItem_Click);
            englishToolStripMenuItem.Click += new System.EventHandler(englishToolStripMenuItem_Click);
            ukrainianToolStripMenuItem.Click += new System.EventHandler(ukrainianToolStripMenuItem_Click);

            toolStrip1 = new System.Windows.Forms.ToolStrip();
            leftToolStripButton = new System.Windows.Forms.ToolStripButton();
            centerToolStripButton = new System.Windows.Forms.ToolStripButton();
            rightToolStripButton = new System.Windows.Forms.ToolStripButton();

            leftToolStripButton.Click += new System.EventHandler(leftToolStripButton_Click);
            centerToolStripButton.Click += new System.EventHandler(centerToolStripButton_Click);
            rightToolStripButton.Click += new System.EventHandler(rightToolStripButton_Click);

            toolStrip1.Items.AddRange(new[] {
                leftToolStripButton,
                centerToolStripButton,
                rightToolStripButton
            });

            Controls.Add(richTextBox1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);

            MainMenuStrip = menuStrip1;
            Text = "Text Editor";
            Width = 800;
            Height = 600;
        }
    }
}
