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
	public class SqlMailMessageProvider : MailMessageProvider {
		/// <summary>
		/// Count MailMessage
		/// Calls [usp_count_MailMessage_New_for_Recipient]
		/// </summary>
		public override Int32 CountNewForRecipient(System.Int32? toLoginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_MailMessage_New_for_Recipient", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ToLoginNo", SqlDbType.Int).Value = toLoginNo;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count MailMessage", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Count MailMessage
		/// Calls [usp_count_MailMessage_New_for_Recipient_by_Folder]
		/// </summary>
		public override Int32 CountNewForRecipientByFolder(System.Int32? toLoginNo, System.Int32? mailMessageFolderNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_MailMessage_New_for_Recipient_by_Folder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ToLoginNo", SqlDbType.Int).Value = toLoginNo;
				cmd.Parameters.Add("@MailMessageFolderNo", SqlDbType.Int).Value = mailMessageFolderNo;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count MailMessage", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete MailMessage
		/// Calls [usp_delete_MailMessage]
		/// </summary>
		public override bool Delete(System.Int32? mailMessageId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_MailMessage", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@MailMessageId", SqlDbType.Int).Value = mailMessageId;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete MailMessage", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_MailMessage]
		/// </summary>
		public override Int32 Insert(System.Int32? fromLoginNo, System.Int32? toLoginNo, System.String subject, System.String body, System.Int32? companyNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_MailMessage", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@FromLoginNo", SqlDbType.Int).Value = fromLoginNo;
				cmd.Parameters.Add("@ToLoginNo", SqlDbType.Int).Value = toLoginNo;
				cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = subject;
				cmd.Parameters.Add("@Body", SqlDbType.NVarChar).Value = body;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@MailMessageId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@MailMessageId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert MailMessage", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_MailMessage]
        /// </summary>
		public override MailMessageDetails Get(System.Int32? mailMessageId, System.Int32? loginId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_MailMessage", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@MailMessageId", SqlDbType.Int).Value = mailMessageId;
				cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetMailMessageFromReader(reader);
					MailMessageDetails obj = new MailMessageDetails();
					obj.MailMessageId = GetReaderValue_Int32(reader, "MailMessageId", 0);
					obj.MailMessageFolderNo = GetReaderValue_NullableInt32(reader, "MailMessageFolderNo", null);
					obj.FromLoginNo = GetReaderValue_NullableInt32(reader, "FromLoginNo", null);
					obj.ToLoginNo = GetReaderValue_NullableInt32(reader, "ToLoginNo", null);
					obj.Subject = GetReaderValue_String(reader, "Subject", "");
					obj.Body = GetReaderValue_String(reader, "Body", "");
					obj.DateSent = GetReaderValue_NullableDateTime(reader, "DateSent", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
					obj.RecipientHasBeenNotified = GetReaderValue_Boolean(reader, "RecipientHasBeenNotified", false);
					obj.HasBeenRead = GetReaderValue_Boolean(reader, "HasBeenRead", false);
					obj.FromLoginName = GetReaderValue_String(reader, "FromLoginName", "");
					obj.ToLoginName = GetReaderValue_String(reader, "ToLoginName", "");
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get MailMessage", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_MailMessage]
        /// </summary>
		public override List<MailMessageDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_MailMessage", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<MailMessageDetails> lst = new List<MailMessageDetails>();
				while (reader.Read()) {
					MailMessageDetails obj = new MailMessageDetails();
					obj.MailMessageId = GetReaderValue_Int32(reader, "MailMessageId", 0);
					obj.MailMessageFolderNo = GetReaderValue_NullableInt32(reader, "MailMessageFolderNo", null);
					obj.FromLoginNo = GetReaderValue_NullableInt32(reader, "FromLoginNo", null);
					obj.ToLoginNo = GetReaderValue_NullableInt32(reader, "ToLoginNo", null);
					obj.Subject = GetReaderValue_String(reader, "Subject", "");
					obj.Body = GetReaderValue_String(reader, "Body", "");
					obj.DateSent = GetReaderValue_NullableDateTime(reader, "DateSent", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
					obj.RecipientHasBeenNotified = GetReaderValue_Boolean(reader, "RecipientHasBeenNotified", false);
					obj.HasBeenRead = GetReaderValue_Boolean(reader, "HasBeenRead", false);
					obj.FromLoginName = GetReaderValue_String(reader, "FromLoginName", "");
					obj.ToLoginName = GetReaderValue_String(reader, "ToLoginName", "");
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get MailMessages", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForRecipient 
		/// Calls [usp_selectAll_MailMessage_for_Recipient]
        /// </summary>
		public override List<MailMessageDetails> GetListForRecipient(System.Int32? toLoginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_MailMessage_for_Recipient", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ToLoginNo", SqlDbType.Int).Value = toLoginNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<MailMessageDetails> lst = new List<MailMessageDetails>();
				while (reader.Read()) {
					MailMessageDetails obj = new MailMessageDetails();
					obj.MailMessageId = GetReaderValue_Int32(reader, "MailMessageId", 0);
					obj.MailMessageFolderNo = GetReaderValue_NullableInt32(reader, "MailMessageFolderNo", null);
					obj.FromLoginNo = GetReaderValue_NullableInt32(reader, "FromLoginNo", null);
					obj.ToLoginNo = GetReaderValue_NullableInt32(reader, "ToLoginNo", null);
					obj.Subject = GetReaderValue_String(reader, "Subject", "");
					obj.Body = GetReaderValue_String(reader, "Body", "");
					obj.DateSent = GetReaderValue_NullableDateTime(reader, "DateSent", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
					obj.RecipientHasBeenNotified = GetReaderValue_Boolean(reader, "RecipientHasBeenNotified", false);
					obj.HasBeenRead = GetReaderValue_Boolean(reader, "HasBeenRead", false);
					obj.FromLoginName = GetReaderValue_String(reader, "FromLoginName", "");
					obj.ToLoginName = GetReaderValue_String(reader, "ToLoginName", "");
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get MailMessages", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForRecipientByFolder 
		/// Calls [usp_selectAll_MailMessage_for_Recipient_by_Folder]
        /// </summary>
		public override List<MailMessageDetails> GetListForRecipientByFolder(System.Int32? toLoginNo, System.Int32? mailMessageFolderNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_MailMessage_for_Recipient_by_Folder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ToLoginNo", SqlDbType.Int).Value = toLoginNo;
				cmd.Parameters.Add("@MailMessageFolderNo", SqlDbType.Int).Value = mailMessageFolderNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<MailMessageDetails> lst = new List<MailMessageDetails>();
				while (reader.Read()) {
					MailMessageDetails obj = new MailMessageDetails();
					obj.MailMessageId = GetReaderValue_Int32(reader, "MailMessageId", 0);
					obj.MailMessageFolderNo = GetReaderValue_NullableInt32(reader, "MailMessageFolderNo", null);
					obj.FromLoginNo = GetReaderValue_NullableInt32(reader, "FromLoginNo", null);
					obj.ToLoginNo = GetReaderValue_NullableInt32(reader, "ToLoginNo", null);
					obj.Subject = GetReaderValue_String(reader, "Subject", "");
					obj.Body = GetReaderValue_String(reader, "Body", "");
					obj.DateSent = GetReaderValue_NullableDateTime(reader, "DateSent", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
					obj.RecipientHasBeenNotified = GetReaderValue_Boolean(reader, "RecipientHasBeenNotified", false);
					obj.HasBeenRead = GetReaderValue_Boolean(reader, "HasBeenRead", false);
					obj.FromLoginName = GetReaderValue_String(reader, "FromLoginName", "");
					obj.ToLoginName = GetReaderValue_String(reader, "ToLoginName", "");
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get MailMessages", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListNewAndUnnotifiedForRecipient 
		/// Calls [usp_selectAll_MailMessage_New_and_Unnotified_for_Recipient]
        /// </summary>
		public override List<MailMessageDetails> GetListNewAndUnnotifiedForRecipient(System.Int32? toLoginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_MailMessage_New_and_Unnotified_for_Recipient", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ToLoginNo", SqlDbType.Int).Value = toLoginNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<MailMessageDetails> lst = new List<MailMessageDetails>();
				while (reader.Read()) {
					MailMessageDetails obj = new MailMessageDetails();
					obj.MailMessageId = GetReaderValue_Int32(reader, "MailMessageId", 0);
					obj.Subject = GetReaderValue_String(reader, "Subject", "");
					obj.DateSent = GetReaderValue_NullableDateTime(reader, "DateSent", null);
					obj.FromLoginName = GetReaderValue_String(reader, "FromLoginName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get MailMessages", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListSentByRecipient 
		/// Calls [usp_selectAll_MailMessage_Sent_by_Recipient]
        /// </summary>
		public override List<MailMessageDetails> GetListSentByRecipient(System.Int32? fromLoginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_MailMessage_Sent_by_Recipient", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@FromLoginNo", SqlDbType.Int).Value = fromLoginNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<MailMessageDetails> lst = new List<MailMessageDetails>();
				while (reader.Read()) {
					MailMessageDetails obj = new MailMessageDetails();
					obj.MailMessageId = GetReaderValue_Int32(reader, "MailMessageId", 0);
					obj.MailMessageFolderNo = GetReaderValue_NullableInt32(reader, "MailMessageFolderNo", null);
					obj.FromLoginNo = GetReaderValue_NullableInt32(reader, "FromLoginNo", null);
					obj.ToLoginNo = GetReaderValue_NullableInt32(reader, "ToLoginNo", null);
					obj.Subject = GetReaderValue_String(reader, "Subject", "");
					obj.Body = GetReaderValue_String(reader, "Body", "");
					obj.DateSent = GetReaderValue_NullableDateTime(reader, "DateSent", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
					obj.RecipientHasBeenNotified = GetReaderValue_Boolean(reader, "RecipientHasBeenNotified", false);
					obj.HasBeenRead = GetReaderValue_Boolean(reader, "HasBeenRead", false);
					obj.FromLoginName = GetReaderValue_String(reader, "FromLoginName", "");
					obj.ToLoginName = GetReaderValue_String(reader, "ToLoginName", "");
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get MailMessages", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update MailMessage
		/// Calls [usp_update_MailMessage_MessageRead]
        /// </summary>
		public override bool UpdateMessageRead(System.Int32? mailMessageId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_MailMessage_MessageRead", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@MailMessageId", SqlDbType.Int).Value = mailMessageId;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update MailMessage", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update MailMessage
		/// Calls [usp_update_MailMessage_Move_Folder]
        /// </summary>
		public override bool UpdateMoveFolder(System.Int32? mailMessageId, System.Int32? newFolderNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_MailMessage_Move_Folder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@MailMessageId", SqlDbType.Int).Value = mailMessageId;
				cmd.Parameters.Add("@NewFolderNo", SqlDbType.Int).Value = newFolderNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update MailMessage", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update MailMessage
		/// Calls [usp_update_MailMessage_RecipientNotified]
        /// </summary>
		public override bool UpdateRecipientNotified(System.Int32? toLoginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_MailMessage_RecipientNotified", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ToLoginNo", SqlDbType.Int).Value = toLoginNo;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update MailMessage", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}