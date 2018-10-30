
/*

Marker     changed by      date         Remarks

[001]      Abhinav       17/11/20011   ESMS Ref:25 & 34  - Virtual Stock Update & Closeing of line CRMA

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
	
	public abstract class CustomerRmaLineProvider : DataAccess {
		static private CustomerRmaLineProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public CustomerRmaLineProvider Instance {
			get {
				if (_instance == null) _instance = (CustomerRmaLineProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.CustomerRmaLines.ProviderType));
				return _instance;
			}
		}
		public CustomerRmaLineProvider() {
			this.ConnectionString = Globals.Settings.CustomerRmaLines.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_CustomerRMALine]
		/// </summary>
        public abstract List<CustomerRmaLineDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String crmaNotesSearch, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.DateTime? customerRmaDateFrom, System.DateTime? customerRmaDateTo, System.Boolean? includeReceived, System.Boolean? recentOnly, System.Boolean? PohubOnly, System.Int32? clientSearch, Boolean IsGlobalLogin);
		/// <summary>
		/// DataListNuggetReadyToReceive
		/// Calls [usp_datalistnugget_CustomerRMALine_ReadyToReceive]
		/// </summary>
        public abstract List<CustomerRmaLineDetails> DataListNuggetReadyToReceive(System.Int32? clientId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String crmaNotesSearch, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.DateTime? customerRmaDateFrom, System.DateTime? customerRmaDateTo, System.Int32? clientSearch, Boolean IsGlobalLogin);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_CustomerRMALine]
		/// </summary>
		public abstract bool Delete(System.Int32? customerRmaLineId);

        // [001] code  start
        /// <summary>
        /// Delete
        /// Calls [usp_UpdateClose_CustomerRMALine]
        /// </summary>
        public abstract bool UpdateClose(System.Int32? customerRmaLineId,System.Int32? updatedBy);
       // [001] code  end

		/// <summary>
		/// Insert
		/// Calls [usp_insert_CustomerRMALine]
		/// </summary>
        public abstract Int32 Insert(System.Int32? customerRmaNo, System.Int32? invoiceLineNo, System.DateTime? returnDate, System.String reason, System.String reason1, System.String reason2, System.Int32? quantity, System.String notes, System.String rootCause, System.Int32? updatedBy, out int customerRMAId, out int customerRMANumber, System.Int32? stockNo, System.Boolean? avoidable, System.Boolean? printHazardous);
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_CustomerRMALine]
		/// </summary>
		public abstract List<CustomerRmaLineDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesman, System.String crmaNotesSearch, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.DateTime? customerRmaDateFrom, System.DateTime? customerRmaDateTo);
		/// <summary>
		/// Get
		/// Calls [usp_select_CustomerRMALine]
		/// </summary>
		public abstract CustomerRmaLineDetails Get(System.Int32? customerRmaLineId);
		/// <summary>
		/// GetForReceiving
		/// Calls [usp_select_CustomerRMALine_for_Receiving]
		/// </summary>
		public abstract CustomerRmaLineDetails GetForReceiving(System.Int32? customerRmaLineNo);
		/// <summary>
		/// GetListForCustomerRMA
		/// Calls [usp_selectAll_CustomerRMALine_for_CustomerRMA]
		/// </summary>
		public abstract List<CustomerRmaLineDetails> GetListForCustomerRMA(System.Int32? customerRmaId);
        
        // [001] code start
        /// GetQtyForCustomerRMA
        /// Calls [usp_GetQty_CustomerRMALine_for_CustomerRMA]
        /// </summary>
        public abstract CustomerRmaLineDetails GetQtyForCustomerRMA(System.Int32? customerRmaId, System.Int32? invoiceLineID);
        // [001] code start
        /// /// GetListFor Open CustomerRMA
        /// Calls [usp_selectAll_CRMALine_open_for_CustomerCRMA]
        /// </summary>
        public abstract List<CustomerRmaLineDetails> GetListOpenForCRMA(System.Int32? customerRmaId);
        /// <summary>
        /// /// GetListFor Closed CustomerRMA
        /// Calls [usp_selectAll_CRMALine_close_for_CustomerCRMA]
        /// </summary>
        public abstract List<CustomerRmaLineDetails> GetListClosedForCRMA(System.Int32? customerRmaId);
        /// <summary>
        // [001] code  end  
 
		/// GetListForReceiving
		/// Calls [usp_selectAll_CustomerRMALine_for_Receiving]
		/// </summary>
		public abstract List<CustomerRmaLineDetails> GetListForReceiving(System.Int32? customerRmaNo);
		/// <summary>
		/// Update
		/// Calls [usp_update_CustomerRMALine]
		/// </summary>
        public abstract bool Update(System.Int32? customerRmaLineId, System.Int32? quantity, System.String reason, System.String reason1, System.String notes, System.String rootCause, System.String reason2, System.Int32? updatedBy, System.Boolean? avoidable, System.Boolean? printHazardous);

		#endregion
				
		/// <summary>
		/// Returns a new CustomerRmaLineDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual CustomerRmaLineDetails GetCustomerRmaLineFromReader(DbDataReader reader) {
			CustomerRmaLineDetails customerRmaLine = new CustomerRmaLineDetails();
			if (reader.HasRows) {
				customerRmaLine.CustomerRMALineId = GetReaderValue_Int32(reader, "CustomerRMALineId", 0); //From: [Table]
				customerRmaLine.CustomerRMANo = GetReaderValue_Int32(reader, "CustomerRMANo", 0); //From: [Table]
				customerRmaLine.InvoiceLineNo = GetReaderValue_Int32(reader, "InvoiceLineNo", 0); //From: [Table]
				customerRmaLine.ReturnDate = GetReaderValue_NullableDateTime(reader, "ReturnDate", null); //From: [Table]
				customerRmaLine.Reason = GetReaderValue_String(reader, "Reason", ""); //From: [Table]
				customerRmaLine.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null); //From: [usp_select_CustomerRMA]
				customerRmaLine.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				customerRmaLine.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				customerRmaLine.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				customerRmaLine.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0); //From: [Table]
				customerRmaLine.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0); //From: [Table]
				customerRmaLine.CustomerRMADate = GetReaderValue_DateTime(reader, "CustomerRMADate", DateTime.MinValue); //From: [Table]
				customerRmaLine.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_itemsearch_CustomerRMA]
				customerRmaLine.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [Table]
				customerRmaLine.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0); //From: [usp_itemsearch_CustomerRMA]
				customerRmaLine.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null); //From: [Table]
				customerRmaLine.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0); //From: [usp_datalistnugget_CustomerRMALine]
				customerRmaLine.Part = GetReaderValue_String(reader, "Part", ""); //From: [usp_datalistnugget_CustomerRMALine]
				customerRmaLine.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_select_CustomerRMA]
				customerRmaLine.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null); //From: [Table]
				customerRmaLine.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null); //From: [usp_datalistnugget_CustomerRMALine]
				customerRmaLine.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", ""); //From: [usp_datalistnugget_CustomerRMALine]
				customerRmaLine.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_itemsearch_CustomerRMA]
				customerRmaLine.QuantityReceived = GetReaderValue_NullableInt32(reader, "QuantityReceived", null); //From: [usp_select_CustomerRMA]
				customerRmaLine.SalesmanName = GetReaderValue_String(reader, "SalesmanName", ""); //From: [usp_itemsearch_CustomerRMA]
				customerRmaLine.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				customerRmaLine.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue); //From: [usp_select_CustomerRMA]
				customerRmaLine.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0); //From: [usp_select_CustomerRMA]
				customerRmaLine.Salesman = GetReaderValue_Int32(reader, "Salesman", 0); //From: [usp_select_CustomerRMA]
				customerRmaLine.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null); //From: [Table]
				customerRmaLine.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null); //From: [usp_select_CustomerRMALine]
				customerRmaLine.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null); //From: [usp_select_CustomerRMALine]
				customerRmaLine.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null); //From: [usp_select_CustomerRMALine]
				customerRmaLine.ProductName = GetReaderValue_String(reader, "ProductName", ""); //From: [usp_select_CustomerRMALine]
				customerRmaLine.ProductDescription = GetReaderValue_String(reader, "ProductDescription", ""); //From: [usp_select_CustomerRMALine]
				customerRmaLine.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", ""); //From: [usp_select_CustomerRMALine]
				customerRmaLine.FullPart = GetReaderValue_String(reader, "FullPart", ""); //From: [usp_select_CustomerRMALine]
				customerRmaLine.CustomerPart = GetReaderValue_String(reader, "CustomerPart", ""); //From: [usp_select_CustomerRMALine]
				customerRmaLine.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", ""); //From: [usp_select_CustomerRMALine]
				customerRmaLine.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null); //From: [usp_select_CustomerRMALine]
				customerRmaLine.DateCode = GetReaderValue_String(reader, "DateCode", ""); //From: [usp_select_CustomerRMALine]
				customerRmaLine.PackageName = GetReaderValue_String(reader, "PackageName", ""); //From: [usp_select_CustomerRMALine]
				customerRmaLine.PackageDescription = GetReaderValue_String(reader, "PackageDescription", ""); //From: [usp_select_CustomerRMALine]
				customerRmaLine.Price = GetReaderValue_NullableDouble(reader, "Price", null); //From: [usp_select_CustomerRMALine]
				customerRmaLine.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null); //From: [usp_select_CustomerRMALine]
				customerRmaLine.LineNotes = GetReaderValue_String(reader, "LineNotes", ""); //From: [usp_select_CustomerRMALine]
				customerRmaLine.InvoiceLineAllocationId = GetReaderValue_Int32(reader, "InvoiceLineAllocationId", 0); //From: [usp_select_CustomerRMALine_for_Receiving]

                
                // [001] code start
                customerRmaLine.QuantityShipped = GetReaderValue_NullableInt32(reader, "QuantityShipped", null); //From: [usp_select_CustomerRMA]
                customerRmaLine.QuantityCRMA = GetReaderValue_NullableInt32(reader, "QuantityAllocatedToCRMA", null); // from: [usp_select_CustomerRMA]  
                
                customerRmaLine.Closed = GetReaderValue_Boolean(reader, "Closed", false); //From: [Table]  

                // [001] code end
			}
			return customerRmaLine;
		}
	
		/// <summary>
		/// Returns a collection of CustomerRmaLineDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<CustomerRmaLineDetails> GetCustomerRmaLineCollectionFromReader(DbDataReader reader) {
			List<CustomerRmaLineDetails> customerRmaLines = new List<CustomerRmaLineDetails>();
			while (reader.Read()) customerRmaLines.Add(GetCustomerRmaLineFromReader(reader));
			return customerRmaLines;
		}
		
		
	}
}