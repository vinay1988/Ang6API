/*
Marker     Changed by      Date         Remarks
[001]      Abhinav        06/04/2018   [REB-10310]: CHG-146739: Built in function to notifi users when GT is updated when they login

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
	
	public class GTUpdateDetails {
		
		#region Constructors

        public GTUpdateDetails() { }
		
		#endregion
		
		#region Properties

        /// <summary>
        /// GTUpdateId
        /// </summary>
        public System.Int32 GTAppUpdateId { get; set; }
        /// <summary>
        /// GTUpdateName
        /// </summary>
        public System.String GTAppUpdateName { get; set; }
        /// GTAppUpdateValue
        /// </summary>
         public System.String GTAppUpdateTitle { get; set; }
        /// GTAppUpdateValue
        /// </summary>
        public System.String GTAppUpdateValue { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? ClientNo { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.String GTAppUpdateVersion { get; set; }
        /// <summary>
        /// Inactive
        /// </summary>
        public System.Boolean Inactive { get; set; }
        /// IsShowPopupHome
        /// </summary>
        public System.Boolean IsShowPopupHome { get; set; }
        /// IsSendMailtoUser
        /// </summary>
        public System.Boolean IsSendMailtoUser { get; set; }
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
