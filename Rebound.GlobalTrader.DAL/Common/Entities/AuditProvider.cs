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
	
	public abstract class AuditProvider : DataAccess {
		static private AuditProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public AuditProvider Instance {
			get {
				if (_instance == null) _instance = (AuditProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Audits.ProviderType));
				return _instance;
			}
		}
		public AuditProvider() {
			this.ConnectionString = Globals.Settings.Audits.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Audit]
		/// </summary>
		public abstract bool Delete(System.Int32? auditId);
		/// <summary>
		/// GetListApprovalForPurchaseOrder
		/// Calls [usp_selectAll_Audit_approval_for_PurchaseOrder]
		/// </summary>
		public abstract List<AuditDetails> GetListApprovalForPurchaseOrder(System.Int32? purchaseOrderId);
		/// <summary>
		/// GetListAuthorisationForSalesOrder
		/// Calls [usp_selectAll_Audit_authorisation_for_SalesOrder]
		/// </summary>
		public abstract List<AuditDetails> GetListAuthorisationForSalesOrder(System.Int32? salesOrderId);
		/// <summary>
		/// GetListCreditHistoryForCompany
		/// Calls [usp_selectAll_Audit_creditHistory_for_Company]
		/// </summary>
		public abstract List<AuditDetails> GetListCreditHistoryForCompany(System.Int32? companyId);
        /// <summary>
        /// GetListInsuranceHistoryForCompany
        /// Calls [usp_selectAll_Insurance_History_for_Company]
        /// </summary>
        public abstract List<AuditDetails> GetListInsuranceHistoryForCompany(System.Int32? companyId);
		/// <summary>
		/// GetListForGoodsInLine
		/// Calls [usp_selectAll_Audit_for_GoodsInLine]
		/// </summary>
		public abstract List<AuditDetails> GetListForGoodsInLine(System.Int32? goodsInLineId);
		/// <summary>
		/// GetListForPurchaseOrder
		/// Calls [usp_selectAll_Audit_for_PurchaseOrder]
		/// </summary>
		public abstract List<AuditDetails> GetListForPurchaseOrder(System.Int32? purchaseOrderId);
		/// <summary>
		/// GetListForPurchaseOrderLine
		/// Calls [usp_selectAll_Audit_for_PurchaseOrderLine]
		/// </summary>
		public abstract List<AuditDetails> GetListForPurchaseOrderLine(System.Int32? purchaseOrderLineId);
		/// <summary>
		/// GetListForQuote
		/// Calls [usp_selectAll_Audit_for_Quote]
		/// </summary>
		public abstract List<AuditDetails> GetListForQuote(System.Int32? quoteId);
		/// <summary>
		/// GetListForQuoteLine
		/// Calls [usp_selectAll_Audit_for_QuoteLine]
		/// </summary>
		public abstract List<AuditDetails> GetListForQuoteLine(System.Int32? quoteLineId);
		/// <summary>
		/// GetListForSalesOrder
		/// Calls [usp_selectAll_Audit_for_SalesOrder]
		/// </summary>
		public abstract List<AuditDetails> GetListForSalesOrder(System.Int32? salesOrderId);
		/// <summary>
		/// GetListForSalesOrderLine
		/// Calls [usp_selectAll_Audit_for_SalesOrderLine]
		/// </summary>
		public abstract List<AuditDetails> GetListForSalesOrderLine(System.Int32? salesOrderLineId);

        /// <summary>
        /// Calls [usp_selectAll_Audit_approval_for_Expedite]
        /// </summary>
        public abstract List<AuditDetails> GetListExpediteForPurchaseOrder(System.Int32? purchaseOrderId);

        /// <summary>
        /// Calls [usp_selectAll_Audit_approval_for_Expedite]
        /// </summary>
        public abstract List<AuditDetails> GetListExpediteForHUBRFQ(System.Int32? HUBRFQId);
		#endregion
				
		/// <summary>
		/// Returns a new AuditDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual AuditDetails GetAuditFromReader(DbDataReader reader) {
			AuditDetails audit = new AuditDetails();
			if (reader.HasRows) {
				audit.AuditId = GetReaderValue_Int32(reader, "AuditId", 0); //From: [Table]
				audit.TableName = GetReaderValue_String(reader, "TableName", ""); //From: [Table]
				audit.HeaderNo = GetReaderValue_Int32(reader, "HeaderNo", 0); //From: [Table]
				audit.DetailLineNo = GetReaderValue_NullableInt32(reader, "DetailLineNo", null); //From: [Table]
				audit.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null); //From: [Table]
				audit.DateReceived = GetReaderValue_NullableDateTime(reader, "DateReceived", null); //From: [Table]
				audit.DateOrdered = GetReaderValue_NullableDateTime(reader, "DateOrdered", null); //From: [Table]
				audit.DateRequired = GetReaderValue_NullableDateTime(reader, "DateRequired", null); //From: [Table]
				audit.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null); //From: [Table]
				audit.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null); //From: [Table]
				audit.DateDue = GetReaderValue_NullableDateTime(reader, "DateDue", null); //From: [Table]
				audit.DateAuthorised = GetReaderValue_NullableDateTime(reader, "DateAuthorised", null); //From: [Table]
				audit.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null); //From: [Table]
				audit.Price = GetReaderValue_NullableDouble(reader, "Price", null); //From: [Table]
				audit.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null); //From: [Table]
				audit.Freight = GetReaderValue_NullableDouble(reader, "Freight", null); //From: [Table]
				audit.ShipCost = GetReaderValue_NullableDouble(reader, "ShipCost", null); //From: [Table]
				audit.FullPart = GetReaderValue_String(reader, "FullPart", ""); //From: [Table]
				audit.ExternalPart = GetReaderValue_String(reader, "ExternalPart", ""); //From: [Table]
				audit.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null); //From: [Table]
				audit.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null); //From: [Table]
				audit.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null); //From: [Table]
				audit.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null); //From: [Table]
				audit.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null); //From: [Table]
				audit.CreditLimitNew = GetReaderValue_NullableDouble(reader, "CreditLimitNew", null); //From: [Table]
				audit.Note = GetReaderValue_String(reader, "Note", ""); //From: [Table]
				audit.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				audit.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				audit.EmployeeName = GetReaderValue_String(reader, "EmployeeName", ""); //From: [usp_selectAll_Audit_approval_for_PurchaseOrder]
			}
			return audit;
		}
	
		/// <summary>
		/// Returns a collection of AuditDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<AuditDetails> GetAuditCollectionFromReader(DbDataReader reader) {
			List<AuditDetails> audits = new List<AuditDetails>();
			while (reader.Read()) audits.Add(GetAuditFromReader(reader));
			return audits;
		}
		
		
	}
}