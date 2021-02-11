using AutoMapper;
using Microsoft.AspNetCore.Http;
using WT.MobileWebService.Contract.V1.Requests;
using WT.MobileWebService.Domain;
using WT.MobileWebService.Extentions;

namespace WT.MobileWebService.Mapping
{
    public class DomainToResponseProfile:Profile
    {
        
        public DomainToResponseProfile()
        {
            CreateMap<CreateLocationRequest, Location>();
        }
    }
}
