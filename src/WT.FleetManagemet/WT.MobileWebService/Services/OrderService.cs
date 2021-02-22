using System;
using System.Linq;
using System.Threading.Tasks;
using WT.MobileWebService.Data;
using WT.MobileWebService.Domain;
using WT.MobileWebService.Domain.Enums;
using WT.MobileWebService.Domain.Exceptions;

namespace WT.MobileWebService.Services
{
    public sealed class OrderService : IOrderService
    {
        private readonly DataContext _dataContext;
        private readonly IGenerateOrderRefrence _generateOrderRefrence;
        public OrderService(DataContext dataContext, IGenerateOrderRefrence generateOrderRefrence)
        {
            _dataContext = dataContext;
            _generateOrderRefrence = generateOrderRefrence;
        }
        public async Task<Order> CreateAsync(string customerEmail,string userId)
        {
            //ToDo:add new service to featch userId
            var customer = _dataContext.CustomerInformations.FirstOrDefault(c => c.Email.ToLower() == customerEmail.ToLower());
            if(customer==null)
            {
                throw new EntityNotFoundException("CustomerInformation", customerEmail);
            }
            var order = new Order
            {
                OrderRef = _generateOrderRefrence.Generate(),
                CustomerInformationId = customer.Id,
                OrderStatus = OrderStatus.Packed,
                OrderStatusDate = DateTime.UtcNow,
                UserId = userId
            };
            await _dataContext.Orders.AddAsync(order);
            await _dataContext.SaveChangesAsync();

            return order;
        }

        public async Task<Order> UpdateStatusAsync(string orderRef,OrderStatus orderStatus, string userId)
        {
            var order = _dataContext.Orders.FirstOrDefault(c => c.OrderRef == orderRef);
            if(order==null)
            {
                throw new EntityNotFoundException("CustomerInformation", orderRef);
            }
            if(order.OrderStatus==OrderStatus.Recived)
            {
                throw new NotAllowedException("order", "update", "recived");
            }
            order.OrderStatus = orderStatus;
            order.OrderStatusDate = DateTime.UtcNow;
            order.UserId = userId;

            await _dataContext.SaveChangesAsync();
            return order;
        }
    }
}
