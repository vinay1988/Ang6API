/*
Marker     Create by      Date         Remarks
           Ranjit         10/09/2014  
[001]      Aashu Singh    06-Aug-2018   REB-12084:Lock PO lines when EPR is authorised
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
    public partial class EPR : BizObject
    {

        #region Properties

        protected static DAL.EPRElement Settings
        {
            get { return Globals.Settings.EPR; }
        }

        /// <summary>
        /// EPRId
        /// </summary>
        public System.Int32 EPRId { get; set; }
        /// <summary>
        /// PurchaseOrderId
        /// </summary>
        public System.Int32 PurchaseOrderId { get; set; }
        /// <summary>
        /// PurchaseOrderNumber
        /// </summary>
        public System.Int32 PurchaseOrderNumber { get; set; }
        /// <summary>
        /// IsNew
        /// </summary>
        public System.Boolean IsNew { get; set; }
        /// <summary>
        /// CompanyNo
        /// </summary>
        public System.String CompanyName { get; set; }
        /// <summary>
        /// OrderValue
        /// </summary>
        public System.Double OrderValue { get; set; }

        /// <summary>
        /// CurrencyNo
        /// </summary>
        public System.String CurrencyCode { get; set; }
        /// <summary>
        /// DeliveryDate
        /// </summary>

        public System.DateTime? DeliveryDate { get; set; }
        /// <summary>
        /// In Advance
        /// </summary>
        public System.Boolean InAdvance { get; set; }
        /// <summary>
        /// Upon Receipt
        /// </summary>
        public System.Boolean UponReceipt { get; set; }

        /// <summary>
        /// Net Specify
        /// </summary>
        public System.Int32? NetSpecify { get; set; }

        /// <summary>
        /// Other Specify
        /// </summary>
        public System.String OtherSpecify { get; set; }

        /// <summary>
        /// TT
        /// </summary>
        public System.Boolean TT { get; set; }

        /// <summary>
        /// Cheque
        /// </summary>
        public System.Boolean Cheque { get; set; }



        /// <summary>
        /// Credit Card
        /// </summary>

        public System.Boolean CreditCard { get; set; }
        /// <summary>
        /// Comments
        /// </summary>
        public System.String Comments { get; set; }

        public System.String Name { get; set; }
        public System.String Address { get; set; }
        public System.String Tel { get; set; }
        public System.String Fax { get; set; }
        public System.String Email { get; set; }
        public System.String Name1 { get; set; }
        public System.String Address1 { get; set; }
        public System.String Tel1 { get; set; }
        public System.String Fax1 { get; set; }
        public System.String Email1 { get; set; }
        public System.String Comment { get; set; }
        public System.String Name2 { get; set; }
        public System.String Address2 { get; set; }
        public System.String Tel2 { get; set; }
        public System.String Fax2 { get; set; }
        public System.String Email2 { get; set; }

        public System.Boolean ProFormaAttached { get; set; }
        public System.String RaisedBy { get; set; }
        public System.DateTime? RaisedByDate { get; set; }
        public System.Boolean SORSigned { get; set; }
        public System.Boolean ForStock { get; set; }
        public System.Boolean ValuesCorrect { get; set; }
        public System.String Authorized { get; set; }
        public System.DateTime? AuthorizedDate { get; set; }
        /// <summary>
        /// ACCOUNTS ONLY 
        /// </summary>
        public System.Boolean ERAIMember { get; set; }
        public System.Boolean ERAIReported { get; set; }
        public System.Boolean DebitNotes { get; set; }
        public System.Boolean APOpenOrders { get; set; }
        public System.Double ACTotalValue { get; set; }
        public System.Double ACTotalValue1 { get; set; }
        /// <summary>
        /// Sales Ledger Properties
        /// </summary>
        public System.String SLComment { get; set; }
        public System.String SLTerms { get; set; }
        public System.Boolean SLOverdue { get; set; }
        public System.Double SLTotalValue { get; set; }

        public System.String PaymentAuthorizedBy { get; set; }
        public System.String Countersigned { get; set; }
        public System.DateTime? PaymentAuthorizedDate { get; set; }

        public System.DateTime? DLUP { get; set; }
        public System.Int32? UpdatedBy { get; set; }
        public System.String SupplierCode { get; set; }
        /// <summary>
        /// IsRefAuthorise
        /// </summary>
        public System.Boolean? IsRefAuthorise { get; set; }
        /// <summary>
        /// IsPaymentAuthorise
        /// </summary>
        public System.Boolean? IsCompleted { get; set; }
        /// <summary>
        /// EPRCompletedBy
        /// </summary>
        public System.Int32? EPRCompletedByNo { get; set; }
        /// <summary>
        /// EPRCompletedByName
        /// </summary>
        public System.String EPRCompletedByName { get; set; }
        /// <summary>
        /// EPRLogId
        /// </summary>
        public System.Int32? EPRLogId { get; set; }
        /// <summary>
        /// Details
        /// </summary>
        public System.String Details { get; set; }
        /// <summary>
        /// UpdatedByName
        /// </summary>
        public System.String UpdatedByName { get; set; }
        /// <summary>
        /// EPRChange
        /// </summary>
        public System.String EPRChange { get; set; }
        /// <summary>
        /// RaisedByNo
        /// </summary>
        public System.Int32? RaisedByNo { get; set; }
        //[001] start
        /// <summary>
        /// POLineNo
        /// </summary>
        public System.String POLineIds { get; set; }
        public System.String POLineSerialNo { get; set; }
        //[001] end

        #endregion

        #region Methods


        //[003] code start
        /// <summary>
        /// Insert
        /// Calls [usp_insert_EPR]
        /// </summary>
        public static Int32 Insert(EPR objEPR)
        {
            EPRDetails obj = new EPRDetails();
            obj.PurchaseOrderId = objEPR.PurchaseOrderId;
            obj.CompanyName = objEPR.CompanyName;
            obj.IsNew = objEPR.IsNew;
            obj.PurchaseOrderNumber = objEPR.PurchaseOrderNumber;
            obj.OrderValue = objEPR.OrderValue;
            obj.CurrencyCode = objEPR.CurrencyCode;
            obj.DeliveryDate = objEPR.DeliveryDate;
            obj.InAdvance = objEPR.InAdvance;
            obj.UponReceipt = objEPR.UponReceipt;
            obj.NetSpecify = objEPR.NetSpecify;
            obj.OtherSpecify = objEPR.OtherSpecify;
            obj.TT = objEPR.TT;
            obj.Cheque = objEPR.Cheque;
            obj.CreditCard = objEPR.CreditCard;
            obj.Comments = objEPR.Comments;
            obj.Name = objEPR.Name;
            obj.Address = objEPR.Address;
            obj.Tel = objEPR.Tel;
            obj.Fax = objEPR.Fax;
            obj.Email = objEPR.Email;
            obj.Name1 = objEPR.Name1;
            obj.Address1 = objEPR.Address1;
            obj.Tel1 = objEPR.Tel1;
            obj.Fax1 = objEPR.Fax1;
            obj.Email1 = objEPR.Email1;
            obj.Name2 = objEPR.Name2;
            obj.Address2 = objEPR.Address2;
            obj.Tel2 = objEPR.Tel2;
            obj.Fax2 = objEPR.Fax2;
            obj.Email2 = objEPR.Email2;
            obj.Comment = objEPR.Comment;
            obj.ProFormaAttached = objEPR.ProFormaAttached;
            obj.RaisedByNo = objEPR.RaisedByNo;
            obj.RaisedByDate = objEPR.RaisedByDate;
            obj.SORSigned = objEPR.SORSigned;
            obj.ForStock = objEPR.ForStock;
            obj.ValuesCorrect = objEPR.ValuesCorrect;
            obj.Authorized = objEPR.Authorized;
            obj.AuthorizedDate = objEPR.AuthorizedDate;
            obj.ERAIMember = objEPR.ERAIMember;
            obj.ERAIReported = objEPR.ERAIReported;
            obj.DebitNotes = objEPR.DebitNotes;
            obj.APOpenOrders = objEPR.APOpenOrders;
            obj.ACTotalValue = objEPR.ACTotalValue;
            obj.ACTotalValue1 = objEPR.ACTotalValue1;
            obj.SLComment = objEPR.SLComment;
            obj.SLTerms = objEPR.SLTerms;
            obj.SLOverdue = objEPR.SLOverdue;
            obj.SLTotalValue = objEPR.SLTotalValue;
            obj.PaymentAuthorizedBy = objEPR.PaymentAuthorizedBy;
            obj.Countersigned = objEPR.Countersigned;
            obj.PaymentAuthorizedDate = objEPR.PaymentAuthorizedDate;
            obj.SupplierCode = objEPR.SupplierCode;
            obj.EPRCompletedByNo = objEPR.EPRCompletedByNo;
            obj.EPRChange = objEPR.EPRChange;
            obj.UpdatedBy = objEPR.UpdatedBy;
            obj.POLineIds = formatXml(objEPR.POLineIds,objEPR.UpdatedBy.ToString());
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.EPRProvider.Insert(obj);
			return objReturn;
		}


        /// <summary>
        /// Get
        /// Calls [usp_select_EPR]
        /// </summary>
        public static EPR Get(System.Int32? eprId)
        {
            Rebound.GlobalTrader.DAL.EPRDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.EPRProvider.Get(eprId);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                EPR obj = new EPR();
                obj.EPRId = objDetails.EPRId;
                obj.PurchaseOrderId = objDetails.PurchaseOrderId;
                obj.CompanyName = objDetails.CompanyName;
                obj.IsNew = objDetails.IsNew;
                obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                obj.OrderValue = objDetails.OrderValue;
                obj.CurrencyCode = objDetails.CurrencyCode;
                obj.DeliveryDate = objDetails.DeliveryDate;
                obj.InAdvance = objDetails.InAdvance;
                obj.UponReceipt = objDetails.UponReceipt;
                obj.NetSpecify = objDetails.NetSpecify;
                obj.OtherSpecify = objDetails.OtherSpecify;
                obj.TT = objDetails.TT;
                obj.Cheque = objDetails.Cheque;
                obj.CreditCard = objDetails.CreditCard;
                obj.Comments = objDetails.Comments;
                obj.Name = objDetails.Name;
                obj.Address = objDetails.Address;
                obj.Tel = objDetails.Tel;
                obj.Fax = objDetails.Fax;
                obj.Email = objDetails.Email;
                obj.Name1 = objDetails.Name1;
                obj.Address1 = objDetails.Address1;
                obj.Tel1 = objDetails.Tel1;
                obj.Fax1 = objDetails.Fax1;
                obj.Email1 = objDetails.Email1;
                obj.Name2 = objDetails.Name2;
                obj.Address2 = objDetails.Address2;
                obj.Tel2 = objDetails.Tel2;
                obj.Fax2 = objDetails.Fax2;
                obj.Email2 = objDetails.Email2;
                obj.Comment = objDetails.Comment;
                obj.ProFormaAttached = objDetails.ProFormaAttached;
                obj.RaisedBy = objDetails.RaisedBy;
                obj.RaisedByDate = objDetails.RaisedByDate;
                obj.SORSigned = objDetails.SORSigned;
                obj.ForStock = objDetails.ForStock;
                obj.ValuesCorrect = objDetails.ValuesCorrect;
                obj.Authorized = objDetails.Authorized;
                obj.AuthorizedDate = objDetails.AuthorizedDate;
                obj.ERAIMember = objDetails.ERAIMember;
                obj.ERAIReported = objDetails.ERAIReported;
                obj.DebitNotes = objDetails.DebitNotes;
                obj.APOpenOrders = objDetails.APOpenOrders;
                obj.ACTotalValue = objDetails.ACTotalValue;
                obj.ACTotalValue1 = objDetails.ACTotalValue1;
                obj.SLComment = objDetails.SLComment;
                obj.SLTerms = objDetails.SLTerms;
                obj.SLOverdue = objDetails.SLOverdue;
                obj.SLTotalValue = objDetails.SLTotalValue;
                obj.PaymentAuthorizedBy = objDetails.PaymentAuthorizedBy;
                obj.Countersigned = objDetails.Countersigned;
                obj.PaymentAuthorizedDate = objDetails.PaymentAuthorizedDate;
                obj.SupplierCode = objDetails.SupplierCode;
                obj.IsRefAuthorise = string.IsNullOrEmpty(objDetails.Authorized) ? false : true;
                obj.IsCompleted = objDetails.EPRCompletedByNo.HasValue ? false : true;
                obj.EPRCompletedByName = objDetails.EPRCompletedByName;
                obj.EPRCompletedByNo = objDetails.EPRCompletedByNo;
                obj.RaisedByNo = objDetails.RaisedByNo;
                //[001] start
                obj.POLineSerialNo = objDetails.POLineSerialNo;
                //[001] end
                objDetails = null;
                return obj;
            }
        }


        // <summary>
        /// Get
        /// Calls [usp_select_ListEPR]
        /// </summary>
        public static List<EPR> ListEPR(System.Int32? PoId)
        {
            List<EPRDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.EPRProvider.ListEPR(PoId);
            if (lstDetails == null)
            {
                return null;
            }
            else
            {
                List<EPR> lst = new List<EPR>();
                foreach (EPRDetails objDetails in lstDetails)
                {
                    EPR obj = new EPR();
                    obj.EPRId = objDetails.EPRId;
                    obj.PurchaseOrderId = objDetails.PurchaseOrderId;
                    obj.CompanyName = objDetails.CompanyName;
                    obj.IsNew = objDetails.IsNew;
                    obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                    obj.OrderValue = objDetails.OrderValue;
                    obj.DeliveryDate = objDetails.DeliveryDate;
                    obj.InAdvance = objDetails.InAdvance;
                    obj.UponReceipt = objDetails.UponReceipt;
                    obj.NetSpecify = objDetails.NetSpecify;
                    obj.OtherSpecify = objDetails.OtherSpecify;
                    obj.TT = objDetails.TT;
                    obj.Cheque = objDetails.Cheque;
                    obj.CreditCard = objDetails.CreditCard;
                    obj.Comments = objDetails.Comments;
                    obj.Name = objDetails.Name;
                    obj.Address = objDetails.Address;
                    obj.Tel = objDetails.Tel;
                    obj.Fax = objDetails.Fax;
                    obj.Email = objDetails.Email;
                    obj.Name1 = objDetails.Name1;
                    obj.Address1 = objDetails.Address1;
                    obj.Tel1 = objDetails.Tel1;
                    obj.Fax1 = objDetails.Fax1;
                    obj.Email1 = objDetails.Email1;
                    obj.Name2 = objDetails.Name2;
                    obj.Address2 = objDetails.Address2;
                    obj.Tel2 = objDetails.Tel2;
                    obj.Fax2 = objDetails.Fax2;
                    obj.Email2 = objDetails.Email2;
                    obj.Comment = objDetails.Comment;
                    obj.ProFormaAttached = objDetails.ProFormaAttached;
                    obj.RaisedBy = objDetails.RaisedBy;
                    obj.RaisedByDate = objDetails.RaisedByDate;
                    obj.SORSigned = objDetails.SORSigned;
                    obj.ForStock = objDetails.ForStock;
                    obj.ValuesCorrect = objDetails.ValuesCorrect;
                    obj.Authorized = objDetails.Authorized;
                    obj.AuthorizedDate = objDetails.AuthorizedDate;
                    obj.ERAIMember = objDetails.ERAIMember;
                    obj.ERAIReported = objDetails.ERAIReported;
                    obj.DebitNotes = objDetails.DebitNotes;
                    obj.APOpenOrders = objDetails.APOpenOrders;
                    obj.ACTotalValue = objDetails.ACTotalValue;
                    obj.ACTotalValue1 = objDetails.ACTotalValue1;
                    obj.SLComment = objDetails.SLComment;
                    obj.SLTerms = objDetails.SLTerms;
                    obj.SLOverdue = objDetails.SLOverdue;
                    obj.SLTotalValue = objDetails.SLTotalValue;
                    obj.PaymentAuthorizedBy = objDetails.PaymentAuthorizedBy;
                    obj.Countersigned = objDetails.Countersigned;
                    obj.PaymentAuthorizedDate = objDetails.PaymentAuthorizedDate;
                    obj.SupplierCode = objDetails.SupplierCode;
                    lst.Add(obj);
                }
                lstDetails = null;
                return lst;

            }
        }

        /// <summary>
        /// Insert
        /// Calls [usp_Update_EPR]
        /// </summary>
        public static bool Update(EPR objEPR)
        {
            EPRDetails obj = new EPRDetails();
            obj.EPRId = objEPR.EPRId;
            obj.PurchaseOrderId = objEPR.PurchaseOrderId;
            obj.CompanyName = objEPR.CompanyName;
            obj.IsNew = objEPR.IsNew;
            obj.PurchaseOrderNumber = objEPR.PurchaseOrderNumber;
            obj.OrderValue = objEPR.OrderValue;
            obj.CurrencyCode = objEPR.CurrencyCode;
            obj.DeliveryDate = objEPR.DeliveryDate;
            obj.InAdvance = objEPR.InAdvance;
            obj.UponReceipt = objEPR.UponReceipt;
            obj.NetSpecify = objEPR.NetSpecify;
            obj.OtherSpecify = objEPR.OtherSpecify;
            obj.TT = objEPR.TT;
            obj.Cheque = objEPR.Cheque;
            obj.CreditCard = objEPR.CreditCard;
            obj.Comments = objEPR.Comments;
            obj.Name = objEPR.Name;
            obj.Address = objEPR.Address;
            obj.Tel = objEPR.Tel;
            obj.Fax = objEPR.Fax;
            obj.Email = objEPR.Email;
            obj.Name1 = objEPR.Name1;
            obj.Address1 = objEPR.Address1;
            obj.Tel1 = objEPR.Tel1;
            obj.Fax1 = objEPR.Fax1;
            obj.Email1 = objEPR.Email1;
            obj.Name2 = objEPR.Name2;
            obj.Address2 = objEPR.Address2;
            obj.Tel2 = objEPR.Tel2;
            obj.Fax2 = objEPR.Fax2;
            obj.Email2 = objEPR.Email2;
            obj.Comment = objEPR.Comment;
            obj.ProFormaAttached = objEPR.ProFormaAttached;
            obj.RaisedByNo = objEPR.RaisedByNo;
            obj.RaisedByDate = objEPR.RaisedByDate;
            obj.SORSigned = objEPR.SORSigned;
            obj.ForStock = objEPR.ForStock;
            obj.ValuesCorrect = objEPR.ValuesCorrect;
            obj.Authorized = objEPR.Authorized;
            obj.AuthorizedDate = objEPR.AuthorizedDate;
            obj.ERAIMember = objEPR.ERAIMember;
            obj.ERAIReported = objEPR.ERAIReported;
            obj.DebitNotes = objEPR.DebitNotes;
            obj.APOpenOrders = objEPR.APOpenOrders;
            obj.ACTotalValue = objEPR.ACTotalValue;
            obj.ACTotalValue1 = objEPR.ACTotalValue1;
            obj.SLComment = objEPR.SLComment;
            obj.SLTerms = objEPR.SLTerms;
            obj.SLOverdue = objEPR.SLOverdue;
            obj.SLTotalValue = objEPR.SLTotalValue;
            obj.PaymentAuthorizedBy = objEPR.PaymentAuthorizedBy;
            obj.Countersigned = objEPR.Countersigned;
            obj.PaymentAuthorizedDate = objEPR.PaymentAuthorizedDate;
            obj.UpdatedBy = objEPR.UpdatedBy;
            obj.SupplierCode = objEPR.SupplierCode;
            obj.EPRCompletedByNo = objEPR.EPRCompletedByNo;
            obj.EPRChange = objEPR.EPRChange;
            bool isUpdated = Rebound.GlobalTrader.DAL.SiteProvider.EPRProvider.Update(obj);
            return isUpdated;
        }
        public static List<EPR> GetEPRLog(System.Int32? eprId)
        {
            List<EPRDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.EPRProvider.GetEPRLog(eprId);
            if (lstDetails == null)
            {
                return null;
            }
            else
            {
                List<EPR> lst = new List<EPR>();
                foreach (EPRDetails objDetails in lstDetails)
                {
                    EPR obj = new EPR();
                    obj.EPRLogId = objDetails.EPRLogId;
                    obj.EPRId = objDetails.EPRId;
                    obj.Details = objDetails.Details;
                    obj.UpdatedByName = objDetails.UpdatedByName;
                    obj.DLUP = objDetails.DLUP;
                    obj.PurchaseOrderNumber = objDetails.PurchaseOrderNumber;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        /// <summary>
        /// Insert EPR Email Log
        /// Call [usp_insert_Email_EPR_Log]
        /// </summary>
        /// <param name="eprId"></param>
        /// <param name="details"></param>
        /// <param name="updatedBy"></param>
        /// <returns></returns>
        public static Int32 InsertEmailEPRLog(System.Int32? eprId, System.String details, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.EPRProvider.InsertEmailEPRLog(eprId, details, updatedBy);
            return objReturn;
        }

        /// <summary>
        /// Delete EPR by Id
        /// Calls [usp_delete_EPR]
        /// </summary>
        /// <param name="nprId"></param>
        /// <returns></returns>
        public static bool Delete(System.Int32? eprId)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.EPRProvider.Delete(eprId);
        }
        //[001] start
        public static string formatXml(string poLineIds,string createdBy)
        {
            System.Text.StringBuilder sbxml = new System.Text.StringBuilder();
            if (!string.IsNullOrEmpty(poLineIds))
            {
                string[] arrIds = poLineIds.Split(',');
                sbxml.Append("<POLineEPRDetails>");
                foreach (string id in arrIds)
                {
                    sbxml.Append("<POLineEPRDetail>");
                    sbxml.Append("<POLineID>" + id + "</POLineID>");
                    //sbxml.Append("<EPRID>" + eprid + "/EPRID");
                    sbxml.Append("<CreatedBy>" + createdBy + "</CreatedBy>");
                    sbxml.Append("</POLineEPRDetail>");
                    
                }
                sbxml.Append("</POLineEPRDetails>");
            }
            return sbxml.ToString();
        }
        //[001] end

        #endregion

    }
}