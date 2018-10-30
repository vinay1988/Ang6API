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
	public class SqlHelpGlossaryProvider : HelpGlossaryProvider {
        /// <summary>
        /// Get 
		/// Calls [usp_select_HelpGlossary]
        /// </summary>
		public override HelpGlossaryDetails Get(System.Int32? helpGlossaryId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_HelpGlossary", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@HelpGlossaryId", SqlDbType.Int).Value = helpGlossaryId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetHelpGlossaryFromReader(reader);
					HelpGlossaryDetails obj = new HelpGlossaryDetails();
					obj.HelpGlossaryId = GetReaderValue_Int32(reader, "HelpGlossaryId", 0);
					obj.Title = GetReaderValue_String(reader, "Title", "");
					obj.HTMLText = GetReaderValue_String(reader, "HTMLText", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get HelpGlossary", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_HelpGlossary]
        /// </summary>
		public override List<HelpGlossaryDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_HelpGlossary", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<HelpGlossaryDetails> lst = new List<HelpGlossaryDetails>();
				while (reader.Read()) {
					HelpGlossaryDetails obj = new HelpGlossaryDetails();
					obj.HelpGlossaryId = GetReaderValue_Int32(reader, "HelpGlossaryId", 0);
					obj.Title = GetReaderValue_String(reader, "Title", "");
					obj.HTMLText = GetReaderValue_String(reader, "HTMLText", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get HelpGlossarys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListByFirstLetter 
		/// Calls [usp_selectAll_HelpGlossary_by_FirstLetter]
        /// </summary>
		public override List<HelpGlossaryDetails> GetListByFirstLetter(System.String firstLetter) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_HelpGlossary_by_FirstLetter", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@FirstLetter", SqlDbType.NChar).Value = firstLetter;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<HelpGlossaryDetails> lst = new List<HelpGlossaryDetails>();
				while (reader.Read()) {
					HelpGlossaryDetails obj = new HelpGlossaryDetails();
					obj.HelpGlossaryId = GetReaderValue_Int32(reader, "HelpGlossaryId", 0);
					obj.Title = GetReaderValue_String(reader, "Title", "");
					obj.HTMLText = GetReaderValue_String(reader, "HTMLText", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get HelpGlossarys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}