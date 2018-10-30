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
    public partial class Certificate : BizObject
    {
		
		#region Properties

        protected static DAL.CertificateElement Settings
        {
            get { return Globals.Settings.Certificates; }
		}

		/// <summary>
        /// CertificateId
		/// </summary>
        public System.Int32 CertificateId { get; set; }		
		/// <summary>
        /// CertificateName
		/// </summary>
        public System.String CertificateName { get; set; }		
		/// <summary>
        /// Description
		/// </summary>
        public System.String Description { get; set; }	
	    /// <summary>
	    /// CertificateCategoryNo
	    /// </summary>
        public System.Int32? CertificateCategoryNo { get; set; }
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
        /// <summary>
        /// CompanyCertificateId
        /// </summary>
        public System.Int32 CompanyCertificateId { get; set; }
        /// <summary>
        /// StartDate
        /// </summary>
        public System.DateTime? StartDate { get; set; }
        /// <summary>
        /// ExpiryDate
        /// </summary>
        public System.DateTime? ExpiryDate { get; set; }
        /// <summary>
        /// CertificateCategoryName
        /// </summary>
        public System.String CertificateCategoryName { get; set; }
        /// <summary>
        /// CertificateNumber
        /// </summary>
        public System.String CertificateNumber { get; set; }
		
     
		#endregion
		
		#region Methods

        /// <summary>
        /// Insert
        /// Calls [usp_insert_Certificate]
        /// </summary>
        public static Int32 Insert(System.String certificateName, System.String description, System.Int32? certificateCategoryNo, System.Boolean? inactive, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Certificate.Insert(certificateName, description,certificateCategoryNo, inactive, updatedBy);
            return objReturn;
        }

        /// <summary>
        /// Insert
        /// Calls [usp_insert_CompanyCertificate]
        /// </summary>
        public static Int32 InsertCompanyCertificate(System.Int32? clientNo, System.Int32? companyNo, System.Int32? certificateCategoryNo,System.Int32? CertificateNo,System.String description,System.DateTime? startDate,System.DateTime? expiryDate, System.Boolean? inactive, System.Int32? updatedBy,System.String certificateNumber)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Certificate.InsertCompanyCertificate(clientNo, companyNo, certificateCategoryNo, CertificateNo, description, startDate, expiryDate, inactive, updatedBy, certificateNumber);
            return objReturn;
        }
        /// <summary>
        /// Update
        /// Calls [usp_update_CompanyCertificate]
        /// </summary>
        public static bool UpdateCompanyCertificate(System.Int32? companyCertificateId, System.Int32? certificateCategoryNo, System.Int32? CertificateNo, System.String description, System.DateTime? startDate, System.DateTime? expiryDate, System.Boolean? inactive, System.Int32? updatedBy, System.String certificateNumber)
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.Certificate.UpdateCompanyCertificate(companyCertificateId, certificateCategoryNo, CertificateNo, description, startDate, expiryDate, inactive, updatedBy, certificateNumber);
        }
        /// <summary>
        /// Calls [usp_Get_All_CertificateByCategory]
        /// </summary>
        /// <returns></returns>
        public static List<Certificate> GetListCertificate(System.Int32? certificateCategoryNo)
        {
            List<CertificateDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Certificate.GetListCertificate(certificateCategoryNo);
			if (lstDetails == null) {
                return new List<Certificate>();
			} else {
                List<Certificate> lst = new List<Certificate>();
                foreach (CertificateDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Certificate obj = new Rebound.GlobalTrader.BLL.Certificate();
                    obj.CertificateId = objDetails.CertificateId;
                    obj.CertificateName = objDetails.CertificateName;
                    obj.Description = objDetails.Description;
                    obj.CertificateCategoryNo = objDetails.CertificateCategoryNo;
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
        /// Calls [usp_dropdown_CertificateByCategory]
        /// </summary>
        /// <returns></returns>
        public static List<Certificate> DropDownListCertificate(System.Int32? certificateCategoryNo)
        {
            List<CertificateDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Certificate.DropDownListCertificate(certificateCategoryNo);
            if (lstDetails == null)
            {
                return new List<Certificate>();
            }
            else
            {
                List<Certificate> lst = new List<Certificate>();
                foreach (CertificateDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Certificate obj = new Rebound.GlobalTrader.BLL.Certificate();
                    obj.CertificateId = objDetails.CertificateId;
                    obj.CertificateName = objDetails.CertificateName;
                    obj.Description = objDetails.Description;
                    obj.CertificateCategoryNo = objDetails.CertificateCategoryNo;
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
		/// Calls [usp_select_Certificate]
		/// </summary>
        public static Certificate Get(System.Int32? certificateId)
        {
            Rebound.GlobalTrader.DAL.CertificateDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Certificate.Get(certificateId);
			if (objDetails == null) {
				return null;
			} else {
                Certificate obj = new Certificate();
                obj.CertificateId = objDetails.CertificateId;
                obj.CertificateName = objDetails.CertificateName;
                obj.Description = objDetails.Description;
                obj.CertificateCategoryNo = objDetails.CertificateCategoryNo;
                obj.Inactive = objDetails.Inactive;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Certificate]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Certificate.Update(CertificateId, CertificateName, Description,CertificateCategoryNo, Inactive, UpdatedBy);
		}

        /// <summary>
        /// Calls [usp_Get_CertificateByCompany]
        /// </summary>
        /// <returns></returns>
        public static List<Certificate> GetCertificateByCompany(System.Int32? companyNo)
        {
            List<CertificateDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Certificate.GetCertificateByCompany(companyNo);
            if (lstDetails == null)
            {
                return new List<Certificate>();
            }
            else
            {
                List<Certificate> lst = new List<Certificate>();
                foreach (CertificateDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Certificate obj = new Rebound.GlobalTrader.BLL.Certificate();
                    obj.CertificateId = objDetails.CertificateId;
                    obj.CompanyCertificateId = objDetails.CompanyCertificateId;
                    obj.CertificateCategoryNo = objDetails.CertificateCategoryNo;
                    obj.CertificateName = objDetails.CertificateName;
                    obj.Description = objDetails.Description;
                    obj.StartDate = objDetails.StartDate;
                    obj.ExpiryDate = objDetails.ExpiryDate;
                    obj.Inactive = objDetails.Inactive;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.CertificateNumber = objDetails.CertificateNumber;
                    obj.CertificateCategoryName = objDetails.CertificateCategoryName;
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