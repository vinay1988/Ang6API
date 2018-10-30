using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebound.GlobalTrader.DAL
{
    public class SupplierInvoiceLineDetails
    {
        #region Constructors

        public SupplierInvoiceLineDetails() { }
		
		#endregion

        #region Poperties


        /// <summary>
        /// SupplierInvoiceLineId
        /// </summary>
        public System.Int32 SupplierInvoiceLineId { get; set; }
        /// <summary>
        /// SupplierInvoiceNo
        /// </summary>
        public System.Int32 SupplierInvoiceNo { get; set; }
        /// <summary>
        /// GoodInLineNo
        /// </summary>
        public System.Int32 GoodsInLineNo { get; set; }
        /// <summary>
        /// GoodsInNo
        /// </summary>
        public System.Int32 GoodsInNo { get; set; }
        /// <summary>
        /// UnitPrice
        /// </summary>
        public System.Double? UnitPrice { get; set; }
        /// <summary>
        /// Part
        /// </summary>
        public System.String Part { get; set; }
        /// <summary>
        /// QtyReceived
        /// </summary>
        public System.Int32? QtyReceived { get; set; }
        /// <summary>
        /// Landedcost
        /// </summary>
        public System.Double? Landedcost { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public System.Double? Price { get; set; }
        /// <summary>
        /// ShipInCost
        /// </summary>
        public System.Double? ShipInCost { get; set; }
        /// <summary>
        /// PurchaseOrderLineNo
        /// </summary>
        public System.Int32? PurchaseOrderLineNo { get; set; }
        /// <summary>
        /// PurchaseOrderNo
        /// </summary>
        public System.Int32? PurchaseOrderNumber { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime DLUP { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// NPRPrinted
        /// </summary>
        public System.Boolean? NPRPrinted { get; set; }
        /// <summary>
        /// RowNum
        /// </summary>
        public System.Int64? RowNum { get; set; }
        /// <summary>
        /// RowCnt
        /// </summary>
        public System.Int32? RowCnt { get; set; }
        /// <summary>
        /// GoodsInNumber
        /// </summary>
        public System.Int32? GoodsInNumber { get; set; }
        /// <summary>
        /// SupplierPart
        /// </summary>
        public System.String SupplierPart { get; set; }
        /// <summary>
        /// DateReceived
        /// </summary>
        public System.DateTime? DateReceived { get; set; }
        /// <summary>
        /// StockNo
        /// </summary>
        public System.Int32? StockNo { get; set; }
        /// <summary>
        /// ROHS
        /// </summary>
        public System.Byte? ROHS { get; set; }
        /// <summary>
        /// CurrencyNo
        /// </summary>
        public System.Int32? CurrencyNo { get; set; }
        /// <summary>
        /// CurrencyCode
        /// </summary>
        public System.String CurrencyCode { get; set; }


        public string CountryOfManufacture { get; set; }

        public string ProductName { get; set; }

        public string DateCode { get; set; }

        public string PackageNo { get; set; }

        public System.Int32? InternalPurchaseOrderId { get; set; }
        public System.Int32? InternalPurchaseOrderNumber { get; set; }
        public System.String BuyerName { get; set; }
        public System.Int32 BuyerNo { get; set; }
        #endregion
		
    }
}
