/* Marker    changed by      date           Remarks
  [001]      Vinay           11/08/2014     ESMS  Ticket Number: 	200
 */
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
	public class SqlManufacturerLinkProvider : ManufacturerLinkProvider {
		/// <summary>
		/// Count ManufacturerLink
		/// Calls [usp_count_ManufacturerLink_for_Manufacturer_and_Supplier]
		/// </summary>
		public override Int32 CountForManufacturerAndSupplier(System.Int32? manufacturerNo, System.Int32? supplierCompanyNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_ManufacturerLink_for_Manufacturer_and_Supplier", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@SupplierCompanyNo", SqlDbType.Int).Value = supplierCompanyNo;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count ManufacturerLink", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete ManufacturerLink
		/// Calls [usp_delete_ManufacturerLink]
		/// </summary>
		public override bool Delete(System.Int32? manufacturerLinkId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_ManufacturerLink", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ManufacturerLinkId", SqlDbType.Int).Value = manufacturerLinkId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete ManufacturerLink", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_ManufacturerLink]
		/// </summary>
		public override Int32 Insert(System.Int32? manufacturerNo, System.Int32? supplierCompanyNo, System.Int32? manufacturerRating, System.Int32? supplierRating, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_ManufacturerLink", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@SupplierCompanyNo", SqlDbType.Int).Value = supplierCompanyNo;
				cmd.Parameters.Add("@ManufacturerRating", SqlDbType.Int).Value = manufacturerRating;
				cmd.Parameters.Add("@SupplierRating", SqlDbType.Int).Value = supplierRating;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@ManufacturerLinkId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@ManufacturerLinkId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert ManufacturerLink", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_ManufacturerLink]
        /// </summary>
		public override ManufacturerLinkDetails Get(System.Int32? manufacturerLinkId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_ManufacturerLink", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ManufacturerLinkId", SqlDbType.Int).Value = manufacturerLinkId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetManufacturerLinkFromReader(reader);
					ManufacturerLinkDetails obj = new ManufacturerLinkDetails();
					obj.ManufacturerLinkId = GetReaderValue_Int32(reader, "ManufacturerLinkId", 0);
					obj.ManufacturerNo = GetReaderValue_Int32(reader, "ManufacturerNo", 0);
					obj.SupplierCompanyNo = GetReaderValue_Int32(reader, "SupplierCompanyNo", 0);
					obj.ManufacturerRating = GetReaderValue_NullableInt32(reader, "ManufacturerRating", null);
					obj.SupplierRating = GetReaderValue_NullableInt32(reader, "SupplierRating", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ManufacturerLink", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForManufacturerAndSupplier 
		/// Calls [usp_select_ManufacturerLink_for_Manufacturer_and_Supplier]
        /// </summary>
		public override ManufacturerLinkDetails GetForManufacturerAndSupplier(System.Int32? manufacturerNo, System.Int32? supplierCompanyNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_ManufacturerLink_for_Manufacturer_and_Supplier", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@SupplierCompanyNo", SqlDbType.Int).Value = supplierCompanyNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetManufacturerLinkFromReader(reader);
					ManufacturerLinkDetails obj = new ManufacturerLinkDetails();
					obj.ManufacturerLinkId = GetReaderValue_Int32(reader, "ManufacturerLinkId", 0);
					obj.ManufacturerNo = GetReaderValue_Int32(reader, "ManufacturerNo", 0);
					obj.SupplierCompanyNo = GetReaderValue_Int32(reader, "SupplierCompanyNo", 0);
					obj.ManufacturerRating = GetReaderValue_NullableInt32(reader, "ManufacturerRating", null);
					obj.SupplierRating = GetReaderValue_NullableInt32(reader, "SupplierRating", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ManufacturerLink", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForManufacturer 
		/// Calls [usp_selectAll_ManufacturerLink_for_Manufacturer]
        /// </summary>
		public override List<ManufacturerLinkDetails> GetListForManufacturer(System.Int32? manufacturerId, System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_ManufacturerLink_for_Manufacturer", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ManufacturerId", SqlDbType.Int).Value = manufacturerId;
				cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ManufacturerLinkDetails> lst = new List<ManufacturerLinkDetails>();
				while (reader.Read()) {
					ManufacturerLinkDetails obj = new ManufacturerLinkDetails();
					obj.ManufacturerLinkId = GetReaderValue_Int32(reader, "ManufacturerLinkId", 0);
					obj.ManufacturerNo = GetReaderValue_Int32(reader, "ManufacturerNo", 0);
					obj.SupplierCompanyNo = GetReaderValue_Int32(reader, "SupplierCompanyNo", 0);
					obj.ManufacturerRating = GetReaderValue_NullableInt32(reader, "ManufacturerRating", null);
					obj.SupplierRating = GetReaderValue_NullableInt32(reader, "SupplierRating", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
                    //[001] code start
                    obj.CompanyType = GetReaderValue_String(reader, "CompanyType", "");
                    //[001] code end
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ManufacturerLinks", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForSupplier 
		/// Calls [usp_selectAll_ManufacturerLink_for_Supplier]
        /// </summary>
		public override List<ManufacturerLinkDetails> GetListForSupplier(System.Int32? supplierCompanyNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_ManufacturerLink_for_Supplier", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SupplierCompanyNo", SqlDbType.Int).Value = supplierCompanyNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ManufacturerLinkDetails> lst = new List<ManufacturerLinkDetails>();
				while (reader.Read()) {
					ManufacturerLinkDetails obj = new ManufacturerLinkDetails();
					obj.ManufacturerLinkId = GetReaderValue_Int32(reader, "ManufacturerLinkId", 0);
					obj.ManufacturerNo = GetReaderValue_Int32(reader, "ManufacturerNo", 0);
					obj.SupplierCompanyNo = GetReaderValue_Int32(reader, "SupplierCompanyNo", 0);
					obj.ManufacturerRating = GetReaderValue_NullableInt32(reader, "ManufacturerRating", null);
					obj.SupplierRating = GetReaderValue_NullableInt32(reader, "SupplierRating", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ManufacturerLinks", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update ManufacturerLink
		/// Calls [usp_update_ManufacturerLink]
        /// </summary>
		public override bool Update(System.Int32? manufacturerLinkId, System.Int32? manufacturerNo, System.Int32? supplierCompanyNo, System.Int32? manufacturerRating, System.Int32? supplierRating, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_ManufacturerLink", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ManufacturerLinkId", SqlDbType.Int).Value = manufacturerLinkId;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@SupplierCompanyNo", SqlDbType.Int).Value = supplierCompanyNo;
				cmd.Parameters.Add("@ManufacturerRating", SqlDbType.Int).Value = manufacturerRating;
				cmd.Parameters.Add("@SupplierRating", SqlDbType.Int).Value = supplierRating;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update ManufacturerLink", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update ManufacturerLink
		/// Calls [usp_update_ManufacturerLink_by_Manufacturer_and_Supplier]
        /// </summary>
		public override bool UpdateByManufacturerAndSupplier(System.Int32? manufacturerNo, System.Int32? supplierCompanyNo, System.Int32? manufacturerRating, System.Int32? supplierRating, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_ManufacturerLink_by_Manufacturer_and_Supplier", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@SupplierCompanyNo", SqlDbType.Int).Value = supplierCompanyNo;
				cmd.Parameters.Add("@ManufacturerRating", SqlDbType.Int).Value = manufacturerRating;
				cmd.Parameters.Add("@SupplierRating", SqlDbType.Int).Value = supplierRating;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update ManufacturerLink", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}