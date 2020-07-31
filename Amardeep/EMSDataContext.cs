using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class EMSDataContext :  DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source= POSEIDON\SQLEXPRESS; Initial Catalog = EMS;MultipleActiveResultSets = true;
                                       Persist Security Info = true; User Id = sa; Password = master";

            optionsBuilder
                .UseSqlServer(connectionString, providerOptions => providerOptions.CommandTimeout(60))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public  DbSet<Employee> Employees { get; set; }
        public  DbSet<User> Users { get; set; } 
    }


    [Table("Employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [MaxLength(50)]
        public string EmployeeName { get; set; }

        public string Department { get; set; }
    }


    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }
    }
}
