using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MyAngAppAPI.Models
{
    public class CurrencyContext : DbContext
    {
        public CurrencyContext() : base("DefaultConnection") { }
        public DbSet<Currency> Currencies
        {
            get;
            set;
        }
    }
}