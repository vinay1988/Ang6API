/*
Marker     changed by      date         Remarks
[001]      Vinay           19/07/2012   Display invoice email status report
*/
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
	public class SqlReportProvider : ReportProvider {
		/// <summary>
		/// Delete Report
		/// Calls [usp_delete_Report]
		/// </summary>
		public override bool Delete(System.Int32? reportId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Report", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ReportId", SqlDbType.Int).Value = reportId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_101]
		/// </summary>
        public override List<List<object>> Report101(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_101", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_102]
		/// </summary>
		public override List<List<object>> Report102(System.Int32? clientNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_102", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_103]
		/// </summary>
		public override List<List<object>> Report103(System.Int32? clientNo, System.Int32? salesman) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_103", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_104]
		/// </summary>
		public override List<List<object>> Report104(System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_104", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_105]
		/// </summary>
		public override List<List<object>> Report105(System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_105", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_107]
		/// </summary>
		public override List<List<object>> Report107(System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_107", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_108]
		/// </summary>
		public override List<List<object>> Report108(System.Int32? loginId, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_108", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_109]
		/// </summary>
        public override List<List<object>> Report109(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_109", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_110]
		/// </summary>
        public override List<List<object>> Report110(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_110", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_111]
		/// </summary>
		public override List<List<object>> Report111() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_111", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_112]
		/// </summary>
		public override List<List<object>> Report112() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_112", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_113]
		/// </summary>
        public override List<List<object>> Report113(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_113", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_114]
		/// </summary>
        public override List<List<object>> Report114(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_114", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_117]
		/// </summary>
        public override List<List<object>> Report117(System.Int32? clientNo, System.Boolean? excludeOnStop, System.Boolean? includeUnpaid, System.DateTime? dueDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_117", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@ExcludeOnStop", SqlDbType.Bit).Value = excludeOnStop;
				cmd.Parameters.Add("@IncludeUnpaid", SqlDbType.Bit).Value = includeUnpaid;
				cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = dueDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_118]
		/// </summary>
        public override List<List<object>> Report118(System.Int32? clientNo, System.Boolean? excludeOnStop, System.Boolean? includeUnpaid, System.DateTime? dueDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_118", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@ExcludeOnStop", SqlDbType.Bit).Value = excludeOnStop;
				cmd.Parameters.Add("@IncludeUnpaid", SqlDbType.Bit).Value = includeUnpaid;
				cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = dueDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_119]
		/// </summary>
		public override List<List<object>> Report119(System.Int32? clientNo, System.Int32? salesman, System.DateTime? dueDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_119", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = dueDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_120]
		/// </summary>
        public override List<List<object>> Report120(System.Int32? clientNo, System.DateTime? dueDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_120", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = dueDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_121]
		/// </summary>
        public override List<List<object>> Report121(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.String status, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_121", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
				cmd.Parameters.Add("@Status", SqlDbType.Char).Value = status;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_121A]
		/// </summary>
		public override List<List<object>> Report121A(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate, System.String status) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_121A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
				cmd.Parameters.Add("@Status", SqlDbType.Char).Value = status;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_121B]
		/// </summary>
		public override List<List<object>> Report121B(System.Int32? clientNo, System.Int32? buyer, System.DateTime? startDate, System.DateTime? endDate, System.String status) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_121B", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Buyer", SqlDbType.Int).Value = buyer;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
				cmd.Parameters.Add("@Status", SqlDbType.Char).Value = status;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_122]
		/// </summary>
		public override List<List<object>> Report122(System.Int32? clientNo, System.Int32? warehouseNo, System.Boolean? valueStockOnly, System.String location) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_122", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
				cmd.Parameters.Add("@ValueStockOnly", SqlDbType.Bit).Value = valueStockOnly;
				cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = location;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_122A]
		/// </summary>
		public override List<List<object>> Report122A(System.Int32? clientNo, System.Int32? warehouseNo, System.Int32? lotNo, System.Boolean? valueStockOnly, System.String location) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_122A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
				cmd.Parameters.Add("@LotNo", SqlDbType.Int).Value = lotNo;
				cmd.Parameters.Add("@ValueStockOnly", SqlDbType.Bit).Value = valueStockOnly;
				cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = location;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_122B]
		/// </summary>
		public override List<List<object>> Report122B() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_122B", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_123]
		/// </summary>
        public override List<List<object>> Report123(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_123", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_123A]
		/// </summary>
        public override List<List<object>> Report123A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_123A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_124]
		/// </summary>
        public override List<List<object>> Report124(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeShipping, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_124", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
				cmd.Parameters.Add("@IncludeShipping", SqlDbType.Bit).Value = includeShipping;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_124A]
		/// </summary>
		public override List<List<object>> Report124A(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_124A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_124B]
		/// </summary>
        public override List<List<object>> Report124B(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_124B", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_125]
		/// </summary>
        public override List<List<object>> Report125(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_125", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_125A]
		/// </summary>
		public override List<List<object>> Report125A(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_125A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_125B]
		/// </summary>
        public override List<List<object>> Report125B(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_125B", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_126]
		/// </summary>
		public override List<List<object>> Report126(System.Int32? clientNo, System.Int32? salesman) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_126", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_128]
		/// </summary>
        public override List<List<object>> Report128(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? postedOnly, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_128", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
				cmd.Parameters.Add("@PostedOnly", SqlDbType.Bit).Value = postedOnly;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_128A]
		/// </summary>
		public override List<List<object>> Report128A(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? postedOnly) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_128A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
				cmd.Parameters.Add("@PostedOnly", SqlDbType.Bit).Value = postedOnly;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_129]
		/// </summary>
        public override List<List<object>> Report129(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_129", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_130]
		/// </summary>
        public override List<List<object>> Report130(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeCredits, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_130", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
				cmd.Parameters.Add("@IncludeCredits", SqlDbType.Bit).Value = includeCredits;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_130A]
		/// </summary>
        public override List<List<object>> Report130A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeCredits, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_130A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
				cmd.Parameters.Add("@IncludeCredits", SqlDbType.Bit).Value = includeCredits;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_130B]
		/// </summary>
        public override List<List<object>> Report130B(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeCredits, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_130B", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
				cmd.Parameters.Add("@IncludeCredits", SqlDbType.Bit).Value = includeCredits;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_133]
		/// </summary>
		public override List<List<object>> Report133(System.Int32? clientNo, System.Boolean? includeOnOrder, System.Boolean? unallocatedOnly, System.Boolean? includeLotsOnHold) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_133", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@IncludeOnOrder", SqlDbType.Bit).Value = includeOnOrder;
				cmd.Parameters.Add("@UnallocatedOnly", SqlDbType.Bit).Value = unallocatedOnly;
				cmd.Parameters.Add("@IncludeLotsOnHold", SqlDbType.Bit).Value = includeLotsOnHold;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_133A]
		/// </summary>
		public override List<List<object>> Report133A() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_133A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_137]
		/// </summary>
        public override List<List<object>> Report137(System.Int32? clientNo, System.Int32? lotNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_137", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@LotNo", SqlDbType.Int).Value = lotNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_139]
		/// </summary>
        public override List<List<object>> Report139(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_139", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_139A]
		/// </summary>
        public override List<List<object>> Report139A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_139A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_139B]
		/// </summary>
        public override List<List<object>> Report139B(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_139B", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_143]
		/// </summary>
		public override List<List<object>> Report143(System.Int32? clientNo, System.Int32? warehouseNo, System.Boolean? valueStockOnly) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_143", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
				cmd.Parameters.Add("@ValueStockOnly", SqlDbType.Bit).Value = valueStockOnly;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_143A]
		/// </summary>
		public override List<List<object>> Report143A() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_143A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_144]
		/// </summary>
        public override List<List<object>> Report144(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_144", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_144A]
		/// </summary>
        public override List<List<object>> Report144A(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_144A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_144B]
		/// </summary>
		public override List<List<object>> Report144B(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_144B", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_147]
		/// </summary>
        public override List<List<object>> Report147(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_147", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
               cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_147A]
		/// </summary>
        public override List<List<object>> Report147A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_147A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_147B]
		/// </summary>
        public override List<List<object>> Report147B(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_147B", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_149]
		/// </summary>
		public override List<List<object>> Report149(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_149", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_150]
		/// </summary>
        public override List<List<object>> Report150(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_150", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_150A]
		/// </summary>
        public override List<List<object>> Report150A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_150A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_150B]
		/// </summary>
		public override List<List<object>> Report150B(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_150B", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_150C]
		/// </summary>
		public override List<List<object>> Report150C(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_150C", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_150D]
		/// </summary>
        public override List<List<object>> Report150D(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_150D", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_150E]
		/// </summary>
        public override List<List<object>> Report150E(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_150E", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_153]
		/// </summary>
        public override List<List<object>> Report153(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_153", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_153A]
		/// </summary>
        public override List<List<object>> Report153A(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_153A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_153B]
		/// </summary>
		public override List<List<object>> Report153B(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_153B", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_153C]
		/// </summary>
        public override List<List<object>> Report153C(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_153C", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_153D]
		/// </summary>
        public override List<List<object>> Report153D(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_153D", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_153E]
		/// </summary>
		public override List<List<object>> Report153E(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_153E", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_156]
		/// </summary>
        public override List<List<object>> Report156(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_156", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_156A]
		/// </summary>
        public override List<List<object>> Report156A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_156A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_156B]
		/// </summary>
		public override List<List<object>> Report156B(System.Int32? clientNo, System.Int32? buyer, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_156B", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Buyer", SqlDbType.Int).Value = buyer;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_156C]
		/// </summary>
		public override List<List<object>> Report156C(System.Int32? clientNo, System.Int32? buyer, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_156C", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Buyer", SqlDbType.Int).Value = buyer;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_156D]
		/// </summary>
        public override List<List<object>> Report156D(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_156D", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_156E]
		/// </summary>
        public override List<List<object>> Report156E(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_156E", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_159]
		/// </summary>
        public override List<List<object>> Report159(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_159", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_159A]
		/// </summary>
		public override List<List<object>> Report159A(System.Int32? clientNo, System.Int32? buyer, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_159A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Buyer", SqlDbType.Int).Value = buyer;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_159B]
		/// </summary>
        public override List<List<object>> Report159B(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_159B", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_159C]
		/// </summary>
        public override List<List<object>> Report159C(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_159C", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_159D]
		/// </summary>
		public override List<List<object>> Report159D(System.Int32? clientNo, System.Int32? buyer, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_159D", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Buyer", SqlDbType.Int).Value = buyer;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_159E]
		/// </summary>
        public override List<List<object>> Report159E(System.Int32? clientNo, System.Int32? companyNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_159E", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_162]
		/// </summary>
		public override List<List<object>> Report162(System.Int32? clientNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_162", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_176]
		/// </summary>
		public override List<List<object>> Report176(System.Int32? clientNo, System.DateTime? dueDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_176", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = dueDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_177]
		/// </summary>
        public override List<List<object>> Report177(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_177", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_181]
		/// </summary>
		public override List<List<object>> Report181(System.Int32? clientNo, System.Int32? warehouseNo, System.String location) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_181", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
				cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = location;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_181A]
		/// </summary>
		public override List<List<object>> Report181A() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_181A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_182]
		/// </summary>
		public override List<List<object>> Report182(System.Int32? clientNo, System.DateTime? cutOffDate, System.Int32? salesman, System.String companyGrouping, System.Boolean? includeNever) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_182", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CutOffDate", SqlDbType.DateTime).Value = cutOffDate;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@CompanyGrouping", SqlDbType.Char).Value = companyGrouping;
				cmd.Parameters.Add("@IncludeNever", SqlDbType.Bit).Value = includeNever;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_183]
		/// </summary>
		public override List<List<object>> Report183(System.Int32? clientNo, System.DateTime? cutOffDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_183", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CutOffDate", SqlDbType.DateTime).Value = cutOffDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_184]
		/// </summary>
		public override List<List<object>> Report184(System.Int32? clientNo, System.Int32? employee, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_184", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Employee", SqlDbType.Int).Value = employee;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_185]
		/// </summary>
        public override List<List<object>> Report185(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_185", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_185A]
		/// </summary>
        public override List<List<object>> Report185A(System.Int32? clientNo, System.Int32? companyNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_185A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_185B]
		/// </summary>
		public override List<List<object>> Report185B(System.Int32? clientNo, System.Int32? salesman) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_185B", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_188]
		/// </summary>
		public override List<List<object>> Report188(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_188", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_189]
		/// </summary>
		public override List<List<object>> Report189(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_189", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_190]
		/// </summary>
		public override List<List<object>> Report190(System.Int32? clientNo, System.Int32? salesman, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_190", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_191]
		/// </summary>
		public override List<List<object>> Report191(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_191", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_192]
		/// </summary>
        public override List<List<object>> Report192(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_192", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_193]
		/// </summary>
        public override List<List<object>> Report193(System.Int32? clientNo, System.Int32? countryNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_193", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CountryNo", SqlDbType.Int).Value = countryNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_194]
		/// </summary>
        public override List<List<object>> Report194(System.Int32? clientNo, System.Int32? warehouseNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_194", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_195]
		/// </summary>
        public override List<List<object>> Report195(System.Int32? clientNo, System.Int32? warehouseNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_195", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_195A]
		/// </summary>
		public override List<List<object>> Report195A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_195A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_196]
		/// </summary>
        public override List<List<object>> Report196(System.Int32? clientNo, System.Int32? warehouseNo, System.DateTime? startDate, System.DateTime? endDate, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_196", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_196A]
		/// </summary>
		public override List<List<object>> Report196A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_196A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_197]
		/// </summary>
		public override List<List<object>> Report197(System.Int32? clientNo, System.Int32? warehouseNo, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_197", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_197A]
		/// </summary>
		public override List<List<object>> Report197A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_197A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_198]
		/// </summary>
		public override List<List<object>> Report198(System.Int32? clientNo, System.Int32? warehouseNo, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_198", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_198A]
		/// </summary>
		public override List<List<object>> Report198A(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_198A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_199]
		/// </summary>
		public override List<List<object>> Report199(System.Int32? clientNo, System.Int32? countryNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_199", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CountryNo", SqlDbType.Int).Value = countryNo;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_200]
		/// </summary>
        public override List<List<object>> Report200(System.Int32? clientNo, System.Boolean? lateOnly, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_200", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@LateOnly", SqlDbType.Bit).Value = lateOnly;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_201]
		/// </summary>
        public override List<List<object>> Report201(System.Int32? clientNo, System.Int32? companyNo, System.Boolean? lateOnly, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_201", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@LateOnly", SqlDbType.Bit).Value = lateOnly;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_202]
		/// </summary>
        public override List<List<object>> Report202(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_202", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_203]
		/// </summary>
        public override List<List<object>> Report203(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_203", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_204]
		/// </summary>
        public override List<List<object>> Report204(System.Int32? clientNo, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_204", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_205]
		/// </summary>
        public override List<List<object>> Report205(System.Int32? clientId, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeUnconfirmed, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_205", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
				cmd.Parameters.Add("@IncludeUnconfirmed", SqlDbType.Bit).Value = includeUnconfirmed;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_205A]
		/// </summary>
		public override List<List<object>> Report205A(System.Int32? clientId, System.Int32? supplierId, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeUnconfirmed) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_205A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@SupplierId", SqlDbType.Int).Value = supplierId;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
				cmd.Parameters.Add("@IncludeUnconfirmed", SqlDbType.Bit).Value = includeUnconfirmed;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_205B]
		/// </summary>
		public override List<List<object>> Report205B(System.Int32? clientId, System.Int32? companyType, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? includeUnconfirmed) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_205B", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@CompanyType", SqlDbType.Int).Value = companyType;
				cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
				cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
				cmd.Parameters.Add("@IncludeUnconfirmed", SqlDbType.Bit).Value = includeUnconfirmed;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_206A]
		/// </summary>
		public override List<List<object>> Report206A(System.Int32? clientNo, System.Boolean? invalidOnly) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_206A", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@InvalidOnly", SqlDbType.Bit).Value = invalidOnly;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_206B]
		/// </summary>
        public override List<List<object>> Report206B(System.Int32? clientNo, System.Boolean? invalidOnly, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_206B", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@InvalidOnly", SqlDbType.Bit).Value = invalidOnly;
                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Calls [usp_report_Report_207]
		/// </summary>
		public override List<List<object>> Report207(System.Int32? warehouseNo, System.Int32? topToSelect) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_report_Report_207", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 90;
				cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
				cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				if (reader.HasRows) {
					return GetReportDataFromReader(reader);
				} else {
					return null;
				}			
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
        //[001] code start
        /// <summary>
        /// Calls [usp_report_Report_124C]
        /// </summary>
        public override List<List<object>> Report124C(System.Int32? clientNo, System.DateTime? startDate, System.DateTime? endDate, System.Boolean? failedOnly, System.Int32? intLoginId, System.Boolean? ViewMyReport)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_report_Report_124C", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 90;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = endDate;
                if (failedOnly.HasValue && failedOnly.Value)
                    cmd.Parameters.Add("@FailedOnly", SqlDbType.Bit).Value = failedOnly.Value;
                else
                    cmd.Parameters.Add("@FailedOnly", SqlDbType.Bit).Value = DBNull.Value;

                cmd.Parameters.Add("@IntLoginId", SqlDbType.Int).Value = intLoginId;
                cmd.Parameters.Add("@ViewMyReport", SqlDbType.Bit).Value = ViewMyReport;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                if (reader.HasRows)
                {
                    return GetReportDataFromReader(reader);
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get report", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        //[002] code start
        /// <summary>
        /// Calls [usp_report_Report_210]
        /// </summary>
        public override List<List<object>> Report210(System.Decimal? percentage, System.Int32 lotId )
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_report_Report_210", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 90;
                //cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;              
                cmd.Parameters.Add("@Percentage", SqlDbType.Decimal).Value = percentage;
                cmd.Parameters.Add("@LotId", SqlDbType.Int).Value = lotId;

                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                if (reader.HasRows)
                {
                    return GetReportDataFromReader(reader);
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get report", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[001] code end
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_Report]
        /// </summary>
		public override ReportDetails Get(System.Int32? reportId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Report", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ReportId", SqlDbType.Int).Value = reportId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetReportFromReader(reader);
					ReportDetails obj = new ReportDetails();
					obj.ReportId = GetReaderValue_Int32(reader, "ReportId", 0);
					obj.ReportName = GetReaderValue_String(reader, "ReportName", "");
					obj.ReportCategoryNo = GetReaderValue_NullableInt32(reader, "ReportCategoryNo", null);
					obj.StoredProcName = GetReaderValue_String(reader, "StoredProcName", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.AvailableAsPDF = GetReaderValue_Boolean(reader, "AvailableAsPDF", false);
					obj.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ReportCategoryName = GetReaderValue_String(reader, "ReportCategoryName", "");
					obj.ReportCategorySortOrder = GetReaderValue_NullableInt32(reader, "ReportCategorySortOrder", null);
					obj.ReportCategoryGroupNo = GetReaderValue_NullableInt32(reader, "ReportCategoryGroupNo", null);
					obj.ReportCategoryGroupName = GetReaderValue_String(reader, "ReportCategoryGroupName", "");
					obj.ReportCategoryGroupSortOrder = GetReaderValue_String(reader, "ReportCategoryGroupSortOrder", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Report", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForCategory 
		/// Calls [usp_selectAll_Report_for_Category]
        /// </summary>
		public override List<ReportDetails> GetListForCategory(System.Int32? reportCategoryNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Report_for_Category", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ReportCategoryNo", SqlDbType.Int).Value = reportCategoryNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ReportDetails> lst = new List<ReportDetails>();
				while (reader.Read()) {
					ReportDetails obj = new ReportDetails();
					obj.ReportId = GetReaderValue_Int32(reader, "ReportId", 0);
					obj.ReportName = GetReaderValue_String(reader, "ReportName", "");
					obj.ReportCategoryNo = GetReaderValue_NullableInt32(reader, "ReportCategoryNo", null);
					obj.StoredProcName = GetReaderValue_String(reader, "StoredProcName", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.AvailableAsPDF = GetReaderValue_Boolean(reader, "AvailableAsPDF", false);
					obj.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ReportCategoryName = GetReaderValue_String(reader, "ReportCategoryName", "");
					obj.ReportCategorySortOrder = GetReaderValue_NullableInt32(reader, "ReportCategorySortOrder", null);
					obj.ReportCategoryGroupNo = GetReaderValue_NullableInt32(reader, "ReportCategoryGroupNo", null);
					obj.ReportCategoryGroupName = GetReaderValue_String(reader, "ReportCategoryGroupName", "");
					obj.ReportCategoryGroupSortOrder = GetReaderValue_String(reader, "ReportCategoryGroupSortOrder", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Reports", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForCategoryAndLogin 
		/// Calls [usp_selectAll_Report_for_Category_and_Login]
        /// </summary>
		public override List<ReportDetails> GetListForCategoryAndLogin(System.Int32? reportCategoryNo, System.Int32? loginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Report_for_Category_and_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ReportCategoryNo", SqlDbType.Int).Value = reportCategoryNo;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ReportDetails> lst = new List<ReportDetails>();
				while (reader.Read()) {
					ReportDetails obj = new ReportDetails();
					obj.ReportId = GetReaderValue_Int32(reader, "ReportId", 0);
					obj.ReportName = GetReaderValue_String(reader, "ReportName", "");
					obj.ReportCategoryNo = GetReaderValue_NullableInt32(reader, "ReportCategoryNo", null);
					obj.StoredProcName = GetReaderValue_String(reader, "StoredProcName", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.AvailableAsPDF = GetReaderValue_Boolean(reader, "AvailableAsPDF", false);
					obj.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ReportCategoryName = GetReaderValue_String(reader, "ReportCategoryName", "");
					obj.ReportCategorySortOrder = GetReaderValue_NullableInt32(reader, "ReportCategorySortOrder", null);
					obj.ReportCategoryGroupNo = GetReaderValue_NullableInt32(reader, "ReportCategoryGroupNo", null);
					obj.ReportCategoryGroupName = GetReaderValue_String(reader, "ReportCategoryGroupName", "");
					obj.ReportCategoryGroupSortOrder = GetReaderValue_String(reader, "ReportCategoryGroupSortOrder", "");
                    obj.HUBReport = GetReaderValue_NullableBoolean(reader, "IsHUBReport", false);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Reports", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListInSameGroupForLogin 
		/// Calls [usp_selectAll_Report_in_same_Group_for_Login]
        /// </summary>
		public override List<ReportDetails> GetListInSameGroupForLogin(System.Int32? loginNo, System.Int32? reportId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Report_in_same_Group_for_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@ReportId", SqlDbType.Int).Value = reportId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ReportDetails> lst = new List<ReportDetails>();
				while (reader.Read()) {
					ReportDetails obj = new ReportDetails();
					obj.ReportId = GetReaderValue_Int32(reader, "ReportId", 0);
					obj.ReportName = GetReaderValue_String(reader, "ReportName", "");
					obj.ReportCategoryNo = GetReaderValue_NullableInt32(reader, "ReportCategoryNo", null);
					obj.ReportCategoryName = GetReaderValue_String(reader, "ReportCategoryName", "");
					obj.ReportCategoryGroupNo = GetReaderValue_NullableInt32(reader, "ReportCategoryGroupNo", null);
					obj.ReportCategoryGroupName = GetReaderValue_String(reader, "ReportCategoryGroupName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Reports", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}