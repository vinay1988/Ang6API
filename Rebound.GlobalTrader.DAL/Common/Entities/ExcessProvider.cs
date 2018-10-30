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
	
	public abstract class ExcessProvider : DataAccess {
		static private ExcessProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ExcessProvider Instance {
			get {
				if (_instance == null) _instance = (ExcessProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Excesss.ProviderType));
				return _instance;
			}
		}
		public ExcessProvider() {
			this.ConnectionString = Globals.Settings.Excesss.ConnectionString;
            this.GTConnectionString = Globals.Settings.Excesss.GTConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Excess]
		/// </summary>
		public abstract bool Delete(System.Int32? excessId);
		/// <summary>
		/// 
		/// Calls [usp_Import_Excess]
		/// </summary>
		/// <summary>
		/// Insert
        /// Calls [usp_insert_ExcessNew]
		/// </summary>
        public abstract Int32 Insert(System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? companyNo, System.String companyName, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Int32? clientNo, System.Int32? offerStatusNo, bool? isPoHub);

        /// <summary>
        /// 
        /// Calls [usp_Import_Excess]
        /// </summary>
        /// <summary>
        /// Insert
        /// Calls [usp_insert_ExcessNew]
        /// </summary>
        public abstract Int32 IPOBOMInsert(System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? companyNo, System.String companyName, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Int32? clientNo, System.Int32? offerStatusNo, bool? isPoHub,System.String supplierTotalQSA, System.String supplierMOQ, System.String supplierLTB, System.String msl, System.String spq, System.String leadTime, System.String factorySealed, System.String rohsStatus,System.Int32? mslLevel);
        /// Insert
        /// Calls [usp_insert_ExcessClone]
        /// </summary>
        public abstract Int32 CloneTrustedAddToReq(System.Int32 trustedId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? companyNo, System.String companyName, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Int32? clientNo, System.Int32? offerStatusNo, bool? isPoHub, System.String supplierTotalQSA, System.String supplierMOQ, System.String supplierLTB, System.String msl, System.String spq, System.String leadTime, System.String factorySealed, System.String rohsStatus, System.Int32? customerRequirementNo, System.Int32? mslLevelNo);


        /// <summary>
		/// Get
		/// Calls [usp_select_Excess]
		/// </summary>
        public abstract ExcessDetails Get(System.Int32? excessId, bool? isPoHub);
		/// <summary>
		/// Source
		/// Calls [usp_source_Excess]
		/// </summary>
        public abstract List<ExcessDetails> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool IsServerLocal, System.Boolean? isPohub);

        /// <summary>
        /// Source
        /// Calls [usp_ipobom_source_Excess]
        /// </summary>
        public abstract List<ExcessDetails> IPOBOMSource(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool IsServerLocal, System.Boolean? isPohub);
		/// <summary>
		/// Update
		/// Calls [usp_update_Excess]
		/// </summary>
        public abstract bool Update(System.Int32? excessId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.Int32? offerStatusNo, System.Int32? companyNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, bool? isPoHub);

        /// <summary>
        /// Update
        /// Calls [usp_update_Excess]
        /// </summary>
        public abstract bool IPOBOMUpdate(System.Int32? excessId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.Int32? offerStatusNo, System.Int32? companyNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, bool? isPoHub, System.String supplierTotalQSA, System.String supplierMOQ, System.String supplierLTB, System.String MSL, System.String SPQ, System.String leadTime, System.String factorySealed, System.String rohsStatus, System.Int32? mslLevelNo);
		/// <summary>
		/// UpdateForSourcing
		/// Calls [usp_update_Excess_for_sourcing]
		/// </summary>
		public abstract bool UpdateForSourcing(System.Int32? excessId, System.Int32? quantity, System.Double? price, System.String notes, System.Int32? updatedBy);
		/// <summary>
		/// UpdateOfferStatus
		/// Calls [usp_update_Excess_OfferStatus]
		/// </summary>
		public abstract bool UpdateOfferStatus(System.Int32? excessNo, System.Int32? offerStatusNo, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new ExcessDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ExcessDetails GetExcessFromReader(DbDataReader reader) {
			ExcessDetails excess = new ExcessDetails();
			if (reader.HasRows) {
				excess.ExcessId = GetReaderValue_Int32(reader, "ExcessId", 0); //From: [Table]
				excess.ExcessName = GetReaderValue_String(reader, "ExcessName", ""); //From: [Table]
				excess.FullPart = GetReaderValue_String(reader, "FullPart", ""); //From: [Table]
				excess.Part = GetReaderValue_String(reader, "Part", ""); //From: [Table]
				excess.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null); //From: [Table]
				excess.DateCode = GetReaderValue_String(reader, "DateCode", ""); //From: [Table]
				excess.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null); //From: [Table]
				excess.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null); //From: [Table]
				excess.Quantity = GetReaderValue_Int32(reader, "Quantity", 0); //From: [Table]
				excess.Price = GetReaderValue_Double(reader, "Price", 0); //From: [Table]
				excess.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null); //From: [Table]
				excess.OriginalEntryDate = GetReaderValue_NullableDateTime(reader, "OriginalEntryDate", null); //From: [Table]
				excess.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null); //From: [Table]
				excess.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [Table]
				excess.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0); //From: [Table]
				excess.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				excess.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				excess.OfferStatusNo = GetReaderValue_NullableInt32(reader, "OfferStatusNo", null); //From: [Table]
				excess.OfferStatusChangeDate = GetReaderValue_NullableDateTime(reader, "OfferStatusChangeDate", null); //From: [Table]
				excess.OfferStatusChangeLoginNo = GetReaderValue_NullableInt32(reader, "OfferStatusChangeLoginNo", null); //From: [Table]
				excess.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [Table]
				excess.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				excess.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", ""); //From: [Table]
				excess.ProductName = GetReaderValue_String(reader, "ProductName", ""); //From: [Table]
				excess.PackageName = GetReaderValue_String(reader, "PackageName", ""); //From: [Table]
				excess.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null); //From: [Table]
				excess.SupplierName = GetReaderValue_String(reader, "SupplierName", ""); //From: [usp_source_Excess]
				excess.SupplierEmail = GetReaderValue_String(reader, "SupplierEmail", ""); //From: [usp_source_Excess]
				excess.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", ""); //From: [usp_source_Excess]
				excess.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_source_Excess]
				excess.SalesmanName = GetReaderValue_String(reader, "SalesmanName", ""); //From: [usp_source_Excess]
				excess.OfferStatusChangeEmployeeName = GetReaderValue_String(reader, "OfferStatusChangeEmployeeName", ""); //From: [usp_source_Excess]
				excess.ClientName = GetReaderValue_String(reader, "ClientName", ""); //From: [usp_source_Excess]
				excess.ClientDataVisibleToOthers = GetReaderValue_NullableBoolean(reader, "ClientDataVisibleToOthers", null); //From: [usp_source_Excess]
			}
			return excess;
		}
	
		/// <summary>
		/// Returns a collection of ExcessDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ExcessDetails> GetExcessCollectionFromReader(DbDataReader reader) {
			List<ExcessDetails> excesss = new List<ExcessDetails>();
			while (reader.Read()) excesss.Add(GetExcessFromReader(reader));
			return excesss;
		}
		
		
	}
}
