using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SimpleTextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ApplyLocalization();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog { Filter = "RTF files|*.rtf" };
            if (ofd.ShowDialog() == DialogResult.OK)
                richTextBox1.LoadFile(ofd.FileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SaveFileDialog sfd = new SaveFileDialog { Filter = "RTF files|*.rtf" };
            if (sfd.ShowDialog() == DialogResult.OK)
                richTextBox1.SaveFile(sfd.FileName);
        }

        private void leftToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void centerToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void rightToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("en");
        }

        private void ukrainianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeLanguage("uk");
        }

        private void ChangeLanguage(string lang)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            Controls.Clear();
            InitializeComponent();
            ApplyLocalization();
        }

        private void ApplyLocalization()
        {
            fileToolStripMenuItem.Text = GetText("File");
            newToolStripMenuItem.Text = GetText("New");
            openToolStripMenuItem.Text = GetText("Open");
            saveToolStripMenuItem.Text = GetText("Save");
            languageToolStripMenuItem.Text = GetText("Language");
            englishToolStripMenuItem.Text = "English";
            ukrainianToolStripMenuItem.Text = "Українська";

            leftToolStripButton.Text = GetText("Left");
            centerToolStripButton.Text = GetText("Center");
            rightToolStripButton.Text = GetText("Right");

            Text = GetText("Text Editor");
        }

        private string GetText(string key)
        {
            return Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName switch
            {
                "uk" => key switch
                {
                    "File" => "Файл",
                    "New" => "Новий",
                    "Open" => "Відкрити",
                    "Save" => "Зберегти",
                    "Language" => "Мова",
                    "Left" => "Ліворуч",
                    "Center" => "По центру",
                    "Right" => "Праворуч",
                    "Text Editor" => "Текстовий редактор",
                    _ => key
                },
                _ => key
            };
        }
    }
}
