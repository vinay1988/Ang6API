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
		public partial class MailMessageFolder : BizObject {
		
		#region Properties

		protected static DAL.MailMessageFolderElement Settings {
			get { return Globals.Settings.MailMessageFolders; }
		}

		/// <summary>
		/// MailMessageFolderId
		/// </summary>
		public System.Int32 MailMessageFolderId { get; set; }		
		/// <summary>
		/// LoginNo
		/// </summary>
		public System.Int32? LoginNo { get; set; }		
		/// <summary>
		/// Name
		/// </summary>
		public System.String Name { get; set; }		
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
		/// Calls [usp_delete_MailMessageFolder]
		/// </summary>
		public static bool Delete(System.Int32? mailMessageFolderNo) {
			return Rebound.GlobalTrader.DAL.SiteProvider.MailMessageFolder.Delete(mailMessageFolderNo);
		}
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_MailMessageFolder]
		/// </summary>
		public static List<MailMessageFolder> DropDown(System.Int32? loginNo) {
			List<MailMessageFolderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.MailMessageFolder.DropDown(loginNo);
			if (lstDetails == null) {
				return new List<MailMessageFolder>();
			} else {
				List<MailMessageFolder> lst = new List<MailMessageFolder>();
				foreach (MailMessageFolderDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.MailMessageFolder obj = new Rebound.GlobalTrader.BLL.MailMessageFolder();
					obj.MailMessageFolderId = objDetails.MailMessageFolderId;
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
		/// Calls [usp_insert_MailMessageFolder]
		/// </summary>
		public static Int32 Insert(System.Int32? loginNo, System.String name, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.MailMessageFolder.Insert(loginNo, name, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_MailMessageFolder]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.MailMessageFolder.Insert(LoginNo, Name, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_MailMessageFolder]
		/// </summary>
		public static MailMessageFolder Get(System.Int32? mailMessageFolderId) {
			Rebound.GlobalTrader.DAL.MailMessageFolderDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.MailMessageFolder.Get(mailMessageFolderId);
			if (objDetails == null) {
				return null;
			} else {
				MailMessageFolder obj = new MailMessageFolder();
				obj.MailMessageFolderId = objDetails.MailMessageFolderId;
				obj.LoginNo = objDetails.LoginNo;
				obj.Name = objDetails.Name;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_MailMessageFolder]
		/// </summary>
		public static List<MailMessageFolder> GetList() {
			List<MailMessageFolderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.MailMessageFolder.GetList();
			if (lstDetails == null) {
				return new List<MailMessageFolder>();
			} else {
				List<MailMessageFolder> lst = new List<MailMessageFolder>();
				foreach (MailMessageFolderDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.MailMessageFolder obj = new Rebound.GlobalTrader.BLL.MailMessageFolder();
					obj.MailMessageFolderId = objDetails.MailMessageFolderId;
					obj.LoginNo = objDetails.LoginNo;
					obj.Name = objDetails.Name;
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
		/// GetListForLogin
		/// Calls [usp_selectAll_MailMessageFolder_for_Login]
		/// </summary>
		public static List<MailMessageFolder> GetListForLogin(System.Int32? loginNo) {
			List<MailMessageFolderDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.MailMessageFolder.GetListForLogin(loginNo);
			if (lstDetails == null) {
				return new List<MailMessageFolder>();
			} else {
				List<MailMessageFolder> lst = new List<MailMessageFolder>();
				foreach (MailMessageFolderDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.MailMessageFolder obj = new Rebound.GlobalTrader.BLL.MailMessageFolder();
					obj.MailMessageFolderId = objDetails.MailMessageFolderId;
					obj.LoginNo = objDetails.LoginNo;
					obj.Name = objDetails.Name;
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
		/// Calls [usp_update_MailMessageFolder]
		/// </summary>
		public static bool Update(System.Int32? mailMessageFolderId, System.String name, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.MailMessageFolder.Update(mailMessageFolderId, name, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_MailMessageFolder]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.MailMessageFolder.Update(MailMessageFolderId, Name, UpdatedBy);
		}

        private static MailMessageFolder PopulateFromDBDetailsObject(MailMessageFolderDetails obj) {
            MailMessageFolder objNew = new MailMessageFolder();
			objNew.MailMessageFolderId = obj.MailMessageFolderId;
			objNew.LoginNo = obj.LoginNo;
			objNew.Name = obj.Name;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
            return objNew;
        }
		
		#endregion
		
	}
}