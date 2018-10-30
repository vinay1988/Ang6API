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
	
	public abstract class IndustryTypeProvider : DataAccess {
		static private IndustryTypeProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public IndustryTypeProvider Instance {
			get {
				if (_instance == null) _instance = (IndustryTypeProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.IndustryTypes.ProviderType));
				return _instance;
			}
		}
		public IndustryTypeProvider() {
			this.ConnectionString = Globals.Settings.IndustryTypes.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_IndustryType]
		/// </summary>
		public abstract bool Delete(System.Int32? industryTypeId);
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_IndustryType]
		/// </summary>
		public abstract List<IndustryTypeDetails> DropDown();
		/// <summary>
		/// Insert
		/// Calls [usp_insert_IndustryType]
		/// </summary>
		public abstract Int32 Insert(System.String name);
		/// <summary>
		/// Get
		/// Calls [usp_select_IndustryType]
		/// </summary>
		public abstract IndustryTypeDetails Get(System.Int32? industryTypeId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_IndustryType]
		/// </summary>
		public abstract List<IndustryTypeDetails> GetList();
		/// <summary>
		/// Update
		/// Calls [usp_update_IndustryType]
		/// </summary>
		public abstract bool Update(System.String name, System.Int32? industryTypeId, System.Boolean? inactive, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new IndustryTypeDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual IndustryTypeDetails GetIndustryTypeFromReader(DbDataReader reader) {
			IndustryTypeDetails industryType = new IndustryTypeDetails();
			if (reader.HasRows) {
				industryType.IndustryTypeId = GetReaderValue_Int32(reader, "IndustryTypeId", 0); //From: [Table]
				industryType.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
				industryType.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				industryType.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				industryType.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null); //From: [Table]
			}
			return industryType;
		}
	
		/// <summary>
		/// Returns a collection of IndustryTypeDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<IndustryTypeDetails> GetIndustryTypeCollectionFromReader(DbDataReader reader) {
			List<IndustryTypeDetails> industryTypes = new List<IndustryTypeDetails>();
			while (reader.Read()) industryTypes.Add(GetIndustryTypeFromReader(reader));
			return industryTypes;
		}
		
		
	}
}