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
	
	public abstract class CompanyTypeProvider : DataAccess {
		static private CompanyTypeProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public CompanyTypeProvider Instance {
			get {
				if (_instance == null) _instance = (CompanyTypeProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.CompanyTypes.ProviderType));
				return _instance;
			}
		}
		public CompanyTypeProvider() {
			this.ConnectionString = Globals.Settings.CompanyTypes.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_CompanyType]
		/// </summary>
		public abstract bool Delete(System.Int32? companyTypeId);
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_CompanyType]
		/// </summary>
		public abstract List<CompanyTypeDetails> DropDown();
		/// <summary>
		/// Insert
		/// Calls [usp_insert_CompanyType]
		/// </summary>
        public abstract Int32 Insert(System.String name, System.Boolean? Traceability,System.Boolean? NonPreferredCompany);
		/// <summary>
		/// Get
		/// Calls [usp_select_CompanyType]
		/// </summary>
		public abstract CompanyTypeDetails Get(System.Int32? companyTypeId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_CompanyType]
		/// </summary>
		public abstract List<CompanyTypeDetails> GetList();
		/// <summary>
		/// Update
		/// Calls [usp_update_CompanyType]
		/// </summary>
        public abstract bool Update(System.String name, System.Int32? companyTypeId, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? Traceability, System.Boolean? NonPreferredCompany);

		#endregion
				
		/// <summary>
		/// Returns a new CompanyTypeDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual CompanyTypeDetails GetCompanyTypeFromReader(DbDataReader reader) {
			CompanyTypeDetails companyType = new CompanyTypeDetails();
			if (reader.HasRows) {
				companyType.CompanyTypeId = GetReaderValue_Int32(reader, "CompanyTypeId", 0); //From: [Table]
				companyType.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
				companyType.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				companyType.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				companyType.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null); //From: [Table]
			}
			return companyType;
		}
	
		/// <summary>
		/// Returns a collection of CompanyTypeDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<CompanyTypeDetails> GetCompanyTypeCollectionFromReader(DbDataReader reader) {
			List<CompanyTypeDetails> companyTypes = new List<CompanyTypeDetails>();
			while (reader.Read()) companyTypes.Add(GetCompanyTypeFromReader(reader));
			return companyTypes;
		}
		
		
	}
}