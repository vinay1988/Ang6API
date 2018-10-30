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
	public class SqlTaxRateProvider : TaxRateProvider {
		/// <summary>
		/// Delete TaxRate
		/// Calls [usp_delete_TaxRate]
		/// </summary>
		public override bool Delete(System.Int32? taxRateId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_TaxRate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@TaxRateId", SqlDbType.Int).Value = taxRateId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete TaxRate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_TaxRate]
		/// </summary>
		public override Int32 Insert(System.DateTime? taxDate, System.Int32? taxNo, System.Double? rate1, System.Double? rate2, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_TaxRate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@TaxDate", SqlDbType.DateTime).Value = taxDate;
				cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
				cmd.Parameters.Add("@Rate1", SqlDbType.Float).Value = rate1;
				cmd.Parameters.Add("@Rate2", SqlDbType.Float).Value = rate2;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@TaxRateId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@TaxRateId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert TaxRate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_TaxRate]
        /// </summary>
		public override TaxRateDetails Get(System.Int32? taxRateId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_TaxRate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@TaxRateId", SqlDbType.Int).Value = taxRateId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetTaxRateFromReader(reader);
					TaxRateDetails obj = new TaxRateDetails();
					obj.TaxRateId = GetReaderValue_Int32(reader, "TaxRateId", 0);
					obj.TaxDate = GetReaderValue_DateTime(reader, "TaxDate", DateTime.MinValue);
					obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
					obj.Rate1 = GetReaderValue_NullableDouble(reader, "Rate1", null);
					obj.Rate2 = GetReaderValue_NullableDouble(reader, "Rate2", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get TaxRate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get2ForTaxAndDate 
		/// Calls [usp_select_TaxRate_2_for_Tax_and_Date]
        /// </summary>
		public override TaxRateDetails Get2ForTaxAndDate(System.Int32? taxNo, System.Int32? clientNo, System.DateTime? taxPoint) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_TaxRate_2_for_Tax_and_Date", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@TaxPoint", SqlDbType.DateTime).Value = taxPoint;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetTaxRateFromReader(reader);
					TaxRateDetails obj = new TaxRateDetails();
					obj.CurrentTaxRate = GetReaderValue_NullableDouble(reader, "CurrentTaxRate", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get TaxRate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForTaxAndDate 
		/// Calls [usp_select_TaxRate_for_Tax_and_Date]
        /// </summary>
		public override TaxRateDetails GetForTaxAndDate(System.Int32? taxNo, System.Int32? clientNo, System.DateTime? taxPoint) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_TaxRate_for_Tax_and_Date", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@TaxPoint", SqlDbType.DateTime).Value = taxPoint;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetTaxRateFromReader(reader);
					TaxRateDetails obj = new TaxRateDetails();
					obj.CurrentTaxRate = GetReaderValue_NullableDouble(reader, "CurrentTaxRate", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get TaxRate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForTax 
		/// Calls [usp_selectAll_TaxRate_for_Tax]
        /// </summary>
		public override List<TaxRateDetails> GetListForTax(System.Int32? taxId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_TaxRate_for_Tax", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@TaxId", SqlDbType.Int).Value = taxId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<TaxRateDetails> lst = new List<TaxRateDetails>();
				while (reader.Read()) {
					TaxRateDetails obj = new TaxRateDetails();
					obj.TaxRateId = GetReaderValue_Int32(reader, "TaxRateId", 0);
					obj.TaxDate = GetReaderValue_DateTime(reader, "TaxDate", DateTime.MinValue);
					obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
					obj.Rate1 = GetReaderValue_NullableDouble(reader, "Rate1", null);
					obj.Rate2 = GetReaderValue_NullableDouble(reader, "Rate2", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get TaxRates", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update TaxRate
		/// Calls [usp_update_TaxRate]
        /// </summary>
		public override bool Update(System.Int32? taxRateId, System.DateTime? taxDate, System.Int32? taxNo, System.Double? rate1, System.Double? rate2, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_TaxRate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@TaxRateId", SqlDbType.Int).Value = taxRateId;
				cmd.Parameters.Add("@TaxDate", SqlDbType.DateTime).Value = taxDate;
				cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
				cmd.Parameters.Add("@Rate1", SqlDbType.Float).Value = rate1;
				cmd.Parameters.Add("@Rate2", SqlDbType.Float).Value = rate2;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update TaxRate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}