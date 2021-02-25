﻿using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WT.FleetDashboard.DTOs;
using WT.FleetDashboard.Services;
using WT.MessageBrokers;

namespace WT.FleetDashboard.Infrastructure.MessageBroker.Handlers
{
    public class DriverCreatedHandler : IMessageHandler
    {
        private readonly IDriverService _driverService;
        public DriverCreatedHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }
        public async Task HandleMessageAsync(MessageReceivedEventArgs message)
        {
            var eventMessage = new EventMessage($"Id_{Guid.NewGuid():N}", Encoding.UTF8.GetString(message.Message.Body), DateTime.UtcNow);
            var driver = JsonSerializer.Deserialize<Driver>(message.Message.Body);
            await _driverService.InsertAsync(driver);
            
        }
    }
}
