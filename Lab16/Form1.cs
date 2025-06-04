using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UdpChat
{
    public partial class Form1 : Form
    {
        UdpClient client;
        const int TTL = 20;
        IPAddress groupAddress;
        bool alive = false;
        string userName = "";
        string logPath = "chat_log.txt";

        public Form1()
        {
            InitializeComponent();
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
            chatTextBox.ReadOnly = true;
            groupAddress = IPAddress.Parse("235.5.5.1");
            LoadSettings();
        }

        private void LoadSettings()
        {
            // Шрифт
            chatTextBox.Font = new Font("Segoe UI", 10);
            messageTextBox.Font = new Font("Segoe UI", 10);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                userName = userNameTextBox.Text;
                userNameTextBox.ReadOnly = true;
                client = new UdpClient(int.Parse(portTextBox.Text));
                client.JoinMulticastGroup(groupAddress, TTL);

                Task receiveTask = new Task(ReceiveMessages);
                receiveTask.Start();

                SendMessage(userName + " зайшов у чат");

                loginButton.Enabled = false;
                logoutButton.Enabled = true;
                sendButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void ReceiveMessages()
        {
            alive = true;
            try
            {
                while (alive)
                {
                    IPEndPoint remoteIp = null;
                    byte[] data = client.Receive(ref remoteIp);
                    string message = Encoding.Unicode.GetString(data);

                    this.Invoke(new MethodInvoker(() =>
                    {
                        string time = DateTime.Now.ToShortTimeString();
                        string formatted = $"{time} {message}\r\n";
                        chatTextBox.Text = formatted + chatTextBox.Text;
                        File.AppendAllText(logPath, formatted);
                    }));
                }
            }
            catch { }
        }

        private void SendMessage(string message)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            client.Send(data, data.Length, ipTextBox.Text, int.Parse(portTextBox.Text));
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(messageTextBox.Text))
            {
                SendMessage($"{userName}: {messageTextBox.Text}");
                messageTextBox.Clear();
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            ExitChat();
        }

        private void ExitChat()
        {
            if (client != null)
            {
                SendMessage(userName + " вийшов із чату");
                client.DropMulticastGroup(groupAddress);
                client.Close();
                alive = false;
            }

            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
            userNameTextBox.ReadOnly = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alive)
                ExitChat();
        }
    }
}
