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
	public class SqlCommunicationLogProvider : CommunicationLogProvider {
        /// <summary>
        /// DataListNugget 
		/// Calls [usp_datalistnugget_CommunicationLog]
        /// </summary>
		public override List<CommunicationLogDetails> DataListNugget(System.Int32? clientId, System.Int32? companyNo, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? loginId, System.String details, System.Int32? contactNo, System.Int32? communicationLogTypeNo, System.String logCallType, System.DateTime? logDateLo, System.DateTime? logDateHi) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_CommunicationLog", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@Details", SqlDbType.NVarChar).Value = details;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@CommunicationLogTypeNo", SqlDbType.Int).Value = communicationLogTypeNo;
				cmd.Parameters.Add("@LogCallType", SqlDbType.NVarChar).Value = logCallType;
				cmd.Parameters.Add("@LogDateLo", SqlDbType.DateTime).Value = logDateLo;
				cmd.Parameters.Add("@LogDateHi", SqlDbType.DateTime).Value = logDateHi;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CommunicationLogDetails> lst = new List<CommunicationLogDetails>();
				while (reader.Read()) {
					CommunicationLogDetails obj = new CommunicationLogDetails();
					obj.CommunicationLogId = GetReaderValue_Int32(reader, "CommunicationLogId", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.Frozen = GetReaderValue_Boolean(reader, "Frozen", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.LogDate = GetReaderValue_DateTime(reader, "LogDate", DateTime.MinValue);
					obj.KeyNo = GetReaderValue_NullableInt32(reader, "KeyNo", null);
					obj.CommunicationLogTypeNo = GetReaderValue_NullableInt32(reader, "CommunicationLogTypeNo", null);
					obj.SystemDocumentNo = GetReaderValue_NullableInt32(reader, "SystemDocumentNo", null);
					obj.DocumentNumber = GetReaderValue_NullableInt32(reader, "DocumentNumber", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CommunicationLogTypeDescription = GetReaderValue_String(reader, "CommunicationLogTypeDescription", "");
					obj.EnteredBy = GetReaderValue_String(reader, "EnteredBy", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CommunicationLogs", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete CommunicationLog
		/// Calls [usp_delete_CommunicationLog]
		/// </summary>
		public override bool Delete(System.Int32? communicationLogId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_CommunicationLog", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CommunicationLogId", SqlDbType.Int).Value = communicationLogId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete CommunicationLog", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_CommunicationLog]
		/// </summary>
		public override Int32 Insert(System.Int32? communicationLogTypeNo, System.Int32? systemDocumentNo, System.DateTime? logDate, System.String notes, System.Int32? contactNo, System.Int32? companyNo, System.Boolean? frozen, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_CommunicationLog", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CommunicationLogTypeNo", SqlDbType.Int).Value = communicationLogTypeNo;
				cmd.Parameters.Add("@SystemDocumentNo", SqlDbType.Int).Value = systemDocumentNo;
				cmd.Parameters.Add("@LogDate", SqlDbType.DateTime).Value = logDate;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@Frozen", SqlDbType.Bit).Value = frozen;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@CommunicationLogId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@CommunicationLogId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert CommunicationLog", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_CommunicationLog]
        /// </summary>
		public override CommunicationLogDetails Get(System.Int32? communicationLogId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_CommunicationLog", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CommunicationLogId", SqlDbType.Int).Value = communicationLogId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCommunicationLogFromReader(reader);
					CommunicationLogDetails obj = new CommunicationLogDetails();
					obj.CommunicationLogId = GetReaderValue_Int32(reader, "CommunicationLogId", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.Frozen = GetReaderValue_Boolean(reader, "Frozen", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.LogDate = GetReaderValue_DateTime(reader, "LogDate", DateTime.MinValue);
					obj.KeyNo = GetReaderValue_NullableInt32(reader, "KeyNo", null);
					obj.CommunicationLogTypeNo = GetReaderValue_NullableInt32(reader, "CommunicationLogTypeNo", null);
					obj.SystemDocumentNo = GetReaderValue_NullableInt32(reader, "SystemDocumentNo", null);
					obj.DocumentNumber = GetReaderValue_NullableInt32(reader, "DocumentNumber", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CommunicationLogTypeDescription = GetReaderValue_String(reader, "CommunicationLogTypeDescription", "");
					obj.EnteredBy = GetReaderValue_String(reader, "EnteredBy", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CommunicationLog", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_CommunicationLog]
        /// </summary>
		public override List<CommunicationLogDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_CommunicationLog", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CommunicationLogDetails> lst = new List<CommunicationLogDetails>();
				while (reader.Read()) {
					CommunicationLogDetails obj = new CommunicationLogDetails();
					obj.CommunicationLogId = GetReaderValue_Int32(reader, "CommunicationLogId", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.Frozen = GetReaderValue_Boolean(reader, "Frozen", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.LogDate = GetReaderValue_DateTime(reader, "LogDate", DateTime.MinValue);
					obj.KeyNo = GetReaderValue_NullableInt32(reader, "KeyNo", null);
					obj.CommunicationLogTypeNo = GetReaderValue_NullableInt32(reader, "CommunicationLogTypeNo", null);
					obj.SystemDocumentNo = GetReaderValue_NullableInt32(reader, "SystemDocumentNo", null);
					obj.DocumentNumber = GetReaderValue_NullableInt32(reader, "DocumentNumber", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CommunicationLogTypeDescription = GetReaderValue_String(reader, "CommunicationLogTypeDescription", "");
					obj.EnteredBy = GetReaderValue_String(reader, "EnteredBy", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CommunicationLogs", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForCommunicationLogType 
		/// Calls [usp_selectAll_CommunicationLog_for_CommunicationLogType]
        /// </summary>
		public override List<CommunicationLogDetails> GetListForCommunicationLogType(System.Int32? communicationLogTypeId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_CommunicationLog_for_CommunicationLogType", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CommunicationLogTypeId", SqlDbType.Int).Value = communicationLogTypeId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CommunicationLogDetails> lst = new List<CommunicationLogDetails>();
				while (reader.Read()) {
					CommunicationLogDetails obj = new CommunicationLogDetails();
					obj.CommunicationLogId = GetReaderValue_Int32(reader, "CommunicationLogId", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.Frozen = GetReaderValue_Boolean(reader, "Frozen", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.LogDate = GetReaderValue_DateTime(reader, "LogDate", DateTime.MinValue);
					obj.KeyNo = GetReaderValue_NullableInt32(reader, "KeyNo", null);
					obj.CommunicationLogTypeNo = GetReaderValue_NullableInt32(reader, "CommunicationLogTypeNo", null);
					obj.SystemDocumentNo = GetReaderValue_NullableInt32(reader, "SystemDocumentNo", null);
					obj.DocumentNumber = GetReaderValue_NullableInt32(reader, "DocumentNumber", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CommunicationLogTypeDescription = GetReaderValue_String(reader, "CommunicationLogTypeDescription", "");
					obj.EnteredBy = GetReaderValue_String(reader, "EnteredBy", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CommunicationLogs", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForCompany 
		/// Calls [usp_selectAll_CommunicationLog_for_Company]
        /// </summary>
		public override List<CommunicationLogDetails> GetListForCompany(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_CommunicationLog_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CommunicationLogDetails> lst = new List<CommunicationLogDetails>();
				while (reader.Read()) {
					CommunicationLogDetails obj = new CommunicationLogDetails();
					obj.CommunicationLogId = GetReaderValue_Int32(reader, "CommunicationLogId", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.Frozen = GetReaderValue_Boolean(reader, "Frozen", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.LogDate = GetReaderValue_DateTime(reader, "LogDate", DateTime.MinValue);
					obj.KeyNo = GetReaderValue_NullableInt32(reader, "KeyNo", null);
					obj.CommunicationLogTypeNo = GetReaderValue_NullableInt32(reader, "CommunicationLogTypeNo", null);
					obj.SystemDocumentNo = GetReaderValue_NullableInt32(reader, "SystemDocumentNo", null);
					obj.DocumentNumber = GetReaderValue_NullableInt32(reader, "DocumentNumber", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CommunicationLogTypeDescription = GetReaderValue_String(reader, "CommunicationLogTypeDescription", "");
					obj.EnteredBy = GetReaderValue_String(reader, "EnteredBy", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CommunicationLogs", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForContact 
		/// Calls [usp_selectAll_CommunicationLog_for_Contact]
        /// </summary>
		public override List<CommunicationLogDetails> GetListForContact(System.Int32? contactId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_CommunicationLog_for_Contact", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ContactId", SqlDbType.Int).Value = contactId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CommunicationLogDetails> lst = new List<CommunicationLogDetails>();
				while (reader.Read()) {
					CommunicationLogDetails obj = new CommunicationLogDetails();
					obj.CommunicationLogId = GetReaderValue_Int32(reader, "CommunicationLogId", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.Frozen = GetReaderValue_Boolean(reader, "Frozen", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.LogDate = GetReaderValue_DateTime(reader, "LogDate", DateTime.MinValue);
					obj.KeyNo = GetReaderValue_NullableInt32(reader, "KeyNo", null);
					obj.CommunicationLogTypeNo = GetReaderValue_NullableInt32(reader, "CommunicationLogTypeNo", null);
					obj.SystemDocumentNo = GetReaderValue_NullableInt32(reader, "SystemDocumentNo", null);
					obj.DocumentNumber = GetReaderValue_NullableInt32(reader, "DocumentNumber", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CommunicationLogTypeDescription = GetReaderValue_String(reader, "CommunicationLogTypeDescription", "");
					obj.EnteredBy = GetReaderValue_String(reader, "EnteredBy", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CommunicationLogs", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update CommunicationLog
		/// Calls [usp_update_CommunicationLog]
        /// </summary>
		public override bool Update(System.Int32? communicationLogId, System.Int32? communicationLogTypeNo, System.Int32? systemDocumentNo, System.String notes, System.Int32? contactNo, System.Int32? companyNo, System.Boolean? frozen, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_CommunicationLog", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CommunicationLogId", SqlDbType.Int).Value = communicationLogId;
				cmd.Parameters.Add("@CommunicationLogTypeNo", SqlDbType.Int).Value = communicationLogTypeNo;
				cmd.Parameters.Add("@SystemDocumentNo", SqlDbType.Int).Value = systemDocumentNo;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@Frozen", SqlDbType.Bit).Value = frozen;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update CommunicationLog", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// InsertPrintEmailLog
        /// Calls [usp_insert_PrintEmailLog]
        /// </summary>
        public override Int32 InsertPrintEmailLog(System.String sectionName, System.String subSectionName, System.String actionName, System.Int32? documentNo, System.String Detail, System.Int32? UpdatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_PrintEmailLog", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SectionName", SqlDbType.VarChar).Value = sectionName;
                cmd.Parameters.Add("@SubSectionName", SqlDbType.VarChar).Value = subSectionName;
                cmd.Parameters.Add("@ActionName", SqlDbType.VarChar).Value = actionName;
                cmd.Parameters.Add("@DocumentNo", SqlDbType.Int).Value = documentNo;
                cmd.Parameters.Add("@Detail", SqlDbType.NVarChar).Value = Detail;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UpdatedBy;
                cmd.Parameters.Add("@PrintDocumentLogId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@PrintDocumentLogId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Print/email document", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// GetPrintEmailLog
        /// Calls [usp_select_PrintEmailLog]
        /// </summary>
        public override List<CommunicationLogDetails> GetPrintEmailLog(System.Int32? documentNo, System.String secionName)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_PrintEmailLog", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@DocumentNo", SqlDbType.Int).Value = documentNo;
                cmd.Parameters.Add("@SectionName", SqlDbType.VarChar).Value = secionName;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CommunicationLogDetails> lst = new List<CommunicationLogDetails>();
                while (reader.Read())
                {
                    CommunicationLogDetails obj = new CommunicationLogDetails();
                    obj.CommunicationLogId = GetReaderValue_Int32(reader, "PrintDocumentLogId", 0);
                    obj.SystemDocumentNo = GetReaderValue_NullableInt32(reader, "DocumentNo", 0);
                    obj.LogDetail = GetReaderValue_String(reader, "Detail", "");
                    obj.SectionName = GetReaderValue_String(reader, "SectionName", "");
                    obj.ActionName = GetReaderValue_String(reader, "ActionName", "");
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.UpdatedByName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.SubSectionName = GetReaderValue_String(reader, "SubSectionName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get print/email Logs", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		
		
		
		
	}
}