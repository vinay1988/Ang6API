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
	public class SqlRecentlyViewedProvider : RecentlyViewedProvider {
		/// <summary>
		/// Delete RecentlyViewed
		/// Calls [usp_delete_RecentlyViewed]
		/// </summary>
		public override bool Delete(System.Int32? recentlyViewedId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_RecentlyViewed", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@RecentlyViewedId", SqlDbType.Int).Value = recentlyViewedId;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete RecentlyViewed", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete RecentlyViewed
		/// Calls [usp_delete_RecentlyViewed_by_Login_and_PageTitle]
		/// </summary>
		public override bool DeleteByLoginAndPageTitle(System.Int32? loginNo, System.String pageTitle) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_RecentlyViewed_by_Login_and_PageTitle", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@PageTitle", SqlDbType.NVarChar).Value = pageTitle;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete RecentlyViewed", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_RecentlyViewed]
		/// </summary>
		public override Int32 Insert(System.Int32? loginNo, System.String pageTitle, System.String pageUrl) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_RecentlyViewed", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@PageTitle", SqlDbType.NVarChar).Value = pageTitle;
				cmd.Parameters.Add("@PageURL", SqlDbType.NVarChar).Value = pageUrl;
				cmd.Parameters.Add("@NewID", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@NewID"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert RecentlyViewed", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForUser 
		/// Calls [usp_selectAll_RecentlyViewed_for_User]
        /// </summary>
		public override List<RecentlyViewedDetails> GetListForUser(System.Int32? loginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_RecentlyViewed_for_User", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<RecentlyViewedDetails> lst = new List<RecentlyViewedDetails>();
				while (reader.Read()) {
					RecentlyViewedDetails obj = new RecentlyViewedDetails();
					obj.RecentlyViewedId = GetReaderValue_Int32(reader, "RecentlyViewedId", 0);
					obj.LoginNo = GetReaderValue_NullableInt32(reader, "LoginNo", null);
					obj.PageTitle = GetReaderValue_String(reader, "PageTitle", "");
					obj.PageURL = GetReaderValue_String(reader, "PageURL", "");
					obj.DateAdded = GetReaderValue_NullableDateTime(reader, "DateAdded", null);
					obj.Locked = GetReaderValue_NullableBoolean(reader, "Locked", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get RecentlyVieweds", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update RecentlyViewed
		/// Calls [usp_update_RecentlyViewed_Lock]
        /// </summary>
		public override bool UpdateLock(System.Int32? recentlyViewedId, System.Boolean? locked) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_RecentlyViewed_Lock", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@RecentlyViewedId", SqlDbType.Int).Value = recentlyViewedId;
				cmd.Parameters.Add("@Locked", SqlDbType.Bit).Value = locked;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update RecentlyViewed", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}