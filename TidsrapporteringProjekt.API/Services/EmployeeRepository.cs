using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TidsrapporteringProjekt.API.Models;
using TidsrapporteringProjekt.Models;

namespace TidsrapporteringProjekt.API.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Employee> Add(Employee newEntity)
        {
            var result = await _appDbContext.Employees.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> Delete(int id)
        {
            var entityToDelete = await _appDbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);

            if (entityToDelete!=null)
            {
               _appDbContext.Employees.Remove(entityToDelete);
               await _appDbContext.SaveChangesAsync();
               return entityToDelete;
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> Update(Employee entity)
        {
            var employeeToUpdate = await _appDbContext.Employees.FirstOrDefaultAsync(e=>e.EmployeeId==entity.EmployeeId);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.Age = entity.Age;
                employeeToUpdate.EmployedDate = entity.EmployedDate;
                employeeToUpdate.FirstName = entity.FirstName;
                employeeToUpdate.Gender = entity.Gender;
                employeeToUpdate.JobTitle = entity.JobTitle;
                employeeToUpdate.LastName = entity.LastName;

                await _appDbContext.SaveChangesAsync();
                return employeeToUpdate;
            }
            return null;

        }

        public async Task<Employee> GetSingle(int id)
        {
            return await _appDbContext.Employees.Include(e=>e.TimeReports).ThenInclude(x=>x.Project).FirstOrDefaultAsync(x => x.EmployeeId == id);
        }
    }
}
