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
	public class SqlAlternatePartProvider : AlternatePartProvider {
		/// <summary>
		/// Delete AlternatePart
		/// Calls [usp_delete_AlternatePart]
		/// </summary>
		public override bool Delete(System.Int32? alternatePartId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_AlternatePart", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@AlternatePartId", SqlDbType.Int).Value = alternatePartId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete AlternatePart", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_AlternatePart]
		/// </summary>
		public override Int32 Insert(System.Int32? partNo, System.String fullPart, System.String part, System.Boolean? rohsCompliant, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_AlternatePart", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@PartNo", SqlDbType.Int).Value = partNo;
				cmd.Parameters.Add("@FullPart", SqlDbType.NVarChar).Value = fullPart;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@ROHSCompliant", SqlDbType.Bit).Value = rohsCompliant;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@AlternatePartId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@AlternatePartId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert AlternatePart", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_AlternatePart]
        /// </summary>
		public override AlternatePartDetails Get(System.Int32? alternatePartId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_AlternatePart", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@AlternatePartId", SqlDbType.Int).Value = alternatePartId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetAlternatePartFromReader(reader);
					AlternatePartDetails obj = new AlternatePartDetails();
					obj.AlternatePartId = GetReaderValue_Int32(reader, "AlternatePartId", 0);
					obj.PartNo = GetReaderValue_Int32(reader, "PartNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ROHSCompliant = GetReaderValue_Boolean(reader, "ROHSCompliant", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get AlternatePart", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update AlternatePart
		/// Calls [usp_update_AlternatePart]
        /// </summary>
		public override bool Update(System.Int32? alternatePartId, System.Int32? partNo, System.String fullPart, System.String part, System.Boolean? rohsCompliant, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_AlternatePart", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@AlternatePartId", SqlDbType.Int).Value = alternatePartId;
				cmd.Parameters.Add("@PartNo", SqlDbType.Int).Value = partNo;
				cmd.Parameters.Add("@FullPart", SqlDbType.NVarChar).Value = fullPart;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@ROHSCompliant", SqlDbType.Bit).Value = rohsCompliant;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update AlternatePart", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}