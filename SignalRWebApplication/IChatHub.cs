using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRWebApplication
{
    public interface IChatHub
    {
		Task Send(string message);
    }
}
