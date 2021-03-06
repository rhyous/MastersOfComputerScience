using Rhyous.CS6210.Hw1.Models;
using Rhyous.SimpleArgs;
using System;
using System.Collections.Generic;

namespace Rhyous.CS6210.Hw1.OutBreakAnalyzer.Arguments
{
    // Add this line of code to Main() in Program.cs
    //
    //   new ArgsManager<ArgsHandler>().Start(args);
    //

    /// <summary>
    /// A class that implements IArgumentsHandler where command line
    /// arguments are defined.
    /// </summary>
    public sealed class ArgsHandler : ArgsHandlerBase
    {
        public override void InitializeArguments(IArgsManager argsManager)
        {
            Arguments.AddRange(CommonArguments.Create("OutbreakAnalyzer", "5555"));
            Arguments.AddRange(new List<Argument>
            {
                new Argument
                {
                    Name = Constants.PublisherName,
                    ShortName = "pn",
                    Description = "The name of the publisher server.",
                    Example = "{name}=Publisher1",
                    DefaultValue = "Publisher1",
                    Action = (value) => { Console.WriteLine(value); }
                },
                new Argument
                {
                    Name = Constants.PublisherEndpoint,
                    ShortName = "p",
                    Description = "The endpoint for the server service.",
                    Example = "{name}=tcp://127.0.0.1:5556",
                    DefaultValue = "tcp://127.0.0.1:5556",
                    Action = (value) => { Console.WriteLine(value); }
                },
                new Argument
                {
                    Name = Constants.Disease,
                    ShortName = "d",
                    Description = "The disease this service analyzes.",
                    DefaultValue = "Influenza",
                    Example = "{name}=Influenza"
                },
                new Argument
                {
                    Name = Constants.Threshold,
                    ShortName = "t",
                    Description = "The number of diseases per day that indicate an outbreak.",
                    DefaultValue = "200",
                    Example = "{name}=200"
                }
            });
        }

        public override void HandleArgs(IReadArgs inArgsHandler)
        {
            var name = Args.Value(Constants.Name);
            if (string.IsNullOrWhiteSpace(name))
                name = Args.Value(Constants.Disease);
            Starter.StartAsync(name,
                               Args.Value(Constants.Endpoint),
                               Args.Value(Constants.PublisherName),
                               Args.Value(Constants.PublisherEndpoint),
                               Args.Value(Constants.NameServerEndpoint),
                               Args.Value(Constants.LoggerServerName)
                              ).Wait();            
        }
    }
}