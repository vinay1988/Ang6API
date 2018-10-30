//Marker     changed by      date          Remarks
//[001]      Vinay           21/01/2014   CR:- Add AS9120 Requirement in GT application
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
	
	public abstract class QuoteProvider : DataAccess {
		static private QuoteProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public QuoteProvider Instance {
			get {
				if (_instance == null) _instance = (QuoteProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Quotes.ProviderType));
				return _instance;
			}
		}
		public QuoteProvider() {
			this.ConnectionString = Globals.Settings.Quotes.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_Quote_for_Client]
		/// </summary>
		public abstract Int32 CountForClient(System.Int32? clientId);
		/// <summary>
		/// CountForCompany
		/// Calls [usp_count_Quote_for_Company]
		/// </summary>
		public abstract Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeClosed);
		/// <summary>
		/// CountOpenForCompany
		/// Calls [usp_count_Quote_open_for_Company]
		/// </summary>
		public abstract Int32 CountOpenForCompany(System.Int32? companyId);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Quote]
		/// </summary>
		public abstract bool Delete(System.Int32? quoteId);
        //[001] code start
        /// <summary>
        /// Insert
        /// Calls [usp_insert_Quote]
        /// </summary>
        public abstract Int32 Insert(System.Int32? clientNo, System.String notes, System.String instructions, System.Int32? companyNo, System.Int32? contactNo, System.DateTime? dateQuoted, System.Int32? currencyNo, System.Int32? salesman, System.Int32? termsNo, System.Int32? divisionNo, System.Double? freight, System.Boolean? closed, System.Int32? incotermNo, System.Int32? updatedBy, System.Boolean? As9120, System.Boolean? isImportant);
        //[001] code end
		/// <summary>
		/// Get
		/// Calls [usp_select_Quote]
		/// </summary>
		public abstract QuoteDetails Get(System.Int32? quoteId);
		/// <summary>
		/// GetByNumber
		/// Calls [usp_select_Quote_by_Number]
		/// </summary>
		public abstract QuoteDetails GetByNumber(System.Int32? quoteNumber, System.Int32? clientNo);
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_Quote_for_Page]
		/// </summary>
		public abstract QuoteDetails GetForPage(System.Int32? quoteId);
		/// <summary>
		/// GetForPrint
		/// Calls [usp_select_Quote_for_Print]
		/// </summary>
		public abstract QuoteDetails GetForPrint(System.Int32? quoteId);
		/// <summary>
		/// GetIDFromNumber
		/// Calls [usp_select_Quote_ID_from_Number]
		/// </summary>
		public abstract QuoteDetails GetIDFromNumber(System.Int32? quoteNumber,System.Int32? clientNo);
		/// <summary>
		/// GetNextNumber
		/// Calls [usp_select_Quote_NextNumber]
		/// </summary>
		public abstract QuoteDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy);
		/// <summary>
		/// GetListForCompany
		/// Calls [usp_selectAll_Quote_for_Company]
		/// </summary>
		public abstract List<QuoteDetails> GetListForCompany(System.Int32? companyId, System.Boolean? includeClosed);
		/// <summary>
		/// GetListForSourcingResult
		/// Calls [usp_selectAll_Quote_for_SourcingResult]
		/// </summary>
		public abstract List<QuoteDetails> GetListForSourcingResult(System.Int32? sourcingResultNo);
		/// <summary>
		/// GetListOpenForCompany
		/// Calls [usp_selectAll_Quote_open_for_Company]
		/// </summary>
		public abstract List<QuoteDetails> GetListOpenForCompany(System.Int32? companyId);
		/// <summary>
		/// GetListOpenForLogin
		/// Calls [usp_selectAll_Quote_open_for_Login]
		/// </summary>
		public abstract List<QuoteDetails> GetListOpenForLogin(System.Int32? loginId, System.Int32? topToSelect);
		/// <summary>
		/// GetListRecentForLogin
		/// Calls [usp_selectAll_Quote_recent_for_Login]
		/// </summary>
		public abstract List<QuoteDetails> GetListRecentForLogin(System.Int32? loginId, System.Int32? topToSelect);
        //[001] code start
        /// <summary>
        /// Update
        /// Calls [usp_update_Quote]
        /// </summary>
        public abstract bool Update(System.Int32? quoteId, System.String notes, System.String instructions, System.Boolean? closed, System.Int32? contactNo, System.DateTime? dateQuoted, System.Int32? currencyNo, System.Int32? salesman, System.Int32? divisionNo, System.Double? freight, System.Int32? termsNo, System.Int32? incotermNo, System.Int32? updatedBy, System.Boolean? As9120, System.Boolean? isImportant,System.Int32? quoteStatus);
        //[001] code end
		/// <summary>
		/// UpdateCheckClosed
		/// Calls [usp_update_Quote_CheckClosed]
		/// </summary>
		public abstract bool UpdateCheckClosed(System.Int32? quoteNo);

		#endregion
				
		/// <summary>
		/// Returns a new QuoteDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual QuoteDetails GetQuoteFromReader(DbDataReader reader) {
			QuoteDetails quote = new QuoteDetails();
			if (reader.HasRows) {
				quote.QuoteId = GetReaderValue_Int32(reader, "QuoteId", 0); //From: [Table]
				quote.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				quote.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0); //From: [Table]
				quote.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				quote.Instructions = GetReaderValue_String(reader, "Instructions", ""); //From: [Table]
				quote.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [Table]
				quote.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0); //From: [Table]
				quote.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue); //From: [Table]
				quote.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0); //From: [Table]
				quote.Salesman = GetReaderValue_Int32(reader, "Salesman", 0); //From: [Table]
				quote.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null); //From: [Table]
				quote.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0); //From: [Table]
				quote.Freight = GetReaderValue_NullableDouble(reader, "Freight", null); //From: [Table]
				quote.Closed = GetReaderValue_NullableBoolean(reader, "Closed", null); //From: [Table]
				quote.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				quote.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				quote.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null); //From: [Table]
				quote.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_itemsearch_PurchaseOrder]
				quote.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null); //From: [usp_select_Quote]
				quote.CompanySOApproved = GetReaderValue_NullableBoolean(reader, "CompanySOApproved", null); //From: [usp_select_Quote]
				quote.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_itemsearch_PurchaseOrder]
				quote.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_select_PurchaseOrder]
				quote.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_select_PurchaseOrder]
				quote.SalesmanName = GetReaderValue_String(reader, "SalesmanName", ""); //From: [usp_select_Quote]
				quote.DivisionName = GetReaderValue_String(reader, "DivisionName", ""); //From: [usp_select_PurchaseOrder]
				quote.QuoteValue = GetReaderValue_NullableDouble(reader, "QuoteValue", null); //From: [usp_select_Quote]
				quote.TermsName = GetReaderValue_String(reader, "TermsName", ""); //From: [usp_select_PurchaseOrder]
				quote.OpenLines = GetReaderValue_NullableInt32(reader, "OpenLines", null); //From: [usp_select_Quote]
				quote.IncotermName = GetReaderValue_String(reader, "IncotermName", ""); //From: [usp_select_PurchaseOrder]
				quote.ContactEmail = GetReaderValue_String(reader, "ContactEmail", ""); //From: [usp_select_PurchaseOrder_for_Print]
				quote.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null); //From: [usp_selectAll_PurchaseOrder_due_for_Client]
				quote.Balance = GetReaderValue_NullableDouble(reader, "Balance", null); //From: [usp_selectAll_PurchaseOrder_due_for_Client]
			}
			return quote;
		}
	
		/// <summary>
		/// Returns a collection of QuoteDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<QuoteDetails> GetQuoteCollectionFromReader(DbDataReader reader) {
			List<QuoteDetails> quotes = new List<QuoteDetails>();
			while (reader.Read()) quotes.Add(GetQuoteFromReader(reader));
			return quotes;
		}
		
		
	}
}
