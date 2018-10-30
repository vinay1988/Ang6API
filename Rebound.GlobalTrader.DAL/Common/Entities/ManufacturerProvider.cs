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
	
	public abstract class ManufacturerProvider : DataAccess {
		static private ManufacturerProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ManufacturerProvider Instance {
			get {
				if (_instance == null) _instance = (ManufacturerProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Manufacturers.ProviderType));
				return _instance;
			}
		}
		public ManufacturerProvider() {
			this.ConnectionString = Globals.Settings.Manufacturers.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// AutoSearch
		/// Calls [usp_autosearch_Manufacturer]
		/// </summary>
		public abstract List<ManufacturerDetails> AutoSearch(System.String nameSearch,Boolean? showInactive);
		/// <summary>
		/// Count
		/// Calls [usp_count_Manufacturer]
		/// </summary>
		public abstract Int32 Count();
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_Manufacturer]
		/// </summary>
		public abstract List<ManufacturerDetails> DataListNugget(System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nameSearch, System.String codeSearch);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Manufacturer]
		/// </summary>
		public abstract bool Delete(System.Int32? manufacturerId);
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_Manufacturer]
		/// </summary>
		public abstract List<ManufacturerDetails> DropDown();
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Manufacturer]
		/// </summary>
		public abstract Int32 Insert(System.String manufacturerName, System.String notes, System.String manufacturerCode, System.Int32? updatedBy, System.String url);
		/// <summary>
		/// Get
		/// Calls [usp_select_Manufacturer]
		/// </summary>
		public abstract ManufacturerDetails Get(System.Int32? manufacturerId);
		/// <summary>
		/// Update
		/// Calls [usp_update_Manufacturer]
		/// </summary>
        public abstract bool Update(System.Int32? manufacturerId, System.String manufacturerName, System.String notes, System.String manufacturerCode, System.Boolean? inactive, System.Int32? updatedBy, System.String url, System.String conflictResource);

        /// <summary>
        /// Insert
        /// Calls [usp_insert_ManufacturerPDF]
        /// </summary>
        public abstract Int32 Insert(System.Int32? ManufacturerNo, System.String Caption, System.String FileName, System.Int32? updatedBy);



        /// <summary>
        /// Insert
        /// Calls [usp_insert_ManufacturerExcel]
        /// </summary>
        public abstract Int32 InsertExcel(System.Int32? ManufacturerNo, System.String Caption, System.String FileName, System.Int32? updatedBy);

        // [004] code start
        /// <summary>
        /// GetPDFListForManufaturer 
        /// Calls [usp_selectAll_PDF_for_Manufacturer]
        /// </summary>
        /// <param name="ManufacturerNo"></param>
        /// <returns></returns>
        public abstract List<PDFDocumentDetails> GetPDFListForManufacturer(System.Int32? ManufacturerNo);


        /// <summary>
        /// GetExcelListForManufaturer 
        /// Calls [usp_selectAll_Excel_for_Manufacturer]
        /// </summary>
        /// <param name="ManufacturerNo"></param>
        /// <returns></returns>
        public abstract List<PDFDocumentDetails> GetExcelListForManufacturer(System.Int32? ManufacturerNo);


        /// <summary>
        /// Calls [usp_delete_ManufacturerPDF]
        /// </summary>
        /// <param name="ManufacturerPdfId"></param>
        /// <returns></returns>
        public abstract bool DeleteManufacturerPDF(System.Int32? ManufacturerPdfId);

        /// <summary>
        /// Calls [usp_delete_ManufacturerExcel]
        /// </summary>
        /// <param name="ManufacturerPdfId"></param>
        /// <returns></returns>
        public abstract bool DeleteManufacturerExcel(System.Int32? ManufacturerExcelId);



		#endregion
				
		/// <summary>
		/// Returns a new ManufacturerDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ManufacturerDetails GetManufacturerFromReader(DbDataReader reader) {
			ManufacturerDetails manufacturer = new ManufacturerDetails();
			if (reader.HasRows) {
				manufacturer.ManufacturerId = GetReaderValue_Int32(reader, "ManufacturerId", 0); //From: [Table]
				manufacturer.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", ""); //From: [usp_selectAll_Allocation]
				manufacturer.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
				manufacturer.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", ""); //From: [usp_selectAll_Allocation]
				manufacturer.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				manufacturer.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				manufacturer.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				manufacturer.URL = GetReaderValue_String(reader, "URL", ""); //From: [Table]
				manufacturer.FullName = GetReaderValue_String(reader, "FullName", ""); //From: [Table]
				manufacturer.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_list_Activity_by_Client_with_filter]
			}
			return manufacturer;
		}
	

		/// <summary>
		/// Returns a collection of ManufacturerDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ManufacturerDetails> GetManufacturerCollectionFromReader(DbDataReader reader) {
			List<ManufacturerDetails> manufacturers = new List<ManufacturerDetails>();
			while (reader.Read()) manufacturers.Add(GetManufacturerFromReader(reader));
			return manufacturers;
		}
		
		
	}
}