using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthStabilizer.Data.Entities;
using HealthStabilizer.Services.Services.MineralServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthStabilizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MineralController : ControllerBase
    {
        readonly IMineralService _mineralService;
        readonly NLog.ILogger _logger;


        public MineralController(IMineralService mineralService)
        {
            _mineralService = mineralService;
            _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {

                return Ok(await _mineralService.GetAsync());
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
                return Ok(await _mineralService.GetAsync(id));
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return BadRequest(e.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Mineral model)
        {
            try
            {
                await _mineralService.AddAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Mineral model)
        {
            try
            {
                await _mineralService.UpdateAsync(model);
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
                await _mineralService.DeleteAsync(id);
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