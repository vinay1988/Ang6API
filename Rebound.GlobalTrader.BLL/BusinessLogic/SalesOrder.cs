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
	public partial class SalesOrder : BizObject {

		#region Properties

		private Address _objShipToAddress;
		public Address ShipToAddress {
			get {
				if (_objShipToAddress == null) _objShipToAddress = GetShipToAddress(ShipToAddressNo);
				return _objShipToAddress;
			}
		}

		#endregion

		#region Static Methods

		public static Address GetShipToAddress(int? intShipToAddressNo) {
			Address addr = new Address();
			if (intShipToAddressNo != null) addr = Address.Get(intShipToAddressNo);
			return addr;
		}

		#endregion

	}
}