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
	
	public class AlternatePartDetails {
		
		#region Constructors
		
		public AlternatePartDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// AlternatePartId (from Table)
		/// </summary>
		public System.Int32 AlternatePartId { get; set; }
		/// <summary>
		/// PartNo (from Table)
		/// </summary>
		public System.Int32 PartNo { get; set; }
		/// <summary>
		/// FullPart (from Table)
		/// </summary>
		public System.String FullPart { get; set; }
		/// <summary>
		/// Part (from usp_selectAll_Allocation)
		/// </summary>
		public System.String Part { get; set; }
		/// <summary>
		/// ROHSCompliant (from Table)
		/// </summary>
		public System.Boolean ROHSCompliant { get; set; }
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