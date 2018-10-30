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
	public class SqlFeedbackProvider : FeedbackProvider {
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_Feedback]
		/// </summary>
		public override Int32 Insert(System.Int32? loginNo, System.String feedbackText) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Feedback", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@FeedbackText", SqlDbType.NVarChar).Value = feedbackText;
				cmd.Parameters.Add("@NewID", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@NewID"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Feedback", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}