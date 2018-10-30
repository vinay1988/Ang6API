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
		public partial class Session : BizObject {
		
		#region Properties

		protected static DAL.SessionElement Settings {
			get { return Globals.Settings.Sessions; }
		}

		/// <summary>
		/// LoginNo
		/// </summary>
		public System.Int32 LoginNo { get; set; }		
		/// <summary>
		/// SessionName
		/// </summary>
		public System.String SessionName { get; set; }		
		/// <summary>
		/// SessionTimestamp
		/// </summary>
		public System.DateTime SessionTimestamp { get; set; }		
		/// <summary>
		/// StartTime
		/// </summary>
		public System.DateTime StartTime { get; set; }		
		/// <summary>
		/// IPAddress
		/// </summary>
		public System.String IPAddress { get; set; }		
		/// <summary>
		/// EmployeeName
		/// </summary>
		public System.String EmployeeName { get; set; }
        /// <summary>
        /// ServerIP
        /// </summary>
        public System.String ServerIP { get; set; }

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Count
		/// Calls [usp_count_Session]
		/// </summary>
		public static Int32 Count() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Session.Count();
		}		/// <summary>
		/// CountForLogin
		/// Calls [usp_count_Session_for_Login]
		/// </summary>
		public static Int32 CountForLogin(System.Int32? loginNo, System.String sessionName) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Session.CountForLogin(loginNo, sessionName);
		}		/// <summary>
		/// Delete
		/// Calls [usp_delete_Session]
		/// </summary>
		public static bool Delete(System.Int32? loginNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Session.Delete(loginNo);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_Session]
		/// </summary>
		public static Session Get(System.Int32? loginNo) {
			Rebound.GlobalTrader.DAL.SessionDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Session.Get(loginNo);
			if (objDetails == null) {
				return null;
			} else {
				Session obj = new Session();
				obj.LoginNo = objDetails.LoginNo;
				obj.SessionName = objDetails.SessionName;
				obj.SessionTimestamp = objDetails.SessionTimestamp;
				obj.StartTime = objDetails.StartTime;
				obj.IPAddress = objDetails.IPAddress;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_Session]
		/// </summary>
		public static List<Session> GetList() {
			List<SessionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Session.GetList();
			if (lstDetails == null) {
				return new List<Session>();
			} else {
				List<Session> lst = new List<Session>();
				foreach (SessionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Session obj = new Rebound.GlobalTrader.BLL.Session();
					obj.LoginNo = objDetails.LoginNo;
					obj.SessionName = objDetails.SessionName;
					obj.SessionTimestamp = objDetails.SessionTimestamp;
					obj.StartTime = objDetails.StartTime;
					obj.IPAddress = objDetails.IPAddress;
					obj.EmployeeName = objDetails.EmployeeName;
                    obj.ServerIP = objDetails.ServerIP;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// UpdateClearOldSessions
		/// Calls [usp_update_Session_ClearOldSessions]
		/// </summary>
		public static bool UpdateClearOldSessions() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Session.UpdateClearOldSessions();
		}

        private static Session PopulateFromDBDetailsObject(SessionDetails obj) {
            Session objNew = new Session();
			objNew.LoginNo = obj.LoginNo;
			objNew.SessionName = obj.SessionName;
			objNew.SessionTimestamp = obj.SessionTimestamp;
			objNew.StartTime = obj.StartTime;
			objNew.IPAddress = obj.IPAddress;
			objNew.EmployeeName = obj.EmployeeName;
            return objNew;
        }
		
		#endregion
		
	}
}