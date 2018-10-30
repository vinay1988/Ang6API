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
		public partial class SecurityGroup : BizObject {
		
		#region Properties

		protected static DAL.SecurityGroupElement Settings {
			get { return Globals.Settings.SecurityGroups; }
		}

		/// <summary>
		/// SecurityGroupId
		/// </summary>
		public System.Int32 SecurityGroupId { get; set; }		
		/// <summary>
		/// SecurityGroupName
		/// </summary>
		public System.String SecurityGroupName { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// Inactive
		/// </summary>
		public System.Boolean Inactive { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// Locked
		/// </summary>
		public System.Boolean Locked { get; set; }		
		/// <summary>
		/// Administrator
		/// </summary>
		public System.Boolean Administrator { get; set; }		
		/// <summary>
		/// NumberOfMembers
		/// </summary>
		public System.Int32? NumberOfMembers { get; set; }
        /// <summary>
        /// IsGlobal
        /// </summary>
        public System.Boolean? IsGlobal { get; set; }
        

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_SecurityGroup]
		/// </summary>
		public static bool Delete(System.Int32? securityGroupNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroup.Delete(securityGroupNo);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_SecurityGroup]
		/// </summary>
		public static Int32 Insert(System.String securityGroupName, System.Int32? clientNo, System.Boolean? inactive, System.Boolean? locked, System.Boolean? administrator, System.Int32? updatedBy,System.Boolean? isGlobal) {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroup.Insert(securityGroupName, clientNo, inactive, locked, administrator, updatedBy, isGlobal);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_SecurityGroup]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroup.Insert(SecurityGroupName, ClientNo, Inactive, Locked, Administrator, UpdatedBy,IsGlobal);
		}
		/// <summary>
		/// InsertClone
		/// Calls [usp_insert_SecurityGroup_Clone]
		/// </summary>
		public static Int32 InsertClone(System.Int32? oldSecurityGroupId, System.String securityGroupName, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroup.InsertClone(oldSecurityGroupId, securityGroupName, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_SecurityGroup]
		/// </summary>
		public static SecurityGroup Get(System.Int32? securityGroupNo) {
			Rebound.GlobalTrader.DAL.SecurityGroupDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroup.Get(securityGroupNo);
			if (objDetails == null) {
				return null;
			} else {
				SecurityGroup obj = new SecurityGroup();
				obj.SecurityGroupId = objDetails.SecurityGroupId;
				obj.SecurityGroupName = objDetails.SecurityGroupName;
				obj.ClientNo = objDetails.ClientNo;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.Locked = objDetails.Locked;
				obj.Administrator = objDetails.Administrator;
				obj.NumberOfMembers = objDetails.NumberOfMembers;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_SecurityGroup_for_Client]
		/// </summary>
		public static List<SecurityGroup> GetListForClient(System.Int32? clientNo,System.Boolean? isGlobal) {
            List<SecurityGroupDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroup.GetListForClient(clientNo, isGlobal);
			if (lstDetails == null) {
				return new List<SecurityGroup>();
			} else {
				List<SecurityGroup> lst = new List<SecurityGroup>();
				foreach (SecurityGroupDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityGroup obj = new Rebound.GlobalTrader.BLL.SecurityGroup();
					obj.SecurityGroupId = objDetails.SecurityGroupId;
					obj.SecurityGroupName = objDetails.SecurityGroupName;
					obj.ClientNo = objDetails.ClientNo;
					obj.Inactive = objDetails.Inactive;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.Locked = objDetails.Locked;
					obj.Administrator = objDetails.Administrator;
					obj.NumberOfMembers = objDetails.NumberOfMembers;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForLogin
		/// Calls [usp_selectAll_SecurityGroup_for_Login]
		/// </summary>
		public static List<SecurityGroup> GetListForLogin(System.Int32? loginNo) {
			List<SecurityGroupDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroup.GetListForLogin(loginNo);
			if (lstDetails == null) {
				return new List<SecurityGroup>();
			} else {
				List<SecurityGroup> lst = new List<SecurityGroup>();
				foreach (SecurityGroupDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SecurityGroup obj = new Rebound.GlobalTrader.BLL.SecurityGroup();
					obj.SecurityGroupId = objDetails.SecurityGroupId;
					obj.SecurityGroupName = objDetails.SecurityGroupName;
					obj.ClientNo = objDetails.ClientNo;
					obj.Inactive = objDetails.Inactive;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.Locked = objDetails.Locked;
					obj.Administrator = objDetails.Administrator;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_SecurityGroup]
		/// </summary>
		public static bool Update(System.Int32? securityGroupId, System.String securityGroupName, System.Int32? clientNo, System.Boolean? locked, System.Boolean? administrator, System.Boolean? inactive, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroup.Update(securityGroupId, securityGroupName, clientNo, locked, administrator, inactive, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_SecurityGroup]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.SecurityGroup.Update(SecurityGroupId, SecurityGroupName, ClientNo, Locked, Administrator, Inactive, UpdatedBy);
		}

        private static SecurityGroup PopulateFromDBDetailsObject(SecurityGroupDetails obj) {
            SecurityGroup objNew = new SecurityGroup();
			objNew.SecurityGroupId = obj.SecurityGroupId;
			objNew.SecurityGroupName = obj.SecurityGroupName;
			objNew.ClientNo = obj.ClientNo;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.Locked = obj.Locked;
			objNew.Administrator = obj.Administrator;
			objNew.NumberOfMembers = obj.NumberOfMembers;
            return objNew;
        }
		
		#endregion
		
	}
}