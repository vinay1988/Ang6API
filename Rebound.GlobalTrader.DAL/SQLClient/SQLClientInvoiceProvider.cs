//Marker     Changed by      Date               Remarks
//[001]      Vinay           11/06/2013         CR:- Client Invoice
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
    public class SqlClientInvoiceProvider : ClientInvoiceProvider
    {
       /// <summary>
       /// Call Proc [usp_select_ClientInvoice]
       /// Get the client invoice by ClientinvoiceId
       /// </summary>
       /// <param name="clientInvoiceId"></param>
       /// <returns></returns>
       public override ClientInvoiceDetails Get(System.Int32? clientInvoiceId)
       {
           SqlConnection cn = null;
           SqlCommand cmd = null;
           try
           {
               cn = new SqlConnection(this.ConnectionString);
               cmd = new SqlCommand("usp_select_ClientInvoice", cn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandTimeout = 30;
               cmd.Parameters.Add("@ClientInvoiceId", SqlDbType.Int).Value = clientInvoiceId;
               cn.Open();
               DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
               if (reader.Read())
               {
                   ClientInvoiceDetails obj = new ClientInvoiceDetails();
                   obj.ClientInvoiceID = GetReaderValue_Int32(reader, "ClientInvoiceID", 0);
                   obj.ClientInvoiceNumber = GetReaderValue_String(reader, "ClientInvoiceNumber", "");
                   obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                   obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                   obj.ClientInvoiceDate = GetReaderValue_DateTime(reader, "ClientInvoiceDate", DateTime.MinValue);
                   obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
                   obj.Clientname = GetReaderValue_String(reader, "Clientname", "");
                   obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                   obj.InvoiceAmount = GetReaderValue_NullableDouble(reader, "InvoiceAmount", null);
                   obj.GoodsValue = GetReaderValue_NullableDouble(reader, "GoodsValue", null);
                   obj.Tax = GetReaderValue_NullableDouble(reader, "Tax", null);
                   obj.DeliveryCharge = GetReaderValue_NullableDouble(reader, "DeliveryCharge", null);
                   obj.CreditCardFee = GetReaderValue_NullableDouble(reader, "CreditCardFee", null);
                   obj.BankFee = GetReaderValue_NullableDouble(reader, "BankFee", null);
                   obj.Exported = GetReaderValue_Boolean(reader, "Exported", false);
                   obj.Notes = GetReaderValue_String(reader, "Notes", "");
                   obj.SecondRef = GetReaderValue_String(reader, "SecondRef", "");
                   obj.Narrative = GetReaderValue_String(reader, "Narrative", "");
                   obj.CanbeExported = GetReaderValue_Boolean(reader, "CanbeExported", false);
                   obj.URNNumber = GetReaderValue_NullableInt64(reader, "URNNumber", null);
                   obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                   obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                   obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                   obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                   obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                   obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
                   obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                   obj.TaxCode = GetReaderValue_String(reader, "TaxCode", "");
                   obj.InternalPurchaseOrderNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNo", 0);
                   obj.InternalPurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNumber", 0);
                   obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                   obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", 0);
                   obj.SalesmanNo = GetReaderValue_NullableInt32(reader, "Salesman", null);
                   obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                   obj.InvoiceClientNo = GetReaderValue_Int32(reader, "InvoiceClientNo", 0);
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
               throw new Exception("Failed to get Client Invoice", sqlex);
           }
           finally
           {
               cmd.Dispose();
               cn.Close();
               cn.Dispose();
           }
       }

       /// <summary>
       /// Call Proc [usp_insert_ClientInvoiceManual]
       /// Insert client invoice header
       /// </summary>
       /// <param name="clientNo"></param>
       /// <param name="companyNo"></param>
       /// <param name="supplierInvoiceNumber"></param>
       /// <param name="supplierInvoiceDate"></param>
       /// <param name="supplierCode"></param>
       /// <param name="supplierName"></param>
       /// <param name="cuurencyNo"></param>
       /// <param name="amount"></param>
       /// <param name="goodsValue"></param>
       /// <param name="Tax"></param>
       /// <param name="deliveryCharge"></param>
       /// <param name="bankFee"></param>
       /// <param name="creditCardFee"></param>
       /// <param name="notes"></param>
       /// <param name="secondRef"></param>
       /// <param name="narrative"></param>
       /// <param name="canBeExported"></param>
       /// <param name="taxNo"></param>
       /// <param name="TaxCode"></param>
       /// <param name="currencyCode"></param>
       /// <param name="updatedBy"></param>
       /// <returns></returns>
       public override Int32 Insert(System.Int32? clientNo, System.Int32? PurchaseHubClientNo, 
           System.Double? amount, System.Double? goodsValue, System.Double? tax, System.Int32? taxNo, System.String taxCode, System.Double? deliveryCharge, System.Double? bankFee,
           System.Double? creditCardFee, System.String notes, System.String secondRef, System.String narrative, System.Boolean? canBeExported, System.Int32 updatedBy, System.Int32? currencyNo, System.String currencyCode)

       {
           SqlConnection cn = null;
           SqlCommand cmd = null;
           try
           {
               cn = new SqlConnection(this.ConnectionString);
               cmd = new SqlCommand("usp_insert_ClientInvoiceManual", cn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
               cmd.Parameters.Add("@PurchaseHubClientNo", SqlDbType.Int).Value = PurchaseHubClientNo;
             
               cmd.Parameters.Add("@InvoiceAmount", SqlDbType.Float).Value = amount;
               cmd.Parameters.Add("@GoodsValue", SqlDbType.Float).Value = goodsValue;
               cmd.Parameters.Add("@Tax", SqlDbType.Float).Value = tax;
               cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
               cmd.Parameters.Add("@TaxCode", SqlDbType.NVarChar).Value = taxCode;
               cmd.Parameters.Add("@DeliveryCharge", SqlDbType.Float).Value = deliveryCharge;
               cmd.Parameters.Add("@BankFee", SqlDbType.Float).Value = bankFee;
               cmd.Parameters.Add("@CreditCardFee", SqlDbType.Float).Value = creditCardFee;
               cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
               cmd.Parameters.Add("@SecondRef", SqlDbType.NVarChar).Value = secondRef;
               cmd.Parameters.Add("@Narrative", SqlDbType.NVarChar).Value = narrative;
               cmd.Parameters.Add("@CanbeExported", SqlDbType.Bit).Value = canBeExported;          
               cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
               cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
               cmd.Parameters.Add("@CurrencyCode", SqlDbType.NVarChar).Value = currencyCode;
               cmd.Parameters.Add("@ClientInvoiceNo", SqlDbType.Int).Direction = ParameterDirection.Output;
               cn.Open();
               int ret = ExecuteNonQuery(cmd);
               return (Int32)cmd.Parameters["@ClientInvoiceNo"].Value;
           }
           catch (SqlException sqlex)
           {
               //LogException(sqlex);
               throw new Exception("Failed to insert Client Invoice", sqlex);
           }
           finally
           {
               cmd.Dispose();
               cn.Close();
               cn.Dispose();
           }
       }
       /// <summary>
       /// Call Proc [usp_datalistnugget_ClientInvoice]
       /// Get list of supplier invoice on basis of following search criteria
       /// </summary>
       /// <param name="clientId"></param>
       /// <param name="orderBy"></param>
       /// <param name="sortDir"></param>
       /// <param name="pageIndex"></param>
       /// <param name="pageSize"></param>
       /// <param name="supplierInvoiceNumber"></param>
       /// <param name="urnNoLo"></param>
       /// <param name="urnNoHi"></param>
       /// <param name="purchaseOrderNoLo"></param>
       /// <param name="purchaseOrderNoHi"></param>
       /// <param name="goodsInNoLo"></param>
       /// <param name="goodsInNoHi"></param>
       /// <param name="supplierInvoiceDateFrom"></param>
       /// <param name="supplierInvoiceDateTo"></param>
       /// <param name="cmSearch"></param>
       /// <param name="recentOnly"></param>
       /// <param name="cannotBeExported"></param>
       /// <returns></returns>
       public override List<ClientInvoiceDetails> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? ciNoLo, System.Int32? ciNoHi, System.Int32? urnNoLo, System.Int32? urnNoHi, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? goodsInNoLo, System.Int32? goodsInNoHi, System.DateTime? clientInvoiceDateFrom, System.DateTime? clientInvoiceDateTo, System.String cmSearch, System.Boolean? recentOnly, System.Boolean? exportedOnly, System.Boolean? approveandUnExported, System.Boolean? cannotBeExported, System.Int32? selectedClientNo, System.Boolean? isPOHub)
       {
           SqlConnection cn = null;
           SqlCommand cmd = null;
           try
           {
               cn = new SqlConnection(this.ConnectionString);
               if (isPOHub==true)
               {
                   cmd = new SqlCommand("usp_datalistnugget_ClientInvoice", cn);
               }
               else
               {
                   cmd = new SqlCommand("usp_datalistnugget_ClientInvoiceForClient", cn);
               }
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandTimeout = 60;
               cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
               cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
               cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
               cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
               cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
               //cmd.Parameters.Add("@ClientInvoiceNumber", SqlDbType.NVarChar).Value = clientInvoiceNumber;
               cmd.Parameters.Add("@CINoLo", SqlDbType.Int).Value = ciNoLo;
               cmd.Parameters.Add("@CINoHi", SqlDbType.Int).Value = ciNoHi;
               cmd.Parameters.Add("@URNNoLo", SqlDbType.Int).Value = urnNoLo;
               cmd.Parameters.Add("@URNNoHi", SqlDbType.Int).Value = urnNoHi;
               cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
               cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
               cmd.Parameters.Add("@GoodsInNoLo", SqlDbType.Int).Value = goodsInNoLo;
               cmd.Parameters.Add("@GoodsInNoHi", SqlDbType.Int).Value = goodsInNoHi;
               cmd.Parameters.Add("@ClientInvoiceDateFrom", SqlDbType.DateTime).Value = clientInvoiceDateFrom;
               cmd.Parameters.Add("@ClientInvoiceDateTo", SqlDbType.DateTime).Value = clientInvoiceDateTo;
               cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
               cmd.Parameters.Add("@RecentOnly", SqlDbType.Bit).Value = recentOnly;
               cmd.Parameters.Add("@ExportedOnly", SqlDbType.Bit).Value = exportedOnly;
               cmd.Parameters.Add("@ApproveAndUnExported", SqlDbType.Bit).Value = approveandUnExported;
               cmd.Parameters.Add("@CannotBeExported", SqlDbType.Bit).Value = cannotBeExported;
               cmd.Parameters.Add("@SelectedClientNo", SqlDbType.Int).Value = selectedClientNo;
               cn.Open();
               DbDataReader reader = ExecuteReader(cmd);
               List<ClientInvoiceDetails> lst = new List<ClientInvoiceDetails>();
               while (reader.Read())
               {
                   ClientInvoiceDetails obj = new ClientInvoiceDetails();
                   obj.ClientInvoiceID = GetReaderValue_Int32(reader, "ClientInvoiceId", 0);
                   obj.ClientInvoiceNumber = GetReaderValue_String(reader, "ClientInvoiceNumber", "");
                   obj.Clientname = GetReaderValue_String(reader, "Clientname", "");
                   obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
                   obj.GoodsInNo = GetReaderValue_Int32(reader, "GoodsInId", 0);
                   obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                   obj.ClientInvoiceDate = GetReaderValue_DateTime(reader, "ClientInvoiceDate", DateTime.MinValue);
                   obj.Part = GetReaderValue_String(reader, "Part", "");
                   obj.InvoiceAmount = GetReaderValue_NullableDouble(reader, "InvoiceAmount", null);
                   obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                   obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                   obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                   obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                   obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                   obj.URNNumber = GetReaderValue_NullableInt64(reader, "URNNumber", null);
                   obj.InternalPurchaseOrderNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNo", null);
                   obj.InternalPurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNumber", null);
                   lst.Add(obj);
                   obj = null;
               }
               return lst;
           }
           catch (SqlException sqlex)
           {
               //LogException(sqlex);
               throw new Exception("Failed to get supplier invoice", sqlex);
           }
           finally
           {
               cmd.Dispose();
               cn.Close();
               cn.Dispose();
           }
       }

       /// <summary>
       /// Get detail for supplier invoice detail page
       /// Call Proc [usp_select_SupplierInvoice_for_Page]
       /// </summary>
       /// <param name="supplierInvoiceId"></param>
       /// <returns></returns>
       public override ClientInvoiceDetails GetForPage(System.Int32? clientInvoiceId, System.Boolean? isPOHub)
       {
           SqlConnection cn = null;
           SqlCommand cmd = null;
           try
           {
               cn = new SqlConnection(this.ConnectionString);
               if (isPOHub == true)
               {
                   cmd = new SqlCommand("usp_select_ClientInvoice_for_Page", cn);
               }
               else
               {
                   cmd = new SqlCommand("usp_select_ClientInvoice_for_PageClient", cn);
               }
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandTimeout = 30;
               cmd.Parameters.Add("@ClientInvoiceId", SqlDbType.Int).Value = clientInvoiceId;
               cn.Open();
               DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
               if (reader.Read())
               {
                   ClientInvoiceDetails obj = new ClientInvoiceDetails();
                   obj.ClientInvoiceID = GetReaderValue_Int32(reader, "ClientInvoiceID", 0);
                   obj.ClientInvoiceNumber = GetReaderValue_String(reader, "ClientInvoiceNumber", "");
                   obj.Clientname = GetReaderValue_String(reader, "Clientname", "");
                   obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                   obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                   
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
               throw new Exception("Failed to get Client invoice", sqlex);
           }
           finally
           {
               cmd.Dispose();
               cn.Close();
               cn.Dispose();
           }
       }
       /// <summary>
       /// Update client invoice main info
       /// Call Proc [usp_update_ClientInvoice]
       /// </summary>
       /// <param name="clientInvoiceId"></param>
       /// <param name="clientInvoiceId"></param>
       /// <param name="clientInvoiceDate"></param>
       /// <param name="currencyNo"></param>
       /// <param name="amount"></param>
       /// <param name="goodsValue"></param>
       /// <param name="tax"></param>
       /// <param name="deliveryCharge"></param>
       /// <param name="bankFee"></param>
       /// <param name="creditCardFee"></param>
       /// <param name="canbeExported"></param>
       /// <param name="notes"></param>
       /// <param name="taxCode"></param>
       /// <param name="currencyCode"></param>
       /// <param name="secondRef"></param>
       /// <param name="narrtive"></param>
       /// <param name="updatedBy"></param>
       /// <returns></returns>
       public override bool Update(System.Int32 clientInvoiceId, System.String clientInvoiceNumber, System.DateTime? clientInvoiceDate, System.Int32? currencyNo, System.Double? amount, System.Double? goodsValue, System.Double? tax, System.Double? deliveryCharge, System.Double? bankFee, System.Double? creditCardFee, System.Boolean? canbeExported, System.String notes, System.Int32? taxNo, System.String taxCode, System.String currencyCode, System.String secondRef, System.String narrative, System.Int32 updatedBy, System.Int64? urnNumber)
       {
           SqlConnection cn = null;
           SqlCommand cmd = null;
           try
           {
               cn = new SqlConnection(this.ConnectionString);
               cmd = new SqlCommand("usp_update_ClientInvoice", cn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@ClientInvoiceId", SqlDbType.Int).Value = clientInvoiceId;
               //cmd.Parameters.Add("@ClientInvoiceNumber", SqlDbType.NVarChar).Value = clientInvoiceNumber;
               cmd.Parameters.Add("@ClientInvoiceDate", SqlDbType.DateTime).Value = clientInvoiceDate;
               cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
               cmd.Parameters.Add("@InvoiceAmount", SqlDbType.Float).Value = amount;
               cmd.Parameters.Add("@GoodsValue", SqlDbType.Float).Value = goodsValue;
               cmd.Parameters.Add("@Tax", SqlDbType.Float).Value = tax;
               cmd.Parameters.Add("@DeliveryCharge", SqlDbType.Float).Value = deliveryCharge;
               cmd.Parameters.Add("@BankFee", SqlDbType.Float).Value = bankFee;
               cmd.Parameters.Add("@CreditCardFee", SqlDbType.Float).Value = creditCardFee;
               //cmd.Parameters.Add("@CanBeExported", SqlDbType.Bit).Value = canbeExported;
               cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
               cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
              cmd.Parameters.Add("@TaxCode", SqlDbType.NVarChar).Value = taxCode;
               cmd.Parameters.Add("@CurrencyCode", SqlDbType.NVarChar).Value = currencyCode;
               cmd.Parameters.Add("@SecondRef", SqlDbType.NVarChar).Value = secondRef;
               cmd.Parameters.Add("@Narrative", SqlDbType.NVarChar).Value = narrative;
               cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
               //cmd.Parameters.Add("@URNNumber", SqlDbType.BigInt).Value = urnNumber;
               cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
               cn.Open();
               int ret = ExecuteNonQuery(cmd);
               return (ret > 0);
           }
           catch (SqlException sqlex)
           {
               //LogException(sqlex);
               throw new Exception("Failed to update Client Invoice", sqlex);
           }
           finally
           {
               cmd.Dispose();
               cn.Close();
               cn.Dispose();
           }
       }

       /// <summary>
       /// Update header after updating supplier invoice line
       /// Call Proc [usp_updateHeader_SupplierInvoice]
       /// </summary>
       /// <param name="supplierInvoiceId"></param>
       /// <param name="secondRef"></param>
       /// <param name="narrative"></param>
       /// <param name="updatedBy"></param>
       /// <returns></returns>
       public override bool UpdateHeader(System.Int32 clientInvoiceId, System.String secondRef, System.String narrative,System.Boolean? canBeExported, System.Int32 updatedBy)
       {
           SqlConnection cn = null;
           SqlCommand cmd = null;
           try
           {
               cn = new SqlConnection(this.ConnectionString);
               cmd = new SqlCommand("usp_updateHeader_ClientInvoice", cn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@ClientInvoiceId", SqlDbType.Int).Value = clientInvoiceId;
               cmd.Parameters.Add("@SecondRef", SqlDbType.NVarChar).Value = secondRef;
               cmd.Parameters.Add("@Narrative", SqlDbType.NVarChar).Value = narrative;
               cmd.Parameters.Add("@CanBeExported", SqlDbType.Bit).Value = canBeExported;
               cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
               cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
               cn.Open();
               int ret = ExecuteNonQuery(cmd);
               return (ret > 0);
           }
           catch (SqlException sqlex)
           {
               //LogException(sqlex);
               throw new Exception("Failed to update Client Invoice", sqlex);
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
       /// Calls [usp_select_ClientInvoice_for_Print]
       /// </summary>
       public override ClientInvoiceDetails GetForPrint(System.Int32? clientInvoiceId)
       {
           SqlConnection cn = null;
           SqlCommand cmd = null;
           try
           {
               cn = new SqlConnection(this.ConnectionString);
               cmd = new SqlCommand("usp_select_ClientInvoice_for_Print", cn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandTimeout = 30;
               cmd.Parameters.Add("@ClientInvoiceId", SqlDbType.Int).Value = clientInvoiceId;
               cn.Open();
               DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
               if (reader.Read())
               {
                   //return GetInvoiceFromReader(reader);
                   ClientInvoiceDetails obj = new ClientInvoiceDetails();
                   obj.ClientInvoiceID = GetReaderValue_Int32(reader, "ClientInvoiceId", 0);
                   obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                   obj.ClientInvoiceNumber = GetReaderValue_String(reader, "ClientInvoiceNumber", "");
                   //obj.ClientInvoiceDate = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
                   obj.ClientInvoiceDate = GetReaderValue_DateTime(reader, "ClientInvoiceDate", DateTime.MinValue);
                   //obj.Notes = GetReaderValue_String(reader, "Notes", "");
                   //obj.Instructions = GetReaderValue_String(reader, "Instructions", "");
                   obj.ClientBillto = GetReaderValue_String(reader, "clientBillto", "");
                   obj.ClientShipTo = GetReaderValue_String(reader, "clientShipTo", "");
                   //obj.ShipViaNo = GetReaderValue_Int32(reader, "ShipViaNo", 0);
                   //obj.Account = GetReaderValue_String(reader, "Account", "");
                   //obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
                   //obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
                   //obj.FreeOnBoard = GetReaderValue_String(reader, "FreeOnBoard", "");
                   //obj.Boxes = GetReaderValue_NullableInt32(reader, "Boxes", null);
                   //obj.Weight = GetReaderValue_NullableDouble(reader, "Weight", null);
                   //obj.DimensionalWeight = GetReaderValue_NullableDouble(reader, "DimensionalWeight", null);
                   //obj.WeightInPounds = GetReaderValue_Boolean(reader, "WeightInPounds", false);
                   //obj.AirWayBill = GetReaderValue_String(reader, "AirWayBill", "");
                   //obj.ShippedBy = GetReaderValue_NullableInt32(reader, "ShippedBy", null);
                   //obj.Printed = GetReaderValue_NullableInt32(reader, "Printed", null);
                   //obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
                   //obj.ShippingNotes = GetReaderValue_String(reader, "ShippingNotes", "");
                   //obj.Exported = GetReaderValue_Boolean(reader, "Exported", false);
                   //obj.InvoicePaid = GetReaderValue_Boolean(reader, "InvoicePaid", false);
                   //obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
                   //obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
                   //obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                   //obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                   //obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
                   //obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
                   //obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
                   //obj.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null);
                   //
                   //obj.TermsNo = GetReaderValue_NullableInt32(reader, "TermsNo", null);
                   //obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
                   //obj.ShipToAddressNo = GetReaderValue_NullableInt32(reader, "ShipToAddressNo", null);
                   //obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                   //obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
                   //obj.DateOrdered = GetReaderValue_NullableDateTime(reader, "DateOrdered", null);
                   //obj.CofCNotes = GetReaderValue_String(reader, "CofCNotes", "");
                   //obj.BillToAddressNo = GetReaderValue_NullableInt32(reader, "BillToAddressNo", null);
                   //obj.IncotermNo = GetReaderValue_NullableInt32(reader, "IncotermNo", null);
                   //obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                   //obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                  
                   //obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
                   //obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                   //obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
                   //obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                   //obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
                   //obj.TermsName = GetReaderValue_String(reader, "TermsName", "");
                   //obj.ShippedByName = GetReaderValue_String(reader, "ShippedByName", "");
                   //obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                   //obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                   //obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                   //obj.VATNo = GetReaderValue_String(reader, "VATNo", "");
                   //obj.ShipViaName = GetReaderValue_String(reader, "ShipViaName", "");
                   //obj.InvoiceValue = GetReaderValue_NullableDouble(reader, "InvoiceValue", null);
                   //obj.LandedCostValue = GetReaderValue_NullableDouble(reader, "LandedCostValue", null);
                   //obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                   //obj.StatusText = GetReaderValue_String(reader, "StatusText", "");
                   //obj.IncotermName = GetReaderValue_String(reader, "IncotermName", "");
                   //obj.CompanyTelephone = GetReaderValue_String(reader, "CompanyTelephone", "");
                   //obj.CompanyFax = GetReaderValue_String(reader, "CompanyFax", "");
                   //obj.ContactEmail = GetReaderValue_String(reader, "ContactEmail", "");
                   //obj.PrintNotes = GetReaderValue_String(reader, "PrintNotes", "");
                   ////[001] Code start
                   //obj.CompanyRegNo = GetReaderValue_String(reader, "CompanyRegNo", "");
                   ////[001] Code end
                   ////[002] code start
                   //obj.CurrencyNotes = GetReaderValue_String(reader, "CurrencyNotes", "");
                   ////[002] code end
                   ////[009] code start
                   //obj.InvoiceBankFee = GetReaderValue_Double(reader, "InvoiceBankFee", 0);
                   //obj.IsApplyBankFee = GetReaderValue_NullableBoolean(reader, "IsApplyBankFee", false);
                   ////[009] code end
                   //obj.ExchangeRate = GetReaderValue_NullableDouble(reader, "ExchangeRate", null);
                   //obj.LocalCurrencyNo = GetReaderValue_NullableInt32(reader, "LocalCurrencyNo", 0);
                   //obj.ApplyLocalCurrency = GetReaderValue_NullableBoolean(reader, "ApplyLocalCurrency", false);
                   //obj.LocalCurrencyCode = GetReaderValue_String(reader, "LocalCurrencyCode", "");
                   //obj.ShipToVatNo = GetReaderValue_String(reader, "ShipToVatNo", "");                
                   obj.Fax = GetReaderValue_String(reader, "Fax", "");
                   obj.Telephone = GetReaderValue_String(reader, "Telephone", "");
                   obj.CustomerCode = GetReaderValue_String(reader, "CustomerCode", "");
                   obj.Vat = GetReaderValue_String(reader, "Vat", "");
                   obj.Email = GetReaderValue_String(reader, "Email", "");
                   obj.TaxRate = GetReaderValue_NullableDouble(reader, "TaxRate", null);
                   obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                   obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                   obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                   obj.Tax = GetReaderValue_NullableDouble(reader, "Tax", 0);
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
               throw new Exception("Failed to get Invoice", sqlex);
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
       /// Calls [usp_itemsearch_ClientInvoice]
       /// </summary>
       public override List<ClientInvoiceDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? GoodsInNoLo, System.Int32? GoodsInNoHi, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.DateTime? invoiceDateFrom, System.DateTime? invoiceDateTo, System.Int32? ClientDebitNoLo, System.Int32? ClientDebitNoHi)
       {
           SqlConnection cn = null;
           SqlCommand cmd = null;
           try
           {
               cn = new SqlConnection(this.ConnectionString);
               cmd = new SqlCommand("usp_itemsearch_ClientInvoice", cn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandTimeout = 60;
               cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
               cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
               cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
               cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
               cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;

               cmd.Parameters.Add("@GoodsInNoLo", SqlDbType.Int).Value = GoodsInNoLo;
               cmd.Parameters.Add("@GoodsInNoHi", SqlDbType.Int).Value = GoodsInNoHi;

               cmd.Parameters.Add("@InvoiceNoLo", SqlDbType.Int).Value = invoiceNoLo;
               cmd.Parameters.Add("@InvoiceNoHi", SqlDbType.Int).Value = invoiceNoHi;

               cmd.Parameters.Add("@InvoiceDateFrom", SqlDbType.DateTime).Value = invoiceDateFrom;
               cmd.Parameters.Add("@InvoiceDateTo", SqlDbType.DateTime).Value = invoiceDateTo;

               cmd.Parameters.Add("@ClientDebitNoLo", SqlDbType.Int).Value = ClientDebitNoLo;
               cmd.Parameters.Add("@ClientDebitNoHi", SqlDbType.Int).Value = ClientDebitNoHi;

               cn.Open();
               DbDataReader reader = ExecuteReader(cmd);
               List<ClientInvoiceDetails> lst = new List<ClientInvoiceDetails>();
               while (reader.Read())
               {
                   ClientInvoiceDetails obj = new ClientInvoiceDetails();
                   obj.ClientInvoiceID = GetReaderValue_Int32(reader, "ClientInvoiceId", 0);
                   obj.ClientInvoiceNumber = GetReaderValue_String(reader, "ClientInvoiceNumber", "");
                   obj.ClientInvoiceDate = GetReaderValue_DateTime(reader, "ClientInvoiceDate", DateTime.MinValue);
                   // obj.GoodsInNo = GetReaderValue_Int32(reader, "GoodsInNo", 0);
                   obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                   obj.ClientCompanyName = GetReaderValue_String(reader, "Clientname", "");
                   obj.Narrative = GetReaderValue_String(reader, "Narrative", "");
                   obj.SecondRef = GetReaderValue_String(reader, "SecondRef", "");
                   obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                   obj.SalesmanName = GetReaderValue_String(reader, "SalesManName", "");
                   obj.ClientInvoiceLineNo = GetReaderValue_Int32(reader, "ClientInvoiceLineId", 0);
                   lst.Add(obj);
                   obj = null;
               }
               return lst;
           }
           catch (SqlException sqlex)
           {
               //LogException(sqlex);
               throw new Exception("Failed to get Invoices", sqlex);
           }
           finally
           {
               cmd.Dispose();
               cn.Close();
               cn.Dispose();
           }
       }

       /// <summary>
       /// Call Proc [usp_select_ClientInvoiceByLineNo]
       /// Get the Client invoice by ClientinvoiceId and Line No
       /// </summary>
       /// <param name="clientInvoiceId"></param>
       /// <returns></returns>
       public override ClientInvoiceDetails GetClientInvoiceByLineNo(System.Int32? clientInvoiceId, System.Int32? clientInvoiceLineNo)
       {
           SqlConnection cn = null;
           SqlCommand cmd = null;
           try
           {
               cn = new SqlConnection(this.ConnectionString);
               cmd = new SqlCommand("usp_select_ClientInvoiceByLineNo", cn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandTimeout = 30;
               cmd.Parameters.Add("@ClientInvoiceId", SqlDbType.Int).Value = clientInvoiceId;
               cmd.Parameters.Add("@ClientInvoiceLineNo", SqlDbType.Int).Value = clientInvoiceLineNo;
               cn.Open();
               DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
               if (reader.Read())
               {
                   ClientInvoiceDetails obj = new ClientInvoiceDetails();
                   obj.ClientInvoiceID = GetReaderValue_Int32(reader, "ClientInvoiceID", 0);
                   obj.ClientInvoiceNumber = GetReaderValue_String(reader, "ClientInvoiceNumber", "");
                   obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                   obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                   obj.ClientInvoiceDate = GetReaderValue_DateTime(reader, "ClientInvoiceDate", DateTime.MinValue);
                   obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
                   obj.Clientname = GetReaderValue_String(reader, "Clientname", "");
                   obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                   obj.InvoiceAmount = GetReaderValue_NullableDouble(reader, "InvoiceAmount", null);
                   obj.GoodsValue = GetReaderValue_NullableDouble(reader, "GoodsValue", null);
                   obj.Tax = GetReaderValue_NullableDouble(reader, "Tax", null);
                   obj.DeliveryCharge = GetReaderValue_NullableDouble(reader, "DeliveryCharge", null);
                   obj.CreditCardFee = GetReaderValue_NullableDouble(reader, "CreditCardFee", null);
                   obj.BankFee = GetReaderValue_NullableDouble(reader, "BankFee", null);
                   obj.Exported = GetReaderValue_Boolean(reader, "Exported", false);
                   obj.Notes = GetReaderValue_String(reader, "Notes", "");
                   obj.SecondRef = GetReaderValue_String(reader, "SecondRef", "");
                   obj.Narrative = GetReaderValue_String(reader, "Narrative", "");
                   obj.CanbeExported = GetReaderValue_Boolean(reader, "CanbeExported", false);
                   obj.URNNumber = GetReaderValue_NullableInt64(reader, "URNNumber", null);
                   obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                   obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                   obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                   obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                   obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                   obj.TaxNo = GetReaderValue_NullableInt32(reader, "TaxNo", null);
                   obj.TaxName = GetReaderValue_String(reader, "TaxName", "");
                   obj.TaxCode = GetReaderValue_String(reader, "TaxCode", "");
                   obj.InternalPurchaseOrderNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNo", 0);
                   obj.InternalPurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNumber", 0);
                   obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
                   obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", 0);
                   obj.SalesmanNo = GetReaderValue_NullableInt32(reader, "Salesman", null);
                   obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
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
               throw new Exception("Failed to get Client Invoice", sqlex);
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
