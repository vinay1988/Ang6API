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
		public partial class ContactSupplement : BizObject {
		
		#region Properties

		protected static DAL.ContactSupplementElement Settings {
			get { return Globals.Settings.ContactSupplements; }
		}

		/// <summary>
		/// ContactNo
		/// </summary>
		public System.Int32 ContactNo { get; set; }		
		/// <summary>
		/// Birthday
		/// </summary>
		public System.DateTime? Birthday { get; set; }		
		/// <summary>
		/// PartnerName
		/// </summary>
		public System.String PartnerName { get; set; }		
		/// <summary>
		/// PartnerBirthday
		/// </summary>
		public System.DateTime? PartnerBirthday { get; set; }		
		/// <summary>
		/// Anniversary
		/// </summary>
		public System.DateTime? Anniversary { get; set; }		
		/// <summary>
		/// NumberOfChildren
		/// </summary>
		public System.Int32? NumberOfChildren { get; set; }		
		/// <summary>
		/// ChildName1
		/// </summary>
		public System.String ChildName1 { get; set; }		
		/// <summary>
		/// ChildBirthday1
		/// </summary>
		public System.DateTime? ChildBirthday1 { get; set; }		
		/// <summary>
		/// ChildName2
		/// </summary>
		public System.String ChildName2 { get; set; }		
		/// <summary>
		/// ChildBirthday2
		/// </summary>
		public System.DateTime? ChildBirthday2 { get; set; }		
		/// <summary>
		/// ChildName3
		/// </summary>
		public System.String ChildName3 { get; set; }		
		/// <summary>
		/// ChildBirthday3
		/// </summary>
		public System.DateTime? ChildBirthday3 { get; set; }		
		/// <summary>
		/// PersonalCellphone
		/// </summary>
		public System.String PersonalCellphone { get; set; }		
		/// <summary>
		/// FavouriteSport
		/// </summary>
		public System.String FavouriteSport { get; set; }		
		/// <summary>
		/// FavouriteTeam
		/// </summary>
		public System.String FavouriteTeam { get; set; }		
		/// <summary>
		/// Hobbies
		/// </summary>
		public System.String Hobbies { get; set; }		
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
		/// GenderNo
		/// </summary>
		public System.Int32? GenderNo { get; set; }		
		/// <summary>
		/// MaritalStatusNo
		/// </summary>
		public System.Int32? MaritalStatusNo { get; set; }		
		/// <summary>
		/// ChildGenderNo1
		/// </summary>
		public System.Int32? ChildGenderNo1 { get; set; }		
		/// <summary>
		/// ChildGenderNo2
		/// </summary>
		public System.Int32? ChildGenderNo2 { get; set; }		
		/// <summary>
		/// ChildGenderNo3
		/// </summary>
		public System.Int32? ChildGenderNo3 { get; set; }		
		/// <summary>
		/// MaritalStatusName
		/// </summary>
		public System.String MaritalStatusName { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_ContactSupplement]
		/// </summary>
		public static bool Delete(System.Int32? contactNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.ContactSupplement.Delete(contactNo);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_ContactSupplement]
		/// </summary>
		public static Int32 Insert(System.Int32? contactNo, System.Int32? genderNo, System.DateTime? birthday, System.Int32? maritalStatusNo, System.String partnerName, System.DateTime? partnerBirthday, System.DateTime? anniversary, System.Int32? numberOfChildren, System.String childName1, System.Int32? childGenderNo1, System.DateTime? childBirthday1, System.String childName2, System.Int32? childGenderNo2, System.DateTime? childBirthday2, System.String childName3, System.Int32? childGenderNo3, System.DateTime? childBirthday3, System.String personalCellphone, System.String favouriteSport, System.String favouriteTeam, System.String hobbies, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.ContactSupplement.Insert(contactNo, genderNo, birthday, maritalStatusNo, partnerName, partnerBirthday, anniversary, numberOfChildren, childName1, childGenderNo1, childBirthday1, childName2, childGenderNo2, childBirthday2, childName3, childGenderNo3, childBirthday3, personalCellphone, favouriteSport, favouriteTeam, hobbies, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_ContactSupplement]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.ContactSupplement.Insert(ContactNo, GenderNo, Birthday, MaritalStatusNo, PartnerName, PartnerBirthday, Anniversary, NumberOfChildren, ChildName1, ChildGenderNo1, ChildBirthday1, ChildName2, ChildGenderNo2, ChildBirthday2, ChildName3, ChildGenderNo3, ChildBirthday3, PersonalCellphone, FavouriteSport, FavouriteTeam, Hobbies, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_ContactSupplement]
		/// </summary>
		public static ContactSupplement Get(System.Int32? contactNo) {
			Rebound.GlobalTrader.DAL.ContactSupplementDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.ContactSupplement.Get(contactNo);
			if (objDetails == null) {
				return null;
			} else {
				ContactSupplement obj = new ContactSupplement();
				obj.ContactNo = objDetails.ContactNo;
				obj.Birthday = objDetails.Birthday;
				obj.PartnerName = objDetails.PartnerName;
				obj.PartnerBirthday = objDetails.PartnerBirthday;
				obj.Anniversary = objDetails.Anniversary;
				obj.NumberOfChildren = objDetails.NumberOfChildren;
				obj.ChildName1 = objDetails.ChildName1;
				obj.ChildBirthday1 = objDetails.ChildBirthday1;
				obj.ChildName2 = objDetails.ChildName2;
				obj.ChildBirthday2 = objDetails.ChildBirthday2;
				obj.ChildName3 = objDetails.ChildName3;
				obj.ChildBirthday3 = objDetails.ChildBirthday3;
				obj.PersonalCellphone = objDetails.PersonalCellphone;
				obj.FavouriteSport = objDetails.FavouriteSport;
				obj.FavouriteTeam = objDetails.FavouriteTeam;
				obj.Hobbies = objDetails.Hobbies;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.GenderNo = objDetails.GenderNo;
				obj.MaritalStatusNo = objDetails.MaritalStatusNo;
				obj.ChildGenderNo1 = objDetails.ChildGenderNo1;
				obj.ChildGenderNo2 = objDetails.ChildGenderNo2;
				obj.ChildGenderNo3 = objDetails.ChildGenderNo3;
				obj.MaritalStatusName = objDetails.MaritalStatusName;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_ContactSupplement]
		/// </summary>
		public static bool Update(System.Int32? contactNo, System.Int32? genderNo, System.DateTime? birthday, System.Int32? maritalStatusNo, System.String partnerName, System.DateTime? partnerBirthday, System.DateTime? anniversary, System.Int32? numberOfChildren, System.String childName1, System.Int32? childGenderNo1, System.DateTime? childBirthday1, System.String childName2, System.Int32? childGenderNo2, System.DateTime? childBirthday2, System.String childName3, System.Int32? childGenderNo3, System.DateTime? childBirthday3, System.String personalCellphone, System.String favouriteSport, System.String favouriteTeam, System.String hobbies, System.Boolean? inactive, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.ContactSupplement.Update(contactNo, genderNo, birthday, maritalStatusNo, partnerName, partnerBirthday, anniversary, numberOfChildren, childName1, childGenderNo1, childBirthday1, childName2, childGenderNo2, childBirthday2, childName3, childGenderNo3, childBirthday3, personalCellphone, favouriteSport, favouriteTeam, hobbies, inactive, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_ContactSupplement]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.ContactSupplement.Update(ContactNo, GenderNo, Birthday, MaritalStatusNo, PartnerName, PartnerBirthday, Anniversary, NumberOfChildren, ChildName1, ChildGenderNo1, ChildBirthday1, ChildName2, ChildGenderNo2, ChildBirthday2, ChildName3, ChildGenderNo3, ChildBirthday3, PersonalCellphone, FavouriteSport, FavouriteTeam, Hobbies, Inactive, UpdatedBy);
		}

        private static ContactSupplement PopulateFromDBDetailsObject(ContactSupplementDetails obj) {
            ContactSupplement objNew = new ContactSupplement();
			objNew.ContactNo = obj.ContactNo;
			objNew.Birthday = obj.Birthday;
			objNew.PartnerName = obj.PartnerName;
			objNew.PartnerBirthday = obj.PartnerBirthday;
			objNew.Anniversary = obj.Anniversary;
			objNew.NumberOfChildren = obj.NumberOfChildren;
			objNew.ChildName1 = obj.ChildName1;
			objNew.ChildBirthday1 = obj.ChildBirthday1;
			objNew.ChildName2 = obj.ChildName2;
			objNew.ChildBirthday2 = obj.ChildBirthday2;
			objNew.ChildName3 = obj.ChildName3;
			objNew.ChildBirthday3 = obj.ChildBirthday3;
			objNew.PersonalCellphone = obj.PersonalCellphone;
			objNew.FavouriteSport = obj.FavouriteSport;
			objNew.FavouriteTeam = obj.FavouriteTeam;
			objNew.Hobbies = obj.Hobbies;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.GenderNo = obj.GenderNo;
			objNew.MaritalStatusNo = obj.MaritalStatusNo;
			objNew.ChildGenderNo1 = obj.ChildGenderNo1;
			objNew.ChildGenderNo2 = obj.ChildGenderNo2;
			objNew.ChildGenderNo3 = obj.ChildGenderNo3;
			objNew.MaritalStatusName = obj.MaritalStatusName;
            return objNew;
        }
		
		#endregion
		
	}
}