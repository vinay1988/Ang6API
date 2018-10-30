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
	public class SqlReasonProvider : ReasonProvider {
		/// <summary>
		/// Delete Reason
		/// Calls [usp_delete_Reason]
		/// </summary>
		public override bool Delete(System.Int32? reasonId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Reason", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ReasonId", SqlDbType.Int).Value = reasonId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Reason", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDown 
		/// Calls [usp_dropdown_Reason]
        /// </summary>
		public override List<ReasonDetails> DropDown() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_Reason", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ReasonDetails> lst = new List<ReasonDetails>();
				while (reader.Read()) {
					ReasonDetails obj = new ReasonDetails();
					obj.ReasonId = GetReaderValue_Int32(reader, "ReasonId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					obj.Sold = GetReaderValue_Boolean(reader, "Sold", false);
					obj.NotQuoted = GetReaderValue_Boolean(reader, "NotQuoted", false);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Reasons", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_Reason]
		/// </summary>
		public override Int32 Insert(System.String name) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Reason", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
				cmd.Parameters.Add("@ReasonId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@ReasonId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Reason", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_Reason]
        /// </summary>
		public override ReasonDetails Get(System.Int32? reasonId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Reason", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ReasonId", SqlDbType.Int).Value = reasonId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetReasonFromReader(reader);
					ReasonDetails obj = new ReasonDetails();
					obj.ReasonId = GetReaderValue_Int32(reader, "ReasonId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					obj.Locked = GetReaderValue_Boolean(reader, "Locked", false);
					obj.Sold = GetReaderValue_Boolean(reader, "Sold", false);
					obj.NotQuoted = GetReaderValue_Boolean(reader, "NotQuoted", false);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Reason", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_Reason]
        /// </summary>
		public override List<ReasonDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Reason", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ReasonDetails> lst = new List<ReasonDetails>();
				while (reader.Read()) {
					ReasonDetails obj = new ReasonDetails();
					obj.ReasonId = GetReaderValue_Int32(reader, "ReasonId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					obj.Locked = GetReaderValue_Boolean(reader, "Locked", false);
					obj.Sold = GetReaderValue_Boolean(reader, "Sold", false);
					obj.NotQuoted = GetReaderValue_Boolean(reader, "NotQuoted", false);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Reasons", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Reason
		/// Calls [usp_update_Reason]
        /// </summary>
		public override bool Update(System.String name, System.Int32? reasonId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Reason", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
				cmd.Parameters.Add("@ReasonId", SqlDbType.Int).Value = reasonId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Reason", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// DropDown 
        /// Calls [usp_dropdown_StatusReason]
        /// </summary>
        public override List<ReasonDetails> DropDown(System.String strSection)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdown_StatusReason", cn);
                cmd.Parameters.Add("@Section", SqlDbType.NVarChar).Value = strSection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<ReasonDetails> lst = new List<ReasonDetails>();
                while (reader.Read())
                {
                    ReasonDetails obj = new ReasonDetails();
                    obj.ReasonId = GetReaderValue_Int32(reader, "StatusReasonId", 0);
                    obj.Name = GetReaderValue_String(reader, "Name", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Reasons", sqlex);
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