//Marker     Changed by      Date         Remarks
//[001]      Aashu Singh     25/06/2018   Show supplier warranty for ipo line detail
//[002]      Aashu Singh     29/06/2018   Save MSL detail.

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
   public class InternalPurchaseOrderLine: BizObject {
       #region Properties

       protected static DAL.InternalPurchaseOrderLineElement Settings
       {
           get { return Globals.Settings.InternalPurchaseOrderLines; }
       }

       /// <summary>
       /// PurchaseOrderLineId
       /// </summary>
       public System.Int32 PurchaseOrderLineId { get; set; }
       /// <summary>
       /// PurchaseOrderNo
       /// </summary>
       public System.Int32 PurchaseOrderNo { get; set; }
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
       /// DeliveryDate
       /// </summary>
       public System.DateTime DeliveryDate { get; set; }
       /// <summary>
       /// ReceivingNotes
       /// </summary>
       public System.String ReceivingNotes { get; set; }
       /// <summary>
       /// Taxable
       /// </summary>
       public System.Boolean Taxable { get; set; }
       /// <summary>
       /// ProductNo
       /// </summary>
       public System.Int32? ProductNo { get; set; }
       /// <summary>
       /// Posted
       /// </summary>
       public System.Boolean Posted { get; set; }
       /// <summary>
       /// ShipInCost
       /// </summary>
       public System.Double? ShipInCost { get; set; }
       /// <summary>
       /// SupplierPart
       /// </summary>
       public System.String SupplierPart { get; set; }
       /// <summary>
       /// Inactive
       /// </summary>
       public System.Boolean Inactive { get; set; }
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
       /// Notes
       /// </summary>
       public System.String Notes { get; set; }
        
       /// <summary>
       /// FullSupplierPart
       /// </summary>
       public System.String FullSupplierPart { get; set; }
       /// <summary>
       /// PurchaseOrderId
       /// </summary>
       public System.Int32 PurchaseOrderId { get; set; }
       /// <summary>
       /// PurchaseOrderNumber
       /// </summary>
       public System.Int32 PurchaseOrderNumber { get; set; }
       /// <summary>
       /// CurrencyCode
       /// </summary>
       public System.String CurrencyCode { get; set; }
       /// <summary>
       /// QuantityOrdered
       /// </summary>
       public System.Int32 QuantityOrdered { get; set; }
       /// <summary>
       /// DateOrdered
       /// </summary>
       public System.DateTime DateOrdered { get; set; }
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
       /// ManufacturerCode
       /// </summary>
       public System.String ManufacturerCode { get; set; }
       /// <summary>
       /// RowNum
       /// </summary>
       public System.Int64? RowNum { get; set; }
       /// <summary>
       /// RowCnt
       /// </summary>
       public System.Int32? RowCnt { get; set; }
       /// <summary>
       /// Status
       /// </summary>
       public System.Int32? Status { get; set; }
       /// <summary>
       /// QuantityOutstanding
       /// </summary>
       public System.Int32? QuantityOutstanding { get; set; }
       /// <summary>
       /// EarliestShipDate
       /// </summary>
       public System.DateTime? EarliestShipDate { get; set; }
       /// <summary>
       /// PurchaseOrderValue
       /// </summary>
       public System.Double? PurchaseOrderValue { get; set; }
       /// <summary>
       /// LineNotes
       /// </summary>
       public System.String LineNotes { get; set; }
       /// <summary>
       /// QuantityReceived
       /// </summary>
       public System.Int32 QuantityReceived { get; set; }
       /// <summary>
       /// QuantityAllocated
       /// </summary>
       public System.Int32 QuantityAllocated { get; set; }
       /// <summary>
       /// GIShipInCost
       /// </summary>
       public System.Double GIShipInCost { get; set; }
       /// <summary>
       /// ProductName
       /// </summary>
       public System.String ProductName { get; set; }
       /// <summary>
       /// ProductDescription
       /// </summary>
       public System.String ProductDescription { get; set; }
       /// <summary>
       /// ProductDutyCode
       /// </summary>
       public System.String ProductDutyCode { get; set; }
       /// <summary>
       /// PackageName
       /// </summary>
       public System.String PackageName { get; set; }
       /// <summary>
       /// PackageDescription
       /// </summary>
       public System.String PackageDescription { get; set; }
       /// <summary>
       /// ImportCountryShippingCost
       /// </summary>
       public System.Double? ImportCountryShippingCost { get; set; }
       /// <summary>
       /// CurrencyNo
       /// </summary>
       public System.Int32 CurrencyNo { get; set; }
       /// <summary>
       /// CurrencyDescription
       /// </summary>
       public System.String CurrencyDescription { get; set; }
       /// <summary>
       /// ManufacturerName
       /// </summary>
       public System.String ManufacturerName { get; set; }
       /// <summary>
       /// TaxRate
       /// </summary>
       public System.Double? TaxRate { get; set; }
       /// <summary>
       /// ClientNo
       /// </summary>
       public System.Int32 ClientNo { get; set; }
       /// <summary>
       /// QuantityToReturn
       /// </summary>
       public System.Int32? QuantityToReturn { get; set; }
       /// <summary>
       /// ExpediteDate
       /// </summary>
       public System.DateTime? ExpediteDate { get; set; }
       /// <summary>
       /// Buyer
       /// </summary>
       public System.Int32 Buyer { get; set; }
       /// <summary>
       /// BuyerName
       /// </summary>
       public System.String BuyerName { get; set; }
       /// <summary>
       /// DivisionNo
       /// </summary>
       public System.Int32 DivisionNo { get; set; }
       /// <summary>
       /// TeamNo
       /// </summary>
       public System.Int32? TeamNo { get; set; }
       /// <summary>
       /// FullName
       /// </summary>
       public System.String FullName { get; set; }
       /// <summary>
       /// CreditLimit
       /// </summary>
       public System.Double? CreditLimit { get; set; }
       /// <summary>
       /// Balance
       /// </summary>
       public System.Double? Balance { get; set; }
       /// <summary>
       /// LineValue
       /// </summary>
       public System.Double LineValue { get; set; }
       /// <summary>
       /// TermsNo
       /// </summary>
       public System.Int32 TermsNo { get; set; }
       /// <summary>
       /// TermsName
       /// </summary>
       public System.String TermsName { get; set; }
       /// <summary>
       /// InAdvance
       /// </summary>
       public System.Boolean InAdvance { get; set; }
       /// <summary>
       /// DatePromised
       /// </summary>
       public System.DateTime DatePromised { get; set; }
       /// <summary>
       /// ClientName
       /// </summary>
       public System.String ClientName { get; set; }
       /// <summary>
       /// ClientDataVisibleToOthers
       /// </summary>
       public System.Boolean? ClientDataVisibleToOthers { get; set; }
       //[002] code start
       /// <summary>
       /// ImportCountryNo
       /// </summary>
       public System.Int32? ImportCountryNo { get; set; }
       //[002] code end
       //[003] code end
       /// </summary>
       public System.DateTime PromiseDate { get; set; }
       /// <summary>
       //[003] code end
       /// <summary>
       /// Location
       /// </summary>
       public System.String Location { get; set; }
       /// <summary>
       /// IsNprExist
       /// </summary>
       public System.Boolean? IsNprExist { get; set; }
       /// <summary>
       /// blnSRMA
       /// </summary>
       public System.Boolean? blnSRMA { get; set; }
       /// <summary>
       /// POSerialNo
       /// </summary>
       public System.Int16? POSerialNo { get; set; }

       //[004]Code Start
       /// <summary>
       /// IsCRMA
       /// </summary>
       public System.Boolean? IsCRMA { get; set; }
       //[004]Code Start

       public int? PurchaseOrderLineNo { get; set; }
       public int? InternalPurchaseOrderLineNo { get; set; }

       public System.Int32? InternalPurchaseOrderNo { get; set; }
       public System.Int32? InternalPurchaseOrderId { get; set; }
       public System.DateTime CreateDate { get; set; }
       public System.String EmployeeName { get; set; }
       /// <summary>
       /// IPOStatus
       /// </summary>
       public System.Int32? IPOStatus { get; set; }
       //[001] start
       /// <summary>
       /// SupplierWarranty
       /// </summary>
       public System.Int32? SupplierWarranty { get; set; }
       //[001] end
       //[002] start
       /// <summary>
       /// MSLLevel
       /// </summary>
       public System.String MSLLevel { get; set; }
       //[002] end
       #endregion

       #region Methods

       /// <summary>
       /// DataListNugget
       /// Calls [usp_datalistnugget_InternalPurchaseOrderLine]
       /// </summary>
       //[001]Code Start
       public static List<InternalPurchaseOrderLine> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.Int32? CountrySearch, System.Boolean? includeClosed, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? expediteDateFrom, System.DateTime? expediteDateTo, System.DateTime? deliveryDateFrom, System.DateTime? deliveryDateTo, System.Boolean? recentOnly, System.Int32? ClientSearch)
       {
           List<InternalPurchaseOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrderLine.DataListNugget(clientId, teamId, divisionId, loginId, pageIndex, pageSize, orderBy, sortDir, partSearch, contactSearch, cmSearch, buyerSearch, CountrySearch, includeClosed, purchaseOrderNoLo, purchaseOrderNoHi, dateOrderedFrom, dateOrderedTo, expediteDateFrom, expediteDateTo, deliveryDateFrom, deliveryDateTo, recentOnly, ClientSearch);
           //[001]Code End
           if (lstDetails == null)
           {
               return new List<InternalPurchaseOrderLine>();
           }
           else
           {
               List<InternalPurchaseOrderLine> lst = new List<InternalPurchaseOrderLine>();
               foreach (InternalPurchaseOrderLineDetails objDetails in lstDetails)
               {
                   Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine();
                   obj.PurchaseOrderId = objDetails.PurchaseOrderId;
                   obj.PurchaseOrderLineId = objDetails.PurchaseOrderLineId;
                   obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                   obj.Part = objDetails.Part;
                   obj.Price = objDetails.Price;
                   obj.CurrencyCode = objDetails.CurrencyCode;
                   obj.QuantityOrdered = objDetails.QuantityOrdered;
                   obj.DateOrdered = objDetails.DateOrdered;
                   obj.DeliveryDate = objDetails.DeliveryDate;
                   obj.CompanyName = objDetails.CompanyName;
                   obj.CompanyNo = objDetails.CompanyNo;
                   obj.ContactName = objDetails.ContactName;
                   obj.ContactNo = objDetails.ContactNo;
                   obj.ROHS = objDetails.ROHS;
                   obj.ManufacturerNo = objDetails.ManufacturerNo;
                   obj.ManufacturerCode = objDetails.ManufacturerCode;
                   obj.RowNum = objDetails.RowNum;
                   obj.RowCnt = objDetails.RowCnt;
                   obj.Status = objDetails.Status;
                   obj.QuantityOutstanding = objDetails.QuantityOutstanding;
                   obj.ClientName = objDetails.ClientName;
                   obj.ClientNo = objDetails.ClientNo;
                   obj.IPOStatus = objDetails.IPOStatus;
                   lst.Add(obj);
                   obj = null;
               }
               lstDetails = null;
               return lst;
           }
       }
       /// <summary>
       /// DataListNuggetAllForReceiving
       /// Calls [usp_datalistnugget_PurchaseOrderLine_AllForReceiving]
       /// </summary>
       public static List<InternalPurchaseOrderLine> DataListNuggetAllForReceiving(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.Boolean? recentOnly, System.Boolean? includeClosed, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? expediteDateFrom, System.DateTime? expediteDateTo, System.DateTime? deliveryDateFrom, System.DateTime? deliveryDateTo)
       {
           List<InternalPurchaseOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrderLine.DataListNuggetAllForReceiving(clientId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, buyerSearch, recentOnly, includeClosed, purchaseOrderNoLo, purchaseOrderNoHi, dateOrderedFrom, dateOrderedTo, expediteDateFrom, expediteDateTo, deliveryDateFrom, deliveryDateTo);
           if (lstDetails == null)
           {
               return new List<InternalPurchaseOrderLine>();
           }
           else
           {
               List<InternalPurchaseOrderLine> lst = new List<InternalPurchaseOrderLine>();
               foreach (InternalPurchaseOrderLineDetails objDetails in lstDetails)
               {
                   Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine();
                   obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                   obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                   obj.Part = objDetails.Part;
                   obj.ROHS = objDetails.ROHS;
                   obj.ManufacturerNo = objDetails.ManufacturerNo;
                   obj.ManufacturerCode = objDetails.ManufacturerCode;
                   obj.CompanyNo = objDetails.CompanyNo;
                   obj.CompanyName = objDetails.CompanyName;
                   obj.ContactNo = objDetails.ContactNo;
                   obj.ContactName = objDetails.ContactName;
                   obj.DeliveryDate = objDetails.DeliveryDate;
                   obj.PurchaseOrderLineId = objDetails.PurchaseOrderLineId;
                   obj.QuantityOrdered = objDetails.QuantityOrdered;
                   obj.QuantityOutstanding = objDetails.QuantityOutstanding;
                   obj.EarliestShipDate = objDetails.EarliestShipDate;
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
       /// DataListNuggetReadyToReceive
       /// Calls [usp_datalistnugget_PurchaseOrderLine_ReadyToReceive]
       /// </summary>
       public static List<InternalPurchaseOrderLine> DataListNuggetReadyToReceive(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? expediteDateFrom, System.DateTime? expediteDateTo, System.DateTime? deliveryDateFrom, System.DateTime? deliveryDateTo)
       {
           List<InternalPurchaseOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrderLine.DataListNuggetReadyToReceive(clientId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, buyerSearch, purchaseOrderNoLo, purchaseOrderNoHi, dateOrderedFrom, dateOrderedTo, expediteDateFrom, expediteDateTo, deliveryDateFrom, deliveryDateTo);
           if (lstDetails == null)
           {
               return new List<InternalPurchaseOrderLine>();
           }
           else
           {
               List<InternalPurchaseOrderLine> lst = new List<InternalPurchaseOrderLine>();
               foreach (InternalPurchaseOrderLineDetails objDetails in lstDetails)
               {
                   Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine();
                   obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                   obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                   obj.Part = objDetails.Part;
                   obj.ROHS = objDetails.ROHS;
                   obj.ManufacturerNo = objDetails.ManufacturerNo;
                   obj.ManufacturerCode = objDetails.ManufacturerCode;
                   obj.CompanyNo = objDetails.CompanyNo;
                   obj.CompanyName = objDetails.CompanyName;
                   obj.ContactNo = objDetails.ContactNo;
                   obj.ContactName = objDetails.ContactName;
                   obj.DeliveryDate = objDetails.DeliveryDate;
                   obj.PurchaseOrderLineId = objDetails.PurchaseOrderLineId;
                   obj.QuantityOrdered = objDetails.QuantityOrdered;
                   obj.QuantityOutstanding = objDetails.QuantityOutstanding;
                   obj.EarliestShipDate = objDetails.EarliestShipDate;
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
       /// Calls [usp_delete_PurchaseOrderLine]
       /// </summary>
       public static bool Delete(System.Int32? purchaseOrderLineId)
       {
           return Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrderLine.Delete(purchaseOrderLineId);
       }
       /// <summary>
       /// Insert
       /// Calls [usp_insert_InternalPurchaseOrderLine]
       /// </summary>
       public static Int32 Insert(int? fromPurchaseOrderLineNo,System.Int32? purchaseOrderLineId, System.Int32? updatedBy) 
       {
           Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrderLine.Insert(fromPurchaseOrderLineNo,purchaseOrderLineId, updatedBy);
           return objReturn;
       }

       /// <summary>
       /// InsertFromSalesOrderLine
       /// Calls [usp_insert_PurchaseOrderLine_from_SalesOrderLine]
       /// </summary>
       public static Int32 InsertFromSalesOrderLine(System.Int32? salesOrderLineId, System.Int32? purchaseOrderNo, System.Int32? updatedBy)
       {
           Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.PurchaseOrderLine.InsertFromSalesOrderLine(salesOrderLineId, purchaseOrderNo, updatedBy);
           return objReturn;
       }
       /// <summary>
       /// ItemSearch
       /// Calls [usp_itemsearch_PurchaseOrderLine]
       /// </summary>
       public static List<InternalPurchaseOrderLine> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Boolean? includeClosed, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? deliveryDateFrom, System.DateTime? deliveryDateTo)
       {
           List<InternalPurchaseOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrderLine.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, partSearch, cmSearch, includeClosed, purchaseOrderNoLo, purchaseOrderNoHi, dateOrderedFrom, dateOrderedTo, deliveryDateFrom, deliveryDateTo);
           if (lstDetails == null)
           {
               return new List<InternalPurchaseOrderLine>();
           }
           else
           {
               List<InternalPurchaseOrderLine> lst = new List<InternalPurchaseOrderLine>();
               foreach (InternalPurchaseOrderLineDetails objDetails in lstDetails)
               {
                   Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine();
                   obj.PurchaseOrderLineId = objDetails.PurchaseOrderLineId;
                   obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                   obj.PurchaseOrderValue = objDetails.PurchaseOrderValue;
                   obj.CurrencyCode = objDetails.CurrencyCode;
                   obj.Price = objDetails.Price;
                   obj.CompanyNo = objDetails.CompanyNo;
                   obj.CompanyName = objDetails.CompanyName;
                   obj.DateOrdered = objDetails.DateOrdered;
                   obj.DeliveryDate = objDetails.DeliveryDate;
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
       /// Calls [usp_select_InternalPurchaseOrderLine]
       /// </summary>
       public static InternalPurchaseOrderLine Get(System.Int32? internalPurchaseOrderLineId) 
       {
           Rebound.GlobalTrader.DAL.InternalPurchaseOrderLineDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrderLine.Get(internalPurchaseOrderLineId);
           if (objDetails == null)
           {
               return null;
           }
           else
           {
               InternalPurchaseOrderLine obj = new InternalPurchaseOrderLine();
               obj.PurchaseOrderLineId = objDetails.PurchaseOrderLineId;
               obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
               obj.InternalPurchaseOrderLineNo = objDetails.InternalPurchaseOrderLineNo;
               obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
               obj.FullPart = objDetails.FullPart;
               obj.Part = objDetails.Part;
               obj.ManufacturerNo = objDetails.ManufacturerNo;
               obj.DateCode = objDetails.DateCode;
               obj.PackageNo = objDetails.PackageNo;
               obj.Quantity = objDetails.Quantity;
               obj.Price = objDetails.Price;
               obj.DeliveryDate = objDetails.DeliveryDate;
               obj.ReceivingNotes = objDetails.ReceivingNotes;
               obj.Taxable = objDetails.Taxable;
               obj.ProductNo = objDetails.ProductNo;
               obj.Posted = objDetails.Posted;
               obj.ShipInCost = objDetails.ShipInCost;
               obj.SupplierPart = objDetails.SupplierPart;
               obj.Inactive = objDetails.Inactive;
               obj.Closed = objDetails.Closed;
               obj.ROHS = objDetails.ROHS;
               obj.LineNotes = objDetails.LineNotes;
               obj.UpdatedBy = objDetails.UpdatedBy;
               obj.DLUP = objDetails.DLUP;
               obj.QuantityReceived = objDetails.QuantityReceived;
               obj.QuantityAllocated = objDetails.QuantityAllocated;
               obj.GIShipInCost = objDetails.GIShipInCost;
               obj.ProductName = objDetails.ProductName;
               obj.ProductDescription = objDetails.ProductDescription;
               obj.ProductDutyCode = objDetails.ProductDutyCode;
               obj.PackageName = objDetails.PackageName;
               obj.PackageDescription = objDetails.PackageDescription;
               obj.ImportCountryShippingCost = objDetails.ImportCountryShippingCost;
               obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
               obj.CurrencyCode = objDetails.CurrencyCode;
               obj.CurrencyNo = objDetails.CurrencyNo;
               obj.CurrencyDescription = objDetails.CurrencyDescription;
               obj.ManufacturerName = objDetails.ManufacturerName;
               obj.ManufacturerCode = objDetails.ManufacturerCode;
               obj.CompanyNo = objDetails.CompanyNo;
               obj.CompanyName = objDetails.CompanyName;
               obj.DateOrdered = objDetails.DateOrdered;
               obj.TaxRate = objDetails.TaxRate;
               obj.ClientNo = objDetails.ClientNo;
               //[002] code start
               obj.ImportCountryNo = objDetails.ImportCountryNo;
               //[002] code end
               obj.PromiseDate = objDetails.PromiseDate;
               //[003] start
               obj.SupplierWarranty = objDetails.SupplierWarranty;
               //[003] end
               obj.MSLLevel = objDetails.MSLLevel;
               objDetails = null;
               return obj;
           }
       }
       /// <summary>
       /// GetForSupplierRMALine
       /// Calls [usp_select_PurchaseOrderLine_for_SupplierRMALine]
       /// </summary>
       public static InternalPurchaseOrderLine GetForSupplierRMALine(System.Int32? purchaseOrderLineId)
       {
           Rebound.GlobalTrader.DAL.InternalPurchaseOrderLineDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrderLine.GetForSupplierRMALine(purchaseOrderLineId);
           if (objDetails == null)
           {
               return null;
           }
           else
           {
               InternalPurchaseOrderLine obj = new InternalPurchaseOrderLine();
               obj.PurchaseOrderLineId = objDetails.PurchaseOrderLineId;
               obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
               obj.FullPart = objDetails.FullPart;
               obj.Part = objDetails.Part;
               obj.ManufacturerNo = objDetails.ManufacturerNo;
               obj.DateCode = objDetails.DateCode;
               obj.PackageNo = objDetails.PackageNo;
               obj.Quantity = objDetails.Quantity;
               obj.Price = objDetails.Price;
               obj.DeliveryDate = objDetails.DeliveryDate;
               obj.ReceivingNotes = objDetails.ReceivingNotes;
               obj.Taxable = objDetails.Taxable;
               obj.ProductNo = objDetails.ProductNo;
               obj.Posted = objDetails.Posted;
               obj.ShipInCost = objDetails.ShipInCost;
               obj.SupplierPart = objDetails.SupplierPart;
               obj.Inactive = objDetails.Inactive;
               obj.Closed = objDetails.Closed;
               obj.ROHS = objDetails.ROHS;
               obj.LineNotes = objDetails.LineNotes;
               obj.UpdatedBy = objDetails.UpdatedBy;
               obj.DLUP = objDetails.DLUP;
               obj.QuantityReceived = objDetails.QuantityReceived;
               obj.QuantityAllocated = objDetails.QuantityAllocated;
               obj.GIShipInCost = objDetails.GIShipInCost;
               obj.ProductName = objDetails.ProductName;
               obj.ProductDescription = objDetails.ProductDescription;
               obj.ProductDutyCode = objDetails.ProductDutyCode;
               obj.PackageName = objDetails.PackageName;
               obj.PackageDescription = objDetails.PackageDescription;
               obj.ImportCountryShippingCost = objDetails.ImportCountryShippingCost;
               obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
               obj.CurrencyCode = objDetails.CurrencyCode;
               obj.CurrencyNo = objDetails.CurrencyNo;
               obj.CurrencyDescription = objDetails.CurrencyDescription;
               obj.ManufacturerName = objDetails.ManufacturerName;
               obj.ManufacturerCode = objDetails.ManufacturerCode;
               obj.CompanyNo = objDetails.CompanyNo;
               obj.CompanyName = objDetails.CompanyName;
               obj.DateOrdered = objDetails.DateOrdered;
               obj.TaxRate = objDetails.TaxRate;
               obj.ClientNo = objDetails.ClientNo;
               obj.QuantityToReturn = objDetails.QuantityToReturn;
               objDetails = null;
               return obj;
           }
       }
       /// <summary>
       /// GetListCandidatesForSupplierRMA
       /// Calls [usp_selectAll_PurchaseOrderLine_candidates_for_SupplierRMA]
       /// </summary>
       public static List<InternalPurchaseOrderLine> GetListCandidatesForSupplierRMA(System.Int32? supplierRmaId)
       {
           List<InternalPurchaseOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrderLine.GetListCandidatesForSupplierRMA(supplierRmaId);
           if (lstDetails == null)
           {
               return new List<InternalPurchaseOrderLine>();
           }
           else
           {
               List<InternalPurchaseOrderLine> lst = new List<InternalPurchaseOrderLine>();
               foreach (InternalPurchaseOrderLineDetails objDetails in lstDetails)
               {
                   Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine();
                   obj.PurchaseOrderLineId = objDetails.PurchaseOrderLineId;
                   obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                   obj.FullPart = objDetails.FullPart;
                   obj.Part = objDetails.Part;
                   obj.ManufacturerNo = objDetails.ManufacturerNo;
                   obj.DateCode = objDetails.DateCode;
                   obj.PackageNo = objDetails.PackageNo;
                   obj.Quantity = objDetails.Quantity;
                   obj.Price = objDetails.Price;
                   obj.DeliveryDate = objDetails.DeliveryDate;
                   obj.ReceivingNotes = objDetails.ReceivingNotes;
                   obj.Taxable = objDetails.Taxable;
                   obj.ProductNo = objDetails.ProductNo;
                   obj.Posted = objDetails.Posted;
                   obj.ShipInCost = objDetails.ShipInCost;
                   obj.SupplierPart = objDetails.SupplierPart;
                   obj.Inactive = objDetails.Inactive;
                   obj.Closed = objDetails.Closed;
                   obj.ROHS = objDetails.ROHS;
                   obj.LineNotes = objDetails.LineNotes;
                   obj.UpdatedBy = objDetails.UpdatedBy;
                   obj.DLUP = objDetails.DLUP;
                   obj.QuantityReceived = objDetails.QuantityReceived;
                   obj.QuantityAllocated = objDetails.QuantityAllocated;
                   obj.GIShipInCost = objDetails.GIShipInCost;
                   obj.ProductName = objDetails.ProductName;
                   obj.ProductDescription = objDetails.ProductDescription;
                   obj.ProductDutyCode = objDetails.ProductDutyCode;
                   obj.PackageName = objDetails.PackageName;
                   obj.PackageDescription = objDetails.PackageDescription;
                   obj.ImportCountryShippingCost = objDetails.ImportCountryShippingCost;
                   obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                   obj.CurrencyCode = objDetails.CurrencyCode;
                   obj.CurrencyNo = objDetails.CurrencyNo;
                   obj.CurrencyDescription = objDetails.CurrencyDescription;
                   obj.ManufacturerName = objDetails.ManufacturerName;
                   obj.ManufacturerCode = objDetails.ManufacturerCode;
                   obj.CompanyNo = objDetails.CompanyNo;
                   obj.CompanyName = objDetails.CompanyName;
                   obj.DateOrdered = objDetails.DateOrdered;
                   obj.TaxRate = objDetails.TaxRate;
                   obj.ClientNo = objDetails.ClientNo;
                   obj.QuantityToReturn = objDetails.QuantityToReturn;
                   obj.Location = objDetails.Location;
                   obj.IsNprExist = objDetails.IsNprExist;
                   //[004]Code Start
                   obj.IsCRMA = objDetails.IsCRMA;
                   //[004]Code End
                   obj.POSerialNo = objDetails.POSerialNo;
                   lst.Add(obj);
                   obj = null;
               }
               lstDetails = null;
               return lst;
           }
       }
       /// <summary>
       /// GetListClosedForPurchaseOrder
       /// Calls [usp_selectAll_InternalPurchaseOrderLine_closed_for_InternalPurchaseOrder]
       /// </summary>
       public static List<InternalPurchaseOrderLine> GetListClosedForPurchaseOrder(System.Int32? purchaseOrderId)
       {
           List<InternalPurchaseOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrderLine.GetListClosedForPurchaseOrder(purchaseOrderId);
           if (lstDetails == null)
           {
               return new List<InternalPurchaseOrderLine>();
           }
           else
           {
               List<InternalPurchaseOrderLine> lst = new List<InternalPurchaseOrderLine>();
               foreach (InternalPurchaseOrderLineDetails objDetails in lstDetails)
               {
                   Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine();
                   obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
                   obj.InternalPurchaseOrderLineNo = objDetails.InternalPurchaseOrderLineNo;
                   obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                   obj.FullPart = objDetails.FullPart;
                   obj.Part = objDetails.Part;
                   obj.ManufacturerNo = objDetails.ManufacturerNo;
                   obj.DateCode = objDetails.DateCode;
                   obj.PackageNo = objDetails.PackageNo;
                   obj.Quantity = objDetails.Quantity;
                   obj.Price = objDetails.Price;
                   obj.DeliveryDate = objDetails.DeliveryDate;
                   obj.ReceivingNotes = objDetails.ReceivingNotes;
                   obj.Taxable = objDetails.Taxable;
                   obj.ProductNo = objDetails.ProductNo;
                   obj.Posted = objDetails.Posted;
                   obj.ShipInCost = objDetails.ShipInCost;
                   obj.SupplierPart = objDetails.SupplierPart;
                   obj.Inactive = objDetails.Inactive;
                   obj.Closed = objDetails.Closed;
                   obj.ROHS = objDetails.ROHS;
                   obj.LineNotes = objDetails.LineNotes;
                   obj.UpdatedBy = objDetails.UpdatedBy;
                   obj.DLUP = objDetails.DLUP;
                   obj.QuantityReceived = objDetails.QuantityReceived;
                   obj.QuantityAllocated = objDetails.QuantityAllocated;
                   obj.GIShipInCost = objDetails.GIShipInCost;
                   obj.ProductName = objDetails.ProductName;
                   obj.ProductDescription = objDetails.ProductDescription;
                   obj.ProductDutyCode = objDetails.ProductDutyCode;
                   obj.PackageName = objDetails.PackageName;
                   obj.PackageDescription = objDetails.PackageDescription;
                   obj.ImportCountryShippingCost = objDetails.ImportCountryShippingCost;
                   obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                   obj.CurrencyCode = objDetails.CurrencyCode;
                   obj.CurrencyNo = objDetails.CurrencyNo;
                   obj.CurrencyDescription = objDetails.CurrencyDescription;
                   obj.ManufacturerName = objDetails.ManufacturerName;
                   obj.ManufacturerCode = objDetails.ManufacturerCode;
                   obj.CompanyNo = objDetails.CompanyNo;
                   obj.CompanyName = objDetails.CompanyName;
                   obj.DateOrdered = objDetails.DateOrdered;
                   obj.TaxRate = objDetails.TaxRate;
                   obj.ClientNo = objDetails.ClientNo;
                   obj.POSerialNo = objDetails.POSerialNo;
                   //[002] start
                   obj.MSLLevel = objDetails.MSLLevel;
                   //[002] end
                   lst.Add(obj);
                   obj = null;
               }
               lstDetails = null;
               return lst;
           }
       }
       /// <summary>
       /// GetListForPurchaseOrder
       /// Calls [usp_selectAll_InternalPurchaseOrderLine_for_InternalPurchaseOrder]
       /// </summary>
       public static List<InternalPurchaseOrderLine> GetListForPurchaseOrder(System.Int32? purchaseOrderId)
       {
           List<InternalPurchaseOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrderLine.GetListForPurchaseOrder(purchaseOrderId);
           if (lstDetails == null)
           {
               return new List<InternalPurchaseOrderLine>();
           }
           else
           {
               List<InternalPurchaseOrderLine> lst = new List<InternalPurchaseOrderLine>();
               foreach (InternalPurchaseOrderLineDetails objDetails in lstDetails)
               {
                   Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine();
                   obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
                   obj.InternalPurchaseOrderLineNo = objDetails.InternalPurchaseOrderLineNo;                   
                   obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                   obj.FullPart = objDetails.FullPart;
                   obj.Part = objDetails.Part;
                   obj.ManufacturerNo = objDetails.ManufacturerNo;
                   obj.DateCode = objDetails.DateCode;
                   obj.PackageNo = objDetails.PackageNo;
                   obj.Quantity = objDetails.Quantity;
                   obj.Price = objDetails.Price;
                   obj.DeliveryDate = objDetails.DeliveryDate;
                   obj.ReceivingNotes = objDetails.ReceivingNotes;
                   obj.Taxable = objDetails.Taxable;
                   obj.ProductNo = objDetails.ProductNo;
                   obj.Posted = objDetails.Posted;
                   obj.ShipInCost = objDetails.ShipInCost;
                   obj.SupplierPart = objDetails.SupplierPart;
                   obj.Inactive = objDetails.Inactive;
                   obj.Closed = objDetails.Closed;
                   obj.ROHS = objDetails.ROHS;
                   obj.LineNotes = objDetails.LineNotes;
                   obj.UpdatedBy = objDetails.UpdatedBy;
                   obj.DLUP = objDetails.DLUP;
                   obj.QuantityReceived = objDetails.QuantityReceived;
                   obj.QuantityAllocated = objDetails.QuantityAllocated;
                   obj.GIShipInCost = objDetails.GIShipInCost;
                   obj.ProductName = objDetails.ProductName;
                   obj.ProductDescription = objDetails.ProductDescription;
                   obj.ProductDutyCode = objDetails.ProductDutyCode;
                   obj.PackageName = objDetails.PackageName;
                   obj.PackageDescription = objDetails.PackageDescription;
                   obj.ImportCountryShippingCost = objDetails.ImportCountryShippingCost;
                   obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                   obj.CurrencyCode = objDetails.CurrencyCode;
                   obj.CurrencyNo = objDetails.CurrencyNo;
                   obj.CurrencyDescription = objDetails.CurrencyDescription;
                   obj.ManufacturerName = objDetails.ManufacturerName;
                   obj.ManufacturerCode = objDetails.ManufacturerCode;
                   obj.CompanyNo = objDetails.CompanyNo;
                   obj.CompanyName = objDetails.CompanyName;
                   obj.DateOrdered = objDetails.DateOrdered;
                   obj.TaxRate = objDetails.TaxRate;
                   obj.ClientNo = objDetails.ClientNo;
                   obj.POSerialNo = objDetails.POSerialNo;
                   //[002] start
                   obj.MSLLevel = objDetails.MSLLevel;
                   //[002] end
                   lst.Add(obj);
                   obj = null;
               }
               lstDetails = null;
               return lst;
           }
       }
       /// <summary>
       /// GetListForSupplierRMA
       /// Calls [usp_selectAll_PurchaseOrderLine_for_SupplierRMA]
       /// </summary>
       public static List<InternalPurchaseOrderLine> GetListForSupplierRMA(System.Int32? supplierRmaId)
       {
           List<InternalPurchaseOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrderLine.GetListForSupplierRMA(supplierRmaId);
           if (lstDetails == null)
           {
               return new List<InternalPurchaseOrderLine>();
           }
           else
           {
               List<InternalPurchaseOrderLine> lst = new List<InternalPurchaseOrderLine>();
               foreach (InternalPurchaseOrderLineDetails objDetails in lstDetails)
               {
                   Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine();
                   obj.PurchaseOrderLineId = objDetails.PurchaseOrderLineId;
                   obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                   obj.FullPart = objDetails.FullPart;
                   obj.Part = objDetails.Part;
                   obj.ManufacturerNo = objDetails.ManufacturerNo;
                   obj.DateCode = objDetails.DateCode;
                   obj.PackageNo = objDetails.PackageNo;
                   obj.Quantity = objDetails.Quantity;
                   obj.Price = objDetails.Price;
                   obj.DeliveryDate = objDetails.DeliveryDate;
                   obj.ReceivingNotes = objDetails.ReceivingNotes;
                   obj.Taxable = objDetails.Taxable;
                   obj.ProductNo = objDetails.ProductNo;
                   obj.Posted = objDetails.Posted;
                   obj.ShipInCost = objDetails.ShipInCost;
                   obj.SupplierPart = objDetails.SupplierPart;
                   obj.Inactive = objDetails.Inactive;
                   obj.Closed = objDetails.Closed;
                   obj.ROHS = objDetails.ROHS;
                   obj.LineNotes = objDetails.LineNotes;
                   obj.UpdatedBy = objDetails.UpdatedBy;
                   obj.DLUP = objDetails.DLUP;
                   obj.QuantityReceived = objDetails.QuantityReceived;
                   obj.QuantityAllocated = objDetails.QuantityAllocated;
                   obj.GIShipInCost = objDetails.GIShipInCost;
                   obj.ProductName = objDetails.ProductName;
                   obj.ProductDescription = objDetails.ProductDescription;
                   obj.ProductDutyCode = objDetails.ProductDutyCode;
                   obj.PackageName = objDetails.PackageName;
                   obj.PackageDescription = objDetails.PackageDescription;
                   obj.ImportCountryShippingCost = objDetails.ImportCountryShippingCost;
                   obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                   obj.CurrencyCode = objDetails.CurrencyCode;
                   obj.CurrencyNo = objDetails.CurrencyNo;
                   obj.CurrencyDescription = objDetails.CurrencyDescription;
                   obj.ManufacturerName = objDetails.ManufacturerName;
                   obj.ManufacturerCode = objDetails.ManufacturerCode;
                   obj.CompanyNo = objDetails.CompanyNo;
                   obj.CompanyName = objDetails.CompanyName;
                   obj.DateOrdered = objDetails.DateOrdered;
                   obj.TaxRate = objDetails.TaxRate;
                   obj.ClientNo = objDetails.ClientNo;
                   lst.Add(obj);
                   obj = null;
               }
               lstDetails = null;
               return lst;
           }
       }
       /// <summary>
       /// GetListOpenForPurchaseOrder
       /// Calls [usp_selectAll_InternalPurchaseOrderLine_open_for_InternalPurchaseOrder]
       /// </summary>
       public static List<InternalPurchaseOrderLine> GetListOpenForPurchaseOrder(System.Int32? purchaseOrderId)
       {
           List<InternalPurchaseOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrderLine.GetListOpenForPurchaseOrder(purchaseOrderId);
           if (lstDetails == null)
           {
               return new List<InternalPurchaseOrderLine>();
           }
           else
           {
               List<InternalPurchaseOrderLine> lst = new List<InternalPurchaseOrderLine>();
               foreach (InternalPurchaseOrderLineDetails objDetails in lstDetails)
               {
                   Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine();
                   obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
                   obj.InternalPurchaseOrderLineNo = objDetails.InternalPurchaseOrderLineNo;
                   obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                   obj.FullPart = objDetails.FullPart;
                   obj.Part = objDetails.Part;
                   obj.ManufacturerNo = objDetails.ManufacturerNo;
                   obj.DateCode = objDetails.DateCode;
                   obj.PackageNo = objDetails.PackageNo;
                   obj.Quantity = objDetails.Quantity;
                   obj.Price = objDetails.Price;
                   obj.DeliveryDate = objDetails.DeliveryDate;
                   obj.ReceivingNotes = objDetails.ReceivingNotes;
                   obj.Taxable = objDetails.Taxable;
                   obj.ProductNo = objDetails.ProductNo;
                   obj.Posted = objDetails.Posted;
                   obj.ShipInCost = objDetails.ShipInCost;
                   obj.SupplierPart = objDetails.SupplierPart;
                   obj.Inactive = objDetails.Inactive;
                   obj.Closed = objDetails.Closed;
                   obj.ROHS = objDetails.ROHS;
                   obj.LineNotes = objDetails.LineNotes;
                   obj.UpdatedBy = objDetails.UpdatedBy;
                   obj.DLUP = objDetails.DLUP;
                   obj.QuantityReceived = objDetails.QuantityReceived;
                   obj.QuantityAllocated = objDetails.QuantityAllocated;
                   obj.GIShipInCost = objDetails.GIShipInCost;
                   obj.ProductName = objDetails.ProductName;
                   obj.ProductDescription = objDetails.ProductDescription;
                   obj.ProductDutyCode = objDetails.ProductDutyCode;
                   obj.PackageName = objDetails.PackageName;
                   obj.PackageDescription = objDetails.PackageDescription;
                   obj.ImportCountryShippingCost = objDetails.ImportCountryShippingCost;
                   obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                   obj.CurrencyCode = objDetails.CurrencyCode;
                   obj.CurrencyNo = objDetails.CurrencyNo;
                   obj.CurrencyDescription = objDetails.CurrencyDescription;
                   obj.ManufacturerName = objDetails.ManufacturerName;
                   obj.ManufacturerCode = objDetails.ManufacturerCode;
                   obj.CompanyNo = objDetails.CompanyNo;
                   obj.CompanyName = objDetails.CompanyName;
                   obj.DateOrdered = objDetails.DateOrdered;
                   obj.TaxRate = objDetails.TaxRate;
                   obj.ClientNo = objDetails.ClientNo;
                   //[001] code start
                   obj.PromiseDate = objDetails.PromiseDate;
                   //[001] code end
                   obj.POSerialNo = objDetails.POSerialNo;
                   //[002] start
                   obj.MSLLevel = objDetails.MSLLevel;
                   //[002] end
                   lst.Add(obj);
                   obj = null;
               }
               lstDetails = null;
               return lst;
           }
       }
       /// <summary>
       /// GetListReceivingForPurchaseOrder
       /// Calls [usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder]
       /// </summary>
       public static List<InternalPurchaseOrderLine> GetListReceivingForPurchaseOrder(System.Int32? purchaseOrderId)
       {
           List<InternalPurchaseOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrderLine.GetListReceivingForPurchaseOrder(purchaseOrderId);
           if (lstDetails == null)
           {
               return new List<InternalPurchaseOrderLine>();
           }
           else
           {
               List<InternalPurchaseOrderLine> lst = new List<InternalPurchaseOrderLine>();
               foreach (InternalPurchaseOrderLineDetails objDetails in lstDetails)
               {
                   Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine();
                   obj.ClientNo = objDetails.ClientNo;
                   obj.PurchaseOrderId = objDetails.PurchaseOrderId;
                   obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                   obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
                   obj.DateOrdered = objDetails.DateOrdered;
                   obj.ExpediteDate = objDetails.ExpediteDate;
                   obj.DeliveryDate = objDetails.DeliveryDate;
                   obj.Buyer = objDetails.Buyer;
                   obj.BuyerName = objDetails.BuyerName;
                   obj.DivisionNo = objDetails.DivisionNo;
                   obj.TeamNo = objDetails.TeamNo;
                   obj.CompanyNo = objDetails.CompanyNo;
                   obj.CompanyName = objDetails.CompanyName;
                   obj.FullName = objDetails.FullName;
                   obj.CreditLimit = objDetails.CreditLimit;
                   obj.Balance = objDetails.Balance;
                   obj.ContactNo = objDetails.ContactNo;
                   obj.ContactName = objDetails.ContactName;
                   obj.Price = objDetails.Price;
                   obj.Quantity = objDetails.Quantity;
                   obj.LineValue = objDetails.LineValue;
                   obj.QuantityOrdered = objDetails.QuantityOrdered;
                   obj.QuantityReceived = objDetails.QuantityReceived;
                   obj.QuantityOutstanding = objDetails.QuantityOutstanding;
                   obj.QuantityAllocated = objDetails.QuantityAllocated;
                   obj.ShipInCost = objDetails.ShipInCost;
                   obj.ReceivingNotes = objDetails.ReceivingNotes;
                   obj.ProductNo = objDetails.ProductNo;
                   obj.ProductName = objDetails.ProductName;
                   obj.ProductDescription = objDetails.ProductDescription;
                   obj.FullPart = objDetails.FullPart;
                   obj.Part = objDetails.Part;
                   obj.ROHS = objDetails.ROHS;
                   obj.Posted = objDetails.Posted;
                   obj.SupplierPart = objDetails.SupplierPart;
                   obj.FullSupplierPart = objDetails.FullSupplierPart;
                   obj.ManufacturerNo = objDetails.ManufacturerNo;
                   obj.ManufacturerName = objDetails.ManufacturerName;
                   obj.ManufacturerCode = objDetails.ManufacturerCode;
                   obj.DateCode = objDetails.DateCode;
                   obj.PackageNo = objDetails.PackageNo;
                   obj.PackageName = objDetails.PackageName;
                   obj.PackageDescription = objDetails.PackageDescription;
                   obj.Closed = objDetails.Closed;
                   obj.TermsNo = objDetails.TermsNo;
                   obj.TermsName = objDetails.TermsName;
                   obj.InAdvance = objDetails.InAdvance;
                   obj.CurrencyNo = objDetails.CurrencyNo;
                   obj.CurrencyCode = objDetails.CurrencyCode;
                   obj.CurrencyDescription = objDetails.CurrencyDescription;
                   obj.PurchaseOrderValue = objDetails.PurchaseOrderValue;
                   obj.DatePromised = objDetails.DatePromised;
                   lst.Add(obj);
                   obj = null;
               }
               lstDetails = null;
               return lst;
           }
       }


       /// <summary>
       /// GetListTodayForClient
       /// Calls [usp_selectAll_PurchaseOrderLine_today_for_Client]
       /// </summary>
       public static List<InternalPurchaseOrderLine> GetListTodayForClient(System.Int32? clientId, System.Int32? topToSelect)
       {
           List<InternalPurchaseOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrderLine.GetListTodayForClient(clientId, topToSelect);
           if (lstDetails == null)
           {
               return new List<InternalPurchaseOrderLine>();
           }
           else
           {
               List<InternalPurchaseOrderLine> lst = new List<InternalPurchaseOrderLine>();
               foreach (InternalPurchaseOrderLineDetails objDetails in lstDetails)
               {
                   Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine();
                   obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
                   obj.InternalPurchaseOrderNo = objDetails.InternalPurchaseOrderNo;
                   obj.CreateDate = objDetails.CreateDate;
                   obj.CompanyName = objDetails.CompanyName;
                   obj.CompanyNo = objDetails.CompanyNo;
                   obj.ClientName = objDetails.ClientName;
                   obj.ClientNo = objDetails.ClientNo;
                   obj.EmployeeName = objDetails.EmployeeName;
                   lst.Add(obj);
                   obj = null;
               }
               lstDetails = null;
               return lst;
           }
       }
       /// <summary>
       /// Source
       /// Calls [usp_source_PurchaseOrderLine]
       /// </summary>
       public static List<InternalPurchaseOrderLine> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? maxDate, out DateTime? outDate, System.Boolean? blnReferesh, bool IsServerLocal)
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
           List<InternalPurchaseOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrderLine.Source(clientId, partSearch, index, StartDate, EndDate, out outDate, IsServerLocal);
           if (lstDetails == null)
           {
               return new List<InternalPurchaseOrderLine>();
           }
           else
           {
               List<InternalPurchaseOrderLine> lst = new List<InternalPurchaseOrderLine>();
               foreach (InternalPurchaseOrderLineDetails objDetails in lstDetails)
               {
                   Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrderLine();
                   obj.PurchaseOrderLineId = objDetails.PurchaseOrderLineId;
                   obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                   obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                   obj.Part = objDetails.Part;
                   obj.Quantity = objDetails.Quantity;
                   obj.Price = objDetails.Price;
                   obj.ROHS = objDetails.ROHS;
                   obj.ManufacturerNo = objDetails.ManufacturerNo;
                   obj.ManufacturerCode = objDetails.ManufacturerCode;
                   obj.CompanyNo = objDetails.CompanyNo;
                   obj.CompanyName = objDetails.CompanyName;
                   obj.DateOrdered = objDetails.DateOrdered;
                   obj.CurrencyCode = objDetails.CurrencyCode;
                   obj.DateCode = objDetails.DateCode;
                   obj.SupplierPart = objDetails.SupplierPart;
                   obj.ProductName = objDetails.ProductName;
                   obj.PackageName = objDetails.PackageName;
                   obj.ClientNo = objDetails.ClientNo;
                   obj.ClientName = objDetails.ClientName;
                   obj.ClientDataVisibleToOthers = objDetails.ClientDataVisibleToOthers;
                   obj.Buyer = objDetails.Buyer;
                   obj.BuyerName = objDetails.BuyerName;
                   obj.blnSRMA = objDetails.blnSRMA;
                   lst.Add(obj);
                   obj = null;
               }
               lstDetails = null;
               return lst;
           }
       }
       /// <summary>
       /// Update
       /// Calls [usp_update_PurchaseOrderLine]
       /// </summary>
       public static bool Update(System.Int32? purchaseOrderLineId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.DateTime? deliveryDate, System.String receivingNotes, System.Boolean? taxable, System.Int32? productNo, System.Double? shipInCost, System.String supplierPart, System.Boolean? inactive, System.Byte? rohs, System.String notes, System.DateTime? PromiseDate, System.Int32? updatedBy)
       {
           return Rebound.GlobalTrader.DAL.SiteProvider.PurchaseOrderLine.Update(purchaseOrderLineId, part, manufacturerNo, dateCode, packageNo, quantity, price, deliveryDate, receivingNotes, taxable, productNo, shipInCost, supplierPart, inactive, rohs, notes, PromiseDate, updatedBy,false,null,false);
       }
       /// <summary>
       /// Update (without parameters)
       /// Calls [usp_update_InternalPurchaseOrderLine]
       /// </summary>
       //[002] start
       public bool Update()
       {
           return Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrderLine.Update(InternalPurchaseOrderLineNo,Price,Notes,ReceivingNotes,ShipInCost,ProductNo, UpdatedBy,MSLLevel);
       }
      
       /// <summary>
       /// UpdateClosedStatus
       /// Calls [usp_update_PurchaseOrderLine_Closed_Status]
       /// </summary>
       public static bool UpdateClosedStatus(System.Int32? purchaseOrderLineNo)
       {
           return Rebound.GlobalTrader.DAL.SiteProvider.PurchaseOrderLine.UpdateClosedStatus(purchaseOrderLineNo);
       }
       /// <summary>
       /// UpdatePostOrUnpost
       /// Calls [usp_update_PurchaseOrderLine_Post_or_Unpost]
       /// </summary>
       public static bool UpdatePostOrUnpost(System.Int32? purchaseOrderLineId, System.Boolean? posted, System.Int32? updatedBy)
       {
           return Rebound.GlobalTrader.DAL.SiteProvider.PurchaseOrderLine.UpdatePostOrUnpost(purchaseOrderLineId, posted, updatedBy);
       }

       private static InternalPurchaseOrderLine PopulateFromDBDetailsObject(InternalPurchaseOrderLineDetails obj)
       {
           InternalPurchaseOrderLine objNew = new InternalPurchaseOrderLine();
           objNew.PurchaseOrderLineId = obj.PurchaseOrderLineId;
           objNew.PurchaseOrderNo = obj.PurchaseOrderNo;
           objNew.FullPart = obj.FullPart;
           objNew.Part = obj.Part;
           objNew.ManufacturerNo = obj.ManufacturerNo;
           objNew.DateCode = obj.DateCode;
           objNew.PackageNo = obj.PackageNo;
           objNew.Quantity = obj.Quantity;
           objNew.Price = obj.Price;
           objNew.DeliveryDate = obj.DeliveryDate;
           objNew.ReceivingNotes = obj.ReceivingNotes;
           objNew.Taxable = obj.Taxable;
           objNew.ProductNo = obj.ProductNo;
           objNew.Posted = obj.Posted;
           objNew.ShipInCost = obj.ShipInCost;
           objNew.SupplierPart = obj.SupplierPart;
           objNew.Inactive = obj.Inactive;
           objNew.Closed = obj.Closed;
           objNew.ROHS = obj.ROHS;
           objNew.UpdatedBy = obj.UpdatedBy;
           objNew.DLUP = obj.DLUP;
           objNew.Notes = obj.Notes;
           objNew.FullSupplierPart = obj.FullSupplierPart;
           objNew.PurchaseOrderId = obj.PurchaseOrderId;
           objNew.PurchaseOrderNumber = obj.PurchaseOrderNumber;
           objNew.CurrencyCode = obj.CurrencyCode;
           objNew.QuantityOrdered = obj.QuantityOrdered;
           objNew.DateOrdered = obj.DateOrdered;
           objNew.CompanyName = obj.CompanyName;
           objNew.CompanyNo = obj.CompanyNo;
           objNew.ContactName = obj.ContactName;
           objNew.ContactNo = obj.ContactNo;
           objNew.ManufacturerCode = obj.ManufacturerCode;
           objNew.RowNum = obj.RowNum;
           objNew.RowCnt = obj.RowCnt;
           objNew.Status = obj.Status;
           objNew.QuantityOutstanding = obj.QuantityOutstanding;
           objNew.EarliestShipDate = obj.EarliestShipDate;
           objNew.PurchaseOrderValue = obj.PurchaseOrderValue;
           objNew.LineNotes = obj.LineNotes;
           objNew.QuantityReceived = obj.QuantityReceived;
           objNew.QuantityAllocated = obj.QuantityAllocated;
           objNew.GIShipInCost = obj.GIShipInCost;
           objNew.ProductName = obj.ProductName;
           objNew.ProductDescription = obj.ProductDescription;
           objNew.ProductDutyCode = obj.ProductDutyCode;
           objNew.PackageName = obj.PackageName;
           objNew.PackageDescription = obj.PackageDescription;
           objNew.ImportCountryShippingCost = obj.ImportCountryShippingCost;
           objNew.CurrencyNo = obj.CurrencyNo;
           objNew.CurrencyDescription = obj.CurrencyDescription;
           objNew.ManufacturerName = obj.ManufacturerName;
           objNew.TaxRate = obj.TaxRate;
           objNew.ClientNo = obj.ClientNo;
           objNew.QuantityToReturn = obj.QuantityToReturn;
           objNew.ExpediteDate = obj.ExpediteDate;
           objNew.Buyer = obj.Buyer;
           objNew.BuyerName = obj.BuyerName;
           objNew.DivisionNo = obj.DivisionNo;
           objNew.TeamNo = obj.TeamNo;
           objNew.FullName = obj.FullName;
           objNew.CreditLimit = obj.CreditLimit;
           objNew.Balance = obj.Balance;
           objNew.LineValue = obj.LineValue;
           objNew.TermsNo = obj.TermsNo;
           objNew.TermsName = obj.TermsName;
           objNew.InAdvance = obj.InAdvance;
           objNew.DatePromised = obj.DatePromised;
           objNew.ClientName = obj.ClientName;
           objNew.ClientDataVisibleToOthers = obj.ClientDataVisibleToOthers;
           return objNew;
       }

       #endregion
    
    }
}
