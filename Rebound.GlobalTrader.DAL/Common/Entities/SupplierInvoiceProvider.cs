//Marker     Changed by      Date               Remarks
//[001]      Vinay           11/06/2013         CR:- Supplier Invoice
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebound.GlobalTrader.DAL
{
  public abstract class SupplierInvoiceProvider : DataAccess
    {
        static private SupplierInvoiceProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SupplierInvoiceProvider Instance {
			get {
                if (_instance == null) _instance = (SupplierInvoiceProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.SupplierInvoices.ProviderType));
				return _instance;
			}
		}
        public SupplierInvoiceProvider()
        {
			this.ConnectionString = Globals.Settings.SupplierInvoices.ConnectionString;
		}

        #region Method Registrations

        /// <summary>
        /// Call Proc [usp_select_SupplierInvoice]
        /// Get the supplier invoice by supplierinvoiceId
        /// </summary>
        /// <param name="supplierInvoiceId"></param>
        /// <returns></returns>
        public abstract SupplierInvoiceDetails Get(System.Int32? supplierInvoiceId);
        /// <summary>
        /// Call Proc [usp_insert_SupplierInvoice]
        /// Insert supplier invoice header
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="companyNo"></param>
        /// <param name="supplierInvoiceNumber"></param>
        /// <param name="supplierInvoiceDate"></param>
        /// <param name="supplierCode"></param>
        /// <param name="supplierName"></param>
        /// <param name="cuurencyNo"></param>
        /// <param name="amount"></param>
        /// <param name="goodsValue"></param>
        /// <param name="Tax"></param>
        /// <param name="deliveryCharge"></param>
        /// <param name="bankFee"></param>
        /// <param name="creditCardFee"></param>
        /// <param name="notes"></param>
        /// <param name="secondRef"></param>
        /// <param name="narrative"></param>
        /// <param name="canBeExported"></param>
        /// <param name="taxNo"></param>
        /// <param name="taxCode"></param>
        /// <param name="currencyCode"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public abstract Int32 Insert(System.Int32? clientNo, System.Int32 companyNo, System.String supplierInvoiceNumber, System.DateTime? supplierInvoiceDate, System.String supplierCode, System.String supplierName, System.Int32? currencyNo, System.Double? amount, System.Double? goodsValue, System.Double? tax, System.Double? deliveryCharge, System.Double? bankFee, System.Double? creditCardFee, System.String notes, System.String secondRef, System.String narrative, System.Boolean? canBeExported, System.Int32? taxNo, System.String taxCode, System.String currencyCode, System.Int32 updatedBy, System.Int32? statusReason);

      /// <summary>
      /// Call Proc [usp_datalistnugget_SupplierInvoice]
      /// Get list of supplier invoice on basis of following search criteria
      /// </summary>
      /// <param name="clientId"></param>
      /// <param name="orderBy"></param>
      /// <param name="sortDir"></param>
      /// <param name="pageIndex"></param>
      /// <param name="pageSize"></param>
      /// <param name="supplierInvoiceNumber"></param>
      /// <param name="urnNoLo"></param>
      /// <param name="urnNoHi"></param>
      /// <param name="purchaseOrderNoLo"></param>
      /// <param name="purchaseOrderNoHi"></param>
      /// <param name="goodsInNoLo"></param>
      /// <param name="goodsInNoHi"></param>
      /// <param name="supplierInvoiceDateFrom"></param>
      /// <param name="supplierInvoiceDateTo"></param>
      /// <param name="cmSearch"></param>
      /// <param name="recentOnly"></param>
      /// <param name="cannotBeExported"></param>
      /// <returns></returns>
        public abstract List<SupplierInvoiceDetails> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String supplierInvoiceNumber, System.Int32? urnNoLo, System.Int32? urnNoHi, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? goodsInNoLo, System.Int32? goodsInNoHi, System.DateTime? supplierInvoiceDateFrom, System.DateTime? supplierInvoiceDateTo, System.String cmSearch, System.Boolean? recentOnly, System.Boolean? exportedOnly, System.Boolean? approveandUnExported, System.Boolean? cannotBeExported, System.Int32? internalPurchaseOrderNoLo, System.Int32? internalPurchaseOrderNoHi, System.Int32? statusReason);

        /// <summary>
        /// Get detail for supplier invoice detail page
        /// Call Proc [usp_select_SupplierInvoice_for_Page]
        /// </summary>
        /// <param name="supplierInvoiceId"></param>
        /// <returns></returns>
        public abstract SupplierInvoiceDetails GetForPage(System.Int32? supplierInvoiceId);

        /// <summary>
        /// Update supplier invoice main info
        /// Call Proc [usp_update_SupplierInvoice]
        /// </summary>
        /// <param name="supplierInvoiceId"></param>
        /// <param name="supplierInvoiceId"></param>
        /// <param name="supplierInvoiceDate"></param>
        /// <param name="currencyNo"></param>
        /// <param name="amount"></param>
        /// <param name="goodsValue"></param>
        /// <param name="tax"></param>
        /// <param name="deliveryCharge"></param>
        /// <param name="bankFee"></param>
        /// <param name="creditCardFee"></param>
        /// <param name="canbeExported"></param>
        /// <param name="notes"></param>
        /// <param name="taxCode"></param>
        /// <param name="currencyCode"></param>
        /// <param name="secondRef"></param>
        /// <param name="narrtive"></param>
        /// <param name="updatedBy"></param>
        /// <param name="urnNumber"></param>
        /// <returns></returns>
        public abstract bool Update(System.Int32 supplierInvoiceId, System.String supplierInvoiceNumber, System.DateTime? supplierInvoiceDate, System.Int32? currencyNo, System.Double? amount, System.Double? goodsValue, System.Double? tax, System.Double? deliveryCharge, System.Double? bankFee, System.Double? creditCardFee, System.Boolean? canbeExported, System.String notes, System.Int32? taxNo, System.String taxCode, System.String currencyCode, System.String secondRef, System.String narrative, System.Int32 updatedBy, System.Int64? urnNumber, System.Int32? statusReason);

        /// <summary>
        /// Update header after updating supplier invoice line
        /// Call Proc [usp_updateHeader_SupplierInvoice]
        /// </summary>
        /// <param name="supplierInvoiceId"></param>
        /// <param name="secondRef"></param>
        /// <param name="narrative"></param>
        /// <param name="canBeExported"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public abstract bool UpdateHeader(System.Int32 supplierInvoiceId, System.String secondRef, System.String narrative, System.Boolean? canBeExported, System.Int32 updatedBy, System.Int32? statusReason);
        #endregion
    }
}
