
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

namespace Rebound.GlobalTrader.BLL
{
    public partial class EightDCode : BizObject 
    {
        #region Properties
        protected static DAL.EightDCodeElement Settings
        {
            get { return Globals.Settings.EightDCodes; }
        }

        /// <summary>
        ///  Analysis8DCategoryID
        /// </summary>
        public System.Int32 Analysis8DCategoryID { get; set; }

        /// <summary>
        /// Analysis of 8D Category Prifix
        /// </summary>
        public System.String Prefix { get; set; }

        /// <summary>
        ///  Analysis of 8D Category Description
        /// </summary>
        public System.String PrefixDescription { get; set; }

        /// <summary>
        /// SortedOrder
        /// </summary>
        public System.Int32? SortOrder { get; set; }

        /// <summary>
        /// DLUP
        /// </summary>
        public System.DateTime? DLUP { get; set; }

        /// <summary>
        /// Analysis8DSubCategoryID
        /// </summary>
        public System.Int32 Analysis8DSubCategoryID { get; set; }
        /// <summary>
        /// Code
        /// </summary>
        public System.String Code { get; set; }

        /// <summary>
        /// CodeDescription
        /// </summary>
        public System.String CodeDescription { get; set; }

        /// <summary>
        /// Inactive
        /// </summary>
        public System.Boolean Inactive { get; set; }

        /// <summary>
        /// UpdatedBy
        /// </summary>
        public System.Int32? UpdatedBy { get; set; }

        #endregion

        #region Method
        /// <summary>
        /// GetListCategory
        /// Calls [USP_Select8DSubCat]
        /// </summary>
        public static List<EightDCode> GetListCategory()
        {
            List<EightDCodeDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.EightDCode.GetListOfCategory();
            if (lstDetails == null)
            {
                return new List<EightDCode>();
            }
            else
            {
                List<EightDCode> lst = new List<EightDCode>();
                foreach (EightDCodeDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.EightDCode obj = new Rebound.GlobalTrader.BLL.EightDCode();
                    obj.Prefix = objDetails.Prefix;
                    obj.PrefixDescription = objDetails.PrefixDescription;
                    obj.CodeDescription = objDetails.CodeDescription;
                    obj.Code = objDetails.Code;
                    obj.Analysis8DSubCategoryID = objDetails.Analysis8DSubCategoryID;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }


        /// <summary>
        /// Select All Active Category
        /// USP_Select8DCategory
        /// </summary>
        /// <returns></returns>

         
        public static List<EightDCode> SelectListCategory()
        {
            List<EightDCodeDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.EightDCode.SelectListCategory();
            if (lstDetails == null)
            {
                return new List<EightDCode>();
            }
            else
            {
                List<EightDCode> lst = new List<EightDCode>();
                foreach (EightDCodeDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.EightDCode obj = new Rebound.GlobalTrader.BLL.EightDCode();
                    obj.Prefix = objDetails.Prefix;
                    obj.PrefixDescription = objDetails.PrefixDescription;
                    obj.Analysis8DCategoryID = objDetails.Analysis8DCategoryID;
                    obj.Inactive = objDetails.Inactive;
                    obj.SortOrder = objDetails.SortOrder;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// List of Subcategory based on Caegory Id
        /// </summary>
        /// <param name="prifix"></param>
        /// <returns></returns>
        public static List<EightDCode> GetListSubCategory(System.Int32? Id)
        {
            List<EightDCodeDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.EightDCode.GetListSubCategory(Id);
            if (lstDetails == null)
            {
                return new List<EightDCode>();
            }
            else
            {
                List<EightDCode> lst = new List<EightDCode>();
                foreach (EightDCodeDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.EightDCode obj = new Rebound.GlobalTrader.BLL.EightDCode();                    
                    obj.Code = objDetails.Code;
                    obj.CodeDescription = objDetails.CodeDescription;
                    obj.Analysis8DSubCategoryID = objDetails.Analysis8DSubCategoryID;
                    obj.Inactive = objDetails.Inactive;
                    obj.SortOrder = objDetails.SortOrder;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

        /// <summary>
        /// Insert
        /// Calls [usp_insert_Analysis8DCategory]
        /// </summary>
        public static Int32 Insert(System.String prefix, System.String prefixdescription, System.Boolean? inactive, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.EightDCode.Insert(prefix, prefixdescription, inactive, updatedBy);
            return objReturn;
        }

        public static Int32 Insert(System.Int32 prefixNo, System.String prefix, System.String prefixdescription, System.Boolean? inactive, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.EightDCode.Insert(prefixNo, prefix, prefixdescription, inactive, updatedBy);
            return objReturn;
        }

        /// <summary>
        /// Get
        /// Calls [usp_select_Analysis8DCategory]
        /// </summary>
        public static EightDCode Get(System.Int32? Id)
        {
            Rebound.GlobalTrader.DAL.EightDCodeDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.EightDCode.Get(Id);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                EightDCode obj = new EightDCode();
                obj.Analysis8DCategoryID = objDetails.Analysis8DCategoryID;
                obj.Prefix = objDetails.Prefix;
                obj.PrefixDescription = objDetails.PrefixDescription;
                obj.SortOrder = objDetails.SortOrder;
                obj.Inactive = objDetails.Inactive;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                objDetails = null;
                return obj;
            }
        }

        /// <summary>
        /// Get
        /// Calls [usp_select_Analysis8DSubCategory]
        /// </summary>
        public static EightDCode GetSubCat(System.Int32? Id)
        {
            Rebound.GlobalTrader.DAL.EightDCodeDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.EightDCode.GetSubCat(Id);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                EightDCode obj = new EightDCode();
                obj.Analysis8DSubCategoryID = objDetails.Analysis8DSubCategoryID;
                obj.Code = objDetails.Code;
                obj.CodeDescription = objDetails.CodeDescription;
                obj.Analysis8DCategoryID = objDetails.Analysis8DCategoryID;
                obj.SortOrder = objDetails.SortOrder;
                obj.Inactive = objDetails.Inactive;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                objDetails = null;
                return obj;
            }
        }
        /// <summary>
        /// Update (without parameters)
        /// Calls [usp_update_Analysis8DCategory]
        /// </summary>
        public bool Update()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.EightDCode.Update(Analysis8DCategoryID, Prefix, PrefixDescription, Inactive, UpdatedBy);
        }

        /// <summary>
        /// Update (without parameters)
        /// Calls [usp_update_Analysis8DSubCategory]
        /// </summary>
        public bool UpdateSubCat()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.EightDCode.Update(Analysis8DSubCategoryID,Analysis8DCategoryID,Code, CodeDescription, Inactive, UpdatedBy);
        }

        #endregion
    }
}
