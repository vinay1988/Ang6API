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
	
	public class ContactUserDefinedDetails {
		
		#region Constructors
		
		public ContactUserDefinedDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ContactNo (from Table)
		/// </summary>
		public System.Int32 ContactNo { get; set; }
		/// <summary>
		/// RowNo (from Table)
		/// </summary>
		public System.Int32 RowNo { get; set; }
		/// <summary>
		/// UserDefinedHeading (from Table)
		/// </summary>
		public System.String UserDefinedHeading { get; set; }
		/// <summary>
		/// UserDefinedValue (from Table)
		/// </summary>
		public System.String UserDefinedValue { get; set; }
		/// <summary>
		/// Inactive (from Table)
		/// </summary>
		public System.Boolean Inactive { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }

		#endregion

	}
}