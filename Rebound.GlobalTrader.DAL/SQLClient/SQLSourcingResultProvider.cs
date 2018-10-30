//Marker     changed by      date         Remarks
//[001]      Aashu          07/06/2018     Added supplier warranty field
//[002]      Aashu          20/06/2018     [REB-11754]: MSL level
//[003]      Aashu          16/08/2018     REB-12322 : A tick box to recomond test the parts from HUB side.
//-----------------------------------------------------------------------------------------
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
	public class SqlSourcingResultProvider : SourcingResultProvider {
		/// <summary>
		/// Delete SourcingResult
		/// Calls [usp_delete_SourcingResult]
		/// </summary>
		public override bool Delete(System.Int32? sourcingResultId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_SourcingResult", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SourcingResultId", SqlDbType.Int).Value = sourcingResultId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete SourcingResult", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_SourcingResult]
		/// </summary>
		public override Int32 Insert(System.Int32? customerRequirementNo, System.String typeName, System.String notes, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? offerStatusNo, System.Int32? supplierNo, System.Byte? rohs, System.Int32? clientNo, System.Int32? updatedBy,System.Int32? mslLevelNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_SourcingResult", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CustomerRequirementNo", SqlDbType.Int).Value = customerRequirementNo;
				cmd.Parameters.Add("@TypeName", SqlDbType.NVarChar).Value = typeName;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@OriginalEntryDate", SqlDbType.DateTime).Value = originalEntryDate;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@OfferStatusNo", SqlDbType.Int).Value = offerStatusNo;
				cmd.Parameters.Add("@SupplierNo", SqlDbType.Int).Value = supplierNo;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@MSLLevelNo", SqlDbType.Int).Value = mslLevelNo;
				cmd.Parameters.Add("@SourcingResultId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@SourcingResultId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert SourcingResult", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_SourcingResult_From_History]
		/// </summary>
		public override Int32 InsertFromHistory(System.Int32? customerRequirementNo, System.Int32? historyNo, System.Int32? clientNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_SourcingResult_From_History", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CustomerRequirementNo", SqlDbType.Int).Value = customerRequirementNo;
				cmd.Parameters.Add("@HistoryNo", SqlDbType.Int).Value = historyNo;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@SourcingResultId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@SourcingResultId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert SourcingResult", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_SourcingResult_From_Offer]
		/// </summary>
        public override Int32 InsertFromOffer(System.Int32? customerRequirementNo, System.Int32? offerNo, System.Int32? updatedBy, System.Boolean isPOHub)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                if (isPOHub)
                    cmd = new SqlCommand("usp_insert_SourcingResult_From_OfferPH", cn);
                else
                    cmd = new SqlCommand("usp_insert_SourcingResult_From_Offer", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustomerRequirementNo", SqlDbType.Int).Value = customerRequirementNo;
                cmd.Parameters.Add("@OfferNo", SqlDbType.Int).Value = offerNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@SourcingResultId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@SourcingResultId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert SourcingResult", sqlex);
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
		/// Calls [usp_insert_SourcingResult_From_Trusted]
		/// </summary>
        public override Int32 InsertFromTrusted(System.Int32? customerRequirementNo, System.Int32? excessNo, System.Int32? updatedBy, System.Boolean isPOHub)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                if (isPOHub)
                    cmd = new SqlCommand("usp_insert_SourcingResult_From_TrustedPH", cn);
                else
                    cmd = new SqlCommand("usp_insert_SourcingResult_From_Trusted", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustomerRequirementNo", SqlDbType.Int).Value = customerRequirementNo;
                cmd.Parameters.Add("@ExcessNo", SqlDbType.Int).Value = excessNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@SourcingResultId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@SourcingResultId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert SourcingResult", sqlex);
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
        /// Calls [usp_insert_SourcingResult_From_POQuote]
        /// </summary>
        public override Int32 InsertFromPOQuote(System.Int32? customerRequirementNo, System.Int32? poQuoteLineNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_SourcingResult_From_PurchaseRequest", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustomerRequirementNo", SqlDbType.Int).Value = customerRequirementNo;
                cmd.Parameters.Add("@POQuoteLineDetailNo", SqlDbType.Int).Value = poQuoteLineNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@SourcingResultId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@SourcingResultId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert SourcingResult", sqlex);
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
		/// Calls [usp_itemsearch_SourcingResult]
        /// </summary>
        public override List<SourcingResultDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Int32? customerRequirementNoLo, System.Int32? customerRequirementNoHi, System.String supplierSearch, System.Boolean? IsPoHub, System.Int32? intQuoteID,System.String bom)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_itemsearch_SourcingResult", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@CustomerRequirementNoLo", SqlDbType.Int).Value = customerRequirementNoLo;
				cmd.Parameters.Add("@CustomerRequirementNoHi", SqlDbType.Int).Value = customerRequirementNoHi;
				cmd.Parameters.Add("@SupplierSearch", SqlDbType.NVarChar).Value = supplierSearch;              
                cmd.Parameters.Add("@IsPoHub", SqlDbType.Bit).Value = IsPoHub;
                cmd.Parameters.Add("@intQuoteID", SqlDbType.Int).Value = intQuoteID;
                cmd.Parameters.Add("@BOM", SqlDbType.NVarChar).Value = bom;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SourcingResultDetails> lst = new List<SourcingResultDetails>();
				while (reader.Read()) {
					SourcingResultDetails obj = new SourcingResultDetails();
					obj.SourcingResultId = GetReaderValue_Int32(reader, "SourcingResultId", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
					obj.OfferStatusChangeDate = GetReaderValue_NullableDateTime(reader, "OfferStatusChangeDate", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CustomerRequirementId = GetReaderValue_NullableInt32(reader, "CustomerRequirementId", null);
					obj.CustomerRequirementNumber = GetReaderValue_NullableInt32(reader, "CustomerRequirementNumber", null);
					obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.OfferStatusChangeEmployeeName = GetReaderValue_String(reader, "OfferStatusChangeEmployeeName", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.IsPoHub = GetReaderValue_String(reader, "IsPoHub", "");
                    obj.ClientCompanyNo = GetReaderValue_NullableInt32(reader, "ClientCompanyNo", null);
                    obj.ClientSupplierName = GetReaderValue_String(reader, "ClientCompanyName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SourcingResults", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_SourcingResult]
        /// </summary>
		public override SourcingResultDetails Get(System.Int32? sourcingResultId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_SourcingResult", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SourcingResultId", SqlDbType.Int).Value = sourcingResultId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetSourcingResultFromReader(reader);
					SourcingResultDetails obj = new SourcingResultDetails();
					obj.SourcingResultId = GetReaderValue_Int32(reader, "SourcingResultId", 0);
					obj.CustomerRequirementNo = GetReaderValue_Int32(reader, "CustomerRequirementNo", 0);
					obj.SourcingTable = GetReaderValue_String(reader, "SourcingTable", "");
					obj.SourcingTableItemNo = GetReaderValue_NullableInt32(reader, "SourcingTableItemNo", null);
					obj.TypeName = GetReaderValue_String(reader, "TypeName", "");
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.OriginalEntryDate = GetReaderValue_NullableDateTime(reader, "OriginalEntryDate", null);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.OfferStatusNo = GetReaderValue_NullableInt32(reader, "OfferStatusNo", null);
					obj.OfferStatusChangeDate = GetReaderValue_NullableDateTime(reader, "OfferStatusChangeDate", null);
					obj.OfferStatusChangeLoginNo = GetReaderValue_NullableInt32(reader, "OfferStatusChangeLoginNo", null);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                    obj.SupplierPrice = GetReaderValue_Double(reader, "SupplierPrice", 0);
                    obj.POHubSupplierName = GetReaderValue_String(reader, "POHubSupplierName", "");
                    obj.POHubCompanyNo = GetReaderValue_NullableInt32(reader, "POHubCompanyNo", 0);
                    obj.UPLiftPrice = GetReaderValue_NullableDouble(reader, "UPLiftPrice", 0);
                    obj.ClientCompanyNo = GetReaderValue_NullableInt32(reader, "ClientCompanyNo", null);
                    obj.ClientSupplierName = GetReaderValue_String(reader, "ClientSupplierName", "");
                    obj.EstimatedShippingCost = GetReaderValue_NullableDouble(reader, "EstimatedShippingCost", 0);
                    obj.ActualPrice = GetReaderValue_NullableDouble(reader, "SupplierPrice", 0);
                    obj.SupplierPercentage = GetReaderValue_NullableDouble(reader, "UPLiftPrice", 0);
                    obj.ClientCurrencyNo = GetReaderValue_Int32(reader, "ClientCurrencyNo", 0);
                    obj.ClientCurrencyCode = GetReaderValue_String(reader, "ClientCurrencyCode", "");
                    obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);

                    obj.SPQ = GetReaderValue_String(reader, "SPQ", "");
                    obj.LeadTime = GetReaderValue_String(reader, "LeadTime", "");
                    obj.ROHSStatus = GetReaderValue_String(reader, "ROHSStatus", "");
                    obj.FactorySealed = GetReaderValue_String(reader, "FactorySealed", "");
                    obj.MSL = GetReaderValue_String(reader, "MSL", "");
                    obj.SupplierMOQ = GetReaderValue_String(reader, "SupplierMOQ", "");
                    obj.SupplierTotalQSA = GetReaderValue_String(reader, "SupplierTotalQSA", "");
                    obj.SupplierLTB = GetReaderValue_String(reader, "SupplierLTB", "");
                    obj.SupplierNotes = GetReaderValue_String(reader, "SupplierNotes", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.RegionNo = GetReaderValue_Int32(reader, "RegionNo", 0);

                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.OriginalPrice = GetReaderValue_NullableDouble(reader, "ActualPrice", 0);
                    obj.ActualCurrencyNo = GetReaderValue_Int32(reader, "ActualCurrencyNo", 0);
                    obj.ActualCurrencyCode = GetReaderValue_String(reader, "ActualCurrencyCode", "");
                    obj.SourcingNotes = GetReaderValue_String(reader, "SourcingNotes", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ProductInactive = GetReaderValue_NullableBoolean(reader, "ProductInactive", false);
                    obj.MSLLevelNo = GetReaderValue_Int32(reader, "MSLLevelNo", 0);

                    //[001] start
                    obj.SupplierWarranty = GetReaderValue_NullableInt32(reader, "SupplierWarranty", null);
                    obj.NonPreferredCompany = GetReaderValue_NullableBoolean(reader, "NonPreferredCompany", null);
                    //[001] end
                    obj.MSLLevelText = GetReaderValue_String(reader, "MSLLevel", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SourcingResult", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}


        /// <summary>
        /// GetListForCustomerRequirement 
        /// Calls [usp_SourcingResult_for_CustomerRequirement]
        /// </summary>
        public override List<SourcingResultDetails> GetListForSourcing(System.Int32? customerRequirementId, System.Boolean? isFromQuote)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_SourcingResult_for_CustomerRequirement", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRequirementId", SqlDbType.Int).Value = customerRequirementId;
                cmd.Parameters.Add("@IsFromQuote", SqlDbType.Bit).Value = isFromQuote;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SourcingResultDetails> lst = new List<SourcingResultDetails>();
                while (reader.Read())
                {
                    SourcingResultDetails obj = new SourcingResultDetails();
                    obj.SourcingResultId = GetReaderValue_Int32(reader, "SourcingResultId", 0);
                    obj.CustomerRequirementNo = GetReaderValue_Int32(reader, "CustomerRequirementNo", 0);
                    obj.SourcingTable = GetReaderValue_String(reader, "SourcingTable", "");
                    obj.SourcingTableItemNo = GetReaderValue_NullableInt32(reader, "SourcingTableItemNo", null);
                    obj.TypeName = GetReaderValue_String(reader, "TypeName", "");
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.OriginalEntryDate = GetReaderValue_NullableDateTime(reader, "OriginalEntryDate", null);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.OfferStatusNo = GetReaderValue_NullableInt32(reader, "OfferStatusNo", null);
                    obj.OfferStatusChangeDate = GetReaderValue_NullableDateTime(reader, "OfferStatusChangeDate", null);
                    obj.OfferStatusChangeLoginNo = GetReaderValue_NullableInt32(reader, "OfferStatusChangeLoginNo", null);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.OfferStatusChangeEmployeeName = GetReaderValue_String(reader, "OfferStatusChangeEmployeeName", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.POHubCompanyNo = GetReaderValue_NullableInt32(reader, "POHubCompanyNo", null);
                    obj.POHubSupplierName = GetReaderValue_String(reader, "POHubSupplierName", "");
                    obj.POHubReleaseBy = GetReaderValue_NullableInt32(reader, "POHubReleaseBy", 0);
                    obj.ClientCompanyNo = GetReaderValue_NullableInt32(reader, "ClientCompanyNo", null);
                    obj.ClientSupplierName = GetReaderValue_String(reader, "ClientSupplierName", "");
                    obj.ClientCurrencyNo = GetReaderValue_Int32(reader, "ClientCurrencyNo", 0);
                    obj.IsReleased = GetReaderValue_Boolean(reader, "IsReleased", false);
                    obj.Recalled = GetReaderValue_Boolean(reader, "Recalled", false);                    
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SourcingResults", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		
        /// <summary>
        /// GetListForCustomerRequirement 
		/// Calls [usp_selectAll_SourcingResult_for_CustomerRequirement]
        /// </summary>
		public override List<SourcingResultDetails> GetListForCustomerRequirement(System.Int32? customerRequirementId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SourcingResult_for_CustomerRequirement", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CustomerRequirementId", SqlDbType.Int).Value = customerRequirementId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SourcingResultDetails> lst = new List<SourcingResultDetails>();
				while (reader.Read()) {
					SourcingResultDetails obj = new SourcingResultDetails();
					obj.SourcingResultId = GetReaderValue_Int32(reader, "SourcingResultId", 0);
					obj.CustomerRequirementNo = GetReaderValue_Int32(reader, "CustomerRequirementNo", 0);
					obj.SourcingTable = GetReaderValue_String(reader, "SourcingTable", "");
					obj.SourcingTableItemNo = GetReaderValue_NullableInt32(reader, "SourcingTableItemNo", null);
					obj.TypeName = GetReaderValue_String(reader, "TypeName", "");
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.OriginalEntryDate = GetReaderValue_NullableDateTime(reader, "OriginalEntryDate", null);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.OfferStatusNo = GetReaderValue_NullableInt32(reader, "OfferStatusNo", null);
					obj.OfferStatusChangeDate = GetReaderValue_NullableDateTime(reader, "OfferStatusChangeDate", null);
					obj.OfferStatusChangeLoginNo = GetReaderValue_NullableInt32(reader, "OfferStatusChangeLoginNo", null);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.OfferStatusChangeEmployeeName = GetReaderValue_String(reader, "OfferStatusChangeEmployeeName", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.POHubCompanyNo = GetReaderValue_NullableInt32(reader, "POHubCompanyNo", null);
                    obj.POHubSupplierName = GetReaderValue_String(reader, "POHubSupplierName", "");
                    obj.POHubReleaseBy = GetReaderValue_NullableInt32(reader, "POHubReleaseBy", 0);
                    obj.ClientCompanyNo = GetReaderValue_NullableInt32(reader, "ClientCompanyNo", null);
                    obj.ClientSupplierName = GetReaderValue_String(reader, "ClientSupplierName", "");
                    obj.ClientCurrencyNo = GetReaderValue_Int32(reader, "ClientCurrencyNo", 0);
                    obj.IsClosed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.IsSoCreated = GetReaderValue_Boolean(reader, "IsSoCreated", false);
                    obj.EstimatedShippingCost = GetReaderValue_NullableDouble(reader, "EstimatedShippingCost", 0);
                    obj.IsSoCreated = GetReaderValue_Boolean(reader, "IsSoCreated", false);
                    obj.IsApplyPOBankFee = GetReaderValue_Boolean(reader, "IsApplyPOBankFee", false);
                    obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
                    obj.SourceRef = GetReaderValue_String(reader, "SourceRef", "");

                    obj.OriginalPrice = GetReaderValue_NullableDouble(reader, "BuyPrice", 0);
                    obj.ActualCurrencyNo = GetReaderValue_Int32(reader, "ActualCurrencyNo", 0);
                    obj.ActualCurrencyCode = GetReaderValue_String(reader, "BuyCurrencyCode", "");
                    obj.SupplierType = GetReaderValue_String(reader, "SupplierType", "");
                    obj.RegionName = GetReaderValue_String(reader, "RegionName", "");
                    //[002] start
                    obj.MSL = GetReaderValue_String(reader, "MSLLevel", "");
                    //[002] end
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SourcingResults", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// GetListForCustomerRequirement 
        /// Calls [usp_selectAll_SourcingResult_for_CustomerRequirement]
        /// </summary>
        public override List<SourcingResultDetails> GetListForCustomerRequirementCopy(System.Int32? customerRequirementId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SourcingResult_for_CustomerRequirement", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRequirementId", SqlDbType.Int).Value = customerRequirementId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SourcingResultDetails> lst = new List<SourcingResultDetails>();
                while (reader.Read())
                {
                    SourcingResultDetails obj = new SourcingResultDetails();
                    obj.SourcingResultId = GetReaderValue_Int32(reader, "SourcingResultId", 0);
                    obj.CustomerRequirementNo = GetReaderValue_Int32(reader, "CustomerRequirementNo", 0);
                    obj.SourcingTable = GetReaderValue_String(reader, "SourcingTable", "");
                    obj.SourcingTableItemNo = GetReaderValue_NullableInt32(reader, "SourcingTableItemNo", null);
                    obj.TypeName = GetReaderValue_String(reader, "TypeName", "");
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.OriginalEntryDate = GetReaderValue_NullableDateTime(reader, "OriginalEntryDate", null);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.OfferStatusNo = GetReaderValue_NullableInt32(reader, "OfferStatusNo", null);
                    obj.OfferStatusChangeDate = GetReaderValue_NullableDateTime(reader, "OfferStatusChangeDate", null);
                    obj.OfferStatusChangeLoginNo = GetReaderValue_NullableInt32(reader, "OfferStatusChangeLoginNo", null);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.OfferStatusChangeEmployeeName = GetReaderValue_String(reader, "OfferStatusChangeEmployeeName", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.POHubCompanyNo = GetReaderValue_NullableInt32(reader, "POHubCompanyNo", null);
                    obj.POHubSupplierName = GetReaderValue_String(reader, "POHubSupplierName", "");
                    obj.POHubReleaseBy = GetReaderValue_NullableInt32(reader, "POHubReleaseBy", 0);
                    obj.ClientCompanyNo = GetReaderValue_NullableInt32(reader, "ClientCompanyNo", null);
                    obj.ClientSupplierName = GetReaderValue_String(reader, "ClientSupplierName", "");
                    obj.ClientCurrencyNo = GetReaderValue_Int32(reader, "ClientCurrencyNo", 0);
                    obj.IsClosed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.IsSoCreated = GetReaderValue_Boolean(reader, "IsSoCreated", false);
                    obj.EstimatedShippingCost = GetReaderValue_NullableDouble(reader, "EstimatedShippingCost", 0);
                    obj.IsSoCreated = GetReaderValue_Boolean(reader, "IsSoCreated", false);
                    obj.IsApplyPOBankFee = GetReaderValue_Boolean(reader, "IsApplyPOBankFee", false);
                    obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
                    obj.SourceRef = GetReaderValue_String(reader, "SourceRef", "");

                    obj.OriginalPrice = GetReaderValue_NullableDouble(reader, "BuyPrice", 0);
                    obj.ActualCurrencyNo = GetReaderValue_Int32(reader, "ActualCurrencyNo", 0);
                    obj.ActualCurrencyCode = GetReaderValue_String(reader, "BuyCurrencyCode", "");
                    obj.SupplierType = GetReaderValue_String(reader, "SupplierType", "");
                    obj.RegionName = GetReaderValue_String(reader, "RegionName", "");

                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SourcingResults", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		
		
        /// <summary>
        /// GetListForQuoteLine 
		/// Calls [usp_selectAll_SourcingResult_for_QuoteLine]
        /// </summary>
		public override List<SourcingResultDetails> GetListForQuoteLine(System.Int32? quoteLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SourcingResult_for_QuoteLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@QuoteLineId", SqlDbType.Int).Value = quoteLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SourcingResultDetails> lst = new List<SourcingResultDetails>();
				while (reader.Read()) {
					SourcingResultDetails obj = new SourcingResultDetails();
					obj.SourcingResultId = GetReaderValue_Int32(reader, "SourcingResultId", 0);
					obj.CustomerRequirementNo = GetReaderValue_Int32(reader, "CustomerRequirementNo", 0);
					obj.SourcingTable = GetReaderValue_String(reader, "SourcingTable", "");
					obj.SourcingTableItemNo = GetReaderValue_NullableInt32(reader, "SourcingTableItemNo", null);
					obj.TypeName = GetReaderValue_String(reader, "TypeName", "");
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.OriginalEntryDate = GetReaderValue_NullableDateTime(reader, "OriginalEntryDate", null);
					obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
					obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.OfferStatusNo = GetReaderValue_NullableInt32(reader, "OfferStatusNo", null);
					obj.OfferStatusChangeDate = GetReaderValue_NullableDateTime(reader, "OfferStatusChangeDate", null);
					obj.OfferStatusChangeLoginNo = GetReaderValue_NullableInt32(reader, "OfferStatusChangeLoginNo", null);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CustomerRequirementNumber = GetReaderValue_NullableInt32(reader, "CustomerRequirementNumber", null);
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.OfferStatusChangeEmployeeName = GetReaderValue_String(reader, "OfferStatusChangeEmployeeName", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");

                    obj.POHubCompanyNo = GetReaderValue_NullableInt32(reader, "POHubCompanyNo", null);
                    obj.POHubSupplierName = GetReaderValue_String(reader, "POHubSupplierName", "");
                    //obj.POHubReleaseBy = GetReaderValue_NullableInt32(reader, "POHubReleaseBy", 0);
                    obj.ClientCompanyNo = GetReaderValue_NullableInt32(reader, "ClientCompanyNo", null);
                    obj.ClientSupplierName = GetReaderValue_String(reader, "ClientSupplierName", "");
                    obj.ClientCurrencyNo = GetReaderValue_Int32(reader, "ClientCurrencyNo", 0);
                    obj.ClientCurrencyCode = GetReaderValue_String(reader, "ClientCurrencyCode", "");
                   // obj.ConvertedSourcingPrice = GetReaderValue_Double(reader, "ConvertedSourcingPrice", 0);
                    obj.SupplierType = GetReaderValue_String(reader, "SupplierType", "");
                    obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);
                    obj.EstimatedShippingCost = GetReaderValue_Double(reader, "EstimatedShippingCost", 0);
                    obj.RegionName = GetReaderValue_String(reader, "RegionName", "");

                    obj.HubRFQName = GetReaderValue_String(reader, "HubRFQName", "");
                    obj.HubRFQNo = GetReaderValue_Int32(reader, "HubRFQNo", 0);
                    obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
                    obj.IsApplyPOBankFee = GetReaderValue_Boolean(reader, "IsApplyPOBankFee", false);

					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SourcingResults", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update SourcingResult
		/// Calls [usp_update_SourcingResult]
        /// </summary>
		public override bool Update(System.Int32? sourcingResultId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.Int32? offerStatusNo, System.Int32? supplierNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy,System.Int32? mslLevelNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_SourcingResult", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SourcingResultId", SqlDbType.Int).Value = sourcingResultId;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@OfferStatusNo", SqlDbType.Int).Value = offerStatusNo;
				cmd.Parameters.Add("@SupplierNo", SqlDbType.Int).Value = supplierNo;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@MSLLevelNo", SqlDbType.Int).Value = mslLevelNo;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update SourcingResult", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// GetListForBOMCustomerRequirement 
        /// Calls [usp_selectAll_SourcingResult_for_BOMCustomerRequirement]
        /// </summary>
        public override List<SourcingResultDetails> GetListForBOMCustomerRequirement(System.Int32? customerRequirementId, System.Boolean isPOHub)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SourcingResult_for_BOMCustomerRequirement", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRequirementId", SqlDbType.Int).Value = customerRequirementId;
                cmd.Parameters.Add("@IsPoHub", SqlDbType.Bit).Value = isPOHub;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SourcingResultDetails> lst = new List<SourcingResultDetails>();
                while (reader.Read())
                {
                    SourcingResultDetails obj = new SourcingResultDetails();
                    obj.SourcingResultId = GetReaderValue_Int32(reader, "SourcingResultId", 0);
                    obj.CustomerRequirementNo = GetReaderValue_Int32(reader, "CustomerRequirementNo", 0);
                    obj.SourcingTable = GetReaderValue_String(reader, "SourcingTable", "");
                    obj.SourcingTableItemNo = GetReaderValue_NullableInt32(reader, "SourcingTableItemNo", null);
                    obj.TypeName = GetReaderValue_String(reader, "TypeName", "");
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.OriginalEntryDate = GetReaderValue_NullableDateTime(reader, "OriginalEntryDate", null);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.OfferStatusNo = GetReaderValue_NullableInt32(reader, "OfferStatusNo", null);
                    obj.OfferStatusChangeDate = GetReaderValue_NullableDateTime(reader, "OfferStatusChangeDate", null);
                    obj.OfferStatusChangeLoginNo = GetReaderValue_NullableInt32(reader, "OfferStatusChangeLoginNo", null);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.OfferStatusChangeEmployeeName = GetReaderValue_String(reader, "OfferStatusChangeEmployeeName", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.SupplierPrice = GetReaderValue_Double(reader, "SupplierPrice", 0);
                    obj.POHubCompanyNo = GetReaderValue_NullableInt32(reader, "POHubCompanyNo", null);
                    obj.POHubSupplierName = GetReaderValue_String(reader, "POHubSupplierName", "");
                    obj.POHubReleaseBy = GetReaderValue_NullableInt32(reader, "POHubReleaseBy", 0);
                    obj.ClientCompanyNo = GetReaderValue_NullableInt32(reader, "ClientCompanyNo", null);
                    obj.ClientSupplierName = GetReaderValue_String(reader, "ClientSupplierName", "");
                    obj.ClientCurrencyNo = GetReaderValue_Int32(reader, "ClientCurrencyNo", 0);
                    obj.ClientCurrencyCode = GetReaderValue_String(reader, "ClientCurrencyCode", "");
                    obj.ConvertedSourcingPrice = GetReaderValue_Double(reader, "ConvertedSourcingPrice", 0);
                    obj.MslSpqFactorySealed = GetReaderValue_String(reader, "MslSpqFactorySealed", "");
                    obj.EstimatedShippingCost = GetReaderValue_NullableDouble(reader, "EstimatedShippingCost", 0);

                    obj.SupplierType = GetReaderValue_String(reader, "SupplierType", "");
                    obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);

                    obj.ActualPrice = GetReaderValue_NullableDouble(reader, "SupplierPrice", 0);
                    obj.SupplierPercentage = GetReaderValue_NullableDouble(reader, "UPLiftPrice", 0);

                    obj.SupplierManufacturerName = GetReaderValue_String(reader, "SupplierManufacturerName", "");
                    obj.SupplierDateCode = GetReaderValue_String(reader, "SupplierDateCode", "");
                    obj.SupplierPackageType = GetReaderValue_String(reader, "SupplierPackageType", "");
                    obj.SupplierProductType = GetReaderValue_String(reader, "SupplierProductType", "");
                    obj.SupplierMOQ = GetReaderValue_String(reader, "SupplierMOQ", "");
                    obj.SupplierTotalQSA = GetReaderValue_String(reader, "SupplierTotalQSA", "");
                    obj.SupplierLTB = GetReaderValue_String(reader, "SupplierLTB", "");
                    obj.SupplierNotes = GetReaderValue_String(reader, "SupplierNotes", "");
                    obj.SourcingRelease = GetReaderValue_NullableBoolean(reader, "SourcingReleased", false);
                    obj.SPQ = GetReaderValue_String(reader, "SPQ", "");
                    obj.LeadTime = GetReaderValue_String(reader, "LeadTime", "");
                    obj.ROHSStatus = GetReaderValue_String(reader, "ROHSStatus", "");
                    obj.FactorySealed = GetReaderValue_String(reader, "FactorySealed", "");
                    obj.MSL = GetReaderValue_String(reader, "MSL", "");
                    obj.IsClosed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.RegionName = GetReaderValue_String(reader, "RegionName", "");
                    obj.IsClosed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.IsSoCreated = GetReaderValue_Boolean(reader, "IsSoCreated", false);
                    obj.IsApplyPOBankFee = GetReaderValue_Boolean(reader, "IsApplyPOBankFee", false);
                    obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
                    obj.SourceRef = GetReaderValue_String(reader, "SourceRef", "");

                    obj.OriginalPrice = GetReaderValue_NullableDouble(reader, "BuyPrice", 0);
                    obj.ActualCurrencyNo = GetReaderValue_Int32(reader, "ActualCurrencyNo", 0);
                    obj.ActualCurrencyCode = GetReaderValue_String(reader, "BuyCurrencyCode", "");
                    obj.SourcingReleasedCount = GetReaderValue_Int32(reader, "SourcingReleasedCount", 0);
                    obj.MSLLevelNo = GetReaderValue_Int32(reader, "MSLLevelNo", 0);
                    obj.MSLLevelText = GetReaderValue_String(reader, "MSLLevelText", "");

                    //[001] start
                    obj.SupplierWarranty = GetReaderValue_Int32(reader, "SupplierWarranty", 0);
                    //[001] end
                    //[003] start
                    obj.IsTestingRecommended = GetReaderValue_Boolean(reader, "IsTestingRecommended", false);
                    //[003] end
                    obj.IsImageAvailable = GetReaderValue_NullableBoolean(reader, "IsImageAvailable", false);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SourcingResults", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Update SourcingResult
        /// Calls [usp_update_POHubSourcingResult]
        /// </summary>
        //[003] start
        public override bool UpdatePOHub(System.Int32? sourcingResultId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.Int32? offerStatusNo, System.Int32? supplierNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, System.Double? suplierPrice, double? estimatedShippingCost, DateTime? deliveryDate, bool isPoHub, System.String SPQ, System.String leadTime, System.String rohsStatus, System.String factorySealed, System.String MSL, System.String supplierTotalQSA, System.String supplierMOQ, System.String supplierLTB, System.Int32? regionNo, System.Int32? hubCurrencyNo, System.Int32? linkMultiCurrencyNo, System.Int32? mslLevelNo, System.Int32? supplierWarranty,System.Boolean? isTestingRecommended)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_POHubSourcingResult", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SourcingResultId", SqlDbType.Int).Value = sourcingResultId;
                cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
                cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
                cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
                cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
                cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
                //cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
                cmd.Parameters.Add("@OfferStatusNo", SqlDbType.Int).Value = offerStatusNo;
                cmd.Parameters.Add("@SupplierNo", SqlDbType.Int).Value = supplierNo;
                cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@SuplierPrice", SqlDbType.Float).Value = suplierPrice;
                cmd.Parameters.Add("@EstimatedShippingCost", SqlDbType.Float).Value = estimatedShippingCost;
                cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = deliveryDate;
                cmd.Parameters.Add("@PUHUB", SqlDbType.Bit).Value = isPoHub;

                cmd.Parameters.Add("@SPQ", SqlDbType.NVarChar).Value = SPQ;
                cmd.Parameters.Add("@LeadTime", SqlDbType.NVarChar).Value = leadTime;
                cmd.Parameters.Add("@ROHSStatus", SqlDbType.NVarChar).Value = rohsStatus;
                cmd.Parameters.Add("@FactorySealed", SqlDbType.NVarChar).Value = factorySealed;
                cmd.Parameters.Add("@MSL", SqlDbType.NVarChar).Value = MSL;
                cmd.Parameters.Add("@SupplierTotalQSA", SqlDbType.NVarChar).Value = supplierTotalQSA;
                cmd.Parameters.Add("@SupplierLTB", SqlDbType.NVarChar).Value = supplierLTB;
                cmd.Parameters.Add("@SupplierMOQ", SqlDbType.NVarChar).Value = supplierMOQ;
                cmd.Parameters.Add("@RegionNo", SqlDbType.Int).Value = regionNo;
                cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = hubCurrencyNo;
                cmd.Parameters.Add("@LinkMultiCurrencyNo", SqlDbType.Int).Value = linkMultiCurrencyNo;
                cmd.Parameters.Add("@MSLLevelNo", SqlDbType.Int).Value = mslLevelNo;
                cmd.Parameters.Add("@SupplierWarranty", SqlDbType.Int).Value = supplierWarranty;
                //[003] start
                cmd.Parameters.Add("@isTestingRecommended", SqlDbType.Bit).Value = isTestingRecommended;
                //[003] end
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update SourcingResult", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// ConvertPriceToDifferentCurrency
        /// Calls [usp_Convert_Price_To_Different_Currency]
        /// </summary>
        public override SourcingResultDetails ConvertPriceToDifferentCurrency(System.Int32? intFromCurrency, System.Int32? intToCurrency, System.Double? upliftPrice, System.Double? hubBuyPrice, System.Int32? sourcingResultNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_Convert_Price_To_Different_Currency", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
               // cmd.Parameters.Add("@FromCurrencyNo", SqlDbType.Int).Value = intFromCurrency;
                cmd.Parameters.Add("@ToCurrencyNo", SqlDbType.Int).Value = intToCurrency;
                //cmd.Parameters.Add("@UpliftPrice", SqlDbType.Float).Value = upliftPrice;
                //cmd.Parameters.Add("@HubBuyPrice", SqlDbType.Float).Value = hubBuyPrice;
                cmd.Parameters.Add("@SourcingResultNo", SqlDbType.Int).Value = sourcingResultNo;
                
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSourcingResultFromReader(reader);
                    SourcingResultDetails obj = new SourcingResultDetails();
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.UPLiftPrice = GetReaderValue_NullableDouble(reader, "UpliftPriceInToCurrency", 0);
                    obj.SupplierPrice = GetReaderValue_NullableDouble(reader, "HubBuyPriceInBase", 0);
                    obj.EstimatedShippingCost = GetReaderValue_NullableDouble(reader, "ToShippingCost", 0);
                    obj.SupplierPercentage = GetReaderValue_NullableDouble(reader, "UpliftPer", 0);
                    
                
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
                throw new Exception("Failed to convert price", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


       
        /// <summary>
        /// Release 
        /// Calls [usp_update_Sourcing_Release]
        /// </summary>
        public override bool ReleaseSourcing(System.Int32? sourcingResultID, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Sourcing_Release", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SourcingResultID", SqlDbType.Int).Value = sourcingResultID;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
              
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Sourcing Result", sqlex);
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
        /// Calls [usp_insert_SourcingResult]
        /// </summary>
        //[003] start
        public override Int32 InsertSourcingResult(System.Int32? customerRequirementNo, System.String typeName, System.String notes, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? offerStatusNo, System.Int32? supplierNo, System.Byte? rohs, System.Int32? clientNo, System.Int32? updatedBy,
            System.Double? suplierPrice, double? estimatedShippingCost, DateTime? deliveryDate, bool isPoHub, System.String SPQ, System.String leadTime, System.String rohsStatus, System.String factorySealed, System.String MSL, System.String supplierTotalQSA, System.String supplierMOQ, System.String supplierLTB, System.Int32? regionNo, System.Int32? hubCurrencyNo, System.Int32? mslLevelNo, System.Int32? supplierWarranty,System.Boolean? isTestingRecommended)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_SourcingResultWithOffer", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustomerRequirementNo", SqlDbType.Int).Value = customerRequirementNo;
                cmd.Parameters.Add("@TypeName", SqlDbType.NVarChar).Value = typeName;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
                cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
                cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
                cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
                cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;              
                cmd.Parameters.Add("@OriginalEntryDate", SqlDbType.DateTime).Value = originalEntryDate;
                cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
                cmd.Parameters.Add("@OfferStatusNo", SqlDbType.Int).Value = offerStatusNo;
                cmd.Parameters.Add("@SupplierNo", SqlDbType.Int).Value = supplierNo;
                cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;

                cmd.Parameters.Add("@SuplierPrice", SqlDbType.Float).Value = suplierPrice;
                cmd.Parameters.Add("@EstimatedShippingCost", SqlDbType.Float).Value = estimatedShippingCost;
                cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = deliveryDate;
                cmd.Parameters.Add("@PUHUB", SqlDbType.Bit).Value = isPoHub;
                cmd.Parameters.Add("@SPQ", SqlDbType.NVarChar).Value = SPQ;
                cmd.Parameters.Add("@LeadTime", SqlDbType.NVarChar).Value = leadTime;
                cmd.Parameters.Add("@ROHSStatus", SqlDbType.NVarChar).Value = rohsStatus;
                cmd.Parameters.Add("@FactorySealed", SqlDbType.NVarChar).Value = factorySealed;
                cmd.Parameters.Add("@MSL", SqlDbType.NVarChar).Value = MSL;
                cmd.Parameters.Add("@SupplierTotalQSA", SqlDbType.NVarChar).Value = supplierTotalQSA;
                cmd.Parameters.Add("@SupplierLTB", SqlDbType.NVarChar).Value = supplierLTB;
                cmd.Parameters.Add("@SupplierMOQ", SqlDbType.NVarChar).Value = supplierMOQ;
                cmd.Parameters.Add("@RegionNo", SqlDbType.Int).Value = regionNo;
                cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = hubCurrencyNo;
                cmd.Parameters.Add("@MSLLevelNo", SqlDbType.Int).Value = mslLevelNo;

              //  cmd.Parameters.Add("@LinkMultiCurrencyNo", SqlDbType.Int).Value = linkMultiCurrencyNo;
                //[001] start
                cmd.Parameters.Add("@SupplierWarranty", SqlDbType.Int).Value = supplierWarranty;
                //[001] end
                //[003] start
                cmd.Parameters.Add("@isTestingRecommended", SqlDbType.Bit).Value = isTestingRecommended;
                //[003] end
                cmd.Parameters.Add("@SourcingResultId", SqlDbType.Int).Direction = ParameterDirection.Output;

                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@SourcingResultId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert SourcingResult", sqlex);
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
