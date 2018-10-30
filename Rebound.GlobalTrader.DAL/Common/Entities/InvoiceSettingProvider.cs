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
    public abstract class InvoiceSettingProvider : DataAccess
    {
        static private InvoiceSettingProvider _instance = null;
        /// <summary>
        /// Returns an instance of the provider type specified in the 
        /// file
        /// </summary>       
        static public InvoiceSettingProvider Instance
        {
            get
            {
                if (_instance == null) _instance = (InvoiceSettingProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.InvoiceSetting.ProviderType));
                return _instance;
            }
        }
        public InvoiceSettingProvider()
        {
            this.ConnectionString = Globals.Settings.InvoiceSetting.ConnectionString;
        }

        /// <summary>
        /// Insert
        /// Calls [usp_insert_InvoiceSchedule]
        /// </summary>
        public abstract Int32 Insert(System.Int32? duration, DateTime? startdate, System.Boolean? inactive, System.Boolean? grouped, System.Int32? createdBy,Int32? clientNo);

        /// <summary>
        /// usp_select_InvoiceSchedule
        /// </summary>
        /// <returns></returns>
        public abstract InvoiceSettingDetails Get(System.Int32? Id);
        /// <summary>
        /// usp_select_InvoiceSchedule
        /// </summary>
        /// <returns></returns>
        public abstract List<InvoiceSettingDetails> GetData(int? clientNo);
        /// <summary>
        /// Calls [usp_Update_InvoiceSchedule]
        /// </summary>
        public abstract bool Update(System.Int32 Id, System.Int32 duration, System.DateTime startDate, System.Boolean? inactive, System.Boolean? grouped, System.Int32? updatedBy,int? clientNo);
    }
}
