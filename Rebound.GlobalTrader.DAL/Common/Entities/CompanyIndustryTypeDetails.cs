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
	
	public class CompanyIndustryTypeDetails {
		
		#region Constructors
		
		public CompanyIndustryTypeDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// CompanyIndustryTypeId (from Table)
		/// </summary>
		public System.Int32 CompanyIndustryTypeId { get; set; }
		/// <summary>
		/// CompanyNo (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.Int32? CompanyNo { get; set; }
		/// <summary>
		/// IndustryTypeNo (from Table)
		/// </summary>
		public System.Int32? IndustryTypeNo { get; set; }
		/// <summary>
		/// Name (from Table)
		/// </summary>
		public System.String Name { get; set; }

		#endregion

	}
}