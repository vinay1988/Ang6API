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
	public class SqlShipViaProvider : ShipViaProvider {
		/// <summary>
		/// Delete ShipVia
		/// Calls [usp_delete_ShipVia]
		/// </summary>
		public override bool Delete(System.Int32? shipViaId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_ShipVia", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ShipViaId", SqlDbType.Int).Value = shipViaId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete ShipVia", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDownBuyForClient 
		/// Calls [usp_dropdown_ShipVia_Buy_for_Client]
        /// </summary>
		public override List<ShipViaDetails> DropDownBuyForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_ShipVia_Buy_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ShipViaDetails> lst = new List<ShipViaDetails>();
				while (reader.Read()) {
					ShipViaDetails obj = new ShipViaDetails();
					obj.ShipViaId = GetReaderValue_Int32(reader, "ShipViaId", 0);
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ShipVias", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDownForClient 
		/// Calls [usp_dropdown_ShipVia_for_Client]
        /// </summary>
		public override List<ShipViaDetails> DropDownForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_ShipVia_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ShipViaDetails> lst = new List<ShipViaDetails>();
				while (reader.Read()) {
					ShipViaDetails obj = new ShipViaDetails();
					obj.ShipViaId = GetReaderValue_Int32(reader, "ShipViaId", 0);
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ShipVias", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDownSellForClient 
		/// Calls [usp_dropdown_ShipVia_Sell_for_Client]
        /// </summary>
		public override List<ShipViaDetails> DropDownSellForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_ShipVia_Sell_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ShipViaDetails> lst = new List<ShipViaDetails>();
				while (reader.Read()) {
					ShipViaDetails obj = new ShipViaDetails();
					obj.ShipViaId = GetReaderValue_Int32(reader, "ShipViaId", 0);
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ShipVias", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_ShipVia]
		/// </summary>
        public override Int32 Insert(System.Int32? clientNo, System.String shipViaName, System.String notes, System.String service, System.String shipper, System.Boolean? buy, System.Boolean? sell, System.Double? cost, System.Double? charge, System.String pickUp, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? isSameAsShipCost)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_ShipVia", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@ShipViaName", SqlDbType.NVarChar).Value = shipViaName;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@Service", SqlDbType.NVarChar).Value = service;
				cmd.Parameters.Add("@Shipper", SqlDbType.NVarChar).Value = shipper;
				cmd.Parameters.Add("@Buy", SqlDbType.Bit).Value = buy;
				cmd.Parameters.Add("@Sell", SqlDbType.Bit).Value = sell;
				cmd.Parameters.Add("@Cost", SqlDbType.Float).Value = cost;
				cmd.Parameters.Add("@Charge", SqlDbType.Float).Value = charge;
				cmd.Parameters.Add("@PickUp", SqlDbType.NVarChar).Value = pickUp;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@IsSameAsShipCost", SqlDbType.Bit).Value = isSameAsShipCost;
				cmd.Parameters.Add("@ShipViaId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@ShipViaId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert ShipVia", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_ShipVia]
        /// </summary>
		public override ShipViaDetails Get(System.Int32? shipViaId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_ShipVia", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ShipViaId", SqlDbType.Int).Value = shipViaId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetShipViaFromReader(reader);
					ShipViaDetails obj = new ShipViaDetails();
					obj.ShipViaId = GetReaderValue_Int32(reader, "ShipViaId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Service = GetReaderValue_String(reader, "Service", "");
					obj.Shipper = GetReaderValue_String(reader, "Shipper", "");
					obj.Buy = GetReaderValue_Boolean(reader, "Buy", false);
					obj.Sell = GetReaderValue_Boolean(reader, "Sell", false);
					obj.Cost = GetReaderValue_NullableDouble(reader, "Cost", null);
					obj.Charge = GetReaderValue_NullableDouble(reader, "Charge", null);
					obj.PickUp = GetReaderValue_String(reader, "PickUp", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.IsSameAsShipCost = GetReaderValue_Boolean(reader, "IsSameAsShipCost", false);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ShipVia", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForClient 
		/// Calls [usp_selectAll_ShipVia_for_Client]
        /// </summary>
		public override List<ShipViaDetails> GetListForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_ShipVia_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ShipViaDetails> lst = new List<ShipViaDetails>();
				while (reader.Read()) {
					ShipViaDetails obj = new ShipViaDetails();
					obj.ShipViaId = GetReaderValue_Int32(reader, "ShipViaId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Service = GetReaderValue_String(reader, "Service", "");
					obj.Shipper = GetReaderValue_String(reader, "Shipper", "");
					obj.Buy = GetReaderValue_Boolean(reader, "Buy", false);
					obj.Sell = GetReaderValue_Boolean(reader, "Sell", false);
					obj.Cost = GetReaderValue_NullableDouble(reader, "Cost", null);
					obj.Charge = GetReaderValue_NullableDouble(reader, "Charge", null);
					obj.PickUp = GetReaderValue_String(reader, "PickUp", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.IsSameAsShipCost = GetReaderValue_Boolean(reader, "IsSameAsShipCost", false);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get ShipVias", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update ShipVia
		/// Calls [usp_update_ShipVia]
        /// </summary>
        public override bool Update(System.Int32? shipViaId, System.Int32? clientNo, System.String shipViaName, System.String notes, System.String service, System.String shipper, System.Boolean? buy, System.Boolean? sell, System.Double? cost, System.Double? charge, System.String pickUp, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? isSameAsShipCost)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_ShipVia", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ShipViaId", SqlDbType.Int).Value = shipViaId;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@ShipViaName", SqlDbType.NVarChar).Value = shipViaName;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@Service", SqlDbType.NVarChar).Value = service;
				cmd.Parameters.Add("@Shipper", SqlDbType.NVarChar).Value = shipper;
				cmd.Parameters.Add("@Buy", SqlDbType.Bit).Value = buy;
				cmd.Parameters.Add("@Sell", SqlDbType.Bit).Value = sell;
				cmd.Parameters.Add("@Cost", SqlDbType.Float).Value = cost;
				cmd.Parameters.Add("@Charge", SqlDbType.Float).Value = charge;
				cmd.Parameters.Add("@PickUp", SqlDbType.NVarChar).Value = pickUp;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@IsSameAsShipCost", SqlDbType.Bit).Value = isSameAsShipCost;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update ShipVia", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}