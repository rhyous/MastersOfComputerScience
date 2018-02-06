﻿using Rhyous.CS6210.Hw1.Interfaces;
using Rhyous.CS6210.Hw1.Models;
using ZeroMQ;

namespace Rhyous.CS6210.Hw1.LogClient
{
    public class LoggerClient : ILogger
    {
        public string LogServerEndpoint { get; }
        public string ClientName { get; }
        public SendClient SendClient { get; }

        internal bool IsConnected { get; set; }

        public LoggerClient(string logServerEndpoint, string clientName)
        {
            LogServerEndpoint = logServerEndpoint;
            ClientName = clientName;
            SendClient = new SendClient();
        }
        
        public void WriteLine(string message)
        {
            if (!IsConnected)
            {
                SendClient.Connect(LogServerEndpoint, ZSocketType.PUSH);
                IsConnected = true;
            }
            SendClient.Send($"{ClientName}: {message}");
        }

        public void WriteLine(string message, IVectorTimeStamp vts)
        {
            if (!IsConnected)
            {
                SendClient.Connect(LogServerEndpoint, ZSocketType.PUSH);
                IsConnected = true;
            }
            SendClient.Send($"{ClientName}:{vts}: {message}");
        }
    }
}