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
	
	public abstract class SecurityGroupSecurityFunctionPermissionProvider : DataAccess {
		static private SecurityGroupSecurityFunctionPermissionProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SecurityGroupSecurityFunctionPermissionProvider Instance {
			get {
				if (_instance == null) _instance = (SecurityGroupSecurityFunctionPermissionProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.SecurityGroupSecurityFunctionPermissions.ProviderType));
				return _instance;
			}
		}
		public SecurityGroupSecurityFunctionPermissionProvider() {
			this.ConnectionString = Globals.Settings.SecurityGroupSecurityFunctionPermissions.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Insert
		/// Calls [usp_insert_SecurityGroupSecurityFunctionPermission]
		/// </summary>
		public abstract Int32 Insert(System.Int32? securityGroupNo, System.Int32? securityFunctionNo, System.Boolean? isAllowed, System.Int32? updatedBy);
		/// <summary>
		/// InsertDenyAllButAdminsForNewFunction
		/// Calls [usp_insert_SecurityGroupSecurityFunctionPermission_DenyAllButAdminsForNewFunction]
		/// </summary>
		public abstract Int32 InsertDenyAllButAdminsForNewFunction(System.Int32? securityFunctionId, System.Int32? updatedBy);
		/// <summary>
		/// InsertStandardPermissions
		/// Calls [usp_insert_SecurityGroupSecurityFunctionPermission_StandardPermissions]
		/// </summary>
		public abstract Int32 InsertStandardPermissions(System.Int32? securityGroupNo, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_SecurityGroupSecurityFunctionPermission]
		/// </summary>
		public abstract SecurityGroupSecurityFunctionPermissionDetails Get(System.Int32? securityGroupSecurityFunctionPermissionId);
		/// <summary>
		/// GetByGroupAndFunction
		/// Calls [usp_select_SecurityGroupSecurityFunctionPermission_by_Group_and_Function]
		/// </summary>
		public abstract SecurityGroupSecurityFunctionPermissionDetails GetByGroupAndFunction(System.Int32? securityGroupNo, System.Int32? securityFunctionNo);
		/// <summary>
		/// Update
		/// Calls [usp_update_SecurityGroupSecurityFunctionPermission]
		/// </summary>
		public abstract bool Update(System.Int32? securityGroupSecurityFunctionPermissionId, System.Int32? securityGroupNo, System.Int32? securityFunctionNo, System.Boolean? isAllowed, System.Int32? updatedBy);

        /// <summary>
        /// Insert
        /// Calls [usp_insert_GlobalSecurityGroupSecurityFunctionPermission]
        /// </summary>
        public abstract Int32 GlobalPermissionInsert(System.Int32? securityGroupNo, System.Int32? securityFunctionNo, System.Boolean? isAllowed, System.Int32? updatedBy);
        /// <summary>
        /// Update
        /// Calls [usp_update_GlobalSecurityGroupSecurityFunctionPermission]
        /// </summary>
        public abstract bool GlobalPermissionUpdate(System.Int32? securityGroupSecurityFunctionPermissionId, System.Int32? securityGroupNo, System.Int32? securityFunctionNo, System.Boolean? isAllowed, System.Int32? updatedBy);



		#endregion
				
		/// <summary>
		/// Returns a new SecurityGroupSecurityFunctionPermissionDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual SecurityGroupSecurityFunctionPermissionDetails GetSecurityGroupSecurityFunctionPermissionFromReader(DbDataReader reader) {
			SecurityGroupSecurityFunctionPermissionDetails securityGroupSecurityFunctionPermission = new SecurityGroupSecurityFunctionPermissionDetails();
			if (reader.HasRows) {
				securityGroupSecurityFunctionPermission.SecurityGroupSecurityFunctionPermissionId = GetReaderValue_Int32(reader, "SecurityGroupSecurityFunctionPermissionId", 0); //From: [Table]
				securityGroupSecurityFunctionPermission.SecurityGroupNo = GetReaderValue_Int32(reader, "SecurityGroupNo", 0); //From: [Table]
				securityGroupSecurityFunctionPermission.SecurityFunctionNo = GetReaderValue_Int32(reader, "SecurityFunctionNo", 0); //From: [Table]
				securityGroupSecurityFunctionPermission.IsAllowed = GetReaderValue_Boolean(reader, "IsAllowed", false); //From: [Table]
				securityGroupSecurityFunctionPermission.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				securityGroupSecurityFunctionPermission.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
			}
			return securityGroupSecurityFunctionPermission;
		}
	
		/// <summary>
		/// Returns a collection of SecurityGroupSecurityFunctionPermissionDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<SecurityGroupSecurityFunctionPermissionDetails> GetSecurityGroupSecurityFunctionPermissionCollectionFromReader(DbDataReader reader) {
			List<SecurityGroupSecurityFunctionPermissionDetails> securityGroupSecurityFunctionPermissions = new List<SecurityGroupSecurityFunctionPermissionDetails>();
			while (reader.Read()) securityGroupSecurityFunctionPermissions.Add(GetSecurityGroupSecurityFunctionPermissionFromReader(reader));
			return securityGroupSecurityFunctionPermissions;
		}

        /// <summary>
        /// Insert
        /// Calls [usp_insert_BulkSecurityGroupSecurityFunctionPermission]
        /// </summary>
        public abstract Int32 Insert(System.Int32? securityGroupNo, System.String xmlPermission, System.Int32? updatedBy);	
	}
}