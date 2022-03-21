using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Networking_Chat_Client
{
    public partial class Chat : Form
    {
        //variables
        private static TcpClient Client;
        const int PORT = 5000;
        const string SERVER_IP = "10.156.26.55";

        public Chat()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try 
            {
                //create a TCPClient object at the IP and port
                Client = new TcpClient(SERVER_IP, PORT);

                //write console message
                Console.ForegroundColor = ConsoleColor.Green;
                if (Client.Connected) Console.WriteLine("Connected to server at IP: " + SERVER_IP);
                Console.ForegroundColor = ConsoleColor.White;

                Thread thread = new Thread(new ThreadStart(HandleRead));
                thread.Start();
            }
            catch (SocketException e44) 
            {
                DisplayErrorExit("No internet connection or incorrect ip adress");
            }
        }
        
        [DllImport("kernel32.dll")]
        private static extern void ExitProcess(int a);
        private static void ChatClient_Closing(object s, CancelEventArgs e)
        {
            e.Cancel = false;
            Application.Exit();
            ExitProcess(0);
        }

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            rtbx_chat.Text += value + "\n";
        }

        private void HandleRead()
        {
            try
            {
                //handle text sent from server
                StreamReader reader = new StreamReader(Client.GetStream());
                while (true) AppendTextBox(reader.ReadLine());
            } 
            catch(Exception e)
            {
                DisplayErrorExit("Lost connection to server");
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter(Client.GetStream());
            writer.WriteLine(tbx_input.Text);
            writer.Flush();
            tbx_input.Text = "";
        }

        private void DisplayErrorExit(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(DisplayErrorExit), new object[] { msg });
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
            Close();
            Thread.Sleep(5000);
            Application.Exit();
        }
    }
}
