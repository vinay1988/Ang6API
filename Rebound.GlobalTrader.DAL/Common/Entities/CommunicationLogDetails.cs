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
	
	public class CommunicationLogDetails {
		
		#region Constructors
		
		public CommunicationLogDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// CommunicationLogId (from Table)
		/// </summary>
		public System.Int32 CommunicationLogId { get; set; }
		/// <summary>
		/// Notes (from Table)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// ContactNo (from Table)
		/// </summary>
		public System.Int32? ContactNo { get; set; }
		/// <summary>
		/// CompanyNo (from Table)
		/// </summary>
		public System.Int32? CompanyNo { get; set; }
		/// <summary>
		/// Frozen (from Table)
		/// </summary>
		public System.Boolean Frozen { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// LogDate (from Table)
		/// </summary>
		public System.DateTime LogDate { get; set; }
		/// <summary>
		/// KeyNo (from Table)
		/// </summary>
		public System.Int32? KeyNo { get; set; }
		/// <summary>
		/// CommunicationLogTypeNo (from Table)
		/// </summary>
		public System.Int32? CommunicationLogTypeNo { get; set; }
		/// <summary>
		/// SystemDocumentNo (from Table)
		/// </summary>
		public System.Int32? SystemDocumentNo { get; set; }
		/// <summary>
		/// DocumentNumber (from Table)
		/// </summary>
		public System.Int32? DocumentNumber { get; set; }
		/// <summary>
		/// ContactName (from usp_datalistnugget_CommunicationLog)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// CompanyName (from usp_datalistnugget_CommunicationLog)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// CommunicationLogTypeDescription (from usp_datalistnugget_CommunicationLog)
		/// </summary>
		public System.String CommunicationLogTypeDescription { get; set; }
		/// <summary>
		/// EnteredBy (from usp_datalistnugget_CommunicationLog)
		/// </summary>
		public System.String EnteredBy { get; set; }
		/// <summary>
		/// RowNum (from usp_datalistnugget_CommunicationLog)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_datalistnugget_CommunicationLog)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
        /// <summary>
        /// LogDetail 
        /// </summary>
        public System.String LogDetail { get; set; }
        /// <summary>
        /// SectionName 
        /// </summary>
        public System.String SectionName { get; set; }
        /// <summary>
        /// ActionName 
        /// </summary>
        public System.String ActionName { get; set; }
        /// <summary>
        /// UpdatedByName
        /// </summary>
        public System.String UpdatedByName { get; set; }
        /// <summary>
        /// SubSectionName 
        /// </summary>
        public System.String SubSectionName { get; set; }

		#endregion

	}
}