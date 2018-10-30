/*
Marker     changed by      date         Remarks
[001]      Abhinav       16/09/20011   ESMS Ref:29 - Display Buyer information in GI
[002]      Vinay           07/05/2012   This need to upload pdf document for goodsIn section
[003]      Vinay           18/09/2012    Ref:## - Display Purchase Country
[003]      Vinay           20/06/2013    CR:- - Supplier Invoice
[004]      Vinay           08/07/2013    Ref:## -32 Nice Label Printing
[005]      Aashu           04/06/2018    Quick Jump in Global Warehouse
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
    public class SqlGoodsInProvider : GoodsInProvider
    {
        /// <summary>
        /// Count GoodsIn
        /// Calls [usp_count_GoodsIn_for_Client]
        /// </summary>
        public override Int32 CountForClient(System.Int32? clientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_count_GoodsIn_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                return (Int32)ExecuteScalar(cmd);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to count GoodsIn", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Delete GoodsIn
        /// Calls [usp_delete_GoodsIn]
        /// </summary>
        public override bool Delete(System.Int32? goodsInId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_GoodsIn", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GoodsInId", SqlDbType.Int).Value = goodsInId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete GoodsIn", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        //[003] code start
        /// <summary>
        /// Create a new row
        /// Calls [usp_insert_GoodsIn]
        /// </summary>
        public override Int32 Insert(System.Int32? clientNo, System.Int32? shipViaNo, System.String airWayBill, System.String reference, System.Int32? companyNo, System.String receivingNotes, System.DateTime? dateReceived, System.Int32? receivedBy, System.Int32? purchaseOrderNo, System.Int32? customerRmaNo, System.Int32? warehouseNo, System.Int32? currencyNo, System.Int32? updatedBy, System.Int32? purchaseCountryNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_GoodsIn", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@ShipViaNo", SqlDbType.Int).Value = shipViaNo;
                cmd.Parameters.Add("@AirWayBill", SqlDbType.NVarChar).Value = airWayBill;
                cmd.Parameters.Add("@Reference", SqlDbType.NVarChar).Value = reference;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
                cmd.Parameters.Add("@ReceivingNotes", SqlDbType.NVarChar).Value = receivingNotes;
                cmd.Parameters.Add("@DateReceived", SqlDbType.DateTime).Value = dateReceived;
                cmd.Parameters.Add("@ReceivedBy", SqlDbType.Int).Value = receivedBy;
                cmd.Parameters.Add("@PurchaseOrderNo", SqlDbType.Int).Value = purchaseOrderNo;
                cmd.Parameters.Add("@CustomerRMANo", SqlDbType.Int).Value = customerRmaNo;
                cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
                cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@PurchaseCountryNo", SqlDbType.Int).Value = purchaseCountryNo;
                cmd.Parameters.Add("@GoodsInId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@GoodsInId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert GoodsIn", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[003] code start
        /// <summary>
        /// ItemSearch 
        /// Calls [usp_itemsearch_GoodsIn]
        /// </summary>
        public override List<GoodsInDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String airWayBillSearch, System.String cmSearch, System.Int32? receivedBySearch, System.Boolean? includeInvoiced, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.Int32? goodsInNoLo, System.Int32? goodsInNoHi, System.DateTime? dateReceivedFrom, System.DateTime? dateReceivedTo, System.Boolean IsGlobal)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_itemsearch_GoodsIn", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
                cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                cmd.Parameters.Add("@AirWayBillSearch", SqlDbType.NVarChar).Value = airWayBillSearch;
                cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
                cmd.Parameters.Add("@ReceivedBySearch", SqlDbType.Int).Value = receivedBySearch;
                cmd.Parameters.Add("@IncludeInvoiced", SqlDbType.Bit).Value = includeInvoiced;
                cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
                cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
                cmd.Parameters.Add("@CustomerRMANoLo", SqlDbType.Int).Value = customerRmaNoLo;
                cmd.Parameters.Add("@CustomerRMANoHi", SqlDbType.Int).Value = customerRmaNoHi;
                cmd.Parameters.Add("@GoodsInNoLo", SqlDbType.Int).Value = goodsInNoLo;
                cmd.Parameters.Add("@GoodsInNoHi", SqlDbType.Int).Value = goodsInNoHi;
                cmd.Parameters.Add("@DateReceivedFrom", SqlDbType.DateTime).Value = dateReceivedFrom;
                cmd.Parameters.Add("@DateReceivedTo", SqlDbType.DateTime).Value = dateReceivedTo;
                cmd.Parameters.Add("@IsGlobal", SqlDbType.Bit).Value = IsGlobal;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<GoodsInDetails> lst = new List<GoodsInDetails>();
                while (reader.Read())
                {
                    GoodsInDetails obj = new GoodsInDetails();
                    obj.GoodsInId = GetReaderValue_Int32(reader, "GoodsInId", 0);
                    obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
                    obj.AirWayBill = GetReaderValue_String(reader, "AirWayBill", "");
                    obj.Reference = GetReaderValue_String(reader, "Reference", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    obj.ReceiverName = GetReaderValue_String(reader, "ReceiverName", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get GoodsIns", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Get 
        /// Calls [usp_select_GoodsIn]
        /// </summary>
        public override GoodsInDetails Get(System.Int32? goodsInId, bool? isHub)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            //string proc = "usp_select_GoodsIn";
            //proc = isHub==true ? "usp_select_GoodsIn_Hub" : proc;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_GoodsIn", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@GoodsInId", SqlDbType.Int).Value = goodsInId;
                cmd.Parameters.Add("@IsHub", SqlDbType.Bit).Value = isHub ?? false;

                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetGoodsInFromReader(reader);
                    GoodsInDetails obj = new GoodsInDetails();
                    obj.GoodsInId = GetReaderValue_Int32(reader, "GoodsInId", 0);
                    obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.AirWayBill = GetReaderValue_String(reader, "AirWayBill", "");
                    obj.Reference = GetReaderValue_String(reader, "Reference", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", "");
                    obj.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue);
                    obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                    obj.ReceivedBy = GetReaderValue_Int32(reader, "ReceivedBy", 0);
                    obj.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0);
                    obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
                    obj.SupplierInvoice = GetReaderValue_String(reader, "SupplierInvoice", "");
                    obj.InvoiceDate = GetReaderValue_NullableDateTime(reader, "InvoiceDate", null);
                    obj.InvoiceAmount = GetReaderValue_NullableDouble(reader, "InvoiceAmount", null);
                    obj.BankFee = GetReaderValue_NullableDouble(reader, "BankFee", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.GoodsValue = GetReaderValue_NullableDouble(reader, "GoodsValue", null);
                    obj.Tax = GetReaderValue_NullableDouble(reader, "Tax", null);
                    obj.DeliveryCharge = GetReaderValue_NullableDouble(reader, "DeliveryCharge", null);
                    obj.CreditCardFee = GetReaderValue_NullableDouble(reader, "CreditCardFee", null);
                    obj.CanBeExported = GetReaderValue_Boolean(reader, "CanBeExported", false);
                    obj.Exported = GetReaderValue_Boolean(reader, "Exported", false);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    obj.ReceiverName = GetReaderValue_String(reader, "ReceiverName", "");
                    // [001] code start
                    obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
                    // [001] code end
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.GoodsInValue = GetReaderValue_NullableDouble(reader, "GoodsInValue", null);
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
                    obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
                    obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    //[002] code start
                    obj.PurchaseCountryNo = GetReaderValue_NullableInt32(reader, "PurchaseCountryNo", null);
                    obj.PurchaseCountryName = GetReaderValue_String(reader, "PurchaseCountryName", "");
                    //[002] code end
                    obj.SupplierType = GetReaderValue_String(reader, "SupplierType", "");
                    //[003] code start
                    obj.SupplierInvoiceNos = GetReaderValue_String(reader, "SupplierInvoiceNos", "");
                    obj.SupplierInvoiceNumbers = GetReaderValue_String(reader, "SupplierInvoiceNumbers", "");
                    //[003] code end
                    obj.IPOSupplier = GetReaderValue_NullableInt32(reader, "IPOSupplier", null);
                    obj.IPOSupplierName = GetReaderValue_String(reader, "IPOSupplierName", "");

                    obj.InternalPurchaseOrderId = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderId", null);
                    obj.InternalPurchaseOrderNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNumber", null);
                    obj.GoodsInValueForClient = GetReaderValue_NullableDouble(reader, "GoodsInValueForClient", null);
                    obj.POClientNo = GetReaderValue_NullableInt32(reader, "IPOClientNo", 0);

                    obj.ClientCurrencyNo = GetReaderValue_NullableInt32(reader, "ClientCurrencyNo", 0);
                    obj.ClientCurrencyCode = GetReaderValue_String(reader, "ClientCurrencyCode", "");

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
                throw new Exception("Failed to get GoodsIn", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetAsReceivedPO 
        /// Calls [usp_select_GoodsIn_as_ReceivedPO]
        /// </summary>
        public override GoodsInDetails GetAsReceivedPO(System.Int32? purchaseOrderNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_GoodsIn_as_ReceivedPO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@PurchaseOrderNo", SqlDbType.Int).Value = purchaseOrderNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetGoodsInFromReader(reader);
                    GoodsInDetails obj = new GoodsInDetails();
                    obj.AirWayBill = GetReaderValue_String(reader, "AirWayBill", "");
                    obj.Reference = GetReaderValue_String(reader, "Reference", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", "");
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                    obj.ReceivedBy = GetReaderValue_Int32(reader, "ReceivedBy", 0);
                    obj.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0);
                    obj.SupplierInvoice = GetReaderValue_String(reader, "SupplierInvoice", "");
                    obj.InvoiceDate = GetReaderValue_NullableDateTime(reader, "InvoiceDate", null);
                    obj.InvoiceAmount = GetReaderValue_NullableDouble(reader, "InvoiceAmount", null);
                    obj.BankFee = GetReaderValue_NullableDouble(reader, "BankFee", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
                    obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
                    obj.ReceivedByName = GetReaderValue_String(reader, "ReceivedByName", "");
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.TotalShipInCost = GetReaderValue_NullableDouble(reader, "TotalShipInCost", null);
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
                throw new Exception("Failed to get GoodsIn", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetByNumber 
        /// Calls [usp_select_GoodsIn_by_Number]
        /// </summary>
        public override GoodsInDetails GetByNumber(System.Int32? goodsInNumber, System.Int32? clientNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_GoodsIn_by_Number", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@GoodsInNumber", SqlDbType.Int).Value = goodsInNumber;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetGoodsInFromReader(reader);
                    GoodsInDetails obj = new GoodsInDetails();
                    obj.GoodsInId = GetReaderValue_Int32(reader, "GoodsInId", 0);
                    obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.AirWayBill = GetReaderValue_String(reader, "AirWayBill", "");
                    obj.Reference = GetReaderValue_String(reader, "Reference", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", "");
                    obj.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue);
                    obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                    obj.ReceivedBy = GetReaderValue_Int32(reader, "ReceivedBy", 0);
                    obj.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0);
                    obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
                    obj.SupplierInvoice = GetReaderValue_String(reader, "SupplierInvoice", "");
                    obj.InvoiceDate = GetReaderValue_NullableDateTime(reader, "InvoiceDate", null);
                    obj.InvoiceAmount = GetReaderValue_NullableDouble(reader, "InvoiceAmount", null);
                    obj.BankFee = GetReaderValue_NullableDouble(reader, "BankFee", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.GoodsValue = GetReaderValue_NullableDouble(reader, "GoodsValue", null);
                    obj.Tax = GetReaderValue_NullableDouble(reader, "Tax", null);
                    obj.DeliveryCharge = GetReaderValue_NullableDouble(reader, "DeliveryCharge", null);
                    obj.CreditCardFee = GetReaderValue_NullableDouble(reader, "CreditCardFee", null);
                    obj.CanBeExported = GetReaderValue_Boolean(reader, "CanBeExported", false);
                    obj.Exported = GetReaderValue_Boolean(reader, "Exported", false);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    obj.ReceiverName = GetReaderValue_String(reader, "ReceiverName", "");
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.GoodsInValue = GetReaderValue_NullableDouble(reader, "GoodsInValue", null);
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
                    obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
                    obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
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
                throw new Exception("Failed to get GoodsIn", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetForPage 
        /// Calls [usp_select_GoodsIn_for_Page]
        /// </summary>
        public override GoodsInDetails GetForPage(System.Int32? goodsInId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_GoodsIn_for_Page", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@GoodsInId", SqlDbType.Int).Value = goodsInId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetGoodsInFromReader(reader);
                    GoodsInDetails obj = new GoodsInDetails();
                    obj.GoodsInId = GetReaderValue_Int32(reader, "GoodsInId", 0);
                    obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
                    obj.CompanyNameForSearch = GetReaderValue_String(reader, "CompanyNameForSearch", "");
                    // [002] code start
                    obj.IsPDFAvailable = GetReaderValue_Boolean(reader, "IsPDFAvailable", false);
                    // [002] code end
                    //[003] code start
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    //[003] code end
                    obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", 0);
                    obj.GlobalCurrencyNo = GetReaderValue_NullableInt32(reader, "GlobalCurrencyNo", 0);
                    obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.POClientNo = GetReaderValue_Int32(reader, "POClientNo", 0);
                    obj.IPOSupplierName = GetReaderValue_String(reader, "IPOSupplierName", "");
                    obj.IPOSupplier = GetReaderValue_Int32(reader, "IPOSupplier", 0);
                    obj.InternalPurchaseOrderId = GetReaderValue_Int32(reader, "InternalPurchaseOrderId", 0);
                    obj.InternalPurchaseOrderNo = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.ClientBaseCurrencyID = GetReaderValue_NullableInt32(reader, "ClientBaseCurrencyID", 0);
                    obj.ClientBaseCurrencyCode = GetReaderValue_String(reader, "ClientBaseCurrencyCode", "");
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
                throw new Exception("Failed to get GoodsIn", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetForPrint 
        /// Calls [usp_select_GoodsIn_for_Print]
        /// </summary>
        public override GoodsInDetails GetForPrint(System.Int32? goodsInId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_GoodsIn_for_Print", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@GoodsInId", SqlDbType.Int).Value = goodsInId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetGoodsInFromReader(reader);
                    GoodsInDetails obj = new GoodsInDetails();
                    obj.GoodsInId = GetReaderValue_Int32(reader, "GoodsInId", 0);
                    obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.AirWayBill = GetReaderValue_String(reader, "AirWayBill", "");
                    obj.Reference = GetReaderValue_String(reader, "Reference", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", "");
                    obj.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue);
                    obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                    obj.ReceivedBy = GetReaderValue_Int32(reader, "ReceivedBy", 0);
                    obj.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0);
                    obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
                    obj.SupplierInvoice = GetReaderValue_String(reader, "SupplierInvoice", "");
                    obj.InvoiceDate = GetReaderValue_NullableDateTime(reader, "InvoiceDate", null);
                    obj.InvoiceAmount = GetReaderValue_NullableDouble(reader, "InvoiceAmount", null);
                    obj.BankFee = GetReaderValue_NullableDouble(reader, "BankFee", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.GoodsValue = GetReaderValue_NullableDouble(reader, "GoodsValue", null);
                    obj.Tax = GetReaderValue_NullableDouble(reader, "Tax", null);
                    obj.DeliveryCharge = GetReaderValue_NullableDouble(reader, "DeliveryCharge", null);
                    obj.CreditCardFee = GetReaderValue_NullableDouble(reader, "CreditCardFee", null);
                    obj.CanBeExported = GetReaderValue_Boolean(reader, "CanBeExported", false);
                    obj.Exported = GetReaderValue_Boolean(reader, "Exported", false);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    obj.ReceiverName = GetReaderValue_String(reader, "ReceiverName", "");
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.GoodsInValue = GetReaderValue_NullableDouble(reader, "GoodsInValue", null);
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
                    obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
                    obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.SupplierTelephone = GetReaderValue_String(reader, "SupplierTelephone", "");
                    obj.SupplierFax = GetReaderValue_String(reader, "SupplierFax", "");
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
                throw new Exception("Failed to get GoodsIn", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetIDByNumber 
        /// Calls [usp_select_GoodsIn_ID_by_Number]
        /// </summary>
        public override List<GoodsInDetails> GetIDByNumber(System.Int32? goodsInNumber, System.Int32? clientNo, System.Int32? isGlobalUser)
        {
            //[005] start
            SqlConnection cn = null;
            SqlCommand cmd = null;
            List<GoodsInDetails> lstGoodsIn = new List<GoodsInDetails>();
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_GoodsIn_ID_by_Number", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@GoodsInNumber", SqlDbType.Int).Value = goodsInNumber;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@IsGlobalUser", SqlDbType.Int).Value = isGlobalUser;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                while (reader.Read())
                {
                    //return GetGoodsInFromReader(reader);
                    GoodsInDetails obj = new GoodsInDetails();
                    obj.GoodsInId = GetReaderValue_Int32(reader, "GoodsInId", 0);
                    obj.GoodsInNumberDetail = GetReaderValue_String(reader, "GoodsInNumberDetail", "false");
                    lstGoodsIn.Add(obj);
                }
                return lstGoodsIn;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get GoodsIn", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
            //[005] end
        }


        /// <summary>
        /// GetNextNumber 
        /// Calls [usp_select_GoodsIn_NextNumber]
        /// </summary>
        public override GoodsInDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_GoodsIn_NextNumber", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@NewNumber", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetGoodsInFromReader(reader);
                    GoodsInDetails obj = new GoodsInDetails();
                    obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
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
                throw new Exception("Failed to get GoodsIn", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update GoodsIn
        /// Calls [usp_update_GoodsIn]
        /// </summary>
        public override bool Update(System.Int32? goodsInId, System.Int32? shipViaNo, System.String airWayBill, System.String reference, System.String receivingNotes, System.String supplierInvoice, System.DateTime? invoiceDate, System.Double? invoiceAmount, System.Double? bankFee, System.Int32? currencyNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_GoodsIn", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GoodsInId", SqlDbType.Int).Value = goodsInId;
                cmd.Parameters.Add("@ShipViaNo", SqlDbType.Int).Value = shipViaNo;
                cmd.Parameters.Add("@AirWayBill", SqlDbType.NVarChar).Value = airWayBill;
                cmd.Parameters.Add("@Reference", SqlDbType.NVarChar).Value = reference;
                cmd.Parameters.Add("@ReceivingNotes", SqlDbType.NVarChar).Value = receivingNotes;
                cmd.Parameters.Add("@SupplierInvoice", SqlDbType.NVarChar).Value = supplierInvoice;
                cmd.Parameters.Add("@InvoiceDate", SqlDbType.DateTime).Value = invoiceDate;
                cmd.Parameters.Add("@InvoiceAmount", SqlDbType.Float).Value = invoiceAmount;
                cmd.Parameters.Add("@BankFee", SqlDbType.Float).Value = bankFee;
                cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update GoodsIn", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        //[003] code start
        /// <summary>
        /// Update GoodsIn
        /// Calls [usp_update_GoodsIn_AccountingInfo]
        /// </summary>
        public override bool UpdateAccountingInfo(System.Int32? goodsInId, System.Int32? updatedBy, System.Int32? PurchaseCountryNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_GoodsIn_AccountingInfo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GoodsInId", SqlDbType.Int).Value = goodsInId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@PurchaseCountryNo", SqlDbType.Int).Value = PurchaseCountryNo;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update GoodsIn", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[003] code end

        /// <summary>
        /// Update GoodsIn
        /// Calls [usp_update_GoodsIn_MainInfo]
        /// </summary>
        public override bool UpdateMainInfo(System.Int32? goodsInId, System.Int32? shipViaNo, System.String airWayBill, System.String reference, System.String receivingNotes, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_GoodsIn_MainInfo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GoodsInId", SqlDbType.Int).Value = goodsInId;
                cmd.Parameters.Add("@ShipViaNo", SqlDbType.Int).Value = shipViaNo;
                cmd.Parameters.Add("@AirWayBill", SqlDbType.NVarChar).Value = airWayBill;
                cmd.Parameters.Add("@Reference", SqlDbType.NVarChar).Value = reference;
                cmd.Parameters.Add("@ReceivingNotes", SqlDbType.NVarChar).Value = receivingNotes;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update GoodsIn", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        // [002] code start
        /// <summary>
        /// GetPDFListForGoodsIn 
        /// Calls [usp_selectAll_PDF_for_GoodsIn]
        /// </summary>
        public override List<PDFDocumentDetails> GetPDFListForGoodsIn(System.Int32? GoodsInId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_PDF_for_GoodsIn", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@GoodsInNo", SqlDbType.Int).Value = GoodsInId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PDFDocumentDetails> lstPDF = new List<PDFDocumentDetails>();
                while (reader.Read())
                {
                    PDFDocumentDetails obj = new PDFDocumentDetails();
                    obj.PDFDocumentId = GetReaderValue_Int32(reader, "GoodsInPDFId", 0);
                    obj.PDFDocumentRefNo = GetReaderValue_Int32(reader, "GoodsInNo", 0);
                    obj.Caption = GetReaderValue_String(reader, "Caption", "");
                    obj.FileName = GetReaderValue_String(reader, "FileName", "");
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
                    lstPDF.Add(obj);
                    obj = null;
                }
                return lstPDF;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get PDF list for GoodsIn", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Create a new row
        /// Calls [usp_insert_GoodsInPDF]
        /// </summary>
        public override Int32 Insert(System.Int32? GoodsInId, System.String Caption, System.String FileName, System.Int32? UpdatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_GoodsInPDF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GoodsInNo", SqlDbType.Int).Value = GoodsInId;
                cmd.Parameters.Add("@Caption", SqlDbType.NVarChar).Value = Caption;
                cmd.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = FileName;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UpdatedBy;
                cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@NewId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert goodsIn pdf", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Delete goodsIn pdf
        /// Calls[usp_delete_GoodsInPDF]
        /// </summary>
        public override bool DeleteGoodsInPDF(System.Int32? GoodsInPdfId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_GoodsInPDF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GoodsInPDFId", SqlDbType.Int).Value = GoodsInPdfId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete goodsIn pdf", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        // [002] code end


    }
}
