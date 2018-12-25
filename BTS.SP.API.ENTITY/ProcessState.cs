using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY
{
    public enum ProcessState
    {
        IsPending = 0,
        IsComplete = 10,
        IsRunning = 20,
        IsError = 30,
        IsUnClosingOut = 40
    }
    public enum CodeProcess
    {
        KHOASO
    }
}
