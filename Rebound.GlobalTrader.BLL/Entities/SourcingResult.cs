//Marker     changed by      date         Remarks
//[001]      Aashu          07/06/2018     Added supplier warranty field
//[002]      Aashu          20/06/2018     [REB-11754]: MSL level
//[003]      Aashu Singh    16/08/2018     REB-12322 : A tick box to recomond test the parts from HUB side.
//-----------------------------------------------------------------------------------------
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
    public partial class SourcingResult : BizObject
    {

        #region Properties

        protected static DAL.SourcingResultElement Settings
        {
            get { return Globals.Settings.SourcingResults; }
        }

        /// <summary>
        /// SourcingResultId
        /// </summary>
        public System.Int32 SourcingResultId { get; set; }
        /// <summary>
        /// CustomerRequirementNo
        /// </summary>
        public System.Int32 CustomerRequirementNo { get; set; }
        /// <summary>
        /// SourcingTable
        /// </summary>
        public System.String SourcingTable { get; set; }
        /// <summary>
        /// SourcingTableItemNo
        /// </summary>
        public System.Int32? SourcingTableItemNo { get; set; }
        /// <summary>
        /// TypeName
        /// </summary>
        public System.String TypeName { get; set; }
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
        /// ProductNo
        /// </summary>
        public System.Int32? ProductNo { get; set; }
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
        public System.Int32 CurrencyNo { get; set; }
        /// <summary>
        /// OriginalEntryDate
        /// </summary>
        public System.DateTime? OriginalEntryDate { get; set; }
        /// <summary>
        /// Salesman
        /// </summary>
        public System.Int32 Salesman { get; set; }
        /// <summary>
        /// SupplierNo
        /// </summary>
        public System.Int32? SupplierNo { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime DLUP { get; set; }
        /// <summary>
        /// ROHS
        /// </summary>
        public System.Byte? ROHS { get; set; }
        /// <summary>
        /// OfferStatusNo
        /// </summary>
        public System.Int32? OfferStatusNo { get; set; }
        /// <summary>
        /// OfferStatusChangeDate
        /// </summary>
        public System.DateTime? OfferStatusChangeDate { get; set; }
        /// <summary>
        /// OfferStatusChangeLoginNo
        /// </summary>
        public System.Int32? OfferStatusChangeLoginNo { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public System.String Notes { get; set; }
        /// <summary>
        /// CurrencyCode
        /// </summary>
        public System.String CurrencyCode { get; set; }
        /// <summary>
        /// CustomerRequirementId
        /// </summary>
        public System.Int32? CustomerRequirementId { get; set; }
        /// <summary>
        /// CustomerRequirementNumber
        /// </summary>
        public System.Int32? CustomerRequirementNumber { get; set; }
        /// <summary>
        /// ClientNo
        /// </summary>
        public System.Int32? ClientNo { get; set; }
        /// <summary>
        /// CompanyNo
        /// </summary>
        public System.Int32? CompanyNo { get; set; }
        /// <summary>
        /// CompanyName
        /// </summary>
        public System.String CompanyName { get; set; }
        /// <summary>
        /// SupplierName
        /// </summary>
        public System.String SupplierName { get; set; }
        /// <summary>
        /// ManufacturerCode
        /// </summary>
        public System.String ManufacturerCode { get; set; }
        /// <summary>
        /// ProductName
        /// </summary>
        public System.String ProductName { get; set; }
        /// <summary>
        /// PackageName
        /// </summary>
        public System.String PackageName { get; set; }
        /// <summary>
        /// OfferStatusChangeEmployeeName
        /// </summary>
        public System.String OfferStatusChangeEmployeeName { get; set; }
        /// <summary>
        /// RowNum
        /// </summary>
        public System.Int64? RowNum { get; set; }
        /// <summary>
        /// RowCnt
        /// </summary>
        public System.Int32? RowCnt { get; set; }
        /// <summary>
        /// ManufacturerName
        /// </summary>
        public System.String ManufacturerName { get; set; }
        /// <summary>
        /// CustomerPart
        /// </summary>
        public System.String CustomerPart { get; set; }
        /// <summary>
        /// ProductDescription
        /// </summary>
        public System.String ProductDescription { get; set; }
        /// <summary>
        /// PackageDescription
        /// </summary>
        public System.String PackageDescription { get; set; }
        /// <summary>
        /// SalesmanName
        /// </summary>
        public System.String SalesmanName { get; set; }
        public System.Double? SupplierPrice { get; set; }
        public System.String POHubSupplierName { get; set; }
        public System.Int32? POHubCompanyNo { get; set; }
        public System.String IsPoHub { get; set; }
        public System.Int32? POHubReleaseBy { get; set; }

        public System.String ClientSupplierName { get; set; }
        public System.Int32? ClientCompanyNo { get; set; }
        /// <summary>
        /// UPLiftPrice
        /// </summary>
        public System.Double? UPLiftPrice { get; set; }
        public System.Int32 ClientCurrencyNo { get; set; }
        public System.String ClientCurrencyCode { get; set; }
        public System.Double? ConvertedSourcingPrice { get; set; }
        public System.String MslSpqFactorySealed { get; set; }
        public double? EstimatedShippingCost { get; set; }
        public double? ActualPrice { get; set; }
        public double? SupplierPercentage { get; set; }

        public string SupplierManufacturerName { get; set; }
        public string SupplierDateCode { get; set; }
        public string SupplierPackageType { get; set; }
        public string SupplierProductType { get; set; }
        public string SupplierMOQ { get; set; }
        public string SupplierTotalQSA { get; set; }
        public string SupplierLTB { get; set; }
        public string SupplierNotes { get; set; }
        public string SupplierType { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public System.Boolean? SourcingRelease { get; set; }
        public bool IsClosed { get; set; }
        public string SPQ { get; set; }
        public string LeadTime { get; set; }
        public string ROHSStatus { get; set; }
        public string FactorySealed { get; set; }
        public string MSL { get; set; }
        public string RegionName { get; set; }
        public System.Int32? RegionNo { get; set; }

        public string HubRFQName { get; set; }
        public System.Int32? HubRFQNo { get; set; }
        public bool IsSoCreated { get; set; }
        public string TermsName { get; set; }
        public bool IsApplyPOBankFee { get; set; }
        public string SourceRef { get; set; }
        public bool IsReleased { get; set; }
        public bool Recalled { get; set; }
        public string SourcingNotes { get; set; }
        public double? OriginalPrice { get; set; }
        public System.Int32? ActualCurrencyNo { get; set; }
        public System.String ActualCurrencyCode { get; set; }
        public System.Int32 SourcingReleasedCount { get; set; }
        public System.Int32?  MSLLevelNo { get; set; }
        public System.String MSLLevelText { get; set; }
        
        //[001] start
        /// <summary>
        /// SupplierWarranty
        /// </summary>
        public System.Int32? SupplierWarranty { get; set; }
        /// <summary>
        /// NonPreferredCompany
        /// </summary>
        public System.Boolean? NonPreferredCompany { get; set; }
        //[001] end
        //[003] start
        public System.Boolean IsTestingRecommended { get; set; }
        //[003] end
        public System.Boolean? IsImageAvailable { get; set; }
        #endregion

        #region Methods

        /// <summary>
        /// Delete
        /// Calls [usp_delete_SourcingResult]
        /// </summary>
        public static bool Delete(System.Int32? sourcingResultId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.Delete(sourcingResultId);
        }
        /// <summary>
        /// Insert
        /// Calls [usp_insert_SourcingResult]
        /// </summary>
        public static Int32 Insert(System.Int32? customerRequirementNo, System.String typeName, System.String notes, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? offerStatusNo, System.Int32? supplierNo, System.Byte? rohs, System.Int32? clientNo, System.Int32? updatedBy,System.Int32? mslLevelNo)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.Insert(customerRequirementNo, typeName, notes, part, manufacturerNo, dateCode, productNo, packageNo, quantity, price, currencyNo, originalEntryDate, salesman, offerStatusNo, supplierNo, rohs, clientNo, updatedBy,mslLevelNo);
            return objReturn;
        }
        /// <summary>
        /// Insert (without parameters)
        /// Calls [usp_insert_SourcingResult]
        /// </summary>
        public Int32 Insert()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.Insert(CustomerRequirementNo, TypeName, Notes, Part, ManufacturerNo, DateCode, ProductNo, PackageNo, Quantity, Price, CurrencyNo, OriginalEntryDate, Salesman, OfferStatusNo, SupplierNo, ROHS, ClientNo, UpdatedBy, null);
        }
        /// <summary>
        /// InsertFromHistory
        /// Calls [usp_insert_SourcingResult_From_History]
        /// </summary>
        public static Int32 InsertFromHistory(System.Int32? customerRequirementNo, System.Int32? historyNo, System.Int32? clientNo, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.InsertFromHistory(customerRequirementNo, historyNo, clientNo, updatedBy);
            return objReturn;
        }
        /// <summary>
        /// InsertFromOffer
        /// Calls [usp_insert_SourcingResult_From_Offer]
        /// </summary>
        public static Int32 InsertFromOffer(System.Int32? customerRequirementNo, System.Int32? offerNo, System.Int32? updatedBy, System.Boolean isPOHub)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.InsertFromOffer(customerRequirementNo, offerNo, updatedBy, isPOHub);
            return objReturn;
        }
        /// <summary>
        /// InsertFromTrusted
        /// Calls [usp_insert_SourcingResult_From_Trusted]
        /// </summary>
        public static Int32 InsertFromTrusted(System.Int32? customerRequirementNo, System.Int32? excessNo, System.Int32? updatedBy, System.Boolean isPOHub)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.InsertFromTrusted(customerRequirementNo, excessNo, updatedBy, isPOHub);
            return objReturn;
        }
        /// <summary>
        /// Release 
        /// Calls [usp_update_Sourcing_Release]
        /// </summary>
        public static bool ReleaseSourcing(System.Int32? sourcingResultID, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.ReleaseSourcing(sourcingResultID, updatedBy);
        }

        /// <summary>
        /// InsertFromPurchaseQuote
        /// Calls [[usp_insert_SourcingResult_From_PurchaseRequest]]
        /// </summary>
        public static Int32 InsertFromPOQuote(System.Int32? customerRequirementNo, System.Int32? poQuoteLineNo, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.InsertFromPOQuote(customerRequirementNo, poQuoteLineNo, updatedBy);
            return objReturn;
        }
        /// <summary>
        /// ItemSearch
        /// Calls [usp_itemsearch_SourcingResult]
        /// </summary>
        public static List<SourcingResult> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Int32? customerRequirementNoLo, System.Int32? customerRequirementNoHi, System.String supplierSearch, System.Boolean? isPoHub, System.Int32? intQuoteID, System.String bom)
        {
            List<SourcingResultDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, partSearch, cmSearch, customerRequirementNoLo, customerRequirementNoHi, supplierSearch, isPoHub, intQuoteID, bom);
            if (lstDetails == null)
            {
                return new List<SourcingResult>();
            }
            else
            {
                List<SourcingResult> lst = new List<SourcingResult>();
                foreach (SourcingResultDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SourcingResult obj = new Rebound.GlobalTrader.BLL.SourcingResult();
                    obj.SourcingResultId = objDetails.SourcingResultId;
                    obj.Part = objDetails.Part;
                    obj.Price = objDetails.Price;
                    obj.Quantity = objDetails.Quantity;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CustomerRequirementId = objDetails.CustomerRequirementId;
                    obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.SupplierNo = objDetails.SupplierNo;
                    obj.SupplierName = objDetails.SupplierName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.ProductName = objDetails.ProductName;
                    obj.PackageName = objDetails.PackageName;
                    obj.OfferStatusChangeDate = objDetails.OfferStatusChangeDate;
                    obj.OfferStatusChangeEmployeeName = objDetails.OfferStatusChangeEmployeeName;
                    obj.DateCode = objDetails.DateCode;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.IsPoHub = objDetails.IsPoHub;
                    obj.ClientCompanyNo = objDetails.ClientCompanyNo;
                    obj.ClientSupplierName = objDetails.ClientSupplierName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Get
        /// Calls [usp_select_SourcingResult]
        /// </summary>
        public static SourcingResult Get(System.Int32? sourcingResultId)
        {
            Rebound.GlobalTrader.DAL.SourcingResultDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.Get(sourcingResultId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SourcingResult obj = new SourcingResult();
                obj.SourcingResultId = objDetails.SourcingResultId;
                obj.CustomerRequirementNo = objDetails.CustomerRequirementNo;
                obj.SourcingTable = objDetails.SourcingTable;
                obj.SourcingTableItemNo = objDetails.SourcingTableItemNo;
                obj.TypeName = objDetails.TypeName;
                obj.FullPart = objDetails.FullPart;
                obj.Part = objDetails.Part;
                obj.ManufacturerNo = objDetails.ManufacturerNo;
                obj.DateCode = objDetails.DateCode;
                obj.ProductNo = objDetails.ProductNo;
                obj.PackageNo = objDetails.PackageNo;
                obj.Quantity = objDetails.Quantity;
                obj.Price = objDetails.Price;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.OriginalEntryDate = objDetails.OriginalEntryDate;
                obj.Salesman = objDetails.Salesman;
                obj.SupplierNo = objDetails.SupplierNo;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.ROHS = objDetails.ROHS;
                obj.OfferStatusNo = objDetails.OfferStatusNo;
                obj.OfferStatusChangeDate = objDetails.OfferStatusChangeDate;
                obj.OfferStatusChangeLoginNo = objDetails.OfferStatusChangeLoginNo;
                obj.Notes = objDetails.Notes;
                obj.SupplierName = objDetails.SupplierName;
                obj.ManufacturerName = objDetails.ManufacturerName;
                obj.ManufacturerCode = objDetails.ManufacturerCode;
                obj.CustomerPart = objDetails.CustomerPart;
                obj.SupplierPrice = objDetails.SupplierPrice;
                obj.POHubSupplierName = objDetails.POHubSupplierName;
                obj.POHubCompanyNo = objDetails.POHubCompanyNo;
                obj.UPLiftPrice = objDetails.UPLiftPrice;
                obj.ClientCompanyNo = objDetails.ClientCompanyNo;
                obj.ClientSupplierName = objDetails.ClientSupplierName;
                obj.EstimatedShippingCost = objDetails.EstimatedShippingCost;
                obj.ClientCurrencyNo = objDetails.ClientCurrencyNo;
                obj.ClientCurrencyCode = objDetails.ClientCurrencyCode;
                obj.ActualPrice = objDetails.ActualPrice;
                obj.SupplierPercentage = objDetails.SupplierPercentage;
                obj.DeliveryDate = objDetails.DeliveryDate;

                obj.SPQ = objDetails.SPQ;
                obj.LeadTime = objDetails.LeadTime;
                obj.ROHSStatus = objDetails.ROHSStatus;
                obj.FactorySealed = objDetails.FactorySealed;
                obj.MSL = objDetails.MSL;
                obj.SupplierMOQ = objDetails.SupplierMOQ;
                obj.SupplierTotalQSA = objDetails.SupplierTotalQSA;
                obj.SupplierLTB = objDetails.SupplierLTB;                
                obj.SupplierNotes = objDetails.SupplierNotes;
                obj.ClientNo = objDetails.ClientNo;
                obj.RegionNo = objDetails.RegionNo;
                obj.SourcingNotes = objDetails.SourcingNotes;

                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.ActualCurrencyCode = objDetails.ActualCurrencyCode;
                obj.ActualCurrencyNo = objDetails.ActualCurrencyNo;
                obj.OriginalPrice = objDetails.OriginalPrice;
                obj.ProductDescription = objDetails.ProductDescription;
                obj.ProductInactive = objDetails.ProductInactive;
                //[001] start
                obj.SupplierWarranty = objDetails.SupplierWarranty;
                obj.NonPreferredCompany = objDetails.NonPreferredCompany;
                //[001] end
                obj.MSLLevelNo = objDetails.MSLLevelNo;
                obj.MSLLevelText = objDetails.MSLLevelText;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetListForCustomerRequirement
        /// Calls [usp_selectAll_SourcingResult_for_CustomerRequirement]
        /// </summary>
        public static List<SourcingResult> GetListForCustomerRequirement(System.Int32? customerRequirementId)
        {
            List<SourcingResultDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.GetListForCustomerRequirement(customerRequirementId);
            if (lstDetails == null)
            {
                return new List<SourcingResult>();
            }
            else
            {
                List<SourcingResult> lst = new List<SourcingResult>();
                foreach (SourcingResultDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SourcingResult obj = new Rebound.GlobalTrader.BLL.SourcingResult();
                    obj.SourcingResultId = objDetails.SourcingResultId;
                    obj.CustomerRequirementNo = objDetails.CustomerRequirementNo;
                    obj.SourcingTable = objDetails.SourcingTable;
                    obj.SourcingTableItemNo = objDetails.SourcingTableItemNo;
                    obj.TypeName = objDetails.TypeName;
                    obj.FullPart = objDetails.FullPart;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.DateCode = objDetails.DateCode;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.OriginalEntryDate = objDetails.OriginalEntryDate;
                    obj.Salesman = objDetails.Salesman;
                    obj.SupplierNo = objDetails.SupplierNo;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.ROHS = objDetails.ROHS;
                    obj.OfferStatusNo = objDetails.OfferStatusNo;
                    obj.OfferStatusChangeDate = objDetails.OfferStatusChangeDate;
                    obj.OfferStatusChangeLoginNo = objDetails.OfferStatusChangeLoginNo;
                    obj.Notes = objDetails.Notes;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.SupplierName = objDetails.SupplierName;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.OfferStatusChangeEmployeeName = objDetails.OfferStatusChangeEmployeeName;
                    obj.POHubCompanyNo = objDetails.POHubCompanyNo;
                    obj.POHubSupplierName = objDetails.POHubSupplierName;
                    obj.POHubReleaseBy = objDetails.POHubReleaseBy;
                    obj.ClientCompanyNo = objDetails.ClientCompanyNo;
                    obj.ClientSupplierName = objDetails.ClientSupplierName;
                    obj.ClientCurrencyNo = objDetails.ClientCurrencyNo;
                    obj.IsSoCreated = objDetails.IsSoCreated;
                    obj.IsClosed = objDetails.IsClosed;
                    obj.RegionName = objDetails.RegionName;
                    obj.EstimatedShippingCost = objDetails.EstimatedShippingCost;
                    obj.TermsName = objDetails.TermsName;
                    obj.SupplierType = objDetails.SupplierType;
                    obj.MSL = objDetails.MSL;

                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// GetListForCustomerRequirement
        /// Calls [usp_select_SourcingResult_for_CustomerRequirement]
        /// </summary>
        public static List<SourcingResult> GetListForCustomerRequirementCopy(System.Int32? customerRequirementId)
        {
            List<SourcingResultDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.GetListForCustomerRequirementCopy(customerRequirementId);
            if (lstDetails == null)
            {
                return new List<SourcingResult>();
            }
            else
            {
                List<SourcingResult> lst = new List<SourcingResult>();
                foreach (SourcingResultDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SourcingResult obj = new Rebound.GlobalTrader.BLL.SourcingResult();
                    obj.SourcingResultId = objDetails.SourcingResultId;
                    obj.CustomerRequirementNo = objDetails.CustomerRequirementNo;
                    obj.SourcingTable = objDetails.SourcingTable;
                    obj.SourcingTableItemNo = objDetails.SourcingTableItemNo;
                    obj.TypeName = objDetails.TypeName;
                    obj.FullPart = objDetails.FullPart;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.DateCode = objDetails.DateCode;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.OriginalEntryDate = objDetails.OriginalEntryDate;
                    obj.Salesman = objDetails.Salesman;
                    obj.SupplierNo = objDetails.SupplierNo;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.ROHS = objDetails.ROHS;
                    obj.OfferStatusNo = objDetails.OfferStatusNo;
                    obj.OfferStatusChangeDate = objDetails.OfferStatusChangeDate;
                    obj.OfferStatusChangeLoginNo = objDetails.OfferStatusChangeLoginNo;
                    obj.Notes = objDetails.Notes;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.SupplierName = objDetails.SupplierName;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.OfferStatusChangeEmployeeName = objDetails.OfferStatusChangeEmployeeName;
                    obj.POHubCompanyNo = objDetails.POHubCompanyNo;
                    obj.POHubSupplierName = objDetails.POHubSupplierName;
                    obj.POHubReleaseBy = objDetails.POHubReleaseBy;
                    obj.ClientCompanyNo = objDetails.ClientCompanyNo;
                    obj.ClientSupplierName = objDetails.ClientSupplierName;
                    obj.ClientCurrencyNo = objDetails.ClientCurrencyNo;
                    obj.IsSoCreated = objDetails.IsSoCreated;
                    obj.IsClosed = objDetails.IsClosed;
                    obj.RegionName = objDetails.RegionName;
                    obj.EstimatedShippingCost = objDetails.EstimatedShippingCost;
                    obj.TermsName = objDetails.TermsName;
                    obj.SupplierType = objDetails.SupplierType;

                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// GetListForCustomerRequirement
        /// Calls [usp_SourcingResult_for_CustomerRequirement]
        /// </summary>
        public static List<SourcingResult> GetListForSourcing(System.Int32? customerRequirementId,System.Boolean? isFromQuote)
        {
            List<SourcingResultDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.GetListForSourcing(customerRequirementId, isFromQuote);
            if (lstDetails == null)
            {
                return new List<SourcingResult>();
            }
            else
            {
                List<SourcingResult> lst = new List<SourcingResult>();
                foreach (SourcingResultDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SourcingResult obj = new Rebound.GlobalTrader.BLL.SourcingResult();
                    obj.SourcingResultId = objDetails.SourcingResultId;
                    obj.CustomerRequirementNo = objDetails.CustomerRequirementNo;
                    obj.SourcingTable = objDetails.SourcingTable;
                    obj.SourcingTableItemNo = objDetails.SourcingTableItemNo;
                    obj.TypeName = objDetails.TypeName;
                    obj.FullPart = objDetails.FullPart;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.DateCode = objDetails.DateCode;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.OriginalEntryDate = objDetails.OriginalEntryDate;
                    obj.Salesman = objDetails.Salesman;
                    obj.SupplierNo = objDetails.SupplierNo;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.ROHS = objDetails.ROHS;
                    obj.OfferStatusNo = objDetails.OfferStatusNo;
                    obj.OfferStatusChangeDate = objDetails.OfferStatusChangeDate;
                    obj.OfferStatusChangeLoginNo = objDetails.OfferStatusChangeLoginNo;
                    obj.Notes = objDetails.Notes;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.SupplierName = objDetails.SupplierName;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.OfferStatusChangeEmployeeName = objDetails.OfferStatusChangeEmployeeName;
                    obj.POHubCompanyNo = objDetails.POHubCompanyNo;
                    obj.POHubSupplierName = objDetails.POHubSupplierName;
                    obj.POHubReleaseBy = objDetails.POHubReleaseBy;
                    obj.ClientCompanyNo = objDetails.ClientCompanyNo;
                    obj.ClientSupplierName = objDetails.ClientSupplierName;
                    obj.ClientCurrencyNo = objDetails.ClientCurrencyNo;
                    obj.IsReleased = objDetails.IsReleased;
                    obj.Recalled = objDetails.Recalled;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
     

        /// <summary>
        /// GetListForQuoteLine
        /// Calls [usp_selectAll_SourcingResult_for_QuoteLine]
        /// </summary>
        public static List<SourcingResult> GetListForQuoteLine(System.Int32? quoteLineId)
        {
            List<SourcingResultDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.GetListForQuoteLine(quoteLineId);
            if (lstDetails == null)
            {
                return new List<SourcingResult>();
            }
            else
            {
                List<SourcingResult> lst = new List<SourcingResult>();
                foreach (SourcingResultDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SourcingResult obj = new Rebound.GlobalTrader.BLL.SourcingResult();
                    obj.SourcingResultId = objDetails.SourcingResultId;
                    obj.CustomerRequirementNo = objDetails.CustomerRequirementNo;
                    obj.CustomerRequirementNumber = objDetails.CustomerRequirementNumber;
                    obj.SourcingTable = objDetails.SourcingTable;
                    obj.SourcingTableItemNo = objDetails.SourcingTableItemNo;
                    obj.TypeName = objDetails.TypeName;
                    obj.FullPart = objDetails.FullPart;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.DateCode = objDetails.DateCode;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.OriginalEntryDate = objDetails.OriginalEntryDate;
                    obj.Salesman = objDetails.Salesman;
                    obj.SupplierNo = objDetails.SupplierNo;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.ROHS = objDetails.ROHS;
                    obj.OfferStatusNo = objDetails.OfferStatusNo;
                    obj.OfferStatusChangeDate = objDetails.OfferStatusChangeDate;
                    obj.OfferStatusChangeLoginNo = objDetails.OfferStatusChangeLoginNo;
                    obj.Notes = objDetails.Notes;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.SupplierName = objDetails.SupplierName;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.OfferStatusChangeEmployeeName = objDetails.OfferStatusChangeEmployeeName;
                    obj.POHubCompanyNo = objDetails.POHubCompanyNo;
                    obj.POHubSupplierName = objDetails.POHubSupplierName;
                    obj.POHubReleaseBy = objDetails.POHubReleaseBy;
                    obj.ClientCompanyNo = objDetails.ClientCompanyNo;
                    obj.ClientSupplierName = objDetails.ClientSupplierName;
                    obj.ClientCurrencyNo = objDetails.ClientCurrencyNo;
                    obj.ClientCurrencyCode = objDetails.ClientCurrencyCode;
                    obj.ConvertedSourcingPrice = objDetails.ConvertedSourcingPrice;
                    obj.SupplierType = objDetails.SupplierType;
                    obj.DeliveryDate = objDetails.DeliveryDate;
                    obj.EstimatedShippingCost = objDetails.EstimatedShippingCost;
                    obj.RegionName = objDetails.RegionName;
                    obj.HubRFQName = objDetails.HubRFQName;
                    obj.HubRFQNo = objDetails.HubRFQNo;
                    obj.TermsName = objDetails.TermsName;
                    obj.IsApplyPOBankFee = objDetails.IsApplyPOBankFee;

                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Update
        /// Calls [usp_update_SourcingResult]
        /// </summary>
        public static bool Update(System.Int32? sourcingResultId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.Int32? offerStatusNo, System.Int32? supplierNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy,System.Int32? mslLevelNo)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.Update(sourcingResultId, part, manufacturerNo, dateCode, productNo, packageNo, quantity, price, currencyNo, offerStatusNo, supplierNo, rohs, notes, updatedBy,mslLevelNo);
        }
        /// <summary>
        /// Update
        /// Calls [usp_update_POHubSourcingResult]
        /// </summary>
        //[003] start
        public static bool UpdatePOHub(System.Int32? sourcingResultId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.Int32? offerStatusNo, System.Int32? supplierNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Double? suplierPrice, double? estimatedShippingCost, DateTime? deliveryDate, bool IsPoHub, System.String SPQ, System.String leadTime, System.String rohsStatus, System.String factorySealed, System.String MSL, System.String supplierTotalQSA, System.String supplierMOQ, System.String supplierLTB, System.Int32? regionNo, System.Int32? hubcurrencyNo, System.Int32? linkMultiCurrencyNo, System.Int32? mslLevelNo, System.Int32? supplierWarranty,System.Boolean? isTestingRecommended)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.UpdatePOHub(sourcingResultId, part, manufacturerNo, dateCode, productNo, packageNo, quantity, price, currencyNo, offerStatusNo, supplierNo, rohs, notes, updatedBy, suplierPrice, estimatedShippingCost, deliveryDate, IsPoHub, SPQ, leadTime, rohsStatus, factorySealed, MSL, supplierTotalQSA, supplierMOQ, supplierLTB, regionNo, hubcurrencyNo, linkMultiCurrencyNo, mslLevelNo, supplierWarranty,isTestingRecommended);
        }
        //[001] end
        /// <summary>
        /// Update (without parameters)
        /// Calls [usp_update_SourcingResult]
        /// </summary>
        public bool Update()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.Update(SourcingResultId, Part, ManufacturerNo, DateCode, ProductNo, PackageNo, Quantity, Price, CurrencyNo, OfferStatusNo, SupplierNo, ROHS, Notes, UpdatedBy,null);
        }

        /// <summary>
        /// GetListForBOMCustomerRequirement
        /// Calls [usp_selectAll_SourcingResult_for_BOMCustomerRequirement]
        /// </summary>
        public static List<SourcingResult> GetListForBOMCustomerRequirement(System.Int32? customerRequirementId, System.Boolean isPOHub)
        {
            List<SourcingResultDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.GetListForBOMCustomerRequirement(customerRequirementId, isPOHub);
            if (lstDetails == null)
            {
                return new List<SourcingResult>();
            }
            else
            {
                List<SourcingResult> lst = new List<SourcingResult>();
                foreach (SourcingResultDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SourcingResult obj = new Rebound.GlobalTrader.BLL.SourcingResult();
                    obj.SourcingResultId = objDetails.SourcingResultId;
                    obj.CustomerRequirementNo = objDetails.CustomerRequirementNo;
                    obj.SourcingTable = objDetails.SourcingTable;
                    obj.SourcingTableItemNo = objDetails.SourcingTableItemNo;
                    obj.TypeName = objDetails.TypeName;
                    obj.FullPart = objDetails.FullPart;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.DateCode = objDetails.DateCode;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.OriginalEntryDate = objDetails.OriginalEntryDate;
                    obj.Salesman = objDetails.Salesman;
                    obj.SupplierNo = objDetails.SupplierNo;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.ROHS = objDetails.ROHS;
                    obj.OfferStatusNo = objDetails.OfferStatusNo;
                    obj.OfferStatusChangeDate = objDetails.OfferStatusChangeDate;
                    obj.OfferStatusChangeLoginNo = objDetails.OfferStatusChangeLoginNo;
                    obj.Notes = objDetails.Notes;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.SupplierName = objDetails.SupplierName;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.OfferStatusChangeEmployeeName = objDetails.OfferStatusChangeEmployeeName;
                    obj.SupplierPrice = objDetails.SupplierPrice;
                    obj.POHubCompanyNo = objDetails.POHubCompanyNo;
                    obj.POHubSupplierName = objDetails.POHubSupplierName;
                    obj.POHubReleaseBy = objDetails.POHubReleaseBy;
                    obj.ClientCompanyNo = objDetails.ClientCompanyNo;
                    obj.ClientSupplierName = objDetails.ClientSupplierName;
                    obj.UPLiftPrice = objDetails.UPLiftPrice;
                    obj.ClientCurrencyNo = objDetails.ClientCurrencyNo;
                    obj.ClientCurrencyCode = objDetails.ClientCurrencyCode;
                    obj.ConvertedSourcingPrice = objDetails.ConvertedSourcingPrice;
                    obj.MslSpqFactorySealed = objDetails.MslSpqFactorySealed;
                    obj.EstimatedShippingCost = objDetails.EstimatedShippingCost;

                    obj.SupplierType = objDetails.SupplierType;
                    obj.DeliveryDate = objDetails.DeliveryDate;


                    obj.ActualPrice = objDetails.ActualPrice;
                    obj.SupplierPercentage = objDetails.SupplierPercentage;

                    obj.SupplierManufacturerName = objDetails.SupplierManufacturerName;
                    obj.SupplierDateCode = objDetails.SupplierDateCode;
                    obj.SupplierPackageType = objDetails.SupplierPackageType;
                    obj.SupplierProductType = objDetails.SupplierProductType;
                    obj.SupplierMOQ = objDetails.SupplierMOQ;
                    obj.SupplierTotalQSA = objDetails.SupplierTotalQSA;
                    obj.SupplierLTB = objDetails.SupplierLTB;
                    obj.SupplierNotes = objDetails.SupplierNotes;
                    obj.SourcingRelease = objDetails.SourcingRelease;
                    obj.SPQ = objDetails.SPQ;
                    obj.LeadTime = objDetails.LeadTime;
                    obj.ROHSStatus = objDetails.ROHSStatus;
                    obj.FactorySealed = objDetails.FactorySealed;
                    obj.MSL = objDetails.MSL;
                    obj.IsClosed = objDetails.IsClosed;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.RegionName = objDetails.RegionName;
                    obj.IsClosed = objDetails.IsClosed;
                    obj.IsSoCreated = objDetails.IsSoCreated;
                    obj.TermsName = objDetails.TermsName;
                    obj.IsApplyPOBankFee = objDetails.IsApplyPOBankFee;
                    obj.SourceRef = objDetails.SourceRef;

                    obj.OriginalPrice = objDetails.OriginalPrice;
                    obj.ActualCurrencyNo = objDetails.ActualCurrencyNo;
                    obj.ActualCurrencyCode = objDetails.ActualCurrencyCode;

                    obj.SourcingReleasedCount = objDetails.SourcingReleasedCount;
                    //[001] start
                    //obj.NonPreferredCompany = objDetails.NonPreferredCompany;
                    obj.SupplierWarranty = objDetails.SupplierWarranty;
                    //[001] end
                    obj.MSLLevelNo = objDetails.MSLLevelNo;
                    obj.MSLLevelText = objDetails.MSLLevelText;
                    //[003] start
                    obj.IsTestingRecommended = objDetails.IsTestingRecommended;
                    //[003] end
                    obj.IsImageAvailable = objDetails.IsImageAvailable;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// ConvertPriceToDifferentCurrency
        /// Calls [usp_Convert_Price_To_Different_Currency]
        /// </summary>
        public static SourcingResult ConvertPriceToDifferentCurrency(System.Int32? intFromCurrency, System.Int32? intToCurrency, System.Double? upliftPrice, System.Double? hubBuyPrice, System.Int32? sourcingResultNo)
        {
            Rebound.GlobalTrader.DAL.SourcingResultDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.ConvertPriceToDifferentCurrency(intFromCurrency, intToCurrency, upliftPrice, hubBuyPrice,sourcingResultNo);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SourcingResult obj = new SourcingResult();
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.UPLiftPrice = objDetails.UPLiftPrice;
                obj.SupplierPrice = objDetails.SupplierPrice;
                obj.EstimatedShippingCost = objDetails.EstimatedShippingCost;
                obj.SupplierPercentage = objDetails.SupplierPercentage;
                objDetails = null;
                return obj;
            }
        }

        private static SourcingResult PopulateFromDBDetailsObject(SourcingResultDetails obj)
        {
            SourcingResult objNew = new SourcingResult();
            objNew.SourcingResultId = obj.SourcingResultId;
            objNew.CustomerRequirementNo = obj.CustomerRequirementNo;
            objNew.SourcingTable = obj.SourcingTable;
            objNew.SourcingTableItemNo = obj.SourcingTableItemNo;
            objNew.TypeName = obj.TypeName;
            objNew.FullPart = obj.FullPart;
            objNew.Part = obj.Part;
            objNew.ManufacturerNo = obj.ManufacturerNo;
            objNew.DateCode = obj.DateCode;
            objNew.ProductNo = obj.ProductNo;
            objNew.PackageNo = obj.PackageNo;
            objNew.Quantity = obj.Quantity;
            objNew.Price = obj.Price;
            objNew.CurrencyNo = obj.CurrencyNo;
            objNew.OriginalEntryDate = obj.OriginalEntryDate;
            objNew.Salesman = obj.Salesman;
            objNew.SupplierNo = obj.SupplierNo;
            objNew.UpdatedBy = obj.UpdatedBy;
            objNew.DLUP = obj.DLUP;
            objNew.ROHS = obj.ROHS;
            objNew.OfferStatusNo = obj.OfferStatusNo;
            objNew.OfferStatusChangeDate = obj.OfferStatusChangeDate;
            objNew.OfferStatusChangeLoginNo = obj.OfferStatusChangeLoginNo;
            objNew.Notes = obj.Notes;
            objNew.CurrencyCode = obj.CurrencyCode;
            objNew.CustomerRequirementId = obj.CustomerRequirementId;
            objNew.CustomerRequirementNumber = obj.CustomerRequirementNumber;
            objNew.ClientNo = obj.ClientNo;
            objNew.CompanyNo = obj.CompanyNo;
            objNew.CompanyName = obj.CompanyName;
            objNew.SupplierName = obj.SupplierName;
            objNew.ManufacturerCode = obj.ManufacturerCode;
            objNew.ProductName = obj.ProductName;
            objNew.PackageName = obj.PackageName;
            objNew.OfferStatusChangeEmployeeName = obj.OfferStatusChangeEmployeeName;
            objNew.RowNum = obj.RowNum;
            objNew.RowCnt = obj.RowCnt;
            objNew.ManufacturerName = obj.ManufacturerName;
            objNew.CustomerPart = obj.CustomerPart;
            objNew.ProductDescription = obj.ProductDescription;
            objNew.PackageDescription = obj.PackageDescription;
            objNew.SalesmanName = obj.SalesmanName;
            return objNew;
        }


        /// <summary>
        /// Insert
        /// Calls [usp_insert_SourcingResult]
        /// </summary>
        //[001],[003] start
        public static Int32 InsertSourcingResult(System.Int32? customerRequirementNo, System.String typeName, System.String notes, System.String part
          ,System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity,
           System.Double? price,  System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? offerStatusNo,
           System.Int32? supplierNo, System.Byte? rohs, System.Int32? clientNo, System.Int32? updatedBy, System.Double? suplierPrice,
           double? estimatedShippingCost, DateTime? deliveryDate, bool isPoHub, System.String SPQ, System.String leadTime, System.String rohsStatus,
           System.String factorySealed, System.String MSL, System.String supplierTotalQSA, System.String supplierMOQ, System.String supplierLTB,
           System.Int32? regionNo, System.Int32? hubcurrencyNo, System.Int32? mslLevel, System.Int32? supplierWarranty,System.Boolean? isTestingRecommended)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SourcingResult.InsertSourcingResult(customerRequirementNo, typeName, notes, part, manufacturerNo, dateCode,
                              productNo, packageNo, quantity, price,  originalEntryDate, salesman, offerStatusNo, supplierNo, rohs, clientNo, updatedBy,
                              suplierPrice, estimatedShippingCost, deliveryDate, isPoHub, SPQ, leadTime, rohsStatus, factorySealed, MSL, supplierTotalQSA, supplierMOQ,
                              supplierLTB, regionNo, hubcurrencyNo, mslLevel, supplierWarranty,isTestingRecommended);
            return objReturn;

        }

        #endregion

    }
}
