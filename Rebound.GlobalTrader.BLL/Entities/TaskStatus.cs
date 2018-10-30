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
		public partial class TaskStatus : BizObject {
		
		#region Properties

		protected static DAL.TaskStatusElement Settings {
			get { return Globals.Settings.TaskStatuss; }
		}

		/// <summary>
		/// TaskStatusId
		/// </summary>
		public System.Int32 TaskStatusId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_TaskStatus]
		/// </summary>
		public static bool Delete(System.Int32? taskStatusId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.TaskStatus.Delete(taskStatusId);
		}
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_TaskStatus]
		/// </summary>
		public static List<TaskStatus> DropDown() {
			List<TaskStatusDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.TaskStatus.DropDown();
			if (lstDetails == null) {
				return new List<TaskStatus>();
			} else {
				List<TaskStatus> lst = new List<TaskStatus>();
				foreach (TaskStatusDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.TaskStatus obj = new Rebound.GlobalTrader.BLL.TaskStatus();
					obj.TaskStatusId = objDetails.TaskStatusId;
					obj.Name = objDetails.Name;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_TaskStatus]
		/// </summary>
		public static Int32 Insert(System.String name) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.TaskStatus.Insert(name);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_TaskStatus]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.TaskStatus.Insert(Name);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_TaskStatus]
		/// </summary>
		public static TaskStatus Get(System.Int32? taskStatusId) {
			Rebound.GlobalTrader.DAL.TaskStatusDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.TaskStatus.Get(taskStatusId);
			if (objDetails == null) {
				return null;
			} else {
				TaskStatus obj = new TaskStatus();
				obj.TaskStatusId = objDetails.TaskStatusId;
				obj.Name = objDetails.Name;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_TaskStatus]
		/// </summary>
		public static bool Update(System.String name, System.Int32? taskStatusId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.TaskStatus.Update(name, taskStatusId);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_TaskStatus]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.TaskStatus.Update(Name, TaskStatusId);
		}

        private static TaskStatus PopulateFromDBDetailsObject(TaskStatusDetails obj) {
            TaskStatus objNew = new TaskStatus();
			objNew.TaskStatusId = obj.TaskStatusId;
			objNew.Name = obj.Name;
            return objNew;
        }
		
		#endregion
		
	}
}