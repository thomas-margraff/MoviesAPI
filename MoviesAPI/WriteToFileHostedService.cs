﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MoviesAPI
{
    public class WriteToFileHostedService : IHostedService
    {
        private readonly IWebHostEnvironment env;
        private readonly string fileName = "File1.txt";
        private Timer timer;
        public WriteToFileHostedService(IWebHostEnvironment env)
        {
            this.env = env;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            WriteToFile("Process Started");
            return Task.CompletedTask;
        }
        private void DoWork(object state)
        {
            WriteToFile("Process Ongoing:" + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            WriteToFile("Process Stopped");
            return Task.CompletedTask;

        }

        private void WriteToFile(string message)
        {
            var path = $@"{env.ContentRootPath}\wwwroot\{fileName}";
            using (StreamWriter writer = new StreamWriter(path, append: true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
