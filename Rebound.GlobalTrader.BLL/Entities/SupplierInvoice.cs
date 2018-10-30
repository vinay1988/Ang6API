//Marker     Changed by      Date               Remarks
//[001]      Vinay           11/06/2013         CR:- Supplier Invoice
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rebound.GlobalTrader.DAL;
using Rebound.GlobalTrader.BLL;

namespace Rebound.GlobalTrader.BLL
{
    /// <summary>
    /// Created Date:- 29-05-2013
    /// </summary>
    public class SupplierInvoice : BizObject
    {
        #region Properties

        protected static DAL.SupplierInvoiceElement Settings
        {
            get { return Globals.Settings.SupplierInvoices; }
        }

        /// <summary>
        /// SupplierInvoiceID
        /// </summary>
        public System.Int32 SupplierInvoiceID { get; set; }
        /// <summary>
        /// SupplierInvoiceNumber
        /// </summary>
        public System.String SupplierInvoiceNumber { get; set; }
        /// <summary>
        /// CompanyNo
        /// </summary>
        public System.Int32 CompanyNo { get; set; }
        /// <summary>
        /// ClientID
        /// </summary>
        public System.Int32 ClientNo { get; set; }
      
        /// <summary>
        /// SupplierInvoiceDate
        /// </summary>
        public System.DateTime SupplierInvoiceDate { get; set; }
        /// <summary>
        /// SupplierCode
        /// </summary>
        public System.String SupplierCode { get; set; }
        /// <summary>
        /// SupplierName
        /// </summary>
        public System.String SupplierName { get; set; }
        /// <summary>
        /// CurrencyNo
        /// </summary>
        public System.Int32? CurrencyNo { get; set; }
        /// <summary>
        /// CurrencyCode
        /// </summary>
        public System.String CurrencyCode { get; set; }
        /// <summary>
        /// InvoiceAmount
        /// </summary>
        public System.Double? InvoiceAmount { get; set; }
        /// <summary>
        /// GoodsValue
        /// </summary>
        public System.Double? GoodsValue { get; set; }
        /// <summary>
        /// Tax
        /// </summary>
        public System.Double? Tax { get; set; }
        /// <summary>
        /// DeliveryCharge
        /// </summary>
        public System.Double? DeliveryCharge { get; set; }
        /// <summary>
        /// BankFee
        /// </summary>
        public System.Double? BankFee { get; set; }
        /// <summary>
        /// CreditCardFee
        /// </summary>
        public System.Double? CreditCardFee { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public System.String Notes { get; set; }
        /// <summary>
        /// SecondRef
        /// </summary>
        public System.String SecondRef { get; set; }
        /// <summary>
        /// Narrative
        /// </summary>
        public System.String Narrative { get; set; }
        /// <summary>
        /// CanbeExported
        /// </summary>
        public System.Boolean? CanbeExported { get; set; }
        /// <summary>
        /// Exported
        /// </summary>
        public System.Boolean? Exported { get; set; }
        /// <summary>
        /// URNNumber
        /// </summary>
        public System.Int64? URNNumber { get; set; }
        /// <summary>
        /// GoodsInNumber
        /// </summary>
        public System.Int32 GoodsInNumber { get; set; }
        /// <summary>
        /// GoodsInNo
        /// </summary>
        public System.Int32? GoodsInNo { get; set; }
        /// <summary>
        /// PurchaseOrderNumber
        /// </summary>
        public System.Int32? PurchaseOrderNumber { get; set; }
        /// <summary>
        /// PurchaseOrderNo
        /// </summary>
        public System.Int32? PurchaseOrderNo { get; set; }
        /// <summary>
        /// Part
        /// </summary>
        public System.String Part { get; set; }
        /// <summary>
        /// RowNum
        /// </summary>
        public System.Int64? RowNum { get; set; }
        /// <summary>
        /// RowCnt
        /// </summary>
        public System.Int32? RowCnt { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime DLUP { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// TaxNo
        /// </summary>
        public System.Int32? TaxNo { get; set; }
        /// <summary>
        /// TaxName
        /// </summary>
        public System.String TaxName { get; set; }
        /// <summary>
        /// TaxCode
        /// </summary>
        public System.String TaxCode { get; set; }
        /// <summary>
        /// InternalPurchaseOrderId
        /// </summary>
        public System.Int32? InternalPurchaseOrderId { get; set; }
        /// <summary>
        /// StatusReasonId
        /// </summary>
        public System.Int32? StatusReasonId { get; set; }
        /// <summary>
        /// StatusReason
        /// </summary>
        public System.String StatusReason { get; set; }
      
      
    

        #endregion

        #region Methods

        /// <summary>
        /// Call Proc [usp_select_SupplierInvoice]
        /// Get the supplier invoice by supplierinvoiceId
        /// </summary>
        /// <param name="supplierInvoiceId"></param>
        /// <returns></returns>
        public static SupplierInvoice Get(System.Int32? supplierInvoiceId)
        {
            Rebound.GlobalTrader.DAL.SupplierInvoiceDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierInvoice.Get(supplierInvoiceId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SupplierInvoice obj = new SupplierInvoice();
                obj.SupplierInvoiceID = objDetails.SupplierInvoiceID;
                obj.SupplierInvoiceNumber = objDetails.SupplierInvoiceNumber;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ClientNo = objDetails.ClientNo;
                obj.SupplierInvoiceDate = objDetails.SupplierInvoiceDate;
                obj.SupplierCode = objDetails.SupplierCode;
                obj.SupplierName = objDetails.SupplierName;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.InvoiceAmount = objDetails.InvoiceAmount;
                obj.GoodsValue = objDetails.GoodsValue;
                obj.Tax = objDetails.Tax;
                obj.DeliveryCharge = objDetails.DeliveryCharge;
                obj.CreditCardFee = objDetails.CreditCardFee;
                obj.BankFee = objDetails.BankFee;
                obj.Exported = objDetails.Exported;
                obj.Notes = objDetails.Notes;
                obj.SecondRef = objDetails.SecondRef;
                obj.Narrative = objDetails.Narrative;
                obj.CanbeExported = objDetails.CanbeExported;
                obj.URNNumber = objDetails.URNNumber;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.TaxNo = objDetails.TaxNo;
                obj.TaxName = objDetails.TaxName;
                obj.TaxCode = objDetails.TaxCode;
                obj.StatusReasonId = objDetails.StatusReasonId;
                obj.StatusReason = objDetails.StatusReason;
                objDetails = null;
                return obj;
            }
        }
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
        public static Int32 Insert(System.Int32? clientNo, System.Int32 companyNo, System.String supplierInvoiceNumber, System.DateTime? supplierInvoiceDate, System.String supplierCode, System.String supplierName, System.Int32? currencyNo, System.Double? amount, System.Double? goodsValue, System.Double? tax, System.Double? deliveryCharge, System.Double? bankFee, System.Double? creditCardFee, System.String notes, System.String secondRef, System.String narrative, System.Boolean? canBeExported, System.Int32? taxNo, System.String taxCode,System.String currencyCode, System.Int32 updatedBy,System.Int32? statusReason)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SupplierInvoice.Insert(clientNo, companyNo, supplierInvoiceNumber, supplierInvoiceDate, supplierCode, supplierName, currencyNo, amount, goodsValue, tax, deliveryCharge, bankFee, creditCardFee, notes, secondRef, narrative, canBeExported, taxNo, taxCode, currencyCode, updatedBy, statusReason);
            return objReturn;
        }
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
        public static List<SupplierInvoice> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String supplierInvoiceNumber, System.Int32? urnNoLo, System.Int32? urnNoHi, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? goodsInNoLo, System.Int32? goodsInNoHi, System.DateTime? supplierInvoiceDateFrom, System.DateTime? supplierInvoiceDateTo, System.String cmSearch, System.Boolean? recentOnly, System.Boolean? exportedOnly, System.Boolean? approveandUnExported, System.Boolean? cannotBeExported, System.Int32? internalPurchaseOrderNoLo, System.Int32? internalPurchaseOrderNoHi,System.Int32? statusReason)
        {
            cannotBeExported = (cannotBeExported.HasValue) ? (!cannotBeExported.Value) : cannotBeExported;
            List<SupplierInvoiceDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierInvoice.DataListNugget(clientId, orderBy, sortDir, pageIndex, pageSize, supplierInvoiceNumber, urnNoLo, urnNoHi, purchaseOrderNoLo, purchaseOrderNoHi, goodsInNoLo, goodsInNoHi, supplierInvoiceDateFrom, supplierInvoiceDateTo, cmSearch, recentOnly, exportedOnly, approveandUnExported, cannotBeExported, internalPurchaseOrderNoLo, internalPurchaseOrderNoHi, statusReason);
            if (lstDetails == null)
            {
                return new List<SupplierInvoice>();
            }
            else
            {
                List<SupplierInvoice> lst = new List<SupplierInvoice>();
                foreach (SupplierInvoiceDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SupplierInvoice obj = new Rebound.GlobalTrader.BLL.SupplierInvoice();
                    obj.SupplierInvoiceID = objDetails.SupplierInvoiceID;
                    obj.SupplierInvoiceNumber = objDetails.SupplierInvoiceNumber;
                    obj.SupplierName = objDetails.SupplierName;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.GoodsInNumber = objDetails.GoodsInNumber;
                    obj.GoodsInNo = objDetails.GoodsInNo;
                    obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                    obj.SupplierInvoiceDate = objDetails.SupplierInvoiceDate;
                    obj.Part = objDetails.Part;
                    obj.InvoiceAmount = objDetails.InvoiceAmount;
                    obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.URNNumber = objDetails.URNNumber;
                    obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Get detail for supplier invoice detail page
        /// Call Proc [usp_select_SupplierInvoice_for_Page]
        /// </summary>
        /// <param name="supplierInvoiceId"></param>
        /// <returns></returns>
        public static SupplierInvoice GetForPage(System.Int32? supplierInvoiceId)
        {
            Rebound.GlobalTrader.DAL.SupplierInvoiceDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierInvoice.GetForPage(supplierInvoiceId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SupplierInvoice obj = new SupplierInvoice();
                obj.SupplierInvoiceID = objDetails.SupplierInvoiceID;
                obj.SupplierInvoiceNumber = objDetails.SupplierInvoiceNumber;
                obj.SupplierName = objDetails.SupplierName;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ClientNo = objDetails.ClientNo;
                objDetails = null;
                return obj;
            }
        }

        /// <summary>
        /// Update supplier invoice main info
        /// Call Proc [usp_update_SupplierInvoice]
        /// </summary>
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
        public static bool Update(System.Int32 supplierInvoiceId,System.String supplierInvoiceNumber, System.DateTime? supplierInvoiceDate,  System.Int32? currencyNo, System.Double? amount, System.Double? goodsValue, System.Double? tax, System.Double? deliveryCharge, System.Double? bankFee, System.Double? creditCardFee, System.Boolean? canbeExported, System.String notes,System.Int32? taxNo,System.String taxCode,System.String currencyCode,System.String secondRef,System.String narrative, System.Int32 updatedBy,System.Int64? urnNumber,System.Int32? statusReason)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SupplierInvoice.Update(supplierInvoiceId, supplierInvoiceNumber, supplierInvoiceDate, currencyNo, amount, goodsValue, tax, deliveryCharge, bankFee, creditCardFee, canbeExported, notes, taxNo, taxCode, currencyCode, secondRef, narrative, updatedBy, urnNumber, statusReason);
            
        }

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
        public static bool UpdateHeader(System.Int32 supplierInvoiceId, System.String secondRef, System.String narrative,System.Boolean? canBeExported, System.Int32 updatedBy,System.Int32? statusReason)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SupplierInvoice.UpdateHeader(supplierInvoiceId, secondRef, narrative, canBeExported, updatedBy, statusReason);

        }
        #endregion


       
    }
}
