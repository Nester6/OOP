namespace FTPClient
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtHost, txtUser, txtPass, txtNewDir;
        private System.Windows.Forms.Button btnConnect, btnUpload, btnCreateDir;
        private System.Windows.Forms.ListBox listBox1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtNewDir = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnCreateDir = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();

            // txtHost
            this.txtHost.Location = new System.Drawing.Point(12, 12);
            this.txtHost.Size = new System.Drawing.Size(200, 20);
            this.txtHost.Text = "ftp://127.0.0.1/";

            // txtUser
            this.txtUser.Location = new System.Drawing.Point(220, 12);
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.Text = "user";

            // txtPass
            this.txtPass.Location = new System.Drawing.Point(330, 12);
            this.txtPass.Size = new System.Drawing.Size(100, 20);
            this.txtPass.PasswordChar = '*';
            this.txtPass.Text = "pass";

            // btnConnect
            this.btnConnect.Location = new System.Drawing.Point(440, 10);
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.Text = "Підключитись";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);

            // listBox1
            this.listBox1.Location = new System.Drawing.Point(12, 40);
            this.listBox1.Size = new System.Drawing.Size(500, 150);

            // btnUpload
            this.btnUpload.Location = new System.Drawing.Point(12, 200);
            this.btnUpload.Size = new System.Drawing.Size(100, 23);
            this.btnUpload.Text = "Завантажити файл";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);

            // txtNewDir
            this.txtNewDir.Location = new System.Drawing.Point(120, 202);
            this.txtNewDir.Size = new System.Drawing.Size(150, 20);
            this.txtNewDir.Text = "new_folder";

            // btnCreateDir
            this.btnCreateDir.Location = new System.Drawing.Point(280, 200);
            this.btnCreateDir.Size = new System.Drawing.Size(100, 23);
            this.btnCreateDir.Text = "Створити каталог";
            this.btnCreateDir.Click += new System.EventHandler(this.btnCreateDir_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(530, 240);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.txtNewDir);
            this.Controls.Add(this.btnCreateDir);
            this.Text = "FTP Клієнт";
        }
    }
}
