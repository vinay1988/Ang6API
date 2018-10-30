/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to upload pdf document for sales order section
[002]      Vinay           21/01/2014   CR:- Add AS9120 Requirement in GT application
[003]      Aashu Singh     03/07/2018   Add customer order value nugget on broker and sales tab
[004]      Aashu Singh      01/06/2018   Quick Jump in Global Warehouse 
[005]      Aashu Singh      13/08/2018   REB-12161:Credit Card Payments
[006]      Aashu Singh      29/08/2018   Show so payment attachment
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
using System.Collections.Generic;
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL {

	public abstract class SalesOrderProvider : DataAccess {
		static private SalesOrderProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SalesOrderProvider Instance {
			get {
				if (_instance == null) _instance = (SalesOrderProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.SalesOrders.ProviderType));
				return _instance;
			}
		}
		public SalesOrderProvider() {
			this.ConnectionString = Globals.Settings.SalesOrders.ConnectionString;
		}

		#region Method Registrations

		/// <summary>
		/// CountForClient
		/// Calls [usp_count_SalesOrder_for_Client]
		/// </summary>
		public abstract Int32 CountForClient(System.Int32? clientId);
		/// <summary>
		/// CountForCompany
		/// Calls [usp_count_SalesOrder_for_Company]
		/// </summary>
		public abstract Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeClosed);
		/// <summary>
		/// CountOpenForCompany
		/// Calls [usp_count_SalesOrder_open_for_Company]
		/// </summary>
		public abstract Int32 CountOpenForCompany(System.Int32? companyId);
		/// <summary>
		/// CountShippingForClient
		/// Calls [usp_count_SalesOrder_shipping_for_Client]
		/// </summary>
		public abstract Int32 CountShippingForClient(System.Int32? clientId);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_SalesOrder]
		/// </summary>
		public abstract bool Delete(System.Int32? salesOrderId);
        //[002] code start
        /// <summary>
        /// Insert
        /// Calls [usp_insert_SalesOrder]
        /// </summary>
        public abstract Int32 Insert(System.Int32? clientNo, System.Int32? companyNo, System.Int32? contactNo, System.DateTime? dateOrdered, System.Int32? currencyNo, System.Int32? salesman, System.Int32? termsNo, System.Int32? shipToAddressNo, System.Int32? shipViaNo, System.String account, System.Double? freight, System.String customerPo, System.Int32? divisionNo, System.Int32? taxNo, System.Double? shippingCost, System.String notes, System.String instructions, System.Boolean? paid, System.Int32? statusNo, System.Boolean? closed, System.Int32? salesman2, System.Double? salesman2Percent, System.Int32? incotermNo, System.Int32? authorisedBy, System.DateTime? dateAuthorised, System.Int32? updatedBy, System.Boolean? As9120);
        //[002] code end
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_SalesOrder]
		/// </summary>
		public abstract List<SalesOrderDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String customerPoSearch, System.Boolean? includeClosed, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo);
		/// <summary>
		/// Get
		/// Calls [usp_select_SalesOrder]
		/// </summary>
		public abstract SalesOrderDetails Get(System.Int32? salesOrderId);
		/// <summary>
		/// GetByNumber
		/// Calls [usp_select_SalesOrder_by_Number]
		/// </summary>
		public abstract SalesOrderDetails GetByNumber(System.Int32? salesOrderNumber, System.Int32? clientNo);
		/// <summary>
		/// GetDetailsForLineCalculations
		/// Calls [usp_select_SalesOrder_DetailsForLineCalculations]
		/// </summary>
		public abstract SalesOrderDetails GetDetailsForLineCalculations(System.Int32? salesOrderId);
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_SalesOrder_for_Page]
		/// </summary>
		public abstract SalesOrderDetails GetForPage(System.Int32? salesOrderId);
		/// <summary>
		/// GetForPrint
		/// Calls [usp_select_SalesOrder_for_Print]
		/// </summary>
		public abstract SalesOrderDetails GetForPrint(System.Int32? salesOrderId);
		/// <summary>
		/// GetIDByNumber
		/// Calls [usp_select_SalesOrder_ID_by_Number]
		/// </summary>
        //[003] start
        public abstract List<SalesOrderDetails> GetIDByNumber(System.Int32? salesOrderNumber, System.Int32? clientNo, System.Int32? isGlobalUser);
        //[003] end
		/// <summary>
		/// GetNextNumber
		/// Calls [usp_select_SalesOrder_NextNumber]
		/// </summary>
		public abstract SalesOrderDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy);
		/// <summary>
		/// GetOpenLineSummaryValues
		/// Calls [usp_select_SalesOrder_OpenLineSummaryValues]
		/// </summary>
		public abstract SalesOrderDetails GetOpenLineSummaryValues(System.Int32? salesOrderId);
		/// <summary>
		/// GetStatus
		/// Calls [usp_select_SalesOrder_Status]
		/// </summary>
		public abstract SalesOrderDetails GetStatus(System.Int32? salesOrderId);
		/// <summary>
		/// GetSummaryValues
		/// Calls [usp_select_SalesOrder_SummaryValues]
		/// </summary>
		public abstract SalesOrderDetails GetSummaryValues(System.Int32? salesOrderId);
		/// <summary>
		/// GetValueSummary
		/// Calls [usp_select_SalesOrder_ValueSummary]
		/// </summary>
		public abstract SalesOrderDetails GetValueSummary(System.Int32? salesOrderId);
		/// <summary>
		/// GetListForCompany
		/// Calls [usp_selectAll_SalesOrder_for_Company]
		/// </summary>
		public abstract List<SalesOrderDetails> GetListForCompany(System.Int32? companyId, System.Boolean? includeClosed);
		/// <summary>
		/// GetListOpenForCompany
		/// Calls [usp_selectAll_SalesOrder_open_for_Company]
		/// </summary>
		public abstract List<SalesOrderDetails> GetListOpenForCompany(System.Int32? companyId);
		/// <summary>
		/// GetListOpenForLogin
		/// Calls [usp_selectAll_SalesOrder_open_for_Login]
		/// </summary>
		public abstract List<SalesOrderDetails> GetListOpenForLogin(System.Int32? loginId, System.Int32? topToSelect);
        /// <summary>
        /// GetListOpenForLoginUnProcess
        /// Calls [usp_selectAll_SalesOrder_open_for_Login_UnProcess]
        /// </summary>
        public abstract List<SalesOrderDetails> GetListOpenForLoginUnProcess(System.Int32? loginId, System.Int32? topToSelect);
		/// <summary>
		/// GetListOverdueForCompany
		/// Calls [usp_selectAll_SalesOrder_overdue_for_Company]
		/// </summary>
		public abstract List<SalesOrderDetails> GetListOverdueForCompany(System.Int32? companyId);
		/// <summary>
		/// GetListOverdueForLogin
		/// Calls [usp_selectAll_SalesOrder_overdue_for_Login]
		/// </summary>
		public abstract List<SalesOrderDetails> GetListOverdueForLogin(System.Int32? loginId, System.Int32? topToSelect);
       	/// <summary>
		/// GetListReadyForClient
		/// Calls [usp_selectAll_SalesOrder_ready_for_Client]
		/// </summary>
		public abstract List<SalesOrderDetails> GetListReadyForClient(System.Int32? clientId, System.Int32? topToSelect);
		/// <summary>
		/// GetListShippedRecentlyForLogin
		/// Calls [usp_selectAll_SalesOrder_shipped_recently_for_Login]
		/// </summary>
		public abstract List<SalesOrderDetails> GetListShippedRecentlyForLogin(System.Int32? loginId, System.Int32? topToSelect);
		/// <summary>
		/// GetListShippedTodayForClient
		/// Calls [usp_selectAll_SalesOrder_shipped_today_for_Client]
		/// </summary>
		public abstract List<SalesOrderDetails> GetListShippedTodayForClient(System.Int32? clientId, System.Int32? topToSelect);
        //[002] code start
        /// <summary>
        /// Update
        /// Calls [usp_update_SalesOrder]
        /// </summary>
        public abstract bool Update(System.Int32? salesOrderId, System.Int32? contactNo, System.Int32? salesman, System.Int32? shipToAddressNo, System.Int32? shipViaNo, System.Int32? termsNo, System.String account, System.Double? freight, System.Double? shippingCost, System.String customerPo, System.Int32? divisionNo, System.String notes, System.String instructions, System.Boolean? paid, System.Int32? statusNo, System.Boolean? closed, System.Int32? saleTypeNo, System.Int32? salesman2, System.Double? salesman2Percent, System.Int32? incotermNo, System.Int32? TaxNo, System.Int32? updatedBy, System.Boolean? As9120,System.Int32? currencyNo);
        //[002] code end
		/// <summary>
		/// <summary>
		/// UpdateAuthorise
		/// Calls [usp_update_SalesOrder_Authorise]
		/// </summary>
		public abstract bool UpdateAuthorise(System.Int32? salesOrderId, System.Int32? authorisedBy, System.Boolean? authorise);
		/// <summary>
		/// UpdateClose
		/// Calls [usp_update_SalesOrder_Close]
		/// </summary>
		public abstract bool UpdateClose(System.Int32? salesOrderId, System.Boolean? resetQuantity, System.Int32? updatedBy);
		/// <summary>
		/// UpdateFromInvoice
		/// Calls [usp_update_SalesOrder_from_Invoice]
		/// </summary>
		public abstract bool UpdateFromInvoice(System.Int32? invoiceId, System.Int32? taxNo, System.Int32? currencyNo, System.Int32? updatedBy);
		/// <summary>
		/// UpdateUpdateCurrencyDateOnOpenOrdersForCurrency
		/// Calls [usp_update_SalesOrder_UpdateCurrencyDateOnOpenOrders_for_Currency]
		/// </summary>
		public abstract bool UpdateUpdateCurrencyDateOnOpenOrdersForCurrency(System.Int32? currencyNo, System.DateTime? currencyDate);
		/// <summary>
		/// UpdateAuthoriseAllUnauthorisedOrders
		/// Calls [usp_update_SalesOrder_AuthoriseAllUnauthorisedOrders]
		/// </summary>
		public abstract bool UpdateAuthoriseAllUnauthorisedOrders(System.Int32? clientNo, System.Int32? updatedBy);
        //[001] code start
        /// <summary>
        /// Get PDF list for sales order 
        /// Calls [usp_selectAll_PDF_for_SalesOrder]
        /// </summary>
        /// <param name="SalesOrderId"></param>
        /// <returns></returns>
        public abstract List<PDFDocumentDetails> GetPDFListForSalesOrder(System.Int32? SalesOrderId,System.String fileType);
        /// <summary>
        /// 
        /// Insert PDF for sales order
        /// Calls [usp_insert_SalesOrderPDF]
        /// </summary>
        /// <param name="SalesOrderId"></param>
        /// <param name="Caption"></param>
        /// <param name="FileName"></param>
        /// <param name="UpdatedBy"></param>
        /// <returns></returns>
        public abstract Int32 Insert(System.Int32? SalesOrderId, System.String Caption, System.String FileName, System.Int32? UpdatedBy, System.String FileType);
        /// <summary>
        /// Delete sales order pdf
        /// Calls[usp_delete_SalesOrderPDF]
        /// </summary>
        /// <param name="SalesOrderPdfId"></param>
        /// <returns></returns>
        public abstract bool DeleteSalesOrderPDF(System.Int32? SalesOrderPdfId);
       
        //[001] code end
        /// <summary>
        /// usp_Get_InvoiceNotExported
        /// </summary>
        /// <param name="comoanyNo"></param>
        /// <returns></returns>
        public abstract double GetInvoiceNotExported(System.Int32 comoanyNo);
        /// <summary>
        /// usp_Validate_ReadyToShipped_Total_Price
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public abstract Int32 ValidateReadyToShippedPrice(System.Int32 salesOrderID, System.String xml,System.Double? freight);
        //[006] start
        public abstract List<PDFDocumentDetails> GetSOPaymentAttachment(System.Int32 SalesOrderId);
        //[006] end
		#endregion

		/// <summary>
		/// Returns a new SalesOrderDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual SalesOrderDetails GetSalesOrderFromReader(DbDataReader reader) {
			SalesOrderDetails salesOrder = new SalesOrderDetails();
			if (reader.HasRows) {
				salesOrder.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0); //From: [Table]
				salesOrder.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0); //From: [Table]
				salesOrder.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				salesOrder.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [Table]
				salesOrder.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0); //From: [Table]
				salesOrder.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue); //From: [Table]
				salesOrder.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0); //From: [Table]
				salesOrder.Salesman = GetReaderValue_Int32(reader, "Salesman", 0); //From: [Table]
				salesOrder.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0); //From: [Table]
				salesOrder.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null); //From: [Table]
				salesOrder.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null); //From: [Table]
				salesOrder.Account = GetReaderValue_String(reader, "Account", ""); //From: [Table]
				salesOrder.Freight = GetReaderValue_Double(reader, "Freight", 0); //From: [Table]
				salesOrder.CustomerPO = GetReaderValue_String(reader, "CustomerPO", ""); //From: [Table]
				salesOrder.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0); //From: [Table]
				salesOrder.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0); //From: [Table]
				salesOrder.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null); //From: [Table]
				salesOrder.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				salesOrder.Instructions = GetReaderValue_String(reader, "Instructions", ""); //From: [Table]
				salesOrder.Paid = GetReaderValue_Boolean(reader, "Paid", false); //From: [Table]
				salesOrder.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null); //From: [Table]
				salesOrder.Closed = GetReaderValue_Boolean(reader, "Closed", false); //From: [Table]
				salesOrder.SaleTypeNo = GetReaderValue_NullableInt32(reader, "SaleTypeNo", null); //From: [Table]
				salesOrder.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null); //From: [Table]
				salesOrder.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0); //From: [Table]
				salesOrder.AuthorisedBy = GetReaderValue_NullableInt32(reader, "AuthorisedBy", null); //From: [Table]
				salesOrder.DateAuthorised = GetReaderValue_NullableDateTime(reader, "DateAuthorised", null); //From: [Table]
				salesOrder.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				salesOrder.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				salesOrder.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null); //From: [Table]
				salesOrder.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null); //From: [Table]
				salesOrder.CreatedBy = GetReaderValue_NullableInt32(reader, "CreatedBy", null); //From: [Table]
				salesOrder.CreateDate = GetReaderValue_NullableDateTime(reader, "CreateDate", null); //From: [Table]
				salesOrder.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_itemsearch_PurchaseOrder]
				salesOrder.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_itemsearch_PurchaseOrder]
				salesOrder.SalesmanName = GetReaderValue_String(reader, "SalesmanName", ""); //From: [usp_select_Quote]
				salesOrder.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_itemsearch_PurchaseOrder]
				salesOrder.ShippingCharge = GetReaderValue_NullableBoolean(reader, "ShippingCharge", null); //From: [usp_select_SalesOrder]
				salesOrder.CreditLimit = GetReaderValue_Double(reader, "CreditLimit", 0); //From: [usp_selectAll_PurchaseOrder_due_for_Client]
				salesOrder.Balance = GetReaderValue_Double(reader, "Balance", 0); //From: [usp_selectAll_PurchaseOrder_due_for_Client]
				salesOrder.CustomerCode = GetReaderValue_String(reader, "CustomerCode", ""); //From: [usp_select_SalesOrder]
				salesOrder.VATNo = GetReaderValue_String(reader, "VATNo", ""); //From: [usp_select_SalesOrder]
				salesOrder.SOCurrencyNo = GetReaderValue_Int32(reader, "SOCurrencyNo", 0); //From: [usp_select_SalesOrder]
				salesOrder.SOCurrencyCode = GetReaderValue_String(reader, "SOCurrencyCode", ""); //From: [usp_select_SalesOrder]
				salesOrder.SOCurrencyDescription = GetReaderValue_String(reader, "SOCurrencyDescription", ""); //From: [usp_select_SalesOrder]
				salesOrder.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_select_PurchaseOrder]
				salesOrder.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_select_PurchaseOrder]
				salesOrder.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", ""); //From: [usp_select_SalesOrder]
				salesOrder.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null); //From: [usp_select_SalesOrder]
				salesOrder.Team2No = GetReaderValue_NullableInt32(reader, "Team2No", null); //From: [usp_select_SalesOrder]
				salesOrder.TermsName = GetReaderValue_String(reader, "TermsName", ""); //From: [usp_select_PurchaseOrder]
				salesOrder.InAdvance = GetReaderValue_NullableBoolean(reader, "InAdvance", null); //From: [usp_select_SalesOrder]
				salesOrder.ShipViaName = GetReaderValue_String(reader, "ShipViaName", ""); //From: [usp_select_PurchaseOrder]
				salesOrder.PickUp = GetReaderValue_String(reader, "PickUp", ""); //From: [usp_select_SalesOrder]
				salesOrder.DivisionName = GetReaderValue_String(reader, "DivisionName", ""); //From: [usp_select_PurchaseOrder]
				salesOrder.TaxName = GetReaderValue_String(reader, "TaxName", ""); //From: [usp_select_PurchaseOrder]
				salesOrder.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null); //From: [usp_select_PurchaseOrder]
				salesOrder.Authoriser = GetReaderValue_String(reader, "Authoriser", ""); //From: [usp_select_SalesOrder]
				salesOrder.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null); //From: [usp_select_Quote]
				salesOrder.IncotermName = GetReaderValue_String(reader, "IncotermName", ""); //From: [usp_select_PurchaseOrder]
				salesOrder.LineSubTotal = GetReaderValue_NullableDouble(reader, "LineSubTotal", null); //From: [usp_select_SalesOrder]
				salesOrder.TotalTax = GetReaderValue_NullableDouble(reader, "TotalTax", null); //From: [usp_select_SalesOrder]
				salesOrder.TotalValue = GetReaderValue_NullableDouble(reader, "TotalValue", null); //From: [usp_select_SalesOrder]
				salesOrder.CompanyTelephone = GetReaderValue_String(reader, "CompanyTelephone", ""); //From: [usp_select_PurchaseOrder_for_Print]
				salesOrder.CompanyFax = GetReaderValue_String(reader, "CompanyFax", ""); //From: [usp_select_PurchaseOrder_for_Print]
				salesOrder.ContactEmail = GetReaderValue_String(reader, "ContactEmail", ""); //From: [usp_select_PurchaseOrder_for_Print]
				salesOrder.SalesOrderValue = GetReaderValue_NullableDouble(reader, "SalesOrderValue", null); //From: [usp_select_SalesOrder_ValueSummary]
				salesOrder.SalesOrderValueIncFreight = GetReaderValue_NullableDouble(reader, "SalesOrderValueIncFreight", null); //From: [usp_select_SalesOrder_ValueSummary]
				salesOrder.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0); //From: [usp_selectAll_SalesOrder_open_for_Login]
				salesOrder.Quantity = GetReaderValue_Int32(reader, "Quantity", 0); //From: [usp_selectAll_SalesOrder_open_for_Login]
				salesOrder.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0); //From: [usp_selectAll_SalesOrder_open_for_Login]
				salesOrder.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue); //From: [usp_selectAll_SalesOrder_open_for_Login]
				salesOrder.DaysOverdue = GetReaderValue_NullableInt32(reader, "DaysOverdue", null); //From: [usp_selectAll_PurchaseOrder_due_for_Client]
				salesOrder.InvoiceId = GetReaderValue_Int32(reader, "InvoiceId", 0); //From: [usp_selectAll_SalesOrder_shipped_recently_for_Login]
				salesOrder.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0); //From: [usp_selectAll_SalesOrder_shipped_recently_for_Login]
				salesOrder.InvoiceLineId = GetReaderValue_NullableInt32(reader, "InvoiceLineId", null); //From: [usp_selectAll_SalesOrder_shipped_recently_for_Login]
				salesOrder.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue); //From: [usp_selectAll_SalesOrder_shipped_recently_for_Login]
				salesOrder.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null); //From: [usp_selectAll_SalesOrder_shipped_recently_for_Login]
				salesOrder.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null); //From: [usp_selectAll_SalesOrder_shipped_recently_for_Login]
				salesOrder.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null); //From: [usp_selectAll_SalesOrder_shipped_recently_for_Login]
				salesOrder.FullCompanyName = GetReaderValue_String(reader, "FullCompanyName", ""); //From: [usp_selectAll_SalesOrder_shipped_recently_for_Login]
				salesOrder.Price = GetReaderValue_NullableDouble(reader, "Price", null); //From: [usp_selectAll_SalesOrder_shipped_recently_for_Login]
				salesOrder.FullPart = GetReaderValue_String(reader, "FullPart", ""); //From: [usp_selectAll_SalesOrder_shipped_recently_for_Login]
				salesOrder.FullCustomerPart = GetReaderValue_String(reader, "FullCustomerPart", ""); //From: [usp_selectAll_SalesOrder_shipped_recently_for_Login]
				salesOrder.Part = GetReaderValue_String(reader, "Part", ""); //From: [usp_selectAll_SalesOrder_shipped_recently_for_Login]
				salesOrder.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0); //From: [usp_selectAll_SalesOrder_shipped_recently_for_Login]
				salesOrder.CustomerPart = GetReaderValue_String(reader, "CustomerPart", ""); //From: [usp_selectAll_SalesOrder_shipped_recently_for_Login]
				salesOrder.DateCode = GetReaderValue_String(reader, "DateCode", ""); //From: [usp_selectAll_SalesOrder_shipped_recently_for_Login]
				salesOrder.InvoicePaid = GetReaderValue_Boolean(reader, "InvoicePaid", false); //From: [usp_selectAll_SalesOrder_shipped_recently_for_Login]
				salesOrder.Inactive = GetReaderValue_NullableBoolean(reader, "Inactive", null); //From: [usp_selectAll_SalesOrder_shipped_recently_for_Login]
			}
			return salesOrder;
		}

		/// <summary>
		/// Returns a collection of SalesOrderDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<SalesOrderDetails> GetSalesOrderCollectionFromReader(DbDataReader reader) {
			List<SalesOrderDetails> salesOrders = new List<SalesOrderDetails>();
			while (reader.Read()) salesOrders.Add(GetSalesOrderFromReader(reader));
			return salesOrders;
		}

            /// <summary>
        /// Get So Line from soID 
        /// Calls [usp_GetSoLines]
        /// </summary>
        public abstract List<SalesOrderLineDetails> GetSoLines(int salesOrderId);

        /// <summary>
        /// 0: Non-Consolidated
        /// 1: Consolidated
        /// Null: Ask confirmation
        /// UpdateConsolidated
        /// Calls [usp_update_SalesOrder_Consolidated]
        /// </summary>
        public abstract bool UpdateConsolidated(System.Int32? salesOrderId, System.Int32? consolidateStaus, System.Int32? updatedBy);

        public abstract Int32 InsertSerialNo(System.String subGroup, System.Int32? serialNo, System.Int32? soLineNo, System.Int32? updatedBy, out System.String validateMessage);

        public abstract List<GoodsInLineDetails> GetDataGrid(System.Int32? soLineNo ,System.Int32? updatedBy);

        public abstract Int32 InsertAllSerialNo(System.Int32? updatedBy);

        /// <summary>
        /// usp_attach_SerialNo_WithInvoice
        /// </summary>
        /// <param name="strSerialNoIds"></param>
        /// <param name="salesOrderLineNo"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public abstract bool AttachSerialNo(System.String strSerialNoIds, System.Int32? salesOrderLineNo, System.Int32? allocatedId, System.Int32? updatedBy);
        /// <summary>
        /// Get So Line from soID 
        /// Calls [usp_SentOrder]
        /// </summary>
        public abstract bool SentOrder(System.Int32? salesOrderId, System.Int32? updatedBy);
        //[003] start
        public abstract List<SalesOrderDetails> GetListCustomerOrderValue(System.Int32? loginId,System.Int32? clientId);
        //[005] start
        public abstract Int32 SaveSOPaymentInfo(System.Int32 salesOrderNumber, System.String receiptNo, System.String originalFilename,System.String generatedFilename, System.Int32 createdBy);
        //[005] end
	}
}
