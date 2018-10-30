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
	public class SqlPartProvider : PartProvider {
        /// <summary>
        /// AutoSearch 
		/// Calls [usp_autosearch_Part]
        /// </summary>
		public override List<PartDetails> AutoSearch(System.Int32? clientId, System.String partSearch) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_autosearch_Part", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PartDetails> lst = new List<PartDetails>();
				while (reader.Read()) {
					PartDetails obj = new PartDetails();
                  
                    obj.PartName = GetReaderValue_String(reader, "PartName", "");
                   
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Parts", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// AutoSearch 
        /// Calls [usp_autosearch_Part_New]
        /// </summary>
        public override List<PartDetails> CustReqPartSearch(System.Int32? clientId, System.String partSearch)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_autosearch_Part_New", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PartDetails> lst = new List<PartDetails>();
                while (reader.Read())
                {
                    PartDetails obj = new PartDetails();
                    obj.PartNameWithManufacture = GetReaderValue_String(reader, "PartName", "");
                    obj.PartName = GetReaderValue_String(reader, "Parts", "");
                    obj.ManufacturerNo = GetReaderValue_Int32(reader, "ManufacturerId", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Parts", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// AutoSearch 
        /// Calls [usp_autosearch_CustReqPart]
        /// </summary>
        public override List<PartDetails> CustReqPart(System.Int32? clientId, System.String partSearch, System.String ids, System.String DateCode)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            string ManufacturerNo = "";
            string ProductNumber = "";
            string PackageNumber = "";
            string[] values = ids.Split('|');// ids.Split(",");
            ManufacturerNo = values[0].Trim();
            ProductNumber = values[1].Trim();
            PackageNumber = values[2].Trim();

            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_autosearch_CustReqPart", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
                cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = Convert.ToInt32(ManufacturerNo);
                cmd.Parameters.Add("@ProductNumber", SqlDbType.Int).Value = Convert.ToInt32(ProductNumber);
                cmd.Parameters.Add("@PackageNumber", SqlDbType.Int).Value = Convert.ToInt32(PackageNumber);
                cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = DateCode;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PartDetails> lst = new List<PartDetails>();
                while (reader.Read())
                {
                    PartDetails obj = new PartDetails();
                    obj.PartNameWithManufacture = GetReaderValue_String(reader, "PartName", "");
                    obj.PartName = GetReaderValue_String(reader, "Parts", "");
                    obj.ManufacturerNo = GetReaderValue_Int32(reader, "ManufacturerId", 0);
                    obj.Productname = GetReaderValue_String(reader, "ProductName", "");
                    obj.Packagename = GetReaderValue_String(reader, "PackageName", "");
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.ProductNo = GetReaderValue_Int32(reader, "ProductNo", 0);
                    obj.PackageNo = GetReaderValue_Int32(reader, "PackageNo", 0);
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.ROHSNo = GetReaderValue_Int32(reader, "ROHS", 0);

                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Parts", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// AutoSearch 
        /// Calls [usp_autosearch_Part_New]
        /// </summary>
        public override List<PartDetails> CustReqPartsGRID(System.Int32? clientId, System.String partSearch)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                partSearch = partSearch + "%";
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_PartSearch_GRID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PartDetails> lst = new List<PartDetails>();
                while (reader.Read())
                {
                    PartDetails obj = new PartDetails();
                    obj.PartNameWithManufacture = GetReaderValue_String(reader, "PartName", "");
                    obj.PartName = GetReaderValue_String(reader, "Parts", "");
                    obj.ManufacturerNo = GetReaderValue_Int32(reader, "ManufacturerId", 0);
                    obj.ProductNo = GetReaderValue_Int32(reader, "ProductNo", 0);
                    obj.PackageNo = GetReaderValue_Int32(reader, "PackageNo", 0);
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.Productname = GetReaderValue_String(reader, "ProductName", "");
                    obj.Packagename = GetReaderValue_String(reader, "PackageName", "");
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.DateCodeOriginal = GetReaderValue_String(reader, "DateCodeOriginal", "");
                    obj.ROHSNo = GetReaderValue_Int32(reader, "ROHS", 0);
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ProductInactive = GetReaderValue_NullableBoolean(reader, "ProductInactive", false);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Parts", sqlex);
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
		/// Calls [usp_insert_Part]
		/// </summary>
		public override Int32 Insert(System.String fullPart, System.Int32? manufacturerNo, System.Int32? packageNo, System.Int32? productNo, System.Int32? minimumQuantity, System.Int32? reOrderQuantity, System.Int32? leadTime, System.Int32? clientNo, System.Double? resalePrice, System.String partTitle, System.Boolean? masterPart, System.Boolean? goldenPart, System.Boolean? rohsCompliant, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Part", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@FullPart", SqlDbType.NVarChar).Value = fullPart;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@MinimumQuantity", SqlDbType.Int).Value = minimumQuantity;
				cmd.Parameters.Add("@ReOrderQuantity", SqlDbType.Int).Value = reOrderQuantity;
				cmd.Parameters.Add("@LeadTime", SqlDbType.Int).Value = leadTime;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@ResalePrice", SqlDbType.Float).Value = resalePrice;
				cmd.Parameters.Add("@PartTitle", SqlDbType.NVarChar).Value = partTitle;
				cmd.Parameters.Add("@MasterPart", SqlDbType.Bit).Value = masterPart;
				cmd.Parameters.Add("@GoldenPart", SqlDbType.Bit).Value = goldenPart;
				cmd.Parameters.Add("@ROHSCompliant", SqlDbType.Bit).Value = rohsCompliant;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@MasterPartId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@MasterPartId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Part", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}