namespace UdpChat
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox chatTextBox;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.chatTextBox = new System.Windows.Forms.TextBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // userNameTextBox
            this.userNameTextBox.Location = new System.Drawing.Point(12, 12);
            this.userNameTextBox.Size = new System.Drawing.Size(120, 23);
            this.userNameTextBox.PlaceholderText = "Ім'я";

            // ipTextBox
            this.ipTextBox.Location = new System.Drawing.Point(150, 12);
            this.ipTextBox.Size = new System.Drawing.Size(110, 23);
            this.ipTextBox.Text = "235.5.5.1";

            // portTextBox
            this.portTextBox.Location = new System.Drawing.Point(270, 12);
            this.portTextBox.Size = new System.Drawing.Size(60, 23);
            this.portTextBox.Text = "8001";

            // loginButton
            this.loginButton.Location = new System.Drawing.Point(350, 10);
            this.loginButton.Size = new System.Drawing.Size(75, 25);
            this.loginButton.Text = "Увійти";
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);

            // logoutButton
            this.logoutButton.Location = new System.Drawing.Point(435, 10);
            this.logoutButton.Size = new System.Drawing.Size(75, 25);
            this.logoutButton.Text = "Вийти";
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);

            // chatTextBox
            this.chatTextBox.Location = new System.Drawing.Point(12, 45);
            this.chatTextBox.Multiline = true;
            this.chatTextBox.ScrollBars = ScrollBars.Vertical;
            this.chatTextBox.ReadOnly = true;
            this.chatTextBox.Size = new System.Drawing.Size(500, 250);

            // messageTextBox
            this.messageTextBox.Location = new System.Drawing.Point(12, 305);
            this.messageTextBox.Size = new System.Drawing.Size(400, 23);

            // sendButton
            this.sendButton.Location = new System.Drawing.Point(420, 304);
            this.sendButton.Size = new System.Drawing.Size(92, 25);
            this.sendButton.Text = "Надіслати";
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(524, 341);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.chatTextBox);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.sendButton);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Text = "UDP Чат";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
