/*
Marker     Changed by      Date         Remarks
[001]      Vinay           11/06/2012   This need to Add Incoterms field in company section
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
	public class SqlCompanyAddressProvider : CompanyAddressProvider {
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_CompanyAddress]
		/// </summary>
        public override Int32 Insert(System.Int32? companyNo, System.Int32? addressNo, System.Int32? shipViaNo, System.String shipViaAccount, System.String notes, System.String shippingNotes, System.Int32? TaxbyAddress, System.Int32? updatedBy, System.Int32? IncotermNo,System.String vatNo, System.String recievingNotes)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_CompanyAddress", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@AddressNo", SqlDbType.Int).Value = addressNo;
				cmd.Parameters.Add("@ShipViaNo", SqlDbType.Int).Value = shipViaNo;
				cmd.Parameters.Add("@ShipViaAccount", SqlDbType.NVarChar).Value = shipViaAccount;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@ShippingNotes", SqlDbType.NVarChar).Value = shippingNotes;
                // ESMS #14
                cmd.Parameters.Add("@TaxbyAddress", SqlDbType.Int).Value = TaxbyAddress;
				//end
                //[001] code start
                cmd.Parameters.Add("@IncotermNo", SqlDbType.Int).Value = IncotermNo;
                //[001] code end
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@VatNo", SqlDbType.NVarChar).Value = vatNo;
                cmd.Parameters.Add("@RecievingNotes", SqlDbType.NVarChar).Value = recievingNotes;
				cmd.Parameters.Add("@CompanyAddressId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@CompanyAddressId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert CompanyAddress", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetByAddress 
		/// Calls [usp_select_CompanyAddress_by_Address]
        /// </summary>
		public override CompanyAddressDetails GetByAddress(System.Int32? addressId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_CompanyAddress_by_Address", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@AddressId", SqlDbType.Int).Value = addressId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCompanyAddressFromReader(reader);
					CompanyAddressDetails obj = new CompanyAddressDetails();
					obj.CompanyAddressId = GetReaderValue_Int32(reader, "CompanyAddressId", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.AddressNo = GetReaderValue_Int32(reader, "AddressNo", 0);
					obj.CeaseDate = GetReaderValue_NullableDateTime(reader, "CeaseDate", null);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.ShipViaAccount = GetReaderValue_String(reader, "ShipViaAccount", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");

                    obj.TaxbyAddress = GetReaderValue_NullableInt32(reader, "TaxbyAddress", null);                     

                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.DefaultBilling = GetReaderValue_Boolean(reader, "DefaultBilling", false);
					obj.DefaultShipping = GetReaderValue_Boolean(reader, "DefaultShipping", false);
					obj.ShippingNotes = GetReaderValue_String(reader, "ShippingNotes", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CompanyAddress", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update CompanyAddress
		/// Calls [usp_update_CompanyAddress]
        /// </summary>
        public override bool Update(System.Int32? companyAddressId, System.Int32? shipViaNo, System.String shipViaAccount, System.String notes, System.String shippingNotes, System.Int32? TaxbyAddress, System.Int32? updatedBy, System.Int32? IncotermNo,System.String vatNo,System.String recievingNotes)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_CompanyAddress", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyAddressId", SqlDbType.Int).Value = companyAddressId;
				cmd.Parameters.Add("@ShipViaNo", SqlDbType.Int).Value = shipViaNo;
				cmd.Parameters.Add("@ShipViaAccount", SqlDbType.NVarChar).Value = shipViaAccount;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@ShippingNotes", SqlDbType.NVarChar).Value = shippingNotes;
               // ESMS #14
                cmd.Parameters.Add("@TaxbyAddress", SqlDbType.Int).Value = TaxbyAddress;
                //end
                //[001] code start
                cmd.Parameters.Add("@IncotermNo", SqlDbType.Int).Value = IncotermNo;
                //[001] code end
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@VatNo", SqlDbType.NVarChar).Value = vatNo;
                cmd.Parameters.Add("@RecievingNotes", SqlDbType.NVarChar).Value = recievingNotes;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update CompanyAddress", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update CompanyAddress
		/// Calls [usp_update_CompanyAddress_CeaseDate]
        /// </summary>
		public override bool UpdateCeaseDate(System.Int32? companyAddressNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_CompanyAddress_CeaseDate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyAddressNo", SqlDbType.Int).Value = companyAddressNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update CompanyAddress", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update CompanyAddress
		/// Calls [usp_update_CompanyAddress_CheckDefault]
        /// </summary>
		public override bool UpdateCheckDefault(System.Int32? companyAddressId, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_CompanyAddress_CheckDefault", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyAddressId", SqlDbType.Int).Value = companyAddressId;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update CompanyAddress", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update CompanyAddress
		/// Calls [usp_update_CompanyAddress_DefaultBilling]
        /// </summary>
		public override bool UpdateDefaultBilling(System.Int32? companyAddressId, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_CompanyAddress_DefaultBilling", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyAddressId", SqlDbType.Int).Value = companyAddressId;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update CompanyAddress", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update CompanyAddress
		/// Calls [usp_update_CompanyAddress_DefaultShipping]
        /// </summary>
		public override bool UpdateDefaultShipping(System.Int32? companyAddressId, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_CompanyAddress_DefaultShipping", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyAddressId", SqlDbType.Int).Value = companyAddressId;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update CompanyAddress", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}