//Marker    changed by      date           Remarks
//[001]      Vinay           12/08/2014     ESMS  Ticket Number: 	201
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
	public class SqlLotProvider : LotProvider {
		/// <summary>
		/// Count Lot
		/// Calls [usp_count_Lot_for_Client]
		/// </summary>
		public override Int32 CountForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_Lot_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count Lot", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DataListNugget 
		/// Calls [usp_datalistnugget_Lot]
        /// </summary>
		public override List<LotDetails> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String lotCode, System.String lotName) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_Lot", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@LotCode", SqlDbType.NVarChar).Value = lotCode;
				cmd.Parameters.Add("@LotName", SqlDbType.NVarChar).Value = lotName;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<LotDetails> lst = new List<LotDetails>();
				while (reader.Read()) {
					LotDetails obj = new LotDetails();
					obj.LotId = GetReaderValue_Int32(reader, "LotId", 0);
					obj.LotName = GetReaderValue_String(reader, "LotName", "");
					obj.OnHold = GetReaderValue_Boolean(reader, "OnHold", false);
					obj.Consignment = GetReaderValue_Boolean(reader, "Consignment", false);
					obj.LotCode = GetReaderValue_String(reader, "LotCode", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.StockCount = GetReaderValue_NullableInt32(reader, "StockCount", null);
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Lots", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete Lot
		/// Calls [usp_delete_Lot]
		/// </summary>
		public override bool Delete(System.Int32? lotId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Lot", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@LotId", SqlDbType.Int).Value = lotId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Lot", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDownForClient 
		/// Calls [usp_dropdown_Lot_for_Client]
        /// </summary>
		public override List<LotDetails> DropDownForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_Lot_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<LotDetails> lst = new List<LotDetails>();
				while (reader.Read()) {
					LotDetails obj = new LotDetails();
					obj.LotId = GetReaderValue_Int32(reader, "LotId", 0);
					obj.LotName = GetReaderValue_String(reader, "LotName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Lots", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_Lot]
		/// </summary>
		public override Int32 Insert(System.Int32? clientNo, System.String lotName, System.Double? cost, System.Int32? currencyNo, System.Boolean? onHold, System.Boolean? consignment, System.String notes, System.String lotCode, System.Int32? updatedBy, System.Int32? LockForCustomerNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Lot", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@LotName", SqlDbType.NVarChar).Value = lotName;
				cmd.Parameters.Add("@Cost", SqlDbType.Float).Value = cost;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@OnHold", SqlDbType.Bit).Value = onHold;
				cmd.Parameters.Add("@Consignment", SqlDbType.Bit).Value = consignment;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@LotCode", SqlDbType.NVarChar).Value = lotCode;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@LockForCustomerNo", SqlDbType.NVarChar).Value = LockForCustomerNo;
				cmd.Parameters.Add("@LotId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@LotId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Lot", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_Lot]
        /// </summary>
		public override LotDetails Get(System.Int32? lotId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Lot", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LotId", SqlDbType.Int).Value = lotId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetLotFromReader(reader);
					LotDetails obj = new LotDetails();
					obj.LotId = GetReaderValue_Int32(reader, "LotId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.LotName = GetReaderValue_String(reader, "LotName", "");
					obj.Cost = GetReaderValue_NullableDouble(reader, "Cost", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.OnHold = GetReaderValue_Boolean(reader, "OnHold", false);
					obj.Consignment = GetReaderValue_Boolean(reader, "Consignment", false);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.LotCode = GetReaderValue_String(reader, "LotCode", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.LockForCustomerNo = GetReaderValue_NullableInt32(reader, "LockForCustomerNo", null);
                    obj.LockForCustomer = GetReaderValue_String(reader, "LockForCustomer", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Lot", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForPage 
		/// Calls [usp_select_Lot_for_Page]
        /// </summary>
		public override LotDetails GetForPage(System.Int32? lotId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Lot_for_Page", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LotId", SqlDbType.Int).Value = lotId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetLotFromReader(reader);
					LotDetails obj = new LotDetails();
					obj.LotId = GetReaderValue_Int32(reader, "LotId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.LotName = GetReaderValue_String(reader, "LotName", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Lot", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Lot
		/// Calls [usp_update_Lot]
        /// </summary>
        public override bool Update(System.Int32? lotId, System.Int32? clientNo, System.String lotName, System.Double? cost, System.Int32? currencyNo, System.Boolean? onHold, System.Boolean? consignment, System.String notes, System.String lotCode, System.Boolean? inactive, System.Int32? updatedBy, System.Int32? LockForCustomerNo)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Lot", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@LotId", SqlDbType.Int).Value = lotId;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@LotName", SqlDbType.NVarChar).Value = lotName;
				cmd.Parameters.Add("@Cost", SqlDbType.Float).Value = cost;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@OnHold", SqlDbType.Bit).Value = onHold;
				cmd.Parameters.Add("@Consignment", SqlDbType.Bit).Value = consignment;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@LotCode", SqlDbType.NVarChar).Value = lotCode;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@LockForCustomerNo", SqlDbType.Int).Value = LockForCustomerNo;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Lot", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Lot
		/// Calls [usp_update_Lot_Delete]
        /// </summary>
		public override bool UpdateDelete(System.Int32? lotId, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Lot_Delete", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@LotId", SqlDbType.Int).Value = lotId;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Lot", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
        //[001] code start
        /// <summary>
        /// AutoSearch 
        /// Calls [usp_autosearch_Lot]
        /// </summary>
        public override List<LotDetails> AutoSearch(System.Int32? clientId, System.String nameSearch)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_autosearch_Lot", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<LotDetails> lst = new List<LotDetails>();
                while (reader.Read())
                {
                    LotDetails obj = new LotDetails();
                    obj.LotId = GetReaderValue_Int32(reader, "LotId", 0);
                    obj.LotName = GetReaderValue_String(reader, "LotName", "");
                    obj.LotCode = GetReaderValue_String(reader, "LotCode", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Lots", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[001] code end
		
		
		
	}
}