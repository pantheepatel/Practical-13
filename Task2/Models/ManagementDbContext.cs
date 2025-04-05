using System;
using System.Data.Entity;
using System.Linq;

namespace Task2.Models
{
    public class ManagementDbContext : DbContext
    {
        // Your context has been configured to use a 'ManagementDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Task2.Models.ManagementDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ManagementDbContext' 
        // connection string in the application configuration file.
        public ManagementDbContext()
            : base("name=ManagementDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<EmployeeT2> Employees { get; set; }
        public DbSet<DesignationT2> Designations { get; set; }
    }
}