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
	
	public class CertificateDetails {
		
		#region Constructors

        public CertificateDetails() { }
		
		#endregion
		
		#region Properties

        /// <summary>
        /// CertificateId
        /// </summary>
        public System.Int32 CertificateId { get; set; }
        /// <summary>
        /// CertificateName
        /// </summary>
        public System.String CertificateName { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public System.String Description { get; set; }
        /// <summary>
        /// CertificateCategoryNo
        /// </summary>
        public System.Int32? CertificateCategoryNo { get; set; }
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
        /// <summary>
        /// CompanyCertificateId
        /// </summary>
        public System.Int32 CompanyCertificateId { get; set; }
        /// <summary>
        /// StartDate
        /// </summary>
        public System.DateTime? StartDate { get; set; }
        /// <summary>
        /// ExpiryDate
        /// </summary>
        public System.DateTime? ExpiryDate { get; set; }
        /// <summary>
        /// CertificateCategoryName
        /// </summary>
        public System.String CertificateCategoryName { get; set; }
        /// <summary>
        /// CertificateNumber
        /// </summary>
        public System.String CertificateNumber { get; set; }

		#endregion

	}
}
