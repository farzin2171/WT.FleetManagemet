using System;
using System.Threading.Tasks;
using WT.MobileWebService.Domain;
using WT.MobileWebService.Domain.Enums;

namespace WT.MobileWebService.Services
{
    public interface IOrderService
    {
        Task<Order> CreateAsync(string customerEmail,string userId);
        Task<Order> UpdateStatusAsync(string orderRef,OrderStatus orderStatus,string userId);
    }
}
