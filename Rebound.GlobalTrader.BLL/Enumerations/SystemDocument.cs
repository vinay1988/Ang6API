/*
Marker     changed by      date         Remarks
[001]      Vinay           18/06/2012   This need to implement NPR Report
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
    public partial class SystemDocument {
		/// <summary>
		/// An enum representation of the 'tbSystemDocument' table.
		/// </summary>
		/// <remark>This enumeration contains the items contained in the table tbSystemDocument</remark>
		[Serializable]
		public enum List {
			CustomerRequirement = 1, 
			SalesOrder = 2, 
			PurchaseOrder = 3, 
			Quote = 4, 
			Invoice = 5, 
			CustomerRMA = 6, 
			SupplierRMA = 7, 
			PurchaseRequisition = 8, 
			CreditNote = 9, 
			DebitNote = 10, 
			GoodsIn = 11, 
			SupplierRMAShipment = 12, 
			ProFormaInvoice = 13, 
			PackingSlip = 14, 
			ReceivingDocket = 15, 
			SOReport = 16, 
			CertificateOfConformance = 17, 
			ProFormaReceivingDocket = 18,
            SupplierInvoice=19,
            InternalPurchaseOrder=25,
            PurchaseQuote = 26,
            ClientInvoice=27,
            ConsolidatePrintSO=28,
            ConsolidateEmailSO=29,
          
		}		

	

		

		/// <summary>
		/// ForPrint
		/// </summary>
		/// <remark>This enumeration contains the items contained in the table tbSystemDocument</remark>
		[Serializable]
		public enum ListForPrint {
			SalesOrder = 2, 
			PurchaseOrder = 3, 
			Quote = 4, 
			Invoice = 5, 
			CustomerRMA = 6, 
			SupplierRMA = 7, 
			CreditNote = 9, 
			DebitNote = 10, 
			GoodsIn = 11, 
			ProFormaInvoice = 13, 
			PackingSlip = 14, 
			ReceivingDocket = 15, 
			SOReport = 16, 
			CertificateOfConformance = 17, 
			ProFormaReceivingDocket = 18,
            //[001] code start
            ReportNPR = 19,
            //[001] code end
            ReportNPRLog=20,
            AS9120=21,
            CommercialInvoice=22,
            InvoiceWithCocf=23,
            ReportEPRLog = 24,
            DownLoadExcel = 25,
            CustomerRequirement=26,
            SingleRequirement=27,
            PackingSlipWithCocf=28,
            PurchaseOrderEmail=29,
            DownLoadPOQuoteCSV = 30,
            DownLoadBOMCSV = 31,
            ClientInvoice = 32,
            PurchaseOrderReport=33,
            PrintHUBSRMA=34,
            EmailHUBSRMA=35,
            PrintHUBDebit = 36,
            EmailHUBDebit = 37,
            InternalPurchaseOrder=38,
            ConsolidatePrintSO=39,
            ConsolidateEmailSO=40,
            PrintHUBRFQ=41,
            EmailHUBRFQ=42,
            ProFormaInvoiceCon = 43,
            QuoteEmail = 44,
            CREmail = 45,
            DBEmail = 46,
            EmailHUBDebitHtml = 47,
            PrintLog = 48
		}

		/// <summary>
		/// ForPrint
		/// </summary>
		/// <remark>This enumeration contains the items contained in the table tbSystemDocument</remark>
		[Serializable]
		public enum ListForSequencer {
			CustomerRequirement = 1, 
			SalesOrder = 2, 
			PurchaseOrder = 3, 
			Quote = 4, 
			Invoice = 5, 
			CustomerRMA = 6, 
			SupplierRMA = 7, 
			CreditNote = 9, 
			DebitNote = 10, 
			GoodsIn = 11, 
           
		}


        [Serializable]
        public enum FooterDocument
        {
            PrintHazardous = 26

        }
	}
}
