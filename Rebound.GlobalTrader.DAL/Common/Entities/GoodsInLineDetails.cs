//Marker     Changed by      Date         Remarks
//[001]      Vinay           04/09/2012   Print Label
//[002]      Vinay           08/07/2013    Ref:## -32 Nice Label Printing
//[003]      Vinay           28/08/2013    NPR Print
//[004]      Raushan         27/02/2014    GoodsIn - Po serial No.
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
	
	public class GoodsInLineDetails {
		
		#region Constructors
		
		public GoodsInLineDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// GoodsInLineId (from Table)
		/// </summary>
		public System.Int32 GoodsInLineId { get; set; }
		/// <summary>
		/// GoodsInNo (from Table)
		/// </summary>
		public System.Int32 GoodsInNo { get; set; }
		/// <summary>
		/// PurchaseOrderLineNo (from Table)
		/// </summary>
		public System.Int32? PurchaseOrderLineNo { get; set; }
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
		/// ShipInCost (from Table)
		/// </summary>
		public System.Double? ShipInCost { get; set; }
		/// <summary>
		/// QualityControlNotes (from Table)
		/// </summary>
		public System.String QualityControlNotes { get; set; }
		/// <summary>
		/// Location (from Table)
		/// </summary>
		public System.String Location { get; set; }
		/// <summary>
		/// ProductNo (from Table)
		/// </summary>
		public System.Int32? ProductNo { get; set; }
		/// <summary>
		/// LandedCost (from Table)
		/// </summary>
		public System.Double LandedCost { get; set; }

		/// <summary>
		/// CustomerRMALineNo (from Table)
		/// </summary>
		public System.Int32? CustomerRMALineNo { get; set; }
		/// <summary>
		/// SupplierPart (from Table)
		/// </summary>
		public System.String SupplierPart { get; set; }
		/// <summary>
		/// ROHS (from Table)
		/// </summary>
		public System.Byte? ROHS { get; set; }
		/// <summary>
		/// CountryOfManufacture (from Table)
		/// </summary>
		public System.Int32? CountryOfManufacture { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// InspectedBy (from Table)
		/// </summary>
		public System.Int32? InspectedBy { get; set; }
		/// <summary>
		/// DateInspected (from Table)
		/// </summary>
		public System.DateTime? DateInspected { get; set; }
		/// <summary>
		/// CountingMethodNo (from Table)
		/// </summary>
		public System.Int32? CountingMethodNo { get; set; }
		/// <summary>
		/// SerialNosRecorded (from Table)
		/// </summary>
		public System.Boolean? SerialNosRecorded { get; set; }
		/// <summary>
		/// Unavailable (from Table)
		/// </summary>
		public System.Boolean? Unavailable { get; set; }
		/// <summary>
		/// LotNo (from Table)
		/// </summary>
		public System.Int32? LotNo { get; set; }
		/// <summary>
		/// Notes (from Table)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// PartMarkings (from Table)
		/// </summary>
		public System.String PartMarkings { get; set; }
		/// <summary>
		/// FullSupplierPart (from Table)
		/// </summary>
		public System.String FullSupplierPart { get; set; }
		/// <summary>
		/// GoodsInId (from usp_datalistnugget_GoodsInLine)
		/// </summary>
		public System.Int32 GoodsInId { get; set; }
		/// <summary>
		/// GoodsInNumber (from usp_datalistnugget_GoodsInLine)
		/// </summary>
		public System.Int32 GoodsInNumber { get; set; }
		/// <summary>
		/// ManufacturerCode (from usp_datalistnugget_GoodsInLine)
		/// </summary>
		public System.String ManufacturerCode { get; set; }
		/// <summary>
		/// DateReceived (from usp_datalistnugget_GoodsInLine)
		/// </summary>
		public System.DateTime DateReceived { get; set; }
		/// <summary>
		/// ReceiverName (from usp_datalistnugget_GoodsInLine)
		/// </summary>
		public System.String ReceiverName { get; set; }
		/// <summary>
		/// PurchaseOrderNo (from usp_datalistnugget_GoodsInLine)
		/// </summary>
		public System.Int32? PurchaseOrderNo { get; set; }
		/// <summary>
		/// DeliveryDate (from usp_datalistnugget_GoodsInLine)
		/// </summary>
		public System.DateTime? DeliveryDate { get; set; }
		/// <summary>
		/// PurchaseOrderNumber (from usp_datalistnugget_GoodsInLine)
		/// </summary>
		public System.Int32? PurchaseOrderNumber { get; set; }
		/// <summary>
		/// CompanyNo (from usp_datalistnugget_GoodsInLine)
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// CompanyName (from usp_datalistnugget_GoodsInLine)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// AirWayBill (from usp_datalistnugget_GoodsInLine)
		/// </summary>
		public System.String AirWayBill { get; set; }
		/// <summary>
		/// RowNum (from usp_datalistnugget_GoodsInLine)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_datalistnugget_GoodsInLine)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// QuantityOrdered (from usp_datalistnugget_GoodsInLine_AsReceivedPO)
		/// </summary>
		public System.Int32 QuantityOrdered { get; set; }
		/// <summary>
		/// ContactNo (from usp_datalistnugget_GoodsInLine_AsReceivedPO)
		/// </summary>
		public System.Int32 ContactNo { get; set; }
		/// <summary>
		/// ContactName (from usp_datalistnugget_GoodsInLine_AsReceivedPO)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// SupplierInvoice (from usp_datalistnugget_GoodsInLine_AsReceivedPO)
		/// </summary>
		public System.String SupplierInvoice { get; set; }
		/// <summary>
		/// InvoiceAmount (from usp_datalistnugget_GoodsInLine_AsReceivedPO)
		/// </summary>
		public System.Double? InvoiceAmount { get; set; }
		/// <summary>
		/// CurrencyNo (from usp_datalistnugget_GoodsInLine_AsReceivedPO)
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_datalistnugget_GoodsInLine_AsReceivedPO)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// CountingMethodDescription (from usp_select_GoodsInLine)
		/// </summary>
		public System.String CountingMethodDescription { get; set; }
		/// <summary>
		/// LineNotes (from usp_select_GoodsInLine)
		/// </summary>
		public System.String LineNotes { get; set; }
		/// <summary>
		/// ClientNo (from usp_select_GoodsInLine)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// PackageName (from usp_select_GoodsInLine)
		/// </summary>
		public System.String PackageName { get; set; }
		/// <summary>
		/// PackageDescription (from usp_select_GoodsInLine)
		/// </summary>
		public System.String PackageDescription { get; set; }
		/// <summary>
		/// ProductName (from usp_select_GoodsInLine)
		/// </summary>
		public System.String ProductName { get; set; }
		/// <summary>
		/// ProductDescription (from usp_select_GoodsInLine)
		/// </summary>
		public System.String ProductDescription { get; set; }
		/// <summary>
		/// ProductDutyCode (from usp_select_GoodsInLine)
		/// </summary>
		public System.String ProductDutyCode { get; set; }
		/// <summary>
		/// ManufacturerName (from usp_select_GoodsInLine)
		/// </summary>
		public System.String ManufacturerName { get; set; }
		/// <summary>
		/// CountryOfManufactureName (from usp_select_GoodsInLine)
		/// </summary>
		public System.String CountryOfManufactureName { get; set; }
		/// <summary>
		/// InspectorName (from usp_select_GoodsInLine)
		/// </summary>
		public System.String InspectorName { get; set; }
		/// <summary>
		/// CustomerRMANo (from usp_select_GoodsInLine)
		/// </summary>
		public System.Int32? CustomerRMANo { get; set; }
		/// <summary>
		/// CustomerRMANumber (from usp_select_GoodsInLine)
		/// </summary>
		public System.Int32? CustomerRMANumber { get; set; }
		/// <summary>
		/// CurrencyDescription (from usp_select_GoodsInLine)
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// ReceivedBy (from usp_select_GoodsInLine)
		/// </summary>
		public System.Int32 ReceivedBy { get; set; }
		/// <summary>
		/// DivisionNo (from usp_select_GoodsInLine)
		/// </summary>
		public System.Int32? DivisionNo { get; set; }
		/// <summary>
		/// TeamNo (from usp_select_GoodsInLine)
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// StockNo (from usp_select_GoodsInLine)
		/// </summary>
		public System.Int32? StockNo { get; set; }
		/// <summary>
		/// Reference (from usp_select_GoodsInLine)
		/// </summary>
		public System.String Reference { get; set; }
		/// <summary>
		/// LotName (from usp_select_GoodsInLine)
		/// </summary>
		public System.String LotName { get; set; }
		/// <summary>
		/// PurchaseOrderLineShipInCost (from usp_select_GoodsInLine)
		/// </summary>
		public System.Double PurchaseOrderLineShipInCost { get; set; }
		/// <summary>
		/// ChangedFields (from usp_select_GoodsInLine)
		/// </summary>
		public System.String ChangedFields { get; set; }
		/// <summary>
		/// UpdateStock (from usp_select_GoodsInLine)
		/// </summary>
		public System.Boolean? UpdateStock { get; set; }
		/// <summary>
		/// UpdateShipments (from usp_select_GoodsInLine)
		/// </summary>
		public System.Boolean? UpdateShipments { get; set; }
        //[001] code start
        /// <summary>
        /// CustomerPart
        /// </summary>
        public System.String CustomerPart { get; set; }
        /// <summary>
        /// SalesOrderNumber
        /// </summary>
        public System.Int32? SalesOrderNumber { get; set; }
        /// <summary>
        /// DatePicked
        /// </summary>
        public System.DateTime DatePicked { get; set; }
        /// <summary>
        /// InspectedByUser
        /// </summary>
        public System.String InspectedByUser { get; set; }
        //[001] code end
        /// <summary>
        /// HasAllocationOutward
        /// </summary>
        public System.Boolean? HasAllocationOutward { get; set; }
        /// <summary>
        /// NPRPrinted
        /// </summary>
        public System.Boolean? NPRPrinted { get; set; }
      
          
        //[002] code start
        /// <summary>
        /// InspectorNameLabel
        /// </summary>
        public System.String InspectorNameLabel { get; set; }
        //[002] code end
  
        //[003] code start
        /// <summary>
        /// NPRIds
        /// </summary>
        public System.String NPRIds { get; set; }
        /// <summary>
        /// NPRNos
        /// </summary>
        public System.String NPRNos { get; set; }
        //[003] code end

        /// SupplierInvoiceExists
        /// </summary>
        public System.Boolean HasSupplierInvoiceExists { get; set; }

        /// HasStocksplit
        /// </summary>
        public System.Boolean HasStocksplit { get; set; }
        /// <summary>
        /// blnStockProvision
        /// </summary>
        public System.Boolean blnStockProvision { get; set; }

        /// <summary>
        /// PhysicalInspectedBy
        /// </summary>
        public System.Int32? PhysicalInspectedBy { get; set; }
        /// <summary>
        /// DatePhysicalInspected
        /// </summary>
        public System.DateTime? DatePhysicalInspected { get; set; }
        /// <summary>
        /// LotCode
        /// </summary>
        public System.String LotCode { get; set; }

        //[004] Code Start
        /// POSerialNo
        /// </summary>
        public System.Int16? POSerialNo { get; set; }
        //[004] Code End

        public int? InternalPurchaseOrderNumber { get; set; }
        public int? InternalPurchaseOrderId { get; set; }
        public int? IPOSupplier { get; set; }
        public string IPOSupplierName { get; set; }
        /// <summary>
        /// ClientPrice (from Table)
        /// </summary>
        public System.Double ClientPrice { get; set; }

        public string ClientName { get; set; }
        /// <summary>
        /// ClientLandedCost (from Table)
        /// </summary>
        public System.Double ClientLandedCost { get; set; }
        public System.Int32? ClientCurrencyNo { get; set; }
        public System.String ClientCurrencyCode { get; set; }

        public int IpoCount { get; set; }
        public System.Int32? IPOClientNo { get; set; }
        public System.Double? POBankFee { get; set; }
        /// <summary>
        /// CustomerPO
        /// </summary>
        public System.String CustomerPO { get; set; }	
        /// </summary>
        public System.String ClientBaseCurrencyCode { get; set; }	
        public System.Int32? ClientBaseCurrencyID { get; set; }	
        public System.DateTime? StockDate { get; set; }
        public System.Boolean? ProductInactive { get; set; }
        public System.Double? DutyRate { get; set; }

        public System.String SerialNo { get; set; }
        public int? SerialNoId { get; set; }
        public System.String SubGroup { get; set; }
        public System.Boolean? ReqSerialNo { get; set; }
        public System.Int32? SerialNoCount { get; set; }
        public System.String Status { get; set; }
        public System.Int32? InvoiceLineNo { get; set; }
        public System.String ReasonDate { get; set; }
        public System.String ReasonCode { get; set; }
        public System.String MSLLevel { get; set; }
        public System.Boolean? IsProdHazardous { get; set; }
        public System.Boolean? PrintHazardous { get; set; }
        public System.Int32 GIShipCostHistoryId { get; set; }

		#endregion

	}
}
