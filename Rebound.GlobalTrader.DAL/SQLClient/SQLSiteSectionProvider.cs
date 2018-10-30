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
	public class SqlSiteSectionProvider : SiteSectionProvider {
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_SiteSection]
        /// </summary>
		public override List<SiteSectionDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SiteSection", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SiteSectionDetails> lst = new List<SiteSectionDetails>();
				while (reader.Read()) {
					SiteSectionDetails obj = new SiteSectionDetails();
					obj.SiteSectionId = GetReaderValue_Int32(reader, "SiteSectionId", 0);
					obj.SiteSectionName = GetReaderValue_String(reader, "SiteSectionName", "");
					obj.Description = GetReaderValue_String(reader, "Description", "");
					obj.URL = GetReaderValue_String(reader, "URL", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SiteSections", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}