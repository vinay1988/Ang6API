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
    public partial class Printer : BizObject
    {		
        #region Properties

        protected static DAL.PrinterElement Settings
        {
            get { return Globals.Settings.Printer; }
        }

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
		
		#region Methods
				
		/// <summary>
		/// DropDownForClient
        /// Calls [usp_dropdown_PrinterAll]
		/// </summary>
        public static List<Printer> DropDownForPrinter(System.Int32? clientId)
        {
            List<PrinterDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Printer.DropDownForPrinter(clientId);
			if (lstDetails == null) {
                return new List<Printer>();
			} else {
				List<Printer> lst = new List<Printer>();
                foreach (PrinterDetails objDetails in lstDetails)
                {
					Rebound.GlobalTrader.BLL.Printer obj = new Rebound.GlobalTrader.BLL.Printer();
					obj.PrinterId = objDetails.PrinterId;
					obj.PrinterName = objDetails.PrinterName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        /// <summary>
        /// [usp_insert_Printer]
        /// </summary>
        /// <param name="clientNo"></param>
        /// <param name="printerName"></param>
        /// <param name="description"></param>
        /// <param name="inActive"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public static int Insert(System.Int32? clientNo, System.String printerName, System.String description, System.Boolean? inActive, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Printer.Insert(clientNo, printerName, description, inActive, updatedBy);
            return objReturn;
        }
        /// <summary>
        /// Calls [usp_update_Printer]
        /// </summary>
        /// <param name="printerId"></param>
        /// <param name="clientNo"></param>
        /// <param name="printerName"></param>
        /// <param name="description"></param>
        /// <param name="inActive"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public static bool Update(System.Int32? printerId, System.Int32? clientNo, System.String printerName, System.String description, System.Boolean? inActive, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Printer.Update(printerId, clientNo, printerName, description, inActive, updatedBy);
        }

        /// <summary>
        /// GetListForClient
        /// Calls [usp_selectAll_Printer_for_Client]
        /// </summary>
        public static List<Printer> GetListForClient(System.Int32? clientId)
        {
            List<PrinterDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Printer.GetListForClient(clientId);
            if (lstDetails == null)
            {
                return new List<Printer>();
            }
            else
            {
                List<Printer> lst = new List<Printer>();
                foreach (PrinterDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Printer obj = new Rebound.GlobalTrader.BLL.Printer();
                    obj.PrinterId = objDetails.PrinterId;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.PrinterName = objDetails.PrinterName;
                    obj.PrinterDescription = objDetails.PrinterDescription;
                    obj.Inactive = objDetails.Inactive;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
		
		#endregion

    }
}