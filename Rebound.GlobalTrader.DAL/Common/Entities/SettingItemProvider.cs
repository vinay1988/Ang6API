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
	
	public abstract class SettingItemProvider : DataAccess {
		static private SettingItemProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SettingItemProvider Instance {
			get {
				if (_instance == null) _instance = (SettingItemProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.SettingItems.ProviderType));
				return _instance;
			}
		}
		public SettingItemProvider() {
			this.ConnectionString = Globals.Settings.SettingItems.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_SettingItem]
		/// </summary>
		public abstract List<SettingItemDetails> GetList();

		#endregion
				
		/// <summary>
		/// Returns a new SettingItemDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual SettingItemDetails GetSettingItemFromReader(DbDataReader reader) {
			SettingItemDetails settingItem = new SettingItemDetails();
			if (reader.HasRows) {
				settingItem.SettingItemID = GetReaderValue_Int32(reader, "SettingItemID", 0); //From: [Table]
				settingItem.SettingItemName = GetReaderValue_String(reader, "SettingItemName", ""); //From: [usp_selectAll_Setting_values]
				settingItem.DefaultValue = GetReaderValue_String(reader, "DefaultValue", ""); //From: [usp_selectAll_Setting_values]
			}
			return settingItem;
		}
	
		/// <summary>
		/// Returns a collection of SettingItemDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<SettingItemDetails> GetSettingItemCollectionFromReader(DbDataReader reader) {
			List<SettingItemDetails> settingItems = new List<SettingItemDetails>();
			while (reader.Read()) settingItems.Add(GetSettingItemFromReader(reader));
			return settingItems;
		}
		
		
	}
}