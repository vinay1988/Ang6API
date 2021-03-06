﻿//Marker     Changed by      Date               Remarks
//[001]      Vinay           11/06/2013         CR:- Supplier Invoice
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebound.GlobalTrader.DAL
{
    public class SupplierInvoiceDetails
    {
        #region Constructors

        public SupplierInvoiceDetails() { }

        #endregion

        #region Properties
      
        /// <summary>
        /// SupplierInvoiceID  (from Table)
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
        /// ClientID  (from Table)
        /// </summary>
        public System.Int32 ClientNo { get; set; }
       
        /// <summary>
        /// SupplierInvoiceDate  (from Table)
        /// </summary>
        public System.DateTime SupplierInvoiceDate { get; set; }
        /// <summary>
        /// SupplierCode  (from Table)
        /// </summary>
        public System.String SupplierCode { get; set; }
        /// <summary>
        /// SupplierName  (from Table)
        /// </summary>
        public System.String SupplierName { get; set; }
        /// <summary>
        /// CurrencyNo  (from Table)
        /// </summary>
        public System.Int32? CurrencyNo { get; set; }
        /// <summary>
        /// CurrencyCode
        /// </summary>
        public System.String CurrencyCode { get; set; }
        /// <summary>
        /// InvoiceAmount  (from Table)
        /// </summary>
        public System.Double? InvoiceAmount { get; set; }
        /// <summary>
        /// GoodsValue  (from Table)
        /// </summary>
        public System.Double? GoodsValue { get; set; }
        /// <summary>
        /// Tax  (from Table)
        /// </summary>
        public System.Double? Tax { get; set; }
        /// <summary>
        /// DeliveryCharge  (from Table)
        /// </summary>
        public System.Double? DeliveryCharge { get; set; }
        /// <summary>
        /// BankFee  (from Table)
        /// </summary>
        public System.Double? BankFee { get; set; }
        /// <summary>
        /// CreditCardFee  (from Table)
        /// </summary>
        public System.Double? CreditCardFee { get; set; }
        /// <summary>
        /// Notes  (from Table)
        /// </summary>
        public System.String Notes { get; set; }
        /// <summary>
        /// SecondRef  (from Table)
        /// </summary>
        public System.String SecondRef { get; set; }
        /// <summary>
        /// Narrative  (from Table)
        /// </summary>
        public System.String Narrative { get; set; }
        /// <summary>
        /// CanbeExported  (from Table)
        /// </summary>
        public System.Boolean? CanbeExported { get; set; }
        /// <summary>
        /// Exported  (from Table)
        /// </summary>
        public System.Boolean? Exported { get; set; }
        /// <summary>
        /// URNNumber  (from Table)
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
        /// RowNum
        /// </summary>
        public System.Int64? RowNum { get; set; }
        /// <summary>
        /// RowCnt
        /// </summary>
        public System.Int32? RowCnt { get; set; }
        /// <summary>
        /// Part
        /// </summary>
        public System.String Part { get; set; }
        /// <summary>
        /// DLUP  (from Table)
        /// </summary>
        public System.DateTime DLUP { get; set; }
        /// <summary>
        /// UpdatedBy  (from Table)
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

        
    }
}
