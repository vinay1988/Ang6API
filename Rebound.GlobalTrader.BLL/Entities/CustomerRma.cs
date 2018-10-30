/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to upload pdf document for customerRMA section
[002]      Vinay           26/07/2012   Add compulsory incoterms field when create Credit and debit note. :ESMS No:- 105
[003]      Aashu Singh     01/06/2018   Quick Jump in Global Warehouse 
[004]      Aashu Singh     26/06/2018   Save internal log for CRMA
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
    public partial class CustomerRma : BizObject
    {

        #region Properties

        protected static DAL.CustomerRmaElement Settings
        {
            get { return Globals.Settings.CustomerRmas; }
        }

        /// <summary>
        /// CustomerRMAId
        /// </summary>
        public System.Int32 CustomerRMAId { get; set; }
        /// <summary>
        /// ClientNo
        /// </summary>
        public System.Int32 ClientNo { get; set; }
        /// <summary>
        /// CustomerRMANumber
        /// </summary>
        public System.Int32 CustomerRMANumber { get; set; }
        /// <summary>
        /// InvoiceNo
        /// </summary>
        public System.Int32? InvoiceNo { get; set; }
        /// <summary>
        /// AuthorisedBy
        /// </summary>
        public System.Int32 AuthorisedBy { get; set; }
        /// <summary>
        /// CustomerRMADate
        /// </summary>
        public System.DateTime CustomerRMADate { get; set; }
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
        /// WarehouseNo
        /// </summary>
        public System.Int32 WarehouseNo { get; set; }
        /// <summary>
        /// CompanyNo
        /// </summary>
        public System.Int32 CompanyNo { get; set; }
        /// <summary>
        /// ContactNo
        /// </summary>
        public System.Int32? ContactNo { get; set; }
        /// <summary>
        /// DivisionNo
        /// </summary>
        public System.Int32 DivisionNo { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime DLUP { get; set; }
        /// <summary>
        /// IncotermNo
        /// </summary>
        public System.Int32? IncotermNo { get; set; }
        /// <summary>
        /// CompanyName
        /// </summary>
        public System.String CompanyName { get; set; }
        /// <summary>
        /// SalesmanName
        /// </summary>
        public System.String SalesmanName { get; set; }
        /// <summary>
        /// AuthoriserName
        /// </summary>
        public System.String AuthoriserName { get; set; }
        /// <summary>
        /// InvoiceNumber
        /// </summary>
        public System.Int32 InvoiceNumber { get; set; }
        /// <summary>
        /// RowNum
        /// </summary>
        public System.Int64? RowNum { get; set; }
        /// <summary>
        /// RowCnt
        /// </summary>
        public System.Int32? RowCnt { get; set; }
        /// <summary>
        /// WarehouseName
        /// </summary>
        public System.String WarehouseName { get; set; }
        /// <summary>
        /// ContactName
        /// </summary>
        public System.String ContactName { get; set; }
        /// <summary>
        /// DivisionName
        /// </summary>
        public System.String DivisionName { get; set; }
        /// <summary>
        /// SalesOrderNo
        /// </summary>
        public System.Int32? SalesOrderNo { get; set; }
        /// <summary>
        /// SalesOrderNumber
        /// </summary>
        public System.Int32 SalesOrderNumber { get; set; }
        /// <summary>
        /// CurrencyNo
        /// </summary>
        public System.Int32 CurrencyNo { get; set; }
        /// <summary>
        /// Salesman
        /// </summary>
        public System.Int32 Salesman { get; set; }
        /// <summary>
        /// CurrencyCode
        /// </summary>
        public System.String CurrencyCode { get; set; }
        /// <summary>
        /// CurrencyDescription
        /// </summary>
        public System.String CurrencyDescription { get; set; }
        /// <summary>
        /// ShipViaName
        /// </summary>
        public System.String ShipViaName { get; set; }
        /// <summary>
        /// TaxNo
        /// </summary>
        public System.Int32 TaxNo { get; set; }
        /// <summary>
        /// TaxName
        /// </summary>
        public System.String TaxName { get; set; }
        /// <summary>
        /// InvoiceDate
        /// </summary>
        public System.DateTime InvoiceDate { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        public System.Int32? Quantity { get; set; }
        /// <summary>
        /// QuantityReceived
        /// </summary>
        public System.Int32? QuantityReceived { get; set; }
        /// <summary>
        /// IncotermName
        /// </summary>
        public System.String IncotermName { get; set; }
        /// <summary>
        /// InvoiceCustomerPO
        /// </summary>
        public System.String InvoiceCustomerPO { get; set; }
        /// <summary>
        /// InvoiceShippingCost
        /// </summary>
        public System.Double? InvoiceShippingCost { get; set; }
        /// <summary>
        /// InvoiceFreight
        /// </summary>
        public System.Double? InvoiceFreight { get; set; }
        /// <summary>
        /// Salesman2
        /// </summary>
        public System.Int32? Salesman2 { get; set; }
        /// <summary>
        /// Salesman2Percent
        /// </summary>
        public System.Double? Salesman2Percent { get; set; }
        /// <summary>
        /// CompanyTelephone
        /// </summary>
        public System.String CompanyTelephone { get; set; }
        /// <summary>
        /// CompanyFax
        /// </summary>
        public System.String CompanyFax { get; set; }
        /// <summary>
        /// CustomerPO
        /// </summary>
        public System.String CustomerPO { get; set; }
        /// <summary>
        /// TermsName
        /// </summary>
        public System.String TermsName { get; set; }
        /// <summary>
        /// ContactEmail
        /// </summary>
        public System.String ContactEmail { get; set; }
        // [001] code start
        /// <summary>
        /// IsPDFAvailable
        /// </summary>
        public System.Boolean? IsPDFAvailable { get; set; }
        // [001] code end
        public System.Int32 TeamNo { get; set; }
        public System.Int32? ClientCustomerRMANo { get; set; }
        public System.Int32? RefNumber { get; set; }
        public System.String ClientName { get; set; }
        public System.Int32? ClientBaseCurrencyID { get; set; }
        public System.String ClientBaseCurrencyCode { get; set; }

        public System.String CustomerRejectionNo { get; set; }
        /// <summary>
        /// CRMANumberDetail (from usp_select_Credit_for_Print)
        /// </summary>
        //[003] start
        public System.String CRMANumberDetail { get; set; }
        //[003] end
        //[004] start
        public System.Int32 CRMAExpediteNotesId { get; set; }
        public System.String EmployeeName { get; set; }
        //[004] end

        #endregion

        #region Methods

        /// <summary>
        /// CountForClient
        /// Calls [usp_count_CustomerRMA_for_Client]
        /// </summary>
        public static Int32 CountForClient(System.Int32? clientId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.CountForClient(clientId);
        }		/// <summary>
        /// CountForCompany
        /// Calls [usp_count_CustomerRMA_for_Company]
        /// </summary>
        public static Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeComplete)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.CountForCompany(companyId, includeComplete);
        }		/// <summary>
        /// CountReceivingForClient
        /// Calls [usp_count_CustomerRMA_receiving_for_Client]
        /// </summary>
        public static Int32 CountReceivingForClient(System.Int32? clientId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.CountReceivingForClient(clientId);
        }		/// <summary>
        /// Delete
        /// Calls [usp_delete_CustomerRMA]
        /// </summary>
        public static bool Delete(System.Int32? customerRmaId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.Delete(customerRmaId);
        }
        /// <summary>
        /// Insert
        /// Calls [usp_insert_CustomerRMA]
        /// </summary>
        public static Int32 Insert(System.Int32? clientNo, System.Int32? invoiceNo, System.Int32? authorisedBy, System.DateTime? customerRmaDate, System.String notes, System.String instructions, System.Int32? shipViaNo, System.String account, System.Int32? warehouseNo, System.Int32? companyNo, System.Int32? contactNo, System.Int32? divisionNo, System.Int32? incotermNo, System.Int32? updatedBy, System.String CustomerRejectionNo)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.Insert(clientNo, invoiceNo, authorisedBy, customerRmaDate, notes, instructions, shipViaNo, account, warehouseNo, companyNo, contactNo, divisionNo, incotermNo, updatedBy, CustomerRejectionNo);
            return objReturn;
        }
        /// <summary>
        /// Insert (without parameters)
        /// Calls [usp_insert_CustomerRMA]
        /// </summary>
        public Int32 Insert()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.Insert(ClientNo, InvoiceNo, AuthorisedBy, CustomerRMADate, Notes, Instructions, ShipViaNo, Account, WarehouseNo, CompanyNo, ContactNo, DivisionNo, IncotermNo, UpdatedBy, CustomerRejectionNo);
        }
        /// <summary>
        /// ItemSearch
        /// Calls [usp_itemsearch_CustomerRMA]
        /// </summary>
        public static List<CustomerRma> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.String crmaNotesSearch, System.Int32? invoiceNoLo, System.Int32? invoiceNoHi, System.Int32? customerRmaNoLo, System.Int32? customerRmaNoHi, System.DateTime? customerRmaDateFrom, System.DateTime? customerRmaDateTo)
        {
            List<CustomerRmaDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, contactSearch, cmSearch, salesmanSearch, crmaNotesSearch, invoiceNoLo, invoiceNoHi, customerRmaNoLo, customerRmaNoHi, customerRmaDateFrom, customerRmaDateTo);
            if (lstDetails == null)
            {
                return new List<CustomerRma>();
            }
            else
            {
                List<CustomerRma> lst = new List<CustomerRma>();
                foreach (CustomerRmaDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.CustomerRma obj = new Rebound.GlobalTrader.BLL.CustomerRma();
                    obj.CustomerRMAId = objDetails.CustomerRMAId;
                    obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.CustomerRMADate = objDetails.CustomerRMADate;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.AuthoriserName = objDetails.AuthoriserName;
                    obj.InvoiceNo = objDetails.InvoiceNo;
                    obj.InvoiceNumber = objDetails.InvoiceNumber;
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
        /// Calls [usp_select_CustomerRMA]
        /// </summary>
        public static CustomerRma Get(System.Int32? customerRmaId)
        {
            Rebound.GlobalTrader.DAL.CustomerRmaDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.Get(customerRmaId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                CustomerRma obj = new CustomerRma();
                obj.CustomerRMAId = objDetails.CustomerRMAId;
                obj.ClientNo = objDetails.ClientNo;
                obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                obj.InvoiceNo = objDetails.InvoiceNo;
                obj.AuthorisedBy = objDetails.AuthorisedBy;
                obj.CustomerRMADate = objDetails.CustomerRMADate;
                obj.Notes = objDetails.Notes;
                obj.Instructions = objDetails.Instructions;
                obj.ShipViaNo = objDetails.ShipViaNo;
                obj.Account = objDetails.Account;
                obj.WarehouseNo = objDetails.WarehouseNo;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ContactNo = objDetails.ContactNo;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.InvoiceNumber = objDetails.InvoiceNumber;
                obj.AuthoriserName = objDetails.AuthoriserName;
                obj.WarehouseName = objDetails.WarehouseName;
                obj.CompanyName = objDetails.CompanyName;
                obj.ContactName = objDetails.ContactName;
                obj.DivisionName = objDetails.DivisionName;
                obj.SalesOrderNo = objDetails.SalesOrderNo;
                obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.Salesman = objDetails.Salesman;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.SalesmanName = objDetails.SalesmanName;
                obj.TaxNo = objDetails.TaxNo;
                obj.TaxName = objDetails.TaxName;
                obj.InvoiceDate = objDetails.InvoiceDate;
                obj.Quantity = objDetails.Quantity;
                obj.QuantityReceived = objDetails.QuantityReceived;
                obj.IncotermNo = objDetails.IncotermNo;
                obj.IncotermName = objDetails.IncotermName;
                obj.ClientCustomerRMANo = objDetails.ClientCustomerRMANo;
                obj.RefNumber = objDetails.RefNumber;
                obj.CustomerRejectionNo = objDetails.CustomerRejectionNo;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetByNumber
        /// Calls [usp_select_CustomerRMA_by_Number]
        /// </summary>
        public static CustomerRma GetByNumber(System.Int32? customerRmaNumber)
        {
            Rebound.GlobalTrader.DAL.CustomerRmaDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.GetByNumber(customerRmaNumber);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                CustomerRma obj = new CustomerRma();
                obj.CustomerRMAId = objDetails.CustomerRMAId;
                obj.ClientNo = objDetails.ClientNo;
                obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                obj.InvoiceNo = objDetails.InvoiceNo;
                obj.AuthorisedBy = objDetails.AuthorisedBy;
                obj.CustomerRMADate = objDetails.CustomerRMADate;
                obj.Notes = objDetails.Notes;
                obj.Instructions = objDetails.Instructions;
                obj.ShipViaNo = objDetails.ShipViaNo;
                obj.Account = objDetails.Account;
                obj.WarehouseNo = objDetails.WarehouseNo;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ContactNo = objDetails.ContactNo;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.InvoiceNumber = objDetails.InvoiceNumber;
                obj.AuthoriserName = objDetails.AuthoriserName;
                obj.WarehouseName = objDetails.WarehouseName;
                obj.CompanyName = objDetails.CompanyName;
                obj.ContactName = objDetails.ContactName;
                obj.DivisionName = objDetails.DivisionName;
                obj.SalesOrderNo = objDetails.SalesOrderNo;
                obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.Salesman = objDetails.Salesman;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.SalesmanName = objDetails.SalesmanName;
                obj.TaxNo = objDetails.TaxNo;
                obj.TaxName = objDetails.TaxName;
                obj.InvoiceDate = objDetails.InvoiceDate;
                obj.Quantity = objDetails.Quantity;
                obj.QuantityReceived = objDetails.QuantityReceived;
                obj.IncotermNo = objDetails.IncotermNo;
                obj.IncotermName = objDetails.IncotermName;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetForNewCreditNote
        /// Calls [usp_select_CustomerRMA_for_NewCreditNote]
        /// </summary>
        public static CustomerRma GetForNewCreditNote(System.Int32? customerRmaId)
        {
            Rebound.GlobalTrader.DAL.CustomerRmaDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.GetForNewCreditNote(customerRmaId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                CustomerRma obj = new CustomerRma();
                obj.CustomerRMAId = objDetails.CustomerRMAId;
                obj.ClientNo = objDetails.ClientNo;
                obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                obj.InvoiceNo = objDetails.InvoiceNo;
                obj.AuthorisedBy = objDetails.AuthorisedBy;
                obj.CustomerRMADate = objDetails.CustomerRMADate;
                obj.Instructions = objDetails.Instructions;
                obj.WarehouseNo = objDetails.WarehouseNo;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ContactNo = objDetails.ContactNo;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.InvoiceNumber = objDetails.InvoiceNumber;
                obj.AuthoriserName = objDetails.AuthoriserName;
                obj.WarehouseName = objDetails.WarehouseName;
                obj.CompanyName = objDetails.CompanyName;
                obj.ContactName = objDetails.ContactName;
                obj.DivisionName = objDetails.DivisionName;
                obj.SalesOrderNo = objDetails.SalesOrderNo;
                obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.Salesman = objDetails.Salesman;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.SalesmanName = objDetails.SalesmanName;
                obj.TaxNo = objDetails.TaxNo;
                obj.TaxName = objDetails.TaxName;
                obj.InvoiceDate = objDetails.InvoiceDate;
                obj.Quantity = objDetails.Quantity;
                obj.QuantityReceived = objDetails.QuantityReceived;
                obj.ShipViaNo = objDetails.ShipViaNo;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.Account = objDetails.Account;
                obj.InvoiceCustomerPO = objDetails.InvoiceCustomerPO;
                obj.InvoiceShippingCost = objDetails.InvoiceShippingCost;
                obj.InvoiceFreight = objDetails.InvoiceFreight;
                obj.Salesman2 = objDetails.Salesman2;
                obj.Salesman2Percent = objDetails.Salesman2Percent;
                //[002] code start
                obj.IncotermNo = objDetails.IncotermNo;
                //[002] code end
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetForPage
        /// Calls [usp_select_CustomerRMA_for_Page]
        /// </summary>
        public static CustomerRma GetForPage(System.Int32? customerRmaId)
        {
            Rebound.GlobalTrader.DAL.CustomerRmaDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.GetForPage(customerRmaId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                CustomerRma obj = new CustomerRma();
                obj.CustomerRMAId = objDetails.CustomerRMAId;
                obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                obj.ClientNo = objDetails.ClientNo;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.CompanyName = objDetails.CompanyName;
                //[001] code start
                obj.IsPDFAvailable = objDetails.IsPDFAvailable;
                //[001] code end
                obj.TeamNo = objDetails.TeamNo;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.Salesman = objDetails.Salesman;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetForPage
        /// Calls [usp_select_RecieveCustomerRMA_for_Page]
        /// </summary>
        public static CustomerRma GetForRecievePage(System.Int32? customerRmaId)
        {
            Rebound.GlobalTrader.DAL.CustomerRmaDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.GetForRecievePage(customerRmaId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                CustomerRma obj = new CustomerRma();
                obj.CustomerRMAId = objDetails.CustomerRMAId;
                obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                obj.ClientNo = objDetails.ClientNo;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.CompanyName = objDetails.CompanyName;
                //[001] code start
                obj.IsPDFAvailable = objDetails.IsPDFAvailable;
                //[001] code end
                obj.TeamNo = objDetails.TeamNo;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.Salesman = objDetails.Salesman;
                obj.ClientName = objDetails.ClientName;
                obj.ClientBaseCurrencyCode = objDetails.ClientBaseCurrencyCode;
                obj.ClientBaseCurrencyID = objDetails.ClientBaseCurrencyID;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetForPrint
        /// Calls [usp_select_CustomerRMA_for_Print]
        /// </summary>
        public static CustomerRma GetForPrint(System.Int32? customerRmaId)
        {
            Rebound.GlobalTrader.DAL.CustomerRmaDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.GetForPrint(customerRmaId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                CustomerRma obj = new CustomerRma();
                obj.CustomerRMAId = objDetails.CustomerRMAId;
                obj.ClientNo = objDetails.ClientNo;
                obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                obj.InvoiceNo = objDetails.InvoiceNo;
                obj.AuthorisedBy = objDetails.AuthorisedBy;
                obj.CustomerRMADate = objDetails.CustomerRMADate;
                obj.Notes = objDetails.Notes;
                obj.Instructions = objDetails.Instructions;
                obj.ShipViaNo = objDetails.ShipViaNo;
                obj.Account = objDetails.Account;
                obj.WarehouseNo = objDetails.WarehouseNo;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ContactNo = objDetails.ContactNo;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.InvoiceNumber = objDetails.InvoiceNumber;
                obj.AuthoriserName = objDetails.AuthoriserName;
                obj.WarehouseName = objDetails.WarehouseName;
                obj.CompanyName = objDetails.CompanyName;
                obj.ContactName = objDetails.ContactName;
                obj.DivisionName = objDetails.DivisionName;
                obj.SalesOrderNo = objDetails.SalesOrderNo;
                obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.Salesman = objDetails.Salesman;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.SalesmanName = objDetails.SalesmanName;
                obj.TaxNo = objDetails.TaxNo;
                obj.TaxName = objDetails.TaxName;
                obj.InvoiceDate = objDetails.InvoiceDate;
                obj.Quantity = objDetails.Quantity;
                obj.QuantityReceived = objDetails.QuantityReceived;
                obj.IncotermNo = objDetails.IncotermNo;
                obj.IncotermName = objDetails.IncotermName;
                obj.CompanyTelephone = objDetails.CompanyTelephone;
                obj.CompanyFax = objDetails.CompanyFax;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.CustomerPO = objDetails.CustomerPO;
                obj.TermsName = objDetails.TermsName;
                obj.ContactEmail = objDetails.ContactEmail;
                obj.IncotermName = objDetails.IncotermName;
                obj.CustomerRejectionNo = objDetails.CustomerRejectionNo;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetIDByNumber
        /// Calls [usp_select_CustomerRMA_ID_by_Number]
        /// </summary>
        public static List<CustomerRma> GetIDByNumber(System.Int32? customerRmaNumber, System.Int32? clientNo, System.Int32? isGlobalUser)
        {
            //[003] start
            List<Rebound.GlobalTrader.DAL.CustomerRmaDetails> objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.GetIDByNumber(customerRmaNumber, clientNo, isGlobalUser);
            List<CustomerRma> lstCRMA = new List<CustomerRma>();
            foreach (CustomerRmaDetails crmad in objDetails)
            {
                CustomerRma crma = new CustomerRma();
                crma.CustomerRMAId = crmad.CustomerRMAId;
                crma.CRMANumberDetail = crmad.CRMANumberDetail;
                lstCRMA.Add(crma);
            }
            return lstCRMA;
            //[003] end
        }
        /// <summary>
        /// GetNextNumber
        /// Calls [usp_select_CustomerRMA_NextNumber]
        /// </summary>
        public static CustomerRma GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy)
        {
            Rebound.GlobalTrader.DAL.CustomerRmaDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.GetNextNumber(clientNo, updatedBy);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                CustomerRma obj = new CustomerRma();
                obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetListForCompany
        /// Calls [usp_selectAll_CustomerRMA_for_Company]
        /// </summary>
        public static List<CustomerRma> GetListForCompany(System.Int32? companyId, System.Boolean? includeComplete)
        {
            List<CustomerRmaDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.GetListForCompany(companyId, includeComplete);
            if (lstDetails == null)
            {
                return new List<CustomerRma>();
            }
            else
            {
                List<CustomerRma> lst = new List<CustomerRma>();
                foreach (CustomerRmaDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.CustomerRma obj = new Rebound.GlobalTrader.BLL.CustomerRma();
                    obj.CustomerRMAId = objDetails.CustomerRMAId;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.CustomerRMANumber = objDetails.CustomerRMANumber;
                    obj.InvoiceNo = objDetails.InvoiceNo;
                    obj.AuthorisedBy = objDetails.AuthorisedBy;
                    obj.CustomerRMADate = objDetails.CustomerRMADate;
                    obj.Notes = objDetails.Notes;
                    obj.Instructions = objDetails.Instructions;
                    obj.ShipViaNo = objDetails.ShipViaNo;
                    obj.Account = objDetails.Account;
                    obj.WarehouseNo = objDetails.WarehouseNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.InvoiceNumber = objDetails.InvoiceNumber;
                    obj.AuthoriserName = objDetails.AuthoriserName;
                    obj.WarehouseName = objDetails.WarehouseName;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.ContactName = objDetails.ContactName;
                    obj.DivisionName = objDetails.DivisionName;
                    obj.SalesOrderNo = objDetails.SalesOrderNo;
                    obj.SalesOrderNumber = objDetails.SalesOrderNumber;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.Salesman = objDetails.Salesman;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.ShipViaName = objDetails.ShipViaName;
                    obj.SalesmanName = objDetails.SalesmanName;
                    obj.TaxNo = objDetails.TaxNo;
                    obj.TaxName = objDetails.TaxName;
                    obj.InvoiceDate = objDetails.InvoiceDate;
                    obj.Quantity = objDetails.Quantity;
                    obj.QuantityReceived = objDetails.QuantityReceived;
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
        /// Update
        /// Calls [usp_update_CustomerRMA]
        /// </summary>
        public static bool Update(System.Int32? customerRmaId, System.Int32? divisionNo, System.Int32? warehouseNo, System.Int32? authorisedBy, System.DateTime? customerRmaDate, System.Int32? shipViaNo, System.String account, System.String notes, System.String instructions, System.Int32? incotermNo, System.Int32? updatedBy, System.String CustomerRejectionNo)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.Update(customerRmaId, divisionNo, warehouseNo, authorisedBy, customerRmaDate, shipViaNo, account, notes, instructions, incotermNo, updatedBy, CustomerRejectionNo);
        }
        /// <summary>
        /// Update (without parameters)
        /// Calls [usp_update_CustomerRMA]
        /// </summary>
        public bool Update()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.Update(CustomerRMAId, DivisionNo, WarehouseNo, AuthorisedBy, CustomerRMADate, ShipViaNo, Account, Notes, Instructions, IncotermNo, UpdatedBy, CustomerRejectionNo);
        }

        private static CustomerRma PopulateFromDBDetailsObject(CustomerRmaDetails obj)
        {
            CustomerRma objNew = new CustomerRma();
            objNew.CustomerRMAId = obj.CustomerRMAId;
            objNew.ClientNo = obj.ClientNo;
            objNew.CustomerRMANumber = obj.CustomerRMANumber;
            objNew.InvoiceNo = obj.InvoiceNo;
            objNew.AuthorisedBy = obj.AuthorisedBy;
            objNew.CustomerRMADate = obj.CustomerRMADate;
            objNew.Notes = obj.Notes;
            objNew.Instructions = obj.Instructions;
            objNew.ShipViaNo = obj.ShipViaNo;
            objNew.Account = obj.Account;
            objNew.WarehouseNo = obj.WarehouseNo;
            objNew.CompanyNo = obj.CompanyNo;
            objNew.ContactNo = obj.ContactNo;
            objNew.DivisionNo = obj.DivisionNo;
            objNew.UpdatedBy = obj.UpdatedBy;
            objNew.DLUP = obj.DLUP;
            objNew.IncotermNo = obj.IncotermNo;
            objNew.CompanyName = obj.CompanyName;
            objNew.SalesmanName = obj.SalesmanName;
            objNew.AuthoriserName = obj.AuthoriserName;
            objNew.InvoiceNumber = obj.InvoiceNumber;
            objNew.RowNum = obj.RowNum;
            objNew.RowCnt = obj.RowCnt;
            objNew.WarehouseName = obj.WarehouseName;
            objNew.ContactName = obj.ContactName;
            objNew.DivisionName = obj.DivisionName;
            objNew.SalesOrderNo = obj.SalesOrderNo;
            objNew.SalesOrderNumber = obj.SalesOrderNumber;
            objNew.CurrencyNo = obj.CurrencyNo;
            objNew.Salesman = obj.Salesman;
            objNew.CurrencyCode = obj.CurrencyCode;
            objNew.CurrencyDescription = obj.CurrencyDescription;
            objNew.ShipViaName = obj.ShipViaName;
            objNew.TaxNo = obj.TaxNo;
            objNew.TaxName = obj.TaxName;
            objNew.InvoiceDate = obj.InvoiceDate;
            objNew.Quantity = obj.Quantity;
            objNew.QuantityReceived = obj.QuantityReceived;
            objNew.IncotermName = obj.IncotermName;
            objNew.InvoiceCustomerPO = obj.InvoiceCustomerPO;
            objNew.InvoiceShippingCost = obj.InvoiceShippingCost;
            objNew.InvoiceFreight = obj.InvoiceFreight;
            objNew.Salesman2 = obj.Salesman2;
            objNew.Salesman2Percent = obj.Salesman2Percent;
            objNew.CompanyTelephone = obj.CompanyTelephone;
            objNew.CompanyFax = obj.CompanyFax;
            objNew.CustomerPO = obj.CustomerPO;
            objNew.TermsName = obj.TermsName;
            objNew.ContactEmail = obj.ContactEmail;
            return objNew;
        }
        // [001] code start
        /// <summary>
        /// GetPDFListForCustomerRMA
        /// Calls [usp_selectAll_PDF_for_CustomerRMA]
        /// </summary>
        public static List<PDFDocument> GetPDFListForCustomerRMA(System.Int32? CustomerRMAId)
        {
            List<PDFDocumentDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.GetPDFListForCustomerRMA(CustomerRMAId);
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
        /// Calls [usp_insert_CustomerRMAPDF]
        /// </summary>
        public static Int32 Insert(System.Int32? CustomerRMAId, System.String Caption, System.String FileName, System.Int32? UpdatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.Insert(CustomerRMAId, Caption, FileName, UpdatedBy);
            return objReturn;
        }
        /// Delete
        /// Calls [usp_delete_CustomerRMAPDF]
        /// </summary>
        public static bool DeleteCustomerRMAPDF(System.Int32? CustomerRMAPdfId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.DeleteCustomerRMAPDF(CustomerRMAPdfId);
        }
        //[004] start
        /// save internal log for CRMA
        /// Calls [usp_insert_CRMAInternalLog]
        /// </summary>
        public static Int32 InsertCRMAInternalLog(System.Int32 CustomerRMAId, System.String notes,System.Int32 UpdatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.InsertCRMAInternalLog(CustomerRMAId, notes, UpdatedBy);
            return objReturn;
        }
        public static List<CustomerRma> GetCRMAInternalLog(System.Int32 customerRmaNumber)
        {
            //[004] start
            List<Rebound.GlobalTrader.DAL.CustomerRmaDetails> objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CustomerRma.GetCRMAInternalLog(customerRmaNumber);
            List<CustomerRma> lstCRMA = new List<CustomerRma>();
            foreach (CustomerRmaDetails crmad in objDetails)
            {
                CustomerRma crma = new CustomerRma();
                crma.CRMAExpediteNotesId = crmad.CRMAExpediteNotesId;
                crma.Notes = crmad.Notes;
                crma.EmployeeName = crmad.EmployeeName;
                crma.DLUP = crmad.DLUP;
                lstCRMA.Add(crma);
            }
            return lstCRMA;
            //[004] end
        }
        //[004] end
        #endregion

    }
}