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
		public partial class CompanyType : BizObject {
		
		#region Properties

		protected static DAL.CompanyTypeElement Settings {
			get { return Globals.Settings.CompanyTypes; }
		}

		/// <summary>
		/// CompanyTypeId
		/// </summary>
		public System.Int32 CompanyTypeId { get; set; }		
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
        /// <summary>
        /// Traceability
        /// </summary>
        public System.Boolean? Traceability { get; set; }	

        public System.Boolean? NonPreferredCompany { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Delete
        /// Calls [usp_delete_CompanyType]
        /// </summary>
        public static bool Delete(System.Int32? companyTypeId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CompanyType.Delete(companyTypeId);
		}
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_CompanyType]
		/// </summary>
		public static List<CompanyType> DropDown() {
			List<CompanyTypeDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CompanyType.DropDown();
			if (lstDetails == null) {
				return new List<CompanyType>();
			} else {
				List<CompanyType> lst = new List<CompanyType>();
				foreach (CompanyTypeDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CompanyType obj = new Rebound.GlobalTrader.BLL.CompanyType();
					obj.CompanyTypeId = objDetails.CompanyTypeId;
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
		/// Calls [usp_insert_CompanyType]
		/// </summary>
        public static Int32 Insert(System.String name, System.Boolean? Traceability, System.Boolean? NonPreferredCompany)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CompanyType.Insert(name, Traceability, NonPreferredCompany);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_CompanyType]
		/// </summary>
		public Int32 Insert() {
            return Rebound.GlobalTrader.DAL.SiteProvider.CompanyType.Insert(Name,Traceability, NonPreferredCompany);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_CompanyType]
		/// </summary>
		public static CompanyType Get(System.Int32? companyTypeId) {
			Rebound.GlobalTrader.DAL.CompanyTypeDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CompanyType.Get(companyTypeId);
			if (objDetails == null) {
				return null;
			} else {
				CompanyType obj = new CompanyType();
				obj.CompanyTypeId = objDetails.CompanyTypeId;
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
		/// Calls [usp_selectAll_CompanyType]
		/// </summary>
		public static List<CompanyType> GetList() {
			List<CompanyTypeDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CompanyType.GetList();
			if (lstDetails == null) {
				return new List<CompanyType>();
			} else {
				List<CompanyType> lst = new List<CompanyType>();
				foreach (CompanyTypeDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CompanyType obj = new Rebound.GlobalTrader.BLL.CompanyType();
					obj.CompanyTypeId = objDetails.CompanyTypeId;
					obj.Name = objDetails.Name;
					obj.Inactive = objDetails.Inactive;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
                    obj.Traceability = objDetails.Traceability;
                    obj.NonPreferredCompany = objDetails.NonPreferredCompany;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_CompanyType]
		/// </summary>
        public static bool Update(System.String name, System.Int32? companyTypeId, System.Boolean? inactive, System.Int32? updatedBy, System.Boolean? Traceability, System.Boolean? NonPreferredCompany)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.CompanyType.Update(name, companyTypeId, inactive, updatedBy, Traceability, NonPreferredCompany);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_CompanyType]
		/// </summary>
		public bool Update() {
            return Rebound.GlobalTrader.DAL.SiteProvider.CompanyType.Update(Name, CompanyTypeId, Inactive, UpdatedBy, Traceability, NonPreferredCompany);
		}

        private static CompanyType PopulateFromDBDetailsObject(CompanyTypeDetails obj) {
            CompanyType objNew = new CompanyType();
			objNew.CompanyTypeId = obj.CompanyTypeId;
			objNew.Name = obj.Name;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
            return objNew;
        }
		
		#endregion
		
	}
}