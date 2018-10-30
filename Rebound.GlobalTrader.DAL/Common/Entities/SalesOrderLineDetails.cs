/*
Marker     changed by      date         Remarks
[001]      Vinay           21/08/2012   ESMS Ref:54 - If SO line created from Quote line then create hyperlink from sales order to quote
[002]      Vinay           04/02/2014   CR:- Add AS9120 Requirement in GT application
[003]      Vinay           11/04/2018    [REB-11304]: CHG-570795 Hazarders product type
[004]      Aashu Singh     18/07/2018   REB-12614 :Sales order Confirmation requirements
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
	
	public class SalesOrderLineDetails {
		
		#region Constructors
		
		public SalesOrderLineDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// SalesOrderLineId (from Table)
		/// </summary>
		public System.Int32 SalesOrderLineId { get; set; }
		/// <summary>
		/// SalesOrderNo (from Table)
		/// </summary>
		public System.Int32 SalesOrderNo { get; set; }
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
		/// DatePromised (from Table)
		/// </summary>
		public System.DateTime DatePromised { get; set; }
		/// <summary>
		/// RequiredDate (from Table)
		/// </summary>
		public System.DateTime RequiredDate { get; set; }
		/// <summary>
		/// Instructions (from Table)
		/// </summary>
		public System.String Instructions { get; set; }
		/// <summary>
		/// ProductNo (from Table)
		/// </summary>
		public System.Int32? ProductNo { get; set; }
		/// <summary>
		/// Taxable (from Table)
		/// </summary>
		public System.String Taxable { get; set; }
		/// <summary>
		/// CustomerPart (from Table)
		/// </summary>
		public System.String CustomerPart { get; set; }
		/// <summary>
		/// Posted (from Table)
		/// </summary>
		public System.Boolean Posted { get; set; }
		/// <summary>
		/// ShipASAP (from Table)
		/// </summary>
		public System.Boolean ShipASAP { get; set; }
		/// <summary>
		/// Inactive (from Table)
		/// </summary>
		public System.Boolean Inactive { get; set; }
		/// <summary>
		/// Closed (from Table)
		/// </summary>
		public System.Boolean Closed { get; set; }
		/// <summary>
		/// ROHS (from Table)
		/// </summary>
		public System.Byte? ROHS { get; set; }
		/// <summary>
		/// ServiceNo (from Table)
		/// </summary>
		public System.Int32? ServiceNo { get; set; }
		/// <summary>
		/// StockNo (from Table)
		/// </summary>
		public System.Int32? StockNo { get; set; }
		/// <summary>
		/// Notes (from Table)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// FullCustomerPart (from Table)
		/// </summary>
		public System.String FullCustomerPart { get; set; }
		/// <summary>
		/// ServiceShipped (from Table)
		/// </summary>
		public System.Boolean ServiceShipped { get; set; }
		/// <summary>
		/// SalesOrderNumber (from usp_datalistnugget_SalesOrderLine)
		/// </summary>
		public System.Int32 SalesOrderNumber { get; set; }
		/// <summary>
		/// ManufacturerCode (from usp_datalistnugget_SalesOrderLine)
		/// </summary>
		public System.String ManufacturerCode { get; set; }
		/// <summary>
		/// QuantityShipped (from usp_datalistnugget_SalesOrderLine)
		/// </summary>
		public System.Int32 QuantityShipped { get; set; }
		/// <summary>
		/// CompanyNo (from usp_datalistnugget_SalesOrderLine)
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// CompanyName (from usp_datalistnugget_SalesOrderLine)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// ContactNo (from usp_datalistnugget_SalesOrderLine)
		/// </summary>
		public System.Int32 ContactNo { get; set; }
		/// <summary>
		/// ContactName (from usp_datalistnugget_SalesOrderLine)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// DateOrdered (from usp_datalistnugget_SalesOrderLine)
		/// </summary>
		public System.DateTime DateOrdered { get; set; }
		/// <summary>
		/// CustomerPO (from usp_datalistnugget_SalesOrderLine)
		/// </summary>
		public System.String CustomerPO { get; set; }
		/// <summary>
		/// RowNum (from usp_datalistnugget_SalesOrderLine)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_datalistnugget_SalesOrderLine)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// Status (from usp_datalistnugget_SalesOrderLine)
		/// </summary>
		public System.Int32? Status { get; set; }
		/// <summary>
		/// QuantityAllocated (from usp_datalistnugget_SalesOrderLine_AllForShipping)
		/// </summary>
		public System.Int32? QuantityAllocated { get; set; }
		/// <summary>
		/// AllocationId (from usp_datalistnugget_SalesOrderLine_AllForShipping)
		/// </summary>
		public System.Int32? AllocationId { get; set; }
		/// <summary>
		/// QuantityOrdered (from usp_datalistnugget_SalesOrderLine_AllForShipping)
		/// </summary>
		public System.Int32 QuantityOrdered { get; set; }
		/// <summary>
		/// QuantityInStock (from usp_datalistnugget_SalesOrderLine_AllForShipping)
		/// </summary>
		public System.Int32? QuantityInStock { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_datalistnugget_SalesOrderLine_as_PurchaseRequisition)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// BackOrderQuantity (from usp_datalistnugget_SalesOrderLine_as_PurchaseRequisition)
		/// </summary>
		public System.Int32 BackOrderQuantity { get; set; }
		/// <summary>
		/// AllocatedQuantity (from usp_datalistnugget_SalesOrderLine_ReadyToShip)
		/// </summary>
		public System.Int32? AllocatedQuantity { get; set; }
		/// <summary>
		/// SalesmanName (from usp_itemsearch_SalesOrderLine)
		/// </summary>
		public System.String SalesmanName { get; set; }
		/// <summary>
		/// SalesOrderId (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.Int32 SalesOrderId { get; set; }
		/// <summary>
		/// CurrencyDate (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.DateTime? CurrencyDate { get; set; }
		/// <summary>
		/// ClientNo (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// Salesman (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.Int32 Salesman { get; set; }
		/// <summary>
		/// DivisionNo (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.Int32 DivisionNo { get; set; }
		/// <summary>
		/// TeamNo (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// LineValue (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.Double LineValue { get; set; }
		/// <summary>
		/// ProductName (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.String ProductName { get; set; }
		/// <summary>
		/// ProductDescription (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.String ProductDescription { get; set; }
		/// <summary>
		/// ManufacturerName (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.String ManufacturerName { get; set; }
		/// <summary>
		/// PackageName (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.String PackageName { get; set; }
		/// <summary>
		/// PackageDescription (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.String PackageDescription { get; set; }
		/// <summary>
		/// Paid (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.Boolean Paid { get; set; }
		/// <summary>
		/// TermsNo (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.Int32 TermsNo { get; set; }
		/// <summary>
		/// ShipViaNo (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.Int32? ShipViaNo { get; set; }
		/// <summary>
		/// ShipToAddressNo (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.Int32? ShipToAddressNo { get; set; }
		/// <summary>
		/// Unauthorised (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.Int32 Unauthorised { get; set; }
		/// <summary>
		/// TermsName (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.String TermsName { get; set; }
		/// <summary>
		/// InAdvance (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.Boolean InAdvance { get; set; }
		/// <summary>
		/// CurrencyNo (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }
		/// <summary>
		/// CurrencyDescription (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// SalesOrderValue (from usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter)
		/// </summary>
		public System.Double? SalesOrderValue { get; set; }
		/// <summary>
		/// FullName (from usp_list_SalesOrderLine_Ship_by_Client_with_filter)
		/// </summary>
		public System.String FullName { get; set; }
		/// <summary>
		/// OnStop (from usp_list_SalesOrderLine_Ship_by_Client_with_filter)
		/// </summary>
		public System.Boolean? OnStop { get; set; }
		/// <summary>
		/// CreditLimit (from usp_list_SalesOrderLine_Ship_by_Client_with_filter)
		/// </summary>
		public System.Double CreditLimit { get; set; }
		/// <summary>
		/// Balance (from usp_list_SalesOrderLine_Ship_by_Client_with_filter)
		/// </summary>
		public System.Double Balance { get; set; }
		/// <summary>
		/// LineNotes (from usp_select_SalesOrderLine)
		/// </summary>
		public System.String LineNotes { get; set; }
		/// <summary>
		/// ExchangeRate (from usp_select_SalesOrderLine)
		/// </summary>
		public System.Double? ExchangeRate { get; set; }
		/// <summary>
		/// Location (from usp_select_SalesOrderLine_Allocation)
		/// </summary>
		public System.String Location { get; set; }
		/// <summary>
		/// DeliveryDate (from usp_select_SalesOrderLine_Allocation)
		/// </summary>
		public System.DateTime? DeliveryDate { get; set; }

        public DateTime? OriginalEntryDate { get; set; }

        public int? ClientCurrencyNo { get; set; }
		/// <summary>
		/// PurchaseOrderId (from usp_select_SalesOrderLine_Allocation)
		/// </summary>
		public System.Int32? PurchaseOrderId { get; set; }
		/// <summary>
		/// PurchaseOrderNumber (from usp_select_SalesOrderLine_Allocation)
		/// </summary>
		public System.Int32? PurchaseOrderNumber { get; set; }
		/// <summary>
		/// WarehouseNo (from usp_select_SalesOrderLine_Allocation)
		/// </summary>
		public System.Int32? WarehouseNo { get; set; }
		/// <summary>
		/// WarehouseName (from usp_select_SalesOrderLine_Allocation)
		/// </summary>
		public System.String WarehouseName { get; set; }
		/// <summary>
		/// SupplierNo (from usp_select_SalesOrderLine_Allocation)
		/// </summary>
		public System.Int32? SupplierNo { get; set; }
		/// <summary>
		/// SupplierName (from usp_select_SalesOrderLine_Allocation)
		/// </summary>
		public System.String SupplierName { get; set; }
		/// <summary>
		/// GoodsInLineNo (from usp_select_SalesOrderLine_Allocation)
		/// </summary>
		public System.Int32? GoodsInLineNo { get; set; }
		/// <summary>
		/// GoodsInNo (from usp_select_SalesOrderLine_Allocation)
		/// </summary>
		public System.Int32? GoodsInNo { get; set; }
		/// <summary>
		/// GoodsInNumber (from usp_select_SalesOrderLine_Allocation)
		/// </summary>
		public System.Int32? GoodsInNumber { get; set; }
		/// <summary>
		/// TermsInAdvanceOK (from usp_select_SalesOrderLine_ShippingStatusInfo)
		/// </summary>
		public System.Int32 TermsInAdvanceOK { get; set; }
		/// <summary>
		/// CreditLimitOK (from usp_select_SalesOrderLine_ShippingStatusInfo)
		/// </summary>
		public System.Int32 CreditLimitOK { get; set; }
		/// <summary>
		/// StockUnavailable (from usp_select_SalesOrderLine_ShippingStatusInfo)
		/// </summary>
		public System.Boolean StockUnavailable { get; set; }
		/// <summary>
		/// SalesOrderClosed (from usp_select_SalesOrderLine_ShippingStatusInfo)
		/// </summary>
		public System.Boolean SalesOrderClosed { get; set; }
		/// <summary>
		/// GoodsInInspected (from usp_select_SalesOrderLine_ShippingStatusInfo)
		/// </summary>
		public System.Int32 GoodsInInspected { get; set; }
		/// <summary>
		/// CompanyOnStop (from usp_select_SalesOrderLine_ShippingStatusInfo)
		/// </summary>
		public System.Boolean? CompanyOnStop { get; set; }
		/// <summary>
		/// ServiceCost (from usp_selectAll_SalesOrderLine_for_SalesOrder)
		/// </summary>
		public System.Double? ServiceCost { get; set; }
		/// <summary>
		/// ServicePrice (from usp_selectAll_SalesOrderLine_for_SalesOrder)
		/// </summary>
		public System.Double? ServicePrice { get; set; }
		/// <summary>
		/// ReadyToShip (from usp_selectAll_SalesOrderLine_for_Shipping)
		/// </summary>
		public System.Boolean? ReadyToShip { get; set; }
		/// <summary>
		/// ShipViaName (from usp_selectAll_SalesOrderLine_from_GoodsInLine_for_Docket)
		/// </summary>
		public System.String ShipViaName { get; set; }
		/// <summary>
		/// EarliestDatePromised (from usp_selectAll_SalesOrderLine_from_GoodsInLine_for_Docket)
		/// </summary>
		public System.DateTime EarliestDatePromised { get; set; }
		/// <summary>
		/// NumberOfLines (from usp_selectAll_SalesOrderLine_from_GoodsInLine_for_Docket)
		/// </summary>
		public System.Int32? NumberOfLines { get; set; }
		/// <summary>
		/// LandedCost (from usp_selectAll_SalesOrderLine_ReportManualStock)
		/// </summary>
		public System.Double LandedCost { get; set; }
		/// <summary>
		/// ResalePrice (from usp_selectAll_SalesOrderLine_ReportManualStock)
		/// </summary>
		public System.Double? ResalePrice { get; set; }
		/// <summary>
		/// SupplierPart (from usp_selectAll_SalesOrderLine_ReportManualStock)
		/// </summary>
		public System.String SupplierPart { get; set; }
		/// <summary>
		/// PurchaseOrderLineNo (from usp_selectAll_SalesOrderLine_ReportPO)
		/// </summary>
		public System.Int32? PurchaseOrderLineNo { get; set; }
		/// <summary>
		/// PurchasePrice (from usp_selectAll_SalesOrderLine_ReportPO)
		/// </summary>
		public System.Double? PurchasePrice { get; set; }
		/// <summary>
		/// PurchaseOrderNo (from usp_selectAll_SalesOrderLine_ReportPO)
		/// </summary>
		public System.Int32? PurchaseOrderNo { get; set; }
		/// <summary>
		/// CountryName (from usp_selectAll_SalesOrderLine_ReportPO)
		/// </summary>
		public System.String CountryName { get; set; }
		/// <summary>
		/// Duty (from usp_selectAll_SalesOrderLine_ReportPO)
		/// </summary>
		public System.Boolean? Duty { get; set; }
		/// <summary>
		/// DutyRate (from usp_selectAll_SalesOrderLine_ReportPO)
		/// </summary>
		public System.Double? DutyRate { get; set; }
		/// <summary>
		/// QuantitySupplied (from usp_selectAll_SalesOrderLine_ReportPO)
		/// </summary>
		public System.Int32? QuantitySupplied { get; set; }
		/// <summary>
		/// ShipInCost (from usp_selectAll_SalesOrderLine_ReportPO)
		/// </summary>
		public System.Double ShipInCost { get; set; }
		/// <summary>
		/// SupplierType (from usp_selectAll_SalesOrderLine_ReportPO)
		/// </summary>
		public System.String SupplierType { get; set; }
		/// <summary>
		/// DateReceived (from usp_selectAll_SalesOrderLine_ReportPOStock)
		/// </summary>
		public System.DateTime DateReceived { get; set; }
		/// <summary>
		/// InvoiceDate (from usp_selectAll_SalesOrderLine_ReportShipped)
		/// </summary>
		public System.DateTime InvoiceDate { get; set; }
		/// <summary>
		/// Account (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.String Account { get; set; }
		/// <summary>
		/// Freight (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Double Freight { get; set; }
		/// <summary>
		/// TaxNo (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Int32 TaxNo { get; set; }
		/// <summary>
		/// ShippingCost (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Double? ShippingCost { get; set; }
		/// <summary>
		/// StatusNo (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Int32? StatusNo { get; set; }
		/// <summary>
		/// SaleTypeNo (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Int32? SaleTypeNo { get; set; }
		/// <summary>
		/// Salesman2 (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Int32? Salesman2 { get; set; }
		/// <summary>
		/// Salesman2Percent (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Double Salesman2Percent { get; set; }
		/// <summary>
		/// AuthorisedBy (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Int32? AuthorisedBy { get; set; }
		/// <summary>
		/// DateAuthorised (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.DateTime? DateAuthorised { get; set; }
		/// <summary>
		/// IncotermNo (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Int32? IncotermNo { get; set; }
		/// <summary>
		/// CreatedBy (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Int32? CreatedBy { get; set; }
		/// <summary>
		/// CreateDate (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.DateTime? CreateDate { get; set; }
		/// <summary>
		/// InvoiceId (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Int32 InvoiceId { get; set; }
		/// <summary>
		/// InvoiceNumber (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Int32 InvoiceNumber { get; set; }
		/// <summary>
		/// CompanyShipTo (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.String CompanyShipTo { get; set; }
		/// <summary>
		/// CompanyBillTo (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.String CompanyBillTo { get; set; }
		/// <summary>
		/// FreeOnBoard (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.String FreeOnBoard { get; set; }
		/// <summary>
		/// Boxes (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Int32? Boxes { get; set; }
		/// <summary>
		/// Weight (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Double? Weight { get; set; }
		/// <summary>
		/// DimensionalWeight (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Double? DimensionalWeight { get; set; }
		/// <summary>
		/// WeightInPounds (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Boolean WeightInPounds { get; set; }
		/// <summary>
		/// AirWayBill (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.String AirWayBill { get; set; }
		/// <summary>
		/// ShippedBy (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Int32? ShippedBy { get; set; }
		/// <summary>
		/// Printed (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Int32? Printed { get; set; }
		/// <summary>
		/// SupplierRMANo (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Int32? SupplierRMANo { get; set; }
		/// <summary>
		/// ShippingNotes (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.String ShippingNotes { get; set; }
		/// <summary>
		/// Exported (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Boolean Exported { get; set; }
		/// <summary>
		/// InvoicePaid (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Boolean InvoicePaid { get; set; }
		/// <summary>
		/// CofCNotes (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.String CofCNotes { get; set; }
		/// <summary>
		/// BillToAddressNo (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Int32? BillToAddressNo { get; set; }
		/// <summary>
		/// DivisionNo2 (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.Int32? DivisionNo2 { get; set; }
		/// <summary>
		/// DateExported (from usp_selectAll_SalesOrderLine_service_for_Invoice)
		/// </summary>
		public System.DateTime? DateExported { get; set; }
		/// <summary>
		/// ClientName (from usp_source_SalesOrderLine)
		/// </summary>
		public System.String ClientName { get; set; }
		/// <summary>
		/// ClientDataVisibleToOthers (from usp_source_SalesOrderLine)
		/// </summary>
		public System.Boolean? ClientDataVisibleToOthers { get; set; }
        //[001] code start
        /// <summary>
        /// QuoteLineNo
        /// </summary>
        public System.Int32? QuoteLineNo { get; set; }
        //[001] code end
        //[002] code start
        /// <summary>
        /// ProductSource
        /// </summary>
        public System.Byte? ProductSource { get; set; }
        //[002] code end
        /// <summary>
        /// blnCRMA
        /// </summary>
        public System.Boolean? blnCRMA { get; set; }
        /// <summary>
        /// SerialNo
        /// </summary>
        public System.Int16? SerialNo { get; set; }


        public int? POHubSupplierNo { get; set; }
        public int? POQuoteLineNo { get; set; }
        public int? SourcingResultNo { get; set; }
        public bool IsIPOHeaderCreated { get; set; }
        public int? InternalPurchaseOrderNumber { get; set; }
        public bool IsIPO { get; set; }
        public bool IsChecked { get; set; }

        public double? EstimatedShippingCost { get; set; }
        /// <summary>
        /// ClientSupplierNo 
        /// </summary>
        public System.Int32? ClientSupplierNo { get; set; }
        /// <summary>
        /// ClientSupplierName 
        /// </summary>
        public System.String ClientSupplierName { get; set; }

        public int? SourceingResultAttachedBy { get; set; }
        public string IPOSupplierName { get; set; }
        public int InternalPurchaseOrderNo { get; set; }
        public string IPOSupplierType { get; set; }

        public double? ClientLandedCost { get; set; }

        public string CreditStatus { get; set; }
        public System.Int32? IPOApprovedBy { get; set; }
        public System.Int32? CloneID { get; set; }
        public System.Boolean? IsIPOExist { get; set; }
        public System.DateTime? PODeliveryDate { get; set; }
        public System.Boolean? IsIPOAndPOOpen { get; set; }
        public System.Boolean? IsIPOPOExist { get; set; }
        /// <summary>
        /// SourcingResultUsedByOther
        /// </summary>
        public System.Boolean? SourcingResultUsedByOther { get; set; }
        /// <summary>
        /// ClientCode
        /// </summary>
        public System.String ClientCode { get; set; }
        /// <summary>
        /// PurchaseBuyCurrencyNo
        /// </summary>
        public int? PurchaseBuyCurrencyNo { get; set; }
        public System.Int32? LinkMultiCurrencyNo { get; set; }
        public System.DateTime PODateOrdered { get; set; }
        /// <summary>
        /// IPOs
        /// </summary>
        public System.String IPOs { get; set; }
        /// <summary>
        /// ReceivingNotes
        /// </summary>
        public System.String ReceivingNotes { get; set; }
        public System.Boolean? ProductInactive { get; set; }

        public System.String DutyCode { get; set; }
        public System.Double? IPOPrice { get; set; }
        public System.String IPOPriceWithCurrency { get; set; }

        /// <summary>
        /// SerialNo
        /// </summary>
        public System.Int16? CloneSerialNo { get; set; }
        public System.Boolean? ReqSerialNumber { get; set; }
        public System.String MSLLevel { get; set; }
        public System.String ContractNo { get; set; }
      
        //[003] code start
        public System.Boolean? IsProdHazardous { get; set; }
        public System.Boolean? PrintHazardous { get; set; }
        //[003] code end
        //[004] start
        public System.Boolean IsConfirmed { get; set; }
        public System.DateTime? DateConfirmed { get; set; }
        //[004] end
		#endregion

	}
}
