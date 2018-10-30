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
using Rebound.GlobalTrader.DAL;
using Rebound.GlobalTrader.BLL;

namespace Rebound.GlobalTrader.BLL {
		public partial class Currency : BizObject {
		
		#region Properties

		protected static DAL.CurrencyElement Settings {
			get { return Globals.Settings.Currencys; }
		}

		/// <summary>
		/// CurrencyId
		/// </summary>
		public System.Int32 CurrencyId { get; set; }		
		/// <summary>
		/// GlobalCurrencyNo
		/// </summary>
		public System.Int32 GlobalCurrencyNo { get; set; }		
		/// <summary>
		/// CurrencyCode
		/// </summary>
		public System.String CurrencyCode { get; set; }		
		/// <summary>
		/// CurrencyDescription
		/// </summary>
		public System.String CurrencyDescription { get; set; }		
		/// <summary>
		/// Symbol
		/// </summary>
		public System.String Symbol { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// Buy
		/// </summary>
		public System.Boolean Buy { get; set; }		
		/// <summary>
		/// Sell
		/// </summary>
		public System.Boolean Sell { get; set; }		
		/// <summary>
		/// Inactive
		/// </summary>
		public System.Boolean Inactive { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// ConvertedValue
		/// </summary>
		public System.Double? ConvertedValue { get; set; }		
		/// <summary>
		/// ClientDefaultCurrencyCode
		/// </summary>
		public System.String ClientDefaultCurrencyCode { get; set; }		
		/// <summary>
		/// ClientDefaultCurrencyNo
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
        /// ClientDefaultLocalCurrencyDesc
        /// </summary>
        public System.String ClientDefaultLocalCurrencyDesc { get; set; }
        /// <summary>
        /// ClientDefaultLocalCurrencyNo
        /// </summary>
        public System.Int32 ClientDefaultLocalCurrencyNo { get; set; }
        /// <summary>
        /// LinkMultiCurrencyId
        /// </summary>
        public System.Int32? LinkMultiCurrencyId { get; set; }
     
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Currency]
		/// </summary>
		public static bool Delete(System.Int32? currencyId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Currency.Delete(currencyId);
		}
		/// <summary>
		/// DeleteByGlobalCurrencyNo
		/// Calls [usp_delete_Currency_by_GlobalCurrencyNo]
		/// </summary>
		public static bool DeleteByGlobalCurrencyNo(System.Int32? globalCurrencyNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Currency.DeleteByGlobalCurrencyNo(globalCurrencyNo);
		}
		/// <summary>
		/// DropDownBuyForClient
		/// Calls [usp_dropdown_Currency_Buy_For_Client]
		/// </summary>
		public static List<Currency> DropDownBuyForClient(System.Int32? clientId) {
			List<CurrencyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Currency.DropDownBuyForClient(clientId);
			if (lstDetails == null) {
				return new List<Currency>();
			} else {
				List<Currency> lst = new List<Currency>();
				foreach (CurrencyDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Currency obj = new Rebound.GlobalTrader.BLL.Currency();
					obj.CurrencyId = objDetails.CurrencyId;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.CurrencyCode = objDetails.CurrencyCode;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
        /// <summary>
        /// DropDownBuyForClientAndGlobal
        /// Calls [usp_dropdown_Currency_Buy_For_Client_And_GlobalCurrencyNo]
        /// </summary>
        public static List<Currency> DropDownBuyForClientAndGlobal(System.Int32? clientId,System.Int32? globalCurrencyNo,System.Boolean? blnBuy)
        {
            List<CurrencyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Currency.DropDownBuyForClientAndGlobal(clientId, globalCurrencyNo, blnBuy);
            if (lstDetails == null)
            {
                return new List<Currency>();
            }
            else
            {
                List<Currency> lst = new List<Currency>();
                foreach (CurrencyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Currency obj = new Rebound.GlobalTrader.BLL.Currency();
                    obj.CurrencyId = objDetails.CurrencyId;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }


		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_Currency_for_Client]
		/// </summary>
		public static List<Currency> DropDownForClient(System.Int32? clientId) {
			List<CurrencyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Currency.DropDownForClient(clientId);
			if (lstDetails == null) {
				return new List<Currency>();
			} else {
				List<Currency> lst = new List<Currency>();
				foreach (CurrencyDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Currency obj = new Rebound.GlobalTrader.BLL.Currency();
					obj.CurrencyId = objDetails.CurrencyId;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// DropDownSellForClient
		/// Calls [usp_dropdown_Currency_Sell_For_Client]
		/// </summary>
		public static List<Currency> DropDownSellForClient(System.Int32? clientId) {
			List<CurrencyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Currency.DropDownSellForClient(clientId);
			if (lstDetails == null) {
				return new List<Currency>();
			} else {
				List<Currency> lst = new List<Currency>();
				foreach (CurrencyDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Currency obj = new Rebound.GlobalTrader.BLL.Currency();
					obj.CurrencyId = objDetails.CurrencyId;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.CurrencyCode = objDetails.CurrencyCode;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        /// <summary>
        /// DropDownLinkMultiCurrency
        /// Calls [usp_dropdown_LinkMultiCurrency]
        /// </summary>
        public static List<Currency> DropDownLinkMultiCurrency(System.Int32? hubClientNo, System.Int32? customerClientNo, System.Int32? buyCurrencyNo)
        {
            List<CurrencyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Currency.DropDownLinkMultiCurrency(hubClientNo, customerClientNo, buyCurrencyNo);
            if (lstDetails == null)
            {
                return new List<Currency>();
            }
            else
            {
                List<Currency> lst = new List<Currency>();
                foreach (CurrencyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Currency obj = new Rebound.GlobalTrader.BLL.Currency();
                    obj.CurrencyId = objDetails.CurrencyId;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.LinkMultiCurrencyId = objDetails.LinkMultiCurrencyId;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Currency]
		/// </summary>
        public static Int32 Insert(System.Int32? globalCurrencyNo, System.String currencyCode, System.String currencyDescription, System.String symbol, System.Int32? clientNo, System.Boolean? buy, System.Boolean? sell, System.Boolean? inactive, System.Int32? updatedBy, System.String notes)
        {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Currency.Insert(globalCurrencyNo, currencyCode, currencyDescription, symbol, clientNo, buy, sell, inactive, updatedBy, notes);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Currency]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Currency.Insert(GlobalCurrencyNo, CurrencyCode, CurrencyDescription, Symbol, ClientNo, Buy, Sell, Inactive, UpdatedBy, Notes);
		}
        /// <summary>
        /// [usp_insert_LocalCurrency]
        /// </summary>
        /// <param name="currencyNo"></param>
        /// <param name="exchangeRate"></param>
        /// <param name="apply"></param>
        /// <param name="clientNo"></param>
        /// <returns></returns>
        public static Int32 InsertLocalCurrency(System.Int32 globalCurrencyNo, System.Double? exchangeRate, System.Boolean Inactive, System.Int32 clientNo, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Currency.InsertLocalCurrency(globalCurrencyNo, exchangeRate, Inactive, clientNo, updatedBy);
            return objReturn;
        }
        /// <summary>
        /// [usp_update_LocalCurrency]
        /// </summary>
        /// <param name="localCurrencyId"></param>
        /// <param name="currencyNo"></param>
        /// <param name="exchangeRate"></param>
        /// <param name="apply"></param>
        /// <param name="clientNo"></param>
        /// <returns></returns>
        public static bool UpdateLocalCurrency(System.Int32 localCurrencyId,  System.Double? exchangeRate, System.Boolean Inactive, System.Int32 clientNo,System.Int32? updatedBy)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Currency.UpdateLocalCurrency(localCurrencyId, exchangeRate, Inactive, clientNo, updatedBy);
        }
		/// <summary>
		/// Get
		/// Calls [usp_select_Currency]
		/// </summary>
		public static Currency Get(System.Int32? currencyId) {
			Rebound.GlobalTrader.DAL.CurrencyDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Currency.Get(currencyId);
			if (objDetails == null) {
				return null;
			} else {
				Currency obj = new Currency();
				obj.CurrencyId = objDetails.CurrencyId;
				obj.CurrencyCode = objDetails.CurrencyCode;
				obj.CurrencyDescription = objDetails.CurrencyDescription;
				obj.Symbol = objDetails.Symbol;
				obj.ClientNo = objDetails.ClientNo;
				obj.Buy = objDetails.Buy;
				obj.Sell = objDetails.Sell;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
                //[001] code start
                obj.Notes = objDetails.Notes;
                //[001] code end
                obj.GlobalCurrencyNo = objDetails.GlobalCurrencyNo;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetConvertedValueBetweenTwoCurrencies
		/// Calls [usp_select_Currency_ConvertedValueBetweenTwoCurrencies]
		/// </summary>
		public static Currency GetConvertedValueBetweenTwoCurrencies(System.Double? valueToBeConverted, System.Int32? currencyFromId, System.Int32? currencyToId, System.DateTime? exchangeRateDate) {
			Rebound.GlobalTrader.DAL.CurrencyDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Currency.GetConvertedValueBetweenTwoCurrencies(valueToBeConverted, currencyFromId, currencyToId, exchangeRateDate);
			if (objDetails == null) {
				return null;
			} else {
				Currency obj = new Currency();
				obj.ConvertedValue = objDetails.ConvertedValue;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_Currency_for_Client]
		/// </summary>
		public static List<Currency> GetListForClient(System.Int32? clientId, System.Boolean? includeInactive) {
			List<CurrencyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Currency.GetListForClient(clientId, includeInactive);
			if (lstDetails == null) {
				return new List<Currency>();
			} else {
				List<Currency> lst = new List<Currency>();
				foreach (CurrencyDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Currency obj = new Rebound.GlobalTrader.BLL.Currency();
					obj.CurrencyId = objDetails.CurrencyId;
					obj.GlobalCurrencyNo = objDetails.GlobalCurrencyNo;
					obj.CurrencyCode = objDetails.CurrencyCode;
					obj.CurrencyDescription = objDetails.CurrencyDescription;
					obj.Symbol = objDetails.Symbol;
					obj.ClientNo = objDetails.ClientNo;
					obj.Buy = objDetails.Buy;
					obj.Sell = objDetails.Sell;
					obj.Inactive = objDetails.Inactive;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.ClientDefaultCurrencyCode = objDetails.ClientDefaultCurrencyCode;
					obj.ClientDefaultCurrencyNo = objDetails.ClientDefaultCurrencyNo;
                    //[001] code start
                    obj.Notes = objDetails.Notes;
                    //[001] code end
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_Currency]
		/// </summary>
        public static bool Update(System.Int32? currencyId, System.String currencyCode, System.String currencyDescription, System.String symbol, System.Int32? clientNo, System.Boolean? buy, System.Boolean? sell, System.Boolean? inactive, System.Int32? updatedBy, System.String notes)
        {
			return Rebound.GlobalTrader.DAL.SiteProvider.Currency.Update(currencyId, currencyCode, currencyDescription, symbol, clientNo, buy, sell, inactive, updatedBy, notes);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Currency]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Currency.Update(CurrencyId, CurrencyCode, CurrencyDescription, Symbol, ClientNo, Buy, Sell, Inactive, UpdatedBy, Notes);
		}

        private static Currency PopulateFromDBDetailsObject(CurrencyDetails obj) {
            Currency objNew = new Currency();
			objNew.CurrencyId = obj.CurrencyId;
			objNew.GlobalCurrencyNo = obj.GlobalCurrencyNo;
			objNew.CurrencyCode = obj.CurrencyCode;
			objNew.CurrencyDescription = obj.CurrencyDescription;
			objNew.Symbol = obj.Symbol;
			objNew.ClientNo = obj.ClientNo;
			objNew.Buy = obj.Buy;
			objNew.Sell = obj.Sell;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.ConvertedValue = obj.ConvertedValue;
			objNew.ClientDefaultCurrencyCode = obj.ClientDefaultCurrencyCode;
			objNew.ClientDefaultCurrencyNo = obj.ClientDefaultCurrencyNo;
            return objNew;
        }
        /// <summary>
        /// GetListForClient
        /// Calls [usp_selectAll_localCurrency_for_Client]
        /// </summary>
        public static List<Currency> GetLocalListForClient(System.Int32? clientId, out string clientLocalCurrencyDescription, out System.Int32? clientLocalCurrencyNo)
        {
            List<CurrencyDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Currency.GetLocalListForClient(clientId, out clientLocalCurrencyDescription, out clientLocalCurrencyNo);
            if (lstDetails == null)
            {
                return new List<Currency>();
            }
            else
            {
                List<Currency> lst = new List<Currency>();
                foreach (CurrencyDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Currency obj = new Rebound.GlobalTrader.BLL.Currency();
                    obj.LocalCurrencyId = objDetails.LocalCurrencyId;
                    obj.LocalExchangeRate = objDetails.LocalExchangeRate;
                    obj.CurrencyId = objDetails.CurrencyId;
                    obj.CurrencyCode = objDetails.CurrencyCode;
                    obj.CurrencyDescription = objDetails.CurrencyDescription;
                    obj.Symbol = objDetails.Symbol;
                    obj.ClientNo = objDetails.ClientNo;
                    obj.DLUP = objDetails.DLUP;
                    obj.Inactive = objDetails.Inactive;
                    obj.ClientDefaultLocalCurrencyDesc = objDetails.ClientDefaultLocalCurrencyDesc;
                    obj.ClientDefaultLocalCurrencyNo = objDetails.ClientDefaultLocalCurrencyNo;
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