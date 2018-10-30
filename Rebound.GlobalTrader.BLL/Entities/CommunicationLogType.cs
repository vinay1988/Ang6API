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
		public partial class CommunicationLogType : BizObject {
		
		#region Properties

		protected static DAL.CommunicationLogTypeElement Settings {
			get { return Globals.Settings.CommunicationLogTypes; }
		}

		/// <summary>
		/// CommunicationLogTypeId
		/// </summary>
		public System.Int32 CommunicationLogTypeId { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Count
		/// Calls [usp_count_CommunicationLogType]
		/// </summary>
		public static Int32 Count() {
			return Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLogType.Count();
		}		/// <summary>
		/// Delete
		/// Calls [usp_delete_CommunicationLogType]
		/// </summary>
		public static bool Delete(System.Int32? communicationLogTypeId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLogType.Delete(communicationLogTypeId);
		}
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_CommunicationLogType]
		/// </summary>
		public static List<CommunicationLogType> DropDown() {
			List<CommunicationLogTypeDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLogType.DropDown();
			if (lstDetails == null) {
				return new List<CommunicationLogType>();
			} else {
				List<CommunicationLogType> lst = new List<CommunicationLogType>();
				foreach (CommunicationLogTypeDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CommunicationLogType obj = new Rebound.GlobalTrader.BLL.CommunicationLogType();
					obj.CommunicationLogTypeId = objDetails.CommunicationLogTypeId;
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
		/// Calls [usp_insert_CommunicationLogType]
		/// </summary>
		public static Int32 Insert(System.String name) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLogType.Insert(name);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_CommunicationLogType]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLogType.Insert(Name);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_CommunicationLogType]
		/// </summary>
		public static CommunicationLogType Get(System.Int32? communicationLogTypeId) {
			Rebound.GlobalTrader.DAL.CommunicationLogTypeDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLogType.Get(communicationLogTypeId);
			if (objDetails == null) {
				return null;
			} else {
				CommunicationLogType obj = new CommunicationLogType();
				obj.CommunicationLogTypeId = objDetails.CommunicationLogTypeId;
				obj.Name = objDetails.Name;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_CommunicationLogType]
		/// </summary>
		public static List<CommunicationLogType> GetList() {
			List<CommunicationLogTypeDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLogType.GetList();
			if (lstDetails == null) {
				return new List<CommunicationLogType>();
			} else {
				List<CommunicationLogType> lst = new List<CommunicationLogType>();
				foreach (CommunicationLogTypeDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CommunicationLogType obj = new Rebound.GlobalTrader.BLL.CommunicationLogType();
					obj.CommunicationLogTypeId = objDetails.CommunicationLogTypeId;
					obj.Name = objDetails.Name;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_CommunicationLogType]
		/// </summary>
		public static bool Update(System.Int32? communicationLogTypeId, System.String name) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLogType.Update(communicationLogTypeId, name);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_CommunicationLogType]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLogType.Update(CommunicationLogTypeId, Name);
		}

        private static CommunicationLogType PopulateFromDBDetailsObject(CommunicationLogTypeDetails obj) {
            CommunicationLogType objNew = new CommunicationLogType();
			objNew.CommunicationLogTypeId = obj.CommunicationLogTypeId;
			objNew.Name = obj.Name;
            return objNew;
        }
		
		#endregion
		
	}
}