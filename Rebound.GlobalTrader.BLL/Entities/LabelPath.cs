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
    public partial class LabelPath : BizObject
    {		
        #region Properties

        protected static DAL.LabelPathElement Settings
        {
            get { return Globals.Settings.LabelPath; }
        }

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
		
		#region Methods
				
		/// <summary>
		/// DropDownForClient
        /// Calls [usp_dropdown_LabelPath]
		/// </summary>
        public static List<LabelPath> DropDownForPrinter(System.Int32? clientId)
        {
            List<LabelPathDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.LabelPath.DropDownForPrinter(clientId);
			if (lstDetails == null) {
                return new List<LabelPath>();
			} else {
                List<LabelPath> lst = new List<LabelPath>();
                foreach (LabelPathDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.LabelPath obj = new Rebound.GlobalTrader.BLL.LabelPath();
                    obj.LabelPathId = objDetails.LabelPathId;
                    obj.LabelFullPath = objDetails.LabelFullPath;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        /// <summary>
        /// [usp_insert_LabelPath]
        /// </summary>
        /// <param name="clientNo"></param>
        /// <param name="labelPath"></param>
        /// <param name="description"></param>
        /// <param name="inActive"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public static int Insert(System.Int32? clientNo, System.String labelPath, System.String description, System.Boolean? inActive, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.LabelPath.Insert(clientNo, labelPath, description, inActive, updatedBy);
            return objReturn;
        }
        /// <summary>
        /// Calls [usp_update_LabelPath]
        /// </summary>
        /// <param name="labelPathId"></param>
        /// <param name="clientNo"></param>
        /// <param name="labelPath"></param>
        /// <param name="description"></param>
        /// <param name="inActive"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public static bool Update(System.Int32? labelPathId, System.Int32? clientNo, System.String labelPath, System.String description, System.Boolean? inActive, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.LabelPath.Update(labelPathId, clientNo, labelPath, description, inActive, updatedBy);
        }

        /// <summary>
        /// GetListForClient
        /// Calls [usp_selectAll_LabelPath_for_Client]
        /// </summary>
        public static List<LabelPath> GetListForClient(System.Int32? clientId)
        {
            List<LabelPathDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.LabelPath.GetListForClient(clientId);
            if (lstDetails == null)
            {
                return new List<LabelPath>();
            }
            else
            {
                List<LabelPath> lst = new List<LabelPath>();
                foreach (LabelPathDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.LabelPath obj = new Rebound.GlobalTrader.BLL.LabelPath();
                    obj.LabelPathId = objDetails.LabelPathId;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.LabelFullPath = objDetails.LabelFullPath;
                    obj.Description = objDetails.Description;
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