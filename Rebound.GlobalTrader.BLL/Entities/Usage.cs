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
		public partial class Usage : BizObject {
		
		#region Properties

		protected static DAL.UsageElement Settings {
			get { return Globals.Settings.Usages; }
		}

		/// <summary>
		/// UsageId
		/// </summary>
		public System.Int32 UsageId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_Usage]
		/// </summary>
		public static List<Usage> DropDown() {
			List<UsageDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Usage.DropDown();
			if (lstDetails == null) {
				return new List<Usage>();
			} else {
				List<Usage> lst = new List<Usage>();
				foreach (UsageDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Usage obj = new Rebound.GlobalTrader.BLL.Usage();
					obj.UsageId = objDetails.UsageId;
					obj.Name = objDetails.Name;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
        /// <summary>
        /// DropDown
        /// Calls [usp_dropdown_RequirementData]
        /// </summary>
        public static List<Usage> ReqDropDown(string ReqType)
        {
            List<UsageDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Usage.ReqDropDown(ReqType);
            if (lstDetails == null)
            {
                return new List<Usage>();
            }
            else
            {
                List<Usage> lst = new List<Usage>();
                foreach (UsageDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.Usage obj = new Rebound.GlobalTrader.BLL.Usage();
                    obj.UsageId = objDetails.UsageId;
                    obj.Name = objDetails.Name;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }

		/// <summary>
		/// Insert
		/// Calls [usp_insert_Usage]
		/// </summary>
		public static Int32 Insert(System.String name) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Usage.Insert(name);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Usage]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Usage.Insert(Name);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_Usage]
		/// </summary>
		public static Usage Get(System.Int32? usageId) {
			Rebound.GlobalTrader.DAL.UsageDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Usage.Get(usageId);
			if (objDetails == null) {
				return null;
			} else {
				Usage obj = new Usage();
				obj.UsageId = objDetails.UsageId;
				obj.Name = objDetails.Name;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_Usage]
		/// </summary>
		public static bool Update(System.String name, System.Int32? usageId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Usage.Update(name, usageId);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Usage]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Usage.Update(Name, UsageId);
		}

        private static Usage PopulateFromDBDetailsObject(UsageDetails obj) {
            Usage objNew = new Usage();
			objNew.UsageId = obj.UsageId;
			objNew.Name = obj.Name;
            return objNew;
        }
		
		#endregion
		
	}
}