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
		public partial class UserAudit : BizObject {
		
		#region Properties

		protected static DAL.UserAuditElement Settings {
			get { return Globals.Settings.UserAudits; }
		}

		/// <summary>
		/// LoginNo
		/// </summary>
		public System.Int32 LoginNo { get; set; }		
		/// <summary>
		/// IPAddress
		/// </summary>
		public System.String IPAddress { get; set; }		
		/// <summary>
		/// StartTime
		/// </summary>
		public System.DateTime StartTime { get; set; }		
		/// <summary>
		/// EndTime
		/// </summary>
		public System.DateTime? EndTime { get; set; }		

		#endregion
		
		#region Methods
		

        private static UserAudit PopulateFromDBDetailsObject(UserAuditDetails obj) {
            UserAudit objNew = new UserAudit();
			objNew.LoginNo = obj.LoginNo;
			objNew.IPAddress = obj.IPAddress;
			objNew.StartTime = obj.StartTime;
			objNew.EndTime = obj.EndTime;
            return objNew;
        }
		
		#endregion
		
	}
}