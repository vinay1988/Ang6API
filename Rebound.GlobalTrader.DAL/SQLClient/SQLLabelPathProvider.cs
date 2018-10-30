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
	public class SqlLabelPathProvider : LabelPathProvider {
				
		
        /// <summary>
        /// DropDownForLabelPath 
        /// Calls [usp_dropdown_LabelPath]
        /// </summary>
        public override List<LabelPathDetails> DropDownForPrinter(System.Int32? clientId)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdown_LabelPath", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
                List<LabelPathDetails> lst = new List<LabelPathDetails>();
				while (reader.Read()) {
                    LabelPathDetails obj = new LabelPathDetails();
                    obj.LabelPathId = GetReaderValue_Int32(reader, "LabelPathId", 0);
                    obj.LabelFullPath = GetReaderValue_String(reader, "LabelFullPath", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Label Path", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
        /// <summary>
        /// Calls [usp_insert_LabelPath]
        /// </summary>
        /// <param name="clientNo"></param>
        /// <param name="labelPath"></param>
        /// <param name="description"></param>
        /// <param name="inActive"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public override int Insert(System.Int32? clientNo, System.String labelPath, System.String description, System.Boolean? inActive, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_LabelPath", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@LabelFullPath", SqlDbType.NVarChar).Value = labelPath;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
                cmd.Parameters.Add("@InActive", SqlDbType.Bit).Value = inActive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@LabelPathId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@LabelPathId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert LabelPath", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Update LabelPath
        /// Calls [usp_update_LabelPath]
        /// </summary>
        public override bool Update(System.Int32? labelPathId, System.Int32? clientNo, System.String labelPath, System.String description, System.Boolean? inActive, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_LabelPath", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LabelPathId", SqlDbType.Int).Value = labelPathId;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@LabelFullPath", SqlDbType.NVarChar).Value = labelPath;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
                cmd.Parameters.Add("@InActive", SqlDbType.Bit).Value = inActive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                ExecuteNonQuery(cmd);
                int ret = (Int32)cmd.Parameters["@RowsAffected"].Value;
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Label Path", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Call [usp_selectAll_LabelPath_for_Client]
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public override List<LabelPathDetails> GetListForClient(System.Int32? clientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_LabelPath_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<LabelPathDetails> lst = new List<LabelPathDetails>();
                while (reader.Read())
                {
                    LabelPathDetails obj = new LabelPathDetails();
                    obj.LabelPathId = GetReaderValue_Int32(reader, "LabelPathId", 0);
                    obj.LabelFullPath = GetReaderValue_String(reader, "LabelFullPath", "");
                    obj.Description = GetReaderValue_String(reader, "Description", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.UpdatedBy = GetReaderValue_Int32(reader, "UpdatedBy", 0);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get List", sqlex);
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