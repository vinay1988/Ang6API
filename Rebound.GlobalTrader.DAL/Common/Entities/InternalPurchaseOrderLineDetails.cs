//Marker     changed by      date          Remarks
//[001]      Vinay           18/09/2012    Ref:## - Display Purchase Country
//[002]      Raushan         27/02/2014    Ref:## - Supplier RMA-ISCRMA
//[003]      Aashu Singh     25/06/2018   Show supplier warranty for ipo line detail
//[004]      Aashu Singh     29/06/2018   Show msl detai.

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
	
	public class InternalPurchaseOrderLineDetails {
		
		#region Constructors

        public InternalPurchaseOrderLineDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// PurchaseOrderLineId (from Table)
		/// </summary>
		public System.Int32 PurchaseOrderLineId { get; set; }
		/// <summary>
		/// PurchaseOrderNo (from Table)
		/// </summary>
        public System.Int32 PurchaseOrderNo { get; set; }

        public int? PurchaseOrderLineNo { get; set; }
        public int? InternalPurchaseOrderLineNo { get; set; }
		/// <summary>
		/// FullPart (from Table)
		/// </summary>
		public System.String FullPart { get; set; }
		/// <summary>
		/// Part (from Table)
		/// </summary>
		public System.String Part { get; set; }
		/// <summary>
		/// ManufacturerNo (from Table)
		/// </summary>
		public System.Int32? ManufacturerNo { get; set; }
		/// <summary>
		/// DateCode (from Table)
		/// </summary>
		public System.String DateCode { get; set; }
		/// <summary>
		/// PackageNo (from Table)
		/// </summary>
		public System.Int32? PackageNo { get; set; }
		/// <summary>
		/// Quantity (from Table)
		/// </summary>
		public System.Int32 Quantity { get; set; }
		/// <summary>
		/// Price (from Table)
		/// </summary>
		public System.Double Price { get; set; }
		/// <summary>
		/// DeliveryDate (from Table)
		/// </summary>
		public System.DateTime DeliveryDate { get; set; }
		/// <summary>
		/// ReceivingNotes (from Table)
		/// </summary>
		public System.String ReceivingNotes { get; set; }
		/// <summary>
		/// Taxable (from Table)
		/// </summary>
		public System.Boolean Taxable { get; set; }
		/// <summary>
		/// ProductNo (from Table)
		/// </summary>
		public System.Int32? ProductNo { get; set; }
		/// <summary>
		/// Posted (from Table)
		/// </summary>
		public System.Boolean Posted { get; set; }
		/// <summary>
		/// ShipInCost (from Table)
		/// </summary>
		public System.Double? ShipInCost { get; set; }
		/// <summary>
		/// SupplierPart (from Table)
		/// </summary>
		public System.String SupplierPart { get; set; }
		/// <summary>
		/// Inactive (from Table)
		/// </summary>
		public System.Boolean Inactive { get; set; }
		/// <summary>
		/// Closed (from Table)
		/// </summary>
		public System.Boolean Closed { get; set; }
		/// <summary>
		/// ROHS (from Table)
		/// </summary>
		public System.Byte? ROHS { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// Notes (from Table)
		/// </summary>
		public System.String Notes { get; set; }
		/// <summary>
		/// FullSupplierPart (from Table)
		/// </summary>
		public System.String FullSupplierPart { get; set; }
		/// <summary>
		/// PurchaseOrderId (from usp_datalistnugget_PurchaseOrderLine)
		/// </summary>
		public System.Int32 PurchaseOrderId { get; set; }
		/// <summary>
		/// PurchaseOrderNumber (from usp_datalistnugget_PurchaseOrderLine)
		/// </summary>
		public System.Int32 PurchaseOrderNumber { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_datalistnugget_PurchaseOrderLine)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// QuantityOrdered (from usp_datalistnugget_PurchaseOrderLine)
		/// </summary>
		public System.Int32 QuantityOrdered { get; set; }
		/// <summary>
		/// DateOrdered (from usp_datalistnugget_PurchaseOrderLine)
		/// </summary>
		public System.DateTime DateOrdered { get; set; }
		/// <summary>
		/// CompanyName (from usp_datalistnugget_PurchaseOrderLine)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// CompanyNo (from usp_datalistnugget_PurchaseOrderLine)
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// ContactName (from usp_datalistnugget_PurchaseOrderLine)
		/// </summary>
		public System.String ContactName { get; set; }
		/// <summary>
		/// ContactNo (from usp_datalistnugget_PurchaseOrderLine)
		/// </summary>
		public System.Int32 ContactNo { get; set; }
		/// <summary>
		/// ManufacturerCode (from usp_datalistnugget_PurchaseOrderLine)
		/// </summary>
		public System.String ManufacturerCode { get; set; }
		/// <summary>
		/// RowNum (from usp_datalistnugget_PurchaseOrderLine)
		/// </summary>
		public System.Int64? RowNum { get; set; }
		/// <summary>
		/// RowCnt (from usp_datalistnugget_PurchaseOrderLine)
		/// </summary>
		public System.Int32? RowCnt { get; set; }
		/// <summary>
		/// Status (from usp_datalistnugget_PurchaseOrderLine)
		/// </summary>
		public System.Int32? Status { get; set; }
		/// <summary>
		/// QuantityOutstanding (from usp_datalistnugget_PurchaseOrderLine)
		/// </summary>
		public System.Int32? QuantityOutstanding { get; set; }
		/// <summary>
		/// EarliestShipDate (from usp_datalistnugget_PurchaseOrderLine_AllForReceiving)
		/// </summary>
		public System.DateTime? EarliestShipDate { get; set; }
		/// <summary>
		/// PurchaseOrderValue (from usp_itemsearch_PurchaseOrderLine)
		/// </summary>
		public System.Double? PurchaseOrderValue { get; set; }
		/// <summary>
		/// LineNotes (from usp_select_PurchaseOrderLine)
		/// </summary>
		public System.String LineNotes { get; set; }
		/// <summary>
		/// QuantityReceived (from usp_select_PurchaseOrderLine)
		/// </summary>
		public System.Int32 QuantityReceived { get; set; }
		/// <summary>
		/// QuantityAllocated (from usp_select_PurchaseOrderLine)
		/// </summary>
		public System.Int32 QuantityAllocated { get; set; }
		/// <summary>
		/// GIShipInCost (from usp_select_PurchaseOrderLine)
		/// </summary>
		public System.Double GIShipInCost { get; set; }
		/// <summary>
		/// ProductName (from usp_select_PurchaseOrderLine)
		/// </summary>
		public System.String ProductName { get; set; }
		/// <summary>
		/// ProductDescription (from usp_select_PurchaseOrderLine)
		/// </summary>
		public System.String ProductDescription { get; set; }
		/// <summary>
		/// ProductDutyCode (from usp_select_PurchaseOrderLine)
		/// </summary>
		public System.String ProductDutyCode { get; set; }
		/// <summary>
		/// PackageName (from usp_select_PurchaseOrderLine)
		/// </summary>
		public System.String PackageName { get; set; }
		/// <summary>
		/// PackageDescription (from usp_select_PurchaseOrderLine)
		/// </summary>
		public System.String PackageDescription { get; set; }
		/// <summary>
		/// ImportCountryShippingCost (from usp_select_PurchaseOrderLine)
		/// </summary>
		public System.Double? ImportCountryShippingCost { get; set; }
		/// <summary>
		/// CurrencyNo (from usp_select_PurchaseOrderLine)
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }
		/// <summary>
		/// CurrencyDescription (from usp_select_PurchaseOrderLine)
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// ManufacturerName (from usp_select_PurchaseOrderLine)
		/// </summary>
		public System.String ManufacturerName { get; set; }
		/// <summary>
		/// TaxRate (from usp_select_PurchaseOrderLine)
		/// </summary>
		public System.Double? TaxRate { get; set; }
		/// <summary>
		/// ClientNo (from usp_select_PurchaseOrderLine)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// QuantityToReturn (from usp_select_PurchaseOrderLine_for_SupplierRMALine)
		/// </summary>
		public System.Int32? QuantityToReturn { get; set; }
		/// <summary>
		/// ExpediteDate (from usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder)
		/// </summary>
		public System.DateTime? ExpediteDate { get; set; }
		/// <summary>
		/// Buyer (from usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder)
		/// </summary>
		public System.Int32 Buyer { get; set; }
		/// <summary>
		/// BuyerName (from usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder)
		/// </summary>
		public System.String BuyerName { get; set; }
		/// <summary>
		/// DivisionNo (from usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder)
		/// </summary>
		public System.Int32 DivisionNo { get; set; }
		/// <summary>
		/// TeamNo (from usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder)
		/// </summary>
		public System.Int32? TeamNo { get; set; }
		/// <summary>
		/// FullName (from usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder)
		/// </summary>
		public System.String FullName { get; set; }
		/// <summary>
		/// CreditLimit (from usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder)
		/// </summary>
		public System.Double? CreditLimit { get; set; }
		/// <summary>
		/// Balance (from usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder)
		/// </summary>
		public System.Double? Balance { get; set; }
		/// <summary>
		/// LineValue (from usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder)
		/// </summary>
		public System.Double LineValue { get; set; }
		/// <summary>
		/// TermsNo (from usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder)
		/// </summary>
		public System.Int32 TermsNo { get; set; }
		/// <summary>
		/// TermsName (from usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder)
		/// </summary>
		public System.String TermsName { get; set; }
		/// <summary>
		/// InAdvance (from usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder)
		/// </summary>
		public System.Boolean InAdvance { get; set; }
		/// <summary>
		/// DatePromised (from usp_selectAll_PurchaseOrderLine_Receiving_for_PurchaseOrder)
		/// </summary>
		public System.DateTime DatePromised { get; set; }
		/// <summary>
		/// ClientName (from usp_source_PurchaseOrderLine)
		/// </summary>
		public System.String ClientName { get; set; }
		/// <summary>
		/// ClientDataVisibleToOthers (from usp_source_PurchaseOrderLine)
		/// </summary>
		public System.Boolean? ClientDataVisibleToOthers { get; set; }
        //[001] code start
        /// <summary>
        /// ImportCountryNo
        /// </summary>
        public System.Int32? ImportCountryNo { get; set; }
        //[001] code end
        /// </summary>
        public System.DateTime PromiseDate { get; set; }
        /// <summary>
        /// Location
        /// </summary>
        public System.String Location { get; set; }
        /// <summary>
        /// IsNprExist
        /// </summary>
        public System.Boolean? IsNprExist { get; set; }
        /// <summary>
        /// blnSRMA
        /// </summary>
        public System.Boolean? blnSRMA { get; set; }
        /// <summary>
        /// POSerialNo
        /// </summary>
        public System.Int16? POSerialNo { get; set; }
        //[002] Code Start
        /// <summary>
        /// IsCRMA
        /// </summary>
        public System.Boolean? IsCRMA { get; set; }
        //[002] Code End

        public System.Int32? InternalPurchaseOrderNo { get; set; }
        public System.Int32? InternalPurchaseOrderId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.String EmployeeName { get; set; }
        /// <summary>
        /// IPOStatus
        /// </summary>
        public System.Int32? IPOStatus { get; set; }
        //[003] start
        /// <summary>
        /// SupplierWarranty
        /// </summary>
        public System.Int32? SupplierWarranty { get; set; }
        //[003] end
        //[004] start
        /// <summary>
        /// SupplierWarranty
        /// </summary>
        public System.String MSLLevel { get; set; }
        //[004] end
		#endregion

	}
}