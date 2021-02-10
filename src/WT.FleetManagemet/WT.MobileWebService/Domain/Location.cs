using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WT.MobileWebService.Domain
{
    public class Location
    {
        public Location()
        {
            IsTransfered = false;
            RecivedDate = DateTime.UtcNow;
        }
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public DateTime RecivedDate { get; set; }
        public DateTime SampledDate { get; set; }
        public bool IsTransfered { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser user { get; set; }
    }
}
