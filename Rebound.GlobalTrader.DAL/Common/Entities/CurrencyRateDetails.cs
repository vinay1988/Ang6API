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
	
	public class CurrencyRateDetails {
		
		#region Constructors
		
		public CurrencyRateDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// CurrencyRateId (from Table)
		/// </summary>
		public System.Int32 CurrencyRateId { get; set; }
		/// <summary>
		/// CurrencyNo (from usp_selectAll_Allocation_for_CustomerRMALine)
		/// </summary>
		public System.Int32 CurrencyNo { get; set; }
		/// <summary>
		/// CurrencyDate (from Table)
		/// </summary>
		public System.DateTime CurrencyDate { get; set; }
		/// <summary>
		/// ExchangeRate (from Table)
		/// </summary>
		public System.Double ExchangeRate { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// RepriceOpenOrders (from Table)
		/// </summary>
		public System.Boolean? RepriceOpenOrders { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.String CurrencyCode { get; set; }
        /// <summary>
        /// ExchangeRateId
        /// </summary>
        public System.Int32 ExchangeRateId { get; set; }
        /// <summary>
        /// LocalCurrencyNo
        /// </summary>
        public System.Int32 LocalCurrencyNo { get; set; }
        /// <summary>
        /// ExchangeRateDate
        /// </summary>
        public System.DateTime ExchangeRateDate { get; set; }
        /// <summary>
        /// ChangeBy
        /// </summary>
        public System.String ChangeBy { get; set; }
        public System.String ClientCurrencyCode { get; set; }
		#endregion

	}
}