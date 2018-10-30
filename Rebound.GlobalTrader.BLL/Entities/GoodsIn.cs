/*
Marker     Changed by      Date          Remarks
[001]      Vinay           07/05/2012    This need to upload pdf document for goodsIn section
[002]      Vinay           18/09/2012    Ref:## - Display Purchase Country
[003]      Vinay           20/06/2013    CR:- - Supplier Invoice
[004]      Vinay           08/07/2013    Ref:## -32 Nice Label Prining
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
using System.Collections.Generic;
using Rebound.GlobalTrader.DAL;
using Rebound.GlobalTrader.BLL;

namespace Rebound.GlobalTrader.BLL
{
    public partial class GoodsIn : BizObject
    {

        #region Properties

        protected static DAL.GoodsInElement Settings
        {
            get { return Globals.Settings.GoodsIns; }
        }

        /// <summary>
        /// GoodsInId
        /// </summary>
        public System.Int32 GoodsInId { get; set; }
        /// <summary>
        /// GoodsInNumber
        /// </summary>
        public System.Int32 GoodsInNumber { get; set; }
        /// <summary>
        /// ClientNo
        /// </summary>
        public System.Int32 ClientNo { get; set; }
        /// <summary>
        /// ShipViaNo
        /// </summary>
        public System.Int32? ShipViaNo { get; set; }
        /// <summary>
        /// AirWayBill
        /// </summary>
        public System.String AirWayBill { get; set; }
        /// <summary>
        /// Reference
        /// </summary>
        public System.String Reference { get; set; }
        /// <summary>
        /// CompanyNo
        /// </summary>
        public System.Int32 CompanyNo { get; set; }
        /// <summary>
        /// ReceivingNotes
        /// </summary>
        public System.String ReceivingNotes { get; set; }
        /// <summary>
        /// DateReceived
        /// </summary>
        public System.DateTime DateReceived { get; set; }
        /// <summary>
        /// PurchaseOrderNo
        /// </summary>
        public System.Int32? PurchaseOrderNo { get; set; }
        /// <summary>
        /// CurrencyNo
        /// </summary>
        public System.Int32? CurrencyNo { get; set; }
        /// <summary>
        /// ReceivedBy
        /// </summary>
        public System.Int32 ReceivedBy { get; set; }
        /// <summary>
        /// WarehouseNo
        /// </summary>
        public System.Int32 WarehouseNo { get; set; }
        /// <summary>
        /// CustomerRMANo
        /// </summary>
        public System.Int32? CustomerRMANo { get; set; }
        /// <summary>
        /// SupplierInvoice
        /// </summary>
        public System.String SupplierInvoice { get; set; }
        /// <summary>
        /// InvoiceDate
        /// </summary>
        public System.DateTime? InvoiceDate { get; set; }
        /// <summary>
        /// InvoiceAmount
        /// </summary>
        public System.Double? InvoiceAmount { get; set; }
        /// <summary>
        /// BankFee
        /// </summary>
        public System.Double? BankFee { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime DLUP { get; set; }
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
        /// CreditCardFee
        /// </summary>
        public System.Double? CreditCardFee { get; set; }
        /// <summary>
        /// CanBeExported
        /// </summary>
        public System.Boolean CanBeExported { get; set; }
        /// <summary>
        /// Exported
        /// </summary>
        public System.Boolean Exported { get; set; }
        /// <summary>
        /// CompanyName
        /// </summary>
        public System.String CompanyName { get; set; }
        /// <summary>
        /// PurchaseOrderNumber
        /// </summary>
        public System.Int32? PurchaseOrderNumber { get; set; }
        /// <summary>
        /// CustomerRMANumber
        /// </summary>
        public System.Int32? CustomerRMANumber { get; set; }
        /// <summary>
        /// ReceiverName
        /// </summary>
        public System.String ReceiverName { get; set; }
        /// <summary>
        /// RowNum
        /// </summary>
        public System.Int64? RowNum { get; set; }
        /// <summary>
        /// RowCnt
        /// </summary>
        public System.Int32? RowCnt { get; set; }
        /// <summary>
        /// WarehouseName
        /// </summary>
        public System.String WarehouseName { get; set; }
        /// <summary>
        /// GoodsInValue
        /// </summary>
        public System.Double? GoodsInValue { get; set; }
        /// <summary>
        /// DivisionNo
        /// </summary>
        public System.Int32? DivisionNo { get; set; }
        /// <summary>
        /// TeamNo
        /// </summary>
        public System.Int32? TeamNo { get; set; }
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
        /// StatusNo
        /// </summary>
        public System.Int32? StatusNo { get; set; }
        /// <summary>
        /// SupplierRMANo
        /// </summary>
        public System.Int32? SupplierRMANo { get; set; }
        /// <summary>
        /// SupplierRMANumber
        /// </summary>
        public System.Int32? SupplierRMANumber { get; set; }
        /// <summary>
        /// DivisionName
        /// </summary>
        public System.String DivisionName { get; set; }
        /// <summary>
        /// Buyer
        /// </summary>
        public System.Int32 Buyer { get; set; }
        /// <summary>
        /// BuyerName
        /// </summary>
        public System.String BuyerName { get; set; }
        /// <summary>
        /// ReceivedByName
        /// </summary>
        public System.String ReceivedByName { get; set; }
        /// <summary>
        /// ContactNo
        /// </summary>
        public System.Int32 ContactNo { get; set; }
        /// <summary>
        /// ContactName
        /// </summary>
        public System.String ContactName { get; set; }
        /// <summary>
        /// TotalShipInCost
        /// </summary>
        public System.Double? TotalShipInCost { get; set; }
        /// <summary>
        /// CompanyNameForSearch
        /// </summary>
        public System.String CompanyNameForSearch { get; set; }
        /// <summary>
        /// SupplierTelephone
        /// </summary>
        public System.String SupplierTelephone { get; set; }
        /// <summary>
        /// SupplierFax
        /// </summary>
        public System.String SupplierFax { get; set; }
        // [001] code start
        /// <summary>
        /// IsPDFAvailable
        /// </summary>
        public System.Boolean? IsPDFAvailable { get; set; }
        // [001] code start

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
        /// ClientName
        /// </summary>
        public System.String ClientName { get; set; }
        public System.Int32? ClientCurrencyNo { get; set; }
        public System.String ClientCurrencyCode { get; set; }
        /// </summary>
        public System.String ClientBaseCurrencyCode { get; set; }
        public int? ClientBaseCurrencyID { get; set; }

        public int? SerialNo { get; set; }
        public int? SerialNoId { get; set; }
        public System.String SubGroup { get; set; }

        /// <summary>
        /// GoodsInNumberDetail
        /// </summary>
        //[005] start
        public System.String GoodsInNumberDetail { get; set; }
        //[005] end
        #endregion

        #region Methods

        /// <summary>
        /// CountForClient
        /// Calls [usp_count_GoodsIn_for_Client]
        /// </summary>
        public static Int32 CountForClient(System.Int32? clientId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.GoodsIn.CountForClient(clientId);
        }		/// <summary>
        /// Delete
        /// Calls [usp_delete_GoodsIn]
        /// </summary>
        public static bool Delete(System.Int32? goodsInId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.GoodsIn.Delete(goodsInId);
        }
        //[002] code start
        /// <summary>
        /// Insert
        /// Calls [usp_insert_GoodsIn]
        /// </summary>
        public static Int32 Insert(System.Int32? clientNo, System.Int32? shipViaNo, System.String airWayBill, System.String reference, System.Int32? companyNo, System.String receivingNotes, System.DateTime? dateReceived, System.Int32? receivedBy, System.Int32? purchaseOrderNo, System.Int32? customerRmaNo, System.Int32? warehouseNo, System.Int32? currencyNo, System.Int32? updatedBy, System.Int32? purchaseCountryNo)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.GoodsIn.Insert(clientNo, shipViaNo, airWayBill, reference, companyNo, receivingNotes, dateReceived, receivedBy, purchaseOrderNo, customerRmaNo, warehouseNo, currencyNo, updatedBy, purchaseCountryNo);
            return objReturn;
        }
        /// <summary>
        /// Insert (without parameters)
        /// Calls [usp_insert_GoodsIn]
        /// </summary>
        public Int32 Insert()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.GoodsIn.Insert(ClientNo, ShipViaNo, AirWayBill, Reference, CompanyNo, ReceivingNotes, DateReceived, ReceivedBy, PurchaseOrderNo, CustomerRMANo, WarehouseNo, CurrencyNo, UpdatedBy, PurchaseCountryNo);
        }
        //[002] code end
        /// <summary>
        /// ItemSearch
        /// Calls [usp_itemsearch_GoodsIn]
        /// </summary>
        public static List<GoodsIn> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String airWayBillSearch, System.String cmSearch, System.Int32? receivedBySearch, System.Boolean? includeInvoiced, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.Int32? goodsInNoLo, System.Int32? goodsInNoHi, System.DateTime? dateReceivedFrom, System.DateTime? dateReceivedTo, System.Boolean IsGlobal)
        {
            List<GoodsInDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsIn.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, airWayBillSearch, cmSearch, receivedBySearch, includeInvoiced, purchaseOrderNoLo, purchaseOrderNoHi, customerRmaNoLo, customerRmaNoHi, goodsInNoLo, goodsInNoHi, dateReceivedFrom, dateReceivedTo,IsGlobal);
            if (lstDetails == null)
            {
                return new List<GoodsIn>();
            }
            else
            {
                List<GoodsIn> lst = new List<GoodsIn>();
                foreach (GoodsInDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.GoodsIn obj = new Rebound.GlobalTrader.BLL.GoodsIn();
                    obj.GoodsInId = objDetails.GoodsInId;
                    obj.GoodsInNumber = objDetails.GoodsInNumber;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.DateReceived = objDetails.DateReceived;
                    obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                    obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                    obj.AirWayBill = objDetails.AirWayBill;
                    obj.ReceiverName = objDetails.ReceiverName;
                    obj.Reference = objDetails.Reference;
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
        /// Calls [usp_select_GoodsIn]
        /// </summary>
        public static GoodsIn Get(System.Int32? goodsInId, bool? isHub)
        {
            Rebound.GlobalTrader.DAL.GoodsInDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsIn.Get(goodsInId, isHub);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                GoodsIn obj = new GoodsIn();
                obj.GoodsInId = objDetails.GoodsInId;
                obj.GoodsInNumber = objDetails.GoodsInNumber;
                obj.ClientNo = objDetails.ClientNo;
                obj.ShipViaNo = objDetails.ShipViaNo;
                obj.AirWayBill = objDetails.AirWayBill;
                obj.Reference = objDetails.Reference;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ReceivingNotes = objDetails.ReceivingNotes;
                obj.DateReceived = objDetails.DateReceived;
                obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.ReceivedBy = objDetails.ReceivedBy;
                obj.WarehouseNo = objDetails.WarehouseNo;
                obj.CustomerRMANo = objDetails.CustomerRMANo;
                obj.SupplierInvoice = objDetails.SupplierInvoice;
                obj.InvoiceDate = objDetails.InvoiceDate;
                obj.InvoiceAmount = objDetails.InvoiceAmount;
                obj.GoodsValue = objDetails.GoodsValue;
                obj.Tax = objDetails.Tax;
                obj.BankFee = objDetails.BankFee;
                obj.DeliveryCharge = objDetails.DeliveryCharge;
                obj.CreditCardFee = objDetails.CreditCardFee;
                obj.CanBeExported = objDetails.CanBeExported;
                obj.Exported = objDetails.Exported;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.CompanyName = objDetails.InternalPurchaseOrderId > 0 && isHub == false ? objDetails.IPOSupplierName : objDetails.CompanyName;
                obj.ReceiverName = objDetails.ReceiverName;
                //---------------------------
                obj.BuyerName = objDetails.BuyerName;
                //---------------------------------
                obj.WarehouseName = objDetails.WarehouseName;
                obj.GoodsInValue = objDetails.GoodsInValue;
                obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.TeamNo = objDetails.TeamNo;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.StatusNo = objDetails.StatusNo;
                obj.SupplierRMANo = objDetails.SupplierRMANo;
                obj.SupplierRMANumber = objDetails.SupplierRMANumber;
                obj.DivisionName = objDetails.DivisionName;
                //[002] code start
                obj.PurchaseCountryNo = objDetails.PurchaseCountryNo;
                obj.PurchaseCountryName = objDetails.PurchaseCountryName;
                //[002] code end
                obj.SupplierType = objDetails.SupplierType;
                //[003] code start
                obj.SupplierInvoiceNos = objDetails.SupplierInvoiceNos;
                obj.SupplierInvoiceNumbers = objDetails.SupplierInvoiceNumbers;

                obj.IPOSupplier = objDetails.IPOSupplier;
                obj.IPOSupplierName = objDetails.IPOSupplierName;

                obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
                obj.InternalPurchaseOrderNo = objDetails.InternalPurchaseOrderNo;
                obj.GoodsInValueForClient = objDetails.GoodsInValueForClient;
                obj.POClientNo = objDetails.POClientNo;
                obj.ClientCurrencyCode = objDetails.ClientCurrencyCode;
                obj.ClientCurrencyNo = objDetails.ClientCurrencyNo;

                //[003] code end
                
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetAsReceivedPO
        /// Calls [usp_select_GoodsIn_as_ReceivedPO]
        /// </summary>
        public static GoodsIn GetAsReceivedPO(System.Int32? purchaseOrderNo)
        {
            Rebound.GlobalTrader.DAL.GoodsInDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsIn.GetAsReceivedPO(purchaseOrderNo);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                GoodsIn obj = new GoodsIn();
                obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                obj.Buyer = objDetails.Buyer;
                obj.BuyerName = objDetails.BuyerName;
                obj.WarehouseNo = objDetails.WarehouseNo;
                obj.WarehouseName = objDetails.WarehouseName;
                obj.ReceivedBy = objDetails.ReceivedBy;
                obj.ReceivedByName = objDetails.ReceivedByName;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.CompanyName = objDetails.CompanyName;
                obj.ContactNo = objDetails.ContactNo;
                obj.ContactName = objDetails.ContactName;
                obj.AirWayBill = objDetails.AirWayBill;
                obj.Reference = objDetails.Reference;
                obj.TotalShipInCost = objDetails.TotalShipInCost;
                obj.ReceivingNotes = objDetails.ReceivingNotes;
                obj.SupplierInvoice = objDetails.SupplierInvoice;
                obj.InvoiceAmount = objDetails.InvoiceAmount;
                obj.BankFee = objDetails.BankFee;
                obj.InvoiceDate = objDetails.InvoiceDate;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.DLUP = objDetails.DLUP;
                obj.UpdatedBy = objDetails.UpdatedBy;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetByNumber
        /// Calls [usp_select_GoodsIn_by_Number]
        /// </summary>
        public static GoodsIn GetByNumber(System.Int32? goodsInNumber, System.Int32? clientNo)
        {
            Rebound.GlobalTrader.DAL.GoodsInDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsIn.GetByNumber(goodsInNumber, clientNo);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                GoodsIn obj = new GoodsIn();
                obj.GoodsInId = objDetails.GoodsInId;
                obj.GoodsInNumber = objDetails.GoodsInNumber;
                obj.ClientNo = objDetails.ClientNo;
                obj.ShipViaNo = objDetails.ShipViaNo;
                obj.AirWayBill = objDetails.AirWayBill;
                obj.Reference = objDetails.Reference;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ReceivingNotes = objDetails.ReceivingNotes;
                obj.DateReceived = objDetails.DateReceived;
                obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.ReceivedBy = objDetails.ReceivedBy;
                obj.WarehouseNo = objDetails.WarehouseNo;
                obj.CustomerRMANo = objDetails.CustomerRMANo;
                obj.SupplierInvoice = objDetails.SupplierInvoice;
                obj.InvoiceDate = objDetails.InvoiceDate;
                obj.InvoiceAmount = objDetails.InvoiceAmount;
                obj.GoodsValue = objDetails.GoodsValue;
                obj.Tax = objDetails.Tax;
                obj.BankFee = objDetails.BankFee;
                obj.DeliveryCharge = objDetails.DeliveryCharge;
                obj.CreditCardFee = objDetails.CreditCardFee;
                obj.CanBeExported = objDetails.CanBeExported;
                obj.Exported = objDetails.Exported;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.CompanyName = objDetails.CompanyName;
                obj.ReceiverName = objDetails.ReceiverName;
                obj.WarehouseName = objDetails.WarehouseName;
                obj.GoodsInValue = objDetails.GoodsInValue;
                obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.TeamNo = objDetails.TeamNo;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.StatusNo = objDetails.StatusNo;
                obj.SupplierRMANo = objDetails.SupplierRMANo;
                obj.SupplierRMANumber = objDetails.SupplierRMANumber;
                obj.DivisionName = objDetails.DivisionName;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetForPage
        /// Calls [usp_select_GoodsIn_for_Page]
        /// </summary>
        public static GoodsIn GetForPage(System.Int32? goodsInId)
        {
            Rebound.GlobalTrader.DAL.GoodsInDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsIn.GetForPage(goodsInId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                GoodsIn obj = new GoodsIn();
                obj.GoodsInId = objDetails.GoodsInId;
                obj.GoodsInNumber = objDetails.GoodsInNumber;
                obj.ClientNo = objDetails.ClientNo;
                obj.CompanyName = objDetails.CompanyName;
                obj.CompanyNameForSearch = objDetails.CompanyNameForSearch;
                obj.StatusNo = objDetails.StatusNo;
                // [001] code start
                obj.IsPDFAvailable = objDetails.IsPDFAvailable;
                // [001] code end

                //[003] code start
                obj.CompanyNo = objDetails.CompanyNo;
                obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                obj.TaxNo = objDetails.TaxNo;
                obj.GlobalCurrencyNo = objDetails.GlobalCurrencyNo;
                obj.CurrencyCode = objDetails.CurrencyCode;
                //[003] code end
                obj.IPOSupplier = objDetails.IPOSupplier;
                obj.IPOSupplierName = objDetails.IPOSupplierName;

                obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
                obj.InternalPurchaseOrderNo = objDetails.InternalPurchaseOrderNo;

                obj.POClientNo = objDetails.POClientNo;
                obj.ClientName = objDetails.ClientName;
                obj.ClientBaseCurrencyCode = objDetails.ClientBaseCurrencyCode;
                obj.ClientBaseCurrencyID = objDetails.ClientBaseCurrencyID;
               
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetForPrint
        /// Calls [usp_select_GoodsIn_for_Print]
        /// </summary>
        public static GoodsIn GetForPrint(System.Int32? goodsInId)
        {
            Rebound.GlobalTrader.DAL.GoodsInDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsIn.GetForPrint(goodsInId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                GoodsIn obj = new GoodsIn();
                obj.GoodsInId = objDetails.GoodsInId;
                obj.GoodsInNumber = objDetails.GoodsInNumber;
                obj.ClientNo = objDetails.ClientNo;
                obj.ShipViaNo = objDetails.ShipViaNo;
                obj.AirWayBill = objDetails.AirWayBill;
                obj.Reference = objDetails.Reference;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ReceivingNotes = objDetails.ReceivingNotes;
                obj.DateReceived = objDetails.DateReceived;
                obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.ReceivedBy = objDetails.ReceivedBy;
                obj.WarehouseNo = objDetails.WarehouseNo;
                obj.CustomerRMANo = objDetails.CustomerRMANo;
                obj.SupplierInvoice = objDetails.SupplierInvoice;
                obj.InvoiceDate = objDetails.InvoiceDate;
                obj.InvoiceAmount = objDetails.InvoiceAmount;
                obj.GoodsValue = objDetails.GoodsValue;
                obj.Tax = objDetails.Tax;
                obj.BankFee = objDetails.BankFee;
                obj.DeliveryCharge = objDetails.DeliveryCharge;
                obj.CreditCardFee = objDetails.CreditCardFee;
                obj.CanBeExported = objDetails.CanBeExported;
                obj.Exported = objDetails.Exported;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.CompanyName = objDetails.CompanyName;
                obj.ReceiverName = objDetails.ReceiverName;
                obj.WarehouseName = objDetails.WarehouseName;
                obj.GoodsInValue = objDetails.GoodsInValue;
                obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.TeamNo = objDetails.TeamNo;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.StatusNo = objDetails.StatusNo;
                obj.SupplierRMANo = objDetails.SupplierRMANo;
                obj.SupplierRMANumber = objDetails.SupplierRMANumber;
                obj.DivisionName = objDetails.DivisionName;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.SupplierTelephone = objDetails.SupplierTelephone;
                obj.SupplierFax = objDetails.SupplierFax;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetIDByNumber
        /// Calls [usp_select_GoodsIn_ID_by_Number]
        /// </summary>
        public static List<GoodsIn> GetIDByNumber(System.Int32? goodsInNumber, System.Int32? clientNo, System.Int32? isGlobalUser)
        {
            //[005] start
            List<Rebound.GlobalTrader.DAL.GoodsInDetails> objDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsIn.GetIDByNumber(goodsInNumber, clientNo, isGlobalUser);
            List<GoodsIn> lstGoodsIn = new List<GoodsIn>();
            foreach (GoodsInDetails gi in objDetails)
            {
                GoodsIn objGI = new GoodsIn();
                objGI.GoodsInId = gi.GoodsInId;
                objGI.GoodsInNumberDetail = gi.GoodsInNumberDetail;
                lstGoodsIn.Add(objGI);
            }
            return lstGoodsIn;
            //[005] end
        }
        /// <summary>
        /// GetNextNumber
        /// Calls [usp_select_GoodsIn_NextNumber]
        /// </summary>
        public static GoodsIn GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy)
        {
            Rebound.GlobalTrader.DAL.GoodsInDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsIn.GetNextNumber(clientNo, updatedBy);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                GoodsIn obj = new GoodsIn();
                obj.GoodsInNumber = objDetails.GoodsInNumber;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// Update
        /// Calls [usp_update_GoodsIn]
        /// </summary>
        public static bool Update(System.Int32? goodsInId, System.Int32? shipViaNo, System.String airWayBill, System.String reference, System.String receivingNotes, System.String supplierInvoice, System.DateTime? invoiceDate, System.Double? invoiceAmount, System.Double? bankFee, System.Int32? currencyNo, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.GoodsIn.Update(goodsInId, shipViaNo, airWayBill, reference, receivingNotes, supplierInvoice, invoiceDate, invoiceAmount, bankFee, currencyNo, updatedBy);
        }
        /// <summary>
        /// Update (without parameters)
        /// Calls [usp_update_GoodsIn]
        /// </summary>
        public bool Update()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.GoodsIn.Update(GoodsInId, ShipViaNo, AirWayBill, Reference, ReceivingNotes, SupplierInvoice, InvoiceDate, InvoiceAmount, BankFee, CurrencyNo, UpdatedBy);
        }
        //[002] code start
        /// <summary>
        /// UpdateAccountingInfo
        /// Calls [usp_update_GoodsIn_AccountingInfo]
        /// </summary>
        public static bool UpdateAccountingInfo(System.Int32? goodsInId, System.Int32? updatedBy, System.Int32? PurchaseCountryNo)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.GoodsIn.UpdateAccountingInfo(goodsInId, updatedBy, PurchaseCountryNo);
        }
        //[002] code end
        /// <summary>
        /// UpdateMainInfo
        /// Calls [usp_update_GoodsIn_MainInfo]
        /// </summary>
        public static bool UpdateMainInfo(System.Int32? goodsInId, System.Int32? shipViaNo, System.String airWayBill, System.String reference, System.String receivingNotes, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.GoodsIn.UpdateMainInfo(goodsInId, shipViaNo, airWayBill, reference, receivingNotes, updatedBy);
        }

        private static GoodsIn PopulateFromDBDetailsObject(GoodsInDetails obj)
        {
            GoodsIn objNew = new GoodsIn();
            objNew.GoodsInId = obj.GoodsInId;
            objNew.GoodsInNumber = obj.GoodsInNumber;
            objNew.ClientNo = obj.ClientNo;
            objNew.ShipViaNo = obj.ShipViaNo;
            objNew.AirWayBill = obj.AirWayBill;
            objNew.Reference = obj.Reference;
            objNew.CompanyNo = obj.CompanyNo;
            objNew.ReceivingNotes = obj.ReceivingNotes;
            objNew.DateReceived = obj.DateReceived;
            objNew.PurchaseOrderNo = obj.PurchaseOrderNo;
            objNew.CurrencyNo = obj.CurrencyNo;
            objNew.ReceivedBy = obj.ReceivedBy;
            objNew.WarehouseNo = obj.WarehouseNo;
            objNew.CustomerRMANo = obj.CustomerRMANo;
            objNew.SupplierInvoice = obj.SupplierInvoice;
            objNew.InvoiceDate = obj.InvoiceDate;
            objNew.InvoiceAmount = obj.InvoiceAmount;
            objNew.BankFee = obj.BankFee;
            objNew.UpdatedBy = obj.UpdatedBy;
            objNew.DLUP = obj.DLUP;
            objNew.GoodsValue = obj.GoodsValue;
            objNew.Tax = obj.Tax;
            objNew.DeliveryCharge = obj.DeliveryCharge;
            objNew.CreditCardFee = obj.CreditCardFee;
            objNew.CanBeExported = obj.CanBeExported;
            objNew.Exported = obj.Exported;
            objNew.CompanyName = obj.CompanyName;
            objNew.PurchaseOrderNumber = obj.PurchaseOrderNumber;
            objNew.CustomerRMANumber = obj.CustomerRMANumber;
            objNew.ReceiverName = obj.ReceiverName;
            objNew.RowNum = obj.RowNum;
            objNew.RowCnt = obj.RowCnt;
            objNew.WarehouseName = obj.WarehouseName;
            objNew.GoodsInValue = obj.GoodsInValue;
            objNew.DivisionNo = obj.DivisionNo;
            objNew.TeamNo = obj.TeamNo;
            objNew.CurrencyCode = obj.CurrencyCode;
            objNew.CurrencyDescription = obj.CurrencyDescription;
            objNew.ShipViaName = obj.ShipViaName;
            objNew.StatusNo = obj.StatusNo;
            objNew.SupplierRMANo = obj.SupplierRMANo;
            objNew.SupplierRMANumber = obj.SupplierRMANumber;
            objNew.DivisionName = obj.DivisionName;
            objNew.Buyer = obj.Buyer;
            objNew.BuyerName = obj.BuyerName;
            objNew.ReceivedByName = obj.ReceivedByName;
            objNew.ContactNo = obj.ContactNo;
            objNew.ContactName = obj.ContactName;
            objNew.TotalShipInCost = obj.TotalShipInCost;
            objNew.CompanyNameForSearch = obj.CompanyNameForSearch;
            objNew.SupplierTelephone = obj.SupplierTelephone;
            objNew.SupplierFax = obj.SupplierFax;
            return objNew;
        }
        // [001] code start
        /// <summary>
        /// GetPDFListForGoodsIn
        /// Calls [usp_selectAll_PDF_for_GoodsIn]
        /// </summary>
        public static List<PDFDocument> GetPDFListForGoodsIn(System.Int32? GoodsInId)
        {
            List<PDFDocumentDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GoodsIn.GetPDFListForGoodsIn(GoodsInId);
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
        /// Calls [usp_insert_GoodsInPDF]
        /// </summary>
        public static Int32 Insert(System.Int32? GoodsInId, System.String Caption, System.String FileName, System.Int32? UpdatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.GoodsIn.Insert(GoodsInId, Caption, FileName, UpdatedBy);
            return objReturn;
        }
        /// Delete
        /// Calls [usp_delete_GoodsInPDF]
        /// </summary>
        public static bool DeleteGoodsInPDF(System.Int32? GoodsInPdfId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.GoodsIn.DeleteGoodsInPDF(GoodsInPdfId);
        }

        #endregion

    }
}
