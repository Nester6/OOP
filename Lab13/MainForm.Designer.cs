namespace MyWinApp
{
    partial class MainForm
    {
        private System.Windows.Forms.ComboBox diskComboBox;
        private System.Windows.Forms.TreeView fileTreeView;
        private System.Windows.Forms.ListBox fileListBox;
        private System.Windows.Forms.TextBox fileInfoBox;
        private System.Windows.Forms.PictureBox imagePreview;
        private System.Windows.Forms.RichTextBox textPreview;

        private void InitializeComponent()
        {
            this.diskComboBox = new ComboBox();
            this.fileTreeView = new TreeView();
            this.fileListBox = new ListBox();
            this.fileInfoBox = new TextBox();
            this.imagePreview = new PictureBox();
            this.textPreview = new RichTextBox();

            // === diskComboBox ===
            this.diskComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.diskComboBox.Location = new System.Drawing.Point(10, 10);
            this.diskComboBox.Width = 200;
            this.diskComboBox.SelectedIndexChanged += diskComboBox_SelectedIndexChanged;

            // === fileTreeView ===
            this.fileTreeView.Location = new System.Drawing.Point(10, 40);
            this.fileTreeView.Size = new System.Drawing.Size(200, 400);
            this.fileTreeView.AfterSelect += fileTreeView_AfterSelect;

            // === fileListBox ===
            this.fileListBox.Location = new System.Drawing.Point(220, 40);
            this.fileListBox.Size = new System.Drawing.Size(200, 200);
            this.fileListBox.SelectedIndexChanged += fileListBox_SelectedIndexChanged;

            // === fileInfoBox ===
            this.fileInfoBox.Location = new System.Drawing.Point(220, 250);
            this.fileInfoBox.Size = new System.Drawing.Size(200, 60);
            this.fileInfoBox.Multiline = true;
            this.fileInfoBox.ReadOnly = true;

            // === imagePreview ===
            this.imagePreview.Location = new System.Drawing.Point(430, 40);
            this.imagePreview.Size = new System.Drawing.Size(300, 200);
            this.imagePreview.SizeMode = PictureBoxSizeMode.Zoom;

            // === textPreview ===
            this.textPreview.Location = new System.Drawing.Point(430, 250);
            this.textPreview.Size = new System.Drawing.Size(300, 190);
            this.textPreview.ReadOnly = true;

            // === MainForm ===
            this.Text = "Файловий переглядач";
            this.ClientSize = new System.Drawing.Size(750, 460);
            this.Controls.Add(this.diskComboBox);
            this.Controls.Add(this.fileTreeView);
            this.Controls.Add(this.fileListBox);
            this.Controls.Add(this.fileInfoBox);
            this.Controls.Add(this.imagePreview);
            this.Controls.Add(this.textPreview);
        }
    }
}
