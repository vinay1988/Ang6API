//Marker     changed by      date         Remarks
//[001]      Aashu          07/06/2018     Added supplier warranty field
//[002]      Aashu          16/08/2018     REB-12322 : A tick box to recomond test the parts from HUB side.
//-----------------------------------------------------------------------------------------
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
	
	public abstract class SourcingResultProvider : DataAccess {
		static private SourcingResultProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SourcingResultProvider Instance {
			get {
				if (_instance == null) _instance = (SourcingResultProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.SourcingResults.ProviderType));
				return _instance;
			}
		}
		public SourcingResultProvider() {
			this.ConnectionString = Globals.Settings.SourcingResults.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_SourcingResult]
		/// </summary>
		public abstract bool Delete(System.Int32? sourcingResultId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_SourcingResult]
		/// </summary>
        public abstract Int32 Insert(System.Int32? customerRequirementNo, System.String typeName, System.String notes, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? offerStatusNo, System.Int32? supplierNo, System.Byte? rohs, System.Int32? clientNo, System.Int32? updatedBy, System.Int32? mslLevelNo);
		/// <summary>
		/// InsertFromHistory
		/// Calls [usp_insert_SourcingResult_From_History]
		/// </summary>
		public abstract Int32 InsertFromHistory(System.Int32? customerRequirementNo, System.Int32? historyNo, System.Int32? clientNo, System.Int32? updatedBy);
		/// <summary>
		/// InsertFromOffer
		/// Calls [usp_insert_SourcingResult_From_Offer]
		/// </summary>
        public abstract Int32 InsertFromOffer(System.Int32? customerRequirementNo, System.Int32? offerNo, System.Int32? updatedBy, System.Boolean isPOHub);
		/// <summary>
		/// InsertFromTrusted
		/// Calls [usp_insert_SourcingResult_From_Trusted]
		/// </summary>
        public abstract Int32 InsertFromTrusted(System.Int32? customerRequirementNo, System.Int32? excessNo, System.Int32? updatedBy, System.Boolean isPOHub);
        /// <summary>
        /// Release
        /// Calls [usp_update_Sourcing_Release]
        /// </summary>
        public abstract bool ReleaseSourcing(System.Int32? sourcingResultID, System.Int32? updatedBy);
        
        /// <summary>
        /// InsertFromPurchaseQuote
        /// Calls [usp_insert_SourcingResult_From_POQuote]
        /// </summary>
        public abstract Int32 InsertFromPOQuote(System.Int32? customerRequirementNo, System.Int32? poQuoteLineNo, System.Int32? updatedBy);
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_SourcingResult]
		/// </summary>
        public abstract List<SourcingResultDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Int32? customerRequirementNoLo, System.Int32? customerRequirementNoHi, System.String supplierSearch, System.Boolean? IsPoHub, System.Int32? intQuoteID,System.String bom);
		/// <summary>
		/// Get
		/// Calls [usp_select_SourcingResult]
		/// </summary>
		public abstract SourcingResultDetails Get(System.Int32? sourcingResultId);
		/// <summary>
		/// GetListForCustomerRequirement
		/// Calls [usp_selectAll_SourcingResult_for_CustomerRequirement]
		/// </summary>
		public abstract List<SourcingResultDetails> GetListForCustomerRequirement(System.Int32? customerRequirementId);

        public abstract List<SourcingResultDetails> GetListForCustomerRequirementCopy(System.Int32? customerRequirementId);

        /// <summary>
        /// SourcingResult_for_CustomerRequirement
        /// Calls [usp_SourcingResult_for_CustomerRequirement]
        /// </summary>
        public abstract List<SourcingResultDetails> GetListForSourcing(System.Int32? customerRequirementId, System.Boolean? isFromQuote);
		/// <summary>
		/// GetListForQuoteLine
		/// Calls [usp_selectAll_SourcingResult_for_QuoteLine]
		/// </summary>
		public abstract List<SourcingResultDetails> GetListForQuoteLine(System.Int32? quoteLineId);
		/// <summary>
		/// Update
		/// Calls [usp_update_SourcingResult]
		/// </summary>
		public abstract bool Update(System.Int32? sourcingResultId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.Int32? offerStatusNo, System.Int32? supplierNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy,System.Int32? mslLevelNo);

        /// <summary>
        /// Update
        /// Calls [usp_update_POHubSourcingResult]
        /// </summary>
        //[002] start
        public abstract bool UpdatePOHub(System.Int32? sourcingResultId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.Int32? offerStatusNo, System.Int32? supplierNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Double? suplierPrice, double? estimatedShippingCost, DateTime? deliveryDate, bool isPoHub, System.String SPQ, System.String leadTime, System.String rohsStatus, System.String factorySealed, System.String MSL, System.String supplierTotalQSA, System.String supplierMOQ, System.String supplierLTB, System.Int32? regionNo, System.Int32? hubcurrencyNo, System.Int32? linkMultiCurrencyNo, System.Int32? mslLevelNo, System.Int32? supplierWarranty,System.Boolean? isTestingRecommended);


        /// <summary>
        /// GetListForBOMCustomerRequirement
        /// Calls [usp_selectAll_SourcingResult_for_BOMCustomerRequirement]
        /// </summary>
        public abstract List<SourcingResultDetails> GetListForBOMCustomerRequirement(System.Int32? customerRequirementId, System.Boolean isPOHub);

        /// <summary>
        /// Get
        /// Calls [usp_Convert_Price_To_Different_Currency]
        /// </summary>
        public abstract SourcingResultDetails ConvertPriceToDifferentCurrency(System.Int32? intFromCurrency, System.Int32? intToCurrency, System.Double? upliftPrice, System.Double? hubBuyPrice, System.Int32? sourcingResultNo);

		#endregion
				
		/// <summary>
		/// Returns a new SourcingResultDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual SourcingResultDetails GetSourcingResultFromReader(DbDataReader reader) {
			SourcingResultDetails sourcingResult = new SourcingResultDetails();
			if (reader.HasRows) {
				sourcingResult.SourcingResultId = GetReaderValue_Int32(reader, "SourcingResultId", 0); //From: [Table]
				sourcingResult.CustomerRequirementNo = GetReaderValue_Int32(reader, "CustomerRequirementNo", 0); //From: [Table]
				sourcingResult.SourcingTable = GetReaderValue_String(reader, "SourcingTable", ""); //From: [Table]
				sourcingResult.SourcingTableItemNo = GetReaderValue_NullableInt32(reader, "SourcingTableItemNo", null); //From: [Table]
				sourcingResult.TypeName = GetReaderValue_String(reader, "TypeName", ""); //From: [Table]
				sourcingResult.FullPart = GetReaderValue_String(reader, "FullPart", ""); //From: [Table]
				sourcingResult.Part = GetReaderValue_String(reader, "Part", ""); //From: [Table]
				sourcingResult.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null); //From: [Table]
				sourcingResult.DateCode = GetReaderValue_String(reader, "DateCode", ""); //From: [Table]
				sourcingResult.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null); //From: [Table]
				sourcingResult.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null); //From: [Table]
				sourcingResult.Quantity = GetReaderValue_Int32(reader, "Quantity", 0); //From: [Table]
				sourcingResult.Price = GetReaderValue_Double(reader, "Price", 0); //From: [Table]
				sourcingResult.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0); //From: [Table]
				sourcingResult.OriginalEntryDate = GetReaderValue_NullableDateTime(reader, "OriginalEntryDate", null); //From: [Table]
				sourcingResult.Salesman = GetReaderValue_Int32(reader, "Salesman", 0); //From: [Table]
				sourcingResult.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null); //From: [Table]
				sourcingResult.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				sourcingResult.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				sourcingResult.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0); //From: [Table]
				sourcingResult.OfferStatusNo = GetReaderValue_NullableInt32(reader, "OfferStatusNo", null); //From: [Table]
				sourcingResult.OfferStatusChangeDate = GetReaderValue_NullableDateTime(reader, "OfferStatusChangeDate", null); //From: [Table]
				sourcingResult.OfferStatusChangeLoginNo = GetReaderValue_NullableInt32(reader, "OfferStatusChangeLoginNo", null); //From: [Table]
				sourcingResult.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				sourcingResult.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_source_Offer]
				sourcingResult.CustomerRequirementId = GetReaderValue_NullableInt32(reader, "CustomerRequirementId", null); //From: [usp_itemsearch_SourcingResult]
				sourcingResult.CustomerRequirementNumber = GetReaderValue_NullableInt32(reader, "CustomerRequirementNumber", null); //From: [usp_itemsearch_SourcingResult]
				sourcingResult.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null); //From: [Table]
				sourcingResult.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null); //From: [usp_itemsearch_SourcingResult]
				sourcingResult.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_itemsearch_SourcingResult]
				sourcingResult.SupplierName = GetReaderValue_String(reader, "SupplierName", ""); //From: [Table]
				sourcingResult.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", ""); //From: [usp_source_Offer]
				sourcingResult.ProductName = GetReaderValue_String(reader, "ProductName", ""); //From: [Table]
				sourcingResult.PackageName = GetReaderValue_String(reader, "PackageName", ""); //From: [Table]
				sourcingResult.OfferStatusChangeEmployeeName = GetReaderValue_String(reader, "OfferStatusChangeEmployeeName", ""); //From: [usp_source_Offer]
				sourcingResult.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_itemsearch_SourcingResult]
				sourcingResult.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", ""); //From: [Table]
				sourcingResult.CustomerPart = GetReaderValue_String(reader, "CustomerPart", ""); //From: [usp_select_SourcingResult]
				sourcingResult.ProductDescription = GetReaderValue_String(reader, "ProductDescription", ""); //From: [usp_selectAll_SourcingResult_for_CustomerRequirement]
				sourcingResult.PackageDescription = GetReaderValue_String(reader, "PackageDescription", ""); //From: [usp_selectAll_SourcingResult_for_CustomerRequirement]
				sourcingResult.SalesmanName = GetReaderValue_String(reader, "SalesmanName", ""); //From: [usp_source_Offer]
			}
			return sourcingResult;
		}
	
		/// <summary>
		/// Returns a collection of SourcingResultDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<SourcingResultDetails> GetSourcingResultCollectionFromReader(DbDataReader reader) {
			List<SourcingResultDetails> sourcingResults = new List<SourcingResultDetails>();
			while (reader.Read()) sourcingResults.Add(GetSourcingResultFromReader(reader));
			return sourcingResults;
		}


        /// <summary>
        /// Insert
        /// Calls [usp_insert_SourcingResultWithOffer]
        /// </summary>
        //[001],[002] start
        public abstract Int32 InsertSourcingResult(System.Int32? customerRequirementNo, System.String typeName, System.String notes, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price,  System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? offerStatusNo, System.Int32? supplierNo, System.Byte? rohs, System.Int32? clientNo, System.Int32? updatedBy,
             System.Double? suplierPrice, double? estimatedShippingCost, DateTime? deliveryDate, bool isPoHub, System.String SPQ, System.String leadTime, System.String rohsStatus, System.String factorySealed, System.String MSL, System.String supplierTotalQSA, System.String supplierMOQ, System.String supplierLTB, System.Int32? regionNo, System.Int32? hubcurrencyNo, System.Int32? mslLevelNo, System.Int32? supplierWarranty,System.Boolean? isTestingRecommended);

		
		
	}
}
