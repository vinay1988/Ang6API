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
	
	public abstract class OfferProvider : DataAccess {
		static private OfferProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public OfferProvider Instance {
			get {
				if (_instance == null) _instance = (OfferProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Offers.ProviderType));
				return _instance;
			}
		}
		public OfferProvider() {
			this.ConnectionString = Globals.Settings.Offers.ConnectionString;
            this.GTConnectionString = Globals.Settings.Offers.GTConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Offer]
		/// </summary>
		public abstract bool Delete(System.Int32? offerId);
		/// <summary>
		/// 
		/// Calls [usp_Import_Offer]
		/// </summary>
		/// <summary>
		/// Insert
        /// Calls [usp_insert_OfferNew]
		/// </summary>
        public abstract Int32 Insert(System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? supplierNo, System.String supplierName, System.Byte? rohs, System.Int32? offerStatusNo, System.String notes, System.Int32? updatedBy, System.Int32? clientNo, bool? isPoHub);

        /// <summary>
        /// 
        /// Calls [usp_Import_Offer]
        /// </summary>
        /// <summary>
        /// Insert
        /// Calls [usp_insert_OfferNew]
        /// </summary>
        public abstract Int32 IPOBOMInsert(System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? supplierNo, System.String supplierName, System.Byte? rohs, System.Int32? offerStatusNo, System.String notes, System.Int32? updatedBy, System.Int32? clientNo, bool? isPoHub, System.String supplierTotalQSA, System.String supplierMOQ, System.String supplierLTB, System.String msl, System.String spq, System.String leadTime, System.String factorySealed, System.String rohsStatus, System.Int32? mslLevelNo);
        /// <summary>
        /// usp_offer_clone_AddToRequirement
        /// </summary>
        /// <returns></returns>
        public abstract Int32 CloneOfferAddToReq(System.Int32 offerId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? supplierNo, System.String supplierName, System.Byte? rohs, System.Int32? offerStatusNo, System.String notes, System.Int32? updatedBy, System.Int32? clientNo, bool? isPoHub, System.String supplierTotalQSA, System.String supplierMOQ, System.String supplierLTB, System.String msl, System.String spq, System.String leadTime, System.String factorySealed, System.String rohsStatus, System.Int32? customerRequirementNo, System.Int32? mslLevelNo);
		/// <summary>
		/// Get
		/// Calls [usp_select_Offer]
		/// </summary>
		public abstract OfferDetails Get(System.Int32? offerId,bool? isPoHub);
		/// <summary>
		/// Source
		/// Calls [usp_source_Offer]
		/// </summary>
        public abstract List<OfferDetails> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool IsServerLocal,System.Boolean? IsPOHub);

        /// <summary>
        /// Source
        /// Calls [usp_source_Offer_PQ_Trusted]
        /// </summary>
        public abstract List<OfferDetails> SourceOfferAll(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool IsServerLocal);

        /// <summary>
        /// Source
        /// Calls [[usp_ipobom_source_Offer]]
        /// </summary>
        public abstract List<OfferDetails> IPOBOMSource(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool IsServerLocal,System.Boolean? isPohub);
		
        /// <summary>
		/// Update
		/// Calls [usp_update_Offer]
		/// </summary>
        public abstract bool Update(System.Int32? offerId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.Int32? salesman, System.Int32? offerStatusNo, System.Int32? supplierNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, bool? isPoHub);

        /// <summary>
        /// Update
        /// Calls [usp_ipobom_update_Offer]
        /// </summary>
        public abstract bool IPOBOMUpdate(System.Int32? offerId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.Int32? salesman, System.Int32? offerStatusNo, System.Int32? supplierNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, bool? isPoHub, System.String supplierTotalQSA, System.String supplierMOQ, System.String supplierLTB, System.String MSL, System.String SPQ, System.String leadTime, System.String factorySealed, System.String rohsStatus, System.Int32? mslLevelNo);
		/// <summary>
		/// UpdateForSourcing
		/// Calls [usp_update_Offer_for_sourcing]
		/// </summary>
		public abstract bool UpdateForSourcing(System.Int32? offerId, System.Int32? quantity, System.Double? price, System.String notes, System.Int32? updatedBy);
		/// <summary>
		/// UpdateOfferStatus
		/// Calls [usp_update_Offer_OfferStatus]
		/// </summary>
		public abstract bool UpdateOfferStatus(System.Int32? offerNo, System.Int32? offerStatusNo, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new OfferDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual OfferDetails GetOfferFromReader(DbDataReader reader) {
			OfferDetails offer = new OfferDetails();
			if (reader.HasRows) {
				offer.OfferId = GetReaderValue_Int32(reader, "OfferId", 0); //From: [Table]
				offer.FullPart = GetReaderValue_String(reader, "FullPart", ""); //From: [Table]
				offer.Part = GetReaderValue_String(reader, "Part", ""); //From: [Table]
				offer.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null); //From: [Table]
				offer.DateCode = GetReaderValue_String(reader, "DateCode", ""); //From: [Table]
				offer.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null); //From: [Table]
				offer.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null); //From: [Table]
				offer.Quantity = GetReaderValue_Int32(reader, "Quantity", 0); //From: [Table]
				offer.Price = GetReaderValue_Double(reader, "Price", 0); //From: [Table]
				offer.OriginalEntryDate = GetReaderValue_NullableDateTime(reader, "OriginalEntryDate", null); //From: [Table]
				offer.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null); //From: [Table]
				offer.SupplierNo = GetReaderValue_Int32(reader, "SupplierNo", 0); //From: [Table]
				offer.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null); //From: [Table]
				offer.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0); //From: [Table]
				offer.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				offer.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				offer.OfferStatusNo = GetReaderValue_NullableInt32(reader, "OfferStatusNo", null); //From: [Table]
				offer.OfferStatusChangeDate = GetReaderValue_NullableDateTime(reader, "OfferStatusChangeDate", null); //From: [Table]
				offer.OfferStatusChangeLoginNo = GetReaderValue_NullableInt32(reader, "OfferStatusChangeLoginNo", null); //From: [Table]
				offer.SupplierName = GetReaderValue_String(reader, "SupplierName", ""); //From: [Table]
				offer.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				offer.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", ""); //From: [Table]
				offer.ProductName = GetReaderValue_String(reader, "ProductName", ""); //From: [Table]
				offer.PackageName = GetReaderValue_String(reader, "PackageName", ""); //From: [Table]
				offer.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null); //From: [Table]
				offer.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", ""); //From: [usp_source_Offer]
				offer.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_source_Offer]
				offer.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_source_Offer]
				offer.SupplierEmail = GetReaderValue_String(reader, "SupplierEmail", ""); //From: [usp_source_Offer]
				offer.SalesmanName = GetReaderValue_String(reader, "SalesmanName", ""); //From: [usp_source_Offer]
				offer.OfferStatusChangeEmployeeName = GetReaderValue_String(reader, "OfferStatusChangeEmployeeName", ""); //From: [usp_source_Offer]
				offer.ClientId = GetReaderValue_Int32(reader, "ClientId", 0); //From: [usp_source_Offer]
				offer.ClientName = GetReaderValue_String(reader, "ClientName", ""); //From: [usp_source_Offer]
				offer.ClientDataVisibleToOthers = GetReaderValue_NullableBoolean(reader, "ClientDataVisibleToOthers", null); //From: [usp_source_Offer]
			}
			return offer;
		}
	
		/// <summary>
		/// Returns a collection of OfferDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<OfferDetails> GetOfferCollectionFromReader(DbDataReader reader) {
			List<OfferDetails> offers = new List<OfferDetails>();
			while (reader.Read()) offers.Add(GetOfferFromReader(reader));
			return offers;
		}
		
		
	}
}
