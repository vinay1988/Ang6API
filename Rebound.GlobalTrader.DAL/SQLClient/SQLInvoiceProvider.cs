/*
Marker     Changed by      Date         Remarks
[001]      Pankaj Kumar    05/09/20011  ESMS Ref:13 - Include CompanyRegNo in GetForPrint methods
[002]      Vinay Kumar     17/05/2012   Add currency notes field
[003]      Vinay           13/07/2012   Rebound- Invoice bulk Emailer
[004]      Vinay           23/08/2012   Customize the invoice control for exported record, Set Exported=1
[005]      Vinay           21/09/2012   Add expoted only filter
[006]      Vinay           12/10/2012   Upload PDF document for invoices
[007]      Vinay           01/11/2012   Add comma(,) seprated credit notes and CustomerRMA in invoice section
[008]      Vinay           22/11/2012   Add Failed only  filter
[009]      Vinay           29/11/2012   Apply a bank fee charge to the customers final invoice  
[010]      Aashu           01/06/2018   Quick Jump in Global Warehouse
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
	public class SqlInvoiceProvider : InvoiceProvider {
		/// <summary>
		/// Count Invoice
		/// Calls [usp_count_Invoice_for_Client]
		/// </summary>
		public override Int32 CountForClient(System.Int32? clientId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_Invoice_for_Client", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count Invoice", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Count Invoice
		/// Calls [usp_count_Invoice_for_Company]
		/// </summary>
		public override Int32 CountForCompany(System.Int32? companyId, System.Boolean? includePaid) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_Invoice_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cmd.Parameters.Add("@IncludePaid", SqlDbType.Bit).Value = includePaid;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count Invoice", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Count Invoice
		/// Calls [usp_count_Invoice_Open_for_Company]
		/// </summary>
		public override Int32 CountOpenForCompany(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_Invoice_Open_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = companyId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count Invoice", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		//[005],[008] code start
        /// <summary>
        /// DataListNugget 
		/// Calls [usp_datalistnugget_Invoice]
        /// </summary>
        public override List<InvoiceDetails> DataListNugget(System.Int32? clientId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String cmSearch, System.Int32? salesmanSearch, System.String customerPoSearch, System.Boolean? includePaid, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? invoiceDateFrom, System.DateTime? invoiceDateTo, System.Boolean? recentOnly, System.Boolean? exportedOnly,System.Boolean? failedOnly,System.Boolean? notExported)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_datalistnugget_Invoice", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 60;
				cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
				cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
				cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
				cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
				cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
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
                if (exportedOnly.Value)
                    cmd.Parameters.Add("@ExportedOnly", SqlDbType.Bit).Value = exportedOnly;
                else
                    cmd.Parameters.Add("@ExportedOnly", SqlDbType.Bit).Value = DBNull.Value;
                if (failedOnly.Value)
                    cmd.Parameters.Add("@FailedOnly", SqlDbType.Bit).Value = failedOnly;
                else
                    cmd.Parameters.Add("@FailedOnly", SqlDbType.Bit).Value = DBNull.Value; 
                if(notExported.Value)
                    cmd.Parameters.Add("@NotExported", SqlDbType.Bit).Value = notExported;
                else
                    cmd.Parameters.Add("@NotExported", SqlDbType.Bit).Value = DBNull.Value;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<InvoiceDetails> lst = new List<InvoiceDetails>();
				while (reader.Read()) {
					InvoiceDetails obj = new InvoiceDetails();
					obj.InvoiceId = GetReaderValue_Int32(reader, "InvoiceId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.CompanyBillTo = GetReaderValue_String(reader, "CompanyBillTo", "");
					obj.CompanyShipTo = GetReaderValue_String(reader, "CompanyShipTo", "");
					obj.ShipViaNo = GetReaderValue_Int32(reader, "ShipViaNo", 0);
					obj.Account = GetReaderValue_String(reader, "Account", "");
					obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", "");
					obj.Boxes = GetReaderValue_NullableInt32(reader, "Boxes", null);
					obj.Weight = GetReaderValue_NullableDouble(reader, "Weight", null);
					obj.DimensionalWeight = GetReaderValue_NullableDouble(reader, "DimensionalWeight", null);
					obj.WeightInPounds = GetReaderValue_Boolean(reader, "WeightInPounds", false);
					obj.AirWayBill = GetReaderValue_String(reader, "AirWayBill", "");
					obj.ShippedBy = GetReaderValue_NullableInt32(reader, "ShippedBy", null);
					obj.Printed = GetReaderValue_NullableInt32(reader, "Printed", null);
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.ShippingNotes = GetReaderValue_String(reader, "ShippingNotes", "");
					obj.Exported = GetReaderValue_Boolean(reader, "Exported", false);
					obj.InvoicePaid = GetReaderValue_Boolean(reader, "InvoicePaid", false);
					obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
					obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null);
					obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
					obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.CofCNotes = GetReaderValue_String(reader, "CofCNotes", "");
					obj.BillToAddressNo = GetReaderValue_NullableInt32(reader, "BillToAddressNo", null);
					obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.ShippedByName = GetReaderValue_String(reader, "ShippedByName", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
					obj.VATNo = GetReaderValue_String(reader, "VATNo", "");
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
					obj.InvoiceValue = GetReaderValue_NullableDouble(reader, "InvoiceValue", null);
					obj.LandedCostValue = GetReaderValue_NullableDouble(reader, "LandedCostValue", null);
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					obj.StatusText = GetReaderValue_String(reader, "StatusText", "");
					obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Invoices", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
        //[005] code end
		
		/// <summary>
		/// Delete Invoice
		/// Calls [usp_delete_Invoice]
		/// </summary>
		public override bool Delete(System.Int32? invoiceId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Invoice", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = invoiceId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Invoice", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_Invoice]
		/// </summary>
		public override Int32 Insert(System.Int32? clientNo, System.Int32? salesOrderNo, System.DateTime? invoiceDate, System.String notes, System.String instructions, System.Int32? shipViaNo, System.String account, System.Double? shippingCost, System.Double? freight, System.String freeOnBoard, System.Int32? boxes, System.Double? weight, System.Double? dimensionalWeight, System.Boolean? weightInPounds, System.String airWayBill, System.Int32? shippedBy, System.Int32? printed, System.Int32? supplierRmaNo, System.String shippingNotes, System.Boolean? exported, System.Boolean? invoicePaid, System.Int32? salesOrderNumber, System.Int32? companyNo, System.Int32? contactNo, System.DateTime? dateOrdered, System.Int32? currencyNo, System.Int32? salesman, System.Int32? termsNo, System.Int32? taxNo, System.Int32? billToAddressNo, System.String companyBillTo, System.Int32? shipToAddressNo, System.String companyShipTo, System.Int32? divisionNo, System.String customerPo, System.Int32? salesman2, System.Double? salesman2Percent, System.Int32? incotermNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Invoice", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@SalesOrderNo", SqlDbType.Int).Value = salesOrderNo;
				cmd.Parameters.Add("@InvoiceDate", SqlDbType.DateTime).Value = invoiceDate;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
				cmd.Parameters.Add("@ShipViaNo", SqlDbType.Int).Value = shipViaNo;
				cmd.Parameters.Add("@Account", SqlDbType.NVarChar).Value = account;
				cmd.Parameters.Add("@ShippingCost", SqlDbType.Float).Value = shippingCost;
				cmd.Parameters.Add("@Freight", SqlDbType.Float).Value = freight;
				cmd.Parameters.Add("@FreeOnBoard", SqlDbType.NVarChar).Value = freeOnBoard;
				cmd.Parameters.Add("@Boxes", SqlDbType.Int).Value = boxes;
				cmd.Parameters.Add("@Weight", SqlDbType.Float).Value = weight;
				cmd.Parameters.Add("@DimensionalWeight", SqlDbType.Float).Value = dimensionalWeight;
				cmd.Parameters.Add("@WeightInPounds", SqlDbType.Bit).Value = weightInPounds;
				cmd.Parameters.Add("@AirWayBill", SqlDbType.NVarChar).Value = airWayBill;
				cmd.Parameters.Add("@ShippedBy", SqlDbType.Int).Value = shippedBy;
				cmd.Parameters.Add("@Printed", SqlDbType.Int).Value = printed;
				cmd.Parameters.Add("@SupplierRMANo", SqlDbType.Int).Value = supplierRmaNo;
				cmd.Parameters.Add("@ShippingNotes", SqlDbType.NVarChar).Value = shippingNotes;
				cmd.Parameters.Add("@Exported", SqlDbType.Bit).Value = exported;
				cmd.Parameters.Add("@InvoicePaid", SqlDbType.Bit).Value = invoicePaid;
				cmd.Parameters.Add("@SalesOrderNumber", SqlDbType.Int).Value = salesOrderNumber;
				cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
				cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
				cmd.Parameters.Add("@DateOrdered", SqlDbType.DateTime).Value = dateOrdered;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@TermsNo", SqlDbType.Int).Value = termsNo;
				cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
				cmd.Parameters.Add("@BillToAddressNo", SqlDbType.Int).Value = billToAddressNo;
				cmd.Parameters.Add("@CompanyBillTo", SqlDbType.NVarChar).Value = companyBillTo;
				cmd.Parameters.Add("@ShipToAddressNo", SqlDbType.Int).Value = shipToAddressNo;
				cmd.Parameters.Add("@CompanyShipTo", SqlDbType.NVarChar).Value = companyShipTo;
				cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
				cmd.Parameters.Add("@CustomerPO", SqlDbType.NVarChar).Value = customerPo;
				cmd.Parameters.Add("@Salesman2", SqlDbType.Int).Value = salesman2;
				cmd.Parameters.Add("@Salesman2Percent", SqlDbType.Float).Value = salesman2Percent;
				cmd.Parameters.Add("@IncotermNo", SqlDbType.Int).Value = incotermNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@InvoiceId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@InvoiceId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Invoice", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
        //[003] code start
        public override List<System.String> InsertIntoInvoiceEmail(System.String Invoices, System.Int32? updatedBy,System.Boolean? blnCOC)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_InvoiceEmail", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@InvoiceNos", SqlDbType.Xml).Value = Invoices;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@AttachCOC", SqlDbType.Bit).Value = blnCOC;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<System.String> lst = new List<System.String>();
                while (reader.Read())
                {
                    lst.Add(GetReaderValue_String(reader, "InvoiceNumber", "0"));
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert InvoiceEmail", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        public override string GetEmailStatusByInvoiceEmailNo(System.Int32? InvoiceEmailNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_InvoiceEmailbyId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@InvoiceEmailId", SqlDbType.Int).Value = InvoiceEmailNo;
                cn.Open();
                string ret = "";
                DbDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (reader.Read())
                {
                  ret=   GetReaderValue_String(reader, "Reason", "");
                }
                return ret;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert InvoiceEmail", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[003] code end
		
        /// <summary>
        /// ItemSearch 
		/// Calls [usp_itemsearch_Invoice]
        /// </summary>
        public override List<InvoiceDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String customerPoSearch, System.Boolean? includePaid, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? invoiceDateFrom, System.DateTime? invoiceDateTo,System.Int32? Exported)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_itemsearch_Invoice", cn);
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
				cmd.Parameters.Add("@CustomerPOSearch", SqlDbType.NVarChar).Value = customerPoSearch;
				cmd.Parameters.Add("@IncludePaid", SqlDbType.Bit).Value = includePaid;
				cmd.Parameters.Add("@InvoiceNoLo", SqlDbType.Int).Value = invoiceNoLo;
				cmd.Parameters.Add("@InvoiceNoHi", SqlDbType.Int).Value = invoiceNoHi;
				cmd.Parameters.Add("@SalesOrderNoLo", SqlDbType.Int).Value = salesOrderNoLo;
				cmd.Parameters.Add("@SalesOrderNoHi", SqlDbType.Int).Value = salesOrderNoHi;
				cmd.Parameters.Add("@InvoiceDateFrom", SqlDbType.DateTime).Value = invoiceDateFrom;
				cmd.Parameters.Add("@InvoiceDateTo", SqlDbType.DateTime).Value = invoiceDateTo;
                if (Exported != null)
                    cmd.Parameters.Add("@Exported", SqlDbType.Int).Value = Exported;
                else
                    cmd.Parameters.Add("@Exported", SqlDbType.Int).Value = DBNull.Value;

				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<InvoiceDetails> lst = new List<InvoiceDetails>();
				while (reader.Read()) {
					InvoiceDetails obj = new InvoiceDetails();
					obj.InvoiceId = GetReaderValue_Int32(reader, "InvoiceId", 0);
					obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
					obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Invoices", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_Invoice]
        /// </summary>
		public override InvoiceDetails Get(System.Int32? invoiceId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Invoice", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = invoiceId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);                
				if (reader.Read()) {
					//return GetInvoiceFromReader(reader);
					InvoiceDetails obj = new InvoiceDetails();
					obj.InvoiceId = GetReaderValue_Int32(reader, "InvoiceId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.CompanyBillTo = GetReaderValue_String(reader, "CompanyBillTo", "");
					obj.CompanyShipTo = GetReaderValue_String(reader, "CompanyShipTo", "");
					obj.ShipViaNo = GetReaderValue_Int32(reader, "ShipViaNo", 0);
					obj.Account = GetReaderValue_String(reader, "Account", "");
					obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", "");
					obj.Boxes = GetReaderValue_NullableInt32(reader, "Boxes", null);
					obj.Weight = GetReaderValue_NullableDouble(reader, "Weight", null);
					obj.DimensionalWeight = GetReaderValue_NullableDouble(reader, "DimensionalWeight", null);
					obj.WeightInPounds = GetReaderValue_Boolean(reader, "WeightInPounds", false);
					obj.AirWayBill = GetReaderValue_String(reader, "AirWayBill", "");
					obj.ShippedBy = GetReaderValue_NullableInt32(reader, "ShippedBy", null);
					obj.Printed = GetReaderValue_NullableInt32(reader, "Printed", null);
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.ShippingNotes = GetReaderValue_String(reader, "ShippingNotes", "");
					obj.Exported = GetReaderValue_Boolean(reader, "Exported", false);
					obj.InvoicePaid = GetReaderValue_Boolean(reader, "InvoicePaid", false);
					obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
					obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null);
					obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
					obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.CofCNotes = GetReaderValue_String(reader, "CofCNotes", "");
					obj.BillToAddressNo = GetReaderValue_NullableInt32(reader, "BillToAddressNo", null);
					obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.ShippedByName = GetReaderValue_String(reader, "ShippedByName", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
					obj.VATNo = GetReaderValue_String(reader, "VATNo", "");
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
					obj.InvoiceValue = GetReaderValue_NullableDouble(reader, "InvoiceValue", null);
					obj.LandedCostValue = GetReaderValue_NullableDouble(reader, "LandedCostValue", null);
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					obj.StatusText = GetReaderValue_String(reader, "StatusText", "");
					obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    obj.SalesOrderNOs = GetReaderValue_String(reader, "SalesOrderNos", "");
                    obj.SalesOrderNumbers = GetReaderValue_String(reader, "SalesOrderNumbers", "");
                    //[007] code start
                    obj.CRMAIds = GetReaderValue_String(reader, "CRMAIds", "");
                    obj.CRMANumbers = GetReaderValue_String(reader, "CRMANumbers", "");
                    obj.CreditIds = GetReaderValue_String(reader, "CreditIds", "");
                    obj.CreditNumbers = GetReaderValue_String(reader, "CreditNumbers", "");
                    //[007] code end
                    //[009] code start
                    obj.InvoiceBankFee = GetReaderValue_Double(reader, "InvoiceBankFee", 0);
                    obj.IsApplyBankFee = GetReaderValue_NullableBoolean(reader, "IsApplyBankFee", false);
                    //[009] code end
                    obj.ExchangeRate = GetReaderValue_NullableDouble(reader, "ExchangeRate", null);
                    obj.InvoicePaidDate = GetReaderValue_NullableDateTime(reader, "InvoicePaidDate", null);
                    obj.IsSameAsShipCost = GetReaderValue_NullableBoolean(reader, "IsSameAsShipCost", false);
                    obj.ShippingSurchargeValue = GetReaderValue_Double(reader, "ShippingSurchargeValue", 0);

					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Invoice", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetByNumber 
		/// Calls [usp_select_Invoice_by_Number]
        /// </summary>
		public override InvoiceDetails GetByNumber(System.Int32? invoiceNumber, System.Int32? clientNo) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Invoice_by_Number", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = invoiceNumber;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetInvoiceFromReader(reader);
					InvoiceDetails obj = new InvoiceDetails();
					obj.InvoiceId = GetReaderValue_Int32(reader, "InvoiceId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.CompanyBillTo = GetReaderValue_String(reader, "CompanyBillTo", "");
					obj.CompanyShipTo = GetReaderValue_String(reader, "CompanyShipTo", "");
					obj.ShipViaNo = GetReaderValue_Int32(reader, "ShipViaNo", 0);
					obj.Account = GetReaderValue_String(reader, "Account", "");
					obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", "");
					obj.Boxes = GetReaderValue_NullableInt32(reader, "Boxes", null);
					obj.Weight = GetReaderValue_NullableDouble(reader, "Weight", null);
					obj.DimensionalWeight = GetReaderValue_NullableDouble(reader, "DimensionalWeight", null);
					obj.WeightInPounds = GetReaderValue_Boolean(reader, "WeightInPounds", false);
					obj.AirWayBill = GetReaderValue_String(reader, "AirWayBill", "");
					obj.ShippedBy = GetReaderValue_NullableInt32(reader, "ShippedBy", null);
					obj.Printed = GetReaderValue_NullableInt32(reader, "Printed", null);
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.ShippingNotes = GetReaderValue_String(reader, "ShippingNotes", "");
					obj.Exported = GetReaderValue_Boolean(reader, "Exported", false);
					obj.InvoicePaid = GetReaderValue_Boolean(reader, "InvoicePaid", false);
					obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
					obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null);
					obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
					obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.CofCNotes = GetReaderValue_String(reader, "CofCNotes", "");
					obj.BillToAddressNo = GetReaderValue_NullableInt32(reader, "BillToAddressNo", null);
					obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.ShippedByName = GetReaderValue_String(reader, "ShippedByName", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
					obj.VATNo = GetReaderValue_String(reader, "VATNo", "");
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
					obj.InvoiceValue = GetReaderValue_NullableDouble(reader, "InvoiceValue", null);
					obj.LandedCostValue = GetReaderValue_NullableDouble(reader, "LandedCostValue", null);
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					obj.StatusText = GetReaderValue_String(reader, "StatusText", "");
					obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Invoice", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForPage 
		/// Calls [usp_select_Invoice_for_Page]
        /// </summary>
		public override InvoiceDetails GetForPage(System.Int32? invoiceId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Invoice_for_Page", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = invoiceId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetInvoiceFromReader(reader);
					InvoiceDetails obj = new InvoiceDetails();
					obj.InvoiceId = GetReaderValue_Int32(reader, "InvoiceId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.StatusText = GetReaderValue_String(reader, "StatusText", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", 0);
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", 0);
                    obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", 0);
                    //[006] code start
                    obj.IsPDFAvailable = GetReaderValue_NullableBoolean(reader, "IsPDFAvailable", false);
                    //[006] code end
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Invoice", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetForPrint 
		/// Calls [usp_select_Invoice_for_Print]
        /// </summary>
		public override InvoiceDetails GetForPrint(System.Int32? invoiceId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Invoice_for_Print", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = invoiceId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetInvoiceFromReader(reader);
					InvoiceDetails obj = new InvoiceDetails();
					obj.InvoiceId = GetReaderValue_Int32(reader, "InvoiceId", 0);
					obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
					obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
					obj.Notes = GetReaderValue_String(reader, "Notes", "");
					obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
					obj.CompanyBillTo = GetReaderValue_String(reader, "CompanyBillTo", "");
					obj.CompanyShipTo = GetReaderValue_String(reader, "CompanyShipTo", "");
					obj.ShipViaNo = GetReaderValue_Int32(reader, "ShipViaNo", 0);
					obj.Account = GetReaderValue_String(reader, "Account", "");
					obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", "");
					obj.Boxes = GetReaderValue_NullableInt32(reader, "Boxes", null);
					obj.Weight = GetReaderValue_NullableDouble(reader, "Weight", null);
					obj.DimensionalWeight = GetReaderValue_NullableDouble(reader, "DimensionalWeight", null);
					obj.WeightInPounds = GetReaderValue_Boolean(reader, "WeightInPounds", false);
					obj.AirWayBill = GetReaderValue_String(reader, "AirWayBill", "");
					obj.ShippedBy = GetReaderValue_NullableInt32(reader, "ShippedBy", null);
					obj.Printed = GetReaderValue_NullableInt32(reader, "Printed", null);
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.ShippingNotes = GetReaderValue_String(reader, "ShippingNotes", "");
					obj.Exported = GetReaderValue_Boolean(reader, "Exported", false);
					obj.InvoicePaid = GetReaderValue_Boolean(reader, "InvoicePaid", false);
					obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
					obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null);
					obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
					obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
					obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.DateOrdered = GetReaderValue_NullableDateTime(reader, "DateOrdered", null);
					obj.CofCNotes = GetReaderValue_String(reader, "CofCNotes", "");
					obj.BillToAddressNo = GetReaderValue_NullableInt32(reader, "BillToAddressNo", null);
					obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
					obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
					obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
					obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
					obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
					obj.ShippedByName = GetReaderValue_String(reader, "ShippedByName", "");
					obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
					obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
					obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
					obj.VATNo = GetReaderValue_String(reader, "VATNo", "");
					obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
					obj.InvoiceValue = GetReaderValue_NullableDouble(reader, "InvoiceValue", null);
					obj.LandedCostValue = GetReaderValue_NullableDouble(reader, "LandedCostValue", null);
					obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
					obj.StatusText = GetReaderValue_String(reader, "StatusText", "");
					obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
					obj.CompanyTelephone = GetReaderValue_String(reader, "CompanyTelephone", "");
					obj.CompanyFax = GetReaderValue_String(reader, "CompanyFax", "");
					obj.ContactEmail = GetReaderValue_String(reader, "ContactEmail", "");
					obj.PrintNotes = GetReaderValue_String(reader, "PrintNotes", "");
                    //[001] Code start
                    obj.CompanyRegNo = GetReaderValue_String(reader, "CompanyRegNo", "");
                    //[001] Code end
                    //[002] code start
                    obj.CurrencyNotes = GetReaderValue_String(reader, "CurrencyNotes", "");
                    //[002] code end
                    //[009] code start
                    obj.InvoiceBankFee = GetReaderValue_Double(reader, "InvoiceBankFee", 0);
                    obj.IsApplyBankFee = GetReaderValue_NullableBoolean(reader, "IsApplyBankFee", false);
                    //[009] code end
                    obj.ExchangeRate = GetReaderValue_NullableDouble(reader, "ExchangeRate", null);
                    obj.LocalCurrencyNo = GetReaderValue_NullableInt32(reader, "LocalCurrencyNo", 0);
                    obj.ApplyLocalCurrency = GetReaderValue_NullableBoolean(reader, "ApplyLocalCurrency", false);
                    obj.LocalCurrencyCode = GetReaderValue_String(reader, "LocalCurrencyCode", "");
                    obj.ShipToVatNo = GetReaderValue_String(reader, "ShipToVatNo", "");
                    obj.NotesToInvoice = GetReaderValue_String(reader, "NotesToInvoice", "");
                    obj.SerialInvoice = GetReaderValue_String(reader, "SerialNo", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Invoice", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetIDByNumber 
		/// Calls [usp_select_Invoice_ID_by_Number]
        /// </summary>
        // [010] start        
        public override List<InvoiceDetails> GetIDByNumber(System.Int32? invoiceNumber, System.Int32? clientNo, System.Int32? isGlobalUser)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
            List<InvoiceDetails> lstInvoice=new List<InvoiceDetails>();
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Invoice_ID_by_Number", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@InvoiceNumber", SqlDbType.Int).Value = invoiceNumber;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@IsGlobalUser", SqlDbType.Int).Value = isGlobalUser;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				while (reader.Read()) {
					//return GetInvoiceFromReader(reader);
					InvoiceDetails obj = new InvoiceDetails();
					obj.InvoiceId = GetReaderValue_Int32(reader, "InvoiceId", 0);
                    obj.InvoiceDetail = GetReaderValue_String(reader, "InvoiceDetail","true");
                    lstInvoice.Add(obj);
					//return obj;
				}
                return lstInvoice;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Invoice", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		// [010] end
		
        /// <summary>
        /// GetNextNumber 
		/// Calls [usp_select_Invoice_NextNumber]
        /// </summary>
		public override InvoiceDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Invoice_NextNumber", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@NewNumber", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetInvoiceFromReader(reader);
					InvoiceDetails obj = new InvoiceDetails();
					obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Invoice", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetStatusText 
		/// Calls [usp_select_Invoice_StatusText]
        /// </summary>
		public override InvoiceDetails GetStatusText(System.Int32? invoiceId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Invoice_StatusText", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = invoiceId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetInvoiceFromReader(reader);
					InvoiceDetails obj = new InvoiceDetails();
					obj.StatusText = GetReaderValue_String(reader, "StatusText", "");
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Invoice", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForCompany 
		/// Calls [usp_selectAll_Invoice_for_Company]
        /// </summary>
		public override List<InvoiceDetails> GetListForCompany(System.Int32? companyId, System.Boolean? includePaid) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Invoice_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cmd.Parameters.Add("@IncludePaid", SqlDbType.Bit).Value = includePaid;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<InvoiceDetails> lst = new List<InvoiceDetails>();
				while (reader.Read()) {
					InvoiceDetails obj = new InvoiceDetails();
					obj.InvoiceId = GetReaderValue_Int32(reader, "InvoiceId", 0);
					obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.InvoiceValue = GetReaderValue_NullableDouble(reader, "InvoiceValue", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Invoices", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListOpenForCompany 
		/// Calls [usp_selectAll_Invoice_Open_for_Company]
        /// </summary>
		public override List<InvoiceDetails> GetListOpenForCompany(System.Int32? companyId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Invoice_Open_for_Company", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<InvoiceDetails> lst = new List<InvoiceDetails>();
				while (reader.Read()) {
					InvoiceDetails obj = new InvoiceDetails();
					obj.InvoiceId = GetReaderValue_Int32(reader, "InvoiceId", 0);
					obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.InvoiceValue = GetReaderValue_NullableDouble(reader, "InvoiceValue", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Invoices", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Invoice
		/// Calls [usp_update_Invoice]
        /// </summary>
        public override bool Update(System.Int32? invoiceId, System.String notes, System.String instructions, System.String shippingNotes, System.String cofCnotes, System.Boolean? invoicePaid, System.Int32? salesman2, System.Double? salesman2Percent, System.Int32? boxes, System.Double? weight, System.Double? dimensionalWeight, System.Boolean? weightInPounds, System.String airWayBill, System.Double? shippingCost, System.Double? freight, System.Int32? shipViaNo, System.String customerPo, System.String account, System.Int32? currencyNo, System.Int32? salesman, System.Int32? termsNo, System.Int32? taxNo, System.Int32? billToAddressNo, System.String companyBillTo, System.Int32? shipToAddressNo, System.String companyShipTo, System.Int32? divisionNo, System.Int32? incotermNo, System.Int32? updatedBy, System.Double? ExchangeRate, System.DateTime? invoicePaidDate)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Invoice", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = invoiceId;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
				cmd.Parameters.Add("@ShippingNotes", SqlDbType.NVarChar).Value = shippingNotes;
				cmd.Parameters.Add("@CofCNotes", SqlDbType.NVarChar).Value = cofCnotes;
				cmd.Parameters.Add("@InvoicePaid", SqlDbType.Bit).Value = invoicePaid;
				cmd.Parameters.Add("@Salesman2", SqlDbType.Int).Value = salesman2;
				cmd.Parameters.Add("@Salesman2Percent", SqlDbType.Float).Value = salesman2Percent;
				cmd.Parameters.Add("@Boxes", SqlDbType.Int).Value = boxes;
				cmd.Parameters.Add("@Weight", SqlDbType.Float).Value = weight;
				cmd.Parameters.Add("@DimensionalWeight", SqlDbType.Float).Value = dimensionalWeight;
				cmd.Parameters.Add("@WeightInPounds", SqlDbType.Bit).Value = weightInPounds;
				cmd.Parameters.Add("@AirWayBill", SqlDbType.NVarChar).Value = airWayBill;
				cmd.Parameters.Add("@ShippingCost", SqlDbType.Float).Value = shippingCost;
				cmd.Parameters.Add("@Freight", SqlDbType.Float).Value = freight;
				cmd.Parameters.Add("@ShipViaNo", SqlDbType.Int).Value = shipViaNo;
				cmd.Parameters.Add("@CustomerPO", SqlDbType.NVarChar).Value = customerPo;
				cmd.Parameters.Add("@Account", SqlDbType.NVarChar).Value = account;
				cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
				cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
				cmd.Parameters.Add("@TermsNo", SqlDbType.Int).Value = termsNo;
				cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
				cmd.Parameters.Add("@BillToAddressNo", SqlDbType.Int).Value = billToAddressNo;
				cmd.Parameters.Add("@CompanyBillTo", SqlDbType.NVarChar).Value = companyBillTo;
				cmd.Parameters.Add("@ShipToAddressNo", SqlDbType.Int).Value = shipToAddressNo;
				cmd.Parameters.Add("@CompanyShipTo", SqlDbType.NVarChar).Value = companyShipTo;
				cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
				cmd.Parameters.Add("@IncotermNo", SqlDbType.Int).Value = incotermNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@ExchangeRate", SqlDbType.Float).Value = ExchangeRate;
                cmd.Parameters.Add("@InvoicePaidDate", SqlDbType.DateTime).Value = invoicePaidDate;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Invoice", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Invoice
		/// Calls [usp_update_Invoice_Export]
        /// </summary>
		public override bool UpdateExport(System.Int32? invoiceId, System.Int32? exportedBy, System.Boolean? export) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Invoice_Export", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = invoiceId;
				cmd.Parameters.Add("@ExportedBy", SqlDbType.Int).Value = exportedBy;
				cmd.Parameters.Add("@Export", SqlDbType.Bit).Value = export;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Invoice", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
        // [006] code start
        /// <summary>
        /// GetPDFListForInvoice 
        /// Calls [usp_selectAll_PDF_for_Invoice]
        /// </summary>
        public override List<PDFDocumentDetails> GetPDFListForInvoice(System.Int32? InvoiceNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_PDF_for_Invoice", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@InvoiceNo", SqlDbType.Int).Value = InvoiceNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PDFDocumentDetails> lstPDF = new List<PDFDocumentDetails>();
                while (reader.Read())
                {
                    PDFDocumentDetails obj = new PDFDocumentDetails();
                    obj.PDFDocumentId = GetReaderValue_Int32(reader, "InvoicePDFId", 0);
                    obj.PDFDocumentRefNo = GetReaderValue_Int32(reader, "InvoiceNo", 0);
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
                throw new Exception("Failed to get PDF list for invoice", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Calls [usp_insert_InvoicePDF]
        /// </summary>
        /// <param name="InvoiceNo"></param>
        /// <param name="Caption"></param>
        /// <param name="FileName"></param>
        /// <param name="UpdatedBy"></param>
        /// <returns></returns>
        public override Int32 Insert(System.Int32? InvoiceNo, System.String Caption, System.String FileName, System.Int32? UpdatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_InvoicePDF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@InvoiceNo", SqlDbType.Int).Value = InvoiceNo;
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
                throw new Exception("Failed to insert invoice pdf", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// DeleteInvoicePDF
        /// Calls [usp_delete_InvoicePDF]
        /// </summary>
        /// <param name="InvoicePdfId"></param>
        /// <returns></returns>
        public override bool DeleteInvoicePDF(System.Int32? InvoicePdfId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_InvoicePDF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@InvoicePDFId", SqlDbType.Int).Value = InvoicePdfId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete invoice pdf", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        
		//[006] code end

        //[009] code start
        /// <summary>
        /// Update bank fee invoice
        /// Calls [usp_updateInvoiceBankFee]
        /// </summary>
        public override bool UpdateInvoiceBankFee(System.Int32 invoiceID, System.Double? invoiceBankFee)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_updateInvoiceBankFee", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = invoiceID;
                cmd.Parameters.Add("@BankFee", SqlDbType.Float).Value = invoiceBankFee;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Failed to update bank fee", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[009] code end

        /// <summary>
        /// Update Shipping Info
        /// Calls [usp_update_InvoiceShippingInfo]
        /// </summary>
        public override bool UpdateShippingInfo(System.Int32? invoiceId, System.Int32? boxes, System.Double? weight, System.Double? dimensionalWeight, System.Boolean? weightInPounds, System.String airWayBill, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_InvoiceShippingInfo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = invoiceId;
                cmd.Parameters.Add("@Boxes", SqlDbType.Int).Value = boxes;
                cmd.Parameters.Add("@Weight", SqlDbType.Float).Value = weight;
                cmd.Parameters.Add("@DimensionalWeight", SqlDbType.Float).Value = dimensionalWeight;
                cmd.Parameters.Add("@WeightInPounds", SqlDbType.Bit).Value = weightInPounds;
                cmd.Parameters.Add("@AirWayBill", SqlDbType.NVarChar).Value = airWayBill;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update shipping info", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public override List<GoodsInLineDetails> GetSerial(System.Int32? invoiceLineId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SerialNoByInvoiceLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@InvoiceLineId", SqlDbType.Int).Value = invoiceLineId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<GoodsInLineDetails> lst = new List<GoodsInLineDetails>();
                while (reader.Read())
                {
                    GoodsInLineDetails obj = new GoodsInLineDetails();
                    obj.SerialNoId = GetReaderValue_Int32(reader, "SerialNumberId", 0);
                    obj.SerialNo = GetReaderValue_String(reader, "SerialNo", "");
                    obj.SubGroup = GetReaderValue_String(reader, "Group", null);
                    obj.GoodsInNo = GetReaderValue_Int32(reader, "GoodsInNo", 0);

                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Serial Details", sqlex);
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