
/*

Marker     changed by      date         Remarks

[001]      Abhinav       31/05/2012   ESMS Ref:92 - Requirement Error - Urgent
[002]      Aashu Singh   10/07/2018   [REB-12515]: show the HUBRFQ link below the customer requirement number in the customer requirement nugget of the sourcing results
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
		public partial class CustomerRequirement : BizObject {
		
		#region Properties

		protected static DAL.CustomerRequirementElement Settings {
			get { return Globals.Settings.CustomerRequirements; }
		}

		/// <summary>
		/// CustomerRequirementId
		/// </summary>
		public System.Int32 CustomerRequirementId { get; set; }		
		/// <summary>
		/// CustomerRequirementNumber
		/// </summary>
		public System.Int32 CustomerRequirementNumber { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// FullPart
		/// </summary>
		public System.String FullPart { get; set; }		
		/// <summary>
		/// Part
		/// </summary>
		public System.String Part { get; set; }		
		/// <summary>
		/// ManufacturerNo
		/// </summary>
		public System.Int32? ManufacturerNo { get; set; }		
		/// <summary>
		/// DateCode
		/// </summary>
		public System.String DateCode { get; set; }		
		/// <summary>
		/// PackageNo
		/// </summary>
		public System.Int32? PackageNo { get; set; }		
		/// <summary>
		/// Quantity
		/// </summary>
		public System.Int32 Quantity { get; set; }		
		/// <summary>
		/// Price
		/// </summary>
		public System.Double Price { get; set; }		
		/// <summary>
		/// CurrencyNo
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }		
		/// <summary>
		/// ReceivedDate
		/// </summary>
		public System.DateTime ReceivedDate { get; set; }		
		/// <summary>
		/// Salesman
		/// </summary>
		public System.Int32 Salesman { get; set; }		
		/// <summary>
		/// DatePromised
		/// </summary>
		public System.DateTime DatePromised { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// Instructions
		/// </summary>
		public System.String Instructions { get; set; }		
		/// <summary>
		/// Shortage
		/// </summary>
		public System.Boolean Shortage { get; set; }		
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32 CompanyNo { get; set; }		
		/// <summary>
		/// ContactNo
		/// </summary>
		public System.Int32 ContactNo { get; set; }		
		/// <summary>
		/// Alternate
		/// </summary>
		public System.Boolean Alternate { get; set; }		
		/// <summary>
		/// OriginalCustomerRequirementNo
		/// </summary>
		public System.Int32? OriginalCustomerRequirementNo { get; set; }		
		/// <summary>
		/// ReasonNo
		/// </summary>
		public System.Int32? ReasonNo { get; set; }		
		/// <summary>
		/// ProductNo
		/// </summary>
		public System.Int32? ProductNo { get; set; }		
		/// <summary>
		/// CustomerPart
		/// </summary>
		public System.String CustomerPart { get; set; }		
		/// <summary>
		/// Closed
		/// </summary>
		public System.Boolean Closed { get; set; }		
		/// <summary>
		/// ROHS
		/// </summary>
		public System.Byte? ROHS { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// UsageNo
		/// </summary>
		public System.Int32? UsageNo { get; set; }		
		/// <summary>
		/// FullCustomerPart
		/// </summary>
		public System.String FullCustomerPart { get; set; }		
		/// <summary>
		/// BOM
		/// </summary>
		public System.Boolean? BOM { get; set; }		
		/// <summary>
		/// BOMName
		/// </summary>
		public System.String BOMName { get; set; }		
		/// <summary>
		/// PartWatch
		/// </summary>
		public System.Boolean? PartWatch { get; set; }		
		/// <summary>
		/// SalesmanName
		/// </summary>
		public System.String SalesmanName { get; set; }		
		/// <summary>
		/// ManufacturerCode
		/// </summary>
		public System.String ManufacturerCode { get; set; }		
		/// <summary>
		/// CompanyName
		/// </summary>
		public System.String CompanyName { get; set; }		
		/// <summary>
		/// ContactName
		/// </summary>
		public System.String ContactName { get; set; }		
		/// <summary>
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }		
		/// <summary>
		/// RowCnt
		/// </summary>
		public System.Int32? RowCnt { get; set; }		
		/// <summary>
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }		
		/// <summary>
		/// DisplayStatus
		/// </summary>
		public System.String DisplayStatus { get; set; }		
		/// <summary>
		/// DivisionNo
		/// </summary>
		public System.Int32? DivisionNo { get; set; }		
		/// <summary>
		/// TeamNo
		/// </summary>
		public System.Int32? TeamNo { get; set; }		
		/// <summary>
		/// CompanyOnStop
		/// </summary>
		public System.Boolean? CompanyOnStop { get; set; }		
		/// <summary>
		/// CurrencyDescription
		/// </summary>
		public System.String CurrencyDescription { get; set; }		
		/// <summary>
		/// ProductName
		/// </summary>
		public System.String ProductName { get; set; }		
		/// <summary>
		/// ProductDescription
		/// </summary>
		public System.String ProductDescription { get; set; }		
		/// <summary>
		/// ManufacturerName
		/// </summary>
		public System.String ManufacturerName { get; set; }		
		/// <summary>
		/// PackageName
		/// </summary>
		public System.String PackageName { get; set; }		
		/// <summary>
		/// PackageDescription
		/// </summary>
		public System.String PackageDescription { get; set; }		
		/// <summary>
		/// UsageName
		/// </summary>
		public System.String UsageName { get; set; }		
		/// <summary>
		/// CustomerRequirementValue
		/// </summary>
		public System.Double CustomerRequirementValue { get; set; }		
		/// <summary>
		/// ClosedReason
		/// </summary>
		public System.String ClosedReason { get; set; }		
		/// <summary>
		/// DivisionName
		/// </summary>
		public System.String DivisionName { get; set; }		
		/// <summary>
		/// Status
		/// </summary>
		public System.String Status { get; set; }		
		/// <summary>
		/// CreditLimit
		/// </summary>
		public System.Double? CreditLimit { get; set; }		
		/// <summary>
		/// Balance
		/// </summary>
		public System.Double? Balance { get; set; }		
		/// <summary>
		/// DaysOverdue
		/// </summary>
		public System.Int32? DaysOverdue { get; set; }		
		/// <summary>
		/// ClientName
		/// </summary>
		public System.String ClientName { get; set; }
        /// <summary>
        /// Traceability
        /// </summary>
        public System.Boolean? Traceability { get; set; }

        /// <summary>
        /// BOMNo
        /// </summary>
        public System.Int32 BOMNo { get; set; }
        /// <summary>
        /// BOMHeader
        /// </summary>
        public System.String BOMHeader { get; set; }
        /// <summary>
        /// BOMCode
        /// </summary>
        public System.String BOMCode { get; set; }       
        public string BOMFullName { get; set; }
        public System.Int32? POHubReleaseBy { get; set; }
        public System.Int32? RequestToPOHubBy { get; set; }
        public System.String BOMStatus { get; set; }
        public int? SourcingResultId { get; set; }
        /// <summary>
        /// Price (from Table)
        /// </summary>
        public System.Double ConvertedTargetValue { get; set; }
        public System.String BOMCurrencyCode { get; set; }
        public int? PurchaseQuoteNumber { get; set; }
        public int? PurchaseQuoteId { get; set; }
        public System.Double PHPrice { get; set; }
        public System.String PHCurrencyCode { get; set; }
        public int? POHubCompany { get; set; }
        public System.Boolean? FactorySealed { get; set; }
        public System.String MSL { get; set; }
        public System.Int32 AllSorcingHasDelDate { get; set; }
        public int AllSorcingHasProduct { get; set; }
        public System.Boolean? AS9120 { get; set; }
        public int? SourcingResultNo { get; set; }
        public System.Int32 SourcingResult { get; set; }

         public   System.Boolean? PQA { get; set; }
         public System.Boolean? Obsolete { get; set; }
         public  System.Boolean? LastTimeBuy { get; set; }
         public  System.Boolean? RefirbsAcceptable {  get; set; }
         public  System.Boolean? TestingRequired { get; set; }
         public  System.Double? TargetSellPrice { get; set; }
         public  System.Double? CompetitorBestOffer { get; set; }
          public System.DateTime? CustomerDecisionDate { get; set; }
          public  System.DateTime? RFQClosingDate { get; set; }
          public   System.Int32? QuoteValidityRequired { get; set; }
           public System.Int32? Type { get; set; }
            public    System.Boolean? OrderToPlace { get; set; }
            public System.Int32? RequirementforTraceability { get; set; }
            public System.String QuoteValidityText { get; set; }
            public System.String ReqTypeText { get; set; }
            public System.String ReqForTraceabilityText { get; set; }
            public System.Boolean? IsGlobalCurrencySame { get; set; }
            public System.Boolean? HasClientSourcingResult { get; set; }
            public System.Boolean? HasHubSourcingResult { get; set; }
            public System.String EAU { get; set; }
            public System.Int32? ClientGlobalCurrencyNo { get; set; }
            public System.Int32? ReqGlobalCurrencyNo { get; set; }
            public System.String ClientCurrencyCode { get; set; }
            public System.Int32? ClientCurrencyNo { get; set; }
            public System.String ReqNotes { get; set; }
            public System.String ClientCode { get; set; }
            public Boolean? IsNoBid { get; set; }
            public System.String NoBidNotes { get; set; }
            public System.Boolean? IsCurrencyInSameFaimly { get; set; }
            public System.Boolean? AlternativesAccepted {get; set;}
            public System.Boolean? RepeatBusiness { get; set; }
            public System.DateTime? DateRequestToPOHub { get; set; }
            public System.Int32 POCurrencyNo { get; set; }
            public System.DateTime? ExpeditDate { get; set; }
            public System.Int32 UpdateByPH { get; set; }
            public System.String DutyCode { get; set; }
            public System.Double? DutyRate { get; set; }
            public System.Int32? MSLLevelNo { get; set; }
            public System.Boolean? IsProdHaz { get; set; }
            public System.Double? TotalValue { get; set; }
            public System.Double? TotalInBase { get; set; }
           
		#endregion 

		
		#region Methods
		
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_CustomerRequirement_for_Client]
		/// </summary>
		public static Int32 CountForClient(System.Int32? clientId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.CountForClient(clientId);
		}		
         /// <summary>
		/// CountForCompany
		/// Calls [usp_count_CustomerRequirement_for_Company]
		/// </summary>
		public static Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeClosed) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.CountForCompany(companyId, includeClosed);
		}		/// <summary>
		/// CountOpenForCompany
		/// Calls [usp_count_CustomerRequirement_open_for_Company]
		/// </summary>
		public static Int32 CountOpenForCompany(System.Int32? companyId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.CountOpenForCompany(companyId);
		}		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_CustomerRequirement]
		/// </summary>
		public static List<CustomerRequirement> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanNo, System.Boolean? recentOnly, System.Boolean? includeClosed, System.Int32? customerRequirementNoLo, System.Int32? customerRequirementNoHi, System.DateTime? receivedDateFrom, System.DateTime? receivedDateTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo, System.Boolean? partWatch, System.String bomNameSearch,System.String BOMCode,System.Int32? totalLo, System.Int32? totalHi) {
            List<CustomerRequirementDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.DataListNugget(clientId, teamId, divisionId, loginId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, salesmanNo, recentOnly, includeClosed, customerRequirementNoLo, customerRequirementNoHi, receivedDateFrom, receivedDateTo, datePromisedFrom, datePromisedTo, partWatch, bomNameSearch, BOMCode, totalLo, totalHi);
			if (lstDetails == null) {
				return new List<CustomerRequirement>();
			} else {
				List<CustomerRequirement> lst = new List<CustomerRequirement>();
				foreach (CustomerRequirementDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CustomerRequirement obj = new Rebound.GlobalTrader.BLL.CustomerRequirement();
					obj.CustomerRequirementId = objDetails.CustomerRequirementId;
					obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
					obj.Salesman = objDetails.Salesman;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.Quantity = objDetails.Quantity;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.ReceivedDate = objDetails.ReceivedDate;
					obj.DatePromised = objDetails.DatePromised;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
                    obj.BOMCode = objDetails.BOMCode;
                    obj.BOMNo = (int)objDetails.BOMNo;
                    obj.BOMName = objDetails.BOMName;
                    obj.TotalValue = objDetails.TotalValue;
                    obj.TotalInBase = objDetails.TotalInBase;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

		/// <summary>
		/// Delete
		/// Calls [usp_delete_CustomerRequirement]
		/// </summary>
		public static bool Delete(System.Int32? customerRequirementId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.Delete(customerRequirementId);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_CustomerRequirement]
		/// </summary>
        public static Int32 Insert(System.Int32? clientNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? receivedDate, System.Int32? salesman, System.DateTime? datePromised, System.String notes, System.String instructions, System.Boolean? shortage, System.Int32? companyNo, System.Int32? contactNo, System.Int32? usageNo, System.Boolean? alternate, System.Int32? originalCustomerRequirementNo, System.Int32? reasonNo, System.Int32? productNo, System.String customerPart, System.Boolean? closed, System.Byte? rohs, System.Int32? updatedBy, System.Boolean? partWatch, System.Boolean? bom, System.String bomName, System.Int32? BOMNo, System.Boolean? FactorySealed, System.String MSL, System.Boolean? PQA, System.Boolean? ObsoleteChk, System.Boolean? LastTimeBuyChk, System.Boolean? RefirbsAcceptableChk, System.Boolean? TestingRequiredChk, System.Double? TargetSellPrice, System.Double? CompetitorBestOffer, System.DateTime? CustomerDecisionDate, System.DateTime? RFQClosingDate, System.Int32? QuoteValidityRequired, System.Int32? Type, System.Boolean? OrderToPlace, System.Int32? RequirementforTraceability, System.String EAU, System.Boolean? AlternativesAccepted, System.Boolean? RepeatBusiness)
        {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.Insert(clientNo, part, manufacturerNo, dateCode, packageNo, quantity, price, currencyNo, receivedDate, salesman, datePromised, notes, instructions, shortage, companyNo, contactNo, usageNo, alternate, originalCustomerRequirementNo, reasonNo, productNo, customerPart, closed, rohs, updatedBy, partWatch, bom, bomName,BOMNo,FactorySealed,MSL, PQA,  ObsoleteChk,  LastTimeBuyChk,  RefirbsAcceptableChk,  TestingRequiredChk,  TargetSellPrice,  CompetitorBestOffer,  CustomerDecisionDate,  RFQClosingDate,  QuoteValidityRequired,Type, OrderToPlace,  RequirementforTraceability,EAU,AlternativesAccepted,RepeatBusiness);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_CustomerRequirement]
		/// </summary>
		public Int32 Insert() {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.Insert(ClientNo, Part, ManufacturerNo, DateCode, PackageNo, Quantity, Price, CurrencyNo, ReceivedDate, Salesman, DatePromised, Notes, Instructions, Shortage, CompanyNo, ContactNo, UsageNo, Alternate, OriginalCustomerRequirementNo, ReasonNo, ProductNo, CustomerPart, Closed, ROHS, UpdatedBy, PartWatch, BOM, BOMName, BOMNo, FactorySealed, MSL, PQA, Obsolete, LastTimeBuy, RefirbsAcceptable, TestingRequired, TargetSellPrice, CompetitorBestOffer, CustomerDecisionDate, RFQClosingDate, QuoteValidityRequired, Type, OrderToPlace, RequirementforTraceability,EAU,AlternativesAccepted,RepeatBusiness);
		}
		/// <summary>
		/// InsertAsAlternate
		/// Calls [usp_insert_CustomerRequirement_as_Alternate]
		/// </summary>
		public static Int32 InsertAsAlternate(System.String customerRequirementName, System.Int32? customerRequirementNumber, System.Int32? clientNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? receivedDate, System.Int32? salesman, System.DateTime? datePromised, System.String notes, System.String instructions, System.Boolean? shortage, System.Int32? companyNo, System.Int32? contactNo, System.Int32? usageNo, System.Int32? originalCustomerRequirementNo, System.Int32? reasonNo, System.Int32? productNo, System.String customerPart, System.Boolean? closed, System.Byte? rohs, System.Int32? updatedBy, System.Boolean? partWatch, System.Boolean? bom, System.String bomName,
            System.Int32? salesmanno, System.Boolean? PQA, System.Boolean? ObsoleteChk, System.Boolean? LastTimeBuyChk, System.Boolean? RefirbsAcceptableChk, System.Boolean? TestingRequiredChk, System.Boolean? AlternativesAccepted, System.Boolean? RepeatBusiness, System.Double? CompetitorBestOffer, System.DateTime? CustomerDecisionDate, System.DateTime? RFQClosingDate, System.Int32? QuoteValidityRequired, System.Int32? Type, System.Boolean? OrderToPlace, System.Boolean? FactorySealed, System.String MSL, System.Int32? BOMNo, System.Int32? RequirementforTraceability, System.String EAU)
        {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.InsertAsAlternate(customerRequirementName, customerRequirementNumber, clientNo, part, manufacturerNo, dateCode, packageNo, quantity, price, currencyNo, receivedDate, salesman, datePromised, notes, instructions, shortage, companyNo, contactNo, usageNo, originalCustomerRequirementNo, reasonNo, productNo, customerPart, closed, rohs, updatedBy, partWatch, bom, bomName,
                salesmanno, PQA, ObsoleteChk,LastTimeBuyChk, RefirbsAcceptableChk, TestingRequiredChk, AlternativesAccepted, RepeatBusiness, CompetitorBestOffer, CustomerDecisionDate, RFQClosingDate,  QuoteValidityRequired,Type, OrderToPlace, FactorySealed,  MSL,  BOMNo,  RequirementforTraceability, EAU);
			return objReturn;
		}
        /// <summary>
        /// InsertAsAllAlternate
        /// Calls [usp_insert_CustomerRequirement_as_AllAlternate]
        /// </summary>
        public static Int32 InsertAsAllAlternate(System.Int32? clientNo, System.String part, System.Int32? CustRequirementId)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.InsertAsAllAlternate(clientNo, part, CustRequirementId);
            return objReturn;
        }


		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_CustomerRequirement]
		/// </summary>
		public static List<CustomerRequirement> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Boolean? includeClosed, System.Int32? customerRequirementNoLo, System.Int32? customerRequirementNoHi, System.DateTime? receivedDateFrom, System.DateTime? receivedDateTo) {
			List<CustomerRequirementDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, partSearch, cmSearch, includeClosed, customerRequirementNoLo, customerRequirementNoHi, receivedDateFrom, receivedDateTo);
			if (lstDetails == null) {
				return new List<CustomerRequirement>();
			} else {
				List<CustomerRequirement> lst = new List<CustomerRequirement>();
				foreach (CustomerRequirementDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CustomerRequirement obj = new Rebound.GlobalTrader.BLL.CustomerRequirement();
					obj.CustomerRequirementId = objDetails.CustomerRequirementId;
					obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
					obj.CompanyName = objDetails.CompanyName;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.ReceivedDate = objDetails.ReceivedDate;
					obj.Quantity = objDetails.Quantity;
					obj.Price = objDetails.Price;
					obj.CurrencyCode = objDetails.CurrencyCode;
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
		/// Get
		/// Calls [usp_select_CustomerRequirement]
		/// </summary>
		public static CustomerRequirement Get(System.Int32? customerRequirementId) {
			Rebound.GlobalTrader.DAL.CustomerRequirementDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.Get(customerRequirementId);
			if (objDetails == null) {
				return null;
			} else {
				CustomerRequirement obj = new CustomerRequirement();
				obj.CustomerRequirementId = objDetails.CustomerRequirementId;
				obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
				obj.ClientNo = objDetails.ClientNo;
				obj.FullPart = objDetails.FullPart;
				obj.Part = objDetails.Part;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.DateCode = objDetails.DateCode;
				obj.PackageNo = objDetails.PackageNo;
				obj.Quantity = objDetails.Quantity;
				obj.Price = objDetails.Price;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.ReceivedDate = objDetails.ReceivedDate;
				obj.Salesman = objDetails.Salesman;
				obj.DatePromised = objDetails.DatePromised;
				obj.Notes = objDetails.Notes;
				obj.Instructions = objDetails.Instructions;
				obj.Shortage = objDetails.Shortage;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.ContactNo = objDetails.ContactNo;
				obj.Alternate = objDetails.Alternate;
				obj.OriginalCustomerRequirementNo = objDetails.OriginalCustomerRequirementNo;
				obj.ReasonNo = objDetails.ReasonNo;
				obj.ProductNo = objDetails.ProductNo;
				obj.CustomerPart = objDetails.CustomerPart;
				obj.Closed = objDetails.Closed;
				obj.ROHS = objDetails.ROHS;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.UsageNo = objDetails.UsageNo;
				obj.DisplayStatus = objDetails.DisplayStatus;
				obj.SalesmanName = objDetails.SalesmanName;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.TeamNo = objDetails.TeamNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.CompanyOnStop = objDetails.CompanyOnStop;
				obj.ContactName = objDetails.ContactName;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyDescription = objDetails.CurrencyDescription;
				obj.ProductName = objDetails.ProductName;
				obj.ProductDescription = objDetails.ProductDescription;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.ManufacturerCode = objDetails.ManufacturerCode;
				obj.PackageName = objDetails.PackageName;
				obj.PackageDescription = objDetails.PackageDescription;
				obj.UsageName = objDetails.UsageName;
				obj.CustomerRequirementValue = objDetails.CustomerRequirementValue;
				obj.ClosedReason = objDetails.ClosedReason;
				obj.PartWatch = objDetails.PartWatch;
				obj.BOM = objDetails.BOM;
				obj.BOMName = objDetails.BOMName;
				obj.DivisionName = objDetails.DivisionName;
                obj.Traceability = objDetails.Traceability;
                //obj.BOMHeader = objDetails.BOMNo + "-" + objDetails.BOMHeader;
                //obj.BOMHeader = objDetails.BOMHeader + " (" + objDetails.BOMStatus+")";
                obj.BOMHeader = !string.IsNullOrEmpty(objDetails.BOMHeader) ? objDetails.BOMHeader + " (" + objDetails.BOMStatus + ")" : "";//NEW code
                obj.BOMNo = objDetails.BOMNo==null?0:(int)objDetails.BOMNo;
                obj.RequestToPOHubBy = objDetails.RequestToPOHubBy;
                obj.FactorySealed = objDetails.FactorySealed;
                obj.MSL = objDetails.MSL;
                obj.SourcingResultNo = objDetails.SourcingResultNo;
                obj.PQA = objDetails.PQA;
                obj.Obsolete = objDetails.Obsolete;
                obj.LastTimeBuy = objDetails.LastTimeBuy;
                obj.RefirbsAcceptable = objDetails.RefirbsAcceptable;
                obj.TestingRequired = objDetails.TestingRequired;
                obj.TargetSellPrice = objDetails.TargetSellPrice;
                obj.CompetitorBestOffer = objDetails.CompetitorBestOffer;
                obj.CustomerDecisionDate = objDetails.CustomerDecisionDate;
                obj.RFQClosingDate = objDetails.RFQClosingDate;
                obj.QuoteValidityRequired = objDetails.QuoteValidityRequired;
                obj.Type = objDetails.Type;
                obj.OrderToPlace = objDetails.OrderToPlace;
                obj.RequirementforTraceability = objDetails.RequirementforTraceability;
                obj.QuoteValidityText = objDetails.QuoteValidityText;
                obj.ReqTypeText = objDetails.ReqTypeText;
                obj.ReqForTraceabilityText = objDetails.ReqForTraceabilityText;
                obj.EAU = objDetails.EAU;
                obj.ReqNotes = objDetails.ReqNotes;
                obj.POHubReleaseBy = objDetails.POHubReleaseBy;
                obj.ClientGlobalCurrencyNo = objDetails.ClientGlobalCurrencyNo;
                obj.IsCurrencyInSameFaimly = objDetails.IsCurrencyInSameFaimly;
                obj.AlternativesAccepted = objDetails.AlternativesAccepted;
                obj.RepeatBusiness = objDetails.RepeatBusiness;
                obj.ProductInactive = objDetails.ProductInactive;
                obj.DutyCode = objDetails.DutyCode;
                obj.DutyRate = objDetails.DutyRate;                
                obj.MSLLevelNo = objDetails.MSLLevelNo;
                obj.IsProdHaz = objDetails.IsProdHaz;
				objDetails = null;
				return obj;
			}
		}

        /// <summary>
        /// Get
        /// Calls [usp_select_CustomerRequirementBOM]
        /// </summary>
        public static CustomerRequirement GetReqBOM(System.Int32? customerRequirementId)
        {
            Rebound.GlobalTrader.DAL.CustomerRequirementDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.GetReqBOM(customerRequirementId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                CustomerRequirement obj = new CustomerRequirement();
                obj.CustomerRequirementId = objDetails.CustomerRequirementId;
                obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
                obj.ClientNo = objDetails.ClientNo;
                obj.FullPart = objDetails.FullPart;
                obj.Part = objDetails.Part;
                obj.ManufacturerNo = objDetails.ManufacturerNo;
                obj.DateCode = objDetails.DateCode;
                obj.PackageNo = objDetails.PackageNo;
                obj.Quantity = objDetails.Quantity;
                obj.Price = objDetails.Price;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.ReceivedDate = objDetails.ReceivedDate;
                obj.Salesman = objDetails.Salesman;
                obj.DatePromised = objDetails.DatePromised;
                obj.Notes = objDetails.Notes;
                obj.Instructions = objDetails.Instructions;
                obj.Shortage = objDetails.Shortage;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ContactNo = objDetails.ContactNo;
                obj.Alternate = objDetails.Alternate;
                obj.OriginalCustomerRequirementNo = objDetails.OriginalCustomerRequirementNo;
                obj.ReasonNo = objDetails.ReasonNo;
                obj.ProductNo = objDetails.ProductNo;
                obj.CustomerPart = objDetails.CustomerPart;
                obj.Closed = objDetails.Closed;
                obj.ROHS = objDetails.ROHS;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.UsageNo = objDetails.UsageNo;
                obj.DisplayStatus = objDetails.DisplayStatus;
                obj.SalesmanName = objDetails.SalesmanName;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.TeamNo = objDetails.TeamNo;
                obj.CompanyName = objDetails.CompanyName;
                obj.CompanyOnStop = objDetails.CompanyOnStop;
                obj.ContactName = objDetails.ContactName;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.ProductName = objDetails.ProductName;
                obj.ProductDescription = objDetails.ProductDescription;
                obj.ManufacturerName = objDetails.ManufacturerName;
                obj.ManufacturerCode = objDetails.ManufacturerCode;
                obj.PackageName = objDetails.PackageName;
                obj.PackageDescription = objDetails.PackageDescription;
                obj.UsageName = objDetails.UsageName;
                obj.CustomerRequirementValue = objDetails.CustomerRequirementValue;
                obj.ClosedReason = objDetails.ClosedReason;
                obj.PartWatch = objDetails.PartWatch;
                obj.BOM = objDetails.BOM;
                obj.BOMName = objDetails.BOMName;
                obj.DivisionName = objDetails.DivisionName;
                obj.Traceability = objDetails.Traceability;
                //obj.BOMHeader = objDetails.BOMNo + "-" + objDetails.BOMHeader;
                //obj.BOMHeader = objDetails.BOMHeader + " (" + objDetails.BOMStatus+")";
                obj.BOMHeader = !string.IsNullOrEmpty(objDetails.BOMHeader) ? objDetails.BOMHeader + " (" + objDetails.BOMStatus + ")" : "";//NEW code
                obj.BOMNo = objDetails.BOMNo == null ? 0 : (int)objDetails.BOMNo;
                obj.RequestToPOHubBy = objDetails.RequestToPOHubBy;
                obj.FactorySealed = objDetails.FactorySealed;
                obj.MSL = objDetails.MSL;
                obj.SourcingResultNo = objDetails.SourcingResultNo;
                obj.PQA = objDetails.PQA;
                obj.Obsolete = objDetails.Obsolete;
                obj.LastTimeBuy = objDetails.LastTimeBuy;
                obj.RefirbsAcceptable = objDetails.RefirbsAcceptable;
                obj.TestingRequired = objDetails.TestingRequired;
                obj.TargetSellPrice = objDetails.TargetSellPrice;
                obj.CompetitorBestOffer = objDetails.CompetitorBestOffer;
                obj.CustomerDecisionDate = objDetails.CustomerDecisionDate;
                obj.RFQClosingDate = objDetails.RFQClosingDate;
                obj.QuoteValidityRequired = objDetails.QuoteValidityRequired;
                obj.Type = objDetails.Type;
                obj.OrderToPlace = objDetails.OrderToPlace;
                obj.RequirementforTraceability = objDetails.RequirementforTraceability;
                obj.QuoteValidityText = objDetails.QuoteValidityText;
                obj.ReqTypeText = objDetails.ReqTypeText;
                obj.ReqForTraceabilityText = objDetails.ReqForTraceabilityText;
                obj.SourcingResult = objDetails.SourcingResult;
                obj.EAU = objDetails.EAU;
                obj.ClientGlobalCurrencyNo = objDetails.ClientGlobalCurrencyNo;
                obj.ReqGlobalCurrencyNo = objDetails.ReqGlobalCurrencyNo;
                obj.ClientCurrencyCode = objDetails.ClientCurrencyCode;
                obj.ClientCurrencyNo = objDetails.ClientCurrencyNo;
                obj.IsNoBid = objDetails.IsNoBid;
                obj.NoBidNotes = objDetails.NoBidNotes;
                obj.AlternativesAccepted = objDetails.AlternativesAccepted;
                obj.RepeatBusiness = objDetails.RepeatBusiness;
                obj.DutyCode = objDetails.DutyCode;
                obj.DutyRate = objDetails.DutyRate;
                obj.MSLLevelNo = objDetails.MSLLevelNo;
                objDetails = null;
                return obj;
            }
        }
            /// <summary>
		/// GetByNumber
		/// Calls [usp_select_CustomerRequirement_by_Number]
		/// </summary>
		public static CustomerRequirement GetByNumber(System.Int32? customerRequirementNumber, System.Int32? clientNo) {
			Rebound.GlobalTrader.DAL.CustomerRequirementDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.GetByNumber(customerRequirementNumber, clientNo);
			if (objDetails == null) {
				return null;
			} else {
				CustomerRequirement obj = new CustomerRequirement();
				obj.CustomerRequirementId = objDetails.CustomerRequirementId;
				obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
				obj.ClientNo = objDetails.ClientNo;
				obj.FullPart = objDetails.FullPart;
				obj.Part = objDetails.Part;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.DateCode = objDetails.DateCode;
				obj.PackageNo = objDetails.PackageNo;
				obj.Quantity = objDetails.Quantity;
				obj.Price = objDetails.Price;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.ReceivedDate = objDetails.ReceivedDate;
				obj.Salesman = objDetails.Salesman;
				obj.DatePromised = objDetails.DatePromised;
				obj.Notes = objDetails.Notes;
				obj.Instructions = objDetails.Instructions;
				obj.Shortage = objDetails.Shortage;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.ContactNo = objDetails.ContactNo;
				obj.Alternate = objDetails.Alternate;
				obj.OriginalCustomerRequirementNo = objDetails.OriginalCustomerRequirementNo;
				obj.ReasonNo = objDetails.ReasonNo;
				obj.ProductNo = objDetails.ProductNo;
				obj.CustomerPart = objDetails.CustomerPart;
				obj.Closed = objDetails.Closed;
				obj.ROHS = objDetails.ROHS;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.UsageNo = objDetails.UsageNo;
				obj.DisplayStatus = objDetails.DisplayStatus;
				obj.SalesmanName = objDetails.SalesmanName;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.TeamNo = objDetails.TeamNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.CompanyOnStop = objDetails.CompanyOnStop;
				obj.ContactName = objDetails.ContactName;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyDescription = objDetails.CurrencyDescription;
				obj.ProductName = objDetails.ProductName;
				obj.ProductDescription = objDetails.ProductDescription;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.ManufacturerCode = objDetails.ManufacturerCode;
				obj.PackageName = objDetails.PackageName;
				obj.PackageDescription = objDetails.PackageDescription;
				obj.UsageName = objDetails.UsageName;
				obj.CustomerRequirementValue = objDetails.CustomerRequirementValue;
				obj.ClosedReason = objDetails.ClosedReason;
				obj.PartWatch = objDetails.PartWatch;
				obj.BOM = objDetails.BOM;
				obj.BOMName = objDetails.BOMName;
				obj.DivisionName = objDetails.DivisionName;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_CustomerRequirement_for_Page]
		/// </summary>
		public static CustomerRequirement GetForPage(System.Int32? customerRequirementId) {
			Rebound.GlobalTrader.DAL.CustomerRequirementDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.GetForPage(customerRequirementId);
			if (objDetails == null) {
				return null;
			} else {
				CustomerRequirement obj = new CustomerRequirement();
				obj.CustomerRequirementId = objDetails.CustomerRequirementId;
				obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
				obj.ClientNo = objDetails.ClientNo;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.DisplayStatus = objDetails.DisplayStatus;
                obj.TeamNo = objDetails.TeamNo;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.Salesman = objDetails.Salesman;
                obj.ContactNo = objDetails.ContactNo;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetIdByNumber
		/// Calls [usp_select_CustomerRequirement_Id_by_Number]
		/// </summary>
		public static CustomerRequirement GetIdByNumber(System.Int32? customerRequirementNumber, System.Int32? clientNo) {
			Rebound.GlobalTrader.DAL.CustomerRequirementDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.GetIdByNumber(customerRequirementNumber, clientNo);
			if (objDetails == null) {
				return null;
			} else {
				CustomerRequirement obj = new CustomerRequirement();
				obj.CustomerRequirementId = objDetails.CustomerRequirementId;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetNextNumber
		/// Calls [usp_select_CustomerRequirement_NextNumber]
		/// </summary>
		public static CustomerRequirement GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy) {
			Rebound.GlobalTrader.DAL.CustomerRequirementDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.GetNextNumber(clientNo, updatedBy);
			if (objDetails == null) {
				return null;
			} else {
				CustomerRequirement obj = new CustomerRequirement();
				obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetNumberById
		/// Calls [usp_select_CustomerRequirement_Number_by_Id]
		/// </summary>
		public static CustomerRequirement GetNumberById(System.Int32? customerRequirementId) {
			Rebound.GlobalTrader.DAL.CustomerRequirementDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.GetNumberById(customerRequirementId);
			if (objDetails == null) {
				return null;
			} else {
				CustomerRequirement obj = new CustomerRequirement();
				obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForCompany
		/// Calls [usp_selectAll_CustomerRequirement_for_Company]
		/// </summary>
		public static List<CustomerRequirement> GetListForCompany(System.Int32? companyId, System.Boolean? includeClosed) {
			List<CustomerRequirementDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.GetListForCompany(companyId, includeClosed);
			if (lstDetails == null) {
				return new List<CustomerRequirement>();
			} else {
				List<CustomerRequirement> lst = new List<CustomerRequirement>();
				foreach (CustomerRequirementDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CustomerRequirement obj = new Rebound.GlobalTrader.BLL.CustomerRequirement();
					obj.CustomerRequirementId = objDetails.CustomerRequirementId;
					obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
					obj.ClientNo = objDetails.ClientNo;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.DateCode = objDetails.DateCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.Quantity = objDetails.Quantity;
					obj.Price = objDetails.Price;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.ReceivedDate = objDetails.ReceivedDate;
					obj.Salesman = objDetails.Salesman;
					obj.DatePromised = objDetails.DatePromised;
					obj.Notes = objDetails.Notes;
					obj.Instructions = objDetails.Instructions;
					obj.Shortage = objDetails.Shortage;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.ContactNo = objDetails.ContactNo;
					obj.Alternate = objDetails.Alternate;
					obj.OriginalCustomerRequirementNo = objDetails.OriginalCustomerRequirementNo;
					obj.ReasonNo = objDetails.ReasonNo;
					obj.ProductNo = objDetails.ProductNo;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.Closed = objDetails.Closed;
					obj.ROHS = objDetails.ROHS;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.UsageNo = objDetails.UsageNo;
					obj.DisplayStatus = objDetails.DisplayStatus;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.TeamNo = objDetails.TeamNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.CompanyOnStop = objDetails.CompanyOnStop;
					obj.ContactName = objDetails.ContactName;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.UsageName = objDetails.UsageName;
					obj.CustomerRequirementValue = objDetails.CustomerRequirementValue;
					obj.ClosedReason = objDetails.ClosedReason;
					obj.PartWatch = objDetails.PartWatch;
					obj.BOM = objDetails.BOM;
					obj.BOMName = objDetails.BOMName;
					obj.DivisionName = objDetails.DivisionName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForCustomerRequirementNumber
		/// Calls [usp_selectAll_CustomerRequirement_for_CustomerRequirementNumber]
		/// </summary>
        public static List<CustomerRequirement> GetListForCustomerRequirementNumber(System.Int32? customerRequirementNumber, System.Int32? clientNo)
        {
			List<CustomerRequirementDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.GetListForCustomerRequirementNumber(customerRequirementNumber,clientNo);
			if (lstDetails == null) {
				return new List<CustomerRequirement>();
			} else {
				List<CustomerRequirement> lst = new List<CustomerRequirement>();
				foreach (CustomerRequirementDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CustomerRequirement obj = new Rebound.GlobalTrader.BLL.CustomerRequirement();
					obj.CustomerRequirementId = objDetails.CustomerRequirementId;
					obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
					obj.ClientNo = objDetails.ClientNo;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.DateCode = objDetails.DateCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.Quantity = objDetails.Quantity;
					obj.Price = objDetails.Price;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.ReceivedDate = objDetails.ReceivedDate;
					obj.Salesman = objDetails.Salesman;
					obj.DatePromised = objDetails.DatePromised;
					obj.Notes = objDetails.Notes;
					obj.Instructions = objDetails.Instructions;
					obj.Shortage = objDetails.Shortage;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.ContactNo = objDetails.ContactNo;
					obj.Alternate = objDetails.Alternate;
					obj.OriginalCustomerRequirementNo = objDetails.OriginalCustomerRequirementNo;
					obj.ReasonNo = objDetails.ReasonNo;
					obj.ProductNo = objDetails.ProductNo;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.Closed = objDetails.Closed;
					obj.ROHS = objDetails.ROHS;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.UsageNo = objDetails.UsageNo;
					obj.DisplayStatus = objDetails.DisplayStatus;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.TeamNo = objDetails.TeamNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.CompanyOnStop = objDetails.CompanyOnStop;
					obj.ContactName = objDetails.ContactName;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.UsageName = objDetails.UsageName;
					obj.CustomerRequirementValue = objDetails.CustomerRequirementValue;
					obj.ClosedReason = objDetails.ClosedReason;
					obj.PartWatch = objDetails.PartWatch;
					obj.BOM = objDetails.BOM;
					obj.BOMName = objDetails.BOMName;
					obj.DivisionName = objDetails.DivisionName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
        /// 
        /// [001] code start
        /// <summary>
        /// GetListForCustomerRequirement
        /// Calls [usp_selectAll_CustomerRequirement_for_CustomerRequirement]
        /// </summary>
        public static List<CustomerRequirement> GetListForCustomerRequirement(System.Int32? customerRequirementNo,System.Int32?  clientID)
        {
            List<CustomerRequirementDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.GetListForCustomerRequirement(customerRequirementNo, clientID);
            if (lstDetails == null)
            {
                return new List<CustomerRequirement>();
            }
            else
            {
                List<CustomerRequirement> lst = new List<CustomerRequirement>();
                foreach (CustomerRequirementDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.CustomerRequirement obj = new Rebound.GlobalTrader.BLL.CustomerRequirement();
                    obj.CustomerRequirementId = objDetails.CustomerRequirementId;
                    obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.FullPart = objDetails.FullPart;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.DateCode = objDetails.DateCode;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.ReceivedDate = objDetails.ReceivedDate;
                    obj.Salesman = objDetails.Salesman;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.Notes = objDetails.Notes;
                    obj.Instructions = objDetails.Instructions;
                    obj.Shortage = objDetails.Shortage;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.Alternate = objDetails.Alternate;
                    obj.OriginalCustomerRequirementNo = objDetails.OriginalCustomerRequirementNo;
                    obj.ReasonNo = objDetails.ReasonNo;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.Closed = objDetails.Closed;
                    obj.ROHS = objDetails.ROHS;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.UsageNo = objDetails.UsageNo;
                    obj.DisplayStatus = objDetails.DisplayStatus;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.CompanyOnStop = objDetails.CompanyOnStop;
                    obj.ContactName = objDetails.ContactName;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.UsageName = objDetails.UsageName;
                    obj.CustomerRequirementValue = objDetails.CustomerRequirementValue;
                    obj.ClosedReason = objDetails.ClosedReason;
                    obj.PartWatch = objDetails.PartWatch;
                    obj.BOM = objDetails.BOM;
                    obj.BOMName = objDetails.BOMName;
                    obj.DivisionName = objDetails.DivisionName;
                    obj.BOMHeader = objDetails.BOMHeader;
                    obj.BOMNo = objDetails.BOMNo == null ? 0 : (int)objDetails.BOMNo;
                    obj.RequestToPOHubBy = objDetails.RequestToPOHubBy;
                    obj.FactorySealed = objDetails.FactorySealed;
                    obj.MSL = objDetails.MSL;
                    obj.PQA = objDetails.PQA;
                    obj.Obsolete = objDetails.Obsolete;
                    obj.LastTimeBuy = objDetails.LastTimeBuy;
                    obj.RefirbsAcceptable = objDetails.RefirbsAcceptable;
                    obj.TestingRequired = objDetails.TestingRequired;
                    obj.TargetSellPrice = objDetails.TargetSellPrice;
                    obj.CompetitorBestOffer = objDetails.CompetitorBestOffer;
                    obj.CustomerDecisionDate = objDetails.CustomerDecisionDate;
                    obj.RFQClosingDate = objDetails.RFQClosingDate;
                    obj.QuoteValidityRequired = objDetails.QuoteValidityRequired;
                    obj.Type = objDetails.Type;
                    obj.OrderToPlace = objDetails.OrderToPlace;
                    obj.RequirementforTraceability = objDetails.RequirementforTraceability;
                    
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        // [001] code end

		/// GetListOpenForCompany
		/// Calls [usp_selectAll_CustomerRequirement_open_for_Company]
		/// </summary>
		public static List<CustomerRequirement> GetListOpenForCompany(System.Int32? companyId) {
			List<CustomerRequirementDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.GetListOpenForCompany(companyId);
			if (lstDetails == null) {
				return new List<CustomerRequirement>();
			} else {
				List<CustomerRequirement> lst = new List<CustomerRequirement>();
				foreach (CustomerRequirementDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CustomerRequirement obj = new Rebound.GlobalTrader.BLL.CustomerRequirement();
					obj.CustomerRequirementId = objDetails.CustomerRequirementId;
					obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
					obj.ClientNo = objDetails.ClientNo;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.DateCode = objDetails.DateCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.Quantity = objDetails.Quantity;
					obj.Price = objDetails.Price;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.ReceivedDate = objDetails.ReceivedDate;
					obj.Salesman = objDetails.Salesman;
					obj.DatePromised = objDetails.DatePromised;
					obj.Notes = objDetails.Notes;
					obj.Instructions = objDetails.Instructions;
					obj.Shortage = objDetails.Shortage;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.ContactNo = objDetails.ContactNo;
					obj.Alternate = objDetails.Alternate;
					obj.OriginalCustomerRequirementNo = objDetails.OriginalCustomerRequirementNo;
					obj.ReasonNo = objDetails.ReasonNo;
					obj.ProductNo = objDetails.ProductNo;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.Closed = objDetails.Closed;
					obj.ROHS = objDetails.ROHS;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.UsageNo = objDetails.UsageNo;
					obj.DisplayStatus = objDetails.DisplayStatus;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.TeamNo = objDetails.TeamNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.CompanyOnStop = objDetails.CompanyOnStop;
					obj.ContactName = objDetails.ContactName;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.UsageName = objDetails.UsageName;
					obj.CustomerRequirementValue = objDetails.CustomerRequirementValue;
					obj.ClosedReason = objDetails.ClosedReason;
					obj.PartWatch = objDetails.PartWatch;
					obj.BOM = objDetails.BOM;
					obj.BOMName = objDetails.BOMName;
					obj.DivisionName = objDetails.DivisionName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListOpenForLogin
		/// Calls [usp_selectAll_CustomerRequirement_open_for_Login]
		/// </summary>
		public static List<CustomerRequirement> GetListOpenForLogin(System.Int32? loginId, System.Int32? topToSelect) {
			List<CustomerRequirementDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.GetListOpenForLogin(loginId, topToSelect);
			if (lstDetails == null) {
				return new List<CustomerRequirement>();
			} else {
				List<CustomerRequirement> lst = new List<CustomerRequirement>();
				foreach (CustomerRequirementDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CustomerRequirement obj = new Rebound.GlobalTrader.BLL.CustomerRequirement();
					obj.Status = objDetails.Status;
					obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
					obj.ReceivedDate = objDetails.ReceivedDate;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.Quantity = objDetails.Quantity;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.CreditLimit = objDetails.CreditLimit;
					obj.Balance = objDetails.Balance;
					obj.Salesman = objDetails.Salesman;
					obj.DatePromised = objDetails.DatePromised;
					obj.DaysOverdue = objDetails.DaysOverdue;
					obj.CustomerRequirementId = objDetails.CustomerRequirementId;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListOverdueForLogin
		/// Calls [usp_selectAll_CustomerRequirement_overdue_for_Login]
		/// </summary>
		public static List<CustomerRequirement> GetListOverdueForLogin(System.Int32? loginId, System.Int32? topToSelect) {
			List<CustomerRequirementDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.GetListOverdueForLogin(loginId, topToSelect);
			if (lstDetails == null) {
				return new List<CustomerRequirement>();
			} else {
				List<CustomerRequirement> lst = new List<CustomerRequirement>();
				foreach (CustomerRequirementDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CustomerRequirement obj = new Rebound.GlobalTrader.BLL.CustomerRequirement();
					obj.Status = objDetails.Status;
					obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
					obj.ReceivedDate = objDetails.ReceivedDate;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.Quantity = objDetails.Quantity;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.CreditLimit = objDetails.CreditLimit;
					obj.Balance = objDetails.Balance;
					obj.Salesman = objDetails.Salesman;
					obj.DatePromised = objDetails.DatePromised;
					obj.DaysOverdue = objDetails.DaysOverdue;
					obj.CustomerRequirementId = objDetails.CustomerRequirementId;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Source
		/// Calls [usp_source_CustomerRequirement]
		/// </summary>
        public static List<CustomerRequirement> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? maxDate, out DateTime? outDate, System.Boolean? blnReferesh, bool IsServerLocal)
        {
            DateTime? StartDate = null;
            DateTime? EndDate = null;
            if (index == 2 && maxDate.HasValue)
            {
                StartDate = (!blnReferesh.Value) ? maxDate.Value.AddMonths(-6) : maxDate.Value.AddMonths(-12);
                EndDate = maxDate.Value;
            }
            else if (index == 3 && maxDate.HasValue)
            {
                StartDate = DateTime.Parse("1900-01-01 00:00:00.000");
                EndDate = maxDate.Value;
            }
            List<CustomerRequirementDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.Source(clientId, partSearch, index, StartDate, EndDate, out outDate, IsServerLocal);
			if (lstDetails == null) {
				return new List<CustomerRequirement>();
			} else {
				List<CustomerRequirement> lst = new List<CustomerRequirement>();
				foreach (CustomerRequirementDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CustomerRequirement obj = new Rebound.GlobalTrader.BLL.CustomerRequirement();
					obj.ClientNo = objDetails.ClientNo;
					obj.ClientName = objDetails.ClientName;
					obj.CustomerRequirementId = objDetails.CustomerRequirementId;
					obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
					obj.Part = objDetails.Part;
					obj.Quantity = objDetails.Quantity;
					obj.ROHS = objDetails.ROHS;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.ReceivedDate = objDetails.ReceivedDate;
					obj.Price = objDetails.Price;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.ProductName = objDetails.ProductName;
					obj.PackageName = objDetails.PackageName;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.DateCode = objDetails.DateCode;
                    obj.Salesman = objDetails.Salesman;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.ClientCode = objDetails.ClientCode;  
                    //[002] start
                    obj.BOMNo = objDetails.BOMNo??0;
                    obj.BOMName = objDetails.BOMName;  
                    //[002] end
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
        public static Int32 InsertExpedite(System.Int32? HUBRFQId, System.String expediteNotes, System.Int32? UpdatedBy, string ReqIds,System.Int32? emailSendTo)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.InsertExpedite(HUBRFQId, expediteNotes, UpdatedBy, ReqIds, emailSendTo);
        }
        public static Int32 InsertHUBRFQExpedite(System.Int32? HUBRFQId, System.String expediteNotes, System.Int32? UpdatedBy, System.Int32? emailSendTo)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.InsertHUBRFQExpedite(HUBRFQId, expediteNotes, UpdatedBy, emailSendTo);
        }

		/// <summary>
		/// Update
		/// Calls [usp_update_CustomerRequirement]
		/// </summary>
        public static bool Update(System.Int32? customerRequirementId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? receivedDate, System.Int32? salesman, System.DateTime? datePromised, System.String notes, System.String instructions, System.Boolean? shortage, System.Int32? companyNo, System.Int32? contactNo, System.Int32? usageNo, System.Boolean? alternate, System.Int32? originalCustomerRequirementNo, System.Int32? reasonNo, System.Int32? productNo, System.String customerPart, System.Boolean? closed, System.Byte? rohs, System.Int32? updatedBy, System.Boolean? partWatch, System.Boolean? bom, System.String bomName, System.Int32? BOMNo, System.Boolean? FactorySealed, System.String MSL, System.Boolean? PQA, System.Boolean? ObsoleteChk, System.Boolean? LastTimeBuyChk, System.Boolean? RefirbsAcceptableChk, System.Boolean? TestingRequiredChk, System.Double? TargetSellPrice, System.Double? CompetitorBestOffer, System.DateTime? CustomerDecisionDate, System.DateTime? RFQClosingDate, System.Int32? QuoteValidityRequired, System.Int32? Type, System.Boolean? OrderToPlace, System.Int32? RequirementforTraceability, System.String EAU, System.Boolean? AlternativesAccepted, System.Boolean? RepeatBusiness)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.Update(customerRequirementId, part, manufacturerNo, dateCode, packageNo, quantity, price, currencyNo, receivedDate, salesman, datePromised, notes, instructions, shortage, companyNo, contactNo, usageNo, alternate, originalCustomerRequirementNo, reasonNo, productNo, customerPart, closed, rohs, updatedBy, partWatch, bom, bomName, BOMNo, FactorySealed, MSL, PQA, ObsoleteChk, LastTimeBuyChk, RefirbsAcceptableChk, TestingRequiredChk, TargetSellPrice, CompetitorBestOffer, CustomerDecisionDate, RFQClosingDate, QuoteValidityRequired, Type, OrderToPlace, RequirementforTraceability,EAU,AlternativesAccepted,RepeatBusiness);
		}

        /// <summary>
        /// Update Bomid in Customer Requirements
        /// Calls [usp_update_CustRequirementByBomID]
        /// </summary>
        public static bool Update(System.Int32? bomID, System.Int32? updatedBy, System.Int32? clientNo, System.String ReqsId, System.Int32? bomStatus)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.Update(bomID, updatedBy, clientNo, ReqsId, bomStatus);
        }
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_CustomerRequirement]
		/// </summary>
		public bool Update() {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.Update(CustomerRequirementId, Part, ManufacturerNo, DateCode, PackageNo, Quantity, Price, CurrencyNo, ReceivedDate, Salesman, DatePromised, Notes, Instructions, Shortage, CompanyNo, ContactNo, UsageNo, Alternate, OriginalCustomerRequirementNo, ReasonNo, ProductNo, CustomerPart, Closed, ROHS, UpdatedBy, PartWatch, BOM, BOMName, BOMNo, FactorySealed, MSL, PQA, Obsolete, LastTimeBuy, RefirbsAcceptable, TestingRequired, TargetSellPrice, CompetitorBestOffer, CustomerDecisionDate, RFQClosingDate, QuoteValidityRequired, Type, OrderToPlace, RequirementforTraceability,EAU,AlternativesAccepted,RepeatBusiness);
		}
		/// <summary>
		/// UpdateClose
		/// Calls [usp_update_CustomerRequirement_Close]
		/// </summary>
		public static bool UpdateClose(System.Int32? customerRequirementId, System.Boolean? includeAllRelatedAlternates, System.Int32? reasonNo, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.UpdateClose(customerRequirementId, includeAllRelatedAlternates, reasonNo, updatedBy);
		}

        private static CustomerRequirement PopulateFromDBDetailsObject(CustomerRequirementDetails obj) {
            CustomerRequirement objNew = new CustomerRequirement();
			objNew.CustomerRequirementId = obj.CustomerRequirementId;
			objNew.CustomerRequirementNumber = obj.CustomerRequirementNumber;
			objNew.ClientNo = obj.ClientNo;
			objNew.FullPart = obj.FullPart;
			objNew.Part = obj.Part;
			objNew.ManufacturerNo = obj.ManufacturerNo;
			objNew.DateCode = obj.DateCode;
			objNew.PackageNo = obj.PackageNo;
			objNew.Quantity = obj.Quantity;
			objNew.Price = obj.Price;
			objNew.CurrencyNo = obj.CurrencyNo;
			objNew.ReceivedDate = obj.ReceivedDate;
			objNew.Salesman = obj.Salesman;
			objNew.DatePromised = obj.DatePromised;
			objNew.Notes = obj.Notes;
			objNew.Instructions = obj.Instructions;
			objNew.Shortage = obj.Shortage;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.ContactNo = obj.ContactNo;
			objNew.Alternate = obj.Alternate;
			objNew.OriginalCustomerRequirementNo = obj.OriginalCustomerRequirementNo;
			objNew.ReasonNo = obj.ReasonNo;
			objNew.ProductNo = obj.ProductNo;
			objNew.CustomerPart = obj.CustomerPart;
			objNew.Closed = obj.Closed;
			objNew.ROHS = obj.ROHS;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.UsageNo = obj.UsageNo;
			objNew.FullCustomerPart = obj.FullCustomerPart;
			objNew.BOM = obj.BOM;
			objNew.BOMName = obj.BOMName;
			objNew.PartWatch = obj.PartWatch;
			objNew.SalesmanName = obj.SalesmanName;
			objNew.ManufacturerCode = obj.ManufacturerCode;
			objNew.CompanyName = obj.CompanyName;
			objNew.ContactName = obj.ContactName;
			objNew.RowNum = obj.RowNum;
			objNew.RowCnt = obj.RowCnt;
			objNew.CurrencyCode = obj.CurrencyCode;
			objNew.DisplayStatus = obj.DisplayStatus;
			objNew.DivisionNo = obj.DivisionNo;
			objNew.TeamNo = obj.TeamNo;
			objNew.CompanyOnStop = obj.CompanyOnStop;
			objNew.CurrencyDescription = obj.CurrencyDescription;
			objNew.ProductName = obj.ProductName;
			objNew.ProductDescription = obj.ProductDescription;
			objNew.ManufacturerName = obj.ManufacturerName;
			objNew.PackageName = obj.PackageName;
			objNew.PackageDescription = obj.PackageDescription;
			objNew.UsageName = obj.UsageName;
			objNew.CustomerRequirementValue = obj.CustomerRequirementValue;
			objNew.ClosedReason = obj.ClosedReason;
			objNew.DivisionName = obj.DivisionName;
			objNew.Status = obj.Status;
			objNew.CreditLimit = obj.CreditLimit;
			objNew.Balance = obj.Balance;
			objNew.DaysOverdue = obj.DaysOverdue;
			objNew.ClientName = obj.ClientName;
            return objNew;
        }

        public static List<CustomerRequirement> DataListNuggetPrint(System.Int32? clientId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String cmSearch, System.Int32? salesmanNo, System.Int32? companyNo, System.DateTime? receivedDateFrom, System.DateTime? receivedDateTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo, System.Int32? contactNo)
        {
            List<CustomerRequirementDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.DataListNuggetPrint(clientId, loginId, orderBy, sortDir, pageIndex, pageSize, cmSearch, salesmanNo, companyNo, receivedDateFrom, receivedDateTo, datePromisedFrom, datePromisedTo, contactNo);
            if (lstDetails == null)
            {
                return new List<CustomerRequirement>();
            }
            else
            {
                List<CustomerRequirement> lst = new List<CustomerRequirement>();
                foreach (CustomerRequirementDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.CustomerRequirement obj = new Rebound.GlobalTrader.BLL.CustomerRequirement();
                    obj.CustomerRequirementId = objDetails.CustomerRequirementId;
                    obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
                    obj.Salesman = objDetails.Salesman;
                    obj.Part = objDetails.Part;
                    obj.ROHS = objDetails.ROHS;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.Quantity = objDetails.Quantity;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.ReceivedDate = objDetails.ReceivedDate;
                    obj.DatePromised = objDetails.DatePromised;
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
        /// usp_Print_CustomerRequirement_Enquiry_Form
        /// </summary>
        /// <param name="xmlReqNo"></param>
        /// <returns></returns>
        public static List<CustomerRequirement> GetForPrint(System.String xmlReqNo)
        {
            List<CustomerRequirementDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.GetForPrint(xmlReqNo);
            if (lstDetails == null)
            {
                return new List<CustomerRequirement>();
            }
            else
            {
                List<CustomerRequirement> lst = new List<CustomerRequirement>();
                foreach (CustomerRequirementDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.CustomerRequirement obj = new Rebound.GlobalTrader.BLL.CustomerRequirement();
                    obj.CustomerRequirementId = objDetails.CustomerRequirementId;
                    obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.Quantity = objDetails.Quantity;
                    obj.ReceivedDate = objDetails.ReceivedDate;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.ContactName = objDetails.ContactName;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.PackageName = objDetails.PackageName;
                    obj.ProductName = objDetails.ProductName;
                    obj.DateCode = objDetails.DateCode;
                    obj.Price = objDetails.Price;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.Alternate = objDetails.Alternate;
                    obj.Part = objDetails.Part;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.CustomerPart = objDetails.CustomerPart;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// ItemSearch
        /// Calls [usp_itemsearch_CustomerReqsWithBOM]
        /// </summary>
        public static List<CustomerRequirement> ItemSearchWithBOM(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId,  System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Boolean? includeClosed, System.Int32? customerRequirementNoLo, System.Int32? customerRequirementNoHi, System.DateTime? receivedDateFrom, System.DateTime? receivedDateTo,System.Int32? client,System.String bomName)
        {
            List<CustomerRequirementDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.ItemSearchWithBOM(clientId,teamId,divisionId,loginId, orderBy, sortDir, pageIndex, pageSize, partSearch, cmSearch, includeClosed, customerRequirementNoLo, customerRequirementNoHi, receivedDateFrom, receivedDateTo, client, bomName);
            if (lstDetails == null)
            {
                return new List<CustomerRequirement>();
            }
            else
            {
                List<CustomerRequirement> lst = new List<CustomerRequirement>();
                foreach (CustomerRequirementDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.CustomerRequirement obj = new Rebound.GlobalTrader.BLL.CustomerRequirement();
                    obj.CustomerRequirementId = objDetails.CustomerRequirementId;
                    obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.Part = objDetails.Part;
                    obj.ROHS = objDetails.ROHS;
                    obj.ReceivedDate = objDetails.ReceivedDate;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.BOMHeader = objDetails.BOMHeader;
                    obj.PHPrice = objDetails.PHPrice;
                    obj.PHCurrencyCode = objDetails.PHCurrencyCode;
                    obj.AS9120 = objDetails.AS9120;
                    obj.IsGlobalCurrencySame = objDetails.IsGlobalCurrencySame;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// ItemSearch
        /// Calls [usp_itemsearch_CustRequirementWithoutBOM]
        /// </summary>
        public static List<CustomerRequirement> ItemSearchWithoutBOM(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Boolean? includeClosed, System.Int32? customerRequirementNoLo, System.Int32? customerRequirementNoHi, System.DateTime? receivedDateFrom, System.DateTime? receivedDateTo, System.Int32? BOM, System.String BOMName)
        {
            List<CustomerRequirementDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.ItemSearchWithoutBOM(clientId, orderBy, sortDir, pageIndex, pageSize, partSearch, cmSearch, includeClosed, customerRequirementNoLo, customerRequirementNoHi, receivedDateFrom, receivedDateTo, BOM, BOMName);
            if (lstDetails == null)
            {
                return new List<CustomerRequirement>();
            }
            else
            {
                List<CustomerRequirement> lst = new List<CustomerRequirement>();
                foreach (CustomerRequirementDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.CustomerRequirement obj = new Rebound.GlobalTrader.BLL.CustomerRequirement();
                    obj.CustomerRequirementId = objDetails.CustomerRequirementId;
                    obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.Part = objDetails.Part;
                    obj.ROHS = objDetails.ROHS;
                    obj.ReceivedDate = objDetails.ReceivedDate;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.BOMHeader = objDetails.BOMHeader;
                    obj.BOMName = objDetails.BOMName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }


        /// <summary>
        /// 
        /// [001] code start
        /// <summary>
        /// GetListForCustomerRequirement
        /// Calls [usp_selectAll_CustomerRequirement_for_BOM]
        /// </summary>
        public static List<CustomerRequirement> GetBOMListForCustomerRequirement(System.Int32? BOMNo, System.Int32? clientID)
        {
            List<CustomerRequirementDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.GetBOMListForCustomerRequirement(BOMNo, clientID);
            if (lstDetails == null)
            {
                return new List<CustomerRequirement>();
            }
            else
            {
                List<CustomerRequirement> lst = new List<CustomerRequirement>();
                foreach (CustomerRequirementDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.CustomerRequirement obj = new Rebound.GlobalTrader.BLL.CustomerRequirement();
                    obj.CustomerRequirementId = objDetails.CustomerRequirementId;
                    obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.FullPart = objDetails.FullPart;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.DateCode = objDetails.DateCode;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.ReceivedDate = objDetails.ReceivedDate;
                    obj.Salesman = objDetails.Salesman;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.Notes = objDetails.Notes;
                    obj.Instructions = objDetails.Instructions;
                    obj.Shortage = objDetails.Shortage;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.Alternate = objDetails.Alternate;
                    obj.OriginalCustomerRequirementNo = objDetails.OriginalCustomerRequirementNo;
                    obj.ReasonNo = objDetails.ReasonNo;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.Closed = objDetails.Closed;
                    obj.ROHS = objDetails.ROHS;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.UsageNo = objDetails.UsageNo;
                    obj.DisplayStatus = objDetails.DisplayStatus;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.CompanyOnStop = objDetails.CompanyOnStop;
                    obj.ContactName = objDetails.ContactName;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.UsageName = objDetails.UsageName;
                    obj.CustomerRequirementValue = objDetails.CustomerRequirementValue;
                    obj.ClosedReason = objDetails.ClosedReason;
                    obj.PartWatch = objDetails.PartWatch;
                    obj.BOM = objDetails.BOM;
                    obj.BOMName = objDetails.BOMName;
                    obj.DivisionName = objDetails.DivisionName;
                    obj.BOMHeader = objDetails.BOMHeader;
                    obj.BOMNo = (int)objDetails.BOMNo;
                    obj.POHubReleaseBy = objDetails.POHubReleaseBy;
                    obj.SourcingResultId = objDetails.SourcingResultId;
                    obj.RequestToPOHubBy = objDetails.RequestToPOHubBy;
                    obj.BOMCode = objDetails.BOMCode;
                    obj.BOMFullName = objDetails.BOMFullName;
                    obj.BOMCurrencyCode = objDetails.BOMCurrencyCode;
                    obj.ConvertedTargetValue = objDetails.ConvertedTargetValue;

                    obj.PurchaseQuoteId = objDetails.PurchaseQuoteId;
                    obj.PurchaseQuoteNumber = objDetails.PurchaseQuoteNumber;
                    obj.ClientName = objDetails.ClientName;
                    obj.POHubCompany = objDetails.POHubCompany;
                    obj.FactorySealed = objDetails.FactorySealed;
                    obj.MSL = objDetails.MSL;
                    obj.AllSorcingHasDelDate = objDetails.AllSorcingHasDelDate;
                    obj.AllSorcingHasProduct = objDetails.AllSorcingHasProduct;
                    obj.SourcingResult = objDetails.SourcingResult;
                    obj.BOMStatus = objDetails.BOMStatus;
                    obj.HasClientSourcingResult = objDetails.HasClientSourcingResult;
                    obj.HasHubSourcingResult = objDetails.HasHubSourcingResult;
                    obj.IsNoBid = objDetails.IsNoBid;
                    obj.ExpeditDate = objDetails.ExpeditDate;
                    obj.UpdateByPH = objDetails.UpdateByPH;

                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }


        /// <summary>
        /// 
        /// [001] code start
        /// <summary>
        /// This use for Mail Template of HURFQ
        /// Calls [[usp_selectCusReqForMail]]
        /// </summary>
        public static List<CustomerRequirement> GetHUBRFQForMail(System.Int32? BOMNo, System.Int32? clientID)
        {
            List<CustomerRequirementDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.GetHUBRFQForMail(BOMNo, clientID);
            if (lstDetails == null)
            {
                return new List<CustomerRequirement>();
            }
            else
            {
                List<CustomerRequirement> lst = new List<CustomerRequirement>();
                foreach (CustomerRequirementDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.CustomerRequirement obj = new Rebound.GlobalTrader.BLL.CustomerRequirement();

                    obj.CustomerRequirementId = objDetails.CustomerRequirementId;
                    obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
                    obj.PackageName = objDetails.PackageName;
                    obj.ProductName = objDetails.ProductName;
                    obj.Quantity = objDetails.Quantity;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.Part = objDetails.Part;
                    obj.DateCode = objDetails.DateCode;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.ClientName = objDetails.ClientName;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.ConvertedTargetValue = objDetails.ConvertedTargetValue;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.BOMCurrencyCode = objDetails.BOMCurrencyCode;
                    obj.Instructions = objDetails.Instructions;
                    obj.MSL = objDetails.MSL;
                    obj.FactorySealed = objDetails.FactorySealed;
                    obj.ReqTypeText = objDetails.ReqTypeText;
                    obj.ReqForTraceabilityText = objDetails.ReqForTraceabilityText;
                    obj.RepeatBusiness = objDetails.RepeatBusiness;
                    obj.AlternativesAccepted = objDetails.AlternativesAccepted;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

            
            /// <summary>
            // [001] code end

        /// <summary>
        /// Report103
        /// Calls [usp_report_Report_103]
        /// </summary>
        public static List<List<object>> GetBOMListForCRList(System.Int32? BOMNo, System.Int32? clientID, System.Int32? CompanyNo)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.GetBOMListForCRList(BOMNo, clientID, CompanyNo);
        }

    /// <summary>
        /// Release 
        /// Calls [usp_update_CustomerRequirement_Release]
        /// </summary>
        public static bool ReleaseRequirement(System.Int32? customerRequirementId, System.Int32? updatedBy,System.Int32? bomID)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.ReleaseRequirement(customerRequirementId, updatedBy,bomID);
        }
        /// <summary>
        /// BOM Release 
        /// Calls [usp_update_BOM_Release]
        /// </summary>
        public static bool BOMReleaseRequirement(System.Int32? bomID, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.BOMReleaseRequirement(bomID, updatedBy);
        }
        ///Recall NoBid 
        /// Calls [usp_update_CustomerRequirement_RecallNoBid]
        /// </summary>
        public static bool RecallNoBidRequirement(System.Int32? customerRequirementId, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.RecallNoBidRequirement(customerRequirementId, updatedBy);
        }
        /// NoBid 
        /// Calls [usp_update_CustomerRequirement_NoBid]
        /// </summary>
        public static bool NoBidRequirement(System.Int32? customerRequirementId, System.Int32? updatedBy, System.Int32? bomID, string Notes)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.NoBidRequirement(customerRequirementId, updatedBy, bomID,Notes);
        }
        /// <summary>
        /// BOM NoBid 
        /// Calls [usp_update_BOM_NoBid]
        /// </summary>
        public static bool BOMNoBidRequirement(System.Int32? bomID, System.Int32? updatedBy, string Notes)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.BOMNoBidRequirement(bomID, updatedBy, Notes);
        }
        /// <summary>
        /// delete 
        /// Calls [usp_delete_CustomerRequirement_Bom]
        /// </summary>
        public static bool DeleteBomItem(int? bomId, int? requirementId, System.Int32? LoginID,System.Int32? clientId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.DeleteBomItem(bomId, requirementId,LoginID,clientId);
        }
        /// <summary>
        /// delete 
        /// Calls [usp_UnRelease_CustomerRequirement_Bom]
        /// </summary>
        public static bool UnReleaseBomItem(int? bomId, int? requirementId) 
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.UnReleaseBomItem(bomId, requirementId);
        }

        /// DataListNugget for HURFQ
        /// Calls [usp_datalistnugget_CustomerRequirementForHUBRFQ]
        /// add start date and end date  for searching by umendra
        /// </summary>
        public static List<CustomerRequirement> DataListNuggetHUBRFQ(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String BOMCode, System.String bomName, System.Boolean? isPOHub, System.Int32? selectedClientNo, int? bomStatus, int? isAssignToMe, int? assignedUser, System.String Manufacturer, System.String Part, System.Int32? intDivision, System.DateTime? startdate, System.DateTime? enddate, System.Int32? salesPerson)
        {
            List<CustomerRequirementDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.DataListNuggetHUBRFQ(clientId, teamId, divisionId, loginId, orderBy, sortDir, pageIndex, pageSize, BOMCode, bomName, isPOHub, selectedClientNo, bomStatus, isAssignToMe, assignedUser, Manufacturer, Part, intDivision, startdate, enddate, salesPerson);
            if (lstDetails == null)
            {
                return new List<CustomerRequirement>();
            }
            else
            {
                List<CustomerRequirement> lst = new List<CustomerRequirement>();
                foreach (CustomerRequirementDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.CustomerRequirement obj = new Rebound.GlobalTrader.BLL.CustomerRequirement();
                    obj.CustomerRequirementId = objDetails.CustomerRequirementId;
                    obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
                    obj.Salesman = objDetails.Salesman;
                    obj.Part = objDetails.Part;
                    obj.ROHS = objDetails.ROHS;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.Quantity = objDetails.Quantity;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.ReceivedDate = objDetails.ReceivedDate;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.BOMCode = objDetails.BOMCode;
                    obj.BOMNo = (int)objDetails.BOMNo;
                    obj.BOMName = objDetails.BOMName;
                    obj.BOMStatus = objDetails.BOMStatus;
                    obj.Price = objDetails.Price;
                    obj.PHPrice = objDetails.PHPrice;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.DLUP = objDetails.DLUP;
                    obj.DivisionName = objDetails.DivisionName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }


        /// <summary>
        /// 
        /// [001] code start
        /// <summary>
        /// GetListForCustomerRequirement
        /// Calls [usp_selectAll_CustomerRequirement_for_BOM]
        /// </summary>
        public static List<CustomerRequirement> GetHUBRFQReqNos(String ReqIds, System.Int32? clientID)
        {
            List<CustomerRequirementDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRequirement.GetHUBRFQReqNos(ReqIds, clientID);
            if (lstDetails == null)
            {
                return new List<CustomerRequirement>();
            }
            else
            {
                List<CustomerRequirement> lst = new List<CustomerRequirement>();
                foreach (CustomerRequirementDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.CustomerRequirement obj = new Rebound.GlobalTrader.BLL.CustomerRequirement();
                    obj.CustomerRequirementId = objDetails.CustomerRequirementId;
                    obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;                                     
                                       obj.BOMHeader = objDetails.BOMHeader;
                                     

                                       obj.RequestToPOHubBy = objDetails.RequestToPOHubBy;
                                       obj.BOMFullName = objDetails.BOMFullName;
                                       obj.BOMCode = objDetails.BOMCode;

                                       obj.FullPart = objDetails.FullPart;
                                       obj.Part = objDetails.Part;
                                       obj.ManufacturerNo = objDetails.ManufacturerNo;




                    
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
