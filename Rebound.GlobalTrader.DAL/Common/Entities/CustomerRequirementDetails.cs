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
	
	public class CustomerRequirementDetails {
		
		#region Constructors
		
		public CustomerRequirementDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// CustomerRequirementId (from Table)
		/// </summary>
		public System.Int32 CustomerRequirementId { get; set; }
		/// <summary>
		/// CustomerRequirementNumber (from Table)
		/// </summary>
		public System.Int32 CustomerRequirementNumber { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// FullPart (from Table)
		/// </summary>
		public System.String FullPart { get; set; }
		/// <summary>
		/// Part (from Table)
		/// </summary>
		public System.String Part { get; set; }
		/// <summary>
		/// ManufacturerNo (from Table)
		/// </summary>
		public System.Int32? ManufacturerNo { get; set; }
		/// <summary>
		/// DateCode (from Table)
		/// </summary>
		public System.String DateCode { get; set; }
		/// <summary>
		/// PackageNo (from Table)
		/// </summary>
		public System.Int32? PackageNo { get; set; }
		/// <summary>
		/// Quantity (from Table)
		/// </summary>
		public System.Int32 Quantity { get; set; }
		/// <summary>
		/// Price (from Table)
		/// </summary>
		public System.Double Price { get; set; }
		/// <summary>
		/// CurrencyNo (from Table)
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }
		/// <summary>
		/// ReceivedDate (from Table)
		/// </summary>
		public System.DateTime ReceivedDate { get; set; }
		/// <summary>
		/// Salesman (from Table)
		/// </summary>
		public System.Int32 Salesman { get; set; }
		/// <summary>
		/// DatePromised (from Table)
		/// </summary>
		public System.DateTime DatePromised { get; set; }
		/// <summary>
		/// Notes (from Table)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// Instructions (from Table)
		/// </summary>
		public System.String Instructions { get; set; }
		/// <summary>
		/// Shortage (from Table)
		/// </summary>
		public System.Boolean Shortage { get; set; }
		/// <summary>
		/// CompanyNo (from Table)
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// ContactNo (from Table)
		/// </summary>
		public System.Int32 ContactNo { get; set; }
		/// <summary>
		/// Alternate (from Table)
		/// </summary>
		public System.Boolean Alternate { get; set; }
		/// <summary>
		/// OriginalCustomerRequirementNo (from Table)
		/// </summary>
		public System.Int32? OriginalCustomerRequirementNo { get; set; }
		/// <summary>
		/// ReasonNo (from Table)
		/// </summary>
		public System.Int32? ReasonNo { get; set; }
		/// <summary>
		/// ProductNo (from Table)
		/// </summary>
		public System.Int32? ProductNo { get; set; }
		/// <summary>
		/// CustomerPart (from Table)
		/// </summary>
		public System.String CustomerPart { get; set; }
		/// <summary>
		/// Closed (from Table)
		/// </summary>
		public System.Boolean Closed { get; set; }
		/// <summary>
		/// ROHS (from Table)
		/// </summary>
		public System.Byte? ROHS { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// UsageNo (from Table)
		/// </summary>
		public System.Int32? UsageNo { get; set; }
		/// <summary>
		/// FullCustomerPart (from Table)
		/// </summary>
		public System.String FullCustomerPart { get; set; }
		/// <summary>
		/// BOM (from Table)
		/// </summary>
		public System.Boolean? BOM { get; set; }
		/// <summary>
		/// BOMName (from Table)
		/// </summary>
		public System.String BOMName { get; set; }
		/// <summary>
		/// PartWatch (from Table)
		/// </summary>
		public System.Boolean? PartWatch { get; set; }
		/// <summary>
		/// SalesmanName (from usp_select_Credit)
		/// </summary>
		public System.String SalesmanName { get; set; }
		/// <summary>
		/// ManufacturerCode (from usp_datalistnugget_CustomerRequirement)
		/// </summary>
		public System.String ManufacturerCode { get; set; }
		/// <summary>
		/// CompanyName (from usp_select_Credit)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// ContactName (from usp_select_Credit)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// RowNum (from usp_datalistnugget_CustomerRequirement)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_datalistnugget_CustomerRequirement)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_select_Credit)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// DisplayStatus (from usp_select_CustomerRequirement)
		/// </summary>
		public System.String DisplayStatus { get; set; }
		/// <summary>
		/// DivisionNo (from Table)
		/// </summary>
		public System.Int32? DivisionNo { get; set; }
		/// <summary>
		/// TeamNo (from usp_select_Credit)
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// CompanyOnStop (from usp_select_CustomerRequirement)
		/// </summary>
		public System.Boolean? CompanyOnStop { get; set; }
		/// <summary>
		/// CurrencyDescription (from usp_select_Credit)
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// ProductName (from usp_select_CustomerRequirement)
		/// </summary>
		public System.String ProductName { get; set; }
		/// <summary>
		/// ProductDescription (from usp_select_CustomerRequirement)
		/// </summary>
		public System.String ProductDescription { get; set; }
		/// <summary>
		/// ManufacturerName (from usp_select_CustomerRequirement)
		/// </summary>
		public System.String ManufacturerName { get; set; }
		/// <summary>
		/// PackageName (from usp_select_CustomerRequirement)
		/// </summary>
		public System.String PackageName { get; set; }
		/// <summary>
		/// PackageDescription (from usp_select_CustomerRequirement)
		/// </summary>
		public System.String PackageDescription { get; set; }
		/// <summary>
		/// UsageName (from usp_select_CustomerRequirement)
		/// </summary>
		public System.String UsageName { get; set; }
		/// <summary>
		/// CustomerRequirementValue (from usp_select_CustomerRequirement)
		/// </summary>
		public System.Double CustomerRequirementValue { get; set; }
		/// <summary>
		/// ClosedReason (from usp_select_CustomerRequirement)
		/// </summary>
		public System.String ClosedReason { get; set; }
		/// <summary>
		/// DivisionName (from usp_select_Credit)
		/// </summary>
		public System.String DivisionName { get; set; }
		/// <summary>
		/// Status (from usp_selectAll_CustomerRequirement_open_for_Login)
		/// </summary>
		public System.String Status { get; set; }
		/// <summary>
		/// CreditLimit (from usp_selectAll_CustomerRequirement_open_for_Login)
		/// </summary>
		public System.Double? CreditLimit { get; set; }
		/// <summary>
		/// Balance (from usp_selectAll_CustomerRequirement_open_for_Login)
		/// </summary>
		public System.Double? Balance { get; set; }
		/// <summary>
		/// DaysOverdue (from usp_selectAll_CustomerRequirement_open_for_Login)
		/// </summary>
		public System.Int32? DaysOverdue { get; set; }
		/// <summary>
		/// ClientName (from usp_source_CustomerRequirement)
		/// </summary>
		public System.String ClientName { get; set; }
        /// <summary>
        /// Traceability
        /// </summary>
        public System.Boolean? Traceability { get; set; }

        /// <summary>
        /// BOMNo (from Table)
        /// </summary>
        public System.Int32? BOMNo { get; set; }
        /// <summary>
        /// BOMHeader
        /// </summary>
        public System.String BOMHeader { get; set; }
        /// <summary>
        /// BOMCode
        /// </summary>
        public System.String BOMCode { get; set; }
        public string BOMFullName { get; set; }
        public System.Int32? POHubReleaseBy { get; set; }
        public System.Int32? RequestToPOHubBy { get; set; }
        public int? SourcingResultId { get; set; }
        /// <summary>
        /// Price (from Table)
        /// </summary>
        public System.Double ConvertedTargetValue { get; set; }
        public System.String BOMCurrencyCode { get; set; }
        public int? PurchaseQuoteNumber { get; set; }
        public int? PurchaseQuoteId { get; set; }
        public System.String BOMStatus { get; set; }
        public System.Double PHPrice { get; set; }
        public System.String PHCurrencyCode { get; set; }
        public int? POHubCompany { get; set; }
        public System.Boolean? FactorySealed { get; set; }
        public System.String MSL { get; set; }
        public System.Int32 AllSorcingHasDelDate { get; set; }
        public int AllSorcingHasProduct { get; set; }
        public System.Boolean? AS9120 { get; set; }
        public System.Int32 SourcingResult { get; set; }
        public int? SourcingResultNo { get; set; }

        public System.Boolean? PQA { get; set; }
        public System.Boolean? Obsolete { get; set; }
        public System.Boolean? LastTimeBuy { get; set; }
        public System.Boolean? RefirbsAcceptable { get; set; }
        public System.Boolean? TestingRequired { get; set; }
        public System.Double? TargetSellPrice { get; set; }
        public System.Double? CompetitorBestOffer { get; set; }
        public System.DateTime? CustomerDecisionDate { get; set; }
        public System.DateTime? RFQClosingDate { get; set; }
        public System.Int32? QuoteValidityRequired { get; set; }
        public System.Int32? Type { get; set; }
        public System.Boolean? OrderToPlace { get; set; }
        public System.Int32? RequirementforTraceability { get; set; }
        public System.String QuoteValidityText { get; set; }
        public System.String ReqTypeText { get; set; }
        public System.String ReqForTraceabilityText { get; set; }
        public System.Boolean? IsGlobalCurrencySame { get; set; }
        public System.Boolean? HasClientSourcingResult { get; set; }
        public System.Boolean? HasHubSourcingResult { get; set; }
        public System.String EAU { get; set; }
        public System.Int32? ClientGlobalCurrencyNo { get; set; }
        public System.Int32? ReqGlobalCurrencyNo { get; set; }
        public System.String ClientCurrencyCode { get; set; }
        public System.Int32? ClientCurrencyNo { get; set; }
        public System.String ReqNotes { get; set; }
        /// ClientCode
        /// </summary>
        public System.String ClientCode { get; set; }
        /// <summary>
        public Boolean? IsNoBid { get; set; }
        public System.String NoBidNotes { get; set; }
        /// <summary>
        /// IsCurrencyInSameFaimly
        /// </summary>
        public System.Boolean? IsCurrencyInSameFaimly { get; set; }
        public System.Boolean? AlternativesAccepted { get; set; }
        public System.Boolean? RepeatBusiness { get; set; }
        public System.DateTime? DateRequestToPOHub { get; set; }
        public System.Int32 POCurrencyNo { get; set; }

        public System.DateTime? ExpeditDate { get; set; }
        public System.Int32 UpdateByPH { get; set; }
        public System.Boolean? ProductInactive { get; set; }
        public System.String DutyCode { get; set; }
        public System.Double? DutyRate { get; set; }
        public System.String ValidateMessage { get; set; }
        public System.Int32? MSLLevelNo { get; set; }
        public System.Boolean? IsProdHaz { get; set; }
        public System.Double? TotalValue { get; set; }
        public System.Double? TotalInBase { get; set; }
        
        #endregion



    }
}
