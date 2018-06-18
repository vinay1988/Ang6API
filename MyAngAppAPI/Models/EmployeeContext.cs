using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MyAngAppAPI.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("DefaultConnection") { }
        public DbSet<Employee> Employees
        {
            get;
            set;
        }
    }
}