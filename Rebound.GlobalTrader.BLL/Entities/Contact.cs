//Marker     Changed by      Date         Remarks
//[001]      Vinay           09/07/2012   This need for Rebound- Invoice bulk Emailer
//[002]      Vinay           04/10/2012   Degete Ref:#26#  - Add two more columns contact to identify Default Purchase ledger and Default Sales ledger
//[003]      Aashu Singh     13-Sep-2018  [REB-12820]:Provision to add Global Security on Contact Section
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
		public partial class Contact : BizObject {
		
		#region Properties

		protected static DAL.ContactElement Settings {
			get { return Globals.Settings.Contacts; }
		}

		/// <summary>
		/// ContactId
		/// </summary>
		public System.Int32 ContactId { get; set; }		
		/// <summary>
		/// ContactName
		/// </summary>
		public System.String ContactName { get; set; }		
		/// <summary>
		/// Salutation
		/// </summary>
		public System.String Salutation { get; set; }		
		/// <summary>
		/// FirstName
		/// </summary>
		public System.String FirstName { get; set; }		
		/// <summary>
		/// LastName
		/// </summary>
		public System.String LastName { get; set; }		
		/// <summary>
		/// Telephone
		/// </summary>
		public System.String Telephone { get; set; }		
		/// <summary>
		/// Extension
		/// </summary>
		public System.String Extension { get; set; }		
		/// <summary>
		/// Fax
		/// </summary>
		public System.String Fax { get; set; }		
		/// <summary>
		/// Title
		/// </summary>
		public System.String Title { get; set; }		
		/// <summary>
		/// EMail
		/// </summary>
		public System.String EMail { get; set; }		
		/// <summary>
		/// HomeTelephone
		/// </summary>
		public System.String HomeTelephone { get; set; }		
		/// <summary>
		/// MobileTelephone
		/// </summary>
		public System.String MobileTelephone { get; set; }		
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32? CompanyNo { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// AddressNo
		/// </summary>
		public System.Int32? AddressNo { get; set; }		
		/// <summary>
		/// ContactPositionNo
		/// </summary>
		public System.Int32? ContactPositionNo { get; set; }		
		/// <summary>
		/// TextOnlyEmail
		/// </summary>
		public System.Boolean? TextOnlyEmail { get; set; }		
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
		/// CompanyName
		/// </summary>
		public System.String CompanyName { get; set; }		
		/// <summary>
		/// SalesmanName
		/// </summary>
		public System.String SalesmanName { get; set; }		
		/// <summary>
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }		
		/// <summary>
		/// RowCnt
		/// </summary>
		public System.Int32? RowCnt { get; set; }		
		/// <summary>
		/// FullName
		/// </summary>
		public System.String FullName { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// Salesman
		/// </summary>
		public System.Int32? Salesman { get; set; }		
		/// <summary>
		/// DefaultPOContactNo
		/// </summary>
		public System.Int32? DefaultPOContactNo { get; set; }		
		/// <summary>
		/// DefaultSOContactNo
		/// </summary>
		public System.Int32? DefaultSOContactNo { get; set; }		
		/// <summary>
		/// TeamNo
		/// </summary>
		public System.Int32? TeamNo { get; set; }		
		/// <summary>
		/// DivisionNo
		/// </summary>
		public System.Int32? DivisionNo { get; set; }		
		/// <summary>
		/// HasSupplementalData
		/// </summary>
		public System.Int32 HasSupplementalData { get; set; }		
		/// <summary>
		/// HasUserDefinedData
		/// </summary>
		public System.Int32 HasUserDefinedData { get; set; }		
		/// <summary>
		/// DefaultPO
		/// </summary>
		public System.Boolean? DefaultPO { get; set; }		
		/// <summary>
		/// DefaultSO
		/// </summary>
		public System.Boolean? DefaultSO { get; set; }
        //[001] code start
        /// <summary>
        /// FinanceContact
        /// </summary>
        public System.Boolean? FinanceContact { get; set; }
        //[001] code end
        //[001] code end
        //[002] code start
        /// <summary>
        /// DefaultPOLedgerContactNo (from usp_select_Contact)
        /// </summary>
        public System.Int32? DefaultPOLedgerContactNo { get; set; }
        /// <summary>
        /// DefaultSOLedgerContactNo (from usp_select_Contact)
        /// </summary>
        public System.Int32? DefaultSOLedgerContactNo { get; set; }
        /// <summary>
        /// DefaultPOLedger (from usp_selectAll_Contact_for_Company)
        /// </summary>
        public System.Boolean? DefaultPOLedger { get; set; }
        /// <summary>
        /// DefaultSOLedger (from usp_selectAll_Contact_for_Company)
        /// </summary>
        public System.Boolean? DefaultSOLedger { get; set; }
        //[002] code end
		#endregion
		
		#region Methods
		
		/// <summary>
		/// AutoSearch
		/// Calls [usp_autosearch_Contact]
		/// </summary>
		public static List<Contact> AutoSearch(System.Int32? clientId, System.String nameSearch) {
			List<ContactDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Contact.AutoSearch(clientId, nameSearch);
			if (lstDetails == null) {
				return new List<Contact>();
			} else {
				List<Contact> lst = new List<Contact>();
				foreach (ContactDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Contact obj = new Rebound.GlobalTrader.BLL.Contact();
					obj.ContactId = objDetails.ContactId;
					obj.ContactName = objDetails.ContactName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_Contact_for_Client]
		/// </summary>
		public static Int32 CountForClient(System.Int32? clientId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Contact.CountForClient(clientId);
		}		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_Contact]
		/// </summary>
        //[003] start
        public static List<Contact> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String firstNameSearch, System.String lastNameSearch, System.String companyNameSearch, System.Int32? salesmanSearch, System.String telNo, Boolean IsGlobalLogin, System.Int32? clientSearch)
        {
            List<ContactDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Contact.DataListNugget(clientId, teamId, divisionId, loginId, orderBy, sortDir, pageIndex, pageSize, firstNameSearch, lastNameSearch, companyNameSearch, salesmanSearch, telNo, IsGlobalLogin, clientSearch);
			if (lstDetails == null) {
				return new List<Contact>();
			} else {
				List<Contact> lst = new List<Contact>();
				foreach (ContactDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Contact obj = new Rebound.GlobalTrader.BLL.Contact();
					obj.ContactId = objDetails.ContactId;
					obj.ContactName = objDetails.ContactName;
					obj.Title = objDetails.Title;
					obj.CompanyName = objDetails.CompanyName;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.Telephone = objDetails.Telephone;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Contact]
		/// </summary>
		public static bool Delete(System.Int32? contactId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Contact.Delete(contactId);
		}
		/// <summary>
		/// DropDownForCompany
		/// Calls [usp_dropdown_Contact_for_Company]
		/// </summary>
		public static List<Contact> DropDownForCompany(System.Int32? companyId) {
			List<ContactDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Contact.DropDownForCompany(companyId);
			if (lstDetails == null) {
				return new List<Contact>();
			} else {
				List<Contact> lst = new List<Contact>();
				foreach (ContactDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Contact obj = new Rebound.GlobalTrader.BLL.Contact();
					obj.ContactId = objDetails.ContactId;
					obj.ContactName = objDetails.ContactName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
        //[001] code start
        /// <summary>
        /// Insert
        /// Calls [usp_insert_Contact]
        /// </summary>
        public static Int32 Insert(System.String contactName, System.String salutation, System.String firstName, System.String lastName, System.String telephone, System.String extension, System.String fax, System.String title, System.String email, System.String homeTelephone, System.String mobileTelephone, System.Int32? companyNo, System.String notes, System.Int32? addressNo, System.Boolean? textOnlyEmail, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? FinanceContct)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Contact.Insert(contactName, salutation, firstName, lastName, telephone, extension, fax, title, email, homeTelephone, mobileTelephone, companyNo, notes, addressNo, textOnlyEmail, inactive, updatedBy, FinanceContct);
            return objReturn;
        }

        /// <summary>
        /// Insert (without parameters)
        /// Calls [usp_insert_Contact]
        /// </summary>
        public Int32 Insert()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Contact.Insert(ContactName, Salutation, FirstName, LastName, Telephone, Extension, Fax, Title, EMail, HomeTelephone, MobileTelephone, CompanyNo, Notes, AddressNo, TextOnlyEmail, Inactive, UpdatedBy, FinanceContact);
        }
        //[001] code end
		/// <summary>
		/// Get
		/// Calls [usp_select_Contact]
		/// </summary>
		public static Contact Get(System.Int32? contactId) {
			Rebound.GlobalTrader.DAL.ContactDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Contact.Get(contactId);
			if (objDetails == null) {
				return null;
			} else {
				Contact obj = new Contact();
				obj.ContactId = objDetails.ContactId;
				obj.ContactName = objDetails.ContactName;
				obj.Salutation = objDetails.Salutation;
				obj.FirstName = objDetails.FirstName;
				obj.LastName = objDetails.LastName;
				obj.Telephone = objDetails.Telephone;
				obj.Extension = objDetails.Extension;
				obj.Fax = objDetails.Fax;
				obj.Title = objDetails.Title;
				obj.EMail = objDetails.EMail;
				obj.HomeTelephone = objDetails.HomeTelephone;
				obj.MobileTelephone = objDetails.MobileTelephone;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.Notes = objDetails.Notes;
				obj.AddressNo = objDetails.AddressNo;
				obj.ContactPositionNo = objDetails.ContactPositionNo;
				obj.TextOnlyEmail = objDetails.TextOnlyEmail;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.CompanyName = objDetails.CompanyName;
				obj.FullName = objDetails.FullName;
				obj.ClientNo = objDetails.ClientNo;
				obj.Salesman = objDetails.Salesman;
				obj.DefaultPOContactNo = objDetails.DefaultPOContactNo;
				obj.DefaultSOContactNo = objDetails.DefaultSOContactNo;
				obj.SalesmanName = objDetails.SalesmanName;
				obj.TeamNo = objDetails.TeamNo;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.HasSupplementalData = objDetails.HasSupplementalData;
				obj.HasUserDefinedData = objDetails.HasUserDefinedData;
                //[001] code start
                obj.FinanceContact = objDetails.FinanceContact;
                //[001] code end
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_Contact_for_Page]
		/// </summary>
		public static Contact GetForPage(System.Int32? contactId) {
			Rebound.GlobalTrader.DAL.ContactDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Contact.GetForPage(contactId);
			if (objDetails == null) {
				return null;
			} else {
				Contact obj = new Contact();
				obj.ContactId = objDetails.ContactId;
				obj.ContactName = objDetails.ContactName;
				obj.Inactive = objDetails.Inactive;
				obj.CompanyNo = objDetails.CompanyNo;
                obj.TeamNo = objDetails.TeamNo;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.Salesman = objDetails.Salesman;
                obj.ClientNo = objDetails.ClientNo;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForCompany
		/// Calls [usp_selectAll_Contact_for_Company]
		/// </summary>
		public static List<Contact> GetListForCompany(System.Int32? companyId) {
			List<ContactDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Contact.GetListForCompany(companyId);
			if (lstDetails == null) {
				return new List<Contact>();
			} else {
				List<Contact> lst = new List<Contact>();
				foreach (ContactDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Contact obj = new Rebound.GlobalTrader.BLL.Contact();
					obj.ContactId = objDetails.ContactId;
					obj.ContactName = objDetails.ContactName;
					obj.Salutation = objDetails.Salutation;
					obj.FirstName = objDetails.FirstName;
					obj.LastName = objDetails.LastName;
					obj.Telephone = objDetails.Telephone;
					obj.Extension = objDetails.Extension;
					obj.Fax = objDetails.Fax;
					obj.Title = objDetails.Title;
					obj.EMail = objDetails.EMail;
					obj.HomeTelephone = objDetails.HomeTelephone;
					obj.MobileTelephone = objDetails.MobileTelephone;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.Notes = objDetails.Notes;
					obj.AddressNo = objDetails.AddressNo;
					obj.ContactPositionNo = objDetails.ContactPositionNo;
					obj.TextOnlyEmail = objDetails.TextOnlyEmail;
					obj.Inactive = objDetails.Inactive;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.CompanyName = objDetails.CompanyName;
					obj.FullName = objDetails.FullName;
					obj.ClientNo = objDetails.ClientNo;
					obj.Salesman = objDetails.Salesman;
					obj.DefaultPOContactNo = objDetails.DefaultPOContactNo;
					obj.DefaultSOContactNo = objDetails.DefaultSOContactNo;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.TeamNo = objDetails.TeamNo;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.HasSupplementalData = objDetails.HasSupplementalData;
					obj.HasUserDefinedData = objDetails.HasUserDefinedData;
					obj.DefaultPO = objDetails.DefaultPO;
					obj.DefaultSO = objDetails.DefaultSO;
                    //[001] code start
                    obj.FinanceContact = objDetails.FinanceContact;
                    //[001] code end
                    //[002] code start
                    obj.DefaultPOLedgerContactNo = objDetails.DefaultPOLedgerContactNo;
                    obj.DefaultSOLedgerContactNo = objDetails.DefaultSOLedgerContactNo;
                    obj.DefaultPOLedger = objDetails.DefaultPOLedger;
                    obj.DefaultSOLedger = objDetails.DefaultSOLedger;
                    //[002] code end
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
        //[001] code start
        /// <summary>
        /// Update
        /// Calls [usp_update_Contact]
        /// </summary>
        public static bool Update(System.Int32? contactId, System.String contactName, System.String salutation, System.String firstName, System.String lastName, System.String telephone, System.String extension, System.String fax, System.String title, System.String email, System.String homeTelephone, System.String mobileTelephone, System.Int32? companyNo, System.String notes, System.Int32? addressNo, System.Boolean? textOnlyEmail, System.Boolean? inactive, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Contact.Update(contactId, contactName, salutation, firstName, lastName, telephone, extension, fax, title, email, homeTelephone, mobileTelephone, companyNo, notes, addressNo, textOnlyEmail, inactive, updatedBy, null);
        }

        /// <summary>
        /// Update (without parameters)
        /// Calls [usp_update_Contact]
        /// </summary>
        public bool Update()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Contact.Update(ContactId, ContactName, Salutation, FirstName, LastName, Telephone, Extension, Fax, Title, EMail, HomeTelephone, MobileTelephone, CompanyNo, Notes, AddressNo, TextOnlyEmail, Inactive, UpdatedBy, FinanceContact);
        }
        //[001] code end

        private static Contact PopulateFromDBDetailsObject(ContactDetails obj) {
            Contact objNew = new Contact();
			objNew.ContactId = obj.ContactId;
			objNew.ContactName = obj.ContactName;
			objNew.Salutation = obj.Salutation;
			objNew.FirstName = obj.FirstName;
			objNew.LastName = obj.LastName;
			objNew.Telephone = obj.Telephone;
			objNew.Extension = obj.Extension;
			objNew.Fax = obj.Fax;
			objNew.Title = obj.Title;
			objNew.EMail = obj.EMail;
			objNew.HomeTelephone = obj.HomeTelephone;
			objNew.MobileTelephone = obj.MobileTelephone;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.Notes = obj.Notes;
			objNew.AddressNo = obj.AddressNo;
			objNew.ContactPositionNo = obj.ContactPositionNo;
			objNew.TextOnlyEmail = obj.TextOnlyEmail;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.CompanyName = obj.CompanyName;
			objNew.SalesmanName = obj.SalesmanName;
			objNew.RowNum = obj.RowNum;
			objNew.RowCnt = obj.RowCnt;
			objNew.FullName = obj.FullName;
			objNew.ClientNo = obj.ClientNo;
			objNew.Salesman = obj.Salesman;
			objNew.DefaultPOContactNo = obj.DefaultPOContactNo;
			objNew.DefaultSOContactNo = obj.DefaultSOContactNo;
			objNew.TeamNo = obj.TeamNo;
			objNew.DivisionNo = obj.DivisionNo;
			objNew.HasSupplementalData = obj.HasSupplementalData;
			objNew.HasUserDefinedData = obj.HasUserDefinedData;
			objNew.DefaultPO = obj.DefaultPO;
			objNew.DefaultSO = obj.DefaultSO;
            return objNew;
        }
		
		#endregion
		
	}
}