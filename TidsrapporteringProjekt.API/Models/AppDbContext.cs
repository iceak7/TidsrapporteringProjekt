using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TidsrapporteringProjekt.Models;

namespace TidsrapporteringProjekt.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TimeReport> TimeReports { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 1, Age = 22, EmployedDate = new DateTime(2021, 09, 07), FirstName = "Isak", LastName = "Jensen", Gender = "Male", JobTitle = "Programmer" });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 2, Age = 30, EmployedDate = new DateTime(2020, 09, 01), FirstName = "Anas", LastName = "Qlok", Gender = "Male", JobTitle = "Programming Teacher" });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeId = 3, Age = 45, EmployedDate = new DateTime(2021, 10, 17), FirstName = "Reidar", LastName = "Qlok", Gender = "Male", JobTitle = "Teacher" });


            modelBuilder.Entity<Project>().HasData(new Project { ProjectId = 1, ProjectName = "Bank Project", IsActive = false, ProjectDescription = "Creating a bank-console-application" });
            modelBuilder.Entity<Project>().HasData(new Project { ProjectId = 2, ProjectName = "Time Reporting Project", IsActive = true, ProjectDescription = "Creating a time-reporting-application" });
            modelBuilder.Entity<Project>().HasData(new Project { ProjectId = 3, ProjectName = "Teach programming", IsActive = true, ProjectDescription = "Teach the students programming" });


            modelBuilder.Entity<ProjectEmployee>().HasData(new ProjectEmployee { ProjectEmployeeId = 1, EmployeeId = 1, ProjectId = 1 });
            modelBuilder.Entity<ProjectEmployee>().HasData(new ProjectEmployee { ProjectEmployeeId = 2, EmployeeId = 1, ProjectId = 2 });
            modelBuilder.Entity<ProjectEmployee>().HasData(new ProjectEmployee { ProjectEmployeeId = 3, EmployeeId = 2, ProjectId = 3 });
            modelBuilder.Entity<ProjectEmployee>().HasData(new ProjectEmployee { ProjectEmployeeId = 4, EmployeeId = 3, ProjectId = 3 });


            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 1, EmployeeId = 1, StartTime = new DateTime(2021, 12, 7, 08, 00, 00), EndTime = new DateTime(2021, 12, 7, 16, 00, 00), ProjectId = 1, Comment = "Worked on the bank project" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 2, EmployeeId = 1, StartTime = new DateTime(2021, 12, 8, 08, 00, 00), EndTime = new DateTime(2021, 12, 8, 16, 00, 00), ProjectId = 1, Comment = "Worked on the bank project" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 3, EmployeeId = 1, StartTime = new DateTime(2022, 01, 3, 09, 00, 00), EndTime = new DateTime(2022, 01, 3, 16, 00, 00), Comment = "I studied" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 4, EmployeeId = 1, StartTime = new DateTime(2022, 04, 6, 08, 00, 00), EndTime = new DateTime(2022, 04, 6, 15, 00, 00), ProjectId = 2, Comment = "Worked on the time-report project" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 5, EmployeeId = 1, StartTime = new DateTime(2022, 04, 5, 09, 00, 00), EndTime = new DateTime(2022, 04, 5, 15, 00, 00), ProjectId = 2, Comment = "Worked on the time-report project" });

            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 6, EmployeeId = 2, StartTime = new DateTime(2022, 04, 5, 09, 00, 00), EndTime = new DateTime(2022, 04, 5, 15, 00, 00), ProjectId = 3, Comment = "Teached about API" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 7, EmployeeId = 2, StartTime = new DateTime(2022, 01, 5, 09, 00, 00), EndTime = new DateTime(2022, 01, 5, 15, 00, 00), ProjectId = 3, Comment = "Teached about SQL" });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport { TimeReportId = 8, EmployeeId = 3, StartTime = new DateTime(2022, 03, 20, 09, 00, 00), EndTime = new DateTime(2022, 03, 20, 15, 00, 00), ProjectId = 3, Comment = "Teached about microservices" });

        }
    }
}
