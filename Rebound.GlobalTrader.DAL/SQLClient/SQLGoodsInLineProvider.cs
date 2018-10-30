/*
Marker     changed by      date         Remarks
[001]      Vinay           08/07/2013    Ref:## -32 Nice Label Printing
[002]      Vinay           28/08/2013    NPR Print
[003]      Raushan         27/02/2014    GoodsIn - Po serial No.
 [004]     Abhinav goyal    09/11/2017     Ref:##- Global Security
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
    public class SqlGoodsInLineProvider : GoodsInLineProvider
    {
        /// <summary>
        /// Count GoodsInLine
        /// Calls [usp_count_GoodsInLine_for_PurchaseOrderLine]
        /// </summary>
        public override Int32 CountForPurchaseOrderLine(System.Int32? purchaseOrderLineId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_count_GoodsInLine_for_PurchaseOrderLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Value = purchaseOrderLineId;
                cn.Open();
                return (Int32)ExecuteScalar(cmd);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to count GoodsInLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// DataListNugget 
        /// Calls [usp_datalistnugget_GoodsInLine]
        /// </summary>
        public override List<GoodsInLineDetails> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Int32? receivedBy, System.String airWayBill, System.Boolean? includeInvoiced, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? goodsInNoLo, System.Int32? goodsInNoHi, System.DateTime? dateReceivedFrom, System.DateTime? dateReceivedTo, System.String supplierInvoice, System.String reference, System.Boolean? recentOnly, System.Boolean? uninspectedOnly, System.Int32? clientSearch, int? IsPoHub, Boolean IsGlobalLogin)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_datalistnugget_GoodsInLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
                cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
                cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
                cmd.Parameters.Add("@ReceivedBy", SqlDbType.Int).Value = receivedBy;
                cmd.Parameters.Add("@AirWayBill", SqlDbType.NVarChar).Value = airWayBill;
                cmd.Parameters.Add("@IncludeInvoiced", SqlDbType.Bit).Value = includeInvoiced;
                cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
                cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
                cmd.Parameters.Add("@GoodsInNoLo", SqlDbType.Int).Value = goodsInNoLo;
                cmd.Parameters.Add("@GoodsInNoHi", SqlDbType.Int).Value = goodsInNoHi;
                cmd.Parameters.Add("@DateReceivedFrom", SqlDbType.DateTime).Value = dateReceivedFrom;
                cmd.Parameters.Add("@DateReceivedTo", SqlDbType.DateTime).Value = dateReceivedTo;
                cmd.Parameters.Add("@SupplierInvoice", SqlDbType.NVarChar).Value = supplierInvoice;
                cmd.Parameters.Add("@Reference", SqlDbType.NVarChar).Value = reference;
                cmd.Parameters.Add("@RecentOnly", SqlDbType.Bit).Value = recentOnly;
                cmd.Parameters.Add("@UninspectedOnly", SqlDbType.Bit).Value = uninspectedOnly;
                cmd.Parameters.Add("@ClientSearch", SqlDbType.Int).Value = clientSearch;
                cmd.Parameters.Add("@IsPoHub", SqlDbType.Int).Value = IsPoHub ?? 0;
                cmd.Parameters.Add("@IsGlobalLogin", SqlDbType.Bit).Value = IsGlobalLogin;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<GoodsInLineDetails> lst = new List<GoodsInLineDetails>();
                while (reader.Read())
                {
                    GoodsInLineDetails obj = new GoodsInLineDetails();
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.GoodsInId = GetReaderValue_Int32(reader, "GoodsInId", 0);
                    obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue);
                    obj.ReceiverName = GetReaderValue_String(reader, "ReceiverName", "");
                    obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                    obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.AirWayBill = GetReaderValue_String(reader, "AirWayBill", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null) ?? 0;
                    obj.InternalPurchaseOrderId = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderId", null);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNumber", null);
                    obj.IPOSupplier = GetReaderValue_NullableInt32(reader, "IPOSupplier", null);
                    obj.IPOSupplierName = GetReaderValue_String(reader, "IPOSupplierName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get GoodsInLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// DataListNuggetAsReceivedPO 
        /// Calls [usp_datalistnugget_GoodsInLine_AsReceivedPO]
        /// </summary>
        public override List<GoodsInLineDetails> DataListNuggetAsReceivedPO(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.String partSearch, System.Boolean? recentOnly, System.String cmSearch, System.String contactSearch, System.Int32? buyerSearch, System.DateTime? receivedDateFrom, System.DateTime? receivedDateTo, System.String airWayBill, System.String supplierPartSearch, System.String reference,bool? isPoHub)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_datalistnugget_GoodsInLine_AsReceivedPO", cn);
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
                cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
                cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
                cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
                cmd.Parameters.Add("@RecentOnly", SqlDbType.Bit).Value = recentOnly;
                cmd.Parameters.Add("@CMSearch", SqlDbType.NVarChar).Value = cmSearch;
                cmd.Parameters.Add("@ContactSearch", SqlDbType.NVarChar).Value = contactSearch;
                cmd.Parameters.Add("@BuyerSearch", SqlDbType.Int).Value = buyerSearch;
                cmd.Parameters.Add("@ReceivedDateFrom", SqlDbType.DateTime).Value = receivedDateFrom;
                cmd.Parameters.Add("@ReceivedDateTo", SqlDbType.DateTime).Value = receivedDateTo;
                cmd.Parameters.Add("@AirWayBill", SqlDbType.NVarChar).Value = airWayBill;
                cmd.Parameters.Add("@SupplierPartSearch", SqlDbType.NVarChar).Value = supplierPartSearch;
                cmd.Parameters.Add("@Reference", SqlDbType.NVarChar).Value = reference;
                cmd.Parameters.Add("@IsPoHub", SqlDbType.Bit).Value = isPoHub;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<GoodsInLineDetails> lst = new List<GoodsInLineDetails>();
                while (reader.Read())
                {
                    GoodsInLineDetails obj = new GoodsInLineDetails();
                    //obj.IpoCount = GetReaderValue_Int32(reader, "IpoCount", 0);
                    obj.GoodsInNo = GetReaderValue_Int32(reader, "GoodsInNo", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue);
                    obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.AirWayBill = GetReaderValue_String(reader, "AirWayBill", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
                    obj.ContactNo = GetReaderValue_Int32(reader, "ContactNo", 0);
                    obj.ContactName = GetReaderValue_String(reader, "ContactName", "");
                    obj.SupplierInvoice = GetReaderValue_String(reader, "SupplierInvoice", "");
                    obj.InvoiceAmount = GetReaderValue_NullableDouble(reader, "InvoiceAmount", null);
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    lst.Add(obj);
                    obj = null;

                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get GoodsInLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Delete GoodsInLine
        /// Calls [usp_delete_GoodsInLine]
        /// </summary>
        public override bool Delete(System.Int32? goodsInLineId, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_GoodsInLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GoodsInLineId", SqlDbType.Int).Value = goodsInLineId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete GoodsInLine", sqlex);
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
        /// Calls [usp_insert_GoodsInLine]
        /// </summary>
        public override Int32 Insert(System.Int32? goodsInNo, System.Int32? purchaseOrderLineNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Double? shipInCost, System.String qualityControlNotes, System.String location, System.Int32? lotNo, System.Int32? productNo, System.Int32? currencyNo, System.Int32? customerRmaLineNo, System.String supplierPart, System.Byte? rohs, System.Int32? countryOfManufacture, System.Boolean? unavailable, System.String notes, System.String changedFields, System.Int32? countingMethodNo, System.Boolean? serialNosRecorded, System.String partMarkings, System.Int32? updatedBy, System.Double? clientPrice, System.Boolean? reqSerialNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_GoodsInLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GoodsInNo", SqlDbType.Int).Value = goodsInNo;
                cmd.Parameters.Add("@PurchaseOrderLineNo", SqlDbType.Int).Value = purchaseOrderLineNo;
                cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
                cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
                cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
                cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
                cmd.Parameters.Add("@ShipInCost", SqlDbType.Float).Value = shipInCost;
                cmd.Parameters.Add("@QualityControlNotes", SqlDbType.NVarChar).Value = qualityControlNotes;
                cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = location;
                cmd.Parameters.Add("@LotNo", SqlDbType.Int).Value = lotNo;
                cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
                cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
                cmd.Parameters.Add("@CustomerRMALineNo", SqlDbType.Int).Value = customerRmaLineNo;
                cmd.Parameters.Add("@SupplierPart", SqlDbType.NVarChar).Value = supplierPart;
                cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
                cmd.Parameters.Add("@CountryOfManufacture", SqlDbType.Int).Value = countryOfManufacture;
                cmd.Parameters.Add("@Unavailable", SqlDbType.Bit).Value = unavailable;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@ChangedFields", SqlDbType.NVarChar).Value = changedFields;
                cmd.Parameters.Add("@CountingMethodNo", SqlDbType.Int).Value = countingMethodNo;
                cmd.Parameters.Add("@SerialNosRecorded", SqlDbType.Bit).Value = serialNosRecorded;
                cmd.Parameters.Add("@PartMarkings", SqlDbType.NVarChar).Value = partMarkings;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@ClientPrice", SqlDbType.Float).Value = clientPrice;
                cmd.Parameters.Add("@ReqSerialNo", SqlDbType.Bit).Value = reqSerialNo;
                cmd.Parameters.Add("@GoodsInLineId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@GoodsInLineId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert GoodsInLine", sqlex);
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
        /// Calls [usp_select_GoodsInLine]
        /// </summary>
        public override GoodsInLineDetails Get(System.Int32? goodsInLineId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_GoodsInLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@GoodsInLineId", SqlDbType.Int).Value = goodsInLineId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetGoodsInLineFromReader(reader);
                    GoodsInLineDetails obj = new GoodsInLineDetails();
                    obj.GoodsInLineId = GetReaderValue_Int32(reader, "GoodsInLineId", 0);
                    obj.GoodsInNo = GetReaderValue_Int32(reader, "GoodsInNo", 0);
                    obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
                    obj.QualityControlNotes = GetReaderValue_String(reader, "QualityControlNotes", "");
                    obj.Location = GetReaderValue_String(reader, "Location", "");
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.LandedCost = GetReaderValue_Double(reader, "LandedCost", 0);
                    obj.CustomerRMALineNo = GetReaderValue_NullableInt32(reader, "CustomerRMALineNo", null);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
                    obj.CountryOfManufacture = GetReaderValue_NullableInt32(reader, "CountryOfManufacture", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.InspectedBy = GetReaderValue_NullableInt32(reader, "InspectedBy", null);
                    obj.DateInspected = GetReaderValue_NullableDateTime(reader, "DateInspected", null);
                    obj.CountingMethodNo = GetReaderValue_NullableInt32(reader, "CountingMethodNo", null);
                    obj.SerialNosRecorded = GetReaderValue_NullableBoolean(reader, "SerialNosRecorded", null);
                    obj.Unavailable = GetReaderValue_NullableBoolean(reader, "Unavailable", null);
                    obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
                    obj.PartMarkings = GetReaderValue_String(reader, "PartMarkings", "");
                    obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue);
                    obj.ReceiverName = GetReaderValue_String(reader, "ReceiverName", "");
                    obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.AirWayBill = GetReaderValue_String(reader, "AirWayBill", "");
                    obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
                    obj.SupplierInvoice = GetReaderValue_String(reader, "SupplierInvoice", "");
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CountingMethodDescription = GetReaderValue_String(reader, "CountingMethodDescription", "");
                    obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", "");
                    obj.InspectorName = GetReaderValue_String(reader, "InspectorName", "");
                    obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
                    obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ReceivedBy = GetReaderValue_Int32(reader, "ReceivedBy", 0);
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
                    obj.Reference = GetReaderValue_String(reader, "Reference", "");
                    obj.LotName = GetReaderValue_String(reader, "LotName", "");
                    obj.PurchaseOrderLineShipInCost = GetReaderValue_Double(reader, "PurchaseOrderLineShipInCost", 0);
                    obj.ChangedFields = GetReaderValue_String(reader, "ChangedFields", "");
                    obj.UpdateStock = GetReaderValue_NullableBoolean(reader, "UpdateStock", null);
                    obj.UpdateShipments = GetReaderValue_NullableBoolean(reader, "UpdateShipments", null);
                    obj.HasAllocationOutward = GetReaderValue_NullableBoolean(reader, "HasAllocationOutward", false);
                    obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
                    obj.CustomerPart = GetReaderValue_String(reader, "CustomerPartNo", string.Empty);
                    obj.NPRPrinted = GetReaderValue_NullableBoolean(reader, "NPRPrinted", false);
                    //[001] code start
                    obj.InspectorNameLabel = GetReaderValue_String(reader, "InspectorNameLabel", string.Empty);
                    //[001] code end
                    //[002] code start
                    obj.NPRIds = GetReaderValue_String(reader, "NPRIds", string.Empty);
                    obj.NPRNos = GetReaderValue_String(reader, "NPRNos", string.Empty);
                    //[002] code end
                    obj.HasStocksplit = GetReaderValue_Boolean(reader, "Stocksplit", false);
                    obj.HasSupplierInvoiceExists = GetReaderValue_Boolean(reader, "SupplierInvoiceExists", false);
                    obj.blnStockProvision = GetReaderValue_Boolean(reader, "blnStockProvision", false);
                    obj.LotCode = GetReaderValue_String(reader, "LotCode", "");

                    obj.InternalPurchaseOrderId = GetReaderValue_Int32(reader, "InternalPurchaseOrderNo", 0);
                    obj.ClientLandedCost = GetReaderValue_Double(reader, "ClientLandedCost", 0);
                    obj.ClientPrice = GetReaderValue_Double(reader, "ClientPrice", 0);

                    obj.ClientCurrencyNo = GetReaderValue_NullableInt32(reader, "ClientCurrencyNo", 0);
                    obj.ClientCurrencyCode = GetReaderValue_String(reader, "ClientCurrencyCode", "");
                    obj.IPOClientNo = GetReaderValue_NullableInt32(reader, "IPOClientNo", null);
                    obj.POBankFee = GetReaderValue_NullableDouble(reader, "POBankFee", null);
                    obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
                    obj.StockDate = GetReaderValue_DateTime(reader, "StockDate", DateTime.MinValue);
                    obj.ProductInactive = GetReaderValue_NullableBoolean(reader, "ProductInactive", false);
                    obj.DutyRate = GetReaderValue_NullableDouble(reader, "ProductDutyRate", null);
                    obj.ReqSerialNo = GetReaderValue_NullableBoolean(reader, "ReqSerialNo", false);
                    obj.SerialNoCount = GetReaderValue_NullableInt32(reader, "SerialNoCount", 0);
                    obj.MSLLevel = GetReaderValue_String(reader, "MSLLevel", "");
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
                throw new Exception("Failed to get GoodsInLine", sqlex);
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
        /// Calls [usp_selectAll_GoodsInLine_for_CustomerRMA]
        /// </summary>
        public override List<GoodsInLineDetails> GetListForCustomerRMA(System.Int32? customerRmaId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_GoodsInLine_for_CustomerRMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRMAId", SqlDbType.Int).Value = customerRmaId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<GoodsInLineDetails> lst = new List<GoodsInLineDetails>();
                while (reader.Read())
                {
                    GoodsInLineDetails obj = new GoodsInLineDetails();
                    obj.GoodsInLineId = GetReaderValue_Int32(reader, "GoodsInLineId", 0);
                    obj.GoodsInNo = GetReaderValue_Int32(reader, "GoodsInNo", 0);
                    obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
                    obj.QualityControlNotes = GetReaderValue_String(reader, "QualityControlNotes", "");
                    obj.Location = GetReaderValue_String(reader, "Location", "");
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.LandedCost = GetReaderValue_Double(reader, "LandedCost", 0);
                    obj.CustomerRMALineNo = GetReaderValue_NullableInt32(reader, "CustomerRMALineNo", null);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.CountryOfManufacture = GetReaderValue_NullableInt32(reader, "CountryOfManufacture", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.InspectedBy = GetReaderValue_NullableInt32(reader, "InspectedBy", null);
                    obj.DateInspected = GetReaderValue_NullableDateTime(reader, "DateInspected", null);
                    obj.CountingMethodNo = GetReaderValue_NullableInt32(reader, "CountingMethodNo", null);
                    obj.SerialNosRecorded = GetReaderValue_NullableBoolean(reader, "SerialNosRecorded", null);
                    obj.Unavailable = GetReaderValue_NullableBoolean(reader, "Unavailable", null);
                    obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
                    obj.PartMarkings = GetReaderValue_String(reader, "PartMarkings", "");
                    obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue);
                    obj.ReceiverName = GetReaderValue_String(reader, "ReceiverName", "");
                    obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.AirWayBill = GetReaderValue_String(reader, "AirWayBill", "");
                    obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
                    obj.SupplierInvoice = GetReaderValue_String(reader, "SupplierInvoice", "");
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CountingMethodDescription = GetReaderValue_String(reader, "CountingMethodDescription", "");
                    obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", "");
                    obj.InspectorName = GetReaderValue_String(reader, "InspectorName", "");
                    obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
                    obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ReceivedBy = GetReaderValue_Int32(reader, "ReceivedBy", 0);
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
                    obj.Reference = GetReaderValue_String(reader, "Reference", "");
                    obj.LotName = GetReaderValue_String(reader, "LotName", "");
                    obj.PurchaseOrderLineShipInCost = GetReaderValue_Double(reader, "PurchaseOrderLineShipInCost", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get GoodsInLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListForCustomerRMALine 
        /// Calls [usp_selectAll_GoodsInLine_for_CustomerRMALine]
        /// </summary>
        public override List<GoodsInLineDetails> GetListForCustomerRMALine(System.Int32? customerRmaLineId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_GoodsInLine_for_CustomerRMALine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRMALineId", SqlDbType.Int).Value = customerRmaLineId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<GoodsInLineDetails> lst = new List<GoodsInLineDetails>();
                while (reader.Read())
                {
                    GoodsInLineDetails obj = new GoodsInLineDetails();
                    obj.GoodsInLineId = GetReaderValue_Int32(reader, "GoodsInLineId", 0);
                    obj.GoodsInNo = GetReaderValue_Int32(reader, "GoodsInNo", 0);
                    obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
                    obj.QualityControlNotes = GetReaderValue_String(reader, "QualityControlNotes", "");
                    obj.Location = GetReaderValue_String(reader, "Location", "");
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.LandedCost = GetReaderValue_Double(reader, "LandedCost", 0);
                    obj.CustomerRMALineNo = GetReaderValue_NullableInt32(reader, "CustomerRMALineNo", null);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.CountryOfManufacture = GetReaderValue_NullableInt32(reader, "CountryOfManufacture", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.InspectedBy = GetReaderValue_NullableInt32(reader, "InspectedBy", null);
                    obj.DateInspected = GetReaderValue_NullableDateTime(reader, "DateInspected", null);
                    obj.CountingMethodNo = GetReaderValue_NullableInt32(reader, "CountingMethodNo", null);
                    obj.SerialNosRecorded = GetReaderValue_NullableBoolean(reader, "SerialNosRecorded", null);
                    obj.Unavailable = GetReaderValue_NullableBoolean(reader, "Unavailable", null);
                    obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
                    obj.PartMarkings = GetReaderValue_String(reader, "PartMarkings", "");
                    obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue);
                    obj.ReceiverName = GetReaderValue_String(reader, "ReceiverName", "");
                    obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.AirWayBill = GetReaderValue_String(reader, "AirWayBill", "");
                    obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
                    obj.SupplierInvoice = GetReaderValue_String(reader, "SupplierInvoice", "");
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CountingMethodDescription = GetReaderValue_String(reader, "CountingMethodDescription", "");
                    obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", "");
                    obj.InspectorName = GetReaderValue_String(reader, "InspectorName", "");
                    obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
                    obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ReceivedBy = GetReaderValue_Int32(reader, "ReceivedBy", 0);
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
                    obj.Reference = GetReaderValue_String(reader, "Reference", "");
                    obj.LotName = GetReaderValue_String(reader, "LotName", "");
                    obj.PurchaseOrderLineShipInCost = GetReaderValue_Double(reader, "PurchaseOrderLineShipInCost", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get GoodsInLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListForGoodsIn 
        /// Calls [usp_selectAll_GoodsInLine_for_GoodsIn]
        /// </summary>
        public override List<GoodsInLineDetails> GetListForGoodsIn(System.Int32? goodsInId, System.Int32? pageIndex, System.Int32? pageSize)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_GoodsInLine_for_GoodsIn", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@GoodsInId", SqlDbType.Int).Value = goodsInId;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<GoodsInLineDetails> lst = new List<GoodsInLineDetails>();
                while (reader.Read())
                {
                    GoodsInLineDetails obj = new GoodsInLineDetails();
                    obj.GoodsInLineId = GetReaderValue_Int32(reader, "GoodsInLineId", 0);
                    obj.GoodsInNo = GetReaderValue_Int32(reader, "GoodsInNo", 0);
                    obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
                    obj.QualityControlNotes = GetReaderValue_String(reader, "QualityControlNotes", "");
                    obj.Location = GetReaderValue_String(reader, "Location", "");
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.LandedCost = GetReaderValue_Double(reader, "LandedCost", 0);
                    obj.CustomerRMALineNo = GetReaderValue_NullableInt32(reader, "CustomerRMALineNo", null);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.CountryOfManufacture = GetReaderValue_NullableInt32(reader, "CountryOfManufacture", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.InspectedBy = GetReaderValue_NullableInt32(reader, "InspectedBy", null);
                    obj.DateInspected = GetReaderValue_NullableDateTime(reader, "DateInspected", null);
                    obj.CountingMethodNo = GetReaderValue_NullableInt32(reader, "CountingMethodNo", null);
                    obj.SerialNosRecorded = GetReaderValue_NullableBoolean(reader, "SerialNosRecorded", null);
                    obj.Unavailable = GetReaderValue_NullableBoolean(reader, "Unavailable", null);
                    obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
                    obj.PartMarkings = GetReaderValue_String(reader, "PartMarkings", "");
                    obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue);
                    obj.ReceiverName = GetReaderValue_String(reader, "ReceiverName", "");
                    obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.AirWayBill = GetReaderValue_String(reader, "AirWayBill", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
                    obj.SupplierInvoice = GetReaderValue_String(reader, "SupplierInvoice", "");
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CountingMethodDescription = GetReaderValue_String(reader, "CountingMethodDescription", "");
                    obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", "");
                    obj.InspectorName = GetReaderValue_String(reader, "InspectorName", "");
                    obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
                    obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ReceivedBy = GetReaderValue_Int32(reader, "ReceivedBy", 0);
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
                    obj.Reference = GetReaderValue_String(reader, "Reference", "");
                    obj.LotName = GetReaderValue_String(reader, "LotName", "");
                    obj.PurchaseOrderLineShipInCost = GetReaderValue_Double(reader, "PurchaseOrderLineShipInCost", 0);
                    obj.PhysicalInspectedBy = GetReaderValue_NullableInt32(reader, "PhysicalInspectedBy", 0);
                    obj.DatePhysicalInspected = GetReaderValue_NullableDateTime(reader, "DatePhysicalInspected", null);
                    //[003] Code Start
                    obj.POSerialNo = GetReaderValue_Int16(reader, "POSerialNo", 0);
                    //[003] Code End
                    obj.InternalPurchaseOrderId = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNo", 0);
                    obj.ClientLandedCost = GetReaderValue_Double(reader, "ClientLandedCost", 0);
                    obj.ClientPrice = GetReaderValue_Double(reader, "ClientPrice", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get GoodsInLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListForPurchaseOrder 
        /// Calls [usp_selectAll_GoodsInLine_for_PurchaseOrder]
        /// </summary>
        public override List<GoodsInLineDetails> GetListForPurchaseOrder(System.Int32? purchaseOrderId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_GoodsInLine_for_PurchaseOrder", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@PurchaseOrderId", SqlDbType.Int).Value = purchaseOrderId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<GoodsInLineDetails> lst = new List<GoodsInLineDetails>();
                while (reader.Read())
                {
                    GoodsInLineDetails obj = new GoodsInLineDetails();
                    obj.GoodsInLineId = GetReaderValue_Int32(reader, "GoodsInLineId", 0);
                    obj.GoodsInNo = GetReaderValue_Int32(reader, "GoodsInNo", 0);
                    obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
                    obj.QualityControlNotes = GetReaderValue_String(reader, "QualityControlNotes", "");
                    obj.Location = GetReaderValue_String(reader, "Location", "");
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.LandedCost = GetReaderValue_Double(reader, "LandedCost", 0);
                    obj.CustomerRMALineNo = GetReaderValue_NullableInt32(reader, "CustomerRMALineNo", null);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.CountryOfManufacture = GetReaderValue_NullableInt32(reader, "CountryOfManufacture", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.InspectedBy = GetReaderValue_NullableInt32(reader, "InspectedBy", null);
                    obj.DateInspected = GetReaderValue_NullableDateTime(reader, "DateInspected", null);
                    obj.CountingMethodNo = GetReaderValue_NullableInt32(reader, "CountingMethodNo", null);
                    obj.SerialNosRecorded = GetReaderValue_NullableBoolean(reader, "SerialNosRecorded", null);
                    obj.Unavailable = GetReaderValue_NullableBoolean(reader, "Unavailable", null);
                    obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
                    obj.PartMarkings = GetReaderValue_String(reader, "PartMarkings", "");
                    obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue);
                    obj.ReceiverName = GetReaderValue_String(reader, "ReceiverName", "");
                    obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.AirWayBill = GetReaderValue_String(reader, "AirWayBill", "");
                    obj.QuantityOrdered = GetReaderValue_Int32(reader, "QuantityOrdered", 0);
                    obj.SupplierInvoice = GetReaderValue_String(reader, "SupplierInvoice", "");
                    obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.CountingMethodDescription = GetReaderValue_String(reader, "CountingMethodDescription", "");
                    obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ProductDutyCode = GetReaderValue_String(reader, "ProductDutyCode", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", "");
                    obj.InspectorName = GetReaderValue_String(reader, "InspectorName", "");
                    obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
                    obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    obj.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", "");
                    obj.ReceivedBy = GetReaderValue_Int32(reader, "ReceivedBy", 0);
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    obj.TeamNo = GetReaderValue_NullableInt32(reader, "TeamNo", null);
                    obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
                    obj.Reference = GetReaderValue_String(reader, "Reference", "");
                    obj.LotName = GetReaderValue_String(reader, "LotName", "");
                    obj.PurchaseOrderLineShipInCost = GetReaderValue_Double(reader, "PurchaseOrderLineShipInCost", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get GoodsInLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListForPurchaseOrderLine 
        /// Calls [usp_selectAll_GoodsInLine_for_PurchaseOrderLine]
        /// </summary>
        public override List<GoodsInLineDetails> GetListForPurchaseOrderLine(System.Int32? purchaseOrderLineId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_GoodsInLine_for_PurchaseOrderLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Value = purchaseOrderLineId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<GoodsInLineDetails> lst = new List<GoodsInLineDetails>();
                while (reader.Read())
                {
                    GoodsInLineDetails obj = new GoodsInLineDetails();
                    obj.GoodsInLineId = GetReaderValue_Int32(reader, "GoodsInLineId", 0);
                    obj.GoodsInNo = GetReaderValue_Int32(reader, "GoodsInNo", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.Price = GetReaderValue_Double(reader, "Price", 0);
                    obj.Location = GetReaderValue_String(reader, "Location", "");
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.LandedCost = GetReaderValue_Double(reader, "LandedCost", 0);
                    obj.ClientLandedCost = GetReaderValue_Double(reader, "ClientLandedCost", 0);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.DateReceived = GetReaderValue_DateTime(reader, "DateReceived", DateTime.MinValue);
                    obj.ReceiverName = GetReaderValue_String(reader, "ReceiverName", "");
                    obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
                    obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get GoodsInLines", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update GoodsInLine
        /// Calls [usp_update_GoodsInLine]
        /// </summary>
        public override bool Update(System.Int32? goodsInLineId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Double? shipInCost, System.String qualityControlNotes, System.String location, System.Int32? lotNo, System.Int32? productNo, System.String supplierPart, System.Byte? rohs, System.Int32? countryOfManufacture, System.Int32? currencyNo, System.Boolean? unavailable, System.String changedFields, System.String notes, System.Int32? countingMethodNo, System.Boolean? serialNosRecorded, System.String partMarkings, System.Boolean? updateStock, System.Boolean? updateShipments, System.Int32? updatedBy, System.Double? clientPrice, System.Boolean? reqSerialNo, System.String mslLevel, System.Boolean? printHazardous)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_GoodsInLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GoodsInLineId", SqlDbType.Int).Value = goodsInLineId;
                cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
                cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
                cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
                cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
                cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
                cmd.Parameters.Add("@ShipInCost", SqlDbType.Float).Value = shipInCost;
                cmd.Parameters.Add("@QualityControlNotes", SqlDbType.NVarChar).Value = qualityControlNotes;
                cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = location;
                cmd.Parameters.Add("@LotNo", SqlDbType.Int).Value = lotNo;
                cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
                cmd.Parameters.Add("@SupplierPart", SqlDbType.NVarChar).Value = supplierPart;
                cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
                cmd.Parameters.Add("@CountryOfManufacture", SqlDbType.Int).Value = countryOfManufacture;
                cmd.Parameters.Add("@CurrencyNo", SqlDbType.Int).Value = currencyNo;
                cmd.Parameters.Add("@Unavailable", SqlDbType.Bit).Value = unavailable;
                cmd.Parameters.Add("@ChangedFields", SqlDbType.NVarChar).Value = changedFields;
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
                cmd.Parameters.Add("@CountingMethodNo", SqlDbType.Int).Value = countingMethodNo;
                cmd.Parameters.Add("@SerialNosRecorded", SqlDbType.Bit).Value = serialNosRecorded;
                cmd.Parameters.Add("@PartMarkings", SqlDbType.NVarChar).Value = partMarkings;
                cmd.Parameters.Add("@UpdateStock", SqlDbType.Bit).Value = updateStock;
                cmd.Parameters.Add("@UpdateShipments", SqlDbType.Bit).Value = updateShipments;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@ClientPrice", SqlDbType.Float).Value = clientPrice;
                cmd.Parameters.Add("@ReqSerialNo", SqlDbType.Bit).Value = reqSerialNo;
                cmd.Parameters.Add("@PrintHazardous", SqlDbType.Bit).Value = printHazardous;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@MSLLevel", SqlDbType.NVarChar).Value = mslLevel;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update GoodsInLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update GoodsInLine
        /// Calls [usp_update_GoodsInLine_Inspect]
        /// </summary>
        public override bool UpdateInspect(System.Int32? goodsInLineId, System.Int32? inspectedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_GoodsInLine_Inspect", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GoodsInLineId", SqlDbType.Int).Value = goodsInLineId;
                cmd.Parameters.Add("@InspectedBy", SqlDbType.Int).Value = inspectedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                ExecuteNonQuery(cmd);
                int ret = Convert.ToInt32(cmd.Parameters["@RowsAffected"].Value);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update GoodsInLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[001] code start
        /// <summary>
        /// GetDetailsPrintNiceLabelGoodsInLine 
        /// Calls [usp_select_GoodsInLine]
        /// </summary>
        public override GoodsInLineDetails GetDetailsPrintNiceLabelGoodsInLine(System.Int32? goodsInLineId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_GetDetails_to_PrintNiceLabel_for_GoodsInLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@GoodsInLineId", SqlDbType.Int).Value = goodsInLineId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    GoodsInLineDetails obj = new GoodsInLineDetails();
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
                    obj.InspectedByUser = GetReaderValue_String(reader, "InspectedByUser", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.CompanyName = GetReaderValue_String(reader, "Customer", "");
                    obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
                    obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
                    obj.DatePicked = GetReaderValue_DateTime(reader, "DatePicked", DateTime.MinValue);
                    obj.GoodsInNumber = GetReaderValue_Int32(reader, "GoodsInNumber", 0);
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
                throw new Exception("Failed to get GoodsInLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[001] code end
        /// <summary>
        /// usp_update_GoodsInLine_NPRStatus
        /// </summary>
        /// <param name="goodsInLineId"></param>
        /// <param name="nprPrintStatus"></param>
        /// <returns></returns>
        public override bool UpdateNPRStatus(System.Int32? goodsInLineId, System.Boolean? nprPrintStatus)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_GoodsInLine_NPRStatus", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GoodsInLineId", SqlDbType.Int).Value = goodsInLineId;
                cmd.Parameters.Add("@NPRPrintStatus", SqlDbType.Int).Value = nprPrintStatus;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update NPR Print Status", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Update GoodsInLine
        /// Calls [usp_update_GoodsInLine_PhysicalInspect]
        /// </summary>
        public override bool UpdatePhysicalInspect(System.Int32? goodsInLineId, System.Int32? inspectedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_GoodsInLine_PhysicalInspect", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GoodsInLineId", SqlDbType.Int).Value = goodsInLineId;
                cmd.Parameters.Add("@InspectedBy", SqlDbType.Int).Value = inspectedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                ExecuteNonQuery(cmd);
                int ret = Convert.ToInt32(cmd.Parameters["@RowsAffected"].Value);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update GoodsInLine", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public override Int32 InsertSerialNo(System.String subGroup, System.String serialNo, System.Int32? goodsInId, System.Int32? goodsInLineId, System.Int32? updatedBy, out System.String validateMessage)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_SerialNo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@serialNo", SqlDbType.VarChar).Value = serialNo;
                cmd.Parameters.Add("@subGroup", SqlDbType.VarChar).Value = subGroup;
                cmd.Parameters.Add("@GoodsInNo", SqlDbType.Int).Value = goodsInId;
                cmd.Parameters.Add("@GoodsInLineId", SqlDbType.Int).Value = goodsInLineId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy; 
                cmd.Parameters.Add("@SerialNoId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CountStatus", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;            
                cn.Open();
               // int ret = ExecuteNonQuery(cmd);

                validateMessage = null;
                ExecuteScalar(cmd);
                int ret = (int)(cmd.Parameters["@SerialNoId"].Value == null ? 0 : cmd.Parameters["@SerialNoId"].Value);
                validateMessage = (cmd.Parameters["@CountStatus"].Value.Equals(DBNull.Value) == true ? null : (String)cmd.Parameters["@CountStatus"].Value);

                if (ret == -1 && validateMessage == null)
                {
                    validateMessage = "Duplicate Serial Numbers not allowed";
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


        public override Int32 UpdateSerialNo(System.Int32? serialId, System.String subGroup, System.String serialNo, System.Int32? goodsInId, System.String status, System.Int32? goodsInLineId, System.Int32? updatedBy, out System.String validateMessage)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_SerialNo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@serialId", SqlDbType.Int).Value = serialId;
                cmd.Parameters.Add("@serialNo", SqlDbType.VarChar).Value = serialNo;
                cmd.Parameters.Add("@subGroup", SqlDbType.VarChar).Value = subGroup;
                cmd.Parameters.Add("@GoodsInNo", SqlDbType.Int).Value = goodsInId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy; 
                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = status;
                cmd.Parameters.Add("@GoodsInLineId", SqlDbType.Int).Value = goodsInLineId;
                cmd.Parameters.Add("@SerialNoId", SqlDbType.Int).Direction = ParameterDirection.Output;

                cn.Open();
                //int ret = ExecuteNonQuery(cmd);
                //return (Int32)cmd.Parameters["@SerialNoId"].Value;
                int ret = ExecuteNonQuery(cmd);
                validateMessage = null;
                if (ret == -1)
                {
                    validateMessage = "Duplicate Serial Numbers not allowed";                    
                }
                return ret;// (Int32)cmd.Parameters["@SerialNoId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update SerialNo", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        public override List<GoodsInLineDetails> GetDataGrid(System.Int32? goodsInId, System.Int32? goodsInLineId, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {               
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SerialNo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@GoodsInId", SqlDbType.Int).Value = goodsInId;
                cmd.Parameters.Add("@GoodsInLineId", SqlDbType.Int).Value = goodsInLineId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy; 
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<GoodsInLineDetails> lst = new List<GoodsInLineDetails>();
                while (reader.Read())
                {
                    GoodsInLineDetails obj = new GoodsInLineDetails();
                    obj.SerialNoId = GetReaderValue_Int32(reader, "SerialNoId", 0);
                    obj.GoodsInNo = GetReaderValue_Int32(reader, "GoodsInNo", 0);
                    obj.SerialNo = GetReaderValue_String(reader, "SerialNo", "");
                    obj.SubGroup = GetReaderValue_String(reader, "SubGroup", "");         
                    obj.Status = GetReaderValue_String(reader, "Status", "");
                    obj.InvoiceLineNo = GetReaderValue_Int32(reader, "InvoiceLineNo", 0);
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

        public override Int32 InsertAllSerialNo(System.Int32? goodsInId,System.Int32? goodsInLineId, System.Int32? updatedBy ,out System.String validateMessage)
         {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_AllSerialNo", cn);
                cmd.CommandType = CommandType.StoredProcedure;      
                cmd.Parameters.Add("@GoodsInNo", SqlDbType.Int).Value = goodsInId;
                cmd.Parameters.Add("@GoodsInLineId", SqlDbType.Int).Value = goodsInLineId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@SerialNoId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@CountStatus", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;  
                cn.Open();
                //int ret = ExecuteNonQuery(cmd);               
                //return (Int32)cmd.Parameters["@SerialNoId"].Value;
               // return ret;
                validateMessage = null;
                ExecuteScalar(cmd);
                //int ret = (int)(cmd.Parameters["@SerialNoId"].Value == null ? 0 : cmd.Parameters["@SerialNoId"].Value);
                validateMessage = (cmd.Parameters["@CountStatus"].Value.Equals(DBNull.Value) == true ? null : (String)cmd.Parameters["@CountStatus"].Value);

                return  (Int32)cmd.Parameters["@SerialNoId"].Value;
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

        public override List<GoodsInLineDetails> GetSerial(System.Int32? goodsInLineId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_AllSerialNo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@GoodsInId", SqlDbType.Int).Value = goodsInLineId;
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

        public override List<GoodsInLineDetails> AutoSearch(System.String nameSearch, System.String groupName)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_autosearch_SerialNo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
                cmd.Parameters.Add("@Group", SqlDbType.VarChar).Value = groupName;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<GoodsInLineDetails> lst = new List<GoodsInLineDetails>();
                while (reader.Read())
                {
                    GoodsInLineDetails obj = new GoodsInLineDetails();
                    obj.SerialNoId = GetReaderValue_Int32(reader, "SerialNumberId", 0);
                    obj.SerialNo = GetReaderValue_String(reader, "SerialNo", "");                   
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Serial No", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public override List<GoodsInLineDetails> DropDown(System.Int32? goodsInLineNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_dropdown_Group", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@GoodsInLineNo", SqlDbType.Int).Value = goodsInLineNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<GoodsInLineDetails> lst = new List<GoodsInLineDetails>();
                while (reader.Read())
                {
                    GoodsInLineDetails obj = new GoodsInLineDetails();      
                    obj.SubGroup = GetReaderValue_String(reader, "Group", "");
                    obj.SerialNo = GetReaderValue_String(reader, "RemainSerialNo", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get RohsStatuss", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        public override List<GoodsInLineDetails> AutoSearchGroup(System.String nameSearch)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_autosearch_Group", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;               
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<GoodsInLineDetails> lst = new List<GoodsInLineDetails>();
                while (reader.Read())
                {
                    GoodsInLineDetails obj = new GoodsInLineDetails();
                    obj.SerialNoId = GetReaderValue_Int32(reader, "SerialNumberId", 0);
                    obj.SubGroup = GetReaderValue_String(reader, "Group","");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Serial No", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        public override Int32 DeleteSerialNo(System.Int32? serialNoId, System.String status, System.Int32? goodsInId, System.Int32? goodsInLineId, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_SerialNo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SerialNoId", SqlDbType.Int).Value = serialNoId;
                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = status;
                cmd.Parameters.Add("@GoodsInNo", SqlDbType.VarChar).Value = goodsInId;
                cmd.Parameters.Add("@GoodsInLineId", SqlDbType.VarChar).Value = goodsInLineId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
          
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                //return (Int32)cmd.Parameters["@SerialNoId"].Value;
                return ret;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete Serial No", sqlex);
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
        /// Calls [usp_itemsearch_GoodsInSerialNo]
        /// </summary>
        public override List<GoodsInLineDetails> GISerialSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String giSerialGroup, System.String serialNoLo, System.Int32? serialNoHi, System.DateTime? dateReceivedFrom, System.DateTime? dateReceivedTo, System.Int32? goodsInLineNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_itemsearch_GoodsInSerialNo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
                cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                cmd.Parameters.Add("@GroupNo", SqlDbType.NVarChar).Value = giSerialGroup;
                cmd.Parameters.Add("@SerialNoLo", SqlDbType.VarChar).Value = serialNoLo;
                //cmd.Parameters.Add("@SerialNoHi", SqlDbType.Int).Value = serialNoHi;
                cmd.Parameters.Add("@DateReceivedFrom", SqlDbType.DateTime).Value = dateReceivedFrom;
                cmd.Parameters.Add("@DateReceivedTo", SqlDbType.DateTime).Value = dateReceivedTo;
                cmd.Parameters.Add("@GoodsInLineNo", SqlDbType.Int).Value = goodsInLineNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<GoodsInLineDetails> lst = new List<GoodsInLineDetails>();
                while (reader.Read())
                {
                    GoodsInLineDetails obj = new GoodsInLineDetails();
                    obj.SerialNoId = GetReaderValue_Int32(reader, "SerialNumberId", 0);
                    obj.SerialNo = GetReaderValue_String(reader, "SerialNo", "");
                    obj.SubGroup = GetReaderValue_String(reader, "Group", "");
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get GoodsIn serial number", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// usp_get_AttachedSerialNo
        /// </summary>
        public override List<GoodsInLineDetails> GetAttachedSerial(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? goodsInLineNo, System.Int32? salesOrderLineNo, System.DateTime? dateReceivedFrom, System.DateTime? dateReceivedTo, System.Int32? allocationNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_get_AttachedSerialNo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
                cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                cmd.Parameters.Add("@GoodsInLineNo", SqlDbType.Int).Value = goodsInLineNo;
                cmd.Parameters.Add("@SalesOrderLineNo", SqlDbType.Int).Value = salesOrderLineNo;
                cmd.Parameters.Add("@DateReceivedFrom", SqlDbType.DateTime).Value = dateReceivedFrom;
                cmd.Parameters.Add("@DateReceivedTo", SqlDbType.DateTime).Value = dateReceivedTo;
                cmd.Parameters.Add("@AllocationNo", SqlDbType.Int).Value = allocationNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<GoodsInLineDetails> lst = new List<GoodsInLineDetails>();
                while (reader.Read())
                {
                    GoodsInLineDetails obj = new GoodsInLineDetails();
                    obj.SerialNoId = GetReaderValue_Int32(reader, "SerialNumberId", 0);
                    obj.SerialNo = GetReaderValue_String(reader, "SerialNo", "");
                    obj.SubGroup = GetReaderValue_String(reader, "Group", "");
                    obj.InvoiceLineNo = GetReaderValue_Int32(reader, "InvoiceLineNo", 0);
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get GoodsIn serial number", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// usp_delete_AttachedSerial
        /// </summary>
        public override Int32 DeleteAttachedSerial(System.Int32? serialId, System.Int32? goodsInLineId, System.Int32? soLineId, System.Int32? updatedBy,System.Int32? allocationNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_AttachedSerial", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SerialNoId", SqlDbType.Int).Value = serialId;                
                cmd.Parameters.Add("@GoodsInLineId", SqlDbType.VarChar).Value = goodsInLineId;
                cmd.Parameters.Add("@SOLineNo", SqlDbType.VarChar).Value = soLineId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@AllocationNo", SqlDbType.Int).Value = allocationNo;

                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                //return (Int32)cmd.Parameters["@SerialNoId"].Value;
                return ret;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete Serial No", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// usp_update_SerialBySO
        /// </summary>
        public override Int32 UpdateSerialBySO(System.String subGroup, System.Int32? goodsInLineId, System.Int32? soLineId, System.Int32? qtyToShpped,System.Int32? allocatedId , out System.String validateMessage)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_SerialBySO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SubGroup", SqlDbType.VarChar).Value = subGroup;
                cmd.Parameters.Add("@GoodsInLineId", SqlDbType.Int).Value = goodsInLineId;
                cmd.Parameters.Add("@SOLineNo", SqlDbType.Int).Value = soLineId;
                cmd.Parameters.Add("@QtyToShpped", SqlDbType.Int).Value = qtyToShpped;
                cmd.Parameters.Add("@AllocatedId", SqlDbType.Int).Value = allocatedId;         
                cn.Open();
               // int ret = ExecuteNonQuery(cmd);
                //return (Int32)cmd.Parameters["@SerialNoId"].Value;
               // return ret;
                
                int ret = ExecuteNonQuery(cmd);
                validateMessage = null;
                if (ret == -1)
                {
                    validateMessage = "Cannot insert Serial Numbers beyond Quantity limit";
                }
                if (ret == 0)
                {
                    validateMessage = "All the serial number are recorded for this group";
                }
                return ret;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Serial No", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// usp_delete_SerialBySO
        /// </summary>
        public override Int32 DeleteSerialBySO(System.Int32? goodsInLineId, System.Int32? soLineId, System.Int32? AllocatedId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_SerialBySO", cn);
                cmd.CommandType = CommandType.StoredProcedure;           
                cmd.Parameters.Add("@GoodsInLineId", SqlDbType.Int).Value = goodsInLineId;
                cmd.Parameters.Add("@SOLineNo", SqlDbType.Int).Value = soLineId;
                cmd.Parameters.Add("@AllocationNo", SqlDbType.Int).Value = AllocatedId;    

                cn.Open();                
                int ret = ExecuteNonQuery(cmd);                
                return ret;
            }
            catch (SqlException sqlex)
            {               
                throw new Exception("Failed to delete Serial No", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }



        public override List<GoodsInLineDetails> GetReasonDetailByPart(System.String part)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_get_ReasonDetailByPart", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;           
                
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<GoodsInLineDetails> lst = new List<GoodsInLineDetails>();
                while (reader.Read())
                {
                    GoodsInLineDetails obj = new GoodsInLineDetails();
                    obj.ReasonCode = GetReaderValue_String(reader, "ReasonCode", "");
                    obj.ReasonDate = Convert.ToString(GetReaderValue_DateTime(reader, "ReasonDate", DateTime.MinValue));                  
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Reason Code Detail", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// USP_SELECT_ShipInCostHistory
        /// </summary>
        /// <param name="goodsInLineNo"></param>
        /// <returns></returns>
        public override List<GoodsInLineDetails> GetShipCostHistory(System.Int32? goodsInLineNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("USP_SELECT_ShipInCostHistory", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@GoodsInLineNo", SqlDbType.Int).Value = goodsInLineNo;

                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<GoodsInLineDetails> lst = new List<GoodsInLineDetails>();
                while (reader.Read())
                {
                    GoodsInLineDetails obj = new GoodsInLineDetails();
                    obj.GIShipCostHistoryId = GetReaderValue_Int32(reader, "GIShipCostHistoryId", 0);
                    obj.ShipInCost = GetReaderValue_NullableDouble(reader, "ShipInCost", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.ReceiverName = GetReaderValue_String(reader, "EmployeeName", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get ship cost history", sqlex);
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
