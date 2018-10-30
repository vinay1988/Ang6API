
/*

Marker     changed by      date         Remarks

[001]      Abhinav       17/11/20011   ESMS Ref:25 & 34  - Virtual Stock Update & Closeing of line CRMA
[002]      Ranjit        14/08/2014    TreeView - add Reason1 and Reason2 id   
//[003]      Suhail          15/05/2018   Added Avoidable on CRMA Line
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
    public class SqlCustomerRmaLineProvider : CustomerRmaLineProvider
    {
        /// <summary>
        /// DataListNugget 
        /// Calls [usp_datalistnugget_CustomerRMALine]
        /// </summary>
        public override List<CustomerRmaLineDetails> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String crmaNotesSearch, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.DateTime? customerRmaDateFrom, System.DateTime? customerRmaDateTo, System.Boolean? includeReceived, System.Boolean? recentOnly, System.Boolean? PohubOnly, System.Int32? clientSearch, Boolean IsGlobalLogin)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_datalistnugget_CustomerRMALine", cn);
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
                cmd.Parameters.Add("@CRMANotesSearch", SqlDbType.NVarChar).Value = crmaNotesSearch;
                cmd.Parameters.Add("@InvoiceNoLo", SqlDbType.Int).Value = invoiceNoLo;
                cmd.Parameters.Add("@InvoiceNoHi", SqlDbType.Int).Value = invoiceNoHi;
                cmd.Parameters.Add("@CustomerRMANoLo", SqlDbType.Int).Value = customerRmaNoLo;
                cmd.Parameters.Add("@CustomerRMANoHi", SqlDbType.Int).Value = customerRmaNoHi;
                cmd.Parameters.Add("@CustomerRMADateFrom", SqlDbType.DateTime).Value = customerRmaDateFrom;
                cmd.Parameters.Add("@CustomerRMADateTo", SqlDbType.DateTime).Value = customerRmaDateTo;
                cmd.Parameters.Add("@IncludeReceived", SqlDbType.Bit).Value = includeReceived;
                cmd.Parameters.Add("@RecentOnly", SqlDbType.Bit).Value = recentOnly;
                cmd.Parameters.Add("@PoHubOnly", SqlDbType.Bit).Value = PohubOnly;
                cmd.Parameters.Add("@ClientSearch", SqlDbType.Int).Value = clientSearch;
                cmd.Parameters.Add("@IsGlobalLogin", SqlDbType.Bit).Value = IsGlobalLogin;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CustomerRmaLineDetails> lst = new List<CustomerRmaLineDetails>();
                while (reader.Read())
                {
                    CustomerRmaLineDetails obj = new CustomerRmaLineDetails();
                    obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
                    obj.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0);
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.CustomerRMADate = GetReaderValue_DateTime(reader, "CustomerRMADate", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRmaLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// DataListNuggetReadyToReceive 
        /// Calls [usp_datalistnugget_CustomerRMALine_ReadyToReceive]
        /// </summary>
        public override List<CustomerRmaLineDetails> DataListNuggetReadyToReceive(System.Int32? clientId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String crmaNotesSearch, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.DateTime? customerRmaDateFrom, System.DateTime? customerRmaDateTo, System.Int32? clientSearch, Boolean IsGlobalLogin)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_datalistnugget_CustomerRMALine_ReadyToReceive", cn);
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
                cmd.Parameters.Add("@SalesmanSearch", SqlDbType.Int).Value = salesmanSearch;
                cmd.Parameters.Add("@CRMANotesSearch", SqlDbType.NVarChar).Value = crmaNotesSearch;
                cmd.Parameters.Add("@InvoiceNoLo", SqlDbType.Int).Value = invoiceNoLo;
                cmd.Parameters.Add("@InvoiceNoHi", SqlDbType.Int).Value = invoiceNoHi;
                cmd.Parameters.Add("@CustomerRMANoLo", SqlDbType.Int).Value = customerRmaNoLo;
                cmd.Parameters.Add("@CustomerRMANoHi", SqlDbType.Int).Value = customerRmaNoHi;
                cmd.Parameters.Add("@CustomerRMADateFrom", SqlDbType.DateTime).Value = customerRmaDateFrom;
                cmd.Parameters.Add("@CustomerRMADateTo", SqlDbType.DateTime).Value = customerRmaDateTo;
                cmd.Parameters.Add("@ClientSearch", SqlDbType.Int).Value = clientSearch;
                cmd.Parameters.Add("@IsGlobalLogin", SqlDbType.Bit).Value = IsGlobalLogin;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CustomerRmaLineDetails> lst = new List<CustomerRmaLineDetails>();
                while (reader.Read())
                {
                    CustomerRmaLineDetails obj = new CustomerRmaLineDetails();
                    obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
                    obj.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0);
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.CustomerRMADate = GetReaderValue_DateTime(reader, "CustomerRMADate", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.QuantityReceived = GetReaderValue_NullableInt32(reader, "QuantityReceived", null);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRmaLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Delete CustomerRmaLine
        /// Calls [usp_delete_CustomerRMALine]
        /// </summary>
        public override bool Delete(System.Int32? customerRmaLineId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            Int32 rowAffected = 0;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_CustomerRMALine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustomerRMALineId", SqlDbType.Int).Value = customerRmaLineId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);

                rowAffected = Convert.ToInt32(cmd.Parameters["@RowsAffected"].Value);

                return (rowAffected > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete CustomerRmaLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        // [001] code  start
        /// <summary>
        /// Update CustomerRmaLine
        /// Calls [usp_UpdateClose_CustomerRMALine]
        /// </summary>
        public override bool UpdateClose(System.Int32? customerRmaLineId, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_UpdateClose_CustomerRMALine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustomerRMALineId", SqlDbType.Int).Value = customerRmaLineId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete CustomerRmaLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        // [001] code  end


        /// <summary>
        /// Create a new row
        /// Calls [usp_insert_CustomerRMALine]
        /// </summary>
        public override Int32 Insert(System.Int32? customerRmaNo, System.Int32? invoiceLineNo, System.DateTime? returnDate, System.String reason, System.String reason1, System.String reason2, System.Int32? quantity, System.String notes, System.String rootCause, System.Int32? updatedBy, out int customerRMAId, out int customerRMANumber, System.Int32? stockNo, System.Boolean? avoidable, System.Boolean? printHazardous)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_CustomerRMALine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustomerRMANo", SqlDbType.Int).Value = customerRmaNo;
                cmd.Parameters.Add("@InvoiceLineNo", SqlDbType.Int).Value = invoiceLineNo;
                cmd.Parameters.Add("@ReturnDate", SqlDbType.DateTime).Value = returnDate;
                cmd.Parameters.Add("@Reason", SqlDbType.NVarChar).Value = reason;
                cmd.Parameters.Add("@Reason1", SqlDbType.NVarChar).Value = reason1;
                cmd.Parameters.Add("@Reason2", SqlDbType.NVarChar).Value = reason2;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@RootCause", SqlDbType.NVarChar).Value = rootCause;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@CustomerRMALineId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CustomerRMAId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CustomerRMANumber", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@POStockNo", SqlDbType.Int).Value = stockNo;
                //[003] Code start
                cmd.Parameters.Add("@IsAvoidable", SqlDbType.Bit).Value = avoidable;
                //[003] Code end
                cmd.Parameters.Add("@PrintHazardous", SqlDbType.Bit).Value = printHazardous;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                customerRMAId = (Int32)(cmd.Parameters["@CustomerRMAId"].Value == null ? 0 : cmd.Parameters["@CustomerRMAId"].Value);
                customerRMANumber = (Int32)(cmd.Parameters["@CustomerRMANumber"].Value == null ? 0 : cmd.Parameters["@CustomerRMANumber"].Value);
                return (Int32)cmd.Parameters["@CustomerRMALineId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert CustomerRmaLine", sqlex);
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
        /// Calls [usp_itemsearch_CustomerRMALine]
        /// </summary>
        public override List<CustomerRmaLineDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? salesman, System.String crmaNotesSearch, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.DateTime? customerRmaDateFrom, System.DateTime? customerRmaDateTo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_itemsearch_CustomerRMALine", cn);
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
                cmd.Parameters.Add("@Salesman", SqlDbType.Int).Value = salesman;
                cmd.Parameters.Add("@CRMANotesSearch", SqlDbType.NVarChar).Value = crmaNotesSearch;
                cmd.Parameters.Add("@InvoiceNoLo", SqlDbType.Int).Value = invoiceNoLo;
                cmd.Parameters.Add("@InvoiceNoHi", SqlDbType.Int).Value = invoiceNoHi;
                cmd.Parameters.Add("@CustomerRMANoLo", SqlDbType.Int).Value = customerRmaNoLo;
                cmd.Parameters.Add("@CustomerRMANoHi", SqlDbType.Int).Value = customerRmaNoHi;
                cmd.Parameters.Add("@CustomerRMADateFrom", SqlDbType.DateTime).Value = customerRmaDateFrom;
                cmd.Parameters.Add("@CustomerRMADateTo", SqlDbType.DateTime).Value = customerRmaDateTo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CustomerRmaLineDetails> lst = new List<CustomerRmaLineDetails>();
                while (reader.Read())
                {
                    CustomerRmaLineDetails obj = new CustomerRmaLineDetails();
                    obj.CustomerRMALineId = GetReaderValue_Int32(reader, "CustomerRMALineId", 0);
                    obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
                    obj.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0);
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.CustomerRMADate = GetReaderValue_DateTime(reader, "CustomerRMADate", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRmaLines", sqlex);
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
        /// Calls [usp_select_CustomerRMALine]
        /// </summary>
        public override CustomerRmaLineDetails Get(System.Int32? customerRmaLineId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_CustomerRMALine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRMALineId", SqlDbType.Int).Value = customerRmaLineId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetCustomerRmaLineFromReader(reader);
                    CustomerRmaLineDetails obj = new CustomerRmaLineDetails();
                    obj.CustomerRMALineId = GetReaderValue_Int32(reader, "CustomerRMALineId", 0);
                    obj.InvoiceLineNo = GetReaderValue_Int32(reader, "InvoiceLineNo", 0);
                    obj.ReturnDate = GetReaderValue_NullableDateTime(reader, "ReturnDate", null);
                    obj.Reason = GetReaderValue_String(reader, "Reason", "");
                    obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0);
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.CustomerRMADate = GetReaderValue_DateTime(reader, "CustomerRMADate", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.QuantityReceived = GetReaderValue_NullableInt32(reader, "QuantityReceived", null);
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
                    obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
                    obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.StockNo = GetReaderValue_NullableInt32(reader, "StockId", null);
                    obj.CreditIds = GetReaderValue_String(reader, "CreditIds", "");
                    obj.CreditNumbers = GetReaderValue_String(reader, "CreditNumbers", "");
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
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRmaLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetForReceiving 
        /// Calls [usp_select_CustomerRMALine_for_Receiving]
        /// </summary>
        public override CustomerRmaLineDetails GetForReceiving(System.Int32? customerRmaLineNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_CustomerRMALine_for_Receiving", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRMALineNo", SqlDbType.Int).Value = customerRmaLineNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetCustomerRmaLineFromReader(reader);
                    CustomerRmaLineDetails obj = new CustomerRmaLineDetails();
                    obj.CustomerRMALineId = GetReaderValue_Int32(reader, "CustomerRMALineId", 0);
                    obj.InvoiceLineNo = GetReaderValue_Int32(reader, "InvoiceLineNo", 0);
                    obj.ReturnDate = GetReaderValue_NullableDateTime(reader, "ReturnDate", null);
                    obj.Reason = GetReaderValue_String(reader, "Reason", "");
                    obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0);
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.CustomerRMADate = GetReaderValue_DateTime(reader, "CustomerRMADate", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.QuantityReceived = GetReaderValue_NullableInt32(reader, "QuantityReceived", null);
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
                    obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
                    obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.InvoiceLineAllocationId = GetReaderValue_Int32(reader, "InvoiceLineAllocationId", 0);
                    obj.Reason2 = GetReaderValue_String(reader, "Reason1", "");
                    obj.Reason2 = GetReaderValue_String(reader, "Reason2", "");
                    obj.RootCause = GetReaderValue_String(reader, "RootCause", "");
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
                throw new Exception("Failed to get CustomerRmaLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListForCustomerRMA 
        /// Calls [usp_selectAll_CustomerRMALine_for_CustomerRMA]
        /// </summary>
        public override List<CustomerRmaLineDetails> GetListForCustomerRMA(System.Int32? customerRmaId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_CustomerRMALine_for_CustomerRMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRMAId", SqlDbType.Int).Value = customerRmaId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CustomerRmaLineDetails> lst = new List<CustomerRmaLineDetails>();
                while (reader.Read())
                {
                    CustomerRmaLineDetails obj = new CustomerRmaLineDetails();
                    obj.CustomerRMALineId = GetReaderValue_Int32(reader, "CustomerRMALineId", 0);
                    obj.InvoiceLineNo = GetReaderValue_Int32(reader, "InvoiceLineNo", 0);
                    obj.ReturnDate = GetReaderValue_NullableDateTime(reader, "ReturnDate", null);
                    obj.Reason = GetReaderValue_String(reader, "Reason", "");
                    obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0);
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.CustomerRMADate = GetReaderValue_DateTime(reader, "CustomerRMADate", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.QuantityReceived = GetReaderValue_NullableInt32(reader, "QuantityReceived", null);
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
                    obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
                    obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    //
                    // [001] code 
                    obj.QuantityShipped = GetReaderValue_NullableInt32(reader, "QuantityShipped", null);
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.Reason1 = GetReaderValue_String(reader, "Reason1", "");
                    obj.Reason2 = GetReaderValue_String(reader, "Reason2", "");
                    obj.RootCause = GetReaderValue_String(reader, "RootCause", "");
                    obj.ParentCustomerRMALineNo = GetReaderValue_Int32(reader, "ParentCustomerRMALineNo", 0);
                    obj.PrintHazardous = GetReaderValue_NullableBoolean(reader, "PrintHazardous", false);
                    // [001] code  end
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRmaLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        // [001] code 
        /// <summary>
        /// GetListForCustomerRMA for open CRMAs
        /// Calls [usp_selectAll_CRMALine_open_for_CustomerCRMA]
        /// </summary>
        public override List<CustomerRmaLineDetails> GetListOpenForCRMA(System.Int32? customerRmaId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_CRMALine_open_for_CustomerCRMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRMAId", SqlDbType.Int).Value = customerRmaId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CustomerRmaLineDetails> lst = new List<CustomerRmaLineDetails>();
                while (reader.Read())
                {
                    CustomerRmaLineDetails obj = new CustomerRmaLineDetails();
                    obj.CustomerRMALineId = GetReaderValue_Int32(reader, "CustomerRMALineId", 0);
                    obj.InvoiceLineNo = GetReaderValue_Int32(reader, "InvoiceLineNo", 0);
                    obj.ReturnDate = GetReaderValue_NullableDateTime(reader, "ReturnDate", null);
                    obj.Reason = GetReaderValue_String(reader, "Reason", "");
                    obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0);
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.CustomerRMADate = GetReaderValue_DateTime(reader, "CustomerRMADate", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.QuantityReceived = GetReaderValue_NullableInt32(reader, "QuantityReceived", null);
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
                    obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
                    obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.Reason1 = GetReaderValue_String(reader, "Reason1", "");
                    obj.Reason2 = GetReaderValue_String(reader, "Reason2", "");
                    obj.RootCause = GetReaderValue_String(reader, "RootCause", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRmaLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        // [001] code start
        /// GetQtyForCustomerRMA 
        /// Calls [usp_GetQty_CustomerRMALine_for_CustomerRMA]
        /// </summary>
        public override CustomerRmaLineDetails GetQtyForCustomerRMA(System.Int32? customerRMALineId, System.Int32? invoiceLineID)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_GetQty_CustomerRMALine_for_CustomerRMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@vCustomerRMALineId", SqlDbType.Int).Value = customerRMALineId;
                cmd.Parameters.Add("@vInvoiceLineNo", SqlDbType.Int).Value = invoiceLineID;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);

                reader.Read();

                CustomerRmaLineDetails obj = new CustomerRmaLineDetails();
                obj.InvoiceLineNo = (Int32)GetReaderValue_NullableInt32(reader, "InvoiceLineNo", null);
                obj.QuantityCRMA = GetReaderValue_NullableInt32(reader, "TOTQTYCRMA", null);
                obj.QuantityReceived = GetReaderValue_NullableInt32(reader, "TOTQtyReceived", null);
                obj.QuantityShipped = GetReaderValue_NullableInt32(reader, "QuantityShipped", null);
                obj.QuantityAvailable = GetReaderValue_Int32(reader, "QtyAvailable", 0);
                reader.Close();
                return obj;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRmaLine Qty", sqlex);
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
        /// GetListForCustomerRMA for closed CRMAS
        /// Calls [usp_selectAll_CRMALine_close_for_CustomerCRMA]
        /// </summary>
        public override List<CustomerRmaLineDetails> GetListClosedForCRMA(System.Int32? customerRmaId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_CRMALine_close_for_CustomerCRMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRMAId", SqlDbType.Int).Value = customerRmaId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CustomerRmaLineDetails> lst = new List<CustomerRmaLineDetails>();
                while (reader.Read())
                {
                    CustomerRmaLineDetails obj = new CustomerRmaLineDetails();
                    obj.CustomerRMALineId = GetReaderValue_Int32(reader, "CustomerRMALineId", 0);
                    obj.InvoiceLineNo = GetReaderValue_Int32(reader, "InvoiceLineNo", 0);
                    obj.ReturnDate = GetReaderValue_NullableDateTime(reader, "ReturnDate", null);
                    obj.Reason = GetReaderValue_String(reader, "Reason", "");
                    obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0);
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.CustomerRMADate = GetReaderValue_DateTime(reader, "CustomerRMADate", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.QuantityReceived = GetReaderValue_NullableInt32(reader, "QuantityReceived", null);
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
                    obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
                    obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.Closed = GetReaderValue_Boolean(reader, "Closed", false);
                    obj.Reason1 = GetReaderValue_String(reader, "Reason1", "");
                    obj.Reason2 = GetReaderValue_String(reader, "Reason2", "");
                    obj.RootCause = GetReaderValue_String(reader, "RootCause", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRmaLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        // 
        // [001] code end 


        /// <summary>
        /// GetListForReceiving 
        /// Calls [usp_selectAll_CustomerRMALine_for_Receiving]
        /// </summary>
        public override List<CustomerRmaLineDetails> GetListForReceiving(System.Int32? customerRmaNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_CustomerRMALine_for_Receiving", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRMANo", SqlDbType.Int).Value = customerRmaNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<CustomerRmaLineDetails> lst = new List<CustomerRmaLineDetails>();
                while (reader.Read())
                {
                    CustomerRmaLineDetails obj = new CustomerRmaLineDetails();
                    obj.CustomerRMALineId = GetReaderValue_Int32(reader, "CustomerRMALineId", 0);
                    obj.InvoiceLineNo = GetReaderValue_Int32(reader, "InvoiceLineNo", 0);
                    obj.ReturnDate = GetReaderValue_NullableDateTime(reader, "ReturnDate", null);
                    obj.Reason = GetReaderValue_String(reader, "Reason", "");
                    obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.CustomerRMAId = GetReaderValue_Int32(reader, "CustomerRMAId", 0);
                    obj.CustomerRMANumber = GetReaderValue_Int32(reader, "CustomerRMANumber", 0);
                    obj.CustomerRMADate = GetReaderValue_DateTime(reader, "CustomerRMADate", DateTime.MinValue);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.InvoiceNumber = GetReaderValue_Int32(reader, "InvoiceNumber", 0);
                    obj.InvoiceNo = GetReaderValue_NullableInt32(reader, "InvoiceNo", null);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.QuantityReceived = GetReaderValue_NullableInt32(reader, "QuantityReceived", null);
                    obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.InvoiceDate = GetReaderValue_DateTime(reader, "InvoiceDate", DateTime.MinValue);
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.Salesman = GetReaderValue_Int32(reader, "Salesman", 0);
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
                    obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
                    obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.InvoiceLineAllocationId = GetReaderValue_Int32(reader, "InvoiceLineAllocationId", 0);
                    obj.Reason1 = GetReaderValue_String(reader, "Reason1", "");
                    obj.Reason2 = GetReaderValue_String(reader, "Reason2", "");
                    obj.RootCause = GetReaderValue_String(reader, "RootCause", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get CustomerRmaLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Update CustomerRmaLine
        /// Calls [usp_update_CustomerRMALine]
        /// </summary>
        public override bool Update(System.Int32? customerRmaLineId, System.Int32? quantity, System.String reason, System.String reason1, System.String notes, System.String rootCause, System.String reason2, System.Int32? updatedBy, System.Boolean? avoidable, System.Boolean? printHazardous)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_CustomerRMALine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CustomerRMALineId", SqlDbType.Int).Value = customerRmaLineId;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                cmd.Parameters.Add("@Reason", SqlDbType.NVarChar).Value = reason;                
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@Reason1", SqlDbType.NVarChar).Value = reason1;
                cmd.Parameters.Add("@Reason2", SqlDbType.NVarChar).Value = reason2;
                cmd.Parameters.Add("@RootCause", SqlDbType.NVarChar).Value = rootCause;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //[003] Code start
                cmd.Parameters.Add("@IsAvoidable", SqlDbType.Bit).Value = avoidable;
                //[003] Code start
                cmd.Parameters.Add("@PrintHazardous", SqlDbType.Bit).Value = printHazardous;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update CustomerRmaLine", sqlex);
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