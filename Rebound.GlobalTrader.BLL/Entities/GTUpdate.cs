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
using System.Collections.Generic;
using Rebound.GlobalTrader.DAL;
using Rebound.GlobalTrader.BLL;

namespace Rebound.GlobalTrader.BLL {
    public partial class GTUpdate : BizObject
    {
		
		#region Properties

        protected static DAL.GTUpdateElement Settings
        {
            get { return Globals.Settings.GTUpdates; }
		}

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
		
		#region Methods

        /// <summary>
        /// Insert
        /// Calls [usp_insert_GTAppUpdate]
        /// </summary>
        public static Int32 Insert(System.String GTAppUpdateName, System.String GTAppUpdateTitle, System.String GTAppUpdateValue, System.String GTAppUpdateVersion, System.Int32? ClientNo, System.Boolean? IsShowPopupHome, System.Boolean? IsSendMailtoUser, System.Boolean? inactive, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.GTUpdate.Insert(GTAppUpdateName, GTAppUpdateTitle, GTAppUpdateValue, GTAppUpdateVersion, ClientNo, IsShowPopupHome, IsSendMailtoUser, inactive, updatedBy);
            return objReturn;
        }

        /// <summary>
        /// Calls [usp_Get_All_GTAPPUpdates]
        /// </summary>
        /// <returns></returns>
        public static List<GTUpdate> GetListGTUpdate()
        {
            List<GTUpdateDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GTUpdate.GetListGTUpdate();
			if (lstDetails == null) {
                return new List<GTUpdate>();
			} else {
                List<GTUpdate> lst = new List<GTUpdate>();
                foreach (GTUpdateDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.GTUpdate obj = new Rebound.GlobalTrader.BLL.GTUpdate();
                    obj.GTAppUpdateId = objDetails.GTAppUpdateId;
                    obj.GTAppUpdateName = objDetails.GTAppUpdateName;
                    obj.GTAppUpdateTitle = objDetails.GTAppUpdateTitle;
                    obj.GTAppUpdateValue =objDetails.GTAppUpdateValue;
                    obj.Inactive =objDetails.Inactive;
                    obj.UpdatedBy =objDetails.UpdatedBy;
                    obj.GTAppUpdateVersion = objDetails.GTAppUpdateVersion;
                    obj.IsSendMailtoUser = objDetails.IsSendMailtoUser;
                    obj.IsShowPopupHome = objDetails.IsShowPopupHome;
                    obj.DLUP =objDetails.DLUP;
                    obj.ClientNo = objDetails.ClientNo;
                   lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
	
		/// <summary>
		/// Get
        /// Calls [usp_select_GTAPPUpdates]
		/// </summary>
        public static GTUpdate Get(System.Int32? categoryId)
        {
            Rebound.GlobalTrader.DAL.GTUpdateDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.GTUpdate.Get(categoryId);
			if (objDetails == null) {
				return null;
			} else {
                GTUpdate obj = new GTUpdate();
                     obj.GTAppUpdateId = objDetails.GTAppUpdateId;
                    obj.GTAppUpdateTitle = objDetails.GTAppUpdateTitle;
                    obj.GTAppUpdateValue = objDetails.GTAppUpdateValue;
                    obj.ClientNo= objDetails.ClientNo;
                    obj.GTAppUpdateName = objDetails.GTAppUpdateName;
                    obj.IsShowPopupHome = objDetails.IsShowPopupHome;
                    obj.IsSendMailtoUser = objDetails.IsSendMailtoUser;
                    obj.Inactive = objDetails.Inactive;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		
		/// <summary>
		/// Update 
        /// Calls [usp_update_GTAppUpdate]
		/// </summary>
        public static Boolean Update(System.Int32 GTAppUpdateId, System.String GTAppUpdateName, System.String GTAppUpdateTitle, System.String GTAppUpdateValue, System.Int32? ClientNo, System.Int32? UpdatedBy, System.Boolean? IsShowPopupHome, System.Boolean? IsSendMailtoUser, System.Boolean? IsActive, System.String GTAppUpdateVersion)
    {
        return Rebound.GlobalTrader.DAL.SiteProvider.GTUpdate.Update(GTAppUpdateId, GTAppUpdateName, GTAppUpdateTitle, GTAppUpdateValue, ClientNo, UpdatedBy, IsShowPopupHome, IsSendMailtoUser, IsActive, GTAppUpdateVersion);
        }

       
		#endregion
		
	}
}