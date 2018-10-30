/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to upload pdf document for supplierRMA section
[002]      Aashu Singh     01/06/2018   Quick Jump in Global Warehouse
[003]      Aashu Singh     06/07/2018   Save internal log for SRMA
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
    public class SqlSupplierRmaProvider : SupplierRmaProvider
    {
        /// <summary>
        /// Count SupplierRma
        /// Calls [usp_count_SupplierRMA_for_Client]
        /// </summary>
        public override Int32 CountForClient(System.Int32? clientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_count_SupplierRMA_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                return (Int32)ExecuteScalar(cmd);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to count SupplierRma", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Count SupplierRma
        /// Calls [usp_count_SupplierRMA_for_Company]
        /// </summary>
        public override Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeComplete)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_count_SupplierRMA_for_Company", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@IncludeComplete", SqlDbType.Bit).Value = includeComplete;
                cn.Open();
                return (Int32)ExecuteScalar(cmd);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to count SupplierRma", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Count SupplierRma
        /// Calls [usp_count_SupplierRMA_shipping_for_Client]
        /// </summary>
        public override Int32 CountShippingForClient(System.Int32? clientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_count_SupplierRMA_shipping_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                return (Int32)ExecuteScalar(cmd);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to count SupplierRma", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Delete SupplierRma
        /// Calls [usp_delete_SupplierRMA]
        /// </summary>
        public override bool Delete(System.Int32? supplierRmaId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_SupplierRMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SupplierRMAId", SqlDbType.Int).Value = supplierRmaId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete SupplierRma", sqlex);
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
        /// Calls [usp_insert_SupplierRMA]
        /// </summary>
        public override Int32 Insert(System.Int32? clientNo, System.Int32? purchaseOrderNo, System.Int32? authorisedBy, System.DateTime? supplierRmaDate, System.String notes, System.String instructions, System.Int32? shipViaNo, System.String account, System.Int32? shipToAddressNo, System.String reference, System.Int32? companyNo, System.Int32? contactNo, System.Int32? divisionNo, System.Int32? incotermNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_SupplierRMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@PurchaseOrderNo", SqlDbType.Int).Value = purchaseOrderNo;
                cmd.Parameters.Add("@AuthorisedBy", SqlDbType.Int).Value = authorisedBy;
                cmd.Parameters.Add("@SupplierRMADate", SqlDbType.DateTime).Value = supplierRmaDate;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
                cmd.Parameters.Add("@ShipViaNo", SqlDbType.Int).Value = shipViaNo;
                cmd.Parameters.Add("@Account", SqlDbType.NVarChar).Value = account;
                cmd.Parameters.Add("@ShipToAddressNo", SqlDbType.Int).Value = shipToAddressNo;
                cmd.Parameters.Add("@Reference", SqlDbType.NVarChar).Value = reference;
                cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
                cmd.Parameters.Add("@ContactNo", SqlDbType.Int).Value = contactNo;
                cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
                cmd.Parameters.Add("@IncotermNo", SqlDbType.Int).Value = incotermNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@SupplierRMAId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@SupplierRMAId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert SupplierRma", sqlex);
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
        /// Calls [usp_itemsearch_SupplierRMA]
        /// </summary>
        public override List<SupplierRmaDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.String srmaNotesSearch, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? supplierRmaNoLo, System.Int32? supplierRmaNoHi, System.DateTime? supplierRmaDateFrom, System.DateTime? supplierRmaDateTo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_itemsearch_SupplierRMA", cn);
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
                cmd.Parameters.Add("@SRMANotesSearch", SqlDbType.NVarChar).Value = srmaNotesSearch;
                cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
                cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
                cmd.Parameters.Add("@SupplierRMANoLo", SqlDbType.Int).Value = supplierRmaNoLo;
                cmd.Parameters.Add("@SupplierRMANoHi", SqlDbType.Int).Value = supplierRmaNoHi;
                cmd.Parameters.Add("@SupplierRMADateFrom", SqlDbType.DateTime).Value = supplierRmaDateFrom;
                cmd.Parameters.Add("@SupplierRMADateTo", SqlDbType.DateTime).Value = supplierRmaDateTo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SupplierRmaDetails> lst = new List<SupplierRmaDetails>();
                while (reader.Read())
                {
                    SupplierRmaDetails obj = new SupplierRmaDetails();
                    obj.SupplierRMAId = GetReaderValue_Int32(reader, "SupplierRMAId", 0);
                    obj.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0);
                    obj.SupplierRMADate = GetReaderValue_DateTime(reader, "SupplierRMADate", DateTime.MinValue);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SupplierRmas", sqlex);
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
        /// Calls [usp_select_SupplierRMA]
        /// </summary>
        public override SupplierRmaDetails Get(System.Int32? supplierRmaId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SupplierRMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SupplierRMAId", SqlDbType.Int).Value = supplierRmaId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSupplierRmaFromReader(reader);
                    SupplierRmaDetails obj = new SupplierRmaDetails();
                    obj.SupplierRMAId = GetReaderValue_Int32(reader, "SupplierRMAId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0);
                    obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
                    obj.AuthorisedBy = GetReaderValue_Int32(reader, "AuthorisedBy", 0);
                    obj.SupplierRMADate = GetReaderValue_DateTime(reader, "SupplierRMADate", DateTime.MinValue);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.ShipToAddressNo = GetReaderValue_Int32(reader, "ShipToAddressNo", 0);
                    obj.Reference = GetReaderValue_String(reader, "Reference", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
                    obj.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", "");
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.FullCompanyName = GetReaderValue_String(reader, "FullCompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
                    obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
                    obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
                    obj.QuantityShipped = GetReaderValue_NullableInt32(reader, "QuantityShipped", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    obj.POBuyerName = GetReaderValue_String(reader, "POBuyerName", "");
                    obj.ClientSupplierRMANo = GetReaderValue_NullableInt32(reader, "ClientSupplierRMANo", null);
                    obj.InternalPurchaseOrderNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNo", 0);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNumber", 0);
                    obj.RefNumber = GetReaderValue_NullableInt32(reader, "RefNumber", null);
                    obj.IPOCompanyNo = GetReaderValue_NullableInt32(reader, "IPOCompanyNo", 0);
                    obj.IPOCompanyName = GetReaderValue_String(reader, "IPOCompanyName", "");
                    obj.isLockUpdateClient = GetReaderValue_NullableBoolean(reader, "ishublocked", null);
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
                throw new Exception("Failed to get SupplierRma", sqlex);
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
        /// Calls [usp_select_SupplierRMA_by_Number]
        /// </summary>
        public override SupplierRmaDetails GetByNumber(System.Int32? supplierRmaNumber, System.Int32? clientNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SupplierRMA_by_Number", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SupplierRMANumber", SqlDbType.Int).Value = supplierRmaNumber;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSupplierRmaFromReader(reader);
                    SupplierRmaDetails obj = new SupplierRmaDetails();
                    obj.SupplierRMAId = GetReaderValue_Int32(reader, "SupplierRMAId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0);
                    obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
                    obj.AuthorisedBy = GetReaderValue_Int32(reader, "AuthorisedBy", 0);
                    obj.SupplierRMADate = GetReaderValue_DateTime(reader, "SupplierRMADate", DateTime.MinValue);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.ShipToAddressNo = GetReaderValue_Int32(reader, "ShipToAddressNo", 0);
                    obj.Reference = GetReaderValue_String(reader, "Reference", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
                    obj.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", "");
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.FullCompanyName = GetReaderValue_String(reader, "FullCompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
                    obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
                    obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
                    obj.QuantityShipped = GetReaderValue_NullableInt32(reader, "QuantityShipped", null);
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
                throw new Exception("Failed to get SupplierRma", sqlex);
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
        /// Calls [usp_select_SupplierRMA_for_Page]
        /// </summary>
        public override SupplierRmaDetails GetForPage(System.Int32? supplierRmaId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SupplierRMA_for_Page", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SupplierRMAId", SqlDbType.Int).Value = supplierRmaId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSupplierRmaFromReader(reader);
                    SupplierRmaDetails obj = new SupplierRmaDetails();
                    obj.SupplierRMAId = GetReaderValue_Int32(reader, "SupplierRMAId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    // [001] code start
                    obj.IsPDFAvailable = GetReaderValue_Boolean(reader, "IsPDFAvailable", false);
                    // [001] code end
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", 0);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
                    obj.IPOCompanyNo = GetReaderValue_NullableInt32(reader, "IPOCompanyNo", 0);
                    obj.IPOCompanyName = GetReaderValue_String(reader, "IPOCompanyName", "");
                    obj.InternalPurchaseOrderId = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderId", null);
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
                throw new Exception("Failed to get SupplierRma", sqlex);
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
        /// Calls [usp_select_SupplierRMA_for_Print]
        /// </summary>
        public override SupplierRmaDetails GetForPrint(System.Int32? supplierRmaId, bool IsHUBsupplierRmaId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SupplierRMA_for_Print", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SupplierRMAId", SqlDbType.Int).Value = supplierRmaId;
                cmd.Parameters.Add("@IsHUBsupplierRmaId", SqlDbType.Bit).Value = IsHUBsupplierRmaId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSupplierRmaFromReader(reader);
                    SupplierRmaDetails obj = new SupplierRmaDetails();
                    obj.SupplierRMAId = GetReaderValue_Int32(reader, "SupplierRMAId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0);
                    obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
                    obj.AuthorisedBy = GetReaderValue_Int32(reader, "AuthorisedBy", 0);
                    obj.SupplierRMADate = GetReaderValue_DateTime(reader, "SupplierRMADate", DateTime.MinValue);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.ShipToAddressNo = GetReaderValue_Int32(reader, "ShipToAddressNo", 0);
                    obj.Reference = GetReaderValue_String(reader, "Reference", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
                    obj.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", "");
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.FullCompanyName = GetReaderValue_String(reader, "FullCompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
                    obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
                    obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
                    obj.QuantityShipped = GetReaderValue_NullableInt32(reader, "QuantityShipped", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    obj.CompanyTelephone = GetReaderValue_String(reader, "CompanyTelephone", "");
                    obj.CompanyFax = GetReaderValue_String(reader, "CompanyFax", "");
                    obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
                    obj.ContactEmail = GetReaderValue_String(reader, "ContactEmail", "");
                    obj.POHubCompanyNo = GetReaderValue_NullableInt32(reader, "POHubCompanyNo", null);
                    obj.POHubCompanyName = GetReaderValue_String(reader, "POHubCompanyName", "");
                    obj.ClientRefNo = GetReaderValue_String(reader, "ClientRefNo", "");
                    obj.HubShipToAddressNo = GetReaderValue_Int32(reader, "HubShipToAddressNo", 0);
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
                throw new Exception("Failed to get SupplierRma", sqlex);
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
        /// Calls [usp_select_SupplierRMA_ID_by_Number]
        /// </summary>
        public override List<SupplierRmaDetails> GetIDByNumber(System.Int32? supplierRmaNumber, System.Int32? clientNo, System.Int32? isGlobalUser)
        {
            //[002] start
            SqlConnection cn = null;
            SqlCommand cmd = null;
            List<SupplierRmaDetails> lstSRMAD = new List<SupplierRmaDetails>();
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SupplierRMA_ID_by_Number", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SupplierRMANumber", SqlDbType.Int).Value = supplierRmaNumber;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@IsGlobalUser", SqlDbType.Int).Value = isGlobalUser;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                while (reader.Read())
                {
                    //return GetSupplierRmaFromReader(reader);
                    SupplierRmaDetails obj = new SupplierRmaDetails();
                    obj.SupplierRMAId = GetReaderValue_Int32(reader, "SupplierRMAId", 0);
                    obj.SRMANumberDetail = GetReaderValue_String(reader, "SRMANumberDetail", "true");
                    lstSRMAD.Add(obj);
                }
                return lstSRMAD;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SupplierRma", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
            //[002] end
        }


        /// <summary>
        /// GetNextNumber 
        /// Calls [usp_select_SupplierRMA_NextNumber]
        /// </summary>
        public override SupplierRmaDetails GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SupplierRMA_NextNumber", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@NewNumber", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetSupplierRmaFromReader(reader);
                    SupplierRmaDetails obj = new SupplierRmaDetails();
                    obj.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0);
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
                throw new Exception("Failed to get SupplierRma", sqlex);
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
        /// Calls [usp_selectAll_SupplierRMA_for_Company]
        /// </summary>
        public override List<SupplierRmaDetails> GetListForCompany(System.Int32? companyId, System.Boolean? includeComplete)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_SupplierRMA_for_Company", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CompanyId", SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add("@IncludeComplete", SqlDbType.Bit).Value = includeComplete;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SupplierRmaDetails> lst = new List<SupplierRmaDetails>();
                while (reader.Read())
                {
                    SupplierRmaDetails obj = new SupplierRmaDetails();
                    obj.SupplierRMAId = GetReaderValue_Int32(reader, "SupplierRMAId", 0);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.SupplierRMANumber = GetReaderValue_Int32(reader, "SupplierRMANumber", 0);
                    obj.PurchaseOrderNo = GetReaderValue_Int32(reader, "PurchaseOrderNo", 0);
                    obj.AuthorisedBy = GetReaderValue_Int32(reader, "AuthorisedBy", 0);
                    obj.SupplierRMADate = GetReaderValue_DateTime(reader, "SupplierRMADate", DateTime.MinValue);
                    obj.Notes = GetReaderValue_String(reader, "Notes", "");
                    obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                    obj.ShipViaNo = GetReaderValue_NullableInt32(reader, "ShipViaNo", null);
                    obj.Account = GetReaderValue_String(reader, "Account", "");
                    obj.ShipToAddressNo = GetReaderValue_Int32(reader, "ShipToAddressNo", 0);
                    obj.Reference = GetReaderValue_String(reader, "Reference", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
                    obj.DivisionNo = GetReaderValue_Int32(reader, "DivisionNo", 0);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.PurchaseOrderNumber = GetReaderValue_Int32(reader, "PurchaseOrderNumber", 0);
                    obj.AuthoriserName = GetReaderValue_String(reader, "AuthoriserName", "");
                    obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                    obj.FullCompanyName = GetReaderValue_String(reader, "FullCompanyName", "");
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
                    obj.TaxNo = GetReaderValue_Int32(reader, "TaxNo", 0);
                    obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                    obj.Buyer = GetReaderValue_Int32(reader, "Buyer", 0);
                    obj.Quantity = GetReaderValue_NullableInt32(reader, "Quantity", null);
                    obj.QuantityShipped = GetReaderValue_NullableInt32(reader, "QuantityShipped", null);
                    obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get SupplierRmas", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update SupplierRma
        /// Calls [usp_update_SupplierRMA]
        /// </summary>
        public override bool Update(System.Int32? supplierRmaId, System.String notes, System.String instructions, System.String reference, System.Int32? shipToAddressNo, System.DateTime? supplierRmaDate, System.Int32? shipViaNo, System.String account, System.Int32? incotermNo, System.Int32? updatedBy, bool? isLockUpdateClient)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_SupplierRMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SupplierRMAId", SqlDbType.Int).Value = supplierRmaId;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@Instructions", SqlDbType.NVarChar).Value = instructions;
                cmd.Parameters.Add("@Reference", SqlDbType.NVarChar).Value = reference;
                cmd.Parameters.Add("@ShipToAddressNo", SqlDbType.Int).Value = shipToAddressNo;
                cmd.Parameters.Add("@SupplierRMADate", SqlDbType.DateTime).Value = supplierRmaDate;
                cmd.Parameters.Add("@ShipViaNo", SqlDbType.Int).Value = shipViaNo;
                cmd.Parameters.Add("@Account", SqlDbType.NVarChar).Value = account;
                cmd.Parameters.Add("@IncotermNo", SqlDbType.Int).Value = incotermNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@isLockUpdateClient", SqlDbType.Bit).Value = isLockUpdateClient;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update SupplierRma", sqlex);
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
        /// GetPDFListForSupplierRMA 
        /// Calls [usp_selectAll_PDF_for_SupplierRMA]
        /// </summary>
        public override List<PDFDocumentDetails> GetPDFListForSupplierRMA(System.Int32? SupplierRMAId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_PDF_for_SupplierRMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@SupplierRMANo", SqlDbType.Int).Value = SupplierRMAId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PDFDocumentDetails> lstPDF = new List<PDFDocumentDetails>();
                while (reader.Read())
                {
                    PDFDocumentDetails obj = new PDFDocumentDetails();
                    obj.PDFDocumentId = GetReaderValue_Int32(reader, "SupplierRMAPDFId", 0);
                    obj.PDFDocumentRefNo = GetReaderValue_Int32(reader, "SupplierRMANo", 0);
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
                throw new Exception("Failed to get PDF list for supplier rma", sqlex);
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
        /// Calls [usp_insert_SupplierRMAPDF]
        /// </summary>
        public override Int32 Insert(System.Int32? SupplierRMAId, System.String Caption, System.String FileName, System.Int32? UpdatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_SupplierRMAPDF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SupplierRMANo", SqlDbType.Int).Value = SupplierRMAId;
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
                throw new Exception("Failed to insert supplier rma pdf", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Delete supplier rma pdf
        /// Calls[usp_delete_SupplierRMAPDF]
        /// </summary>
        public override bool DeleteSupplierRMAPDF(System.Int32? SupplierRMAPdfId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_SupplierRMAPDF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SupplierRMAPDFId", SqlDbType.Int).Value = SupplierRMAPdfId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete supplier rma pdf", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        // [001] code end
        //[003] start
        public override Int32 InsertSRMAInternalLog(System.Int32 SupplierRMAId, System.String notes, System.Int32 UpdatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_SRMAInternalLog", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SupplierRMANo", SqlDbType.Int).Value = SupplierRMAId;
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
                throw new Exception("Failed to save supplier rma internal log", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        public override List<SupplierRmaDetails> GetSRMAInternalLog(System.Int32 supplierRmaNumber)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_GetSRMAInternalLog", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SupplierRMANo", SqlDbType.Int).Value = supplierRmaNumber;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<SupplierRmaDetails> lstPDF = new List<SupplierRmaDetails>();
                while (reader.Read())
                {
                    SupplierRmaDetails obj = new SupplierRmaDetails();
                    obj.SRMAExpediteNotesId = GetReaderValue_Int32(reader, "SRMAExpediteNotesId", 0);
                    obj.Notes = GetReaderValue_String(reader, "ExpediteNotes", "");
                    obj.EmployeeName = GetReaderValue_String(reader, "EmployeeName", "");
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.Now);
                    lstPDF.Add(obj);
                    obj = null;
                }
                return lstPDF;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get supplier rma internal log", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        //[003] end


    }
}