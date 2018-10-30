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
		public partial class CommunicationLog : BizObject {
		
		#region Properties

		protected static DAL.CommunicationLogElement Settings {
			get { return Globals.Settings.CommunicationLogs; }
		}

		/// <summary>
		/// CommunicationLogId
		/// </summary>
		public System.Int32 CommunicationLogId { get; set; }		
		/// <summary>
		/// Notes
		/// </summary>
		public System.String Notes { get; set; }		
		/// <summary>
		/// ContactNo
		/// </summary>
		public System.Int32? ContactNo { get; set; }		
		/// <summary>
		/// CompanyNo
		/// </summary>
		public System.Int32? CompanyNo { get; set; }		
		/// <summary>
		/// Frozen
		/// </summary>
		public System.Boolean Frozen { get; set; }		
		/// <summary>
		/// UpdatedBy
		/// </summary>
		public System.Int32? UpdatedBy { get; set; }		
		/// <summary>
		/// DLUP
		/// </summary>
		public System.DateTime DLUP { get; set; }		
		/// <summary>
		/// LogDate
		/// </summary>
		public System.DateTime LogDate { get; set; }		
		/// <summary>
		/// KeyNo
		/// </summary>
		public System.Int32? KeyNo { get; set; }		
		/// <summary>
		/// CommunicationLogTypeNo
		/// </summary>
		public System.Int32? CommunicationLogTypeNo { get; set; }		
		/// <summary>
		/// SystemDocumentNo
		/// </summary>
		public System.Int32? SystemDocumentNo { get; set; }		
		/// <summary>
		/// DocumentNumber
		/// </summary>
		public System.Int32? DocumentNumber { get; set; }		
		/// <summary>
		/// ContactName
		/// </summary>
		public System.String ContactName { get; set; }		
		/// <summary>
		/// CompanyName
		/// </summary>
		public System.String CompanyName { get; set; }		
		/// <summary>
		/// CommunicationLogTypeDescription
		/// </summary>
		public System.String CommunicationLogTypeDescription { get; set; }		
		/// <summary>
		/// EnteredBy
		/// </summary>
		public System.String EnteredBy { get; set; }		
		/// <summary>
		/// RowNum
		/// </summary>
		public System.Int64? RowNum { get; set; }		
		/// <summary>
		/// RowCnt
		/// </summary>
		public System.Int32? RowCnt { get; set; }
        /// <summary>
        /// LogDetail 
        /// </summary>
        public System.String LogDetail { get; set; }
        /// <summary>
        /// SectionName 
        /// </summary>
        public System.String SectionName { get; set; }
        /// <summary>
        /// ActionName 
        /// </summary>
        public System.String ActionName { get; set; }
        /// <summary>
        /// UpdatedByName
        /// </summary>
        public System.String UpdatedByName { get; set; }
        /// <summary>
        /// SubSectionName 
        /// </summary>
        public System.String SubSectionName { get; set; }
		#endregion
		
		#region Methods
		
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_CommunicationLog]
		/// </summary>
		public static List<CommunicationLog> DataListNugget(System.Int32? clientId, System.Int32? companyNo, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? loginId, System.String details, System.Int32? contactNo, System.Int32? communicationLogTypeNo, System.String logCallType, System.DateTime? logDateLo, System.DateTime? logDateHi) {
			List<CommunicationLogDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLog.DataListNugget(clientId, companyNo, orderBy, sortDir, pageIndex, pageSize, loginId, details, contactNo, communicationLogTypeNo, logCallType, logDateLo, logDateHi);
			if (lstDetails == null) {
				return new List<CommunicationLog>();
			} else {
				List<CommunicationLog> lst = new List<CommunicationLog>();
				foreach (CommunicationLogDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CommunicationLog obj = new Rebound.GlobalTrader.BLL.CommunicationLog();
					obj.CommunicationLogId = objDetails.CommunicationLogId;
					obj.LogDate = objDetails.LogDate;
					obj.Notes = objDetails.Notes;
					obj.ContactNo = objDetails.ContactNo;
					obj.ContactName = objDetails.ContactName;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.CompanyName = objDetails.CompanyName;
					obj.Frozen = objDetails.Frozen;
					obj.KeyNo = objDetails.KeyNo;
					obj.SystemDocumentNo = objDetails.SystemDocumentNo;
					obj.DocumentNumber = objDetails.DocumentNumber;
					obj.CommunicationLogTypeNo = objDetails.CommunicationLogTypeNo;
					obj.CommunicationLogTypeDescription = objDetails.CommunicationLogTypeDescription;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.EnteredBy = objDetails.EnteredBy;
					obj.RowNum = objDetails.RowNum;
					obj.RowCnt = objDetails.RowCnt;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Delete
		/// Calls [usp_delete_CommunicationLog]
		/// </summary>
		public static bool Delete(System.Int32? communicationLogId) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLog.Delete(communicationLogId);
		}
		/// <summary>
		/// Insert
		/// Calls [usp_insert_CommunicationLog]
		/// </summary>
		public static Int32 Insert(System.Int32? communicationLogTypeNo, System.Int32? systemDocumentNo, System.DateTime? logDate, System.String notes, System.Int32? contactNo, System.Int32? companyNo, System.Boolean? frozen, System.Int32? updatedBy) {
			Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLog.Insert(communicationLogTypeNo, systemDocumentNo, logDate, notes, contactNo, companyNo, frozen, updatedBy);
			return objReturn;
		}
		/// <summary>
		/// Insert (without parameters)
		/// Calls [usp_insert_CommunicationLog]
		/// </summary>
		public Int32 Insert() {
			return Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLog.Insert(CommunicationLogTypeNo, SystemDocumentNo, LogDate, Notes, ContactNo, CompanyNo, Frozen, UpdatedBy);
		}
		/// <summary>
		/// Get
		/// Calls [usp_select_CommunicationLog]
		/// </summary>
		public static CommunicationLog Get(System.Int32? communicationLogId) {
			Rebound.GlobalTrader.DAL.CommunicationLogDetails objDetails = Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLog.Get(communicationLogId);
			if (objDetails == null) {
				return null;
			} else {
				CommunicationLog obj = new CommunicationLog();
				obj.CommunicationLogId = objDetails.CommunicationLogId;
				obj.Notes = objDetails.Notes;
				obj.ContactNo = objDetails.ContactNo;
				obj.CompanyNo = objDetails.CompanyNo;
				obj.Frozen = objDetails.Frozen;
				obj.UpdatedBy = objDetails.UpdatedBy;
				obj.DLUP = objDetails.DLUP;
				obj.LogDate = objDetails.LogDate;
				obj.KeyNo = objDetails.KeyNo;
				obj.CommunicationLogTypeNo = objDetails.CommunicationLogTypeNo;
				obj.SystemDocumentNo = objDetails.SystemDocumentNo;
				obj.DocumentNumber = objDetails.DocumentNumber;
				obj.CommunicationLogTypeDescription = objDetails.CommunicationLogTypeDescription;
				obj.ContactName = objDetails.ContactName;
				obj.EnteredBy = objDetails.EnteredBy;
				objDetails = null;
				return obj;
			}
		}
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_CommunicationLog]
		/// </summary>
		public static List<CommunicationLog> GetList() {
			List<CommunicationLogDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLog.GetList();
			if (lstDetails == null) {
				return new List<CommunicationLog>();
			} else {
				List<CommunicationLog> lst = new List<CommunicationLog>();
				foreach (CommunicationLogDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CommunicationLog obj = new Rebound.GlobalTrader.BLL.CommunicationLog();
					obj.CommunicationLogId = objDetails.CommunicationLogId;
					obj.Notes = objDetails.Notes;
					obj.ContactNo = objDetails.ContactNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.Frozen = objDetails.Frozen;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.LogDate = objDetails.LogDate;
					obj.KeyNo = objDetails.KeyNo;
					obj.CommunicationLogTypeNo = objDetails.CommunicationLogTypeNo;
					obj.SystemDocumentNo = objDetails.SystemDocumentNo;
					obj.DocumentNumber = objDetails.DocumentNumber;
					obj.CommunicationLogTypeDescription = objDetails.CommunicationLogTypeDescription;
					obj.ContactName = objDetails.ContactName;
					obj.EnteredBy = objDetails.EnteredBy;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForCommunicationLogType
		/// Calls [usp_selectAll_CommunicationLog_for_CommunicationLogType]
		/// </summary>
		public static List<CommunicationLog> GetListForCommunicationLogType(System.Int32? communicationLogTypeId) {
			List<CommunicationLogDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLog.GetListForCommunicationLogType(communicationLogTypeId);
			if (lstDetails == null) {
				return new List<CommunicationLog>();
			} else {
				List<CommunicationLog> lst = new List<CommunicationLog>();
				foreach (CommunicationLogDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CommunicationLog obj = new Rebound.GlobalTrader.BLL.CommunicationLog();
					obj.CommunicationLogId = objDetails.CommunicationLogId;
					obj.Notes = objDetails.Notes;
					obj.ContactNo = objDetails.ContactNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.Frozen = objDetails.Frozen;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.LogDate = objDetails.LogDate;
					obj.KeyNo = objDetails.KeyNo;
					obj.CommunicationLogTypeNo = objDetails.CommunicationLogTypeNo;
					obj.SystemDocumentNo = objDetails.SystemDocumentNo;
					obj.DocumentNumber = objDetails.DocumentNumber;
					obj.CommunicationLogTypeDescription = objDetails.CommunicationLogTypeDescription;
					obj.ContactName = objDetails.ContactName;
					obj.EnteredBy = objDetails.EnteredBy;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForCompany
		/// Calls [usp_selectAll_CommunicationLog_for_Company]
		/// </summary>
		public static List<CommunicationLog> GetListForCompany(System.Int32? companyId) {
			List<CommunicationLogDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLog.GetListForCompany(companyId);
			if (lstDetails == null) {
				return new List<CommunicationLog>();
			} else {
				List<CommunicationLog> lst = new List<CommunicationLog>();
				foreach (CommunicationLogDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CommunicationLog obj = new Rebound.GlobalTrader.BLL.CommunicationLog();
					obj.CommunicationLogId = objDetails.CommunicationLogId;
					obj.Notes = objDetails.Notes;
					obj.ContactNo = objDetails.ContactNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.Frozen = objDetails.Frozen;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.LogDate = objDetails.LogDate;
					obj.KeyNo = objDetails.KeyNo;
					obj.CommunicationLogTypeNo = objDetails.CommunicationLogTypeNo;
					obj.SystemDocumentNo = objDetails.SystemDocumentNo;
					obj.DocumentNumber = objDetails.DocumentNumber;
					obj.CommunicationLogTypeDescription = objDetails.CommunicationLogTypeDescription;
					obj.ContactName = objDetails.ContactName;
					obj.EnteredBy = objDetails.EnteredBy;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// GetListForContact
		/// Calls [usp_selectAll_CommunicationLog_for_Contact]
		/// </summary>
		public static List<CommunicationLog> GetListForContact(System.Int32? contactId) {
			List<CommunicationLogDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLog.GetListForContact(contactId);
			if (lstDetails == null) {
				return new List<CommunicationLog>();
			} else {
				List<CommunicationLog> lst = new List<CommunicationLog>();
				foreach (CommunicationLogDetails objDetails in lstDetails) {
					Rebound.GlobalTrader.BLL.CommunicationLog obj = new Rebound.GlobalTrader.BLL.CommunicationLog();
					obj.CommunicationLogId = objDetails.CommunicationLogId;
					obj.Notes = objDetails.Notes;
					obj.ContactNo = objDetails.ContactNo;
					obj.CompanyNo = objDetails.CompanyNo;
					obj.Frozen = objDetails.Frozen;
					obj.UpdatedBy = objDetails.UpdatedBy;
					obj.DLUP = objDetails.DLUP;
					obj.LogDate = objDetails.LogDate;
					obj.KeyNo = objDetails.KeyNo;
					obj.CommunicationLogTypeNo = objDetails.CommunicationLogTypeNo;
					obj.SystemDocumentNo = objDetails.SystemDocumentNo;
					obj.DocumentNumber = objDetails.DocumentNumber;
					obj.CommunicationLogTypeDescription = objDetails.CommunicationLogTypeDescription;
					obj.ContactName = objDetails.ContactName;
					obj.EnteredBy = objDetails.EnteredBy;
					lst.Add(obj);
					obj = null;
				}
				lstDetails = null;
				return lst;
			}
		}
		/// <summary>
		/// Update
		/// Calls [usp_update_CommunicationLog]
		/// </summary>
		public static bool Update(System.Int32? communicationLogId, System.Int32? communicationLogTypeNo, System.Int32? systemDocumentNo, System.String notes, System.Int32? contactNo, System.Int32? companyNo, System.Boolean? frozen, System.Int32? updatedBy) {
			return Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLog.Update(communicationLogId, communicationLogTypeNo, systemDocumentNo, notes, contactNo, companyNo, frozen, updatedBy);
		}
		/// <summary>
		/// Update (without parameters)
		/// Calls [usp_update_CommunicationLog]
		/// </summary>
		public bool Update() {
			return Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLog.Update(CommunicationLogId, CommunicationLogTypeNo, SystemDocumentNo, Notes, ContactNo, CompanyNo, Frozen, UpdatedBy);
		}

        private static CommunicationLog PopulateFromDBDetailsObject(CommunicationLogDetails obj) {
            CommunicationLog objNew = new CommunicationLog();
			objNew.CommunicationLogId = obj.CommunicationLogId;
			objNew.Notes = obj.Notes;
			objNew.ContactNo = obj.ContactNo;
			objNew.CompanyNo = obj.CompanyNo;
			objNew.Frozen = obj.Frozen;
			objNew.UpdatedBy = obj.UpdatedBy;
			objNew.DLUP = obj.DLUP;
			objNew.LogDate = obj.LogDate;
			objNew.KeyNo = obj.KeyNo;
			objNew.CommunicationLogTypeNo = obj.CommunicationLogTypeNo;
			objNew.SystemDocumentNo = obj.SystemDocumentNo;
			objNew.DocumentNumber = obj.DocumentNumber;
			objNew.ContactName = obj.ContactName;
			objNew.CompanyName = obj.CompanyName;
			objNew.CommunicationLogTypeDescription = obj.CommunicationLogTypeDescription;
			objNew.EnteredBy = obj.EnteredBy;
			objNew.RowNum = obj.RowNum;
			objNew.RowCnt = obj.RowCnt;
            return objNew;
        }

        /// <summary>
        /// InsertPrintEmailLog
        /// Calls [usp_insert_PrintEmailLog]
        /// </summary>
        public static Int32 InsertPrintEmailLog(System.String sectionName, System.String subSectionName, System.String actionName, System.Int32? documentNo, System.String Detail, System.Int32? updatedBy)
        {
            Int32 objReturn = Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLog.InsertPrintEmailLog(sectionName,subSectionName, actionName, documentNo, Detail, updatedBy);
            return objReturn;
        }

        /// <summary>
        /// GetPrintEmailLog
        /// Calls [usp_select_PrintEmailLog]
        /// </summary>
        public static List<CommunicationLog> GetPrintEmailLog(System.Int32? documentNo,System.String secionName)
        {
            List<CommunicationLogDetails> lstDetails = Rebound.GlobalTrader.DAL.SiteProvider.CommunicationLog.GetPrintEmailLog(documentNo, secionName);
            if (lstDetails == null)
            {
                return new List<CommunicationLog>();
            }
            else
            {
                List<CommunicationLog> lst = new List<CommunicationLog>();
                foreach (CommunicationLogDetails objDetails in lstDetails)
                {
                    Rebound.GlobalTrader.BLL.CommunicationLog obj = new Rebound.GlobalTrader.BLL.CommunicationLog();
                    obj.CommunicationLogId = objDetails.CommunicationLogId;
                    obj.SystemDocumentNo = objDetails.SystemDocumentNo;
                    obj.LogDetail = objDetails.LogDetail;
                    obj.SectionName = objDetails.SectionName;
                    obj.ActionName = objDetails.ActionName;
                    obj.UpdatedBy = objDetails.UpdatedBy;
                    obj.DLUP = objDetails.DLUP;
                    obj.UpdatedByName = objDetails.UpdatedByName;
                    obj.SubSectionName = objDetails.SubSectionName;
                    //obj.DocumentNumber = objDetails.DocumentNumber;
                    lst.Add(obj);
                    obj = null;
                }
                lstDetails = null;
                return lst;
            }
        }
		
		#endregion
		
	}
}