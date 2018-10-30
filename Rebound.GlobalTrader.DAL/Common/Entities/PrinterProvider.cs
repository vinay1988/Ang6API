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
	
	public abstract class PrinterProvider : DataAccess {
		static private PrinterProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public PrinterProvider Instance {
			get {
				if (_instance == null) _instance = (PrinterProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Printer.ProviderType));
				return _instance;
			}
		}
        public PrinterProvider()
        {
			this.ConnectionString = Globals.Settings.Printer.ConnectionString;
		}

		#region Method Registrations
				
		/// <summary>
        /// DropDownForPrinter
        /// Calls [usp_dropdown_PrinterAll]
		/// </summary>
        public abstract List<PrinterDetails> DropDownForPrinter(System.Int32? clientId);

        /// <summary>
        /// Insert
        /// Calls [usp_insert_Printer]
        /// </summary>
        /// <param name="clientNo"></param>
        /// <param name="printerName"></param>
        /// <param name="description"></param>
        /// <param name="inActive"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public abstract Int32 Insert(System.Int32? clientNo, System.String printerName, System.String description, System.Boolean? inActive, System.Int32? updatedBy);
        /// <summary>
        /// Update
        /// Call [usp_update_Printer]
        /// </summary>
        /// <param name="printerId"></param>
        /// <param name="clientNo"></param>
        /// <param name="printerName"></param>
        /// <param name="description"></param>
        /// <param name="inActive"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public abstract bool Update(System.Int32? printerId, System.Int32? clientNo, System.String printerName, System.String description, System.Boolean? inActive, System.Int32? updatedBy);
        /// <summary>
        /// Call [usp_selectAll_Printer_for_Client]
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public abstract List<PrinterDetails> GetListForClient(System.Int32? clientId);

		#endregion
		
	}
}