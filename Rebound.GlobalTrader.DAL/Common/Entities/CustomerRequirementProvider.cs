/*

Marker     changed by      date         Remarks

[001]      Abhinav       31/05/2012   ESMS Ref:92 - Requirement Error - Urgent

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
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL {
	
	public abstract class CustomerRequirementProvider : DataAccess {
		static private CustomerRequirementProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public CustomerRequirementProvider Instance {
			get {
				if (_instance == null) _instance = (CustomerRequirementProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.CustomerRequirements.ProviderType));
				return _instance;
			}
		}
		public CustomerRequirementProvider() {
			this.ConnectionString = Globals.Settings.CustomerRequirements.ConnectionString;
            this.GTConnectionString = Globals.Settings.CustomerRequirements.GTConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_CustomerRequirement_for_Client]
		/// </summary>
		public abstract Int32 CountForClient(System.Int32? clientId);
		/// <summary>
		/// CountForCompany
		/// Calls [usp_count_CustomerRequirement_for_Company]
		/// </summary>
		public abstract Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeClosed);
		/// <summary>
		/// CountOpenForCompany
		/// Calls [usp_count_CustomerRequirement_open_for_Company]
		/// </summary>
		public abstract Int32 CountOpenForCompany(System.Int32? companyId);
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_CustomerRequirement]
		/// </summary>
        public abstract List<CustomerRequirementDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanNo, System.Boolean? recentOnly, System.Boolean? includeClosed, System.Int32? customerRequirementNoLo, System.Int32? customerRequirementNoHi, System.DateTime? receivedDateFrom, System.DateTime? receivedDateTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo, System.Boolean? partWatch, System.String bomNameSearch, System.String bomCodeSearch, System.Int32? totalLo, System.Int32? totalHi);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_CustomerRequirement]
		/// </summary>
		public abstract bool Delete(System.Int32? customerRequirementId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_CustomerRequirement]
		/// </summary>
        public abstract Int32 Insert(System.Int32? clientNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? receivedDate, System.Int32? salesman, System.DateTime? datePromised, System.String notes, System.String instructions, System.Boolean? shortage, System.Int32? companyNo, System.Int32? contactNo, System.Int32? usageNo, System.Boolean? alternate, System.Int32? originalCustomerRequirementNo, System.Int32? reasonNo, System.Int32? productNo, System.String customerPart, System.Boolean? closed, System.Byte? rohs, System.Int32? updatedBy, System.Boolean? partWatch, System.Boolean? bom, System.String bomName, System.Int32? BOMNo, System.Boolean? FactorySealed, System.String MSL, System.Boolean? PQA, System.Boolean? ObsoleteChk, System.Boolean? LastTimeBuyChk, System.Boolean? RefirbsAcceptableChk, System.Boolean? TestingRequiredChk, System.Double? TargetSellPrice, System.Double? CompetitorBestOffer, System.DateTime? CustomerDecisionDate, System.DateTime? RFQClosingDate, System.Int32? QuoteValidityRequired, System.Int32? Type, System.Boolean? OrderToPlace, System.Int32? RequirementforTraceability, System.String EAU, System.Boolean? AlternativesAccepted, System.Boolean? RepeatBusiness);
		/// <summary>
		/// InsertAsAlternate
		/// Calls [usp_insert_CustomerRequirement_as_Alternate]
		/// </summary>
		public abstract Int32 InsertAsAlternate(System.String customerRequirementName, System.Int32? customerRequirementNumber, System.Int32? clientNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? receivedDate, System.Int32? salesman, System.DateTime? datePromised, System.String notes, System.String instructions, System.Boolean? shortage, System.Int32? companyNo, System.Int32? contactNo, System.Int32? usageNo, System.Int32? originalCustomerRequirementNo, System.Int32? reasonNo, System.Int32? productNo, System.String customerPart, System.Boolean? closed, System.Byte? rohs, System.Int32? updatedBy, System.Boolean? partWatch, System.Boolean? bom, System.String bomName,
            System.Int32? salesmanno, System.Boolean? PQA, System.Boolean? ObsoleteChk, System.Boolean? LastTimeBuyChk, System.Boolean? RefirbsAcceptableChk, System.Boolean? TestingRequiredChk, System.Boolean? AlternativesAccepted, System.Boolean? RepeatBusiness, System.Double? CompetitorBestOffer, System.DateTime? CustomerDecisionDate, System.DateTime? RFQClosingDate, System.Int32? QuoteValidityRequired, System.Int32? Type, System.Boolean? OrderToPlace, System.Boolean? FactorySealed, System.String MSL, System.Int32? BOMNo, System.Int32? RequirementforTraceability, System.String EAU);
        /// <summary>
        /// InsertAsAllAlternate
        /// Calls [usp_insert_CustomerRequirement_as_AllAlternate]
        /// </summary>
        public abstract Int32 InsertAsAllAlternate(System.Int32? clientNo, System.String part, System.Int32? CustRequirementId);
        
        /// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_CustomerRequirement]
		/// </summary>
		public abstract List<CustomerRequirementDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Boolean? includeClosed, System.Int32? customerRequirementNoLo, System.Int32? customerRequirementNoHi, System.DateTime? receivedDateFrom, System.DateTime? receivedDateTo);
		/// <summary>
		/// Get
		/// Calls [usp_select_CustomerRequirement]
		/// </summary>
		public abstract CustomerRequirementDetails Get(System.Int32? customerRequirementId);
        /// <summary>
        /// Get
        /// Calls [usp_select_CustomerRequirementBOM]
        /// </summary>
        public abstract CustomerRequirementDetails GetReqBOM(System.Int32? customerRequirementId);
        /// <summary>
		/// GetByNumber
		/// Calls [usp_select_CustomerRequirement_by_Number]
		/// </summary>
		public abstract CustomerRequirementDetails GetByNumber(System.Int32? customerRequirementNumber, System.Int32? clientNo);
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_CustomerRequirement_for_Page]
		/// </summary>
		public abstract CustomerRequirementDetails GetForPage(System.Int32? customerRequirementId);
		/// <summary>
		/// GetIdByNumber
		/// Calls [usp_select_CustomerRequirement_Id_by_Number]
		/// </summary>
		public abstract CustomerRequirementDetails GetIdByNumber(System.Int32? customerRequirementNumber, System.Int32? clientNo);
		/// <summary>
		/// GetNextNumber
		/// Calls [usp_select_CustomerRequirement_NextNumber]
		/// </summary>
		public abstract CustomerRequirementDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy);
		/// <summary>
		/// GetNumberById
		/// Calls [usp_select_CustomerRequirement_Number_by_Id]
		/// </summary>
		public abstract CustomerRequirementDetails GetNumberById(System.Int32? customerRequirementId);
		/// <summary>
		/// GetListForCompany
		/// Calls [usp_selectAll_CustomerRequirement_for_Company]
		/// </summary>
		public abstract List<CustomerRequirementDetails> GetListForCompany(System.Int32? companyId, System.Boolean? includeClosed);
		/// <summary>
		/// GetListForCustomerRequirementNumber
		/// Calls [usp_selectAll_CustomerRequirement_for_CustomerRequirementNumber]
		/// </summary>
		public abstract List<CustomerRequirementDetails> GetListForCustomerRequirementNumber(System.Int32? customerRequirementNumber,System.Int32? clientID);


        // [001] code start
        /// <summary>
        /// GetListForCustomerRequirement
        /// Calls [usp_selectAll_CustomerRequirement_for_CustomerRequirement]
        /// </summary>
        public abstract List<CustomerRequirementDetails> GetListForCustomerRequirement(System.Int32? customerRequirementNo,System.Int32?  clientID);
        // [001] code end

		/// <summary>
		/// GetListOpenForCompany
		/// Calls [usp_selectAll_CustomerRequirement_open_for_Company]
		/// </summary>
		public abstract List<CustomerRequirementDetails> GetListOpenForCompany(System.Int32? companyId);
		/// <summary>
		/// GetListOpenForLogin
		/// Calls [usp_selectAll_CustomerRequirement_open_for_Login]
		/// </summary>
		public abstract List<CustomerRequirementDetails> GetListOpenForLogin(System.Int32? loginId, System.Int32? topToSelect);
		/// <summary>
		/// GetListOverdueForLogin
		/// Calls [usp_selectAll_CustomerRequirement_overdue_for_Login]
		/// </summary>
		public abstract List<CustomerRequirementDetails> GetListOverdueForLogin(System.Int32? loginId, System.Int32? topToSelect);
		/// <summary>
		/// Source
		/// Calls [usp_source_CustomerRequirement]
		/// </summary>
        public abstract List<CustomerRequirementDetails> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool IsServerLocal);
       /// <summary>
       /// 
       /// </summary>
       /// <param name="HUBRFQId"></param>
       /// <param name="expediteNotes"></param>
       /// <param name="UpdatedBy"></param>
       /// <param name="ReqIds"></param>
       /// <returns></returns>
        public abstract int InsertExpedite(int? HUBRFQId, string expediteNotes, int? UpdatedBy, string ReqIds, System.Int32? emailSendTo);
        public abstract int InsertHUBRFQExpedite(int? HUBRFQId, string expediteNotes, int? UpdatedBy, System.Int32? emailSendTo);

        
        /// <summary>
		/// Update
		/// Calls [usp_update_CustomerRequirement]
		/// </summary>
        public abstract bool Update(System.Int32? customerRequirementId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? receivedDate, System.Int32? salesman, System.DateTime? datePromised, System.String notes, System.String instructions, System.Boolean? shortage, System.Int32? companyNo, System.Int32? contactNo, System.Int32? usageNo, System.Boolean? alternate, System.Int32? originalCustomerRequirementNo, System.Int32? reasonNo, System.Int32? productNo, System.String customerPart, System.Boolean? closed, System.Byte? rohs, System.Int32? updatedBy, System.Boolean? partWatch, System.Boolean? bom, System.String bomName, System.Int32? bomNo, System.Boolean? FactorySealed, System.String MSL, System.Boolean? PQA, System.Boolean? ObsoleteChk, System.Boolean? LastTimeBuyChk, System.Boolean? RefirbsAcceptableChk, System.Boolean? TestingRequiredChk, System.Double? TargetSellPrice, System.Double? CompetitorBestOffer, System.DateTime? CustomerDecisionDate, System.DateTime? RFQClosingDate, System.Int32? QuoteValidityRequired, System.Int32? Type, System.Boolean? OrderToPlace, System.Int32? RequirementforTraceability, System.String EAU, System.Boolean? AlternativesAccepted, System.Boolean? RepeatBusiness);

        /// <summary>
        /// Update
        /// Calls [usp_update_CustRequirementByBomID]
        /// </summary>
        public abstract bool Update(System.Int32? bomID, System.Int32? updatedBy, System.Int32? clientNo, System.String ReqsId, System.Int32? BOMStatus);

        /// <summary>
		/// UpdateClose
		/// Calls [usp_update_CustomerRequirement_Close]
		/// </summary>
		public abstract bool UpdateClose(System.Int32? customerRequirementId, System.Boolean? includeAllRelatedAlternates, System.Int32? reasonNo, System.Int32? updatedBy);
        /// <summary>
        /// DataListNuggetPrint
        /// Calls [usp_datalistnugget_CustomerRequirementPrint]
        /// </summary>
        public abstract List<CustomerRequirementDetails> DataListNuggetPrint(System.Int32? clientId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String cmSearch, System.Int32? salesmanNo, System.Int32? companyNo, System.DateTime? receivedDateFrom, System.DateTime? receivedDateTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo, System.Int32? contactNo);
        /// <summary>
        /// Print Requirement
        /// Calls [usp_Print_CustomerRequirement_Enquiry_Form]
        /// </summary>
        public abstract List<CustomerRequirementDetails> GetForPrint(System.String xmlReqNo);
        /// <summary>
        /// Release
        /// Calls [usp_update_CustomerRequirement_Release]
        /// </summary>
        public abstract bool ReleaseRequirement(System.Int32? customerRequirementId, System.Int32? updatedBy, System.Int32? bomID);

        /// <summary>
        /// Release
        /// Calls [usp_update_BOM_Release]
        /// </summary>
        public abstract bool BOMReleaseRequirement(System.Int32? bomID, System.Int32? updatedBy);
        /// <summary>
        ///Recall NoBid
        /// Calls [usp_update_CustomerRequirement_RecallNoBid]
        /// </summary>
        public abstract bool RecallNoBidRequirement(System.Int32? customerRequirementId, System.Int32? updatedBy);

        /// <summary>
        /// NoBid
        /// Calls [usp_update_CustomerRequirement_NoBid]
        /// </summary>
        public abstract bool NoBidRequirement(System.Int32? customerRequirementId, System.Int32? updatedBy, System.Int32? bomID, string Notes);

        /// <summary>
        /// NoBid
        /// Calls [usp_update_BOM_NoBid]
        /// </summary>
        public abstract bool BOMNoBidRequirement(System.Int32? bomID, System.Int32? updatedBy, string Notes);
		#endregion
				
		/// <summary>
		/// Returns a new CustomerRequirementDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual CustomerRequirementDetails GetCustomerRequirementFromReader(DbDataReader reader) {
			CustomerRequirementDetails customerRequirement = new CustomerRequirementDetails();
			if (reader.HasRows) {
				customerRequirement.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0); //From: [Table]
				customerRequirement.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0); //From: [Table]
				customerRequirement.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				customerRequirement.FullPart = GetReaderValue_String(reader, "FullPart", ""); //From: [Table]
				customerRequirement.Part = GetReaderValue_String(reader, "Part", ""); //From: [Table]
				customerRequirement.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null); //From: [Table]
				customerRequirement.DateCode = GetReaderValue_String(reader, "DateCode", ""); //From: [Table]
				customerRequirement.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null); //From: [Table]
				customerRequirement.Quantity = GetReaderValue_Int32(reader, "Quantity", 0); //From: [Table]
				customerRequirement.Price = GetReaderValue_Double(reader, "Price", 0); //From: [Table]
				customerRequirement.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null); //From: [Table]
				customerRequirement.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue); //From: [Table]
				customerRequirement.Salesman = GetReaderValue_Int32(reader, "Salesman", 0); //From: [Table]
				customerRequirement.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue); //From: [Table]
				customerRequirement.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				customerRequirement.Instructions = GetReaderValue_String(reader, "Instructions", ""); //From: [Table]
				customerRequirement.Shortage = GetReaderValue_Boolean(reader, "Shortage", false); //From: [Table]
				customerRequirement.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0); //From: [Table]
				customerRequirement.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0); //From: [Table]
				customerRequirement.Alternate = GetReaderValue_Boolean(reader, "Alternate", false); //From: [Table]
				customerRequirement.OriginalCustomerRequirementNo = GetReaderValue_NullableInt32(reader, "OriginalCustomerRequirementNo", null); //From: [Table]
				customerRequirement.ReasonNo = GetReaderValue_NullableInt32(reader, "ReasonNo", null); //From: [Table]
				customerRequirement.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null); //From: [Table]
				customerRequirement.CustomerPart = GetReaderValue_String(reader, "CustomerPart", ""); //From: [Table]
				customerRequirement.Closed = GetReaderValue_Boolean(reader, "Closed", false); //From: [Table]
				customerRequirement.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0); //From: [Table]
				customerRequirement.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				customerRequirement.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				customerRequirement.UsageNo = GetReaderValue_NullableInt32(reader, "UsageNo", null); //From: [Table]
				customerRequirement.FullCustomerPart = GetReaderValue_String(reader, "FullCustomerPart", ""); //From: [Table]
				customerRequirement.BOM = GetReaderValue_NullableBoolean(reader, "BOM", null); //From: [Table]
				customerRequirement.BOMName = GetReaderValue_String(reader, "BOMName", ""); //From: [Table]
				customerRequirement.PartWatch = GetReaderValue_NullableBoolean(reader, "PartWatch", null); //From: [Table]
				customerRequirement.SalesmanName = GetReaderValue_String(reader, "SalesmanName", ""); //From: [usp_select_Credit]
				customerRequirement.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", ""); //From: [usp_datalistnugget_CustomerRequirement]
				customerRequirement.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_select_Credit]
				customerRequirement.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_select_Credit]
				customerRequirement.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_datalistnugget_CustomerRequirement]
				customerRequirement.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_select_Credit]
				customerRequirement.DisplayStatus = GetReaderValue_String(reader, "DisplayStatus", ""); //From: [usp_select_CustomerRequirement]
				customerRequirement.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null); //From: [Table]
				customerRequirement.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null); //From: [usp_select_Credit]
				customerRequirement.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null); //From: [usp_select_CustomerRequirement]
				customerRequirement.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_select_Credit]
				customerRequirement.ProductName = GetReaderValue_String(reader, "ProductName", ""); //From: [usp_select_CustomerRequirement]
				customerRequirement.ProductDescription = GetReaderValue_String(reader, "ProductDescription", ""); //From: [usp_select_CustomerRequirement]
				customerRequirement.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", ""); //From: [usp_select_CustomerRequirement]
				customerRequirement.PackageName = GetReaderValue_String(reader, "PackageName", ""); //From: [usp_select_CustomerRequirement]
				customerRequirement.PackageDescription = GetReaderValue_String(reader, "PackageDescription", ""); //From: [usp_select_CustomerRequirement]
				customerRequirement.UsageName = GetReaderValue_String(reader, "UsageName", ""); //From: [usp_select_CustomerRequirement]
				customerRequirement.CustomerRequirementValue = GetReaderValue_Double(reader, "CustomerRequirementValue", 0); //From: [usp_select_CustomerRequirement]
				customerRequirement.ClosedReason = GetReaderValue_String(reader, "ClosedReason", ""); //From: [usp_select_CustomerRequirement]
				customerRequirement.DivisionName = GetReaderValue_String(reader, "DivisionName", ""); //From: [usp_select_Credit]
				customerRequirement.Status = GetReaderValue_String(reader, "Status", ""); //From: [usp_selectAll_CustomerRequirement_open_for_Login]
				customerRequirement.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null); //From: [usp_selectAll_CustomerRequirement_open_for_Login]
				customerRequirement.Balance = GetReaderValue_NullableDouble(reader, "Balance", null); //From: [usp_selectAll_CustomerRequirement_open_for_Login]
				customerRequirement.DaysOverdue = GetReaderValue_NullableInt32(reader, "DaysOverdue", null); //From: [usp_selectAll_CustomerRequirement_open_for_Login]
				customerRequirement.ClientName = GetReaderValue_String(reader, "ClientName", ""); //From: [usp_source_CustomerRequirement]
			}
			return customerRequirement;
		}

        /// <summary>
        /// ItemSearch
        /// Calls [usp_itemsearch_CustomerReqsWithBOM]
        /// </summary>
        public abstract List<CustomerRequirementDetails> ItemSearchWithBOM(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Boolean? includeClosed, System.Int32? customerRequirementNoLo, System.Int32? customerRequirementNoHi, System.DateTime? receivedDateFrom, System.DateTime? receivedDateTo, System.Int32? client, System.String bomName);


        /// <summary>
        /// ItemSearch
        /// Calls [usp_itemsearch_CustRequirementWithoutBOM]
        /// </summary>
        public abstract List<CustomerRequirementDetails> ItemSearchWithoutBOM(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Boolean? includeClosed, System.Int32? customerRequirementNoLo, System.Int32? customerRequirementNoHi, System.DateTime? receivedDateFrom, System.DateTime? receivedDateTo, System.Int32? bomId, System.String BOMName);
	
		/// <summary>
		/// Returns a collection of CustomerRequirementDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<CustomerRequirementDetails> GetCustomerRequirementCollectionFromReader(DbDataReader reader) {
			List<CustomerRequirementDetails> customerRequirements = new List<CustomerRequirementDetails>();
			while (reader.Read()) customerRequirements.Add(GetCustomerRequirementFromReader(reader));
			return customerRequirements;
		}
        // [001] code start
        /// <summary>
        /// GetBOMListForCustomerRequirement 
        /// Calls [usp_selectAll_CustomerRequirement_for_BOM]
        /// </summary>
        public abstract List<CustomerRequirementDetails> GetBOMListForCustomerRequirement(System.Int32? BOMNo, System.Int32? clientID);
        // [001] code end
        public abstract List<CustomerRequirementDetails> GetHUBRFQReqNos(String ReqIds, System.Int32? clientID);
        /// <summary>
        /// This use for Mail Template of HURFQ
        /// </summary>
        /// <param name="BOMNo"></param>
        /// <param name="clientID"></param>
        /// Calls [usp_selectCusReqForMail]
        /// <returns></returns>
        public abstract List<CustomerRequirementDetails> GetHUBRFQForMail(System.Int32? BOMNo, System.Int32? clientID);

        /// <summary>
        /// GetBOMListForCRList
        /// Calls [usp_select_CustomerRequirements_for_BOM]
        /// </summary>
        public abstract List<List<object>> GetBOMListForCRList(System.Int32? BOMNo, System.Int32? clientID, System.Int32? CompanyNo);
        /// <summary>
        /// 
        protected virtual List<List<object>> GetCustReqDataFromReader(DbDataReader reader)
        {
            List<List<object>> lstReports = new List<List<object>>();
            while (reader.Read()) lstReports.Add(GetCustReqDataRowFromReader(reader));
            return lstReports;
        }

        protected virtual List<object> GetCustReqDataRowFromReader(DbDataReader reader)
        {
            List<object> lst = new List<object>(reader.FieldCount);
            for (int i = 0; i < reader.FieldCount; i++) lst.Add(reader.GetValue(i));
            return lst;
        }


        /// <summary>
        /// delete 
        /// Calls [usp_delete_CustomerRequirement_Bom]
        /// </summary>
        public abstract bool DeleteBomItem(int? bomId, int? requirementId, System.Int32? LoginID, System.Int32? clientId);

        /// <summary>
        /// delete 
        /// Calls [usp_UnRelease_CustomerRequirement_Bom]
        /// </summary>
        public abstract bool UnReleaseBomItem(int? bomId, int? requirementId);

        /// <summary>
        /// DataListNugget for HURFQ
        /// Calls [usp_datalistnugget_CustomerRequirementForHUBRFQ]
        /// add start date and end date  for searching by umendra
        /// </summary>
        public abstract List<CustomerRequirementDetails> DataListNuggetHUBRFQ(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String BOMCode, System.String bomName, System.Boolean? isPOHub, System.Int32? selectedClientNo, int? bomStatus, int? isAssignToMe, int? assignedUser, System.String Manufacturer, System.String Part, System.Int32? intDivision, System.DateTime? startdate, System.DateTime? enddate, System.Int32? salesPerson);
    }
}
