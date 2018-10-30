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
		public partial class Country : BizObject {
		
		#region Properties

		protected static DAL.CountryElement Settings {
			get { return Globals.Settings.Countrys; }
		}

		/// <summary>
		/// CountryId
		/// </summary>
		public System.Int32 CountryId { get; set; }		
		/// <summary>
		/// CountryName
		/// </summary>
		public System.String CountryName { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// TelephonePrefix
		/// </summary>
		public System.String TelephonePrefix { get; set; }		
		/// <summary>
		/// Duty
		/// </summary>
		public System.Boolean Duty { get; set; }		
		/// <summary>
		/// TaxNo
		/// </summary>
		public System.Int32? TaxNo { get; set; }		
		/// <summary>
		/// ShippingCost
		/// </summary>
		public System.Double? ShippingCost { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// GlobalCountryNo
		/// </summary>
		public System.Int32? GlobalCountryNo { get; set; }		
		/// <summary>
		/// DeliveryLeadTimeAir
		/// </summary>
		public System.Int32? DeliveryLeadTimeAir { get; set; }		
		/// <summary>
		/// DeliveryLeadTimeSurface
		/// </summary>
		public System.Int32? DeliveryLeadTimeSurface { get; set; }		
		/// <summary>
		/// IsPriorityForLists
		/// </summary>
		public System.Boolean IsPriorityForLists { get; set; }		
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
		/// TaxName
		/// </summary>
		public System.String TaxName { get; set; }
        /// <summary>
        /// RegionId (from Table)
        /// </summary>
        public System.Int32 RegionId { get; set; }
        /// <summary>
        /// RegionName 
        /// </summary>
        public System.String RegionName { get; set; }
        /// <summary>
        /// ShipSurchargePer
        /// </summary>
        public System.Double? ShipSurchargePer { get; set; }

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Country]
		/// </summary>
		public static bool Delete(System.Int32? countryId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Country.Delete(countryId);
		}
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_Country_for_Client]
		/// </summary>
		public static List<Country> DropDownForClient(System.Int32? clientId) {
			List<CountryDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Country.DropDownForClient(clientId);
			if (lstDetails == null) {
				return new List<Country>();
			} else {
				List<Country> lst = new List<Country>();
				foreach (CountryDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Country obj = new Rebound.GlobalTrader.BLL.Country();
					obj.CountryId = objDetails.CountryId;
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
		/// Calls [usp_insert_Country]
		/// </summary>
		public static Int32 Insert(System.String countryName, System.String notes, System.String telephonePrefix, System.Boolean? duty, System.Int32? taxNo, System.Double? shippingCost, System.Int32? clientNo, System.Int32? globalCountryNo, System.Int32? deliveryLeadTimeAir, System.Int32? deliveryLeadTimeSurface, System.Boolean? isPriorityForLists, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Country.Insert(countryName, notes, telephonePrefix, duty, taxNo, shippingCost, clientNo, globalCountryNo, deliveryLeadTimeAir, deliveryLeadTimeSurface, isPriorityForLists, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Country]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Country.Insert(CountryName, Notes, TelephonePrefix, Duty, TaxNo, ShippingCost, ClientNo, GlobalCountryNo, DeliveryLeadTimeAir, DeliveryLeadTimeSurface, IsPriorityForLists, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_Country]
		/// </summary>
		public static Country Get(System.Int32? countryId) {
			Rebound.GlobalTrader.DAL.CountryDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Country.Get(countryId);
			if (objDetails == null) {
				return null;
			} else {
				Country obj = new Country();
				obj.CountryId = objDetails.CountryId;
				obj.CountryName = objDetails.CountryName;
				obj.Notes = objDetails.Notes;
				obj.TelephonePrefix = objDetails.TelephonePrefix;
				obj.Duty = objDetails.Duty;
				obj.TaxNo = objDetails.TaxNo;
				obj.ShippingCost = objDetails.ShippingCost;
				obj.ClientNo = objDetails.ClientNo;
				obj.GlobalCountryNo = objDetails.GlobalCountryNo;
				obj.DeliveryLeadTimeAir = objDetails.DeliveryLeadTimeAir;
				obj.DeliveryLeadTimeSurface = objDetails.DeliveryLeadTimeSurface;
				obj.IsPriorityForLists = objDetails.IsPriorityForLists;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.TaxName = objDetails.TaxName;
                obj.ShipSurchargePer = objDetails.ShipSurchargePer;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetShippingCost
		/// Calls [usp_select_Country_ShippingCost]
		/// </summary>
		public static Country GetShippingCost(System.Int32? countryId) {
			Rebound.GlobalTrader.DAL.CountryDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Country.GetShippingCost(countryId);
			if (objDetails == null) {
				return null;
			} else {
				Country obj = new Country();
				obj.ShippingCost = objDetails.ShippingCost;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_Country_for_Client]
		/// </summary>
		public static List<Country> GetListForClient(System.Int32? clientId) {
			List<CountryDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Country.GetListForClient(clientId);
			if (lstDetails == null) {
				return new List<Country>();
			} else {
				List<Country> lst = new List<Country>();
				foreach (CountryDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Country obj = new Rebound.GlobalTrader.BLL.Country();
					obj.CountryId = objDetails.CountryId;
					obj.CountryName = objDetails.CountryName;
					obj.Notes = objDetails.Notes;
					obj.TelephonePrefix = objDetails.TelephonePrefix;
					obj.Duty = objDetails.Duty;
					obj.TaxNo = objDetails.TaxNo;
					obj.ShippingCost = objDetails.ShippingCost;
					obj.ClientNo = objDetails.ClientNo;
					obj.GlobalCountryNo = objDetails.GlobalCountryNo;
					obj.DeliveryLeadTimeAir = objDetails.DeliveryLeadTimeAir;
					obj.DeliveryLeadTimeSurface = objDetails.DeliveryLeadTimeSurface;
					obj.IsPriorityForLists = objDetails.IsPriorityForLists;
					obj.Inactive = objDetails.Inactive;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.TaxName = objDetails.TaxName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_Country]
		/// </summary>
		public static bool Update(System.Int32? countryId, System.String countryName, System.String notes, System.String telephonePrefix, System.Boolean? duty, System.Int32? taxNo, System.Double? shippingCost, System.Int32? deliveryLeadTimeAir, System.Int32? deliveryLeadTimeSurface, System.Boolean? isPriorityForLists, System.Boolean? inactive, System.Int32? updatedBy,System.Double? shipSurChargePer) {
            return Rebound.GlobalTrader.DAL.SiteProvider.Country.Update(countryId, countryName, notes, telephonePrefix, duty, taxNo, shippingCost, deliveryLeadTimeAir, deliveryLeadTimeSurface, isPriorityForLists, inactive, updatedBy, shipSurChargePer);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Country]
		/// </summary>
		public bool Update() {
            return Rebound.GlobalTrader.DAL.SiteProvider.Country.Update(CountryId, CountryName, Notes, TelephonePrefix, Duty, TaxNo, ShippingCost, DeliveryLeadTimeAir, DeliveryLeadTimeSurface, IsPriorityForLists, Inactive, UpdatedBy, ShipSurchargePer);
		}

        private static Country PopulateFromDBDetailsObject(CountryDetails obj) {
            Country objNew = new Country();
			objNew.CountryId = obj.CountryId;
			objNew.CountryName = obj.CountryName;
			objNew.Notes = obj.Notes;
			objNew.TelephonePrefix = obj.TelephonePrefix;
			objNew.Duty = obj.Duty;
			objNew.TaxNo = obj.TaxNo;
			objNew.ShippingCost = obj.ShippingCost;
			objNew.ClientNo = obj.ClientNo;
			objNew.GlobalCountryNo = obj.GlobalCountryNo;
			objNew.DeliveryLeadTimeAir = obj.DeliveryLeadTimeAir;
			objNew.DeliveryLeadTimeSurface = obj.DeliveryLeadTimeSurface;
			objNew.IsPriorityForLists = obj.IsPriorityForLists;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.TaxName = obj.TaxName;
            return objNew;
        }

        /// <summary>
        /// DropDown for Region
        /// Calls [usp_dropdown_Region]
        /// </summary>
        public static List<Country> DropDownForRegion()
        {
            List<CountryDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Country.DropDownForRegion();
            if (lstDetails == null)
            {
                return new List<Country>();
            }
            else
            {
                List<Country> lst = new List<Country>();
                foreach (CountryDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Country obj = new Rebound.GlobalTrader.BLL.Country();
                    obj.RegionId = objDetails.RegionId;
                    obj.RegionName = objDetails.RegionName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
		#endregion
		
	}
}