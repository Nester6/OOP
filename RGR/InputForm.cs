using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MyWinFormsApp
{
    public partial class InputForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int InputValue { get; private set; }

        public InputForm(string prompt)
        {
            InitializeComponent();
            lblPrompt.Text = prompt;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtInput.Text, out int val))
            {
                InputValue = val;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Введіть коректне ціле число.");
            }
        }
    }
}
