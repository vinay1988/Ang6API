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
    public partial class Credit : BizObject
    {

        #region Properties

        protected static DAL.CreditElement Settings
        {
            get { return Globals.Settings.Credits; }
        }

        /// <summary>
        /// CreditId
        /// </summary>
        public System.Int32 CreditId { get; set; }
        /// <summary>
        /// CreditNumber
        /// </summary>
        public System.Int32 CreditNumber { get; set; }
        /// <summary>
        /// ClientNo
        /// </summary>
        public System.Int32 ClientNo { get; set; }
        /// <summary>
        /// CompanyNo
        /// </summary>
        public System.Int32 CompanyNo { get; set; }
        /// <summary>
        /// ContactNo
        /// </summary>
        public System.Int32 ContactNo { get; set; }
        /// <summary>
        /// CreditDate
        /// </summary>
        public System.DateTime CreditDate { get; set; }
        /// <summary>
        /// CurrencyNo
        /// </summary>
        public System.Int32 CurrencyNo { get; set; }
        /// <summary>
        /// RaisedBy
        /// </summary>
        public System.Int32? RaisedBy { get; set; }
        /// <summary>
        /// Salesman
        /// </summary>
        public System.Int32 Salesman { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public System.String Notes { get; set; }
        /// <summary>
        /// Instructions
        /// </summary>
        public System.String Instructions { get; set; }
        /// <summary>
        /// ShipViaNo
        /// </summary>
        public System.Int32? ShipViaNo { get; set; }
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
        /// DivisionNo
        /// </summary>
        public System.Int32 DivisionNo { get; set; }
        /// <summary>
        /// TaxNo
        /// </summary>
        public System.Int32? TaxNo { get; set; }
        /// <summary>
        /// InvoiceNo
        /// </summary>
        public System.Int32? InvoiceNo { get; set; }
        /// <summary>
        /// CustomerRMANo
        /// </summary>
        public System.Int32? CustomerRMANo { get; set; }
        /// <summary>
        /// ReferenceDate
        /// </summary>
        public System.DateTime ReferenceDate { get; set; }
        /// <summary>
        /// CustomerPO
        /// </summary>
        public System.String CustomerPO { get; set; }
        /// <summary>
        /// CustomerRMA
        /// </summary>
        public System.String CustomerRMA { get; set; }
        /// <summary>
        /// CustomerDebit
        /// </summary>
        public System.String CustomerDebit { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime DLUP { get; set; }
        /// <summary>
        /// Salesman2
        /// </summary>
        public System.Int32? Salesman2 { get; set; }
        /// <summary>
        /// Salesman2Percent
        /// </summary>
        public System.Double Salesman2Percent { get; set; }
        /// <summary>
        /// IncotermNo
        /// </summary>
        public System.Int32? IncotermNo { get; set; }
        /// <summary>
        /// DivisionNo2
        /// </summary>
        public System.Int32? DivisionNo2 { get; set; }
        /// <summary>
        /// CompanyName
        /// </summary>
        public System.String CompanyName { get; set; }
        /// <summary>
        /// CustomerCode
        /// </summary>
        public System.String CustomerCode { get; set; }
        /// <summary>
        /// ContactName
        /// </summary>
        public System.String ContactName { get; set; }
        /// <summary>
        /// CurrencyCode
        /// </summary>
        public System.String CurrencyCode { get; set; }
        /// <summary>
        /// CurrencyDescription
        /// </summary>
        public System.String CurrencyDescription { get; set; }
        /// <summary>
        /// RaiserName
        /// </summary>
        public System.String RaiserName { get; set; }
        /// <summary>
        /// SalesmanName
        /// </summary>
        public System.String SalesmanName { get; set; }
        /// <summary>
        /// TeamNo
        /// </summary>
        public System.Int32? TeamNo { get; set; }
        /// <summary>
        /// DivisionName
        /// </summary>
        public System.String DivisionName { get; set; }
        /// <summary>
        /// Salesman2Name
        /// </summary>
        public System.String Salesman2Name { get; set; }
        /// <summary>
        /// TaxName
        /// </summary>
        public System.String TaxName { get; set; }
        /// <summary>
        /// InvoiceNumber
        /// </summary>
        public System.Int32? InvoiceNumber { get; set; }
        /// <summary>
        /// InvoiceDate
        /// </summary>
        public System.DateTime? InvoiceDate { get; set; }
        /// <summary>
        /// SalesOrderNo
        /// </summary>
        public System.Int32? SalesOrderNo { get; set; }
        /// <summary>
        /// SalesOrderNumber
        /// </summary>
        public System.Int32? SalesOrderNumber { get; set; }
        /// <summary>
        /// CustomerRMANumber
        /// </summary>
        public System.Int32? CustomerRMANumber { get; set; }
        /// <summary>
        /// CustomerRMADate
        /// </summary>
        public System.DateTime? CustomerRMADate { get; set; }
        /// <summary>
        /// ShipViaName
        /// </summary>
        public System.String ShipViaName { get; set; }
        /// <summary>
        /// CreditValue
        /// </summary>
        public System.Double? CreditValue { get; set; }
        /// <summary>
        /// CreditCost
        /// </summary>
        public System.Double? CreditCost { get; set; }
        /// <summary>
        /// TaxRate
        /// </summary>
        public System.Double? TaxRate { get; set; }
        /// <summary>
        /// IncotermName
        /// </summary>
        public System.String IncotermName { get; set; }
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
        //[001] start code
        /// </summary>
        public System.Double? CreditNoteBankFee { get; set; }
        /// <summary>    
        //[001] end code
        /// <summary>
        /// VATNO 
        /// </summary>
        public System.String VATNO { get; set; }

        public int? ClientCreditNo { get; set; }
        public System.Int32? RefNumber { get; set; }
        public System.Boolean isClientInvoice { get; set; }
        public System.Int32? RefClientNo { get; set; }
        public System.String RefClientName { get; set; }
        public System.Int32? ClientInvoiceNo { get; set; }
        public System.Int32? ClientInvoiceNumber { get; set; }


        public System.String ClientShipTo { get; set; }
        public System.String Telephone { get; set; }
        public System.String Fax { get; set; }
        public System.String ClientCustomerCode { get; set; }
        public System.String Email { get; set; }
        public System.String VAT { get; set; }
        public System.String Tax { get; set; }
        public System.String ClientBillToAdr { get; set; }
        public System.Int32? ClientInvoiceLineNo { get; set; }
        public Boolean isExport { get; set; }
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

        #endregion

        #region Methods

        /// <summary>
        /// CountForCompany
        /// Calls [usp_count_Credit_for_Company]
        /// </summary>
        public static Int32 CountForCompany(System.Int32? companyId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Credit.CountForCompany(companyId);
        }	
	
        /// <summary>
        /// Delete
        /// Calls [usp_delete_Credit]
        /// </summary>
        public static bool Delete(System.Int32? creditId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Credit.Delete(creditId);
        }
        /// <summary>
        /// Insert
        /// Calls [usp_insert_Credit]
        /// </summary>
        public static Int32 Insert(System.Int32? clientNo, System.Int32? companyNo, System.Int32? contactNo, System.DateTime? creditDate, System.Int32? currencyNo, System.Int32? raisedBy, System.Int32? salesman, System.String notes, System.String instructions, System.Int32? shipViaNo, System.String account, System.Double? shippingCost, System.Double? freight, System.Int32? divisionNo, System.Int32? taxNo, System.Int32? invoiceNo, System.Int32? customerRmaNo, System.DateTime? referenceDate, System.String customerPo, System.String customerRma, System.String customerDebit, System.Int32? salesman2, System.Double? salesman2Percent, System.Int32? incotermNo, System.Double? CreditNoteBankFee, System.Int32? updatedBy, System.Boolean isClientInvoice,System.Int32? clientInvoiceLineNo)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Credit.Insert(clientNo, companyNo, contactNo, creditDate, currencyNo, raisedBy, salesman, notes, instructions, shipViaNo, account, shippingCost, freight, divisionNo, taxNo, invoiceNo, customerRmaNo, referenceDate, customerPo, customerRma, customerDebit, salesman2, salesman2Percent, incotermNo, CreditNoteBankFee, updatedBy, isClientInvoice, clientInvoiceLineNo);
            return objReturn;
        }
        /// <summary>
        /// Insert (without parameters)
        /// Calls [usp_insert_Credit]
        /// </summary>
        public Int32 Insert()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Credit.Insert(ClientNo, CompanyNo, ContactNo, CreditDate, CurrencyNo, RaisedBy, Salesman, Notes, Instructions, ShipViaNo, Account, ShippingCost, Freight, DivisionNo, TaxNo, InvoiceNo, CustomerRMANo, ReferenceDate, CustomerPO, CustomerRMA, CustomerDebit, Salesman2, Salesman2Percent, IncotermNo, CreditNoteBankFee, UpdatedBy, isClientInvoice, null);
        }
        /// <summary>
        /// Get
        /// Calls [usp_select_Credit]
        /// </summary>
        public static Credit Get(System.Int32? creditId)
        {
            Rebound.GlobalTrader.DAL.CreditDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Credit.Get(creditId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Credit obj = new Credit();
                obj.CreditId = objDetails.CreditId;
                obj.CreditNumber = objDetails.CreditNumber;
                obj.ClientNo = objDetails.ClientNo;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ContactNo = objDetails.ContactNo;
                obj.CreditDate = objDetails.CreditDate;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.RaisedBy = objDetails.RaisedBy;
                obj.Salesman = objDetails.Salesman;
                obj.Notes = objDetails.Notes;
                obj.Instructions = objDetails.Instructions;
                obj.ShipViaNo = objDetails.ShipViaNo;
                obj.Account = objDetails.Account;
                obj.ShippingCost = objDetails.ShippingCost;
                obj.Freight = objDetails.Freight;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.TaxNo = objDetails.TaxNo;
                obj.InvoiceNo = objDetails.InvoiceNo;
                obj.CustomerRMANo = objDetails.CustomerRMANo;
                obj.ReferenceDate = objDetails.ReferenceDate;
                obj.CustomerPO = objDetails.CustomerPO;
                obj.CustomerRMA = objDetails.CustomerRMA;
                obj.CustomerDebit = objDetails.CustomerDebit;
                obj.Salesman2 = objDetails.Salesman2;
                obj.Salesman2Percent = objDetails.Salesman2Percent;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.CompanyName = objDetails.CompanyName;
                obj.CustomerCode = objDetails.CustomerCode;
                obj.ContactName = objDetails.ContactName;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.RaiserName = objDetails.RaiserName;
                obj.SalesmanName = objDetails.SalesmanName;
                obj.TeamNo = objDetails.TeamNo;
                obj.DivisionName = objDetails.DivisionName;
                obj.Salesman2Name = objDetails.Salesman2Name;
                obj.TaxName = objDetails.TaxName;
                obj.InvoiceNumber = objDetails.InvoiceNumber;
                obj.InvoiceDate = objDetails.InvoiceDate;
                obj.SalesOrderNo = objDetails.SalesOrderNo;
                obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                obj.CustomerRMADate = objDetails.CustomerRMADate;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.CreditValue = objDetails.CreditValue;
                obj.CreditCost = objDetails.CreditCost;
                obj.TaxRate = objDetails.TaxRate;
                obj.IncotermNo = objDetails.IncotermNo;
                //[001] start code
                obj.CreditNoteBankFee = objDetails.CreditNoteBankFee;
                //[001] end code
                obj.IncotermName = objDetails.IncotermName;
                obj.VATNO = objDetails.VATNO;
                obj.ClientCreditNo = objDetails.ClientCreditNo;
                obj.RefNumber = objDetails.RefNumber;
                obj.isClientInvoice = objDetails.isClientInvoice;
                obj.RefClientNo = objDetails.RefClientNo;
                obj.RefClientName = objDetails.RefClientName;
                obj.ClientInvoiceNo = objDetails.ClientInvoiceNo;
                obj.ClientInvoiceNumber = objDetails.ClientInvoiceNumber;
                obj.ClientInvoiceLineNo = objDetails.ClientInvoiceLineNo;
                obj.isExport = objDetails.isExport;
                obj.ExchangeRate = objDetails.ExchangeRate;

                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetForPage
        /// Calls [usp_select_Credit_for_Page]
        /// </summary>
        public static Credit GetForPage(System.Int32? creditId)
        {
            Rebound.GlobalTrader.DAL.CreditDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Credit.GetForPage(creditId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Credit obj = new Credit();
                obj.CreditId = objDetails.CreditId;
                obj.CreditNumber = objDetails.CreditNumber;
                obj.ClientNo = objDetails.ClientNo;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.CompanyName = objDetails.CompanyName;
                obj.TeamNo = objDetails.TeamNo;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.Salesman = objDetails.Salesman;
                obj.isClientInvoice = objDetails.isClientInvoice;
                obj.RefClientName = objDetails.RefClientName;
                obj.RefClientNo = objDetails.RefClientNo;
                obj.ClientCreditNo = objDetails.ClientCreditNo;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetForPrint
        /// Calls [usp_select_Credit_for_Print]
        /// </summary>
        public static Credit GetForPrint(System.Int32? creditId)
        {
            Rebound.GlobalTrader.DAL.CreditDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Credit.GetForPrint(creditId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Credit obj = new Credit();
                obj.CreditId = objDetails.CreditId;
                obj.CreditNumber = objDetails.CreditNumber;
                obj.ClientNo = objDetails.ClientNo;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ContactNo = objDetails.ContactNo;
                obj.CreditDate = objDetails.CreditDate;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.RaisedBy = objDetails.RaisedBy;
                obj.Salesman = objDetails.Salesman;
                obj.Notes = objDetails.Notes;
                obj.Instructions = objDetails.Instructions;
                obj.ShipViaNo = objDetails.ShipViaNo;
                obj.Account = objDetails.Account;
                obj.ShippingCost = objDetails.ShippingCost;
                obj.Freight = objDetails.Freight;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.TaxNo = objDetails.TaxNo;
                obj.InvoiceNo = objDetails.InvoiceNo;
                obj.CustomerRMANo = objDetails.CustomerRMANo;
                obj.ReferenceDate = objDetails.ReferenceDate;
                obj.CustomerPO = objDetails.CustomerPO;
                obj.CustomerRMA = objDetails.CustomerRMA;
                obj.CustomerDebit = objDetails.CustomerDebit;
                obj.Salesman2 = objDetails.Salesman2;
                obj.Salesman2Percent = objDetails.Salesman2Percent;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.CompanyName = objDetails.CompanyName;
                obj.CustomerCode = objDetails.CustomerCode;
                obj.ContactName = objDetails.ContactName;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.RaiserName = objDetails.RaiserName;
                obj.SalesmanName = objDetails.SalesmanName;
                obj.TeamNo = objDetails.TeamNo;
                obj.DivisionName = objDetails.DivisionName;
                obj.Salesman2Name = objDetails.Salesman2Name;
                obj.TaxName = objDetails.TaxName;
                obj.InvoiceNumber = objDetails.InvoiceNumber;
                obj.InvoiceDate = objDetails.InvoiceDate;
                obj.SalesOrderNo = objDetails.SalesOrderNo;
                obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                obj.CustomerRMADate = objDetails.CustomerRMADate;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.CreditValue = objDetails.CreditValue;
                obj.CreditCost = objDetails.CreditCost;
                obj.TaxRate = objDetails.TaxRate;
                obj.IncotermNo = objDetails.IncotermNo;
                //[001] start code
                obj.CreditNoteBankFee = objDetails.CreditNoteBankFee;
                //[001] end code
                obj.IncotermName = objDetails.IncotermName;
                obj.CompanyTelephone = objDetails.CompanyTelephone;
                obj.CompanyFax = objDetails.CompanyFax;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.ContactEmail = objDetails.ContactEmail;
                obj.IncotermName = objDetails.IncotermName;
                obj.VATNO = objDetails.VATNO;

                obj.ClientCreditNo = objDetails.ClientCreditNo;
                obj.RefNumber = objDetails.RefNumber;
                obj.isClientInvoice = objDetails.isClientInvoice;
                obj.RefClientNo = objDetails.RefClientNo;
                obj.RefClientName = objDetails.RefClientName;
                obj.ClientInvoiceNo = objDetails.ClientInvoiceNo;
                obj.ClientInvoiceNumber = objDetails.ClientInvoiceNumber;

                obj.ClientShipTo = objDetails.ClientShipTo;
                obj.Telephone = objDetails.Telephone;
                obj.Fax = objDetails.Fax;
                obj.ClientCustomerCode = objDetails.ClientCustomerCode;
                obj.Email = objDetails.Email;
                obj.VAT = objDetails.VAT;
                obj.Tax = objDetails.Tax;
                obj.ClientBillToAdr = objDetails.ClientBillToAdr;
                obj.ExchangeRate = objDetails.ExchangeRate;
                obj.LocalCurrencyNo = objDetails.LocalCurrencyNo;
                obj.ApplyLocalCurrency = objDetails.ApplyLocalCurrency;
                obj.LocalCurrencyCode = objDetails.LocalCurrencyCode;

                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetIdByNumber
        /// Calls [usp_select_Credit_Id_by_Number]
        /// </summary>
        public static Credit GetIdByNumber(System.Int32? creditNumber, System.Int32? clientNo)
        {
            Rebound.GlobalTrader.DAL.CreditDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Credit.GetIdByNumber(creditNumber, clientNo);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Credit obj = new Credit();
                obj.CreditId = objDetails.CreditId;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetNextNumber
        /// Calls [usp_select_Credit_NextNumber]
        /// </summary>
        public static Credit GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy)
        {
            Rebound.GlobalTrader.DAL.CreditDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Credit.GetNextNumber(clientNo, updatedBy);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Credit obj = new Credit();
                obj.CreditNumber = objDetails.CreditNumber;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetListForCompany
        /// Calls [usp_selectAll_Credit_for_Company]
        /// </summary>
        public static List<Credit> GetListForCompany(System.Int32? companyId)
        {
            List<CreditDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Credit.GetListForCompany(companyId);
            if (lstDetails == null)
            {
                return new List<Credit>();
            }
            else
            {
                List<Credit> lst = new List<Credit>();
                foreach (CreditDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Credit obj = new Rebound.GlobalTrader.BLL.Credit();
                    obj.CreditId = objDetails.CreditId;
                    obj.CreditNumber = objDetails.CreditNumber;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.CreditDate = objDetails.CreditDate;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.RaisedBy = objDetails.RaisedBy;
                    obj.Salesman = objDetails.Salesman;
                    obj.Notes = objDetails.Notes;
                    obj.Instructions = objDetails.Instructions;
                    obj.ShipViaNo = objDetails.ShipViaNo;
                    obj.Account = objDetails.Account;
                    obj.ShippingCost = objDetails.ShippingCost;
                    obj.Freight = objDetails.Freight;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TaxNo = objDetails.TaxNo;
                    obj.InvoiceNo = objDetails.InvoiceNo;
                    obj.CustomerRMANo = objDetails.CustomerRMANo;
                    obj.ReferenceDate = objDetails.ReferenceDate;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.CustomerRMA = objDetails.CustomerRMA;
                    obj.CustomerDebit = objDetails.CustomerDebit;
                    obj.Salesman2 = objDetails.Salesman2;
                    obj.Salesman2Percent = objDetails.Salesman2Percent;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.CustomerCode = objDetails.CustomerCode;
                    obj.ContactName = objDetails.ContactName;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.RaiserName = objDetails.RaiserName;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.DivisionName = objDetails.DivisionName;
                    obj.Salesman2Name = objDetails.Salesman2Name;
                    obj.TaxName = objDetails.TaxName;
                    obj.InvoiceNumber = objDetails.InvoiceNumber;
                    obj.InvoiceDate = objDetails.InvoiceDate;
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                    obj.CustomerRMADate = objDetails.CustomerRMADate;
                    obj.ShipViaName = objDetails.ShipViaName;
                    obj.CreditValue = objDetails.CreditValue;
                    obj.CreditCost = objDetails.CreditCost;
                    obj.TaxRate = objDetails.TaxRate;
                    obj.IncotermNo = objDetails.IncotermNo;
                    obj.IncotermName = objDetails.IncotermName;
                    //[001] start code
                    obj.CreditNoteBankFee = objDetails.CreditNoteBankFee;
                    //[001] end code
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Update
        /// Calls [usp_update_Credit]
        /// </summary>
        public static bool Update(System.Int32? creditId, System.String customerPo, System.String customerRma, System.String customerDebit, System.String notes, System.String instructions, System.Int32? divisionNo, System.Int32? salesman, System.Int32? raisedBy, System.DateTime? creditDate, System.DateTime? referenceDate, System.Int32? taxNo, System.Int32? currencyNo, System.Int32? shipViaNo, System.String account, System.Double? shippingCost, System.Double? freight, System.Int32? salesman2, System.Double? salesman2Percent, System.Int32? incotermNo, System.Double? CreditNoteBankFee, System.Int32? updatedBy,System.Double? exchangeRate)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Credit.Update(creditId, customerPo, customerRma, customerDebit, notes, instructions, divisionNo, salesman, raisedBy, creditDate, referenceDate, taxNo, currencyNo, shipViaNo, account, shippingCost, freight, salesman2, salesman2Percent, incotermNo, CreditNoteBankFee, updatedBy, exchangeRate);
        }
        /// <summary>
        /// Update (without parameters)
        /// Calls [usp_update_Credit]
        /// </summary>
        public bool Update()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Credit.Update(CreditId, CustomerPO, CustomerRMA, CustomerDebit, Notes, Instructions, DivisionNo, Salesman, RaisedBy, CreditDate, ReferenceDate, TaxNo, CurrencyNo, ShipViaNo, Account, ShippingCost, Freight, Salesman2, Salesman2Percent, IncotermNo, CreditNoteBankFee, UpdatedBy,ExchangeRate);
        }

        /// <summary>
        /// UpdateExport
        /// Calls [usp_update_Credit_Export]
        /// </summary>
        public static bool UpdateExport(System.Int32? creditId, System.Int32? exportedBy, System.Boolean? export)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Credit.UpdateExport(creditId, exportedBy, export);
        }

        private static Credit PopulateFromDBDetailsObject(CreditDetails obj)
        {
            Credit objNew = new Credit();
            objNew.CreditId = obj.CreditId;
            objNew.CreditNumber = obj.CreditNumber;
            objNew.ClientNo = obj.ClientNo;
            objNew.CompanyNo = obj.CompanyNo;
            objNew.ContactNo = obj.ContactNo;
            objNew.CreditDate = obj.CreditDate;
            objNew.CurrencyNo = obj.CurrencyNo;
            objNew.RaisedBy = obj.RaisedBy;
            objNew.Salesman = obj.Salesman;
            objNew.Notes = obj.Notes;
            objNew.Instructions = obj.Instructions;
            objNew.ShipViaNo = obj.ShipViaNo;
            objNew.Account = obj.Account;
            objNew.ShippingCost = obj.ShippingCost;
            objNew.Freight = obj.Freight;
            objNew.DivisionNo = obj.DivisionNo;
            objNew.TaxNo = obj.TaxNo;
            objNew.InvoiceNo = obj.InvoiceNo;
            objNew.CustomerRMANo = obj.CustomerRMANo;
            objNew.ReferenceDate = obj.ReferenceDate;
            objNew.CustomerPO = obj.CustomerPO;
            objNew.CustomerRMA = obj.CustomerRMA;
            objNew.CustomerDebit = obj.CustomerDebit;
            objNew.UpdatedBy = obj.UpdatedBy;
            objNew.DLUP = obj.DLUP;
            objNew.Salesman2 = obj.Salesman2;
            objNew.Salesman2Percent = obj.Salesman2Percent;
            objNew.IncotermNo = obj.IncotermNo;
            objNew.DivisionNo2 = obj.DivisionNo2;
            objNew.CompanyName = obj.CompanyName;
            objNew.CustomerCode = obj.CustomerCode;
            objNew.ContactName = obj.ContactName;
            objNew.CurrencyCode = obj.CurrencyCode;
            objNew.CurrencyDescription = obj.CurrencyDescription;
            objNew.RaiserName = obj.RaiserName;
            objNew.SalesmanName = obj.SalesmanName;
            objNew.TeamNo = obj.TeamNo;
            objNew.DivisionName = obj.DivisionName;
            objNew.Salesman2Name = obj.Salesman2Name;
            objNew.TaxName = obj.TaxName;
            objNew.InvoiceNumber = obj.InvoiceNumber;
            objNew.InvoiceDate = obj.InvoiceDate;
            objNew.SalesOrderNo = obj.SalesOrderNo;
            objNew.SalesOrderNumber = obj.SalesOrderNumber;
            objNew.CustomerRMANumber = obj.CustomerRMANumber;
            objNew.CustomerRMADate = obj.CustomerRMADate;
            objNew.ShipViaName = obj.ShipViaName;
            objNew.CreditValue = obj.CreditValue;
            objNew.CreditCost = obj.CreditCost;
            objNew.TaxRate = obj.TaxRate;
            objNew.IncotermName = obj.IncotermName;
            //[001] start code
            objNew.CreditNoteBankFee = obj.CreditNoteBankFee;
            //[001] end code
            objNew.CompanyTelephone = obj.CompanyTelephone;
            objNew.CompanyFax = obj.CompanyFax;
            objNew.ContactEmail = obj.ContactEmail;
            return objNew;
        }

        #endregion

    }
}