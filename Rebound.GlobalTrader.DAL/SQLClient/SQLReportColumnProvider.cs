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
	public class SqlReportColumnProvider : ReportColumnProvider {
        /// <summary>
        /// GetListForReport 
		/// Calls [usp_selectAll_ReportColumn_for_Report]
        /// </summary>
		public override List<ReportColumnDetails> GetListForReport(System.Int32? reportNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_ReportColumn_for_Report", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ReportNo", SqlDbType.Int).Value = reportNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ReportColumnDetails> lst = new List<ReportColumnDetails>();
				while (reader.Read()) {
					ReportColumnDetails obj = new ReportColumnDetails();
					obj.ReportColumnId = GetReaderValue_Int32(reader, "ReportColumnId", 0);
					obj.ReportNo = GetReaderValue_NullableInt32(reader, "ReportNo", null);
					obj.TitleResource = GetReaderValue_String(reader, "TitleResource", "");
					obj.ReportColumnFormatNo = GetReaderValue_NullableInt32(reader, "ReportColumnFormatNo", null);
					obj.HasSum = GetReaderValue_Boolean(reader, "HasSum", false);
					obj.HasCount = GetReaderValue_Boolean(reader, "HasCount", false);
					obj.HasAverage = GetReaderValue_Boolean(reader, "HasAverage", false);
					obj.HasPercentageOnSums = GetReaderValue_Boolean(reader, "HasPercentageOnSums", false);
					obj.PercentageNumeratorColumnIndex = GetReaderValue_NullableInt32(reader, "PercentageNumeratorColumnIndex", null);
					obj.PercentageDenominatorColumnIndex = GetReaderValue_NullableInt32(reader, "PercentageDenominatorColumnIndex", null);
					obj.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ReportColumns", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}