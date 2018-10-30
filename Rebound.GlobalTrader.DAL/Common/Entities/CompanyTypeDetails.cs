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
	
	public class CompanyTypeDetails {
		
		#region Constructors
		
		public CompanyTypeDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// CompanyTypeId (from Table)
		/// </summary>
		public System.Int32 CompanyTypeId { get; set; }
		/// <summary>
		/// Name (from Table)
		/// </summary>
		public System.String Name { get; set; }
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
		public System.DateTime? DLUP { get; set; }
        /// <summary>
        /// Traceability
        /// </summary>
        public System.Boolean? Traceability { get; set; }
        public System.Boolean? NonPreferredCompany { get; set; }

        #endregion

    }
}