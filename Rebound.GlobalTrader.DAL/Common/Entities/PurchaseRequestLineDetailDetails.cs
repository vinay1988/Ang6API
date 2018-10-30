using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebound.GlobalTrader.DAL.Common.Entities
{
    public class PurchaseRequestLineDetailDetails
    {
        #region Constructors
        public PurchaseRequestLineDetailDetails()
        {
        }
        #endregion

        #region Properties
        public int? PurchaseRequestLineDetailId { get; set; }
        public int? PurchaseRequestLineNo { get; set; }
        public int? CompanyNo { get; set; }
        public string CompanyName { get; set; }
        public double? Price { get; set; }
        public System.String SPQ { get; set; }
        public System.String LeadTime { get; set; }
        public System.String RoHSStatus { get; set; }
        public System.String FactorySealed { get; set; }
        public System.String MSL { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DLUP { get; set; }

        public string ManufacturerName { get; set; }
        public string DateCode { get; set; }
        public string PackageType { get; set; }
        public string ProductType { get; set; }
        public string MOQ { get; set; }
        public string TotalQSA { get; set; }
        public string LTB { get; set; }
        public string Notes { get; set; }
        public System.Int32? CurrencyNo { get; set; }
        public System.Int32? GlobalCurrencyNo { get; set; }
        public string CurrencyCode { get; set; }
        public System.Int32? MSLLevelNo { get; set; }

        #endregion
    }
}
