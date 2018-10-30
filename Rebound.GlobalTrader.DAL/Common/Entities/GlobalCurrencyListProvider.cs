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
	
	public abstract class GlobalCurrencyListProvider : DataAccess {
		static private GlobalCurrencyListProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public GlobalCurrencyListProvider Instance {
			get {
				if (_instance == null) _instance = (GlobalCurrencyListProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.GlobalCurrencyLists.ProviderType));
				return _instance;
			}
		}
		public GlobalCurrencyListProvider() {
			this.ConnectionString = Globals.Settings.GlobalCurrencyLists.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_GlobalCurrencyList]
		/// </summary>
		public abstract List<GlobalCurrencyListDetails> DropDown(System.Boolean? includeSelected, System.Int32? clientNo);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_GlobalCurrencyList]
		/// </summary>
		public abstract Int32 Insert(System.String globalCurrencyName, System.String globalCurrencyDescription, System.String symbol, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_GlobalCurrencyList]
		/// </summary>
		public abstract GlobalCurrencyListDetails Get(System.Int32? currencyId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_GlobalCurrencyList]
		/// </summary>
		public abstract List<GlobalCurrencyListDetails> GetList();
		/// <summary>
		/// Update
		/// Calls [usp_update_GlobalCurrencyList]
		/// </summary>
		public abstract bool Update(System.Int32? globalCurrencyId, System.String globalCurrencyName, System.String globalCurrencyDescription, System.String symbol, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new GlobalCurrencyListDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual GlobalCurrencyListDetails GetGlobalCurrencyListFromReader(DbDataReader reader) {
			GlobalCurrencyListDetails globalCurrencyList = new GlobalCurrencyListDetails();
			if (reader.HasRows) {
				globalCurrencyList.GlobalCurrencyId = GetReaderValue_Int32(reader, "GlobalCurrencyId", 0); //From: [Table]
				globalCurrencyList.GlobalCurrencyName = GetReaderValue_String(reader, "GlobalCurrencyName", ""); //From: [Table]
				globalCurrencyList.GlobalCurrencyDescription = GetReaderValue_String(reader, "GlobalCurrencyDescription", ""); //From: [Table]
				globalCurrencyList.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				globalCurrencyList.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				globalCurrencyList.Priority = GetReaderValue_Boolean(reader, "Priority", false); //From: [Table]
				globalCurrencyList.Symbol = GetReaderValue_String(reader, "Symbol", ""); //From: [Table]
			}
			return globalCurrencyList;
		}
	
		/// <summary>
		/// Returns a collection of GlobalCurrencyListDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<GlobalCurrencyListDetails> GetGlobalCurrencyListCollectionFromReader(DbDataReader reader) {
			List<GlobalCurrencyListDetails> globalCurrencyLists = new List<GlobalCurrencyListDetails>();
			while (reader.Read()) globalCurrencyLists.Add(GetGlobalCurrencyListFromReader(reader));
			return globalCurrencyLists;
		}
		
		
	}
}