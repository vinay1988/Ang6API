//Marker    changed by      date           Remarks
//[001]      Vinay           12/08/2014     ESMS  Ticket Number: 	201
//[002]     Shashi Keshar    22/02/2016     BOM for Dash Board
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
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL {
	
	public abstract class CSVExportLogProvider : DataAccess {
		static private CSVExportLogProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public CSVExportLogProvider Instance {
			get {
				if (_instance == null) _instance = (CSVExportLogProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.CSVExportLog.ProviderType));
				return _instance;
			}
		}
        public CSVExportLogProvider()
        {
			this.ConnectionString = Globals.Settings.BOM.ConnectionString;
		}

		#region Method Registrations		
		/// <summary>
		/// Insert
        /// Calls [usp_insert_CSVExportLog]
		/// </summary>
        public abstract Int32 Insert(System.Int32? CompanyNo, System.String Filename, System.Int32? updatedBy, System.String Section, System.String SendmailID, System.Int32? PurchaseQuoteNo, System.String strSubject, System.String strMessage);

        /// <summary>
        /// Insert
        /// Calls usp_create_SendMailLog
        /// </summary>
        public abstract Int32 InsertMailLog(System.String CompanyName, System.Int32? Id, string Type);
	    
		#endregion		
        }
}
