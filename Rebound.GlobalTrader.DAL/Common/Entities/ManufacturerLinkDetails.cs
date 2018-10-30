/* Marker    changed by      date           Remarks
  [001]      Vinay           11/08/2014     ESMS  Ticket Number: 	200
 */
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
	
	public class ManufacturerLinkDetails {
		
		#region Constructors
		
		public ManufacturerLinkDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ManufacturerLinkId (from Table)
		/// </summary>
		public System.Int32 ManufacturerLinkId { get; set; }
		/// <summary>
		/// ManufacturerNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32 ManufacturerNo { get; set; }
		/// <summary>
		/// SupplierCompanyNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32 SupplierCompanyNo { get; set; }
		/// <summary>
		/// ManufacturerRating (from Table)
		/// </summary>
		public System.Int32? ManufacturerRating { get; set; }
		/// <summary>
		/// SupplierRating (from Table)
		/// </summary>
		public System.Int32? SupplierRating { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// ManufacturerName (from usp_selectAll_Allocation)
		/// </summary>
		public System.String ManufacturerName { get; set; }
		/// <summary>
		/// SupplierName (from usp_source_Excess)
		/// </summary>
		public System.String SupplierName { get; set; }
        //[001] code start
        /// <summary>
        /// CompanyType
        /// </summary>
        public System.String CompanyType { get; set; }
        //[001] code end

		#endregion

	}
}