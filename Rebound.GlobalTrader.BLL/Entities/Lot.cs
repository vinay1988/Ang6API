//Marker    changed by      date           Remarks
//[001]      Vinay           12/08/2014     ESMS  Ticket Number: 	201
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
		public partial class Lot : BizObject {
		
		#region Properties

		protected static DAL.LotElement Settings {
			get { return Globals.Settings.Lots; }
		}

		/// <summary>
		/// LotId
		/// </summary>
		public System.Int32 LotId { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// LotName
		/// </summary>
		public System.String LotName { get; set; }		
		/// <summary>
		/// Cost
		/// </summary>
		public System.Double? Cost { get; set; }		
		/// <summary>
		/// CurrencyNo
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }		
		/// <summary>
		/// OnHold
		/// </summary>
		public System.Boolean OnHold { get; set; }		
		/// <summary>
		/// Consignment
		/// </summary>
		public System.Boolean Consignment { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// LotCode
		/// </summary>
		public System.String LotCode { get; set; }		
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
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }		
		/// <summary>
		/// StockCount
		/// </summary>
		public System.Int32? StockCount { get; set; }		
		/// <summary>
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }		
		/// <summary>
		/// RowCnt
		/// </summary>
		public System.Int32? RowCnt { get; set; }		
		/// <summary>
		/// CurrencyDescription
		/// </summary>
		public System.String CurrencyDescription { get; set; }
        /// <summary>
        /// LockForCustomerNo
        /// </summary>
        public System.Int32? LockForCustomerNo { get; set; }
        /// <summary>
        /// LockForCustomer
        /// </summary>
        public System.String LockForCustomer { get; set; }

		#endregion
		
		#region Methods
		
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_Lot_for_Client]
		/// </summary>
		public static Int32 CountForClient(System.Int32? clientId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Lot.CountForClient(clientId);
		}		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_Lot]
		/// </summary>
		public static List<Lot> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String lotCode, System.String lotName) {
			List<LotDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Lot.DataListNugget(clientId, orderBy, sortDir, pageIndex, pageSize, lotCode, lotName);
			if (lstDetails == null) {
				return new List<Lot>();
			} else {
				List<Lot> lst = new List<Lot>();
				foreach (LotDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Lot obj = new Rebound.GlobalTrader.BLL.Lot();
					obj.LotId = objDetails.LotId;
					obj.LotCode = objDetails.LotCode;
					obj.LotName = objDetails.LotName;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.OnHold = objDetails.OnHold;
					obj.Consignment = objDetails.Consignment;
					obj.StockCount = objDetails.StockCount;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
                    obj.Inactive = objDetails.Inactive;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Lot]
		/// </summary>
		public static bool Delete(System.Int32? lotId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Lot.Delete(lotId);
		}
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_Lot_for_Client]
		/// </summary>
		public static List<Lot> DropDownForClient(System.Int32? clientId) {
			List<LotDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Lot.DropDownForClient(clientId);
			if (lstDetails == null) {
				return new List<Lot>();
			} else {
				List<Lot> lst = new List<Lot>();
				foreach (LotDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Lot obj = new Rebound.GlobalTrader.BLL.Lot();
					obj.LotId = objDetails.LotId;
					obj.LotName = objDetails.LotName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Lot]
		/// </summary>
        public static Int32 Insert(System.Int32? clientNo, System.String lotName, System.Double? cost, System.Int32? currencyNo, System.Boolean? onHold, System.Boolean? consignment, System.String notes, System.String lotCode, System.Int32? updatedBy, System.Int32? LockForCustomerNo)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Lot.Insert(clientNo, lotName, cost, currencyNo, onHold, consignment, notes, lotCode, updatedBy, LockForCustomerNo);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Lot]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Lot.Insert(ClientNo, LotName, Cost, CurrencyNo, OnHold, Consignment, Notes, LotCode, UpdatedBy,LockForCustomerNo);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_Lot]
		/// </summary>
		public static Lot Get(System.Int32? lotId) {
			Rebound.GlobalTrader.DAL.LotDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Lot.Get(lotId);
			if (objDetails == null) {
				return null;
			} else {
				Lot obj = new Lot();
				obj.LotId = objDetails.LotId;
				obj.ClientNo = objDetails.ClientNo;
				obj.LotName = objDetails.LotName;
				obj.Cost = objDetails.Cost;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.OnHold = objDetails.OnHold;
				obj.Consignment = objDetails.Consignment;
				obj.Notes = objDetails.Notes;
				obj.LotCode = objDetails.LotCode;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.LockForCustomerNo = objDetails.LockForCustomerNo;
                obj.LockForCustomer = objDetails.LockForCustomer;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_Lot_for_Page]
		/// </summary>
		public static Lot GetForPage(System.Int32? lotId) {
			Rebound.GlobalTrader.DAL.LotDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Lot.GetForPage(lotId);
			if (objDetails == null) {
				return null;
			} else {
				Lot obj = new Lot();
				obj.LotId = objDetails.LotId;
				obj.LotName = objDetails.LotName;
				obj.ClientNo = objDetails.ClientNo;
				obj.Inactive = objDetails.Inactive;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_Lot]
		/// </summary>
		public static bool Update(System.Int32? lotId, System.Int32? clientNo, System.String lotName, System.Double? cost, System.Int32? currencyNo, System.Boolean? onHold, System.Boolean? consignment, System.String notes, System.String lotCode, System.Boolean? inactive, System.Int32? updatedBy, System.Int32? LockForCustomerNo) {
            return Rebound.GlobalTrader.DAL.SiteProvider.Lot.Update(lotId, clientNo, lotName, cost, currencyNo, onHold, consignment, notes, lotCode, inactive, updatedBy, LockForCustomerNo);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Lot]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Lot.Update(LotId, ClientNo, LotName, Cost, CurrencyNo, OnHold, Consignment, Notes, LotCode, Inactive, UpdatedBy,LockForCustomerNo);
		}
		/// <summary>
		/// UpdateDelete
		/// Calls [usp_update_Lot_Delete]
		/// </summary>
		public static bool UpdateDelete(System.Int32? lotId, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Lot.UpdateDelete(lotId, updatedBy);
		}

        private static Lot PopulateFromDBDetailsObject(LotDetails obj) {
            Lot objNew = new Lot();
			objNew.LotId = obj.LotId;
			objNew.ClientNo = obj.ClientNo;
			objNew.LotName = obj.LotName;
			objNew.Cost = obj.Cost;
			objNew.CurrencyNo = obj.CurrencyNo;
			objNew.OnHold = obj.OnHold;
			objNew.Consignment = obj.Consignment;
			objNew.Notes = obj.Notes;
			objNew.LotCode = obj.LotCode;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.CurrencyCode = obj.CurrencyCode;
			objNew.StockCount = obj.StockCount;
			objNew.RowNum = obj.RowNum;
			objNew.RowCnt = obj.RowCnt;
			objNew.CurrencyDescription = obj.CurrencyDescription;
            return objNew;
        }

        //[001] code start
        /// <summary>
        /// AutoSearch
        /// Calls [usp_autosearch_Lot]
        /// </summary>
        public static List<Lot> AutoSearch(System.Int32? clientId, System.String nameSearch)
        {
            List<LotDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Lot.AutoSearch(clientId, nameSearch);
            if (lstDetails == null)
            {
                return new List<Lot>();
            }
            else
            {
                List<Lot> lst = new List<Lot>();
                foreach (LotDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Lot obj = new Rebound.GlobalTrader.BLL.Lot();
                    obj.LotId = objDetails.LotId;
                    obj.LotName = objDetails.LotName;
                    obj.LotCode = objDetails.LotCode;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        //[001] code end
		
		#endregion
		
	}
}