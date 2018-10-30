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
		public partial class ProductType : BizObject {
		
		#region Properties

		protected static DAL.ProductTypeElement Settings {
			get { return Globals.Settings.ProductTypes; }
		}

		/// <summary>
		/// ProductTypeId
		/// </summary>
		public System.Int32 ProductTypeId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Insert
		/// Calls [usp_insert_ProductType]
		/// </summary>
		public static Int32 Insert(System.String name) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.ProductType.Insert(name);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_ProductType]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.ProductType.Insert(Name);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_ProductType]
		/// </summary>
		public static ProductType Get(System.Int32? productTypeId) {
			Rebound.GlobalTrader.DAL.ProductTypeDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.ProductType.Get(productTypeId);
			if (objDetails == null) {
				return null;
			} else {
				ProductType obj = new ProductType();
				obj.ProductTypeId = objDetails.ProductTypeId;
				obj.Name = objDetails.Name;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_ProductType]
		/// </summary>
		public static bool Update(System.String name, System.Int32? productTypeId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.ProductType.Update(name, productTypeId);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_ProductType]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.ProductType.Update(Name, ProductTypeId);
		}

        private static ProductType PopulateFromDBDetailsObject(ProductTypeDetails obj) {
            ProductType objNew = new ProductType();
			objNew.ProductTypeId = obj.ProductTypeId;
			objNew.Name = obj.Name;
            return objNew;
        }
		
		#endregion
		
	}
}