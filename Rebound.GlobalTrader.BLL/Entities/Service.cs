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
		public partial class Service : BizObject {
		
		#region Properties

		protected static DAL.ServiceElement Settings {
			get { return Globals.Settings.Services; }
		}

		/// <summary>
		/// ServiceId
		/// </summary>
		public System.Int32 ServiceId { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// ServiceName
		/// </summary>
		public System.String ServiceName { get; set; }		
		/// <summary>
		/// ServiceDescription
		/// </summary>
		public System.String ServiceDescription { get; set; }		
		/// <summary>
		/// Price
		/// </summary>
		public System.Double? Price { get; set; }		
		/// <summary>
		/// Cost
		/// </summary>
		public System.Double? Cost { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// LotNo
		/// </summary>
		public System.Int32? LotNo { get; set; }		
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
		/// LotName
		/// </summary>
		public System.String LotName { get; set; }		
		/// <summary>
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }		
		/// <summary>
		/// RowCnt
		/// </summary>
		public System.Int32? RowCnt { get; set; }		
		/// <summary>
		/// Allocations
		/// </summary>
		public System.Int32? Allocations { get; set; }
        public System.String ClientBaseCurrencyCode { get; set; }

		#endregion
		
		#region Methods
		
		/// <summary>
		/// AutoSearch
		/// Calls [usp_autosearch_Service]
		/// </summary>
		public static List<Service> AutoSearch(System.Int32? clientId, System.String nameSearch) {
			List<ServiceDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Service.AutoSearch(clientId, nameSearch);
			if (lstDetails == null) {
				return new List<Service>();
			} else {
				List<Service> lst = new List<Service>();
				foreach (ServiceDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Service obj = new Rebound.GlobalTrader.BLL.Service();
					obj.ServiceId = objDetails.ServiceId;
					obj.ServiceName = objDetails.ServiceName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_Service_for_Client]
		/// </summary>
		public static Int32 CountForClient(System.Int32? clientId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Service.CountForClient(clientId);
		}		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_Service]
		/// </summary>
		public static List<Service> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String serviceName, System.String serviceDescription, System.Int32? lotNo) {
			List<ServiceDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Service.DataListNugget(clientId, orderBy, sortDir, pageIndex, pageSize, serviceName, serviceDescription, lotNo);
			if (lstDetails == null) {
				return new List<Service>();
			} else {
				List<Service> lst = new List<Service>();
				foreach (ServiceDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Service obj = new Rebound.GlobalTrader.BLL.Service();
					obj.ServiceId = objDetails.ServiceId;
					obj.ServiceName = objDetails.ServiceName;
					obj.ServiceDescription = objDetails.ServiceDescription;
					obj.Price = objDetails.Price;
					obj.Cost = objDetails.Cost;
					obj.Notes = objDetails.Notes;
					obj.LotNo = objDetails.LotNo;
					obj.Inactive = objDetails.Inactive;
					obj.LotName = objDetails.LotName;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Service]
		/// </summary>
		public static bool Delete(System.Int32? serviceId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Service.Delete(serviceId);
		}
		/// <summary>
		/// DeleteUnallocatedForLot
		/// Calls [usp_delete_Service_Unallocated_for_Lot]
		/// </summary>
		public static bool DeleteUnallocatedForLot(System.Int32? lotNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Service.DeleteUnallocatedForLot(lotNo);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Service]
		/// </summary>
		public static Int32 Insert(System.Int32? clientNo, System.String serviceName, System.String serviceDescription, System.Double? price, System.Double? cost, System.String notes, System.Int32? lotNo, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Service.Insert(clientNo, serviceName, serviceDescription, price, cost, notes, lotNo, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Service]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Service.Insert(ClientNo, ServiceName, ServiceDescription, Price, Cost, Notes, LotNo, UpdatedBy);
		}
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_Service]
		/// </summary>
		public static List<Service> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String serviceName, System.String serviceDescription, System.Int32? lotNo) {
			List<ServiceDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Service.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, serviceName, serviceDescription, lotNo);
			if (lstDetails == null) {
				return new List<Service>();
			} else {
				List<Service> lst = new List<Service>();
				foreach (ServiceDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Service obj = new Rebound.GlobalTrader.BLL.Service();
					obj.ServiceId = objDetails.ServiceId;
					obj.ServiceName = objDetails.ServiceName;
					obj.ServiceDescription = objDetails.ServiceDescription;
					obj.Cost = objDetails.Cost;
					obj.Price = objDetails.Price;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
                    obj.ClientBaseCurrencyCode = objDetails.ClientBaseCurrencyCode;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_Service]
		/// </summary>
		public static Service Get(System.Int32? serviceId) {
			Rebound.GlobalTrader.DAL.ServiceDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Service.Get(serviceId);
			if (objDetails == null) {
				return null;
			} else {
				Service obj = new Service();
				obj.ServiceId = objDetails.ServiceId;
				obj.ClientNo = objDetails.ClientNo;
				obj.ServiceName = objDetails.ServiceName;
				obj.ServiceDescription = objDetails.ServiceDescription;
				obj.Price = objDetails.Price;
				obj.Cost = objDetails.Cost;
				obj.Notes = objDetails.Notes;
				obj.LotNo = objDetails.LotNo;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.LotName = objDetails.LotName;
				obj.Allocations = objDetails.Allocations;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_Service_for_Page]
		/// </summary>
		public static Service GetForPage(System.Int32? serviceId) {
			Rebound.GlobalTrader.DAL.ServiceDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Service.GetForPage(serviceId);
			if (objDetails == null) {
				return null;
			} else {
				Service obj = new Service();
				obj.ServiceId = objDetails.ServiceId;
				obj.ServiceName = objDetails.ServiceName;
				obj.ClientNo = objDetails.ClientNo;
				obj.Inactive = objDetails.Inactive;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForLot
		/// Calls [usp_selectAll_Service_for_Lot]
		/// </summary>
		public static List<Service> GetListForLot(System.Int32? lotId) {
			List<ServiceDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Service.GetListForLot(lotId);
			if (lstDetails == null) {
				return new List<Service>();
			} else {
				List<Service> lst = new List<Service>();
				foreach (ServiceDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Service obj = new Rebound.GlobalTrader.BLL.Service();
					obj.ServiceId = objDetails.ServiceId;
					obj.ClientNo = objDetails.ClientNo;
					obj.ServiceName = objDetails.ServiceName;
					obj.ServiceDescription = objDetails.ServiceDescription;
					obj.Price = objDetails.Price;
					obj.Cost = objDetails.Cost;
					obj.Notes = objDetails.Notes;
					obj.LotNo = objDetails.LotNo;
					obj.Inactive = objDetails.Inactive;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_Service]
		/// </summary>
		public static bool Update(System.Int32? serviceId, System.Int32? clientNo, System.String serviceName, System.String serviceDescription, System.Double? price, System.Double? cost, System.String notes, System.Int32? lotNo, System.Boolean? inactive, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Service.Update(serviceId, clientNo, serviceName, serviceDescription, price, cost, notes, lotNo, inactive, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Service]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Service.Update(ServiceId, ClientNo, ServiceName, ServiceDescription, Price, Cost, Notes, LotNo, Inactive, UpdatedBy);
		}
		/// <summary>
		/// UpdateMakeInactive
		/// Calls [usp_update_Service_MakeInactive]
		/// </summary>
		public static bool UpdateMakeInactive(System.Int32? serviceId, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Service.UpdateMakeInactive(serviceId, updatedBy);
		}
		/// <summary>
		/// UpdateTransferLot
		/// Calls [usp_update_Service_Transfer_Lot]
		/// </summary>
		public static bool UpdateTransferLot(System.Int32? oldNotNo, System.Int32? newLotNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Service.UpdateTransferLot(oldNotNo, newLotNo);
		}

        private static Service PopulateFromDBDetailsObject(ServiceDetails obj) {
            Service objNew = new Service();
			objNew.ServiceId = obj.ServiceId;
			objNew.ClientNo = obj.ClientNo;
			objNew.ServiceName = obj.ServiceName;
			objNew.ServiceDescription = obj.ServiceDescription;
			objNew.Price = obj.Price;
			objNew.Cost = obj.Cost;
			objNew.Notes = obj.Notes;
			objNew.LotNo = obj.LotNo;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.LotName = obj.LotName;
			objNew.RowNum = obj.RowNum;
			objNew.RowCnt = obj.RowCnt;
			objNew.Allocations = obj.Allocations;
            return objNew;
        }
		
		#endregion
		
	}
}