using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRWebApplication
{
    public class Chat : Hub, IChatHub
    {
		public Task Send(string message)
		{
			if (Clients == null)
			{
				return Task.CompletedTask;
			}

			return Clients.All.InvokeAsync("Send", message);
		}
    }
}
