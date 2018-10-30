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

namespace Rebound.GlobalTrader.BLL {
    public partial class ReportParameterType {
		/// <summary>
		/// An enum representation of the 'tbReportParameterType' table.
		/// </summary>
		/// <remark>This enumeration contains the items contained in the table tbReportParameterType</remark>
		[Serializable]
		public enum List {
			DateTime = 1, 
			CheckBox = 2, 
			DropDown = 3, 
			Combo = 4, 
			Text = 5, 
			Integer = 6
		}		

	

		
	}
}