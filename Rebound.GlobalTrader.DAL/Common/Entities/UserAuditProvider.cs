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
	
	public abstract class UserAuditProvider : DataAccess {
		static private UserAuditProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public UserAuditProvider Instance {
			get {
				if (_instance == null) _instance = (UserAuditProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.UserAudits.ProviderType));
				return _instance;
			}
		}
		public UserAuditProvider() {
			this.ConnectionString = Globals.Settings.UserAudits.ConnectionString;
		}

		#region Method Registrations
		

		#endregion
				
		/// <summary>
		/// Returns a new UserAuditDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual UserAuditDetails GetUserAuditFromReader(DbDataReader reader) {
			UserAuditDetails userAudit = new UserAuditDetails();
			if (reader.HasRows) {
				userAudit.LoginNo = GetReaderValue_Int32(reader, "LoginNo", 0); //From: [Table]
				userAudit.IPAddress = GetReaderValue_String(reader, "IPAddress", ""); //From: [Table]
				userAudit.StartTime = GetReaderValue_DateTime(reader, "StartTime", DateTime.MinValue); //From: [Table]
				userAudit.EndTime = GetReaderValue_NullableDateTime(reader, "EndTime", null); //From: [Table]
			}
			return userAudit;
		}
	
		/// <summary>
		/// Returns a collection of UserAuditDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<UserAuditDetails> GetUserAuditCollectionFromReader(DbDataReader reader) {
			List<UserAuditDetails> userAudits = new List<UserAuditDetails>();
			while (reader.Read()) userAudits.Add(GetUserAuditFromReader(reader));
			return userAudits;
		}
		
		
	}
}