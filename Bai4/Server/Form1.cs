using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        TcpListener server = null;
        List<TcpClient> clients = new List<TcpClient>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            Thread serverThread = new Thread(StartServer);
            serverThread.Start();
            btnListen.Enabled = false;
        }

        private void StartServer()
        {
            server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            AppendMessage("Server started...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                clients.Add(client);
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int byteCount;

            while ((byteCount = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, byteCount);
                BroadcastMessage(message);
            }

            clients.Remove(client);
            client.Close();
        }

        private void BroadcastMessage(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);

            foreach (var client in clients)
            {
                try
                {
                    NetworkStream stream = client.GetStream();
                    stream.Write(buffer, 0, buffer.Length);
                }
                catch { }
            }

            AppendMessage(message);
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
