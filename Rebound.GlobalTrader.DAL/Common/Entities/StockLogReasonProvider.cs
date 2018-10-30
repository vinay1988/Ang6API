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
	
	public abstract class StockLogReasonProvider : DataAccess {
		static private StockLogReasonProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public StockLogReasonProvider Instance {
			get {
				if (_instance == null) _instance = (StockLogReasonProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.StockLogReasons.ProviderType));
				return _instance;
			}
		}
		public StockLogReasonProvider() {
			this.ConnectionString = Globals.Settings.StockLogReasons.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_StockLogReason]
		/// </summary>
		public abstract bool Delete(System.Int32? stockLogReasonId);
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_StockLogReason]
		/// </summary>
		public abstract List<StockLogReasonDetails> DropDown(System.Int32? clientNo);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_StockLogReason]
		/// </summary>
		public abstract Int32 Insert(System.String name, System.Int32? clientNo);
		/// <summary>
		/// Get
		/// Calls [usp_select_StockLogReason]
		/// </summary>
		public abstract StockLogReasonDetails Get(System.Int32? stockLogReasonId);
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_StockLogReason_for_Client]
		/// </summary>
		public abstract List<StockLogReasonDetails> GetListForClient(System.Int32? clientNo);
		/// <summary>
		/// Update
		/// Calls [usp_update_StockLogReason]
		/// </summary>
		public abstract bool Update(System.String name, System.Int32? stockLogReasonId);

		#endregion
				
		/// <summary>
		/// Returns a new StockLogReasonDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual StockLogReasonDetails GetStockLogReasonFromReader(DbDataReader reader) {
			StockLogReasonDetails stockLogReason = new StockLogReasonDetails();
			if (reader.HasRows) {
				stockLogReason.StockLogReasonId = GetReaderValue_Int32(reader, "StockLogReasonId", 0); //From: [Table]
				stockLogReason.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
				stockLogReason.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
			}
			return stockLogReason;
		}
	
		/// <summary>
		/// Returns a collection of StockLogReasonDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<StockLogReasonDetails> GetStockLogReasonCollectionFromReader(DbDataReader reader) {
			List<StockLogReasonDetails> stockLogReasons = new List<StockLogReasonDetails>();
			while (reader.Read()) stockLogReasons.Add(GetStockLogReasonFromReader(reader));
			return stockLogReasons;
		}
		
		
	}
}