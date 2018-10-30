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

    public abstract class CertificateCategoryProvider : DataAccess
    {
        static private CertificateCategoryProvider _instance = null;
        /// <summary>
        /// Returns an instance of the provider type specified in the config file
        /// </summary>       
        static public CertificateCategoryProvider Instance
        {
            get
            {
                if (_instance == null) _instance = (CertificateCategoryProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.CertificateCategorys.ProviderType));
                return _instance;
            }
        }
        public CertificateCategoryProvider()
        {
            this.ConnectionString = Globals.Settings.CertificateCategorys.ConnectionString;
        }

        #region Method Registrations
        /// <summary>
        /// Insert
        /// Calls [usp_insert_CertificateCategory]
        /// </summary>
        public abstract Int32 Insert(System.String certificateCategoryName, System.String description, System.Boolean? inactive, System.Int32? updatedBy);
        /// <summary>
        /// Get
        /// Calls [usp_select_CertificateCategory]
        /// </summary>
        public abstract CertificateCategoryDetails Get(System.Int32? categoryId);
        /// <summary>
        /// Calls [usp_update_CertificateCategory]
        /// </summary>
        public abstract bool Update(System.Int32? categoryId, System.String certificateCategoryName, System.String description, System.Boolean? inactive, System.Int32? updatedBy);
        /// <summary>
        /// Calls [usp_Get_All_CertificateCategory]
        /// </summary>
        /// <returns></returns>
        public abstract List<CertificateCategoryDetails> GetListCertificateCategory();

        /// <summary>
        /// Calls [usp_dropdown_CertificateCategory]
        /// </summary>
        /// <returns></returns>
        public abstract List<CertificateCategoryDetails> GetDropDownCertificateCategory();


        #endregion
    }
}

