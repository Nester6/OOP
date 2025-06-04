using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UdpChat
{
    public partial class Form1 : Form
    {
        private UdpClient client;
        private Thread receiveThread;

        private int localPort = 11000;
        private int remotePort = 11000;
        private string remoteIp = "127.0.0.1";

        public Form1()
        {
            InitializeComponent();

            client = new UdpClient(localPort);
            receiveThread = new Thread(ReceiveMessages);
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string message = textBoxMessage.Text;
            if (!string.IsNullOrWhiteSpace(message))
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                client.Send(data, data.Length, remoteIp, remotePort);
                AppendText("Я: " + message);
                textBoxMessage.Clear();
            }
        }

        private void ReceiveMessages()
        {
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, remotePort);
            while (true)
            {
                try
                {
                    byte[] data = client.Receive(ref remoteEP);
                    string message = Encoding.UTF8.GetString(data);
                    AppendText($"Від {remoteEP.Address}: {message}");
                }
                catch
                {
                    break;
                }
            }
        }

        private void AppendText(string text)
        {
            if (textBoxChat.InvokeRequired)
            {
                textBoxChat.Invoke(new Action<string>(AppendText), text);
            }
            else
            {
                textBoxChat.AppendText(text + Environment.NewLine);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            receiveThread?.Abort();
            client?.Close();
        }
    }
}
