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
    public class SqlTabSecurityFunctionProvider : TabSecurityFunctionProvider
    {
        /// <summary>
        ///  
        /// Calls [usp_selectAll_TabSecurityFunction_General_Permissions_by_SecurityGroup]
        /// </summary>
        public override List<TabSecurityFunctionDetails> GetListGeneralPermissionsByTabSecurityGroup(System.Int32? securityGroupId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_TabSecurityFunction_General_Permissions_by_SecurityGroup", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SecurityGroupId", SqlDbType.Int).Value = securityGroupId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<TabSecurityFunctionDetails> lst = new List<TabSecurityFunctionDetails>();
                while (reader.Read())
                {
                    TabSecurityFunctionDetails obj = new TabSecurityFunctionDetails();
                    obj.TabSecurityFunctionId = GetReaderValue_Int32(reader, "TabSecurityFunctionId", 0);
                    obj.TabFunctionName = GetReaderValue_String(reader, "TabFunctionName", "");
                    obj.MyTab = GetReaderValue_NullableBoolean(reader, "MyTab", false);
                    obj.TeamTab = GetReaderValue_NullableBoolean(reader, "TeamTab", false);
                    obj.DivisionTab = GetReaderValue_NullableBoolean(reader, "DivisionTab", false);
                    obj.CompanyTab = GetReaderValue_NullableBoolean(reader, "CompanyTab", false);
                    obj.SiteSectionName = GetReaderValue_String(reader, "SiteSectionName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Tab security", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// GetByGroupAndFunction 
        /// Calls [usp_select_TabSecurityGroupSecurityFunctionPermission_by_Group_and_Function]
        /// </summary>
        public override TabSecurityFunctionDetails GetByGroupAndFunction(System.Int32? securityGroupNo, System.Int32? tabSecurityFunctionNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_TabSecurityGroupSecurityFunctionPermission_by_Group_and_Function", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SecurityGroupNo", SqlDbType.Int).Value = securityGroupNo;
                cmd.Parameters.Add("@TabSecurityFunctionNo", SqlDbType.Int).Value = tabSecurityFunctionNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSecurityGroupSecurityFunctionPermissionFromReader(reader);
                    TabSecurityFunctionDetails obj = new TabSecurityFunctionDetails();
                    obj.TabSecurityGroupSecurityFunctionPermissionId = GetReaderValue_Int32(reader, "TabSecurityGroupSecurityFunctionPermissionId", 0);
                    obj.SecurityGroupNo = GetReaderValue_Int32(reader, "SecurityGroupNo", 0);
                    obj.TabSecurityFunctionId = GetReaderValue_Int32(reader, "TabSecurityFunctionNo", 0);
                    obj.MyTab = GetReaderValue_Boolean(reader, "MyTab", false);
                    obj.TeamTab = GetReaderValue_Boolean(reader, "TeamTab", false);
                    obj.DivisionTab = GetReaderValue_Boolean(reader, "DivisionTab", false);
                    obj.CompanyTab = GetReaderValue_Boolean(reader, "CompanyTab", false);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
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
                throw new Exception("Failed to get TabSecurityGroupSecurityFunctionPermission", sqlex);
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
        /// Calls [usp_insert_TabSecurityGroupSecurityFunctionPermission]
        /// </summary>
        public override Int32 Insert(System.Int32? securityGroupNo, System.Int32? tabSecurityFunctionId, System.Boolean? myTab, System.Boolean? teamTab, System.Boolean? divisionTab, System.Boolean? companyTab, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_TabSecurityGroupSecurityFunctionPermission", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SecurityGroupNo", SqlDbType.Int).Value = securityGroupNo;
                cmd.Parameters.Add("@TabSecurityFunctionNo", SqlDbType.Int).Value = tabSecurityFunctionId;
                cmd.Parameters.Add("@MyTab", SqlDbType.Bit).Value = myTab;
                cmd.Parameters.Add("@TeamTab", SqlDbType.Bit).Value = teamTab;
                cmd.Parameters.Add("@DivisionTab", SqlDbType.Bit).Value = divisionTab;
                cmd.Parameters.Add("@CompanyTab", SqlDbType.Bit).Value = companyTab;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@NewId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert TabSecurityGroupSecurityFunctionPermission", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Update tbTabSecurityGroupSecurityFunctionPermission
        /// Calls [usp_update_TabSecurityGroupSecurityFunctionPermission]
        /// </summary>
        public override bool Update(System.Int32? tabSecurityGroupSecurityFunctionPermissionId, System.Int32? securityGroupNo, System.Int32? tabSecurityFunctionNo, System.Boolean? myTab, System.Boolean? teamTab, System.Boolean? divisionTab, System.Boolean? companyTab, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_TabSecurityGroupSecurityFunctionPermission", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TabSecurityGroupSecurityFunctionPermissionId", SqlDbType.Int).Value = tabSecurityGroupSecurityFunctionPermissionId;
                cmd.Parameters.Add("@SecurityGroupNo", SqlDbType.Int).Value = securityGroupNo;
                cmd.Parameters.Add("@TabSecurityFunctionNo", SqlDbType.Int).Value = tabSecurityFunctionNo;
                cmd.Parameters.Add("@MyTab", SqlDbType.Bit).Value = myTab;
                cmd.Parameters.Add("@TeamTab", SqlDbType.Bit).Value = teamTab;
                cmd.Parameters.Add("@DivisionTab", SqlDbType.Bit).Value = divisionTab;
                cmd.Parameters.Add("@CompanyTab", SqlDbType.Bit).Value = companyTab;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update TabSecurityGroupSecurityFunctionPermission", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// GetByGroupAndFunction 
        /// Calls [usp_select_TabSecurityFunction_Permission_by_Login]
        /// </summary>
        public override TabSecurityFunctionDetails GetInvisibleTabSecurityList(System.Int32? pageId, System.Int32? loginId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_TabSecurityFunction_Permission_by_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@TabSecurityFunctionNo", SqlDbType.Int).Value = pageId;
                cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    TabSecurityFunctionDetails obj = new TabSecurityFunctionDetails();
                    obj.MyTab = GetReaderValue_Boolean(reader, "MyTab", false);
                    obj.TeamTab = GetReaderValue_Boolean(reader, "TeamTab", false);
                    obj.DivisionTab = GetReaderValue_Boolean(reader, "DivisionTab", false);
                    obj.CompanyTab = GetReaderValue_Boolean(reader, "CompanyTab", false);
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
                throw new Exception("Failed to get GetInvisibleTabSecurityList", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
       
        /// <summary>
        /// [usp_select_TabSecurityFunction_CompanyPermission_by_Login]
        /// </summary>
        /// <param name="pageId1"></param>
        /// <param name="pageId2"></param>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public override TabSecurityFunctionDetails GetVisibleCompanyTabSecurityList(System.Int32? pageId1, System.Int32? pageId2, System.Int32? loginId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_TabSecurityFunction_CompanyPermission_by_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@TabSecurityFunctionNoSupplier", SqlDbType.Int).Value = pageId1;
                cmd.Parameters.Add("@TabSecurityFunctionNoCustomer", SqlDbType.Int).Value = pageId2;
                cmd.Parameters.Add("@LoginNo", SqlDbType.Int).Value = loginId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    TabSecurityFunctionDetails obj = new TabSecurityFunctionDetails();
                    obj.MyTab = GetReaderValue_Boolean(reader, "MyTab", false);
                    obj.TeamTab = GetReaderValue_Boolean(reader, "TeamTab", false);
                    obj.DivisionTab = GetReaderValue_Boolean(reader, "DivisionTab", false);
                    obj.CompanyTab = GetReaderValue_Boolean(reader, "CompanyTab", false);
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
                throw new Exception("Failed to get GetInvisibleTabSecurityList", sqlex);
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
