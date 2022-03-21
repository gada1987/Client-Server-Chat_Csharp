using System;
using System.IO;
using System.Net;
using System.Collections;
using System.Net.Sockets;
using System.Drawing;
using System.Collections.Generic;

namespace Server
{
    class ChatServer
    {
        //variables
        const int PORT = 5000;
        public static Hashtable NickNames;
        public static Hashtable NickNamesByConnect;
        public static List<string> MessagesSent = new List<string>();

        public ChatServer()
        {
            NickNames = new Hashtable(100);
            NickNamesByConnect = new Hashtable(100);

            //Listen at the specified IP and port no
            TcpListener server = new TcpListener(IPAddress.Any, PORT);
            //Start server
            server.Start();
            Console.WriteLine("Starting server...");

            while (true)
            {
                //Incoming client connected
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Client connected with IP: " + ((IPEndPoint)client.Client.RemoteEndPoint).Address);
                DoCommunicate communicate = new DoCommunicate(client);
            }
        }

        public static void SendMsgToAll(string nick, string msg, TcpClient sender = null)
        {
            StreamWriter writer;
            TcpClient[] tcpClients = new TcpClient[NickNames.Count];
            NickNames.Values.CopyTo(tcpClients, 0);
            MessagesSent.Add(nick + ": " + msg);

            //Loop trough all clients
            for (int i = 0; i < tcpClients.Length; i++)
            {
                try
                {
                    writer = new StreamWriter(tcpClients[i].GetStream());
                    //Control message
                    if (msg.Trim() == "" || tcpClients[i] == null) continue;
                    //Send message to stream
                    if(sender == tcpClients[i]) writer.WriteLine("Me: " + msg);
                    else writer.WriteLine(nick + ": " + msg);
                    //Reset
                    writer.Flush();
                    writer = null;
                }
                catch (Exception e44)
                {
                    PlayerDisconnect(tcpClients[i]);
                }
            }
        }

        public static void SendSystemMessage(string msg, TcpClient exceptionClient = null)
        {
            StreamWriter writer;
            TcpClient[] tcpClients = new TcpClient[NickNames.Count];
            NickNames.Values.CopyTo(tcpClients, 0);

            //Loop trough all clients
            for (int i = 0; i < tcpClients.Length; i++)
            {
                try
                {
                    writer = new StreamWriter(tcpClients[i].GetStream());
                    //Control message
                    if (exceptionClient == tcpClients[i]) continue;
                    if (msg.Trim() == "" || tcpClients[i] == null) continue;
                    //Send message to stream
                    writer.WriteLine(msg);
                    writer.Flush();
                    writer = null;
                }
                catch (Exception e44)
                {
                    PlayerDisconnect(tcpClients[i]);
                }
            }
        }

        public static void PlayerDisconnect(TcpClient client)
        {
            //temp save nick
            var nick = NickNamesByConnect[client];
            //Remove nick from hashtables
            NickNames.Remove(NickNamesByConnect[client]);
            NickNamesByConnect.Remove(client);

            SendSystemMessage($"** {nick} ** has left the chat");

            //write console message
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{nick} disconnected with IP: " +
                $"{((IPEndPoint)client.Client.RemoteEndPoint).Address}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
