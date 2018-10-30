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
	public class SqlHelpFaqProvider : HelpFaqProvider {
        /// <summary>
        /// Get 
		/// Calls [usp_select_HelpFAQ]
        /// </summary>
		public override HelpFaqDetails Get(System.Int32? helpFaqId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_HelpFAQ", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@HelpFAQId", SqlDbType.Int).Value = helpFaqId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetHelpFaqFromReader(reader);
					HelpFaqDetails obj = new HelpFaqDetails();
					obj.HelpFAQId = GetReaderValue_Int32(reader, "HelpFAQId", 0);
					obj.HelpGroupNo = GetReaderValue_Int32(reader, "HelpGroupNo", 0);
					obj.Question = GetReaderValue_String(reader, "Question", "");
					obj.Answer = GetReaderValue_String(reader, "Answer", "");
					obj.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get HelpFaq", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_HelpFAQ]
        /// </summary>
		public override List<HelpFaqDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_HelpFAQ", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<HelpFaqDetails> lst = new List<HelpFaqDetails>();
				while (reader.Read()) {
					HelpFaqDetails obj = new HelpFaqDetails();
					obj.HelpFAQId = GetReaderValue_Int32(reader, "HelpFAQId", 0);
					obj.HelpGroupNo = GetReaderValue_Int32(reader, "HelpGroupNo", 0);
					obj.Question = GetReaderValue_String(reader, "Question", "");
					obj.Answer = GetReaderValue_String(reader, "Answer", "");
					obj.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get HelpFaqs", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForGroup 
		/// Calls [usp_selectAll_HelpFAQ_for_Group]
        /// </summary>
		public override List<HelpFaqDetails> GetListForGroup(System.Int32? helpGroupNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_HelpFAQ_for_Group", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@HelpGroupNo", SqlDbType.Int).Value = helpGroupNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<HelpFaqDetails> lst = new List<HelpFaqDetails>();
				while (reader.Read()) {
					HelpFaqDetails obj = new HelpFaqDetails();
					obj.HelpFAQId = GetReaderValue_Int32(reader, "HelpFAQId", 0);
					obj.HelpGroupNo = GetReaderValue_Int32(reader, "HelpGroupNo", 0);
					obj.Question = GetReaderValue_String(reader, "Question", "");
					obj.Answer = GetReaderValue_String(reader, "Answer", "");
					obj.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get HelpFaqs", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}