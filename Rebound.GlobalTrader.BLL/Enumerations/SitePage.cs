//Marker     changed by      date         Remarks
//[001]      Vikas Kumar    10/11/20011   ESMS Ref:19 - Change link to "Add New Requirement to This Company"   
//[002]      Abhinav Goayl  28/15/2013    ESMS Ref:25 - Add sales Calculator"   

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
    public partial class SitePage {
		/// <summary>
		/// An enum representation of the 'tbSitePage' table.
		/// </summary>
		/// <remark>This enumeration contains the items contained in the table tbSitePage</remark>
		[Serializable]
		public enum List {
			None = 0,
			Home = 1, 
			Login = 2, 
			Logout = 3, 
			NotFound = 4, 
			Help = 5, 
			Error = 6, 
			Feedback = 7,
            //[002]Code Start 
            SalesCalc = 8,
            //[002]Code end 
			Contact = 1000000, 
			Contact_CompanyBrowse = 1000102, 
			Contact_CompanyAdd = 1000103, 
			Contact_CompanyDetail = 1000105, 
			Contact_ContactBrowse = 1000201, 
			Contact_ContactDetail = 1000202, 
			Contact_ManufacturerBrowse = 1000301, 
			Contact_ManufacturerDetail = 1000302, 
			Contact_ManufacturerAdd = 1000303, 
			Orders = 2000000, 
			Orders_Sourcing = 2000101, 
			Orders_CustomerRequirementBrowse = 2000201, 
			Orders_CustomerRequirementDetail = 2000202, 
			Orders_CustomerRequirementAdd = 2000203,
            //[001]Code Start 
            Orders_CustomerRequirement_DetailAdd = 2000204, 
            CSV_Import=2000205,
            //[001]Code End
			Orders_QuoteBrowse = 2000301, 
			Orders_QuoteDetail = 2000302, 
			Orders_QuoteAdd = 2000303, 
			Orders_SalesOrderBrowse = 2000401, 
			Orders_SalesOrderDetail = 2000402, 
			Orders_SalesOrderAdd = 2000403, 
			Orders_InvoiceBrowse = 2000501, 
			Orders_InvoiceDetail = 2000502, 
			Orders_InvoiceAdd = 2000503, 
			Orders_InvoiceBulkPrint = 2000504,
            //Added new on 6th Apr 2016 for new development
            Orders_ClientInvoiceBrowse = 2000505,
            Orders_ClientInvoiceDetail = 2000506, 
            //Added-End
			Orders_PurchaseOrderBrowse = 2000601, 
			Orders_PurchaseOrderDetail = 2000602, 
			Orders_PurchaseOrderAdd = 2000603, 
			Orders_PurchaseRequisitionBrowse = 2000701, 
			Orders_PurchaseRequisitionDetail = 2000702, 
			Orders_CustomerRMABrowse = 2000801, 
			Orders_CustomerRMADetail = 2000802, 
			Orders_CustomerRMAAdd = 2000803, 
			Orders_SupplierRMABrowse = 2000901, 
			Orders_SupplierRMADetail = 2000902, 
			Orders_SupplierRMAAdd = 2000903, 
			Orders_CreditNoteBrowse = 2001001, 
			Orders_CreditNoteDetail = 2001002, 
			Orders_CreditNoteAdd = 2001003, 
			Orders_DebitNoteBrowse = 2001101, 
			Orders_DebitNoteDetail = 2001102, 
			Orders_DebitNoteAdd = 2001103,
            Orders_BOMBrowse = 2001105,
            Orders_BOMAdd = 2001106,
            Orders_BOMDetail = 2001107,
            Orders_ATMIPOBOM=2001108,
            Orders_BOMAddRequirement = 2001109,
            Orders_ClientInvoiceAdd = 2001110,
			Warehouse = 3000000, 
			Warehouse_ReceivePurchaseOrderBrowse = 3000101, 
			Warehouse_ReceivePurchaseOrderDetail = 3000102, 
			Warehouse_ShipSalesOrderBrowse = 3000201, 
			Warehouse_ShipSalesOrderDetail = 3000202, 
			Warehouse_ReceiveCustomerRMABrowse = 3000301, 
			Warehouse_ReceiveCustomerRMADetail = 3000302, 
			Warehouse_ShipSupplierRMABrowse = 3000401, 
			Warehouse_ShipSupplierRMADetail = 3000402, 
			Warehouse_StockBrowse = 3000501, 
			Warehouse_StockDetail = 3000502, 
			Warehouse_StockAdd = 3000503, 
			Warehouse_ServicesBrowse = 3000601, 
			Warehouse_ServicesDetail = 3000602, 
			Warehouse_ServicesAdd = 3000603, 
			Warehouse_LotsBrowse = 3000701, 
			Warehouse_LotsDetail = 3000702, 
			Warehouse_LotsAdd = 3000703, 
			Warehouse_GoodsInBrowse = 3000801, 
			Warehouse_GoodsInDetail = 3000802, 
			Warehouse_GoodsInAdd = 3000803, 
            Warehouse_SupplierInvoiceDetail=3000806,
			Profile = 4000000, 
			Profile_Edit = 4010101, 
			Profile_MailMessages = 4020101, 
			Profile_ToDo = 4030101, 
			Profile_MailMessageGroups = 4040101, 
			Reports = 5000000, 
			Reports_ReportDetail = 5000001, 
			Setup = 6000000, 
			Setup_CompanyDetails_Country = 6010101, 
			Setup_CompanyDetails_Currency = 6010201, 
			Setup_CompanyDetails_Division = 6010301, 
			Setup_CompanyDetails_Product = 6010401, 
			Setup_CompanyDetails_Tax = 6010501,
            Setup_CompanyDetails_GlobalTax=6010502,
			Setup_CompanyDetails_Team = 6010601, 
			Setup_CompanyDetails_Terms = 6010701, 
			Setup_CompanyDetails_User = 6010801, 
			Setup_CompanyDetails_Warehouse = 6010901, 
			Setup_CompanyDetails_SourcingLinks = 6011001, 
			Setup_CompanyDetails_SequenceNumber = 6011101, 
			Setup_CompanyDetails_ShippingMethod = 6011201, 
			Setup_CompanyDetails_MailGroups = 6011301, 
			Setup_CompanyDetails_PrintedDocuments = 6011401, 
			Setup_CompanyDetails_ApplicationSettings = 6011501, 
			Setup_GlobalSettings_Package = 6020101, 
			Setup_GlobalSettings_MasterCurrencyList = 6020201, 
			Setup_GlobalSettings_Reason = 6020301, 
			Setup_GlobalSettings_ProductType = 6020401, 
			Setup_GlobalSettings_CommunicationLogType = 6020501, 
			Setup_GlobalSettings_CompanyType = 6020601, 
			Setup_GlobalSettings_IndustryType = 6020701, 
			Setup_GlobalSettings_MasterCountryList = 6020801, 
			Setup_CompanyDetails_StockLogReason = 6020901, 
			Setup_GlobalSettings_CountingMethod = 6021001, 
			Setup_GlobalSettings_ApplicationSettings = 6021101, 
			Setup_GlobalSettings_Incoterm = 6022001, 
			Setup_Security_Groups = 6030101, 
			Setup_Security_Users = 6030201, 
			OverallSetup_Home = 9000001, 
			OverallSetup_InitialSetup = 9000002, 
			OverallSetup_AddCompany = 9000003, 
			OverallSetup_AppSettings = 9000004, 
			OverallSetup_DatabaseSettings = 9000005, 
			OverallSetup_DisableCompany = 9000006, 
			OverallSetup_EmailSettings = 9000007, 
			OverallSetup_Sessions = 9000008,
            Setup_CompanyDetails_Printer = 9000010,
            Setup_CompanySettings_LocalCurrencies = 6030301,
            Setup_GlobalSettings_Certificate = 9000011,
            Setup_GlobalSettings_EightDCode = 9000012,
            Setup_CompanyDetails_LabelPath = 9000013,
            Setup_GlobalSettings_InvoiceSetting = 6756749,
            Orders_InternalPurchaseOrderDetail = 30005024,
            Setup_GlobalSettings_Product = 9000014
		}		

		public static string GetPageURL(List enmPage) {
			string str = "";
			switch (enmPage) {
				case List.Home: str = "Default.aspx"; break;
				case List.Login: str = "Login.aspx"; break;
				case List.Logout: str = "Logout.aspx"; break;
				case List.NotFound: str = "NotFound.aspx"; break;
				case List.Help: str = "Help.aspx"; break;
				case List.Error: str = "Error.aspx"; break;
				case List.Feedback: str = "Feedback.aspx"; break;
				case List.Contact: str = "Contact.aspx"; break;
                //[002]Code Start 
                case List.SalesCalc: str = "SaleCalculator.html"; break;
                //[002]Code end 
				case List.Contact_CompanyBrowse: str = "Con_CompanyBrowse.aspx"; break;
                case List.CSV_Import: str = "CSV_Import.aspx"; break;
				case List.Contact_CompanyAdd: str = "Con_CompanyAdd.aspx"; break;
				case List.Contact_CompanyDetail: str = "Con_CompanyDetail.aspx"; break;
				case List.Contact_ContactBrowse: str = "Con_ContactBrowse.aspx"; break;
				case List.Contact_ContactDetail: str = "Con_ContactDetail.aspx"; break;
				case List.Contact_ManufacturerBrowse: str = "Con_ManufacturerBrowse.aspx"; break;
				case List.Contact_ManufacturerDetail: str = "Con_ManufacturerDetail.aspx"; break;
				case List.Contact_ManufacturerAdd: str = "Con_ManufacturerAdd.aspx"; break;
				case List.Orders: str = "Orders.aspx"; break;
				case List.Orders_Sourcing: str = "Ord_Sourcing.aspx"; break;
				case List.Orders_CustomerRequirementBrowse: str = "Ord_CusReqBrowse.aspx"; break;
				case List.Orders_CustomerRequirementDetail: str = "Ord_CusReqDetail.aspx"; break;
				case List.Orders_CustomerRequirementAdd: str = "Ord_CusReqAdd.aspx"; break;
				case List.Orders_QuoteBrowse: str = "Ord_QuoteBrowse.aspx"; break;
				case List.Orders_QuoteDetail: str = "Ord_QuoteDetail.aspx"; break;
				case List.Orders_QuoteAdd: str = "Ord_QuoteAdd.aspx"; break;
				case List.Orders_SalesOrderBrowse: str = "Ord_SOBrowse.aspx"; break;
				case List.Orders_SalesOrderDetail: str = "Ord_SODetail.aspx"; break;
				case List.Orders_SalesOrderAdd: str = "Ord_SOAdd.aspx"; break;
				case List.Orders_InvoiceBrowse: str = "Ord_InvoiceBrowse.aspx"; break;
				case List.Orders_InvoiceDetail: str = "Ord_InvoiceDetail.aspx"; break;
				case List.Orders_InvoiceAdd: str = "Ord_InvoiceAdd.aspx"; break;
				case List.Orders_InvoiceBulkPrint: str = "Ord_InvoiceBulkPrint.aspx"; break;
                //Added new on 6th Apr 2016 for new development
                case List.Orders_ClientInvoiceBrowse: str = "Ord_ClientInvoiceBrowse.aspx"; break;
                case List.Orders_ClientInvoiceDetail: str = "Ord_ClientInvoiceDetail.aspx"; break;
                //End
				case List.Orders_PurchaseOrderBrowse: str = "Ord_POBrowse.aspx"; break;
				case List.Orders_PurchaseOrderDetail: str = "Ord_PODetail.aspx"; break;
				case List.Orders_PurchaseOrderAdd: str = "Ord_POAdd.aspx"; break;
				case List.Orders_PurchaseRequisitionBrowse: str = "Ord_PurReqBrowse.aspx"; break;
				case List.Orders_PurchaseRequisitionDetail: str = "Ord_PurReqDetail.aspx"; break;
				case List.Orders_CustomerRMABrowse: str = "Ord_CRMABrowse.aspx"; break;
				case List.Orders_CustomerRMADetail: str = "Ord_CRMADetail.aspx"; break;
				case List.Orders_CustomerRMAAdd: str = "Ord_CRMAAdd.aspx"; break;
				case List.Orders_SupplierRMABrowse: str = "Ord_SRMABrowse.aspx"; break;
				case List.Orders_SupplierRMADetail: str = "Ord_SRMADetail.aspx"; break;
				case List.Orders_SupplierRMAAdd: str = "Ord_SRMAAdd.aspx"; break;
				case List.Orders_CreditNoteBrowse: str = "Ord_CreditNoteBrowse.aspx"; break;
				case List.Orders_CreditNoteDetail: str = "Ord_CreditNoteDetail.aspx"; break;
				case List.Orders_CreditNoteAdd: str = "Ord_CreditNoteAdd.aspx"; break;
				case List.Orders_DebitNoteBrowse: str = "Ord_DebitNoteBrowse.aspx"; break;
				case List.Orders_DebitNoteDetail: str = "Ord_DebitNoteDetail.aspx"; break;
				case List.Orders_DebitNoteAdd: str = "Ord_DebitNoteAdd.aspx"; break;
                case List.Orders_BOMBrowse: str = "Ord_BOMBrowse.aspx"; break;
                case List.Orders_BOMAdd: str = "Ord_BOMAdd.aspx"; break;
                case List.Orders_BOMDetail: str = "Ord_BOMDetail.aspx"; break;
                case List.Orders_ATMIPOBOM: str = "Ord_ATMIPOBOM.aspx"; break;
                case List.Orders_ClientInvoiceAdd: str = "Ord_ClientInvoiceAdd.aspx"; break;

				case List.Warehouse: str = "Warehouse.aspx"; break;
				case List.Warehouse_ReceivePurchaseOrderBrowse: str = "Whs_ReceivePOBrowse.aspx"; break;
				case List.Warehouse_ReceivePurchaseOrderDetail: str = "Whs_ReceivePODetail.aspx"; break;
				case List.Warehouse_ShipSalesOrderBrowse: str = "Whs_ShipSOBrowse.aspx"; break;
				case List.Warehouse_ShipSalesOrderDetail: str = "Whs_ShipSODetail.aspx"; break;
				case List.Warehouse_ReceiveCustomerRMABrowse: str = "Whs_ReceiveCRMABrowse.aspx"; break;
				case List.Warehouse_ReceiveCustomerRMADetail: str = "Whs_ReceiveCRMADetail.aspx"; break;
				case List.Warehouse_ShipSupplierRMABrowse: str = "Whs_ShipSRMABrowse.aspx"; break;
				case List.Warehouse_ShipSupplierRMADetail: str = "Whs_ShipSRMADetail.aspx"; break;
				case List.Warehouse_StockBrowse: str = "Whs_StockBrowse.aspx"; break;
				case List.Warehouse_StockDetail: str = "Whs_StockDetail.aspx"; break;
				case List.Warehouse_StockAdd: str = "Whs_StockAdd.aspx"; break;
				case List.Warehouse_ServicesBrowse: str = "Whs_ServiceBrowse.aspx"; break;
				case List.Warehouse_ServicesDetail: str = "Whs_ServiceDetail.aspx"; break;
				case List.Warehouse_ServicesAdd: str = "Whs_ServiceAdd.aspx"; break;
				case List.Warehouse_LotsBrowse: str = "Whs_LotBrowse.aspx"; break;
				case List.Warehouse_LotsDetail: str = "Whs_LotDetail.aspx"; break;
				case List.Warehouse_LotsAdd: str = "Whs_LotAdd.aspx"; break;
				case List.Warehouse_GoodsInBrowse: str = "Whs_GIBrowse.aspx"; break;
				case List.Warehouse_GoodsInDetail: str = "Whs_GIDetail.aspx"; break;
				case List.Warehouse_GoodsInAdd: str = "Whs_GIAdd.aspx"; break;
				case List.Profile: str = "Profile.aspx"; break;
				case List.Profile_Edit: str = "Prf_ProfileEdit.aspx"; break;
				case List.Profile_MailMessages: str = "Prf_MailMessages.aspx"; break;
				case List.Profile_ToDo: str = "Prf_ToDo.aspx"; break;
				case List.Profile_MailMessageGroups: str = "Prf_MailMessageGroups.aspx"; break;
				case List.Reports: str = "Reports.aspx"; break;
				case List.Reports_ReportDetail: str = "Rpt_ReportDetail.aspx"; break;
				case List.Setup: str = "Setup.aspx"; break;
				case List.Setup_CompanyDetails_Country: str = "Set_CD_Country.aspx"; break;
				case List.Setup_CompanyDetails_Currency: str = "Set_CD_Currency.aspx"; break;
				case List.Setup_CompanyDetails_Division: str = "Set_CD_Division.aspx"; break;
				case List.Setup_CompanyDetails_Product: str = "Set_CD_Product.aspx"; break;
				case List.Setup_CompanyDetails_Tax: str = "Set_CD_Tax.aspx"; break;
                case List.Setup_CompanyDetails_GlobalTax: str = "Set_CD_Global_Tax.aspx"; break;                    
				case List.Setup_CompanyDetails_Team: str = "Set_CD_Team.aspx"; break;
				case List.Setup_CompanyDetails_Terms: str = "Set_CD_Terms.aspx"; break;
				case List.Setup_CompanyDetails_User: str = "Set_CD_User.aspx"; break;
				case List.Setup_CompanyDetails_Warehouse: str = "Set_CD_Warehouse.aspx"; break;
				case List.Setup_CompanyDetails_SourcingLinks: str = "Set_CD_SourcingLinks.aspx"; break;
				case List.Setup_CompanyDetails_SequenceNumber: str = "Set_CD_SeqNumber.aspx"; break;
				case List.Setup_CompanyDetails_ShippingMethod: str = "Set_CD_ShipMethod.aspx"; break;
				case List.Setup_CompanyDetails_MailGroups: str = "Set_CD_MailGroups.aspx"; break;
				case List.Setup_CompanyDetails_PrintedDocuments: str = "Set_CD_PrintedDocuments.aspx"; break;
				case List.Setup_CompanyDetails_ApplicationSettings: str = "Set_CD_AppSettings.aspx"; break;
				case List.Setup_GlobalSettings_Package: str = "Set_GS_Package.aspx"; break;
				case List.Setup_GlobalSettings_MasterCurrencyList: str = "Set_GS_MstCurrencyList.aspx"; break;
				case List.Setup_GlobalSettings_Reason: str = "Set_GS_Reason.aspx"; break;
                case List.Setup_GlobalSettings_EightDCode:str="Set_GS_EightDCode.aspx";break;                
				case List.Setup_GlobalSettings_ProductType: str = "Set_GS_ProductType.aspx"; break;
				case List.Setup_GlobalSettings_CommunicationLogType: str = "Set_GS_CommunicationLogType.aspx"; break;
				case List.Setup_GlobalSettings_CompanyType: str = "Set_GS_CompanyType.aspx"; break;
				case List.Setup_GlobalSettings_IndustryType: str = "Set_GS_IndustryType.aspx"; break;
				case List.Setup_GlobalSettings_MasterCountryList: str = "Set_GS_MstCountryList.aspx"; break;
				case List.Setup_CompanyDetails_StockLogReason: str = "Set_CD_StockLogReason.aspx"; break;
				case List.Setup_GlobalSettings_CountingMethod: str = "Set_GS_CountingMethod.aspx"; break;
				case List.Setup_GlobalSettings_ApplicationSettings: str = "Set_GS_AppSettings.aspx"; break;
				case List.Setup_GlobalSettings_Incoterm: str = "Set_GS_Incoterm.aspx"; break;
				case List.Setup_Security_Groups: str = "Set_Sec_Groups.aspx"; break;
				case List.Setup_Security_Users: str = "Set_Sec_Users.aspx"; break;
				case List.OverallSetup_Home: str = "Setup/Default.aspx"; break;
				case List.OverallSetup_InitialSetup: str = "Setup/InitialSetup.aspx"; break;
				case List.OverallSetup_AddCompany: str = "Setup/AddCompany.aspx"; break;
				case List.OverallSetup_AppSettings: str = "Setup/AppSettings.aspx"; break;
				case List.OverallSetup_DatabaseSettings: str = "Setup/DatabaseSettings.aspx"; break;
				case List.OverallSetup_DisableCompany: str = "Setup/DisableCompany.aspx"; break;
				case List.OverallSetup_EmailSettings: str = "Setup/EmailSettings.aspx"; break;
				case List.OverallSetup_Sessions: str = "Setup/Sessions.aspx"; break;
                case List.Setup_GlobalSettings_InvoiceSetting: str = "Set_GS_InvoiceSetting.aspx"; break;
                case List.Setup_GlobalSettings_Product: str = "Set_GS_Products.aspx"; break;
			}
			return str;
		}

		public static List GetPageEnumerationFromURL(string strPage) {
				List enm = List.None;
				switch (strPage) {
				case "Default.aspx": enm = List.Home; break;
				case "Login.aspx": enm = List.Login; break;
				case "Logout.aspx": enm = List.Logout; break;
				case "NotFound.aspx": enm = List.NotFound; break;
				case "Help.aspx": enm = List.Help; break;
				case "Error.aspx": enm = List.Error; break;
				case "Feedback.aspx": enm = List.Feedback; break;
				case "Contact.aspx": enm = List.Contact; break;
                //[002]Code Start 
                case "SaleCalculator.html": enm = List.SalesCalc; break;
                //[002]Code end 
				case "Con_CompanyBrowse.aspx": enm = List.Contact_CompanyBrowse; break;
                case "CSV_Import.aspx": enm = List.CSV_Import; break;
				case "Con_CompanyAdd.aspx": enm = List.Contact_CompanyAdd; break;
				case "Con_CompanyDetail.aspx": enm = List.Contact_CompanyDetail; break;
				case "Con_ContactBrowse.aspx": enm = List.Contact_ContactBrowse; break;
				case "Con_ContactDetail.aspx": enm = List.Contact_ContactDetail; break;
				case "Con_ManufacturerBrowse.aspx": enm = List.Contact_ManufacturerBrowse; break;
				case "Con_ManufacturerDetail.aspx": enm = List.Contact_ManufacturerDetail; break;
				case "Con_ManufacturerAdd.aspx": enm = List.Contact_ManufacturerAdd; break;
				case "Orders.aspx": enm = List.Orders; break;
				case "Ord_Sourcing.aspx": enm = List.Orders_Sourcing; break;
				case "Ord_CusReqBrowse.aspx": enm = List.Orders_CustomerRequirementBrowse; break;
				case "Ord_CusReqDetail.aspx": enm = List.Orders_CustomerRequirementDetail; break;
				case "Ord_CusReqAdd.aspx": enm = List.Orders_CustomerRequirementAdd; break;
				case "Ord_QuoteBrowse.aspx": enm = List.Orders_QuoteBrowse; break;
				case "Ord_QuoteDetail.aspx": enm = List.Orders_QuoteDetail; break;
				case "Ord_QuoteAdd.aspx": enm = List.Orders_QuoteAdd; break;
				case "Ord_SOBrowse.aspx": enm = List.Orders_SalesOrderBrowse; break;
				case "Ord_SODetail.aspx": enm = List.Orders_SalesOrderDetail; break;
				case "Ord_SOAdd.aspx": enm = List.Orders_SalesOrderAdd; break;
				case "Ord_InvoiceBrowse.aspx": enm = List.Orders_InvoiceBrowse; break;
				case "Ord_InvoiceDetail.aspx": enm = List.Orders_InvoiceDetail; break;
				case "Ord_InvoiceAdd.aspx": enm = List.Orders_InvoiceAdd; break;
				case "Ord_InvoiceBulkPrint.aspx": enm = List.Orders_InvoiceBulkPrint; break;
                //Added new on 6th Apr 2016 for new development
                case "Ord_ClientInvoiceBrowse.aspx": enm = List.Orders_ClientInvoiceBrowse; break;
                case "Ord_ClientInvoiceDetail.aspx": enm = List.Orders_ClientInvoiceDetail; break;
                        //End
				case "Ord_POBrowse.aspx": enm = List.Orders_PurchaseOrderBrowse; break;
				case "Ord_PODetail.aspx": enm = List.Orders_PurchaseOrderDetail; break;
				case "Ord_POAdd.aspx": enm = List.Orders_PurchaseOrderAdd; break;
				case "Ord_PurReqBrowse.aspx": enm = List.Orders_PurchaseRequisitionBrowse; break;
				case "Ord_PurReqDetail.aspx": enm = List.Orders_PurchaseRequisitionDetail; break;
				case "Ord_CRMABrowse.aspx": enm = List.Orders_CustomerRMABrowse; break;
				case "Ord_CRMADetail.aspx": enm = List.Orders_CustomerRMADetail; break;
				case "Ord_CRMAAdd.aspx": enm = List.Orders_CustomerRMAAdd; break;
				case "Ord_SRMABrowse.aspx": enm = List.Orders_SupplierRMABrowse; break;
				case "Ord_SRMADetail.aspx": enm = List.Orders_SupplierRMADetail; break;
				case "Ord_SRMAAdd.aspx": enm = List.Orders_SupplierRMAAdd; break;
				case "Ord_CreditNoteBrowse.aspx": enm = List.Orders_CreditNoteBrowse; break;
				case "Ord_CreditNoteDetail.aspx": enm = List.Orders_CreditNoteDetail; break;
				case "Ord_CreditNoteAdd.aspx": enm = List.Orders_CreditNoteAdd; break;
				case "Ord_DebitNoteBrowse.aspx": enm = List.Orders_DebitNoteBrowse; break;
				case "Ord_DebitNoteDetail.aspx": enm = List.Orders_DebitNoteDetail; break;
				case "Ord_DebitNoteAdd.aspx": enm = List.Orders_DebitNoteAdd; break;
                case "Ord_BOMBrowse.aspx": enm = List.Orders_BOMBrowse; break;
                case "Ord_BOMAdd.aspx": enm = List.Orders_BOMAdd; break;
                case "Ord_BOMDetail.aspx": enm = List.Orders_BOMDetail; break;
                case "Ord_ATMIPOBOM.aspx": enm = List.Orders_ATMIPOBOM; break;
                case "Ord_ClientInvoiceAdd.aspx": enm = List.Orders_ClientInvoiceAdd; break;
				case "Warehouse.aspx": enm = List.Warehouse; break;
				case "Whs_ReceivePOBrowse.aspx": enm = List.Warehouse_ReceivePurchaseOrderBrowse; break;
				case "Whs_ReceivePODetail.aspx": enm = List.Warehouse_ReceivePurchaseOrderDetail; break;
				case "Whs_ShipSOBrowse.aspx": enm = List.Warehouse_ShipSalesOrderBrowse; break;
				case "Whs_ShipSODetail.aspx": enm = List.Warehouse_ShipSalesOrderDetail; break;
				case "Whs_ReceiveCRMABrowse.aspx": enm = List.Warehouse_ReceiveCustomerRMABrowse; break;
				case "Whs_ReceiveCRMADetail.aspx": enm = List.Warehouse_ReceiveCustomerRMADetail; break;
				case "Whs_ShipSRMABrowse.aspx": enm = List.Warehouse_ShipSupplierRMABrowse; break;
				case "Whs_ShipSRMADetail.aspx": enm = List.Warehouse_ShipSupplierRMADetail; break;
				case "Whs_StockBrowse.aspx": enm = List.Warehouse_StockBrowse; break;
				case "Whs_StockDetail.aspx": enm = List.Warehouse_StockDetail; break;
				case "Whs_StockAdd.aspx": enm = List.Warehouse_StockAdd; break;
				case "Whs_ServiceBrowse.aspx": enm = List.Warehouse_ServicesBrowse; break;
				case "Whs_ServiceDetail.aspx": enm = List.Warehouse_ServicesDetail; break;
				case "Whs_ServiceAdd.aspx": enm = List.Warehouse_ServicesAdd; break;
				case "Whs_LotBrowse.aspx": enm = List.Warehouse_LotsBrowse; break;
				case "Whs_LotDetail.aspx": enm = List.Warehouse_LotsDetail; break;
				case "Whs_LotAdd.aspx": enm = List.Warehouse_LotsAdd; break;
				case "Whs_GIBrowse.aspx": enm = List.Warehouse_GoodsInBrowse; break;
				case "Whs_GIDetail.aspx": enm = List.Warehouse_GoodsInDetail; break;
				case "Whs_GIAdd.aspx": enm = List.Warehouse_GoodsInAdd; break;
				case "Profile.aspx": enm = List.Profile; break;
				case "Prf_ProfileEdit.aspx": enm = List.Profile_Edit; break;
				case "Prf_MailMessages.aspx": enm = List.Profile_MailMessages; break;
				case "Prf_ToDo.aspx": enm = List.Profile_ToDo; break;
				case "Prf_MailMessageGroups.aspx": enm = List.Profile_MailMessageGroups; break;
				case "Reports.aspx": enm = List.Reports; break;
				case "Rpt_ReportDetail.aspx": enm = List.Reports_ReportDetail; break;
				case "Setup.aspx": enm = List.Setup; break;
				case "Set_CD_Country.aspx": enm = List.Setup_CompanyDetails_Country; break;
				case "Set_CD_Currency.aspx": enm = List.Setup_CompanyDetails_Currency; break;
				case "Set_CD_Division.aspx": enm = List.Setup_CompanyDetails_Division; break;
				case "Set_CD_Product.aspx": enm = List.Setup_CompanyDetails_Product; break;
				case "Set_CD_Tax.aspx": enm = List.Setup_CompanyDetails_Tax; break;
                case "Set_CD_Global_Tax.aspx": enm = List.Setup_CompanyDetails_GlobalTax; break;
				case "Set_CD_Team.aspx": enm = List.Setup_CompanyDetails_Team; break;
				case "Set_CD_Terms.aspx": enm = List.Setup_CompanyDetails_Terms; break;
				case "Set_CD_User.aspx": enm = List.Setup_CompanyDetails_User; break;
				case "Set_CD_Warehouse.aspx": enm = List.Setup_CompanyDetails_Warehouse; break;
				case "Set_CD_SourcingLinks.aspx": enm = List.Setup_CompanyDetails_SourcingLinks; break;
				case "Set_CD_SeqNumber.aspx": enm = List.Setup_CompanyDetails_SequenceNumber; break;
				case "Set_CD_ShipMethod.aspx": enm = List.Setup_CompanyDetails_ShippingMethod; break;
				case "Set_CD_MailGroups.aspx": enm = List.Setup_CompanyDetails_MailGroups; break;
				case "Set_CD_PrintedDocuments.aspx": enm = List.Setup_CompanyDetails_PrintedDocuments; break;
				case "Set_CD_AppSettings.aspx": enm = List.Setup_CompanyDetails_ApplicationSettings; break;
				case "Set_GS_Package.aspx": enm = List.Setup_GlobalSettings_Package; break;
				case "Set_GS_MstCurrencyList.aspx": enm = List.Setup_GlobalSettings_MasterCurrencyList; break;
				case "Set_GS_Reason.aspx": enm = List.Setup_GlobalSettings_Reason; break;
                case "Set_GS_EightDCode.aspx": enm = List.Setup_GlobalSettings_EightDCode; break;
				case "Set_GS_ProductType.aspx": enm = List.Setup_GlobalSettings_ProductType; break;
				case "Set_GS_CommunicationLogType.aspx": enm = List.Setup_GlobalSettings_CommunicationLogType; break;
				case "Set_GS_CompanyType.aspx": enm = List.Setup_GlobalSettings_CompanyType; break;
				case "Set_GS_IndustryType.aspx": enm = List.Setup_GlobalSettings_IndustryType; break;
				case "Set_GS_MstCountryList.aspx": enm = List.Setup_GlobalSettings_MasterCountryList; break;
				case "Set_CD_StockLogReason.aspx": enm = List.Setup_CompanyDetails_StockLogReason; break;
				case "Set_GS_CountingMethod.aspx": enm = List.Setup_GlobalSettings_CountingMethod; break;
				case "Set_GS_AppSettings.aspx": enm = List.Setup_GlobalSettings_ApplicationSettings; break;
				case "Set_GS_Incoterm.aspx": enm = List.Setup_GlobalSettings_Incoterm; break;
				case "Set_Sec_Groups.aspx": enm = List.Setup_Security_Groups; break;
				case "Set_Sec_Users.aspx": enm = List.Setup_Security_Users; break;
				case "Setup/Default.aspx": enm = List.OverallSetup_Home; break;
				case "Setup/InitialSetup.aspx": enm = List.OverallSetup_InitialSetup; break;
				case "Setup/AddCompany.aspx": enm = List.OverallSetup_AddCompany; break;
				case "Setup/AppSettings.aspx": enm = List.OverallSetup_AppSettings; break;
				case "Setup/DatabaseSettings.aspx": enm = List.OverallSetup_DatabaseSettings; break;
				case "Setup/DisableCompany.aspx": enm = List.OverallSetup_DisableCompany; break;
				case "Setup/EmailSettings.aspx": enm = List.OverallSetup_EmailSettings; break;
				case "Setup/Sessions.aspx": enm = List.OverallSetup_Sessions; break;
                case "Set_GS_Products.aspx": enm = List.Setup_GlobalSettings_Product; break;
			}
			return enm;
		}
	

		
	}
}
