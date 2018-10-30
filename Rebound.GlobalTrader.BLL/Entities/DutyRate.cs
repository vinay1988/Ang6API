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
		public partial class DutyRate : BizObject {
		
		#region Properties

		protected static DAL.DutyRateElement Settings {
			get { return Globals.Settings.DutyRates; }
		}

		/// <summary>
		/// DutyRateId
		/// </summary>
		public System.Int32 DutyRateId { get; set; }		
		/// <summary>
		/// DutyDate
		/// </summary>
		public System.DateTime? DutyDate { get; set; }		
		/// <summary>
		/// DutyRateValue
		/// </summary>
		public System.Double? DutyRateValue { get; set; }		
		/// <summary>
		/// ProductNo
		/// </summary>
		public System.Int32 ProductNo { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_DutyRate]
		/// </summary>
		public static bool Delete(System.Int32? dutyRateId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.DutyRate.Delete(dutyRateId);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_DutyRate]
		/// </summary>
		public static Int32 Insert(System.DateTime? dutyDate, System.Double? dutyRateValue, System.Int32? productNo, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.DutyRate.Insert(dutyDate, dutyRateValue, productNo, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_DutyRate]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.DutyRate.Insert(DutyDate, DutyRateValue, ProductNo, UpdatedBy);
		}

        /// <summary>
        /// Insert
        /// Calls [usp_insert_GlobalDutyRate]
        /// </summary>
        public static Int32 GlobalInsert(System.DateTime? dutyDate, System.Double? dutyRateValue, System.Int32? productNo, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.DutyRate.GlobalInsert(dutyDate, dutyRateValue, productNo, updatedBy);
            return objReturn;
        }
        /// <summary>
        /// Insert (without parameters)
        /// Calls [usp_insert_GlobalDutyRate]
        /// </summary>
        public Int32 GlobalInsert()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.DutyRate.GlobalInsert(DutyDate, DutyRateValue, ProductNo, UpdatedBy);
        }
		/// <summary>
		/// Get
		/// Calls [usp_select_DutyRate]
		/// </summary>
		public static DutyRate Get(System.Int32? dutyRateId) {
			Rebound.GlobalTrader.DAL.DutyRateDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.DutyRate.Get(dutyRateId);
			if (objDetails == null) {
				return null;
			} else {
				DutyRate obj = new DutyRate();
				obj.DutyRateId = objDetails.DutyRateId;
				obj.DutyDate = objDetails.DutyDate;
				obj.DutyRateValue = objDetails.DutyRateValue;
				obj.ProductNo = objDetails.ProductNo;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetCurrentForProduct
		/// Calls [usp_select_DutyRate_Current_for_Product]
		/// </summary>
		public static DutyRate GetCurrentForProduct(System.Int32? productNo, System.DateTime? datePoint) {
			Rebound.GlobalTrader.DAL.DutyRateDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.DutyRate.GetCurrentForProduct(productNo, datePoint);
			if (objDetails == null) {
				return null;
			} else {
				DutyRate obj = new DutyRate();
				obj.DutyRateValue = objDetails.DutyRateValue;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForProduct
		/// Calls [usp_selectAll_DutyRate_for_Product]
		/// </summary>
		public static List<DutyRate> GetListForProduct(System.Int32? productId) {
			List<DutyRateDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.DutyRate.GetListForProduct(productId);
			if (lstDetails == null) {
				return new List<DutyRate>();
			} else {
				List<DutyRate> lst = new List<DutyRate>();
				foreach (DutyRateDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.DutyRate obj = new Rebound.GlobalTrader.BLL.DutyRate();
					obj.DutyRateId = objDetails.DutyRateId;
					obj.DutyDate = objDetails.DutyDate;
					obj.DutyRateValue = objDetails.DutyRateValue;
					obj.ProductNo = objDetails.ProductNo;
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
        /// GetListForProduct
        /// Calls [usp_selectAll_DutyRate_for_Product]
        /// </summary>
        public static List<DutyRate> GetListForGlobalProduct(System.Int32? productId)
        {
            List<DutyRateDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.DutyRate.GetListForGlobalProduct(productId);
            if (lstDetails == null)
            {
                return new List<DutyRate>();
            }
            else
            {
                List<DutyRate> lst = new List<DutyRate>();
                foreach (DutyRateDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.DutyRate obj = new Rebound.GlobalTrader.BLL.DutyRate();
                    obj.DutyRateId = objDetails.DutyRateId;
                    obj.DutyDate = objDetails.DutyDate;
                    obj.DutyRateValue = objDetails.DutyRateValue;
                    obj.ProductNo = objDetails.ProductNo;
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
		/// Calls [usp_update_DutyRate]
		/// </summary>
		public static bool Update(System.Int32? dutyRateId, System.DateTime? dutyDate, System.Double? dutyRateValue, System.Int32? productNo, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.DutyRate.Update(dutyRateId, dutyDate, dutyRateValue, productNo, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_DutyRate]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.DutyRate.Update(DutyRateId, DutyDate, DutyRateValue, ProductNo, UpdatedBy);
		}

        private static DutyRate PopulateFromDBDetailsObject(DutyRateDetails obj) {
            DutyRate objNew = new DutyRate();
			objNew.DutyRateId = obj.DutyRateId;
			objNew.DutyDate = obj.DutyDate;
			objNew.DutyRateValue = obj.DutyRateValue;
			objNew.ProductNo = obj.ProductNo;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
            return objNew;
        }
		
		#endregion
		
	}
}