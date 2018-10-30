//Marker     Changed by      Date         Remarks
//[001]      Vinay           30/07/2012   Add compulsory incoterms field when create Credit and debit note. :ESMS No:- 105
//[002]      Vinay           24/02/2015   Need a provision in GT on SRMA Line to show Purchase order Line serial No
//[003]      Suhail          15/05/2018   Added Avoidable on SRMA Line
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
	public class SqlSupplierRmaLineProvider : SupplierRmaLineProvider {
		/// <summary>
		/// Count SupplierRmaLine
		/// Calls [usp_count_SupplierRMALine_for_PurchaseOrderLine]
		/// </summary>
		public override Int32 CountForPurchaseOrderLine(System.Int32? purchaseOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_SupplierRMALine_for_PurchaseOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Value = purchaseOrderLineId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count SupplierRmaLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DataListNugget 
		/// Calls [usp_datalistnugget_SupplierRMALine]
        /// </summary>
        public override List<SupplierRmaLineDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.String srmaNotesSearch, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? supplierRmaNoLo, System.Int32? supplierRmaNoHi, System.DateTime? supplierRmaDateFrom, System.DateTime? supplierRmaDateTo, System.Boolean? includeShipped, System.Boolean? recentOnly, System.Boolean? PohubOnly, System.Int32? clientSearch, Boolean IsGlobalLogin)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_SupplierRMALine", cn);
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
				cmd.Parameters.Add("@SRMANotesSearch", SqlDbType.NVarChar).Value = srmaNotesSearch;
				cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
				cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
				cmd.Parameters.Add("@SupplierRMANoLo", SqlDbType.Int).Value = supplierRmaNoLo;
				cmd.Parameters.Add("@SupplierRMANoHi", SqlDbType.Int).Value = supplierRmaNoHi;
				cmd.Parameters.Add("@SupplierRMADateFrom", SqlDbType.DateTime).Value = supplierRmaDateFrom;
				cmd.Parameters.Add("@SupplierRMADateTo", SqlDbType.DateTime).Value = supplierRmaDateTo;
				cmd.Parameters.Add("@IncludeShipped", SqlDbType.Bit).Value = includeShipped;
				cmd.Parameters.Add("@RecentOnly", SqlDbType.Bit).Value = recentOnly;
                cmd.Parameters.Add("@PoHubOnly", SqlDbType.Bit).Value = PohubOnly;
                cmd.Parameters.Add("@ClientSearch", SqlDbType.Int).Value = clientSearch;
                cmd.Parameters.Add("@IsGlobalLogin", SqlDbType.Bit).Value = IsGlobalLogin;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SupplierRmaLineDetails> lst = new List<SupplierRmaLineDetails>();
				while (reader.Read()) {
					SupplierRmaLineDetails obj = new SupplierRmaLineDetails();
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.SupplierRMAId = GetReaderValue_Int32(reader, "SupplierRMAId", 0);
					obj.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0);
					obj.SupplierRMADate = GetReaderValue_DateTime(reader, "SupplierRMADate", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
					obj.AllocatedQuantity = GetReaderValue_Int32(reader, "AllocatedQuantity", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);

                    obj.IPOCompanyNo = GetReaderValue_NullableInt32(reader, "IPOCompanyNo", null);
                    obj.IPOCompanyName = GetReaderValue_String(reader, "IPOCompanyName", "");
                    obj.InternalPurchaseOrderId = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderId", null);
                   // obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                   // obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SupplierRmaLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// DataListNuggetReadyToShip 
		/// Calls [usp_datalistnugget_SupplierRMALine_ReadyToShip]
        /// </summary>
        public override List<SupplierRmaLineDetails> DataListNuggetReadyToShip(System.Int32? clientId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.String srmaNotesSearch, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? supplierRmaNoLo, System.Int32? supplierRmaNoHi, System.DateTime? supplierRmaDateFrom, System.DateTime? supplierRmaDateTo, System.Int32? clientSearch, Boolean IsGlobalLogin)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_SupplierRMALine_ReadyToShip", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@BuyerSearch", SqlDbType.Int).Value = buyerSearch;
				cmd.Parameters.Add("@SRMANotesSearch", SqlDbType.NVarChar).Value = srmaNotesSearch;
				cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
				cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
				cmd.Parameters.Add("@SupplierRMANoLo", SqlDbType.Int).Value = supplierRmaNoLo;
				cmd.Parameters.Add("@SupplierRMANoHi", SqlDbType.Int).Value = supplierRmaNoHi;
				cmd.Parameters.Add("@SupplierRMADateFrom", SqlDbType.DateTime).Value = supplierRmaDateFrom;
				cmd.Parameters.Add("@SupplierRMADateTo", SqlDbType.DateTime).Value = supplierRmaDateTo;
                cmd.Parameters.Add("@ClientSearch", SqlDbType.Int).Value = clientSearch;
                cmd.Parameters.Add("@IsGlobalLogin", SqlDbType.Bit).Value = IsGlobalLogin;

				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SupplierRmaLineDetails> lst = new List<SupplierRmaLineDetails>();
				while (reader.Read()) {
					SupplierRmaLineDetails obj = new SupplierRmaLineDetails();
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.SupplierRMAId = GetReaderValue_Int32(reader, "SupplierRMAId", 0);
					obj.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0);
					obj.SupplierRMADate = GetReaderValue_DateTime(reader, "SupplierRMADate", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
					obj.AllocatedQuantity = GetReaderValue_Int32(reader, "AllocatedQuantity", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SupplierRmaLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete SupplierRmaLine
		/// Calls [usp_delete_SupplierRMALine]
		/// </summary>
		public override bool Delete(System.Int32? supplierRmaLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_SupplierRMALine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SupplierRMALineId", SqlDbType.Int).Value = supplierRmaLineId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete SupplierRmaLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_SupplierRMALine]
		/// </summary>
        public override Int32 Insert(System.Int32? supplierRmaNo, System.Int32? purchaseOrderLineNo, System.DateTime? returnDate, System.String reason, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? productNo, System.Int32? quantity, System.String reference, System.Byte? rohs, System.String notes, System.String Reason1, System.String Reason2, System.String rootCause, System.Int32? updatedBy, out int supplierRMAId, out int supplierRMANumber, System.Boolean? avoidable, System.Boolean? printHazardous)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_SupplierRMALine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SupplierRMANo", SqlDbType.Int).Value = supplierRmaNo;
				cmd.Parameters.Add("@PurchaseOrderLineNo", SqlDbType.Int).Value = purchaseOrderLineNo;
				cmd.Parameters.Add("@ReturnDate", SqlDbType.DateTime).Value = returnDate;
				cmd.Parameters.Add("@Reason", SqlDbType.NVarChar).Value = reason;
				cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
				cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
				cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
				cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
				cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Reference", SqlDbType.NVarChar).Value = reference;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@Reason1", SqlDbType.NVarChar).Value = Reason1;
                cmd.Parameters.Add("@Reason2", SqlDbType.NVarChar).Value = Reason2;
                cmd.Parameters.Add("@RootCause", SqlDbType.NVarChar).Value = rootCause;
                cmd.Parameters.Add("@SupplierRMALineId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@SupplierRMAId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@SupplierRMANumber", SqlDbType.Int).Direction = ParameterDirection.Output;
                //[003] Code start
                cmd.Parameters.Add("@IsAvoidable", SqlDbType.Bit).Value = avoidable;
                //[003] Code end
                cmd.Parameters.Add("@PrintHazardous", SqlDbType.Bit).Value = printHazardous;

				cn.Open();
				int ret = ExecuteNonQuery(cmd);
                supplierRMAId = (Int32)(cmd.Parameters["@SupplierRMAId"].Value == null ? 0 : cmd.Parameters["@SupplierRMAId"].Value);
                supplierRMANumber = (Int32)(cmd.Parameters["@SupplierRMANumber"].Value == null ? 0 : cmd.Parameters["@SupplierRMANumber"].Value);
				return (Int32)cmd.Parameters["@SupplierRMALineId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert SupplierRmaLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// ItemSearch 
		/// Calls [usp_itemsearch_SupplierRMALine]
        /// </summary>
		public override List<SupplierRmaLineDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.String srmaNotesSearch, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? supplierRmaNoLo, System.Int32? supplierRmaNoHi, System.DateTime? supplierRmaDateFrom, System.DateTime? supplierRmaDateTo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_itemsearch_SupplierRMALine", cn);
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
				cmd.Parameters.Add("@SRMANotesSearch", SqlDbType.NVarChar).Value = srmaNotesSearch;
				cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
				cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
				cmd.Parameters.Add("@SupplierRMANoLo", SqlDbType.Int).Value = supplierRmaNoLo;
				cmd.Parameters.Add("@SupplierRMANoHi", SqlDbType.Int).Value = supplierRmaNoHi;
				cmd.Parameters.Add("@SupplierRMADateFrom", SqlDbType.DateTime).Value = supplierRmaDateFrom;
				cmd.Parameters.Add("@SupplierRMADateTo", SqlDbType.DateTime).Value = supplierRmaDateTo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SupplierRmaLineDetails> lst = new List<SupplierRmaLineDetails>();
				while (reader.Read()) {
					SupplierRmaLineDetails obj = new SupplierRmaLineDetails();
					obj.SupplierRMALineId = GetReaderValue_Int32(reader, "SupplierRMALineId", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0);
					obj.SupplierRMADate = GetReaderValue_DateTime(reader, "SupplierRMADate", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SupplierRmaLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_SupplierRMALine]
        /// </summary>
		public override SupplierRmaLineDetails Get(System.Int32? supplierRmaLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_SupplierRMALine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SupplierRMALineId", SqlDbType.Int).Value = supplierRmaLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetSupplierRmaLineFromReader(reader);
					SupplierRmaLineDetails obj = new SupplierRmaLineDetails();
					obj.SupplierRMALineId = GetReaderValue_Int32(reader, "SupplierRMALineId", 0);
					obj.PurchaseOrderLineNo = GetReaderValue_Int32(reader, "PurchaseOrderLineNo", 0);
					obj.ReturnDate = GetReaderValue_DateTime(reader, "ReturnDate", DateTime.MinValue);
					obj.Reason = GetReaderValue_String(reader, "Reason", "");
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Reference = GetReaderValue_String(reader, "Reference", "");
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.SupplierRMAId = GetReaderValue_Int32(reader, "SupplierRMAId", 0);
					obj.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0);
					obj.SupplierRMADate = GetReaderValue_DateTime(reader, "SupplierRMADate", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.FullName = GetReaderValue_String(reader, "FullName", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.AuthorisedBy = GetReaderValue_Int32(reader, "AuthorisedBy", 0);
					obj.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", "");
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.AllocationId = GetReaderValue_NullableInt32(reader, "AllocationId", null);
					obj.QuantityInStock = GetReaderValue_NullableInt32(reader, "QuantityInStock", null);
					obj.Location = GetReaderValue_String(reader, "Location", "");
					obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.Reason1 = GetReaderValue_String(reader, "Reason1", "");
                    obj.Reason2 = GetReaderValue_String(reader, "Reason2", "");
                    obj.Reason1Val = GetReaderValue_String(reader, "Reason1CodeNo", "");
                    obj.Reason2Val = GetReaderValue_String(reader, "Reason2CodeNo", "");
                    obj.RootCause = GetReaderValue_String(reader, "RootCause", "");
                    //[003] Code start
                    obj.Avoidable = GetReaderValue_Boolean(reader, "IsAvoidable", false);
                    //[003] Code end
                    obj.IsProdHazardous = GetReaderValue_NullableBoolean(reader, "IsProdHazardous", false);
                    obj.PrintHazardous = GetReaderValue_NullableBoolean(reader, "PrintHazardous", false);

					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SupplierRmaLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetAllocation 
		/// Calls [usp_select_SupplierRMALine_Allocation]
        /// </summary>
		public override SupplierRmaLineDetails GetAllocation(System.Int32? supplierRmaLineId, System.Int32? allocationId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_SupplierRMALine_Allocation", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SupplierRMALineId", SqlDbType.Int).Value = supplierRmaLineId;
				cmd.Parameters.Add("@AllocationId", SqlDbType.Int).Value = allocationId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetSupplierRmaLineFromReader(reader);
					SupplierRmaLineDetails obj = new SupplierRmaLineDetails();
					obj.SupplierRMALineId = GetReaderValue_Int32(reader, "SupplierRMALineId", 0);
					obj.PurchaseOrderLineNo = GetReaderValue_Int32(reader, "PurchaseOrderLineNo", 0);
					obj.ReturnDate = GetReaderValue_DateTime(reader, "ReturnDate", DateTime.MinValue);
					obj.Reason = GetReaderValue_String(reader, "Reason", "");
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Reference = GetReaderValue_String(reader, "Reference", "");
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.SupplierRMAId = GetReaderValue_Int32(reader, "SupplierRMAId", 0);
					obj.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0);
					obj.SupplierRMADate = GetReaderValue_DateTime(reader, "SupplierRMADate", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.AllocatedQuantity = GetReaderValue_Int32(reader, "AllocatedQuantity", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.FullName = GetReaderValue_String(reader, "FullName", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.AuthorisedBy = GetReaderValue_Int32(reader, "AuthorisedBy", 0);
					obj.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", "");
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.AllocationId = GetReaderValue_NullableInt32(reader, "AllocationId", null);
					obj.QuantityInStock = GetReaderValue_NullableInt32(reader, "QuantityInStock", null);
					obj.Location = GetReaderValue_String(reader, "Location", "");
					obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null);
					obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
					obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null);
					obj.CountryOfManufacture = GetReaderValue_NullableInt32(reader, "CountryOfManufacture", null);
					obj.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", null);
					obj.SupplierNo = GetReaderValue_Int32(reader, "SupplierNo", 0);
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.PurchaseOrderLineId = GetReaderValue_Int32(reader, "PurchaseOrderLineId", 0);
					obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
					obj.PurchasePrice = GetReaderValue_Double(reader, "PurchasePrice", 0);
                    obj.Reason1 = GetReaderValue_String(reader, "Reason1", "");
                    obj.Reason2 = GetReaderValue_String(reader, "Reason2", "");
                    obj.Reason1Val = GetReaderValue_String(reader, "Reason1CodeNo", "");
                    obj.Reason2Val = GetReaderValue_String(reader, "Reason2CodeNo", "");
                    obj.RootCause = GetReaderValue_String(reader, "RootCause", "");

					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SupplierRmaLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetShip 
		/// Calls [usp_select_SupplierRMALine_Ship]
        /// </summary>
		public override SupplierRmaLineDetails GetShip(System.Int32? supplierRmaLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_SupplierRMALine_Ship", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SupplierRMALineId", SqlDbType.Int).Value = supplierRmaLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetSupplierRmaLineFromReader(reader);
					SupplierRmaLineDetails obj = new SupplierRmaLineDetails();
					obj.SupplierRMALineId = GetReaderValue_Int32(reader, "SupplierRMALineId", 0);
					obj.PurchaseOrderLineNo = GetReaderValue_Int32(reader, "PurchaseOrderLineNo", 0);
					obj.ReturnDate = GetReaderValue_DateTime(reader, "ReturnDate", DateTime.MinValue);
					obj.Reason = GetReaderValue_String(reader, "Reason", "");
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.SupplierRMAId = GetReaderValue_Int32(reader, "SupplierRMAId", 0);
					obj.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0);
					obj.SupplierRMADate = GetReaderValue_DateTime(reader, "SupplierRMADate", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
					obj.AllocatedQuantity = GetReaderValue_Int32(reader, "AllocatedQuantity", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.AllocationId = GetReaderValue_NullableInt32(reader, "AllocationId", null);
					obj.QuantityInStock = GetReaderValue_NullableInt32(reader, "QuantityInStock", null);
					obj.Location = GetReaderValue_String(reader, "Location", "");
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    //[001] code start
                    obj.SRMAIncotermsNo = GetReaderValue_NullableInt32(reader, "SRMAIncotermsNo", null);
                    //[001] code end
                                      
                    obj.Reason1 = GetReaderValue_String(reader, "Reason1", "");
                    obj.Reason2 = GetReaderValue_String(reader, "Reason2", "");                    
                    obj.RootCause = GetReaderValue_String(reader, "RootCause", "");


					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SupplierRmaLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForPurchaseOrderLine 
		/// Calls [usp_selectAll_SupplierRMALine_for_PurchaseOrderLine]
        /// </summary>
		public override List<SupplierRmaLineDetails> GetListForPurchaseOrderLine(System.Int32? purchaseOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SupplierRMALine_for_PurchaseOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Value = purchaseOrderLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SupplierRmaLineDetails> lst = new List<SupplierRmaLineDetails>();
				while (reader.Read()) {
					SupplierRmaLineDetails obj = new SupplierRmaLineDetails();
					obj.SupplierRMALineId = GetReaderValue_Int32(reader, "SupplierRMALineId", 0);
					obj.PurchaseOrderLineNo = GetReaderValue_Int32(reader, "PurchaseOrderLineNo", 0);
					obj.ReturnDate = GetReaderValue_DateTime(reader, "ReturnDate", DateTime.MinValue);
					obj.Reason = GetReaderValue_String(reader, "Reason", "");
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Reference = GetReaderValue_String(reader, "Reference", "");
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.SupplierRMAId = GetReaderValue_Int32(reader, "SupplierRMAId", 0);
					obj.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0);
					obj.SupplierRMADate = GetReaderValue_DateTime(reader, "SupplierRMADate", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.FullName = GetReaderValue_String(reader, "FullName", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.AuthorisedBy = GetReaderValue_Int32(reader, "AuthorisedBy", 0);
					obj.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", "");
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.Price = GetReaderValue_Double(reader, "Price", 0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.AllocationId = GetReaderValue_NullableInt32(reader, "AllocationId", null);
					obj.QuantityInStock = GetReaderValue_NullableInt32(reader, "QuantityInStock", null);
					obj.Location = GetReaderValue_String(reader, "Location", "");
					obj.Taxable = GetReaderValue_Boolean(reader, "Taxable", false);
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");

                    obj.Reason1 = GetReaderValue_String(reader, "Reason1", "");
                    obj.Reason2 = GetReaderValue_String(reader, "Reason2", "");
                    obj.RootCause = GetReaderValue_String(reader, "RootCause", "");

                   

					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SupplierRmaLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForSupplierRMA 
		/// Calls [usp_selectAll_SupplierRMALine_for_SupplierRMA]
        /// </summary>
		public override List<SupplierRmaLineDetails> GetListForSupplierRMA(System.Int32? supplierRmaId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SupplierRMALine_for_SupplierRMA", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SupplierRMAId", SqlDbType.Int).Value = supplierRmaId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SupplierRmaLineDetails> lst = new List<SupplierRmaLineDetails>();
				while (reader.Read()) {
					SupplierRmaLineDetails obj = new SupplierRmaLineDetails();
					obj.SupplierRMALineId = GetReaderValue_Int32(reader, "SupplierRMALineId", 0);
					obj.PurchaseOrderLineNo = GetReaderValue_Int32(reader, "PurchaseOrderLineNo", 0);
					obj.ReturnDate = GetReaderValue_DateTime(reader, "ReturnDate", DateTime.MinValue);
					obj.Reason = GetReaderValue_String(reader, "Reason", "");
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.Reference = GetReaderValue_String(reader, "Reference", "");
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.SupplierRMAId = GetReaderValue_Int32(reader, "SupplierRMAId", 0);
					obj.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0);
					obj.SupplierRMADate = GetReaderValue_DateTime(reader, "SupplierRMADate", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.AuthorisedBy = GetReaderValue_Int32(reader, "AuthorisedBy", 0);
					obj.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", "");
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.QuantityShipped = GetReaderValue_Int32(reader, "QuantityShipped", 0);
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.Reason1 = GetReaderValue_String(reader, "Reason1", "");
                    obj.Reason2 = GetReaderValue_String(reader, "Reason2", "");
                    obj.RootCause = GetReaderValue_String(reader, "RootCause", "");
                    //[002] code start
                    obj.POSerialNo = GetReaderValue_Int16(reader, "POSerialNo", 0);
                    //[002] code end
                    obj.ParentSRMALineNo = GetReaderValue_Int32(reader, "ParentSRMALineNo", 0);
                    obj.PrintHazardous = GetReaderValue_NullableBoolean(reader, "PrintHazardous", false);

					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SupplierRmaLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListShipForSupplierRMA 
		/// Calls [usp_selectAll_SupplierRMALine_Ship_for_SupplierRMA]
        /// </summary>
		public override List<SupplierRmaLineDetails> GetListShipForSupplierRMA(System.Int32? supplierRmaId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SupplierRMALine_Ship_for_SupplierRMA", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SupplierRMAId", SqlDbType.Int).Value = supplierRmaId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SupplierRmaLineDetails> lst = new List<SupplierRmaLineDetails>();
				while (reader.Read()) {
					SupplierRmaLineDetails obj = new SupplierRmaLineDetails();
					obj.SupplierRMALineId = GetReaderValue_Int32(reader, "SupplierRMALineId", 0);
					obj.PurchaseOrderLineNo = GetReaderValue_Int32(reader, "PurchaseOrderLineNo", 0);
					obj.ReturnDate = GetReaderValue_DateTime(reader, "ReturnDate", DateTime.MinValue);
					obj.Reason = GetReaderValue_String(reader, "Reason", "");
					obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.SupplierRMAId = GetReaderValue_Int32(reader, "SupplierRMAId", 0);
					obj.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0);
					obj.SupplierRMADate = GetReaderValue_DateTime(reader, "SupplierRMADate", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
					obj.AllocatedQuantity = GetReaderValue_Int32(reader, "AllocatedQuantity", 0);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.AllocationId = GetReaderValue_NullableInt32(reader, "AllocationId", null);
					obj.QuantityInStock = GetReaderValue_NullableInt32(reader, "QuantityInStock", null);
					obj.Location = GetReaderValue_String(reader, "Location", "");
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");

                    obj.Reason1 = GetReaderValue_String(reader, "Reason1", "");
                    obj.Reason2 = GetReaderValue_String(reader, "Reason2", "");
                    obj.RootCause = GetReaderValue_String(reader, "RootCause", "");

                    

					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SupplierRmaLines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		/// <summary>
		/// GetListFromGoodsInLineForDocket 
		/// Calls [usp_selectAll_SupplierRMALine_from_GoodsInLine_for_Docket]
		/// </summary>
		public override List<SupplierRmaLineDetails> GetListFromGoodsInLineForDocket(System.Int32? goodsInLineNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_SupplierRMALine_from_GoodsInLine_for_Docket", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@GoodsInLineNo", SqlDbType.Int).Value = goodsInLineNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<SupplierRmaLineDetails> lst = new List<SupplierRmaLineDetails>();
				while (reader.Read()) {
					SupplierRmaLineDetails obj = new SupplierRmaLineDetails();
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
					obj.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ReturnDate = GetReaderValue_DateTime(reader, "ReturnDate", DateTime.Now);
					obj.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", "");
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
                    //[0001] code start
                    obj.ShippingNotes = GetReaderValue_String(reader, "ShippingNotes", "");
                    //[0001] code end
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get SupplierRMALines", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
        /// <summary>
        /// Update SupplierRmaLine
		/// Calls [usp_update_SupplierRMALine]
        /// </summary>
        public override bool Update(System.Int32? supplierRmaLineId, System.String reason, System.Int32? quantity, System.String reference, System.Byte? rohs, System.String notes, System.String Reason1, System.String Reason2, System.String rootCause, System.Int32? updatedBy, System.Boolean? avoidable, System.Boolean? printHazardous)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_SupplierRMALine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@SupplierRMALineId", SqlDbType.Int).Value = supplierRmaLineId;
				cmd.Parameters.Add("@Reason", SqlDbType.NVarChar).Value = reason;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@Reference", SqlDbType.NVarChar).Value = reference;
				cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@Reason1", SqlDbType.NVarChar).Value = Reason1;
                cmd.Parameters.Add("@Reason2", SqlDbType.NVarChar).Value = Reason2;
                cmd.Parameters.Add("@RootCause", SqlDbType.NVarChar).Value = rootCause;
                cmd.Parameters.Add("@PrintHazardous", SqlDbType.Bit).Value = printHazardous;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                //[003] Code start
                cmd.Parameters.Add("@IsAvoidable", SqlDbType.Bit).Value = avoidable;
                //[003] Code end
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update SupplierRmaLine", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}