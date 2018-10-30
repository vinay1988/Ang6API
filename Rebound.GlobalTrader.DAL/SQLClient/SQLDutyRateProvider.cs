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

namespace Rebound.GlobalTrader.DAL.SqlClient {
	public class SqlDutyRateProvider : DutyRateProvider {
		/// <summary>
		/// Delete DutyRate
		/// Calls [usp_delete_DutyRate]
		/// </summary>
		public override bool Delete(System.Int32? dutyRateId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_DutyRate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@DutyRateId", SqlDbType.Int).Value = dutyRateId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete DutyRate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_DutyRate]
		/// </summary>
		public override Int32 Insert(System.DateTime? dutyDate, System.Double? dutyRateValue, System.Int32? productNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_DutyRate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@DutyDate", SqlDbType.DateTime).Value = dutyDate;
				cmd.Parameters.Add("@DutyRateValue", SqlDbType.Float).Value = dutyRateValue;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@DutyRateId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@DutyRateId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert DutyRate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
        /// <summary>
        /// Create a new row
        /// Calls [usp_insert_GlobalDutyRate]
        /// </summary>
        public override Int32 GlobalInsert(System.DateTime? dutyDate, System.Double? dutyRateValue, System.Int32? productNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_GlobalDutyRate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DutyDate", SqlDbType.DateTime).Value = dutyDate;
                cmd.Parameters.Add("@DutyRateValue", SqlDbType.Float).Value = dutyRateValue;
                cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@DutyRateId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@DutyRateId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Global DutyRate", sqlex);
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
		/// Calls [usp_select_DutyRate]
        /// </summary>
		public override DutyRateDetails Get(System.Int32? dutyRateId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_DutyRate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@DutyRateId", SqlDbType.Int).Value = dutyRateId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetDutyRateFromReader(reader);
					DutyRateDetails obj = new DutyRateDetails();
					obj.DutyRateId = GetReaderValue_Int32(reader, "DutyRateId", 0);
					obj.DutyDate = GetReaderValue_NullableDateTime(reader, "DutyDate", null);
					obj.DutyRateValue = GetReaderValue_NullableDouble(reader, "DutyRateValue", null);
					obj.ProductNo = GetReaderValue_Int32(reader, "ProductNo", 0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get DutyRate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetCurrentForProduct 
		/// Calls [usp_select_DutyRate_Current_for_Product]
        /// </summary>
		public override DutyRateDetails GetCurrentForProduct(System.Int32? productNo, System.DateTime? datePoint) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_DutyRate_Current_for_Product", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@DatePoint", SqlDbType.DateTime).Value = datePoint;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetDutyRateFromReader(reader);
					DutyRateDetails obj = new DutyRateDetails();
					obj.DutyRateValue = GetReaderValue_NullableDouble(reader, "DutyRateValue", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get DutyRate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForProduct 
		/// Calls [usp_selectAll_DutyRate_for_Product]
        /// </summary>
		public override List<DutyRateDetails> GetListForProduct(System.Int32? productId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_DutyRate_for_Product", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<DutyRateDetails> lst = new List<DutyRateDetails>();
				while (reader.Read()) {
					DutyRateDetails obj = new DutyRateDetails();
					obj.DutyRateId = GetReaderValue_Int32(reader, "DutyRateId", 0);
					obj.DutyDate = GetReaderValue_NullableDateTime(reader, "DutyDate", null);
					obj.DutyRateValue = GetReaderValue_NullableDouble(reader, "DutyRateValue", null);
					obj.ProductNo = GetReaderValue_Int32(reader, "ProductNo", 0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get DutyRates", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// GetListForGlobalProduct 
        /// Calls [usp_selectAll_DutyRate_for_GlobalProduct]
        /// </summary>
        public override List<DutyRateDetails> GetListForGlobalProduct(System.Int32? productId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_DutyRate_for_GlobalProduct", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@GlobalProductId", SqlDbType.Int).Value = productId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<DutyRateDetails> lst = new List<DutyRateDetails>();
                while (reader.Read())
                {
                    DutyRateDetails obj = new DutyRateDetails();
                    obj.DutyRateId = GetReaderValue_Int32(reader, "GlobalDutyRateId", 0);
                    obj.DutyDate = GetReaderValue_NullableDateTime(reader, "DutyDate", null);
                    obj.DutyRateValue = GetReaderValue_NullableDouble(reader, "DutyRateValue", null);
                    obj.ProductNo = GetReaderValue_Int32(reader, "ProductNo", 0);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get DutyRates", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		
		
        /// <summary>
        /// Update DutyRate
		/// Calls [usp_update_DutyRate]
        /// </summary>
		public override bool Update(System.Int32? dutyRateId, System.DateTime? dutyDate, System.Double? dutyRateValue, System.Int32? productNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_DutyRate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@DutyRateId", SqlDbType.Int).Value = dutyRateId;
				cmd.Parameters.Add("@DutyDate", SqlDbType.DateTime).Value = dutyDate;
				cmd.Parameters.Add("@DutyRateValue", SqlDbType.Float).Value = dutyRateValue;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update DutyRate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}