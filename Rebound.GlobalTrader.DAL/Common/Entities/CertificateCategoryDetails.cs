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
	
	public class CertificateCategoryDetails {
		
		#region Constructors

        public CertificateCategoryDetails() { }
		
		#endregion
		
		#region Properties

        /// <summary>
        /// CertificateCategoryId
        /// </summary>
        public System.Int32 CertificateCategoryId { get; set; }
        /// <summary>
        /// CertificateCategoryName
        /// </summary>
        public System.String CertificateCategoryName { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public System.String Description { get; set; }
        /// <summary>
        /// Inactive
        /// </summary>
        public System.Boolean Inactive { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime DLUP { get; set; }	

		#endregion

	}
}
