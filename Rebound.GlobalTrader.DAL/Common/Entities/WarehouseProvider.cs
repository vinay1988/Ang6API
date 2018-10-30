using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL
{

    public abstract class WarehouseProvider : DataAccess
    {
        static private WarehouseProvider _instance = null;
        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>       
        static public WarehouseProvider Instance
        {
            get
            {
                if (_instance == null) _instance = (WarehouseProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Warehouses.ProviderType));
                return _instance;
            }
        }
        public WarehouseProvider()
        {
            this.ConnectionString = Globals.Settings.Warehouses.ConnectionString;
        }

        #region Method Registrations

        /// <summary>
        /// Delete
        /// Calls [usp_delete_Warehouse]
        /// </summary>
        public abstract bool Delete(System.Int32? warehouseId);
        /// <summary>
        /// DropDownForClient
        /// Calls [usp_dropdown_Warehouse_for_Client]
        /// </summary>
        public abstract List<WarehouseDetails> DropDownForClient(System.Int32? clientId, System.Boolean? includeVirtual);
        /// <summary>
        /// Insert
        /// Calls [usp_insert_Warehouse]
        /// </summary>
        public abstract Int32 Insert(System.Int32? clientNo, System.String warehouseName, System.Int32? addressNo, System.Boolean? virtualWarehouse, System.Int32? updatedBy);
        /// <summary>
        /// Get
        /// Calls [usp_select_Warehouse]
        /// </summary>
        public abstract WarehouseDetails Get(System.Int32? warehouseId);
        /// <summary>
        /// GetDefault
        /// Calls [usp_select_Warehouse_Default]
        /// </summary>
        public abstract WarehouseDetails GetDefault(System.Int32? clientId);
        /// <summary>
        /// GetListForClient
        /// Calls [usp_selectAll_Warehouse_for_Client]
        /// </summary>
        public abstract List<WarehouseDetails> GetListForClient(System.Int32? clientId);
        /// <summary>
        /// Update
        /// Calls [usp_update_Warehouse]
        /// </summary>
        public abstract bool Update(System.Int32? warehouseId, System.Int32? clientNo, System.String warehouseName, System.Int32? addressNo, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? virtualWarehouse);
        /// <summary>
        /// UpdateClearDefaults
        /// Calls [usp_update_Warehouse_ClearDefaults]
        /// </summary>
        public abstract bool UpdateClearDefaults(System.Int32? clientId, System.Int32? updatedBy);
        /// <summary>
        /// UpdateSetDefault
        /// Calls [usp_update_Warehouse_SetDefault]
        /// </summary>
        public abstract bool UpdateSetDefault(System.Int32? warehouseId, System.Int32? clientId, System.Int32? updatedBy);

        #endregion

        /// <summary>
        /// Returns a new WarehouseDetails instance filled with the DataReader's current record data
        /// </summary>        
        protected virtual WarehouseDetails GetWarehouseFromReader(DbDataReader reader)
        {
            WarehouseDetails warehouse = new WarehouseDetails();
            if (reader.HasRows)
            {
                warehouse.WarehouseId = GetReaderValue_Int32(reader, "WarehouseId", 0); //From: [Table]
                warehouse.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
                warehouse.WarehouseName = GetReaderValue_String(reader, "WarehouseName", ""); //From: [Table]
                warehouse.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
                warehouse.AddressNo = GetReaderValue_NullableInt32(reader, "AddressNo", null); //From: [Table]
                warehouse.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
                warehouse.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
                warehouse.VirtualWarehouse = GetReaderValue_Boolean(reader, "VirtualWarehouse", false); //From: [Table]
                warehouse.DefaultWarehouse = GetReaderValue_Boolean(reader, "DefaultWarehouse", false); //From: [Table]
                warehouse.AddressName = GetReaderValue_String(reader, "AddressName", ""); //From: [usp_select_Warehouse]
                warehouse.Line1 = GetReaderValue_String(reader, "Line1", ""); //From: [usp_select_Warehouse]
                warehouse.Line2 = GetReaderValue_String(reader, "Line2", ""); //From: [usp_select_Warehouse]
                warehouse.Line3 = GetReaderValue_String(reader, "Line3", ""); //From: [usp_select_Warehouse]
                warehouse.County = GetReaderValue_String(reader, "County", ""); //From: [usp_select_Warehouse]
                warehouse.City = GetReaderValue_String(reader, "City", ""); //From: [usp_select_Warehouse]
                warehouse.State = GetReaderValue_String(reader, "State", ""); //From: [usp_select_Warehouse]
                warehouse.ZIP = GetReaderValue_String(reader, "ZIP", ""); //From: [usp_select_Warehouse]
                warehouse.CountryName = GetReaderValue_String(reader, "CountryName", ""); //From: [usp_select_Warehouse]
                warehouse.CountryNo = GetReaderValue_NullableInt32(reader, "CountryNo", null); //From: [usp_select_Warehouse]
            }
            return warehouse;
        }

        /// <summary>
        /// Returns a collection of WarehouseDetails objects with the data read from the input DataReader
        /// </summary>                
        protected virtual List<WarehouseDetails> GetWarehouseCollectionFromReader(DbDataReader reader)
        {
            List<WarehouseDetails> warehouses = new List<WarehouseDetails>();
            while (reader.Read()) warehouses.Add(GetWarehouseFromReader(reader));
            return warehouses;
        }

        /// <summary>
        /// Create IPO and PO 
        /// Calls [usp_insert_InternalPurchaseOrder]
        /// </summary>
        public abstract int CreateIPOAndPurchaseOrder(int SalesOrderNo, string SalesOrderLines, int POHubSupplierNo, int ClientNo, int WarehouseNo, int SourceingResultAttachedBy, int? SourceingResultNo, double? EstimatedShippingCost, DateTime? Deliverydate, double? ConvertedEstimatedShippingCost, System.Int32? ClientCurrencyNo, System.Int32? POBuyCurrencyNo, System.Int32 CurrencyNo, System.Int32? LinkMultiCurrencyNo, out int InternalPurchaseOrderNo, out int PurchaseOrderNo, out string SolIdS);

        /// <summary>
        /// To Get Default Warehouse By ClientId
        /// Calls [usp_GetDefaultWarehouseByClientId]
        /// </summary>
        public abstract int GetDefaultWarehouseByClient(int ClientId);

        /// <summary>
        /// To check whether sourcing result exist for so line or not
        ///   /// Calls [usp_IsSoLineExistInSourcingResult]
        /// </summary>
        /// <param name="SoId"></param>
        /// <param name="SolineId"></param>
        /// <returns></returns>
        public abstract int IsSoLineExistInSourcingResult(int? SoId, int? SolineId);
          /// <summary>
        /// To check whether th line exist in IPO Lines
        ///   /// Calls [usp_IsSoLineExistInSourcingResult]
        /// </summary>
        /// <param name="SoId"></param>
        /// <param name="SolineId"></param>
        /// <returns></returns>
        public abstract  int IsIPOExist(int? SoId, int? SolineId);
    }
}