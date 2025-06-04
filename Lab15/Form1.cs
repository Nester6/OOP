using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace FTPClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(txtHost.Text);
                request.Credentials = new NetworkCredential(txtUser.Text, txtPass.Text);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    while (!reader.EndOfStream)
                    {
                        listBox1.Items.Add(reader.ReadLine());
                    }
                    MessageBox.Show(response.WelcomeMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = dialog.FileName;
                string fileName = Path.GetFileName(filePath);

                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(txtHost.Text + "/" + fileName);
                    request.Credentials = new NetworkCredential(txtUser.Text, txtPass.Text);
                    request.Method = WebRequestMethods.Ftp.UploadFile;

                    byte[] fileData = File.ReadAllBytes(filePath);
                    using (Stream reqStream = request.GetRequestStream())
                    {
                        reqStream.Write(fileData, 0, fileData.Length);
                    }

                    MessageBox.Show("Файл завантажено");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка: " + ex.Message);
                }
            }
        }

        private void btnCreateDir_Click(object sender, EventArgs e)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(txtHost.Text + "/" + txtNewDir.Text);
                request.Credentials = new NetworkCredential(txtUser.Text, txtPass.Text);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    MessageBox.Show("Каталог створено");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
    }
}
