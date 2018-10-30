//Marker     Changed by      Date         Remarks
//[001]      Vinay           30/07/2012   Add compulsory incoterms field when create Credit and debit note. :ESMS No:- 105
//[002]      Shashi Keshar   24/10/2016   Checked print document is Reference of Hub. IsHUB
//[003]      Aashu Singh      01/06/2018   Quick Jump in Global Warehouse 
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
	public class SqlDebitProvider : DebitProvider {
		/// <summary>
		/// Count Debit
		/// Calls [usp_count_Debit_for_Company]
		/// </summary>
		public override Int32 CountForCompany(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_Debit_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count Debit", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete Debit
		/// Calls [usp_delete_Debit]
		/// </summary>
		public override bool Delete(System.Int32? debitId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Debit", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@DebitId", SqlDbType.Int).Value = debitId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Debit", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		//[001] code start
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_Debit]
		/// </summary>
		public override Int32 Insert(System.Int32? clientNo, System.Int32? companyNo, System.Int32? contactNo, System.DateTime? debitDate, System.Int32? currencyNo, System.Int32? raisedBy, System.Int32? buyer, System.String notes, System.String instructions, System.Double? freight, System.Int32? divisionNo, System.Int32? taxNo, System.Int32? purchaseOrderNo, System.Int32? supplierRmaNo, System.DateTime? referenceDate, System.String supplierInvoice, System.String supplierRma, System.String supplierCredit, System.Int32? updatedBy,System.Int32? IncotermsNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Debit", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@DebitDate", SqlDbType.DateTime).Value = debitDate;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@RaisedBy", SqlDbType.Int).Value = raisedBy;
				cmd.Parameters.Add("@Buyer", SqlDbType.Int).Value = buyer;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
				cmd.Parameters.Add("@Freight", SqlDbType.Float).Value = freight;
				cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
				cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
				cmd.Parameters.Add("@PurchaseOrderNo", SqlDbType.Int).Value = purchaseOrderNo;
				cmd.Parameters.Add("@SupplierRMANo", SqlDbType.Int).Value = supplierRmaNo;
				cmd.Parameters.Add("@ReferenceDate", SqlDbType.DateTime).Value = referenceDate;
				cmd.Parameters.Add("@SupplierInvoice", SqlDbType.NVarChar).Value = supplierInvoice;
				cmd.Parameters.Add("@SupplierRMA", SqlDbType.NVarChar).Value = supplierRma;
				cmd.Parameters.Add("@SupplierCredit", SqlDbType.NVarChar).Value = supplierCredit;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@IncotermNo", SqlDbType.Int).Value = IncotermsNo;
				cmd.Parameters.Add("@DebitId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@DebitId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Debit", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
        //[001] code end
		
        /// <summary>
        /// ItemSearch 
		/// Calls [usp_itemsearch_Debit]
        /// </summary>
		public override List<DebitDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.Int32? debitNoLo, System.Int32? debitNoHi, System.Int32? supplierRmaNoLo, System.Int32? supplierRmaNoHi, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? debitDateFrom, System.DateTime? debitDateTo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_itemsearch_Debit", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
				cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
				cmd.Parameters.Add("@SalesmanSearch", SqlDbType.Int).Value = salesmanSearch;
				cmd.Parameters.Add("@DebitNoLo", SqlDbType.Int).Value = debitNoLo;
				cmd.Parameters.Add("@DebitNoHi", SqlDbType.Int).Value = debitNoHi;
				cmd.Parameters.Add("@SupplierRMANoLo", SqlDbType.Int).Value = supplierRmaNoLo;
				cmd.Parameters.Add("@SupplierRMANoHi", SqlDbType.Int).Value = supplierRmaNoHi;
				cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
				cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
				cmd.Parameters.Add("@DebitDateFrom", SqlDbType.DateTime).Value = debitDateFrom;
				cmd.Parameters.Add("@DebitDateTo", SqlDbType.DateTime).Value = debitDateTo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<DebitDetails> lst = new List<DebitDetails>();
				while (reader.Read()) {
					DebitDetails obj = new DebitDetails();
					obj.DebitId = GetReaderValue_Int32(reader, "DebitId", 0);
					obj.DebitNumber = GetReaderValue_Int32(reader, "DebitNumber", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.DebitDate = GetReaderValue_DateTime(reader, "DebitDate", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.RaiserName = GetReaderValue_String(reader, "RaiserName", "");
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Debits", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_Debit]
        /// </summary>
		public override DebitDetails Get(System.Int32? debitId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Debit", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@DebitId", SqlDbType.Int).Value = debitId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetDebitFromReader(reader);
					DebitDetails obj = new DebitDetails();
					obj.DebitId = GetReaderValue_Int32(reader, "DebitId", 0);
					obj.DebitNumber = GetReaderValue_Int32(reader, "DebitNumber", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.DebitDate = GetReaderValue_DateTime(reader, "DebitDate", DateTime.MinValue);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.RaisedBy = GetReaderValue_NullableInt32(reader, "RaisedBy", null);
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
					obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.ReferenceDate = GetReaderValue_DateTime(reader, "ReferenceDate", DateTime.MinValue);
					obj.SupplierInvoice = GetReaderValue_String(reader, "SupplierInvoice", "");
					obj.SupplierRMA = GetReaderValue_String(reader, "SupplierRMA", "");
					obj.SupplierCredit = GetReaderValue_String(reader, "SupplierCredit", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.RaiserName = GetReaderValue_String(reader, "RaiserName", "");
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
					obj.PurchaseOrderDate = GetReaderValue_DateTime(reader, "PurchaseOrderDate", DateTime.MinValue);
					obj.DebitValue = GetReaderValue_NullableDouble(reader, "DebitValue", null);
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                    //[001] code start
                    obj.IncotermsNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.IncotermsName = GetReaderValue_String(reader, "IncotermsName", "");
                    //[001] code end
                    obj.InternalPurchaseOrderNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNo", 0);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNumber", 0);
                    obj.POHubCompanyNo = GetReaderValue_NullableInt32(reader, "IPOCompanyNo", 0);
                    obj.POHubCompanyName = GetReaderValue_String(reader, "IPOCompanyName", "");
                    obj.RefNumber = GetReaderValue_NullableInt32(reader, "RefNumber", null);
                    obj.DebitParentId = GetReaderValue_NullableInt32(reader, "DebitParentId", null);
                    obj.ishublocked = GetReaderValue_NullableBoolean(reader, "ishublocked", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Debit", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForPage 
		/// Calls [usp_select_Debit_for_Page]
        /// </summary>
		public override DebitDetails GetForPage(System.Int32? debitId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Debit_for_Page", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@DebitId", SqlDbType.Int).Value = debitId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetDebitFromReader(reader);
					DebitDetails obj = new DebitDetails();
					obj.DebitId = GetReaderValue_Int32(reader, "DebitId", 0);
					obj.DebitNumber = GetReaderValue_Int32(reader, "DebitNumber", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", 0);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
                    obj.POHubCompanyNo = GetReaderValue_NullableInt32(reader, "IPOCompanyNo", 0);
                    obj.POHubCompanyName = GetReaderValue_String(reader, "IPOCompanyName", "");
                    obj.InternalPurchaseOrderNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderId", null);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Debit", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForPrint 
		/// Calls [usp_select_Debit_for_Print]
        /// </summary>
        public override DebitDetails GetForPrint(System.Int32? debitNo, bool IsHUBdebitNo)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Debit_for_Print", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@DebitNo", SqlDbType.Int).Value = debitNo;
                //[002] Start Here
                cmd.Parameters.Add("@IsHUBdebitNo", SqlDbType.Bit).Value = IsHUBdebitNo;
                //[002]  End Here
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetDebitFromReader(reader);
					DebitDetails obj = new DebitDetails();
					obj.DebitId = GetReaderValue_Int32(reader, "DebitId", 0);
					obj.DebitNumber = GetReaderValue_Int32(reader, "DebitNumber", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.DebitDate = GetReaderValue_DateTime(reader, "DebitDate", DateTime.MinValue);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.RaisedBy = GetReaderValue_NullableInt32(reader, "RaisedBy", null);
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
					obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.ReferenceDate = GetReaderValue_DateTime(reader, "ReferenceDate", DateTime.MinValue);
					obj.SupplierInvoice = GetReaderValue_String(reader, "SupplierInvoice", "");
					obj.SupplierRMA = GetReaderValue_String(reader, "SupplierRMA", "");
					obj.SupplierCredit = GetReaderValue_String(reader, "SupplierCredit", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.RaiserName = GetReaderValue_String(reader, "RaiserName", "");
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
					obj.PurchaseOrderDate = GetReaderValue_DateTime(reader, "PurchaseOrderDate", DateTime.MinValue);
					obj.DebitValue = GetReaderValue_NullableDouble(reader, "DebitValue", null);
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					obj.CompanyTelephone = GetReaderValue_String(reader, "CompanyTelephone", "");
					obj.CompanyFax = GetReaderValue_String(reader, "CompanyFax", "");
					obj.ContactEmail = GetReaderValue_String(reader, "ContactEmail", "");
                    obj.VATNO = GetReaderValue_String(reader, "VATNo", "");
                    obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
                    obj.POHubCompanyNo = GetReaderValue_NullableInt32(reader, "POHubCompanyNo", null);
                    obj.POHubCompanyName = GetReaderValue_String(reader, "POHubCompanyName", "");
                    obj.ClientRefNo = GetReaderValue_String(reader, "ClientRefNo", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Debit", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetIdByNumber 
		/// Calls [usp_select_Debit_Id_by_Number]
        /// </summary>
        //[003] start
        public override List<DebitDetails> GetIdByNumber(System.Int32? debitNumber, System.Int32? clientNo, System.Int32? isGlobalUser)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
            List<DebitDetails> lstDebitDetail = new List<DebitDetails>();
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Debit_Id_by_Number", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@DebitNumber", SqlDbType.Int).Value = debitNumber;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@IsGlobalUser", SqlDbType.Int).Value = isGlobalUser;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				while (reader.Read()) {
					//return GetDebitFromReader(reader);
					DebitDetails obj = new DebitDetails();
					obj.DebitId = GetReaderValue_Int32(reader, "DebitId", 0);
                    obj.DebitDetailNumber = GetReaderValue_String(reader, "DebitDetailNumber", "true");
                    lstDebitDetail.Add(obj);
				}
                return lstDebitDetail;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Debit", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
        // [003] end
		
        /// <summary>
        /// GetNextNumber 
		/// Calls [usp_select_Debit_NextNumber]
        /// </summary>
		public override DebitDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Debit_NextNumber", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@NewNumber", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetDebitFromReader(reader);
					DebitDetails obj = new DebitDetails();
					obj.DebitNumber = GetReaderValue_Int32(reader, "DebitNumber", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Debit", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForCompany 
		/// Calls [usp_selectAll_Debit_for_Company]
        /// </summary>
		public override List<DebitDetails> GetListForCompany(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Debit_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<DebitDetails> lst = new List<DebitDetails>();
				while (reader.Read()) {
					DebitDetails obj = new DebitDetails();
					obj.DebitId = GetReaderValue_Int32(reader, "DebitId", 0);
					obj.DebitNumber = GetReaderValue_Int32(reader, "DebitNumber", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
					obj.DebitDate = GetReaderValue_DateTime(reader, "DebitDate", DateTime.MinValue);
					obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
					obj.RaisedBy = GetReaderValue_NullableInt32(reader, "RaisedBy", null);
					obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
					obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
					obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.ReferenceDate = GetReaderValue_DateTime(reader, "ReferenceDate", DateTime.MinValue);
					obj.SupplierInvoice = GetReaderValue_String(reader, "SupplierInvoice", "");
					obj.SupplierRMA = GetReaderValue_String(reader, "SupplierRMA", "");
					obj.SupplierCredit = GetReaderValue_String(reader, "SupplierCredit", "");
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.RaiserName = GetReaderValue_String(reader, "RaiserName", "");
					obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
					obj.PurchaseOrderDate = GetReaderValue_DateTime(reader, "PurchaseOrderDate", DateTime.MinValue);
					obj.DebitValue = GetReaderValue_NullableDouble(reader, "DebitValue", null);
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Debits", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Debit
		/// Calls [usp_update_Debit]
        /// </summary>
        public override bool Update(System.Int32? debitId, System.String supplierInvoice, System.String supplierRma, System.String supplierCredit, System.Double? freight, System.String notes, System.String instructions, System.Int32? divisionNo, System.Int32? buyer, System.Int32? raisedBy, System.DateTime? debitDate, System.DateTime? referenceDate, System.Int32? taxNo, System.Int32? currencyNo, System.Int32? updatedBy, System.Int32? IncotermNo, bool? isLockUpdateClient)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Debit", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@DebitId", SqlDbType.Int).Value = debitId;
				cmd.Parameters.Add("@SupplierInvoice", SqlDbType.NVarChar).Value = supplierInvoice;
				cmd.Parameters.Add("@SupplierRMA", SqlDbType.NVarChar).Value = supplierRma;
				cmd.Parameters.Add("@SupplierCredit", SqlDbType.NVarChar).Value = supplierCredit;
				cmd.Parameters.Add("@Freight", SqlDbType.Float).Value = freight;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
				cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
				cmd.Parameters.Add("@Buyer", SqlDbType.Int).Value = buyer;
				cmd.Parameters.Add("@RaisedBy", SqlDbType.Int).Value = raisedBy;
				cmd.Parameters.Add("@DebitDate", SqlDbType.DateTime).Value = debitDate;
				cmd.Parameters.Add("@ReferenceDate", SqlDbType.DateTime).Value = referenceDate;
				cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //[001] code start
                cmd.Parameters.Add("@IncotermNo", SqlDbType.Int).Value = IncotermNo;
                //[001] code end

                cmd.Parameters.Add("@isLockUpdateClient", SqlDbType.Bit).Value = isLockUpdateClient;

				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Debit", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}