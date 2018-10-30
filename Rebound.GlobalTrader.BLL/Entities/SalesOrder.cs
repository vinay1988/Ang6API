/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to upload pdf document for sales order section
[002]      Vinay           23/05/2012   This need to add currency notes 
[003]      Abhinav         15/01/2013   Add Bank Fee Term
[004]      Pankaj          10/09/2013   Add property IsSORPDFAvailable
[005]      Vinay           21/01/2014   CR:- Add AS9120 Requirement in GT application
[006]      Aashu Singh     01/06/2018   Quick Jump in Global Warehouse 
[007]      Aashu Singh     03/07/2018   Add customer order value nugget on broker and sales tab
[008]      Aashu Singh     13/08/2018   REB-12161:credit card payments
[009]      Aashu Singh     29/08/2018   Show so payment attachment.
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

namespace Rebound.GlobalTrader.BLL
{
    public partial class SalesOrder : BizObject
    {

        #region Properties

        protected static DAL.SalesOrderElement Settings
        {
            get { return Globals.Settings.SalesOrders; }
        }

        /// <summary>
        /// SalesOrderId
        /// </summary>
        public System.Int32 SalesOrderId { get; set; }
        /// <summary>
        /// SalesOrderNumber
        /// </summary>
        public System.Int32 SalesOrderNumber { get; set; }
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
        /// DateOrdered
        /// </summary>
        public System.DateTime DateOrdered { get; set; }
        /// <summary>
        /// CurrencyNo
        /// </summary>
        public System.Int32 CurrencyNo { get; set; }
        /// <summary>
        /// Salesman
        /// </summary>
        public System.Int32 Salesman { get; set; }
        /// <summary>
        /// TermsNo
        /// </summary>
        public System.Int32 TermsNo { get; set; }
        /// <summary>
        /// ShipToAddressNo
        /// </summary>
        public System.Int32? ShipToAddressNo { get; set; }
        /// <summary>
        /// ShipViaNo
        /// </summary>
        public System.Int32? ShipViaNo { get; set; }
        /// <summary>
        /// Account
        /// </summary>
        public System.String Account { get; set; }
        /// <summary>
        /// Freight
        /// </summary>
        public System.Double Freight { get; set; }
        /// <summary>
        /// CustomerPO
        /// </summary>
        public System.String CustomerPO { get; set; }
        /// <summary>
        /// DivisionNo
        /// </summary>
        public System.Int32 DivisionNo { get; set; }
        /// <summary>
        /// TaxNo
        /// </summary>
        public System.Int32 TaxNo { get; set; }
        /// <summary>
        /// ShippingCost
        /// </summary>
        public System.Double? ShippingCost { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public System.String Notes { get; set; }
        /// <summary>
        /// Instructions
        /// </summary>
        public System.String Instructions { get; set; }
        /// <summary>
        /// Paid
        /// </summary>
        public System.Boolean Paid { get; set; }
        /// <summary>
        /// StatusNo
        /// </summary>
        public System.Int32? StatusNo { get; set; }
        /// <summary>
        /// Closed
        /// </summary>
        public System.Boolean Closed { get; set; }
        /// <summary>
        /// SaleTypeNo
        /// </summary>
        public System.Int32? SaleTypeNo { get; set; }
        /// <summary>
        /// Salesman2
        /// </summary>
        public System.Int32? Salesman2 { get; set; }
        /// <summary>
        /// Salesman2Percent
        /// </summary>
        public System.Double Salesman2Percent { get; set; }
        /// <summary>
        /// AuthorisedBy
        /// </summary>
        public System.Int32? AuthorisedBy { get; set; }
        /// <summary>
        /// DateAuthorised
        /// </summary>
        public System.DateTime? DateAuthorised { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime DLUP { get; set; }
        /// <summary>
        /// CurrencyDate
        /// </summary>
        public System.DateTime? CurrencyDate { get; set; }
        /// <summary>
        /// IncotermNo
        /// </summary>
        public System.Int32? IncotermNo { get; set; }
        /// <summary>
        /// CreatedBy
        /// </summary>
        public System.Int32? CreatedBy { get; set; }
        /// <summary>
        /// CreateDate
        /// </summary>
        public System.DateTime? CreateDate { get; set; }
        /// <summary>
        /// CompanyName
        /// </summary>
        public System.String CompanyName { get; set; }
        /// <summary>
        /// ContactName
        /// </summary>
        public System.String ContactName { get; set; }
        /// <summary>
        /// SalesmanName
        /// </summary>
        public System.String SalesmanName { get; set; }
        /// <summary>
        /// RowNum
        /// </summary>
        public System.Int64? RowNum { get; set; }
        /// <summary>
        /// RowCnt
        /// </summary>
        public System.Int32? RowCnt { get; set; }
        /// <summary>
        /// ShippingCharge
        /// </summary>
        public System.Boolean? ShippingCharge { get; set; }
        /// <summary>
        /// CreditLimit
        /// </summary>
        public System.Double CreditLimit { get; set; }
        /// <summary>
        /// Balance
        /// </summary>
        public System.Double Balance { get; set; }
        /// <summary>
        /// CustomerCode
        /// </summary>
        public System.String CustomerCode { get; set; }
        /// <summary>
        /// VATNo
        /// </summary>
        public System.String VATNo { get; set; }
        /// <summary>
        /// SOCurrencyNo
        /// </summary>
        public System.Int32 SOCurrencyNo { get; set; }
        /// <summary>
        /// SOCurrencyCode
        /// </summary>
        public System.String SOCurrencyCode { get; set; }
        /// <summary>
        /// SOCurrencyDescription
        /// </summary>
        public System.String SOCurrencyDescription { get; set; }
        /// <summary>
        /// CurrencyCode
        /// </summary>
        public System.String CurrencyCode { get; set; }
        /// <summary>
        /// CurrencyDescription
        /// </summary>
        public System.String CurrencyDescription { get; set; }
        /// <summary>
        /// Salesman2Name
        /// </summary>
        public System.String Salesman2Name { get; set; }
        /// <summary>
        /// TeamNo
        /// </summary>
        public System.Int32? TeamNo { get; set; }
        /// <summary>
        /// Team2No
        /// </summary>
        public System.Int32? Team2No { get; set; }
        /// <summary>
        /// TermsName
        /// </summary>
        public System.String TermsName { get; set; }
        /// <summary>
        /// InAdvance
        /// </summary>
        public System.Boolean? InAdvance { get; set; }
        /// <summary>
        /// ShipViaName
        /// </summary>
        public System.String ShipViaName { get; set; }
        /// <summary>
        /// PickUp
        /// </summary>
        public System.String PickUp { get; set; }
        /// <summary>
        /// DivisionName
        /// </summary>
        public System.String DivisionName { get; set; }
        /// <summary>
        /// TaxName
        /// </summary>
        public System.String TaxName { get; set; }
        /// <summary>
        /// TaxRate
        /// </summary>
        public System.Double? TaxRate { get; set; }
        /// <summary>
        /// Authoriser
        /// </summary>
        public System.String Authoriser { get; set; }
        /// <summary>
        /// CompanyOnStop
        /// </summary>
        public System.Boolean? CompanyOnStop { get; set; }
        /// <summary>
        /// IncotermName
        /// </summary>
        public System.String IncotermName { get; set; }
        /// <summary>
        /// LineSubTotal
        /// </summary>
        public System.Double? LineSubTotal { get; set; }
        /// <summary>
        /// TotalTax
        /// </summary>
        public System.Double? TotalTax { get; set; }
        /// <summary>
        /// TotalValue
        /// </summary>
        public System.Double? TotalValue { get; set; }
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
        /// SalesOrderValue
        /// </summary>
        public System.Double? SalesOrderValue { get; set; }
        /// <summary>
        /// SalesOrderValueIncFreight
        /// </summary>
        public System.Double? SalesOrderValueIncFreight { get; set; }
        /// <summary>
        /// CompanyId
        /// </summary>
        public System.Int32 CompanyId { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        public System.Int32 Quantity { get; set; }
        /// <summary>
        /// QuantityAllocated
        /// </summary>
        public System.Int32 QuantityAllocated { get; set; }
        /// <summary>
        /// DatePromised
        /// </summary>
        public System.DateTime DatePromised { get; set; }
        /// <summary>
        /// DaysOverdue
        /// </summary>
        public System.Int32? DaysOverdue { get; set; }
        /// <summary>
        /// InvoiceId
        /// </summary>
        public System.Int32 InvoiceId { get; set; }
        /// <summary>
        /// InvoiceNumber
        /// </summary>
        public System.Int32 InvoiceNumber { get; set; }
        /// <summary>
        /// InvoiceLineId
        /// </summary>
        public System.Int32? InvoiceLineId { get; set; }
        /// <summary>
        /// InvoiceDate
        /// </summary>
        public System.DateTime InvoiceDate { get; set; }
        /// <summary>
        /// SupplierRMANumber
        /// </summary>
        public System.Int32? SupplierRMANumber { get; set; }
        /// <summary>
        /// SalesOrderNo
        /// </summary>
        public System.Int32? SalesOrderNo { get; set; }
        /// <summary>
        /// SalesOrderLineNo
        /// </summary>
        public System.Int32? SalesOrderLineNo { get; set; }
        /// <summary>
        /// FullCompanyName
        /// </summary>
        public System.String FullCompanyName { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public System.Double? Price { get; set; }
        /// <summary>
        /// FullPart
        /// </summary>
        public System.String FullPart { get; set; }
        /// <summary>
        /// FullCustomerPart
        /// </summary>
        public System.String FullCustomerPart { get; set; }
        /// <summary>
        /// Part
        /// </summary>
        public System.String Part { get; set; }
        /// <summary>
        /// ROHS
        /// </summary>
        public System.Byte ROHS { get; set; }
        /// <summary>
        /// CustomerPart
        /// </summary>
        public System.String CustomerPart { get; set; }
        /// <summary>
        /// DateCode
        /// </summary>
        public System.String DateCode { get; set; }
        /// <summary>
        /// InvoicePaid
        /// </summary>
        public System.Boolean InvoicePaid { get; set; }
        /// <summary>
        /// Inactive
        /// </summary>
        public System.Boolean? Inactive { get; set; }
        /// <summary>
        /// Company registration no
        /// </summary>
        public System.String CompanyRegNo { get; set; }
        // [001] code start
        /// <summary>
        /// IsPDFAvailable
        /// </summary>
        public System.Boolean? IsPDFAvailable { get; set; }
        // [001] code end

        //[002] code start
        /// <summary>
        /// CurrencyNotes
        /// </summary>
        public System.String CurrencyNotes { get; set; }
        //[002] code end

        //[003] code start
        public System.Double? InvoiceBankFee { get; set; }
        public System.Boolean? IsApplyBankFee { get; set; }
        //[003] code end

        // [004] code start
        /// <summary>
        /// IsSORPDFAvailable
        /// </summary>
        public System.Boolean? IsSORPDFAvailable { get; set; }
        // [004] code end
        //[005] code start
        /// <summary>
        /// AS9120
        /// </summary>
        public System.Boolean? AS9120 { get; set; }
        //[005] code end
        /// <summary>
        /// CompanyType
        /// </summary>
        public System.String CompanyType { get; set; }
        /// <summary>
        /// Traceability
        /// </summary>
        public System.Boolean? Traceability { get; set; }
        /// <summary>
        /// IsSameAsShipCost
        /// </summary>
        public System.Boolean? IsSameAsShipCost { get; set; }

        public List<SalesOrderLineDetails> SalesOrderLineDetails { get; set; }

        public int? SalesMan { get; set; }

        public DateTime? OriginalEntryDate { get; set; }

        public int? ClientCurrencyNo { get; set; }

        public bool IsFromIPO { get; set; }

        /// <summary>
        /// IsAgency
        /// </summary>
        public System.Boolean? IsAgency { get; set; }
        /// <summary>
        /// UKAuthorisedBy
        /// </summary>
        public System.Int32? UKAuthorisedBy { get; set; }
        /// <summary>
        /// UKAuthorisedDate
        /// </summary>
        public System.DateTime? UKAuthorisedDate { get; set; }
        /// <summary>
        /// UKAuthoriserName
        /// </summary>
        public System.String UKAuthoriserName { get; set; }
        /// <summary>
        /// IsCurrencyInSameFaimly
        /// </summary>
        public System.Boolean? IsCurrencyInSameFaimly { get; set; }

        public System.String ConsolidateStatus { get; set; }

        public System.Boolean? IsConsolidated { get; set; }

        public System.String ClientName { get; set; }
        public System.Int32? SentOrderValue { get; set; }
        public System.Double? ActualCreditLimit { get; set; }
        /// <summary>
        /// SalesOrderNumberDetail
        /// </summary>
        //[006] start
        public System.String SalesOrderNumberDetail { get; set; }
        //[006] end

        //[006] start
        public System.Double? AvailableCreditLimit { get; set; }
        public System.String RowCSS { get; set; }
        
        //[008] start
        public System.Boolean IsPaidByCreditCard { get; set; }
        //[008] end
        
        #endregion

        #region Methods

        /// <summary>
        /// CountForClient
        /// Calls [usp_count_SalesOrder_for_Client]
        /// </summary>
        public static Int32 CountForClient(System.Int32? clientId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.CountForClient(clientId);
        }		/// <summary>
        /// CountForCompany
        /// Calls [usp_count_SalesOrder_for_Company]
        /// </summary>
        public static Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeClosed)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.CountForCompany(companyId, includeClosed);
        }		/// <summary>
        /// CountOpenForCompany
        /// Calls [usp_count_SalesOrder_open_for_Company]
        /// </summary>
        public static Int32 CountOpenForCompany(System.Int32? companyId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.CountOpenForCompany(companyId);
        }		/// <summary>
        /// CountShippingForClient
        /// Calls [usp_count_SalesOrder_shipping_for_Client]
        /// </summary>
        public static Int32 CountShippingForClient(System.Int32? clientId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.CountShippingForClient(clientId);
        }		/// <summary>
        /// Delete
        /// Calls [usp_delete_SalesOrder]
        /// </summary>
        public static bool Delete(System.Int32? salesOrderId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.Delete(salesOrderId);
        }
        //[005] code start
        /// <summary>
        /// Insert
        /// Calls [usp_insert_SalesOrder]
        /// </summary>
        public static Int32 Insert(System.Int32? clientNo, System.Int32? companyNo, System.Int32? contactNo, System.DateTime? dateOrdered, System.Int32? currencyNo, System.Int32? salesman, System.Int32? termsNo, System.Int32? shipToAddressNo, System.Int32? shipViaNo, System.String account, System.Double? freight, System.String customerPo, System.Int32? divisionNo, System.Int32? taxNo, System.Double? shippingCost, System.String notes, System.String instructions, System.Boolean? paid, System.Int32? statusNo, System.Boolean? closed, System.Int32? salesman2, System.Double? salesman2Percent, System.Int32? incotermNo, System.Int32? authorisedBy, System.DateTime? dateAuthorised, System.Int32? updatedBy, System.Boolean? As9120)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.Insert(clientNo, companyNo, contactNo, dateOrdered, currencyNo, salesman, termsNo, shipToAddressNo, shipViaNo, account, freight, customerPo, divisionNo, taxNo, shippingCost, notes, instructions, paid, statusNo, closed, salesman2, salesman2Percent, incotermNo, authorisedBy, dateAuthorised, updatedBy, As9120);
            return objReturn;
        }

        /// <summary>
        /// Insert (without parameters)
        /// Calls [usp_insert_SalesOrder]
        /// </summary>
        public Int32 Insert()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.Insert(ClientNo, CompanyNo, ContactNo, DateOrdered, CurrencyNo, Salesman, TermsNo, ShipToAddressNo, ShipViaNo, Account, Freight, CustomerPO, DivisionNo, TaxNo, ShippingCost, Notes, Instructions, Paid, StatusNo, Closed, Salesman2, Salesman2Percent, IncotermNo, AuthorisedBy, DateAuthorised, UpdatedBy, AS9120);
        }
        //[005] code end
        /// <summary>
        /// ItemSearch
        /// Calls [usp_itemsearch_SalesOrder]
        /// </summary>
        public static List<SalesOrder> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String customerPoSearch, System.Boolean? includeClosed, System.Int32? salesOrderNoLo, System.Int32? salesOrderNoHi, System.DateTime? dateOrderedFrom, System.DateTime? dateOrderedTo)
        {
            List<SalesOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, contactSearch, cmSearch, salesmanSearch, customerPoSearch, includeClosed, salesOrderNoLo, salesOrderNoHi, dateOrderedFrom, dateOrderedTo);
            if (lstDetails == null)
            {
                return new List<SalesOrder>();
            }
            else
            {
                List<SalesOrder> lst = new List<SalesOrder>();
                foreach (SalesOrderDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrder obj = new Rebound.GlobalTrader.BLL.SalesOrder();
                    obj.SalesOrderId = objDetails.SalesOrderId;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.RowNum = objDetails.RowNum;
                    obj.RowCnt = objDetails.RowCnt;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Get
        /// Calls [usp_select_SalesOrder]
        /// </summary>
        public static SalesOrder Get(System.Int32? salesOrderId)
        {
            Rebound.GlobalTrader.DAL.SalesOrderDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.Get(salesOrderId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SalesOrder obj = new SalesOrder();
                obj.SalesOrderId = objDetails.SalesOrderId;
                obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                obj.ClientNo = objDetails.ClientNo;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ContactNo = objDetails.ContactNo;
                obj.DateOrdered = objDetails.DateOrdered;
                obj.CurrencyDate = objDetails.CurrencyDate;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.Salesman = objDetails.Salesman;
                obj.TermsNo = objDetails.TermsNo;
                obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                obj.ShipViaNo = objDetails.ShipViaNo;
                obj.Account = objDetails.Account;
                obj.Freight = objDetails.Freight;
                obj.CustomerPO = objDetails.CustomerPO;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.TaxNo = objDetails.TaxNo;
                obj.ShippingCost = objDetails.ShippingCost;
                obj.Notes = objDetails.Notes;
                obj.Instructions = objDetails.Instructions;
                obj.Paid = objDetails.Paid;
                obj.Closed = objDetails.Closed;
                obj.SaleTypeNo = objDetails.SaleTypeNo;
                obj.Salesman2 = objDetails.Salesman2;
                obj.Salesman2Percent = objDetails.Salesman2Percent;
                obj.AuthorisedBy = objDetails.AuthorisedBy;
                obj.DateAuthorised = objDetails.DateAuthorised;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.CompanyName = objDetails.CompanyName;
                obj.ShippingCharge = objDetails.ShippingCharge;
                obj.CreditLimit = objDetails.CreditLimit;
                obj.Balance = objDetails.Balance;
                obj.CustomerCode = objDetails.CustomerCode;
                obj.VATNo = objDetails.VATNo;
                obj.SOCurrencyNo = objDetails.SOCurrencyNo;
                obj.SOCurrencyCode = objDetails.SOCurrencyCode;
                obj.SOCurrencyDescription = objDetails.SOCurrencyDescription;
                obj.ContactName = objDetails.ContactName;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.SalesmanName = objDetails.SalesmanName;
                obj.Salesman2Name = objDetails.Salesman2Name;
                obj.TeamNo = objDetails.TeamNo;
                obj.Team2No = objDetails.Team2No;
                obj.TermsName = objDetails.TermsName;
                obj.InAdvance = objDetails.InAdvance;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.PickUp = objDetails.PickUp;
                obj.DivisionName = objDetails.DivisionName;
                obj.TaxName = objDetails.TaxName;
                obj.TaxRate = objDetails.TaxRate;
                obj.Authoriser = objDetails.Authoriser;
                obj.StatusNo = objDetails.StatusNo;
                obj.CompanyOnStop = objDetails.CompanyOnStop;
                obj.IncotermNo = objDetails.IncotermNo;
                obj.IncotermName = objDetails.IncotermName;
                obj.LineSubTotal = objDetails.LineSubTotal;
                obj.TotalTax = objDetails.TotalTax;
                obj.TotalValue = objDetails.TotalValue;
                //[005] code start
                obj.AS9120 = objDetails.AS9120;
                //[005] code end
                obj.IsSameAsShipCost = objDetails.IsSameAsShipCost;
                obj.IsCurrencyInSameFaimly = objDetails.IsCurrencyInSameFaimly;
                obj.IsConsolidated = objDetails.IsConsolidated;
                obj.SentOrderValue = objDetails.SentOrder;
                obj.ActualCreditLimit = objDetails.ActualCreditLimit;
                //[008] start
                obj.IsPaidByCreditCard = objDetails.IsPaidByCreditCard;
                //[008] end
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetByNumber
        /// Calls [usp_select_SalesOrder_by_Number]
        /// </summary>
        public static SalesOrder GetByNumber(System.Int32? salesOrderNumber, System.Int32? clientNo)
        {
            Rebound.GlobalTrader.DAL.SalesOrderDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetByNumber(salesOrderNumber, clientNo);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SalesOrder obj = new SalesOrder();
                obj.SalesOrderId = objDetails.SalesOrderId;
                obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                obj.ClientNo = objDetails.ClientNo;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ContactNo = objDetails.ContactNo;
                obj.DateOrdered = objDetails.DateOrdered;
                obj.CurrencyDate = objDetails.CurrencyDate;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.Salesman = objDetails.Salesman;
                obj.TermsNo = objDetails.TermsNo;
                obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                obj.ShipViaNo = objDetails.ShipViaNo;
                obj.Account = objDetails.Account;
                obj.Freight = objDetails.Freight;
                obj.CustomerPO = objDetails.CustomerPO;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.TaxNo = objDetails.TaxNo;
                obj.ShippingCost = objDetails.ShippingCost;
                obj.Notes = objDetails.Notes;
                obj.Instructions = objDetails.Instructions;
                obj.Paid = objDetails.Paid;
                obj.Closed = objDetails.Closed;
                obj.SaleTypeNo = objDetails.SaleTypeNo;
                obj.Salesman2 = objDetails.Salesman2;
                obj.Salesman2Percent = objDetails.Salesman2Percent;
                obj.AuthorisedBy = objDetails.AuthorisedBy;
                obj.DateAuthorised = objDetails.DateAuthorised;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.CompanyName = objDetails.CompanyName;
                obj.ShippingCharge = objDetails.ShippingCharge;
                obj.CreditLimit = objDetails.CreditLimit;
                obj.Balance = objDetails.Balance;
                obj.CustomerCode = objDetails.CustomerCode;
                obj.VATNo = objDetails.VATNo;
                obj.SOCurrencyNo = objDetails.SOCurrencyNo;
                obj.SOCurrencyCode = objDetails.SOCurrencyCode;
                obj.SOCurrencyDescription = objDetails.SOCurrencyDescription;
                obj.ContactName = objDetails.ContactName;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.SalesmanName = objDetails.SalesmanName;
                obj.Salesman2Name = objDetails.Salesman2Name;
                obj.TeamNo = objDetails.TeamNo;
                obj.Team2No = objDetails.Team2No;
                obj.TermsName = objDetails.TermsName;
                obj.InAdvance = objDetails.InAdvance;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.PickUp = objDetails.PickUp;
                obj.DivisionName = objDetails.DivisionName;
                obj.TaxName = objDetails.TaxName;
                obj.TaxRate = objDetails.TaxRate;
                obj.Authoriser = objDetails.Authoriser;
                obj.StatusNo = objDetails.StatusNo;
                obj.CompanyOnStop = objDetails.CompanyOnStop;
                obj.IncotermNo = objDetails.IncotermNo;
                obj.IncotermName = objDetails.IncotermName;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetDetailsForLineCalculations
        /// Calls [usp_select_SalesOrder_DetailsForLineCalculations]
        /// </summary>
        public static SalesOrder GetDetailsForLineCalculations(System.Int32? salesOrderId)
        {
            Rebound.GlobalTrader.DAL.SalesOrderDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetDetailsForLineCalculations(salesOrderId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SalesOrder obj = new SalesOrder();
                obj.Paid = objDetails.Paid;
                obj.Balance = objDetails.Balance;
                obj.Freight = objDetails.Freight;
                obj.TaxRate = objDetails.TaxRate;
                obj.CreditLimit = objDetails.CreditLimit;
                obj.CurrencyCode = objDetails.CurrencyCode;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetForPage
        /// Calls [usp_select_SalesOrder_for_Page]
        /// </summary>
        public static SalesOrder GetForPage(System.Int32? salesOrderId)
        {
            Rebound.GlobalTrader.DAL.SalesOrderDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetForPage(salesOrderId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SalesOrder obj = new SalesOrder();
                obj.SalesOrderId = objDetails.SalesOrderId;
                obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                obj.ClientNo = objDetails.ClientNo;
                obj.CompanyName = objDetails.CompanyName;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.StatusNo = objDetails.StatusNo;
                // [001] code start
                obj.IsPDFAvailable = objDetails.IsPDFAvailable;
                // [001] code end
                obj.TeamNo = objDetails.TeamNo;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.Salesman = objDetails.Salesman;
                obj.IsSORPDFAvailable = objDetails.IsSORPDFAvailable;
                obj.IsFromIPO = objDetails.IsFromIPO;
                obj.ConsolidateStatus = objDetails.ConsolidateStatus;
                obj.ClientName = objDetails.ClientName;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetForPrint
        /// Calls [usp_select_SalesOrder_for_Print]
        /// </summary>
        public static SalesOrder GetForPrint(System.Int32? salesOrderId)
        {
            Rebound.GlobalTrader.DAL.SalesOrderDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetForPrint(salesOrderId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SalesOrder obj = new SalesOrder();
                obj.SalesOrderId = objDetails.SalesOrderId;
                obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                obj.ClientNo = objDetails.ClientNo;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ContactNo = objDetails.ContactNo;
                obj.DateOrdered = objDetails.DateOrdered;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.Salesman = objDetails.Salesman;
                obj.TermsNo = objDetails.TermsNo;
                obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                obj.ShipViaNo = objDetails.ShipViaNo;
                obj.Account = objDetails.Account;
                obj.Freight = objDetails.Freight;
                obj.CustomerPO = objDetails.CustomerPO;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.TaxNo = objDetails.TaxNo;
                obj.ShippingCost = objDetails.ShippingCost;
                obj.Notes = objDetails.Notes;
                obj.Instructions = objDetails.Instructions;
                obj.Paid = objDetails.Paid;
                obj.StatusNo = objDetails.StatusNo;
                obj.Closed = objDetails.Closed;
                obj.SaleTypeNo = objDetails.SaleTypeNo;
                obj.Salesman2 = objDetails.Salesman2;
                obj.Salesman2Percent = objDetails.Salesman2Percent;
                obj.AuthorisedBy = objDetails.AuthorisedBy;
                obj.DateAuthorised = objDetails.DateAuthorised;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.CurrencyDate = objDetails.CurrencyDate;
                obj.IncotermNo = objDetails.IncotermNo;
                obj.CreatedBy = objDetails.CreatedBy;
                obj.CreateDate = objDetails.CreateDate;
                obj.CompanyName = objDetails.CompanyName;
                obj.CustomerCode = objDetails.CustomerCode;
                obj.CompanyTelephone = objDetails.CompanyTelephone;
                obj.CompanyFax = objDetails.CompanyFax;
                obj.ShippingCharge = objDetails.ShippingCharge;
                obj.ContactName = objDetails.ContactName;
                obj.ContactEmail = objDetails.ContactEmail;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.SalesmanName = objDetails.SalesmanName;
                obj.TermsName = objDetails.TermsName;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.TaxName = objDetails.TaxName;
                obj.TaxRate = objDetails.TaxRate;
                obj.Closed = objDetails.Closed;
                obj.DateAuthorised = objDetails.DateAuthorised;
                obj.AuthorisedBy = objDetails.AuthorisedBy;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.LineSubTotal = objDetails.LineSubTotal;
                obj.TotalTax = objDetails.TotalTax;
                obj.TotalValue = objDetails.TotalValue;
                obj.IncotermName = objDetails.IncotermName;
                obj.Salesman2Name = objDetails.Salesman2Name;
                obj.CompanyRegNo = objDetails.CompanyRegNo;
                //[002] code start
                obj.CurrencyNotes = objDetails.CurrencyNotes;
                //[002] code end
                //[003] code start
                obj.IsApplyBankFee = objDetails.IsApplyBankFee;
                obj.InvoiceBankFee = objDetails.InvoiceBankFee;
                //[003] code end
                obj.VATNo = objDetails.VATNo;
                //[005] code start
                obj.AS9120 = objDetails.AS9120;
                //[005] code end
                obj.CompanyType = objDetails.CompanyType;
                obj.Traceability = objDetails.Traceability;

                obj.IsAgency = objDetails.IsAgency;
                obj.UKAuthorisedBy = objDetails.UKAuthorisedBy;
                obj.UKAuthorisedDate = objDetails.UKAuthorisedDate;
                obj.UKAuthoriserName = objDetails.UKAuthoriserName;
                obj.CompanyOnStop = objDetails.CompanyOnStop;
                obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetIDByNumber
        /// Calls [usp_select_SalesOrder_ID_by_Number]
        /// </summary>
        public static List<SalesOrder> GetIDByNumber(System.Int32? salesOrderNumber, System.Int32? clientNo, System.Int32? isGlobalUser)
        {
            //[006] start
            List<Rebound.GlobalTrader.DAL.SalesOrderDetails> lstSOD = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetIDByNumber(salesOrderNumber, clientNo, isGlobalUser);
            List<SalesOrder> lstSO = new List<SalesOrder>();
            foreach (SalesOrderDetails sod in lstSOD)
            {
                SalesOrder so = new SalesOrder();
                so.SalesOrderId = sod.SalesOrderId;
                so.SalesOrderNumberDetail = sod.SalesOrderNumberDetail;
                lstSO.Add(so);
            }
            return lstSO;
            //[006] end
        }
        /// <summary>
        /// GetNextNumber
        /// Calls [usp_select_SalesOrder_NextNumber]
        /// </summary>
        public static SalesOrder GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy)
        {
            Rebound.GlobalTrader.DAL.SalesOrderDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetNextNumber(clientNo, updatedBy);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SalesOrder obj = new SalesOrder();
                obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetOpenLineSummaryValues
        /// Calls [usp_select_SalesOrder_OpenLineSummaryValues]
        /// </summary>
        public static SalesOrder GetOpenLineSummaryValues(System.Int32? salesOrderId)
        {
            Rebound.GlobalTrader.DAL.SalesOrderDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetOpenLineSummaryValues(salesOrderId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SalesOrder obj = new SalesOrder();
                obj.SalesOrderId = objDetails.SalesOrderId;
                obj.LineSubTotal = objDetails.LineSubTotal;
                obj.Freight = objDetails.Freight;
                obj.TotalTax = objDetails.TotalTax;
                obj.TotalValue = objDetails.TotalValue;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.DateOrdered = objDetails.DateOrdered;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetStatus
        /// Calls [usp_select_SalesOrder_Status]
        /// </summary>
        public static SalesOrder GetStatus(System.Int32? salesOrderId)
        {
            Rebound.GlobalTrader.DAL.SalesOrderDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetStatus(salesOrderId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SalesOrder obj = new SalesOrder();
                obj.StatusNo = objDetails.StatusNo;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetSummaryValues
        /// Calls [usp_select_SalesOrder_SummaryValues]
        /// </summary>
        public static SalesOrder GetSummaryValues(System.Int32? salesOrderId)
        {
            Rebound.GlobalTrader.DAL.SalesOrderDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetSummaryValues(salesOrderId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SalesOrder obj = new SalesOrder();
                obj.SalesOrderId = objDetails.SalesOrderId;
                obj.LineSubTotal = objDetails.LineSubTotal;
                obj.Freight = objDetails.Freight;
                obj.TotalTax = objDetails.TotalTax;
                obj.TotalValue = objDetails.TotalValue;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.DateOrdered = objDetails.DateOrdered;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetValueSummary
        /// Calls [usp_select_SalesOrder_ValueSummary]
        /// </summary>
        public static SalesOrder GetValueSummary(System.Int32? salesOrderId)
        {
            Rebound.GlobalTrader.DAL.SalesOrderDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetValueSummary(salesOrderId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SalesOrder obj = new SalesOrder();
                obj.SalesOrderId = objDetails.SalesOrderId;
                obj.SalesOrderValue = objDetails.SalesOrderValue;
                obj.SalesOrderValueIncFreight = objDetails.SalesOrderValueIncFreight;
                obj.CurrencyNo = objDetails.CurrencyNo;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetListForCompany
        /// Calls [usp_selectAll_SalesOrder_for_Company]
        /// </summary>
        public static List<SalesOrder> GetListForCompany(System.Int32? companyId, System.Boolean? includeClosed)
        {
            List<SalesOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetListForCompany(companyId, includeClosed);
            if (lstDetails == null)
            {
                return new List<SalesOrder>();
            }
            else
            {
                List<SalesOrder> lst = new List<SalesOrder>();
                foreach (SalesOrderDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrder obj = new Rebound.GlobalTrader.BLL.SalesOrder();
                    obj.SalesOrderId = objDetails.SalesOrderId;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.CurrencyDate = objDetails.CurrencyDate;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.Salesman = objDetails.Salesman;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                    obj.ShipViaNo = objDetails.ShipViaNo;
                    obj.Account = objDetails.Account;
                    obj.Freight = objDetails.Freight;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TaxNo = objDetails.TaxNo;
                    obj.ShippingCost = objDetails.ShippingCost;
                    obj.Notes = objDetails.Notes;
                    obj.Instructions = objDetails.Instructions;
                    obj.Paid = objDetails.Paid;
                    obj.Closed = objDetails.Closed;
                    obj.SaleTypeNo = objDetails.SaleTypeNo;
                    obj.Salesman2 = objDetails.Salesman2;
                    obj.Salesman2Percent = objDetails.Salesman2Percent;
                    obj.AuthorisedBy = objDetails.AuthorisedBy;
                    obj.DateAuthorised = objDetails.DateAuthorised;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.ShippingCharge = objDetails.ShippingCharge;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.Balance = objDetails.Balance;
                    obj.CustomerCode = objDetails.CustomerCode;
                    obj.VATNo = objDetails.VATNo;
                    obj.SOCurrencyNo = objDetails.SOCurrencyNo;
                    obj.SOCurrencyCode = objDetails.SOCurrencyCode;
                    obj.SOCurrencyDescription = objDetails.SOCurrencyDescription;
                    obj.ContactName = objDetails.ContactName;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.Salesman2Name = objDetails.Salesman2Name;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.Team2No = objDetails.Team2No;
                    obj.TermsName = objDetails.TermsName;
                    obj.InAdvance = objDetails.InAdvance;
                    obj.ShipViaName = objDetails.ShipViaName;
                    obj.PickUp = objDetails.PickUp;
                    obj.DivisionName = objDetails.DivisionName;
                    obj.TaxName = objDetails.TaxName;
                    obj.TaxRate = objDetails.TaxRate;
                    obj.Authoriser = objDetails.Authoriser;
                    obj.StatusNo = objDetails.StatusNo;
                    obj.CompanyOnStop = objDetails.CompanyOnStop;
                    obj.IncotermNo = objDetails.IncotermNo;
                    obj.IncotermName = objDetails.IncotermName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListOpenForCompany
        /// Calls [usp_selectAll_SalesOrder_open_for_Company]
        /// </summary>
        public static List<SalesOrder> GetListOpenForCompany(System.Int32? companyId)
        {
            List<SalesOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetListOpenForCompany(companyId);
            if (lstDetails == null)
            {
                return new List<SalesOrder>();
            }
            else
            {
                List<SalesOrder> lst = new List<SalesOrder>();
                foreach (SalesOrderDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrder obj = new Rebound.GlobalTrader.BLL.SalesOrder();
                    obj.SalesOrderId = objDetails.SalesOrderId;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.CurrencyDate = objDetails.CurrencyDate;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.Salesman = objDetails.Salesman;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                    obj.ShipViaNo = objDetails.ShipViaNo;
                    obj.Account = objDetails.Account;
                    obj.Freight = objDetails.Freight;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TaxNo = objDetails.TaxNo;
                    obj.ShippingCost = objDetails.ShippingCost;
                    obj.Notes = objDetails.Notes;
                    obj.Instructions = objDetails.Instructions;
                    obj.Paid = objDetails.Paid;
                    obj.Closed = objDetails.Closed;
                    obj.SaleTypeNo = objDetails.SaleTypeNo;
                    obj.Salesman2 = objDetails.Salesman2;
                    obj.Salesman2Percent = objDetails.Salesman2Percent;
                    obj.AuthorisedBy = objDetails.AuthorisedBy;
                    obj.DateAuthorised = objDetails.DateAuthorised;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.ShippingCharge = objDetails.ShippingCharge;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.Balance = objDetails.Balance;
                    obj.CustomerCode = objDetails.CustomerCode;
                    obj.VATNo = objDetails.VATNo;
                    obj.SOCurrencyNo = objDetails.SOCurrencyNo;
                    obj.SOCurrencyCode = objDetails.SOCurrencyCode;
                    obj.SOCurrencyDescription = objDetails.SOCurrencyDescription;
                    obj.ContactName = objDetails.ContactName;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.Salesman2Name = objDetails.Salesman2Name;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.Team2No = objDetails.Team2No;
                    obj.TermsName = objDetails.TermsName;
                    obj.InAdvance = objDetails.InAdvance;
                    obj.ShipViaName = objDetails.ShipViaName;
                    obj.PickUp = objDetails.PickUp;
                    obj.DivisionName = objDetails.DivisionName;
                    obj.TaxName = objDetails.TaxName;
                    obj.TaxRate = objDetails.TaxRate;
                    obj.Authoriser = objDetails.Authoriser;
                    obj.StatusNo = objDetails.StatusNo;
                    obj.CompanyOnStop = objDetails.CompanyOnStop;
                    obj.IncotermNo = objDetails.IncotermNo;
                    obj.IncotermName = objDetails.IncotermName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListOpenForLogin
        /// Calls [usp_selectAll_SalesOrder_open_for_Login]
        /// </summary>
        public static List<SalesOrder> GetListOpenForLogin(System.Int32? loginId, System.Int32? topToSelect)
        {
            List<SalesOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetListOpenForLogin(loginId, topToSelect);
            if (lstDetails == null)
            {
                return new List<SalesOrder>();
            }
            else
            {
                List<SalesOrder> lst = new List<SalesOrder>();
                foreach (SalesOrderDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrder obj = new Rebound.GlobalTrader.BLL.SalesOrder();
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.CompanyId = objDetails.CompanyId;
                    obj.Quantity = objDetails.Quantity;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.Balance = objDetails.Balance;
                    obj.Salesman = objDetails.Salesman;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.SalesOrderId = objDetails.SalesOrderId;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// GetListOpenForLoginUnProcess
        /// Calls [usp_selectAll_SalesOrder_open_for_Login_UnProcess]
        /// </summary>
        public static List<SalesOrder> GetListOpenForLoginUnProcess(System.Int32? loginId, System.Int32? topToSelect)
        {
            List<SalesOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetListOpenForLoginUnProcess(loginId, topToSelect);
            if (lstDetails == null)
            {
                return new List<SalesOrder>();
            }
            else
            {
                List<SalesOrder> lst = new List<SalesOrder>();
                foreach (SalesOrderDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrder obj = new Rebound.GlobalTrader.BLL.SalesOrder();
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.CompanyId = objDetails.CompanyId;
                    obj.Quantity = objDetails.Quantity;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.Balance = objDetails.Balance;
                    obj.Salesman = objDetails.Salesman;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.SalesOrderId = objDetails.SalesOrderId;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// GetListOverdueForCompany
        /// Calls [usp_selectAll_SalesOrder_overdue_for_Company]
        /// </summary>
        public static List<SalesOrder> GetListOverdueForCompany(System.Int32? companyId)
        {
            List<SalesOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetListOverdueForCompany(companyId);
            if (lstDetails == null)
            {
                return new List<SalesOrder>();
            }
            else
            {
                List<SalesOrder> lst = new List<SalesOrder>();
                foreach (SalesOrderDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrder obj = new Rebound.GlobalTrader.BLL.SalesOrder();
                    obj.SalesOrderId = objDetails.SalesOrderId;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.CurrencyDate = objDetails.CurrencyDate;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.Salesman = objDetails.Salesman;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                    obj.ShipViaNo = objDetails.ShipViaNo;
                    obj.Account = objDetails.Account;
                    obj.Freight = objDetails.Freight;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TaxNo = objDetails.TaxNo;
                    obj.ShippingCost = objDetails.ShippingCost;
                    obj.Notes = objDetails.Notes;
                    obj.Instructions = objDetails.Instructions;
                    obj.Paid = objDetails.Paid;
                    obj.Closed = objDetails.Closed;
                    obj.SaleTypeNo = objDetails.SaleTypeNo;
                    obj.Salesman2 = objDetails.Salesman2;
                    obj.Salesman2Percent = objDetails.Salesman2Percent;
                    obj.AuthorisedBy = objDetails.AuthorisedBy;
                    obj.DateAuthorised = objDetails.DateAuthorised;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.ShippingCharge = objDetails.ShippingCharge;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.Balance = objDetails.Balance;
                    obj.CustomerCode = objDetails.CustomerCode;
                    obj.VATNo = objDetails.VATNo;
                    obj.SOCurrencyNo = objDetails.SOCurrencyNo;
                    obj.SOCurrencyCode = objDetails.SOCurrencyCode;
                    obj.SOCurrencyDescription = objDetails.SOCurrencyDescription;
                    obj.ContactName = objDetails.ContactName;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.Salesman2Name = objDetails.Salesman2Name;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.Team2No = objDetails.Team2No;
                    obj.TermsName = objDetails.TermsName;
                    obj.InAdvance = objDetails.InAdvance;
                    obj.ShipViaName = objDetails.ShipViaName;
                    obj.PickUp = objDetails.PickUp;
                    obj.DivisionName = objDetails.DivisionName;
                    obj.TaxName = objDetails.TaxName;
                    obj.TaxRate = objDetails.TaxRate;
                    obj.Authoriser = objDetails.Authoriser;
                    obj.StatusNo = objDetails.StatusNo;
                    obj.CompanyOnStop = objDetails.CompanyOnStop;
                    obj.IncotermNo = objDetails.IncotermNo;
                    obj.IncotermName = objDetails.IncotermName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListOverdueForLogin
        /// Calls [usp_selectAll_SalesOrder_overdue_for_Login]
        /// </summary>
        public static List<SalesOrder> GetListOverdueForLogin(System.Int32? loginId, System.Int32? topToSelect)
        {
            List<SalesOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetListOverdueForLogin(loginId, topToSelect);
            if (lstDetails == null)
            {
                return new List<SalesOrder>();
            }
            else
            {
                List<SalesOrder> lst = new List<SalesOrder>();
                foreach (SalesOrderDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrder obj = new Rebound.GlobalTrader.BLL.SalesOrder();
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyId = objDetails.CompanyId;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.Balance = objDetails.Balance;
                    obj.Salesman = objDetails.Salesman;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.DaysOverdue = objDetails.DaysOverdue;
                    obj.SalesOrderId = objDetails.SalesOrderId;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }


        /// <summary>
        /// GetListReadyForClient
        /// Calls [usp_selectAll_SalesOrder_ready_for_Client]
        /// </summary>
        public static List<SalesOrder> GetListReadyForClient(System.Int32? clientId, System.Int32? topToSelect)
        {
            List<SalesOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetListReadyForClient(clientId, topToSelect);
            if (lstDetails == null)
            {
                return new List<SalesOrder>();
            }
            else
            {
                List<SalesOrder> lst = new List<SalesOrder>();
                foreach (SalesOrderDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrder obj = new Rebound.GlobalTrader.BLL.SalesOrder();
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.QuantityAllocated = objDetails.QuantityAllocated;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.Balance = objDetails.Balance;
                    obj.Salesman = objDetails.Salesman;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.SalesOrderId = objDetails.SalesOrderId;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListShippedRecentlyForLogin
        /// Calls [usp_selectAll_SalesOrder_shipped_recently_for_Login]
        /// </summary>
        public static List<SalesOrder> GetListShippedRecentlyForLogin(System.Int32? loginId, System.Int32? topToSelect)
        {
            List<SalesOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetListShippedRecentlyForLogin(loginId, topToSelect);
            if (lstDetails == null)
            {
                return new List<SalesOrder>();
            }
            else
            {
                List<SalesOrder> lst = new List<SalesOrder>();
                foreach (SalesOrderDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrder obj = new Rebound.GlobalTrader.BLL.SalesOrder();
                    obj.InvoiceId = objDetails.InvoiceId;
                    obj.InvoiceNumber = objDetails.InvoiceNumber;
                    obj.InvoiceLineId = objDetails.InvoiceLineId;
                    obj.InvoiceDate = objDetails.InvoiceDate;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.SupplierRMANumber = objDetails.SupplierRMANumber;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
                    obj.Salesman = objDetails.Salesman;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.FullCompanyName = objDetails.FullCompanyName;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.Price = objDetails.Price;
                    obj.FullPart = objDetails.FullPart;
                    obj.FullCustomerPart = objDetails.FullCustomerPart;
                    obj.Part = objDetails.Part;
                    obj.ROHS = objDetails.ROHS;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.Quantity = objDetails.Quantity;
                    obj.DateCode = objDetails.DateCode;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.InvoicePaid = objDetails.InvoicePaid;
                    obj.Inactive = objDetails.Inactive;
                    obj.Salesman2 = objDetails.Salesman2;
                    obj.Salesman2Percent = objDetails.Salesman2Percent;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListShippedTodayForClient
        /// Calls [usp_selectAll_SalesOrder_shipped_today_for_Client]
        /// </summary>
        public static List<SalesOrder> GetListShippedTodayForClient(System.Int32? clientId, System.Int32? topToSelect)
        {
            List<SalesOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetListShippedTodayForClient(clientId, topToSelect);
            if (lstDetails == null)
            {
                return new List<SalesOrder>();
            }
            else
            {
                List<SalesOrder> lst = new List<SalesOrder>();
                foreach (SalesOrderDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrder obj = new Rebound.GlobalTrader.BLL.SalesOrder();
                    obj.InvoiceId = objDetails.InvoiceId;
                    obj.InvoiceNumber = objDetails.InvoiceNumber;
                    obj.InvoiceLineId = objDetails.InvoiceLineId;
                    obj.InvoiceDate = objDetails.InvoiceDate;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.SupplierRMANumber = objDetails.SupplierRMANumber;
                    obj.CustomerPO = objDetails.CustomerPO;
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.SalesOrderLineNo = objDetails.SalesOrderLineNo;
                    obj.Salesman = objDetails.Salesman;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.FullCompanyName = objDetails.FullCompanyName;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.Price = objDetails.Price;
                    obj.FullPart = objDetails.FullPart;
                    obj.FullCustomerPart = objDetails.FullCustomerPart;
                    obj.Part = objDetails.Part;
                    obj.ROHS = objDetails.ROHS;
                    obj.CustomerPart = objDetails.CustomerPart;
                    obj.Quantity = objDetails.Quantity;
                    obj.DateCode = objDetails.DateCode;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.InvoicePaid = objDetails.InvoicePaid;
                    obj.Inactive = objDetails.Inactive;
                    obj.Salesman2 = objDetails.Salesman2;
                    obj.Salesman2Percent = objDetails.Salesman2Percent;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        //[005] code start
        /// <summary>
        /// Update
        /// Calls [usp_update_SalesOrder]
        /// </summary>
        public static bool Update(System.Int32? salesOrderId, System.Int32? contactNo, System.Int32? salesman, System.Int32? shipToAddressNo, System.Int32? shipViaNo, System.Int32? termsNo, System.String account, System.Double? freight, System.Double? shippingCost, System.String customerPo, System.Int32? divisionNo, System.String notes, System.String instructions, System.Boolean? paid, System.Int32? statusNo, System.Boolean? closed, System.Int32? saleTypeNo, System.Int32? salesman2, System.Double? salesman2Percent, System.Int32? incotermNo, System.Int32? TaxNo, System.Int32? updatedBy, System.Boolean? As9120, System.Int32? currencyNo)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.Update(salesOrderId, contactNo, salesman, shipToAddressNo, shipViaNo, termsNo, account, freight, shippingCost, customerPo, divisionNo, notes, instructions, paid, statusNo, closed, saleTypeNo, salesman2, salesman2Percent, incotermNo, TaxNo, updatedBy, As9120, currencyNo);
        }

        /// <summary>
        /// Update (without parameters)
        /// Calls [usp_update_SalesOrder]
        /// </summary>
        public bool Update()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.Update(SalesOrderId, ContactNo, Salesman, ShipToAddressNo, ShipViaNo, TermsNo, Account, Freight, ShippingCost, CustomerPO, DivisionNo, Notes, Instructions, Paid, StatusNo, Closed, SaleTypeNo, Salesman2, Salesman2Percent, IncotermNo, TaxNo, UpdatedBy, AS9120, CurrencyNo);
        }
        //[005] code end
        /// <summary>
        /// UpdateAuthorise
        /// Calls [usp_update_SalesOrder_Authorise]
        /// </summary>
        public static bool UpdateAuthorise(System.Int32? salesOrderId, System.Int32? authorisedBy, System.Boolean? authorise)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.UpdateAuthorise(salesOrderId, authorisedBy, authorise);
        }
        /// <summary>
        /// UpdateClose
        /// Calls [usp_update_SalesOrder_Close]
        /// </summary>
        public static bool UpdateClose(System.Int32? salesOrderId, System.Boolean? resetQuantity, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.UpdateClose(salesOrderId, resetQuantity, updatedBy);
        }
        /// <summary>
        /// UpdateFromInvoice
        /// Calls [usp_update_SalesOrder_from_Invoice]
        /// </summary>
        public static bool UpdateFromInvoice(System.Int32? invoiceId, System.Int32? taxNo, System.Int32? currencyNo, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.UpdateFromInvoice(invoiceId, taxNo, currencyNo, updatedBy);
        }
        /// <summary>
        /// UpdateUpdateCurrencyDateOnOpenOrdersForCurrency
        /// Calls [usp_update_SalesOrder_UpdateCurrencyDateOnOpenOrders_for_Currency]
        /// </summary>
        public static bool UpdateUpdateCurrencyDateOnOpenOrdersForCurrency(System.Int32? currencyNo, System.DateTime? currencyDate)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.UpdateUpdateCurrencyDateOnOpenOrdersForCurrency(currencyNo, currencyDate);
        }
        /// <summary>
        /// UpdateAuthoriseAllUnauthorisedOrders
        /// Calls [usp_update_SalesOrder_AuthoriseAllUnauthorisedOrders]
        /// </summary>
        public static bool UpdateAuthoriseAllUnauthorisedOrders(System.Int32? clientNo, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.UpdateAuthoriseAllUnauthorisedOrders(clientNo, updatedBy);
        }


        private static SalesOrder PopulateFromDBDetailsObject(SalesOrderDetails obj)
        {
            SalesOrder objNew = new SalesOrder();
            objNew.SalesOrderId = obj.SalesOrderId;
            objNew.SalesOrderNumber = obj.SalesOrderNumber;
            objNew.ClientNo = obj.ClientNo;
            objNew.CompanyNo = obj.CompanyNo;
            objNew.ContactNo = obj.ContactNo;
            objNew.DateOrdered = obj.DateOrdered;
            objNew.CurrencyNo = obj.CurrencyNo;
            objNew.Salesman = obj.Salesman;
            objNew.TermsNo = obj.TermsNo;
            objNew.ShipToAddressNo = obj.ShipToAddressNo;
            objNew.ShipViaNo = obj.ShipViaNo;
            objNew.Account = obj.Account;
            objNew.Freight = obj.Freight;
            objNew.CustomerPO = obj.CustomerPO;
            objNew.DivisionNo = obj.DivisionNo;
            objNew.TaxNo = obj.TaxNo;
            objNew.ShippingCost = obj.ShippingCost;
            objNew.Notes = obj.Notes;
            objNew.Instructions = obj.Instructions;
            objNew.Paid = obj.Paid;
            objNew.StatusNo = obj.StatusNo;
            objNew.Closed = obj.Closed;
            objNew.SaleTypeNo = obj.SaleTypeNo;
            objNew.Salesman2 = obj.Salesman2;
            objNew.Salesman2Percent = obj.Salesman2Percent;
            objNew.AuthorisedBy = obj.AuthorisedBy;
            objNew.DateAuthorised = obj.DateAuthorised;
            objNew.UpdatedBy = obj.UpdatedBy;
            objNew.DLUP = obj.DLUP;
            objNew.CurrencyDate = obj.CurrencyDate;
            objNew.IncotermNo = obj.IncotermNo;
            objNew.CreatedBy = obj.CreatedBy;
            objNew.CreateDate = obj.CreateDate;
            objNew.CompanyName = obj.CompanyName;
            objNew.ContactName = obj.ContactName;
            objNew.SalesmanName = obj.SalesmanName;
            objNew.RowNum = obj.RowNum;
            objNew.RowCnt = obj.RowCnt;
            objNew.ShippingCharge = obj.ShippingCharge;
            objNew.CreditLimit = obj.CreditLimit;
            objNew.Balance = obj.Balance;
            objNew.CustomerCode = obj.CustomerCode;
            objNew.VATNo = obj.VATNo;
            objNew.SOCurrencyNo = obj.SOCurrencyNo;
            objNew.SOCurrencyCode = obj.SOCurrencyCode;
            objNew.SOCurrencyDescription = obj.SOCurrencyDescription;
            objNew.CurrencyCode = obj.CurrencyCode;
            objNew.CurrencyDescription = obj.CurrencyDescription;
            objNew.Salesman2Name = obj.Salesman2Name;
            objNew.TeamNo = obj.TeamNo;
            objNew.Team2No = obj.Team2No;
            objNew.TermsName = obj.TermsName;
            objNew.InAdvance = obj.InAdvance;
            objNew.ShipViaName = obj.ShipViaName;
            objNew.PickUp = obj.PickUp;
            objNew.DivisionName = obj.DivisionName;
            objNew.TaxName = obj.TaxName;
            objNew.TaxRate = obj.TaxRate;
            objNew.Authoriser = obj.Authoriser;
            objNew.CompanyOnStop = obj.CompanyOnStop;
            objNew.IncotermName = obj.IncotermName;
            objNew.LineSubTotal = obj.LineSubTotal;
            objNew.TotalTax = obj.TotalTax;
            objNew.TotalValue = obj.TotalValue;
            objNew.CompanyTelephone = obj.CompanyTelephone;
            objNew.CompanyFax = obj.CompanyFax;
            objNew.ContactEmail = obj.ContactEmail;
            objNew.SalesOrderValue = obj.SalesOrderValue;
            objNew.SalesOrderValueIncFreight = obj.SalesOrderValueIncFreight;
            objNew.CompanyId = obj.CompanyId;
            objNew.Quantity = obj.Quantity;
            objNew.QuantityAllocated = obj.QuantityAllocated;
            objNew.DatePromised = obj.DatePromised;
            objNew.DaysOverdue = obj.DaysOverdue;
            objNew.InvoiceId = obj.InvoiceId;
            objNew.InvoiceNumber = obj.InvoiceNumber;
            objNew.InvoiceLineId = obj.InvoiceLineId;
            objNew.InvoiceDate = obj.InvoiceDate;
            objNew.SupplierRMANumber = obj.SupplierRMANumber;
            objNew.SalesOrderNo = obj.SalesOrderNo;
            objNew.SalesOrderLineNo = obj.SalesOrderLineNo;
            objNew.FullCompanyName = obj.FullCompanyName;
            objNew.Price = obj.Price;
            objNew.FullPart = obj.FullPart;
            objNew.FullCustomerPart = obj.FullCustomerPart;
            objNew.Part = obj.Part;
            objNew.ROHS = obj.ROHS;
            objNew.CustomerPart = obj.CustomerPart;
            objNew.DateCode = obj.DateCode;
            objNew.InvoicePaid = obj.InvoicePaid;
            objNew.Inactive = obj.Inactive;
            return objNew;
        }
        // [001] code start
        /// <summary>
        /// GetListForSalesOrder
        /// Calls [usp_selectAll_StockPDF_for_Stock]
        /// </summary>
        public static List<PDFDocument> GetPDFListForSalesOrder(System.Int32? SalesOrderId, System.String fileType)
        {
            List<PDFDocumentDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetPDFListForSalesOrder(SalesOrderId, fileType);
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
        /// Insert
        /// Calls [usp_insert_SalesOrderPDF]
        /// </summary>
        public static Int32 Insert(System.Int32? SalesOrderId, System.String Caption, System.String FileName, System.Int32? UpdatedBy, System.String FileType)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.Insert(SalesOrderId, Caption, FileName, UpdatedBy, FileType);
            return objReturn;
        }
        /// Delete
        /// Calls [usp_delete_SalesOrderPDF]
        /// </summary>
        public static bool DeleteSalesOrderPDF(System.Int32? SalesOrderPdfId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.DeleteSalesOrderPDF(SalesOrderPdfId);
        }

        // [001] code end
        /// <summary>
        /// Get from : [usp_Get_InvoiceNotExported]
        /// </summary>
        /// <param name="comoanyNo"></param>
        /// <returns></returns>
        public static double GetInvoiceNotExported(System.Int32 comoanyNo)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetInvoiceNotExported(comoanyNo);
        }
        /// <summary>
        /// usp_Validate_ReadyToShipped_Total_Price
        public static Int32 ValidateReadyToShippedPrice(System.Int32 salesOrderID, Array arySoLines, Array aryQuantity, System.Double? freight, Array aryAllocation)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.ValidateReadyToShippedPrice(salesOrderID, ParamsToXml(arySoLines, aryQuantity, aryAllocation), freight);
        }
        private static string ParamsToXml(Array arySoLines, Array aryQuantity, Array aryAllocation)
        {
            System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();

            strBuilder.Append("<SOLines>");
            if (arySoLines.Length > 0)
            {
                for (int i = 0; i < arySoLines.Length; i++)
                {
                    strBuilder.Append("<SOLine>");
                    strBuilder.Append("<ID>");
                    strBuilder.Append(Convert.ToString(arySoLines.GetValue(i)));
                    strBuilder.Append("</ID>");
                    strBuilder.Append("<Quantity>");
                    strBuilder.Append(Convert.ToString(aryQuantity.GetValue(i)));
                    strBuilder.Append("</Quantity>");
                    //add allocation id for validation
                    strBuilder.Append("<allocation>");
                    strBuilder.Append(Convert.ToString(aryAllocation.GetValue(i)));
                    strBuilder.Append("</allocation>");

                    strBuilder.Append("</SOLine>");
                }
            }
            strBuilder.Append("</SOLines>");
            return strBuilder.ToString();
        }

        //private static string ParamsToXml(Array arySerialLine)
        //{
        //    System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();

        //    strBuilder.Append("<SerialNos>");
        //    if (arySerialLine.Length > 0)
        //    {
        //        for (int i = 0; i < arySerialLine.Length; i++)
        //        {
        //            strBuilder.Append("<SerialNo>");
        //            strBuilder.Append("<ID>");
        //            strBuilder.Append(Convert.ToString(arySerialLine.GetValue(i)));
        //            strBuilder.Append("</ID>");
        //            strBuilder.Append("</SerialNo>");
        //        }
        //    }
        //    strBuilder.Append("</SerialNos>");
        //    return strBuilder.ToString();
        //}

        /// <summary>
        /// Get So Line from soID 
        /// Calls [usp_GetSoLines]
        /// </summary>
        public static List<SalesOrderLine> GetSoLines(int salesOrderId)
        {
            List<SalesOrderLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetSoLines(salesOrderId);
            if (lstDetails == null)
            {
                return new List<SalesOrderLine>();
            }
            else
            {
                List<SalesOrderLine> lst = new List<SalesOrderLine>();
                foreach (SalesOrderLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrderLine obj = new Rebound.GlobalTrader.BLL.SalesOrderLine();
                    obj.SalesOrderLineId = objDetails.SalesOrderLineId;
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                    obj.POHubSupplierNo = objDetails.POHubSupplierNo;
                    obj.POQuoteLineNo = objDetails.POQuoteLineNo;
                    obj.Salesman = objDetails.Salesman;
                    obj.SourceingResultAttachedBy = objDetails.SourceingResultAttachedBy;
                    obj.SourceingResultNo = objDetails.SourcingResultNo;
                    obj.EstimatedShippingCost = objDetails.EstimatedShippingCost;
                    obj.DeliveryDate = objDetails.DeliveryDate;
                    obj.OriginalEntryDate = objDetails.OriginalEntryDate;
                    obj.ClientCurrencyNo = objDetails.ClientCurrencyNo;
                    obj.PurchaseBuyCurrencyNo = objDetails.PurchaseBuyCurrencyNo;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.LinkMultiCurrencyNo = objDetails.LinkMultiCurrencyNo;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// UpdateConsolidated
        /// Calls [usp_update_SalesOrder_Consolidated]
        /// </summary>
        public static bool UpdateConsolidated(System.Int32? salesOrderId, System.Int32? consolidateStaus, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.UpdateConsolidated(salesOrderId, consolidateStaus, updatedBy);
        }

        /// <summary>
        /// UpdateConsolidated
        /// Calls [usp_SentOrder]
        /// </summary>
        public static bool SentOrder(System.Int32? salesOrderId, System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.SentOrder(salesOrderId, updatedBy);
        }

        public static Int32 InsertSerialNo(System.String subGroup, System.Int32? serialNo, System.Int32? soLineNo, System.Int32? updatedBy, out System.String validateMessage)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.InsertSerialNo(subGroup, serialNo, soLineNo, updatedBy, out validateMessage);
            return objReturn;
        }


        public static List<GoodsInLine> GetDataGrid(System.Int32? soLineNo, System.Int32? updatedBy)
        {
            List<GoodsInLineDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetDataGrid(soLineNo, updatedBy);
            if (lstDetails == null)
            {
                return new List<GoodsInLine>();
            }
            else
            {
                List<GoodsInLine> lst = new List<GoodsInLine>();
                foreach (GoodsInLineDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.GoodsInLine obj = new Rebound.GlobalTrader.BLL.GoodsInLine();
                    obj.SerialNoId = objDetails.SerialNoId;
                    obj.SerialNo = objDetails.SerialNo;
                    obj.SubGroup = objDetails.SubGroup;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        public static Int32 InsertAllSerialNo(System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.InsertAllSerialNo(updatedBy);
            return objReturn;
        }
        /// <summary>
        /// usp_attach_SerialNo_WithInvoice
        /// </summary>
        /// <param name="strSerialNoIds"></param>
        /// <param name="salesOrderLineNo"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public static bool AttachSerialNo(System.String strSerialNoIds, System.Int32? salesOrderLineNo, System.Int32? allocatedId, System.Int32? updatedBy)
        {
            bool objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.AttachSerialNo(ParamsToXml(strSerialNoIds), salesOrderLineNo, allocatedId, updatedBy);
            return objReturn;
        }

        private static string ParamsToXml(string strSerialNos)
        {
            System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
            string[] Arr = strSerialNos.Split(',');
            strBuilder.Append("<SerialNos>");
            if (Arr.Length > 0)
            {
                foreach (string str in Arr)
                {
                    strBuilder.Append("<Serial>");
                    strBuilder.Append("<ID>");
                    strBuilder.Append(str);
                    strBuilder.Append("</ID>");
                    strBuilder.Append("</Serial>");
                }
            }
            strBuilder.Append("</SerialNos>");
            return strBuilder.ToString();
        }
        //[006] start
        /// <summary>
        /// GetListCustomerOrderValue
        /// Calls [usp_selectAll_Customer_Order_Value]
        /// </summary>
        public static List<SalesOrder> GetListCustomerOrderValue(System.Int32? loginId, System.Int32? clientId)
        {
            List<SalesOrderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetListCustomerOrderValue(loginId, clientId);
            if (lstDetails == null)
            {
                return new List<SalesOrder>();
            }
            else
            {
                List<SalesOrder> lst = new List<SalesOrder>();
                foreach (SalesOrderDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SalesOrder obj = new Rebound.GlobalTrader.BLL.SalesOrder();
                    obj.CompanyName = objDetails.CompanyName;
                    obj.TotalValue = objDetails.TotalValue;
                    obj.AvailableCreditLimit = objDetails.AvailableCreditLimit;
                    obj.RowCSS = objDetails.RowCSS;
                    obj.CompanyNo = objDetails.CompanyNo;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        //[008] start
        public static Int32 SaveSOPaymentInfo(System.Int32 salesOrderNumber, System.String receiptNo, System.String originalFilename,string generatedFilename,System.Int32 createdBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.SaveSOPaymentInfo(salesOrderNumber, receiptNo, originalFilename, generatedFilename, createdBy);
            return objReturn;
        }
        //[008] end
        //[009] start
        public static List<PDFDocument> GetSOPaymentAttachment(System.Int32 SalesOrderId)
        {
            List<PDFDocumentDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SalesOrder.GetSOPaymentAttachment(SalesOrderId);
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
                    //obj.PDFDocumentRefNo = objDetails.PDFDocumentRefNo;
                    obj.GeneratedFileName = objDetails.GeneratedFileName;
                    obj.FileName = objDetails.FileName;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.Caption = objDetails.Caption;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        //[009] end
        #endregion

    }
}
