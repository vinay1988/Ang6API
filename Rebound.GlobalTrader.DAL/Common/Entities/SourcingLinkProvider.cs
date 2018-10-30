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
	
	public abstract class SourcingLinkProvider : DataAccess {
		static private SourcingLinkProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public SourcingLinkProvider Instance {
			get {
				if (_instance == null) _instance = (SourcingLinkProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.SourcingLinks.ProviderType));
				return _instance;
			}
		}
		public SourcingLinkProvider() {
			this.ConnectionString = Globals.Settings.SourcingLinks.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_SourcingLink]
		/// </summary>
		public abstract bool Delete(System.Int32? sourcingLinkId);
		/// <summary>
		/// Insert
		/// Calls [usp_insert_SourcingLink]
		/// </summary>
		public abstract Int32 Insert(System.String sourcingLinkName, System.String url, System.Int32? clientNo, System.Int32? updatedBy);
		/// <summary>
		/// Get
		/// Calls [usp_select_SourcingLink]
		/// </summary>
		public abstract SourcingLinkDetails Get(System.Int32? sourcingLinkId);
		/// <summary>
		/// GetListForClient
		/// Calls [usp_selectAll_SourcingLink_for_Client]
		/// </summary>
		public abstract List<SourcingLinkDetails> GetListForClient(System.Int32? clientId);
		/// <summary>
		/// Update
		/// Calls [usp_update_SourcingLink]
		/// </summary>
		public abstract bool Update(System.Int32? sourcingLinkId, System.String sourcingLinkName, System.String url, System.Int32? clientNo, System.Int32? updatedBy);

		#endregion
				
		/// <summary>
		/// Returns a new SourcingLinkDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual SourcingLinkDetails GetSourcingLinkFromReader(DbDataReader reader) {
			SourcingLinkDetails sourcingLink = new SourcingLinkDetails();
			if (reader.HasRows) {
				sourcingLink.SourcingLinkId = GetReaderValue_Int32(reader, "SourcingLinkId", 0); //From: [Table]
				sourcingLink.SourcingLinkName = GetReaderValue_String(reader, "SourcingLinkName", ""); //From: [Table]
				sourcingLink.URL = GetReaderValue_String(reader, "URL", ""); //From: [Table]
				sourcingLink.ClientNo = GetReaderValue_Int32(reader, "ClientNo", 0); //From: [Table]
				sourcingLink.UpdatedBy = GetReaderValue_NullableInt32(reader, "UpdatedBy", null); //From: [Table]
				sourcingLink.DLUP = GetReaderValue_DateTime(reader, "DLUP", DateTime.MinValue); //From: [Table]
			}
			return sourcingLink;
		}
	
		/// <summary>
		/// Returns a collection of SourcingLinkDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<SourcingLinkDetails> GetSourcingLinkCollectionFromReader(DbDataReader reader) {
			List<SourcingLinkDetails> sourcingLinks = new List<SourcingLinkDetails>();
			while (reader.Read()) sourcingLinks.Add(GetSourcingLinkFromReader(reader));
			return sourcingLinks;
		}
		
		
	}
}