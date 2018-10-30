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
    public class SqlCertificateCategoryProvider : CertificateCategoryProvider
    {
        /// <summary>
        /// Calls [usp_Get_All_CertificateCategory]
        /// </summary>
        /// <returns></returns>
        public override List<CertificateCategoryDetails> GetListCertificateCategory()
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_Get_All_CertificateCategory", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
                List<CertificateCategoryDetails> lst = new List<CertificateCategoryDetails>();
				while (reader.Read()) {
                    CertificateCategoryDetails obj = new CertificateCategoryDetails();
                    obj.CertificateCategoryId = GetReaderValue_Int32(reader, "CertificateCategoryId", 0);
                    obj.CertificateCategoryName = GetReaderValue_String(reader, "CertificateCategoryName", "");
                    obj.Description = GetReaderValue_String(reader, "Description", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", 0);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
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
        /// Insert
        /// Calls [usp_insert_CertificateCategory]
        /// </summary>
        public override Int32 Insert(System.String certificateCategoryName, System.String description, System.Boolean? inactive, System.Int32? updatedBy)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_CertificateCategory", cn);
				cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CertificateCategoryName", SqlDbType.NVarChar).Value = certificateCategoryName;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@CertificateCategoryId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@CertificateCategoryId"].Value;
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
        /// Calls [usp_select_CertificateCategory]
        /// </summary>
		public override CertificateCategoryDetails Get(System.Int32? categoryId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_CertificateCategory", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCurrencyFromReader(reader);
                    CertificateCategoryDetails obj = new CertificateCategoryDetails();
                    obj.CertificateCategoryId = GetReaderValue_Int32(reader, "CertificateCategoryId", 0);
                    obj.CertificateCategoryName = GetReaderValue_String(reader, "CertificateCategoryName", "");
                    obj.Description = GetReaderValue_String(reader, "Description", "");
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
        /// Calls [usp_update_CertificateCategory]
        /// </summary>
        public override bool Update(System.Int32? categoryId, System.String certificateCategoryName, System.String description, System.Boolean? inactive, System.Int32? updatedBy)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_CertificateCategory", cn);
				cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryId;
                cmd.Parameters.Add("@CertificateCategoryName", SqlDbType.NVarChar).Value = certificateCategoryName;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Certificate Category", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// Calls [usp_dropdown_CertificateCategory]
        /// </summary>
        /// <returns></returns>
        public override List<CertificateCategoryDetails> GetDropDownCertificateCategory()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdown_CertificateCategory", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CertificateCategoryDetails> lst = new List<CertificateCategoryDetails>();
                while (reader.Read())
                {
                    CertificateCategoryDetails obj = new CertificateCategoryDetails();
                    obj.CertificateCategoryId = GetReaderValue_Int32(reader, "CertificateCategoryId", 0);
                    obj.CertificateCategoryName = GetReaderValue_String(reader, "CertificateCategoryName", "");
                    obj.Description = GetReaderValue_String(reader, "Description", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", 0);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Certificate Category", sqlex);
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