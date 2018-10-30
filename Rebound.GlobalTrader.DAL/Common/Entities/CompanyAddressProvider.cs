/*
Marker     Changed by      Date         Remarks
[001]      Vinay           11/06/2012   This need to Add Incoterms field in company section
*/
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
	
	public abstract class CompanyAddressProvider : DataAccess {
		static private CompanyAddressProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public CompanyAddressProvider Instance {
			get {
				if (_instance == null) _instance = (CompanyAddressProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.CompanyAddresss.ProviderType));
				return _instance;
			}
		}
		public CompanyAddressProvider() {
			this.ConnectionString = Globals.Settings.CompanyAddresss.ConnectionString;
		}

		#region Method Registrations

        //[001] code start
        /// <summary>
        /// Insert
        /// Calls [usp_insert_CompanyAddress]
        /// </summary>
        public abstract Int32 Insert(System.Int32? companyNo, System.Int32? addressNo, System.Int32? shipViaNo, System.String shipViaAccount, System.String notes, System.String shippingNotes, System.Int32? TaxbyAddress, System.Int32? updatedBy, System.Int32? IncotermNo, System.String vatNo, System.String recievingNotes);
        //[001] code end
		/// <summary>
		/// GetByAddress
		/// Calls [usp_select_CompanyAddress_by_Address]
		/// </summary>
		public abstract CompanyAddressDetails GetByAddress(System.Int32? addressId);
        //[001] code start
		/// <summary>
		/// Update
		/// Calls [usp_update_CompanyAddress]
		/// </summary>
        public abstract bool Update(System.Int32? companyAddressId, System.Int32? shipViaNo, System.String shipViaAccount, System.String notes, System.String shippingNotes, System.Int32? TaxbyAddress, System.Int32? updatedBy, System.Int32? IncotermNo, System.String vatNo, System.String recievingNotes);
        //[001] code end
		/// <summary>
		/// UpdateCeaseDate
		/// Calls [usp_update_CompanyAddress_CeaseDate]
		/// </summary>
		public abstract bool UpdateCeaseDate(System.Int32? companyAddressNo, System.Int32? updatedBy);
		/// <summary>
		/// UpdateCheckDefault
		/// Calls [usp_update_CompanyAddress_CheckDefault]
		/// </summary>
		public abstract bool UpdateCheckDefault(System.Int32? companyAddressId, System.Int32? updatedBy);
		/// <summary>
		/// UpdateDefaultBilling
		/// Calls [usp_update_CompanyAddress_DefaultBilling]
		/// </summary>
		public abstract bool UpdateDefaultBilling(System.Int32? companyAddressId, System.Int32? updatedBy);
		/// <summary>
		/// UpdateDefaultShipping
		/// Calls [usp_update_CompanyAddress_DefaultShipping]
		/// </summary>
		public abstract bool UpdateDefaultShipping(System.Int32? companyAddressId, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new CompanyAddressDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual CompanyAddressDetails GetCompanyAddressFromReader(DbDataReader reader) {
			CompanyAddressDetails companyAddress = new CompanyAddressDetails();
			if (reader.HasRows) {
				companyAddress.CompanyAddressId = GetReaderValue_Int32(reader, "CompanyAddressId", 0); //From: [usp_select_Address_DefaultBilling_for_Company]
				companyAddress.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [usp_list_Activity_by_Client_with_filter]
				companyAddress.AddressNo = GetReaderValue_Int32(reader, "AddressNo", 0); //From: [Table]
				companyAddress.CeaseDate = GetReaderValue_NullableDateTime(reader, "CeaseDate", null); //From: [usp_select_Address_DefaultBilling_for_Company]
				companyAddress.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null); //From: [usp_select_Address_DefaultBilling_for_Company]
				companyAddress.ShipViaAccount = GetReaderValue_String(reader, "ShipViaAccount", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
				companyAddress.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
				companyAddress.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				companyAddress.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				companyAddress.DefaultBilling = GetReaderValue_Boolean(reader, "DefaultBilling", false); //From: [usp_select_Address_DefaultBilling_for_Company]
				companyAddress.DefaultShipping = GetReaderValue_Boolean(reader, "DefaultShipping", false); //From: [usp_select_Address_DefaultBilling_for_Company]
				companyAddress.ShippingNotes = GetReaderValue_String(reader, "ShippingNotes", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
                
                companyAddress.TaxbyAddress = GetReaderValue_NullableInt32(reader, "TaxbyAddress", 0); //  From: [usp_select_Address_DefaultBilling_for_Company]
			}
			return companyAddress;
		}
	
		/// <summary>
		/// Returns a collection of CompanyAddressDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<CompanyAddressDetails> GetCompanyAddressCollectionFromReader(DbDataReader reader) {
			List<CompanyAddressDetails> companyAddresss = new List<CompanyAddressDetails>();
			while (reader.Read()) companyAddresss.Add(GetCompanyAddressFromReader(reader));
			return companyAddresss;
		}
		
		
	}
}