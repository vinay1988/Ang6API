using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Rebound.GlobalTrader.DAL {
	
	public class POQuoteLineDetails {
		
		#region Constructors
		
		public POQuoteLineDetails() { }
		
		#endregion
		
		#region Properties

        /// <summary>
        /// PurchaseQuoteLineId
        /// </summary>
        public System.Int32 PurchaseQuoteLineId { get; set; }
        /// <summary>
        /// CustomerRequirementNo
        /// </summary>
        public System.Int32 CustomerRequirementNo { get; set; }
        /// <summary>
        /// PurchaseQuoteNo
        /// </summary>
        public System.Int32? PurchaseQuoteNo { get; set; }
        /// <summary>
        /// BOMNo
        /// </summary>
        public System.Int32 BOMNo { get; set; }
        /// <summary>
        /// FullPart
        /// </summary>
        public System.String FullPart { get; set; }
        /// <summary>
        /// Part
        /// </summary>
        public System.String Part { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        public System.Int32 Quantity { get; set; }
        /// <summary>
        /// CompanyNo
        /// </summary>
        public System.Int32 CompanyNo { get; set; }
        /// <summary>
        /// ContactName
        /// </summary>
        public System.String ContactName { get; set; }
        /// <summary>
        /// ContactNo
        /// </summary>
        public System.Int32 ContactNo { get; set; }
        /// <summary>
        /// TargetPrice
        /// </summary>
        public System.Double TargetPrice { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public System.Double UnitPrice { get; set; }
        /// <summary>
        /// CurrencyNo
        /// </summary>
        public System.Int32? CurrencyNo { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime DLUP { get; set; }
        /// <summary>
        /// CurrencyCode
        /// </summary>
        public System.String CurrencyCode { get; set; }
        /// <summary>
        /// CompanyName
        /// </summary>
        public System.String CompanyName { get; set; }
        /// <summary>
        /// RowNum
        /// </summary>
        public System.Int64? RowNum { get; set; }
        /// <summary>
        /// RowCnt
        /// </summary>
        public System.Int32? RowCnt { get; set; }
        /// <summary>
        /// ClientNo
        /// </summary>
        public System.Int32? ClientNo { get; set; }
        /// <summary>
        /// ClientName
        /// </summary>
        public System.String ClientName { get; set; }
        /// <summary>
        /// Salesman
        /// </summary>
        public System.Int32 Salesman { get; set; }
        /// <summary>
        /// SalesmanName
        /// </summary>
        public System.String SalesmanName { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public System.String LineNotes { get; set; }
        /// <summary>
        /// Clsoed
        /// </summary>
        public System.Boolean? Closed { get; set; }
        public System.Int32? CustomerRequirementNumber { get; set; }
        /// <summary>
        /// BOMName
        /// </summary>
        public System.String BOMName { get; set; }
        /// <summary>
        /// PurchaseQuoteNumber
        /// </summary>
        public System.Int32? PurchaseQuoteNumber { get; set; }
        /// <summary>
        /// DatePOQuoted
        /// </summary>
        public System.DateTime? DatePOQuoted { get; set; }
        /// <summary>
        /// CSV Log Message
        /// </summary>
        public System.String Message { get; set; }

        public System.Int32 PRCurrencyNo { get; set; }
        public System.String PRCurencyCode { get; set; }
        public System.Int32 ReqCurrencyNo { get; set; }
        public System.String ReqCurrencyCode { get; set; }
        public System.Double? ConvertedTargetValue { get; set; }

        public string PRStatus { get; set; }
        public int? PQStatus { get; set; }
        public System.String MSL { get; set; }
        public System.String SPQ { get; set; }
        public System.String LeadTime { get; set; }
        public System.String RoHSStatus { get; set; }
        public System.String FactorySealed { get; set; }
        public System.Int32 PurchaseRequestLineDetailId { get; set; }
        public System.String SupplierType { get; set; }
        public System.Double PHPrice { get; set; }
         public System.Boolean? FactorySealedR { get; set; }
        public System.String MSLR { get; set; }
        public System.Boolean? AS9120 { get; set; }
        public System.Boolean? IsGlobalCurrencySame { get; set; }

        public System.Boolean? Status { get; set; }
        public System.String LoginName { get; set; }
        public System.String FileName { get; set; }


		#endregion

	}
}
