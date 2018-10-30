/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to upload pdf document for Purchage Order section
[002]      Vinay           01/11/2012   Add comma(,) seprated Debit and SRMA in purchase order section  
[003]      Vinay           17/01/2014   ESMS Ticket No : 95
[004]      Aashu Singh     29/05/2018   Quick Jump in Global Warehouse [11815]
[005]      Aashu           05/06/2018   Show Billed to address on PO
[006]      Aashu           18/06/2018   REB-11552: Change how the how the IPO/PO expedite message work
[007]      Aashu Singh     25/07/2018   REB-12824:   Add Client name to the PO bill to address
[008]      Aashu Singh     22-Aug-2018  REB-12084:Lock PO lines when EPR is authorised
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
	public class SqlPurchaseOrderProvider : PurchaseOrderProvider {
		/// <summary>
		/// Count PurchaseOrder
		/// Calls [usp_count_PurchaseOrder_for_Client]
		/// </summary>
		public override Int32 CountForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_PurchaseOrder_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count PurchaseOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Count PurchaseOrder
		/// Calls [usp_count_PurchaseOrder_for_Company]
		/// </summary>
		public override Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeClosed) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_PurchaseOrder_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count PurchaseOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Count PurchaseOrder
		/// Calls [usp_count_PurchaseOrder_open_for_Company]
		/// </summary>
		public override Int32 CountOpenForCompany(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_PurchaseOrder_open_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count PurchaseOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Count PurchaseOrder
		/// Calls [usp_count_PurchaseOrder_receiving_for_Client]
		/// </summary>
		public override Int32 CountReceivingForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_PurchaseOrder_receiving_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count PurchaseOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete PurchaseOrder
		/// Calls [usp_delete_PurchaseOrder]
		/// </summary>
		public override bool Delete(System.Int32? purchaseOrderId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_PurchaseOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete PurchaseOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_PurchaseOrder]
		/// </summary>
		public override Int32 Insert(System.Int32? clientNo, System.Int32? companyNo, System.Int32? contactNo, System.DateTime? dateOrdered, System.Int32? warehouseNo, System.Int32? currencyNo, System.Int32? buyer, System.Int32? shipViaNo, System.String account, System.Int32? termsNo, System.String expediteNotes, System.DateTime? expediteDate, System.Double? totalShipInCost, System.Int32? divisionNo, System.Int32? taxNo, System.String notes, System.String instructions, System.Boolean? paid, System.Boolean? confirmed, System.Int32? importCountryNo, System.String freeOnBoard, System.Int32? statusNo, System.Boolean? closed, System.Int32? incotermNo, System.Int32? updatedBy,System.String airwayBill) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_PurchaseOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@DateOrdered", SqlDbType.DateTime).Value = dateOrdered;
				cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@Buyer", SqlDbType.Int).Value = buyer;
				cmd.Parameters.Add("@ShipViaNo", SqlDbType.Int).Value = shipViaNo;
				cmd.Parameters.Add("@Account", SqlDbType.NVarChar).Value = account;
				cmd.Parameters.Add("@TermsNo", SqlDbType.Int).Value = termsNo;
				cmd.Parameters.Add("@ExpediteNotes", SqlDbType.NVarChar).Value = expediteNotes;
				cmd.Parameters.Add("@ExpediteDate", SqlDbType.DateTime).Value = expediteDate;
				cmd.Parameters.Add("@TotalShipInCost", SqlDbType.Float).Value = totalShipInCost;
				cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
				cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
				cmd.Parameters.Add("@Paid", SqlDbType.Bit).Value = paid;
				cmd.Parameters.Add("@Confirmed", SqlDbType.Bit).Value = confirmed;
				cmd.Parameters.Add("@ImportCountryNo", SqlDbType.Int).Value = importCountryNo;
				cmd.Parameters.Add("@FreeOnBoard", SqlDbType.NVarChar).Value = freeOnBoard;
				cmd.Parameters.Add("@StatusNo", SqlDbType.Int).Value = statusNo;
				cmd.Parameters.Add("@Closed", SqlDbType.Bit).Value = closed;
				cmd.Parameters.Add("@IncotermNo", SqlDbType.Int).Value = incotermNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //[003] code start
                cmd.Parameters.Add("@AirWayBillPO", SqlDbType.NVarChar).Value = airwayBill;
                //[003] code end
				cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@PurchaseOrderId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert PurchaseOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// ItemSearch 
		/// Calls [usp_itemsearch_PurchaseOrder]
        /// </summary>
        public override List<PurchaseOrderDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.Boolean? includeClosed, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? expediteDateFrom, System.DateTime? expediteDateTo, System.Int32? internalPurchaseOrderNoLo, System.Int32? internalPurchaseOrderNoHi)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_itemsearch_PurchaseOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@BuyerSearch", SqlDbType.Int).Value = buyerSearch;
				cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
				cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
				cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
				cmd.Parameters.Add("@ExpediteDateFrom", SqlDbType.DateTime).Value = expediteDateFrom;
				cmd.Parameters.Add("@ExpediteDateTo", SqlDbType.DateTime).Value = expediteDateTo;
                cmd.Parameters.Add("@InternalPurchaseOrderNoLo", SqlDbType.Int).Value = internalPurchaseOrderNoLo;
                cmd.Parameters.Add("@InternalPurchaseOrderNoHi", SqlDbType.Int).Value = internalPurchaseOrderNoHi;

				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderDetails> lst = new List<PurchaseOrderDetails>();
				while (reader.Read()) {
					PurchaseOrderDetails obj = new PurchaseOrderDetails();
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.ExpediteDate = GetReaderValue_NullableDateTime(reader, "ExpediteDate", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrders", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// ItemSearchReceived 
		/// Calls [usp_itemsearch_PurchaseOrder_Received]
        /// </summary>
        public override List<PurchaseOrderDetails> ItemSearchReceived(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.Boolean? includeClosed, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.Int32? internalPurchaseOrderNoLo, System.Int32? internalPurchaseOrderNoHi)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_itemsearch_PurchaseOrder_Received", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@BuyerSearch", SqlDbType.Int).Value = buyerSearch;
				cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
				cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
				cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
				cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
				cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
                cmd.Parameters.Add("@InternalPurchaseOrderNoLo", SqlDbType.Int).Value = internalPurchaseOrderNoLo;
                cmd.Parameters.Add("@InternalPurchaseOrderNoHi", SqlDbType.Int).Value = internalPurchaseOrderNoHi;
                cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderDetails> lst = new List<PurchaseOrderDetails>();
				while (reader.Read()) {
					PurchaseOrderDetails obj = new PurchaseOrderDetails();
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					obj.LastReceived = GetReaderValue_NullableDateTime(reader, "LastReceived", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrders", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_PurchaseOrder]
        /// </summary>
		public override PurchaseOrderDetails Get(System.Int32? purchaseOrderId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_PurchaseOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetPurchaseOrderFromReader(reader);
					PurchaseOrderDetails obj = new PurchaseOrderDetails();
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0);
                    //obj.IPOWarehouseNo = GetReaderValue_Int32(reader, "IPOWarehouseNo", 0);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.Account = GetReaderValue_String(reader, "Account", "");
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.ExpediteNotes = GetReaderValue_String(reader, "ExpediteNotes", "");
					obj.ExpediteDate = GetReaderValue_NullableDateTime(reader, "ExpediteDate", null);
					obj.TotalShipInCost = GetReaderValue_NullableDouble(reader, "TotalShipInCost", null);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
					obj.Confirmed = GetReaderValue_Boolean(reader, "Confirmed", false);
					obj.ImportCountryNo = GetReaderValue_NullableInt32(reader, "ImportCountryNo", null);
					obj.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", "");
					obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
					obj.ApprovedBy = GetReaderValue_NullableInt32(reader, "ApprovedBy", null);
					obj.DateApproved = GetReaderValue_NullableDateTime(reader, "DateApproved", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
					obj.ImportCountryName = GetReaderValue_String(reader, "ImportCountryName", "");
					obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
					obj.PurchaseOrderValue = GetReaderValue_NullableDouble(reader, "PurchaseOrderValue", null);
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
					obj.CompanyPORating = GetReaderValue_NullableInt32(reader, "CompanyPORating", null);
					obj.Approver = GetReaderValue_String(reader, "Approver", "");
                    //[002] code start
                    obj.SupplierRMAIds = GetReaderValue_String(reader, "SupplierRMAIds", "");
                    obj.SupplierRMANumbers = GetReaderValue_String(reader, "SupplierRMANumbers", "");
                    obj.DebitIds = GetReaderValue_String(reader, "DebitIds", "");
                    obj.DebitNumbers = GetReaderValue_String(reader, "DebitNumbers", "");
                    //[002] code end
                    //[003] code start
                    obj.AirWayBill = GetReaderValue_String(reader, "AirWayBillPO", "");
                    obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
                    //[003] code end
                    obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
                    obj.EPRIds = GetReaderValue_String(reader, "EPRIds", "");
                    //obj.IsIPO = GetReaderValue_Boolean(reader, "IsIPO", false);
                    obj.IPOClientNo = GetReaderValue_NullableInt32(reader, "IPOClientNo", null);
                    obj.SupplierOnSop = GetReaderValue_Boolean(reader, "SupplierOnSop", false);
                    obj.POApproved = GetReaderValue_Boolean(reader, "POApproved", false);
                    obj.InternalPurchaseOrderNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNo", 0);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNumber", 0);
                    obj.IPOBuyer = GetReaderValue_NullableInt32(reader, "IpoBuyer", 0);
                    obj.IPOBuyerName = GetReaderValue_String(reader, "IpoBuyerName", "");
                    obj.MailGroupId = GetReaderValue_NullableInt32(reader, "MailGroupId", 0);
                    obj.ClientCurrencyCode = GetReaderValue_String(reader, "ClientCurrencyCode", "");
                    obj.IsChecked = GetReaderValue_Boolean(reader, "isChecked", false);
                    obj.CompanyNameType = GetReaderValue_String(reader, "CompanyNameType", "");
                    obj.POGlobalCurrencyNo = GetReaderValue_NullableInt32(reader, "POGlobalCurrencyNo", 0);
                    //[008] start
                    obj.POLineEPRIds = GetReaderValue_String(reader, "POLineEPRIds", "");
                    //[008] end
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetByNumber 
		/// Calls [usp_select_PurchaseOrder_by_Number]
        /// </summary>
		public override PurchaseOrderDetails GetByNumber(System.Int32? purchaseOrderNumber, System.Int32? clientNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_PurchaseOrder_by_Number", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PurchaseOrderNumber", SqlDbType.Int).Value = purchaseOrderNumber;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetPurchaseOrderFromReader(reader);
					PurchaseOrderDetails obj = new PurchaseOrderDetails();
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.Account = GetReaderValue_String(reader, "Account", "");
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.ExpediteNotes = GetReaderValue_String(reader, "ExpediteNotes", "");
					obj.ExpediteDate = GetReaderValue_NullableDateTime(reader, "ExpediteDate", null);
					obj.TotalShipInCost = GetReaderValue_NullableDouble(reader, "TotalShipInCost", null);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
					obj.Confirmed = GetReaderValue_Boolean(reader, "Confirmed", false);
					obj.ImportCountryNo = GetReaderValue_NullableInt32(reader, "ImportCountryNo", null);
					obj.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", "");
					obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
					obj.ApprovedBy = GetReaderValue_NullableInt32(reader, "ApprovedBy", null);
					obj.DateApproved = GetReaderValue_NullableDateTime(reader, "DateApproved", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
					obj.ImportCountryName = GetReaderValue_String(reader, "ImportCountryName", "");
					obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
					obj.PurchaseOrderValue = GetReaderValue_NullableDouble(reader, "PurchaseOrderValue", null);
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
					obj.CompanyPORating = GetReaderValue_NullableInt32(reader, "CompanyPORating", null);
					obj.Approver = GetReaderValue_String(reader, "Approver", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForPage 
		/// Calls [usp_select_PurchaseOrder_for_Page]
        /// </summary>
		public override PurchaseOrderDetails GetForPage(System.Int32? purchaseOrderId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_PurchaseOrder_for_Page", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetPurchaseOrderFromReader(reader);
					PurchaseOrderDetails obj = new PurchaseOrderDetails();
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CompanyNameForSearch = GetReaderValue_String(reader, "CompanyNameForSearch", "");
                    // [001] code start
                    obj.IsPDFAvailable = GetReaderValue_Boolean(reader, "IsPDFAvailable", false);
                    // [001] code end
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", 0);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
                    obj.IPOClientNo = GetReaderValue_Int32(reader, "IPOClientNo", 0);
                    obj.IsPOHub = GetReaderValue_Boolean(reader, "IsPOHub", false);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.ClientBaseCurrencyCode = GetReaderValue_String(reader, "ClientBaseCurrencyCode", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForPrint 
		/// Calls [usp_select_PurchaseOrder_for_Print]
        /// </summary>
		public override PurchaseOrderDetails GetForPrint(System.Int32? purchaseOrderId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_PurchaseOrder_for_Print", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetPurchaseOrderFromReader(reader);
					PurchaseOrderDetails obj = new PurchaseOrderDetails();
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.Account = GetReaderValue_String(reader, "Account", "");
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.ExpediteNotes = GetReaderValue_String(reader, "ExpediteNotes", "");
					obj.ExpediteDate = GetReaderValue_NullableDateTime(reader, "ExpediteDate", null);
					obj.TotalShipInCost = GetReaderValue_NullableDouble(reader, "TotalShipInCost", null);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
					obj.Confirmed = GetReaderValue_Boolean(reader, "Confirmed", false);
					obj.ImportCountryNo = GetReaderValue_NullableInt32(reader, "ImportCountryNo", null);
					obj.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", "");
					obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
					obj.ApprovedBy = GetReaderValue_NullableInt32(reader, "ApprovedBy", null);
					obj.DateApproved = GetReaderValue_NullableDateTime(reader, "DateApproved", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
					obj.ImportCountryName = GetReaderValue_String(reader, "ImportCountryName", "");
					obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
					obj.PurchaseOrderValue = GetReaderValue_NullableDouble(reader, "PurchaseOrderValue", null);
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
					obj.CompanyPORating = GetReaderValue_NullableInt32(reader, "CompanyPORating", null);
					obj.Approver = GetReaderValue_String(reader, "Approver", "");
					obj.CompanyTelephone = GetReaderValue_String(reader, "CompanyTelephone", "");
					obj.CompanyFax = GetReaderValue_String(reader, "CompanyFax", "");
					obj.ContactEmail = GetReaderValue_String(reader, "ContactEmail", "");
                    obj.VATNO = GetReaderValue_String(reader, "VATNo", "");
                    //[005] start
                    obj.BilledToAddress = GetReaderValue_String(reader, "ClientBillTo", "");
                    obj.ClientVATNo = GetReaderValue_String(reader, "ClientVATNo", "");
                    //[005] end
                    obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    //[007] start
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    //[007] end
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetIDByNumber 
		/// Calls [usp_select_PurchaseOrder_ID_by_Number]
        /// </summary>
        public override List<PurchaseOrderDetails> GetIDByNumber(System.Int32? purchaseOrderNumber, System.Int32? clientNo, System.Int32? isGlobalUser)
        {
            //[004] start
			SqlConnection cn = null;
			SqlCommand cmd = null;
            List<PurchaseOrderDetails> lstPO = new List<PurchaseOrderDetails>();
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_PurchaseOrder_ID_by_Number", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PurchaseOrderNumber", SqlDbType.Int).Value = purchaseOrderNumber;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@IsGlobalUser", SqlDbType.Int).Value = isGlobalUser;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				while (reader.Read()) {
					//return GetPurchaseOrderFromReader(reader);
					PurchaseOrderDetails obj = new PurchaseOrderDetails();
                    obj.PONumberDetail = GetReaderValue_String(reader, "PurchaseOrderNumber", "false");
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
                    lstPO.Add(obj);
				}
                return lstPO;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
            //[004] end
		}
		
		
        /// <summary>
        /// GetNextNumber 
		/// Calls [usp_select_PurchaseOrder_NextNumber]
        /// </summary>
		public override PurchaseOrderDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_PurchaseOrder_NextNumber", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@NewNumber", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetPurchaseOrderFromReader(reader);
					PurchaseOrderDetails obj = new PurchaseOrderDetails();
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetStatus 
		/// Calls [usp_select_PurchaseOrder_Status]
        /// </summary>
		public override PurchaseOrderDetails GetStatus(System.Int32? purchaseOrderId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_PurchaseOrder_Status", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetPurchaseOrderFromReader(reader);
					PurchaseOrderDetails obj = new PurchaseOrderDetails();
					obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// GetIPONotification 
        /// Calls [usp_select_InternalPurchaseOrder_Notification]
        /// </summary>
        public override PurchaseOrderDetails GetIPONotification(System.Int32? purchaseOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_InternalPurchaseOrder_Notification", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetPurchaseOrderFromReader(reader);
                    PurchaseOrderDetails obj = new PurchaseOrderDetails();
                    obj.InternalPurchaseOrderId = GetReaderValue_Int32(reader, "InternalPurchaseOrderId", 0);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0); 
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
                    obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
                    obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
                    obj.IPOBuyer = GetReaderValue_Int32(reader, "IPOBuyer", 0);
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
                throw new Exception("Failed to get PurchaseOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// GetListDueForClient 
		/// Calls [usp_selectAll_PurchaseOrder_due_for_Client]
        /// </summary>
		public override List<PurchaseOrderDetails> GetListDueForClient(System.Int32? clientId, System.Int32? topToSelect,bool isPOHub) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_PurchaseOrder_due_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
                cmd.Parameters.Add("@IsPOHub", SqlDbType.Bit).Value = isPOHub;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderDetails> lst = new List<PurchaseOrderDetails>();
				while (reader.Read()) {
					PurchaseOrderDetails obj = new PurchaseOrderDetails();
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.OutstandingQuantity = GetReaderValue_NullableInt32(reader, "OutstandingQuantity", null);
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.Balance = GetReaderValue_NullableDouble(reader, "Balance", null);
					obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
					obj.DaysOverdue = GetReaderValue_NullableInt32(reader, "DaysOverdue", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrders", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForCompany 
		/// Calls [usp_selectAll_PurchaseOrder_for_Company]
        /// </summary>
		public override List<PurchaseOrderDetails> GetListForCompany(System.Int32? companyId, System.Boolean? includeClosed) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_PurchaseOrder_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderDetails> lst = new List<PurchaseOrderDetails>();
				while (reader.Read()) {
					PurchaseOrderDetails obj = new PurchaseOrderDetails();
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.Account = GetReaderValue_String(reader, "Account", "");
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.ExpediteNotes = GetReaderValue_String(reader, "ExpediteNotes", "");
					obj.ExpediteDate = GetReaderValue_NullableDateTime(reader, "ExpediteDate", null);
					obj.TotalShipInCost = GetReaderValue_NullableDouble(reader, "TotalShipInCost", null);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
					obj.Confirmed = GetReaderValue_Boolean(reader, "Confirmed", false);
					obj.ImportCountryNo = GetReaderValue_NullableInt32(reader, "ImportCountryNo", null);
					obj.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", "");
					obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
					obj.ApprovedBy = GetReaderValue_NullableInt32(reader, "ApprovedBy", null);
					obj.DateApproved = GetReaderValue_NullableDateTime(reader, "DateApproved", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
					obj.ImportCountryName = GetReaderValue_String(reader, "ImportCountryName", "");
					obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
					obj.PurchaseOrderValue = GetReaderValue_NullableDouble(reader, "PurchaseOrderValue", null);
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
					obj.CompanyPORating = GetReaderValue_NullableInt32(reader, "CompanyPORating", null);
					obj.Approver = GetReaderValue_String(reader, "Approver", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrders", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListOpenForCompany 
		/// Calls [usp_selectAll_PurchaseOrder_open_for_Company]
        /// </summary>
		public override List<PurchaseOrderDetails> GetListOpenForCompany(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_PurchaseOrder_open_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderDetails> lst = new List<PurchaseOrderDetails>();
				while (reader.Read()) {
					PurchaseOrderDetails obj = new PurchaseOrderDetails();
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.Account = GetReaderValue_String(reader, "Account", "");
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.ExpediteNotes = GetReaderValue_String(reader, "ExpediteNotes", "");
					obj.ExpediteDate = GetReaderValue_NullableDateTime(reader, "ExpediteDate", null);
					obj.TotalShipInCost = GetReaderValue_NullableDouble(reader, "TotalShipInCost", null);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
					obj.Confirmed = GetReaderValue_Boolean(reader, "Confirmed", false);
					obj.ImportCountryNo = GetReaderValue_NullableInt32(reader, "ImportCountryNo", null);
					obj.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", "");
					obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
					obj.ApprovedBy = GetReaderValue_NullableInt32(reader, "ApprovedBy", null);
					obj.DateApproved = GetReaderValue_NullableDateTime(reader, "DateApproved", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
					obj.ImportCountryName = GetReaderValue_String(reader, "ImportCountryName", "");
					obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
					obj.PurchaseOrderValue = GetReaderValue_NullableDouble(reader, "PurchaseOrderValue", null);
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
					obj.CompanyPORating = GetReaderValue_NullableInt32(reader, "CompanyPORating", null);
					obj.Approver = GetReaderValue_String(reader, "Approver", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrders", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListOpenForLogin 
		/// Calls [usp_selectAll_PurchaseOrder_open_for_Login]
        /// </summary>
		public override List<PurchaseOrderDetails> GetListOpenForLogin(System.Int32? loginId, System.Int32? topToSelect, bool isPOHub) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_PurchaseOrder_open_for_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
                cmd.Parameters.Add("@IsPOHub", SqlDbType.Bit).Value = isPOHub;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderDetails> lst = new List<PurchaseOrderDetails>();
				while (reader.Read()) {
					PurchaseOrderDetails obj = new PurchaseOrderDetails();
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.OutstandingQuantity = GetReaderValue_NullableInt32(reader, "OutstandingQuantity", null);
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.Balance = GetReaderValue_NullableDouble(reader, "Balance", null);
					obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrders", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// <summary>
        /// GetListOpenForLoginToday 
        /// Calls [usp_selectAll_PurchaseOrder_open_for_Login_Today]
        /// </summary>
        public override List<PurchaseOrderDetails> GetListOpenForLoginToday(System.Int32? loginId, System.Int32? topToSelect)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_PurchaseOrder_open_for_Login_Today", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PurchaseOrderDetails> lst = new List<PurchaseOrderDetails>();
                while (reader.Read())
                {
                    PurchaseOrderDetails obj = new PurchaseOrderDetails();
                    obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get PurchaseOrders", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// GetListOverdueForCompany 
		/// Calls [usp_selectAll_PurchaseOrder_overdue_for_Company]
        /// </summary>
		public override List<PurchaseOrderDetails> GetListOverdueForCompany(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_PurchaseOrder_overdue_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderDetails> lst = new List<PurchaseOrderDetails>();
				while (reader.Read()) {
					PurchaseOrderDetails obj = new PurchaseOrderDetails();
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.Account = GetReaderValue_String(reader, "Account", "");
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.ExpediteNotes = GetReaderValue_String(reader, "ExpediteNotes", "");
					obj.ExpediteDate = GetReaderValue_NullableDateTime(reader, "ExpediteDate", null);
					obj.TotalShipInCost = GetReaderValue_NullableDouble(reader, "TotalShipInCost", null);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
					obj.Confirmed = GetReaderValue_Boolean(reader, "Confirmed", false);
					obj.ImportCountryNo = GetReaderValue_NullableInt32(reader, "ImportCountryNo", null);
					obj.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", "");
					obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
					obj.ApprovedBy = GetReaderValue_NullableInt32(reader, "ApprovedBy", null);
					obj.DateApproved = GetReaderValue_NullableDateTime(reader, "DateApproved", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
					obj.ImportCountryName = GetReaderValue_String(reader, "ImportCountryName", "");
					obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
					obj.PurchaseOrderValue = GetReaderValue_NullableDouble(reader, "PurchaseOrderValue", null);
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
					obj.CompanyPORating = GetReaderValue_NullableInt32(reader, "CompanyPORating", null);
					obj.Approver = GetReaderValue_String(reader, "Approver", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrders", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListOverdueForLogin 
		/// Calls [usp_selectAll_PurchaseOrder_overdue_for_Login]
        /// </summary>
		public override List<PurchaseOrderDetails> GetListOverdueForLogin(System.Int32? loginId, System.Int32? topToSelect, bool isPOHub) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_PurchaseOrder_overdue_for_Login", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
				cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
                cmd.Parameters.Add("@IsPOHub", SqlDbType.Bit).Value = isPOHub;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderDetails> lst = new List<PurchaseOrderDetails>();
				while (reader.Read()) {
					PurchaseOrderDetails obj = new PurchaseOrderDetails();
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.OutstandingQuantity = GetReaderValue_NullableInt32(reader, "OutstandingQuantity", null);
					obj.CreditLimit = GetReaderValue_NullableDouble(reader, "CreditLimit", null);
					obj.Balance = GetReaderValue_NullableDouble(reader, "Balance", null);
					obj.DeliveryDate = GetReaderValue_DateTime(reader, "DeliveryDate", DateTime.MinValue);
					obj.DaysOverdue = GetReaderValue_NullableInt32(reader, "DaysOverdue", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrders", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
        /// <summary>
        /// GetListRecentlyReceived 
		/// Calls [usp_selectAll_PurchaseOrder_RecentlyReceived]
        /// </summary>
		public override List<PurchaseOrderDetails> GetListRecentlyReceived(System.Int32? clientId, System.Int32? topToSelect, bool isPOHub) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_PurchaseOrder_RecentlyReceived", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
                cmd.Parameters.Add("@IsPOHub", SqlDbType.Bit).Value = isPOHub;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<PurchaseOrderDetails> lst = new List<PurchaseOrderDetails>();
				while (reader.Read()) {
					PurchaseOrderDetails obj = new PurchaseOrderDetails();
					obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
					obj.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
					obj.Account = GetReaderValue_String(reader, "Account", "");
					obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
					obj.ExpediteNotes = GetReaderValue_String(reader, "ExpediteNotes", "");
					obj.ExpediteDate = GetReaderValue_NullableDateTime(reader, "ExpediteDate", null);
					obj.TotalShipInCost = GetReaderValue_NullableDouble(reader, "TotalShipInCost", null);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
					obj.Confirmed = GetReaderValue_Boolean(reader, "Confirmed", false);
					obj.ImportCountryNo = GetReaderValue_NullableInt32(reader, "ImportCountryNo", null);
					obj.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", "");
					obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
					obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
					obj.ApprovedBy = GetReaderValue_NullableInt32(reader, "ApprovedBy", null);
					obj.DateApproved = GetReaderValue_NullableDateTime(reader, "DateApproved", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
					obj.ImportCountryName = GetReaderValue_String(reader, "ImportCountryName", "");
					obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
					obj.PurchaseOrderValue = GetReaderValue_NullableDouble(reader, "PurchaseOrderValue", null);
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
					obj.CompanyPORating = GetReaderValue_NullableInt32(reader, "CompanyPORating", null);
					obj.Approver = GetReaderValue_String(reader, "Approver", "");
					obj.GoodsInId = GetReaderValue_Int32(reader, "GoodsInId", 0);
					obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
					obj.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get PurchaseOrders", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update PurchaseOrder
		/// Calls [usp_update_PurchaseOrder]
        /// </summary>
        public override bool Update(System.Int32? purchaseOrderId, System.Int32? currencyNo, System.Int32? contactNo, System.Int32? buyer, System.Int32? shipViaNo, System.String account, System.String expediteNotes, System.DateTime? expediteDate, System.Double? totalShipInCost, System.Int32? divisionNo, System.Int32? taxNo, System.Int32? termsNo, System.String notes, System.String instructions, System.Boolean? paid, System.Boolean? confirmed, System.Int32? importCountryNo, System.String freeOnBoard, System.Int32? statusNo, System.Boolean? closed, System.Int32? incotermNo, System.Int32? updatedBy, System.Int32? warehouseNo, System.String airwayBill, System.Int32? companyNo)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_PurchaseOrder", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@Buyer", SqlDbType.Int).Value = buyer;
				cmd.Parameters.Add("@ShipViaNo", SqlDbType.Int).Value = shipViaNo;
				cmd.Parameters.Add("@Account", SqlDbType.NVarChar).Value = account;
				cmd.Parameters.Add("@ExpediteNotes", SqlDbType.NVarChar).Value = expediteNotes;
				cmd.Parameters.Add("@ExpediteDate", SqlDbType.DateTime).Value = expediteDate;
				cmd.Parameters.Add("@TotalShipInCost", SqlDbType.Float).Value = totalShipInCost;
				cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
				cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
				cmd.Parameters.Add("@TermsNo", SqlDbType.Int).Value = termsNo;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
				cmd.Parameters.Add("@Paid", SqlDbType.Bit).Value = paid;
				cmd.Parameters.Add("@Confirmed", SqlDbType.Bit).Value = confirmed;
				cmd.Parameters.Add("@ImportCountryNo", SqlDbType.Int).Value = importCountryNo;
				cmd.Parameters.Add("@FreeOnBoard", SqlDbType.NVarChar).Value = freeOnBoard;
				cmd.Parameters.Add("@StatusNo", SqlDbType.Int).Value = statusNo;
				cmd.Parameters.Add("@Closed", SqlDbType.Bit).Value = closed;
				cmd.Parameters.Add("@IncotermNo", SqlDbType.Int).Value = incotermNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
                //[003] code start
                cmd.Parameters.Add("@AirWayBillPO", SqlDbType.NVarChar).Value = airwayBill;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
                //[003] code end
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update PurchaseOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update PurchaseOrder
		/// Calls [usp_update_PurchaseOrder_Approve]
        /// </summary>
		public override bool UpdateApprove(System.Int32? purchaseOrderId, System.Int32? approvedBy, System.Boolean? approve) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_PurchaseOrder_Approve", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
				cmd.Parameters.Add("@ApprovedBy", SqlDbType.Int).Value = approvedBy;
				cmd.Parameters.Add("@Approve", SqlDbType.Bit).Value = approve;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update PurchaseOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update PurchaseOrder
		/// Calls [usp_update_PurchaseOrder_Close]
        /// </summary>
		public override bool UpdateClose(System.Int32? purchaseOrderId, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_PurchaseOrder_Close", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update PurchaseOrder", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        // [001] code start
        /// <summary>
        /// GetPDFListForPurchageOrder 
        /// Calls [usp_selectAll_PDF_for_PurchaseOrder]
        /// </summary>
        public override List<PDFDocumentDetails> GetPDFListForPurchageOrder(System.Int32? PurchaseOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_PDF_for_PurchaseOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@PurchaseOrderNo", SqlDbType.Int).Value = PurchaseOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PDFDocumentDetails> lstPDF = new List<PDFDocumentDetails>();
                while (reader.Read())
                {
                    PDFDocumentDetails obj = new PDFDocumentDetails();
                    obj.PDFDocumentId = GetReaderValue_Int32(reader, "PurchaseOrderPDFId", 0);
                    obj.PDFDocumentRefNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
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
                throw new Exception("Failed to get PDF list for purchase order", sqlex);
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
        /// Calls [usp_insert_PurchaseOrderPDF]
        /// </summary>
        public override Int32 Insert(System.Int32? PurchaseOrderId, System.String Caption, System.String FileName, System.Int32? UpdatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_PurchaseOrderPDF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = PurchaseOrderId;
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
                throw new Exception("Failed to insert purchase order pdf", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Delete purchase order pdf
        /// Calls[usp_delete_PurchaseOrderPDF]
        /// </summary>
        public override bool DeletePurchaseOrderPDF(System.Int32? PurchaseOrderPdfId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_PurchaseOrderPDF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PurchaseOrderPDFId", SqlDbType.Int).Value = PurchaseOrderPdfId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete purchase order pdf", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        
        // [001] code end
        //[006] start
        public override Int32 InsertExpedite(System.Int32? purchaseOrderId, System.String expediteNotes, System.Int32? UpdatedBy, System.String poLineIds,Boolean? isMailSent )
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_ExpediteNote", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
                cmd.Parameters.Add("@ExpediteNotes", SqlDbType.NVarChar).Value = expediteNotes;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UpdatedBy;
                cmd.Parameters.Add("@POLineNos", SqlDbType.NVarChar).Value = poLineIds;
                cmd.Parameters.Add("@IsMailSent", SqlDbType.Bit).Value = isMailSent;
                cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@NewId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert expedite note", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// GetForPrint 
        /// Calls [usp_select_PurchaseOrder_for_PrintPOReport]
        /// </summary>
        public override PurchaseOrderDetails GetForPrintPOReport(System.Int32? purchaseOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_PurchaseOrder_for_PrintPOReport", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetPurchaseOrderFromReader(reader);
                    PurchaseOrderDetails obj = new PurchaseOrderDetails();
                    obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
                    obj.ExpediteNotes = GetReaderValue_String(reader, "ExpediteNotes", "");
                    obj.ExpediteDate = GetReaderValue_NullableDateTime(reader, "ExpediteDate", null);
                    obj.TotalShipInCost = GetReaderValue_NullableDouble(reader, "TotalShipInCost", null);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
                    obj.Confirmed = GetReaderValue_Boolean(reader, "Confirmed", false);
                    obj.ImportCountryNo = GetReaderValue_NullableInt32(reader, "ImportCountryNo", null);
                    obj.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", "");
                    obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.ApprovedBy = GetReaderValue_NullableInt32(reader, "ApprovedBy", null);
                    obj.DateApproved = GetReaderValue_NullableDateTime(reader, "DateApproved", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.ImportCountryName = GetReaderValue_String(reader, "ImportCountryName", "");
                    obj.ImportCountryShippingCost = GetReaderValue_NullableDouble(reader, "ImportCountryShippingCost", null);
                    obj.PurchaseOrderValue = GetReaderValue_NullableDouble(reader, "PurchaseOrderValue", null);
                    obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    obj.CompanyPORating = GetReaderValue_NullableInt32(reader, "CompanyPORating", null);
                    obj.Approver = GetReaderValue_String(reader, "Approver", "");
                    obj.CompanyTelephone = GetReaderValue_String(reader, "CompanyTelephone", "");
                    obj.CompanyFax = GetReaderValue_String(reader, "CompanyFax", "");
                    obj.ContactEmail = GetReaderValue_String(reader, "ContactEmail", "");
                    obj.VATNO = GetReaderValue_String(reader, "VATNo", "");
                    obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
                    obj.CTName = GetReaderValue_String(reader, "CTName", "");//CTName->Company Type Name
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
                throw new Exception("Failed to get PurchaseOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Calls [usp_selectAll_Audit_approval_for_Expedite]
        /// </summary>
        public override List<PurchaseOrderDetails> GetListCompanyForPurchaseOrder(System.Int32? purchaseOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_PurchaseOrder_Update_Company_History", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PurchaseOrderDetails> lst = new List<PurchaseOrderDetails>();
                while (reader.Read())
                {
                    PurchaseOrderDetails obj = new PurchaseOrderDetails();

                    obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderId", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                   
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

        /// <summary>
        /// Calls [usp_Notify_IPO_after_SO_Checked]
        /// </summary>
        public override List<PurchaseOrderDetails> GetListIPOCreationMessage(System.Int32? salesOrderNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_Notify_IPO_after_SO_Checked", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SalesOrderNo", SqlDbType.Int).Value = salesOrderNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PurchaseOrderDetails> lst = new List<PurchaseOrderDetails>();
                while (reader.Read())
                {
                    PurchaseOrderDetails obj = new PurchaseOrderDetails();

                    obj.PurchaseOrderId = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
                    obj.InternalPurchaseOrderId = GetReaderValue_Int32(reader, "InternalPurchaseOrderId", 0);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0);
                    obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    //It come from tbsourcing restlt of buyer column
                    obj.Buyer = GetReaderValue_Int32(reader, "SourcingResultAttachedBy", 0);
                    //It come from tbsalesorder restlt of salesman column
                    obj.IPOBuyer = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.IPOBuyerName = GetReaderValue_String(reader, "IPOBuyerName", "");
 

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

      
		
		
    }
}