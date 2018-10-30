//Marker     Changed by      Date         Remarks
//[001]      Vinay           31/07/2012   Add enable/disable link in incoterms
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
	
	public class IncotermDetails {
		
		#region Constructors
		
		public IncotermDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// IncotermId (from Table)
		/// </summary>
		public System.Int32 IncotermId { get; set; }
		/// <summary>
		/// Code (from Table)
		/// </summary>
		public System.String Code { get; set; }
		/// <summary>
		/// Name (from Table)
		/// </summary>
		public System.String Name { get; set; }
        //[001] code start
        /// <summary>
        /// Active
        /// </summary>
        public System.Boolean Active { get; set; }
        //[001] code end
		#endregion

	}
}