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
		public partial class PurchaseQuote : BizObject {
		
		#region Properties

            protected static DAL.PurchaseQuoteElement Settings
            {
                get { return Globals.Settings.POQuotes; }
		}

		/// <summary>
        /// POQuoteId
		/// </summary>
        public System.Int32 POQuoteId { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// QuoteNumber
		/// </summary>
        public System.Int32 POQuoteNumber { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32 CompanyNo { get; set; }		
		/// <summary>
		/// ContactNo
		/// </summary>
		public System.Int32 ContactNo { get; set; }		
        ///// <summary>
        ///// CurrencyNo
        ///// </summary>
        //public System.Int32 CurrencyNo { get; set; }		
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
		/// ContactName
		/// </summary>
		public System.String ContactName { get; set; }		
        ///// <summary>
        ///// CurrencyCode
        ///// </summary>
        //public System.String CurrencyCode { get; set; }		
        ///// <summary>
        ///// CurrencyDescription
        ///// </summary>
        //public System.String CurrencyDescription { get; set; }
        /// <summary>
        /// CompanyName
        /// </summary>
        public System.String CompanyName { get; set; }
        /// <summary>
        /// SalesPersonNo
        /// </summary>
        public System.Int32? SalesPersonNo { get; set; }
        /// <summary>
        /// SalesPersonName
        /// </summary>
        public System.String SalesPersonName { get; set; }
        /// <summary>
        /// DivisionNo
        /// </summary>
        public System.Int32? DivisionNo { get; set; }
        /// <summary>
        /// DivisionName
        /// </summary>
        public System.String DivisionName { get; set; }

        /// <summary>
        /// Price Request Status
        /// </summary>
        public System.String PRStatus { get; set; }

        /// <summary>
        /// SalesPersonEmail
        /// </summary>
        public System.String SalesPersonEmail { get; set; }

        public int? PQStatus { get; set; }
		#endregion
		
		#region Methods
		
        ///// <summary>
        ///// CountForClient
        ///// Calls [usp_count_Quote_for_Client]
        ///// </summary>
        //public static Int32 CountForClient(System.Int32? clientId) {
        //    return Rebound.GlobalTrader.DAL.SiteProvider.Quote.CountForClient(clientId);
        //}		/// <summary>
        ///// CountForCompany
        ///// Calls [usp_count_Quote_for_Company]
        ///// </summary>
        //public static Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeClosed) {
        //    return Rebound.GlobalTrader.DAL.SiteProvider.Quote.CountForCompany(companyId, includeClosed);
        //}		/// <summary>
        ///// CountOpenForCompany
        ///// Calls [usp_count_Quote_open_for_Company]
        ///// </summary>
        //public static Int32 CountOpenForCompany(System.Int32? companyId) {
        //    return Rebound.GlobalTrader.DAL.SiteProvider.Quote.CountOpenForCompany(companyId);
        //}		/// <summary>
        ///// Delete
        ///// Calls [usp_delete_Quote]
        ///// </summary>
        //public static bool Delete(System.Int32? quoteId) {
        //    return Rebound.GlobalTrader.DAL.SiteProvider.Quote.Delete(quoteId);
        //}
		/// <summary>
		/// Insert
        /// Calls [usp_insert_PurchaseQuote]
		/// </summary>
        public static Int32 Insert(System.Int32? clientNo, System.String notes, System.Int32? companyNo, System.Int32? contactNo, System.Int32? currencyNo, System.Int32? updatedBy, System.Boolean? closed,System.Int32? salesperson,System.Int32? division)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.POQuote.Insert(clientNo, notes, companyNo, contactNo, currencyNo, updatedBy, closed, salesperson,division);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Quote]
		/// </summary>
        //public Int32 Insert() {
        //    return Rebound.GlobalTrader.DAL.SiteProvider.Quote.Insert(ClientNo, Notes, CompanyNo, ContactNo,  CurrencyNo,  Closed,  UpdatedBy);
        //}
        //[002] code end
		/// <summary>
		/// Get
        /// Calls [usp_select_PurchaseRequest]
		/// </summary>
        public static PurchaseQuote Get(System.Int32? poQuoteId)
        {
            Rebound.GlobalTrader.DAL.POQuoteDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.POQuote.Get(poQuoteId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                PurchaseQuote obj = new PurchaseQuote();
                obj.POQuoteId = objDetails.POQuoteId;
                obj.ClientNo = objDetails.ClientNo;
                obj.POQuoteNumber = objDetails.POQuoteNumber;
                obj.Notes = objDetails.Notes;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ContactNo = objDetails.ContactNo;
               // obj.CurrencyNo = objDetails.CurrencyNo;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.CompanyName = objDetails.CompanyName;
                obj.ContactName = objDetails.ContactName;
                //obj.CurrencyCode = objDetails.CurrencyCode;
                //obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.SalesPersonNo = objDetails.SalesPersonNo;
                obj.SalesPersonName = objDetails.SalesPersonName;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.DivisionName = objDetails.DivisionName;
                obj.SalesPersonEmail = objDetails.SalesPersonEmail;
                obj.PQStatus = objDetails.PQStatus;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// Update
        /// Calls [usp_update_Quote]
        /// </summary>
        public static bool Update(System.Int32? poQuoteId, System.String notes, System.Boolean? closed, System.Int32? contactNo, System.Int32? updatedBy,System.Int32? salesPerson,System.Int32? division)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.POQuote.Update(poQuoteId, notes, closed, contactNo,  updatedBy, salesPerson,division);
        }
        /// <summary>
        /// Update (without parameters)
        /// Calls [usp_update_PurchaseRequest]
        /// </summary>
        public bool Update()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.POQuote.Update(POQuoteId, Notes, Closed, ContactNo, UpdatedBy,SalesPersonNo,DivisionNo);
        }
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_POQuote_for_Page]
		/// </summary>
		public static PurchaseQuote GetForPage(System.Int32? poQuoteId) {
            Rebound.GlobalTrader.DAL.POQuoteDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.POQuote.GetForPage(poQuoteId);
			if (objDetails == null) {
				return null;
			} else {
                PurchaseQuote obj = new PurchaseQuote();
				obj.POQuoteId = objDetails.POQuoteId;
				obj.POQuoteNumber = objDetails.POQuoteNumber;
				obj.ClientNo = objDetails.ClientNo;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.Closed = objDetails.Closed;
                obj.PRStatus = objDetails.PRStatus;
				objDetails = null;
				return obj;
			}
		}
        /// <summary>
        /// GetCSVListForPurchaseQuote
        /// Calls [usp_selectAll_CSV_for_PurchaseQuote]
        /// </summary>
        public static List<PDFDocument> GetCSVListForPurchaseQuote(System.Int32? purchaseQuoteNo)
        {
            List<PDFDocumentDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.POQuote.GetCSVListForPurchaseQuote(purchaseQuoteNo);
            if (lstDetails == null)
            {
                return new List<PDFDocument>();
            }
            else
            {
                List<PDFDocument> lst = new List<PDFDocument>();
                foreach (PDFDocumentDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.PDFDocument obj = new Rebound.GlobalTrader.BLL.PDFDocument();
                    obj.PDFDocumentId = objDetails.PDFDocumentId;
                    obj.PDFDocumentRefNo = objDetails.PDFDocumentRefNo;
                    obj.Caption = objDetails.Caption;
                    obj.FileName = objDetails.FileName;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        ///// <summary>
        ///// GetForPrint
        ///// Calls [usp_select_Quote_for_Print]
        ///// </summary>
        //public static Quote GetForPrint(System.Int32? quoteId) {
        //    Rebound.GlobalTrader.DAL.QuoteDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Quote.GetForPrint(quoteId);
        //    if (objDetails == null) {
        //        return null;
        //    } else {
        //        Quote obj = new Quote();
        //        obj.QuoteId = objDetails.QuoteId;
        //        obj.ClientNo = objDetails.ClientNo;
        //        obj.QuoteNumber = objDetails.QuoteNumber;
        //        obj.Notes = objDetails.Notes;
        //        obj.Instructions = objDetails.Instructions;
        //        obj.CompanyNo = objDetails.CompanyNo;
        //        obj.ContactNo = objDetails.ContactNo;
        //        obj.DateQuoted = objDetails.DateQuoted;
        //        obj.CurrencyNo = objDetails.CurrencyNo;
        //        obj.Salesman = objDetails.Salesman;
        //        obj.TermsNo = objDetails.TermsNo;
        //        obj.DivisionNo = objDetails.DivisionNo;
        //        obj.Freight = objDetails.Freight;
        //        obj.Closed = objDetails.Closed;
        //        obj.IncotermNo = objDetails.IncotermNo;
        //        obj.UpdatedBy = objDetails.UpdatedBy;
        //        obj.DLUP = objDetails.DLUP;
        //        obj.CompanyName = objDetails.CompanyName;
        //        obj.CompanyOnStop = objDetails.CompanyOnStop;
        //        obj.CompanySOApproved = objDetails.CompanySOApproved;
        //        obj.ContactName = objDetails.ContactName;
        //        obj.CurrencyCode = objDetails.CurrencyCode;
        //        obj.CurrencyDescription = objDetails.CurrencyDescription;
        //        obj.SalesmanName = objDetails.SalesmanName;
        //        obj.DivisionName = objDetails.DivisionName;
        //        obj.QuoteValue = objDetails.QuoteValue;
        //        obj.TermsName = objDetails.TermsName;
        //        obj.OpenLines = objDetails.OpenLines;
        //        obj.IncotermName = objDetails.IncotermName;
        //        obj.ContactEmail = objDetails.ContactEmail;
        //        //[002] code start
        //        obj.AS9120 = objDetails.AS9120;
        //        //[002] code end
        //        objDetails = null;
        //        return obj;
        //    }
        //}
        ///// <summary>
        ///// GetIDFromNumber
        ///// Calls [usp_select_Quote_ID_from_Number]
        ///// </summary>
        //public static Quote GetIDFromNumber(System.Int32? quoteNumber, System.Int32? clientNo)
        //{
        //    Rebound.GlobalTrader.DAL.QuoteDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Quote.GetIDFromNumber(quoteNumber, clientNo);
        //    if (objDetails == null) {
        //        return null;
        //    } else {
        //        Quote obj = new Quote();
        //        obj.QuoteId = objDetails.QuoteId;
        //        objDetails = null;
        //        return obj;
        //    }
        //}
        ///// <summary>
        ///// GetNextNumber
        ///// Calls [usp_select_Quote_NextNumber]
        ///// </summary>
        //public static Quote GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy) {
        //    Rebound.GlobalTrader.DAL.QuoteDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Quote.GetNextNumber(clientNo, updatedBy);
        //    if (objDetails == null) {
        //        return null;
        //    } else {
        //        Quote obj = new Quote();
        //        obj.QuoteNumber = objDetails.QuoteNumber;
        //        objDetails = null;
        //        return obj;
        //    }
        //}
        ///// <summary>
        ///// GetListForCompany
        ///// Calls [usp_selectAll_Quote_for_Company]
        ///// </summary>
        //public static List<Quote> GetListForCompany(System.Int32? companyId, System.Boolean? includeClosed) {
        //    List<QuoteDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Quote.GetListForCompany(companyId, includeClosed);
        //    if (lstDetails == null) {
        //        return new List<Quote>();
        //    } else {
        //        List<Quote> lst = new List<Quote>();
        //        foreach (QuoteDetails objDetails in lstDetails) {
        //            Rebound.GlobalTrader.BLL.Quote obj = new Rebound.GlobalTrader.BLL.Quote();
        //            obj.QuoteId = objDetails.QuoteId;
        //            obj.ClientNo = objDetails.ClientNo;
        //            obj.QuoteNumber = objDetails.QuoteNumber;
        //            obj.Notes = objDetails.Notes;
        //            obj.Instructions = objDetails.Instructions;
        //            obj.CompanyNo = objDetails.CompanyNo;
        //            obj.ContactNo = objDetails.ContactNo;
        //            obj.DateQuoted = objDetails.DateQuoted;
        //            obj.CurrencyNo = objDetails.CurrencyNo;
        //            obj.Salesman = objDetails.Salesman;
        //            obj.TermsNo = objDetails.TermsNo;
        //            obj.DivisionNo = objDetails.DivisionNo;
        //            obj.Freight = objDetails.Freight;
        //            obj.Closed = objDetails.Closed;
        //            obj.IncotermNo = objDetails.IncotermNo;
        //            obj.UpdatedBy = objDetails.UpdatedBy;
        //            obj.DLUP = objDetails.DLUP;
        //            obj.CompanyName = objDetails.CompanyName;
        //            obj.CompanyOnStop = objDetails.CompanyOnStop;
        //            obj.CompanySOApproved = objDetails.CompanySOApproved;
        //            obj.ContactName = objDetails.ContactName;
        //            obj.CurrencyCode = objDetails.CurrencyCode;
        //            obj.CurrencyDescription = objDetails.CurrencyDescription;
        //            obj.SalesmanName = objDetails.SalesmanName;
        //            obj.DivisionName = objDetails.DivisionName;
        //            obj.QuoteValue = objDetails.QuoteValue;
        //            obj.TermsName = objDetails.TermsName;
        //            obj.OpenLines = objDetails.OpenLines;
        //            obj.IncotermName = objDetails.IncotermName;
        //            lst.Add(obj);
        //            obj = null;
        //        }
        //        lstDetails = null;
        //        return lst;
        //    }
        //}
        ///// <summary>
        ///// GetListForSourcingResult
        ///// Calls [usp_selectAll_Quote_for_SourcingResult]
        ///// </summary>
        //public static List<Quote> GetListForSourcingResult(System.Int32? sourcingResultNo) {
        //    List<QuoteDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Quote.GetListForSourcingResult(sourcingResultNo);
        //    if (lstDetails == null) {
        //        return new List<Quote>();
        //    } else {
        //        List<Quote> lst = new List<Quote>();
        //        foreach (QuoteDetails objDetails in lstDetails) {
        //            Rebound.GlobalTrader.BLL.Quote obj = new Rebound.GlobalTrader.BLL.Quote();
        //            obj.QuoteId = objDetails.QuoteId;
        //            obj.QuoteNumber = objDetails.QuoteNumber;
        //            lst.Add(obj);
        //            obj = null;
        //        }
        //        lstDetails = null;
        //        return lst;
        //    }
        //}
        ///// <summary>
        ///// GetListOpenForCompany
        ///// Calls [usp_selectAll_Quote_open_for_Company]
        ///// </summary>
        //public static List<Quote> GetListOpenForCompany(System.Int32? companyId) {
        //    List<QuoteDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Quote.GetListOpenForCompany(companyId);
        //    if (lstDetails == null) {
        //        return new List<Quote>();
        //    } else {
        //        List<Quote> lst = new List<Quote>();
        //        foreach (QuoteDetails objDetails in lstDetails) {
        //            Rebound.GlobalTrader.BLL.Quote obj = new Rebound.GlobalTrader.BLL.Quote();
        //            obj.QuoteId = objDetails.QuoteId;
        //            obj.ClientNo = objDetails.ClientNo;
        //            obj.QuoteNumber = objDetails.QuoteNumber;
        //            obj.Notes = objDetails.Notes;
        //            obj.Instructions = objDetails.Instructions;
        //            obj.CompanyNo = objDetails.CompanyNo;
        //            obj.ContactNo = objDetails.ContactNo;
        //            obj.DateQuoted = objDetails.DateQuoted;
        //            obj.CurrencyNo = objDetails.CurrencyNo;
        //            obj.Salesman = objDetails.Salesman;
        //            obj.TermsNo = objDetails.TermsNo;
        //            obj.DivisionNo = objDetails.DivisionNo;
        //            obj.Freight = objDetails.Freight;
        //            obj.Closed = objDetails.Closed;
        //            obj.IncotermNo = objDetails.IncotermNo;
        //            obj.UpdatedBy = objDetails.UpdatedBy;
        //            obj.DLUP = objDetails.DLUP;
        //            obj.CompanyName = objDetails.CompanyName;
        //            obj.CompanyOnStop = objDetails.CompanyOnStop;
        //            obj.CompanySOApproved = objDetails.CompanySOApproved;
        //            obj.ContactName = objDetails.ContactName;
        //            obj.CurrencyCode = objDetails.CurrencyCode;
        //            obj.CurrencyDescription = objDetails.CurrencyDescription;
        //            obj.SalesmanName = objDetails.SalesmanName;
        //            obj.DivisionName = objDetails.DivisionName;
        //            obj.QuoteValue = objDetails.QuoteValue;
        //            obj.TermsName = objDetails.TermsName;
        //            obj.OpenLines = objDetails.OpenLines;
        //            obj.IncotermName = objDetails.IncotermName;
        //            lst.Add(obj);
        //            obj = null;
        //        }
        //        lstDetails = null;
        //        return lst;
        //    }
        //}
        ///// <summary>
        ///// GetListOpenForLogin
        ///// Calls [usp_selectAll_Quote_open_for_Login]
        ///// </summary>
        //public static List<Quote> GetListOpenForLogin(System.Int32? loginId, System.Int32? topToSelect) {
        //    List<QuoteDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Quote.GetListOpenForLogin(loginId, topToSelect);
        //    if (lstDetails == null) {
        //        return new List<Quote>();
        //    } else {
        //        List<Quote> lst = new List<Quote>();
        //        foreach (QuoteDetails objDetails in lstDetails) {
        //            Rebound.GlobalTrader.BLL.Quote obj = new Rebound.GlobalTrader.BLL.Quote();
        //            obj.QuoteNumber = objDetails.QuoteNumber;
        //            obj.DateQuoted = objDetails.DateQuoted;
        //            obj.CompanyNo = objDetails.CompanyNo;
        //            obj.CompanyName = objDetails.CompanyName;
        //            obj.CreditLimit = objDetails.CreditLimit;
        //            obj.Balance = objDetails.Balance;
        //            obj.Salesman = objDetails.Salesman;
        //            obj.QuoteId = objDetails.QuoteId;
        //            lst.Add(obj);
        //            obj = null;
        //        }
        //        lstDetails = null;
        //        return lst;
        //    }
        //}
        ///// <summary>
        ///// GetListRecentForLogin
        ///// Calls [usp_selectAll_Quote_recent_for_Login]
        ///// </summary>
        //public static List<Quote> GetListRecentForLogin(System.Int32? loginId, System.Int32? topToSelect) {
        //    List<QuoteDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Quote.GetListRecentForLogin(loginId, topToSelect);
        //    if (lstDetails == null) {
        //        return new List<Quote>();
        //    } else {
        //        List<Quote> lst = new List<Quote>();
        //        foreach (QuoteDetails objDetails in lstDetails) {
        //            Rebound.GlobalTrader.BLL.Quote obj = new Rebound.GlobalTrader.BLL.Quote();
        //            obj.QuoteNumber = objDetails.QuoteNumber;
        //            obj.DateQuoted = objDetails.DateQuoted;
        //            obj.CompanyNo = objDetails.CompanyNo;
        //            obj.CompanyName = objDetails.CompanyName;
        //            obj.CreditLimit = objDetails.CreditLimit;
        //            obj.Balance = objDetails.Balance;
        //            obj.Salesman = objDetails.Salesman;
        //            obj.QuoteId = objDetails.QuoteId;
        //            lst.Add(obj);
        //            obj = null;
        //        }
        //        lstDetails = null;
        //        return lst;
        //    }
        //}
        ////[002] code start
       
        ////[002] code end
        ///// <summary>
        ///// UpdateCheckClosed
        ///// Calls [usp_update_Quote_CheckClosed]
        ///// </summary>
        //public static bool UpdateCheckClosed(System.Int32? quoteNo) {
        //    return Rebound.GlobalTrader.DAL.SiteProvider.Quote.UpdateCheckClosed(quoteNo);
        //}

        //private static Quote PopulateFromDBDetailsObject(QuoteDetails obj) {
        //    Quote objNew = new Quote();
        //    objNew.QuoteId = obj.QuoteId;
        //    objNew.ClientNo = obj.ClientNo;
        //    objNew.QuoteNumber = obj.QuoteNumber;
        //    objNew.Notes = obj.Notes;
        //    objNew.Instructions = obj.Instructions;
        //    objNew.CompanyNo = obj.CompanyNo;
        //    objNew.ContactNo = obj.ContactNo;
        //    objNew.DateQuoted = obj.DateQuoted;
        //    objNew.CurrencyNo = obj.CurrencyNo;
        //    objNew.Salesman = obj.Salesman;
        //    objNew.TermsNo = obj.TermsNo;
        //    objNew.DivisionNo = obj.DivisionNo;
        //    objNew.Freight = obj.Freight;
        //    objNew.Closed = obj.Closed;
        //    objNew.UpdatedBy = obj.UpdatedBy;
        //    objNew.DLUP = obj.DLUP;
        //    objNew.IncotermNo = obj.IncotermNo;
        //    objNew.CompanyName = obj.CompanyName;
        //    objNew.CompanyOnStop = obj.CompanyOnStop;
        //    objNew.CompanySOApproved = obj.CompanySOApproved;
        //    objNew.ContactName = obj.ContactName;
        //    objNew.CurrencyCode = obj.CurrencyCode;
        //    objNew.CurrencyDescription = obj.CurrencyDescription;
        //    objNew.SalesmanName = obj.SalesmanName;
        //    objNew.DivisionName = obj.DivisionName;
        //    objNew.QuoteValue = obj.QuoteValue;
        //    objNew.TermsName = obj.TermsName;
        //    objNew.OpenLines = obj.OpenLines;
        //    objNew.IncotermName = obj.IncotermName;
        //    objNew.ContactEmail = obj.ContactEmail;
        //    objNew.CreditLimit = obj.CreditLimit;
        //    objNew.Balance = obj.Balance;
        //    return objNew;
        //}

        /// <summary>
        /// Insert
        /// Calls [usp_CSVImport]
        /// </summary>
        public static Int32 InsertCSV(System.Int32? ID, System.Int32? LoginID, System.Int32? clientNo, System.Int32? companyNo, System.String FileName, System.String Type)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.POQuote.InsertCSV(ID, LoginID, clientNo, companyNo, FileName, Type);
            return objReturn;
        }
        /// <summary>
        /// Delete
        /// Calls [usp_PurchaseQuoteCsvDelete]
        /// </summary>
        public static bool DeletePurchaseQuoteCsv(System.Int32? PurchaseQuoteCSVId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.POQuote.DeletePurchaseQuoteCsv(PurchaseQuoteCSVId);
        }

		#endregion
		
	}
}
