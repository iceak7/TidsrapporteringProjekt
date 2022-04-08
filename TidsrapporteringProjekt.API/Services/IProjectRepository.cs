using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TidsrapporteringProjekt.Models;

namespace TidsrapporteringProjekt.API.Services
{
    public interface IProjectRepository : ITidsrapporteringProjekt<Project>
    {
        Task<IEnumerable<Employee>> GetEmployeesWorkingOnProject(int id);
    }
}
