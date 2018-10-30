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
		public partial class SystemDocumentFooter : BizObject {
		
		#region Properties

		protected static DAL.SystemDocumentFooterElement Settings {
			get { return Globals.Settings.SystemDocumentFooters; }
		}

		/// <summary>
		/// SystemDocumentFooterId
		/// </summary>
		public System.Int32 SystemDocumentFooterId { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// SystemDocumentNo
		/// </summary>
		public System.Int32 SystemDocumentNo { get; set; }		
		/// <summary>
		/// FooterText
		/// </summary>
		public System.String FooterText { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime? DLUP { get; set; }		
		/// <summary>
		/// SystemDocumentName
		/// </summary>
		public System.String SystemDocumentName { get; set; }		

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_SystemDocumentFooter]
		/// </summary>
		public static bool Delete(System.Int32? systemDocumentFooterNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.SystemDocumentFooter.Delete(systemDocumentFooterNo);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_SystemDocumentFooter]
		/// </summary>
		public static Int32 Insert(System.Int32? clientNo, System.Int32? systemDocumentNo, System.String footerText, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.SystemDocumentFooter.Insert(clientNo, systemDocumentNo, footerText, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_SystemDocumentFooter]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.SystemDocumentFooter.Insert(ClientNo, SystemDocumentNo, FooterText, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_SystemDocumentFooter]
		/// </summary>
		public static SystemDocumentFooter Get(System.Int32? systemDocumentFooterNo) {
			Rebound.GlobalTrader.DAL.SystemDocumentFooterDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SystemDocumentFooter.Get(systemDocumentFooterNo);
			if (objDetails == null) {
				return null;
			} else {
				SystemDocumentFooter obj = new SystemDocumentFooter();
				obj.SystemDocumentFooterId = objDetails.SystemDocumentFooterId;
				obj.ClientNo = objDetails.ClientNo;
				obj.SystemDocumentNo = objDetails.SystemDocumentNo;
				obj.FooterText = objDetails.FooterText;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetForClientAndDocument
		/// Calls [usp_select_SystemDocumentFooter_for_Client_and_Document]
		/// </summary>
		public static SystemDocumentFooter GetForClientAndDocument(System.Int32? clientNo, System.Int32? systemDocumentNo) {
			Rebound.GlobalTrader.DAL.SystemDocumentFooterDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.SystemDocumentFooter.GetForClientAndDocument(clientNo, systemDocumentNo);
			if (objDetails == null) {
				return null;
			} else {
				SystemDocumentFooter obj = new SystemDocumentFooter();
				obj.FooterText = objDetails.FooterText;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_SystemDocumentFooter_for_Client]
		/// </summary>
		public static List<SystemDocumentFooter> GetListForClient(System.Int32? clientNo) {
			List<SystemDocumentFooterDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.SystemDocumentFooter.GetListForClient(clientNo);
			if (lstDetails == null) {
				return new List<SystemDocumentFooter>();
			} else {
				List<SystemDocumentFooter> lst = new List<SystemDocumentFooter>();
				foreach (SystemDocumentFooterDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.SystemDocumentFooter obj = new Rebound.GlobalTrader.BLL.SystemDocumentFooter();
					obj.SystemDocumentFooterId = objDetails.SystemDocumentFooterId;
					obj.ClientNo = objDetails.ClientNo;
					obj.SystemDocumentNo = objDetails.SystemDocumentNo;
					obj.SystemDocumentName = objDetails.SystemDocumentName;
					obj.FooterText = objDetails.FooterText;
					obj.DLUP = objDetails.DLUP;
					obj.UpdatedBy = objDetails.UpdatedBy;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_SystemDocumentFooter]
		/// </summary>
		public static bool Update(System.Int32? systemDocumentFooterId, System.Int32? clientNo, System.Int32? systemDocumentNo, System.String footerText, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.SystemDocumentFooter.Update(systemDocumentFooterId, clientNo, systemDocumentNo, footerText, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_SystemDocumentFooter]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.SystemDocumentFooter.Update(SystemDocumentFooterId, ClientNo, SystemDocumentNo, FooterText, UpdatedBy);
		}

        private static SystemDocumentFooter PopulateFromDBDetailsObject(SystemDocumentFooterDetails obj) {
            SystemDocumentFooter objNew = new SystemDocumentFooter();
			objNew.SystemDocumentFooterId = obj.SystemDocumentFooterId;
			objNew.ClientNo = obj.ClientNo;
			objNew.SystemDocumentNo = obj.SystemDocumentNo;
			objNew.FooterText = obj.FooterText;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.SystemDocumentName = obj.SystemDocumentName;
            return objNew;
        }
		
		#endregion
		
	}
}