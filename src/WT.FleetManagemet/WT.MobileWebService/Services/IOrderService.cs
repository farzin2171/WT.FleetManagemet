using System;
using System.Threading.Tasks;
using WT.MobileWebService.Domain;
using WT.MobileWebService.Domain.Enums;

namespace WT.MobileWebService.Services
{
    public interface IOrderService
    {
        Task<Order> CreateAsync(Guid CustomerId);
        Task<Order> UpdateStatus(OrderStatus orderStatus);
    }
}
