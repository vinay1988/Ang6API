//Marker    changed by      date           Remarks
//[001]      Vinay           12/08/2014     ESMS  Ticket Number: 	201
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Rebound.GlobalTrader.DAL;
using Rebound.GlobalTrader.BLL;

namespace Rebound.GlobalTrader.BLL {
    public partial class CSVExportLog : BizObject
    {
        #region Properties
        protected static DAL.CSVExportLogElement Settings
        {
            get { return Globals.Settings.CSVExportLog; }
        }
        /// <summary>
        /// Id
        /// </summary>
        public System.Int32 Id { get; set; }
        /// <summary> 
        /// Company No
        /// </summary>       
        public System.Int32? CompanyNo { get; set; }
    
        public System.String Filename { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        public System.String Section { get; set; } 
                   
        #endregion

        #region Methods         
        /// <summary>
        /// Insert
        /// Calls [usp_insert_CSVExportLog]
        /// </summary>
        public static Int32 Insert(System.Int32? CompanyNo, System.String Filename, System.Int32? updatedBy, System.String Section, System.String SendmailID, System.Int32? PurchaseQuoteNo, System.String strSubject, System.String strMessage)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CSVExportLog.Insert(CompanyNo, Filename, updatedBy, Section, SendmailID, PurchaseQuoteNo,strSubject,strMessage);
            return objReturn;
        }

        /// <summary>
        /// Insert
        /// Calls [usp_create_SaveMailLog]
        /// </summary>
        public static Int32 InsertMailLog(System.String CompanyName,System.Int32? Id,string Type)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CSVExportLog.InsertMailLog(CompanyName, Id,Type);
            return objReturn;
        }
        #endregion

    }
}
