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
		public partial class InvoiceLineAllocation : BizObject {
		
		#region Properties

		protected static DAL.InvoiceLineAllocationElement Settings {
			get { return Globals.Settings.InvoiceLineAllocations; }
		}

		/// <summary>
		/// InvoiceLineAllocationId
		/// </summary>
		public System.Int32 InvoiceLineAllocationId { get; set; }		
		/// <summary>
		/// InvoiceLineNo
		/// </summary>
		public System.Int32 InvoiceLineNo { get; set; }		
		/// <summary>
		/// Quantity
		/// </summary>
		public System.Int32 Quantity { get; set; }		
		/// <summary>
		/// StockNo
		/// </summary>
		public System.Int32? StockNo { get; set; }		
		/// <summary>
		/// SalesOrderLineNo
		/// </summary>
		public System.Int32? SalesOrderLineNo { get; set; }		
		/// <summary>
		/// LotNo
		/// </summary>
		public System.Int32? LotNo { get; set; }		
		/// <summary>
		/// LandedCost
		/// </summary>
		public System.Double? LandedCost { get; set; }		
		/// <summary>
		/// SupplierRMALineNo
		/// </summary>
		public System.Int32? SupplierRMALineNo { get; set; }		
		/// <summary>
		/// WarehouseNo
		/// </summary>
		public System.Int32? WarehouseNo { get; set; }		
		/// <summary>
		/// Location
		/// </summary>
		public System.String Location { get; set; }		
		/// <summary>
		/// GoodsInLineNo
		/// </summary>
		public System.Int32? GoodsInLineNo { get; set; }		
		/// <summary>
		/// PurchaseOrderLineNo
		/// </summary>
		public System.Int32? PurchaseOrderLineNo { get; set; }		
		/// <summary>
		/// CountryOfManufactureNo
		/// </summary>
		public System.Int32? CountryOfManufactureNo { get; set; }		
		/// <summary>
		/// CustomerRMAGoodsInLineNo
		/// </summary>
		public System.Int32? CustomerRMAGoodsInLineNo { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// LineNotes
		/// </summary>
		public System.String LineNotes { get; set; }		
		/// <summary>
		/// CountryOfManufactureName
		/// </summary>
		public System.String CountryOfManufactureName { get; set; }		
		/// <summary>
		/// LotName
		/// </summary>
		public System.String LotName { get; set; }		
		/// <summary>
		/// WarehouseName
		/// </summary>
		public System.String WarehouseName { get; set; }		
		/// <summary>
		/// InvoiceNo
		/// </summary>
		public System.Int32 InvoiceNo { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32? ClientNo { get; set; }		
		/// <summary>
		/// InvoiceNumber
		/// </summary>
		public System.Int32? InvoiceNumber { get; set; }		
		/// <summary>
		/// InvoiceDate
		/// </summary>
		public System.DateTime? InvoiceDate { get; set; }		
		/// <summary>
		/// SalesOrderNo
		/// </summary>
		public System.Int32? SalesOrderNo { get; set; }		
		/// <summary>
		/// Salesman2
		/// </summary>
		public System.Int32? Salesman2 { get; set; }		
		/// <summary>
		/// ShippingCost
		/// </summary>
		public System.Double? ShippingCost { get; set; }		
		/// <summary>
		/// Freight
		/// </summary>
		public System.Double? Freight { get; set; }		
		/// <summary>
		/// Salesman2Name
		/// </summary>
		public System.String Salesman2Name { get; set; }		
		/// <summary>
		/// Salesman2Percent
		/// </summary>
		public System.Double Salesman2Percent { get; set; }		
		/// <summary>
		/// SalesOrderNumber
		/// </summary>
		public System.Int32? SalesOrderNumber { get; set; }		
		/// <summary>
		/// CurrencyNo
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }		
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32? CompanyNo { get; set; }		
		/// <summary>
		/// CompanyName
		/// </summary>
		public System.String CompanyName { get; set; }		
		/// <summary>
		/// Part
		/// </summary>
		public System.String Part { get; set; }		
		/// <summary>
		/// DateCode
		/// </summary>
		public System.String DateCode { get; set; }		
		/// <summary>
		/// SupplierPart
		/// </summary>
		public System.String SupplierPart { get; set; }		
		/// <summary>
		/// ProductNo
		/// </summary>
		public System.Int32? ProductNo { get; set; }		
		/// <summary>
		/// PackageNo
		/// </summary>
		public System.Int32? PackageNo { get; set; }		
		/// <summary>
		/// ManufacturerNo
		/// </summary>
		public System.Int32? ManufacturerNo { get; set; }		
		/// <summary>
		/// ROHS
		/// </summary>
		public System.Byte? ROHS { get; set; }		
		/// <summary>
		/// GoodsInNo
		/// </summary>
		public System.Int32? GoodsInNo { get; set; }		
		/// <summary>
		/// GoodsInNumber
		/// </summary>
		public System.Int32? GoodsInNumber { get; set; }		
		/// <summary>
		/// ManufacturerName
		/// </summary>
		public System.String ManufacturerName { get; set; }		
		/// <summary>
		/// ManufacturerCode
		/// </summary>
		public System.String ManufacturerCode { get; set; }		
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
		/// SalesOrderLineId
		/// </summary>
		public System.Int32? SalesOrderLineId { get; set; }		
		/// <summary>
		/// Price
		/// </summary>
		public System.Double? Price { get; set; }		
		/// <summary>
		/// CustomerPart
		/// </summary>
		public System.String CustomerPart { get; set; }		
		/// <summary>
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }		
		/// <summary>
		/// SupplierRMANo
		/// </summary>
		public System.Int32? SupplierRMANo { get; set; }		
		/// <summary>
		/// SupplierRMANumber
		/// </summary>
		public System.Int32? SupplierRMANumber { get; set; }		
		/// <summary>
		/// PurchaseOrderNo
		/// </summary>
		public System.Int32? PurchaseOrderNo { get; set; }		
		/// <summary>
		/// PurchasePrice
		/// </summary>
		public System.Double? PurchasePrice { get; set; }		
		/// <summary>
		/// PurchaseOrderNumber
		/// </summary>
		public System.Int32? PurchaseOrderNumber { get; set; }

        public System.Int32? InternalPurchaseOrderNo { get; set; }
        public System.Int32? InternalPurchaseOrderNumber { get; set; }

		/// <summary>
		/// SupplierNo
		/// </summary>
		public System.Int32? SupplierNo { get; set; }		
		/// <summary>
		/// PurchaseCurrencyNo
		/// </summary>
		public System.Int32? PurchaseCurrencyNo { get; set; }		
		/// <summary>
		/// PurchaseCurrencyCode
		/// </summary>
		public System.String PurchaseCurrencyCode { get; set; }		
		/// <summary>
		/// SupplierName
		/// </summary>
		public System.String SupplierName { get; set; }		
		/// <summary>
		/// Salesman
		/// </summary>
		public System.Int32? Salesman { get; set; }		
		/// <summary>
		/// SalesmanName
		/// </summary>
		public System.String SalesmanName { get; set; }		
		/// <summary>
		/// Buyer
		/// </summary>
		public System.Int32? Buyer { get; set; }		
		/// <summary>
		/// BuyerName
		/// </summary>
		public System.String BuyerName { get; set; }		
		/// <summary>
		/// QuantityAllocatedToCRMA
		/// </summary>
		public System.Int32? QuantityAllocatedToCRMA { get; set; }		
		/// <summary>
		/// QuantityAllocated
		/// </summary>
		public System.Int32? QuantityAllocated { get; set; }

        /// SOSerialNo
        /// </summary>
        public System.Int32? SOSerialNo { get; set; }
        /// <summary>
        /// ClientSupplierNo
        /// </summary>
        public System.Int32? ClientSupplierNo { get; set; }
        /// <summary>
        /// ClientSupplierName
        /// </summary>
        public System.String ClientSupplierName { get; set; }
        ///// <summary>
        ///// ClientLandedCost
        ///// </summary>
        public System.Double? ClientLandedCost { get; set; }
		#endregion
		
		#region Methods
		
		/// <summary>
		/// CountForPurchaseOrderLine
		/// Calls [usp_count_InvoiceLineAllocation_for_PurchaseOrderLine]
		/// </summary>
		public static Int32 CountForPurchaseOrderLine(System.Int32? purchaseOrderLineId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLineAllocation.CountForPurchaseOrderLine(purchaseOrderLineId);
		}		/// <summary>
		/// Delete
		/// Calls [usp_delete_InvoiceLineAllocation]
		/// </summary>
		public static bool Delete(System.Int32? invoiceLineAllocationId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLineAllocation.Delete(invoiceLineAllocationId);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_InvoiceLineAllocation]
		/// </summary>
		public static Int32 Insert(System.Int32? invoiceLineNo, System.Int32? quantity, System.Int32? stockNo, System.Int32? salesOrderLineNo, System.Int32? lotNo, System.Double? landedCost, System.Int32? supplierRmaLineNo, System.Int32? warehouseNo, System.String location, System.Int32? goodsInLineNo, System.Int32? purchaseOrderLineNo, System.Int32? customerRmaGoodsInLineNo, System.Int32? countryOfManufactureNo, System.String notes, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLineAllocation.Insert(invoiceLineNo, quantity, stockNo, salesOrderLineNo, lotNo, landedCost, supplierRmaLineNo, warehouseNo, location, goodsInLineNo, purchaseOrderLineNo, customerRmaGoodsInLineNo, countryOfManufactureNo, notes, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_InvoiceLineAllocation]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLineAllocation.Insert(InvoiceLineNo, Quantity, StockNo, SalesOrderLineNo, LotNo, LandedCost, SupplierRMALineNo, WarehouseNo, Location, GoodsInLineNo, PurchaseOrderLineNo, CustomerRMAGoodsInLineNo, CountryOfManufactureNo, Notes, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_InvoiceLineAllocation]
		/// </summary>
		public static InvoiceLineAllocation Get(System.Int32? invoiceLineAllocationId) {
			Rebound.GlobalTrader.DAL.InvoiceLineAllocationDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLineAllocation.Get(invoiceLineAllocationId);
			if (objDetails == null) {
				return null;
			} else {
				InvoiceLineAllocation obj = new InvoiceLineAllocation();
				obj.InvoiceLineAllocationId = objDetails.InvoiceLineAllocationId;
				obj.InvoiceLineNo = objDetails.InvoiceLineNo;
				obj.Quantity = objDetails.Quantity;
				obj.StockNo = objDetails.StockNo;
				obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
				obj.LotNo = objDetails.LotNo;
				obj.LandedCost = objDetails.LandedCost;
				obj.SupplierRMALineNo = objDetails.SupplierRMALineNo;
				obj.WarehouseNo = objDetails.WarehouseNo;
				obj.Location = objDetails.Location;
				obj.GoodsInLineNo = objDetails.GoodsInLineNo;
				obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
				obj.CountryOfManufactureNo = objDetails.CountryOfManufactureNo;
				obj.CustomerRMAGoodsInLineNo = objDetails.CustomerRMAGoodsInLineNo;
				obj.LineNotes = objDetails.LineNotes;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.CountryOfManufactureName = objDetails.CountryOfManufactureName;
				obj.LotName = objDetails.LotName;
				obj.WarehouseName = objDetails.WarehouseName;
				obj.InvoiceNo = objDetails.InvoiceNo;
				obj.ClientNo = objDetails.ClientNo;
				obj.InvoiceNumber = objDetails.InvoiceNumber;
				obj.InvoiceDate = objDetails.InvoiceDate;
				obj.SalesOrderNo = objDetails.SalesOrderNo;
				obj.Salesman2 = objDetails.Salesman2;
				obj.ShippingCost = objDetails.ShippingCost;
				obj.Freight = objDetails.Freight;
				obj.Salesman2Name = objDetails.Salesman2Name;
				obj.Salesman2Percent = objDetails.Salesman2Percent;
				obj.SalesOrderNumber = objDetails.SalesOrderNumber;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.Part = objDetails.Part;
				obj.DateCode = objDetails.DateCode;
				obj.SupplierPart = objDetails.SupplierPart;
				obj.ProductNo = objDetails.ProductNo;
				obj.PackageNo = objDetails.PackageNo;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.ROHS = objDetails.ROHS;
				obj.GoodsInNo = objDetails.GoodsInNo;
				obj.GoodsInNumber = objDetails.GoodsInNumber;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.ManufacturerCode = objDetails.ManufacturerCode;
				obj.PackageName = objDetails.PackageName;
				obj.PackageDescription = objDetails.PackageDescription;
				obj.ProductName = objDetails.ProductName;
				obj.ProductDescription = objDetails.ProductDescription;
				obj.SalesOrderLineId = objDetails.SalesOrderLineId;
				obj.Price = objDetails.Price;
				obj.CustomerPart = objDetails.CustomerPart;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.SupplierRMANo = objDetails.SupplierRMANo;
				obj.SupplierRMANumber = objDetails.SupplierRMANumber;
				obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
				obj.PurchasePrice = objDetails.PurchasePrice;
				obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
				obj.SupplierNo = objDetails.SupplierNo;
				obj.PurchaseCurrencyNo = objDetails.PurchaseCurrencyNo;
				obj.PurchaseCurrencyCode = objDetails.PurchaseCurrencyCode;
				obj.SupplierName = objDetails.SupplierName;
				obj.Salesman = objDetails.Salesman;
				obj.SalesmanName = objDetails.SalesmanName;
				obj.Buyer = objDetails.Buyer;
				obj.BuyerName = objDetails.BuyerName;
				obj.QuantityAllocatedToCRMA = objDetails.QuantityAllocatedToCRMA;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetCandidateForCustomerRMA
		/// Calls [usp_select_InvoiceLineAllocation_candidate_for_CustomerRMA]
		/// </summary>
		public static InvoiceLineAllocation GetCandidateForCustomerRMA(System.Int32? invoiceLineAllocationId, System.Int32? customerRmaId) {
			Rebound.GlobalTrader.DAL.InvoiceLineAllocationDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLineAllocation.GetCandidateForCustomerRMA(invoiceLineAllocationId, customerRmaId);
			if (objDetails == null) {
				return null;
			} else {
				InvoiceLineAllocation obj = new InvoiceLineAllocation();
				obj.InvoiceLineAllocationId = objDetails.InvoiceLineAllocationId;
				obj.InvoiceLineNo = objDetails.InvoiceLineNo;
				obj.Quantity = objDetails.Quantity;
				obj.StockNo = objDetails.StockNo;
				obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
				obj.LotNo = objDetails.LotNo;
				obj.LandedCost = objDetails.LandedCost;
				obj.SupplierRMALineNo = objDetails.SupplierRMALineNo;
				obj.WarehouseNo = objDetails.WarehouseNo;
				obj.Location = objDetails.Location;
				obj.GoodsInLineNo = objDetails.GoodsInLineNo;
				obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
				obj.CountryOfManufactureNo = objDetails.CountryOfManufactureNo;
				obj.CustomerRMAGoodsInLineNo = objDetails.CustomerRMAGoodsInLineNo;
				obj.LineNotes = objDetails.LineNotes;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.CountryOfManufactureName = objDetails.CountryOfManufactureName;
				obj.LotName = objDetails.LotName;
				obj.WarehouseName = objDetails.WarehouseName;
				obj.InvoiceNo = objDetails.InvoiceNo;
				obj.ClientNo = objDetails.ClientNo;
				obj.InvoiceNumber = objDetails.InvoiceNumber;
				obj.InvoiceDate = objDetails.InvoiceDate;
				obj.SalesOrderNo = objDetails.SalesOrderNo;
				obj.Salesman2 = objDetails.Salesman2;
				obj.ShippingCost = objDetails.ShippingCost;
				obj.Freight = objDetails.Freight;
				obj.Salesman2Name = objDetails.Salesman2Name;
				obj.Salesman2Percent = objDetails.Salesman2Percent;
				obj.SalesOrderNumber = objDetails.SalesOrderNumber;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.Part = objDetails.Part;
				obj.DateCode = objDetails.DateCode;
				obj.SupplierPart = objDetails.SupplierPart;
				obj.ProductNo = objDetails.ProductNo;
				obj.PackageNo = objDetails.PackageNo;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.ROHS = objDetails.ROHS;
				obj.GoodsInNo = objDetails.GoodsInNo;
				obj.GoodsInNumber = objDetails.GoodsInNumber;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.ManufacturerCode = objDetails.ManufacturerCode;
				obj.PackageName = objDetails.PackageName;
				obj.PackageDescription = objDetails.PackageDescription;
				obj.ProductName = objDetails.ProductName;
				obj.ProductDescription = objDetails.ProductDescription;
				obj.SalesOrderLineId = objDetails.SalesOrderLineId;
				obj.Price = objDetails.Price;
				obj.CustomerPart = objDetails.CustomerPart;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.SupplierRMANo = objDetails.SupplierRMANo;
				obj.SupplierRMANumber = objDetails.SupplierRMANumber;
				obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
				obj.PurchasePrice = objDetails.PurchasePrice;
				obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
				obj.SupplierNo = objDetails.SupplierNo;
				obj.PurchaseCurrencyNo = objDetails.PurchaseCurrencyNo;
				obj.PurchaseCurrencyCode = objDetails.PurchaseCurrencyCode;
				obj.SupplierName = objDetails.SupplierName;
				obj.Salesman = objDetails.Salesman;
				obj.SalesmanName = objDetails.SalesmanName;
				obj.Buyer = objDetails.Buyer;
				obj.BuyerName = objDetails.BuyerName;
				obj.QuantityAllocatedToCRMA = objDetails.QuantityAllocatedToCRMA;
				obj.QuantityAllocated = objDetails.QuantityAllocated;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListCandidatesForCustomerRMA
		/// Calls [usp_selectAll_InvoiceLineAllocation_candidates_for_CustomerRMA]
		/// </summary>
		public static List<InvoiceLineAllocation> GetListCandidatesForCustomerRMA(System.Int32? customerRmaId) {
			List<InvoiceLineAllocationDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLineAllocation.GetListCandidatesForCustomerRMA(customerRmaId);
			if (lstDetails == null) {
				return new List<InvoiceLineAllocation>();
			} else {
				List<InvoiceLineAllocation> lst = new List<InvoiceLineAllocation>();
				foreach (InvoiceLineAllocationDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.InvoiceLineAllocation obj = new Rebound.GlobalTrader.BLL.InvoiceLineAllocation();
					obj.InvoiceLineAllocationId = objDetails.InvoiceLineAllocationId;
					obj.InvoiceLineNo = objDetails.InvoiceLineNo;
					obj.Quantity = objDetails.Quantity;
					obj.StockNo = objDetails.StockNo;
					obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
					obj.LotNo = objDetails.LotNo;
					obj.LandedCost = objDetails.LandedCost;
					obj.SupplierRMALineNo = objDetails.SupplierRMALineNo;
					obj.WarehouseNo = objDetails.WarehouseNo;
					obj.Location = objDetails.Location;
					obj.GoodsInLineNo = objDetails.GoodsInLineNo;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.CountryOfManufactureNo = objDetails.CountryOfManufactureNo;
					obj.CustomerRMAGoodsInLineNo = objDetails.CustomerRMAGoodsInLineNo;
					obj.LineNotes = objDetails.LineNotes;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.CountryOfManufactureName = objDetails.CountryOfManufactureName;
					obj.LotName = objDetails.LotName;
					obj.WarehouseName = objDetails.WarehouseName;
					obj.InvoiceNo = objDetails.InvoiceNo;
					obj.ClientNo = objDetails.ClientNo;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.InvoiceDate = objDetails.InvoiceDate;
					obj.SalesOrderNo = objDetails.SalesOrderNo;
					obj.Salesman2 = objDetails.Salesman2;
					obj.ShippingCost = objDetails.ShippingCost;
					obj.Freight = objDetails.Freight;
					obj.Salesman2Name = objDetails.Salesman2Name;
					obj.Salesman2Percent = objDetails.Salesman2Percent;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.Part = objDetails.Part;
					obj.DateCode = objDetails.DateCode;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.ProductNo = objDetails.ProductNo;
					obj.PackageNo = objDetails.PackageNo;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ROHS = objDetails.ROHS;
					obj.GoodsInNo = objDetails.GoodsInNo;
					obj.GoodsInNumber = objDetails.GoodsInNumber;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.SalesOrderLineId = objDetails.SalesOrderLineId;
					obj.Price = objDetails.Price;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.SupplierRMANo = objDetails.SupplierRMANo;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.PurchasePrice = objDetails.PurchasePrice;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.SupplierNo = objDetails.SupplierNo;
					obj.PurchaseCurrencyNo = objDetails.PurchaseCurrencyNo;
					obj.PurchaseCurrencyCode = objDetails.PurchaseCurrencyCode;
					obj.SupplierName = objDetails.SupplierName;
					obj.Salesman = objDetails.Salesman;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.Buyer = objDetails.Buyer;
					obj.BuyerName = objDetails.BuyerName;
					obj.QuantityAllocatedToCRMA = objDetails.QuantityAllocatedToCRMA;
                    obj.SOSerialNo = objDetails.SOSerialNo;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForGoodsInLine
		/// Calls [usp_selectAll_InvoiceLineAllocation_for_GoodsInLine]
		/// </summary>
		public static List<InvoiceLineAllocation> GetListForGoodsInLine(System.Int32? goodsInLineId) {
			List<InvoiceLineAllocationDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLineAllocation.GetListForGoodsInLine(goodsInLineId);
			if (lstDetails == null) {
				return new List<InvoiceLineAllocation>();
			} else {
				List<InvoiceLineAllocation> lst = new List<InvoiceLineAllocation>();
				foreach (InvoiceLineAllocationDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.InvoiceLineAllocation obj = new Rebound.GlobalTrader.BLL.InvoiceLineAllocation();
					obj.InvoiceLineAllocationId = objDetails.InvoiceLineAllocationId;
					obj.InvoiceLineNo = objDetails.InvoiceLineNo;
					obj.Quantity = objDetails.Quantity;
					obj.StockNo = objDetails.StockNo;
					obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
					obj.LotNo = objDetails.LotNo;
					obj.LandedCost = objDetails.LandedCost;
					obj.SupplierRMALineNo = objDetails.SupplierRMALineNo;
					obj.WarehouseNo = objDetails.WarehouseNo;
					obj.Location = objDetails.Location;
					obj.GoodsInLineNo = objDetails.GoodsInLineNo;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.CountryOfManufactureNo = objDetails.CountryOfManufactureNo;
					obj.CustomerRMAGoodsInLineNo = objDetails.CustomerRMAGoodsInLineNo;
					obj.LineNotes = objDetails.LineNotes;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.CountryOfManufactureName = objDetails.CountryOfManufactureName;
					obj.LotName = objDetails.LotName;
					obj.WarehouseName = objDetails.WarehouseName;
					obj.InvoiceNo = objDetails.InvoiceNo;
					obj.ClientNo = objDetails.ClientNo;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.InvoiceDate = objDetails.InvoiceDate;
					obj.SalesOrderNo = objDetails.SalesOrderNo;
					obj.Salesman2 = objDetails.Salesman2;
					obj.ShippingCost = objDetails.ShippingCost;
					obj.Freight = objDetails.Freight;
					obj.Salesman2Name = objDetails.Salesman2Name;
					obj.Salesman2Percent = objDetails.Salesman2Percent;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.Part = objDetails.Part;
					obj.DateCode = objDetails.DateCode;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.ProductNo = objDetails.ProductNo;
					obj.PackageNo = objDetails.PackageNo;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ROHS = objDetails.ROHS;
					obj.GoodsInNo = objDetails.GoodsInNo;
					obj.GoodsInNumber = objDetails.GoodsInNumber;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.SalesOrderLineId = objDetails.SalesOrderLineId;
					obj.Price = objDetails.Price;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.SupplierRMANo = objDetails.SupplierRMANo;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.PurchasePrice = objDetails.PurchasePrice;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.SupplierNo = objDetails.SupplierNo;
					obj.PurchaseCurrencyNo = objDetails.PurchaseCurrencyNo;
					obj.PurchaseCurrencyCode = objDetails.PurchaseCurrencyCode;
					obj.SupplierName = objDetails.SupplierName;
					obj.Salesman = objDetails.Salesman;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.Buyer = objDetails.Buyer;
					obj.BuyerName = objDetails.BuyerName;
					obj.QuantityAllocatedToCRMA = objDetails.QuantityAllocatedToCRMA;
                    obj.ClientLandedCost = objDetails.ClientLandedCost;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForInvoiceLine
		/// Calls [usp_selectAll_InvoiceLineAllocation_for_InvoiceLine]
		/// </summary>
		public static List<InvoiceLineAllocation> GetListForInvoiceLine(System.Int32? invoiceLineId) {
			List<InvoiceLineAllocationDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLineAllocation.GetListForInvoiceLine(invoiceLineId);
			if (lstDetails == null) {
				return new List<InvoiceLineAllocation>();
			} else {
				List<InvoiceLineAllocation> lst = new List<InvoiceLineAllocation>();
				foreach (InvoiceLineAllocationDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.InvoiceLineAllocation obj = new Rebound.GlobalTrader.BLL.InvoiceLineAllocation();
					obj.InvoiceLineAllocationId = objDetails.InvoiceLineAllocationId;
					obj.InvoiceLineNo = objDetails.InvoiceLineNo;
					obj.Quantity = objDetails.Quantity;
					obj.StockNo = objDetails.StockNo;
					obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
					obj.LotNo = objDetails.LotNo;
					obj.LandedCost = objDetails.LandedCost;
					obj.SupplierRMALineNo = objDetails.SupplierRMALineNo;
					obj.WarehouseNo = objDetails.WarehouseNo;
					obj.Location = objDetails.Location;
					obj.GoodsInLineNo = objDetails.GoodsInLineNo;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.CountryOfManufactureNo = objDetails.CountryOfManufactureNo;
					obj.CustomerRMAGoodsInLineNo = objDetails.CustomerRMAGoodsInLineNo;
					obj.LineNotes = objDetails.LineNotes;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.CountryOfManufactureName = objDetails.CountryOfManufactureName;
					obj.LotName = objDetails.LotName;
					obj.WarehouseName = objDetails.WarehouseName;
					obj.InvoiceNo = objDetails.InvoiceNo;
					obj.ClientNo = objDetails.ClientNo;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.InvoiceDate = objDetails.InvoiceDate;
					obj.SalesOrderNo = objDetails.SalesOrderNo;
					obj.Salesman2 = objDetails.Salesman2;
					obj.ShippingCost = objDetails.ShippingCost;
					obj.Freight = objDetails.Freight;
					obj.Salesman2Name = objDetails.Salesman2Name;
					obj.Salesman2Percent = objDetails.Salesman2Percent;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.Part = objDetails.Part;
					obj.DateCode = objDetails.DateCode;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.ProductNo = objDetails.ProductNo;
					obj.PackageNo = objDetails.PackageNo;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ROHS = objDetails.ROHS;
					obj.GoodsInNo = objDetails.GoodsInNo;
					obj.GoodsInNumber = objDetails.GoodsInNumber;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.SalesOrderLineId = objDetails.SalesOrderLineId;
					obj.Price = objDetails.Price;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.SupplierRMANo = objDetails.SupplierRMANo;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.PurchasePrice = objDetails.PurchasePrice;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.SupplierNo = objDetails.SupplierNo;
					obj.PurchaseCurrencyNo = objDetails.PurchaseCurrencyNo;
					obj.PurchaseCurrencyCode = objDetails.PurchaseCurrencyCode;
					obj.SupplierName = objDetails.SupplierName;
					obj.Salesman = objDetails.Salesman;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.Buyer = objDetails.Buyer;
					obj.BuyerName = objDetails.BuyerName;
					obj.QuantityAllocatedToCRMA = objDetails.QuantityAllocatedToCRMA;
                    obj.SOSerialNo = objDetails.SOSerialNo;
                   // obj.ClientLandedCost = objDetails.ClientLandedCost;
                    obj.ClientSupplierNo = objDetails.ClientSupplierNo;
                    obj.ClientSupplierName = objDetails.ClientSupplierName;
                    obj.InternalPurchaseOrderNo = objDetails.InternalPurchaseOrderNo;
                    obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;

					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForPurchaseOrderLine
		/// Calls [usp_selectAll_InvoiceLineAllocation_for_PurchaseOrderLine]
		/// </summary>
		public static List<InvoiceLineAllocation> GetListForPurchaseOrderLine(System.Int32? purchaseOrderLineId) {
			List<InvoiceLineAllocationDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLineAllocation.GetListForPurchaseOrderLine(purchaseOrderLineId);
			if (lstDetails == null) {
				return new List<InvoiceLineAllocation>();
			} else {
				List<InvoiceLineAllocation> lst = new List<InvoiceLineAllocation>();
				foreach (InvoiceLineAllocationDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.InvoiceLineAllocation obj = new Rebound.GlobalTrader.BLL.InvoiceLineAllocation();
					obj.InvoiceLineAllocationId = objDetails.InvoiceLineAllocationId;
					obj.InvoiceLineNo = objDetails.InvoiceLineNo;
					obj.Quantity = objDetails.Quantity;
					obj.StockNo = objDetails.StockNo;
					obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
					obj.LotNo = objDetails.LotNo;
					obj.LandedCost = objDetails.LandedCost;
					obj.SupplierRMALineNo = objDetails.SupplierRMALineNo;
					obj.WarehouseNo = objDetails.WarehouseNo;
					obj.Location = objDetails.Location;
					obj.GoodsInLineNo = objDetails.GoodsInLineNo;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.CountryOfManufactureNo = objDetails.CountryOfManufactureNo;
					obj.CustomerRMAGoodsInLineNo = objDetails.CustomerRMAGoodsInLineNo;
					obj.LineNotes = objDetails.LineNotes;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.CountryOfManufactureName = objDetails.CountryOfManufactureName;
					obj.LotName = objDetails.LotName;
					obj.WarehouseName = objDetails.WarehouseName;
					obj.InvoiceNo = objDetails.InvoiceNo;
					obj.ClientNo = objDetails.ClientNo;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.InvoiceDate = objDetails.InvoiceDate;
					obj.SalesOrderNo = objDetails.SalesOrderNo;
					obj.Salesman2 = objDetails.Salesman2;
					obj.ShippingCost = objDetails.ShippingCost;
					obj.Freight = objDetails.Freight;
					obj.Salesman2Name = objDetails.Salesman2Name;
					obj.Salesman2Percent = objDetails.Salesman2Percent;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.Part = objDetails.Part;
					obj.DateCode = objDetails.DateCode;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.ProductNo = objDetails.ProductNo;
					obj.PackageNo = objDetails.PackageNo;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ROHS = objDetails.ROHS;
					obj.GoodsInNo = objDetails.GoodsInNo;
					obj.GoodsInNumber = objDetails.GoodsInNumber;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.SalesOrderLineId = objDetails.SalesOrderLineId;
					obj.Price = objDetails.Price;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.SupplierRMANo = objDetails.SupplierRMANo;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.PurchasePrice = objDetails.PurchasePrice;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.SupplierNo = objDetails.SupplierNo;
					obj.PurchaseCurrencyNo = objDetails.PurchaseCurrencyNo;
					obj.PurchaseCurrencyCode = objDetails.PurchaseCurrencyCode;
					obj.SupplierName = objDetails.SupplierName;
					obj.Salesman = objDetails.Salesman;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.Buyer = objDetails.Buyer;
					obj.BuyerName = objDetails.BuyerName;
					obj.QuantityAllocatedToCRMA = objDetails.QuantityAllocatedToCRMA;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForSupplierRMALine
		/// Calls [usp_selectAll_InvoiceLineAllocation_for_SupplierRMALine]
		/// </summary>
		public static List<InvoiceLineAllocation> GetListForSupplierRMALine(System.Int32? supplierRmaLineId) {
			List<InvoiceLineAllocationDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLineAllocation.GetListForSupplierRMALine(supplierRmaLineId);
			if (lstDetails == null) {
				return new List<InvoiceLineAllocation>();
			} else {
				List<InvoiceLineAllocation> lst = new List<InvoiceLineAllocation>();
				foreach (InvoiceLineAllocationDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.InvoiceLineAllocation obj = new Rebound.GlobalTrader.BLL.InvoiceLineAllocation();
					obj.InvoiceLineAllocationId = objDetails.InvoiceLineAllocationId;
					obj.InvoiceLineNo = objDetails.InvoiceLineNo;
					obj.Quantity = objDetails.Quantity;
					obj.StockNo = objDetails.StockNo;
					obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
					obj.LotNo = objDetails.LotNo;
					obj.LandedCost = objDetails.LandedCost;
					obj.SupplierRMALineNo = objDetails.SupplierRMALineNo;
					obj.WarehouseNo = objDetails.WarehouseNo;
					obj.Location = objDetails.Location;
					obj.GoodsInLineNo = objDetails.GoodsInLineNo;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.CountryOfManufactureNo = objDetails.CountryOfManufactureNo;
					obj.CustomerRMAGoodsInLineNo = objDetails.CustomerRMAGoodsInLineNo;
					obj.LineNotes = objDetails.LineNotes;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.CountryOfManufactureName = objDetails.CountryOfManufactureName;
					obj.LotName = objDetails.LotName;
					obj.WarehouseName = objDetails.WarehouseName;
					obj.InvoiceNo = objDetails.InvoiceNo;
					obj.ClientNo = objDetails.ClientNo;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.InvoiceDate = objDetails.InvoiceDate;
					obj.SalesOrderNo = objDetails.SalesOrderNo;
					obj.Salesman2 = objDetails.Salesman2;
					obj.ShippingCost = objDetails.ShippingCost;
					obj.Freight = objDetails.Freight;
					obj.Salesman2Name = objDetails.Salesman2Name;
					obj.Salesman2Percent = objDetails.Salesman2Percent;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.Part = objDetails.Part;
					obj.DateCode = objDetails.DateCode;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.ProductNo = objDetails.ProductNo;
					obj.PackageNo = objDetails.PackageNo;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ROHS = objDetails.ROHS;
					obj.GoodsInNo = objDetails.GoodsInNo;
					obj.GoodsInNumber = objDetails.GoodsInNumber;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.SalesOrderLineId = objDetails.SalesOrderLineId;
					obj.Price = objDetails.Price;
					obj.CustomerPart = objDetails.CustomerPart;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.SupplierRMANo = objDetails.SupplierRMANo;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.PurchasePrice = objDetails.PurchasePrice;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.SupplierNo = objDetails.SupplierNo;
					obj.PurchaseCurrencyNo = objDetails.PurchaseCurrencyNo;
					obj.PurchaseCurrencyCode = objDetails.PurchaseCurrencyCode;
					obj.SupplierName = objDetails.SupplierName;
					obj.Salesman = objDetails.Salesman;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.Buyer = objDetails.Buyer;
					obj.BuyerName = objDetails.BuyerName;
					obj.QuantityAllocatedToCRMA = objDetails.QuantityAllocatedToCRMA;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_InvoiceLineAllocation]
		/// </summary>
		public static bool Update(System.Int32? invoiceLineAllocationId, System.Int32? invoiceLineNo, System.Int32? quantity, System.Int32? stockNo, System.Int32? salesOrderLineNo, System.Int32? lotNo, System.Double? landedCost, System.Int32? supplierRmaLineNo, System.Int32? warehouseNo, System.String location, System.Int32? goodsInLineNo, System.Int32? purchaseOrderLineNo, System.Int32? customerRmaGoodsInLineNo, System.Int32? countryOfManufactureNo, System.String notes, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLineAllocation.Update(invoiceLineAllocationId, invoiceLineNo, quantity, stockNo, salesOrderLineNo, lotNo, landedCost, supplierRmaLineNo, warehouseNo, location, goodsInLineNo, purchaseOrderLineNo, customerRmaGoodsInLineNo, countryOfManufactureNo, notes, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_InvoiceLineAllocation]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.InvoiceLineAllocation.Update(InvoiceLineAllocationId, InvoiceLineNo, Quantity, StockNo, SalesOrderLineNo, LotNo, LandedCost, SupplierRMALineNo, WarehouseNo, Location, GoodsInLineNo, PurchaseOrderLineNo, CustomerRMAGoodsInLineNo, CountryOfManufactureNo, Notes, UpdatedBy);
		}

        private static InvoiceLineAllocation PopulateFromDBDetailsObject(InvoiceLineAllocationDetails obj) {
            InvoiceLineAllocation objNew = new InvoiceLineAllocation();
			objNew.InvoiceLineAllocationId = obj.InvoiceLineAllocationId;
			objNew.InvoiceLineNo = obj.InvoiceLineNo;
			objNew.Quantity = obj.Quantity;
			objNew.StockNo = obj.StockNo;
			objNew.SalesOrderLineNo = obj.SalesOrderLineNo;
			objNew.LotNo = obj.LotNo;
			objNew.LandedCost = obj.LandedCost;
			objNew.SupplierRMALineNo = obj.SupplierRMALineNo;
			objNew.WarehouseNo = obj.WarehouseNo;
			objNew.Location = obj.Location;
			objNew.GoodsInLineNo = obj.GoodsInLineNo;
			objNew.PurchaseOrderLineNo = obj.PurchaseOrderLineNo;
			objNew.CountryOfManufactureNo = obj.CountryOfManufactureNo;
			objNew.CustomerRMAGoodsInLineNo = obj.CustomerRMAGoodsInLineNo;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.Notes = obj.Notes;
			objNew.LineNotes = obj.LineNotes;
			objNew.CountryOfManufactureName = obj.CountryOfManufactureName;
			objNew.LotName = obj.LotName;
			objNew.WarehouseName = obj.WarehouseName;
			objNew.InvoiceNo = obj.InvoiceNo;
			objNew.ClientNo = obj.ClientNo;
			objNew.InvoiceNumber = obj.InvoiceNumber;
			objNew.InvoiceDate = obj.InvoiceDate;
			objNew.SalesOrderNo = obj.SalesOrderNo;
			objNew.Salesman2 = obj.Salesman2;
			objNew.ShippingCost = obj.ShippingCost;
			objNew.Freight = obj.Freight;
			objNew.Salesman2Name = obj.Salesman2Name;
			objNew.Salesman2Percent = obj.Salesman2Percent;
			objNew.SalesOrderNumber = obj.SalesOrderNumber;
			objNew.CurrencyNo = obj.CurrencyNo;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.CompanyName = obj.CompanyName;
			objNew.Part = obj.Part;
			objNew.DateCode = obj.DateCode;
			objNew.SupplierPart = obj.SupplierPart;
			objNew.ProductNo = obj.ProductNo;
			objNew.PackageNo = obj.PackageNo;
			objNew.ManufacturerNo = obj.ManufacturerNo;
			objNew.ROHS = obj.ROHS;
			objNew.GoodsInNo = obj.GoodsInNo;
			objNew.GoodsInNumber = obj.GoodsInNumber;
			objNew.ManufacturerName = obj.ManufacturerName;
			objNew.ManufacturerCode = obj.ManufacturerCode;
			objNew.PackageName = obj.PackageName;
			objNew.PackageDescription = obj.PackageDescription;
			objNew.ProductName = obj.ProductName;
			objNew.ProductDescription = obj.ProductDescription;
			objNew.SalesOrderLineId = obj.SalesOrderLineId;
			objNew.Price = obj.Price;
			objNew.CustomerPart = obj.CustomerPart;
			objNew.CurrencyCode = obj.CurrencyCode;
			objNew.SupplierRMANo = obj.SupplierRMANo;
			objNew.SupplierRMANumber = obj.SupplierRMANumber;
			objNew.PurchaseOrderNo = obj.PurchaseOrderNo;
			objNew.PurchasePrice = obj.PurchasePrice;
			objNew.PurchaseOrderNumber = obj.PurchaseOrderNumber;
			objNew.SupplierNo = obj.SupplierNo;
			objNew.PurchaseCurrencyNo = obj.PurchaseCurrencyNo;
			objNew.PurchaseCurrencyCode = obj.PurchaseCurrencyCode;
			objNew.SupplierName = obj.SupplierName;
			objNew.Salesman = obj.Salesman;
			objNew.SalesmanName = obj.SalesmanName;
			objNew.Buyer = obj.Buyer;
			objNew.BuyerName = obj.BuyerName;
			objNew.QuantityAllocatedToCRMA = obj.QuantityAllocatedToCRMA;
			objNew.QuantityAllocated = obj.QuantityAllocated;
            return objNew;
        }
		
		#endregion
		
	}
}