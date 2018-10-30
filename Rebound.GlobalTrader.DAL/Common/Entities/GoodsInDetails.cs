/*
Marker     Changed by      Date          Remarks
[001]      Vinay           07/05/2012    This need to upload pdf document for goodsIn section
[002]      Vinay           18/09/2012    Ref:## - Display Purchase Country
[003]      Vinay           20/06/2013    CR:- - Supplier Invoice
[004]      Vinay           08/07/2013    Ref:## -32 Nice Label Printing
[005]      Aashu           04/06/2018    Quick Jump in Global Warehouse
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

namespace Rebound.GlobalTrader.DAL {
	
	public class GoodsInDetails {
		
		#region Constructors
		
		public GoodsInDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// GoodsInId (from Table)
		/// </summary>
		public System.Int32 GoodsInId { get; set; }
		/// <summary>
		/// GoodsInNumber (from Table)
		/// </summary>
		public System.Int32 GoodsInNumber { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// ShipViaNo (from Table)
		/// </summary>
		public System.Int32? ShipViaNo { get; set; }
		/// <summary>
		/// AirWayBill (from Table)
		/// </summary>
		public System.String AirWayBill { get; set; }
		/// <summary>
		/// Reference (from Table)
		/// </summary>
		public System.String Reference { get; set; }
		/// <summary>
		/// CompanyNo (from Table)
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// ReceivingNotes (from Table)
		/// </summary>
		public System.String ReceivingNotes { get; set; }
		/// <summary>
		/// DateReceived (from Table)
		/// </summary>
		public System.DateTime DateReceived { get; set; }
		/// <summary>
		/// PurchaseOrderNo (from Table)
		/// </summary>
		public System.Int32? PurchaseOrderNo { get; set; }
		/// <summary>
		/// CurrencyNo (from Table)
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }
		/// <summary>
		/// ReceivedBy (from Table)
		/// </summary>
		public System.Int32 ReceivedBy { get; set; }
		/// <summary>
		/// WarehouseNo (from Table)
		/// </summary>
		public System.Int32 WarehouseNo { get; set; }
		/// <summary>
		/// CustomerRMANo (from Table)
		/// </summary>
		public System.Int32? CustomerRMANo { get; set; }
		/// <summary>
		/// SupplierInvoice (from Table)
		/// </summary>
		public System.String SupplierInvoice { get; set; }
		/// <summary>
		/// InvoiceDate (from Table)
		/// </summary>
		public System.DateTime? InvoiceDate { get; set; }
		/// <summary>
		/// InvoiceAmount (from Table)
		/// </summary>
		public System.Double? InvoiceAmount { get; set; }
		/// <summary>
		/// BankFee (from Table)
		/// </summary>
		public System.Double? BankFee { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// GoodsValue (from Table)
		/// </summary>
		public System.Double? GoodsValue { get; set; }
		/// <summary>
		/// Tax (from Table)
		/// </summary>
		public System.Double? Tax { get; set; }
		/// <summary>
		/// DeliveryCharge (from Table)
		/// </summary>
		public System.Double? DeliveryCharge { get; set; }
		/// <summary>
		/// CreditCardFee (from Table)
		/// </summary>
		public System.Double? CreditCardFee { get; set; }
		/// <summary>
		/// CanBeExported (from Table)
		/// </summary>
		public System.Boolean CanBeExported { get; set; }
		/// <summary>
		/// Exported (from Table)
		/// </summary>
		public System.Boolean Exported { get; set; }
		/// <summary>
		/// CompanyName (from usp_itemsearch_Debit)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// PurchaseOrderNumber (from usp_itemsearch_Debit)
		/// </summary>
		public System.Int32? PurchaseOrderNumber { get; set; }
		/// <summary>
		/// CustomerRMANumber (from usp_itemsearch_GoodsIn)
		/// </summary>
		public System.Int32? CustomerRMANumber { get; set; }
		/// <summary>
		/// ReceiverName (from usp_itemsearch_GoodsIn)
		/// </summary>
		public System.String ReceiverName { get; set; }
		/// <summary>
		/// RowNum (from usp_itemsearch_Debit)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_itemsearch_Debit)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// WarehouseName (from usp_select_GoodsIn)
		/// </summary>
		public System.String WarehouseName { get; set; }
		/// <summary>
		/// GoodsInValue (from usp_select_GoodsIn)
		/// </summary>
		public System.Double? GoodsInValue { get; set; }
		/// <summary>
		/// DivisionNo (from Table)
		/// </summary>
		public System.Int32? DivisionNo { get; set; }
		/// <summary>
		/// TeamNo (from usp_select_Debit)
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_select_Debit)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// CurrencyDescription (from usp_select_Debit)
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// ShipViaName (from usp_select_GoodsIn)
		/// </summary>
		public System.String ShipViaName { get; set; }
		/// <summary>
		/// StatusNo (from usp_select_GoodsIn)
		/// </summary>
		public System.Int32? StatusNo { get; set; }
		/// <summary>
		/// SupplierRMANo (from Table)
		/// </summary>
		public System.Int32? SupplierRMANo { get; set; }
		/// <summary>
		/// SupplierRMANumber (from usp_itemsearch_Debit)
		/// </summary>
		public System.Int32? SupplierRMANumber { get; set; }
		/// <summary>
		/// DivisionName (from usp_select_Debit)
		/// </summary>
		public System.String DivisionName { get; set; }
		/// <summary>
		/// Buyer (from Table)
		/// </summary>
		public System.Int32 Buyer { get; set; }
		/// <summary>
		/// BuyerName (from usp_select_Debit)
		/// </summary>
		public System.String BuyerName { get; set; }
		/// <summary>
		/// ReceivedByName (from usp_select_GoodsIn_as_ReceivedPO)
		/// </summary>
		public System.String ReceivedByName { get; set; }
		/// <summary>
		/// ContactNo (from Table)
		/// </summary>
		public System.Int32 ContactNo { get; set; }
		/// <summary>
		/// ContactName (from usp_itemsearch_Debit)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// TotalShipInCost (from usp_select_GoodsIn_as_ReceivedPO)
		/// </summary>
		public System.Double? TotalShipInCost { get; set; }
		/// <summary>
		/// CompanyNameForSearch (from usp_select_GoodsIn_for_Page)
		/// </summary>
		public System.String CompanyNameForSearch { get; set; }
		/// <summary>
		/// SupplierTelephone (from usp_select_GoodsIn_for_Print)
		/// </summary>
		public System.String SupplierTelephone { get; set; }
		/// <summary>
		/// SupplierFax (from usp_select_GoodsIn_for_Print)
		/// </summary>
		public System.String SupplierFax { get; set; }
        // [001] code start
        /// <summary>
        /// IsPDFAvailable
        /// </summary>
        public System.Boolean? IsPDFAvailable { get; set; }
        // [001] code end
        //[002] code start
        /// <summary>
        /// PurchaseCountryNo
        /// </summary>
        public System.Int32? PurchaseCountryNo { get; set; }
        /// <summary>
        /// PurchaseCountryName
        /// </summary>
        public System.String PurchaseCountryName { get; set; }
        //[002] code end
        public System.String SupplierType { get; set; }
        //[003] code start
        /// <summary>
        /// SupplierInvoiceNos
        /// </summary>
        public System.String SupplierInvoiceNos { get; set; }
        /// <summary>
        /// SupplierInvoiceNumbers
        /// </summary>
        public System.String SupplierInvoiceNumbers { get; set; }
        /// <summary>
        /// TaxNo
        /// </summary>
        public System.Int32? TaxNo { get; set; }
        /// <summary>
        /// GlobalCurrencyNo
        /// </summary>
        public System.Int32? GlobalCurrencyNo { get; set; }
     
        //[003] code end

        public int? IPOSupplier { get; set; }

        public string IPOSupplierName { get; set; }

        public int? InternalPurchaseOrderId { get; set; }

        public int? InternalPurchaseOrderNo { get; set; }

        /// <summary>
        /// POClientNo (from Table)
        /// </summary>
        public System.Int32? POClientNo { get; set; }
        /// <summary>
        /// GoodsInValueForClient (from Table)
        /// </summary>
        public System.Double? GoodsInValueForClient { get; set; }

        /// <summary>
        /// ClientName (from table)
        /// </summary>
        public System.String ClientName { get; set; }

        public System.Int32? ClientCurrencyNo { get; set; }
        public System.String ClientCurrencyCode { get; set; }

        /// </summary>
        public System.String ClientBaseCurrencyCode { get; set; }
        public int? ClientBaseCurrencyID { get; set; }
        /// <summary>
        /// GoodsInNumberDetail (from Table)
        /// </summary>
        //[005] start
        public System.String GoodsInNumberDetail { get; set; }
        //[005] end
		#endregion

	}
}
