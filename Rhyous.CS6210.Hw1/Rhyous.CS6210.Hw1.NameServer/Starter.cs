﻿using Rhyous.CS6210.Hw1.Interfaces;
using Rhyous.CS6210.Hw1.LogClient;
using Rhyous.CS6210.Hw1.Models;
using System;
using System.Threading.Tasks;

namespace Rhyous.CS6210.Hw1.NameServer
{
    internal class Starter
    {
        internal static ILogger Logger;
        internal static DynamicNameServer Ns;
        internal static async Task StartAsync(string name, string endpoint, string logServerName, bool useLocalhost)
        {
            Console.WriteLine($"{name}:{typeof(DynamicNameServer).Name}");
            Console.WriteLine(endpoint);
            Logger = new MultiLogger(
                //new LoggerClient(logServerName, name, endpoint),
                new ConsoleLogger()
            );
            Ns = new DynamicNameServer(name, Logger) { UseLocalHost = useLocalhost};
            await Ns.StartAsync(endpoint);
        }

        public class NsTask : Task
        {

            public NsTask(Action action) : base(action) { }
            public DynamicNameServer NameServer { get; set; } }
    }
}