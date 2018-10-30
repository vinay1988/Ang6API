//Marker     changed by      date         Remarks
//[001]      Vinay           28/11/2012   Apply a bank fee charge to the customers final invoice
//[002]      Vinay           11/08/2016   Apply a PO bank fee charge
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
	public class SqlTermsProvider : TermsProvider {
		/// <summary>
		/// Delete Terms
		/// Calls [usp_delete_Terms]
		/// </summary>
		public override bool Delete(System.Int32? termsId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Terms", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@TermsId", SqlDbType.Int).Value = termsId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Terms", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDownBuyForClient 
		/// Calls [usp_dropdown_Terms_Buy_for_Client]
        /// </summary>
		public override List<TermsDetails> DropDownBuyForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_Terms_Buy_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<TermsDetails> lst = new List<TermsDetails>();
				while (reader.Read()) {
					TermsDetails obj = new TermsDetails();
					obj.TermsId = GetReaderValue_Int32(reader, "TermsId", 0);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Termss", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDownForClient 
		/// Calls [usp_dropdown_Terms_for_Client]
        /// </summary>
		public override List<TermsDetails> DropDownForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_Terms_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<TermsDetails> lst = new List<TermsDetails>();
				while (reader.Read()) {
					TermsDetails obj = new TermsDetails();
					obj.TermsId = GetReaderValue_Int32(reader, "TermsId", 0);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Termss", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDownSellForClient 
		/// Calls [usp_dropdown_Terms_Sell_for_Client]
        /// </summary>
		public override List<TermsDetails> DropDownSellForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_Terms_Sell_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<TermsDetails> lst = new List<TermsDetails>();
				while (reader.Read()) {
					TermsDetails obj = new TermsDetails();
					obj.TermsId = GetReaderValue_Int32(reader, "TermsId", 0);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Termss", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		//[001] code start
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_Terms]
		/// </summary>
        public override Int32 Insert(System.Int32? clientNo, System.Int32? days, System.String termsName, System.Boolean? buy, System.Boolean? sell, System.Boolean? inAdvance, System.Int32? updatedBy, System.Boolean? isApplyBankFee, System.Double? bankFee, System.Boolean? isApplyPOBankFee, System.Double? poBankFee)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Terms", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Days", SqlDbType.Int).Value = days;
				cmd.Parameters.Add("@TermsName", SqlDbType.NVarChar).Value = termsName;
				cmd.Parameters.Add("@Buy", SqlDbType.Bit).Value = buy;
				cmd.Parameters.Add("@Sell", SqlDbType.Bit).Value = sell;
				cmd.Parameters.Add("@InAdvance", SqlDbType.Bit).Value = inAdvance;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@IsApplyBankFee", SqlDbType.Bit).Value = isApplyBankFee;
                cmd.Parameters.Add("@BankFee",SqlDbType.Decimal).Value=bankFee;
                //[002] code start
                cmd.Parameters.Add("@IsApplyPOBankFee", SqlDbType.Bit).Value = isApplyPOBankFee;
                cmd.Parameters.Add("@POBankFee", SqlDbType.Decimal).Value = poBankFee;
                //[002] code end
				cmd.Parameters.Add("@TermsId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@TermsId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Terms", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		//[001] code end
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_Terms]
        /// </summary>
		public override TermsDetails Get(System.Int32? termsId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Terms", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@TermsId", SqlDbType.Int).Value = termsId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetTermsFromReader(reader);
					TermsDetails obj = new TermsDetails();
					obj.TermsId = GetReaderValue_Int32(reader, "TermsId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Days = GetReaderValue_Int32(reader, "Days", 0);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.Buy = GetReaderValue_Boolean(reader, "Buy", false);
					obj.Sell = GetReaderValue_Boolean(reader, "Sell", false);
					obj.InAdvance = GetReaderValue_Boolean(reader, "InAdvance", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Terms", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForClient 
		/// Calls [usp_selectAll_Terms_for_Client]
        /// </summary>
		public override List<TermsDetails> GetListForClient(System.Int32? clientId, System.Int32? pageIndex, System.Int32? pageSize) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Terms_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<TermsDetails> lst = new List<TermsDetails>();
				while (reader.Read()) {
					TermsDetails obj = new TermsDetails();
					obj.TermsId = GetReaderValue_Int32(reader, "TermsId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Days = GetReaderValue_Int32(reader, "Days", 0);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.Buy = GetReaderValue_Boolean(reader, "Buy", false);
					obj.Sell = GetReaderValue_Boolean(reader, "Sell", false);
					obj.InAdvance = GetReaderValue_Boolean(reader, "InAdvance", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    //[001] code start
                    obj.IsApplyBankFee = GetReaderValue_Boolean(reader, "IsApplyBankFee", false);
                    obj.BankFee = GetReaderValue_NullableDouble(reader, "BankFee",null);
                    //[001] code end
                    //[002] code start
                    obj.IsApplyPOBankFee = GetReaderValue_Boolean(reader, "IsApplyPOBankFee", false);
                    obj.POBankFee = GetReaderValue_NullableDouble(reader, "POBankFee", null);
                    //[002] code end
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Terms", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		//[001] code start
        /// <summary>
        /// Update Terms
		/// Calls [usp_update_Terms]
        /// </summary>
        public override bool Update(System.Int32? termsId, System.Int32? clientNo, System.Int32? days, System.String termsName, System.Boolean? buy, System.Boolean? sell, System.Boolean? inAdvance, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? isApplyBankFee, System.Double? bankFee, System.Boolean? isApplyPOBankFee, System.Double? poBankFee)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Terms", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@TermsId", SqlDbType.Int).Value = termsId;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Days", SqlDbType.Int).Value = days;
				cmd.Parameters.Add("@TermsName", SqlDbType.NVarChar).Value = termsName;
				cmd.Parameters.Add("@Buy", SqlDbType.Bit).Value = buy;
				cmd.Parameters.Add("@Sell", SqlDbType.Bit).Value = sell;
				cmd.Parameters.Add("@InAdvance", SqlDbType.Bit).Value = inAdvance;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@IsApplyBankFee", SqlDbType.Bit).Value = isApplyBankFee;
                cmd.Parameters.Add("@BankFee", SqlDbType.Decimal).Value = bankFee;
                cmd.Parameters.Add("@IsApplyPOBankFee", SqlDbType.Bit).Value = isApplyPOBankFee;
                cmd.Parameters.Add("@POBankFee", SqlDbType.Decimal).Value = poBankFee;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Terms", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
        //[001] code end
		
		
		
		
	}
}