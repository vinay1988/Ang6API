using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Rebound.GlobalTrader.DAL {
	
	public class MSLLevelDetails {
		
		#region Constructors

        public MSLLevelDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// UsageId (from Table)
		/// </summary>
        public System.Int32 MSLLevelId { get; set; }
		/// <summary>
		/// Name (from Table)
		/// </summary>
        public System.String MSLLevels { get; set; }

		#endregion

	}
}