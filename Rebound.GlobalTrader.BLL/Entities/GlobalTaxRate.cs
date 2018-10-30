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
    public partial class GlobalTaxRate : BizObject
    {
		
		#region Properties

		protected static DAL.TaxRateElement Settings {
			get { return Globals.Settings.TaxRates; }
		}

		/// <summary>
		/// TaxRateId
		/// </summary>
		public System.Int32 TaxRateId { get; set; }		
		/// <summary>
		/// TaxDate
		/// </summary>
		public System.DateTime TaxDate { get; set; }		
		/// <summary>
		/// TaxNo
		/// </summary>
		public System.Int32 TaxNo { get; set; }		
		/// <summary>
		/// Rate1
		/// </summary>
		public System.Double? Rate1 { get; set; }		
		/// <summary>
		/// Rate2
		/// </summary>
		public System.Double? Rate2 { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// CurrentTaxRate
		/// </summary>
		public System.Double? CurrentTaxRate { get; set; }		

		#endregion
		
		#region Methods
		
		
		/// <summary>
		/// Insert
        /// Calls [usp_insert_GlobalTaxRate]
		/// </summary>
		public static Int32 Insert(System.DateTime? taxDate, System.Int32? taxNo, System.Double? rate1, System.Double? rate2, System.Int32? updatedBy) {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.GlobalTaxRate.Insert(taxDate, taxNo, rate1, rate2, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_TaxRate]
		/// </summary>
		public Int32 Insert() {
            return Rebound.GlobalTrader.DAL.SiteProvider.GlobalTaxRate.Insert(TaxDate, TaxNo, Rate1, Rate2, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_TaxRate]
		/// </summary>
        public static GlobalTaxRate Get(System.Int32? taxRateId)
        {
            Rebound.GlobalTrader.DAL.GlobalTaxRateDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.GlobalTaxRate.Get(taxRateId);
			if (objDetails == null) {
				return null;
			} else {
                GlobalTaxRate obj = new GlobalTaxRate();
				obj.TaxRateId = objDetails.TaxRateId;
				obj.TaxDate = objDetails.TaxDate;
				obj.TaxNo = objDetails.TaxNo;
				obj.Rate1 = objDetails.Rate1;
				obj.Rate2 = objDetails.Rate2;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
	
		
		/// <summary>
		/// GetListForTax
		/// Calls [usp_selectAll_TaxRate_for_Tax]
		/// </summary>
        public static List<GlobalTaxRate> GetListForTax(System.Int32? taxId)
        {
            List<GlobalTaxRateDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GlobalTaxRate.GetListForTax(taxId);
			if (lstDetails == null) {
                return new List<GlobalTaxRate>();
			} else {
                List<GlobalTaxRate> lst = new List<GlobalTaxRate>();
                foreach (GlobalTaxRateDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.GlobalTaxRate obj = new Rebound.GlobalTrader.BLL.GlobalTaxRate();
					obj.TaxRateId = objDetails.TaxRateId;
					obj.TaxDate = objDetails.TaxDate;
					obj.TaxNo = objDetails.TaxNo;
					obj.Rate1 = objDetails.Rate1;
					obj.Rate2 = objDetails.Rate2;
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
		/// Calls [usp_update_TaxRate]
		/// </summary>
		public static bool Update(System.Int32? taxRateId, System.DateTime? taxDate, System.Int32? taxNo, System.Double? rate1, System.Double? rate2, System.Int32? updatedBy) {
            return Rebound.GlobalTrader.DAL.SiteProvider.GlobalTaxRate.Update(taxRateId, taxDate, taxNo, rate1, rate2, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_TaxRate]
		/// </summary>
		public bool Update() {
            return Rebound.GlobalTrader.DAL.SiteProvider.GlobalTaxRate.Update(TaxRateId, TaxDate, TaxNo, Rate1, Rate2, UpdatedBy);
		}

        private static GlobalTaxRate PopulateFromDBDetailsObject(GlobalTaxRateDetails obj)
        {
            GlobalTaxRate objNew = new GlobalTaxRate();
			objNew.TaxRateId = obj.TaxRateId;
			objNew.TaxDate = obj.TaxDate;
			objNew.TaxNo = obj.TaxNo;
			objNew.Rate1 = obj.Rate1;
			objNew.Rate2 = obj.Rate2;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.CurrentTaxRate = obj.CurrentTaxRate;
            return objNew;
        }
		
		#endregion
		
	}
}