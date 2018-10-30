//Marker     Changed by      Date         Remarks
//[001]      Vinay           31/07/2012   Add enable/disable link in incoterms
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
	public class SqlIncotermProvider : IncotermProvider {
		/// <summary>
		/// Delete Incoterm
		/// Calls [usp_delete_Incoterm]
		/// </summary>
		public override bool Delete(System.Int32? incotermId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Incoterm", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IncotermId", SqlDbType.Int).Value = incotermId;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Incoterm", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDown 
		/// Calls [usp_dropdown_Incoterm]
        /// </summary>
		public override List<IncotermDetails> DropDown() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_Incoterm", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<IncotermDetails> lst = new List<IncotermDetails>();
				while (reader.Read()) {
					IncotermDetails obj = new IncotermDetails();
					obj.IncotermId = GetReaderValue_Int32(reader, "IncotermId", 0);
					obj.Name = GetReaderValue_String(reader, "Name", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Incoterms", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_Incoterm]
		/// </summary>
		public override Int32 Insert(System.String code, System.String name) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Incoterm", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = code;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
				cmd.Parameters.Add("@IncotermId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@IncotermId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Incoterm", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_Incoterm]
        /// </summary>
		public override IncotermDetails Get(System.Int32? incotermId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Incoterm", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@IncotermId", SqlDbType.Int).Value = incotermId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetIncotermFromReader(reader);
					IncotermDetails obj = new IncotermDetails();
					obj.IncotermId = GetReaderValue_Int32(reader, "IncotermId", 0);
					obj.Code = GetReaderValue_String(reader, "Code", "");
					obj.Name = GetReaderValue_String(reader, "Name", "");
                    //[001] code start
                    obj.Active = GetReaderValue_Boolean(reader, "Active", false);
                    //[001] code end
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Incoterm", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_Incoterm]
        /// </summary>
		public override List<IncotermDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Incoterm", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<IncotermDetails> lst = new List<IncotermDetails>();
                
				while (reader.Read()) {
					IncotermDetails obj = new IncotermDetails();
					obj.IncotermId = GetReaderValue_Int32(reader, "IncotermId", 0);
					obj.Code = GetReaderValue_String(reader, "Code", "");
					obj.Name = GetReaderValue_String(reader, "Name", "");
                    //[001] code start
                    obj.Active = GetReaderValue_Boolean(reader, "Active", false);
                    //[001] code end
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Incoterms", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Incoterm
		/// Calls [usp_update_Incoterm]
        /// </summary>
		public override bool Update(System.Int32? incotermId, System.String code, System.String name,System.Boolean Active) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Incoterm", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@IncotermId", SqlDbType.Int).Value = incotermId;
				cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = code;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
                //[001] code start
                cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = Active;
                //[001] code end
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Incoterm", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}