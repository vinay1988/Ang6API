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
	
	public abstract class InternalPurchaseOrderStatusProvider : DataAccess {
		static private InternalPurchaseOrderStatusProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public InternalPurchaseOrderStatusProvider Instance {
			get {
				if (_instance == null) _instance = (InternalPurchaseOrderStatusProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.PurchaseOrderStatuss.ProviderType));
				return _instance;
			}
		}
        public InternalPurchaseOrderStatusProvider()
        {
            this.ConnectionString = Globals.Settings.InternalPurchaseOrderStatuss.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_PurchaseOrderStatus]
		/// </summary>
		public abstract bool Delete(System.Int32? purchaseOrderStatusId);
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_PurchaseOrderStatus]
		/// </summary>
		public abstract List<PurchaseOrderStatusDetails> DropDown();
		/// <summary>
		/// Insert
		/// Calls [usp_insert_PurchaseOrderStatus]
		/// </summary>
		public abstract Int32 Insert(System.String name);
		/// <summary>
		/// Get
		/// Calls [usp_select_PurchaseOrderStatus]
		/// </summary>
		public abstract PurchaseOrderStatusDetails Get(System.Int32? purchaseOrderStatusId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_PurchaseOrderStatus]
		/// </summary>
		public abstract List<PurchaseOrderStatusDetails> GetList();
		/// <summary>
		/// Update
		/// Calls [usp_update_PurchaseOrderStatus]
		/// </summary>
		public abstract bool Update(System.String name, System.Int32? purchaseOrderStatusId);

		#endregion
				
		/// <summary>
		/// Returns a new PurchaseOrderStatusDetails instance filled with the DataReader's current record data
		/// </summary>        
        protected virtual InternalPurchaseOrderStatusDetails GetPurchaseOrderStatusFromReader(DbDataReader reader)
        {
            InternalPurchaseOrderStatusDetails purchaseOrderStatus = new InternalPurchaseOrderStatusDetails();
			if (reader.HasRows) {
				purchaseOrderStatus.PurchaseOrderStatusId = GetReaderValue_Int32(reader, "PurchaseOrderStatusId", 0); //From: [Table]
				purchaseOrderStatus.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
			}
			return purchaseOrderStatus;
		}
	
		/// <summary>
		/// Returns a collection of PurchaseOrderStatusDetails objects with the data read from the input DataReader
		/// </summary>                
        protected virtual List<InternalPurchaseOrderStatusDetails> GetPurchaseOrderStatusCollectionFromReader(DbDataReader reader)
        {
            List<InternalPurchaseOrderStatusDetails> internalPurchaseOrderStatuss = new List<InternalPurchaseOrderStatusDetails>();
            while (reader.Read()) internalPurchaseOrderStatuss.Add(GetPurchaseOrderStatusFromReader(reader));
            return internalPurchaseOrderStatuss;
		}
		
		
	}
}