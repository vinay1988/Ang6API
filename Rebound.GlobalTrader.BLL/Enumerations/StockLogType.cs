
/*

Marker     changed by      date         Remarks

[001]      Abhinav       19/10/20011   ESMS Ref:35 - CRMA - Virtual Stock Bin Update


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

namespace Rebound.GlobalTrader.BLL {
    public partial class StockLogType {
		/// <summary>
		/// An enum representation of the 'tbStockLogType' table.
		/// </summary>
		/// <remark>This enumeration contains the items contained in the table tbStockLogType</remark>
		[Serializable]
		public enum List {
			Add = 1, 
			Cancel = 2, 
			Delete = 3, 
			Edit = 4, 
			LinkPO = 5, 
			Quarantine = 6, 
			Received = 7, 
			Ship = 8, 
			Split = 9, 
			SplitNew = 10, 
			AddFromPOLine = 11, 
			SplitOriginal = 12, 
			ShippedInvoice = 13, 
			EditPOLine = 14, 
			ShippedSRMA = 15, 
			ReceivedOnGoodsIn = 16, 
			QuarantineRemoved = 17, 
			AllocatedToSalesOrder = 18, 
			ChangesFromReceivePO = 19, 
			AllocationRemovedFromSalesOrder = 20, 
			CancelledReceipt = 21, 
			CancelledShipmentForInvoice = 22, 
			AllocatedToSRMA = 23, 
			AutoCreatedFromCancelledReceipt = 24, 
			ManuallyAdded = 25, 
			Allocation = 26, 
			POLineDeleted = 27, 
			AddedFromCancelledPartialReceipts = 28, 
			AllocationRemovedFromSRMA = 29, 
			UnlinkPO = 30, 
			Inspected = 31, 
			AddedFromCRMA = 32, 
			AddedFromPartialReceipt = 33, 
			ChangesOnGoodsIn = 34, 
			CancelledShipmentForDebit = 35,
            // [001] code start
            EditCRMA = 36,
            // [001] code end
            CRMALineDeleted = 37,
            StockWrittenDown=38,
           

            PhysicalInspect = 39,
            ShipInCostUpdateWithBankFee = 40
		}		

	

		
	}
}
