using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TidsrapporteringProjekt.Models;
using TidsrapporteringProjekt.API.Models;
using Microsoft.EntityFrameworkCore;

namespace TidsrapporteringProjekt.API.Services
{
    public class ProjectRepository : IProjectRepository
    {
        private AppDbContext _appDbContext;
        public ProjectRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Project> Add(Project newEntity)
        {
            var result = await _appDbContext.Projects.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Project> Delete(int id)
        {
            var entityToDelete = await _appDbContext.Projects.FirstOrDefaultAsync(x => x.ProjectId == id);

            if (entityToDelete != null)
            {
                _appDbContext.Projects.Remove(entityToDelete);
                await _appDbContext.SaveChangesAsync();
                return entityToDelete;
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesWorkingOnProject(int id)
        {
            var result = _appDbContext.Employees.Include(e => e.ProjectEmployee).Where(e=>e.ProjectEmployee.FirstOrDefault(p=>p.ProjectId==id)!=null);

            if (result.Any())
            {
                return await result.ToListAsync();
            }
            return null;
        }

        public async Task<Project> GetSingle(int id)
        {
            return await _appDbContext.Projects.FirstOrDefaultAsync(x => x.ProjectId == id);
        }

        public async Task<Project> Update(Project entity)
        {
            var projectToUpdate = await _appDbContext.Projects.FirstOrDefaultAsync(e => e.ProjectId == entity.ProjectId);
            if (projectToUpdate != null)
            {
                projectToUpdate.IsActive = entity.IsActive;
                projectToUpdate.ProjectDescription = entity.ProjectDescription;
                projectToUpdate.ProjectName = entity.ProjectName;

                await _appDbContext.SaveChangesAsync();
                return projectToUpdate;
            }
            return null;
        }
    }
}
