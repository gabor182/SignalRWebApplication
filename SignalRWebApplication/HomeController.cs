using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRWebApplication
{
    public class HomeController : Controller
    {
		private IHubContext<Chat> _hubContext;
		private Thread _workerThread;

		public HomeController(IHubContext<Chat> hubContext)
		{
			_hubContext = hubContext;
		}

        // GET: /<controller>/
        public string Index()
        {
			return "Index";
		}

		public string Start()
		{
			_workerThread = new Thread(WorkerThread)
			{
				Priority = ThreadPriority.Normal,
				IsBackground = true,
				Name = "AlarmSenderThread"
			};
			_workerThread.Start();

			return "WorkerThread started";
		}

		private async void WorkerThread()
		{
			int i = 0;
			while (true)
			{
				await _hubContext.Clients.All.InvokeAsync("Send", $"Alarm {++i}");
				Thread.Sleep(1000);
			}
		}
	}
}
