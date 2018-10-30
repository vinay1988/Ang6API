/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to upload pdf document for stock section
[002]      Vinay           01/08/2012   Delete UnAllocated Stock Bug
[003]      Vinay           15/10/2012   Display company type in stock grid
[004]      Vinay           08/04/2014   CR:- Stock Provision
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
	
	public class StockDetails {
		
		#region Constructors
		
		public StockDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// StockId (from Table)
		/// </summary>
		public System.Int32 StockId { get; set; }
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
		/// WarehouseNo (from Table)
		/// </summary>
		public System.Int32? WarehouseNo { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// QualityControlNotes (from Table)
		/// </summary>
		public System.String QualityControlNotes { get; set; }
		/// <summary>
		/// PurchaseOrderNo (from Table)
		/// </summary>
		public System.Int32? PurchaseOrderNo { get; set; }
		/// <summary>
		/// PurchaseOrderLineNo (from Table)
		/// </summary>
		public System.Int32? PurchaseOrderLineNo { get; set; }
		/// <summary>
		/// QuantityInStock (from Table)
		/// </summary>
		public System.Int32 QuantityInStock { get; set; }
		/// <summary>
		/// QuantityOnOrder (from Table)
		/// </summary>
		public System.Int32 QuantityOnOrder { get; set; }
		/// <summary>
		/// Location (from Table)
		/// </summary>
		public System.String Location { get; set; }
		/// <summary>
		/// ProductNo (from Table)
		/// </summary>
		public System.Int32? ProductNo { get; set; }
		/// <summary>
		/// ResalePrice (from Table)
		/// </summary>
		public System.Double? ResalePrice { get; set; }
		/// <summary>
		/// Unavailable (from Table)
		/// </summary>
		public System.Boolean Unavailable { get; set; }
		/// <summary>
		/// LotNo (from Table)
		/// </summary>
		public System.Int32? LotNo { get; set; }
		/// <summary>
		/// LandedCost (from Table)
		/// </summary>
		public System.Double? LandedCost { get; set; }
		/// <summary>
		/// SupplierPart (from Table)
		/// </summary>
		public System.String SupplierPart { get; set; }
		/// <summary>
		/// ROHS (from Table)
		/// </summary>
		public System.Byte? ROHS { get; set; }
		/// <summary>
		/// PackageUnit (from Table)
		/// </summary>
		public System.Int32? PackageUnit { get; set; }
		/// <summary>
		/// StockKeepingUnit (from Table)
		/// </summary>
		public System.Int32? StockKeepingUnit { get; set; }
		/// <summary>
		/// CustomerRMANo (from Table)
		/// </summary>
		public System.Int32? CustomerRMANo { get; set; }
		/// <summary>
		/// CustomerRMALineNo (from Table)
		/// </summary>
		public System.Int32? CustomerRMALineNo { get; set; }
		/// <summary>
		/// GoodsInLineNo (from Table)
		/// </summary>
		public System.Int32? GoodsInLineNo { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// FullSupplierPart (from Table)
		/// </summary>
		public System.String FullSupplierPart { get; set; }
		/// <summary>
		/// CountryOfManufacture (from Table)
		/// </summary>
		public System.Int32? CountryOfManufacture { get; set; }
		/// <summary>
		/// PartMarkings (from Table)
		/// </summary>
		public System.String PartMarkings { get; set; }
		/// <summary>
		/// CountingMethodNo (from Table)
		/// </summary>
		public System.Int32? CountingMethodNo { get; set; }
		/// <summary>
		/// ManufacturerCode (from usp_datalistnugget_Stock)
		/// </summary>
		public System.String ManufacturerCode { get; set; }
		/// <summary>
		/// QuantityAllocated (from usp_datalistnugget_Stock)
		/// </summary>
		public System.Int32 QuantityAllocated { get; set; }
		/// <summary>
		/// WarehouseName (from usp_datalistnugget_Stock)
		/// </summary>
		public System.String WarehouseName { get; set; }
		/// <summary>
		/// LotName (from usp_datalistnugget_Stock)
		/// </summary>
		public System.String LotName { get; set; }
		/// <summary>
		/// SupplierNo (from usp_datalistnugget_Stock)
		/// </summary>
		public System.Int32? SupplierNo { get; set; }
		/// <summary>
		/// SupplierName (from usp_datalistnugget_Stock)
		/// </summary>
		public System.String SupplierName { get; set; }
		/// <summary>
		/// RowNum (from usp_datalistnugget_Stock)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// QuantityAvailable (from usp_datalistnugget_Stock)
		/// </summary>
		public System.Int32? QuantityAvailable { get; set; }
		/// <summary>
		/// StatusNo (from usp_datalistnugget_Stock)
		/// </summary>
		public System.Int32? StatusNo { get; set; }
		/// <summary>
		/// RowCnt (from usp_datalistnugget_Stock)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// PODeliveryDate (from usp_itemsearch_Stock)
		/// </summary>
		public System.DateTime? PODeliveryDate { get; set; }
		/// <summary>
		/// PurchaseOrderNumber (from usp_itemsearch_Stock)
		/// </summary>
		public System.Int32? PurchaseOrderNumber { get; set; }
		/// <summary>
		/// CustomerRMANumber (from usp_itemsearch_Stock)
		/// </summary>
		public System.Int32? CustomerRMANumber { get; set; }
		/// <summary>
		/// CustomerRMADate (from usp_itemsearch_Stock)
		/// </summary>
		public System.DateTime? CustomerRMADate { get; set; }
		/// <summary>
		/// PackageName (from usp_select_Stock)
		/// </summary>
		public System.String PackageName { get; set; }
		/// <summary>
		/// PackageDescription (from usp_select_Stock)
		/// </summary>
		public System.String PackageDescription { get; set; }
		/// <summary>
		/// ProductName (from usp_select_Stock)
		/// </summary>
		public System.String ProductName { get; set; }
		/// <summary>
		/// ProductDescription (from usp_select_Stock)
		/// </summary>
		public System.String ProductDescription { get; set; }
		/// <summary>
		/// ManufacturerName (from usp_select_Stock)
		/// </summary>
		public System.String ManufacturerName { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_select_Stock)
		/// </summary>
		public System.String CurrencyCode { get; set; }
        /// <summary>
        /// BaseCurrency of stock related client
        /// </summary>
        public System.String ClientBaseCurrencyCode { get; set; }
		/// <summary>
		/// LotCode (from usp_select_Stock)
		/// </summary>
		public System.String LotCode { get; set; }
		/// <summary>
		/// Buyer (from usp_select_Stock)
		/// </summary>
		public System.Int32? Buyer { get; set; }
		/// <summary>
		/// BuyerName (from usp_select_Stock)
		/// </summary>
		public System.String BuyerName { get; set; }
		/// <summary>
		/// GoodsInNo (from usp_select_Stock)
		/// </summary>
		public System.Int32? GoodsInNo { get; set; }
		/// <summary>
		/// GoodsInPrice (from usp_select_Stock)
		/// </summary>
		public System.Double? GoodsInPrice { get; set; }
		/// <summary>
		/// GoodsInShipInCost (from usp_select_Stock)
		/// </summary>
		public System.Double? GoodsInShipInCost { get; set; }
		/// <summary>
		/// GoodsInNumber (from usp_select_Stock)
		/// </summary>
		public System.Int32? GoodsInNumber { get; set; }
		/// <summary>
		/// GoodsInCurrencyNo (from usp_select_Stock)
		/// </summary>
		public System.Int32? GoodsInCurrencyNo { get; set; }
		/// <summary>
		/// StockDate (from usp_select_Stock)
		/// </summary>
		public System.DateTime StockDate { get; set; }
		/// <summary>
		/// ROHSStatus (from usp_select_Stock)
		/// </summary>
		public System.String ROHSStatus { get; set; }
		/// <summary>
		/// CountryOfManufactureName (from usp_select_Stock)
		/// </summary>
		public System.String CountryOfManufactureName { get; set; }
		/// <summary>
		/// PurchasePrice (from usp_select_Stock)
		/// </summary>
		public System.Double? PurchasePrice { get; set; }
		/// <summary>
		/// CountingMethodDescription (from usp_select_Stock)
		/// </summary>
		public System.String CountingMethodDescription { get; set; }
		/// <summary>
		/// StockLogDetail (from usp_select_Stock)
		/// </summary>
		public System.String StockLogDetail { get; set; }
		/// <summary>
		/// StockLogChangeNotes (from usp_select_Stock)
		/// </summary>
		public System.String StockLogChangeNotes { get; set; }
		/// <summary>
		/// StockLogReasonNo (from usp_select_Stock)
		/// </summary>
		public System.Int32? StockLogReasonNo { get; set; }
		/// <summary>
		/// UpdateShipments (from usp_select_Stock)
		/// </summary>
		public System.Boolean? UpdateShipments { get; set; }
		/// <summary>
		/// RelationType (from usp_selectAll_Stock_RelatedStock)
		/// </summary>
		public System.String RelationType { get; set; }
		/// <summary>
		/// ClientName (from usp_source_Stock)
		/// </summary>
		public System.String ClientName { get; set; }
		/// <summary>
		/// ClientDataVisibleToOthers (from usp_source_Stock)
		/// </summary>
		public System.Boolean? ClientDataVisibleToOthers { get; set; }
        /// <summary>
        /// Check image availablability from tbStock
        /// </summary>
        public System.Boolean? IsImageAvailable { get; set; }
        /// <summary>
        /// IsPDFAvailable
        ///[001] code start
        /// </summary>
        public System.Boolean? IsPDFAvailable { get; set; }
        // [001] code start

        ///[002] code start
        /// <summary>
        /// StockUnallocatedCount
        /// </summary>
        public System.Int32 StockUnallocatedCount { get; set; }
        //[002] code end

        //[003] code start
        public System.String SupplierType { get; set; }

        //[003] code end
        /// <summary>
        /// Stock start date
        /// </summary>
        public System.String StockStartDate { get; set; }
        //[004] code start
        /// <summary>
        /// OriginalLandedCost
        /// </summary>
        public System.Double? OriginalLandedCost { get; set; }
        /// <summary>
        /// ManualStockSplitDate
        /// </summary>
        public System.DateTime? ManualStockSplitDate { get; set; }
        /// <summary>
        /// FirstStockProvisionDate
        /// </summary>
        public System.DateTime? FirstStockProvisionDate { get; set; }
        /// <summary>
        /// LastStockProvisionDate
        /// </summary>
        public System.DateTime? LastStockProvisionDate { get; set; }
        /// <summary>
        /// IsManual
        /// </summary>
        public System.Boolean? IsManual { get; set; }
        //[004] code start


        /// <summary>
        /// Lot Stock Provision Id
        /// </summary>
        public System.Int32 LotStockProvisionID { get; set; }

        /// <summary>
        /// Lot Stock Provision Name
        /// </summary>
        public System.String LotStockProvisionName { get; set; }
        /// <summary>
        /// Current Landed Cost.
        /// </summary>
        public System.Double? CurrentLandedCost { get; set; }

        /// <summary>
        /// Stock Provision Value.
        /// </summary>
        public System.Double? StockProvisionValue { get; set; }

        /// <summary>
        /// Stock Provision Perventage.
        /// </summary>
        public System.Int32? StockProvisonPercentage { get; set; }

        /// <summary>
        /// Lost stock provision line id.
        /// </summary>
        public System.Int32 LotStockProvisionLineID { get; set; }

        /// <summary>
        /// Lot stock provision no.
        /// </summary>
        public System.String LotStockProvisionNo { get; set; }

        /// <summary>
        /// Client Currency id
        /// </summary>
        public System.Int32 CurrencyId { get; set; }
        /// <summary>
        /// POSerialNo
        /// </summary>
        public System.Int16? POSerialNo { get; set; }
        /// <summary>
        /// DivisionNo
        /// </summary>
        public System.Int32? DivisionNo { get; set; }
        /// <summary>
        /// DivisionName
        /// </summary>
        public System.String DivisionName { get; set; }

        public int? InternalPurchaseOrderNumber { get; set; }

        public int? InternalPurchaseOrderId { get; set; }  

        public int? IPOSupplier { get; set; }

        public string IPOSupplierName { get; set; }

        /// <summary>
        /// POClientNo
        /// </summary>
        public System.Int32 ? POClientNo { get; set; }

        public int? IsPoHub { get; set; }
        /// <summary>
        /// ClientLandedCost (from Table)
        /// </summary>
        public System.Double? ClientLandedCost { get; set; }
        /// <summary>
        /// ClientPurchasePrice (from usp_select_Stock)
		/// </summary>
        public System.Double? ClientPurchasePrice { get; set; }
        public int? IPONo { get; set; }
        public System.Boolean? IsClientUpdate { get; set; }
        /// <summary>
        /// ClientCode
        /// </summary>
        public System.String  ClientCode { get; set; }
        public int? SalesOrderNumber { get; set; }
        public System.String NPRNo { get; set; }
        public System.String CustomerPO { get; set; }

        public System.Int32? CustomerNo { get; set; }
        public System.String CustomerName { get; set; }
        public System.Int32? ClientBaseCurrencyID { get; set; }
        //public System.Boolean? ReqSerialNo { get; set; }
        public System.String MSLLevel { get; set; }
		#endregion

	}
}
