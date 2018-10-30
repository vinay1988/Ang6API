/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to upload pdf document for sales order section
[002]      Vinay           23/05/2012   This need to add currency notes.
[003]      Abhinav         15/01/2013   Apply a bank fee charge to the customers final invoice 
[004]      Vinay           21/01/2014   CR:- Add AS9120 Requirement in GT application
[005]      Shashi Keshar   25/01/2016  Added properties to check IsAgency
[006]      Aashu Singh     01/06/2018   Quick Jump in Global Warehouse 
[007]      Aashu Singh     03/07/2018   Add customer order value nugget on broker and sales tab
[008]      Aashu Singh     13/08/2018   REB-12161:Credit Card Payments
[009]      Aashu Singh     29/08/2018   Show so payment attachment
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
    public class SqlSalesOrderProvider : SalesOrderProvider
    {
        /// <summary>
        /// Count SalesOrder
        /// Calls [usp_count_SalesOrder_for_Client]
        /// </summary>
        public override Int32 CountForClient(System.Int32? clientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_count_SalesOrder_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                return (Int32)ExecuteScalar(cmd);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to count SalesOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Count SalesOrder
        /// Calls [usp_count_SalesOrder_for_Company]
        /// </summary>
        public override Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeClosed)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_count_SalesOrder_for_Company", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
                cn.Open();
                return (Int32)ExecuteScalar(cmd);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to count SalesOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Count SalesOrder
        /// Calls [usp_count_SalesOrder_open_for_Company]
        /// </summary>
        public override Int32 CountOpenForCompany(System.Int32? companyId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_count_SalesOrder_open_for_Company", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cn.Open();
                return (Int32)ExecuteScalar(cmd);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to count SalesOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Count SalesOrder
        /// Calls [usp_count_SalesOrder_shipping_for_Client]
        /// </summary>
        public override Int32 CountShippingForClient(System.Int32? clientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_count_SalesOrder_shipping_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                return (Int32)ExecuteScalar(cmd);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to count SalesOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Delete SalesOrder
        /// Calls [usp_delete_SalesOrder]
        /// </summary>
        public override bool Delete(System.Int32? salesOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_SalesOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete SalesOrder", sqlex);
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
        /// Calls [usp_insert_SalesOrder]
        /// </summary>
        public override Int32 Insert(System.Int32? clientNo, System.Int32? companyNo, System.Int32? contactNo, System.DateTime? dateOrdered, System.Int32? currencyNo, System.Int32? salesman, System.Int32? termsNo, System.Int32? shipToAddressNo, System.Int32? shipViaNo, System.String account, System.Double? freight, System.String customerPo, System.Int32? divisionNo, System.Int32? taxNo, System.Double? shippingCost, System.String notes, System.String instructions, System.Boolean? paid, System.Int32? statusNo, System.Boolean? closed, System.Int32? salesman2, System.Double? salesman2Percent, System.Int32? incotermNo, System.Int32? authorisedBy, System.DateTime? dateAuthorised, System.Int32? updatedBy, System.Boolean? As9120)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_SalesOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
                cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
                cmd.Parameters.Add("@DateOrdered", SqlDbType.DateTime).Value = dateOrdered;
                cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
                cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
                cmd.Parameters.Add("@TermsNo", SqlDbType.Int).Value = termsNo;
                cmd.Parameters.Add("@ShipToAddressNo", SqlDbType.Int).Value = shipToAddressNo;
                cmd.Parameters.Add("@ShipViaNo", SqlDbType.Int).Value = shipViaNo;
                cmd.Parameters.Add("@Account", SqlDbType.NVarChar).Value = account;
                cmd.Parameters.Add("@Freight", SqlDbType.Float).Value = freight;
                cmd.Parameters.Add("@CustomerPO", SqlDbType.NVarChar).Value = customerPo;
                cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
                cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
                cmd.Parameters.Add("@ShippingCost", SqlDbType.Float).Value = shippingCost;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
                cmd.Parameters.Add("@Paid", SqlDbType.Bit).Value = paid;
                cmd.Parameters.Add("@StatusNo", SqlDbType.Int).Value = statusNo;
                cmd.Parameters.Add("@Closed", SqlDbType.Bit).Value = closed;
                cmd.Parameters.Add("@Salesman2", SqlDbType.Int).Value = salesman2;
                cmd.Parameters.Add("@Salesman2Percent", SqlDbType.Float).Value = salesman2Percent;
                cmd.Parameters.Add("@IncotermNo", SqlDbType.Int).Value = incotermNo;
                cmd.Parameters.Add("@AuthorisedBy", SqlDbType.Int).Value = authorisedBy;
                cmd.Parameters.Add("@DateAuthorised", SqlDbType.DateTime).Value = dateAuthorised;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //[004] code start
                cmd.Parameters.Add("@AS9120", SqlDbType.Bit).Value = As9120;
                //[004] code end
                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@SalesOrderId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert SalesOrder", sqlex);
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
        /// Calls [usp_itemsearch_SalesOrder]
        /// </summary>
        public override List<SalesOrderDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String customerPoSearch, System.Boolean? includeClosed, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_itemsearch_SalesOrder", cn);
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
                cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
                cmd.Parameters.Add("@SalesOrderNoLo", SqlDbType.Int).Value = salesOrderNoLo;
                cmd.Parameters.Add("@SalesOrderNoHi", SqlDbType.Int).Value = salesOrderNoHi;
                cmd.Parameters.Add("@DateOrderedFrom", SqlDbType.DateTime).Value = dateOrderedFrom;
                cmd.Parameters.Add("@DateOrderedTo", SqlDbType.DateTime).Value = dateOrderedTo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SalesOrderDetails> lst = new List<SalesOrderDetails>();
                while (reader.Read())
                {
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SalesOrders", sqlex);
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
        /// Calls [usp_select_SalesOrder]
        /// </summary>
        public override SalesOrderDetails Get(System.Int32? salesOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SalesOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSalesOrderFromReader(reader);
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
                    obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.Freight = GetReaderValue_Double(reader, "Freight", 0);
                    obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
                    obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
                    obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.SaleTypeNo = GetReaderValue_NullableInt32(reader, "SaleTypeNo", null);
                    obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
                    obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
                    obj.AuthorisedBy = GetReaderValue_NullableInt32(reader, "AuthorisedBy", null);
                    obj.DateAuthorised = GetReaderValue_NullableDateTime(reader, "DateAuthorised", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.ShippingCharge = GetReaderValue_NullableBoolean(reader, "ShippingCharge", null);
                    obj.CreditLimit = GetReaderValue_Double(reader, "CreditLimit", 0);
                    obj.Balance = GetReaderValue_Double(reader, "Balance", 0);
                    obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
                    obj.VATNo = GetReaderValue_String(reader, "VATNo", "");
                    obj.SOCurrencyNo = GetReaderValue_Int32(reader, "SOCurrencyNo", 0);
                    obj.SOCurrencyCode = GetReaderValue_String(reader, "SOCurrencyCode", "");
                    obj.SOCurrencyDescription = GetReaderValue_String(reader, "SOCurrencyDescription", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.Team2No = GetReaderValue_NullableInt32(reader, "Team2No", null);
                    obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
                    obj.InAdvance = GetReaderValue_NullableBoolean(reader, "InAdvance", null);
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.PickUp = GetReaderValue_String(reader, "PickUp", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                    obj.Authoriser = GetReaderValue_String(reader, "Authoriser", "");
                    obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    obj.LineSubTotal = GetReaderValue_NullableDouble(reader, "LineSubTotal", null);
                    obj.TotalTax = GetReaderValue_NullableDouble(reader, "TotalTax", null);
                    obj.TotalValue = GetReaderValue_NullableDouble(reader, "TotalValue", null);
                    //[004] code start
                    obj.AS9120 = GetReaderValue_NullableBoolean(reader, "AS9120", null);
                    obj.IsSameAsShipCost = GetReaderValue_NullableBoolean(reader, "IsSameAsShipCost", false);
                    obj.IsCurrencyInSameFaimly = GetReaderValue_NullableBoolean(reader, "IsCurrencyInSameFaimly", false);
                    //[004] code end
                    obj.IsConsolidated = GetReaderValue_NullableBoolean(reader, "IsConsolidated", null);
                    obj.SentOrder = GetReaderValue_NullableInt32(reader, "SentOrder", 0);
                    obj.ActualCreditLimit = GetReaderValue_Double(reader, "ActualCreditLimit", 0);
                    //[008] start
                    obj.IsPaidByCreditCard = GetReaderValue_Boolean(reader, "IsPaidByCreditCard", false);
                    //[008] end
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
                throw new Exception("Failed to get SalesOrder", sqlex);
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
        /// Calls [usp_select_SalesOrder_by_Number]
        /// </summary>
        public override SalesOrderDetails GetByNumber(System.Int32? salesOrderNumber, System.Int32? clientNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SalesOrder_by_Number", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SalesOrderNumber", SqlDbType.Int).Value = salesOrderNumber;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSalesOrderFromReader(reader);
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
                    obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.Freight = GetReaderValue_Double(reader, "Freight", 0);
                    obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
                    obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
                    obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.SaleTypeNo = GetReaderValue_NullableInt32(reader, "SaleTypeNo", null);
                    obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
                    obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
                    obj.AuthorisedBy = GetReaderValue_NullableInt32(reader, "AuthorisedBy", null);
                    obj.DateAuthorised = GetReaderValue_NullableDateTime(reader, "DateAuthorised", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.ShippingCharge = GetReaderValue_NullableBoolean(reader, "ShippingCharge", null);
                    obj.CreditLimit = GetReaderValue_Double(reader, "CreditLimit", 0);
                    obj.Balance = GetReaderValue_Double(reader, "Balance", 0);
                    obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
                    obj.VATNo = GetReaderValue_String(reader, "VATNo", "");
                    obj.SOCurrencyNo = GetReaderValue_Int32(reader, "SOCurrencyNo", 0);
                    obj.SOCurrencyCode = GetReaderValue_String(reader, "SOCurrencyCode", "");
                    obj.SOCurrencyDescription = GetReaderValue_String(reader, "SOCurrencyDescription", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.Team2No = GetReaderValue_NullableInt32(reader, "Team2No", null);
                    obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
                    obj.InAdvance = GetReaderValue_NullableBoolean(reader, "InAdvance", null);
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.PickUp = GetReaderValue_String(reader, "PickUp", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                    obj.Authoriser = GetReaderValue_String(reader, "Authoriser", "");
                    obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
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
                throw new Exception("Failed to get SalesOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetDetailsForLineCalculations 
        /// Calls [usp_select_SalesOrder_DetailsForLineCalculations]
        /// </summary>
        public override SalesOrderDetails GetDetailsForLineCalculations(System.Int32? salesOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SalesOrder_DetailsForLineCalculations", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSalesOrderFromReader(reader);
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.Freight = GetReaderValue_Double(reader, "Freight", 0);
                    obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
                    obj.CreditLimit = GetReaderValue_Double(reader, "CreditLimit", 0);
                    obj.Balance = GetReaderValue_Double(reader, "Balance", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
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
                throw new Exception("Failed to get SalesOrder", sqlex);
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
        /// Calls [usp_select_SalesOrder_for_Page]
        /// </summary>
        public override SalesOrderDetails GetForPage(System.Int32? salesOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SalesOrder_for_Page", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSalesOrderFromReader(reader);
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    // [001] code start
                    obj.IsPDFAvailable = GetReaderValue_Boolean(reader, "IsPDFAvailable", false);
                    // [001] code end
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", 0);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.IsSORPDFAvailable = GetReaderValue_Boolean(reader, "IsSORPDFAvailable", false);
                    obj.IpoCount = GetReaderValue_Int32(reader, "IpoCount", 0);
                    obj.IsFromIPO = obj.IpoCount > 0 ? true : false;
                    obj.ConsolidateStatus = GetReaderValue_String(reader, "ConsolidateStatus", "");
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
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
                throw new Exception("Failed to get SalesOrder", sqlex);
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
        /// Calls [usp_select_SalesOrder_for_Print]
        /// </summary>
        public override SalesOrderDetails GetForPrint(System.Int32? salesOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SalesOrder_for_Print", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSalesOrderFromReader(reader);
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
                    obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.Freight = GetReaderValue_Double(reader, "Freight", 0);
                    obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
                    obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
                    obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.SaleTypeNo = GetReaderValue_NullableInt32(reader, "SaleTypeNo", null);
                    obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
                    obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
                    obj.AuthorisedBy = GetReaderValue_NullableInt32(reader, "AuthorisedBy", null);
                    obj.DateAuthorised = GetReaderValue_NullableDateTime(reader, "DateAuthorised", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.CreatedBy = GetReaderValue_NullableInt32(reader, "CreatedBy", null);
                    obj.CreateDate = GetReaderValue_NullableDateTime(reader, "CreateDate", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.ShippingCharge = GetReaderValue_NullableBoolean(reader, "ShippingCharge", null);
                    obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
                    obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    obj.LineSubTotal = GetReaderValue_NullableDouble(reader, "LineSubTotal", null);
                    obj.TotalTax = GetReaderValue_NullableDouble(reader, "TotalTax", null);
                    obj.TotalValue = GetReaderValue_NullableDouble(reader, "TotalValue", null);
                    obj.CompanyTelephone = GetReaderValue_String(reader, "CompanyTelephone", "");
                    obj.CompanyFax = GetReaderValue_String(reader, "CompanyFax", "");
                    obj.ContactEmail = GetReaderValue_String(reader, "ContactEmail", "");
                    obj.CompanyRegNo = GetReaderValue_String(reader, "CompanyRegNo", "");
                    //[002] code start
                    obj.CurrencyNotes = GetReaderValue_String(reader, "CurrencyNotes", "");
                    //[002] code end

                    //[003] code start
                    obj.InvoiceBankFee = GetReaderValue_Double(reader, "InvoiceBankFee", 0);
                    obj.IsApplyBankFee = GetReaderValue_NullableBoolean(reader, "IsApplyBankFee", false);
                    //[003] code end
                    obj.VATNo = GetReaderValue_String(reader, "VATNo", "");
                    //[004] code start
                    obj.AS9120 = GetReaderValue_NullableBoolean(reader, "AS9120", false);
                    //[004] code end
                    obj.CompanyType = GetReaderValue_String(reader, "CompanyType", "");
                    obj.Traceability = GetReaderValue_NullableBoolean(reader, "IsTraceability", false);

                    obj.IsAgency = GetReaderValue_NullableBoolean(reader, "IsAgency", false);
                    obj.UKAuthorisedBy = GetReaderValue_NullableInt32(reader, "UKAuthorisedBy", null);
                    obj.UKAuthorisedDate = GetReaderValue_NullableDateTime(reader, "UKAuthorisedDate", DateTime.Now);
                    obj.UKAuthoriserName = GetReaderValue_String(reader, "UKAuthoriserName", "");
                    obj.CompanyOnStop = GetReaderValue_Boolean(reader, "CompanyOnStop", false);
                    obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
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
                throw new Exception("Failed to get SalesOrder", sqlex);
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
        /// Calls [usp_select_SalesOrder_ID_by_Number]
        /// </summary>
        public override List<SalesOrderDetails> GetIDByNumber(System.Int32? salesOrderNumber, System.Int32? clientNo, System.Int32? isGlobalUser)
        {
            //[006] start
            SqlConnection cn = null;
            SqlCommand cmd = null;
            List<SalesOrderDetails> lstSOD = new List<SalesOrderDetails>();
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SalesOrder_ID_by_Number", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SalesOrderNumber", SqlDbType.Int).Value = salesOrderNumber;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@IsGlobalUser", SqlDbType.Int).Value = isGlobalUser;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                while (reader.Read())
                {
                    //return GetSalesOrderFromReader(reader);
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
                    obj.SalesOrderNumberDetail = GetReaderValue_String(reader, "SalesOrderNumberDetail", "true");
                    lstSOD.Add(obj);
                }
                return lstSOD;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SalesOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
            //[006] end
        }


        /// <summary>
        /// GetNextNumber 
        /// Calls [usp_select_SalesOrder_NextNumber]
        /// </summary>
        public override SalesOrderDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SalesOrder_NextNumber", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@NewNumber", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSalesOrderFromReader(reader);
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
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
                throw new Exception("Failed to get SalesOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetOpenLineSummaryValues 
        /// Calls [usp_select_SalesOrder_OpenLineSummaryValues]
        /// </summary>
        public override SalesOrderDetails GetOpenLineSummaryValues(System.Int32? salesOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SalesOrder_OpenLineSummaryValues", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSalesOrderFromReader(reader);
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Freight = GetReaderValue_Double(reader, "Freight", 0);
                    obj.LineSubTotal = GetReaderValue_NullableDouble(reader, "LineSubTotal", null);
                    obj.TotalTax = GetReaderValue_NullableDouble(reader, "TotalTax", null);
                    obj.TotalValue = GetReaderValue_NullableDouble(reader, "TotalValue", null);
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
                throw new Exception("Failed to get SalesOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetStatus 
        /// Calls [usp_select_SalesOrder_Status]
        /// </summary>
        public override SalesOrderDetails GetStatus(System.Int32? salesOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SalesOrder_Status", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSalesOrderFromReader(reader);
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
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
                throw new Exception("Failed to get SalesOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetSummaryValues 
        /// Calls [usp_select_SalesOrder_SummaryValues]
        /// </summary>
        public override SalesOrderDetails GetSummaryValues(System.Int32? salesOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SalesOrder_SummaryValues", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSalesOrderFromReader(reader);
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Freight = GetReaderValue_Double(reader, "Freight", 0);
                    obj.LineSubTotal = GetReaderValue_NullableDouble(reader, "LineSubTotal", null);
                    obj.TotalTax = GetReaderValue_NullableDouble(reader, "TotalTax", null);
                    obj.TotalValue = GetReaderValue_NullableDouble(reader, "TotalValue", null);
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
                throw new Exception("Failed to get SalesOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetValueSummary 
        /// Calls [usp_select_SalesOrder_ValueSummary]
        /// </summary>
        public override SalesOrderDetails GetValueSummary(System.Int32? salesOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SalesOrder_ValueSummary", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSalesOrderFromReader(reader);
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
                    obj.SalesOrderValue = GetReaderValue_NullableDouble(reader, "SalesOrderValue", null);
                    obj.SalesOrderValueIncFreight = GetReaderValue_NullableDouble(reader, "SalesOrderValueIncFreight", null);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
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
                throw new Exception("Failed to get SalesOrder", sqlex);
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
        /// Calls [usp_selectAll_SalesOrder_for_Company]
        /// </summary>
        public override List<SalesOrderDetails> GetListForCompany(System.Int32? companyId, System.Boolean? includeClosed)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SalesOrder_for_Company", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@IncludeClosed", SqlDbType.Bit).Value = includeClosed;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SalesOrderDetails> lst = new List<SalesOrderDetails>();
                while (reader.Read())
                {
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
                    obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.Freight = GetReaderValue_Double(reader, "Freight", 0);
                    obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
                    obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
                    obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.SaleTypeNo = GetReaderValue_NullableInt32(reader, "SaleTypeNo", null);
                    obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
                    obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
                    obj.AuthorisedBy = GetReaderValue_NullableInt32(reader, "AuthorisedBy", null);
                    obj.DateAuthorised = GetReaderValue_NullableDateTime(reader, "DateAuthorised", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.ShippingCharge = GetReaderValue_NullableBoolean(reader, "ShippingCharge", null);
                    obj.CreditLimit = GetReaderValue_Double(reader, "CreditLimit", 0);
                    obj.Balance = GetReaderValue_Double(reader, "Balance", 0);
                    obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
                    obj.VATNo = GetReaderValue_String(reader, "VATNo", "");
                    obj.SOCurrencyNo = GetReaderValue_Int32(reader, "SOCurrencyNo", 0);
                    obj.SOCurrencyCode = GetReaderValue_String(reader, "SOCurrencyCode", "");
                    obj.SOCurrencyDescription = GetReaderValue_String(reader, "SOCurrencyDescription", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.Team2No = GetReaderValue_NullableInt32(reader, "Team2No", null);
                    obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
                    obj.InAdvance = GetReaderValue_NullableBoolean(reader, "InAdvance", null);
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.PickUp = GetReaderValue_String(reader, "PickUp", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                    obj.Authoriser = GetReaderValue_String(reader, "Authoriser", "");
                    obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SalesOrders", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListOpenForCompany 
        /// Calls [usp_selectAll_SalesOrder_open_for_Company]
        /// </summary>
        public override List<SalesOrderDetails> GetListOpenForCompany(System.Int32? companyId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SalesOrder_open_for_Company", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SalesOrderDetails> lst = new List<SalesOrderDetails>();
                while (reader.Read())
                {
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
                    obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.Freight = GetReaderValue_Double(reader, "Freight", 0);
                    obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
                    obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
                    obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.SaleTypeNo = GetReaderValue_NullableInt32(reader, "SaleTypeNo", null);
                    obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
                    obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
                    obj.AuthorisedBy = GetReaderValue_NullableInt32(reader, "AuthorisedBy", null);
                    obj.DateAuthorised = GetReaderValue_NullableDateTime(reader, "DateAuthorised", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.ShippingCharge = GetReaderValue_NullableBoolean(reader, "ShippingCharge", null);
                    obj.CreditLimit = GetReaderValue_Double(reader, "CreditLimit", 0);
                    obj.Balance = GetReaderValue_Double(reader, "Balance", 0);
                    obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
                    obj.VATNo = GetReaderValue_String(reader, "VATNo", "");
                    obj.SOCurrencyNo = GetReaderValue_Int32(reader, "SOCurrencyNo", 0);
                    obj.SOCurrencyCode = GetReaderValue_String(reader, "SOCurrencyCode", "");
                    obj.SOCurrencyDescription = GetReaderValue_String(reader, "SOCurrencyDescription", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.Team2No = GetReaderValue_NullableInt32(reader, "Team2No", null);
                    obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
                    obj.InAdvance = GetReaderValue_NullableBoolean(reader, "InAdvance", null);
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.PickUp = GetReaderValue_String(reader, "PickUp", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                    obj.Authoriser = GetReaderValue_String(reader, "Authoriser", "");
                    obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SalesOrders", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListOpenForLogin 
        /// Calls [usp_selectAll_SalesOrder_open_for_Login]
        /// </summary>
        public override List<SalesOrderDetails> GetListOpenForLogin(System.Int32? loginId, System.Int32? topToSelect)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SalesOrder_open_for_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SalesOrderDetails> lst = new List<SalesOrderDetails>();
                while (reader.Read())
                {
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CreditLimit = GetReaderValue_Double(reader, "CreditLimit", 0);
                    obj.Balance = GetReaderValue_Double(reader, "Balance", 0);
                    obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
                    obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SalesOrders", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// GetListOpenForLoginUnProcess 
        /// Calls [usp_selectAll_SalesOrder_open_for_Login_UnProcess]
        /// </summary>
        public override List<SalesOrderDetails> GetListOpenForLoginUnProcess(System.Int32? loginId, System.Int32? topToSelect)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SalesOrder_open_for_Login_UnProcess", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SalesOrderDetails> lst = new List<SalesOrderDetails>();
                while (reader.Read())
                {
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CreditLimit = GetReaderValue_Double(reader, "CreditLimit", 0);
                    obj.Balance = GetReaderValue_Double(reader, "Balance", 0);
                    obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
                    obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SalesOrders", sqlex);
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
        /// Calls [usp_selectAll_SalesOrder_overdue_for_Company]
        /// </summary>
        public override List<SalesOrderDetails> GetListOverdueForCompany(System.Int32? companyId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SalesOrder_overdue_for_Company", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SalesOrderDetails> lst = new List<SalesOrderDetails>();
                while (reader.Read())
                {
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.TermsNo = GetReaderValue_Int32(reader, "TermsNo", 0);
                    obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.Freight = GetReaderValue_Double(reader, "Freight", 0);
                    obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
                    obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.Paid = GetReaderValue_Boolean(reader, "Paid", false);
                    obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.SaleTypeNo = GetReaderValue_NullableInt32(reader, "SaleTypeNo", null);
                    obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
                    obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
                    obj.AuthorisedBy = GetReaderValue_NullableInt32(reader, "AuthorisedBy", null);
                    obj.DateAuthorised = GetReaderValue_NullableDateTime(reader, "DateAuthorised", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.CurrencyDate = GetReaderValue_NullableDateTime(reader, "CurrencyDate", null);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.ShippingCharge = GetReaderValue_NullableBoolean(reader, "ShippingCharge", null);
                    obj.CreditLimit = GetReaderValue_Double(reader, "CreditLimit", 0);
                    obj.Balance = GetReaderValue_Double(reader, "Balance", 0);
                    obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
                    obj.VATNo = GetReaderValue_String(reader, "VATNo", "");
                    obj.SOCurrencyNo = GetReaderValue_Int32(reader, "SOCurrencyNo", 0);
                    obj.SOCurrencyCode = GetReaderValue_String(reader, "SOCurrencyCode", "");
                    obj.SOCurrencyDescription = GetReaderValue_String(reader, "SOCurrencyDescription", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.Team2No = GetReaderValue_NullableInt32(reader, "Team2No", null);
                    obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
                    obj.InAdvance = GetReaderValue_NullableBoolean(reader, "InAdvance", null);
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.PickUp = GetReaderValue_String(reader, "PickUp", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                    obj.Authoriser = GetReaderValue_String(reader, "Authoriser", "");
                    obj.CompanyOnStop = GetReaderValue_NullableBoolean(reader, "CompanyOnStop", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SalesOrders", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListOverdueForLogin 
        /// Calls [usp_selectAll_SalesOrder_overdue_for_Login]
        /// </summary>
        public override List<SalesOrderDetails> GetListOverdueForLogin(System.Int32? loginId, System.Int32? topToSelect)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SalesOrder_overdue_for_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginId", SqlDbType.Int).Value = loginId;
                cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SalesOrderDetails> lst = new List<SalesOrderDetails>();
                while (reader.Read())
                {
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CreditLimit = GetReaderValue_Double(reader, "CreditLimit", 0);
                    obj.Balance = GetReaderValue_Double(reader, "Balance", 0);
                    obj.CompanyId = GetReaderValue_Int32(reader, "CompanyId", 0);
                    obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
                    obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
                    obj.DaysOverdue = GetReaderValue_NullableInt32(reader, "DaysOverdue", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SalesOrders", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListReadyForClient 
        /// Calls [usp_selectAll_SalesOrder_ready_for_Client]
        /// </summary>
        public override List<SalesOrderDetails> GetListReadyForClient(System.Int32? clientId, System.Int32? topToSelect)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SalesOrder_ready_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SalesOrderDetails> lst = new List<SalesOrderDetails>();
                while (reader.Read())
                {
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.SalesOrderId = GetReaderValue_Int32(reader, "SalesOrderId", 0);
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CreditLimit = GetReaderValue_Double(reader, "CreditLimit", 0);
                    obj.Balance = GetReaderValue_Double(reader, "Balance", 0);
                    obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
                    obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SalesOrders", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListShippedRecentlyForLogin 
        /// Calls [usp_selectAll_SalesOrder_shipped_recently_for_Login]
        /// </summary>
        public override List<SalesOrderDetails> GetListShippedRecentlyForLogin(System.Int32? loginId, System.Int32? topToSelect)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SalesOrder_shipped_recently_for_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LoginID", SqlDbType.Int).Value = loginId;
                cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SalesOrderDetails> lst = new List<SalesOrderDetails>();
                while (reader.Read())
                {
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
                    obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
                    obj.InvoiceId = GetReaderValue_Int32(reader, "InvoiceId", 0);
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.InvoiceLineId = GetReaderValue_NullableInt32(reader, "InvoiceLineId", null);
                    obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
                    obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
                    obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
                    obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
                    obj.FullCompanyName = GetReaderValue_String(reader, "FullCompanyName", "");
                    obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.FullCustomerPart = GetReaderValue_String(reader, "FullCustomerPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.InvoicePaid = GetReaderValue_Boolean(reader, "InvoicePaid", false);
                    obj.Inactive = GetReaderValue_NullableBoolean(reader, "Inactive", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SalesOrders", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListShippedTodayForClient 
        /// Calls [usp_selectAll_SalesOrder_shipped_today_for_Client]
        /// </summary>
        public override List<SalesOrderDetails> GetListShippedTodayForClient(System.Int32? clientId, System.Int32? topToSelect)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SalesOrder_shipped_today_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SalesOrderDetails> lst = new List<SalesOrderDetails>();
                while (reader.Read())
                {
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.DateOrdered = GetReaderValue_DateTime(reader, "DateOrdered", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
                    obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.DatePromised = GetReaderValue_DateTime(reader, "DatePromised", DateTime.MinValue);
                    obj.InvoiceId = GetReaderValue_Int32(reader, "InvoiceId", 0);
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.InvoiceLineId = GetReaderValue_NullableInt32(reader, "InvoiceLineId", null);
                    obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
                    obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
                    obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
                    obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
                    obj.FullCompanyName = GetReaderValue_String(reader, "FullCompanyName", "");
                    obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.FullCustomerPart = GetReaderValue_String(reader, "FullCustomerPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.InvoicePaid = GetReaderValue_Boolean(reader, "InvoicePaid", false);
                    obj.Inactive = GetReaderValue_NullableBoolean(reader, "Inactive", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SalesOrders", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update SalesOrder
        /// Calls [usp_update_SalesOrder]
        /// </summary>
        public override bool Update(System.Int32? salesOrderId, System.Int32? contactNo, System.Int32? salesman, System.Int32? shipToAddressNo, System.Int32? shipViaNo, System.Int32? termsNo, System.String account, System.Double? freight, System.Double? shippingCost, System.String customerPo, System.Int32? divisionNo, System.String notes, System.String instructions, System.Boolean? paid, System.Int32? statusNo, System.Boolean? closed, System.Int32? saleTypeNo, System.Int32? salesman2, System.Double? salesman2Percent, System.Int32? incotermNo, System.Int32? TaxNo, System.Int32? updatedBy, System.Boolean? As9120, System.Int32? currencyNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_SalesOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
                cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
                cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
                cmd.Parameters.Add("@ShipToAddressNo", SqlDbType.Int).Value = shipToAddressNo;
                cmd.Parameters.Add("@ShipViaNo", SqlDbType.Int).Value = shipViaNo;
                cmd.Parameters.Add("@TermsNo", SqlDbType.Int).Value = termsNo;
                cmd.Parameters.Add("@Account", SqlDbType.NVarChar).Value = account;
                cmd.Parameters.Add("@Freight", SqlDbType.Float).Value = freight;
                cmd.Parameters.Add("@ShippingCost", SqlDbType.Float).Value = shippingCost;
                cmd.Parameters.Add("@CustomerPO", SqlDbType.NVarChar).Value = customerPo;
                cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
                cmd.Parameters.Add("@Paid", SqlDbType.Bit).Value = paid;
                cmd.Parameters.Add("@StatusNo", SqlDbType.Int).Value = statusNo;
                cmd.Parameters.Add("@Closed", SqlDbType.Bit).Value = closed;
                cmd.Parameters.Add("@SaleTypeNo", SqlDbType.Int).Value = saleTypeNo;
                cmd.Parameters.Add("@Salesman2", SqlDbType.Int).Value = salesman2;
                cmd.Parameters.Add("@Salesman2Percent", SqlDbType.Float).Value = salesman2Percent;
                cmd.Parameters.Add("@IncotermNo", SqlDbType.Int).Value = incotermNo;
                cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = TaxNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //[004] code start
                cmd.Parameters.Add("@AS9120", SqlDbType.Bit).Value = As9120;
                //[004] code end
                cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update SalesOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update SalesOrder
        /// Calls [usp_update_SalesOrder_Authorise]
        /// </summary>
        public override bool UpdateAuthorise(System.Int32? salesOrderId, System.Int32? authorisedBy, System.Boolean? authorise)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_SalesOrder_Authorise", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
                cmd.Parameters.Add("@AuthorisedBy", SqlDbType.Int).Value = authorisedBy;
                cmd.Parameters.Add("@Authorise", SqlDbType.Bit).Value = authorise;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update SalesOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update SalesOrder
        /// Calls [usp_update_SalesOrder_Close]
        /// </summary>
        public override bool UpdateClose(System.Int32? salesOrderId, System.Boolean? resetQuantity, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_SalesOrder_Close", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
                cmd.Parameters.Add("@ResetQuantity", SqlDbType.Bit).Value = resetQuantity;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update SalesOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update SalesOrder
        /// Calls [usp_update_SalesOrder_from_Invoice]
        /// </summary>
        public override bool UpdateFromInvoice(System.Int32? invoiceId, System.Int32? taxNo, System.Int32? currencyNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_SalesOrder_from_Invoice", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = invoiceId;
                cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
                cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                 ExecuteNonQuery(cmd);
                int ret = (Int32)cmd.Parameters["@RowsAffected"].Value;
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update SalesOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update SalesOrder
        /// Calls [usp_update_SalesOrder_UpdateCurrencyDateOnOpenOrders_for_Currency]
        /// </summary>
        public override bool UpdateUpdateCurrencyDateOnOpenOrdersForCurrency(System.Int32? currencyNo, System.DateTime? currencyDate)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_SalesOrder_UpdateCurrencyDateOnOpenOrders_for_Currency", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
                cmd.Parameters.Add("@CurrencyDate", SqlDbType.DateTime).Value = currencyDate;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update SalesOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// UpdateAuthoriseAllUnauthorisedOrders
        /// Calls [usp_update_SalesOrder_AuthoriseAllUnauthorisedOrders]
        /// </summary>
        public override bool UpdateAuthoriseAllUnauthorisedOrders(System.Int32? clientNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_SalesOrder_AuthoriseAllUnauthorisedOrders", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update SalesOrder", sqlex);
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
        /// GetPDFListForSalesOrder 
        /// Calls [usp_selectAll_PDF_for_SalesOrder]
        /// </summary>
        public override List<PDFDocumentDetails> GetPDFListForSalesOrder(System.Int32? SalesOrderId, System.String fileType)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_PDF_for_SalesOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SalesOrderNo", SqlDbType.Int).Value = SalesOrderId;
                cmd.Parameters.Add("@FileType", SqlDbType.NVarChar).Value = fileType;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PDFDocumentDetails> lstPDF = new List<PDFDocumentDetails>();
                while (reader.Read())
                {
                    PDFDocumentDetails obj = new PDFDocumentDetails();
                    obj.PDFDocumentId = GetReaderValue_Int32(reader, "SalesOrderPDFId", 0);
                    obj.PDFDocumentRefNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
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
                throw new Exception("Failed to get PDF list for sales order", sqlex);
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
        /// Calls [usp_insert_SalesOrderPDF]
        /// </summary>
        public override Int32 Insert(System.Int32? SalesOrderId, System.String Caption, System.String FileName, System.Int32? UpdatedBy, System.String FileType)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_SalesOrderPDF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = SalesOrderId;
                cmd.Parameters.Add("@Caption", SqlDbType.NVarChar).Value = Caption;
                cmd.Parameters.Add("@FileName", SqlDbType.NVarChar).Value = FileName;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UpdatedBy;
                cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@FileType", SqlDbType.NVarChar).Value = FileType;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@NewId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert sales order pdf", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Delete sales order pdf
        /// Calls[usp_delete_SalesOrderPDF]
        /// </summary>
        public override bool DeleteSalesOrderPDF(System.Int32? SalesOrderPdfId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_SalesOrderPDF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SalesOrderPDFId", SqlDbType.Int).Value = SalesOrderPdfId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete sales order pdf", sqlex);
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
        /// Calls [usp_Get_InvoiceNotExported]
        /// </summary>
        public override double GetInvoiceNotExported(System.Int32 comoanyNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_Get_InvoiceNotExported", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = comoanyNo;
                cn.Open();
                return (double)ExecuteScalar(cmd);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to not exported invoice value", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// usp_Validate_ReadyToShipped_Total_Price
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public override Int32 ValidateReadyToShippedPrice(System.Int32 salesOrderID, System.String xml, System.Double? freight)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_Validate_ReadyToShipped_Total_Price", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SalesOrderID", SqlDbType.Int).Value = salesOrderID;
                cmd.Parameters.Add("@SOLines", SqlDbType.Xml).Value = xml;
                cmd.Parameters.Add("@Freight", SqlDbType.Float).Value = freight;
                cn.Open();
                Int32 ret = (Int32)cmd.ExecuteScalar();
                return ret;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to validate ready to ship price", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Get So Line from soID 
        /// Calls [usp_GetSoLines]
        /// </summary>
        public override List<SalesOrderLineDetails> GetSoLines(int salesOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_GetSoLines", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SoId", SqlDbType.Int).Value = salesOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SalesOrderLineDetails> lst = new List<SalesOrderLineDetails>();
                while (reader.Read())
                {
                    SalesOrderLineDetails obj = new SalesOrderLineDetails();
                    obj.SalesOrderNo = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
                    obj.SalesOrderLineId = GetReaderValue_Int32(reader, "SalesOrderLineId", 0);
                    obj.POHubSupplierNo = GetReaderValue_Int32(reader, "POHubSupplierNo", 0);
                    obj.POQuoteLineNo = GetReaderValue_Int32(reader, "POQuoteLineNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "SoSalesPerson", 0);
                    obj.SourceingResultAttachedBy = GetReaderValue_NullableInt32(reader, "SourceingResultAttachedBy", 0);
                    obj.SourcingResultNo = GetReaderValue_NullableInt32(reader, "SourcingResultNo", 0);
                    obj.EstimatedShippingCost = GetReaderValue_NullableDouble(reader, "EstimatedShippingCost", 0);
                    obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);
                    obj.OriginalEntryDate = GetReaderValue_NullableDateTime(reader, "OriginalEntryDate", null);
                    obj.ClientCurrencyNo = GetReaderValue_NullableInt32(reader, "ClientCurrencyNo", 0);
                    obj.PurchaseBuyCurrencyNo = GetReaderValue_NullableInt32(reader, "ActualCurrencyNo", 0);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.LinkMultiCurrencyNo = GetReaderValue_NullableInt32(reader, "LinkMultiCurrencyNo", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Failed to get SalesOrderLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Update SalesOrder
        /// Calls [usp_update_SalesOrder_Consolidated]
        /// </summary>
        public override bool UpdateConsolidated(System.Int32? salesOrderId, System.Int32? consolidateStaus, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_SalesOrder_Consolidated", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
                cmd.Parameters.Add("@ConsolidateStaus", SqlDbType.Int).Value = consolidateStaus;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update SalesOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        public override Int32 InsertSerialNo(System.String subGroup, System.Int32? serialNo, System.Int32? soLineNo, System.Int32? updatedBy, out System.String validateMessage)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_SOSerialNo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SerialNo", SqlDbType.Int).Value = serialNo;
                cmd.Parameters.Add("@SubGroup", SqlDbType.VarChar).Value = subGroup;
                cmd.Parameters.Add("@SOLineNo", SqlDbType.VarChar).Value = soLineNo;     
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@SerialNoId", SqlDbType.Int).Direction = ParameterDirection.Output;

                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                validateMessage = null;
                if (ret == -1)
                {
                    validateMessage = "Duplicate Records Not Allowed";
                    return ret;
                }
                return (Int32)cmd.Parameters["@SerialNoId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Serial No", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        
     
        public override List<GoodsInLineDetails> GetDataGrid(System.Int32? soLineNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SOSerialNo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;              
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@SOLineNo", SqlDbType.Int).Value = soLineNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<GoodsInLineDetails> lst = new List<GoodsInLineDetails>();
                while (reader.Read())
                {
                    GoodsInLineDetails obj = new GoodsInLineDetails();
                    obj.SerialNoId = GetReaderValue_Int32(reader, "SerialNoId", 0);                    
                    obj.SerialNo = GetReaderValue_String(reader, "SerialNo", "");
                    obj.SubGroup = GetReaderValue_String(reader, "SubGroup", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get GoodsInLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        public override Int32 InsertAllSerialNo(System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insertAll_SOSerialNo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
 
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;              

                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return ret;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Serial No", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// usp_attach_SerialNo_WithInvoice
        /// </summary>
        /// <param name="strSerialNoIds"></param>
        /// <param name="salesOrderLineNo"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public override bool AttachSerialNo(System.String strSerialNoIds, System.Int32? salesOrderLineNo, System.Int32? allocatedId, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_attach_SerialNo_WithInvoice", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SerialNos", SqlDbType.Xml).Value = strSerialNoIds;
                cmd.Parameters.Add("@SalesOrderLineNo", SqlDbType.Int).Value = salesOrderLineNo;
                cmd.Parameters.Add("@AllocatedId", SqlDbType.Int).Value = allocatedId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                 ExecuteNonQuery(cmd);
                 int ret = (Int32)cmd.Parameters["@RowsAffected"].Value;
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to attach Serial number", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Update SalesOrder
        /// Calls [usp_SentOrder]
        /// </summary>
        public override bool SentOrder(System.Int32? salesOrderId, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_SentOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SalesOrderId", SqlDbType.Int).Value = salesOrderId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to  Sent Order", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[006] start
        /// <summary>
        /// GetListCustomerOrderValue 
        /// Calls [usp_selectAll_Customer_Order_Value]
        /// </summary>
        public override List<SalesOrderDetails> GetListCustomerOrderValue(System.Int32? loginId,System.Int32? clientId)//, System.Int32? topToSelect
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_Customer_Order_Value", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@SalesmannO", SqlDbType.Int).Value = loginId;
                //cmd.Parameters.Add("@TopToSelect", SqlDbType.Int).Value = topToSelect;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SalesOrderDetails> lst = new List<SalesOrderDetails>();
                while (reader.Read())
                {
                    SalesOrderDetails obj = new SalesOrderDetails();
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.TotalValue = GetReaderValue_Int32(reader, "TotalValue", 0);
                    obj.AvailableCreditLimit = GetReaderValue_Int32(reader, "AvailCredit", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.RowCSS = GetReaderValue_String(reader, "RowCSS", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SalesOrders", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[008] start
        public override Int32 SaveSOPaymentInfo(System.Int32 salesOrderNumber, System.String receiptNo, System.String originalFilename,String generatedFilename, System.Int32 createdBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_Save_SO_PaymentInfo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SalesOrderNo", SqlDbType.Int).Value = salesOrderNumber;
                cmd.Parameters.Add("@ReceiptNo", SqlDbType.VarChar, 50).Value = receiptNo;
                cmd.Parameters.Add("@OriginalFilename", SqlDbType.VarChar,200).Value = originalFilename;
                cmd.Parameters.Add("@GeneratedFilename", SqlDbType.VarChar, 200).Value = generatedFilename;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = createdBy;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@Id"].Value;
            }
            catch (SqlException sqlex)
            {
                throw new Exception("Failed to insert SalesOrder", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[008] end
        //[009] start
        public override List<PDFDocumentDetails> GetSOPaymentAttachment(System.Int32 SalesOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_Get_SO_Payment_Attachment", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SalesOrderNo", SqlDbType.Int).Value = SalesOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PDFDocumentDetails> lstPDF = new List<PDFDocumentDetails>();
                while (reader.Read())
                {
                    PDFDocumentDetails obj = new PDFDocumentDetails();
                    obj.PDFDocumentId = GetReaderValue_Int32(reader, "SOPaymentInfoId", 0);
                    obj.FileName = GetReaderValue_String(reader, "FileName", "");
                    obj.GeneratedFileName = GetReaderValue_String(reader, "GeneratedFilename", "");
                    obj.UpdatedBy = GetReaderValue_Int32(reader, "UpdatedBy", 0);
                    obj.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null);
                    obj.Caption = GetReaderValue_String(reader, "ReceiptNo", "");
                    lstPDF.Add(obj);
                    obj = null;
                }
                return lstPDF;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get PDF list for sales order", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[009] end
    }
}
