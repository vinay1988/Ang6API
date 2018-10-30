
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
		public partial class InternalPurchaseOrder : BizObject {
		
		#region Properties

		protected static DAL.InternalPurchaseOrderElement Settings {
            get { return Globals.Settings.InternalPurchaseOrders; }
		}

		/// <summary>
        /// InternalPurchaseOrderId
		/// </summary>
		public System.Int32 InternalPurchaseOrderId { get; set; }		
		/// <summary>
        /// InternalPurchaseOrderNumber
		/// </summary>
        public System.Int32 InternalPurchaseOrderNumber { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32 CompanyNo { get; set; }		
		/// <summary>
		/// ContactNo
		/// </summary>
		public System.Int32 ContactNo { get; set; }		
		/// <summary>
		/// DateOrdered
		/// </summary>
		public System.DateTime DateOrdered { get; set; }		
		/// <summary>
		/// WarehouseNo
		/// </summary>
		public System.Int32 WarehouseNo { get; set; }		
		/// <summary>
		/// CurrencyNo
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }		
		/// <summary>
		/// Buyer
		/// </summary>
		public System.Int32 Buyer { get; set; }		
		/// <summary>
		/// ShipViaNo
		/// </summary>
		public System.Int32? ShipViaNo { get; set; }		
		/// <summary>
		/// Account
		/// </summary>
		public System.String Account { get; set; }		
		/// <summary>
		/// TermsNo
		/// </summary>
		public System.Int32 TermsNo { get; set; }		
		/// <summary>
		/// ExpediteNotes
		/// </summary>
		public System.String ExpediteNotes { get; set; }		
		/// <summary>
		/// ExpediteDate
		/// </summary>
		public System.DateTime? ExpediteDate { get; set; }		
		/// <summary>
		/// TotalShipInCost
		/// </summary>
		public System.Double? TotalShipInCost { get; set; }		
		/// <summary>
		/// DivisionNo
		/// </summary>
		public System.Int32 DivisionNo { get; set; }		
		/// <summary>
		/// TaxNo
		/// </summary>
		public System.Int32 TaxNo { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// Instructions
		/// </summary>
		public System.String Instructions { get; set; }		
		/// <summary>
		/// Paid
		/// </summary>
		public System.Boolean Paid { get; set; }		
		/// <summary>
		/// Confirmed
		/// </summary>
		public System.Boolean Confirmed { get; set; }		
		/// <summary>
		/// ImportCountryNo
		/// </summary>
		public System.Int32? ImportCountryNo { get; set; }		
		/// <summary>
		/// FreeOnBoard
		/// </summary>
		public System.String FreeOnBoard { get; set; }		
		/// <summary>
		/// StatusNo
		/// </summary>
		public System.Int32? StatusNo { get; set; }		
		/// <summary>
		/// Closed
		/// </summary>
		public System.Boolean Closed { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// IncotermNo
		/// </summary>
		public System.Int32? IncotermNo { get; set; }		
		/// <summary>
		/// ApprovedBy
		/// </summary>
		public System.Int32? ApprovedBy { get; set; }		
		/// <summary>
		/// DateApproved
		/// </summary>
		public System.DateTime? DateApproved { get; set; }		
		/// <summary>
		/// CreatedBy
		/// </summary>
		public System.Int32? CreatedBy { get; set; }		
		/// <summary>
		/// CreateDate
		/// </summary>
		public System.DateTime? CreateDate { get; set; }		
		/// <summary>
		/// CompanyName
		/// </summary>
		public System.String CompanyName { get; set; }		
		/// <summary>
		/// ContactName
		/// </summary>
		public System.String ContactName { get; set; }		
		/// <summary>
		/// BuyerName
		/// </summary>
		public System.String BuyerName { get; set; }		
		/// <summary>
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }		
		/// <summary>
		/// RowCnt
		/// </summary>
		public System.Int32? RowCnt { get; set; }		
		/// <summary>
		/// LastReceived
		/// </summary>
		public System.DateTime? LastReceived { get; set; }		
		/// <summary>
		/// WarehouseName
		/// </summary>
		public System.String WarehouseName { get; set; }		
		/// <summary>
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }		
		/// <summary>
		/// CurrencyDescription
		/// </summary>
		public System.String CurrencyDescription { get; set; }		
		/// <summary>
		/// ShipViaName
		/// </summary>
		public System.String ShipViaName { get; set; }		
		/// <summary>
		/// TermsName
		/// </summary>
		public System.String TermsName { get; set; }		
		/// <summary>
		/// DivisionName
		/// </summary>
		public System.String DivisionName { get; set; }		
		/// <summary>
		/// TaxName
		/// </summary>
		public System.String TaxName { get; set; }		
		/// <summary>
		/// ImportCountryName
		/// </summary>
		public System.String ImportCountryName { get; set; }		
		/// <summary>
		/// ImportCountryShippingCost
		/// </summary>
		public System.Double? ImportCountryShippingCost { get; set; }		
		/// <summary>
		/// PurchaseOrderValue
		/// </summary>
		public System.Double? PurchaseOrderValue { get; set; }		
		/// <summary>
		/// TaxRate
		/// </summary>
		public System.Double? TaxRate { get; set; }		
		/// <summary>
		/// IncotermName
		/// </summary>
		public System.String IncotermName { get; set; }		
		/// <summary>
		/// CompanyPORating
		/// </summary>
		public System.Int32? CompanyPORating { get; set; }		
		/// <summary>
		/// Approver
		/// </summary>
		public System.String Approver { get; set; }		
		/// <summary>
		/// CompanyNameForSearch
		/// </summary>
		public System.String CompanyNameForSearch { get; set; }		
		/// <summary>
		/// CompanyTelephone
		/// </summary>
		public System.String CompanyTelephone { get; set; }		
		/// <summary>
		/// CompanyFax
		/// </summary>
		public System.String CompanyFax { get; set; }		
		/// <summary>
		/// ContactEmail
		/// </summary>
		public System.String ContactEmail { get; set; }		
		/// <summary>
		/// OutstandingQuantity
		/// </summary>
		public System.Int32? OutstandingQuantity { get; set; }		
		/// <summary>
		/// CreditLimit
		/// </summary>
		public System.Double? CreditLimit { get; set; }		
		/// <summary>
		/// Balance
		/// </summary>
		public System.Double? Balance { get; set; }		
		/// <summary>
		/// DeliveryDate
		/// </summary>
		public System.DateTime DeliveryDate { get; set; }		
		/// <summary>
		/// DaysOverdue
		/// </summary>
		public System.Int32? DaysOverdue { get; set; }		
		/// <summary>
		/// GoodsInId
		/// </summary>
		public System.Int32 GoodsInId { get; set; }		
		/// <summary>
		/// GoodsInNumber
		/// </summary>
		public System.Int32 GoodsInNumber { get; set; }		
		/// <summary>
		/// DateReceived
		/// </summary>
		public System.DateTime DateReceived { get; set; }
       
        /// <summary>
        /// IsPDFAvailable
        /// </summary>
        public System.Boolean? IsPDFAvailable { get; set; }
      
        public System.String SupplierRMAIds { get; set; }
        public System.String SupplierRMANumbers { get; set; }
        public System.String DebitIds { get; set; }
        public System.String DebitNumbers { get; set; }
    
        public System.Int32? TeamNo { get; set; }

        /// <summary>
        /// CustomerCode 
        /// /// </summary>
        public System.String CustomerCode { get; set; }
        /// <summary>
        /// VATNO 
        /// </summary>
        public System.String VATNO { get; set; }
            //SupplierCode
        public System.String SupplierCode { get; set; }
      
        /// <summary>
        /// AirWayBill
        /// </summary>
        public System.String AirWayBill { get; set; }
       
        /// <summary>
        /// EPRIds
        /// </summary>
        public System.String EPRIds { get; set; }

        public int? PurchaseOrderNo { get; set; }

        public int? RegionNo { get; set; }
        public System.String RegionName { get; set; }
        /// <summary>
        /// PO Buyer
        /// </summary>
        public System.Int32 PoBuyer { get; set; }
        public System.Int32 PurchaseOrderNumber { get; set; }
        public string PoTermsName { get; set; }
        public bool IsApplyPOBankFee { get; set; }
        public System.Int32? GlobalCurrencyNo { get; set; }
		#endregion
		
		#region Methods
		
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_PurchaseOrder_for_Client]
		/// </summary>
		public static Int32 CountForClient(System.Int32? clientId) {
            return Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.CountForClient(clientId);
		}		/// <summary>
		/// CountForCompany
		/// Calls [usp_count_PurchaseOrder_for_Company]
		/// </summary>
		public static Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeClosed) {
            return Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.CountForCompany(companyId, includeClosed);
		}		/// <summary>
		/// CountOpenForCompany
		/// Calls [usp_count_PurchaseOrder_open_for_Company]
		/// </summary>
		public static Int32 CountOpenForCompany(System.Int32? companyId) {
            return Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.CountOpenForCompany(companyId);
		}		/// <summary>
		/// CountReceivingForClient
		/// Calls [usp_count_PurchaseOrder_receiving_for_Client]
		/// </summary>
		public static Int32 CountReceivingForClient(System.Int32? clientId) {
            return Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.CountReceivingForClient(clientId);
		}		/// <summary>
		/// Delete
		/// Calls [usp_delete_PurchaseOrder]
		/// </summary>
		public static bool Delete(System.Int32? purchaseOrderId) {
            return Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.Delete(purchaseOrderId);
		}
        //[003] code start
		/// <summary>
		/// Insert
		/// Calls [usp_insert_PurchaseOrder]
		/// </summary>
		public static Int32 Insert(System.Int32? clientNo, System.Int32? companyNo, System.Int32? contactNo, System.DateTime? dateOrdered, System.Int32? warehouseNo, System.Int32? currencyNo, System.Int32? buyer, System.Int32? shipViaNo, System.String account, System.Int32? termsNo, System.String expediteNotes, System.DateTime? expediteDate, System.Double? totalShipInCost, System.Int32? divisionNo, System.Int32? taxNo, System.String notes, System.String instructions, System.Boolean? paid, System.Boolean? confirmed, System.Int32? importCountryNo, System.String freeOnBoard, System.Int32? statusNo, System.Boolean? closed, System.Int32? incotermNo, System.Int32? updatedBy,System.String airwayBill) {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.Insert(clientNo, companyNo, contactNo, dateOrdered, warehouseNo, currencyNo, buyer, shipViaNo, account, termsNo, expediteNotes, expediteDate, totalShipInCost, divisionNo, taxNo, notes, instructions, paid, confirmed, importCountryNo, freeOnBoard, statusNo, closed, incotermNo, updatedBy, airwayBill);
			return objReturn;
		}
      
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_PurchaseOrder]
		/// </summary>
		public Int32 Insert() {
            return Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.Insert(ClientNo, CompanyNo, ContactNo, DateOrdered, WarehouseNo, CurrencyNo, Buyer, ShipViaNo, Account, TermsNo, ExpediteNotes, ExpediteDate, TotalShipInCost, DivisionNo, TaxNo, Notes, Instructions, Paid, Confirmed, ImportCountryNo, FreeOnBoard, StatusNo, Closed, IncotermNo, UpdatedBy, AirWayBill);
		}
        //[003] code end
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_PurchaseOrder]
		/// </summary>
        public static List<InternalPurchaseOrder> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.Boolean? includeClosed, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo, System.DateTime? expediteDateFrom, System.DateTime? expediteDateTo)
        {
            List<InternalPurchaseOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, contactSearch, cmSearch, buyerSearch, includeClosed, purchaseOrderNoLo, purchaseOrderNoHi, dateOrderedFrom, dateOrderedTo, expediteDateFrom, expediteDateTo);
			if (lstDetails == null) {
                return new List<InternalPurchaseOrder>();
			} else {
                List<InternalPurchaseOrder> lst = new List<InternalPurchaseOrder>();
                foreach (InternalPurchaseOrderDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.InternalPurchaseOrder obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrder();
					obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
					obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.DateOrdered = objDetails.DateOrdered;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.BuyerName = objDetails.BuyerName;
					obj.ExpediteDate = objDetails.ExpediteDate;
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
		/// ItemSearchReceived
		/// Calls [usp_itemsearch_PurchaseOrder_Received]
		/// </summary>
        public static List<InternalPurchaseOrder> ItemSearchReceived(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.Boolean? includeClosed, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo)
        {
            List<InternalPurchaseOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.ItemSearchReceived(clientId, orderBy, sortDir, pageIndex, pageSize, contactSearch, cmSearch, buyerSearch, includeClosed, purchaseOrderNoLo, purchaseOrderNoHi, dateOrderedFrom, dateOrderedTo);
			if (lstDetails == null) {
                return new List<InternalPurchaseOrder>();
			} else {
                List<InternalPurchaseOrder> lst = new List<InternalPurchaseOrder>();
				foreach (InternalPurchaseOrderDetails objDetails in lstDetails) {
                    Rebound.GlobalTrader.BLL.InternalPurchaseOrder obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrder();
					obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
					obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.DateOrdered = objDetails.DateOrdered;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.BuyerName = objDetails.BuyerName;
					obj.LastReceived = objDetails.LastReceived;
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
        /// Calls [usp_select_InternalPurchaseOrder]
		/// </summary>
        public static InternalPurchaseOrder Get(System.Int32? purchaseOrderId)
        {
            Rebound.GlobalTrader.DAL.InternalPurchaseOrderDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.Get(purchaseOrderId);
			if (objDetails == null) {
				return null;
			} else {
                InternalPurchaseOrder obj = new InternalPurchaseOrder();
                obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
                obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
                obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
				obj.ClientNo = objDetails.ClientNo;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.ContactNo = objDetails.ContactNo;
				obj.ContactName = objDetails.ContactName;
				obj.DateOrdered = objDetails.DateOrdered;
				obj.WarehouseNo = objDetails.WarehouseNo;
				obj.WarehouseName = objDetails.WarehouseName;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyDescription = objDetails.CurrencyDescription;
				obj.Buyer = objDetails.Buyer;
				obj.BuyerName = objDetails.BuyerName;
				obj.ShipViaNo = objDetails.ShipViaNo;
				obj.ShipViaName = objDetails.ShipViaName;
				obj.Account = objDetails.Account;
				obj.TermsNo = objDetails.TermsNo;
				obj.TermsName = objDetails.TermsName;
				obj.ExpediteNotes = objDetails.ExpediteNotes;
				obj.ExpediteDate = objDetails.ExpediteDate;
				obj.TotalShipInCost = objDetails.TotalShipInCost;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.DivisionName = objDetails.DivisionName;
				obj.TaxNo = objDetails.TaxNo;
				obj.TaxName = objDetails.TaxName;
				obj.Notes = objDetails.Notes;
				obj.Instructions = objDetails.Instructions;
				obj.Paid = objDetails.Paid;
				obj.Confirmed = objDetails.Confirmed;
				obj.ImportCountryNo = objDetails.ImportCountryNo;
				obj.ImportCountryName = objDetails.ImportCountryName;
				obj.ImportCountryShippingCost = objDetails.ImportCountryShippingCost;
				obj.FreeOnBoard = objDetails.FreeOnBoard;
				obj.PurchaseOrderValue = objDetails.PurchaseOrderValue;
				obj.Closed = objDetails.Closed;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.TaxRate = objDetails.TaxRate;
				obj.StatusNo = objDetails.StatusNo;
				obj.IncotermNo = objDetails.IncotermNo;
				obj.IncotermName = objDetails.IncotermName;
				obj.CompanyPORating = objDetails.CompanyPORating;
				obj.ApprovedBy = objDetails.ApprovedBy;
				obj.DateApproved = objDetails.DateApproved;
				obj.Approver = objDetails.Approver;
                //[002] code start
                obj.SupplierRMAIds = objDetails.SupplierRMAIds;
                obj.SupplierRMANumbers = objDetails.SupplierRMANumbers;
                obj.DebitIds = objDetails.DebitIds;
                obj.DebitNumbers = objDetails.DebitNumbers;
                //[002] code end
                //[003] code start
                obj.AirWayBill = objDetails.AirWayBill;
                obj.SupplierCode = objDetails.SupplierCode;
                obj.EPRIds = objDetails.EPRIds;
                obj.RegionNo = objDetails.RegionNo;
                obj.RegionName = objDetails.RegionName;
                obj.PoBuyer = objDetails.PoBuyer;
                obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                obj.PoTermsName = objDetails.PoTermsName;
                obj.IsApplyPOBankFee = objDetails.IsApplyPOBankFee;
                obj.GlobalCurrencyNo = objDetails.GlobalCurrencyNo;
                //[003] code end
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetByNumber
		/// Calls [usp_select_PurchaseOrder_by_Number]
		/// </summary>
        public static InternalPurchaseOrder GetByNumber(System.Int32? purchaseOrderNumber, System.Int32? clientNo)
        {
            Rebound.GlobalTrader.DAL.InternalPurchaseOrderDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.GetByNumber(purchaseOrderNumber, clientNo);
			if (objDetails == null) {
				return null;
			} else {
                InternalPurchaseOrder obj = new InternalPurchaseOrder();
				obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
				obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
				obj.ClientNo = objDetails.ClientNo;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.ContactNo = objDetails.ContactNo;
				obj.ContactName = objDetails.ContactName;
				obj.DateOrdered = objDetails.DateOrdered;
				obj.WarehouseNo = objDetails.WarehouseNo;
				obj.WarehouseName = objDetails.WarehouseName;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyDescription = objDetails.CurrencyDescription;
				obj.Buyer = objDetails.Buyer;
				obj.BuyerName = objDetails.BuyerName;
				obj.ShipViaNo = objDetails.ShipViaNo;
				obj.ShipViaName = objDetails.ShipViaName;
				obj.Account = objDetails.Account;
				obj.TermsNo = objDetails.TermsNo;
				obj.TermsName = objDetails.TermsName;
				obj.ExpediteNotes = objDetails.ExpediteNotes;
				obj.ExpediteDate = objDetails.ExpediteDate;
				obj.TotalShipInCost = objDetails.TotalShipInCost;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.DivisionName = objDetails.DivisionName;
				obj.TaxNo = objDetails.TaxNo;
				obj.TaxName = objDetails.TaxName;
				obj.Notes = objDetails.Notes;
				obj.Instructions = objDetails.Instructions;
				obj.Paid = objDetails.Paid;
				obj.Confirmed = objDetails.Confirmed;
				obj.ImportCountryNo = objDetails.ImportCountryNo;
				obj.ImportCountryName = objDetails.ImportCountryName;
				obj.ImportCountryShippingCost = objDetails.ImportCountryShippingCost;
				obj.FreeOnBoard = objDetails.FreeOnBoard;
				obj.PurchaseOrderValue = objDetails.PurchaseOrderValue;
				obj.Closed = objDetails.Closed;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.TaxRate = objDetails.TaxRate;
				obj.StatusNo = objDetails.StatusNo;
				obj.IncotermNo = objDetails.IncotermNo;
				obj.IncotermName = objDetails.IncotermName;
				obj.CompanyPORating = objDetails.CompanyPORating;
				obj.ApprovedBy = objDetails.ApprovedBy;
				obj.DateApproved = objDetails.DateApproved;
				obj.Approver = objDetails.Approver;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_PurchaseOrder_for_Page]
		/// </summary>
        public static InternalPurchaseOrder GetForPage(System.Int32? purchaseOrderId)
        {
            Rebound.GlobalTrader.DAL.InternalPurchaseOrderDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.GetForPage(purchaseOrderId);
			if (objDetails == null) {
				return null;
			} else {
                InternalPurchaseOrder obj = new InternalPurchaseOrder();
				obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
				obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.CompanyNameForSearch = objDetails.CompanyNameForSearch;
				obj.ClientNo = objDetails.ClientNo;
				obj.Closed = objDetails.Closed;
				obj.StatusNo = objDetails.StatusNo;
                // [001] code start
                obj.IsPDFAvailable = objDetails.IsPDFAvailable;
                // [001] code end
                obj.TeamNo = objDetails.TeamNo;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.Buyer = objDetails.Buyer;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForPrint
        /// Calls [usp_select_InternalPurchaseOrder_for_Print]
		/// </summary>
        public static InternalPurchaseOrder GetForPrint(System.Int32? purchaseOrderId)
        {
            Rebound.GlobalTrader.DAL.InternalPurchaseOrderDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.GetForPrint(purchaseOrderId);
			if (objDetails == null) {
				return null;
			} else {
                InternalPurchaseOrder obj = new InternalPurchaseOrder();
				obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
				obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
				obj.ClientNo = objDetails.ClientNo;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.ContactNo = objDetails.ContactNo;
				obj.ContactName = objDetails.ContactName;
				obj.DateOrdered = objDetails.DateOrdered;
				obj.WarehouseNo = objDetails.WarehouseNo;
				obj.WarehouseName = objDetails.WarehouseName;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyDescription = objDetails.CurrencyDescription;
				obj.Buyer = objDetails.Buyer;
				obj.BuyerName = objDetails.BuyerName;
				obj.ShipViaNo = objDetails.ShipViaNo;
				obj.ShipViaName = objDetails.ShipViaName;
				obj.Account = objDetails.Account;
				obj.TermsNo = objDetails.TermsNo;
				obj.TermsName = objDetails.TermsName;
				obj.ExpediteNotes = objDetails.ExpediteNotes;
				obj.ExpediteDate = objDetails.ExpediteDate;
				obj.TotalShipInCost = objDetails.TotalShipInCost;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.DivisionName = objDetails.DivisionName;
				obj.TaxNo = objDetails.TaxNo;
				obj.TaxName = objDetails.TaxName;
				obj.Notes = objDetails.Notes;
				obj.Instructions = objDetails.Instructions;
				obj.Paid = objDetails.Paid;
				obj.Confirmed = objDetails.Confirmed;
				obj.ImportCountryNo = objDetails.ImportCountryNo;
				obj.ImportCountryName = objDetails.ImportCountryName;
				obj.ImportCountryShippingCost = objDetails.ImportCountryShippingCost;
				obj.FreeOnBoard = objDetails.FreeOnBoard;
				obj.PurchaseOrderValue = objDetails.PurchaseOrderValue;
				obj.Closed = objDetails.Closed;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.TaxRate = objDetails.TaxRate;
				obj.StatusNo = objDetails.StatusNo;
				obj.IncotermNo = objDetails.IncotermNo;
				obj.IncotermName = objDetails.IncotermName;
				obj.CompanyPORating = objDetails.CompanyPORating;
				obj.ApprovedBy = objDetails.ApprovedBy;
				obj.DateApproved = objDetails.DateApproved;
				obj.Approver = objDetails.Approver;
				obj.CompanyTelephone = objDetails.CompanyTelephone;
				obj.CompanyFax = objDetails.CompanyFax;
				obj.ShipViaName = objDetails.ShipViaName;
				obj.ContactEmail = objDetails.ContactEmail;
				obj.IncotermName = objDetails.IncotermName;
                obj.VATNO = objDetails.VATNO;
                obj.SupplierCode = objDetails.SupplierCode; 
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetIDByNumber
        /// Calls [usp_select_InternalPurchaseOrder_ID_by_Number]
		/// </summary>
        public static InternalPurchaseOrder GetIDByNumber(System.Int32? internalPurchaseOrderNumber, System.Int32? clientNo)
        {
            Rebound.GlobalTrader.DAL.InternalPurchaseOrderDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.GetIDByNumber(internalPurchaseOrderNumber, clientNo);
			if (objDetails == null) {
				return null;
			} else {
                InternalPurchaseOrder obj = new InternalPurchaseOrder();
				obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetNextNumber
		/// Calls [usp_select_PurchaseOrder_NextNumber]
		/// </summary>
        public static InternalPurchaseOrder GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy)
        {
            Rebound.GlobalTrader.DAL.InternalPurchaseOrderDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.GetNextNumber(clientNo, updatedBy);
			if (objDetails == null) {
				return null;
			} else {
                InternalPurchaseOrder obj = new InternalPurchaseOrder();
				obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetStatus
		/// Calls [usp_select_PurchaseOrder_Status]
		/// </summary>
        public static InternalPurchaseOrder GetStatus(System.Int32? purchaseOrderId)
        {
            Rebound.GlobalTrader.DAL.InternalPurchaseOrderDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.GetStatus(purchaseOrderId);
			if (objDetails == null) {
				return null;
			} else {
                InternalPurchaseOrder obj = new InternalPurchaseOrder();
				obj.StatusNo = objDetails.StatusNo;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListDueForClient
		/// Calls [usp_selectAll_PurchaseOrder_due_for_Client]
		/// </summary>
        public static List<InternalPurchaseOrder> GetListDueForClient(System.Int32? clientId, System.Int32? topToSelect)
        {
            List<InternalPurchaseOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.GetListDueForClient(clientId, topToSelect);
			if (lstDetails == null) {
                return new List<InternalPurchaseOrder>();
			} else {
                List<InternalPurchaseOrder> lst = new List<InternalPurchaseOrder>();
                foreach (InternalPurchaseOrderDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.InternalPurchaseOrder obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrder();
					obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
					obj.DateOrdered = objDetails.DateOrdered;
					obj.CompanyName = objDetails.CompanyName;
					obj.OutstandingQuantity = objDetails.OutstandingQuantity;
					obj.CreditLimit = objDetails.CreditLimit;
					obj.Balance = objDetails.Balance;
					obj.Buyer = objDetails.Buyer;
					obj.DeliveryDate = objDetails.DeliveryDate;
					obj.DaysOverdue = objDetails.DaysOverdue;
					obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
					obj.CompanyNo = objDetails.CompanyNo;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForCompany
		/// Calls [usp_selectAll_PurchaseOrder_for_Company]
		/// </summary>
        public static List<InternalPurchaseOrder> GetListForCompany(System.Int32? companyId, System.Boolean? includeClosed)
        {
            List<InternalPurchaseOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.GetListForCompany(companyId, includeClosed);
			if (lstDetails == null) {
                return new List<InternalPurchaseOrder>();
			} else {
                List<InternalPurchaseOrder> lst = new List<InternalPurchaseOrder>();
				foreach (InternalPurchaseOrderDetails objDetails in lstDetails) {
                    Rebound.GlobalTrader.BLL.InternalPurchaseOrder obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrder();
					obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
					obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
					obj.ClientNo = objDetails.ClientNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.DateOrdered = objDetails.DateOrdered;
					obj.WarehouseNo = objDetails.WarehouseNo;
					obj.WarehouseName = objDetails.WarehouseName;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.Buyer = objDetails.Buyer;
					obj.BuyerName = objDetails.BuyerName;
					obj.ShipViaNo = objDetails.ShipViaNo;
					obj.ShipViaName = objDetails.ShipViaName;
					obj.Account = objDetails.Account;
					obj.TermsNo = objDetails.TermsNo;
					obj.TermsName = objDetails.TermsName;
					obj.ExpediteNotes = objDetails.ExpediteNotes;
					obj.ExpediteDate = objDetails.ExpediteDate;
					obj.TotalShipInCost = objDetails.TotalShipInCost;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.DivisionName = objDetails.DivisionName;
					obj.TaxNo = objDetails.TaxNo;
					obj.TaxName = objDetails.TaxName;
					obj.Notes = objDetails.Notes;
					obj.Instructions = objDetails.Instructions;
					obj.Paid = objDetails.Paid;
					obj.Confirmed = objDetails.Confirmed;
					obj.ImportCountryNo = objDetails.ImportCountryNo;
					obj.ImportCountryName = objDetails.ImportCountryName;
					obj.ImportCountryShippingCost = objDetails.ImportCountryShippingCost;
					obj.FreeOnBoard = objDetails.FreeOnBoard;
					obj.PurchaseOrderValue = objDetails.PurchaseOrderValue;
					obj.Closed = objDetails.Closed;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.TaxRate = objDetails.TaxRate;
					obj.StatusNo = objDetails.StatusNo;
					obj.IncotermNo = objDetails.IncotermNo;
					obj.IncotermName = objDetails.IncotermName;
					obj.CompanyPORating = objDetails.CompanyPORating;
					obj.ApprovedBy = objDetails.ApprovedBy;
					obj.DateApproved = objDetails.DateApproved;
					obj.Approver = objDetails.Approver;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListOpenForCompany
		/// Calls [usp_selectAll_PurchaseOrder_open_for_Company]
		/// </summary>
        public static List<InternalPurchaseOrder> GetListOpenForCompany(System.Int32? companyId)
        {
            List<InternalPurchaseOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.GetListOpenForCompany(companyId);
			if (lstDetails == null) {
                return new List<InternalPurchaseOrder>();
			} else {
                List<InternalPurchaseOrder> lst = new List<InternalPurchaseOrder>();
                foreach (InternalPurchaseOrderDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.InternalPurchaseOrder obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrder();
					obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
					obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
					obj.ClientNo = objDetails.ClientNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.DateOrdered = objDetails.DateOrdered;
					obj.WarehouseNo = objDetails.WarehouseNo;
					obj.WarehouseName = objDetails.WarehouseName;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.Buyer = objDetails.Buyer;
					obj.BuyerName = objDetails.BuyerName;
					obj.ShipViaNo = objDetails.ShipViaNo;
					obj.ShipViaName = objDetails.ShipViaName;
					obj.Account = objDetails.Account;
					obj.TermsNo = objDetails.TermsNo;
					obj.TermsName = objDetails.TermsName;
					obj.ExpediteNotes = objDetails.ExpediteNotes;
					obj.ExpediteDate = objDetails.ExpediteDate;
					obj.TotalShipInCost = objDetails.TotalShipInCost;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.DivisionName = objDetails.DivisionName;
					obj.TaxNo = objDetails.TaxNo;
					obj.TaxName = objDetails.TaxName;
					obj.Notes = objDetails.Notes;
					obj.Instructions = objDetails.Instructions;
					obj.Paid = objDetails.Paid;
					obj.Confirmed = objDetails.Confirmed;
					obj.ImportCountryNo = objDetails.ImportCountryNo;
					obj.ImportCountryName = objDetails.ImportCountryName;
					obj.ImportCountryShippingCost = objDetails.ImportCountryShippingCost;
					obj.FreeOnBoard = objDetails.FreeOnBoard;
					obj.PurchaseOrderValue = objDetails.PurchaseOrderValue;
					obj.Closed = objDetails.Closed;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.TaxRate = objDetails.TaxRate;
					obj.StatusNo = objDetails.StatusNo;
					obj.IncotermNo = objDetails.IncotermNo;
					obj.IncotermName = objDetails.IncotermName;
					obj.CompanyPORating = objDetails.CompanyPORating;
					obj.ApprovedBy = objDetails.ApprovedBy;
					obj.DateApproved = objDetails.DateApproved;
					obj.Approver = objDetails.Approver;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListOpenForLogin
		/// Calls [usp_selectAll_PurchaseOrder_open_for_Login]
		/// </summary>
        public static List<InternalPurchaseOrder> GetListOpenForLogin(System.Int32? loginId, System.Int32? topToSelect)
        {
            List<InternalPurchaseOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.GetListOpenForLogin(loginId, topToSelect);
			if (lstDetails == null) {
                return new List<InternalPurchaseOrder>();
			} else {
                List<InternalPurchaseOrder> lst = new List<InternalPurchaseOrder>();
                foreach (InternalPurchaseOrderDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.InternalPurchaseOrder obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrder();
					obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
					obj.DateOrdered = objDetails.DateOrdered;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.OutstandingQuantity = objDetails.OutstandingQuantity;
					obj.CreditLimit = objDetails.CreditLimit;
					obj.Balance = objDetails.Balance;
					obj.Buyer = objDetails.Buyer;
					obj.DeliveryDate = objDetails.DeliveryDate;
					obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListOverdueForCompany
		/// Calls [usp_selectAll_PurchaseOrder_overdue_for_Company]
		/// </summary>
        public static List<InternalPurchaseOrder> GetListOverdueForCompany(System.Int32? companyId)
        {
            List<InternalPurchaseOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.GetListOverdueForCompany(companyId);
			if (lstDetails == null) {
                return new List<InternalPurchaseOrder>();
			} else {
                List<InternalPurchaseOrder> lst = new List<InternalPurchaseOrder>();
                foreach (InternalPurchaseOrderDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.InternalPurchaseOrder obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrder();
					obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
					obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
					obj.ClientNo = objDetails.ClientNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.DateOrdered = objDetails.DateOrdered;
					obj.WarehouseNo = objDetails.WarehouseNo;
					obj.WarehouseName = objDetails.WarehouseName;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.Buyer = objDetails.Buyer;
					obj.BuyerName = objDetails.BuyerName;
					obj.ShipViaNo = objDetails.ShipViaNo;
					obj.ShipViaName = objDetails.ShipViaName;
					obj.Account = objDetails.Account;
					obj.TermsNo = objDetails.TermsNo;
					obj.TermsName = objDetails.TermsName;
					obj.ExpediteNotes = objDetails.ExpediteNotes;
					obj.ExpediteDate = objDetails.ExpediteDate;
					obj.TotalShipInCost = objDetails.TotalShipInCost;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.DivisionName = objDetails.DivisionName;
					obj.TaxNo = objDetails.TaxNo;
					obj.TaxName = objDetails.TaxName;
					obj.Notes = objDetails.Notes;
					obj.Instructions = objDetails.Instructions;
					obj.Paid = objDetails.Paid;
					obj.Confirmed = objDetails.Confirmed;
					obj.ImportCountryNo = objDetails.ImportCountryNo;
					obj.ImportCountryName = objDetails.ImportCountryName;
					obj.ImportCountryShippingCost = objDetails.ImportCountryShippingCost;
					obj.FreeOnBoard = objDetails.FreeOnBoard;
					obj.PurchaseOrderValue = objDetails.PurchaseOrderValue;
					obj.Closed = objDetails.Closed;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.TaxRate = objDetails.TaxRate;
					obj.StatusNo = objDetails.StatusNo;
					obj.IncotermNo = objDetails.IncotermNo;
					obj.IncotermName = objDetails.IncotermName;
					obj.CompanyPORating = objDetails.CompanyPORating;
					obj.ApprovedBy = objDetails.ApprovedBy;
					obj.DateApproved = objDetails.DateApproved;
					obj.Approver = objDetails.Approver;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListOverdueForLogin
		/// Calls [usp_selectAll_PurchaseOrder_overdue_for_Login]
		/// </summary>
        public static List<InternalPurchaseOrder> GetListOverdueForLogin(System.Int32? loginId, System.Int32? topToSelect)
        {
            List<InternalPurchaseOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.GetListOverdueForLogin(loginId, topToSelect);
			if (lstDetails == null) {
                return new List<InternalPurchaseOrder>();
			} else {
                List<InternalPurchaseOrder> lst = new List<InternalPurchaseOrder>();
                foreach (InternalPurchaseOrderDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.InternalPurchaseOrder obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrder();
					obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
					obj.DateOrdered = objDetails.DateOrdered;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.OutstandingQuantity = objDetails.OutstandingQuantity;
					obj.CreditLimit = objDetails.CreditLimit;
					obj.Balance = objDetails.Balance;
					obj.Buyer = objDetails.Buyer;
					obj.DeliveryDate = objDetails.DeliveryDate;
					obj.DaysOverdue = objDetails.DaysOverdue;
					obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListRecentlyReceived
		/// Calls [usp_selectAll_PurchaseOrder_RecentlyReceived]
		/// </summary>
        public static List<InternalPurchaseOrder> GetListRecentlyReceived(System.Int32? clientId, System.Int32? topToSelect)
        {
            List<InternalPurchaseOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.GetListRecentlyReceived(clientId, topToSelect);
			if (lstDetails == null) {
                return new List<InternalPurchaseOrder>();
			} else {
                List<InternalPurchaseOrder> lst = new List<InternalPurchaseOrder>();
				foreach (InternalPurchaseOrderDetails objDetails in lstDetails) {
                    Rebound.GlobalTrader.BLL.InternalPurchaseOrder obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrder();
					obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
					obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
					obj.ClientNo = objDetails.ClientNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.DateOrdered = objDetails.DateOrdered;
					obj.WarehouseNo = objDetails.WarehouseNo;
					obj.WarehouseName = objDetails.WarehouseName;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.Buyer = objDetails.Buyer;
					obj.BuyerName = objDetails.BuyerName;
					obj.ShipViaNo = objDetails.ShipViaNo;
					obj.ShipViaName = objDetails.ShipViaName;
					obj.Account = objDetails.Account;
					obj.TermsNo = objDetails.TermsNo;
					obj.TermsName = objDetails.TermsName;
					obj.ExpediteNotes = objDetails.ExpediteNotes;
					obj.ExpediteDate = objDetails.ExpediteDate;
					obj.TotalShipInCost = objDetails.TotalShipInCost;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.DivisionName = objDetails.DivisionName;
					obj.TaxNo = objDetails.TaxNo;
					obj.TaxName = objDetails.TaxName;
					obj.Notes = objDetails.Notes;
					obj.Instructions = objDetails.Instructions;
					obj.Paid = objDetails.Paid;
					obj.Confirmed = objDetails.Confirmed;
					obj.ImportCountryNo = objDetails.ImportCountryNo;
					obj.ImportCountryName = objDetails.ImportCountryName;
					obj.ImportCountryShippingCost = objDetails.ImportCountryShippingCost;
					obj.FreeOnBoard = objDetails.FreeOnBoard;
					obj.PurchaseOrderValue = objDetails.PurchaseOrderValue;
					obj.Closed = objDetails.Closed;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.TaxRate = objDetails.TaxRate;
					obj.StatusNo = objDetails.StatusNo;
					obj.IncotermNo = objDetails.IncotermNo;
					obj.IncotermName = objDetails.IncotermName;
					obj.CompanyPORating = objDetails.CompanyPORating;
					obj.ApprovedBy = objDetails.ApprovedBy;
					obj.DateApproved = objDetails.DateApproved;
					obj.Approver = objDetails.Approver;
					obj.GoodsInId = objDetails.GoodsInId;
					obj.GoodsInNumber = objDetails.GoodsInNumber;
					obj.DateReceived = objDetails.DateReceived;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
        //[003] code start
		/// <summary>
		/// Update
        /// Calls [usp_update_InternalPurchaseOrder]
		/// </summary>
		public static bool Update(System.Int32? internalPOId, System.Int32? currencyNo, System.Int32? contactNo, System.Int32? buyer, System.Int32? divisionNo, System.Int32? updatedBy) {
            return Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.Update(internalPOId, currencyNo, contactNo, buyer, divisionNo, updatedBy);
		}
      
        ///// <summary>
        ///// Update (without parameters)
        ///// Calls [usp_update_PurchaseOrder]
        ///// </summary>
        //public bool Update() {
        //    return Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.Update(InternalPurchaseOrderId, CurrencyNo, ContactNo, Buyer, ShipViaNo, Account, ExpediteNotes, ExpediteDate, TotalShipInCost, DivisionNo, TaxNo, TermsNo, Notes, Instructions, Paid, Confirmed, ImportCountryNo, FreeOnBoard, StatusNo, Closed, IncotermNo, UpdatedBy, WarehouseNo, AirWayBill);
        //}
        //[003] code start
		/// <summary>
		/// UpdateApprove
		/// Calls [usp_update_PurchaseOrder_Approve]
		/// </summary>
		public static bool UpdateApprove(System.Int32? purchaseOrderId, System.Int32? approvedBy, System.Boolean? approve) {
            return Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.UpdateApprove(purchaseOrderId, approvedBy, approve);
		}
		/// <summary>
		/// UpdateClose
		/// Calls [usp_update_PurchaseOrder_Close]
		/// </summary>
		public static bool UpdateClose(System.Int32? purchaseOrderId, System.Int32? updatedBy) {
            return Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.UpdateClose(purchaseOrderId, updatedBy);
		}

        private static InternalPurchaseOrder PopulateFromDBDetailsObject(InternalPurchaseOrderDetails obj)
        {
            InternalPurchaseOrder objNew = new InternalPurchaseOrder();
			objNew.InternalPurchaseOrderId = obj.InternalPurchaseOrderId;
			objNew.InternalPurchaseOrderNumber = obj.InternalPurchaseOrderNumber;
			objNew.ClientNo = obj.ClientNo;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.ContactNo = obj.ContactNo;
			objNew.DateOrdered = obj.DateOrdered;
			objNew.WarehouseNo = obj.WarehouseNo;
			objNew.CurrencyNo = obj.CurrencyNo;
			objNew.Buyer = obj.Buyer;
			objNew.ShipViaNo = obj.ShipViaNo;
			objNew.Account = obj.Account;
			objNew.TermsNo = obj.TermsNo;
			objNew.ExpediteNotes = obj.ExpediteNotes;
			objNew.ExpediteDate = obj.ExpediteDate;
			objNew.TotalShipInCost = obj.TotalShipInCost;
			objNew.DivisionNo = obj.DivisionNo;
			objNew.TaxNo = obj.TaxNo;
			objNew.Notes = obj.Notes;
			objNew.Instructions = obj.Instructions;
			objNew.Paid = obj.Paid;
			objNew.Confirmed = obj.Confirmed;
			objNew.ImportCountryNo = obj.ImportCountryNo;
			objNew.FreeOnBoard = obj.FreeOnBoard;
			objNew.StatusNo = obj.StatusNo;
			objNew.Closed = obj.Closed;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.IncotermNo = obj.IncotermNo;
			objNew.ApprovedBy = obj.ApprovedBy;
			objNew.DateApproved = obj.DateApproved;
			objNew.CreatedBy = obj.CreatedBy;
			objNew.CreateDate = obj.CreateDate;
			objNew.CompanyName = obj.CompanyName;
			objNew.ContactName = obj.ContactName;
			objNew.BuyerName = obj.BuyerName;
			objNew.RowNum = obj.RowNum;
			objNew.RowCnt = obj.RowCnt;
			objNew.LastReceived = obj.LastReceived;
			objNew.WarehouseName = obj.WarehouseName;
			objNew.CurrencyCode = obj.CurrencyCode;
			objNew.CurrencyDescription = obj.CurrencyDescription;
			objNew.ShipViaName = obj.ShipViaName;
			objNew.TermsName = obj.TermsName;
			objNew.DivisionName = obj.DivisionName;
			objNew.TaxName = obj.TaxName;
			objNew.ImportCountryName = obj.ImportCountryName;
			objNew.ImportCountryShippingCost = obj.ImportCountryShippingCost;
			objNew.PurchaseOrderValue = obj.PurchaseOrderValue;
			objNew.TaxRate = obj.TaxRate;
			objNew.IncotermName = obj.IncotermName;
			objNew.CompanyPORating = obj.CompanyPORating;
			objNew.Approver = obj.Approver;
			objNew.CompanyNameForSearch = obj.CompanyNameForSearch;
			objNew.CompanyTelephone = obj.CompanyTelephone;
			objNew.CompanyFax = obj.CompanyFax;
			objNew.ContactEmail = obj.ContactEmail;
			objNew.OutstandingQuantity = obj.OutstandingQuantity;
			objNew.CreditLimit = obj.CreditLimit;
			objNew.Balance = obj.Balance;
			objNew.DeliveryDate = obj.DeliveryDate;
			objNew.DaysOverdue = obj.DaysOverdue;
			objNew.GoodsInId = obj.GoodsInId;
			objNew.GoodsInNumber = obj.GoodsInNumber;
			objNew.DateReceived = obj.DateReceived;
            return objNew;
        }
        // [001] code start
        /// <summary>
        /// GetListForPurchaseOrder
        /// Calls [usp_selectAll_PDF_for_PurchaseOrder]
        /// </summary>
        public static List<PDFDocument> GetPDFListForPurchageOrder(System.Int32? PurchaseOrderId)
        {
            List<PDFDocumentDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.PurchaseOrder.GetPDFListForPurchageOrder(PurchaseOrderId);
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
        /// Calls [usp_insert_PurchaseOrderPDF]
        /// </summary>
        public static Int32 Insert(System.Int32? PurchaseOrderId, System.String Caption, System.String FileName, System.Int32? UpdatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.Insert(PurchaseOrderId, Caption, FileName, UpdatedBy);
            return objReturn;
        }
        /// Delete
        /// Calls [usp_delete_PurchaseOrderPDF]
        /// </summary>
        public static bool DeletePurchaseOrderPDF(System.Int32? PurchaseOrderPdfId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.DeletePurchaseOrderPDF(PurchaseOrderPdfId);
        }
        public static Int32 InsertExpedite(System.Int32? purchaseOrderId, System.String expediteNotes, System.Int32? UpdatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.InsertExpedite(purchaseOrderId, expediteNotes, UpdatedBy);
        }
        // [001] code end


        //[003] code end

        /// usp_dropdownlist_IPO
        /// </summary>
        /// <param name="docId"></param>
        /// <returns></returns>
        public static List<InternalPurchaseOrder> IPODropDownList(System.Int32? docId)
        {
            List<InternalPurchaseOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.InternalPurchaseOrder.IPODropDownList(docId);
            if (lstDetails == null)
            {
                return new List<InternalPurchaseOrder>();
            }
            else
            {
                List<InternalPurchaseOrder> lst = new List<InternalPurchaseOrder>();
                foreach (InternalPurchaseOrderDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.InternalPurchaseOrder obj = new Rebound.GlobalTrader.BLL.InternalPurchaseOrder();
                    obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
                    obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
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