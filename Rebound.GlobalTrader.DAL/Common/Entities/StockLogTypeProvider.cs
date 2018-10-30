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
	
	public abstract class StockLogTypeProvider : DataAccess {
		static private StockLogTypeProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public StockLogTypeProvider Instance {
			get {
				if (_instance == null) _instance = (StockLogTypeProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.StockLogTypes.ProviderType));
				return _instance;
			}
		}
		public StockLogTypeProvider() {
			this.ConnectionString = Globals.Settings.StockLogTypes.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_StockLogType]
		/// </summary>
		public abstract bool Delete(System.Int32? stockLogTypeId);
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_StockLogType]
		/// </summary>
		public abstract List<StockLogTypeDetails> DropDown();
		/// <summary>
		/// Insert
		/// Calls [usp_insert_StockLogType]
		/// </summary>
		public abstract Int32 Insert(System.String name, System.Int32? parentStockLogTypeNo);
		/// <summary>
		/// Get
		/// Calls [usp_select_StockLogType]
		/// </summary>
		public abstract StockLogTypeDetails Get(System.Int32? stockLogTypeId);
		/// <summary>
		/// Update
		/// Calls [usp_update_StockLogType]
		/// </summary>
		public abstract bool Update(System.String name, System.Int32? parentStockLogTypeNo, System.Int32? stockLogTypeId);

		#endregion
				
		/// <summary>
		/// Returns a new StockLogTypeDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual StockLogTypeDetails GetStockLogTypeFromReader(DbDataReader reader) {
			StockLogTypeDetails stockLogType = new StockLogTypeDetails();
			if (reader.HasRows) {
				stockLogType.StockLogTypeId = GetReaderValue_Int32(reader, "StockLogTypeId", 0); //From: [Table]
				stockLogType.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
				stockLogType.ParentStockLogTypeNo = GetReaderValue_NullableInt32(reader, "ParentStockLogTypeNo", null); //From: [Table]
			}
			return stockLogType;
		}
	
		/// <summary>
		/// Returns a collection of StockLogTypeDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<StockLogTypeDetails> GetStockLogTypeCollectionFromReader(DbDataReader reader) {
			List<StockLogTypeDetails> stockLogTypes = new List<StockLogTypeDetails>();
			while (reader.Read()) stockLogTypes.Add(GetStockLogTypeFromReader(reader));
			return stockLogTypes;
		}
		
		
	}
}