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
	
	public class DutyRateDetails {
		
		#region Constructors
		
		public DutyRateDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// DutyRateId (from Table)
		/// </summary>
		public System.Int32 DutyRateId { get; set; }
		/// <summary>
		/// DutyDate (from Table)
		/// </summary>
		public System.DateTime? DutyDate { get; set; }
		/// <summary>
		/// DutyRateValue (from Table)
		/// </summary>
		public System.Double? DutyRateValue { get; set; }
		/// <summary>
		/// ProductNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32 ProductNo { get; set; }
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