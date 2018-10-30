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

	public partial class SourcingLink : BizObject {

		#region Properties

		protected static DAL.SourcingLinkElement Settings {
			get { return Globals.Settings.SourcingLinks; }
		}

		/// <summary>
		/// SourcingLinkId
		/// </summary>
		public System.Int32 SourcingLinkId { get; set; }
		/// <summary>
		/// SourcingLinkName
		/// </summary>
		public System.String SourcingLinkName { get; set; }
		/// <summary>
		/// URL
		/// </summary>
		public System.String URL { get; set; }
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// Delete
		/// Calls [usp_delete_SourcingLink]
		/// </summary>
		public static bool Delete(System.Int32? sourcingLinkId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.SourcingLink.Delete(sourcingLinkId);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_SourcingLink]
		/// </summary>
		public static Int32 Insert(System.String sourcingLinkName, System.String url, System.Int32? clientNo, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SourcingLink.Insert(sourcingLinkName, url, clientNo, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_SourcingLink]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.SourcingLink.Insert(SourcingLinkName, URL, ClientNo, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_SourcingLink]
		/// </summary>
		public static SourcingLink Get(System.Int32? sourcingLinkId) {
			Rebound.GlobalTrader.DAL.SourcingLinkDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SourcingLink.Get(sourcingLinkId);
			if (objDetails == null) {
				return null;
			} else {
				SourcingLink obj = new SourcingLink();
				obj.SourcingLinkId = objDetails.SourcingLinkId;
				obj.SourcingLinkName = objDetails.SourcingLinkName;
				obj.URL = objDetails.URL;
				obj.ClientNo = objDetails.ClientNo;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_SourcingLink_for_Client]
		/// </summary>
		public static List<SourcingLink> GetListForClient(System.Int32? clientId) {
			List<SourcingLinkDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SourcingLink.GetListForClient(clientId);
			if (lstDetails == null) {
				return new List<SourcingLink>();
			} else {
				List<SourcingLink> lst = new List<SourcingLink>();
				foreach (SourcingLinkDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SourcingLink obj = new Rebound.GlobalTrader.BLL.SourcingLink();
					obj.SourcingLinkId = objDetails.SourcingLinkId;
					obj.SourcingLinkName = objDetails.SourcingLinkName;
					obj.URL = objDetails.URL;
					obj.ClientNo = objDetails.ClientNo;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_SourcingLink]
		/// </summary>
		public static bool Update(System.Int32? sourcingLinkId, System.String sourcingLinkName, System.String url, System.Int32? clientNo, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.SourcingLink.Update(sourcingLinkId, sourcingLinkName, url, clientNo, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_SourcingLink]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.SourcingLink.Update(SourcingLinkId, SourcingLinkName, URL, ClientNo, UpdatedBy);
		}

		private static SourcingLink PopulateFromDBDetailsObject(SourcingLinkDetails obj) {
			SourcingLink objNew = new SourcingLink();
			objNew.SourcingLinkId = obj.SourcingLinkId;
			objNew.SourcingLinkName = obj.SourcingLinkName;
			objNew.URL = obj.URL;
			objNew.ClientNo = obj.ClientNo;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			return objNew;
		}

		#endregion

	}
}