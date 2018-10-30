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
	
	public abstract class SessionProvider : DataAccess {
		static private SessionProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SessionProvider Instance {
			get {
				if (_instance == null) _instance = (SessionProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Sessions.ProviderType));
				return _instance;
			}
		}
		public SessionProvider() {
			this.ConnectionString = Globals.Settings.Sessions.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Count
		/// Calls [usp_count_Session]
		/// </summary>
		public abstract Int32 Count();
		/// <summary>
		/// CountForLogin
		/// Calls [usp_count_Session_for_Login]
		/// </summary>
		public abstract Int32 CountForLogin(System.Int32? loginNo, System.String sessionName);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Session]
		/// </summary>
		public abstract bool Delete(System.Int32? loginNo);
		/// <summary>
		/// Get
		/// Calls [usp_select_Session]
		/// </summary>
		public abstract SessionDetails Get(System.Int32? loginNo);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_Session]
		/// </summary>
		public abstract List<SessionDetails> GetList();
		/// <summary>
		/// UpdateClearOldSessions
		/// Calls [usp_update_Session_ClearOldSessions]
		/// </summary>
		public abstract bool UpdateClearOldSessions();

		#endregion
				
		/// <summary>
		/// Returns a new SessionDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual SessionDetails GetSessionFromReader(DbDataReader reader) {
			SessionDetails session = new SessionDetails();
			if (reader.HasRows) {
				session.LoginNo = GetReaderValue_Int32(reader, "LoginNo", 0); //From: [Table]
				session.SessionName = GetReaderValue_String(reader, "SessionName", ""); //From: [Table]
				session.SessionTimestamp = GetReaderValue_DateTime(reader, "SessionTimestamp", DateTime.MinValue); //From: [Table]
				session.StartTime = GetReaderValue_DateTime(reader, "StartTime", DateTime.MinValue); //From: [Table]
				session.IPAddress = GetReaderValue_String(reader, "IPAddress", ""); //From: [Table]
				session.EmployeeName = GetReaderValue_String(reader, "EmployeeName", ""); //From: [usp_selectAll_Audit_authorisation_for_SalesOrder]
			}
			return session;
		}
	
		/// <summary>
		/// Returns a collection of SessionDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<SessionDetails> GetSessionCollectionFromReader(DbDataReader reader) {
			List<SessionDetails> sessions = new List<SessionDetails>();
			while (reader.Read()) sessions.Add(GetSessionFromReader(reader));
			return sessions;
		}
		
		
	}
}