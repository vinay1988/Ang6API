/*
Marker     Changed by      Date         Remarks
[001]      Vinay           11/06/2012   This need to Add Incoterms field in company section
[002]      Vinay           13/03/2014   EMS Ref No: 104
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
		public partial class CompanyAddress : BizObject {
		
		#region Properties

		protected static DAL.CompanyAddressElement Settings {
			get { return Globals.Settings.CompanyAddresss; }
		}

		/// <summary>
		/// CompanyAddressId
		/// </summary>
		public System.Int32 CompanyAddressId { get; set; }		
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32 CompanyNo { get; set; }		
		/// <summary>
		/// AddressNo
		/// </summary>
		public System.Int32 AddressNo { get; set; }		
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
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// DefaultBilling
		/// </summary>
		public System.Boolean DefaultBilling { get; set; }		
		/// <summary>
		/// DefaultShipping
		/// </summary>
		public System.Boolean DefaultShipping { get; set; }		
		/// <summary>
		/// ShippingNotes
		/// </summary>
		public System.String ShippingNotes { get; set; }
        /// <summary>
        /// TaxbyAddress
        /// </summary>
        public System.Int32? TaxbyAddress { get; set; }
        //[001] code start
        /// <summary>
        /// IncotermNo
        /// </summary>
        public System.Int32? IncotermNo { get; set; }
        //[001] code end
        //[002] code star
        public System.String VatNo { get; set; }
        //[002] code end
        public System.String RecievingNotes { get; set; }

		#endregion
		
		#region Methods
        //[001] code start
		/// <summary>
		/// Insert
		/// Calls [usp_insert_CompanyAddress]
		/// </summary>
        /// //ESMS #14
        public static Int32 Insert(System.Int32? companyNo, System.Int32? addressNo, System.Int32? shipViaNo, System.String shipViaAccount, System.String notes, System.String shippingNotes, System.Int32? TaxbyAddress, System.Int32? updatedBy, System.Int32? IncotermNo, System.String vatNo, System.String recievingNotes)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CompanyAddress.Insert(companyNo, addressNo, shipViaNo, shipViaAccount, notes, shippingNotes, TaxbyAddress, updatedBy, IncotermNo, vatNo, recievingNotes);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_CompanyAddress]
		/// </summary>
        /// //ESMS #14
		public Int32 Insert() {
            return Rebound.GlobalTrader.DAL.SiteProvider.CompanyAddress.Insert(CompanyNo, AddressNo, ShipViaNo, ShipViaAccount, Notes, ShippingNotes, TaxbyAddress, UpdatedBy, IncotermNo, VatNo,RecievingNotes);
		}
        //[001] code end
		/// <summary>
		/// GetByAddress
		/// Calls [usp_select_CompanyAddress_by_Address]
		/// </summary>
		public static CompanyAddress GetByAddress(System.Int32? addressId) {
			Rebound.GlobalTrader.DAL.CompanyAddressDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CompanyAddress.GetByAddress(addressId);
			if (objDetails == null) {
				return null;
			} else {
				CompanyAddress obj = new CompanyAddress();
				obj.CompanyAddressId = objDetails.CompanyAddressId;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.AddressNo = objDetails.AddressNo;
				obj.CeaseDate = objDetails.CeaseDate;
				obj.ShipViaNo = objDetails.ShipViaNo;
				obj.ShipViaAccount = objDetails.ShipViaAccount;
				obj.Notes = objDetails.Notes;
                //ESMS #14
                obj.TaxbyAddress = objDetails.TaxbyAddress; 
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.DefaultBilling = objDetails.DefaultBilling;
				obj.DefaultShipping = objDetails.DefaultShipping;
				obj.ShippingNotes = objDetails.ShippingNotes;
				objDetails = null;
				return obj;
			}
		}
        //[001] code start
		/// <summary>
		/// Update
		/// Calls [usp_update_CompanyAddress]
		/// </summary>
        ///  /// //ESMS #14
		public static bool Update(System.Int32? companyAddressId, System.Int32? shipViaNo, System.String shipViaAccount, System.String notes, System.String shippingNotes, System.Int32? TaxbyAddress,  System.Int32? updatedBy,System.String vatNo,System.String recivingNotes) {
            return Rebound.GlobalTrader.DAL.SiteProvider.CompanyAddress.Update(companyAddressId, shipViaNo, shipViaAccount, notes, shippingNotes, TaxbyAddress, updatedBy, null, vatNo, recivingNotes);
		}
        
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_CompanyAddress]
		/// </summary>
        ///  /// //ESMS #14
		public bool Update() {
            return Rebound.GlobalTrader.DAL.SiteProvider.CompanyAddress.Update(CompanyAddressId, ShipViaNo, ShipViaAccount, Notes, ShippingNotes, TaxbyAddress, UpdatedBy, IncotermNo, VatNo, RecievingNotes);
		}
        //[001] code end
		/// <summary>
		/// UpdateCeaseDate
		/// Calls [usp_update_CompanyAddress_CeaseDate]
		/// </summary>
		public static bool UpdateCeaseDate(System.Int32? companyAddressNo, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CompanyAddress.UpdateCeaseDate(companyAddressNo, updatedBy);
		}
		/// <summary>
		/// UpdateCheckDefault
		/// Calls [usp_update_CompanyAddress_CheckDefault]
		/// </summary>
		public static bool UpdateCheckDefault(System.Int32? companyAddressId, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CompanyAddress.UpdateCheckDefault(companyAddressId, updatedBy);
		}
		/// <summary>
		/// UpdateDefaultBilling
		/// Calls [usp_update_CompanyAddress_DefaultBilling]
		/// </summary>
		public static bool UpdateDefaultBilling(System.Int32? companyAddressId, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CompanyAddress.UpdateDefaultBilling(companyAddressId, updatedBy);
		}
		/// <summary>
		/// UpdateDefaultShipping
		/// Calls [usp_update_CompanyAddress_DefaultShipping]
		/// </summary>
		public static bool UpdateDefaultShipping(System.Int32? companyAddressId, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CompanyAddress.UpdateDefaultShipping(companyAddressId, updatedBy);
		}

        private static CompanyAddress PopulateFromDBDetailsObject(CompanyAddressDetails obj) {
            CompanyAddress objNew = new CompanyAddress();
			objNew.CompanyAddressId = obj.CompanyAddressId;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.AddressNo = obj.AddressNo;
			objNew.CeaseDate = obj.CeaseDate;
			objNew.ShipViaNo = obj.ShipViaNo;
			objNew.ShipViaAccount = obj.ShipViaAccount;
			objNew.Notes = obj.Notes;
			objNew.UpdatedBy = obj.UpdatedBy;
            // ESMS #14
            objNew.TaxbyAddress = obj.TaxbyAddress; 
            //end
			objNew.DLUP = obj.DLUP;
			objNew.DefaultBilling = obj.DefaultBilling;
			objNew.DefaultShipping = obj.DefaultShipping;
			objNew.ShippingNotes = obj.ShippingNotes;
            return objNew;
        }
		
		#endregion
		
	}
}