using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace TidsrapporteringProjekt.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProjectEmployee> ProjectEmployee { get; set; }

    }
}
