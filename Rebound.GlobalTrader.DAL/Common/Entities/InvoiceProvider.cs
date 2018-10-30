/*
Marker     Changed by      Date         Remarks
[001]      Vinay           13/07/2012   Rebound- Invoice bulk Emailer
[002]      Vinay           23/08/2012   Customize the invoice control for exported record, Set Exported=1
[003]      Vinay           21/09/2012   Add expoted only filter
[004]      Vinay           12/10/2012   Upload PDF document for invoices
[005]      Vinay           22/11/2012   Add Failed only  filter
[006]      Vinay           29/11/2012   Apply a bank fee charge to the customers final invoice 
[007]      Aashu           01/06/2018   Quick Jump in Global Warehouse
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
	
	public abstract class InvoiceProvider : DataAccess {
		static private InvoiceProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public InvoiceProvider Instance {
			get {
				if (_instance == null) _instance = (InvoiceProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Invoices.ProviderType));
				return _instance;
			}
		}
		public InvoiceProvider() {
			this.ConnectionString = Globals.Settings.Invoices.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_Invoice_for_Client]
		/// </summary>
		public abstract Int32 CountForClient(System.Int32? clientId);
		/// <summary>
		/// CountForCompany
		/// Calls [usp_count_Invoice_for_Company]
		/// </summary>
		public abstract Int32 CountForCompany(System.Int32? companyId, System.Boolean? includePaid);
		/// <summary>
		/// CountOpenForCompany
		/// Calls [usp_count_Invoice_Open_for_Company]
		/// </summary>
		public abstract Int32 CountOpenForCompany(System.Int32? companyId);
        //[003],[005] code start
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_Invoice]
		/// </summary>
        public abstract List<InvoiceDetails> DataListNugget(System.Int32? clientId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String cmSearch, System.Int32? salesmanSearch, System.String customerPoSearch, System.Boolean? includePaid, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? invoiceDateFrom, System.DateTime? invoiceDateTo, System.Boolean? recentOnly, System.Boolean? exportedOnly, System.Boolean? failedOnly, System.Boolean? notExported);
        //[003] code end
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Invoice]
		/// </summary>
		public abstract bool Delete(System.Int32? invoiceId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Invoice]
		/// </summary>
		public abstract Int32 Insert(System.Int32? clientNo, System.Int32? salesOrderNo, System.DateTime? invoiceDate, System.String notes, System.String instructions, System.Int32? shipViaNo, System.String account, System.Double? shippingCost, System.Double? freight, System.String freeOnBoard, System.Int32? boxes, System.Double? weight, System.Double? dimensionalWeight, System.Boolean? weightInPounds, System.String airWayBill, System.Int32? shippedBy, System.Int32? printed, System.Int32? supplierRmaNo, System.String shippingNotes, System.Boolean? exported, System.Boolean? invoicePaid, System.Int32? salesOrderNumber, System.Int32? companyNo, System.Int32? contactNo, System.DateTime? dateOrdered, System.Int32? currencyNo, System.Int32? salesman, System.Int32? termsNo, System.Int32? taxNo, System.Int32? billToAddressNo, System.String companyBillTo, System.Int32? shipToAddressNo, System.String companyShipTo, System.Int32? divisionNo, System.String customerPo, System.Int32? salesman2, System.Double? salesman2Percent, System.Int32? incotermNo, System.Int32? updatedBy);
        //[001] code start
        /// <summary>
        /// Insert
        /// Calls [usp_insert_InvoiceEmail]
        /// </summary>
        /// <param name="InvoiceNo"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public abstract List<System.String> InsertIntoInvoiceEmail(System.String Invoices, System.Int32? updatedBy, System.Boolean? blnCOC);
        /// <summary>
        ///  InvoiceEmailNo
        /// </summary>
        /// <param name="InvoiceEmailNo"></param>
        /// <returns></returns>
        public abstract string GetEmailStatusByInvoiceEmailNo(System.Int32? InvoiceEmailNo);
        //[001] code end

		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_Invoice]
		/// </summary>
		public abstract List<InvoiceDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String customerPoSearch, System.Boolean? includePaid, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? invoiceDateFrom, System.DateTime? invoiceDateTo,System.Int32? Exported);
		/// <summary>
		/// Get
		/// Calls [usp_select_Invoice]
		/// </summary>
		public abstract InvoiceDetails Get(System.Int32? invoiceId);
		/// <summary>
		/// GetByNumber
		/// Calls [usp_select_Invoice_by_Number]
		/// </summary>
		public abstract InvoiceDetails GetByNumber(System.Int32? invoiceNumber, System.Int32? clientNo);
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_Invoice_for_Page]
		/// </summary>
		public abstract InvoiceDetails GetForPage(System.Int32? invoiceId);
		/// <summary>
		/// GetForPrint
		/// Calls [usp_select_Invoice_for_Print]
		/// </summary>
		public abstract InvoiceDetails GetForPrint(System.Int32? invoiceId);
		/// <summary>
		/// GetIDByNumber
		/// Calls [usp_select_Invoice_ID_by_Number]
		/// </summary>
        //[007] start
        public abstract List<InvoiceDetails> GetIDByNumber(System.Int32? invoiceNumber, System.Int32? clientNo, System.Int32? isGlobalUser);
        //[007] end
		/// <summary>
		/// GetNextNumber
		/// Calls [usp_select_Invoice_NextNumber]
		/// </summary>
		public abstract InvoiceDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy);
		/// <summary>
		/// GetStatusText
		/// Calls [usp_select_Invoice_StatusText]
		/// </summary>
		public abstract InvoiceDetails GetStatusText(System.Int32? invoiceId);
		/// <summary>
		/// GetListForCompany
		/// Calls [usp_selectAll_Invoice_for_Company]
		/// </summary>
		public abstract List<InvoiceDetails> GetListForCompany(System.Int32? companyId, System.Boolean? includePaid);
		/// <summary>
		/// GetListOpenForCompany
		/// Calls [usp_selectAll_Invoice_Open_for_Company]
		/// </summary>
		public abstract List<InvoiceDetails> GetListOpenForCompany(System.Int32? companyId);
		/// <summary>
		/// Update
		/// Calls [usp_update_Invoice]
		/// </summary>
        public abstract bool Update(System.Int32? invoiceId, System.String notes, System.String instructions, System.String shippingNotes, System.String cofCnotes, System.Boolean? invoicePaid, System.Int32? salesman2, System.Double? salesman2Percent, System.Int32? boxes, System.Double? weight, System.Double? dimensionalWeight, System.Boolean? weightInPounds, System.String airWayBill, System.Double? shippingCost, System.Double? freight, System.Int32? shipViaNo, System.String customerPo, System.String account, System.Int32? currencyNo, System.Int32? salesman, System.Int32? termsNo, System.Int32? taxNo, System.Int32? billToAddressNo, System.String companyBillTo, System.Int32? shipToAddressNo, System.String companyShipTo, System.Int32? divisionNo, System.Int32? incotermNo, System.Int32? updatedBy, System.Double? ExchangeRate,System.DateTime? invoicePaidDate);
		/// <summary>
		/// UpdateExport
		/// Calls [usp_update_Invoice_Export]
		/// </summary>
		public abstract bool UpdateExport(System.Int32? invoiceId, System.Int32? exportedBy, System.Boolean? export);
        /// <summary>
        /// Update Shipping Info
        /// Calls [usp_update_InvoiceShippingInfo]
        /// </summary>
        public abstract bool UpdateShippingInfo(System.Int32? invoiceId, System.Int32? boxes, System.Double? weight, System.Double? dimensionalWeight, System.Boolean? weightInPounds, System.String airWayBill, System.Int32? updatedBy);

        // [004] code start
        /// <summary>
        /// GetPDFListForInvoice 
        /// Calls [usp_selectAll_PDF_for_Invoice]
        /// </summary>
        /// <param name="InvoiceNo"></param>
        /// <returns></returns>
        public abstract List<PDFDocumentDetails> GetPDFListForInvoice(System.Int32? InvoiceNo);
        /// <summary>
        /// Calls [usp_insert_InvoicePDF]
        /// </summary>
        /// <param name="InvoiceNo"></param>
        /// <param name="Caption"></param>
        /// <param name="FileName"></param>
        /// <param name="UpdatedBy"></param>
        /// <returns></returns>
        public abstract Int32 Insert(System.Int32? InvoiceNo, System.String Caption, System.String FileName, System.Int32? UpdatedBy);
        /// <summary>
        /// Calls [usp_delete_InvoicePDF]
        /// </summary>
        /// <param name="InvoicePdfId"></param>
        /// <returns></returns>
        public abstract bool DeleteInvoicePDF(System.Int32? InvoicePdfId);
       
        //[004] code start
        
        //[006] code start
        public abstract bool UpdateInvoiceBankFee(System.Int32 invoiceID, System.Double? invoiceBankFee);
        //[006] code end
		#endregion
				
		/// <summary>
		/// Returns a new InvoiceDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual InvoiceDetails GetInvoiceFromReader(DbDataReader reader) {
			InvoiceDetails invoice = new InvoiceDetails();
			if (reader.HasRows) {
				invoice.InvoiceId = GetReaderValue_Int32(reader, "InvoiceId", 0); //From: [Table]
				invoice.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				invoice.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0); //From: [Table]
				invoice.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null); //From: [Table]
				invoice.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue); //From: [Table]
				invoice.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				invoice.Instructions = GetReaderValue_String(reader, "Instructions", ""); //From: [Table]
				invoice.CompanyBillTo = GetReaderValue_String(reader, "CompanyBillTo", ""); //From: [Table]
				invoice.CompanyShipTo = GetReaderValue_String(reader, "CompanyShipTo", ""); //From: [Table]
				invoice.ShipViaNo = GetReaderValue_Int32(reader, "ShipViaNo", 0); //From: [Table]
				invoice.Account = GetReaderValue_String(reader, "Account", ""); //From: [Table]
				invoice.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null); //From: [Table]
				invoice.Freight = GetReaderValue_NullableDouble(reader, "Freight", null); //From: [Table]
				invoice.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", ""); //From: [Table]
				invoice.Boxes = GetReaderValue_NullableInt32(reader, "Boxes", null); //From: [Table]
				invoice.Weight = GetReaderValue_NullableDouble(reader, "Weight", null); //From: [Table]
				invoice.DimensionalWeight = GetReaderValue_NullableDouble(reader, "DimensionalWeight", null); //From: [Table]
				invoice.WeightInPounds = GetReaderValue_Boolean(reader, "WeightInPounds", false); //From: [Table]
				invoice.AirWayBill = GetReaderValue_String(reader, "AirWayBill", ""); //From: [Table]
				invoice.ShippedBy = GetReaderValue_NullableInt32(reader, "ShippedBy", null); //From: [Table]
				invoice.Printed = GetReaderValue_NullableInt32(reader, "Printed", null); //From: [Table]
				invoice.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null); //From: [Table]
				invoice.ShippingNotes = GetReaderValue_String(reader, "ShippingNotes", ""); //From: [Table]
				invoice.Exported = GetReaderValue_Boolean(reader, "Exported", false); //From: [Table]
				invoice.InvoicePaid = GetReaderValue_Boolean(reader, "InvoicePaid", false); //From: [Table]
				invoice.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null); //From: [Table]
				invoice.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0); //From: [Table]
				invoice.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				invoice.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				invoice.CustomerPO = GetReaderValue_String(reader, "CustomerPO", ""); //From: [Table]
				invoice.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null); //From: [Table]
				invoice.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null); //From: [Table]
				invoice.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null); //From: [Table]
				invoice.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null); //From: [Table]
				invoice.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null); //From: [Table]
				invoice.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null); //From: [Table]
				invoice.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null); //From: [Table]
				invoice.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null); //From: [Table]
				invoice.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null); //From: [Table]
				invoice.DateOrdered = GetReaderValue_NullableDateTime(reader, "DateOrdered", null); //From: [Table]
				invoice.CofCNotes = GetReaderValue_String(reader, "CofCNotes", ""); //From: [Table]
				invoice.BillToAddressNo = GetReaderValue_NullableInt32(reader, "BillToAddressNo", null); //From: [Table]
				invoice.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null); //From: [Table]
				invoice.DivisionNo2 = GetReaderValue_NullableInt32(reader, "DivisionNo2", null); //From: [Table]
				invoice.DateExported = GetReaderValue_NullableDateTime(reader, "DateExported", null); //From: [Table]
				invoice.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_itemsearch_Debit]
				invoice.SalesmanName = GetReaderValue_String(reader, "SalesmanName", ""); //From: [usp_datalistnugget_Invoice]
				invoice.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_select_Debit]
				invoice.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null); //From: [usp_itemsearch_Debit]
				invoice.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_itemsearch_Debit]
				invoice.CustomerCode = GetReaderValue_String(reader, "CustomerCode", ""); //From: [usp_datalistnugget_Invoice]
				invoice.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_select_Debit]
				invoice.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", ""); //From: [usp_datalistnugget_Invoice]
				invoice.TermsName = GetReaderValue_String(reader, "TermsName", ""); //From: [usp_datalistnugget_Invoice]
				invoice.ShippedByName = GetReaderValue_String(reader, "ShippedByName", ""); //From: [usp_datalistnugget_Invoice]
				invoice.DivisionName = GetReaderValue_String(reader, "DivisionName", ""); //From: [usp_select_Debit]
				invoice.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null); //From: [usp_select_Debit]
				invoice.TaxName = GetReaderValue_String(reader, "TaxName", ""); //From: [usp_select_Debit]
				invoice.VATNo = GetReaderValue_String(reader, "VATNo", ""); //From: [usp_datalistnugget_Invoice]
				invoice.ShipViaName = GetReaderValue_String(reader, "ShipViaName", ""); //From: [usp_select_GoodsIn]
				invoice.InvoiceValue = GetReaderValue_NullableDouble(reader, "InvoiceValue", null); //From: [usp_datalistnugget_Invoice]
				invoice.LandedCostValue = GetReaderValue_NullableDouble(reader, "LandedCostValue", null); //From: [usp_datalistnugget_Invoice]
				invoice.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null); //From: [usp_select_Debit]
				invoice.StatusText = GetReaderValue_String(reader, "StatusText", ""); //From: [usp_datalistnugget_Invoice]
				invoice.IncotermName = GetReaderValue_String(reader, "IncotermName", ""); //From: [usp_datalistnugget_Invoice]
				invoice.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_itemsearch_Debit]
				invoice.CompanyTelephone = GetReaderValue_String(reader, "CompanyTelephone", ""); //From: [usp_select_Debit_for_Print]
				invoice.CompanyFax = GetReaderValue_String(reader, "CompanyFax", ""); //From: [usp_select_Debit_for_Print]
				invoice.ContactEmail = GetReaderValue_String(reader, "ContactEmail", ""); //From: [usp_select_Debit_for_Print]
				invoice.PrintNotes = GetReaderValue_String(reader, "PrintNotes", ""); //From: [usp_select_Invoice_for_Print]
			}
			return invoice;
		}
	
		/// <summary>
		/// Returns a collection of InvoiceDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<InvoiceDetails> GetInvoiceCollectionFromReader(DbDataReader reader) {
			List<InvoiceDetails> invoices = new List<InvoiceDetails>();
			while (reader.Read()) invoices.Add(GetInvoiceFromReader(reader));
			return invoices;
		}

        public abstract List<GoodsInLineDetails> GetSerial(System.Int32? invoiceLineId);
	}
}