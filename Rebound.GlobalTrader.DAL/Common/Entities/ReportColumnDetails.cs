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
	
	public class ReportColumnDetails {
		
		#region Constructors
		
		public ReportColumnDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ReportColumnId (from Table)
		/// </summary>
		public System.Int32 ReportColumnId { get; set; }
		/// <summary>
		/// ReportNo (from Table)
		/// </summary>
		public System.Int32? ReportNo { get; set; }
		/// <summary>
		/// TitleResource (from Table)
		/// </summary>
		public System.String TitleResource { get; set; }
		/// <summary>
		/// ReportColumnFormatNo (from Table)
		/// </summary>
		public System.Int32? ReportColumnFormatNo { get; set; }
		/// <summary>
		/// HasSum (from Table)
		/// </summary>
		public System.Boolean HasSum { get; set; }
		/// <summary>
		/// HasCount (from Table)
		/// </summary>
		public System.Boolean HasCount { get; set; }
		/// <summary>
		/// HasAverage (from Table)
		/// </summary>
		public System.Boolean HasAverage { get; set; }
		/// <summary>
		/// HasPercentageOnSums (from Table)
		/// </summary>
		public System.Boolean HasPercentageOnSums { get; set; }
		/// <summary>
		/// PercentageNumeratorColumnIndex (from Table)
		/// </summary>
		public System.Int32? PercentageNumeratorColumnIndex { get; set; }
		/// <summary>
		/// PercentageDenominatorColumnIndex (from Table)
		/// </summary>
		public System.Int32? PercentageDenominatorColumnIndex { get; set; }
		/// <summary>
		/// SortOrder (from Table)
		/// </summary>
		public System.Int32? SortOrder { get; set; }

		#endregion

	}
}