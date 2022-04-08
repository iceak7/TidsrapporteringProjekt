using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TidsrapporteringProjekt.API.Models;
using TidsrapporteringProjekt.Models;

namespace TidsrapporteringProjekt.API.Services
{
    public interface ITimeReportRepository : ITidsrapporteringProjekt<TimeReport>
    {
        Task<WorkedHours> WorkedHoursPerWeekandEmployee(int employeeId, int weekNr);
    }
}
