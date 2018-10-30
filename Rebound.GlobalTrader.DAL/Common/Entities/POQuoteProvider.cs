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
	
	public abstract class POQuoteProvider : DataAccess {
		static private POQuoteProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public POQuoteProvider Instance {
			get {
				if (_instance == null) _instance = (POQuoteProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.POQuotes.ProviderType));
				return _instance;
			}
		}
		public POQuoteProvider() {
			this.ConnectionString = Globals.Settings.POQuotes.ConnectionString;
		}

		#region Method Registrations
		
        ///// <summary>
        ///// CountForClient
        ///// Calls [usp_count_Quote_for_Client]
        ///// </summary>
        //public abstract Int32 CountForClient(System.Int32? clientId);
        ///// <summary>
        ///// CountForCompany
        ///// Calls [usp_count_Quote_for_Company]
        ///// </summary>
        //public abstract Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeClosed);
        ///// <summary>
        ///// CountOpenForCompany
        ///// Calls [usp_count_Quote_open_for_Company]
        ///// </summary>
        //public abstract Int32 CountOpenForCompany(System.Int32? companyId);
        ///// <summary>
        ///// Delete
        ///// Calls [usp_delete_Quote]
        ///// </summary>
        //public abstract bool Delete(System.Int32? quoteId);
        /// <summary>
        /// Insert
        /// Calls [usp_insert_PurchaseQuote]
        /// </summary>
        public abstract Int32 Insert(System.Int32? clientNo, System.String notes, System.Int32? companyNo, System.Int32? contactNo, System.Int32? currencyNo, System.Int32? updatedBy, System.Boolean? closed, System.Int32? salesperson, System.Int32? division);
        //[001] code end
		/// <summary>
		/// Get
        /// Calls [usp_select_PurchaseRequest]
		/// </summary>
		public abstract POQuoteDetails Get(System.Int32? poQuoteId);
        /// <summary>
        /// Update
        /// Calls [usp_update_PurchaseRequest]
        /// </summary>
        public abstract bool Update(System.Int32? poQuoteId, System.String notes, System.Boolean? closed, System.Int32? contactNo, System.Int32? updatedBy, System.Int32? salesPerson, System.Int32? division);
        ///// <summary>
        ///// GetByNumber
        ///// Calls [usp_select_Quote_by_Number]
        ///// </summary>
        //public abstract QuoteDetails GetByNumber(System.Int32? quoteNumber, System.Int32? clientNo);
		/// <summary>
		/// GetForPage
        /// Calls [usp_select_POQuote_for_Page]
		/// </summary>
         public abstract POQuoteDetails GetForPage(System.Int32? poQuoteId);
         /// <summary>
         /// GetCSVListForPurchaseQuote 
         /// Calls [usp_selectAll_CSV_for_PurchaseQuote]
         /// </summary>
         /// <param name="ManufacturerNo"></param>
         /// <returns></returns>
         public abstract List<PDFDocumentDetails> GetCSVListForPurchaseQuote(System.Int32? purchaseQuoteNo);
		/// <summary>
		/// GetForPrint
		/// Calls [usp_select_Quote_for_Print]
		/// </summary>
		//public abstract QuoteDetails GetForPrint(System.Int32? quoteId);
        ///// <summary>
        ///// GetIDFromNumber
        ///// Calls [usp_select_Quote_ID_from_Number]
        ///// </summary>
        //public abstract QuoteDetails GetIDFromNumber(System.Int32? quoteNumber,System.Int32? clientNo);
        ///// <summary>
        ///// GetNextNumber
        ///// Calls [usp_select_Quote_NextNumber]
        ///// </summary>
        //public abstract QuoteDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy);
        ///// <summary>
        ///// GetListForCompany
        ///// Calls [usp_selectAll_Quote_for_Company]
        ///// </summary>
        //public abstract List<QuoteDetails> GetListForCompany(System.Int32? companyId, System.Boolean? includeClosed);
        ///// <summary>
        ///// GetListForSourcingResult
        ///// Calls [usp_selectAll_Quote_for_SourcingResult]
        ///// </summary>
        //public abstract List<QuoteDetails> GetListForSourcingResult(System.Int32? sourcingResultNo);
        ///// <summary>
        ///// GetListOpenForCompany
        ///// Calls [usp_selectAll_Quote_open_for_Company]
        ///// </summary>
        //public abstract List<QuoteDetails> GetListOpenForCompany(System.Int32? companyId);
        ///// <summary>
        ///// GetListOpenForLogin
        ///// Calls [usp_selectAll_Quote_open_for_Login]
        ///// </summary>
        //public abstract List<QuoteDetails> GetListOpenForLogin(System.Int32? loginId, System.Int32? topToSelect);
        ///// <summary>
        ///// GetListRecentForLogin
        ///// Calls [usp_selectAll_Quote_recent_for_Login]
        ///// </summary>
        //public abstract List<QuoteDetails> GetListRecentForLogin(System.Int32? loginId, System.Int32? topToSelect);
        ////[001] code start
       
        ////[001] code end
        ///// <summary>
        ///// UpdateCheckClosed
        ///// Calls [usp_update_Quote_CheckClosed]
        ///// </summary>
        //public abstract bool UpdateCheckClosed(System.Int32? quoteNo);
         /// <summary>
         /// Insert
         /// Calls [usp_CSVImport]
         /// </summary>
         public abstract Int32 InsertCSV(System.Int32? ID, System.Int32? LoginID, System.Int32? clientNo, System.Int32? companyNo, System.String FileName, System.String Type);

         /// <summary>
         /// Delete
         /// Calls [usp_PurchaseQuoteCsvDelete]
         /// </summary>
         public abstract bool DeletePurchaseQuoteCsv(System.Int32? PurchaseQuoteCSVId);
		#endregion
				
	
		
		
	}
}
