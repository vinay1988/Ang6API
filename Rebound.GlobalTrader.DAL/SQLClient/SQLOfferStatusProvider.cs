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
	public class SqlOfferStatusProvider : OfferStatusProvider {
		/// <summary>
		/// Delete OfferStatus
		/// Calls [usp_delete_OfferStatus]
		/// </summary>
		public override bool Delete(System.Int32? offerStatusId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_OfferStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@OfferStatusId", SqlDbType.Int).Value = offerStatusId;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete OfferStatus", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDown 
		/// Calls [usp_dropdown_OfferStatus]
        /// </summary>
		public override List<OfferStatusDetails> DropDown() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_OfferStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<OfferStatusDetails> lst = new List<OfferStatusDetails>();
				while (reader.Read()) {
					OfferStatusDetails obj = new OfferStatusDetails();
					obj.OfferStatusId = GetReaderValue_Int32(reader, "OfferStatusId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get OfferStatuss", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_OfferStatus]
		/// </summary>
		public override Int32 Insert(System.String name) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_OfferStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
				cmd.Parameters.Add("@OfferStatusId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@OfferStatusId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert OfferStatus", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_OfferStatus]
        /// </summary>
		public override OfferStatusDetails Get(System.Int32? offerStatusId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_OfferStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@OfferStatusId", SqlDbType.Int).Value = offerStatusId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetOfferStatusFromReader(reader);
					OfferStatusDetails obj = new OfferStatusDetails();
					obj.OfferStatusId = GetReaderValue_Int32(reader, "OfferStatusId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get OfferStatus", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_OfferStatus]
        /// </summary>
		public override List<OfferStatusDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_OfferStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<OfferStatusDetails> lst = new List<OfferStatusDetails>();
				while (reader.Read()) {
					OfferStatusDetails obj = new OfferStatusDetails();
					obj.OfferStatusId = GetReaderValue_Int32(reader, "OfferStatusId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get OfferStatuss", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update OfferStatus
		/// Calls [usp_update_OfferStatus]
        /// </summary>
		public override bool Update(System.String name, System.Int32? offerStatusId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_OfferStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
				cmd.Parameters.Add("@OfferStatusId", SqlDbType.Int).Value = offerStatusId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update OfferStatus", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}