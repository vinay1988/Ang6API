//Marker     changed by      date          Remarks
//[001]      Vinay           24/08/2012    ESMS Ref:## - Disable create so button if quantity is 0 
//[002]      Vinay           21/01/2014   CR:- Add AS9120 Requirement in GT application
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
	public class SqlQuoteProvider : QuoteProvider {
		/// <summary>
		/// Count Quote
		/// Calls [usp_count_Quote_for_Client]
		/// </summary>
		public override Int32 CountForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_Quote_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count Quote", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Count Quote
		/// Calls [usp_count_Quote_for_Company]
		/// </summary>
		public override Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeClosed) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_Quote_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count Quote", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Count Quote
		/// Calls [usp_count_Quote_open_for_Company]
		/// </summary>
		public override Int32 CountOpenForCompany(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_Quote_open_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count Quote", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete Quote
		/// Calls [usp_delete_Quote]
		/// </summary>
		public override bool Delete(System.Int32? quoteId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Quote", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@QuoteId", SqlDbType.Int).Value = quoteId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Quote", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_Quote]
		/// </summary>
        public override Int32 Insert(System.Int32? clientNo, System.String notes, System.String instructions, System.Int32? companyNo, System.Int32? contactNo, System.DateTime? dateQuoted, System.Int32? currencyNo, System.Int32? salesman, System.Int32? termsNo, System.Int32? divisionNo, System.Double? freight, System.Boolean? closed, System.Int32? incotermNo, System.Int32? updatedBy, System.Boolean? As9120, System.Boolean? isImportant)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Quote", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@DateQuoted", SqlDbType.DateTime).Value = dateQuoted;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@TermsNo", SqlDbType.Int).Value = termsNo;
				cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
				cmd.Parameters.Add("@Freight", SqlDbType.Float).Value = freight;
				cmd.Parameters.Add("@Closed", SqlDbType.Bit).Value = closed;
				cmd.Parameters.Add("@IncotermNo", SqlDbType.Int).Value = incotermNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //[002] code start
                cmd.Parameters.Add("@AS9120", SqlDbType.Bit).Value = As9120;
                //[002] code end
                cmd.Parameters.Add("@IsImportant", SqlDbType.Bit).Value = isImportant;
				cmd.Parameters.Add("@QuoteId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@QuoteId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Quote", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_Quote]
        /// </summary>
		public override QuoteDetails Get(System.Int32? quoteId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Quote", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@QuoteId", SqlDbType.Int).Value = quoteId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetQuoteFromReader(reader);
					QuoteDetails obj = new QuoteDetails();
					obj.QuoteId = GetReaderValue_Int32(reader, "QuoteId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.Closed = GetReaderValue_NullableBoolean(reader, "Closed", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
					obj.CompanySOApproved = GetReaderValue_NullableBoolean(reader, "CompanySOApproved", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.QuoteValue = GetReaderValue_NullableDouble(reader, "QuoteValue", null);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.OpenLines = GetReaderValue_NullableInt32(reader, "OpenLines", null);
					obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    //[001] code start
                    obj.TotalQuantityLines = GetReaderValue_NullableInt32(reader, "TotalQuantityLines",0);
                    //[001] code end
                    //[002] code start
                    obj.AS9120 = GetReaderValue_NullableBoolean(reader, "AS9120", false);
                    //[002] code end
                    obj.GlobalCurrencyNo = GetReaderValue_Int32(reader, "GlobalCurrencyNo", 0);
                    obj.IsCurrencyInSameFaimly = GetReaderValue_NullableBoolean(reader, "IsCurrencyInSameFaimly", false);
                    obj.IsImportant = GetReaderValue_NullableBoolean(reader, "IsImportant", false);
                    obj.QuoteStatus = GetReaderValue_NullableInt32(reader, "QuoteStatus", null);
                    obj.QuoteStatusName = GetReaderValue_String(reader, "QuoteStatusName", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Quote", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetByNumber 
		/// Calls [usp_select_Quote_by_Number]
        /// </summary>
		public override QuoteDetails GetByNumber(System.Int32? quoteNumber, System.Int32? clientNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Quote_by_Number", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@QuoteNumber", SqlDbType.Int).Value = quoteNumber;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetQuoteFromReader(reader);
					QuoteDetails obj = new QuoteDetails();
					obj.QuoteId = GetReaderValue_Int32(reader, "QuoteId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.Closed = GetReaderValue_NullableBoolean(reader, "Closed", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
					obj.CompanySOApproved = GetReaderValue_NullableBoolean(reader, "CompanySOApproved", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.QuoteValue = GetReaderValue_NullableDouble(reader, "QuoteValue", null);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.OpenLines = GetReaderValue_NullableInt32(reader, "OpenLines", null);
					obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Quote", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForPage 
		/// Calls [usp_select_Quote_for_Page]
        /// </summary>
		public override QuoteDetails GetForPage(System.Int32? quoteId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Quote_for_Page", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@QuoteId", SqlDbType.Int).Value = quoteId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetQuoteFromReader(reader);
					QuoteDetails obj = new QuoteDetails();
					obj.QuoteId = GetReaderValue_Int32(reader, "QuoteId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.Closed = GetReaderValue_NullableBoolean(reader, "Closed", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.TeamNo = GetReaderValue_Int32(reader, "TeamNo", 0);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.QuoteStatusName = GetReaderValue_String(reader, "QuoteStatusName", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Quote", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForPrint 
		/// Calls [usp_select_Quote_for_Print]
        /// </summary>
		public override QuoteDetails GetForPrint(System.Int32? quoteId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Quote_for_Print", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@QuoteId", SqlDbType.Int).Value = quoteId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetQuoteFromReader(reader);
					QuoteDetails obj = new QuoteDetails();
					obj.QuoteId = GetReaderValue_Int32(reader, "QuoteId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.Closed = GetReaderValue_NullableBoolean(reader, "Closed", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
					obj.CompanySOApproved = GetReaderValue_NullableBoolean(reader, "CompanySOApproved", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.QuoteValue = GetReaderValue_NullableDouble(reader, "QuoteValue", null);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.OpenLines = GetReaderValue_NullableInt32(reader, "OpenLines", null);
					obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
					obj.ContactEmail = GetReaderValue_String(reader, "ContactEmail", "");
                    //[002] code start
                    obj.AS9120 = GetReaderValue_NullableBoolean(reader, "AS9120", false);
                    //[002] code end
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Quote", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetIDFromNumber 
		/// Calls [usp_select_Quote_ID_from_Number]
        /// </summary>
		public override QuoteDetails GetIDFromNumber(System.Int32? quoteNumber,System.Int32? clientNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Quote_ID_from_Number", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@QuoteNumber", SqlDbType.Int).Value = quoteNumber;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetQuoteFromReader(reader);
					QuoteDetails obj = new QuoteDetails();
					obj.QuoteId = GetReaderValue_Int32(reader, "QuoteId", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Quote", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetNextNumber 
		/// Calls [usp_select_Quote_NextNumber]
        /// </summary>
		public override QuoteDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Quote_NextNumber", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@NewNumber", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetQuoteFromReader(reader);
					QuoteDetails obj = new QuoteDetails();
					obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Quote", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForCompany 
		/// Calls [usp_selectAll_Quote_for_Company]
        /// </summary>
		public override List<QuoteDetails> GetListForCompany(System.Int32? companyId, System.Boolean? includeClosed) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Quote_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<QuoteDetails> lst = new List<QuoteDetails>();
				while (reader.Read()) {
					QuoteDetails obj = new QuoteDetails();
					obj.QuoteId = GetReaderValue_Int32(reader, "QuoteId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.Closed = GetReaderValue_NullableBoolean(reader, "Closed", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
					obj.CompanySOApproved = GetReaderValue_NullableBoolean(reader, "CompanySOApproved", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.QuoteValue = GetReaderValue_NullableDouble(reader, "QuoteValue", null);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.OpenLines = GetReaderValue_NullableInt32(reader, "OpenLines", null);
					obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Quotes", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForSourcingResult 
		/// Calls [usp_selectAll_Quote_for_SourcingResult]
        /// </summary>
		public override List<QuoteDetails> GetListForSourcingResult(System.Int32? sourcingResultNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Quote_for_SourcingResult", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SourcingResultNo", SqlDbType.Int).Value = sourcingResultNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<QuoteDetails> lst = new List<QuoteDetails>();
				while (reader.Read()) {
					QuoteDetails obj = new QuoteDetails();
					obj.QuoteId = GetReaderValue_Int32(reader, "QuoteId", 0);
					obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Quotes", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListOpenForCompany 
		/// Calls [usp_selectAll_Quote_open_for_Company]
        /// </summary>
		public override List<QuoteDetails> GetListOpenForCompany(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Quote_open_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<QuoteDetails> lst = new List<QuoteDetails>();
				while (reader.Read()) {
					QuoteDetails obj = new QuoteDetails();
					obj.QuoteId = GetReaderValue_Int32(reader, "QuoteId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.Closed = GetReaderValue_NullableBoolean(reader, "Closed", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
					obj.CompanySOApproved = GetReaderValue_NullableBoolean(reader, "CompanySOApproved", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.QuoteValue = GetReaderValue_NullableDouble(reader, "QuoteValue", null);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.OpenLines = GetReaderValue_NullableInt32(reader, "OpenLines", null);
					obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Quotes", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListOpenForLogin 
		/// Calls [usp_selectAll_Quote_open_for_Login]
        /// </summary>
		public override List<QuoteDetails> GetListOpenForLogin(System.Int32? loginId, System.Int32? topToSelect) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Quote_open_for_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<QuoteDetails> lst = new List<QuoteDetails>();
				while (reader.Read()) {
					QuoteDetails obj = new QuoteDetails();
					obj.QuoteId = GetReaderValue_Int32(reader, "QuoteId", 0);
					obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.Balance = GetReaderValue_NullableDouble(reader, "Balance", null);
                    obj.IsImportant = GetReaderValue_NullableBoolean(reader, "IsImportant", false);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Quotes", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListRecentForLogin 
		/// Calls [usp_selectAll_Quote_recent_for_Login]
        /// </summary>
		public override List<QuoteDetails> GetListRecentForLogin(System.Int32? loginId, System.Int32? topToSelect) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Quote_recent_for_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<QuoteDetails> lst = new List<QuoteDetails>();
				while (reader.Read()) {
					QuoteDetails obj = new QuoteDetails();
					obj.QuoteId = GetReaderValue_Int32(reader, "QuoteId", 0);
					obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.Balance = GetReaderValue_NullableDouble(reader, "Balance", null);
                    obj.IsImportant = GetReaderValue_NullableBoolean(reader, "IsImportant", false);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Quotes", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Quote
		/// Calls [usp_update_Quote]
        /// </summary>
        public override bool Update(System.Int32? quoteId, System.String notes, System.String instructions, System.Boolean? closed, System.Int32? contactNo, System.DateTime? dateQuoted, System.Int32? currencyNo, System.Int32? salesman, System.Int32? divisionNo, System.Double? freight, System.Int32? termsNo, System.Int32? incotermNo, System.Int32? updatedBy, System.Boolean? As9120, System.Boolean? isImportant, System.Int32? quoteStatus)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Quote", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@QuoteId", SqlDbType.Int).Value = quoteId;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
				cmd.Parameters.Add("@Closed", SqlDbType.Bit).Value = closed;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@DateQuoted", SqlDbType.DateTime).Value = dateQuoted;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
				cmd.Parameters.Add("@Freight", SqlDbType.Float).Value = freight;
				cmd.Parameters.Add("@TermsNo", SqlDbType.Int).Value = termsNo;
				cmd.Parameters.Add("@IncotermNo", SqlDbType.Int).Value = incotermNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //[002] code start
                cmd.Parameters.Add("@AS9120", SqlDbType.Bit).Value = As9120;
                //[002] code end
                cmd.Parameters.Add("@IsImportant", SqlDbType.Bit).Value = isImportant;
                cmd.Parameters.Add("@QuoteStatus", SqlDbType.Int).Value = quoteStatus;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Quote", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Quote
		/// Calls [usp_update_Quote_CheckClosed]
        /// </summary>
		public override bool UpdateCheckClosed(System.Int32? quoteNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Quote_CheckClosed", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@QuoteNo", SqlDbType.Int).Value = quoteNo;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Quote", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}
