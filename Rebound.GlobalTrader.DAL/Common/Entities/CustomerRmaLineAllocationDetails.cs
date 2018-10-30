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
	
	public class CustomerRmaLineAllocationDetails {
		
		#region Constructors
		
		public CustomerRmaLineAllocationDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// CustomerRMALineAllocationId (from Table)
		/// </summary>
		public System.Int32 CustomerRMALineAllocationId { get; set; }
		/// <summary>
		/// CustomerRMALineNo (from Table)
		/// </summary>
		public System.Int32 CustomerRMALineNo { get; set; }
		/// <summary>
		/// InvoiceLineAllocationNo (from Table)
		/// </summary>
		public System.Int32 InvoiceLineAllocationNo { get; set; }
		/// <summary>
		/// Quantity (from usp_select_CustomerRMA)
		/// </summary>
		public System.Int32 Quantity { get; set; }
		/// <summary>
		/// GoodsInLineNo (from Table)
		/// </summary>
		public System.Int32? GoodsInLineNo { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// CustomerRMAId (from Table)
		/// </summary>
		public System.Int32 CustomerRMAId { get; set; }
		/// <summary>
		/// CustomerRMANumber (from Table)
		/// </summary>
		public System.Int32 CustomerRMANumber { get; set; }
		/// <summary>
		/// CustomerRMADate (from Table)
		/// </summary>
		public System.DateTime CustomerRMADate { get; set; }
		/// <summary>
		/// ReturnDate (from Table)
		/// </summary>
		public System.DateTime? ReturnDate { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// Reason (from Table)
		/// </summary>
		public System.String Reason { get; set; }
		/// <summary>
		/// InvoiceNumber (from usp_itemsearch_CustomerRMA)
		/// </summary>
		public System.Int32 InvoiceNumber { get; set; }
		/// <summary>
		/// InvoiceNo (from Table)
		/// </summary>
		public System.Int32? InvoiceNo { get; set; }
		/// <summary>
		/// InvoiceLineNo (from Table)
		/// </summary>
		public System.Int32 InvoiceLineNo { get; set; }
		/// <summary>
		/// CompanyNo (from Table)
		/// </summary>
		public System.Int32 CompanyNo { get; set; }
		/// <summary>
		/// CompanyName (from usp_itemsearch_CustomerRMA)
		/// </summary>
		public System.String CompanyName { get; set; }
		/// <summary>
		/// PurchaseOrderLineNo (from usp_selectAll_CustomerRMALineAllocation_for_PurchaseOrderLine)
		/// </summary>
		public System.Int32? PurchaseOrderLineNo { get; set; }
		/// <summary>
		/// AuthorisedBy (from Table)
		/// </summary>
		public System.Int32 AuthorisedBy { get; set; }
		/// <summary>
		/// AuthoriserName (from usp_itemsearch_CustomerRMA)
		/// </summary>
		public System.String AuthoriserName { get; set; }
		/// <summary>
		/// StockNo (from usp_selectAll_CustomerRMALineAllocation_for_PurchaseOrderLine)
		/// </summary>
		public System.Int32? StockNo { get; set; }
		/// <summary>
		/// RowNum (from usp_itemsearch_CustomerRMA)
		/// </summary>
		public System.Int64? RowNum { get; set; }

		#endregion

	}
}