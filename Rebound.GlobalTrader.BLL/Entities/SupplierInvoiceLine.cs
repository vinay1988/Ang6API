//Marker     Created by      Date               Remarks
//[001]      Vinay           11/06/2013         CR:- Supplier Invoice
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
    public class SupplierInvoiceLine : BizObject
    {
        #region Poperties

        protected static DAL.SupplierInvoiceLineElement Settings
        {
            get { return Globals.Settings.SupplierInvoiceLines; }
        }

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
        /// <summary>
        /// BuyerNo
        /// </summary>
        public System.Int32 BuyerNo { get; set; }

        #endregion

        #region Method
        /// <summary>
        /// Get supplierinvoiceline by ID
        /// Call Proc [usp_selectAll_SupplierInvoiceLine_for_SupplierInvoice]
        /// </summary>
        /// <param name="SupplierInvoiceId"></param>
        /// <returns></returns>
        public static List<SupplierInvoiceLine> GetListForSupplierInvoiceLine(System.Int32? SupplierInvoiceId)
        {
            List<SupplierInvoiceLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierInvoiceLine.GetListForSupplierInvoiceLine(SupplierInvoiceId);
            if (lstDetails == null)
            {
                return new List<SupplierInvoiceLine>();
            }
            else
            {
                List<SupplierInvoiceLine> lst = new List<SupplierInvoiceLine>();
                foreach (SupplierInvoiceLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SupplierInvoiceLine obj = new Rebound.GlobalTrader.BLL.SupplierInvoiceLine();
                    obj.SupplierInvoiceLineId = objDetails.SupplierInvoiceLineId;
                    obj.SupplierInvoiceNo = objDetails.SupplierInvoiceNo;
                    obj.GoodsInNo = objDetails.GoodsInNo;
                    obj.GoodsInNumber = objDetails.GoodsInNumber;
                    obj.Part = objDetails.Part;
                    obj.SupplierPart = objDetails.SupplierPart;
                    obj.UnitPrice = objDetails.UnitPrice;
                    obj.QtyReceived = objDetails.QtyReceived;
                    obj.Landedcost = objDetails.Landedcost;
                    obj.DateReceived = objDetails.DateReceived;
                    obj.StockNo = objDetails.StockNo;
                    obj.ROHS = objDetails.ROHS;
                    obj.DLUP = objDetails.DLUP;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.GoodsInLineNo = objDetails.GoodsInLineNo;

                    obj.PackageNo = objDetails.PackageNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.CountryOfManufacture = objDetails.CountryOfManufacture;
                    obj.DateCode = objDetails.DateCode;
                    obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
                    obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
                    obj.ShipInCost = objDetails.ShipInCost;
                    obj.BuyerName = objDetails.BuyerName;
                    obj.BuyerNo = objDetails.BuyerNo;

                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Search supplier goodsin line by given parameter
        /// Call Proc [usp_itemsearch_SupplierInvoice_GoodsInLine]
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="orderBy"></param>
        /// <param name="sortDir"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="companyNo"></param>
        /// <param name="includeInvoiced"></param>
        /// <param name="giLineDateFrom"></param>
        /// <param name="giLineDateTo"></param>
        /// <returns></returns>
        public static List<SupplierInvoiceLine> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Int32 companyNo, System.Boolean? includeInvoiced, System.DateTime? giLineDateFrom, System.DateTime? giLineDateTo, System.Int32? goodsInNo, System.Boolean? IsPoHub, bool? isClientInvoice,System.Int32? poNoLo,System.Int32? poNoHi)
        {
            List<SupplierInvoiceLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierInvoiceLine.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, companyNo, includeInvoiced, giLineDateFrom, giLineDateTo, goodsInNo, IsPoHub, isClientInvoice, poNoLo, poNoHi);
            if (lstDetails == null)
            {
                return new List<SupplierInvoiceLine>();
            }
            else
            {
                List<SupplierInvoiceLine> lst = new List<SupplierInvoiceLine>();
                foreach (SupplierInvoiceLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SupplierInvoiceLine obj = new Rebound.GlobalTrader.BLL.SupplierInvoiceLine();
                    obj.GoodsInLineNo = objDetails.GoodsInLineNo;
                    obj.GoodsInNumber = objDetails.GoodsInNumber;
                    obj.Part = objDetails.Part;
                    obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                    obj.QtyReceived = objDetails.QtyReceived;
                    obj.Price = objDetails.Price;
                    obj.ShipInCost = objDetails.ShipInCost;
                    obj.NPRPrinted = objDetails.NPRPrinted;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.DateReceived = objDetails.DateReceived;
                    obj.GoodsInNo = objDetails.GoodsInNo;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
       
        #endregion

        /// <summary>
        /// Insert supplier invoice line and update the invoiced field of goodsinline
        /// Call Proc [usp_insert_SupplierInvoiceLine]
        /// </summary>
        /// <param name="goodsInLineId"></param>
        /// <param name="supplierInvoiceNo"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public static Int32 InsertSupplierInvoiceLine(System.Int32 goodsInLineId, System.Int32 supplierInvoiceNo, System.Int32 updatedBy,bool? isPoHub)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SupplierInvoiceLine.InsertSupplierInvoiceLine(goodsInLineId, supplierInvoiceNo, updatedBy,isPoHub);
        }

        /// <summary>
        /// Delete Supplier Invoice Line
        /// Call Proc [usp_delete_SupplierInvoiceLine]
        /// </summary>
        /// <param name="supplierInvoiceLineId"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public static bool Delete(System.Int32? supplierInvoiceLineId, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SupplierInvoiceLine.Delete(supplierInvoiceLineId, updatedBy);
        }
    }
}
