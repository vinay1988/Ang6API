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
	
	public abstract class MailGroupProvider : DataAccess {
		static private MailGroupProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public MailGroupProvider Instance {
			get {
				if (_instance == null) _instance = (MailGroupProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.MailGroups.ProviderType));
				return _instance;
			}
		}
		public MailGroupProvider() {
			this.ConnectionString = Globals.Settings.MailGroups.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_MailGroup]
		/// </summary>
		public abstract bool Delete(System.Int32? mailGroupId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_MailGroup]
		/// </summary>
		public abstract Int32 Insert(System.Int32? loginNo, System.Int32? clientNo, System.String name, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_MailGroup]
		/// </summary>
		public abstract MailGroupDetails Get(System.Int32? mailGroupNo);
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_MailGroup_for_Client]
		/// </summary>
		public abstract List<MailGroupDetails> GetListForClient(System.Int32? clientNo);
		/// <summary>
		/// GetListForLogin
		/// Calls [usp_selectAll_MailGroup_for_Login]
		/// </summary>
		public abstract List<MailGroupDetails> GetListForLogin(System.Int32? loginNo);
		/// <summary>
		/// Update
		/// Calls [usp_update_MailGroup]
		/// </summary>
		public abstract bool Update(System.Int32? mailGroupId, System.Int32? loginNo, System.Int32? clientNo, System.String name, System.Int32? updatedBy);

        public abstract int? GetQualityMailGroupNo(System.Int32? clientNo);

		#endregion
				
		/// <summary>
		/// Returns a new MailGroupDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual MailGroupDetails GetMailGroupFromReader(DbDataReader reader) {
			MailGroupDetails mailGroup = new MailGroupDetails();
			if (reader.HasRows) {
				mailGroup.MailGroupId = GetReaderValue_Int32(reader, "MailGroupId", 0); //From: [Table]
				mailGroup.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
				mailGroup.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				mailGroup.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null); //From: [Table]
				mailGroup.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null); //From: [Table]
				mailGroup.LoginNo = GetReaderValue_NullableInt32(reader, "LoginNo", null); //From: [Table]
				mailGroup.NumberOfMembers = GetReaderValue_NullableInt32(reader, "NumberOfMembers", null); //From: [usp_selectAll_Division_for_Client]
			}
			return mailGroup;
		}
	
		/// <summary>
		/// Returns a collection of MailGroupDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<MailGroupDetails> GetMailGroupCollectionFromReader(DbDataReader reader) {
			List<MailGroupDetails> mailGroups = new List<MailGroupDetails>();
			while (reader.Read()) mailGroups.Add(GetMailGroupFromReader(reader));
			return mailGroups;
		}
		
		
	}
}