using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.Caching;
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL.SqlClient {
	public class SqlToDoProvider : ToDoProvider {
		/// <summary>
		/// Delete ToDo
		/// Calls [usp_delete_ToDo]
		/// </summary>
		public override bool Delete(System.Int32? toDoId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_ToDo", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ToDoId", SqlDbType.Int).Value = toDoId;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete ToDo", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_ToDo]
		/// </summary>
		public override Int32 Insert(System.Int32? loginNo, System.String subject, System.DateTime? dateAdded, System.DateTime? dueDate, System.String toDoText, System.Int32? priority, System.Boolean? isComplete, System.DateTime? reminderDate, System.String reminderText, System.Boolean? reminderHasBeenNotified, System.Int32? companyNo, System.Int32? relatedMailMessageNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_ToDo", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = subject;
				cmd.Parameters.Add("@DateAdded", SqlDbType.DateTime).Value = dateAdded;
				cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = dueDate;
				cmd.Parameters.Add("@ToDoText", SqlDbType.NVarChar).Value = toDoText;
				cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = priority;
				cmd.Parameters.Add("@IsComplete", SqlDbType.Bit).Value = isComplete;
				cmd.Parameters.Add("@ReminderDate", SqlDbType.DateTime).Value = reminderDate;
				cmd.Parameters.Add("@ReminderText", SqlDbType.NVarChar).Value = reminderText;
				cmd.Parameters.Add("@ReminderHasBeenNotified", SqlDbType.Bit).Value = reminderHasBeenNotified;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@RelatedMailMessageNo", SqlDbType.Int).Value = relatedMailMessageNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@ToDoId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@ToDoId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert ToDo", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_ToDo]
        /// </summary>
		public override ToDoDetails Get(System.Int32? toDoId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_ToDo", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ToDoId", SqlDbType.Int).Value = toDoId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetToDoFromReader(reader);
					ToDoDetails obj = new ToDoDetails();
					obj.ToDoId = GetReaderValue_Int32(reader, "ToDoId", 0);
					obj.LoginNo = GetReaderValue_NullableInt32(reader, "LoginNo", null);
					obj.Subject = GetReaderValue_String(reader, "Subject", "");
					obj.DateAdded = GetReaderValue_NullableDateTime(reader, "DateAdded", null);
					obj.DueDate = GetReaderValue_NullableDateTime(reader, "DueDate", null);
					obj.ToDoText = GetReaderValue_String(reader, "ToDoText", "");
					obj.Priority = GetReaderValue_NullableInt32(reader, "Priority", null);
					obj.IsComplete = GetReaderValue_Boolean(reader, "IsComplete", false);
					obj.ReminderDate = GetReaderValue_NullableDateTime(reader, "ReminderDate", null);
					obj.ReminderText = GetReaderValue_String(reader, "ReminderText", "");
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.ReminderHasBeenNotified = GetReaderValue_Boolean(reader, "ReminderHasBeenNotified", false);
					obj.RelatedMailMessageNo = GetReaderValue_NullableInt32(reader, "RelatedMailMessageNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.LoginName = GetReaderValue_String(reader, "LoginName", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ToDo", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListAlertForLogin 
		/// Calls [usp_selectAll_ToDo_Alert_for_Login]
        /// </summary>
		public override List<ToDoDetails> GetListAlertForLogin(System.Int32? loginNo, System.DateTime? now) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_ToDo_Alert_for_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@Now", SqlDbType.DateTime).Value = now;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ToDoDetails> lst = new List<ToDoDetails>();
				while (reader.Read()) {
					ToDoDetails obj = new ToDoDetails();
					obj.ToDoId = GetReaderValue_Int32(reader, "ToDoId", 0);
					obj.DueDate = GetReaderValue_NullableDateTime(reader, "DueDate", null);
					obj.ReminderText = GetReaderValue_String(reader, "ReminderText", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ToDos", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListByLogin 
		/// Calls [usp_selectAll_ToDo_by_Login]
        /// </summary>
		public override List<ToDoDetails> GetListByLogin(System.Int32? loginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_ToDo_by_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ToDoDetails> lst = new List<ToDoDetails>();
				while (reader.Read()) {
					ToDoDetails obj = new ToDoDetails();
					obj.ToDoId = GetReaderValue_Int32(reader, "ToDoId", 0);
					obj.LoginNo = GetReaderValue_NullableInt32(reader, "LoginNo", null);
					obj.Subject = GetReaderValue_String(reader, "Subject", "");
					obj.DateAdded = GetReaderValue_NullableDateTime(reader, "DateAdded", null);
					obj.DueDate = GetReaderValue_NullableDateTime(reader, "DueDate", null);
					obj.ToDoText = GetReaderValue_String(reader, "ToDoText", "");
					obj.Priority = GetReaderValue_NullableInt32(reader, "Priority", null);
					obj.IsComplete = GetReaderValue_Boolean(reader, "IsComplete", false);
					obj.ReminderDate = GetReaderValue_NullableDateTime(reader, "ReminderDate", null);
					obj.ReminderText = GetReaderValue_String(reader, "ReminderText", "");
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.ReminderHasBeenNotified = GetReaderValue_Boolean(reader, "ReminderHasBeenNotified", false);
					obj.RelatedMailMessageNo = GetReaderValue_NullableInt32(reader, "RelatedMailMessageNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.LoginName = GetReaderValue_String(reader, "LoginName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ToDos", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForMailMessage 
		/// Calls [usp_selectAll_ToDo_for_MailMessage]
        /// </summary>
		public override List<ToDoDetails> GetListForMailMessage(System.Int32? mailMessageNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_ToDo_for_MailMessage", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@MailMessageNo", SqlDbType.Int).Value = mailMessageNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ToDoDetails> lst = new List<ToDoDetails>();
				while (reader.Read()) {
					ToDoDetails obj = new ToDoDetails();
					obj.ToDoId = GetReaderValue_Int32(reader, "ToDoId", 0);
					obj.LoginNo = GetReaderValue_NullableInt32(reader, "LoginNo", null);
					obj.Subject = GetReaderValue_String(reader, "Subject", "");
					obj.DateAdded = GetReaderValue_NullableDateTime(reader, "DateAdded", null);
					obj.DueDate = GetReaderValue_NullableDateTime(reader, "DueDate", null);
					obj.ToDoText = GetReaderValue_String(reader, "ToDoText", "");
					obj.Priority = GetReaderValue_NullableInt32(reader, "Priority", null);
					obj.IsComplete = GetReaderValue_Boolean(reader, "IsComplete", false);
					obj.ReminderDate = GetReaderValue_NullableDateTime(reader, "ReminderDate", null);
					obj.ReminderText = GetReaderValue_String(reader, "ReminderText", "");
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.ReminderHasBeenNotified = GetReaderValue_Boolean(reader, "ReminderHasBeenNotified", false);
					obj.RelatedMailMessageNo = GetReaderValue_NullableInt32(reader, "RelatedMailMessageNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.LoginName = GetReaderValue_String(reader, "LoginName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ToDos", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update ToDo
		/// Calls [usp_update_ToDo]
        /// </summary>
		public override bool Update(System.Int32? toDoId, System.Int32? loginNo, System.String subject, System.DateTime? dueDate, System.String toDoText, System.Int32? priority, System.Boolean? isComplete, System.DateTime? reminderDate, System.String reminderText, System.Boolean? reminderHasBeenNotified, System.Int32? companyNo, System.Int32? relatedMailMessageNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_ToDo", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ToDoId", SqlDbType.Int).Value = toDoId;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = subject;
				cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = dueDate;
				cmd.Parameters.Add("@ToDoText", SqlDbType.NVarChar).Value = toDoText;
				cmd.Parameters.Add("@Priority", SqlDbType.Int).Value = priority;
				cmd.Parameters.Add("@IsComplete", SqlDbType.Bit).Value = isComplete;
				cmd.Parameters.Add("@ReminderDate", SqlDbType.DateTime).Value = reminderDate;
				cmd.Parameters.Add("@ReminderText", SqlDbType.NVarChar).Value = reminderText;
				cmd.Parameters.Add("@ReminderHasBeenNotified", SqlDbType.Bit).Value = reminderHasBeenNotified;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@RelatedMailMessageNo", SqlDbType.Int).Value = relatedMailMessageNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update ToDo", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update ToDo
		/// Calls [usp_update_ToDo_Complete]
        /// </summary>
		public override bool UpdateComplete(System.Int32? toDoId, System.Boolean? isComplete, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_ToDo_Complete", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ToDoId", SqlDbType.Int).Value = toDoId;
				cmd.Parameters.Add("@IsComplete", SqlDbType.Bit).Value = isComplete;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update ToDo", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update ToDo
		/// Calls [usp_update_ToDo_Dismiss]
        /// </summary>
		public override bool UpdateDismiss(System.Int32? toDoId, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_ToDo_Dismiss", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ToDoId", SqlDbType.Int).Value = toDoId;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update ToDo", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update ToDo
		/// Calls [usp_update_ToDo_Snooze]
        /// </summary>
		public override bool UpdateSnooze(System.Int32? toDoId, System.Int32? snoozeMinutes, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_ToDo_Snooze", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ToDoId", SqlDbType.Int).Value = toDoId;
				cmd.Parameters.Add("@SnoozeMinutes", SqlDbType.Int).Value = snoozeMinutes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update ToDo", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}