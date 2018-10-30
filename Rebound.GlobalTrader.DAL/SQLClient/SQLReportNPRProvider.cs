/*
Marker     Changed by      Date          Remarks
[001]      Abhinav         24/03/2014    ESMS #108 to show GI currency on NPR
[002]      Abhinav         09/04/2014    ESMS #120 Add Reason1,Reason2,Comments fields in NPR
[003]      Raushan          13/09/2014   NPR Search
 */
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.Caching;
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL.SqlClient
{
    public class SqlReportNPRProvider:ReportNPRProvider
    {
        /// <summary>
        /// GetGoodsInLineById 
        /// Calls [usp_report_NPR]
        /// </summary>
        public override ReportNPRDetails GetGoodsInLineById(System.Int32 goodsInLineId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_report_NPR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@GoodsInLineId", SqlDbType.Int).Value = goodsInLineId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    ReportNPRDetails obj = new ReportNPRDetails();
                    obj.GoodsInNo = GetReaderValue_Int32(reader, "GoodsInNo", 0);
                    obj.GoodsInLineId = GetReaderValue_Int32(reader, "GoodsInLineId", 0);
                    obj.CurrentDate = GetReaderValue_DateTime(reader, "CurrentDate", DateTime.MinValue);
                    obj.QLocation = GetReaderValue_String(reader, "Location", "");
                    obj.NPRNo = GetReaderValue_String(reader, "NPRNo", "");
                    obj.ReceiverName = GetReaderValue_String(reader, "ReceiverName", "");
                    obj.PartNo = GetReaderValue_String(reader, "PartNo", "");
                    obj.RejectedQty = GetReaderValue_Int32(reader, "RejectedQty", 0);
                    obj.UnitCost = GetReaderValue_Double(reader, "UnitCost", 0);
                    obj.Supplier = GetReaderValue_String(reader, "Supplier", "");
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.AdviceNote = GetReaderValue_String(reader, "AdviceNote", "");
                    obj.TotalRejectedValue = GetReaderValue_Double(reader, "TotalRejectedValue", 0);
                    obj.CustomerName = GetReaderValue_String(reader, "CustomerName", "");
                    obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyId", null);
                    obj.SalesOrderNo = GetReaderValue_Int32(reader, "SONo", 0);
                    obj.RejectionReason = GetReaderValue_String(reader, "NonConformanceDetails", "");
                    //[0001] start
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    //[0001] end
                   
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get GoodsInLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
           
        }

        /// <summary>
        /// Insert
        /// Calls [usp_insert_ReportNPR]
        /// </summary>
        public override Int32 Insert(System.Int32? raisedBy, System.DateTime? nprDate, System.String qLocation, System.Int32? goodsInLineId, System.Int32? salesOrderNo, System.Int32? rejectedQty, System.Double? totalRejectedValue, System.String rejectionReason, System.String supplierRMANo, System.Boolean? correctiveActionReport, System.String supplierShipVia, System.String supplierShipAccount, System.Boolean?  supplierToCredit, System.String supplierRef, System.Boolean? incurredCostToSales_Scrap, System.String comments, System.String stockLocation, System.Boolean? incurredCostToSales_Stock, System.String outWorkerName, System.Int32? outWorkerPONo, System.Int32? salesPersonNo, System.String salesAuthoriseBy, System.String salesAuthoriseName, System.DateTime? salesAuthoriseDate, System.Int32? logisticSRMANo, System.DateTime? logisticSRMADate, System.Int32? debitNoteNo, System.DateTime? debitNoteDate, System.Int32? nprCompletedByNo, System.DateTime? nprCompletedDate, System.Int32? updatedBy, System.Int32? customerNo, System.String adviceNotes, System.Double? unitCost, System.String changeLog,System.Int32? qtyAdvised, System.String  nprReason1, System.String  nprReason2, System.String nprComment,System.String salesAcion)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_ReportNPR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RaisedBy", SqlDbType.Int).Value = raisedBy;
                cmd.Parameters.Add("@NPRdate", SqlDbType.DateTime).Value = nprDate;
                cmd.Parameters.Add("@QLocation", SqlDbType.NVarChar).Value = qLocation;
                cmd.Parameters.Add("@GoodsInLineNo", SqlDbType.Int).Value = goodsInLineId;
                cmd.Parameters.Add("@SalesOrderNo", SqlDbType.Int).Value = salesOrderNo;
                cmd.Parameters.Add("@RejectedQty", SqlDbType.Int).Value = rejectedQty;
                cmd.Parameters.Add("@TotalRejectedValue", SqlDbType.Float).Value = totalRejectedValue;
                cmd.Parameters.Add("@RejectionReason", SqlDbType.NVarChar).Value = rejectionReason;
                cmd.Parameters.Add("@SupplierRMANo", SqlDbType.NVarChar).Value = supplierRMANo;
                cmd.Parameters.Add("@CorrectiveActionReport", SqlDbType.Bit).Value = correctiveActionReport;
                cmd.Parameters.Add("@SupplierShipVia", SqlDbType.VarChar).Value = supplierShipVia;
                cmd.Parameters.Add("@SupplierShipAccount", SqlDbType.VarChar).Value = supplierShipAccount;
                cmd.Parameters.Add("@SupplierToCredit", SqlDbType.Bit).Value = supplierToCredit;
                cmd.Parameters.Add("@SupplierRef", SqlDbType.NVarChar).Value = supplierRef;
                cmd.Parameters.Add("@IncurredCostToSales_Scrap", SqlDbType.Bit).Value = incurredCostToSales_Scrap;
                cmd.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = comments;
                cmd.Parameters.Add("@StockLocation", SqlDbType.NVarChar).Value = stockLocation;
                cmd.Parameters.Add("@IncurredCostToSales_Stock", SqlDbType.Bit).Value = incurredCostToSales_Stock;
                cmd.Parameters.Add("@OutworkerName", SqlDbType.VarChar).Value = outWorkerName;
                cmd.Parameters.Add("@OutworkerPONo", SqlDbType.Int).Value = outWorkerPONo;
                cmd.Parameters.Add("@SalesPersonNo", SqlDbType.Int).Value = salesPersonNo;
                cmd.Parameters.Add("@SalesAuthoriseBy", SqlDbType.NVarChar).Value = salesAuthoriseBy;
                cmd.Parameters.Add("@SalesAuthoriseName", SqlDbType.NVarChar).Value = salesAuthoriseName;
                cmd.Parameters.Add("@SalesAuthoriseDate", SqlDbType.DateTime).Value = salesAuthoriseDate;
                cmd.Parameters.Add("@LogisticSRMANo", SqlDbType.Int).Value = logisticSRMANo;
                cmd.Parameters.Add("@LogisticSRMADate", SqlDbType.DateTime).Value = logisticSRMADate;
                cmd.Parameters.Add("@DebitNoteNo", SqlDbType.Int).Value = debitNoteNo;
                cmd.Parameters.Add("@DebitNoteDate", SqlDbType.DateTime).Value = debitNoteDate;
                cmd.Parameters.Add("@NPRCompletedByNo", SqlDbType.Int).Value = nprCompletedByNo;
                cmd.Parameters.Add("@NPRCompleteddATE", SqlDbType.DateTime).Value = nprCompletedDate;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@CustomerNo", SqlDbType.Int).Value = customerNo;
                cmd.Parameters.Add("@AdviceNote", SqlDbType.NVarChar).Value = adviceNotes;
                cmd.Parameters.Add("@UnitCost", SqlDbType.Float).Value = unitCost;
                cmd.Parameters.Add("@ChangeLog", SqlDbType.VarChar).Value = changeLog;
                //[0002] start
                cmd.Parameters.Add("@Reason1", SqlDbType.NVarChar).Value = nprReason1;
                cmd.Parameters.Add("@Reason2", SqlDbType.NVarChar).Value = nprReason2;
                cmd.Parameters.Add("@NPRComments", SqlDbType.NVarChar).Value = nprComment;
                //[0002] end
                cmd.Parameters.Add("@QtyAdvised", SqlDbType.Int).Value = qtyAdvised;
                cmd.Parameters.Add("@SalesAction", SqlDbType.VarChar).Value = salesAcion;

                cmd.Parameters.Add("@NPRId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@NPRId"].Value;

            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert NPR Report", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Insert
        /// Calls [usp_update_ReportNPR]
        /// </summary>
        public override bool Update(System.Int32 nprId, System.Int32? raisedBy, System.DateTime? nprDate, System.String qLocation, System.Int32? goodsInLineId, System.Int32? salesOrderNo, System.Int32? rejectedQty, System.Double? totalRejectedValue, System.String rejectionReason, System.String supplierRMANo, System.Boolean? correctiveActionReport, System.String supplierShipVia, System.String supplierShipAccount, System.Boolean? supplierToCredit, System.String supplierRef, System.Boolean? incurredCostToSales_Scrap, System.String comments, System.String stockLocation, System.Boolean? incurredCostToSales_Stock, System.String outWorkerName, System.Int32? outWorkerPONo, System.Int32? salesPersonNo, System.String salesAuthoriseBy, System.String salesAuthoriseName, System.DateTime? salesAuthoriseDate, System.Int32? logisticSRMANo, System.DateTime? logisticSRMADate, System.Int32? debitNoteNo, System.DateTime? debitNoteDate, System.Int32? nprCompletedByNo, System.DateTime? nprCompletedDate, System.Int32? updatedBy, System.Int32? customerNo, System.String adviceNotes, System.String changesLog, System.Double? unitCost, System.Int32? qtyAdvised, System.String nprReason1, System.String nprReason2, System.String nprComment, System.String salesAcion)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_ReportNPR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NPRId", SqlDbType.Int).Value = nprId;
                cmd.Parameters.Add("@RaisedBy", SqlDbType.Int).Value = raisedBy;
                cmd.Parameters.Add("@NPRdate", SqlDbType.DateTime).Value = nprDate;
                cmd.Parameters.Add("@QLocation", SqlDbType.NVarChar).Value = qLocation;
                cmd.Parameters.Add("@GoodsInLineNo", SqlDbType.Int).Value = goodsInLineId;
                cmd.Parameters.Add("@SalesOrderNo", SqlDbType.Int).Value = salesOrderNo;
                cmd.Parameters.Add("@RejectedQty", SqlDbType.Int).Value = rejectedQty;
                cmd.Parameters.Add("@TotalRejectedValue", SqlDbType.Float).Value = totalRejectedValue;
                cmd.Parameters.Add("@RejectionReason", SqlDbType.NVarChar).Value = rejectionReason;
                cmd.Parameters.Add("@SupplierRMANo", SqlDbType.NVarChar).Value = supplierRMANo;
                cmd.Parameters.Add("@CorrectiveActionReport", SqlDbType.Bit).Value = correctiveActionReport;
                cmd.Parameters.Add("@SupplierShipVia", SqlDbType.VarChar).Value = supplierShipVia;
                cmd.Parameters.Add("@SupplierShipAccount", SqlDbType.VarChar).Value = supplierShipAccount;
                cmd.Parameters.Add("@SupplierToCredit", SqlDbType.Bit).Value = supplierToCredit;
                cmd.Parameters.Add("@SupplierRef", SqlDbType.NVarChar).Value = supplierRef;
                cmd.Parameters.Add("@IncurredCostToSales_Scrap", SqlDbType.Bit).Value = incurredCostToSales_Scrap;
                cmd.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = comments;
                cmd.Parameters.Add("@StockLocation", SqlDbType.NVarChar).Value = stockLocation;
                cmd.Parameters.Add("@IncurredCostToSales_Stock", SqlDbType.Bit).Value = incurredCostToSales_Stock;
                cmd.Parameters.Add("@OutworkerName", SqlDbType.NVarChar).Value = outWorkerName;
                cmd.Parameters.Add("@OutworkerPONo", SqlDbType.Int).Value = outWorkerPONo;
                cmd.Parameters.Add("@SalesPersonNo", SqlDbType.Int).Value = salesPersonNo;
                cmd.Parameters.Add("@SalesAuthoriseBy", SqlDbType.NVarChar).Value = salesAuthoriseBy;
                cmd.Parameters.Add("@SalesAuthoriseName", SqlDbType.NVarChar).Value = salesAuthoriseName;
                cmd.Parameters.Add("@SalesAuthoriseDate", SqlDbType.DateTime).Value = salesAuthoriseDate;
                cmd.Parameters.Add("@LogisticSRMANo", SqlDbType.Int).Value = logisticSRMANo;
                cmd.Parameters.Add("@LogisticSRMADate", SqlDbType.DateTime).Value = logisticSRMADate;
                cmd.Parameters.Add("@DebitNoteNo", SqlDbType.Int).Value = debitNoteNo;
                cmd.Parameters.Add("@DebitNoteDate", SqlDbType.DateTime).Value = debitNoteDate;
                cmd.Parameters.Add("@NPRCompletedByNo", SqlDbType.Int).Value = nprCompletedByNo;
                cmd.Parameters.Add("@NPRCompleteddATE", SqlDbType.DateTime).Value = nprCompletedDate;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@CustomerNo", SqlDbType.Int).Value = customerNo;
                cmd.Parameters.Add("@AdviceNote", SqlDbType.NVarChar).Value = adviceNotes;
                cmd.Parameters.Add("@ChangesLog", SqlDbType.NVarChar).Value = changesLog;
                cmd.Parameters.Add("@UnitCost", SqlDbType.Float).Value = unitCost;
                cmd.Parameters.Add("@QtyAdvised", SqlDbType.Int).Value = qtyAdvised;
                //[0002] start
                cmd.Parameters.Add("@Reason1", SqlDbType.NVarChar).Value = nprReason1;
                cmd.Parameters.Add("@Reason2", SqlDbType.NVarChar).Value = nprReason2;
                cmd.Parameters.Add("@NPRComments", SqlDbType.NVarChar).Value = nprComment;
                //[0002] end
                cmd.Parameters.Add("@SalesAction", SqlDbType.VarChar).Value = salesAcion;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);

            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update NPR Report", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public override ReportNPRDetails Get(System.Int32 nprId, System.Int32? clientNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_NPRbyId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@NPRId", SqlDbType.Int).Value = nprId;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    ReportNPRDetails obj = new ReportNPRDetails();
                    obj.NPRId = GetReaderValue_Int32(reader, "NPRId", 0);
                    obj.NPRNo = GetReaderValue_String(reader, "NPRNo", "");
                    obj.RaisedBy = GetReaderValue_NullableInt32(reader, "RaisedBy", null);
                    obj.NPRdate = GetReaderValue_NullableDateTime(reader, "NPRdate", null);
                    obj.QLocation = GetReaderValue_String(reader, "QLocation", "");
                    obj.GoodsInLineId = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", 0);
                    obj.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", 0);
                    obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
                    obj.TotalRejectedValue = GetReaderValue_NullableDouble(reader, "TotalRejectedValue", null);
                    obj.RejectionReason = GetReaderValue_String(reader, "RejectionReason", "");
                    obj.SupplierRMANo = GetReaderValue_String(reader, "SupplierRMANo", "");
                    obj.CorrectiveActionReport = GetReaderValue_NullableBoolean(reader, "CorrectiveActionReport", false);
                    obj.SupplierShipVia = GetReaderValue_String(reader, "SupplierShipVia", "");
                    obj.SupplierShipAccount = GetReaderValue_String(reader, "SupplierShipAccount", "");
                    obj.SupplierToCredit = GetReaderValue_NullableBoolean(reader, "SupplierToCredit", false);
                    obj.SupplierRef = GetReaderValue_String(reader, "SupplierRef", "");
                    obj.IncurredCostToSales_Scrap = GetReaderValue_NullableBoolean(reader, "IncurredCostToSales_Scrap", false);
                    obj.Comments = GetReaderValue_String(reader, "Comments", "");
                    obj.StockLocation = GetReaderValue_String(reader, "StockLocation", "");
                    obj.IncurredCostToSales_Stock = GetReaderValue_NullableBoolean(reader, "IncurredCostToSales_Stock", false);
                    obj.OutworkerName = GetReaderValue_String(reader, "OutworkerName", "");
                    obj.OutworkerPONo = GetReaderValue_NullableInt32(reader, "OutworkerPONo", null);
                    obj.SalesPersonNo = GetReaderValue_NullableInt32(reader, "SalesPersonNo", null);
                    obj.SalesAuthorisePersonNo = GetReaderValue_NullableInt32(reader, "SalesAuthorisePersonNo", null);
                    obj.SalesAuthoriseDate = GetReaderValue_NullableDateTime(reader, "SalesAuthoriseDate", null);
                    obj.LogisticSRMANo = GetReaderValue_NullableInt32(reader, "LogisticSRMANo", null);
                    obj.LogisticSRMADate = GetReaderValue_NullableDateTime(reader, "LogisticSRMADate", null);
                    obj.DebitNoteNo = GetReaderValue_NullableInt32(reader, "DebitNoteNo", null);
                    obj.DebitNoteDate = GetReaderValue_NullableDateTime(reader, "DebitNoteDate", null);
                    obj.NPRCompletedByNo = GetReaderValue_NullableInt32(reader, "NPRCompletedByNo", null);
                    obj.NPRCompletedDate = GetReaderValue_NullableDateTime(reader, "NPRCompleteddATE", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.Now);
                    obj.ReceiverName = GetReaderValue_String(reader, "ReceiverName", "");
                    obj.RejectedQty = GetReaderValue_NullableInt32(reader, "RejectedQty", null);
                    obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CustomerNo", null);
                    obj.AdviceNote = GetReaderValue_String(reader, "AdviceNote", null);
                    obj.Supplier = GetReaderValue_String(reader, "CompanyName", "");
                    obj.PartNo = GetReaderValue_String(reader, "PartNo", "");
                    obj.CustomerName = GetReaderValue_String(reader, "CustomerName", "");
                    obj.CompletedByName = GetReaderValue_String(reader, "CompletedByName", "");
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.BuyerId = GetReaderValue_NullableInt32(reader, "BuyerId", null);
                    obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
                    obj.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", 0);
                    obj.UnitCost = GetReaderValue_NullableDouble(reader, "UnitCost", null);
                    obj.SalesAuthoriseBy = GetReaderValue_String(reader, "SalesAuthoriseBy", "");
                    obj.SalesAuthoriseName = GetReaderValue_String(reader, "SalesAuthoriseName", "");
                    obj.IsAuthorise = GetReaderValue_NullableBoolean(reader, "IsAuthorise", false);
                    obj.SalesPerson = GetReaderValue_String(reader, "SalesPerson", "");
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.QtyAdvised = GetReaderValue_NullableInt32(reader, "QtyAdvised", null);
                    //[0001] start
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    //[0001] end
                    //[0002] start
                    obj.Reason1 = GetReaderValue_String(reader, "Reason1", "");
                    obj.Reason2 = GetReaderValue_String(reader, "Reason2", "");
                    obj.Reason1Val = GetReaderValue_String(reader, "Reason1Val", "");
                    obj.Reason2Val = GetReaderValue_String(reader, "Reason2Val", "");
                    obj.NPRComment = GetReaderValue_String(reader, "NPRComments", "");
                    //[0002] end
                    obj.SalesAction = GetReaderValue_String(reader, "SalesAction", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get NPR", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }

        }
        /// <summary>
        /// Delete NPR by Id
        /// Calls [usp_delete_nprReport]
        /// </summary>
        /// <param name="nprId"></param>
        /// <returns></returns>
        public override bool Delete(System.Int32? nprId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_nprReport", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NPRId", SqlDbType.Int).Value = nprId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete NPR Report", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        public override List<ReportNPRDetails> GetNPRLog(System.Int32? nprId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_NPRLog", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@NPRId", SqlDbType.Int).Value = nprId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<ReportNPRDetails> lst=new List<ReportNPRDetails>();
                while(reader.Read())
                {
                    ReportNPRDetails obj = new ReportNPRDetails();
                    obj.NPRLogId = GetReaderValue_Int32(reader, "NPRLogId", 0);
                    obj.NPRId = GetReaderValue_Int32(reader, "NPRId", 0);
                    obj.NPRNo = GetReaderValue_String(reader, "NPRNo", "");
                    obj.Details = GetReaderValue_String(reader, "Detail", "");
                    obj.UpdatedByName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.Now);
                    lst.Add(obj);
					obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get NPR Log", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }

        }

        public override int? getNPRCompanyID(System.Int32? SalesorderNo, System.Int32? ClientNo )
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            int? CompanyNo=0 ;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_NPR_CompanyID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SalesOrderNo", SqlDbType.Int).Value = SalesorderNo;
                cmd.Parameters.Add("@clientNo", SqlDbType.Int).Value = ClientNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", 0);
                }
                return CompanyNo;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to find salesorder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Insert NPR Email Log
        /// Call [usp_insert_Email_NPR_Log]
        /// </summary>
        /// <param name="nprId"></param>
        /// <param name="details"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public override Int32 InsertEmailNPRLog(System.Int32? nprId, System.String details, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_Email_NPR_Log", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NPRNo", SqlDbType.Int).Value = nprId;
                cmd.Parameters.Add("@Detail", SqlDbType.NVarChar).Value = details;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@NPRIdLog", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@NPRIdLog"].Value;

            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert NPR Email Log", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        // [003] Code Start
        /// <summary>
        /// DataListNugget 
        /// Calls [usp_datalistnugget_NPR]
        /// </summary>
        public override List<ReportNPRDetails> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nprSearch,
            System.String cmSearch, System.String action, System.Int32? isCompleted, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? goodsInNoLo, System.Int32? goodsInNoHi,
            System.DateTime? nprRaisedDateFrom, System.DateTime? nprRaisedDateTo, System.Int32? isAuthorised)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_datalistnugget_NPR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
                cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                cmd.Parameters.Add("@NprSearch", SqlDbType.NVarChar).Value = nprSearch;
                cmd.Parameters.Add("@CmSearch", SqlDbType.NVarChar).Value = cmSearch;
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = action;
                if (isCompleted == 1)
                    cmd.Parameters.Add("@IsCompleted", SqlDbType.Int).Value = isCompleted;
                else if (isCompleted == 2)            
                cmd.Parameters.Add("@IsCompleted", SqlDbType.Int).Value = 0; 
                else
                    cmd.Parameters.Add("@IsCompleted", SqlDbType.Int).Value = DBNull.Value; 
                cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
                cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
                cmd.Parameters.Add("@GoodsInNoLo", SqlDbType.Int).Value = goodsInNoLo;
                cmd.Parameters.Add("@GoodsInNoHi", SqlDbType.Int).Value = goodsInNoHi;
                cmd.Parameters.Add("@NprRaisedDateFrom", SqlDbType.DateTime).Value = nprRaisedDateFrom;
                cmd.Parameters.Add("@NprRaisedDateTo", SqlDbType.DateTime).Value = nprRaisedDateTo;
                if (isAuthorised == 1)
                    cmd.Parameters.Add("@isAuthorised", SqlDbType.Int).Value = isAuthorised;
                else if (isAuthorised == 2)
                cmd.Parameters.Add("@isAuthorised", SqlDbType.Int).Value = 0;
                else
                    cmd.Parameters.Add("@isAuthorised", SqlDbType.Int).Value = DBNull.Value; 
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<ReportNPRDetails> lst = new List<ReportNPRDetails>();
                while (reader.Read())
                {
                    ReportNPRDetails obj = new ReportNPRDetails();
                    obj.NprId = GetReaderValue_Int32(reader, "NPRId", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.NprNo = GetReaderValue_String(reader, "NPRNo"," ");
                    obj.Quantity = GetReaderValue_Int32(reader, "RejectedQty", 0);
                    obj.NprRaisedDate = GetReaderValue_NullableDateTime(reader, "NPRdate", null);                    
                    obj.UnitCost = GetReaderValue_Int32(reader, "UnitCost", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.AuthorisedBy = GetReaderValue_String(reader, "SalesAuthoriseName", "");
                    obj.CompletedBy = GetReaderValue_String(reader, "CompletedBy", "");
                    obj.Location = GetReaderValue_String(reader, "Location", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.Action = GetReaderValue_String(reader, "SalesAction", "");
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
                    obj.POId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
                    obj.GoodsInLineId = GetReaderValue_Int32(reader, "GoodsInLineNo", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Npr", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        // [003] Code End
    }
}
