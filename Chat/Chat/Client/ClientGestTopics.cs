﻿using Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Chat;
using System.Collections;
using AuthentificationN;

namespace Client
{
    class ClientGestTopics : TCPClient, ITopicsManager
    {
        
        public ClientGestTopics(IPAddress Ip, int port) : base (Ip,port)
        {            
        }

        public void addUser(string login, string password)
        {
            Message request = new Message(new Header("Client", MessageType.ADD_USER), login + ";" + password);
            sendMessage(request);
        }
        public void removeUser(string login)
        {
            Message request = new Message(new Header("Client", MessageType.RM_USER), login);
            sendMessage(request);           
        }
        public void authentify(string login, string password)
        {
            Message request = new Message(new Header("Client", MessageType.AUTH_USER), login + ";" + password);
            sendMessage(request);
        }

        public void createTopic(string name)
        {
            Message request = new Message(new Header("Client", MessageType.CREATE_TOPIC), name);
            sendMessage(request);
        }
        public IChatroom joinTopic(string topic)
        {
            Message request = new Message(new Header("Client", MessageType.JOIN_TOPIC), topic);
            sendMessage(request);
            Message reply = getMessage();
            int port =  int.Parse(reply.data);
            ClientChatRoom ccr = new ClientChatRoom(Ip,port,topic);
            ccr.connect();
            return ccr;
        }
        public String listTopics()
        {
            Message request = new Message(new Header("Client", MessageType.LISTE_TOPICS), "");
            sendMessage(request);
            Message reply = getMessage();
            return reply.data;
        }

    }
    
}
