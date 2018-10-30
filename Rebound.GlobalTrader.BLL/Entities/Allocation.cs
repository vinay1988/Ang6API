//Marker     Changed by      Date         Remarks
//[001]      Vinay           30/08/2012   Add purchase order link in srma allocation lines
//[002]      Vinay           31/08/2012   Add sales order link in purchase order allocation lines
//[003]      Vinay           31/08/2012   Add sales order link in CRMA allocation lines
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
		public partial class Allocation : BizObject {
		
		#region Properties

		protected static DAL.AllocationElement Settings {
			get { return Globals.Settings.Allocations; }
		}

		/// <summary>
		/// AllocationId
		/// </summary>
		public System.Int32 AllocationId { get; set; }		
		/// <summary>
		/// StockNo
		/// </summary>
		public System.Int32? StockNo { get; set; }		
		/// <summary>
		/// SalesOrderLineNo
		/// </summary>
		public System.Int32? SalesOrderLineNo { get; set; }		
		/// <summary>
		/// QuantityAllocated
		/// </summary>
		public System.Int32 QuantityAllocated { get; set; }		
		/// <summary>
		/// SupplierRMALineNo
		/// </summary>
		public System.Int32? SupplierRMALineNo { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// SalesmanName
		/// </summary>
		public System.String SalesmanName { get; set; }		
		/// <summary>
		/// SupplierRMANo
		/// </summary>
		public System.Int32? SupplierRMANo { get; set; }		
		/// <summary>
		/// SupplierRMANumber
		/// </summary>
		public System.Int32? SupplierRMANumber { get; set; }		
		/// <summary>
		/// Part
		/// </summary>
		public System.String Part { get; set; }		
		/// <summary>
		/// ProductNo
		/// </summary>
		public System.Int32? ProductNo { get; set; }		
		/// <summary>
		/// ProductName
		/// </summary>
		public System.String ProductName { get; set; }		
		/// <summary>
		/// ProductDescription
		/// </summary>
		public System.String ProductDescription { get; set; }		
		/// <summary>
		/// ManufacturerNo
		/// </summary>
		public System.Int32? ManufacturerNo { get; set; }		
		/// <summary>
		/// ManufacturerCode
		/// </summary>
		public System.String ManufacturerCode { get; set; }		
		/// <summary>
		/// ManufacturerName
		/// </summary>
		public System.String ManufacturerName { get; set; }		
		/// <summary>
		/// PackageNo
		/// </summary>
		public System.Int32? PackageNo { get; set; }		
		/// <summary>
		/// PackageName
		/// </summary>
		public System.String PackageName { get; set; }		
		/// <summary>
		/// PackageDescription
		/// </summary>
		public System.String PackageDescription { get; set; }		
		/// <summary>
		/// DateCode
		/// </summary>
		public System.String DateCode { get; set; }		
		/// <summary>
		/// ROHS
		/// </summary>
		public System.Byte ROHS { get; set; }		
		/// <summary>
		/// LandedCost
		/// </summary>
		public System.Double? LandedCost { get; set; }		
		/// <summary>
		/// QuantityInStock
		/// </summary>
		public System.Int32 QuantityInStock { get; set; }		
		/// <summary>
		/// WarehouseNo
		/// </summary>
		public System.Int32? WarehouseNo { get; set; }		
		/// <summary>
		/// WarehouseName
		/// </summary>
		public System.String WarehouseName { get; set; }		
		/// <summary>
		/// PurchaseOrderNo
		/// </summary>
		public System.Int32? PurchaseOrderNo { get; set; }		
		/// <summary>
		/// PurchaseOrderNumber
		/// </summary>
		public System.Int32? PurchaseOrderNumber { get; set; }		
		/// <summary>
		/// PurchaseOrderLineId
		/// </summary>
		public System.Int32? PurchaseOrderLineId { get; set; }		
		/// <summary>
		/// BuyPrice
		/// </summary>
		public System.Double? BuyPrice { get; set; }		
		/// <summary>
		/// DeliveryDate
		/// </summary>
		public System.DateTime? DeliveryDate { get; set; }		
		/// <summary>
		/// BuyCurrencyNo
		/// </summary>
		public System.Int32? BuyCurrencyNo { get; set; }		
		/// <summary>
		/// BuyCurrencyCode
		/// </summary>
		public System.String BuyCurrencyCode { get; set; }		
		/// <summary>
		/// SupplierCompanyNo
		/// </summary>
		public System.Int32? SupplierCompanyNo { get; set; }		
		/// <summary>
		/// SupplierCompanyName
		/// </summary>
		public System.String SupplierCompanyName { get; set; }		
		/// <summary>
		/// CustomerCompanyNo
		/// </summary>
		public System.Int32? CustomerCompanyNo { get; set; }		
		/// <summary>
		/// CustomerCompanyName
		/// </summary>
		public System.String CustomerCompanyName { get; set; }		
		/// <summary>
		/// Salesman
		/// </summary>
		public System.Int32? Salesman { get; set; }		
		/// <summary>
		/// SalesOrderNo
		/// </summary>
		public System.Int32? SalesOrderNo { get; set; }		
		/// <summary>
		/// SalesOrderNumber
		/// </summary>
		public System.Int32? SalesOrderNumber { get; set; }		
		/// <summary>
		/// CustomerPO
		/// </summary>
		public System.String CustomerPO { get; set; }		
		/// <summary>
		/// SellPrice
		/// </summary>
		public System.Double? SellPrice { get; set; }		
		/// <summary>
		/// SellCurrencyNo
		/// </summary>
		public System.Int32? SellCurrencyNo { get; set; }		
		/// <summary>
		/// SellCurrencyCode
		/// </summary>
		public System.String SellCurrencyCode { get; set; }		
		/// <summary>
		/// DatePromised
		/// </summary>
		public System.DateTime? DatePromised { get; set; }		
		/// <summary>
		/// CustomerPart
		/// </summary>
		public System.String CustomerPart { get; set; }		
		/// <summary>
		/// GoodsInLineNo
		/// </summary>
		public System.Int32? GoodsInLineNo { get; set; }		
		/// <summary>
		/// Shipped
		/// </summary>
		public System.Boolean? Shipped { get; set; }		
		/// <summary>
		/// Location
		/// </summary>
		public System.String Location { get; set; }		
		/// <summary>
		/// SupplierPart
		/// </summary>
		public System.String SupplierPart { get; set; }		
		/// <summary>
		/// CustomerRMALineNo
		/// </summary>
		public System.Int32? CustomerRMALineNo { get; set; }		
		/// <summary>
		/// PurchaseOrderLineNo
		/// </summary>
		public System.Int32? PurchaseOrderLineNo { get; set; }		
		/// <summary>
		/// ReturnDate
		/// </summary>
		public System.DateTime? ReturnDate { get; set; }		
		/// <summary>
		/// SupplierRMADate
		/// </summary>
		public System.DateTime? SupplierRMADate { get; set; }		
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32 CompanyNo { get; set; }		
		/// <summary>
		/// CompanyName
		/// </summary>
		public System.String CompanyName { get; set; }		
		/// <summary>
		/// CurrencyNo
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }		
		/// <summary>
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }		
		/// <summary>
		/// Price
		/// </summary>
		public System.Double? Price { get; set; }		
		/// <summary>
		/// ExpediteDate
		/// </summary>
		public System.DateTime? ExpediteDate { get; set; }		
		/// <summary>
		/// CustomerRMANo
		/// </summary>
		public System.Int32? CustomerRMANo { get; set; }		
		/// <summary>
		/// CustomerRMANumber
		/// </summary>
		public System.Int32? CustomerRMANumber { get; set; }		
		/// <summary>
		/// QuantityOnOrder
		/// </summary>
		public System.Int32? QuantityOnOrder { get; set; }
        /// <summary>
        /// SOSerialNo
        /// </summary>
        public System.Int16? SOSerialNo { get; set; }
        /// <summary>
        /// POSerialNo
        /// </summary>
        public System.Int16? POSerialNo { get; set; }

        public int? InternalPurchaseOrderId { get; set; }

        public int? InternalPurchaseOrderNo { get; set; }

        public int? IPOSupplier { get; set; }

        public string IPOSupplierName { get; set; }
        /// <summary>
        /// ClientLandedCost
        /// </summary>
        public System.Double? ClientLandedCost { get; set; }
        public System.Boolean?  ShipASAP { get; set; }
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Allocation]
		/// </summary>
		public static bool Delete(System.Int32? allocationId, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Allocation.Delete(allocationId, updatedBy);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Allocation]
		/// </summary>
        public static Int32 Insert(System.Int32? stockNo, System.Int32? salesOrderLineNo, System.Int32? quantityAllocated, System.Int32? supplierRmaLineNo, System.Int32? updatedBy, System.Boolean? updateSOIsIPO)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Allocation.Insert(stockNo, salesOrderLineNo, quantityAllocated, supplierRmaLineNo, updatedBy, updateSOIsIPO);
			return objReturn;
		}
        /// <summary>
        /// Insert
        /// Calls [usp_insert_AllocationExt]
        /// </summary>
        public static Int32 InsertNew(System.Int32? stockNo, System.Int32? salesOrderLineNo, System.Int32? quantityAllocated, System.Int32? supplierRmaLineNo, System.Int32? updatedBy,System.Boolean? updateSOIsIPO)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Allocation.InsertNew(stockNo, salesOrderLineNo, quantityAllocated, supplierRmaLineNo, updatedBy, updateSOIsIPO);
            return objReturn;
        }

		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Allocation]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Allocation.Insert(StockNo, SalesOrderLineNo, QuantityAllocated, SupplierRMALineNo, UpdatedBy,false);
		}
        /// <summary>
        /// Insert
        /// Calls [usp_insert_IPOAllocation]
        /// </summary>
        public static Int32 InsertIPO(System.Int32? stockNo, System.Int32? salesOrderLineNo, System.Int32? quantityAllocated, System.Int32? supplierRmaLineNo, System.Int32? updatedBy,System.Boolean? createSONonIPO)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Allocation.InsertIPO(stockNo, salesOrderLineNo, quantityAllocated, supplierRmaLineNo, updatedBy, createSONonIPO);
            return objReturn;
        }
		/// <summary>
		/// Get
		/// Calls [usp_select_Allocation]
		/// </summary>
		public static Allocation Get(System.Int32? allocationId) {
			Rebound.GlobalTrader.DAL.AllocationDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Allocation.Get(allocationId);
			if (objDetails == null) {
				return null;
			} else {
				Allocation obj = new Allocation();
				obj.AllocationId = objDetails.AllocationId;
				obj.StockNo = objDetails.StockNo;
				obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
				obj.QuantityAllocated = objDetails.QuantityAllocated;
				obj.SupplierRMALineNo = objDetails.SupplierRMALineNo;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_Allocation]
		/// </summary>
		public static List<Allocation> GetList() {
			List<AllocationDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Allocation.GetList();
			if (lstDetails == null) {
				return new List<Allocation>();
			} else {
				List<Allocation> lst = new List<Allocation>();
				foreach (AllocationDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Allocation obj = new Rebound.GlobalTrader.BLL.Allocation();
					obj.AllocationId = objDetails.AllocationId;
					obj.StockNo = objDetails.StockNo;
					obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
					obj.QuantityAllocated = objDetails.QuantityAllocated;
					obj.SupplierRMALineNo = objDetails.SupplierRMALineNo;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.SupplierRMANo = objDetails.SupplierRMANo;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.Part = objDetails.Part;
					obj.ProductNo = objDetails.ProductNo;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.PackageNo = objDetails.PackageNo;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.DateCode = objDetails.DateCode;
					obj.ROHS = objDetails.ROHS;
					obj.LandedCost = objDetails.LandedCost;
					obj.QuantityInStock = objDetails.QuantityInStock;
					obj.WarehouseNo = objDetails.WarehouseNo;
					obj.WarehouseName = objDetails.WarehouseName;
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.PurchaseOrderLineId = objDetails.PurchaseOrderLineId;
					obj.BuyPrice = objDetails.BuyPrice;
					obj.DeliveryDate = objDetails.DeliveryDate;
					obj.BuyCurrencyNo = objDetails.BuyCurrencyNo;
					obj.BuyCurrencyCode = objDetails.BuyCurrencyCode;
					obj.SupplierCompanyNo = objDetails.SupplierCompanyNo;
					obj.SupplierCompanyName = objDetails.SupplierCompanyName;
					obj.CustomerCompanyNo = objDetails.CustomerCompanyNo;
					obj.CustomerCompanyName = objDetails.CustomerCompanyName;
					obj.Salesman = objDetails.Salesman;
					obj.SalesOrderNo = objDetails.SalesOrderNo;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.CustomerPO = objDetails.CustomerPO;
					obj.SellPrice = objDetails.SellPrice;
					obj.SellCurrencyNo = objDetails.SellCurrencyNo;
					obj.SellCurrencyCode = objDetails.SellCurrencyCode;
					obj.DatePromised = objDetails.DatePromised;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.GoodsInLineNo = objDetails.GoodsInLineNo;
					obj.Shipped = objDetails.Shipped;
					obj.Location = objDetails.Location;
					obj.SupplierPart = objDetails.SupplierPart;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForCustomerRMALine
		/// Calls [usp_selectAll_Allocation_for_CustomerRMALine]
		/// </summary>
		public static List<Allocation> GetListForCustomerRMALine(System.Int32? customerRmaLineId) {
			List<AllocationDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Allocation.GetListForCustomerRMALine(customerRmaLineId);
			if (lstDetails == null) {
				return new List<Allocation>();
			} else {
				List<Allocation> lst = new List<Allocation>();
				foreach (AllocationDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Allocation obj = new Rebound.GlobalTrader.BLL.Allocation();
					obj.AllocationId = objDetails.AllocationId;
					obj.QuantityAllocated = objDetails.QuantityAllocated;
					obj.CustomerRMALineNo = objDetails.CustomerRMALineNo;
					obj.GoodsInLineNo = objDetails.GoodsInLineNo;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.StockNo = objDetails.StockNo;
					obj.SupplierRMANo = objDetails.SupplierRMANo;
					obj.ReturnDate = objDetails.ReturnDate;
					obj.SalesOrderNo = objDetails.SalesOrderNo;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.CustomerPO = objDetails.CustomerPO;
					obj.DatePromised = objDetails.DatePromised;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.SupplierRMADate = objDetails.SupplierRMADate;
					obj.Salesman = objDetails.Salesman;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.Part = objDetails.Part;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ProductNo = objDetails.ProductNo;
					obj.ProductName = objDetails.ProductName;
					obj.PackageNo = objDetails.PackageNo;
					obj.PackageName = objDetails.PackageName;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.Price = objDetails.Price;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.ROHS = objDetails.ROHS;
                    //[003] code start
                    obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
                    //[003] code end
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForGoodsInLine
		/// Calls [usp_selectAll_Allocation_for_GoodsInLine]
		/// </summary>
		public static List<Allocation> GetListForGoodsInLine(System.Int32? goodsInLineId) {
			List<AllocationDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Allocation.GetListForGoodsInLine(goodsInLineId);
			if (lstDetails == null) {
				return new List<Allocation>();
			} else {
				List<Allocation> lst = new List<Allocation>();
				foreach (AllocationDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Allocation obj = new Rebound.GlobalTrader.BLL.Allocation();
					obj.AllocationId = objDetails.AllocationId;
					obj.QuantityAllocated = objDetails.QuantityAllocated;
					obj.CustomerRMALineNo = objDetails.CustomerRMALineNo;
					obj.GoodsInLineNo = objDetails.GoodsInLineNo;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.StockNo = objDetails.StockNo;
					obj.SupplierRMANo = objDetails.SupplierRMANo;
					obj.ReturnDate = objDetails.ReturnDate;
					obj.SalesOrderNo = objDetails.SalesOrderNo;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.CustomerPO = objDetails.CustomerPO;
					obj.DatePromised = objDetails.DatePromised;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.SupplierRMADate = objDetails.SupplierRMADate;
					obj.Salesman = objDetails.Salesman;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.Part = objDetails.Part;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ProductNo = objDetails.ProductNo;
					obj.ProductName = objDetails.ProductName;
					obj.PackageNo = objDetails.PackageNo;
					obj.PackageName = objDetails.PackageName;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.Price = objDetails.Price;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.ROHS = objDetails.ROHS;
                    obj.POSerialNo = objDetails.POSerialNo;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForPurchaseOrderLine
		/// Calls [usp_selectAll_Allocation_for_PurchaseOrderLine]
		/// </summary>
		public static List<Allocation> GetListForPurchaseOrderLine(System.Int32? purchaseOrderLineId) {
			List<AllocationDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Allocation.GetListForPurchaseOrderLine(purchaseOrderLineId);
			if (lstDetails == null) {
				return new List<Allocation>();
			} else {
				List<Allocation> lst = new List<Allocation>();
				foreach (AllocationDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Allocation obj = new Rebound.GlobalTrader.BLL.Allocation();
					obj.AllocationId = objDetails.AllocationId;
					obj.QuantityAllocated = objDetails.QuantityAllocated;
					obj.CustomerRMALineNo = objDetails.CustomerRMALineNo;
					obj.GoodsInLineNo = objDetails.GoodsInLineNo;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.StockNo = objDetails.StockNo;
					obj.SupplierRMANo = objDetails.SupplierRMANo;
					obj.ReturnDate = objDetails.ReturnDate;
					obj.SalesOrderNo = objDetails.SalesOrderNo;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.CustomerPO = objDetails.CustomerPO;
					obj.DatePromised = objDetails.DatePromised;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.SupplierRMADate = objDetails.SupplierRMADate;
					obj.Salesman = objDetails.Salesman;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.Part = objDetails.Part;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ProductNo = objDetails.ProductNo;
					obj.ProductName = objDetails.ProductName;
					obj.PackageNo = objDetails.PackageNo;
					obj.PackageName = objDetails.PackageName;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.Price = objDetails.Price;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.ROHS = objDetails.ROHS;
                    //[002] code start
                    obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
                    //[002] code end
                    obj.SOSerialNo = objDetails.SOSerialNo;
                    obj.ShipASAP = objDetails.ShipASAP;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForSalesOrderLine
		/// Calls [usp_selectAll_Allocation_for_SalesOrderLine]
		/// </summary>
		public static List<Allocation> GetListForSalesOrderLine(System.Int32? salesOrderLineId) {
			List<AllocationDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Allocation.GetListForSalesOrderLine(salesOrderLineId);
			if (lstDetails == null) {
				return new List<Allocation>();
			} else {
				List<Allocation> lst = new List<Allocation>();
				foreach (AllocationDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Allocation obj = new Rebound.GlobalTrader.BLL.Allocation();
					obj.AllocationId = objDetails.AllocationId;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.QuantityAllocated = objDetails.QuantityAllocated;
					obj.StockNo = objDetails.StockNo;
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.Price = objDetails.Price;
					obj.ExpediteDate = objDetails.ExpediteDate;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.CustomerRMANo = objDetails.CustomerRMANo;
					obj.CustomerRMANumber = objDetails.CustomerRMANumber;
					obj.QuantityInStock = objDetails.QuantityInStock;
					obj.QuantityOnOrder = objDetails.QuantityOnOrder;
					obj.ReturnDate = objDetails.ReturnDate;
					obj.LandedCost = objDetails.LandedCost;
                    obj.POSerialNo = objDetails.POSerialNo;
                    obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
                    obj.InternalPurchaseOrderNo = objDetails.InternalPurchaseOrderNo;
                    obj.IPOSupplier = objDetails.IPOSupplier;
                    obj.IPOSupplierName = objDetails.IPOSupplierName;
                    obj.ClientLandedCost = objDetails.ClientLandedCost;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForStock
		/// Calls [usp_selectAll_Allocation_for_Stock]
		/// </summary>
		public static List<Allocation> GetListForStock(System.Int32? stockId) {
			List<AllocationDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Allocation.GetListForStock(stockId);
			if (lstDetails == null) {
				return new List<Allocation>();
			} else {
				List<Allocation> lst = new List<Allocation>();
				foreach (AllocationDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Allocation obj = new Rebound.GlobalTrader.BLL.Allocation();
					obj.AllocationId = objDetails.AllocationId;
					obj.QuantityAllocated = objDetails.QuantityAllocated;
					obj.CustomerRMALineNo = objDetails.CustomerRMALineNo;
					obj.GoodsInLineNo = objDetails.GoodsInLineNo;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.StockNo = objDetails.StockNo;
					obj.SupplierRMANo = objDetails.SupplierRMANo;
					obj.ReturnDate = objDetails.ReturnDate;
					obj.SalesOrderNo = objDetails.SalesOrderNo;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.CustomerPO = objDetails.CustomerPO;
					obj.DatePromised = objDetails.DatePromised;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.SupplierRMADate = objDetails.SupplierRMADate;
					obj.Salesman = objDetails.Salesman;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.Part = objDetails.Part;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ProductNo = objDetails.ProductNo;
					obj.ProductName = objDetails.ProductName;
					obj.PackageNo = objDetails.PackageNo;
					obj.PackageName = objDetails.PackageName;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.Price = objDetails.Price;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.ROHS = objDetails.ROHS;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForSupplierRMALine
		/// Calls [usp_selectAll_Allocation_for_SupplierRMALine]
		/// </summary>
		public static List<Allocation> GetListForSupplierRMALine(System.Int32? supplierRmaLineId) {
			List<AllocationDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Allocation.GetListForSupplierRMALine(supplierRmaLineId);
			if (lstDetails == null) {
				return new List<Allocation>();
			} else {
				List<Allocation> lst = new List<Allocation>();
				foreach (AllocationDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Allocation obj = new Rebound.GlobalTrader.BLL.Allocation();
					obj.AllocationId = objDetails.AllocationId;
					obj.StockNo = objDetails.StockNo;
					obj.Part = objDetails.Part;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.SupplierCompanyNo = objDetails.SupplierCompanyNo;
					obj.SupplierCompanyName = objDetails.SupplierCompanyName;
					obj.ExpediteDate = objDetails.ExpediteDate;
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.CustomerRMANo = objDetails.CustomerRMANo;
					obj.CustomerRMANumber = objDetails.CustomerRMANumber;
					obj.ReturnDate = objDetails.ReturnDate;
					obj.QuantityAllocated = objDetails.QuantityAllocated;
					obj.Location = objDetails.Location;
					obj.ROHS = objDetails.ROHS;
                    //[001] code start
                    obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
                    //[001] code end
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_Allocation]
		/// </summary>
		public static bool Update(System.Int32? allocationId, System.Int32? stockNo, System.Int32? salesOrderLineNo, System.Int32? quantityAllocated, System.Int32? supplierRmaLineNo, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Allocation.Update(allocationId, stockNo, salesOrderLineNo, quantityAllocated, supplierRmaLineNo, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Allocation]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Allocation.Update(AllocationId, StockNo, SalesOrderLineNo, QuantityAllocated, SupplierRMALineNo, UpdatedBy);
		}
		/// <summary>
		/// UpdateAfterIncreaseGIQuantity
		/// Calls [usp_update_Allocation_AfterIncreaseGIQuantity]
		/// </summary>
		public static bool UpdateAfterIncreaseGIQuantity(System.Int32? goodsInLineNo, System.Int32? oldQuantity, System.Int32? newQuantity, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Allocation.UpdateAfterIncreaseGIQuantity(goodsInLineNo, oldQuantity, newQuantity, updatedBy);
		}
		/// <summary>
		/// UpdateAfterPartialReceive
		/// Calls [usp_Update_Allocation_AfterPartialReceive]
		/// </summary>
		public static bool UpdateAfterPartialReceive(System.Int32? goodsInLineNo, System.Int32? goodsInNo, System.Int32? quantityInserted, System.Int32? quantityOnOrderChange, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Allocation.UpdateAfterPartialReceive(goodsInLineNo, goodsInNo, quantityInserted, quantityOnOrderChange, updatedBy);
		}
		/// <summary>
		/// UpdateCleanUp
		/// Calls [usp_update_Allocation_CleanUp]
		/// </summary>
		public static bool UpdateCleanUp() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Allocation.UpdateCleanUp();
		}

        private static Allocation PopulateFromDBDetailsObject(AllocationDetails obj) {
            Allocation objNew = new Allocation();
			objNew.AllocationId = obj.AllocationId;
			objNew.StockNo = obj.StockNo;
			objNew.SalesOrderLineNo = obj.SalesOrderLineNo;
			objNew.QuantityAllocated = obj.QuantityAllocated;
			objNew.SupplierRMALineNo = obj.SupplierRMALineNo;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.SalesmanName = obj.SalesmanName;
			objNew.SupplierRMANo = obj.SupplierRMANo;
			objNew.SupplierRMANumber = obj.SupplierRMANumber;
			objNew.Part = obj.Part;
			objNew.ProductNo = obj.ProductNo;
			objNew.ProductName = obj.ProductName;
			objNew.ProductDescription = obj.ProductDescription;
			objNew.ManufacturerNo = obj.ManufacturerNo;
			objNew.ManufacturerCode = obj.ManufacturerCode;
			objNew.ManufacturerName = obj.ManufacturerName;
			objNew.PackageNo = obj.PackageNo;
			objNew.PackageName = obj.PackageName;
			objNew.PackageDescription = obj.PackageDescription;
			objNew.DateCode = obj.DateCode;
			objNew.ROHS = obj.ROHS;
			objNew.LandedCost = obj.LandedCost;
			objNew.QuantityInStock = obj.QuantityInStock;
			objNew.WarehouseNo = obj.WarehouseNo;
			objNew.WarehouseName = obj.WarehouseName;
			objNew.PurchaseOrderNo = obj.PurchaseOrderNo;
			objNew.PurchaseOrderNumber = obj.PurchaseOrderNumber;
			objNew.PurchaseOrderLineId = obj.PurchaseOrderLineId;
			objNew.BuyPrice = obj.BuyPrice;
			objNew.DeliveryDate = obj.DeliveryDate;
			objNew.BuyCurrencyNo = obj.BuyCurrencyNo;
			objNew.BuyCurrencyCode = obj.BuyCurrencyCode;
			objNew.SupplierCompanyNo = obj.SupplierCompanyNo;
			objNew.SupplierCompanyName = obj.SupplierCompanyName;
			objNew.CustomerCompanyNo = obj.CustomerCompanyNo;
			objNew.CustomerCompanyName = obj.CustomerCompanyName;
			objNew.Salesman = obj.Salesman;
			objNew.SalesOrderNo = obj.SalesOrderNo;
			objNew.SalesOrderNumber = obj.SalesOrderNumber;
			objNew.CustomerPO = obj.CustomerPO;
			objNew.SellPrice = obj.SellPrice;
			objNew.SellCurrencyNo = obj.SellCurrencyNo;
			objNew.SellCurrencyCode = obj.SellCurrencyCode;
			objNew.DatePromised = obj.DatePromised;
			objNew.CustomerPart = obj.CustomerPart;
			objNew.GoodsInLineNo = obj.GoodsInLineNo;
			objNew.Shipped = obj.Shipped;
			objNew.Location = obj.Location;
			objNew.SupplierPart = obj.SupplierPart;
			objNew.CustomerRMALineNo = obj.CustomerRMALineNo;
			objNew.PurchaseOrderLineNo = obj.PurchaseOrderLineNo;
			objNew.ReturnDate = obj.ReturnDate;
			objNew.SupplierRMADate = obj.SupplierRMADate;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.CompanyName = obj.CompanyName;
			objNew.CurrencyNo = obj.CurrencyNo;
			objNew.CurrencyCode = obj.CurrencyCode;
			objNew.Price = obj.Price;
			objNew.ExpediteDate = obj.ExpediteDate;
			objNew.CustomerRMANo = obj.CustomerRMANo;
			objNew.CustomerRMANumber = obj.CustomerRMANumber;
			objNew.QuantityOnOrder = obj.QuantityOnOrder;
            return objNew;
        }
		
		#endregion
		
	}
}