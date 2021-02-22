using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WT.MobileWebService.Contract.V1;
using WT.MobileWebService.Contract.V1.Requests;
using WT.MobileWebService.Contract.V1.Responses;
using WT.MobileWebService.Domain;
using WT.MobileWebService.Extentions;
using WT.MobileWebService.Services;

namespace WT.MobileWebService.Controllers.V1
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CustomerInformationsController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerInformationService _customerInformationService;
        public CustomerInformationsController(IMapper mapper, ICustomerInformationService customerInformationService)
        {
            _mapper = mapper;
            _customerInformationService = customerInformationService;
        }

        /// <summary>
        /// Creates new customer in the system
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        ///
        ///     Post /api/v1/CustomerInformations
        ///
        /// </remarks>
        /// <param name="input"></param>
        /// <response code="401">The JWT is missing or incorrect.</response>  
        /// <response code="403">The authorization is missing a permission</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost(ApiRoutes.CustomerInformation.Create)]
        public async Task<IActionResult> Create([FromBody] CreateCustomerInformationRequest input)
        {
            var domainData = _mapper.Map<CustomerInformation>(input);
            domainData.UserId = HttpContext.GetUserId();
            await _customerInformationService.CreateAsync(domainData);
            return Ok(_mapper.Map<CreateCustomerInformationResponse>(domainData));
        }
    }
}
