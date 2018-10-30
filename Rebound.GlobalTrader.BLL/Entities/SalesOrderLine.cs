/***********************************************************************************
Marker     changed by      date         Remarks
[1001]      Abhinav       01/09/20011   ESMS Ref:20 - Dsiplay Notes in Sales Order
[1002]      Vikas kumar   22/11/2011    ESMS Ref:21 - Add Country search option in Sales Order
[1003]      Vinay         21/08/2012    ESMS Ref:54 - If SO line created from Quote line then create hyperlink from sales order to quote
[1004]      Vinay          04/02/2014   CR:- Add AS9120 Requirement in GT application
[1005]      Aashu Singh     12/07/2018  REB-12593 :Show Contract number under notes.
[1006]      Aashu Singh     18/07/2018   REB-12614 :Sales order Confirmation requirements
[1007]      Aashu Singh     17-Aug-2018  Provision to add Global Security in Sales Order
*********************************************************************************/

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
    public partial class SalesOrderLine : BizObject
    {

        #region Properties

        protected static DAL.SalesOrderLineElement Settings
        {
            get { return Globals.Settings.SalesOrderLines; }
        }

        /// <summary>
        /// SalesOrderLineId
        /// </summary>
        public System.Int32 SalesOrderLineId { get; set; }
        /// <summary>
        /// SalesOrderNo
        /// </summary>
        public System.Int32 SalesOrderNo { get; set; }
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
        /// DatePromised
        /// </summary>
        public System.DateTime DatePromised { get; set; }
        /// <summary>
        /// RequiredDate
        /// </summary>
        public System.DateTime RequiredDate { get; set; }
        /// <summary>
        /// Instructions
        /// </summary>
        public System.String Instructions { get; set; }
        /// <summary>
        /// ProductNo
        /// </summary>
        public System.Int32? ProductNo { get; set; }
        /// <summary>
        /// Taxable
        /// </summary>
        public System.String Taxable { get; set; }
        /// <summary>
        /// CustomerPart
        /// </summary>
        public System.String CustomerPart { get; set; }
        /// <summary>
        /// Posted
        /// </summary>
        public System.Boolean Posted { get; set; }
        /// <summary>
        /// ShipASAP
        /// </summary>
        public System.Boolean ShipASAP { get; set; }
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
        /// ServiceNo
        /// </summary>
        public System.Int32? ServiceNo { get; set; }
        /// <summary>
        /// StockNo
        /// </summary>
        public System.Int32? StockNo { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public System.String Notes { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime DLUP { get; set; }
        /// <summary>
        /// FullCustomerPart
        /// </summary>
        public System.String FullCustomerPart { get; set; }
        /// <summary>
        /// ServiceShipped
        /// </summary>
        public System.Boolean ServiceShipped { get; set; }
        /// <summary>
        /// SalesOrderNumber
        /// </summary>
        public System.Int32 SalesOrderNumber { get; set; }
        /// <summary>
        /// ManufacturerCode
        /// </summary>
        public System.String ManufacturerCode { get; set; }
        /// <summary>
        /// QuantityShipped
        /// </summary>
        public System.Int32 QuantityShipped { get; set; }
        /// <summary>
        /// CompanyNo
        /// </summary>
        public System.Int32 CompanyNo { get; set; }
        /// <summary>
        /// CompanyName
        /// </summary>
        public System.String CompanyName { get; set; }
        /// <summary>
        /// ContactNo
        /// </summary>
        public System.Int32 ContactNo { get; set; }
        /// <summary>
        /// ContactName
        /// </summary>
        public System.String ContactName { get; set; }
        /// <summary>
        /// DateOrdered
        /// </summary>
        public System.DateTime DateOrdered { get; set; }
        /// <summary>
        /// CustomerPO
        /// </summary>
        public System.String CustomerPO { get; set; }
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
        /// QuantityAllocated
        /// </summary>
        public System.Int32? QuantityAllocated { get; set; }
        /// <summary>
        /// AllocationId
        /// </summary>
        public System.Int32? AllocationId { get; set; }
        /// <summary>
        /// QuantityOrdered
        /// </summary>
        public System.Int32 QuantityOrdered { get; set; }
        /// <summary>
        /// QuantityInStock
        /// </summary>
        public System.Int32? QuantityInStock { get; set; }
        /// <summary>
        /// CurrencyCode
        /// </summary>
        public System.String CurrencyCode { get; set; }
        /// <summary>
        /// BackOrderQuantity
        /// </summary>
        public System.Int32 BackOrderQuantity { get; set; }
        /// <summary>
        /// AllocatedQuantity
        /// </summary>
        public System.Int32? AllocatedQuantity { get; set; }
        /// <summary>
        /// SalesmanName
        /// </summary>
        public System.String SalesmanName { get; set; }
        /// <summary>
        /// SalesOrderId
        /// </summary>
        public System.Int32 SalesOrderId { get; set; }
        /// <summary>
        /// CurrencyDate
        /// </summary>
        public System.DateTime? CurrencyDate { get; set; }
        /// <summary>
        /// ClientNo
        /// </summary>
        public System.Int32 ClientNo { get; set; }
        /// <summary>
        /// Salesman
        /// </summary>
        public System.Int32 Salesman { get; set; }
        /// <summary>
        /// DivisionNo
        /// </summary>
        public System.Int32 DivisionNo { get; set; }
        /// <summary>
        /// TeamNo
        /// </summary>
        public System.Int32? TeamNo { get; set; }
        /// <summary>
        /// LineValue
        /// </summary>
        public System.Double LineValue { get; set; }
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
        /// Paid
        /// </summary>
        public System.Boolean Paid { get; set; }
        /// <summary>
        /// TermsNo
        /// </summary>
        public System.Int32 TermsNo { get; set; }
        /// <summary>
        /// ShipViaNo
        /// </summary>
        public System.Int32? ShipViaNo { get; set; }
        /// <summary>
        /// ShipToAddressNo
        /// </summary>
        public System.Int32? ShipToAddressNo { get; set; }
        /// <summary>
        /// Unauthorised
        /// </summary>
        public System.Int32 Unauthorised { get; set; }
        /// <summary>
        /// TermsName
        /// </summary>
        public System.String TermsName { get; set; }
        /// <summary>
        /// InAdvance
        /// </summary>
        public System.Boolean InAdvance { get; set; }
        /// <summary>
        /// CurrencyNo
        /// </summary>
        public System.Int32 CurrencyNo { get; set; }
        /// <summary>
        /// CurrencyDescription
        /// </summary>
        public System.String CurrencyDescription { get; set; }
        /// <summary>
        /// SalesOrderValue
        /// </summary>
        public System.Double? SalesOrderValue { get; set; }
        /// <summary>
        /// FullName
        /// </summary>
        public System.String FullName { get; set; }
        /// <summary>
        /// OnStop
        /// </summary>
        public System.Boolean? OnStop { get; set; }
        /// <summary>
        /// CreditLimit
        /// </summary>
        public System.Double CreditLimit { get; set; }
        /// <summary>
        /// Balance
        /// </summary>
        public System.Double Balance { get; set; }
        /// <summary>
        /// LineNotes
        /// </summary>
        public System.String LineNotes { get; set; }
        /// <summary>
        /// ExchangeRate
        /// </summary>
        public System.Double? ExchangeRate { get; set; }
        /// <summary>
        /// Location
        /// </summary>
        public System.String Location { get; set; }
        /// <summary>
        /// DeliveryDate
        /// </summary>
        public System.DateTime? DeliveryDate { get; set; }
        /// <summary>
        /// PurchaseOrderId
        /// </summary>
        public System.Int32? PurchaseOrderId { get; set; }
        /// <summary>
        /// PurchaseOrderNumber
        /// </summary>
        public System.Int32? PurchaseOrderNumber { get; set; }
        /// <summary>
        /// WarehouseNo
        /// </summary>
        public System.Int32? WarehouseNo { get; set; }
        /// <summary>
        /// WarehouseName
        /// </summary>
        public System.String WarehouseName { get; set; }
        /// <summary>
        /// SupplierNo
        /// </summary>
        public System.Int32? SupplierNo { get; set; }
        /// <summary>
        /// SupplierName
        /// </summary>
        public System.String SupplierName { get; set; }
        /// <summary>
        /// GoodsInLineNo
        /// </summary>
        public System.Int32? GoodsInLineNo { get; set; }
        /// <summary>
        /// GoodsInNo
        /// </summary>
        public System.Int32? GoodsInNo { get; set; }
        /// <summary>
        /// GoodsInNumber
        /// </summary>
        public System.Int32? GoodsInNumber { get; set; }
        /// <summary>
        /// TermsInAdvanceOK
        /// </summary>
        public System.Int32 TermsInAdvanceOK { get; set; }
        /// <summary>
        /// CreditLimitOK
        /// </summary>
        public System.Int32 CreditLimitOK { get; set; }
        /// <summary>
        /// StockUnavailable
        /// </summary>
        public System.Boolean StockUnavailable { get; set; }
        /// <summary>
        /// SalesOrderClosed
        /// </summary>
        public System.Boolean SalesOrderClosed { get; set; }
        /// <summary>
        /// GoodsInInspected
        /// </summary>
        public System.Int32 GoodsInInspected { get; set; }
        /// <summary>
        /// CompanyOnStop
        /// </summary>
        public System.Boolean? CompanyOnStop { get; set; }
        /// <summary>
        /// ServiceCost
        /// </summary>
        public System.Double? ServiceCost { get; set; }
        /// <summary>
        /// ServicePrice
        /// </summary>
        public System.Double? ServicePrice { get; set; }
        /// <summary>
        /// ReadyToShip
        /// </summary>
        public System.Boolean? ReadyToShip { get; set; }
        /// <summary>
        /// ShipViaName
        /// </summary>
        public System.String ShipViaName { get; set; }
        /// <summary>
        /// EarliestDatePromised
        /// </summary>
        public System.DateTime EarliestDatePromised { get; set; }
        /// <summary>
        /// NumberOfLines
        /// </summary>
        public System.Int32? NumberOfLines { get; set; }
        /// <summary>
        /// LandedCost
        /// </summary>
        public System.Double LandedCost { get; set; }
        /// <summary>
        /// ResalePrice
        /// </summary>
        public System.Double? ResalePrice { get; set; }
        /// <summary>
        /// SupplierPart
        /// </summary>
        public System.String SupplierPart { get; set; }
        /// <summary>
        /// PurchaseOrderLineNo
        /// </summary>
        public System.Int32? PurchaseOrderLineNo { get; set; }
        /// <summary>
        /// PurchasePrice
        /// </summary>
        public System.Double? PurchasePrice { get; set; }
        /// <summary>
        /// PurchaseOrderNo
        /// </summary>
        public System.Int32? PurchaseOrderNo { get; set; }
        /// <summary>
        /// CountryName
        /// </summary>
        public System.String CountryName { get; set; }
        /// <summary>
        /// Duty
        /// </summary>
        public System.Boolean? Duty { get; set; }
        /// <summary>
        /// DutyRate
        /// </summary>
        public System.Double? DutyRate { get; set; }
        /// <summary>
        /// QuantitySupplied
        /// </summary>
        public System.Int32? QuantitySupplied { get; set; }
        /// <summary>
        /// ShipInCost
        /// </summary>
        public System.Double ShipInCost { get; set; }
        /// <summary>
        /// SupplierType
        /// </summary>
        public System.String SupplierType { get; set; }
        /// <summary>
        /// DateReceived
        /// </summary>
        public System.DateTime DateReceived { get; set; }
        /// <summary>
        /// InvoiceDate
        /// </summary>
        public System.DateTime InvoiceDate { get; set; }
        /// <summary>
        /// Account
        /// </summary>
        public System.String Account { get; set; }
        /// <summary>
        /// Freight
        /// </summary>
        public System.Double Freight { get; set; }
        /// <summary>
        /// TaxNo
        /// </summary>
        public System.Int32 TaxNo { get; set; }
        /// <summary>
        /// ShippingCost
        /// </summary>
        public System.Double? ShippingCost { get; set; }
        /// <summary>
        /// StatusNo
        /// </summary>
        public System.Int32? StatusNo { get; set; }
        /// <summary>
        /// SaleTypeNo
        /// </summary>
        public System.Int32? SaleTypeNo { get; set; }
        /// <summary>
        /// Salesman2
        /// </summary>
        public System.Int32? Salesman2 { get; set; }
        /// <summary>
        /// Salesman2Percent
        /// </summary>
        public System.Double Salesman2Percent { get; set; }
        /// <summary>
        /// AuthorisedBy
        /// </summary>
        public System.Int32? AuthorisedBy { get; set; }
        /// <summary>
        /// DateAuthorised
        /// </summary>
        public System.DateTime? DateAuthorised { get; set; }
        /// <summary>
        /// IncotermNo
        /// </summary>
        public System.Int32? IncotermNo { get; set; }
        /// <summary>
        /// CreatedBy
        /// </summary>
        public System.Int32? CreatedBy { get; set; }
        /// <summary>
        /// CreateDate
        /// </summary>
        public System.DateTime? CreateDate { get; set; }
        /// <summary>
        /// InvoiceId
        /// </summary>
        public System.Int32 InvoiceId { get; set; }
        /// <summary>
        /// InvoiceNumber
        /// </summary>
        public System.Int32 InvoiceNumber { get; set; }
        /// <summary>
        /// CompanyShipTo
        /// </summary>
        public System.String CompanyShipTo { get; set; }
        /// <summary>
        /// CompanyBillTo
        /// </summary>
        public System.String CompanyBillTo { get; set; }
        /// <summary>
        /// FreeOnBoard
        /// </summary>
        public System.String FreeOnBoard { get; set; }
        /// <summary>
        /// Boxes
        /// </summary>
        public System.Int32? Boxes { get; set; }
        /// <summary>
        /// Weight
        /// </summary>
        public System.Double? Weight { get; set; }
        /// <summary>
        /// DimensionalWeight
        /// </summary>
        public System.Double? DimensionalWeight { get; set; }
        /// <summary>
        /// WeightInPounds
        /// </summary>
        public System.Boolean WeightInPounds { get; set; }
        /// <summary>
        /// AirWayBill
        /// </summary>
        public System.String AirWayBill { get; set; }
        /// <summary>
        /// ShippedBy
        /// </summary>
        public System.Int32? ShippedBy { get; set; }
        /// <summary>
        /// Printed
        /// </summary>
        public System.Int32? Printed { get; set; }
        /// <summary>
        /// SupplierRMANo
        /// </summary>
        public System.Int32? SupplierRMANo { get; set; }
        /// <summary>
        /// ShippingNotes
        /// </summary>
        public System.String ShippingNotes { get; set; }
        /// <summary>
        /// Exported
        /// </summary>
        public System.Boolean Exported { get; set; }
        /// <summary>
        /// InvoicePaid
        /// </summary>
        public System.Boolean InvoicePaid { get; set; }
        /// <summary>
        /// CofCNotes
        /// </summary>
        public System.String CofCNotes { get; set; }
        /// <summary>
        /// BillToAddressNo
        /// </summary>
        public System.Int32? BillToAddressNo { get; set; }
        /// <summary>
        /// DivisionNo2
        /// </summary>
        public System.Int32? DivisionNo2 { get; set; }
        /// <summary>
        /// DateExported
        /// </summary>
        public System.DateTime? DateExported { get; set; }
        /// <summary>
        /// ClientName
        /// </summary>
        public System.String ClientName { get; set; }
        /// <summary>
        /// ClientDataVisibleToOthers
        /// </summary>
        public System.Boolean? ClientDataVisibleToOthers { get; set; }
        //[1003] code start
        /// <summary>
        /// QuoteLineNo
        /// </summary>
        public System.Int32? QuoteLineNo { get; set; }
        //[1003] code end

        //[1004] code start
        /// <summary>
        /// ProductSource
        /// </summary>
        public System.Byte? ProductSource { get; set; }
        //[1004] code end
        /// <summary>
        /// blnCRMA
        /// </summary>
        public System.Boolean? blnCRMA { get; set; }
        /// <summary>
        /// SerialNo
        /// </summary>
        public System.Int16? SerialNo { get; set; }
        public bool IsIPO { get; set; }
        public bool IsChecked { get; set; }
        public int? IsSourcingResultExist { get; set; }

        public int? POHubSupplierNo { get; set; }

        public int? POQuoteLineNo { get; set; }
        public int? SourcingResultNo { get; set; }
        /// <summary>
        /// ClientSupplierNo
        /// </summary>
        public System.Int32? ClientSupplierNo { get; set; }
        /// <summary>
        /// ClientSupplierName
        /// </summary>
        public System.String ClientSupplierName { get; set; }

        public bool IsFromIPO { get; set; }
        public bool IsIPOHeaderCreated { get; set; }
        public bool? IsIPOCreatedForCurrentLine { get; set; }
        public int? InternalPurchaseOrderNumber { get; set; }
        public int? SourceingResultAttachedBy { get; set; }

        public int? SourceingResultNo { get; set; }

        public double? EstimatedShippingCost { get; set; }

        public DateTime? OriginalEntryDate { get; set; }

        public int? ClientCurrencyNo { get; set; }
        public string IPOSupplierName { get; set; }
        public int InternalPurchaseOrderNo { get; set; }
        public string IPOSupplierType { get; set; }
        public double? ClientLandedCost { get; set; }
        public string CreditStatus { get; set; }
        public System.Boolean? isClone { get; set; }
        public int?  SalesorderLineID { get; set; }
        public System.Int32? IPOApprovedBy { get; set; }
        public System.Int32? CloneID { get; set; }
        public System.Boolean? IsIPOExist { get; set; }
        public System.DateTime? PODeliveryDate { get; set; }
        /// <summary>
        /// SourcingResultUsedByOther
        /// </summary>
        public System.Boolean? SourcingResultUsedByOther { get; set; }
        public System.Boolean? IsIPOAndPOOpen { get; set; }
  
        public System.String ClientCode { get; set; }
        /// <summary>
        /// PurchaseBuyCurrencyNo
        /// </summary>
        public int? PurchaseBuyCurrencyNo { get; set; }
        public System.Int32? LinkMultiCurrencyNo { get; set; }
        public System.DateTime PODateOrdered { get; set; }
        /// <summary>
        /// IPOs
        /// </summary>
        public System.String IPOs { get; set; }
        /// <summary>
        /// ReceivingNotes
        /// </summary>
        public System.String ReceivingNotes { get; set; }
        public System.String DutyCode { get; set; }

        public System.Double? IPOPrice { get; set; }
        public System.Boolean? ReqSerialNumber { get; set; }



        public System.String IPOPriceWithCurrency { get; set; }
        /// <summary>
        /// SerialNo
        /// </summary>
        public System.Int16? CloneSerialNo { get; set; }
        public System.String MSLLevel { get; set; }
        public System.String ContractNo { get; set; }
        /// <summary>
        /// IsProdHazardous
        /// </summary>
        public System.Boolean? IsProdHazardous { get; set; }
        /// <summary>
        /// PrintHazardous
        /// </summary>
        public System.Boolean? PrintHazardous { get; set; }
        //[1006] start
        /// <summary>
        /// IsConfirmed
        /// </summary>
        public System.Boolean IsConfirmed { get; set; }
        /// <summary>
        /// DateConfirmed
        /// </summary>
        public System.DateTime? DateConfirmed { get; set; }
        //[1006] end
        #endregion

        #region Methods

        /// <summary>
        /// CountAsPurchaseRequisitionForClient
        /// Calls [usp_count_SalesOrderLine_as_PurchaseRequisition_for_Client]
        /// </summary>
        public static Int32 CountAsPurchaseRequisitionForClient(System.Int32? clientId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.CountAsPurchaseRequisitionForClient(clientId);
        }		/// <summary>
        /// DataListNugget
        /// Calls [usp_datalistnugget_SalesOrderLine]
        /// </summary>
        //[1002],[1007]Code Start
        public static List<SalesOrderLine> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.Int32? CountrySearch, System.String cmSearch, System.Int32? salesmanNo, System.String customerPoSearch, System.Boolean? recentOnly, System.Boolean? includeClosed, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo, System.Boolean? unauthorisedOnly, System.Int32? IncludeOrderSent, System.String ContractNo, Boolean IsGlobalLogin, System.Int32? clientSearch)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.DataListNugget(clientId, teamId, divisionId, loginId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, CountrySearch, cmSearch, salesmanNo, customerPoSearch, recentOnly, includeClosed, salesOrderNoLo, salesOrderNoHi, dateOrderedFrom, dateOrderedTo, datePromisedFrom, datePromisedTo, unauthorisedOnly, IncludeOrderSent, ContractNo, IsGlobalLogin,clientSearch);
            //[1002]Code End 
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.Quantity = objDetails.Quantity;
                    obj.QuantityShipped = objDetails.QuantityShipped;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.RequiredDate = objDetails.RequiredDate;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.Status = objDetails.Status;
                    obj.QuantityInStock = objDetails.QuantityInStock;
                    obj.ContractNo = objDetails.ContractNo;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// DataListNuggetAllForShipping
        /// Calls [usp_datalistnugget_SalesOrderLine_AllForShipping]
        /// </summary>
        public static List<SalesOrderLine> DataListNuggetAllForShipping(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanNo, System.String customerPoSearch, System.Boolean? recentOnly, System.Boolean? includeClosed, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo, System.Int32? clientSearch, Boolean IsGlobalLogin)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.DataListNuggetAllForShipping(clientId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, salesmanNo, customerPoSearch, recentOnly, includeClosed, salesOrderNoLo, salesOrderNoHi, dateOrderedFrom, dateOrderedTo, datePromisedFrom, datePromisedTo, clientSearch, IsGlobalLogin);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                    obj.Part = objDetails.Part;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.AllocationId = objDetails.AllocationId;
                    obj.QuantityOrdered = objDetails.QuantityOrdered;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.RequiredDate = objDetails.RequiredDate;
                    obj.ShipASAP = objDetails.ShipASAP;
                    obj.QuantityInStock = objDetails.QuantityInStock;
                    obj.ROHS = objDetails.ROHS;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.CreditStatus = objDetails.CreditStatus;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.ClientName = objDetails.ClientName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// DataListNuggetAsPurchaseRequisition
        /// Calls [usp_datalistnugget_SalesOrderLine_as_PurchaseRequisition]
        /// </summary>
        public static List<SalesOrderLine> DataListNuggetAsPurchaseRequisition(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.DataListNuggetAsPurchaseRequisition(clientId, teamId, divisionId, loginId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, salesmanSearch, salesOrderNoLo, salesOrderNoHi, dateOrderedFrom, dateOrderedTo);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.Part = objDetails.Part;
                    obj.Price = objDetails.Price;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.BackOrderQuantity = objDetails.BackOrderQuantity;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ROHS = objDetails.ROHS;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
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
        /// DataListNuggetReadyToShip
        /// Calls [usp_datalistnugget_SalesOrderLine_ReadyToShip]
        /// </summary>
        public static List<SalesOrderLine> DataListNuggetReadyToShip(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanNo, System.String customerPoSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo, System.Int32? clientSearch, Boolean IsGlobalLogin)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.DataListNuggetReadyToShip(clientId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, salesmanNo, customerPoSearch, salesOrderNoLo, salesOrderNoHi, dateOrderedFrom, dateOrderedTo, datePromisedFrom, datePromisedTo, clientSearch, IsGlobalLogin);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                    obj.Part = objDetails.Part;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.ShipASAP = objDetails.ShipASAP;
                    obj.AllocatedQuantity = objDetails.AllocatedQuantity;
                    obj.QuantityOrdered = objDetails.QuantityOrdered;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.RequiredDate = objDetails.RequiredDate;
                    obj.StockNo = objDetails.StockNo;
                    obj.ROHS = objDetails.ROHS;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.ClientName = objDetails.ClientName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Delete
        /// Calls [usp_delete_SalesOrderLine]
        /// </summary>
        public static bool Delete(System.Int32? salesOrderLineId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.Delete(salesOrderLineId);
        }
        /// <summary>
        /// usp_insert_Clone_SalesOrderLine
        /// </summary>
        /// <param name="salesOrderNo"></param>
        /// <param name="part"></param>
      
        /// <returns></returns>
        public static Int32 CreateCloneSOLine(System.Int32? salesOrderNo, System.Int32? quantity, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.DateTime? poDeleveryDate, System.Int32? updatedBy, int? sourcingResultNo, int? SalesorderLineID, System.Boolean? IsIPO, System.Int32? InternalPurchaseOrderNo, System.String Notes, System.String Instruction, Int32? Flag, System.Byte? productSource, out string Message)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.CreateCloneSOLine(salesOrderNo, quantity, price, datePromised, requiredDate, poDeleveryDate, updatedBy, sourcingResultNo, SalesorderLineID, IsIPO, InternalPurchaseOrderNo, Notes, Instruction, Flag, productSource, out Message);
            return objReturn;
        }

        //[1003],[1004] code start
        /// <summary>
        /// Insert
        /// Calls [usp_insert_SalesOrderLine]
        /// </summary>
        public static Int32 Insert(System.Int32? salesOrderNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.String instructions, System.Int32? productNo, System.String taxable, System.String customerPart, System.Boolean? posted, System.Boolean? shipAsap, System.Int32? serviceNo, System.Int32? stockNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Int32? QuoteLineNo, System.Byte? productSource, int? sourcingResultNo, System.DateTime? poDeliveryDate, System.String mslLevel, System.String ContractNo, System.Boolean? printHazardous)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.Insert(salesOrderNo, part, manufacturerNo, dateCode, packageNo, quantity, price, datePromised, requiredDate, instructions, productNo, taxable, customerPart, posted, shipAsap, serviceNo, stockNo, rohs, notes, updatedBy, QuoteLineNo, productSource, sourcingResultNo, poDeliveryDate, mslLevel, ContractNo, printHazardous);
            return objReturn;
        }

        /// <summary>
        /// Insert (without parameters)
        /// Calls [usp_insert_SalesOrderLine]
        /// </summary>
        public Int32 Insert()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.Insert(SalesOrderNo, Part, ManufacturerNo, DateCode, PackageNo, Quantity, Price, DatePromised, RequiredDate, Instructions, ProductNo, Taxable, CustomerPart, Posted, ShipASAP, ServiceNo, StockNo, ROHS, Notes, UpdatedBy, QuoteLineNo, ProductSource, null, null, MSLLevel, ContractNo, PrintHazardous);
        }
        //[1003],[1004] code end
        /// <summary>
        /// InsertFromQuoteLine
        /// Calls [usp_insert_SalesOrderLine_from_QuoteLine]
        /// </summary>
        public static Int32 InsertFromQuoteLine(System.Int32? quoteLineId, System.Int32? salesOrderNo, System.DateTime? dateOrdered, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.InsertFromQuoteLine(quoteLineId, salesOrderNo, dateOrdered, updatedBy);
            return objReturn;
        }
        /// <summary>
        /// ItemSearch
        /// Calls [usp_itemsearch_SalesOrderLine]
        /// </summary>
        public static List<SalesOrderLine> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String customerPoSearch, System.Boolean? includeClosed, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo, bool? onlyFromIPO) 
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, partSearch, cmSearch, salesmanSearch, customerPoSearch, includeClosed, salesOrderNoLo, salesOrderNoHi, dateOrderedFrom, dateOrderedTo, datePromisedFrom, datePromisedTo,onlyFromIPO);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.Price = objDetails.Price;
                    obj.CurrencyCode = objDetails.CurrencyCode;
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
        /// ItemSearchAsPurchaseRequisition
        /// Calls [usp_itemsearch_SalesOrderLine_as_PurchaseRequisition]
        /// </summary>
        public static List<SalesOrderLine> ItemSearchAsPurchaseRequisition(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Int32? salesmanSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.ItemSearchAsPurchaseRequisition(clientId, orderBy, sortDir, pageIndex, pageSize, partSearch, cmSearch, salesmanSearch, salesOrderNoLo, salesOrderNoHi, dateOrderedFrom, dateOrderedTo);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.Price = objDetails.Price;
                    obj.QuantityOrdered = objDetails.QuantityOrdered;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.Part = objDetails.Part;
                    obj.ROHS = objDetails.ROHS;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.SerialNo = objDetails.SerialNo;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// ListForAuthorisationByClientWithFilter
        /// Calls [usp_list_SalesOrderLine_ForAuthorisation_by_Client_with_filter]
        /// </summary>
        public static List<SalesOrderLine> ListForAuthorisationByClientWithFilter(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.ListForAuthorisationByClientWithFilter(clientId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, salesmanSearch, customerPoSearch, salesOrderNoLo, salesOrderNoHi, dateOrderedFrom, dateOrderedTo, datePromisedFrom, datePromisedTo);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.FullPart = objDetails.FullPart;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.DateCode = objDetails.DateCode;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.RequiredDate = objDetails.RequiredDate;
                    obj.Instructions = objDetails.Instructions;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.Taxable = objDetails.Taxable;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.Posted = objDetails.Posted;
                    obj.ShipASAP = objDetails.ShipASAP;
                    obj.ServiceNo = objDetails.ServiceNo;
                    obj.Inactive = objDetails.Inactive;
                    obj.ROHS = objDetails.ROHS;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.SalesOrderId = objDetails.SalesOrderId;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.CurrencyDate = objDetails.CurrencyDate;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.Salesman = objDetails.Salesman;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.LineValue = objDetails.LineValue;
                    obj.QuantityOrdered = objDetails.QuantityOrdered;
                    obj.QuantityShipped = objDetails.QuantityShipped;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.BackOrderQuantity = objDetails.BackOrderQuantity;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.Paid = objDetails.Paid;
                    obj.Closed = objDetails.Closed;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.ShipViaNo = objDetails.ShipViaNo;
                    obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                    obj.Unauthorised = objDetails.Unauthorised;
                    obj.TermsName = objDetails.TermsName;
                    obj.InAdvance = objDetails.InAdvance;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.SalesOrderValue = objDetails.SalesOrderValue;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.RowNum = objDetails.RowNum;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// ListForAuthorisationByDivisionWithFilter
        /// Calls [usp_list_SalesOrderLine_ForAuthorisation_by_Division_with_filter]
        /// </summary>
        public static List<SalesOrderLine> ListForAuthorisationByDivisionWithFilter(System.Int32? divisionId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.ListForAuthorisationByDivisionWithFilter(divisionId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, salesmanSearch, customerPoSearch, salesOrderNoLo, salesOrderNoHi, dateOrderedFrom, dateOrderedTo, datePromisedFrom, datePromisedTo);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.FullPart = objDetails.FullPart;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.DateCode = objDetails.DateCode;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.RequiredDate = objDetails.RequiredDate;
                    obj.Instructions = objDetails.Instructions;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.Taxable = objDetails.Taxable;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.Posted = objDetails.Posted;
                    obj.ShipASAP = objDetails.ShipASAP;
                    obj.ServiceNo = objDetails.ServiceNo;
                    obj.Inactive = objDetails.Inactive;
                    obj.ROHS = objDetails.ROHS;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.SalesOrderId = objDetails.SalesOrderId;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.CurrencyDate = objDetails.CurrencyDate;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.Salesman = objDetails.Salesman;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.LineValue = objDetails.LineValue;
                    obj.QuantityOrdered = objDetails.QuantityOrdered;
                    obj.QuantityShipped = objDetails.QuantityShipped;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.BackOrderQuantity = objDetails.BackOrderQuantity;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.Paid = objDetails.Paid;
                    obj.Closed = objDetails.Closed;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.ShipViaNo = objDetails.ShipViaNo;
                    obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                    obj.Unauthorised = objDetails.Unauthorised;
                    obj.TermsName = objDetails.TermsName;
                    obj.InAdvance = objDetails.InAdvance;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.SalesOrderValue = objDetails.SalesOrderValue;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.RowNum = objDetails.RowNum;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// ListForAuthorisationByLoginWithFilter
        /// Calls [usp_list_SalesOrderLine_ForAuthorisation_by_Login_with_filter]
        /// </summary>
        public static List<SalesOrderLine> ListForAuthorisationByLoginWithFilter(System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.ListForAuthorisationByLoginWithFilter(loginId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, salesmanSearch, customerPoSearch, salesOrderNoLo, salesOrderNoHi, dateOrderedFrom, dateOrderedTo, datePromisedFrom, datePromisedTo);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.FullPart = objDetails.FullPart;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.DateCode = objDetails.DateCode;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.RequiredDate = objDetails.RequiredDate;
                    obj.Instructions = objDetails.Instructions;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.Taxable = objDetails.Taxable;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.Posted = objDetails.Posted;
                    obj.ShipASAP = objDetails.ShipASAP;
                    obj.ServiceNo = objDetails.ServiceNo;
                    obj.Inactive = objDetails.Inactive;
                    obj.ROHS = objDetails.ROHS;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.SalesOrderId = objDetails.SalesOrderId;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.CurrencyDate = objDetails.CurrencyDate;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.Salesman = objDetails.Salesman;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.LineValue = objDetails.LineValue;
                    obj.QuantityOrdered = objDetails.QuantityOrdered;
                    obj.QuantityShipped = objDetails.QuantityShipped;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.BackOrderQuantity = objDetails.BackOrderQuantity;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.Paid = objDetails.Paid;
                    obj.Closed = objDetails.Closed;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.ShipViaNo = objDetails.ShipViaNo;
                    obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                    obj.Unauthorised = objDetails.Unauthorised;
                    obj.TermsName = objDetails.TermsName;
                    obj.InAdvance = objDetails.InAdvance;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.SalesOrderValue = objDetails.SalesOrderValue;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.RowNum = objDetails.RowNum;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// ListForAuthorisationByTeamWithFilter
        /// Calls [usp_list_SalesOrderLine_ForAuthorisation_by_Team_with_filter]
        /// </summary>
        public static List<SalesOrderLine> ListForAuthorisationByTeamWithFilter(System.Int32? teamId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.ListForAuthorisationByTeamWithFilter(teamId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, salesmanSearch, customerPoSearch, salesOrderNoLo, salesOrderNoHi, dateOrderedFrom, dateOrderedTo, datePromisedFrom, datePromisedTo);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.FullPart = objDetails.FullPart;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.DateCode = objDetails.DateCode;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.RequiredDate = objDetails.RequiredDate;
                    obj.Instructions = objDetails.Instructions;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.Taxable = objDetails.Taxable;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.Posted = objDetails.Posted;
                    obj.ShipASAP = objDetails.ShipASAP;
                    obj.ServiceNo = objDetails.ServiceNo;
                    obj.Inactive = objDetails.Inactive;
                    obj.ROHS = objDetails.ROHS;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.SalesOrderId = objDetails.SalesOrderId;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.CurrencyDate = objDetails.CurrencyDate;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.Salesman = objDetails.Salesman;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.LineValue = objDetails.LineValue;
                    obj.QuantityOrdered = objDetails.QuantityOrdered;
                    obj.QuantityShipped = objDetails.QuantityShipped;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.BackOrderQuantity = objDetails.BackOrderQuantity;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.Paid = objDetails.Paid;
                    obj.Closed = objDetails.Closed;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.ShipViaNo = objDetails.ShipViaNo;
                    obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                    obj.Unauthorised = objDetails.Unauthorised;
                    obj.TermsName = objDetails.TermsName;
                    obj.InAdvance = objDetails.InAdvance;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.SalesOrderValue = objDetails.SalesOrderValue;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.RowNum = objDetails.RowNum;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// ListShipByClientWithFilter
        /// Calls [usp_list_SalesOrderLine_Ship_by_Client_with_filter]
        /// </summary>
        public static List<SalesOrderLine> ListShipByClientWithFilter(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Boolean? includeHistory, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.ListShipByClientWithFilter(clientId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, salesmanSearch, customerPoSearch, includeHistory, salesOrderNoLo, salesOrderNoHi, dateOrderedFrom, dateOrderedTo, datePromisedFrom, datePromisedTo);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderId = objDetails.SalesOrderId;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.CurrencyDate = objDetails.CurrencyDate;
                    obj.RequiredDate = objDetails.RequiredDate;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.Salesman = objDetails.Salesman;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.FullName = objDetails.FullName;
                    obj.OnStop = objDetails.OnStop;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.Balance = objDetails.Balance;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.Price = objDetails.Price;
                    obj.LineValue = objDetails.LineValue;
                    obj.QuantityOrdered = objDetails.QuantityOrdered;
                    obj.QuantityShipped = objDetails.QuantityShipped;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.BackOrderQuantity = objDetails.BackOrderQuantity;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.FullPart = objDetails.FullPart;
                    obj.Part = objDetails.Part;
                    obj.ROHS = objDetails.ROHS;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.FullCustomerPart = objDetails.FullCustomerPart;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.DateCode = objDetails.DateCode;
                    obj.Quantity = objDetails.Quantity;
                    obj.Instructions = objDetails.Instructions;
                    obj.Taxable = objDetails.Taxable;
                    obj.Posted = objDetails.Posted;
                    obj.ShipASAP = objDetails.ShipASAP;
                    obj.ServiceNo = objDetails.ServiceNo;
                    obj.Inactive = objDetails.Inactive;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.Unauthorised = objDetails.Unauthorised;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.Paid = objDetails.Paid;
                    obj.Closed = objDetails.Closed;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.ShipViaNo = objDetails.ShipViaNo;
                    obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                    obj.TermsName = objDetails.TermsName;
                    obj.InAdvance = objDetails.InAdvance;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.AllocatedQuantity = objDetails.AllocatedQuantity;
                    obj.StockNo = objDetails.StockNo;
                    obj.QuantityInStock = objDetails.QuantityInStock;
                    obj.SalesOrderValue = objDetails.SalesOrderValue;
                    obj.AllocationId = objDetails.AllocationId;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.RowNum = objDetails.RowNum;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// ListShipByDivisionWithFilter
        /// Calls [usp_list_SalesOrderLine_Ship_by_Division_with_filter]
        /// </summary>
        public static List<SalesOrderLine> ListShipByDivisionWithFilter(System.Int32? divisionId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Boolean? includeHistory, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.ListShipByDivisionWithFilter(divisionId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, salesmanSearch, customerPoSearch, includeHistory, salesOrderNoLo, salesOrderNoHi, dateOrderedFrom, dateOrderedTo, datePromisedFrom, datePromisedTo);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderId = objDetails.SalesOrderId;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.CurrencyDate = objDetails.CurrencyDate;
                    obj.RequiredDate = objDetails.RequiredDate;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.Salesman = objDetails.Salesman;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.FullName = objDetails.FullName;
                    obj.OnStop = objDetails.OnStop;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.Balance = objDetails.Balance;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.Price = objDetails.Price;
                    obj.LineValue = objDetails.LineValue;
                    obj.QuantityOrdered = objDetails.QuantityOrdered;
                    obj.QuantityShipped = objDetails.QuantityShipped;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.BackOrderQuantity = objDetails.BackOrderQuantity;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.FullPart = objDetails.FullPart;
                    obj.Part = objDetails.Part;
                    obj.ROHS = objDetails.ROHS;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.FullCustomerPart = objDetails.FullCustomerPart;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.DateCode = objDetails.DateCode;
                    obj.Quantity = objDetails.Quantity;
                    obj.Instructions = objDetails.Instructions;
                    obj.Taxable = objDetails.Taxable;
                    obj.Posted = objDetails.Posted;
                    obj.ShipASAP = objDetails.ShipASAP;
                    obj.ServiceNo = objDetails.ServiceNo;
                    obj.Inactive = objDetails.Inactive;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.Unauthorised = objDetails.Unauthorised;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.Paid = objDetails.Paid;
                    obj.Closed = objDetails.Closed;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.ShipViaNo = objDetails.ShipViaNo;
                    obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                    obj.TermsName = objDetails.TermsName;
                    obj.InAdvance = objDetails.InAdvance;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.AllocatedQuantity = objDetails.AllocatedQuantity;
                    obj.StockNo = objDetails.StockNo;
                    obj.QuantityInStock = objDetails.QuantityInStock;
                    obj.SalesOrderValue = objDetails.SalesOrderValue;
                    obj.AllocationId = objDetails.AllocationId;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.RowNum = objDetails.RowNum;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// ListShipByLoginWithFilter
        /// Calls [usp_list_SalesOrderLine_Ship_by_Login_with_filter]
        /// </summary>
        public static List<SalesOrderLine> ListShipByLoginWithFilter(System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Boolean? includeHistory, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.ListShipByLoginWithFilter(loginId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, salesmanSearch, customerPoSearch, includeHistory, salesOrderNoLo, salesOrderNoHi, dateOrderedFrom, dateOrderedTo, datePromisedFrom, datePromisedTo);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderId = objDetails.SalesOrderId;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.CurrencyDate = objDetails.CurrencyDate;
                    obj.RequiredDate = objDetails.RequiredDate;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.Salesman = objDetails.Salesman;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.FullName = objDetails.FullName;
                    obj.OnStop = objDetails.OnStop;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.Balance = objDetails.Balance;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.Price = objDetails.Price;
                    obj.LineValue = objDetails.LineValue;
                    obj.QuantityOrdered = objDetails.QuantityOrdered;
                    obj.QuantityShipped = objDetails.QuantityShipped;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.BackOrderQuantity = objDetails.BackOrderQuantity;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.FullPart = objDetails.FullPart;
                    obj.Part = objDetails.Part;
                    obj.ROHS = objDetails.ROHS;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.FullCustomerPart = objDetails.FullCustomerPart;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.DateCode = objDetails.DateCode;
                    obj.Quantity = objDetails.Quantity;
                    obj.Instructions = objDetails.Instructions;
                    obj.Taxable = objDetails.Taxable;
                    obj.Posted = objDetails.Posted;
                    obj.ShipASAP = objDetails.ShipASAP;
                    obj.ServiceNo = objDetails.ServiceNo;
                    obj.Inactive = objDetails.Inactive;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.Unauthorised = objDetails.Unauthorised;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.Paid = objDetails.Paid;
                    obj.Closed = objDetails.Closed;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.ShipViaNo = objDetails.ShipViaNo;
                    obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                    obj.TermsName = objDetails.TermsName;
                    obj.InAdvance = objDetails.InAdvance;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.AllocatedQuantity = objDetails.AllocatedQuantity;
                    obj.StockNo = objDetails.StockNo;
                    obj.QuantityInStock = objDetails.QuantityInStock;
                    obj.SalesOrderValue = objDetails.SalesOrderValue;
                    obj.AllocationId = objDetails.AllocationId;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.RowNum = objDetails.RowNum;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// ListShipByTeamWithFilter
        /// Calls [usp_list_SalesOrderLine_Ship_by_Team_with_filter]
        /// </summary>
        public static List<SalesOrderLine> ListShipByTeamWithFilter(System.Int32? teamId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.String salesmanSearch, System.String customerPoSearch, System.Boolean? includeHistory, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.ListShipByTeamWithFilter(teamId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, salesmanSearch, customerPoSearch, includeHistory, salesOrderNoLo, salesOrderNoHi, dateOrderedFrom, dateOrderedTo, datePromisedFrom, datePromisedTo);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderId = objDetails.SalesOrderId;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.CurrencyDate = objDetails.CurrencyDate;
                    obj.RequiredDate = objDetails.RequiredDate;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.Salesman = objDetails.Salesman;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.FullName = objDetails.FullName;
                    obj.OnStop = objDetails.OnStop;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.Balance = objDetails.Balance;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.Price = objDetails.Price;
                    obj.LineValue = objDetails.LineValue;
                    obj.QuantityOrdered = objDetails.QuantityOrdered;
                    obj.QuantityShipped = objDetails.QuantityShipped;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.BackOrderQuantity = objDetails.BackOrderQuantity;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.FullPart = objDetails.FullPart;
                    obj.Part = objDetails.Part;
                    obj.ROHS = objDetails.ROHS;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.FullCustomerPart = objDetails.FullCustomerPart;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.DateCode = objDetails.DateCode;
                    obj.Quantity = objDetails.Quantity;
                    obj.Instructions = objDetails.Instructions;
                    obj.Taxable = objDetails.Taxable;
                    obj.Posted = objDetails.Posted;
                    obj.ShipASAP = objDetails.ShipASAP;
                    obj.ServiceNo = objDetails.ServiceNo;
                    obj.Inactive = objDetails.Inactive;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.Unauthorised = objDetails.Unauthorised;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.Paid = objDetails.Paid;
                    obj.Closed = objDetails.Closed;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.ShipViaNo = objDetails.ShipViaNo;
                    obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                    obj.TermsName = objDetails.TermsName;
                    obj.InAdvance = objDetails.InAdvance;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.AllocatedQuantity = objDetails.AllocatedQuantity;
                    obj.StockNo = objDetails.StockNo;
                    obj.QuantityInStock = objDetails.QuantityInStock;
                    obj.SalesOrderValue = objDetails.SalesOrderValue;
                    obj.AllocationId = objDetails.AllocationId;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.RowNum = objDetails.RowNum;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Get
        /// Calls [usp_select_SalesOrderLine]
        /// </summary>
        public static SalesOrderLine Get(System.Int32? salesOrderLineId)
        {
            Rebound.GlobalTrader.DAL.SalesOrderLineDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.Get(salesOrderLineId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SalesOrderLine obj = new SalesOrderLine();
                obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                obj.SalesOrderNo = objDetails.SalesOrderNo;
                obj.FullPart = objDetails.FullPart;
                obj.Part = objDetails.Part;
                obj.ManufacturerNo = objDetails.ManufacturerNo;
                obj.DateCode = objDetails.DateCode;
                obj.PackageNo = objDetails.PackageNo;
                obj.Quantity = objDetails.Quantity;
                obj.Price = objDetails.Price;
                obj.DatePromised = objDetails.DatePromised;
                obj.RequiredDate = objDetails.RequiredDate;
                obj.Instructions = objDetails.Instructions;
                obj.ProductNo = objDetails.ProductNo;
                obj.Taxable = objDetails.Taxable;
                obj.CustomerPart = objDetails.CustomerPart;
                obj.Posted = objDetails.Posted;
                obj.ShipASAP = objDetails.ShipASAP;
                obj.Inactive = objDetails.Inactive;
                obj.Closed = objDetails.Closed;
                obj.ROHS = objDetails.ROHS;
                obj.ServiceNo = objDetails.ServiceNo;
                obj.StockNo = objDetails.StockNo;
                obj.LineNotes = objDetails.LineNotes;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.QuantityShipped = objDetails.QuantityShipped;
                obj.QuantityAllocated = objDetails.QuantityAllocated;
                obj.BackOrderQuantity = objDetails.BackOrderQuantity;
                obj.ProductName = objDetails.ProductName;
                obj.ProductDescription = objDetails.ProductDescription;
                obj.PackageName = objDetails.PackageName;
                obj.PackageDescription = objDetails.PackageDescription;
                obj.ManufacturerName = objDetails.ManufacturerName;
                obj.ManufacturerCode = objDetails.ManufacturerCode;
                obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                obj.CustomerPO = objDetails.CustomerPO;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.ClientNo = objDetails.ClientNo;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.CompanyName = objDetails.CompanyName;
                obj.OnStop = objDetails.OnStop;
                obj.CreditLimit = objDetails.CreditLimit;
                obj.Balance = objDetails.Balance;
                obj.DateOrdered = objDetails.DateOrdered;
                obj.CurrencyDate = objDetails.CurrencyDate;
                obj.Salesman = objDetails.Salesman;
                obj.ExchangeRate = objDetails.ExchangeRate;
                obj.ServiceShipped = objDetails.ServiceShipped;
                //[1003] code start
                obj.QuoteLineNo = objDetails.QuoteLineNo;
                //[1003] code end
                //[1004] code start
                obj.ProductSource = objDetails.ProductSource;
                obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
                obj.SourcingResultNo = objDetails.SourcingResultNo;
                //[1004] code end
                obj.IPOApprovedBy = objDetails.IPOApprovedBy;
                obj.InternalPurchaseOrderNo = objDetails.InternalPurchaseOrderNo;
                obj.IsIPOExist = objDetails.IsIPOExist;
                obj.IsIPO = objDetails.IsIPO;
                obj.PODeliveryDate = objDetails.PODeliveryDate;
                obj.SourcingResultUsedByOther = objDetails.SourcingResultUsedByOther;
                obj.IsIPOAndPOOpen = objDetails.IsIPOAndPOOpen;
                obj.SerialNo = objDetails.SerialNo;
                obj.ProductInactive = objDetails.ProductInactive;
                obj.DutyCode = objDetails.DutyCode;
                obj.DutyRate = objDetails.DutyRate;
                obj.CloneSerialNo = objDetails.CloneSerialNo;
                obj.MSLLevel = objDetails.MSLLevel;
                obj.ContractNo = objDetails.ContractNo;
                obj.IsProdHazardous = objDetails.IsProdHazardous;
                obj.PrintHazardous = objDetails.PrintHazardous;
                //[1006] start
                obj.DateConfirmed = objDetails.DateConfirmed;
                //[1006] end
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetAllocation
        /// Calls [usp_select_SalesOrderLine_Allocation]
        /// </summary>
        public static SalesOrderLine GetAllocation(System.Int32? salesOrderLineId, System.Int32? allocationId)
        {
            Rebound.GlobalTrader.DAL.SalesOrderLineDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.GetAllocation(salesOrderLineId, allocationId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SalesOrderLine obj = new SalesOrderLine();
                obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                obj.SalesOrderNo = objDetails.SalesOrderNo;
                obj.Part = objDetails.Part;
                obj.ManufacturerNo = objDetails.ManufacturerNo;
                obj.ManufacturerName = objDetails.ManufacturerName;
                obj.ManufacturerCode = objDetails.ManufacturerCode;
                obj.DateCode = objDetails.DateCode;
                obj.Location = objDetails.Location;
                obj.PackageNo = objDetails.PackageNo;
                obj.PackageName = objDetails.PackageName;
                obj.PackageDescription = objDetails.PackageDescription;
                obj.PackageNo = objDetails.PackageNo;
                obj.Quantity = objDetails.Quantity;
                obj.Price = objDetails.Price;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.BackOrderQuantity = objDetails.BackOrderQuantity;
                obj.DatePromised = objDetails.DatePromised;
                obj.RequiredDate = objDetails.RequiredDate;
                obj.DeliveryDate = objDetails.DeliveryDate;
                obj.Instructions = objDetails.Instructions;
                obj.ProductNo = objDetails.ProductNo;
                obj.ProductName = objDetails.ProductName;
                obj.ProductDescription = objDetails.ProductDescription;
                obj.CustomerPart = objDetails.CustomerPart;
                obj.Posted = objDetails.Posted;
                obj.ShipASAP = objDetails.ShipASAP;
                obj.QuantityAllocated = objDetails.QuantityAllocated;
                obj.QuantityShipped = objDetails.QuantityShipped;
                obj.Quantity = objDetails.Quantity;
                obj.StockNo = objDetails.StockNo;
                obj.ROHS = objDetails.ROHS;
                obj.PurchaseOrderId = objDetails.PurchaseOrderId;
                obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                obj.WarehouseNo = objDetails.WarehouseNo;
                obj.WarehouseName = objDetails.WarehouseName;
                obj.AllocationId = objDetails.AllocationId;
                obj.AllocatedQuantity = objDetails.AllocatedQuantity;
                obj.SupplierNo = objDetails.SupplierNo;
                obj.SupplierName = objDetails.SupplierName;
                obj.GoodsInLineNo = objDetails.GoodsInLineNo;
                obj.GoodsInNo = objDetails.GoodsInNo;
                obj.GoodsInNumber = objDetails.GoodsInNumber;
                obj.Notes = objDetails.Notes;
                obj.ServiceNo = objDetails.ServiceNo;
                obj.ClientSupplierNo = objDetails.ClientSupplierNo;
                obj.ClientSupplierName = objDetails.ClientSupplierName;
                obj.MSLLevel = objDetails.MSLLevel;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetAsPurchaseRequisitionForPage
        /// Calls [usp_select_SalesOrderLine_as_PurchaseRequisition_for_Page]
        /// </summary>
        public static SalesOrderLine GetAsPurchaseRequisitionForPage(System.Int32? salesOrderLineId)
        {
            Rebound.GlobalTrader.DAL.SalesOrderLineDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.GetAsPurchaseRequisitionForPage(salesOrderLineId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SalesOrderLine obj = new SalesOrderLine();
                obj.ClientNo = objDetails.ClientNo;
                obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.CompanyName = objDetails.CompanyName;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetShippingStatusInfo
        /// Calls [usp_select_SalesOrderLine_ShippingStatusInfo]
        /// </summary>
        public static SalesOrderLine GetShippingStatusInfo(System.Int32? salesOrderLineId, System.Int32? allocationId)
        {
            Rebound.GlobalTrader.DAL.SalesOrderLineDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.GetShippingStatusInfo(salesOrderLineId, allocationId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SalesOrderLine obj = new SalesOrderLine();
                obj.TermsInAdvanceOK = objDetails.TermsInAdvanceOK;
                obj.CreditLimitOK = objDetails.CreditLimitOK;
                obj.StockUnavailable = objDetails.StockUnavailable;
                obj.SalesOrderClosed = objDetails.SalesOrderClosed;
                obj.Closed = objDetails.Closed;
                obj.Unauthorised = objDetails.Unauthorised;
                obj.GoodsInInspected = objDetails.GoodsInInspected;
                obj.QuantityInStock = objDetails.QuantityInStock;
                obj.CompanyOnStop = objDetails.CompanyOnStop;
                obj.QuantityAllocated = objDetails.QuantityAllocated;
                obj.ServiceNo = objDetails.ServiceNo;
                obj.Posted = objDetails.Posted;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetListClosedForSalesOrder
        /// Calls [usp_selectAll_SalesOrderLine_closed_for_SalesOrder]
        /// </summary>
        public static List<SalesOrderLine> GetListClosedForSalesOrder(System.Int32? salesOrderId)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.GetListClosedForSalesOrder(salesOrderId);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                    obj.Taxable = objDetails.Taxable;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.ROHS = objDetails.ROHS;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.DateCode = objDetails.DateCode;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.PackageName = objDetails.PackageName;
                    obj.QuantityShipped = objDetails.QuantityShipped;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.BackOrderQuantity = objDetails.BackOrderQuantity;
                    obj.ServiceNo = objDetails.ServiceNo;
                    obj.Closed = objDetails.Closed;
                    obj.Posted = objDetails.Posted;
                    obj.Inactive = objDetails.Inactive;
                    obj.ServiceShipped = objDetails.ServiceShipped;
                    obj.SerialNo = objDetails.SerialNo;
                    obj.IsIPO = objDetails.IsIPO;
                    obj.IsChecked = objDetails.IsChecked;
                    obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
                    obj.IsFromIPO = objDetails.SourcingResultNo > 0 ? true : false;
                    obj.IsIPOHeaderCreated = objDetails.IsIPOHeaderCreated;
                    obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
                    obj.CloneID = objDetails.CloneID;
                    //[1006] start
                    obj.IsConfirmed = objDetails.IsConfirmed;
                    obj.DateConfirmed = objDetails.DateConfirmed;
                    //[1006] end
                    if (obj.IsIPO==true)
                    {
                        int IsIPOAlreadyCreated = BLL.Warehouse.IsIPOExist(salesOrderId, objDetails.SalesOrderLineId);
                        if (IsIPOAlreadyCreated == 0)
                        {
                            obj.IsSourcingResultExist = 1;
                            obj.IsIPOCreatedForCurrentLine = false;
                        }
                        else
                        {
                            obj.IsSourcingResultExist = 0;
                            obj.IsIPOCreatedForCurrentLine = true;
                        }
                    }
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListForSalesOrder
        /// Calls [usp_selectAll_SalesOrderLine_for_SalesOrder]
        /// </summary>
        public static List<SalesOrderLine> GetListForSalesOrder(System.Int32? salesOrderId, System.Boolean? includeInactive)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.GetListForSalesOrder(salesOrderId, includeInactive);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                    obj.Taxable = objDetails.Taxable;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.ROHS = objDetails.ROHS;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.DateCode = objDetails.DateCode;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.PackageName = objDetails.PackageName;
                    obj.QuantityShipped = objDetails.QuantityShipped;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.BackOrderQuantity = objDetails.BackOrderQuantity;
                    obj.ServiceNo = objDetails.ServiceNo;
                    obj.Closed = objDetails.Closed;
                    obj.Posted = objDetails.Posted;
                    obj.Inactive = objDetails.Inactive;
                    obj.ServiceShipped = objDetails.ServiceShipped;
                    obj.ServiceCost = objDetails.ServiceCost;
                    obj.ServicePrice = objDetails.ServicePrice;
                    obj.DatePromised = objDetails.DatePromised;
                    //[1001] code start
                    obj.Notes = objDetails.Notes;
                    //[1001] code end
                    //[1004] code start
                    obj.ProductSource = objDetails.ProductSource;
                    //[1004] code end
                    obj.ShipASAP = objDetails.ShipASAP;
                    obj.SerialNo = objDetails.SerialNo;
                    obj.IsIPO = objDetails.IsIPO;
                    obj.IsChecked = objDetails.IsChecked;
                    obj.SourcingResultNo = objDetails.SourcingResultNo;
                    obj.IsFromIPO = objDetails.SourcingResultNo > 0 ? true : false;
                    obj.IsIPOHeaderCreated = objDetails.IsIPOHeaderCreated;
                    obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
                    obj.CloneID = objDetails.CloneID;
                    obj.DutyCode = objDetails.DutyCode;
                    obj.MSLLevel = objDetails.MSLLevel;
                    //[005] start
                    obj.ContractNo = objDetails.ContractNo;
                    //[005] end
                    obj.PrintHazardous = objDetails.PrintHazardous;
                    //[1006] start
                    obj.IsConfirmed = objDetails.IsConfirmed;
                    //[1006] end
                    obj.DateConfirmed = objDetails.DateConfirmed;
                    if (objDetails.IsIPO==true)
                    {
                        int IsIPOAlreadyCreated = BLL.Warehouse.IsIPOExist(salesOrderId, objDetails.SalesOrderLineId);
                        if (IsIPOAlreadyCreated == 0)
                        {
                            obj.IsSourcingResultExist = 1;
                            obj.IsIPOCreatedForCurrentLine = false;
                        }
                        else
                        {
                            obj.IsSourcingResultExist = 0;
                            obj.IsIPOCreatedForCurrentLine = true;
                        }
                    }
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// GetListForSalesOrder
        /// Calls [usp_selectAll_ConsolidateSalesOrderLine_for_SalesOrder]
        /// </summary>
        public static List<SalesOrderLine> GetListForConsolidateSalesOrder(System.Int32? salesOrderId, System.Boolean? includeInactive)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.GetListForConsolidateSalesOrder(salesOrderId, includeInactive);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                  
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                  
                    obj.Quantity = objDetails.Quantity;
                    obj.Part = objDetails.Part;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.DateCode = objDetails.DateCode;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.PackageName = objDetails.PackageName;
                    obj.ROHS = objDetails.ROHS;
                    obj.Price = objDetails.Price;
                    obj.Notes = objDetails.Notes;
                    obj.ProductSource = objDetails.ProductSource;
                    obj.DutyCode = objDetails.DutyCode;
                    obj.MSLLevel = objDetails.MSLLevel;
                    obj.ContractNo = objDetails.ContractNo;
                    obj.PrintHazardous = objDetails.PrintHazardous;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }


        /// <summary>
        /// GetListForSerial
        /// Calls [usp_selectAll_SalesOrderLine_for_SerialNumber]
        /// </summary>
        public static List<SalesOrderLine> GetListForSerial(System.Int32? salesOrderId)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.GetListForSerial(salesOrderId);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListForService
        /// Calls [usp_selectAll_SalesOrderLine_for_Service]
        /// </summary>
        public static List<SalesOrderLine> GetListForService(System.Int32? serviceId)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.GetListForService(serviceId);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                    obj.FullPart = objDetails.FullPart;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.DateCode = objDetails.DateCode;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.RequiredDate = objDetails.RequiredDate;
                    obj.Instructions = objDetails.Instructions;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.Taxable = objDetails.Taxable;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.Posted = objDetails.Posted;
                    obj.ShipASAP = objDetails.ShipASAP;
                    obj.Inactive = objDetails.Inactive;
                    obj.Closed = objDetails.Closed;
                    obj.ROHS = objDetails.ROHS;
                    obj.ServiceNo = objDetails.ServiceNo;
                    obj.StockNo = objDetails.StockNo;
                    obj.LineNotes = objDetails.LineNotes;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.QuantityShipped = objDetails.QuantityShipped;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.BackOrderQuantity = objDetails.BackOrderQuantity;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.OnStop = objDetails.OnStop;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.Balance = objDetails.Balance;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.CurrencyDate = objDetails.CurrencyDate;
                    obj.Salesman = objDetails.Salesman;
                    obj.ExchangeRate = objDetails.ExchangeRate;
                    obj.ServiceShipped = objDetails.ServiceShipped;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListForShipping
        /// Calls [usp_selectAll_SalesOrderLine_for_Shipping]
        /// </summary>
        public static List<SalesOrderLine> GetListForShipping(System.Int32? salesOrderNo)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.GetListForShipping(salesOrderNo);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.AllocationId = objDetails.AllocationId;
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                    obj.Part = objDetails.Part;
                    obj.ROHS = objDetails.ROHS;
                    obj.DateCode = objDetails.DateCode;
                    obj.Quantity = objDetails.Quantity;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.StockNo = objDetails.StockNo;
                    obj.GoodsInLineNo = objDetails.GoodsInLineNo;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.QuantityOrdered = objDetails.QuantityOrdered;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.QuantityInStock = objDetails.QuantityInStock;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.Location = objDetails.Location;
                    obj.QuantityShipped = objDetails.QuantityShipped;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.RequiredDate = objDetails.RequiredDate;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.ReadyToShip = objDetails.ReadyToShip;
                    obj.WarehouseNo = objDetails.WarehouseNo;
                    obj.WarehouseName = objDetails.WarehouseName;
                    obj.ServiceNo = objDetails.ServiceNo;
                    obj.Instructions = objDetails.Instructions;
                    obj.CreditStatus = objDetails.CreditStatus;
                    obj.ReqSerialNumber = objDetails.ReqSerialNumber;
                    obj.MSLLevel = objDetails.MSLLevel;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListFromGoodsInLineForDocket
        /// Calls [usp_selectAll_SalesOrderLine_from_GoodsInLine_for_Docket]
        /// </summary>
        public static List<SalesOrderLine> GetListFromGoodsInLineForDocket(System.Int32? goodsInLineNo)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.GetListFromGoodsInLineForDocket(goodsInLineNo);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.ShipViaName = objDetails.ShipViaName;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.EarliestDatePromised = objDetails.EarliestDatePromised;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.ShipASAP = objDetails.ShipASAP;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.NumberOfLines = objDetails.NumberOfLines;
                    //[0001] Code start
                    obj.ShippingNotes = objDetails.ShippingNotes;
                    //[0001] code end
                    obj.ReceivingNotes = objDetails.ReceivingNotes;

                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListOpenForSalesOrder
        /// Calls [usp_selectAll_SalesOrderLine_open_for_SalesOrder]
        /// </summary>
        public static List<SalesOrderLine> GetListOpenForSalesOrder(System.Int32? salesOrderId)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.GetListOpenForSalesOrder(salesOrderId);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                    obj.Taxable = objDetails.Taxable;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.ROHS = objDetails.ROHS;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.DateCode = objDetails.DateCode;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.PackageName = objDetails.PackageName;
                    obj.QuantityShipped = objDetails.QuantityShipped;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.BackOrderQuantity = objDetails.BackOrderQuantity;
                    obj.ServiceNo = objDetails.ServiceNo;
                    obj.Closed = objDetails.Closed;
                    obj.Posted = objDetails.Posted;
                    obj.Inactive = objDetails.Inactive;
                    obj.ServiceShipped = objDetails.ServiceShipped;
                    obj.Instructions = objDetails.Instructions;
                    obj.SerialNo = objDetails.SerialNo;
                    obj.IsIPO = objDetails.IsIPO;
                    obj.IsChecked = objDetails.IsChecked;
                    obj.POQuoteLineNo = objDetails.POQuoteLineNo;
                    obj.IsIPOHeaderCreated = objDetails.IsIPOHeaderCreated;
                    obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
                    obj.CloneID = objDetails.CloneID;
                    //[1006] start
                    obj.IsConfirmed = objDetails.IsConfirmed;
                    //[1006] end
                    obj.DateConfirmed = objDetails.DateConfirmed;
                    
                    obj.IsFromIPO = objDetails.SourcingResultNo > 0 ? true : false;
                    if (objDetails.SourcingResultNo != null && objDetails.SourcingResultNo > 0)
                    {
                        int IsIPOAlreadyCreated = BLL.Warehouse.IsIPOExist(salesOrderId, objDetails.SalesOrderLineId);
                        if (IsIPOAlreadyCreated == 0)
                        {
                            obj.IsSourcingResultExist = 1;
                            obj.IsIPOCreatedForCurrentLine = false;
                        }
                        else
                        {
                            obj.IsSourcingResultExist = 0;
                            obj.IsIPOCreatedForCurrentLine = true;
                        }
                    }
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListReportManualStock
        /// Calls [usp_selectAll_SalesOrderLine_ReportManualStock]
        /// </summary>
        public static List<SalesOrderLine> GetListReportManualStock(System.Int32? salesOrderLineId)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.GetListReportManualStock(salesOrderLineId);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                    obj.StockNo = objDetails.StockNo;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.DateCode = objDetails.DateCode;
                    obj.LandedCost = objDetails.LandedCost;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.ResalePrice = objDetails.ResalePrice;
                    obj.SupplierPart = objDetails.SupplierPart;
                    obj.ROHS = objDetails.ROHS;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListReportPO
        /// Calls [usp_selectAll_SalesOrderLine_ReportPO]
        /// </summary>
        public static List<SalesOrderLine> GetListReportPO(System.Int32? salesOrderLineId)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.GetListReportPO(salesOrderLineId);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                    obj.StockNo = objDetails.StockNo;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.DateCode = objDetails.DateCode;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
                    obj.PurchasePrice = objDetails.PurchasePrice;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                    obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                    obj.SupplierNo = objDetails.SupplierNo;
                    obj.SupplierName = objDetails.SupplierName;
                    obj.CountryName = objDetails.CountryName;
                    obj.Duty = objDetails.Duty;
                    obj.DutyRate = objDetails.DutyRate;
                    obj.LandedCost = objDetails.LandedCost;
                    obj.DeliveryDate = objDetails.DeliveryDate;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.TermsName = objDetails.TermsName;
                    obj.Taxable = objDetails.Taxable;
                    obj.QuantitySupplied = objDetails.QuantitySupplied;
                    obj.ShipInCost = objDetails.ShipInCost;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.SupplierType = objDetails.SupplierType;
                    obj.SupplierPart = objDetails.SupplierPart;
                    obj.ROHS = objDetails.ROHS;
                    obj.SerialNo = objDetails.SerialNo;
                    obj.InternalPurchaseOrderNo = objDetails.InternalPurchaseOrderNo;
                    obj.IPOSupplierName = objDetails.IPOSupplierName;
                    obj.IPOSupplierType = objDetails.IPOSupplierType;
                    obj.ClientLandedCost = objDetails.ClientLandedCost;
                    obj.PODateOrdered = objDetails.PODateOrdered;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListReportPOStock
        /// Calls [usp_selectAll_SalesOrderLine_ReportPOStock]
        /// </summary>
        public static List<SalesOrderLine> GetListReportPOStock(System.Int32? salesOrderLineId)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.GetListReportPOStock(salesOrderLineId);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                    obj.StockNo = objDetails.StockNo;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.GoodsInLineNo = objDetails.GoodsInLineNo;
                    obj.GoodsInNo = objDetails.GoodsInNo;
                    obj.Part = objDetails.Part;
                    obj.ROHS = objDetails.ROHS;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.DateCode = objDetails.DateCode;
                    obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
                    obj.PurchasePrice = objDetails.PurchasePrice;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                    obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.SupplierNo = objDetails.SupplierNo;
                    obj.SupplierName = objDetails.SupplierName;
                    obj.CountryName = objDetails.CountryName;
                    obj.Duty = objDetails.Duty;
                    obj.DutyRate = objDetails.DutyRate;
                    obj.ShipInCost = objDetails.ShipInCost;
                    obj.DateReceived = objDetails.DateReceived;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.TermsName = objDetails.TermsName;
                    obj.Taxable = objDetails.Taxable;
                    obj.LandedCost = objDetails.LandedCost;
                    obj.SupplierType = objDetails.SupplierType;
                    obj.SupplierPart = objDetails.SupplierPart;
                    obj.SerialNo = objDetails.SerialNo;
                    obj.IPOSupplierName = objDetails.IPOSupplierName;
                    obj.InternalPurchaseOrderNo = objDetails.InternalPurchaseOrderNo;
                    obj.IPOSupplierType = objDetails.IPOSupplierType;
                    obj.ClientLandedCost = objDetails.ClientLandedCost;
                    obj.PODateOrdered = objDetails.PODateOrdered;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListReportShipped
        /// Calls [usp_selectAll_SalesOrderLine_ReportShipped]
        /// </summary>
        public static List<SalesOrderLine> GetListReportShipped(System.Int32? salesOrderLineId)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.GetListReportShipped(salesOrderLineId);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.QuantityShipped = objDetails.QuantityShipped;
                    obj.GoodsInLineNo = objDetails.GoodsInLineNo;
                    obj.GoodsInNo = objDetails.GoodsInNo;
                    obj.Part = objDetails.Part;
                    obj.ROHS = objDetails.ROHS;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.DateCode = objDetails.DateCode;
                    obj.LandedCost = objDetails.LandedCost;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.InvoiceDate = objDetails.InvoiceDate;
                    obj.ShipInCost = objDetails.ShipInCost;
                    obj.Taxable = objDetails.Taxable;
                    obj.PurchasePrice = objDetails.PurchasePrice;
                    obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                    obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.TermsName = objDetails.TermsName;
                    obj.CountryName = objDetails.CountryName;
                    obj.Duty = objDetails.Duty;
                    obj.DutyRate = objDetails.DutyRate;
                    obj.SupplierNo = objDetails.SupplierNo;
                    obj.SupplierName = objDetails.SupplierName;
                    obj.SupplierType = objDetails.SupplierType;
                    obj.SupplierPart = objDetails.SupplierPart;
                    obj.ServiceNo = objDetails.ServiceNo;
                    obj.SerialNo = objDetails.SerialNo;
                    obj.InternalPurchaseOrderNo = objDetails.InternalPurchaseOrderNo;
                    obj.IPOSupplierName = objDetails.IPOSupplierName;
                    obj.IPOSupplierType = objDetails.IPOSupplierType;
                    obj.ClientLandedCost = objDetails.ClientLandedCost;
                    obj.PODateOrdered = objDetails.PODateOrdered;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListServiceForInvoice
        /// Calls [usp_selectAll_SalesOrderLine_service_for_Invoice]
        /// </summary>
        public static List<SalesOrderLine> GetListServiceForInvoice(System.Int32? invoiceId)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.GetListServiceForInvoice(invoiceId);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                    obj.FullPart = objDetails.FullPart;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.DateCode = objDetails.DateCode;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.RequiredDate = objDetails.RequiredDate;
                    obj.Instructions = objDetails.Instructions;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.Taxable = objDetails.Taxable;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.Posted = objDetails.Posted;
                    obj.ShipASAP = objDetails.ShipASAP;
                    obj.Inactive = objDetails.Inactive;
                    obj.Closed = objDetails.Closed;
                    obj.ROHS = objDetails.ROHS;
                    obj.ServiceNo = objDetails.ServiceNo;
                    obj.StockNo = objDetails.StockNo;
                    obj.LineNotes = objDetails.LineNotes;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.QuantityShipped = objDetails.QuantityShipped;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.BackOrderQuantity = objDetails.BackOrderQuantity;
                    obj.ProductName = objDetails.ProductName;
                    obj.ProductDescription = objDetails.ProductDescription;
                    obj.PackageName = objDetails.PackageName;
                    obj.PackageDescription = objDetails.PackageDescription;
                    obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.OnStop = objDetails.OnStop;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.Balance = objDetails.Balance;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.CurrencyDate = objDetails.CurrencyDate;
                    obj.Salesman = objDetails.Salesman;
                    obj.ExchangeRate = objDetails.ExchangeRate;
                    obj.ServiceShipped = objDetails.ServiceShipped;
                    obj.SalesOrderId = objDetails.SalesOrderId;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.Salesman = objDetails.Salesman;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                    obj.ShipViaNo = objDetails.ShipViaNo;
                    obj.Account = objDetails.Account;
                    obj.Freight = objDetails.Freight;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TaxNo = objDetails.TaxNo;
                    obj.ShippingCost = objDetails.ShippingCost;
                    obj.Notes = objDetails.Notes;
                    obj.Instructions = objDetails.Instructions;
                    obj.Paid = objDetails.Paid;
                    obj.StatusNo = objDetails.StatusNo;
                    obj.Closed = objDetails.Closed;
                    obj.SaleTypeNo = objDetails.SaleTypeNo;
                    obj.Salesman2 = objDetails.Salesman2;
                    obj.Salesman2Percent = objDetails.Salesman2Percent;
                    obj.AuthorisedBy = objDetails.AuthorisedBy;
                    obj.DateAuthorised = objDetails.DateAuthorised;
                    obj.CurrencyDate = objDetails.CurrencyDate;
                    obj.IncotermNo = objDetails.IncotermNo;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.CreatedBy = objDetails.CreatedBy;
                    obj.CreateDate = objDetails.CreateDate;
                    obj.InvoiceId = objDetails.InvoiceId;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.InvoiceNumber = objDetails.InvoiceNumber;
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                    obj.InvoiceDate = objDetails.InvoiceDate;
                    obj.Notes = objDetails.Notes;
                    obj.Instructions = objDetails.Instructions;
                    obj.CompanyShipTo = objDetails.CompanyShipTo;
                    obj.CompanyBillTo = objDetails.CompanyBillTo;
                    obj.ShipViaNo = objDetails.ShipViaNo;
                    obj.Account = objDetails.Account;
                    obj.ShippingCost = objDetails.ShippingCost;
                    obj.Freight = objDetails.Freight;
                    obj.FreeOnBoard = objDetails.FreeOnBoard;
                    obj.Boxes = objDetails.Boxes;
                    obj.Weight = objDetails.Weight;
                    obj.DimensionalWeight = objDetails.DimensionalWeight;
                    obj.WeightInPounds = objDetails.WeightInPounds;
                    obj.AirWayBill = objDetails.AirWayBill;
                    obj.ShippedBy = objDetails.ShippedBy;
                    obj.Printed = objDetails.Printed;
                    obj.SupplierRMANo = objDetails.SupplierRMANo;
                    obj.ShippingNotes = objDetails.ShippingNotes;
                    obj.Exported = objDetails.Exported;
                    obj.InvoicePaid = objDetails.InvoicePaid;
                    obj.Salesman2 = objDetails.Salesman2;
                    obj.Salesman2Percent = objDetails.Salesman2Percent;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.Salesman = objDetails.Salesman;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.TaxNo = objDetails.TaxNo;
                    obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.CofCNotes = objDetails.CofCNotes;
                    obj.BillToAddressNo = objDetails.BillToAddressNo;
                    obj.IncotermNo = objDetails.IncotermNo;
                    obj.DivisionNo2 = objDetails.DivisionNo2;
                    obj.DateExported = objDetails.DateExported;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Source
        /// Calls [usp_source_SalesOrderLine]
        /// </summary>
        public static List<SalesOrderLine> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? maxDate, out DateTime? outDate, System.Boolean? blnReferesh, bool IsServerLocal)
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
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.Source(clientId, partSearch, index, StartDate, EndDate, out outDate, IsServerLocal);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.Part = objDetails.Part;
                    obj.DateCode = objDetails.DateCode;
                    obj.Quantity = objDetails.Quantity;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.ROHS = objDetails.ROHS;
                    obj.Price = objDetails.Price;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.PackageName = objDetails.PackageName;
                    obj.ProductName = objDetails.ProductName;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.ClientName = objDetails.ClientName;
                    obj.ClientDataVisibleToOthers = objDetails.ClientDataVisibleToOthers;
                    obj.Salesman = objDetails.Salesman;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.blnCRMA = objDetails.blnCRMA;
                    obj.ClientCode = objDetails.ClientCode;
                    obj.IPOs = objDetails.IPOs;
                    obj.IPOPrice = objDetails.IPOPrice;
                    obj.IPOPriceWithCurrency = objDetails.IPOPriceWithCurrency;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        //[1004] code start
        /// <summary>
        /// Update
        /// Calls [usp_update_SalesOrderLine]
        /// </summary>
        public static bool Update(System.Int32? salesOrderLineId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.String instructions, System.Int32? productNo, System.String taxable, System.String customerPart, System.Boolean? shipAsap, System.Boolean? inactive, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Byte? productSource,System.DateTime? poDeliveryDate,System.Int16? serialNo, System.String mslLevel,System.String ContractNo)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.Update(salesOrderLineId, part, manufacturerNo, dateCode, packageNo, quantity, price, datePromised, requiredDate, instructions, productNo, taxable, customerPart, shipAsap, inactive, rohs, notes, updatedBy, productSource, poDeliveryDate, serialNo, mslLevel,ContractNo,false,false);
        }
        /// <summary>
        /// Update (without parameters)
        /// Calls [usp_update_SalesOrderLine]
        /// </summary>
        public bool Update(bool isFormChanged)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.Update(SalesOrderLineId, Part, ManufacturerNo, DateCode, PackageNo, Quantity, Price, DatePromised, RequiredDate, Instructions, ProductNo, Taxable, CustomerPart, ShipASAP, Inactive, ROHS, Notes, UpdatedBy, ProductSource, PODeliveryDate, SerialNo, MSLLevel, ContractNo, PrintHazardous, isFormChanged);
        }
        //[1004] code end
        /// <summary>
        /// UpdateClose
        /// Calls [usp_update_SalesOrderLine_Close]
        /// </summary>
        public static bool UpdateClose(System.Int32? salesOrderLineId, System.Boolean? resetQuantity, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.UpdateClose(salesOrderLineId, resetQuantity, updatedBy);
        }
        /// <summary>
        /// UpdatePostOrUnpost
        /// Calls [usp_update_SalesOrderLine_Post_or_Unpost]
        /// </summary>
        public static bool UpdatePostOrUnpost(System.Int32? salesOrderLineId, System.Boolean? posted, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.UpdatePostOrUnpost(salesOrderLineId, posted, updatedBy);
        }

        private static SalesOrderLine PopulateFromDBDetailsObject(SalesOrderLineDetails obj)
        {
            SalesOrderLine objNew = new SalesOrderLine();
            objNew.SalesOrderLineId = obj.SalesOrderLineId;
            objNew.SalesOrderNo = obj.SalesOrderNo;
            objNew.FullPart = obj.FullPart;
            objNew.Part = obj.Part;
            objNew.ManufacturerNo = obj.ManufacturerNo;
            objNew.DateCode = obj.DateCode;
            objNew.PackageNo = obj.PackageNo;
            objNew.Quantity = obj.Quantity;
            objNew.Price = obj.Price;
            objNew.DatePromised = obj.DatePromised;
            objNew.RequiredDate = obj.RequiredDate;
            objNew.Instructions = obj.Instructions;
            objNew.ProductNo = obj.ProductNo;
            objNew.Taxable = obj.Taxable;
            objNew.CustomerPart = obj.CustomerPart;
            objNew.Posted = obj.Posted;
            objNew.ShipASAP = obj.ShipASAP;
            objNew.Inactive = obj.Inactive;
            objNew.Closed = obj.Closed;
            objNew.ROHS = obj.ROHS;
            objNew.ServiceNo = obj.ServiceNo;
            objNew.StockNo = obj.StockNo;
            objNew.Notes = obj.Notes;
            objNew.UpdatedBy = obj.UpdatedBy;
            objNew.DLUP = obj.DLUP;
            objNew.FullCustomerPart = obj.FullCustomerPart;
            objNew.ServiceShipped = obj.ServiceShipped;
            objNew.SalesOrderNumber = obj.SalesOrderNumber;
            objNew.ManufacturerCode = obj.ManufacturerCode;
            objNew.QuantityShipped = obj.QuantityShipped;
            objNew.CompanyNo = obj.CompanyNo;
            objNew.CompanyName = obj.CompanyName;
            objNew.ContactNo = obj.ContactNo;
            objNew.ContactName = obj.ContactName;
            objNew.DateOrdered = obj.DateOrdered;
            objNew.CustomerPO = obj.CustomerPO;
            objNew.RowNum = obj.RowNum;
            objNew.RowCnt = obj.RowCnt;
            objNew.Status = obj.Status;
            objNew.QuantityAllocated = obj.QuantityAllocated;
            objNew.AllocationId = obj.AllocationId;
            objNew.QuantityOrdered = obj.QuantityOrdered;
            objNew.QuantityInStock = obj.QuantityInStock;
            objNew.CurrencyCode = obj.CurrencyCode;
            objNew.BackOrderQuantity = obj.BackOrderQuantity;
            objNew.AllocatedQuantity = obj.AllocatedQuantity;
            objNew.SalesmanName = obj.SalesmanName;
            objNew.SalesOrderId = obj.SalesOrderId;
            objNew.CurrencyDate = obj.CurrencyDate;
            objNew.ClientNo = obj.ClientNo;
            objNew.Salesman = obj.Salesman;
            objNew.DivisionNo = obj.DivisionNo;
            objNew.TeamNo = obj.TeamNo;
            objNew.LineValue = obj.LineValue;
            objNew.ProductName = obj.ProductName;
            objNew.ProductDescription = obj.ProductDescription;
            objNew.ManufacturerName = obj.ManufacturerName;
            objNew.PackageName = obj.PackageName;
            objNew.PackageDescription = obj.PackageDescription;
            objNew.Paid = obj.Paid;
            objNew.TermsNo = obj.TermsNo;
            objNew.ShipViaNo = obj.ShipViaNo;
            objNew.ShipToAddressNo = obj.ShipToAddressNo;
            objNew.Unauthorised = obj.Unauthorised;
            objNew.TermsName = obj.TermsName;
            objNew.InAdvance = obj.InAdvance;
            objNew.CurrencyNo = obj.CurrencyNo;
            objNew.CurrencyDescription = obj.CurrencyDescription;
            objNew.SalesOrderValue = obj.SalesOrderValue;
            objNew.FullName = obj.FullName;
            objNew.OnStop = obj.OnStop;
            objNew.CreditLimit = obj.CreditLimit;
            objNew.Balance = obj.Balance;
            objNew.LineNotes = obj.LineNotes;
            objNew.ExchangeRate = obj.ExchangeRate;
            objNew.Location = obj.Location;
            objNew.DeliveryDate = obj.DeliveryDate;
            objNew.PurchaseOrderId = obj.PurchaseOrderId;
            objNew.PurchaseOrderNumber = obj.PurchaseOrderNumber;
            objNew.WarehouseNo = obj.WarehouseNo;
            objNew.WarehouseName = obj.WarehouseName;
            objNew.SupplierNo = obj.SupplierNo;
            objNew.SupplierName = obj.SupplierName;
            objNew.GoodsInLineNo = obj.GoodsInLineNo;
            objNew.GoodsInNo = obj.GoodsInNo;
            objNew.GoodsInNumber = obj.GoodsInNumber;
            objNew.TermsInAdvanceOK = obj.TermsInAdvanceOK;
            objNew.CreditLimitOK = obj.CreditLimitOK;
            objNew.StockUnavailable = obj.StockUnavailable;
            objNew.SalesOrderClosed = obj.SalesOrderClosed;
            objNew.GoodsInInspected = obj.GoodsInInspected;
            objNew.CompanyOnStop = obj.CompanyOnStop;
            objNew.ServiceCost = obj.ServiceCost;
            objNew.ServicePrice = obj.ServicePrice;
            objNew.ReadyToShip = obj.ReadyToShip;
            objNew.ShipViaName = obj.ShipViaName;
            objNew.EarliestDatePromised = obj.EarliestDatePromised;
            objNew.NumberOfLines = obj.NumberOfLines;
            objNew.LandedCost = obj.LandedCost;
            objNew.ResalePrice = obj.ResalePrice;
            objNew.SupplierPart = obj.SupplierPart;
            objNew.PurchaseOrderLineNo = obj.PurchaseOrderLineNo;
            objNew.PurchasePrice = obj.PurchasePrice;
            objNew.PurchaseOrderNo = obj.PurchaseOrderNo;
            objNew.CountryName = obj.CountryName;
            objNew.Duty = obj.Duty;
            objNew.DutyRate = obj.DutyRate;
            objNew.QuantitySupplied = obj.QuantitySupplied;
            objNew.ShipInCost = obj.ShipInCost;
            objNew.SupplierType = obj.SupplierType;
            objNew.DateReceived = obj.DateReceived;
            objNew.InvoiceDate = obj.InvoiceDate;
            objNew.Account = obj.Account;
            objNew.Freight = obj.Freight;
            objNew.TaxNo = obj.TaxNo;
            objNew.ShippingCost = obj.ShippingCost;
            objNew.StatusNo = obj.StatusNo;
            objNew.SaleTypeNo = obj.SaleTypeNo;
            objNew.Salesman2 = obj.Salesman2;
            objNew.Salesman2Percent = obj.Salesman2Percent;
            objNew.AuthorisedBy = obj.AuthorisedBy;
            objNew.DateAuthorised = obj.DateAuthorised;
            objNew.IncotermNo = obj.IncotermNo;
            objNew.CreatedBy = obj.CreatedBy;
            objNew.CreateDate = obj.CreateDate;
            objNew.InvoiceId = obj.InvoiceId;
            objNew.InvoiceNumber = obj.InvoiceNumber;
            objNew.CompanyShipTo = obj.CompanyShipTo;
            objNew.CompanyBillTo = obj.CompanyBillTo;
            objNew.FreeOnBoard = obj.FreeOnBoard;
            objNew.Boxes = obj.Boxes;
            objNew.Weight = obj.Weight;
            objNew.DimensionalWeight = obj.DimensionalWeight;
            objNew.WeightInPounds = obj.WeightInPounds;
            objNew.AirWayBill = obj.AirWayBill;
            objNew.ShippedBy = obj.ShippedBy;
            objNew.Printed = obj.Printed;
            objNew.SupplierRMANo = obj.SupplierRMANo;
            objNew.ShippingNotes = obj.ShippingNotes;
            objNew.Exported = obj.Exported;
            objNew.InvoicePaid = obj.InvoicePaid;
            objNew.CofCNotes = obj.CofCNotes;
            objNew.BillToAddressNo = obj.BillToAddressNo;
            objNew.DivisionNo2 = obj.DivisionNo2;
            objNew.DateExported = obj.DateExported;
            objNew.ClientName = obj.ClientName;
            objNew.ClientDataVisibleToOthers = obj.ClientDataVisibleToOthers;
            return objNew;
        }
        //[1006]  start
        public int SaveConfirmation(int salesOrderLineId, int salesOrderId,int buttonClicked)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrderLine.SaveConfirmation(salesOrderLineId, salesOrderId, buttonClicked);
            return objReturn;
        }
        //[1006]  end

        #endregion

    }
}
