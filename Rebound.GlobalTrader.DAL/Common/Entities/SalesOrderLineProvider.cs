/***********************************************************************************
Marker     Changed by      Date         Remarks
[001]      Vinay           21/08/2012   ESMS Ref:54 - If SO line created from Quote line then create hyperlink from sales order to quote.
[002]      Vinay           04/02/2014   CR:- Add AS9120 Requirement in GT application
[003]      Aashu Singh     18/07/2018   REB-12614 :Sales order Confirmation requirements
[004]      Aashu Singh     17-Aug-2018  Provision to add Global Security in Sales Order
*********************************************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL {
	
	public abstract class SalesOrderLineProvider : DataAccess {
		static private SalesOrderLineProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SalesOrderLineProvider Instance {
			get {
				if (_instance == null) _instance = (SalesOrderLineProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.SalesOrderLines.ProviderType));
				return _instance;
			}
		}
		public SalesOrderLineProvider() {
			this.ConnectionString = Globals.Settings.SalesOrderLines.ConnectionString;
            this.GTConnectionString = Globals.Settings.SalesOrderLines.GTConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// CountAsPurchaseRequisitionForClient
		/// Calls [usp_count_SalesOrderLine_as_PurchaseRequisition_for_Client]
		/// </summary>
		public abstract Int32 CountAsPurchaseRequisitionForClient(System.Int32? clientId);
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_SalesOrderLine]
		/// </summary>
        //[004] start
        public abstract List<SalesOrderLineDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.Int32? CompanySearch, System.String cmSearch, System.Int32? salesmanNo, System.String customerPoSearch, System.Boolean? recentOnly, System.Boolean? includeClosed, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo, System.Boolean? unauthorisedOnly, System.Int32? IncludeOrderSent, System.String ContractNo, Boolean IsGlobalLogin, System.Int32? clientSearch);
		/// <summary>
		/// DataListNuggetAllForShipping
		/// Calls [usp_datalistnugget_SalesOrderLine_AllForShipping]
		/// </summary>
        public abstract List<SalesOrderLineDetails> DataListNuggetAllForShipping(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanNo, System.String customerPoSearch, System.Boolean? recentOnly, System.Boolean? includeClosed, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo, System.Int32? clientSearch, Boolean IsGlobalLogin);
		/// <summary>
		/// DataListNuggetAsPurchaseRequisition
		/// Calls [usp_datalistnugget_SalesOrderLine_as_PurchaseRequisition]
		/// </summary>
		public abstract List<SalesOrderLineDetails> DataListNuggetAsPurchaseRequisition(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo);
		/// <summary>
		/// DataListNuggetReadyToShip
		/// Calls [usp_datalistnugget_SalesOrderLine_ReadyToShip]
		/// </summary>
        public abstract List<SalesOrderLineDetails> DataListNuggetReadyToShip(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanNo, System.String customerPoSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo, System.Int32? clientSearch, Boolean IsGlobalLogin);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_SalesOrderLine]
		/// </summary>
		public abstract bool Delete(System.Int32? salesOrderLineId);

        /// <summary>
        /// Create Clone
        /// Calls [usp_insert_Clone_SalesOrderLine]
        /// </summary>
        public abstract Int32 CreateCloneSOLine(System.Int32? salesOrderNo, System.Int32? quantity, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.DateTime? poDeleveryDate, System.Int32? updatedBy, int? sourcingResultNo, int? SalesOrderLineID, System.Boolean? IsIPO, System.Int32? InternalPurchaseOrderNo, System.String Notes, System.String Instruction, Int32? Flag, System.Byte? productSource,  out string Message);


        //[001],[002] code start
		/// <summary>
		/// Insert
		/// Calls [usp_insert_SalesOrderLine]
		/// </summary>
        public abstract Int32 Insert(System.Int32? salesOrderNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.String instructions, System.Int32? productNo, System.String taxable, System.String customerPart, System.Boolean? posted, System.Boolean? shipAsap, System.Int32? serviceNo, System.Int32? stockNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Int32? QuoteLineNo, System.Byte? productSource, int? sourcingResultNo, System.DateTime? poDeliveryDate, System.String mslLevel, System.String ContractNo, System.Boolean? printHazardous);
        //[001],[002] code end
		/// <summary>
		/// InsertFromQuoteLine
		/// Calls [usp_insert_SalesOrderLine_from_QuoteLine]
		/// </summary>
		public abstract Int32 InsertFromQuoteLine(System.Int32? quoteLineId, System.Int32? salesOrderNo, System.DateTime? dateOrdered, System.Int32? updatedBy);
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_SalesOrderLine]
		/// </summary>
        public abstract List<SalesOrderLineDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String customerPoSearch, System.Boolean? includeClosed, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo, bool? onlyFromIPO);
		/// <summary>
		/// ItemSearchAsPurchaseRequisition
		/// Calls [usp_itemsearch_SalesOrderLine_as_PurchaseRequisition]
		/// </summary>
		public abstract List<SalesOrderLineDetails> ItemSearchAsPurchaseRequisition(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Int32? salesmanSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo);
		/// <summary>
		/// ListForAuthorisationByClientWithFilter
		/// Calls [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
		/// </summary>
		public abstract List<SalesOrderLineDetails> ListForAuthorisationByClientWithFilter(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo);
		/// <summary>
		/// ListForAuthorisationByDivisionWithFilter
		/// Calls [usp_list_SalesOrderLine_ForAuthorisation_by_Division_with_filter]
		/// </summary>
		public abstract List<SalesOrderLineDetails> ListForAuthorisationByDivisionWithFilter(System.Int32? divisionId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo);
		/// <summary>
		/// ListForAuthorisationByLoginWithFilter
		/// Calls [usp_list_SalesOrderLine_ForAuthorisation_by_Login_with_filter]
		/// </summary>
		public abstract List<SalesOrderLineDetails> ListForAuthorisationByLoginWithFilter(System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo);
		/// <summary>
		/// ListForAuthorisationByTeamWithFilter
		/// Calls [usp_list_SalesOrderLine_ForAuthorisation_by_Team_with_filter]
		/// </summary>
		public abstract List<SalesOrderLineDetails> ListForAuthorisationByTeamWithFilter(System.Int32? teamId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo);
		/// <summary>
		/// ListShipByClientWithFilter
		/// Calls [usp_list_SalesOrderLine_Ship_by_Client_with_filter]
		/// </summary>
		public abstract List<SalesOrderLineDetails> ListShipByClientWithFilter(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Boolean? includeHistory, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo);
		/// <summary>
		/// ListShipByDivisionWithFilter
		/// Calls [usp_list_SalesOrderLine_Ship_by_Division_with_filter]
		/// </summary>
		public abstract List<SalesOrderLineDetails> ListShipByDivisionWithFilter(System.Int32? divisionId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Boolean? includeHistory, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo);
		/// <summary>
		/// ListShipByLoginWithFilter
		/// Calls [usp_list_SalesOrderLine_Ship_by_Login_with_filter]
		/// </summary>
		public abstract List<SalesOrderLineDetails> ListShipByLoginWithFilter(System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Boolean? includeHistory, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo);
		/// <summary>
		/// ListShipByTeamWithFilter
		/// Calls [usp_list_SalesOrderLine_Ship_by_Team_with_filter]
		/// </summary>
		public abstract List<SalesOrderLineDetails> ListShipByTeamWithFilter(System.Int32? teamId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Boolean? includeHistory, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo);
		/// <summary>
		/// Get
		/// Calls [usp_select_SalesOrderLine]
		/// </summary>
		public abstract SalesOrderLineDetails Get(System.Int32? salesOrderLineId);
		/// <summary>
		/// GetAllocation
		/// Calls [usp_select_SalesOrderLine_Allocation]
		/// </summary>
		public abstract SalesOrderLineDetails GetAllocation(System.Int32? salesOrderLineId, System.Int32? allocationId);
		/// <summary>
		/// GetAsPurchaseRequisitionForPage
		/// Calls [usp_select_SalesOrderLine_as_PurchaseRequisition_for_Page]
		/// </summary>
		public abstract SalesOrderLineDetails GetAsPurchaseRequisitionForPage(System.Int32? salesOrderLineId);
		/// <summary>
		/// GetShippingStatusInfo
		/// Calls [usp_select_SalesOrderLine_ShippingStatusInfo]
		/// </summary>
		public abstract SalesOrderLineDetails GetShippingStatusInfo(System.Int32? salesOrderLineId, System.Int32? allocationId);
		/// <summary>
		/// GetListClosedForSalesOrder
		/// Calls [usp_selectAll_SalesOrderLine_closed_for_SalesOrder]
		/// </summary>
		public abstract List<SalesOrderLineDetails> GetListClosedForSalesOrder(System.Int32? salesOrderId);
		/// <summary>
		/// GetListForSalesOrder
		/// Calls [usp_selectAll_SalesOrderLine_for_SalesOrder]
		/// </summary>
		public abstract List<SalesOrderLineDetails> GetListForSalesOrder(System.Int32? salesOrderId, System.Boolean? includeInactive);

        /// <summary>
        /// GetListForSalesOrder
        /// Calls [usp_selectAll_ConsolidateSalesOrderLine_for_SalesOrder]
        /// </summary>
        public abstract List<SalesOrderLineDetails> GetListForConsolidateSalesOrder(System.Int32? salesOrderId, System.Boolean? includeInactive);
        /// <summary>
        /// GetListForSerial
        /// Calls [usp_selectAll_SalesOrderLine_for_SerialNumber]
        /// </summary>
        public abstract List<SalesOrderLineDetails> GetListForSerial(System.Int32? salesOrderId);
		/// <summary>
		/// GetListForService
		/// Calls [usp_selectAll_SalesOrderLine_for_Service]
		/// </summary>
		public abstract List<SalesOrderLineDetails> GetListForService(System.Int32? serviceId);
		/// <summary>
		/// GetListForShipping
		/// Calls [usp_selectAll_SalesOrderLine_for_Shipping]
		/// </summary>
		public abstract List<SalesOrderLineDetails> GetListForShipping(System.Int32? salesOrderNo);
		/// <summary>
		/// GetListFromGoodsInLineForDocket
		/// Calls [usp_selectAll_SalesOrderLine_from_GoodsInLine_for_Docket]
		/// </summary>
		public abstract List<SalesOrderLineDetails> GetListFromGoodsInLineForDocket(System.Int32? goodsInLineNo);
		/// <summary>
		/// GetListOpenForSalesOrder
		/// Calls [usp_selectAll_SalesOrderLine_open_for_SalesOrder]
		/// </summary>
		public abstract List<SalesOrderLineDetails> GetListOpenForSalesOrder(System.Int32? salesOrderId);
		/// <summary>
		/// GetListReportManualStock
		/// Calls [usp_selectAll_SalesOrderLine_ReportManualStock]
		/// </summary>
		public abstract List<SalesOrderLineDetails> GetListReportManualStock(System.Int32? salesOrderLineId);
		/// <summary>
		/// GetListReportPO
		/// Calls [usp_selectAll_SalesOrderLine_ReportPO]
		/// </summary>
		public abstract List<SalesOrderLineDetails> GetListReportPO(System.Int32? salesOrderLineId);
		/// <summary>
		/// GetListReportPOStock
		/// Calls [usp_selectAll_SalesOrderLine_ReportPOStock]
		/// </summary>
		public abstract List<SalesOrderLineDetails> GetListReportPOStock(System.Int32? salesOrderLineId);
		/// <summary>
		/// GetListReportShipped
		/// Calls [usp_selectAll_SalesOrderLine_ReportShipped]
		/// </summary>
		public abstract List<SalesOrderLineDetails> GetListReportShipped(System.Int32? salesOrderLineId);
		/// <summary>
		/// GetListServiceForInvoice
		/// Calls [usp_selectAll_SalesOrderLine_service_for_Invoice]
		/// </summary>
		public abstract List<SalesOrderLineDetails> GetListServiceForInvoice(System.Int32? invoiceId);
		/// <summary>
		/// Source
		/// Calls [usp_source_SalesOrderLine]
		/// </summary>
        public abstract List<SalesOrderLineDetails> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool IsServerLocal);
        //[002] code start
		/// <summary>
		/// Update
		/// Calls [usp_update_SalesOrderLine]
		/// </summary>
        public abstract bool Update(System.Int32? salesOrderLineId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.String instructions, System.Int32? productNo, System.String taxable, System.String customerPart, System.Boolean? shipAsap, System.Boolean? inactive, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Byte? productSource, System.DateTime? poDeliveryDate, System.Int16? serialNo, System.String mslLevel, System.String ContractNo, System.Boolean? printHazardous, bool? isFormChanged);
        //[002] code end
		/// <summary>
		/// UpdateClose
		/// Calls [usp_update_SalesOrderLine_Close]
		/// </summary>
		public abstract bool UpdateClose(System.Int32? salesOrderLineId, System.Boolean? resetQuantity, System.Int32? updatedBy);
		/// <summary>
		/// UpdatePostOrUnpost
		/// Calls [usp_update_SalesOrderLine_Post_or_Unpost]
		/// </summary>
		public abstract bool UpdatePostOrUnpost(System.Int32? salesOrderLineId, System.Boolean? posted, System.Int32? updatedBy);
        public abstract Int32 SaveConfirmation(System.Int32 salesOrderLineId, int salesOrderId, int buttonClicked);
		#endregion
				
		/// <summary>
		/// Returns a new SalesOrderLineDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual SalesOrderLineDetails GetSalesOrderLineFromReader(DbDataReader reader) {
			SalesOrderLineDetails salesOrderLine = new SalesOrderLineDetails();
			if (reader.HasRows) {
				salesOrderLine.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0); //From: [Table]
				salesOrderLine.SalesOrderNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0); //From: [Table]
				salesOrderLine.FullPart = GetReaderValue_String(reader, "FullPart", ""); //From: [Table]
				salesOrderLine.Part = GetReaderValue_String(reader, "Part", ""); //From: [Table]
				salesOrderLine.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null); //From: [Table]
				salesOrderLine.DateCode = GetReaderValue_String(reader, "DateCode", ""); //From: [Table]
				salesOrderLine.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null); //From: [Table]
				salesOrderLine.Quantity = GetReaderValue_Int32(reader, "Quantity", 0); //From: [Table]
				salesOrderLine.Price = GetReaderValue_Double(reader, "Price", 0); //From: [Table]
				salesOrderLine.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue); //From: [Table]
				salesOrderLine.RequiredDate = GetReaderValue_DateTime(reader, "RequiredDate", DateTime.MinValue); //From: [Table]
				salesOrderLine.Instructions = GetReaderValue_String(reader, "Instructions", ""); //From: [Table]
				salesOrderLine.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null); //From: [Table]
				salesOrderLine.Taxable = GetReaderValue_String(reader, "Taxable", ""); //From: [Table]
				salesOrderLine.CustomerPart = GetReaderValue_String(reader, "CustomerPart", ""); //From: [Table]
				salesOrderLine.Posted = GetReaderValue_Boolean(reader, "Posted", false); //From: [Table]
				salesOrderLine.ShipASAP = GetReaderValue_Boolean(reader, "ShipASAP", false); //From: [Table]
				salesOrderLine.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				salesOrderLine.Closed = GetReaderValue_Boolean(reader, "Closed", false); //From: [Table]
				salesOrderLine.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0); //From: [Table]
				salesOrderLine.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null); //From: [Table]
				salesOrderLine.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null); //From: [Table]
				salesOrderLine.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				salesOrderLine.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				salesOrderLine.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				salesOrderLine.FullCustomerPart = GetReaderValue_String(reader, "FullCustomerPart", ""); //From: [Table]
				salesOrderLine.ServiceShipped = GetReaderValue_Boolean(reader, "ServiceShipped", false); //From: [Table]
				salesOrderLine.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0); //From: [usp_datalistnugget_SalesOrderLine]
				salesOrderLine.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", ""); //From: [usp_datalistnugget_SalesOrderLine]
				salesOrderLine.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0); //From: [usp_datalistnugget_SalesOrderLine]
				salesOrderLine.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [usp_datalistnugget_SalesOrderLine]
				salesOrderLine.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_datalistnugget_SalesOrderLine]
				salesOrderLine.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0); //From: [usp_datalistnugget_SalesOrderLine]
				salesOrderLine.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_datalistnugget_SalesOrderLine]
				salesOrderLine.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue); //From: [usp_datalistnugget_SalesOrderLine]
				salesOrderLine.CustomerPO = GetReaderValue_String(reader, "CustomerPO", ""); //From: [usp_datalistnugget_SalesOrderLine]
				salesOrderLine.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_datalistnugget_SalesOrderLine]
				salesOrderLine.Status = GetReaderValue_NullableInt32(reader, "Status", null); //From: [usp_datalistnugget_SalesOrderLine]
				salesOrderLine.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null); //From: [usp_datalistnugget_SalesOrderLine_AllForShipping]
				salesOrderLine.AllocationId = GetReaderValue_NullableInt32(reader, "AllocationId", null); //From: [usp_datalistnugget_SalesOrderLine_AllForShipping]
				salesOrderLine.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0); //From: [usp_datalistnugget_SalesOrderLine_AllForShipping]
				salesOrderLine.QuantityInStock = GetReaderValue_NullableInt32(reader, "QuantityInStock", null); //From: [usp_datalistnugget_SalesOrderLine_AllForShipping]
				salesOrderLine.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_datalistnugget_SalesOrderLine_as_PurchaseRequisition]
				salesOrderLine.BackOrderQuantity = GetReaderValue_Int32(reader, "BackOrderQuantity", 0); //From: [usp_datalistnugget_SalesOrderLine_as_PurchaseRequisition]
				salesOrderLine.AllocatedQuantity = GetReaderValue_NullableInt32(reader, "AllocatedQuantity", null); //From: [usp_datalistnugget_SalesOrderLine_ReadyToShip]
				salesOrderLine.SalesmanName = GetReaderValue_String(reader, "SalesmanName", ""); //From: [usp_itemsearch_SalesOrderLine]
				salesOrderLine.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.Salesman = GetReaderValue_Int32(reader, "Salesman", 0); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.LineValue = GetReaderValue_Double(reader, "LineValue", 0); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.ProductName = GetReaderValue_String(reader, "ProductName", ""); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.ProductDescription = GetReaderValue_String(reader, "ProductDescription", ""); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", ""); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.PackageName = GetReaderValue_String(reader, "PackageName", ""); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.PackageDescription = GetReaderValue_String(reader, "PackageDescription", ""); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.Paid = GetReaderValue_Boolean(reader, "Paid", false); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.Unauthorised = GetReaderValue_Int32(reader, "Unauthorised", 0); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.TermsName = GetReaderValue_String(reader, "TermsName", ""); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.InAdvance = GetReaderValue_Boolean(reader, "InAdvance", false); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.SalesOrderValue = GetReaderValue_NullableDouble(reader, "SalesOrderValue", null); //From: [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
				salesOrderLine.FullName = GetReaderValue_String(reader, "FullName", ""); //From: [usp_list_SalesOrderLine_Ship_by_Client_with_filter]
				salesOrderLine.OnStop = GetReaderValue_NullableBoolean(reader, "OnStop", null); //From: [usp_list_SalesOrderLine_Ship_by_Client_with_filter]
				salesOrderLine.CreditLimit = GetReaderValue_Double(reader, "CreditLimit", 0); //From: [usp_list_SalesOrderLine_Ship_by_Client_with_filter]
				salesOrderLine.Balance = GetReaderValue_Double(reader, "Balance", 0); //From: [usp_list_SalesOrderLine_Ship_by_Client_with_filter]
				salesOrderLine.LineNotes = GetReaderValue_String(reader, "LineNotes", ""); //From: [usp_select_SalesOrderLine]
				salesOrderLine.ExchangeRate = GetReaderValue_NullableDouble(reader, "ExchangeRate", null); //From: [usp_select_SalesOrderLine]
				salesOrderLine.Location = GetReaderValue_String(reader, "Location", ""); //From: [usp_select_SalesOrderLine_Allocation]
				salesOrderLine.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null); //From: [usp_select_SalesOrderLine_Allocation]
				salesOrderLine.PurchaseOrderId = GetReaderValue_NullableInt32(reader, "PurchaseOrderId", null); //From: [usp_select_SalesOrderLine_Allocation]
				salesOrderLine.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null); //From: [usp_select_SalesOrderLine_Allocation]
				salesOrderLine.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null); //From: [usp_select_SalesOrderLine_Allocation]
				salesOrderLine.WarehouseName = GetReaderValue_String(reader, "WarehouseName", ""); //From: [usp_select_SalesOrderLine_Allocation]
				salesOrderLine.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null); //From: [usp_select_SalesOrderLine_Allocation]
				salesOrderLine.SupplierName = GetReaderValue_String(reader, "SupplierName", ""); //From: [usp_select_SalesOrderLine_Allocation]
				salesOrderLine.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null); //From: [usp_select_SalesOrderLine_Allocation]
				salesOrderLine.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null); //From: [usp_select_SalesOrderLine_Allocation]
				salesOrderLine.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", null); //From: [usp_select_SalesOrderLine_Allocation]
				salesOrderLine.TermsInAdvanceOK = GetReaderValue_Int32(reader, "TermsInAdvanceOK", 0); //From: [usp_select_SalesOrderLine_ShippingStatusInfo]
				salesOrderLine.CreditLimitOK = GetReaderValue_Int32(reader, "CreditLimitOK", 0); //From: [usp_select_SalesOrderLine_ShippingStatusInfo]
				salesOrderLine.StockUnavailable = GetReaderValue_Boolean(reader, "StockUnavailable", false); //From: [usp_select_SalesOrderLine_ShippingStatusInfo]
				salesOrderLine.SalesOrderClosed = GetReaderValue_Boolean(reader, "SalesOrderClosed", false); //From: [usp_select_SalesOrderLine_ShippingStatusInfo]
				salesOrderLine.GoodsInInspected = GetReaderValue_Int32(reader, "GoodsInInspected", 0); //From: [usp_select_SalesOrderLine_ShippingStatusInfo]
				salesOrderLine.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null); //From: [usp_select_SalesOrderLine_ShippingStatusInfo]
				salesOrderLine.ServiceCost = GetReaderValue_NullableDouble(reader, "ServiceCost", null); //From: [usp_selectAll_SalesOrderLine_for_SalesOrder]
				salesOrderLine.ServicePrice = GetReaderValue_NullableDouble(reader, "ServicePrice", null); //From: [usp_selectAll_SalesOrderLine_for_SalesOrder]
				salesOrderLine.ReadyToShip = GetReaderValue_NullableBoolean(reader, "ReadyToShip", null); //From: [usp_selectAll_SalesOrderLine_for_Shipping]
				salesOrderLine.ShipViaName = GetReaderValue_String(reader, "ShipViaName", ""); //From: [usp_selectAll_SalesOrderLine_from_GoodsInLine_for_Docket]
				salesOrderLine.EarliestDatePromised = GetReaderValue_DateTime(reader, "EarliestDatePromised", DateTime.MinValue); //From: [usp_selectAll_SalesOrderLine_from_GoodsInLine_for_Docket]
				salesOrderLine.NumberOfLines = GetReaderValue_NullableInt32(reader, "NumberOfLines", null); //From: [usp_selectAll_SalesOrderLine_from_GoodsInLine_for_Docket]
				salesOrderLine.LandedCost = GetReaderValue_Double(reader, "LandedCost", 0); //From: [usp_selectAll_SalesOrderLine_ReportManualStock]
				salesOrderLine.ResalePrice = GetReaderValue_NullableDouble(reader, "ResalePrice", null); //From: [usp_selectAll_SalesOrderLine_ReportManualStock]
				salesOrderLine.SupplierPart = GetReaderValue_String(reader, "SupplierPart", ""); //From: [usp_selectAll_SalesOrderLine_ReportManualStock]
				salesOrderLine.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null); //From: [usp_selectAll_SalesOrderLine_ReportPO]
				salesOrderLine.PurchasePrice = GetReaderValue_NullableDouble(reader, "PurchasePrice", null); //From: [usp_selectAll_SalesOrderLine_ReportPO]
				salesOrderLine.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null); //From: [usp_selectAll_SalesOrderLine_ReportPO]
				salesOrderLine.CountryName = GetReaderValue_String(reader, "CountryName", ""); //From: [usp_selectAll_SalesOrderLine_ReportPO]
				salesOrderLine.Duty = GetReaderValue_NullableBoolean(reader, "Duty", null); //From: [usp_selectAll_SalesOrderLine_ReportPO]
				salesOrderLine.DutyRate = GetReaderValue_NullableDouble(reader, "DutyRate", null); //From: [usp_selectAll_SalesOrderLine_ReportPO]
				salesOrderLine.QuantitySupplied = GetReaderValue_NullableInt32(reader, "QuantitySupplied", null); //From: [usp_selectAll_SalesOrderLine_ReportPO]
				salesOrderLine.ShipInCost = GetReaderValue_Double(reader, "ShipInCost", 0); //From: [usp_selectAll_SalesOrderLine_ReportPO]
				salesOrderLine.SupplierType = GetReaderValue_String(reader, "SupplierType", ""); //From: [usp_selectAll_SalesOrderLine_ReportPO]
				salesOrderLine.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue); //From: [usp_selectAll_SalesOrderLine_ReportPOStock]
				salesOrderLine.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue); //From: [usp_selectAll_SalesOrderLine_ReportShipped]
				salesOrderLine.Account = GetReaderValue_String(reader, "Account", ""); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.Freight = GetReaderValue_Double(reader, "Freight", 0); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.SaleTypeNo = GetReaderValue_NullableInt32(reader, "SaleTypeNo", null); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.AuthorisedBy = GetReaderValue_NullableInt32(reader, "AuthorisedBy", null); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.DateAuthorised = GetReaderValue_NullableDateTime(reader, "DateAuthorised", null); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.CreatedBy = GetReaderValue_NullableInt32(reader, "CreatedBy", null); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.CreateDate = GetReaderValue_NullableDateTime(reader, "CreateDate", null); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.InvoiceId = GetReaderValue_Int32(reader, "InvoiceId", 0); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.CompanyShipTo = GetReaderValue_String(reader, "CompanyShipTo", ""); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.CompanyBillTo = GetReaderValue_String(reader, "CompanyBillTo", ""); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", ""); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.Boxes = GetReaderValue_NullableInt32(reader, "Boxes", null); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.Weight = GetReaderValue_NullableDouble(reader, "Weight", null); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.DimensionalWeight = GetReaderValue_NullableDouble(reader, "DimensionalWeight", null); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.WeightInPounds = GetReaderValue_Boolean(reader, "WeightInPounds", false); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.AirWayBill = GetReaderValue_String(reader, "AirWayBill", ""); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.ShippedBy = GetReaderValue_NullableInt32(reader, "ShippedBy", null); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.Printed = GetReaderValue_NullableInt32(reader, "Printed", null); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.ShippingNotes = GetReaderValue_String(reader, "ShippingNotes", ""); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.Exported = GetReaderValue_Boolean(reader, "Exported", false); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.InvoicePaid = GetReaderValue_Boolean(reader, "InvoicePaid", false); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.CofCNotes = GetReaderValue_String(reader, "CofCNotes", ""); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.BillToAddressNo = GetReaderValue_NullableInt32(reader, "BillToAddressNo", null); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.DivisionNo2 = GetReaderValue_NullableInt32(reader, "DivisionNo2", null); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.DateExported = GetReaderValue_NullableDateTime(reader, "DateExported", null); //From: [usp_selectAll_SalesOrderLine_service_for_Invoice]
				salesOrderLine.ClientName = GetReaderValue_String(reader, "ClientName", ""); //From: [usp_source_SalesOrderLine]
				salesOrderLine.ClientDataVisibleToOthers = GetReaderValue_NullableBoolean(reader, "ClientDataVisibleToOthers", null); //From: [usp_source_SalesOrderLine]
			}
			return salesOrderLine;
		}
	
		/// <summary>
		/// Returns a collection of SalesOrderLineDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<SalesOrderLineDetails> GetSalesOrderLineCollectionFromReader(DbDataReader reader) {
			List<SalesOrderLineDetails> salesOrderLines = new List<SalesOrderLineDetails>();
			while (reader.Read()) salesOrderLines.Add(GetSalesOrderLineFromReader(reader));
			return salesOrderLines;
		}
		
		
	}
}
