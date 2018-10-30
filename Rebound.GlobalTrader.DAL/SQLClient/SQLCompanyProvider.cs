/**********************************************************************************************
Marker     changed by      date         Remarks
[001]      Abhinav       02/09/20011   ESMS Ref:12 - Add new field "Company Registration No" 
[002]      Vinay           07/05/2012   This need to upload pdf document for company section
[003]      Vinay           03/07/2013   CR:- Supplier Invoice
[004]      Abhinav        02/17/2014   ESMS Ref:100 - Add new field to Compnay Form 
[005]      Abhinav        02/21/2014   ESMS Ref: -  Add new field to Compnay Form  for Traceability required
[006]      Vinay          24/03/2014     ESMS Ref:106 -  Add new field(EARI Member and EARI Reported) to Compnay Form  
[007]      Vinay          25/03/2014     ESMS Ref:107 -  Add provision to Default Shipping from Country 
[008]      Shashi Keshar  21/01/2016     Added Insurance information in UpdateSales Need to add Insurance File No and Insured Amount
[009]      Shashi Keshar  14/10/2016     Combobox  POApproveSuppliers 
[010]      Suhail          02/05/2018   Added Credit Limit2  
[011]      Aashu          06/06/2018    Added supplier warranty,NonPreferredCompany
[012]      Aashu          13-Sep-2018    [REB-12820]:Provision to add Global Security on Contact Section
* **********************************************************************************************/

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
	public class SqlCompanyProvider : CompanyProvider {
        /// <summary>
        /// AutoSearch 
		/// Calls [usp_autosearch_Company]
        /// </summary>
		public override List<CompanyDetails> AutoSearch(System.Int32? clientId, System.String nameSearch) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_autosearch_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CompanyDetails> lst = new List<CompanyDetails>();
				while (reader.Read()) {
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.FullName = GetReaderValue_String(reader, "FullName", "");
                    //obj.EMail = GetReaderValue_String(reader, "Email", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Companys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// AutoSearch 
        /// Calls [usp_autosearch_SaleCompany]
        /// </summary>
        public override List<CompanyDetails> AutoSearchSale(System.Int32? clientId, System.String nameSearch)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_autosearch_SaleCompany", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CompanyDetails> lst = new List<CompanyDetails>();
                while (reader.Read())
                {
                    CompanyDetails obj = new CompanyDetails();
                    obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.FullName = GetReaderValue_String(reader, "FullName", "");
                    //obj.EMail = GetReaderValue_String(reader, "Email", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Companys", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		
		
		
        /// <summary>
        /// AutoSearchForCustomers 
		/// Calls [usp_autosearch_Company_for_Customers]
        /// </summary>
		public override List<CompanyDetails> AutoSearchForCustomers(System.Int32? clientId, System.String nameSearch) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_autosearch_Company_for_Customers", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CompanyDetails> lst = new List<CompanyDetails>();
				while (reader.Read()) {
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.FullName = GetReaderValue_String(reader, "FullName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Companys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// AutoSearchForProspects 
		/// Calls [usp_autosearch_Company_for_Prospects]
        /// </summary>
		public override List<CompanyDetails> AutoSearchForProspects(System.Int32? clientId, System.String nameSearch) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_autosearch_Company_for_Prospects", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CompanyDetails> lst = new List<CompanyDetails>();
				while (reader.Read()) {
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.FullName = GetReaderValue_String(reader, "FullName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Companys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// AutoSearchForSuppliers 
		/// Calls [usp_autosearch_Company_for_Suppliers]
        /// </summary>
		public override List<CompanyDetails> AutoSearchForSuppliers(System.Int32? clientId, System.String nameSearch) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_autosearch_Company_for_Suppliers", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CompanyDetails> lst = new List<CompanyDetails>();
				while (reader.Read()) {
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.FullName = GetReaderValue_String(reader, "FullName", "");
                    obj.EMail = GetReaderValue_String(reader, "Email", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Companys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

      //  [009] Start Here

        /// <summary>
        /// AutoSearchForPOApproveSuppliers 
        /// Calls [usp_autosearch_Company_for_POApproveSuppliers]
        /// </summary>
        public override List<CompanyDetails> AutoSearchForPOApproveSuppliers(System.Int32? clientId, System.String nameSearch)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_autosearch_Company_for_POApproveSuppliers", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CompanyDetails> lst = new List<CompanyDetails>();
                while (reader.Read())
                {
                    CompanyDetails obj = new CompanyDetails();
                    obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.FullName = GetReaderValue_String(reader, "FullName", "");
                    obj.EMail = GetReaderValue_String(reader, "Email", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Companys", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        //  [009] End  Here
        /// <summary>
        /// AutoSearchForAllSuppliers 
        /// Calls [usp_autosearch_Company_for_AllSuppliers]
        /// </summary>
        public override List<CompanyDetails> AutoSearchForAllSuppliers(System.Int32? clientId, System.String nameSearch)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_autosearch_Company_for_AllSuppliers", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CompanyDetails> lst = new List<CompanyDetails>();
                while (reader.Read())
                {
                    CompanyDetails obj = new CompanyDetails();
                    obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.FullName = GetReaderValue_String(reader, "FullName", "");
                    obj.EMail = GetReaderValue_String(reader, "Email", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Companys", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		
		
		/// <summary>
		/// Count Company
		/// Calls [usp_count_Company_as_Customers_by_Client]
		/// </summary>
		public override Int32 CountAsCustomersByClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_Company_as_Customers_by_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Count Company
		/// Calls [usp_count_Company_as_Prospects_by_Client]
		/// </summary>
		public override Int32 CountAsProspectsByClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_Company_as_Prospects_by_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Count Company
		/// Calls [usp_count_Company_as_Suppliers_by_Client]
		/// </summary>
		public override Int32 CountAsSuppliersByClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_Company_as_Suppliers_by_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Count Company
		/// Calls [usp_count_Company_by_Client]
		/// </summary>
		public override Int32 CountByClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_Company_by_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DataListNugget 
		/// Calls [usp_datalistnugget_Company]
        /// </summary>
		public override List<CompanyDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nameSearch, System.String typeSearch, System.String citySearch, System.String countrySearch, System.Int32? salesmanSearch, System.Int32? customerRatingLo, System.Int32? customerRatingHi, System.Int32? supplierRatingLo, System.Int32? supplierRatingHi, System.String customerCode, System.String telNo, System.String Zipcode) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@TeamId", SqlDbType.Int).Value = teamId;
				cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = divisionId;
				cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
				cmd.Parameters.Add("@TypeSearch", SqlDbType.NVarChar).Value = typeSearch;
				cmd.Parameters.Add("@CitySearch", SqlDbType.NVarChar).Value = citySearch;
				cmd.Parameters.Add("@CountrySearch", SqlDbType.NVarChar).Value = countrySearch;
				cmd.Parameters.Add("@SalesmanSearch", SqlDbType.Int).Value = salesmanSearch;
				cmd.Parameters.Add("@CustomerRatingLo", SqlDbType.Int).Value = customerRatingLo;
				cmd.Parameters.Add("@CustomerRatingHi", SqlDbType.Int).Value = customerRatingHi;
				cmd.Parameters.Add("@SupplierRatingLo", SqlDbType.Int).Value = supplierRatingLo;
				cmd.Parameters.Add("@SupplierRatingHi", SqlDbType.Int).Value = supplierRatingHi;
				cmd.Parameters.Add("@CustomerCode", SqlDbType.NVarChar).Value = customerCode;
				cmd.Parameters.Add("@TelNo", SqlDbType.NVarChar).Value = telNo;
                cmd.Parameters.Add("@ZIP", SqlDbType.NVarChar).Value = Zipcode;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CompanyDetails> lst = new List<CompanyDetails>();
				while (reader.Read()) {
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
					obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
					obj.OnStop = GetReaderValue_NullableBoolean(reader, "OnStop", null);
					obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
					obj.CompanyType = GetReaderValue_String(reader, "CompanyType", "");
					obj.City = GetReaderValue_String(reader, "City", "");
					obj.Country = GetReaderValue_String(reader, "Country", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.DaysSinceContact = GetReaderValue_NullableInt32(reader, "DaysSinceContact", null);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.Zipcode = GetReaderValue_String(reader, "ZIP", "");
                    //02 April
                    obj.SalesGrossProfit = GetReaderValue_Double(reader, "SalesGrossProfit", 0);
                    obj.SalesTurnover = GetReaderValue_Double(reader, "SalesTurnover", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Companys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DataListNuggetAsCustomers 
		/// Calls [usp_datalistnugget_Company_as_Customers]
        /// </summary>
		public override List<CompanyDetails> DataListNuggetAsCustomers(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nameSearch, System.String typeSearch, System.String citySearch, System.String countrySearch, System.Int32? salesmanSearch, System.Int32? customerRatingLo, System.Int32? customerRatingHi, System.Int32? supplierRatingLo, System.Int32? supplierRatingHi, System.String customerCode, System.String telNo, System.String Zipcode) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_Company_as_Customers", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@TeamId", SqlDbType.Int).Value = teamId;
				cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = divisionId;
				cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
				cmd.Parameters.Add("@TypeSearch", SqlDbType.NVarChar).Value = typeSearch;
				cmd.Parameters.Add("@CitySearch", SqlDbType.NVarChar).Value = citySearch;
				cmd.Parameters.Add("@CountrySearch", SqlDbType.NVarChar).Value = countrySearch;
				cmd.Parameters.Add("@SalesmanSearch", SqlDbType.Int).Value = salesmanSearch;
				cmd.Parameters.Add("@CustomerRatingLo", SqlDbType.Int).Value = customerRatingLo;
				cmd.Parameters.Add("@CustomerRatingHi", SqlDbType.Int).Value = customerRatingHi;
				cmd.Parameters.Add("@SupplierRatingLo", SqlDbType.Int).Value = supplierRatingLo;
				cmd.Parameters.Add("@SupplierRatingHi", SqlDbType.Int).Value = supplierRatingHi;
				cmd.Parameters.Add("@CustomerCode", SqlDbType.NVarChar).Value = customerCode;
				cmd.Parameters.Add("@TelNo", SqlDbType.NVarChar).Value = telNo;
                cmd.Parameters.Add("@ZIP", SqlDbType.NVarChar).Value = Zipcode;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CompanyDetails> lst = new List<CompanyDetails>();
				while (reader.Read()) {
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
					obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
					obj.OnStop = GetReaderValue_NullableBoolean(reader, "OnStop", null);
					obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
					obj.CompanyType = GetReaderValue_String(reader, "CompanyType", "");
					obj.City = GetReaderValue_String(reader, "City", "");
					obj.Country = GetReaderValue_String(reader, "Country", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.DaysSinceContact = GetReaderValue_NullableInt32(reader, "DaysSinceContact", null);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.Zipcode = GetReaderValue_String(reader, "ZIP", "");
                    //02 April
                    obj.SalesGrossProfit = GetReaderValue_Double(reader, "SalesGrossProfit", 0);
                    obj.SalesTurnover = GetReaderValue_Double(reader, "SalesTurnover", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Companys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DataListNuggetAsProspects 
		/// Calls [usp_datalistnugget_Company_as_Prospects]
        /// </summary>
		public override List<CompanyDetails> DataListNuggetAsProspects(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nameSearch, System.String typeSearch, System.String citySearch, System.String countrySearch, System.Int32? salesmanSearch, System.Int32? customerRatingLo, System.Int32? customerRatingHi, System.Int32? supplierRatingLo, System.Int32? supplierRatingHi, System.String customerCode, System.String telNo, System.String Zipcode) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_Company_as_Prospects", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@TeamId", SqlDbType.Int).Value = teamId;
				cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = divisionId;
				cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
				cmd.Parameters.Add("@TypeSearch", SqlDbType.NVarChar).Value = typeSearch;
				cmd.Parameters.Add("@CitySearch", SqlDbType.NVarChar).Value = citySearch;
				cmd.Parameters.Add("@CountrySearch", SqlDbType.NVarChar).Value = countrySearch;
				cmd.Parameters.Add("@SalesmanSearch", SqlDbType.Int).Value = salesmanSearch;
				cmd.Parameters.Add("@CustomerRatingLo", SqlDbType.Int).Value = customerRatingLo;
				cmd.Parameters.Add("@CustomerRatingHi", SqlDbType.Int).Value = customerRatingHi;
				cmd.Parameters.Add("@SupplierRatingLo", SqlDbType.Int).Value = supplierRatingLo;
				cmd.Parameters.Add("@SupplierRatingHi", SqlDbType.Int).Value = supplierRatingHi;
				cmd.Parameters.Add("@CustomerCode", SqlDbType.NVarChar).Value = customerCode;
				cmd.Parameters.Add("@TelNo", SqlDbType.NVarChar).Value = telNo;                
                cmd.Parameters.Add("@ZIP", SqlDbType.NVarChar).Value = Zipcode;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CompanyDetails> lst = new List<CompanyDetails>();
				while (reader.Read()) {
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
					obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
					obj.OnStop = GetReaderValue_NullableBoolean(reader, "OnStop", null);
					obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
					obj.CompanyType = GetReaderValue_String(reader, "CompanyType", "");
					obj.City = GetReaderValue_String(reader, "City", "");
					obj.Country = GetReaderValue_String(reader, "Country", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.DaysSinceContact = GetReaderValue_NullableInt32(reader, "DaysSinceContact", null);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.Zipcode = GetReaderValue_String(reader, "ZIP", "");
                    //02 April
                    obj.SalesGrossProfit = GetReaderValue_Double(reader, "SalesGrossProfit", 0);
                    obj.SalesTurnover = GetReaderValue_Double(reader, "SalesTurnover", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Companys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DataListNuggetAsSuppliers 
		/// Calls [usp_datalistnugget_Company_as_Suppliers]
        /// </summary>
		public override List<CompanyDetails> DataListNuggetAsSuppliers(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nameSearch, System.String typeSearch, System.String citySearch, System.String countrySearch, System.Int32? salesmanSearch, System.Int32? customerRatingLo, System.Int32? customerRatingHi, System.Int32? supplierRatingLo, System.Int32? supplierRatingHi, System.String customerCode, System.String telNo, System.String Zipcode) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_Company_as_Suppliers", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@TeamId", SqlDbType.Int).Value = teamId;
				cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = divisionId;
				cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
				cmd.Parameters.Add("@TypeSearch", SqlDbType.NVarChar).Value = typeSearch;
				cmd.Parameters.Add("@CitySearch", SqlDbType.NVarChar).Value = citySearch;
				cmd.Parameters.Add("@CountrySearch", SqlDbType.NVarChar).Value = countrySearch;
				cmd.Parameters.Add("@SalesmanSearch", SqlDbType.Int).Value = salesmanSearch;
				cmd.Parameters.Add("@CustomerRatingLo", SqlDbType.Int).Value = customerRatingLo;
				cmd.Parameters.Add("@CustomerRatingHi", SqlDbType.Int).Value = customerRatingHi;
				cmd.Parameters.Add("@SupplierRatingLo", SqlDbType.Int).Value = supplierRatingLo;
				cmd.Parameters.Add("@SupplierRatingHi", SqlDbType.Int).Value = supplierRatingHi;
				cmd.Parameters.Add("@CustomerCode", SqlDbType.NVarChar).Value = customerCode;
				cmd.Parameters.Add("@TelNo", SqlDbType.NVarChar).Value = telNo;
                cmd.Parameters.Add("@ZIP", SqlDbType.NVarChar).Value = Zipcode;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CompanyDetails> lst = new List<CompanyDetails>();
				while (reader.Read()) {
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
					obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
					obj.OnStop = GetReaderValue_NullableBoolean(reader, "OnStop", null);
					obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
					obj.CompanyType = GetReaderValue_String(reader, "CompanyType", "");
					obj.City = GetReaderValue_String(reader, "City", "");
					obj.Country = GetReaderValue_String(reader, "Country", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.DaysSinceContact = GetReaderValue_NullableInt32(reader, "DaysSinceContact", null);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.Zipcode = GetReaderValue_String(reader, "ZIP", "");
                    //02 April
                    obj.SalesGrossProfit = GetReaderValue_Double(reader, "SalesGrossProfit", 0);
                    obj.SalesTurnover = GetReaderValue_Double(reader, "SalesTurnover", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Companys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete Company
		/// Calls [usp_delete_Company]
		/// </summary>
		public override bool Delete(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DropDownForClient 
		/// Calls [usp_dropdown_Company_for_Client]
        /// </summary>
		public override List<CompanyDetails> DropDownForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_dropdown_Company_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CompanyDetails> lst = new List<CompanyDetails>();
				while (reader.Read()) {
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Companys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// DropDownForClient 
        /// Calls [usp_dropdown_Company_for_ClientNPR]
        /// </summary>
        public override List<CompanyDetails> DropDownForClientNPR(System.Int32? goodsinLineNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdown_Company_for_ClientNPR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@GoodsInlineNo", SqlDbType.Int).Value = goodsinLineNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CompanyDetails> lst = new List<CompanyDetails>();
                while (reader.Read())
                {
                    CompanyDetails obj = new CompanyDetails();
                    obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Companys", sqlex);
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
		/// Calls [usp_insert_Company]
		/// </summary>
        /// [100] code start
        public override Int32 Insert(System.Int32? clientNo, System.String companyName, System.DateTime? dateCreated, System.String customerCode, System.Int32? salesman, System.Int32? teamNo, System.String telephone, System.String telephone800, System.String fax, System.String rfax, System.String email, System.String url, System.String notes, System.String tax, System.Int32? typeNo, System.Int32? manufacturerNo, System.Boolean? soApproved, System.Int32? soRating, System.Int32? soTermsNo, System.Int32? soCurrencyNo, System.Int32? soTaxNo, System.Int32? defaultSoContactNo, System.Int32? defaultSalesShipViaNo, System.String defaultSalesShipViaAccount, System.Boolean? poApproved, System.Int32? poRating, System.Int32? poTermsNo, System.Int32? poCurrencyNo, System.Int32? poTaxNo, System.Int32? defaultPoContactNo, System.Int32? defaultPurchaseShipViaNo, System.String defaultPurchaseShipViaAccount, System.Boolean? onStop, System.Double? creditLimit, System.Double? currentMonth, System.Double? days30, System.Double? days60, System.Double? days90, System.Double? days120, System.Boolean? shippingCharge, System.Boolean? exportData, System.String importantNotes, System.Int32? parentCompanyNo, System.Int32? updatedBy, System.String CompanyRegNo, System.String certificateNotes, System.String qualityNotes)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar).Value = companyName;
				cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = dateCreated;
				cmd.Parameters.Add("@CustomerCode", SqlDbType.NVarChar).Value = customerCode;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@TeamNo", SqlDbType.Int).Value = teamNo;
				cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = telephone;
				cmd.Parameters.Add("@Telephone800", SqlDbType.NVarChar).Value = telephone800;
				cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = fax;
				cmd.Parameters.Add("@RFax", SqlDbType.NVarChar).Value = rfax;
				cmd.Parameters.Add("@EMail", SqlDbType.NVarChar).Value = email;
				cmd.Parameters.Add("@URL", SqlDbType.NVarChar).Value = url;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@Tax", SqlDbType.NVarChar).Value = tax;
				cmd.Parameters.Add("@TypeNo", SqlDbType.Int).Value = typeNo;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@SOApproved", SqlDbType.Bit).Value = soApproved;
				cmd.Parameters.Add("@SORating", SqlDbType.Int).Value = soRating;
				cmd.Parameters.Add("@SOTermsNo", SqlDbType.Int).Value = soTermsNo;
				cmd.Parameters.Add("@SOCurrencyNo", SqlDbType.Int).Value = soCurrencyNo;
				cmd.Parameters.Add("@SOTaxNo", SqlDbType.Int).Value = soTaxNo;
				cmd.Parameters.Add("@DefaultSOContactNo", SqlDbType.Int).Value = defaultSoContactNo;
				cmd.Parameters.Add("@DefaultSalesShipViaNo", SqlDbType.Int).Value = defaultSalesShipViaNo;
				cmd.Parameters.Add("@DefaultSalesShipViaAccount", SqlDbType.NVarChar).Value = defaultSalesShipViaAccount;
				cmd.Parameters.Add("@POApproved", SqlDbType.Bit).Value = poApproved;
				cmd.Parameters.Add("@PORating", SqlDbType.Int).Value = poRating;
				cmd.Parameters.Add("@POTermsNo", SqlDbType.Int).Value = poTermsNo;
				cmd.Parameters.Add("@POCurrencyNo", SqlDbType.Int).Value = poCurrencyNo;
				cmd.Parameters.Add("@POTaxNo", SqlDbType.Int).Value = poTaxNo;
				cmd.Parameters.Add("@DefaultPOContactNo", SqlDbType.Int).Value = defaultPoContactNo;
				cmd.Parameters.Add("@DefaultPurchaseShipViaNo", SqlDbType.Int).Value = defaultPurchaseShipViaNo;
				cmd.Parameters.Add("@DefaultPurchaseShipViaAccount", SqlDbType.NVarChar).Value = defaultPurchaseShipViaAccount;
				cmd.Parameters.Add("@OnStop", SqlDbType.Bit).Value = onStop;
				cmd.Parameters.Add("@CreditLimit", SqlDbType.Float).Value = creditLimit;
				cmd.Parameters.Add("@CurrentMonth", SqlDbType.Float).Value = currentMonth;
				cmd.Parameters.Add("@Days30", SqlDbType.Float).Value = days30;
				cmd.Parameters.Add("@Days60", SqlDbType.Float).Value = days60;
				cmd.Parameters.Add("@Days90", SqlDbType.Float).Value = days90;
				cmd.Parameters.Add("@Days120", SqlDbType.Float).Value = days120;
				cmd.Parameters.Add("@ShippingCharge", SqlDbType.Bit).Value = shippingCharge;
				cmd.Parameters.Add("@ExportData", SqlDbType.Bit).Value = exportData;
				cmd.Parameters.Add("@ImportantNotes", SqlDbType.NVarChar).Value = importantNotes;
				cmd.Parameters.Add("@ParentCompanyNo", SqlDbType.Int).Value = parentCompanyNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@CompanyRegNo", SqlDbType.NVarChar).Value = CompanyRegNo;
			//[004] start
                cmd.Parameters.Add("@certificateNotes", SqlDbType.NVarChar).Value = certificateNotes;
                cmd.Parameters.Add("@qualityNotes", SqlDbType.NVarChar).Value = qualityNotes;
	        //[004] end
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Direction = ParameterDirection.Output;
                
                cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@CompanyId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		//[1001] code end
		
        /// <summary>
        /// ItemSearch 
		/// Calls [usp_itemsearch_Company]
        /// </summary>
        public override List<CompanyDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String nameSearch, System.Boolean? poApproved, System.Boolean? soApproved, System.Boolean? includeOnStop, Boolean? excludeSupplierOnStop, System.Int32? poNoLo, System.Int32? poNoHi)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_itemsearch_Company", cn);             
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
				cmd.Parameters.Add("@POApproved", SqlDbType.Bit).Value = poApproved;
				cmd.Parameters.Add("@SOApproved", SqlDbType.Bit).Value = soApproved;
				cmd.Parameters.Add("@IncludeOnStop", SqlDbType.Bit).Value = includeOnStop;
                cmd.Parameters.Add("@ExcludeSupplierOnStop", SqlDbType.Bit).Value = excludeSupplierOnStop;
                cmd.Parameters.Add("@PONoLo", SqlDbType.Int).Value = poNoLo;
                cmd.Parameters.Add("@PONoHi", SqlDbType.Int).Value = poNoHi;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CompanyDetails> lst = new List<CompanyDetails>();
				while (reader.Read()) {
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
					obj.CompanyType = GetReaderValue_String(reader, "CompanyType", "");
					obj.City = GetReaderValue_String(reader, "City", "");
					obj.Country = GetReaderValue_String(reader, "Country", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.DaysSinceContact = GetReaderValue_NullableInt32(reader, "DaysSinceContact", null);
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    //[003] code start
                    obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
                    //[003] code end
                    obj.IsTraceability = GetReaderValue_NullableBoolean(reader, "IsTraceability", false);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Companys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_Company]
        /// </summary>
		public override CompanyDetails Get(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCompanyFromReader(reader);
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.DateCreated = GetReaderValue_DateTime(reader, "DateCreated", DateTime.MinValue);
					obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
					obj.Telephone800 = GetReaderValue_String(reader, "Telephone800", "");
					obj.Fax = GetReaderValue_String(reader, "Fax", "");
					obj.RFax = GetReaderValue_String(reader, "RFax", "");
					obj.EMail = GetReaderValue_String(reader, "EMail", "");
					obj.URL = GetReaderValue_String(reader, "URL", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Tax = GetReaderValue_String(reader, "Tax", "");
					obj.TypeNo = GetReaderValue_NullableInt32(reader, "TypeNo", null);
					obj.SOApproved = GetReaderValue_NullableBoolean(reader, "SOApproved", null);
					obj.SORating = GetReaderValue_NullableInt32(reader, "SORating", null);
					obj.SOTermsNo = GetReaderValue_NullableInt32(reader, "SOTermsNo", null);
					obj.SOCurrencyNo = GetReaderValue_NullableInt32(reader, "SOCurrencyNo", null);
					obj.SOTaxNo = GetReaderValue_NullableInt32(reader, "SOTaxNo", null);
					obj.DefaultSOContactNo = GetReaderValue_NullableInt32(reader, "DefaultSOContactNo", null);
					obj.DefaultSalesShipViaNo = GetReaderValue_NullableInt32(reader, "DefaultSalesShipViaNo", null);
					obj.DefaultSalesShipViaAccount = GetReaderValue_String(reader, "DefaultSalesShipViaAccount", "");
					obj.POApproved = GetReaderValue_NullableBoolean(reader, "POApproved", null);
					obj.PORating = GetReaderValue_NullableInt32(reader, "PORating", null);
					obj.POTermsNo = GetReaderValue_NullableInt32(reader, "POTermsNo", null);
					obj.POCurrencyNo = GetReaderValue_NullableInt32(reader, "POCurrencyNo", null);
					obj.POTaxNo = GetReaderValue_NullableInt32(reader, "POTaxNo", null);
					obj.DefaultPOContactNo = GetReaderValue_NullableInt32(reader, "DefaultPOContactNo", null);
					obj.DefaultPurchaseShipViaNo = GetReaderValue_NullableInt32(reader, "DefaultPurchaseShipViaNo", null);
					obj.DefaultPurchaseShipViaAccount = GetReaderValue_String(reader, "DefaultPurchaseShipViaAccount", "");
					obj.OnStop = GetReaderValue_NullableBoolean(reader, "OnStop", null);
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.CurrentMonth = GetReaderValue_NullableDouble(reader, "CurrentMonth", null);
					obj.Days30 = GetReaderValue_NullableDouble(reader, "Days30", null);
					obj.Days60 = GetReaderValue_NullableDouble(reader, "Days60", null);
					obj.Days90 = GetReaderValue_NullableDouble(reader, "Days90", null);
					obj.Days120 = GetReaderValue_NullableDouble(reader, "Days120", null);
					obj.ShippingCharge = GetReaderValue_NullableBoolean(reader, "ShippingCharge", null);
					obj.ExportData = GetReaderValue_NullableBoolean(reader, "ExportData", null);
					obj.ImportantNotes = GetReaderValue_String(reader, "ImportantNotes", "");
					obj.ParentCompanyNo = GetReaderValue_NullableInt32(reader, "ParentCompanyNo", null);
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.Balance = GetReaderValue_NullableDouble(reader, "Balance", null);
					obj.CompanyType = GetReaderValue_String(reader, "CompanyType", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.TeamName = GetReaderValue_String(reader, "TeamName", "");
					obj.SOTermsName = GetReaderValue_String(reader, "SOTermsName", "");
					obj.SOCurrencyCode = GetReaderValue_String(reader, "SOCurrencyCode", "");
					obj.SOCurrencyDescription = GetReaderValue_String(reader, "SOCurrencyDescription", "");
					obj.SOCurrencySymbol = GetReaderValue_String(reader, "SOCurrencySymbol", "");
					obj.DefaultSOContactName = GetReaderValue_String(reader, "DefaultSOContactName", "");
					obj.SOTaxName = GetReaderValue_String(reader, "SOTaxName", "");
					obj.DefaultSalesShipViaName = GetReaderValue_String(reader, "DefaultSalesShipViaName", "");
					obj.DefaultSalesShippingCost = GetReaderValue_Double(reader, "DefaultSalesShippingCost", 0);
					obj.DefaultSalesFreightCharge = GetReaderValue_Double(reader, "DefaultSalesFreightCharge", 0);
					obj.POTermsName = GetReaderValue_String(reader, "POTermsName", "");
					obj.POCurrencyCode = GetReaderValue_String(reader, "POCurrencyCode", "");
					obj.POCurrencyDescription = GetReaderValue_String(reader, "POCurrencyDescription", "");
					obj.POCurrencySymbol = GetReaderValue_String(reader, "POCurrencySymbol", "");
					obj.DefaultPOContactName = GetReaderValue_String(reader, "DefaultPOContactName", "");
					obj.POTaxName = GetReaderValue_String(reader, "POTaxName", "");
					obj.DefaultPurchaseShipViaName = GetReaderValue_String(reader, "DefaultPurchaseShipViaName", "");
					obj.DefaultPurchaseShippingCost = GetReaderValue_Double(reader, "DefaultPurchaseShippingCost", 0);
					obj.DefaultPurchaseFreightCharge = GetReaderValue_Double(reader, "DefaultPurchaseFreightCharge", 0);
					obj.ParentCompanyName = GetReaderValue_String(reader, "ParentCompanyName", "");
					obj.FirstContactNo = GetReaderValue_NullableInt32(reader, "FirstContactNo", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetDefaultPurchasingInfo 
		/// Calls [usp_select_Company_DefaultPurchasingInfo]
        /// </summary>
		public override CompanyDetails GetDefaultPurchasingInfo(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Company_DefaultPurchasingInfo", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCompanyFromReader(reader);
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.POTermsNo = GetReaderValue_NullableInt32(reader, "POTermsNo", null);
					obj.POCurrencyNo = GetReaderValue_NullableInt32(reader, "POCurrencyNo", null);
					obj.POTaxNo = GetReaderValue_NullableInt32(reader, "POTaxNo", null);
					obj.DefaultPOContactNo = GetReaderValue_NullableInt32(reader, "DefaultPOContactNo", null);
					obj.DefaultPurchaseShipViaNo = GetReaderValue_NullableInt32(reader, "DefaultPurchaseShipViaNo", null);
					obj.DefaultPurchaseShipViaAccount = GetReaderValue_String(reader, "DefaultPurchaseShipViaAccount", "");
					obj.POTermsName = GetReaderValue_String(reader, "POTermsName", "");
					obj.POCurrencyCode = GetReaderValue_String(reader, "POCurrencyCode", "");
					obj.POCurrencyDescription = GetReaderValue_String(reader, "POCurrencyDescription", "");
					obj.DefaultPOContactName = GetReaderValue_String(reader, "DefaultPOContactName", "");
					obj.POTaxName = GetReaderValue_String(reader, "POTaxName", "");
					obj.DefaultPurchaseShipViaName = GetReaderValue_String(reader, "DefaultPurchaseShipViaName", "");
					obj.DefaultPurchaseShippingCost = GetReaderValue_Double(reader, "DefaultPurchaseShippingCost", 0);
					obj.DefaultPurchaseFreightCharge = GetReaderValue_Double(reader, "DefaultPurchaseFreightCharge", 0);
                    obj.GlobalCurrencyNo = GetReaderValue_Int32(reader, "GlobalCurrencyNo", 0);
                    obj.UPLiftPrice = GetReaderValue_Double(reader, "UPLiftPrice", 0);
                    obj.ESTShippingCost = GetReaderValue_Double(reader, "ESTShippingCost", 0);
                    //[010] start
                    obj.NonPreferredCompany = GetReaderValue_NullableBoolean(reader, "NonPreferredCompany", null);
                    obj.SupplierWarranty = GetReaderValue_NullableInt32(reader, "SupplierWarranty", null);
                    //[010] end
					return obj;

				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetDefaultSalesInfo 
		/// Calls [usp_select_Company_DefaultSalesInfo]
        /// </summary>
		public override CompanyDetails GetDefaultSalesInfo(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Company_DefaultSalesInfo", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCompanyFromReader(reader);
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.SOTermsNo = GetReaderValue_NullableInt32(reader, "SOTermsNo", null);
					obj.SOCurrencyNo = GetReaderValue_NullableInt32(reader, "SOCurrencyNo", null);
					obj.SOTaxNo = GetReaderValue_NullableInt32(reader, "SOTaxNo", null);
					obj.DefaultSOContactNo = GetReaderValue_NullableInt32(reader, "DefaultSOContactNo", null);
					obj.DefaultSalesShipViaNo = GetReaderValue_NullableInt32(reader, "DefaultSalesShipViaNo", null);
					obj.DefaultSalesShipViaAccount = GetReaderValue_String(reader, "DefaultSalesShipViaAccount", "");
					obj.ShippingCharge = GetReaderValue_NullableBoolean(reader, "ShippingCharge", null);
					obj.SOTermsName = GetReaderValue_String(reader, "SOTermsName", "");
					obj.SOCurrencyCode = GetReaderValue_String(reader, "SOCurrencyCode", "");
					obj.SOCurrencyDescription = GetReaderValue_String(reader, "SOCurrencyDescription", "");
					obj.DefaultSOContactName = GetReaderValue_String(reader, "DefaultSOContactName", "");
					obj.SOTaxName = GetReaderValue_String(reader, "SOTaxName", "");
					obj.DefaultSalesShipViaName = GetReaderValue_String(reader, "DefaultSalesShipViaName", "");
					obj.DefaultSalesShippingCost = GetReaderValue_Double(reader, "DefaultSalesShippingCost", 0);
					obj.DefaultSalesFreightCharge = GetReaderValue_Double(reader, "DefaultSalesFreightCharge", 0);
                    obj.IsTraceability = GetReaderValue_NullableBoolean(reader, "IsTraceability", false);
                    obj.GlobalCurrencyNo = GetReaderValue_Int32(reader, "GlobalCurrencyNo", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForPage 
		/// Calls [usp_select_Company_for_Page]
        /// </summary>
		public override CompanyDetails GetForPage(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Company_for_Page", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCompanyFromReader(reader);
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.SOApproved = GetReaderValue_NullableBoolean(reader, "SOApproved", null);
					obj.SORating = GetReaderValue_NullableInt32(reader, "SORating", null);
					obj.POApproved = GetReaderValue_NullableBoolean(reader, "POApproved", null);
					obj.PORating = GetReaderValue_NullableInt32(reader, "PORating", null);
					obj.OnStop = GetReaderValue_NullableBoolean(reader, "OnStop", null);
					obj.ImportantNotes = GetReaderValue_String(reader, "ImportantNotes", "");
					obj.ParentCompanyNo = GetReaderValue_NullableInt32(reader, "ParentCompanyNo", null);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.CompanyType = GetReaderValue_String(reader, "CompanyType", "");
					obj.ParentCompanyName = GetReaderValue_String(reader, "ParentCompanyName", "");
                    // [002] code start
                    obj.IsPDFAvailable = GetReaderValue_Boolean(reader, "IsPDFAvailable", false);
                    // [002] code end
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", 0);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", 0);
                    obj.InsuredAmount = GetReaderValue_Double(reader, "InsuredAmount",0.00);
                    obj.InsuranceFileNo = GetReaderValue_String(reader, "InsuranceFileNo", "");
                    obj.StopStatus = GetReaderValue_String(reader, "CreditStatus", "");
                    obj.IsPoHub = GetReaderValue_NullableBoolean(reader, "IsPOHub", null);
                    obj.NonPreferredCompany= GetReaderValue_Boolean(reader, "NonPreferredCompany", false);
                    return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetMainInfo 
		/// Calls [usp_select_Company_MainInfo]
        /// </summary>
		public override CompanyDetails GetMainInfo(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Company_MainInfo", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCompanyFromReader(reader);
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
					obj.Telephone800 = GetReaderValue_String(reader, "Telephone800", "");
					obj.Fax = GetReaderValue_String(reader, "Fax", "");
					obj.EMail = GetReaderValue_String(reader, "EMail", "");
					obj.URL = GetReaderValue_String(reader, "URL", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Tax = GetReaderValue_String(reader, "Tax", "");
					obj.TypeNo = GetReaderValue_NullableInt32(reader, "TypeNo", null);
					obj.OnStop = GetReaderValue_NullableBoolean(reader, "OnStop", null);
					obj.ImportantNotes = GetReaderValue_String(reader, "ImportantNotes", "");
					obj.ParentCompanyNo = GetReaderValue_NullableInt32(reader, "ParentCompanyNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.CompanyType = GetReaderValue_String(reader, "CompanyType", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.ParentCompanyName = GetReaderValue_String(reader, "ParentCompanyName", "");
                    //[001] code start
                    obj.CompanyRegNo = GetReaderValue_String(reader, "CompanyRegNo", "");
                    //[001] Code end
                    //[004] code start
                    obj.certificateNotes = GetReaderValue_String(reader, "certificateNotes", "");
                    obj.qualityNotes = GetReaderValue_String(reader, "qualityNotes", "");
                    //[004] code end
                    //[005] code start
                    obj.IsTraceability = GetReaderValue_Boolean(reader, "IsTraceability", false);
                    //[005] code end
                    //[006] code start
                    obj.ERAIMember = GetReaderValue_Boolean(reader, "ERAIMember", false);
                    obj.ERAIReported = GetReaderValue_Boolean(reader, "ERAIReported", false);
                    //[006] code end
                    obj.ReviewDate = GetReaderValue_NullableDateTime(reader, "ReviewDate", null);
                    obj.UPLiftPrice = GetReaderValue_NullableDouble(reader, "UPLiftPrice", null);
                    obj.IsPoHub = GetReaderValue_Boolean(reader, "IsPOHub", false);
                    obj.LastReviewDate = GetReaderValue_NullableDateTime(reader, "LastReviewDate", null);
                    obj.PreviousReviewDate = GetReaderValue_NullableDateTime(reader, "PreviousReviewDate", null);
                    obj.SalesAccountInDays = GetReaderValue_NullableInt32(reader, "SalesAccountInDays", 0);

                    //[011] start
                    obj.SupplierWarranty = GetReaderValue_NullableInt32(reader, "SupplierWarranty", null);
                    //[011] end
                    //[012] start
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo",0);
                    //[012] end
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetPurchaseInfo 
		/// Calls [usp_select_Company_PurchaseInfo]
        /// </summary>
		public override CompanyDetails GetPurchaseInfo(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Company_PurchaseInfo", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCompanyFromReader(reader);
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.POApproved = GetReaderValue_NullableBoolean(reader, "POApproved", null);
					obj.PORating = GetReaderValue_NullableInt32(reader, "PORating", null);
					obj.POTermsNo = GetReaderValue_NullableInt32(reader, "POTermsNo", null);
					obj.POCurrencyNo = GetReaderValue_NullableInt32(reader, "POCurrencyNo", null);
					obj.POTaxNo = GetReaderValue_NullableInt32(reader, "POTaxNo", null);
					obj.DefaultPOContactNo = GetReaderValue_NullableInt32(reader, "DefaultPOContactNo", null);
					obj.DefaultPurchaseShipViaNo = GetReaderValue_NullableInt32(reader, "DefaultPurchaseShipViaNo", null);
					obj.DefaultPurchaseShipViaAccount = GetReaderValue_String(reader, "DefaultPurchaseShipViaAccount", "");
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
					obj.POTermsName = GetReaderValue_String(reader, "POTermsName", "");
					obj.POCurrencyCode = GetReaderValue_String(reader, "POCurrencyCode", "");
					obj.POCurrencyDescription = GetReaderValue_String(reader, "POCurrencyDescription", "");
					obj.DefaultPOContactName = GetReaderValue_String(reader, "DefaultPOContactName", "");
					obj.POTaxName = GetReaderValue_String(reader, "POTaxName", "");
					obj.DefaultPurchaseShipViaName = GetReaderValue_String(reader, "DefaultPurchaseShipViaName", "");
					obj.DefaultPurchaseShippingCost = GetReaderValue_Double(reader, "DefaultPurchaseShippingCost", 0);
					obj.DefaultPurchaseFreightCharge = GetReaderValue_Double(reader, "DefaultPurchaseFreightCharge", 0);
					obj.ExchangeRate = GetReaderValue_NullableDouble(reader, "ExchangeRate", null);
                    //[003] code start
                    obj.GlobalCurrencyNo = GetReaderValue_Int32(reader, "GlobalCurrencyNo", 0);
                    obj.GlobalCurrencyCode = GetReaderValue_String(reader, "GlobalCurrencyName", "");
                    //[003] code end
                    //[006] code start
                    obj.ERAIReported = GetReaderValue_NullableBoolean(reader, "ERAIReported", false);
                    //[006] code end
                    //[007] code start
                    obj.DefaultPOShipCountryNo = GetReaderValue_NullableInt32(reader, "DefaultPOShipCountryNo", null);
                    obj.DefaultPOShipCountry = GetReaderValue_String(reader, "DefaultPOShipCountry", "");
                    //[007] code end
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");

                    //[008] code start
                    obj.POApprovedBy = GetReaderValue_NullableInt32(reader, "POApprovedBy", 0);
                    obj.POApprovedDate = GetReaderValue_NullableDateTime(reader, "POApprovedDate", null);
                    //[008] End
                    obj.SupplierOnStop = GetReaderValue_NullableBoolean(reader, "SupplierOnStop", false);
                    obj.TaxByAddrssNo = GetReaderValue_NullableInt32(reader, "TaxByAddrssNo", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetSalesInfo 
		/// Calls [usp_select_Company_SalesInfo]
        /// </summary>
		public override CompanyDetails GetSalesInfo(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Company_SalesInfo", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCompanyFromReader(reader);
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SOApproved = GetReaderValue_NullableBoolean(reader, "SOApproved", null);
					obj.SORating = GetReaderValue_NullableInt32(reader, "SORating", null);
					obj.SOTermsNo = GetReaderValue_NullableInt32(reader, "SOTermsNo", null);
					obj.SOCurrencyNo = GetReaderValue_NullableInt32(reader, "SOCurrencyNo", null);
					obj.SOTaxNo = GetReaderValue_NullableInt32(reader, "SOTaxNo", null);
					obj.DefaultSOContactNo = GetReaderValue_NullableInt32(reader, "DefaultSOContactNo", null);
					obj.DefaultSalesShipViaNo = GetReaderValue_NullableInt32(reader, "DefaultSalesShipViaNo", null);
					obj.DefaultSalesShipViaAccount = GetReaderValue_String(reader, "DefaultSalesShipViaAccount", "");
					obj.OnStop = GetReaderValue_NullableBoolean(reader, "OnStop", null);
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.CurrentMonth = GetReaderValue_NullableDouble(reader, "CurrentMonth", null);
					obj.Days30 = GetReaderValue_NullableDouble(reader, "Days30", null);
					obj.Days60 = GetReaderValue_NullableDouble(reader, "Days60", null);
					obj.Days90 = GetReaderValue_NullableDouble(reader, "Days90", null);
					obj.Days120 = GetReaderValue_NullableDouble(reader, "Days120", null);
					obj.ShippingCharge = GetReaderValue_NullableBoolean(reader, "ShippingCharge", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.Balance = GetReaderValue_NullableDouble(reader, "Balance", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.SOTermsName = GetReaderValue_String(reader, "SOTermsName", "");
					obj.SOCurrencyCode = GetReaderValue_String(reader, "SOCurrencyCode", "");
					obj.SOCurrencyDescription = GetReaderValue_String(reader, "SOCurrencyDescription", "");
					obj.DefaultSOContactName = GetReaderValue_String(reader, "DefaultSOContactName", "");
					obj.SOTaxName = GetReaderValue_String(reader, "SOTaxName", "");
					obj.DefaultSalesShipViaName = GetReaderValue_String(reader, "DefaultSalesShipViaName", "");
					obj.DefaultSalesShippingCost = GetReaderValue_Double(reader, "DefaultSalesShippingCost", 0);
					obj.DefaultSalesFreightCharge = GetReaderValue_Double(reader, "DefaultSalesFreightCharge", 0);
					obj.ExchangeRate = GetReaderValue_NullableDouble(reader, "ExchangeRate", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.SOApprovedBy = GetReaderValue_NullableInt32(reader, "SOApprovedBy", 0);
                    obj.SOApprovedDate = GetReaderValue_DateTime(reader, "SOApprovedDate", DateTime.MinValue);
                    obj.IsTraceability = GetReaderValue_Boolean(reader, "IsTraceability", false);
                    //[008]  Start here 
                    obj.InsuranceFileNo = GetReaderValue_String(reader, "InsuranceFileNo", "");
                    obj.InsuredAmount = GetReaderValue_NullableDouble(reader, "InsuredAmount", null);
                    obj.StopStatus = GetReaderValue_String(reader, "CreditStatus", "");
                    obj.GlobalCurrencyNo = GetReaderValue_Int32(reader, "GlobalCurrencyNo", 0);
                    obj.NotesToInvoice = GetReaderValue_String(reader, "NotesToInvoice", "");                   
                    //[008]  End here
                    //[010]  Start Start 
                    obj.ActualCreditLimit = GetReaderValue_NullableDouble(reader, "ActualCreditLimit", null);
                    //[010]  Start End 
                    obj.Days1 = GetReaderValue_NullableDouble(reader, "Days1", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListByManufacturer 
		/// Calls [usp_selectAll_Company_by_Manufacturer]
        /// </summary>
		public override List<CompanyDetails> GetListByManufacturer(System.Int32? manufacturerNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Company_by_Manufacturer", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CompanyDetails> lst = new List<CompanyDetails>();
				while (reader.Read()) {
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.DateCreated = GetReaderValue_DateTime(reader, "DateCreated", DateTime.MinValue);
					obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
					obj.Telephone800 = GetReaderValue_String(reader, "Telephone800", "");
					obj.Fax = GetReaderValue_String(reader, "Fax", "");
					obj.RFax = GetReaderValue_String(reader, "RFax", "");
					obj.EMail = GetReaderValue_String(reader, "EMail", "");
					obj.URL = GetReaderValue_String(reader, "URL", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Tax = GetReaderValue_String(reader, "Tax", "");
					obj.TypeNo = GetReaderValue_NullableInt32(reader, "TypeNo", null);
					obj.SOApproved = GetReaderValue_NullableBoolean(reader, "SOApproved", null);
					obj.SORating = GetReaderValue_NullableInt32(reader, "SORating", null);
					obj.SOTermsNo = GetReaderValue_NullableInt32(reader, "SOTermsNo", null);
					obj.SOCurrencyNo = GetReaderValue_NullableInt32(reader, "SOCurrencyNo", null);
					obj.SOTaxNo = GetReaderValue_NullableInt32(reader, "SOTaxNo", null);
					obj.DefaultSOContactNo = GetReaderValue_NullableInt32(reader, "DefaultSOContactNo", null);
					obj.DefaultSalesShipViaNo = GetReaderValue_NullableInt32(reader, "DefaultSalesShipViaNo", null);
					obj.DefaultSalesShipViaAccount = GetReaderValue_String(reader, "DefaultSalesShipViaAccount", "");
					obj.POApproved = GetReaderValue_NullableBoolean(reader, "POApproved", null);
					obj.PORating = GetReaderValue_NullableInt32(reader, "PORating", null);
					obj.POTermsNo = GetReaderValue_NullableInt32(reader, "POTermsNo", null);
					obj.POCurrencyNo = GetReaderValue_NullableInt32(reader, "POCurrencyNo", null);
					obj.POTaxNo = GetReaderValue_NullableInt32(reader, "POTaxNo", null);
					obj.DefaultPOContactNo = GetReaderValue_NullableInt32(reader, "DefaultPOContactNo", null);
					obj.DefaultPurchaseShipViaNo = GetReaderValue_NullableInt32(reader, "DefaultPurchaseShipViaNo", null);
					obj.DefaultPurchaseShipViaAccount = GetReaderValue_String(reader, "DefaultPurchaseShipViaAccount", "");
					obj.OnStop = GetReaderValue_NullableBoolean(reader, "OnStop", null);
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.CurrentMonth = GetReaderValue_NullableDouble(reader, "CurrentMonth", null);
					obj.Days30 = GetReaderValue_NullableDouble(reader, "Days30", null);
					obj.Days60 = GetReaderValue_NullableDouble(reader, "Days60", null);
					obj.Days90 = GetReaderValue_NullableDouble(reader, "Days90", null);
					obj.Days120 = GetReaderValue_NullableDouble(reader, "Days120", null);
					obj.ShippingCharge = GetReaderValue_NullableBoolean(reader, "ShippingCharge", null);
					obj.ExportData = GetReaderValue_NullableBoolean(reader, "ExportData", null);
					obj.ImportantNotes = GetReaderValue_String(reader, "ImportantNotes", "");
					obj.ParentCompanyNo = GetReaderValue_NullableInt32(reader, "ParentCompanyNo", null);
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.AutoImportDate = GetReaderValue_NullableDateTime(reader, "AutoImportDate", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.Balance = GetReaderValue_NullableDouble(reader, "Balance", null);
					obj.FullName = GetReaderValue_String(reader, "FullName", "");
					obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");                   
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Companys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListOnstopForClient 
		/// Calls [usp_selectAll_Company_onstop_for_Client]
        /// </summary>
		public override List<CompanyDetails> GetListOnstopForClient(System.Int32? clientId, System.Int32? topToSelect) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Company_onstop_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CompanyDetails> lst = new List<CompanyDetails>();
				while (reader.Read()) {
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.Balance = GetReaderValue_NullableDouble(reader, "Balance", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Companys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListOnstopForLogin 
		/// Calls [usp_selectAll_Company_onstop_for_Login]
        /// </summary>
		public override List<CompanyDetails> GetListOnstopForLogin(System.Int32? loginId, System.Int32? topToSelect) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Company_onstop_for_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginID", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CompanyDetails> lst = new List<CompanyDetails>();
				while (reader.Read()) {
					CompanyDetails obj = new CompanyDetails();
					obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.Balance = GetReaderValue_NullableDouble(reader, "Balance", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Companys", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// SummariseLastYearPurchaseOrderValue 
		/// Calls [usp_summarise_Company_LastYear_PurchaseOrderValue]
        /// </summary>
		public override CompanyDetails SummariseLastYearPurchaseOrderValue(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_summarise_Company_LastYear_PurchaseOrderValue", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCompanyFromReader(reader);
					CompanyDetails obj = new CompanyDetails();
					obj.POCurrencyCode = GetReaderValue_String(reader, "POCurrencyCode", "");
					obj.PurchaseOrderValueLastYear = GetReaderValue_NullableDouble(reader, "PurchaseOrderValueLastYear", null);
					obj.PurchaseOrderValueLastYearInBase = GetReaderValue_NullableDouble(reader, "PurchaseOrderValueLastYearInBase", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// SummariseLastYearSalesOrderValue 
		/// Calls [usp_summarise_Company_LastYear_SalesOrderValue]
        /// </summary>
		public override CompanyDetails SummariseLastYearSalesOrderValue(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_summarise_Company_LastYear_SalesOrderValue", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCompanyFromReader(reader);
					CompanyDetails obj = new CompanyDetails();
					obj.SOCurrencyCode = GetReaderValue_String(reader, "SOCurrencyCode", "");
					obj.SalesOrderValueLastYear = GetReaderValue_NullableDouble(reader, "SalesOrderValueLastYear", null);
					obj.SalesOrderValueLastYearInBase = GetReaderValue_NullableDouble(reader, "SalesOrderValueLastYearInBase", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// SummariseThisYearPurchaseOrderValue 
		/// Calls [usp_summarise_Company_ThisYear_PurchaseOrderValue]
        /// </summary>
		public override CompanyDetails SummariseThisYearPurchaseOrderValue(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_summarise_Company_ThisYear_PurchaseOrderValue", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCompanyFromReader(reader);
					CompanyDetails obj = new CompanyDetails();
					obj.POCurrencyCode = GetReaderValue_String(reader, "POCurrencyCode", "");
					obj.PurchaseOrderValueYTD = GetReaderValue_NullableDouble(reader, "PurchaseOrderValueYTD", null);
					obj.PurchaseOrderValueYTDInBase = GetReaderValue_NullableDouble(reader, "PurchaseOrderValueYTDInBase", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// SummariseThisYearSalesOrderValue 
		/// Calls [usp_summarise_Company_ThisYear_SalesOrderValue]
        /// </summary>
		public override CompanyDetails SummariseThisYearSalesOrderValue(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_summarise_Company_ThisYear_SalesOrderValue", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCompanyFromReader(reader);
					CompanyDetails obj = new CompanyDetails();
					obj.SOCurrencyCode = GetReaderValue_String(reader, "SOCurrencyCode", "");
					obj.SalesOrderValueYTD = GetReaderValue_NullableDouble(reader, "SalesOrderValueYTD", null);
					obj.SalesOrderValueYTDInBase = GetReaderValue_NullableDouble(reader, "SalesOrderValueYTDInBase", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Company
		/// Calls [usp_update_Company_DefaultPOContact]
        /// </summary>
		public override bool UpdateDefaultPOContact(System.Int32? companyId, System.Int32? defaultPoContactNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Company_DefaultPOContact", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cmd.Parameters.Add("@DefaultPOContactNo", SqlDbType.Int).Value = defaultPoContactNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
        //[003] code start
        /// <summary>
        /// Update Company
        /// Calls [usp_update_Company_DefaultPOLedgerContact]
        /// </summary>
        public override bool UpdateDefaultPOLedgerContact(System.Int32? companyId, System.Int32? defaultPoContactNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Company_DefaultPOLedgerContact", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@DefaultPOLedgerContactNo", SqlDbType.Int).Value = defaultPoContactNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Company", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Calls [usp_update_Company_DefaultSOLedgerContact]
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="defaultSoContactNo"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public override bool UpdateDefaultSOLedgerContact(System.Int32? companyId, System.Int32? defaultSoContactNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Company_DefaultSOLedgerContact", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@DefaultSOLedgerContactNo", SqlDbType.Int).Value = defaultSoContactNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Company", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[003] code end
		
        /// <summary>
        /// Update Company
		/// Calls [usp_update_Company_DefaultSOContact]
        /// </summary>
		public override bool UpdateDefaultSOContact(System.Int32? companyId, System.Int32? defaultSoContactNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Company_DefaultSOContact", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cmd.Parameters.Add("@DefaultSOContactNo", SqlDbType.Int).Value = defaultSoContactNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Company
		/// Calls [usp_update_Company_MainInfo]
        /// </summary>
        public override bool UpdateMainInfo(System.Int32? companyId, System.String companyName, System.Int32? parentCompanyNo, System.Int32? salesman, System.String telephone, System.String telephone800, System.String fax, System.String email, System.String url, System.Int32? typeNo, System.String tax, System.String notes, System.String importantNotes, System.Int32? updatedBy, System.String CompanyRegNo, System.String certificateNotes, System.String qualityNotes, System.Boolean IsTraceability, System.Boolean? eraiMember, System.Boolean? eraiReported, System.DateTime? reviewDate, System.Double? upLiftPrice, System.Int32? SupplierWarranty)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Company_MainInfo", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar).Value = companyName;
				cmd.Parameters.Add("@ParentCompanyNo", SqlDbType.Int).Value = parentCompanyNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = telephone;
				cmd.Parameters.Add("@Telephone800", SqlDbType.NVarChar).Value = telephone800;
				cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = fax;
				cmd.Parameters.Add("@EMail", SqlDbType.NVarChar).Value = email;
				cmd.Parameters.Add("@URL", SqlDbType.NVarChar).Value = url;
				cmd.Parameters.Add("@TypeNo", SqlDbType.Int).Value = typeNo;
				cmd.Parameters.Add("@Tax", SqlDbType.NVarChar).Value = tax;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@ImportantNotes", SqlDbType.NVarChar).Value = importantNotes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@CompanyRegNo", SqlDbType.NVarChar).Value = CompanyRegNo;
                //[004] start
                cmd.Parameters.Add("@certificateNotes", SqlDbType.NVarChar).Value = certificateNotes;
                cmd.Parameters.Add("@qualityNotes", SqlDbType.NVarChar).Value = qualityNotes;
                //[004] end
                //[005] start
                cmd.Parameters.Add("@IsTraceability", SqlDbType.Bit).Value = IsTraceability;
                //[005] end
                //[006] code start
                cmd.Parameters.Add("@ERAIMember", SqlDbType.Bit).Value = eraiMember;
                cmd.Parameters.Add("@ERAIReported", SqlDbType.Bit).Value = eraiReported;
                //[006] code end
                cmd.Parameters.Add("@ReviewDate", SqlDbType.DateTime).Value = reviewDate;
                cmd.Parameters.Add("@UPLiftPrice", SqlDbType.Float).Value = upLiftPrice;
                //cmd.Parameters.Add("@IsPOHub", SqlDbType.Bit).Value = isPOHub;
                //[011] code start
                cmd.Parameters.Add("@SupplierWarranty", SqlDbType.Int).Value = SupplierWarranty;
                //[011] code end
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Company
		/// Calls [usp_update_Company_ManufacturerNo]
        /// </summary>
		public override bool UpdateManufacturerNo(System.Int32? companyId, System.Int32? manufacturerNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Company_ManufacturerNo", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		//[007] code start
        /// <summary>
        /// Update Company
		/// Calls [usp_update_Company_PurchaseInfo]
        /// </summary>
        public override bool UpdatePurchaseInfo(System.Int32? companyId, System.String supplierCode, System.Boolean? poApproved, System.Int32? poRating, System.Int32? poTermsNo, System.Int32? poCurrencyNo, System.Int32? poTaxNo, System.Int32? defaultPoContactNo, System.String defaultPurchaseShipViaAccount, System.Int32? defaultPurchaseShipViaNo, System.Int32? updatedBy, System.Int32? defaultPOShipCountryNo, System.Boolean? onSupplierStop)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Company_PurchaseInfo", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cmd.Parameters.Add("@SupplierCode", SqlDbType.NVarChar).Value = supplierCode;
				cmd.Parameters.Add("@POApproved", SqlDbType.Bit).Value = poApproved;
				cmd.Parameters.Add("@PORating", SqlDbType.Int).Value = poRating;
				cmd.Parameters.Add("@POTermsNo", SqlDbType.Int).Value = poTermsNo;
				cmd.Parameters.Add("@POCurrencyNo", SqlDbType.Int).Value = poCurrencyNo;
				cmd.Parameters.Add("@POTaxNo", SqlDbType.Int).Value = poTaxNo;
				cmd.Parameters.Add("@DefaultPOContactNo", SqlDbType.Int).Value = defaultPoContactNo;
				cmd.Parameters.Add("@DefaultPurchaseShipViaAccount", SqlDbType.NVarChar).Value = defaultPurchaseShipViaAccount;
				cmd.Parameters.Add("@DefaultPurchaseShipViaNo", SqlDbType.Int).Value = defaultPurchaseShipViaNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@DefaultPOShipCountryNo", SqlDbType.Int).Value = defaultPOShipCountryNo;
                cmd.Parameters.Add("@SupplierOnStop", SqlDbType.Bit).Value = onSupplierStop;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
        //[007] code end
		
        /// <summary>
        /// Update Company
		/// Calls [usp_update_Company_SalesInfo]
        /// </summary>
        public override bool UpdateSalesInfo(System.Int32? companyId, System.String customerCode, System.Int32? salesman, System.Boolean? soApproved, System.Int32? soRating, System.Int32? soTermsNo, System.Int32? soCurrencyNo, System.Int32? soTaxNo, System.Int32? defaultSoContactNo, System.Int32? defaultSalesShipViaNo, System.String defaultSalesShipViaAccount, System.Boolean? onStop, System.Boolean? shippingCharge, System.Double? creditLimit, System.String insuranceFileNo, System.Double? insuredAmount, System.Int32? updatedBy, System.String StopStatus, System.String NotesToInvoice, System.Double? actualCreditLimit)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Company_SalesInfo", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cmd.Parameters.Add("@CustomerCode", SqlDbType.NVarChar).Value = customerCode;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@SOApproved", SqlDbType.Bit).Value = soApproved;
				cmd.Parameters.Add("@SORating", SqlDbType.Int).Value = soRating;
				cmd.Parameters.Add("@SOTermsNo", SqlDbType.Int).Value = soTermsNo;
				cmd.Parameters.Add("@SOCurrencyNo", SqlDbType.Int).Value = soCurrencyNo;
				cmd.Parameters.Add("@SOTaxNo", SqlDbType.Int).Value = soTaxNo;
				cmd.Parameters.Add("@DefaultSOContactNo", SqlDbType.Int).Value = defaultSoContactNo;
				cmd.Parameters.Add("@DefaultSalesShipViaNo", SqlDbType.Int).Value = defaultSalesShipViaNo;
				cmd.Parameters.Add("@DefaultSalesShipViaAccount", SqlDbType.NVarChar).Value = defaultSalesShipViaAccount;
				cmd.Parameters.Add("@OnStop", SqlDbType.Bit).Value = onStop;
				cmd.Parameters.Add("@ShippingCharge", SqlDbType.Bit).Value = shippingCharge;
				cmd.Parameters.Add("@CreditLimit", SqlDbType.Float).Value = creditLimit;
                //[008] Start here
                cmd.Parameters.Add("@InsuranceFileNo", SqlDbType.NChar).Value = insuranceFileNo;
                cmd.Parameters.Add("@InsuredAmount", SqlDbType.Float).Value = insuredAmount;
                //[008] End Here
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@StopStatus", SqlDbType.NChar).Value = StopStatus;
                cmd.Parameters.Add("@NotesToInvoice", SqlDbType.NVarChar).Value = NotesToInvoice;
                //[010] Start Code
                cmd.Parameters.Add("@ActualCreditLimit", SqlDbType.Float).Value = actualCreditLimit;
                //[010] Start End
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Company
		/// Calls [usp_update_Company_TransferAccounts]
        /// </summary>
		public override bool UpdateTransferAccounts(System.Int32? oldLoginNo, System.Int32? newLoginNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Company_TransferAccounts", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@OldLoginNo", SqlDbType.Int).Value = oldLoginNo;
				cmd.Parameters.Add("@NewLoginNo", SqlDbType.Int).Value = newLoginNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Company", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        // [002] code start
        /// <summary>
        /// GetPDFListForCompany
        /// Calls [usp_selectAll_PDF_for_Company]
        /// </summary>
        public override List<PDFDocumentDetails> GetPDFListForCompany(System.Int32? CompanyId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_PDF_for_Company", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = CompanyId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PDFDocumentDetails> lstPDF = new List<PDFDocumentDetails>();
                while (reader.Read())
                {
                    PDFDocumentDetails obj = new PDFDocumentDetails();
                    obj.PDFDocumentId = GetReaderValue_Int32(reader, "CompanyPDFId", 0);
                    obj.PDFDocumentRefNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.Caption = GetReaderValue_String(reader, "Caption", "");
                    obj.FileName = GetReaderValue_String(reader, "FileName", "");
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
                    lstPDF.Add(obj);
                    obj = null;
                }
                return lstPDF;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get PDF list for cutomer rma", sqlex);
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
        /// Calls [usp_insert_CompanyPDF]
        /// </summary>
        public override Int32 Insert(System.Int32? CompanyId, System.String Caption, System.String FileName, System.Int32? UpdatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_CompanyPDF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = CompanyId;
                cmd.Parameters.Add("@Caption", SqlDbType.NVarChar).Value = Caption;
                cmd.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = FileName;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UpdatedBy;
                cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@NewId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert cutomer rma pdf", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Delete company pdf
        /// Calls[usp_delete_CompanyPDF]
        /// </summary>
        public override bool DeleteCompanyPDF(System.Int32? CompanyPdfId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_CompanyPDF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CompanyPDFId", SqlDbType.Int).Value = CompanyPdfId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete customer rma pdf", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// SummariseThisYearandLastYearSalesValue
        /// Calls [usp_summarise_Company_ThisYear_LastYear_SalesValue]
        /// </summary>
        public override CompanyDetails SummariseThisYearandLastYearSalesValue(System.Int32? companyId,System.Boolean? blnThisYear)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_summarise_Company_ThisYear_LastYear_SalesValue", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@IncludeCredits", SqlDbType.Bit).Value = 1;
                cmd.Parameters.Add("@ThisYear", SqlDbType.Int).Value = blnThisYear;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetCompanyFromReader(reader);
                    CompanyDetails obj = new CompanyDetails();
                    obj.SalesCost = GetReaderValue_NullableDouble(reader, "Cost", null);
                    obj.SalesResale = GetReaderValue_NullableDouble(reader, "Resale", null);
                    obj.SalesGrossProfit = GetReaderValue_NullableDouble(reader, "GrossProfit", null);
                    obj.Margin = GetReaderValue_NullableDouble(reader, "Margin", null);
                    
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Company", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        
        // [002] code end
		
		
		
	}
}
