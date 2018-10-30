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
	
	public abstract class MailGroupMemberProvider : DataAccess {
		static private MailGroupMemberProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public MailGroupMemberProvider Instance {
			get {
				if (_instance == null) _instance = (MailGroupMemberProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.MailGroupMembers.ProviderType));
				return _instance;
			}
		}
		public MailGroupMemberProvider() {
			this.ConnectionString = Globals.Settings.MailGroupMembers.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_MailGroupMember]
		/// </summary>
		public abstract bool Delete(System.Int32? mailGroupNo, System.Int32? loginNo);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_MailGroupMember]
		/// </summary>
		public abstract Int32 Insert(System.Int32? mailGroupNo, System.Int32? loginNo);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_MailGroupMember]
		/// </summary>
		public abstract List<MailGroupMemberDetails> GetList(System.Int32? mailGroupMemberId);
		/// <summary>
		/// GetListByGroup
		/// Calls [usp_selectAll_MailGroupMember_by_Group]
		/// </summary>
		public abstract List<MailGroupMemberDetails> GetListByGroup(System.Int32? mailGroupNo);

        /// <summary>
        /// GetListByGroup
        /// Calls [[usp_selectAll_MailGroupMember_by_GroupName]]
        /// </summary>
        public abstract List<MailGroupMemberDetails> GetEmailListByGroup(System.String mailGroupName);
		#endregion
				
		/// <summary>
		/// Returns a new MailGroupMemberDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual MailGroupMemberDetails GetMailGroupMemberFromReader(DbDataReader reader) {
			MailGroupMemberDetails mailGroupMember = new MailGroupMemberDetails();
			if (reader.HasRows) {
				mailGroupMember.MailGroupMemberId = GetReaderValue_Int32(reader, "MailGroupMemberId", 0); //From: [Table]
				mailGroupMember.MailGroupNo = GetReaderValue_Int32(reader, "MailGroupNo", 0); //From: [Table]
				mailGroupMember.LoginNo = GetReaderValue_Int32(reader, "LoginNo", 0); //From: [Table]
				mailGroupMember.EmployeeName = GetReaderValue_String(reader, "EmployeeName", ""); //From: [usp_selectAll_Audit_authorisation_for_SalesOrder]
			}
			return mailGroupMember;
		}
	
		/// <summary>
		/// Returns a collection of MailGroupMemberDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<MailGroupMemberDetails> GetMailGroupMemberCollectionFromReader(DbDataReader reader) {
			List<MailGroupMemberDetails> mailGroupMembers = new List<MailGroupMemberDetails>();
			while (reader.Read()) mailGroupMembers.Add(GetMailGroupMemberFromReader(reader));
			return mailGroupMembers;
		}
		
		
	}
}