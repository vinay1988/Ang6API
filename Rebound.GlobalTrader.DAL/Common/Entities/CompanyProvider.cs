/**********************************************************************************************
Marker     changed by      date         Remarks
[001]      Abhinav       02/09/20011   ESMS Ref:12 - Add new field "Company Registration No" 
[002]      Vinay           07/05/2012   This need to upload pdf document for company section
[003]      Vinay           09/10/2012   Degete Ref:#26#  - Add two more columns contact to identify Default Purchase ledger and Default Sales ledger
[004]      Abhinav        02/17/2014   ESMS Ref:100 - Add new field to Compnay Form
[005]      Abhinav        02/21/2014   ESMS Ref: -  Add new field to Compnay Form  for Traceability required
[006]      Vinay          24/03/2014     ESMS Ref:106 -  Add new field(EARI Member and EARI Reported) to Compnay Form  
 [007]      Shashi Keshar  14/10/2016     Combobox  POApproveSuppliers 
 [008]      Aashu           06/06/2018    Added supplier warranty
* **********************************************************************************************/

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
	
	public abstract class CompanyProvider : DataAccess {
		static private CompanyProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public CompanyProvider Instance {
			get {
				if (_instance == null) _instance = (CompanyProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Companys.ProviderType));
				return _instance;
			}
		}
		public CompanyProvider() {
			this.ConnectionString = Globals.Settings.Companys.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// AutoSearch
		/// Calls [usp_autosearch_Company]
		/// </summary>
		public abstract List<CompanyDetails> AutoSearch(System.Int32? clientId, System.String nameSearch);

        /// <summary>
        /// AutoSearch
        /// Calls [usp_autosearch_SaleCompany]
        /// </summary>
        public abstract List<CompanyDetails> AutoSearchSale(System.Int32? clientId, System.String nameSearch);
		/// <summary>
		/// AutoSearchForCustomers
		/// Calls [usp_autosearch_Company_for_Customers]
		/// </summary>
		public abstract List<CompanyDetails> AutoSearchForCustomers(System.Int32? clientId, System.String nameSearch);
		/// <summary>
		/// AutoSearchForProspects
		/// Calls [usp_autosearch_Company_for_Prospects]
		/// </summary>
		public abstract List<CompanyDetails> AutoSearchForProspects(System.Int32? clientId, System.String nameSearch);
		/// <summary>
		/// AutoSearchForSuppliers
		/// Calls [usp_autosearch_Company_for_Suppliers]
		/// </summary>
		public abstract List<CompanyDetails> AutoSearchForSuppliers(System.Int32? clientId, System.String nameSearch);

        //[007] Start Here
        /// <summary>
        /// AutoSearchForPOApproveSuppliers
        /// Calls [usp_autosearch_Company_for_POApproveSuppliers]
        /// </summary>
        public abstract List<CompanyDetails> AutoSearchForPOApproveSuppliers(System.Int32? clientId, System.String nameSearch);
        //[007] End Here

        /// <summary>
        /// AutoSearchForAllSuppliers
        /// Calls [usp_autosearch_Company_for_AllSuppliers]
        /// </summary>
        public abstract List<CompanyDetails> AutoSearchForAllSuppliers(System.Int32? clientId, System.String nameSearch);
		/// <summary>
		/// CountAsCustomersByClient
		/// Calls [usp_count_Company_as_Customers_by_Client]
		/// </summary>
		public abstract Int32 CountAsCustomersByClient(System.Int32? clientId);
		/// <summary>
		/// CountAsProspectsByClient
		/// Calls [usp_count_Company_as_Prospects_by_Client]
		/// </summary>
		public abstract Int32 CountAsProspectsByClient(System.Int32? clientId);
		/// <summary>
		/// CountAsSuppliersByClient
		/// Calls [usp_count_Company_as_Suppliers_by_Client]
		/// </summary>
		public abstract Int32 CountAsSuppliersByClient(System.Int32? clientId);
		/// <summary>
		/// CountByClient
		/// Calls [usp_count_Company_by_Client]
		/// </summary>
		public abstract Int32 CountByClient(System.Int32? clientId);
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_Company]
		/// </summary>
        public abstract List<CompanyDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nameSearch, System.String typeSearch, System.String citySearch, System.String countrySearch, System.Int32? salesmanSearch, System.Int32? customerRatingLo, System.Int32? customerRatingHi, System.Int32? supplierRatingLo, System.Int32? supplierRatingHi, System.String customerCode, System.String telNo, System.String Zipcode);
		/// <summary>
		/// DataListNuggetAsCustomers
		/// Calls [usp_datalistnugget_Company_as_Customers]
		/// </summary>
        public abstract List<CompanyDetails> DataListNuggetAsCustomers(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nameSearch, System.String typeSearch, System.String citySearch, System.String countrySearch, System.Int32? salesmanSearch, System.Int32? customerRatingLo, System.Int32? customerRatingHi, System.Int32? supplierRatingLo, System.Int32? supplierRatingHi, System.String customerCode, System.String telNo, System.String Zipcode);
		/// <summary>
		/// DataListNuggetAsProspects
		/// Calls [usp_datalistnugget_Company_as_Prospects]
		/// </summary>
		public abstract List<CompanyDetails> DataListNuggetAsProspects(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nameSearch, System.String typeSearch, System.String citySearch, System.String countrySearch, System.Int32? salesmanSearch, System.Int32? customerRatingLo, System.Int32? customerRatingHi, System.Int32? supplierRatingLo, System.Int32? supplierRatingHi, System.String customerCode, System.String telNo, System.String Zipcode);
		/// <summary>
		/// DataListNuggetAsSuppliers
		/// Calls [usp_datalistnugget_Company_as_Suppliers]
		/// </summary>
		public abstract List<CompanyDetails> DataListNuggetAsSuppliers(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nameSearch, System.String typeSearch, System.String citySearch, System.String countrySearch, System.Int32? salesmanSearch, System.Int32? customerRatingLo, System.Int32? customerRatingHi, System.Int32? supplierRatingLo, System.Int32? supplierRatingHi, System.String customerCode, System.String telNo, System.String Zipcode);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Company]
		/// </summary>
		public abstract bool Delete(System.Int32? companyId);
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_Company_for_Client]
		/// </summary>
		public abstract List<CompanyDetails> DropDownForClient(System.Int32? clientId);
        public abstract List<CompanyDetails> DropDownForClientNPR(System.Int32? goodsinLineNo);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Company]
		/// </summary>
        //[001],[004] code start
        public abstract Int32 Insert(System.Int32? clientNo, System.String companyName, System.DateTime? dateCreated, System.String customerCode, System.Int32? salesman, System.Int32? teamNo, System.String telephone, System.String telephone800, System.String fax, System.String rfax, System.String email, System.String url, System.String notes, System.String tax, System.Int32? typeNo, System.Int32? manufacturerNo, System.Boolean? soApproved, System.Int32? soRating, System.Int32? soTermsNo, System.Int32? soCurrencyNo, System.Int32? soTaxNo, System.Int32? defaultSoContactNo, System.Int32? defaultSalesShipViaNo, System.String defaultSalesShipViaAccount, System.Boolean? poApproved, System.Int32? poRating, System.Int32? poTermsNo, System.Int32? poCurrencyNo, System.Int32? poTaxNo, System.Int32? defaultPoContactNo, System.Int32? defaultPurchaseShipViaNo, System.String defaultPurchaseShipViaAccount, System.Boolean? onStop, System.Double? creditLimit, System.Double? currentMonth, System.Double? days30, System.Double? days60, System.Double? days90, System.Double? days120, System.Boolean? shippingCharge, System.Boolean? exportData, System.String importantNotes, System.Int32? parentCompanyNo, System.Int32? updatedBy, string CompanyRegNo,System.String certificateNotes, System.String qualityNotes);
        //[001],[004] code end
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_Company]
		/// </summary>
        public abstract List<CompanyDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nameSearch, System.Boolean? poApproved, System.Boolean? soApproved, System.Boolean? includeOnStopSystem, Boolean? excludeSupplierOnStop, System.Int32? poNoLo, System.Int32? poNoHi);
		/// <summary>
		/// Get
		/// Calls [usp_select_Company]
		/// </summary>
		public abstract CompanyDetails Get(System.Int32? companyId);
		/// <summary>
		/// GetDefaultPurchasingInfo
		/// Calls [usp_select_Company_DefaultPurchasingInfo]
		/// </summary>
		public abstract CompanyDetails GetDefaultPurchasingInfo(System.Int32? companyId);
		/// <summary>
		/// GetDefaultSalesInfo
		/// Calls [usp_select_Company_DefaultSalesInfo]
		/// </summary>
		public abstract CompanyDetails GetDefaultSalesInfo(System.Int32? companyId);
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_Company_for_Page]
		/// </summary>
		public abstract CompanyDetails GetForPage(System.Int32? companyId);
		/// <summary>
		/// GetMainInfo
		/// Calls [usp_select_Company_MainInfo]
		/// </summary>
		public abstract CompanyDetails GetMainInfo(System.Int32? companyId);
		/// <summary>
		/// GetPurchaseInfo
		/// Calls [usp_select_Company_PurchaseInfo]
		/// </summary>
		public abstract CompanyDetails GetPurchaseInfo(System.Int32? companyId);
		/// <summary>
		/// GetSalesInfo
		/// Calls [usp_select_Company_SalesInfo]
		/// </summary>
		public abstract CompanyDetails GetSalesInfo(System.Int32? companyId);
		/// <summary>
		/// GetListByManufacturer
		/// Calls [usp_selectAll_Company_by_Manufacturer]
		/// </summary>
		public abstract List<CompanyDetails> GetListByManufacturer(System.Int32? manufacturerNo);
		/// <summary>
		/// GetListOnstopForClient
		/// Calls [usp_selectAll_Company_onstop_for_Client]
		/// </summary>
		public abstract List<CompanyDetails> GetListOnstopForClient(System.Int32? clientId, System.Int32? topToSelect);
		/// <summary>
		/// GetListOnstopForLogin
		/// Calls [usp_selectAll_Company_onstop_for_Login]
		/// </summary>
		public abstract List<CompanyDetails> GetListOnstopForLogin(System.Int32? loginId, System.Int32? topToSelect);
		/// <summary>
		/// SummariseLastYearPurchaseOrderValue
		/// Calls [usp_summarise_Company_LastYear_PurchaseOrderValue]
		/// </summary>
		public abstract CompanyDetails SummariseLastYearPurchaseOrderValue(System.Int32? companyId);
		/// <summary>
		/// SummariseLastYearSalesOrderValue
		/// Calls [usp_summarise_Company_LastYear_SalesOrderValue]
		/// </summary>
		public abstract CompanyDetails SummariseLastYearSalesOrderValue(System.Int32? companyId);
		/// <summary>
		/// SummariseThisYearPurchaseOrderValue
		/// Calls [usp_summarise_Company_ThisYear_PurchaseOrderValue]
		/// </summary>
		public abstract CompanyDetails SummariseThisYearPurchaseOrderValue(System.Int32? companyId);
		/// <summary>
		/// SummariseThisYearSalesOrderValue
		/// Calls [usp_summarise_Company_ThisYear_SalesOrderValue]
		/// </summary>
		public abstract CompanyDetails SummariseThisYearSalesOrderValue(System.Int32? companyId);
		/// <summary>
		/// UpdateDefaultPOContact
		/// Calls [usp_update_Company_DefaultPOContact]
		/// </summary>
		public abstract bool UpdateDefaultPOContact(System.Int32? companyId, System.Int32? defaultPoContactNo, System.Int32? updatedBy);
        //[003] code start
        /// <summary>
        /// UpdateDefaultPOLedgerContact
        /// Calls [usp_update_Company_DefaultPOLedgerContact]
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="defaultPoContactNo"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public abstract bool UpdateDefaultPOLedgerContact(System.Int32? companyId, System.Int32? defaultPoContactNo, System.Int32? updatedBy);
        /// <summary>
        /// UpdateDefaultSOLedgerContact
        /// Calls [usp_update_Company_DefaultSOLedgerContact]
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="defaultPoContactNo"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public abstract bool UpdateDefaultSOLedgerContact(System.Int32? companyId, System.Int32? defaultSoContactNo, System.Int32? updatedBy);
        //[003] code end
		/// <summary>
		/// UpdateDefaultSOContact
		/// Calls [usp_update_Company_DefaultSOContact]
		/// </summary>
		public abstract bool UpdateDefaultSOContact(System.Int32? companyId, System.Int32? defaultSoContactNo, System.Int32? updatedBy);
		/// <summary>
		/// UpdateMainInfo
		/// Calls [usp_update_Company_MainInfo]
		/// </summary>
        //[001],[004],[005],[006],[008] code start
        public abstract bool UpdateMainInfo(System.Int32? companyId, System.String companyName, System.Int32? parentCompanyNo, System.Int32? salesman, System.String telephone, System.String telephone800, System.String fax, System.String email, System.String url, System.Int32? typeNo, System.String tax, System.String notes, System.String importantNotes, System.Int32? updatedBy, System.String CompanyRegNo, System.String certificateNotes, System.String qualityNotes, System.Boolean IsTraceability, System.Boolean? eraiMember, System.Boolean? eraiReported, System.DateTime? reviewDate, System.Double? upLiftPrice, System.Int32? SupplierWarranty);
		/// <summary>
        ///[001],[004],[005],[006] code end
		/// UpdateManufacturerNo
		/// Calls [usp_update_Company_ManufacturerNo]
		/// </summary>
		public abstract bool UpdateManufacturerNo(System.Int32? companyId, System.Int32? manufacturerNo, System.Int32? updatedBy);
		/// <summary>
		/// UpdatePurchaseInfo
		/// Calls [usp_update_Company_PurchaseInfo]
		/// </summary>
        public abstract bool UpdatePurchaseInfo(System.Int32? companyId, System.String supplierCode, System.Boolean? poApproved, System.Int32? poRating, System.Int32? poTermsNo, System.Int32? poCurrencyNo, System.Int32? poTaxNo, System.Int32? defaultPoContactNo, System.String defaultPurchaseShipViaAccount, System.Int32? defaultPurchaseShipViaNo, System.Int32? updatedBy, System.Int32? defaultPOShipCountryNo,System.Boolean? onSupplierStop);
		/// <summary>
		/// UpdateSalesInfo
		/// Calls [usp_update_Company_SalesInfo]
		/// </summary>
        public abstract bool UpdateSalesInfo(System.Int32? companyId, System.String customerCode, System.Int32? salesman, System.Boolean? soApproved, System.Int32? soRating, System.Int32? soTermsNo, System.Int32? soCurrencyNo, System.Int32? soTaxNo, System.Int32? defaultSoContactNo, System.Int32? defaultSalesShipViaNo, System.String defaultSalesShipViaAccount, System.Boolean? onStop, System.Boolean? shippingCharge, System.Double? creditLimit, System.String insuranceFileNo, System.Double? insuredAmount, System.Int32? updatedBy, System.String StopStatus, System.String NotesToInvoice, System.Double? actualCreditLimit);
		/// <summary>
		/// UpdateTransferAccounts
		/// Calls [usp_update_Company_TransferAccounts]
		/// </summary>
		public abstract bool UpdateTransferAccounts(System.Int32? oldLoginNo, System.Int32? newLoginNo, System.Int32? updatedBy);

        // [002] code start
        /// <summary>
        /// Get PDF list for company
        /// Calls [usp_selectAll_PDF_for_Company]
        /// </summary>
        /// <param name="SalesOrderId"></param>
        /// <returns></returns>
        public abstract List<PDFDocumentDetails> GetPDFListForCompany(System.Int32? CompanyId);
        /// <summary>
        /// Insert PDF for company
        /// Calls [usp_insert_CompanyPDF]
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <param name="Caption"></param>
        /// <param name="FileName"></param>
        /// <param name="UpdatedBy"></param>
        /// <returns></returns>
        public abstract Int32 Insert(System.Int32? CompanyId, System.String Caption, System.String FileName, System.Int32? UpdatedBy);
        /// <summary>
        /// Delete company pdf
        /// Calls[usp_delete_CompanyPDF]
        /// </summary>
        /// <param name="CompanyPdfId"></param>
        /// <returns></returns>
        public abstract bool DeleteCompanyPDF(System.Int32? CompanyPdfId);
       
        // [002] code end

		#endregion
				
		/// <summary>
		/// Returns a new CompanyDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual CompanyDetails GetCompanyFromReader(DbDataReader reader) {
			CompanyDetails company = new CompanyDetails();
			if (reader.HasRows) {
				company.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0); //From: [Table]
				company.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				company.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [Table]
				company.DateCreated = GetReaderValue_DateTime(reader, "DateCreated", DateTime.MinValue); //From: [Table]
				company.CustomerCode = GetReaderValue_String(reader, "CustomerCode", ""); //From: [Table]
				company.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null); //From: [Table]
				company.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null); //From: [Table]
				company.Telephone = GetReaderValue_String(reader, "Telephone", ""); //From: [Table]
				company.Telephone800 = GetReaderValue_String(reader, "Telephone800", ""); //From: [Table]
				company.Fax = GetReaderValue_String(reader, "Fax", ""); //From: [Table]
				company.RFax = GetReaderValue_String(reader, "RFax", ""); //From: [Table]
				company.EMail = GetReaderValue_String(reader, "EMail", ""); //From: [Table]
				company.URL = GetReaderValue_String(reader, "URL", ""); //From: [Table]
				company.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				company.Tax = GetReaderValue_String(reader, "Tax", ""); //From: [Table]
				company.TypeNo = GetReaderValue_NullableInt32(reader, "TypeNo", null); //From: [Table]
				company.SOApproved = GetReaderValue_NullableBoolean(reader, "SOApproved", null); //From: [Table]
				company.SORating = GetReaderValue_NullableInt32(reader, "SORating", null); //From: [Table]
				company.SOTermsNo = GetReaderValue_NullableInt32(reader, "SOTermsNo", null); //From: [Table]
				company.SOCurrencyNo = GetReaderValue_NullableInt32(reader, "SOCurrencyNo", null); //From: [Table]
				company.SOTaxNo = GetReaderValue_NullableInt32(reader, "SOTaxNo", null); //From: [Table]
				company.DefaultSOContactNo = GetReaderValue_NullableInt32(reader, "DefaultSOContactNo", null); //From: [Table]
				company.DefaultSalesShipViaNo = GetReaderValue_NullableInt32(reader, "DefaultSalesShipViaNo", null); //From: [Table]
				company.DefaultSalesShipViaAccount = GetReaderValue_String(reader, "DefaultSalesShipViaAccount", ""); //From: [Table]
				company.POApproved = GetReaderValue_NullableBoolean(reader, "POApproved", null); //From: [Table]
				company.PORating = GetReaderValue_NullableInt32(reader, "PORating", null); //From: [Table]
				company.POTermsNo = GetReaderValue_NullableInt32(reader, "POTermsNo", null); //From: [Table]
				company.POCurrencyNo = GetReaderValue_NullableInt32(reader, "POCurrencyNo", null); //From: [Table]
				company.POTaxNo = GetReaderValue_NullableInt32(reader, "POTaxNo", null); //From: [Table]
				company.DefaultPOContactNo = GetReaderValue_NullableInt32(reader, "DefaultPOContactNo", null); //From: [Table]
				company.DefaultPurchaseShipViaNo = GetReaderValue_NullableInt32(reader, "DefaultPurchaseShipViaNo", null); //From: [Table]
				company.DefaultPurchaseShipViaAccount = GetReaderValue_String(reader, "DefaultPurchaseShipViaAccount", ""); //From: [Table]
				company.OnStop = GetReaderValue_NullableBoolean(reader, "OnStop", null); //From: [Table]
				company.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null); //From: [Table]
				company.CurrentMonth = GetReaderValue_NullableDouble(reader, "CurrentMonth", null); //From: [Table]
				company.Days30 = GetReaderValue_NullableDouble(reader, "Days30", null); //From: [Table]
				company.Days60 = GetReaderValue_NullableDouble(reader, "Days60", null); //From: [Table]
				company.Days90 = GetReaderValue_NullableDouble(reader, "Days90", null); //From: [Table]
				company.Days120 = GetReaderValue_NullableDouble(reader, "Days120", null); //From: [Table]
				company.ShippingCharge = GetReaderValue_NullableBoolean(reader, "ShippingCharge", null); //From: [Table]
				company.ExportData = GetReaderValue_NullableBoolean(reader, "ExportData", null); //From: [Table]
				company.ImportantNotes = GetReaderValue_String(reader, "ImportantNotes", ""); //From: [Table]
				company.ParentCompanyNo = GetReaderValue_NullableInt32(reader, "ParentCompanyNo", null); //From: [Table]
				company.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null); //From: [Table]
				company.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				company.AutoImportDate = GetReaderValue_NullableDateTime(reader, "AutoImportDate", null); //From: [Table]
				company.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				company.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				company.Balance = GetReaderValue_NullableDouble(reader, "Balance", null); //From: [Table]
				company.FullName = GetReaderValue_String(reader, "FullName", ""); //From: [Table]
				company.SupplierCode = GetReaderValue_String(reader, "SupplierCode", ""); //From: [Table]
				company.CompanyType = GetReaderValue_String(reader, "CompanyType", ""); //From: [usp_datalistnugget_Company]
				company.City = GetReaderValue_String(reader, "City", ""); //From: [usp_datalistnugget_Company]
				company.Country = GetReaderValue_String(reader, "Country", ""); //From: [usp_datalistnugget_Company]
				company.SalesmanName = GetReaderValue_String(reader, "SalesmanName", ""); //From: [usp_datalistnugget_Company]
				company.DaysSinceContact = GetReaderValue_NullableInt32(reader, "DaysSinceContact", null); //From: [usp_datalistnugget_Company]
				company.TermsName = GetReaderValue_String(reader, "TermsName", ""); //From: [usp_datalistnugget_Company]
				company.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_datalistnugget_Company]
				company.TeamName = GetReaderValue_String(reader, "TeamName", ""); //From: [usp_select_Company]
				company.SOTermsName = GetReaderValue_String(reader, "SOTermsName", ""); //From: [usp_select_Company]
				company.SOCurrencyCode = GetReaderValue_String(reader, "SOCurrencyCode", ""); //From: [usp_select_Company]
				company.SOCurrencyDescription = GetReaderValue_String(reader, "SOCurrencyDescription", ""); //From: [usp_select_Company]
				company.SOCurrencySymbol = GetReaderValue_String(reader, "SOCurrencySymbol", ""); //From: [usp_select_Company]
				company.DefaultSOContactName = GetReaderValue_String(reader, "DefaultSOContactName", ""); //From: [usp_select_Company]
				company.SOTaxName = GetReaderValue_String(reader, "SOTaxName", ""); //From: [usp_select_Company]
				company.DefaultSalesShipViaName = GetReaderValue_String(reader, "DefaultSalesShipViaName", ""); //From: [usp_select_Company]
				company.DefaultSalesShippingCost = GetReaderValue_Double(reader, "DefaultSalesShippingCost", 0); //From: [usp_select_Company]
				company.DefaultSalesFreightCharge = GetReaderValue_Double(reader, "DefaultSalesFreightCharge", 0); //From: [usp_select_Company]
				company.POTermsName = GetReaderValue_String(reader, "POTermsName", ""); //From: [usp_select_Company]
				company.POCurrencyCode = GetReaderValue_String(reader, "POCurrencyCode", ""); //From: [usp_select_Company]
				company.POCurrencyDescription = GetReaderValue_String(reader, "POCurrencyDescription", ""); //From: [usp_select_Company]
				company.POCurrencySymbol = GetReaderValue_String(reader, "POCurrencySymbol", ""); //From: [usp_select_Company]
				company.DefaultPOContactName = GetReaderValue_String(reader, "DefaultPOContactName", ""); //From: [usp_select_Company]
				company.POTaxName = GetReaderValue_String(reader, "POTaxName", ""); //From: [usp_select_Company]
				company.DefaultPurchaseShipViaName = GetReaderValue_String(reader, "DefaultPurchaseShipViaName", ""); //From: [usp_select_Company]
				company.DefaultPurchaseShippingCost = GetReaderValue_Double(reader, "DefaultPurchaseShippingCost", 0); //From: [usp_select_Company]
				company.DefaultPurchaseFreightCharge = GetReaderValue_Double(reader, "DefaultPurchaseFreightCharge", 0); //From: [usp_select_Company]
				company.ParentCompanyName = GetReaderValue_String(reader, "ParentCompanyName", ""); //From: [usp_select_Company]
				company.FirstContactNo = GetReaderValue_NullableInt32(reader, "FirstContactNo", null); //From: [usp_select_Company]
				company.ExchangeRate = GetReaderValue_NullableDouble(reader, "ExchangeRate", null); //From: [usp_select_Company_PurchaseInfo]
				company.PurchaseOrderValueLastYear = GetReaderValue_NullableDouble(reader, "PurchaseOrderValueLastYear", null); //From: [usp_summarise_Company_LastYear_PurchaseOrderValue]
				company.PurchaseOrderValueLastYearInBase = GetReaderValue_NullableDouble(reader, "PurchaseOrderValueLastYearInBase", null); //From: [usp_summarise_Company_LastYear_PurchaseOrderValue]
				company.SalesOrderValueLastYear = GetReaderValue_NullableDouble(reader, "SalesOrderValueLastYear", null); //From: [usp_summarise_Company_LastYear_SalesOrderValue]
				company.SalesOrderValueLastYearInBase = GetReaderValue_NullableDouble(reader, "SalesOrderValueLastYearInBase", null); //From: [usp_summarise_Company_LastYear_SalesOrderValue]
				company.PurchaseOrderValueYTD = GetReaderValue_NullableDouble(reader, "PurchaseOrderValueYTD", null); //From: [usp_summarise_Company_ThisYear_PurchaseOrderValue]
				company.PurchaseOrderValueYTDInBase = GetReaderValue_NullableDouble(reader, "PurchaseOrderValueYTDInBase", null); //From: [usp_summarise_Company_ThisYear_PurchaseOrderValue]
				company.SalesOrderValueYTD = GetReaderValue_NullableDouble(reader, "SalesOrderValueYTD", null); //From: [usp_summarise_Company_ThisYear_SalesOrderValue]
				company.SalesOrderValueYTDInBase = GetReaderValue_NullableDouble(reader, "SalesOrderValueYTDInBase", null); //From: [usp_summarise_Company_ThisYear_SalesOrderValue]
			}
			return company;
		}
	
		/// <summary>
		/// Returns a collection of CompanyDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<CompanyDetails> GetCompanyCollectionFromReader(DbDataReader reader) {
			List<CompanyDetails> companys = new List<CompanyDetails>();
			while (reader.Read()) companys.Add(GetCompanyFromReader(reader));
			return companys;
		}



        public int Insert(int? clientNo, string companyName, DateTime? dateCreated, string customerCode, int? salesman, int? teamNo, string telephone, string telephone800, string fax, string rfax, string email, string url, string notes, string tax, int? typeNo, int? manufacturerNo, bool? soApproved, int? soRating, int? soTermsNo, int? soCurrencyNo, int? soTaxNo, int? defaultSoContactNo, int? defaultSalesShipViaNo, string defaultSalesShipViaAccount, bool? poApproved, int? poRating, int? poTermsNo, int? poCurrencyNo, int? poTaxNo, int? defaultPoContactNo, int? defaultPurchaseShipViaNo, string defaultPurchaseShipViaAccount, bool? onStop, double? creditLimit, double? currentMonth, double? days30, double? days60, double? days90, double? days120, bool? shippingCharge, bool? exportData, string importantNotes, int? parentCompanyNo, int? updatedBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// SummariseThisYearandLastYearSalesValue
        /// Calls [usp_summarise_Company_ThisYear_LastYear_SalesValue]
        /// </summary>
        public abstract CompanyDetails SummariseThisYearandLastYearSalesValue(System.Int32? companyId,System.Boolean? blnThisYear);
    }
}
