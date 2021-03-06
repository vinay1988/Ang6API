﻿//Marker     Changed by      Date         Remarks    
//[001]      Vinay           16/10/2012   Display supplier type in stock grid  
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
	public class SqlOfferProvider : OfferProvider {
		/// <summary>
		/// Delete Offer
		/// Calls [usp_delete_Offer]
		/// </summary>
		public override bool Delete(System.Int32? offerId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Offer", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@OfferId", SqlDbType.Int).Value = offerId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Offer", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		/// <summary>
		/// Create a new row
        /// Calls [usp_insert_OfferNew]
		/// </summary>
        public override Int32 Insert(System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? supplierNo, System.String supplierName, System.Byte? rohs, System.Int32? offerStatusNo, System.String notes, System.Int32? updatedBy, System.Int32? cleintNo, bool? isPoHub)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
            string proc = "usp_insert_OfferNew";
			try {
                proc = isPoHub == true ? "usp_insert_OfferNewPH" : proc;
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand(proc, cn);
				cmd.CommandType = CommandType.StoredProcedure;
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
				cmd.Parameters.Add("@SupplierNo", SqlDbType.Int).Value = supplierNo;
				cmd.Parameters.Add("@SupplierName", SqlDbType.NVarChar).Value = supplierName;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@OfferStatusNo", SqlDbType.Int).Value = offerStatusNo;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = cleintNo;                
				cmd.Parameters.Add("@OfferId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@OfferId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Offer", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}


        /// <summary>
        /// Create a new row
        /// Calls [usp_insert_OfferNew]
        /// </summary>
        public override Int32 IPOBOMInsert(System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? supplierNo, System.String supplierName, System.Byte? rohs, System.Int32? offerStatusNo, System.String notes, System.Int32? updatedBy, System.Int32? cleintNo, bool? isPoHub, System.String supplierTotalQSA, System.String supplierMOQ, System.String supplierLTB, System.String msl, System.String spq, System.String leadTime, System.String factorySealed, System.String rohsStatus, System.Int32? mslLevelNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            string proc = "usp_insert_IPOOffer";
            try
            {
                //proc = isPoHub == true ? "usp_ipobom_insert_OfferNewPH" : proc;
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand(proc, cn);
                cmd.CommandType = CommandType.StoredProcedure;
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
                cmd.Parameters.Add("@SupplierNo", SqlDbType.Int).Value = supplierNo;
                cmd.Parameters.Add("@SupplierName", SqlDbType.NVarChar).Value = supplierName;
                cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
                cmd.Parameters.Add("@OfferStatusNo", SqlDbType.Int).Value = offerStatusNo;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = cleintNo;
                cmd.Parameters.Add("@SupplierTotalQSA", SqlDbType.NVarChar).Value = supplierTotalQSA;
                cmd.Parameters.Add("@SupplierLTB", SqlDbType.NVarChar).Value = supplierLTB;
                cmd.Parameters.Add("@SupplierMOQ", SqlDbType.NVarChar).Value = supplierMOQ;
                cmd.Parameters.Add("@MSL", SqlDbType.NVarChar).Value = msl;
                cmd.Parameters.Add("@SPQ", SqlDbType.NVarChar).Value = spq;
                cmd.Parameters.Add("@LeadTime", SqlDbType.NVarChar).Value = leadTime;
                cmd.Parameters.Add("@FactorySealed", SqlDbType.NVarChar).Value = factorySealed;
                cmd.Parameters.Add("@ROHSStatus", SqlDbType.NVarChar).Value = rohsStatus;
                cmd.Parameters.Add("@IsPoHUB", SqlDbType.Bit).Value = isPoHub;
                cmd.Parameters.Add("@MSLLevelNo", SqlDbType.Int).Value = mslLevelNo;
                cmd.Parameters.Add("@OfferId", SqlDbType.Int).Direction = ParameterDirection.Output;
                
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@OfferId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Offer", sqlex);
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
        /// Calls [usp_offer_clone_AddToRequirement]
        /// </summary>
        public override Int32 CloneOfferAddToReq(System.Int32 offerId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.DateTime? originalEntryDate, System.Int32? salesman, System.Int32? supplierNo, System.String supplierName, System.Byte? rohs, System.Int32? offerStatusNo, System.String notes, System.Int32? updatedBy, System.Int32? cleintNo, bool? isPoHub, System.String supplierTotalQSA, System.String supplierMOQ, System.String supplierLTB, System.String msl, System.String spq, System.String leadTime, System.String factorySealed, System.String rohsStatus,System.Int32? customerRequirementNo,System.Int32? mslLevelNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            //string proc = "usp_insert_IPOOffer";
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_offer_clone_AddToRequirement", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OfferNo", SqlDbType.Int).Value = offerId;
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
                cmd.Parameters.Add("@SupplierNo", SqlDbType.Int).Value = supplierNo;
                cmd.Parameters.Add("@SupplierName", SqlDbType.NVarChar).Value = supplierName;
                cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
                cmd.Parameters.Add("@OfferStatusNo", SqlDbType.Int).Value = offerStatusNo;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = cleintNo;
                cmd.Parameters.Add("@SupplierTotalQSA", SqlDbType.NVarChar).Value = supplierTotalQSA;
                cmd.Parameters.Add("@SupplierLTB", SqlDbType.NVarChar).Value = supplierLTB;
                cmd.Parameters.Add("@SupplierMOQ", SqlDbType.NVarChar).Value = supplierMOQ;
                cmd.Parameters.Add("@MSL", SqlDbType.NVarChar).Value = msl;
                cmd.Parameters.Add("@SPQ", SqlDbType.NVarChar).Value = spq;
                cmd.Parameters.Add("@LeadTime", SqlDbType.NVarChar).Value = leadTime;
                cmd.Parameters.Add("@FactorySealed", SqlDbType.NVarChar).Value = factorySealed;
                cmd.Parameters.Add("@ROHSStatus", SqlDbType.NVarChar).Value = rohsStatus;
                cmd.Parameters.Add("@IsPoHUB", SqlDbType.Bit).Value = isPoHub;
                cmd.Parameters.Add("@CustomerRequirementNo", SqlDbType.Int).Value = customerRequirementNo;
                cmd.Parameters.Add("@MSLLevelNo", SqlDbType.Int).Value = mslLevelNo;
                cmd.Parameters.Add("@OfferId", SqlDbType.Int).Direction = ParameterDirection.Output;

                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@OfferId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Offer", sqlex);
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
		/// Calls [usp_select_Offer]
        /// </summary>
		public override OfferDetails Get(System.Int32? offerId,bool? isPoHub) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
            string proc = "usp_select_Offer";
			try {
                //proc = isPoHub == true ? "usp_select_OfferPH" : proc;
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand(proc, cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@OfferId", SqlDbType.Int).Value = offerId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetOfferFromReader(reader);
					OfferDetails obj = new OfferDetails();
					obj.OfferId = GetReaderValue_Int32(reader, "OfferId", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.OriginalEntryDate = GetReaderValue_NullableDateTime(reader, "OriginalEntryDate", null);
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SupplierNo = GetReaderValue_Int32(reader, "SupplierNo", 0);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.OfferStatusNo = GetReaderValue_NullableInt32(reader, "OfferStatusNo", null);
					obj.OfferStatusChangeDate = GetReaderValue_NullableDateTime(reader, "OfferStatusChangeDate", null);
					obj.OfferStatusChangeLoginNo = GetReaderValue_NullableInt32(reader, "OfferStatusChangeLoginNo", null);
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.SupplierTotalQSA = GetReaderValue_String(reader, "SupplierTotalQSA", "");
                    obj.SupplierLTB = GetReaderValue_String(reader, "SupplierLTB", "");
                    obj.SupplierMOQ = GetReaderValue_String(reader, "SupplierMOQ", "");
                    obj.MSL = GetReaderValue_String(reader, "MSL", "");
                    obj.SPQ = GetReaderValue_String(reader, "SPQ", "");
                    obj.LeadTime = GetReaderValue_String(reader, "LeadTime", "");
                    obj.FactorySealed = GetReaderValue_String(reader, "FactorySealed", "");
                    obj.RoHSStatus= GetReaderValue_String(reader, "ROHSStatus", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ProductInactive = GetReaderValue_NullableBoolean(reader, "ProductInactive", false);
                    obj.MSLLevelNo = GetReaderValue_Int32(reader, "MSLLevelNo", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Offer", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Source 
		/// Calls [usp_source_Offer]
        /// </summary>
        public override List<OfferDetails> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool hasServerLocal, System.Boolean? IsPOHub)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
            outDate = null;
			try {
                if (!hasServerLocal)
                    cn = new SqlConnection(this.GTConnectionString);
                else
                    cn = new SqlConnection(this.ConnectionString);

                cmd = new SqlCommand((IsPOHub.Value) ? "usp_source_OfferPH" : "usp_source_Offer", cn);
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
				List<OfferDetails> lst = new List<OfferDetails>();
				while (reader.Read()) {
					OfferDetails obj = new OfferDetails();
					obj.OfferId = GetReaderValue_Int32(reader, "OfferId", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.OriginalEntryDate = GetReaderValue_NullableDateTime(reader, "OriginalEntryDate", null);
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SupplierNo = GetReaderValue_Int32(reader, "SupplierNo", 0);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.OfferStatusNo = GetReaderValue_NullableInt32(reader, "OfferStatusNo", null);
					obj.OfferStatusChangeDate = GetReaderValue_NullableDateTime(reader, "OfferStatusChangeDate", null);
					obj.OfferStatusChangeLoginNo = GetReaderValue_NullableInt32(reader, "OfferStatusChangeLoginNo", null);
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.SupplierEmail = GetReaderValue_String(reader, "SupplierEmail", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.OfferStatusChangeEmployeeName = GetReaderValue_String(reader, "OfferStatusChangeEmployeeName", "");
					obj.ClientId = GetReaderValue_Int32(reader, "ClientId", 0);
					obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
					obj.ClientDataVisibleToOthers = GetReaderValue_NullableBoolean(reader, "ClientDataVisibleToOthers", null);
                    //[001] code start
                    obj.SupplierType = GetReaderValue_String(reader, "SupplierType", "");
                    //[001] code end
                    obj.ClientCode = GetReaderValue_String(reader, "ClientCode", "");
                    obj.IsSourcingHub = GetReaderValue_Boolean(reader, "ishub", false);
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
				throw new Exception("Failed to get Offers", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// Source 
        /// Calls [usp_source_Offer_PQ_Trusted]
        /// </summary>
        public override List<OfferDetails> SourceOfferAll(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool hasServerLocal)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            outDate = null;
            try
            {
                if (!hasServerLocal)
                    cn = new SqlConnection(this.GTConnectionString);
                else
                    cn = new SqlConnection(this.ConnectionString);

                cmd = new SqlCommand("usp_source_Offer_PQ_Trusted", cn);
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
                List<OfferDetails> lst = new List<OfferDetails>();
                while (reader.Read())
                {
                    OfferDetails obj = new OfferDetails();
                    obj.OfferId = GetReaderValue_Int32(reader, "SourcingResultId", 0);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.OriginalEntryDate = GetReaderValue_NullableDateTime(reader, "OriginalEntryDate", null);
                    obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
                    obj.SupplierNo = GetReaderValue_Int32(reader, "SupplierNo", 0);
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.OfferStatusNo = GetReaderValue_NullableInt32(reader, "OfferStatusNo", null);
                    obj.OfferStatusChangeDate = GetReaderValue_NullableDateTime(reader, "OfferStatusChangeDate", null);
                    obj.OfferStatusChangeLoginNo = GetReaderValue_NullableInt32(reader, "OfferStatusChangeLoginNo", null);
                    obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.SupplierEmail = GetReaderValue_String(reader, "SupplierEmail", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.OfferStatusChangeEmployeeName = GetReaderValue_String(reader, "OfferStatusChangeEmployeeName", "");
                    obj.ClientId = GetReaderValue_Int32(reader, "ClientId", 0);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.ClientDataVisibleToOthers = GetReaderValue_NullableBoolean(reader, "ClientDataVisibleToOthers", null);
                    //[001] code start
                    obj.SupplierType = GetReaderValue_String(reader, "SupplierType", "");
                    //[001] code end
                    obj.ClientCode = GetReaderValue_String(reader, "ClientCode", "");
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
                throw new Exception("Failed to get Offers", sqlex);
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
        /// Calls [[usp_ipobom_source_Offer]]
        /// 
        /// </summary>
        public override List<OfferDetails> IPOBOMSource(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool hasServerLocal,System.Boolean? isPOHub)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            outDate = null;
            try
            {
                if (!hasServerLocal)
                    cn = new SqlConnection(this.GTConnectionString);
                else
                    cn = new SqlConnection(this.ConnectionString);

                if (isPOHub.Value)
                    cmd = new SqlCommand("usp_IPOBOM_Source_OfferPH", cn);
                else
                    cmd = new SqlCommand("usp_ipobom_source_Offer", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
                cmd.Parameters.Add("@Index", SqlDbType.Int).Value = index;
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = startDate;
                cmd.Parameters.Add("@FinishDate", SqlDbType.DateTime).Value = endDate;
                cmd.Parameters.Add("@IsPoHUB", SqlDbType.Bit).Value = isPOHub;
                cn.Open();
                //DbDataReader reader = ExecuteReader(cmd);
                SqlDataReader reader = cmd.ExecuteReader();
                List<OfferDetails> lst = new List<OfferDetails>();
                while (reader.Read())
                {
                    OfferDetails obj = new OfferDetails();
                    obj.OfferId = GetReaderValue_Int32(reader, "OfferId", 0);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.OriginalEntryDate = GetReaderValue_NullableDateTime(reader, "OriginalEntryDate", null);
                    obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
                    obj.SupplierNo = GetReaderValue_Int32(reader, "SupplierNo", 0);
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.OfferStatusNo = GetReaderValue_NullableInt32(reader, "OfferStatusNo", null);
                    obj.OfferStatusChangeDate = GetReaderValue_NullableDateTime(reader, "OfferStatusChangeDate", null);
                    obj.OfferStatusChangeLoginNo = GetReaderValue_NullableInt32(reader, "OfferStatusChangeLoginNo", null);
                    obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.SupplierEmail = GetReaderValue_String(reader, "SupplierEmail", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.OfferStatusChangeEmployeeName = GetReaderValue_String(reader, "OfferStatusChangeEmployeeName", "");
                    obj.ClientId = GetReaderValue_Int32(reader, "ClientId", 0);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.ClientDataVisibleToOthers = GetReaderValue_NullableBoolean(reader, "ClientDataVisibleToOthers", null);
                    //[001] code start
                    obj.SupplierType = GetReaderValue_String(reader, "SupplierType", "");
                    //[001] code end
                    obj.ClientCode = GetReaderValue_String(reader, "ClientCode", "");

                    obj.MSL = GetReaderValue_String(reader, "MSL", "");
                    obj.SPQ = GetReaderValue_String(reader, "SPQ", "");
                    obj.LeadTime = GetReaderValue_String(reader, "LeadTime", "");
                    obj.RoHSStatus = GetReaderValue_String(reader, "RoHSStatus", "");
                    obj.FactorySealed = GetReaderValue_String(reader, "FactorySealed", "");
                    obj.IPOBOMNo = GetReaderValue_Int32(reader, "IPOBOMNo", 0);
                    obj.SupplierTotalQSA = GetReaderValue_String(reader, "SupplierTotalQSA", "");
                    obj.SupplierLTB = GetReaderValue_String(reader, "SupplierLTB", "");
                    obj.SupplierMOQ = GetReaderValue_String(reader, "SupplierMOQ", "");
                    obj.IsSourcingHub=  GetReaderValue_Boolean(reader, "ishub", false);
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
                throw new Exception("Failed to get Offers", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		
	
		
        /// <summary>
        /// Update Offer
		/// Calls [usp_update_Offer]
        /// </summary>
        public override bool Update(System.Int32? offerId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.Int32? salesman, System.Int32? offerStatusNo, System.Int32? supplierNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, bool? isPoHub)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
            string proc = "usp_update_Offer";
			try {
                proc = isPoHub == true ? "usp_update_OfferPH" : proc;
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand(proc, cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@OfferId", SqlDbType.Int).Value = offerId;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@OfferStatusNo", SqlDbType.Int).Value = offerStatusNo;
				cmd.Parameters.Add("@SupplierNo", SqlDbType.Int).Value = supplierNo;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                ////cmd.Parameters.Add("@SupplierTotalQSA", SqlDbType.NVarChar).Value = supplierTotalQSA;
                ////cmd.Parameters.Add("@SupplierLTB", SqlDbType.NVarChar).Value = supplierLTB;
                ////cmd.Parameters.Add("@SupplierMOQ", SqlDbType.NVarChar).Value = supplierMOQ;

                ////cmd.Parameters.Add("@MSL", SqlDbType.NVarChar).Value = MSL;
                ////cmd.Parameters.Add("@SPQ", SqlDbType.NVarChar).Value = SPQ;
                ////cmd.Parameters.Add("@LeadTime", SqlDbType.NVarChar).Value = leadTime;
                ////cmd.Parameters.Add("@FactorySealed", SqlDbType.NVarChar).Value = factorySealed;
                ////cmd.Parameters.Add("@ROHSStatus", SqlDbType.NVarChar).Value = rohsStatus;

				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Offer", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// Update Offer
        /// Calls [usp_ipobom_update_Offer]
        /// </summary>
        public override bool IPOBOMUpdate(System.Int32? offerId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? productNo, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Int32? currencyNo, System.Int32? salesman, System.Int32? offerStatusNo, System.Int32? supplierNo, System.Byte? rohs, System.String notes, System.Int32? updatedBy, bool? isPoHub, System.String supplierTotalQSA, System.String supplierMOQ, System.String supplierLTB, System.String MSL, System.String SPQ, System.String leadTime, System.String factorySealed, System.String rohsStatus, System.Int32? mslLevelNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            string proc = "usp_ipobom_update_Offer";
            try
            {
                //proc = isPoHub == true ? "usp_ipobom_update_OfferPH" : proc;
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand(proc, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OfferId", SqlDbType.Int).Value = offerId;
                cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
                cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
                cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
                cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
                cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
                cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
                cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
                cmd.Parameters.Add("@OfferStatusNo", SqlDbType.Int).Value = offerStatusNo;
                cmd.Parameters.Add("@SupplierNo", SqlDbType.Int).Value = supplierNo;
                cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@SupplierTotalQSA", SqlDbType.NVarChar).Value = supplierTotalQSA;
                cmd.Parameters.Add("@SupplierLTB", SqlDbType.NVarChar).Value = supplierLTB;
                cmd.Parameters.Add("@SupplierMOQ", SqlDbType.NVarChar).Value = supplierMOQ;

                cmd.Parameters.Add("@MSL", SqlDbType.NVarChar).Value = MSL;
                cmd.Parameters.Add("@SPQ", SqlDbType.NVarChar).Value = SPQ;
                cmd.Parameters.Add("@LeadTime", SqlDbType.NVarChar).Value = leadTime;
                cmd.Parameters.Add("@FactorySealed", SqlDbType.NVarChar).Value = factorySealed;
                cmd.Parameters.Add("@ROHSStatus", SqlDbType.NVarChar).Value = rohsStatus;
                cmd.Parameters.Add("@MSLLevelNo", SqlDbType.Int).Value = mslLevelNo;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Offer", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		
		
        /// <summary>
        /// Update Offer
		/// Calls [usp_update_Offer_for_sourcing]
        /// </summary>
        public override bool UpdateForSourcing(System.Int32? offerId, System.Int32? quantity, System.Double? price, System.String notes, System.Int32? updatedBy)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Offer_for_sourcing", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@OfferId", SqlDbType.Int).Value = offerId;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Offer", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Offer
		/// Calls [usp_update_Offer_OfferStatus]
        /// </summary>
		public override bool UpdateOfferStatus(System.Int32? offerNo, System.Int32? offerStatusNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Offer_OfferStatus", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@OfferNo", SqlDbType.Int).Value = offerNo;
				cmd.Parameters.Add("@OfferStatusNo", SqlDbType.Int).Value = offerStatusNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Offer", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}		
	}
}
