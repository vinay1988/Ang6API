// Marker     Changed by      Date         Remarks
// [001]      Vinay           12/11/2014   Display history (log) of exchange rate change in the local currency
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
	public class SqlCurrencyRateProvider : CurrencyRateProvider {
		/// <summary>
		/// Delete CurrencyRate
		/// Calls [usp_delete_CurrencyRate]
		/// </summary>
		public override bool Delete(System.Int32? currencyRateId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_CurrencyRate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CurrencyRateId", SqlDbType.Int).Value = currencyRateId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete CurrencyRate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_CurrencyRate]
		/// </summary>
		public override Int32 Insert(System.Int32? currencyNo, System.DateTime? currencyDate, System.Double? exchangeRate, System.Boolean? repriceOpenOrders, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_CurrencyRate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@CurrencyDate", SqlDbType.DateTime).Value = currencyDate;
				cmd.Parameters.Add("@ExchangeRate", SqlDbType.Float).Value = exchangeRate;
				cmd.Parameters.Add("@RepriceOpenOrders", SqlDbType.Bit).Value = repriceOpenOrders;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@CurrencyRateId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@CurrencyRateId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert CurrencyRate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_CurrencyRate]
        /// </summary>
		public override CurrencyRateDetails Get(System.Int32? currencyRateId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_CurrencyRate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CurrencyRateId", SqlDbType.Int).Value = currencyRateId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCurrencyRateFromReader(reader);
					CurrencyRateDetails obj = new CurrencyRateDetails();
					obj.CurrencyRateId = GetReaderValue_Int32(reader, "CurrencyRateId", 0);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDate = GetReaderValue_DateTime(reader, "CurrencyDate", DateTime.MinValue);
					obj.ExchangeRate = GetReaderValue_Double(reader, "ExchangeRate", 0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.RepriceOpenOrders = GetReaderValue_NullableBoolean(reader, "RepriceOpenOrders", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CurrencyRate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetCurrentAtDate 
		/// Calls [usp_select_CurrencyRate_Current_at_Date]
        /// </summary>
		public override CurrencyRateDetails GetCurrentAtDate(System.Int32? currencyNo, System.DateTime? datePoint) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_CurrencyRate_Current_at_Date", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@DatePoint", SqlDbType.DateTime).Value = datePoint;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCurrencyRateFromReader(reader);
					CurrencyRateDetails obj = new CurrencyRateDetails();
					obj.ExchangeRate = GetReaderValue_Double(reader, "ExchangeRate", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CurrencyRate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForCurrency 
		/// Calls [usp_selectAll_CurrencyRate_for_Currency]
        /// </summary>
		public override List<CurrencyRateDetails> GetListForCurrency(System.Int32? currencyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_CurrencyRate_for_Currency", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CurrencyId", SqlDbType.Int).Value = currencyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CurrencyRateDetails> lst = new List<CurrencyRateDetails>();
				while (reader.Read()) {
					CurrencyRateDetails obj = new CurrencyRateDetails();
					obj.CurrencyRateId = GetReaderValue_Int32(reader, "CurrencyRateId", 0);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDate = GetReaderValue_DateTime(reader, "CurrencyDate", DateTime.MinValue);
					obj.ExchangeRate = GetReaderValue_Double(reader, "ExchangeRate", 0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.RepriceOpenOrders = GetReaderValue_NullableBoolean(reader, "RepriceOpenOrders", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CurrencyRates", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update CurrencyRate
		/// Calls [usp_update_CurrencyRate]
        /// </summary>
		public override bool Update(System.Int32? currencyRateId, System.Int32? currencyNo, System.DateTime? currencyDate, System.Double? exchangeRate, System.Boolean? repriceOpenOrders, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_CurrencyRate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CurrencyRateId", SqlDbType.Int).Value = currencyRateId;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@CurrencyDate", SqlDbType.DateTime).Value = currencyDate;
				cmd.Parameters.Add("@ExchangeRate", SqlDbType.Float).Value = exchangeRate;
				cmd.Parameters.Add("@RepriceOpenOrders", SqlDbType.Bit).Value = repriceOpenOrders;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update CurrencyRate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        //[001] code start
        /// <summary>
        /// GetListForCurrency 
        /// Calls [usp_selectAll_ExchangeRate_for_LocalCurrency]
        /// </summary>
        public override List<CurrencyRateDetails> GetListForExchangeRate(System.Int32? localCurrencyId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_ExchangeRate_for_LocalCurrency", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LocalCurrencyId", SqlDbType.Int).Value = localCurrencyId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CurrencyRateDetails> lst = new List<CurrencyRateDetails>();
                while (reader.Read())
                {
                    CurrencyRateDetails obj = new CurrencyRateDetails();
                    obj.ExchangeRateId = GetReaderValue_Int32(reader, "ExchangeRateId", 0);
                    obj.LocalCurrencyNo = GetReaderValue_Int32(reader, "LocalCurrencyNo", 0);
                    obj.ExchangeRateDate = GetReaderValue_DateTime(reader, "ExchangeRateDate", DateTime.MinValue);
                    obj.ExchangeRate = GetReaderValue_Double(reader, "ExchangeRate", 0);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.CurrencyCode = GetReaderValue_String(reader, "GlobalCurrencyName", "");
                    obj.ChangeBy = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.ClientCurrencyCode = GetReaderValue_String(reader, "ClientLocalCurrencyCode", "");

                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Exchange rates", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[001] code start
	}
}