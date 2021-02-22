using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WT.MobileWebService.Domain.Enums;

namespace WT.MobileWebService.Domain
{
    public sealed class CustomerInformation
    {
        public CustomerInformation()
        {
            EntityStatus = EntityStatus.IsNew;
            ActionDate = DateTime.UtcNow;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public EntityStatus EntityStatus { get; set; }
        public DateTime ActionDate { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser user { get; set; }
    }
}
