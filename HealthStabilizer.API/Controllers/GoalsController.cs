using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HealthStabilizer.Data;
using HealthStabilizer.Data.Entities;
using HealthStabilizer.Services.Services.GoalsServices;
using HealthStabilizer.Services.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthStabilizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {

        readonly IGoalsService _goalsService;
        readonly UserService _userService;
        readonly NLog.ILogger _logger;
        string _requestUserID;


        public GoalsController(IGoalsService goalsService, IHttpContextAccessor httpContextAccessor, DBContext context)
        {
            _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            _goalsService = goalsService;
            _requestUserID = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _userService = new UserService(context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _goalsService.GetAsync(_requestUserID);
                if (result is null)
                    return BadRequest();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return BadRequest(e.Message);
            }
        }


        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Goals model)
        {
            try
            {
                model.ForUserId = _requestUserID;
                await _goalsService.AddAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Goals model)
        {
            try
            {
                if (!ModelState.IsValid || String.IsNullOrEmpty(_requestUserID) || id <= 0)
                    return BadRequest();

                if ((await _goalsService.GetAsync(_requestUserID)).GoalsId != id)
                    return BadRequest();


                model.ForUserId = _requestUserID;
                await _goalsService.UpdateAsync(model);

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
                await _goalsService.DeleteAsync(id);
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
