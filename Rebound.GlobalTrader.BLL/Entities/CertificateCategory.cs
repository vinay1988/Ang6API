
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
    public partial class CertificateCategory : BizObject
    {
		
		#region Properties

        protected static DAL.CertificateCategoryElement Settings
        {
            get { return Globals.Settings.CertificateCategorys; }
		}

		/// <summary>
        /// CertificateCategoryId
		/// </summary>
        public System.Int32 CertificateCategoryId { get; set; }		
		/// <summary>
        /// CertificateCategoryName
		/// </summary>
        public System.String CertificateCategoryName { get; set; }		
		/// <summary>
        /// Description
		/// </summary>
        public System.String Description { get; set; }		
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
        /// Insert
        /// Calls [usp_insert_CertificateCategory]
        /// </summary>
        public static Int32 Insert(System.String certificateCategoryName, System.String description, System.Boolean? inactive, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CertificateCategory.Insert(certificateCategoryName, description, inactive, updatedBy);
            return objReturn;
        }

        /// <summary>
        /// Calls [usp_Get_All_CertificateCategory]
        /// </summary>
        /// <returns></returns>
        public static List<CertificateCategory> GetListCertificateCategory()
        {
            List<CertificateCategoryDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CertificateCategory.GetListCertificateCategory();
			if (lstDetails == null) {
                return new List<CertificateCategory>();
			} else {
                List<CertificateCategory> lst = new List<CertificateCategory>();
                foreach (CertificateCategoryDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.CertificateCategory obj = new Rebound.GlobalTrader.BLL.CertificateCategory();
                    obj.CertificateCategoryId = objDetails.CertificateCategoryId;
                    obj.CertificateCategoryName = objDetails.CertificateCategoryName;
                    obj.Description = objDetails.Description;
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
		/// Get
		/// Calls [usp_select_CertificateCategory]
		/// </summary>
        public static CertificateCategory Get(System.Int32? categoryId)
        {
            Rebound.GlobalTrader.DAL.CertificateCategoryDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CertificateCategory.Get(categoryId);
			if (objDetails == null) {
				return null;
			} else {
                CertificateCategory obj = new CertificateCategory();
                obj.CertificateCategoryId = objDetails.CertificateCategoryId;
                obj.CertificateCategoryName = objDetails.CertificateCategoryName;
                obj.Description = objDetails.Description;
                obj.Inactive = objDetails.Inactive;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_CertificateCategory]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.CertificateCategory.Update(CertificateCategoryId, CertificateCategoryName, Description,Inactive, UpdatedBy);
		}

        /// <summary>
        /// Calls [usp_dropdown_CertificateCategory]
        /// </summary>
        /// <returns></returns>
        public static List<CertificateCategory> GetDropDownCertificateCategory()
        {
            List<CertificateCategoryDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CertificateCategory.GetDropDownCertificateCategory();
            if (lstDetails == null)
            {
                return new List<CertificateCategory>();
            }
            else
            {
                List<CertificateCategory> lst = new List<CertificateCategory>();
                foreach (CertificateCategoryDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.CertificateCategory obj = new Rebound.GlobalTrader.BLL.CertificateCategory();
                    obj.CertificateCategoryId = objDetails.CertificateCategoryId;
                    obj.CertificateCategoryName = objDetails.CertificateCategoryName;
                    obj.Description = objDetails.Description;
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

		#endregion
		
	}
}