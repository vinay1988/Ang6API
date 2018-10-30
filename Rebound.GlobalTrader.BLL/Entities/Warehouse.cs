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
		public partial class Warehouse : BizObject {
		
		#region Properties

		protected static DAL.WarehouseElement Settings {
			get { return Globals.Settings.Warehouses; }
		}

		/// <summary>
		/// WarehouseId
		/// </summary>
		public System.Int32 WarehouseId { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// WarehouseName
		/// </summary>
		public System.String WarehouseName { get; set; }		
		/// <summary>
		/// Inactive
		/// </summary>
		public System.Boolean Inactive { get; set; }		
		/// <summary>
		/// AddressNo
		/// </summary>
		public System.Int32? AddressNo { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// VirtualWarehouse
		/// </summary>
		public System.Boolean VirtualWarehouse { get; set; }		
		/// <summary>
		/// DefaultWarehouse
		/// </summary>
		public System.Boolean DefaultWarehouse { get; set; }		
		/// <summary>
		/// AddressName
		/// </summary>
		public System.String AddressName { get; set; }		
		/// <summary>
		/// Line1
		/// </summary>
		public System.String Line1 { get; set; }		
		/// <summary>
		/// Line2
		/// </summary>
		public System.String Line2 { get; set; }		
		/// <summary>
		/// Line3
		/// </summary>
		public System.String Line3 { get; set; }		
		/// <summary>
		/// County
		/// </summary>
		public System.String County { get; set; }		
		/// <summary>
		/// City
		/// </summary>
		public System.String City { get; set; }		
		/// <summary>
		/// State
		/// </summary>
		public System.String State { get; set; }		
		/// <summary>
		/// ZIP
		/// </summary>
		public System.String ZIP { get; set; }		
		/// <summary>
		/// CountryName
		/// </summary>
		public System.String CountryName { get; set; }		
		/// <summary>
		/// CountryNo
		/// </summary>
		public System.Int32? CountryNo { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Warehouse]
		/// </summary>
		public static bool Delete(System.Int32? warehouseId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Warehouse.Delete(warehouseId);
		}
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_Warehouse_for_Client]
		/// </summary>
		public static List<Warehouse> DropDownForClient(System.Int32? clientId, System.Boolean? includeVirtual) {
			List<WarehouseDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Warehouse.DropDownForClient(clientId, includeVirtual);
			if (lstDetails == null) {
				return new List<Warehouse>();
			} else {
				List<Warehouse> lst = new List<Warehouse>();
				foreach (WarehouseDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Warehouse obj = new Rebound.GlobalTrader.BLL.Warehouse();
					obj.WarehouseId = objDetails.WarehouseId;
					obj.WarehouseName = objDetails.WarehouseName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Warehouse]
		/// </summary>
		public static Int32 Insert(System.Int32? clientNo, System.String warehouseName, System.Int32? addressNo, System.Boolean? virtualWarehouse, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Warehouse.Insert(clientNo, warehouseName, addressNo, virtualWarehouse, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Warehouse]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Warehouse.Insert(ClientNo, WarehouseName, AddressNo, VirtualWarehouse, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_Warehouse]
		/// </summary>
		public static Warehouse Get(System.Int32? warehouseId) {
			Rebound.GlobalTrader.DAL.WarehouseDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Warehouse.Get(warehouseId);
			if (objDetails == null) {
				return null;
			} else {
				Warehouse obj = new Warehouse();
				obj.WarehouseId = objDetails.WarehouseId;
				obj.ClientNo = objDetails.ClientNo;
				obj.WarehouseName = objDetails.WarehouseName;
				obj.Inactive = objDetails.Inactive;
				obj.AddressNo = objDetails.AddressNo;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.VirtualWarehouse = objDetails.VirtualWarehouse;
				obj.AddressName = objDetails.AddressName;
				obj.Line1 = objDetails.Line1;
				obj.Line2 = objDetails.Line2;
				obj.Line3 = objDetails.Line3;
				obj.County = objDetails.County;
				obj.City = objDetails.City;
				obj.State = objDetails.State;
				obj.ZIP = objDetails.ZIP;
				obj.CountryName = objDetails.CountryName;
				obj.CountryNo = objDetails.CountryNo;
				obj.DefaultWarehouse = objDetails.DefaultWarehouse;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetDefault
		/// Calls [usp_select_Warehouse_Default]
		/// </summary>
		public static Warehouse GetDefault(System.Int32? clientId) {
			Rebound.GlobalTrader.DAL.WarehouseDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Warehouse.GetDefault(clientId);
			if (objDetails == null) {
				return null;
			} else {
				Warehouse obj = new Warehouse();
				obj.WarehouseId = objDetails.WarehouseId;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_Warehouse_for_Client]
		/// </summary>
		public static List<Warehouse> GetListForClient(System.Int32? clientId) {
			List<WarehouseDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Warehouse.GetListForClient(clientId);
			if (lstDetails == null) {
				return new List<Warehouse>();
			} else {
				List<Warehouse> lst = new List<Warehouse>();
				foreach (WarehouseDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Warehouse obj = new Rebound.GlobalTrader.BLL.Warehouse();
					obj.WarehouseId = objDetails.WarehouseId;
					obj.ClientNo = objDetails.ClientNo;
					obj.WarehouseName = objDetails.WarehouseName;
					obj.Inactive = objDetails.Inactive;
					obj.AddressNo = objDetails.AddressNo;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.VirtualWarehouse = objDetails.VirtualWarehouse;
					obj.AddressName = objDetails.AddressName;
					obj.Line1 = objDetails.Line1;
					obj.Line2 = objDetails.Line2;
					obj.Line3 = objDetails.Line3;
					obj.County = objDetails.County;
					obj.City = objDetails.City;
					obj.State = objDetails.State;
					obj.ZIP = objDetails.ZIP;
					obj.CountryName = objDetails.CountryName;
					obj.CountryNo = objDetails.CountryNo;
					obj.DefaultWarehouse = objDetails.DefaultWarehouse;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_Warehouse]
		/// </summary>
		public static bool Update(System.Int32? warehouseId, System.Int32? clientNo, System.String warehouseName, System.Int32? addressNo, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? virtualWarehouse) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Warehouse.Update(warehouseId, clientNo, warehouseName, addressNo, inactive, updatedBy, virtualWarehouse);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Warehouse]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Warehouse.Update(WarehouseId, ClientNo, WarehouseName, AddressNo, Inactive, UpdatedBy, VirtualWarehouse);
		}
		/// <summary>
		/// UpdateClearDefaults
		/// Calls [usp_update_Warehouse_ClearDefaults]
		/// </summary>
		public static bool UpdateClearDefaults(System.Int32? clientId, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Warehouse.UpdateClearDefaults(clientId, updatedBy);
		}
		/// <summary>
		/// UpdateSetDefault
		/// Calls [usp_update_Warehouse_SetDefault]
		/// </summary>
		public static bool UpdateSetDefault(System.Int32? warehouseId, System.Int32? clientId, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Warehouse.UpdateSetDefault(warehouseId, clientId, updatedBy);
		}

        private static Warehouse PopulateFromDBDetailsObject(WarehouseDetails obj) {
            Warehouse objNew = new Warehouse();
			objNew.WarehouseId = obj.WarehouseId;
			objNew.ClientNo = obj.ClientNo;
			objNew.WarehouseName = obj.WarehouseName;
			objNew.Inactive = obj.Inactive;
			objNew.AddressNo = obj.AddressNo;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.VirtualWarehouse = obj.VirtualWarehouse;
			objNew.DefaultWarehouse = obj.DefaultWarehouse;
			objNew.AddressName = obj.AddressName;
			objNew.Line1 = obj.Line1;
			objNew.Line2 = obj.Line2;
			objNew.Line3 = obj.Line3;
			objNew.County = obj.County;
			objNew.City = obj.City;
			objNew.State = obj.State;
			objNew.ZIP = obj.ZIP;
			objNew.CountryName = obj.CountryName;
			objNew.CountryNo = obj.CountryNo;
            return objNew;
        }

        /// <summary>
        /// Create IPO and PO 
        /// Calls [usp_insert_InternalPurchaseOrder]
        /// </summary>
        public static int CreateIPOAndPurchaseOrder(int SalesOrderNo, string SalesOrderLines, int POHubSupplierNo, int ClientNo, int WarehouseNo, int SourceingResultAttachedBy, int? SourceingResultNo, double? EstimatedShippingCost, DateTime? DeliveryDate, double? ConvertedEstimatedCost, System.Int32? ClientCurrencyNo, System.Int32? POBuyCurrencyNo, System.Int32 CurrencyNo, System.Int32? LinkMultiCurrencyNo, out int InternalPurchaseOrderNo, out int PurchaseOrderNo, out string SolIdS)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Warehouse.CreateIPOAndPurchaseOrder(SalesOrderNo, SalesOrderLines, POHubSupplierNo, ClientNo, WarehouseNo, SourceingResultAttachedBy,SourceingResultNo, EstimatedShippingCost,DeliveryDate,ConvertedEstimatedCost,ClientCurrencyNo,POBuyCurrencyNo,CurrencyNo,LinkMultiCurrencyNo ,out  InternalPurchaseOrderNo, out  PurchaseOrderNo,out SolIdS);
        }

        /// <summary>
        /// To Get Default Warehouse By ClientId
        /// Calls [usp_GetDefaultWarehouseByClientId] 
        /// </summary>
        public static int GetDefaultWarehouseByClient(int ClientId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Warehouse.GetDefaultWarehouseByClient(ClientId);
        }

            /// <summary>
        /// To check whether sourcing result exist for so line or not
        ///   /// Calls [usp_IsSoLineExistInSourcingResult]
        /// </summary>
        /// <param name="SoId"></param>
        /// <param name="SolineId"></param>
        /// <returns></returns>
        public static int IsSoLineExistInSourcingResult(int? SoId, int? SolineId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Warehouse.IsSoLineExistInSourcingResult(SoId, SolineId);
        }

        /// <summary>
        /// To check whether th line exist in IPO Lines
        ///   /// Calls [usp_IsSoLineExistInSourcingResult]
        /// </summary>
        /// <param name="SoId"></param>
        /// <param name="SolineId"></param>
        /// <returns></returns>
        public static int IsIPOExist(int? SoId, int? SolineId) 
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Warehouse.IsIPOExist(SoId, SolineId);
        }
		#endregion
		
	}
}