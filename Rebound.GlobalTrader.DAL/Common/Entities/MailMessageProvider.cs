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
	
	public abstract class MailMessageProvider : DataAccess {
		static private MailMessageProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public MailMessageProvider Instance {
			get {
				if (_instance == null) _instance = (MailMessageProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.MailMessages.ProviderType));
				return _instance;
			}
		}
		public MailMessageProvider() {
			this.ConnectionString = Globals.Settings.MailMessages.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// CountNewForRecipient
		/// Calls [usp_count_MailMessage_New_for_Recipient]
		/// </summary>
		public abstract Int32 CountNewForRecipient(System.Int32? toLoginNo);
		/// <summary>
		/// CountNewForRecipientByFolder
		/// Calls [usp_count_MailMessage_New_for_Recipient_by_Folder]
		/// </summary>
		public abstract Int32 CountNewForRecipientByFolder(System.Int32? toLoginNo, System.Int32? mailMessageFolderNo);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_MailMessage]
		/// </summary>
		public abstract bool Delete(System.Int32? mailMessageId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_MailMessage]
		/// </summary>
		public abstract Int32 Insert(System.Int32? fromLoginNo, System.Int32? toLoginNo, System.String subject, System.String body, System.Int32? companyNo, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_MailMessage]
		/// </summary>
		public abstract MailMessageDetails Get(System.Int32? mailMessageId, System.Int32? loginId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_MailMessage]
		/// </summary>
		public abstract List<MailMessageDetails> GetList();
		/// <summary>
		/// GetListForRecipient
		/// Calls [usp_selectAll_MailMessage_for_Recipient]
		/// </summary>
		public abstract List<MailMessageDetails> GetListForRecipient(System.Int32? toLoginNo);
		/// <summary>
		/// GetListForRecipientByFolder
		/// Calls [usp_selectAll_MailMessage_for_Recipient_by_Folder]
		/// </summary>
		public abstract List<MailMessageDetails> GetListForRecipientByFolder(System.Int32? toLoginNo, System.Int32? mailMessageFolderNo);
		/// <summary>
		/// GetListNewAndUnnotifiedForRecipient
		/// Calls [usp_selectAll_MailMessage_New_and_Unnotified_for_Recipient]
		/// </summary>
		public abstract List<MailMessageDetails> GetListNewAndUnnotifiedForRecipient(System.Int32? toLoginNo);
		/// <summary>
		/// GetListSentByRecipient
		/// Calls [usp_selectAll_MailMessage_Sent_by_Recipient]
		/// </summary>
		public abstract List<MailMessageDetails> GetListSentByRecipient(System.Int32? fromLoginNo);
		/// <summary>
		/// UpdateMessageRead
		/// Calls [usp_update_MailMessage_MessageRead]
		/// </summary>
		public abstract bool UpdateMessageRead(System.Int32? mailMessageId);
		/// <summary>
		/// UpdateMoveFolder
		/// Calls [usp_update_MailMessage_Move_Folder]
		/// </summary>
		public abstract bool UpdateMoveFolder(System.Int32? mailMessageId, System.Int32? newFolderNo, System.Int32? updatedBy);
		/// <summary>
		/// UpdateRecipientNotified
		/// Calls [usp_update_MailMessage_RecipientNotified]
		/// </summary>
		public abstract bool UpdateRecipientNotified(System.Int32? toLoginNo);

		#endregion
				
		/// <summary>
		/// Returns a new MailMessageDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual MailMessageDetails GetMailMessageFromReader(DbDataReader reader) {
			MailMessageDetails mailMessage = new MailMessageDetails();
			if (reader.HasRows) {
				mailMessage.MailMessageId = GetReaderValue_Int32(reader, "MailMessageId", 0); //From: [Table]
				mailMessage.MailMessageFolderNo = GetReaderValue_NullableInt32(reader, "MailMessageFolderNo", null); //From: [Table]
				mailMessage.FromLoginNo = GetReaderValue_NullableInt32(reader, "FromLoginNo", null); //From: [Table]
				mailMessage.ToLoginNo = GetReaderValue_NullableInt32(reader, "ToLoginNo", null); //From: [Table]
				mailMessage.Subject = GetReaderValue_String(reader, "Subject", ""); //From: [Table]
				mailMessage.Body = GetReaderValue_String(reader, "Body", ""); //From: [Table]
				mailMessage.DateSent = GetReaderValue_NullableDateTime(reader, "DateSent", null); //From: [Table]
				mailMessage.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null); //From: [usp_list_Activity_by_Client_with_filter]
				mailMessage.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				mailMessage.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null); //From: [Table]
				mailMessage.RecipientHasBeenNotified = GetReaderValue_Boolean(reader, "RecipientHasBeenNotified", false); //From: [Table]
				mailMessage.HasBeenRead = GetReaderValue_Boolean(reader, "HasBeenRead", false); //From: [Table]
				mailMessage.FromLoginName = GetReaderValue_String(reader, "FromLoginName", ""); //From: [usp_select_MailMessage]
				mailMessage.ToLoginName = GetReaderValue_String(reader, "ToLoginName", ""); //From: [usp_select_MailMessage]
				mailMessage.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_list_Activity_by_Client_with_filter]
			}
			return mailMessage;
		}
	
		/// <summary>
		/// Returns a collection of MailMessageDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<MailMessageDetails> GetMailMessageCollectionFromReader(DbDataReader reader) {
			List<MailMessageDetails> mailMessages = new List<MailMessageDetails>();
			while (reader.Read()) mailMessages.Add(GetMailMessageFromReader(reader));
			return mailMessages;
		}
		
		
	}
}