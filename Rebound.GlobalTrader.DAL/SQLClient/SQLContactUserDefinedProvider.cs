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
	public class SqlContactUserDefinedProvider : ContactUserDefinedProvider {
		/// <summary>
		/// Delete ContactUserDefined
		/// Calls [usp_delete_ContactUserDefined]
		/// </summary>
		public override bool Delete(System.Int32? contactNo, System.Int32? rowNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_ContactUserDefined", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@RowNo", SqlDbType.Int).Value = rowNo;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete ContactUserDefined", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete ContactUserDefined
		/// Calls [usp_delete_ContactUserDefined_for_Contact]
		/// </summary>
		public override bool DeleteForContact(System.Int32? contactNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_ContactUserDefined_for_Contact", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete ContactUserDefined", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_ContactUserDefined]
		/// </summary>
		public override Int32 Insert(System.Int32? contactNo, System.Int32? rowNo, System.String userDefinedHeading, System.String userDefinedValue, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_ContactUserDefined", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@RowNo", SqlDbType.Int).Value = rowNo;
				cmd.Parameters.Add("@UserDefinedHeading", SqlDbType.NVarChar).Value = userDefinedHeading;
				cmd.Parameters.Add("@UserDefinedValue", SqlDbType.NVarChar).Value = userDefinedValue;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@RowId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert ContactUserDefined", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_ContactUserDefined]
        /// </summary>
		public override ContactUserDefinedDetails Get(System.Int32? contactNo, System.Int32? rowNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_ContactUserDefined", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@RowNo", SqlDbType.Int).Value = rowNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetContactUserDefinedFromReader(reader);
					ContactUserDefinedDetails obj = new ContactUserDefinedDetails();
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.RowNo = GetReaderValue_Int32(reader, "RowNo", 0);
					obj.UserDefinedHeading = GetReaderValue_String(reader, "UserDefinedHeading", "");
					obj.UserDefinedValue = GetReaderValue_String(reader, "UserDefinedValue", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ContactUserDefined", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForContact 
		/// Calls [usp_selectAll_ContactUserDefined_for_Contact]
        /// </summary>
		public override List<ContactUserDefinedDetails> GetListForContact(System.Int32? contactNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_ContactUserDefined_for_Contact", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ContactUserDefinedDetails> lst = new List<ContactUserDefinedDetails>();
				while (reader.Read()) {
					ContactUserDefinedDetails obj = new ContactUserDefinedDetails();
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.RowNo = GetReaderValue_Int32(reader, "RowNo", 0);
					obj.UserDefinedHeading = GetReaderValue_String(reader, "UserDefinedHeading", "");
					obj.UserDefinedValue = GetReaderValue_String(reader, "UserDefinedValue", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ContactUserDefineds", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update ContactUserDefined
		/// Calls [usp_update_ContactUserDefined]
        /// </summary>
		public override bool Update(System.Int32? contactNo, System.Int32? rowNo, System.String userDefinedHeading, System.String userDefinedValue, System.Boolean? inactive, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_ContactUserDefined", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@RowNo", SqlDbType.Int).Value = rowNo;
				cmd.Parameters.Add("@UserDefinedHeading", SqlDbType.NVarChar).Value = userDefinedHeading;
				cmd.Parameters.Add("@UserDefinedValue", SqlDbType.NVarChar).Value = userDefinedValue;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update ContactUserDefined", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}