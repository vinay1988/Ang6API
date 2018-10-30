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
	
	public abstract class ReasonProvider : DataAccess {
		static private ReasonProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public ReasonProvider Instance {
			get {
				if (_instance == null) _instance = (ReasonProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.Reasons.ProviderType));
				return _instance;
			}
		}
		public ReasonProvider() {
			this.ConnectionString = Globals.Settings.Reasons.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_Reason]
		/// </summary>
		public abstract bool Delete(System.Int32? reasonId);
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_Reason]
		/// </summary>
		public abstract List<ReasonDetails> DropDown();
		/// <summary>
		/// Insert
		/// Calls [usp_insert_Reason]
		/// </summary>
		public abstract Int32 Insert(System.String name);
		/// <summary>
		/// Get
		/// Calls [usp_select_Reason]
		/// </summary>
		public abstract ReasonDetails Get(System.Int32? reasonId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_Reason]
		/// </summary>
		public abstract List<ReasonDetails> GetList();
		/// <summary>
		/// Update
		/// Calls [usp_update_Reason]
		/// </summary>
		public abstract bool Update(System.String name, System.Int32? reasonId);
        /// <summary>
        /// DropDown
        /// Calls [usp_dropdown_StatusReason]
        /// </summary>
        public abstract List<ReasonDetails> DropDown(System.String strSection);
		#endregion
				
		/// <summary>
		/// Returns a new ReasonDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual ReasonDetails GetReasonFromReader(DbDataReader reader) {
			ReasonDetails reason = new ReasonDetails();
			if (reader.HasRows) {
				reason.ReasonId = GetReaderValue_Int32(reader, "ReasonId", 0); //From: [Table]
				reason.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
				reason.Locked = GetReaderValue_Boolean(reader, "Locked", false); //From: [Table]
				reason.Sold = GetReaderValue_Boolean(reader, "Sold", false); //From: [Table]
				reason.NotQuoted = GetReaderValue_Boolean(reader, "NotQuoted", false); //From: [Table]
			}
			return reason;
		}
	
		/// <summary>
		/// Returns a collection of ReasonDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<ReasonDetails> GetReasonCollectionFromReader(DbDataReader reader) {
			List<ReasonDetails> reasons = new List<ReasonDetails>();
			while (reader.Read()) reasons.Add(GetReasonFromReader(reader));
			return reasons;
		}
		
		
	}
}