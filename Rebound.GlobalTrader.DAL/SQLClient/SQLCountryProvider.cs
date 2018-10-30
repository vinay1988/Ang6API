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
	public class SqlCountryProvider : CountryProvider {
		/// <summary>
		/// Delete Country
		/// Calls [usp_delete_Country]
		/// </summary>
		public override bool Delete(System.Int32? countryId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Country", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = countryId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Country", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDownForClient 
		/// Calls [usp_dropdown_Country_for_Client]
        /// </summary>
		public override List<CountryDetails> DropDownForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_Country_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CountryDetails> lst = new List<CountryDetails>();
				while (reader.Read()) {
					CountryDetails obj = new CountryDetails();
					obj.CountryId = GetReaderValue_Int32(reader, "CountryId", 0);
					obj.CountryName = GetReaderValue_String(reader, "CountryName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Countrys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_Country]
		/// </summary>
		public override Int32 Insert(System.String countryName, System.String notes, System.String telephonePrefix, System.Boolean? duty, System.Int32? taxNo, System.Double? shippingCost, System.Int32? clientNo, System.Int32? globalCountryNo, System.Int32? deliveryLeadTimeAir, System.Int32? deliveryLeadTimeSurface, System.Boolean? isPriorityForLists, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Country", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CountryName", SqlDbType.NVarChar).Value = countryName;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@TelephonePrefix", SqlDbType.NVarChar).Value = telephonePrefix;
				cmd.Parameters.Add("@Duty", SqlDbType.Bit).Value = duty;
				cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
				cmd.Parameters.Add("@ShippingCost", SqlDbType.Float).Value = shippingCost;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@GlobalCountryNo", SqlDbType.Int).Value = globalCountryNo;
				cmd.Parameters.Add("@DeliveryLeadTimeAir", SqlDbType.Int).Value = deliveryLeadTimeAir;
				cmd.Parameters.Add("@DeliveryLeadTimeSurface", SqlDbType.Int).Value = deliveryLeadTimeSurface;
				cmd.Parameters.Add("@IsPriorityForLists", SqlDbType.Bit).Value = isPriorityForLists;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@CountryId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@CountryId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Country", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_Country]
        /// </summary>
		public override CountryDetails Get(System.Int32? countryId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Country", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = countryId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCountryFromReader(reader);
					CountryDetails obj = new CountryDetails();
					obj.CountryId = GetReaderValue_Int32(reader, "CountryId", 0);
					obj.CountryName = GetReaderValue_String(reader, "CountryName", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.TelephonePrefix = GetReaderValue_String(reader, "TelephonePrefix", "");
					obj.Duty = GetReaderValue_Boolean(reader, "Duty", false);
					obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
					obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.GlobalCountryNo = GetReaderValue_NullableInt32(reader, "GlobalCountryNo", null);
					obj.DeliveryLeadTimeAir = GetReaderValue_NullableInt32(reader, "DeliveryLeadTimeAir", null);
					obj.DeliveryLeadTimeSurface = GetReaderValue_NullableInt32(reader, "DeliveryLeadTimeSurface", null);
					obj.IsPriorityForLists = GetReaderValue_Boolean(reader, "IsPriorityForLists", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.ShipSurchargePer = GetReaderValue_NullableDouble(reader, "ShippingSurchargePercent", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Country", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetShippingCost 
		/// Calls [usp_select_Country_ShippingCost]
        /// </summary>
		public override CountryDetails GetShippingCost(System.Int32? countryId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Country_ShippingCost", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = countryId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCountryFromReader(reader);
					CountryDetails obj = new CountryDetails();
					obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Country", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForClient 
		/// Calls [usp_selectAll_Country_for_Client]
        /// </summary>
		public override List<CountryDetails> GetListForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Country_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CountryDetails> lst = new List<CountryDetails>();
				while (reader.Read()) {
					CountryDetails obj = new CountryDetails();
					obj.CountryId = GetReaderValue_Int32(reader, "CountryId", 0);
					obj.CountryName = GetReaderValue_String(reader, "CountryName", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.TelephonePrefix = GetReaderValue_String(reader, "TelephonePrefix", "");
					obj.Duty = GetReaderValue_Boolean(reader, "Duty", false);
					obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
					obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.GlobalCountryNo = GetReaderValue_NullableInt32(reader, "GlobalCountryNo", null);
					obj.DeliveryLeadTimeAir = GetReaderValue_NullableInt32(reader, "DeliveryLeadTimeAir", null);
					obj.DeliveryLeadTimeSurface = GetReaderValue_NullableInt32(reader, "DeliveryLeadTimeSurface", null);
					obj.IsPriorityForLists = GetReaderValue_Boolean(reader, "IsPriorityForLists", false);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Countrys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Country
		/// Calls [usp_update_Country]
        /// </summary>
		public override bool Update(System.Int32? countryId, System.String countryName, System.String notes, System.String telephonePrefix, System.Boolean? duty, System.Int32? taxNo, System.Double? shippingCost, System.Int32? deliveryLeadTimeAir, System.Int32? deliveryLeadTimeSurface, System.Boolean? isPriorityForLists, System.Boolean? inactive, System.Int32? updatedBy, System.Double? shipSurChargePer) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Country", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CountryId", SqlDbType.Int).Value = countryId;
				cmd.Parameters.Add("@CountryName", SqlDbType.NVarChar).Value = countryName;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@TelephonePrefix", SqlDbType.NVarChar).Value = telephonePrefix;
				cmd.Parameters.Add("@Duty", SqlDbType.Bit).Value = duty;
				cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
				cmd.Parameters.Add("@ShippingCost", SqlDbType.Float).Value = shippingCost;
				cmd.Parameters.Add("@DeliveryLeadTimeAir", SqlDbType.Int).Value = deliveryLeadTimeAir;
				cmd.Parameters.Add("@DeliveryLeadTimeSurface", SqlDbType.Int).Value = deliveryLeadTimeSurface;
				cmd.Parameters.Add("@IsPriorityForLists", SqlDbType.Bit).Value = isPriorityForLists;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@ShipSurChargePer", SqlDbType.Float).Value = shipSurChargePer;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Country", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}


        /// <summary>
        /// DropDownForRegion 
        /// Calls [usp_dropdown_Region]
        /// </summary>
        public override List<CountryDetails> DropDownForRegion()
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdown_Region", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                //cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CountryDetails> lst = new List<CountryDetails>();
                while (reader.Read())
                {
                    CountryDetails obj = new CountryDetails();
                    obj.RegionId = GetReaderValue_Int32(reader, "RegionId", 0);
                    obj.RegionName = GetReaderValue_String(reader, "RegionName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Regions", sqlex);
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