using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WT.FleetDashboard.Services;

namespace WT.FleetDashboard.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriverService _driverService;
        public DriversController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _driverService.GetAllAsync());
        }

    }
}
