//Marker     changed by      date          Remarks
//[001]      Vinay           24/08/2012    ESMS Ref:## - Disable create so button if quantity is 0 
//[002]      Vinay           21/01/2014   CR:- Add AS9120 Requirement in GT application
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
		public partial class Quote : BizObject {
		
		#region Properties

		protected static DAL.QuoteElement Settings {
			get { return Globals.Settings.Quotes; }
		}

		/// <summary>
		/// QuoteId
		/// </summary>
		public System.Int32 QuoteId { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// QuoteNumber
		/// </summary>
		public System.Int32 QuoteNumber { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// Instructions
		/// </summary>
		public System.String Instructions { get; set; }		
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32 CompanyNo { get; set; }		
		/// <summary>
		/// ContactNo
		/// </summary>
		public System.Int32 ContactNo { get; set; }		
		/// <summary>
		/// DateQuoted
		/// </summary>
		public System.DateTime DateQuoted { get; set; }		
		/// <summary>
		/// CurrencyNo
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }		
		/// <summary>
		/// Salesman
		/// </summary>
		public System.Int32 Salesman { get; set; }		
		/// <summary>
		/// TermsNo
		/// </summary>
		public System.Int32? TermsNo { get; set; }		
		/// <summary>
		/// DivisionNo
		/// </summary>
		public System.Int32 DivisionNo { get; set; }		
		/// <summary>
		/// Freight
		/// </summary>
		public System.Double? Freight { get; set; }		
		/// <summary>
		/// Closed
		/// </summary>
		public System.Boolean? Closed { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// IncotermNo
		/// </summary>
		public System.Int32? IncotermNo { get; set; }		
		/// <summary>
		/// CompanyName
		/// </summary>
		public System.String CompanyName { get; set; }		
		/// <summary>
		/// CompanyOnStop
		/// </summary>
		public System.Boolean? CompanyOnStop { get; set; }		
		/// <summary>
		/// CompanySOApproved
		/// </summary>
		public System.Boolean? CompanySOApproved { get; set; }		
		/// <summary>
		/// ContactName
		/// </summary>
		public System.String ContactName { get; set; }		
		/// <summary>
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }		
		/// <summary>
		/// CurrencyDescription
		/// </summary>
		public System.String CurrencyDescription { get; set; }		
		/// <summary>
		/// SalesmanName
		/// </summary>
		public System.String SalesmanName { get; set; }		
		/// <summary>
		/// DivisionName
		/// </summary>
		public System.String DivisionName { get; set; }		
		/// <summary>
		/// QuoteValue
		/// </summary>
		public System.Double? QuoteValue { get; set; }		
		/// <summary>
		/// TermsName
		/// </summary>
		public System.String TermsName { get; set; }		
		/// <summary>
		/// OpenLines
		/// </summary>
		public System.Int32? OpenLines { get; set; }		
		/// <summary>
		/// IncotermName
		/// </summary>
		public System.String IncotermName { get; set; }		
		/// <summary>
		/// ContactEmail
		/// </summary>
		public System.String ContactEmail { get; set; }		
		/// <summary>
		/// CreditLimit
		/// </summary>
		public System.Double? CreditLimit { get; set; }		
		/// <summary>
		/// Balance
		/// </summary>
		public System.Double? Balance { get; set; }
        //[001] code start
        public System.Int32? TotalQuantityLines { get; set; }
        //[001] code end
        public System.Int32 TeamNo { get; set; }
        //[002] code start
        /// <summary>
        /// AS9120
        /// </summary>
        public System.Boolean? AS9120 { get; set; }
        //[002] code end

        public System.Int32 GlobalCurrencyNo { get; set; }
        /// <summary>
        /// IsCurrencyInSameFaimly
        /// </summary>
        public System.Boolean? IsCurrencyInSameFaimly { get; set; }
        public System.Boolean? IsImportant { get; set; }
        public System.Int32? QuoteStatus { get; set; }
        public System.String QuoteStatusName { get; set; }
		#endregion
		
		#region Methods
		
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_Quote_for_Client]
		/// </summary>
		public static Int32 CountForClient(System.Int32? clientId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Quote.CountForClient(clientId);
		}		/// <summary>
		/// CountForCompany
		/// Calls [usp_count_Quote_for_Company]
		/// </summary>
		public static Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeClosed) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Quote.CountForCompany(companyId, includeClosed);
		}		/// <summary>
		/// CountOpenForCompany
		/// Calls [usp_count_Quote_open_for_Company]
		/// </summary>
		public static Int32 CountOpenForCompany(System.Int32? companyId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Quote.CountOpenForCompany(companyId);
		}		/// <summary>
		/// Delete
		/// Calls [usp_delete_Quote]
		/// </summary>
		public static bool Delete(System.Int32? quoteId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Quote.Delete(quoteId);
		}
        //[002] code start
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Quote]
		/// </summary>
		public static Int32 Insert(System.Int32? clientNo, System.String notes, System.String instructions, System.Int32? companyNo, System.Int32? contactNo, System.DateTime? dateQuoted, System.Int32? currencyNo, System.Int32? salesman, System.Int32? termsNo, System.Int32? divisionNo, System.Double? freight, System.Boolean? closed, System.Int32? incotermNo, System.Int32? updatedBy,System.Boolean? As9120, System.Boolean? isImportant) {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Quote.Insert(clientNo, notes, instructions, companyNo, contactNo, dateQuoted, currencyNo, salesman, termsNo, divisionNo, freight, closed, incotermNo, updatedBy, As9120,isImportant);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Quote]
		/// </summary>
		public Int32 Insert() {
            return Rebound.GlobalTrader.DAL.SiteProvider.Quote.Insert(ClientNo, Notes, Instructions, CompanyNo, ContactNo, DateQuoted, CurrencyNo, Salesman, TermsNo, DivisionNo, Freight, Closed, IncotermNo, UpdatedBy, AS9120, IsImportant);
		}
        //[002] code end
		/// <summary>
		/// Get
		/// Calls [usp_select_Quote]
		/// </summary>
		public static Quote Get(System.Int32? quoteId) {
			Rebound.GlobalTrader.DAL.QuoteDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Quote.Get(quoteId);
			if (objDetails == null) {
				return null;
			} else {
				Quote obj = new Quote();
				obj.QuoteId = objDetails.QuoteId;
				obj.ClientNo = objDetails.ClientNo;
				obj.QuoteNumber = objDetails.QuoteNumber;
				obj.Notes = objDetails.Notes;
				obj.Instructions = objDetails.Instructions;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.ContactNo = objDetails.ContactNo;
				obj.DateQuoted = objDetails.DateQuoted;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.Salesman = objDetails.Salesman;
				obj.TermsNo = objDetails.TermsNo;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.Freight = objDetails.Freight;
				obj.Closed = objDetails.Closed;
				obj.IncotermNo = objDetails.IncotermNo;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.CompanyName = objDetails.CompanyName;
				obj.CompanyOnStop = objDetails.CompanyOnStop;
				obj.CompanySOApproved = objDetails.CompanySOApproved;
				obj.ContactName = objDetails.ContactName;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyDescription = objDetails.CurrencyDescription;
				obj.SalesmanName = objDetails.SalesmanName;
				obj.DivisionName = objDetails.DivisionName;
				obj.QuoteValue = objDetails.QuoteValue;
				obj.TermsName = objDetails.TermsName;
				obj.OpenLines = objDetails.OpenLines;
				obj.IncotermName = objDetails.IncotermName;
                //[001] code start
                obj.TotalQuantityLines = objDetails.TotalQuantityLines;
                //[001] code end
                //[002] code start
                obj.AS9120 = objDetails.AS9120;
                //[002] code end
                obj.GlobalCurrencyNo = objDetails.GlobalCurrencyNo;
                obj.IsCurrencyInSameFaimly = objDetails.IsCurrencyInSameFaimly;
                obj.IsImportant = objDetails.IsImportant;
                obj.QuoteStatus = objDetails.QuoteStatus;
                obj.QuoteStatusName = objDetails.QuoteStatusName;

				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetByNumber
		/// Calls [usp_select_Quote_by_Number]
		/// </summary>
		public static Quote GetByNumber(System.Int32? quoteNumber, System.Int32? clientNo) {
			Rebound.GlobalTrader.DAL.QuoteDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Quote.GetByNumber(quoteNumber, clientNo);
			if (objDetails == null) {
				return null;
			} else {
				Quote obj = new Quote();
				obj.QuoteId = objDetails.QuoteId;
				obj.ClientNo = objDetails.ClientNo;
				obj.QuoteNumber = objDetails.QuoteNumber;
				obj.Notes = objDetails.Notes;
				obj.Instructions = objDetails.Instructions;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.ContactNo = objDetails.ContactNo;
				obj.DateQuoted = objDetails.DateQuoted;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.Salesman = objDetails.Salesman;
				obj.TermsNo = objDetails.TermsNo;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.Freight = objDetails.Freight;
				obj.Closed = objDetails.Closed;
				obj.IncotermNo = objDetails.IncotermNo;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.CompanyName = objDetails.CompanyName;
				obj.CompanyOnStop = objDetails.CompanyOnStop;
				obj.CompanySOApproved = objDetails.CompanySOApproved;
				obj.ContactName = objDetails.ContactName;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyDescription = objDetails.CurrencyDescription;
				obj.SalesmanName = objDetails.SalesmanName;
				obj.DivisionName = objDetails.DivisionName;
				obj.QuoteValue = objDetails.QuoteValue;
				obj.TermsName = objDetails.TermsName;
				obj.OpenLines = objDetails.OpenLines;
				obj.IncotermName = objDetails.IncotermName;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_Quote_for_Page]
		/// </summary>
		public static Quote GetForPage(System.Int32? quoteId) {
			Rebound.GlobalTrader.DAL.QuoteDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Quote.GetForPage(quoteId);
			if (objDetails == null) {
				return null;
			} else {
				Quote obj = new Quote();
				obj.QuoteId = objDetails.QuoteId;
				obj.QuoteNumber = objDetails.QuoteNumber;
				obj.ClientNo = objDetails.ClientNo;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.Closed = objDetails.Closed;
                obj.TeamNo = objDetails.TeamNo;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.Salesman = objDetails.Salesman;
                obj.QuoteStatusName = objDetails.QuoteStatusName;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForPrint
		/// Calls [usp_select_Quote_for_Print]
		/// </summary>
		public static Quote GetForPrint(System.Int32? quoteId) {
			Rebound.GlobalTrader.DAL.QuoteDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Quote.GetForPrint(quoteId);
			if (objDetails == null) {
				return null;
			} else {
				Quote obj = new Quote();
				obj.QuoteId = objDetails.QuoteId;
				obj.ClientNo = objDetails.ClientNo;
				obj.QuoteNumber = objDetails.QuoteNumber;
				obj.Notes = objDetails.Notes;
				obj.Instructions = objDetails.Instructions;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.ContactNo = objDetails.ContactNo;
				obj.DateQuoted = objDetails.DateQuoted;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.Salesman = objDetails.Salesman;
				obj.TermsNo = objDetails.TermsNo;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.Freight = objDetails.Freight;
				obj.Closed = objDetails.Closed;
				obj.IncotermNo = objDetails.IncotermNo;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.CompanyName = objDetails.CompanyName;
				obj.CompanyOnStop = objDetails.CompanyOnStop;
				obj.CompanySOApproved = objDetails.CompanySOApproved;
				obj.ContactName = objDetails.ContactName;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyDescription = objDetails.CurrencyDescription;
				obj.SalesmanName = objDetails.SalesmanName;
				obj.DivisionName = objDetails.DivisionName;
				obj.QuoteValue = objDetails.QuoteValue;
				obj.TermsName = objDetails.TermsName;
				obj.OpenLines = objDetails.OpenLines;
				obj.IncotermName = objDetails.IncotermName;
				obj.ContactEmail = objDetails.ContactEmail;
                //[002] code start
                obj.AS9120 = objDetails.AS9120;
                //[002] code end
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetIDFromNumber
		/// Calls [usp_select_Quote_ID_from_Number]
		/// </summary>
        public static Quote GetIDFromNumber(System.Int32? quoteNumber, System.Int32? clientNo)
        {
            Rebound.GlobalTrader.DAL.QuoteDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Quote.GetIDFromNumber(quoteNumber, clientNo);
			if (objDetails == null) {
				return null;
			} else {
				Quote obj = new Quote();
				obj.QuoteId = objDetails.QuoteId;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetNextNumber
		/// Calls [usp_select_Quote_NextNumber]
		/// </summary>
		public static Quote GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy) {
			Rebound.GlobalTrader.DAL.QuoteDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Quote.GetNextNumber(clientNo, updatedBy);
			if (objDetails == null) {
				return null;
			} else {
				Quote obj = new Quote();
				obj.QuoteNumber = objDetails.QuoteNumber;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForCompany
		/// Calls [usp_selectAll_Quote_for_Company]
		/// </summary>
		public static List<Quote> GetListForCompany(System.Int32? companyId, System.Boolean? includeClosed) {
			List<QuoteDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Quote.GetListForCompany(companyId, includeClosed);
			if (lstDetails == null) {
				return new List<Quote>();
			} else {
				List<Quote> lst = new List<Quote>();
				foreach (QuoteDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Quote obj = new Rebound.GlobalTrader.BLL.Quote();
					obj.QuoteId = objDetails.QuoteId;
					obj.ClientNo = objDetails.ClientNo;
					obj.QuoteNumber = objDetails.QuoteNumber;
					obj.Notes = objDetails.Notes;
					obj.Instructions = objDetails.Instructions;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.ContactNo = objDetails.ContactNo;
					obj.DateQuoted = objDetails.DateQuoted;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.Salesman = objDetails.Salesman;
					obj.TermsNo = objDetails.TermsNo;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.Freight = objDetails.Freight;
					obj.Closed = objDetails.Closed;
					obj.IncotermNo = objDetails.IncotermNo;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.CompanyName = objDetails.CompanyName;
					obj.CompanyOnStop = objDetails.CompanyOnStop;
					obj.CompanySOApproved = objDetails.CompanySOApproved;
					obj.ContactName = objDetails.ContactName;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.DivisionName = objDetails.DivisionName;
					obj.QuoteValue = objDetails.QuoteValue;
					obj.TermsName = objDetails.TermsName;
					obj.OpenLines = objDetails.OpenLines;
					obj.IncotermName = objDetails.IncotermName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForSourcingResult
		/// Calls [usp_selectAll_Quote_for_SourcingResult]
		/// </summary>
		public static List<Quote> GetListForSourcingResult(System.Int32? sourcingResultNo) {
			List<QuoteDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Quote.GetListForSourcingResult(sourcingResultNo);
			if (lstDetails == null) {
				return new List<Quote>();
			} else {
				List<Quote> lst = new List<Quote>();
				foreach (QuoteDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Quote obj = new Rebound.GlobalTrader.BLL.Quote();
					obj.QuoteId = objDetails.QuoteId;
					obj.QuoteNumber = objDetails.QuoteNumber;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListOpenForCompany
		/// Calls [usp_selectAll_Quote_open_for_Company]
		/// </summary>
		public static List<Quote> GetListOpenForCompany(System.Int32? companyId) {
			List<QuoteDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Quote.GetListOpenForCompany(companyId);
			if (lstDetails == null) {
				return new List<Quote>();
			} else {
				List<Quote> lst = new List<Quote>();
				foreach (QuoteDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Quote obj = new Rebound.GlobalTrader.BLL.Quote();
					obj.QuoteId = objDetails.QuoteId;
					obj.ClientNo = objDetails.ClientNo;
					obj.QuoteNumber = objDetails.QuoteNumber;
					obj.Notes = objDetails.Notes;
					obj.Instructions = objDetails.Instructions;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.ContactNo = objDetails.ContactNo;
					obj.DateQuoted = objDetails.DateQuoted;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.Salesman = objDetails.Salesman;
					obj.TermsNo = objDetails.TermsNo;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.Freight = objDetails.Freight;
					obj.Closed = objDetails.Closed;
					obj.IncotermNo = objDetails.IncotermNo;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.CompanyName = objDetails.CompanyName;
					obj.CompanyOnStop = objDetails.CompanyOnStop;
					obj.CompanySOApproved = objDetails.CompanySOApproved;
					obj.ContactName = objDetails.ContactName;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.DivisionName = objDetails.DivisionName;
					obj.QuoteValue = objDetails.QuoteValue;
					obj.TermsName = objDetails.TermsName;
					obj.OpenLines = objDetails.OpenLines;
					obj.IncotermName = objDetails.IncotermName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListOpenForLogin
		/// Calls [usp_selectAll_Quote_open_for_Login]
		/// </summary>
		public static List<Quote> GetListOpenForLogin(System.Int32? loginId, System.Int32? topToSelect) {
			List<QuoteDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Quote.GetListOpenForLogin(loginId, topToSelect);
			if (lstDetails == null) {
				return new List<Quote>();
			} else {
				List<Quote> lst = new List<Quote>();
				foreach (QuoteDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Quote obj = new Rebound.GlobalTrader.BLL.Quote();
					obj.QuoteNumber = objDetails.QuoteNumber;
					obj.DateQuoted = objDetails.DateQuoted;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.CreditLimit = objDetails.CreditLimit;
					obj.Balance = objDetails.Balance;
					obj.Salesman = objDetails.Salesman;
					obj.QuoteId = objDetails.QuoteId;
                    obj.IsImportant = objDetails.IsImportant;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListRecentForLogin
		/// Calls [usp_selectAll_Quote_recent_for_Login]
		/// </summary>
		public static List<Quote> GetListRecentForLogin(System.Int32? loginId, System.Int32? topToSelect) {
			List<QuoteDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Quote.GetListRecentForLogin(loginId, topToSelect);
			if (lstDetails == null) {
				return new List<Quote>();
			} else {
				List<Quote> lst = new List<Quote>();
				foreach (QuoteDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Quote obj = new Rebound.GlobalTrader.BLL.Quote();
					obj.QuoteNumber = objDetails.QuoteNumber;
					obj.DateQuoted = objDetails.DateQuoted;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.CreditLimit = objDetails.CreditLimit;
					obj.Balance = objDetails.Balance;
					obj.Salesman = objDetails.Salesman;
					obj.QuoteId = objDetails.QuoteId;
                    obj.IsImportant = objDetails.IsImportant;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
        //[002] code start
		/// <summary>
		/// Update
		/// Calls [usp_update_Quote]
		/// </summary>
        public static bool Update(System.Int32? quoteId, System.String notes, System.String instructions, System.Boolean? closed, System.Int32? contactNo, System.DateTime? dateQuoted, System.Int32? currencyNo, System.Int32? salesman, System.Int32? divisionNo, System.Double? freight, System.Int32? termsNo, System.Int32? incotermNo, System.Int32? updatedBy, System.Boolean? As9120, System.Boolean? isImportant,System.Int32? quoteStatus)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Quote.Update(quoteId, notes, instructions, closed, contactNo, dateQuoted, currencyNo, salesman, divisionNo, freight, termsNo, incotermNo, updatedBy, As9120, isImportant, quoteStatus);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Quote]
		/// </summary>
		public bool Update() {
            return Rebound.GlobalTrader.DAL.SiteProvider.Quote.Update(QuoteId, Notes, Instructions, Closed, ContactNo, DateQuoted, CurrencyNo, Salesman, DivisionNo, Freight, TermsNo, IncotermNo, UpdatedBy, AS9120, IsImportant, QuoteStatus);
		}
        //[002] code end
		/// <summary>
		/// UpdateCheckClosed
		/// Calls [usp_update_Quote_CheckClosed]
		/// </summary>
		public static bool UpdateCheckClosed(System.Int32? quoteNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Quote.UpdateCheckClosed(quoteNo);
		}

        private static Quote PopulateFromDBDetailsObject(QuoteDetails obj) {
            Quote objNew = new Quote();
			objNew.QuoteId = obj.QuoteId;
			objNew.ClientNo = obj.ClientNo;
			objNew.QuoteNumber = obj.QuoteNumber;
			objNew.Notes = obj.Notes;
			objNew.Instructions = obj.Instructions;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.ContactNo = obj.ContactNo;
			objNew.DateQuoted = obj.DateQuoted;
			objNew.CurrencyNo = obj.CurrencyNo;
			objNew.Salesman = obj.Salesman;
			objNew.TermsNo = obj.TermsNo;
			objNew.DivisionNo = obj.DivisionNo;
			objNew.Freight = obj.Freight;
			objNew.Closed = obj.Closed;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.IncotermNo = obj.IncotermNo;
			objNew.CompanyName = obj.CompanyName;
			objNew.CompanyOnStop = obj.CompanyOnStop;
			objNew.CompanySOApproved = obj.CompanySOApproved;
			objNew.ContactName = obj.ContactName;
			objNew.CurrencyCode = obj.CurrencyCode;
			objNew.CurrencyDescription = obj.CurrencyDescription;
			objNew.SalesmanName = obj.SalesmanName;
			objNew.DivisionName = obj.DivisionName;
			objNew.QuoteValue = obj.QuoteValue;
			objNew.TermsName = obj.TermsName;
			objNew.OpenLines = obj.OpenLines;
			objNew.IncotermName = obj.IncotermName;
			objNew.ContactEmail = obj.ContactEmail;
			objNew.CreditLimit = obj.CreditLimit;
			objNew.Balance = obj.Balance;
            return objNew;
        }
		
		#endregion
		
	}
}
