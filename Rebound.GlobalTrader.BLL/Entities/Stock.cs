/* Marker     changed by      date         Remarks
 [001]      Vikas kumar     17/11/2011  ESMS Ref:23 - PO No. and Crma No. should also be displayed 
 [002]      Vinay           07/05/2012   This need to upload pdf document for stock section
 [003]      Vinay           01/08/2012   Delete UnAllocated Stock Bug
 [004]      Vinay           15/10/2012   Display company type in stock grid
 [005]      Vinay           08/04/2014   CR:- Stock Provision
 [006]      Vinay           30/07/2015   ESMS Ticket No : 255
 */

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
using Rebound.GlobalTrader.DAL;
using Rebound.GlobalTrader.BLL;

namespace Rebound.GlobalTrader.BLL {
		public partial class Stock : BizObject {
		
		#region Properties

		protected static DAL.StockElement Settings {
			get { return Globals.Settings.Stocks; }
		}

		/// <summary>
		/// StockId
		/// </summary>
		public System.Int32 StockId { get; set; }		
		/// <summary>
		/// FullPart
		/// </summary>
		public System.String FullPart { get; set; }		
		/// <summary>
		/// Part
		/// </summary>
		public System.String Part { get; set; }		
		/// <summary>
		/// ManufacturerNo
		/// </summary>
		public System.Int32? ManufacturerNo { get; set; }		
		/// <summary>
		/// DateCode
		/// </summary>
		public System.String DateCode { get; set; }		
		/// <summary>
		/// PackageNo
		/// </summary>
		public System.Int32? PackageNo { get; set; }		
		/// <summary>
		/// WarehouseNo
		/// </summary>
		public System.Int32? WarehouseNo { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// QualityControlNotes
		/// </summary>
		public System.String QualityControlNotes { get; set; }		
		/// <summary>
		/// PurchaseOrderNo
		/// </summary>
		public System.Int32? PurchaseOrderNo { get; set; }		
		/// <summary>
		/// PurchaseOrderLineNo
		/// </summary>
		public System.Int32? PurchaseOrderLineNo { get; set; }		
		/// <summary>
		/// QuantityInStock
		/// </summary>
		public System.Int32 QuantityInStock { get; set; }		
		/// <summary>
		/// QuantityOnOrder
		/// </summary>
		public System.Int32 QuantityOnOrder { get; set; }		
		/// <summary>
		/// Location
		/// </summary>
		public System.String Location { get; set; }		
		/// <summary>
		/// ProductNo
		/// </summary>
		public System.Int32? ProductNo { get; set; }		
		/// <summary>
		/// ResalePrice
		/// </summary>
		public System.Double? ResalePrice { get; set; }		
		/// <summary>
		/// Unavailable
		/// </summary>
		public System.Boolean Unavailable { get; set; }		
		/// <summary>
		/// LotNo
		/// </summary>
		public System.Int32? LotNo { get; set; }		
		/// <summary>
		/// LandedCost
		/// </summary>
		public System.Double? LandedCost { get; set; }		
		/// <summary>
		/// SupplierPart
		/// </summary>
		public System.String SupplierPart { get; set; }		
		/// <summary>
		/// ROHS
		/// </summary>
		public System.Byte? ROHS { get; set; }		
		/// <summary>
		/// PackageUnit
		/// </summary>
		public System.Int32? PackageUnit { get; set; }		
		/// <summary>
		/// StockKeepingUnit
		/// </summary>
		public System.Int32? StockKeepingUnit { get; set; }		
		/// <summary>
		/// CustomerRMANo
		/// </summary>
		public System.Int32? CustomerRMANo { get; set; }		
		/// <summary>
		/// CustomerRMALineNo
		/// </summary>
		public System.Int32? CustomerRMALineNo { get; set; }		
		/// <summary>
		/// GoodsInLineNo
		/// </summary>
		public System.Int32? GoodsInLineNo { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// FullSupplierPart
		/// </summary>
		public System.String FullSupplierPart { get; set; }		
		/// <summary>
		/// CountryOfManufacture
		/// </summary>
		public System.Int32? CountryOfManufacture { get; set; }		
		/// <summary>
		/// PartMarkings
		/// </summary>
		public System.String PartMarkings { get; set; }		
		/// <summary>
		/// CountingMethodNo
		/// </summary>
		public System.Int32? CountingMethodNo { get; set; }		
		/// <summary>
		/// ManufacturerCode
		/// </summary>
		public System.String ManufacturerCode { get; set; }		
		/// <summary>
		/// QuantityAllocated
		/// </summary>
		public System.Int32 QuantityAllocated { get; set; }		
		/// <summary>
		/// WarehouseName
		/// </summary>
		public System.String WarehouseName { get; set; }		
		/// <summary>
		/// LotName
		/// </summary>
		public System.String LotName { get; set; }		
		/// <summary>
		/// SupplierNo
		/// </summary>
		public System.Int32? SupplierNo { get; set; }		
		/// <summary>
		/// SupplierName
		/// </summary>
		public System.String SupplierName { get; set; }		
		/// <summary>
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }		
		/// <summary>
		/// QuantityAvailable
		/// </summary>
		public System.Int32? QuantityAvailable { get; set; }		
		/// <summary>
		/// StatusNo
		/// </summary>
		public System.Int32? StatusNo { get; set; }		
		/// <summary>
		/// RowCnt
		/// </summary>
		public System.Int32? RowCnt { get; set; }		
		/// <summary>
		/// PODeliveryDate
		/// </summary>
		public System.DateTime? PODeliveryDate { get; set; }		
		/// <summary>
		/// PurchaseOrderNumber
		/// </summary>
		public System.Int32? PurchaseOrderNumber { get; set; }		
		/// <summary>
		/// CustomerRMANumber
		/// </summary>
		public System.Int32? CustomerRMANumber { get; set; }		
		/// <summary>
		/// CustomerRMADate
		/// </summary>
		public System.DateTime? CustomerRMADate { get; set; }		
		/// <summary>
		/// PackageName
		/// </summary>
		public System.String PackageName { get; set; }		
		/// <summary>
		/// PackageDescription
		/// </summary>
		public System.String PackageDescription { get; set; }		
		/// <summary>
		/// ProductName
		/// </summary>
		public System.String ProductName { get; set; }		
		/// <summary>
		/// ProductDescription
		/// </summary>
		public System.String ProductDescription { get; set; }		
		/// <summary>
		/// ManufacturerName
		/// </summary>
		public System.String ManufacturerName { get; set; }		
		/// <summary>
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }
        /// <summary>
        /// BaseCurrency of stock related client
        /// </summary>
        public System.String ClientBaseCurrencyCode { get; set; }
		/// <summary>
		/// LotCode
		/// </summary>
		public System.String LotCode { get; set; }		
		/// <summary>
		/// Buyer
		/// </summary>
		public System.Int32? Buyer { get; set; }		
		/// <summary>
		/// BuyerName
		/// </summary>
		public System.String BuyerName { get; set; }		
		/// <summary>
		/// GoodsInNo
		/// </summary>
		public System.Int32? GoodsInNo { get; set; }		
		/// <summary>
		/// GoodsInPrice
		/// </summary>
		public System.Double? GoodsInPrice { get; set; }		
		/// <summary>
		/// GoodsInShipInCost
		/// </summary>
		public System.Double? GoodsInShipInCost { get; set; }		
		/// <summary>
		/// GoodsInNumber
		/// </summary>
		public System.Int32? GoodsInNumber { get; set; }		
		/// <summary>
		/// GoodsInCurrencyNo
		/// </summary>
		public System.Int32? GoodsInCurrencyNo { get; set; }		
		/// <summary>
		/// StockDate
		/// </summary>
		public System.DateTime StockDate { get; set; }		
		/// <summary>
		/// ROHSStatus
		/// </summary>
		public System.String ROHSStatus { get; set; }		
		/// <summary>
		/// CountryOfManufactureName
		/// </summary>
		public System.String CountryOfManufactureName { get; set; }		
		/// <summary>
		/// PurchasePrice
		/// </summary>
		public System.Double? PurchasePrice { get; set; }		
		/// <summary>
		/// CountingMethodDescription
		/// </summary>
		public System.String CountingMethodDescription { get; set; }		
		/// <summary>
		/// StockLogDetail
		/// </summary>
		public System.String StockLogDetail { get; set; }		
		/// <summary>
		/// StockLogChangeNotes
		/// </summary>
		public System.String StockLogChangeNotes { get; set; }		
		/// <summary>
		/// StockLogReasonNo
		/// </summary>
		public System.Int32? StockLogReasonNo { get; set; }		
		/// <summary>
		/// UpdateShipments
		/// </summary>
		public System.Boolean? UpdateShipments { get; set; }		
		/// <summary>
		/// RelationType
		/// </summary>
		public System.String RelationType { get; set; }		
		/// <summary>
		/// ClientName
		/// </summary>
		public System.String ClientName { get; set; }		
		/// <summary>
		/// ClientDataVisibleToOthers
		/// </summary>
		public System.Boolean? ClientDataVisibleToOthers { get; set; }

        /// <summary>
        /// Is image available
        /// </summary>
        public System.Boolean? IsImageAvailable { get; set; }
        /// <summary>
        /// IsPDFAvailable
        /// [002] code start
        /// </summary>
        public System.Boolean? IsPDFAvailable { get; set; }
        // [002] code end

        ///[003] code start
        /// <summary>
        /// StockUnallocatedCount
        /// </summary>
        public System.Int32 StockUnallocatedCount { get; set; }
        //[003] code end

        //[004] code start
        public System.String SupplierType { get; set; }
        //[004] code end

        //[005] code start
        /// <summary>
        /// OriginalLandedCost
        /// </summary>
        public System.Double? OriginalLandedCost { get; set; }
        /// <summary>
        /// ManualStockSplitDate
        /// </summary>
        public System.DateTime? ManualStockSplitDate { get; set; }
        /// <summary>
        /// FirstStockProvisionDate
        /// </summary>
        public System.DateTime? FirstStockProvisionDate { get; set; }
        /// <summary>
        /// LastStockProvisionDate
        /// </summary>
        public System.DateTime? LastStockProvisionDate { get; set; }
        /// <summary>
        /// IsManual
        /// </summary>
        public System.Boolean? IsManual { get; set; }
        //[005] code start

        /// <summary>
        /// Stock Start Date
        /// </summary>
        public System.String StockStartDate { get; set; }

        /// <summary>
        /// LotId
        /// </summary>
        public System.Int32 LotId { get; set; }
        /// <summary>
        /// Current Landed cost.
        /// </summary>
        public System.Double? CurrentLandedCost { get; set; }

        /// <summary>
        /// New Landed cost.
        /// </summary>
        public System.Double? NewLandedCost { get; set; }
        /// <summary>
        /// POSerialNo
        /// </summary>
        public System.Int16? POSerialNo { get; set; }
        /// <summary>
        /// DivisionNo
        /// </summary>
        public System.Int32? DivisionNo { get; set; }
        /// <summary>
        /// DivisionName
        /// </summary>
        public System.String DivisionName { get; set; }

        public int? InternalPurchaseOrderNumber { get; set; }

        public int? InternalPurchaseOrderId { get; set; }  

        public int? IPOSupplier { get; set; }

        public string IPOSupplierName { get; set; } 

         /// <summary>
        /// POClientNo
        /// </summary>
        public System.Int32 ? POClientNo { get; set; }
        /// <summary>
        /// ClientLandedCost
        /// </summary>
        public System.Double? ClientLandedCost { get; set; }		
        /// <summary>
        /// ClientPurchasePrice (from usp_select_Stock)
        /// </summary>
        public System.Double? ClientPurchasePrice { get; set; }
        public int? IPONo { get; set; }
        public System.Boolean? IsClientUpdate { get; set; }
        /// <summary>
        /// ClientCode
        /// </summary>
        public System.String ClientCode { get; set; }
        /// <summary>
       
        public int? SalesOrderNumber { get; set; }
        public System.String NPRNo { get; set; }
        public System.String CustomerPO { get; set; }

        public System.Int32? CustomerNo { get; set; }
        public System.String CustomerName { get; set; }
        public System.Int32? ClientBaseCurrencyID { get; set; }
        public System.String SerialNo { get; set; }
        public System.Int32? SerialNoId { get; set; }
        public System.String SubGroup { get; set; }
        //public System.Boolean? ReqSerialNo { get; set; }
        public System.String MSLLevel { get; set; }
		#endregion

       
        

		#region Methods
		
		/// <summary>
		/// AutoSearch
		/// Calls [usp_autosearch_Stock]
		/// </summary>
		public static List<Stock> AutoSearch(System.Int32? clientId, System.String nameSearch) {
			List<StockDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Stock.AutoSearch(clientId, nameSearch);
			if (lstDetails == null) {
				return new List<Stock>();
			} else {
				List<Stock> lst = new List<Stock>();
				foreach (StockDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Stock obj = new Rebound.GlobalTrader.BLL.Stock();
					obj.StockId = objDetails.StockId;
					obj.Part = objDetails.Part;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_Stock_for_Client]
		/// </summary>
		public static Int32 CountForClient(System.Int32? clientId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Stock.CountForClient(clientId);
		}		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_Stock]
		/// </summary>
        public static List<Stock> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Boolean? quarantine, System.String partSearch, System.Int32? lotNo, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.String supplierPartSearch, System.String supplierNameSearch, System.String locationSearch, System.Int32? warehouseNo, System.Boolean? recentOnly, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.Boolean? includeZeroStock, System.Int32? clientSearch, int? IsPoHub, Boolean IsGlobalLogin)
        {
			List<StockDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Stock.DataListNugget(clientId, orderBy, sortDir, pageIndex, pageSize, quarantine, partSearch, lotNo, purchaseOrderNoLo, purchaseOrderNoHi, supplierPartSearch, supplierNameSearch, locationSearch, warehouseNo, recentOnly, customerRmaNoLo, customerRmaNoHi, includeZeroStock, clientSearch, IsPoHub,IsGlobalLogin);
			if (lstDetails == null) {
				return new List<Stock>();
			} else {
				List<Stock> lst = new List<Stock>();
				foreach (StockDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Stock obj = new Rebound.GlobalTrader.BLL.Stock();
					obj.StockId = objDetails.StockId;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.QuantityInStock = objDetails.QuantityInStock;
					obj.QuantityOnOrder = objDetails.QuantityOnOrder;
					obj.QuantityAllocated = objDetails.QuantityAllocated;
					obj.WarehouseNo = objDetails.WarehouseNo;
					obj.WarehouseName = objDetails.WarehouseName;
					obj.Location = objDetails.Location;
					obj.LotNo = objDetails.LotNo;
					obj.LotName = objDetails.LotName;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.SupplierNo = objDetails.SupplierNo;
					obj.SupplierName = objDetails.SupplierName;
					obj.RowNum = objDetails.RowNum;
					obj.QuantityAvailable = objDetails.QuantityAvailable;
					obj.StatusNo = objDetails.StatusNo;
					obj.RowCnt = objDetails.RowCnt;
                    // [001]Code Start 
                    obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                    obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                    obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                    obj.CustomerRMANo = objDetails.CustomerRMANo;
                    obj.ClientName = objDetails.ClientName;
                    obj.ClientNo = objDetails.ClientNo;
                    // [001]Code End 
                    lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Stock]
		/// </summary>
		public static bool Delete(System.Int32? stockId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Stock.Delete(stockId);
		}
		/// <summary>
		/// DeleteUnallocatedForLot
		/// Calls [usp_delete_Stock_Unallocated_for_Lot]
		/// </summary>
		public static bool DeleteUnallocatedForLot(System.Int32? lotNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Stock.DeleteUnallocatedForLot(lotNo);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Stock]
		/// </summary>
        public static Int32 Insert(System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? warehouseNo, System.Int32? clientNo, System.String qualityControlNotes, System.Int32? purchaseOrderNo, System.Int32? purchaseOrderLineNo, System.Int32? customerRmaNo, System.Int32? customerRmaLineNo, System.Int32? quantityInStock, System.Int32? quantityOnOrder, System.Int32? productNo, System.Double? resalePrice, System.Boolean? unavailable, System.Int32? lotNo, System.Double? landedCost, System.String supplierPart, System.Byte? rohs, System.Int32? packageUnit, System.Int32? stockKeepingUnit, System.String stockLogChangeNotes, System.String location, System.Int32? countryOfManufacture, System.String partMarkings, System.Int32? countingMethodNo, System.Int32? updatedBy, System.Int32? divisionNo, System.String mslLevel)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Stock.Insert(part, manufacturerNo, dateCode, packageNo, warehouseNo, clientNo, qualityControlNotes, purchaseOrderNo, purchaseOrderLineNo, customerRmaNo, customerRmaLineNo, quantityInStock, quantityOnOrder, productNo, resalePrice, unavailable, lotNo, landedCost, supplierPart, rohs, packageUnit, stockKeepingUnit, stockLogChangeNotes, location, countryOfManufacture, partMarkings, countingMethodNo, updatedBy, divisionNo, mslLevel);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Stock]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Stock.Insert(Part, ManufacturerNo, DateCode, PackageNo, WarehouseNo, ClientNo, QualityControlNotes, PurchaseOrderNo, PurchaseOrderLineNo, CustomerRMANo, CustomerRMALineNo, QuantityInStock, QuantityOnOrder, ProductNo, ResalePrice, Unavailable, LotNo, LandedCost, SupplierPart, ROHS, PackageUnit, StockKeepingUnit, StockLogChangeNotes, Location, CountryOfManufacture, PartMarkings, CountingMethodNo, UpdatedBy,DivisionNo, MSLLevel);
		}
		/// <summary>
		/// InsertIdentityOff
		/// Calls [usp_insert_Stock_Identity_Off]
		/// </summary>
		public static Int32 InsertIdentityOff(System.Int32? stockId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? warehouseNo, System.Int32? clientNo, System.String qualityControlNotes, System.Int32? purchaseOrderNo, System.Int32? purchaseOrderLineNo, System.Int32? customerRmaNo, System.Int32? customerRmaLineNo, System.Int32? goodsInLineNo, System.Int32? quantityInStock, System.Int32? quantityOnOrder, System.Int32? productNo, System.Double? resalePrice, System.Boolean? unavailable, System.Int32? lotNo, System.Double? landedCost, System.String supplierPart, System.Byte? rohs, System.Int32? packageUnit, System.Int32? stockKeepingUnit, System.String stockLogChangeNotes, System.String location, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Stock.InsertIdentityOff(stockId, part, manufacturerNo, dateCode, packageNo, warehouseNo, clientNo, qualityControlNotes, purchaseOrderNo, purchaseOrderLineNo, customerRmaNo, customerRmaLineNo, goodsInLineNo, quantityInStock, quantityOnOrder, productNo, resalePrice, unavailable, lotNo, landedCost, supplierPart, rohs, packageUnit, stockKeepingUnit, stockLogChangeNotes, location, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// InsertSplit
		/// Calls [usp_insert_Stock_Split]
		/// </summary>
		public static Int32 InsertSplit(System.Int32? stockId, System.Int32? quantitySplit, System.String location, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Stock.InsertSplit(stockId, quantitySplit, location, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_Stock]
		/// </summary>
		public static List<Stock> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.Boolean? forRmAs, System.Int32? supplierRmaNo, System.Boolean? includeQuarantined, System.Boolean? includeLotsOnHold, System.Int32? poNoLo, System.Int32? poNoHi, System.Int32? crmaNoLo, System.Int32? crmaNoHi, System.Int32? warehouseNo, System.String location,System.Int32? incLockCustNo) {
            List<StockDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Stock.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, partSearch, forRmAs, supplierRmaNo, includeQuarantined, includeLotsOnHold, poNoLo, poNoHi, crmaNoLo, crmaNoHi, warehouseNo, location, incLockCustNo);
			if (lstDetails == null) {
				return new List<Stock>();
			} else {
				List<Stock> lst = new List<Stock>();
				foreach (StockDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Stock obj = new Rebound.GlobalTrader.BLL.Stock();
					obj.ClientNo = objDetails.ClientNo;
					obj.StockId = objDetails.StockId;
					obj.Part = objDetails.Part;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.QuantityInStock = objDetails.QuantityInStock;
					obj.QuantityOnOrder = objDetails.QuantityOnOrder;
					obj.QuantityAvailable = objDetails.QuantityAvailable;
					obj.QuantityAllocated = objDetails.QuantityAllocated;
					obj.LandedCost = objDetails.LandedCost;
					obj.Unavailable = objDetails.Unavailable;
					obj.SupplierName = objDetails.SupplierName;
					obj.PODeliveryDate = objDetails.PODeliveryDate;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.CustomerRMANumber = objDetails.CustomerRMANumber;
					obj.CustomerRMADate = objDetails.CustomerRMADate;
					obj.WarehouseName = objDetails.WarehouseName;
					obj.Location = objDetails.Location;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
                    obj.POSerialNo = objDetails.POSerialNo;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
        /// <summary>
        /// ItemSearch
        /// Calls [usp_itemsearch_IpoStock]
        /// </summary>
        public static List<Stock> IpoItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.Boolean? forRmAs, System.Int32? supplierRmaNo, System.Boolean? includeQuarantined, System.Boolean? includeLotsOnHold, System.Int32? poNoLo, System.Int32? poNoHi, System.Int32? crmaNoLo, System.Int32? crmaNoHi, System.Int32? warehouseNo, System.String location, System.Int32? incLockCustNo, int? salesOrderNo,System.Boolean? stopNONIpoStock)
        {
            List<StockDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Stock.IpoItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, partSearch, forRmAs, supplierRmaNo, includeQuarantined, includeLotsOnHold, poNoLo, poNoHi, crmaNoLo, crmaNoHi, warehouseNo, location, incLockCustNo, salesOrderNo, stopNONIpoStock);
            if (lstDetails == null)
            {
                return new List<Stock>();
            }
            else
            {
                List<Stock> lst = new List<Stock>();
                foreach (StockDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Stock obj = new Rebound.GlobalTrader.BLL.Stock();
                    obj.ClientNo = objDetails.ClientNo;
                    obj.StockId = objDetails.StockId;
                    obj.Part = objDetails.Part;
                    obj.SupplierPart = objDetails.SupplierPart;
                    obj.QuantityInStock = objDetails.QuantityInStock;
                    obj.QuantityOnOrder = objDetails.QuantityOnOrder;
                    obj.QuantityAvailable = objDetails.QuantityAvailable;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.LandedCost = objDetails.LandedCost;
                    obj.Unavailable = objDetails.Unavailable;
                    obj.SupplierName = objDetails.SupplierName;
                    obj.PODeliveryDate = objDetails.PODeliveryDate;
                    obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                    obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                    obj.CustomerRMADate = objDetails.CustomerRMADate;
                    obj.WarehouseName = objDetails.WarehouseName;
                    obj.Location = objDetails.Location;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.POSerialNo = objDetails.POSerialNo;
                    obj.IPONo = objDetails.IPONo;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
		/// <summary>
		/// Get
		/// Calls [usp_select_Stock]
		/// </summary>
		public static Stock Get(System.Int32? stockId) {
			Rebound.GlobalTrader.DAL.StockDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Stock.Get(stockId);
			if (objDetails == null) {
				return null;
			} else {
				Stock obj = new Stock();
				obj.StockId = objDetails.StockId;
				obj.FullPart = objDetails.FullPart;
				obj.Part = objDetails.Part;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.DateCode = objDetails.DateCode;
				obj.PackageNo = objDetails.PackageNo;
				obj.WarehouseNo = objDetails.WarehouseNo;
				obj.ClientNo = objDetails.ClientNo;
				obj.QualityControlNotes = objDetails.QualityControlNotes;
				obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
				obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
				obj.QuantityInStock = objDetails.QuantityInStock;
				obj.QuantityOnOrder = objDetails.QuantityOnOrder;
				obj.Location = objDetails.Location;
				obj.ProductNo = objDetails.ProductNo;
				obj.ResalePrice = objDetails.ResalePrice;
				obj.Unavailable = objDetails.Unavailable;
				obj.LotNo = objDetails.LotNo;
				obj.LandedCost = objDetails.LandedCost;
				obj.SupplierPart = objDetails.SupplierPart;
				obj.ROHS = objDetails.ROHS;
				obj.PackageUnit = objDetails.PackageUnit;
				obj.StockKeepingUnit = objDetails.StockKeepingUnit;
				obj.CustomerRMANo = objDetails.CustomerRMANo;
				obj.CustomerRMALineNo = objDetails.CustomerRMALineNo;
				obj.GoodsInLineNo = objDetails.GoodsInLineNo;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.FullSupplierPart = objDetails.FullSupplierPart;
				obj.CountryOfManufacture = objDetails.CountryOfManufacture;
				obj.PackageName = objDetails.PackageName;
				obj.PackageDescription = objDetails.PackageDescription;
				obj.WarehouseName = objDetails.WarehouseName;
				obj.ProductName = objDetails.ProductName;
				obj.ProductDescription = objDetails.ProductDescription;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.ManufacturerCode = objDetails.ManufacturerCode;
				obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
				obj.CustomerRMANumber = objDetails.CustomerRMANumber;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.SupplierName = objDetails.SupplierName;
				obj.LotName = objDetails.LotName;
				obj.LotCode = objDetails.LotCode;
				obj.SupplierNo = objDetails.SupplierNo;
				obj.Buyer = objDetails.Buyer;
				obj.BuyerName = objDetails.BuyerName;
				obj.QuantityAllocated = objDetails.QuantityAllocated;
				obj.QuantityAvailable = objDetails.QuantityAvailable;
				obj.GoodsInNo = objDetails.GoodsInNo;
				obj.GoodsInPrice = objDetails.GoodsInPrice;
				obj.GoodsInShipInCost = objDetails.GoodsInShipInCost;
				obj.GoodsInNumber = objDetails.GoodsInNumber;
				obj.GoodsInCurrencyNo = objDetails.GoodsInCurrencyNo;
				obj.StockDate = objDetails.StockDate;
				obj.ROHSStatus = objDetails.ROHSStatus;
				obj.CountryOfManufactureName = objDetails.CountryOfManufactureName;
				obj.PurchasePrice = objDetails.PurchasePrice;
				obj.PartMarkings = objDetails.PartMarkings;
				obj.CountingMethodNo = objDetails.CountingMethodNo;
				obj.CountingMethodDescription = objDetails.CountingMethodDescription;
				obj.StatusNo = objDetails.StatusNo;
				obj.StockLogDetail = objDetails.StockLogDetail;
				obj.StockLogChangeNotes = objDetails.StockLogChangeNotes;
				obj.StockLogReasonNo = objDetails.StockLogReasonNo;
				obj.UpdateShipments = objDetails.UpdateShipments;
                obj.StockStartDate = objDetails.StockStartDate;
                obj.OriginalLandedCost = objDetails.OriginalLandedCost;
                obj.FirstStockProvisionDate = objDetails.FirstStockProvisionDate;
                obj.LastStockProvisionDate = objDetails.LastStockProvisionDate;
                obj.ManualStockSplitDate = objDetails.ManualStockSplitDate;
                obj.IsManual = objDetails.IsManual;
                //[006] code start
                obj.DivisionNo = objDetails.DivisionNo;
                obj.DivisionName = objDetails.DivisionName;
                //[006] code end
                obj.IPOSupplier = objDetails.IPOSupplier;
                obj.IPOSupplierName = objDetails.IPOSupplierName;

                obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
                obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
                obj.ClientLandedCost = objDetails.ClientLandedCost;
                obj.ClientPurchasePrice = objDetails.ClientPurchasePrice;
                obj.IPONo=objDetails.IPONo;
                obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                obj.CustomerPO = objDetails.CustomerPO;
                obj.CustomerNo = objDetails.CustomerNo;
                obj.CustomerName = objDetails.CustomerName;
                //obj.ReqSerialNo = objDetails.ReqSerialNo;
                obj.MSLLevel = objDetails.MSLLevel;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForCustomerRMALine
		/// Calls [usp_select_Stock_for_CustomerRMALine]
		/// </summary>
		public static Stock GetForCustomerRMALine(System.Int32? customerRmaLineId) {
			Rebound.GlobalTrader.DAL.StockDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Stock.GetForCustomerRMALine(customerRmaLineId);
			if (objDetails == null) {
				return null;
			} else {
				Stock obj = new Stock();
				obj.StockId = objDetails.StockId;
				obj.FullPart = objDetails.FullPart;
				obj.Part = objDetails.Part;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.DateCode = objDetails.DateCode;
				obj.PackageNo = objDetails.PackageNo;
				obj.WarehouseNo = objDetails.WarehouseNo;
				obj.ClientNo = objDetails.ClientNo;
				obj.QualityControlNotes = objDetails.QualityControlNotes;
				obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
				obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
				obj.QuantityInStock = objDetails.QuantityInStock;
				obj.QuantityOnOrder = objDetails.QuantityOnOrder;
				obj.Location = objDetails.Location;
				obj.ProductNo = objDetails.ProductNo;
				obj.ResalePrice = objDetails.ResalePrice;
				obj.Unavailable = objDetails.Unavailable;
				obj.LotNo = objDetails.LotNo;
				obj.LandedCost = objDetails.LandedCost;
				obj.SupplierPart = objDetails.SupplierPart;
				obj.ROHS = objDetails.ROHS;
				obj.PackageUnit = objDetails.PackageUnit;
				obj.StockKeepingUnit = objDetails.StockKeepingUnit;
				obj.CustomerRMANo = objDetails.CustomerRMANo;
				obj.CustomerRMALineNo = objDetails.CustomerRMALineNo;
				obj.GoodsInLineNo = objDetails.GoodsInLineNo;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.FullSupplierPart = objDetails.FullSupplierPart;
				obj.CountryOfManufacture = objDetails.CountryOfManufacture;
				obj.PackageName = objDetails.PackageName;
				obj.PackageDescription = objDetails.PackageDescription;
				obj.WarehouseName = objDetails.WarehouseName;
				obj.ProductName = objDetails.ProductName;
				obj.ProductDescription = objDetails.ProductDescription;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.ManufacturerCode = objDetails.ManufacturerCode;
				obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
				obj.CustomerRMANumber = objDetails.CustomerRMANumber;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.SupplierName = objDetails.SupplierName;
				obj.LotName = objDetails.LotName;
				obj.LotCode = objDetails.LotCode;
				obj.SupplierNo = objDetails.SupplierNo;
				obj.Buyer = objDetails.Buyer;
				obj.BuyerName = objDetails.BuyerName;
				obj.QuantityAllocated = objDetails.QuantityAllocated;
				obj.QuantityAvailable = objDetails.QuantityAvailable;
				obj.GoodsInNo = objDetails.GoodsInNo;
				obj.GoodsInPrice = objDetails.GoodsInPrice;
				obj.GoodsInShipInCost = objDetails.GoodsInShipInCost;
				obj.GoodsInNumber = objDetails.GoodsInNumber;
				obj.GoodsInCurrencyNo = objDetails.GoodsInCurrencyNo;
				obj.StockDate = objDetails.StockDate;
				obj.ROHSStatus = objDetails.ROHSStatus;
				obj.CountryOfManufactureName = objDetails.CountryOfManufactureName;
				obj.PurchasePrice = objDetails.PurchasePrice;
				obj.PartMarkings = objDetails.PartMarkings;
				obj.CountingMethodNo = objDetails.CountingMethodNo;
				obj.CountingMethodDescription = objDetails.CountingMethodDescription;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_Stock_for_Page]
		/// </summary>
		public static Stock GetForPage(System.Int32? stockId) {
			Rebound.GlobalTrader.DAL.StockDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Stock.GetForPage(stockId);
			if (objDetails == null) {
				return null;
			} else {
				Stock obj = new Stock();
				obj.StockId = objDetails.StockId;
				obj.ClientNo = objDetails.ClientNo;
				obj.Part = objDetails.Part;
                obj.IsImageAvailable = objDetails.IsImageAvailable;
                // [002] code start
                obj.IsPDFAvailable = objDetails.IsPDFAvailable;
                // [002] code end
                obj.POClientNo = objDetails.POClientNo;
                // [003] code start
                obj.ClientName = objDetails.ClientName;
                // [003] code end
                obj.ClientBaseCurrencyCode = objDetails.ClientBaseCurrencyCode;
                obj.ClientBaseCurrencyID = objDetails.ClientBaseCurrencyID;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForPurchaseOrderLine
		/// Calls [usp_select_Stock_for_PurchaseOrderLine]
		/// </summary>
		public static Stock GetForPurchaseOrderLine(System.Int32? purchaseOrderLineId) {
			Rebound.GlobalTrader.DAL.StockDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Stock.GetForPurchaseOrderLine(purchaseOrderLineId);
			if (objDetails == null) {
				return null;
			} else {
				Stock obj = new Stock();
				obj.StockId = objDetails.StockId;
				obj.FullPart = objDetails.FullPart;
				obj.Part = objDetails.Part;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.DateCode = objDetails.DateCode;
				obj.PackageNo = objDetails.PackageNo;
				obj.WarehouseNo = objDetails.WarehouseNo;
				obj.ClientNo = objDetails.ClientNo;
				obj.QualityControlNotes = objDetails.QualityControlNotes;
				obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
				obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
				obj.QuantityInStock = objDetails.QuantityInStock;
				obj.QuantityOnOrder = objDetails.QuantityOnOrder;
				obj.Location = objDetails.Location;
				obj.ProductNo = objDetails.ProductNo;
				obj.ResalePrice = objDetails.ResalePrice;
				obj.Unavailable = objDetails.Unavailable;
				obj.LotNo = objDetails.LotNo;
				obj.LandedCost = objDetails.LandedCost;
				obj.SupplierPart = objDetails.SupplierPart;
				obj.ROHS = objDetails.ROHS;
				obj.PackageUnit = objDetails.PackageUnit;
				obj.StockKeepingUnit = objDetails.StockKeepingUnit;
				obj.CustomerRMANo = objDetails.CustomerRMANo;
				obj.CustomerRMALineNo = objDetails.CustomerRMALineNo;
				obj.GoodsInLineNo = objDetails.GoodsInLineNo;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.FullSupplierPart = objDetails.FullSupplierPart;
				obj.CountryOfManufacture = objDetails.CountryOfManufacture;
				obj.PackageName = objDetails.PackageName;
				obj.PackageDescription = objDetails.PackageDescription;
				obj.WarehouseName = objDetails.WarehouseName;
				obj.ProductName = objDetails.ProductName;
				obj.ProductDescription = objDetails.ProductDescription;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.ManufacturerCode = objDetails.ManufacturerCode;
				obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
				obj.CustomerRMANumber = objDetails.CustomerRMANumber;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.SupplierName = objDetails.SupplierName;
				obj.LotName = objDetails.LotName;
				obj.LotCode = objDetails.LotCode;
				obj.SupplierNo = objDetails.SupplierNo;
				obj.Buyer = objDetails.Buyer;
				obj.BuyerName = objDetails.BuyerName;
				obj.QuantityAllocated = objDetails.QuantityAllocated;
				obj.QuantityAvailable = objDetails.QuantityAvailable;
				obj.GoodsInNo = objDetails.GoodsInNo;
				obj.GoodsInPrice = objDetails.GoodsInPrice;
				obj.GoodsInShipInCost = objDetails.GoodsInShipInCost;
				obj.GoodsInNumber = objDetails.GoodsInNumber;
				obj.GoodsInCurrencyNo = objDetails.GoodsInCurrencyNo;
				obj.StockDate = objDetails.StockDate;
				obj.ROHSStatus = objDetails.ROHSStatus;
				obj.CountryOfManufactureName = objDetails.CountryOfManufactureName;
				obj.PurchasePrice = objDetails.PurchasePrice;
				obj.PartMarkings = objDetails.PartMarkings;
				obj.CountingMethodNo = objDetails.CountingMethodNo;
				obj.CountingMethodDescription = objDetails.CountingMethodDescription;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForLot
		/// Calls [usp_selectAll_Stock_for_Lot]
		/// </summary>
		public static List<Stock> GetListForLot(System.Int32? lotId) {
			List<StockDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Stock.GetListForLot(lotId);
			if (lstDetails == null) {
				return new List<Stock>();
			} else {
				List<Stock> lst = new List<Stock>();
				foreach (StockDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Stock obj = new Rebound.GlobalTrader.BLL.Stock();
					obj.StockId = objDetails.StockId;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.DateCode = objDetails.DateCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.WarehouseNo = objDetails.WarehouseNo;
					obj.ClientNo = objDetails.ClientNo;
					obj.QualityControlNotes = objDetails.QualityControlNotes;
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.QuantityInStock = objDetails.QuantityInStock;
					obj.QuantityOnOrder = objDetails.QuantityOnOrder;
					obj.Location = objDetails.Location;
					obj.ProductNo = objDetails.ProductNo;
					obj.ResalePrice = objDetails.ResalePrice;
					obj.Unavailable = objDetails.Unavailable;
					obj.LotNo = objDetails.LotNo;
					obj.LandedCost = objDetails.LandedCost;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.ROHS = objDetails.ROHS;
					obj.PackageUnit = objDetails.PackageUnit;
					obj.StockKeepingUnit = objDetails.StockKeepingUnit;
					obj.CustomerRMANo = objDetails.CustomerRMANo;
					obj.CustomerRMALineNo = objDetails.CustomerRMALineNo;
					obj.GoodsInLineNo = objDetails.GoodsInLineNo;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.FullSupplierPart = objDetails.FullSupplierPart;
					obj.CountryOfManufacture = objDetails.CountryOfManufacture;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.WarehouseName = objDetails.WarehouseName;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.CustomerRMANumber = objDetails.CustomerRMANumber;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.SupplierName = objDetails.SupplierName;
					obj.LotName = objDetails.LotName;
					obj.LotCode = objDetails.LotCode;
					obj.SupplierNo = objDetails.SupplierNo;
					obj.Buyer = objDetails.Buyer;
					obj.BuyerName = objDetails.BuyerName;
					obj.QuantityAllocated = objDetails.QuantityAllocated;
					obj.QuantityAvailable = objDetails.QuantityAvailable;
					obj.GoodsInNo = objDetails.GoodsInNo;
					obj.GoodsInPrice = objDetails.GoodsInPrice;
					obj.GoodsInShipInCost = objDetails.GoodsInShipInCost;
					obj.GoodsInNumber = objDetails.GoodsInNumber;
					obj.GoodsInCurrencyNo = objDetails.GoodsInCurrencyNo;
					obj.StockDate = objDetails.StockDate;
					obj.ROHSStatus = objDetails.ROHSStatus;
					obj.CountryOfManufactureName = objDetails.CountryOfManufactureName;
					obj.PurchasePrice = objDetails.PurchasePrice;
					obj.PartMarkings = objDetails.PartMarkings;
					obj.CountingMethodNo = objDetails.CountingMethodNo;
					obj.CountingMethodDescription = objDetails.CountingMethodDescription;
                    //[003] code start
                    obj.StockUnallocatedCount = objDetails.StockUnallocatedCount;
                    //[003] code end
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        public static List<Stock> GetListForNonZeroStockLot(System.Int32? lotId)
        {
            List<StockDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Stock.GetListForNonZeroStockLot(lotId);
            if (lstDetails == null)
            {
                return new List<Stock>();
            }
            else
            {
                List<Stock> lst = new List<Stock>();
                foreach (StockDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Stock obj = new Rebound.GlobalTrader.BLL.Stock();
                    obj.StockId = objDetails.StockId;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.WarehouseNo = objDetails.WarehouseNo;
                    obj.WarehouseName = objDetails.WarehouseName;
                    obj.QuantityInStock = objDetails.QuantityInStock;
                    obj.Location = objDetails.Location;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.ROHS = objDetails.ROHS;
                    obj.ProductName = objDetails.ProductName;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.StockUnallocatedCount = objDetails.StockUnallocatedCount;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
		/// <summary>
		/// GetListRelatedStock
		/// Calls [usp_selectAll_Stock_RelatedStock]
		/// </summary>
		public static List<Stock> GetListRelatedStock(System.Int32? stockNo) {
			List<StockDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Stock.GetListRelatedStock(stockNo);
			if (lstDetails == null) {
				return new List<Stock>();
			} else {
				List<Stock> lst = new List<Stock>();
				foreach (StockDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Stock obj = new Rebound.GlobalTrader.BLL.Stock();
					obj.StockId = objDetails.StockId;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ProductNo = objDetails.ProductNo;
					obj.ProductName = objDetails.ProductName;
					obj.PackageNo = objDetails.PackageNo;
					obj.PackageName = objDetails.PackageName;
					obj.QuantityAllocated = objDetails.QuantityAllocated;
					obj.QuantityAvailable = objDetails.QuantityAvailable;
					obj.QuantityInStock = objDetails.QuantityInStock;
					obj.QuantityOnOrder = objDetails.QuantityOnOrder;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.RelationType = objDetails.RelationType;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Source
		/// Calls [usp_source_Stock]
		/// </summary>
        public static List<Stock> Source(System.Int32? clientId, System.String partSearch, bool IsServerLocal)
        {
            List<StockDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Stock.Source(clientId, partSearch, IsServerLocal);
			if (lstDetails == null) {
				return new List<Stock>();
			} else {
				List<Stock> lst = new List<Stock>();
				foreach (StockDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Stock obj = new Rebound.GlobalTrader.BLL.Stock();
					obj.StockId = objDetails.StockId;
					obj.QuantityInStock = objDetails.QuantityInStock;
					obj.QuantityOnOrder = objDetails.QuantityOnOrder;
					obj.Part = objDetails.Part;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ProductName = objDetails.ProductName;
					obj.DateCode = objDetails.DateCode;
					obj.SupplierNo = objDetails.SupplierNo;
					obj.SupplierName = objDetails.SupplierName;
					obj.ResalePrice = objDetails.ResalePrice;
					obj.ROHS = objDetails.ROHS;
					obj.WarehouseName = objDetails.WarehouseName;
					obj.Location = objDetails.Location;
					obj.PackageName = objDetails.PackageName;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.ClientNo = objDetails.ClientNo;
					obj.ClientName = objDetails.ClientName;
					obj.ClientDataVisibleToOthers = objDetails.ClientDataVisibleToOthers;
                    //[004] code start
                    obj.SupplierType = objDetails.SupplierType;
                    //[004] code end
                    obj.QuantityAvailable = objDetails.QuantityAvailable;
                    obj.ClientBaseCurrencyCode = objDetails.ClientBaseCurrencyCode;
                    obj.ClientCode = objDetails.ClientCode; 
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;                
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_Stock]
		/// </summary>
        public static bool Update(System.Int32? stockId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? warehouseNo, System.Int32? clientNo, System.String qualityControlNotes, System.Int32? purchaseOrderNo, System.Int32? purchaseOrderLineNo, System.Int32? customerRmaNo, System.Int32? customerRmaLineNo, System.Int32? quantityInStock, System.Int32? quantityOnOrder, System.Int32? productNo, System.Double? resalePrice, System.Boolean? unavailable, System.Int32? lotNo, System.Double? landedCost, System.String supplierPart, System.Byte? rohs, System.Int32? packageUnit, System.Int32? stockKeepingUnit, System.Int32? updatedBy, System.String stockLogDetail, System.String stockLogChangeNotes, System.Int32? stockLogReasonNo, System.String location, System.Int32? countryOfManufacture, System.Boolean? updateShipments, System.String partMarkings, System.Int32? countingMethodNo, System.Int32? divisionNo, System.Boolean? isClientUpdate, System.String mslLevel)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Stock.Update(stockId, part, manufacturerNo, dateCode, packageNo, warehouseNo, clientNo, qualityControlNotes, purchaseOrderNo, purchaseOrderLineNo, customerRmaNo, customerRmaLineNo, quantityInStock, quantityOnOrder, productNo, resalePrice, unavailable, lotNo, landedCost, supplierPart, rohs, packageUnit, stockKeepingUnit, updatedBy, stockLogDetail, stockLogChangeNotes, stockLogReasonNo, location, countryOfManufacture, updateShipments, partMarkings, countingMethodNo, divisionNo, isClientUpdate, mslLevel);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Stock]
		/// </summary>
		public bool Update() {
            return Rebound.GlobalTrader.DAL.SiteProvider.Stock.Update(StockId, Part, ManufacturerNo, DateCode, PackageNo, WarehouseNo, ClientNo, QualityControlNotes, PurchaseOrderNo, PurchaseOrderLineNo, CustomerRMANo, CustomerRMALineNo, QuantityInStock, QuantityOnOrder, ProductNo, ResalePrice, Unavailable, LotNo, LandedCost, SupplierPart, ROHS, PackageUnit, StockKeepingUnit, UpdatedBy, StockLogDetail, StockLogChangeNotes, StockLogReasonNo, Location, CountryOfManufacture, UpdateShipments, PartMarkings, CountingMethodNo, DivisionNo,IsClientUpdate,MSLLevel);
		}
		/// <summary>
		/// UpdateQuarantined
		/// Calls [usp_update_Stock_Quarantined]
		/// </summary>
		public static bool UpdateQuarantined(System.Int32? stockId, System.Boolean? quarantine, System.String location, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Stock.UpdateQuarantined(stockId, quarantine, location, updatedBy);
		}
		/// <summary>
		/// UpdateTransferLot
		/// Calls [usp_update_Stock_Transfer_Lot]
		/// </summary>
		public static bool UpdateTransferLot(System.Int32? oldNotNo, System.Int32? newLotNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Stock.UpdateTransferLot(oldNotNo, newLotNo);
		}

        private static Stock PopulateFromDBDetailsObject(StockDetails obj) {
            Stock objNew = new Stock();
			objNew.StockId = obj.StockId;
			objNew.FullPart = obj.FullPart;
			objNew.Part = obj.Part;
			objNew.ManufacturerNo = obj.ManufacturerNo;
			objNew.DateCode = obj.DateCode;
			objNew.PackageNo = obj.PackageNo;
			objNew.WarehouseNo = obj.WarehouseNo;
			objNew.ClientNo = obj.ClientNo;
			objNew.QualityControlNotes = obj.QualityControlNotes;
			objNew.PurchaseOrderNo = obj.PurchaseOrderNo;
			objNew.PurchaseOrderLineNo = obj.PurchaseOrderLineNo;
			objNew.QuantityInStock = obj.QuantityInStock;
			objNew.QuantityOnOrder = obj.QuantityOnOrder;
			objNew.Location = obj.Location;
			objNew.ProductNo = obj.ProductNo;
			objNew.ResalePrice = obj.ResalePrice;
			objNew.Unavailable = obj.Unavailable;
			objNew.LotNo = obj.LotNo;
			objNew.LandedCost = obj.LandedCost;
			objNew.SupplierPart = obj.SupplierPart;
			objNew.ROHS = obj.ROHS;
			objNew.PackageUnit = obj.PackageUnit;
			objNew.StockKeepingUnit = obj.StockKeepingUnit;
			objNew.CustomerRMANo = obj.CustomerRMANo;
			objNew.CustomerRMALineNo = obj.CustomerRMALineNo;
			objNew.GoodsInLineNo = obj.GoodsInLineNo;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.FullSupplierPart = obj.FullSupplierPart;
			objNew.CountryOfManufacture = obj.CountryOfManufacture;
			objNew.PartMarkings = obj.PartMarkings;
			objNew.CountingMethodNo = obj.CountingMethodNo;
			objNew.ManufacturerCode = obj.ManufacturerCode;
			objNew.QuantityAllocated = obj.QuantityAllocated;
			objNew.WarehouseName = obj.WarehouseName;
			objNew.LotName = obj.LotName;
			objNew.SupplierNo = obj.SupplierNo;
			objNew.SupplierName = obj.SupplierName;
			objNew.RowNum = obj.RowNum;
			objNew.QuantityAvailable = obj.QuantityAvailable;
			objNew.StatusNo = obj.StatusNo;
			objNew.RowCnt = obj.RowCnt;
			objNew.PODeliveryDate = obj.PODeliveryDate;
			objNew.PurchaseOrderNumber = obj.PurchaseOrderNumber;
			objNew.CustomerRMANumber = obj.CustomerRMANumber;
			objNew.CustomerRMADate = obj.CustomerRMADate;
			objNew.PackageName = obj.PackageName;
			objNew.PackageDescription = obj.PackageDescription;
			objNew.ProductName = obj.ProductName;
			objNew.ProductDescription = obj.ProductDescription;
			objNew.ManufacturerName = obj.ManufacturerName;
			objNew.CurrencyCode = obj.CurrencyCode;
			objNew.LotCode = obj.LotCode;
			objNew.Buyer = obj.Buyer;
			objNew.BuyerName = obj.BuyerName;
			objNew.GoodsInNo = obj.GoodsInNo;
			objNew.GoodsInPrice = obj.GoodsInPrice;
			objNew.GoodsInShipInCost = obj.GoodsInShipInCost;
			objNew.GoodsInNumber = obj.GoodsInNumber;
			objNew.GoodsInCurrencyNo = obj.GoodsInCurrencyNo;
			objNew.StockDate = obj.StockDate;
			objNew.ROHSStatus = obj.ROHSStatus;
			objNew.CountryOfManufactureName = obj.CountryOfManufactureName;
			objNew.PurchasePrice = obj.PurchasePrice;
			objNew.CountingMethodDescription = obj.CountingMethodDescription;
			objNew.StockLogDetail = obj.StockLogDetail;
			objNew.StockLogChangeNotes = obj.StockLogChangeNotes;
			objNew.StockLogReasonNo = obj.StockLogReasonNo;
			objNew.UpdateShipments = obj.UpdateShipments;
			objNew.RelationType = obj.RelationType;
			objNew.ClientName = obj.ClientName;
			objNew.ClientDataVisibleToOthers = obj.ClientDataVisibleToOthers;
            return objNew;
        }
        // [002] code start
        /// <summary>
        /// GetListForSalesOrder
        /// Calls [usp_selectAll_PDF_for_Stock]
        /// </summary>
        public static List<PDFDocument> GetPDFListForStock(System.Int32? StockId)
        {
            List<PDFDocumentDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Stock.GetPDFListForStock(StockId);
            if (lstDetails == null)
            {
                return new List<PDFDocument>();
            }
            else
            {
                List<PDFDocument> lst = new List<PDFDocument>();
                foreach (PDFDocumentDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.PDFDocument obj = new Rebound.GlobalTrader.BLL.PDFDocument();
                    obj.PDFDocumentId = objDetails.PDFDocumentId;
                    obj.PDFDocumentRefNo = objDetails.PDFDocumentRefNo;
                    obj.Caption = objDetails.Caption;
                    obj.FileName = objDetails.FileName;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Insert
        /// Calls [usp_insert_StockPDF]
        /// </summary>
        public static Int32 Insert(System.Int32? StockId, System.String Caption, System.String FileName, System.Int32? UpdatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Stock.Insert(StockId, Caption, FileName, UpdatedBy);
            return objReturn;
        }
        /// Delete
        /// Calls [usp_delete_StockPDF]
        /// </summary>
        public static bool DeleteStockPDF(System.Int32? StockPdfId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Stock.DeleteStockPDF(StockPdfId);
        }
  
        // [002] code start

        //[005] code start
        /// <summary>
        /// UpdateStockProvision
        /// Calls [usp_update_Stock_Provision]
        /// </summary>
        public static bool UpdateStockProvision(System.Int32? stockId,  System.Double? newLandedCost, System.Int32? updatedBy,System.Int32? percentageValue)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Stock.UpdateStockProvision(stockId, newLandedCost, updatedBy, percentageValue);
        }
        //[005] code end
        public static bool UpdateHubLandedCost(System.Int32? stockId, System.Double? landedCost, System.Double? resalePrice, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Stock.UpdateHubLandedCost(stockId, landedCost, resalePrice, updatedBy);
        }
		#endregion

       #region Lot stock provision start

        /// <summary>
        ///Get list of stock Provision
        /// Calls [uspGetAllLotStockProvision]
        /// </summary>
        public static List<Stock> GetListStockProvision(System.Int32? lotId)
        {
            List<StockDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Stock.GetListStockProvision(lotId);
            if (lstDetails == null)
            {
                return new List<Stock>();
            }
            else
            {
                List<Stock> lst = new List<Stock>();
                foreach (StockDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Stock obj = new Rebound.GlobalTrader.BLL.Stock();
                    obj.StockId = objDetails.StockId;
                    obj.Part = objDetails.Part;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.WarehouseNo = objDetails.WarehouseNo;
                    obj.WarehouseName = objDetails.WarehouseName;
                    obj.QuantityInStock = objDetails.QuantityInStock;
                    obj.Location = objDetails.Location;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.OriginalLandedCost = objDetails.OriginalLandedCost;// Currency.ConvertValueFromBaseCurrency(objDetails.OriginalLandedCost, objDetails.CurrencyId, DateTime.Now);
                    obj.CurrentLandedCost =objDetails.CurrentLandedCost;// Currency.ConvertValueFromBaseCurrency(objDetails.CurrentLandedCost, objDetails.CurrencyId, DateTime.Now);
                    obj.ClientBaseCurrencyCode = objDetails.ClientBaseCurrencyCode;
                    obj.ROHS = objDetails.ROHS;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;

                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        public static Int32 InserLotStock(System.Int32 lotId, double provisionPercentage, System.Int32? UpdatedBy, Double? TotalPrimaryLandedCost, Double? TotalCurrentLandedCost)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Stock.InserLotStock(lotId, provisionPercentage, UpdatedBy, TotalPrimaryLandedCost, TotalCurrentLandedCost);
            return objReturn;
           
 
        }
        
       #endregion

        public static List<Stock> GetSerial(System.Int32? stockId)
        {
            List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Stock.GetSerial(stockId);
            if (lstDetails == null)
            {
                return new List<Stock>();
            }
            else
            {
                List<Stock> lst = new List<Stock>();
                foreach (GoodsInLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Stock obj = new Rebound.GlobalTrader.BLL.Stock();
                    obj.SerialNoId = objDetails.SerialNoId;
                    obj.SerialNo = objDetails.SerialNo;
                    obj.SubGroup = objDetails.SubGroup;
                    obj.GoodsInNo = objDetails.GoodsInNo;

                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        }
}
