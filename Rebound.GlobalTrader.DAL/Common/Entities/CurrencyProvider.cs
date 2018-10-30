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
using System.Collections.Generic;
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL {
	
	public abstract class CurrencyProvider : DataAccess {
		static private CurrencyProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public CurrencyProvider Instance {
			get {
				if (_instance == null) _instance = (CurrencyProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Currencys.ProviderType));
				return _instance;
			}
		}
		public CurrencyProvider() {
			this.ConnectionString = Globals.Settings.Currencys.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Currency]
		/// </summary>
		public abstract bool Delete(System.Int32? currencyId);
		/// <summary>
		/// DeleteByGlobalCurrencyNo
		/// Calls [usp_delete_Currency_by_GlobalCurrencyNo]
		/// </summary>
		public abstract bool DeleteByGlobalCurrencyNo(System.Int32? globalCurrencyNo);
		/// <summary>
		/// DropDownBuyForClient
		/// Calls [usp_dropdown_Currency_Buy_For_Client]
		/// </summary>
		public abstract List<CurrencyDetails> DropDownBuyForClient(System.Int32? clientId);
        /// <summary>
        /// DropDownBuyForClientAndGlobal
        /// Calls [usp_dropdown_Currency_Buy_For_Client_And_GlobalCurrencyNo]
        /// </summary>
        public abstract List<CurrencyDetails> DropDownBuyForClientAndGlobal(System.Int32? clientId, System.Int32? globalCurrencyNo, System.Boolean? blnBuy);
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_Currency_for_Client]
		/// </summary>
		public abstract List<CurrencyDetails> DropDownForClient(System.Int32? clientId);
		/// <summary>
		/// DropDownSellForClient
		/// Calls [usp_dropdown_Currency_Sell_For_Client]
		/// </summary>
		public abstract List<CurrencyDetails> DropDownSellForClient(System.Int32? clientId);
        //[001] code start
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Currency]
		/// </summary>
        public abstract Int32 Insert(System.Int32? globalCurrencyNo, System.String currencyCode, System.String currencyDescription, System.String symbol, System.Int32? clientNo, System.Boolean? buy, System.Boolean? sell, System.Boolean? inactive, System.Int32? updatedBy, System.String notes);
        //[001] code end
        /// <summary>
        /// usp_insert_LocalCurrency
        /// </summary>
        /// <param name="currencyNo"></param>
        /// <param name="exchangeRate"></param>
        /// <param name="apply"></param>
        /// <param name="clientNo"></param>
        /// <returns></returns>
        public abstract Int32 InsertLocalCurrency(System.Int32 currencyNo, System.Double? exchangeRate, System.Boolean apply, System.Int32 clientNo, System.Int32? updatedBy);
        /// <summary>
        /// [usp_update_LocalCurrency]
        /// </summary>
        /// <param name="localCurrencyId"></param>
        /// <param name="currencyNo"></param>
        /// <param name="exchangeRate"></param>
        /// <param name="apply"></param>
        /// <param name="clientNo"></param>
        /// <returns></returns>
        public abstract bool UpdateLocalCurrency(System.Int32 localCurrencyId, System.Double? exchangeRate, System.Boolean apply, System.Int32 clientNo, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_Currency]
		/// </summary>
		public abstract CurrencyDetails Get(System.Int32? currencyId);
		/// <summary>
		/// GetConvertedValueBetweenTwoCurrencies
		/// Calls [usp_select_Currency_ConvertedValueBetweenTwoCurrencies]
		/// </summary>
		public abstract CurrencyDetails GetConvertedValueBetweenTwoCurrencies(System.Double? valueToBeConverted, System.Int32? currencyFromId, System.Int32? currencyToId, System.DateTime? exchangeRateDate);
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_Currency_for_Client]
		/// </summary>
		public abstract List<CurrencyDetails> GetListForClient(System.Int32? clientId, System.Boolean? includeInactive);
        //[001] code start
		/// <summary>
		/// Update
		/// Calls [usp_update_Currency]
		/// </summary>
        public abstract bool Update(System.Int32? currencyId, System.String currencyCode, System.String currencyDescription, System.String symbol, System.Int32? clientNo, System.Boolean? buy, System.Boolean? sell, System.Boolean? inactive, System.Int32? updatedBy, System.String notes);
        //[001] code end

        /// <summary>
        /// usp_selectAll_localCurrency_for_Client
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public abstract List<CurrencyDetails> GetLocalListForClient(System.Int32? clientId, out string clientLocalCurrencyDescription, out System.Int32? clientLocalCurrencyNo);

        /// <summary>
        /// DropDownLinkMultiCurrency
        /// Calls [usp_dropdown_LinkMultiCurrency]
        /// </summary>
        public abstract List<CurrencyDetails> DropDownLinkMultiCurrency(System.Int32? hubClientNo, System.Int32? customerClientNo, System.Int32? buyCurrencyNo);

		#endregion
				
		/// <summary>
		/// Returns a new CurrencyDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual CurrencyDetails GetCurrencyFromReader(DbDataReader reader) {
			CurrencyDetails currency = new CurrencyDetails();
			if (reader.HasRows) {
				currency.CurrencyId = GetReaderValue_Int32(reader, "CurrencyId", 0); //From: [Table]
				currency.GlobalCurrencyNo = GetReaderValue_Int32(reader, "GlobalCurrencyNo", 0); //From: [Table]
				currency.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_list_Activity_by_Client_with_filter]
				currency.CurrencyDescription = GetReaderValue_String(reader, "CurrencyDescription", ""); //From: [usp_select_Client]
				currency.Symbol = GetReaderValue_String(reader, "Symbol", ""); //From: [Table]
				currency.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				currency.Buy = GetReaderValue_Boolean(reader, "Buy", false); //From: [Table]
				currency.Sell = GetReaderValue_Boolean(reader, "Sell", false); //From: [Table]
				currency.Inactive = GetReaderValue_Boolean(reader, "Inactive", false); //From: [Table]
				currency.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				currency.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				currency.ConvertedValue = GetReaderValue_NullableDouble(reader, "ConvertedValue", null); //From: [usp_select_Currency_ConvertedValueBetweenTwoCurrencies]
				currency.ClientDefaultCurrencyCode = GetReaderValue_String(reader, "ClientDefaultCurrencyCode", ""); //From: [usp_selectAll_Currency_for_Client]
				currency.ClientDefaultCurrencyNo = GetReaderValue_Int32(reader, "ClientDefaultCurrencyNo", 0); //From: [usp_selectAll_Currency_for_Client]
			}
			return currency;
		}
	
		/// <summary>
		/// Returns a collection of CurrencyDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<CurrencyDetails> GetCurrencyCollectionFromReader(DbDataReader reader) {
			List<CurrencyDetails> currencys = new List<CurrencyDetails>();
			while (reader.Read()) currencys.Add(GetCurrencyFromReader(reader));
			return currencys;
		}
		
		
	}
}
