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

namespace Rebound.GlobalTrader.DAL.SqlClient
{
    public class SqlLoginProvider : LoginProvider
    {
        /// <summary>
        /// AutoSearchForMail 
        /// Calls [usp_autosearch_Login_for_Mail]
        /// </summary>
        public override List<LoginDetails> AutoSearchForMail(System.Int32? clientId, System.Int32? loginId, System.String nameSearch)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_autosearch_Login_for_Mail", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<LoginDetails> lst = new List<LoginDetails>();
                while (reader.Read())
                {
                    LoginDetails obj = new LoginDetails();
                    obj.LoginId = GetReaderValue_Int32(reader, "LoginId", 0);
                    obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.MailMessageAddressType = GetReaderValue_String(reader, "MailMessageAddressType", "");
                    obj.MailMessageAddressSort = GetReaderValue_String(reader, "MailMessageAddressSort", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Logins", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Delete Login
        /// Calls [usp_delete_Login]
        /// </summary>
        public override bool Delete(System.Int32? loginId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete Login", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// DropDownForClient 
        /// Calls [usp_dropdown_Login_for_Client]
        /// </summary>
        public override List<LoginDetails> DropDownForClient(System.Int32? clientNo, System.Int32? teamNo, System.Int32? divisionNo, System.Int32? excludeLoginNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdown_Login_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@TeamNo", SqlDbType.Int).Value = teamNo;
                cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
                cmd.Parameters.Add("@ExcludeLoginNo", SqlDbType.Int).Value = excludeLoginNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<LoginDetails> lst = new List<LoginDetails>();
                while (reader.Read())
                {
                    LoginDetails obj = new LoginDetails();
                    obj.LoginId = GetReaderValue_Int32(reader, "LoginId", 0);
                    obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Logins", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// DropDownForClient 
        /// Calls [usp_dropdown_Login_for_ClientNPR]
        /// </summary>
        public override List<LoginDetails> DropDownForClientNPR(System.Int32? goodsInLineNo, System.Int32? teamNo, System.Int32? divisionNo, System.Int32? excludeLoginNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdown_Login_for_ClientNPR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@GoodsInlineNo", SqlDbType.Int).Value = goodsInLineNo;
                cmd.Parameters.Add("@TeamNo", SqlDbType.Int).Value = teamNo;
                cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
                cmd.Parameters.Add("@ExcludeLoginNo", SqlDbType.Int).Value = excludeLoginNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<LoginDetails> lst = new List<LoginDetails>();
                while (reader.Read())
                {
                    LoginDetails obj = new LoginDetails();
                    obj.LoginId = GetReaderValue_Int32(reader, "LoginId", 0);
                    obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Logins", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Create a new row
        /// Calls [usp_insert_Login]
        /// </summary>
        public override Int32 Insert(System.Int32? clientNo, System.String loginName, System.String employeeName, System.String firstName, System.String lastName, System.Int32? addressNo, System.String title, System.String extension, System.String telephone, System.String fax, System.String email, System.String notes, System.String homeTelephone, System.String homeFax, System.String homeEmail, System.String mobile, System.Int32? divisionNo, System.Int32? teamNo, System.String salutation, System.Boolean? keyLogin, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@LoginName", SqlDbType.NVarChar).Value = loginName;
                cmd.Parameters.Add("@EmployeeName", SqlDbType.NVarChar).Value = employeeName;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastName;
                cmd.Parameters.Add("@AddressNo", SqlDbType.Int).Value = addressNo;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
                cmd.Parameters.Add("@Extension", SqlDbType.NVarChar).Value = extension;
                cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = telephone;
                cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = fax;
                cmd.Parameters.Add("@EMail", SqlDbType.NVarChar).Value = email;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@HomeTelephone", SqlDbType.NVarChar).Value = homeTelephone;
                cmd.Parameters.Add("@HomeFax", SqlDbType.NVarChar).Value = homeFax;
                cmd.Parameters.Add("@HomeEmail", SqlDbType.NVarChar).Value = homeEmail;
                cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = mobile;
                cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
                cmd.Parameters.Add("@TeamNo", SqlDbType.Int).Value = teamNo;
                cmd.Parameters.Add("@Salutation", SqlDbType.NVarChar).Value = salutation;
                cmd.Parameters.Add("@KeyLogin", SqlDbType.Bit).Value = keyLogin;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@LoginId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Login", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Login
        /// Calls [usp_login_Login]
        /// </summary>
        public override Int32 Login(System.String loginName, System.String password, System.String ipAddress, System.String sessionId,System.String serverIP)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_login_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LoginName", SqlDbType.NVarChar).Value = loginName;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = password;
                cmd.Parameters.Add("@IPAddress", SqlDbType.NVarChar).Value = ipAddress;
                cmd.Parameters.Add("@SessionId", SqlDbType.NVarChar).Value = sessionId;
                cmd.Parameters.Add("@ServerIP", SqlDbType.NVarChar).Value = serverIP;
                cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@Result"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to logout", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Logout
        /// Calls [usp_logout_Login]
        /// </summary>
        public override void Logout(System.Int32? loginId, System.String sessionName)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_logout_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cmd.Parameters.Add("@SessionName", SqlDbType.NVarChar).Value = sessionName;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to logout", sqlex);
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
        /// Calls [usp_select_Login]
        /// </summary>
        public override LoginDetails Get(System.Int32? loginId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetLoginFromReader(reader);
                    LoginDetails obj = new LoginDetails();
                    obj.LoginId = GetReaderValue_Int32(reader, "LoginId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.LoginName = GetReaderValue_String(reader, "LoginName", "");
                    obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.FirstName = GetReaderValue_String(reader, "FirstName", "");
                    obj.LastName = GetReaderValue_String(reader, "LastName", "");
                    obj.AddressNo = GetReaderValue_NullableInt32(reader, "AddressNo", null);
                    obj.Title = GetReaderValue_String(reader, "Title", "");
                    obj.Extension = GetReaderValue_String(reader, "Extension", "");
                    obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
                    obj.Fax = GetReaderValue_String(reader, "Fax", "");
                    obj.EMail = GetReaderValue_String(reader, "EMail", "");
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.HomeTelephone = GetReaderValue_String(reader, "HomeTelephone", "");
                    obj.HomeFax = GetReaderValue_String(reader, "HomeFax", "");
                    obj.HomeEmail = GetReaderValue_String(reader, "HomeEmail", "");
                    obj.Mobile = GetReaderValue_String(reader, "Mobile", "");
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.Salutation = GetReaderValue_String(reader, "Salutation", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.KeyLogin = GetReaderValue_Boolean(reader, "KeyLogin", false);
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.TeamName = GetReaderValue_String(reader, "TeamName", "");
                    obj.PrinterNo = GetReaderValue_NullableInt32(reader, "PrinterNo", null);
                    obj.PrinterName = GetReaderValue_String(reader, "PrinterName", "");
                    obj.LabelPathNo = GetReaderValue_NullableInt32(reader, "LabelPathNo", null);
                    obj.LabelPath = GetReaderValue_String(reader, "LabelFullPath", "");
                    obj.ADLogin = GetReaderValue_String(reader, "ADLogin", "");
                    obj.GroupAccess = GetReaderValue_Boolean(reader, "GroupAccess", false);
                    //obj.IsPOHub = GetReaderValue_Boolean(reader, "IsPOHub", false);
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
                throw new Exception("Failed to get Login", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetByName 
        /// Calls [usp_select_Login_by_Name]
        /// </summary>
		public override LoginDetails GetByName(System.String loginName) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Login_by_Name", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginName", SqlDbType.NVarChar).Value = loginName;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetLoginFromReader(reader);
					LoginDetails obj = new LoginDetails();
					obj.LoginId = GetReaderValue_Int32(reader, "LoginId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.LoginName = GetReaderValue_String(reader, "LoginName", "");
					obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
					obj.FirstName = GetReaderValue_String(reader, "FirstName", "");
					obj.LastName = GetReaderValue_String(reader, "LastName", "");
					obj.AddressNo = GetReaderValue_NullableInt32(reader, "AddressNo", null);
					obj.Title = GetReaderValue_String(reader, "Title", "");
					obj.Extension = GetReaderValue_String(reader, "Extension", "");
					obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
					obj.Fax = GetReaderValue_String(reader, "Fax", "");
					obj.EMail = GetReaderValue_String(reader, "EMail", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.HomeTelephone = GetReaderValue_String(reader, "HomeTelephone", "");
					obj.HomeFax = GetReaderValue_String(reader, "HomeFax", "");
					obj.HomeEmail = GetReaderValue_String(reader, "HomeEmail", "");
					obj.Mobile = GetReaderValue_String(reader, "Mobile", "");
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.Salutation = GetReaderValue_String(reader, "Salutation", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.KeyLogin = GetReaderValue_Boolean(reader, "KeyLogin", false);
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.TeamName = GetReaderValue_String(reader, "TeamName", "");
					obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
					obj.ClientCurrencyNo = GetReaderValue_NullableInt32(reader, "ClientCurrencyNo", null);
					obj.ClientCurrencyCode = GetReaderValue_String(reader, "ClientCurrencyCode", "");
                    obj.ClientLocalCurrencyCode = GetReaderValue_String(reader, "ClientLocalCurrencyCode", "");
                    obj.ClientCode = GetReaderValue_String(reader, "ClientCode", "");
                    obj.ADLogin = GetReaderValue_String(reader, "ADLogin", "");
                    obj.IsPOHub = GetReaderValue_Boolean(reader, "IsPOHub", false);
                    obj.POHubMailGroupId = GetReaderValue_NullableInt32(reader, "SecurityGroupId", null);
                    obj.IsGlobalUser = GetReaderValue_Boolean(reader, "IsGlobal", false);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Login", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForRebound 
        /// Calls [usp_select_Login_for_Boris]
        /// </summary>
        public override LoginDetails GetForBoris(System.Int32? clientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Login_for_Boris", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = clientId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetLoginFromReader(reader);
                    LoginDetails obj = new LoginDetails();
                    obj.LoginId = GetReaderValue_Int32(reader, "LoginId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.FirstName = GetReaderValue_String(reader, "FirstName", "");
                    obj.LastName = GetReaderValue_String(reader, "LastName", "");
                    obj.EMail = GetReaderValue_String(reader, "EMail", "");
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.TeamName = GetReaderValue_String(reader, "TeamName", "");
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.ClientCurrencyNo = GetReaderValue_NullableInt32(reader, "ClientCurrencyNo", null);
                    obj.ClientCurrencyCode = GetReaderValue_String(reader, "ClientCurrencyCode", "");
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
                throw new Exception("Failed to get Login", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetLastMonthGP 
        /// Calls [usp_select_Login_LastMonth_GP]
        /// </summary>
        public override LoginDetails GetLastMonthGP(System.Int32? loginId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Login_LastMonth_GP", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetLoginFromReader(reader);
                    LoginDetails obj = new LoginDetails();
                    obj.OpenShippingCost = GetReaderValue_Double(reader, "OpenShippingCost", 0);
                    obj.OpenFreightCharge = GetReaderValue_Double(reader, "OpenFreightCharge", 0);
                    obj.OpenLandedCost = GetReaderValue_Double(reader, "OpenLandedCost", 0);
                    obj.OpenSalesValue = GetReaderValue_Double(reader, "OpenSalesValue", 0);
                    obj.ShippedShippingCost = GetReaderValue_Double(reader, "ShippedShippingCost", 0);
                    obj.ShippedFreightCharge = GetReaderValue_Double(reader, "ShippedFreightCharge", 0);
                    obj.ShippedLandedCost = GetReaderValue_Double(reader, "ShippedLandedCost", 0);
                    obj.ShippedSalesValue = GetReaderValue_Double(reader, "ShippedSalesValue", 0);
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
                throw new Exception("Failed to get Login", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetLastYearGP 
        /// Calls [usp_select_Login_LastYear_GP]
        /// </summary>
        public override LoginDetails GetLastYearGP(System.Int32? loginId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Login_LastYear_GP", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetLoginFromReader(reader);
                    LoginDetails obj = new LoginDetails();
                    obj.OpenShippingCost = GetReaderValue_Double(reader, "OpenShippingCost", 0);
                    obj.OpenFreightCharge = GetReaderValue_Double(reader, "OpenFreightCharge", 0);
                    obj.OpenLandedCost = GetReaderValue_Double(reader, "OpenLandedCost", 0);
                    obj.OpenSalesValue = GetReaderValue_Double(reader, "OpenSalesValue", 0);
                    obj.ShippedShippingCost = GetReaderValue_Double(reader, "ShippedShippingCost", 0);
                    obj.ShippedFreightCharge = GetReaderValue_Double(reader, "ShippedFreightCharge", 0);
                    obj.ShippedLandedCost = GetReaderValue_Double(reader, "ShippedLandedCost", 0);
                    obj.ShippedSalesValue = GetReaderValue_Double(reader, "ShippedSalesValue", 0);
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
                throw new Exception("Failed to get Login", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetName 
        /// Calls [usp_select_Login_Name]
        /// </summary>
        public override LoginDetails GetName(System.Int32? loginId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Login_Name", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetLoginFromReader(reader);
                    LoginDetails obj = new LoginDetails();
                    obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
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
                throw new Exception("Failed to get Login", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetNextMonthGP 
        /// Calls [usp_select_Login_NextMonth_GP]
        /// </summary>
        public override LoginDetails GetNextMonthGP(System.Int32? loginId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Login_NextMonth_GP", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetLoginFromReader(reader);
                    LoginDetails obj = new LoginDetails();
                    obj.OpenShippingCost = GetReaderValue_Double(reader, "OpenShippingCost", 0);
                    obj.OpenFreightCharge = GetReaderValue_Double(reader, "OpenFreightCharge", 0);
                    obj.OpenLandedCost = GetReaderValue_Double(reader, "OpenLandedCost", 0);
                    obj.OpenSalesValue = GetReaderValue_Double(reader, "OpenSalesValue", 0);
                    obj.ShippedShippingCost = GetReaderValue_Double(reader, "ShippedShippingCost", 0);
                    obj.ShippedFreightCharge = GetReaderValue_Double(reader, "ShippedFreightCharge", 0);
                    obj.ShippedLandedCost = GetReaderValue_Double(reader, "ShippedLandedCost", 0);
                    obj.ShippedSalesValue = GetReaderValue_Double(reader, "ShippedSalesValue", 0);
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
                throw new Exception("Failed to get Login", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetThisMonthGP 
        /// Calls [usp_select_Login_ThisMonth_GP]
        /// </summary>
        public override LoginDetails GetThisMonthGP(System.Int32? loginId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Login_ThisMonth_GP", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetLoginFromReader(reader);
                    LoginDetails obj = new LoginDetails();
                    obj.OpenShippingCost = GetReaderValue_Double(reader, "OpenShippingCost", 0);
                    obj.OpenFreightCharge = GetReaderValue_Double(reader, "OpenFreightCharge", 0);
                    obj.OpenLandedCost = GetReaderValue_Double(reader, "OpenLandedCost", 0);
                    obj.OpenSalesValue = GetReaderValue_Double(reader, "OpenSalesValue", 0);
                    obj.ShippedShippingCost = GetReaderValue_Double(reader, "ShippedShippingCost", 0);
                    obj.ShippedFreightCharge = GetReaderValue_Double(reader, "ShippedFreightCharge", 0);
                    obj.ShippedLandedCost = GetReaderValue_Double(reader, "ShippedLandedCost", 0);
                    obj.ShippedSalesValue = GetReaderValue_Double(reader, "ShippedSalesValue", 0);
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
                throw new Exception("Failed to get Login", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetThisYearGP 
        /// Calls [usp_select_Login_ThisYear_GP]
        /// </summary>
        public override LoginDetails GetThisYearGP(System.Int32? loginId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Login_ThisYear_GP", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetLoginFromReader(reader);
                    LoginDetails obj = new LoginDetails();
                    obj.OpenShippingCost = GetReaderValue_Double(reader, "OpenShippingCost", 0);
                    obj.OpenFreightCharge = GetReaderValue_Double(reader, "OpenFreightCharge", 0);
                    obj.OpenLandedCost = GetReaderValue_Double(reader, "OpenLandedCost", 0);
                    obj.OpenSalesValue = GetReaderValue_Double(reader, "OpenSalesValue", 0);
                    obj.ShippedShippingCost = GetReaderValue_Double(reader, "ShippedShippingCost", 0);
                    obj.ShippedFreightCharge = GetReaderValue_Double(reader, "ShippedFreightCharge", 0);
                    obj.ShippedLandedCost = GetReaderValue_Double(reader, "ShippedLandedCost", 0);
                    obj.ShippedSalesValue = GetReaderValue_Double(reader, "ShippedSalesValue", 0);
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
                throw new Exception("Failed to get Login", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListForClient 
        /// Calls [usp_selectAll_Login_for_Client]
        /// </summary>
        public override List<LoginDetails> GetListForClient(System.Int32? clientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_Login_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<LoginDetails> lst = new List<LoginDetails>();
                while (reader.Read())
                {
                    LoginDetails obj = new LoginDetails();
                    obj.LoginId = GetReaderValue_Int32(reader, "LoginId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.LoginName = GetReaderValue_String(reader, "LoginName", "");
                    obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.FirstName = GetReaderValue_String(reader, "FirstName", "");
                    obj.LastName = GetReaderValue_String(reader, "LastName", "");
                    obj.AddressNo = GetReaderValue_NullableInt32(reader, "AddressNo", null);
                    obj.Title = GetReaderValue_String(reader, "Title", "");
                    obj.Extension = GetReaderValue_String(reader, "Extension", "");
                    obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
                    obj.Fax = GetReaderValue_String(reader, "Fax", "");
                    obj.EMail = GetReaderValue_String(reader, "EMail", "");
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.HomeTelephone = GetReaderValue_String(reader, "HomeTelephone", "");
                    obj.HomeFax = GetReaderValue_String(reader, "HomeFax", "");
                    obj.HomeEmail = GetReaderValue_String(reader, "HomeEmail", "");
                    obj.Mobile = GetReaderValue_String(reader, "Mobile", "");
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.Salutation = GetReaderValue_String(reader, "Salutation", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.KeyLogin = GetReaderValue_Boolean(reader, "KeyLogin", false);
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.TeamName = GetReaderValue_String(reader, "TeamName", "");
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.ClientCurrencyNo = GetReaderValue_NullableInt32(reader, "ClientCurrencyNo", null);
                    obj.ClientCurrencyCode = GetReaderValue_String(reader, "ClientCurrencyCode", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Logins", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListForClientIncludingDisabled 
        /// Calls [usp_selectAll_Login_for_Client_including_Disabled]
        /// </summary>
        public override List<LoginDetails> GetListForClientIncludingDisabled(System.Int32? clientNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_Login_for_Client_including_Disabled", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<LoginDetails> lst = new List<LoginDetails>();
                while (reader.Read())
                {
                    LoginDetails obj = new LoginDetails();
                    obj.LoginId = GetReaderValue_Int32(reader, "LoginId", 0);
                    obj.LoginName = GetReaderValue_String(reader, "LoginName", "");
                    obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.TeamName = GetReaderValue_String(reader, "TeamName", "");
                    obj.Administrator = GetReaderValue_NullableBoolean(reader, "Administrator", null);
                    obj.NumberOfSalesAccounts = GetReaderValue_NullableInt32(reader, "NumberOfSalesAccounts", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Logins", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListForDivision 
        /// Calls [usp_selectAll_Login_for_Division]
        /// </summary>
        public override List<LoginDetails> GetListForDivision(System.Int32? divisionId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_Login_for_Division", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = divisionId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<LoginDetails> lst = new List<LoginDetails>();
                while (reader.Read())
                {
                    LoginDetails obj = new LoginDetails();
                    obj.LoginId = GetReaderValue_Int32(reader, "LoginId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.LoginName = GetReaderValue_String(reader, "LoginName", "");
                    obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.FirstName = GetReaderValue_String(reader, "FirstName", "");
                    obj.LastName = GetReaderValue_String(reader, "LastName", "");
                    obj.AddressNo = GetReaderValue_NullableInt32(reader, "AddressNo", null);
                    obj.Title = GetReaderValue_String(reader, "Title", "");
                    obj.Extension = GetReaderValue_String(reader, "Extension", "");
                    obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
                    obj.Fax = GetReaderValue_String(reader, "Fax", "");
                    obj.EMail = GetReaderValue_String(reader, "EMail", "");
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.HomeTelephone = GetReaderValue_String(reader, "HomeTelephone", "");
                    obj.HomeFax = GetReaderValue_String(reader, "HomeFax", "");
                    obj.HomeEmail = GetReaderValue_String(reader, "HomeEmail", "");
                    obj.Mobile = GetReaderValue_String(reader, "Mobile", "");
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.Salutation = GetReaderValue_String(reader, "Salutation", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.KeyLogin = GetReaderValue_Boolean(reader, "KeyLogin", false);
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.TeamName = GetReaderValue_String(reader, "TeamName", "");
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.ClientCurrencyNo = GetReaderValue_NullableInt32(reader, "ClientCurrencyNo", null);
                    obj.ClientCurrencyCode = GetReaderValue_String(reader, "ClientCurrencyCode", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Logins", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListForTeam 
        /// Calls [usp_selectAll_Login_for_Team]
        /// </summary>
        public override List<LoginDetails> GetListForTeam(System.Int32? teamId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_Login_for_Team", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@TeamId", SqlDbType.Int).Value = teamId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<LoginDetails> lst = new List<LoginDetails>();
                while (reader.Read())
                {
                    LoginDetails obj = new LoginDetails();
                    obj.LoginId = GetReaderValue_Int32(reader, "LoginId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.LoginName = GetReaderValue_String(reader, "LoginName", "");
                    obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.FirstName = GetReaderValue_String(reader, "FirstName", "");
                    obj.LastName = GetReaderValue_String(reader, "LastName", "");
                    obj.AddressNo = GetReaderValue_NullableInt32(reader, "AddressNo", null);
                    obj.Title = GetReaderValue_String(reader, "Title", "");
                    obj.Extension = GetReaderValue_String(reader, "Extension", "");
                    obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
                    obj.Fax = GetReaderValue_String(reader, "Fax", "");
                    obj.EMail = GetReaderValue_String(reader, "EMail", "");
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.HomeTelephone = GetReaderValue_String(reader, "HomeTelephone", "");
                    obj.HomeFax = GetReaderValue_String(reader, "HomeFax", "");
                    obj.HomeEmail = GetReaderValue_String(reader, "HomeEmail", "");
                    obj.Mobile = GetReaderValue_String(reader, "Mobile", "");
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.Salutation = GetReaderValue_String(reader, "Salutation", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.KeyLogin = GetReaderValue_Boolean(reader, "KeyLogin", false);
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.TeamName = GetReaderValue_String(reader, "TeamName", "");
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.ClientCurrencyNo = GetReaderValue_NullableInt32(reader, "ClientCurrencyNo", null);
                    obj.ClientCurrencyCode = GetReaderValue_String(reader, "ClientCurrencyCode", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Logins", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListTopSalespersons 
        /// Calls [usp_selectAll_Login_Top_Salespersons]
        /// </summary>
        public override List<LoginDetails> GetListTopSalespersons(System.Int32? clientNo, System.Int32? topToSelect)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_Login_Top_Salespersons", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<LoginDetails> lst = new List<LoginDetails>();
                while (reader.Read())
                {
                    LoginDetails obj = new LoginDetails();
                    obj.LoginId = GetReaderValue_Int32(reader, "LoginId", 0);
                    obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.Cost = GetReaderValue_NullableDouble(reader, "Cost", null);
                    obj.Resale = GetReaderValue_NullableDouble(reader, "Resale", null);
                    obj.GrossProfit = GetReaderValue_NullableDouble(reader, "GrossProfit", null);
                    obj.Margin = GetReaderValue_NullableDouble(reader, "Margin", null);
                    obj.NoOfOrders = GetReaderValue_NullableInt32(reader, "NoOfOrders", null);
                    obj.NoOfCredits = GetReaderValue_NullableInt32(reader, "NoOfCredits", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Logins", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update Login
        /// Calls [usp_update_Login]
        /// </summary>
        public override bool Update(System.Int32? loginId, System.Int32? clientNo, System.String loginName, System.String employeeName, System.String firstName, System.String lastName, System.Int32? addressNo, System.String title, System.String extension, System.String telephone, System.String fax, System.String email, System.String notes, System.String homeTelephone, System.String homeFax, System.String homeEmail, System.String mobile, System.Int32? divisionNo, System.Int32? teamNo, System.String salutation, System.Boolean? inactive, System.Boolean? keyLogin, System.Int32? updatedBy, System.Int32? printerNo, System.Int32? labelPathNo, System.String adLogin, System.Boolean? groupAccess)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@LoginName", SqlDbType.NVarChar).Value = loginName;
                cmd.Parameters.Add("@EmployeeName", SqlDbType.NVarChar).Value = employeeName;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastName;
                cmd.Parameters.Add("@AddressNo", SqlDbType.Int).Value = addressNo;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = title;
                cmd.Parameters.Add("@Extension", SqlDbType.NVarChar).Value = extension;
                cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = telephone;
                cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = fax;
                cmd.Parameters.Add("@EMail", SqlDbType.NVarChar).Value = email;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@HomeTelephone", SqlDbType.NVarChar).Value = homeTelephone;
                cmd.Parameters.Add("@HomeFax", SqlDbType.NVarChar).Value = homeFax;
                cmd.Parameters.Add("@HomeEmail", SqlDbType.NVarChar).Value = homeEmail;
                cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = mobile;
                cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
                cmd.Parameters.Add("@TeamNo", SqlDbType.Int).Value = teamNo;
                cmd.Parameters.Add("@Salutation", SqlDbType.NVarChar).Value = salutation;
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
                cmd.Parameters.Add("@KeyLogin", SqlDbType.Bit).Value = keyLogin;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@PrinterNo", SqlDbType.Int).Value = printerNo;
                cmd.Parameters.Add("@LabelPathNo", SqlDbType.Int).Value = labelPathNo;
                cmd.Parameters.Add("@ADLogin", SqlDbType.VarChar).Value = adLogin;
                cmd.Parameters.Add("@GroupAccess", SqlDbType.Bit).Value = groupAccess;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Login", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update Login
        /// Calls [usp_update_Login_Division]
        /// </summary>
        public override bool UpdateDivision(System.Int32? loginId, System.Int32? divisionNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Login_Division", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Login", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update Login
        /// Calls [usp_update_Login_Inactive]
        /// </summary>
        public override bool UpdateInactive(System.Int32? loginId, System.Boolean? inactive)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Login_Inactive", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Login", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update Login
        /// Calls [usp_update_Login_Password]
        /// </summary>
        public override bool UpdatePassword(System.Int32? loginId, System.String oldPassword, System.String newPassword, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Login_Password", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cmd.Parameters.Add("@OldPassword", SqlDbType.NVarChar).Value = oldPassword;
                cmd.Parameters.Add("@NewPassword", SqlDbType.NVarChar).Value = newPassword;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Login", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update Login
        /// Calls [usp_update_Login_ResetPassword]
        /// </summary>
        public override bool UpdateResetPassword(System.Int32? loginId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Login_ResetPassword", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Login", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update Login
        /// Calls [usp_update_Login_Team]
        /// </summary>
        public override bool UpdateTeam(System.Int32? loginId, System.Int32? teamNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Login_Team", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cmd.Parameters.Add("@TeamNo", SqlDbType.Int).Value = teamNo;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Login", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Login
        /// Calls [usp_login_Login]
        /// </summary>
        public override Int32 ForgotPassword(System.String loginName, out System.String password, out System.String email)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_get_password", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LoginName", SqlDbType.NVarChar).Value = loginName;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@EMail", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                password = (cmd.Parameters["@Password"].Value != DBNull.Value) ? (string)cmd.Parameters["@Password"].Value : "";
                email = (cmd.Parameters["@EMail"].Value != DBNull.Value) ? (string)cmd.Parameters["@EMail"].Value : "";
                return (int)cmd.Parameters["@Result"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to logout", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public override List<LoginDetails> ForgotUserName(System.Int32? clientNo, System.String email)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_get_password_by_Email_client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@LoginEmail", SqlDbType.NVarChar).Value = email;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<LoginDetails> lst = new List<LoginDetails>();
                while (reader.Read())
                {
                    LoginDetails obj = new LoginDetails();
                    obj.LoginName = GetReaderValue_String(reader, "LoginName", "");
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.LastName = GetReaderValue_String(reader, "employeepassword", "");
                    obj.EMail = GetReaderValue_String(reader, "EMail", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Logins", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// DropDownForPurchaseHub
        /// Calls [usp_dropdown_Login_for_PurchaseHubClient]
        /// </summary>
        public override List<LoginDetails> DropDownForPurchaseHub(System.Int32? clientNo, System.Int32? teamNo, System.Int32? divisionNo, System.Int32? excludeLoginNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdown_Login_for_PurchaseHubClient", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@TeamNo", SqlDbType.Int).Value = teamNo;
                cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
                cmd.Parameters.Add("@ExcludeLoginNo", SqlDbType.Int).Value = excludeLoginNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<LoginDetails> lst = new List<LoginDetails>();
                while (reader.Read())
                {
                    LoginDetails obj = new LoginDetails();
                    obj.LoginId = GetReaderValue_Int32(reader, "LoginId", 0);
                    obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Logins", sqlex);
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
