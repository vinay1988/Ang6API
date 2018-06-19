using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAngAppAPI.Models
{
    [Table("SalesOrder")]
    public class SalesOrder
    {
        [Key]
        public int SalesOrderId
        {
            get;
            set;
        }

        public int SalesOrderNumber { get; set; }


        public int ClientNo { get; set; }
        public int CompanyNo { get; set; }
        public int ContactNo { get; set; }
        public DateTime DateOrdered { get; set; }
        public int CurrencyNo { get; set; }
        public int Salesman { get; set; }
        public int TermsNo { get; set; }
        public int? ShipToAddressNo { get; set; }
        public int? ShipViaNo { get; set; }
        public string Account { get; set; }
        public System.Double Freight { get; set; }
        public string CustomerPO { get; set; }
        public int DivisionNo
        { get; set; }
        public int TaxNo { get; set; }
         public System.Double? ShippingCost { get; set; }
        public string Notes
        { get; set; }
        public string Instructions
        { get; set; }
        public int StatusNo { get; set; }
        public int? SaleTypeNo { get; set; }
        public int? Salesman2
        { get; set; }
        public System.Double Salesman2Percent
        { get; set; }
        public int? AuthorisedBy { get; set; }
        public DateTime? DateAuthorised { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime DLUP { get; set; }
        public DateTime? CurrencyDate { get; set; }
        public int? IncotermNo { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}