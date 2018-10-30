/*
Marker     Changed by      Date          Remarks
[001]      Abhinav         24/04/2014    ESMS #108 to show GI currency on NPR
[002]      Raushan          13/04/2015    NPR Search
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rebound.GlobalTrader.DAL;
using Rebound.GlobalTrader.BLL;

namespace Rebound.GlobalTrader.BLL
{
    public class ReportNPR : BizObject
    {
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
        /// CurrencyCode
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
        /// <summary>
        /// SalesAction
        /// </summary>
        public System.String SalesAction { get; set; }
        //[002] Code Start
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
        #region Method
        public static ReportNPR GetGoodsInLineById(System.Int32 goodsInLineId)
        {
            Rebound.GlobalTrader.DAL.ReportNPRDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.ReportNPR.GetGoodsInLineById(goodsInLineId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Rebound.GlobalTrader.BLL.ReportNPR obj = new Rebound.GlobalTrader.BLL.ReportNPR();
                obj.GoodsInNo = objDetails.GoodsInNo;
                obj.GoodsInLineId = objDetails.GoodsInLineId;
                obj.CurrentDate = objDetails.CurrentDate;
                obj.QLocation = objDetails.QLocation;
                obj.NPRNo = objDetails.NPRNo;
                obj.ReceiverName = objDetails.ReceiverName;
                obj.PartNo = objDetails.PartNo;
                obj.RejectedQty = objDetails.RejectedQty;
                obj.UnitCost = objDetails.UnitCost;
                obj.Supplier = objDetails.Supplier;
                obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                obj.AdviceNote = objDetails.AdviceNote;
                obj.TotalRejectedValue = objDetails.TotalRejectedValue;
                obj.CustomerName = objDetails.CustomerName;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.SalesOrderNo = objDetails.SalesOrderNo;
                obj.RaisedBy = objDetails.RaisedBy;
                //[0001] start
                obj.CurrencyCode = objDetails.CurrencyCode; 
                //[0001] end
                // obj.CustomerRMANo = objDetails.CustomerRMANo;
               // obj.SupplierRMANo = objDetails.SupplierRMANo;
                obj.RejectionReason = objDetails.RejectionReason;
                //[0002] start
                obj.Reason1 = objDetails.Reason1;
                obj.Reason1 = objDetails.Reason1;
                obj.NPRComment = objDetails.NPRComment;
                
                //[0002] end

                objDetails = null;
                return obj;
            }

        }

        /// <summary>
        /// Insert
        /// Calls [usp_insert_ReportNPR]
        /// </summary>
        public static Int32 Insert(System.Int32? raisedBy, System.DateTime? nprDate, System.String qLocation, System.Int32? goodsInLineId, System.Int32? salesOrderNo, System.Int32? rejectedQty, System.Double? totalRejectedValue, System.String rejectionReason, System.String supplierRMANo, System.Boolean? correctiveActionReport, System.String supplierShipVia, System.String supplierShipAccount, System.Boolean? supplierToCredit, System.String supplierRef, System.Boolean? incurredCostToSales_Scrap, System.String comments, System.String stockLocation, System.Boolean? incurredCostToSales_Stock, System.String outWorkerName, System.Int32? outWorkerPONo, System.Int32? salesPersonNo, System.String salesAuthoriseBy,System.String salesAuthoriseName, System.DateTime? salesAuthoriseDate, System.Int32? logisticSRMANo, System.DateTime? logisticSRMADate, System.Int32? debitNoteNo, System.DateTime? debitNoteDate, System.Int32? nprCompletedByNo, System.DateTime? nprCompletedDate, System.Int32? updatedBy, System.Int32? customerNo, System.String adviceNotes, System.Double? unitCost,System.String changeLog,System.Int32? qtyAdvised, System.String nprReason1, System.String nprReason2, System.String nprComment,System.String salesAcion)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.ReportNPR.Insert(raisedBy, nprDate, qLocation, goodsInLineId, salesOrderNo, rejectedQty, totalRejectedValue, rejectionReason, supplierRMANo, correctiveActionReport, supplierShipVia, supplierShipAccount, supplierToCredit, supplierRef, incurredCostToSales_Scrap, comments, stockLocation, incurredCostToSales_Stock, outWorkerName, outWorkerPONo, salesPersonNo, salesAuthoriseBy, salesAuthoriseName, salesAuthoriseDate, logisticSRMANo, logisticSRMADate, debitNoteNo, debitNoteDate, nprCompletedByNo, nprCompletedDate, updatedBy, customerNo, adviceNotes, unitCost, changeLog, qtyAdvised, nprReason1, nprReason2, nprComment, salesAcion);
            return objReturn;
        }
        /// <summary>
        /// Insert
        /// Calls [usp_update_ReportNPR]
        /// </summary>
        public static bool Update(System.Int32 nprId, System.Int32? raisedBy, System.DateTime? nprDate, System.String qLocation, System.Int32? goodsInLineId, System.Int32? salesOrderNo, System.Int32? rejectedQty, System.Double? totalRejectedValue, System.String rejectionReason, System.String supplierRMANo, System.Boolean? correctiveActionReport, System.String supplierShipVia, System.String supplierShipAccount, System.Boolean? supplierToCredit, System.String supplierRef, System.Boolean? incurredCostToSales_Scrap, System.String comments, System.String stockLocation, System.Boolean? incurredCostToSales_Stock, System.String outWorkerName, System.Int32? outWorkerPONo, System.Int32? salesPersonNo, System.String salesAuthoriseBy, System.String salesAuthoriseName, System.DateTime? salesAuthoriseDate, System.Int32? logisticSRMANo, System.DateTime? logisticSRMADate, System.Int32? debitNoteNo, System.DateTime? debitNoteDate, System.Int32? nprCompletedByNo, System.DateTime? nprCompletedDate, System.Int32? updatedBy, System.Int32? customerNo, System.String adviceNotes, System.String changesLog, System.Double? unitCost, System.Int32? qtyAdvised, System.String nprReason1, System.String nprReason2, System.String nprComment,System.String salesAcion)
        {
            bool objReturn = Rebound.GlobalTrader.DAL.SiteProvider.ReportNPR.Update(nprId, raisedBy, nprDate, qLocation, goodsInLineId, salesOrderNo, rejectedQty, totalRejectedValue, rejectionReason, supplierRMANo, correctiveActionReport, supplierShipVia, supplierShipAccount, supplierToCredit, supplierRef, incurredCostToSales_Scrap, comments, stockLocation, incurredCostToSales_Stock, outWorkerName, outWorkerPONo, salesPersonNo, salesAuthoriseBy, salesAuthoriseName, salesAuthoriseDate, logisticSRMANo, logisticSRMADate, debitNoteNo, debitNoteDate, nprCompletedByNo, nprCompletedDate, updatedBy, customerNo, adviceNotes, changesLog, unitCost, qtyAdvised, nprReason1, nprReason2, nprComment, salesAcion);
            return objReturn;
        }
        /// <summary>
        /// Get NPR by NPRId
        /// calls [usp_select_NPRbyId]
        /// </summary>
        /// <param name="nprId"></param>
        /// <returns></returns>
        public static ReportNPR Get(System.Int32 nprId,System.Int32? clientNo)
        {
            Rebound.GlobalTrader.DAL.ReportNPRDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.ReportNPR.Get(nprId, clientNo);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Rebound.GlobalTrader.BLL.ReportNPR obj = new Rebound.GlobalTrader.BLL.ReportNPR();
                obj.NPRId = objDetails.NPRId;
                obj.NPRNo = objDetails.NPRNo;
                obj.RaisedBy = objDetails.RaisedBy;
                obj.NPRdate = objDetails.NPRdate;
                obj.QLocation = objDetails.QLocation;
                obj.GoodsInLineId = objDetails.GoodsInLineId;
                obj.GoodsInNo = objDetails.GoodsInNo;
                obj.SalesOrderNo = objDetails.SalesOrderNo;
                obj.TotalRejectedValue = objDetails.TotalRejectedValue;
                obj.RejectionReason = objDetails.RejectionReason;
                obj.SupplierRMANo = objDetails.SupplierRMANo;
                obj.CorrectiveActionReport = objDetails.CorrectiveActionReport;
                obj.SupplierShipVia = objDetails.SupplierShipVia;
                obj.SupplierShipAccount = objDetails.SupplierShipAccount;
                obj.SupplierToCredit = objDetails.SupplierToCredit;
                obj.SupplierRef = objDetails.SupplierRef;
                obj.IncurredCostToSales_Scrap = objDetails.IncurredCostToSales_Scrap;
                obj.Comments = objDetails.Comments;
                obj.StockLocation = objDetails.StockLocation;
                obj.IncurredCostToSales_Stock = objDetails.IncurredCostToSales_Stock;
                obj.OutworkerName = objDetails.OutworkerName;
                obj.OutworkerPONo = objDetails.OutworkerPONo;
                obj.SalesPersonNo = objDetails.SalesPersonNo;
                obj.SalesAuthorisePersonNo = objDetails.SalesAuthorisePersonNo;
                obj.SalesAuthoriseDate = objDetails.SalesAuthoriseDate;
                obj.LogisticSRMANo = objDetails.LogisticSRMANo;
                obj.LogisticSRMADate = objDetails.LogisticSRMADate;
                obj.DebitNoteNo = objDetails.DebitNoteNo;
                obj.DebitNoteDate = objDetails.DebitNoteDate;
                obj.NPRCompletedByNo = objDetails.NPRCompletedByNo;
                obj.NPRCompletedDate = objDetails.NPRCompletedDate;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.ReceiverName = objDetails.ReceiverName;
                obj.RejectedQty = objDetails.RejectedQty;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.AdviceNote = objDetails.AdviceNote;
                obj.Supplier = objDetails.Supplier;
                obj.PartNo = objDetails.PartNo;
                obj.CustomerName = objDetails.CustomerName;
                obj.CompletedByName = objDetails.CompletedByName;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.BuyerId = objDetails.BuyerId;
                obj.BuyerName = objDetails.BuyerName;
                obj.GoodsInNumber = objDetails.GoodsInNumber;
                obj.UnitCost = objDetails.UnitCost;
                obj.SalesAuthoriseBy = objDetails.SalesAuthoriseBy;
                obj.SalesAuthoriseName = objDetails.SalesAuthoriseName;
                obj.IsAuthorise = objDetails.IsAuthorise;
                obj.SalesPerson = objDetails.SalesPerson;
                obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                obj.QtyAdvised = objDetails.QtyAdvised;
                //[0001] start
                obj.CurrencyCode = objDetails.CurrencyCode;
                //[0001] end
                //[0002] start
                obj.Reason1 = objDetails.Reason1;
                obj.Reason2 = objDetails.Reason2;
                obj.Reason1Val = objDetails.Reason1Val;
                obj.Reason2Val = objDetails.Reason2Val;
                obj.NPRComment = objDetails.NPRComment;
                obj.SalesAction = objDetails.SalesAction;
                obj.ClientNo = objDetails.ClientNo;
                obj.ClientName = objDetails.ClientName;
                //[0002] end
                objDetails = null;
                return obj;
            }

        }

        /// <summary>
        /// Delete NPR by Id
        /// Calls [usp_delete_nprReport]
        /// </summary>
        /// <param name="nprId"></param>
        /// <returns></returns>
        public static bool Delete(System.Int32? nprId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.ReportNPR.Delete(nprId);
        }

        public static List<ReportNPR> GetNPRLog(System.Int32? nprId)
        {
           List<ReportNPRDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ReportNPR.GetNPRLog(nprId);
           if (lstDetails == null)
           {
               return null;
           }
           else
           {
               List<ReportNPR> lst = new List<ReportNPR>();
               foreach (ReportNPRDetails objDetails in lstDetails)
               {
                   ReportNPR obj = new ReportNPR();
                   obj.NPRLogId = objDetails.NPRLogId;
                   obj.NPRId = objDetails.NPRId;
                   obj.NPRNo = objDetails.NPRNo;
                   obj.Details = objDetails.Details;
                   obj.UpdatedByName = objDetails.UpdatedByName;
                   obj.DLUP = objDetails.DLUP;
                   lst.Add(obj);
                   obj = null;
               }
               lstDetails = null;
               return lst;
           }
        }

        public static Int32? getNPRCompanyID(System.Int32? SalesorderNo, System.Int32? ClientID)
        {
            Int32? NPRCompnayID = 0;
            NPRCompnayID = Rebound.GlobalTrader.DAL.SiteProvider.ReportNPR.getNPRCompanyID(SalesorderNo, ClientID);
            if (NPRCompnayID == null)
            {
                return null;
            }
            return NPRCompnayID;

        }
        /// <summary>
        /// Insert NPR Email Log
        /// Call [usp_insert_Email_NPR_Log]
        /// </summary>
        /// <param name="nprId"></param>
        /// <param name="details"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public static Int32 InsertEmailNPRLog(System.Int32? nprId, System.String details,  System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.ReportNPR.InsertEmailNPRLog(nprId, details, updatedBy);
            return objReturn;
        }


        public static List<ReportNPR> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nprSearch, System.String cmSearch, System.String action, System.Int32? isCompleted, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? goodsInNoLo, System.Int32? goodsInNoHi, System.DateTime? nprRaisedDateFrom, System.DateTime? nprRaisedDateTo, System.Int32? isAuthorised)
        {
            List<ReportNPRDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ReportNPR.DataListNugget(clientId, orderBy, sortDir, pageIndex, pageSize, nprSearch, cmSearch, action, isCompleted, purchaseOrderNoLo, purchaseOrderNoHi,goodsInNoLo,goodsInNoHi, nprRaisedDateFrom, nprRaisedDateTo, isAuthorised);
            if (lstDetails == null)
            {
                return new List<ReportNPR>();
            }
            else
            {
                List<ReportNPR> lst = new List<ReportNPR>();
                foreach (ReportNPRDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.ReportNPR obj = new Rebound.GlobalTrader.BLL.ReportNPR();
                    obj.NprId = objDetails.NprId;
                    obj.NprNo = objDetails.NprNo;
                    obj.Part = objDetails.Part;
                    obj.Location = objDetails.Location;
                    obj.Quantity = objDetails.Quantity;
                    obj.UnitCost = objDetails.UnitCost;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.AuthorisedBy = objDetails.AuthorisedBy;
                    obj.CompletedBy = objDetails.CompletedBy;
                    obj.NprRaisedDate = objDetails.NprRaisedDate;
                    obj.Action = objDetails.Action;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                    obj.POId = objDetails.POId;
                    obj.GoodsInLineId = objDetails.GoodsInLineId;
                    
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        //[002] Code End

        #endregion
    }
}
