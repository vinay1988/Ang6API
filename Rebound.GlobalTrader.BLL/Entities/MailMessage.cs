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
		public partial class MailMessage : BizObject {
		
		#region Properties

		protected static DAL.MailMessageElement Settings {
			get { return Globals.Settings.MailMessages; }
		}

		/// <summary>
		/// MailMessageId
		/// </summary>
		public System.Int32 MailMessageId { get; set; }		
		/// <summary>
		/// MailMessageFolderNo
		/// </summary>
		public System.Int32? MailMessageFolderNo { get; set; }		
		/// <summary>
		/// FromLoginNo
		/// </summary>
		public System.Int32? FromLoginNo { get; set; }		
		/// <summary>
		/// ToLoginNo
		/// </summary>
		public System.Int32? ToLoginNo { get; set; }		
		/// <summary>
		/// Subject
		/// </summary>
		public System.String Subject { get; set; }		
		/// <summary>
		/// Body
		/// </summary>
		public System.String Body { get; set; }		
		/// <summary>
		/// DateSent
		/// </summary>
		public System.DateTime? DateSent { get; set; }		
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32? CompanyNo { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime? DLUP { get; set; }		
		/// <summary>
		/// RecipientHasBeenNotified
		/// </summary>
		public System.Boolean RecipientHasBeenNotified { get; set; }		
		/// <summary>
		/// HasBeenRead
		/// </summary>
		public System.Boolean HasBeenRead { get; set; }		
		/// <summary>
		/// FromLoginName
		/// </summary>
		public System.String FromLoginName { get; set; }		
		/// <summary>
		/// ToLoginName
		/// </summary>
		public System.String ToLoginName { get; set; }		
		/// <summary>
		/// CompanyName
		/// </summary>
		public System.String CompanyName { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// CountNewForRecipient
		/// Calls [usp_count_MailMessage_New_for_Recipient]
		/// </summary>
		public static Int32 CountNewForRecipient(System.Int32? toLoginNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.MailMessage.CountNewForRecipient(toLoginNo);
		}		/// <summary>
		/// CountNewForRecipientByFolder
		/// Calls [usp_count_MailMessage_New_for_Recipient_by_Folder]
		/// </summary>
		public static Int32 CountNewForRecipientByFolder(System.Int32? toLoginNo, System.Int32? mailMessageFolderNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.MailMessage.CountNewForRecipientByFolder(toLoginNo, mailMessageFolderNo);
		}		/// <summary>
		/// Delete
		/// Calls [usp_delete_MailMessage]
		/// </summary>
		public static bool Delete(System.Int32? mailMessageId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.MailMessage.Delete(mailMessageId);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_MailMessage]
		/// </summary>
		public static Int32 Insert(System.Int32? fromLoginNo, System.Int32? toLoginNo, System.String subject, System.String body, System.Int32? companyNo, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.MailMessage.Insert(fromLoginNo, toLoginNo, subject, body, companyNo, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_MailMessage]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.MailMessage.Insert(FromLoginNo, ToLoginNo, Subject, Body, CompanyNo, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_MailMessage]
		/// </summary>
		public static MailMessage Get(System.Int32? mailMessageId, System.Int32? loginId) {
			Rebound.GlobalTrader.DAL.MailMessageDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.MailMessage.Get(mailMessageId, loginId);
			if (objDetails == null) {
				return null;
			} else {
				MailMessage obj = new MailMessage();
				obj.MailMessageId = objDetails.MailMessageId;
				obj.MailMessageFolderNo = objDetails.MailMessageFolderNo;
				obj.FromLoginNo = objDetails.FromLoginNo;
				obj.ToLoginNo = objDetails.ToLoginNo;
				obj.Subject = objDetails.Subject;
				obj.Body = objDetails.Body;
				obj.DateSent = objDetails.DateSent;
				obj.RecipientHasBeenNotified = objDetails.RecipientHasBeenNotified;
				obj.HasBeenRead = objDetails.HasBeenRead;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.FromLoginName = objDetails.FromLoginName;
				obj.ToLoginName = objDetails.ToLoginName;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_MailMessage]
		/// </summary>
		public static List<MailMessage> GetList() {
			List<MailMessageDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.MailMessage.GetList();
			if (lstDetails == null) {
				return new List<MailMessage>();
			} else {
				List<MailMessage> lst = new List<MailMessage>();
				foreach (MailMessageDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.MailMessage obj = new Rebound.GlobalTrader.BLL.MailMessage();
					obj.MailMessageId = objDetails.MailMessageId;
					obj.MailMessageFolderNo = objDetails.MailMessageFolderNo;
					obj.FromLoginNo = objDetails.FromLoginNo;
					obj.ToLoginNo = objDetails.ToLoginNo;
					obj.Subject = objDetails.Subject;
					obj.Body = objDetails.Body;
					obj.DateSent = objDetails.DateSent;
					obj.RecipientHasBeenNotified = objDetails.RecipientHasBeenNotified;
					obj.HasBeenRead = objDetails.HasBeenRead;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.FromLoginName = objDetails.FromLoginName;
					obj.ToLoginName = objDetails.ToLoginName;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForRecipient
		/// Calls [usp_selectAll_MailMessage_for_Recipient]
		/// </summary>
		public static List<MailMessage> GetListForRecipient(System.Int32? toLoginNo) {
			List<MailMessageDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.MailMessage.GetListForRecipient(toLoginNo);
			if (lstDetails == null) {
				return new List<MailMessage>();
			} else {
				List<MailMessage> lst = new List<MailMessage>();
				foreach (MailMessageDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.MailMessage obj = new Rebound.GlobalTrader.BLL.MailMessage();
					obj.MailMessageId = objDetails.MailMessageId;
					obj.MailMessageFolderNo = objDetails.MailMessageFolderNo;
					obj.FromLoginNo = objDetails.FromLoginNo;
					obj.ToLoginNo = objDetails.ToLoginNo;
					obj.Subject = objDetails.Subject;
					obj.Body = objDetails.Body;
					obj.DateSent = objDetails.DateSent;
					obj.RecipientHasBeenNotified = objDetails.RecipientHasBeenNotified;
					obj.HasBeenRead = objDetails.HasBeenRead;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.FromLoginName = objDetails.FromLoginName;
					obj.ToLoginName = objDetails.ToLoginName;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForRecipientByFolder
		/// Calls [usp_selectAll_MailMessage_for_Recipient_by_Folder]
		/// </summary>
		public static List<MailMessage> GetListForRecipientByFolder(System.Int32? toLoginNo, System.Int32? mailMessageFolderNo) {
			List<MailMessageDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.MailMessage.GetListForRecipientByFolder(toLoginNo, mailMessageFolderNo);
			if (lstDetails == null) {
				return new List<MailMessage>();
			} else {
				List<MailMessage> lst = new List<MailMessage>();
				foreach (MailMessageDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.MailMessage obj = new Rebound.GlobalTrader.BLL.MailMessage();
					obj.MailMessageId = objDetails.MailMessageId;
					obj.MailMessageFolderNo = objDetails.MailMessageFolderNo;
					obj.FromLoginNo = objDetails.FromLoginNo;
					obj.ToLoginNo = objDetails.ToLoginNo;
					obj.Subject = objDetails.Subject;
					obj.Body = objDetails.Body;
					obj.DateSent = objDetails.DateSent;
					obj.RecipientHasBeenNotified = objDetails.RecipientHasBeenNotified;
					obj.HasBeenRead = objDetails.HasBeenRead;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.FromLoginName = objDetails.FromLoginName;
					obj.ToLoginName = objDetails.ToLoginName;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListNewAndUnnotifiedForRecipient
		/// Calls [usp_selectAll_MailMessage_New_and_Unnotified_for_Recipient]
		/// </summary>
		public static List<MailMessage> GetListNewAndUnnotifiedForRecipient(System.Int32? toLoginNo) {
			List<MailMessageDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.MailMessage.GetListNewAndUnnotifiedForRecipient(toLoginNo);
			if (lstDetails == null) {
				return new List<MailMessage>();
			} else {
				List<MailMessage> lst = new List<MailMessage>();
				foreach (MailMessageDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.MailMessage obj = new Rebound.GlobalTrader.BLL.MailMessage();
					obj.MailMessageId = objDetails.MailMessageId;
					obj.FromLoginName = objDetails.FromLoginName;
					obj.Subject = objDetails.Subject;
					obj.DateSent = objDetails.DateSent;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListSentByRecipient
		/// Calls [usp_selectAll_MailMessage_Sent_by_Recipient]
		/// </summary>
		public static List<MailMessage> GetListSentByRecipient(System.Int32? fromLoginNo) {
			List<MailMessageDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.MailMessage.GetListSentByRecipient(fromLoginNo);
			if (lstDetails == null) {
				return new List<MailMessage>();
			} else {
				List<MailMessage> lst = new List<MailMessage>();
				foreach (MailMessageDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.MailMessage obj = new Rebound.GlobalTrader.BLL.MailMessage();
					obj.MailMessageId = objDetails.MailMessageId;
					obj.MailMessageFolderNo = objDetails.MailMessageFolderNo;
					obj.FromLoginNo = objDetails.FromLoginNo;
					obj.ToLoginNo = objDetails.ToLoginNo;
					obj.Subject = objDetails.Subject;
					obj.Body = objDetails.Body;
					obj.DateSent = objDetails.DateSent;
					obj.RecipientHasBeenNotified = objDetails.RecipientHasBeenNotified;
					obj.HasBeenRead = objDetails.HasBeenRead;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.FromLoginName = objDetails.FromLoginName;
					obj.ToLoginName = objDetails.ToLoginName;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// UpdateMessageRead
		/// Calls [usp_update_MailMessage_MessageRead]
		/// </summary>
		public static bool UpdateMessageRead(System.Int32? mailMessageId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.MailMessage.UpdateMessageRead(mailMessageId);
		}
		/// <summary>
		/// UpdateMoveFolder
		/// Calls [usp_update_MailMessage_Move_Folder]
		/// </summary>
		public static bool UpdateMoveFolder(System.Int32? mailMessageId, System.Int32? newFolderNo, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.MailMessage.UpdateMoveFolder(mailMessageId, newFolderNo, updatedBy);
		}
		/// <summary>
		/// UpdateRecipientNotified
		/// Calls [usp_update_MailMessage_RecipientNotified]
		/// </summary>
		public static bool UpdateRecipientNotified(System.Int32? toLoginNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.MailMessage.UpdateRecipientNotified(toLoginNo);
		}

        private static MailMessage PopulateFromDBDetailsObject(MailMessageDetails obj) {
            MailMessage objNew = new MailMessage();
			objNew.MailMessageId = obj.MailMessageId;
			objNew.MailMessageFolderNo = obj.MailMessageFolderNo;
			objNew.FromLoginNo = obj.FromLoginNo;
			objNew.ToLoginNo = obj.ToLoginNo;
			objNew.Subject = obj.Subject;
			objNew.Body = obj.Body;
			objNew.DateSent = obj.DateSent;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.RecipientHasBeenNotified = obj.RecipientHasBeenNotified;
			objNew.HasBeenRead = obj.HasBeenRead;
			objNew.FromLoginName = obj.FromLoginName;
			objNew.ToLoginName = obj.ToLoginName;
			objNew.CompanyName = obj.CompanyName;
            return objNew;
        }
		
		#endregion
		
	}
}