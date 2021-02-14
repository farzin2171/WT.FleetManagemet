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

namespace WT.MobileWebService.Controllers.V1
{
    [Consumes("application/json")]
    [Produces("application/json")]
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
        /// <summary>
        /// Accepet lates Vihecle location in the system
        /// </summary>
        /// <remarks>
        /// This will Insert the latest location.
        /// 
        /// Sample request:
        ///
        ///     Post /api/v1/Locations
        ///
        /// </remarks>
        /// <param name="location"></param>
        /// <response code="401">The JWT is missing or incorrect.</response>  
        /// <response code="403">The authorization is missing a permission</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost(ApiRoutes.Locations.Create)]
        public async Task<IActionResult> Create([FromBody] CreateLocationRequest location)
        {
            var domainLocation = _mapper.Map<Location>(location);
            domainLocation.UserId = HttpContext.GetUserId();
            await  _locationService.CreateAsync(domainLocation);
            return Ok(new CreateLocationResponse
            {
                Id=domainLocation.Id,
                Lat=domainLocation.Lat,
                Lon=domainLocation.Lon
            });
        }
    }
}
