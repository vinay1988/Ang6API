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
	public class SqlReportParameterProvider : ReportParameterProvider {
        /// <summary>
        /// GetListForReport 
		/// Calls [usp_selectAll_ReportParameter_for_Report]
        /// </summary>
		public override List<ReportParameterDetails> GetListForReport(System.Int32? reportNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_ReportParameter_for_Report", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ReportNo", SqlDbType.Int).Value = reportNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ReportParameterDetails> lst = new List<ReportParameterDetails>();
				while (reader.Read()) {
					ReportParameterDetails obj = new ReportParameterDetails();
					obj.ReportParameterId = GetReaderValue_Int32(reader, "ReportParameterId", 0);
					obj.ReportNo = GetReaderValue_NullableInt32(reader, "ReportNo", null);
					obj.ParameterName = GetReaderValue_String(reader, "ParameterName", "");
					obj.Description = GetReaderValue_String(reader, "Description", "");
					obj.ReportParameterTypeNo = GetReaderValue_NullableInt32(reader, "ReportParameterTypeNo", null);
					obj.DropDownNo = GetReaderValue_NullableInt32(reader, "DropDownNo", null);
					obj.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null);
					obj.ComboAutoSearchNo = GetReaderValue_NullableInt32(reader, "ComboAutoSearchNo", null);
					obj.Optional = GetReaderValue_Boolean(reader, "Optional", false);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ReportParameters", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}