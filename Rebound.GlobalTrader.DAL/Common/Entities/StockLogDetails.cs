using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Rebound.GlobalTrader.DAL {
	
	public class StockLogDetails {
		
		#region Constructors
		
		public StockLogDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// StockLogId (from Table)
		/// </summary>
		public System.Int32 StockLogId { get; set; }
		/// <summary>
		/// StockLogTypeNo (from Table)
		/// </summary>
		public System.Int32 StockLogTypeNo { get; set; }
		/// <summary>
		/// StockNo (from Table)
		/// </summary>
		public System.Int32 StockNo { get; set; }
		/// <summary>
		/// QuantityInStock (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32 QuantityInStock { get; set; }
		/// <summary>
		/// QuantityOnOrder (from usp_selectAll_Allocation_for_SalesOrderLine)
		/// </summary>
		public System.Int32 QuantityOnOrder { get; set; }
		/// <summary>
		/// InvoiceNo (from Table)
		/// </summary>
		public System.Int32? InvoiceNo { get; set; }
		/// <summary>
		/// PurchaseOrderNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? PurchaseOrderNo { get; set; }
		/// <summary>
		/// RelatedStockNo (from Table)
		/// </summary>
		public System.Int32? RelatedStockNo { get; set; }
		/// <summary>
		/// ActionQuantity (from Table)
		/// </summary>
		public System.Int32? ActionQuantity { get; set; }
		/// <summary>
		/// GoodsInNo (from Table)
		/// </summary>
		public System.Int32? GoodsInNo { get; set; }
		/// <summary>
		/// GoodsInLineNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? GoodsInLineNo { get; set; }
		/// <summary>
		/// CRMALineNo (from Table)
		/// </summary>
		public System.Int32? CRMALineNo { get; set; }
		/// <summary>
		/// SalesOrderNo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? SalesOrderNo { get; set; }
		/// <summary>
		/// SalesOrderLineNo (from Table)
		/// </summary>
		public System.Int32? SalesOrderLineNo { get; set; }
		/// <summary>
		/// SRMALineNo (from Table)
		/// </summary>
		public System.Int32? SRMALineNo { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// Detail (from Table)
		/// </summary>
		public System.String Detail { get; set; }
		/// <summary>
		/// ChangeNotes (from Table)
		/// </summary>
		public System.String ChangeNotes { get; set; }
		/// <summary>
		/// StockLogReasonNo (from usp_select_Stock)
		/// </summary>
		public System.Int32? StockLogReasonNo { get; set; }
		/// <summary>
		/// DebitNo (from Table)
		/// </summary>
		public System.Int32? DebitNo { get; set; }
		/// <summary>
		/// StockLogReasonName (from usp_selectAll_StockLog_for_Stock)
		/// </summary>
		public System.String StockLogReasonName { get; set; }
		/// <summary>
		/// InvoiceNumber (from usp_select_Credit)
		/// </summary>
		public System.Int32? InvoiceNumber { get; set; }
		/// <summary>
		/// PurchaseOrderNumber (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? PurchaseOrderNumber { get; set; }
		/// <summary>
		/// RelatedStockPart (from usp_selectAll_StockLog_for_Stock)
		/// </summary>
		public System.String RelatedStockPart { get; set; }
		/// <summary>
		/// UpdatedByName (from usp_selectAll_StockLog_for_Stock)
		/// </summary>
		public System.String UpdatedByName { get; set; }
		/// <summary>
		/// GoodsInNumber (from Table)
		/// </summary>
		public System.Int32? GoodsInNumber { get; set; }
		/// <summary>
		/// SalesOrderNumber (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? SalesOrderNumber { get; set; }
		/// <summary>
		/// CustomerRMANo (from usp_selectAll_Allocation_for_SalesOrderLine)
		/// </summary>
		public System.Int32? CustomerRMANo { get; set; }
		/// <summary>
		/// CustomerRMANumber (from usp_selectAll_Allocation_for_SalesOrderLine)
		/// </summary>
		public System.Int32? CustomerRMANumber { get; set; }
		/// <summary>
		/// SupplierRMANo (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? SupplierRMANo { get; set; }
		/// <summary>
		/// SupplierRMANumber (from usp_selectAll_Allocation)
		/// </summary>
		public System.Int32? SupplierRMANumber { get; set; }
		/// <summary>
		/// DebitNumber (from Table)
		/// </summary>
		public System.Int32? DebitNumber { get; set; }
		/// <summary>
		/// GoodsInCurrencyCode (from usp_selectAll_StockLog_for_Stock)
		/// </summary>
		public System.String GoodsInCurrencyCode { get; set; }

		#endregion

	}
}