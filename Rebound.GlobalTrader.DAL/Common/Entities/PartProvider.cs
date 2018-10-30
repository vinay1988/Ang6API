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
	
	public abstract class PartProvider : DataAccess {
		static private PartProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public PartProvider Instance {
			get {
				if (_instance == null) _instance = (PartProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Parts.ProviderType));
				return _instance;
			}
		}
		public PartProvider() {
			this.ConnectionString = Globals.Settings.Parts.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// AutoSearch
		/// Calls [usp_autosearch_Part]
		/// </summary>
		public abstract List<PartDetails> AutoSearch(System.Int32? clientId, System.String partSearch);

        /// <summary>
		/// AutoSearch
        /// Calls [usp_autosearch_Part_New]
		/// </summary>
        public abstract List<PartDetails> CustReqPartSearch(System.Int32? clientId, System.String partSearch);
        /// <summary>
        /// AutoSearch
        /// Calls [usp_autosearch_CustReqPart]
        /// </summary>
        public abstract List<PartDetails> CustReqPart(System.Int32? clientId, System.String partSearch, System.String ids, System.String DateCode);
        /// <summary>
        /// AutoSearch
        /// Calls [usp_PartSearch_GRID]
        /// </summary>
        public abstract List<PartDetails> CustReqPartsGRID(System.Int32? clientId, System.String partSearch);

		/// <summary>
		/// Insert
		/// Calls [usp_insert_Part]
		/// </summary>
		public abstract Int32 Insert(System.String fullPart, System.Int32? manufacturerNo, System.Int32? packageNo, System.Int32? productNo, System.Int32? minimumQuantity, System.Int32? reOrderQuantity, System.Int32? leadTime, System.Int32? clientNo, System.Double? resalePrice, System.String partTitle, System.Boolean? masterPart, System.Boolean? goldenPart, System.Boolean? rohsCompliant, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new PartDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual PartDetails GetPartFromReader(DbDataReader reader) {
			PartDetails part = new PartDetails();
			if (reader.HasRows) {
				part.PartId = GetReaderValue_Int32(reader, "PartId", 0); //From: [Table]
				part.FullPart = GetReaderValue_String(reader, "FullPart", ""); //From: [Table]
				part.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null); //From: [usp_selectAll_Allocation]
				part.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null); //From: [usp_selectAll_Allocation]
				part.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null); //From: [usp_selectAll_Allocation]
				part.MinimumQuantity = GetReaderValue_NullableInt32(reader, "MinimumQuantity", null); //From: [Table]
				part.ReOrderQuantity = GetReaderValue_NullableInt32(reader, "ReOrderQuantity", null); //From: [Table]
				part.LeadTime = GetReaderValue_NullableInt32(reader, "LeadTime", null); //From: [Table]
				part.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				part.ResalePrice = GetReaderValue_NullableDouble(reader, "ResalePrice", null); //From: [Table]
				part.ROHSCompliant = GetReaderValue_Boolean(reader, "ROHSCompliant", false); //From: [Table]
				part.MasterPart = GetReaderValue_NullableBoolean(reader, "MasterPart", null); //From: [Table]
				part.GoldenPart = GetReaderValue_NullableBoolean(reader, "GoldenPart", null); //From: [Table]
				part.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				part.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				part.PartTitle = GetReaderValue_String(reader, "PartTitle", ""); //From: [Table]
				part.PartName = GetReaderValue_String(reader, "PartName", ""); //From: [usp_list_Activity_by_Client_with_filter]
			}
			return part;
		}
	
		/// <summary>
		/// Returns a collection of PartDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<PartDetails> GetPartCollectionFromReader(DbDataReader reader) {
			List<PartDetails> parts = new List<PartDetails>();
			while (reader.Read()) parts.Add(GetPartFromReader(reader));
			return parts;
		}
		
		
	}
}