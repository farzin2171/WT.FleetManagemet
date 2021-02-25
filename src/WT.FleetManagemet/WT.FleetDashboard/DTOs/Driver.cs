using System;
using WT.FleetDashboard.DTOs.Enums;

namespace WT.FleetDashboard.DTOs
{
    public sealed class Driver
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public DriverStatus DriverStatus { get; set; }
    }
}
