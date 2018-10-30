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
    public class SqlSupplierInvoiceLineProvider : SupplierInvoiceLineProvider
    {
        /// <summary>
        /// usp_selectAll_SupplierInvoiceLine_for_SupplierInvoice
        /// </summary>
        /// <param name="SupplierInvoiceId"></param>
        /// <returns></returns>
        public override List<SupplierInvoiceLineDetails> GetListForSupplierInvoiceLine(System.Int32? supplierInvoiceId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SupplierInvoiceLine_for_SupplierInvoice", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SupplierInvoiceId", SqlDbType.Int).Value = supplierInvoiceId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SupplierInvoiceLineDetails> lst = new List<SupplierInvoiceLineDetails>();
                while (reader.Read())
                {
                    SupplierInvoiceLineDetails obj = new SupplierInvoiceLineDetails();
                    obj.SupplierInvoiceLineId = GetReaderValue_Int32(reader, "SupplierInvoiceLineId", 0);
                    obj.SupplierInvoiceNo = GetReaderValue_Int32(reader, "SupplierInvoiceNo", 0);
                    obj.GoodsInNo = GetReaderValue_Int32(reader, "GoodsInNo", 0);
                    obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.UnitPrice = GetReaderValue_NullableDouble(reader, "UnitPrice", null);
                    obj.QtyReceived = GetReaderValue_NullableInt32(reader, "QtyReceived", 0);
                    obj.Landedcost = GetReaderValue_NullableDouble(reader, "Landedcost", null);
                    obj.DateReceived = GetReaderValue_NullableDateTime(reader, "DateReceived", null);
                    obj.StockNo = GetReaderValue_NullableInt32(reader, "StockId", null);
                    obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.GoodsInLineNo = GetReaderValue_Int32(reader, "GoodsInLineNo", 0);

                    obj.PackageNo = GetReaderValue_String(reader, "PackageNo", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.CountryOfManufacture = GetReaderValue_String(reader, "CountryOfManufacture", "");
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.InternalPurchaseOrderId = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderId", null);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNumber", null);
                    obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
                    obj.BuyerName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.BuyerNo = GetReaderValue_Int32(reader, "Buyer", 0);

                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Supplier Invoice Line", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Get goods in line of the supplier
        /// Calls Proc [usp_itemsearch_SupplierInvoice_GoodsInLine]
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="orderBy"></param>
        /// <param name="sortDir"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="companyNo"></param>
        /// <param name="includeInvoiced"></param>
        /// <param name="giLineDateFrom"></param>
        /// <param name="giLineDateTo"></param>
        /// <returns></returns>
        public override List<SupplierInvoiceLineDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Int32 companyNo, System.Boolean? includeInvoiced, System.DateTime? giLineDateFrom, System.DateTime? giLineDateTo, System.Int32? goodsInNo, System.Boolean? IsPoHub, bool? isClientInvoice, System.Int32? poNoLo, System.Int32? poNoHi)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                 if(isClientInvoice==true)
                 {
                     cmd = new SqlCommand("usp_itemsearch_ClientInvoice_GoodsInLine", cn);
                 }else{
                      cmd = new SqlCommand("usp_itemsearch_SupplierInvoice_GoodsInLine", cn);
                 }
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
                cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
                cmd.Parameters.Add("@IncludeInvoiced", SqlDbType.Bit).Value = includeInvoiced;
                cmd.Parameters.Add("@GIDateFrom", SqlDbType.DateTime).Value = giLineDateFrom;
                cmd.Parameters.Add("@GIDateTo", SqlDbType.DateTime).Value = giLineDateTo;
                cmd.Parameters.Add("@GoodsInNo", SqlDbType.Int).Value = goodsInNo;
                cmd.Parameters.Add("@IsPOHub", SqlDbType.Bit).Value = IsPoHub;
                cmd.Parameters.Add("@PONoLo", SqlDbType.Int).Value = poNoLo;
                cmd.Parameters.Add("@PONoHi", SqlDbType.Int).Value = poNoHi;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SupplierInvoiceLineDetails> lst = new List<SupplierInvoiceLineDetails>();
                while (reader.Read())
                {
                    SupplierInvoiceLineDetails obj = new SupplierInvoiceLineDetails();
                    obj.GoodsInLineNo = GetReaderValue_Int32(reader, "GoodsInLineNo", 0);
                    obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.QtyReceived = GetReaderValue_NullableInt32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_NullableDouble(reader, "Price", 0);
                    obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", 0);
                    obj.NPRPrinted = GetReaderValue_NullableBoolean(reader, "NPRPrinted", false);
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue);
                    obj.GoodsInNo = GetReaderValue_Int32(reader, "GoodsInNo", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Supplier Invoice Lines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Insert supplier invoice line
        /// Call Proc [usp_insert_SupplierInvoiceLine]
        /// </summary>
        /// <param name="goodsInLineId"></param>
        /// <param name="supplierInvoiceNo"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public override Int32 InsertSupplierInvoiceLine(System.Int32 goodsInLineId, System.Int32 supplierInvoiceNo, System.Int32 updatedBy,bool? isPoHub)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_SupplierInvoiceLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GoodsInLineNo", SqlDbType.Int).Value = goodsInLineId;
                cmd.Parameters.Add("@SupplierInvoiceNo", SqlDbType.Int).Value = supplierInvoiceNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@IsHubInvoice", SqlDbType.Bit).Value = isPoHub??false;                
                cmd.Parameters.Add("@SupplierInvoiceLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@SupplierInvoiceLineId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Supplier Invoice Line", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Delete Supplier Invoice Line
        /// Call Proc [usp_delete_SupplierInvoiceLine]
        /// </summary>
        /// <param name="supplierInvoiceLineId"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public override bool Delete(System.Int32? supplierInvoiceLineId, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_SupplierInvoiceLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SupplierInvoiceLineId", SqlDbType.Int).Value = supplierInvoiceLineId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete Supplier Invoice Line", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
    }
}
