namespace MyWinFormsApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Button btnDeinitialize;
        private System.Windows.Forms.Button btnDestroy;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnInsertBefore;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtOutput;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnCreate = new Button();
            this.btnInitialize = new Button();
            this.btnDeinitialize = new Button();
            this.btnDestroy = new Button();
            this.btnAdd = new Button();
            this.btnInsertBefore = new Button();
            this.btnRemove = new Button();
            this.btnFirst = new Button();
            this.btnLast = new Button();
            this.btnPrint = new Button();
            this.txtOutput = new TextBox();

            this.SuspendLayout();

            int y = 10;
            int height = 30;
            int spacing = 35;
            var buttons = new[]
            {
                (btnCreate, "Створити список"),
                (btnInitialize, "Ініціалізувати список"),
                (btnDeinitialize, "Деініціалізувати список"),
                (btnDestroy, "Знищити список"),
                (btnAdd, "Додати елемент у кінець"),
                (btnInsertBefore, "Вставити перед елементом"),
                (btnRemove, "Видалити елемент"),
                (btnFirst, "Перший елемент"),
                (btnLast, "Останній елемент"),
                (btnPrint, "Вивести список"),
            };

            foreach (var (btn, text) in buttons)
            {
                btn.Text = text;
                btn.Location = new System.Drawing.Point(10, y);
                btn.Size = new System.Drawing.Size(220, height);
                this.Controls.Add(btn);
                y += spacing;
            }

            btnCreate.Click += btnCreate_Click;
            btnInitialize.Click += btnInitialize_Click;
            btnDeinitialize.Click += btnDeinitialize_Click;
            btnDestroy.Click += btnDestroy_Click;
            btnAdd.Click += btnAdd_Click;
            btnInsertBefore.Click += btnInsertBefore_Click;
            btnRemove.Click += btnRemove_Click;
            btnFirst.Click += btnFirst_Click;
            btnLast.Click += btnLast_Click;
            btnPrint.Click += btnPrint_Click;

            this.txtOutput.Location = new System.Drawing.Point(240, 10);
            this.txtOutput.Multiline = true;
            this.txtOutput.ScrollBars = ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(530, 320);
            this.Controls.Add(this.txtOutput);

            this.ClientSize = new System.Drawing.Size(800, 350);
            this.Text = "Список (двозв’язний)";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
