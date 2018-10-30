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
	
	public class ProductDetails {
		
		#region Constructors
		
		public ProductDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ProductId (from Table)
		/// </summary>
		public System.Int32 ProductId { get; set; }
		/// <summary>
		/// ProductName (from usp_selectAll_Allocation)
		/// </summary>
		public System.String ProductName { get; set; }
		/// <summary>
		/// ProductDescription (from usp_selectAll_Allocation)
		/// </summary>
		public System.String ProductDescription { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
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
		/// <summary>
		/// DutyCode (from Table)
		/// </summary>
		public System.String DutyCode { get; set; }
		/// <summary>
		/// LandedCost (from usp_selectAll_Allocation)
		/// </summary>
		public System.Double? LandedCost { get; set; }
		/// <summary>
		/// CurrentDutyRate (from usp_selectAll_Product_for_Client)
		/// </summary>
		public System.Double? CurrentDutyRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String ClientName { get; set; }

        /// <summary>
        /// ProductId (from tbGlobalProductName Table)
        /// </summary>
        public System.Int32 GlobalProductNameId { get; set; }

        /// <summary>
        /// ProductId (from tbGlobalProductName Table)
        /// </summary>
        public System.String GlobalProductName { get; set; }
        public System.Boolean? Hazarders { get; set; }

		#endregion

	}
}