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
	
	public abstract class SecurityGroupProvider : DataAccess {
		static private SecurityGroupProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SecurityGroupProvider Instance {
			get {
				if (_instance == null) _instance = (SecurityGroupProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.SecurityGroups.ProviderType));
				return _instance;
			}
		}
		public SecurityGroupProvider() {
			this.ConnectionString = Globals.Settings.SecurityGroups.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_SecurityGroup]
		/// </summary>
		public abstract bool Delete(System.Int32? securityGroupNo);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_SecurityGroup]
		/// </summary>
		public abstract Int32 Insert(System.String securityGroupName, System.Int32? clientNo, System.Boolean? inactive, System.Boolean? locked, System.Boolean? administrator, System.Int32? updatedBy,System.Boolean? isGlobal);
		/// <summary>
		/// InsertClone
		/// Calls [usp_insert_SecurityGroup_Clone]
		/// </summary>
		public abstract Int32 InsertClone(System.Int32? oldSecurityGroupId, System.String securityGroupName, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_SecurityGroup]
		/// </summary>
		public abstract SecurityGroupDetails Get(System.Int32? securityGroupNo);
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_SecurityGroup_for_Client]
		/// </summary>
        public abstract List<SecurityGroupDetails> GetListForClient(System.Int32? clientNo, System.Boolean? isGlobal);
		/// <summary>
		/// GetListForLogin
		/// Calls [usp_selectAll_SecurityGroup_for_Login]
		/// </summary>
		public abstract List<SecurityGroupDetails> GetListForLogin(System.Int32? loginNo);
		/// <summary>
		/// Update
		/// Calls [usp_update_SecurityGroup]
		/// </summary>
		public abstract bool Update(System.Int32? securityGroupId, System.String securityGroupName, System.Int32? clientNo, System.Boolean? locked, System.Boolean? administrator, System.Boolean? inactive, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new SecurityGroupDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual SecurityGroupDetails GetSecurityGroupFromReader(DbDataReader reader) {
			SecurityGroupDetails securityGroup = new SecurityGroupDetails();
			if (reader.HasRows) {
				securityGroup.SecurityGroupId = GetReaderValue_Int32(reader, "SecurityGroupId", 0); //From: [Table]
				securityGroup.SecurityGroupName = GetReaderValue_String(reader, "SecurityGroupName", ""); //From: [Table]
				securityGroup.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				securityGroup.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				securityGroup.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				securityGroup.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				securityGroup.Locked = GetReaderValue_Boolean(reader, "Locked", false); //From: [Table]
				securityGroup.Administrator = GetReaderValue_Boolean(reader, "Administrator", false); //From: [usp_selectAll_Login_for_Client_including_Disabled]
				securityGroup.NumberOfMembers = GetReaderValue_NullableInt32(reader, "NumberOfMembers", null); //From: [usp_selectAll_Division_for_Client]
			}
			return securityGroup;
		}
	
		/// <summary>
		/// Returns a collection of SecurityGroupDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<SecurityGroupDetails> GetSecurityGroupCollectionFromReader(DbDataReader reader) {
			List<SecurityGroupDetails> securityGroups = new List<SecurityGroupDetails>();
			while (reader.Read()) securityGroups.Add(GetSecurityGroupFromReader(reader));
			return securityGroups;
		}
		
		
	}
}