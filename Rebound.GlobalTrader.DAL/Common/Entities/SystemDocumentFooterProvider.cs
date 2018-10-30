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
	
	public abstract class SystemDocumentFooterProvider : DataAccess {
		static private SystemDocumentFooterProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SystemDocumentFooterProvider Instance {
			get {
				if (_instance == null) _instance = (SystemDocumentFooterProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.SystemDocumentFooters.ProviderType));
				return _instance;
			}
		}
		public SystemDocumentFooterProvider() {
			this.ConnectionString = Globals.Settings.SystemDocumentFooters.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_SystemDocumentFooter]
		/// </summary>
		public abstract bool Delete(System.Int32? systemDocumentFooterNo);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_SystemDocumentFooter]
		/// </summary>
		public abstract Int32 Insert(System.Int32? clientNo, System.Int32? systemDocumentNo, System.String footerText, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_SystemDocumentFooter]
		/// </summary>
		public abstract SystemDocumentFooterDetails Get(System.Int32? systemDocumentFooterNo);
		/// <summary>
		/// GetForClientAndDocument
		/// Calls [usp_select_SystemDocumentFooter_for_Client_and_Document]
		/// </summary>
		public abstract SystemDocumentFooterDetails GetForClientAndDocument(System.Int32? clientNo, System.Int32? systemDocumentNo);
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_SystemDocumentFooter_for_Client]
		/// </summary>
		public abstract List<SystemDocumentFooterDetails> GetListForClient(System.Int32? clientNo);
		/// <summary>
		/// Update
		/// Calls [usp_update_SystemDocumentFooter]
		/// </summary>
		public abstract bool Update(System.Int32? systemDocumentFooterId, System.Int32? clientNo, System.Int32? systemDocumentNo, System.String footerText, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new SystemDocumentFooterDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual SystemDocumentFooterDetails GetSystemDocumentFooterFromReader(DbDataReader reader) {
			SystemDocumentFooterDetails systemDocumentFooter = new SystemDocumentFooterDetails();
			if (reader.HasRows) {
				systemDocumentFooter.SystemDocumentFooterId = GetReaderValue_Int32(reader, "SystemDocumentFooterId", 0); //From: [Table]
				systemDocumentFooter.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				systemDocumentFooter.SystemDocumentNo = GetReaderValue_Int32(reader, "SystemDocumentNo", 0); //From: [Table]
				systemDocumentFooter.FooterText = GetReaderValue_String(reader, "FooterText", ""); //From: [Table]
				systemDocumentFooter.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				systemDocumentFooter.DLUP = GetReaderValue_NullableDateTime(reader, "DLUP", null); //From: [Table]
				systemDocumentFooter.SystemDocumentName = GetReaderValue_String(reader, "SystemDocumentName", ""); //From: [usp_selectAll_SystemDocumentFooter_for_Client]
			}
			return systemDocumentFooter;
		}
	
		/// <summary>
		/// Returns a collection of SystemDocumentFooterDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<SystemDocumentFooterDetails> GetSystemDocumentFooterCollectionFromReader(DbDataReader reader) {
			List<SystemDocumentFooterDetails> systemDocumentFooters = new List<SystemDocumentFooterDetails>();
			while (reader.Read()) systemDocumentFooters.Add(GetSystemDocumentFooterFromReader(reader));
			return systemDocumentFooters;
		}
		
		
	}
}