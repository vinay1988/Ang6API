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
		public partial class MailGroup : BizObject {
		
		#region Properties

		protected static DAL.MailGroupElement Settings {
			get { return Globals.Settings.MailGroups; }
		}

		/// <summary>
		/// MailGroupId
		/// </summary>
		public System.Int32 MailGroupId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime? DLUP { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32? ClientNo { get; set; }		
		/// <summary>
		/// LoginNo
		/// </summary>
		public System.Int32? LoginNo { get; set; }		
		/// <summary>
		/// NumberOfMembers
		/// </summary>
		public System.Int32? NumberOfMembers { get; set; }
        

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_MailGroup]
		/// </summary>
		public static bool Delete(System.Int32? mailGroupId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.MailGroup.Delete(mailGroupId);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_MailGroup]
		/// </summary>
		public static Int32 Insert(System.Int32? loginNo, System.Int32? clientNo, System.String name, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.MailGroup.Insert(loginNo, clientNo, name, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_MailGroup]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.MailGroup.Insert(LoginNo, ClientNo, Name, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_MailGroup]
		/// </summary>
		public static MailGroup Get(System.Int32? mailGroupNo) {
			Rebound.GlobalTrader.DAL.MailGroupDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.MailGroup.Get(mailGroupNo);
			if (objDetails == null) {
				return null;
			} else {
				MailGroup obj = new MailGroup();
				obj.MailGroupId = objDetails.MailGroupId;
				obj.Name = objDetails.Name;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.ClientNo = objDetails.ClientNo;
				obj.LoginNo = objDetails.LoginNo;
				obj.NumberOfMembers = objDetails.NumberOfMembers;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_MailGroup_for_Client]
		/// </summary>
		public static List<MailGroup> GetListForClient(System.Int32? clientNo) {
			List<MailGroupDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.MailGroup.GetListForClient(clientNo);
			if (lstDetails == null) {
				return new List<MailGroup>();
			} else {
				List<MailGroup> lst = new List<MailGroup>();
				foreach (MailGroupDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.MailGroup obj = new Rebound.GlobalTrader.BLL.MailGroup();
					obj.MailGroupId = objDetails.MailGroupId;
					obj.Name = objDetails.Name;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.ClientNo = objDetails.ClientNo;
					obj.LoginNo = objDetails.LoginNo;
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
		/// Calls [usp_selectAll_MailGroup_for_Login]
		/// </summary>
		public static List<MailGroup> GetListForLogin(System.Int32? loginNo) {
			List<MailGroupDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.MailGroup.GetListForLogin(loginNo);
			if (lstDetails == null) {
				return new List<MailGroup>();
			} else {
				List<MailGroup> lst = new List<MailGroup>();
				foreach (MailGroupDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.MailGroup obj = new Rebound.GlobalTrader.BLL.MailGroup();
					obj.MailGroupId = objDetails.MailGroupId;
					obj.Name = objDetails.Name;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.ClientNo = objDetails.ClientNo;
					obj.LoginNo = objDetails.LoginNo;
					obj.NumberOfMembers = objDetails.NumberOfMembers;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_MailGroup]
		/// </summary>
		public static bool Update(System.Int32? mailGroupId, System.Int32? loginNo, System.Int32? clientNo, System.String name, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.MailGroup.Update(mailGroupId, loginNo, clientNo, name, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_MailGroup]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.MailGroup.Update(MailGroupId, LoginNo, ClientNo, Name, UpdatedBy);
		}

        private static MailGroup PopulateFromDBDetailsObject(MailGroupDetails obj) {
            MailGroup objNew = new MailGroup();
			objNew.MailGroupId = obj.MailGroupId;
			objNew.Name = obj.Name;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.ClientNo = obj.ClientNo;
			objNew.LoginNo = obj.LoginNo;
			objNew.NumberOfMembers = obj.NumberOfMembers;
            return objNew;
        }
        public static int? GetQualityMailGroupNo(System.Int32? clientNo)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.MailGroup.GetQualityMailGroupNo(clientNo);
        }
		
		#endregion
		
	}
}