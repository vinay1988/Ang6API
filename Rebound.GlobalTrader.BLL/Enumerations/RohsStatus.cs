//Marker     changed by      date          Remarks
//[001]      Vinay          26/03/2014     ESMS Ref:105 -  Add two more rohs option 
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
    public partial class RohsStatus {
		/// <summary>
		/// An enum representation of the 'tbROHSStatus' table.
		/// </summary>
		/// <remark>This enumeration contains the items contained in the table tbROHSStatus</remark>
        [Serializable]
        public enum List
        {
            Unknown = 0,
            Compliant = 1,
            NonCompliant = 2,
            Exempt = 3,
            NotApplicable = 4,
            ROHS2 = 5,
            //[001] code start
            ROHS56 = 6,
            ROHS66 = 7
            //[001] code end
        }		

	
	}
}