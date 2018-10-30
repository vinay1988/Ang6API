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
	
	public abstract class RohsStatusProvider : DataAccess {
		static private RohsStatusProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public RohsStatusProvider Instance {
			get {
				if (_instance == null) _instance = (RohsStatusProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.RohsStatuss.ProviderType));
				return _instance;
			}
		}
		public RohsStatusProvider() {
			this.ConnectionString = Globals.Settings.RohsStatuss.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_ROHSStatus]
		/// </summary>
		public abstract bool Delete(System.Int32? rohsStatusId);
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_ROHSStatus]
		/// </summary>
		public abstract List<RohsStatusDetails> DropDown();
		/// <summary>
		/// Insert
		/// Calls [usp_insert_ROHSStatus]
		/// </summary>
		public abstract Int32 Insert(System.String name);
		/// <summary>
		/// Get
		/// Calls [usp_select_ROHSStatus]
		/// </summary>
		public abstract RohsStatusDetails Get(System.Int32? rohsStatusId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_ROHSStatus]
		/// </summary>
		public abstract List<RohsStatusDetails> GetList();
		/// <summary>
		/// Update
		/// Calls [usp_update_ROHSStatus]
		/// </summary>
		public abstract bool Update(System.Int32? rohsStatusId, System.String name);

		#endregion
				
		/// <summary>
		/// Returns a new RohsStatusDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual RohsStatusDetails GetRohsStatusFromReader(DbDataReader reader) {
			RohsStatusDetails rohsStatus = new RohsStatusDetails();
			if (reader.HasRows) {
				rohsStatus.ROHSStatusId = GetReaderValue_Int32(reader, "ROHSStatusId", 0); //From: [Table]
				rohsStatus.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
			}
			return rohsStatus;
		}
	
		/// <summary>
		/// Returns a collection of RohsStatusDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<RohsStatusDetails> GetRohsStatusCollectionFromReader(DbDataReader reader) {
			List<RohsStatusDetails> rohsStatuss = new List<RohsStatusDetails>();
			while (reader.Read()) rohsStatuss.Add(GetRohsStatusFromReader(reader));
			return rohsStatuss;
		}
		
		
	}
}