﻿using System;

namespace Rhyous.CS6210.Hw1.Interfaces
{
    public interface IPullSocket : IBind, IReceiveFrame, IDisposable
    {
    }
}