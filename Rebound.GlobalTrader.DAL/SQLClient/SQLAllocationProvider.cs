//Marker     Changed by      Date         Remarks
//[001]      Vinay           30/08/2012   Add purchase order link in srma allocation lines
//[002]      Vinay           31/08/2012   Add sales order link in purchase order allocation lines
//[003]      Vinay           31/08/2012   Add sales order link in CRMA allocation lines
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
	public class SqlAllocationProvider : AllocationProvider {
		/// <summary>
		/// Delete Allocation
		/// Calls [usp_delete_Allocation]
		/// </summary>
		public override bool Delete(System.Int32? allocationId, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_delete_Allocation", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@AllocationId", SqlDbType.Int).Value = allocationId;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to delete Allocation", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		/// <summary>
		/// Create a new row
		/// Calls [usp_insert_Allocation]
		/// </summary>
        public override Int32 Insert(System.Int32? stockNo, System.Int32? salesOrderLineNo, System.Int32? quantityAllocated, System.Int32? supplierRmaLineNo, System.Int32? updatedBy, System.Boolean? createSONonIPO)
        {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_insert_Allocation", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
				cmd.Parameters.Add("@SalesOrderLineNo", SqlDbType.Int).Value = salesOrderLineNo;
				cmd.Parameters.Add("@QuantityAllocated", SqlDbType.Int).Value = quantityAllocated;
				cmd.Parameters.Add("@SupplierRMALineNo", SqlDbType.Int).Value = supplierRmaLineNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@CreateSONONIPO", SqlDbType.Bit).Value = createSONonIPO;
				cmd.Parameters.Add("@AllocationId", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (Int32)cmd.Parameters["@AllocationId"].Value;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to insert Allocation", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}

        /// Create a new row
        /// Calls [usp_insert_AllocationExt]
        /// </summary>
        public override Int32 InsertNew(System.Int32? stockNo, System.Int32? salesOrderLineNo, System.Int32? quantityAllocated, System.Int32? supplierRmaLineNo, System.Int32? updatedBy, System.Boolean? updateSOIsIPO)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_AllocationExt", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
                cmd.Parameters.Add("@SalesOrderLineNo", SqlDbType.Int).Value = salesOrderLineNo;
                cmd.Parameters.Add("@QuantityAllocated", SqlDbType.Int).Value = quantityAllocated;
                cmd.Parameters.Add("@SupplierRMALineNo", SqlDbType.Int).Value = supplierRmaLineNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@UpdateIsIPO", SqlDbType.Bit).Value = updateSOIsIPO;
                cmd.Parameters.Add("@AllocationId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@AllocationId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Allocation", sqlex);
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
        /// Calls [usp_insert_IPOAllocation]
        /// </summary>
        public override Int32 InsertIPO(System.Int32? stockNo, System.Int32? salesOrderLineNo, System.Int32? quantityAllocated, System.Int32? supplierRmaLineNo, System.Int32? updatedBy, System.Boolean? createSONonIPO)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_IPOAllocation", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
                cmd.Parameters.Add("@SalesOrderLineNo", SqlDbType.Int).Value = salesOrderLineNo;
                cmd.Parameters.Add("@QuantityAllocated", SqlDbType.Int).Value = quantityAllocated;
                cmd.Parameters.Add("@SupplierRMALineNo", SqlDbType.Int).Value = supplierRmaLineNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@CreateSONONIPO", SqlDbType.Bit).Value = createSONonIPO;
                cmd.Parameters.Add("@AllocationId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@AllocationId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Allocation", sqlex);
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
		/// Calls [usp_select_Allocation]
        /// </summary>
		public override AllocationDetails Get(System.Int32? allocationId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_select_Allocation", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@AllocationId", SqlDbType.Int).Value = allocationId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
				if (reader.Read()) {
					//return GetAllocationFromReader(reader);
					AllocationDetails obj = new AllocationDetails();
					obj.AllocationId = GetReaderValue_Int32(reader, "AllocationId", 0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					return obj;
				} else {
					return null;
				}
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Allocation", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetList 
		/// Calls [usp_selectAll_Allocation]
        /// </summary>
		public override List<AllocationDetails> GetList() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Allocation", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<AllocationDetails> lst = new List<AllocationDetails>();
				while (reader.Read()) {
					AllocationDetails obj = new AllocationDetails();
					obj.AllocationId = GetReaderValue_Int32(reader, "AllocationId", 0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.SupplierRMALineNo = GetReaderValue_NullableInt32(reader, "SupplierRMALineNo", null);
					obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
					obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
					obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.QuantityInStock = GetReaderValue_Int32(reader, "QuantityInStock", 0);
					obj.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null);
					obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
					obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
					obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
					obj.PurchaseOrderLineId = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineId", null);
					obj.BuyPrice = GetReaderValue_NullableDouble(reader, "BuyPrice", null);
					obj.DeliveryDate = GetReaderValue_NullableDateTime(reader, "DeliveryDate", null);
					obj.BuyCurrencyNo = GetReaderValue_NullableInt32(reader, "BuyCurrencyNo", null);
					obj.BuyCurrencyCode = GetReaderValue_String(reader, "BuyCurrencyCode", "");
					obj.SupplierCompanyNo = GetReaderValue_NullableInt32(reader, "SupplierCompanyNo", null);
					obj.SupplierCompanyName = GetReaderValue_String(reader, "SupplierCompanyName", "");
					obj.CustomerCompanyNo = GetReaderValue_NullableInt32(reader, "CustomerCompanyNo", null);
					obj.CustomerCompanyName = GetReaderValue_String(reader, "CustomerCompanyName", "");
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.SellPrice = GetReaderValue_NullableDouble(reader, "SellPrice", null);
					obj.SellCurrencyNo = GetReaderValue_NullableInt32(reader, "SellCurrencyNo", null);
					obj.SellCurrencyCode = GetReaderValue_String(reader, "SellCurrencyCode", "");
					obj.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.Shipped = GetReaderValue_NullableBoolean(reader, "Shipped", null);
					obj.Location = GetReaderValue_String(reader, "Location", "");
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Allocations", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForCustomerRMALine 
		/// Calls [usp_selectAll_Allocation_for_CustomerRMALine]
        /// </summary>
		public override List<AllocationDetails> GetListForCustomerRMALine(System.Int32? customerRmaLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Allocation_for_CustomerRMALine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@CustomerRMALineId", SqlDbType.Int).Value = customerRmaLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<AllocationDetails> lst = new List<AllocationDetails>();
				while (reader.Read()) {
					AllocationDetails obj = new AllocationDetails();
					obj.AllocationId = GetReaderValue_Int32(reader, "AllocationId", 0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.CustomerRMALineNo = GetReaderValue_NullableInt32(reader, "CustomerRMALineNo", null);
					obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
					obj.ReturnDate = GetReaderValue_NullableDateTime(reader, "ReturnDate", null);
					obj.SupplierRMADate = GetReaderValue_NullableDateTime(reader, "SupplierRMADate", null);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
                    //[003] code start
                    obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
                    //[003] code end
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Allocations", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForGoodsInLine 
		/// Calls [usp_selectAll_Allocation_for_GoodsInLine]
        /// </summary>
		public override List<AllocationDetails> GetListForGoodsInLine(System.Int32? goodsInLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Allocation_for_GoodsInLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@GoodsInLineId", SqlDbType.Int).Value = goodsInLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<AllocationDetails> lst = new List<AllocationDetails>();
				while (reader.Read()) {
					AllocationDetails obj = new AllocationDetails();
					obj.AllocationId = GetReaderValue_Int32(reader, "AllocationId", 0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.CustomerRMALineNo = GetReaderValue_NullableInt32(reader, "CustomerRMALineNo", null);
					obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
					obj.ReturnDate = GetReaderValue_NullableDateTime(reader, "ReturnDate", null);
					obj.SupplierRMADate = GetReaderValue_NullableDateTime(reader, "SupplierRMADate", null);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
                    obj.POSerialNo = GetReaderValue_Int16(reader, "SOSerialNo", 0);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Allocations", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForPurchaseOrderLine 
		/// Calls [usp_selectAll_Allocation_for_PurchaseOrderLine]
        /// </summary>
		public override List<AllocationDetails> GetListForPurchaseOrderLine(System.Int32? purchaseOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Allocation_for_PurchaseOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Value = purchaseOrderLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<AllocationDetails> lst = new List<AllocationDetails>();
				while (reader.Read()) {
					AllocationDetails obj = new AllocationDetails();
					obj.AllocationId = GetReaderValue_Int32(reader, "AllocationId", 0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.CustomerRMALineNo = GetReaderValue_NullableInt32(reader, "CustomerRMALineNo", null);
					obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
					obj.ReturnDate = GetReaderValue_NullableDateTime(reader, "ReturnDate", null);
					obj.SupplierRMADate = GetReaderValue_NullableDateTime(reader, "SupplierRMADate", null);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
                    //[002] code start
                    obj.SalesOrderLineNo = GetReaderValue_NullableInt32(reader, "SalesOrderLineNo", null);
                    //[002] code end
                    obj.SOSerialNo = GetReaderValue_Int16(reader, "SOSerialNo", 0);
                    obj.ShipASAP = GetReaderValue_NullableBoolean(reader, "ShipASAP", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Allocations", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForSalesOrderLine 
		/// Calls [usp_selectAll_Allocation_for_SalesOrderLine]
        /// </summary>
		public override List<AllocationDetails> GetListForSalesOrderLine(System.Int32? salesOrderLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Allocation_for_SalesOrderLine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SalesOrderLineId", SqlDbType.Int).Value = salesOrderLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<AllocationDetails> lst = new List<AllocationDetails>();
				while (reader.Read()) {
					AllocationDetails obj = new AllocationDetails();
					obj.AllocationId = GetReaderValue_Int32(reader, "AllocationId", 0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
					obj.QuantityInStock = GetReaderValue_Int32(reader, "QuantityInStock", 0);
					obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
					obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
					obj.ReturnDate = GetReaderValue_NullableDateTime(reader, "ReturnDate", null);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					obj.ExpediteDate = GetReaderValue_NullableDateTime(reader, "ExpediteDate", null);
					obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
					obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
					obj.QuantityOnOrder = GetReaderValue_NullableInt32(reader, "QuantityOnOrder", null);
                    obj.POSerialNo = GetReaderValue_Int16(reader, "POSerialNo", 0);
                    obj.InternalPurchaseOrderId = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderId", null);
                    obj.InternalPurchaseOrderNo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNumber", null);
                    obj.IPOSupplier = GetReaderValue_NullableInt32(reader, "IPOSupplier", null);
                    obj.IPOSupplierName = GetReaderValue_String(reader, "IPOSupplierName", "");
                    obj.ClientLandedCost = GetReaderValue_NullableDouble(reader, "ClientLandedCost", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Allocations", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForStock 
		/// Calls [usp_selectAll_Allocation_for_Stock]
        /// </summary>
		public override List<AllocationDetails> GetListForStock(System.Int32? stockId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Allocation_for_Stock", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@StockId", SqlDbType.Int).Value = stockId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<AllocationDetails> lst = new List<AllocationDetails>();
				while (reader.Read()) {
					AllocationDetails obj = new AllocationDetails();
					obj.AllocationId = GetReaderValue_Int32(reader, "AllocationId", 0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.SalesmanName = GetReaderValue_String(reader, "SalesmanName", "");
					obj.SupplierRMANo = GetReaderValue_NullableInt32(reader, "SupplierRMANo", null);
					obj.SupplierRMANumber = GetReaderValue_NullableInt32(reader, "SupplierRMANumber", null);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
					obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
					obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
					obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
					obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
					obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
					obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.Salesman = GetReaderValue_NullableInt32(reader, "Salesman", null);
					obj.SalesOrderNo = GetReaderValue_NullableInt32(reader, "SalesOrderNo", null);
					obj.SalesOrderNumber = GetReaderValue_NullableInt32(reader, "SalesOrderNumber", null);
					obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");
					obj.DatePromised = GetReaderValue_NullableDateTime(reader, "DatePromised", null);
					obj.CustomerPart = GetReaderValue_String(reader, "CustomerPart", "");
					obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
					obj.CustomerRMALineNo = GetReaderValue_NullableInt32(reader, "CustomerRMALineNo", null);
					obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
					obj.ReturnDate = GetReaderValue_NullableDateTime(reader, "ReturnDate", null);
					obj.SupplierRMADate = GetReaderValue_NullableDateTime(reader, "SupplierRMADate", null);
					obj.CompanyNo = GetReaderValue_Int32(reader, "CompanyNo", 0);
					obj.CompanyName = GetReaderValue_String(reader, "CompanyName", "");
					obj.CurrencyNo = GetReaderValue_NullableInt32(reader, "CurrencyNo", null);
					obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
					obj.Price = GetReaderValue_NullableDouble(reader, "Price", null);
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Allocations", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// GetListForSupplierRMALine 
		/// Calls [usp_selectAll_Allocation_for_SupplierRMALine]
        /// </summary>
		public override List<AllocationDetails> GetListForSupplierRMALine(System.Int32? supplierRmaLineId) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_selectAll_Allocation_for_SupplierRMALine", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = 30;
				cmd.Parameters.Add("@SupplierRMALineId", SqlDbType.Int).Value = supplierRmaLineId;
				cn.Open();
				DbDataReader reader = ExecuteReader(cmd);
				List<AllocationDetails> lst = new List<AllocationDetails>();
				while (reader.Read()) {
					AllocationDetails obj = new AllocationDetails();
					obj.AllocationId = GetReaderValue_Int32(reader, "AllocationId", 0);
					obj.StockNo = GetReaderValue_NullableInt32(reader, "StockNo", null);
					obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
					obj.Part = GetReaderValue_String(reader, "Part", "");
					obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
					obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
					obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
					obj.SupplierCompanyNo = GetReaderValue_NullableInt32(reader, "SupplierCompanyNo", null);
					obj.SupplierCompanyName = GetReaderValue_String(reader, "SupplierCompanyName", "");
					obj.Location = GetReaderValue_String(reader, "Location", "");
					obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
					obj.ReturnDate = GetReaderValue_NullableDateTime(reader, "ReturnDate", null);
					obj.ExpediteDate = GetReaderValue_NullableDateTime(reader, "ExpediteDate", null);
					obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
					obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    //[001] code start
                    obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", 0);
                    //[001] code end
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Allocations", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Allocation
		/// Calls [usp_update_Allocation]
        /// </summary>
		public override bool Update(System.Int32? allocationId, System.Int32? stockNo, System.Int32? salesOrderLineNo, System.Int32? quantityAllocated, System.Int32? supplierRmaLineNo, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Allocation", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@AllocationId", SqlDbType.Int).Value = allocationId;
				cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
				cmd.Parameters.Add("@SalesOrderLineNo", SqlDbType.Int).Value = salesOrderLineNo;
				cmd.Parameters.Add("@QuantityAllocated", SqlDbType.Int).Value = quantityAllocated;
				cmd.Parameters.Add("@SupplierRMALineNo", SqlDbType.Int).Value = supplierRmaLineNo;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Allocation", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Allocation
		/// Calls [usp_update_Allocation_AfterIncreaseGIQuantity]
        /// </summary>
		public override bool UpdateAfterIncreaseGIQuantity(System.Int32? goodsInLineNo, System.Int32? oldQuantity, System.Int32? newQuantity, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Allocation_AfterIncreaseGIQuantity", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@GoodsInLineNo", SqlDbType.Int).Value = goodsInLineNo;
				cmd.Parameters.Add("@OldQuantity", SqlDbType.Int).Value = oldQuantity;
				cmd.Parameters.Add("@NewQuantity", SqlDbType.Int).Value = newQuantity;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Allocation", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Allocation
		/// Calls [usp_Update_Allocation_AfterPartialReceive]
        /// </summary>
		public override bool UpdateAfterPartialReceive(System.Int32? goodsInLineNo, System.Int32? goodsInNo, System.Int32? quantityInserted, System.Int32? quantityOnOrderChange, System.Int32? updatedBy) {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_Update_Allocation_AfterPartialReceive", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@GoodsInLineNo", SqlDbType.Int).Value = goodsInLineNo;
				cmd.Parameters.Add("@GoodsInNo", SqlDbType.Int).Value = goodsInNo;
				cmd.Parameters.Add("@QuantityInserted", SqlDbType.Int).Value = quantityInserted;
				cmd.Parameters.Add("@QuantityOnOrderChange", SqlDbType.Int).Value = quantityOnOrderChange;
				cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Allocation", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
        /// <summary>
        /// Update Allocation
		/// Calls [usp_update_Allocation_CleanUp]
        /// </summary>
		public override bool UpdateCleanUp() {
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try {
				cn = new SqlConnection(this.ConnectionString);
				cmd = new SqlCommand("usp_update_Allocation_CleanUp", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cn.Open();
				int ret = ExecuteNonQuery(cmd);
				return (ret > 0);
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to update Allocation", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
		
		
		
		
	}
}