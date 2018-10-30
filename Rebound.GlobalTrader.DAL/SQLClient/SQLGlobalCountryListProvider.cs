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
	public class SqlGlobalCountryListProvider : GlobalCountryListProvider {
        /// <summary>
        /// DropDown 
		/// Calls [usp_dropdown_GlobalCountryList]
        /// </summary>
		public override List<GlobalCountryListDetails> DropDown(System.Boolean? includeSelected, System.Int32? clientNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_GlobalCountryList", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@IncludeSelected", SqlDbType.Bit).Value = includeSelected;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<GlobalCountryListDetails> lst = new List<GlobalCountryListDetails>();
				while (reader.Read()) {
					GlobalCountryListDetails obj = new GlobalCountryListDetails();
					obj.GlobalCountryId = GetReaderValue_Int32(reader, "GlobalCountryId", 0);
					obj.GlobalCountryName = GetReaderValue_String(reader, "GlobalCountryName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get GlobalCountryLists", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_GlobalCountryList]
		/// </summary>
		public override Int32 Insert(System.String globalCountryName, System.Boolean? eecMember, System.String telephonePrefix, System.Boolean? include, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_GlobalCountryList", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@GlobalCountryName", SqlDbType.NVarChar).Value = globalCountryName;
				cmd.Parameters.Add("@EECMember", SqlDbType.Bit).Value = eecMember;
				cmd.Parameters.Add("@TelephonePrefix", SqlDbType.NVarChar).Value = telephonePrefix;
				cmd.Parameters.Add("@Include", SqlDbType.Bit).Value = include;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@NewId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert GlobalCountryList", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_GlobalCountryList]
        /// </summary>
		public override GlobalCountryListDetails Get(System.Int32? countryNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_GlobalCountryList", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CountryNo", SqlDbType.Int).Value = countryNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetGlobalCountryListFromReader(reader);
					GlobalCountryListDetails obj = new GlobalCountryListDetails();
					obj.GlobalCountryId = GetReaderValue_Int32(reader, "GlobalCountryId", 0);
					obj.GlobalCountryName = GetReaderValue_String(reader, "GlobalCountryName", "");
					obj.EECMember = GetReaderValue_Boolean(reader, "EECMember", false);
					obj.TelephonePrefix = GetReaderValue_String(reader, "TelephonePrefix", "");
					obj.Include = GetReaderValue_Boolean(reader, "Include", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get GlobalCountryList", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_GlobalCountryList]
        /// </summary>
		public override List<GlobalCountryListDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_GlobalCountryList", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<GlobalCountryListDetails> lst = new List<GlobalCountryListDetails>();
				while (reader.Read()) {
					GlobalCountryListDetails obj = new GlobalCountryListDetails();
					obj.GlobalCountryId = GetReaderValue_Int32(reader, "GlobalCountryId", 0);
					obj.GlobalCountryName = GetReaderValue_String(reader, "GlobalCountryName", "");
					obj.EECMember = GetReaderValue_Boolean(reader, "EECMember", false);
					obj.TelephonePrefix = GetReaderValue_String(reader, "TelephonePrefix", "");
					obj.Include = GetReaderValue_Boolean(reader, "Include", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get GlobalCountryLists", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update GlobalCountryList
		/// Calls [usp_update_GlobalCountryList]
        /// </summary>
		public override bool Update(System.Int32? globalCountryId, System.String globalCountryName, System.String telephonePrefix, System.Boolean? eecMember, System.Boolean? include, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_GlobalCountryList", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@GlobalCountryId", SqlDbType.Int).Value = globalCountryId;
				cmd.Parameters.Add("@GlobalCountryName", SqlDbType.NVarChar).Value = globalCountryName;
				cmd.Parameters.Add("@TelephonePrefix", SqlDbType.NVarChar).Value = telephonePrefix;
				cmd.Parameters.Add("@EECMember", SqlDbType.Bit).Value = eecMember;
				cmd.Parameters.Add("@Include", SqlDbType.Bit).Value = include;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update GlobalCountryList", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}