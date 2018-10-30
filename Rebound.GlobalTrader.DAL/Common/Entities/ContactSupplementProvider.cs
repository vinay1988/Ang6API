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
	
	public abstract class ContactSupplementProvider : DataAccess {
		static private ContactSupplementProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ContactSupplementProvider Instance {
			get {
				if (_instance == null) _instance = (ContactSupplementProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.ContactSupplements.ProviderType));
				return _instance;
			}
		}
		public ContactSupplementProvider() {
			this.ConnectionString = Globals.Settings.ContactSupplements.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_ContactSupplement]
		/// </summary>
		public abstract bool Delete(System.Int32? contactNo);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_ContactSupplement]
		/// </summary>
		public abstract Int32 Insert(System.Int32? contactNo, System.Int32? genderNo, System.DateTime? birthday, System.Int32? maritalStatusNo, System.String partnerName, System.DateTime? partnerBirthday, System.DateTime? anniversary, System.Int32? numberOfChildren, System.String childName1, System.Int32? childGenderNo1, System.DateTime? childBirthday1, System.String childName2, System.Int32? childGenderNo2, System.DateTime? childBirthday2, System.String childName3, System.Int32? childGenderNo3, System.DateTime? childBirthday3, System.String personalCellphone, System.String favouriteSport, System.String favouriteTeam, System.String hobbies, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_ContactSupplement]
		/// </summary>
		public abstract ContactSupplementDetails Get(System.Int32? contactNo);
		/// <summary>
		/// Update
		/// Calls [usp_update_ContactSupplement]
		/// </summary>
		public abstract bool Update(System.Int32? contactNo, System.Int32? genderNo, System.DateTime? birthday, System.Int32? maritalStatusNo, System.String partnerName, System.DateTime? partnerBirthday, System.DateTime? anniversary, System.Int32? numberOfChildren, System.String childName1, System.Int32? childGenderNo1, System.DateTime? childBirthday1, System.String childName2, System.Int32? childGenderNo2, System.DateTime? childBirthday2, System.String childName3, System.Int32? childGenderNo3, System.DateTime? childBirthday3, System.String personalCellphone, System.String favouriteSport, System.String favouriteTeam, System.String hobbies, System.Boolean? inactive, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new ContactSupplementDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ContactSupplementDetails GetContactSupplementFromReader(DbDataReader reader) {
			ContactSupplementDetails contactSupplement = new ContactSupplementDetails();
			if (reader.HasRows) {
				contactSupplement.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0); //From: [Table]
				contactSupplement.Birthday = GetReaderValue_NullableDateTime(reader, "Birthday", null); //From: [Table]
				contactSupplement.PartnerName = GetReaderValue_String(reader, "PartnerName", ""); //From: [Table]
				contactSupplement.PartnerBirthday = GetReaderValue_NullableDateTime(reader, "PartnerBirthday", null); //From: [Table]
				contactSupplement.Anniversary = GetReaderValue_NullableDateTime(reader, "Anniversary", null); //From: [Table]
				contactSupplement.NumberOfChildren = GetReaderValue_NullableInt32(reader, "NumberOfChildren", null); //From: [Table]
				contactSupplement.ChildName1 = GetReaderValue_String(reader, "ChildName1", ""); //From: [Table]
				contactSupplement.ChildBirthday1 = GetReaderValue_NullableDateTime(reader, "ChildBirthday1", null); //From: [Table]
				contactSupplement.ChildName2 = GetReaderValue_String(reader, "ChildName2", ""); //From: [Table]
				contactSupplement.ChildBirthday2 = GetReaderValue_NullableDateTime(reader, "ChildBirthday2", null); //From: [Table]
				contactSupplement.ChildName3 = GetReaderValue_String(reader, "ChildName3", ""); //From: [Table]
				contactSupplement.ChildBirthday3 = GetReaderValue_NullableDateTime(reader, "ChildBirthday3", null); //From: [Table]
				contactSupplement.PersonalCellphone = GetReaderValue_String(reader, "PersonalCellphone", ""); //From: [Table]
				contactSupplement.FavouriteSport = GetReaderValue_String(reader, "FavouriteSport", ""); //From: [Table]
				contactSupplement.FavouriteTeam = GetReaderValue_String(reader, "FavouriteTeam", ""); //From: [Table]
				contactSupplement.Hobbies = GetReaderValue_String(reader, "Hobbies", ""); //From: [Table]
				contactSupplement.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				contactSupplement.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				contactSupplement.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				contactSupplement.GenderNo = GetReaderValue_NullableInt32(reader, "GenderNo", null); //From: [Table]
				contactSupplement.MaritalStatusNo = GetReaderValue_NullableInt32(reader, "MaritalStatusNo", null); //From: [Table]
				contactSupplement.ChildGenderNo1 = GetReaderValue_NullableInt32(reader, "ChildGenderNo1", null); //From: [Table]
				contactSupplement.ChildGenderNo2 = GetReaderValue_NullableInt32(reader, "ChildGenderNo2", null); //From: [Table]
				contactSupplement.ChildGenderNo3 = GetReaderValue_NullableInt32(reader, "ChildGenderNo3", null); //From: [Table]
				contactSupplement.MaritalStatusName = GetReaderValue_String(reader, "MaritalStatusName", ""); //From: [usp_select_ContactSupplement]
			}
			return contactSupplement;
		}
	
		/// <summary>
		/// Returns a collection of ContactSupplementDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ContactSupplementDetails> GetContactSupplementCollectionFromReader(DbDataReader reader) {
			List<ContactSupplementDetails> contactSupplements = new List<ContactSupplementDetails>();
			while (reader.Read()) contactSupplements.Add(GetContactSupplementFromReader(reader));
			return contactSupplements;
		}
		
		
	}
}