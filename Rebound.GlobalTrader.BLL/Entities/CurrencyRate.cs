// Marker     Changed by      Date         Remarks
// [001]      Vinay           12/11/2014   Display history (log) of exchange rate change in the local currency
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
		public partial class CurrencyRate : BizObject {
		
		#region Properties

		protected static DAL.CurrencyRateElement Settings {
			get { return Globals.Settings.CurrencyRates; }
		}

		/// <summary>
		/// CurrencyRateId
		/// </summary>
		public System.Int32 CurrencyRateId { get; set; }		
		/// <summary>
		/// CurrencyNo
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }		
		/// <summary>
		/// CurrencyDate
		/// </summary>
		public System.DateTime CurrencyDate { get; set; }		
		/// <summary>
		/// ExchangeRate
		/// </summary>
		public System.Double ExchangeRate { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// RepriceOpenOrders
		/// </summary>
		public System.Boolean? RepriceOpenOrders { get; set; }		
		/// <summary>
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }
        /// <summary>
        /// ExchangeRateId
        /// </summary>
        public System.Int32 ExchangeRateId { get; set; }
        /// <summary>
        /// LocalCurrencyNo
        /// </summary>
        public System.Int32 LocalCurrencyNo { get; set; }
        /// <summary>
        /// ExchangeRateDate
        /// </summary>
        public System.DateTime ExchangeRateDate { get; set; }
        /// <summary>
        /// ChangeBy
        /// </summary>
        public System.String ChangeBy { get; set; }

        public System.String ClientCurrencyCode { get; set; }

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_CurrencyRate]
		/// </summary>
		public static bool Delete(System.Int32? currencyRateId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CurrencyRate.Delete(currencyRateId);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_CurrencyRate]
		/// </summary>
		public static Int32 Insert(System.Int32? currencyNo, System.DateTime? currencyDate, System.Double? exchangeRate, System.Boolean? repriceOpenOrders, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CurrencyRate.Insert(currencyNo, currencyDate, exchangeRate, repriceOpenOrders, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_CurrencyRate]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.CurrencyRate.Insert(CurrencyNo, CurrencyDate, ExchangeRate, RepriceOpenOrders, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_CurrencyRate]
		/// </summary>
		public static CurrencyRate Get(System.Int32? currencyRateId) {
			Rebound.GlobalTrader.DAL.CurrencyRateDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CurrencyRate.Get(currencyRateId);
			if (objDetails == null) {
				return null;
			} else {
				CurrencyRate obj = new CurrencyRate();
				obj.CurrencyRateId = objDetails.CurrencyRateId;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.CurrencyDate = objDetails.CurrencyDate;
				obj.ExchangeRate = objDetails.ExchangeRate;
				obj.RepriceOpenOrders = objDetails.RepriceOpenOrders;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetCurrentAtDate
		/// Calls [usp_select_CurrencyRate_Current_at_Date]
		/// </summary>
		public static CurrencyRate GetCurrentAtDate(System.Int32? currencyNo, System.DateTime? datePoint) {
			Rebound.GlobalTrader.DAL.CurrencyRateDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CurrencyRate.GetCurrentAtDate(currencyNo, datePoint);
			if (objDetails == null) {
				return null;
			} else {
				CurrencyRate obj = new CurrencyRate();
				obj.ExchangeRate = objDetails.ExchangeRate;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForCurrency
		/// Calls [usp_selectAll_CurrencyRate_for_Currency]
		/// </summary>
		public static List<CurrencyRate> GetListForCurrency(System.Int32? currencyId) {
			List<CurrencyRateDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CurrencyRate.GetListForCurrency(currencyId);
			if (lstDetails == null) {
				return new List<CurrencyRate>();
			} else {
				List<CurrencyRate> lst = new List<CurrencyRate>();
				foreach (CurrencyRateDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CurrencyRate obj = new Rebound.GlobalTrader.BLL.CurrencyRate();
					obj.CurrencyRateId = objDetails.CurrencyRateId;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyDate = objDetails.CurrencyDate;
					obj.ExchangeRate = objDetails.ExchangeRate;
					obj.RepriceOpenOrders = objDetails.RepriceOpenOrders;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.CurrencyCode = objDetails.CurrencyCode;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_CurrencyRate]
		/// </summary>
		public static bool Update(System.Int32? currencyRateId, System.Int32? currencyNo, System.DateTime? currencyDate, System.Double? exchangeRate, System.Boolean? repriceOpenOrders, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CurrencyRate.Update(currencyRateId, currencyNo, currencyDate, exchangeRate, repriceOpenOrders, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_CurrencyRate]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.CurrencyRate.Update(CurrencyRateId, CurrencyNo, CurrencyDate, ExchangeRate, RepriceOpenOrders, UpdatedBy);
		}

        private static CurrencyRate PopulateFromDBDetailsObject(CurrencyRateDetails obj) {
            CurrencyRate objNew = new CurrencyRate();
			objNew.CurrencyRateId = obj.CurrencyRateId;
			objNew.CurrencyNo = obj.CurrencyNo;
			objNew.CurrencyDate = obj.CurrencyDate;
			objNew.ExchangeRate = obj.ExchangeRate;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.RepriceOpenOrders = obj.RepriceOpenOrders;
			objNew.CurrencyCode = obj.CurrencyCode;
            return objNew;
        }
       
        //[001] code start
        /// <summary>
        /// GetListForExchangeRate
        /// Calls [usp_selectAll_ExchangeRate_for_LocalCurrency]
        /// </summary>
        public static List<CurrencyRate> GetListForExchangeRate(System.Int32? localCurrencyId)
        {
            List<CurrencyRateDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CurrencyRate.GetListForExchangeRate(localCurrencyId);
            if (lstDetails == null)
            {
                return new List<CurrencyRate>();
            }
            else
            {
                List<CurrencyRate> lst = new List<CurrencyRate>();
                foreach (CurrencyRateDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.CurrencyRate obj = new Rebound.GlobalTrader.BLL.CurrencyRate();
                    obj.ExchangeRateId = objDetails.ExchangeRateId;
                    obj.LocalCurrencyNo = objDetails.LocalCurrencyNo;
                    obj.ExchangeRateDate = objDetails.ExchangeRateDate;
                    obj.ExchangeRate = objDetails.ExchangeRate;
                    obj.RepriceOpenOrders = objDetails.RepriceOpenOrders;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.ChangeBy = objDetails.ChangeBy;
                    obj.ClientCurrencyCode = objDetails.ClientCurrencyCode;
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