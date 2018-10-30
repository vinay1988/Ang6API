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
	
	public abstract class HelpGroupProvider : DataAccess {
		static private HelpGroupProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public HelpGroupProvider Instance {
			get {
				if (_instance == null) _instance = (HelpGroupProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.HelpGroups.ProviderType));
				return _instance;
			}
		}
		public HelpGroupProvider() {
			this.ConnectionString = Globals.Settings.HelpGroups.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_HelpGroup]
		/// </summary>
		public abstract List<HelpGroupDetails> GetList();

		#endregion
				
		/// <summary>
		/// Returns a new HelpGroupDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual HelpGroupDetails GetHelpGroupFromReader(DbDataReader reader) {
			HelpGroupDetails helpGroup = new HelpGroupDetails();
			if (reader.HasRows) {
				helpGroup.HelpGroupId = GetReaderValue_Int32(reader, "HelpGroupId", 0); //From: [Table]
				helpGroup.Title = GetReaderValue_String(reader, "Title", ""); //From: [Table]
				helpGroup.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null); //From: [Table]
			}
			return helpGroup;
		}
	
		/// <summary>
		/// Returns a collection of HelpGroupDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<HelpGroupDetails> GetHelpGroupCollectionFromReader(DbDataReader reader) {
			List<HelpGroupDetails> helpGroups = new List<HelpGroupDetails>();
			while (reader.Read()) helpGroups.Add(GetHelpGroupFromReader(reader));
			return helpGroups;
		}
		
		
	}
}