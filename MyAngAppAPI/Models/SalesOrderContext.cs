using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MyAngAppAPI.Models
{
    public class SalesOrderContext : DbContext
    {
        public SalesOrderContext() : base("DefaultConnection") { }
        public DbSet<SalesOrder> SalesOrders
        {
            get;
            set;
        }
    }
}