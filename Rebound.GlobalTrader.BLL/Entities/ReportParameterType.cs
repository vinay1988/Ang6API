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
		public partial class ReportParameterType : BizObject {
		
		#region Properties

		protected static DAL.ReportParameterTypeElement Settings {
			get { return Globals.Settings.ReportParameterTypes; }
		}

		/// <summary>
		/// ReportParameterTypeId
		/// </summary>
		public System.Int32 ReportParameterTypeId { get; set; }		
		/// <summary>
		/// ReportParameterName
		/// </summary>
		public System.String ReportParameterName { get; set; }		

		#endregion
		
		#region Methods
		

        private static ReportParameterType PopulateFromDBDetailsObject(ReportParameterTypeDetails obj) {
            ReportParameterType objNew = new ReportParameterType();
			objNew.ReportParameterTypeId = obj.ReportParameterTypeId;
			objNew.ReportParameterName = obj.ReportParameterName;
            return objNew;
        }
		
		#endregion
		
	}
}