//Marker     Changed by      Date         Remarks
//[001]      Vinay           09/07/2012   This need for Rebound- Invoice bulk Emailer
//[002]      Vinay           04/10/2012   Degete Ref:#26#  - Add two more columns contact to identify Default Purchase ledger and Default Sales ledger
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Rebound.GlobalTrader.DAL {
	
	public class ContactDetails {
		
		#region Constructors
		
		public ContactDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// ContactId (from Table)
		/// </summary>
		public System.Int32 ContactId { get; set; }
		/// <summary>
		/// ContactName (from Table)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// Salutation (from Table)
		/// </summary>
		public System.String Salutation { get; set; }
		/// <summary>
		/// FirstName (from Table)
		/// </summary>
		public System.String FirstName { get; set; }
		/// <summary>
		/// LastName (from Table)
		/// </summary>
		public System.String LastName { get; set; }
		/// <summary>
		/// Telephone (from Table)
		/// </summary>
		public System.String Telephone { get; set; }
		/// <summary>
		/// Extension (from Table)
		/// </summary>
		public System.String Extension { get; set; }
		/// <summary>
		/// Fax (from Table)
		/// </summary>
		public System.String Fax { get; set; }
		/// <summary>
		/// Title (from Table)
		/// </summary>
		public System.String Title { get; set; }
		/// <summary>
		/// EMail (from Table)
		/// </summary>
		public System.String EMail { get; set; }
		/// <summary>
		/// HomeTelephone (from Table)
		/// </summary>
		public System.String HomeTelephone { get; set; }
		/// <summary>
		/// MobileTelephone (from Table)
		/// </summary>
		public System.String MobileTelephone { get; set; }
		/// <summary>
		/// CompanyNo (from Table)
		/// </summary>
		public System.Int32? CompanyNo { get; set; }
		/// <summary>
		/// Notes (from Table)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// AddressNo (from Table)
		/// </summary>
		public System.Int32? AddressNo { get; set; }
		/// <summary>
		/// ContactPositionNo (from Table)
		/// </summary>
		public System.Int32? ContactPositionNo { get; set; }
		/// <summary>
		/// TextOnlyEmail (from Table)
		/// </summary>
		public System.Boolean? TextOnlyEmail { get; set; }
		/// <summary>
		/// Inactive (from Table)
		/// </summary>
		public System.Boolean Inactive { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// CompanyName (from usp_datalistnugget_Contact)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// SalesmanName (from usp_datalistnugget_Contact)
		/// </summary>
		public System.String SalesmanName { get; set; }
		/// <summary>
		/// RowNum (from usp_datalistnugget_Contact)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_datalistnugget_Contact)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// FullName (from usp_select_Contact)
		/// </summary>
		public System.String FullName { get; set; }
		/// <summary>
		/// ClientNo (from usp_select_Contact)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// Salesman (from usp_select_Contact)
		/// </summary>
		public System.Int32? Salesman { get; set; }
		/// <summary>
		/// DefaultPOContactNo (from usp_select_Contact)
		/// </summary>
		public System.Int32? DefaultPOContactNo { get; set; }
		/// <summary>
		/// DefaultSOContactNo (from usp_select_Contact)
		/// </summary>
		public System.Int32? DefaultSOContactNo { get; set; }
		/// <summary>
		/// TeamNo (from usp_select_Contact)
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// DivisionNo (from usp_select_Contact)
		/// </summary>
		public System.Int32? DivisionNo { get; set; }
		/// <summary>
		/// HasSupplementalData (from usp_select_Contact)
		/// </summary>
		public System.Int32 HasSupplementalData { get; set; }
		/// <summary>
		/// HasUserDefinedData (from usp_select_Contact)
		/// </summary>
		public System.Int32 HasUserDefinedData { get; set; }
		/// <summary>
		/// DefaultPO (from usp_selectAll_Contact_for_Company)
		/// </summary>
		public System.Boolean? DefaultPO { get; set; }
		/// <summary>
		/// DefaultSO (from usp_selectAll_Contact_for_Company)
		/// </summary>
		public System.Boolean? DefaultSO { get; set; }
        //[001] code start
        /// <summary>
        /// FinanceContact
        /// </summary>
        public System.Boolean? FinanceContact { get; set; }
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

	}
}