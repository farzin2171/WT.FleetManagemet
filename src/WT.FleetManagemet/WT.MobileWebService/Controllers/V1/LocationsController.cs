using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WT.MobileWebService.Contract.V1;
using WT.MobileWebService.Contract.V1.Requests;
using WT.MobileWebService.Domain;

namespace WT.MobileWebService.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly List<Location> locations;
        public LocationsController()
        {
            locations = new List<Location>();
            for (int i = 0; i < 5; i++)
            {
                locations.Add(new Location
                {
                    Id = Guid.NewGuid(),
                    Lat = 1,
                    Lon = 1,
                });
            }
        }

        [HttpGet(ApiRoutes.Locations.GetByUserId)]
        public IActionResult GetByUserId([FromRoute] Guid userId,[FromRoute] DateTime startDate,[FromRoute] DateTime endDate)
        {
            return Ok(locations);
        }

        [HttpPost(ApiRoutes.Locations.Create)]
        public IActionResult Create([FromBody] CreateLocationRequest location)
        {
            return Ok();
        }
    }
}
