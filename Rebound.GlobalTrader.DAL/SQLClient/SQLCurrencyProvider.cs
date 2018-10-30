// Marker     Changed by      Date         Remarks
// [001]      Vinay           16/05/2012   This need to add notes field

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
	public class SqlCurrencyProvider : CurrencyProvider {
		/// <summary>
		/// Delete Currency
		/// Calls [usp_delete_Currency]
		/// </summary>
		public override bool Delete(System.Int32? currencyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Currency", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CurrencyId", SqlDbType.Int).Value = currencyId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Currency", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete Currency
		/// Calls [usp_delete_Currency_by_GlobalCurrencyNo]
		/// </summary>
		public override bool DeleteByGlobalCurrencyNo(System.Int32? globalCurrencyNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Currency_by_GlobalCurrencyNo", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@GlobalCurrencyNo", SqlDbType.Int).Value = globalCurrencyNo;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Currency", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDownBuyForClient 
		/// Calls [usp_dropdown_Currency_Buy_For_Client]
        /// </summary>
		public override List<CurrencyDetails> DropDownBuyForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_Currency_Buy_For_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CurrencyDetails> lst = new List<CurrencyDetails>();
				while (reader.Read()) {
					CurrencyDetails obj = new CurrencyDetails();
					obj.CurrencyId = GetReaderValue_Int32(reader, "CurrencyId", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Currencys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// DropDownBuyForClientAndGlobal 
        /// Calls [usp_dropdown_Currency_Buy_For_Client_And_GlobalCurrencyNo]
        /// </summary>
        public override List<CurrencyDetails> DropDownBuyForClientAndGlobal(System.Int32? clientId, System.Int32? globalCurrencyNo, System.Boolean? blnBuy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand(blnBuy.Value ? "usp_dropdown_Currency_Buy_For_Client_And_GlobalCurrencyNo" : "usp_dropdown_Currency_Sell_For_Client_And_GlobalCurrencyNo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@GlobalCurrencyNo", SqlDbType.Int).Value = globalCurrencyNo??0;
                cmd.Parameters.Add("@Buy", SqlDbType.Bit).Value = blnBuy;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CurrencyDetails> lst = new List<CurrencyDetails>();
                while (reader.Read())
                {
                    CurrencyDetails obj = new CurrencyDetails();
                    obj.CurrencyId = GetReaderValue_Int32(reader, "CurrencyId", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Currencys", sqlex);
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
		/// Calls [usp_dropdown_Currency_for_Client]
        /// </summary>
		public override List<CurrencyDetails> DropDownForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_Currency_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CurrencyDetails> lst = new List<CurrencyDetails>();
				while (reader.Read()) {
					CurrencyDetails obj = new CurrencyDetails();
					obj.CurrencyId = GetReaderValue_Int32(reader, "CurrencyId", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Currencys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDownSellForClient 
		/// Calls [usp_dropdown_Currency_Sell_For_Client]
        /// </summary>
		public override List<CurrencyDetails> DropDownSellForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_Currency_Sell_For_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CurrencyDetails> lst = new List<CurrencyDetails>();
				while (reader.Read()) {
					CurrencyDetails obj = new CurrencyDetails();
					obj.CurrencyId = GetReaderValue_Int32(reader, "CurrencyId", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Currencys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_Currency]
		/// </summary>
        public override Int32 Insert(System.Int32? globalCurrencyNo, System.String currencyCode, System.String currencyDescription, System.String symbol, System.Int32? clientNo, System.Boolean? buy, System.Boolean? sell, System.Boolean? inactive, System.Int32? updatedBy, System.String notes)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Currency", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@GlobalCurrencyNo", SqlDbType.Int).Value = globalCurrencyNo;
				cmd.Parameters.Add("@CurrencyCode", SqlDbType.NVarChar).Value = currencyCode;
				cmd.Parameters.Add("@CurrencyDescription", SqlDbType.NVarChar).Value = currencyDescription;
				cmd.Parameters.Add("@Symbol", SqlDbType.NVarChar).Value = symbol;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Buy", SqlDbType.Bit).Value = buy;
				cmd.Parameters.Add("@Sell", SqlDbType.Bit).Value = sell;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //[001] code start
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                //[001] code end
				cmd.Parameters.Add("@CurrencyId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@CurrencyId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Currency", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_Currency]
        /// </summary>
		public override CurrencyDetails Get(System.Int32? currencyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Currency", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CurrencyId", SqlDbType.Int).Value = currencyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCurrencyFromReader(reader);
					CurrencyDetails obj = new CurrencyDetails();
					obj.CurrencyId = GetReaderValue_Int32(reader, "CurrencyId", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.Symbol = GetReaderValue_String(reader, "Symbol", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Buy = GetReaderValue_Boolean(reader, "Buy", false);
					obj.Sell = GetReaderValue_Boolean(reader, "Sell", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    //[001] code start
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    //[001] code end
                    obj.GlobalCurrencyNo = GetReaderValue_Int32(reader, "GlobalCurrencyNo", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Currency", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetConvertedValueBetweenTwoCurrencies 
		/// Calls [usp_select_Currency_ConvertedValueBetweenTwoCurrencies]
        /// </summary>
		public override CurrencyDetails GetConvertedValueBetweenTwoCurrencies(System.Double? valueToBeConverted, System.Int32? currencyFromId, System.Int32? currencyToId, System.DateTime? exchangeRateDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Currency_ConvertedValueBetweenTwoCurrencies", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ValueToBeConverted", SqlDbType.Float).Value = valueToBeConverted;
				cmd.Parameters.Add("@CurrencyFromId", SqlDbType.Int).Value = currencyFromId;
				cmd.Parameters.Add("@CurrencyToId", SqlDbType.Int).Value = currencyToId;
				cmd.Parameters.Add("@ExchangeRateDate", SqlDbType.DateTime).Value = exchangeRateDate;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCurrencyFromReader(reader);
					CurrencyDetails obj = new CurrencyDetails();
					obj.ConvertedValue = GetReaderValue_NullableDouble(reader, "ConvertedValue", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Currency", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForClient 
		/// Calls [usp_selectAll_Currency_for_Client]
        /// </summary>
		public override List<CurrencyDetails> GetListForClient(System.Int32? clientId, System.Boolean? includeInactive) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Currency_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@IncludeInactive", SqlDbType.Bit).Value = includeInactive;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CurrencyDetails> lst = new List<CurrencyDetails>();
				while (reader.Read()) {
					CurrencyDetails obj = new CurrencyDetails();
					obj.CurrencyId = GetReaderValue_Int32(reader, "CurrencyId", 0);
					obj.GlobalCurrencyNo = GetReaderValue_Int32(reader, "GlobalCurrencyNo", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.Symbol = GetReaderValue_String(reader, "Symbol", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Buy = GetReaderValue_Boolean(reader, "Buy", false);
					obj.Sell = GetReaderValue_Boolean(reader, "Sell", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ClientDefaultCurrencyCode = GetReaderValue_String(reader, "ClientDefaultCurrencyCode", "");
					obj.ClientDefaultCurrencyNo = GetReaderValue_Int32(reader, "ClientDefaultCurrencyNo", 0);
                    //[001] code start
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    //[001] code end
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Currencys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Currency
		/// Calls [usp_update_Currency]
        /// </summary>
        public override bool Update(System.Int32? currencyId, System.String currencyCode, System.String currencyDescription, System.String symbol, System.Int32? clientNo, System.Boolean? buy, System.Boolean? sell, System.Boolean? inactive, System.Int32? updatedBy, System.String notes)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Currency", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CurrencyId", SqlDbType.Int).Value = currencyId;
				cmd.Parameters.Add("@CurrencyCode", SqlDbType.NVarChar).Value = currencyCode;
				cmd.Parameters.Add("@CurrencyDescription", SqlDbType.NVarChar).Value = currencyDescription;
				cmd.Parameters.Add("@Symbol", SqlDbType.NVarChar).Value = symbol;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Buy", SqlDbType.Bit).Value = buy;
				cmd.Parameters.Add("@Sell", SqlDbType.Bit).Value = sell;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //[001] code start
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                //[001] code end
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Currency", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// GetListForClient 
        /// Calls [usp_selectAll_localCurrency_for_Client]
        /// </summary>
        public override List<CurrencyDetails> GetLocalListForClient(System.Int32? clientId, out string clientLocalCurrencyDescription, out System.Int32? clientLocalCurrencyNo)
        {
            clientLocalCurrencyDescription = string.Empty;
            clientLocalCurrencyNo = null;

            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_localCurrency_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<CurrencyDetails> lst = new List<CurrencyDetails>();
                while (reader.Read())
                {
                    CurrencyDetails obj = new CurrencyDetails();
                    obj.LocalCurrencyId = GetReaderValue_Int32(reader, "LocalCurrencyId", 0);
                    obj.LocalExchangeRate = GetReaderValue_NullableDouble(reader, "ExchangeRate", null);
                    obj.CurrencyId = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.Symbol = GetReaderValue_String(reader, "Symbol", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);                    
                    lst.Add(obj);
                    obj = null;
                }
                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        clientLocalCurrencyDescription = GetReaderValue_String(reader, "ClientLocalCurrencyDescription", "");
                        clientLocalCurrencyNo = GetReaderValue_Int32(reader, "ClientLocalCurrencyNo", 0);
                    }
                }
             
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Local Currencys", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// [usp_insert_LocalCurrency]
        /// </summary>
        /// <param name="currencyNo"></param>
        /// <param name="exchangeRate"></param>
        /// <param name="apply"></param>
        /// <param name="clientNo"></param>
        /// <returns></returns>
        public override Int32 InsertLocalCurrency(System.Int32 globalCurrencyNo, System.Double? exchangeRate, System.Boolean Inactive, System.Int32 clientNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_LocalCurrency", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GlobalCurrencyNo", SqlDbType.Int).Value = globalCurrencyNo;
                cmd.Parameters.Add("@ExchangeRate", SqlDbType.Decimal).Value = exchangeRate;
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = Inactive;
                cmd.Parameters.Add("@ClientNo", SqlDbType.NVarChar).Value = clientNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@LocalCurrencyId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@LocalCurrencyId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert LocalCurrency", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        public override bool UpdateLocalCurrency(System.Int32 localCurrencyId, System.Double? exchangeRate, System.Boolean Inactive, System.Int32 clientNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_LocalCurrency", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LocalCurrencyId", SqlDbType.Int).Value = localCurrencyId;
                cmd.Parameters.Add("@ExchangeRate", SqlDbType.Decimal).Value = exchangeRate;
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = Inactive;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update LocalCurrency", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// DropDownLinkMultiCurrency
        /// Calls [usp_dropdown_LinkMultiCurrency]
        /// </summary>
        public override List<CurrencyDetails> DropDownLinkMultiCurrency(System.Int32? hubClientNo, System.Int32? customerClientNo, System.Int32? buyCurrencyNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdown_LinkMultiCurrency", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@HubClientNo", SqlDbType.Int).Value = hubClientNo;
                cmd.Parameters.Add("@CustomerClientNo", SqlDbType.Int).Value = customerClientNo;
                cmd.Parameters.Add("@BuyCurrencyNo", SqlDbType.Int).Value = buyCurrencyNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CurrencyDetails> lst = new List<CurrencyDetails>();
                while (reader.Read())
                {
                    CurrencyDetails obj = new CurrencyDetails();
                    obj.CurrencyId = GetReaderValue_Int32(reader, "CurrencyId", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.LinkMultiCurrencyId = GetReaderValue_Int32(reader, "LinkMultiCurrencyId", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Currencys", sqlex);
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