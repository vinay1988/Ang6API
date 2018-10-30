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
	public partial class CustomerRmaLine : BizObject {

		public double LandedCostInCRMACurrency {
			get {
				return Currency.ConvertValueFromBaseCurrency(LandedCost, CurrencyNo, CustomerRMADate);
			}
		}

	}
}