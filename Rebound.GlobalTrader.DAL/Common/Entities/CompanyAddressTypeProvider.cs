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
	
	public abstract class CompanyAddressTypeProvider : DataAccess {
		static private CompanyAddressTypeProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public CompanyAddressTypeProvider Instance {
			get {
				if (_instance == null) _instance = (CompanyAddressTypeProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.CompanyAddressTypes.ProviderType));
				return _instance;
			}
		}
		public CompanyAddressTypeProvider() {
			this.ConnectionString = Globals.Settings.CompanyAddressTypes.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_CompanyAddressType]
		/// </summary>
		public abstract bool Delete(System.Int32? companyAddressTypeId);
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_CompanyAddressType]
		/// </summary>
		public abstract List<CompanyAddressTypeDetails> DropDown();
		/// <summary>
		/// Insert
		/// Calls [usp_insert_CompanyAddressType]
		/// </summary>
		public abstract Int32 Insert(System.String name);
		/// <summary>
		/// Get
		/// Calls [usp_select_CompanyAddressType]
		/// </summary>
		public abstract CompanyAddressTypeDetails Get(System.Int32? companyAddressTypeId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_CompanyAddressType]
		/// </summary>
		public abstract List<CompanyAddressTypeDetails> GetList();

		#endregion
				
		/// <summary>
		/// Returns a new CompanyAddressTypeDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual CompanyAddressTypeDetails GetCompanyAddressTypeFromReader(DbDataReader reader) {
			CompanyAddressTypeDetails companyAddressType = new CompanyAddressTypeDetails();
			if (reader.HasRows) {
				companyAddressType.CompanyAddressTypeId = GetReaderValue_Int32(reader, "CompanyAddressTypeId", 0); //From: [Table]
				companyAddressType.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
			}
			return companyAddressType;
		}
	
		/// <summary>
		/// Returns a collection of CompanyAddressTypeDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<CompanyAddressTypeDetails> GetCompanyAddressTypeCollectionFromReader(DbDataReader reader) {
			List<CompanyAddressTypeDetails> companyAddressTypes = new List<CompanyAddressTypeDetails>();
			while (reader.Read()) companyAddressTypes.Add(GetCompanyAddressTypeFromReader(reader));
			return companyAddressTypes;
		}
		
		
	}
}