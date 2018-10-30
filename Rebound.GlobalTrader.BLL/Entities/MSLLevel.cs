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

namespace Rebound.GlobalTrader.BLL
{
    public partial class MSLLevel : BizObject
    {

        #region Properties

        protected static DAL.MSLLevelElement Settings
        {
            get { return Globals.Settings.MSLLevels; }
        }

        /// <summary>
        /// MSLLevelId
        /// </summary>
        public System.Int32 MSLLevelId { get; set; }
        /// <summary>
        /// MSLLevels
        /// </summary>
        public System.String MSLLevels { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// DropDown
        /// Calls [usp_dropdown_MSLLevel]
        /// </summary>
        public static List<MSLLevel> DropDown()
        {
            List<MSLLevelDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.MSLLevel.DropDown();
            if (lstDetails == null)
            {
                return new List<MSLLevel>();
            }
            else
            {
                List<MSLLevel> lst = new List<MSLLevel>();
                foreach (MSLLevelDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.MSLLevel obj = new Rebound.GlobalTrader.BLL.MSLLevel();
                    obj.MSLLevelId = objDetails.MSLLevelId;
                    obj.MSLLevels = objDetails.MSLLevels;
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

