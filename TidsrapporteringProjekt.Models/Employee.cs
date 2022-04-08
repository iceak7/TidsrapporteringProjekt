using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;


namespace TidsrapporteringProjekt.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string JobTitle { get; set; }
        public DateTime EmployedDate { get; set; }
        public virtual ICollection<TimeReport> TimeReports { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProjectEmployee> ProjectEmployee { get; set; }
    }
}
