using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HealthStabilizer.Data.Entities;
using HealthStabilizer.Services.Models.Diary;
using HealthStabilizer.Services.Services.DiaryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;

namespace HealthStabilizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DiaryController : ControllerBase
    {
        readonly IDiaryService _diaryService;
        readonly string _requestUserID;

        public DiaryController(IDiaryService foodService, IHttpContextAccessor httpContextAccessor)
        {
            //_logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            _diaryService = foodService;
            _requestUserID = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        }

        [HttpGet("")]
        public async Task<IActionResult> Get(DateTime? date)
        {
            try
            {
                var result = await _diaryService.GetAsync(_requestUserID,date);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetSum")]
        public IActionResult GetSum(DateTime? date)
        {
            try
            {
               var result = _diaryService.GetSumAsync(_requestUserID,date);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost("{date}")]
        public async Task<IActionResult> Post([FromBody] List<DiaryFoodDTO> foods, DateTime date)
        {
            try
            {
                await _diaryService.AddAsync(foods, _requestUserID, date);
                return Ok("Selected items added.");
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] DiaryFoodDTO model)
        {
            try
            {
                await _diaryService.UpdateQuantityAsync(id,model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            try
            {
                await _diaryService.DeleteAsync(id);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
    }
}