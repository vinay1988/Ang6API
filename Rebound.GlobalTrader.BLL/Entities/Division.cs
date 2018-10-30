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
		public partial class Division : BizObject {
		
		#region Properties

		protected static DAL.DivisionElement Settings {
			get { return Globals.Settings.Divisions; }
		}

		/// <summary>
		/// DivisionId
		/// </summary>
		public System.Int32 DivisionId { get; set; }		
		/// <summary>
		/// ClientNo
		/// </summary>
		public System.Int32 ClientNo { get; set; }		
		/// <summary>
		/// DivisionName
		/// </summary>
		public System.String DivisionName { get; set; }		
		/// <summary>
		/// AddressNo
		/// </summary>
		public System.Int32? AddressNo { get; set; }		
		/// <summary>
		/// Manager
		/// </summary>
		public System.Int32? Manager { get; set; }		
		/// <summary>
		/// Budget
		/// </summary>
		public System.Double? Budget { get; set; }		
		/// <summary>
		/// Telephone
		/// </summary>
		public System.String Telephone { get; set; }		
		/// <summary>
		/// Fax
		/// </summary>
		public System.String Fax { get; set; }		
		/// <summary>
		/// EMail
		/// </summary>
		public System.String EMail { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// URL
		/// </summary>
		public System.String URL { get; set; }		
		/// <summary>
		/// Inactive
		/// </summary>
		public System.Boolean Inactive { get; set; }		
		/// <summary>
		/// HasDocumentHeaderImage
		/// </summary>
		public System.Boolean HasDocumentHeaderImage { get; set; }		
		/// <summary>
		/// UseCompanyHeaderForInvoice
		/// </summary>
		public System.Boolean UseCompanyHeaderForInvoice { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// ManagerName
		/// </summary>
		public System.String ManagerName { get; set; }		
		/// <summary>
		/// NumberOfMembers
		/// </summary>
		public System.Int32? NumberOfMembers { get; set; }
        /// <summary>
        /// Agency
        /// </summary>
        public System.Boolean? Agency { get; set; }

		#endregion
		
		#region Methods
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Division]
		/// </summary>
		public static bool Delete(System.Int32? divisionId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Division.Delete(divisionId);
		}
		/// <summary>
		/// DropDownForClient
		/// Calls [usp_dropdown_Division_for_Client]
		/// </summary>
		public static List<Division> DropDownForClient(System.Int32? clientId) {
			List<DivisionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Division.DropDownForClient(clientId);
			if (lstDetails == null) {
				return new List<Division>();
			} else {
				List<Division> lst = new List<Division>();
				foreach (DivisionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Division obj = new Rebound.GlobalTrader.BLL.Division();
					obj.DivisionId = objDetails.DivisionId;
					obj.DivisionName = objDetails.DivisionName;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Division]
		/// </summary>
		public static Int32 Insert(System.Int32? clientNo, System.String divisionName, System.Int32? manager, System.Double? budget, System.String telephone, System.String fax, System.String email, System.String notes, System.String url, System.Int32? addressNo, System.Boolean? inactive, System.Int32? updatedBy,System.Boolean? agency) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.Division.Insert(clientNo, divisionName, manager, budget, telephone, fax, email, notes, url, addressNo, inactive, updatedBy,agency);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_Division]
		/// </summary>
		public Int32 Insert() {
            return Rebound.GlobalTrader.DAL.SiteProvider.Division.Insert(ClientNo, DivisionName, Manager, Budget, Telephone, Fax, EMail, Notes, URL, AddressNo, Inactive, UpdatedBy, Agency);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_Division]
		/// </summary>
		public static Division Get(System.Int32? divisionId) {
			Rebound.GlobalTrader.DAL.DivisionDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Division.Get(divisionId);
			if (objDetails == null) {
				return null;
			} else {
				Division obj = new Division();
				obj.DivisionId = objDetails.DivisionId;
				obj.ClientNo = objDetails.ClientNo;
				obj.DivisionName = objDetails.DivisionName;
				obj.AddressNo = objDetails.AddressNo;
				obj.Manager = objDetails.Manager;
				obj.Budget = objDetails.Budget;
				obj.Telephone = objDetails.Telephone;
				obj.Fax = objDetails.Fax;
				obj.EMail = objDetails.EMail;
				obj.Notes = objDetails.Notes;
				obj.URL = objDetails.URL;
				obj.Inactive = objDetails.Inactive;
				obj.HasDocumentHeaderImage = objDetails.HasDocumentHeaderImage;
				obj.UseCompanyHeaderForInvoice = objDetails.UseCompanyHeaderForInvoice;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
                obj.Agency = objDetails.Agency;
				obj.ManagerName = objDetails.ManagerName;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetHasDocumentHeader
		/// Calls [usp_select_Division_HasDocumentHeader]
		/// </summary>
		public static Division GetHasDocumentHeader(System.Int32? divisionId) {
			Rebound.GlobalTrader.DAL.DivisionDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.Division.GetHasDocumentHeader(divisionId);
			if (objDetails == null) {
				return null;
			} else {
				Division obj = new Division();
				obj.HasDocumentHeaderImage = objDetails.HasDocumentHeaderImage;
				obj.UseCompanyHeaderForInvoice = objDetails.UseCompanyHeaderForInvoice;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_Division_for_Client]
		/// </summary>
		public static List<Division> GetListForClient(System.Int32? clientId) {
			List<DivisionDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.Division.GetListForClient(clientId);
			if (lstDetails == null) {
				return new List<Division>();
			} else {
				List<Division> lst = new List<Division>();
				foreach (DivisionDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.Division obj = new Rebound.GlobalTrader.BLL.Division();
					obj.DivisionId = objDetails.DivisionId;
					obj.ClientNo = objDetails.ClientNo;
					obj.DivisionName = objDetails.DivisionName;
					obj.Manager = objDetails.Manager;
					obj.ManagerName = objDetails.ManagerName;
					obj.Budget = objDetails.Budget;
					obj.Telephone = objDetails.Telephone;
					obj.Fax = objDetails.Fax;
					obj.EMail = objDetails.EMail;
					obj.Notes = objDetails.Notes;
					obj.URL = objDetails.URL;
					obj.Inactive = objDetails.Inactive;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.NumberOfMembers = objDetails.NumberOfMembers;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_Division]
		/// </summary>
		public static bool Update(System.Int32? divisionId, System.Int32? clientNo, System.String divisionName, System.Int32? manager, System.Double? budget, System.String telephone, System.String fax, System.String email, System.String notes, System.String url, System.Int32? addressNo, System.Boolean? inactive, System.Int32? updatedBy,System.Boolean? agency) {
            return Rebound.GlobalTrader.DAL.SiteProvider.Division.Update(divisionId, clientNo, divisionName, manager, budget, telephone, fax, email, notes, url, addressNo, inactive, updatedBy, agency);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_Division]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.Division.Update(DivisionId, ClientNo, DivisionName, Manager, Budget, Telephone, Fax, EMail, Notes, URL, AddressNo, Inactive, UpdatedBy,Agency);
		}
		/// <summary>
		/// UpdateAddressNo
		/// Calls [usp_update_Division_AddressNo]
		/// </summary>
		public static bool UpdateAddressNo(System.Int32? divisionNo, System.Int32? addressNo, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Division.UpdateAddressNo(divisionNo, addressNo, updatedBy);
		}
		/// <summary>
		/// UpdateDocumentHeaderImage
		/// Calls [usp_update_Division_DocumentHeaderImage]
		/// </summary>
		public static bool UpdateDocumentHeaderImage(System.Int32? divisionNo, System.Boolean? hasDocumentHeaderImage, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Division.UpdateDocumentHeaderImage(divisionNo, hasDocumentHeaderImage, updatedBy);
		}
		/// <summary>
		/// UpdateUseCompanyHeaderForInvoice
		/// Calls [usp_update_Division_UseCompanyHeaderForInvoice]
		/// </summary>
		public static bool UpdateUseCompanyHeaderForInvoice(System.Int32? divisionId, System.Boolean? useCompanyHeaderForInvoice, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.Division.UpdateUseCompanyHeaderForInvoice(divisionId, useCompanyHeaderForInvoice, updatedBy);
		}

        private static Division PopulateFromDBDetailsObject(DivisionDetails obj) {
            Division objNew = new Division();
			objNew.DivisionId = obj.DivisionId;
			objNew.ClientNo = obj.ClientNo;
			objNew.DivisionName = obj.DivisionName;
			objNew.AddressNo = obj.AddressNo;
			objNew.Manager = obj.Manager;
			objNew.Budget = obj.Budget;
			objNew.Telephone = obj.Telephone;
			objNew.Fax = obj.Fax;
			objNew.EMail = obj.EMail;
			objNew.Notes = obj.Notes;
			objNew.URL = obj.URL;
			objNew.Inactive = obj.Inactive;
			objNew.HasDocumentHeaderImage = obj.HasDocumentHeaderImage;
			objNew.UseCompanyHeaderForInvoice = obj.UseCompanyHeaderForInvoice;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.ManagerName = obj.ManagerName;
			objNew.NumberOfMembers = obj.NumberOfMembers;
            return objNew;
        }
		
		#endregion
		
	}
}