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
	
	public class ReportParameterDetails {
		
		#region Constructors
		
		public ReportParameterDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ReportParameterId (from Table)
		/// </summary>
		public System.Int32 ReportParameterId { get; set; }
		/// <summary>
		/// ReportNo (from Table)
		/// </summary>
		public System.Int32? ReportNo { get; set; }
		/// <summary>
		/// ParameterName (from Table)
		/// </summary>
		public System.String ParameterName { get; set; }
		/// <summary>
		/// Description (from Table)
		/// </summary>
		public System.String Description { get; set; }
		/// <summary>
		/// ReportParameterTypeNo (from Table)
		/// </summary>
		public System.Int32? ReportParameterTypeNo { get; set; }
		/// <summary>
		/// DropDownNo (from Table)
		/// </summary>
		public System.Int32? DropDownNo { get; set; }
		/// <summary>
		/// SortOrder (from Table)
		/// </summary>
		public System.Int32? SortOrder { get; set; }
		/// <summary>
		/// ComboAutoSearchNo (from Table)
		/// </summary>
		public System.Int32? ComboAutoSearchNo { get; set; }
		/// <summary>
		/// Optional (from Table)
		/// </summary>
		public System.Boolean Optional { get; set; }

		#endregion

	}
}