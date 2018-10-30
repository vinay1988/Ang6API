/*
Marker     Changed by      Date         Remarks
[001]      Aashu           19/06/2018   REB-11552: Change how the how the IPO/PO expedite message work
*/
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
	
	public class AuditDetails {
		
		#region Constructors
		
		public AuditDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// AuditId (from Table)
		/// </summary>
		public System.Int32 AuditId { get; set; }
		/// <summary>
		/// TableName (from Table)
		/// </summary>
		public System.String TableName { get; set; }
		/// <summary>
		/// HeaderNo (from Table)
		/// </summary>
		public System.Int32 HeaderNo { get; set; }
		/// <summary>
		/// DetailLineNo (from Table)
		/// </summary>
		public System.Int32? DetailLineNo { get; set; }
		/// <summary>
		/// CompanyNo (from Table)
		/// </summary>
		public System.Int32? CompanyNo { get; set; }
		/// <summary>
		/// DateReceived (from Table)
		/// </summary>
		public System.DateTime? DateReceived { get; set; }
		/// <summary>
		/// DateOrdered (from Table)
		/// </summary>
		public System.DateTime? DateOrdered { get; set; }
		/// <summary>
		/// DateRequired (from Table)
		/// </summary>
		public System.DateTime? DateRequired { get; set; }
		/// <summary>
		/// DatePromised (from Table)
		/// </summary>
		public System.DateTime? DatePromised { get; set; }
		/// <summary>
		/// DeliveryDate (from Table)
		/// </summary>
		public System.DateTime? DeliveryDate { get; set; }
		/// <summary>
		/// DateDue (from Table)
		/// </summary>
		public System.DateTime? DateDue { get; set; }
		/// <summary>
		/// DateAuthorised (from Table)
		/// </summary>
		public System.DateTime? DateAuthorised { get; set; }
		/// <summary>
		/// Quantity (from Table)
		/// </summary>
		public System.Int32? Quantity { get; set; }
		/// <summary>
		/// Price (from Table)
		/// </summary>
		public System.Double? Price { get; set; }
		/// <summary>
		/// LandedCost (from Table)
		/// </summary>
		public System.Double? LandedCost { get; set; }
		/// <summary>
		/// Freight (from Table)
		/// </summary>
		public System.Double? Freight { get; set; }
		/// <summary>
		/// ShipCost (from Table)
		/// </summary>
		public System.Double? ShipCost { get; set; }
		/// <summary>
		/// FullPart (from Table)
		/// </summary>
		public System.String FullPart { get; set; }
		/// <summary>
		/// ExternalPart (from Table)
		/// </summary>
		public System.String ExternalPart { get; set; }
		/// <summary>
		/// StockNo (from Table)
		/// </summary>
		public System.Int32? StockNo { get; set; }
		/// <summary>
		/// CurrencyNo (from Table)
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }
		/// <summary>
		/// TermsNo (from Table)
		/// </summary>
		public System.Int32? TermsNo { get; set; }
		/// <summary>
		/// TaxNo (from Table)
		/// </summary>
		public System.Int32? TaxNo { get; set; }
		/// <summary>
		/// CreditLimit (from Table)
		/// </summary>
		public System.Double? CreditLimit { get; set; }
		/// <summary>
		/// CreditLimitNew (from Table)
		/// </summary>
		public System.Double? CreditLimitNew { get; set; }
		/// <summary>
		/// Note (from Table)
		/// </summary>
		public System.String Note { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// EmployeeName (from usp_selectAll_Audit_approval_for_PurchaseOrder)
		/// </summary>
		public System.String EmployeeName { get; set; }

        /// <summary>
        /// InsuredAmount
        /// </summary>
        public System.Double? InsuredAmount { get; set; }
        /// <summary>
        /// InsuredAmountNew
        /// </summary>
        public System.Double? InsuredAmountNew { get; set; }
        /// <summary>
        /// InsuranceFileNo
        /// </summary>
        public System.String InsuranceFileNo { get; set; }
        /// <summary>
        /// InsuranceFileNoNew
        /// </summary>
        public System.String InsuranceFileNoNew { get; set; }
        /// <summary>
        /// InsHistoryId 
        /// </summary>
        public System.Int32 InsHistoryId { get; set; }
        /// <summary>
        /// POLineNos
        /// </summary>
        public System.String POLineNos { get; set; }
        /// <summary>
        /// HUBRFQ Item ReqNos
        /// </summary>
        public System.String ReqNos { get; set; }


        public System.String To { get; set; }
        //[001] start
        /// <summary>
        /// IsMailSent
        /// </summary>
        public System.String IsMailSent { get; set; }
        //[001] end
		#endregion

	}
}