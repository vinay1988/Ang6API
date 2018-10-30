/* Marker     changed by      date         Remarks  
   [001]      Vikas kumar     22/11/2011  ESMS Ref:21 - Add Country search option in Purchase Order 
   [002]      Vinay           18/09/2012    Ref:## - Display Purchase Country
   [003]      Raushan         27/02/2014    Ref:## - Supplier RMA-ISCRMA
   [004]      Aashu           11/June/2018  Added code to print SO and so promise date
   [005]      Aashu Singh     25/06/2018    show supplier warranty for po line detail
   [006]      Aashu Singh     06-Aug-2018   REB-12084:Lock PO lines when EPR is authorised
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
	public class SqlPurchaseOrderLineProvider : PurchaseOrderLineProvider {
        /// <summary>
        /// DataListNugget 
		/// Calls [usp_datalistnugget_PurchaseOrderLine]
        /// </summary>
        //[001]Code Start
        public override List<PurchaseOrderLineDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.Int32? CountrySearch, System.Boolean? includeClosed, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? expediteDateFrom, System.DateTime? expediteDateTo, System.DateTime? deliveryDateFrom, System.DateTime? deliveryDateTo, System.Boolean? recentOnly, System.Int32? internalPurchaseOrderNoLo, System.Int32? internalPurchaseOrderNoHi, System.Int32? clientSearch, int? IsPoHub, System.Boolean? PohubOnly, Boolean IsGlobalLogin)
        {
        //[001]Code End
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_PurchaseOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@TeamId", SqlDbType.Int).Value = teamId;
				cmd.Parameters.Add("@DivisionId", SqlDbType.Int).Value = divisionId;
				cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@BuyerSearch", SqlDbType.Int).Value = buyerSearch;
                //[001]Code Start
                cmd.Parameters.Add("@CountrySearch", SqlDbType.Int).Value = CountrySearch;
                //[001]Code End
				cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
				cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
				cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
				cmd.Parameters.Add("@ExpediteDateFrom", SqlDbType.DateTime).Value = expediteDateFrom;
				cmd.Parameters.Add("@ExpediteDateTo", SqlDbType.DateTime).Value = expediteDateTo;
				cmd.Parameters.Add("@DeliveryDateFrom", SqlDbType.DateTime).Value = deliveryDateFrom;
				cmd.Parameters.Add("@DeliveryDateTo", SqlDbType.DateTime).Value = deliveryDateTo;
				cmd.Parameters.Add("@RecentOnly", SqlDbType.Bit).Value = recentOnly;
                cmd.Parameters.Add("@InternalPurchaseOrderNoLo", SqlDbType.Int).Value = internalPurchaseOrderNoLo;
                cmd.Parameters.Add("@InternalPurchaseOrderNoHi", SqlDbType.Int).Value = internalPurchaseOrderNoHi;
                cmd.Parameters.Add("@ClientSearch", SqlDbType.Int).Value = clientSearch;
                cmd.Parameters.Add("@IsPoHub", SqlDbType.Int).Value = IsPoHub??0;
                cmd.Parameters.Add("@PoHubOnly", SqlDbType.Bit).Value = PohubOnly;
                cmd.Parameters.Add("@IsGlobalLogin", SqlDbType.Bit).Value = IsGlobalLogin;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderLineDetails> lst = new List<PurchaseOrderLineDetails>();
				while (reader.Read()) {
					PurchaseOrderLineDetails obj = new PurchaseOrderLineDetails();
					obj.PurchaseOrderLineId = GetReaderValue_Int32(reader, "PurchaseOrderLineId", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.Status = GetReaderValue_NullableInt32(reader, "Status", null);
					obj.QuantityOutstanding = GetReaderValue_NullableInt32(reader, "QuantityOutstanding", null);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.InternalPurchaseOrderNo = GetReaderValue_Int32(reader, "InternalPurchaseOrderId", 0);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0);
                    obj.PoClientName = GetReaderValue_String(reader, "PoClientName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DataListNuggetAllForReceiving 
		/// Calls [usp_datalistnugget_PurchaseOrderLine_AllForReceiving]
        /// </summary>
        public override List<PurchaseOrderLineDetails> DataListNuggetAllForReceiving(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.Boolean? recentOnly, System.Boolean? includeClosed, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? expediteDateFrom, System.DateTime? expediteDateTo, System.DateTime? deliveryDateFrom, System.DateTime? deliveryDateTo, System.Int32? internalPurchaseOrderNoLo, System.Int32? internalPurchaseOrderNoHi, bool? isPoHub, System.Int32? clientNo, System.Boolean? globalUser)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_PurchaseOrderLine_AllForReceiving", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@BuyerSearch", SqlDbType.Int).Value = buyerSearch;
				cmd.Parameters.Add("@RecentOnly", SqlDbType.Bit).Value = recentOnly;
				cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
				cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
				cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
				cmd.Parameters.Add("@ExpediteDateFrom", SqlDbType.DateTime).Value = expediteDateFrom;
				cmd.Parameters.Add("@ExpediteDateTo", SqlDbType.DateTime).Value = expediteDateTo;
				cmd.Parameters.Add("@DeliveryDateFrom", SqlDbType.DateTime).Value = deliveryDateFrom;
				cmd.Parameters.Add("@DeliveryDateTo", SqlDbType.DateTime).Value = deliveryDateTo;
                cmd.Parameters.Add("@InternalPurchaseOrderNoLo", SqlDbType.Int).Value = internalPurchaseOrderNoLo;
				cmd.Parameters.Add("@InternalPurchaseOrderNoHi", SqlDbType.Int).Value = internalPurchaseOrderNoHi;
                cmd.Parameters.Add("@IsPoHub", SqlDbType.Bit).Value = isPoHub;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@IsGlobalLogin", SqlDbType.Bit).Value = globalUser;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderLineDetails> lst = new List<PurchaseOrderLineDetails>();
				while (reader.Read()) {
					PurchaseOrderLineDetails obj = new PurchaseOrderLineDetails();
					obj.PurchaseOrderLineId = GetReaderValue_Int32(reader, "PurchaseOrderLineId", 0);
					obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.QuantityOutstanding = GetReaderValue_NullableInt32(reader, "QuantityOutstanding", null);
					obj.EarliestShipDate = GetReaderValue_NullableDateTime(reader, "EarliestShipDate", null);
                    obj.InternalPurchaseOrderNo = GetReaderValue_Int32(reader, "InternalPurchaseOrderId", 0);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.PoClientName = GetReaderValue_String(reader, "PoClientName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DataListNuggetReadyToReceive 
		/// Calls [usp_datalistnugget_PurchaseOrderLine_ReadyToReceive]
        /// </summary>
        public override List<PurchaseOrderLineDetails> DataListNuggetReadyToReceive(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? expediteDateFrom, System.DateTime? expediteDateTo, System.DateTime? deliveryDateFrom, System.DateTime? deliveryDateTo, System.Int32? internalPurchaseOrderNoLo, System.Int32? internalPurchaseOrderNoHi, System.Int32? clientNo, System.Boolean? globalUser)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_PurchaseOrderLine_ReadyToReceive", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@BuyerSearch", SqlDbType.Int).Value = buyerSearch;
				cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
				cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
				cmd.Parameters.Add("@ExpediteDateFrom", SqlDbType.DateTime).Value = expediteDateFrom;
				cmd.Parameters.Add("@ExpediteDateTo", SqlDbType.DateTime).Value = expediteDateTo;
				cmd.Parameters.Add("@DeliveryDateFrom", SqlDbType.DateTime).Value = deliveryDateFrom;
				cmd.Parameters.Add("@DeliveryDateTo", SqlDbType.DateTime).Value = deliveryDateTo;
                cmd.Parameters.Add("@InternalPurchaseOrderNoLo", SqlDbType.Int).Value = internalPurchaseOrderNoLo;
                cmd.Parameters.Add("@InternalPurchaseOrderNoHi", SqlDbType.Int).Value = internalPurchaseOrderNoHi;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@IsGlobalLogin", SqlDbType.Bit).Value = globalUser;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderLineDetails> lst = new List<PurchaseOrderLineDetails>();
				while (reader.Read()) {
					PurchaseOrderLineDetails obj = new PurchaseOrderLineDetails();
					obj.PurchaseOrderLineId = GetReaderValue_Int32(reader, "PurchaseOrderLineId", 0);
					obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.QuantityOutstanding = GetReaderValue_NullableInt32(reader, "QuantityOutstanding", null);
					obj.EarliestShipDate = GetReaderValue_NullableDateTime(reader, "EarliestShipDate", null);
                    obj.InternalPurchaseOrderNo = GetReaderValue_Int32(reader, "InternalPurchaseOrderId", 0);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.PoClientName = GetReaderValue_String(reader, "PoClientName", "");

					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete PurchaseOrderLine
		/// Calls [usp_delete_PurchaseOrderLine]
		/// </summary>
		public override bool Delete(System.Int32? purchaseOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_PurchaseOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Value = purchaseOrderLineId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete PurchaseOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_PurchaseOrderLine]
		/// </summary>
        public override Int32 Insert(System.Int32? purchaseOrderNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.DateTime? deliveryDate, System.String receivingNotes, System.Boolean? taxable, System.Int32? productNo, System.Boolean? posted, System.Double? shipInCost, System.String supplierPart, System.Byte? rohs, System.String notes, System.DateTime? PromiseDate, System.Int32? updatedBy, System.Boolean? reqSerialNo, System.String mslLevel, System.Boolean? printHazardous)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_PurchaseOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@PurchaseOrderNo", SqlDbType.Int).Value = purchaseOrderNo;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = deliveryDate;
				cmd.Parameters.Add("@ReceivingNotes", SqlDbType.NVarChar).Value = receivingNotes;
				cmd.Parameters.Add("@Taxable", SqlDbType.Bit).Value = taxable;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@Posted", SqlDbType.Bit).Value = posted;
				cmd.Parameters.Add("@ShipInCost", SqlDbType.Float).Value = shipInCost;
				cmd.Parameters.Add("@SupplierPart", SqlDbType.NVarChar).Value = supplierPart;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                //
                cmd.Parameters.Add("@PromiseDate", SqlDbType.DateTime).Value = PromiseDate;
				//
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@ReqSerialNo", SqlDbType.Bit).Value = reqSerialNo;
                cmd.Parameters.Add("@MSLLevel", SqlDbType.NVarChar).Value = mslLevel;
                cmd.Parameters.Add("@PrintHazardous", SqlDbType.Bit).Value = printHazardous;
				cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@PurchaseOrderLineId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert PurchaseOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_PurchaseOrderLine_from_SalesOrderLine]
		/// </summary>
		public override Int32 InsertFromSalesOrderLine(System.Int32? salesOrderLineId, System.Int32? purchaseOrderNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_PurchaseOrderLine_from_SalesOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Value = salesOrderLineId;
				cmd.Parameters.Add("@PurchaseOrderNo", SqlDbType.Int).Value = purchaseOrderNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@PurchaseOrderLineId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert PurchaseOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// ItemSearch 
		/// Calls [usp_itemsearch_PurchaseOrderLine]
        /// </summary>
		public override List<PurchaseOrderLineDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Boolean? includeClosed, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? deliveryDateFrom, System.DateTime? deliveryDateTo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_itemsearch_PurchaseOrderLine", cn);
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
				cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
				cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
				cmd.Parameters.Add("@DeliveryDateFrom", SqlDbType.DateTime).Value = deliveryDateFrom;
				cmd.Parameters.Add("@DeliveryDateTo", SqlDbType.DateTime).Value = deliveryDateTo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderLineDetails> lst = new List<PurchaseOrderLineDetails>();
				while (reader.Read()) {
					PurchaseOrderLineDetails obj = new PurchaseOrderLineDetails();
					obj.PurchaseOrderLineId = GetReaderValue_Int32(reader, "PurchaseOrderLineId", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.PurchaseOrderValue = GetReaderValue_NullableDouble(reader, "PurchaseOrderValue", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_PurchaseOrderLine]
        /// </summary>
		public override PurchaseOrderLineDetails Get(System.Int32? purchaseOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_PurchaseOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Value = purchaseOrderLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetPurchaseOrderLineFromReader(reader);
					PurchaseOrderLineDetails obj = new PurchaseOrderLineDetails();
					obj.PurchaseOrderLineId = GetReaderValue_Int32(reader, "PurchaseOrderLineId", 0);
					obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
					obj.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", "");
					obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.QuantityReceived = GetReaderValue_Int32(reader, "QuantityReceived", 0);
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.GIShipInCost = GetReaderValue_Double(reader, "GIShipInCost", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    //[002] code start
                    obj.ImportCountryNo = GetReaderValue_NullableInt32(reader, "ImportCountryNo", null);
                    //[002 code end
                    //[003] code start
                    obj.PromiseDate = GetReaderValue_DateTime(reader, "PromiseDate", DateTime.MinValue);
                    //[003] code end
                    obj.PurchaseQuoteId = GetReaderValue_Int32(reader, "PurchaseQuoteId", 0);
                    obj.PurchaseQuoteNumber = GetReaderValue_Int32(reader, "PurchaseQuoteNumber", 0);
                    obj.PurchaseRequestDate = GetReaderValue_DateTime(reader, "PurchaseRequestDate", DateTime.MinValue);
                    obj.BomNo = GetReaderValue_NullableInt32(reader, "BomNo", 0);
                    obj.BOMName = GetReaderValue_String(reader, "BOMName", "");

                    obj.ClientPrice = GetReaderValue_Double(reader, "ClientPrice", 0);
                    obj.InternalPurchaseOrderNo = GetReaderValue_Int32(reader, "InternalPurchaseOrderId", 0);
                    obj.ClientCurrencyNo = GetReaderValue_Int32(reader, "ClientCurrencyNo", 0);
                    obj.ClientCurrencyCode = GetReaderValue_String(reader, "ClientCurrencyCode", "");
                    obj.ClientShipInCost = GetReaderValue_Double(reader, "ClientEstShipCost", 0);
                    obj.IPOClientNo = GetReaderValue_NullableInt32(reader, "IPOClientNo", null);
                    obj.DefaultClientLotNo = GetReaderValue_NullableInt32(reader, "DefaultClientLotNo", 0);
                    obj.ProductInactive = GetReaderValue_NullableBoolean(reader, "ProductInactive", false);
                    obj.DutyRate = GetReaderValue_NullableDouble(reader, "ProductDutyRate", null);
                    obj.ReqSerialNo = GetReaderValue_Boolean(reader, "ReqSerialNo", false);
                    obj.MSLevel = GetReaderValue_String(reader, "MSLLevel", "");
                    //[005] start
                    obj.SupplierWarranty = GetReaderValue_NullableInt32(reader, "SupplierWarranty", null);
                    //[005] end
                    //[006] start
                    obj.EPRIds = GetReaderValue_String(reader, "EPRIds", "");
                    obj.IsReleased = GetReaderValue_Boolean(reader, "IsReleased", false);
                    obj.IsAuthorised = GetReaderValue_Boolean(reader, "IsAuthorised", false);
                    //[006] end
                    obj.IsProdHazardous = GetReaderValue_NullableBoolean(reader, "IsProdHazardous", false);
                    obj.PrintHazardous = GetReaderValue_NullableBoolean(reader, "PrintHazardous", false);

                    return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForSupplierRMALine 
		/// Calls [usp_select_PurchaseOrderLine_for_SupplierRMALine]
        /// </summary>
		public override PurchaseOrderLineDetails GetForSupplierRMALine(System.Int32? purchaseOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_PurchaseOrderLine_for_SupplierRMALine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Value = purchaseOrderLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetPurchaseOrderLineFromReader(reader);
					PurchaseOrderLineDetails obj = new PurchaseOrderLineDetails();
					obj.PurchaseOrderLineId = GetReaderValue_Int32(reader, "PurchaseOrderLineId", 0);
					obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
					obj.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", "");
					obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.QuantityReceived = GetReaderValue_Int32(reader, "QuantityReceived", 0);
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.GIShipInCost = GetReaderValue_Double(reader, "GIShipInCost", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.QuantityToReturn = GetReaderValue_NullableInt32(reader, "QuantityToReturn", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListCandidatesForSupplierRMA 
		/// Calls [usp_selectAll_PurchaseOrderLine_candidates_for_SupplierRMA]
        /// </summary>
		public override List<PurchaseOrderLineDetails> GetListCandidatesForSupplierRMA(System.Int32? supplierRmaId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_PurchaseOrderLine_candidates_for_SupplierRMA", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SupplierRMAId", SqlDbType.Int).Value = supplierRmaId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderLineDetails> lst = new List<PurchaseOrderLineDetails>();
				while (reader.Read()) {
					PurchaseOrderLineDetails obj = new PurchaseOrderLineDetails();
					obj.PurchaseOrderLineId = GetReaderValue_Int32(reader, "PurchaseOrderLineId", 0);
					obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
					obj.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", "");
					obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.QuantityReceived = GetReaderValue_Int32(reader, "QuantityReceived", 0);
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.GIShipInCost = GetReaderValue_Double(reader, "GIShipInCost", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.QuantityToReturn = GetReaderValue_NullableInt32(reader, "QuantityToReturn", null);
                    obj.Location = GetReaderValue_String(reader, "Location", "");
                    obj.IsNprExist = GetReaderValue_Boolean(reader, "ISNPREXIST", false);
                    //[003]Code Start
                    obj.IsCRMA = GetReaderValue_Boolean(reader, "ISCRMA", false);
                    //[003]Code End

                    obj.POSerialNo = GetReaderValue_Int16(reader, "POSerialNo", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListClosedForPurchaseOrder 
		/// Calls [usp_selectAll_PurchaseOrderLine_closed_for_PurchaseOrder]
        /// </summary>
        public override List<PurchaseOrderLineDetails> GetListClosedForPurchaseOrder(System.Int32? purchaseOrderId)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_PurchaseOrderLine_closed_for_PurchaseOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
                
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderLineDetails> lst = new List<PurchaseOrderLineDetails>();
				while (reader.Read()) {
					PurchaseOrderLineDetails obj = new PurchaseOrderLineDetails();
					obj.PurchaseOrderLineId = GetReaderValue_Int32(reader, "PurchaseOrderLineId", 0);
					obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
					obj.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", "");
					obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.QuantityReceived = GetReaderValue_Int32(reader, "QuantityReceived", 0);
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.GIShipInCost = GetReaderValue_Double(reader, "GIShipInCost", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.POSerialNo = GetReaderValue_Int16(reader, "POSerialNo", 0);
                    obj.InternalPurchaseOrderNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderId", 0);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0);
                    //[006] start
                    obj.IsReleased = GetReaderValue_Boolean(reader, "IsReleased", false);
                    obj.IsAuthorised = GetReaderValue_Boolean(reader, "IsAuthorised", false);
                    //[006] end
                    
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForPurchaseOrder 
		/// Calls [usp_selectAll_PurchaseOrderLine_for_PurchaseOrder]
        /// </summary>
        public override List<PurchaseOrderLineDetails> GetListForPurchaseOrder(System.Int32? purchaseOrderId)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_PurchaseOrderLine_for_PurchaseOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
                
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderLineDetails> lst = new List<PurchaseOrderLineDetails>();
				while (reader.Read()) {
					PurchaseOrderLineDetails obj = new PurchaseOrderLineDetails();
					obj.PurchaseOrderLineId = GetReaderValue_Int32(reader, "PurchaseOrderLineId", 0);
					obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
					obj.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", "");
					obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.QuantityReceived = GetReaderValue_Int32(reader, "QuantityReceived", 0);
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.GIShipInCost = GetReaderValue_Double(reader, "GIShipInCost", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    //[003] code start
                    obj.PromiseDate = GetReaderValue_DateTime(reader, "PromiseDate", DateTime.MinValue);
                    //[003] code end
                    obj.POSerialNo = GetReaderValue_Int16(reader, "POSerialNo", 0);
                    obj.InternalPurchaseOrderNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderId", 0);
                    obj.ClientPrice = GetReaderValue_Double(reader, "ClientPrice", 0);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0);
                    obj.MSLevel = GetReaderValue_String(reader, "MSLLevel", "");
                    obj.PrintHazardous = GetReaderValue_NullableBoolean(reader, "PrintHazardous", false);
                    //[006] start
                    obj.IsReleased = GetReaderValue_Boolean(reader, "IsReleased", false);
                    obj.IsAuthorised = GetReaderValue_Boolean(reader, "IsAuthorised", false);
                    //[006] end
                    
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForSupplierRMA 
		/// Calls [usp_selectAll_PurchaseOrderLine_for_SupplierRMA]
        /// </summary>
		public override List<PurchaseOrderLineDetails> GetListForSupplierRMA(System.Int32? supplierRmaId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_PurchaseOrderLine_for_SupplierRMA", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SupplierRMAId", SqlDbType.Int).Value = supplierRmaId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderLineDetails> lst = new List<PurchaseOrderLineDetails>();
				while (reader.Read()) {
					PurchaseOrderLineDetails obj = new PurchaseOrderLineDetails();
					obj.PurchaseOrderLineId = GetReaderValue_Int32(reader, "PurchaseOrderLineId", 0);
					obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
					obj.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", "");
					obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.QuantityReceived = GetReaderValue_Int32(reader, "QuantityReceived", 0);
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.GIShipInCost = GetReaderValue_Double(reader, "GIShipInCost", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListOpenForPurchaseOrder 
		/// Calls [usp_selectAll_PurchaseOrderLine_open_for_PurchaseOrder]
        /// </summary>
        public override List<PurchaseOrderLineDetails> GetListOpenForPurchaseOrder(System.Int32? purchaseOrderId)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_PurchaseOrderLine_open_for_PurchaseOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
                
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderLineDetails> lst = new List<PurchaseOrderLineDetails>();
				while (reader.Read()) {
					PurchaseOrderLineDetails obj = new PurchaseOrderLineDetails();
					obj.PurchaseOrderLineId = GetReaderValue_Int32(reader, "PurchaseOrderLineId", 0);
					obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
					obj.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", "");
					obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.QuantityReceived = GetReaderValue_Int32(reader, "QuantityReceived", 0);
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.GIShipInCost = GetReaderValue_Double(reader, "GIShipInCost", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    //[003] code start
                    obj.PromiseDate = GetReaderValue_DateTime(reader, "PromiseDate", DateTime.MinValue);
                    //[003] code end
                    obj.POSerialNo = GetReaderValue_Int16(reader, "POSerialNo", 0);
                    obj.InternalPurchaseOrderNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderId", 0);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0);
                    //[006] start
                    obj.IsReleased = GetReaderValue_Boolean(reader, "IsReleased", false);
                    obj.IsAuthorised = GetReaderValue_Boolean(reader, "IsAuthorised", false);
                    //[006] end
                    
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListReceivingForPurchaseOrder 
		/// Calls [usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder]
        /// </summary>
		public override List<PurchaseOrderLineDetails> GetListReceivingForPurchaseOrder(System.Int32? purchaseOrderId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderLineDetails> lst = new List<PurchaseOrderLineDetails>();
				while (reader.Read()) {
					PurchaseOrderLineDetails obj = new PurchaseOrderLineDetails();
					obj.PurchaseOrderLineId = GetReaderValue_Int32(reader, "PurchaseOrderLineId", 0);
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
					obj.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
					obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.FullSupplierPart = GetReaderValue_String(reader, "FullSupplierPart", "");
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.QuantityOutstanding = GetReaderValue_NullableInt32(reader, "QuantityOutstanding", null);
					obj.PurchaseOrderValue = GetReaderValue_NullableDouble(reader, "PurchaseOrderValue", null);
					obj.QuantityReceived = GetReaderValue_Int32(reader, "QuantityReceived", 0);
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.ExpediteDate = GetReaderValue_NullableDateTime(reader, "ExpediteDate", null);
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.FullName = GetReaderValue_String(reader, "FullName", "");
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.Balance = GetReaderValue_NullableDouble(reader, "Balance", null);
					obj.LineValue = GetReaderValue_Double(reader, "LineValue", 0);
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.InAdvance = GetReaderValue_Boolean(reader, "InAdvance", false);
					obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
                    obj.InternalPurchaseOrderNo = (int)GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNo", 0);
                    obj.ClientPrice = GetReaderValue_Double(reader, "ClientPrice", 0);
                    obj.PromiseDate = GetReaderValue_DateTime(reader, "PromiseDate", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListTodayForClient 
		/// Calls [usp_selectAll_PurchaseOrderLine_today_for_Client]
        /// </summary>
		public override List<PurchaseOrderLineDetails> GetListTodayForClient(System.Int32? clientId,System.Int32? loginId, System.Int32? topToSelect) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_PurchaseOrderLine_today_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
                //cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderLineDetails> lst = new List<PurchaseOrderLineDetails>();
				while (reader.Read()) {
					PurchaseOrderLineDetails obj = new PurchaseOrderLineDetails();
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Source 
		/// Calls [usp_source_PurchaseOrderLine]
        /// </summary>
        public override List<PurchaseOrderLineDetails> Source(System.Int32? clientId, System.String partSearch, System.Int32? index, DateTime? startDate, DateTime? endDate, out DateTime? outDate, bool hasServerLocal, System.Boolean? isPoHub)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
            outDate = null;
			try {
                if (!hasServerLocal)
                {
                    cn = new SqlConnection(this.GTConnectionString);
                    cmd = new SqlCommand("usp_source_PurchaseOrderLine_Without_ClientId", cn);
                }
                else
                {
                    cn = new SqlConnection(this.ConnectionString);//usp_source_PurchaseOrderLineClient
                    cmd = isPoHub.Value == true ? new SqlCommand("usp_source_PurchaseOrderLine", cn) : new SqlCommand("usp_source_PurchaseOrderLineClient", cn);
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
				List<PurchaseOrderLineDetails> lst = new List<PurchaseOrderLineDetails>();
				while (reader.Read()) {
					PurchaseOrderLineDetails obj = new PurchaseOrderLineDetails();
					obj.PurchaseOrderLineId = GetReaderValue_Int32(reader, "PurchaseOrderLineId", 0);
					obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
					obj.ClientDataVisibleToOthers = GetReaderValue_NullableBoolean(reader, "ClientDataVisibleToOthers", null);
                    obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
                    obj.BuyerName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.blnSRMA = GetReaderValue_NullableBoolean(reader, "IsSRMA", false);
                    obj.ClientCode = GetReaderValue_String(reader, "ClientCode", "");
                    obj.InternalPurchaseOrderNumber = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0);
                    obj.InternalPurchaseOrderNo = GetReaderValue_Int32(reader, "InternalPurchaseOrderId", 0);
                    obj.IPOClientNo = GetReaderValue_Int32(reader, "IPOClientNo", 0);
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
				throw new Exception("Failed to get PurchaseOrderLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update PurchaseOrderLine
		/// Calls [usp_update_PurchaseOrderLine]
        /// </summary>
        public override bool Update(System.Int32? purchaseOrderLineId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.DateTime? deliveryDate, System.String receivingNotes, System.Boolean? taxable, System.Int32? productNo, System.Double? shipInCost, System.String supplierPart, System.Boolean? inactive, System.Byte? rohs, System.String notes, System.DateTime? PromiseDate, System.Int32? updatedBy, System.Boolean? ReqSerialNo, System.String msLevel, System.Boolean? printHazardous)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_PurchaseOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Value = purchaseOrderLineId;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@DeliveryDate", SqlDbType.DateTime).Value = deliveryDate;
				cmd.Parameters.Add("@ReceivingNotes", SqlDbType.NVarChar).Value = receivingNotes;
				cmd.Parameters.Add("@Taxable", SqlDbType.Bit).Value = taxable;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@ShipInCost", SqlDbType.Float).Value = shipInCost;
				cmd.Parameters.Add("@SupplierPart", SqlDbType.NVarChar).Value = supplierPart;
				cmd.Parameters.Add("@Inactive", SqlDbType.Bit).Value = inactive;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //
                cmd.Parameters.Add("@PromiseDate", SqlDbType.DateTime).Value = PromiseDate;
                cmd.Parameters.Add("@ReqSerialNo", SqlDbType.Bit).Value = ReqSerialNo;
                cmd.Parameters.Add("@MSLLevel", SqlDbType.NVarChar).Value = msLevel;
                cmd.Parameters.Add("@PrintHazardous", SqlDbType.Bit).Value = printHazardous;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update PurchaseOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update PurchaseOrderLine
		/// Calls [usp_update_PurchaseOrderLine_Close]
        /// </summary>
		public override bool UpdateClose(System.Int32? purchaseOrderLineId, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_PurchaseOrderLine_Close", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Value = purchaseOrderLineId;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update PurchaseOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update PurchaseOrderLine
		/// Calls [usp_update_PurchaseOrderLine_Closed_Status]
        /// </summary>
		public override bool UpdateClosedStatus(System.Int32? purchaseOrderLineNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_PurchaseOrderLine_Closed_Status", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@PurchaseOrderLineNo", SqlDbType.Int).Value = purchaseOrderLineNo;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update PurchaseOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update PurchaseOrderLine
		/// Calls [usp_update_PurchaseOrderLine_Post_or_Unpost]
        /// </summary>
		public override bool UpdatePostOrUnpost(System.Int32? purchaseOrderLineId, System.Boolean? posted, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_PurchaseOrderLine_Post_or_Unpost", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Value = purchaseOrderLineId;
				cmd.Parameters.Add("@Posted", SqlDbType.Bit).Value = posted;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update PurchaseOrderLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}


        /// <summary>
        /// GetListForPurchaseOrder 
        /// Calls [usp_selectAll_PurchaseOrderLine_for_PurchaseOrderReport]
        /// </summary>
        public override List<PurchaseOrderLineDetails> GetListForPurchaseOrderReport(System.Int32? purchaseOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_PurchaseOrderLine_for_PurchaseOrderReport", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PurchaseOrderLineDetails> lst = new List<PurchaseOrderLineDetails>();
                while (reader.Read())
                {
                    PurchaseOrderLineDetails obj = new PurchaseOrderLineDetails();
                    obj.PurchaseOrderLineId = GetReaderValue_Int32(reader, "PurchaseOrderLineId", 0);
                    obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
                    obj.ReceivingNotes = GetReaderValue_String(reader, "ReceivingNotes", "");
                    obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.Posted = GetReaderValue_Boolean(reader, "Posted", false);
                    obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.QuantityReceived = GetReaderValue_Int32(reader, "QuantityReceived", 0);
                    obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
                    obj.GIShipInCost = GetReaderValue_Double(reader, "GIShipInCost", 0);
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    //[003] code start
                    obj.PromiseDate = GetReaderValue_DateTime(reader, "PromiseDate", DateTime.MinValue);
                    //[003] code end
                    obj.POSerialNo = GetReaderValue_Int16(reader, "POSerialNo", 0);
                    obj.InternalPurchaseOrderNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderId", 0);
                    obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.ClientPrice = GetReaderValue_Double(reader, "ClientPrice", 0);
                    obj.CTName = GetReaderValue_String(reader, "CTName", "");//CTName->Company Type Name
                    obj.SOPrice = GetReaderValue_Double(reader, "SOPrice", 0);
                    obj.SOCurrencyCode = GetReaderValue_String(reader, "SOCurrencyCode", "");
                    obj.SOCurrencyNo = GetReaderValue_Int32(reader, "SOCurrencyNo", 0);
                    obj.SODateOrdered = GetReaderValue_DateTime(reader, "SODateOrdered", DateTime.MinValue);
                    obj.ClientCurrencyNo = GetReaderValue_Int32(reader, "ClientCurrencyNo", 0);
                    obj.ClientCurrencyCode = GetReaderValue_String(reader, "IPOCurrencyCode", "");
                    obj.HubCurrencyNo = GetReaderValue_Int32(reader, "HubCurrencyNo", 0);
                    obj.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null);
                    //[004] start
                    obj.SONumberDetail = GetReaderValue_String(reader, "SONumberDetail", "");
                    //[004] end
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get PurchaseOrderLines", sqlex);
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
        /// Calls [usp_Validate_PurchaseOrderLine_Receiving]
        /// </summary>
        public override PurchaseOrderLineDetails ValidatePOLineReceiving(System.Int32? purchaseOrderLineId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_Validate_PurchaseOrderLine_Receiving", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@PurchaseOrderLineNo", SqlDbType.Int).Value = purchaseOrderLineId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetPurchaseOrderLineFromReader(reader);
                    PurchaseOrderLineDetails obj = new PurchaseOrderLineDetails();
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    //obj.QuantityReceived = GetReaderValue_Int32(reader, "QuantityReceived", 0);
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
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
                throw new Exception("Failed to get PurchaseOrderLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Calls [usp_Get_IPO_For_ExpediteNotes]
        /// </summary>
        public override List<PurchaseOrderLineDetails> GetListIPOMessage(System.String poLineIds)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_Get_IPO_For_ExpediteNotes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@POLineNos", SqlDbType.NVarChar).Value = poLineIds;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PurchaseOrderLineDetails> lst = new List<PurchaseOrderLineDetails>();
                while (reader.Read())
                {
                    PurchaseOrderLineDetails obj = new PurchaseOrderLineDetails();

                    obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
                    obj.POSerialNo = GetReaderValue_Int16(reader, "POSerialNo", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.InternalPurchaseOrderNumber = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0);
                    obj.InternalPurchaseOrderNo = GetReaderValue_Int32(reader, "InternalPurchaseOrderId", 0);
                    obj.IPOBuyer = GetReaderValue_Int32(reader, "IPOBuyerNo", 0);
                    obj.IPOBuyerName = GetReaderValue_String(reader, "IPOBuyerName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.MailGroupId = GetReaderValue_Int32(reader, "MailGroupId", 0);
                    obj.Buyer = GetReaderValue_Int32(reader, "POBuyerNo", 0);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
                    //obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    //obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    ////It come from tbsourcing restlt of buyer column
                    
                    ////It come from tbsalesorder restlt of salesman column
                    //obj.IPOBuyer = GetReaderValue_Int32(reader, "Salesman", 0);
                    


                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {

                throw new Exception("Failed to get Company", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[006] start
        //usp_Release_UnRelease_POLines
        public override Int32 Release_POLines(string poLineIDs, int updatedBy,out string message)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                message="";
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_Release_POLines", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PurchaseOrderLineIds", SqlDbType.VarChar, 8000).Value = poLineIDs;
                //cmd.Parameters.Add("@ActionType", SqlDbType.VarChar,20).Value = strActionType;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@Message", SqlDbType.VarChar, 200);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cn.Open();
                int result = ExecuteNonQuery(cmd);
                if (result > 0)
                {
                    message = cmd.Parameters["@Message"].Value.ToString();
                }
                return result;
                
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert PurchaseOrderLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[006] end
		
	}
}
