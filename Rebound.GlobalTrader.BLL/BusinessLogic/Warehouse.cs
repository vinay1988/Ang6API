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
	public partial class Warehouse : BizObject {

		#region Properties

		private Address _objAddress;
		public Address Address {
			get {
				if (_objAddress == null) _objAddress = GetAddress(WarehouseId);
				return _objAddress;
			}
		}

		#endregion

		#region Static Methods

		public static Address GetAddress(int? intWarehouseID) {
			Address addr = new Address();
			if (intWarehouseID != null) addr = Address.GetForWarehouse(intWarehouseID);
			return addr;
		}

		#endregion


    }
}