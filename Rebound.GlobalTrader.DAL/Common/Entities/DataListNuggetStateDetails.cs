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
	
	public class DataListNuggetStateDetails {
		
		#region Constructors
		
		public DataListNuggetStateDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// DataListNuggetStateID (from Table)
		/// </summary>
		public System.Int32 DataListNuggetStateID { get; set; }
		/// <summary>
		/// DataListNuggetNo (from Table)
		/// </summary>
		public System.Int32 DataListNuggetNo { get; set; }
		/// <summary>
		/// LoginNo (from Table)
		/// </summary>
		public System.Int32 LoginNo { get; set; }
		/// <summary>
		/// SubType (from Table)
		/// </summary>
		public System.String SubType { get; set; }
		/// <summary>
		/// StateText (from Table)
		/// </summary>
		public System.String StateText { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }

		#endregion

	}
}