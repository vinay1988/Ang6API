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
    public class SqlWarehouseProvider : WarehouseProvider
    {
        /// <summary>
        /// Delete Warehouse
        /// Calls [usp_delete_Warehouse]
        /// </summary>
        public override bool Delete(System.Int32? warehouseId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_Warehouse", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@WarehouseId", SqlDbType.Int).Value = warehouseId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete Warehouse", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// DropDownForClient 
        /// Calls [usp_dropdown_Warehouse_for_Client]
        /// </summary>
        public override List<WarehouseDetails> DropDownForClient(System.Int32? clientId, System.Boolean? includeVirtual)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdown_Warehouse_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@IncludeVirtual", SqlDbType.Bit).Value = includeVirtual;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<WarehouseDetails> lst = new List<WarehouseDetails>();
                while (reader.Read())
                {
                    WarehouseDetails obj = new WarehouseDetails();
                    obj.WarehouseId = GetReaderValue_Int32(reader, "WarehouseId", 0);
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Warehouses", sqlex);
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
        /// Calls [usp_insert_Warehouse]
        /// </summary>
        public override Int32 Insert(System.Int32? clientNo, System.String warehouseName, System.Int32? addressNo, System.Boolean? virtualWarehouse, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_Warehouse", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = warehouseName;
                cmd.Parameters.Add("@AddressNo", SqlDbType.Int).Value = addressNo;
                cmd.Parameters.Add("@VirtualWarehouse", SqlDbType.Bit).Value = virtualWarehouse;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@WarehouseId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@WarehouseId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Warehouse", sqlex);
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
        /// Calls [usp_select_Warehouse]
        /// </summary>
        public override WarehouseDetails Get(System.Int32? warehouseId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Warehouse", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@WarehouseId", SqlDbType.Int).Value = warehouseId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetWarehouseFromReader(reader);
                    WarehouseDetails obj = new WarehouseDetails();
                    obj.WarehouseId = GetReaderValue_Int32(reader, "WarehouseId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.AddressNo = GetReaderValue_NullableInt32(reader, "AddressNo", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.VirtualWarehouse = GetReaderValue_Boolean(reader, "VirtualWarehouse", false);
                    obj.DefaultWarehouse = GetReaderValue_Boolean(reader, "DefaultWarehouse", false);
                    obj.AddressName = GetReaderValue_String(reader, "AddressName", "");
                    obj.Line1 = GetReaderValue_String(reader, "Line1", "");
                    obj.Line2 = GetReaderValue_String(reader, "Line2", "");
                    obj.Line3 = GetReaderValue_String(reader, "Line3", "");
                    obj.County = GetReaderValue_String(reader, "County", "");
                    obj.City = GetReaderValue_String(reader, "City", "");
                    obj.State = GetReaderValue_String(reader, "State", "");
                    obj.ZIP = GetReaderValue_String(reader, "ZIP", "");
                    obj.CountryName = GetReaderValue_String(reader, "CountryName", "");
                    obj.CountryNo = GetReaderValue_NullableInt32(reader, "CountryNo", null);
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
                throw new Exception("Failed to get Warehouse", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetDefault 
        /// Calls [usp_select_Warehouse_Default]
        /// </summary>
        public override WarehouseDetails GetDefault(System.Int32? clientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Warehouse_Default", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetWarehouseFromReader(reader);
                    WarehouseDetails obj = new WarehouseDetails();
                    obj.WarehouseId = GetReaderValue_Int32(reader, "WarehouseId", 0);
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
                throw new Exception("Failed to get Warehouse", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListForClient 
        /// Calls [usp_selectAll_Warehouse_for_Client]
        /// </summary>
        public override List<WarehouseDetails> GetListForClient(System.Int32? clientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_Warehouse_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<WarehouseDetails> lst = new List<WarehouseDetails>();
                while (reader.Read())
                {
                    WarehouseDetails obj = new WarehouseDetails();
                    obj.WarehouseId = GetReaderValue_Int32(reader, "WarehouseId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.AddressNo = GetReaderValue_NullableInt32(reader, "AddressNo", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.VirtualWarehouse = GetReaderValue_Boolean(reader, "VirtualWarehouse", false);
                    obj.DefaultWarehouse = GetReaderValue_Boolean(reader, "DefaultWarehouse", false);
                    obj.AddressName = GetReaderValue_String(reader, "AddressName", "");
                    obj.Line1 = GetReaderValue_String(reader, "Line1", "");
                    obj.Line2 = GetReaderValue_String(reader, "Line2", "");
                    obj.Line3 = GetReaderValue_String(reader, "Line3", "");
                    obj.County = GetReaderValue_String(reader, "County", "");
                    obj.City = GetReaderValue_String(reader, "City", "");
                    obj.State = GetReaderValue_String(reader, "State", "");
                    obj.ZIP = GetReaderValue_String(reader, "ZIP", "");
                    obj.CountryName = GetReaderValue_String(reader, "CountryName", "");
                    obj.CountryNo = GetReaderValue_NullableInt32(reader, "CountryNo", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Warehouses", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update Warehouse
        /// Calls [usp_update_Warehouse]
        /// </summary>
        public override bool Update(System.Int32? warehouseId, System.Int32? clientNo, System.String warehouseName, System.Int32? addressNo, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? virtualWarehouse)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Warehouse", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@WarehouseId", SqlDbType.Int).Value = warehouseId;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = warehouseName;
                cmd.Parameters.Add("@AddressNo", SqlDbType.Int).Value = addressNo;
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@VirtualWarehouse", SqlDbType.Bit).Value = virtualWarehouse;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Warehouse", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update Warehouse
        /// Calls [usp_update_Warehouse_ClearDefaults]
        /// </summary>
        public override bool UpdateClearDefaults(System.Int32? clientId, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Warehouse_ClearDefaults", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Warehouse", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update Warehouse
        /// Calls [usp_update_Warehouse_SetDefault]
        /// </summary>
        public override bool UpdateSetDefault(System.Int32? warehouseId, System.Int32? clientId, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Warehouse_SetDefault", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@WarehouseId", SqlDbType.Int).Value = warehouseId;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Warehouse", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Create IPO and PO 
        /// Calls [usp_insert_InternalPurchaseOrder] 
        /// </summary>
        public override int CreateIPOAndPurchaseOrder(int SalesOrderNo, string SoLineNumbers, int POHubSupplierNo, int ClientNo, int WarehouseNo, int SourceingResultAttachedBy, int? SourcingResultNo, double? EstimatedShippingCost, DateTime? DeliveryDate, double? ConvertedEstimatedShippingCost, System.Int32? ClientCurrencyNo, System.Int32? POBuyCurrencyNo, System.Int32 CurrencyNo, System.Int32? LinkMultiCurrencyNo, out int InternalPurchaseOrderNo, out int PurchaseOrderNo, out string SolIdS)
        {
            /*Here PurchaseOrderNo is PurchaseOrderId*/
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {

                SolIdS = "";
                InternalPurchaseOrderNo = default(int);

                PurchaseOrderNo = default(int);

                int Result = default(int);

                cn = new SqlConnection(this.ConnectionString);

                cmd = new SqlCommand("usp_insert_InternalPurchaseOrder", cn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@SalesOrderNo", SqlDbType.Int).Value = SalesOrderNo;

                cmd.Parameters.Add("@SalesOrderLines", SqlDbType.VarChar, 1000).Value = SoLineNumbers;

                cmd.Parameters.Add("@POHubSupplierNo", SqlDbType.Int).Value = POHubSupplierNo;

                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = ClientNo;

                cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = WarehouseNo;

               // cmd.Parameters.Add("@PurchaseQuoteLineNo", SqlDbType.Int).Value = POQuoteLineNo;

                cmd.Parameters.Add("@SourceingResultAttachedBy", SqlDbType.Int).Value = SourceingResultAttachedBy;

                cmd.Parameters.Add("@SourceingResultNo", SqlDbType.Int).Value = SourcingResultNo;

               // cmd.Parameters.Add("@EstimatedShippingCost", SqlDbType.Float).Value = EstimatedShippingCost;


               // cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = DeliveryDate;

               // cmd.Parameters.Add("@ConvertedEstimatedShippingCost", SqlDbType.Float).Value =ConvertedEstimatedShippingCost;

                cmd.Parameters.Add("@IPOClientCurrencyNo", SqlDbType.Int).Value = ClientCurrencyNo;
                cmd.Parameters.Add("@POBuyCurrencyNo", SqlDbType.Int).Value = POBuyCurrencyNo;

                cmd.Parameters.Add("@SrCurrencyNo", SqlDbType.Int).Value = CurrencyNo;
                cmd.Parameters.Add("@LinkMultiCurrencyNo", SqlDbType.Int).Value = LinkMultiCurrencyNo;


              
                cmd.Parameters.AddWithValue("@InternalPurchaseOrderNo", InternalPurchaseOrderNo);

                cmd.Parameters["@InternalPurchaseOrderNo"].SqlDbType = SqlDbType.Int;

                cmd.Parameters["@InternalPurchaseOrderNo"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@PurchaseOrderNo", PurchaseOrderNo);

                cmd.Parameters["@PurchaseOrderNo"].SqlDbType = SqlDbType.Int;

                cmd.Parameters["@PurchaseOrderNo"].Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@Result", 0);

                cmd.Parameters["@Result"].SqlDbType = SqlDbType.Int;

                cmd.Parameters["@Result"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@SOL", 1000);
                cmd.Parameters["@SOL"].SqlDbType=SqlDbType.VarChar;
                cmd.Parameters["@SOL"].Direction = ParameterDirection.Output;

                cn.Open();

                ExecuteNonQuery(cmd);

                Int32.TryParse(cmd.Parameters["@InternalPurchaseOrderNo"].Value.ToString(), out InternalPurchaseOrderNo);
                
                Int32.TryParse(cmd.Parameters["@PurchaseOrderNo"].Value.ToString(),out PurchaseOrderNo);
                
                Int32.TryParse(cmd.Parameters["@Result"].Value.ToString(), out Result);
                SolIdS = cmd.Parameters["@SOL"].Value.ToString();
                return Result;
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Failed to create IPO and PO from Sales Order", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// To Get Default Warehouse By ClientId
        /// Calls [usp_GetDefaultWarehouseByClientId]
        /// </summary>
        public override int GetDefaultWarehouseByClient(int ClientId)
        {
            SqlConnection cn = null;
            DbCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_GetDefaultWarehouseByClientId", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@WarehouseId", Convert.ToInt32(0));
                param.Direction = ParameterDirection.Output;

                SqlParameter client = new SqlParameter("@ClientId", ClientId);
                cmd.Parameters.Add(client);
                cmd.Parameters.Add(param);
                cn.Open();
                ExecuteScalar(cmd);
                return Convert.ToInt32(cmd.Parameters["@WarehouseId"].Value.ToString());

            }
            catch (SqlException sqlex)
            {
                throw new Exception("Failed to get default client warehouse", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// To check whether sourcing result exist for so line or not
        ///   /// Calls [usp_IsSoLineExistInSourcingResult]
        /// </summary>
        /// <param name="SoId"></param>
        /// <param name="SolineId"></param>
        /// <returns></returns>
        public override int IsSoLineExistInSourcingResult(int? SoId, int? SolineId)
        {
            SqlConnection cn = null;
            DbCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_IsSoLineExistInSourcingResult", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@SoId", SoId.HasValue ? SoId.Value : 0);

                SqlParameter client = new SqlParameter("@SoLineId", SolineId.HasValue ? SolineId.Value : 0);

                SqlParameter IsSourcingResultExist = new SqlParameter("@IsSourcingExist", 0);
                IsSourcingResultExist.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(client);
                cmd.Parameters.Add(param);
                cmd.Parameters.Add(IsSourcingResultExist);
                cn.Open();
                ExecuteScalar(cmd);
                int success = Convert.ToInt32(cmd.Parameters["@IsSourcingExist"].Value.ToString());                
                return success;

            }
            catch (SqlException sqlex)
            {
                throw new Exception("Failed to check whether sourcing result exist for so line or not", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// To check whether sourcing result exist for so line or not
        ///   /// Calls [usp_IsSoLineExistInSourcingResult]
        /// </summary>
        /// <param name="SoId"></param>
        /// <param name="SolineId"></param>
        /// <returns></returns>
        public override int IsIPOExist(int? SoId, int? SolineId)
        {
            SqlConnection cn = null;
            DbCommand cmd = null;

            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_IsIPOAlreadyCreated", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter client = new SqlParameter("@SoLineId", SolineId.HasValue ? SolineId.Value : 0);

                SqlParameter IsIPOExist = new SqlParameter("@IsIPOExist", 0);
                IsIPOExist.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(client);
                cmd.Parameters.Add(IsIPOExist);
                cn.Open();
                ExecuteScalar(cmd);

                int IsIPOAlreadyCreated = default(int);
                IsIPOAlreadyCreated = Convert.ToInt32(cmd.Parameters["@IsIPOExist"].Value.ToString());

                return IsIPOAlreadyCreated;

            }
            catch (SqlException sqlex)
            {
                throw new Exception("Failed to check whether the item exist in ipo line", sqlex);
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