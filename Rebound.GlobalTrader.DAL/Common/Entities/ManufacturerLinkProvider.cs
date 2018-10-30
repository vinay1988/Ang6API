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
	
	public abstract class ManufacturerLinkProvider : DataAccess {
		static private ManufacturerLinkProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ManufacturerLinkProvider Instance {
			get {
				if (_instance == null) _instance = (ManufacturerLinkProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.ManufacturerLinks.ProviderType));
				return _instance;
			}
		}
		public ManufacturerLinkProvider() {
			this.ConnectionString = Globals.Settings.ManufacturerLinks.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// CountForManufacturerAndSupplier
		/// Calls [usp_count_ManufacturerLink_for_Manufacturer_and_Supplier]
		/// </summary>
		public abstract Int32 CountForManufacturerAndSupplier(System.Int32? manufacturerNo, System.Int32? supplierCompanyNo);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_ManufacturerLink]
		/// </summary>
		public abstract bool Delete(System.Int32? manufacturerLinkId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_ManufacturerLink]
		/// </summary>
		public abstract Int32 Insert(System.Int32? manufacturerNo, System.Int32? supplierCompanyNo, System.Int32? manufacturerRating, System.Int32? supplierRating, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_ManufacturerLink]
		/// </summary>
		public abstract ManufacturerLinkDetails Get(System.Int32? manufacturerLinkId);
		/// <summary>
		/// GetForManufacturerAndSupplier
		/// Calls [usp_select_ManufacturerLink_for_Manufacturer_and_Supplier]
		/// </summary>
		public abstract ManufacturerLinkDetails GetForManufacturerAndSupplier(System.Int32? manufacturerNo, System.Int32? supplierCompanyNo);
		/// <summary>
		/// GetListForManufacturer
		/// Calls [usp_selectAll_ManufacturerLink_for_Manufacturer]
		/// </summary>
		public abstract List<ManufacturerLinkDetails> GetListForManufacturer(System.Int32? manufacturerId, System.Int32? clientId);
		/// <summary>
		/// GetListForSupplier
		/// Calls [usp_selectAll_ManufacturerLink_for_Supplier]
		/// </summary>
		public abstract List<ManufacturerLinkDetails> GetListForSupplier(System.Int32? supplierCompanyNo);
		/// <summary>
		/// Update
		/// Calls [usp_update_ManufacturerLink]
		/// </summary>
		public abstract bool Update(System.Int32? manufacturerLinkId, System.Int32? manufacturerNo, System.Int32? supplierCompanyNo, System.Int32? manufacturerRating, System.Int32? supplierRating, System.Int32? updatedBy);
		/// <summary>
		/// UpdateByManufacturerAndSupplier
		/// Calls [usp_update_ManufacturerLink_by_Manufacturer_and_Supplier]
		/// </summary>
		public abstract bool UpdateByManufacturerAndSupplier(System.Int32? manufacturerNo, System.Int32? supplierCompanyNo, System.Int32? manufacturerRating, System.Int32? supplierRating, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new ManufacturerLinkDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ManufacturerLinkDetails GetManufacturerLinkFromReader(DbDataReader reader) {
			ManufacturerLinkDetails manufacturerLink = new ManufacturerLinkDetails();
			if (reader.HasRows) {
				manufacturerLink.ManufacturerLinkId = GetReaderValue_Int32(reader, "ManufacturerLinkId", 0); //From: [Table]
				manufacturerLink.ManufacturerNo = GetReaderValue_Int32(reader, "ManufacturerNo", 0); //From: [usp_selectAll_Allocation]
				manufacturerLink.SupplierCompanyNo = GetReaderValue_Int32(reader, "SupplierCompanyNo", 0); //From: [usp_selectAll_Allocation]
				manufacturerLink.ManufacturerRating = GetReaderValue_NullableInt32(reader, "ManufacturerRating", null); //From: [Table]
				manufacturerLink.SupplierRating = GetReaderValue_NullableInt32(reader, "SupplierRating", null); //From: [Table]
				manufacturerLink.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				manufacturerLink.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				manufacturerLink.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", ""); //From: [usp_selectAll_Allocation]
				manufacturerLink.SupplierName = GetReaderValue_String(reader, "SupplierName", ""); //From: [usp_source_Excess]
			}
			return manufacturerLink;
		}
	
		/// <summary>
		/// Returns a collection of ManufacturerLinkDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ManufacturerLinkDetails> GetManufacturerLinkCollectionFromReader(DbDataReader reader) {
			List<ManufacturerLinkDetails> manufacturerLinks = new List<ManufacturerLinkDetails>();
			while (reader.Read()) manufacturerLinks.Add(GetManufacturerLinkFromReader(reader));
			return manufacturerLinks;
		}
		
		
	}
}