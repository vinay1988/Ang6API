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
    public partial class SupplierRma : BizObject {

        #region Properties

        private BLL.Address _objShipToAddress;
        public BLL.Address ShipToAddress {
            get {
                if (_objShipToAddress == null) {
                    _objShipToAddress = BLL.Address.Get(ShipToAddressNo);
                    if (_objShipToAddress == null) _objShipToAddress = new BLL.Address();
                }
                return _objShipToAddress;
            }
        }

        #endregion

        #region Static Methods

        #endregion

    }
}