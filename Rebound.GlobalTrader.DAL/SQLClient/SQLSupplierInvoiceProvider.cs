//Marker     Changed by      Date               Remarks
//[001]      Vinay           11/06/2013         CR:- Supplier Invoice
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
   public class SqlSupplierInvoiceProvider : SupplierInvoiceProvider
    {
       /// <summary>
       /// Call Proc [usp_select_SupplierInvoice]
       /// Get the supplier invoice by supplierinvoiceId
       /// </summary>
       /// <param name="supplierInvoiceId"></param>
       /// <returns></returns>
       public override SupplierInvoiceDetails Get(System.Int32? supplierInvoiceId)
       {
           SqlConnection cn = null;
           SqlCommand cmd = null;
           try
           {
               cn = new SqlConnection(this.ConnectionString);
               cmd = new SqlCommand("usp_select_SupplierInvoice", cn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandTimeout = 30;
               cmd.Parameters.Add("@SupplierInvoiceId", SqlDbType.Int).Value = supplierInvoiceId;
               cn.Open();
               DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
               if (reader.Read())
               {
                   SupplierInvoiceDetails obj = new SupplierInvoiceDetails();
                   obj.SupplierInvoiceID = GetReaderValue_Int32(reader, "SupplierInvoiceID", 0);
                   obj.SupplierInvoiceNumber = GetReaderValue_String(reader, "SupplierInvoiceNumber", "");
                   obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                   obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                   obj.SupplierInvoiceDate = GetReaderValue_DateTime(reader, "SupplierInvoiceDate", DateTime.MinValue);
                   obj.SupplierCode = GetReaderValue_String(reader, "SupplierCode", "");
                   obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
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
                   obj.StatusReasonId = GetReaderValue_NullableInt32(reader, "StatusReasonNo", null);
                   obj.StatusReason = GetReaderValue_String(reader, "StatusReason", "");
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
               throw new Exception("Failed to get Supplier Invoice", sqlex);
           }
           finally
           {
               cmd.Dispose();
               cn.Close();
               cn.Dispose();
           }
       }

       /// <summary>
       /// Call Proc [usp_insert_SupplierInvoice]
       /// Insert supplier invoice header
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
       public override Int32 Insert(System.Int32? clientNo, System.Int32 companyNo, System.String supplierInvoiceNumber, System.DateTime? supplierInvoiceDate, System.String supplierCode, System.String supplierName, System.Int32? currencyNo, System.Double? amount, System.Double? goodsValue, System.Double? tax, System.Double? deliveryCharge, System.Double? bankFee, System.Double? creditCardFee, System.String notes, System.String secondRef, System.String narrative, System.Boolean? canBeExported, System.Int32? taxNo, System.String taxCode, System.String currencyCode, System.Int32 updatedBy,System.Int32? statusReason)
       {
           SqlConnection cn = null;
           SqlCommand cmd = null;
           try
           {
               cn = new SqlConnection(this.ConnectionString);
               cmd = new SqlCommand("usp_insert_SupplierInvoice", cn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
               cmd.Parameters.Add("@CompanyNo", SqlDbType.Int).Value = companyNo;
               cmd.Parameters.Add("@SupplierInvoiceNumber", SqlDbType.NVarChar).Value = supplierInvoiceNumber;
               cmd.Parameters.Add("@SupplierInvoiceDate", SqlDbType.DateTime).Value = supplierInvoiceDate;
               cmd.Parameters.Add("@SupplierCode", SqlDbType.NVarChar).Value = supplierCode;
               cmd.Parameters.Add("@SupplierName", SqlDbType.NVarChar).Value = supplierName;
               cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
               cmd.Parameters.Add("@InvoiceAmount", SqlDbType.Float).Value = amount;
               cmd.Parameters.Add("@GoodsValue", SqlDbType.Float).Value = goodsValue;
               cmd.Parameters.Add("@Tax", SqlDbType.Float).Value = tax;
               cmd.Parameters.Add("@DeliveryCharge", SqlDbType.Float).Value = deliveryCharge;
               cmd.Parameters.Add("@BankFee", SqlDbType.Float).Value = bankFee;
               cmd.Parameters.Add("@CreditCardFee", SqlDbType.Float).Value = creditCardFee;
               cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
               cmd.Parameters.Add("@SecondRef", SqlDbType.NVarChar).Value = secondRef;
               cmd.Parameters.Add("@Narrative", SqlDbType.NVarChar).Value = narrative;
               cmd.Parameters.Add("@CanbeExported", SqlDbType.Bit).Value = canBeExported;
               cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
               cmd.Parameters.Add("@TaxCode", SqlDbType.NVarChar).Value = taxCode;
               cmd.Parameters.Add("@CurrencyCode", SqlDbType.NVarChar).Value = currencyCode;
               cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
               cmd.Parameters.Add("@StatusReason", SqlDbType.Int).Value = statusReason;
               cmd.Parameters.Add("@SupplierInvoiceId", SqlDbType.Int).Direction = ParameterDirection.Output;
               cn.Open();
               int ret = ExecuteNonQuery(cmd);
               return (Int32)cmd.Parameters["@SupplierInvoiceId"].Value;
           }
           catch (SqlException sqlex)
           {
               //LogException(sqlex);
               throw new Exception("Failed to insert Supplier Invoice", sqlex);
           }
           finally
           {
               cmd.Dispose();
               cn.Close();
               cn.Dispose();
           }
       }
       /// <summary>
       /// Call Proc [usp_datalistnugget_SupplierInvoice]
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
       public override List<SupplierInvoiceDetails> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String supplierInvoiceNumber, System.Int32? urnNoLo, System.Int32? urnNoHi, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? goodsInNoLo, System.Int32? goodsInNoHi, System.DateTime? supplierInvoiceDateFrom, System.DateTime? supplierInvoiceDateTo, System.String cmSearch, System.Boolean? recentOnly, System.Boolean? exportedOnly, System.Boolean? approveandUnExported, System.Boolean? cannotBeExported, System.Int32? internalPurchaseOrderNoLo, System.Int32? internalPurchaseOrderNoHi, System.Int32? statusReason)
       {
           SqlConnection cn = null;
           SqlCommand cmd = null;
           try
           {
               cn = new SqlConnection(this.ConnectionString);
               cmd = new SqlCommand("usp_datalistnugget_SupplierInvoice", cn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandTimeout = 60;
               cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
               cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
               cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
               cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
               cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
               cmd.Parameters.Add("@SupplierInvoiceNumber", SqlDbType.NVarChar).Value = supplierInvoiceNumber;
               cmd.Parameters.Add("@URNNoLo", SqlDbType.Int).Value = urnNoLo;
               cmd.Parameters.Add("@URNNoHi", SqlDbType.Int).Value = urnNoHi;
               cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
               cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
               cmd.Parameters.Add("@GoodsInNoLo", SqlDbType.Int).Value = goodsInNoLo;
               cmd.Parameters.Add("@GoodsInNoHi", SqlDbType.Int).Value = goodsInNoHi;
               cmd.Parameters.Add("@SupplierInvoiceDateFrom", SqlDbType.DateTime).Value = supplierInvoiceDateFrom;
               cmd.Parameters.Add("@SupplierInvoiceDateTo", SqlDbType.DateTime).Value = supplierInvoiceDateTo;
               cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
               cmd.Parameters.Add("@RecentOnly", SqlDbType.Bit).Value = recentOnly;
               cmd.Parameters.Add("@ExportedOnly", SqlDbType.Bit).Value = exportedOnly;
               cmd.Parameters.Add("@ApproveAndUnExported", SqlDbType.Bit).Value = approveandUnExported;
               cmd.Parameters.Add("@CannotBeExported", SqlDbType.Bit).Value = cannotBeExported;
               cmd.Parameters.Add("@InternalPurchaseOrderNoLo", SqlDbType.Int).Value = internalPurchaseOrderNoLo;
               cmd.Parameters.Add("@InternalPurchaseOrderNoHi", SqlDbType.Int).Value = internalPurchaseOrderNoHi;
               cmd.Parameters.Add("@StatusReason", SqlDbType.Int).Value = statusReason;
               cn.Open();
               DbDataReader reader = ExecuteReader(cmd);
               List<SupplierInvoiceDetails> lst = new List<SupplierInvoiceDetails>();
               while (reader.Read())
               {
                   SupplierInvoiceDetails obj = new SupplierInvoiceDetails();
                   obj.SupplierInvoiceID = GetReaderValue_Int32(reader, "SupplierInvoiceId", 0);
                   obj.SupplierInvoiceNumber = GetReaderValue_String(reader, "SupplierInvoiceNumber", "");
                   obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
                   obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
                   obj.GoodsInNo = GetReaderValue_Int32(reader, "GoodsInId", 0);
                   obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                   obj.SupplierInvoiceDate = GetReaderValue_DateTime(reader, "SupplierInvoiceDate", DateTime.MinValue);
                   obj.Part = GetReaderValue_String(reader, "Part", "");
                   obj.InvoiceAmount = GetReaderValue_NullableDouble(reader, "InvoiceAmount", null);
                   obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                   obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                   obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                   obj.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0);
                   obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                   obj.URNNumber = GetReaderValue_NullableInt64(reader, "URNNumber", null);
                   obj.InternalPurchaseOrderId = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderId", null);
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
       public override SupplierInvoiceDetails GetForPage(System.Int32? supplierInvoiceId)
       {
           SqlConnection cn = null;
           SqlCommand cmd = null;
           try
           {
               cn = new SqlConnection(this.ConnectionString);
               cmd = new SqlCommand("usp_select_SupplierInvoice_for_Page", cn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandTimeout = 30;
               cmd.Parameters.Add("@SupplierInvoiceId", SqlDbType.Int).Value = supplierInvoiceId;
               cn.Open();
               DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
               if (reader.Read())
               {
                   SupplierInvoiceDetails obj = new SupplierInvoiceDetails();
                   obj.SupplierInvoiceID = GetReaderValue_Int32(reader, "SupplierInvoiceID", 0);
                   obj.SupplierInvoiceNumber = GetReaderValue_String(reader, "SupplierInvoiceNumber", "");
                   obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
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
       /// Update supplier invoice main info
       /// Call Proc [usp_update_SupplierInvoice]
       /// </summary>
       /// <param name="supplierInvoiceId"></param>
       /// <param name="supplierInvoiceId"></param>
       /// <param name="supplierInvoiceDate"></param>
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
       public override bool Update(System.Int32 supplierInvoiceId, System.String supplierInvoiceNumber, System.DateTime? supplierInvoiceDate, System.Int32? currencyNo, System.Double? amount, System.Double? goodsValue, System.Double? tax, System.Double? deliveryCharge, System.Double? bankFee, System.Double? creditCardFee, System.Boolean? canbeExported, System.String notes, System.Int32? taxNo, System.String taxCode, System.String currencyCode, System.String secondRef, System.String narrative, System.Int32 updatedBy, System.Int64? urnNumber, System.Int32? statusReason)
       {
           SqlConnection cn = null;
           SqlCommand cmd = null;
           try
           {
               cn = new SqlConnection(this.ConnectionString);
               cmd = new SqlCommand("usp_update_SupplierInvoice", cn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@SupplierInvoiceId", SqlDbType.Int).Value = supplierInvoiceId;
               cmd.Parameters.Add("@SupplierInvoiceNumber", SqlDbType.NVarChar).Value = supplierInvoiceNumber;
               cmd.Parameters.Add("@SupplierInvoiceDate", SqlDbType.DateTime).Value = supplierInvoiceDate;
               cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
               cmd.Parameters.Add("@InvoiceAmount", SqlDbType.Float).Value = amount;
               cmd.Parameters.Add("@GoodsValue", SqlDbType.Float).Value = goodsValue;
               cmd.Parameters.Add("@Tax", SqlDbType.Float).Value = tax;
               cmd.Parameters.Add("@DeliveryCharge", SqlDbType.Float).Value = deliveryCharge;
               cmd.Parameters.Add("@BankFee", SqlDbType.Float).Value = bankFee;
               cmd.Parameters.Add("@CreditCardFee", SqlDbType.Float).Value = creditCardFee;
               cmd.Parameters.Add("@CanBeExported", SqlDbType.Bit).Value = canbeExported;
               cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
               cmd.Parameters.Add("@TaxNo", SqlDbType.Int).Value = taxNo;
               cmd.Parameters.Add("@TaxCode", SqlDbType.NVarChar).Value = taxCode;
               cmd.Parameters.Add("@CurrencyCode", SqlDbType.NVarChar).Value = currencyCode;
               cmd.Parameters.Add("@SecondRef", SqlDbType.NVarChar).Value = secondRef;
               cmd.Parameters.Add("@Narrative", SqlDbType.NVarChar).Value = narrative;
               cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
               cmd.Parameters.Add("@URNNumber", SqlDbType.BigInt).Value = urnNumber;
               cmd.Parameters.Add("@StatusReason", SqlDbType.Int).Value = statusReason;
               cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
               cn.Open();
               int ret = ExecuteNonQuery(cmd);
               return (ret > 0);
           }
           catch (SqlException sqlex)
           {
               //LogException(sqlex);
               throw new Exception("Failed to update Supplier Invoice", sqlex);
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
       public override bool UpdateHeader(System.Int32 supplierInvoiceId, System.String secondRef, System.String narrative,System.Boolean? canBeExported, System.Int32 updatedBy, System.Int32? statusReason)
       {
           SqlConnection cn = null;
           SqlCommand cmd = null;
           try
           {
               cn = new SqlConnection(this.ConnectionString);
               cmd = new SqlCommand("usp_updateHeader_SupplierInvoice", cn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@SupplierInvoiceId", SqlDbType.Int).Value = supplierInvoiceId;
               cmd.Parameters.Add("@SecondRef", SqlDbType.NVarChar).Value = secondRef;
               cmd.Parameters.Add("@Narrative", SqlDbType.NVarChar).Value = narrative;
               cmd.Parameters.Add("@CanBeExported", SqlDbType.Bit).Value = canBeExported;
               cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
               cmd.Parameters.Add("@StatusReason", SqlDbType.Int).Value = statusReason;
               cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
               cn.Open();
               int ret = ExecuteNonQuery(cmd);
               return (ret > 0);
           }
           catch (SqlException sqlex)
           {
               //LogException(sqlex);
               throw new Exception("Failed to update Supplier Invoice", sqlex);
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
