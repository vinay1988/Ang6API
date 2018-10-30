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
    public class SqlCertificateProvider : CertificateProvider
    {
        /// <summary>
        /// Calls [usp_Get_All_CertificateByCategory]
        /// </summary>
        /// <returns></returns>
        public override List<CertificateDetails> GetListCertificate(System.Int32? certificateCategoryNo)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_Get_All_CertificateByCategory", cn);
				cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CategoryNo", SqlDbType.Int).Value = certificateCategoryNo;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
                List<CertificateDetails> lst = new List<CertificateDetails>();
				while (reader.Read()) {
                    CertificateDetails obj = new CertificateDetails();
                    obj.CertificateId = GetReaderValue_Int32(reader, "CertificateId", 0);
                    obj.CertificateName = GetReaderValue_String(reader, "CertificateName", "");
                    obj.Description = GetReaderValue_String(reader, "Description", "");
                    obj.CertificateCategoryNo = GetReaderValue_Int32(reader, "CertificateCategoryNo", 0);
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", 0);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Certificate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}


        /// <summary>
        /// Insert
        /// Calls [usp_insert_Certificate]
        /// </summary>
        public override Int32 Insert(System.String certificateName, System.String description, System.Int32? certificateCategoryNo, System.Boolean? inactive, System.Int32? updatedBy)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_Certificate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CertificateName", SqlDbType.NVarChar).Value = certificateName;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
                cmd.Parameters.Add("@CertificateCategoryNo", SqlDbType.Int).Value = certificateCategoryNo;
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@CertificateId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@CertificateId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Certificate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
        /// Calls [usp_select_Certificate]
        /// </summary>
        public override CertificateDetails Get(System.Int32? certificateId)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Certificate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CertificateId", SqlDbType.Int).Value = certificateId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
                    CertificateDetails obj = new CertificateDetails();
                    obj.CertificateId = GetReaderValue_Int32(reader, "CertificateId", 0);
                    obj.CertificateName = GetReaderValue_String(reader, "CertificateName", "");
                    obj.Description = GetReaderValue_String(reader, "Description", "");
                    obj.CertificateCategoryNo = GetReaderValue_Int32(reader, "CertificateCategoryNo", 0);
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Certificate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// Calls [usp_update_Certificate]
        /// </summary>
        public override bool Update(System.Int32? certificateId, System.String certificateName, System.String description, System.Int32? CertificateCategoryNo, System.Boolean? inactive, System.Int32? updatedBy)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Certificate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CertificateId", SqlDbType.Int).Value = certificateId;
                cmd.Parameters.Add("@CertificateName", SqlDbType.NVarChar).Value = certificateName;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
                cmd.Parameters.Add("@CertificateCategoryNo", SqlDbType.Int).Value = CertificateCategoryNo;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Certificate", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// Calls [usp_Get_CertificateByCompany]
        /// </summary>
        /// <returns></returns>
        public override List<CertificateDetails> GetCertificateByCompany(System.Int32? companyNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_get_CertificateByCompany", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
                cmd.CommandTimeout = 30;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CertificateDetails> lst = new List<CertificateDetails>();
                while (reader.Read())
                {
                    CertificateDetails obj = new CertificateDetails();
                    obj.CompanyCertificateId = GetReaderValue_Int32(reader, "CompanyCertificateId", 0);
                    obj.CertificateId = GetReaderValue_Int32(reader, "CertificateNo", 0);
                    obj.CertificateCategoryNo = GetReaderValue_Int32(reader, "CertificateCategoryNo", 0);
                    obj.CertificateName = GetReaderValue_String(reader, "CertificateName", "");
                    obj.Description = GetReaderValue_String(reader, "Description", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.StartDate = GetReaderValue_NullableDateTime(reader, "StartDate", null);
                    obj.ExpiryDate = GetReaderValue_NullableDateTime(reader, "ExpiryDate", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", 0);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.CertificateCategoryName = GetReaderValue_String(reader, "CertificateCategoryName", "");
                    obj.CertificateNumber = GetReaderValue_String(reader, "CertificateNumber", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get company certificate", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Calls [usp_dropdown_CertificateByCategory]
        /// </summary>
        /// <returns></returns>
        public override List<CertificateDetails> DropDownListCertificate(System.Int32? certificateCategoryNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdown_CertificateByCategory", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CategoryNo", SqlDbType.Int).Value = certificateCategoryNo;
                cmd.CommandTimeout = 30;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CertificateDetails> lst = new List<CertificateDetails>();
                while (reader.Read())
                {
                    CertificateDetails obj = new CertificateDetails();
                    obj.CertificateId = GetReaderValue_Int32(reader, "CertificateId", 0);
                    obj.CertificateName = GetReaderValue_String(reader, "CertificateName", "");
                    obj.Description = GetReaderValue_String(reader, "Description", "");
                    obj.CertificateCategoryNo = GetReaderValue_Int32(reader, "CertificateCategoryNo", 0);
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
                throw new Exception("Failed to get Certificate", sqlex);
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
        /// Calls [usp_insert_CompanyCertificate]
        /// </summary>
        public override Int32 InsertCompanyCertificate(System.Int32? clientNo, System.Int32? companyNo, System.Int32? certificateCategoryNo, System.Int32? CertificateNo, System.String description, System.DateTime? startDate, System.DateTime? expiryDate, System.Boolean? inactive, System.Int32? updatedBy, System.String certificateNumber)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_CompanyCertificate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientNo", SqlDbType.NVarChar).Value = clientNo;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.NVarChar).Value = companyNo;
                cmd.Parameters.Add("@CertificateCategoryNo", SqlDbType.Int).Value = certificateCategoryNo;
                cmd.Parameters.Add("@CertificateNo", SqlDbType.Int).Value = CertificateNo;  
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
                cmd.Parameters.Add("@ExpiryDate", SqlDbType.DateTime).Value = expiryDate;
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@CertificateNumber", SqlDbType.NVarChar).Value = certificateNumber;
                cmd.Parameters.Add("@CompanyCertificateId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@CompanyCertificateId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Company Certificate", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Update
        /// Calls [usp_update_CompanyCertificate]
        /// </summary>
        public override bool UpdateCompanyCertificate(System.Int32? companyCertificateId, System.Int32? certificateCategoryNo, System.Int32? CertificateNo, System.String description, System.DateTime? startDate, System.DateTime? expiryDate, System.Boolean? inactive, System.Int32? updatedBy, System.String certificateNumber)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_CompanyCertificate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CompanyCertificateId", SqlDbType.Int).Value = companyCertificateId;
                cmd.Parameters.Add("@CertificateCategoryNo", SqlDbType.Int).Value = certificateCategoryNo;
                cmd.Parameters.Add("@CertificateNo", SqlDbType.Int).Value = CertificateNo;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = description;
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
                cmd.Parameters.Add("@ExpiryDate", SqlDbType.DateTime).Value = expiryDate;
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@CertificateNumber", SqlDbType.NVarChar).Value = certificateNumber;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Company Certificate", sqlex);
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