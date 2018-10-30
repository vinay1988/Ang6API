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
	
	public abstract class CustomerRmaLineAllocationProvider : DataAccess {
		static private CustomerRmaLineAllocationProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public CustomerRmaLineAllocationProvider Instance {
			get {
				if (_instance == null) _instance = (CustomerRmaLineAllocationProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.CustomerRmaLineAllocations.ProviderType));
				return _instance;
			}
		}
		public CustomerRmaLineAllocationProvider() {
			this.ConnectionString = Globals.Settings.CustomerRmaLineAllocations.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// CountForPurchaseOrderLine
		/// Calls [usp_count_CustomerRMALineAllocation_for_PurchaseOrderLine]
		/// </summary>
		public abstract Int32 CountForPurchaseOrderLine(System.Int32? purchaseOrderLineId);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_CustomerRMALineAllocation]
		/// </summary>
		public abstract bool Delete(System.Int32? customerRmaLineAllocationId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_CustomerRMALineAllocation]
		/// </summary>
		public abstract Int32 Insert(System.Int32? customerRmaLineNo, System.Int32? invoiceLineAllocationNo, System.Int32? quantity, System.Int32? goodsInLineNo, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_CustomerRMALineAllocation]
		/// </summary>
		public abstract CustomerRmaLineAllocationDetails Get(System.Int32? customerRmaLineAllocationId);
		/// <summary>
		/// GetListForPurchaseOrderLine
		/// Calls [usp_selectAll_CustomerRMALineAllocation_for_PurchaseOrderLine]
		/// </summary>
		public abstract List<CustomerRmaLineAllocationDetails> GetListForPurchaseOrderLine(System.Int32? purchaseOrderLineId, System.Int32? pageIndex, System.Int32? pageSize);
		/// <summary>
		/// Update
		/// Calls [usp_update_CustomerRMALineAllocation]
		/// </summary>
		public abstract bool Update(System.Int32? customerRmaLineAllocationId, System.Int32? customerRmaLineNo, System.Int32? invoiceLineAllocationNo, System.Int32? quantity, System.Int32? goodsInLineNo, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new CustomerRmaLineAllocationDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual CustomerRmaLineAllocationDetails GetCustomerRmaLineAllocationFromReader(DbDataReader reader) {
			CustomerRmaLineAllocationDetails customerRmaLineAllocation = new CustomerRmaLineAllocationDetails();
			if (reader.HasRows) {
				customerRmaLineAllocation.CustomerRMALineAllocationId = GetReaderValue_Int32(reader, "CustomerRMALineAllocationId", 0); //From: [Table]
				customerRmaLineAllocation.CustomerRMALineNo = GetReaderValue_Int32(reader, "CustomerRMALineNo", 0); //From: [Table]
				customerRmaLineAllocation.InvoiceLineAllocationNo = GetReaderValue_Int32(reader, "InvoiceLineAllocationNo", 0); //From: [Table]
				customerRmaLineAllocation.Quantity = GetReaderValue_Int32(reader, "Quantity", 0); //From: [usp_select_CustomerRMA]
				customerRmaLineAllocation.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null); //From: [Table]
				customerRmaLineAllocation.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				customerRmaLineAllocation.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				customerRmaLineAllocation.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0); //From: [Table]
				customerRmaLineAllocation.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0); //From: [Table]
				customerRmaLineAllocation.CustomerRMADate = GetReaderValue_DateTime(reader, "CustomerRMADate", DateTime.MinValue); //From: [Table]
				customerRmaLineAllocation.ReturnDate = GetReaderValue_NullableDateTime(reader, "ReturnDate", null); //From: [Table]
				customerRmaLineAllocation.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				customerRmaLineAllocation.Reason = GetReaderValue_String(reader, "Reason", ""); //From: [Table]
				customerRmaLineAllocation.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0); //From: [usp_itemsearch_CustomerRMA]
				customerRmaLineAllocation.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null); //From: [Table]
				customerRmaLineAllocation.InvoiceLineNo = GetReaderValue_Int32(reader, "InvoiceLineNo", 0); //From: [Table]
				customerRmaLineAllocation.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [Table]
				customerRmaLineAllocation.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_itemsearch_CustomerRMA]
				customerRmaLineAllocation.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null); //From: [usp_selectAll_CustomerRMALineAllocation_for_PurchaseOrderLine]
				customerRmaLineAllocation.AuthorisedBy = GetReaderValue_Int32(reader, "AuthorisedBy", 0); //From: [Table]
				customerRmaLineAllocation.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", ""); //From: [usp_itemsearch_CustomerRMA]
				customerRmaLineAllocation.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null); //From: [usp_selectAll_CustomerRMALineAllocation_for_PurchaseOrderLine]
			}
			return customerRmaLineAllocation;
		}
	
		/// <summary>
		/// Returns a collection of CustomerRmaLineAllocationDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<CustomerRmaLineAllocationDetails> GetCustomerRmaLineAllocationCollectionFromReader(DbDataReader reader) {
			List<CustomerRmaLineAllocationDetails> customerRmaLineAllocations = new List<CustomerRmaLineAllocationDetails>();
			while (reader.Read()) customerRmaLineAllocations.Add(GetCustomerRmaLineAllocationFromReader(reader));
			return customerRmaLineAllocations;
		}
		
		
	}
}