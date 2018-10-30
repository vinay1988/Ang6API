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
	public class SqlReportCategoryProvider : ReportCategoryProvider {
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_ReportCategory]
        /// </summary>
		public override List<ReportCategoryDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_ReportCategory", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ReportCategoryDetails> lst = new List<ReportCategoryDetails>();
				while (reader.Read()) {
					ReportCategoryDetails obj = new ReportCategoryDetails();
					obj.ReportCategoryId = GetReaderValue_Int32(reader, "ReportCategoryId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					obj.ReportCategoryGroupNo = GetReaderValue_NullableInt32(reader, "ReportCategoryGroupNo", null);
					obj.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ReportCategorys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForGroup 
		/// Calls [usp_selectAll_ReportCategory_for_Group]
        /// </summary>
		public override List<ReportCategoryDetails> GetListForGroup(System.Int32? reportCategoryGroupNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_ReportCategory_for_Group", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ReportCategoryGroupNo", SqlDbType.Int).Value = reportCategoryGroupNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ReportCategoryDetails> lst = new List<ReportCategoryDetails>();
				while (reader.Read()) {
					ReportCategoryDetails obj = new ReportCategoryDetails();
					obj.ReportCategoryId = GetReaderValue_Int32(reader, "ReportCategoryId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					obj.ReportCategoryGroupNo = GetReaderValue_NullableInt32(reader, "ReportCategoryGroupNo", null);
					obj.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ReportCategorys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}