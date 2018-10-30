//Marker     Changed by      Date         Remarks
//[001]      Vinay           22/01/2014   CR:- Add AS9120 Requirement in GT application
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
	
	public abstract class QuoteLineProvider : DataAccess {
		static private QuoteLineProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public QuoteLineProvider Instance {
			get {
				if (_instance == null) _instance = (QuoteLineProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.QuoteLines.ProviderType));
				return _instance;
			}
		}
		public QuoteLineProvider() {
			this.ConnectionString = Globals.Settings.QuoteLines.ConnectionString;
            this.GTConnectionString = Globals.Settings.QuoteLines.GTConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_QuoteLine]
		/// </summary>
        public abstract List<QuoteLineDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.Boolean? includeClosed, System.Int32? quoteNoLo, System.Int32? quoteNoHi, System.DateTime? dateQuotedFrom, System.DateTime? dateQuotedTo, System.Boolean? recentOnly, System.Boolean? important, System.Int32? totalLo, System.Int32? totalHi, System.Int32? qStatus);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_QuoteLine]
		/// </summary>
		public abstract bool Delete(System.Int32? quoteLineId);
        //[001] code start
        /// <summary>
        /// Insert
        /// Calls [usp_insert_QuoteLine]
        /// </summary>
        public abstract Int32 Insert(System.Int32? quoteNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.String eta, System.String instructions, System.Int32? productNo, System.Int32? reasonNo, System.String customerPart, System.Int32? serviceNo, System.Int32? stockNo, System.Byte? rohs, System.String notes, System.Int32? originalOfferCurrencyNo, System.DateTime? originalOfferDate, System.Double? originalOfferPrice, System.Int32? originalOfferSupplierNo, System.Int32? sourcingResultNo, System.Int32? updatedBy, System.Byte? productSource, System.String mslLevel, System.Boolean? printHazadous);
        //[001] code end
		
		/// <summary>
		/// InsertFromCustomerRequirement
		/// Calls [usp_insert_QuoteLine_from_CustomerRequirement]
		/// </summary>
		public abstract Int32 InsertFromCustomerRequirement(System.Int32? customerRequirementId, System.Int32? quoteNo);
		/// <summary>
		/// InsertFromSourcingResult
		/// Calls [usp_insert_QuoteLine_from_SourcingResult]
		/// </summary>
		public abstract Int32 InsertFromSourcingResult(System.Int32? sourcingResultId, System.Int32? quoteNo, System.DateTime? dateQuoted);
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_QuoteLine]
		/// </summary>
		public abstract List<QuoteLineDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Boolean? includeClosed, System.Int32? quoteNoLo, System.Int32? quoteNoHi, System.DateTime? dateQuotedFrom, System.DateTime? dateQuotedTo);
		/// <summary>
		/// Get
		/// Calls [usp_select_QuoteLine]
		/// </summary>
		public abstract QuoteLineDetails Get(System.Int32? quoteLineId);
		/// <summary>
		/// GetListClosedForQuote
		/// Calls [usp_selectAll_QuoteLine_Closed_for_Quote]
		/// </summary>
		public abstract List<QuoteLineDetails> GetListClosedForQuote(System.Int32? quoteId);
		/// <summary>
		/// GetListForQuote
		/// Calls [usp_selectAll_QuoteLine_for_Quote]
		/// </summary>
		public abstract List<QuoteLineDetails> GetListForQuote(System.Int32? quoteId);
		/// <summary>
		/// GetListOpenForQuote
		/// Calls [usp_selectAll_QuoteLine_Open_for_Quote]
		/// </summary>
		public abstract List<QuoteLineDetails> GetListOpenForQuote(System.Int32? quoteId);
		/// <summary>
		/// Source
		/// Calls [usp_source_QuoteLine]
		/// </summary>
        public abstract List<QuoteLineDetails> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool IsServerLocal);
        //[001] code start
        /// <summary>
        /// Update
        /// Calls [usp_update_QuoteLine]
        /// </summary>
        public abstract bool Update(System.Int32? quoteLineId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.String eta, System.String instructions, System.Int32? productNo, System.String customerPart, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Byte? productSource, System.String MSLLevel, System.Boolean? printHazadous);
        //[001] code end
		
		/// <summary>
		/// UpdateClose
		/// Calls [usp_update_QuoteLine_Close]
		/// </summary>
        public abstract bool UpdateClose(System.Int32? quoteLineId, System.Int32? reasonNo, System.Int32? updatedBy, System.String reasons);
        /// <summary>
        /// UpdateOffer
        /// Calls [usp_update_QuoteLine_OriginalOffer]
        /// </summary>
        public abstract bool UpdateOffer(System.Int32? quoteLineId, System.Int32? sourcingResultNo, System.Int32? updatedBy);

        /// <summary>
        /// Get
        /// Calls [usp_select_PurchaseRequestLineDetails]
        /// </summary>
        public abstract List<List<object>> GetPQLineList(System.Int32? quoteLineId, System.Int32? clientID, System.Int32? companyNo);
		#endregion
				
		/// <summary>
		/// Returns a new QuoteLineDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual List<List<object>> GetQuoteLineFromReader(DbDataReader reader) {
            List<List<object>> lstReports = new List<List<object>>();
            while (reader.Read()) lstReports.Add(GetQuoteLineCollectionFromReader(reader));
            return lstReports;
		}
	
		/// <summary>
		/// Returns a collection of QuoteLineDetails objects with the data read from the input DataReader
		/// </summary>                
        protected virtual List<object> GetQuoteLineCollectionFromReader(DbDataReader reader)
        {
            List<object> lst = new List<object>(reader.FieldCount);
            for (int i = 0; i < reader.FieldCount; i++) lst.Add(reader.GetValue(i));
            return lst;
		}
		
		
	}
}
