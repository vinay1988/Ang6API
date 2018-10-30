
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Rebound.GlobalTrader.DAL {
	
	public class InternalPurchaseOrderDetails {
		
		#region Constructors
		
		public InternalPurchaseOrderDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// PurchaseOrderId (from Table)
		/// </summary>
        public System.Int32 InternalPurchaseOrderId { get; set; }
		/// <summary>
		/// PurchaseOrderNumber (from Table)
		/// </summary>
        public System.Int32 InternalPurchaseOrderNumber { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// CompanyNo (from Table)
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// ContactNo (from Table)
		/// </summary>
		public System.Int32 ContactNo { get; set; }
		/// <summary>
		/// DateOrdered (from Table)
		/// </summary>
		public System.DateTime DateOrdered { get; set; }
		/// <summary>
		/// WarehouseNo (from Table)
		/// </summary>
		public System.Int32 WarehouseNo { get; set; }
		/// <summary>
		/// CurrencyNo (from Table)
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }
		/// <summary>
		/// Buyer (from Table)
		/// </summary>
		public System.Int32 Buyer { get; set; }
		/// <summary>
		/// ShipViaNo (from Table)
		/// </summary>
		public System.Int32? ShipViaNo { get; set; }
		/// <summary>
		/// Account (from Table)
		/// </summary>
		public System.String Account { get; set; }
		/// <summary>
		/// TermsNo (from Table)
		/// </summary>
		public System.Int32 TermsNo { get; set; }
		/// <summary>
		/// ExpediteNotes (from Table)
		/// </summary>
		public System.String ExpediteNotes { get; set; }
		/// <summary>
		/// ExpediteDate (from Table)
		/// </summary>
		public System.DateTime? ExpediteDate { get; set; }
		/// <summary>
		/// TotalShipInCost (from Table)
		/// </summary>
		public System.Double? TotalShipInCost { get; set; }
		/// <summary>
		/// DivisionNo (from Table)
		/// </summary>
		public System.Int32 DivisionNo { get; set; }
		/// <summary>
		/// TaxNo (from Table)
		/// </summary>
		public System.Int32 TaxNo { get; set; }
		/// <summary>
		/// Notes (from Table)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// Instructions (from Table)
		/// </summary>
		public System.String Instructions { get; set; }
		/// <summary>
		/// Paid (from Table)
		/// </summary>
		public System.Boolean Paid { get; set; }
		/// <summary>
		/// Confirmed (from Table)
		/// </summary>
		public System.Boolean Confirmed { get; set; }
		/// <summary>
		/// ImportCountryNo (from Table)
		/// </summary>
		public System.Int32? ImportCountryNo { get; set; }
		/// <summary>
		/// FreeOnBoard (from Table)
		/// </summary>
		public System.String FreeOnBoard { get; set; }
		/// <summary>
		/// StatusNo (from Table)
		/// </summary>
		public System.Int32? StatusNo { get; set; }
		/// <summary>
		/// Closed (from Table)
		/// </summary>
		public System.Boolean Closed { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// IncotermNo (from Table)
		/// </summary>
		public System.Int32? IncotermNo { get; set; }
		/// <summary>
		/// ApprovedBy (from Table)
		/// </summary>
		public System.Int32? ApprovedBy { get; set; }
		/// <summary>
		/// DateApproved (from Table)
		/// </summary>
		public System.DateTime? DateApproved { get; set; }
		/// <summary>
		/// CreatedBy (from Table)
		/// </summary>
		public System.Int32? CreatedBy { get; set; }
		/// <summary>
		/// CreateDate (from Table)
		/// </summary>
		public System.DateTime? CreateDate { get; set; }
		/// <summary>
		/// CompanyName (from usp_itemsearch_PurchaseOrder)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// ContactName (from usp_itemsearch_PurchaseOrder)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// BuyerName (from usp_itemsearch_PurchaseOrder)
		/// </summary>
		public System.String BuyerName { get; set; }
		/// <summary>
		/// RowNum (from usp_itemsearch_PurchaseOrder)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_itemsearch_PurchaseOrder)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// LastReceived (from usp_itemsearch_PurchaseOrder_Received)
		/// </summary>
		public System.DateTime? LastReceived { get; set; }
		/// <summary>
		/// WarehouseName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String WarehouseName { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// CurrencyDescription (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// ShipViaName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String ShipViaName { get; set; }
		/// <summary>
		/// TermsName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String TermsName { get; set; }
		/// <summary>
		/// DivisionName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String DivisionName { get; set; }
		/// <summary>
		/// TaxName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String TaxName { get; set; }
		/// <summary>
		/// ImportCountryName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String ImportCountryName { get; set; }
		/// <summary>
		/// ImportCountryShippingCost (from usp_select_PurchaseOrder)
		/// </summary>
		public System.Double? ImportCountryShippingCost { get; set; }
		/// <summary>
		/// PurchaseOrderValue (from usp_select_PurchaseOrder)
		/// </summary>
		public System.Double? PurchaseOrderValue { get; set; }
		/// <summary>
		/// TaxRate (from usp_select_PurchaseOrder)
		/// </summary>
		public System.Double? TaxRate { get; set; }
		/// <summary>
		/// IncotermName (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String IncotermName { get; set; }
		/// <summary>
		/// CompanyPORating (from usp_select_PurchaseOrder)
		/// </summary>
		public System.Int32? CompanyPORating { get; set; }
		/// <summary>
		/// Approver (from usp_select_PurchaseOrder)
		/// </summary>
		public System.String Approver { get; set; }
		/// <summary>
		/// CompanyNameForSearch (from usp_select_PurchaseOrder_for_Page)
		/// </summary>
		public System.String CompanyNameForSearch { get; set; }
		/// <summary>
		/// CompanyTelephone (from usp_select_PurchaseOrder_for_Print)
		/// </summary>
		public System.String CompanyTelephone { get; set; }
		/// <summary>
		/// CompanyFax (from usp_select_PurchaseOrder_for_Print)
		/// </summary>
		public System.String CompanyFax { get; set; }
		/// <summary>
		/// ContactEmail (from usp_select_PurchaseOrder_for_Print)
		/// </summary>
		public System.String ContactEmail { get; set; }
		/// <summary>
		/// OutstandingQuantity (from usp_selectAll_PurchaseOrder_due_for_Client)
		/// </summary>
		public System.Int32? OutstandingQuantity { get; set; }
		/// <summary>
		/// CreditLimit (from usp_selectAll_PurchaseOrder_due_for_Client)
		/// </summary>
		public System.Double? CreditLimit { get; set; }
		/// <summary>
		/// Balance (from usp_selectAll_PurchaseOrder_due_for_Client)
		/// </summary>
		public System.Double? Balance { get; set; }
		/// <summary>
		/// DeliveryDate (from usp_selectAll_PurchaseOrder_due_for_Client)
		/// </summary>
		public System.DateTime DeliveryDate { get; set; }
		/// <summary>
		/// DaysOverdue (from usp_selectAll_PurchaseOrder_due_for_Client)
		/// </summary>
		public System.Int32? DaysOverdue { get; set; }
		/// <summary>
		/// GoodsInId (from usp_selectAll_PurchaseOrder_RecentlyReceived)
		/// </summary>
		public System.Int32 GoodsInId { get; set; }
		/// <summary>
		/// GoodsInNumber (from usp_selectAll_PurchaseOrder_RecentlyReceived)
		/// </summary>
		public System.Int32 GoodsInNumber { get; set; }
		/// <summary>
		/// DateReceived (from usp_selectAll_PurchaseOrder_RecentlyReceived)
		/// </summary>
		public System.DateTime DateReceived { get; set; }
        // [001] code start
        /// <summary>
        /// IsPDFAvailable
        /// </summary>
        public System.Boolean? IsPDFAvailable { get; set; }
        // [001] code end
        //[002] code start
        public System.String SupplierRMAIds { get; set; }
        public System.String SupplierRMANumbers { get; set; }
        public System.String DebitIds { get; set; }
        public System.String DebitNumbers { get; set; }
        //[002] code end
        public System.Int32? TeamNo { get; set; }
        //[003] code start
        /// <summary>
        /// SupplierCode (from usp_select_PurchaseOrder_for_Print)
        /// </summary>
        public System.String SupplierCode { get; set; }

        /// <summary>
        /// VATNO (from usp_select_PurchaseOrder_for_Print)
        /// </summary>
        public System.String VATNO { get; set; }
        //[003] code end
        //[004] code start
        /// <summary>
        /// AirWayBill
        /// </summary>
        public System.String AirWayBill { get; set; }
        //[004] code end
        /// <summary>
        /// EPRIds
        /// </summary>
        public System.String EPRIds { get; set; }

        public int? PurchaseOrderNo { get; set; }
        /// <summary>
        /// IPOClientNo (from Table)
        /// </summary>
        public System.Int32 IPOClientNo { get; set; }

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

	}
}