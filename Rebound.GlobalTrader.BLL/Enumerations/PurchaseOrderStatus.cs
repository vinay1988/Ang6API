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
    public partial class PurchaseOrderStatus {
		/// <summary>
		/// An enum representation of the 'tbPurchaseOrderStatus' table.
		/// </summary>
		/// <remark>This enumeration contains the items contained in the table tbPurchaseOrderStatus</remark>
		[Serializable]
		public enum List {
			New = 1, 
			Unposted = 2, 
			PartPosted = 3, 
			Posted = 4, 
			Confirmed = 5, 
			AwaitsInspection = 6, 
			PartReceived = 7, 
			Received = 8, 
			Complete = 9
		}

        [Serializable]
        public enum IPOList
        {
            AwaitingSOCheck = 1,
            AwaitingPOApproval = 2,
            POApproved = 3
        }		


	

		
	}
}