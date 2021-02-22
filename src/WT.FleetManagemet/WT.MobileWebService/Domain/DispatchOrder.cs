using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WT.MobileWebService.Domain.Enums;

namespace WT.MobileWebService.Domain
{
    public sealed class DispatchOrder
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid DipatchId { get; set; }
        [ForeignKey(nameof(DipatchId))]
        public Dispatch Dispatch { get; set; }
        public Guid OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
