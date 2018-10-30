/*
Marker     Changed by      Date         Remarks
[001]      Vinay           07/05/2012   This need to set maximum pdf document upload
[002]      Vinay           26/07/2013   Add checkbox saying Automatically exported for supplier invoice under Setup->Company Setting-> Application settings
[003]      Vinay           08/06/2015    Ticket Number: 	240
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

namespace Rebound.GlobalTrader.BLL
{
    public partial class SettingItem
    {
        /// <summary>
        /// An enum representation of the 'tbSettingItem' table.
        /// </summary>
        /// <remark>This enumeration contains the items contained in the table tbSettingItem</remark>
        [Serializable]
        public enum List
        {
            MaxStockImages = 1,
            IncludeShippingOnHomepageStats = 2,
            AutoApprovePO = 3,
            DefaultSORating = 4,
            DefaultPORating = 5,
            HomepageTopSalespeople = 6,
            AutoApproveSO = 7,
            // [001] code start
            MaxPDFDocuments = 8,
            // [001] code end

            //[002] code start
            AutoExportSupplierInvoice = 9,
            //[002] code end
            IncludeInvoiceEmbedImage = 10,
            AgencySOAuthoriser = 11
        }
    }
}