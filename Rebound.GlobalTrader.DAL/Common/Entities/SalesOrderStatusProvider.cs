﻿using System;
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
	
	public abstract class SalesOrderStatusProvider : DataAccess {
		static private SalesOrderStatusProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SalesOrderStatusProvider Instance {
			get {
				if (_instance == null) _instance = (SalesOrderStatusProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.SalesOrderStatuss.ProviderType));
				return _instance;
			}
		}
		public SalesOrderStatusProvider() {
			this.ConnectionString = Globals.Settings.SalesOrderStatuss.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_SalesOrderStatus]
		/// </summary>
		public abstract bool Delete(System.Int32? salesOrderStatusId);
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_SalesOrderStatus]
		/// </summary>
		public abstract List<SalesOrderStatusDetails> DropDown();
		/// <summary>
		/// Insert
		/// Calls [usp_insert_SalesOrderStatus]
		/// </summary>
		public abstract Int32 Insert(System.String name);
		/// <summary>
		/// Get
		/// Calls [usp_select_SalesOrderStatus]
		/// </summary>
		public abstract SalesOrderStatusDetails Get(System.Int32? salesOrderStatusId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_SalesOrderStatus]
		/// </summary>
		public abstract List<SalesOrderStatusDetails> GetList();
		/// <summary>
		/// Update
		/// Calls [usp_update_SalesOrderStatus]
		/// </summary>
		public abstract bool Update(System.String name, System.Int32? salesOrderStatusId);

		#endregion
				
		/// <summary>
		/// Returns a new SalesOrderStatusDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual SalesOrderStatusDetails GetSalesOrderStatusFromReader(DbDataReader reader) {
			SalesOrderStatusDetails salesOrderStatus = new SalesOrderStatusDetails();
			if (reader.HasRows) {
				salesOrderStatus.SalesOrderStatusId = GetReaderValue_Int32(reader, "SalesOrderStatusId", 0); //From: [Table]
				salesOrderStatus.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
			}
			return salesOrderStatus;
		}
	
		/// <summary>
		/// Returns a collection of SalesOrderStatusDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<SalesOrderStatusDetails> GetSalesOrderStatusCollectionFromReader(DbDataReader reader) {
			List<SalesOrderStatusDetails> salesOrderStatuss = new List<SalesOrderStatusDetails>();
			while (reader.Read()) salesOrderStatuss.Add(GetSalesOrderStatusFromReader(reader));
			return salesOrderStatuss;
		}
		
		
	}
}