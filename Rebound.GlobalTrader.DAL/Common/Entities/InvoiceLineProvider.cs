//Marker     Changed by      Date         Remarks
//[001]      Vinay           14/09/2012   Add airwaybill search
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
	
	public abstract class InvoiceLineProvider : DataAccess {
		static private InvoiceLineProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public InvoiceLineProvider Instance {
			get {
				if (_instance == null) _instance = (InvoiceLineProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.InvoiceLines.ProviderType));
				return _instance;
			}
		}
		public InvoiceLineProvider() {
			this.ConnectionString = Globals.Settings.InvoiceLines.ConnectionString;
		}

		#region Method Registrations
		//[001] code start
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_InvoiceLine]
		/// </summary>
        public abstract List<InvoiceLineDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String customerPoSearch, System.Boolean? includePaid, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? invoiceDateFrom, System.DateTime? invoiceDateTo, System.Boolean? recentOnly, System.String airWayBill, Boolean IsGlobalLogin, System.Int32? clientSearchId);
        //[001] code end
		/// <summary>
		/// Delete
		/// Calls [usp_delete_InvoiceLine]
		/// </summary>
        /// Ref:68 Stock log Error
        public abstract bool Delete(System.Int32? invoiceLineId, System.Int32? updatedBy);
		/// <summary>
		/// InsertByShippingSOLine
		/// Calls [usp_insert_InvoiceLine_by_Shipping_SO_Line]
		/// </summary>
		public abstract Int32 InsertByShippingSOLine(System.Int32? invoiceNo, System.Int32? salesOrderLineNo, System.Int32? allocationNo, System.Int32? quantityShipped, System.Int32? shippedBy, System.DateTime? shippedDate, System.Int32? updatedBy, System.String fullPart, System.String part, System.String dateCode, System.Byte? rohs, System.Int32? manufacturerNo, System.Int32? packageNo, System.Int32? productNo, System.String taxable, System.Int32? quantity, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.Int32? salesOrderNo, System.Int32? serviceNo, System.Int32? stockNo, System.String instructions, System.String customerPart, System.String notes, System.Boolean shipASAP);
		/// <summary>
		/// InsertByShippingSRMALine
		/// Calls [usp_insert_InvoiceLine_by_Shipping_SRMALine]
		/// </summary>
		public abstract Int32 InsertByShippingSRMALine(System.Int32? invoiceNo, System.Int32? srmaLineNo, System.Int32? allocationNo, System.Int32? quantityShipped, System.Int32? shippedBy, System.DateTime? shippedDate, System.Int32? updatedBy, System.String fullPart, System.String part, System.String dateCode, System.Byte? rohs, System.Int32? manufacturerNo, System.Int32? packageNo, System.Int32? productNo, System.String taxable, System.Int32? quantity, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.Int32? salesOrderNo, System.Int32? serviceNo, System.Int32? stockNo, System.String instructions, System.String customerPart);
		/// <summary>
		/// InsertForManual
		/// Calls [usp_insert_InvoiceLine_for_Manual]
		/// </summary>
        public abstract Int32 InsertForManual(System.Int32? invoiceNo, System.Int32? salesOrderLineNo, System.Int32? shippedBy, System.DateTime? shippedDate, System.String notes, System.Int32? updatedBy, System.String fullPart, System.String part, System.String dateCode, System.Byte? rohs, System.Int32? manufacturerNo, System.Int32? packageNo, System.Int32? productNo, System.String taxable, System.Int32? quantity, System.Double? cost, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.Int32? salesOrderNo, System.Int32? serviceNo, System.Int32? stockNo, System.String instructions, System.String customerPart, System.Boolean? printHazardous);
		/// <summary>
		/// InsertForService
		/// Calls [usp_insert_InvoiceLine_for_Service]
		/// </summary>
        public abstract Int32 InsertForService(System.Int32? invoiceNo, System.Int32? salesOrderLineNo, System.Int32? shippedBy, System.DateTime? shippedDate, System.String notes, System.Int32? updatedBy, System.String fullPart, System.String part, System.String dateCode, System.Byte? rohs, System.Int32? manufacturerNo, System.Int32? packageNo, System.Int32? productNo, System.String taxable, System.Int32? quantity, System.Double? cost, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.Int32? salesOrderNo, System.Int32? serviceNo, System.Int32? stockNo, System.String instructions, System.String customerPart, System.Boolean? printHazardous);
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_InvoiceLine]
		/// </summary>
		public abstract List<InvoiceLineDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String customerPoSearch, System.Boolean? includePaid, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? invoiceDateFrom, System.DateTime? invoiceDateTo);
		/// <summary>
		/// Get
		/// Calls [usp_select_InvoiceLine]
		/// </summary>
		public abstract InvoiceLineDetails Get(System.Int32? invoiceLineId);
		/// <summary>
		/// GetListCandidatesForCustomerRMA
		/// Calls [usp_selectAll_InvoiceLine_candidates_for_CustomerRMA]
		/// </summary>
		public abstract List<InvoiceLineDetails> GetListCandidatesForCustomerRMA(System.Int32? customerRmaId);
		/// <summary>
		/// GetListForInvoice
		/// Calls [usp_selectAll_InvoiceLine_for_Invoice]
		/// </summary>
		public abstract List<InvoiceLineDetails> GetListForInvoice(System.Int32? invoiceId);
		/// <summary>
		/// GetListForSalesOrder
		/// Calls [usp_selectAll_InvoiceLine_for_SalesOrder]
		/// </summary>
		public abstract List<InvoiceLineDetails> GetListForSalesOrder(System.Int32? salesOrderId);
		/// <summary>
		/// GetListForSalesOrderLine
		/// Calls [usp_selectAll_InvoiceLine_for_SalesOrderLine]
		/// </summary>
		public abstract List<InvoiceLineDetails> GetListForSalesOrderLine(System.Int32? salesOrderLineId);
		/// <summary>
		/// GetListInactiveForInvoice
		/// Calls [usp_selectAll_InvoiceLine_Inactive_for_Invoice]
		/// </summary>
		public abstract List<InvoiceLineDetails> GetListInactiveForInvoice(System.Int32? invoiceId);
		/// <summary>
		/// Update
		/// Calls [usp_update_InvoiceLine]
		/// </summary>
        public abstract bool Update(System.Int32? invoiceLineId, System.Int32? salesOrderLineNo, System.Int32? shippedBy, System.DateTime? shippedDate, System.String customerPart, System.String notes, System.Int32? updatedBy, System.Boolean? printHazardous);

		#endregion
				
		/// <summary>
		/// Returns a new InvoiceLineDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual InvoiceLineDetails GetInvoiceLineFromReader(DbDataReader reader) {
			InvoiceLineDetails invoiceLine = new InvoiceLineDetails();
			if (reader.HasRows) {
				invoiceLine.InvoiceLineId = GetReaderValue_Int32(reader, "InvoiceLineId", 0); //From: [Table]
				invoiceLine.InvoiceNo = GetReaderValue_Int32(reader, "InvoiceNo", 0); //From: [Table]
				invoiceLine.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null); //From: [Table]
				invoiceLine.ShippedBy = GetReaderValue_NullableInt32(reader, "ShippedBy", null); //From: [Table]
				invoiceLine.ShippedDate = GetReaderValue_NullableDateTime(reader, "ShippedDate", null); //From: [Table]
				invoiceLine.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				invoiceLine.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				invoiceLine.CustomerPart = GetReaderValue_String(reader, "CustomerPart", ""); //From: [Table]
				invoiceLine.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				invoiceLine.FullPart = GetReaderValue_String(reader, "FullPart", ""); //From: [Table]
				invoiceLine.Part = GetReaderValue_String(reader, "Part", ""); //From: [Table]
				invoiceLine.DateCode = GetReaderValue_String(reader, "DateCode", ""); //From: [Table]
				invoiceLine.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null); //From: [Table]
				invoiceLine.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null); //From: [Table]
				invoiceLine.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null); //From: [Table]
				invoiceLine.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null); //From: [Table]
				invoiceLine.Taxable = GetReaderValue_String(reader, "Taxable", ""); //From: [Table]
				invoiceLine.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null); //From: [Table]
				invoiceLine.Price = GetReaderValue_NullableDouble(reader, "Price", null); //From: [Table]
				invoiceLine.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null); //From: [Table]
				invoiceLine.RequiredDate = GetReaderValue_NullableDateTime(reader, "RequiredDate", null); //From: [Table]
				invoiceLine.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null); //From: [Table]
				invoiceLine.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null); //From: [Table]
				invoiceLine.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null); //From: [Table]
				invoiceLine.Instructions = GetReaderValue_String(reader, "Instructions", ""); //From: [Table]
				invoiceLine.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				invoiceLine.FullCustomerPart = GetReaderValue_String(reader, "FullCustomerPart", ""); //From: [Table]
				invoiceLine.InvoiceId = GetReaderValue_Int32(reader, "InvoiceId", 0); //From: [usp_datalistnugget_InvoiceLine]
				invoiceLine.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0); //From: [usp_datalistnugget_InvoiceLine]
				invoiceLine.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_datalistnugget_InvoiceLine]
				invoiceLine.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue); //From: [usp_datalistnugget_InvoiceLine]
				invoiceLine.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_datalistnugget_InvoiceLine]
				invoiceLine.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null); //From: [usp_datalistnugget_InvoiceLine]
				invoiceLine.CustomerPO = GetReaderValue_String(reader, "CustomerPO", ""); //From: [usp_datalistnugget_InvoiceLine]
				invoiceLine.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_datalistnugget_InvoiceLine]
				invoiceLine.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null); //From: [usp_itemsearch_InvoiceLine]
				invoiceLine.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [usp_select_InvoiceLine]
				invoiceLine.DateOrdered = GetReaderValue_NullableDateTime(reader, "DateOrdered", null); //From: [usp_select_InvoiceLine]
				invoiceLine.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null); //From: [usp_select_InvoiceLine]
				invoiceLine.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null); //From: [usp_select_InvoiceLine]
				invoiceLine.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null); //From: [usp_select_InvoiceLine]
				invoiceLine.SupplierRMADate = GetReaderValue_NullableDateTime(reader, "SupplierRMADate", null); //From: [usp_select_InvoiceLine]
				invoiceLine.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null); //From: [usp_select_InvoiceLine]
				invoiceLine.SalesmanName = GetReaderValue_String(reader, "SalesmanName", ""); //From: [usp_select_InvoiceLine]
				invoiceLine.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null); //From: [usp_select_InvoiceLine]
				invoiceLine.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null); //From: [usp_select_InvoiceLine]
				invoiceLine.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null); //From: [usp_select_InvoiceLine]
				invoiceLine.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_select_InvoiceLine]
				invoiceLine.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null); //From: [usp_select_InvoiceLine]
				invoiceLine.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_select_InvoiceLine]
				invoiceLine.ProductName = GetReaderValue_String(reader, "ProductName", ""); //From: [usp_select_InvoiceLine]
				invoiceLine.ProductDescription = GetReaderValue_String(reader, "ProductDescription", ""); //From: [usp_select_InvoiceLine]
				invoiceLine.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", ""); //From: [usp_select_InvoiceLine]
				invoiceLine.PackageName = GetReaderValue_String(reader, "PackageName", ""); //From: [usp_select_InvoiceLine]
				invoiceLine.PackageDescription = GetReaderValue_String(reader, "PackageDescription", ""); //From: [usp_select_InvoiceLine]
				invoiceLine.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", ""); //From: [usp_select_InvoiceLine]
				invoiceLine.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", ""); //From: [usp_select_InvoiceLine]
				invoiceLine.InvoicePaid = GetReaderValue_Boolean(reader, "InvoicePaid", false); //From: [usp_select_InvoiceLine]
				invoiceLine.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0); //From: [usp_select_InvoiceLine]
				invoiceLine.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null); //From: [usp_select_InvoiceLine]
				invoiceLine.LineSource = GetReaderValue_String(reader, "LineSource", ""); //From: [usp_select_InvoiceLine]
				invoiceLine.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0); //From: [usp_select_InvoiceLine]
				invoiceLine.ShippedByName = GetReaderValue_String(reader, "ShippedByName", ""); //From: [usp_select_InvoiceLine]
				invoiceLine.LineNotes = GetReaderValue_String(reader, "LineNotes", ""); //From: [usp_select_InvoiceLine]
				invoiceLine.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", ""); //From: [usp_selectAll_InvoiceLine_for_Invoice]
			}
			return invoiceLine;
		}
	
		/// <summary>
		/// Returns a collection of InvoiceLineDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<InvoiceLineDetails> GetInvoiceLineCollectionFromReader(DbDataReader reader) {
			List<InvoiceLineDetails> invoiceLines = new List<InvoiceLineDetails>();
			while (reader.Read()) invoiceLines.Add(GetInvoiceLineFromReader(reader));
			return invoiceLines;
		}
		
		
	}
}