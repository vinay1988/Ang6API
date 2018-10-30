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
	
	public abstract class SecurityGroupLoginProvider : DataAccess {
		static private SecurityGroupLoginProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SecurityGroupLoginProvider Instance {
			get {
				if (_instance == null) _instance = (SecurityGroupLoginProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.SecurityGroupLogins.ProviderType));
				return _instance;
			}
		}
		public SecurityGroupLoginProvider() {
			this.ConnectionString = Globals.Settings.SecurityGroupLogins.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_SecurityGroupLogin]
		/// </summary>
		public abstract bool Delete(System.Int32? loginNo, System.Int32? securityGroupNo);
		/// <summary>
		/// DeleteForSecurityGroup
		/// Calls [usp_delete_SecurityGroupLogin_for_SecurityGroup]
		/// </summary>
		public abstract bool DeleteForSecurityGroup(System.Int32? securityGroupNo);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_SecurityGroupLogin]
		/// </summary>
        public abstract Int32 Insert(System.Int32? securityGroupNo, System.Int32? loginNo, System.Int32? updatedBy, System.Boolean? isGlobal);
		/// <summary>
		/// GetListForSecurityGroup
		/// Calls [usp_selectAll_SecurityGroupLogin_for_SecurityGroup]
		/// </summary>
		public abstract List<SecurityGroupLoginDetails> GetListForSecurityGroup(System.Int32? securityGroupNo);
		/// <summary>
		/// Update
		/// Calls [usp_update_SecurityGroupLogin]
		/// </summary>
		public abstract bool Update(System.Int32? securityGroupNo, System.Int32? loginNo, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new SecurityGroupLoginDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual SecurityGroupLoginDetails GetSecurityGroupLoginFromReader(DbDataReader reader) {
			SecurityGroupLoginDetails securityGroupLogin = new SecurityGroupLoginDetails();
			if (reader.HasRows) {
				securityGroupLogin.SecurityGroupLoginId = GetReaderValue_Int32(reader, "SecurityGroupLoginId", 0); //From: [Table]
				securityGroupLogin.SecurityGroupNo = GetReaderValue_Int32(reader, "SecurityGroupNo", 0); //From: [Table]
				securityGroupLogin.LoginNo = GetReaderValue_Int32(reader, "LoginNo", 0); //From: [Table]
				securityGroupLogin.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				securityGroupLogin.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				securityGroupLogin.EmployeeName = GetReaderValue_String(reader, "EmployeeName", ""); //From: [usp_selectAll_Audit_authorisation_for_SalesOrder]
				securityGroupLogin.KeyLogin = GetReaderValue_Boolean(reader, "KeyLogin", false); //From: [Table]
				securityGroupLogin.Administrator = GetReaderValue_Boolean(reader, "Administrator", false); //From: [usp_selectAll_Login_for_Client_including_Disabled]
			}
			return securityGroupLogin;
		}
	
		/// <summary>
		/// Returns a collection of SecurityGroupLoginDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<SecurityGroupLoginDetails> GetSecurityGroupLoginCollectionFromReader(DbDataReader reader) {
			List<SecurityGroupLoginDetails> securityGroupLogins = new List<SecurityGroupLoginDetails>();
			while (reader.Read()) securityGroupLogins.Add(GetSecurityGroupLoginFromReader(reader));
			return securityGroupLogins;
		}
		
		
	}
}