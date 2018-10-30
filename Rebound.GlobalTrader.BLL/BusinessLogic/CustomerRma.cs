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
	public partial class CustomerRma : BizObject {

		#region Properties

		private Warehouse _objWarehouse;
		public Warehouse Warehouse {
			get {
				if (_objWarehouse == null) {
					_objWarehouse = BLL.Warehouse.Get(WarehouseNo);
					if (_objWarehouse == null) _objWarehouse = new Warehouse();
				}
				return _objWarehouse;
			}
		}

		#endregion

		#region Static Methods

		#endregion

	}
}