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
    public partial class Report {
		/// <summary>
		/// An enum representation of the 'tbReport' table.
		/// </summary>
		/// <remark>This enumeration contains the items contained in the table tbReport</remark>
		[Serializable]
		public enum List {
			AutoEnteredSuppliers_Unedited = 1, 
			ClosedRequirementsReasons = 2, 
			CompaniesApprovedToPurchaseFrom = 3, 
			CustomerListforSalesperson = 4, 
			DailyImports = 5, 
			DailyImportsBySource = 6, 
			LoginStatistics = 7, 
			LoginStatisticsbyName = 8, 
			NumberofAccountsbySalesperson = 9, 
			OpenRequirementsbyCustomer = 10, 
			NumberofOffersbyVendor = 11, 
			NumberofOffersHistorybyVendor = 12, 
			NumberofRequirementsbyVendor = 13, 
			UserList = 14, 
			PickSheetSalesOrdersBasic = 15, 
			PickSheetSalesOrdersDetailed = 16, 
			OrdersToBeShippedBySalesperson = 17, 
			OrdersToBeShipped = 18, 
			PurchaseOrdersDueIn = 19, 
			InventoryLocationReport = 20, 
			GoodsReceived = 21, 
			InvoicesSortedbyInvoiceNumber = 22, 
			ShippedOrdersSortedbyInvoiceNumber = 23, 
			OpenRequirementsReportBySalesperson = 24, 
			OpenSalesOrders = 25, 
			GrossProfitBreakdown = 26, 
			SummaryShippedSalesbySalesperson = 27, 
			ShippedOrdersSortedbyInvoiceNumberforaSalesperson = 28, 
			InvoicesSortedbyInvoiceNumberforaSalesperson = 29, 
			StockList = 30, 
			OpenSalesOrdersforSalesperson = 31, 
			PurchaseOrdersDueInforSalesperson = 32, 
			SummaryShippedSalesbyDivision = 33, 
			ShippedSalesforLot = 34, 
			InventoryLocationReportforLot = 35, 
			SummaryOpenOrdersbySalesperson = 36, 
			SummaryOpenOrdersbyDivision = 37, 
			InvoicesSortedbyInvoiceNumberforaCustomer = 38, 
			ShippedOrdersSortedbyInvoiceNumberforaCustomer = 39, 
			StockValuation = 40, 
			CreditNotes = 41, 
			CreditNotesforaCustomer = 42, 
			CreditNotesforaSalesperson = 43, 
			SummaryBookedOrdersbySalesperson = 44, 
			SummaryBookedOrdersbyDivision = 45, 
			ActiveVendors = 46, 
			OpenCustomerRMAs = 47, 
			OpenCustomerRMAsforaSaleperson = 48, 
			OpenCustomerRMAsforaCustomer = 49, 
			ReceivedCustomerRMAs = 50, 
			ReceivedCustomerRMAsforaSaleperson = 51, 
			ReceivedCustomerRMAsforaCustomer = 52, 
			OpenSupplierRMAs = 53, 
			OpenSupplierRMAsforaBuyer = 54, 
			OpenSupplierRMAsforaSupplier = 55, 
			ShippedSupplierRMAs = 56, 
			ShippedSupplierRMAsforaBuyer = 57, 
			ShippedSupplierRMAsforaSupplier = 58, 
			ApprovedCustomersOnStop = 59, 
			OpenCustomerRMAswithReasons = 60, 
			OpenCustomerRMAsforaSalepersonwithReasons = 61, 
			OpenCustomerRMAsforaCustomerwithReasons = 62, 
			ReceivedCustomerRMAswithReasons = 63, 
			ReceivedCustomerRMAsforaSalepersonwithReasons = 64, 
			ReceivedCustomerRMAsforaCustomerwithReasons = 65, 
			OpenSupplierRMAswithReasons = 66, 
			OpenSupplierRMAsforaBuyerwithReasons = 67, 
			OpenSupplierRMAsforaSupplierwithReasons = 68, 
			ShippedSupplierRMAswithReasons = 69, 
			ShippedSupplierRMAsforaBuyerwithReasons = 70, 
			ShippedSupplierRMAsforaSupplierwithReasons = 71, 
			PurchaseOrdersDueInforBuyer = 72, 
			PickSheetSupplierRMAs = 73, 
			GoodsReceivedShipmentDetails = 74, 
			SummaryShippedSalesbyCustomer = 75, 
			SummaryBookedOrdersbyCustomer = 77, 
			StockCount = 78, 
			CompaniesNotContacted = 79, 
			ContactsNotContacted = 80, 
			CommunicationLogActivityforaUser = 81, 
			PurchaseRequisitions = 82, 
			PurchaseRequisitionsforaCustomer = 83, 
			PurchaseRequisitionsforaSalesPerson = 84, 
			DailyCustomerRequirementsbySalesperson_Totals = 85, 
			DailyCustomerRequirementsbySalesperson_Summary = 86, 
			DailyCustomerRequirementsbySalesperson_Detailed = 87, 
			SupplierOnTimeDeliveryReport = 88, 
			CustomerOnTimeDeliveryReport = 89, 
			ReceivedGoodsValuationbyCountry = 90, 
			ShippedGoodsValuationbyCountry = 91, 
			IntrastatReportforEECDispatches_Sales = 92, 
			IntrastatReportforEECArrivals_Purchases = 93, 
			IntrastatReportforEECArrivals_CustomerRMAs = 94, 
			IntrastatReportforEECDispatches_SupplierRMAs = 95, 
			ContactEmailList = 96, 
			OustandingCustomerInvoices = 97, 
			CustomerStatement = 98, 
			DaysSinceLastInvoicebyCustomer = 99, 
			SummaryOpenOrdersbyCustomer = 102, 
			DaysSinceLastInvoicebyContact = 103, 
			GoodsReceivedNotInvoiced = 104, 
			OpenQuotes = 105, 
			OpenPurchaseOrders = 106, 
			OpenPurchaseOrdersbySupplier = 107, 
			OpenPurchaseOrdersbyCompanyType = 108, 
			InvalidCompanyPurchasingInfo = 109, 
			InvalidCompanySalesInfo = 110, 
			RandomStockCheck = 111,
            LotStockProvision=113,
            RequirementWithBOM = 114,
            PurchaseQuote = 115
		}		

	

		
	}
}