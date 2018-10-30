using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebound.GlobalTrader.DAL
{
    public abstract class TabSecurityFunctionProvider : DataAccess
    {
        static private TabSecurityFunctionProvider _instance = null;
        static public TabSecurityFunctionProvider Instance
        {
			get {
				if (_instance == null) _instance = (TabSecurityFunctionProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.TabSecurityFunctions.ProviderType));
				return _instance;
			}
		}
        public TabSecurityFunctionProvider()
        {
			this.ConnectionString = Globals.Settings.TabSecurityFunctions.ConnectionString;
        }
        #region Method registration
        /// <summary>
        /// Calls [usp_selectAll_TabSecurityFunction_General_Permissions_by_SecurityGroup]
        /// </summary>
        public abstract List<TabSecurityFunctionDetails> GetListGeneralPermissionsByTabSecurityGroup(System.Int32? securityGroupId);
        /// <summary>
        /// GetByGroupAndFunction
        /// Calls [usp_select_TabSecurityGroupSecurityFunctionPermission_by_Group_and_Function]
        /// </summary>
        public abstract TabSecurityFunctionDetails GetByGroupAndFunction(System.Int32? securityGroupNo, System.Int32? tabSecurityFunctionNo);
        /// <summary>
        /// Create a new row
        /// Calls [usp_insert_TabSecurityGroupSecurityFunctionPermission]
        /// </summary>
        public abstract Int32 Insert(System.Int32? securityGroupNo, System.Int32? tabSecurityFunctionId, System.Boolean? myTab, System.Boolean? teamTab, System.Boolean? divisionTab, System.Boolean? companyTab, System.Int32? updatedBy);
        /// <summary>
        /// Update
        /// Calls [usp_update_TabSecurityGroupSecurityFunctionPermission]
        /// </summary>
        public abstract bool Update(System.Int32? tabSecurityGroupSecurityFunctionPermissionId, System.Int32? securityGroupNo, System.Int32? tabSecurityFunctionNo, System.Boolean? myTab, System.Boolean? teamTab, System.Boolean? divisionTab, System.Boolean? companyTab, System.Int32? updatedBy);

        /// <summary>
        /// [usp_select_TabSecurityFunction_Permission_by_Login]
        /// </summary>
        /// <param name="pageId"></param>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public abstract TabSecurityFunctionDetails GetInvisibleTabSecurityList(System.Int32? pageId, System.Int32? loginId);
        /// <summary>
        /// usp_select_TabSecurityFunction_CompanyPermission_by_Login
        /// </summary>
        /// <param name="pageId1"></param>
        /// <param name="pageId2"></param>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public abstract TabSecurityFunctionDetails GetVisibleCompanyTabSecurityList(System.Int32? pageId1, System.Int32? pageId2, System.Int32? loginId); 
        #endregion
    }
}
