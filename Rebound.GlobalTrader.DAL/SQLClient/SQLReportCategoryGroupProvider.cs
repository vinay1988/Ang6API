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
	public class SqlReportCategoryGroupProvider : ReportCategoryGroupProvider {
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_ReportCategoryGroup]
        /// </summary>
		public override List<ReportCategoryGroupDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_ReportCategoryGroup", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ReportCategoryGroupDetails> lst = new List<ReportCategoryGroupDetails>();
				while (reader.Read()) {
					ReportCategoryGroupDetails obj = new ReportCategoryGroupDetails();
					obj.ReportCategoryGroupId = GetReaderValue_Int32(reader, "ReportCategoryGroupId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					obj.SortOrder = GetReaderValue_String(reader, "SortOrder", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ReportCategoryGroups", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}