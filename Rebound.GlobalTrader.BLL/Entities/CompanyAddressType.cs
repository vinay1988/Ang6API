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
		public partial class CompanyAddressType : BizObject {
		
		#region Properties

		protected static DAL.CompanyAddressTypeElement Settings {
			get { return Globals.Settings.CompanyAddressTypes; }
		}

		/// <summary>
		/// CompanyAddressTypeId
		/// </summary>
		public System.Int32 CompanyAddressTypeId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_CompanyAddressType]
		/// </summary>
		public static bool Delete(System.Int32? companyAddressTypeId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CompanyAddressType.Delete(companyAddressTypeId);
		}
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_CompanyAddressType]
		/// </summary>
		public static List<CompanyAddressType> DropDown() {
			List<CompanyAddressTypeDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CompanyAddressType.DropDown();
			if (lstDetails == null) {
				return new List<CompanyAddressType>();
			} else {
				List<CompanyAddressType> lst = new List<CompanyAddressType>();
				foreach (CompanyAddressTypeDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CompanyAddressType obj = new Rebound.GlobalTrader.BLL.CompanyAddressType();
					obj.CompanyAddressTypeId = objDetails.CompanyAddressTypeId;
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
		/// Calls [usp_insert_CompanyAddressType]
		/// </summary>
		public static Int32 Insert(System.String name) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CompanyAddressType.Insert(name);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_CompanyAddressType]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.CompanyAddressType.Insert(Name);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_CompanyAddressType]
		/// </summary>
		public static CompanyAddressType Get(System.Int32? companyAddressTypeId) {
			Rebound.GlobalTrader.DAL.CompanyAddressTypeDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CompanyAddressType.Get(companyAddressTypeId);
			if (objDetails == null) {
				return null;
			} else {
				CompanyAddressType obj = new CompanyAddressType();
				obj.CompanyAddressTypeId = objDetails.CompanyAddressTypeId;
				obj.Name = objDetails.Name;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_CompanyAddressType]
		/// </summary>
		public static List<CompanyAddressType> GetList() {
			List<CompanyAddressTypeDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CompanyAddressType.GetList();
			if (lstDetails == null) {
				return new List<CompanyAddressType>();
			} else {
				List<CompanyAddressType> lst = new List<CompanyAddressType>();
				foreach (CompanyAddressTypeDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CompanyAddressType obj = new Rebound.GlobalTrader.BLL.CompanyAddressType();
					obj.CompanyAddressTypeId = objDetails.CompanyAddressTypeId;
					obj.Name = objDetails.Name;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}

        private static CompanyAddressType PopulateFromDBDetailsObject(CompanyAddressTypeDetails obj) {
            CompanyAddressType objNew = new CompanyAddressType();
			objNew.CompanyAddressTypeId = obj.CompanyAddressTypeId;
			objNew.Name = obj.Name;
            return objNew;
        }
		
		#endregion
		
	}
}