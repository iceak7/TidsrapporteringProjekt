using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TidsrapporteringProjekt.Models;

namespace TidsrapporteringProjekt.API.Models
{
    public class WorkedHours
    {
        public int EmployeeId { get; set; }
        public int WeekNr { get; set; }
        public double HoursWorked { get; set; }
    }
}
