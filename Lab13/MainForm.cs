using System;
using System.IO;
using System.Windows.Forms;

namespace MyWinApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadDrives();
        }

        private void LoadDrives()
        {
            diskComboBox.Items.Clear();
            foreach (var drive in DriveInfo.GetDrives())
            {
                diskComboBox.Items.Add(drive.Name);
            }
        }

        private void diskComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (diskComboBox.SelectedItem == null) return;
            string path = diskComboBox.SelectedItem.ToString();
            LoadDirectories(path);
        }

        private void LoadDirectories(string path)
        {
            fileTreeView.Nodes.Clear();
            var root = new TreeNode(path);
            fileTreeView.Nodes.Add(root);
            LoadSubDirs(root);
        }

        private void LoadSubDirs(TreeNode node)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(node.FullPath);
                foreach (string dir in dirs)
                {
                    var subNode = new TreeNode(Path.GetFileName(dir));
                    subNode.Tag = dir;
                    node.Nodes.Add(subNode);
                }
            }
            catch { }
        }

        private void fileTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = e.Node.FullPath;
            fileListBox.Items.Clear();
            try
            {
                foreach (var file in Directory.GetFiles(path))
                {
                    fileListBox.Items.Add(Path.GetFileName(file));
                }
            }
            catch { }
        }

        private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fileListBox.SelectedItem == null || fileTreeView.SelectedNode == null) return;
            string path = Path.Combine(fileTreeView.SelectedNode.FullPath, fileListBox.SelectedItem.ToString());
            try
            {
                var fileInfo = new FileInfo(path);
                fileInfoBox.Text = $"Size: {fileInfo.Length} bytes\nCreated: {fileInfo.CreationTime}";

                if (Path.GetExtension(path).ToLower() == ".txt")
                {
                    textPreview.Text = File.ReadAllText(path);
                    imagePreview.Image = null;
                }
                else if (new[] { ".jpg", ".png", ".bmp" }.Contains(Path.GetExtension(path).ToLower()))
                {
                    imagePreview.Image = new System.Drawing.Bitmap(path);
                    textPreview.Text = "";
                }
                else
                {
                    imagePreview.Image = null;
                    textPreview.Text = "Непідтримуваний формат.";
                }
            }
            catch (Exception ex)
            {
                fileInfoBox.Text = "Помилка: " + ex.Message;
            }
        }
    }
}
