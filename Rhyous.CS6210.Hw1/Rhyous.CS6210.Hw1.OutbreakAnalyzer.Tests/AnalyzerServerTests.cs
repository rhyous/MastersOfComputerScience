﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhyous.CS6210.Hw1.OutBreakAnalyzer;
using Moq;
using Rhyous.CS6210.Hw1.Interfaces;
using Rhyous.CS6210.Hw1.Models;
using System.Threading;

namespace Rhyous.CS6210.Hw1.OutbreakAnalyzer.Tests
{
    [TestClass]
    public class AnalyzerServerTests
    {
        [TestMethod]
        public void AnalyzerServerStartTests()
        {
            // Arrange
            var mockLogger = new Mock<ILogger>();
            mockLogger.Setup(l => l.WriteLine(It.IsAny<string>(), It.IsAny<VectorTimeStamp>()));
            var server = new AnalyzerServer("AS1", "", "", null);
            var mockSocket = new Mock<IReplySocket>();
            mockSocket.Setup(s => s.Bind(It.IsAny<string>()));
            server.Socket = mockSocket.Object;
            var record = new Record { Id = 1, Disease = 0, };
            
            // Act
            var task = server.StartAsync();
            Thread.Sleep(200);
            server.Stop();

            // Assert
            mockSocket.Verify(s => s.Bind(It.IsAny<string>()), Times.Once());
            mockSocket.Verify(s => s.Dispose(), Times.Once());
            mockLogger.Verify(s => s.WriteLine(It.IsAny<string>(), It.IsAny<VectorTimeStamp>()), Times.Once());
        }
    }
}