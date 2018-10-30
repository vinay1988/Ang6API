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
		public partial class PurchaseQuoteLine : BizObject {
		
		#region Properties

            protected static DAL.QuoteLineElement Settings
            {
                get { return Globals.Settings.QuoteLines; }
            }

		/// <summary>
        /// PurchaseQuoteLineId
		/// </summary>
        public System.Int32 PurchaseQuoteLineId { get; set; }
        /// <summary>
        /// PurchaseQuoteNo
        /// </summary>
        public System.Int32? PurchaseQuoteNo { get; set; }
		/// <summary>
        /// CustomerRequirementNo
		/// </summary>
        public System.Int32 CustomerRequirementNo { get; set; }
        /// <summary>
        /// BOMNo
        /// </summary>
        public System.Int32 BOMNo { get; set; }		
		/// <summary>
		/// FullPart
		/// </summary>
		public System.String FullPart { get; set; }		
		/// <summary>
		/// Part
		/// </summary>
		public System.String Part { get; set; }		
		/// <summary>
		/// Quantity
		/// </summary>
		public System.Int32 Quantity { get; set; }
        /// <summary>
        /// CompanyNo
        /// </summary>
        public System.Int32 CompanyNo { get; set; }
        /// <summary>
        /// ContactName
        /// </summary>
        public System.String ContactName { get; set; }
        /// <summary>
        /// ContactNo
        /// </summary>
        public System.Int32 ContactNo { get; set; }
        /// <summary>
        /// TargetPrice
        /// </summary>
        public System.Double TargetPrice { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public System.Double UnitPrice { get; set; }
        /// <summary>
        /// CurrencyNo
        /// </summary>
        public System.Int32? CurrencyNo { get; set; }	
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }		
		/// <summary>
		/// CompanyName
		/// </summary>
		public System.String CompanyName { get; set; }		
		/// <summary>
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }		
		/// <summary>
		/// RowCnt
		/// </summary>
		public System.Int32? RowCnt { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32? ClientNo { get; set; }		
		/// <summary>
		/// ClientName
		/// </summary>
		public System.String ClientName { get; set; }		
        /// <summary>
        /// Salesman
        /// </summary>
        public System.Int32 Salesman { get; set; }
        /// <summary>
        /// SalesmanName
        /// </summary>
        public System.String SalesmanName { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public System.String LineNotes { get; set; }
        /// <summary>
        /// Clsoed
        /// </summary>
        public System.Boolean? Closed { get; set; }
        /// <summary>
        /// CustomerRequirementNumber
        /// </summary>
        public System.Int32? CustomerRequirementNumber { get; set; }
        /// <summary>
        /// BOMName
        /// </summary>
        public System.String BOMName { get; set; }
        /// <summary>
        /// PurchaseQuoteNumber
        /// </summary>
        public System.Int32? PurchaseQuoteNumber { get; set; }
        /// <summary>
        /// DatePOQuoted
        /// </summary>
        public System.DateTime? DatePOQuoted { get; set; }
        /// <summary>
        /// CSV Log Message
        /// </summary>
        public System.String Message { get; set; }
        public System.Int32 PRCurrencyNo { get; set; }
        public System.String PRCurencyCode { get; set; }
        public System.Int32 ReqCurrencyNo { get; set; }
        public System.String ReqCurrencyCode { get; set; }
        public System.Double? ConvertedTargetValue { get; set; }
        public string PRStatus { get; set; }
        public int? PQStatus { get; set; }
        public bool IsImported { get; set; }
        public System.String MSL { get; set; }
        public System.String SPQ { get; set; }
        public System.String LeadTime { get; set; }
        public System.String RoHSStatus { get; set; }
        public System.String FactorySealed { get; set; }
        public System.Int32 PurchaseRequestLineDetailId { get; set; }
        public System.String SupplierType { get; set; }
        public System.Double PHPrice { get; set; }

        public System.Boolean? FactorySealedR { get; set; }
        public System.String MSLR { get; set; }
        public System.Boolean? AS9120 { get; set; }
        public System.Boolean? IsGlobalCurrencySame { get; set; }

        public System.Boolean? Status { get; set; }
        public System.String LoginName { get; set; }
        public System.String FileName { get; set; }
        #endregion
		
		#region Methods

        /// <summary>
        /// GetListClosedForQuote
        /// Calls [usp_selectAll_PurchaseRequestLine]
        /// </summary>
        public static List<PurchaseQuoteLine> GetListLines(System.Int32? poQuoteId)
        {
            List<POQuoteLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.POQuoteLine.GetListLines(poQuoteId);
            if (lstDetails == null)
            {
                return new List<PurchaseQuoteLine>();
            }
            else
            {
                List<PurchaseQuoteLine> lst = new List<PurchaseQuoteLine>();
                foreach (POQuoteLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.PurchaseQuoteLine obj = new Rebound.GlobalTrader.BLL.PurchaseQuoteLine();
                    obj.PurchaseQuoteLineId = objDetails.PurchaseQuoteLineId;
                    obj.PurchaseQuoteNo = objDetails.PurchaseQuoteNo;
                    obj.CustomerRequirementNo = objDetails.CustomerRequirementNo;
                    obj.BOMNo = objDetails.BOMNo;
                    obj.FullPart = objDetails.FullPart;
                    obj.Part = objDetails.Part;
                    obj.Quantity = objDetails.Quantity;
                    obj.TargetPrice = objDetails.TargetPrice;
                    obj.LineNotes = objDetails.LineNotes;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
                    obj.BOMName = objDetails.BOMName;
                    obj.BOMNo = objDetails.BOMNo;
                    obj.Closed = objDetails.Closed;
                    obj.UnitPrice = objDetails.UnitPrice;
                    obj.PRCurrencyNo = objDetails.PRCurrencyNo;
                    obj.PRCurencyCode = objDetails.PRCurencyCode;
                    obj.ReqCurrencyNo = objDetails.ReqCurrencyNo;
                    obj.ReqCurrencyCode = objDetails.ReqCurrencyCode;
                    obj.ConvertedTargetValue = objDetails.ConvertedTargetValue;
                    obj.PQStatus = objDetails.PQStatus;
                    obj.PRStatus = objDetails.PRStatus;
                    obj.IsImported = objDetails.PQStatus == (int)BLL.Enumerations.PurchaseQuoteStatus.List.Imported;
                    obj.MSL = objDetails.MSL;
                    obj.SPQ = objDetails.SPQ;
                    obj.LeadTime = objDetails.LeadTime;
                    obj.RoHSStatus = objDetails.RoHSStatus;
                    obj.FactorySealed = objDetails.FactorySealed;
                    obj.PHPrice = objDetails.PHPrice;
                    obj.MSLR = objDetails.MSLR;
                    obj.FactorySealedR = objDetails.FactorySealedR;
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
        /// Insert
        /// Calls [usp_insert_PurchaseRequestLine]
        /// </summary>
        public static Int32 Insert(System.Int32? poQuoteNo, System.String xmlReqIds, System.Int32? updatedBy,System.Int32? clientNo)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.POQuoteLine.Insert(poQuoteNo, xmlReqIds, updatedBy,clientNo);
            return objReturn;
        }

        /// <summary>
        /// Delete Purchase Quote Lines
        /// Calls [usp_delete_PurchaseRequestLine]
        /// </summary>
        public static bool Delete(System.Int32? poQuoteLineId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.POQuoteLine.Delete(poQuoteLineId);
        }

        /// <summary>
        /// DataListNugget
        /// Calls [usp_datalistnugget_PurchaseRequetLine]
        /// </summary>
        public static List<PurchaseQuoteLine> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.Boolean? includeClosed, System.Int32? poQuoteNoLo, System.Int32? poQuoteNoHi, System.DateTime? dateQuotedFrom, System.DateTime? dateQuotedTo, System.Boolean? recentOnly)
        {
            List<POQuoteLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.POQuoteLine.DataListNugget(clientId, teamId, divisionId, loginId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch,salesmanSearch,  includeClosed, poQuoteNoLo, poQuoteNoHi, dateQuotedFrom, dateQuotedTo, recentOnly);
            if (lstDetails == null)
            {
                return new List<PurchaseQuoteLine>();
            }
            else
            {
                List<PurchaseQuoteLine> lst = new List<PurchaseQuoteLine>();
                foreach (POQuoteLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.PurchaseQuoteLine obj = new Rebound.GlobalTrader.BLL.PurchaseQuoteLine();
                    obj.PurchaseQuoteLineId = objDetails.PurchaseQuoteLineId;
                    obj.PurchaseQuoteNumber = objDetails.PurchaseQuoteNumber;
                    obj.PurchaseQuoteNo = objDetails.PurchaseQuoteNo;
                    obj.Part = objDetails.Part;
                   // obj.UnitPrice = objDetails.UnitPrice;
                   // obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.Quantity = objDetails.Quantity;
                    obj.CompanyName = objDetails.CompanyName;
                   // obj.CompanyNo = objDetails.CompanyNo;
                    obj.BOMName = objDetails.BOMName;
                    obj.BOMNo = objDetails.BOMNo;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.DatePOQuoted = objDetails.DatePOQuoted;
                    obj.SalesmanName = objDetails.SalesmanName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Source
        /// Calls [usp_source_PurchaseRequestLineDetails]
        /// </summary>
        public static List<PurchaseQuoteLine> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? maxDate, out DateTime? outDate, System.Boolean? blnReferesh, bool IsServerLocal)
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
            List<POQuoteLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.POQuoteLine.Source(clientId, partSearch, index, StartDate, EndDate, out outDate, IsServerLocal);
            if (lstDetails == null)
            {
                return new List<PurchaseQuoteLine>();
            }
            else
            {
                List<PurchaseQuoteLine> lst = new List<PurchaseQuoteLine>();
                foreach (POQuoteLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.PurchaseQuoteLine obj = new Rebound.GlobalTrader.BLL.PurchaseQuoteLine();
                    obj.PurchaseQuoteLineId = objDetails.PurchaseQuoteLineId;
                    obj.PurchaseQuoteNo = objDetails.PurchaseQuoteNo;
                    obj.PurchaseQuoteNumber = objDetails.PurchaseQuoteNumber;
                    obj.Quantity = objDetails.Quantity;
                    obj.Part = objDetails.Part;
                    //obj.ROHS = objDetails.ROHS;
                    //obj.ManufacturerNo = objDetails.ManufacturerNo;
                   // obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    //obj.DateCode = objDetails.DateCode;
                    obj.DatePOQuoted = objDetails.DatePOQuoted;
                    obj.UnitPrice = objDetails.UnitPrice;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    //obj.PackageName = objDetails.PackageName;
                    //obj.ProductName = objDetails.ProductName;
                    //obj.CustomerPart = objDetails.CustomerPart;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.ClientName = objDetails.ClientName;
                    //obj.ClientDataVisibleToOthers = objDetails.ClientDataVisibleToOthers;
                    obj.Salesman = objDetails.Salesman;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.MSL = objDetails.MSL;
                    obj.SPQ = objDetails.SPQ;
                    obj.LeadTime = objDetails.LeadTime;
                    obj.RoHSStatus = objDetails.RoHSStatus;
                    obj.FactorySealed = objDetails.FactorySealed;
                    obj.SupplierType = objDetails.SupplierType;
                    obj.PurchaseRequestLineDetailId = objDetails.PurchaseRequestLineDetailId;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
      

        /// <summary>
        /// Csv Import Log
        /// Calls [usp_CsvImportLog]
        /// </summary>
        public static List<PurchaseQuoteLine> GetLog(System.Int32? ID)
        {
            List<POQuoteLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.POQuoteLine.GetLog(ID);
            if (lstDetails == null)
            {
                return new List<PurchaseQuoteLine>();
            }
            else
            {
                List<PurchaseQuoteLine> lst = new List<PurchaseQuoteLine>();
                foreach (POQuoteLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.PurchaseQuoteLine obj = new Rebound.GlobalTrader.BLL.PurchaseQuoteLine();
                    obj.Message = objDetails.Message;
                    obj.DatePOQuoted = objDetails.DatePOQuoted;
                    obj.PurchaseQuoteLineId = objDetails.PurchaseQuoteLineId;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }

        }

        /// <summary>
        /// Csv Import Log BOM
        /// Calls [usp_CsvBomImportLog]
        /// </summary>
        public static List<PurchaseQuoteLine> GetLogBom(System.Int32? ID)
        {
            List<POQuoteLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.POQuoteLine.GetLogBom(ID);
            if (lstDetails == null)
            {
                return new List<PurchaseQuoteLine>();
            }
            else
            {
                List<PurchaseQuoteLine> lst = new List<PurchaseQuoteLine>();
                foreach (POQuoteLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.PurchaseQuoteLine obj = new Rebound.GlobalTrader.BLL.PurchaseQuoteLine();
                    obj.Message = objDetails.Message;
                    obj.DatePOQuoted = objDetails.DatePOQuoted;
                    obj.PurchaseQuoteLineId = objDetails.PurchaseQuoteLineId;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }

        }

        /// <summary>
        /// Csv Import Log
        /// Calls [usp_CsvUploadLog]
        /// </summary>
        public static List<PurchaseQuoteLine> GetUploadLog(System.Int32? LoginId)
        {
            List<POQuoteLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.POQuoteLine.GetUploadLog(LoginId);
            if (lstDetails == null)
            {
                return new List<PurchaseQuoteLine>();
            }
            else
            {
                List<PurchaseQuoteLine> lst = new List<PurchaseQuoteLine>();
                foreach (POQuoteLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.PurchaseQuoteLine obj = new Rebound.GlobalTrader.BLL.PurchaseQuoteLine();
                    obj.Message = objDetails.Message;
                    obj.DatePOQuoted = objDetails.DatePOQuoted;
                    obj.PurchaseQuoteLineId = objDetails.PurchaseQuoteLineId;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }

        }

        /// <summary>
        ///  Log History
        /// Calls [usp_GetLogHistory]
        /// </summary>
        public static List<PurchaseQuoteLine> GetLogHistory(System.Int32? ClientId)
        {
            List<POQuoteLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.POQuoteLine.GetLogHistory(ClientId);
            if (lstDetails == null)
            {
                return new List<PurchaseQuoteLine>();
            }
            else
            {
                List<PurchaseQuoteLine> lst = new List<PurchaseQuoteLine>();
                foreach (POQuoteLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.PurchaseQuoteLine obj = new Rebound.GlobalTrader.BLL.PurchaseQuoteLine();
                    obj.Message = objDetails.Message;
                    obj.FileName = objDetails.FileName;
                    obj.Status = objDetails.Status;
                    obj.LoginName = objDetails.LoginName;
                    obj.PurchaseQuoteLineId = objDetails.PurchaseQuoteLineId;
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
