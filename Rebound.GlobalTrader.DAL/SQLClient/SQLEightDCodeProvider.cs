
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
    public class SqlEightDCodeProvider : EightDCodeProvider
    {

        /// <summary>
        /// Source 
        /// Calls [usp_source_Stock]
        /// </summary>
        public override List<EightDCodeDetails> GetListOfCategory()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                
                cn = new SqlConnection(this.ConnectionString);
                //cmd = new SqlCommand("USP_Select8DCategory", cn);
                cmd = new SqlCommand("USP_Select8DSubCat", cn);                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<EightDCodeDetails> lst = new List<EightDCodeDetails>();
                while (reader.Read())
                {
                    EightDCodeDetails obj = new EightDCodeDetails();
                    obj.Prefix = GetReaderValue_String(reader, "Prefix", "");
                    obj.PrefixDescription = GetReaderValue_String(reader, "CategoryName", "");
                    obj.CodeDescription = GetReaderValue_String(reader, "SubCategoryName", "");
                    obj.Code = GetReaderValue_String(reader, "code", "");
                    obj.Analysis8DSubCategoryID = GetReaderValue_Int32(reader,"SubCategoryID",0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get 8DCode Category", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Source 
        /// Calls [USP_Select8DSubCategory]
        /// </summary>
        public override List<EightDCodeDetails> GetListSubCategory(System.Int32? Id)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {

                cn = new SqlConnection(this.ConnectionString);
                //cmd = new SqlCommand("USP_Select8DCategory", cn);
                cmd = new SqlCommand("USP_Select8DSubCategory", cn);
                cmd.Parameters.Add("@prifix", SqlDbType.Int).Value = Id;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<EightDCodeDetails> lst = new List<EightDCodeDetails>();
                while (reader.Read())
                {
                    EightDCodeDetails obj = new EightDCodeDetails();
                    
                    obj.Code = GetReaderValue_String(reader, "Code", "");
                    obj.CodeDescription = GetReaderValue_String(reader, "CodeDescription", "");
                    obj.Analysis8DSubCategoryID = GetReaderValue_Int32(reader, "Analysis8DSubCategoryID", 0);
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", 0);   
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get 8DCode Category", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        
        /// <summary>
        /// Source 
        /// Calls [USP_Select8DCategory]
        /// </summary>
        public override List<EightDCodeDetails> SelectListCategory()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {

                cn = new SqlConnection(this.ConnectionString);
                //cmd = new SqlCommand("USP_Select8DCategory", cn);
                cmd = new SqlCommand("USP_Select8DCategory", cn);                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<EightDCodeDetails> lst = new List<EightDCodeDetails>();
                while (reader.Read())
                {
                    EightDCodeDetails obj = new EightDCodeDetails();
                    obj.Prefix = GetReaderValue_String(reader, "Prefix", "");
                    obj.PrefixDescription = GetReaderValue_String(reader, "PrefixDescription", "");
                    obj.Analysis8DCategoryID = GetReaderValue_Int32(reader, "Analysis8DCategoryID",0);
                    obj.Inactive = GetReaderValue_Boolean(reader,"incative",false);
                    obj.SortOrder = GetReaderValue_NullableInt32(reader, "SortOrder", 0);                        
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get 8DCode Category", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }



        /// <summary>
        /// Insert
        /// Calls [usp_insert_Analysis8DCategory]
        /// </summary>
        public override Int32 Insert(System.String prefix, System.String prefixDescription, System.Boolean? inactive, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_Analysis8DCategory", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Prefix", SqlDbType.NVarChar).Value = prefix;
                cmd.Parameters.Add("@PrefixDescription", SqlDbType.NVarChar).Value = prefixDescription;                
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@Analysis8DCategoryId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@Analysis8DCategoryId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Eigth D Category", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Insert
        /// Calls [usp_insert_Analysis8DSubCategory]
        /// </summary>
        public override Int32 Insert(System.Int32 prefixNo, System.String prefix, System.String prefixDescription, System.Boolean? inactive, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_Analysis8DSubCategory", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PrefixNo", SqlDbType.NVarChar).Value = prefixNo;
                cmd.Parameters.Add("@Prefix", SqlDbType.NVarChar).Value = prefix;
                cmd.Parameters.Add("@PrefixDescription", SqlDbType.NVarChar).Value = prefixDescription;                
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@Analysis8DSubCategoryId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@Analysis8DSubCategoryId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Eigth D Category", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Source 
        /// Calls [usp_select_Analysis8DCategory]
        /// </summary>
        public override EightDCodeDetails Get(System.Int32? Id)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {

                cn = new SqlConnection(this.ConnectionString);
                //cmd = new SqlCommand("USP_Select8DCategory", cn);
                cmd = new SqlCommand("usp_select_Analysis8DCategory", cn);
                cmd.Parameters.Add("@Analysis8DCategoryId", SqlDbType.Int).Value = Id;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cn.Open();
                //DbDataReader reader = ExecuteReader(cmd);
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())                {
                    EightDCodeDetails obj = new EightDCodeDetails();
                    obj.Analysis8DCategoryID = GetReaderValue_Int32(reader, "Analysis8DCategoryID", 0);
                    obj.Prefix = GetReaderValue_String(reader, "Prefix", "");
                    obj.PrefixDescription = GetReaderValue_String(reader, "PrefixDescription", "");
                    obj.SortOrder = GetReaderValue_Int32(reader, "SortedOrder", 0);
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);       
                
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
                throw new Exception("Failed to get 8DCode Category", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

         /// <summary>
        /// Source 
        /// Calls [usp_select_Analysis8DSubCategory]
        /// </summary>
        public override EightDCodeDetails GetSubCat(System.Int32? Id)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {

                cn = new SqlConnection(this.ConnectionString);
                //cmd = new SqlCommand("USP_Select8DCategory", cn);
                cmd = new SqlCommand("usp_select_Analysis8DSubCategory", cn);
                cmd.Parameters.Add("@Analysis8DSubCategoryId", SqlDbType.Int).Value = Id;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cn.Open();
                //DbDataReader reader = ExecuteReader(cmd);
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())                {
                    EightDCodeDetails obj = new EightDCodeDetails();
                    obj.Analysis8DSubCategoryID = GetReaderValue_Int32(reader, "Analysis8DSubCategoryID", 0);
                    obj.Code = GetReaderValue_String(reader, "Code", "");
                    obj.CodeDescription = GetReaderValue_String(reader, "CodeDescription", "");
                    obj.Analysis8DCategoryID = GetReaderValue_Int32(reader, "PrefixNo", 0);   
                    obj.SortOrder = GetReaderValue_Int32(reader, "SortedOrder", 0);
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);       
                
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
                throw new Exception("Failed to get 8D Sub-Category", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        
        /// <summary>
        /// Calls [usp_update_Analysis8DCategory]
        /// </summary>
        public override bool Update(System.Int32? analysis8DCategoryId, System.String prefix, System.String prefixDescription, System.Boolean? inactive, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Analysis8DCategory", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@analysis8DCategoryId", SqlDbType.Int).Value = analysis8DCategoryId;
                cmd.Parameters.Add("@prefix", SqlDbType.NVarChar).Value = prefix;
                cmd.Parameters.Add("@prefixDescription", SqlDbType.NVarChar).Value = prefixDescription;                
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Analysis of 8 D Category", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Calls [usp_update_Analysis8DSubCategory]
        /// </summary>
        public override bool Update(System.Int32 analysis8DSubCategoryId, System.Int32 prefixNo,System.String prefix, System.String prefixDescription, System.Boolean? inactive, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Analysis8DSubCategory", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@analysis8DSubCategoryId", SqlDbType.Int).Value = analysis8DSubCategoryId;
                cmd.Parameters.Add("@prefix", SqlDbType.NVarChar).Value = prefix;
                cmd.Parameters.Add("@prefixDescription", SqlDbType.NVarChar).Value = prefixDescription;
                cmd.Parameters.Add("@prefixNo", SqlDbType.NVarChar).Value = prefixNo;                
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Analysis of 8 D Sub Category", sqlex);
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
