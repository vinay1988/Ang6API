/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to upload pdf document for customerRMA section
[002]      Aashu Singh     01/06/2018   Quick Jump in Global Warehouse 
[003]      Aashu Singh     22/06/2018   Save internal log for CRMA
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
	
	public abstract class CustomerRmaProvider : DataAccess {
		static private CustomerRmaProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public CustomerRmaProvider Instance {
			get {
				if (_instance == null) _instance = (CustomerRmaProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.CustomerRmas.ProviderType));
				return _instance;
			}
		}
		public CustomerRmaProvider() {
			this.ConnectionString = Globals.Settings.CustomerRmas.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_CustomerRMA_for_Client]
		/// </summary>
		public abstract Int32 CountForClient(System.Int32? clientId);
		/// <summary>
		/// CountForCompany
		/// Calls [usp_count_CustomerRMA_for_Company]
		/// </summary>
		public abstract Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeComplete);
		/// <summary>
		/// CountReceivingForClient
		/// Calls [usp_count_CustomerRMA_receiving_for_Client]
		/// </summary>
		public abstract Int32 CountReceivingForClient(System.Int32? clientId);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_CustomerRMA]
		/// </summary>
		public abstract bool Delete(System.Int32? customerRmaId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_CustomerRMA]
		/// </summary>
		public abstract Int32 Insert(System.Int32? clientNo, System.Int32? invoiceNo, System.Int32? authorisedBy, System.DateTime? customerRmaDate, System.String notes, System.String instructions, System.Int32? shipViaNo, System.String account, System.Int32? warehouseNo, System.Int32? companyNo, System.Int32? contactNo, System.Int32? divisionNo, System.Int32? incotermNo, System.Int32? updatedBy,System.String CustomerRejectionNo);
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_CustomerRMA]
		/// </summary>
		public abstract List<CustomerRmaDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String crmaNotesSearch, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.DateTime? customerRmaDateFrom, System.DateTime? customerRmaDateTo);
		/// <summary>
		/// Get
		/// Calls [usp_select_CustomerRMA]
		/// </summary>
		public abstract CustomerRmaDetails Get(System.Int32? customerRmaId);
		/// <summary>
		/// GetByNumber
		/// Calls [usp_select_CustomerRMA_by_Number]
		/// </summary>
		public abstract CustomerRmaDetails GetByNumber(System.Int32? customerRmaNumber);
		/// <summary>
		/// GetForNewCreditNote
		/// Calls [usp_select_CustomerRMA_for_NewCreditNote]
		/// </summary>
		public abstract CustomerRmaDetails GetForNewCreditNote(System.Int32? customerRmaId);
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_CustomerRMA_for_Page]
		/// </summary>
		public abstract CustomerRmaDetails GetForPage(System.Int32? customerRmaId);

        /// <summary>
        /// GetForPage
        /// Calls [usp_select_RecieveCustomerRMA_for_Page]
        /// </summary>
        public abstract CustomerRmaDetails GetForRecievePage(System.Int32? customerRmaId);
		/// <summary>
		/// GetForPrint
		/// Calls [usp_select_CustomerRMA_for_Print]
		/// </summary>
		public abstract CustomerRmaDetails GetForPrint(System.Int32? customerRmaId);
		/// <summary>
		/// GetIDByNumber
		/// Calls [usp_select_CustomerRMA_ID_by_Number]
		/// </summary>
        //[002] start
        public abstract List<CustomerRmaDetails> GetIDByNumber(System.Int32? customerRmaNumber, System.Int32? clientNo, System.Int32? isGlobalUser);
        //[002] end
		/// <summary>
		/// GetNextNumber
		/// Calls [usp_select_CustomerRMA_NextNumber]
		/// </summary>
		public abstract CustomerRmaDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy);
		/// <summary>
		/// GetListForCompany
		/// Calls [usp_selectAll_CustomerRMA_for_Company]
		/// </summary>
		public abstract List<CustomerRmaDetails> GetListForCompany(System.Int32? companyId, System.Boolean? includeComplete);
		/// <summary>
		/// Update
		/// Calls [usp_update_CustomerRMA]
		/// </summary>
		public abstract bool Update(System.Int32? customerRmaId, System.Int32? divisionNo, System.Int32? warehouseNo, System.Int32? authorisedBy, System.DateTime? customerRmaDate, System.Int32? shipViaNo, System.String account, System.String notes, System.String instructions, System.Int32? incotermNo, System.Int32? updatedBy,System.String CustomerRejectionNo);
        // [001] code start
        /// <summary>
        /// Get PDF list for customer rma
        /// Calls [usp_selectAll_PDF_for_CustomerRMA]
        /// </summary>
        /// <param name="SalesOrderId"></param>
        /// <returns></returns>
        public abstract List<PDFDocumentDetails> GetPDFListForCustomerRMA(System.Int32? CustomerRMAId);
        /// <summary>
        /// Insert PDF for customer rma
        /// Calls [usp_insert_CustomerRMAPDF]
        /// </summary>
        /// <param name="CustomerRMAId"></param>
        /// <param name="Caption"></param>
        /// <param name="FileName"></param>
        /// <param name="UpdatedBy"></param>
        /// <returns></returns>
        public abstract Int32 Insert(System.Int32? CustomerRMAId, System.String Caption, System.String FileName, System.Int32? UpdatedBy);
        /// <summary>
        /// Delete customer rma pdf
        /// Calls[usp_delete_CustomerRMAPDF]
        /// </summary>
        /// <param name="CustomerRMAPdfId"></param>
        /// <returns></returns>
        public abstract bool DeleteCustomerRMAPDF(System.Int32? CustomerRMAPdfId);
       
        //[001] code end
        //[003] start
        public abstract Int32 InsertCRMAInternalLog(System.Int32 CustomerRMAId, System.String notes, System.Int32 UpdatedBy);
        public abstract List<CustomerRmaDetails> GetCRMAInternalLog(System.Int32 customerRmaNumber);
        //[003] end
		#endregion
				
		/// <summary>
		/// Returns a new CustomerRmaDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual CustomerRmaDetails GetCustomerRmaFromReader(DbDataReader reader) {
			CustomerRmaDetails customerRma = new CustomerRmaDetails();
			if (reader.HasRows) {
				customerRma.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0); //From: [Table]
				customerRma.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				customerRma.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0); //From: [usp_select_Credit]
				customerRma.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null); //From: [Table]
				customerRma.AuthorisedBy = GetReaderValue_Int32(reader, "AuthorisedBy", 0); //From: [Table]
				customerRma.CustomerRMADate = GetReaderValue_DateTime(reader, "CustomerRMADate", DateTime.MinValue); //From: [usp_select_Credit]
				customerRma.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				customerRma.Instructions = GetReaderValue_String(reader, "Instructions", ""); //From: [Table]
				customerRma.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null); //From: [Table]
				customerRma.Account = GetReaderValue_String(reader, "Account", ""); //From: [Table]
				customerRma.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0); //From: [Table]
				customerRma.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [Table]
				customerRma.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null); //From: [Table]
				customerRma.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0); //From: [Table]
				customerRma.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				customerRma.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				customerRma.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null); //From: [Table]
				customerRma.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_select_Credit]
				customerRma.SalesmanName = GetReaderValue_String(reader, "SalesmanName", ""); //From: [usp_select_Credit]
				customerRma.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", ""); //From: [usp_itemsearch_CustomerRMA]
				customerRma.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0); //From: [usp_select_Credit]
				customerRma.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_datalistnugget_CustomerRequirement]
				customerRma.WarehouseName = GetReaderValue_String(reader, "WarehouseName", ""); //From: [usp_select_CustomerRMA]
				customerRma.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_select_Credit]
				customerRma.DivisionName = GetReaderValue_String(reader, "DivisionName", ""); //From: [usp_select_Credit]
				customerRma.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null); //From: [usp_select_Credit]
				customerRma.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0); //From: [usp_select_Credit]
				customerRma.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0); //From: [Table]
				customerRma.Salesman = GetReaderValue_Int32(reader, "Salesman", 0); //From: [Table]
				customerRma.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_select_Credit]
				customerRma.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_select_Credit]
				customerRma.ShipViaName = GetReaderValue_String(reader, "ShipViaName", ""); //From: [usp_select_Credit]
				customerRma.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0); //From: [Table]
				customerRma.TaxName = GetReaderValue_String(reader, "TaxName", ""); //From: [usp_select_Credit]
				customerRma.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue); //From: [usp_select_Credit]
				customerRma.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null); //From: [Table]
				customerRma.QuantityReceived = GetReaderValue_NullableInt32(reader, "QuantityReceived", null); //From: [usp_select_CustomerRMA]
				customerRma.IncotermName = GetReaderValue_String(reader, "IncotermName", ""); //From: [usp_select_Credit]
				customerRma.InvoiceCustomerPO = GetReaderValue_String(reader, "InvoiceCustomerPO", ""); //From: [usp_select_CustomerRMA_for_NewCreditNote]
				customerRma.InvoiceShippingCost = GetReaderValue_NullableDouble(reader, "InvoiceShippingCost", null); //From: [usp_select_CustomerRMA_for_NewCreditNote]
				customerRma.InvoiceFreight = GetReaderValue_NullableDouble(reader, "InvoiceFreight", null); //From: [usp_select_CustomerRMA_for_NewCreditNote]
				customerRma.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null); //From: [Table]
				customerRma.Salesman2Percent = GetReaderValue_NullableDouble(reader, "Salesman2Percent", null); //From: [Table]
				customerRma.CompanyTelephone = GetReaderValue_String(reader, "CompanyTelephone", ""); //From: [usp_select_Credit_for_Print]
				customerRma.CompanyFax = GetReaderValue_String(reader, "CompanyFax", ""); //From: [usp_select_Credit_for_Print]
				customerRma.CustomerPO = GetReaderValue_String(reader, "CustomerPO", ""); //From: [Table]
				customerRma.TermsName = GetReaderValue_String(reader, "TermsName", ""); //From: [usp_select_CustomerRMA_for_Print]
				customerRma.ContactEmail = GetReaderValue_String(reader, "ContactEmail", ""); //From: [usp_select_Credit_for_Print]
			}
			return customerRma;
		}
	
		/// <summary>
		/// Returns a collection of CustomerRmaDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<CustomerRmaDetails> GetCustomerRmaCollectionFromReader(DbDataReader reader) {
			List<CustomerRmaDetails> customerRmas = new List<CustomerRmaDetails>();
			while (reader.Read()) customerRmas.Add(GetCustomerRmaFromReader(reader));
			return customerRmas;
		}
		
		
	}
}