//Marker     Changed by      Date         Remarks
//[001]      Vinay           30/07/2012   Add compulsory incoterms field when create Credit and debit note. :ESMS No:- 105
//[002]      Vinay           24/02/2015   Need a provision in GT on SRMA Line to show Purchase order Line serial No
//[003]      Suhail          15/05/2018   Added Avoidable on SRMA Line
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
	public partial class SupplierRmaLine : BizObject {

		#region Properties

		protected static DAL.SupplierRmaLineElement Settings {
			get { return Globals.Settings.SupplierRmaLines; }
		}

		/// <summary>
		/// SupplierRMALineId
		/// </summary>
		public System.Int32 SupplierRMALineId { get; set; }
		/// <summary>
		/// SupplierRMANo
		/// </summary>
		public System.Int32 SupplierRMANo { get; set; }
		/// <summary>
		/// PurchaseOrderLineNo
		/// </summary>
		public System.Int32 PurchaseOrderLineNo { get; set; }
		/// <summary>
		/// ReturnDate
		/// </summary>
		public System.DateTime ReturnDate { get; set; }
		/// <summary>
		/// Reason
		/// </summary>
		public System.String Reason { get; set; }

        /// <summary>
        /// Reason1
        /// </summary>
        public System.String Reason1 { get; set; }

        /// <summary>
        /// Reason2
        /// </summary>
        public System.String Reason2 { get; set; }

        /// <summary>
        /// Reason1 Value
        /// </summary>
        public System.String Reason1Val { get; set; }

        /// <summary>
        /// Reason2 Value
        /// </summary>
        public System.String Reason2Val { get; set; }
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
		/// ProductNo
		/// </summary>
		public System.Int32? ProductNo { get; set; }
		/// <summary>
		/// Quantity
		/// </summary>
		public System.Int32 Quantity { get; set; }
		/// <summary>
		/// Reference
		/// </summary>
		public System.String Reference { get; set; }
		/// <summary>
		/// ROHS
		/// </summary>
		public System.Byte ROHS { get; set; }
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// SupplierRMAId
		/// </summary>
		public System.Int32 SupplierRMAId { get; set; }
		/// <summary>
		/// SupplierRMANumber
		/// </summary>
		public System.Int32 SupplierRMANumber { get; set; }
		/// <summary>
		/// SupplierRMADate
		/// </summary>
		public System.DateTime SupplierRMADate { get; set; }
		/// <summary>
		/// CompanyName
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// PurchaseOrderNumber
		/// </summary>
		public System.Int32 PurchaseOrderNumber { get; set; }
		/// <summary>
		/// PurchaseOrderNo
		/// </summary>
		public System.Int32 PurchaseOrderNo { get; set; }
		/// <summary>
		/// AllocatedQuantity
		/// </summary>
		public System.Int32 AllocatedQuantity { get; set; }
		/// <summary>
		/// ContactName
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// ContactNo
		/// </summary>
		public System.Int32? ContactNo { get; set; }
		/// <summary>
		/// ManufacturerCode
		/// </summary>
		public System.String ManufacturerCode { get; set; }
		/// <summary>
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// BuyerName
		/// </summary>
		public System.String BuyerName { get; set; }
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// PurchaseOrderId
		/// </summary>
		public System.Int32 PurchaseOrderId { get; set; }
		/// <summary>
		/// DateOrdered
		/// </summary>
		public System.DateTime DateOrdered { get; set; }
		/// <summary>
		/// CurrencyNo
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }
		/// <summary>
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// CurrencyDescription
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// Buyer
		/// </summary>
		public System.Int32 Buyer { get; set; }
		/// <summary>
		/// DivisionNo
		/// </summary>
		public System.Int32? DivisionNo { get; set; }
		/// <summary>
		/// TeamNo
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// FullName
		/// </summary>
		public System.String FullName { get; set; }
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
		/// PackageName
		/// </summary>
		public System.String PackageName { get; set; }
		/// <summary>
		/// PackageDescription
		/// </summary>
		public System.String PackageDescription { get; set; }
		/// <summary>
		/// AuthorisedBy
		/// </summary>
		public System.Int32 AuthorisedBy { get; set; }
		/// <summary>
		/// AuthoriserName
		/// </summary>
		public System.String AuthoriserName { get; set; }
		/// <summary>
		/// QuantityAllocated
		/// </summary>
		public System.Int32 QuantityAllocated { get; set; }
		/// <summary>
		/// QuantityShipped
		/// </summary>
		public System.Int32 QuantityShipped { get; set; }
		/// <summary>
		/// Price
		/// </summary>
		public System.Double Price { get; set; }
		/// <summary>
		/// StockNo
		/// </summary>
		public System.Int32? StockNo { get; set; }
		/// <summary>
		/// AllocationId
		/// </summary>
		public System.Int32? AllocationId { get; set; }
		/// <summary>
		/// QuantityInStock
		/// </summary>
		public System.Int32? QuantityInStock { get; set; }
		/// <summary>
		/// Location
		/// </summary>
		public System.String Location { get; set; }
		/// <summary>
		/// Taxable
		/// </summary>
		public System.Boolean Taxable { get; set; }
		/// <summary>
		/// LineNotes
		/// </summary>
		public System.String LineNotes { get; set; }
		/// <summary>
		/// WarehouseNo
		/// </summary>
		public System.Int32? WarehouseNo { get; set; }
		/// <summary>
		/// WarehouseName
		/// </summary>
		public System.String WarehouseName { get; set; }
		/// <summary>
		/// LotNo
		/// </summary>
		public System.Int32? LotNo { get; set; }
		/// <summary>
		/// LandedCost
		/// </summary>
		public System.Double? LandedCost { get; set; }
		/// <summary>
		/// GoodsInLineNo
		/// </summary>
		public System.Int32? GoodsInLineNo { get; set; }
		/// <summary>
		/// GoodsInNo
		/// </summary>
		public System.Int32? GoodsInNo { get; set; }
		/// <summary>
		/// CountryOfManufacture
		/// </summary>
		public System.Int32? CountryOfManufacture { get; set; }
		/// <summary>
		/// GoodsInNumber
		/// </summary>
		public System.Int32? GoodsInNumber { get; set; }
		/// <summary>
		/// SupplierNo
		/// </summary>
		public System.Int32 SupplierNo { get; set; }
		/// <summary>
		/// SupplierName
		/// </summary>
		public System.String SupplierName { get; set; }
		/// <summary>
		/// PurchaseOrderLineId
		/// </summary>
		public System.Int32 PurchaseOrderLineId { get; set; }
		/// <summary>
		/// DeliveryDate
		/// </summary>
		public System.DateTime DeliveryDate { get; set; }
		/// <summary>
		/// PurchasePrice
		/// </summary>
		public System.Double PurchasePrice { get; set; }
		/// <summary>
		/// ShipViaName
		/// </summary>
		public System.String ShipViaName { get; set; }
        //[0001] code start
        /// <summary>
        /// ShippingNotes (from [usp_selectAll_SalesOrderLine_from_GoodsInLine_for_Docket])
        /// </summary>
        public System.String ShippingNotes { get; set; }
        //[0001] code end
        //[001] code start
        /// <summary>
        /// SRMAIncotermsNo
        /// </summary>
        public System.Int32? SRMAIncotermsNo { get; set; }
        //[001] code end

        /// <summary>
        /// Root Cause
        /// </summary>
        public System.String RootCause { get; set; }
        //[002] code start
        /// <summary>
        /// POSerialNo
        /// </summary>
        public System.Int16? POSerialNo { get; set; }
        //[002] code end

        public System.Int32? ParentSRMALineNo { get; set; }
        public System.Int32? IPOCompanyNo { get; set; }
        public System.Int32? InternalPurchaseOrderId { get; set; }
        public System.String IPOCompanyName { get; set; }
        public System.String ClientName { get; set; }
        public System.Boolean Avoidable { get; set; }
        public System.Boolean? IsProdHazardous { get; set; }
        public System.Boolean? PrintHazardous { get; set; }
		#endregion

		#region Methods

		/// <summary>
		/// CountForPurchaseOrderLine
		/// Calls [usp_count_SupplierRMALine_for_PurchaseOrderLine]
		/// </summary>
		public static Int32 CountForPurchaseOrderLine(System.Int32? purchaseOrderLineId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.SupplierRmaLine.CountForPurchaseOrderLine(purchaseOrderLineId);
		}		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_SupplierRMALine]
		/// </summary>
        public static List<SupplierRmaLine> DataListNugget(System.Int32? clientId, System.Int32? teamId, System.Int32? divisionId, System.Int32? loginId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.String srmaNotesSearch, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? supplierRmaNoLo, System.Int32? supplierRmaNoHi, System.DateTime? supplierRmaDateFrom, System.DateTime? supplierRmaDateTo, System.Boolean? includeShipped, System.Boolean? recentOnly, System.Boolean? PohubOnly, System.Int32? clientSearch, Boolean IsGlobalLogin)
        {
			List<SupplierRmaLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRmaLine.DataListNugget(clientId, teamId, divisionId, loginId, pageIndex, pageSize, orderBy, sortDir, partSearch, contactSearch, cmSearch, buyerSearch, srmaNotesSearch, purchaseOrderNoLo, purchaseOrderNoHi, supplierRmaNoLo, supplierRmaNoHi, supplierRmaDateFrom, supplierRmaDateTo, includeShipped, recentOnly,PohubOnly, clientSearch,  IsGlobalLogin);
			if (lstDetails == null) {
				return new List<SupplierRmaLine>();
			} else {
				List<SupplierRmaLine> lst = new List<SupplierRmaLine>();
				foreach (SupplierRmaLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SupplierRmaLine obj = new Rebound.GlobalTrader.BLL.SupplierRmaLine();
					obj.SupplierRMAId = objDetails.SupplierRMAId;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.SupplierRMADate = objDetails.SupplierRMADate;
					obj.CompanyName = objDetails.CompanyName;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.ROHS = objDetails.ROHS;
					obj.Part = objDetails.Part;
					obj.Quantity = objDetails.Quantity;
					obj.AllocatedQuantity = objDetails.AllocatedQuantity;
					obj.ContactName = objDetails.ContactName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
                    obj.IPOCompanyNo = objDetails.IPOCompanyNo;
                    obj.IPOCompanyName = objDetails.IPOCompanyName;
                    obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
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
		/// DataListNuggetReadyToShip
		/// Calls [usp_datalistnugget_SupplierRMALine_ReadyToShip]
		/// </summary>
        public static List<SupplierRmaLine> DataListNuggetReadyToShip(System.Int32? clientId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.String srmaNotesSearch, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? supplierRmaNoLo, System.Int32? supplierRmaNoHi, System.DateTime? supplierRmaDateFrom, System.DateTime? supplierRmaDateTo, System.Int32? clientSearch, Boolean IsGlobalLogin)
        {
			List<SupplierRmaLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRmaLine.DataListNuggetReadyToShip(clientId, pageIndex, pageSize, orderBy, sortDir, partSearch, contactSearch, cmSearch, buyerSearch, srmaNotesSearch, purchaseOrderNoLo, purchaseOrderNoHi, supplierRmaNoLo, supplierRmaNoHi, supplierRmaDateFrom, supplierRmaDateTo,  clientSearch,  IsGlobalLogin);
			if (lstDetails == null) {
				return new List<SupplierRmaLine>();
			} else {
				List<SupplierRmaLine> lst = new List<SupplierRmaLine>();
				foreach (SupplierRmaLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SupplierRmaLine obj = new Rebound.GlobalTrader.BLL.SupplierRmaLine();
					obj.SupplierRMAId = objDetails.SupplierRMAId;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.SupplierRMADate = objDetails.SupplierRMADate;
					obj.CompanyName = objDetails.CompanyName;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.ROHS = objDetails.ROHS;
					obj.Part = objDetails.Part;
					obj.Quantity = objDetails.Quantity;
					obj.AllocatedQuantity = objDetails.AllocatedQuantity;
					obj.ContactName = objDetails.ContactName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
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
		/// Delete
		/// Calls [usp_delete_SupplierRMALine]
		/// </summary>
		public static bool Delete(System.Int32? supplierRmaLineId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.SupplierRmaLine.Delete(supplierRmaLineId);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_SupplierRMALine]
		/// </summary>
        public static Int32 Insert(System.Int32? supplierRmaNo, System.Int32? purchaseOrderLineNo, System.DateTime? returnDate, System.String reason, System.String part, System.Int32? manufacturerNo, System.String dateCode, System.Int32? packageNo, System.Int32? productNo, System.Int32? quantity, System.String reference, System.Byte? rohs, System.String notes, System.String Reason1, System.String Reason2, System.String rootCause, System.Int32? updatedBy, out int supplierRMAId, out int supplierRMANumber, System.Boolean? avoidable, System.Boolean? printHazardous)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRmaLine.Insert(supplierRmaNo, purchaseOrderLineNo, returnDate, reason, part, manufacturerNo, dateCode, packageNo, productNo, quantity, reference, rohs, notes, Reason1, Reason2, rootCause, updatedBy, out supplierRMAId, out supplierRMANumber, avoidable, printHazardous);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_SupplierRMALine]
		/// </summary>
		public Int32 Insert() {
            int supplierRMAId =0;
            int supplierRMANumber =0;
            return Rebound.GlobalTrader.DAL.SiteProvider.SupplierRmaLine.Insert(SupplierRMANo, PurchaseOrderLineNo, ReturnDate, Reason, Part, ManufacturerNo, DateCode, PackageNo, ProductNo, Quantity, Reference, ROHS, Notes, Reason2, Reason1, RootCause, UpdatedBy, out supplierRMAId, out supplierRMANumber, Avoidable, PrintHazardous);
		}
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_SupplierRMALine]
		/// </summary>
		public static List<SupplierRmaLine> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String partSearch, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.String srmaNotesSearch, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? supplierRmaNoLo, System.Int32? supplierRmaNoHi, System.DateTime? supplierRmaDateFrom, System.DateTime? supplierRmaDateTo) {
			List<SupplierRmaLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRmaLine.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, partSearch, contactSearch, cmSearch, buyerSearch, srmaNotesSearch, purchaseOrderNoLo, purchaseOrderNoHi, supplierRmaNoLo, supplierRmaNoHi, supplierRmaDateFrom, supplierRmaDateTo);
			if (lstDetails == null) {
				return new List<SupplierRmaLine>();
			} else {
				List<SupplierRmaLine> lst = new List<SupplierRmaLine>();
				foreach (SupplierRmaLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SupplierRmaLine obj = new Rebound.GlobalTrader.BLL.SupplierRmaLine();
					obj.SupplierRMALineId = objDetails.SupplierRMALineId;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.SupplierRMADate = objDetails.SupplierRMADate;
					obj.BuyerName = objDetails.BuyerName;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.Quantity = objDetails.Quantity;
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
		/// Get
		/// Calls [usp_select_SupplierRMALine]
		/// </summary>
		public static SupplierRmaLine Get(System.Int32? supplierRmaLineId) {
			Rebound.GlobalTrader.DAL.SupplierRmaLineDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRmaLine.Get(supplierRmaLineId);
			if (objDetails == null) {
				return null;
			} else {
				SupplierRmaLine obj = new SupplierRmaLine();
				obj.SupplierRMAId = objDetails.SupplierRMAId;
				obj.SupplierRMANumber = objDetails.SupplierRMANumber;
				obj.SupplierRMALineId = objDetails.SupplierRMALineId;
				obj.SupplierRMADate = objDetails.SupplierRMADate;
				obj.ReturnDate = objDetails.ReturnDate;
				obj.ClientNo = objDetails.ClientNo;
				obj.Notes = objDetails.Notes;
				obj.Reason = objDetails.Reason;
				obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
				obj.PurchaseOrderId = objDetails.PurchaseOrderId;
				obj.DateOrdered = objDetails.DateOrdered;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyDescription = objDetails.CurrencyDescription;
				obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
				obj.Buyer = objDetails.Buyer;
				obj.BuyerName = objDetails.BuyerName;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.TeamNo = objDetails.TeamNo;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.FullName = objDetails.FullName;
				obj.ContactNo = objDetails.ContactNo;
				obj.ContactName = objDetails.ContactName;
				obj.Quantity = objDetails.Quantity;
				obj.ProductNo = objDetails.ProductNo;
				obj.ProductName = objDetails.ProductName;
				obj.ProductDescription = objDetails.ProductDescription;
				obj.FullPart = objDetails.FullPart;
				obj.Part = objDetails.Part;
				obj.ROHS = objDetails.ROHS;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.ManufacturerCode = objDetails.ManufacturerCode;
				obj.DateCode = objDetails.DateCode;
				obj.PackageNo = objDetails.PackageNo;
				obj.PackageName = objDetails.PackageName;
				obj.PackageDescription = objDetails.PackageDescription;
				obj.AuthorisedBy = objDetails.AuthorisedBy;
				obj.AuthoriserName = objDetails.AuthoriserName;
				obj.QuantityAllocated = objDetails.QuantityAllocated;
				obj.QuantityShipped = objDetails.QuantityShipped;
				obj.Price = objDetails.Price;
				obj.StockNo = objDetails.StockNo;
				obj.AllocationId = objDetails.AllocationId;
				obj.QuantityInStock = objDetails.QuantityInStock;
				obj.Location = objDetails.Location;
				obj.Taxable = objDetails.Taxable;
				obj.Reference = objDetails.Reference;
				obj.LineNotes = objDetails.LineNotes;
                obj.Reason2 = objDetails.Reason2;
                obj.Reason1Val = objDetails.Reason1Val;
                obj.Reason2Val = objDetails.Reason2Val;
                obj.RootCause = objDetails.RootCause;
                obj.Reason1 = objDetails.Reason1;
                //[003] Code Start
                obj.Avoidable = objDetails.Avoidable;
                //[003] Code End
                obj.IsProdHazardous = objDetails.IsProdHazardous;
                obj.PrintHazardous = objDetails.PrintHazardous;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetAllocation
		/// Calls [usp_select_SupplierRMALine_Allocation]
		/// </summary>
		public static SupplierRmaLine GetAllocation(System.Int32? supplierRmaLineId, System.Int32? allocationId) {
			Rebound.GlobalTrader.DAL.SupplierRmaLineDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRmaLine.GetAllocation(supplierRmaLineId, allocationId);
			if (objDetails == null) {
				return null;
			} else {
				SupplierRmaLine obj = new SupplierRmaLine();
				obj.SupplierRMAId = objDetails.SupplierRMAId;
				obj.SupplierRMANumber = objDetails.SupplierRMANumber;
				obj.SupplierRMALineId = objDetails.SupplierRMALineId;
				obj.SupplierRMADate = objDetails.SupplierRMADate;
				obj.ReturnDate = objDetails.ReturnDate;
				obj.ClientNo = objDetails.ClientNo;
				obj.Notes = objDetails.Notes;
				obj.Reason = objDetails.Reason;
				obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
				obj.PurchaseOrderId = objDetails.PurchaseOrderId;
				obj.DateOrdered = objDetails.DateOrdered;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyDescription = objDetails.CurrencyDescription;
				obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
				obj.Buyer = objDetails.Buyer;
				obj.BuyerName = objDetails.BuyerName;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.TeamNo = objDetails.TeamNo;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.FullName = objDetails.FullName;
				obj.ContactNo = objDetails.ContactNo;
				obj.ContactName = objDetails.ContactName;
				obj.Quantity = objDetails.Quantity;
				obj.ProductNo = objDetails.ProductNo;
				obj.ProductName = objDetails.ProductName;
				obj.ProductDescription = objDetails.ProductDescription;
				obj.FullPart = objDetails.FullPart;
				obj.Part = objDetails.Part;
				obj.ROHS = objDetails.ROHS;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.ManufacturerCode = objDetails.ManufacturerCode;
				obj.DateCode = objDetails.DateCode;
				obj.PackageNo = objDetails.PackageNo;
				obj.PackageName = objDetails.PackageName;
				obj.PackageDescription = objDetails.PackageDescription;
				obj.AuthorisedBy = objDetails.AuthorisedBy;
				obj.AuthoriserName = objDetails.AuthoriserName;
				obj.QuantityAllocated = objDetails.QuantityAllocated;
				obj.QuantityShipped = objDetails.QuantityShipped;
				obj.Price = objDetails.Price;
				obj.StockNo = objDetails.StockNo;
				obj.AllocationId = objDetails.AllocationId;
				obj.QuantityInStock = objDetails.QuantityInStock;
				obj.Location = objDetails.Location;
				obj.Taxable = objDetails.Taxable;
				obj.Reference = objDetails.Reference;
				obj.LineNotes = objDetails.LineNotes;
				obj.AllocationId = objDetails.AllocationId;
				obj.AllocatedQuantity = objDetails.AllocatedQuantity;
				obj.StockNo = objDetails.StockNo;
				obj.WarehouseNo = objDetails.WarehouseNo;
				obj.WarehouseName = objDetails.WarehouseName;
				obj.LotNo = objDetails.LotNo;
				obj.LandedCost = objDetails.LandedCost;
				obj.QuantityInStock = objDetails.QuantityInStock;
				obj.GoodsInLineNo = objDetails.GoodsInLineNo;
				obj.Location = objDetails.Location;
				obj.GoodsInNo = objDetails.GoodsInNo;
				obj.CountryOfManufacture = objDetails.CountryOfManufacture;
				obj.GoodsInNumber = objDetails.GoodsInNumber;
				obj.SupplierNo = objDetails.SupplierNo;
				obj.SupplierName = objDetails.SupplierName;
				obj.PurchaseOrderLineId = objDetails.PurchaseOrderLineId;
				obj.DeliveryDate = objDetails.DeliveryDate;
				obj.PurchasePrice = objDetails.PurchasePrice;
				obj.CurrencyCode = objDetails.CurrencyCode;
                obj.Reason1 = objDetails.Reason1;
                obj.Reason2 = objDetails.Reason2;
                obj.Reason1Val = objDetails.Reason1Val;
                obj.Reason2Val = objDetails.Reason2Val;
                obj.RootCause = objDetails.RootCause;

				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetShip
		/// Calls [usp_select_SupplierRMALine_Ship]
		/// </summary>
		public static SupplierRmaLine GetShip(System.Int32? supplierRmaLineId) {
			Rebound.GlobalTrader.DAL.SupplierRmaLineDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRmaLine.GetShip(supplierRmaLineId);
			if (objDetails == null) {
				return null;
			} else {
				SupplierRmaLine obj = new SupplierRmaLine();
				obj.SupplierRMAId = objDetails.SupplierRMAId;
				obj.SupplierRMANumber = objDetails.SupplierRMANumber;
				obj.SupplierRMALineId = objDetails.SupplierRMALineId;
				obj.SupplierRMADate = objDetails.SupplierRMADate;
				obj.ReturnDate = objDetails.ReturnDate;
				obj.ClientNo = objDetails.ClientNo;
				obj.Notes = objDetails.Notes;
				obj.Reason = objDetails.Reason;
				obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
				obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
				obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
				obj.Buyer = objDetails.Buyer;
				obj.BuyerName = objDetails.BuyerName;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.TeamNo = objDetails.TeamNo;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.ContactNo = objDetails.ContactNo;
				obj.ContactName = objDetails.ContactName;
				obj.Quantity = objDetails.Quantity;
				obj.ProductNo = objDetails.ProductNo;
				obj.ProductName = objDetails.ProductName;
				obj.ProductDescription = objDetails.ProductDescription;
				obj.FullPart = objDetails.FullPart;
				obj.Part = objDetails.Part;
				obj.ROHS = objDetails.ROHS;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.ManufacturerCode = objDetails.ManufacturerCode;
				obj.DateCode = objDetails.DateCode;
				obj.PackageNo = objDetails.PackageNo;
				obj.PackageName = objDetails.PackageName;
				obj.PackageDescription = objDetails.PackageDescription;
				obj.AllocatedQuantity = objDetails.AllocatedQuantity;
				obj.StockNo = objDetails.StockNo;
				obj.AllocationId = objDetails.AllocationId;
				obj.QuantityInStock = objDetails.QuantityInStock;
				obj.Location = objDetails.Location;
				obj.LineNotes = objDetails.LineNotes;
                //[001] code start
                obj.SRMAIncotermsNo = objDetails.SRMAIncotermsNo;
                //[001] code end
                obj.Reason1 = objDetails.Reason1;
                obj.Reason2 = objDetails.Reason2;
                obj.RootCause = objDetails.RootCause;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForPurchaseOrderLine
		/// Calls [usp_selectAll_SupplierRMALine_for_PurchaseOrderLine]
		/// </summary>
		public static List<SupplierRmaLine> GetListForPurchaseOrderLine(System.Int32? purchaseOrderLineId) {
			List<SupplierRmaLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRmaLine.GetListForPurchaseOrderLine(purchaseOrderLineId);
			if (lstDetails == null) {
				return new List<SupplierRmaLine>();
			} else {
				List<SupplierRmaLine> lst = new List<SupplierRmaLine>();
				foreach (SupplierRmaLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SupplierRmaLine obj = new Rebound.GlobalTrader.BLL.SupplierRmaLine();
					obj.SupplierRMAId = objDetails.SupplierRMAId;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.SupplierRMALineId = objDetails.SupplierRMALineId;
					obj.SupplierRMADate = objDetails.SupplierRMADate;
					obj.ReturnDate = objDetails.ReturnDate;
					obj.ClientNo = objDetails.ClientNo;
					obj.Notes = objDetails.Notes;
					obj.Reason = objDetails.Reason;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.PurchaseOrderId = objDetails.PurchaseOrderId;
					obj.DateOrdered = objDetails.DateOrdered;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.Buyer = objDetails.Buyer;
					obj.BuyerName = objDetails.BuyerName;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.TeamNo = objDetails.TeamNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.FullName = objDetails.FullName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.Quantity = objDetails.Quantity;
					obj.ProductNo = objDetails.ProductNo;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.DateCode = objDetails.DateCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.AuthorisedBy = objDetails.AuthorisedBy;
					obj.AuthoriserName = objDetails.AuthoriserName;
					obj.QuantityAllocated = objDetails.QuantityAllocated;
					obj.QuantityShipped = objDetails.QuantityShipped;
					obj.Price = objDetails.Price;
					obj.StockNo = objDetails.StockNo;
					obj.AllocationId = objDetails.AllocationId;
					obj.QuantityInStock = objDetails.QuantityInStock;
					obj.Location = objDetails.Location;
					obj.Taxable = objDetails.Taxable;
					obj.Reference = objDetails.Reference;
					obj.LineNotes = objDetails.LineNotes;
                    obj.Reason1 = objDetails.Reason1;
                    obj.Reason2 = objDetails.Reason2;
                    obj.RootCause = objDetails.RootCause;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForSupplierRMA
		/// Calls [usp_selectAll_SupplierRMALine_for_SupplierRMA]
		/// </summary>
		public static List<SupplierRmaLine> GetListForSupplierRMA(System.Int32? supplierRmaId) {
			List<SupplierRmaLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRmaLine.GetListForSupplierRMA(supplierRmaId);
			if (lstDetails == null) {
				return new List<SupplierRmaLine>();
			} else {
				List<SupplierRmaLine> lst = new List<SupplierRmaLine>();
				foreach (SupplierRmaLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SupplierRmaLine obj = new Rebound.GlobalTrader.BLL.SupplierRmaLine();
					obj.SupplierRMAId = objDetails.SupplierRMAId;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.SupplierRMALineId = objDetails.SupplierRMALineId;
					obj.SupplierRMADate = objDetails.SupplierRMADate;
					obj.ReturnDate = objDetails.ReturnDate;
					obj.ClientNo = objDetails.ClientNo;
					obj.Notes = objDetails.Notes;
					obj.Reason = objDetails.Reason;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.PurchaseOrderId = objDetails.PurchaseOrderId;
					obj.DateOrdered = objDetails.DateOrdered;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.Buyer = objDetails.Buyer;
					obj.BuyerName = objDetails.BuyerName;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.TeamNo = objDetails.TeamNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.Quantity = objDetails.Quantity;
					obj.ProductNo = objDetails.ProductNo;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.DateCode = objDetails.DateCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.AuthorisedBy = objDetails.AuthorisedBy;
					obj.AuthoriserName = objDetails.AuthoriserName;
					obj.QuantityAllocated = objDetails.QuantityAllocated;
					obj.QuantityShipped = objDetails.QuantityShipped;
					obj.Reference = objDetails.Reference;
					obj.LineNotes = objDetails.LineNotes;
                    obj.Reason1 = objDetails.Reason1;
                    obj.Reason2 = objDetails.Reason2;
                    obj.RootCause = objDetails.RootCause;
                    //[002] code start
                    obj.POSerialNo = objDetails.POSerialNo;
                    obj.ParentSRMALineNo = objDetails.ParentSRMALineNo;
                    //[002] code end
                    obj.PrintHazardous = objDetails.PrintHazardous;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListShipForSupplierRMA
		/// Calls [usp_selectAll_SupplierRMALine_Ship_for_SupplierRMA]
		/// </summary>
		public static List<SupplierRmaLine> GetListShipForSupplierRMA(System.Int32? supplierRmaId) {
			List<SupplierRmaLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRmaLine.GetListShipForSupplierRMA(supplierRmaId);
			if (lstDetails == null) {
				return new List<SupplierRmaLine>();
			} else {
				List<SupplierRmaLine> lst = new List<SupplierRmaLine>();
				foreach (SupplierRmaLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SupplierRmaLine obj = new Rebound.GlobalTrader.BLL.SupplierRmaLine();
					obj.SupplierRMAId = objDetails.SupplierRMAId;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.SupplierRMALineId = objDetails.SupplierRMALineId;
					obj.SupplierRMADate = objDetails.SupplierRMADate;
					obj.ReturnDate = objDetails.ReturnDate;
					obj.ClientNo = objDetails.ClientNo;
					obj.Notes = objDetails.Notes;
					obj.Reason = objDetails.Reason;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.Buyer = objDetails.Buyer;
					obj.BuyerName = objDetails.BuyerName;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.TeamNo = objDetails.TeamNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.Quantity = objDetails.Quantity;
					obj.ProductNo = objDetails.ProductNo;
					obj.ProductName = objDetails.ProductName;
					obj.ProductDescription = objDetails.ProductDescription;
					obj.FullPart = objDetails.FullPart;
					obj.Part = objDetails.Part;
					obj.ROHS = objDetails.ROHS;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.ManufacturerCode = objDetails.ManufacturerCode;
					obj.DateCode = objDetails.DateCode;
					obj.PackageNo = objDetails.PackageNo;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.AllocatedQuantity = objDetails.AllocatedQuantity;
					obj.StockNo = objDetails.StockNo;
					obj.AllocationId = objDetails.AllocationId;
					obj.QuantityInStock = objDetails.QuantityInStock;
					obj.Location = objDetails.Location;
					obj.LineNotes = objDetails.LineNotes;
                    obj.Reason1 = objDetails.Reason1;
                    obj.Reason2 = objDetails.Reason2;
                    obj.RootCause = objDetails.RootCause;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListFromGoodsInLineForDocket
		/// Calls [usp_selectAll_SupplierRmaLine_from_GoodsInLine_for_Docket]
		/// </summary>
		public static List<SupplierRmaLine> GetListFromGoodsInLineForDocket(System.Int32? goodsInLineNo) {
			List<SupplierRmaLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRmaLine.GetListFromGoodsInLineForDocket(goodsInLineNo);
			if (lstDetails == null) {
				return new List<SupplierRmaLine>();
			} else {
				List<SupplierRmaLine> lst = new List<SupplierRmaLine>();
				foreach (SupplierRmaLineDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SupplierRmaLine obj = new Rebound.GlobalTrader.BLL.SupplierRmaLine();
					obj.ShipViaName = objDetails.ShipViaName;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.CompanyName = objDetails.CompanyName;
					obj.ReturnDate = objDetails.ReturnDate;
					obj.QuantityAllocated = objDetails.QuantityAllocated;
					obj.AuthoriserName = objDetails.AuthoriserName;
                    //[0001] code start
                    obj.ShippingNotes = objDetails.ShippingNotes; 
                    //[0001] code end
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}		/// <summary>
		/// <summary>
		/// Update
		/// Calls [usp_update_SupplierRMALine]
		/// </summary>
        public static bool Update(System.Int32? supplierRmaLineId, System.String reason, System.Int32? quantity, System.String reference, System.Byte? rohs, System.String notes, System.String reason1, System.String reason2, System.String rootCause, System.Int32? updatedBy, System.Boolean? avoidable)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SupplierRmaLine.Update(supplierRmaLineId, reason, quantity, reference, rohs, notes, reason1, reason2, rootCause, updatedBy, avoidable, false);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_SupplierRMALine]
		/// </summary>
		public bool Update() {
            return Rebound.GlobalTrader.DAL.SiteProvider.SupplierRmaLine.Update(SupplierRMALineId, Reason, Quantity, Reference, ROHS, Notes, Reason1, Reason2, RootCause, UpdatedBy, Avoidable, PrintHazardous);
		}

		private static SupplierRmaLine PopulateFromDBDetailsObject(SupplierRmaLineDetails obj) {
			SupplierRmaLine objNew = new SupplierRmaLine();
			objNew.SupplierRMALineId = obj.SupplierRMALineId;
			objNew.SupplierRMANo = obj.SupplierRMANo;
			objNew.PurchaseOrderLineNo = obj.PurchaseOrderLineNo;
			objNew.ReturnDate = obj.ReturnDate;
			objNew.Reason = obj.Reason;
			objNew.FullPart = obj.FullPart;
			objNew.Part = obj.Part;
			objNew.ManufacturerNo = obj.ManufacturerNo;
			objNew.DateCode = obj.DateCode;
			objNew.PackageNo = obj.PackageNo;
			objNew.ProductNo = obj.ProductNo;
			objNew.Quantity = obj.Quantity;
			objNew.Reference = obj.Reference;
			objNew.ROHS = obj.ROHS;
			objNew.Notes = obj.Notes;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.SupplierRMAId = obj.SupplierRMAId;
			objNew.SupplierRMANumber = obj.SupplierRMANumber;
			objNew.SupplierRMADate = obj.SupplierRMADate;
			objNew.CompanyName = obj.CompanyName;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.PurchaseOrderNumber = obj.PurchaseOrderNumber;
			objNew.PurchaseOrderNo = obj.PurchaseOrderNo;
			objNew.AllocatedQuantity = obj.AllocatedQuantity;
			objNew.ContactName = obj.ContactName;
			objNew.ContactNo = obj.ContactNo;
			objNew.ManufacturerCode = obj.ManufacturerCode;
			objNew.RowNum = obj.RowNum;
			objNew.RowCnt = obj.RowCnt;
			objNew.BuyerName = obj.BuyerName;
			objNew.ClientNo = obj.ClientNo;
			objNew.PurchaseOrderId = obj.PurchaseOrderId;
			objNew.DateOrdered = obj.DateOrdered;
			objNew.CurrencyNo = obj.CurrencyNo;
			objNew.CurrencyCode = obj.CurrencyCode;
			objNew.CurrencyDescription = obj.CurrencyDescription;
			objNew.Buyer = obj.Buyer;
			objNew.DivisionNo = obj.DivisionNo;
			objNew.TeamNo = obj.TeamNo;
			objNew.FullName = obj.FullName;
			objNew.ProductName = obj.ProductName;
			objNew.ProductDescription = obj.ProductDescription;
			objNew.ManufacturerName = obj.ManufacturerName;
			objNew.PackageName = obj.PackageName;
			objNew.PackageDescription = obj.PackageDescription;
			objNew.AuthorisedBy = obj.AuthorisedBy;
			objNew.AuthoriserName = obj.AuthoriserName;
			objNew.QuantityAllocated = obj.QuantityAllocated;
			objNew.QuantityShipped = obj.QuantityShipped;
			objNew.Price = obj.Price;
			objNew.StockNo = obj.StockNo;
			objNew.AllocationId = obj.AllocationId;
			objNew.QuantityInStock = obj.QuantityInStock;
			objNew.Location = obj.Location;
			objNew.Taxable = obj.Taxable;
			objNew.LineNotes = obj.LineNotes;
			objNew.WarehouseNo = obj.WarehouseNo;
			objNew.WarehouseName = obj.WarehouseName;
			objNew.LotNo = obj.LotNo;
			objNew.LandedCost = obj.LandedCost;
			objNew.GoodsInLineNo = obj.GoodsInLineNo;
			objNew.GoodsInNo = obj.GoodsInNo;
			objNew.CountryOfManufacture = obj.CountryOfManufacture;
			objNew.GoodsInNumber = obj.GoodsInNumber;
			objNew.SupplierNo = obj.SupplierNo;
			objNew.SupplierName = obj.SupplierName;
			objNew.PurchaseOrderLineId = obj.PurchaseOrderLineId;
			objNew.DeliveryDate = obj.DeliveryDate;
			objNew.PurchasePrice = obj.PurchasePrice;
			objNew.ShipViaName = obj.ShipViaName;
            objNew.Reason1 = obj.Reason1;
            objNew.Reason2 = obj.Reason2;
            objNew.RootCause = obj.RootCause;
			return objNew;
		}

		#endregion

	}
}