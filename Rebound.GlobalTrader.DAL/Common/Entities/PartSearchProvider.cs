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
	
	public abstract class PartSearchProvider : DataAccess {
		static private PartSearchProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public PartSearchProvider Instance {
			get {
				if (_instance == null) _instance = (PartSearchProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.PartSearchs.ProviderType));
				return _instance;
			}
		}
		public PartSearchProvider() {
			this.ConnectionString = Globals.Settings.PartSearchs.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Insert
		/// Calls [usp_insert_PartSearch]
		/// </summary>
		public abstract Int32 Insert(System.Int32? loginNo, System.String searchPart);
		/// <summary>
		/// GetListForLogin
		/// Calls [usp_selectAll_PartSearch_for_Login]
		/// </summary>
		public abstract List<PartSearchDetails> GetListForLogin(System.Int32? loginNo, System.String partSearch);

		#endregion
				
		/// <summary>
		/// Returns a new PartSearchDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual PartSearchDetails GetPartSearchFromReader(DbDataReader reader) {
			PartSearchDetails partSearch = new PartSearchDetails();
			if (reader.HasRows) {
				partSearch.PartSearchID = GetReaderValue_Int32(reader, "PartSearchID", 0); //From: [Table]
				partSearch.SearchPart = GetReaderValue_String(reader, "SearchPart", ""); //From: [Table]
				partSearch.LoginNo = GetReaderValue_NullableInt32(reader, "LoginNo", null); //From: [Table]
				partSearch.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null); //From: [Table]
			}
			return partSearch;
		}
	
		/// <summary>
		/// Returns a collection of PartSearchDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<PartSearchDetails> GetPartSearchCollectionFromReader(DbDataReader reader) {
			List<PartSearchDetails> partSearchs = new List<PartSearchDetails>();
			while (reader.Read()) partSearchs.Add(GetPartSearchFromReader(reader));
			return partSearchs;
		}
		
		
	}
}