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
		public partial class IndustryType : BizObject {
		
		#region Properties

		protected static DAL.IndustryTypeElement Settings {
			get { return Globals.Settings.IndustryTypes; }
		}

		/// <summary>
		/// IndustryTypeId
		/// </summary>
		public System.Int32 IndustryTypeId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		
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
		public System.DateTime? DLUP { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_IndustryType]
		/// </summary>
		public static bool Delete(System.Int32? industryTypeId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.IndustryType.Delete(industryTypeId);
		}
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_IndustryType]
		/// </summary>
		public static List<IndustryType> DropDown() {
			List<IndustryTypeDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.IndustryType.DropDown();
			if (lstDetails == null) {
				return new List<IndustryType>();
			} else {
				List<IndustryType> lst = new List<IndustryType>();
				foreach (IndustryTypeDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.IndustryType obj = new Rebound.GlobalTrader.BLL.IndustryType();
					obj.IndustryTypeId = objDetails.IndustryTypeId;
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
		/// Calls [usp_insert_IndustryType]
		/// </summary>
		public static Int32 Insert(System.String name) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.IndustryType.Insert(name);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_IndustryType]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.IndustryType.Insert(Name);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_IndustryType]
		/// </summary>
		public static IndustryType Get(System.Int32? industryTypeId) {
			Rebound.GlobalTrader.DAL.IndustryTypeDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.IndustryType.Get(industryTypeId);
			if (objDetails == null) {
				return null;
			} else {
				IndustryType obj = new IndustryType();
				obj.IndustryTypeId = objDetails.IndustryTypeId;
				obj.Name = objDetails.Name;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_IndustryType]
		/// </summary>
		public static List<IndustryType> GetList() {
			List<IndustryTypeDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.IndustryType.GetList();
			if (lstDetails == null) {
				return new List<IndustryType>();
			} else {
				List<IndustryType> lst = new List<IndustryType>();
				foreach (IndustryTypeDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.IndustryType obj = new Rebound.GlobalTrader.BLL.IndustryType();
					obj.IndustryTypeId = objDetails.IndustryTypeId;
					obj.Name = objDetails.Name;
					obj.Inactive = objDetails.Inactive;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_IndustryType]
		/// </summary>
		public static bool Update(System.String name, System.Int32? industryTypeId, System.Boolean? inactive, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.IndustryType.Update(name, industryTypeId, inactive, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_IndustryType]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.IndustryType.Update(Name, IndustryTypeId, Inactive, UpdatedBy);
		}

        private static IndustryType PopulateFromDBDetailsObject(IndustryTypeDetails obj) {
            IndustryType objNew = new IndustryType();
			objNew.IndustryTypeId = obj.IndustryTypeId;
			objNew.Name = obj.Name;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
            return objNew;
        }
		
		#endregion
		
	}
}