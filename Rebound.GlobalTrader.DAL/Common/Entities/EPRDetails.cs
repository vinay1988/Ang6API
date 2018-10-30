/*
Marker     Creaded by      Date         Remarks
           Ranjit           07/05/2012   This need to upload pdf document for Purchage Order section
[001]      Aashu Singh      06-Aug-2018  REB-12084:Lock PO lines when EPR is authorised

 * 
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

namespace Rebound.GlobalTrader.DAL {
	
	public class EPRDetails {
		
		#region Constructors

        public EPRDetails() { }
		
		#endregion

        #region Properties

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

	}
}