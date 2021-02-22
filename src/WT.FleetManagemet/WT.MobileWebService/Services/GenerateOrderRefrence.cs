using System;
using System.Linq;
using WT.MobileWebService.Data;

namespace WT.MobileWebService.Services
{
    public sealed class GenerateOrderRefrence : IGenerateOrderRefrence
    {
        private readonly DataContext _dataContext;
        public GenerateOrderRefrence(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public string Generate()
        {
            var chars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm0123456789";
            var result = new char[12];
            var random = new Random();
            do
            {
                for (int i = 0; i < result.Length; i++)
                    result[i] = chars[random.Next(chars.Length)];
            } while (_dataContext.Orders.Any(x => x.OrderRef == new string(result)));

            return new string(result);
        }
    }
}
