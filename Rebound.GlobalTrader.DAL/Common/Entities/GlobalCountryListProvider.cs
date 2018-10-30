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
	
	public abstract class GlobalCountryListProvider : DataAccess {
		static private GlobalCountryListProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public GlobalCountryListProvider Instance {
			get {
				if (_instance == null) _instance = (GlobalCountryListProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.GlobalCountryLists.ProviderType));
				return _instance;
			}
		}
		public GlobalCountryListProvider() {
			this.ConnectionString = Globals.Settings.GlobalCountryLists.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_GlobalCountryList]
		/// </summary>
		public abstract List<GlobalCountryListDetails> DropDown(System.Boolean? includeSelected, System.Int32? clientNo);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_GlobalCountryList]
		/// </summary>
		public abstract Int32 Insert(System.String globalCountryName, System.Boolean? eecMember, System.String telephonePrefix, System.Boolean? include, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_GlobalCountryList]
		/// </summary>
		public abstract GlobalCountryListDetails Get(System.Int32? countryNo);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_GlobalCountryList]
		/// </summary>
		public abstract List<GlobalCountryListDetails> GetList();
		/// <summary>
		/// Update
		/// Calls [usp_update_GlobalCountryList]
		/// </summary>
		public abstract bool Update(System.Int32? globalCountryId, System.String globalCountryName, System.String telephonePrefix, System.Boolean? eecMember, System.Boolean? include, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new GlobalCountryListDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual GlobalCountryListDetails GetGlobalCountryListFromReader(DbDataReader reader) {
			GlobalCountryListDetails globalCountryList = new GlobalCountryListDetails();
			if (reader.HasRows) {
				globalCountryList.GlobalCountryId = GetReaderValue_Int32(reader, "GlobalCountryId", 0); //From: [Table]
				globalCountryList.GlobalCountryName = GetReaderValue_String(reader, "GlobalCountryName", ""); //From: [Table]
				globalCountryList.EECMember = GetReaderValue_Boolean(reader, "EECMember", false); //From: [Table]
				globalCountryList.TelephonePrefix = GetReaderValue_String(reader, "TelephonePrefix", ""); //From: [Table]
				globalCountryList.Include = GetReaderValue_Boolean(reader, "Include", false); //From: [Table]
				globalCountryList.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				globalCountryList.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
			}
			return globalCountryList;
		}
	
		/// <summary>
		/// Returns a collection of GlobalCountryListDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<GlobalCountryListDetails> GetGlobalCountryListCollectionFromReader(DbDataReader reader) {
			List<GlobalCountryListDetails> globalCountryLists = new List<GlobalCountryListDetails>();
			while (reader.Read()) globalCountryLists.Add(GetGlobalCountryListFromReader(reader));
			return globalCountryLists;
		}
		
		
	}
}