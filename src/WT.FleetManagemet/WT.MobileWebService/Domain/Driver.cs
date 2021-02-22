using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WT.MobileWebService.Domain.Enums;

namespace WT.MobileWebService.Domain
{
    public sealed class Driver
    {
        public Driver()
        {
            DriverStatus = DriverStatus.Ready;
            ActionDate = DateTime.UtcNow;
        }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public DriverStatus DriverStatus { get; set; }

        public EntityStatus EntityStatus { get; set; }
        public DateTime ActionDate { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser user { get; set; }
    }
}
