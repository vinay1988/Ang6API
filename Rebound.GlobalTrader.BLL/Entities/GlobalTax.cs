//Marker     Changed by      Date               Remarks
//[001]      Vinay           24/06/2013         CR:- Supplier Invoice
//[002]      Vinay           15/07/2013         ESMS Ref##-37 Add New Column named as purchage code under Setup => Company Settings => Tax Section 
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
		public partial class GlobalTax : BizObject {
		
		#region Properties

		protected static DAL.GlobalTaxElement Settings {
			get { return Globals.Settings.GlobalTaxs; }
		}

		/// <summary>
		/// TaxId
		/// </summary>
		public System.Int32 TaxId { get; set; }		
		/// <summary>
		/// TaxName
		/// </summary>
		public System.String TaxName { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
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
		/// TaxCode
		/// </summary>
		public System.String TaxCode { get; set; }		
		/// <summary>
		/// PrintNotes
		/// </summary>
		public System.String PrintNotes { get; set; }
        
        //[002] code start
        /// <summary>
        /// PurchaseTaxCode
        /// </summary>
        public System.String PurchaseTaxCode { get; set; }
        //[002] code end
		#endregion
		
		#region Methods
		
		
	

        //[001] code start
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Tax]
		/// </summary>
		public static Int32 Insert(System.String taxName, System.String notes, System.Boolean? inactive, System.String taxCode, System.String printNotes, System.Int32? updatedBy,System.String purchaseTaxCode) {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.GlobalTax.Insert(taxName, notes, inactive, taxCode, printNotes, updatedBy, purchaseTaxCode);
			return objReturn;
		}
        //[001] code end

		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Tax]
		/// </summary>
		public Int32 Insert() {
            return Rebound.GlobalTrader.DAL.SiteProvider.GlobalTax.Insert( TaxName, Notes, Inactive, TaxCode, PrintNotes, UpdatedBy, PurchaseTaxCode);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_Tax]
		/// </summary>
        public static GlobalTax Get(System.Int32? taxId)
        {
            Rebound.GlobalTrader.DAL.GlobalTaxDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.GlobalTax.Get(taxId);
			if (objDetails == null) {
				return null;
			} else {
                GlobalTax obj = new GlobalTax();
				obj.TaxId = objDetails.TaxId;
				obj.TaxName = objDetails.TaxName;
				obj.ClientNo = objDetails.ClientNo;
				obj.Notes = objDetails.Notes;
				obj.Inactive = objDetails.Inactive;
				obj.TaxCode = objDetails.TaxCode;
				obj.PrintNotes = objDetails.PrintNotes;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_Tax_for_Client]
		/// </summary>
        public static List<GlobalTax> GetListForClient()
        {
            List<GlobalTaxDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GlobalTax.GetListForClient();
			if (lstDetails == null) {
                return new List<GlobalTax>();
			} else {
                List<GlobalTax> lst = new List<GlobalTax>();
                foreach (GlobalTaxDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.GlobalTax obj = new Rebound.GlobalTrader.BLL.GlobalTax();
					obj.TaxId = objDetails.TaxId;
					obj.TaxName = objDetails.TaxName;
				
					obj.Notes = objDetails.Notes;
					obj.Inactive = objDetails.Inactive;
					obj.TaxCode = objDetails.TaxCode;
					obj.PrintNotes = objDetails.PrintNotes;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
                    //[002] code start
                    obj.PurchaseTaxCode = objDetails.PurchaseTaxCode;
                    //[002] code start
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
		/// Calls [usp_update_Tax]
		/// </summary>
		public static bool Update(System.Int32? taxId,  System.String taxName, System.String notes, System.String taxCode, System.Boolean? inactive, System.String printNotes, System.Int32? updatedBy,System.String purchaseTaxCode) {
            return Rebound.GlobalTrader.DAL.SiteProvider.GlobalTax.Update(taxId,  taxName, notes, taxCode, inactive, printNotes, updatedBy, purchaseTaxCode);
		}
        //[001] code end

		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Tax]
		/// </summary>
		public bool Update() {
            return Rebound.GlobalTrader.DAL.SiteProvider.GlobalTax.Update(TaxId,  TaxName, Notes, TaxCode, Inactive, PrintNotes, UpdatedBy, PurchaseTaxCode);
		}
        
            //[001] code start
            /// <summary>
            /// Get Tax Code according to client
            /// Call Proc [usp_dropdown_PurchaseTaxCode_for_Client]
            /// </summary>
            /// <param name="clientId"></param>
            /// <returns></returns>
        public static List<GlobalTax> DropDownPurchaseTaxCodeForClient()
        {
            List<GlobalTaxDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.GlobalTax.DropDownPurchaseTaxCodeForClient();
            if (lstDetails == null)
            {
                return new List<GlobalTax>();
            }
            else
            {
                List<GlobalTax> lst = new List<GlobalTax>();
                foreach (GlobalTaxDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.GlobalTax obj = new Rebound.GlobalTrader.BLL.GlobalTax();
                    obj.TaxId = objDetails.TaxId;
                    obj.TaxName = objDetails.TaxName;
                    obj.TaxCode = objDetails.TaxCode;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
        //[001] code end

        private static GlobalTax PopulateFromDBDetailsObject(GlobalTaxDetails obj)
        {
            GlobalTax objNew = new GlobalTax();
			objNew.TaxId = obj.TaxId;
			objNew.TaxName = obj.TaxName;
			objNew.ClientNo = obj.ClientNo;
			objNew.Notes = obj.Notes;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.TaxCode = obj.TaxCode;
			objNew.PrintNotes = obj.PrintNotes;
            return objNew;
        }
		
		#endregion
		
	}
}