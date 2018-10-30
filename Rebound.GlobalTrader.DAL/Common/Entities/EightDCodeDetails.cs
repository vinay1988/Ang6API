using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Rebound.GlobalTrader.DAL
{
    public class EightDCodeDetails
    {
        #region Constructors

        public EightDCodeDetails() { }

        #endregion

        #region Properties

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
    }
}
