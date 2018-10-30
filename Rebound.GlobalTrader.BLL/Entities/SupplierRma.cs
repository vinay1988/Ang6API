/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to upload pdf document for supplierRMA section
[002]      Aashu Singh     01/06/2018   Quick Jump in Global Warehouse 
[003]      Aashu Singh     06/07/2018   Save internal log for SRMA
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
    public partial class SupplierRma : BizObject
    {

        #region Properties

        protected static DAL.SupplierRmaElement Settings
        {
            get { return Globals.Settings.SupplierRmas; }
        }

        /// <summary>
        /// SupplierRMAId
        /// </summary>
        public System.Int32 SupplierRMAId { get; set; }
        /// <summary>
        /// ClientNo
        /// </summary>
        public System.Int32 ClientNo { get; set; }
        /// <summary>
        /// SupplierRMANumber
        /// </summary>
        public System.Int32 SupplierRMANumber { get; set; }
        /// <summary>
        /// PurchaseOrderNo
        /// </summary>
        public System.Int32 PurchaseOrderNo { get; set; }
        /// <summary>
        /// AuthorisedBy
        /// </summary>
        public System.Int32 AuthorisedBy { get; set; }
        /// <summary>
        /// SupplierRMADate
        /// </summary>
        public System.DateTime SupplierRMADate { get; set; }
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
        /// ShipToAddressNo
        /// </summary>
        public System.Int32 ShipToAddressNo { get; set; }
        /// <summary>
        /// Reference
        /// </summary>
        public System.String Reference { get; set; }
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
        /// BuyerName
        /// </summary>
        public System.String BuyerName { get; set; }
        /// <summary>
        /// PurchaseOrderNumber
        /// </summary>
        public System.Int32 PurchaseOrderNumber { get; set; }
        /// <summary>
        /// RowNum
        /// </summary>
        public System.Int64? RowNum { get; set; }
        /// <summary>
        /// RowCnt
        /// </summary>
        public System.Int32? RowCnt { get; set; }
        /// <summary>
        /// AuthoriserName
        /// </summary>
        public System.String AuthoriserName { get; set; }
        /// <summary>
        /// ShipViaName
        /// </summary>
        public System.String ShipViaName { get; set; }
        /// <summary>
        /// FullCompanyName
        /// </summary>
        public System.String FullCompanyName { get; set; }
        /// <summary>
        /// ContactName
        /// </summary>
        public System.String ContactName { get; set; }
        /// <summary>
        /// DivisionName
        /// </summary>
        public System.String DivisionName { get; set; }
        /// <summary>
        /// CurrencyNo
        /// </summary>
        public System.Int32 CurrencyNo { get; set; }
        /// <summary>
        /// CurrencyCode
        /// </summary>
        public System.String CurrencyCode { get; set; }
        /// <summary>
        /// CurrencyDescription
        /// </summary>
        public System.String CurrencyDescription { get; set; }
        /// <summary>
        /// TeamNo
        /// </summary>
        public System.Int32? TeamNo { get; set; }
        /// <summary>
        /// CustomerCode
        /// </summary>
        public System.String CustomerCode { get; set; }
        /// <summary>
        /// TaxNo
        /// </summary>
        public System.Int32 TaxNo { get; set; }
        /// <summary>
        /// TaxName
        /// </summary>
        public System.String TaxName { get; set; }
        /// <summary>
        /// Buyer
        /// </summary>
        public System.Int32 Buyer { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        public System.Int32? Quantity { get; set; }
        /// <summary>
        /// QuantityShipped
        /// </summary>
        public System.Int32? QuantityShipped { get; set; }
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
        public System.String POBuyerName { get; set; }
        public System.Int32? ClientSupplierRMANo { get; set; }
        public System.Int32? InternalPurchaseOrderNo { get; set; }
        public System.Int32? InternalPurchaseOrderNumber { get; set; }
        public System.Int32? POHubCompanyNo { get; set; }
        public System.String POHubCompanyName { get; set; }
        public System.Int32? RefNumber { get; set; }
        public System.Int32? IPOCompanyNo { get; set; }
        public System.Int32? InternalPurchaseOrderId { get; set; }
        public System.String IPOCompanyName { get; set; }
        public System.String ClientRefNo { get; set; }
        public System.Int32 HubShipToAddressNo { get; set; }
        public bool? isLockUpdateClient { get; set; }

        public System.String ClientName { get; set; }
        /// <summary>
        /// SRMANumberDetail
        /// </summary>
        //[002] start
        public System.String SRMANumberDetail { get; set; }
        //[002] end
        //[004] start
        public System.Int32 SRMAExpediteNotesId { get; set; }
        public System.String EmployeeName { get; set; }
        //[004] end
        #endregion

        #region Methods

        /// <summary>
        /// CountForClient
        /// Calls [usp_count_SupplierRMA_for_Client]
        /// </summary>
        public static Int32 CountForClient(System.Int32? clientId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.CountForClient(clientId);
        }		/// <summary>
        /// CountForCompany
        /// Calls [usp_count_SupplierRMA_for_Company]
        /// </summary>
        public static Int32 CountForCompany(System.Int32? companyId, System.Boolean? includeComplete)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.CountForCompany(companyId, includeComplete);
        }		/// <summary>
        /// CountShippingForClient
        /// Calls [usp_count_SupplierRMA_shipping_for_Client]
        /// </summary>
        public static Int32 CountShippingForClient(System.Int32? clientId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.CountShippingForClient(clientId);
        }		/// <summary>
        /// Delete
        /// Calls [usp_delete_SupplierRMA]
        /// </summary>
        public static bool Delete(System.Int32? supplierRmaId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.Delete(supplierRmaId);
        }
        /// <summary>
        /// Insert
        /// Calls [usp_insert_SupplierRMA]
        /// </summary>
        public static Int32 Insert(System.Int32? clientNo, System.Int32? purchaseOrderNo, System.Int32? authorisedBy, System.DateTime? supplierRmaDate, System.String notes, System.String instructions, System.Int32? shipViaNo, System.String account, System.Int32? shipToAddressNo, System.String reference, System.Int32? companyNo, System.Int32? contactNo, System.Int32? divisionNo, System.Int32? incotermNo, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.Insert(clientNo, purchaseOrderNo, authorisedBy, supplierRmaDate, notes, instructions, shipViaNo, account, shipToAddressNo, reference, companyNo, contactNo, divisionNo, incotermNo, updatedBy);
            return objReturn;
        }
        /// <summary>
        /// Insert (without parameters)
        /// Calls [usp_insert_SupplierRMA]
        /// </summary>
        public Int32 Insert()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.Insert(ClientNo, PurchaseOrderNo, AuthorisedBy, SupplierRMADate, Notes, Instructions, ShipViaNo, Account, ShipToAddressNo, Reference, CompanyNo, ContactNo, DivisionNo, IncotermNo, UpdatedBy);
        }
        /// <summary>
        /// ItemSearch
        /// Calls [usp_itemsearch_SupplierRMA]
        /// </summary>
        public static List<SupplierRma> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? buyerSearch, System.String srmaNotesSearch, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.Int32? supplierRmaNoLo, System.Int32? supplierRmaNoHi, System.DateTime? supplierRmaDateFrom, System.DateTime? supplierRmaDateTo)
        {
            List<SupplierRmaDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, contactSearch, cmSearch, buyerSearch, srmaNotesSearch, purchaseOrderNoLo, purchaseOrderNoHi, supplierRmaNoLo, supplierRmaNoHi, supplierRmaDateFrom, supplierRmaDateTo);
            if (lstDetails == null)
            {
                return new List<SupplierRma>();
            }
            else
            {
                List<SupplierRma> lst = new List<SupplierRma>();
                foreach (SupplierRmaDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SupplierRma obj = new Rebound.GlobalTrader.BLL.SupplierRma();
                    obj.SupplierRMAId = objDetails.SupplierRMAId;
                    obj.SupplierRMANumber = objDetails.SupplierRMANumber;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.SupplierRMADate = objDetails.SupplierRMADate;
                    obj.BuyerName = objDetails.BuyerName;
                    obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
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
        /// Calls [usp_select_SupplierRMA]
        /// </summary>
        public static SupplierRma Get(System.Int32? supplierRmaId)
        {
            Rebound.GlobalTrader.DAL.SupplierRmaDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.Get(supplierRmaId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SupplierRma obj = new SupplierRma();
                obj.SupplierRMAId = objDetails.SupplierRMAId;
                obj.ClientNo = objDetails.ClientNo;
                obj.SupplierRMANumber = objDetails.SupplierRMANumber;
                obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                obj.AuthorisedBy = objDetails.AuthorisedBy;
                obj.AuthoriserName = objDetails.AuthoriserName;
                obj.SupplierRMADate = objDetails.SupplierRMADate;
                obj.Notes = objDetails.Notes;
                obj.Instructions = objDetails.Instructions;
                obj.ShipViaNo = objDetails.ShipViaNo;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.Account = objDetails.Account;
                obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                obj.Reference = objDetails.Reference;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.CompanyName = objDetails.CompanyName;
                obj.FullCompanyName = objDetails.FullCompanyName;
                obj.ContactNo = objDetails.ContactNo;
                obj.ContactName = objDetails.ContactName;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.DivisionName = objDetails.DivisionName;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.TeamNo = objDetails.TeamNo;
                obj.CustomerCode = objDetails.CustomerCode;
                obj.TaxNo = objDetails.TaxNo;
                obj.TaxName = objDetails.TaxName;
                obj.Buyer = objDetails.Buyer;
                obj.Quantity = objDetails.Quantity;
                obj.QuantityShipped = objDetails.QuantityShipped;
                obj.IncotermNo = objDetails.IncotermNo;
                obj.IncotermName = objDetails.IncotermName;
                obj.POBuyerName = objDetails.POBuyerName;
                obj.ClientSupplierRMANo = objDetails.ClientSupplierRMANo;
                obj.InternalPurchaseOrderNo = objDetails.InternalPurchaseOrderNo;
                obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
                obj.RefNumber = objDetails.RefNumber;
                obj.IPOCompanyNo = objDetails.IPOCompanyNo;
                obj.IPOCompanyName = objDetails.IPOCompanyName;
                obj.isLockUpdateClient = objDetails.isLockUpdateClient;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetByNumber
        /// Calls [usp_select_SupplierRMA_by_Number]
        /// </summary>
        public static SupplierRma GetByNumber(System.Int32? supplierRmaNumber, System.Int32? clientNo)
        {
            Rebound.GlobalTrader.DAL.SupplierRmaDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.GetByNumber(supplierRmaNumber, clientNo);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SupplierRma obj = new SupplierRma();
                obj.SupplierRMAId = objDetails.SupplierRMAId;
                obj.ClientNo = objDetails.ClientNo;
                obj.SupplierRMANumber = objDetails.SupplierRMANumber;
                obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                obj.AuthorisedBy = objDetails.AuthorisedBy;
                obj.AuthoriserName = objDetails.AuthoriserName;
                obj.SupplierRMADate = objDetails.SupplierRMADate;
                obj.Notes = objDetails.Notes;
                obj.Instructions = objDetails.Instructions;
                obj.ShipViaNo = objDetails.ShipViaNo;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.Account = objDetails.Account;
                obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                obj.Reference = objDetails.Reference;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.CompanyName = objDetails.CompanyName;
                obj.FullCompanyName = objDetails.FullCompanyName;
                obj.ContactNo = objDetails.ContactNo;
                obj.ContactName = objDetails.ContactName;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.DivisionName = objDetails.DivisionName;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.TeamNo = objDetails.TeamNo;
                obj.CustomerCode = objDetails.CustomerCode;
                obj.TaxNo = objDetails.TaxNo;
                obj.TaxName = objDetails.TaxName;
                obj.Buyer = objDetails.Buyer;
                obj.Quantity = objDetails.Quantity;
                obj.QuantityShipped = objDetails.QuantityShipped;
                obj.IncotermNo = objDetails.IncotermNo;
                obj.IncotermName = objDetails.IncotermName;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetForPage
        /// Calls [usp_select_SupplierRMA_for_Page]
        /// </summary>
        public static SupplierRma GetForPage(System.Int32? supplierRmaId)
        {
            Rebound.GlobalTrader.DAL.SupplierRmaDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.GetForPage(supplierRmaId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SupplierRma obj = new SupplierRma();
                obj.SupplierRMAId = objDetails.SupplierRMAId;
                obj.SupplierRMANumber = objDetails.SupplierRMANumber;
                obj.ClientNo = objDetails.ClientNo;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.CompanyName = objDetails.CompanyName;
                // [001] code start
                obj.IsPDFAvailable = objDetails.IsPDFAvailable;
                // [001] code end
                obj.TeamNo = objDetails.TeamNo;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.Buyer = objDetails.Buyer;
                obj.IPOCompanyNo = objDetails.IPOCompanyNo;
                obj.IPOCompanyName = objDetails.IPOCompanyName;
                obj.InternalPurchaseOrderId = objDetails.InternalPurchaseOrderId;
                obj.ClientName = objDetails.ClientName;

                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetForPrint
        /// Calls [usp_select_SupplierRMA_for_Print]
        /// </summary>
        public static SupplierRma GetForPrint(System.Int32? supplierRmaId, bool IsHUBsupplierRmaId)
        {
            Rebound.GlobalTrader.DAL.SupplierRmaDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.GetForPrint(supplierRmaId, IsHUBsupplierRmaId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SupplierRma obj = new SupplierRma();
                obj.SupplierRMAId = objDetails.SupplierRMAId;
                obj.ClientNo = objDetails.ClientNo;
                obj.SupplierRMANumber = objDetails.SupplierRMANumber;
                obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                obj.AuthorisedBy = objDetails.AuthorisedBy;
                obj.AuthoriserName = objDetails.AuthoriserName;
                obj.SupplierRMADate = objDetails.SupplierRMADate;
                obj.Notes = objDetails.Notes;
                obj.Instructions = objDetails.Instructions;
                obj.ShipViaNo = objDetails.ShipViaNo;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.Account = objDetails.Account;
                obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                obj.Reference = objDetails.Reference;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.CompanyName = objDetails.CompanyName;
                obj.FullCompanyName = objDetails.FullCompanyName;
                obj.ContactNo = objDetails.ContactNo;
                obj.ContactName = objDetails.ContactName;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.DivisionName = objDetails.DivisionName;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.TeamNo = objDetails.TeamNo;
                obj.CustomerCode = objDetails.CustomerCode;
                obj.TaxNo = objDetails.TaxNo;
                obj.TaxName = objDetails.TaxName;
                obj.Buyer = objDetails.Buyer;
                obj.Quantity = objDetails.Quantity;
                obj.QuantityShipped = objDetails.QuantityShipped;
                obj.IncotermNo = objDetails.IncotermNo;
                obj.IncotermName = objDetails.IncotermName;
                obj.CompanyTelephone = objDetails.CompanyTelephone;
                obj.CompanyFax = objDetails.CompanyFax;
                obj.TermsName = objDetails.TermsName;
                obj.ShipViaName = objDetails.ShipViaName;
                obj.ContactEmail = objDetails.ContactEmail;
                obj.IncotermName = objDetails.IncotermName;
                obj.POHubCompanyNo = objDetails.POHubCompanyNo;
                obj.POHubCompanyName = objDetails.POHubCompanyName;
                obj.ClientRefNo = objDetails.ClientRefNo;
                obj.HubShipToAddressNo = objDetails.HubShipToAddressNo;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetIDByNumber
        /// Calls [usp_select_SupplierRMA_ID_by_Number]
        /// </summary>
        public static List<SupplierRma> GetIDByNumber(System.Int32? supplierRmaNumber, System.Int32? clientNo, System.Int32? isGlobalUser)
        {
            //[002] start
            List<Rebound.GlobalTrader.DAL.SupplierRmaDetails> lstSRMAD = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.GetIDByNumber(supplierRmaNumber, clientNo, isGlobalUser);
            List<SupplierRma> lstSRMA=new List<SupplierRma>();
            foreach(SupplierRmaDetails srmad in lstSRMAD)
            {
                SupplierRma srma=new SupplierRma();
                srma.SupplierRMAId = srmad.SupplierRMAId ;
                srma.SRMANumberDetail = srmad.SRMANumberDetail;
                lstSRMA.Add(srma);
            }
            return lstSRMA;
            //[002] end
		}
        /// <summary>
        /// GetNextNumber
        /// Calls [usp_select_SupplierRMA_NextNumber]
        /// </summary>
        public static SupplierRma GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy)
        {
            Rebound.GlobalTrader.DAL.SupplierRmaDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.GetNextNumber(clientNo, updatedBy);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                SupplierRma obj = new SupplierRma();
                obj.SupplierRMANumber = objDetails.SupplierRMANumber;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetListForCompany
        /// Calls [usp_selectAll_SupplierRMA_for_Company]
        /// </summary>
        public static List<SupplierRma> GetListForCompany(System.Int32? companyId, System.Boolean? includeComplete)
        {
            List<SupplierRmaDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.GetListForCompany(companyId, includeComplete);
            if (lstDetails == null)
            {
                return new List<SupplierRma>();
            }
            else
            {
                List<SupplierRma> lst = new List<SupplierRma>();
                foreach (SupplierRmaDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.SupplierRma obj = new Rebound.GlobalTrader.BLL.SupplierRma();
                    obj.SupplierRMAId = objDetails.SupplierRMAId;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.SupplierRMANumber = objDetails.SupplierRMANumber;
                    obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                    obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                    obj.AuthorisedBy = objDetails.AuthorisedBy;
                    obj.AuthoriserName = objDetails.AuthoriserName;
                    obj.SupplierRMADate = objDetails.SupplierRMADate;
                    obj.Notes = objDetails.Notes;
                    obj.Instructions = objDetails.Instructions;
                    obj.ShipViaNo = objDetails.ShipViaNo;
                    obj.ShipViaName = objDetails.ShipViaName;
                    obj.Account = objDetails.Account;
                    obj.ShipToAddressNo = objDetails.ShipToAddressNo;
                    obj.Reference = objDetails.Reference;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.FullCompanyName = objDetails.FullCompanyName;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.DivisionName = objDetails.DivisionName;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.CustomerCode = objDetails.CustomerCode;
                    obj.TaxNo = objDetails.TaxNo;
                    obj.TaxName = objDetails.TaxName;
                    obj.Buyer = objDetails.Buyer;
                    obj.Quantity = objDetails.Quantity;
                    obj.QuantityShipped = objDetails.QuantityShipped;
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
        /// Calls [usp_update_SupplierRMA]
        /// </summary>
        public static bool Update(System.Int32? supplierRmaId, System.String notes, System.String instructions, System.String reference, System.Int32? shipToAddressNo, System.DateTime? supplierRmaDate, System.Int32? shipViaNo, System.String account, System.Int32? incotermNo, System.Int32? updatedBy, bool? isLockUpdateClient)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.Update(supplierRmaId, notes, instructions, reference, shipToAddressNo, supplierRmaDate, shipViaNo, account, incotermNo, updatedBy, isLockUpdateClient);
        }
        /// <summary>
        /// Update (without parameters)
        /// Calls [usp_update_SupplierRMA]
        /// </summary>
        public bool Update()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.Update(SupplierRMAId, Notes, Instructions, Reference, ShipToAddressNo, SupplierRMADate, ShipViaNo, Account, IncotermNo, UpdatedBy, isLockUpdateClient);
        }

        private static SupplierRma PopulateFromDBDetailsObject(SupplierRmaDetails obj)
        {
            SupplierRma objNew = new SupplierRma();
            objNew.SupplierRMAId = obj.SupplierRMAId;
            objNew.ClientNo = obj.ClientNo;
            objNew.SupplierRMANumber = obj.SupplierRMANumber;
            objNew.PurchaseOrderNo = obj.PurchaseOrderNo;
            objNew.AuthorisedBy = obj.AuthorisedBy;
            objNew.SupplierRMADate = obj.SupplierRMADate;
            objNew.Notes = obj.Notes;
            objNew.Instructions = obj.Instructions;
            objNew.ShipViaNo = obj.ShipViaNo;
            objNew.Account = obj.Account;
            objNew.ShipToAddressNo = obj.ShipToAddressNo;
            objNew.Reference = obj.Reference;
            objNew.CompanyNo = obj.CompanyNo;
            objNew.ContactNo = obj.ContactNo;
            objNew.DivisionNo = obj.DivisionNo;
            objNew.UpdatedBy = obj.UpdatedBy;
            objNew.DLUP = obj.DLUP;
            objNew.IncotermNo = obj.IncotermNo;
            objNew.CompanyName = obj.CompanyName;
            objNew.BuyerName = obj.BuyerName;
            objNew.PurchaseOrderNumber = obj.PurchaseOrderNumber;
            objNew.RowNum = obj.RowNum;
            objNew.RowCnt = obj.RowCnt;
            objNew.AuthoriserName = obj.AuthoriserName;
            objNew.ShipViaName = obj.ShipViaName;
            objNew.FullCompanyName = obj.FullCompanyName;
            objNew.ContactName = obj.ContactName;
            objNew.DivisionName = obj.DivisionName;
            objNew.CurrencyNo = obj.CurrencyNo;
            objNew.CurrencyCode = obj.CurrencyCode;
            objNew.CurrencyDescription = obj.CurrencyDescription;
            objNew.TeamNo = obj.TeamNo;
            objNew.CustomerCode = obj.CustomerCode;
            objNew.TaxNo = obj.TaxNo;
            objNew.TaxName = obj.TaxName;
            objNew.Buyer = obj.Buyer;
            objNew.Quantity = obj.Quantity;
            objNew.QuantityShipped = obj.QuantityShipped;
            objNew.IncotermName = obj.IncotermName;
            objNew.CompanyTelephone = obj.CompanyTelephone;
            objNew.CompanyFax = obj.CompanyFax;
            objNew.TermsName = obj.TermsName;
            objNew.ContactEmail = obj.ContactEmail;
            return objNew;
        }
        // [001] code start
        /// <summary>
        /// GetPDFListForSupplierRMA
        /// Calls [usp_selectAll_PDF_for_SupplierRMA]
        /// </summary>
        public static List<PDFDocument> GetPDFListForSupplierRMA(System.Int32? SupplierRMAId)
        {
            List<PDFDocumentDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.GetPDFListForSupplierRMA(SupplierRMAId);
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
        /// Calls [usp_insert_SupplierRMAPDF]
        /// </summary>
        public static Int32 Insert(System.Int32? SupplierRMAId, System.String Caption, System.String FileName, System.Int32? UpdatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.Insert(SupplierRMAId, Caption, FileName, UpdatedBy);
            return objReturn;
        }
        /// Delete
        /// Calls [usp_delete_SupplierRMAPDF]
        /// </summary>
        public static bool DeleteSupplierRMAPDF(System.Int32? SupplierRMAPdfId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.DeleteSupplierRMAPDF(SupplierRMAPdfId);
        }

        // [001] code end
        //[003] start
        /// save internal log for SRMA
        /// Calls [usp_insert_SRMAInternalLog]
        /// </summary>
        public static Int32 InsertSRMAInternalLog(System.Int32 SupplierRMAId, System.String notes, System.Int32 UpdatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.InsertSRMAInternalLog(SupplierRMAId, notes, UpdatedBy);
            return objReturn;
        }
        public static List<SupplierRma> GetSRMAInternalLog(System.Int32 supplierRmaNumber)
        {

            List<Rebound.GlobalTrader.DAL.SupplierRmaDetails> objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SupplierRma.GetSRMAInternalLog(supplierRmaNumber);
            List<SupplierRma> lstSRMA = new List<SupplierRma>();
            foreach (SupplierRmaDetails srmad in objDetails)
            {
                SupplierRma crma = new SupplierRma();
                crma.SRMAExpediteNotesId = srmad.SRMAExpediteNotesId;
                crma.Notes = srmad.Notes;
                crma.EmployeeName = srmad.EmployeeName;
                crma.DLUP = srmad.DLUP;
                lstSRMA.Add(crma);
            }
            return lstSRMA;
            
        }
        //[003] end
        #endregion

    }
}