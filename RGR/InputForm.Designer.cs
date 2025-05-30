namespace MyWinFormsApp
{
    partial class InputForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblPrompt;
        private TextBox txtInput;
        private Button btnOK;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblPrompt = new Label();
            this.txtInput = new TextBox();
            this.btnOK = new Button();
            this.SuspendLayout();

            // lblPrompt
            this.lblPrompt.Location = new System.Drawing.Point(12, 9);
            this.lblPrompt.Size = new System.Drawing.Size(260, 23);

            // txtInput
            this.txtInput.Location = new System.Drawing.Point(12, 35);
            this.txtInput.Size = new System.Drawing.Size(260, 23);

            // btnOK
            this.btnOK.Location = new System.Drawing.Point(105, 70);
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.Text = "OK";
            this.btnOK.Click += new EventHandler(this.btnOK_Click);

            // InputForm
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.lblPrompt);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnOK);
            this.Text = "Введення";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
