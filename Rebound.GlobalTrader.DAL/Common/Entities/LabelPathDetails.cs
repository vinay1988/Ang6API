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
	
	public class LabelPathDetails {
		
		#region Constructors

        public LabelPathDetails() { }
		
		#endregion
		
		#region Properties

        /// <summary>
        /// LabelPathId
        /// </summary>
        public System.Int32 LabelPathId { get; set; }
        /// <summary>
        /// Client No
        /// </summary>
        public System.Int32 ClientNo { get; set; }
        /// <summary>
        /// Printer Name
        /// </summary>
        public System.String LabelFullPath { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public System.String Description { get; set; }
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