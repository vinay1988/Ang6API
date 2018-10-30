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
	public class SqlHelpGroupProvider : HelpGroupProvider {
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_HelpGroup]
        /// </summary>
		public override List<HelpGroupDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_HelpGroup", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<HelpGroupDetails> lst = new List<HelpGroupDetails>();
				while (reader.Read()) {
					HelpGroupDetails obj = new HelpGroupDetails();
					obj.HelpGroupId = GetReaderValue_Int32(reader, "HelpGroupId", 0);
					obj.Title = GetReaderValue_String(reader, "Title", "");
					obj.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get HelpGroups", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}