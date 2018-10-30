//Marker     Changed by      Date         Remarks
//[001]      Vinay           31/07/2012   Add enable/disable link in incoterms
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
		public partial class Incoterm : BizObject {
		
		#region Properties

		protected static DAL.IncotermElement Settings {
			get { return Globals.Settings.Incoterms; }
		}

		/// <summary>
		/// IncotermId
		/// </summary>
		public System.Int32 IncotermId { get; set; }		
		/// <summary>
		/// Code
		/// </summary>
		public System.String Code { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }
        //[001] code start
        /// <summary>
        /// Active
        /// </summary>
        public System.Boolean Active { get; set; }
        //[001] code end
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Incoterm]
		/// </summary>
		public static bool Delete(System.Int32? incotermId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Incoterm.Delete(incotermId);
		}
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_Incoterm]
		/// </summary>
		public static List<Incoterm> DropDown() {
			List<IncotermDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Incoterm.DropDown();
			if (lstDetails == null) {
				return new List<Incoterm>();
			} else {
				List<Incoterm> lst = new List<Incoterm>();
				foreach (IncotermDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Incoterm obj = new Rebound.GlobalTrader.BLL.Incoterm();
					obj.IncotermId = objDetails.IncotermId;
					obj.Name = objDetails.Name;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Incoterm]
		/// </summary>
		public static Int32 Insert(System.String code, System.String name) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Incoterm.Insert(code, name);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Incoterm]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Incoterm.Insert(Code, Name);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_Incoterm]
		/// </summary>
		public static Incoterm Get(System.Int32? incotermId) {
			Rebound.GlobalTrader.DAL.IncotermDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Incoterm.Get(incotermId);
			if (objDetails == null) {
				return null;
			} else {
				Incoterm obj = new Incoterm();
				obj.IncotermId = objDetails.IncotermId;
				obj.Code = objDetails.Code;
				obj.Name = objDetails.Name;
                //[001] code start
                obj.Active = objDetails.Active;
                //[001] code end
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_Incoterm]
		/// </summary>
		public static List<Incoterm> GetList() {
			List<IncotermDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Incoterm.GetList();
			if (lstDetails == null) {
				return new List<Incoterm>();
			} else {
				List<Incoterm> lst = new List<Incoterm>();
				foreach (IncotermDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Incoterm obj = new Rebound.GlobalTrader.BLL.Incoterm();
					obj.IncotermId = objDetails.IncotermId;
					obj.Code = objDetails.Code;
					obj.Name = objDetails.Name;
                    //[001] code start
                    obj.Active = objDetails.Active;
                    //[001] code end
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
		/// Calls [usp_update_Incoterm]
		/// </summary>
		public static bool Update(System.Int32? incotermId, System.String code, System.String name) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Incoterm.Update(incotermId, code, name,true);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Incoterm]
		/// </summary>
		public bool Update() {
            return Rebound.GlobalTrader.DAL.SiteProvider.Incoterm.Update(IncotermId, Code, Name, Active);
		}
        //[001] code end
        private static Incoterm PopulateFromDBDetailsObject(IncotermDetails obj) {
            Incoterm objNew = new Incoterm();
			objNew.IncotermId = obj.IncotermId;
			objNew.Code = obj.Code;
			objNew.Name = obj.Name;
            return objNew;
        }
		
		#endregion
		
	}
}