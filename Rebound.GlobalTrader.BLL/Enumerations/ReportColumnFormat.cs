﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

namespace Rebound.GlobalTrader.BLL {
    public partial class ReportColumnFormat {
		/// <summary>
		/// An enum representation of the 'tbReportColumnFormat' table.
		/// </summary>
		/// <remark>This enumeration contains the items contained in the table tbReportColumnFormat</remark>
		[Serializable]
		public enum List {
			DateTime = 1, 
			Numerical = 2, 
			Currency = 3, 
			Text = 4, 
			UnitPrice = 5, 
			DateTimeWithTime = 6
		}		

	

		
	}
}