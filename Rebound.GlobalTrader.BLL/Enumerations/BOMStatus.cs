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
    public partial class BOMStatus {
		/// <summary>
        /// An enum representation of the BOM Status.
		/// </summary>
        /// <remark>This enumeration contains the BOM Status</remark>
		[Serializable]
		public enum List {
            New = 1,
            Open = 2,
            RPQ = 3, 
			PartialReleased = 4, 
		    Released = 5,
            Closed = 6,
            NoBid = 7
		}	
		
	}
}