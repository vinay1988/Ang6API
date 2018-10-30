//Marker     Changed by      Date         Remarks
//[001]      Vinay           22/01/2014     CR:- Add AS9120 Requirement in GT application
//[002]      Aashu          21/June/2018   [REB-11754]: MSL level
//[003]      Aashu          1/08/2018   [REB-12517]: Filter on quotes marked as important on the quote screen
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

namespace Rebound.GlobalTrader.BLL
{
    public partial class QuoteLine : BizObject
    {
		
		#region Properties

        protected static DAL.QuoteLineElement Settings
        {
			get { return Globals.Settings.QuoteLines; }
		}

		/// <summary>
		/// QuoteLineId
		/// </summary>
		public System.Int32 QuoteLineId { get; set; }		
		/// <summary>
		/// QuoteNo
		/// </summary>
		public System.Int32 QuoteNo { get; set; }		
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
		/// ETA
		/// </summary>
		public System.String ETA { get; set; }		
		/// <summary>
		/// Instructions
		/// </summary>
		public System.String Instructions { get; set; }		
		/// <summary>
		/// ProductNo
		/// </summary>
		public System.Int32? ProductNo { get; set; }		
		/// <summary>
		/// ReasonNo
		/// </summary>
		public System.Int32? ReasonNo { get; set; }		
		/// <summary>
		/// CustomerPart
		/// </summary>
		public System.String CustomerPart { get; set; }		
		/// <summary>
		/// StockNo
		/// </summary>
		public System.Int32? StockNo { get; set; }		
		/// <summary>
		/// ServiceNo
		/// </summary>
		public System.Int32? ServiceNo { get; set; }		
		/// <summary>
		/// ROHS
		/// </summary>
		public System.Byte? ROHS { get; set; }		
		/// <summary>
		/// Closed
		/// </summary>
		public System.Boolean Closed { get; set; }		
		/// <summary>
		/// OriginalOfferPrice
		/// </summary>
		public System.Double? OriginalOfferPrice { get; set; }		
		/// <summary>
		/// OriginalOfferCurrencyNo
		/// </summary>
		public System.Int32? OriginalOfferCurrencyNo { get; set; }		
		/// <summary>
		/// OriginalOfferDate
		/// </summary>
		public System.DateTime? OriginalOfferDate { get; set; }		
		/// <summary>
		/// OriginalOfferSupplierNo
		/// </summary>
		public System.Int32? OriginalOfferSupplierNo { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// FullCustomerPart
		/// </summary>
		public System.String FullCustomerPart { get; set; }		
		/// <summary>
		/// NotQuoted
		/// </summary>
		public System.Boolean NotQuoted { get; set; }		
		/// <summary>
		/// SourcingResultNo
		/// </summary>
		public System.Int32? SourcingResultNo { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// QuoteId
		/// </summary>
		public System.Int32 QuoteId { get; set; }		
		/// <summary>
		/// QuoteNumber
		/// </summary>
		public System.Int32 QuoteNumber { get; set; }		
		/// <summary>
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }		
		/// <summary>
		/// DateQuoted
		/// </summary>
		public System.DateTime DateQuoted { get; set; }		
		/// <summary>
		/// CompanyName
		/// </summary>
		public System.String CompanyName { get; set; }		
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
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }		
		/// <summary>
		/// RowCnt
		/// </summary>
		public System.Int32? RowCnt { get; set; }		
		/// <summary>
		/// LineNotes
		/// </summary>
		public System.String LineNotes { get; set; }		
		/// <summary>
		/// ManufacturerName
		/// </summary>
		public System.String ManufacturerName { get; set; }		
		/// <summary>
		/// ManufacturerCode
		/// </summary>
		public System.String ManufacturerCode { get; set; }		
		/// <summary>
		/// PackageName
		/// </summary>
		public System.String PackageName { get; set; }		
		/// <summary>
		/// PackageDescription
		/// </summary>
		public System.String PackageDescription { get; set; }		
		/// <summary>
		/// ProductName
		/// </summary>
		public System.String ProductName { get; set; }		
		/// <summary>
		/// ProductDescription
		/// </summary>
		public System.String ProductDescription { get; set; }		
		/// <summary>
		/// CurrencyNo
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }		
		/// <summary>
		/// ReasonName
		/// </summary>
		public System.String ReasonName { get; set; }		
		/// <summary>
		/// OriginalOfferCurrencyCode
		/// </summary>
		public System.String OriginalOfferCurrencyCode { get; set; }		
		/// <summary>
		/// OriginalOfferSupplierName
		/// </summary>
		public System.String OriginalOfferSupplierName { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32? ClientNo { get; set; }		
		/// <summary>
		/// ClientName
		/// </summary>
		public System.String ClientName { get; set; }		
		/// <summary>
		/// ClientDataVisibleToOthers
		/// </summary>
		public System.Boolean? ClientDataVisibleToOthers { get; set; }
        /// <summary>
        /// Salesman
        /// </summary>
        public System.Int32 Salesman { get; set; }
        /// <summary>
        /// SalesmanName
        /// </summary>
        public System.String SalesmanName { get; set; }
        //[001] code start
        /// <summary>
        /// ProductSource
        /// </summary>
        public System.Byte? ProductSource { get; set; }
        //[001] code end
        public double? UPLiftPrice { get; set; }

        public string SourcingTable { get; set; }
        public System.Int32? POHubCompanyNo { get; set; }
        public System.DateTime? DeliveryDate { get; set; }
       // public System.DateTime? DeliveryDate { get; set; }
        public System.Boolean? IsIPOCreated { get; set; }

        public System.String QuoteNotes { get; set; }
        /// ClientCode
        /// </summary>
        public System.String ClientCode { get; set; }
        /// <summary>
        /// 

        public System.String DutyCode { get; set; }
        public System.Double? DutyRate { get; set; }
        public System.String Reason { get; set; }
        public System.String ReasonNote { get; set; }
      //  public System.Boolean? IsImportant { get; set; } 
        public System.String MSLLevel { get; set; }		
        //[002] start
        /// MSL
        /// </summary>
        public System.String MSL { get; set; }
        //[002] end
        public System.Boolean? IsProdHazardous { get; set; }
        public System.Boolean? PrintHazardous { get; set; }
        public System.Double? TotalValue { get; set; }
        public System.Double? TotalInBase { get; set; }
        public System.String QuoteStatusName { get; set; }
		#endregion
		
		#region Methods
		
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_QuoteLine]
		/// </summary>
        //[003] Added important parameter
        public static List<QuoteLine> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.Boolean? includeClosed, System.Int32? quoteNoLo, System.Int32? quoteNoHi, System.DateTime? dateQuotedFrom, System.DateTime? dateQuotedTo, System.Boolean? recentOnly, System.Boolean? important, System.Int32? totalLo, System.Int32? totalHi,System.Int32? qStatus)
        {
            List<QuoteLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.QuoteLine.DataListNugget(clientId, teamId, divisionId, loginId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, salesmanSearch, includeClosed, quoteNoLo, quoteNoHi, dateQuotedFrom, dateQuotedTo, recentOnly, important, totalLo, totalHi, qStatus);
            if (lstDetails == null)
            {
				return new List<QuoteLine>();
            }
            else
            {
				List<QuoteLine> lst = new List<QuoteLine>();
                foreach (QuoteLineDetails objDetails in lstDetails)
                {
					Rebound.GlobalTrader.BLL.QuoteLine obj = new Rebound.GlobalTrader.BLL.QuoteLine();
					obj.QuoteId = objDetails.QuoteId;
					obj.QuoteNumber = objDetails.QuoteNumber;
					obj.Part = objDetails.Part;
					obj.Price = objDetails.Price;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.Quantity = objDetails.Quantity;
					obj.DateQuoted = objDetails.DateQuoted;
					obj.CompanyName = objDetails.CompanyName;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.ContactName = objDetails.ContactName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ROHS = objDetails.ROHS;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
                    obj.TotalValue = objDetails.TotalValue;
                    obj.TotalInBase = objDetails.TotalInBase;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.QuoteStatusName = objDetails.QuoteStatusName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Delete
		/// Calls [usp_delete_QuoteLine]
		/// </summary>
        public static bool Delete(System.Int32? quoteLineId)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.QuoteLine.Delete(quoteLineId);
		}
        //[001] code start
		/// <summary>
		/// Insert
		/// Calls [usp_insert_QuoteLine]
		/// </summary>
        public static Int32 Insert(System.Int32? quoteNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.String eta, System.String instructions, System.Int32? productNo, System.Int32? reasonNo, System.String customerPart, System.Int32? serviceNo, System.Int32? stockNo, System.Byte? rohs, System.String notes, System.Int32? originalOfferCurrencyNo, System.DateTime? originalOfferDate, System.Double? originalOfferPrice, System.Int32? originalOfferSupplierNo, System.Int32? sourcingResultNo, System.Int32? updatedBy, System.Byte? productSource, System.String mslLevel, System.Boolean? printHazadous)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.QuoteLine.Insert(quoteNo, part, manufacturerNo, dateCode, packageNo, quantity, price, eta, instructions, productNo, reasonNo, customerPart, serviceNo, stockNo, rohs, notes, originalOfferCurrencyNo, originalOfferDate, originalOfferPrice, originalOfferSupplierNo, sourcingResultNo, updatedBy, productSource, mslLevel, printHazadous);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_QuoteLine]
		/// </summary>
        public Int32 Insert()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.QuoteLine.Insert(QuoteNo, Part, ManufacturerNo, DateCode, PackageNo, Quantity, Price, ETA, Instructions, ProductNo, ReasonNo, CustomerPart, ServiceNo, StockNo, ROHS, Notes, OriginalOfferCurrencyNo, OriginalOfferDate, OriginalOfferPrice, OriginalOfferSupplierNo, SourcingResultNo, UpdatedBy, ProductSource, MSLLevel, PrintHazardous);
		}
        //[001] code end
		/// <summary>
		/// InsertFromCustomerRequirement
		/// Calls [usp_insert_QuoteLine_from_CustomerRequirement]
		/// </summary>
        public static Int32 InsertFromCustomerRequirement(System.Int32? customerRequirementId, System.Int32? quoteNo)
        {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.QuoteLine.InsertFromCustomerRequirement(customerRequirementId, quoteNo);
			return objReturn;
		}
		/// <summary>
		/// InsertFromSourcingResult
		/// Calls [usp_insert_QuoteLine_from_SourcingResult]
		/// </summary>
        public static Int32 InsertFromSourcingResult(System.Int32? sourcingResultId, System.Int32? quoteNo, System.DateTime? dateQuoted)
        {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.QuoteLine.InsertFromSourcingResult(sourcingResultId, quoteNo, dateQuoted);
			return objReturn;
		}
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_QuoteLine]
		/// </summary>
        public static List<QuoteLine> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Boolean? includeClosed, System.Int32? quoteNoLo, System.Int32? quoteNoHi, System.DateTime? dateQuotedFrom, System.DateTime? dateQuotedTo)
        {
			List<QuoteLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.QuoteLine.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, partSearch, cmSearch, includeClosed, quoteNoLo, quoteNoHi, dateQuotedFrom, dateQuotedTo);
            if (lstDetails == null)
            {
				return new List<QuoteLine>();
            }
            else
            {
				List<QuoteLine> lst = new List<QuoteLine>();
                foreach (QuoteLineDetails objDetails in lstDetails)
                {
					Rebound.GlobalTrader.BLL.QuoteLine obj = new Rebound.GlobalTrader.BLL.QuoteLine();
					obj.QuoteLineId = objDetails.QuoteLineId;
					obj.QuoteNumber = objDetails.QuoteNumber;
					obj.Quantity = objDetails.Quantity;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.Price = objDetails.Price;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.DateQuoted = objDetails.DateQuoted;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
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
		/// Calls [usp_select_QuoteLine]
		/// </summary>
        public static QuoteLine Get(System.Int32? quoteLineId)
        {
			Rebound.GlobalTrader.DAL.QuoteLineDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.QuoteLine.Get(quoteLineId);
            if (objDetails == null)
            {
				return null;
            }
            else
            {
				QuoteLine obj = new QuoteLine();
				obj.QuoteLineId = objDetails.QuoteLineId;
				obj.QuoteNo = objDetails.QuoteNo;
				obj.FullPart = objDetails.FullPart;
				obj.Part = objDetails.Part;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.DateCode = objDetails.DateCode;
				obj.PackageNo = objDetails.PackageNo;
				obj.Quantity = objDetails.Quantity;
				obj.Price = objDetails.Price;
				obj.ETA = objDetails.ETA;
				obj.Instructions = objDetails.Instructions;
				obj.ProductNo = objDetails.ProductNo;
				obj.ReasonNo = objDetails.ReasonNo;
				obj.CustomerPart = objDetails.CustomerPart;
				obj.StockNo = objDetails.StockNo;
				obj.ROHS = objDetails.ROHS;
				obj.Closed = objDetails.Closed;
				obj.ServiceNo = objDetails.ServiceNo;
				obj.OriginalOfferPrice = objDetails.OriginalOfferPrice;
				obj.OriginalOfferCurrencyNo = objDetails.OriginalOfferCurrencyNo;
				obj.OriginalOfferDate = objDetails.OriginalOfferDate;
				obj.LineNotes = objDetails.LineNotes;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.ManufacturerCode = objDetails.ManufacturerCode;
				obj.PackageName = objDetails.PackageName;
				obj.PackageDescription = objDetails.PackageDescription;
				obj.ProductName = objDetails.ProductName;
				obj.ProductDescription = objDetails.ProductDescription;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.QuoteNumber = objDetails.QuoteNumber;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.DateQuoted = objDetails.DateQuoted;
				obj.ReasonName = objDetails.ReasonName;
				obj.OriginalOfferCurrencyCode = objDetails.OriginalOfferCurrencyCode;
				obj.NotQuoted = objDetails.NotQuoted;
				obj.OriginalOfferSupplierNo = objDetails.OriginalOfferSupplierNo;
				obj.OriginalOfferSupplierName = objDetails.OriginalOfferSupplierName;
				obj.SourcingResultNo = objDetails.SourcingResultNo;
				obj.ClientNo = objDetails.ClientNo;
                //[001] code start
                obj.ProductSource = objDetails.ProductSource;
                obj.SourcingTable = objDetails.SourcingTable;
                obj.DeliveryDate = objDetails.DeliveryDate;
                obj.IsIPOCreated = objDetails.IsIPOCreated;
                //[001] code end
               // obj.DeliveryDate = objDetails.DeliveryDate;
                obj.POHubCompanyNo = objDetails.POHubCompanyNo;
                obj.QuoteNotes = objDetails.QuoteNotes;
                obj.ProductInactive = objDetails.ProductInactive;
                obj.DutyCode = objDetails.DutyCode;
                obj.DutyRate = objDetails.DutyRate;
               // obj.IsImportant = objDetails.IsImportant;
                obj.MSLLevel = objDetails.MSL;

                obj.IsProdHazardous = objDetails.IsProdHazardous;
                obj.PrintHazardous = objDetails.PrintHazardous;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListClosedForQuote
		/// Calls [usp_selectAll_QuoteLine_Closed_for_Quote]
		/// </summary>
        public static List<QuoteLine> GetListClosedForQuote(System.Int32? quoteId)
        {
			List<QuoteLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.QuoteLine.GetListClosedForQuote(quoteId);
            if (lstDetails == null)
            {
				return new List<QuoteLine>();
            }
            else
            {
				List<QuoteLine> lst = new List<QuoteLine>();
                foreach (QuoteLineDetails objDetails in lstDetails)
                {
					Rebound.GlobalTrader.BLL.QuoteLine obj = new Rebound.GlobalTrader.BLL.QuoteLine();
					obj.QuoteLineId = objDetails.QuoteLineId;
					obj.QuoteNo = objDetails.QuoteNo;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.DateCode = objDetails.DateCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.Quantity = objDetails.Quantity;
					obj.Price = objDetails.Price;
					obj.ETA = objDetails.ETA;
					obj.Instructions = objDetails.Instructions;
					obj.ProductNo = objDetails.ProductNo;
					obj.ReasonNo = objDetails.ReasonNo;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.StockNo = objDetails.StockNo;
					obj.ROHS = objDetails.ROHS;
					obj.Closed = objDetails.Closed;
					obj.ServiceNo = objDetails.ServiceNo;
					obj.OriginalOfferPrice = objDetails.OriginalOfferPrice;
					obj.OriginalOfferCurrencyNo = objDetails.OriginalOfferCurrencyNo;
					obj.OriginalOfferDate = objDetails.OriginalOfferDate;
					obj.LineNotes = objDetails.LineNotes;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.QuoteNumber = objDetails.QuoteNumber;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.DateQuoted = objDetails.DateQuoted;
					obj.ReasonName = objDetails.ReasonName;
					obj.OriginalOfferCurrencyCode = objDetails.OriginalOfferCurrencyCode;
					obj.NotQuoted = objDetails.NotQuoted;
					obj.OriginalOfferSupplierNo = objDetails.OriginalOfferSupplierNo;
					obj.OriginalOfferSupplierName = objDetails.OriginalOfferSupplierName;
					obj.SourcingResultNo = objDetails.SourcingResultNo;
					obj.ClientNo = objDetails.ClientNo;
                    //[001] code start
                    obj.ProductSource = objDetails.ProductSource;
                    //[001] code end
                    //[002] code start
                    obj.MSL = objDetails.MSL;
                    //[002] code end
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForQuote
		/// Calls [usp_selectAll_QuoteLine_for_Quote]
		/// </summary>
        public static List<QuoteLine> GetListForQuote(System.Int32? quoteId)
        {
			List<QuoteLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.QuoteLine.GetListForQuote(quoteId);
            if (lstDetails == null)
            {
				return new List<QuoteLine>();
            }
            else
            {
				List<QuoteLine> lst = new List<QuoteLine>();
                foreach (QuoteLineDetails objDetails in lstDetails)
                {
					Rebound.GlobalTrader.BLL.QuoteLine obj = new Rebound.GlobalTrader.BLL.QuoteLine();
					obj.QuoteLineId = objDetails.QuoteLineId;
					obj.QuoteNo = objDetails.QuoteNo;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.DateCode = objDetails.DateCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.Quantity = objDetails.Quantity;
					obj.Price = objDetails.Price;
					obj.ETA = objDetails.ETA;
					obj.Instructions = objDetails.Instructions;
					obj.ProductNo = objDetails.ProductNo;
					obj.ReasonNo = objDetails.ReasonNo;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.StockNo = objDetails.StockNo;
					obj.ROHS = objDetails.ROHS;
					obj.Closed = objDetails.Closed;
					obj.ServiceNo = objDetails.ServiceNo;
					obj.OriginalOfferPrice = objDetails.OriginalOfferPrice;
					obj.OriginalOfferCurrencyNo = objDetails.OriginalOfferCurrencyNo;
					obj.OriginalOfferDate = objDetails.OriginalOfferDate;
					obj.LineNotes = objDetails.LineNotes;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.QuoteNumber = objDetails.QuoteNumber;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.DateQuoted = objDetails.DateQuoted;
					obj.ReasonName = objDetails.ReasonName;
					obj.OriginalOfferCurrencyCode = objDetails.OriginalOfferCurrencyCode;
					obj.NotQuoted = objDetails.NotQuoted;
					obj.OriginalOfferSupplierNo = objDetails.OriginalOfferSupplierNo;
					obj.OriginalOfferSupplierName = objDetails.OriginalOfferSupplierName;
					obj.SourcingResultNo = objDetails.SourcingResultNo;
					obj.ClientNo = objDetails.ClientNo;
                    //[001] code start
                    obj.ProductSource = objDetails.ProductSource;
                    //[001] code end
                    obj.DutyCode = objDetails.DutyCode;
                    //[002] start
                    obj.MSL = objDetails.MSL;
                    //[002] end
                    obj.PrintHazardous = objDetails.PrintHazardous;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListOpenForQuote
		/// Calls [usp_selectAll_QuoteLine_Open_for_Quote]
		/// </summary>
        public static List<QuoteLine> GetListOpenForQuote(System.Int32? quoteId)
        {
			List<QuoteLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.QuoteLine.GetListOpenForQuote(quoteId);
            if (lstDetails == null)
            {
				return new List<QuoteLine>();
            }
            else
            {
				List<QuoteLine> lst = new List<QuoteLine>();
                foreach (QuoteLineDetails objDetails in lstDetails)
                {
					Rebound.GlobalTrader.BLL.QuoteLine obj = new Rebound.GlobalTrader.BLL.QuoteLine();
					obj.QuoteLineId = objDetails.QuoteLineId;
					obj.QuoteNo = objDetails.QuoteNo;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.DateCode = objDetails.DateCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.Quantity = objDetails.Quantity;
					obj.Price = objDetails.Price;
					obj.ETA = objDetails.ETA;
					obj.Instructions = objDetails.Instructions;
					obj.ProductNo = objDetails.ProductNo;
					obj.ReasonNo = objDetails.ReasonNo;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.StockNo = objDetails.StockNo;
					obj.ROHS = objDetails.ROHS;
					obj.Closed = objDetails.Closed;
					obj.ServiceNo = objDetails.ServiceNo;
					obj.OriginalOfferPrice = objDetails.OriginalOfferPrice;
					obj.OriginalOfferCurrencyNo = objDetails.OriginalOfferCurrencyNo;
					obj.OriginalOfferDate = objDetails.OriginalOfferDate;
					obj.LineNotes = objDetails.LineNotes;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.QuoteNumber = objDetails.QuoteNumber;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.DateQuoted = objDetails.DateQuoted;
					obj.ReasonName = objDetails.ReasonName;
					obj.OriginalOfferCurrencyCode = objDetails.OriginalOfferCurrencyCode;
					obj.NotQuoted = objDetails.NotQuoted;
					obj.OriginalOfferSupplierNo = objDetails.OriginalOfferSupplierNo;
					obj.OriginalOfferSupplierName = objDetails.OriginalOfferSupplierName;
					obj.SourcingResultNo = objDetails.SourcingResultNo;
					obj.ClientNo = objDetails.ClientNo;
                    //[001] code start
                    obj.ProductSource = objDetails.ProductSource;
                    //[001] code end
                    //[002] code start
                    obj.MSL = objDetails.MSL;
                    //[002] code end
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Source
		/// Calls [usp_source_QuoteLine]
		/// </summary>
        public static List<QuoteLine> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? maxDate, out DateTime? outDate, System.Boolean? blnReferesh, bool IsServerLocal)
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
            List<QuoteLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.QuoteLine.Source(clientId, partSearch, index, StartDate, EndDate, out outDate, IsServerLocal);
            if (lstDetails == null)
            {
				return new List<QuoteLine>();
            }
            else
            {
				List<QuoteLine> lst = new List<QuoteLine>();
                foreach (QuoteLineDetails objDetails in lstDetails)
                {
					Rebound.GlobalTrader.BLL.QuoteLine obj = new Rebound.GlobalTrader.BLL.QuoteLine();
					obj.QuoteLineId = objDetails.QuoteLineId;
					obj.QuoteNo = objDetails.QuoteNo;
					obj.QuoteNumber = objDetails.QuoteNumber;
					obj.Quantity = objDetails.Quantity;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.DateCode = objDetails.DateCode;
					obj.DateQuoted = objDetails.DateQuoted;
					obj.Price = objDetails.Price;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.PackageName = objDetails.PackageName;
					obj.ProductName = objDetails.ProductName;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.ClientNo = objDetails.ClientNo;
					obj.ClientName = objDetails.ClientName;
					obj.ClientDataVisibleToOthers = objDetails.ClientDataVisibleToOthers;
                    obj.Salesman = objDetails.Salesman;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.ClientCode = objDetails.ClientCode;
                    obj.Reason = objDetails.Reason;
                    obj.ReasonNote = objDetails.ReasonNote;
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
		/// Calls [usp_update_QuoteLine]
		/// </summary>
        public static bool Update(System.Int32? quoteLineId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.String eta, System.String instructions, System.Int32? productNo, System.String customerPart, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Byte? productSource, System.String mslLevel, System.Boolean? printHazadous)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.QuoteLine.Update(quoteLineId, part, manufacturerNo, dateCode, packageNo, quantity, price, eta, instructions, productNo, customerPart, rohs, notes, updatedBy, productSource, mslLevel, printHazadous);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_QuoteLine]
		/// </summary>
        public bool Update()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.QuoteLine.Update(QuoteLineId, Part, ManufacturerNo, DateCode, PackageNo, Quantity, Price, ETA, Instructions, ProductNo, CustomerPart, ROHS, Notes, UpdatedBy, ProductSource, MSLLevel, PrintHazardous);
		}
        //[001] code end
		/// <summary>
		/// UpdateClose
		/// Calls [usp_update_QuoteLine_Close]
		/// </summary>
        public static bool UpdateClose(System.Int32? quoteLineId, System.Int32? reasonNo, System.Int32? updatedBy, System.String reasons)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.QuoteLine.UpdateClose(quoteLineId, reasonNo, updatedBy, reasons);
		}
        /// <summary>
        /// UpdateOffer
        /// Calls [usp_update_QuoteLine_OriginalOffer]
        /// </summary>
        public static bool UpdateOffer(System.Int32? quoteLineId, System.Int32? sourcingResultNo, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.QuoteLine.UpdateOffer(quoteLineId, sourcingResultNo, updatedBy);
        }

        private static QuoteLine PopulateFromDBDetailsObject(QuoteLineDetails obj)
        {
            QuoteLine objNew = new QuoteLine();
			objNew.QuoteLineId = obj.QuoteLineId;
			objNew.QuoteNo = obj.QuoteNo;
			objNew.FullPart = obj.FullPart;
			objNew.Part = obj.Part;
			objNew.ManufacturerNo = obj.ManufacturerNo;
			objNew.DateCode = obj.DateCode;
			objNew.PackageNo = obj.PackageNo;
			objNew.Quantity = obj.Quantity;
			objNew.Price = obj.Price;
			objNew.ETA = obj.ETA;
			objNew.Instructions = obj.Instructions;
			objNew.ProductNo = obj.ProductNo;
			objNew.ReasonNo = obj.ReasonNo;
			objNew.CustomerPart = obj.CustomerPart;
			objNew.StockNo = obj.StockNo;
			objNew.ServiceNo = obj.ServiceNo;
			objNew.ROHS = obj.ROHS;
			objNew.Closed = obj.Closed;
			objNew.OriginalOfferPrice = obj.OriginalOfferPrice;
			objNew.OriginalOfferCurrencyNo = obj.OriginalOfferCurrencyNo;
			objNew.OriginalOfferDate = obj.OriginalOfferDate;
			objNew.OriginalOfferSupplierNo = obj.OriginalOfferSupplierNo;
			objNew.Notes = obj.Notes;
			objNew.FullCustomerPart = obj.FullCustomerPart;
			objNew.NotQuoted = obj.NotQuoted;
			objNew.SourcingResultNo = obj.SourcingResultNo;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.QuoteId = obj.QuoteId;
			objNew.QuoteNumber = obj.QuoteNumber;
			objNew.CurrencyCode = obj.CurrencyCode;
			objNew.DateQuoted = obj.DateQuoted;
			objNew.CompanyName = obj.CompanyName;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.ContactName = obj.ContactName;
			objNew.ContactNo = obj.ContactNo;
			objNew.RowNum = obj.RowNum;
			objNew.RowCnt = obj.RowCnt;
			objNew.LineNotes = obj.LineNotes;
			objNew.ManufacturerName = obj.ManufacturerName;
			objNew.ManufacturerCode = obj.ManufacturerCode;
			objNew.PackageName = obj.PackageName;
			objNew.PackageDescription = obj.PackageDescription;
			objNew.ProductName = obj.ProductName;
			objNew.ProductDescription = obj.ProductDescription;
			objNew.CurrencyNo = obj.CurrencyNo;
			objNew.ReasonName = obj.ReasonName;
			objNew.OriginalOfferCurrencyCode = obj.OriginalOfferCurrencyCode;
			objNew.OriginalOfferSupplierName = obj.OriginalOfferSupplierName;
			objNew.ClientNo = obj.ClientNo;
			objNew.ClientName = obj.ClientName;
			objNew.ClientDataVisibleToOthers = obj.ClientDataVisibleToOthers;
            return objNew;
        }
		
		#endregion
		
	}
}
