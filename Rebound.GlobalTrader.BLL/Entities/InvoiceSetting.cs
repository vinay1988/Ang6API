
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
    public partial class InvoiceSetting : BizObject
    {
        #region Properties
        protected static DAL.InvoiceSettingElement Settings
        {
            get { return Globals.Settings.InvoiceSetting; }
        }

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

        #region Method
        /// <summary>
        /// Insert
        /// Calls [usp_insert_InvoiceSchedule] 
        /// </summary>
        public static Int32 Insert(System.Int32? duration, DateTime? startdate, System.Boolean? isActive, System.Boolean? grouped, Int32? createdBy,System.Int32? clientNo)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceSetting.Insert(duration, startdate, isActive, grouped, createdBy,clientNo);
            return objReturn;
        }
        /// <summary>
        /// Get
        /// Calls [usp_selectAll_InvoiceSchedule]
        /// </summary>
        public static List<InvoiceSetting> GetData(int? clientNo)
        {
            List<Rebound.GlobalTrader.DAL.InvoiceSettingDetails> objDetails = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceSetting.GetData(clientNo);
            List<InvoiceSetting> invoiceSetting = new List<InvoiceSetting>();
            if (objDetails != null)
            {
                foreach (InvoiceSettingDetails item in objDetails)
                {
                    InvoiceSetting obj = new InvoiceSetting();
                    obj.ID = item.ID;
                    obj.Duration = item.Duration;
                    obj.StartDate = item.StartDate;
                    obj.Grouped = item.Grouped;
                    obj.ClientNo = item.ClientNo;
                    obj.IsActive = item.IsActive;
                    obj.IsLocked = item.IsLocked;
                    obj.UpdatedBy = item.UpdatedBy;
                    obj.DLUP = item.DLUP;
                    obj.ClientNo = item.ClientNo;
                    obj.ClientName = item.ClientName;
                    obj.LastRun = item.LastRun;
                    invoiceSetting.Add(obj);
                    objDetails = null;
                }
            }

            return invoiceSetting;
        }
        /// <summary>
        /// Get
        /// Calls [usp_selectAll_InvoiceSchedule]
        /// </summary>
        public static InvoiceSetting Get(int? Id)
        {
            Rebound.GlobalTrader.DAL.InvoiceSettingDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.InvoiceSetting.Get(Id);
            if (objDetails == null)
            {
                return null;
            }
            else
            {
                InvoiceSetting obj = new InvoiceSetting();
                obj.ID = objDetails.ID;
                obj.Duration = objDetails.Duration;
                obj.StartDate = objDetails.StartDate;
                obj.Grouped = objDetails.Grouped;
                obj.ClientNo = objDetails.ClientNo;
                obj.IsActive = objDetails.IsActive;
                obj.IsLocked = objDetails.IsLocked;
                obj.UpdatedBy = objDetails.UpdatedBy;
                obj.DLUP = objDetails.DLUP;
                objDetails = null;
                return obj;
            }


        }
        /// <summary>
        /// Update
        /// Calls [usp_Update_InvoiceSchedule]
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            return Rebound.GlobalTrader.DAL.SiteProvider.InvoiceSetting.Update(ID, Duration, StartDate, IsActive, Grouped, UpdatedBy,ClientNo);
        }
        #endregion
    }
    
       
}
