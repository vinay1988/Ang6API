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

namespace Rebound.GlobalTrader.BLL {
		public partial class StockLog : BizObject {
		
		#region Properties

		protected static DAL.StockLogElement Settings {
			get { return Globals.Settings.StockLogs; }
		}

		/// <summary>
		/// StockLogId
		/// </summary>
		public System.Int32 StockLogId { get; set; }		
		/// <summary>
		/// StockLogTypeNo
		/// </summary>
		public System.Int32 StockLogTypeNo { get; set; }		
		/// <summary>
		/// StockNo
		/// </summary>
		public System.Int32 StockNo { get; set; }		
		/// <summary>
		/// QuantityInStock
		/// </summary>
		public System.Int32 QuantityInStock { get; set; }		
		/// <summary>
		/// QuantityOnOrder
		/// </summary>
		public System.Int32 QuantityOnOrder { get; set; }		
		/// <summary>
		/// InvoiceNo
		/// </summary>
		public System.Int32? InvoiceNo { get; set; }		
		/// <summary>
		/// PurchaseOrderNo
		/// </summary>
		public System.Int32? PurchaseOrderNo { get; set; }		
		/// <summary>
		/// RelatedStockNo
		/// </summary>
		public System.Int32? RelatedStockNo { get; set; }		
		/// <summary>
		/// ActionQuantity
		/// </summary>
		public System.Int32? ActionQuantity { get; set; }		
		/// <summary>
		/// GoodsInNo
		/// </summary>
		public System.Int32? GoodsInNo { get; set; }		
		/// <summary>
		/// GoodsInLineNo
		/// </summary>
		public System.Int32? GoodsInLineNo { get; set; }		
		/// <summary>
		/// CRMALineNo
		/// </summary>
		public System.Int32? CRMALineNo { get; set; }		
		/// <summary>
		/// SalesOrderNo
		/// </summary>
		public System.Int32? SalesOrderNo { get; set; }		
		/// <summary>
		/// SalesOrderLineNo
		/// </summary>
		public System.Int32? SalesOrderLineNo { get; set; }		
		/// <summary>
		/// SRMALineNo
		/// </summary>
		public System.Int32? SRMALineNo { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// Detail
		/// </summary>
		public System.String Detail { get; set; }		
		/// <summary>
		/// ChangeNotes
		/// </summary>
		public System.String ChangeNotes { get; set; }		
		/// <summary>
		/// StockLogReasonNo
		/// </summary>
		public System.Int32? StockLogReasonNo { get; set; }		
		/// <summary>
		/// DebitNo
		/// </summary>
		public System.Int32? DebitNo { get; set; }		
		/// <summary>
		/// StockLogReasonName
		/// </summary>
		public System.String StockLogReasonName { get; set; }		
		/// <summary>
		/// InvoiceNumber
		/// </summary>
		public System.Int32? InvoiceNumber { get; set; }		
		/// <summary>
		/// PurchaseOrderNumber
		/// </summary>
		public System.Int32? PurchaseOrderNumber { get; set; }		
		/// <summary>
		/// RelatedStockPart
		/// </summary>
		public System.String RelatedStockPart { get; set; }		
		/// <summary>
		/// UpdatedByName
		/// </summary>
		public System.String UpdatedByName { get; set; }		
		/// <summary>
		/// GoodsInNumber
		/// </summary>
		public System.Int32? GoodsInNumber { get; set; }		
		/// <summary>
		/// SalesOrderNumber
		/// </summary>
		public System.Int32? SalesOrderNumber { get; set; }		
		/// <summary>
		/// CustomerRMANo
		/// </summary>
		public System.Int32? CustomerRMANo { get; set; }		
		/// <summary>
		/// CustomerRMANumber
		/// </summary>
		public System.Int32? CustomerRMANumber { get; set; }		
		/// <summary>
		/// SupplierRMANo
		/// </summary>
		public System.Int32? SupplierRMANo { get; set; }		
		/// <summary>
		/// SupplierRMANumber
		/// </summary>
		public System.Int32? SupplierRMANumber { get; set; }		
		/// <summary>
		/// DebitNumber
		/// </summary>
		public System.Int32? DebitNumber { get; set; }		
		/// <summary>
		/// GoodsInCurrencyCode
		/// </summary>
		public System.String GoodsInCurrencyCode { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_StockLog]
		/// </summary>
		public static bool Delete(System.Int32? stockLogId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.StockLog.Delete(stockLogId);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_StockLog]
		/// </summary>
		public static Int32 Insert(System.Int32? stockLogTypeNo, System.Int32? stockNo, System.Int32? stockLogReasonNo, System.Int32? quantityInStock, System.Int32? quantityOnOrder, System.String detail, System.String changeNotes, System.Int32? invoiceNo, System.Int32? purchaseOrderNo, System.Int32? goodsInLineNo, System.Int32? goodsInNo, System.Int32? salesOrderLineNo, System.Int32? salesOrderNo, System.Int32? srmaLineNo, System.Int32? crmaLineNo, System.Int32? debitNo, System.Int32? relatedStockNo, System.Int32? actionQuantity, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.StockLog.Insert(stockLogTypeNo, stockNo, stockLogReasonNo, quantityInStock, quantityOnOrder, detail, changeNotes, invoiceNo, purchaseOrderNo, goodsInLineNo, goodsInNo, salesOrderLineNo, salesOrderNo, srmaLineNo, crmaLineNo, debitNo, relatedStockNo, actionQuantity, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_StockLog]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.StockLog.Insert(StockLogTypeNo, StockNo, StockLogReasonNo, QuantityInStock, QuantityOnOrder, Detail, ChangeNotes, InvoiceNo, PurchaseOrderNo, GoodsInLineNo, GoodsInNo, SalesOrderLineNo, SalesOrderNo, SRMALineNo, CRMALineNo, DebitNo, RelatedStockNo, ActionQuantity, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_StockLog]
		/// </summary>
		public static StockLog Get(System.Int32? stockLogId) {
			Rebound.GlobalTrader.DAL.StockLogDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.StockLog.Get(stockLogId);
			if (objDetails == null) {
				return null;
			} else {
				StockLog obj = new StockLog();
				obj.StockLogId = objDetails.StockLogId;
				obj.StockLogTypeNo = objDetails.StockLogTypeNo;
				obj.StockNo = objDetails.StockNo;
				obj.QuantityInStock = objDetails.QuantityInStock;
				obj.QuantityOnOrder = objDetails.QuantityOnOrder;
				obj.InvoiceNo = objDetails.InvoiceNo;
				obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
				obj.RelatedStockNo = objDetails.RelatedStockNo;
				obj.ActionQuantity = objDetails.ActionQuantity;
				obj.GoodsInNo = objDetails.GoodsInNo;
				obj.GoodsInLineNo = objDetails.GoodsInLineNo;
				obj.CRMALineNo = objDetails.CRMALineNo;
				obj.SalesOrderNo = objDetails.SalesOrderNo;
				obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
				obj.SRMALineNo = objDetails.SRMALineNo;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.Detail = objDetails.Detail;
				obj.ChangeNotes = objDetails.ChangeNotes;
				obj.StockLogReasonNo = objDetails.StockLogReasonNo;
				obj.DebitNo = objDetails.DebitNo;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForStock
		/// Calls [usp_selectAll_StockLog_for_Stock]
		/// </summary>
		public static List<StockLog> GetListForStock(System.Int32? stockId) {
			List<StockLogDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.StockLog.GetListForStock(stockId);
			if (lstDetails == null) {
				return new List<StockLog>();
			} else {
				List<StockLog> lst = new List<StockLog>();
				foreach (StockLogDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.StockLog obj = new Rebound.GlobalTrader.BLL.StockLog();
					obj.StockLogId = objDetails.StockLogId;
					obj.StockLogTypeNo = objDetails.StockLogTypeNo;
					obj.StockNo = objDetails.StockNo;
					obj.QuantityInStock = objDetails.QuantityInStock;
					obj.QuantityOnOrder = objDetails.QuantityOnOrder;
					obj.InvoiceNo = objDetails.InvoiceNo;
					obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
					obj.RelatedStockNo = objDetails.RelatedStockNo;
					obj.ActionQuantity = objDetails.ActionQuantity;
					obj.GoodsInNo = objDetails.GoodsInNo;
					obj.GoodsInLineNo = objDetails.GoodsInLineNo;
					obj.CRMALineNo = objDetails.CRMALineNo;
					obj.SalesOrderNo = objDetails.SalesOrderNo;
					obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
					obj.SRMALineNo = objDetails.SRMALineNo;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.Detail = objDetails.Detail;
					obj.ChangeNotes = objDetails.ChangeNotes;
					obj.StockLogReasonNo = objDetails.StockLogReasonNo;
					obj.DebitNo = objDetails.DebitNo;
					obj.StockLogReasonName = objDetails.StockLogReasonName;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
					obj.RelatedStockPart = objDetails.RelatedStockPart;
					obj.UpdatedByName = objDetails.UpdatedByName;
					obj.GoodsInNumber = objDetails.GoodsInNumber;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.CustomerRMANo = objDetails.CustomerRMANo;
					obj.CustomerRMANumber = objDetails.CustomerRMANumber;
					obj.SupplierRMANo = objDetails.SupplierRMANo;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.DebitNumber = objDetails.DebitNumber;
					obj.GoodsInCurrencyCode = objDetails.GoodsInCurrencyCode;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_StockLog]
		/// </summary>
		public static bool Update(System.Int32? stockLogId, System.Int32? stockLogTypeNo, System.Int32? stockNo, System.Int32? quantityInStock, System.Int32? quantityOnOrder, System.Int32? invoiceNo, System.Int32? purchaseOrderNo, System.Int32? relatedStockNo, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.StockLog.Update(stockLogId, stockLogTypeNo, stockNo, quantityInStock, quantityOnOrder, invoiceNo, purchaseOrderNo, relatedStockNo, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_StockLog]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.StockLog.Update(StockLogId, StockLogTypeNo, StockNo, QuantityInStock, QuantityOnOrder, InvoiceNo, PurchaseOrderNo, RelatedStockNo, UpdatedBy);
		}

        private static StockLog PopulateFromDBDetailsObject(StockLogDetails obj) {
            StockLog objNew = new StockLog();
			objNew.StockLogId = obj.StockLogId;
			objNew.StockLogTypeNo = obj.StockLogTypeNo;
			objNew.StockNo = obj.StockNo;
			objNew.QuantityInStock = obj.QuantityInStock;
			objNew.QuantityOnOrder = obj.QuantityOnOrder;
			objNew.InvoiceNo = obj.InvoiceNo;
			objNew.PurchaseOrderNo = obj.PurchaseOrderNo;
			objNew.RelatedStockNo = obj.RelatedStockNo;
			objNew.ActionQuantity = obj.ActionQuantity;
			objNew.GoodsInNo = obj.GoodsInNo;
			objNew.GoodsInLineNo = obj.GoodsInLineNo;
			objNew.CRMALineNo = obj.CRMALineNo;
			objNew.SalesOrderNo = obj.SalesOrderNo;
			objNew.SalesOrderLineNo = obj.SalesOrderLineNo;
			objNew.SRMALineNo = obj.SRMALineNo;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.Detail = obj.Detail;
			objNew.ChangeNotes = obj.ChangeNotes;
			objNew.StockLogReasonNo = obj.StockLogReasonNo;
			objNew.DebitNo = obj.DebitNo;
			objNew.StockLogReasonName = obj.StockLogReasonName;
			objNew.InvoiceNumber = obj.InvoiceNumber;
			objNew.PurchaseOrderNumber = obj.PurchaseOrderNumber;
			objNew.RelatedStockPart = obj.RelatedStockPart;
			objNew.UpdatedByName = obj.UpdatedByName;
			objNew.GoodsInNumber = obj.GoodsInNumber;
			objNew.SalesOrderNumber = obj.SalesOrderNumber;
			objNew.CustomerRMANo = obj.CustomerRMANo;
			objNew.CustomerRMANumber = obj.CustomerRMANumber;
			objNew.SupplierRMANo = obj.SupplierRMANo;
			objNew.SupplierRMANumber = obj.SupplierRMANumber;
			objNew.DebitNumber = obj.DebitNumber;
			objNew.GoodsInCurrencyCode = obj.GoodsInCurrencyCode;
            return objNew;
        }
		
		#endregion
		
	}
}