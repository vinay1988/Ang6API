/*
Marker     Changed by      Date          Remarks
[001]      Abhinav         24/04/2014    ESMS #108 to show GI currency on NPR
[002]      Abhinav         09/04/2014    ESMS #120 Add Reason1,Reason2,Comments fields in NPR
[003]       Raushan         13/09/2014    NPR Search
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebound.GlobalTrader.DAL 
{
    public class ReportNPRDetails
    {
        #region Constructors
        public ReportNPRDetails() { }
        #endregion

        #region Properties
        /// <summary>
        /// NPRId
        /// </summary>
        public System.Int32 NPRId { get; set; }
        /// <summary>
        /// NPRNo
        /// </summary>
        public System.String NPRNo { get; set; }
        /// <summary>
        /// RaisedBy
        /// </summary>
        public System.Int32? RaisedBy { get; set; }
        /// <summary>
        /// NPRdate
        /// </summary>
        public System.DateTime? NPRdate { get; set; }
        /// <summary>
        /// QLocation
        /// </summary>
        public System.String QLocation { get; set; }
        /// <summary>
        /// GoodsInLineId
        /// </summary>
        public System.Int32? GoodsInLineId { get; set; }
        /// <summary>
        /// GoodsInNo
        /// </summary>
        public System.Int32? GoodsInNo { get; set; }
        /// <summary>
        /// SalesOrderNo
        /// </summary>
        public System.Int32? SalesOrderNo { get; set; }
        /// <summary>
        /// TotalRejectedValue
        /// </summary>
        public System.Double? TotalRejectedValue { get; set; }
        /// <summary>
        /// RejectionReason
        /// </summary>
        public System.String RejectionReason { get; set; }
        /// <summary>
        /// SupplierRMANo
        /// </summary>
        public System.String SupplierRMANo { get; set; }
        /// <summary>
        /// CorrectiveActionReport
        /// </summary>
        public System.Boolean? CorrectiveActionReport { get; set; }
        /// <summary>
        /// SupplierShipVia
        /// </summary>
        public System.String SupplierShipVia { get; set; }
        /// <summary>
        /// SupplierShipAccount
        /// </summary>
        public System.String SupplierShipAccount { get; set; }
        /// <summary>
        /// SupplierToCredit
        /// </summary>
        public System.Boolean? SupplierToCredit { get; set; }
        /// <summary>
        /// SupplierRef
        /// </summary>
        public System.String SupplierRef { get; set; }
        /// <summary>
        /// IncurredCostToSales_Scrap
        /// </summary>
        public System.Boolean? IncurredCostToSales_Scrap { get; set; }
        /// <summary>
        /// Comments
        /// </summary>
        public System.String Comments { get; set; }
        /// <summary>
        /// StockLocation
        /// </summary>
        public System.String StockLocation { get; set; }
        /// <summary>
        /// IncurredCostToSales_Stock
        /// </summary>
        public System.Boolean? IncurredCostToSales_Stock { get; set; }
        /// <summary>
        /// OutworkerName
        /// </summary>
        public System.String OutworkerName { get; set; }
        /// <summary>
        /// OutworkerPONo
        /// </summary>
        public System.Int32? OutworkerPONo { get; set; }
        /// <summary>
        /// SalesPersonNo
        /// </summary>
        public System.Int32? SalesPersonNo { get; set; }
        /// <summary>
        /// SalesAuthorisePersonNo
        /// </summary>
        public System.Int32? SalesAuthorisePersonNo { get; set; }
        /// <summary>
        /// SalesAuthoriseDate
        /// </summary>
        public System.DateTime? SalesAuthoriseDate { get; set; }
        /// <summary>
        /// LogisticSRMANo
        /// </summary>
        public System.Int32? LogisticSRMANo { get; set; }
        /// <summary>
        /// LogisticSRMADate
        /// </summary>
        public System.DateTime? LogisticSRMADate { get; set; }
        /// <summary>
        /// DebitNoteNo
        /// </summary>
        public System.Int32? DebitNoteNo { get; set; }
        /// <summary>
        /// DebitNoteDate
        /// </summary>
        public System.DateTime? DebitNoteDate { get; set; }
        /// <summary>
        /// NPRCompletedByNo
        /// </summary>
        public System.Int32? NPRCompletedByNo { get; set; }
        /// <summary>
        /// NPRCompleteddATE
        /// </summary>
        public System.DateTime? NPRCompletedDate { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime DLUP { get; set; }
        /// <summary>
        /// ReceiverName
        /// </summary>
        public System.String ReceiverName { get; set; }
        /// <summary>
        /// CurrentDate
        /// </summary>
        public System.DateTime? CurrentDate { get; set; }
        /// <summary>
        /// PartNo
        /// </summary>
        public System.String PartNo { get; set; }
        /// <summary>
        /// RejectedQty
        /// </summary>
        public System.Int32? RejectedQty { get; set; }
        /// <summary>
        /// UnitCost
        /// </summary>
        public System.Double? UnitCost { get; set; }
        /// <summary>
        /// Supplier
        /// </summary>
        public System.String Supplier { get; set; }
        /// <summary>
        /// AdviceNote
        /// </summary>
        public System.String AdviceNote { get; set; }
        /// <summary>
        /// CustomerName
        /// </summary>
        public System.String CustomerName { get; set; }
        /// <summary>
        /// CompanyNo
        /// </summary>
        public System.Int32? CompanyNo { get; set; }
        /// <summary>
        /// CompletedByName
        /// </summary>
        public System.String CompletedByName { get; set; }
        /// <summary>
        /// ShipViaName
        /// </summary>
        public System.String ShipViaName { get; set; }
        /// <summary>
        /// BuyerId
        /// </summary>
        public System.Int32? BuyerId { get; set; }
        /// <summary>
        /// BuyerName
        /// </summary>
        public System.String BuyerName { get; set; }
        /// <summary>
        /// GoodsInNumber
        /// </summary>
        public System.Int32? GoodsInNumber { get; set; }
        /// <summary>
        /// UpdatedByName
        /// </summary>
        public System.String UpdatedByName { get; set; }
        /// <summary>
        /// Details
        /// </summary>
        public System.String Details { get; set; }
        /// <summary>
        /// NPRLogId
        /// </summary>
        public System.Int32 NPRLogId { get; set; }
        /// <summary>
        /// SalesAuthoriseBy
        /// </summary>
        public System.String SalesAuthoriseBy { get; set; }
        /// <summary>
        /// SalesAuthoriseName
        /// </summary>
        public System.String SalesAuthoriseName { get; set; }
        /// <summary>
        /// IsAuthorise
        /// </summary>
        public System.Boolean? IsAuthorise { get; set; }
        /// <summary>
        /// SalesPerson
        /// </summary>
        public System.String SalesPerson { get; set; }
        /// <summary>
        /// PurchaseOrderNumber
        /// </summary>
        public System.Int32? PurchaseOrderNumber { get; set; }
        /// <summary>
        /// QtyAdvised
        /// </summary>
        public System.Int32? QtyAdvised { get; set; }
        //[0001] start 
        /// <summary>
        /// CurrencyNo
        /// </summary>
        public System.String CurrencyCode { get; set; }
        /// <summary>
        //[0001] end 
        //[0002] start 
        /// <summary>
        /// Reason1
        /// </summary>
        public System.String Reason1 { get; set; }
        /// <summary>
        /// <summary>
        /// Reason2
        /// </summary>
        public System.String Reason2 { get; set; }
        /// <summary>
        /// <summary>
        /// Reason1 Value
        /// </summary>
        public System.String Reason1Val { get; set; }
        /// <summary>
        /// <summary>
        /// Reason2 Value
        /// </summary>
        public System.String Reason2Val { get; set; }
        /// <summary>
        /// <summary>
        /// NPRComment
        /// </summary>
        public System.String NPRComment { get; set; }
        /// <summary>
        //[0002] end 
        /// SalesAction
        /// </summary>
        public System.String SalesAction { get; set; }
        //[003] Code Start
        public System.Int32 NprId { get; set; }
        public System.String NprNo { get; set; }
        public System.Int32? PurchaseOrderLineNo { get; set; }
        public System.String Part { get; set; }
        public System.Int32 Quantity { get; set; }
        public System.Double Price { get; set; }
        public System.String Location { get; set; }
        public System.String CompanyName { get; set; }
        public System.String Action { get; set; }
        public System.DateTime? NprRaisedDate { get; set; }
        public System.Boolean? IsAuthorised { get; set; }
        public System.Boolean? IsCompleted { get; set; }
        public System.Int64? RowNum { get; set; }
        public System.Int32? RowCnt { get; set; }
        public System.String AuthorisedBy { get; set; }
        public System.String CompletedBy { get; set; }
        public System.Int32 POId { get; set; }
        public System.Int32 ClientNo { get; set; }
        public System.String ClientName { get; set; }
        #endregion
    }
}
