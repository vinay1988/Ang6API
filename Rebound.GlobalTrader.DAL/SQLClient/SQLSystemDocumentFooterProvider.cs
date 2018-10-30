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
	public class SqlSystemDocumentFooterProvider : SystemDocumentFooterProvider {
		/// <summary>
		/// Delete SystemDocumentFooter
		/// Calls [usp_delete_SystemDocumentFooter]
		/// </summary>
		public override bool Delete(System.Int32? systemDocumentFooterNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_SystemDocumentFooter", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SystemDocumentFooterNo", SqlDbType.Int).Value = systemDocumentFooterNo;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete SystemDocumentFooter", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_SystemDocumentFooter]
		/// </summary>
		public override Int32 Insert(System.Int32? clientNo, System.Int32? systemDocumentNo, System.String footerText, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_SystemDocumentFooter", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@SystemDocumentNo", SqlDbType.Int).Value = systemDocumentNo;
				cmd.Parameters.Add("@FooterText", SqlDbType.NVarChar).Value = footerText;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@NewId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert SystemDocumentFooter", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_SystemDocumentFooter]
        /// </summary>
		public override SystemDocumentFooterDetails Get(System.Int32? systemDocumentFooterNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_SystemDocumentFooter", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SystemDocumentFooterNo", SqlDbType.Int).Value = systemDocumentFooterNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetSystemDocumentFooterFromReader(reader);
					SystemDocumentFooterDetails obj = new SystemDocumentFooterDetails();
					obj.SystemDocumentFooterId = GetReaderValue_Int32(reader, "SystemDocumentFooterId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.SystemDocumentNo = GetReaderValue_Int32(reader, "SystemDocumentNo", 0);
					obj.FooterText = GetReaderValue_String(reader, "FooterText", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SystemDocumentFooter", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForClientAndDocument 
		/// Calls [usp_select_SystemDocumentFooter_for_Client_and_Document]
        /// </summary>
		public override SystemDocumentFooterDetails GetForClientAndDocument(System.Int32? clientNo, System.Int32? systemDocumentNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_SystemDocumentFooter_for_Client_and_Document", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@SystemDocumentNo", SqlDbType.Int).Value = systemDocumentNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetSystemDocumentFooterFromReader(reader);
					SystemDocumentFooterDetails obj = new SystemDocumentFooterDetails();
					obj.FooterText = GetReaderValue_String(reader, "FooterText", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SystemDocumentFooter", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForClient 
		/// Calls [usp_selectAll_SystemDocumentFooter_for_Client]
        /// </summary>
		public override List<SystemDocumentFooterDetails> GetListForClient(System.Int32? clientNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SystemDocumentFooter_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SystemDocumentFooterDetails> lst = new List<SystemDocumentFooterDetails>();
				while (reader.Read()) {
					SystemDocumentFooterDetails obj = new SystemDocumentFooterDetails();
					obj.SystemDocumentFooterId = GetReaderValue_Int32(reader, "SystemDocumentFooterId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.SystemDocumentNo = GetReaderValue_Int32(reader, "SystemDocumentNo", 0);
					obj.FooterText = GetReaderValue_String(reader, "FooterText", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
					obj.SystemDocumentName = GetReaderValue_String(reader, "SystemDocumentName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SystemDocumentFooters", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update SystemDocumentFooter
		/// Calls [usp_update_SystemDocumentFooter]
        /// </summary>
		public override bool Update(System.Int32? systemDocumentFooterId, System.Int32? clientNo, System.Int32? systemDocumentNo, System.String footerText, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_SystemDocumentFooter", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SystemDocumentFooterId", SqlDbType.Int).Value = systemDocumentFooterId;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@SystemDocumentNo", SqlDbType.Int).Value = systemDocumentNo;
				cmd.Parameters.Add("@FooterText", SqlDbType.NVarChar).Value = footerText;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update SystemDocumentFooter", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}