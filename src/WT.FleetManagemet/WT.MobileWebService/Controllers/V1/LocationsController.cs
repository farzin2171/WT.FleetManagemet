using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WT.MobileWebService.Contract.V1;
using WT.MobileWebService.Contract.V1.Requests;
using WT.MobileWebService.Domain;

namespace WT.MobileWebService.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet(ApiRoutes.Locations.GetByUserId)]
        public IActionResult GetByUserId([FromRoute] Guid userId,[FromRoute] DateTime startDate,[FromRoute] DateTime endDate)
        {
            return Ok();
        }

        [HttpPost(ApiRoutes.Locations.Create)]
        public async Task<IActionResult> Create([FromBody] CreateLocationRequest location)
        {
           await  _locationService.CreateAsync(new Location
            {
                Lat = location.Lat,
                Lon = location.Lon,
                RecivedDate = DateTime.UtcNow
            });
            return Ok();
        }
    }
}
