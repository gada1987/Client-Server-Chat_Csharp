using System;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Drawing;

namespace Server
{
    class DoCommunicate
    {
        //variables
        string nickName = "";
        TcpClient client;
        StreamReader reader;
        StreamWriter writer;

        public DoCommunicate(TcpClient tcpClient)
        {
            client = tcpClient;
            Thread chatThread = new Thread(new ThreadStart(startChat));
            chatThread.Start();
        }

        private string GetNick()
        {
            writer.WriteLine("What is your nickname? ");
            writer.Flush();
            return reader.ReadLine();
        }

        private void startChat()
        {
            reader = new StreamReader(client.GetStream());
            writer = new StreamWriter(client.GetStream());
            writer.WriteLine("Welcome to PC Chat!");
            nickName = GetNick();

            //control if name exists
            while (ChatServer.NickNames.Contains(nickName))
            {
                writer.WriteLine("ERROR - Nickname already exists! Please try a new one");
                nickName = GetNick();
            }

            //add nickname to hashtables
            ChatServer.NickNames.Add(nickName, client);
            ChatServer.NickNamesByConnect.Add(client, nickName);
            //send messages
            ChatServer.SendSystemMessage("** " + nickName + " ** has joined the chat", client);
            writer.WriteLine($"Nickname: {nickName} \r\nNow Talkning... \r\n------------------");
            writer.Flush();
            //send old chat to new client
            foreach (var msg in ChatServer.MessagesSent)
            {
                writer.WriteLine(msg);
                writer.Flush();
            }
            
            Thread chatThread = new Thread(new ThreadStart(RunChat));
            chatThread.Start();
        }

        private void RunChat()
        {
            try
            {
                while(true)
                {
                    string msg = reader.ReadLine(); //get msg from client
                    ChatServer.SendMsgToAll(nickName, msg, client); //send msg to all clients
                }
            }
            catch(Exception e44)
            {
                ChatServer.PlayerDisconnect(client);
            }
        }
    }
}
