using System;
using System.Data;
using System.Configuration;
/*
Marker     Changed by      Date         Remarks
[001]      Abhinav        06/04/2018   [REB-10310]: CHG-146739: Built in function to notifi users when GT is updated when they login

*/
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL
{

    public abstract class GTUpdateProvider : DataAccess
    {
        static private GTUpdateProvider _instance = null;
        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>       
        static public GTUpdateProvider Instance
        {
            get
            {
                if (_instance == null) _instance = (GTUpdateProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.GTUpdates.ProviderType));
                return _instance;
            }
        }
        public GTUpdateProvider()
        {
            this.ConnectionString = Globals.Settings.GTUpdates.ConnectionString;
        }

        #region Method Registrations
        /// <summary>
        /// Insert
        /// Calls [usp_insert_GTAppUpdate]
        /// </summary>
        public abstract Int32 Insert(System.String GTAppUpdateName, System.String GTAppUpdateTitle, System.String GTAppUpdateValue, System.String GTAppUpdateVersion, System.Int32? ClientNo, System.Boolean? IsShowPopupHome, System.Boolean? IsSendMailtoUser, System.Boolean? inactive, System.Int32? updatedBy);
        /// <summary>
        /// Get
        /// Calls [usp_select_GTAppUpdate]
        /// </summary>
        public abstract GTUpdateDetails Get(System.Int32? GTAppUpdateId);
        /// <summary>
        /// Calls [usp_update_GTAppUpdate]
        /// </summary>
        public abstract bool Update(System.Int32 GTAppUpdateId ,System.String  GTAppUpdateName ,System.String GTAppUpdateTitle  ,System.String  GTAppUpdateValue,System.Int32? ClientNo  ,System.Int32? UpdatedBy,System.Boolean? IsShowPopupHome , System.Boolean?  IsSendMailtoUser,System.Boolean?  IsActive  ,System.String  GTAppUpdateVersion);
        /// <summary>
        /// Calls [usp_Get_All_GTUpdate]
        /// </summary>
        /// <returns></returns>
        public abstract List<GTUpdateDetails> GetListGTUpdate();

        /// <summary>
        /// Calls [usp_dropdown_GTUpdate]
        /// </summary>
        /// <returns></returns>
     //   public abstract List<GTUpdateDetails> GetDropDownGTUpdate();


        #endregion
    }
}

