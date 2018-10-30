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
	
	public abstract class UsageProvider : DataAccess {
		static private UsageProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public UsageProvider Instance {
			get {
				if (_instance == null) _instance = (UsageProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Usages.ProviderType));
				return _instance;
			}
		}
		public UsageProvider() {
			this.ConnectionString = Globals.Settings.Usages.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_Usage]
		/// </summary>
		public abstract List<UsageDetails> DropDown();

        /// <summary>
        /// DropDown
        /// Calls [usp_dropdown_RequirementData]
        /// </summary>
        public abstract List<UsageDetails> ReqDropDown(string ReqType);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Usage]
		/// </summary>
		public abstract Int32 Insert(System.String name);
		/// <summary>
		/// Get
		/// Calls [usp_select_Usage]
		/// </summary>
		public abstract UsageDetails Get(System.Int32? usageId);
		/// <summary>
		/// Update
		/// Calls [usp_update_Usage]
		/// </summary>
		public abstract bool Update(System.String name, System.Int32? usageId);

		#endregion
				
		/// <summary>
		/// Returns a new UsageDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual UsageDetails GetUsageFromReader(DbDataReader reader) {
			UsageDetails usage = new UsageDetails();
			if (reader.HasRows) {
				usage.UsageId = GetReaderValue_Int32(reader, "UsageId", 0); //From: [Table]
				usage.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
			}
			return usage;
		}
	
		/// <summary>
		/// Returns a collection of UsageDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<UsageDetails> GetUsageCollectionFromReader(DbDataReader reader) {
			List<UsageDetails> usages = new List<UsageDetails>();
			while (reader.Read()) usages.Add(GetUsageFromReader(reader));
			return usages;
		}
		
		
	}
}