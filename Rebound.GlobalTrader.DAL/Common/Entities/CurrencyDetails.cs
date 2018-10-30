// Marker     Changed by      Date         Remarks
// [001]      Vinay           16/05/2012   This need to add notes field

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
	
	public class CurrencyDetails {
		
		#region Constructors
		
		public CurrencyDetails() { }
		
		#endregion
		
		#region Properties
	
		/// <summary>
		/// CurrencyId (from Table)
		/// </summary>
		public System.Int32 CurrencyId { get; set; }
		/// <summary>
		/// GlobalCurrencyNo (from Table)
		/// </summary>
		public System.Int32 GlobalCurrencyNo { get; set; }
		/// <summary>
		/// CurrencyCode (from usp_list_Activity_by_Client_with_filter)
		/// </summary>
		public System.String CurrencyCode { get; set; }
		/// <summary>
		/// CurrencyDescription (from usp_select_Client)
		/// </summary>
		public System.String CurrencyDescription { get; set; }
		/// <summary>
		/// Symbol (from Table)
		/// </summary>
		public System.String Symbol { get; set; }
		/// <summary>
		/// ClientNo (from Table)
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// Buy (from Table)
		/// </summary>
		public System.Boolean Buy { get; set; }
		/// <summary>
		/// Sell (from Table)
		/// </summary>
		public System.Boolean Sell { get; set; }
		/// <summary>
		/// Inactive (from Table)
		/// </summary>
		public System.Boolean Inactive { get; set; }
		/// <summary>
		/// UpdatedBy (from Table)
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP (from Table)
		/// </summary>
		public System.DateTime DLUP { get; set; }
		/// <summary>
		/// ConvertedValue (from usp_select_Currency_ConvertedValueBetweenTwoCurrencies)
		/// </summary>
		public System.Double? ConvertedValue { get; set; }
		/// <summary>
		/// ClientDefaultCurrencyCode (from usp_selectAll_Currency_for_Client)
		/// </summary>
		public System.String ClientDefaultCurrencyCode { get; set; }
		/// <summary>
		/// ClientDefaultCurrencyNo (from usp_selectAll_Currency_for_Client)
		/// </summary>
		public System.Int32 ClientDefaultCurrencyNo { get; set; }
        //[001] code start
        /// <summary>
        /// Notes
        /// </summary>
        public System.String Notes { get; set; }
        //[001] code end
        /// <summary>
        /// LocalCurrencyId
        /// </summary>
        public System.Int32 LocalCurrencyId { get; set; }
        /// <summary>
        /// LocalExchangeRate
        /// </summary>
        public System.Double? LocalExchangeRate { get; set; }

        /// <summary>
        /// ClientDefaultLocalCurrencyDesc (from usp_selectAll_localCurrency_for_Client)
        /// </summary>
        public System.String ClientDefaultLocalCurrencyDesc { get; set; }
        /// <summary>
        /// ClientDefaultLocalCurrencyNo (from usp_selectAll_localCurrency_for_Client)
        /// </summary>
        public System.Int32 ClientDefaultLocalCurrencyNo { get; set; }
        /// <summary>
        /// LinkMultiCurrencyId
        /// </summary>
        public System.Int32? LinkMultiCurrencyId { get; set; }

		#endregion

	}
}
