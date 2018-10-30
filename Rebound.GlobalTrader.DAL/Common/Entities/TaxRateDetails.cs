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
	
	public class TaxRateDetails {
		
		#region Constructors
		
		public TaxRateDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// TaxRateId (from Table)
		/// </summary>
		public System.Int32 TaxRateId { get; set; }
		/// <summary>
		/// TaxDate (from Table)
		/// </summary>
		public System.DateTime TaxDate { get; set; }
		/// <summary>
		/// TaxNo (from Table)
		/// </summary>
		public System.Int32 TaxNo { get; set; }
		/// <summary>
		/// Rate1 (from Table)
		/// </summary>
		public System.Double? Rate1 { get; set; }
		/// <summary>
		/// Rate2 (from Table)
		/// </summary>
		public System.Double? Rate2 { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// CurrentTaxRate (from usp_select_TaxRate_2_for_Tax_and_Date)
		/// </summary>
		public System.Double? CurrentTaxRate { get; set; }

		#endregion

	}
}