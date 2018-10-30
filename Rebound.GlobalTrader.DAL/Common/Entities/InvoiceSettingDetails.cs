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
    public class InvoiceSettingDetails  
    {
        #region Constructors

        public InvoiceSettingDetails() { }

        #endregion

        #region Properties

        /// <summary>
        ///  ID
        /// </summary>
        public System.Int32 ID { get; set; }

        public int Duration { get; set; }

        public DateTime StartDate { get; set; }

        public int? ClientNo { get; set; }

        public System.Boolean? IsActive { get; set; }

        public bool? Grouped { get; set; }

        public bool? IsLocked { get; set; } 

        public System.DateTime? DLUP { get; set; }

        public System.Int32? UpdatedBy { get; set; }
        public string ClientName { get; set; }
        public DateTime? LastRun { get; set; }
        #endregion
    }
}
