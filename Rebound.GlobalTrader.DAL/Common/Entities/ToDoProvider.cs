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
	
	public abstract class ToDoProvider : DataAccess {
		static private ToDoProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ToDoProvider Instance {
			get {
				if (_instance == null) _instance = (ToDoProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.ToDos.ProviderType));
				return _instance;
			}
		}
		public ToDoProvider() {
			this.ConnectionString = Globals.Settings.ToDos.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_ToDo]
		/// </summary>
		public abstract bool Delete(System.Int32? toDoId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_ToDo]
		/// </summary>
		public abstract Int32 Insert(System.Int32? loginNo, System.String subject, System.DateTime? dateAdded, System.DateTime? dueDate, System.String toDoText, System.Int32? priority, System.Boolean? isComplete, System.DateTime? reminderDate, System.String reminderText, System.Boolean? reminderHasBeenNotified, System.Int32? companyNo, System.Int32? relatedMailMessageNo, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_ToDo]
		/// </summary>
		public abstract ToDoDetails Get(System.Int32? toDoId);
		/// <summary>
		/// GetListAlertForLogin
		/// Calls [usp_selectAll_ToDo_Alert_for_Login]
		/// </summary>
		public abstract List<ToDoDetails> GetListAlertForLogin(System.Int32? loginNo, System.DateTime? now);
		/// <summary>
		/// GetListByLogin
		/// Calls [usp_selectAll_ToDo_by_Login]
		/// </summary>
		public abstract List<ToDoDetails> GetListByLogin(System.Int32? loginNo);
		/// <summary>
		/// GetListForMailMessage
		/// Calls [usp_selectAll_ToDo_for_MailMessage]
		/// </summary>
		public abstract List<ToDoDetails> GetListForMailMessage(System.Int32? mailMessageNo);
		/// <summary>
		/// Update
		/// Calls [usp_update_ToDo]
		/// </summary>
		public abstract bool Update(System.Int32? toDoId, System.Int32? loginNo, System.String subject, System.DateTime? dueDate, System.String toDoText, System.Int32? priority, System.Boolean? isComplete, System.DateTime? reminderDate, System.String reminderText, System.Boolean? reminderHasBeenNotified, System.Int32? companyNo, System.Int32? relatedMailMessageNo, System.Int32? updatedBy);
		/// <summary>
		/// UpdateComplete
		/// Calls [usp_update_ToDo_Complete]
		/// </summary>
		public abstract bool UpdateComplete(System.Int32? toDoId, System.Boolean? isComplete, System.Int32? updatedBy);
		/// <summary>
		/// UpdateDismiss
		/// Calls [usp_update_ToDo_Dismiss]
		/// </summary>
		public abstract bool UpdateDismiss(System.Int32? toDoId, System.Int32? updatedBy);
		/// <summary>
		/// UpdateSnooze
		/// Calls [usp_update_ToDo_Snooze]
		/// </summary>
		public abstract bool UpdateSnooze(System.Int32? toDoId, System.Int32? snoozeMinutes, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new ToDoDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ToDoDetails GetToDoFromReader(DbDataReader reader) {
			ToDoDetails toDo = new ToDoDetails();
			if (reader.HasRows) {
				toDo.ToDoId = GetReaderValue_Int32(reader, "ToDoId", 0); //From: [Table]
				toDo.LoginNo = GetReaderValue_NullableInt32(reader, "LoginNo", null); //From: [Table]
				toDo.Subject = GetReaderValue_String(reader, "Subject", ""); //From: [Table]
				toDo.DateAdded = GetReaderValue_NullableDateTime(reader, "DateAdded", null); //From: [Table]
				toDo.DueDate = GetReaderValue_NullableDateTime(reader, "DueDate", null); //From: [Table]
				toDo.ToDoText = GetReaderValue_String(reader, "ToDoText", ""); //From: [Table]
				toDo.Priority = GetReaderValue_NullableInt32(reader, "Priority", null); //From: [Table]
				toDo.IsComplete = GetReaderValue_Boolean(reader, "IsComplete", false); //From: [Table]
				toDo.ReminderDate = GetReaderValue_NullableDateTime(reader, "ReminderDate", null); //From: [Table]
				toDo.ReminderText = GetReaderValue_String(reader, "ReminderText", ""); //From: [Table]
				toDo.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null); //From: [usp_list_Activity_by_Client_with_filter]
				toDo.ReminderHasBeenNotified = GetReaderValue_Boolean(reader, "ReminderHasBeenNotified", false); //From: [Table]
				toDo.RelatedMailMessageNo = GetReaderValue_NullableInt32(reader, "RelatedMailMessageNo", null); //From: [Table]
				toDo.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				toDo.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				toDo.LoginName = GetReaderValue_String(reader, "LoginName", ""); //From: [Table]
			}
			return toDo;
		}
	
		/// <summary>
		/// Returns a collection of ToDoDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ToDoDetails> GetToDoCollectionFromReader(DbDataReader reader) {
			List<ToDoDetails> toDos = new List<ToDoDetails>();
			while (reader.Read()) toDos.Add(GetToDoFromReader(reader));
			return toDos;
		}
		
		
	}
}