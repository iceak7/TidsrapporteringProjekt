using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace TidsrapporteringProjekt.Models
{
    public class TimeReport
    {
        [Key]
        public int TimeReportId { get; set; }
        public string Comment { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int EmployeeId { get; set; }
        public int? ProjectId { get; set; }
        [JsonIgnore]
        public Employee Employee { get; set; }
        public Project Project { get; set; }
    }
}
