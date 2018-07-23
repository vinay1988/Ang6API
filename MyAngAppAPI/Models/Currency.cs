using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAngAppAPI.Models
{
    [Table("tbCurrency")]
    public class Currency
    {
        [Key]
        public int CurrencyId
        {
            get;
            set;
        }

        public string CurrencyCode { get; set; }

        public string CurrencyDescription { get; set; }
        public int ClientNo { get; set; }
    }
}