using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthStabilizer.Data.Entities;
using HealthStabilizer.Services.Services.VitaminServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthStabilizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitaminController : ControllerBase
    {
        readonly IVitaminService _vitaminService;
        readonly NLog.ILogger _logger;


        public VitaminController(IVitaminService vitaminService)
        {
            _vitaminService = vitaminService;
            _logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _vitaminService.GetAsync());
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
                return Ok(await _vitaminService.GetAsync(id));
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return BadRequest(e.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Vitamin model)
        {
            try
            {
                await _vitaminService.AddAsync(model);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Vitamin model)
        {
            try
            {
                await _vitaminService.UpdateAsync(model);
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
                await _vitaminService.DeleteAsync(id);
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