// Marker     Changed by      Date         Remarks
// [001]      Vinay           12/11/2014   Display history (log) of exchange rate change in the local currency
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
	
	public abstract class CurrencyRateProvider : DataAccess {
		static private CurrencyRateProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public CurrencyRateProvider Instance {
			get {
				if (_instance == null) _instance = (CurrencyRateProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.CurrencyRates.ProviderType));
				return _instance;
			}
		}
		public CurrencyRateProvider() {
			this.ConnectionString = Globals.Settings.CurrencyRates.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_CurrencyRate]
		/// </summary>
		public abstract bool Delete(System.Int32? currencyRateId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_CurrencyRate]
		/// </summary>
		public abstract Int32 Insert(System.Int32? currencyNo, System.DateTime? currencyDate, System.Double? exchangeRate, System.Boolean? repriceOpenOrders, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_CurrencyRate]
		/// </summary>
		public abstract CurrencyRateDetails Get(System.Int32? currencyRateId);
		/// <summary>
		/// GetCurrentAtDate
		/// Calls [usp_select_CurrencyRate_Current_at_Date]
		/// </summary>
		public abstract CurrencyRateDetails GetCurrentAtDate(System.Int32? currencyNo, System.DateTime? datePoint);
		/// <summary>
		/// GetListForCurrency
		/// Calls [usp_selectAll_CurrencyRate_for_Currency]
		/// </summary>
		public abstract List<CurrencyRateDetails> GetListForCurrency(System.Int32? currencyId);
		/// <summary>
		/// Update
		/// Calls [usp_update_CurrencyRate]
		/// </summary>
		public abstract bool Update(System.Int32? currencyRateId, System.Int32? currencyNo, System.DateTime? currencyDate, System.Double? exchangeRate, System.Boolean? repriceOpenOrders, System.Int32? updatedBy);

        //[001] code start
        /// <summary>
        /// GetListForExchangeRate
        /// Calls [usp_selectAll_ExchangeRate_for_LocalCurrency]
        /// </summary>
        public abstract List<CurrencyRateDetails> GetListForExchangeRate(System.Int32? localCurrencyId);
        //[001] code start
		#endregion
				
		/// <summary>
		/// Returns a new CurrencyRateDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual CurrencyRateDetails GetCurrencyRateFromReader(DbDataReader reader) {
			CurrencyRateDetails currencyRate = new CurrencyRateDetails();
			if (reader.HasRows) {
				currencyRate.CurrencyRateId = GetReaderValue_Int32(reader, "CurrencyRateId", 0); //From: [Table]
				currencyRate.CurrencyNo = GetReaderValue_Int32(reader, "CurrencyNo", 0); //From: [usp_selectAll_Allocation_for_CustomerRMALine]
				currencyRate.CurrencyDate = GetReaderValue_DateTime(reader, "CurrencyDate", DateTime.MinValue); //From: [Table]
				currencyRate.ExchangeRate = GetReaderValue_Double(reader, "ExchangeRate", 0); //From: [Table]
				currencyRate.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				currencyRate.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				currencyRate.RepriceOpenOrders = GetReaderValue_NullableBoolean(reader, "RepriceOpenOrders", null); //From: [Table]
				currencyRate.CurrencyCode = GetReaderValue_String(reader, "CurrencyCode", ""); //From: [usp_list_Activity_by_Client_with_filter]
			}
			return currencyRate;
		}
	
		/// <summary>
		/// Returns a collection of CurrencyRateDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<CurrencyRateDetails> GetCurrencyRateCollectionFromReader(DbDataReader reader) {
			List<CurrencyRateDetails> currencyRates = new List<CurrencyRateDetails>();
			while (reader.Read()) currencyRates.Add(GetCurrencyRateFromReader(reader));
			return currencyRates;
		}
		
		
	}
}