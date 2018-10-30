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
	
	public abstract class CompanyIndustryTypeProvider : DataAccess {
		static private CompanyIndustryTypeProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public CompanyIndustryTypeProvider Instance {
			get {
				if (_instance == null) _instance = (CompanyIndustryTypeProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.CompanyIndustryTypes.ProviderType));
				return _instance;
			}
		}
		public CompanyIndustryTypeProvider() {
			this.ConnectionString = Globals.Settings.CompanyIndustryTypes.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// DeleteAllForCompany
		/// Calls [usp_delete_CompanyIndustryType_All_For_Company]
		/// </summary>
		public abstract bool DeleteAllForCompany(System.Int32? companyId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_CompanyIndustryType]
		/// </summary>
		public abstract Int32 Insert(System.Int32? companyNo, System.Int32? industryTypeNo);
		/// <summary>
		/// GetListForCompany
		/// Calls [usp_selectAll_CompanyIndustryType_for_Company]
		/// </summary>
		public abstract List<CompanyIndustryTypeDetails> GetListForCompany(System.Int32? companyId);

		#endregion
				
		/// <summary>
		/// Returns a new CompanyIndustryTypeDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual CompanyIndustryTypeDetails GetCompanyIndustryTypeFromReader(DbDataReader reader) {
			CompanyIndustryTypeDetails companyIndustryType = new CompanyIndustryTypeDetails();
			if (reader.HasRows) {
				companyIndustryType.CompanyIndustryTypeId = GetReaderValue_Int32(reader, "CompanyIndustryTypeId", 0); //From: [Table]
				companyIndustryType.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null); //From: [usp_list_Activity_by_Client_with_filter]
				companyIndustryType.IndustryTypeNo = GetReaderValue_NullableInt32(reader, "IndustryTypeNo", null); //From: [Table]
				companyIndustryType.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
			}
			return companyIndustryType;
		}
	
		/// <summary>
		/// Returns a collection of CompanyIndustryTypeDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<CompanyIndustryTypeDetails> GetCompanyIndustryTypeCollectionFromReader(DbDataReader reader) {
			List<CompanyIndustryTypeDetails> companyIndustryTypes = new List<CompanyIndustryTypeDetails>();
			while (reader.Read()) companyIndustryTypes.Add(GetCompanyIndustryTypeFromReader(reader));
			return companyIndustryTypes;
		}
		
		
	}
}