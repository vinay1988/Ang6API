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
	public class SqlActivityProvider : ActivityProvider {
        /// <summary>
        /// ListByClientWithFilter 
		/// Calls [usp_list_Activity_by_Client_with_filter]
        /// </summary>
		public override List<ActivityDetails> ListByClientWithFilter(System.Int32? clientId, System.Int32? pageIndex, System.Int32? pageSize, System.String tableSearch, System.String contactSearch, System.String cmSearch, System.String employeeSearch) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_list_Activity_by_Client_with_filter", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@TableSearch", SqlDbType.NVarChar).Value = tableSearch;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@EmployeeSearch", SqlDbType.NVarChar).Value = employeeSearch;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ActivityDetails> lst = new List<ActivityDetails>();
				while (reader.Read()) {
					ActivityDetails obj = new ActivityDetails();
					obj.TableName = GetReaderValue_String(reader, "TableName", "");
					obj.RowId = GetReaderValue_Int32(reader, "RowId", 0);
					obj.RowNumber = GetReaderValue_Int32(reader, "RowNumber", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.PartName = GetReaderValue_String(reader, "PartName", "");
					obj.RowValue = GetReaderValue_NullableDouble(reader, "RowValue", null);
					obj.RowDate = GetReaderValue_DateTime(reader, "RowDate", DateTime.MinValue);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Activitys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// ListByLoginWithFilter 
		/// Calls [usp_list_Activity_by_Login_with_filter]
        /// </summary>
		public override List<ActivityDetails> ListByLoginWithFilter(System.Int32? loginId, System.Int32? pageIndex, System.Int32? pageSize, System.String tableSearch, System.String contactSearch, System.String cmSearch, System.String employeeSearch) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_list_Activity_by_Login_with_filter", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@TableSearch", SqlDbType.NVarChar).Value = tableSearch;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@EmployeeSearch", SqlDbType.NVarChar).Value = employeeSearch;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ActivityDetails> lst = new List<ActivityDetails>();
				while (reader.Read()) {
					ActivityDetails obj = new ActivityDetails();
					obj.TableName = GetReaderValue_String(reader, "TableName", "");
					obj.RowId = GetReaderValue_Int32(reader, "RowId", 0);
					obj.RowNumber = GetReaderValue_Int32(reader, "RowNumber", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.PartName = GetReaderValue_String(reader, "PartName", "");
					obj.RowValue = GetReaderValue_NullableDouble(reader, "RowValue", null);
					obj.RowDate = GetReaderValue_DateTime(reader, "RowDate", DateTime.MinValue);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Activitys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
		
	}
}