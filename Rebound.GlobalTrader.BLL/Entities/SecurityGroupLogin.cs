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
		public partial class SecurityGroupLogin : BizObject {
		
		#region Properties

		protected static DAL.SecurityGroupLoginElement Settings {
			get { return Globals.Settings.SecurityGroupLogins; }
		}

		/// <summary>
		/// SecurityGroupLoginId
		/// </summary>
		public System.Int32 SecurityGroupLoginId { get; set; }		
		/// <summary>
		/// SecurityGroupNo
		/// </summary>
		public System.Int32 SecurityGroupNo { get; set; }		
		/// <summary>
		/// LoginNo
		/// </summary>
		public System.Int32 LoginNo { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// EmployeeName
		/// </summary>
		public System.String EmployeeName { get; set; }		
		/// <summary>
		/// KeyLogin
		/// </summary>
		public System.Boolean KeyLogin { get; set; }		
		/// <summary>
		/// Administrator
		/// </summary>
		public System.Boolean Administrator { get; set; }
        /// <summary>
        /// ClientCode
        /// </summary>
        public System.String ClientCode { get; set; }

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_SecurityGroupLogin]
		/// </summary>
		public static bool Delete(System.Int32? loginNo, System.Int32? securityGroupNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroupLogin.Delete(loginNo, securityGroupNo);
		}
		/// <summary>
		/// DeleteForSecurityGroup
		/// Calls [usp_delete_SecurityGroupLogin_for_SecurityGroup]
		/// </summary>
		public static bool DeleteForSecurityGroup(System.Int32? securityGroupNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroupLogin.DeleteForSecurityGroup(securityGroupNo);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_SecurityGroupLogin]
		/// </summary>
		public static Int32 Insert(System.Int32? securityGroupNo, System.Int32? loginNo, System.Int32? updatedBy,System.Boolean? isGlobal) {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroupLogin.Insert(securityGroupNo, loginNo, updatedBy, isGlobal);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_SecurityGroupLogin]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroupLogin.Insert(SecurityGroupNo, LoginNo, UpdatedBy,false);
		}
		/// <summary>
		/// GetListForSecurityGroup
		/// Calls [usp_selectAll_SecurityGroupLogin_for_SecurityGroup]
		/// </summary>
		public static List<SecurityGroupLogin> GetListForSecurityGroup(System.Int32? securityGroupNo) {
			List<SecurityGroupLoginDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroupLogin.GetListForSecurityGroup(securityGroupNo);
			if (lstDetails == null) {
				return new List<SecurityGroupLogin>();
			} else {
				List<SecurityGroupLogin> lst = new List<SecurityGroupLogin>();
				foreach (SecurityGroupLoginDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityGroupLogin obj = new Rebound.GlobalTrader.BLL.SecurityGroupLogin();
					obj.SecurityGroupLoginId = objDetails.SecurityGroupLoginId;
					obj.SecurityGroupNo = objDetails.SecurityGroupNo;
					obj.LoginNo = objDetails.LoginNo;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.EmployeeName = objDetails.EmployeeName;
					obj.KeyLogin = objDetails.KeyLogin;
					obj.Administrator = objDetails.Administrator;
                    obj.ClientCode = objDetails.ClientCode;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_SecurityGroupLogin]
		/// </summary>
		public static bool Update(System.Int32? securityGroupNo, System.Int32? loginNo, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroupLogin.Update(securityGroupNo, loginNo, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_SecurityGroupLogin]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroupLogin.Update(SecurityGroupNo, LoginNo, UpdatedBy);
		}

        private static SecurityGroupLogin PopulateFromDBDetailsObject(SecurityGroupLoginDetails obj) {
            SecurityGroupLogin objNew = new SecurityGroupLogin();
			objNew.SecurityGroupLoginId = obj.SecurityGroupLoginId;
			objNew.SecurityGroupNo = obj.SecurityGroupNo;
			objNew.LoginNo = obj.LoginNo;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.EmployeeName = obj.EmployeeName;
			objNew.KeyLogin = obj.KeyLogin;
			objNew.Administrator = obj.Administrator;
            return objNew;
        }
		
		#endregion
		
	}
}