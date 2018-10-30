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
	public class SqlManufacturerProvider : ManufacturerProvider {
        /// <summary>
        /// AutoSearch 
		/// Calls [usp_autosearch_Manufacturer]
        /// </summary>
        public override List<ManufacturerDetails> AutoSearch(System.String nameSearch, Boolean? showInactive)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_autosearch_Manufacturer", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
                cmd.Parameters.Add("@ShowInactive", SqlDbType.Bit).Value = showInactive;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ManufacturerDetails> lst = new List<ManufacturerDetails>();
				while (reader.Read()) {
					ManufacturerDetails obj = new ManufacturerDetails();
					obj.ManufacturerId = GetReaderValue_Int32(reader, "ManufacturerId", 0);
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.FullName = GetReaderValue_String(reader, "FullName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Manufacturers", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Count Manufacturer
		/// Calls [usp_count_Manufacturer]
		/// </summary>
		public override Int32 Count() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_Manufacturer", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count Manufacturer", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DataListNugget 
		/// Calls [usp_datalistnugget_Manufacturer]
        /// </summary>
		public override List<ManufacturerDetails> DataListNugget(System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nameSearch, System.String codeSearch) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_Manufacturer", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
				cmd.Parameters.Add("@CodeSearch", SqlDbType.NVarChar).Value = codeSearch;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ManufacturerDetails> lst = new List<ManufacturerDetails>();
				while (reader.Read()) {
					ManufacturerDetails obj = new ManufacturerDetails();
					obj.ManufacturerId = GetReaderValue_Int32(reader, "ManufacturerId", 0);
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.URL = GetReaderValue_String(reader, "URL", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive",false);
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.ConflictResource = GetReaderValue_String(reader, "ConflictResource", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Manufacturers", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete Manufacturer
		/// Calls [usp_delete_Manufacturer]
		/// </summary>
		public override bool Delete(System.Int32? manufacturerId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Manufacturer", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ManufacturerId", SqlDbType.Int).Value = manufacturerId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Manufacturer", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDown 
		/// Calls [usp_dropdown_Manufacturer]
        /// </summary>
		public override List<ManufacturerDetails> DropDown() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_Manufacturer", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ManufacturerDetails> lst = new List<ManufacturerDetails>();
				while (reader.Read()) {
					ManufacturerDetails obj = new ManufacturerDetails();
					obj.ManufacturerId = GetReaderValue_Int32(reader, "ManufacturerId", 0);
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Manufacturers", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_Manufacturer]
		/// </summary>
		public override Int32 Insert(System.String manufacturerName, System.String notes, System.String manufacturerCode, System.Int32? updatedBy, System.String url) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Manufacturer", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ManufacturerName", SqlDbType.NVarChar).Value = manufacturerName;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@ManufacturerCode", SqlDbType.NVarChar).Value = manufacturerCode;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@URL", SqlDbType.NVarChar).Value = url;
				cmd.Parameters.Add("@ManufacturerId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@ManufacturerId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Manufacturer", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_Manufacturer]
        /// </summary>
		public override ManufacturerDetails Get(System.Int32? manufacturerId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Manufacturer", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ManufacturerId", SqlDbType.Int).Value = manufacturerId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetManufacturerFromReader(reader);
					ManufacturerDetails obj = new ManufacturerDetails();
					obj.ManufacturerId = GetReaderValue_Int32(reader, "ManufacturerId", 0);
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.URL = GetReaderValue_String(reader, "URL", "");
                    obj.IsPDFAvailable = GetReaderValue_Boolean(reader, "IsPDFAvailable", false);
                    obj.ConflictResource = GetReaderValue_String(reader, "ConflictResource", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Manufacturer", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Manufacturer
		/// Calls [usp_update_Manufacturer]
        /// </summary>
        public override bool Update(System.Int32? manufacturerId, System.String manufacturerName, System.String notes, System.String manufacturerCode, System.Boolean? inactive, System.Int32? updatedBy, System.String url, System.String conflictResource)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Manufacturer", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ManufacturerId", SqlDbType.Int).Value = manufacturerId;
				cmd.Parameters.Add("@ManufacturerName", SqlDbType.NVarChar).Value = manufacturerName;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@ManufacturerCode", SqlDbType.NVarChar).Value = manufacturerCode;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@URL", SqlDbType.NVarChar).Value = url;
                cmd.Parameters.Add("@ConflictResource", SqlDbType.NVarChar).Value = conflictResource;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Manufacturer", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// Calls [usp_insert_ManufacturerPDF]
        /// </summary>
        /// <param name="ManufacturerNo"></param>
        /// <param name="Caption"></param>
        /// <param name="FileName"></param>
        /// <param name="UpdatedBy"></param>
        /// <returns></returns>
        public override Int32 Insert(System.Int32? ManufacturerNo, System.String Caption, System.String FileName, System.Int32? UpdatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_ManufacturerPDF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = ManufacturerNo;
                cmd.Parameters.Add("@Caption", SqlDbType.NVarChar).Value = Caption;
                cmd.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = FileName;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UpdatedBy;
                cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@NewId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert manufaturer pdf", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }




        /// <summary>
        /// Calls [usp_insert_ManufacturerExcel]
        /// </summary>
        /// <param name="ManufacturerNo"></param>
        /// <param name="Caption"></param>
        /// <param name="FileName"></param>
        /// <param name="UpdatedBy"></param>
        /// <returns></returns>
        public override Int32 InsertExcel(System.Int32? ManufacturerNo, System.String Caption, System.String FileName, System.Int32? UpdatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_ManufacturerExcel", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = ManufacturerNo;
                cmd.Parameters.Add("@Caption", SqlDbType.NVarChar).Value = Caption;
                cmd.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = FileName;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UpdatedBy;
                cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@NewId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert manufaturer excel", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        // [006] code start
        /// <summary>
        /// GetPDFListForInvoice 
        /// Calls [usp_selectAll_PDF_for_Manufacturer]
        /// </summary>
        public override List<PDFDocumentDetails> GetPDFListForManufacturer(System.Int32? manufacturerNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_PDF_for_Manufacturer", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PDFDocumentDetails> lstPDF = new List<PDFDocumentDetails>();
                while (reader.Read())
                {
                    PDFDocumentDetails obj = new PDFDocumentDetails();
                    obj.PDFDocumentId = GetReaderValue_Int32(reader, "ManufacturerPDFId", 0);
                    obj.PDFDocumentRefNo = GetReaderValue_Int32(reader, "ManufactureNo", 0);
                    obj.Caption = GetReaderValue_String(reader, "Caption", "");
                    obj.FileName = GetReaderValue_String(reader, "FileName", "");
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
                    lstPDF.Add(obj);
                    obj = null;
                }
                return lstPDF;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get PDF list for invoice", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }



       
        /// Calls [usp_selectAll_Excel_for_Manufacturer]
        /// </summary>
        public override List<PDFDocumentDetails> GetExcelListForManufacturer(System.Int32? manufacturerNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_Excel_for_Manufacturer", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PDFDocumentDetails> lstPDF = new List<PDFDocumentDetails>();
                while (reader.Read())
                {
                    PDFDocumentDetails obj = new PDFDocumentDetails();
                    obj.PDFDocumentId = GetReaderValue_Int32(reader, "ManufacturerExcelId", 0);
                    obj.PDFDocumentRefNo = GetReaderValue_Int32(reader, "ManufactureNo", 0);
                    obj.Caption = GetReaderValue_String(reader, "Caption", "");
                    obj.FileName = GetReaderValue_String(reader, "FileName", "");
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
                    lstPDF.Add(obj);
                    obj = null;
                }
                return lstPDF;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Excel list for invoice", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }




        /// <summary>
        /// DeleteManufacturerPDF
        /// Calls [usp_delete_ManufacturerPDF]
        /// </summary>
        /// <param name="ManufacturerPdfId"></param>
        /// <returns></returns>
        public override bool DeleteManufacturerPDF(System.Int32? ManufacturerPdfId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_ManufacturerPDF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ManufacturerPdfId", SqlDbType.Int).Value = ManufacturerPdfId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete manufacturer pdf", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// DeleteManufacturerExcel
        /// Calls [usp_delete_ManufacturerExcel]
        /// </summary>
        /// <param name="ManufacturerExcelId"></param>
        /// <returns></returns>
        public override bool DeleteManufacturerExcel(System.Int32? ManufacturerExcelId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_ManufacturerExcel", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ManufacturerExcelId", SqlDbType.Int).Value = ManufacturerExcelId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete manufacturer excel", sqlex);
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