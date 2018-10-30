//Marker     Changed by      Date         Remarks
//[001]      Vinay           30/07/2012   Add compulsory incoterms field when create Credit and debit note. :ESMS No:- 105
//[002]      Aashu Singh      01/06/2018   Quick Jump in Global Warehouse 
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
	
	public abstract class DebitProvider : DataAccess {
		static private DebitProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public DebitProvider Instance {
			get {
				if (_instance == null) _instance = (DebitProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Debits.ProviderType));
				return _instance;
			}
		}
		public DebitProvider() {
			this.ConnectionString = Globals.Settings.Debits.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// CountForCompany
		/// Calls [usp_count_Debit_for_Company]
		/// </summary>
		public abstract Int32 CountForCompany(System.Int32? companyId);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Debit]
		/// </summary>
		public abstract bool Delete(System.Int32? debitId);
        //[001] code start
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Debit]
		/// </summary>
		public abstract Int32 Insert(System.Int32? clientNo, System.Int32? companyNo, System.Int32? contactNo, System.DateTime? debitDate, System.Int32? currencyNo, System.Int32? raisedBy, System.Int32? buyer, System.String notes, System.String instructions, System.Double? freight, System.Int32? divisionNo, System.Int32? taxNo, System.Int32? purchaseOrderNo, System.Int32? supplierRmaNo, System.DateTime? referenceDate, System.String supplierInvoice, System.String supplierRma, System.String supplierCredit, System.Int32? updatedBy,System.Int32? IncotermsNo);
        //[001] code end
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_Debit]
		/// </summary>
		public abstract List<DebitDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.Int32? debitNoLo, System.Int32? debitNoHi, System.Int32? supplierRmaNoLo, System.Int32? supplierRmaNoHi, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? debitDateFrom, System.DateTime? debitDateTo);
		/// <summary>
		/// Get
		/// Calls [usp_select_Debit]
		/// </summary>
		public abstract DebitDetails Get(System.Int32? debitId);
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_Debit_for_Page]
		/// </summary>
		public abstract DebitDetails GetForPage(System.Int32? debitId);
		/// <summary>
		/// GetForPrint
		/// Calls [usp_select_Debit_for_Print]
		/// </summary>
        public abstract DebitDetails GetForPrint(System.Int32? debitNo, bool IsHUBdebitNo);
		/// <summary>
		/// GetIdByNumber
		/// Calls [usp_select_Debit_Id_by_Number]
		/// </summary>
        //[002] start
		public abstract List<DebitDetails> GetIdByNumber(System.Int32? debitNumber, System.Int32? clientNo, System.Int32? isGlobalUser);
        //[002] end
		/// <summary>
		/// GetNextNumber
		/// Calls [usp_select_Debit_NextNumber]
		/// </summary>
		public abstract DebitDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy);
		/// <summary>
		/// GetListForCompany
		/// Calls [usp_selectAll_Debit_for_Company]
		/// </summary>
		public abstract List<DebitDetails> GetListForCompany(System.Int32? companyId);
        //[001] code start
		/// <summary>
		/// Update
		/// Calls [usp_update_Debit]
		/// </summary>
        public abstract bool Update(System.Int32? debitId, System.String supplierInvoice, System.String supplierRma, System.String supplierCredit, System.Double? freight, System.String notes, System.String instructions, System.Int32? divisionNo, System.Int32? buyer, System.Int32? raisedBy, System.DateTime? debitDate, System.DateTime? referenceDate, System.Int32? taxNo, System.Int32? currencyNo, System.Int32? updatedBy, System.Int32? IncotermsNo, bool? isLockUpdateClient);
        //[001] code end
		#endregion
				
		/// <summary>
		/// Returns a new DebitDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual DebitDetails GetDebitFromReader(DbDataReader reader) {
			DebitDetails debit = new DebitDetails();
			if (reader.HasRows) {
				debit.DebitId = GetReaderValue_Int32(reader, "DebitId", 0); //From: [Table]
				debit.DebitNumber = GetReaderValue_Int32(reader, "DebitNumber", 0); //From: [Table]
				debit.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				debit.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [Table]
				debit.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0); //From: [Table]
				debit.DebitDate = GetReaderValue_DateTime(reader, "DebitDate", DateTime.MinValue); //From: [Table]
				debit.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0); //From: [Table]
				debit.RaisedBy = GetReaderValue_NullableInt32(reader, "RaisedBy", null); //From: [Table]
				debit.Buyer = GetReaderValue_Int32(reader, "Buyer", 0); //From: [Table]
				debit.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				debit.Instructions = GetReaderValue_String(reader, "Instructions", ""); //From: [Table]
				debit.Freight = GetReaderValue_NullableDouble(reader, "Freight", null); //From: [Table]
				debit.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0); //From: [Table]
				debit.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null); //From: [Table]
				debit.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null); //From: [Table]
				debit.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null); //From: [Table]
				debit.ReferenceDate = GetReaderValue_DateTime(reader, "ReferenceDate", DateTime.MinValue); //From: [Table]
				debit.SupplierInvoice = GetReaderValue_String(reader, "SupplierInvoice", ""); //From: [Table]
				debit.SupplierRMA = GetReaderValue_String(reader, "SupplierRMA", ""); //From: [Table]
				debit.SupplierCredit = GetReaderValue_String(reader, "SupplierCredit", ""); //From: [Table]
				debit.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				debit.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				debit.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_itemsearch_Debit]
				debit.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_itemsearch_Debit]
				debit.RaiserName = GetReaderValue_String(reader, "RaiserName", ""); //From: [usp_itemsearch_Debit]
				debit.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0); //From: [usp_itemsearch_Debit]
				debit.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null); //From: [usp_itemsearch_Debit]
				debit.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_itemsearch_Debit]
				debit.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_select_Debit]
				debit.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_select_Debit]
				debit.BuyerName = GetReaderValue_String(reader, "BuyerName", ""); //From: [usp_select_Debit]
				debit.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null); //From: [usp_select_Debit]
				debit.DivisionName = GetReaderValue_String(reader, "DivisionName", ""); //From: [usp_select_Debit]
				debit.TaxName = GetReaderValue_String(reader, "TaxName", ""); //From: [usp_select_Debit]
				debit.PurchaseOrderDate = GetReaderValue_DateTime(reader, "PurchaseOrderDate", DateTime.MinValue); //From: [usp_select_Debit]
				debit.DebitValue = GetReaderValue_NullableDouble(reader, "DebitValue", null); //From: [usp_select_Debit]
				debit.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null); //From: [usp_select_Debit]
				debit.CompanyTelephone = GetReaderValue_String(reader, "CompanyTelephone", ""); //From: [usp_select_Debit_for_Print]
				debit.CompanyFax = GetReaderValue_String(reader, "CompanyFax", ""); //From: [usp_select_Debit_for_Print]
				debit.ContactEmail = GetReaderValue_String(reader, "ContactEmail", ""); //From: [usp_select_Debit_for_Print]
                debit.VATNO = GetReaderValue_String(reader, "VATNo", "");
                debit.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
			}
			return debit;
		}
	
		/// <summary>
		/// Returns a collection of DebitDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<DebitDetails> GetDebitCollectionFromReader(DbDataReader reader) {
			List<DebitDetails> debits = new List<DebitDetails>();
			while (reader.Read()) debits.Add(GetDebitFromReader(reader));
			return debits;
		}
		
		
	}
}