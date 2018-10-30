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
	
	public abstract class HistoryProvider : DataAccess {
		static private HistoryProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public HistoryProvider Instance {
			get {
				if (_instance == null) _instance = (HistoryProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Historys.ProviderType));
				return _instance;
			}
		}
		public HistoryProvider() {
			this.ConnectionString = Globals.Settings.Historys.ConnectionString;
            this.GTConnectionString = Globals.Settings.Historys.GTConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_History]
		/// </summary>
		public abstract bool Delete(System.Int32? historyNo);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_History]
		/// </summary>
		public abstract Int32 Insert(System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? offerStatusNo, System.DateTime? offerStatusChangeDate, System.Int32? offerStatusChangeLoginNo, System.Int32? supplierNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_History]
		/// </summary>
		public abstract HistoryDetails Get(System.Int32? historyNo);
		/// <summary>
		/// Source
		/// Calls [usp_source_History]
		/// </summary>
        public abstract List<HistoryDetails> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool IsServerLocal,bool? isPoHub);
		/// <summary>
		/// Update
		/// Calls [usp_update_History]
		/// </summary>
		public abstract bool Update(System.Int32? historyId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.Int32? offerStatusNo, System.Int32? supplierNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy);
		/// <summary>
		/// UpdateForSourcing
		/// Calls [usp_update_History_for_sourcing]
		/// </summary>
		public abstract bool UpdateForSourcing(System.Int32? historyNo, System.Int32? quantity, System.Double? price, System.String notes, System.Int32? updatedBy);
		/// <summary>
		/// UpdateOfferStatus
		/// Calls [usp_update_History_OfferStatus]
		/// </summary>
		public abstract bool UpdateOfferStatus(System.Int32? historyNo, System.Int32? offerStatusNo, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new HistoryDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual HistoryDetails GetHistoryFromReader(DbDataReader reader) {
			HistoryDetails history = new HistoryDetails();
			if (reader.HasRows) {
				history.HistoryId = GetReaderValue_Int32(reader, "HistoryId", 0); //From: [Table]
				history.FullPart = GetReaderValue_String(reader, "FullPart", ""); //From: [Table]
				history.Part = GetReaderValue_String(reader, "Part", ""); //From: [Table]
				history.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null); //From: [Table]
				history.DateCode = GetReaderValue_String(reader, "DateCode", ""); //From: [Table]
				history.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null); //From: [Table]
				history.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null); //From: [Table]
				history.Quantity = GetReaderValue_Int32(reader, "Quantity", 0); //From: [Table]
				history.Price = GetReaderValue_Double(reader, "Price", 0); //From: [Table]
				history.OriginalEntryDate = GetReaderValue_NullableDateTime(reader, "OriginalEntryDate", null); //From: [Table]
				history.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null); //From: [Table]
				history.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null); //From: [Table]
				history.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null); //From: [Table]
				history.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0); //From: [Table]
				history.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				history.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				history.OfferStatusNo = GetReaderValue_NullableInt32(reader, "OfferStatusNo", null); //From: [Table]
				history.OfferStatusChangeDate = GetReaderValue_NullableDateTime(reader, "OfferStatusChangeDate", null); //From: [Table]
				history.OfferStatusChangeLoginNo = GetReaderValue_NullableInt32(reader, "OfferStatusChangeLoginNo", null); //From: [Table]
				history.SupplierName = GetReaderValue_String(reader, "SupplierName", ""); //From: [Table]
				history.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				history.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", ""); //From: [Table]
				history.ProductName = GetReaderValue_String(reader, "ProductName", ""); //From: [Table]
				history.PackageName = GetReaderValue_String(reader, "PackageName", ""); //From: [Table]
				history.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null); //From: [Table]
				history.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_source_History]
				history.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", ""); //From: [usp_source_History]
				history.SupplierEmail = GetReaderValue_String(reader, "SupplierEmail", ""); //From: [usp_source_History]
				history.SalesmanName = GetReaderValue_String(reader, "SalesmanName", ""); //From: [usp_source_History]
				history.OfferStatusChangeEmployeeName = GetReaderValue_String(reader, "OfferStatusChangeEmployeeName", ""); //From: [usp_source_History]
				history.ClientName = GetReaderValue_String(reader, "ClientName", ""); //From: [usp_source_History]
				history.ClientDataVisibleToOthers = GetReaderValue_NullableBoolean(reader, "ClientDataVisibleToOthers", null); //From: [usp_source_History]
			}
			return history;
		}
	
		/// <summary>
		/// Returns a collection of HistoryDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<HistoryDetails> GetHistoryCollectionFromReader(DbDataReader reader) {
			List<HistoryDetails> historys = new List<HistoryDetails>();
			while (reader.Read()) historys.Add(GetHistoryFromReader(reader));
			return historys;
		}
		
		
	}
}
