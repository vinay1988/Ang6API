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

namespace Rebound.GlobalTrader.DAL {
	
	public abstract class CommunicationLogProvider : DataAccess {
		static private CommunicationLogProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public CommunicationLogProvider Instance {
			get {
				if (_instance == null) _instance = (CommunicationLogProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.CommunicationLogs.ProviderType));
				return _instance;
			}
		}
		public CommunicationLogProvider() {
			this.ConnectionString = Globals.Settings.CommunicationLogs.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// DataListNugget
		/// Calls [usp_datalistnugget_CommunicationLog]
		/// </summary>
		public abstract List<CommunicationLogDetails> DataListNugget(System.Int32? clientId, System.Int32? companyNo, System.Int32? orderBy, System.Int32? sortDir, System.Int32? pageIndex, System.Int32? pageSize, System.Int32? loginId, System.String details, System.Int32? contactNo, System.Int32? communicationLogTypeNo, System.String logCallType, System.DateTime? logDateLo, System.DateTime? logDateHi);
		/// <summary>
		/// Delete
		/// Calls [usp_delete_CommunicationLog]
		/// </summary>
		public abstract bool Delete(System.Int32? communicationLogId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_CommunicationLog]
		/// </summary>
		public abstract Int32 Insert(System.Int32? communicationLogTypeNo, System.Int32? systemDocumentNo, System.DateTime? logDate, System.String notes, System.Int32? contactNo, System.Int32? companyNo, System.Boolean? frozen, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_CommunicationLog]
		/// </summary>
		public abstract CommunicationLogDetails Get(System.Int32? communicationLogId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_CommunicationLog]
		/// </summary>
		public abstract List<CommunicationLogDetails> GetList();
		/// <summary>
		/// GetListForCommunicationLogType
		/// Calls [usp_selectAll_CommunicationLog_for_CommunicationLogType]
		/// </summary>
		public abstract List<CommunicationLogDetails> GetListForCommunicationLogType(System.Int32? communicationLogTypeId);
		/// <summary>
		/// GetListForCompany
		/// Calls [usp_selectAll_CommunicationLog_for_Company]
		/// </summary>
		public abstract List<CommunicationLogDetails> GetListForCompany(System.Int32? companyId);
		/// <summary>
		/// GetListForContact
		/// Calls [usp_selectAll_CommunicationLog_for_Contact]
		/// </summary>
		public abstract List<CommunicationLogDetails> GetListForContact(System.Int32? contactId);
		/// <summary>
		/// Update
		/// Calls [usp_update_CommunicationLog]
		/// </summary>
		public abstract bool Update(System.Int32? communicationLogId, System.Int32? communicationLogTypeNo, System.Int32? systemDocumentNo, System.String notes, System.Int32? contactNo, System.Int32? companyNo, System.Boolean? frozen, System.Int32? updatedBy);
        /// <summary>
        /// InsertPrintEmailLog
        /// Calls [usp_insert_PrintEmailLog]
        /// </summary>
        public abstract Int32 InsertPrintEmailLog(System.String sectionName, System.String subSectionName, System.String actionName, System.Int32? documentNo, System.String Detail, System.Int32? UpdatedBy);

        /// <summary>
        /// GetPrintEmailLog
        /// Calls [usp_select_PrintEmailLog]
        /// </summary>
        public abstract List<CommunicationLogDetails> GetPrintEmailLog(System.Int32? documentNo, System.String secionName);
		#endregion
				
		/// <summary>
		/// Returns a new CommunicationLogDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual CommunicationLogDetails GetCommunicationLogFromReader(DbDataReader reader) {
			CommunicationLogDetails communicationLog = new CommunicationLogDetails();
			if (reader.HasRows) {
				communicationLog.CommunicationLogId = GetReaderValue_Int32(reader, "CommunicationLogId", 0); //From: [Table]
				communicationLog.Notes = GetReaderValue_String(reader, "Notes", ""); //From: [Table]
				communicationLog.ContactNo = GetReaderValue_NullableInt32(reader, "ContactNo", null); //From: [Table]
				communicationLog.CompanyNo = GetReaderValue_NullableInt32(reader, "CompanyNo", null); //From: [Table]
				communicationLog.Frozen = GetReaderValue_Boolean(reader, "Frozen", false); //From: [Table]
				communicationLog.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				communicationLog.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
				communicationLog.LogDate = GetReaderValue_DateTime(reader, "LogDate", DateTime.MinValue); //From: [Table]
				communicationLog.KeyNo = GetReaderValue_NullableInt32(reader, "KeyNo", null); //From: [Table]
				communicationLog.CommunicationLogTypeNo = GetReaderValue_NullableInt32(reader, "CommunicationLogTypeNo", null); //From: [Table]
				communicationLog.SystemDocumentNo = GetReaderValue_NullableInt32(reader, "SystemDocumentNo", null); //From: [Table]
				communicationLog.DocumentNumber = GetReaderValue_NullableInt32(reader, "DocumentNumber", null); //From: [Table]
				communicationLog.ContactName = GetReaderValue_String(reader, "ContactName", ""); //From: [usp_datalistnugget_CommunicationLog]
				communicationLog.CompanyName = GetReaderValue_String(reader, "CompanyName", ""); //From: [usp_datalistnugget_CommunicationLog]
				communicationLog.CommunicationLogTypeDescription = GetReaderValue_String(reader, "CommunicationLogTypeDescription", ""); //From: [usp_datalistnugget_CommunicationLog]
				communicationLog.EnteredBy = GetReaderValue_String(reader, "EnteredBy", ""); //From: [usp_datalistnugget_CommunicationLog]
				communicationLog.RowCnt = GetReaderValue_NullableInt32(reader, "RowCnt", null); //From: [usp_datalistnugget_CommunicationLog]
			}
			return communicationLog;
		}
	
		/// <summary>
		/// Returns a collection of CommunicationLogDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<CommunicationLogDetails> GetCommunicationLogCollectionFromReader(DbDataReader reader) {
			List<CommunicationLogDetails> communicationLogs = new List<CommunicationLogDetails>();
			while (reader.Read()) communicationLogs.Add(GetCommunicationLogFromReader(reader));
			return communicationLogs;
		}
		
		
	}
}