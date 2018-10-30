/*
Marker     changed by      date         Remarks
[001]      Vinay           09/01/2013   Add more icon for all nuggets
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
    public class SqlStockInfoProvider : StockInfoProvider
    {
        /// <summary>
        /// Create a new row
        /// Calls [usp_insert_StockInfo]
        /// </summary>
        public override Int32 Insert(System.String part, System.String supplierPart, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? supplierNo, System.String notes, System.String alternatePart, System.Int32? clientNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_StockInfo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
                cmd.Parameters.Add("@SupplierPart", SqlDbType.NVarChar).Value = supplierPart;
                cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
                cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
                cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
                cmd.Parameters.Add("@SupplierNo", SqlDbType.Int).Value = supplierNo;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@AlternatePart", SqlDbType.NVarChar).Value = alternatePart;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@StockInfoDataId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@StockInfoDataId"].Value;
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Failed to insert StockInfo", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Update StockInfo
        /// Calls [usp_update_StockInfo]
        /// </summary>
        public override bool Update(System.Int32? stockInfoId, System.String part, System.String supplierPart, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? supplierNo, System.String notes, System.String alternatePart, System.Int32? clientNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_StockInfo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StockInfoDataId", SqlDbType.Int).Value = stockInfoId;
                cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
                cmd.Parameters.Add("@SupplierPart", SqlDbType.NVarChar).Value = supplierPart;
                cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
                cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
                cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
                cmd.Parameters.Add("@SupplierNo", SqlDbType.Int).Value = supplierNo;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@AlternatePart", SqlDbType.NVarChar).Value = alternatePart;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update StockInfo", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// usp_ValidateAlternatePart
        /// </summary>
        /// <param name="alternatePart"></param>
        /// <returns></returns>
        public override bool ValidateAlternatePart(System.String alternatePart,System.Int32? stockInfoId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_ValidateAlternatePart", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@AlternatePart", SqlDbType.NVarChar).Value = alternatePart;
                if (stockInfoId.HasValue)
                    cmd.Parameters.Add("@StockInfoId", SqlDbType.Int).Value = stockInfoId;
                else
                    cmd.Parameters.Add("@StockInfoId", SqlDbType.Int).Value = DBNull.Value;
                cn.Open();
                int ret =(int)ExecuteScalar(cmd);
                return (!(ret > 0));
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update StockInfo", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Calls [usp_source_StockInfo] for localServer else call [usp_source_StockInfo_Without_ClientId]
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="partSearch"></param>
        /// <returns></returns>
        public override List<StockInfoDetails> Source(System.Int32? clientId, System.String partSearch, bool hasServerLocal)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                if (!hasServerLocal)
                {
                    cn = new SqlConnection(this.GTConnectionString);
                    cmd = new SqlCommand("usp_source_StockInfo_Without_ClientId", cn);
                }
                else
                {
                    cn = new SqlConnection(this.ConnectionString);
                    cmd = new SqlCommand("usp_source_StockInfo", cn);
                }
                                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<StockInfoDetails> lst = new List<StockInfoDetails>();
                while (reader.Read())
                {
                    StockInfoDetails obj = new StockInfoDetails();
                    obj.StockInfoId = GetReaderValue_Int32(reader, "StockInfoDataId", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.AlternatePart = GetReaderValue_String(reader, "AlternatePart", "");
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
                    obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.SupplierRMAId = GetReaderValue_Int32(reader, "SupplierRMAId", 0);
                    obj.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0);
                    obj.ClientCode = GetReaderValue_String(reader, "ClientCode", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get stocks info", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// usp_select_StockInfo
        /// </summary>
        /// <param name="stockInfoId"></param>
        /// <returns></returns>
        public override StockInfoDetails Get(System.Int32? stockInfoId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_StockInfo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@StockInfoDataId", SqlDbType.Int).Value = stockInfoId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    StockInfoDetails obj = new StockInfoDetails();
                    obj.StockInfoId = GetReaderValue_Int32(reader, "StockInfoDataId", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.AlternatePart = GetReaderValue_String(reader, "AlternatePart", "");
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
                    obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
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
                throw new Exception("Failed to get stock info", sqlex);
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
