using System;
using System.Linq;
using System.Windows.Forms;

namespace MyWinFormsApp
{
    public partial class Form1 : Form
    {
        private DoublyLinkedList list = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            list.Create();
            UpdateOutput("Список створено.");
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            string? input = Prompt("Введіть числа через кому:");
            if (!string.IsNullOrWhiteSpace(input))
            {
                var numbers = input.Split(',')
                                   .Select(s => int.TryParse(s.Trim(), out var n) ? n : (int?)null)
                                   .Where(n => n.HasValue)
                                   .Select(n => n.Value)
                                   .ToArray();
                list.Initialize(numbers);
                UpdateOutput("Список ініціалізовано.");
            }
        }

        private void btnDeinitialize_Click(object sender, EventArgs e)
        {
            list.Deinitialize();
            UpdateOutput("Список деініціалізовано.");
        }

        private void btnDestroy_Click(object sender, EventArgs e)
        {
            list.Destroy();
            UpdateOutput("Список знищено.");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var input = ShowInputDialog("Введіть елемент для додавання:");
            if (input.HasValue)
            {
                list.Append(input.Value);
                UpdateOutput("Додано: " + input.Value);
            }
        }

        private void btnInsertBefore_Click(object sender, EventArgs e)
        {
            var target = ShowInputDialog("Перед яким елементом вставити?");
            var newVal = ShowInputDialog("Який елемент вставити?");
            if (target.HasValue && newVal.HasValue)
            {
                list.InsertBefore(target.Value, newVal.Value);
                UpdateOutput("Вставлено " + newVal.Value + " перед " + target.Value);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var input = ShowInputDialog("Який елемент видалити?");
            if (input.HasValue)
            {
                list.Remove(input.Value);
                UpdateOutput("Видалено: " + input.Value);
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            UpdateOutput("Перший елемент: " + (list.GetFirst()?.ToString() ?? "немає"));
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            UpdateOutput("Останній елемент: " + (list.GetLast()?.ToString() ?? "немає"));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            UpdateOutput("Список: " + list.PrintForward());
        }

        private int? ShowInputDialog(string prompt)
        {
            using var form = new InputForm(prompt);
            return form.ShowDialog() == DialogResult.OK ? form.InputValue : (int?)null;
        }

        private void UpdateOutput(string text)
        {
            txtOutput.Text = text + Environment.NewLine + list.PrintForward();
        }

        private string? Prompt(string message)
        {
            return Microsoft.VisualBasic.Interaction.InputBox(message, "Інпут");
        }
    }
}
