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
		public partial class SaleCommission : BizObject {
		
		#region Properties

		protected static DAL.SaleCommissionElement Settings {
			get { return Globals.Settings.SaleCommissions; }
		}

		/// <summary>
		/// SaleCommissionId
		/// </summary>
		public System.Int32 SaleCommissionId { get; set; }		
		/// <summary>
		/// SaleTypeNo
		/// </summary>
		public System.Int32 SaleTypeNo { get; set; }		
		/// <summary>
		/// CommissionPercent
		/// </summary>
		public System.Double CommissionPercent { get; set; }		
		/// <summary>
		/// UpToAmount
		/// </summary>
		public System.Double UpToAmount { get; set; }		
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
		

        private static SaleCommission PopulateFromDBDetailsObject(SaleCommissionDetails obj) {
            SaleCommission objNew = new SaleCommission();
			objNew.SaleCommissionId = obj.SaleCommissionId;
			objNew.SaleTypeNo = obj.SaleTypeNo;
			objNew.CommissionPercent = obj.CommissionPercent;
			objNew.UpToAmount = obj.UpToAmount;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
            return objNew;
        }
		
		#endregion
		
	}
}