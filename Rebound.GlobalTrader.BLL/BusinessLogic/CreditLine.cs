using System;
using System.Collections.Generic;
using System.Text;

namespace Rebound.GlobalTrader.BLL {
	public partial class CreditLine : BizObject {

		private bool _blnGotCurrencyRate = false;
		private double _dblCurrencyRate = 1;
		public double CurrencyRate {
			get {
				if (!_blnGotCurrencyRate) {
					_dblCurrencyRate = Currency.GetCurrentRateAtDate(CurrencyNo, ReferenceDate);
					_blnGotCurrencyRate = true;
				}
				return _dblCurrencyRate;
			}
		}

		public double LandedCostInCreditCurrency {
			get {
				return Currency.ConvertValueFromBaseCurrency(LandedCost, CurrencyRate);
			}
		}

		/// <summary>
		/// Is the line a service?
		/// Requires fields: ServiceNo
		/// </summary>
		public bool IsService {
			get {
				return (ServiceNo > 0);
			}
		}

	}
}
