//Marker     Changed by      Date         Remarks    
//[001]      Vinay           16/10/2012   Display supplier type in stock grid  
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
	
	public class OfferDetails {
		
		#region Constructors
		
		public OfferDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// OfferId (from Table)
		/// </summary>
		public System.Int32 OfferId { get; set; }
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
		/// ProductNo (from Table)
		/// </summary>
		public System.Int32? ProductNo { get; set; }
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
		/// OriginalEntryDate (from Table)
		/// </summary>
		public System.DateTime? OriginalEntryDate { get; set; }
		/// <summary>
		/// Salesman (from Table)
		/// </summary>
		public System.Int32? Salesman { get; set; }
		/// <summary>
		/// SupplierNo (from Table)
		/// </summary>
		public System.Int32 SupplierNo { get; set; }
		/// <summary>
		/// CurrencyNo (from Table)
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }
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
		/// OfferStatusNo (from Table)
		/// </summary>
		public System.Int32? OfferStatusNo { get; set; }
		/// <summary>
		/// OfferStatusChangeDate (from Table)
		/// </summary>
		public System.DateTime? OfferStatusChangeDate { get; set; }
		/// <summary>
		/// OfferStatusChangeLoginNo (from Table)
		/// </summary>
		public System.Int32? OfferStatusChangeLoginNo { get; set; }
		/// <summary>
		/// SupplierName (from Table)
		/// </summary>
		public System.String SupplierName { get; set; }
		/// <summary>
		/// Notes (from Table)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// ManufacturerName (from Table)
		/// </summary>
		public System.String ManufacturerName { get; set; }
		/// <summary>
		/// ProductName (from Table)
		/// </summary>
		public System.String ProductName { get; set; }
		/// <summary>
		/// PackageName (from Table)
		/// </summary>
		public System.String PackageName { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32? ClientNo { get; set; }
		/// <summary>
		/// ManufacturerCode (from usp_source_Offer)
		/// </summary>
		public System.String ManufacturerCode { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_source_Offer)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// CurrencyDescription (from usp_source_Offer)
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// SupplierEmail (from usp_source_Offer)
		/// </summary>
		public System.String SupplierEmail { get; set; }
		/// <summary>
		/// SalesmanName (from usp_source_Offer)
		/// </summary>
		public System.String SalesmanName { get; set; }
		/// <summary>
		/// OfferStatusChangeEmployeeName (from usp_source_Offer)
		/// </summary>
		public System.String OfferStatusChangeEmployeeName { get; set; }
		/// <summary>
		/// ClientId (from usp_source_Offer)
		/// </summary>
		public System.Int32 ClientId { get; set; }
		/// <summary>
		/// ClientName (from usp_source_Offer)
		/// </summary>
		public System.String ClientName { get; set; }
		/// <summary>
		/// ClientDataVisibleToOthers (from usp_source_Offer)
		/// </summary>
		public System.Boolean? ClientDataVisibleToOthers { get; set; }

        //[001] code start
        /// <summary>
        /// SupplierType
        /// </summary>
        public System.String SupplierType { get; set; }
        //[001] code end
        public System.String ClientCode { get; set; }
        public System.String MSL { get; set; }
        public System.String SPQ { get; set; }
        public System.String LeadTime { get; set; }
        public System.String RoHSStatus { get; set; }
        public System.String FactorySealed { get; set; }
        public System.Int32 IPOBOMNo { get; set; }
        public System.String SupplierTotalQSA { get; set; }
        public System.String SupplierMOQ { get; set; }
        public System.String SupplierLTB { get; set; }
        public System.Boolean IsSourcingHub { get; set; }
        public System.String ProductDescription { get; set; }
        public System.Boolean? ProductInactive { get; set; }
        public System.Int32? MSLLevelNo { get; set; }
		#endregion

	}
}