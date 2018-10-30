//Marker     Changed by      Date               Remarks
//[005]      Prakash           11/04/2014         Add Client Invoice
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebound.GlobalTrader.DAL
{
  public abstract class ClientInvoiceProvider : DataAccess
    {
        static private ClientInvoiceProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ClientInvoiceProvider Instance {
			get {
                if (_instance == null) _instance = (ClientInvoiceProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.ClientInvoices.ProviderType));
				return _instance;
			}
		}
        public ClientInvoiceProvider()
        {
			this.ConnectionString = Globals.Settings.SupplierInvoices.ConnectionString;
		}

        #region Method Registrations

        /// <summary>
        /// Call Proc [usp_select_ClientInvoice]
        /// Get the Client invoice by ClientinvoiceId
        /// </summary>
        /// <param name="ClientInvoiceId"></param>
        /// <returns></returns>
        public abstract ClientInvoiceDetails Get(System.Int32? ClientInvoiceId);
        /// <summary>
        /// Call Proc [usp_insert_ClientInvoice]
        /// Insert Client invoice header
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="companyNo"></param>
        /// <param name="ClientInvoiceNumber"></param>
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
        public abstract Int32 Insert(System.Int32? clientNo, System.Int32? PurchaseHubClientNo, 
           System.Double? amount, System.Double? goodsValue, System.Double? tax, System.Int32? taxNo, System.String taxCode, System.Double? deliveryCharge, System.Double? bankFee,
           System.Double? creditCardFee, System.String notes, System.String secondRef, System.String narrative, System.Boolean? canBeExported, System.Int32 updatedBy, System.Int32? currencyNo, System.String currencyCode);

      /// <summary>
      /// Call Proc [usp_datalistnugget_ClientInvoice]
      /// Get list of client invoice on basis of following search criteria
      /// </summary>
      /// <param name="clientId"></param>
      /// <param name="orderBy"></param>
      /// <param name="sortDir"></param>
      /// <param name="pageIndex"></param>
      /// <param name="pageSize"></param>
      /// <param name="ClientInvoiceNumber"></param>
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
        public abstract List<ClientInvoiceDetails> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? CINoLo, System.Int32? CINoHi, System.Int32? urnNoLo, System.Int32? urnNoHi, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? goodsInNoLo, System.Int32? goodsInNoHi, System.DateTime? supplierInvoiceDateFrom, System.DateTime? supplierInvoiceDateTo, System.String cmSearch, System.Boolean? recentOnly, System.Boolean? exportedOnly, System.Boolean? approveandUnExported, System.Boolean? cannotBeExported, System.Int32? selectedClientNo, System.Boolean? isPOHub);

        /// <summary>
        /// Get detail for supplier invoice detail page
        /// Call Proc [usp_select_ClientInvoice_for_Page]
        /// </summary>
        /// <param name="ClientInvoiceId"></param>
        /// <returns></returns>
        public abstract ClientInvoiceDetails GetForPage(System.Int32? ClientInvoiceId, System.Boolean? isPOHub);

        /// <summary>
        /// Update supplier invoice main info
        /// Call Proc [usp_update_ClientInvoice]
        /// </summary>
        /// <param name="clientInvoiceId"></param>
        /// <param name="clientInvoiceId"></param>
        /// <param name="clientInvoiceDate"></param>
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
        public abstract bool Update(System.Int32 clientInvoiceId, System.String clientInvoiceNumber, System.DateTime? clientInvoiceDate, System.Int32? currencyNo, System.Double? amount, System.Double? goodsValue, System.Double? tax, System.Double? deliveryCharge, System.Double? bankFee, System.Double? creditCardFee, System.Boolean? canbeExported, System.String notes, System.Int32? taxNo, System.String taxCode, System.String currencyCode, System.String secondRef, System.String narrative, System.Int32 updatedBy, System.Int64? urnNumber);

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
        public abstract bool UpdateHeader(System.Int32 supplierInvoiceId, System.String secondRef, System.String narrative, System.Boolean? canBeExported, System.Int32 updatedBy);

        /// <summary>
        /// GetForPrint
        /// Calls [usp_select_ClientInvoice_for_Print]
        /// </summary>
        public abstract ClientInvoiceDetails GetForPrint(System.Int32? invoiceId);

        /// <summary>
        /// ItemSearch
        /// Calls [usp_itemsearch_ClientInvoice]
        /// </summary>
        public abstract List<ClientInvoiceDetails> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? GoodsInNoLo, System.Int32? GoodsInNoHi, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.DateTime? invoiceDateFrom, System.DateTime? invoiceDateTo, System.Int32? ClientDebitNoLo, System.Int32? ClientDebitNoHi);

        /// <summary>
        /// Call Proc [usp_select_ClientInvoiceByLineNo]
        /// Get the Client invoice by ClientinvoiceId
        /// </summary>
        /// <param name="ClientInvoiceId"></param>
        /// <returns></returns>
        public abstract ClientInvoiceDetails GetClientInvoiceByLineNo(System.Int32? clientInvoiceId, System.Int32? clientInvoiceLineNo);


        #endregion
    }
}
