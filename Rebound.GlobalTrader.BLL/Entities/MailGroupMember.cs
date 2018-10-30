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
		public partial class MailGroupMember : BizObject {
		
		#region Properties

		protected static DAL.MailGroupMemberElement Settings {
			get { return Globals.Settings.MailGroupMembers; }
		}

		/// <summary>
		/// MailGroupMemberId
		/// </summary>
		public System.Int32 MailGroupMemberId { get; set; }		
		/// <summary>
		/// MailGroupNo
		/// </summary>
		public System.Int32 MailGroupNo { get; set; }		
		/// <summary>
		/// LoginNo
		/// </summary>
		public System.Int32 LoginNo { get; set; }		
		/// <summary>
		/// EmployeeName
		/// </summary>
		public System.String EmployeeName { get; set; }
        public System.String EmailID { get; set; }
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_MailGroupMember]
		/// </summary>
		public static bool Delete(System.Int32? mailGroupNo, System.Int32? loginNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.MailGroupMember.Delete(mailGroupNo, loginNo);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_MailGroupMember]
		/// </summary>
		public static Int32 Insert(System.Int32? mailGroupNo, System.Int32? loginNo) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.MailGroupMember.Insert(mailGroupNo, loginNo);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_MailGroupMember]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.MailGroupMember.Insert(MailGroupNo, LoginNo);
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_MailGroupMember]
		/// </summary>
		public static List<MailGroupMember> GetList(System.Int32? mailGroupMemberId) {
			List<MailGroupMemberDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.MailGroupMember.GetList(mailGroupMemberId);
			if (lstDetails == null) {
				return new List<MailGroupMember>();
			} else {
				List<MailGroupMember> lst = new List<MailGroupMember>();
				foreach (MailGroupMemberDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.MailGroupMember obj = new Rebound.GlobalTrader.BLL.MailGroupMember();
					obj.MailGroupMemberId = objDetails.MailGroupMemberId;
					obj.MailGroupNo = objDetails.MailGroupNo;
					obj.LoginNo = objDetails.LoginNo;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListByGroup
		/// Calls [usp_selectAll_MailGroupMember_by_Group]
		/// </summary>
		public static List<MailGroupMember> GetListByGroup(System.Int32? mailGroupNo) {
			List<MailGroupMemberDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.MailGroupMember.GetListByGroup(mailGroupNo);
			if (lstDetails == null) {
				return new List<MailGroupMember>();
			} else {
				List<MailGroupMember> lst = new List<MailGroupMember>();
				foreach (MailGroupMemberDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.MailGroupMember obj = new Rebound.GlobalTrader.BLL.MailGroupMember();
					obj.MailGroupMemberId = objDetails.MailGroupMemberId;
					obj.MailGroupNo = objDetails.MailGroupNo;
					obj.LoginNo = objDetails.LoginNo;
					obj.EmployeeName = objDetails.EmployeeName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        /// <summary>
        /// GetListByGroup
        /// Calls [[usp_selectAll_MailGroupMember_by_GroupName]]
        /// </summary>
        public static List<MailGroupMember> GetEmailListByGroup(System.String mailGroupName)
        {
            List<MailGroupMemberDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.MailGroupMember.GetEmailListByGroup(mailGroupName);
            if (lstDetails == null)
            {
                return new List<MailGroupMember>();
            }
            else
            {
                List<MailGroupMember> lst = new List<MailGroupMember>();
                foreach (MailGroupMemberDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.MailGroupMember obj = new Rebound.GlobalTrader.BLL.MailGroupMember();
                    obj.MailGroupMemberId = objDetails.MailGroupMemberId;
                    obj.MailGroupNo = objDetails.MailGroupNo;
                    obj.LoginNo = objDetails.LoginNo;
                    obj.EmployeeName = objDetails.EmployeeName;
                    obj.EmailID = objDetails.EmailID;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }


        private static MailGroupMember PopulateFromDBDetailsObject(MailGroupMemberDetails obj) {
            MailGroupMember objNew = new MailGroupMember();
			objNew.MailGroupMemberId = obj.MailGroupMemberId;
			objNew.MailGroupNo = obj.MailGroupNo;
			objNew.LoginNo = obj.LoginNo;
			objNew.EmployeeName = obj.EmployeeName;
            return objNew;
        }
		
		#endregion
		
	}
}