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
	public class SqlInvoiceLineAllocationProvider : InvoiceLineAllocationProvider {
		/// <summary>
		/// Count InvoiceLineAllocation
		/// Calls [usp_count_InvoiceLineAllocation_for_PurchaseOrderLine]
		/// </summary>
		public override Int32 CountForPurchaseOrderLine(System.Int32? purchaseOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_count_InvoiceLineAllocation_for_PurchaseOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Value = purchaseOrderLineId;
				cn.Open();
				return (Int32)ExecuteScalar(cmd);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to count InvoiceLineAllocation", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Delete InvoiceLineAllocation
		/// Calls [usp_delete_InvoiceLineAllocation]
		/// </summary>
		public override bool Delete(System.Int32? invoiceLineAllocationId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_InvoiceLineAllocation", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@InvoiceLineAllocationId", SqlDbType.Int).Value = invoiceLineAllocationId;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete InvoiceLineAllocation", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_InvoiceLineAllocation]
		/// </summary>
		public override Int32 Insert(System.Int32? invoiceLineNo, System.Int32? quantity, System.Int32? stockNo, System.Int32? salesOrderLineNo, System.Int32? lotNo, System.Double? landedCost, System.Int32? supplierRmaLineNo, System.Int32? warehouseNo, System.String location, System.Int32? goodsInLineNo, System.Int32? purchaseOrderLineNo, System.Int32? customerRmaGoodsInLineNo, System.Int32? countryOfManufactureNo, System.String notes, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_InvoiceLineAllocation", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@InvoiceLineNo", SqlDbType.Int).Value = invoiceLineNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
				cmd.Parameters.Add("@SalesOrderLineNo", SqlDbType.Int).Value = salesOrderLineNo;
				cmd.Parameters.Add("@LotNo", SqlDbType.Int).Value = lotNo;
				cmd.Parameters.Add("@LandedCost", SqlDbType.Float).Value = landedCost;
				cmd.Parameters.Add("@SupplierRMALineNo", SqlDbType.Int).Value = supplierRmaLineNo;
				cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
				cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = location;
				cmd.Parameters.Add("@GoodsInLineNo", SqlDbType.Int).Value = goodsInLineNo;
				cmd.Parameters.Add("@PurchaseOrderLineNo", SqlDbType.Int).Value = purchaseOrderLineNo;
				cmd.Parameters.Add("@CustomerRMAGoodsInLineNo", SqlDbType.Int).Value = customerRmaGoodsInLineNo;
				cmd.Parameters.Add("@CountryOfManufactureNo", SqlDbType.Int).Value = countryOfManufactureNo;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@InvoiceLineAllocationId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@InvoiceLineAllocationId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert InvoiceLineAllocation", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Get 
		/// Calls [usp_select_InvoiceLineAllocation]
        /// </summary>
		public override InvoiceLineAllocationDetails Get(System.Int32? invoiceLineAllocationId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_InvoiceLineAllocation", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@InvoiceLineAllocationId", SqlDbType.Int).Value = invoiceLineAllocationId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetInvoiceLineAllocationFromReader(reader);
					InvoiceLineAllocationDetails obj = new InvoiceLineAllocationDetails();
					obj.InvoiceLineAllocationId = GetReaderValue_Int32(reader, "InvoiceLineAllocationId", 0);
					obj.InvoiceLineNo = GetReaderValue_Int32(reader, "InvoiceLineNo", 0);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
					obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null);
					obj.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null);
					obj.Location = GetReaderValue_String(reader, "Location", "");
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
					obj.CountryOfManufactureNo = GetReaderValue_NullableInt32(reader, "CountryOfManufactureNo", null);
					obj.CustomerRMAGoodsInLineNo = GetReaderValue_NullableInt32(reader, "CustomerRMAGoodsInLineNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", "");
					obj.LotName = GetReaderValue_String(reader, "LotName", "");
					obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
					obj.InvoiceNo = GetReaderValue_Int32(reader, "InvoiceNo", 0);
					obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
					obj.InvoiceNumber = GetReaderValue_NullableInt32(reader, "InvoiceNumber", null);
					obj.InvoiceDate = GetReaderValue_NullableDateTime(reader, "InvoiceDate", null);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
					obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
					obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null);
					obj.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", null);
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.SalesOrderLineId = GetReaderValue_NullableInt32(reader, "SalesOrderLineId", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
					obj.PurchasePrice = GetReaderValue_NullableDouble(reader, "PurchasePrice", null);
					obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
					obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
					obj.PurchaseCurrencyNo = GetReaderValue_NullableInt32(reader, "PurchaseCurrencyNo", null);
					obj.PurchaseCurrencyCode = GetReaderValue_String(reader, "PurchaseCurrencyCode", "");
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.Buyer = GetReaderValue_NullableInt32(reader, "Buyer", null);
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.QuantityAllocatedToCRMA = GetReaderValue_NullableInt32(reader, "QuantityAllocatedToCRMA", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get InvoiceLineAllocation", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetCandidateForCustomerRMA 
		/// Calls [usp_select_InvoiceLineAllocation_candidate_for_CustomerRMA]
        /// </summary>
		public override InvoiceLineAllocationDetails GetCandidateForCustomerRMA(System.Int32? invoiceLineAllocationId, System.Int32? customerRmaId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_InvoiceLineAllocation_candidate_for_CustomerRMA", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@InvoiceLineAllocationId", SqlDbType.Int).Value = invoiceLineAllocationId;
				cmd.Parameters.Add("@CustomerRMAId", SqlDbType.Int).Value = customerRmaId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetInvoiceLineAllocationFromReader(reader);
					InvoiceLineAllocationDetails obj = new InvoiceLineAllocationDetails();
					obj.InvoiceLineAllocationId = GetReaderValue_Int32(reader, "InvoiceLineAllocationId", 0);
					obj.InvoiceLineNo = GetReaderValue_Int32(reader, "InvoiceLineNo", 0);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
					obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null);
					obj.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null);
					obj.Location = GetReaderValue_String(reader, "Location", "");
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
					obj.CountryOfManufactureNo = GetReaderValue_NullableInt32(reader, "CountryOfManufactureNo", null);
					obj.CustomerRMAGoodsInLineNo = GetReaderValue_NullableInt32(reader, "CustomerRMAGoodsInLineNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", "");
					obj.LotName = GetReaderValue_String(reader, "LotName", "");
					obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
					obj.InvoiceNo = GetReaderValue_Int32(reader, "InvoiceNo", 0);
					obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
					obj.InvoiceNumber = GetReaderValue_NullableInt32(reader, "InvoiceNumber", null);
					obj.InvoiceDate = GetReaderValue_NullableDateTime(reader, "InvoiceDate", null);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
					obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
					obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null);
					obj.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", null);
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.SalesOrderLineId = GetReaderValue_NullableInt32(reader, "SalesOrderLineId", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
					obj.PurchasePrice = GetReaderValue_NullableDouble(reader, "PurchasePrice", null);
					obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
					obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
					obj.PurchaseCurrencyNo = GetReaderValue_NullableInt32(reader, "PurchaseCurrencyNo", null);
					obj.PurchaseCurrencyCode = GetReaderValue_String(reader, "PurchaseCurrencyCode", "");
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.Buyer = GetReaderValue_NullableInt32(reader, "Buyer", null);
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.QuantityAllocatedToCRMA = GetReaderValue_NullableInt32(reader, "QuantityAllocatedToCRMA", null);
					obj.QuantityAllocated = GetReaderValue_NullableInt32(reader, "QuantityAllocated", null);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get InvoiceLineAllocation", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListCandidatesForCustomerRMA 
		/// Calls [usp_selectAll_InvoiceLineAllocation_candidates_for_CustomerRMA]
        /// </summary>
		public override List<InvoiceLineAllocationDetails> GetListCandidatesForCustomerRMA(System.Int32? customerRmaId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_InvoiceLineAllocation_candidates_for_CustomerRMA", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CustomerRMAId", SqlDbType.Int).Value = customerRmaId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<InvoiceLineAllocationDetails> lst = new List<InvoiceLineAllocationDetails>();
				while (reader.Read()) {
					InvoiceLineAllocationDetails obj = new InvoiceLineAllocationDetails();
					obj.InvoiceLineAllocationId = GetReaderValue_Int32(reader, "InvoiceLineAllocationId", 0);
					obj.InvoiceLineNo = GetReaderValue_Int32(reader, "InvoiceLineNo", 0);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
					obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null);
					obj.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null);
					obj.Location = GetReaderValue_String(reader, "Location", "");
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
					obj.CountryOfManufactureNo = GetReaderValue_NullableInt32(reader, "CountryOfManufactureNo", null);
					obj.CustomerRMAGoodsInLineNo = GetReaderValue_NullableInt32(reader, "CustomerRMAGoodsInLineNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", "");
					obj.LotName = GetReaderValue_String(reader, "LotName", "");
					obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
					obj.InvoiceNo = GetReaderValue_Int32(reader, "InvoiceNo", 0);
					obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
					obj.InvoiceNumber = GetReaderValue_NullableInt32(reader, "InvoiceNumber", null);
					obj.InvoiceDate = GetReaderValue_NullableDateTime(reader, "InvoiceDate", null);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
					obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
					obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null);
					obj.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", null);
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.SalesOrderLineId = GetReaderValue_NullableInt32(reader, "SalesOrderLineId", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
					obj.PurchasePrice = GetReaderValue_NullableDouble(reader, "PurchasePrice", null);
					obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
					obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
					obj.PurchaseCurrencyNo = GetReaderValue_NullableInt32(reader, "PurchaseCurrencyNo", null);
					obj.PurchaseCurrencyCode = GetReaderValue_String(reader, "PurchaseCurrencyCode", "");
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.Buyer = GetReaderValue_NullableInt32(reader, "Buyer", null);
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.QuantityAllocatedToCRMA = GetReaderValue_NullableInt32(reader, "QuantityAllocatedToCRMA", null);
                    obj.SOSerialNo = GetReaderValue_NullableInt32(reader, "SOSerialNo", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get InvoiceLineAllocations", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForGoodsInLine 
		/// Calls [usp_selectAll_InvoiceLineAllocation_for_GoodsInLine]
        /// </summary>
		public override List<InvoiceLineAllocationDetails> GetListForGoodsInLine(System.Int32? goodsInLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_InvoiceLineAllocation_for_GoodsInLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@GoodsInLineId", SqlDbType.Int).Value = goodsInLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<InvoiceLineAllocationDetails> lst = new List<InvoiceLineAllocationDetails>();
				while (reader.Read()) {
					InvoiceLineAllocationDetails obj = new InvoiceLineAllocationDetails();
					obj.InvoiceLineAllocationId = GetReaderValue_Int32(reader, "InvoiceLineAllocationId", 0);
					obj.InvoiceLineNo = GetReaderValue_Int32(reader, "InvoiceLineNo", 0);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
					obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null);
					obj.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null);
					obj.Location = GetReaderValue_String(reader, "Location", "");
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
					obj.CountryOfManufactureNo = GetReaderValue_NullableInt32(reader, "CountryOfManufactureNo", null);
					obj.CustomerRMAGoodsInLineNo = GetReaderValue_NullableInt32(reader, "CustomerRMAGoodsInLineNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", "");
					obj.LotName = GetReaderValue_String(reader, "LotName", "");
					obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
					obj.InvoiceNo = GetReaderValue_Int32(reader, "InvoiceNo", 0);
					obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
					obj.InvoiceNumber = GetReaderValue_NullableInt32(reader, "InvoiceNumber", null);
					obj.InvoiceDate = GetReaderValue_NullableDateTime(reader, "InvoiceDate", null);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
					obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
					obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null);
					obj.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", null);
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.SalesOrderLineId = GetReaderValue_NullableInt32(reader, "SalesOrderLineId", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
					obj.PurchasePrice = GetReaderValue_NullableDouble(reader, "PurchasePrice", null);
					obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
					obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
					obj.PurchaseCurrencyNo = GetReaderValue_NullableInt32(reader, "PurchaseCurrencyNo", null);
					obj.PurchaseCurrencyCode = GetReaderValue_String(reader, "PurchaseCurrencyCode", "");
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.Buyer = GetReaderValue_NullableInt32(reader, "Buyer", null);
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.QuantityAllocatedToCRMA = GetReaderValue_NullableInt32(reader, "QuantityAllocatedToCRMA", null);
                    //obj.ClientLandedCost = GetReaderValue_NullableDouble(reader, "ClientLandedCost", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get InvoiceLineAllocations", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForInvoiceLine 
		/// Calls [usp_selectAll_InvoiceLineAllocation_for_InvoiceLine]
        /// </summary>
		public override List<InvoiceLineAllocationDetails> GetListForInvoiceLine(System.Int32? invoiceLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_InvoiceLineAllocation_for_InvoiceLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@InvoiceLineId", SqlDbType.Int).Value = invoiceLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<InvoiceLineAllocationDetails> lst = new List<InvoiceLineAllocationDetails>();
				while (reader.Read()) {
					InvoiceLineAllocationDetails obj = new InvoiceLineAllocationDetails();
					obj.InvoiceLineAllocationId = GetReaderValue_Int32(reader, "InvoiceLineAllocationId", 0);
					obj.InvoiceLineNo = GetReaderValue_Int32(reader, "InvoiceLineNo", 0);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
					obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null);
					obj.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null);
					obj.Location = GetReaderValue_String(reader, "Location", "");
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
					obj.CountryOfManufactureNo = GetReaderValue_NullableInt32(reader, "CountryOfManufactureNo", null);
					obj.CustomerRMAGoodsInLineNo = GetReaderValue_NullableInt32(reader, "CustomerRMAGoodsInLineNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", "");
					obj.LotName = GetReaderValue_String(reader, "LotName", "");
					obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
					obj.InvoiceNo = GetReaderValue_Int32(reader, "InvoiceNo", 0);
					obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
					obj.InvoiceNumber = GetReaderValue_NullableInt32(reader, "InvoiceNumber", null);
					obj.InvoiceDate = GetReaderValue_NullableDateTime(reader, "InvoiceDate", null);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
					obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
					obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null);
					obj.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", null);
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.SalesOrderLineId = GetReaderValue_NullableInt32(reader, "SalesOrderLineId", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
					obj.PurchasePrice = GetReaderValue_NullableDouble(reader, "PurchasePrice", null);
					obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
					obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
					obj.PurchaseCurrencyNo = GetReaderValue_NullableInt32(reader, "PurchaseCurrencyNo", null);
					obj.PurchaseCurrencyCode = GetReaderValue_String(reader, "PurchaseCurrencyCode", "");
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.Buyer = GetReaderValue_NullableInt32(reader, "Buyer", null);
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.QuantityAllocatedToCRMA = GetReaderValue_NullableInt32(reader, "QuantityAllocatedToCRMA", null);
                    obj.SOSerialNo = GetReaderValue_NullableInt32(reader, "POSerialNO", null);
                   // obj.ClientLandedCost = GetReaderValue_NullableDouble(reader, "ClientLandedCost", null);
                    obj.ClientSupplierNo = GetReaderValue_NullableInt32(reader, "ClientSupplierNo", null);
                    obj.ClientSupplierName = GetReaderValue_String(reader, "ClientSupplierName", "");
                    obj.InternalPurchaseOrderNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNo", 0);
                    obj.InternalPurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNumber", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get InvoiceLineAllocations", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForPurchaseOrderLine 
		/// Calls [usp_selectAll_InvoiceLineAllocation_for_PurchaseOrderLine]
        /// </summary>
		public override List<InvoiceLineAllocationDetails> GetListForPurchaseOrderLine(System.Int32? purchaseOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_InvoiceLineAllocation_for_PurchaseOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Value = purchaseOrderLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<InvoiceLineAllocationDetails> lst = new List<InvoiceLineAllocationDetails>();
				while (reader.Read()) {
					InvoiceLineAllocationDetails obj = new InvoiceLineAllocationDetails();
					obj.InvoiceLineAllocationId = GetReaderValue_Int32(reader, "InvoiceLineAllocationId", 0);
					obj.InvoiceLineNo = GetReaderValue_Int32(reader, "InvoiceLineNo", 0);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
					obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null);
					obj.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null);
					obj.Location = GetReaderValue_String(reader, "Location", "");
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
					obj.CountryOfManufactureNo = GetReaderValue_NullableInt32(reader, "CountryOfManufactureNo", null);
					obj.CustomerRMAGoodsInLineNo = GetReaderValue_NullableInt32(reader, "CustomerRMAGoodsInLineNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", "");
					obj.LotName = GetReaderValue_String(reader, "LotName", "");
					obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
					obj.InvoiceNo = GetReaderValue_Int32(reader, "InvoiceNo", 0);
					obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
					obj.InvoiceNumber = GetReaderValue_NullableInt32(reader, "InvoiceNumber", null);
					obj.InvoiceDate = GetReaderValue_NullableDateTime(reader, "InvoiceDate", null);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
					obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
					obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null);
					obj.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", null);
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.SalesOrderLineId = GetReaderValue_NullableInt32(reader, "SalesOrderLineId", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
					obj.PurchasePrice = GetReaderValue_NullableDouble(reader, "PurchasePrice", null);
					obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
					obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
					obj.PurchaseCurrencyNo = GetReaderValue_NullableInt32(reader, "PurchaseCurrencyNo", null);
					obj.PurchaseCurrencyCode = GetReaderValue_String(reader, "PurchaseCurrencyCode", "");
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.Buyer = GetReaderValue_NullableInt32(reader, "Buyer", null);
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.QuantityAllocatedToCRMA = GetReaderValue_NullableInt32(reader, "QuantityAllocatedToCRMA", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get InvoiceLineAllocations", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForSupplierRMALine 
		/// Calls [usp_selectAll_InvoiceLineAllocation_for_SupplierRMALine]
        /// </summary>
		public override List<InvoiceLineAllocationDetails> GetListForSupplierRMALine(System.Int32? supplierRmaLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_InvoiceLineAllocation_for_SupplierRMALine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SupplierRMALineId", SqlDbType.Int).Value = supplierRmaLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<InvoiceLineAllocationDetails> lst = new List<InvoiceLineAllocationDetails>();
				while (reader.Read()) {
					InvoiceLineAllocationDetails obj = new InvoiceLineAllocationDetails();
					obj.InvoiceLineAllocationId = GetReaderValue_Int32(reader, "InvoiceLineAllocationId", 0);
					obj.InvoiceLineNo = GetReaderValue_Int32(reader, "InvoiceLineNo", 0);
					obj.Quantity = GetReaderValue_Int32(reader, "Quantity", 0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
					obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null);
					obj.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null);
					obj.Location = GetReaderValue_String(reader, "Location", "");
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
					obj.CountryOfManufactureNo = GetReaderValue_NullableInt32(reader, "CountryOfManufactureNo", null);
					obj.CustomerRMAGoodsInLineNo = GetReaderValue_NullableInt32(reader, "CustomerRMAGoodsInLineNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.LineNotes = GetReaderValue_String(reader, "LineNotes", "");
					obj.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", "");
					obj.LotName = GetReaderValue_String(reader, "LotName", "");
					obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
					obj.InvoiceNo = GetReaderValue_Int32(reader, "InvoiceNo", 0);
					obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null);
					obj.InvoiceNumber = GetReaderValue_NullableInt32(reader, "InvoiceNumber", null);
					obj.InvoiceDate = GetReaderValue_NullableDateTime(reader, "InvoiceDate", null);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.Salesman2 = GetReaderValue_NullableInt32(reader, "Salesman2", null);
					obj.ShippingCost = GetReaderValue_NullableDouble(reader, "ShippingCost", null);
					obj.Freight = GetReaderValue_NullableDouble(reader, "Freight", null);
					obj.Salesman2Name = GetReaderValue_String(reader, "Salesman2Name", "");
					obj.Salesman2Percent = GetReaderValue_Double(reader, "Salesman2Percent", 0);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
					obj.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null);
					obj.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", null);
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.SalesOrderLineId = GetReaderValue_NullableInt32(reader, "SalesOrderLineId", null);
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
					obj.PurchasePrice = GetReaderValue_NullableDouble(reader, "PurchasePrice", null);
					obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
					obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
					obj.PurchaseCurrencyNo = GetReaderValue_NullableInt32(reader, "PurchaseCurrencyNo", null);
					obj.PurchaseCurrencyCode = GetReaderValue_String(reader, "PurchaseCurrencyCode", "");
					obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.Buyer = GetReaderValue_NullableInt32(reader, "Buyer", null);
					obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
					obj.QuantityAllocatedToCRMA = GetReaderValue_NullableInt32(reader, "QuantityAllocatedToCRMA", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get InvoiceLineAllocations", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update InvoiceLineAllocation
		/// Calls [usp_update_InvoiceLineAllocation]
        /// </summary>
		public override bool Update(System.Int32? invoiceLineAllocationId, System.Int32? invoiceLineNo, System.Int32? quantity, System.Int32? stockNo, System.Int32? salesOrderLineNo, System.Int32? lotNo, System.Double? landedCost, System.Int32? supplierRmaLineNo, System.Int32? warehouseNo, System.String location, System.Int32? goodsInLineNo, System.Int32? purchaseOrderLineNo, System.Int32? customerRmaGoodsInLineNo, System.Int32? countryOfManufactureNo, System.String notes, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_InvoiceLineAllocation", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@InvoiceLineAllocationId", SqlDbType.Int).Value = invoiceLineAllocationId;
				cmd.Parameters.Add("@InvoiceLineNo", SqlDbType.Int).Value = invoiceLineNo;
				cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
				cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
				cmd.Parameters.Add("@SalesOrderLineNo", SqlDbType.Int).Value = salesOrderLineNo;
				cmd.Parameters.Add("@LotNo", SqlDbType.Int).Value = lotNo;
				cmd.Parameters.Add("@LandedCost", SqlDbType.Float).Value = landedCost;
				cmd.Parameters.Add("@SupplierRMALineNo", SqlDbType.Int).Value = supplierRmaLineNo;
				cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
				cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = location;
				cmd.Parameters.Add("@GoodsInLineNo", SqlDbType.Int).Value = goodsInLineNo;
				cmd.Parameters.Add("@PurchaseOrderLineNo", SqlDbType.Int).Value = purchaseOrderLineNo;
				cmd.Parameters.Add("@CustomerRMAGoodsInLineNo", SqlDbType.Int).Value = customerRmaGoodsInLineNo;
				cmd.Parameters.Add("@CountryOfManufactureNo", SqlDbType.Int).Value = countryOfManufactureNo;
				cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update InvoiceLineAllocation", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}