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
		public partial class ContactUserDefined : BizObject {
		
		#region Properties

		protected static DAL.ContactUserDefinedElement Settings {
			get { return Globals.Settings.ContactUserDefineds; }
		}

		/// <summary>
		/// ContactNo
		/// </summary>
		public System.Int32 ContactNo { get; set; }		
		/// <summary>
		/// RowNo
		/// </summary>
		public System.Int32 RowNo { get; set; }		
		/// <summary>
		/// UserDefinedHeading
		/// </summary>
		public System.String UserDefinedHeading { get; set; }		
		/// <summary>
		/// UserDefinedValue
		/// </summary>
		public System.String UserDefinedValue { get; set; }		
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

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_ContactUserDefined]
		/// </summary>
		public static bool Delete(System.Int32? contactNo, System.Int32? rowNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.ContactUserDefined.Delete(contactNo, rowNo);
		}
		/// <summary>
		/// DeleteForContact
		/// Calls [usp_delete_ContactUserDefined_for_Contact]
		/// </summary>
		public static bool DeleteForContact(System.Int32? contactNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.ContactUserDefined.DeleteForContact(contactNo);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_ContactUserDefined]
		/// </summary>
		public static Int32 Insert(System.Int32? contactNo, System.Int32? rowNo, System.String userDefinedHeading, System.String userDefinedValue, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.ContactUserDefined.Insert(contactNo, rowNo, userDefinedHeading, userDefinedValue, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_ContactUserDefined]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.ContactUserDefined.Insert(ContactNo, RowNo, UserDefinedHeading, UserDefinedValue, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_ContactUserDefined]
		/// </summary>
		public static ContactUserDefined Get(System.Int32? contactNo, System.Int32? rowNo) {
			Rebound.GlobalTrader.DAL.ContactUserDefinedDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.ContactUserDefined.Get(contactNo, rowNo);
			if (objDetails == null) {
				return null;
			} else {
				ContactUserDefined obj = new ContactUserDefined();
				obj.ContactNo = objDetails.ContactNo;
				obj.RowNo = objDetails.RowNo;
				obj.UserDefinedHeading = objDetails.UserDefinedHeading;
				obj.UserDefinedValue = objDetails.UserDefinedValue;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForContact
		/// Calls [usp_selectAll_ContactUserDefined_for_Contact]
		/// </summary>
		public static List<ContactUserDefined> GetListForContact(System.Int32? contactNo) {
			List<ContactUserDefinedDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ContactUserDefined.GetListForContact(contactNo);
			if (lstDetails == null) {
				return new List<ContactUserDefined>();
			} else {
				List<ContactUserDefined> lst = new List<ContactUserDefined>();
				foreach (ContactUserDefinedDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.ContactUserDefined obj = new Rebound.GlobalTrader.BLL.ContactUserDefined();
					obj.ContactNo = objDetails.ContactNo;
					obj.RowNo = objDetails.RowNo;
					obj.UserDefinedHeading = objDetails.UserDefinedHeading;
					obj.UserDefinedValue = objDetails.UserDefinedValue;
					obj.Inactive = objDetails.Inactive;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_ContactUserDefined]
		/// </summary>
		public static bool Update(System.Int32? contactNo, System.Int32? rowNo, System.String userDefinedHeading, System.String userDefinedValue, System.Boolean? inactive, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.ContactUserDefined.Update(contactNo, rowNo, userDefinedHeading, userDefinedValue, inactive, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_ContactUserDefined]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.ContactUserDefined.Update(ContactNo, RowNo, UserDefinedHeading, UserDefinedValue, Inactive, UpdatedBy);
		}

        private static ContactUserDefined PopulateFromDBDetailsObject(ContactUserDefinedDetails obj) {
            ContactUserDefined objNew = new ContactUserDefined();
			objNew.ContactNo = obj.ContactNo;
			objNew.RowNo = obj.RowNo;
			objNew.UserDefinedHeading = obj.UserDefinedHeading;
			objNew.UserDefinedValue = obj.UserDefinedValue;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
            return objNew;
        }
		
		#endregion
		
	}
}