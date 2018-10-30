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
	
	public abstract class CountryProvider : DataAccess {
		static private CountryProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public CountryProvider Instance {
			get {
				if (_instance == null) _instance = (CountryProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Countrys.ProviderType));
				return _instance;
			}
		}
		public CountryProvider() {
			this.ConnectionString = Globals.Settings.Countrys.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Country]
		/// </summary>
		public abstract bool Delete(System.Int32? countryId);
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_Country_for_Client]
		/// </summary>
		public abstract List<CountryDetails> DropDownForClient(System.Int32? clientId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Country]
		/// </summary>
		public abstract Int32 Insert(System.String countryName, System.String notes, System.String telephonePrefix, System.Boolean? duty, System.Int32? taxNo, System.Double? shippingCost, System.Int32? clientNo, System.Int32? globalCountryNo, System.Int32? deliveryLeadTimeAir, System.Int32? deliveryLeadTimeSurface, System.Boolean? isPriorityForLists, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_Country]
		/// </summary>
		public abstract CountryDetails Get(System.Int32? countryId);
		/// <summary>
		/// GetShippingCost
		/// Calls [usp_select_Country_ShippingCost]
		/// </summary>
		public abstract CountryDetails GetShippingCost(System.Int32? countryId);
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_Country_for_Client]
		/// </summary>
		public abstract List<CountryDetails> GetListForClient(System.Int32? clientId);
		/// <summary>
		/// Update
		/// Calls [usp_update_Country]
		/// </summary>
        public abstract bool Update(System.Int32? countryId, System.String countryName, System.String notes, System.String telephonePrefix, System.Boolean? duty, System.Int32? taxNo, System.Double? shippingCost, System.Int32? deliveryLeadTimeAir, System.Int32? deliveryLeadTimeSurface, System.Boolean? isPriorityForLists, System.Boolean? inactive, System.Int32? updatedBy, System.Double? shipSurChargePer);

		#endregion
				
		/// <summary>
		/// Returns a new CountryDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual CountryDetails GetCountryFromReader(DbDataReader reader) {
			CountryDetails country = new CountryDetails();
			if (reader.HasRows) {
				country.CountryId = GetReaderValue_Int32(reader, "CountryId", 0); //From: [Table]
				country.CountryName = GetReaderValue_String(reader, "CountryName", ""); //From: [usp_dropdown_Address_for_Company]
				country.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [usp_select_Address_DefaultBilling_for_Company]
				country.TelephonePrefix = GetReaderValue_String(reader, "TelephonePrefix", ""); //From: [Table]
				country.Duty = GetReaderValue_Boolean(reader, "Duty", false); //From: [Table]
				country.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null); //From: [Table]
				country.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null); //From: [Table]
				country.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				country.GlobalCountryNo = GetReaderValue_NullableInt32(reader, "GlobalCountryNo", null); //From: [Table]
				country.DeliveryLeadTimeAir = GetReaderValue_NullableInt32(reader, "DeliveryLeadTimeAir", null); //From: [Table]
				country.DeliveryLeadTimeSurface = GetReaderValue_NullableInt32(reader, "DeliveryLeadTimeSurface", null); //From: [Table]
				country.IsPriorityForLists = GetReaderValue_Boolean(reader, "IsPriorityForLists", false); //From: [Table]
				country.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				country.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				country.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				country.TaxName = GetReaderValue_String(reader, "TaxName", ""); //From: [usp_select_Country]
			}
			return country;
		}
	
		/// <summary>
		/// Returns a collection of CountryDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<CountryDetails> GetCountryCollectionFromReader(DbDataReader reader) {
			List<CountryDetails> countrys = new List<CountryDetails>();
			while (reader.Read()) countrys.Add(GetCountryFromReader(reader));
			return countrys;
		}


        /// <summary>
        /// DropDownForRegion
        /// Calls [usp_dropdown_Region]
        /// </summary>
        public abstract List<CountryDetails> DropDownForRegion();
	}
}