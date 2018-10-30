using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rebound.GlobalTrader.DAL
{
    public class ClientInvoiceLineDetails
    {
        #region Constructors

        public ClientInvoiceLineDetails() { }
		
		#endregion

        #region Poperties


        /// <summary>
        /// ClientInvoiceLineId
        /// </summary>
        public System.Int32 ClientInvoiceLineId { get; set; }
        /// <summary>
        /// ClientInvoiceNo
        /// </summary>
        public System.Int32 ClientInvoiceNo { get; set; }
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

        public int? ProductNo { get; set; }

        public string ProductName { get; set; }

        public string DateCode { get; set; }

        public int? PackageNo { get; set; }

        public string PackageName { get; set; }
        /// <summary>
        /// Taxable (from Table)
        /// </summary>
        public System.String Taxable { get; set; }

        public System.Int32? InternalPurchaseOrderNo { get; set; }
        public System.Int32? InternalPurchaseOrderNumber { get; set; }
        public System.Int32? PurchaseOrderNo { get; set; }
        public System.Int32? ManufacturerNo { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerCode { get; set; }
        public System.Int16 POSerialNo { get; set; }
        public System.Int32 ClientInvoiceNumber { get; set; }
        public System.Int32 DebitNumber { get; set; }
        public System.String ProductDescription { get; set; }

        #endregion


      
    }
}
