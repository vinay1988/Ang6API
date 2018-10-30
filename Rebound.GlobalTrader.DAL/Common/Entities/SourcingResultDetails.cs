//Marker     changed by      date         Remarks
//[001]      Aashu          07/06/2018     Added supplier warranty field
//[002]      Aashu          16/08/2018     REB-12322: A tick box to recomond test the parts from HUB side
//-----------------------------------------------------------------------------------------
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
	
	public class SourcingResultDetails {
		
		#region Constructors
		
		public SourcingResultDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// SourcingResultId (from Table)
		/// </summary>
		public System.Int32 SourcingResultId { get; set; }
		/// <summary>
		/// CustomerRequirementNo (from Table)
		/// </summary>
		public System.Int32 CustomerRequirementNo { get; set; }
		/// <summary>
		/// SourcingTable (from Table)
		/// </summary>
		public System.String SourcingTable { get; set; }
		/// <summary>
		/// SourcingTableItemNo (from Table)
		/// </summary>
		public System.Int32? SourcingTableItemNo { get; set; }
		/// <summary>
		/// TypeName (from Table)
		/// </summary>
		public System.String TypeName { get; set; }
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
		/// CurrencyNo (from Table)
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }
		/// <summary>
		/// OriginalEntryDate (from Table)
		/// </summary>
		public System.DateTime? OriginalEntryDate { get; set; }
		/// <summary>
		/// Salesman (from Table)
		/// </summary>
		public System.Int32 Salesman { get; set; }
		/// <summary>
		/// SupplierNo (from Table)
		/// </summary>
		public System.Int32? SupplierNo { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// ROHS (from Table)
		/// </summary>
		public System.Byte? ROHS { get; set; }
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
		/// Notes (from Table)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_source_Offer)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// CustomerRequirementId (from usp_itemsearch_SourcingResult)
		/// </summary>
		public System.Int32? CustomerRequirementId { get; set; }
		/// <summary>
		/// CustomerRequirementNumber (from usp_itemsearch_SourcingResult)
		/// </summary>
		public System.Int32? CustomerRequirementNumber { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32? ClientNo { get; set; }
		/// <summary>
		/// CompanyNo (from usp_itemsearch_SourcingResult)
		/// </summary>
		public System.Int32? CompanyNo { get; set; }
		/// <summary>
		/// CompanyName (from usp_itemsearch_SourcingResult)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// SupplierName (from Table)
		/// </summary>
		public System.String SupplierName { get; set; }
		/// <summary>
		/// ManufacturerCode (from usp_source_Offer)
		/// </summary>
		public System.String ManufacturerCode { get; set; }
		/// <summary>
		/// ProductName (from Table)
		/// </summary>
		public System.String ProductName { get; set; }
		/// <summary>
		/// PackageName (from Table)
		/// </summary>
		public System.String PackageName { get; set; }
		/// <summary>
		/// OfferStatusChangeEmployeeName (from usp_source_Offer)
		/// </summary>
		public System.String OfferStatusChangeEmployeeName { get; set; }
		/// <summary>
		/// RowNum (from usp_itemsearch_SourcingResult)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_itemsearch_SourcingResult)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// ManufacturerName (from Table)
		/// </summary>
		public System.String ManufacturerName { get; set; }
		/// <summary>
		/// CustomerPart (from usp_select_SourcingResult)
		/// </summary>
		public System.String CustomerPart { get; set; }
		/// <summary>
		/// ProductDescription (from usp_selectAll_SourcingResult_for_CustomerRequirement)
		/// </summary>
		public System.String ProductDescription { get; set; }
		/// <summary>
		/// PackageDescription (from usp_selectAll_SourcingResult_for_CustomerRequirement)
		/// </summary>
		public System.String PackageDescription { get; set; }
		/// <summary>
		/// SalesmanName (from usp_source_Offer)
		/// </summary>
		public System.String SalesmanName { get; set; }
        public System.Double? SupplierPrice { get; set; }
        public System.String POHubSupplierName { get; set; }
        public System.Int32? POHubCompanyNo { get; set; }
        public System.String IsPoHub { get; set; }
        public System.Int32? POHubReleaseBy { get; set; }

        public System.String ClientSupplierName { get; set; }
        public System.Int32? ClientCompanyNo { get; set; }

        /// <summary>
        /// UPLiftPrice (from usp_selectAll_SourcingResult_for_BOMCustomerRequirement)
        /// </summary>
        public System.Double? UPLiftPrice { get; set; }
        public System.Int32 ClientCurrencyNo { get; set; }
        public System.String ClientCurrencyCode { get; set; }
        public System.Double? ConvertedSourcingPrice { get; set; }
        public System.String MslSpqFactorySealed { get; set; }

        public double? EstimatedShippingCost { get; set; }

        public double? ActualPrice { get; set; }
         
        public double? SupplierPercentage { get; set; }

        public string SupplierManufacturerName { get; set; }
        public string SupplierDateCode { get; set; }
        public string SupplierPackageType { get; set; }
        public string SupplierProductType { get; set; }
        public string SupplierMOQ { get; set; }
        public string SupplierTotalQSA { get; set; }
        public string SupplierLTB { get; set; }
        public string SupplierNotes { get; set; }
        public string SupplierType { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public System.Boolean? SourcingRelease { get; set; }
        public string SPQ { get; set; }
        public string LeadTime { get; set; }
        public string ROHSStatus { get; set; }
        public string FactorySealed { get; set; }
        public string MSL { get; set; }
        public bool IsClosed { get; set; }
        public string RegionName { get; set; }
        public System.Int32? RegionNo { get; set; }

        public string HubRFQName { get; set; }
        public System.Int32? HubRFQNo { get; set; }
        public bool IsSoCreated { get; set; }
        public string TermsName { get; set; }
        public bool IsApplyPOBankFee { get; set; }
        public string SourceRef { get; set; }

        public bool IsReleased { get; set; }
        public bool Recalled { get; set; }

        public double? OriginalPrice { get; set; }
        public System.Int32? ActualCurrencyNo { get; set; }
        public System.String ActualCurrencyCode { get; set; }

        public string SourcingNotes { get; set; }
        public System.Int32 SourcingReleasedCount { get; set; }
        public System.Boolean? ProductInactive { get; set; }
        public System.Int32? MSLLevelNo { get; set; }
        public System.String MSLLevelText { get; set; }

        //[001] start
        /// <summary>
        /// SupplierWarranty
        /// </summary>
        public System.Int32? SupplierWarranty { get; set; }
        /// <summary>
        /// NonPreferredCompany
        /// </summary>
        public System.Boolean? NonPreferredCompany { get; set; }
        //[001] end
        //[002] start
        public System.Boolean IsTestingRecommended { get; set; }
        //[002] end
        public System.Boolean? IsImageAvailable { get; set; }
		#endregion

	}
}
