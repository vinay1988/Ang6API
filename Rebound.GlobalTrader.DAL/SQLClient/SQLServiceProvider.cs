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
	public class SqlServiceProvider : ServiceProvider {
        /// <summary>
        /// AutoSearch 
		/// Calls [usp_autosearch_Service]
        /// </summary>
		public override List<ServiceDetails> AutoSearch(System.Int32? clientId, System.String nameSearch) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_autosearch_Service", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ServiceDetails> lst = new List<ServiceDetails>();
				while (reader.Read()) {
					ServiceDetails obj = new ServiceDetails();
					obj.ServiceId = GetReaderValue_Int32(reader, "ServiceId", 0);
					obj.ServiceName = GetReaderValue_String(reader, "ServiceName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Services", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Count Service
		/// Calls [usp_count_Service_for_Client]
		/// </summary>
		public override Int32 CountForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_Service_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count Service", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DataListNugget 
		/// Calls [usp_datalistnugget_Service]
        /// </summary>
		public override List<ServiceDetails> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String serviceName, System.String serviceDescription, System.Int32? lotNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_Service", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@ServiceName", SqlDbType.NVarChar).Value = serviceName;
				cmd.Parameters.Add("@ServiceDescription", SqlDbType.NVarChar).Value = serviceDescription;
				cmd.Parameters.Add("@LotNo", SqlDbType.Int).Value = lotNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ServiceDetails> lst = new List<ServiceDetails>();
				while (reader.Read()) {
					ServiceDetails obj = new ServiceDetails();
					obj.ServiceId = GetReaderValue_Int32(reader, "ServiceId", 0);
					obj.ServiceName = GetReaderValue_String(reader, "ServiceName", "");
					obj.ServiceDescription = GetReaderValue_String(reader, "ServiceDescription", "");
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.Cost = GetReaderValue_NullableDouble(reader, "Cost", null);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.LotName = GetReaderValue_String(reader, "LotName", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Services", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete Service
		/// Calls [usp_delete_Service]
		/// </summary>
		public override bool Delete(System.Int32? serviceId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Service", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ServiceId", SqlDbType.Int).Value = serviceId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Service", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete Service
		/// Calls [usp_delete_Service_Unallocated_for_Lot]
		/// </summary>
		public override bool DeleteUnallocatedForLot(System.Int32? lotNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Service_Unallocated_for_Lot", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@LotNo", SqlDbType.Int).Value = lotNo;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Service", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_Service]
		/// </summary>
		public override Int32 Insert(System.Int32? clientNo, System.String serviceName, System.String serviceDescription, System.Double? price, System.Double? cost, System.String notes, System.Int32? lotNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Service", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@ServiceName", SqlDbType.NVarChar).Value = serviceName;
				cmd.Parameters.Add("@ServiceDescription", SqlDbType.NVarChar).Value = serviceDescription;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@Cost", SqlDbType.Float).Value = cost;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@LotNo", SqlDbType.Int).Value = lotNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@ServiceId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@ServiceId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Service", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// ItemSearch 
		/// Calls [usp_itemsearch_Service]
        /// </summary>
		public override List<ServiceDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String serviceName, System.String serviceDescription, System.Int32? lotNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_itemsearch_Service", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@ServiceName", SqlDbType.NVarChar).Value = serviceName;
				cmd.Parameters.Add("@ServiceDescription", SqlDbType.NVarChar).Value = serviceDescription;
				cmd.Parameters.Add("@LotNo", SqlDbType.Int).Value = lotNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ServiceDetails> lst = new List<ServiceDetails>();
				while (reader.Read()) {
					ServiceDetails obj = new ServiceDetails();
					obj.ServiceId = GetReaderValue_Int32(reader, "ServiceId", 0);
					obj.ServiceName = GetReaderValue_String(reader, "ServiceName", "");
					obj.ServiceDescription = GetReaderValue_String(reader, "ServiceDescription", "");
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.Cost = GetReaderValue_NullableDouble(reader, "Cost", null);
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.ClientBaseCurrencyCode = GetReaderValue_String(reader, "ClientBaseCurrencyCode", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Services", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_Service]
        /// </summary>
		public override ServiceDetails Get(System.Int32? serviceId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Service", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ServiceId", SqlDbType.Int).Value = serviceId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetServiceFromReader(reader);
					ServiceDetails obj = new ServiceDetails();
					obj.ServiceId = GetReaderValue_Int32(reader, "ServiceId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.ServiceName = GetReaderValue_String(reader, "ServiceName", "");
					obj.ServiceDescription = GetReaderValue_String(reader, "ServiceDescription", "");
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.Cost = GetReaderValue_NullableDouble(reader, "Cost", null);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.LotName = GetReaderValue_String(reader, "LotName", "");
					obj.Allocations = GetReaderValue_NullableInt32(reader, "Allocations", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Service", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForPage 
		/// Calls [usp_select_Service_for_Page]
        /// </summary>
		public override ServiceDetails GetForPage(System.Int32? serviceId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Service_for_Page", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ServiceId", SqlDbType.Int).Value = serviceId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetServiceFromReader(reader);
					ServiceDetails obj = new ServiceDetails();
					obj.ServiceId = GetReaderValue_Int32(reader, "ServiceId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.ServiceName = GetReaderValue_String(reader, "ServiceName", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Service", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForLot 
		/// Calls [usp_selectAll_Service_for_Lot]
        /// </summary>
		public override List<ServiceDetails> GetListForLot(System.Int32? lotId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Service_for_Lot", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LotId", SqlDbType.Int).Value = lotId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ServiceDetails> lst = new List<ServiceDetails>();
				while (reader.Read()) {
					ServiceDetails obj = new ServiceDetails();
					obj.ServiceId = GetReaderValue_Int32(reader, "ServiceId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.ServiceName = GetReaderValue_String(reader, "ServiceName", "");
					obj.ServiceDescription = GetReaderValue_String(reader, "ServiceDescription", "");
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.Cost = GetReaderValue_NullableDouble(reader, "Cost", null);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Services", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Service
		/// Calls [usp_update_Service]
        /// </summary>
		public override bool Update(System.Int32? serviceId, System.Int32? clientNo, System.String serviceName, System.String serviceDescription, System.Double? price, System.Double? cost, System.String notes, System.Int32? lotNo, System.Boolean? inactive, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Service", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ServiceId", SqlDbType.Int).Value = serviceId;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@ServiceName", SqlDbType.NVarChar).Value = serviceName;
				cmd.Parameters.Add("@ServiceDescription", SqlDbType.NVarChar).Value = serviceDescription;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@Cost", SqlDbType.Float).Value = cost;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@LotNo", SqlDbType.Int).Value = lotNo;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Service", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Service
		/// Calls [usp_update_Service_MakeInactive]
        /// </summary>
		public override bool UpdateMakeInactive(System.Int32? serviceId, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Service_MakeInactive", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ServiceId", SqlDbType.Int).Value = serviceId;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Service", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Service
		/// Calls [usp_update_Service_Transfer_Lot]
        /// </summary>
		public override bool UpdateTransferLot(System.Int32? oldNotNo, System.Int32? newLotNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Service_Transfer_Lot", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@OldNotNo", SqlDbType.Int).Value = oldNotNo;
				cmd.Parameters.Add("@NewLotNo", SqlDbType.Int).Value = newLotNo;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Service", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}