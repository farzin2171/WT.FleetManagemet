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
    public class DriversController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDriverService _driverService;

        public DriversController(IMapper mapper, IDriverService driverService)
        {
            _mapper = mapper;
            _driverService = driverService;
        }

        /// <summary>
        /// Creates new driver in the system
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        ///
        ///     Post /api/v1/drivers
        ///
        /// </remarks>
        /// <param name="input"></param>
        /// <response code="401">The JWT is missing or incorrect.</response>  
        /// <response code="403">The authorization is missing a permission</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost(ApiRoutes.Drivers.Create)]
        public async Task<IActionResult> Create([FromBody] CreateDriverRequest input)
        {
            var domainData = _mapper.Map<Driver>(input);
            domainData.UserId = HttpContext.GetUserId();
            var driver = await _driverService.CreateAsync(domainData);
            return Ok(_mapper.Map<CreateDriverResponse>(driver));
        }

        /// <summary>
        /// Update  driver status in the system
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        ///
        ///     Post /api/v1/drivers/driverPhone/{driverPhone}/driverStatus/{driverStatus}
        ///
        /// </remarks>
        /// <param name="driverPhone"></param>
        /// <param name="driverStatus"></param>
        /// <response code="401">The JWT is missing or incorrect.</response>  
        /// <response code="403">The authorization is missing a permission</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPatch(ApiRoutes.Drivers.UpdateStatus)]
        public async Task<IActionResult> UpdateStatus([FromRoute] string driverPhone,[FromRoute]string driverStatus)
        {
            await _driverService.UpdateStatus(driverStatus,driverPhone);
            return Ok();
        }
    }
}
