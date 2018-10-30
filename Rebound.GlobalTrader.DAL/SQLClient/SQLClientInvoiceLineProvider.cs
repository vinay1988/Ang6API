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
    public class SqlClientInvoiceLineProvider : ClientInvoiceLineProvider
    {
        /// <summary>
        /// usp_selectAll_ClientInvoiceLine_for_ClientInvoice
        /// </summary>
        /// <param name="ClientInvoiceId"></param>
        /// <returns></returns>
        public override List<ClientInvoiceLineDetails> GetListForClientInvoiceLine(System.Int32? ClientInvoiceId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_ClientInvoiceLine_for_ClientInvoice", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientInvoiceId", SqlDbType.Int).Value = ClientInvoiceId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<ClientInvoiceLineDetails> lst = new List<ClientInvoiceLineDetails>();
                while (reader.Read())
                {
                    ClientInvoiceLineDetails obj = new ClientInvoiceLineDetails();
                    obj.ClientInvoiceLineId = GetReaderValue_Int32(reader, "ClientInvoiceLineId", 0);
                    obj.ClientInvoiceNo = GetReaderValue_Int32(reader, "ClientInvoiceNo", 0);
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
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.CountryOfManufacture = GetReaderValue_String(reader, "CountryOfManufacture", "");
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
                    obj.InternalPurchaseOrderNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNo", null);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNumber", null);
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.POSerialNo = GetReaderValue_Int16(reader, "POSerialNo", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Client Invoice Line", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Get goods in line of the Client
        /// Calls Proc [usp_itemsearch_ClientInvoice_GoodsInLine]
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
        public override List<ClientInvoiceLineDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Int32 companyNo, System.Boolean? includeInvoiced, System.DateTime? giLineDateFrom, System.DateTime? giLineDateTo, System.Int32? goodsInNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_itemsearch_ClientInvoice_GoodsInLine", cn);
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
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<ClientInvoiceLineDetails> lst = new List<ClientInvoiceLineDetails>();
                while (reader.Read())
                {
                    ClientInvoiceLineDetails obj = new ClientInvoiceLineDetails();
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
                throw new Exception("Failed to get Client Invoice Lines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Insert Client invoice line
        /// Call Proc [usp_insert_ClientInvoiceLine]
        /// </summary>
        /// <param name="goodsInLineId"></param>
        /// <param name="ClientInvoiceNo"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public override Int32 InsertClientInvoiceLine(System.Int32 goodsInLineId, System.Int32 clientInvoiceNo, System.Int32 updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_ClientInvoiceLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GoodsInLineNo", SqlDbType.Int).Value = goodsInLineId;
                cmd.Parameters.Add("@ClientInvoiceNo", SqlDbType.Int).Value = clientInvoiceNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@ClientInvoiceLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@ClientInvoiceLineId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Client Invoice Line", sqlex);
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
        /// Call Proc [usp_delete_ClientInvoiceLine]
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
                cmd = new SqlCommand("usp_delete_ClientInvoiceLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientInvoiceLineId", SqlDbType.Int).Value = supplierInvoiceLineId;
              //  cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete Client Invoice Line", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        ///  
        /// Calls [usp_getClientInvoice]
        /// </summary>
        public override List<ClientInvoiceLineDetails> GetClientInvoice(System.Int32? InvoiceId,System.Int32? clientInvoiceLineNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_getClientInvoice", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientInvoiceNo", SqlDbType.Int).Value = InvoiceId;
                cmd.Parameters.Add("@ClientInvoiceLineNo", SqlDbType.Int).Value = clientInvoiceLineNo;

                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<ClientInvoiceLineDetails> lst = new List<ClientInvoiceLineDetails>();
                while (reader.Read())
                {
                    ClientInvoiceLineDetails obj = new ClientInvoiceLineDetails();
                    obj.ClientInvoiceLineId = GetReaderValue_Int32(reader, "ClientInvoiceLineId", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.QtyReceived = GetReaderValue_NullableInt32(reader, "Quantity", null);
                    obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
                    obj.ClientInvoiceNo = GetReaderValue_Int32(reader, "ClientInvoiceNo", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.DateReceived = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
                    obj.GoodsInNo = GetReaderValue_Int32(reader, "GoodsInNo", 0);
                    obj.ClientInvoiceNumber = GetReaderValue_Int32(reader, "ClientInvoiceNumber", 0);
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
                    obj.DebitNumber = GetReaderValue_Int32(reader, "DebitNumber", 0);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0);
                   

                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get InvoiceLines", sqlex);
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
        /// Calls [usp_select_ClientInvoiceLine]
        /// </summary>
        public override ClientInvoiceLineDetails Get(System.Int32? clientInvoiceLineId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_ClientInvoiceLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientInvoiceLineId", SqlDbType.Int).Value = clientInvoiceLineId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    ClientInvoiceLineDetails obj = new ClientInvoiceLineDetails();
                    obj.ClientInvoiceLineId = GetReaderValue_Int32(reader, "ClientInvoiceLineId", 0);
                    obj.ClientInvoiceNo = GetReaderValue_Int32(reader, "ClientInvoiceNo", 0);
                    obj.GoodsInNo = GetReaderValue_Int32(reader, "GoodsInNo", 0);
                    obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.QtyReceived = GetReaderValue_NullableInt32(reader, "QtyReceived", null);
                    obj.DateReceived = GetReaderValue_DateTime(reader, "ClientInvoiceDate", DateTime.MinValue);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.Landedcost = GetReaderValue_NullableDouble(reader, "Landedcost", null);
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
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
                throw new Exception("Failed to get ClientInvoiceLine", sqlex);
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
