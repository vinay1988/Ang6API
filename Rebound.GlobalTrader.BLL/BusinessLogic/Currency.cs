using System;
using System.Collections.Generic;
using System.Text;

namespace Rebound.GlobalTrader.BLL {
	public partial class Currency : BizObject {

		public static Double GetCurrentRateAtDate(int intCurrencyID, DateTime dtmExchangeRateDate) {
			Double dbl = 1;
			BLL.CurrencyRate cr = BLL.CurrencyRate.GetCurrentAtDate(intCurrencyID, dtmExchangeRateDate);
			if (cr != null) dbl = (double)cr.ExchangeRate;
			return dbl;
		}

		public static Double ConvertValueBetweenTwoCurrencies(double? dblValueToConvert, int intFromCurrencyID, int intToCurrencyID, DateTime dtmExchangeRateDate) {
			Double dbl = (dblValueToConvert == null) ? 0 : (double)dblValueToConvert;
			if (dbl != 0) {
				BLL.Currency cu = BLL.Currency.GetConvertedValueBetweenTwoCurrencies(dblValueToConvert, intFromCurrencyID, intToCurrencyID, dtmExchangeRateDate);
				if (cu != null) dbl = (double)cu.ConvertedValue;
			}
			return dbl;
		}

		public static Double ConvertValueFromBaseCurrency(double? dblValueToConvert, Double dblRate) {
			Double dblValueToConvert_AsDouble = (dblValueToConvert == null) ? 0 : (double)dblValueToConvert;
			return (double)dblValueToConvert_AsDouble * dblRate;
		}

		public static Double ConvertValueFromBaseCurrency(double? dblValueToConvert, int intToCurrencyID, DateTime dtmExchangeRateDate) {
			return ConvertValueFromBaseCurrency(dblValueToConvert, GetCurrentRateAtDate(intToCurrencyID, dtmExchangeRateDate));
		}

		public static Double ConvertValueToBaseCurrency(double? dblValueToConvert, Double dblRate) {
			Double dblValueToConvert_AsDouble = (dblValueToConvert == null) ? 0 : (double)dblValueToConvert;
			return (double)dblValueToConvert_AsDouble / dblRate;
		}

		public static Double ConvertValueToBaseCurrency(double? dblValueToConvert, int intFromCurrencyID, DateTime dtmExchangeRateDate) {
			return ConvertValueToBaseCurrency(dblValueToConvert, GetCurrentRateAtDate(intFromCurrencyID, dtmExchangeRateDate));
		}

      

	}
}
