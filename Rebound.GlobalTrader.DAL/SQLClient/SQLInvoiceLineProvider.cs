//Marker     Changed by      Date         Remarks
//[0001]      Abhinav         11/03/2014   ESMS#:- 103
//[002]      Vinay           20/11/2014   Transfer SO serial no to invoice
//[003]      Aashu Singh     18/06/2018   [REB-12150]: Traceable, Trusted, Non-preferred - to be printed on the package slip
//[004]      Aashu Singh     10/07/2018   [REB-12593]: Show contract number under notes column.
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
	public class SqlInvoiceLineProvider : InvoiceLineProvider {
        //[001] code start
        /// <summary>
        /// DataListNugget 
		/// Calls [usp_datalistnugget_InvoiceLine]
        /// </summary>
        public override List<InvoiceLineDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String customerPoSearch, System.Boolean? includePaid, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? invoiceDateFrom, System.DateTime? invoiceDateTo, System.Boolean? recentOnly, System.String airWayBill, Boolean IsGlobalLogin, System.Int32? clientSearchId)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_InvoiceLine", cn);
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
				cmd.Parameters.Add("@SalesmanSearch", SqlDbType.Int).Value = salesmanSearch;
				cmd.Parameters.Add("@CustomerPOSearch", SqlDbType.NVarChar).Value = customerPoSearch;
				cmd.Parameters.Add("@IncludePaid", SqlDbType.Bit).Value = includePaid;
				cmd.Parameters.Add("@InvoiceNoLo", SqlDbType.Int).Value = invoiceNoLo;
				cmd.Parameters.Add("@InvoiceNoHi", SqlDbType.Int).Value = invoiceNoHi;
				cmd.Parameters.Add("@SalesOrderNoLo", SqlDbType.Int).Value = salesOrderNoLo;
				cmd.Parameters.Add("@SalesOrderNoHi", SqlDbType.Int).Value = salesOrderNoHi;
				cmd.Parameters.Add("@InvoiceDateFrom", SqlDbType.DateTime).Value = invoiceDateFrom;
				cmd.Parameters.Add("@InvoiceDateTo", SqlDbType.DateTime).Value = invoiceDateTo;
				cmd.Parameters.Add("@RecentOnly", SqlDbType.Bit).Value = recentOnly;
                cmd.Parameters.Add("@AirWayBill", SqlDbType.NVarChar).Value = airWayBill;
                cmd.Parameters.Add("@IsGlobalLogin", SqlDbType.Bit).Value = IsGlobalLogin;
                cmd.Parameters.Add("@ClientSearchId", SqlDbType.Int).Value = clientSearchId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<InvoiceLineDetails> lst = new List<InvoiceLineDetails>();
				while (reader.Read()) {
					InvoiceLineDetails obj = new InvoiceLineDetails();
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.InvoiceId = GetReaderValue_Int32(reader, "InvoiceId", 0);
					obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get InvoiceLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
        //[001] code end	
		
		/// <summary>
		/// Delete InvoiceLine
		/// Calls [usp_delete_InvoiceLine]
		/// </summary>
        /// Ref:68 Stock log Error
        public override bool Delete(System.Int32? invoiceLineId, System.Int32? updatedBy)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_InvoiceLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@InvoiceLineId", SqlDbType.Int).Value = invoiceLineId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete InvoiceLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_InvoiceLine_by_Shipping_SO_Line]
		/// </summary>
		//[0001] start
        public override Int32 InsertByShippingSOLine(System.Int32? invoiceNo, System.Int32? salesOrderLineNo, System.Int32? allocationNo, System.Int32? quantityShipped, System.Int32? shippedBy, System.DateTime? shippedDate, System.Int32? updatedBy, System.String fullPart, System.String part, System.String dateCode, System.Byte? rohs, System.Int32? manufacturerNo, System.Int32? packageNo, System.Int32? productNo, System.String taxable, System.Int32? quantity, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.Int32? salesOrderNo, System.Int32? serviceNo, System.Int32? stockNo, System.String instructions, System.String customerPart, System.String notes, System.Boolean shipASAP) {
			//[0001] end
            SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_InvoiceLine_by_Shipping_SO_Line", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@InvoiceNo", SqlDbType.Int).Value = invoiceNo;
				cmd.Parameters.Add("@SalesOrderLineNo", SqlDbType.Int).Value = salesOrderLineNo;
				cmd.Parameters.Add("@AllocationNo", SqlDbType.Int).Value = allocationNo;
				cmd.Parameters.Add("@QuantityShipped", SqlDbType.Int).Value = quantityShipped;
				cmd.Parameters.Add("@ShippedBy", SqlDbType.Int).Value = shippedBy;
				cmd.Parameters.Add("@ShippedDate", SqlDbType.DateTime).Value = shippedDate;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@FullPart", SqlDbType.NVarChar).Value = fullPart;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@Taxable", SqlDbType.NVarChar).Value = taxable;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@DatePromised", SqlDbType.DateTime).Value = datePromised;
				cmd.Parameters.Add("@RequiredDate", SqlDbType.DateTime).Value = requiredDate;
				cmd.Parameters.Add("@SalesOrderNo", SqlDbType.Int).Value = salesOrderNo;
				cmd.Parameters.Add("@ServiceNo", SqlDbType.Int).Value = serviceNo;
				cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
				cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
				cmd.Parameters.Add("@CustomerPart", SqlDbType.NVarChar).Value = customerPart;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                //[0001] start
                cmd.Parameters.Add("@ShipASAP", SqlDbType.NVarChar).Value = shipASAP ;
                //[0001] end
                cmd.Parameters.Add("@InvoiceLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@InvoiceLineId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert InvoiceLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_InvoiceLine_by_Shipping_SRMALine]
		/// </summary>
		public override Int32 InsertByShippingSRMALine(System.Int32? invoiceNo, System.Int32? srmaLineNo, System.Int32? allocationNo, System.Int32? quantityShipped, System.Int32? shippedBy, System.DateTime? shippedDate, System.Int32? updatedBy, System.String fullPart, System.String part, System.String dateCode, System.Byte? rohs, System.Int32? manufacturerNo, System.Int32? packageNo, System.Int32? productNo, System.String taxable, System.Int32? quantity, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.Int32? salesOrderNo, System.Int32? serviceNo, System.Int32? stockNo, System.String instructions, System.String customerPart) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_InvoiceLine_by_Shipping_SRMALine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@InvoiceNo", SqlDbType.Int).Value = invoiceNo;
				cmd.Parameters.Add("@SRMALineNo", SqlDbType.Int).Value = srmaLineNo;
				cmd.Parameters.Add("@AllocationNo", SqlDbType.Int).Value = allocationNo;
				cmd.Parameters.Add("@QuantityShipped", SqlDbType.Int).Value = quantityShipped;
				cmd.Parameters.Add("@ShippedBy", SqlDbType.Int).Value = shippedBy;
				cmd.Parameters.Add("@ShippedDate", SqlDbType.DateTime).Value = shippedDate;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@FullPart", SqlDbType.NVarChar).Value = fullPart;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@Taxable", SqlDbType.NVarChar).Value = taxable;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@DatePromised", SqlDbType.DateTime).Value = datePromised;
				cmd.Parameters.Add("@RequiredDate", SqlDbType.DateTime).Value = requiredDate;
				cmd.Parameters.Add("@SalesOrderNo", SqlDbType.Int).Value = salesOrderNo;
				cmd.Parameters.Add("@ServiceNo", SqlDbType.Int).Value = serviceNo;
				cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
				cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
				cmd.Parameters.Add("@CustomerPart", SqlDbType.NVarChar).Value = customerPart;
				cmd.Parameters.Add("@InvoiceLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@InvoiceLineId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert InvoiceLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_InvoiceLine_for_Manual]
		/// </summary>
        public override Int32 InsertForManual(System.Int32? invoiceNo, System.Int32? salesOrderLineNo, System.Int32? shippedBy, System.DateTime? shippedDate, System.String notes, System.Int32? updatedBy, System.String fullPart, System.String part, System.String dateCode, System.Byte? rohs, System.Int32? manufacturerNo, System.Int32? packageNo, System.Int32? productNo, System.String taxable, System.Int32? quantity, System.Double? cost, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.Int32? salesOrderNo, System.Int32? serviceNo, System.Int32? stockNo, System.String instructions, System.String customerPart, System.Boolean? printHazardous)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_InvoiceLine_for_Manual", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@InvoiceNo", SqlDbType.Int).Value = invoiceNo;
				cmd.Parameters.Add("@SalesOrderLineNo", SqlDbType.Int).Value = salesOrderLineNo;
				cmd.Parameters.Add("@ShippedBy", SqlDbType.Int).Value = shippedBy;
				cmd.Parameters.Add("@ShippedDate", SqlDbType.DateTime).Value = shippedDate;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@FullPart", SqlDbType.NVarChar).Value = fullPart;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@Taxable", SqlDbType.NVarChar).Value = taxable;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Cost", SqlDbType.Float).Value = cost;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@DatePromised", SqlDbType.DateTime).Value = datePromised;
				cmd.Parameters.Add("@RequiredDate", SqlDbType.DateTime).Value = requiredDate;
				cmd.Parameters.Add("@SalesOrderNo", SqlDbType.Int).Value = salesOrderNo;
				cmd.Parameters.Add("@ServiceNo", SqlDbType.Int).Value = serviceNo;
				cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
				cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
				cmd.Parameters.Add("@CustomerPart", SqlDbType.NVarChar).Value = customerPart;
                cmd.Parameters.Add("@PrintHazardous", SqlDbType.Bit).Value = printHazardous;
				cmd.Parameters.Add("@InvoiceLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmd.Parameters.Add("@InvoiceLineAllocationId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@InvoiceLineId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert InvoiceLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_InvoiceLine_for_Service]
		/// </summary>
        public override Int32 InsertForService(System.Int32? invoiceNo, System.Int32? salesOrderLineNo, System.Int32? shippedBy, System.DateTime? shippedDate, System.String notes, System.Int32? updatedBy, System.String fullPart, System.String part, System.String dateCode, System.Byte? rohs, System.Int32? manufacturerNo, System.Int32? packageNo, System.Int32? productNo, System.String taxable, System.Int32? quantity, System.Double? cost, System.Double? price, System.DateTime? datePromised, System.DateTime? requiredDate, System.Int32? salesOrderNo, System.Int32? serviceNo, System.Int32? stockNo, System.String instructions, System.String customerPart, System.Boolean? printHazardous)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_InvoiceLine_for_Service", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@InvoiceNo", SqlDbType.Int).Value = invoiceNo;
				cmd.Parameters.Add("@SalesOrderLineNo", SqlDbType.Int).Value = salesOrderLineNo;
				cmd.Parameters.Add("@ShippedBy", SqlDbType.Int).Value = shippedBy;
				cmd.Parameters.Add("@ShippedDate", SqlDbType.DateTime).Value = shippedDate;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@FullPart", SqlDbType.NVarChar).Value = fullPart;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@Taxable", SqlDbType.NVarChar).Value = taxable;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Cost", SqlDbType.Float).Value = cost;
				cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
				cmd.Parameters.Add("@DatePromised", SqlDbType.DateTime).Value = datePromised;
				cmd.Parameters.Add("@RequiredDate", SqlDbType.DateTime).Value = requiredDate;
				cmd.Parameters.Add("@SalesOrderNo", SqlDbType.Int).Value = salesOrderNo;
				cmd.Parameters.Add("@ServiceNo", SqlDbType.Int).Value = serviceNo;
				cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
				cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
				cmd.Parameters.Add("@CustomerPart", SqlDbType.NVarChar).Value = customerPart;
                cmd.Parameters.Add("@PrintHazardous", SqlDbType.Bit).Value = printHazardous;
				cmd.Parameters.Add("@InvoiceLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cmd.Parameters.Add("@InvoiceLineAllocationId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@InvoiceLineId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert InvoiceLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// ItemSearch 
		/// Calls [usp_itemsearch_InvoiceLine]
        /// </summary>
		public override List<InvoiceLineDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String customerPoSearch, System.Boolean? includePaid, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? invoiceDateFrom, System.DateTime? invoiceDateTo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_itemsearch_InvoiceLine", cn);
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
				cmd.Parameters.Add("@SalesmanSearch", SqlDbType.Int).Value = salesmanSearch;
				cmd.Parameters.Add("@CustomerPOSearch", SqlDbType.NVarChar).Value = customerPoSearch;
				cmd.Parameters.Add("@IncludePaid", SqlDbType.Bit).Value = includePaid;
				cmd.Parameters.Add("@InvoiceNoLo", SqlDbType.Int).Value = invoiceNoLo;
				cmd.Parameters.Add("@InvoiceNoHi", SqlDbType.Int).Value = invoiceNoHi;
				cmd.Parameters.Add("@SalesOrderNoLo", SqlDbType.Int).Value = salesOrderNoLo;
				cmd.Parameters.Add("@SalesOrderNoHi", SqlDbType.Int).Value = salesOrderNoHi;
				cmd.Parameters.Add("@InvoiceDateFrom", SqlDbType.DateTime).Value = invoiceDateFrom;
				cmd.Parameters.Add("@InvoiceDateTo", SqlDbType.DateTime).Value = invoiceDateTo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<InvoiceLineDetails> lst = new List<InvoiceLineDetails>();
				while (reader.Read()) {
					InvoiceLineDetails obj = new InvoiceLineDetails();
					obj.InvoiceLineId = GetReaderValue_Int32(reader, "InvoiceLineId", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get InvoiceLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_InvoiceLine]
        /// </summary>
		public override InvoiceLineDetails Get(System.Int32? invoiceLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_InvoiceLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@InvoiceLineId", SqlDbType.Int).Value = invoiceLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetInvoiceLineFromReader(reader);
					InvoiceLineDetails obj = new InvoiceLineDetails();
					obj.InvoiceLineId = GetReaderValue_Int32(reader, "InvoiceLineId", 0);
					obj.InvoiceNo = GetReaderValue_Int32(reader, "InvoiceNo", 0);
					obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
					obj.ShippedBy = GetReaderValue_NullableInt32(reader, "ShippedBy", null);
					obj.ShippedDate = GetReaderValue_NullableDateTime(reader, "ShippedDate", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.DateOrdered = GetReaderValue_NullableDateTime(reader, "DateOrdered", null);
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null);
					obj.SupplierRMADate = GetReaderValue_NullableDateTime(reader, "SupplierRMADate", null);
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.InvoicePaid = GetReaderValue_Boolean(reader, "InvoicePaid", false);
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.LineSource = GetReaderValue_String(reader, "LineSource", "");
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.ShippedByName = GetReaderValue_String(reader, "ShippedByName", "");
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    //[0001] start
                    obj.ShipASAP = GetReaderValue_Boolean(reader, "ShipASAP", false);
                    //[0001] end
                    obj.ProductDutyRate = GetReaderValue_NullableDouble(reader, "ProductDutyRate", null);
                    obj.MSLLevel = GetReaderValue_String(reader, "MSLLevel", "");
                    obj.IsProdHazardous = GetReaderValue_NullableBoolean(reader, "IsProdHazardous", false);
                    obj.PrintHazardous = GetReaderValue_NullableBoolean(reader, "PrintHazardous", false);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get InvoiceLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListCandidatesForCustomerRMA 
		/// Calls [usp_selectAll_InvoiceLine_candidates_for_CustomerRMA]
        /// </summary>
		public override List<InvoiceLineDetails> GetListCandidatesForCustomerRMA(System.Int32? customerRmaId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_InvoiceLine_candidates_for_CustomerRMA", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CustomerRMAId", SqlDbType.Int).Value = customerRmaId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<InvoiceLineDetails> lst = new List<InvoiceLineDetails>();
				while (reader.Read()) {
					InvoiceLineDetails obj = new InvoiceLineDetails();
					obj.InvoiceLineId = GetReaderValue_Int32(reader, "InvoiceLineId", 0);
					obj.InvoiceNo = GetReaderValue_Int32(reader, "InvoiceNo", 0);
					obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
					obj.ShippedBy = GetReaderValue_NullableInt32(reader, "ShippedBy", null);
					obj.ShippedDate = GetReaderValue_NullableDateTime(reader, "ShippedDate", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.DateOrdered = GetReaderValue_NullableDateTime(reader, "DateOrdered", null);
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null);
					obj.SupplierRMADate = GetReaderValue_NullableDateTime(reader, "SupplierRMADate", null);
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.InvoicePaid = GetReaderValue_Boolean(reader, "InvoicePaid", false);
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.LineSource = GetReaderValue_String(reader, "LineSource", "");
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.ShippedByName = GetReaderValue_String(reader, "ShippedByName", "");
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get InvoiceLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForInvoice 
		/// Calls [usp_selectAll_InvoiceLine_for_Invoice]
        /// </summary>
		public override List<InvoiceLineDetails> GetListForInvoice(System.Int32? invoiceId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_InvoiceLine_for_Invoice", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = invoiceId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<InvoiceLineDetails> lst = new List<InvoiceLineDetails>();
				while (reader.Read()) {
					InvoiceLineDetails obj = new InvoiceLineDetails();
					obj.InvoiceLineId = GetReaderValue_Int32(reader, "InvoiceLineId", 0);
					obj.InvoiceNo = GetReaderValue_Int32(reader, "InvoiceNo", 0);
					obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
					obj.ShippedBy = GetReaderValue_NullableInt32(reader, "ShippedBy", null);
					obj.ShippedDate = GetReaderValue_NullableDateTime(reader, "ShippedDate", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.DateOrdered = GetReaderValue_NullableDateTime(reader, "DateOrdered", null);
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null);
					obj.SupplierRMADate = GetReaderValue_NullableDateTime(reader, "SupplierRMADate", null);
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.InvoicePaid = GetReaderValue_Boolean(reader, "InvoicePaid", false);
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.LineSource = GetReaderValue_String(reader, "LineSource", "");
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.ShippedByName = GetReaderValue_String(reader, "ShippedByName", "");
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", "");
                    //[002] code start
                    obj.SOSerialNo = GetReaderValue_Int16(reader, "SOSerialNo", 0);
                    //[002] code end
                    //[003] code start
                    obj.BatchReference = GetReaderValue_String(reader, "BatchReference", "");
                    // code end
                    obj.SerialLineNos = GetReaderValue_String(reader, "SerialLineNos", "");
                    obj.MSLLevel = GetReaderValue_String(reader, "MSLLevel", "");
                    //[003] start
                    obj.AS9120 = GetReaderValue_NullableBoolean(reader, "AS9120", null);
                    obj.ProductSource = GetReaderValue_NullableByte(reader, "ProductSource", null);
                    //[003] end
                    //[004] start
                    obj.ContractNo = GetReaderValue_String(reader, "ContractNo", "");
                    //[004] end
                    obj.PrintHazardous = GetReaderValue_Boolean(reader, "PrintHazardous", false);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get InvoiceLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForSalesOrder 
		/// Calls [usp_selectAll_InvoiceLine_for_SalesOrder]
        /// </summary>
		public override List<InvoiceLineDetails> GetListForSalesOrder(System.Int32? salesOrderId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_InvoiceLine_for_SalesOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<InvoiceLineDetails> lst = new List<InvoiceLineDetails>();
				while (reader.Read()) {
					InvoiceLineDetails obj = new InvoiceLineDetails();
					obj.InvoiceLineId = GetReaderValue_Int32(reader, "InvoiceLineId", 0);
					obj.InvoiceNo = GetReaderValue_Int32(reader, "InvoiceNo", 0);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.ShippedByName = GetReaderValue_String(reader, "ShippedByName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get InvoiceLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForSalesOrderLine 
		/// Calls [usp_selectAll_InvoiceLine_for_SalesOrderLine]
        /// </summary>
		public override List<InvoiceLineDetails> GetListForSalesOrderLine(System.Int32? salesOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_InvoiceLine_for_SalesOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Value = salesOrderLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<InvoiceLineDetails> lst = new List<InvoiceLineDetails>();
				while (reader.Read()) {
					InvoiceLineDetails obj = new InvoiceLineDetails();
					obj.InvoiceLineId = GetReaderValue_Int32(reader, "InvoiceLineId", 0);
					obj.InvoiceNo = GetReaderValue_Int32(reader, "InvoiceNo", 0);
					obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
					obj.ShippedBy = GetReaderValue_NullableInt32(reader, "ShippedBy", null);
					obj.ShippedDate = GetReaderValue_NullableDateTime(reader, "ShippedDate", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.DateOrdered = GetReaderValue_NullableDateTime(reader, "DateOrdered", null);
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null);
					obj.SupplierRMADate = GetReaderValue_NullableDateTime(reader, "SupplierRMADate", null);
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.InvoicePaid = GetReaderValue_Boolean(reader, "InvoicePaid", false);
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.LineSource = GetReaderValue_String(reader, "LineSource", "");
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.ShippedByName = GetReaderValue_String(reader, "ShippedByName", "");
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get InvoiceLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListInactiveForInvoice 
		/// Calls [usp_selectAll_InvoiceLine_Inactive_for_Invoice]
        /// </summary>
		public override List<InvoiceLineDetails> GetListInactiveForInvoice(System.Int32? invoiceId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_InvoiceLine_Inactive_for_Invoice", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = invoiceId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<InvoiceLineDetails> lst = new List<InvoiceLineDetails>();
				while (reader.Read()) {
					InvoiceLineDetails obj = new InvoiceLineDetails();
					obj.InvoiceLineId = GetReaderValue_Int32(reader, "InvoiceLineId", 0);
					obj.InvoiceNo = GetReaderValue_Int32(reader, "InvoiceNo", 0);
					obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
					obj.ShippedBy = GetReaderValue_NullableInt32(reader, "ShippedBy", null);
					obj.ShippedDate = GetReaderValue_NullableDateTime(reader, "ShippedDate", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Taxable = GetReaderValue_String(reader, "Taxable", "");
					obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.ServiceNo = GetReaderValue_NullableInt32(reader, "ServiceNo", null);
					obj.Inactive = GetReaderValue_Boolean(reader, "Inactive", false);
					obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.DateOrdered = GetReaderValue_NullableDateTime(reader, "DateOrdered", null);
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null);
					obj.SupplierRMADate = GetReaderValue_NullableDateTime(reader, "SupplierRMADate", null);
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.InvoicePaid = GetReaderValue_Boolean(reader, "InvoicePaid", false);
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.LineSource = GetReaderValue_String(reader, "LineSource", "");
					obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
					obj.ShippedByName = GetReaderValue_String(reader, "ShippedByName", "");
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get InvoiceLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update InvoiceLine
		/// Calls [usp_update_InvoiceLine]
        /// </summary>
		public override bool Update(System.Int32? invoiceLineId, System.Int32? salesOrderLineNo, System.Int32? shippedBy, System.DateTime? shippedDate, System.String customerPart, System.String notes, System.Int32? updatedBy, System.Boolean? printHazardous) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_InvoiceLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@InvoiceLineId", SqlDbType.Int).Value = invoiceLineId;
				cmd.Parameters.Add("@SalesOrderLineNo", SqlDbType.Int).Value = salesOrderLineNo;
				cmd.Parameters.Add("@ShippedBy", SqlDbType.Int).Value = shippedBy;
				cmd.Parameters.Add("@ShippedDate", SqlDbType.DateTime).Value = shippedDate;
				cmd.Parameters.Add("@CustomerPart", SqlDbType.NVarChar).Value = customerPart;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@PrintHazardous", SqlDbType.Bit).Value = printHazardous;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update InvoiceLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}