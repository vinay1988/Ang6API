//Marker     Changed by      Date         Remarks
//[001]      Vinay           22/01/2014   CR:- Add AS9120 Requirement in GT application
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
	
	public class QuoteLineDetails {
		
		#region Constructors
		
		public QuoteLineDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// QuoteLineId (from Table)
		/// </summary>
		public System.Int32 QuoteLineId { get; set; }
		/// <summary>
		/// QuoteNo (from Table)
		/// </summary>
		public System.Int32 QuoteNo { get; set; }
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
		/// ETA (from Table)
		/// </summary>
		public System.String ETA { get; set; }
		/// <summary>
		/// Instructions (from Table)
		/// </summary>
		public System.String Instructions { get; set; }
		/// <summary>
		/// ProductNo (from Table)
		/// </summary>
		public System.Int32? ProductNo { get; set; }
		/// <summary>
		/// ReasonNo (from Table)
		/// </summary>
		public System.Int32? ReasonNo { get; set; }
		/// <summary>
		/// CustomerPart (from Table)
		/// </summary>
		public System.String CustomerPart { get; set; }
		/// <summary>
		/// StockNo (from Table)
		/// </summary>
		public System.Int32? StockNo { get; set; }
		/// <summary>
		/// ServiceNo (from Table)
		/// </summary>
		public System.Int32? ServiceNo { get; set; }
		/// <summary>
		/// ROHS (from Table)
		/// </summary>
		public System.Byte? ROHS { get; set; }
		/// <summary>
		/// Closed (from Table)
		/// </summary>
		public System.Boolean Closed { get; set; }
		/// <summary>
		/// OriginalOfferPrice (from Table)
		/// </summary>
		public System.Double? OriginalOfferPrice { get; set; }
		/// <summary>
		/// OriginalOfferCurrencyNo (from Table)
		/// </summary>
		public System.Int32? OriginalOfferCurrencyNo { get; set; }
		/// <summary>
		/// OriginalOfferDate (from Table)
		/// </summary>
		public System.DateTime? OriginalOfferDate { get; set; }
		/// <summary>
		/// OriginalOfferSupplierNo (from Table)
		/// </summary>
		public System.Int32? OriginalOfferSupplierNo { get; set; }
		/// <summary>
		/// Notes (from Table)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// FullCustomerPart (from Table)
		/// </summary>
		public System.String FullCustomerPart { get; set; }
		/// <summary>
		/// NotQuoted (from Table)
		/// </summary>
		public System.Boolean NotQuoted { get; set; }
		/// <summary>
		/// SourcingResultNo (from Table)
		/// </summary>
		public System.Int32? SourcingResultNo { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// QuoteId (from usp_datalistnugget_QuoteLine)
		/// </summary>
		public System.Int32 QuoteId { get; set; }
		/// <summary>
		/// QuoteNumber (from usp_datalistnugget_QuoteLine)
		/// </summary>
		public System.Int32 QuoteNumber { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_datalistnugget_QuoteLine)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// DateQuoted (from usp_datalistnugget_QuoteLine)
		/// </summary>
		public System.DateTime DateQuoted { get; set; }
		/// <summary>
		/// CompanyName (from usp_datalistnugget_QuoteLine)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// CompanyNo (from usp_datalistnugget_QuoteLine)
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// ContactName (from usp_datalistnugget_QuoteLine)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// ContactNo (from usp_datalistnugget_QuoteLine)
		/// </summary>
		public System.Int32 ContactNo { get; set; }
		/// <summary>
		/// RowNum (from usp_datalistnugget_QuoteLine)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_datalistnugget_QuoteLine)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// LineNotes (from usp_select_QuoteLine)
		/// </summary>
		public System.String LineNotes { get; set; }
		/// <summary>
		/// ManufacturerName (from usp_select_QuoteLine)
		/// </summary>
		public System.String ManufacturerName { get; set; }
		/// <summary>
		/// ManufacturerCode (from usp_select_QuoteLine)
		/// </summary>
		public System.String ManufacturerCode { get; set; }
		/// <summary>
		/// PackageName (from usp_select_QuoteLine)
		/// </summary>
		public System.String PackageName { get; set; }
		/// <summary>
		/// PackageDescription (from usp_select_QuoteLine)
		/// </summary>
		public System.String PackageDescription { get; set; }
		/// <summary>
		/// ProductName (from usp_select_QuoteLine)
		/// </summary>
		public System.String ProductName { get; set; }
		/// <summary>
		/// ProductDescription (from usp_select_QuoteLine)
		/// </summary>
		public System.String ProductDescription { get; set; }
		/// <summary>
		/// CurrencyNo (from usp_select_QuoteLine)
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }
		/// <summary>
		/// ReasonName (from usp_select_QuoteLine)
		/// </summary>
		public System.String ReasonName { get; set; }
		/// <summary>
		/// OriginalOfferCurrencyCode (from usp_select_QuoteLine)
		/// </summary>
		public System.String OriginalOfferCurrencyCode { get; set; }
		/// <summary>
		/// OriginalOfferSupplierName (from usp_select_QuoteLine)
		/// </summary>
		public System.String OriginalOfferSupplierName { get; set; }
		/// <summary>
		/// ClientNo (from usp_select_QuoteLine)
		/// </summary>
		public System.Int32? ClientNo { get; set; }
		/// <summary>
		/// ClientName (from usp_source_QuoteLine)
		/// </summary>
		public System.String ClientName { get; set; }
		/// <summary>
		/// ClientDataVisibleToOthers (from usp_source_QuoteLine)
		/// </summary>
		public System.Boolean? ClientDataVisibleToOthers { get; set; }
        /// <summary>
        /// Salesman (from usp_source_QuoteLine)
        /// </summary>
        public System.Int32 Salesman { get; set; }
        /// <summary>
        /// SalesmanName (from usp_source_QuoteLine)
        /// </summary>
        public System.String SalesmanName { get; set; }
        //[001] code start
        /// <summary>
        /// ProductSource
        /// </summary>
        public System.Byte? ProductSource { get; set; }
        //[001] code end
        public double? UPLiftPrice { get; set; }
        public System.String SPQ { get; set; }
        public System.String FactorySealed { get; set; }
        public System.String MSL { get; set; }
        public string SourcingTable { get; set; }
        public System.Int32? POHubCompanyNo { get; set; }
        public System.DateTime? DeliveryDate { get; set; }
        //public System.DateTime? DeliveryDate { get; set; }
        public System.Boolean? IsIPOCreated { get; set; }

        public System.String QuoteNotes { get; set; }
        
        public System.String ClientCode { get; set; }

        public System.Boolean? ProductInactive { get; set; }
        public System.String DutyCode { get; set; }
        public System.Double? DutyRate { get; set; }

        public System.String Reason { get; set; }
        public System.String ReasonNote { get; set; }
        public System.Boolean? IsProdHazardous { get; set; }
        public System.Boolean? PrintHazardous { get; set; }
        public System.Double? TotalValue { get; set; }
        public System.Double? TotalInBase { get; set; }
        public System.String QuoteStatusName { get; set; }
		#endregion

	}
}
