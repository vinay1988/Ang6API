//Marker     Changed by      Date         Remarks
//[001]      Vinay           04/07/2012   This need to notify the user by email.
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
	
	public class LoginPreferenceDetails {
		
		#region Constructors
		
		public LoginPreferenceDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// LoginNo (from Table)
		/// </summary>
		public System.Int32 LoginNo { get; set; }
		/// <summary>
		/// ShowMessageAlert (from Table)
		/// </summary>
		public System.Boolean ShowMessageAlert { get; set; }
		/// <summary>
		/// DefaultSiteLanguageNo (from Table)
		/// </summary>
		public System.Int32? DefaultSiteLanguageNo { get; set; }
		/// <summary>
		/// DefaultListPageSize (from Table)
		/// </summary>
		public System.Int32 DefaultListPageSize { get; set; }
		/// <summary>
		/// NumberRecentlyViewedPages (from Table)
		/// </summary>
		public System.Int32 NumberRecentlyViewedPages { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime? DLUP { get; set; }
		/// <summary>
		/// DefaultHomePageTab (from Table)
		/// </summary>
		public System.Int32 DefaultHomePageTab { get; set; }
		/// <summary>
		/// DefaultListPageView (from Table)
		/// </summary>
		public System.Int32 DefaultListPageView { get; set; }
		/// <summary>
		/// BackgroundImage (from Table)
		/// </summary>
		public System.String BackgroundImage { get; set; }
		/// <summary>
		/// SaveDataListNuggetStateByDefault (from Table)
		/// </summary>
		public System.Boolean SaveDataListNuggetStateByDefault { get; set; }
		/// <summary>
		/// LoginTimeout (from Table)
		/// </summary>
		public System.Int32 LoginTimeout { get; set; }
		/// <summary>
		/// DefaultSiteLanguageCode (from usp_select_LoginPreference_by_Login)
		/// </summary>
		public System.String DefaultSiteLanguageCode { get; set; }
        //[001] code start
        /// <summary>
        /// SendEmail
        /// </summary>
        public System.Boolean? SendEmail { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public System.String Email { get; set; }
        //[001] code end
        /// <summary>
        /// PrinterNo
        /// </summary>
        public System.Int32? PrinterNo { get; set; }
        /// <summary>
        /// PrinterName
        /// </summary>
        public System.String PrinterName { get; set; }
        public System.Int32? LabelPathNo { get; set; }
		#endregion

	}
}