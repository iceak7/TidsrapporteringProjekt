using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TidsrapporteringProjekt.Models;

namespace TidsrapporteringProjekt.API.Services
{
    public interface IEmployeeRepository : ITidsrapporteringProjekt<Employee>
    {
        Task<IEnumerable<Employee>> GetAll();
    }
}
