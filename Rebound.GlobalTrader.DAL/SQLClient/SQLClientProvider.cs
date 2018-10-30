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
	public class SqlClientProvider : ClientProvider {
		/// <summary>
		/// Count Client
		/// Calls [usp_count_Client]
		/// </summary>
		public override Int32 Count() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count Client", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete Client
		/// Calls [usp_delete_Client]
		/// </summary>
		public override bool Delete(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Client", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_Client]
		/// </summary>
        public override Int32 Insert(System.String clientName, System.Int32? parentClientNo, System.Int32? currencyNo, System.String telephone, System.String fax, System.String email, System.String url, System.String resaleLicense, System.String companyRegistration, System.String documentFontName, System.Int32? documentFontSize, System.Int32? defaultSiteLanguageNo, System.Int32? updatedBy, System.Int32 localCurrencyNo, System.String clientCode)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientName", SqlDbType.NVarChar).Value = clientName;
				cmd.Parameters.Add("@ParentClientNo", SqlDbType.Int).Value = parentClientNo;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = telephone;
				cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = fax;
				cmd.Parameters.Add("@EMail", SqlDbType.NVarChar).Value = email;
				cmd.Parameters.Add("@URL", SqlDbType.NVarChar).Value = url;
				cmd.Parameters.Add("@ResaleLicense", SqlDbType.NVarChar).Value = resaleLicense;
				cmd.Parameters.Add("@CompanyRegistration", SqlDbType.NVarChar).Value = companyRegistration;
				cmd.Parameters.Add("@DocumentFontName", SqlDbType.NVarChar).Value = documentFontName;
				cmd.Parameters.Add("@DocumentFontSize", SqlDbType.Int).Value = documentFontSize;
				cmd.Parameters.Add("@DefaultSiteLanguageNo", SqlDbType.Int).Value = defaultSiteLanguageNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@LocalCurrencyNo", SqlDbType.Int).Value = localCurrencyNo;
                cmd.Parameters.Add("@ClientCode", SqlDbType.NVarChar).Value = clientCode;
                //cmd.Parameters.Add("@IsPOHub", SqlDbType.Bit).Value = IsPOHub;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@ClientId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Client", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_Client]
        /// </summary>
		public override ClientDetails Get(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetClientFromReader(reader);
					ClientDetails obj = new ClientDetails();
					obj.ClientId = GetReaderValue_Int32(reader, "ClientId", 0);
					obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
					obj.ParentClientNo = GetReaderValue_NullableInt32(reader, "ParentClientNo", null);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
					obj.Fax = GetReaderValue_String(reader, "Fax", "");
					obj.EMail = GetReaderValue_String(reader, "EMail", "");
					obj.URL = GetReaderValue_String(reader, "URL", "");
					obj.ResaleLicense = GetReaderValue_String(reader, "ResaleLicense", "");
					obj.CompanyRegistration = GetReaderValue_String(reader, "CompanyRegistration", "");
					obj.DocumentFontName = GetReaderValue_String(reader, "DocumentFontName", "");
					obj.DocumentFontSize = GetReaderValue_NullableInt32(reader, "DocumentFontSize", null);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.Login = GetReaderValue_String(reader, "Login", "");
					obj.DefaultSiteLanguageNo = GetReaderValue_Int32(reader, "DefaultSiteLanguageNo", 0);
					obj.HasDocumentHeaderImage = GetReaderValue_Boolean(reader, "HasDocumentHeaderImage", false);
					obj.Header = GetReaderValue_String(reader, "Header", "");
					obj.OwnDataVisibleToOthers = GetReaderValue_NullableBoolean(reader, "OwnDataVisibleToOthers", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.NumberOfUsers = GetReaderValue_NullableInt32(reader, "NumberOfUsers", null);
                    //obj.IsPOHub = GetReaderValue_Boolean(reader, "IsPOHub", false);
                    
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Client", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetLastMonthGP 
		/// Calls [usp_select_Client_LastMonth_GP]
        /// </summary>
		public override ClientDetails GetLastMonthGP(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Client_LastMonth_GP", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetClientFromReader(reader);
					ClientDetails obj = new ClientDetails();
					obj.OpenShippingCost = GetReaderValue_Double(reader, "OpenShippingCost", 0);
					obj.OpenFreightCharge = GetReaderValue_Double(reader, "OpenFreightCharge", 0);
					obj.OpenLandedCost = GetReaderValue_Double(reader, "OpenLandedCost", 0);
					obj.OpenSalesValue = GetReaderValue_Double(reader, "OpenSalesValue", 0);
					obj.ShippedShippingCost = GetReaderValue_Double(reader, "ShippedShippingCost", 0);
					obj.ShippedFreightCharge = GetReaderValue_Double(reader, "ShippedFreightCharge", 0);
					obj.ShippedLandedCost = GetReaderValue_Double(reader, "ShippedLandedCost", 0);
					obj.ShippedSalesValue = GetReaderValue_Double(reader, "ShippedSalesValue", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Client", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetLastYearGP 
		/// Calls [usp_select_Client_LastYear_GP]
        /// </summary>
		public override ClientDetails GetLastYearGP(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Client_LastYear_GP", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetClientFromReader(reader);
					ClientDetails obj = new ClientDetails();
					obj.OpenShippingCost = GetReaderValue_Double(reader, "OpenShippingCost", 0);
					obj.OpenFreightCharge = GetReaderValue_Double(reader, "OpenFreightCharge", 0);
					obj.OpenLandedCost = GetReaderValue_Double(reader, "OpenLandedCost", 0);
					obj.OpenSalesValue = GetReaderValue_Double(reader, "OpenSalesValue", 0);
					obj.ShippedShippingCost = GetReaderValue_Double(reader, "ShippedShippingCost", 0);
					obj.ShippedFreightCharge = GetReaderValue_Double(reader, "ShippedFreightCharge", 0);
					obj.ShippedLandedCost = GetReaderValue_Double(reader, "ShippedLandedCost", 0);
					obj.ShippedSalesValue = GetReaderValue_Double(reader, "ShippedSalesValue", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Client", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetNextMonthGP 
		/// Calls [usp_select_Client_NextMonth_GP]
        /// </summary>
		public override ClientDetails GetNextMonthGP(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Client_NextMonth_GP", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetClientFromReader(reader);
					ClientDetails obj = new ClientDetails();
					obj.OpenShippingCost = GetReaderValue_Double(reader, "OpenShippingCost", 0);
					obj.OpenFreightCharge = GetReaderValue_Double(reader, "OpenFreightCharge", 0);
					obj.OpenLandedCost = GetReaderValue_Double(reader, "OpenLandedCost", 0);
					obj.OpenSalesValue = GetReaderValue_Double(reader, "OpenSalesValue", 0);
					obj.ShippedShippingCost = GetReaderValue_Double(reader, "ShippedShippingCost", 0);
					obj.ShippedFreightCharge = GetReaderValue_Double(reader, "ShippedFreightCharge", 0);
					obj.ShippedLandedCost = GetReaderValue_Double(reader, "ShippedLandedCost", 0);
					obj.ShippedSalesValue = GetReaderValue_Double(reader, "ShippedSalesValue", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Client", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetThisMonthGP 
		/// Calls [usp_select_Client_ThisMonth_GP]
        /// </summary>
		public override ClientDetails GetThisMonthGP(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Client_ThisMonth_GP", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetClientFromReader(reader);
					ClientDetails obj = new ClientDetails();
					obj.OpenShippingCost = GetReaderValue_Double(reader, "OpenShippingCost", 0);
					obj.OpenFreightCharge = GetReaderValue_Double(reader, "OpenFreightCharge", 0);
					obj.OpenLandedCost = GetReaderValue_Double(reader, "OpenLandedCost", 0);
					obj.OpenSalesValue = GetReaderValue_Double(reader, "OpenSalesValue", 0);
					obj.ShippedShippingCost = GetReaderValue_Double(reader, "ShippedShippingCost", 0);
					obj.ShippedFreightCharge = GetReaderValue_Double(reader, "ShippedFreightCharge", 0);
					obj.ShippedLandedCost = GetReaderValue_Double(reader, "ShippedLandedCost", 0);
					obj.ShippedSalesValue = GetReaderValue_Double(reader, "ShippedSalesValue", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Client", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetThisYearGP 
		/// Calls [usp_select_Client_ThisYear_GP]
        /// </summary>
		public override ClientDetails GetThisYearGP(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Client_ThisYear_GP", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetClientFromReader(reader);
					ClientDetails obj = new ClientDetails();
					obj.OpenShippingCost = GetReaderValue_Double(reader, "OpenShippingCost", 0);
					obj.OpenFreightCharge = GetReaderValue_Double(reader, "OpenFreightCharge", 0);
					obj.OpenLandedCost = GetReaderValue_Double(reader, "OpenLandedCost", 0);
					obj.OpenSalesValue = GetReaderValue_Double(reader, "OpenSalesValue", 0);
					obj.ShippedShippingCost = GetReaderValue_Double(reader, "ShippedShippingCost", 0);
					obj.ShippedFreightCharge = GetReaderValue_Double(reader, "ShippedFreightCharge", 0);
					obj.ShippedLandedCost = GetReaderValue_Double(reader, "ShippedLandedCost", 0);
					obj.ShippedSalesValue = GetReaderValue_Double(reader, "ShippedSalesValue", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Client", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_Client]
        /// </summary>
		public override List<ClientDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ClientDetails> lst = new List<ClientDetails>();
				while (reader.Read()) {
					ClientDetails obj = new ClientDetails();
					obj.ClientId = GetReaderValue_Int32(reader, "ClientId", 0);
					obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
					obj.ParentClientNo = GetReaderValue_NullableInt32(reader, "ParentClientNo", null);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
					obj.Fax = GetReaderValue_String(reader, "Fax", "");
					obj.EMail = GetReaderValue_String(reader, "EMail", "");
					obj.URL = GetReaderValue_String(reader, "URL", "");
					obj.ResaleLicense = GetReaderValue_String(reader, "ResaleLicense", "");
					obj.CompanyRegistration = GetReaderValue_String(reader, "CompanyRegistration", "");
					obj.DocumentFontName = GetReaderValue_String(reader, "DocumentFontName", "");
					obj.DocumentFontSize = GetReaderValue_NullableInt32(reader, "DocumentFontSize", null);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.Login = GetReaderValue_String(reader, "Login", "");
					obj.DefaultSiteLanguageNo = GetReaderValue_Int32(reader, "DefaultSiteLanguageNo", 0);
					obj.HasDocumentHeaderImage = GetReaderValue_Boolean(reader, "HasDocumentHeaderImage", false);
					obj.Header = GetReaderValue_String(reader, "Header", "");
					obj.OwnDataVisibleToOthers = GetReaderValue_NullableBoolean(reader, "OwnDataVisibleToOthers", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.NumberOfUsers = GetReaderValue_NullableInt32(reader, "NumberOfUsers", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Clients", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListActive 
		/// Calls [usp_selectAll_Client_Active]
        /// </summary>
		public override List<ClientDetails> GetListActive() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Client_Active", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<ClientDetails> lst = new List<ClientDetails>();
				while (reader.Read()) {
					ClientDetails obj = new ClientDetails();
					obj.ClientId = GetReaderValue_Int32(reader, "ClientId", 0);
					obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
					obj.ParentClientNo = GetReaderValue_NullableInt32(reader, "ParentClientNo", null);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
					obj.Fax = GetReaderValue_String(reader, "Fax", "");
					obj.EMail = GetReaderValue_String(reader, "EMail", "");
					obj.URL = GetReaderValue_String(reader, "URL", "");
					obj.ResaleLicense = GetReaderValue_String(reader, "ResaleLicense", "");
					obj.CompanyRegistration = GetReaderValue_String(reader, "CompanyRegistration", "");
					obj.DocumentFontName = GetReaderValue_String(reader, "DocumentFontName", "");
					obj.DocumentFontSize = GetReaderValue_NullableInt32(reader, "DocumentFontSize", null);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.Login = GetReaderValue_String(reader, "Login", "");
					obj.DefaultSiteLanguageNo = GetReaderValue_Int32(reader, "DefaultSiteLanguageNo", 0);
					obj.HasDocumentHeaderImage = GetReaderValue_Boolean(reader, "HasDocumentHeaderImage", false);
					obj.Header = GetReaderValue_String(reader, "Header", "");
					obj.OwnDataVisibleToOthers = GetReaderValue_NullableBoolean(reader, "OwnDataVisibleToOthers", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.NumberOfUsers = GetReaderValue_NullableInt32(reader, "NumberOfUsers", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Clients", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Client
		/// Calls [usp_update_Client]
        /// </summary>
		public override bool Update(System.Int32? clientId, System.String clientName, System.Int32? parentClientNo, System.Int32? currencyNo, System.String telephone, System.String fax, System.String email, System.String url, System.String resaleLicense, System.String companyRegistration, System.String documentFontName, System.Int32? documentFontSize, System.Boolean? inactive, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@ClientName", SqlDbType.NVarChar).Value = clientName;
				cmd.Parameters.Add("@ParentClientNo", SqlDbType.Int).Value = parentClientNo;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = telephone;
				cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = fax;
				cmd.Parameters.Add("@EMail", SqlDbType.NVarChar).Value = email;
				cmd.Parameters.Add("@URL", SqlDbType.NVarChar).Value = url;
				cmd.Parameters.Add("@ResaleLicense", SqlDbType.NVarChar).Value = resaleLicense;
				cmd.Parameters.Add("@CompanyRegistration", SqlDbType.NVarChar).Value = companyRegistration;
				cmd.Parameters.Add("@DocumentFontName", SqlDbType.NVarChar).Value = documentFontName;
				cmd.Parameters.Add("@DocumentFontSize", SqlDbType.Int).Value = documentFontSize;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Client", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Client
		/// Calls [usp_update_Client_DocumentHeaderImage]
        /// </summary>
		public override bool UpdateDocumentHeaderImage(System.Int32? clientNo, System.Boolean? hasDocumentHeaderImage, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Client_DocumentHeaderImage", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@HasDocumentHeaderImage", SqlDbType.Bit).Value = hasDocumentHeaderImage;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Client", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Client
		/// Calls [usp_update_Client_Inactive]
        /// </summary>
		public override bool UpdateInactive(System.Int32? clientId, System.Boolean? inactive, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Client_Inactive", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Client", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Client
		/// Calls [usp_update_Client_OwnDataVisibleToOthers]
        /// </summary>
		public override bool UpdateOwnDataVisibleToOthers(System.Int32? clientNo, System.Boolean? ownDataVisibleToOthers, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Client_OwnDataVisibleToOthers", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@OwnDataVisibleToOthers", SqlDbType.Bit).Value = ownDataVisibleToOthers;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Client", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}