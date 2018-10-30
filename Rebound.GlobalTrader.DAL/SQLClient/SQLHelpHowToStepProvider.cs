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
	public class SqlHelpHowToStepProvider : HelpHowToStepProvider {
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_HelpHowToStep]
        /// </summary>
		public override List<HelpHowToStepDetails> GetList(System.Int32? helpHowToNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_HelpHowToStep", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@HelpHowToNo", SqlDbType.Int).Value = helpHowToNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<HelpHowToStepDetails> lst = new List<HelpHowToStepDetails>();
				while (reader.Read()) {
					HelpHowToStepDetails obj = new HelpHowToStepDetails();
					obj.HelpHowToStepId = GetReaderValue_Int32(reader, "HelpHowToStepId", 0);
					obj.HelpHowToNo = GetReaderValue_Int32(reader, "HelpHowToNo", 0);
					obj.HTMLText = GetReaderValue_String(reader, "HTMLText", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get HelpHowToSteps", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}