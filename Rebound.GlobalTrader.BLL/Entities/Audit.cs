/*
Marker     Changed by      Date         Remarks
[001]      Aashu           19/06/2018   REB-11552: Change how the how the IPO/PO expedite message work
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
    public partial class Audit : BizObject
    {

        #region Properties

        protected static DAL.AuditElement Settings
        {
            get { return Globals.Settings.Audits; }
        }

        /// <summary>
        /// AuditId
        /// </summary>
        public System.Int32 AuditId { get; set; }
        /// <summary>
        /// TableName
        /// </summary>
        public System.String TableName { get; set; }
        /// <summary>
        /// HeaderNo
        /// </summary>
        public System.Int32 HeaderNo { get; set; }
        /// <summary>
        /// DetailLineNo
        /// </summary>
        public System.Int32? DetailLineNo { get; set; }
        /// <summary>
        /// CompanyNo
        /// </summary>
        public System.Int32? CompanyNo { get; set; }
        /// <summary>
        /// DateReceived
        /// </summary>
        public System.DateTime? DateReceived { get; set; }
        /// <summary>
        /// DateOrdered
        /// </summary>
        public System.DateTime? DateOrdered { get; set; }
        /// <summary>
        /// DateRequired
        /// </summary>
        public System.DateTime? DateRequired { get; set; }
        /// <summary>
        /// DatePromised
        /// </summary>
        public System.DateTime? DatePromised { get; set; }
        /// <summary>
        /// DeliveryDate
        /// </summary>
        public System.DateTime? DeliveryDate { get; set; }
        /// <summary>
        /// DateDue
        /// </summary>
        public System.DateTime? DateDue { get; set; }
        /// <summary>
        /// DateAuthorised
        /// </summary>
        public System.DateTime? DateAuthorised { get; set; }
        /// <summary>
        /// Quantity
        /// </summary>
        public System.Int32? Quantity { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public System.Double? Price { get; set; }
        /// <summary>
        /// LandedCost
        /// </summary>
        public System.Double? LandedCost { get; set; }
        /// <summary>
        /// Freight
        /// </summary>
        public System.Double? Freight { get; set; }
        /// <summary>
        /// ShipCost
        /// </summary>
        public System.Double? ShipCost { get; set; }
        /// <summary>
        /// FullPart
        /// </summary>
        public System.String FullPart { get; set; }
        /// <summary>
        /// ExternalPart
        /// </summary>
        public System.String ExternalPart { get; set; }
        /// <summary>
        /// StockNo
        /// </summary>
        public System.Int32? StockNo { get; set; }
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
        /// CreditLimit
        /// </summary>
        public System.Double? CreditLimit { get; set; }
        /// <summary>
        /// CreditLimitNew
        /// </summary>
        public System.Double? CreditLimitNew { get; set; }
        /// <summary>
        /// Note
        /// </summary>
        public System.String Note { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime DLUP { get; set; }
        /// <summary>
        /// EmployeeName
        /// </summary>
        public System.String EmployeeName { get; set; }

        /// <summary>
        /// InsuredAmount
        /// </summary>
        public System.Double? InsuredAmount { get; set; }
        /// <summary>
        /// InsuredAmountNew
        /// </summary>
        public System.Double? InsuredAmountNew { get; set; }
        /// <summary>
        /// InsuranceFileNo
        /// </summary>
        public System.String InsuranceFileNo { get; set; }
        /// <summary>
        /// InsuranceFileNoNew
        /// </summary>
        public System.String InsuranceFileNoNew { get; set; }
        /// <summary>
        /// InsHistoryId 
        /// </summary>
        public System.Int32 InsHistoryId { get; set; }
        /// <summary>
        /// POLineNos
        /// </summary>
        public System.String POLineNos { get; set; }
        /// <summary>
        /// HUBRFQ Item ReqNos
        /// </summary>
        public System.String ReqNos { get; set; }
        public System.String To { get; set; }
        //[001] start
        /// <summary>
        /// IsMailSent
        /// </summary>
        public System.String IsMailSent { get; set; }
        //[001] end
        #endregion

        #region Methods

        /// <summary>
        /// Delete
        /// Calls [usp_delete_Audit]
        /// </summary>
        public static bool Delete(System.Int32? auditId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Audit.Delete(auditId);
        }
        /// <summary>
        /// GetListApprovalForPurchaseOrder
        /// Calls [usp_selectAll_Audit_approval_for_PurchaseOrder]
        /// </summary>
        public static List<Audit> GetListApprovalForPurchaseOrder(System.Int32? purchaseOrderId)
        {
            List<AuditDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Audit.GetListApprovalForPurchaseOrder(purchaseOrderId);
            if (lstDetails == null)
            {
                return new List<Audit>();
            }
            else
            {
                List<Audit> lst = new List<Audit>();
                foreach (AuditDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Audit obj = new Rebound.GlobalTrader.BLL.Audit();
                    obj.AuditId = objDetails.AuditId;
                    obj.TableName = objDetails.TableName;
                    obj.HeaderNo = objDetails.HeaderNo;
                    obj.DetailLineNo = objDetails.DetailLineNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.DateReceived = objDetails.DateReceived;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.DateRequired = objDetails.DateRequired;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.DeliveryDate = objDetails.DeliveryDate;
                    obj.DateDue = objDetails.DateDue;
                    obj.DateAuthorised = objDetails.DateAuthorised;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.LandedCost = objDetails.LandedCost;
                    obj.Freight = objDetails.Freight;
                    obj.ShipCost = objDetails.ShipCost;
                    obj.FullPart = objDetails.FullPart;
                    obj.ExternalPart = objDetails.ExternalPart;
                    obj.StockNo = objDetails.StockNo;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.TaxNo = objDetails.TaxNo;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.Note = objDetails.Note;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.EmployeeName = objDetails.EmployeeName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListAuthorisationForSalesOrder
        /// Calls [usp_selectAll_Audit_authorisation_for_SalesOrder]
        /// </summary>
        public static List<Audit> GetListAuthorisationForSalesOrder(System.Int32? salesOrderId)
        {
            List<AuditDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Audit.GetListAuthorisationForSalesOrder(salesOrderId);
            if (lstDetails == null)
            {
                return new List<Audit>();
            }
            else
            {
                List<Audit> lst = new List<Audit>();
                foreach (AuditDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Audit obj = new Rebound.GlobalTrader.BLL.Audit();
                    obj.AuditId = objDetails.AuditId;
                    obj.TableName = objDetails.TableName;
                    obj.HeaderNo = objDetails.HeaderNo;
                    obj.DetailLineNo = objDetails.DetailLineNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.DateReceived = objDetails.DateReceived;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.DateRequired = objDetails.DateRequired;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.DeliveryDate = objDetails.DeliveryDate;
                    obj.DateDue = objDetails.DateDue;
                    obj.DateAuthorised = objDetails.DateAuthorised;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.LandedCost = objDetails.LandedCost;
                    obj.Freight = objDetails.Freight;
                    obj.ShipCost = objDetails.ShipCost;
                    obj.FullPart = objDetails.FullPart;
                    obj.ExternalPart = objDetails.ExternalPart;
                    obj.StockNo = objDetails.StockNo;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.TaxNo = objDetails.TaxNo;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.Note = objDetails.Note;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.EmployeeName = objDetails.EmployeeName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListCreditHistoryForCompany
        /// Calls [usp_selectAll_Audit_creditHistory_for_Company]
        /// </summary>
        public static List<Audit> GetListCreditHistoryForCompany(System.Int32? companyId)
        {
            List<AuditDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Audit.GetListCreditHistoryForCompany(companyId);
            if (lstDetails == null)
            {
                return new List<Audit>();
            }
            else
            {
                List<Audit> lst = new List<Audit>();
                foreach (AuditDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Audit obj = new Rebound.GlobalTrader.BLL.Audit();
                    obj.AuditId = objDetails.AuditId;
                    obj.TableName = objDetails.TableName;
                    obj.HeaderNo = objDetails.HeaderNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.CreditLimitNew = objDetails.CreditLimitNew;
                    obj.Note = objDetails.Note;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.EmployeeName = objDetails.EmployeeName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListInsuranceHistoryForCompany
        /// Calls [usp_selectAll_Insurance_History_for_Company]
        /// </summary>
        public static List<Audit> GetListInsuranceHistoryForCompany(System.Int32? companyId)
        {
            List<AuditDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Audit.GetListInsuranceHistoryForCompany(companyId);
            if (lstDetails == null)
            {
                return new List<Audit>();
            }
            else
            {
                List<Audit> lst = new List<Audit>();
                foreach (AuditDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Audit obj = new Rebound.GlobalTrader.BLL.Audit();
                    obj.InsHistoryId = objDetails.InsHistoryId;

                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.InsuredAmount = objDetails.InsuredAmount;
                    obj.InsuredAmountNew = objDetails.InsuredAmountNew;
                    obj.InsuranceFileNo = objDetails.InsuranceFileNo;
                    obj.InsuranceFileNoNew = objDetails.InsuranceFileNoNew;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.EmployeeName = objDetails.EmployeeName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListForGoodsInLine
        /// Calls [usp_selectAll_Audit_for_GoodsInLine]
        /// </summary>
        public static List<Audit> GetListForGoodsInLine(System.Int32? goodsInLineId)
        {
            List<AuditDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Audit.GetListForGoodsInLine(goodsInLineId);
            if (lstDetails == null)
            {
                return new List<Audit>();
            }
            else
            {
                List<Audit> lst = new List<Audit>();
                foreach (AuditDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Audit obj = new Rebound.GlobalTrader.BLL.Audit();
                    obj.AuditId = objDetails.AuditId;
                    obj.TableName = objDetails.TableName;
                    obj.HeaderNo = objDetails.HeaderNo;
                    obj.DetailLineNo = objDetails.DetailLineNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.DateReceived = objDetails.DateReceived;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.DateRequired = objDetails.DateRequired;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.DeliveryDate = objDetails.DeliveryDate;
                    obj.DateDue = objDetails.DateDue;
                    obj.DateAuthorised = objDetails.DateAuthorised;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.LandedCost = objDetails.LandedCost;
                    obj.Freight = objDetails.Freight;
                    obj.ShipCost = objDetails.ShipCost;
                    obj.FullPart = objDetails.FullPart;
                    obj.ExternalPart = objDetails.ExternalPart;
                    obj.StockNo = objDetails.StockNo;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.TaxNo = objDetails.TaxNo;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.CreditLimitNew = objDetails.CreditLimitNew;
                    obj.Note = objDetails.Note;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.EmployeeName = objDetails.EmployeeName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListForPurchaseOrder
        /// Calls [usp_selectAll_Audit_for_PurchaseOrder]
        /// </summary>
        public static List<Audit> GetListForPurchaseOrder(System.Int32? purchaseOrderId)
        {
            List<AuditDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Audit.GetListForPurchaseOrder(purchaseOrderId);
            if (lstDetails == null)
            {
                return new List<Audit>();
            }
            else
            {
                List<Audit> lst = new List<Audit>();
                foreach (AuditDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Audit obj = new Rebound.GlobalTrader.BLL.Audit();
                    obj.AuditId = objDetails.AuditId;
                    obj.TableName = objDetails.TableName;
                    obj.HeaderNo = objDetails.HeaderNo;
                    obj.DetailLineNo = objDetails.DetailLineNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.DateReceived = objDetails.DateReceived;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.DateRequired = objDetails.DateRequired;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.DeliveryDate = objDetails.DeliveryDate;
                    obj.DateDue = objDetails.DateDue;
                    obj.DateAuthorised = objDetails.DateAuthorised;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.LandedCost = objDetails.LandedCost;
                    obj.Freight = objDetails.Freight;
                    obj.ShipCost = objDetails.ShipCost;
                    obj.FullPart = objDetails.FullPart;
                    obj.ExternalPart = objDetails.ExternalPart;
                    obj.StockNo = objDetails.StockNo;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.TaxNo = objDetails.TaxNo;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.CreditLimitNew = objDetails.CreditLimitNew;
                    obj.Note = objDetails.Note;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.EmployeeName = objDetails.EmployeeName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListForPurchaseOrderLine
        /// Calls [usp_selectAll_Audit_for_PurchaseOrderLine]
        /// </summary>
        public static List<Audit> GetListForPurchaseOrderLine(System.Int32? purchaseOrderLineId)
        {
            List<AuditDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Audit.GetListForPurchaseOrderLine(purchaseOrderLineId);
            if (lstDetails == null)
            {
                return new List<Audit>();
            }
            else
            {
                List<Audit> lst = new List<Audit>();
                foreach (AuditDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Audit obj = new Rebound.GlobalTrader.BLL.Audit();
                    obj.AuditId = objDetails.AuditId;
                    obj.TableName = objDetails.TableName;
                    obj.HeaderNo = objDetails.HeaderNo;
                    obj.DetailLineNo = objDetails.DetailLineNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.DateReceived = objDetails.DateReceived;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.DateRequired = objDetails.DateRequired;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.DeliveryDate = objDetails.DeliveryDate;
                    obj.DateDue = objDetails.DateDue;
                    obj.DateAuthorised = objDetails.DateAuthorised;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.LandedCost = objDetails.LandedCost;
                    obj.Freight = objDetails.Freight;
                    obj.ShipCost = objDetails.ShipCost;
                    obj.FullPart = objDetails.FullPart;
                    obj.ExternalPart = objDetails.ExternalPart;
                    obj.StockNo = objDetails.StockNo;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.TaxNo = objDetails.TaxNo;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.CreditLimitNew = objDetails.CreditLimitNew;
                    obj.Note = objDetails.Note;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.EmployeeName = objDetails.EmployeeName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListForQuote
        /// Calls [usp_selectAll_Audit_for_Quote]
        /// </summary>
        public static List<Audit> GetListForQuote(System.Int32? quoteId)
        {
            List<AuditDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Audit.GetListForQuote(quoteId);
            if (lstDetails == null)
            {
                return new List<Audit>();
            }
            else
            {
                List<Audit> lst = new List<Audit>();
                foreach (AuditDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Audit obj = new Rebound.GlobalTrader.BLL.Audit();
                    obj.AuditId = objDetails.AuditId;
                    obj.TableName = objDetails.TableName;
                    obj.HeaderNo = objDetails.HeaderNo;
                    obj.DetailLineNo = objDetails.DetailLineNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.DateReceived = objDetails.DateReceived;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.DateRequired = objDetails.DateRequired;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.DeliveryDate = objDetails.DeliveryDate;
                    obj.DateDue = objDetails.DateDue;
                    obj.DateAuthorised = objDetails.DateAuthorised;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.LandedCost = objDetails.LandedCost;
                    obj.Freight = objDetails.Freight;
                    obj.ShipCost = objDetails.ShipCost;
                    obj.FullPart = objDetails.FullPart;
                    obj.ExternalPart = objDetails.ExternalPart;
                    obj.StockNo = objDetails.StockNo;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.TaxNo = objDetails.TaxNo;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.CreditLimitNew = objDetails.CreditLimitNew;
                    obj.Note = objDetails.Note;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.EmployeeName = objDetails.EmployeeName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListForQuoteLine
        /// Calls [usp_selectAll_Audit_for_QuoteLine]
        /// </summary>
        public static List<Audit> GetListForQuoteLine(System.Int32? quoteLineId)
        {
            List<AuditDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Audit.GetListForQuoteLine(quoteLineId);
            if (lstDetails == null)
            {
                return new List<Audit>();
            }
            else
            {
                List<Audit> lst = new List<Audit>();
                foreach (AuditDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Audit obj = new Rebound.GlobalTrader.BLL.Audit();
                    obj.AuditId = objDetails.AuditId;
                    obj.TableName = objDetails.TableName;
                    obj.HeaderNo = objDetails.HeaderNo;
                    obj.DetailLineNo = objDetails.DetailLineNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.DateReceived = objDetails.DateReceived;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.DateRequired = objDetails.DateRequired;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.DeliveryDate = objDetails.DeliveryDate;
                    obj.DateDue = objDetails.DateDue;
                    obj.DateAuthorised = objDetails.DateAuthorised;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.LandedCost = objDetails.LandedCost;
                    obj.Freight = objDetails.Freight;
                    obj.ShipCost = objDetails.ShipCost;
                    obj.FullPart = objDetails.FullPart;
                    obj.ExternalPart = objDetails.ExternalPart;
                    obj.StockNo = objDetails.StockNo;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.TaxNo = objDetails.TaxNo;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.CreditLimitNew = objDetails.CreditLimitNew;
                    obj.Note = objDetails.Note;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.EmployeeName = objDetails.EmployeeName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListForSalesOrder
        /// Calls [usp_selectAll_Audit_for_SalesOrder]
        /// </summary>
        public static List<Audit> GetListForSalesOrder(System.Int32? salesOrderId)
        {
            List<AuditDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Audit.GetListForSalesOrder(salesOrderId);
            if (lstDetails == null)
            {
                return new List<Audit>();
            }
            else
            {
                List<Audit> lst = new List<Audit>();
                foreach (AuditDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Audit obj = new Rebound.GlobalTrader.BLL.Audit();
                    obj.AuditId = objDetails.AuditId;
                    obj.TableName = objDetails.TableName;
                    obj.HeaderNo = objDetails.HeaderNo;
                    obj.DetailLineNo = objDetails.DetailLineNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.DateReceived = objDetails.DateReceived;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.DateRequired = objDetails.DateRequired;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.DeliveryDate = objDetails.DeliveryDate;
                    obj.DateDue = objDetails.DateDue;
                    obj.DateAuthorised = objDetails.DateAuthorised;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.LandedCost = objDetails.LandedCost;
                    obj.Freight = objDetails.Freight;
                    obj.ShipCost = objDetails.ShipCost;
                    obj.FullPart = objDetails.FullPart;
                    obj.ExternalPart = objDetails.ExternalPart;
                    obj.StockNo = objDetails.StockNo;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.TaxNo = objDetails.TaxNo;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.CreditLimitNew = objDetails.CreditLimitNew;
                    obj.Note = objDetails.Note;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.EmployeeName = objDetails.EmployeeName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// GetListForSalesOrderLine
        /// Calls [usp_selectAll_Audit_for_SalesOrderLine]
        /// </summary>
        public static List<Audit> GetListForSalesOrderLine(System.Int32? salesOrderLineId)
        {
            List<AuditDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Audit.GetListForSalesOrderLine(salesOrderLineId);
            if (lstDetails == null)
            {
                return new List<Audit>();
            }
            else
            {
                List<Audit> lst = new List<Audit>();
                foreach (AuditDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Audit obj = new Rebound.GlobalTrader.BLL.Audit();
                    obj.AuditId = objDetails.AuditId;
                    obj.TableName = objDetails.TableName;
                    obj.HeaderNo = objDetails.HeaderNo;
                    obj.DetailLineNo = objDetails.DetailLineNo;
                    obj.CompanyNo = objDetails.CompanyNo;
                    obj.DateReceived = objDetails.DateReceived;
                    obj.DateOrdered = objDetails.DateOrdered;
                    obj.DateRequired = objDetails.DateRequired;
                    obj.DatePromised = objDetails.DatePromised;
                    obj.DeliveryDate = objDetails.DeliveryDate;
                    obj.DateDue = objDetails.DateDue;
                    obj.DateAuthorised = objDetails.DateAuthorised;
                    obj.Quantity = objDetails.Quantity;
                    obj.Price = objDetails.Price;
                    obj.LandedCost = objDetails.LandedCost;
                    obj.Freight = objDetails.Freight;
                    obj.ShipCost = objDetails.ShipCost;
                    obj.FullPart = objDetails.FullPart;
                    obj.ExternalPart = objDetails.ExternalPart;
                    obj.StockNo = objDetails.StockNo;
                    obj.CurrencyNo = objDetails.CurrencyNo;
                    obj.TermsNo = objDetails.TermsNo;
                    obj.TaxNo = objDetails.TaxNo;
                    obj.CreditLimit = objDetails.CreditLimit;
                    obj.CreditLimitNew = objDetails.CreditLimitNew;
                    obj.Note = objDetails.Note;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.EmployeeName = objDetails.EmployeeName;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        private static Audit PopulateFromDBDetailsObject(AuditDetails obj)
        {
            Audit objNew = new Audit();
            objNew.AuditId = obj.AuditId;
            objNew.TableName = obj.TableName;
            objNew.HeaderNo = obj.HeaderNo;
            objNew.DetailLineNo = obj.DetailLineNo;
            objNew.CompanyNo = obj.CompanyNo;
            objNew.DateReceived = obj.DateReceived;
            objNew.DateOrdered = obj.DateOrdered;
            objNew.DateRequired = obj.DateRequired;
            objNew.DatePromised = obj.DatePromised;
            objNew.DeliveryDate = obj.DeliveryDate;
            objNew.DateDue = obj.DateDue;
            objNew.DateAuthorised = obj.DateAuthorised;
            objNew.Quantity = obj.Quantity;
            objNew.Price = obj.Price;
            objNew.LandedCost = obj.LandedCost;
            objNew.Freight = obj.Freight;
            objNew.ShipCost = obj.ShipCost;
            objNew.FullPart = obj.FullPart;
            objNew.ExternalPart = obj.ExternalPart;
            objNew.StockNo = obj.StockNo;
            objNew.CurrencyNo = obj.CurrencyNo;
            objNew.TermsNo = obj.TermsNo;
            objNew.TaxNo = obj.TaxNo;
            objNew.CreditLimit = obj.CreditLimit;
            objNew.CreditLimitNew = obj.CreditLimitNew;
            objNew.Note = obj.Note;
            objNew.UpdatedBy = obj.UpdatedBy;
            objNew.DLUP = obj.DLUP;
            objNew.EmployeeName = obj.EmployeeName;
            return objNew;
        }



        public static List<Audit> GetListExpediteForPurchaseOrder(System.Int32? purchaseOrderId)
        {
            List<AuditDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Audit.GetListExpediteForPurchaseOrder(purchaseOrderId);
            if (lstDetails == null)
            {
                return new List<Audit>();
            }
            else
            {
                List<Audit> lst = new List<Audit>();
                foreach (AuditDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Audit obj = new Rebound.GlobalTrader.BLL.Audit();
                    obj.AuditId = objDetails.AuditId;                   
                    obj.Note = objDetails.Note;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.EmployeeName = objDetails.EmployeeName;
                    //[001] start
                    obj.IsMailSent = objDetails.IsMailSent;
                    //[001] end
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        public static List<Audit> GetListExpediteForHUBRFQ(System.Int32? HUBRFQId)
        {
            List<AuditDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Audit.GetListExpediteForHUBRFQ(HUBRFQId);
            if (lstDetails == null)
            {
                return new List<Audit>();
            }
            else
            {
                List<Audit> lst = new List<Audit>();
                foreach (AuditDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Audit obj = new Rebound.GlobalTrader.BLL.Audit();
                    obj.AuditId = objDetails.AuditId;
                    obj.Note = objDetails.Note;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.EmployeeName = objDetails.EmployeeName;
                    obj.ReqNos = objDetails.ReqNos;
                    obj.To = objDetails.To;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        #endregion

    }
}