using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WT.MobileWebService.Contract.V1;
using WT.MobileWebService.Contract.V1.Requests;
using WT.MobileWebService.Domain;
using WT.MobileWebService.Extentions;

namespace WT.MobileWebService.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;
        public LocationsController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Locations.GetByUserId)]
        [Authorize(Policy = "commandCeneter.admin")]
        public IActionResult GetByUserId([FromRoute] Guid userId,[FromRoute] DateTime startDate,[FromRoute] DateTime endDate)
        {
            return Ok();
        }

        [HttpPost(ApiRoutes.Locations.Create)]
        public async Task<IActionResult> Create([FromBody] CreateLocationRequest location)
        {
            var domainLocation = _mapper.Map<Location>(location);
            domainLocation.UserId = HttpContext.GetUserId();
            await  _locationService.CreateAsync(domainLocation);
            return Ok();
        }
    }
}
