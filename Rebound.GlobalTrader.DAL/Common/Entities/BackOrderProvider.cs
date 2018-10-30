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
	
	public abstract class BackOrderProvider : DataAccess {
		static private BackOrderProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public BackOrderProvider Instance {
			get {
				if (_instance == null) _instance = (BackOrderProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.BackOrders.ProviderType));
				return _instance;
			}
		}
		public BackOrderProvider() {
			this.ConnectionString = Globals.Settings.BackOrders.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_BackOrder]
		/// </summary>
		public abstract bool Delete(System.Int32? salesOrderLineNo);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_BackOrder]
		/// </summary>
		public abstract Int32 Insert(System.Int32? salesOrderLineNo, System.Int32? quantity, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_BackOrder]
		/// </summary>
		public abstract BackOrderDetails Get(System.Int32? salesOrderLineNo);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_BackOrder]
		/// </summary>
		public abstract List<BackOrderDetails> GetList(System.Int32? pageIndex, System.Int32? pageSize);
		/// <summary>
		/// Update
		/// Calls [usp_update_BackOrder]
		/// </summary>
		public abstract bool Update(System.Int32? salesOrderLineNo, System.Int32? quantity, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new BackOrderDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual BackOrderDetails GetBackOrderFromReader(DbDataReader reader) {
			BackOrderDetails backOrder = new BackOrderDetails();
			if (reader.HasRows) {
				backOrder.BackOrderId = GetReaderValue_Int32(reader, "BackOrderId", 0); //From: [Table]
				backOrder.SalesOrderLineNo = GetReaderValue_Int32(reader, "SalesOrderLineNo", 0); //From: [Table]
				backOrder.Quantity = GetReaderValue_Int32(reader, "Quantity", 0); //From: [Table]
				backOrder.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				backOrder.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
			}
			return backOrder;
		}
	
		/// <summary>
		/// Returns a collection of BackOrderDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<BackOrderDetails> GetBackOrderCollectionFromReader(DbDataReader reader) {
			List<BackOrderDetails> backOrders = new List<BackOrderDetails>();
			while (reader.Read()) backOrders.Add(GetBackOrderFromReader(reader));
			return backOrders;
		}
		
		
	}
}