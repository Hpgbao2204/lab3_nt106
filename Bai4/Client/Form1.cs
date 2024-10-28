using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {

        TcpClient client;
        NetworkStream stream;

        public Form1()
        {
            InitializeComponent();
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = $"{txtUsername.Text}: {txtContentMessage.Text}";
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
            txtContentMessage.Clear();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client = new TcpClient("127.0.0.1", 5000);
            stream = client.GetStream();

            Thread receiveThread = new Thread(ReceiveMessage);
            receiveThread.Start();

            btnConnect.Enabled = false;
        }
        private void ReceiveMessage()
        {
            byte[] buffer = new byte[1024];
            int byteCount;

            while ((byteCount = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, byteCount);
                AppendMessage(message);
            }
        }

        private void AppendMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendMessage), message);
                return;
            }

            txtMessage.AppendText(message + Environment.NewLine);
        }
    }
}
