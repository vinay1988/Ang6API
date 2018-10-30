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
	public class SqlPartSearchProvider : PartSearchProvider {
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_PartSearch]
		/// </summary>
		public override Int32 Insert(System.Int32? loginNo, System.String searchPart) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_PartSearch", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@SearchPart", SqlDbType.NVarChar).Value = searchPart;
				cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@NewId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert PartSearch", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForLogin 
		/// Calls [usp_selectAll_PartSearch_for_Login]
        /// </summary>
		public override List<PartSearchDetails> GetListForLogin(System.Int32? loginNo, System.String partSearch) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_PartSearch_for_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PartSearchDetails> lst = new List<PartSearchDetails>();
				while (reader.Read()) {
					PartSearchDetails obj = new PartSearchDetails();
					obj.SearchPart = GetReaderValue_String(reader, "SearchPart", "");
					obj.LoginNo = GetReaderValue_NullableInt32(reader, "LoginNo", null);
					obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PartSearchs", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}