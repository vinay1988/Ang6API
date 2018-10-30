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
		public partial class ToDo : BizObject {
		
		#region Properties

		protected static DAL.ToDoElement Settings {
			get { return Globals.Settings.ToDos; }
		}

		/// <summary>
		/// ToDoId
		/// </summary>
		public System.Int32 ToDoId { get; set; }		
		/// <summary>
		/// LoginNo
		/// </summary>
		public System.Int32? LoginNo { get; set; }		
		/// <summary>
		/// Subject
		/// </summary>
		public System.String Subject { get; set; }		
		/// <summary>
		/// DateAdded
		/// </summary>
		public System.DateTime? DateAdded { get; set; }		
		/// <summary>
		/// DueDate
		/// </summary>
		public System.DateTime? DueDate { get; set; }		
		/// <summary>
		/// ToDoText
		/// </summary>
		public System.String ToDoText { get; set; }		
		/// <summary>
		/// Priority
		/// </summary>
		public System.Int32? Priority { get; set; }		
		/// <summary>
		/// IsComplete
		/// </summary>
		public System.Boolean IsComplete { get; set; }		
		/// <summary>
		/// ReminderDate
		/// </summary>
		public System.DateTime? ReminderDate { get; set; }		
		/// <summary>
		/// ReminderText
		/// </summary>
		public System.String ReminderText { get; set; }		
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32? CompanyNo { get; set; }		
		/// <summary>
		/// ReminderHasBeenNotified
		/// </summary>
		public System.Boolean ReminderHasBeenNotified { get; set; }		
		/// <summary>
		/// RelatedMailMessageNo
		/// </summary>
		public System.Int32? RelatedMailMessageNo { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// LoginName
		/// </summary>
		public System.String LoginName { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_ToDo]
		/// </summary>
		public static bool Delete(System.Int32? toDoId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.ToDo.Delete(toDoId);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_ToDo]
		/// </summary>
		public static Int32 Insert(System.Int32? loginNo, System.String subject, System.DateTime? dateAdded, System.DateTime? dueDate, System.String toDoText, System.Int32? priority, System.Boolean? isComplete, System.DateTime? reminderDate, System.String reminderText, System.Boolean? reminderHasBeenNotified, System.Int32? companyNo, System.Int32? relatedMailMessageNo, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.ToDo.Insert(loginNo, subject, dateAdded, dueDate, toDoText, priority, isComplete, reminderDate, reminderText, reminderHasBeenNotified, companyNo, relatedMailMessageNo, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_ToDo]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.ToDo.Insert(LoginNo, Subject, DateAdded, DueDate, ToDoText, Priority, IsComplete, ReminderDate, ReminderText, ReminderHasBeenNotified, CompanyNo, RelatedMailMessageNo, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_ToDo]
		/// </summary>
		public static ToDo Get(System.Int32? toDoId) {
			Rebound.GlobalTrader.DAL.ToDoDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.ToDo.Get(toDoId);
			if (objDetails == null) {
				return null;
			} else {
				ToDo obj = new ToDo();
				obj.LoginName = objDetails.LoginName;
				obj.ToDoId = objDetails.ToDoId;
				obj.LoginNo = objDetails.LoginNo;
				obj.Subject = objDetails.Subject;
				obj.DateAdded = objDetails.DateAdded;
				obj.DueDate = objDetails.DueDate;
				obj.ToDoText = objDetails.ToDoText;
				obj.Priority = objDetails.Priority;
				obj.IsComplete = objDetails.IsComplete;
				obj.ReminderDate = objDetails.ReminderDate;
				obj.ReminderText = objDetails.ReminderText;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.ReminderHasBeenNotified = objDetails.ReminderHasBeenNotified;
				obj.RelatedMailMessageNo = objDetails.RelatedMailMessageNo;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListAlertForLogin
		/// Calls [usp_selectAll_ToDo_Alert_for_Login]
		/// </summary>
		public static List<ToDo> GetListAlertForLogin(System.Int32? loginNo, System.DateTime? now) {
			List<ToDoDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ToDo.GetListAlertForLogin(loginNo, now);
			if (lstDetails == null) {
				return new List<ToDo>();
			} else {
				List<ToDo> lst = new List<ToDo>();
				foreach (ToDoDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.ToDo obj = new Rebound.GlobalTrader.BLL.ToDo();
					obj.ToDoId = objDetails.ToDoId;
					obj.ReminderText = objDetails.ReminderText;
					obj.DueDate = objDetails.DueDate;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListByLogin
		/// Calls [usp_selectAll_ToDo_by_Login]
		/// </summary>
		public static List<ToDo> GetListByLogin(System.Int32? loginNo) {
			List<ToDoDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ToDo.GetListByLogin(loginNo);
			if (lstDetails == null) {
				return new List<ToDo>();
			} else {
				List<ToDo> lst = new List<ToDo>();
				foreach (ToDoDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.ToDo obj = new Rebound.GlobalTrader.BLL.ToDo();
					obj.LoginName = objDetails.LoginName;
					obj.ToDoId = objDetails.ToDoId;
					obj.LoginNo = objDetails.LoginNo;
					obj.Subject = objDetails.Subject;
					obj.DateAdded = objDetails.DateAdded;
					obj.DueDate = objDetails.DueDate;
					obj.ToDoText = objDetails.ToDoText;
					obj.Priority = objDetails.Priority;
					obj.IsComplete = objDetails.IsComplete;
					obj.ReminderDate = objDetails.ReminderDate;
					obj.ReminderText = objDetails.ReminderText;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.ReminderHasBeenNotified = objDetails.ReminderHasBeenNotified;
					obj.RelatedMailMessageNo = objDetails.RelatedMailMessageNo;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForMailMessage
		/// Calls [usp_selectAll_ToDo_for_MailMessage]
		/// </summary>
		public static List<ToDo> GetListForMailMessage(System.Int32? mailMessageNo) {
			List<ToDoDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ToDo.GetListForMailMessage(mailMessageNo);
			if (lstDetails == null) {
				return new List<ToDo>();
			} else {
				List<ToDo> lst = new List<ToDo>();
				foreach (ToDoDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.ToDo obj = new Rebound.GlobalTrader.BLL.ToDo();
					obj.LoginName = objDetails.LoginName;
					obj.ToDoId = objDetails.ToDoId;
					obj.LoginNo = objDetails.LoginNo;
					obj.Subject = objDetails.Subject;
					obj.DateAdded = objDetails.DateAdded;
					obj.DueDate = objDetails.DueDate;
					obj.ToDoText = objDetails.ToDoText;
					obj.Priority = objDetails.Priority;
					obj.IsComplete = objDetails.IsComplete;
					obj.ReminderDate = objDetails.ReminderDate;
					obj.ReminderText = objDetails.ReminderText;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.ReminderHasBeenNotified = objDetails.ReminderHasBeenNotified;
					obj.RelatedMailMessageNo = objDetails.RelatedMailMessageNo;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_ToDo]
		/// </summary>
		public static bool Update(System.Int32? toDoId, System.Int32? loginNo, System.String subject, System.DateTime? dueDate, System.String toDoText, System.Int32? priority, System.Boolean? isComplete, System.DateTime? reminderDate, System.String reminderText, System.Boolean? reminderHasBeenNotified, System.Int32? companyNo, System.Int32? relatedMailMessageNo, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.ToDo.Update(toDoId, loginNo, subject, dueDate, toDoText, priority, isComplete, reminderDate, reminderText, reminderHasBeenNotified, companyNo, relatedMailMessageNo, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_ToDo]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.ToDo.Update(ToDoId, LoginNo, Subject, DueDate, ToDoText, Priority, IsComplete, ReminderDate, ReminderText, ReminderHasBeenNotified, CompanyNo, RelatedMailMessageNo, UpdatedBy);
		}
		/// <summary>
		/// UpdateComplete
		/// Calls [usp_update_ToDo_Complete]
		/// </summary>
		public static bool UpdateComplete(System.Int32? toDoId, System.Boolean? isComplete, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.ToDo.UpdateComplete(toDoId, isComplete, updatedBy);
		}
		/// <summary>
		/// UpdateDismiss
		/// Calls [usp_update_ToDo_Dismiss]
		/// </summary>
		public static bool UpdateDismiss(System.Int32? toDoId, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.ToDo.UpdateDismiss(toDoId, updatedBy);
		}
		/// <summary>
		/// UpdateSnooze
		/// Calls [usp_update_ToDo_Snooze]
		/// </summary>
		public static bool UpdateSnooze(System.Int32? toDoId, System.Int32? snoozeMinutes, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.ToDo.UpdateSnooze(toDoId, snoozeMinutes, updatedBy);
		}

        private static ToDo PopulateFromDBDetailsObject(ToDoDetails obj) {
            ToDo objNew = new ToDo();
			objNew.ToDoId = obj.ToDoId;
			objNew.LoginNo = obj.LoginNo;
			objNew.Subject = obj.Subject;
			objNew.DateAdded = obj.DateAdded;
			objNew.DueDate = obj.DueDate;
			objNew.ToDoText = obj.ToDoText;
			objNew.Priority = obj.Priority;
			objNew.IsComplete = obj.IsComplete;
			objNew.ReminderDate = obj.ReminderDate;
			objNew.ReminderText = obj.ReminderText;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.ReminderHasBeenNotified = obj.ReminderHasBeenNotified;
			objNew.RelatedMailMessageNo = obj.RelatedMailMessageNo;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.LoginName = obj.LoginName;
            return objNew;
        }
		
		#endregion
		
	}
}