using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WT.MobileWebService.Domain;

namespace WT.MobileWebService.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
    }
}
