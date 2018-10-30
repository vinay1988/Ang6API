//Marker     Changed by      Date         Remarks
//[001]      Vinay           04/09/2012   Print Label
//[002]      Vinay           08/07/2013    Ref:## -32 Nice Label Printing
//[003]      Vinay           28/08/2013    NPR Print
//[004]      Raushan           27/02/2014    GoodsIn - Po serial No.
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
		public partial class GoodsInLine : BizObject {
		
		#region Properties

		protected static DAL.GoodsInLineElement Settings {
			get { return Globals.Settings.GoodsInLines; }
		}

		/// <summary>
		/// GoodsInLineId
		/// </summary>
		public System.Int32 GoodsInLineId { get; set; }		
		/// <summary>
		/// GoodsInNo
		/// </summary>
		public System.Int32 GoodsInNo { get; set; }		
		/// <summary>
		/// PurchaseOrderLineNo
		/// </summary>
		public System.Int32? PurchaseOrderLineNo { get; set; }		
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
		/// Quantity
		/// </summary>
		public System.Int32 Quantity { get; set; }		
		/// <summary>
		/// Price
		/// </summary>
		public System.Double Price { get; set; }		
		/// <summary>
		/// ShipInCost
		/// </summary>
		public System.Double? ShipInCost { get; set; }		
		/// <summary>
		/// QualityControlNotes
		/// </summary>
		public System.String QualityControlNotes { get; set; }		
		/// <summary>
		/// Location
		/// </summary>
		public System.String Location { get; set; }		
		/// <summary>
		/// ProductNo
		/// </summary>
		public System.Int32? ProductNo { get; set; }		
		/// <summary>
		/// LandedCost
		/// </summary>
		public System.Double LandedCost { get; set; }		
		/// <summary>
		/// CustomerRMALineNo
		/// </summary>
		public System.Int32? CustomerRMALineNo { get; set; }		
		/// <summary>
		/// SupplierPart
		/// </summary>
		public System.String SupplierPart { get; set; }		
		/// <summary>
		/// ROHS
		/// </summary>
		public System.Byte? ROHS { get; set; }		
		/// <summary>
		/// CountryOfManufacture
		/// </summary>
		public System.Int32? CountryOfManufacture { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// InspectedBy
		/// </summary>
		public System.Int32? InspectedBy { get; set; }		
		/// <summary>
		/// DateInspected
		/// </summary>
		public System.DateTime? DateInspected { get; set; }		
		/// <summary>
		/// CountingMethodNo
		/// </summary>
		public System.Int32? CountingMethodNo { get; set; }		
		/// <summary>
		/// SerialNosRecorded
		/// </summary>
		public System.Boolean? SerialNosRecorded { get; set; }		
		/// <summary>
		/// Unavailable
		/// </summary>
		public System.Boolean? Unavailable { get; set; }		
		/// <summary>
		/// LotNo
		/// </summary>
		public System.Int32? LotNo { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// PartMarkings
		/// </summary>
		public System.String PartMarkings { get; set; }		
		/// <summary>
		/// FullSupplierPart
		/// </summary>
		public System.String FullSupplierPart { get; set; }		
		/// <summary>
		/// GoodsInId
		/// </summary>
		public System.Int32 GoodsInId { get; set; }		
		/// <summary>
		/// GoodsInNumber
		/// </summary>
		public System.Int32 GoodsInNumber { get; set; }		
		/// <summary>
		/// ManufacturerCode
		/// </summary>
		public System.String ManufacturerCode { get; set; }		
		/// <summary>
		/// DateReceived
		/// </summary>
		public System.DateTime DateReceived { get; set; }		
		/// <summary>
		/// ReceiverName
		/// </summary>
		public System.String ReceiverName { get; set; }		
		/// <summary>
		/// PurchaseOrderNo
		/// </summary>
		public System.Int32? PurchaseOrderNo { get; set; }		
		/// <summary>
		/// DeliveryDate
		/// </summary>
		public System.DateTime? DeliveryDate { get; set; }		
		/// <summary>
		/// PurchaseOrderNumber
		/// </summary>
		public System.Int32? PurchaseOrderNumber { get; set; }		
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32 CompanyNo { get; set; }		
		/// <summary>
		/// CompanyName
		/// </summary>
		public System.String CompanyName { get; set; }		
		/// <summary>
		/// AirWayBill
		/// </summary>
		public System.String AirWayBill { get; set; }		
		/// <summary>
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }		
		/// <summary>
		/// RowCnt
		/// </summary>
		public System.Int32? RowCnt { get; set; }		
		/// <summary>
		/// QuantityOrdered
		/// </summary>
		public System.Int32 QuantityOrdered { get; set; }		
		/// <summary>
		/// ContactNo
		/// </summary>
		public System.Int32 ContactNo { get; set; }		
		/// <summary>
		/// ContactName
		/// </summary>
		public System.String ContactName { get; set; }		
		/// <summary>
		/// SupplierInvoice
		/// </summary>
		public System.String SupplierInvoice { get; set; }		
		/// <summary>
		/// InvoiceAmount
		/// </summary>
		public System.Double? InvoiceAmount { get; set; }		
		/// <summary>
		/// CurrencyNo
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }		
		/// <summary>
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }		
		/// <summary>
		/// CountingMethodDescription
		/// </summary>
		public System.String CountingMethodDescription { get; set; }		
		/// <summary>
		/// LineNotes
		/// </summary>
		public System.String LineNotes { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
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
		/// ProductDutyCode
		/// </summary>
		public System.String ProductDutyCode { get; set; }		
		/// <summary>
		/// ManufacturerName
		/// </summary>
		public System.String ManufacturerName { get; set; }		
		/// <summary>
		/// CountryOfManufactureName
		/// </summary>
		public System.String CountryOfManufactureName { get; set; }		
		/// <summary>
		/// InspectorName
		/// </summary>
		public System.String InspectorName { get; set; }		
		/// <summary>
		/// CustomerRMANo
		/// </summary>
		public System.Int32? CustomerRMANo { get; set; }		
		/// <summary>
		/// CustomerRMANumber
		/// </summary>
		public System.Int32? CustomerRMANumber { get; set; }		
		/// <summary>
		/// CurrencyDescription
		/// </summary>
		public System.String CurrencyDescription { get; set; }		
		/// <summary>
		/// ReceivedBy
		/// </summary>
		public System.Int32 ReceivedBy { get; set; }		
		/// <summary>
		/// DivisionNo
		/// </summary>
		public System.Int32? DivisionNo { get; set; }		
		/// <summary>
		/// TeamNo
		/// </summary>
		public System.Int32? TeamNo { get; set; }		
		/// <summary>
		/// StockNo
		/// </summary>
		public System.Int32? StockNo { get; set; }		
		/// <summary>
		/// Reference
		/// </summary>
		public System.String Reference { get; set; }		
		/// <summary>
		/// LotName
		/// </summary>
		public System.String LotName { get; set; }		
		/// <summary>
		/// PurchaseOrderLineShipInCost
		/// </summary>
		public System.Double PurchaseOrderLineShipInCost { get; set; }		
		/// <summary>
		/// ChangedFields
		/// </summary>
		public System.String ChangedFields { get; set; }		
		/// <summary>
		/// UpdateStock
		/// </summary>
		public System.Boolean? UpdateStock { get; set; }		
		/// <summary>
		/// UpdateShipments
		/// </summary>
		public System.Boolean? UpdateShipments { get; set; }
        //[001] code start
        /// <summary>
        /// CustomerPart
        /// </summary>
        public System.String CustomerPart { get; set; }
        /// <summary>
        /// SalesOrderNumber
        /// </summary>
        public System.Int32? SalesOrderNumber { get; set; }
        /// <summary>
        /// DatePicked
        /// </summary>
        public System.DateTime DatePicked { get; set; }
        /// <summary>
        /// InspectedByUser
        /// </summary>
        public System.String InspectedByUser { get; set; }
        //[001] code end
        /// <summary>
        /// HasAllocationOutward
        /// </summary>
        public System.Boolean? HasAllocationOutward { get; set; }
        /// <summary>
        /// NPRPrinted
        /// </summary>
        public System.Boolean? NPRPrinted { get; set; }
      
        //[002] code start
        /// <summary>
        /// InspectorNameLabel
        /// </summary>
        public System.String InspectorNameLabel { get; set; }
        //[002] code end
        //[003] code start
        /// <summary>
        /// NPRIds
        /// </summary>
        public System.String NPRIds { get; set; }
        /// <summary>
        /// NPRNos
        /// </summary>
        public System.String NPRNos { get; set; }
        //[003] code end

        /// SupplierInvoiceExists
        /// </summary>
        public System.Boolean HasSupplierInvoiceExists { get; set; }

        /// HasStocksplit
        /// </summary>
        public System.Boolean HasStocksplit { get; set; }
        /// <summary>
        /// blnStockProvision
        /// </summary>
        public System.Boolean blnStockProvision { get; set; }
        /// <summary>
        /// PhysicalInspectedBy
        /// </summary>
        public System.Int32? PhysicalInspectedBy { get; set; }
        /// <summary>
        /// DatePhysicalInspected
        /// </summary>
        public System.DateTime? DatePhysicalInspected { get; set; }
        /// <summary>
        /// LotCode
        /// </summary>
        public System.String LotCode { get; set; }
        //[004] code start
        /// <summary>
        /// POSerialNo
        /// </summary>
        public System.Int16? POSerialNo { get; set; }

        //[004] code End

        public int? InternalPurchaseOrderNumber { get; set; }
        public int? InternalPurchaseOrderId { get; set; }
        public int? IPOSupplier { get; set; }
        public string IPOSupplierName { get; set; }
        /// <summary>
        /// ClientPrice (from Table)
        /// </summary>
        public System.Double ClientPrice { get; set; }

        public string ClientName { get; set; }
        /// <summary>
        /// ClientLandedCost
        /// </summary>
        public System.Double ClientLandedCost { get; set; }
        public System.Int32? ClientCurrencyNo { get; set; }
        public System.String ClientCurrencyCode { get; set; }
        public System.Int32? IPOClientNo { get; set; }
        public System.Double? POBankFee { get; set; }
        /// <summary>
        /// CustomerPO
        /// </summary>
        public System.String CustomerPO { get; set; }	
        public System.DateTime? StockDate { get; set; }
        public System.Double? DutyRate { get; set; }

        public System.String SerialNo { get; set; }
        public System.Int32? SerialNoId { get; set; }
        public System.String SubGroup { get; set; }
        public System.Boolean? ReqSerialNo { get; set; }
        public System.Int32? SerialNoCount { get; set; }
        public System.String Status { get; set; }
        public System.Int32? InvoiceLineNo { get; set; }
        public System.String MSLLevel { get; set; }
        public System.String ReasonDate { get; set; }	
        public System.String ReasonCode { get; set; }
        public System.Boolean? IsProdHazardous { get; set; }
        public System.Boolean? PrintHazardous { get; set; }
        public System.Int32 GIShipCostHistoryId { get; set; }
		#endregion
		
		#region Methods
		
		/// <summary>
		/// CountForPurchaseOrderLine
		/// Calls [usp_count_GoodsInLine_for_PurchaseOrderLine]
		/// </summary>
		public static Int32 CountForPurchaseOrderLine(System.Int32? purchaseOrderLineId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.CountForPurchaseOrderLine(purchaseOrderLineId);
		}		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_GoodsInLine]
		/// </summary>
        public static List<GoodsInLine> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String cmSearch, System.Int32? receivedBy, System.String airWayBill, System.Boolean? includeInvoiced, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? goodsInNoLo, System.Int32? goodsInNoHi, System.DateTime? dateReceivedFrom, System.DateTime? dateReceivedTo, System.String supplierInvoice, System.String reference, System.Boolean? recentOnly, System.Boolean? uninspectedOnly, System.Int32? clientSearch, int? IsPoHub, Boolean IsGlobalLogin)
        {
			List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.DataListNugget(clientId, orderBy, sortDir, pageIndex, pageSize, partSearch, cmSearch, receivedBy, airWayBill, includeInvoiced, purchaseOrderNoLo, purchaseOrderNoHi, goodsInNoLo, goodsInNoHi, dateReceivedFrom, dateReceivedTo, supplierInvoice, reference, recentOnly, uninspectedOnly, clientSearch, IsPoHub,IsGlobalLogin);
			if (lstDetails == null) {
				return new List<GoodsInLine>();
			} else {
				List<GoodsInLine> lst = new List<GoodsInLine>();
				foreach (GoodsInLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.GoodsInLine obj = new Rebound.GlobalTrader.BLL.GoodsInLine();
					obj.GoodsInId = objDetails.GoodsInId;
					obj.GoodsInNumber = objDetails.GoodsInNumber;
					obj.Part = objDetails.Part;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.Quantity = objDetails.Quantity;
					obj.DateReceived = objDetails.DateReceived;
					obj.ReceiverName = objDetails.ReceiverName;
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.DeliveryDate = objDetails.DeliveryDate;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.ROHS = objDetails.ROHS;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.AirWayBill = objDetails.AirWayBill;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
                    obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
                    obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
                    obj.IPOSupplier = objDetails.IPOSupplier;
                    obj.IPOSupplierName = objDetails.IPOSupplierName;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.ClientName = objDetails.ClientName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// DataListNuggetAsReceivedPO
		/// Calls [usp_datalistnugget_GoodsInLine_AsReceivedPO]
		/// </summary>
		public static List<GoodsInLine> DataListNuggetAsReceivedPO(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.String partSearch, System.Boolean? recentOnly, System.String cmSearch, System.String contactSearch, System.Int32? buyerSearch, System.DateTime? receivedDateFrom, System.DateTime? receivedDateTo, System.String airWayBill, System.String supplierPartSearch, System.String reference,bool? isPoHub) {
            List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.DataListNuggetAsReceivedPO(clientId, teamId, divisionId, loginId, pageIndex, pageSize, orderBy, sortDir, purchaseOrderNoLo, purchaseOrderNoHi, partSearch, recentOnly, cmSearch, contactSearch, buyerSearch, receivedDateFrom, receivedDateTo, airWayBill, supplierPartSearch, reference, isPoHub);
			if (lstDetails == null) {
				return new List<GoodsInLine>();
			} else {
				List<GoodsInLine> lst = new List<GoodsInLine>();
				foreach (GoodsInLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.GoodsInLine obj = new Rebound.GlobalTrader.BLL.GoodsInLine();
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.QuantityOrdered = objDetails.QuantityOrdered;
					obj.GoodsInNo = objDetails.GoodsInNo;
					obj.GoodsInNumber = objDetails.GoodsInNumber;
					obj.DateReceived = objDetails.DateReceived;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.Quantity = objDetails.Quantity;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.SupplierInvoice = objDetails.SupplierInvoice;
					obj.AirWayBill = objDetails.AirWayBill;
					obj.InvoiceAmount = objDetails.InvoiceAmount;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Delete
		/// Calls [usp_delete_GoodsInLine]
		/// </summary>
		public static bool Delete(System.Int32? goodsInLineId, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.Delete(goodsInLineId, updatedBy);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_GoodsInLine]
		/// </summary>
        public static Int32 Insert(System.Int32? goodsInNo, System.Int32? purchaseOrderLineNo, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Double? shipInCost, System.String qualityControlNotes, System.String location, System.Int32? lotNo, System.Int32? productNo, System.Int32? currencyNo, System.Int32? customerRmaLineNo, System.String supplierPart, System.Byte? rohs, System.Int32? countryOfManufacture, System.Boolean? unavailable, System.String notes, System.String changedFields, System.Int32? countingMethodNo, System.Boolean? serialNosRecorded, System.String partMarkings, System.Int32? updatedBy, System.Double? clientPrice, System.Boolean? reqSerialNo)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.Insert(goodsInNo, purchaseOrderLineNo, part, manufacturerNo, dateCode, packageNo, quantity, price, shipInCost, qualityControlNotes, location, lotNo, productNo, currencyNo, customerRmaLineNo, supplierPart, rohs, countryOfManufacture, unavailable, notes, changedFields, countingMethodNo, serialNosRecorded, partMarkings, updatedBy, clientPrice, reqSerialNo);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_GoodsInLine]
		/// </summary>
		public Int32 Insert() {
            return Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.Insert(GoodsInNo, PurchaseOrderLineNo, Part, ManufacturerNo, DateCode, PackageNo, Quantity, Price, ShipInCost, QualityControlNotes, Location, LotNo, ProductNo, CurrencyNo, CustomerRMALineNo, SupplierPart, ROHS, CountryOfManufacture, Unavailable, Notes, ChangedFields, CountingMethodNo, SerialNosRecorded, PartMarkings, UpdatedBy, ClientPrice, ReqSerialNo);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_GoodsInLine]
		/// </summary>
		public static GoodsInLine Get(System.Int32? goodsInLineId) {
			Rebound.GlobalTrader.DAL.GoodsInLineDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.Get(goodsInLineId);
			if (objDetails == null) {
				return null;
			} else {
				GoodsInLine obj = new GoodsInLine();
				obj.GoodsInLineId = objDetails.GoodsInLineId;
				obj.GoodsInNo = objDetails.GoodsInNo;
				obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
				obj.FullPart = objDetails.FullPart;
				obj.Part = objDetails.Part;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.DateCode = objDetails.DateCode;
				obj.PackageNo = objDetails.PackageNo;
				obj.Quantity = objDetails.Quantity;
				obj.Price = objDetails.Price;
				obj.ShipInCost = objDetails.ShipInCost;
				obj.QualityControlNotes = objDetails.QualityControlNotes;
				obj.Location = objDetails.Location;
				obj.ProductNo = objDetails.ProductNo;
				obj.LandedCost = objDetails.LandedCost;
				obj.CustomerRMALineNo = objDetails.CustomerRMALineNo;
				obj.SupplierPart = objDetails.SupplierPart;
				obj.ROHS = objDetails.ROHS;
				obj.CountryOfManufacture = objDetails.CountryOfManufacture;
				obj.InspectedBy = objDetails.InspectedBy;
				obj.DateInspected = objDetails.DateInspected;
				obj.CountingMethodNo = objDetails.CountingMethodNo;
				obj.CountingMethodDescription = objDetails.CountingMethodDescription;
				obj.SerialNosRecorded = objDetails.SerialNosRecorded;
				obj.PartMarkings = objDetails.PartMarkings;
				obj.Unavailable = objDetails.Unavailable;
				obj.LotNo = objDetails.LotNo;
				obj.LineNotes = objDetails.LineNotes;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.GoodsInNumber = objDetails.GoodsInNumber;
				obj.ClientNo = objDetails.ClientNo;
				obj.AirWayBill = objDetails.AirWayBill;
				obj.PackageName = objDetails.PackageName;
				obj.PackageDescription = objDetails.PackageDescription;
				obj.ProductName = objDetails.ProductName;
				obj.ProductDescription = objDetails.ProductDescription;
				obj.ProductDutyCode = objDetails.ProductDutyCode;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.ManufacturerCode = objDetails.ManufacturerCode;
				obj.CountryOfManufactureName = objDetails.CountryOfManufactureName;
				obj.DateReceived = objDetails.DateReceived;
				obj.InspectorName = objDetails.InspectorName;
				obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
				obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
				obj.CustomerRMANo = objDetails.CustomerRMANo;
				obj.CustomerRMANumber = objDetails.CustomerRMANumber;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyDescription = objDetails.CurrencyDescription;
				obj.ReceivedBy = objDetails.ReceivedBy;
				obj.ReceiverName = objDetails.ReceiverName;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.TeamNo = objDetails.TeamNo;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.StockNo = objDetails.StockNo;
				obj.SupplierInvoice = objDetails.SupplierInvoice;
				obj.Reference = objDetails.Reference;
				obj.LotName = objDetails.LotName;
				obj.QuantityOrdered = objDetails.QuantityOrdered;
				obj.PurchaseOrderLineShipInCost = objDetails.PurchaseOrderLineShipInCost;
				obj.ChangedFields = objDetails.ChangedFields;
				obj.UpdateStock = objDetails.UpdateStock;
				obj.UpdateShipments = objDetails.UpdateShipments;
                obj.HasAllocationOutward = objDetails.HasAllocationOutward;
                obj.CustomerPart = objDetails.CustomerPart;
                obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                obj.NPRPrinted = objDetails.NPRPrinted;
                //[002] code start
                obj.InspectorNameLabel = objDetails.InspectorNameLabel;
                //[002] code end

                //[003] code start
                obj.NPRIds = objDetails.NPRIds;
                obj.NPRNos = objDetails.NPRNos;
                //[003] code end
                obj.HasStocksplit = objDetails.HasStocksplit;
                obj.HasSupplierInvoiceExists = objDetails.HasSupplierInvoiceExists;
                obj.blnStockProvision = objDetails.blnStockProvision;
                obj.LotCode = objDetails.LotCode;
                obj.ClientLandedCost = objDetails.ClientLandedCost;
                obj.ClientPrice = objDetails.ClientPrice;
                obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
                obj.ClientCurrencyNo = objDetails.ClientCurrencyNo;
                obj.ClientCurrencyCode = objDetails.ClientCurrencyCode;
                obj.IPOClientNo = objDetails.IPOClientNo;
                obj.POBankFee = objDetails.POBankFee;
                obj.CustomerPO = objDetails.CustomerPO;
                obj.StockDate = objDetails.StockDate;
                obj.ProductInactive = objDetails.ProductInactive;
                obj.DutyRate = objDetails.DutyRate;
                obj.ReqSerialNo = objDetails.ReqSerialNo;
                obj.SerialNoCount = objDetails.SerialNoCount;
                obj.MSLLevel = objDetails.MSLLevel;
                obj.IsProdHazardous = objDetails.IsProdHazardous;
                obj.PrintHazardous = objDetails.PrintHazardous;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForCustomerRMA
		/// Calls [usp_selectAll_GoodsInLine_for_CustomerRMA]
		/// </summary>
		public static List<GoodsInLine> GetListForCustomerRMA(System.Int32? customerRmaId) {
			List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.GetListForCustomerRMA(customerRmaId);
			if (lstDetails == null) {
				return new List<GoodsInLine>();
			} else {
				List<GoodsInLine> lst = new List<GoodsInLine>();
				foreach (GoodsInLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.GoodsInLine obj = new Rebound.GlobalTrader.BLL.GoodsInLine();
					obj.GoodsInLineId = objDetails.GoodsInLineId;
					obj.GoodsInNo = objDetails.GoodsInNo;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.DateCode = objDetails.DateCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.Quantity = objDetails.Quantity;
					obj.Price = objDetails.Price;
					obj.ShipInCost = objDetails.ShipInCost;
					obj.QualityControlNotes = objDetails.QualityControlNotes;
					obj.Location = objDetails.Location;
					obj.ProductNo = objDetails.ProductNo;
					obj.LandedCost = objDetails.LandedCost;
					obj.CustomerRMALineNo = objDetails.CustomerRMALineNo;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.ROHS = objDetails.ROHS;
					obj.CountryOfManufacture = objDetails.CountryOfManufacture;
					obj.InspectedBy = objDetails.InspectedBy;
					obj.DateInspected = objDetails.DateInspected;
					obj.CountingMethodNo = objDetails.CountingMethodNo;
					obj.CountingMethodDescription = objDetails.CountingMethodDescription;
					obj.SerialNosRecorded = objDetails.SerialNosRecorded;
					obj.PartMarkings = objDetails.PartMarkings;
					obj.Unavailable = objDetails.Unavailable;
					obj.LotNo = objDetails.LotNo;
					obj.LineNotes = objDetails.LineNotes;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.GoodsInNumber = objDetails.GoodsInNumber;
					obj.ClientNo = objDetails.ClientNo;
					obj.AirWayBill = objDetails.AirWayBill;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.ProductDutyCode = objDetails.ProductDutyCode;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.CountryOfManufactureName = objDetails.CountryOfManufactureName;
					obj.DateReceived = objDetails.DateReceived;
					obj.InspectorName = objDetails.InspectorName;
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.CustomerRMANo = objDetails.CustomerRMANo;
					obj.CustomerRMANumber = objDetails.CustomerRMANumber;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.ReceivedBy = objDetails.ReceivedBy;
					obj.ReceiverName = objDetails.ReceiverName;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.TeamNo = objDetails.TeamNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.StockNo = objDetails.StockNo;
					obj.SupplierInvoice = objDetails.SupplierInvoice;
					obj.Reference = objDetails.Reference;
					obj.LotName = objDetails.LotName;
					obj.QuantityOrdered = objDetails.QuantityOrdered;
					obj.PurchaseOrderLineShipInCost = objDetails.PurchaseOrderLineShipInCost;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForCustomerRMALine
		/// Calls [usp_selectAll_GoodsInLine_for_CustomerRMALine]
		/// </summary>
		public static List<GoodsInLine> GetListForCustomerRMALine(System.Int32? customerRmaLineId) {
			List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.GetListForCustomerRMALine(customerRmaLineId);
			if (lstDetails == null) {
				return new List<GoodsInLine>();
			} else {
				List<GoodsInLine> lst = new List<GoodsInLine>();
				foreach (GoodsInLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.GoodsInLine obj = new Rebound.GlobalTrader.BLL.GoodsInLine();
					obj.GoodsInLineId = objDetails.GoodsInLineId;
					obj.GoodsInNo = objDetails.GoodsInNo;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.DateCode = objDetails.DateCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.Quantity = objDetails.Quantity;
					obj.Price = objDetails.Price;
					obj.ShipInCost = objDetails.ShipInCost;
					obj.QualityControlNotes = objDetails.QualityControlNotes;
					obj.Location = objDetails.Location;
					obj.ProductNo = objDetails.ProductNo;
					obj.LandedCost = objDetails.LandedCost;
					obj.CustomerRMALineNo = objDetails.CustomerRMALineNo;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.ROHS = objDetails.ROHS;
					obj.CountryOfManufacture = objDetails.CountryOfManufacture;
					obj.InspectedBy = objDetails.InspectedBy;
					obj.DateInspected = objDetails.DateInspected;
					obj.CountingMethodNo = objDetails.CountingMethodNo;
					obj.CountingMethodDescription = objDetails.CountingMethodDescription;
					obj.SerialNosRecorded = objDetails.SerialNosRecorded;
					obj.PartMarkings = objDetails.PartMarkings;
					obj.Unavailable = objDetails.Unavailable;
					obj.LotNo = objDetails.LotNo;
					obj.LineNotes = objDetails.LineNotes;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.GoodsInNumber = objDetails.GoodsInNumber;
					obj.ClientNo = objDetails.ClientNo;
					obj.AirWayBill = objDetails.AirWayBill;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.ProductDutyCode = objDetails.ProductDutyCode;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.CountryOfManufactureName = objDetails.CountryOfManufactureName;
					obj.DateReceived = objDetails.DateReceived;
					obj.InspectorName = objDetails.InspectorName;
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.CustomerRMANo = objDetails.CustomerRMANo;
					obj.CustomerRMANumber = objDetails.CustomerRMANumber;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.ReceivedBy = objDetails.ReceivedBy;
					obj.ReceiverName = objDetails.ReceiverName;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.TeamNo = objDetails.TeamNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.StockNo = objDetails.StockNo;
					obj.SupplierInvoice = objDetails.SupplierInvoice;
					obj.Reference = objDetails.Reference;
					obj.LotName = objDetails.LotName;
					obj.QuantityOrdered = objDetails.QuantityOrdered;
					obj.PurchaseOrderLineShipInCost = objDetails.PurchaseOrderLineShipInCost;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForGoodsIn
		/// Calls [usp_selectAll_GoodsInLine_for_GoodsIn]
		/// </summary>
		public static List<GoodsInLine> GetListForGoodsIn(System.Int32? goodsInId, System.Int32? pageIndex, System.Int32? pageSize) {
			List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.GetListForGoodsIn(goodsInId, pageIndex, pageSize);
			if (lstDetails == null) {
				return new List<GoodsInLine>();
			} else {
				List<GoodsInLine> lst = new List<GoodsInLine>();
				foreach (GoodsInLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.GoodsInLine obj = new Rebound.GlobalTrader.BLL.GoodsInLine();
					obj.GoodsInLineId = objDetails.GoodsInLineId;
					obj.GoodsInNo = objDetails.GoodsInNo;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.DateCode = objDetails.DateCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.Quantity = objDetails.Quantity;
					obj.Price = objDetails.Price;
					obj.ShipInCost = objDetails.ShipInCost;
					obj.QualityControlNotes = objDetails.QualityControlNotes;
					obj.Location = objDetails.Location;
					obj.ProductNo = objDetails.ProductNo;
					obj.LandedCost = objDetails.LandedCost;
					obj.CustomerRMALineNo = objDetails.CustomerRMALineNo;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.ROHS = objDetails.ROHS;
					obj.CountryOfManufacture = objDetails.CountryOfManufacture;
					obj.InspectedBy = objDetails.InspectedBy;
					obj.DateInspected = objDetails.DateInspected;
					obj.CountingMethodNo = objDetails.CountingMethodNo;
					obj.CountingMethodDescription = objDetails.CountingMethodDescription;
					obj.SerialNosRecorded = objDetails.SerialNosRecorded;
					obj.PartMarkings = objDetails.PartMarkings;
					obj.Unavailable = objDetails.Unavailable;
					obj.LotNo = objDetails.LotNo;
					obj.LineNotes = objDetails.LineNotes;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.GoodsInNumber = objDetails.GoodsInNumber;
					obj.ClientNo = objDetails.ClientNo;
					obj.AirWayBill = objDetails.AirWayBill;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.ProductDutyCode = objDetails.ProductDutyCode;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.CountryOfManufactureName = objDetails.CountryOfManufactureName;
					obj.DateReceived = objDetails.DateReceived;
					obj.InspectorName = objDetails.InspectorName;
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.CustomerRMANo = objDetails.CustomerRMANo;
					obj.CustomerRMANumber = objDetails.CustomerRMANumber;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.ReceivedBy = objDetails.ReceivedBy;
					obj.ReceiverName = objDetails.ReceiverName;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.TeamNo = objDetails.TeamNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.StockNo = objDetails.StockNo;
					obj.SupplierInvoice = objDetails.SupplierInvoice;
					obj.Reference = objDetails.Reference;
					obj.LotName = objDetails.LotName;
					obj.QuantityOrdered = objDetails.QuantityOrdered;
					obj.PurchaseOrderLineShipInCost = objDetails.PurchaseOrderLineShipInCost;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
                    obj.PhysicalInspectedBy = objDetails.PhysicalInspectedBy;
                    obj.DatePhysicalInspected = objDetails.DatePhysicalInspected;
                    //[004] code start
                    obj.POSerialNo = objDetails.POSerialNo;
                    //[004] code End
                    obj.ClientLandedCost = objDetails.ClientLandedCost;
                    obj.ClientPrice = objDetails.ClientPrice;
                    obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForPurchaseOrder
		/// Calls [usp_selectAll_GoodsInLine_for_PurchaseOrder]
		/// </summary>
		public static List<GoodsInLine> GetListForPurchaseOrder(System.Int32? purchaseOrderId) {
			List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.GetListForPurchaseOrder(purchaseOrderId);
			if (lstDetails == null) {
				return new List<GoodsInLine>();
			} else {
				List<GoodsInLine> lst = new List<GoodsInLine>();
				foreach (GoodsInLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.GoodsInLine obj = new Rebound.GlobalTrader.BLL.GoodsInLine();
					obj.GoodsInLineId = objDetails.GoodsInLineId;
					obj.GoodsInNo = objDetails.GoodsInNo;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.DateCode = objDetails.DateCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.Quantity = objDetails.Quantity;
					obj.Price = objDetails.Price;
					obj.ShipInCost = objDetails.ShipInCost;
					obj.QualityControlNotes = objDetails.QualityControlNotes;
					obj.Location = objDetails.Location;
					obj.ProductNo = objDetails.ProductNo;
					obj.LandedCost = objDetails.LandedCost;
					obj.CustomerRMALineNo = objDetails.CustomerRMALineNo;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.ROHS = objDetails.ROHS;
					obj.CountryOfManufacture = objDetails.CountryOfManufacture;
					obj.InspectedBy = objDetails.InspectedBy;
					obj.DateInspected = objDetails.DateInspected;
					obj.CountingMethodNo = objDetails.CountingMethodNo;
					obj.CountingMethodDescription = objDetails.CountingMethodDescription;
					obj.SerialNosRecorded = objDetails.SerialNosRecorded;
					obj.PartMarkings = objDetails.PartMarkings;
					obj.Unavailable = objDetails.Unavailable;
					obj.LotNo = objDetails.LotNo;
					obj.LineNotes = objDetails.LineNotes;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.GoodsInNumber = objDetails.GoodsInNumber;
					obj.ClientNo = objDetails.ClientNo;
					obj.AirWayBill = objDetails.AirWayBill;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.ProductDutyCode = objDetails.ProductDutyCode;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.CountryOfManufactureName = objDetails.CountryOfManufactureName;
					obj.DateReceived = objDetails.DateReceived;
					obj.InspectorName = objDetails.InspectorName;
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.CustomerRMANo = objDetails.CustomerRMANo;
					obj.CustomerRMANumber = objDetails.CustomerRMANumber;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.ReceivedBy = objDetails.ReceivedBy;
					obj.ReceiverName = objDetails.ReceiverName;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.TeamNo = objDetails.TeamNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.StockNo = objDetails.StockNo;
					obj.SupplierInvoice = objDetails.SupplierInvoice;
					obj.Reference = objDetails.Reference;
					obj.LotName = objDetails.LotName;
					obj.QuantityOrdered = objDetails.QuantityOrdered;
					obj.PurchaseOrderLineShipInCost = objDetails.PurchaseOrderLineShipInCost;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForPurchaseOrderLine
        /// Calls [usp_selectAll_GoodsInLine_for_PurchaseOrderLine]
		/// </summary>
		public static List<GoodsInLine> GetListForPurchaseOrderLine(System.Int32? purchaseOrderLineId) {
			List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.GetListForPurchaseOrderLine(purchaseOrderLineId);
			if (lstDetails == null) {
				return new List<GoodsInLine>();
			} else {
				List<GoodsInLine> lst = new List<GoodsInLine>();
				foreach (GoodsInLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.GoodsInLine obj = new Rebound.GlobalTrader.BLL.GoodsInLine();
					obj.GoodsInLineId = objDetails.GoodsInLineId;
					obj.GoodsInNumber = objDetails.GoodsInNumber;
					obj.GoodsInNo = objDetails.GoodsInNo;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.SupplierPart = objDetails.SupplierPart;
					obj.DateCode = objDetails.DateCode;
					obj.ProductName = objDetails.ProductName;
					obj.ProductNo = objDetails.ProductNo;
					obj.PackageNo = objDetails.PackageNo;
					obj.PackageName = objDetails.PackageName;
					obj.Quantity = objDetails.Quantity;
					obj.Price = objDetails.Price;
					obj.Location = objDetails.Location;
					obj.DateReceived = objDetails.DateReceived;
					obj.StockNo = objDetails.StockNo;
					obj.ReceiverName = objDetails.ReceiverName;
					obj.LandedCost = objDetails.LandedCost;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.ManufacturerName = objDetails.ManufacturerName;
                    obj.ClientLandedCost = objDetails.ClientLandedCost;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_GoodsInLine]
		/// </summary>
        public static bool Update(System.Int32? goodsInLineId, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? quantity, System.Double? price, System.Double? shipInCost, System.String qualityControlNotes, System.String location, System.Int32? lotNo, System.Int32? productNo, System.String supplierPart, System.Byte? rohs, System.Int32? countryOfManufacture, System.Int32? currencyNo, System.Boolean? unavailable, System.String changedFields, System.String notes, System.Int32? countingMethodNo, System.Boolean? serialNosRecorded, System.String partMarkings, System.Boolean? updateStock, System.Boolean? updateShipments, System.Int32? updatedBy, System.Double? clientPrice, System.Boolean? reqSerialNo, System.String mslLevel, System.Boolean? printHazardous)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.Update(goodsInLineId, part, manufacturerNo, dateCode, packageNo, quantity, price, shipInCost, qualityControlNotes, location, lotNo, productNo, supplierPart, rohs, countryOfManufacture, currencyNo, unavailable, changedFields, notes, countingMethodNo, serialNosRecorded, partMarkings, updateStock, updateShipments, updatedBy, clientPrice, reqSerialNo, mslLevel, printHazardous);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_GoodsInLine]
		/// </summary>
		public bool Update() {
            return Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.Update(GoodsInLineId, Part, ManufacturerNo, DateCode, PackageNo, Quantity, Price, ShipInCost, QualityControlNotes, Location, LotNo, ProductNo, SupplierPart, ROHS, CountryOfManufacture, CurrencyNo, Unavailable, ChangedFields, Notes, CountingMethodNo, SerialNosRecorded, PartMarkings, UpdateStock, UpdateShipments, UpdatedBy, ClientPrice, ReqSerialNo, MSLLevel, PrintHazardous);
		}
		/// <summary>
		/// UpdateInspect
		/// Calls [usp_update_GoodsInLine_Inspect]
		/// </summary>
		public static bool UpdateInspect(System.Int32? goodsInLineId, System.Int32? inspectedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.UpdateInspect(goodsInLineId, inspectedBy);
		}
        /// <summary>
        /// calls [usp_update_GoodsInLine_PhysicalInspect]
        /// </summary>
        /// <param name="goodsInLineId"></param>
        /// <param name="inspectedBy"></param>
        /// <returns></returns>
        public static bool UpdatePhysicalInspect(System.Int32? goodsInLineId, System.Int32? inspectedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.UpdatePhysicalInspect(goodsInLineId, inspectedBy);
        }

        private static GoodsInLine PopulateFromDBDetailsObject(GoodsInLineDetails obj) {
            GoodsInLine objNew = new GoodsInLine();
			objNew.GoodsInLineId = obj.GoodsInLineId;
			objNew.GoodsInNo = obj.GoodsInNo;
			objNew.PurchaseOrderLineNo = obj.PurchaseOrderLineNo;
			objNew.FullPart = obj.FullPart;
			objNew.Part = obj.Part;
			objNew.ManufacturerNo = obj.ManufacturerNo;
			objNew.DateCode = obj.DateCode;
			objNew.PackageNo = obj.PackageNo;
			objNew.Quantity = obj.Quantity;
			objNew.Price = obj.Price;
			objNew.ShipInCost = obj.ShipInCost;
			objNew.QualityControlNotes = obj.QualityControlNotes;
			objNew.Location = obj.Location;
			objNew.ProductNo = obj.ProductNo;
			objNew.LandedCost = obj.LandedCost;
			objNew.CustomerRMALineNo = obj.CustomerRMALineNo;
			objNew.SupplierPart = obj.SupplierPart;
			objNew.ROHS = obj.ROHS;
			objNew.CountryOfManufacture = obj.CountryOfManufacture;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.InspectedBy = obj.InspectedBy;
			objNew.DateInspected = obj.DateInspected;
			objNew.CountingMethodNo = obj.CountingMethodNo;
			objNew.SerialNosRecorded = obj.SerialNosRecorded;
			objNew.Unavailable = obj.Unavailable;
			objNew.LotNo = obj.LotNo;
			objNew.Notes = obj.Notes;
			objNew.PartMarkings = obj.PartMarkings;
			objNew.FullSupplierPart = obj.FullSupplierPart;
			objNew.GoodsInId = obj.GoodsInId;
			objNew.GoodsInNumber = obj.GoodsInNumber;
			objNew.ManufacturerCode = obj.ManufacturerCode;
			objNew.DateReceived = obj.DateReceived;
			objNew.ReceiverName = obj.ReceiverName;
			objNew.PurchaseOrderNo = obj.PurchaseOrderNo;
			objNew.DeliveryDate = obj.DeliveryDate;
			objNew.PurchaseOrderNumber = obj.PurchaseOrderNumber;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.CompanyName = obj.CompanyName;
			objNew.AirWayBill = obj.AirWayBill;
			objNew.RowNum = obj.RowNum;
			objNew.RowCnt = obj.RowCnt;
			objNew.QuantityOrdered = obj.QuantityOrdered;
			objNew.ContactNo = obj.ContactNo;
			objNew.ContactName = obj.ContactName;
			objNew.SupplierInvoice = obj.SupplierInvoice;
			objNew.InvoiceAmount = obj.InvoiceAmount;
			objNew.CurrencyNo = obj.CurrencyNo;
			objNew.CurrencyCode = obj.CurrencyCode;
			objNew.CountingMethodDescription = obj.CountingMethodDescription;
			objNew.LineNotes = obj.LineNotes;
			objNew.ClientNo = obj.ClientNo;
			objNew.PackageName = obj.PackageName;
			objNew.PackageDescription = obj.PackageDescription;
			objNew.ProductName = obj.ProductName;
			objNew.ProductDescription = obj.ProductDescription;
			objNew.ProductDutyCode = obj.ProductDutyCode;
			objNew.ManufacturerName = obj.ManufacturerName;
			objNew.CountryOfManufactureName = obj.CountryOfManufactureName;
			objNew.InspectorName = obj.InspectorName;
			objNew.CustomerRMANo = obj.CustomerRMANo;
			objNew.CustomerRMANumber = obj.CustomerRMANumber;
			objNew.CurrencyDescription = obj.CurrencyDescription;
			objNew.ReceivedBy = obj.ReceivedBy;
			objNew.DivisionNo = obj.DivisionNo;
			objNew.TeamNo = obj.TeamNo;
			objNew.StockNo = obj.StockNo;
			objNew.Reference = obj.Reference;
			objNew.LotName = obj.LotName;
			objNew.PurchaseOrderLineShipInCost = obj.PurchaseOrderLineShipInCost;
			objNew.ChangedFields = obj.ChangedFields;
			objNew.UpdateStock = obj.UpdateStock;
			objNew.UpdateShipments = obj.UpdateShipments;
            return objNew;
        }
        //[001] code start
        /// <summary>
        /// GetDetailsPrintNiceLabelGoodsInLine
        /// Calls [usp_GetDetails_to_PrintNiceLabel_for_GoodsInLine]
        /// </summary>
        public static GoodsInLine GetDetailsPrintNiceLabelGoodsInLine(System.Int32? goodsInLineId)
        {
            Rebound.GlobalTrader.DAL.GoodsInLineDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.GetDetailsPrintNiceLabelGoodsInLine(goodsInLineId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                GoodsInLine obj = new GoodsInLine();
                obj.GoodsInLineId = objDetails.GoodsInLineId;
                obj.Part = objDetails.Part;
                obj.DateCode = objDetails.DateCode;
                obj.Quantity = objDetails.Quantity;
                obj.InspectedByUser = objDetails.InspectedByUser;
                obj.ManufacturerName = objDetails.ManufacturerName;
                obj.CompanyName = objDetails.CompanyName;
                obj.CustomerPart = objDetails.CustomerPart;
                obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                obj.DatePicked = objDetails.DatePicked;
                obj.GoodsInNumber = objDetails.GoodsInNumber;
                objDetails = null;
                return obj;
            }
        }
        //[001] code end
        /// <summary>
        /// usp_update_GoodsInLine_NPRStatus
        /// </summary>
        /// <param name="goodsInLineId"></param>
        /// <param name="nprPrintStatus"></param>
        /// <returns></returns>
        public static bool UpdateNPRStatus(System.Int32? goodsInLineId, System.Boolean? nprPrintStatus)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.UpdateNPRStatus(goodsInLineId, nprPrintStatus);
        }


        /// <summary>
        /// Insert
        /// Calls [usp_insert_SerialNo]
        /// </summary>
        public static Int32 InsertSerialNo(System.String subGroup, System.String serialNo, System.Int32? goodsInId,System.Int32? goodsInLineId , System.Int32? updatedBy, out System.String validateMessage)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.InsertSerialNo(subGroup, serialNo, goodsInId,goodsInLineId , updatedBy ,out validateMessage);
            return objReturn;
        }

        public static Int32 UpdateSerialNo(System.Int32? serialId, System.String subGroup, System.String serialNo, System.Int32? goodsInId, System.String status,System.Int32? goodsInLineId ,System.Int32? updatedBy, out System.String validateMessage)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.UpdateSerialNo(serialId, subGroup, serialNo, goodsInId, status,goodsInLineId ,updatedBy, out validateMessage);
            return objReturn;
        }


        public static List<GoodsInLine> GetDataGrid(System.Int32? goodsInId, System.Int32? goodsInLineId, System.Int32? updatedBy)
        {
            List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.GetDataGrid(goodsInId, goodsInLineId, updatedBy);
            if (lstDetails == null)
            {
                return new List<GoodsInLine>();
            }
            else
            {
                List<GoodsInLine> lst = new List<GoodsInLine>();
                foreach (GoodsInLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.GoodsInLine obj = new Rebound.GlobalTrader.BLL.GoodsInLine();
                    obj.SerialNoId = objDetails.SerialNoId;
                    obj.GoodsInNo = objDetails.GoodsInNo;
                    obj.SerialNo = objDetails.SerialNo;
                    obj.SubGroup = objDetails.SubGroup;
                    obj.Status = objDetails.Status;
                    obj.InvoiceLineNo = objDetails.InvoiceLineNo;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        public static Int32 InsertAllSerialNo(System.Int32? goodsInId, System.Int32? goodsInLineId, System.Int32? updatedBy, out System.String validateMessage)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.InsertAllSerialNo(goodsInId, goodsInLineId, updatedBy, out validateMessage);
            return objReturn;
        }

        public static List<GoodsInLine> GetSerial(System.Int32? goodsInLineId)
        {
            List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.GetSerial(goodsInLineId);
            if (lstDetails == null)
            {
                return new List<GoodsInLine>();
            }
            else
            {
                List<GoodsInLine> lst = new List<GoodsInLine>();
                foreach (GoodsInLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.GoodsInLine obj = new Rebound.GlobalTrader.BLL.GoodsInLine();
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

        //public static List<GoodsInLine> AutoSearch(System.String nameSearch, System.String groupName)
        //{
        //    List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.AutoSearch(nameSearch, groupName);
        //    if (lstDetails == null)
        //    {
        //        return new List<GoodsInLine>();
        //    }
        //    else
        //    {
        //        List<GoodsInLine> lst = new List<GoodsInLine>();
        //        foreach (GoodsInLineDetails objDetails in lstDetails)
        //        {
        //            Rebound.GlobalTrader.BLL.GoodsInLine obj = new Rebound.GlobalTrader.BLL.GoodsInLine();
        //            obj.SerialNoId = objDetails.SerialNoId;
        //            obj.SerialNo = objDetails.SerialNo;
        //            lst.Add(obj);
        //            obj = null;
        //        }
        //        lstDetails = null;
        //        return lst;
        //    }
        //}

        public static List<GoodsInLine> AutoSearch(System.String nameSearch, System.String groupName)
        {
            List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.AutoSearch(nameSearch, groupName);
            if (lstDetails == null)
            {
                return new List<GoodsInLine>();
            }
            else
            {
                List<GoodsInLine> lst = new List<GoodsInLine>();
                foreach (GoodsInLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.GoodsInLine obj = new Rebound.GlobalTrader.BLL.GoodsInLine();
                    obj.SerialNoId = objDetails.SerialNoId;
                    obj.SerialNo = objDetails.SerialNo;

                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodsInLineNo"></param>
        /// <returns></returns>
        public static List<GoodsInLine> DropDown(System.Int32? goodsInLineNo)
        {
            List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.DropDown(goodsInLineNo);
            if (lstDetails == null)
            {
                return new List<GoodsInLine>();
            }
            else
            {
                List<GoodsInLine> lst = new List<GoodsInLine>();
                foreach (GoodsInLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.GoodsInLine obj = new Rebound.GlobalTrader.BLL.GoodsInLine();
                    obj.SubGroup = objDetails.SubGroup;
                    obj.SerialNo = objDetails.SerialNo;  
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }


        public static List<GoodsInLine> AutoSearchGroup(System.String nameSearch)
        {
            List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.AutoSearchGroup(nameSearch);
            if (lstDetails == null)
            {
                return new List<GoodsInLine>();
            }
            else
            {
                List<GoodsInLine> lst = new List<GoodsInLine>();
                foreach (GoodsInLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.GoodsInLine obj = new Rebound.GlobalTrader.BLL.GoodsInLine();
                    obj.SerialNoId = objDetails.SerialNoId;
                    obj.SubGroup = objDetails.SubGroup;

                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        public static Int32 DeleteSerialNo(System.Int32? serialNoId, System.String status, System.Int32? goodsInId,System.Int32? goodsInLineId, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.DeleteSerialNo(serialNoId, status,goodsInId, goodsInLineId, updatedBy);
            return objReturn;
        }

        /// <summary>
        /// ItemSearch
        /// Calls [usp_itemsearch_GoodsInSerialNo]
        /// </summary>
        public static List<GoodsInLine> GISerialSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String giSerialGroup, System.String serialNoLo, System.Int32? serialNoHi, System.DateTime? dateReceivedFrom, System.DateTime? dateReceivedTo,System.Int32? goodsInLineNo)
        {
            List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.GISerialSearch(clientId, orderBy, sortDir, pageIndex, pageSize, giSerialGroup, serialNoLo, serialNoHi, dateReceivedFrom, dateReceivedTo, goodsInLineNo);
            if (lstDetails == null)
            {
                return new List<GoodsInLine>();
            }
            else
            {
                List<GoodsInLine> lst = new List<GoodsInLine>();
                foreach (GoodsInLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.GoodsInLine obj = new Rebound.GlobalTrader.BLL.GoodsInLine();
                    obj.SerialNoId = objDetails.SerialNoId;
                    obj.SerialNo = objDetails.SerialNo;
                    obj.SubGroup = objDetails.SubGroup;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// usp_get_AttachedSerialNo
        /// </summary>
        public static List<GoodsInLine> GetAttachedSerial(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? goodsInLineNO, System.Int32? salesOrderLineNo, System.DateTime? dateReceivedFrom, System.DateTime? dateReceivedTo,System.Int32? allocationNo)
        {
            List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.GetAttachedSerial(clientId, orderBy, sortDir, pageIndex, pageSize, goodsInLineNO, salesOrderLineNo, dateReceivedFrom, dateReceivedTo, allocationNo);
            if (lstDetails == null)
            {
                return new List<GoodsInLine>();
            }
            else
            {
                List<GoodsInLine> lst = new List<GoodsInLine>();
                foreach (GoodsInLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.GoodsInLine obj = new Rebound.GlobalTrader.BLL.GoodsInLine();
                    obj.SerialNoId = objDetails.SerialNoId;
                    obj.SerialNo = objDetails.SerialNo;
                    obj.SubGroup = objDetails.SubGroup;
                    obj.RowNum = objDetails.RowNum;
                    obj.InvoiceLineNo = objDetails.InvoiceLineNo;
                    obj.RowCnt = objDetails.RowCnt;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// usp_delete_AttachedSerial
        /// </summary>
        public static Int32 DeleteAttachedSerial(System.Int32? serialId, System.Int32? goodsInLineId, System.Int32? soLineId, System.Int32? updatedBy,System.Int32? allocationNo)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.DeleteAttachedSerial(serialId, goodsInLineId, soLineId, updatedBy, allocationNo);
            return objReturn;
        }

        /// <summary>
        /// usp_update_SerialBySO
        /// </summary>
        public static Int32 UpdateSerialBySO(System.String subGroup, System.Int32? goodsInLineId, System.Int32? soLineId, System.Int32? qtyToShpped,System.Int32? allocatedId, out System.String validateMessage)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.UpdateSerialBySO(subGroup, goodsInLineId, soLineId, qtyToShpped,allocatedId, out validateMessage);
            return objReturn;
        }

        /// <summary>
        /// usp_delete_SerialBySO
        /// </summary>
        public static Int32 DeleteSerialBySO(System.Int32? goodsInLineId, System.Int32? soLineId, System.Int32? AllocatedId)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.DeleteSerialBySO(goodsInLineId, soLineId, AllocatedId);
            return objReturn;
        }


        public static List<GoodsInLine> GetReasonDetailByPart(System.String part)
        {
            List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.GetReasonDetailByPart(part);
            if (lstDetails == null)
            {
                return new List<GoodsInLine>();
            }
            else
            {
                List<GoodsInLine> lst = new List<GoodsInLine>();
                foreach (GoodsInLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.GoodsInLine obj = new Rebound.GlobalTrader.BLL.GoodsInLine();

                    obj.ReasonCode = objDetails.ReasonCode;
                    obj.ReasonDate = objDetails.ReasonDate;
                    
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodsInLineNo"></param>
        /// <returns></returns>
        public static List<GoodsInLine> GetShipCostHistory(System.Int32? goodsInLineNo)
        {
            List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsInLine.GetShipCostHistory(goodsInLineNo);
            if (lstDetails == null)
            {
                return new List<GoodsInLine>();
            }
            else
            {
                List<GoodsInLine> lst = new List<GoodsInLine>();
                foreach (GoodsInLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.GoodsInLine obj = new Rebound.GlobalTrader.BLL.GoodsInLine();
                    obj.GIShipCostHistoryId = objDetails.GIShipCostHistoryId;
                    obj.ShipInCost = objDetails.ShipInCost;
                    obj.DLUP = objDetails.DLUP;
                    obj.ReceiverName = objDetails.ReceiverName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
		#endregion
		
	}
}
