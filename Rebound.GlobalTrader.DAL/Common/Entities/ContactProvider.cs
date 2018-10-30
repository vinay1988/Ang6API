//Marker     Changed by      Date         Remarks
//[001]      Vinay           09/07/2012   This need for Rebound- Invoice bulk Emailer
//[002]      Aashu Singh     13-Sep-2018  [REB-12820]:Provision to add Global Security on Contact Section
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
	
	public abstract class ContactProvider : DataAccess {
		static private ContactProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ContactProvider Instance {
			get {
				if (_instance == null) _instance = (ContactProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Contacts.ProviderType));
				return _instance;
			}
		}
		public ContactProvider() {
			this.ConnectionString = Globals.Settings.Contacts.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// AutoSearch
		/// Calls [usp_autosearch_Contact]
		/// </summary>
		public abstract List<ContactDetails> AutoSearch(System.Int32? clientId, System.String nameSearch);
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_Contact_for_Client]
		/// </summary>
		public abstract Int32 CountForClient(System.Int32? clientId);
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_Contact]
		/// </summary>
        //[002] start
        public abstract List<ContactDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String firstNameSearch, System.String lastNameSearch, System.String companyNameSearch, System.Int32? salesmanSearch, System.String telNo, Boolean IsGlobalLogin, System.Int32? clientSearch);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Contact]
		/// </summary>
		public abstract bool Delete(System.Int32? contactId);
		/// <summary>
		/// DropDownForCompany
		/// Calls [usp_dropdown_Contact_for_Company]
		/// </summary>
		public abstract List<ContactDetails> DropDownForCompany(System.Int32? companyId);
        //[001] code start
        /// <summary>
        /// Insert
        /// Calls [usp_insert_Contact]
        /// </summary>
        public abstract Int32 Insert(System.String contactName, System.String salutation, System.String firstName, System.String lastName, System.String telephone, System.String extension, System.String fax, System.String title, System.String email, System.String homeTelephone, System.String mobileTelephone, System.Int32? companyNo, System.String notes, System.Int32? addressNo, System.Boolean? textOnlyEmail, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? FinanceContact);
        //[001] code end
		/// <summary>
		/// Get
		/// Calls [usp_select_Contact]
		/// </summary>
		public abstract ContactDetails Get(System.Int32? contactId);
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_Contact_for_Page]
		/// </summary>
		public abstract ContactDetails GetForPage(System.Int32? contactId);
		/// <summary>
		/// GetListForCompany
		/// Calls [usp_selectAll_Contact_for_Company]
		/// </summary>
		public abstract List<ContactDetails> GetListForCompany(System.Int32? companyId);
        //[001] code start
        /// <summary>
        /// Update
        /// Calls [usp_update_Contact]
        /// </summary>
        public abstract bool Update(System.Int32? contactId, System.String contactName, System.String salutation, System.String firstName, System.String lastName, System.String telephone, System.String extension, System.String fax, System.String title, System.String email, System.String homeTelephone, System.String mobileTelephone, System.Int32? companyNo, System.String notes, System.Int32? addressNo, System.Boolean? textOnlyEmail, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? FinanceContact);
        //[001] code end
		#endregion
				
		/// <summary>
		/// Returns a new ContactDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ContactDetails GetContactFromReader(DbDataReader reader) {
			ContactDetails contact = new ContactDetails();
			if (reader.HasRows) {
				contact.ContactId = GetReaderValue_Int32(reader, "ContactId", 0); //From: [Table]
				contact.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [Table]
				contact.Salutation = GetReaderValue_String(reader, "Salutation", ""); //From: [Table]
				contact.FirstName = GetReaderValue_String(reader, "FirstName", ""); //From: [Table]
				contact.LastName = GetReaderValue_String(reader, "LastName", ""); //From: [Table]
				contact.Telephone = GetReaderValue_String(reader, "Telephone", ""); //From: [Table]
				contact.Extension = GetReaderValue_String(reader, "Extension", ""); //From: [Table]
				contact.Fax = GetReaderValue_String(reader, "Fax", ""); //From: [Table]
				contact.Title = GetReaderValue_String(reader, "Title", ""); //From: [Table]
				contact.EMail = GetReaderValue_String(reader, "EMail", ""); //From: [Table]
				contact.HomeTelephone = GetReaderValue_String(reader, "HomeTelephone", ""); //From: [Table]
				contact.MobileTelephone = GetReaderValue_String(reader, "MobileTelephone", ""); //From: [Table]
				contact.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null); //From: [Table]
				contact.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				contact.AddressNo = GetReaderValue_NullableInt32(reader, "AddressNo", null); //From: [Table]
				contact.ContactPositionNo = GetReaderValue_NullableInt32(reader, "ContactPositionNo", null); //From: [Table]
				contact.TextOnlyEmail = GetReaderValue_NullableBoolean(reader, "TextOnlyEmail", null); //From: [Table]
				contact.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				contact.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				contact.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				contact.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_datalistnugget_Contact]
				contact.SalesmanName = GetReaderValue_String(reader, "SalesmanName", ""); //From: [usp_datalistnugget_Contact]
				contact.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_datalistnugget_Contact]
				contact.FullName = GetReaderValue_String(reader, "FullName", ""); //From: [usp_select_Contact]
				contact.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [usp_select_Contact]
				contact.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null); //From: [usp_select_Contact]
				contact.DefaultPOContactNo = GetReaderValue_NullableInt32(reader, "DefaultPOContactNo", null); //From: [usp_select_Contact]
				contact.DefaultSOContactNo = GetReaderValue_NullableInt32(reader, "DefaultSOContactNo", null); //From: [usp_select_Contact]
				contact.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null); //From: [usp_select_Contact]
				contact.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null); //From: [usp_select_Contact]
				contact.HasSupplementalData = GetReaderValue_Int32(reader, "HasSupplementalData", 0); //From: [usp_select_Contact]
				contact.HasUserDefinedData = GetReaderValue_Int32(reader, "HasUserDefinedData", 0); //From: [usp_select_Contact]
				contact.DefaultPO = GetReaderValue_NullableBoolean(reader, "DefaultPO", null); //From: [usp_selectAll_Contact_for_Company]
				contact.DefaultSO = GetReaderValue_NullableBoolean(reader, "DefaultSO", null); //From: [usp_selectAll_Contact_for_Company]
			}
			return contact;
		}
	
		/// <summary>
		/// Returns a collection of ContactDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ContactDetails> GetContactCollectionFromReader(DbDataReader reader) {
			List<ContactDetails> contacts = new List<ContactDetails>();
			while (reader.Read()) contacts.Add(GetContactFromReader(reader));
			return contacts;
		}
		
		
	}
}