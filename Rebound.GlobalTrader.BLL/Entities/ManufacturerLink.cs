/* Marker    changed by      date           Remarks
  [001]      Vinay           11/08/2014     ESMS  Ticket Number: 	200
 */
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
		public partial class ManufacturerLink : BizObject {
		
		#region Properties

		protected static DAL.ManufacturerLinkElement Settings {
			get { return Globals.Settings.ManufacturerLinks; }
		}

		/// <summary>
		/// ManufacturerLinkId
		/// </summary>
		public System.Int32 ManufacturerLinkId { get; set; }		
		/// <summary>
		/// ManufacturerNo
		/// </summary>
		public System.Int32 ManufacturerNo { get; set; }		
		/// <summary>
		/// SupplierCompanyNo
		/// </summary>
		public System.Int32 SupplierCompanyNo { get; set; }		
		/// <summary>
		/// ManufacturerRating
		/// </summary>
		public System.Int32? ManufacturerRating { get; set; }		
		/// <summary>
		/// SupplierRating
		/// </summary>
		public System.Int32? SupplierRating { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// ManufacturerName
		/// </summary>
		public System.String ManufacturerName { get; set; }		
		/// <summary>
		/// SupplierName
		/// </summary>
		public System.String SupplierName { get; set; }
        //[001] code start
        /// <summary>
        /// CompanyType
        /// </summary>
        public System.String CompanyType { get; set; }
        //[001] code end

		#endregion
		
		#region Methods
		
		/// <summary>
		/// CountForManufacturerAndSupplier
		/// Calls [usp_count_ManufacturerLink_for_Manufacturer_and_Supplier]
		/// </summary>
		public static Int32 CountForManufacturerAndSupplier(System.Int32? manufacturerNo, System.Int32? supplierCompanyNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.ManufacturerLink.CountForManufacturerAndSupplier(manufacturerNo, supplierCompanyNo);
		}		/// <summary>
		/// Delete
		/// Calls [usp_delete_ManufacturerLink]
		/// </summary>
		public static bool Delete(System.Int32? manufacturerLinkId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.ManufacturerLink.Delete(manufacturerLinkId);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_ManufacturerLink]
		/// </summary>
		public static Int32 Insert(System.Int32? manufacturerNo, System.Int32? supplierCompanyNo, System.Int32? manufacturerRating, System.Int32? supplierRating, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.ManufacturerLink.Insert(manufacturerNo, supplierCompanyNo, manufacturerRating, supplierRating, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_ManufacturerLink]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.ManufacturerLink.Insert(ManufacturerNo, SupplierCompanyNo, ManufacturerRating, SupplierRating, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_ManufacturerLink]
		/// </summary>
		public static ManufacturerLink Get(System.Int32? manufacturerLinkId) {
			Rebound.GlobalTrader.DAL.ManufacturerLinkDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.ManufacturerLink.Get(manufacturerLinkId);
			if (objDetails == null) {
				return null;
			} else {
				ManufacturerLink obj = new ManufacturerLink();
				obj.ManufacturerLinkId = objDetails.ManufacturerLinkId;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.SupplierCompanyNo = objDetails.SupplierCompanyNo;
				obj.SupplierName = objDetails.SupplierName;
				obj.ManufacturerRating = objDetails.ManufacturerRating;
				obj.SupplierRating = objDetails.SupplierRating;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForManufacturerAndSupplier
		/// Calls [usp_select_ManufacturerLink_for_Manufacturer_and_Supplier]
		/// </summary>
		public static ManufacturerLink GetForManufacturerAndSupplier(System.Int32? manufacturerNo, System.Int32? supplierCompanyNo) {
			Rebound.GlobalTrader.DAL.ManufacturerLinkDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.ManufacturerLink.GetForManufacturerAndSupplier(manufacturerNo, supplierCompanyNo);
			if (objDetails == null) {
				return null;
			} else {
				ManufacturerLink obj = new ManufacturerLink();
				obj.ManufacturerLinkId = objDetails.ManufacturerLinkId;
				obj.ManufacturerNo = objDetails.ManufacturerNo;
				obj.ManufacturerName = objDetails.ManufacturerName;
				obj.SupplierCompanyNo = objDetails.SupplierCompanyNo;
				obj.SupplierName = objDetails.SupplierName;
				obj.ManufacturerRating = objDetails.ManufacturerRating;
				obj.SupplierRating = objDetails.SupplierRating;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForManufacturer
		/// Calls [usp_selectAll_ManufacturerLink_for_Manufacturer]
		/// </summary>
		public static List<ManufacturerLink> GetListForManufacturer(System.Int32? manufacturerId, System.Int32? clientId) {
			List<ManufacturerLinkDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ManufacturerLink.GetListForManufacturer(manufacturerId, clientId);
			if (lstDetails == null) {
				return new List<ManufacturerLink>();
			} else {
				List<ManufacturerLink> lst = new List<ManufacturerLink>();
				foreach (ManufacturerLinkDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.ManufacturerLink obj = new Rebound.GlobalTrader.BLL.ManufacturerLink();
					obj.ManufacturerLinkId = objDetails.ManufacturerLinkId;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.SupplierCompanyNo = objDetails.SupplierCompanyNo;
					obj.SupplierName = objDetails.SupplierName;
					obj.ManufacturerRating = objDetails.ManufacturerRating;
					obj.SupplierRating = objDetails.SupplierRating;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
                    //[001] code start
                    obj.CompanyType = objDetails.CompanyType;
                    //[001] code end
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForSupplier
		/// Calls [usp_selectAll_ManufacturerLink_for_Supplier]
		/// </summary>
		public static List<ManufacturerLink> GetListForSupplier(System.Int32? supplierCompanyNo) {
			List<ManufacturerLinkDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.ManufacturerLink.GetListForSupplier(supplierCompanyNo);
			if (lstDetails == null) {
				return new List<ManufacturerLink>();
			} else {
				List<ManufacturerLink> lst = new List<ManufacturerLink>();
				foreach (ManufacturerLinkDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.ManufacturerLink obj = new Rebound.GlobalTrader.BLL.ManufacturerLink();
					obj.ManufacturerLinkId = objDetails.ManufacturerLinkId;
					obj.ManufacturerNo = objDetails.ManufacturerNo;
					obj.ManufacturerName = objDetails.ManufacturerName;
					obj.SupplierCompanyNo = objDetails.SupplierCompanyNo;
					obj.SupplierName = objDetails.SupplierName;
					obj.ManufacturerRating = objDetails.ManufacturerRating;
					obj.SupplierRating = objDetails.SupplierRating;
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
		/// Calls [usp_update_ManufacturerLink]
		/// </summary>
		public static bool Update(System.Int32? manufacturerLinkId, System.Int32? manufacturerNo, System.Int32? supplierCompanyNo, System.Int32? manufacturerRating, System.Int32? supplierRating, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.ManufacturerLink.Update(manufacturerLinkId, manufacturerNo, supplierCompanyNo, manufacturerRating, supplierRating, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_ManufacturerLink]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.ManufacturerLink.Update(ManufacturerLinkId, ManufacturerNo, SupplierCompanyNo, ManufacturerRating, SupplierRating, UpdatedBy);
		}
		/// <summary>
		/// UpdateByManufacturerAndSupplier
		/// Calls [usp_update_ManufacturerLink_by_Manufacturer_and_Supplier]
		/// </summary>
		public static bool UpdateByManufacturerAndSupplier(System.Int32? manufacturerNo, System.Int32? supplierCompanyNo, System.Int32? manufacturerRating, System.Int32? supplierRating, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.ManufacturerLink.UpdateByManufacturerAndSupplier(manufacturerNo, supplierCompanyNo, manufacturerRating, supplierRating, updatedBy);
		}

        private static ManufacturerLink PopulateFromDBDetailsObject(ManufacturerLinkDetails obj) {
            ManufacturerLink objNew = new ManufacturerLink();
			objNew.ManufacturerLinkId = obj.ManufacturerLinkId;
			objNew.ManufacturerNo = obj.ManufacturerNo;
			objNew.SupplierCompanyNo = obj.SupplierCompanyNo;
			objNew.ManufacturerRating = obj.ManufacturerRating;
			objNew.SupplierRating = obj.SupplierRating;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.ManufacturerName = obj.ManufacturerName;
			objNew.SupplierName = obj.SupplierName;
            return objNew;
        }
		
		#endregion
		
	}
}