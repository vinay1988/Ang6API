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
	
	public abstract class MailMessageFolderProvider : DataAccess {
		static private MailMessageFolderProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public MailMessageFolderProvider Instance {
			get {
				if (_instance == null) _instance = (MailMessageFolderProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.MailMessageFolders.ProviderType));
				return _instance;
			}
		}
		public MailMessageFolderProvider() {
			this.ConnectionString = Globals.Settings.MailMessageFolders.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_MailMessageFolder]
		/// </summary>
		public abstract bool Delete(System.Int32? mailMessageFolderNo);
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_MailMessageFolder]
		/// </summary>
		public abstract List<MailMessageFolderDetails> DropDown(System.Int32? loginNo);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_MailMessageFolder]
		/// </summary>
		public abstract Int32 Insert(System.Int32? loginNo, System.String name, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_MailMessageFolder]
		/// </summary>
		public abstract MailMessageFolderDetails Get(System.Int32? mailMessageFolderId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_MailMessageFolder]
		/// </summary>
		public abstract List<MailMessageFolderDetails> GetList();
		/// <summary>
		/// GetListForLogin
		/// Calls [usp_selectAll_MailMessageFolder_for_Login]
		/// </summary>
		public abstract List<MailMessageFolderDetails> GetListForLogin(System.Int32? loginNo);
		/// <summary>
		/// Update
		/// Calls [usp_update_MailMessageFolder]
		/// </summary>
		public abstract bool Update(System.Int32? mailMessageFolderId, System.String name, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new MailMessageFolderDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual MailMessageFolderDetails GetMailMessageFolderFromReader(DbDataReader reader) {
			MailMessageFolderDetails mailMessageFolder = new MailMessageFolderDetails();
			if (reader.HasRows) {
				mailMessageFolder.MailMessageFolderId = GetReaderValue_Int32(reader, "MailMessageFolderId", 0); //From: [Table]
				mailMessageFolder.LoginNo = GetReaderValue_NullableInt32(reader, "LoginNo", null); //From: [Table]
				mailMessageFolder.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
				mailMessageFolder.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				mailMessageFolder.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
			}
			return mailMessageFolder;
		}
	
		/// <summary>
		/// Returns a collection of MailMessageFolderDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<MailMessageFolderDetails> GetMailMessageFolderCollectionFromReader(DbDataReader reader) {
			List<MailMessageFolderDetails> mailMessageFolders = new List<MailMessageFolderDetails>();
			while (reader.Read()) mailMessageFolders.Add(GetMailMessageFolderFromReader(reader));
			return mailMessageFolders;
		}
		
		
	}
}