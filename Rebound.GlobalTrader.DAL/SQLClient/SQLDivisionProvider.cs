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
	public class SqlDivisionProvider : DivisionProvider {
		/// <summary>
		/// Delete Division
		/// Calls [usp_delete_Division]
		/// </summary>
		public override bool Delete(System.Int32? divisionId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Division", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = divisionId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Division", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDownForClient 
		/// Calls [usp_dropdown_Division_for_Client]
        /// </summary>
		public override List<DivisionDetails> DropDownForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_Division_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<DivisionDetails> lst = new List<DivisionDetails>();
				while (reader.Read()) {
					DivisionDetails obj = new DivisionDetails();
					obj.DivisionId = GetReaderValue_Int32(reader, "DivisionId", 0);
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Divisions", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_Division]
		/// </summary>
        public override Int32 Insert(System.Int32? clientNo, System.String divisionName, System.Int32? manager, System.Double? budget, System.String telephone, System.String fax, System.String email, System.String notes, System.String url, System.Int32? addressNo, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? agency)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_Division", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@DivisionName", SqlDbType.NVarChar).Value = divisionName;
                cmd.Parameters.Add("@Manager", SqlDbType.Int).Value = manager;
                cmd.Parameters.Add("@Budget", SqlDbType.Float).Value = budget;
                cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = telephone;
                cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = fax;
                cmd.Parameters.Add("@EMail", SqlDbType.NVarChar).Value = email;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@URL", SqlDbType.NVarChar).Value = url;
                cmd.Parameters.Add("@AddressNo", SqlDbType.Int).Value = addressNo;
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@Agency", SqlDbType.Bit).Value = agency;
                cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@DivisionId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Division", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_Division]
        /// </summary>
		public override DivisionDetails Get(System.Int32? divisionId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Division", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = divisionId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetDivisionFromReader(reader);
					DivisionDetails obj = new DivisionDetails();
					obj.DivisionId = GetReaderValue_Int32(reader, "DivisionId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.AddressNo = GetReaderValue_NullableInt32(reader, "AddressNo", null);
					obj.Manager = GetReaderValue_NullableInt32(reader, "Manager", null);
					obj.Budget = GetReaderValue_NullableDouble(reader, "Budget", null);
					obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
					obj.Fax = GetReaderValue_String(reader, "Fax", "");
					obj.EMail = GetReaderValue_String(reader, "EMail", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.URL = GetReaderValue_String(reader, "URL", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.HasDocumentHeaderImage = GetReaderValue_Boolean(reader, "HasDocumentHeaderImage", false);
					obj.UseCompanyHeaderForInvoice = GetReaderValue_Boolean(reader, "UseCompanyHeaderForInvoice", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ManagerName = GetReaderValue_String(reader, "ManagerName", "");
                    obj.Agency = GetReaderValue_NullableBoolean(reader, "Agency", false);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Division", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetHasDocumentHeader 
		/// Calls [usp_select_Division_HasDocumentHeader]
        /// </summary>
		public override DivisionDetails GetHasDocumentHeader(System.Int32? divisionId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Division_HasDocumentHeader", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = divisionId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetDivisionFromReader(reader);
					DivisionDetails obj = new DivisionDetails();
					obj.HasDocumentHeaderImage = GetReaderValue_Boolean(reader, "HasDocumentHeaderImage", false);
					obj.UseCompanyHeaderForInvoice = GetReaderValue_Boolean(reader, "UseCompanyHeaderForInvoice", false);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Division", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForClient 
		/// Calls [usp_selectAll_Division_for_Client]
        /// </summary>
		public override List<DivisionDetails> GetListForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Division_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<DivisionDetails> lst = new List<DivisionDetails>();
				while (reader.Read()) {
					DivisionDetails obj = new DivisionDetails();
					obj.DivisionId = GetReaderValue_Int32(reader, "DivisionId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.Manager = GetReaderValue_NullableInt32(reader, "Manager", null);
					obj.Budget = GetReaderValue_NullableDouble(reader, "Budget", null);
					obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
					obj.Fax = GetReaderValue_String(reader, "Fax", "");
					obj.EMail = GetReaderValue_String(reader, "EMail", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.URL = GetReaderValue_String(reader, "URL", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ManagerName = GetReaderValue_String(reader, "ManagerName", "");
					obj.NumberOfMembers = GetReaderValue_NullableInt32(reader, "NumberOfMembers", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Divisions", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Division
		/// Calls [usp_update_Division]
        /// </summary>
		public override bool Update(System.Int32? divisionId, System.Int32? clientNo, System.String divisionName, System.Int32? manager, System.Double? budget, System.String telephone, System.String fax, System.String email, System.String notes, System.String url, System.Int32? addressNo, System.Boolean? inactive, System.Int32? updatedBy,System.Boolean? agency) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Division", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = divisionId;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@DivisionName", SqlDbType.NVarChar).Value = divisionName;
				cmd.Parameters.Add("@Manager", SqlDbType.Int).Value = manager;
				cmd.Parameters.Add("@Budget", SqlDbType.Float).Value = budget;
				cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = telephone;
				cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = fax;
				cmd.Parameters.Add("@EMail", SqlDbType.NVarChar).Value = email;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@URL", SqlDbType.NVarChar).Value = url;
				cmd.Parameters.Add("@AddressNo", SqlDbType.Int).Value = addressNo;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@Agency", SqlDbType.Bit).Value = agency;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Division", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Division
		/// Calls [usp_update_Division_AddressNo]
        /// </summary>
		public override bool UpdateAddressNo(System.Int32? divisionNo, System.Int32? addressNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Division_AddressNo", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
				cmd.Parameters.Add("@AddressNo", SqlDbType.Int).Value = addressNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Division", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Division
		/// Calls [usp_update_Division_DocumentHeaderImage]
        /// </summary>
		public override bool UpdateDocumentHeaderImage(System.Int32? divisionNo, System.Boolean? hasDocumentHeaderImage, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Division_DocumentHeaderImage", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
				cmd.Parameters.Add("@HasDocumentHeaderImage", SqlDbType.Bit).Value = hasDocumentHeaderImage;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Division", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Division
		/// Calls [usp_update_Division_UseCompanyHeaderForInvoice]
        /// </summary>
		public override bool UpdateUseCompanyHeaderForInvoice(System.Int32? divisionId, System.Boolean? useCompanyHeaderForInvoice, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Division_UseCompanyHeaderForInvoice", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = divisionId;
				cmd.Parameters.Add("@UseCompanyHeaderForInvoice", SqlDbType.Bit).Value = useCompanyHeaderForInvoice;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Division", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}