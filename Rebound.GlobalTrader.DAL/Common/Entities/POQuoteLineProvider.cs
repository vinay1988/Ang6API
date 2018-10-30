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
	
	public abstract class POQuoteLineProvider : DataAccess {
		static private POQuoteLineProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public POQuoteLineProvider Instance {
			get {
				if (_instance == null) _instance = (POQuoteLineProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.POQuoteLines.ProviderType));
				return _instance;
			}
		}
		public POQuoteLineProvider() {
			this.ConnectionString = Globals.Settings.QuoteLines.ConnectionString;
            //this.GTConnectionString = Globals.Settings.QuoteLines.GTConnectionString;
		}

		#region Method Registrations
        /// <summary>
        /// GetListLines
        /// Calls [usp_selectAll_PurchaseRequestLine]
        /// </summary>
        public abstract List<POQuoteLineDetails> GetListLines(System.Int32? poQuoteId);
        /// <summary>
        /// Insert
        /// Calls [usp_insert_PurchaseRequestLine]
        /// </summary>
        public abstract Int32 Insert(System.Int32? poQuoteNo, System.String xmlReqIds, System.Int32? updatedBy, System.Int32? clientNo);
        /// Delete
        /// Calls [usp_delete_PurchaseRequestLine]
        /// </summary>
        public abstract bool Delete(System.Int32? poQuoteLineId);
		
        /// <summary>
        /// DataListNugget
        /// Calls [usp_datalistnugget_PurchaseRequetLine]
        /// </summary>
        public abstract List<POQuoteLineDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.Boolean? includeClosed, System.Int32? poQuoteNoLo, System.Int32? poQuoteNoHi, System.DateTime? dateQuotedFrom, System.DateTime? dateQuotedTo, System.Boolean? recentOnly);
        /// <summary>
        /// Source
        /// Calls [usp_source_PurchaseRequestLineDetails]
        /// </summary>
        public abstract List<POQuoteLineDetails> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool IsServerLocal);
        ///// <summary>
        ///// Delete
        ///// Calls [usp_delete_QuoteLine]
        ///// </summary>
        //public abstract bool Delete(System.Int32? quoteLineId);
        ////[001] code start

        ////[001] code end
		
        ///// <summary>
        ///// InsertFromCustomerRequirement
        ///// Calls [usp_insert_QuoteLine_from_CustomerRequirement]
        ///// </summary>
        //public abstract Int32 InsertFromCustomerRequirement(System.Int32? customerRequirementId, System.Int32? quoteNo);
        ///// <summary>
        ///// InsertFromSourcingResult
        ///// Calls [usp_insert_QuoteLine_from_SourcingResult]
        ///// </summary>
        //public abstract Int32 InsertFromSourcingResult(System.Int32? sourcingResultId, System.Int32? quoteNo, System.DateTime? dateQuoted);
        ///// <summary>
        ///// ItemSearch
        ///// Calls [usp_itemsearch_QuoteLine]
        ///// </summary>
        //public abstract List<QuoteLineDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Boolean? includeClosed, System.Int32? quoteNoLo, System.Int32? quoteNoHi, System.DateTime? dateQuotedFrom, System.DateTime? dateQuotedTo);
        ///// <summary>
        ///// Get
        ///// Calls [usp_select_QuoteLine]
        ///// </summary>
        //public abstract QuoteLineDetails Get(System.Int32? quoteLineId);
		
        ///// <summary>
        ///// GetListForQuote
        ///// Calls [usp_selectAll_QuoteLine_for_Quote]
        ///// </summary>
        //public abstract List<QuoteLineDetails> GetListForQuote(System.Int32? quoteId);
        ///// <summary>
        ///// GetListOpenForQuote
        ///// Calls [usp_selectAll_QuoteLine_Open_for_Quote]
        ///// </summary>
        //public abstract List<QuoteLineDetails> GetListOpenForQuote(System.Int32? quoteId);
       
        ////[001] code start
        ///// <summary>
        ///// Update
        ///// Calls [usp_update_QuoteLine]
        ///// </summary>
        //public abstract bool Update(System.Int32? quoteLineId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.String eta, System.String instructions, System.Int32? productNo, System.String customerPart, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Byte? productSource);
        ////[001] code end
		
        ///// <summary>

        ///// <summary>
        ///// UpdateOffer
        ///// Calls [usp_update_QuoteLine_OriginalOffer]
        ///// </summary>
        //public abstract bool UpdateOffer(System.Int32? quoteLineId, System.Int32? sourcingResultNo, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new QuoteLineDetails instance filled with the DataReader's current record data
		/// </summary>        
        //protected virtual QuoteLineDetails GetQuoteLineFromReader(DbDataReader reader) {
        //    QuoteLineDetails quoteLine = new QuoteLineDetails();
        //    if (reader.HasRows) {
        //        quoteLine.QuoteLineId = GetReaderValue_Int32(reader, "QuoteLineId", 0); //From: [Table]
        //        quoteLine.QuoteNo = GetReaderValue_Int32(reader, "QuoteNo", 0); //From: [Table]
        //        quoteLine.FullPart = GetReaderValue_String(reader, "FullPart", ""); //From: [Table]
        //        quoteLine.Part = GetReaderValue_String(reader, "Part", ""); //From: [Table]
        //        quoteLine.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null); //From: [Table]
        //        quoteLine.DateCode = GetReaderValue_String(reader, "DateCode", ""); //From: [Table]
        //        quoteLine.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null); //From: [Table]
        //        quoteLine.Quantity = GetReaderValue_Int32(reader, "Quantity", 0); //From: [Table]
        //        quoteLine.Price = GetReaderValue_Double(reader, "Price", 0); //From: [Table]
        //        quoteLine.ETA = GetReaderValue_String(reader, "ETA", ""); //From: [Table]
        //        quoteLine.Instructions = GetReaderValue_String(reader, "Instructions", ""); //From: [Table]
        //        quoteLine.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null); //From: [Table]
        //        quoteLine.ReasonNo = GetReaderValue_NullableInt32(reader, "ReasonNo", null); //From: [Table]
        //        quoteLine.CustomerPart = GetReaderValue_String(reader, "CustomerPart", ""); //From: [Table]
        //        quoteLine.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null); //From: [Table]
        //        quoteLine.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null); //From: [Table]
        //        quoteLine.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0); //From: [Table]
        //        quoteLine.Closed = GetReaderValue_Boolean(reader, "Closed", false); //From: [Table]
        //        quoteLine.OriginalOfferPrice = GetReaderValue_NullableDouble(reader, "OriginalOfferPrice", null); //From: [Table]
        //        quoteLine.OriginalOfferCurrencyNo = GetReaderValue_NullableInt32(reader, "OriginalOfferCurrencyNo", null); //From: [Table]
        //        quoteLine.OriginalOfferDate = GetReaderValue_NullableDateTime(reader, "OriginalOfferDate", null); //From: [Table]
        //        quoteLine.OriginalOfferSupplierNo = GetReaderValue_NullableInt32(reader, "OriginalOfferSupplierNo", null); //From: [Table]
        //        quoteLine.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
        //        quoteLine.FullCustomerPart = GetReaderValue_String(reader, "FullCustomerPart", ""); //From: [Table]
        //        quoteLine.NotQuoted = GetReaderValue_Boolean(reader, "NotQuoted", false); //From: [Table]
        //        quoteLine.SourcingResultNo = GetReaderValue_NullableInt32(reader, "SourcingResultNo", null); //From: [Table]
        //        quoteLine.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
        //        quoteLine.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
        //        quoteLine.QuoteId = GetReaderValue_Int32(reader, "QuoteId", 0); //From: [usp_datalistnugget_QuoteLine]
        //        quoteLine.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0); //From: [usp_datalistnugget_QuoteLine]
        //        quoteLine.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_datalistnugget_QuoteLine]
        //        quoteLine.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue); //From: [usp_datalistnugget_QuoteLine]
        //        quoteLine.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_datalistnugget_QuoteLine]
        //        quoteLine.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [usp_datalistnugget_QuoteLine]
        //        quoteLine.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_datalistnugget_QuoteLine]
        //        quoteLine.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0); //From: [usp_datalistnugget_QuoteLine]
        //        quoteLine.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_datalistnugget_QuoteLine]
        //        quoteLine.LineNotes = GetReaderValue_String(reader, "LineNotes", ""); //From: [usp_select_QuoteLine]
        //        quoteLine.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", ""); //From: [usp_select_QuoteLine]
        //        quoteLine.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", ""); //From: [usp_select_QuoteLine]
        //        quoteLine.PackageName = GetReaderValue_String(reader, "PackageName", ""); //From: [usp_select_QuoteLine]
        //        quoteLine.PackageDescription = GetReaderValue_String(reader, "PackageDescription", ""); //From: [usp_select_QuoteLine]
        //        quoteLine.ProductName = GetReaderValue_String(reader, "ProductName", ""); //From: [usp_select_QuoteLine]
        //        quoteLine.ProductDescription = GetReaderValue_String(reader, "ProductDescription", ""); //From: [usp_select_QuoteLine]
        //        quoteLine.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null); //From: [usp_select_QuoteLine]
        //        quoteLine.ReasonName = GetReaderValue_String(reader, "ReasonName", ""); //From: [usp_select_QuoteLine]
        //        quoteLine.OriginalOfferCurrencyCode = GetReaderValue_String(reader, "OriginalOfferCurrencyCode", ""); //From: [usp_select_QuoteLine]
        //        quoteLine.OriginalOfferSupplierName = GetReaderValue_String(reader, "OriginalOfferSupplierName", ""); //From: [usp_select_QuoteLine]
        //        quoteLine.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null); //From: [usp_select_QuoteLine]
        //        quoteLine.ClientName = GetReaderValue_String(reader, "ClientName", ""); //From: [usp_source_QuoteLine]
        //        quoteLine.ClientDataVisibleToOthers = GetReaderValue_NullableBoolean(reader, "ClientDataVisibleToOthers", null); //From: [usp_source_QuoteLine]
        //    }
        //    return quoteLine;
        //}
	
		/// <summary>
		/// Returns a collection of QuoteLineDetails objects with the data read from the input DataReader
		/// </summary>                
        //protected virtual List<QuoteLineDetails> GetQuoteLineCollectionFromReader(DbDataReader reader) {
        //    List<QuoteLineDetails> quoteLines = new List<QuoteLineDetails>();
        //    while (reader.Read()) quoteLines.Add(GetQuoteLineFromReader(reader));
        //    return quoteLines;
        //}

        /// <summary>
        /// Csv Import Log 
        /// Calls [usp_CsvImportLog]
        /// </summary>
        public abstract List<POQuoteLineDetails> GetLog(System.Int32? ID);
        // <summary>
        /// Csv Import Log Bom
        /// Calls [usp_CsvBomImportLog]
        /// </summary>
        public abstract List<POQuoteLineDetails> GetLogBom(System.Int32? ID);

        /// <summary>
        /// Csv Import Log 
        /// Calls [usp_CsvUploadLog]
        /// </summary>
        public abstract List<POQuoteLineDetails> GetUploadLog(System.Int32? LoginId);

        /// <summary>
        ///  Log History
        /// Calls [usp_GetLogHistory]
        /// </summary>
        public abstract List<POQuoteLineDetails> GetLogHistory(System.Int32? ClientId);
	}
}
