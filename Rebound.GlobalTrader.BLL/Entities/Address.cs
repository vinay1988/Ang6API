/*
Marker     changed by      date         Remarks
[001]      Abhinav       20/03/2012   ESMS Ref:14 - Tax Information
[002]      Vinay         11/06/2012   This need to Add Incoterms field in company section
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
using Rebound.GlobalTrader.DAL;
using Rebound.GlobalTrader.BLL;

namespace Rebound.GlobalTrader.BLL {
		public partial class Address : BizObject {
		
		#region Properties

		protected static DAL.AddressElement Settings {
			get { return Globals.Settings.Addresss; }
		}

		/// <summary>
		/// AddressId
		/// </summary>
		public System.Int32 AddressId { get; set; }		
		/// <summary>
		/// AddressName
		/// </summary>
		public System.String AddressName { get; set; }		
		/// <summary>
		/// Line1
		/// </summary>
		public System.String Line1 { get; set; }		
		/// <summary>
		/// Line2
		/// </summary>
		public System.String Line2 { get; set; }		
		/// <summary>
		/// Line3
		/// </summary>
		public System.String Line3 { get; set; }		
		/// <summary>
		/// County
		/// </summary>
		public System.String County { get; set; }		
		/// <summary>
		/// City
		/// </summary>
		public System.String City { get; set; }		
		/// <summary>
		/// State
		/// </summary>
		public System.String State { get; set; }		
		/// <summary>
		/// CountryNo
		/// </summary>
		public System.Int32? CountryNo { get; set; }		
		/// <summary>
		/// ZIP
		/// </summary>
		public System.String ZIP { get; set; }		
		/// <summary>
		/// Inactive
		/// </summary>
		public System.Boolean Inactive { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// CountryName
		/// </summary>
		public System.String CountryName { get; set; }		
		/// <summary>
		/// CompanyAddressId
		/// </summary>
		public System.Int32 CompanyAddressId { get; set; }		
		/// <summary>
		/// DefaultBilling
		/// </summary>
		public System.Boolean DefaultBilling { get; set; }		
		/// <summary>
		/// DefaultShipping
		/// </summary>
		public System.Boolean DefaultShipping { get; set; }		
		/// <summary>
		/// CeaseDate
		/// </summary>
		public System.DateTime? CeaseDate { get; set; }		
		/// <summary>
		/// ShipViaNo
		/// </summary>
		public System.Int32? ShipViaNo { get; set; }		
		/// <summary>
		/// ShipViaAccount
		/// </summary>
		public System.String ShipViaAccount { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// ShippingNotes
		/// </summary>
		public System.String ShippingNotes { get; set; }		
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32 CompanyNo { get; set; }		
		/// <summary>
		/// ShipViaName
		/// </summary>
		public System.String ShipViaName { get; set; }
        // [001] code start
        /// <summary>
         /// TaxbyAddress
        /// </summary>
        public System.Int32? TaxbyAddress { get; set; }
        /// <summary>
        /// TaxValue
        /// </summary>
        public System.String TaxValue { get; set; }
        // [001] code end
        //[002] code start
        /// <summary>
        /// IncotermName 
        /// </summary>
        public System.String IncotermName { get; set; }
        /// <summary>
        /// IncotermNo
        /// </summary>
        public System.Int32? IncotermNo { get; set; }
        //[002] code end
        public System.String VatNo { get; set; }
        /// <summary>
        /// RecievingNotes
        /// </summary>
        public System.String RecievingNotes { get; set; }
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Address]
		/// </summary>
		public static bool Delete(System.Int32? addressId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Address.Delete(addressId);
		}
		/// <summary>
		/// DropDownForCompany
		/// Calls [usp_dropdown_Address_for_Company]
		/// </summary>
		public static List<Address> DropDownForCompany(System.Int32? companyId) {
			List<AddressDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Address.DropDownForCompany(companyId);
			if (lstDetails == null) {
				return new List<Address>();
			} else {
				List<Address> lst = new List<Address>();
				foreach (AddressDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Address obj = new Rebound.GlobalTrader.BLL.Address();
					obj.AddressId = objDetails.AddressId;
					obj.AddressName = objDetails.AddressName;
					obj.Line1 = objDetails.Line1;
					obj.Line2 = objDetails.Line2;
					obj.Line3 = objDetails.Line3;
					obj.County = objDetails.County;
					obj.City = objDetails.City;
					obj.State = objDetails.State;
					obj.ZIP = objDetails.ZIP;
					obj.CountryName = objDetails.CountryName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Address]
		/// </summary>
		public static Int32 Insert(System.String addressName, System.String line1, System.String line2, System.String line3, System.String county, System.String city, System.String state, System.Int32? countryNo, System.String zip, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Address.Insert(addressName, line1, line2, line3, county, city, state, countryNo, zip, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Address]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Address.Insert(AddressName, Line1, Line2, Line3, County, City, State, CountryNo, ZIP, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_Address]
		/// </summary>
		public static Address Get(System.Int32? addressId) {
			Rebound.GlobalTrader.DAL.AddressDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Address.Get(addressId);
			if (objDetails == null) {
				return null;
			} else {
				Address obj = new Address();
				obj.AddressId = objDetails.AddressId;
				obj.AddressName = objDetails.AddressName;
				obj.Line1 = objDetails.Line1;
				obj.Line2 = objDetails.Line2;
				obj.Line3 = objDetails.Line3;
				obj.County = objDetails.County;
				obj.City = objDetails.City;
				obj.State = objDetails.State;
				obj.CountryNo = objDetails.CountryNo;
				obj.ZIP = objDetails.ZIP;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.CountryName = objDetails.CountryName;
                // [001] code start
                obj.TaxbyAddress = objDetails.TaxbyAddress;
                obj.TaxValue = objDetails.TaxValue; 
                // End
                //[002] code start
                obj.IncotermNo = objDetails.IncotermNo;
                obj.IncotermName = objDetails.IncotermName;
                //[002] code end
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetDefaultBillingForCompany
		/// Calls [usp_select_Address_DefaultBilling_for_Company]
		/// </summary>
		public static Address GetDefaultBillingForCompany(System.Int32? companyId) {
			Rebound.GlobalTrader.DAL.AddressDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Address.GetDefaultBillingForCompany(companyId);
			if (objDetails == null) {
				return null;
			} else {
				Address obj = new Address();
				obj.AddressId = objDetails.AddressId;
				obj.AddressName = objDetails.AddressName;
				obj.Line1 = objDetails.Line1;
				obj.Line2 = objDetails.Line2;
				obj.Line3 = objDetails.Line3;
				obj.County = objDetails.County;
				obj.City = objDetails.City;
				obj.State = objDetails.State;
				obj.ZIP = objDetails.ZIP;
				obj.Inactive = objDetails.Inactive;
				obj.DLUP = objDetails.DLUP;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.CompanyAddressId = objDetails.CompanyAddressId;
				obj.DefaultBilling = objDetails.DefaultBilling;
				obj.DefaultShipping = objDetails.DefaultShipping;
				obj.CeaseDate = objDetails.CeaseDate;
				obj.ShipViaNo = objDetails.ShipViaNo;
				obj.ShipViaAccount = objDetails.ShipViaAccount;
				obj.Notes = objDetails.Notes;
				obj.ShippingNotes = objDetails.ShippingNotes;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CountryNo = objDetails.CountryNo;
				obj.CountryName = objDetails.CountryName;
				obj.ShipViaName = objDetails.ShipViaName;
                // [001] code start
                obj.TaxbyAddress = objDetails.TaxbyAddress;
                obj.TaxValue = objDetails.TaxValue; 
                // End
                //[002] code start
                obj.IncotermNo = objDetails.IncotermNo;
                obj.IncotermName = objDetails.IncotermName;
                //[002] code end
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetDefaultShippingForCompany
		/// Calls [usp_select_Address_DefaultShipping_for_Company]
		/// </summary>
		public static Address GetDefaultShippingForCompany(System.Int32? companyId) {
			Rebound.GlobalTrader.DAL.AddressDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Address.GetDefaultShippingForCompany(companyId);
			if (objDetails == null) {
				return null;
			} else {
				Address obj = new Address();
				obj.AddressId = objDetails.AddressId;
				obj.AddressName = objDetails.AddressName;
				obj.Line1 = objDetails.Line1;
				obj.Line2 = objDetails.Line2;
				obj.Line3 = objDetails.Line3;
				obj.County = objDetails.County;
				obj.City = objDetails.City;
				obj.State = objDetails.State;
				obj.ZIP = objDetails.ZIP;
				obj.Inactive = objDetails.Inactive;
				obj.DLUP = objDetails.DLUP;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.CompanyAddressId = objDetails.CompanyAddressId;
				obj.DefaultBilling = objDetails.DefaultBilling;
				obj.DefaultShipping = objDetails.DefaultShipping;
				obj.CeaseDate = objDetails.CeaseDate;
				obj.ShipViaNo = objDetails.ShipViaNo;
				obj.ShipViaAccount = objDetails.ShipViaAccount;
				obj.Notes = objDetails.Notes;
				obj.ShippingNotes = objDetails.ShippingNotes;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CountryNo = objDetails.CountryNo;
				obj.CountryName = objDetails.CountryName;
				obj.ShipViaName = objDetails.ShipViaName;
                // [001] code start
                obj.TaxbyAddress = objDetails.TaxbyAddress;
                obj.TaxValue = objDetails.TaxValue;
                // End
                //[002] code start
                obj.IncotermNo = objDetails.IncotermNo;
                obj.IncotermName = objDetails.IncotermName;
                //[002] code end
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForCompany
		/// Calls [usp_select_Address_for_Company]
		/// </summary>
		public static Address GetForCompany(System.Int32? companyAddressId) {
			Rebound.GlobalTrader.DAL.AddressDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Address.GetForCompany(companyAddressId);
			if (objDetails == null) {
				return null;
			} else {
				Address obj = new Address();
				obj.AddressId = objDetails.AddressId;
				obj.AddressName = objDetails.AddressName;
				obj.Line1 = objDetails.Line1;
				obj.Line2 = objDetails.Line2;
				obj.Line3 = objDetails.Line3;
				obj.County = objDetails.County;
				obj.City = objDetails.City;
				obj.State = objDetails.State;
				obj.ZIP = objDetails.ZIP;
				obj.Inactive = objDetails.Inactive;
				obj.DLUP = objDetails.DLUP;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.CompanyAddressId = objDetails.CompanyAddressId;
				obj.DefaultBilling = objDetails.DefaultBilling;
				obj.DefaultShipping = objDetails.DefaultShipping;
				obj.CeaseDate = objDetails.CeaseDate;
				obj.ShipViaNo = objDetails.ShipViaNo;
				obj.ShipViaAccount = objDetails.ShipViaAccount;
				obj.Notes = objDetails.Notes;
				obj.ShippingNotes = objDetails.ShippingNotes;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CountryNo = objDetails.CountryNo;
				obj.CountryName = objDetails.CountryName;
				obj.ShipViaName = objDetails.ShipViaName;
                // [001] code start
                obj.TaxbyAddress = objDetails.TaxbyAddress;
                obj.TaxValue = objDetails.TaxValue; 
                // End
                //[002] code start
                obj.IncotermNo = objDetails.IncotermNo;
                obj.IncotermName = objDetails.IncotermName;
                //[002] code end
                obj.VatNo = objDetails.VatNo;
                obj.RecievingNotes = objDetails.RecievingNotes;
                objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForDivision
		/// Calls [usp_select_Address_for_Division]
		/// </summary>
		public static Address GetForDivision(System.Int32? divisionId) {
			Rebound.GlobalTrader.DAL.AddressDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Address.GetForDivision(divisionId);
			if (objDetails == null) {
				return null;
			} else {
				Address obj = new Address();
				obj.AddressId = objDetails.AddressId;
				obj.AddressName = objDetails.AddressName;
				obj.Line1 = objDetails.Line1;
				obj.Line2 = objDetails.Line2;
				obj.Line3 = objDetails.Line3;
				obj.County = objDetails.County;
				obj.City = objDetails.City;
				obj.State = objDetails.State;
				obj.CountryNo = objDetails.CountryNo;
				obj.ZIP = objDetails.ZIP;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.CountryName = objDetails.CountryName;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForWarehouse
		/// Calls [usp_select_Address_for_Warehouse]
		/// </summary>
		public static Address GetForWarehouse(System.Int32? warehouseId) {
			Rebound.GlobalTrader.DAL.AddressDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Address.GetForWarehouse(warehouseId);
			if (objDetails == null) {
				return null;
			} else {
				Address obj = new Address();
				obj.AddressId = objDetails.AddressId;
				obj.AddressName = objDetails.AddressName;
				obj.Line1 = objDetails.Line1;
				obj.Line2 = objDetails.Line2;
				obj.Line3 = objDetails.Line3;
				obj.County = objDetails.County;
				obj.City = objDetails.City;
				obj.State = objDetails.State;
				obj.CountryNo = objDetails.CountryNo;
				obj.ZIP = objDetails.ZIP;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.CountryName = objDetails.CountryName;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForCompany
		/// Calls [usp_selectAll_Address_for_Company]
		/// </summary>
		public static List<Address> GetListForCompany(System.Int32? companyId) {
			List<AddressDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Address.GetListForCompany(companyId);
			if (lstDetails == null) {
				return new List<Address>();
			} else {
				List<Address> lst = new List<Address>();
				foreach (AddressDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Address obj = new Rebound.GlobalTrader.BLL.Address();
					obj.AddressId = objDetails.AddressId;
					obj.AddressName = objDetails.AddressName;
					obj.Line1 = objDetails.Line1;
					obj.Line2 = objDetails.Line2;
					obj.Line3 = objDetails.Line3;
					obj.County = objDetails.County;
					obj.City = objDetails.City;
					obj.State = objDetails.State;
					obj.ZIP = objDetails.ZIP;
					obj.Inactive = objDetails.Inactive;
					obj.DLUP = objDetails.DLUP;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.CompanyAddressId = objDetails.CompanyAddressId;
					obj.DefaultBilling = objDetails.DefaultBilling;
					obj.DefaultShipping = objDetails.DefaultShipping;
					obj.CeaseDate = objDetails.CeaseDate;
					obj.ShipViaNo = objDetails.ShipViaNo;
					obj.ShipViaAccount = objDetails.ShipViaAccount;
					obj.Notes = objDetails.Notes;
					obj.ShippingNotes = objDetails.ShippingNotes;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CountryNo = objDetails.CountryNo;
					obj.CountryName = objDetails.CountryName;
					obj.ShipViaName = objDetails.ShipViaName;
                    // [001] code start
                    obj.TaxbyAddress = objDetails.TaxbyAddress;
                    obj.TaxValue = objDetails.TaxValue;  
                    // End
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_Address]
		/// </summary>
		public static bool Update(System.Int32? addressId, System.String addressName, System.String line1, System.String line2, System.String line3, System.String county, System.String city, System.String state, System.Int32? countryNo, System.String zip, System.Boolean? inactive, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Address.Update(addressId, addressName, line1, line2, line3, county, city, state, countryNo, zip, inactive, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Address]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Address.Update(AddressId, AddressName, Line1, Line2, Line3, County, City, State, CountryNo, ZIP, Inactive, UpdatedBy);
		}

        private static Address PopulateFromDBDetailsObject(AddressDetails obj) {
            Address objNew = new Address();
			objNew.AddressId = obj.AddressId;
			objNew.AddressName = obj.AddressName;
			objNew.Line1 = obj.Line1;
			objNew.Line2 = obj.Line2;
			objNew.Line3 = obj.Line3;
			objNew.County = obj.County;
			objNew.City = obj.City;
			objNew.State = obj.State;
			objNew.CountryNo = obj.CountryNo;
			objNew.ZIP = obj.ZIP;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.CountryName = obj.CountryName;
			objNew.CompanyAddressId = obj.CompanyAddressId;
			objNew.DefaultBilling = obj.DefaultBilling;
			objNew.DefaultShipping = obj.DefaultShipping;
			objNew.CeaseDate = obj.CeaseDate;
			objNew.ShipViaNo = obj.ShipViaNo;
			objNew.ShipViaAccount = obj.ShipViaAccount;
			objNew.Notes = obj.Notes;
			objNew.ShippingNotes = obj.ShippingNotes;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.ShipViaName = obj.ShipViaName;
            /// /// ESMS #14
            objNew.TaxbyAddress = obj.TaxbyAddress;
            // End
            return objNew;
        }
		
		#endregion
		
	}
}