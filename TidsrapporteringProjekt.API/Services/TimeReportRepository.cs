using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TidsrapporteringProjekt.API.Models;
using TidsrapporteringProjekt.Models;
using System.Globalization;

namespace TidsrapporteringProjekt.API.Services
{
    public class TimeReportRepository : ITimeReportRepository
    {
        private AppDbContext _appDbContext;
        public TimeReportRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<TimeReport> GetSingle(int id)
        {
            return await _appDbContext.TimeReports.Include(t=>t.Project).FirstOrDefaultAsync(x => x.TimeReportId == id);
        }
        public async Task<TimeReport> Add(TimeReport newEntity)
        {
            var result = await _appDbContext.TimeReports.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TimeReport> Delete(int id)
        {
            var result = await _appDbContext.TimeReports.FirstOrDefaultAsync(t => t.TimeReportId == id);
            if (result != null)
            {
                _appDbContext.TimeReports.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }


        public async Task<TimeReport> Update(TimeReport entity)
        {
            var entityToUpdate = await _appDbContext.TimeReports.FirstOrDefaultAsync(t => t.TimeReportId == entity.TimeReportId);
            if (entityToUpdate != null)
            {
                entityToUpdate.Comment = entity.Comment;
                entityToUpdate.EmployeeId = entity.EmployeeId;
                entityToUpdate.EndTime = entity.EndTime;
                entityToUpdate.ProjectId = entity.ProjectId;
                entityToUpdate.StartTime = entity.StartTime;

                await _appDbContext.SaveChangesAsync();
                return entityToUpdate;
            }
            return null;
        }

        public async Task<WorkedHours> WorkedHoursPerWeekandEmployee(int employeeId, int weekNr)
        {
            CultureInfo ci = new CultureInfo("sv-SE");
            Calendar cal = ci.Calendar;

            if (_appDbContext.Employees.FirstOrDefault(e => e.EmployeeId == employeeId) == null)
            {
                return null;
            }

            var result = await _appDbContext.TimeReports.Where(t => t.EmployeeId == employeeId).ToListAsync();
            result = result.Where(t => cal.GetWeekOfYear(t.StartTime, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek) == weekNr).ToList();


            double nrOfWorkedHours = 0;

            foreach (var item in result)
            {
                nrOfWorkedHours += (item.EndTime - item.StartTime).TotalHours;
            }

            WorkedHours workedHours = new WorkedHours { EmployeeId = employeeId, HoursWorked = nrOfWorkedHours, WeekNr = weekNr };
            return workedHours;

        }
    }
}
