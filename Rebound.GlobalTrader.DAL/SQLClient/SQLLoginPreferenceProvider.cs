//Marker     Changed by      Date         Remarks
//[001]      Vinay           20/06/2012   This need to notify the user by email.
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
	public class SqlLoginPreferenceProvider : LoginPreferenceProvider {
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_LoginPreference]
		/// </summary>
		public override Int32 Insert(System.Int32? loginNo, System.Boolean? showMessageAlert, System.Int32? defaultSiteLanguageNo, System.Int32? defaultListPageSize, System.Int32? numberRecentlyViewedPages, System.Int32? defaultHomePageTab, System.Int32? defaultListPageView, System.String backgroundImage, System.Boolean? saveDataListNuggetStateByDefault, System.Int32? loginTimeout, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_LoginPreference", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@ShowMessageAlert", SqlDbType.Bit).Value = showMessageAlert;
				cmd.Parameters.Add("@DefaultSiteLanguageNo", SqlDbType.Int).Value = defaultSiteLanguageNo;
				cmd.Parameters.Add("@DefaultListPageSize", SqlDbType.Int).Value = defaultListPageSize;
				cmd.Parameters.Add("@NumberRecentlyViewedPages", SqlDbType.Int).Value = numberRecentlyViewedPages;
				cmd.Parameters.Add("@DefaultHomePageTab", SqlDbType.Int).Value = defaultHomePageTab;
				cmd.Parameters.Add("@DefaultListPageView", SqlDbType.Int).Value = defaultListPageView;
				cmd.Parameters.Add("@BackgroundImage", SqlDbType.NVarChar).Value = backgroundImage;
				cmd.Parameters.Add("@SaveDataListNuggetStateByDefault", SqlDbType.Bit).Value = saveDataListNuggetStateByDefault;
				cmd.Parameters.Add("@LoginTimeout", SqlDbType.Int).Value = loginTimeout;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@LoginPreferenceId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@LoginPreferenceId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert LoginPreference", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetByLogin 
		/// Calls [usp_select_LoginPreference_by_Login]
        /// </summary>
		public override LoginPreferenceDetails GetByLogin(System.Int32? loginNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_LoginPreference_by_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetLoginPreferenceFromReader(reader);
					LoginPreferenceDetails obj = new LoginPreferenceDetails();
					obj.LoginNo = GetReaderValue_Int32(reader, "LoginNo", 0);
					obj.ShowMessageAlert = GetReaderValue_Boolean(reader, "ShowMessageAlert", false);
					obj.DefaultSiteLanguageNo = GetReaderValue_NullableInt32(reader, "DefaultSiteLanguageNo", null);
					obj.DefaultListPageSize = GetReaderValue_Int32(reader, "DefaultListPageSize", 0);
					obj.NumberRecentlyViewedPages = GetReaderValue_Int32(reader, "NumberRecentlyViewedPages", 0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
					obj.DefaultHomePageTab = GetReaderValue_Int32(reader, "DefaultHomePageTab", 0);
					obj.DefaultListPageView = GetReaderValue_Int32(reader, "DefaultListPageView", 0);
					obj.BackgroundImage = GetReaderValue_String(reader, "BackgroundImage", "");
					obj.SaveDataListNuggetStateByDefault = GetReaderValue_Boolean(reader, "SaveDataListNuggetStateByDefault", false);
					obj.LoginTimeout = GetReaderValue_Int32(reader, "LoginTimeout", 0);
					obj.DefaultSiteLanguageCode = GetReaderValue_String(reader, "DefaultSiteLanguageCode", "");
                    //[001] code start
                    obj.SendEmail = GetReaderValue_Boolean(reader, "SendEmail", false);
                    //[001] code end
                    obj.PrinterNo = GetReaderValue_NullableInt32(reader, "PrinterNo", null);
                    obj.PrinterName = GetReaderValue_String(reader, "PrinterName", "");
                    obj.LabelPathNo = GetReaderValue_NullableInt32(reader, "LabelPathNo", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get LoginPreference", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update LoginPreference
		/// Calls [usp_update_LoginPreference]
        /// </summary>
        public override bool Update(System.Int32? loginNo, System.Boolean? showMessageAlert, System.Int32? defaultSiteLanguageNo, System.Int32? defaultListPageSize, System.Int32? numberRecentlyViewedPages, System.Int32? defaultHomePageTab, System.Int32? defaultListPageView, System.String backgroundImage, System.Boolean? saveDataListNuggetStateByDefault, System.Int32? loginTimeout, System.Int32? updatedBy, System.Boolean? SendEmail, System.Int32? printerNo)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_LoginPreference", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
				cmd.Parameters.Add("@ShowMessageAlert", SqlDbType.Bit).Value = showMessageAlert;
				cmd.Parameters.Add("@DefaultSiteLanguageNo", SqlDbType.Int).Value = defaultSiteLanguageNo;
				cmd.Parameters.Add("@DefaultListPageSize", SqlDbType.Int).Value = defaultListPageSize;
				cmd.Parameters.Add("@NumberRecentlyViewedPages", SqlDbType.Int).Value = numberRecentlyViewedPages;
				cmd.Parameters.Add("@DefaultHomePageTab", SqlDbType.Int).Value = defaultHomePageTab;
				cmd.Parameters.Add("@DefaultListPageView", SqlDbType.Int).Value = defaultListPageView;
				cmd.Parameters.Add("@BackgroundImage", SqlDbType.NVarChar).Value = backgroundImage;
				cmd.Parameters.Add("@SaveDataListNuggetStateByDefault", SqlDbType.Bit).Value = saveDataListNuggetStateByDefault;
				cmd.Parameters.Add("@LoginTimeout", SqlDbType.Int).Value = loginTimeout;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //[001] code start
                cmd.Parameters.Add("@SendEmail", SqlDbType.Bit).Value = SendEmail;
                //[001] code end
                cmd.Parameters.Add("@PrinterNo", SqlDbType.Int).Value = printerNo;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update LoginPreference", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
        //[001] code start
        /// <summary>
        /// GetByLoginForSendEmail
        /// usp_select_login_for_sendemail
        /// </summary>
        /// <param name="loginNo"></param>
        /// <returns></returns>
        public override LoginPreferenceDetails GetByLoginForSendEmail(System.Int32? loginId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_login_for_sendemail", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@loginId", SqlDbType.Int).Value = loginId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    LoginPreferenceDetails obj = new LoginPreferenceDetails();
                    obj.SendEmail = GetReaderValue_Boolean(reader, "SendEmail", false);
                    obj.Email = GetReaderValue_String(reader, "EMail", "");
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get login details", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[001] code end
		
		
		
	}
}