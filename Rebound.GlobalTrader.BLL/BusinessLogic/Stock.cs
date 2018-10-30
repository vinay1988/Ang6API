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
    public partial class Stock : BizObject {

        #region Properties

        public bool IsManuallyAddedStock {
            get { return (PurchaseOrderLineNo == null && CustomerRMALineNo == null); }
        }

        public bool IsSplitStock {
            get { return ((PurchaseOrderLineNo != null || CustomerRMALineNo != null) && GoodsInLineNo == null && QuantityInStock > 0); }
        }

        #endregion

    }
}