using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WT.MobileWebService.Domain.Enums;

namespace WT.MobileWebService.Domain
{
    public sealed class Order
    {
        public Order()
        {
            OrderStatus = OrderStatus.Packed;
            OrderStatusDate = DateTime.UtcNow;

            EntityStatus = EntityStatus.IsNew;
            ActionDate = DateTime.UtcNow;
        }
        [Key]
        public Guid Id { get; set; }
        public string OrderRef { get; set; }
        public Guid CustomerInformationId { get; set; }

        [ForeignKey(nameof(CustomerInformationId))]
        public CustomerInformation CustomerInformation { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime OrderStatusDate { get; set; }

        //Indicates syncronization status
        public EntityStatus EntityStatus { get; set; }
        //Indicates latest action date on entity
        public DateTime ActionDate { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser user { get; set; }

    }
}
