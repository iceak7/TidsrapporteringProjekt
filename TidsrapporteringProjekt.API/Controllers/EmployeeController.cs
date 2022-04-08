using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TidsrapporteringProjekt.API.Services;
using TidsrapporteringProjekt.Models;

namespace TidsrapporteringProjekt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                return Ok(await _employeeRepository.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving all employees");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetSingleEmployee(int id)
        {
            try
            {

                var result = await _employeeRepository.GetSingle(id);

                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound("Employee not found");


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving employee");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var employeeToDelete = await _employeeRepository.GetSingle(id);

                if (employeeToDelete != null)
                {
                    return await _employeeRepository.Delete(id);                
                }
                return NotFound("Employee not found");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting employee");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee updatedEmployee)
        {
            try
            {
                if(id != updatedEmployee.EmployeeId)
                {
                    return BadRequest("Id:s doesn't match.");
                }

                var employeeToUpdate = await _employeeRepository.GetSingle(id);

                if (employeeToUpdate != null)
                {
                    return await _employeeRepository.Update(updatedEmployee);
                }
                return NotFound("Employee not found");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating employee");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee newEmployee)
        {
            try
            {

                if (newEmployee != null)
                {
                    var createdEmployee = await _employeeRepository.Add(newEmployee);

                    return CreatedAtAction(nameof(GetSingleEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding employee");
            }
        }
    }
}
