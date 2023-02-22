using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HealthStabilizer.Data.Entities;
using HealthStabilizer.Services.Services.FoodServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthStabilizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FoodController : ControllerBase
    {
        readonly IFoodService _foodService;
        readonly NLog.ILogger _logger;
        readonly string _requestUserID;

        public FoodController(IFoodService foodService, IHttpContextAccessor httpContextAccessor)
        {
            _requestUserID = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            _foodService = foodService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _foodService.GetAsync(_requestUserID));
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            try
            {
                return Ok(await _foodService.GetAsync(id));
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Food model)
        {
            try
            {
                await _foodService.AddAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Food model)
        {
            try
            {
                await _foodService.UpdateAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _foodService.GetAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}