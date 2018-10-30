using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rebound.GlobalTrader.DAL;
using Rebound.GlobalTrader.BLL;

namespace Rebound.GlobalTrader.BLL
{
   public class TabSecurityFuncion : BizObject
    {
        #region Properties

        protected static DAL.TabSecurityFunctionElement Settings
        {
            get { return Globals.Settings.TabSecurityFunctions; }
        }

        /// <summary>
        /// TabSecurityFunctionId
        /// </summary>
        public System.Int32 TabSecurityFunctionId { get; set; }
        /// <summary>
        /// TabFunctionName
        /// </summary>
        public System.String TabFunctionName { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public System.String Description { get; set; }
        /// <summary>
        /// SitePageNo
        /// </summary>
        public System.Int32? SitePageNo { get; set; }
        /// <summary>
        /// SiteSectionNo
        /// </summary>
        public System.Int32? SiteSectionNo { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime DLUP { get; set; }
        /// <summary>
        /// InitiallyProhibitedForNewLogins
        /// </summary>
        public System.Boolean InitiallyProhibitedForNewLogins { get; set; }
        /// <summary>
        /// DisplaySortOrder
        /// </summary>
        public System.Int32? DisplaySortOrder { get; set; }
        /// <summary>
        /// MyTab
        /// </summary>
        public System.Boolean? MyTab { get; set; }
       /// <summary>
        /// TeamTab
       /// </summary>
        public System.Boolean? TeamTab { get; set; }
       /// <summary>
        /// DivisionTab
       /// </summary>
        public System.Boolean? DivisionTab { get; set; }
       /// <summary>
       /// CompanyTab
       /// </summary>
        public System.Boolean? CompanyTab { get; set; }
       /// <summary>
        /// SiteSectionName
       /// </summary>
        public System.String SiteSectionName { get; set; }
       /// <summary>
       /// SecurityGroupNo
       /// </summary>
        public System.Int32? SecurityGroupNo { get; set; }
       /// <summary>
        /// TabSecurityGroupSecurityFunctionPermissionId
       /// </summary>
        public System.Int32 TabSecurityGroupSecurityFunctionPermissionId { get; set; }
       

        #endregion

        #region Public Method
        /// <summary>
        /// Calls [usp_selectAll_TabSecurityFunction_General_Permissions_by_SecurityGroup]
        /// </summary>
        public static List<TabSecurityFuncion> GetListGeneralPermissionsByTabSecurityGroup(System.Int32? securityGroupId)
        {
            List<TabSecurityFunctionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.TabSecurityFunction.GetListGeneralPermissionsByTabSecurityGroup(securityGroupId);
            if (lstDetails == null)
            {
                return new List<TabSecurityFuncion>();
            }
            else
            {
                List<TabSecurityFuncion> lst = new List<TabSecurityFuncion>();
                foreach (TabSecurityFunctionDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.TabSecurityFuncion obj = new Rebound.GlobalTrader.BLL.TabSecurityFuncion();
                    obj.TabSecurityFunctionId = objDetails.TabSecurityFunctionId;
                    obj.TabFunctionName = objDetails.TabFunctionName;
                    obj.MyTab = objDetails.MyTab;
                    obj.TeamTab = objDetails.TeamTab;
                    obj.DivisionTab = objDetails.DivisionTab;
                    obj.CompanyTab = objDetails.CompanyTab;
                    obj.SiteSectionName = objDetails.SiteSectionName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetByGroupAndFunction
        /// Calls [usp_select_TabSecurityGroupSecurityFunctionPermission_by_Group_and_Function]
        /// </summary>
        public static TabSecurityFuncion GetByGroupAndFunction(System.Int32? securityGroupNo, System.Int32? tabSecurityFunctionNo)
        {
            Rebound.GlobalTrader.DAL.TabSecurityFunctionDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.TabSecurityFunction.GetByGroupAndFunction(securityGroupNo, tabSecurityFunctionNo);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                TabSecurityFuncion obj = new TabSecurityFuncion();
                obj.TabSecurityGroupSecurityFunctionPermissionId = objDetails.TabSecurityGroupSecurityFunctionPermissionId;
                obj.SecurityGroupNo = objDetails.SecurityGroupNo;
                obj.TabSecurityFunctionId = objDetails.TabSecurityFunctionId;
                obj.MyTab = objDetails.MyTab;
                obj.TeamTab = objDetails.TeamTab;
                obj.DivisionTab = objDetails.DivisionTab;
                obj.CompanyTab = objDetails.CompanyTab;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// Insert (without parameters)
        /// Calls [usp_insert_TabSecurityGroupSecurityFunctionPermission]
        /// </summary>
        public Int32 Insert()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.TabSecurityFunction.Insert(SecurityGroupNo, TabSecurityFunctionId, MyTab, TeamTab, DivisionTab, CompanyTab, UpdatedBy);
        }
        /// <summary>
        /// Update (without parameters)
        /// Calls [usp_update_TabSecurityGroupSecurityFunctionPermission]
        /// </summary>
        public bool Update()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.TabSecurityFunction.Update(TabSecurityGroupSecurityFunctionPermissionId, SecurityGroupNo, TabSecurityFunctionId, MyTab,TeamTab,DivisionTab,CompanyTab, UpdatedBy);
        }
       /// <summary>
        /// [usp_select_TabSecurityFunction_Permission_by_Login]
       /// </summary>
       /// <param name="pageId"></param>
       /// <param name="loginId"></param>
       /// <returns></returns>
        public static TabSecurityFuncion GetInvisibleTabSecurityList(System.Int32? pageId, System.Int32? loginId)
        {
            Rebound.GlobalTrader.DAL.TabSecurityFunctionDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.TabSecurityFunction.GetInvisibleTabSecurityList(pageId, loginId);
            if (objDetails == null)
                return null;
            else
            {
                TabSecurityFuncion obj = new TabSecurityFuncion();
                obj.MyTab = objDetails.MyTab;
                obj.TeamTab = objDetails.TeamTab;
                obj.DivisionTab = objDetails.DivisionTab;
                obj.CompanyTab = objDetails.CompanyTab;
                objDetails = null;
                return obj;
            }
        }
       /// <summary>
        /// usp_select_TabSecurityFunction_CompanyPermission_by_Login
       /// </summary>
       /// <param name="pageId1"></param>
       /// <param name="pageId2"></param>
       /// <param name="loginId"></param>
       /// <returns></returns>
        public static TabSecurityFuncion GetVisibleCompanyTabSecurityList(System.Int32? pageId1, System.Int32? pageId2, System.Int32? loginId)
        {
            Rebound.GlobalTrader.DAL.TabSecurityFunctionDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.TabSecurityFunction.GetVisibleCompanyTabSecurityList(pageId1, pageId2, loginId);
            if (objDetails == null)
                return null;
            else
            {
                TabSecurityFuncion obj = new TabSecurityFuncion();
                obj.MyTab = objDetails.MyTab;
                obj.TeamTab = objDetails.TeamTab;
                obj.DivisionTab = objDetails.DivisionTab;
                obj.CompanyTab = objDetails.CompanyTab;
                objDetails = null;
                return obj;
            }
        }

        #endregion
    }
}
