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
    public class ProjectController : ControllerBase
    {
        private IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;        
        }

        [HttpGet("{id}/employees")]
        public async Task<ActionResult<Project>> GetEmployeesFromProject(int id)
        {
            try
            {

                var result = await _projectRepository.GetEmployeesWorkingOnProject(id);

                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound("Project not found");


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving project");

            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Project>> GetSingleProject(int id)
        {
            try
            {

                var result = await _projectRepository.GetSingle(id);

                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound("Project not found");


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving project");

            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            try
            {
                var projectToDelete = await _projectRepository.GetSingle(id);

                if (projectToDelete != null)
                {
                    return await _projectRepository.Delete(id);
                }
                return NotFound("Project not found");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting project");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, Project updatedProject)
        {
            try
            {
                if (id != updatedProject.ProjectId)
                {
                    return BadRequest("Id:s doesn't match.");
                }

                var projectToUpdate = await _projectRepository.GetSingle(id);

                if (projectToUpdate != null)
                {
                    return await _projectRepository.Update(updatedProject);
                }
                return NotFound("Project not found");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating project");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Project>> AddProject(Project newProject)
        {
            try
            {

                if (newProject != null)
                {
                    var createdProject = await _projectRepository.Add(newProject);

                    return CreatedAtAction(nameof(GetSingleProject), new { id = createdProject.ProjectId }, createdProject);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding project");
            }
        }
    }
}
