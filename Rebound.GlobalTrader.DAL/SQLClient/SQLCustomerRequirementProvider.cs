/*

Marker     changed by      date         Remarks

[001]      Abhinav       31/05/2012   ESMS Ref:92 - Requirement Error - Urgent
[002]      Shashi Keshar 23/09/2016  MailTemplate Data for Send to Purchase Hub from HUBRFQ and Requirement Main Info Page 
[003]      Aashu Singh   10/07/2018  [REB-12515]: show the HUBRFQ link below the customer requirement number in the customer requirement nugget of the sourcing results
[004]      Umendra Gupta 11/09/2018  add start date and end date for searching 

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
	public class SqlCustomerRequirementProvider : CustomerRequirementProvider {
		/// <summary>
		/// Count CustomerRequirement
		/// Calls [usp_count_CustomerRequirement_for_Client]
		/// </summary>
		public override Int32 CountForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_CustomerRequirement_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count CustomerRequirement", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Count CustomerRequirement
		/// Calls [usp_count_CustomerRequirement_for_Company]
		/// </summary>
		public override Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeClosed) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_CustomerRequirement_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count CustomerRequirement", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Count CustomerRequirement
		/// Calls [usp_count_CustomerRequirement_open_for_Company]
		/// </summary>
		public override Int32 CountOpenForCompany(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_CustomerRequirement_open_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count CustomerRequirement", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DataListNugget 
		/// Calls [usp_datalistnugget_CustomerRequirement]
        /// </summary>
        public override List<CustomerRequirementDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanNo, System.Boolean? recentOnly, System.Boolean? includeClosed, System.Int32? customerRequirementNoLo, System.Int32? customerRequirementNoHi, System.DateTime? receivedDateFrom, System.DateTime? receivedDateTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo, System.Boolean? partWatch, System.String bomNameSearch, System.String bomCodeSearch, System.Int32? totalLo, System.Int32? totalHi)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_CustomerRequirement", cn);
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
				cmd.Parameters.Add("@SalesmanNo", SqlDbType.Int).Value = salesmanNo;
				cmd.Parameters.Add("@RecentOnly", SqlDbType.Bit).Value = recentOnly;
				cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
				cmd.Parameters.Add("@CustomerRequirementNoLo", SqlDbType.Int).Value = customerRequirementNoLo;
				cmd.Parameters.Add("@CustomerRequirementNoHi", SqlDbType.Int).Value = customerRequirementNoHi;
				cmd.Parameters.Add("@ReceivedDateFrom", SqlDbType.DateTime).Value = receivedDateFrom;
				cmd.Parameters.Add("@ReceivedDateTo", SqlDbType.DateTime).Value = receivedDateTo;
				cmd.Parameters.Add("@DatePromisedFrom", SqlDbType.DateTime).Value = datePromisedFrom;
				cmd.Parameters.Add("@DatePromisedTo", SqlDbType.DateTime).Value = datePromisedTo;
				cmd.Parameters.Add("@PartWatch", SqlDbType.Bit).Value = partWatch;
				cmd.Parameters.Add("@BOMNameSearch", SqlDbType.NVarChar).Value = bomNameSearch;
                cmd.Parameters.Add("@BOMCode", SqlDbType.NVarChar).Value = bomCodeSearch;
                cmd.Parameters.Add("@TotalLo", SqlDbType.Int).Value = totalLo;
                cmd.Parameters.Add("@TotalHi", SqlDbType.Int).Value = totalHi;
               
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CustomerRequirementDetails> lst = new List<CustomerRequirementDetails>();
				while (reader.Read()) {
					CustomerRequirementDetails obj = new CustomerRequirementDetails();
					obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
					obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.BOMCode = GetReaderValue_String(reader, "BOMCode", "");
                    obj.BOMNo = GetReaderValue_NullableInt32(reader, "BOMId", 0);
                    obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
                    obj.TotalInBase = GetReaderValue_NullableDouble(reader, "TotalInBase", 0);
                    obj.TotalValue = GetReaderValue_NullableDouble(reader, "TotalValue", 0);
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CustomerRequirements", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete CustomerRequirement
		/// Calls [usp_delete_CustomerRequirement]
		/// </summary>
		public override bool Delete(System.Int32? customerRequirementId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_CustomerRequirement", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CustomerRequirementId", SqlDbType.Int).Value = customerRequirementId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete CustomerRequirement", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_CustomerRequirement]
		/// </summary>
        public override Int32 Insert(System.Int32? clientNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? receivedDate, System.Int32? salesman, System.DateTime? datePromised, System.String notes, System.String instructions, System.Boolean? shortage, System.Int32? companyNo, System.Int32? contactNo, System.Int32? usageNo, System.Boolean? alternate, System.Int32? originalCustomerRequirementNo, System.Int32? reasonNo, System.Int32? productNo, System.String customerPart, System.Boolean? closed, System.Byte? rohs, System.Int32? updatedBy, System.Boolean? partWatch, System.Boolean? bom, System.String bomName, System.Int32? BOMNo, System.Boolean? FactorySealed, System.String MSL, System.Boolean? PQA, System.Boolean? ObsoleteChk, System.Boolean? LastTimeBuyChk, System.Boolean? RefirbsAcceptableChk, System.Boolean? TestingRequiredChk, System.Double? TargetSellPrice, System.Double? CompetitorBestOffer, System.DateTime? CustomerDecisionDate, System.DateTime? RFQClosingDate, System.Int32? QuoteValidityRequired, System.Int32? Type, System.Boolean? OrderToPlace, System.Int32? RequirementforTraceability, System.String EAU, System.Boolean? AlternativesAccepted, System.Boolean? RepeatBusiness)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_CustomerRequirement", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@ReceivedDate", SqlDbType.DateTime).Value = receivedDate;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@DatePromised", SqlDbType.DateTime).Value = datePromised;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
				cmd.Parameters.Add("@Shortage", SqlDbType.Bit).Value = shortage;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@UsageNo", SqlDbType.Int).Value = usageNo;
				cmd.Parameters.Add("@Alternate", SqlDbType.Bit).Value = alternate;
				cmd.Parameters.Add("@OriginalCustomerRequirementNo", SqlDbType.Int).Value = originalCustomerRequirementNo;
				cmd.Parameters.Add("@ReasonNo", SqlDbType.Int).Value = reasonNo;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@CustomerPart", SqlDbType.NVarChar).Value = customerPart;
				cmd.Parameters.Add("@Closed", SqlDbType.Bit).Value = closed;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@PartWatch", SqlDbType.Bit).Value = partWatch;
				cmd.Parameters.Add("@BOM", SqlDbType.Bit).Value = bom;
				cmd.Parameters.Add("@BOMName", SqlDbType.NVarChar).Value = bomName;
                cmd.Parameters.Add("@BOMNo", SqlDbType.Int).Value = BOMNo;
                cmd.Parameters.Add("@FactorySealed", SqlDbType.Bit).Value = FactorySealed;
                cmd.Parameters.Add("@MSL", SqlDbType.NVarChar).Value = MSL;

                cmd.Parameters.Add("@PartialQuantityAcceptable", SqlDbType.Bit).Value = PQA;
                cmd.Parameters.Add("@Obsolete", SqlDbType.Bit).Value = ObsoleteChk;
                cmd.Parameters.Add("@LastTimeBuy", SqlDbType.Bit).Value = LastTimeBuyChk;
                cmd.Parameters.Add("@RefirbsAcceptable", SqlDbType.Bit).Value = RefirbsAcceptableChk;
                cmd.Parameters.Add("@TestingRequired", SqlDbType.Bit).Value = TestingRequiredChk;
                cmd.Parameters.Add("@TargetSellPrice", SqlDbType.Float).Value = TargetSellPrice;
                cmd.Parameters.Add("@CompetitorBestOffer", SqlDbType.Float).Value = CompetitorBestOffer;
                cmd.Parameters.Add("@CustomerDecisionDate", SqlDbType.DateTime).Value = CustomerDecisionDate;
                cmd.Parameters.Add("@RFQClosingDate", SqlDbType.DateTime).Value = RFQClosingDate;
                cmd.Parameters.Add("@QuoteValidityRequired", SqlDbType.Int).Value = QuoteValidityRequired;
                cmd.Parameters.Add("@Type", SqlDbType.Int).Value = Type;
                cmd.Parameters.Add("@OrderToPlace", SqlDbType.Int).Value = OrderToPlace;
                cmd.Parameters.Add("@RequirementForTraceability", SqlDbType.Int).Value = RequirementforTraceability;
                cmd.Parameters.Add("@EAU", SqlDbType.NVarChar).Value = EAU;

                cmd.Parameters.Add("@AlternativesAccepted", SqlDbType.Bit).Value = AlternativesAccepted;
                cmd.Parameters.Add("@RepeatBusiness", SqlDbType.Bit).Value = RepeatBusiness;
               
				cmd.Parameters.Add("@CustomerRequirementId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@CustomerRequirementId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert CustomerRequirement", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_CustomerRequirement_as_Alternate]
		/// </summary>
		public override Int32 InsertAsAlternate(System.String customerRequirementName, System.Int32? customerRequirementNumber, System.Int32? clientNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? receivedDate, System.Int32? salesman, System.DateTime? datePromised, System.String notes, System.String instructions, System.Boolean? shortage, System.Int32? companyNo, System.Int32? contactNo, System.Int32? usageNo, System.Int32? originalCustomerRequirementNo, System.Int32? reasonNo, System.Int32? productNo, System.String customerPart, System.Boolean? closed, System.Byte? rohs, System.Int32? updatedBy, System.Boolean? partWatch, System.Boolean? bom, System.String bomName,
            System.Int32? salesmanno, System.Boolean? PQA, System.Boolean? ObsoleteChk, System.Boolean? LastTimeBuyChk, System.Boolean? RefirbsAcceptableChk, System.Boolean? TestingRequiredChk, System.Boolean? AlternativesAccepted, System.Boolean? RepeatBusiness, System.Double? CompetitorBestOffer, System.DateTime? CustomerDecisionDate, System.DateTime? RFQClosingDate, System.Int32? QuoteValidityRequired, System.Int32? Type, System.Boolean? OrderToPlace, System.Boolean? FactorySealed, System.String MSL, System.Int32? BOMNo, System.Int32? RequirementforTraceability, System.String EAU)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_CustomerRequirement_as_Alternate", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CustomerRequirementName", SqlDbType.NVarChar).Value = customerRequirementName;
				cmd.Parameters.Add("@CustomerRequirementNumber", SqlDbType.Int).Value = customerRequirementNumber;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@ReceivedDate", SqlDbType.DateTime).Value = receivedDate;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@DatePromised", SqlDbType.DateTime).Value = datePromised;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
				cmd.Parameters.Add("@Shortage", SqlDbType.Bit).Value = shortage;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@UsageNo", SqlDbType.Int).Value = usageNo;
				cmd.Parameters.Add("@OriginalCustomerRequirementNo", SqlDbType.Int).Value = originalCustomerRequirementNo;
				cmd.Parameters.Add("@ReasonNo", SqlDbType.Int).Value = reasonNo;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@CustomerPart", SqlDbType.NVarChar).Value = customerPart;
				cmd.Parameters.Add("@Closed", SqlDbType.Bit).Value = closed;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@PartWatch", SqlDbType.Bit).Value = partWatch;
				cmd.Parameters.Add("@BOM", SqlDbType.Bit).Value = bom;
				cmd.Parameters.Add("@BOMName", SqlDbType.NVarChar).Value = bomName;

                //[002] code start
                cmd.Parameters.Add("@SalesmanNo", SqlDbType.Int).Value = salesmanno;
                cmd.Parameters.Add("@PartialQuantityAcceptable", SqlDbType.Bit).Value = PQA;
                cmd.Parameters.Add("@Obsolete", SqlDbType.Bit).Value = ObsoleteChk;
                cmd.Parameters.Add("@LastTimeBuy", SqlDbType.Bit).Value = LastTimeBuyChk;
                cmd.Parameters.Add("@RefirbsAcceptable", SqlDbType.Bit).Value = RefirbsAcceptableChk;
                cmd.Parameters.Add("@TestingRequired", SqlDbType.Bit).Value = TestingRequiredChk;
                cmd.Parameters.Add("@AlternativesAccepted", SqlDbType.Bit).Value = AlternativesAccepted;
                cmd.Parameters.Add("@RepeatBusiness", SqlDbType.Bit).Value = RepeatBusiness;
                cmd.Parameters.Add("@CompetitorBestOffer", SqlDbType.Float).Value = CompetitorBestOffer;
                cmd.Parameters.Add("@CustomerDecisionDate", SqlDbType.DateTime).Value = CustomerDecisionDate;
                cmd.Parameters.Add("@RFQClosingDate", SqlDbType.DateTime).Value = RFQClosingDate;
                cmd.Parameters.Add("@QuoteValidityRequired", SqlDbType.Int).Value = QuoteValidityRequired;
                cmd.Parameters.Add("@Type", SqlDbType.Int).Value = Type;
                cmd.Parameters.Add("@OrderToPlace", SqlDbType.Bit).Value = OrderToPlace;
                cmd.Parameters.Add("@FactorySealed", SqlDbType.Bit).Value = FactorySealed;
                cmd.Parameters.Add("@MSL", SqlDbType.NVarChar).Value = MSL;
                cmd.Parameters.Add("@BOMNum", SqlDbType.Int).Value = BOMNo;
                cmd.Parameters.Add("@RequirementforTraceability", SqlDbType.Int).Value = RequirementforTraceability;
                cmd.Parameters.Add("@EAU", SqlDbType.NVarChar).Value = EAU;

                //[002] code end
				cmd.Parameters.Add("@CustomerRequirementId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@CustomerRequirementId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert CustomerRequirement", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// Create a new row
        /// Calls [usp_insert_CustomerRequirement_as_Alternate]
        /// </summary>
        public override Int32 InsertAsAllAlternate(System.Int32? clientNo, System.String part, System.Int32? CustRequirementId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_CustomerRequirement_as_AllAlternate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustRequirementId", SqlDbType.Int).Value = CustRequirementId;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
                cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                 ExecuteNonQuery(cmd);
                 int ret = (Int32)cmd.Parameters["@Result"].Value;
                return ret;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert All CustomerRequirement", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		
        /// <summary>
        /// ItemSearch 
		/// Calls [usp_itemsearch_CustomerRequirement]
        /// </summary>
		public override List<CustomerRequirementDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Boolean? includeClosed, System.Int32? customerRequirementNoLo, System.Int32? customerRequirementNoHi, System.DateTime? receivedDateFrom, System.DateTime? receivedDateTo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_itemsearch_CustomerRequirement", cn);
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
				cmd.Parameters.Add("@CustomerRequirementNoLo", SqlDbType.Int).Value = customerRequirementNoLo;
				cmd.Parameters.Add("@CustomerRequirementNoHi", SqlDbType.Int).Value = customerRequirementNoHi;
				cmd.Parameters.Add("@ReceivedDateFrom", SqlDbType.DateTime).Value = receivedDateFrom;
				cmd.Parameters.Add("@ReceivedDateTo", SqlDbType.DateTime).Value = receivedDateTo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CustomerRequirementDetails> lst = new List<CustomerRequirementDetails>();
				while (reader.Read()) {
					CustomerRequirementDetails obj = new CustomerRequirementDetails();
					obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
					obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CustomerRequirements", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_CustomerRequirement]
        /// </summary>
		public override CustomerRequirementDetails Get(System.Int32? customerRequirementId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_CustomerRequirement", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CustomerRequirementId", SqlDbType.Int).Value = customerRequirementId;           
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCustomerRequirementFromReader(reader);
					CustomerRequirementDetails obj = new CustomerRequirementDetails();
					obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
					obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.Shortage = GetReaderValue_Boolean(reader, "Shortage", false);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.Alternate = GetReaderValue_Boolean(reader, "Alternate", false);
					obj.OriginalCustomerRequirementNo = GetReaderValue_NullableInt32(reader, "OriginalCustomerRequirementNo", null);
					obj.ReasonNo = GetReaderValue_NullableInt32(reader, "ReasonNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.UsageNo = GetReaderValue_NullableInt32(reader, "UsageNo", null);
					obj.BOM = GetReaderValue_NullableBoolean(reader, "BOM", null);
					obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
					obj.PartWatch = GetReaderValue_NullableBoolean(reader, "PartWatch", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DisplayStatus = GetReaderValue_String(reader, "DisplayStatus", "");
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.UsageName = GetReaderValue_String(reader, "UsageName", "");
					obj.CustomerRequirementValue = GetReaderValue_Double(reader, "CustomerRequirementValue", 0);
					obj.ClosedReason = GetReaderValue_String(reader, "ClosedReason", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.Traceability = GetReaderValue_NullableBoolean(reader, "IsTraceability", false);
                    obj.BOMHeader = GetReaderValue_String(reader, "BOMHeader", "");
                    obj.BOMStatus = GetReaderValue_String(reader, "BOMStatus", "");
                    obj.BOMNo = GetReaderValue_NullableInt32(reader, "BOMNo", null);
                    obj.RequestToPOHubBy = GetReaderValue_NullableInt32(reader, "RequestToPOHubBy", null);
                    obj.FactorySealed = GetReaderValue_NullableBoolean(reader, "FactorySealed", false);
                    obj.MSL = GetReaderValue_String(reader, "MSL", "");
                    obj.SourcingResultNo = GetReaderValue_NullableInt32(reader, "SourcingResultNo", 0);

                    obj.PQA = GetReaderValue_NullableBoolean(reader, "PartialQuantityAcceptable", null);
                    obj.Obsolete = GetReaderValue_NullableBoolean(reader, "Obsolete", null);
                    obj.LastTimeBuy = GetReaderValue_NullableBoolean(reader, "LastTimeBuy", null);
                    obj.RefirbsAcceptable = GetReaderValue_NullableBoolean(reader, "RefirbsAcceptable", null);
                    obj.TestingRequired = GetReaderValue_NullableBoolean(reader, "TestingRequired", null);
                    obj.TargetSellPrice = GetReaderValue_Double(reader, "TargetSellPrice", 0);
                    obj.CompetitorBestOffer = GetReaderValue_Double(reader, "CompetitorBestOffer", 0);
                    obj.CustomerDecisionDate = GetReaderValue_DateTime(reader, "CustomerDecisionDate", DateTime.MinValue);
                    obj.RFQClosingDate = GetReaderValue_DateTime(reader, "RFQClosingDate", DateTime.MinValue);
                    obj.QuoteValidityRequired = GetReaderValue_NullableInt32(reader, "QuoteValidityRequired", null);
                    obj.Type = GetReaderValue_NullableInt32(reader, "ReqType", null);
                    obj.OrderToPlace = GetReaderValue_NullableBoolean(reader, "OrderToPlace", null);
                    obj.RequirementforTraceability = GetReaderValue_NullableInt32(reader, "ReqForTraceability", null);
                    obj.QuoteValidityText = GetReaderValue_String(reader, "QuoteValidityText", "");
                    obj.ReqTypeText = GetReaderValue_String(reader, "ReqTypeText", "");
                    obj.ReqForTraceabilityText = GetReaderValue_String(reader, "ReqForTraceabilityText", "");
                    obj.EAU = GetReaderValue_String(reader, "EAU", "");
                    obj.ReqNotes = GetReaderValue_String(reader, "ReqNotes", "");
                    obj.POHubReleaseBy = GetReaderValue_NullableInt32(reader, "POHubReleaseBy", null);
                    obj.ClientGlobalCurrencyNo = GetReaderValue_NullableInt32(reader, "CustGlobalCurrencyNo", 0);
                    obj.IsCurrencyInSameFaimly = GetReaderValue_NullableBoolean(reader, "IsCurrencyInSameFaimly", false);
                    obj.AlternativesAccepted = GetReaderValue_NullableBoolean(reader, "AlternativesAccepted", false);
                    obj.RepeatBusiness = GetReaderValue_NullableBoolean(reader, "RepeatBusiness", false);
                    obj.ProductInactive = GetReaderValue_NullableBoolean(reader, "ProductInactive", false);
                    obj.DutyCode = GetReaderValue_String(reader, "DutyCode", "");
                    obj.DutyRate = GetReaderValue_NullableDouble(reader, "ProductDutyRate", null);                  
                    obj.MSLLevelNo = GetReaderValue_NullableInt32(reader, "MSLLevelNo", 0);
                    obj.IsProdHaz = GetReaderValue_NullableBoolean(reader, "IsHazardous", false);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CustomerRequirement", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}


        /// <summary>
        /// Get 
        /// Calls [usp_select_CustomerRequirementBOM]
        /// </summary>
        public override CustomerRequirementDetails GetReqBOM(System.Int32? customerRequirementId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_CustomerRequirementBOM", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRequirementId", SqlDbType.Int).Value = customerRequirementId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetCustomerRequirementFromReader(reader);
                    CustomerRequirementDetails obj = new CustomerRequirementDetails();
                    obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
                    obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                    obj.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.Shortage = GetReaderValue_Boolean(reader, "Shortage", false);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.Alternate = GetReaderValue_Boolean(reader, "Alternate", false);
                    obj.OriginalCustomerRequirementNo = GetReaderValue_NullableInt32(reader, "OriginalCustomerRequirementNo", null);
                    obj.ReasonNo = GetReaderValue_NullableInt32(reader, "ReasonNo", null);
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.UsageNo = GetReaderValue_NullableInt32(reader, "UsageNo", null);
                    obj.BOM = GetReaderValue_NullableBoolean(reader, "BOM", null);
                    obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
                    obj.PartWatch = GetReaderValue_NullableBoolean(reader, "PartWatch", null);
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.DisplayStatus = GetReaderValue_String(reader, "DisplayStatus", "");
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.UsageName = GetReaderValue_String(reader, "UsageName", "");
                    obj.CustomerRequirementValue = GetReaderValue_Double(reader, "CustomerRequirementValue", 0);
                    obj.ClosedReason = GetReaderValue_String(reader, "ClosedReason", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.Traceability = GetReaderValue_NullableBoolean(reader, "IsTraceability", false);
                    obj.BOMHeader = GetReaderValue_String(reader, "BOMHeader", "");
                    obj.BOMStatus = GetReaderValue_String(reader, "BOMStatus", "");
                    obj.BOMNo = GetReaderValue_NullableInt32(reader, "BOMNo", null);
                    obj.RequestToPOHubBy = GetReaderValue_NullableInt32(reader, "RequestToPOHubBy", null);
                    obj.FactorySealed = GetReaderValue_NullableBoolean(reader, "FactorySealed", false);
                    obj.MSL = GetReaderValue_String(reader, "MSL", "");
                    obj.SourcingResultNo = GetReaderValue_NullableInt32(reader, "SourcingResultNo", 0);

                    obj.PQA = GetReaderValue_NullableBoolean(reader, "PartialQuantityAcceptable", null);
                    obj.Obsolete = GetReaderValue_NullableBoolean(reader, "Obsolete", null);
                    obj.LastTimeBuy = GetReaderValue_NullableBoolean(reader, "LastTimeBuy", null);
                    obj.RefirbsAcceptable = GetReaderValue_NullableBoolean(reader, "RefirbsAcceptable", null);
                    obj.TestingRequired = GetReaderValue_NullableBoolean(reader, "TestingRequired", null);
                    obj.TargetSellPrice = GetReaderValue_Double(reader, "TargetSellPrice", 0);
                    obj.CompetitorBestOffer = GetReaderValue_Double(reader, "CompetitorBestOffer", 0);
                    obj.CustomerDecisionDate = GetReaderValue_DateTime(reader, "CustomerDecisionDate", DateTime.MinValue);
                    obj.RFQClosingDate = GetReaderValue_DateTime(reader, "RFQClosingDate", DateTime.MinValue);
                    obj.QuoteValidityRequired = GetReaderValue_NullableInt32(reader, "QuoteValidityRequired", null);
                    obj.Type = GetReaderValue_NullableInt32(reader, "ReqType", null);
                    obj.OrderToPlace = GetReaderValue_NullableBoolean(reader, "OrderToPlace", null);
                    obj.RequirementforTraceability = GetReaderValue_NullableInt32(reader, "ReqForTraceability", null);
                    obj.QuoteValidityText = GetReaderValue_String(reader, "QuoteValidityText", "");
                    obj.ReqTypeText = GetReaderValue_String(reader, "ReqTypeText", "");
                    obj.ReqForTraceabilityText = GetReaderValue_String(reader, "ReqForTraceabilityText", "");
                    obj.SourcingResult = GetReaderValue_Int32(reader, "SourcingResult", 0);
                    obj.EAU = GetReaderValue_String(reader, "EAU", "");

                    obj.ClientCurrencyNo = GetReaderValue_NullableInt32(reader, "ClientCurrencyNo", 0);
                    obj.ClientCurrencyCode = GetReaderValue_String(reader, "ClientCurrencyCode", "");
                    obj.ReqGlobalCurrencyNo = GetReaderValue_NullableInt32(reader, "ReqGlobalCurrencyNo", 0);
                    obj.ClientGlobalCurrencyNo = GetReaderValue_NullableInt32(reader, "ClientGlobalCurrencyNo", 0);
                    obj.IsNoBid = GetReaderValue_NullableBoolean(reader, "IsNoBid", null);
                    obj.NoBidNotes = GetReaderValue_String(reader, "NoBidNotes", "");
                    obj.AlternativesAccepted = GetReaderValue_NullableBoolean(reader, "AlternativesAccepted", null);
                    obj.RepeatBusiness = GetReaderValue_NullableBoolean(reader, "RepeatBusiness", null);

                    obj.DutyCode = GetReaderValue_String(reader, "DutyCode", "");
                    obj.DutyRate = GetReaderValue_NullableDouble(reader, "ProductDutyRate", null);
                    obj.MSLLevelNo = GetReaderValue_NullableInt32(reader, "MSLLevelNo", 0);
                    
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
                throw new Exception("Failed to get CustomerRequirement", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		

        /// <summary>
        /// GetByNumber 
		/// Calls [usp_select_CustomerRequirement_by_Number]
        /// </summary>
		public override CustomerRequirementDetails GetByNumber(System.Int32? customerRequirementNumber, System.Int32? clientNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_CustomerRequirement_by_Number", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CustomerRequirementNumber", SqlDbType.Int).Value = customerRequirementNumber;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCustomerRequirementFromReader(reader);
					CustomerRequirementDetails obj = new CustomerRequirementDetails();
					obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
					obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.Shortage = GetReaderValue_Boolean(reader, "Shortage", false);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.Alternate = GetReaderValue_Boolean(reader, "Alternate", false);
					obj.OriginalCustomerRequirementNo = GetReaderValue_NullableInt32(reader, "OriginalCustomerRequirementNo", null);
					obj.ReasonNo = GetReaderValue_NullableInt32(reader, "ReasonNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.UsageNo = GetReaderValue_NullableInt32(reader, "UsageNo", null);
					obj.BOM = GetReaderValue_NullableBoolean(reader, "BOM", null);
					obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
					obj.PartWatch = GetReaderValue_NullableBoolean(reader, "PartWatch", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DisplayStatus = GetReaderValue_String(reader, "DisplayStatus", "");
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.UsageName = GetReaderValue_String(reader, "UsageName", "");
					obj.CustomerRequirementValue = GetReaderValue_Double(reader, "CustomerRequirementValue", 0);
					obj.ClosedReason = GetReaderValue_String(reader, "ClosedReason", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CustomerRequirement", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForPage 
		/// Calls [usp_select_CustomerRequirement_for_Page]
        /// </summary>
		public override CustomerRequirementDetails GetForPage(System.Int32? customerRequirementId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_CustomerRequirement_for_Page", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CustomerRequirementId", SqlDbType.Int).Value = customerRequirementId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCustomerRequirementFromReader(reader);
					CustomerRequirementDetails obj = new CustomerRequirementDetails();
					obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
					obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.DisplayStatus = GetReaderValue_String(reader, "DisplayStatus", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", 0);
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CustomerRequirement", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetIdByNumber 
		/// Calls [usp_select_CustomerRequirement_Id_by_Number]
        /// </summary>
		public override CustomerRequirementDetails GetIdByNumber(System.Int32? customerRequirementNumber, System.Int32? clientNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_CustomerRequirement_Id_by_Number", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CustomerRequirementNumber", SqlDbType.Int).Value = customerRequirementNumber;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCustomerRequirementFromReader(reader);
					CustomerRequirementDetails obj = new CustomerRequirementDetails();
					obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CustomerRequirement", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetNextNumber 
		/// Calls [usp_select_CustomerRequirement_NextNumber]
        /// </summary>
		public override CustomerRequirementDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_CustomerRequirement_NextNumber", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@NewNumber", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCustomerRequirementFromReader(reader);
					CustomerRequirementDetails obj = new CustomerRequirementDetails();
					obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CustomerRequirement", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetNumberById 
		/// Calls [usp_select_CustomerRequirement_Number_by_Id]
        /// </summary>
		public override CustomerRequirementDetails GetNumberById(System.Int32? customerRequirementId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_CustomerRequirement_Number_by_Id", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CustomerRequirementId", SqlDbType.Int).Value = customerRequirementId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetCustomerRequirementFromReader(reader);
					CustomerRequirementDetails obj = new CustomerRequirementDetails();
					obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CustomerRequirement", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForCompany 
		/// Calls [usp_selectAll_CustomerRequirement_for_Company]
        /// </summary>
		public override List<CustomerRequirementDetails> GetListForCompany(System.Int32? companyId, System.Boolean? includeClosed) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_CustomerRequirement_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CustomerRequirementDetails> lst = new List<CustomerRequirementDetails>();
				while (reader.Read()) {
					CustomerRequirementDetails obj = new CustomerRequirementDetails();
					obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
					obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.Shortage = GetReaderValue_Boolean(reader, "Shortage", false);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.Alternate = GetReaderValue_Boolean(reader, "Alternate", false);
					obj.OriginalCustomerRequirementNo = GetReaderValue_NullableInt32(reader, "OriginalCustomerRequirementNo", null);
					obj.ReasonNo = GetReaderValue_NullableInt32(reader, "ReasonNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.UsageNo = GetReaderValue_NullableInt32(reader, "UsageNo", null);
					obj.BOM = GetReaderValue_NullableBoolean(reader, "BOM", null);
					obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
					obj.PartWatch = GetReaderValue_NullableBoolean(reader, "PartWatch", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DisplayStatus = GetReaderValue_String(reader, "DisplayStatus", "");
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.UsageName = GetReaderValue_String(reader, "UsageName", "");
					obj.CustomerRequirementValue = GetReaderValue_Double(reader, "CustomerRequirementValue", 0);
					obj.ClosedReason = GetReaderValue_String(reader, "ClosedReason", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CustomerRequirements", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForCustomerRequirementNumber 
		/// Calls [usp_selectAll_CustomerRequirement_for_CustomerRequirementNumber]
        /// </summary>
		public override List<CustomerRequirementDetails> GetListForCustomerRequirementNumber(System.Int32? customerRequirementNumber,System.Int32? ClientID) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_CustomerRequirement_for_CustomerRequirementNumber", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CustomerRequirementNumber", SqlDbType.Int).Value = customerRequirementNumber;
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = ClientID;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CustomerRequirementDetails> lst = new List<CustomerRequirementDetails>();
				while (reader.Read()) {
					CustomerRequirementDetails obj = new CustomerRequirementDetails();
					obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
					obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.Shortage = GetReaderValue_Boolean(reader, "Shortage", false);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.Alternate = GetReaderValue_Boolean(reader, "Alternate", false);
					obj.OriginalCustomerRequirementNo = GetReaderValue_NullableInt32(reader, "OriginalCustomerRequirementNo", null);
					obj.ReasonNo = GetReaderValue_NullableInt32(reader, "ReasonNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.UsageNo = GetReaderValue_NullableInt32(reader, "UsageNo", null);
					obj.BOM = GetReaderValue_NullableBoolean(reader, "BOM", null);
					obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
					obj.PartWatch = GetReaderValue_NullableBoolean(reader, "PartWatch", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DisplayStatus = GetReaderValue_String(reader, "DisplayStatus", "");
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.UsageName = GetReaderValue_String(reader, "UsageName", "");
					obj.CustomerRequirementValue = GetReaderValue_Double(reader, "CustomerRequirementValue", 0);
					obj.ClosedReason = GetReaderValue_String(reader, "ClosedReason", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CustomerRequirements", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        // [001] code start
        /// <summary>
        /// GetListForCustomerRequirement 
        /// Calls [usp_selectAll_CustomerRequirement_for_CustomerRequirement]
        /// </summary>
        public override List<CustomerRequirementDetails> GetListForCustomerRequirement(System.Int32? customerRequirementNo,System.Int32?  clientID)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_CustomerRequirement_for_CustomerRequirement", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRequirementNo", SqlDbType.Int).Value = customerRequirementNo;
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = clientID;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CustomerRequirementDetails> lst = new List<CustomerRequirementDetails>();
                while (reader.Read())
                {
                    CustomerRequirementDetails obj = new CustomerRequirementDetails();
                    obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
                    obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                    obj.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.Shortage = GetReaderValue_Boolean(reader, "Shortage", false);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.Alternate = GetReaderValue_Boolean(reader, "Alternate", false);
                    obj.OriginalCustomerRequirementNo = GetReaderValue_NullableInt32(reader, "OriginalCustomerRequirementNo", null);
                    obj.ReasonNo = GetReaderValue_NullableInt32(reader, "ReasonNo", null);
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.UsageNo = GetReaderValue_NullableInt32(reader, "UsageNo", null);
                    obj.BOM = GetReaderValue_NullableBoolean(reader, "BOM", null);
                    obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
                    obj.PartWatch = GetReaderValue_NullableBoolean(reader, "PartWatch", null);
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.DisplayStatus = GetReaderValue_String(reader, "DisplayStatus", "");
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.UsageName = GetReaderValue_String(reader, "UsageName", "");
                    obj.CustomerRequirementValue = GetReaderValue_Double(reader, "CustomerRequirementValue", 0);
                    obj.ClosedReason = GetReaderValue_String(reader, "ClosedReason", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.BOMHeader = GetReaderValue_String(reader, "BOMHeader", "");
                    obj.BOMNo = GetReaderValue_NullableInt32(reader, "BOMNo", null);
                    obj.RequestToPOHubBy = GetReaderValue_NullableInt32(reader, "RequestToPOHubBy", null);
                    obj.FactorySealed = GetReaderValue_NullableBoolean(reader, "FactorySealed", null);
                    obj.MSL = GetReaderValue_String(reader, "MSL", "");

                    obj.PQA = GetReaderValue_NullableBoolean(reader, "PartialQuantityAcceptable", null);
                    obj.Obsolete = GetReaderValue_NullableBoolean(reader, "Obsolete", null);
                    obj.LastTimeBuy = GetReaderValue_NullableBoolean(reader, "LastTimeBuy", null);
                    obj.RefirbsAcceptable = GetReaderValue_NullableBoolean(reader, "RefirbsAcceptable", null);
                    obj.TestingRequired = GetReaderValue_NullableBoolean(reader, "TestingRequired", null);
                    obj.TargetSellPrice = GetReaderValue_Double(reader, "TargetSellPrice", 0);
                    obj.CompetitorBestOffer = GetReaderValue_Double(reader, "CompetitorBestOffer", 0);
                    obj.CustomerDecisionDate = GetReaderValue_DateTime(reader, "CustomerDecisionDate", DateTime.MinValue);
                    obj.RFQClosingDate = GetReaderValue_DateTime(reader, "RFQClosingDate", DateTime.MinValue);
                    obj.QuoteValidityRequired = GetReaderValue_NullableInt32(reader, "QuoteValidityRequired", null);
                    obj.Type = GetReaderValue_NullableInt32(reader, "ReqType", null);
                    obj.OrderToPlace = GetReaderValue_NullableBoolean(reader, "OrderToPlace", null);
                    obj.RequirementforTraceability = GetReaderValue_NullableInt32(reader, "ReqForTraceability", null);
                    //obj.DutyCode = GetReaderValue_String(reader, "DutyCode", null);
                    //obj.DutyRate = GetReaderValue_NullableDouble(reader, "ProductDutyRate", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRequirements", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        // [001] code end

        /// <summary>
        /// GetListOpenForCompany 
		/// Calls [usp_selectAll_CustomerRequirement_open_for_Company]
        /// </summary>
		public override List<CustomerRequirementDetails> GetListOpenForCompany(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_CustomerRequirement_open_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CustomerRequirementDetails> lst = new List<CustomerRequirementDetails>();
				while (reader.Read()) {
					CustomerRequirementDetails obj = new CustomerRequirementDetails();
					obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
					obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.Shortage = GetReaderValue_Boolean(reader, "Shortage", false);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.Alternate = GetReaderValue_Boolean(reader, "Alternate", false);
					obj.OriginalCustomerRequirementNo = GetReaderValue_NullableInt32(reader, "OriginalCustomerRequirementNo", null);
					obj.ReasonNo = GetReaderValue_NullableInt32(reader, "ReasonNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.UsageNo = GetReaderValue_NullableInt32(reader, "UsageNo", null);
					obj.BOM = GetReaderValue_NullableBoolean(reader, "BOM", null);
					obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
					obj.PartWatch = GetReaderValue_NullableBoolean(reader, "PartWatch", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DisplayStatus = GetReaderValue_String(reader, "DisplayStatus", "");
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.UsageName = GetReaderValue_String(reader, "UsageName", "");
					obj.CustomerRequirementValue = GetReaderValue_Double(reader, "CustomerRequirementValue", 0);
					obj.ClosedReason = GetReaderValue_String(reader, "ClosedReason", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CustomerRequirements", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListOpenForLogin 
		/// Calls [usp_selectAll_CustomerRequirement_open_for_Login]
        /// </summary>
		public override List<CustomerRequirementDetails> GetListOpenForLogin(System.Int32? loginId, System.Int32? topToSelect) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_CustomerRequirement_open_for_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CustomerRequirementDetails> lst = new List<CustomerRequirementDetails>();
				while (reader.Read()) {
					CustomerRequirementDetails obj = new CustomerRequirementDetails();
					obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
					obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.Status = GetReaderValue_String(reader, "Status", "");
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.Balance = GetReaderValue_NullableDouble(reader, "Balance", null);
					obj.DaysOverdue = GetReaderValue_NullableInt32(reader, "DaysOverdue", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CustomerRequirements", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListOverdueForLogin 
		/// Calls [usp_selectAll_CustomerRequirement_overdue_for_Login]
        /// </summary>
		public override List<CustomerRequirementDetails> GetListOverdueForLogin(System.Int32? loginId, System.Int32? topToSelect) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_CustomerRequirement_overdue_for_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<CustomerRequirementDetails> lst = new List<CustomerRequirementDetails>();
				while (reader.Read()) {
					CustomerRequirementDetails obj = new CustomerRequirementDetails();
					obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
					obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.Status = GetReaderValue_String(reader, "Status", "");
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.Balance = GetReaderValue_NullableDouble(reader, "Balance", null);
					obj.DaysOverdue = GetReaderValue_NullableInt32(reader, "DaysOverdue", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get CustomerRequirements", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Source 
		/// Calls [usp_source_CustomerRequirement]
        /// </summary>
        public override List<CustomerRequirementDetails> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool hasServerLocal)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
            outDate = null;
			try {
                if (!hasServerLocal)
                {
                    cn = new SqlConnection(this.GTConnectionString);
                    cmd = new SqlCommand("usp_source_CustomerRequirement_Without_ClientId", cn);
                }
                else
                {
                    cn = new SqlConnection(this.ConnectionString);
                    cmd = new SqlCommand("usp_source_CustomerRequirement", cn);
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
				List<CustomerRequirementDetails> lst = new List<CustomerRequirementDetails>();
				while (reader.Read()) {
					CustomerRequirementDetails obj = new CustomerRequirementDetails();
					obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
					obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.SalesmanName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.ClientCode = GetReaderValue_String(reader, "ClientCode", "");
                    //[003] start
                    obj.BOMNo = GetReaderValue_Int32(reader, "BOMID", 0);
                    obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
                    //[003] end
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
				throw new Exception("Failed to get CustomerRequirements", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update CustomerRequirement
		/// Calls [usp_update_CustomerRequirement]
        /// </summary>
        public override bool Update(System.Int32? customerRequirementId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? receivedDate, System.Int32? salesman, System.DateTime? datePromised, System.String notes, System.String instructions, System.Boolean? shortage, System.Int32? companyNo, System.Int32? contactNo, System.Int32? usageNo, System.Boolean? alternate, System.Int32? originalCustomerRequirementNo, System.Int32? reasonNo, System.Int32? productNo, System.String customerPart, System.Boolean? closed, System.Byte? rohs, System.Int32? updatedBy, System.Boolean? partWatch, System.Boolean? bom, System.String bomName, System.Int32? bomNo, System.Boolean? FactorySealed, System.String MSL, System.Boolean? PQA, System.Boolean? ObsoleteChk, System.Boolean? LastTimeBuyChk, System.Boolean? RefirbsAcceptableChk, System.Boolean? TestingRequiredChk, System.Double? TargetSellPrice, System.Double? CompetitorBestOffer, System.DateTime? CustomerDecisionDate, System.DateTime? RFQClosingDate, System.Int32? QuoteValidityRequired, System.Int32? Type, System.Boolean? OrderToPlace, System.Int32? RequirementforTraceability, System.String EAU, System.Boolean? AlternativesAccepted, System.Boolean? RepeatBusiness)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_CustomerRequirement", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CustomerRequirementId", SqlDbType.Int).Value = customerRequirementId;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@ReceivedDate", SqlDbType.DateTime).Value = receivedDate;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@DatePromised", SqlDbType.DateTime).Value = datePromised;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
				cmd.Parameters.Add("@Shortage", SqlDbType.Bit).Value = shortage;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@UsageNo", SqlDbType.Int).Value = usageNo;
				cmd.Parameters.Add("@Alternate", SqlDbType.Bit).Value = alternate;
				cmd.Parameters.Add("@OriginalCustomerRequirementNo", SqlDbType.Int).Value = originalCustomerRequirementNo;
				cmd.Parameters.Add("@ReasonNo", SqlDbType.Int).Value = reasonNo;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@CustomerPart", SqlDbType.NVarChar).Value = customerPart;
				cmd.Parameters.Add("@Closed", SqlDbType.Bit).Value = closed;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@PartWatch", SqlDbType.Bit).Value = partWatch;
				cmd.Parameters.Add("@BOM", SqlDbType.Bit).Value = bom;
				cmd.Parameters.Add("@BOMName", SqlDbType.NVarChar).Value = bomName;
                cmd.Parameters.Add("@FactorySealed", SqlDbType.Bit).Value = FactorySealed;
                cmd.Parameters.Add("@MSL", SqlDbType.NVarChar).Value = MSL;
                //  [002] code start
                cmd.Parameters.Add("@PartialQuantityAcceptable", SqlDbType.Bit).Value = PQA;
                cmd.Parameters.Add("@Obsolete", SqlDbType.Bit).Value = ObsoleteChk;
                cmd.Parameters.Add("@LastTimeBuy", SqlDbType.Bit).Value = LastTimeBuyChk;
                cmd.Parameters.Add("@RefirbsAcceptable", SqlDbType.Bit).Value = RefirbsAcceptableChk;
                cmd.Parameters.Add("@TestingRequired", SqlDbType.Bit).Value = TestingRequiredChk;
                cmd.Parameters.Add("@TargetSellPrice", SqlDbType.Float).Value = TargetSellPrice;
                cmd.Parameters.Add("@CompetitorBestOffer", SqlDbType.Float).Value = CompetitorBestOffer;
                cmd.Parameters.Add("@CustomerDecisionDate", SqlDbType.DateTime).Value = CustomerDecisionDate;
                cmd.Parameters.Add("@RFQClosingDate", SqlDbType.DateTime).Value = RFQClosingDate;
                cmd.Parameters.Add("@QuoteValidityRequired", SqlDbType.Int).Value = QuoteValidityRequired;
                cmd.Parameters.Add("@Type", SqlDbType.Int).Value = Type;
                cmd.Parameters.Add("@OrderToPlace", SqlDbType.Int).Value = OrderToPlace;
                cmd.Parameters.Add("@RequirementForTraceability", SqlDbType.Int).Value = RequirementforTraceability;
                cmd.Parameters.Add("@EAU", SqlDbType.NVarChar).Value = EAU;
                cmd.Parameters.Add("@AlternativesAccepted", SqlDbType.Bit).Value = AlternativesAccepted;
                cmd.Parameters.Add("@RepeatBusiness", SqlDbType.Bit).Value = RepeatBusiness;
                //  [002] code end
                if (bomNo > 0)
                {
                    cmd.Parameters.Add("@BOMNo", SqlDbType.Int).Value = bomNo;
                }
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
                if (ret == -1)
                {
                    return false;
                }
                else
                {
                    return (ret > 0);
                }
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update CustomerRequirement", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		

        /// <summary>
        /// Update CustomerRequirement
		/// Calls [usp_update_CustomerRequirement_Close]
        /// </summary>
		public override bool UpdateClose(System.Int32? customerRequirementId, System.Boolean? includeAllRelatedAlternates, System.Int32? reasonNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_CustomerRequirement_Close", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CustomerRequirementId", SqlDbType.Int).Value = customerRequirementId;
				cmd.Parameters.Add("@IncludeAllRelatedAlternates", SqlDbType.Bit).Value = includeAllRelatedAlternates;
				cmd.Parameters.Add("@ReasonNo", SqlDbType.Int).Value = reasonNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update CustomerRequirement", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// DataListNugget 
        /// Calls [usp_datalistnugget_CustomerRequirementPrint]
        /// </summary>
        public override List<CustomerRequirementDetails> DataListNuggetPrint(System.Int32? clientId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String cmSearch, System.Int32? salesmanNo, System.Int32? companyNo, System.DateTime? receivedDateFrom, System.DateTime? receivedDateTo, System.DateTime? datePromisedFrom, System.DateTime? datePromisedTo, System.Int32? contactNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_datalistnugget_CustomerRequirementPrint", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
                cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
                cmd.Parameters.Add("@SalesmanNo", SqlDbType.Int).Value = salesmanNo;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
                cmd.Parameters.Add("@ReceivedDateFrom", SqlDbType.DateTime).Value = receivedDateFrom;
                cmd.Parameters.Add("@ReceivedDateTo", SqlDbType.DateTime).Value = receivedDateTo;
                cmd.Parameters.Add("@DatePromisedFrom", SqlDbType.DateTime).Value = datePromisedFrom;
                cmd.Parameters.Add("@DatePromisedTo", SqlDbType.DateTime).Value = datePromisedTo;
                cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CustomerRequirementDetails> lst = new List<CustomerRequirementDetails>();
                while (reader.Read())
                {
                    CustomerRequirementDetails obj = new CustomerRequirementDetails();
                    obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
                    obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRequirements", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Print 
        /// Calls [usp_Print_CustomerRequirement_Enquiry_Form]
        /// </summary>
        public override List<CustomerRequirementDetails> GetForPrint(System.String xmlReqNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_Print_CustomerRequirement_Enquiry_Form", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@xmlCustReqNo", SqlDbType.VarChar).Value = xmlReqNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CustomerRequirementDetails> lst = new List<CustomerRequirementDetails>();
                while (reader.Read())
                {
                    CustomerRequirementDetails obj = new CustomerRequirementDetails();
                    obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
                    obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue);
                    obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.Alternate = GetReaderValue_Boolean(reader, "Alternate", false);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRequirements", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// ItemSearch 
        /// Calls [usp_itemsearch_CustomerReqsWithBOM]
        /// </summary>
        public override List<CustomerRequirementDetails> ItemSearchWithBOM(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId,  System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Boolean? includeClosed, System.Int32? customerRequirementNoLo, System.Int32? customerRequirementNoHi, System.DateTime? receivedDateFrom, System.DateTime? receivedDateTo, System.Int32? client, System.String bomName)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_itemsearch_CustomerReqsWithBOM", cn);
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
                cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
                cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
                cmd.Parameters.Add("@CustomerRequirementNoLo", SqlDbType.Int).Value = customerRequirementNoLo;
                cmd.Parameters.Add("@CustomerRequirementNoHi", SqlDbType.Int).Value = customerRequirementNoHi;
                cmd.Parameters.Add("@ReceivedDateFrom", SqlDbType.DateTime).Value = receivedDateFrom;
                cmd.Parameters.Add("@ReceivedDateTo", SqlDbType.DateTime).Value = receivedDateTo;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = client;
                cmd.Parameters.Add("@BOMName", SqlDbType.NVarChar).Value = bomName;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CustomerRequirementDetails> lst = new List<CustomerRequirementDetails>();
                while (reader.Read())
                {
                    CustomerRequirementDetails obj = new CustomerRequirementDetails();
                    obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
                    obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.BOMHeader = GetReaderValue_String(reader, "BOMName", "");
                    obj.PHPrice = GetReaderValue_Double(reader, "PHPrice", 0);
                    obj.PHCurrencyCode = GetReaderValue_String(reader, "PHCurrecyCode", "");
                    obj.AS9120 = GetReaderValue_NullableBoolean(reader, "AS9120", false);
                    obj.IsGlobalCurrencySame = GetReaderValue_NullableBoolean(reader, "IsGlobalCurrencySame", false);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRequirements", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// ItemSearch 
        /// Calls [usp_itemsearch_CustRequirementWithoutBOM]
        /// </summary>
        public override List<CustomerRequirementDetails> ItemSearchWithoutBOM(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Boolean? includeClosed, System.Int32? customerRequirementNoLo, System.Int32? customerRequirementNoHi, System.DateTime? receivedDateFrom, System.DateTime? receivedDateTo, System.Int32? bomId, System.String BOMName)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_itemsearch_CustRequirementWithoutBOM", cn);
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
                cmd.Parameters.Add("@CustomerRequirementNoLo", SqlDbType.Int).Value = customerRequirementNoLo;
                cmd.Parameters.Add("@CustomerRequirementNoHi", SqlDbType.Int).Value = customerRequirementNoHi;
                cmd.Parameters.Add("@ReceivedDateFrom", SqlDbType.DateTime).Value = receivedDateFrom;
                cmd.Parameters.Add("@ReceivedDateTo", SqlDbType.DateTime).Value = receivedDateTo;
                cmd.Parameters.Add("@BOMId", SqlDbType.Int).Value = bomId;
                cmd.Parameters.Add("@BOMName", SqlDbType.NVarChar).Value = BOMName;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CustomerRequirementDetails> lst = new List<CustomerRequirementDetails>();
                while (reader.Read())
                {
                    CustomerRequirementDetails obj = new CustomerRequirementDetails();
                    obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
                    obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.BOMHeader = GetReaderValue_String(reader, "BOMName", "");
                    obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRequirements", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        // [001] code start
        /// <summary>
        /// GetBOMListForCustomerRequirement 
        /// Calls [usp_selectAll_CustomerRequirement_for_BOM]
        /// </summary>
        public override List<CustomerRequirementDetails> GetBOMListForCustomerRequirement(System.Int32? BOMNo, System.Int32? clientID)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_CustomerRequirement_for_BOM", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@BOMNo", SqlDbType.Int).Value = BOMNo;
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = clientID;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CustomerRequirementDetails> lst = new List<CustomerRequirementDetails>();
                while (reader.Read())
                {
                    CustomerRequirementDetails obj = new CustomerRequirementDetails();
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.Alternate = GetReaderValue_Boolean(reader, "Alternate", false);
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
                    obj.BOMHeader = GetReaderValue_String(reader, "BOMHeader", "");
                    obj.BOMNo = GetReaderValue_NullableInt32(reader, "BOMNo", 0);
                    obj.POHubReleaseBy = GetReaderValue_NullableInt32(reader, "POHubReleaseBy", 0);
                    obj.SourcingResultId = GetReaderValue_NullableInt32(reader, "SourcingResultId", 0);
                    obj.RequestToPOHubBy = GetReaderValue_NullableInt32(reader, "RequestToPOHubBy", 0);
                    obj.BOMFullName = GetReaderValue_String(reader, "BOMFullName", "");
                    obj.BOMCode = GetReaderValue_String(reader, "BOMCode", "");
                    obj.ConvertedTargetValue = GetReaderValue_Double(reader, "ConvertedTargetValue", 0);
                    obj.BOMCurrencyCode = GetReaderValue_String(reader, "BOMCurrencyCode", "");
                    obj.PurchaseQuoteId = GetReaderValue_NullableInt32(reader, "PurchaseQuoteId", 0);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.POHubCompany = GetReaderValue_NullableInt32(reader, "POHubCompany", 0);
                    obj.MSL = GetReaderValue_String(reader, "MSL", "");
                    obj.FactorySealed = GetReaderValue_Boolean(reader, "FactorySealed", false);
                    obj.AllSorcingHasDelDate = GetReaderValue_Int32(reader, "AllSorcingHasDelDate", 0);
                    obj.AllSorcingHasProduct = GetReaderValue_Int32(reader, "AllSorcingHasProduct", 0);
                    obj.SourcingResult = GetReaderValue_Int32(reader, "SourcingResult", 0);
                    obj.BOMStatus = GetReaderValue_String(reader, "BOMStatus", "");
                    obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
                    obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                    obj.HasClientSourcingResult = GetReaderValue_Boolean(reader, "HasClientSourcingResult", false);
                    obj.HasHubSourcingResult = GetReaderValue_Boolean(reader, "HasHubSourcingResult", false);
                    obj.IsNoBid = GetReaderValue_NullableBoolean(reader, "IsNoBid", false);
                    obj.ExpeditDate = GetReaderValue_NullableDateTime(reader, "ExpediteDate", null);
                    obj.UpdateByPH = GetReaderValue_Int32(reader, "UpdateByPH", 0);

                    //obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    //obj.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue);
                    //obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    //obj.Shortage = GetReaderValue_Boolean(reader, "Shortage", false);
                    //obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    //obj.OriginalCustomerRequirementNo = GetReaderValue_NullableInt32(reader, "OriginalCustomerRequirementNo", null);
                    //obj.ReasonNo = GetReaderValue_NullableInt32(reader, "ReasonNo", null);
                    //obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    //obj.UsageNo = GetReaderValue_NullableInt32(reader, "UsageNo", null);
                    //obj.BOM = GetReaderValue_NullableBoolean(reader, "BOM", null);
                    //obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
                    //obj.PartWatch = GetReaderValue_NullableBoolean(reader, "PartWatch", null);
                    //obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    //obj.DisplayStatus = GetReaderValue_String(reader, "DisplayStatus", "");
                    //obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    //obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    //obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
                    //obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    //obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    //obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    //obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    //obj.UsageName = GetReaderValue_String(reader, "UsageName", "");
                    //obj.CustomerRequirementValue = GetReaderValue_Double(reader, "CustomerRequirementValue", 0);
                    //obj.ClosedReason = GetReaderValue_String(reader, "ClosedReason", "");
                    //obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    //obj.PurchaseQuoteNumber = GetReaderValue_NullableInt32(reader, "PurchaseQuoteNumber", 0);
                    
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRequirements", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        // [002] code start Here
        /// <summary>
        /// GetBOMListForCustomerRequirement 
        /// Calls [usp_selectCusReqForMail]
        /// </summary>
        public override List<CustomerRequirementDetails> GetHUBRFQForMail(System.Int32? BOMNo, System.Int32? clientID)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectCusReqForMail", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@BOMNo", SqlDbType.Int).Value = BOMNo;
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = clientID;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CustomerRequirementDetails> lst = new List<CustomerRequirementDetails>();
                while (reader.Read())
                {
                    CustomerRequirementDetails obj = new CustomerRequirementDetails();

                    obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
                    obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
                    obj.ConvertedTargetValue = GetReaderValue_Double(reader, "ConvertedTargetValue", 0);
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                    obj.BOMCurrencyCode = GetReaderValue_String(reader, "BOMCurrencyCode", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.MSL = GetReaderValue_String(reader, "MSL", "");
                    obj.FactorySealed = GetReaderValue_Boolean(reader, "FactorySealed", false);
                    obj.ReqTypeText = GetReaderValue_String(reader, "ReqTypeText", "");
                    obj.ReqForTraceabilityText = GetReaderValue_String(reader, "ReqForTraceability", "");
                    obj.AlternativesAccepted = GetReaderValue_Boolean(reader, "AlternativesAccepted", false);
                    obj.RepeatBusiness = GetReaderValue_Boolean(reader, "RepeatBusiness", false);

                    
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRequirements", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        // [002] Code End Here


        /// <summary>
        /// GetBOMListForCustomerRequirement 
        /// Calls [usp_selectAll_CustomerRequirement_for_BOM]
        /// </summary>
        public override List<List<object>> GetBOMListForCRList(System.Int32? BOMNo, System.Int32? clientID, System.Int32? CompanyNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_CustomerRequirements_for_BOM", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@BOMNo", SqlDbType.Int).Value = BOMNo;
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = clientID;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = CompanyNo;
                
                //cmd.Parameters.Add("@Note", SqlDbType.VarChar).Direction = ParameterDirection.Output;
                //int ret = ExecuteNonQuery(cmd);
                //return (Int32)cmd.Parameters["@Rowaffected"].Value;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                //List<CustomerRequirementDetails> lst = new List<CustomerRequirementDetails>();
                //while (reader.Read())
                //{
                //    CustomerRequirementDetails obj = new CustomerRequirementDetails();
                //    obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
                //    obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
                //    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                //    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                //    obj.Part = GetReaderValue_String(reader, "Part", "");
                //    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                //    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                //    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                //    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                //    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                //    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                //    obj.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue);
                //    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                //    obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
                //    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                //    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                //    obj.Shortage = GetReaderValue_Boolean(reader, "Shortage", false);
                //    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                //    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                //    obj.Alternate = GetReaderValue_Boolean(reader, "Alternate", false);
                //    obj.OriginalCustomerRequirementNo = GetReaderValue_NullableInt32(reader, "OriginalCustomerRequirementNo", null);
                //    obj.ReasonNo = GetReaderValue_NullableInt32(reader, "ReasonNo", null);
                //    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                //    obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                //    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                //    obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
                //    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                //    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                //    obj.UsageNo = GetReaderValue_NullableInt32(reader, "UsageNo", null);
                //    obj.BOM = GetReaderValue_NullableBoolean(reader, "BOM", null);
                //    obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
                //    obj.PartWatch = GetReaderValue_NullableBoolean(reader, "PartWatch", null);
                //    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                //    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                //    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                //    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                //    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                //    obj.DisplayStatus = GetReaderValue_String(reader, "DisplayStatus", "");
                //    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                //    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                //    obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
                //    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                //    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                //    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                //    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                //    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                //    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                //    obj.UsageName = GetReaderValue_String(reader, "UsageName", "");
                //    obj.CustomerRequirementValue = GetReaderValue_Double(reader, "CustomerRequirementValue", 0);
                //    obj.ClosedReason = GetReaderValue_String(reader, "ClosedReason", "");
                //    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                //    obj.BOMHeader = GetReaderValue_String(reader, "BOMHeader", "");
                //    obj.BOMNo = GetReaderValue_NullableInt32(reader, "BOMNo", null);
                //    lst.Add(obj);
                //    obj = null;
                //}
                if (reader.HasRows)
                {
                    return GetCustReqDataFromReader(reader);
                }
                else
                {
                    return null;
                }	
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRequirements", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        //[000] code start : BOM
        /// <summary>
        /// Release CustomerRequirement from purchase HUB
        /// Calls [usp_update_CustomerRequirement_Release]
        /// </summary>
        public override bool ReleaseRequirement(System.Int32? customerRequirementId, System.Int32? updatedBy, System.Int32? bomID)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_CustomerRequirement_Release", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustomerRequirementId", SqlDbType.Int).Value = customerRequirementId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@BomId", SqlDbType.Int).Value = bomID;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update CustomerRequirement", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[000] code End : BOM

        //[000] code start : BOM
        /// <summary>
        /// Release CustomerRequirement from purchase HUB
        /// Calls [usp_update_BOM_Release]
        /// </summary>
        public override bool BOMReleaseRequirement(System.Int32? bomID, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_BOM_Release", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BomId", SqlDbType.Int).Value = bomID;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                ExecuteNonQuery(cmd);
                int ret = 1;
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update CustomerRequirement", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[000] code End : BOM
        /// <summary>
        ///Recall NoBid CustomerRequirement from purchase HUB
        /// Calls [usp_update_CustomerRequirement_RecallNoBid]
        /// </summary>
        public override bool RecallNoBidRequirement(System.Int32? customerRequirementId, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_CustomerRequirement_RecallNoBid", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustomerRequirementId", SqlDbType.Int).Value = customerRequirementId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;               
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update CustomerRequirement", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
     
        /// <summary>
        /// NoBid CustomerRequirement from purchase HUB
        /// Calls [usp_update_CustomerRequirement_NoBid]
        /// </summary>
        public override bool NoBidRequirement(System.Int32? customerRequirementId, System.Int32? updatedBy, System.Int32? bomID, string Notes)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_CustomerRequirement_NoBid", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustomerRequirementId", SqlDbType.Int).Value = customerRequirementId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@BomId", SqlDbType.Int).Value = bomID;
                cmd.Parameters.Add("@NoBidNotes", SqlDbType.NVarChar).Value = Notes;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update CustomerRequirement", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
     
        /// <summary>
        /// NoBid CustomerRequirement from purchase HUB
        /// Calls [usp_update_BOM_NoBid]
        /// </summary>
        public override bool BOMNoBidRequirement(System.Int32? bomID, System.Int32? updatedBy, string Notes)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_BOM_NoBid", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BomId", SqlDbType.Int).Value = bomID;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@NoBidNotes", SqlDbType.NVarChar).Value = Notes;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update CustomerRequirement", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        public override Int32 InsertExpedite(System.Int32? HUBRFQId, System.String expediteNotes, System.Int32? UpdatedBy, string ReqIds, System.Int32? emailSendTo)
        {
            string GroupId = string.Format("{0:yyyy-MM-dd_hh-mm-ss}", DateTime.Now);
            GroupId = GroupId + Convert.ToString(UpdatedBy);
            GroupId = GroupId.Replace("_", "").Replace("-", "");
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_HUBRFQExpediteNote", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@HUBRFQId", SqlDbType.Int).Value = HUBRFQId;
                cmd.Parameters.Add("@ExpediteNotes", SqlDbType.NVarChar).Value = expediteNotes;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UpdatedBy;
                cmd.Parameters.Add("@ReqIds", SqlDbType.NVarChar).Value = ReqIds;
                cmd.Parameters.Add("@GroupId", SqlDbType.NVarChar).Value = GroupId;
                cmd.Parameters.Add("@EmailSendTo", SqlDbType.Int).Value = emailSendTo;
                cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
               
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@NewId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert HUBRFQ expedite note", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        public override Int32 InsertHUBRFQExpedite(System.Int32? HUBRFQId, System.String expediteNotes, System.Int32? UpdatedBy, System.Int32? emailSendTo)
        {
            
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_HUBRFQMainInfo_ExpediteNote", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@HUBRFQId", SqlDbType.Int).Value = HUBRFQId;
                cmd.Parameters.Add("@ExpediteNotes", SqlDbType.NVarChar).Value = expediteNotes;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UpdatedBy;
                cmd.Parameters.Add("@EmailSendTo", SqlDbType.Int).Value = emailSendTo;
                cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;

                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@NewId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert HUBRFQ MainInfo expedite note", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Update CustomerRequirement
        /// Calls [usp_update_CustRequirementByBomID]
        /// </summary>
        public override bool Update(System.Int32? bomID, System.Int32? updatedBy, System.Int32? clientNo,System.String ReqsId, System.Int32? BOMStatus)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_CustRequirementByBomID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Bomid", SqlDbType.Int).Value = bomID;
                cmd.Parameters.Add("@ReqIds", SqlDbType.NVarChar).Value = ReqsId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@BOMStatus", SqlDbType.Int).Value = BOMStatus; 
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update CustomerRequirement", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// delete 
        /// Calls [usp_delete_CustomerRequirement_Bom]
        /// </summary>
        public override bool DeleteBomItem(int? bomId, int? requirementId, System.Int32? LoginID, System.Int32? clientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_CustomerRequirement_Bom", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BomID", SqlDbType.Int).Value = bomId;
                cmd.Parameters.Add("@RequirementID", SqlDbType.Int).Value = requirementId;
                cmd.Parameters.Add("@LoginID", SqlDbType.Int).Value = LoginID;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                int ret = cmd.ExecuteNonQuery();// ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Failed to delete CustomerRequirement", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// delete 
        /// Calls [usp_UnRelease_CustomerRequirement_Bom]
        /// </summary>
        public override bool UnReleaseBomItem(int? bomId, int? requirementId) 
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_UnRelease_CustomerRequirement_Bom", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BomId", SqlDbType.Int).Value = bomId;
                cmd.Parameters.Add("@CustomerRequirementId", SqlDbType.Int).Value = requirementId;
                cn.Open();
                int ret = cmd.ExecuteNonQuery();
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Failed to Revoke CustomerRequirement", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// DataListNugget  for HURFQ
        /// Calls [usp_datalistnugget_CustomerRequirementForHUBRFQ]
        ///  add start date and end date  for searching by umendra
        /// </summary>
        public override List<CustomerRequirementDetails> DataListNuggetHUBRFQ(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String BOMCode, System.String bomName, System.Boolean? isPOHub, System.Int32? selectedClientNo, int? bomStatus, int? isAssignToMe, int? assignedUser, System.String Manufacturer, System.String Part, System.Int32? intDivision, System.DateTime? startdate, System.DateTime? enddate, System.Int32? salesPerson)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_datalistnugget_CustomerRequirementForHUBRFQ", cn);
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
                cmd.Parameters.Add("@BOMCode", SqlDbType.NVarChar).Value = BOMCode;
                cmd.Parameters.Add("@BOMName", SqlDbType.NVarChar).Value = bomName;
                cmd.Parameters.Add("@IsPoHub", SqlDbType.Bit).Value = isPOHub;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = selectedClientNo;
                cmd.Parameters.Add("@BomStatus", SqlDbType.Int).Value = bomStatus;
                if (assignedUser > 0)
                {
                    cmd.Parameters.Add("@AssignedUser", SqlDbType.Int).Value = assignedUser;
                }

                cmd.Parameters.Add("@Manufacturer", SqlDbType.NVarChar).Value = Manufacturer;
                cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = Part;
                cmd.Parameters.Add("@ClientDivisionNo", SqlDbType.Int).Value = intDivision;
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startdate;//[004]  
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = enddate;//[004]  
                cmd.Parameters.Add("@SalesPerson", SqlDbType.NVarChar).Value = salesPerson;//[003]

                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CustomerRequirementDetails> lst = new List<CustomerRequirementDetails>();
                while (reader.Read())
                {
                    CustomerRequirementDetails obj = new CustomerRequirementDetails();
                    obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
                    obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.ReceivedDate = GetReaderValue_DateTime(reader, "ReceivedDate", DateTime.MinValue);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.BOMCode = GetReaderValue_String(reader, "BOMCode", "");
                    obj.BOMNo = GetReaderValue_NullableInt32(reader, "BOMId", 0);
                    obj.BOMName = GetReaderValue_String(reader, "BOMName", "");
                    obj.BOMStatus = GetReaderValue_String(reader, "Status", "");
                    obj.Price = GetReaderValue_Double(reader, "Price", 0.00);
                    obj.PHPrice = GetReaderValue_Double(reader, "PHPrice", 0.00);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyId", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.DateRequestToPOHub = GetReaderValue_DateTime(reader, "DateRequestToPOHub", DateTime.MinValue);
                    obj.POCurrencyNo = GetReaderValue_Int32(reader, "POCurrencyNo", 0);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRequirements", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public override List<CustomerRequirementDetails> GetHUBRFQReqNos(string ReqIds, System.Int32? clientID)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_HUBRFQItemByReqIds", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ReqIds", SqlDbType.NVarChar).Value = ReqIds;
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = clientID;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CustomerRequirementDetails> lst = new List<CustomerRequirementDetails>();
                while (reader.Read())
                {
                    CustomerRequirementDetails obj = new CustomerRequirementDetails();

                    obj.CustomerRequirementNumber = GetReaderValue_Int32(reader, "CustomerRequirementNumber", 0);
                    obj.CustomerRequirementId = GetReaderValue_Int32(reader, "CustomerRequirementId", 0);
                  
                    obj.BOMHeader = GetReaderValue_String(reader, "BOMHeader", "");
                    obj.BOMNo = GetReaderValue_NullableInt32(reader, "BOMNo", 0);
                  
                    obj.RequestToPOHubBy = GetReaderValue_NullableInt32(reader, "RequestToPOHubBy", 0);
                    obj.BOMFullName = GetReaderValue_String(reader, "BOMFullName", "");
                    obj.BOMCode = GetReaderValue_String(reader, "BOMCode", "");
                  
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                   

                   

                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRequirements", sqlex);
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
