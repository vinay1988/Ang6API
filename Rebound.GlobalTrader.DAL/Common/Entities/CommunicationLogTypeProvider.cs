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
	
	public abstract class CommunicationLogTypeProvider : DataAccess {
		static private CommunicationLogTypeProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public CommunicationLogTypeProvider Instance {
			get {
				if (_instance == null) _instance = (CommunicationLogTypeProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.CommunicationLogTypes.ProviderType));
				return _instance;
			}
		}
		public CommunicationLogTypeProvider() {
			this.ConnectionString = Globals.Settings.CommunicationLogTypes.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Count
		/// Calls [usp_count_CommunicationLogType]
		/// </summary>
		public abstract Int32 Count();
		/// <summary>
		/// Delete
		/// Calls [usp_delete_CommunicationLogType]
		/// </summary>
		public abstract bool Delete(System.Int32? communicationLogTypeId);
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_CommunicationLogType]
		/// </summary>
		public abstract List<CommunicationLogTypeDetails> DropDown();
		/// <summary>
		/// Insert
		/// Calls [usp_insert_CommunicationLogType]
		/// </summary>
		public abstract Int32 Insert(System.String name);
		/// <summary>
		/// Get
		/// Calls [usp_select_CommunicationLogType]
		/// </summary>
		public abstract CommunicationLogTypeDetails Get(System.Int32? communicationLogTypeId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_CommunicationLogType]
		/// </summary>
		public abstract List<CommunicationLogTypeDetails> GetList();
		/// <summary>
		/// Update
		/// Calls [usp_update_CommunicationLogType]
		/// </summary>
		public abstract bool Update(System.Int32? communicationLogTypeId, System.String name);

		#endregion
				
		/// <summary>
		/// Returns a new CommunicationLogTypeDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual CommunicationLogTypeDetails GetCommunicationLogTypeFromReader(DbDataReader reader) {
			CommunicationLogTypeDetails communicationLogType = new CommunicationLogTypeDetails();
			if (reader.HasRows) {
				communicationLogType.CommunicationLogTypeId = GetReaderValue_Int32(reader, "CommunicationLogTypeId", 0); //From: [Table]
				communicationLogType.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
			}
			return communicationLogType;
		}
	
		/// <summary>
		/// Returns a collection of CommunicationLogTypeDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<CommunicationLogTypeDetails> GetCommunicationLogTypeCollectionFromReader(DbDataReader reader) {
			List<CommunicationLogTypeDetails> communicationLogTypes = new List<CommunicationLogTypeDetails>();
			while (reader.Read()) communicationLogTypes.Add(GetCommunicationLogTypeFromReader(reader));
			return communicationLogTypes;
		}
		
		
	}
}