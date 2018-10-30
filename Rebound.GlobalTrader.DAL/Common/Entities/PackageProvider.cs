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
	
	public abstract class PackageProvider : DataAccess {
		static private PackageProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public PackageProvider Instance {
			get {
				if (_instance == null) _instance = (PackageProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Packages.ProviderType));
				return _instance;
			}
		}
		public PackageProvider() {
			this.ConnectionString = Globals.Settings.Packages.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Package]
		/// </summary>
		public abstract bool Delete(System.Int32? packageId);
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_Package]
		/// </summary>
		public abstract List<PackageDetails> DropDown();
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Package]
		/// </summary>
		public abstract Int32 Insert(System.String packageName, System.String packageDescription, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_Package]
		/// </summary>
		public abstract PackageDetails Get(System.Int32? packageId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_Package]
		/// </summary>
		public abstract List<PackageDetails> GetList();
		/// <summary>
		/// Update
		/// Calls [usp_update_Package]
		/// </summary>
		public abstract bool Update(System.Int32? packageId, System.String packageName, System.String packageDescription, System.Boolean? inactive, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new PackageDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual PackageDetails GetPackageFromReader(DbDataReader reader) {
			PackageDetails package = new PackageDetails();
			if (reader.HasRows) {
				package.PackageId = GetReaderValue_Int32(reader, "PackageId", 0); //From: [Table]
				package.PackageName = GetReaderValue_String(reader, "PackageName", ""); //From: [Table]
				package.PackageDescription = GetReaderValue_String(reader, "PackageDescription", ""); //From: [Table]
				package.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				package.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				package.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
			}
			return package;
		}
	
		/// <summary>
		/// Returns a collection of PackageDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<PackageDetails> GetPackageCollectionFromReader(DbDataReader reader) {
			List<PackageDetails> packages = new List<PackageDetails>();
			while (reader.Read()) packages.Add(GetPackageFromReader(reader));
			return packages;
		}
		
		
	}
}