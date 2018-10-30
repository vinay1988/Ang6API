//Marker     Changed by      Date         Remarks
//[001]      Vinay           11/06/2012   This need to Add Incoterms field in company section
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
	public class SqlAddressProvider : AddressProvider {
		/// <summary>
		/// Delete Address
		/// Calls [usp_delete_Address]
		/// </summary>
		public override bool Delete(System.Int32? addressId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Address", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@AddressId", SqlDbType.Int).Value = addressId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Address", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDownForCompany 
		/// Calls [usp_dropdown_Address_for_Company]
        /// </summary>
		public override List<AddressDetails> DropDownForCompany(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_Address_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<AddressDetails> lst = new List<AddressDetails>();
				while (reader.Read()) {
					AddressDetails obj = new AddressDetails();
					obj.AddressId = GetReaderValue_Int32(reader, "AddressId", 0);
					obj.AddressName = GetReaderValue_String(reader, "AddressName", "");
					obj.Line1 = GetReaderValue_String(reader, "Line1", "");
					obj.Line2 = GetReaderValue_String(reader, "Line2", "");
					obj.Line3 = GetReaderValue_String(reader, "Line3", "");
					obj.County = GetReaderValue_String(reader, "County", "");
					obj.City = GetReaderValue_String(reader, "City", "");
					obj.State = GetReaderValue_String(reader, "State", "");
					obj.ZIP = GetReaderValue_String(reader, "ZIP", "");
					obj.CountryName = GetReaderValue_String(reader, "CountryName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Addresss", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_Address]
		/// </summary>
		public override Int32 Insert(System.String addressName, System.String line1, System.String line2, System.String line3, System.String county, System.String city, System.String state, System.Int32? countryNo, System.String zip, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Address", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@AddressName", SqlDbType.NVarChar).Value = addressName;
				cmd.Parameters.Add("@Line1", SqlDbType.NVarChar).Value = line1;
				cmd.Parameters.Add("@Line2", SqlDbType.NVarChar).Value = line2;
				cmd.Parameters.Add("@Line3", SqlDbType.NVarChar).Value = line3;
				cmd.Parameters.Add("@County", SqlDbType.NVarChar).Value = county;
				cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = city;
				cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = state;
				cmd.Parameters.Add("@CountryNo", SqlDbType.Int).Value = countryNo;
				cmd.Parameters.Add("@ZIP", SqlDbType.NVarChar).Value = zip;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@AddressId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@AddressId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Address", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_Address]
        /// </summary>
		public override AddressDetails Get(System.Int32? addressId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Address", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@AddressId", SqlDbType.Int).Value = addressId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetAddressFromReader(reader);
					AddressDetails obj = new AddressDetails();
					obj.AddressId = GetReaderValue_Int32(reader, "AddressId", 0);
					obj.AddressName = GetReaderValue_String(reader, "AddressName", "");
					obj.Line1 = GetReaderValue_String(reader, "Line1", "");
					obj.Line2 = GetReaderValue_String(reader, "Line2", "");
					obj.Line3 = GetReaderValue_String(reader, "Line3", "");
					obj.County = GetReaderValue_String(reader, "County", "");
					obj.City = GetReaderValue_String(reader, "City", "");
					obj.State = GetReaderValue_String(reader, "State", "");
					obj.CountryNo = GetReaderValue_NullableInt32(reader, "CountryNo", null);
					obj.ZIP = GetReaderValue_String(reader, "ZIP", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.CountryName = GetReaderValue_String(reader, "CountryName", "");
                    // ESMS #14
                    obj.TaxbyAddress = GetReaderValue_Int32(reader, "TaxbyAddress", 0);
                    obj.TaxValue = GetReaderValue_String(reader, "TaxName", "");
                    // End 
                    //[001] code start
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    //[001] code end
                   
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Address", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetDefaultBillingForCompany 
		/// Calls [usp_select_Address_DefaultBilling_for_Company]
        /// </summary>
		public override AddressDetails GetDefaultBillingForCompany(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Address_DefaultBilling_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetAddressFromReader(reader);
					AddressDetails obj = new AddressDetails();
					obj.AddressId = GetReaderValue_Int32(reader, "AddressId", 0);
					obj.AddressName = GetReaderValue_String(reader, "AddressName", "");
					obj.Line1 = GetReaderValue_String(reader, "Line1", "");
					obj.Line2 = GetReaderValue_String(reader, "Line2", "");
					obj.Line3 = GetReaderValue_String(reader, "Line3", "");
					obj.County = GetReaderValue_String(reader, "County", "");
					obj.City = GetReaderValue_String(reader, "City", "");
					obj.State = GetReaderValue_String(reader, "State", "");
					obj.CountryNo = GetReaderValue_NullableInt32(reader, "CountryNo", null);
					obj.ZIP = GetReaderValue_String(reader, "ZIP", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.CountryName = GetReaderValue_String(reader, "CountryName", "");
					obj.CompanyAddressId = GetReaderValue_Int32(reader, "CompanyAddressId", 0);
					obj.DefaultBilling = GetReaderValue_Boolean(reader, "DefaultBilling", false);
					obj.DefaultShipping = GetReaderValue_Boolean(reader, "DefaultShipping", false);
					obj.CeaseDate = GetReaderValue_NullableDateTime(reader, "CeaseDate", null);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.ShipViaAccount = GetReaderValue_String(reader, "ShipViaAccount", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.ShippingNotes = GetReaderValue_String(reader, "ShippingNotes", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    // ESMS #14
                    obj.TaxbyAddress = GetReaderValue_Int32(reader, "TaxbyAddress", 0);
                    obj.TaxValue = GetReaderValue_String(reader, "TaxValue", "");
					// End
                    //[001] code start
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    //[001] code end
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Address", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetDefaultShippingForCompany 
		/// Calls [usp_select_Address_DefaultShipping_for_Company]
        /// </summary>
		public override AddressDetails GetDefaultShippingForCompany(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Address_DefaultShipping_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetAddressFromReader(reader);
					AddressDetails obj = new AddressDetails();
					obj.AddressId = GetReaderValue_Int32(reader, "AddressId", 0);
					obj.AddressName = GetReaderValue_String(reader, "AddressName", "");
					obj.Line1 = GetReaderValue_String(reader, "Line1", "");
					obj.Line2 = GetReaderValue_String(reader, "Line2", "");
					obj.Line3 = GetReaderValue_String(reader, "Line3", "");
					obj.County = GetReaderValue_String(reader, "County", "");
					obj.City = GetReaderValue_String(reader, "City", "");
					obj.State = GetReaderValue_String(reader, "State", "");
					obj.CountryNo = GetReaderValue_NullableInt32(reader, "CountryNo", null);
					obj.ZIP = GetReaderValue_String(reader, "ZIP", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.CountryName = GetReaderValue_String(reader, "CountryName", "");
					obj.CompanyAddressId = GetReaderValue_Int32(reader, "CompanyAddressId", 0);
					obj.DefaultBilling = GetReaderValue_Boolean(reader, "DefaultBilling", false);
					obj.DefaultShipping = GetReaderValue_Boolean(reader, "DefaultShipping", false);
					obj.CeaseDate = GetReaderValue_NullableDateTime(reader, "CeaseDate", null);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.ShipViaAccount = GetReaderValue_String(reader, "ShipViaAccount", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.ShippingNotes = GetReaderValue_String(reader, "ShippingNotes", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    /// /// ESMS #14
                    obj.TaxbyAddress = GetReaderValue_Int32(reader, "TaxbyAddress", 0);
                    obj.TaxValue = GetReaderValue_String(reader, "TaxValue", "");
                    // End
                    //[001] code start
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    //[001] code end
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Address", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForCompany 
		/// Calls [usp_select_Address_for_Company]
        /// </summary>
		public override AddressDetails GetForCompany(System.Int32? companyAddressId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Address_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyAddressId", SqlDbType.Int).Value = companyAddressId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetAddressFromReader(reader);
					AddressDetails obj = new AddressDetails();
					obj.AddressId = GetReaderValue_Int32(reader, "AddressId", 0);
					obj.AddressName = GetReaderValue_String(reader, "AddressName", "");
					obj.Line1 = GetReaderValue_String(reader, "Line1", "");
					obj.Line2 = GetReaderValue_String(reader, "Line2", "");
					obj.Line3 = GetReaderValue_String(reader, "Line3", "");
					obj.County = GetReaderValue_String(reader, "County", "");
					obj.City = GetReaderValue_String(reader, "City", "");
					obj.State = GetReaderValue_String(reader, "State", "");
					obj.CountryNo = GetReaderValue_NullableInt32(reader, "CountryNo", null);
					obj.ZIP = GetReaderValue_String(reader, "ZIP", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.CountryName = GetReaderValue_String(reader, "CountryName", "");
					obj.CompanyAddressId = GetReaderValue_Int32(reader, "CompanyAddressId", 0);
					obj.DefaultBilling = GetReaderValue_Boolean(reader, "DefaultBilling", false);
					obj.DefaultShipping = GetReaderValue_Boolean(reader, "DefaultShipping", false);
					obj.CeaseDate = GetReaderValue_NullableDateTime(reader, "CeaseDate", null);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.ShipViaAccount = GetReaderValue_String(reader, "ShipViaAccount", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.ShippingNotes = GetReaderValue_String(reader, "ShippingNotes", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    // ESMS #14
                    obj.TaxbyAddress = GetReaderValue_NullableInt32(reader, "TaxbyAddress", null);
                    obj.TaxValue = GetReaderValue_String(reader, "TaxValue", "");
                    // End
                    //[001] code start
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    //[001] code end
                    obj.VatNo = GetReaderValue_String(reader, "CompanyVatNo", "");
                    obj.RecievingNotes = GetReaderValue_String(reader, "ReceivingNotes", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Address", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForDivision 
		/// Calls [usp_select_Address_for_Division]
        /// </summary>
		public override AddressDetails GetForDivision(System.Int32? divisionId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Address_for_Division", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = divisionId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetAddressFromReader(reader);
					AddressDetails obj = new AddressDetails();
					obj.AddressId = GetReaderValue_Int32(reader, "AddressId", 0);
					obj.AddressName = GetReaderValue_String(reader, "AddressName", "");
					obj.Line1 = GetReaderValue_String(reader, "Line1", "");
					obj.Line2 = GetReaderValue_String(reader, "Line2", "");
					obj.Line3 = GetReaderValue_String(reader, "Line3", "");
					obj.County = GetReaderValue_String(reader, "County", "");
					obj.City = GetReaderValue_String(reader, "City", "");
					obj.State = GetReaderValue_String(reader, "State", "");
					obj.CountryNo = GetReaderValue_NullableInt32(reader, "CountryNo", null);
					obj.ZIP = GetReaderValue_String(reader, "ZIP", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.CountryName = GetReaderValue_String(reader, "CountryName", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Address", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForWarehouse 
		/// Calls [usp_select_Address_for_Warehouse]
        /// </summary>
		public override AddressDetails GetForWarehouse(System.Int32? warehouseId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Address_for_Warehouse", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@WarehouseId", SqlDbType.Int).Value = warehouseId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetAddressFromReader(reader);
					AddressDetails obj = new AddressDetails();
					obj.AddressId = GetReaderValue_Int32(reader, "AddressId", 0);
					obj.AddressName = GetReaderValue_String(reader, "AddressName", "");
					obj.Line1 = GetReaderValue_String(reader, "Line1", "");
					obj.Line2 = GetReaderValue_String(reader, "Line2", "");
					obj.Line3 = GetReaderValue_String(reader, "Line3", "");
					obj.County = GetReaderValue_String(reader, "County", "");
					obj.City = GetReaderValue_String(reader, "City", "");
					obj.State = GetReaderValue_String(reader, "State", "");
					obj.CountryNo = GetReaderValue_NullableInt32(reader, "CountryNo", null);
					obj.ZIP = GetReaderValue_String(reader, "ZIP", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.CountryName = GetReaderValue_String(reader, "CountryName", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Address", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForCompany 
		/// Calls [usp_selectAll_Address_for_Company]
        /// </summary>
		public override List<AddressDetails> GetListForCompany(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Address_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<AddressDetails> lst = new List<AddressDetails>();
				while (reader.Read()) {
					AddressDetails obj = new AddressDetails();
					obj.AddressId = GetReaderValue_Int32(reader, "AddressId", 0);
					obj.AddressName = GetReaderValue_String(reader, "AddressName", "");
					obj.Line1 = GetReaderValue_String(reader, "Line1", "");
					obj.Line2 = GetReaderValue_String(reader, "Line2", "");
					obj.Line3 = GetReaderValue_String(reader, "Line3", "");
					obj.County = GetReaderValue_String(reader, "County", "");
					obj.City = GetReaderValue_String(reader, "City", "");
					obj.State = GetReaderValue_String(reader, "State", "");
					obj.CountryNo = GetReaderValue_NullableInt32(reader, "CountryNo", null);
					obj.ZIP = GetReaderValue_String(reader, "ZIP", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.CountryName = GetReaderValue_String(reader, "CountryName", "");
					obj.CompanyAddressId = GetReaderValue_Int32(reader, "CompanyAddressId", 0);
					obj.DefaultBilling = GetReaderValue_Boolean(reader, "DefaultBilling", false);
					obj.DefaultShipping = GetReaderValue_Boolean(reader, "DefaultShipping", false);
					obj.CeaseDate = GetReaderValue_NullableDateTime(reader, "CeaseDate", null);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.ShipViaAccount = GetReaderValue_String(reader, "ShipViaAccount", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.ShippingNotes = GetReaderValue_String(reader, "ShippingNotes", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    /// /// ESMS #14
                    obj.TaxbyAddress = GetReaderValue_Int32(reader, "TaxbyAddress", 0);
                    // End
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Addresss", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Address
		/// Calls [usp_update_Address]
        /// </summary>
		public override bool Update(System.Int32? addressId, System.String addressName, System.String line1, System.String line2, System.String line3, System.String county, System.String city, System.String state, System.Int32? countryNo, System.String zip, System.Boolean? inactive, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Address", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@AddressId", SqlDbType.Int).Value = addressId;
				cmd.Parameters.Add("@AddressName", SqlDbType.NVarChar).Value = addressName;
				cmd.Parameters.Add("@Line1", SqlDbType.NVarChar).Value = line1;
				cmd.Parameters.Add("@Line2", SqlDbType.NVarChar).Value = line2;
				cmd.Parameters.Add("@Line3", SqlDbType.NVarChar).Value = line3;
				cmd.Parameters.Add("@County", SqlDbType.NVarChar).Value = county;
				cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = city;
				cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = state;
				cmd.Parameters.Add("@CountryNo", SqlDbType.Int).Value = countryNo;
				cmd.Parameters.Add("@ZIP", SqlDbType.NVarChar).Value = zip;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Address", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}