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
	
	public class DivisionDetails {
		
		#region Constructors
		
		public DivisionDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// DivisionId (from Table)
		/// </summary>
		public System.Int32 DivisionId { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// DivisionName (from usp_select_Credit)
		/// </summary>
		public System.String DivisionName { get; set; }
		/// <summary>
		/// AddressNo (from Table)
		/// </summary>
		public System.Int32? AddressNo { get; set; }
		/// <summary>
		/// Manager (from Table)
		/// </summary>
		public System.Int32? Manager { get; set; }
		/// <summary>
		/// Budget (from Table)
		/// </summary>
		public System.Double? Budget { get; set; }
		/// <summary>
		/// Telephone (from Table)
		/// </summary>
		public System.String Telephone { get; set; }
		/// <summary>
		/// Fax (from Table)
		/// </summary>
		public System.String Fax { get; set; }
		/// <summary>
		/// EMail (from Table)
		/// </summary>
		public System.String EMail { get; set; }
		/// <summary>
		/// Notes (from usp_select_Address_DefaultBilling_for_Company)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// URL (from Table)
		/// </summary>
		public System.String URL { get; set; }
		/// <summary>
		/// Inactive (from Table)
		/// </summary>
		public System.Boolean Inactive { get; set; }
		/// <summary>
		/// HasDocumentHeaderImage (from Table)
		/// </summary>
		public System.Boolean HasDocumentHeaderImage { get; set; }
		/// <summary>
		/// UseCompanyHeaderForInvoice (from Table)
		/// </summary>
		public System.Boolean UseCompanyHeaderForInvoice { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// ManagerName (from usp_select_Division)
		/// </summary>
		public System.String ManagerName { get; set; }
		/// <summary>
		/// NumberOfMembers (from usp_selectAll_Division_for_Client)
		/// </summary>
		public System.Int32? NumberOfMembers { get; set; }
        /// <summary>
        /// Agency
        /// </summary>
        public System.Boolean? Agency { get; set; }

		#endregion

	}
}