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
    public class SqlGTUpdateProvider : GTUpdateProvider
    {
        /// <summary>
        /// Calls [usp_Get_All_GTAPPUpdates]
        /// </summary>
        /// <returns></returns>
        public override List<GTUpdateDetails> GetListGTUpdate()
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_Get_All_GTAPPUpdates", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
                List<GTUpdateDetails> lst = new List<GTUpdateDetails>();
				while (reader.Read()) {
                    GTUpdateDetails obj = new GTUpdateDetails();
                    obj.GTAppUpdateId = GetReaderValue_Int32(reader, "GTAppUpdateID", 0);
                    obj.GTAppUpdateTitle = GetReaderValue_String(reader, "GTAppUpdateTitle", "");
                    obj.GTAppUpdateValue = GetReaderValue_String(reader, "GTAppUpdateValue", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.GTAppUpdateName = GetReaderValue_String(reader, "GTAppUpdateName", "");
                    obj.GTAppUpdateVersion = GetReaderValue_String(reader, "GTAppUpdateVersion", "");
                    obj.IsShowPopupHome = GetReaderValue_Boolean(reader, "IsShowPopupHome", false);
                    obj.IsSendMailtoUser = GetReaderValue_Boolean(reader, "IsSendMailtoUser", false);
                    obj.Inactive = GetReaderValue_Boolean(reader, "IsActive", false);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get GT Update", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}


        /// <summary>
        /// Insert
        /// Calls [usp_insert_GTAppUpdate]
        /// </summary>
        public override Int32 Insert (System.String GTAppUpdateName, System.String GTAppUpdateTitle, System.String GTAppUpdateValue, System.String GTAppUpdateVersion, System.Int32? ClientNo, System.Boolean? IsShowPopupHome, System.Boolean? IsSendMailtoUser, System.Boolean? inactive, System.Int32? updatedBy)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_GTAppUpdate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GTAppUpdateName", SqlDbType.NVarChar).Value = GTAppUpdateName;
                cmd.Parameters.Add("@GTAppUpdateTitle", SqlDbType.NVarChar).Value = GTAppUpdateTitle;
                cmd.Parameters.Add("@GTAppUpdateValue", SqlDbType.NVarChar).Value = GTAppUpdateValue;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = ClientNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@IsShowPopupHome", SqlDbType.Bit).Value = IsShowPopupHome;
                cmd.Parameters.Add("@IsSendMailtoUser", SqlDbType.Bit).Value = IsSendMailtoUser;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = inactive;
                cmd.Parameters.Add("@GTAppUpdateVersion", SqlDbType.NVarChar).Value = GTAppUpdateVersion;
                cmd.Parameters.Add("@GTAppUpdateId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@GTAppUpdateId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Certificate category", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
        /// Calls [usp_select_GTAPPUpdate]
        /// </summary>
		public override GTUpdateDetails Get(System.Int32? categoryId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_GTAPPUpdate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@GTAppUpdateId", SqlDbType.Int).Value = categoryId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCurrencyFromReader(reader);
                     GTUpdateDetails obj = new GTUpdateDetails();
                    obj.GTAppUpdateId = GetReaderValue_Int32(reader, "GTAppUpdateID", 0);
                    obj.GTAppUpdateTitle = GetReaderValue_String(reader, "GTAppUpdateTitle", "");
                    obj.GTAppUpdateValue = GetReaderValue_String(reader, "GTAppUpdateValue", "");
                    obj.ClientNo= GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.GTAppUpdateName = GetReaderValue_String(reader, "GTAppUpdateName", "");
                    obj.GTAppUpdateVersion = GetReaderValue_String(reader, "GTAppUpdateVersion", "");
                    obj.IsShowPopupHome = GetReaderValue_Boolean(reader, "IsShowPopupHome", false);
                    obj.IsSendMailtoUser = GetReaderValue_Boolean(reader, "IsSendMailtoUser", false);
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                   obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);

					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Certificate Category", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// Calls [usp_update_GTAppUpdate]
        /// </summary>
        public override bool Update(System.Int32 GTAppUpdateId ,System.String  GTAppUpdateName ,System.String GTAppUpdateTitle  ,System.String  GTAppUpdateValue,System.Int32? ClientNo  ,System.Int32? UpdatedBy,System.Boolean? IsShowPopupHome , System.Boolean?  IsSendMailtoUser,System.Boolean?  IsActive  ,System.String  GTAppUpdateVersion)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_GTAppUpdate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GTAppUpdateId", SqlDbType.Int).Value = GTAppUpdateId;
                cmd.Parameters.Add("@GTAppUpdateName", SqlDbType.NVarChar).Value = GTAppUpdateName;
                cmd.Parameters.Add("@GTAppUpdateTitle", SqlDbType.NVarChar).Value = GTAppUpdateTitle;
                cmd.Parameters.Add("@GTAppUpdateValue", SqlDbType.NVarChar).Value = GTAppUpdateValue;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = ClientNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UpdatedBy;
                cmd.Parameters.Add("@IsShowPopupHome", SqlDbType.Bit).Value = IsShowPopupHome;
                cmd.Parameters.Add("@IsSendMailtoUser", SqlDbType.Bit).Value = IsSendMailtoUser;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
                cmd.Parameters.Add("@GTAppUpdateVersion", SqlDbType.NVarChar).Value = GTAppUpdateVersion;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update GT App ", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

      
       
		
		
		
	}
}