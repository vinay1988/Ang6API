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
	
	public abstract class SettingProvider : DataAccess {
		static private SettingProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SettingProvider Instance {
			get {
				if (_instance == null) _instance = (SettingProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Settings.ProviderType));
				return _instance;
			}
		}
		public SettingProvider() {
			this.ConnectionString = Globals.Settings.Settings.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Setting]
		/// </summary>
		public abstract Int32 Insert(System.Int32? settingItemId, System.Int32? clientId, System.String settingValue, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_Setting]
		/// </summary>
		public abstract SettingDetails Get(System.Int32? settingId);
		/// <summary>
		/// GetValue
		/// Calls [usp_select_Setting_Value]
		/// </summary>
		public abstract SettingDetails GetValue(System.Int32? settingItemId, System.Int32? clientId);
		/// <summary>
		/// GetListValues
		/// Calls [usp_selectAll_Setting_values]
		/// </summary>
		public abstract List<SettingDetails> GetListValues(System.Int32? clientId);
		/// <summary>
		/// Update
		/// Calls [usp_update_Setting]
		/// </summary>
		public abstract bool Update(System.Int32? settingItemId, System.Int32? clientId, System.String settingValue, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new SettingDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual SettingDetails GetSettingFromReader(DbDataReader reader) {
			SettingDetails setting = new SettingDetails();
			if (reader.HasRows) {
				setting.SettingID = GetReaderValue_Int32(reader, "SettingID", 0); //From: [Table]
				setting.SettingItemID = GetReaderValue_Int32(reader, "SettingItemID", 0); //From: [Table]
				setting.ClientID = GetReaderValue_NullableInt32(reader, "ClientID", null); //From: [Table]
				setting.SettingValue = GetReaderValue_String(reader, "SettingValue", ""); //From: [Table]
				setting.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				setting.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null); //From: [Table]
				setting.SettingItemName = GetReaderValue_String(reader, "SettingItemName", ""); //From: [usp_selectAll_Setting_values]
				setting.DefaultValue = GetReaderValue_String(reader, "DefaultValue", ""); //From: [usp_selectAll_Setting_values]
			}
			return setting;
		}
	
		/// <summary>
		/// Returns a collection of SettingDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<SettingDetails> GetSettingCollectionFromReader(DbDataReader reader) {
			List<SettingDetails> settings = new List<SettingDetails>();
			while (reader.Read()) settings.Add(GetSettingFromReader(reader));
			return settings;
		}
		
		
	}
}