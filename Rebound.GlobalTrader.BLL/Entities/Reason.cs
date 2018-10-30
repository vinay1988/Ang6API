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
		public partial class Reason : BizObject {
		
		#region Properties

		protected static DAL.ReasonElement Settings {
			get { return Globals.Settings.Reasons; }
		}

		/// <summary>
		/// ReasonId
		/// </summary>
		public System.Int32 ReasonId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		
		/// <summary>
		/// Locked
		/// </summary>
		public System.Boolean Locked { get; set; }		
		/// <summary>
		/// Sold
		/// </summary>
		public System.Boolean Sold { get; set; }		
		/// <summary>
		/// NotQuoted
		/// </summary>
		public System.Boolean NotQuoted { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Reason]
		/// </summary>
		public static bool Delete(System.Int32? reasonId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Reason.Delete(reasonId);
		}
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_Reason]
		/// </summary>
		public static List<Reason> DropDown() {
			List<ReasonDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Reason.DropDown();
			if (lstDetails == null) {
				return new List<Reason>();
			} else {
				List<Reason> lst = new List<Reason>();
				foreach (ReasonDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Reason obj = new Rebound.GlobalTrader.BLL.Reason();
					obj.ReasonId = objDetails.ReasonId;
					obj.Name = objDetails.Name;
					obj.NotQuoted = objDetails.NotQuoted;
					obj.Sold = objDetails.Sold;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Reason]
		/// </summary>
		public static Int32 Insert(System.String name) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Reason.Insert(name);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Reason]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Reason.Insert(Name);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_Reason]
		/// </summary>
		public static Reason Get(System.Int32? reasonId) {
			Rebound.GlobalTrader.DAL.ReasonDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Reason.Get(reasonId);
			if (objDetails == null) {
				return null;
			} else {
				Reason obj = new Reason();
				obj.ReasonId = objDetails.ReasonId;
				obj.Name = objDetails.Name;
				obj.Locked = objDetails.Locked;
				obj.Sold = objDetails.Sold;
				obj.NotQuoted = objDetails.NotQuoted;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_Reason]
		/// </summary>
		public static List<Reason> GetList() {
			List<ReasonDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Reason.GetList();
			if (lstDetails == null) {
				return new List<Reason>();
			} else {
				List<Reason> lst = new List<Reason>();
				foreach (ReasonDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Reason obj = new Rebound.GlobalTrader.BLL.Reason();
					obj.ReasonId = objDetails.ReasonId;
					obj.Name = objDetails.Name;
					obj.Locked = objDetails.Locked;
					obj.Sold = objDetails.Sold;
					obj.NotQuoted = objDetails.NotQuoted;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_Reason]
		/// </summary>
		public static bool Update(System.String name, System.Int32? reasonId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Reason.Update(name, reasonId);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Reason]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Reason.Update(Name, ReasonId);
		}

        /// <summary>
        /// DropDown
        /// Calls [usp_dropdown_StatusReason]
        /// </summary>
        public static List<Reason> DropDown(System.String strSection)
        {
            List<ReasonDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Reason.DropDown(strSection);
            if (lstDetails == null)
            {
                return new List<Reason>();
            }
            else
            {
                List<Reason> lst = new List<Reason>();
                foreach (ReasonDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Reason obj = new Rebound.GlobalTrader.BLL.Reason();
                    obj.ReasonId = objDetails.ReasonId;
                    obj.Name = objDetails.Name;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        private static Reason PopulateFromDBDetailsObject(ReasonDetails obj) {
            Reason objNew = new Reason();
			objNew.ReasonId = obj.ReasonId;
			objNew.Name = obj.Name;
			objNew.Locked = obj.Locked;
			objNew.Sold = obj.Sold;
			objNew.NotQuoted = obj.NotQuoted;
            return objNew;
        }


		
		#endregion
		
	}
}