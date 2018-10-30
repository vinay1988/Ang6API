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
	public partial class Address : BizObject {

		#region Properties

		private string _strFullAddressString;
		public string FullAddressString {
			get { return _strFullAddressString; }
			set { _strFullAddressString = value; }
		}

		#endregion

	}
}