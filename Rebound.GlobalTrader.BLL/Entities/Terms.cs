//Marker     changed by      date         Remarks
//[001]      Vinay           28/11/2012   Apply a bank fee charge to the customers final invoice
//[002]      Vinay           11/08/2016   Apply a PO bank fee charge
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
		public partial class Terms : BizObject {
		
		#region Properties

		protected static DAL.TermsElement Settings {
			get { return Globals.Settings.Termss; }
		}

		/// <summary>
		/// TermsId
		/// </summary>
		public System.Int32 TermsId { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// Days
		/// </summary>
		public System.Int32 Days { get; set; }		
		/// <summary>
		/// TermsName
		/// </summary>
		public System.String TermsName { get; set; }		
		/// <summary>
		/// Buy
		/// </summary>
		public System.Boolean Buy { get; set; }		
		/// <summary>
		/// Sell
		/// </summary>
		public System.Boolean Sell { get; set; }		
		/// <summary>
		/// InAdvance
		/// </summary>
		public System.Boolean InAdvance { get; set; }		
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
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }
		//[001] code start
        /// <summary>
        /// BankFee
        /// </summary>
        public System.Double? BankFee { get; set; }
        /// <summary>
        /// IsApplyBankFee
        /// </summary>
        public System.Boolean? IsApplyBankFee { get; set; }
        //[001] code end

        //[002] code start
        /// <summary>
        /// POBankFee
        /// </summary>
        public System.Double? POBankFee { get; set; }
        /// <summary>
        /// IsApplyPOBankFee
        /// </summary>
        public System.Boolean? IsApplyPOBankFee { get; set; }
        //[002] code end

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Terms]
		/// </summary>
		public static bool Delete(System.Int32? termsId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Terms.Delete(termsId);
		}
		/// <summary>
		/// DropDownBuyForClient
		/// Calls [usp_dropdown_Terms_Buy_for_Client]
		/// </summary>
		public static List<Terms> DropDownBuyForClient(System.Int32? clientId) {
			List<TermsDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Terms.DropDownBuyForClient(clientId);
			if (lstDetails == null) {
				return new List<Terms>();
			} else {
				List<Terms> lst = new List<Terms>();
				foreach (TermsDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Terms obj = new Rebound.GlobalTrader.BLL.Terms();
					obj.TermsId = objDetails.TermsId;
					obj.TermsName = objDetails.TermsName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_Terms_for_Client]
		/// </summary>
		public static List<Terms> DropDownForClient(System.Int32? clientId) {
			List<TermsDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Terms.DropDownForClient(clientId);
			if (lstDetails == null) {
				return new List<Terms>();
			} else {
				List<Terms> lst = new List<Terms>();
				foreach (TermsDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Terms obj = new Rebound.GlobalTrader.BLL.Terms();
					obj.TermsId = objDetails.TermsId;
					obj.TermsName = objDetails.TermsName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// DropDownSellForClient
		/// Calls [usp_dropdown_Terms_Sell_for_Client]
		/// </summary>
		public static List<Terms> DropDownSellForClient(System.Int32? clientId) {
			List<TermsDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Terms.DropDownSellForClient(clientId);
			if (lstDetails == null) {
				return new List<Terms>();
			} else {
				List<Terms> lst = new List<Terms>();
				foreach (TermsDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Terms obj = new Rebound.GlobalTrader.BLL.Terms();
					obj.TermsId = objDetails.TermsId;
					obj.TermsName = objDetails.TermsName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
        //[001] code start
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Terms]
		/// </summary>
        public static Int32 Insert(System.Int32? clientNo, System.Int32? days, System.String termsName, System.Boolean? buy, System.Boolean? sell, System.Boolean? inAdvance, System.Int32? updatedBy, System.Boolean? isApplyBankFee, System.Double? bankFee,System.Boolean? isApplyPOBankFee, System.Double? poBankFee)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Terms.Insert(clientNo, days, termsName, buy, sell, inAdvance, updatedBy, isApplyBankFee, bankFee, isApplyBankFee, poBankFee);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Terms]
		/// </summary>
		public Int32 Insert() {
            return Rebound.GlobalTrader.DAL.SiteProvider.Terms.Insert(ClientNo, Days, TermsName, Buy, Sell, InAdvance, UpdatedBy, IsApplyBankFee, BankFee, IsApplyPOBankFee, POBankFee);
		}
        //[001] code end
		/// <summary>
		/// Get
		/// Calls [usp_select_Terms]
		/// </summary>
		public static Terms Get(System.Int32? termsId) {
			Rebound.GlobalTrader.DAL.TermsDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Terms.Get(termsId);
			if (objDetails == null) {
				return null;
			} else {
				Terms obj = new Terms();
				obj.TermsId = objDetails.TermsId;
				obj.ClientNo = objDetails.ClientNo;
				obj.Days = objDetails.Days;
				obj.TermsName = objDetails.TermsName;
				obj.Buy = objDetails.Buy;
				obj.Sell = objDetails.Sell;
				obj.InAdvance = objDetails.InAdvance;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_Terms_for_Client]
		/// </summary>
		public static List<Terms> GetListForClient(System.Int32? clientId, System.Int32? pageIndex, System.Int32? pageSize) {
			List<TermsDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Terms.GetListForClient(clientId, pageIndex, pageSize);
			if (lstDetails == null) {
				return new List<Terms>();
			} else {
				List<Terms> lst = new List<Terms>();
				foreach (TermsDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Terms obj = new Rebound.GlobalTrader.BLL.Terms();
					obj.TermsId = objDetails.TermsId;
					obj.ClientNo = objDetails.ClientNo;
					obj.Days = objDetails.Days;
					obj.TermsName = objDetails.TermsName;
					obj.Buy = objDetails.Buy;
					obj.Sell = objDetails.Sell;
					obj.InAdvance = objDetails.InAdvance;
					obj.Inactive = objDetails.Inactive;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.RowNum = objDetails.RowNum;
                    //[001] code start
                    obj.IsApplyBankFee = objDetails.IsApplyBankFee;
                    obj.BankFee = objDetails.BankFee;
                    //[001] code end

                    //[002] code start
                    obj.IsApplyPOBankFee = objDetails.IsApplyPOBankFee;
                    obj.POBankFee = objDetails.POBankFee;
                    //[002] code end
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
        //[001] code start
		/// <summary>
		/// Update
		/// Calls [usp_update_Terms]
		/// </summary>
        public static bool Update(System.Int32? termsId, System.Int32? clientNo, System.Int32? days, System.String termsName, System.Boolean? buy, System.Boolean? sell, System.Boolean? inAdvance, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? isApplyBankFee, System.Double? bankFee, System.Boolean? isApplyPOBankFee, System.Double? poBankFee)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Terms.Update(termsId, clientNo, days, termsName, buy, sell, inAdvance, inactive, updatedBy, isApplyBankFee, bankFee, isApplyPOBankFee, poBankFee);
		}
        //[001] code end
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Terms]
		/// </summary>
		public bool Update() {
            return Rebound.GlobalTrader.DAL.SiteProvider.Terms.Update(TermsId, ClientNo, Days, TermsName, Buy, Sell, InAdvance, Inactive, UpdatedBy, IsApplyBankFee, BankFee, IsApplyPOBankFee, POBankFee);
		}

        private static Terms PopulateFromDBDetailsObject(TermsDetails obj) {
            Terms objNew = new Terms();
			objNew.TermsId = obj.TermsId;
			objNew.ClientNo = obj.ClientNo;
			objNew.Days = obj.Days;
			objNew.TermsName = obj.TermsName;
			objNew.Buy = obj.Buy;
			objNew.Sell = obj.Sell;
			objNew.InAdvance = obj.InAdvance;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.RowNum = obj.RowNum;
            return objNew;
        }
		
		#endregion
		
	}
}