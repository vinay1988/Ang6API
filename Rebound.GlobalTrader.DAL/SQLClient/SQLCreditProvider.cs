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
    public class SqlCreditProvider : CreditProvider
    {
        /// <summary>
        /// Count Credit
        /// Calls [usp_count_Credit_for_Company]
        /// </summary>
        public override Int32 CountForCompany(System.Int32? companyId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_count_Credit_for_Company", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cn.Open();
                return (Int32)ExecuteScalar(cmd);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to count Credit", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Delete Credit
        /// Calls [usp_delete_Credit]
        /// </summary>
        public override bool Delete(System.Int32? creditId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_Credit", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CreditId", SqlDbType.Int).Value = creditId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete Credit", sqlex);
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
        /// Calls [usp_insert_Credit]
        /// </summary>
        public override Int32 Insert(System.Int32? clientNo, System.Int32? companyNo, System.Int32? contactNo, System.DateTime? creditDate, System.Int32? currencyNo, System.Int32? raisedBy, System.Int32? salesman, System.String notes, System.String instructions, System.Int32? shipViaNo, System.String account, System.Double? shippingCost, System.Double? freight, System.Int32? divisionNo, System.Int32? taxNo, System.Int32? invoiceNo, System.Int32? customerRmaNo, System.DateTime? referenceDate, System.String customerPo, System.String customerRma, System.String customerDebit, System.Int32? salesman2, System.Double? salesman2Percent, System.Int32? incotermNo, System.Double? CreditNoteBankFee, System.Int32? updatedBy, System.Boolean isClientInvoice, System.Int32? clientInvoiceLineNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = isClientInvoice == true ? new SqlCommand("usp_insert_ClientCredit", cn) : new SqlCommand("usp_insert_Credit", cn);
              //  cmd = new SqlCommand("usp_insert_Credit", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
                cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
                cmd.Parameters.Add("@CreditDate", SqlDbType.DateTime).Value = creditDate;
                cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
                cmd.Parameters.Add("@RaisedBy", SqlDbType.Int).Value = raisedBy;
                cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
                cmd.Parameters.Add("@ShipViaNo", SqlDbType.Int).Value = shipViaNo;
                cmd.Parameters.Add("@Account", SqlDbType.NVarChar).Value = account;
                cmd.Parameters.Add("@ShippingCost", SqlDbType.Float).Value = shippingCost;
                cmd.Parameters.Add("@Freight", SqlDbType.Float).Value = freight;
                cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
                cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
                cmd.Parameters.Add("@InvoiceNo", SqlDbType.Int).Value = invoiceNo;
                cmd.Parameters.Add("@CustomerRMANo", SqlDbType.Int).Value = customerRmaNo;
                cmd.Parameters.Add("@ReferenceDate", SqlDbType.DateTime).Value = referenceDate;
                cmd.Parameters.Add("@CustomerPO", SqlDbType.NVarChar).Value = customerPo;
                cmd.Parameters.Add("@CustomerRMA", SqlDbType.NVarChar).Value = customerRma;
                cmd.Parameters.Add("@CustomerDebit", SqlDbType.NVarChar).Value = customerDebit;
                cmd.Parameters.Add("@Salesman2", SqlDbType.Int).Value = salesman2;
                cmd.Parameters.Add("@Salesman2Percent", SqlDbType.Float).Value = salesman2Percent;
                cmd.Parameters.Add("@IncotermNo", SqlDbType.Int).Value = incotermNo;
                //[001] code start
                cmd.Parameters.Add("@CreditNoteBankFee", SqlDbType.Float).Value = CreditNoteBankFee;
                //[001] code start
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@isClientInvoice", SqlDbType.Bit).Value = isClientInvoice;
                cmd.Parameters.Add("@ClientInvoiceLineNo", SqlDbType.Int).Value = clientInvoiceLineNo;
                cmd.Parameters.Add("@CreditId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@CreditId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Credit", sqlex);
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
        /// Calls [usp_select_Credit]
        /// </summary>
        public override CreditDetails Get(System.Int32? creditId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Credit", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CreditId", SqlDbType.Int).Value = creditId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetCreditFromReader(reader);
                    CreditDetails obj = new CreditDetails();
                    obj.CreditId = GetReaderValue_Int32(reader, "CreditId", 0);
                    obj.CreditNumber = GetReaderValue_Int32(reader, "CreditNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.CreditDate = GetReaderValue_DateTime(reader, "CreditDate", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.RaisedBy = GetReaderValue_NullableInt32(reader, "RaisedBy", null);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
                    obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
                    obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
                    obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
                    obj.ReferenceDate = GetReaderValue_DateTime(reader, "ReferenceDate", DateTime.MinValue);
                    obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
                    obj.CustomerRMA = GetReaderValue_String(reader, "CustomerRMA", "");
                    obj.CustomerDebit = GetReaderValue_String(reader, "CustomerDebit", "");
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
                    obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.RaiserName = GetReaderValue_String(reader, "RaiserName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.InvoiceNumber = GetReaderValue_NullableInt32(reader, "InvoiceNumber", null);
                    obj.InvoiceDate = GetReaderValue_NullableDateTime(reader, "InvoiceDate", null);
                    obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
                    obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
                    obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    obj.CustomerRMADate = GetReaderValue_NullableDateTime(reader, "CustomerRMADate", null);
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.CreditValue = GetReaderValue_NullableDouble(reader, "CreditValue", null);
                    obj.CreditCost = GetReaderValue_NullableDouble(reader, "CreditCost", null);
                    obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    //[001] code start
                    obj.CreditNoteBankFee = GetReaderValue_NullableDouble(reader, "CreditNoteBankFee", null);
                    //[001] code end
                    obj.ClientCreditNo = GetReaderValue_Int32(reader, "ClientCreditNo", 0);
                    obj.RefNumber = GetReaderValue_NullableInt32(reader, "RefNumber", null);
                    obj.isClientInvoice = GetReaderValue_Boolean(reader, "IsClientInvoice", false);
                    obj.RefClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.RefClientNo = GetReaderValue_NullableInt32(reader, "RefClientNo", null);
                    obj.ClientInvoiceNo = GetReaderValue_NullableInt32(reader, "ClientInvoiceNo", null);
                    obj.ClientInvoiceNumber = GetReaderValue_NullableInt32(reader, "ClientInvoiceNumber", null);
                    obj.ClientInvoiceLineNo = GetReaderValue_NullableInt32(reader, "ClientInvoiceLineNo", null);
                    obj.isExport = GetReaderValue_Boolean(reader, "Exported", false);
                    obj.ExchangeRate = GetReaderValue_NullableDouble(reader, "ExchangeRate", null);
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
                throw new Exception("Failed to get Credit", sqlex);
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
        /// Calls [usp_select_Credit_for_Page]
        /// </summary>
        public override CreditDetails GetForPage(System.Int32? creditId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Credit_for_Page", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CreditId", SqlDbType.Int).Value = creditId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetCreditFromReader(reader);
                    CreditDetails obj = new CreditDetails();
                    obj.CreditId = GetReaderValue_Int32(reader, "CreditId", 0);
                    obj.CreditNumber = GetReaderValue_Int32(reader, "CreditNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", 0);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.isClientInvoice = GetReaderValue_Boolean(reader, "IsClientInvoice", false);
                    obj.RefClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.RefClientNo = GetReaderValue_NullableInt32(reader, "RefClientNo", 0);
                    obj.ClientCreditNo = GetReaderValue_NullableInt32(reader, "ClientCreditNo", 0);
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
                throw new Exception("Failed to get Credit", sqlex);
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
        /// Calls [usp_select_Credit_for_Print]
        /// </summary>
        public override CreditDetails GetForPrint(System.Int32? creditId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Credit_for_Print", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CreditId", SqlDbType.Int).Value = creditId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetCreditFromReader(reader);
                    CreditDetails obj = new CreditDetails();
                    obj.CreditId = GetReaderValue_Int32(reader, "CreditId", 0);
                    obj.CreditNumber = GetReaderValue_Int32(reader, "CreditNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.CreditDate = GetReaderValue_DateTime(reader, "CreditDate", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.RaisedBy = GetReaderValue_NullableInt32(reader, "RaisedBy", null);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
                    obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
                    obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
                    obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
                    obj.ReferenceDate = GetReaderValue_DateTime(reader, "ReferenceDate", DateTime.MinValue);
                    obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
                    obj.CustomerRMA = GetReaderValue_String(reader, "CustomerRMA", "");
                    obj.CustomerDebit = GetReaderValue_String(reader, "CustomerDebit", "");
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
                    obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.RaiserName = GetReaderValue_String(reader, "RaiserName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.InvoiceNumber = GetReaderValue_NullableInt32(reader, "InvoiceNumber", null);
                    obj.InvoiceDate = GetReaderValue_NullableDateTime(reader, "InvoiceDate", null);
                    obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
                    obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
                    obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    obj.CustomerRMADate = GetReaderValue_NullableDateTime(reader, "CustomerRMADate", null);
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.CreditValue = GetReaderValue_NullableDouble(reader, "CreditValue", null);
                    obj.CreditCost = GetReaderValue_NullableDouble(reader, "CreditCost", null);
                    obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    obj.CompanyTelephone = GetReaderValue_String(reader, "CompanyTelephone", "");
                    obj.CompanyFax = GetReaderValue_String(reader, "CompanyFax", "");
                    obj.ContactEmail = GetReaderValue_String(reader, "ContactEmail", "");
                    obj.CreditNoteBankFee = GetReaderValue_NullableDouble(reader, "CreditNoteBankFee", null);
                    obj.VATNO = GetReaderValue_String(reader, "VATNo", "");

                    obj.ClientCreditNo = GetReaderValue_Int32(reader, "ClientCreditNo", 0);
                    obj.RefNumber = GetReaderValue_NullableInt32(reader, "RefNumber", null);
                    obj.isClientInvoice = GetReaderValue_Boolean(reader, "IsClientInvoice", false);
                    obj.RefClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.RefClientNo = GetReaderValue_NullableInt32(reader, "RefClientNo", null);
                    obj.ClientInvoiceNo = GetReaderValue_NullableInt32(reader, "ClientInvoiceNo", null);
                    obj.ClientInvoiceNumber = GetReaderValue_NullableInt32(reader, "ClientInvoiceNumber", null);


                    obj.ClientShipTo = GetReaderValue_String(reader, "ClientShipTo", "");
                    obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
                    obj.Fax = GetReaderValue_String(reader, "Fax", "");
                    obj.ClientCustomerCode = GetReaderValue_String(reader, "ClientCustomerCode", "");
                    obj.Email = GetReaderValue_String(reader, "Email", "");
                    obj.VAT = GetReaderValue_String(reader, "VAT", "");
                    obj.Tax = GetReaderValue_String(reader, "Tax", "");
                    obj.ClientBillToAdr = GetReaderValue_String(reader, "ClientBillToAdr", "");

                    obj.ExchangeRate = GetReaderValue_NullableDouble(reader, "ExchangeRate", null);
                    obj.LocalCurrencyNo = GetReaderValue_NullableInt32(reader, "LocalCurrencyNo", 0);
                    obj.ApplyLocalCurrency = GetReaderValue_NullableBoolean(reader, "ApplyLocalCurrency", false);
                    obj.LocalCurrencyCode = GetReaderValue_String(reader, "LocalCurrencyCode", "");

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
                throw new Exception("Failed to get Credit", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetIdByNumber 
        /// Calls [usp_select_Credit_Id_by_Number]
        /// </summary>
        public override CreditDetails GetIdByNumber(System.Int32? creditNumber, System.Int32? clientNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Credit_Id_by_Number", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CreditNumber", SqlDbType.Int).Value = creditNumber;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetCreditFromReader(reader);
                    CreditDetails obj = new CreditDetails();
                    obj.CreditId = GetReaderValue_Int32(reader, "CreditId", 0);
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
                throw new Exception("Failed to get Credit", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetNextNumber 
        /// Calls [usp_select_Credit_NextNumber]
        /// </summary>
        public override CreditDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Credit_NextNumber", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@NewNumber", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetCreditFromReader(reader);
                    CreditDetails obj = new CreditDetails();
                    obj.CreditNumber = GetReaderValue_Int32(reader, "CreditNumber", 0);
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
                throw new Exception("Failed to get Credit", sqlex);
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
        /// Calls [usp_selectAll_Credit_for_Company]
        /// </summary>
        public override List<CreditDetails> GetListForCompany(System.Int32? companyId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_Credit_for_Company", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CreditDetails> lst = new List<CreditDetails>();
                while (reader.Read())
                {
                    CreditDetails obj = new CreditDetails();
                    obj.CreditId = GetReaderValue_Int32(reader, "CreditId", 0);
                    obj.CreditNumber = GetReaderValue_Int32(reader, "CreditNumber", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.CreditDate = GetReaderValue_DateTime(reader, "CreditDate", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.RaisedBy = GetReaderValue_NullableInt32(reader, "RaisedBy", null);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
                    obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
                    obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
                    obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
                    obj.ReferenceDate = GetReaderValue_DateTime(reader, "ReferenceDate", DateTime.MinValue);
                    obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
                    obj.CustomerRMA = GetReaderValue_String(reader, "CustomerRMA", "");
                    obj.CustomerDebit = GetReaderValue_String(reader, "CustomerDebit", "");
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
                    obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.RaiserName = GetReaderValue_String(reader, "RaiserName", "");
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.InvoiceNumber = GetReaderValue_NullableInt32(reader, "InvoiceNumber", null);
                    obj.InvoiceDate = GetReaderValue_NullableDateTime(reader, "InvoiceDate", null);
                    obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
                    obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
                    obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    obj.CustomerRMADate = GetReaderValue_NullableDateTime(reader, "CustomerRMADate", null);
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.CreditValue = GetReaderValue_NullableDouble(reader, "CreditValue", null);
                    obj.CreditCost = GetReaderValue_NullableDouble(reader, "CreditCost", null);
                    obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Credits", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update Credit
        /// Calls [usp_update_Credit]
        /// </summary>
        public override bool Update(System.Int32? creditId, System.String customerPo, System.String customerRma, System.String customerDebit, System.String notes, System.String instructions, System.Int32? divisionNo, System.Int32? salesman, System.Int32? raisedBy, System.DateTime? creditDate, System.DateTime? referenceDate, System.Int32? taxNo, System.Int32? currencyNo, System.Int32? shipViaNo, System.String account, System.Double? shippingCost, System.Double? freight, System.Int32? salesman2, System.Double? salesman2Percent, System.Int32? incotermNo, System.Double? CreditNoteBankFee, System.Int32? updatedBy, System.Double? exchangeRate)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Credit", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CreditId", SqlDbType.Int).Value = creditId;
                cmd.Parameters.Add("@CustomerPO", SqlDbType.NVarChar).Value = customerPo;
                cmd.Parameters.Add("@CustomerRMA", SqlDbType.NVarChar).Value = customerRma;
                cmd.Parameters.Add("@CustomerDebit", SqlDbType.NVarChar).Value = customerDebit;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
                cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
                cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
                cmd.Parameters.Add("@RaisedBy", SqlDbType.Int).Value = raisedBy;
                cmd.Parameters.Add("@CreditDate", SqlDbType.DateTime).Value = creditDate;
                cmd.Parameters.Add("@ReferenceDate", SqlDbType.DateTime).Value = referenceDate;
                cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
                cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
                cmd.Parameters.Add("@ShipViaNo", SqlDbType.Int).Value = shipViaNo;
                cmd.Parameters.Add("@Account", SqlDbType.NVarChar).Value = account;
                cmd.Parameters.Add("@ShippingCost", SqlDbType.Float).Value = shippingCost;
                cmd.Parameters.Add("@Freight", SqlDbType.Float).Value = freight;
                cmd.Parameters.Add("@Salesman2", SqlDbType.Int).Value = salesman2;
                cmd.Parameters.Add("@Salesman2Percent", SqlDbType.Float).Value = salesman2Percent;
                cmd.Parameters.Add("@IncotermNo", SqlDbType.Int).Value = incotermNo;
                //[001] start code
                cmd.Parameters.Add("@CreditNoteBankFee", SqlDbType.Float).Value = CreditNoteBankFee;
                //[001] end code
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@ExchangeRate", SqlDbType.Float).Value = exchangeRate;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Credit", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }



        /// <summary>
        /// Update Invoice
        /// Calls [usp_update_Credit_Export]
        /// </summary>
        public override bool UpdateExport(System.Int32? creditId, System.Int32? exportedBy, System.Boolean? export)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Credit_Export", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CreditId", SqlDbType.Int).Value = creditId;
                cmd.Parameters.Add("@ExportedBy", SqlDbType.Int).Value = exportedBy;
                cmd.Parameters.Add("@Export", SqlDbType.Bit).Value = export;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Credit", sqlex);
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