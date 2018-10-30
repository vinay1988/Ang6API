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
    public class SqlSecurityFunctionProvider : SecurityFunctionProvider
    {
        /// <summary>
        /// Get 
        /// Calls [usp_select_SecurityFunction]
        /// </summary>
        public override SecurityFunctionDetails Get(System.Int32? securityFunctionNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SecurityFunction", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SecurityFunctionNo", SqlDbType.Int).Value = securityFunctionNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSecurityFunctionFromReader(reader);
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.FunctionName = GetReaderValue_String(reader, "FunctionName", "");
                    obj.Description = GetReaderValue_String(reader, "Description", "");
                    obj.SitePageNo = GetReaderValue_NullableInt32(reader, "SitePageNo", null);
                    obj.SiteSectionNo = GetReaderValue_NullableInt32(reader, "SiteSectionNo", null);
                    obj.ReportNo = GetReaderValue_NullableInt32(reader, "ReportNo", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.InitiallyProhibitedForNewLogins = GetReaderValue_Boolean(reader, "InitiallyProhibitedForNewLogins", false);
                    obj.DisplaySortOrder = GetReaderValue_NullableInt32(reader, "DisplaySortOrder", null);
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
                throw new Exception("Failed to get SecurityFunction", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetBySitePage 
        /// Calls [usp_select_SecurityFunction_by_SitePage]
        /// </summary>
        public override SecurityFunctionDetails GetBySitePage(System.Int32? sitePageNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SecurityFunction_by_SitePage", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SitePageNo", SqlDbType.Int).Value = sitePageNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSecurityFunctionFromReader(reader);
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.FunctionName = GetReaderValue_String(reader, "FunctionName", "");
                    obj.Description = GetReaderValue_String(reader, "Description", "");
                    obj.SitePageNo = GetReaderValue_NullableInt32(reader, "SitePageNo", null);
                    obj.SiteSectionNo = GetReaderValue_NullableInt32(reader, "SiteSectionNo", null);
                    obj.ReportNo = GetReaderValue_NullableInt32(reader, "ReportNo", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.InitiallyProhibitedForNewLogins = GetReaderValue_Boolean(reader, "InitiallyProhibitedForNewLogins", false);
                    obj.DisplaySortOrder = GetReaderValue_NullableInt32(reader, "DisplaySortOrder", null);
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
                throw new Exception("Failed to get SecurityFunction", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetPermissionByLogin 
        /// Calls [usp_select_SecurityFunction_Permission_by_Login]
        /// </summary>
        public override SecurityFunctionDetails GetPermissionByLogin(System.Int32? securityFunctionNo, System.Int32? loginNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SecurityFunction_Permission_by_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SecurityFunctionNo", SqlDbType.Int).Value = securityFunctionNo;
                cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSecurityFunctionFromReader(reader);
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllowed", null);
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
                throw new Exception("Failed to get SecurityFunction", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetReportPermissionForLogin 
        /// Calls [usp_select_SecurityFunction_Report_Permission_for_Login]
        /// </summary>
        public override SecurityFunctionDetails GetReportPermissionForLogin(System.Int32? loginNo, System.Int32? reportNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SecurityFunction_Report_Permission_for_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
                cmd.Parameters.Add("@ReportNo", SqlDbType.Int).Value = reportNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSecurityFunctionFromReader(reader);
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllowed", null);
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
                throw new Exception("Failed to get SecurityFunction", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetList 
        /// Calls [usp_selectAll_SecurityFunction]
        /// </summary>
        public override List<SecurityFunctionDetails> GetList()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.FunctionName = GetReaderValue_String(reader, "FunctionName", "");
                    obj.Description = GetReaderValue_String(reader, "Description", "");
                    obj.SitePageNo = GetReaderValue_NullableInt32(reader, "SitePageNo", null);
                    obj.SiteSectionNo = GetReaderValue_NullableInt32(reader, "SiteSectionNo", null);
                    obj.ReportNo = GetReaderValue_NullableInt32(reader, "ReportNo", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.InitiallyProhibitedForNewLogins = GetReaderValue_Boolean(reader, "InitiallyProhibitedForNewLogins", false);
                    obj.DisplaySortOrder = GetReaderValue_NullableInt32(reader, "DisplaySortOrder", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListBySitePage 
        /// Calls [usp_selectAll_SecurityFunction_by_SitePage]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListBySitePage(System.Int32? sitePageNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction_by_SitePage", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SitePageNo", SqlDbType.Int).Value = sitePageNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.FunctionName = GetReaderValue_String(reader, "FunctionName", "");
                    obj.SitePageNo = GetReaderValue_NullableInt32(reader, "SitePageNo", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListGeneral 
        /// Calls [usp_selectAll_SecurityFunction_General]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListGeneral()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction_General", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.FunctionName = GetReaderValue_String(reader, "FunctionName", "");
                    obj.Description = GetReaderValue_String(reader, "Description", "");
                    obj.SitePageNo = GetReaderValue_NullableInt32(reader, "SitePageNo", null);
                    obj.SiteSectionNo = GetReaderValue_NullableInt32(reader, "SiteSectionNo", null);
                    obj.ReportNo = GetReaderValue_NullableInt32(reader, "ReportNo", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.InitiallyProhibitedForNewLogins = GetReaderValue_Boolean(reader, "InitiallyProhibitedForNewLogins", false);
                    obj.DisplaySortOrder = GetReaderValue_NullableInt32(reader, "DisplaySortOrder", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListGeneralPermissionsByLogin 
        /// Calls [usp_selectAll_SecurityFunction_General_Permissions_by_Login]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListGeneralPermissionsByLogin(System.Int32? loginNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction_General_Permissions_by_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllowed", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListGeneralPermissionsBySecurityGroup 
        /// Calls [usp_selectAll_SecurityFunction_General_Permissions_by_SecurityGroup]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListGeneralPermissionsBySecurityGroup(System.Int32? securityGroupId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction_General_Permissions_by_SecurityGroup", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SecurityGroupId", SqlDbType.Int).Value = securityGroupId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllowed", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListPage 
        /// Calls [usp_selectAll_SecurityFunction_Page]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListPage()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction_Page", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.FunctionName = GetReaderValue_String(reader, "FunctionName", "");
                    obj.SitePageNo = GetReaderValue_NullableInt32(reader, "SitePageNo", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListPageBySiteSection 
        /// Calls [usp_selectAll_SecurityFunction_Page_by_SiteSection]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListPageBySiteSection(System.Int32? siteSectionNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction_Page_by_SiteSection", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SiteSectionNo", SqlDbType.Int).Value = siteSectionNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.FunctionName = GetReaderValue_String(reader, "FunctionName", "");
                    obj.SitePageNo = GetReaderValue_NullableInt32(reader, "SitePageNo", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListPagePermissionsByPage 
        /// Calls [usp_selectAll_SecurityFunction_Page_Permissions_by_Page]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListPagePermissionsByPage(System.Int32? pageId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction_Page_Permissions_by_Page", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@PageId", SqlDbType.Int).Value = pageId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllowed", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListPagePermissionsByPageAndLogin 
        /// Calls [usp_selectAll_SecurityFunction_Page_Permissions_by_Page_and_Login]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListPagePermissionsByPageAndLogin(System.Int32? sitePageNo, System.Int32? loginNo, System.Boolean? dataHasOtherClient)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand((!dataHasOtherClient.Value) ? "usp_selectAll_SecurityFunction_Page_Permissions_by_Page_and_Login" : "usp_selectAll_GlobalSecurityFunction_Page_Permissions_by_Page_and_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SitePageNo", SqlDbType.Int).Value = sitePageNo;
                cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllowed", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListPagePermissionsBySecurityGroup 
        /// Calls [usp_selectAll_SecurityFunction_Page_Permissions_by_SecurityGroup]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListPagePermissionsBySecurityGroup(System.Int32? securityGroupId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction_Page_Permissions_by_SecurityGroup", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SecurityGroupId", SqlDbType.Int).Value = securityGroupId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllowed", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListPagePermissionsBySecurityGroupAndPage 
        /// Calls [usp_selectAll_SecurityFunction_Page_Permissions_by_SecurityGroup_and_Page]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListPagePermissionsBySecurityGroupAndPage(System.Int32? securityGroupNo, System.Int32? pageId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction_Page_Permissions_by_SecurityGroup_and_Page", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SecurityGroupNo", SqlDbType.Int).Value = securityGroupNo;
                cmd.Parameters.Add("@PageId", SqlDbType.Int).Value = pageId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllowed", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListPermissionsByLoginAndReport 
        /// Calls [usp_selectAll_SecurityFunction_Permissions_by_Login_and_Report]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListPermissionsByLoginAndReport(System.Int32? loginNo, System.Int32? reportNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction_Permissions_by_Login_and_Report", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
                cmd.Parameters.Add("@ReportNo", SqlDbType.Int).Value = reportNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllowed", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListPermissionsByLoginAndSitePage 
        /// Calls [usp_selectAll_SecurityFunction_Permissions_by_Login_and_SitePage]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListPermissionsByLoginAndSitePage(System.Int32? loginNo, System.Int32? sitePageNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction_Permissions_by_Login_and_SitePage", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
                cmd.Parameters.Add("@SitePageNo", SqlDbType.Int).Value = sitePageNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllowed", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListPermissionsByLoginAndSiteSection 
        /// Calls [usp_selectAll_SecurityFunction_Permissions_by_Login_and_SiteSection]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListPermissionsByLoginAndSiteSection(System.Int32? loginNo, System.Int32? siteSectionNo, System.Boolean? isDataOtherClient)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand((!isDataOtherClient.Value) ? "usp_selectAll_SecurityFunction_Permissions_by_Login_and_SiteSection" : "usp_selectAll_SecurityFunction_GlobalPermissions_by_Login_and_SiteSection", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
                cmd.Parameters.Add("@SiteSectionNo", SqlDbType.Int).Value = siteSectionNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllowed", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListReport 
        /// Calls [usp_selectAll_SecurityFunction_Report]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListReport()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction_Report", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.FunctionName = GetReaderValue_String(reader, "FunctionName", "");
                    obj.ReportId = GetReaderValue_Int32(reader, "ReportId", 0);
                    obj.ReportName = GetReaderValue_String(reader, "ReportName", "");
                    obj.ReportCategoryName = GetReaderValue_String(reader, "ReportCategoryName", "");
                    obj.ReportCategoryGroupName = GetReaderValue_String(reader, "ReportCategoryGroupName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListReportPermissionsByLogin 
        /// Calls [usp_selectAll_SecurityFunction_Report_Permissions_by_Login]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListReportPermissionsByLogin(System.Int32? loginNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction_Report_Permissions_by_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllowed", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListReportPermissionsBySecurityGroup 
        /// Calls [usp_selectAll_SecurityFunction_Report_Permissions_by_SecurityGroup]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListReportPermissionsBySecurityGroup(System.Int32? securityGroupId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction_Report_Permissions_by_SecurityGroup", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SecurityGroupId", SqlDbType.Int).Value = securityGroupId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllowed", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListSection 
        /// Calls [usp_selectAll_SecurityFunction_Section]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListSection(System.Int32? sectionNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction_Section", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SectionNo", SqlDbType.Int).Value = sectionNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.FunctionName = GetReaderValue_String(reader, "FunctionName", "");
                    obj.SiteSectionNo = GetReaderValue_NullableInt32(reader, "SiteSectionNo", null);
                    obj.SiteSectionName = GetReaderValue_String(reader, "SiteSectionName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListSectionPermissionsByLogin 
        /// Calls [usp_selectAll_SecurityFunction_Section_Permissions_by_Login]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListSectionPermissionsByLogin(System.Int32? loginNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction_Section_Permissions_by_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllowed", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListSectionPermissionsBySecurityGroup 
        /// Calls [usp_selectAll_SecurityFunction_Section_Permissions_by_SecurityGroup]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListSectionPermissionsBySecurityGroup(System.Int32? securityGroupId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction_Section_Permissions_by_SecurityGroup", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SecurityGroupId", SqlDbType.Int).Value = securityGroupId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllowed", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

       
        /// <summary>
        /// CheckAdminPermissionsByLogin 
        /// Calls [usp_check_admin_Permissions_by_Login]
        /// </summary>
        public override SecurityFunctionDetails CheckAdminPermissionsByLogin(System.Int32? loginNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_check_admin_Permissions_by_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    // obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllow", false);
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
                throw new Exception("Failed to get SecurityFunction", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// GetListGeneralPermissionsByGlobalSecurityGroup 
        /// Calls [usp_selectAll_GlobalSecurityFunction_General_Permissions_by_SecurityGroup]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListGeneralPermissionsByGlobalSecurityGroup(System.Int32? securityGroupId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_GlobalSecurityFunction_General_Permissions_by_SecurityGroup", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SecurityGroupId", SqlDbType.Int).Value = securityGroupId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllowed", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// GetListSectionPermissionsByGlobalSecurityGroup 
        /// Calls [usp_selectAll_SecurityFunction_Section_Permissions_by_GlobalSecurityGroup]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListSectionPermissionsByGlobalSecurityGroup(System.Int32? securityGroupId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction_Section_Permissions_by_GlobalSecurityGroup", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SecurityGroupId", SqlDbType.Int).Value = securityGroupId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllowed", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// GetListPagePermissionsByGlobalSecurityGroupAndPage 
        /// Calls [usp_selectAll_SecurityFunction_Page_Permissions_by_GlobalSecurityGroup_and_Page]
        /// </summary>
        public override List<SecurityFunctionDetails> GetListPagePermissionsByGlobalSecurityGroupAndPage(System.Int32? securityGroupNo, System.Int32? pageId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SecurityFunction_Page_Permissions_by_GlobalSecurityGroup_and_Page", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SecurityGroupNo", SqlDbType.Int).Value = securityGroupNo;
                cmd.Parameters.Add("@PageId", SqlDbType.Int).Value = pageId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.IsAllowed = GetReaderValue_NullableBoolean(reader, "IsAllowed", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListBySitePage 
        /// Calls [usp_selectAll_GlobalSecurityFunction_by_SitePage]
        /// </summary>
        public override List<SecurityFunctionDetails> GetGlobalListBySitePage(System.Int32? sitePageNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_GlobalSecurityFunction_by_SitePage", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SitePageNo", SqlDbType.Int).Value = sitePageNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SecurityFunctionDetails> lst = new List<SecurityFunctionDetails>();
                while (reader.Read())
                {
                    SecurityFunctionDetails obj = new SecurityFunctionDetails();
                    obj.SecurityFunctionId = GetReaderValue_Int32(reader, "SecurityFunctionId", 0);
                    obj.FunctionName = GetReaderValue_String(reader, "FunctionName", "");
                    obj.SitePageNo = GetReaderValue_NullableInt32(reader, "SitePageNo", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SecurityFunctions", sqlex);
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