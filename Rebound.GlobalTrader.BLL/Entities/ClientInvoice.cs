//Marker     Changed by      Date               Remarks
//[005]      Prakash           11/04/2014         Add Client Invoice
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
    public class ClientInvoice : BizObject
    {
        #region Properties

        protected static DAL.ClientInvoiceElement Settings
        {
            get { return Globals.Settings.ClientInvoices; }
        }

        /// <summary>
        /// SupplierInvoiceID
        /// </summary>
        public System.Int32 ClientInvoiceID { get; set; }
        /// <summary>
        /// ClientInvoiceNumber
        /// </summary>
        public System.String ClientInvoiceNumber { get; set; }
        /// <summary>
        /// CompanyNo
        /// </summary>
        public System.Int32 CompanyNo { get; set; }
        /// <summary>
        /// ClientID
        /// </summary>
        public System.Int32 ClientNo { get; set; }
      
        /// <summary>
        /// ClientInvoiceDate
        /// </summary>
        public System.DateTime ClientInvoiceDate { get; set; }
        /// <summary>
        /// SupplierCode
        /// </summary>
        public System.String SupplierCode { get; set; }
        /// <summary>
        /// SupplierName
        /// </summary>
        public System.String Clientname { get; set; }
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
        public System.String ClientBillto { get; set; }
        public System.String ClientShipTo { get; set; }

        public string Fax { get; set; }
        public string Telephone { get; set; }
        public string CustomerCode { get; set; }
        public string Vat { get; set; }
        public string Email { get; set; }

        public System.Int32? InternalPurchaseOrderNo { get; set; }
        public System.Int32? InternalPurchaseOrderNumber { get; set; }
        public System.Double? TaxRate { get; set; }
        public System.String ClientCompanyName { get; set; }
        public System.String ContactName { get; set; }
        public System.Int32? ContactNo { get; set; }
        public System.String SalesmanName { get; set; }
        public System.String CustomerPO { get; set; }
        public System.Int32? SalesOrderNumber { get; set; }
        public System.Int32? DivisionNo { get; set; }
        public System.Int32? SalesmanNo { get; set; }
        public System.String DivisionName { get; set; }
        public System.Int32? ClientInvoiceLineNo { get; set; }
        public System.Int32 InvoiceClientNo { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Call Proc [usp_select_ClientInvoice]
        /// Get the Client invoice by ClientinvoiceId
        /// </summary>
        /// <param name="ClientInvoiceId"></param>
        /// <returns></returns>
        public static ClientInvoice Get(System.Int32? clientInvoiceId)
        {
            Rebound.GlobalTrader.DAL.ClientInvoiceDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.ClientInvoice.Get(clientInvoiceId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                ClientInvoice obj = new ClientInvoice();
                obj.ClientInvoiceID = objDetails.ClientInvoiceID;
                obj.ClientInvoiceNumber = objDetails.ClientInvoiceNumber;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ClientNo = objDetails.ClientNo;
                obj.ClientInvoiceDate = objDetails.ClientInvoiceDate;
                obj.SupplierCode = objDetails.SupplierCode;
                obj.Clientname = objDetails.Clientname;
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
                obj.InternalPurchaseOrderNo = objDetails.InternalPurchaseOrderNo;
                obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
                obj.SalesmanName = objDetails.SalesmanName;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.SalesmanNo = objDetails.SalesmanNo;
                obj.DivisionName = objDetails.DivisionName;
                obj.InvoiceClientNo = objDetails.InvoiceClientNo;
              
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
        public static Int32 Insert(System.Int32? clientNo, System.Int32? PurchaseHubClientNo, 
           System.Double? amount, System.Double? goodsValue, System.Double? tax, System.Int32? taxNo, System.String taxCode, System.Double? deliveryCharge, System.Double? bankFee,
           System.Double? creditCardFee, System.String notes, System.String secondRef, System.String narrative, System.Boolean? canBeExported, System.Int32 updatedBy,System.Int32? currencyNo,System.String currencyCode)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.ClientInvoice.Insert(clientNo, PurchaseHubClientNo, amount, goodsValue,
                tax, taxNo, taxCode, deliveryCharge, bankFee, creditCardFee, notes, secondRef, narrative, canBeExported, updatedBy, currencyNo, currencyCode);
            return objReturn;
        }
        /// <summary>
        /// Call Proc [usp_datalistnugget_ClientInvoice]
        /// Get list of Client invoice on basis of following search criteria
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
        /// <param name="ClientInvoiceDateFrom"></param>
        /// <param name="ClientInvoiceDateTo"></param>
        /// <param name="cmSearch"></param>
        /// <param name="recentOnly"></param>
        /// <param name="cannotBeExported"></param>
        /// <returns></returns>
        public static List<ClientInvoice> DataListNugget(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? CINoLo, System.Int32? CINoHi, System.Int32? urnNoLo, System.Int32? urnNoHi, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? goodsInNoLo, System.Int32? goodsInNoHi, System.DateTime? clientInvoiceDateFrom, System.DateTime? clientInvoiceDateTo, System.String cmSearch, System.Boolean? recentOnly, System.Boolean? exportedOnly, System.Boolean? approveandUnExported, System.Boolean? cannotBeExported, System.Int32? selectedClientNo, System.Boolean? isPOHub)
        {
            cannotBeExported = (cannotBeExported.HasValue) ? (!cannotBeExported.Value) : cannotBeExported;
            List<ClientInvoiceDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ClientInvoice.DataListNugget(clientId, orderBy, sortDir, pageIndex, pageSize, CINoLo, CINoHi, urnNoLo, urnNoHi, purchaseOrderNoLo, purchaseOrderNoHi, goodsInNoLo, goodsInNoHi, clientInvoiceDateFrom, clientInvoiceDateTo, cmSearch, recentOnly, exportedOnly, approveandUnExported, cannotBeExported, selectedClientNo, isPOHub);
            if (lstDetails == null)
            {
                return new List<ClientInvoice>();
            }
            else
            {
                List<ClientInvoice> lst = new List<ClientInvoice>();
                foreach (ClientInvoiceDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.ClientInvoice obj = new Rebound.GlobalTrader.BLL.ClientInvoice();
                    obj.ClientInvoiceID = objDetails.ClientInvoiceID;
                    obj.ClientInvoiceNumber = objDetails.ClientInvoiceNumber;
                    obj.Clientname = objDetails.Clientname;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.GoodsInNumber = objDetails.GoodsInNumber;
                    obj.GoodsInNo = objDetails.GoodsInNo;
                    obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                    obj.ClientInvoiceDate = objDetails.ClientInvoiceDate;
                    obj.Part = objDetails.Part;
                    obj.InvoiceAmount = objDetails.InvoiceAmount;
                    obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.URNNumber = objDetails.URNNumber;
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
        /// Get detail for supplier invoice detail page
        /// Call Proc [usp_select_ClientInvoice_for_Page]
        /// </summary>
        /// <param name="clientInvoiceId"></param>
        /// <returns></returns>
        public static ClientInvoice GetForPage(System.Int32? clientInvoiceId, System.Boolean? isPOHub)
        {
            Rebound.GlobalTrader.DAL.ClientInvoiceDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.ClientInvoice.GetForPage(clientInvoiceId, isPOHub);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                ClientInvoice obj = new ClientInvoice();
                obj.ClientInvoiceID = objDetails.ClientInvoiceID;
                obj.ClientInvoiceNumber = objDetails.ClientInvoiceNumber;
                obj.Clientname = objDetails.Clientname;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ClientNo = objDetails.ClientNo;
                objDetails = null;
                return obj;
            }
        }

        /// <summary>
        /// Update Client invoice main info
        /// Call Proc [usp_update_ClientInvoice]
        /// </summary>
        /// <param name="clientInvoiceId"></param>
        /// <param name="ClientInvoiceDate"></param>
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
        public static bool Update(System.Int32 clientInvoiceId, System.String clientInvoiceNumber, System.DateTime? clientInvoiceDate, System.Int32? currencyNo, System.Double? amount, System.Double? goodsValue, System.Double? tax, System.Double? deliveryCharge, System.Double? bankFee, System.Double? creditCardFee, System.Boolean? canbeExported, System.String notes, System.Int32? taxNo, System.String taxCode, System.String currencyCode, System.String secondRef, System.String narrative, System.Int32 updatedBy, System.Int64? urnNumber)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.ClientInvoice.Update(clientInvoiceId, clientInvoiceNumber, clientInvoiceDate, currencyNo, amount, goodsValue, tax, deliveryCharge, bankFee, creditCardFee, canbeExported, notes, taxNo, taxCode, currencyCode, secondRef, narrative, updatedBy, urnNumber);
            
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
        //public static bool UpdateHeader(System.Int32 supplierInvoiceId, System.String secondRef, System.String narrative,System.Boolean? canBeExported, System.Int32 updatedBy)
        //{
        //    return Rebound.GlobalTrader.DAL.SiteProvider.SupplierInvoice.UpdateHeader(supplierInvoiceId, secondRef, narrative,canBeExported, updatedBy);

        //}

        /// <summary>
        /// GetForPrint
        /// Calls [usp_select_ClientInvoice_for_Print]
        /// </summary>
        public static ClientInvoice GetForPrint(System.Int32? clientInvoiceId)
        {
            Rebound.GlobalTrader.DAL.ClientInvoiceDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.ClientInvoice.GetForPrint(clientInvoiceId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                ClientInvoice obj = new ClientInvoice();
                obj.ClientInvoiceID = objDetails.ClientInvoiceID;
                obj.ClientNo = objDetails.ClientNo;
                obj.ClientInvoiceNumber = objDetails.ClientInvoiceNumber;
                obj.ClientInvoiceDate = objDetails.ClientInvoiceDate;
                obj.ClientShipTo = objDetails.ClientShipTo;
                obj.ClientBillto = objDetails.ClientBillto;
                obj.Fax = objDetails.Fax;
                obj.Telephone = objDetails.Telephone;
                obj.CustomerCode = objDetails.CustomerCode;
                obj.Vat = objDetails.Vat;
                obj.Email = objDetails.Email;
                obj.TaxRate = objDetails.TaxRate;
                obj.TaxName = objDetails.TaxName;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.Tax = objDetails.Tax;
                objDetails = null;
                return obj;
            }
        }



        /// <summary>
        /// ItemSearch
        /// Calls [usp_itemsearch_ClientInvoice]
        /// </summary>
        public static List<ClientInvoice> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? GoodsInNoLo, System.Int32? GoodsInNoHi, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.DateTime? invoiceDateFrom, System.DateTime? invoiceDateTo, System.Int32? ClientDebitNoLo, System.Int32? ClientDebitNoHi)
        {
            List<ClientInvoiceDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ClientInvoice.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, GoodsInNoLo,GoodsInNoHi, invoiceNoLo, invoiceNoHi, invoiceDateFrom, invoiceDateTo,ClientDebitNoLo,ClientDebitNoHi);
            if (lstDetails == null)
            {
                return new List<ClientInvoice>();
            }
            else
            {
                List<ClientInvoice> lst = new List<ClientInvoice>();
                foreach (ClientInvoiceDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.ClientInvoice obj = new Rebound.GlobalTrader.BLL.ClientInvoice();
                    obj.ClientInvoiceID = objDetails.ClientInvoiceID;
                    obj.ClientInvoiceNumber = objDetails.ClientInvoiceNumber;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.ClientCompanyName = objDetails.ClientCompanyName;
                    obj.ClientInvoiceDate = objDetails.ClientInvoiceDate;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.GoodsInNo = objDetails.GoodsInNo;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.Narrative = objDetails.Narrative;
                    obj.SecondRef = objDetails.SecondRef;
                    obj.ClientInvoiceLineNo = objDetails.ClientInvoiceLineNo;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// Call Proc [usp_select_ClientInvoiceByLineNo]
        /// Get the Client invoice by ClientinvoiceId and Line No
        /// </summary>
        /// <param name="clientInvoiceId"></param>
        /// <param name="clientInvoiceLineNo"></param>
        /// <returns></returns>
        public static ClientInvoice GetClientInvoiceByLineNo(System.Int32? clientInvoiceId, System.Int32? clientInvoiceLineNo)
        {
            Rebound.GlobalTrader.DAL.ClientInvoiceDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.ClientInvoice.GetClientInvoiceByLineNo(clientInvoiceId, clientInvoiceLineNo);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                ClientInvoice obj = new ClientInvoice();
                obj.ClientInvoiceID = objDetails.ClientInvoiceID;
                obj.ClientInvoiceNumber = objDetails.ClientInvoiceNumber;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ClientNo = objDetails.ClientNo;
                obj.ClientInvoiceDate = objDetails.ClientInvoiceDate;
                obj.SupplierCode = objDetails.SupplierCode;
                obj.Clientname = objDetails.Clientname;
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
                obj.InternalPurchaseOrderNo = objDetails.InternalPurchaseOrderNo;
                obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
                obj.SalesmanName = objDetails.SalesmanName;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.SalesmanNo = objDetails.SalesmanNo;
                obj.DivisionName = objDetails.DivisionName;
                objDetails = null;
                return obj;
            }
        }

        /// <summary>
        /// Update header after updating supplier invoice line
        /// Call Proc [usp_updateHeader_ClientInvoice]
        /// </summary>
        /// <param name="supplierInvoiceId"></param>
        /// <param name="secondRef"></param>
        /// <param name="narrative"></param>
        /// <param name="canBeExported"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public static bool UpdateHeader(System.Int32 supplierInvoiceId, System.String secondRef, System.String narrative, System.Boolean? canBeExported, System.Int32 updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.ClientInvoice.UpdateHeader(supplierInvoiceId, secondRef, narrative, canBeExported, updatedBy);

        }

        #endregion


       
    }
}
