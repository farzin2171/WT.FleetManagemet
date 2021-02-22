using AutoMapper;
using WT.MobileWebService.Contract.V1.Requests;
using WT.MobileWebService.Contract.V1.Responses;
using WT.MobileWebService.Domain;

namespace WT.MobileWebService.Mapping
{
    public class DomainToResponseProfile:Profile
    {
        
        public DomainToResponseProfile()
        {
            CreateMap<CreateLocationRequest, Location>();
            CreateMap<CreateCustomerInformationRequest, CustomerInformation>();
            CreateMap<CustomerInformation, CreateCustomerInformationResponse>();

        }
    }
}
