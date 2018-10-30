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
	public class SqlSettingItemProvider : SettingItemProvider {
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_SettingItem]
        /// </summary>
		public override List<SettingItemDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SettingItem", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SettingItemDetails> lst = new List<SettingItemDetails>();
				while (reader.Read()) {
					SettingItemDetails obj = new SettingItemDetails();
					obj.SettingItemID = GetReaderValue_Int32(reader, "SettingItemID", 0);
					obj.SettingItemName = GetReaderValue_String(reader, "SettingItemName", "");
					obj.DefaultValue = GetReaderValue_String(reader, "DefaultValue", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SettingItems", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}