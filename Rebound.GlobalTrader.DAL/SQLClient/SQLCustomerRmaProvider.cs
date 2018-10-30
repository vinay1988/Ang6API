/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to upload pdf document for customerRMA section
[002]      Vinay           26/07/2012   Add compulsory incoterms field when create Credit and debit note. :ESMS No:- 105
[003]      Aashu Singh     01/06/2018   Quick Jump in Global Warehouse 
[004]      Aashu Singh     22/06/2018   Save internal log for CRMA
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

namespace Rebound.GlobalTrader.DAL.SqlClient
{
    public class SqlCustomerRmaProvider : CustomerRmaProvider
    {
        /// <summary>
        /// Count CustomerRma
        /// Calls [usp_count_CustomerRMA_for_Client]
        /// </summary>
        public override Int32 CountForClient(System.Int32? clientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_count_CustomerRMA_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                return (Int32)ExecuteScalar(cmd);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to count CustomerRma", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Count CustomerRma
        /// Calls [usp_count_CustomerRMA_for_Company]
        /// </summary>
        public override Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeComplete)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_count_CustomerRMA_for_Company", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@IncludeComplete", SqlDbType.Bit).Value = includeComplete;
                cn.Open();
                return (Int32)ExecuteScalar(cmd);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to count CustomerRma", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Count CustomerRma
        /// Calls [usp_count_CustomerRMA_receiving_for_Client]
        /// </summary>
        public override Int32 CountReceivingForClient(System.Int32? clientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_count_CustomerRMA_receiving_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                return (Int32)ExecuteScalar(cmd);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to count CustomerRma", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Delete CustomerRma
        /// Calls [usp_delete_CustomerRMA]
        /// </summary>
        public override bool Delete(System.Int32? customerRmaId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_CustomerRMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustomerRMAId", SqlDbType.Int).Value = customerRmaId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete CustomerRma", sqlex);
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
        /// Calls [usp_insert_CustomerRMA]
        /// </summary>
        public override Int32 Insert(System.Int32? clientNo, System.Int32? invoiceNo, System.Int32? authorisedBy, System.DateTime? customerRmaDate, System.String notes, System.String instructions, System.Int32? shipViaNo, System.String account, System.Int32? warehouseNo, System.Int32? companyNo, System.Int32? contactNo, System.Int32? divisionNo, System.Int32? incotermNo, System.Int32? updatedBy, System.String CustomerRejectionNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_CustomerRMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@InvoiceNo", SqlDbType.Int).Value = invoiceNo;
                cmd.Parameters.Add("@AuthorisedBy", SqlDbType.Int).Value = authorisedBy;
                cmd.Parameters.Add("@CustomerRMADate", SqlDbType.DateTime).Value = customerRmaDate;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
                cmd.Parameters.Add("@ShipViaNo", SqlDbType.Int).Value = shipViaNo;
                cmd.Parameters.Add("@Account", SqlDbType.NVarChar).Value = account;
                cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
                cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
                cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
                cmd.Parameters.Add("@IncotermNo", SqlDbType.Int).Value = incotermNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@CustomerRejectionNo", SqlDbType.NVarChar).Value = CustomerRejectionNo;
                cmd.Parameters.Add("@CustomerRMAId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@CustomerRMAId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert CustomerRma", sqlex);
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
        /// Calls [usp_itemsearch_CustomerRMA]
        /// </summary>
        public override List<CustomerRmaDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String crmaNotesSearch, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.DateTime? customerRmaDateFrom, System.DateTime? customerRmaDateTo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_itemsearch_CustomerRMA", cn);
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
                cmd.Parameters.Add("@CRMANotesSearch", SqlDbType.NVarChar).Value = crmaNotesSearch;
                cmd.Parameters.Add("@InvoiceNoLo", SqlDbType.Int).Value = invoiceNoLo;
                cmd.Parameters.Add("@InvoiceNoHi", SqlDbType.Int).Value = invoiceNoHi;
                cmd.Parameters.Add("@CustomerRMANoLo", SqlDbType.Int).Value = customerRmaNoLo;
                cmd.Parameters.Add("@CustomerRMANoHi", SqlDbType.Int).Value = customerRmaNoHi;
                cmd.Parameters.Add("@CustomerRMADateFrom", SqlDbType.DateTime).Value = customerRmaDateFrom;
                cmd.Parameters.Add("@CustomerRMADateTo", SqlDbType.DateTime).Value = customerRmaDateTo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CustomerRmaDetails> lst = new List<CustomerRmaDetails>();
                while (reader.Read())
                {
                    CustomerRmaDetails obj = new CustomerRmaDetails();
                    obj.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0);
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
                    obj.CustomerRMADate = GetReaderValue_DateTime(reader, "CustomerRMADate", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", "");
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRmas", sqlex);
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
        /// Calls [usp_select_CustomerRMA]
        /// </summary>
        public override CustomerRmaDetails Get(System.Int32? customerRmaId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_CustomerRMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRMAId", SqlDbType.Int).Value = customerRmaId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetCustomerRmaFromReader(reader);
                    CustomerRmaDetails obj = new CustomerRmaDetails();
                    obj.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
                    obj.AuthorisedBy = GetReaderValue_Int32(reader, "AuthorisedBy", 0);
                    obj.CustomerRMADate = GetReaderValue_DateTime(reader, "CustomerRMADate", DateTime.MinValue);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", "");
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
                    obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
                    obj.QuantityReceived = GetReaderValue_NullableInt32(reader, "QuantityReceived", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    obj.ClientCustomerRMANo = GetReaderValue_NullableInt32(reader, "ClientCustomerRMANo", 0);
                    obj.RefNumber = GetReaderValue_NullableInt32(reader, "RefNumber", null);
                    obj.CustomerRejectionNo = GetReaderValue_String(reader, "CustomerRejectionNo", "");
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
                throw new Exception("Failed to get CustomerRma", sqlex);
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
        /// Calls [usp_select_CustomerRMA_by_Number]
        /// </summary>
        public override CustomerRmaDetails GetByNumber(System.Int32? customerRmaNumber)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_CustomerRMA_by_Number", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRMANumber", SqlDbType.Int).Value = customerRmaNumber;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetCustomerRmaFromReader(reader);
                    CustomerRmaDetails obj = new CustomerRmaDetails();
                    obj.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
                    obj.AuthorisedBy = GetReaderValue_Int32(reader, "AuthorisedBy", 0);
                    obj.CustomerRMADate = GetReaderValue_DateTime(reader, "CustomerRMADate", DateTime.MinValue);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", "");
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
                    obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
                    obj.QuantityReceived = GetReaderValue_NullableInt32(reader, "QuantityReceived", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
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
                throw new Exception("Failed to get CustomerRma", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetForNewCreditNote 
        /// Calls [usp_select_CustomerRMA_for_NewCreditNote]
        /// </summary>
        public override CustomerRmaDetails GetForNewCreditNote(System.Int32? customerRmaId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_CustomerRMA_for_NewCreditNote", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRMAId", SqlDbType.Int).Value = customerRmaId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetCustomerRmaFromReader(reader);
                    CustomerRmaDetails obj = new CustomerRmaDetails();
                    obj.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
                    obj.AuthorisedBy = GetReaderValue_Int32(reader, "AuthorisedBy", 0);
                    obj.CustomerRMADate = GetReaderValue_DateTime(reader, "CustomerRMADate", DateTime.MinValue);
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", "");
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
                    obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
                    obj.QuantityReceived = GetReaderValue_NullableInt32(reader, "QuantityReceived", null);
                    obj.InvoiceCustomerPO = GetReaderValue_String(reader, "InvoiceCustomerPO", "");
                    obj.InvoiceShippingCost = GetReaderValue_NullableDouble(reader, "InvoiceShippingCost", null);
                    obj.InvoiceFreight = GetReaderValue_NullableDouble(reader, "InvoiceFreight", null);
                    obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
                    obj.Salesman2Percent = GetReaderValue_NullableDouble(reader, "Salesman2Percent", null);
                    //[002] code start
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    //[002] code end
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
                throw new Exception("Failed to get CustomerRma", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetForPage 
        /// Calls [usp_select_CustomerRMA_for_Page]
        /// </summary>
        public override CustomerRmaDetails GetForPage(System.Int32? customerRmaId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_CustomerRMA_for_Page", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRMAId", SqlDbType.Int).Value = customerRmaId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetCustomerRmaFromReader(reader);
                    CustomerRmaDetails obj = new CustomerRmaDetails();
                    obj.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    // [001] code start
                    obj.IsPDFAvailable = GetReaderValue_Boolean(reader, "IsPDFAvailable", false);
                    // [001] code end
                    obj.TeamNo = GetReaderValue_Int32(reader, "TeamNo", 0);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
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
                throw new Exception("Failed to get CustomerRma", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// GetForPage 
        /// Calls [usp_select_RecieveCustomerRMA_for_Page]
        /// </summary>
        public override CustomerRmaDetails GetForRecievePage(System.Int32? customerRmaId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_RecieveCustomerRMA_for_Page", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRMAId", SqlDbType.Int).Value = customerRmaId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetCustomerRmaFromReader(reader);
                    CustomerRmaDetails obj = new CustomerRmaDetails();
                    obj.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    // [001] code start
                    obj.IsPDFAvailable = GetReaderValue_Boolean(reader, "IsPDFAvailable", false);
                    // [001] code end
                    obj.TeamNo = GetReaderValue_Int32(reader, "TeamNo", 0);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");

                    obj.ClientBaseCurrencyID = GetReaderValue_Int32(reader, "ClientBaseCurrencyID", 0);
                    obj.ClientBaseCurrencyCode = GetReaderValue_String(reader, "ClientBaseCurrencyCode", "");
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
                throw new Exception("Failed to get CustomerRma", sqlex);
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
        /// Calls [usp_select_CustomerRMA_for_Print]
        /// </summary>
        public override CustomerRmaDetails GetForPrint(System.Int32? customerRmaId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_CustomerRMA_for_Print", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRMAId", SqlDbType.Int).Value = customerRmaId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetCustomerRmaFromReader(reader);
                    CustomerRmaDetails obj = new CustomerRmaDetails();
                    obj.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
                    obj.AuthorisedBy = GetReaderValue_Int32(reader, "AuthorisedBy", 0);
                    obj.CustomerRMADate = GetReaderValue_DateTime(reader, "CustomerRMADate", DateTime.MinValue);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", "");
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
                    obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
                    obj.QuantityReceived = GetReaderValue_NullableInt32(reader, "QuantityReceived", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    obj.CompanyTelephone = GetReaderValue_String(reader, "CompanyTelephone", "");
                    obj.CompanyFax = GetReaderValue_String(reader, "CompanyFax", "");
                    obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
                    obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
                    obj.ContactEmail = GetReaderValue_String(reader, "ContactEmail", "");
                    obj.CustomerRejectionNo = GetReaderValue_String(reader, "CustomerRejectionNo", "");
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
                throw new Exception("Failed to get CustomerRma", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetIDByNumber 
        /// Calls [usp_select_CustomerRMA_ID_by_Number]
        /// </summary>
        public override List<CustomerRmaDetails> GetIDByNumber(System.Int32? customerRmaNumber, System.Int32? clientNo, System.Int32? isGlobalUser)
        {
            //[003] start
            SqlConnection cn = null;
            SqlCommand cmd = null;
            List<CustomerRmaDetails> lstCRMAD=new List<CustomerRmaDetails>();
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_CustomerRMA_ID_by_Number", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRMANumber", SqlDbType.Int).Value = customerRmaNumber;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@IsGlobalUser", SqlDbType.Int).Value = isGlobalUser;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                while (reader.Read())
                {
                    //return GetCustomerRmaFromReader(reader);
                    CustomerRmaDetails obj = new CustomerRmaDetails();
                    obj.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0);
                    obj.CRMANumberDetail = GetReaderValue_String(reader, "CRMANumberDetail", "true");
                    lstCRMAD.Add(obj);
                }
                return lstCRMAD;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRma", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
            //[003] end
        }


        /// <summary>
        /// GetNextNumber 
        /// Calls [usp_select_CustomerRMA_NextNumber]
        /// </summary>
        public override CustomerRmaDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_CustomerRMA_NextNumber", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@NewNumber", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetCustomerRmaFromReader(reader);
                    CustomerRmaDetails obj = new CustomerRmaDetails();
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
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
                throw new Exception("Failed to get CustomerRma", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListForCompany 
        /// Calls [usp_selectAll_CustomerRMA_for_Company]
        /// </summary>
        public override List<CustomerRmaDetails> GetListForCompany(System.Int32? companyId, System.Boolean? includeComplete)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_CustomerRMA_for_Company", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@IncludeComplete", SqlDbType.Bit).Value = includeComplete;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CustomerRmaDetails> lst = new List<CustomerRmaDetails>();
                while (reader.Read())
                {
                    CustomerRmaDetails obj = new CustomerRmaDetails();
                    obj.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
                    obj.AuthorisedBy = GetReaderValue_Int32(reader, "AuthorisedBy", 0);
                    obj.CustomerRMADate = GetReaderValue_DateTime(reader, "CustomerRMADate", DateTime.MinValue);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.WarehouseNo = GetReaderValue_Int32(reader, "WarehouseNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", "");
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
                    obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
                    obj.QuantityReceived = GetReaderValue_NullableInt32(reader, "QuantityReceived", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRmas", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update CustomerRma
        /// Calls [usp_update_CustomerRMA]
        /// </summary>
        public override bool Update(System.Int32? customerRmaId, System.Int32? divisionNo, System.Int32? warehouseNo, System.Int32? authorisedBy, System.DateTime? customerRmaDate, System.Int32? shipViaNo, System.String account, System.String notes, System.String instructions, System.Int32? incotermNo, System.Int32? updatedBy,System.String CustomerRejectionNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_CustomerRMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustomerRMAId", SqlDbType.Int).Value = customerRmaId;
                cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
                cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
                cmd.Parameters.Add("@AuthorisedBy", SqlDbType.Int).Value = authorisedBy;
                cmd.Parameters.Add("@CustomerRMADate", SqlDbType.DateTime).Value = customerRmaDate;
                cmd.Parameters.Add("@ShipViaNo", SqlDbType.Int).Value = shipViaNo;
                cmd.Parameters.Add("@Account", SqlDbType.NVarChar).Value = account;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
                cmd.Parameters.Add("@IncotermNo", SqlDbType.Int).Value = incotermNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@CustomerRejectionNo", SqlDbType.NVarChar).Value = CustomerRejectionNo;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update CustomerRma", sqlex);
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
        /// GetPDFListForCustomerRMA 
        /// Calls [usp_selectAll_PDF_for_CustomerRMA]
        /// </summary>
        public override List<PDFDocumentDetails> GetPDFListForCustomerRMA(System.Int32? CustomerRMAId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_PDF_for_CustomerRMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRMANo", SqlDbType.Int).Value = CustomerRMAId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PDFDocumentDetails> lstPDF = new List<PDFDocumentDetails>();
                while (reader.Read())
                {
                    PDFDocumentDetails obj = new PDFDocumentDetails();
                    obj.PDFDocumentId = GetReaderValue_Int32(reader, "CustomerRMAPDFId", 0);
                    obj.PDFDocumentRefNo = GetReaderValue_Int32(reader, "CustomerRMANo", 0);
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
                throw new Exception("Failed to get PDF list for cutomer rma", sqlex);
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
        /// Calls [usp_insert_CustomerRMAPDF]
        /// </summary>
        public override Int32 Insert(System.Int32? CustomerRMAId, System.String Caption, System.String FileName, System.Int32? UpdatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_CustomerRMAPDF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustomerRMANo", SqlDbType.Int).Value = CustomerRMAId;
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
                throw new Exception("Failed to insert cutomer rma pdf", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Delete cutomer rma pdf
        /// Calls[usp_delete_CustomerRMAPDF]
        /// </summary>
        public override bool DeleteCustomerRMAPDF(System.Int32? CustomerRMAPdfId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_CustomerRMAPDF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustomerRMAPDFId", SqlDbType.Int).Value = CustomerRMAPdfId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete customer rma pdf", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        
        // [001] code end
        //[004] start
        public override Int32 InsertCRMAInternalLog(System.Int32 CustomerRMAId, System.String notes, System.Int32 UpdatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_CRMAInternalLog", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustomerRMANo", SqlDbType.Int).Value = CustomerRMAId;
                cmd.Parameters.Add("@ExpediteNotes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UpdatedBy;
                cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return ret;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to save customer rma internal log", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        public override List<CustomerRmaDetails> GetCRMAInternalLog(System.Int32 customerRmaNumber)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_GetCRMAInternalLog", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustomerRMANo", SqlDbType.Int).Value = customerRmaNumber;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CustomerRmaDetails> lstPDF = new List<CustomerRmaDetails>();
                while (reader.Read())
                {
                    CustomerRmaDetails obj = new CustomerRmaDetails();
                    obj.CRMAExpediteNotesId = GetReaderValue_Int32(reader, "CRMAExpediteNotesId", 0);
                    obj.Notes = GetReaderValue_String(reader, "ExpediteNotes", "");
                    obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP",DateTime.Now);
                    lstPDF.Add(obj);
                    obj = null;
                }
                return lstPDF;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get customer rma internal log", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[004] end
    }
}