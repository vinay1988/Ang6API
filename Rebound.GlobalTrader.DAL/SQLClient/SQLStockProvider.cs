/* Marker     changed by      date         Remarks
 [001]      Vikas kumar     17/11/2011  ESMS Ref:23 - PO No. and Crma No. should alos be displayed 
 [002]      Vinay           07/05/2012   This need to upload pdf document for stock section
 [003]      Vinay           01/08/2012   Delete UnAllocated Stock Bug
 [004]      Vinay           15/10/2012   Display company type in stock grid
 [005]      Vinay           08/04/2014   CR:- Stock Provision
 [006]      Vinay           30/07/2015   ESMS Ticket No: 255
 [007]      Suhail          01/05/2018   Adding MSL 
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
    public class SqlStockProvider : StockProvider
    {
        /// <summary>
        /// AutoSearch 
        /// Calls [usp_autosearch_Stock]
        /// </summary>
        public override List<StockDetails> AutoSearch(System.Int32? clientId, System.String nameSearch)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_autosearch_Stock", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@NameSearch", SqlDbType.NVarChar).Value = nameSearch;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<StockDetails> lst = new List<StockDetails>();
                while (reader.Read())
                {
                    StockDetails obj = new StockDetails();
                    obj.StockId = GetReaderValue_Int32(reader, "StockId", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Stocks", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Count Stock
        /// Calls [usp_count_Stock_for_Client]
        /// </summary>
        public override Int32 CountForClient(System.Int32? clientId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_count_Stock_for_Client", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cn.Open();
                return (Int32)ExecuteScalar(cmd);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to count Stock", sqlex);
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
        /// Calls [usp_datalistnugget_Stock]
        /// </summary>
        public override List<StockDetails> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Boolean? quarantine, System.String partSearch, System.Int32? lotNo, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.String supplierPartSearch, System.String supplierNameSearch, System.String locationSearch, System.Int32? warehouseNo, System.Boolean? recentOnly, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.Boolean? includeZeroStock, System.Int32? clientSearch, int? IsPoHub, Boolean IsGlobalLogin)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_datalistnugget_Stock", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
                cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                cmd.Parameters.Add("@Quarantine", SqlDbType.Bit).Value = quarantine;
                cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
                cmd.Parameters.Add("@LotNo", SqlDbType.Int).Value = lotNo;
                cmd.Parameters.Add("@PurchaseOrderNoLo", SqlDbType.Int).Value = purchaseOrderNoLo;
                cmd.Parameters.Add("@PurchaseOrderNoHi", SqlDbType.Int).Value = purchaseOrderNoHi;
                cmd.Parameters.Add("@SupplierPartSearch", SqlDbType.NVarChar).Value = supplierPartSearch;
                cmd.Parameters.Add("@SupplierNameSearch", SqlDbType.NVarChar).Value = supplierNameSearch;
                cmd.Parameters.Add("@LocationSearch", SqlDbType.NVarChar).Value = locationSearch;
                cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
                cmd.Parameters.Add("@RecentOnly", SqlDbType.Bit).Value = recentOnly;
                cmd.Parameters.Add("@CustomerRMANoLo", SqlDbType.Int).Value = customerRmaNoLo;
                cmd.Parameters.Add("@CustomerRMANoHi", SqlDbType.Int).Value = customerRmaNoHi;
                cmd.Parameters.Add("@IncludeZeroStock", SqlDbType.Bit).Value = includeZeroStock;
                cmd.Parameters.Add("@ClientSearch", SqlDbType.Int).Value = clientSearch;
                cmd.Parameters.Add("@IsPoHub", SqlDbType.Int).Value = IsPoHub ?? 0;
                cmd.Parameters.Add("@IsGlobalLogin", SqlDbType.Bit).Value = IsGlobalLogin;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<StockDetails> lst = new List<StockDetails>();
                while (reader.Read())
                {
                    StockDetails obj = new StockDetails();
                    obj.StockId = GetReaderValue_Int32(reader, "StockId", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null);
                    obj.QuantityInStock = GetReaderValue_Int32(reader, "QuantityInStock", 0);
                    obj.QuantityOnOrder = GetReaderValue_Int32(reader, "QuantityOnOrder", 0);
                    obj.Location = GetReaderValue_String(reader, "Location", "");
                    obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.LotName = GetReaderValue_String(reader, "LotName", "");
                    obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
                    obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
                    obj.QuantityAvailable = GetReaderValue_NullableInt32(reader, "QuantityAvailable", null);
                    obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    //[001]Code Start
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                    obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", null);
                    //obj.ClientNo = GetReaderValue_NullableInt32(reader, "ClientNo", null)??0;
                    //[001]Code End
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Stocks", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Delete Stock
        /// Calls [usp_delete_Stock]
        /// </summary>
        public override bool Delete(System.Int32? stockId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_Stock", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StockId", SqlDbType.Int).Value = stockId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete Stock", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Delete Stock
        /// Calls [usp_delete_Stock_Unallocated_for_Lot]
        /// </summary>
        public override bool DeleteUnallocatedForLot(System.Int32? lotNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_Stock_Unallocated_for_Lot", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LotNo", SqlDbType.Int).Value = lotNo;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret >= 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete Stock", sqlex);
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
        /// Calls [usp_insert_Stock]
        /// </summary>
        public override Int32 Insert(System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? warehouseNo, System.Int32? clientNo, System.String qualityControlNotes, System.Int32? purchaseOrderNo, System.Int32? purchaseOrderLineNo, System.Int32? customerRmaNo, System.Int32? customerRmaLineNo, System.Int32? quantityInStock, System.Int32? quantityOnOrder, System.Int32? productNo, System.Double? resalePrice, System.Boolean? unavailable, System.Int32? lotNo, System.Double? landedCost, System.String supplierPart, System.Byte? rohs, System.Int32? packageUnit, System.Int32? stockKeepingUnit, System.String stockLogChangeNotes, System.String location, System.Int32? countryOfManufacture, System.String partMarkings, System.Int32? countingMethodNo, System.Int32? updatedBy, System.Int32? divisionNo, System.String mslLevel)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_Stock", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
                cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
                cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
                cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
                cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@QualityControlNotes", SqlDbType.NVarChar).Value = qualityControlNotes;
                cmd.Parameters.Add("@PurchaseOrderNo", SqlDbType.Int).Value = purchaseOrderNo;
                cmd.Parameters.Add("@PurchaseOrderLineNo", SqlDbType.Int).Value = purchaseOrderLineNo;
                cmd.Parameters.Add("@CustomerRMANo", SqlDbType.Int).Value = customerRmaNo;
                cmd.Parameters.Add("@CustomerRMALineNo", SqlDbType.Int).Value = customerRmaLineNo;
                cmd.Parameters.Add("@QuantityInStock", SqlDbType.Int).Value = quantityInStock;
                cmd.Parameters.Add("@QuantityOnOrder", SqlDbType.Int).Value = quantityOnOrder;
                cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
                cmd.Parameters.Add("@ResalePrice", SqlDbType.Float).Value = resalePrice;
                cmd.Parameters.Add("@Unavailable", SqlDbType.Bit).Value = unavailable;
                cmd.Parameters.Add("@LotNo", SqlDbType.Int).Value = lotNo;
                cmd.Parameters.Add("@LandedCost", SqlDbType.Float).Value = landedCost;
                cmd.Parameters.Add("@SupplierPart", SqlDbType.NVarChar).Value = supplierPart;
                cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
                cmd.Parameters.Add("@PackageUnit", SqlDbType.Int).Value = packageUnit;
                cmd.Parameters.Add("@StockKeepingUnit", SqlDbType.Int).Value = stockKeepingUnit;
                cmd.Parameters.Add("@StockLogChangeNotes", SqlDbType.NVarChar).Value = stockLogChangeNotes;
                cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = location;
                cmd.Parameters.Add("@CountryOfManufacture", SqlDbType.Int).Value = countryOfManufacture;
                cmd.Parameters.Add("@PartMarkings", SqlDbType.NVarChar).Value = partMarkings;
                cmd.Parameters.Add("@CountingMethodNo", SqlDbType.Int).Value = countingMethodNo;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                //[006] code start
                cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
                //[006] code end
                cmd.Parameters.Add("@StockId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@MSLLevel", SqlDbType.NVarChar).Value = mslLevel; 
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@StockId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Stock", sqlex);
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
        /// Calls [usp_insert_Stock_Identity_Off]
        /// </summary>
        public override Int32 InsertIdentityOff(System.Int32? stockId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? warehouseNo, System.Int32? clientNo, System.String qualityControlNotes, System.Int32? purchaseOrderNo, System.Int32? purchaseOrderLineNo, System.Int32? customerRmaNo, System.Int32? customerRmaLineNo, System.Int32? goodsInLineNo, System.Int32? quantityInStock, System.Int32? quantityOnOrder, System.Int32? productNo, System.Double? resalePrice, System.Boolean? unavailable, System.Int32? lotNo, System.Double? landedCost, System.String supplierPart, System.Byte? rohs, System.Int32? packageUnit, System.Int32? stockKeepingUnit, System.String stockLogChangeNotes, System.String location, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_Stock_Identity_Off", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StockId", SqlDbType.Int).Value = stockId;
                cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
                cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
                cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
                cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
                cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@QualityControlNotes", SqlDbType.NVarChar).Value = qualityControlNotes;
                cmd.Parameters.Add("@PurchaseOrderNo", SqlDbType.Int).Value = purchaseOrderNo;
                cmd.Parameters.Add("@PurchaseOrderLineNo", SqlDbType.Int).Value = purchaseOrderLineNo;
                cmd.Parameters.Add("@CustomerRMANo", SqlDbType.Int).Value = customerRmaNo;
                cmd.Parameters.Add("@CustomerRMALineNo", SqlDbType.Int).Value = customerRmaLineNo;
                cmd.Parameters.Add("@GoodsInLineNo", SqlDbType.Int).Value = goodsInLineNo;
                cmd.Parameters.Add("@QuantityInStock", SqlDbType.Int).Value = quantityInStock;
                cmd.Parameters.Add("@QuantityOnOrder", SqlDbType.Int).Value = quantityOnOrder;
                cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
                cmd.Parameters.Add("@ResalePrice", SqlDbType.Float).Value = resalePrice;
                cmd.Parameters.Add("@Unavailable", SqlDbType.Bit).Value = unavailable;
                cmd.Parameters.Add("@LotNo", SqlDbType.Int).Value = lotNo;
                cmd.Parameters.Add("@LandedCost", SqlDbType.Float).Value = landedCost;
                cmd.Parameters.Add("@SupplierPart", SqlDbType.NVarChar).Value = supplierPart;
                cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
                cmd.Parameters.Add("@PackageUnit", SqlDbType.Int).Value = packageUnit;
                cmd.Parameters.Add("@StockKeepingUnit", SqlDbType.Int).Value = stockKeepingUnit;
                cmd.Parameters.Add("@StockLogChangeNotes", SqlDbType.NVarChar).Value = stockLogChangeNotes;
                cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = location;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@RowsAffected"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Stock", sqlex);
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
        /// Calls [usp_insert_Stock_Split]
        /// </summary>
        public override Int32 InsertSplit(System.Int32? stockId, System.Int32? quantitySplit, System.String location, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_Stock_Split", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StockId", SqlDbType.Int).Value = stockId;
                cmd.Parameters.Add("@QuantitySplit", SqlDbType.Int).Value = quantitySplit;
                cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = location;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@NewStockId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@NewStockId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert Stock", sqlex);
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
        /// Calls [usp_itemsearch_Stock]
        /// </summary>
        public override List<StockDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.Boolean? forRmAs, System.Int32? supplierRmaNo, System.Boolean? includeQuarantined, System.Boolean? includeLotsOnHold, System.Int32? poNoLo, System.Int32? poNoHi, System.Int32? crmaNoLo, System.Int32? crmaNoHi, System.Int32? warehouseNo, System.String location, System.Int32? incLockCustNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_itemsearch_Stock", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
                cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
                cmd.Parameters.Add("@ForRMAs", SqlDbType.Bit).Value = forRmAs;
                cmd.Parameters.Add("@SupplierRMANo", SqlDbType.Int).Value = supplierRmaNo;
                cmd.Parameters.Add("@IncludeQuarantined", SqlDbType.Bit).Value = includeQuarantined;
                cmd.Parameters.Add("@IncludeLotsOnHold", SqlDbType.Bit).Value = includeLotsOnHold;
                cmd.Parameters.Add("@PONoLo", SqlDbType.Int).Value = poNoLo;
                cmd.Parameters.Add("@PONoHi", SqlDbType.Int).Value = poNoHi;
                cmd.Parameters.Add("@CRMANoLo", SqlDbType.Int).Value = crmaNoLo;
                cmd.Parameters.Add("@CRMANoHi", SqlDbType.Int).Value = crmaNoHi;
                cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
                cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = location;
                cmd.Parameters.Add("@IncludeLockLotCustNo", SqlDbType.Int).Value = incLockCustNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<StockDetails> lst = new List<StockDetails>();
                while (reader.Read())
                {
                    StockDetails obj = new StockDetails();
                    obj.StockId = GetReaderValue_Int32(reader, "StockId", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.QuantityInStock = GetReaderValue_Int32(reader, "QuantityInStock", 0);
                    obj.QuantityOnOrder = GetReaderValue_Int32(reader, "QuantityOnOrder", 0);
                    obj.Location = GetReaderValue_String(reader, "Location", "");
                    obj.Unavailable = GetReaderValue_Boolean(reader, "Unavailable", false);
                    obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
                    obj.QuantityAvailable = GetReaderValue_NullableInt32(reader, "QuantityAvailable", null);
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.PODeliveryDate = GetReaderValue_NullableDateTime(reader, "PODeliveryDate", null);
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    obj.CustomerRMADate = GetReaderValue_NullableDateTime(reader, "CustomerRMADate", null);
                    obj.POSerialNo = GetReaderValue_Int16(reader, "POSerialNo", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Stocks", sqlex);
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
        /// Calls [usp_itemsearch_IpoStock]
        /// </summary>
        public override List<StockDetails> IpoItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.Boolean? forRmAs, System.Int32? supplierRmaNo, System.Boolean? includeQuarantined, System.Boolean? includeLotsOnHold, System.Int32? poNoLo, System.Int32? poNoHi, System.Int32? crmaNoLo, System.Int32? crmaNoHi, System.Int32? warehouseNo, System.String location, System.Int32? incLockCustNo, int? salesOrderNo, System.Boolean? stopNONIpoStock)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_itemsearch_IpoStock", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 60;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@OrderBy", SqlDbType.Int).Value = orderBy;
                cmd.Parameters.Add("@SortDir", SqlDbType.Int).Value = sortDir;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
                cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
                cmd.Parameters.Add("@ForRMAs", SqlDbType.Bit).Value = forRmAs;
                cmd.Parameters.Add("@SupplierRMANo", SqlDbType.Int).Value = supplierRmaNo;
                cmd.Parameters.Add("@IncludeQuarantined", SqlDbType.Bit).Value = includeQuarantined;
                cmd.Parameters.Add("@IncludeLotsOnHold", SqlDbType.Bit).Value = includeLotsOnHold;
                cmd.Parameters.Add("@IPONo", SqlDbType.Int).Value = poNoLo??0;
                cmd.Parameters.Add("@CRMANoLo", SqlDbType.Int).Value = crmaNoLo;
                cmd.Parameters.Add("@CRMANoHi", SqlDbType.Int).Value = crmaNoHi;
                cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
                cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = location;
                cmd.Parameters.Add("@IncludeLockLotCustNo", SqlDbType.Int).Value = incLockCustNo;
                cmd.Parameters.Add("@SalesOrderNo", SqlDbType.Int).Value = salesOrderNo??0;
                cmd.Parameters.Add("@StopNonIPOStock", SqlDbType.Bit).Value = stopNONIpoStock;
               
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<StockDetails> lst = new List<StockDetails>();
                while (reader.Read())
                {
                    StockDetails obj = new StockDetails();
                    obj.StockId = GetReaderValue_Int32(reader, "StockId", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.QuantityInStock = GetReaderValue_Int32(reader, "QuantityInStock", 0);
                    obj.QuantityOnOrder = GetReaderValue_Int32(reader, "QuantityOnOrder", 0);
                    obj.Location = GetReaderValue_String(reader, "Location", "");
                    obj.Unavailable = GetReaderValue_Boolean(reader, "Unavailable", false);
                    obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
                    obj.QuantityAvailable = GetReaderValue_NullableInt32(reader, "QuantityAvailable", null);
                    obj.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null);
                    obj.PODeliveryDate = GetReaderValue_NullableDateTime(reader, "PODeliveryDate", null);
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    obj.CustomerRMADate = GetReaderValue_NullableDateTime(reader, "CustomerRMADate", null);
                    obj.POSerialNo = GetReaderValue_Int16(reader, "POSerialNo", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Stocks", sqlex);
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
        /// Calls [usp_select_Stock]
        /// </summary>
        public override StockDetails Get(System.Int32? stockId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Stock", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@StockId", SqlDbType.Int).Value = stockId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetStockFromReader(reader);
                    StockDetails obj = new StockDetails();



                    obj.StockId = GetReaderValue_Int32(reader, "StockId", 0);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.QualityControlNotes = GetReaderValue_String(reader, "QualityControlNotes", "");
                    obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                    obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
                    obj.QuantityInStock = GetReaderValue_Int32(reader, "QuantityInStock", 0);
                    obj.QuantityOnOrder = GetReaderValue_Int32(reader, "QuantityOnOrder", 0);
                    obj.Location = GetReaderValue_String(reader, "Location", "");
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.ResalePrice = GetReaderValue_NullableDouble(reader, "ResalePrice", null);
                    obj.Unavailable = GetReaderValue_Boolean(reader, "Unavailable", false);
                    obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
                    obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
                    obj.PackageUnit = GetReaderValue_NullableInt32(reader, "PackageUnit", null);
                    obj.StockKeepingUnit = GetReaderValue_NullableInt32(reader, "StockKeepingUnit", null);
                    obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
                    obj.CustomerRMALineNo = GetReaderValue_NullableInt32(reader, "CustomerRMALineNo", null);
                    obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.FullSupplierPart = GetReaderValue_String(reader, "FullSupplierPart", "");
                    obj.CountryOfManufacture = GetReaderValue_NullableInt32(reader, "CountryOfManufacture", null);
                    obj.PartMarkings = GetReaderValue_String(reader, "PartMarkings", "");
                    obj.CountingMethodNo = GetReaderValue_NullableInt32(reader, "CountingMethodNo", null);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.LotName = GetReaderValue_String(reader, "LotName", "");
                    obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
                    obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
                    obj.QuantityAvailable = GetReaderValue_NullableInt32(reader, "QuantityAvailable", null);
                    obj.StatusNo = GetReaderValue_NullableInt32(reader, "StatusNo", null);
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.LotCode = GetReaderValue_String(reader, "LotCode", "");
                    obj.Buyer = GetReaderValue_NullableInt32(reader, "Buyer", null);
                    obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
                    obj.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null);
                    obj.GoodsInPrice = GetReaderValue_NullableDouble(reader, "GoodsInPrice", null);
                    obj.GoodsInShipInCost = GetReaderValue_NullableDouble(reader, "GoodsInShipInCost", null);
                    obj.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", null);
                    obj.GoodsInCurrencyNo = GetReaderValue_NullableInt32(reader, "GoodsInCurrencyNo", null);
                    obj.StockDate = GetReaderValue_DateTime(reader, "StockDate", DateTime.MinValue);
                    obj.ROHSStatus = GetReaderValue_String(reader, "ROHSStatus", "");
                    obj.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", "");
                    obj.PurchasePrice = GetReaderValue_NullableDouble(reader, "PurchasePrice", null);
                    obj.CountingMethodDescription = GetReaderValue_String(reader, "CountingMethodDescription", "");
                    obj.StockLogDetail = GetReaderValue_String(reader, "StockLogDetail", "");
                    obj.StockLogChangeNotes = GetReaderValue_String(reader, "StockLogChangeNotes", "");
                    obj.StockLogReasonNo = GetReaderValue_NullableInt32(reader, "StockLogReasonNo", null);
                    obj.UpdateShipments = GetReaderValue_NullableBoolean(reader, "UpdateShipments", null);
                    obj.StockStartDate = GetReaderValue_String(reader, "StockStartDate", "");
                    //[005] code start
                    obj.OriginalLandedCost = GetReaderValue_NullableDouble(reader, "OriginalLandedCost", null);
                    obj.FirstStockProvisionDate = GetReaderValue_NullableDateTime(reader, "FirstStockProvisionDate", null);
                    obj.LastStockProvisionDate = GetReaderValue_NullableDateTime(reader, "LastStockProvisionDate", null);
                    obj.ManualStockSplitDate = GetReaderValue_NullableDateTime(reader, "ManualStockSplitDate", null);
                    obj.IsManual = GetReaderValue_NullableBoolean(reader, "IsManual", false);
                    //[005] code end
                    //[006] code start
                    obj.DivisionNo = GetReaderValue_NullableInt32(reader, "DivisionNo", null);
                    obj.DivisionName = GetReaderValue_String(reader, "DivisionName", "");
                    //[006] code end
                    obj.InternalPurchaseOrderNumber = GetReaderValue_Int32(reader, "InternalPurchaseOrderNumber", 0);
                    obj.InternalPurchaseOrderId = GetReaderValue_Int32(reader, "InternalPurchaseOrderId", 0);

                    obj.IPONo = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderNumber", null);
                    obj.IPOSupplier = GetReaderValue_NullableInt32(reader, "IPOSupplier", null);
                    obj.IPOSupplierName = GetReaderValue_String(reader, "IPOSupplierName", "");
                    obj.ClientLandedCost = GetReaderValue_NullableDouble(reader, "ClientLandedCost", null);
                    obj.ClientPurchasePrice = GetReaderValue_NullableDouble(reader, "ClientPurchasePrice", null);
                    obj.SalesOrderNumber = GetReaderValue_Int32(reader, "SalesOrderNo", 0);
                    obj.NPRNo = GetReaderValue_String(reader, "NPRNo", "");
                    obj.CustomerPO = GetReaderValue_String(reader, "CustomerPO", "");

                    obj.CustomerNo = GetReaderValue_NullableInt32(reader, "CustomerNo", null);
                    obj.CustomerName = GetReaderValue_String(reader, "CustomerName", "");
                   // obj.ReqSerialNo = GetReaderValue_NullableBoolean(reader, "ReqSerialNo", false);
                    //[007] code start
                    obj.MSLLevel = GetReaderValue_String(reader, "MSLLevel", "");
                    //[007] code end
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
                throw new Exception("Failed to get Stock", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetForCustomerRMALine 
        /// Calls [usp_select_Stock_for_CustomerRMALine]
        /// </summary>
        public override StockDetails GetForCustomerRMALine(System.Int32? customerRmaLineId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Stock_for_CustomerRMALine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@CustomerRMALineId", SqlDbType.Int).Value = customerRmaLineId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetStockFromReader(reader);
                    StockDetails obj = new StockDetails();
                    obj.StockId = GetReaderValue_Int32(reader, "StockId", 0);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.QualityControlNotes = GetReaderValue_String(reader, "QualityControlNotes", "");
                    obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                    obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
                    obj.QuantityInStock = GetReaderValue_Int32(reader, "QuantityInStock", 0);
                    obj.QuantityOnOrder = GetReaderValue_Int32(reader, "QuantityOnOrder", 0);
                    obj.Location = GetReaderValue_String(reader, "Location", "");
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.ResalePrice = GetReaderValue_NullableDouble(reader, "ResalePrice", null);
                    obj.Unavailable = GetReaderValue_Boolean(reader, "Unavailable", false);
                    obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
                    obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.PackageUnit = GetReaderValue_NullableInt32(reader, "PackageUnit", null);
                    obj.StockKeepingUnit = GetReaderValue_NullableInt32(reader, "StockKeepingUnit", null);
                    obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
                    obj.CustomerRMALineNo = GetReaderValue_NullableInt32(reader, "CustomerRMALineNo", null);
                    obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.FullSupplierPart = GetReaderValue_String(reader, "FullSupplierPart", "");
                    obj.CountryOfManufacture = GetReaderValue_NullableInt32(reader, "CountryOfManufacture", null);
                    obj.PartMarkings = GetReaderValue_String(reader, "PartMarkings", "");
                    obj.CountingMethodNo = GetReaderValue_NullableInt32(reader, "CountingMethodNo", null);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.LotName = GetReaderValue_String(reader, "LotName", "");
                    obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
                    obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
                    obj.QuantityAvailable = GetReaderValue_NullableInt32(reader, "QuantityAvailable", null);
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.LotCode = GetReaderValue_String(reader, "LotCode", "");
                    obj.Buyer = GetReaderValue_NullableInt32(reader, "Buyer", null);
                    obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
                    obj.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null);
                    obj.GoodsInPrice = GetReaderValue_NullableDouble(reader, "GoodsInPrice", null);
                    obj.GoodsInShipInCost = GetReaderValue_NullableDouble(reader, "GoodsInShipInCost", null);
                    obj.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", null);
                    obj.GoodsInCurrencyNo = GetReaderValue_NullableInt32(reader, "GoodsInCurrencyNo", null);
                    obj.StockDate = GetReaderValue_DateTime(reader, "StockDate", DateTime.MinValue);
                    obj.ROHSStatus = GetReaderValue_String(reader, "ROHSStatus", "");
                    obj.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", "");
                    obj.PurchasePrice = GetReaderValue_NullableDouble(reader, "PurchasePrice", null);
                    obj.CountingMethodDescription = GetReaderValue_String(reader, "CountingMethodDescription", "");
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
                throw new Exception("Failed to get Stock", sqlex);
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
        /// Calls [usp_select_Stock_for_Page]
        /// </summary>
        public override StockDetails GetForPage(System.Int32? stockId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Stock_for_Page", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@StockId", SqlDbType.Int).Value = stockId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetStockFromReader(reader);
                    StockDetails obj = new StockDetails();
                    obj.StockId = GetReaderValue_Int32(reader, "StockId", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.IsImageAvailable = GetReaderValue_Boolean(reader, "IsImageAvailable", false);
                    // [002] code start
                    obj.IsPDFAvailable = GetReaderValue_Boolean(reader, "IsPDFAvailable", false);
                    // [002] code end
                    obj.POClientNo = GetReaderValue_Int32(reader, "POClientNo", 0);
                    // [003] code start
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    // [003] code end
                    obj.ClientBaseCurrencyCode = GetReaderValue_String(reader, "ClientBaseCurrencyCode", "");
                    obj.ClientBaseCurrencyID = GetReaderValue_Int32(reader, "ClientBaseCurrencyID", 0);
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
                throw new Exception("Failed to get Stock", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetForPurchaseOrderLine 
        /// Calls [usp_select_Stock_for_PurchaseOrderLine]
        /// </summary>
        public override StockDetails GetForPurchaseOrderLine(System.Int32? purchaseOrderLineId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_Stock_for_PurchaseOrderLine", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@PurchaseOrderLineId", SqlDbType.Int).Value = purchaseOrderLineId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                if (reader.Read())
                {
                    //return GetStockFromReader(reader);
                    StockDetails obj = new StockDetails();
                    obj.StockId = GetReaderValue_Int32(reader, "StockId", 0);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.QualityControlNotes = GetReaderValue_String(reader, "QualityControlNotes", "");
                    obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                    obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
                    obj.QuantityInStock = GetReaderValue_Int32(reader, "QuantityInStock", 0);
                    obj.QuantityOnOrder = GetReaderValue_Int32(reader, "QuantityOnOrder", 0);
                    obj.Location = GetReaderValue_String(reader, "Location", "");
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.ResalePrice = GetReaderValue_NullableDouble(reader, "ResalePrice", null);
                    obj.Unavailable = GetReaderValue_Boolean(reader, "Unavailable", false);
                    obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
                    obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.PackageUnit = GetReaderValue_NullableInt32(reader, "PackageUnit", null);
                    obj.StockKeepingUnit = GetReaderValue_NullableInt32(reader, "StockKeepingUnit", null);
                    obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
                    obj.CustomerRMALineNo = GetReaderValue_NullableInt32(reader, "CustomerRMALineNo", null);
                    obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.FullSupplierPart = GetReaderValue_String(reader, "FullSupplierPart", "");
                    obj.CountryOfManufacture = GetReaderValue_NullableInt32(reader, "CountryOfManufacture", null);
                    obj.PartMarkings = GetReaderValue_String(reader, "PartMarkings", "");
                    obj.CountingMethodNo = GetReaderValue_NullableInt32(reader, "CountingMethodNo", null);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.LotName = GetReaderValue_String(reader, "LotName", "");
                    obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
                    obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
                    obj.QuantityAvailable = GetReaderValue_NullableInt32(reader, "QuantityAvailable", null);
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.LotCode = GetReaderValue_String(reader, "LotCode", "");
                    obj.Buyer = GetReaderValue_NullableInt32(reader, "Buyer", null);
                    obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
                    obj.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null);
                    obj.GoodsInPrice = GetReaderValue_NullableDouble(reader, "GoodsInPrice", null);
                    obj.GoodsInShipInCost = GetReaderValue_NullableDouble(reader, "GoodsInShipInCost", null);
                    obj.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", null);
                    obj.GoodsInCurrencyNo = GetReaderValue_NullableInt32(reader, "GoodsInCurrencyNo", null);
                    obj.StockDate = GetReaderValue_DateTime(reader, "StockDate", DateTime.MinValue);
                    obj.ROHSStatus = GetReaderValue_String(reader, "ROHSStatus", "");
                    obj.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", "");
                    obj.PurchasePrice = GetReaderValue_NullableDouble(reader, "PurchasePrice", null);
                    obj.CountingMethodDescription = GetReaderValue_String(reader, "CountingMethodDescription", "");
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
                throw new Exception("Failed to get Stock", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// GetListForLot 
        /// Calls [usp_selectAll_Stock_for_Lot]
        /// </summary>
        public override List<StockDetails> GetListForLot(System.Int32? lotId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_Stock_for_Lot", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LotId", SqlDbType.Int).Value = lotId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<StockDetails> lst = new List<StockDetails>();
                while (reader.Read())
                {
                    StockDetails obj = new StockDetails();
                    obj.StockId = GetReaderValue_Int32(reader, "StockId", 0);
                    obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null);
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.QualityControlNotes = GetReaderValue_String(reader, "QualityControlNotes", "");
                    obj.PurchaseOrderNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderNo", null);
                    obj.PurchaseOrderLineNo = GetReaderValue_NullableInt32(reader, "PurchaseOrderLineNo", null);
                    obj.QuantityInStock = GetReaderValue_Int32(reader, "QuantityInStock", 0);
                    obj.QuantityOnOrder = GetReaderValue_Int32(reader, "QuantityOnOrder", 0);
                    obj.Location = GetReaderValue_String(reader, "Location", "");
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.ResalePrice = GetReaderValue_NullableDouble(reader, "ResalePrice", null);
                    obj.Unavailable = GetReaderValue_Boolean(reader, "Unavailable", false);
                    obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
                    obj.LandedCost = GetReaderValue_NullableDouble(reader, "LandedCost", null);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.PackageUnit = GetReaderValue_NullableInt32(reader, "PackageUnit", null);
                    obj.StockKeepingUnit = GetReaderValue_NullableInt32(reader, "StockKeepingUnit", null);
                    obj.CustomerRMANo = GetReaderValue_NullableInt32(reader, "CustomerRMANo", null);
                    obj.CustomerRMALineNo = GetReaderValue_NullableInt32(reader, "CustomerRMALineNo", null);
                    obj.GoodsInLineNo = GetReaderValue_NullableInt32(reader, "GoodsInLineNo", null);
                    obj.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null);
                    obj.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue);
                    obj.FullSupplierPart = GetReaderValue_String(reader, "FullSupplierPart", "");
                    obj.CountryOfManufacture = GetReaderValue_NullableInt32(reader, "CountryOfManufacture", null);
                    obj.PartMarkings = GetReaderValue_String(reader, "PartMarkings", "");
                    obj.CountingMethodNo = GetReaderValue_NullableInt32(reader, "CountingMethodNo", null);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.LotName = GetReaderValue_String(reader, "LotName", "");
                    obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
                    obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
                    obj.QuantityAvailable = GetReaderValue_NullableInt32(reader, "QuantityAvailable", null);
                    obj.PurchaseOrderNumber = GetReaderValue_NullableInt32(reader, "PurchaseOrderNumber", null);
                    obj.CustomerRMANumber = GetReaderValue_NullableInt32(reader, "CustomerRMANumber", null);
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.PackageDescription = GetReaderValue_String(reader, "PackageDescription", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ProductDescription = GetReaderValue_String(reader, "ProductDescription", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.LotCode = GetReaderValue_String(reader, "LotCode", "");
                    obj.Buyer = GetReaderValue_NullableInt32(reader, "Buyer", null);
                    obj.BuyerName = GetReaderValue_String(reader, "BuyerName", "");
                    obj.GoodsInNo = GetReaderValue_NullableInt32(reader, "GoodsInNo", null);
                    obj.GoodsInPrice = GetReaderValue_NullableDouble(reader, "GoodsInPrice", null);
                    obj.GoodsInShipInCost = GetReaderValue_NullableDouble(reader, "GoodsInShipInCost", null);
                    obj.GoodsInNumber = GetReaderValue_NullableInt32(reader, "GoodsInNumber", null);
                    obj.GoodsInCurrencyNo = GetReaderValue_NullableInt32(reader, "GoodsInCurrencyNo", null);
                    obj.StockDate = GetReaderValue_DateTime(reader, "StockDate", DateTime.MinValue);
                    obj.ROHSStatus = GetReaderValue_String(reader, "ROHSStatus", "");
                    obj.CountryOfManufactureName = GetReaderValue_String(reader, "CountryOfManufactureName", "");
                    obj.PurchasePrice = GetReaderValue_NullableDouble(reader, "PurchasePrice", null);
                    obj.CountingMethodDescription = GetReaderValue_String(reader, "CountingMethodDescription", "");
                    //[003] code start
                    obj.StockUnallocatedCount = GetReaderValue_Int32(reader, "CountUnallocatedStock", 0);
                    //[003] code end
					lst.Add(obj);
					obj = null;
				}
				return lst;
			} catch (SqlException sqlex) {
				//LogException(sqlex);
				throw new Exception("Failed to get Stocks", sqlex);
			} finally {
				cmd.Dispose();
				cn.Close();
				cn.Dispose();
			}
		}
        /// <summary>
        /// Calls [usp_selectNonZero_Stock_for_Lot]
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns></returns>
        public override List<StockDetails> GetListForNonZeroStockLot(System.Int32? lotId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectNonZero_Stock_for_Lot", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LotId", SqlDbType.Int).Value = lotId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<StockDetails> lst = new List<StockDetails>();
                while (reader.Read())
                {
                    StockDetails obj = new StockDetails();
                    obj.StockId = GetReaderValue_Int32(reader, "StockId", 0);
                    //obj.FullPart = GetReaderValue_String(reader, "FullPart", "");
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null);
                    obj.QuantityInStock = GetReaderValue_Int32(reader, "QuantityInStock", 0);
                    obj.Location = GetReaderValue_String(reader, "Location", "");
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.LotNo = GetReaderValue_NullableInt32(reader, "LotNo", null);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.StockUnallocatedCount = GetReaderValue_Int32(reader, "CountUnallocatedStock", 0);
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Stocks", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
		
		
                 

        /// <summary>
        /// GetListRelatedStock 
        /// Calls [usp_selectAll_Stock_RelatedStock]
        /// </summary>
        public override List<StockDetails> GetListRelatedStock(System.Int32? stockNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_Stock_RelatedStock", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = stockNo;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<StockDetails> lst = new List<StockDetails>();
                while (reader.Read())
                {
                    StockDetails obj = new StockDetails();
                    obj.StockId = GetReaderValue_Int32(reader, "StockId", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.PackageNo = GetReaderValue_NullableInt32(reader, "PackageNo", null);
                    obj.QuantityInStock = GetReaderValue_Int32(reader, "QuantityInStock", 0);
                    obj.QuantityOnOrder = GetReaderValue_Int32(reader, "QuantityOnOrder", 0);
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo", null);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.QuantityAllocated = GetReaderValue_Int32(reader, "QuantityAllocated", 0);
                    obj.QuantityAvailable = GetReaderValue_NullableInt32(reader, "QuantityAvailable", null);
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ManufacturerName = GetReaderValue_String(reader, "ManufacturerName", "");
                    obj.RelationType = GetReaderValue_String(reader, "RelationType", "");
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Stocks", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Source 
        /// Calls [usp_source_Stock]
        /// </summary>
        public override List<StockDetails> Source(System.Int32? clientId, System.String partSearch, bool hasServerLocal)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                if (!hasServerLocal)
                {
                    cn = new SqlConnection(this.GTConnectionString);
                    cmd = new SqlCommand("usp_source_Stock_Without_ClientId", cn);
                }
                else
                {
                    cn = new SqlConnection(this.ConnectionString);
                    cmd = new SqlCommand("usp_source_Stock", cn);
                }


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@PartSearch", SqlDbType.NVarChar).Value = partSearch;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<StockDetails> lst = new List<StockDetails>();
                while (reader.Read())
                {
                    StockDetails obj = new StockDetails();
                    obj.StockId = GetReaderValue_Int32(reader, "StockId", 0);
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.DateCode = GetReaderValue_String(reader, "DateCode", "");
                    obj.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0);
                    obj.QuantityInStock = GetReaderValue_Int32(reader, "QuantityInStock", 0);
                    obj.QuantityOnOrder = GetReaderValue_Int32(reader, "QuantityOnOrder", 0);
                    obj.Location = GetReaderValue_String(reader, "Location", "");
                    obj.ResalePrice = GetReaderValue_NullableDouble(reader, "ResalePrice", null);
                    obj.SupplierPart = GetReaderValue_String(reader, "SupplierPart", "");
                    obj.ROHS = GetReaderValue_NullableByte(reader, "ROHS", null);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.SupplierNo = GetReaderValue_NullableInt32(reader, "SupplierNo", null);
                    obj.SupplierName = GetReaderValue_String(reader, "SupplierName", "");
                    obj.PackageName = GetReaderValue_String(reader, "PackageName", "");
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.ClientName = GetReaderValue_String(reader, "ClientName", "");
                    obj.ClientDataVisibleToOthers = GetReaderValue_NullableBoolean(reader, "ClientDataVisibleToOthers", null);
                    //[004] code start
                    obj.SupplierType = GetReaderValue_String(reader, "SupplierType", "");
                    //[004] code end
                    obj.QuantityAvailable = GetReaderValue_NullableInt32(reader, "QuantityAvailable", null);
                    obj.ClientBaseCurrencyCode = GetReaderValue_String(reader, "ClientBaseCurrencyCode", "");
                    obj.ClientCode = GetReaderValue_String(reader, "ClientCode", "");
                    //obj.QuantityAvailable = GetReaderValue_NullableInt32(reader, "InternalPurchaseOrderId", null);
                    //obj.QuantityAvailable = GetReaderValue_NullableInt32(reader, "ClientCompanyNo", null);
                    //obj.ClientBaseCurrencyCode = GetReaderValue_String(reader, "ClientBaseCurrencyCode", "");

                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Stocks", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update Stock
        /// Calls [usp_update_Stock]
        /// </summary>
        public override bool Update(System.Int32? stockId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? warehouseNo, System.Int32? clientNo, System.String qualityControlNotes, System.Int32? purchaseOrderNo, System.Int32? purchaseOrderLineNo, System.Int32? customerRmaNo, System.Int32? customerRmaLineNo, System.Int32? quantityInStock, System.Int32? quantityOnOrder, System.Int32? productNo, System.Double? resalePrice, System.Boolean? unavailable, System.Int32? lotNo, System.Double? landedCost, System.String supplierPart, System.Byte? rohs, System.Int32? packageUnit, System.Int32? stockKeepingUnit, System.Int32? updatedBy, System.String stockLogDetail, System.String stockLogChangeNotes, System.Int32? stockLogReasonNo, System.String location, System.Int32? countryOfManufacture, System.Boolean? updateShipments, System.String partMarkings, System.Int32? countingMethodNo,System.Int32? divisionNo,System.Boolean? IsUpdateClient , System.String mslLevel)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Stock", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StockId", SqlDbType.Int).Value = stockId;
                cmd.Parameters.Add("@Part", SqlDbType.NVarChar).Value = part;
                cmd.Parameters.Add("@ManufacturerNo", SqlDbType.Int).Value = manufacturerNo;
                cmd.Parameters.Add("@DateCode", SqlDbType.NVarChar).Value = dateCode;
                cmd.Parameters.Add("@PackageNo", SqlDbType.Int).Value = packageNo;
                cmd.Parameters.Add("@WarehouseNo", SqlDbType.Int).Value = warehouseNo;
                cmd.Parameters.Add("@ClientNo", SqlDbType.Int).Value = clientNo;
                cmd.Parameters.Add("@QualityControlNotes", SqlDbType.NVarChar).Value = qualityControlNotes;
                cmd.Parameters.Add("@PurchaseOrderNo", SqlDbType.Int).Value = purchaseOrderNo;
                cmd.Parameters.Add("@PurchaseOrderLineNo", SqlDbType.Int).Value = purchaseOrderLineNo;
                cmd.Parameters.Add("@CustomerRMANo", SqlDbType.Int).Value = customerRmaNo;
                cmd.Parameters.Add("@CustomerRMALineNo", SqlDbType.Int).Value = customerRmaLineNo;
                cmd.Parameters.Add("@QuantityInStock", SqlDbType.Int).Value = quantityInStock;
                cmd.Parameters.Add("@QuantityOnOrder", SqlDbType.Int).Value = quantityOnOrder;
                cmd.Parameters.Add("@ProductNo", SqlDbType.Int).Value = productNo;
                cmd.Parameters.Add("@ResalePrice", SqlDbType.Float).Value = resalePrice;
                cmd.Parameters.Add("@Unavailable", SqlDbType.Bit).Value = unavailable;
                cmd.Parameters.Add("@LotNo", SqlDbType.Int).Value = lotNo;
                cmd.Parameters.Add("@LandedCost", SqlDbType.Float).Value = landedCost;
                cmd.Parameters.Add("@SupplierPart", SqlDbType.NVarChar).Value = supplierPart;
                cmd.Parameters.Add("@ROHS", SqlDbType.TinyInt).Value = rohs;
                cmd.Parameters.Add("@PackageUnit", SqlDbType.Int).Value = packageUnit;
                cmd.Parameters.Add("@StockKeepingUnit", SqlDbType.Int).Value = stockKeepingUnit;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@StockLogDetail", SqlDbType.NVarChar).Value = stockLogDetail;
                cmd.Parameters.Add("@StockLogChangeNotes", SqlDbType.NVarChar).Value = stockLogChangeNotes;
                cmd.Parameters.Add("@StockLogReasonNo", SqlDbType.Int).Value = stockLogReasonNo;
                cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = location;
                cmd.Parameters.Add("@CountryOfManufacture", SqlDbType.Int).Value = countryOfManufacture;
                cmd.Parameters.Add("@UpdateShipments", SqlDbType.Bit).Value = updateShipments;
                cmd.Parameters.Add("@PartMarkings", SqlDbType.NVarChar).Value = partMarkings;
                cmd.Parameters.Add("@CountingMethodNo", SqlDbType.Int).Value = countingMethodNo;
                //[006] code start
                cmd.Parameters.Add("@DivisionNo", SqlDbType.Int).Value = divisionNo;
                //[006] code end
                cmd.Parameters.Add("@UpdateClientLandedCost", SqlDbType.Bit).Value = IsUpdateClient;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                //[007] code start
                cmd.Parameters.Add("@MSLLevel", SqlDbType.NVarChar).Value = mslLevel;
                //[007] code end
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Stock", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update Stock
        /// Calls [usp_update_Stock_Quarantined]
        /// </summary>
        public override bool UpdateQuarantined(System.Int32? stockId, System.Boolean? quarantine, System.String location, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Stock_Quarantined", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StockId", SqlDbType.Int).Value = stockId;
                cmd.Parameters.Add("@Quarantine", SqlDbType.Bit).Value = quarantine;
                cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = location;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Stock", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }


        /// <summary>
        /// Update Stock
        /// Calls [usp_update_Stock_Transfer_Lot]
        /// </summary>
        public override bool UpdateTransferLot(System.Int32? oldNotNo, System.Int32? newLotNo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Stock_Transfer_Lot", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OldNotNo", SqlDbType.Int).Value = oldNotNo;
                cmd.Parameters.Add("@NewLotNo", SqlDbType.Int).Value = newLotNo;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Stock", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        // [002] code start
        /// <summary>
        /// GetPDFListForStock 
        /// Calls [usp_selectAll_PDF_for_Stock]
        /// </summary>
        public override List<PDFDocumentDetails> GetPDFListForStock(System.Int32? StockId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_PDF_for_Stock", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = StockId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<PDFDocumentDetails> lstPDF = new List<PDFDocumentDetails>();
                while (reader.Read())
                {
                    PDFDocumentDetails obj = new PDFDocumentDetails();
                    obj.PDFDocumentId = GetReaderValue_Int32(reader, "StockPDFId", 0);
                    obj.PDFDocumentRefNo = GetReaderValue_Int32(reader, "StockNo", 0);
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
                throw new Exception("Failed to get PDF list for stock", sqlex);
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
        /// Calls [usp_insert_StockPDF]
        /// </summary>
        public override Int32 Insert(System.Int32? StockId, System.String Caption, System.String FileName, System.Int32? UpdatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_StockPDF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StockNo", SqlDbType.Int).Value = StockId;
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
                throw new Exception("Failed to insert stock pdf", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        /// <summary>
        /// Delete stock pdf
        /// Calls[usp_delete_StockPDF]
        /// </summary>
        public override bool DeleteStockPDF(System.Int32? StockPdfId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_delete_StockPDF", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StockPDFId", SqlDbType.Int).Value = StockPdfId;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to delete stock pdf", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        // [002] code end

        //[005] code start
        /// <summary>
        /// Update Stock
        /// Calls [usp_update_Stock_Provision]
        /// </summary>
        public override bool UpdateStockProvision(System.Int32? stockId, System.Double? newLandedCost, System.Int32? updatedBy, System.Int32? percentageValue)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Stock_Provision", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StockId", SqlDbType.Int).Value = stockId;
                cmd.Parameters.Add("@NewLandedCost", SqlDbType.Float).Value = newLandedCost;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@PercentageValue", SqlDbType.Int).Value = percentageValue;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update Stock provision", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        //[005] code end


        // [002] code end

        /// <summary>
        /// Update Stock
        /// Calls [usp_update_Stock_Hub_LandedCost]
        /// </summary>
        public override bool UpdateHubLandedCost(System.Int32? stockId, System.Double? newLandedCost, System.Double? resalePrice, System.Int32? updatedBy)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_update_Stock_Hub_LandedCost", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StockId", SqlDbType.Int).Value = stockId;
                cmd.Parameters.Add("@LandedCost", SqlDbType.Float).Value = newLandedCost;
                cmd.Parameters.Add("@ResalePrice", SqlDbType.Float).Value = resalePrice;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = updatedBy;
                cmd.Parameters.Add("@RowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret > 0);
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to update hub landed cost", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        #region Lost stock provision start
        /// <summary>
        /// Calls usp_selectAll_LotStockProvision
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns></returns>
        public override List<StockDetails> GetListStockProvision(System.Int32? lotId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_selectAll_LotStockProvision", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@LotId", SqlDbType.Int).Value = lotId;
                cn.Open();
                DbDataReader reader = ExecuteReader(cmd);
                List<StockDetails> lst = new List<StockDetails>();
                while (reader.Read())
                {
                    StockDetails obj = new StockDetails();
                    obj.StockId = GetReaderValue_Int32(reader, "StockId", 0);                    
                    obj.Part = GetReaderValue_String(reader, "Part", "");
                    obj.ManufacturerNo = GetReaderValue_NullableInt32(reader, "ManufacturerNo", null);
                    obj.WarehouseNo = GetReaderValue_NullableInt32(reader, "WarehouseNo", null);
                    obj.WarehouseName = GetReaderValue_String(reader, "WarehouseName", "");
                    obj.QuantityInStock = GetReaderValue_Int32(reader, "QuantityInStock", 0);
                    obj.ROHS = GetReaderValue_Byte(reader, "ROHS", (byte)0);
                    obj.ManufacturerCode = GetReaderValue_String(reader, "ManufacturerCode", "");
                    obj.Location = GetReaderValue_String(reader, "Location", "");
                    obj.ProductNo = GetReaderValue_NullableInt32(reader, "ProductNo",0);
                    obj.ProductName = GetReaderValue_String(reader, "ProductName", "");
                    obj.OriginalLandedCost =(double?) GetReaderValue_NullableDecimal(reader, "OriginalLandedCost", null);
                    obj.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", "");
                    obj.ClientBaseCurrencyCode = GetReaderValue_String(reader, "ClientCurrency", "");
                    obj.CurrentLandedCost = GetReaderValue_NullableDouble(reader, "CurrentLandedCost", null);
                    obj.CurrencyId = GetReaderValue_Int32(reader, "CurrencyNo",1);
                        
                    lst.Add(obj);
                    obj = null;
                }
                return lst;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to get Stocks", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        /// <summary>
        /// Insert Stock details against the lot id
        /// </summary>
        /// usp_insert_LotStockDetails
        /// <param name="LotId">LotId</param>
        /// <param name="Percentage"> Percentage</param>
        /// <param name="UpdatedBy">Inserted by</param>
        /// <returns></returns>
        public override Int32 InserLotStock(System.Int32? LotId, System.Double? Percentage, System.Int32? UpdatedBy, Double? TotalPrimaryLandedCost, Double? TotalCurrentLandedCost)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_insert_LotStockDetails", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@LotId", SqlDbType.Int).Value = LotId;
                cmd.Parameters.Add("@Percentage", SqlDbType.Decimal).Value = Percentage;                
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.Int).Value = UpdatedBy;
                cmd.Parameters.Add("@TotalPrimaryLandedCost", SqlDbType.Decimal).Value = TotalPrimaryLandedCost;
                cmd.Parameters.Add("@TotalCurrentLandedCost", SqlDbType.Decimal).Value = TotalCurrentLandedCost;
                cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (Int32)cmd.Parameters["@NewId"].Value;
            }
            catch (SqlException sqlex)
            {
                //LogException(sqlex);
                throw new Exception("Failed to insert stock againest Lot", sqlex);
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
        #endregion

        public override List<GoodsInLineDetails> GetSerial(System.Int32? stockId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            try
            {
                cn = new SqlConnection(this.ConnectionString);
                cmd = new SqlCommand("usp_select_SerialNoByStock", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@StockId", SqlDbType.Int).Value = stockId;
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
    }
}
