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
	public class SqlSitePageProvider : SitePageProvider {
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_SitePage]
        /// </summary>
		public override List<SitePageDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SitePage", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SitePageDetails> lst = new List<SitePageDetails>();
				while (reader.Read()) {
					SitePageDetails obj = new SitePageDetails();
					obj.SitePageId = GetReaderValue_Int32(reader, "SitePageId", 0);
					obj.ShortName = GetReaderValue_String(reader, "ShortName", "");
					obj.Description = GetReaderValue_String(reader, "Description", "");
					obj.URL = GetReaderValue_String(reader, "URL", "");
					obj.SiteSectionNo = GetReaderValue_NullableInt32(reader, "SiteSectionNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SitePages", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListHavingSecurityFunctionBySiteSection 
		/// Calls [usp_selectAll_SitePage_having_SecurityFunction_by_SiteSection]
        /// </summary>
		public override List<SitePageDetails> GetListHavingSecurityFunctionBySiteSection(System.Int32? siteSectionNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SitePage_having_SecurityFunction_by_SiteSection", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SiteSectionNo", SqlDbType.Int).Value = siteSectionNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SitePageDetails> lst = new List<SitePageDetails>();
				while (reader.Read()) {
					SitePageDetails obj = new SitePageDetails();
					obj.SitePageId = GetReaderValue_Int32(reader, "SitePageId", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SitePages", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}