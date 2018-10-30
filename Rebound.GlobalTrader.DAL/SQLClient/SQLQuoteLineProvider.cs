//Marker     Changed by      Date          Remarks
//[001]      Vinay           22/01/2014    CR:- Add AS9120 Requirement in GT application
//[002]      Aashu Singh     21/June/2018  [REB-11754]: MSL level
//[003]      Aashu Singh     1/Aug/2018    [REB-12517]: Filter on quotes marked as important on the quote screen
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
	public class SqlQuoteLineProvider : QuoteLineProvider {
        /// <summary>
        /// DataListNugget 
		/// Calls [usp_datalistnugget_QuoteLine]
        /// </summary>
        public override List<QuoteLineDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.Boolean? includeClosed, System.Int32? quoteNoLo, System.Int32? quoteNoHi, System.DateTime? dateQuotedFrom, System.DateTime? dateQuotedTo, System.Boolean? recentOnly, System.Boolean? important, System.Int32? totalLo, System.Int32? totalHi, System.Int32? qStatus)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_QuoteLine", cn);
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
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@SalesmanSearch", SqlDbType.Int).Value = salesmanSearch;
				cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
				cmd.Parameters.Add("@QuoteNoLo", SqlDbType.Int).Value = quoteNoLo;
				cmd.Parameters.Add("@QuoteNoHi", SqlDbType.Int).Value = quoteNoHi;
				cmd.Parameters.Add("@DateQuotedFrom", SqlDbType.DateTime).Value = dateQuotedFrom;
				cmd.Parameters.Add("@DateQuotedTo", SqlDbType.DateTime).Value = dateQuotedTo;
				cmd.Parameters.Add("@RecentOnly", SqlDbType.Bit).Value = recentOnly;
                //[003] start
                cmd.Parameters.Add("@Important", SqlDbType.Bit).Value = important;
                //[003] end
                cmd.Parameters.Add("@TotalLo", SqlDbType.Int).Value = totalLo;
                cmd.Parameters.Add("@TotalHi", SqlDbType.Int).Value = totalHi;
                cmd.Parameters.Add("@QuoteStatus", SqlDbType.Int).Value = qStatus;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<QuoteLineDetails> lst = new List<QuoteLineDetails>();
				while (reader.Read()) {
					QuoteLineDetails obj = new QuoteLineDetails();
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.QuoteId = GetReaderValue_Int32(reader, "QuoteId", 0);
					obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.TotalInBase = GetReaderValue_NullableDouble(reader, "TotalInBase", 0);
                    obj.TotalValue = GetReaderValue_NullableDouble(reader, "TotalValue", 0);
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", 0);
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.QuoteStatusName = GetReaderValue_String(reader, "QuoteStatusName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get QuoteLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete QuoteLine
		/// Calls [usp_delete_QuoteLine]
		/// </summary>
		public override bool Delete(System.Int32? quoteLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_QuoteLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@QuoteLineId", SqlDbType.Int).Value = quoteLineId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete QuoteLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_QuoteLine]
		/// </summary>
        public override Int32 Insert(System.Int32? quoteNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.String eta, System.String instructions, System.Int32? productNo, System.Int32? reasonNo, System.String customerPart, System.Int32? serviceNo, System.Int32? stockNo, System.Byte? rohs, System.String notes, System.Int32? originalOfferCurrencyNo, System.DateTime? originalOfferDate, System.Double? originalOfferPrice, System.Int32? originalOfferSupplierNo, System.Int32? sourcingResultNo, System.Int32? updatedBy, System.Byte? productSource, System.String mslLevel, System.Boolean? printHazardous)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_QuoteLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@QuoteNo", SqlDbType.Int).Value = quoteNo;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@ETA", SqlDbType.NVarChar).Value = eta;
				cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@ReasonNo", SqlDbType.Int).Value = reasonNo;
				cmd.Parameters.Add("@CustomerPart", SqlDbType.NVarChar).Value = customerPart;
				cmd.Parameters.Add("@ServiceNo", SqlDbType.Int).Value = serviceNo;
				cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@OriginalOfferCurrencyNo", SqlDbType.Int).Value = originalOfferCurrencyNo;
				cmd.Parameters.Add("@OriginalOfferDate", SqlDbType.DateTime).Value = originalOfferDate;
				cmd.Parameters.Add("@OriginalOfferPrice", SqlDbType.Float).Value = originalOfferPrice;
				cmd.Parameters.Add("@OriginalOfferSupplierNo", SqlDbType.Int).Value = originalOfferSupplierNo;
				cmd.Parameters.Add("@SourcingResultNo", SqlDbType.Int).Value = sourcingResultNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //[001] code start
                cmd.Parameters.Add("@ProductSource", SqlDbType.TinyInt).Value = productSource;
                //[001] code end
                //cmd.Parameters.Add("@IsImportant", SqlDbType.Bit).Value = isImportant;   
                cmd.Parameters.Add("@MSLLevel", SqlDbType.NVarChar).Value = mslLevel;
                cmd.Parameters.Add("@PrintHazardous", SqlDbType.Bit).Value = printHazardous;
				cmd.Parameters.Add("@QuoteLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@QuoteLineId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert QuoteLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_QuoteLine_from_CustomerRequirement]
		/// </summary>
		public override Int32 InsertFromCustomerRequirement(System.Int32? customerRequirementId, System.Int32? quoteNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_QuoteLine_from_CustomerRequirement", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CustomerRequirementId", SqlDbType.Int).Value = customerRequirementId;
				cmd.Parameters.Add("@QuoteNo", SqlDbType.Int).Value = quoteNo;
				cmd.Parameters.Add("@QuoteLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@QuoteLineId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert QuoteLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_QuoteLine_from_SourcingResult]
		/// </summary>
		public override Int32 InsertFromSourcingResult(System.Int32? sourcingResultId, System.Int32? quoteNo, System.DateTime? dateQuoted) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_QuoteLine_from_SourcingResult", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SourcingResultId", SqlDbType.Int).Value = sourcingResultId;
				cmd.Parameters.Add("@QuoteNo", SqlDbType.Int).Value = quoteNo;
				cmd.Parameters.Add("@DateQuoted", SqlDbType.DateTime).Value = dateQuoted;
				cmd.Parameters.Add("@QuoteLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@QuoteLineId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert QuoteLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// ItemSearch 
		/// Calls [usp_itemsearch_QuoteLine]
        /// </summary>
		public override List<QuoteLineDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Boolean? includeClosed, System.Int32? quoteNoLo, System.Int32? quoteNoHi, System.DateTime? dateQuotedFrom, System.DateTime? dateQuotedTo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_itemsearch_QuoteLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
				cmd.Parameters.Add("@QuoteNoLo", SqlDbType.Int).Value = quoteNoLo;
				cmd.Parameters.Add("@QuoteNoHi", SqlDbType.Int).Value = quoteNoHi;
				cmd.Parameters.Add("@DateQuotedFrom", SqlDbType.DateTime).Value = dateQuotedFrom;
				cmd.Parameters.Add("@DateQuotedTo", SqlDbType.DateTime).Value = dateQuotedTo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<QuoteLineDetails> lst = new List<QuoteLineDetails>();
				while (reader.Read()) {
					QuoteLineDetails obj = new QuoteLineDetails();
					obj.QuoteLineId = GetReaderValue_Int32(reader, "QuoteLineId", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get QuoteLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_QuoteLine]
        /// </summary>
		public override QuoteLineDetails Get(System.Int32? quoteLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_QuoteLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@QuoteLineId", SqlDbType.Int).Value = quoteLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetQuoteLineFromReader(reader);
					QuoteLineDetails obj = new QuoteLineDetails();
					obj.QuoteLineId = GetReaderValue_Int32(reader, "QuoteLineId", 0);
					obj.QuoteNo = GetReaderValue_Int32(reader, "QuoteNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.ETA = GetReaderValue_String(reader, "ETA", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.ReasonNo = GetReaderValue_NullableInt32(reader, "ReasonNo", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.OriginalOfferPrice = GetReaderValue_NullableDouble(reader, "OriginalOfferPrice", null);
					obj.OriginalOfferCurrencyNo = GetReaderValue_NullableInt32(reader, "OriginalOfferCurrencyNo", null);
					obj.OriginalOfferDate = GetReaderValue_NullableDateTime(reader, "OriginalOfferDate", null);
					obj.OriginalOfferSupplierNo = GetReaderValue_NullableInt32(reader, "OriginalOfferSupplierNo", null);
					obj.NotQuoted = GetReaderValue_Boolean(reader, "NotQuoted", false);
					obj.SourcingResultNo = GetReaderValue_NullableInt32(reader, "SourcingResultNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.ReasonName = GetReaderValue_String(reader, "ReasonName", "");
					obj.OriginalOfferCurrencyCode = GetReaderValue_String(reader, "OriginalOfferCurrencyCode", "");
					obj.OriginalOfferSupplierName = GetReaderValue_String(reader, "OriginalOfferSupplierName", "");
					obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
                    //[001] code start
                    obj.ProductSource = GetReaderValue_NullableByte(reader, "ProductSource", null);
                    obj.SourcingTable = GetReaderValue_String(reader, "SourcingTable", "");
                    obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);
                    obj.IsIPOCreated = GetReaderValue_Boolean(reader, "IsIPOCreated", false);
                    obj.POHubCompanyNo = GetReaderValue_NullableInt32(reader, "POHubCompanyNo", null);
                   // obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);
                   
                    //[001] code end
                    obj.QuoteNotes = GetReaderValue_String(reader, "Notes", "");
                    obj.ProductInactive = GetReaderValue_NullableBoolean(reader, "ProductInactive", false);
                    obj.DutyCode = GetReaderValue_String(reader, "DutyCode", "");
                    obj.DutyRate = GetReaderValue_NullableDouble(reader, "ProductDutyRate", null);
                   // obj.IsImportant = GetReaderValue_Boolean(reader, "IsImportant", false);
                    obj.MSL = GetReaderValue_String(reader, "MSLLevel", "");
                    obj.IsProdHazardous = GetReaderValue_NullableBoolean(reader, "IsProdHazardous", false);
                    obj.PrintHazardous = GetReaderValue_NullableBoolean(reader, "PrintHazardous", false);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get QuoteLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListClosedForQuote 
		/// Calls [usp_selectAll_QuoteLine_Closed_for_Quote]
        /// </summary>
		public override List<QuoteLineDetails> GetListClosedForQuote(System.Int32? quoteId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_QuoteLine_Closed_for_Quote", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@QuoteId", SqlDbType.Int).Value = quoteId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<QuoteLineDetails> lst = new List<QuoteLineDetails>();
				while (reader.Read()) {
					QuoteLineDetails obj = new QuoteLineDetails();
					obj.QuoteLineId = GetReaderValue_Int32(reader, "QuoteLineId", 0);
					obj.QuoteNo = GetReaderValue_Int32(reader, "QuoteNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.ETA = GetReaderValue_String(reader, "ETA", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.ReasonNo = GetReaderValue_NullableInt32(reader, "ReasonNo", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.OriginalOfferPrice = GetReaderValue_NullableDouble(reader, "OriginalOfferPrice", null);
					obj.OriginalOfferCurrencyNo = GetReaderValue_NullableInt32(reader, "OriginalOfferCurrencyNo", null);
					obj.OriginalOfferDate = GetReaderValue_NullableDateTime(reader, "OriginalOfferDate", null);
					obj.OriginalOfferSupplierNo = GetReaderValue_NullableInt32(reader, "OriginalOfferSupplierNo", null);
					obj.NotQuoted = GetReaderValue_Boolean(reader, "NotQuoted", false);
					obj.SourcingResultNo = GetReaderValue_NullableInt32(reader, "SourcingResultNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.ReasonName = GetReaderValue_String(reader, "ReasonName", "");
					obj.OriginalOfferCurrencyCode = GetReaderValue_String(reader, "OriginalOfferCurrencyCode", "");
					obj.OriginalOfferSupplierName = GetReaderValue_String(reader, "OriginalOfferSupplierName", "");
					obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
                    //[001] code start
                    obj.ProductSource = GetReaderValue_NullableByte(reader, "ProductSource", null);
                    //[001] code end
                    //[002] code start
                    obj.MSL = GetReaderValue_String(reader, "MSLLevel", "");
                    //[002] code end
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get QuoteLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForQuote 
		/// Calls [usp_selectAll_QuoteLine_for_Quote]
        /// </summary>
		public override List<QuoteLineDetails> GetListForQuote(System.Int32? quoteId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_QuoteLine_for_Quote", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@QuoteId", SqlDbType.Int).Value = quoteId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<QuoteLineDetails> lst = new List<QuoteLineDetails>();
				while (reader.Read()) {
					QuoteLineDetails obj = new QuoteLineDetails();
					obj.QuoteLineId = GetReaderValue_Int32(reader, "QuoteLineId", 0);
					obj.QuoteNo = GetReaderValue_Int32(reader, "QuoteNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.ETA = GetReaderValue_String(reader, "ETA", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.ReasonNo = GetReaderValue_NullableInt32(reader, "ReasonNo", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.OriginalOfferPrice = GetReaderValue_NullableDouble(reader, "OriginalOfferPrice", null);
					obj.OriginalOfferCurrencyNo = GetReaderValue_NullableInt32(reader, "OriginalOfferCurrencyNo", null);
					obj.OriginalOfferDate = GetReaderValue_NullableDateTime(reader, "OriginalOfferDate", null);
					obj.OriginalOfferSupplierNo = GetReaderValue_NullableInt32(reader, "OriginalOfferSupplierNo", null);
					obj.NotQuoted = GetReaderValue_Boolean(reader, "NotQuoted", false);
					obj.SourcingResultNo = GetReaderValue_NullableInt32(reader, "SourcingResultNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.ReasonName = GetReaderValue_String(reader, "ReasonName", "");
					obj.OriginalOfferCurrencyCode = GetReaderValue_String(reader, "OriginalOfferCurrencyCode", "");
					obj.OriginalOfferSupplierName = GetReaderValue_String(reader, "OriginalOfferSupplierName", "");
					obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
                    //[001] code start
                    obj.ProductSource = GetReaderValue_NullableByte(reader, "ProductSource", null);
                    //[001] code end
                    obj.DutyCode = GetReaderValue_String(reader, "DutyCode", "");
                    //[002] start
                    obj.MSL = GetReaderValue_String(reader, "MSLLevel", "");
                    //[002] end
                    obj.PrintHazardous = GetReaderValue_NullableBoolean(reader, "PrintHazardous", false);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get QuoteLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListOpenForQuote 
		/// Calls [usp_selectAll_QuoteLine_Open_for_Quote]
        /// </summary>
		public override List<QuoteLineDetails> GetListOpenForQuote(System.Int32? quoteId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_QuoteLine_Open_for_Quote", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@QuoteId", SqlDbType.Int).Value = quoteId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<QuoteLineDetails> lst = new List<QuoteLineDetails>();
				while (reader.Read()) {
					QuoteLineDetails obj = new QuoteLineDetails();
					obj.QuoteLineId = GetReaderValue_Int32(reader, "QuoteLineId", 0);
					obj.QuoteNo = GetReaderValue_Int32(reader, "QuoteNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.ETA = GetReaderValue_String(reader, "ETA", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.ReasonNo = GetReaderValue_NullableInt32(reader, "ReasonNo", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.OriginalOfferPrice = GetReaderValue_NullableDouble(reader, "OriginalOfferPrice", null);
					obj.OriginalOfferCurrencyNo = GetReaderValue_NullableInt32(reader, "OriginalOfferCurrencyNo", null);
					obj.OriginalOfferDate = GetReaderValue_NullableDateTime(reader, "OriginalOfferDate", null);
					obj.OriginalOfferSupplierNo = GetReaderValue_NullableInt32(reader, "OriginalOfferSupplierNo", null);
					obj.NotQuoted = GetReaderValue_Boolean(reader, "NotQuoted", false);
					obj.SourcingResultNo = GetReaderValue_NullableInt32(reader, "SourcingResultNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.ReasonName = GetReaderValue_String(reader, "ReasonName", "");
					obj.OriginalOfferCurrencyCode = GetReaderValue_String(reader, "OriginalOfferCurrencyCode", "");
					obj.OriginalOfferSupplierName = GetReaderValue_String(reader, "OriginalOfferSupplierName", "");
					obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
                    //[001] code start
                    obj.ProductSource = GetReaderValue_NullableByte(reader, "ProductSource", null);
                    //[001] code end
                    //[002] code start
                    obj.MSL = GetReaderValue_String(reader, "MSLLevel", "");
                    //[002] code end
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get QuoteLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Source 
		/// Calls [usp_source_QuoteLine]
        /// </summary>
        public override List<QuoteLineDetails> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool hasServerLocal)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
            outDate = null;
			try {
                if (!hasServerLocal)
                {
                    cn = new SqlConnection(this.GTConnectionString);
                    cmd = new SqlCommand("usp_source_QuoteLine_Without_ClientId", cn);
                }
                else
                {
                    cn = new SqlConnection(this.ConnectionString);
                    cmd = new SqlCommand("usp_source_QuoteLine", cn);
                }
                				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
                cmd.Parameters.Add("@Index", SqlDbType.Int).Value = index;
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
                cmd.Parameters.Add("@FinishDate", SqlDbType.DateTime).Value = endDate;
				cn.Open();
                //DbDataReader reader = ExecuteReader(cmd);
                SqlDataReader reader = cmd.ExecuteReader();
				List<QuoteLineDetails> lst = new List<QuoteLineDetails>();
				while (reader.Read()) {
					QuoteLineDetails obj = new QuoteLineDetails();
					obj.QuoteLineId = GetReaderValue_Int32(reader, "QuoteLineId", 0);
					obj.QuoteNo = GetReaderValue_Int32(reader, "QuoteNo", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
					obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
					obj.ClientDataVisibleToOthers = GetReaderValue_NullableBoolean(reader, "ClientDataVisibleToOthers", null);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.SalesmanName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.ClientCode = GetReaderValue_String(reader, "ClientCode", "");
                    obj.Reason = GetReaderValue_String(reader, "Reason", "");
                    obj.ReasonNote = GetReaderValue_String(reader, "ReasonNote", "");
					lst.Add(obj);
					obj = null;
				}
                reader.NextResult();
                while (reader.Read())
                {
                    outDate = GetReaderValue_NullableDateTime(reader, "OutPutDate", null);
                }
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get QuoteLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update QuoteLine
		/// Calls [usp_update_QuoteLine]
        /// </summary>
        public override bool Update(System.Int32? quoteLineId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.String eta, System.String instructions, System.Int32? productNo, System.String customerPart, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Byte? productSource, System.String mslLevel, System.Boolean? printHazardous)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_QuoteLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@QuoteLineId", SqlDbType.Int).Value = quoteLineId;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@ETA", SqlDbType.NVarChar).Value = eta;
				cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@CustomerPart", SqlDbType.NVarChar).Value = customerPart;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //[001] code start
                cmd.Parameters.Add("@ProductSource", SqlDbType.TinyInt).Value = productSource;
                //[001] code end
               // cmd.Parameters.Add("@IsImportant", SqlDbType.Int).Value = isImportant;
                cmd.Parameters.Add("@MSLLevel", SqlDbType.NVarChar).Value = mslLevel;
                cmd.Parameters.Add("@PrintHazardous", SqlDbType.Bit).Value = printHazardous;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update QuoteLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update QuoteLine
		/// Calls [usp_update_QuoteLine_Close]
        /// </summary>
		public override bool UpdateClose(System.Int32? quoteLineId, System.Int32? reasonNo, System.Int32? updatedBy, System.String reasons) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_QuoteLine_Close", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@QuoteLineId", SqlDbType.Int).Value = quoteLineId;
				cmd.Parameters.Add("@ReasonNo", SqlDbType.Int).Value = reasonNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@Reasons", SqlDbType.VarChar).Value = reasons;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update QuoteLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// UpdateOffer
        /// Calls [usp_update_QuoteLine_OriginalOffer]
        /// </summary>
        public override bool UpdateOffer(System.Int32? quoteLineId, System.Int32? sourcingResultNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_QuoteLine_OriginalOffer", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@QuoteLineId", SqlDbType.Int).Value = quoteLineId;
                cmd.Parameters.Add("@SourcingResultNo", SqlDbType.Int).Value = sourcingResultNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                ExecuteNonQuery(cmd);
                int ret = (Int32)cmd.Parameters["@RowsAffected"].Value;
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update QuoteLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Get
        /// Calls [usp_select_PurchaseRequestLineDetails]
        /// </summary>
        public override List<List<object>> GetPQLineList(System.Int32? PQLineId, System.Int32? clientId, System.Int32? companyNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_PurchaseRequestLineDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@PurchaseRequestId", SqlDbType.Int).Value = PQLineId;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                
                if (reader.HasRows)
                {
                    return GetQuoteLineFromReader(reader);
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get PurchaseQuoteLine Details", sqlex);
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
