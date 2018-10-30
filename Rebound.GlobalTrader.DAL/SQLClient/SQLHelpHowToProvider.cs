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
	public class SqlHelpHowToProvider : HelpHowToProvider {
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_HelpHowTo]
        /// </summary>
		public override List<HelpHowToDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_HelpHowTo", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<HelpHowToDetails> lst = new List<HelpHowToDetails>();
				while (reader.Read()) {
					HelpHowToDetails obj = new HelpHowToDetails();
					obj.HelpHowToId = GetReaderValue_Int32(reader, "HelpHowToId", 0);
					obj.HelpGroupNo = GetReaderValue_Int32(reader, "HelpGroupNo", 0);
					obj.Title = GetReaderValue_String(reader, "Title", "");
					obj.ImageName = GetReaderValue_String(reader, "ImageName", "");
					obj.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get HelpHowTos", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForGroup 
		/// Calls [usp_selectAll_HelpHowTo_for_Group]
        /// </summary>
		public override List<HelpHowToDetails> GetListForGroup(System.Int32? helpGroupNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_HelpHowTo_for_Group", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@HelpGroupNo", SqlDbType.Int).Value = helpGroupNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<HelpHowToDetails> lst = new List<HelpHowToDetails>();
				while (reader.Read()) {
					HelpHowToDetails obj = new HelpHowToDetails();
					obj.HelpHowToId = GetReaderValue_Int32(reader, "HelpHowToId", 0);
					obj.HelpGroupNo = GetReaderValue_Int32(reader, "HelpGroupNo", 0);
					obj.Title = GetReaderValue_String(reader, "Title", "");
					obj.ImageName = GetReaderValue_String(reader, "ImageName", "");
					obj.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get HelpHowTos", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}