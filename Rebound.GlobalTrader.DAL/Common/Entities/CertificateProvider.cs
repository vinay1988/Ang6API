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
using System.Data.Common;

namespace Rebound.GlobalTrader.DAL
{

    public abstract class CertificateProvider : DataAccess
    {
        static private CertificateProvider _instance = null;
        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>       
        static public CertificateProvider Instance
        {
            get
            {
                if (_instance == null) _instance = (CertificateProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Certificates.ProviderType));
                return _instance;
            }
        }
        public CertificateProvider()
        {
            this.ConnectionString = Globals.Settings.Certificates.ConnectionString;
        }

        #region Method Registrations
        /// <summary>
        /// Insert
        /// Calls [usp_insert_Certificate]
        /// </summary>
        public abstract Int32 Insert(System.String certificateName, System.String description, System.Int32? certificateCategoryNo, System.Boolean? inactive, System.Int32? updatedBy);
        /// <summary>
        /// Get
        /// Calls [usp_select_Certificate]
        /// </summary>
        public abstract CertificateDetails Get(System.Int32? certificateId);
        /// <summary>
        /// Calls [usp_update_Certificate]
        /// </summary>
        public abstract bool Update(System.Int32? certificateId, System.String certificateName, System.String description,System.Int32? CertificateCategoryNo, System.Boolean? inactive, System.Int32? updatedBy);
        /// <summary>
        /// Calls [usp_Get_All_CertificateByCategory]
        /// </summary>
        /// <returns></returns>
        public abstract List<CertificateDetails> GetListCertificate(System.Int32? certificateCategoryNo);

        /// <summary>
        /// Calls [usp_dropdown_CertificateByCategory]
        /// </summary>
        /// <returns></returns>
        public abstract List<CertificateDetails> DropDownListCertificate(System.Int32? certificateCategoryNo);

        /// <summary>
        /// Calls [usp_Get_CertificateByCompany]
        /// </summary>
        /// <returns></returns>
        public abstract List<CertificateDetails> GetCertificateByCompany(System.Int32? companyNo);
        /// <summary>
        /// Insert
        /// Calls [usp_insert_CompanyCertificate]
        /// </summary>
        public abstract Int32 InsertCompanyCertificate(System.Int32? clientNo, System.Int32? companyNo, System.Int32? certificateCategoryNo, System.Int32? CertificateNo, System.String description, System.DateTime? startDate, System.DateTime? expiryDate, System.Boolean? inactive, System.Int32? updatedBy, System.String certificateNumber);
        /// <summary>
        /// Update
        /// Calls [usp_update_CompanyCertificate]
        /// </summary>
        public abstract bool UpdateCompanyCertificate(System.Int32? companyCertificateId, System.Int32? certificateCategoryNo, System.Int32? CertificateNo, System.String description, System.DateTime? startDate, System.DateTime? expiryDate, System.Boolean? inactive, System.Int32? updatedBy, System.String certificateNumber);

        #endregion
    }
}

