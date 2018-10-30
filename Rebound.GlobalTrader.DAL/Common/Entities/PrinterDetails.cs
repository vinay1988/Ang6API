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
	
	public class PrinterDetails {
		
		#region Constructors

        public PrinterDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
        /// Printer Id
		/// </summary>
        public System.Int32 PrinterId { get; set; }
		/// <summary>
		/// Client No
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
        /// Printer Name
		/// </summary>
        public System.String PrinterName { get; set; }
		/// <summary>
        /// Printer Description
		/// </summary>
        public System.String PrinterDescription { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
        /// Inactive
		/// </summary>
        public System.Boolean Inactive { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }


		#endregion

	}
}