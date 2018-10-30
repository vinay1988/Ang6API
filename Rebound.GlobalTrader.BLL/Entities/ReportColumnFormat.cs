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
		public partial class ReportColumnFormat : BizObject {
		
		#region Properties

		protected static DAL.ReportColumnFormatElement Settings {
			get { return Globals.Settings.ReportColumnFormats; }
		}

		/// <summary>
		/// ReportColumnFormatId
		/// </summary>
		public System.Int32 ReportColumnFormatId { get; set; }		
		/// <summary>
		/// ReportColumnFormatName
		/// </summary>
		public System.String ReportColumnFormatName { get; set; }		

		#endregion
		
		#region Methods
		

        private static ReportColumnFormat PopulateFromDBDetailsObject(ReportColumnFormatDetails obj) {
            ReportColumnFormat objNew = new ReportColumnFormat();
			objNew.ReportColumnFormatId = obj.ReportColumnFormatId;
			objNew.ReportColumnFormatName = obj.ReportColumnFormatName;
            return objNew;
        }
		
		#endregion
		
	}
}