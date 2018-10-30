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
	public class SqlPOQuoteLineProvider : POQuoteLineProvider {

        /// <summary>
        /// GetListClosedForQuote 
        /// Calls [usp_selectAll_PurchaseRequestLine]
        /// </summary>
        public override List<POQuoteLineDetails> GetListLines(System.Int32? poQuoteId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_PurchaseRequestLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@PurchaseRequestId", SqlDbType.Int).Value = poQuoteId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<POQuoteLineDetails> lst = new List<POQuoteLineDetails>();
                while (reader.Read())
                {
                    POQuoteLineDetails obj = new POQuoteLineDetails();
                    obj.PurchaseQuoteLineId = GetReaderValue_Int32(reader, "PurchaseRequestLineId", 0);
                    obj.PurchaseQuoteNo = GetReaderValue_Int32(reader, "PurchaseRequestNo", 0);
                    obj.CustomerRequirementNo = GetReaderValue_Int32(reader, "CustomerRequirementNo", 0);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.TargetPrice = GetReaderValue_Double(reader, "TargetPrice", 0);
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
                    obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
                    obj.BOMNo = GetReaderValue_Int32(reader, "BOMNo", 0);
                    obj.UnitPrice = GetReaderValue_Double(reader, "UnitPrice", 0);
                    obj.PRCurencyCode = GetReaderValue_String(reader, "PRCurencyCode", "");
                    obj.PRCurrencyNo = GetReaderValue_Int32(reader, "PRCurrencyNo", 0);
                    obj.ReqCurrencyCode = GetReaderValue_String(reader, "ReqCurrencyCode", "");
                    obj.ReqCurrencyNo = GetReaderValue_Int32(reader, "ReqCurrencyNo", 0);
                    obj.ConvertedTargetValue = GetReaderValue_Double(reader, "ConvertedTargetValue", 0);
                    obj.PRStatus = GetReaderValue_String(reader, "PRStatus", "");
                    obj.PQStatus = GetReaderValue_Int32(reader, "PQStatus", 0);
                    obj.PHPrice = GetReaderValue_Double(reader, "PHPrice", 0);
                    obj.MSLR = GetReaderValue_String(reader, "MSL", "");
                    obj.FactorySealedR = GetReaderValue_Boolean(reader, "FactorySealed", false);
                    obj.AS9120 = GetReaderValue_Boolean(reader, "AS9120", false);
                    obj.IsGlobalCurrencySame = GetReaderValue_NullableBoolean(reader, "IsGlobalCurrencySame", false);
                    //obj.LeadTime = GetReaderValue_String(reader, "LeadTime", "");
                   // obj.RoHSStatus = GetReaderValue_String(reader, "RoHSStatus", "");
                   // obj.FactorySealed = GetReaderValue_String(reader, "FactorySealed", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get QuoteLines", sqlex);
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
        /// Calls [usp_insert_PurchaseRequestLine]
        /// </summary>
        public override Int32 Insert(System.Int32? poQuoteNo, System.String xmlReqIds, System.Int32? updatedBy,System.Int32? clientNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_PurchaseRequestLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PurchaseRequestNo", SqlDbType.Int).Value = poQuoteNo;
                cmd.Parameters.Add("@xmlCustReqNo", SqlDbType.VarChar).Value = xmlReqIds;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@Rowaffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@Rowaffected"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Purchase QuoteLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Delete PO QuoteLine
        /// Calls [usp_delete_PurchaseRequestLine]
        /// </summary>
        public override bool Delete(System.Int32? quoteLineId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_PurchaseRequestLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PurchaseRequestLineId", SqlDbType.Int).Value = quoteLineId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete Price Request Line", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// DataListNugget 
        /// Calls [usp_datalistnugget_PurchaseRequetLine]
        /// </summary>
        public override List<POQuoteLineDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.Boolean? includeClosed, System.Int32? poQuoteNoLo, System.Int32? poQuoteNoHi, System.DateTime? dateQuotedFrom, System.DateTime? dateQuotedTo, System.Boolean? recentOnly)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_datalistnugget_PurchaseRequetLine", cn);
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
                //cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
                cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
                cmd.Parameters.Add("@SalesmanSearch", SqlDbType.Int).Value = salesmanSearch;
                cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
                cmd.Parameters.Add("@POQuoteNoLo", SqlDbType.Int).Value = poQuoteNoLo;
                cmd.Parameters.Add("@POQuoteNoHi", SqlDbType.Int).Value = poQuoteNoHi;
                cmd.Parameters.Add("@DatePOQuotedFrom", SqlDbType.DateTime).Value = dateQuotedFrom;
                cmd.Parameters.Add("@DatePOQuotedTo", SqlDbType.DateTime).Value = dateQuotedTo;
                cmd.Parameters.Add("@RecentOnly", SqlDbType.Bit).Value = recentOnly;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<POQuoteLineDetails> lst = new List<POQuoteLineDetails>();
                while (reader.Read())
                {
                    POQuoteLineDetails obj = new POQuoteLineDetails();
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    //obj.UnitPrice = GetReaderValue_Double(reader, "Price", 0);
                    obj.PurchaseQuoteLineId = GetReaderValue_Int32(reader, "PurchaseRequestLineId", 0);
                    obj.PurchaseQuoteNo = GetReaderValue_Int32(reader, "PurchaseRequestId", 0);
                    obj.PurchaseQuoteNumber = GetReaderValue_Int32(reader, "PurchaseRequestNumber", 0);
                   // obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.DatePOQuoted = GetReaderValue_DateTime(reader, "DateRequested", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                   // obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
                    obj.BOMNo = GetReaderValue_Int32(reader, "BOMNo", 0);
                    obj.SalesmanName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Purchase QuoteLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Source 
        /// Calls [usp_source_PurchaseRequestLineDetails]
        /// </summary>
        public override List<POQuoteLineDetails> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool hasServerLocal)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            outDate = null;
            try
            {
                if (!hasServerLocal)
                {
                    cn = new SqlConnection(this.GTConnectionString);
                    cmd = new SqlCommand("usp_source_PurchaseQuoteLine_Without_ClientId", cn);
                }
                else
                {
                    cn = new SqlConnection(this.ConnectionString);
                    cmd = new SqlCommand("usp_source_PurchaseRequestLineDetails", cn);
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
                List<POQuoteLineDetails> lst = new List<POQuoteLineDetails>();
                while (reader.Read())
                {
                    POQuoteLineDetails obj = new POQuoteLineDetails();
                    obj.PurchaseQuoteLineId = GetReaderValue_Int32(reader, "PurchaseRequestLineId", 0);
                    obj.PurchaseRequestLineDetailId = GetReaderValue_Int32(reader, "PurchaseRequestLineDetailId", 0);
                    obj.PurchaseQuoteNo = GetReaderValue_Int32(reader, "PurchaseRequestNo", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                   // obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    //obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.UnitPrice = GetReaderValue_Double(reader, "Price", 0);
                   // obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                   // obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.PurchaseQuoteNumber = GetReaderValue_Int32(reader, "PurchaseRequestNumber", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.DatePOQuoted = GetReaderValue_DateTime(reader, "DatePOQuoted", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                   // obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    //obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    //obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                   // obj.ClientDataVisibleToOthkghhers = GetReaderValue_NullableBoolean(reader, "ClientDataVisibleToOthers", null);
                    obj.Salesman = GetReaderValue_Int32(reader, "Buyer", 0);
                    obj.SalesmanName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.MSL = GetReaderValue_String(reader, "MSL", "");
                    obj.SPQ = GetReaderValue_String(reader, "SPQ", "");
                    obj.LeadTime = GetReaderValue_String(reader, "LeadTime", "");
                    obj.RoHSStatus = GetReaderValue_String(reader, "RoHSStatus", "");
                    obj.FactorySealed = GetReaderValue_String(reader, "FactorySealed", "");
                    obj.SupplierType = GetReaderValue_String(reader, "SupplierType", "");

                    lst.Add(obj);
                    obj = null;
                }
                reader.NextResult();
                while (reader.Read())
                {
                    outDate = GetReaderValue_NullableDateTime(reader, "OutPutDate", null);
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get QuoteLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		
        ///// <summary>
        ///// Create a new row
        ///// Calls [usp_insert_QuoteLine_from_CustomerRequirement]
        ///// </summary>
        //public override Int32 InsertFromCustomerRequirement(System.Int32? customerRequirementId, System.Int32? quoteNo) {
        //    SqlConnection cn = null;
        //    SqlCommand cmd = null;
        //    try {
        //        cn = new SqlConnection(this.ConnectionString);
        //        cmd = new SqlCommand("usp_insert_QuoteLine_from_CustomerRequirement", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@CustomerRequirementId", SqlDbType.Int).Value = customerRequirementId;
        //        cmd.Parameters.Add("@QuoteNo", SqlDbType.Int).Value = quoteNo;
        //        cmd.Parameters.Add("@QuoteLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
        //        cn.Open();
        //        int ret = ExecuteNonQuery(cmd);
        //        return (Int32)cmd.Parameters["@QuoteLineId"].Value;
        //    } catch (SqlException sqlex) {
        //        //LogException(sqlex);
        //        throw new Exception("Failed to insert QuoteLine", sqlex);
        //    } finally {
        //        cmd.Dispose();
        //        cn.Close();
        //        cn.Dispose();
        //    }
        //}
		
		
        ///// <summary>
        ///// Create a new row
        ///// Calls [usp_insert_QuoteLine_from_SourcingResult]
        ///// </summary>
        //public override Int32 InsertFromSourcingResult(System.Int32? sourcingResultId, System.Int32? quoteNo, System.DateTime? dateQuoted) {
        //    SqlConnection cn = null;
        //    SqlCommand cmd = null;
        //    try {
        //        cn = new SqlConnection(this.ConnectionString);
        //        cmd = new SqlCommand("usp_insert_QuoteLine_from_SourcingResult", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@SourcingResultId", SqlDbType.Int).Value = sourcingResultId;
        //        cmd.Parameters.Add("@QuoteNo", SqlDbType.Int).Value = quoteNo;
        //        cmd.Parameters.Add("@DateQuoted", SqlDbType.DateTime).Value = dateQuoted;
        //        cmd.Parameters.Add("@QuoteLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
        //        cn.Open();
        //        int ret = ExecuteNonQuery(cmd);
        //        return (Int32)cmd.Parameters["@QuoteLineId"].Value;
        //    } catch (SqlException sqlex) {
        //        //LogException(sqlex);
        //        throw new Exception("Failed to insert QuoteLine", sqlex);
        //    } finally {
        //        cmd.Dispose();
        //        cn.Close();
        //        cn.Dispose();
        //    }
        //}
		
		
        ///// <summary>
        ///// ItemSearch 
        ///// Calls [usp_itemsearch_QuoteLine]
        ///// </summary>
        //public override List<QuoteLineDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Boolean? includeClosed, System.Int32? quoteNoLo, System.Int32? quoteNoHi, System.DateTime? dateQuotedFrom, System.DateTime? dateQuotedTo) {
        //    SqlConnection cn = null;
        //    SqlCommand cmd = null;
        //    try {
        //        cn = new SqlConnection(this.ConnectionString);
        //        cmd = new SqlCommand("usp_itemsearch_QuoteLine", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = 60;
        //        cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
        //        cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
        //        cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
        //        cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
        //        cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
        //        cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
        //        cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
        //        cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
        //        cmd.Parameters.Add("@QuoteNoLo", SqlDbType.Int).Value = quoteNoLo;
        //        cmd.Parameters.Add("@QuoteNoHi", SqlDbType.Int).Value = quoteNoHi;
        //        cmd.Parameters.Add("@DateQuotedFrom", SqlDbType.DateTime).Value = dateQuotedFrom;
        //        cmd.Parameters.Add("@DateQuotedTo", SqlDbType.DateTime).Value = dateQuotedTo;
        //        cn.Open();
        //        DbDataReader reader = ExecuteReader(cmd);
        //        List<QuoteLineDetails> lst = new List<QuoteLineDetails>();
        //        while (reader.Read()) {
        //            QuoteLineDetails obj = new QuoteLineDetails();
        //            obj.QuoteLineId = GetReaderValue_Int32(reader, "QuoteLineId", 0);
        //            obj.Part = GetReaderValue_String(reader, "Part", "");
        //            obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
        //            obj.Price = GetReaderValue_Double(reader, "Price", 0);
        //            obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
        //            obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
        //            obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
        //            obj.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue);
        //            obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
        //            obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
        //            obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
        //            lst.Add(obj);
        //            obj = null;
        //        }
        //        return lst;
        //    } catch (SqlException sqlex) {
        //        //LogException(sqlex);
        //        throw new Exception("Failed to get QuoteLines", sqlex);
        //    } finally {
        //        cmd.Dispose();
        //        cn.Close();
        //        cn.Dispose();
        //    }
        //}
		
		
        ///// <summary>
        ///// Get 
        ///// Calls [usp_select_QuoteLine]
        ///// </summary>
        //public override QuoteLineDetails Get(System.Int32? quoteLineId) {
        //    SqlConnection cn = null;
        //    SqlCommand cmd = null;
        //    try {
        //        cn = new SqlConnection(this.ConnectionString);
        //        cmd = new SqlCommand("usp_select_QuoteLine", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = 30;
        //        cmd.Parameters.Add("@QuoteLineId", SqlDbType.Int).Value = quoteLineId;
        //        cn.Open();
        //        DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
        //        if (reader.Read()) {
        //            //return GetQuoteLineFromReader(reader);
        //            QuoteLineDetails obj = new QuoteLineDetails();
        //            obj.QuoteLineId = GetReaderValue_Int32(reader, "QuoteLineId", 0);
        //            obj.QuoteNo = GetReaderValue_Int32(reader, "QuoteNo", 0);
        //            obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
        //            obj.Part = GetReaderValue_String(reader, "Part", "");
        //            obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
        //            obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
        //            obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
        //            obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
        //            obj.Price = GetReaderValue_Double(reader, "Price", 0);
        //            obj.ETA = GetReaderValue_String(reader, "ETA", "");
        //            obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
        //            obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
        //            obj.ReasonNo = GetReaderValue_NullableInt32(reader, "ReasonNo", null);
        //            obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
        //            obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
        //            obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
        //            obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
        //            obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
        //            obj.OriginalOfferPrice = GetReaderValue_NullableDouble(reader, "OriginalOfferPrice", null);
        //            obj.OriginalOfferCurrencyNo = GetReaderValue_NullableInt32(reader, "OriginalOfferCurrencyNo", null);
        //            obj.OriginalOfferDate = GetReaderValue_NullableDateTime(reader, "OriginalOfferDate", null);
        //            obj.OriginalOfferSupplierNo = GetReaderValue_NullableInt32(reader, "OriginalOfferSupplierNo", null);
        //            obj.NotQuoted = GetReaderValue_Boolean(reader, "NotQuoted", false);
        //            obj.SourcingResultNo = GetReaderValue_NullableInt32(reader, "SourcingResultNo", null);
        //            obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
        //            obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
        //            obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
        //            obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
        //            obj.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue);
        //            obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
        //            obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
        //            obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
        //            obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
        //            obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
        //            obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
        //            obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
        //            obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
        //            obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
        //            obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
        //            obj.ReasonName = GetReaderValue_String(reader, "ReasonName", "");
        //            obj.OriginalOfferCurrencyCode = GetReaderValue_String(reader, "OriginalOfferCurrencyCode", "");
        //            obj.OriginalOfferSupplierName = GetReaderValue_String(reader, "OriginalOfferSupplierName", "");
        //            obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
        //            //[001] code start
        //            obj.ProductSource = GetReaderValue_NullableByte(reader, "ProductSource", null);
        //            //[001] code end
        //            return obj;
        //        } else {
        //            return null;
        //        }
        //    } catch (SqlException sqlex) {
        //        //LogException(sqlex);
        //        throw new Exception("Failed to get QuoteLine", sqlex);
        //    } finally {
        //        cmd.Dispose();
        //        cn.Close();
        //        cn.Dispose();
        //    }
        //}
		
		
        ///// <summary>
        ///// GetListClosedForQuote 
        ///// Calls [usp_selectAll_QuoteLine_Closed_for_Quote]
        ///// </summary>
        //public override List<QuoteLineDetails> GetListClosedForQuote(System.Int32? quoteId) {
        //    SqlConnection cn = null;
        //    SqlCommand cmd = null;
        //    try {
        //        cn = new SqlConnection(this.ConnectionString);
        //        cmd = new SqlCommand("usp_selectAll_QuoteLine_Closed_for_Quote", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = 30;
        //        cmd.Parameters.Add("@QuoteId", SqlDbType.Int).Value = quoteId;
        //        cn.Open();
        //        DbDataReader reader = ExecuteReader(cmd);
        //        List<QuoteLineDetails> lst = new List<QuoteLineDetails>();
        //        while (reader.Read()) {
        //            QuoteLineDetails obj = new QuoteLineDetails();
        //            obj.QuoteLineId = GetReaderValue_Int32(reader, "QuoteLineId", 0);
        //            obj.QuoteNo = GetReaderValue_Int32(reader, "QuoteNo", 0);
        //            obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
        //            obj.Part = GetReaderValue_String(reader, "Part", "");
        //            obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
        //            obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
        //            obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
        //            obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
        //            obj.Price = GetReaderValue_Double(reader, "Price", 0);
        //            obj.ETA = GetReaderValue_String(reader, "ETA", "");
        //            obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
        //            obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
        //            obj.ReasonNo = GetReaderValue_NullableInt32(reader, "ReasonNo", null);
        //            obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
        //            obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
        //            obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
        //            obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
        //            obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
        //            obj.OriginalOfferPrice = GetReaderValue_NullableDouble(reader, "OriginalOfferPrice", null);
        //            obj.OriginalOfferCurrencyNo = GetReaderValue_NullableInt32(reader, "OriginalOfferCurrencyNo", null);
        //            obj.OriginalOfferDate = GetReaderValue_NullableDateTime(reader, "OriginalOfferDate", null);
        //            obj.OriginalOfferSupplierNo = GetReaderValue_NullableInt32(reader, "OriginalOfferSupplierNo", null);
        //            obj.NotQuoted = GetReaderValue_Boolean(reader, "NotQuoted", false);
        //            obj.SourcingResultNo = GetReaderValue_NullableInt32(reader, "SourcingResultNo", null);
        //            obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
        //            obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
        //            obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
        //            obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
        //            obj.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue);
        //            obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
        //            obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
        //            obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
        //            obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
        //            obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
        //            obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
        //            obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
        //            obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
        //            obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
        //            obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
        //            obj.ReasonName = GetReaderValue_String(reader, "ReasonName", "");
        //            obj.OriginalOfferCurrencyCode = GetReaderValue_String(reader, "OriginalOfferCurrencyCode", "");
        //            obj.OriginalOfferSupplierName = GetReaderValue_String(reader, "OriginalOfferSupplierName", "");
        //            obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
        //            //[001] code start
        //            obj.ProductSource = GetReaderValue_NullableByte(reader, "ProductSource", null);
        //            //[001] code end
        //            lst.Add(obj);
        //            obj = null;
        //        }
        //        return lst;
        //    } catch (SqlException sqlex) {
        //        //LogException(sqlex);
        //        throw new Exception("Failed to get QuoteLines", sqlex);
        //    } finally {
        //        cmd.Dispose();
        //        cn.Close();
        //        cn.Dispose();
        //    }
        //}
		
		
        ///// <summary>
        ///// GetListForQuote 
        ///// Calls [usp_selectAll_QuoteLine_for_Quote]
        ///// </summary>
        //public override List<QuoteLineDetails> GetListForQuote(System.Int32? quoteId) {
        //    SqlConnection cn = null;
        //    SqlCommand cmd = null;
        //    try {
        //        cn = new SqlConnection(this.ConnectionString);
        //        cmd = new SqlCommand("usp_selectAll_QuoteLine_for_Quote", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = 30;
        //        cmd.Parameters.Add("@QuoteId", SqlDbType.Int).Value = quoteId;
        //        cn.Open();
        //        DbDataReader reader = ExecuteReader(cmd);
        //        List<QuoteLineDetails> lst = new List<QuoteLineDetails>();
        //        while (reader.Read()) {
        //            QuoteLineDetails obj = new QuoteLineDetails();
        //            obj.QuoteLineId = GetReaderValue_Int32(reader, "QuoteLineId", 0);
        //            obj.QuoteNo = GetReaderValue_Int32(reader, "QuoteNo", 0);
        //            obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
        //            obj.Part = GetReaderValue_String(reader, "Part", "");
        //            obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
        //            obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
        //            obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
        //            obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
        //            obj.Price = GetReaderValue_Double(reader, "Price", 0);
        //            obj.ETA = GetReaderValue_String(reader, "ETA", "");
        //            obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
        //            obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
        //            obj.ReasonNo = GetReaderValue_NullableInt32(reader, "ReasonNo", null);
        //            obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
        //            obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
        //            obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
        //            obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
        //            obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
        //            obj.OriginalOfferPrice = GetReaderValue_NullableDouble(reader, "OriginalOfferPrice", null);
        //            obj.OriginalOfferCurrencyNo = GetReaderValue_NullableInt32(reader, "OriginalOfferCurrencyNo", null);
        //            obj.OriginalOfferDate = GetReaderValue_NullableDateTime(reader, "OriginalOfferDate", null);
        //            obj.OriginalOfferSupplierNo = GetReaderValue_NullableInt32(reader, "OriginalOfferSupplierNo", null);
        //            obj.NotQuoted = GetReaderValue_Boolean(reader, "NotQuoted", false);
        //            obj.SourcingResultNo = GetReaderValue_NullableInt32(reader, "SourcingResultNo", null);
        //            obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
        //            obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
        //            obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
        //            obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
        //            obj.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue);
        //            obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
        //            obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
        //            obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
        //            obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
        //            obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
        //            obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
        //            obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
        //            obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
        //            obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
        //            obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
        //            obj.ReasonName = GetReaderValue_String(reader, "ReasonName", "");
        //            obj.OriginalOfferCurrencyCode = GetReaderValue_String(reader, "OriginalOfferCurrencyCode", "");
        //            obj.OriginalOfferSupplierName = GetReaderValue_String(reader, "OriginalOfferSupplierName", "");
        //            obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
        //            //[001] code start
        //            obj.ProductSource = GetReaderValue_NullableByte(reader, "ProductSource", null);
        //            //[001] code end
        //            lst.Add(obj);
        //            obj = null;
        //        }
        //        return lst;
        //    } catch (SqlException sqlex) {
        //        //LogException(sqlex);
        //        throw new Exception("Failed to get QuoteLines", sqlex);
        //    } finally {
        //        cmd.Dispose();
        //        cn.Close();
        //        cn.Dispose();
        //    }
        //}
		
		
        ///// <summary>
        ///// GetListOpenForQuote 
        ///// Calls [usp_selectAll_QuoteLine_Open_for_Quote]
        ///// </summary>
        //public override List<QuoteLineDetails> GetListOpenForQuote(System.Int32? quoteId) {
        //    SqlConnection cn = null;
        //    SqlCommand cmd = null;
        //    try {
        //        cn = new SqlConnection(this.ConnectionString);
        //        cmd = new SqlCommand("usp_selectAll_QuoteLine_Open_for_Quote", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = 30;
        //        cmd.Parameters.Add("@QuoteId", SqlDbType.Int).Value = quoteId;
        //        cn.Open();
        //        DbDataReader reader = ExecuteReader(cmd);
        //        List<QuoteLineDetails> lst = new List<QuoteLineDetails>();
        //        while (reader.Read()) {
        //            QuoteLineDetails obj = new QuoteLineDetails();
        //            obj.QuoteLineId = GetReaderValue_Int32(reader, "QuoteLineId", 0);
        //            obj.QuoteNo = GetReaderValue_Int32(reader, "QuoteNo", 0);
        //            obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
        //            obj.Part = GetReaderValue_String(reader, "Part", "");
        //            obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
        //            obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
        //            obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
        //            obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
        //            obj.Price = GetReaderValue_Double(reader, "Price", 0);
        //            obj.ETA = GetReaderValue_String(reader, "ETA", "");
        //            obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
        //            obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
        //            obj.ReasonNo = GetReaderValue_NullableInt32(reader, "ReasonNo", null);
        //            obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
        //            obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
        //            obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
        //            obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
        //            obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
        //            obj.OriginalOfferPrice = GetReaderValue_NullableDouble(reader, "OriginalOfferPrice", null);
        //            obj.OriginalOfferCurrencyNo = GetReaderValue_NullableInt32(reader, "OriginalOfferCurrencyNo", null);
        //            obj.OriginalOfferDate = GetReaderValue_NullableDateTime(reader, "OriginalOfferDate", null);
        //            obj.OriginalOfferSupplierNo = GetReaderValue_NullableInt32(reader, "OriginalOfferSupplierNo", null);
        //            obj.NotQuoted = GetReaderValue_Boolean(reader, "NotQuoted", false);
        //            obj.SourcingResultNo = GetReaderValue_NullableInt32(reader, "SourcingResultNo", null);
        //            obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
        //            obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
        //            obj.QuoteNumber = GetReaderValue_Int32(reader, "QuoteNumber", 0);
        //            obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
        //            obj.DateQuoted = GetReaderValue_DateTime(reader, "DateQuoted", DateTime.MinValue);
        //            obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
        //            obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
        //            obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
        //            obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
        //            obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
        //            obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
        //            obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
        //            obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
        //            obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
        //            obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
        //            obj.ReasonName = GetReaderValue_String(reader, "ReasonName", "");
        //            obj.OriginalOfferCurrencyCode = GetReaderValue_String(reader, "OriginalOfferCurrencyCode", "");
        //            obj.OriginalOfferSupplierName = GetReaderValue_String(reader, "OriginalOfferSupplierName", "");
        //            obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
        //            //[001] code start
        //            obj.ProductSource = GetReaderValue_NullableByte(reader, "ProductSource", null);
        //            //[001] code end
        //            lst.Add(obj);
        //            obj = null;
        //        }
        //        return lst;
        //    } catch (SqlException sqlex) {
        //        //LogException(sqlex);
        //        throw new Exception("Failed to get QuoteLines", sqlex);
        //    } finally {
        //        cmd.Dispose();
        //        cn.Close();
        //        cn.Dispose();
        //    }
        //}


        
		
        ///// <summary>
        ///// Update QuoteLine
        ///// Calls [usp_update_QuoteLine]
        ///// </summary>
        //public override bool Update(System.Int32? quoteLineId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.String eta, System.String instructions, System.Int32? productNo, System.String customerPart, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Byte? productSource) {
        //    SqlConnection cn = null;
        //    SqlCommand cmd = null;
        //    try {
        //        cn = new SqlConnection(this.ConnectionString);
        //        cmd = new SqlCommand("usp_update_QuoteLine", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@QuoteLineId", SqlDbType.Int).Value = quoteLineId;
        //        cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
        //        cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
        //        cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
        //        cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
        //        cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
        //        cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
        //        cmd.Parameters.Add("@ETA", SqlDbType.NVarChar).Value = eta;
        //        cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
        //        cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
        //        cmd.Parameters.Add("@CustomerPart", SqlDbType.NVarChar).Value = customerPart;
        //        cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
        //        cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
        //        cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
        //        //[001] code start
        //        cmd.Parameters.Add("@ProductSource", SqlDbType.TinyInt).Value = productSource;
        //        //[001] code end
        //        cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
        //        cn.Open();
        //        int ret = ExecuteNonQuery(cmd);
        //        return (ret > 0);
        //    } catch (SqlException sqlex) {
        //        //LogException(sqlex);
        //        throw new Exception("Failed to update QuoteLine", sqlex);
        //    } finally {
        //        cmd.Dispose();
        //        cn.Close();
        //        cn.Dispose();
        //    }
        //}
		
		
        ///// <summary>
        ///// Update QuoteLine
        ///// Calls [usp_update_QuoteLine_Close]
        ///// </summary>
        //public override bool UpdateClose(System.Int32? quoteLineId, System.Int32? reasonNo, System.Int32? updatedBy) {
        //    SqlConnection cn = null;
        //    SqlCommand cmd = null;
        //    try {
        //        cn = new SqlConnection(this.ConnectionString);
        //        cmd = new SqlCommand("usp_update_QuoteLine_Close", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@QuoteLineId", SqlDbType.Int).Value = quoteLineId;
        //        cmd.Parameters.Add("@ReasonNo", SqlDbType.Int).Value = reasonNo;
        //        cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
        //        cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
        //        cn.Open();
        //        int ret = ExecuteNonQuery(cmd);
        //        return (ret > 0);
        //    } catch (SqlException sqlex) {
        //        //LogException(sqlex);
        //        throw new Exception("Failed to update QuoteLine", sqlex);
        //    } finally {
        //        cmd.Dispose();
        //        cn.Close();
        //        cn.Dispose();
        //    }
        //}

        ///// <summary>
        ///// UpdateOffer
        ///// Calls [usp_update_QuoteLine_OriginalOffer]
        ///// </summary>
        //public override bool UpdateOffer(System.Int32? quoteLineId, System.Int32? sourcingResultNo, System.Int32? updatedBy)
        //{
        //    SqlConnection cn = null;
        //    SqlCommand cmd = null;
        //    try
        //    {
        //        cn = new SqlConnection(this.ConnectionString);
        //        cmd = new SqlCommand("usp_update_QuoteLine_OriginalOffer", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@QuoteLineId", SqlDbType.Int).Value = quoteLineId;
        //        cmd.Parameters.Add("@SourcingResultNo", SqlDbType.Int).Value = sourcingResultNo;
        //        cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
        //        cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
        //        cn.Open();
        //        ExecuteNonQuery(cmd);
        //        int ret = (Int32)cmd.Parameters["@RowsAffected"].Value;
        //        return (ret > 0);
        //    }
        //    catch (SqlException sqlex)
        //    {
        //        //LogException(sqlex);
        //        throw new Exception("Failed to update QuoteLine", sqlex);
        //    }
        //    finally
        //    {
        //        cmd.Dispose();
        //        cn.Close();
        //        cn.Dispose();
        //    }
        //}


        /// <summary>
        /// Csv Import Log 
        /// Calls [usp_CsvImportLog]
        /// </summary>
        public override List<POQuoteLineDetails> GetLog(System.Int32? ID)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_CsvImportLog", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@PQuoteNo", SqlDbType.Int).Value = ID;

                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<POQuoteLineDetails> lst = new List<POQuoteLineDetails>();
                while (reader.Read())
                {
                    POQuoteLineDetails obj = new POQuoteLineDetails();
                    obj.Message = GetReaderValue_String(reader, "Message", "");
                    obj.DatePOQuoted = GetReaderValue_DateTime(reader, "LogDate", DateTime.MinValue);
                    obj.PurchaseQuoteLineId = GetReaderValue_Int32(reader, "PurchaseQuoteCSVLogId", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get log details", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Csv Import Log 
        /// Calls [usp_CsvImportLogBom]
        /// </summary>
        public override List<POQuoteLineDetails> GetLogBom(System.Int32? ID)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_CsvBomImportLog", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@BomNo", SqlDbType.Int).Value = ID;

                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<POQuoteLineDetails> lst = new List<POQuoteLineDetails>();
                while (reader.Read())
                {
                    POQuoteLineDetails obj = new POQuoteLineDetails();
                    obj.Message = GetReaderValue_String(reader, "Message", "");
                    obj.DatePOQuoted = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.PurchaseQuoteLineId = GetReaderValue_Int32(reader, "BomNo", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get log details", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Csv Import Log 
        /// Calls [usp_CsvImportLogBom]
        /// </summary>
        public override List<POQuoteLineDetails> GetUploadLog(System.Int32? LoginId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_CsvUploadLog", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@loginId", SqlDbType.Int).Value = LoginId;

                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<POQuoteLineDetails> lst = new List<POQuoteLineDetails>();
                while (reader.Read())
                {
                    POQuoteLineDetails obj = new POQuoteLineDetails();
                    obj.Message = GetReaderValue_String(reader, "CompanyName", "");
                    obj.DatePOQuoted = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.PurchaseQuoteLineId = GetReaderValue_Int32(reader, "Csvid", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get upload log details", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Csv Import Log 
        /// Calls [usp_CsvImportLogBom]
        /// </summary>
        public override List<POQuoteLineDetails> GetLogHistory(System.Int32? ClientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_GetLogHistory", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = ClientId;

                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<POQuoteLineDetails> lst = new List<POQuoteLineDetails>();
                while (reader.Read())
                {
                    POQuoteLineDetails obj = new POQuoteLineDetails();
                    obj.Message = GetReaderValue_String(reader, "Message", "");
                    obj.FileName = GetReaderValue_String(reader, "FileName", "");
                    obj.LoginName = GetReaderValue_String(reader, "LoginName", "");
                    obj.Status = GetReaderValue_NullableBoolean(reader, "Status", false);
                    obj.PurchaseQuoteLineId = GetReaderValue_Int32(reader, "PurchaseQuoteCSVLogId", 0);
                   
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get log details", sqlex);
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
