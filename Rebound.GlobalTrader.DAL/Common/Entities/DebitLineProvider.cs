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
	
	public abstract class DebitLineProvider : DataAccess {
		static private DebitLineProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public DebitLineProvider Instance {
			get {
				if (_instance == null) _instance = (DebitLineProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.DebitLines.ProviderType));
				return _instance;
			}
		}
		public DebitLineProvider() {
			this.ConnectionString = Globals.Settings.DebitLines.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_DebitLine_for_Client]
		/// </summary>
		public abstract Int32 CountForClient(System.Int32? clientId);
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_DebitLine]
		/// </summary>
        public abstract List<DebitLineDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.String debitNotesSearch, System.String supplierInvoiceSearch, System.Int32? debitNoLo, System.Int32? debitNoHi, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? supplierRmaNoLo, System.Int32? supplierRmaNoHi, System.DateTime? debitDateFrom, System.DateTime? debitDateTo, System.Boolean? PohubOnly, Boolean IsGlobalLogin, System.Int32? clientSearchId);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_DebitLine]
		/// </summary>
		public abstract bool Delete(System.Int32? debitLineId, System.Int32? updatedBy);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_DebitLine]
		/// </summary>
		public abstract Int32 Insert(System.Int32? debitNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? productNo, System.Int32? quantity, System.Double? price, System.Boolean? taxable, System.String supplierPart, System.Double? landedCost, System.Int32? purchaseOrderLineNo, System.Int32? supplierRmaLineNo, System.Int32? stockNo, System.Int32? serviceNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, out int debitId, out int debitNumber,System.Boolean? printHazardous);
		/// <summary>
		/// InsertByShippingSRMALine
		/// Calls [usp_insert_DebitLine_by_Shipping_SRMALine]
		/// </summary>
		public abstract Int32 InsertByShippingSRMALine(System.Int32? debitNo, System.Int32? supplierRmaLineId, System.Int32? allocationNo, System.Int32? quantityShipped, System.Int32? shippedBy, System.DateTime? shippedDate, System.Int32? updatedBy,out int debitId, out int debitNumber);
		/// <summary>
		/// Get
		/// Calls [usp_select_DebitLine]
		/// </summary>
		public abstract DebitLineDetails Get(System.Int32? debitLineId);
		/// <summary>
		/// GetListForDebit
		/// Calls [usp_selectAll_DebitLine_for_Debit]
		/// </summary>
		public abstract List<DebitLineDetails> GetListForDebit(System.Int32? debitId);

        /// <summary>
        /// GetListForDebit
        /// Calls [usp_selectAll_DebitLine_for_Debit_Print]
        /// </summary>
        public abstract List<DebitLineDetails> GetListForDebitPrint(System.Int32? debitId, System.Boolean? IsHUBDebit);
		/// <summary>
		/// GetListForSupplierRMA
		/// Calls [usp_selectAll_DebitLine_for_SupplierRMA]
		/// </summary>
		public abstract List<DebitLineDetails> GetListForSupplierRMA(System.Int32? supplierRmaId);
		/// <summary>
		/// GetListForSupplierRMALine
		/// Calls [usp_selectAll_DebitLine_for_SupplierRMALine]
		/// </summary>
		public abstract List<DebitLineDetails> GetListForSupplierRMALine(System.Int32? supplierRmaLineId);
		/// <summary>
		/// Update
		/// Calls [usp_update_DebitLine]
		/// </summary>
		public abstract bool Update(System.Int32? debitLineId, System.Int32? quantity, System.Double? price, System.String part, System.String supplierPart, System.String notes, System.Int32? updatedBy,System.Boolean? printHazardous);

		#endregion
				
		/// <summary>
		/// Returns a new DebitLineDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual DebitLineDetails GetDebitLineFromReader(DbDataReader reader) {
			DebitLineDetails debitLine = new DebitLineDetails();
			if (reader.HasRows) {
				debitLine.DebitLineId = GetReaderValue_Int32(reader, "DebitLineId", 0); //From: [Table]
				debitLine.DebitNo = GetReaderValue_Int32(reader, "DebitNo", 0); //From: [Table]
				debitLine.FullPart = GetReaderValue_String(reader, "FullPart", ""); //From: [Table]
				debitLine.Part = GetReaderValue_String(reader, "Part", ""); //From: [usp_selectAll_Allocation]
				debitLine.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null); //From: [usp_selectAll_Allocation]
				debitLine.DateCode = GetReaderValue_String(reader, "DateCode", ""); //From: [usp_selectAll_Allocation]
				debitLine.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null); //From: [usp_selectAll_Allocation]
				debitLine.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null); //From: [usp_selectAll_Allocation]
				debitLine.Quantity = GetReaderValue_Int32(reader, "Quantity", 0); //From: [Table]
				debitLine.Price = GetReaderValue_Double(reader, "Price", 0); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
				debitLine.Taxable = GetReaderValue_Boolean(reader, "Taxable", false); //From: [Table]
				debitLine.SupplierPart = GetReaderValue_String(reader, "SupplierPart", ""); //From: [usp_selectAll_Allocation]
				debitLine.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null); //From: [usp_selectAll_Allocation]
				debitLine.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
				debitLine.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null); //From: [Table]
				debitLine.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null); //From: [Table]
				debitLine.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0); //From: [usp_selectAll_Allocation]
				debitLine.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				debitLine.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				debitLine.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null); //From: [Table]
				debitLine.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
				debitLine.FullSupplierPart = GetReaderValue_String(reader, "FullSupplierPart", ""); //From: [Table]
				debitLine.DebitId = GetReaderValue_Int32(reader, "DebitId", 0); //From: [Table]
				debitLine.DebitNumber = GetReaderValue_Int32(reader, "DebitNumber", 0); //From: [Table]
				debitLine.DebitDate = GetReaderValue_DateTime(reader, "DebitDate", DateTime.MinValue); //From: [Table]
				debitLine.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_list_Activity_by_Client_with_filter]
				debitLine.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [usp_list_Activity_by_Client_with_filter]
				debitLine.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0); //From: [usp_selectAll_Allocation]
				debitLine.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null); //From: [usp_selectAll_Allocation]
				debitLine.SupplierInvoice = GetReaderValue_String(reader, "SupplierInvoice", ""); //From: [Table]
				debitLine.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0); //From: [usp_selectAll_Allocation]
				debitLine.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null); //From: [usp_selectAll_Allocation]
				debitLine.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_list_Activity_by_Client_with_filter]
				debitLine.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0); //From: [Table]
				debitLine.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", ""); //From: [usp_selectAll_Allocation]
				debitLine.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_list_Activity_by_Client_with_filter]
				debitLine.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0); //From: [usp_select_Contact]
				debitLine.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", ""); //From: [usp_selectAll_Allocation]
				debitLine.PackageName = GetReaderValue_String(reader, "PackageName", ""); //From: [usp_selectAll_Allocation]
				debitLine.PackageDescription = GetReaderValue_String(reader, "PackageDescription", ""); //From: [usp_selectAll_Allocation]
				debitLine.ProductName = GetReaderValue_String(reader, "ProductName", ""); //From: [usp_selectAll_Allocation]
				debitLine.ProductDescription = GetReaderValue_String(reader, "ProductDescription", ""); //From: [usp_selectAll_Allocation]
				debitLine.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
				debitLine.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_list_Activity_by_Client_with_filter]
				debitLine.LineNotes = GetReaderValue_String(reader, "LineNotes", ""); //From: [usp_select_CreditLine]
			}
			return debitLine;
		}
	
		/// <summary>
		/// Returns a collection of DebitLineDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<DebitLineDetails> GetDebitLineCollectionFromReader(DbDataReader reader) {
			List<DebitLineDetails> debitLines = new List<DebitLineDetails>();
			while (reader.Read()) debitLines.Add(GetDebitLineFromReader(reader));
			return debitLines;
		}
		
		
	}
}