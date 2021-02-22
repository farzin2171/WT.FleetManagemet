using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WT.MobileWebService.Domain.Enums;

namespace WT.MobileWebService.Domain
{
    public sealed class Dispatch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid DriverId { get; set; }
        [ForeignKey(nameof(DriverId))]
        public Driver Driver { get; set; }
        public DispatchStatus DispatchStatus { get; set; }
        public DateTime DispatchDate { get; set; }

        //Indicates syncronization status
        public EntityStatus EntityStatus { get; set; }
        //Indicates latest action date on entity
        public DateTime ActionDate { get; set; }
        

    }
}
