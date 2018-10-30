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
	

	public class POQuoteDetails {
		
		#region Constructors
		
		public POQuoteDetails() { }
		
		#endregion
		
		#region Properties

        /// <summary>
        /// POQuoteId
        /// </summary>
        public System.Int32 POQuoteId { get; set; }
        /// <summary>
        /// ClientNo
        /// </summary>
        public System.Int32 ClientNo { get; set; }
        /// <summary>
        /// QuoteNumber
        /// </summary>
        public System.Int32 POQuoteNumber { get; set; }
        /// <summary>
        /// Notes
        /// </summary>
        public System.String Notes { get; set; }
        /// <summary>
        /// CompanyNo
        /// </summary>
        public System.Int32 CompanyNo { get; set; }
        /// <summary>
        /// ContactNo
        /// </summary>
        public System.Int32 ContactNo { get; set; }
        ///// <summary>
        ///// CurrencyNo
        ///// </summary>
        //public System.Int32 CurrencyNo { get; set; }
        /// <summary>
        /// Closed
        /// </summary>
        public System.Boolean? Closed { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }
        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime DLUP { get; set; }
        /// <summary>
        /// ContactName
        /// </summary>
        public System.String ContactName { get; set; }
        ///// <summary>
        ///// CurrencyCode
        ///// </summary>
        //public System.String CurrencyCode { get; set; }
        ///// <summary>
        ///// CurrencyDescription
        ///// </summary>
        //public System.String CurrencyDescription { get; set; }
        /// <summary>
        /// CompanyName
        /// </summary>
        public System.String CompanyName { get; set; }
        /// <summary>
        /// SalesPersonNo
        /// </summary>
        public System.Int32? SalesPersonNo { get; set; }
        /// <summary>
        /// SalesPersonName
        /// </summary>
        public System.String SalesPersonName { get; set; }
        /// <summary>
        /// DivisionNo
        /// </summary>
        public System.Int32? DivisionNo { get; set; }
        /// <summary>
        /// DivisionName
        /// </summary>
        public System.String DivisionName { get; set; }
        /// <summary>
        /// PurchaseRequestStatus
        /// </summary>
        public System.String PRStatus { get; set; }

        /// <summary>
        /// SalesPersonEmail
        /// </summary>
        public System.String SalesPersonEmail { get; set; }
        public int? PQStatus { get; set; }
		#endregion

	}
}
