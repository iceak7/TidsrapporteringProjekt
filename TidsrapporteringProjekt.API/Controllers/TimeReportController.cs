using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TidsrapporteringProjekt.API.Models;
using TidsrapporteringProjekt.API.Services;
using TidsrapporteringProjekt.Models;

namespace TidsrapporteringProjekt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeReportController : ControllerBase
    {
        private ITimeReportRepository _timeReportRepository;

        public TimeReportController(ITimeReportRepository timeReportRepository)
        {
            _timeReportRepository = timeReportRepository;
        }

        [HttpGet("employee/{id}/week/{weekNr}")]
        public async Task<ActionResult<WorkedHours>> WorkedHoursPerWeekAndEmployee(int id, int weekNr)
        {
            try
            {

                if (weekNr > 53)
                {
                    return BadRequest();
                }

                var result = await _timeReportRepository.WorkedHoursPerWeekandEmployee(id, weekNr);

                if (result == null)
                {
                    return BadRequest();
                }               
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving worked hours");
            }



        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TimeReport>> GetSingleTimeReport(int id)
        {
            try
            {

                var result = await _timeReportRepository.GetSingle(id);

                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound("Time report not found");


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving time report");

            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeReport>> DeleteTimeReport(int id)
        {
            try
            {
                var timeReportToDelete = await _timeReportRepository.GetSingle(id);

                if (timeReportToDelete != null)
                {
                    return await _timeReportRepository.Delete(id);
                }
                return NotFound("Time report not found");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting time report");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TimeReport>> UpdateTimeReport(int id, TimeReport updatedTimeReport)
        {
            try
            {
                if (id != updatedTimeReport.TimeReportId)
                {
                    return BadRequest("Id:s doesn't match.");
                }

                var timeReportToUpdate = await _timeReportRepository.GetSingle(id);

                if (timeReportToUpdate != null)
                {
                    return await _timeReportRepository.Update(updatedTimeReport);
                }
                return NotFound("Time report not found");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating time report");
            }
        }
        [HttpPost]
        public async Task<ActionResult<TimeReport>> AddTimeReport(TimeReport newTimeReport)
        {
            try
            {

                if (newTimeReport != null)
                {
                    var createdTimeReport = await _timeReportRepository.Add(newTimeReport);

                    return CreatedAtAction(nameof(GetSingleTimeReport), new { id = createdTimeReport.TimeReportId }, createdTimeReport);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding time report");
            }
        }


    }
}
