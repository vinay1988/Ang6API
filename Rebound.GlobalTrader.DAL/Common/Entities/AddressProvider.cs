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
	
	public abstract class AddressProvider : DataAccess {
		static private AddressProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public AddressProvider Instance {
			get {
				if (_instance == null) _instance = (AddressProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Addresss.ProviderType));
				return _instance;
			}
		}
		public AddressProvider() {
			this.ConnectionString = Globals.Settings.Addresss.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Address]
		/// </summary>
		public abstract bool Delete(System.Int32? addressId);
		/// <summary>
		/// DropDownForCompany
		/// Calls [usp_dropdown_Address_for_Company]
		/// </summary>
		public abstract List<AddressDetails> DropDownForCompany(System.Int32? companyId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Address]
		/// </summary>
		public abstract Int32 Insert(System.String addressName, System.String line1, System.String line2, System.String line3, System.String county, System.String city, System.String state, System.Int32? countryNo, System.String zip, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_Address]
		/// </summary>
		public abstract AddressDetails Get(System.Int32? addressId);
		/// <summary>
		/// GetDefaultBillingForCompany
		/// Calls [usp_select_Address_DefaultBilling_for_Company]
		/// </summary>
		public abstract AddressDetails GetDefaultBillingForCompany(System.Int32? companyId);
		/// <summary>
		/// GetDefaultShippingForCompany
		/// Calls [usp_select_Address_DefaultShipping_for_Company]
		/// </summary>
		public abstract AddressDetails GetDefaultShippingForCompany(System.Int32? companyId);
		/// <summary>
		/// GetForCompany
		/// Calls [usp_select_Address_for_Company]
		/// </summary>
		public abstract AddressDetails GetForCompany(System.Int32? companyAddressId);
		/// <summary>
		/// GetForDivision
		/// Calls [usp_select_Address_for_Division]
		/// </summary>
		public abstract AddressDetails GetForDivision(System.Int32? divisionId);
		/// <summary>
		/// GetForWarehouse
		/// Calls [usp_select_Address_for_Warehouse]
		/// </summary>
		public abstract AddressDetails GetForWarehouse(System.Int32? warehouseId);
		/// <summary>
		/// GetListForCompany
		/// Calls [usp_selectAll_Address_for_Company]
		/// </summary>
		public abstract List<AddressDetails> GetListForCompany(System.Int32? companyId);
		/// <summary>
		/// Update
		/// Calls [usp_update_Address]
		/// </summary>
		public abstract bool Update(System.Int32? addressId, System.String addressName, System.String line1, System.String line2, System.String line3, System.String county, System.String city, System.String state, System.Int32? countryNo, System.String zip, System.Boolean? inactive, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new AddressDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual AddressDetails GetAddressFromReader(DbDataReader reader) {
			AddressDetails address = new AddressDetails();
			if (reader.HasRows) {
				address.AddressId = GetReaderValue_Int32(reader, "AddressId", 0); //From: [Table]
				address.AddressName = GetReaderValue_String(reader, "AddressName", ""); //From: [Table]
				address.Line1 = GetReaderValue_String(reader, "Line1", ""); //From: [Table]
				address.Line2 = GetReaderValue_String(reader, "Line2", ""); //From: [Table]
				address.Line3 = GetReaderValue_String(reader, "Line3", ""); //From: [Table]
				address.County = GetReaderValue_String(reader, "County", ""); //From: [Table]
				address.City = GetReaderValue_String(reader, "City", ""); //From: [Table]
				address.State = GetReaderValue_String(reader, "State", ""); //From: [Table]
				address.CountryNo = GetReaderValue_NullableInt32(reader, "CountryNo", null); //From: [Table]
				address.ZIP = GetReaderValue_String(reader, "ZIP", ""); //From: [Table]
				address.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				address.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				address.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				address.CountryName = GetReaderValue_String(reader, "CountryName", ""); //From: [usp_dropdown_Address_for_Company]
				address.CompanyAddressId = GetReaderValue_Int32(reader, "CompanyAddressId", 0); //From: [usp_select_Address_DefaultBilling_for_Company]
				address.DefaultBilling = GetReaderValue_Boolean(reader, "DefaultBilling", false); //From: [usp_select_Address_DefaultBilling_for_Company]
				address.DefaultShipping = GetReaderValue_Boolean(reader, "DefaultShipping", false); //From: [usp_select_Address_DefaultBilling_for_Company]
				address.CeaseDate = GetReaderValue_NullableDateTime(reader, "CeaseDate", null); //From: [usp_select_Address_DefaultBilling_for_Company]
				address.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null); //From: [usp_select_Address_DefaultBilling_for_Company]
				address.ShipViaAccount = GetReaderValue_String(reader, "ShipViaAccount", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
				address.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
				address.ShippingNotes = GetReaderValue_String(reader, "ShippingNotes", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
				address.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [usp_list_Activity_by_Client_with_filter]
				address.ShipViaName = GetReaderValue_String(reader, "ShipViaName", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
                /// /// ESMS #14
                address.TaxbyAddress = GetReaderValue_NullableInt32(reader, "TaxbyAddress", null);//From: [usp_select_Address_DefaultBilling_for_Company]
                address.TaxValue = GetReaderValue_String(reader, "TaxValue", "");  
			    // End
            }
			return address;
		}
	
		/// <summary>
		/// Returns a collection of AddressDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<AddressDetails> GetAddressCollectionFromReader(DbDataReader reader) {
			List<AddressDetails> addresss = new List<AddressDetails>();
			while (reader.Read()) addresss.Add(GetAddressFromReader(reader));
			return addresss;
		}
		
		
	}
}