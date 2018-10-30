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
using Rebound.GlobalTrader.DAL;
using Rebound.GlobalTrader.BLL;

namespace Rebound.GlobalTrader.BLL {
		public partial class ShipVia : BizObject {
		
		#region Properties

		protected static DAL.ShipViaElement Settings {
			get { return Globals.Settings.ShipVias; }
		}

		/// <summary>
		/// ShipViaId
		/// </summary>
		public System.Int32 ShipViaId { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// ShipViaName
		/// </summary>
		public System.String ShipViaName { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// Service
		/// </summary>
		public System.String Service { get; set; }		
		/// <summary>
		/// Shipper
		/// </summary>
		public System.String Shipper { get; set; }		
		/// <summary>
		/// Buy
		/// </summary>
		public System.Boolean Buy { get; set; }		
		/// <summary>
		/// Sell
		/// </summary>
		public System.Boolean Sell { get; set; }		
		/// <summary>
		/// Cost
		/// </summary>
		public System.Double? Cost { get; set; }		
		/// <summary>
		/// Charge
		/// </summary>
		public System.Double? Charge { get; set; }		
		/// <summary>
		/// PickUp
		/// </summary>
		public System.String PickUp { get; set; }		
		/// <summary>
		/// Inactive
		/// </summary>
		public System.Boolean Inactive { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }
        /// <summary>
        /// IsSameAsShipCost
        /// </summary>
        public System.Boolean IsSameAsShipCost { get; set; }	

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_ShipVia]
		/// </summary>
		public static bool Delete(System.Int32? shipViaId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.ShipVia.Delete(shipViaId);
		}
		/// <summary>
		/// DropDownBuyForClient
		/// Calls [usp_dropdown_ShipVia_Buy_for_Client]
		/// </summary>
		public static List<ShipVia> DropDownBuyForClient(System.Int32? clientId) {
			List<ShipViaDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ShipVia.DropDownBuyForClient(clientId);
			if (lstDetails == null) {
				return new List<ShipVia>();
			} else {
				List<ShipVia> lst = new List<ShipVia>();
				foreach (ShipViaDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.ShipVia obj = new Rebound.GlobalTrader.BLL.ShipVia();
					obj.ShipViaId = objDetails.ShipViaId;
					obj.ShipViaName = objDetails.ShipViaName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_ShipVia_for_Client]
		/// </summary>
		public static List<ShipVia> DropDownForClient(System.Int32? clientId) {
			List<ShipViaDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ShipVia.DropDownForClient(clientId);
			if (lstDetails == null) {
				return new List<ShipVia>();
			} else {
				List<ShipVia> lst = new List<ShipVia>();
				foreach (ShipViaDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.ShipVia obj = new Rebound.GlobalTrader.BLL.ShipVia();
					obj.ShipViaId = objDetails.ShipViaId;
					obj.ShipViaName = objDetails.ShipViaName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// DropDownSellForClient
		/// Calls [usp_dropdown_ShipVia_Sell_for_Client]
		/// </summary>
		public static List<ShipVia> DropDownSellForClient(System.Int32? clientId) {
			List<ShipViaDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ShipVia.DropDownSellForClient(clientId);
			if (lstDetails == null) {
				return new List<ShipVia>();
			} else {
				List<ShipVia> lst = new List<ShipVia>();
				foreach (ShipViaDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.ShipVia obj = new Rebound.GlobalTrader.BLL.ShipVia();
					obj.ShipViaId = objDetails.ShipViaId;
					obj.ShipViaName = objDetails.ShipViaName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_ShipVia]
		/// </summary>
        public static Int32 Insert(System.Int32? clientNo, System.String shipViaName, System.String notes, System.String service, System.String shipper, System.Boolean? buy, System.Boolean? sell, System.Double? cost, System.Double? charge, System.String pickUp, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? isSameAsShipCost)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.ShipVia.Insert(clientNo, shipViaName, notes, service, shipper, buy, sell, cost, charge, pickUp, inactive, updatedBy, isSameAsShipCost);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_ShipVia]
		/// </summary>
		public Int32 Insert() {
            return Rebound.GlobalTrader.DAL.SiteProvider.ShipVia.Insert(ClientNo, ShipViaName, Notes, Service, Shipper, Buy, Sell, Cost, Charge, PickUp, Inactive, UpdatedBy, IsSameAsShipCost);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_ShipVia]
		/// </summary>
		public static ShipVia Get(System.Int32? shipViaId) {
			Rebound.GlobalTrader.DAL.ShipViaDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.ShipVia.Get(shipViaId);
			if (objDetails == null) {
				return null;
			} else {
				ShipVia obj = new ShipVia();
				obj.ShipViaId = objDetails.ShipViaId;
				obj.ClientNo = objDetails.ClientNo;
				obj.ShipViaName = objDetails.ShipViaName;
				obj.Notes = objDetails.Notes;
				obj.Service = objDetails.Service;
				obj.Shipper = objDetails.Shipper;
				obj.Buy = objDetails.Buy;
				obj.Sell = objDetails.Sell;
				obj.Cost = objDetails.Cost;
				obj.Charge = objDetails.Charge;
				obj.PickUp = objDetails.PickUp;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
                obj.IsSameAsShipCost = objDetails.IsSameAsShipCost;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_ShipVia_for_Client]
		/// </summary>
		public static List<ShipVia> GetListForClient(System.Int32? clientId) {
			List<ShipViaDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ShipVia.GetListForClient(clientId);
			if (lstDetails == null) {
				return new List<ShipVia>();
			} else {
				List<ShipVia> lst = new List<ShipVia>();
				foreach (ShipViaDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.ShipVia obj = new Rebound.GlobalTrader.BLL.ShipVia();
					obj.ShipViaId = objDetails.ShipViaId;
					obj.ClientNo = objDetails.ClientNo;
					obj.ShipViaName = objDetails.ShipViaName;
					obj.Notes = objDetails.Notes;
					obj.Service = objDetails.Service;
					obj.Shipper = objDetails.Shipper;
					obj.Buy = objDetails.Buy;
					obj.Sell = objDetails.Sell;
					obj.Cost = objDetails.Cost;
					obj.Charge = objDetails.Charge;
					obj.PickUp = objDetails.PickUp;
					obj.Inactive = objDetails.Inactive;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
                    obj.IsSameAsShipCost = objDetails.IsSameAsShipCost;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_ShipVia]
		/// </summary>
        public static bool Update(System.Int32? shipViaId, System.Int32? clientNo, System.String shipViaName, System.String notes, System.String service, System.String shipper, System.Boolean? buy, System.Boolean? sell, System.Double? cost, System.Double? charge, System.String pickUp, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? isSameAsShipCost)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.ShipVia.Update(shipViaId, clientNo, shipViaName, notes, service, shipper, buy, sell, cost, charge, pickUp, inactive, updatedBy, isSameAsShipCost);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_ShipVia]
		/// </summary>
		public bool Update() {
            return Rebound.GlobalTrader.DAL.SiteProvider.ShipVia.Update(ShipViaId, ClientNo, ShipViaName, Notes, Service, Shipper, Buy, Sell, Cost, Charge, PickUp, Inactive, UpdatedBy, IsSameAsShipCost);
		}

        private static ShipVia PopulateFromDBDetailsObject(ShipViaDetails obj) {
            ShipVia objNew = new ShipVia();
			objNew.ShipViaId = obj.ShipViaId;
			objNew.ClientNo = obj.ClientNo;
			objNew.ShipViaName = obj.ShipViaName;
			objNew.Notes = obj.Notes;
			objNew.Service = obj.Service;
			objNew.Shipper = obj.Shipper;
			objNew.Buy = obj.Buy;
			objNew.Sell = obj.Sell;
			objNew.Cost = obj.Cost;
			objNew.Charge = obj.Charge;
			objNew.PickUp = obj.PickUp;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
            return objNew;
        }
		
		#endregion
		
	}
}