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
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL {
	
	public abstract class TaskStatusProvider : DataAccess {
		static private TaskStatusProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public TaskStatusProvider Instance {
			get {
				if (_instance == null) _instance = (TaskStatusProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.TaskStatuss.ProviderType));
				return _instance;
			}
		}
		public TaskStatusProvider() {
			this.ConnectionString = Globals.Settings.TaskStatuss.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_TaskStatus]
		/// </summary>
		public abstract bool Delete(System.Int32? taskStatusId);
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_TaskStatus]
		/// </summary>
		public abstract List<TaskStatusDetails> DropDown();
		/// <summary>
		/// Insert
		/// Calls [usp_insert_TaskStatus]
		/// </summary>
		public abstract Int32 Insert(System.String name);
		/// <summary>
		/// Get
		/// Calls [usp_select_TaskStatus]
		/// </summary>
		public abstract TaskStatusDetails Get(System.Int32? taskStatusId);
		/// <summary>
		/// Update
		/// Calls [usp_update_TaskStatus]
		/// </summary>
		public abstract bool Update(System.String name, System.Int32? taskStatusId);

		#endregion
				
		/// <summary>
		/// Returns a new TaskStatusDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual TaskStatusDetails GetTaskStatusFromReader(DbDataReader reader) {
			TaskStatusDetails taskStatus = new TaskStatusDetails();
			if (reader.HasRows) {
				taskStatus.TaskStatusId = GetReaderValue_Int32(reader, "TaskStatusId", 0); //From: [Table]
				taskStatus.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
			}
			return taskStatus;
		}
	
		/// <summary>
		/// Returns a collection of TaskStatusDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<TaskStatusDetails> GetTaskStatusCollectionFromReader(DbDataReader reader) {
			List<TaskStatusDetails> taskStatuss = new List<TaskStatusDetails>();
			while (reader.Read()) taskStatuss.Add(GetTaskStatusFromReader(reader));
			return taskStatuss;
		}
		
		
	}
}