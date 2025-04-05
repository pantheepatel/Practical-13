using System;
using System.Data.Entity;
using System.Linq;

namespace Task1.Models
{
    public class EmployeeDbContext : DbContext
    {
        // Your context has been configured to use a 'EmployeeDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Task1.Models.EmployeeDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EmployeeDbContext' 
        // connection string in the application configuration file.
        public EmployeeDbContext()
            : base("name=EmployeeDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Employee> Employees { get; set; }
    }
}