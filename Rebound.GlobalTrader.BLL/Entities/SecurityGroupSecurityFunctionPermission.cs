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
		public partial class SecurityGroupSecurityFunctionPermission : BizObject {
		
		#region Properties

		protected static DAL.SecurityGroupSecurityFunctionPermissionElement Settings {
			get { return Globals.Settings.SecurityGroupSecurityFunctionPermissions; }
		}

		/// <summary>
		/// SecurityGroupSecurityFunctionPermissionId
		/// </summary>
		public System.Int32 SecurityGroupSecurityFunctionPermissionId { get; set; }		
		/// <summary>
		/// SecurityGroupNo
		/// </summary>
		public System.Int32 SecurityGroupNo { get; set; }		
		/// <summary>
		/// SecurityFunctionNo
		/// </summary>
		public System.Int32 SecurityFunctionNo { get; set; }		
		/// <summary>
		/// IsAllowed
		/// </summary>
		public System.Boolean IsAllowed { get; set; }		
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
		/// Calls [usp_insert_SecurityGroupSecurityFunctionPermission]
		/// </summary>
		public static Int32 Insert(System.Int32? securityGroupNo, System.Int32? securityFunctionNo, System.Boolean? isAllowed, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroupSecurityFunctionPermission.Insert(securityGroupNo, securityFunctionNo, isAllowed, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_SecurityGroupSecurityFunctionPermission]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroupSecurityFunctionPermission.Insert(SecurityGroupNo, SecurityFunctionNo, IsAllowed, UpdatedBy);
		}
		/// <summary>
		/// InsertDenyAllButAdminsForNewFunction
		/// Calls [usp_insert_SecurityGroupSecurityFunctionPermission_DenyAllButAdminsForNewFunction]
		/// </summary>
		public static Int32 InsertDenyAllButAdminsForNewFunction(System.Int32? securityFunctionId, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroupSecurityFunctionPermission.InsertDenyAllButAdminsForNewFunction(securityFunctionId, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// InsertStandardPermissions
		/// Calls [usp_insert_SecurityGroupSecurityFunctionPermission_StandardPermissions]
		/// </summary>
		public static Int32 InsertStandardPermissions(System.Int32? securityGroupNo, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroupSecurityFunctionPermission.InsertStandardPermissions(securityGroupNo, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_SecurityGroupSecurityFunctionPermission]
		/// </summary>
		public static SecurityGroupSecurityFunctionPermission Get(System.Int32? securityGroupSecurityFunctionPermissionId) {
			Rebound.GlobalTrader.DAL.SecurityGroupSecurityFunctionPermissionDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroupSecurityFunctionPermission.Get(securityGroupSecurityFunctionPermissionId);
			if (objDetails == null) {
				return null;
			} else {
				SecurityGroupSecurityFunctionPermission obj = new SecurityGroupSecurityFunctionPermission();
				obj.SecurityGroupSecurityFunctionPermissionId = objDetails.SecurityGroupSecurityFunctionPermissionId;
				obj.SecurityGroupNo = objDetails.SecurityGroupNo;
				obj.SecurityFunctionNo = objDetails.SecurityFunctionNo;
				obj.IsAllowed = objDetails.IsAllowed;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetByGroupAndFunction
		/// Calls [usp_select_SecurityGroupSecurityFunctionPermission_by_Group_and_Function]
		/// </summary>
		public static SecurityGroupSecurityFunctionPermission GetByGroupAndFunction(System.Int32? securityGroupNo, System.Int32? securityFunctionNo) {
			Rebound.GlobalTrader.DAL.SecurityGroupSecurityFunctionPermissionDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroupSecurityFunctionPermission.GetByGroupAndFunction(securityGroupNo, securityFunctionNo);
			if (objDetails == null) {
				return null;
			} else {
				SecurityGroupSecurityFunctionPermission obj = new SecurityGroupSecurityFunctionPermission();
				obj.SecurityGroupSecurityFunctionPermissionId = objDetails.SecurityGroupSecurityFunctionPermissionId;
				obj.SecurityGroupNo = objDetails.SecurityGroupNo;
				obj.SecurityFunctionNo = objDetails.SecurityFunctionNo;
				obj.IsAllowed = objDetails.IsAllowed;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_SecurityGroupSecurityFunctionPermission]
		/// </summary>
		public static bool Update(System.Int32? securityGroupSecurityFunctionPermissionId, System.Int32? securityGroupNo, System.Int32? securityFunctionNo, System.Boolean? isAllowed, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroupSecurityFunctionPermission.Update(securityGroupSecurityFunctionPermissionId, securityGroupNo, securityFunctionNo, isAllowed, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_SecurityGroupSecurityFunctionPermission]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroupSecurityFunctionPermission.Update(SecurityGroupSecurityFunctionPermissionId, SecurityGroupNo, SecurityFunctionNo, IsAllowed, UpdatedBy);
		}

        private static SecurityGroupSecurityFunctionPermission PopulateFromDBDetailsObject(SecurityGroupSecurityFunctionPermissionDetails obj) {
            SecurityGroupSecurityFunctionPermission objNew = new SecurityGroupSecurityFunctionPermission();
			objNew.SecurityGroupSecurityFunctionPermissionId = obj.SecurityGroupSecurityFunctionPermissionId;
			objNew.SecurityGroupNo = obj.SecurityGroupNo;
			objNew.SecurityFunctionNo = obj.SecurityFunctionNo;
			objNew.IsAllowed = obj.IsAllowed;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
            return objNew;
        }

        /// <summary>
        /// Insert (without parameters)
        /// Calls [usp_insert_GlobalSecurityGroupSecurityFunctionPermission]
        /// </summary>
        public Int32 GlobalPermissionInsert()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroupSecurityFunctionPermission.GlobalPermissionInsert(SecurityGroupNo, SecurityFunctionNo, IsAllowed, UpdatedBy);
        }
        /// <summary>
        /// Update (without parameters)
        /// Calls [usp_update_SecurityGroupSecurityFunctionPermission]
        /// </summary>
        public bool GlobalPermissionUpdate()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroupSecurityFunctionPermission.GlobalPermissionUpdate(SecurityGroupSecurityFunctionPermissionId, SecurityGroupNo, SecurityFunctionNo, IsAllowed, UpdatedBy);
        }

        /// <summary>
        /// Insert
        /// Calls [usp_insert_BulkSecurityGroupSecurityFunctionPermission]
        /// </summary>
        public static Int32 Insert(System.Int32? securityGroupNo, System.String xmlPermission, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroupSecurityFunctionPermission.Insert(securityGroupNo, xmlPermission, updatedBy);
            return objReturn;
        }

		
		#endregion
		
	}
}