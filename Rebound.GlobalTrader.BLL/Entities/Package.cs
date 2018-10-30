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
		public partial class Package : BizObject {
		
		#region Properties

		protected static DAL.PackageElement Settings {
			get { return Globals.Settings.Packages; }
		}

		/// <summary>
		/// PackageId
		/// </summary>
		public System.Int32 PackageId { get; set; }		
		/// <summary>
		/// PackageName
		/// </summary>
		public System.String PackageName { get; set; }		
		/// <summary>
		/// PackageDescription
		/// </summary>
		public System.String PackageDescription { get; set; }		
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

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Package]
		/// </summary>
		public static bool Delete(System.Int32? packageId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Package.Delete(packageId);
		}
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_Package]
		/// </summary>
		public static List<Package> DropDown() {
			List<PackageDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Package.DropDown();
			if (lstDetails == null) {
				return new List<Package>();
			} else {
				List<Package> lst = new List<Package>();
				foreach (PackageDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Package obj = new Rebound.GlobalTrader.BLL.Package();
					obj.PackageId = objDetails.PackageId;
					obj.PackageDescription = objDetails.PackageDescription;
					obj.PackageName = objDetails.PackageName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Package]
		/// </summary>
		public static Int32 Insert(System.String packageName, System.String packageDescription, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Package.Insert(packageName, packageDescription, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Package]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Package.Insert(PackageName, PackageDescription, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_Package]
		/// </summary>
		public static Package Get(System.Int32? packageId) {
			Rebound.GlobalTrader.DAL.PackageDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Package.Get(packageId);
			if (objDetails == null) {
				return null;
			} else {
				Package obj = new Package();
				obj.PackageId = objDetails.PackageId;
				obj.PackageName = objDetails.PackageName;
				obj.PackageDescription = objDetails.PackageDescription;
				obj.Inactive = objDetails.Inactive;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_Package]
		/// </summary>
		public static List<Package> GetList() {
			List<PackageDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Package.GetList();
			if (lstDetails == null) {
				return new List<Package>();
			} else {
				List<Package> lst = new List<Package>();
				foreach (PackageDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Package obj = new Rebound.GlobalTrader.BLL.Package();
					obj.PackageId = objDetails.PackageId;
					obj.PackageName = objDetails.PackageName;
					obj.PackageDescription = objDetails.PackageDescription;
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
		/// Calls [usp_update_Package]
		/// </summary>
		public static bool Update(System.Int32? packageId, System.String packageName, System.String packageDescription, System.Boolean? inactive, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Package.Update(packageId, packageName, packageDescription, inactive, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Package]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Package.Update(PackageId, PackageName, PackageDescription, Inactive, UpdatedBy);
		}

        private static Package PopulateFromDBDetailsObject(PackageDetails obj) {
            Package objNew = new Package();
			objNew.PackageId = obj.PackageId;
			objNew.PackageName = obj.PackageName;
			objNew.PackageDescription = obj.PackageDescription;
			objNew.Inactive = obj.Inactive;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
            return objNew;
        }
		
		#endregion
		
	}
}