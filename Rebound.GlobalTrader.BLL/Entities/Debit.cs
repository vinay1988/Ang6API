//Marker     Changed by      Date         Remarks
//[001]      Vinay           30/07/2012   Add compulsory incoterms field when create Credit and debit note. :ESMS No:- 105
//[002]     Shashi Keshar    07/10/2016   Lock update from Client
//[003]      Aashu Singh      01/06/2018   Quick Jump in Global Warehouse 
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
    public partial class Debit : BizObject
    {

        #region Properties

        protected static DAL.DebitElement Settings
        {
            get { return Globals.Settings.Debits; }
        }

        /// <summary>
        /// DebitId
        /// </summary>
        public System.Int32 DebitId { get; set; }
        /// <summary>
        /// DebitNumber
        /// </summary>
        public System.Int32 DebitNumber { get; set; }
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
        /// DebitDate
        /// </summary>
        public System.DateTime DebitDate { get; set; }
        /// <summary>
        /// CurrencyNo
        /// </summary>
        public System.Int32 CurrencyNo { get; set; }
        /// <summary>
        /// RaisedBy
        /// </summary>
        public System.Int32? RaisedBy { get; set; }
        /// <summary>
        /// Buyer
        /// </summary>
        public System.Int32 Buyer { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public System.String Notes { get; set; }
        /// <summary>
        /// Instructions
        /// </summary>
        public System.String Instructions { get; set; }
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
        /// PurchaseOrderNo
        /// </summary>
        public System.Int32? PurchaseOrderNo { get; set; }
        /// <summary>
        /// SupplierRMANo
        /// </summary>
        public System.Int32? SupplierRMANo { get; set; }
        /// <summary>
        /// ReferenceDate
        /// </summary>
        public System.DateTime ReferenceDate { get; set; }
        /// <summary>
        /// SupplierInvoice
        /// </summary>
        public System.String SupplierInvoice { get; set; }
        /// <summary>
        /// SupplierRMA
        /// </summary>
        public System.String SupplierRMA { get; set; }
        /// <summary>
        /// SupplierCredit
        /// </summary>
        public System.String SupplierCredit { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime DLUP { get; set; }
        /// <summary>
        /// CompanyName
        /// </summary>
        public System.String CompanyName { get; set; }
        /// <summary>
        /// ContactName
        /// </summary>
        public System.String ContactName { get; set; }
        /// <summary>
        /// RaiserName
        /// </summary>
        public System.String RaiserName { get; set; }
        /// <summary>
        /// PurchaseOrderNumber
        /// </summary>
        public System.Int32 PurchaseOrderNumber { get; set; }
        /// <summary>
        /// SupplierRMANumber
        /// </summary>
        public System.Int32? SupplierRMANumber { get; set; }
        /// <summary>
        /// RowNum
        /// </summary>
        public System.Int64? RowNum { get; set; }
        /// <summary>
        /// RowCnt
        /// </summary>
        public System.Int32? RowCnt { get; set; }
        /// <summary>
        /// CurrencyCode
        /// </summary>
        public System.String CurrencyCode { get; set; }
        /// <summary>
        /// CurrencyDescription
        /// </summary>
        public System.String CurrencyDescription { get; set; }
        /// <summary>
        /// BuyerName
        /// </summary>
        public System.String BuyerName { get; set; }
        /// <summary>
        /// TeamNo
        /// </summary>
        public System.Int32? TeamNo { get; set; }
        /// <summary>
        /// DivisionName
        /// </summary>
        public System.String DivisionName { get; set; }
        /// <summary>
        /// TaxName
        /// </summary>
        public System.String TaxName { get; set; }
        /// <summary>
        /// PurchaseOrderDate
        /// </summary>
        public System.DateTime PurchaseOrderDate { get; set; }
        /// <summary>
        /// DebitValue
        /// </summary>
        public System.Double? DebitValue { get; set; }
        /// <summary>
        /// TaxRate
        /// </summary>
        public System.Double? TaxRate { get; set; }
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
        //[001] code start
        /// <summary>
        /// IncotermNo
        /// </summary>
        public System.Int32? IncotermsNo { get; set; }
        /// <summary>
        /// IncotermName
        /// </summary>
        public System.String IncotermsName { get; set; }
        //[001] code end
        /// <summary>
        /// SupplierCode
        /// </summary>
        public System.String SupplierCode { get; set; }
        /// <summary>
        /// VATNO 
        /// </summary>
        public System.String VATNO { get; set; }
        public System.Int32? InternalPurchaseOrderNo { get; set; }
        public System.Int32? InternalPurchaseOrderNumber { get; set; }

        public System.Int32? POHubCompanyNo { get; set; }
        public System.String POHubCompanyName { get; set; }
        public System.Int32? RefNumber { get; set; }
        public System.String ClientRefNo { get; set; }
        public System.Int32? DebitParentId { get; set; }
        public System.Boolean? ishublocked { get; set; }
        public bool? isLockUpdateClient { get; set; }
        public System.String ClientName { get; set; }
        /// <summary>
        /// DebitDetailNumber
        /// </summary>
        //[003] start
        public System.String DebitDetailNumber { get; set; }
        // [003] end
        #endregion

        #region Methods

        /// <summary>
        /// CountForCompany
        /// Calls [usp_count_Debit_for_Company]
        /// </summary>
        public static Int32 CountForCompany(System.Int32? companyId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Debit.CountForCompany(companyId);
        }		/// <summary>
        /// Delete
        /// Calls [usp_delete_Debit]
        /// </summary>
        public static bool Delete(System.Int32? debitId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Debit.Delete(debitId);
        }
        //[001] code start
        /// <summary>
        /// Insert
        /// Calls [usp_insert_Debit]
        /// </summary>
        public static Int32 Insert(System.Int32? clientNo, System.Int32? companyNo, System.Int32? contactNo, System.DateTime? debitDate, System.Int32? currencyNo, System.Int32? raisedBy, System.Int32? buyer, System.String notes, System.String instructions, System.Double? freight, System.Int32? divisionNo, System.Int32? taxNo, System.Int32? purchaseOrderNo, System.Int32? supplierRmaNo, System.DateTime? referenceDate, System.String supplierInvoice, System.String supplierRma, System.String supplierCredit, System.Int32? updatedBy, System.Int32? IncotermsNo)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Debit.Insert(clientNo, companyNo, contactNo, debitDate, currencyNo, raisedBy, buyer, notes, instructions, freight, divisionNo, taxNo, purchaseOrderNo, supplierRmaNo, referenceDate, supplierInvoice, supplierRma, supplierCredit, updatedBy, IncotermsNo);
            return objReturn;
        }
        /// <summary>
        /// Insert (without parameters)
        /// Calls [usp_insert_Debit]
        /// </summary>
        public Int32 Insert()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Debit.Insert(ClientNo, CompanyNo, ContactNo, DebitDate, CurrencyNo, RaisedBy, Buyer, Notes, Instructions, Freight, DivisionNo, TaxNo, PurchaseOrderNo, SupplierRMANo, ReferenceDate, SupplierInvoice, SupplierRMA, SupplierCredit, UpdatedBy, IncotermsNo);
        }
        //[001] code end
        /// <summary>
        /// ItemSearch
        /// Calls [usp_itemsearch_Debit]
        /// </summary>
        public static List<Debit> ItemSearch(System.Int32? clientId, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.String contactSearch, System.String cmSearch, System.Int32? salesmanSearch, System.Int32? debitNoLo, System.Int32? debitNoHi, System.Int32? supplierRmaNoLo, System.Int32? supplierRmaNoHi, System.Int32? purchaseOrderNoLo, System.Int32? purchaseOrderNoHi, System.DateTime? debitDateFrom, System.DateTime? debitDateTo)
        {
            List<DebitDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Debit.ItemSearch(clientId, orderBy, sortDir, pageIndex, pageSize, contactSearch, cmSearch, salesmanSearch, debitNoLo, debitNoHi, supplierRmaNoLo, supplierRmaNoHi, purchaseOrderNoLo, purchaseOrderNoHi, debitDateFrom, debitDateTo);
            if (lstDetails == null)
            {
                return new List<Debit>();
            }
            else
            {
                List<Debit> lst = new List<Debit>();
                foreach (DebitDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Debit obj = new Rebound.GlobalTrader.BLL.Debit();
                    obj.DebitId = objDetails.DebitId;
                    obj.DebitNumber = objDetails.DebitNumber;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.DebitDate = objDetails.DebitDate;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.ContactName = objDetails.ContactName;
                    obj.RaiserName = objDetails.RaiserName;
                    obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                    obj.SupplierRMANumber = objDetails.SupplierRMANumber;
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
        /// Calls [usp_select_Debit]
        /// </summary>
        public static Debit Get(System.Int32? debitId)
        {
            Rebound.GlobalTrader.DAL.DebitDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Debit.Get(debitId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Debit obj = new Debit();
                obj.DebitId = objDetails.DebitId;
                obj.DebitNumber = objDetails.DebitNumber;
                obj.ClientNo = objDetails.ClientNo;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ContactNo = objDetails.ContactNo;
                obj.DebitDate = objDetails.DebitDate;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.RaisedBy = objDetails.RaisedBy;
                obj.Buyer = objDetails.Buyer;
                obj.Notes = objDetails.Notes;
                obj.Instructions = objDetails.Instructions;
                obj.Freight = objDetails.Freight;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.TaxNo = objDetails.TaxNo;
                obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                obj.SupplierRMANo = objDetails.SupplierRMANo;
                obj.ReferenceDate = objDetails.ReferenceDate;
                obj.SupplierInvoice = objDetails.SupplierInvoice;
                obj.SupplierRMA = objDetails.SupplierRMA;
                obj.SupplierCredit = objDetails.SupplierCredit;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.CompanyName = objDetails.CompanyName;
                obj.ContactName = objDetails.ContactName;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.RaiserName = objDetails.RaiserName;
                obj.BuyerName = objDetails.BuyerName;
                obj.TeamNo = objDetails.TeamNo;
                obj.DivisionName = objDetails.DivisionName;
                obj.TaxName = objDetails.TaxName;
                obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                obj.PurchaseOrderDate = objDetails.PurchaseOrderDate;
                obj.SupplierRMANumber = objDetails.SupplierRMANumber;
                obj.DebitValue = objDetails.DebitValue;
                obj.TaxRate = objDetails.TaxRate;
                //[001] code start
                obj.IncotermsNo = objDetails.IncotermsNo;
                obj.IncotermsName = objDetails.IncotermsName;
                obj.InternalPurchaseOrderNo = objDetails.InternalPurchaseOrderNo;
                obj.InternalPurchaseOrderNumber = objDetails.InternalPurchaseOrderNumber;
                obj.POHubCompanyNo = objDetails.POHubCompanyNo;
                obj.POHubCompanyName = objDetails.POHubCompanyName;
                obj.RefNumber = objDetails.RefNumber;
                //[001] code end

                //[002] Start Here
                obj.DebitParentId = objDetails.DebitParentId;
                obj.ishublocked = objDetails.ishublocked;
                //[001] End Here

                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetForPage
        /// Calls [usp_select_Debit_for_Page]
        /// </summary>
        public static Debit GetForPage(System.Int32? debitId)
        {
            Rebound.GlobalTrader.DAL.DebitDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Debit.GetForPage(debitId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Debit obj = new Debit();
                obj.DebitId = objDetails.DebitId;
                obj.ClientNo = objDetails.ClientNo;
                obj.DebitNumber = objDetails.DebitNumber;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.CompanyName = objDetails.CompanyName;
                obj.TeamNo = objDetails.TeamNo;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.Buyer = objDetails.Buyer;
                obj.POHubCompanyNo = objDetails.POHubCompanyNo;
                obj.POHubCompanyName = objDetails.POHubCompanyName;
                obj.InternalPurchaseOrderNo = objDetails.InternalPurchaseOrderNo;
                obj.ClientName = objDetails.ClientName;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetForPrint
        /// Calls [usp_select_Debit_for_Print]
        /// </summary>
        public static Debit GetForPrint(System.Int32? debitNo, bool IsHUBdebitNo)
        {
            Rebound.GlobalTrader.DAL.DebitDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Debit.GetForPrint(debitNo, IsHUBdebitNo);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Debit obj = new Debit();
                obj.DebitId = objDetails.DebitId;
                obj.DebitNumber = objDetails.DebitNumber;
                obj.ClientNo = objDetails.ClientNo;
                obj.CompanyNo = objDetails.CompanyNo;
                obj.ContactNo = objDetails.ContactNo;
                obj.DebitDate = objDetails.DebitDate;
                obj.CurrencyNo = objDetails.CurrencyNo;
                obj.RaisedBy = objDetails.RaisedBy;
                obj.Buyer = objDetails.Buyer;
                obj.Notes = objDetails.Notes;
                obj.Instructions = objDetails.Instructions;
                obj.Freight = objDetails.Freight;
                obj.DivisionNo = objDetails.DivisionNo;
                obj.TaxNo = objDetails.TaxNo;
                obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                obj.SupplierRMANo = objDetails.SupplierRMANo;
                obj.ReferenceDate = objDetails.ReferenceDate;
                obj.SupplierInvoice = objDetails.SupplierInvoice;
                obj.SupplierRMA = objDetails.SupplierRMA;
                obj.SupplierCredit = objDetails.SupplierCredit;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                obj.CompanyName = objDetails.CompanyName;
                obj.ContactName = objDetails.ContactName;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.CurrencyDescription = objDetails.CurrencyDescription;
                obj.RaiserName = objDetails.RaiserName;
                obj.BuyerName = objDetails.BuyerName;
                obj.TeamNo = objDetails.TeamNo;
                obj.DivisionName = objDetails.DivisionName;
                obj.TaxName = objDetails.TaxName;
                obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                obj.PurchaseOrderDate = objDetails.PurchaseOrderDate;
                obj.SupplierRMANumber = objDetails.SupplierRMANumber;
                obj.DebitValue = objDetails.DebitValue;
                obj.TaxRate = objDetails.TaxRate;
                obj.CompanyTelephone = objDetails.CompanyTelephone;
                obj.CompanyFax = objDetails.CompanyFax;
                obj.ContactEmail = objDetails.ContactEmail;
                obj.VATNO = objDetails.VATNO;
                obj.SupplierCode = objDetails.SupplierCode;
                obj.POHubCompanyNo = objDetails.POHubCompanyNo;
                obj.POHubCompanyName = objDetails.POHubCompanyName;
                obj.ClientRefNo = objDetails.ClientRefNo;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetIdByNumber
        /// Calls [usp_select_Debit_Id_by_Number]
        /// </summary>
        //[003] start
        public static List<Debit> GetIdByNumber(System.Int32? debitNumber, System.Int32? clientNo, System.Int32? isGlobalUser)
        {
            List<Rebound.GlobalTrader.DAL.DebitDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Debit.GetIdByNumber(debitNumber, clientNo, isGlobalUser);
            List<Debit> lstDebit = new List<Debit>();
            foreach (DebitDetails dd in lstDetails)
            {
                Debit obj = new Debit();
                obj.DebitId = dd.DebitId;
                obj.DebitDetailNumber = dd.DebitDetailNumber;
                lstDebit.Add(obj);
            }

            return lstDebit;
        }
        // [003] end
        /// <summary>
        /// GetNextNumber
        /// Calls [usp_select_Debit_NextNumber]
        /// </summary>
        public static Debit GetNextNumber(System.Int32? clientNo, System.Int32? updatedBy)
        {
            Rebound.GlobalTrader.DAL.DebitDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Debit.GetNextNumber(clientNo, updatedBy);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                Debit obj = new Debit();
                obj.DebitNumber = objDetails.DebitNumber;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// GetListForCompany
        /// Calls [usp_selectAll_Debit_for_Company]
        /// </summary>
        public static List<Debit> GetListForCompany(System.Int32? companyId)
        {
            List<DebitDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Debit.GetListForCompany(companyId);
            if (lstDetails == null)
            {
                return new List<Debit>();
            }
            else
            {
                List<Debit> lst = new List<Debit>();
                foreach (DebitDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Debit obj = new Rebound.GlobalTrader.BLL.Debit();
                    obj.DebitId = objDetails.DebitId;
                    obj.DebitNumber = objDetails.DebitNumber;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.ContactNo = objDetails.ContactNo;
                    obj.DebitDate = objDetails.DebitDate;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.RaisedBy = objDetails.RaisedBy;
                    obj.Buyer = objDetails.Buyer;
                    obj.Notes = objDetails.Notes;
                    obj.Instructions = objDetails.Instructions;
                    obj.Freight = objDetails.Freight;
                    obj.DivisionNo = objDetails.DivisionNo;
                    obj.TaxNo = objDetails.TaxNo;
                    obj.PurchaseOrderNo = objDetails.PurchaseOrderNo;
                    obj.SupplierRMANo = objDetails.SupplierRMANo;
                    obj.ReferenceDate = objDetails.ReferenceDate;
                    obj.SupplierInvoice = objDetails.SupplierInvoice;
                    obj.SupplierRMA = objDetails.SupplierRMA;
                    obj.SupplierCredit = objDetails.SupplierCredit;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.ContactName = objDetails.ContactName;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.RaiserName = objDetails.RaiserName;
                    obj.BuyerName = objDetails.BuyerName;
                    obj.TeamNo = objDetails.TeamNo;
                    obj.DivisionName = objDetails.DivisionName;
                    obj.TaxName = objDetails.TaxName;
                    obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                    obj.PurchaseOrderDate = objDetails.PurchaseOrderDate;
                    obj.SupplierRMANumber = objDetails.SupplierRMANumber;
                    obj.DebitValue = objDetails.DebitValue;
                    obj.TaxRate = objDetails.TaxRate;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        //[001] code start
        /// <summary>
        /// Update
        /// Calls [usp_update_Debit]
        /// </summary>
        public static bool Update(System.Int32? debitId, System.String supplierInvoice, System.String supplierRma, System.String supplierCredit, System.Double? freight, System.String notes, System.String instructions, System.Int32? divisionNo, System.Int32? buyer, System.Int32? raisedBy, System.DateTime? debitDate, System.DateTime? referenceDate, System.Int32? taxNo, System.Int32? currencyNo, System.Int32? updatedBy, System.Int32? IncotermNo, bool? isLockUpdateClient)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Debit.Update(debitId, supplierInvoice, supplierRma, supplierCredit, freight, notes, instructions, divisionNo, buyer, raisedBy, debitDate, referenceDate, taxNo, currencyNo, updatedBy, IncotermNo, isLockUpdateClient);
        }

        /// <summary>
        /// Update (without parameters)
        /// Calls [usp_update_Debit]
        /// </summary>
        public bool Update()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Debit.Update(DebitId, SupplierInvoice, SupplierRMA, SupplierCredit, Freight, Notes, Instructions, DivisionNo, Buyer, RaisedBy, DebitDate, ReferenceDate, TaxNo, CurrencyNo, UpdatedBy, IncotermsNo, isLockUpdateClient);
        }
        //[001] code end
        private static Debit PopulateFromDBDetailsObject(DebitDetails obj)
        {
            Debit objNew = new Debit();
            objNew.DebitId = obj.DebitId;
            objNew.DebitNumber = obj.DebitNumber;
            objNew.ClientNo = obj.ClientNo;
            objNew.CompanyNo = obj.CompanyNo;
            objNew.ContactNo = obj.ContactNo;
            objNew.DebitDate = obj.DebitDate;
            objNew.CurrencyNo = obj.CurrencyNo;
            objNew.RaisedBy = obj.RaisedBy;
            objNew.Buyer = obj.Buyer;
            objNew.Notes = obj.Notes;
            objNew.Instructions = obj.Instructions;
            objNew.Freight = obj.Freight;
            objNew.DivisionNo = obj.DivisionNo;
            objNew.TaxNo = obj.TaxNo;
            objNew.PurchaseOrderNo = obj.PurchaseOrderNo;
            objNew.SupplierRMANo = obj.SupplierRMANo;
            objNew.ReferenceDate = obj.ReferenceDate;
            objNew.SupplierInvoice = obj.SupplierInvoice;
            objNew.SupplierRMA = obj.SupplierRMA;
            objNew.SupplierCredit = obj.SupplierCredit;
            objNew.UpdatedBy = obj.UpdatedBy;
            objNew.DLUP = obj.DLUP;
            objNew.CompanyName = obj.CompanyName;
            objNew.ContactName = obj.ContactName;
            objNew.RaiserName = obj.RaiserName;
            objNew.PurchaseOrderNumber = obj.PurchaseOrderNumber;
            objNew.SupplierRMANumber = obj.SupplierRMANumber;
            objNew.RowNum = obj.RowNum;
            objNew.RowCnt = obj.RowCnt;
            objNew.CurrencyCode = obj.CurrencyCode;
            objNew.CurrencyDescription = obj.CurrencyDescription;
            objNew.BuyerName = obj.BuyerName;
            objNew.TeamNo = obj.TeamNo;
            objNew.DivisionName = obj.DivisionName;
            objNew.TaxName = obj.TaxName;
            objNew.PurchaseOrderDate = obj.PurchaseOrderDate;
            objNew.DebitValue = obj.DebitValue;
            objNew.TaxRate = obj.TaxRate;
            objNew.CompanyTelephone = obj.CompanyTelephone;
            objNew.CompanyFax = obj.CompanyFax;
            objNew.ContactEmail = obj.ContactEmail;
            return objNew;
        }

        #endregion

    }
}