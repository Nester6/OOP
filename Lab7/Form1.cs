using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace MyWinApp
{
    public partial class Form1 : Form
    {
        private int docCounter = 1;

        public Form1()
        {
            InitializeComponent();
            IsMdiContainer = true; // Встановлюємо форму як MDI контейнер
            SetLanguage("uk");     // Початкова мова українська
        }

        private void newDocMenu_Click(object sender, EventArgs e)
        {
            var editor = new TextEditorForm
            {
                MdiParent = this,
                Text = $"{(Thread.CurrentThread.CurrentUICulture.Name == "uk" ? "Документ" : "Document")} {docCounter++}",
                Width = 800,
                Height = 600
            };
            editor.Show();
        }

        private void langEnMenu_Click(object sender, EventArgs e)
        {
            SetLanguage("en");
        }

        private void langUkMenu_Click(object sender, EventArgs e)
        {
            SetLanguage("uk");
        }

        private void SetLanguage(string langCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(langCode);

            if (langCode == "en")
            {
                fileMenu.Text = "File";
                newDocMenu.Text = "New Document";
                languageMenu.Text = "Language";
                langEnMenu.Text = "English";
                langUkMenu.Text = "Ukrainian";
                Text = "Text Editor - Main";
            }
            else if (langCode == "uk")
            {
                fileMenu.Text = "Файл";
                newDocMenu.Text = "Новий документ";
                languageMenu.Text = "Мова";
                langEnMenu.Text = "English";
                langUkMenu.Text = "Українська";
                Text = "Текстовий редактор - Головна";
            }
        }
    }

    // Окрема форма редактора — у тому ж файлі для простоти
    public class TextEditorForm : Form
    {
        private RichTextBox editor;
        private ToolStrip toolStrip;

        public TextEditorForm()
        {
            editor = new RichTextBox { Dock = DockStyle.Fill };
            Controls.Add(editor);

            toolStrip = new ToolStrip();

            var boldBtn = new ToolStripButton("Bold")
            {
                CheckOnClick = true
            };
            boldBtn.Click += (s, e) =>
            {
                var font = editor.SelectionFont;
                if (font != null)
                {
                    FontStyle newStyle = font.Style ^ FontStyle.Bold;
                    editor.SelectionFont = new Font(font, newStyle);
                }
            };

            var alignLeftBtn = new ToolStripButton("Ліворуч");
            alignLeftBtn.Click += (s, e) => editor.SelectionAlignment = HorizontalAlignment.Left;

            var alignCenterBtn = new ToolStripButton("По центру");
            alignCenterBtn.Click += (s, e) => editor.SelectionAlignment = HorizontalAlignment.Center;

            var alignRightBtn = new ToolStripButton("Праворуч");
            alignRightBtn.Click += (s, e) => editor.SelectionAlignment = HorizontalAlignment.Right;

            var fontBtn = new ToolStripButton("Шрифт");
            fontBtn.Click += (s, e) =>
            {
                using (var fontDialog = new FontDialog())
                {
                    if (fontDialog.ShowDialog() == DialogResult.OK)
                    {
                        editor.SelectionFont = fontDialog.Font;
                    }
                }
            };

            var saveBtn = new ToolStripButton("Зберегти");
            saveBtn.Click += (s, e) =>
            {
                using (var saveDialog = new SaveFileDialog() { Filter = "RTF Files|*.rtf" })
                {
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        editor.SaveFile(saveDialog.FileName);
                    }
                }
            };

            var openBtn = new ToolStripButton("Відкрити");
            openBtn.Click += (s, e) =>
            {
                using (var openDialog = new OpenFileDialog() { Filter = "RTF Files|*.rtf" })
                {
                    if (openDialog.ShowDialog() == DialogResult.OK)
                    {
                        editor.LoadFile(openDialog.FileName);
                    }
                }
            };

            toolStrip.Items.AddRange(new ToolStripItem[]
            {
                boldBtn,
                alignLeftBtn,
                alignCenterBtn,
                alignRightBtn,
                fontBtn,
                openBtn,
                saveBtn
            });

            toolStrip.Dock = DockStyle.Top;
            Controls.Add(toolStrip);

            Width = 800;
            Height = 600;
        }
    }
}
