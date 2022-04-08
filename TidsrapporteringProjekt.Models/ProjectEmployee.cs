using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TidsrapporteringProjekt.Models
{
    public class ProjectEmployee
    {
        [Key]
        public int ProjectEmployeeId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public Employee Employee { get; set; }
        public Project Project { get; set; }

    }
}
