/*
Marker     Changed by      Date         Remarks
[001]      Pankaj Kumar    05/09/20011  ESMS Ref:13 - Added properties CompanyRegNo, include this in GetForPrint methods
[002]      Vinay  Kumar    17/05/2012   This need to add Currency notes
[003]      Vinay           13/07/2012   Rebound- Invoice bulk Emailer
[004]      Vinay           23/08/2012   Customize the invoice control for exported record, Set Exported=1
[005]      Vinay           21/09/2012   Add expoted only filter
[006]      Vinay           12/10/2012   Upload PDF document for invoices
[007]      Vinay           01/11/2012   Add comma(,) seprated credit notes and CustomerRMA in invoice section
[008]      Vinay           22/11/2012   Add Failed only  filter
[009]      Vinay           29/11/2012   Apply a bank fee charge to the customers final invoice  
[010]      Aashu           01/06/2018   Quick Jump in Global Warehouse
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
using Rebound.GlobalTrader.DAL;
using Rebound.GlobalTrader.BLL;

namespace Rebound.GlobalTrader.BLL {
		public partial class Invoice : BizObject {
		
		#region Properties

		protected static DAL.InvoiceElement Settings {
			get { return Globals.Settings.Invoices; }
		}

		/// <summary>
		/// InvoiceId
		/// </summary>
		public System.Int32 InvoiceId { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// InvoiceNumber
		/// </summary>
		public System.Int32 InvoiceNumber { get; set; }		
		/// <summary>
		/// SalesOrderNo
		/// </summary>
		public System.Int32? SalesOrderNo { get; set; }		
		/// <summary>
		/// InvoiceDate
		/// </summary>
		public System.DateTime InvoiceDate { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// Instructions
		/// </summary>
		public System.String Instructions { get; set; }		
		/// <summary>
		/// CompanyBillTo
		/// </summary>
		public System.String CompanyBillTo { get; set; }		
		/// <summary>
		/// CompanyShipTo
		/// </summary>
		public System.String CompanyShipTo { get; set; }		
		/// <summary>
		/// ShipViaNo
		/// </summary>
		public System.Int32 ShipViaNo { get; set; }		
		/// <summary>
		/// Account
		/// </summary>
		public System.String Account { get; set; }		
		/// <summary>
		/// ShippingCost
		/// </summary>
		public System.Double? ShippingCost { get; set; }		
		/// <summary>
		/// Freight
		/// </summary>
		public System.Double? Freight { get; set; }		
		/// <summary>
		/// FreeOnBoard
		/// </summary>
		public System.String FreeOnBoard { get; set; }		
		/// <summary>
		/// Boxes
		/// </summary>
		public System.Int32? Boxes { get; set; }		
		/// <summary>
		/// Weight
		/// </summary>
		public System.Double? Weight { get; set; }		
		/// <summary>
		/// DimensionalWeight
		/// </summary>
		public System.Double? DimensionalWeight { get; set; }		
		/// <summary>
		/// WeightInPounds
		/// </summary>
		public System.Boolean WeightInPounds { get; set; }		
		/// <summary>
		/// AirWayBill
		/// </summary>
		public System.String AirWayBill { get; set; }		
		/// <summary>
		/// ShippedBy
		/// </summary>
		public System.Int32? ShippedBy { get; set; }		
		/// <summary>
		/// Printed
		/// </summary>
		public System.Int32? Printed { get; set; }		
		/// <summary>
		/// SupplierRMANo
		/// </summary>
		public System.Int32? SupplierRMANo { get; set; }		
		/// <summary>
		/// ShippingNotes
		/// </summary>
		public System.String ShippingNotes { get; set; }		
		/// <summary>
		/// Exported
		/// </summary>
		public System.Boolean Exported { get; set; }		
		/// <summary>
		/// InvoicePaid
		/// </summary>
		public System.Boolean InvoicePaid { get; set; }		
		/// <summary>
		/// Salesman2
		/// </summary>
		public System.Int32? Salesman2 { get; set; }		
		/// <summary>
		/// Salesman2Percent
		/// </summary>
		public System.Double Salesman2Percent { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// CustomerPO
		/// </summary>
		public System.String CustomerPO { get; set; }		
		/// <summary>
		/// Salesman
		/// </summary>
		public System.Int32? Salesman { get; set; }		
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32? CompanyNo { get; set; }		
		/// <summary>
		/// ContactNo
		/// </summary>
		public System.Int32? ContactNo { get; set; }		
		/// <summary>
		/// CurrencyNo
		/// </summary>
		public System.Int32? CurrencyNo { get; set; }		
		/// <summary>
		/// TermsNo
		/// </summary>
		public System.Int32? TermsNo { get; set; }		
		/// <summary>
		/// TaxNo
		/// </summary>
		public System.Int32? TaxNo { get; set; }		
		/// <summary>
		/// ShipToAddressNo
		/// </summary>
		public System.Int32? ShipToAddressNo { get; set; }		
		/// <summary>
		/// DivisionNo
		/// </summary>
		public System.Int32? DivisionNo { get; set; }		
		/// <summary>
		/// SalesOrderNumber
		/// </summary>
		public System.Int32? SalesOrderNumber { get; set; }		
		/// <summary>
		/// DateOrdered
		/// </summary>
		public System.DateTime? DateOrdered { get; set; }		
		/// <summary>
		/// CofCNotes
		/// </summary>
		public System.String CofCNotes { get; set; }		
		/// <summary>
		/// BillToAddressNo
		/// </summary>
		public System.Int32? BillToAddressNo { get; set; }		
		/// <summary>
		/// IncotermNo
		/// </summary>
		public System.Int32? IncotermNo { get; set; }		
		/// <summary>
		/// DivisionNo2
		/// </summary>
		public System.Int32? DivisionNo2 { get; set; }		
		/// <summary>
		/// DateExported
		/// </summary>
		public System.DateTime? DateExported { get; set; }		
		/// <summary>
		/// CompanyName
		/// </summary>
		public System.String CompanyName { get; set; }		
		/// <summary>
		/// SalesmanName
		/// </summary>
		public System.String SalesmanName { get; set; }		
		/// <summary>
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }		
		/// <summary>
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }		
		/// <summary>
		/// SupplierRMANumber
		/// </summary>
		public System.Int32? SupplierRMANumber { get; set; }		
		/// <summary>
		/// ContactName
		/// </summary>
		public System.String ContactName { get; set; }		
		/// <summary>
		/// CustomerCode
		/// </summary>
		public System.String CustomerCode { get; set; }		
		/// <summary>
		/// CurrencyDescription
		/// </summary>
		public System.String CurrencyDescription { get; set; }		
		/// <summary>
		/// Salesman2Name
		/// </summary>
		public System.String Salesman2Name { get; set; }		
		/// <summary>
		/// TermsName
		/// </summary>
		public System.String TermsName { get; set; }		
		/// <summary>
		/// ShippedByName
		/// </summary>
		public System.String ShippedByName { get; set; }		
		/// <summary>
		/// DivisionName
		/// </summary>
		public System.String DivisionName { get; set; }		
		/// <summary>
		/// TeamNo
		/// </summary>
		public System.Int32? TeamNo { get; set; }		
		/// <summary>
		/// TaxName
		/// </summary>
		public System.String TaxName { get; set; }		
		/// <summary>
		/// VATNo
		/// </summary>
		public System.String VATNo { get; set; }		
		/// <summary>
		/// ShipViaName
		/// </summary>
		public System.String ShipViaName { get; set; }		
		/// <summary>
		/// InvoiceValue
		/// </summary>
		public System.Double? InvoiceValue { get; set; }		
		/// <summary>
		/// LandedCostValue
		/// </summary>
		public System.Double? LandedCostValue { get; set; }		
		/// <summary>
		/// TaxRate
		/// </summary>
		public System.Double? TaxRate { get; set; }		
		/// <summary>
		/// StatusText
		/// </summary>
		public System.String StatusText { get; set; }		
		/// <summary>
		/// IncotermName
		/// </summary>
		public System.String IncotermName { get; set; }		
		/// <summary>
		/// RowCnt
		/// </summary>
		public System.Int32? RowCnt { get; set; }		
		/// <summary>
		/// CompanyTelephone
		/// </summary>
		public System.String CompanyTelephone { get; set; }		
		/// <summary>
		/// CompanyFax
		/// </summary>
		public System.String CompanyFax { get; set; }		
		/// <summary>
		/// ContactEmail
		/// </summary>
		public System.String ContactEmail { get; set; }		
		/// <summary>
		/// PrintNotes
		/// </summary>
		public System.String PrintNotes { get; set; }

        //[001] Code Start
        /// <summary>
		/// Company Registration No
		/// </summary>
        public System.String CompanyRegNo { get; set; }
        //[001] Code End

        /// <summary>
        /// SalesOrderNo(From tbInvoiceLine) separated by commas        
        /// </summary>
        public string SalesOrderNOs { get; set; }

        /// <summary>
        /// SalesOrderNumber(From tbInvoiceLine) separated by commas        
        /// </summary>
        public string SalesOrderNumbers { get; set; }
        //[002] code start
        /// <summary>
        /// Currency Notes
        /// </summary>
        public string CurrencyNotes { get; set; }
        //[002] code end
        //[006] code start
        /// <summary>
        /// IsPDFAvailable
        /// </summary>
        public System.Boolean? IsPDFAvailable { get; set; }
        //[006] code end

        //[007] code start
        public System.String CRMAIds { get; set; }
        public System.String CRMANumbers { get; set; }
        public System.String CreditIds { get; set; }
        public System.String CreditNumbers { get; set; }
        //[007] code end
        //[009] code start
        public System.Double? InvoiceBankFee { get; set; }
        public System.Boolean? IsApplyBankFee { get; set; }
        //[009] code end

        /// <summary>
        /// ExchangeRate
        /// </summary>
        public System.Double? ExchangeRate { get; set; }
        /// <summary>
        /// LocalCurrencyNo
        /// </summary>
        public System.Int32? LocalCurrencyNo { get; set; }
        /// <summary>
        /// ApplyLocalCurrency
        /// </summary>
        public System.Boolean? ApplyLocalCurrency { get; set; }
        /// <summary>
        /// LocalCurrencyCode
        /// </summary>
        public System.String LocalCurrencyCode { get; set; }
        /// <summary>
        /// InvoicePaidDate
        /// </summary>
        public System.DateTime? InvoicePaidDate { get; set; }
        /// <summary>
        /// ShipToVatNo
        /// </summary>
        public System.String ShipToVatNo { get; set; }
        /// <summary>
        /// IsSameAsShipCost
        /// </summary>
        public System.Boolean? IsSameAsShipCost { get; set; }
        /// <summary>
        /// ShippingSurchargeValue
        /// </summary>
        public System.Double? ShippingSurchargeValue { get; set; }

        public System.String NotesToInvoice { get; set; }
        public System.String ClientName { get; set; }
        public System.String SerialNo { get; set; }
        public System.Int32? SerialNoId { get; set; }
        public System.String SubGroup { get; set; }
        public System.Int32? GoodsInNo { get; set; }
        public System.String SerialInvoice { get; set; }

        //[010] start
        /// <summary>
        /// InvoiceDetail
        /// </summary>
        public System.String InvoiceDetail { get; set; }
        //[010] end
		#endregion
		
		#region Methods
		
		/// <summary>
		/// CountForClient
		/// Calls [usp_count_Invoice_for_Client]
		/// </summary>
		public static Int32 CountForClient(System.Int32? clientId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Invoice.CountForClient(clientId);
		}		/// <summary>
		/// CountForCompany
		/// Calls [usp_count_Invoice_for_Company]
		/// </summary>
		public static Int32 CountForCompany(System.Int32? companyId, System.Boolean? includePaid) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Invoice.CountForCompany(companyId, includePaid);
		}		/// <summary>
		/// CountOpenForCompany
		/// Calls [usp_count_Invoice_Open_for_Company]
		/// </summary>
		public static Int32 CountOpenForCompany(System.Int32? companyId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Invoice.CountOpenForCompany(companyId);
		}
		//[005],[008] code start
        /// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_Invoice]
		/// </summary>
		public static List<Invoice> DataListNugget(System.Int32? clientId, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? orderBy, System.Int32? sortDir, System.String cmSearch, System.Int32? salesmanSearch, System.String customerPoSearch, System.Boolean? includePaid, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? invoiceDateFrom, System.DateTime? invoiceDateTo, System.Boolean? recentOnly,System.Boolean? exportedOnly,System.Boolean? failedOnly,System.Boolean? notExported) {
            List<InvoiceDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Invoice.DataListNugget(clientId, pageIndex, pageSize, orderBy, sortDir, cmSearch, salesmanSearch, customerPoSearch, includePaid, invoiceNoLo, invoiceNoHi, salesOrderNoLo, salesOrderNoHi, invoiceDateFrom, invoiceDateTo, recentOnly, exportedOnly, failedOnly, notExported);
			if (lstDetails == null) {
				return new List<Invoice>();
			} else {
				List<Invoice> lst = new List<Invoice>();
				foreach (InvoiceDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Invoice obj = new Rebound.GlobalTrader.BLL.Invoice();
					obj.InvoiceId = objDetails.InvoiceId;
					obj.InvoiceDate = objDetails.InvoiceDate;
					obj.InvoicePaid = objDetails.InvoicePaid;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.SalesOrderNo = objDetails.SalesOrderNo;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.CustomerPO = objDetails.CustomerPO;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.Salesman = objDetails.Salesman;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.RowNum = objDetails.RowNum;
					obj.InvoiceId = objDetails.InvoiceId;
					obj.ClientNo = objDetails.ClientNo;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.SalesOrderNo = objDetails.SalesOrderNo;
					obj.InvoiceDate = objDetails.InvoiceDate;
					obj.Notes = objDetails.Notes;
					obj.Instructions = objDetails.Instructions;
					obj.CompanyShipTo = objDetails.CompanyShipTo;
					obj.CompanyBillTo = objDetails.CompanyBillTo;
					obj.ShipViaNo = objDetails.ShipViaNo;
					obj.Account = objDetails.Account;
					obj.ShippingCost = objDetails.ShippingCost;
					obj.Freight = objDetails.Freight;
					obj.FreeOnBoard = objDetails.FreeOnBoard;
					obj.Boxes = objDetails.Boxes;
					obj.Weight = objDetails.Weight;
					obj.DimensionalWeight = objDetails.DimensionalWeight;
					obj.WeightInPounds = objDetails.WeightInPounds;
					obj.AirWayBill = objDetails.AirWayBill;
					obj.ShippedBy = objDetails.ShippedBy;
					obj.Printed = objDetails.Printed;
					obj.SupplierRMANo = objDetails.SupplierRMANo;
					obj.SupplierRMANumber = objDetails.SupplierRMANumber;
					obj.ShippingNotes = objDetails.ShippingNotes;
					obj.Exported = objDetails.Exported;
					obj.InvoicePaid = objDetails.InvoicePaid;
					obj.Salesman2 = objDetails.Salesman2;
					obj.Salesman2Percent = objDetails.Salesman2Percent;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.CustomerCode = objDetails.CustomerCode;
					obj.CurrencyNo = objDetails.CurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.Salesman2Name = objDetails.Salesman2Name;
					obj.TermsNo = objDetails.TermsNo;
					obj.TermsName = objDetails.TermsName;
					obj.Salesman = objDetails.Salesman;
					obj.ShippedByName = objDetails.ShippedByName;
					obj.DivisionNo = objDetails.DivisionNo;
					obj.DivisionName = objDetails.DivisionName;
					obj.TeamNo = objDetails.TeamNo;
					obj.TaxNo = objDetails.TaxNo;
					obj.TaxName = objDetails.TaxName;
					obj.VATNo = objDetails.VATNo;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.ShipViaName = objDetails.ShipViaName;
					obj.CustomerPO = objDetails.CustomerPO;
					obj.InvoiceValue = objDetails.InvoiceValue;
					obj.LandedCostValue = objDetails.LandedCostValue;
					obj.TaxRate = objDetails.TaxRate;
					obj.StatusText = objDetails.StatusText;
					obj.ShipToAddressNo = objDetails.ShipToAddressNo;
					obj.CofCNotes = objDetails.CofCNotes;
					obj.BillToAddressNo = objDetails.BillToAddressNo;
					obj.IncotermNo = objDetails.IncotermNo;
					obj.IncotermName = objDetails.IncotermName;
					obj.RowCnt = objDetails.RowCnt;
					obj.InvoiceValue = objDetails.InvoiceValue;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
        //[005] code end
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Invoice]
		/// </summary>
		public static bool Delete(System.Int32? invoiceId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Invoice.Delete(invoiceId);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Invoice]
		/// </summary>
		public static Int32 Insert(System.Int32? clientNo, System.Int32? salesOrderNo, System.DateTime? invoiceDate, System.String notes, System.String instructions, System.Int32? shipViaNo, System.String account, System.Double? shippingCost, System.Double? freight, System.String freeOnBoard, System.Int32? boxes, System.Double? weight, System.Double? dimensionalWeight, System.Boolean? weightInPounds, System.String airWayBill, System.Int32? shippedBy, System.Int32? printed, System.Int32? supplierRmaNo, System.String shippingNotes, System.Boolean? exported, System.Boolean? invoicePaid, System.Int32? salesOrderNumber, System.Int32? companyNo, System.Int32? contactNo, System.DateTime? dateOrdered, System.Int32? currencyNo, System.Int32? salesman, System.Int32? termsNo, System.Int32? taxNo, System.Int32? billToAddressNo, System.String companyBillTo, System.Int32? shipToAddressNo, System.String companyShipTo, System.Int32? divisionNo, System.String customerPo, System.Int32? salesman2, System.Double? salesman2Percent, System.Int32? incotermNo, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Invoice.Insert(clientNo, salesOrderNo, invoiceDate, notes, instructions, shipViaNo, account, shippingCost, freight, freeOnBoard, boxes, weight, dimensionalWeight, weightInPounds, airWayBill, shippedBy, printed, supplierRmaNo, shippingNotes, exported, invoicePaid, salesOrderNumber, companyNo, contactNo, dateOrdered, currencyNo, salesman, termsNo, taxNo, billToAddressNo, companyBillTo, shipToAddressNo, companyShipTo, divisionNo, customerPo, salesman2, salesman2Percent, incotermNo, updatedBy);
			return objReturn;
		}
        //[003] code start
        public static List<System.String> InsertIntoInvoiceEmail(System.String Invoices, System.Int32? updatedBy,System.Boolean? blnCOC)
        {
            List<System.String> objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Invoice.InsertIntoInvoiceEmail(ParamsToXml(Invoices), updatedBy, blnCOC);
           return objReturn;
        }

        private static string ParamsToXml(string Invoices)
        {
            System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
            string[] ArrInvoice = Invoices.Split(',');
            strBuilder.Append("<Invoices>");
            if (ArrInvoice.Length > 0)
            {
                foreach (string str in ArrInvoice)
                {
                    strBuilder.Append("<Invoice>");
                    strBuilder.Append("<ID>");
                    strBuilder.Append(str);
                    strBuilder.Append("</ID>");
                    strBuilder.Append("</Invoice>");
                }
            }
            strBuilder.Append("</Invoices>");
            return strBuilder.ToString();
        }
        public static string GetEmailStatusByInvoiceEmailNo(System.Int32? InvoiceEmailNo)
        {
            string objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Invoice.GetEmailStatusByInvoiceEmailNo(InvoiceEmailNo);
            return objReturn;
        }
        //[003] code end
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Invoice]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Invoice.Insert(ClientNo, SalesOrderNo, InvoiceDate, Notes, Instructions, ShipViaNo, Account, ShippingCost, Freight, FreeOnBoard, Boxes, Weight, DimensionalWeight, WeightInPounds, AirWayBill, ShippedBy, Printed, SupplierRMANo, ShippingNotes, Exported, InvoicePaid, SalesOrderNumber, CompanyNo, ContactNo, DateOrdered, CurrencyNo, Salesman, TermsNo, TaxNo, BillToAddressNo, CompanyBillTo, ShipToAddressNo, CompanyShipTo, DivisionNo, CustomerPO, Salesman2, Salesman2Percent, IncotermNo, UpdatedBy);
		}
        //[004] code start
		/// <summary>
		/// ItemSearch
		/// Calls [usp_itemsearch_Invoice]
		/// </summary>
		public static List<Invoice> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String customerPoSearch, System.Boolean? includePaid, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? invoiceDateFrom, System.DateTime? invoiceDateTo,System.Int32? Exported) {
            List<InvoiceDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Invoice.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, contactSearch, cmSearch, salesmanSearch, customerPoSearch, includePaid, invoiceNoLo, invoiceNoHi, salesOrderNoLo, salesOrderNoHi, invoiceDateFrom, invoiceDateTo, Exported);
			if (lstDetails == null) {
				return new List<Invoice>();
			} else {
				List<Invoice> lst = new List<Invoice>();
				foreach (InvoiceDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Invoice obj = new Rebound.GlobalTrader.BLL.Invoice();
					obj.InvoiceId = objDetails.InvoiceId;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.InvoiceDate = objDetails.InvoiceDate;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.SalesmanName = objDetails.SalesmanName;
					obj.CustomerPO = objDetails.CustomerPO;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
        //[004] code end
		/// <summary>
		/// Get
		/// Calls [usp_select_Invoice]
		/// </summary>
		public static Invoice Get(System.Int32? invoiceId) {
			Rebound.GlobalTrader.DAL.InvoiceDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Invoice.Get(invoiceId);
			if (objDetails == null) {
				return null;
			} else {
				Invoice obj = new Invoice();
				obj.InvoiceId = objDetails.InvoiceId;
				obj.ClientNo = objDetails.ClientNo;
				obj.InvoiceNumber = objDetails.InvoiceNumber;
				obj.SalesOrderNo = objDetails.SalesOrderNo;
				obj.InvoiceDate = objDetails.InvoiceDate;
				obj.Notes = objDetails.Notes;
				obj.Instructions = objDetails.Instructions;
				obj.CompanyShipTo = objDetails.CompanyShipTo;
				obj.CompanyBillTo = objDetails.CompanyBillTo;
				obj.ShipViaNo = objDetails.ShipViaNo;
				obj.Account = objDetails.Account;
				obj.ShippingCost = objDetails.ShippingCost;
				obj.Freight = objDetails.Freight;
				obj.FreeOnBoard = objDetails.FreeOnBoard;
				obj.Boxes = objDetails.Boxes;
				obj.Weight = objDetails.Weight;
				obj.DimensionalWeight = objDetails.DimensionalWeight;
				obj.WeightInPounds = objDetails.WeightInPounds;
				obj.AirWayBill = objDetails.AirWayBill;
				obj.ShippedBy = objDetails.ShippedBy;
				obj.Printed = objDetails.Printed;
				obj.SupplierRMANo = objDetails.SupplierRMANo;
				obj.SupplierRMANumber = objDetails.SupplierRMANumber;
				obj.ShippingNotes = objDetails.ShippingNotes;
				obj.Exported = objDetails.Exported;
				obj.InvoicePaid = objDetails.InvoicePaid;
				obj.Salesman2 = objDetails.Salesman2;
				obj.Salesman2Percent = objDetails.Salesman2Percent;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.ContactNo = objDetails.ContactNo;
				obj.ContactName = objDetails.ContactName;
				obj.CustomerCode = objDetails.CustomerCode;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyDescription = objDetails.CurrencyDescription;
				obj.SalesmanName = objDetails.SalesmanName;
				obj.Salesman2Name = objDetails.Salesman2Name;
				obj.TermsNo = objDetails.TermsNo;
				obj.TermsName = objDetails.TermsName;
				obj.Salesman = objDetails.Salesman;
				obj.ShippedByName = objDetails.ShippedByName;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.DivisionName = objDetails.DivisionName;
				obj.TeamNo = objDetails.TeamNo;
				obj.TaxNo = objDetails.TaxNo;
				obj.TaxName = objDetails.TaxName;
				obj.VATNo = objDetails.VATNo;
				obj.SalesOrderNumber = objDetails.SalesOrderNumber;
				obj.ShipViaName = objDetails.ShipViaName;
				obj.CustomerPO = objDetails.CustomerPO;
				obj.InvoiceValue = objDetails.InvoiceValue;
				obj.LandedCostValue = objDetails.LandedCostValue;
				obj.TaxRate = objDetails.TaxRate;
				obj.StatusText = objDetails.StatusText;
				obj.ShipToAddressNo = objDetails.ShipToAddressNo;
				obj.CofCNotes = objDetails.CofCNotes;
				obj.BillToAddressNo = objDetails.BillToAddressNo;
				obj.IncotermNo = objDetails.IncotermNo;
				obj.IncotermName = objDetails.IncotermName;
                obj.SalesOrderNOs = objDetails.SalesOrderNOs;
                obj.SalesOrderNumbers = objDetails.SalesOrderNumbers;
                //[007] code start
                obj.CRMAIds = objDetails.CRMAIds;
                obj.CRMANumbers = objDetails.CRMANumbers;
                obj.CreditIds = objDetails.CreditIds;
                obj.CreditNumbers = objDetails.CreditNumbers;
                //[007] code end
                //[009] code start
                obj.InvoiceBankFee = objDetails.InvoiceBankFee;
                obj.IsApplyBankFee = objDetails.IsApplyBankFee;
                //[009] code end
                obj.ExchangeRate = objDetails.ExchangeRate;
                obj.InvoicePaidDate = objDetails.InvoicePaidDate;
                obj.IsSameAsShipCost = objDetails.IsSameAsShipCost;
                obj.ShippingSurchargeValue = objDetails.ShippingSurchargeValue;

				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetByNumber
		/// Calls [usp_select_Invoice_by_Number]
		/// </summary>
		public static Invoice GetByNumber(System.Int32? invoiceNumber, System.Int32? clientNo) {
			Rebound.GlobalTrader.DAL.InvoiceDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Invoice.GetByNumber(invoiceNumber, clientNo);
			if (objDetails == null) {
				return null;
			} else {
				Invoice obj = new Invoice();
				obj.InvoiceId = objDetails.InvoiceId;
				obj.ClientNo = objDetails.ClientNo;
				obj.InvoiceNumber = objDetails.InvoiceNumber;
				obj.SalesOrderNo = objDetails.SalesOrderNo;
				obj.InvoiceDate = objDetails.InvoiceDate;
				obj.Notes = objDetails.Notes;
				obj.Instructions = objDetails.Instructions;
				obj.CompanyShipTo = objDetails.CompanyShipTo;
				obj.CompanyBillTo = objDetails.CompanyBillTo;
				obj.ShipViaNo = objDetails.ShipViaNo;
				obj.Account = objDetails.Account;
				obj.ShippingCost = objDetails.ShippingCost;
				obj.Freight = objDetails.Freight;
				obj.FreeOnBoard = objDetails.FreeOnBoard;
				obj.Boxes = objDetails.Boxes;
				obj.Weight = objDetails.Weight;
				obj.DimensionalWeight = objDetails.DimensionalWeight;
				obj.WeightInPounds = objDetails.WeightInPounds;
				obj.AirWayBill = objDetails.AirWayBill;
				obj.ShippedBy = objDetails.ShippedBy;
				obj.Printed = objDetails.Printed;
				obj.SupplierRMANo = objDetails.SupplierRMANo;
				obj.SupplierRMANumber = objDetails.SupplierRMANumber;
				obj.ShippingNotes = objDetails.ShippingNotes;
				obj.Exported = objDetails.Exported;
				obj.InvoicePaid = objDetails.InvoicePaid;
				obj.Salesman2 = objDetails.Salesman2;
				obj.Salesman2Percent = objDetails.Salesman2Percent;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.ContactNo = objDetails.ContactNo;
				obj.ContactName = objDetails.ContactName;
				obj.CustomerCode = objDetails.CustomerCode;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyDescription = objDetails.CurrencyDescription;
				obj.SalesmanName = objDetails.SalesmanName;
				obj.Salesman2Name = objDetails.Salesman2Name;
				obj.TermsNo = objDetails.TermsNo;
				obj.TermsName = objDetails.TermsName;
				obj.Salesman = objDetails.Salesman;
				obj.ShippedByName = objDetails.ShippedByName;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.DivisionName = objDetails.DivisionName;
				obj.TeamNo = objDetails.TeamNo;
				obj.TaxNo = objDetails.TaxNo;
				obj.TaxName = objDetails.TaxName;
				obj.VATNo = objDetails.VATNo;
				obj.SalesOrderNumber = objDetails.SalesOrderNumber;
				obj.ShipViaName = objDetails.ShipViaName;
				obj.CustomerPO = objDetails.CustomerPO;
				obj.InvoiceValue = objDetails.InvoiceValue;
				obj.LandedCostValue = objDetails.LandedCostValue;
				obj.TaxRate = objDetails.TaxRate;
				obj.StatusText = objDetails.StatusText;
				obj.ShipToAddressNo = objDetails.ShipToAddressNo;
				obj.CofCNotes = objDetails.CofCNotes;
				obj.BillToAddressNo = objDetails.BillToAddressNo;
				obj.IncotermNo = objDetails.IncotermNo;
				obj.IncotermName = objDetails.IncotermName;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForPage
		/// Calls [usp_select_Invoice_for_Page]
		/// </summary>
		public static Invoice GetForPage(System.Int32? invoiceId) {
			Rebound.GlobalTrader.DAL.InvoiceDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Invoice.GetForPage(invoiceId);
			if (objDetails == null) {
				return null;
			} else {
				Invoice obj = new Invoice();
				obj.InvoiceId = objDetails.InvoiceId;
				obj.ClientNo = objDetails.ClientNo;
				obj.InvoiceNumber = objDetails.InvoiceNumber;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.StatusText = objDetails.StatusText;
                //[006] code start
                obj.IsPDFAvailable = objDetails.IsPDFAvailable;
                //[006] code end
                obj.TeamNo = objDetails.TeamNo;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.Salesman = objDetails.Salesman;
                obj.ClientName = objDetails.ClientName;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForPrint
		/// Calls [usp_select_Invoice_for_Print]
		/// </summary>
		public static Invoice GetForPrint(System.Int32? invoiceId) {
			Rebound.GlobalTrader.DAL.InvoiceDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Invoice.GetForPrint(invoiceId);
			if (objDetails == null) {
				return null;
			} else {
				Invoice obj = new Invoice();
				obj.InvoiceId = objDetails.InvoiceId;
				obj.ClientNo = objDetails.ClientNo;
				obj.InvoiceNumber = objDetails.InvoiceNumber;
				obj.SalesOrderNo = objDetails.SalesOrderNo;
				obj.InvoiceDate = objDetails.InvoiceDate;
				obj.Notes = objDetails.Notes;
				obj.Instructions = objDetails.Instructions;
				obj.CompanyShipTo = objDetails.CompanyShipTo;
				obj.CompanyBillTo = objDetails.CompanyBillTo;
				obj.ShipViaNo = objDetails.ShipViaNo;
				obj.Account = objDetails.Account;
				obj.ShippingCost = objDetails.ShippingCost;
				obj.Freight = objDetails.Freight;
				obj.FreeOnBoard = objDetails.FreeOnBoard;
				obj.Boxes = objDetails.Boxes;
				obj.Weight = objDetails.Weight;
				obj.DimensionalWeight = objDetails.DimensionalWeight;
				obj.WeightInPounds = objDetails.WeightInPounds;
				obj.AirWayBill = objDetails.AirWayBill;
				obj.ShippedBy = objDetails.ShippedBy;
				obj.Printed = objDetails.Printed;
				obj.SupplierRMANo = objDetails.SupplierRMANo;
				obj.SupplierRMANumber = objDetails.SupplierRMANumber;
				obj.ShippingNotes = objDetails.ShippingNotes;
				obj.Exported = objDetails.Exported;
				obj.InvoicePaid = objDetails.InvoicePaid;
				obj.Salesman2 = objDetails.Salesman2;
				obj.Salesman2Percent = objDetails.Salesman2Percent;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.CompanyName = objDetails.CompanyName;
				obj.ContactNo = objDetails.ContactNo;
				obj.ContactName = objDetails.ContactName;
				obj.CustomerCode = objDetails.CustomerCode;
				obj.CurrencyNo = objDetails.CurrencyNo;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyDescription = objDetails.CurrencyDescription;
				obj.SalesmanName = objDetails.SalesmanName;
				obj.Salesman2Name = objDetails.Salesman2Name;
				obj.TermsNo = objDetails.TermsNo;
				obj.TermsName = objDetails.TermsName;
				obj.Salesman = objDetails.Salesman;
				obj.ShippedByName = objDetails.ShippedByName;
				obj.DivisionNo = objDetails.DivisionNo;
				obj.DivisionName = objDetails.DivisionName;
				obj.TeamNo = objDetails.TeamNo;
				obj.TaxNo = objDetails.TaxNo;
				obj.TaxName = objDetails.TaxName;
				obj.VATNo = objDetails.VATNo;
				obj.SalesOrderNumber = objDetails.SalesOrderNumber;
				obj.ShipViaName = objDetails.ShipViaName;
				obj.CustomerPO = objDetails.CustomerPO;
				obj.InvoiceValue = objDetails.InvoiceValue;
				obj.LandedCostValue = objDetails.LandedCostValue;
				obj.TaxRate = objDetails.TaxRate;
				obj.StatusText = objDetails.StatusText;
				obj.ShipToAddressNo = objDetails.ShipToAddressNo;
				obj.CofCNotes = objDetails.CofCNotes;
				obj.BillToAddressNo = objDetails.BillToAddressNo;
				obj.IncotermNo = objDetails.IncotermNo;
				obj.IncotermName = objDetails.IncotermName;
				obj.CompanyTelephone = objDetails.CompanyTelephone;
				obj.CompanyFax = objDetails.CompanyFax;
				obj.CustomerCode = objDetails.CustomerCode;
				obj.DateOrdered = objDetails.DateOrdered;
				obj.ContactEmail = objDetails.ContactEmail;
				obj.PrintNotes = objDetails.PrintNotes;
				obj.IncotermName = objDetails.IncotermName;
                //[001] Code start
                obj.CompanyRegNo = objDetails.CompanyRegNo;
                //[001] Code end

                //[002] code start
                obj.CurrencyNotes = objDetails.CurrencyNotes;
                //[002] code end

                //[009] code start
                obj.InvoiceBankFee = objDetails.InvoiceBankFee;
                obj.IsApplyBankFee = objDetails.IsApplyBankFee;
                //[009] code end
                obj.ExchangeRate = objDetails.ExchangeRate;
                obj.LocalCurrencyNo = objDetails.LocalCurrencyNo;
                obj.ApplyLocalCurrency = objDetails.ApplyLocalCurrency;
                obj.LocalCurrencyCode = objDetails.LocalCurrencyCode;
                obj.ShipToVatNo = objDetails.ShipToVatNo;
                obj.NotesToInvoice = objDetails.NotesToInvoice;
                obj.SerialInvoice = objDetails.SerialInvoice;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetIDByNumber
		/// Calls [usp_select_Invoice_ID_by_Number]
		/// </summary>
        public static List<Invoice> GetIDByNumber(System.Int32? invoiceNumber, System.Int32? clientNo, System.Int32? isGlobalUser)
        {
            //[010] start
            List<Rebound.GlobalTrader.DAL.InvoiceDetails> objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Invoice.GetIDByNumber(invoiceNumber, clientNo, isGlobalUser);
            List<Invoice> lstInvoice = new List<Invoice>();
            foreach (InvoiceDetails inc in objDetails)
            {
                Invoice obj = new Invoice();
                obj.InvoiceId = inc.InvoiceId;
                obj.InvoiceDetail = inc.InvoiceDetail;
                lstInvoice.Add(obj);
            }
            return lstInvoice;
            //[010] end
        }
		/// <summary>
		/// GetNextNumber
		/// Calls [usp_select_Invoice_NextNumber]
		/// </summary>
		public static Invoice GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy) {
			Rebound.GlobalTrader.DAL.InvoiceDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Invoice.GetNextNumber(clientNo, updatedBy);
			if (objDetails == null) {
				return null;
			} else {
				Invoice obj = new Invoice();
				obj.InvoiceNumber = objDetails.InvoiceNumber;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetStatusText
		/// Calls [usp_select_Invoice_StatusText]
		/// </summary>
		public static Invoice GetStatusText(System.Int32? invoiceId) {
			Rebound.GlobalTrader.DAL.InvoiceDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Invoice.GetStatusText(invoiceId);
			if (objDetails == null) {
				return null;
			} else {
				Invoice obj = new Invoice();
				obj.StatusText = objDetails.StatusText;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForCompany
		/// Calls [usp_selectAll_Invoice_for_Company]
		/// </summary>
		public static List<Invoice> GetListForCompany(System.Int32? companyId, System.Boolean? includePaid) {
			List<InvoiceDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Invoice.GetListForCompany(companyId, includePaid);
			if (lstDetails == null) {
				return new List<Invoice>();
			} else {
				List<Invoice> lst = new List<Invoice>();
				foreach (InvoiceDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Invoice obj = new Rebound.GlobalTrader.BLL.Invoice();
					obj.InvoiceId = objDetails.InvoiceId;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.InvoiceDate = objDetails.InvoiceDate;
					obj.SalesOrderNo = objDetails.SalesOrderNo;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.InvoiceValue = objDetails.InvoiceValue;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CustomerPO = objDetails.CustomerPO;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListOpenForCompany
		/// Calls [usp_selectAll_Invoice_Open_for_Company]
		/// </summary>
		public static List<Invoice> GetListOpenForCompany(System.Int32? companyId) {
			List<InvoiceDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Invoice.GetListOpenForCompany(companyId);
			if (lstDetails == null) {
				return new List<Invoice>();
			} else {
				List<Invoice> lst = new List<Invoice>();
				foreach (InvoiceDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Invoice obj = new Rebound.GlobalTrader.BLL.Invoice();
					obj.InvoiceId = objDetails.InvoiceId;
					obj.InvoiceNumber = objDetails.InvoiceNumber;
					obj.InvoiceDate = objDetails.InvoiceDate;
					obj.SalesOrderNo = objDetails.SalesOrderNo;
					obj.SalesOrderNumber = objDetails.SalesOrderNumber;
					obj.InvoiceValue = objDetails.InvoiceValue;
					obj.CurrencyCode = objDetails.CurrencyCode;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_Invoice]
		/// </summary>
        public static bool Update(System.Int32? invoiceId, System.String notes, System.String instructions, System.String shippingNotes, System.String cofCnotes, System.Boolean? invoicePaid, System.Int32? salesman2, System.Double? salesman2Percent, System.Int32? boxes, System.Double? weight, System.Double? dimensionalWeight, System.Boolean? weightInPounds, System.String airWayBill, System.Double? shippingCost, System.Double? freight, System.Int32? shipViaNo, System.String customerPo, System.String account, System.Int32? currencyNo, System.Int32? salesman, System.Int32? termsNo, System.Int32? taxNo, System.Int32? billToAddressNo, System.String companyBillTo, System.Int32? shipToAddressNo, System.String companyShipTo, System.Int32? divisionNo, System.Int32? incotermNo, System.Int32? updatedBy, System.Double? ExchangeRate, System.DateTime? invoicePaidDate)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Invoice.Update(invoiceId, notes, instructions, shippingNotes, cofCnotes, invoicePaid, salesman2, salesman2Percent, boxes, weight, dimensionalWeight, weightInPounds, airWayBill, shippingCost, freight, shipViaNo, customerPo, account, currencyNo, salesman, termsNo, taxNo, billToAddressNo, companyBillTo, shipToAddressNo, companyShipTo, divisionNo, incotermNo, updatedBy, ExchangeRate, invoicePaidDate);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Invoice]
		/// </summary>
		public bool Update() {
            return Rebound.GlobalTrader.DAL.SiteProvider.Invoice.Update(InvoiceId, Notes, Instructions, ShippingNotes, CofCNotes, InvoicePaid, Salesman2, Salesman2Percent, Boxes, Weight, DimensionalWeight, WeightInPounds, AirWayBill, ShippingCost, Freight, ShipViaNo, CustomerPO, Account, CurrencyNo, Salesman, TermsNo, TaxNo, BillToAddressNo, CompanyBillTo, ShipToAddressNo, CompanyShipTo, DivisionNo, IncotermNo, UpdatedBy, ExchangeRate, InvoicePaidDate);
		}
		/// <summary>
		/// UpdateExport
		/// Calls [usp_update_Invoice_Export]
		/// </summary>
		public static bool UpdateExport(System.Int32? invoiceId, System.Int32? exportedBy, System.Boolean? export) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Invoice.UpdateExport(invoiceId, exportedBy, export);
		}
        /// <summary>
        /// Update Shipping Info
        /// Calls [usp_update_InvoiceShippingInfo]
        /// </summary>
        public static bool UpdateShippingInfo(System.Int32? invoiceId,  System.Int32? boxes, System.Double? weight, System.Double? dimensionalWeight, System.Boolean? weightInPounds, System.String airWayBill, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Invoice.UpdateShippingInfo(invoiceId, boxes, weight, dimensionalWeight, weightInPounds, airWayBill, updatedBy);
        }

        private static Invoice PopulateFromDBDetailsObject(InvoiceDetails obj) {
            Invoice objNew = new Invoice();
			objNew.InvoiceId = obj.InvoiceId;
			objNew.ClientNo = obj.ClientNo;
			objNew.InvoiceNumber = obj.InvoiceNumber;
			objNew.SalesOrderNo = obj.SalesOrderNo;
			objNew.InvoiceDate = obj.InvoiceDate;
			objNew.Notes = obj.Notes;
			objNew.Instructions = obj.Instructions;
			objNew.CompanyBillTo = obj.CompanyBillTo;
			objNew.CompanyShipTo = obj.CompanyShipTo;
			objNew.ShipViaNo = obj.ShipViaNo;
			objNew.Account = obj.Account;
			objNew.ShippingCost = obj.ShippingCost;
			objNew.Freight = obj.Freight;
			objNew.FreeOnBoard = obj.FreeOnBoard;
			objNew.Boxes = obj.Boxes;
			objNew.Weight = obj.Weight;
			objNew.DimensionalWeight = obj.DimensionalWeight;
			objNew.WeightInPounds = obj.WeightInPounds;
			objNew.AirWayBill = obj.AirWayBill;
			objNew.ShippedBy = obj.ShippedBy;
			objNew.Printed = obj.Printed;
			objNew.SupplierRMANo = obj.SupplierRMANo;
			objNew.ShippingNotes = obj.ShippingNotes;
			objNew.Exported = obj.Exported;
			objNew.InvoicePaid = obj.InvoicePaid;
			objNew.Salesman2 = obj.Salesman2;
			objNew.Salesman2Percent = obj.Salesman2Percent;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.CustomerPO = obj.CustomerPO;
			objNew.Salesman = obj.Salesman;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.ContactNo = obj.ContactNo;
			objNew.CurrencyNo = obj.CurrencyNo;
			objNew.TermsNo = obj.TermsNo;
			objNew.TaxNo = obj.TaxNo;
			objNew.ShipToAddressNo = obj.ShipToAddressNo;
			objNew.DivisionNo = obj.DivisionNo;
			objNew.SalesOrderNumber = obj.SalesOrderNumber;
			objNew.DateOrdered = obj.DateOrdered;
			objNew.CofCNotes = obj.CofCNotes;
			objNew.BillToAddressNo = obj.BillToAddressNo;
			objNew.IncotermNo = obj.IncotermNo;
			objNew.DivisionNo2 = obj.DivisionNo2;
			objNew.DateExported = obj.DateExported;
			objNew.CompanyName = obj.CompanyName;
			objNew.SalesmanName = obj.SalesmanName;
			objNew.CurrencyCode = obj.CurrencyCode;
			objNew.RowNum = obj.RowNum;
			objNew.SupplierRMANumber = obj.SupplierRMANumber;
			objNew.ContactName = obj.ContactName;
			objNew.CustomerCode = obj.CustomerCode;
			objNew.CurrencyDescription = obj.CurrencyDescription;
			objNew.Salesman2Name = obj.Salesman2Name;
			objNew.TermsName = obj.TermsName;
			objNew.ShippedByName = obj.ShippedByName;
			objNew.DivisionName = obj.DivisionName;
			objNew.TeamNo = obj.TeamNo;
			objNew.TaxName = obj.TaxName;
			objNew.VATNo = obj.VATNo;
			objNew.ShipViaName = obj.ShipViaName;
			objNew.InvoiceValue = obj.InvoiceValue;
			objNew.LandedCostValue = obj.LandedCostValue;
			objNew.TaxRate = obj.TaxRate;
			objNew.StatusText = obj.StatusText;
			objNew.IncotermName = obj.IncotermName;
			objNew.RowCnt = obj.RowCnt;
			objNew.CompanyTelephone = obj.CompanyTelephone;
			objNew.CompanyFax = obj.CompanyFax;
			objNew.ContactEmail = obj.ContactEmail;
			objNew.PrintNotes = obj.PrintNotes;
            return objNew;
        }
        // [006] code start
        /// <summary>
        /// GetPDFListForInvoice
        /// Calls [usp_selectAll_PDF_for_Invoice]
        /// </summary>
        public static List<PDFDocument> GetPDFListForInvoice(System.Int32? InvoiceNo)
        {
            List<PDFDocumentDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Invoice.GetPDFListForInvoice(InvoiceNo);
            if (lstDetails == null)
            {
                return new List<PDFDocument>();
            }
            else
            {
                List<PDFDocument> lst = new List<PDFDocument>();
                foreach (PDFDocumentDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.PDFDocument obj = new Rebound.GlobalTrader.BLL.PDFDocument();
                    obj.PDFDocumentId = objDetails.PDFDocumentId;
                    obj.PDFDocumentRefNo = objDetails.PDFDocumentRefNo;
                    obj.Caption = objDetails.Caption;
                    obj.FileName = objDetails.FileName;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Calls [usp_insert_InvoicePDF]
        /// </summary>
        /// <param name="InvoiceNo"></param>
        /// <param name="Caption"></param>
        /// <param name="FileName"></param>
        /// <param name="UpdatedBy"></param>
        /// <returns></returns>
        public static Int32 Insert(System.Int32? InvoiceNo, System.String Caption, System.String FileName, System.Int32? UpdatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Invoice.Insert(InvoiceNo, Caption, FileName, UpdatedBy);
            return objReturn;
        }
        /// <summary>
        /// Calls [usp_delete_InvoicePDF]
        /// </summary>
        /// <param name="InvoicePdfId"></param>
        /// <returns></returns>
        public static bool DeleteInvoicePDF(System.Int32? InvoicePdfId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Invoice.DeleteInvoicePDF(InvoicePdfId);
        }
        // [006] code end

        //[009] code start
        /// <summary>
        /// usp_updateInvoiceBankFee
        /// </summary>
        /// <param name="InvoiceID"></param>
        /// <param name="InvoiceBankFee"></param>
        /// <returns></returns>
        public static bool UpdateInvoiceBankFee(System.Int32 invoiceID, System.Double? invoiceBankFee)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Invoice.UpdateInvoiceBankFee(invoiceID, invoiceBankFee);
        }


        public static List<Invoice> GetSerial(System.Int32? invoiceLineId)
        {
            List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Invoice.GetSerial(invoiceLineId);
            if (lstDetails == null)
            {
                return new List<Invoice>();
            }
            else
            {
                List<Invoice> lst = new List<Invoice>();
                foreach (GoodsInLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Invoice obj = new Rebound.GlobalTrader.BLL.Invoice();
                    obj.SerialNoId = objDetails.SerialNoId;
                    obj.SerialNo = objDetails.SerialNo;
                    obj.SubGroup = objDetails.SubGroup;
                    obj.GoodsInNo = objDetails.GoodsInNo;

                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        //[009] code end
		#endregion
		
	}
}