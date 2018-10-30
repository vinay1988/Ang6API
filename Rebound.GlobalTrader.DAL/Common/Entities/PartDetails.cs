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
	
	public class PartDetails {
		
		#region Constructors
		
		public PartDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// PartId (from Table)
		/// </summary>
		public System.Int32 PartId { get; set; }
		/// <summary>
		/// FullPart (from Table)
		/// </summary>
		public System.String FullPart { get; set; }
		/// <summary>
		/// ManufacturerNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? ManufacturerNo { get; set; }
		/// <summary>
		/// PackageNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? PackageNo { get; set; }
		/// <summary>
		/// ProductNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? ProductNo { get; set; }
		/// <summary>
		/// MinimumQuantity (from Table)
		/// </summary>
		public System.Int32? MinimumQuantity { get; set; }
		/// <summary>
		/// ReOrderQuantity (from Table)
		/// </summary>
		public System.Int32? ReOrderQuantity { get; set; }
		/// <summary>
		/// LeadTime (from Table)
		/// </summary>
		public System.Int32? LeadTime { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// ResalePrice (from Table)
		/// </summary>
		public System.Double? ResalePrice { get; set; }
		/// <summary>
		/// ROHSCompliant (from Table)
		/// </summary>
		public System.Boolean ROHSCompliant { get; set; }
		/// <summary>
		/// MasterPart (from Table)
		/// </summary>
		public System.Boolean? MasterPart { get; set; }
		/// <summary>
		/// GoldenPart (from Table)
		/// </summary>
		public System.Boolean? GoldenPart { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// PartTitle (from Table)
		/// </summary>
		public System.String PartTitle { get; set; }
		/// <summary>
		/// PartName (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.String PartName { get; set; }

       
        public System.String PartNameWithManufacture { get; set; }
        public System.String Productname { get; set; }
        public System.String DateCode { get; set; }
        public System.String Packagename { get; set; }
        public System.Int32 ROHSNo { get; set; }
        public System.String ManufacturerName { get; set; }
        public System.String DateCodeOriginal { get; set; }
        public System.String ProductDescription { get; set; }
        public System.Boolean? ProductInactive { get; set; }
		#endregion

	}
}