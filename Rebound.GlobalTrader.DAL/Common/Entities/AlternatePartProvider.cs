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
	
	public abstract class AlternatePartProvider : DataAccess {
		static private AlternatePartProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public AlternatePartProvider Instance {
			get {
				if (_instance == null) _instance = (AlternatePartProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.AlternateParts.ProviderType));
				return _instance;
			}
		}
		public AlternatePartProvider() {
			this.ConnectionString = Globals.Settings.AlternateParts.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_AlternatePart]
		/// </summary>
		public abstract bool Delete(System.Int32? alternatePartId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_AlternatePart]
		/// </summary>
		public abstract Int32 Insert(System.Int32? partNo, System.String fullPart, System.String part, System.Boolean? rohsCompliant, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_AlternatePart]
		/// </summary>
		public abstract AlternatePartDetails Get(System.Int32? alternatePartId);
		/// <summary>
		/// Update
		/// Calls [usp_update_AlternatePart]
		/// </summary>
		public abstract bool Update(System.Int32? alternatePartId, System.Int32? partNo, System.String fullPart, System.String part, System.Boolean? rohsCompliant, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new AlternatePartDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual AlternatePartDetails GetAlternatePartFromReader(DbDataReader reader) {
			AlternatePartDetails alternatePart = new AlternatePartDetails();
			if (reader.HasRows) {
				alternatePart.AlternatePartId = GetReaderValue_Int32(reader, "AlternatePartId", 0); //From: [Table]
				alternatePart.PartNo = GetReaderValue_Int32(reader, "PartNo", 0); //From: [Table]
				alternatePart.FullPart = GetReaderValue_String(reader, "FullPart", ""); //From: [Table]
				alternatePart.Part = GetReaderValue_String(reader, "Part", ""); //From: [usp_selectAll_Allocation]
				alternatePart.ROHSCompliant = GetReaderValue_Boolean(reader, "ROHSCompliant", false); //From: [Table]
				alternatePart.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				alternatePart.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
			}
			return alternatePart;
		}
	
		/// <summary>
		/// Returns a collection of AlternatePartDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<AlternatePartDetails> GetAlternatePartCollectionFromReader(DbDataReader reader) {
			List<AlternatePartDetails> alternateParts = new List<AlternatePartDetails>();
			while (reader.Read()) alternateParts.Add(GetAlternatePartFromReader(reader));
			return alternateParts;
		}
		
		
	}
}