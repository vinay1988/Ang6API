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
	
	public abstract class ShipViaProvider : DataAccess {
		static private ShipViaProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ShipViaProvider Instance {
			get {
				if (_instance == null) _instance = (ShipViaProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.ShipVias.ProviderType));
				return _instance;
			}
		}
		public ShipViaProvider() {
			this.ConnectionString = Globals.Settings.ShipVias.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_ShipVia]
		/// </summary>
		public abstract bool Delete(System.Int32? shipViaId);
		/// <summary>
		/// DropDownBuyForClient
		/// Calls [usp_dropdown_ShipVia_Buy_for_Client]
		/// </summary>
		public abstract List<ShipViaDetails> DropDownBuyForClient(System.Int32? clientId);
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_ShipVia_for_Client]
		/// </summary>
		public abstract List<ShipViaDetails> DropDownForClient(System.Int32? clientId);
		/// <summary>
		/// DropDownSellForClient
		/// Calls [usp_dropdown_ShipVia_Sell_for_Client]
		/// </summary>
		public abstract List<ShipViaDetails> DropDownSellForClient(System.Int32? clientId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_ShipVia]
		/// </summary>
        public abstract Int32 Insert(System.Int32? clientNo, System.String shipViaName, System.String notes, System.String service, System.String shipper, System.Boolean? buy, System.Boolean? sell, System.Double? cost, System.Double? charge, System.String pickUp, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? isSameAsShipCost);
		/// <summary>
		/// Get
		/// Calls [usp_select_ShipVia]
		/// </summary>
		public abstract ShipViaDetails Get(System.Int32? shipViaId);
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_ShipVia_for_Client]
		/// </summary>
		public abstract List<ShipViaDetails> GetListForClient(System.Int32? clientId);
		/// <summary>
		/// Update
		/// Calls [usp_update_ShipVia]
		/// </summary>
        public abstract bool Update(System.Int32? shipViaId, System.Int32? clientNo, System.String shipViaName, System.String notes, System.String service, System.String shipper, System.Boolean? buy, System.Boolean? sell, System.Double? cost, System.Double? charge, System.String pickUp, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? isSameAsShipCost);

		#endregion
				
		/// <summary>
		/// Returns a new ShipViaDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ShipViaDetails GetShipViaFromReader(DbDataReader reader) {
			ShipViaDetails shipVia = new ShipViaDetails();
			if (reader.HasRows) {
				shipVia.ShipViaId = GetReaderValue_Int32(reader, "ShipViaId", 0); //From: [Table]
				shipVia.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				shipVia.ShipViaName = GetReaderValue_String(reader, "ShipViaName", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
				shipVia.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
				shipVia.Service = GetReaderValue_String(reader, "Service", ""); //From: [Table]
				shipVia.Shipper = GetReaderValue_String(reader, "Shipper", ""); //From: [Table]
				shipVia.Buy = GetReaderValue_Boolean(reader, "Buy", false); //From: [Table]
				shipVia.Sell = GetReaderValue_Boolean(reader, "Sell", false); //From: [Table]
				shipVia.Cost = GetReaderValue_NullableDouble(reader, "Cost", null); //From: [usp_selectAll_Login_Top_Salespersons]
				shipVia.Charge = GetReaderValue_NullableDouble(reader, "Charge", null); //From: [Table]
				shipVia.PickUp = GetReaderValue_String(reader, "PickUp", ""); //From: [usp_select_SalesOrder]
				shipVia.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				shipVia.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				shipVia.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
			}
			return shipVia;
		}
	
		/// <summary>
		/// Returns a collection of ShipViaDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ShipViaDetails> GetShipViaCollectionFromReader(DbDataReader reader) {
			List<ShipViaDetails> shipVias = new List<ShipViaDetails>();
			while (reader.Read()) shipVias.Add(GetShipViaFromReader(reader));
			return shipVias;
		}
		
		
	}
}