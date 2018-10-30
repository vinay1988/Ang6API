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
		public partial class CustomerRmaLineAllocation : BizObject {
		
		#region Properties

		protected static DAL.CustomerRmaLineAllocationElement Settings {
			get { return Globals.Settings.CustomerRmaLineAllocations; }
		}

		/// <summary>
		/// CustomerRMALineAllocationId
		/// </summary>
		public System.Int32 CustomerRMALineAllocationId { get; set; }		
		/// <summary>
		/// CustomerRMALineNo
		/// </summary>
		public System.Int32 CustomerRMALineNo { get; set; }		
		/// <summary>
		/// InvoiceLineAllocationNo
		/// </summary>
		public System.Int32 InvoiceLineAllocationNo { get; set; }		
		/// <summary>
		/// Quantity
		/// </summary>
		public System.Int32 Quantity { get; set; }		
		/// <summary>
		/// GoodsInLineNo
		/// </summary>
		public System.Int32? GoodsInLineNo { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// CustomerRMAId
		/// </summary>
		public System.Int32 CustomerRMAId { get; set; }		
		/// <summary>
		/// CustomerRMANumber
		/// </summary>
		public System.Int32 CustomerRMANumber { get; set; }		
		/// <summary>
		/// CustomerRMADate
		/// </summary>
		public System.DateTime CustomerRMADate { get; set; }		
		/// <summary>
		/// ReturnDate
		/// </summary>
		public System.DateTime? ReturnDate { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// Reason
		/// </summary>
		public System.String Reason { get; set; }		
		/// <summary>
		/// InvoiceNumber
		/// </summary>
		public System.Int32 InvoiceNumber { get; set; }		
		/// <summary>
		/// InvoiceNo
		/// </summary>
		public System.Int32? InvoiceNo { get; set; }		
		/// <summary>
		/// InvoiceLineNo
		/// </summary>
		public System.Int32 InvoiceLineNo { get; set; }		
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32 CompanyNo { get; set; }		
		/// <summary>
		/// CompanyName
		/// </summary>
		public System.String CompanyName { get; set; }		
		/// <summary>
		/// PurchaseOrderLineNo
		/// </summary>
		public System.Int32? PurchaseOrderLineNo { get; set; }		
		/// <summary>
		/// AuthorisedBy
		/// </summary>
		public System.Int32 AuthorisedBy { get; set; }		
		/// <summary>
		/// AuthoriserName
		/// </summary>
		public System.String AuthoriserName { get; set; }		
		/// <summary>
		/// StockNo
		/// </summary>
		public System.Int32? StockNo { get; set; }		
		/// <summary>
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// CountForPurchaseOrderLine
		/// Calls [usp_count_CustomerRMALineAllocation_for_PurchaseOrderLine]
		/// </summary>
		public static Int32 CountForPurchaseOrderLine(System.Int32? purchaseOrderLineId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLineAllocation.CountForPurchaseOrderLine(purchaseOrderLineId);
		}		/// <summary>
		/// Delete
		/// Calls [usp_delete_CustomerRMALineAllocation]
		/// </summary>
		public static bool Delete(System.Int32? customerRmaLineAllocationId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLineAllocation.Delete(customerRmaLineAllocationId);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_CustomerRMALineAllocation]
		/// </summary>
		public static Int32 Insert(System.Int32? customerRmaLineNo, System.Int32? invoiceLineAllocationNo, System.Int32? quantity, System.Int32? goodsInLineNo, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLineAllocation.Insert(customerRmaLineNo, invoiceLineAllocationNo, quantity, goodsInLineNo, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_CustomerRMALineAllocation]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLineAllocation.Insert(CustomerRMALineNo, InvoiceLineAllocationNo, Quantity, GoodsInLineNo, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_CustomerRMALineAllocation]
		/// </summary>
		public static CustomerRmaLineAllocation Get(System.Int32? customerRmaLineAllocationId) {
			Rebound.GlobalTrader.DAL.CustomerRmaLineAllocationDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLineAllocation.Get(customerRmaLineAllocationId);
			if (objDetails == null) {
				return null;
			} else {
				CustomerRmaLineAllocation obj = new CustomerRmaLineAllocation();
				obj.CustomerRMALineAllocationId = objDetails.CustomerRMALineAllocationId;
				obj.CustomerRMALineNo = objDetails.CustomerRMALineNo;
				obj.InvoiceLineAllocationNo = objDetails.InvoiceLineAllocationNo;
				obj.Quantity = objDetails.Quantity;
				obj.GoodsInLineNo = objDetails.GoodsInLineNo;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForPurchaseOrderLine
		/// Calls [usp_selectAll_CustomerRMALineAllocation_for_PurchaseOrderLine]
		/// </summary>
		public static List<CustomerRmaLineAllocation> GetListForPurchaseOrderLine(System.Int32? purchaseOrderLineId, System.Int32? pageIndex, System.Int32? pageSize) {
			List<CustomerRmaLineAllocationDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLineAllocation.GetListForPurchaseOrderLine(purchaseOrderLineId, pageIndex, pageSize);
			if (lstDetails == null) {
				return new List<CustomerRmaLineAllocation>();
			} else {
				List<CustomerRmaLineAllocation> lst = new List<CustomerRmaLineAllocation>();
				foreach (CustomerRmaLineAllocationDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CustomerRmaLineAllocation obj = new Rebound.GlobalTrader.BLL.CustomerRmaLineAllocation();
					obj.CustomerRMALineAllocationId = objDetails.CustomerRMALineAllocationId;
					obj.CustomerRMALineNo = objDetails.CustomerRMALineNo;
					obj.CustomerRMAId = objDetails.CustomerRMAId;
					obj.CustomerRMANumber = objDetails.CustomerRMANumber;
					obj.CustomerRMADate = objDetails.CustomerRMADate;
					obj.ReturnDate = objDetails.ReturnDate;
					obj.ClientNo = objDetails.ClientNo;
					obj.Reason = objDetails.Reason;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.InvoiceNo = objDetails.InvoiceNo;
					obj.InvoiceLineNo = objDetails.InvoiceLineNo;
					obj.InvoiceLineAllocationNo = objDetails.InvoiceLineAllocationNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.Quantity = objDetails.Quantity;
					obj.GoodsInLineNo = objDetails.GoodsInLineNo;
					obj.PurchaseOrderLineNo = objDetails.PurchaseOrderLineNo;
					obj.AuthorisedBy = objDetails.AuthorisedBy;
					obj.AuthoriserName = objDetails.AuthoriserName;
					obj.StockNo = objDetails.StockNo;
					obj.RowNum = objDetails.RowNum;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_CustomerRMALineAllocation]
		/// </summary>
		public static bool Update(System.Int32? customerRmaLineAllocationId, System.Int32? customerRmaLineNo, System.Int32? invoiceLineAllocationNo, System.Int32? quantity, System.Int32? goodsInLineNo, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLineAllocation.Update(customerRmaLineAllocationId, customerRmaLineNo, invoiceLineAllocationNo, quantity, goodsInLineNo, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_CustomerRMALineAllocation]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRmaLineAllocation.Update(CustomerRMALineAllocationId, CustomerRMALineNo, InvoiceLineAllocationNo, Quantity, GoodsInLineNo, UpdatedBy);
		}

        private static CustomerRmaLineAllocation PopulateFromDBDetailsObject(CustomerRmaLineAllocationDetails obj) {
            CustomerRmaLineAllocation objNew = new CustomerRmaLineAllocation();
			objNew.CustomerRMALineAllocationId = obj.CustomerRMALineAllocationId;
			objNew.CustomerRMALineNo = obj.CustomerRMALineNo;
			objNew.InvoiceLineAllocationNo = obj.InvoiceLineAllocationNo;
			objNew.Quantity = obj.Quantity;
			objNew.GoodsInLineNo = obj.GoodsInLineNo;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.CustomerRMAId = obj.CustomerRMAId;
			objNew.CustomerRMANumber = obj.CustomerRMANumber;
			objNew.CustomerRMADate = obj.CustomerRMADate;
			objNew.ReturnDate = obj.ReturnDate;
			objNew.ClientNo = obj.ClientNo;
			objNew.Reason = obj.Reason;
			objNew.InvoiceNumber = obj.InvoiceNumber;
			objNew.InvoiceNo = obj.InvoiceNo;
			objNew.InvoiceLineNo = obj.InvoiceLineNo;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.CompanyName = obj.CompanyName;
			objNew.PurchaseOrderLineNo = obj.PurchaseOrderLineNo;
			objNew.AuthorisedBy = obj.AuthorisedBy;
			objNew.AuthoriserName = obj.AuthoriserName;
			objNew.StockNo = obj.StockNo;
			objNew.RowNum = obj.RowNum;
            return objNew;
        }
		
		#endregion
		
	}
}