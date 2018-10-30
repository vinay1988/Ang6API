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
	public class SqlProductProvider : ProductProvider {


        /// <summary>
        /// AutoSearch 
        /// Calls [usp_autosearch_Product]
        /// </summary>
        public override List<ProductDetails> AutoSearch(System.String nameSearch, System.Int32? clientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_autosearch_Product", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<ProductDetails> lst = new List<ProductDetails>();
                while (reader.Read())
                {
                    ProductDetails obj = new ProductDetails();
                    obj.ProductId = GetReaderValue_Int32(reader, "ProductId", 0);
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.Hazarders = GetReaderValue_NullableBoolean(reader, "IsHazarders", false);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Product", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
		/// Delete Product
		/// Calls [usp_delete_Product]
		/// </summary>
		public override bool Delete(System.Int32? productId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Product", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Product", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDownForClient 
		/// Calls [usp_dropdown_Product_for_Client]
        /// </summary>
		public override List<ProductDetails> DropDownForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_Product_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ProductDetails> lst = new List<ProductDetails>();
				while (reader.Read()) {
					ProductDetails obj = new ProductDetails();
					obj.ProductId = GetReaderValue_Int32(reader, "ProductId", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Products", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_Product]
		/// </summary>
		public override Int32 Insert(System.String productName, System.String productDescription, System.Int32? clientNo, System.String dutyCode, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Product", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = productName;
				cmd.Parameters.Add("@ProductDescription", SqlDbType.NVarChar).Value = productDescription;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@DutyCode", SqlDbType.NVarChar).Value = dutyCode;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@ProductId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@ProductId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Product", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}


        /// <summary>
        /// Create a new row
        /// Calls [usp_insert_GlobalProduct]
        /// </summary>
        ///  // Adding parameter GlobalProductNameNo to Add record with respective ProductNameId selected (Suhail )
        public override Int32 GlobalInsert(System.String productName, System.String productDescription, System.Int32? clientNo, System.String dutyCode, System.Int32? updatedBy, System.Int32? GlobalProductNameNo, System.Double? dutyRateValue, System.Boolean? hazarders)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_GlobalProduct", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = productName; //To hide display Product Name on Global Product Group tab
                cmd.Parameters.Add("@ProductDescription", SqlDbType.NVarChar).Value = productDescription;
              
                cmd.Parameters.Add("@DutyCode", SqlDbType.NVarChar).Value = dutyCode;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@GlobalProductNameNo", SqlDbType.Int).Value = GlobalProductNameNo;
                cmd.Parameters.Add("@DutyRateValue", SqlDbType.Int).Value = dutyRateValue;
                cmd.Parameters.Add("@IsHazarders", SqlDbType.Bit).Value = hazarders;
                cmd.Parameters.Add("@GlobalProductId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@GlobalProductId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Global Product", sqlex);
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
		/// Calls [usp_select_Product]
        /// </summary>
		public override ProductDetails Get(System.Int32? productId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Product", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetProductFromReader(reader);
					ProductDetails obj = new ProductDetails();
					obj.ProductId = GetReaderValue_Int32(reader, "ProductId", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.DutyCode = GetReaderValue_String(reader, "DutyCode", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Product", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetLandedCostCalculation 
		/// Calls [usp_select_Product_LandedCostCalculation]
        /// </summary>
		public override ProductDetails GetLandedCostCalculation(System.Int32? quantity, System.DateTime? datePoint, System.Int32? currencyNo, System.Double? cost, System.Double? shippingCost, System.Boolean? applyDuty, System.Int32? productNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Product_LandedCostCalculation", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@DatePoint", SqlDbType.DateTime).Value = datePoint;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@Cost", SqlDbType.Float).Value = cost;
				cmd.Parameters.Add("@ShippingCost", SqlDbType.Float).Value = shippingCost;
				cmd.Parameters.Add("@ApplyDuty", SqlDbType.Bit).Value = applyDuty;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetProductFromReader(reader);
					ProductDetails obj = new ProductDetails();
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Product", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForClient 
		/// Calls [usp_selectAll_Product_for_Client]
        /// </summary>
		public override List<ProductDetails> GetListForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Product_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ProductDetails> lst = new List<ProductDetails>();
				while (reader.Read()) {
					ProductDetails obj = new ProductDetails();
					obj.ProductId = GetReaderValue_Int32(reader, "ProductId", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.DutyCode = GetReaderValue_String(reader, "DutyCode", "");
					obj.CurrentDutyRate = GetReaderValue_NullableDouble(reader, "CurrentDutyRate", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Products", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}



        /// <summary>
        /// GetListForClient 
        /// Calls [usp_selectAll_Product_for_Client]
        /// </summary>
        public override List<ProductDetails> GetProductList(System.Int32? GlobalProductId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_Product_for_Global", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@GlobalProductId", SqlDbType.Int).Value = GlobalProductId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<ProductDetails> lst = new List<ProductDetails>();
                while (reader.Read())
                {
                    ProductDetails obj = new ProductDetails();
                    obj.ProductId = GetReaderValue_Int32(reader, "ProductId", 0);
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.DutyCode = GetReaderValue_String(reader, "DutyCode", "");
                    obj.CurrentDutyRate = GetReaderValue_NullableDouble(reader, "CurrentDutyRate", null);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Products", sqlex);
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
        /// Calls [usp_selectAll_GlobalProduct]
        /// </summary>
        /// // Adding parameterProductNameId to get record on basis of selected ProductNameId from Global product name (Suhail )
        public override List<ProductDetails> GetListGlobalProduct(System.Int32? GlobalProductNameId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_GlobalProduct", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@GlobalProductNameId", SqlDbType.Int).Value = GlobalProductNameId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<ProductDetails> lst = new List<ProductDetails>();
                while (reader.Read())
                {
                    ProductDetails obj = new ProductDetails();
                    obj.ProductId = GetReaderValue_Int32(reader, "GlobalProductId", 0);
                    //  obj.ProductName = GetReaderValue_String(reader, "GlobalProductName", ""); // To hide display Product Name on Global Product Group tab
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.DutyCode = GetReaderValue_String(reader, "DutyCode", "");
                    obj.CurrentDutyRate = GetReaderValue_NullableDouble(reader, "CurrentDutyRate", null);
                    obj.Hazarders = GetReaderValue_NullableBoolean(reader, "IsHazardous", false);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Products", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		

        /// <summary>
        /// Update Product
		/// Calls [usp_update_Product]
        /// </summary>
		public override bool Update(System.Int32? productId, System.String productName, System.String productDescription, System.Int32? clientNo, System.String dutyCode, System.Boolean? inactive, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Product", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;
				cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = productName;
				cmd.Parameters.Add("@ProductDescription", SqlDbType.NVarChar).Value = productDescription;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@DutyCode", SqlDbType.NVarChar).Value = dutyCode;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Product", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}




        /// <summary>
        /// Update Product
        /// Calls [usp_update_GlobalProduct]
        /// </summary>
        public override bool GlobalUpdate(System.Int32? productId, System.String productName, System.String productDescription, System.Int32? clientNo, System.String dutyCode, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? hazarders)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_GlobalProduct", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GlobalProductId", SqlDbType.Int).Value = productId;
                //cmd.Parameters.Add("@GlobalProductName", SqlDbType.NVarChar).Value = productName; // To hide display Product Name on Global Product Group tab
                cmd.Parameters.Add("@ProductDescription", SqlDbType.NVarChar).Value = productDescription;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@DutyCode", SqlDbType.NVarChar).Value = dutyCode;
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@IsHazarders", SqlDbType.Bit).Value = hazarders;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Global Product", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update Product
        /// Calls [usp_update_Product_Globally]
        /// </summary>
        public override bool UpdateProductGlobally(System.Int32? productId, System.Boolean? inactive, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Product_Globally", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;
                
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
                throw new Exception("Failed to update Product", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// AutoSearch by Client and Global Product
        /// Calls [usp_autosearch_Product_By_GlobalProduct_Client]
        /// </summary>
        public override List<ProductDetails> ProductByGlobalAndClient(System.String nameSearch, System.Int32? clientId, System.Int32? globalProductNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_autosearch_Product_By_GlobalProduct_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@GlobalProductNo", SqlDbType.Int).Value = clientId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<ProductDetails> lst = new List<ProductDetails>();
                while (reader.Read())
                {
                    ProductDetails obj = new ProductDetails();
                    obj.ProductId = GetReaderValue_Int32(reader, "ProductId", 0);
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Product", sqlex);
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
        /// Calls [usp_selectAll_GlobalProductName]
        /// </summary>
        public override List<ProductDetails> GetListGlobalProductName()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_GlobalProductName", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<ProductDetails> lst = new List<ProductDetails>();
                while (reader.Read())
                {
                    ProductDetails obj = new ProductDetails();
                    obj.GlobalProductNameId = GetReaderValue_Int32(reader, "GlobalProductNameId", 0);
                    obj.GlobalProductName = GetReaderValue_String(reader, "GlobalProductName", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Products", sqlex);
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
        /// Calls [usp_insert_GlobalProductName]
        /// </summary>
        public override bool GlobalNameInsert(System.String productName,System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_GlobalProductName", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = productName;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@DLUP", SqlDbType.DateTime).Value = DateTime.Now;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Global Product", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Update Product
        /// Calls [usp_update_GlobalProductName]
        /// </summary>
        public override bool GlobalUpdateName(System.Int32? productId, System.String productName,  System.Boolean? inactive, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_GlobalProductName", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GlobalProductNameId", SqlDbType.Int).Value = productId;
                cmd.Parameters.Add("@GlobalProductName", SqlDbType.NVarChar).Value = productName;
                cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;            
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);            
                
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Global Product Name", sqlex);
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