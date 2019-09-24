using Microsoft.EntityFrameworkCore;
using System;

namespace DBStructure
{
    class TimeTracker : DbContext
    {
        public DbSet<Login> Logins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TimeTracker;Trusted_Connection=True;");
        }

    }


    public class Login
    {
        public int LoginID { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }

        public int LoginID { get; set; }
        public Login Login { get; set; }

    }

    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime TotalTime { get; set; }

        public int ClientID { get; set; }
        public int ProjectManagerID { get; set; }

    }

    public class Session
    {
        public int SessionId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public int ProjectID { get; set; }
        public Project Project { get; set; }


    }
    public class Client
    {
        public int ClientID { get; set; }
        public string CompanyName { get; set; }
        public int CompanyPhone { get; set; }
        public string CompanyPoc { get; set; }
    }

    public class ProjectManager
    {
        public int ProjectManagerID { get; set; }
        public string Rights { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int ProjectID { get; set; }
        public Project Project { get; set; }
    }

}
