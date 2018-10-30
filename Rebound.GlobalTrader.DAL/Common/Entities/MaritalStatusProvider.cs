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
	
	public abstract class MaritalStatusProvider : DataAccess {
		static private MaritalStatusProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public MaritalStatusProvider Instance {
			get {
				if (_instance == null) _instance = (MaritalStatusProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.MaritalStatuss.ProviderType));
				return _instance;
			}
		}
		public MaritalStatusProvider() {
			this.ConnectionString = Globals.Settings.MaritalStatuss.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_MaritalStatus]
		/// </summary>
		public abstract bool Delete(System.Int32? maritalStatusId);
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_MaritalStatus]
		/// </summary>
		public abstract List<MaritalStatusDetails> DropDown();
		/// <summary>
		/// Insert
		/// Calls [usp_insert_MaritalStatus]
		/// </summary>
		public abstract Int32 Insert(System.String name);
		/// <summary>
		/// Get
		/// Calls [usp_select_MaritalStatus]
		/// </summary>
		public abstract MaritalStatusDetails Get(System.Int32? maritalStatusId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_MaritalStatus]
		/// </summary>
		public abstract List<MaritalStatusDetails> GetList();
		/// <summary>
		/// Update
		/// Calls [usp_update_MaritalStatus]
		/// </summary>
		public abstract bool Update(System.String name, System.Int32? maritalStatusId);

		#endregion
				
		/// <summary>
		/// Returns a new MaritalStatusDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual MaritalStatusDetails GetMaritalStatusFromReader(DbDataReader reader) {
			MaritalStatusDetails maritalStatus = new MaritalStatusDetails();
			if (reader.HasRows) {
				maritalStatus.MaritalStatusId = GetReaderValue_Int32(reader, "MaritalStatusId", 0); //From: [Table]
				maritalStatus.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
			}
			return maritalStatus;
		}
	
		/// <summary>
		/// Returns a collection of MaritalStatusDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<MaritalStatusDetails> GetMaritalStatusCollectionFromReader(DbDataReader reader) {
			List<MaritalStatusDetails> maritalStatuss = new List<MaritalStatusDetails>();
			while (reader.Read()) maritalStatuss.Add(GetMaritalStatusFromReader(reader));
			return maritalStatuss;
		}
		
		
	}
}