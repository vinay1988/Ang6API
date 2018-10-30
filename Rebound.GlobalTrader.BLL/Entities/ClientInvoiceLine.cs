//Marker     Created by      Date               Remarks
//[001]      Vinay           11/06/2013         CR:- Client Invoice
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
    public class ClientInvoiceLine : BizObject
    {
        #region Poperties

        protected static DAL.ClientInvoiceLineElement Settings
        {
            get { return Globals.Settings.ClientInvoiceLines; }
        }

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

        public int?  PackageNo { get; set; }

        public string PackageName { get; set; }
        /// <summary>
        /// Taxable (from Table)
        /// </summary>
        public System.String Taxable { get; set; }
        public bool IsLineTaxable
        {
            get
            {
                return (Taxable == "Y" || Taxable == "1");
            }
        }
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

        #region Method
        /// <summary>
        /// Get Clientinvoiceline by ID
        /// Call Proc [usp_selectAll_ClientInvoiceLine_for_ClientInvoice]
        /// </summary>
        /// <param name="ClientInvoiceId"></param>
        /// <returns></returns>
        public static List<ClientInvoiceLine> GetListForClientInvoiceLine(System.Int32? ClientInvoiceId)
        {
            List<ClientInvoiceLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ClientInvoiceLine.GetListForClientInvoiceLine(ClientInvoiceId);
            if (lstDetails == null)
            {
                return new List<ClientInvoiceLine>();
            }
            else
            {
                List<ClientInvoiceLine> lst = new List<ClientInvoiceLine>();
                foreach (ClientInvoiceLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.ClientInvoiceLine obj = new Rebound.GlobalTrader.BLL.ClientInvoiceLine();
                    obj.ClientInvoiceLineId = objDetails.ClientInvoiceLineId;
                    obj.ClientInvoiceNo = objDetails.ClientInvoiceNo;
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

                    obj.CountryOfManufacture = objDetails.CountryOfManufacture;
                    obj.ProductNo = objDetails.ProductNo;
                    obj.ProductName = objDetails.ProductName;
                    obj.DateCode = objDetails.DateCode;
                    obj.PackageNo = objDetails.PackageNo;
                    obj.PackageName = objDetails.PackageName;
                    obj.InternalPurchaseOrderNo = objDetails.InternalPurchaseOrderNo;
                    obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
                    obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                    obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                    obj.Taxable = objDetails.Taxable;
                    obj.ManufacturerNo = objDetails.ManufacturerNo;
                    obj.ManufacturerCode = objDetails.ManufacturerCode;
                    obj.POSerialNo = objDetails.POSerialNo;

                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Search Client goodsin line by given parameter
        /// Call Proc [usp_itemsearch_ClientInvoice_GoodsInLine]
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
        public static List<ClientInvoiceLine> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Int32 companyNo, System.Boolean? includeInvoiced, System.DateTime? giLineDateFrom, System.DateTime? giLineDateTo, System.Int32? goodsInNo)
        {
            List<ClientInvoiceLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ClientInvoiceLine.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, companyNo, includeInvoiced, giLineDateFrom, giLineDateTo, goodsInNo);
            if (lstDetails == null)
            {
                return new List<ClientInvoiceLine>();
            }
            else
            {
                List<ClientInvoiceLine> lst = new List<ClientInvoiceLine>();
                foreach (ClientInvoiceLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.ClientInvoiceLine obj = new Rebound.GlobalTrader.BLL.ClientInvoiceLine();
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
        /// Insert Client invoice line and update the invoiced field of goodsinline
        /// Call Proc [usp_insert_ClientInvoiceLine]
        /// </summary>
        /// <param name="goodsInLineId"></param>
        /// <param name="ClientInvoiceNo"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public static Int32 InsertClientInvoiceLine(System.Int32 goodsInLineId, System.Int32 ClientInvoiceNo, System.Int32 updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.ClientInvoiceLine.InsertClientInvoiceLine(goodsInLineId, ClientInvoiceNo, updatedBy);
        }

        /// <summary>
        /// Delete Client Invoice Line
        /// Call Proc [usp_delete_ClientInvoiceLine]
        /// </summary>
        /// <param name="ClientInvoiceLineId"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public static bool Delete(System.Int32? ClientInvoiceLineId, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.ClientInvoiceLine.Delete(ClientInvoiceLineId, updatedBy);
        }

        /// <summary>
        /// 
        /// Calls [usp_getClientInvoice]
        /// </summary>
        public static List<ClientInvoiceLine> GetClientInvoice(System.Int32? ClientInvoiceId, System.Int32? clientInvoiceLineNo)
        {
            List<ClientInvoiceLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ClientInvoiceLine.GetClientInvoice(ClientInvoiceId, clientInvoiceLineNo);
            if (lstDetails == null)
            {
                return new List<ClientInvoiceLine>();
            }
            else
            {
                List<ClientInvoiceLine> lst = new List<ClientInvoiceLine>();
                foreach (ClientInvoiceLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.ClientInvoiceLine obj = new Rebound.GlobalTrader.BLL.ClientInvoiceLine();
                    obj.ClientInvoiceLineId = objDetails.ClientInvoiceLineId;
                    obj.ClientInvoiceNo = objDetails.ClientInvoiceNo;
                    obj.DateReceived = objDetails.DateReceived;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.QtyReceived = objDetails.QtyReceived;
                    obj.Part = objDetails.Part;
                    obj.Price = objDetails.Price;
                    obj.ROHS = objDetails.ROHS;
                    obj.GoodsInNo = objDetails.GoodsInNo;
                    obj.ClientInvoiceNumber = objDetails.ClientInvoiceNumber;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    obj.GoodsInNumber = objDetails.GoodsInNumber;
                    obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
                    obj.DebitNumber = objDetails.DebitNumber;


                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }


        /// <summary>
        /// Get
        /// Calls [usp_select_ClientInvoiceLine]
        /// </summary>
        public static ClientInvoiceLine Get(System.Int32? clientInvoiceLineId)
        {
            Rebound.GlobalTrader.DAL.ClientInvoiceLineDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.ClientInvoiceLine.Get(clientInvoiceLineId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                ClientInvoiceLine obj = new ClientInvoiceLine();
                obj.ClientInvoiceLineId = objDetails.ClientInvoiceLineId;
                obj.ClientInvoiceNo = objDetails.ClientInvoiceNo;
                obj.GoodsInNo = objDetails.GoodsInNo;
                obj.Price = objDetails.Price;
                obj.Part = objDetails.Part;
                obj.QtyReceived = objDetails.QtyReceived;
                obj.DateReceived = objDetails.DateReceived;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.DateCode = objDetails.DateCode;
                obj.ProductNo = objDetails.ProductNo;
                obj.SupplierPart = objDetails.SupplierPart;
                obj.ROHS = objDetails.ROHS;
                obj.PackageNo = objDetails.PackageNo;
                obj.Landedcost = objDetails.Landedcost;
                obj.ManufacturerNo = objDetails.ManufacturerNo;
                obj.ManufacturerCode = objDetails.ManufacturerCode;
                obj.ManufacturerName = objDetails.ManufacturerName;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.ProductDescription = objDetails.ProductDescription;
                objDetails = null;

                return obj;
            }
        }
    
    }
}
