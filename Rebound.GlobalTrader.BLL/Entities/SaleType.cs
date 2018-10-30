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
		public partial class SaleType : BizObject {
		
		#region Properties

		protected static DAL.SaleTypeElement Settings {
			get { return Globals.Settings.SaleTypes; }
		}

		/// <summary>
		/// SaleTypeId
		/// </summary>
		public System.Int32 SaleTypeId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_SaleType]
		/// </summary>
		public static bool Delete(System.Int32? saleTypeId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.SaleType.Delete(saleTypeId);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_SaleType]
		/// </summary>
		public static Int32 Insert(System.String name) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SaleType.Insert(name);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_SaleType]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.SaleType.Insert(Name);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_SaleType]
		/// </summary>
		public static SaleType Get(System.Int32? saleTypeId) {
			Rebound.GlobalTrader.DAL.SaleTypeDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SaleType.Get(saleTypeId);
			if (objDetails == null) {
				return null;
			} else {
				SaleType obj = new SaleType();
				obj.SaleTypeId = objDetails.SaleTypeId;
				obj.Name = objDetails.Name;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_SaleType]
		/// </summary>
		public static List<SaleType> GetList() {
			List<SaleTypeDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SaleType.GetList();
			if (lstDetails == null) {
				return new List<SaleType>();
			} else {
				List<SaleType> lst = new List<SaleType>();
				foreach (SaleTypeDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SaleType obj = new Rebound.GlobalTrader.BLL.SaleType();
					obj.SaleTypeId = objDetails.SaleTypeId;
					obj.Name = objDetails.Name;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_SaleType]
		/// </summary>
		public static bool Update(System.String name, System.Int32? saleTypeId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.SaleType.Update(name, saleTypeId);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_SaleType]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.SaleType.Update(Name, SaleTypeId);
		}

        private static SaleType PopulateFromDBDetailsObject(SaleTypeDetails obj) {
            SaleType objNew = new SaleType();
			objNew.SaleTypeId = obj.SaleTypeId;
			objNew.Name = obj.Name;
            return objNew;
        }
		
		#endregion
		
	}
}