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
	
	public abstract class RecentlyViewedProvider : DataAccess {
		static private RecentlyViewedProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public RecentlyViewedProvider Instance {
			get {
				if (_instance == null) _instance = (RecentlyViewedProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.RecentlyVieweds.ProviderType));
				return _instance;
			}
		}
		public RecentlyViewedProvider() {
			this.ConnectionString = Globals.Settings.RecentlyVieweds.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_RecentlyViewed]
		/// </summary>
		public abstract bool Delete(System.Int32? recentlyViewedId);
		/// <summary>
		/// DeleteByLoginAndPageTitle
		/// Calls [usp_delete_RecentlyViewed_by_Login_and_PageTitle]
		/// </summary>
		public abstract bool DeleteByLoginAndPageTitle(System.Int32? loginNo, System.String pageTitle);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_RecentlyViewed]
		/// </summary>
		public abstract Int32 Insert(System.Int32? loginNo, System.String pageTitle, System.String pageUrl);
		/// <summary>
		/// GetListForUser
		/// Calls [usp_selectAll_RecentlyViewed_for_User]
		/// </summary>
		public abstract List<RecentlyViewedDetails> GetListForUser(System.Int32? loginNo);
		/// <summary>
		/// UpdateLock
		/// Calls [usp_update_RecentlyViewed_Lock]
		/// </summary>
		public abstract bool UpdateLock(System.Int32? recentlyViewedId, System.Boolean? locked);

		#endregion
				
		/// <summary>
		/// Returns a new RecentlyViewedDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual RecentlyViewedDetails GetRecentlyViewedFromReader(DbDataReader reader) {
			RecentlyViewedDetails recentlyViewed = new RecentlyViewedDetails();
			if (reader.HasRows) {
				recentlyViewed.RecentlyViewedId = GetReaderValue_Int32(reader, "RecentlyViewedId", 0); //From: [Table]
				recentlyViewed.LoginNo = GetReaderValue_NullableInt32(reader, "LoginNo", null); //From: [Table]
				recentlyViewed.PageTitle = GetReaderValue_String(reader, "PageTitle", ""); //From: [Table]
				recentlyViewed.PageURL = GetReaderValue_String(reader, "PageURL", ""); //From: [Table]
				recentlyViewed.DateAdded = GetReaderValue_NullableDateTime(reader, "DateAdded", null); //From: [Table]
				recentlyViewed.Locked = GetReaderValue_NullableBoolean(reader, "Locked", null); //From: [Table]
			}
			return recentlyViewed;
		}
	
		/// <summary>
		/// Returns a collection of RecentlyViewedDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<RecentlyViewedDetails> GetRecentlyViewedCollectionFromReader(DbDataReader reader) {
			List<RecentlyViewedDetails> recentlyVieweds = new List<RecentlyViewedDetails>();
			while (reader.Read()) recentlyVieweds.Add(GetRecentlyViewedFromReader(reader));
			return recentlyVieweds;
		}
		
		
	}
}