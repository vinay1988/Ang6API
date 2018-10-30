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
	
	public abstract class OfferStatusProvider : DataAccess {
		static private OfferStatusProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public OfferStatusProvider Instance {
			get {
				if (_instance == null) _instance = (OfferStatusProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.OfferStatuss.ProviderType));
				return _instance;
			}
		}
		public OfferStatusProvider() {
			this.ConnectionString = Globals.Settings.OfferStatuss.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_OfferStatus]
		/// </summary>
		public abstract bool Delete(System.Int32? offerStatusId);
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_OfferStatus]
		/// </summary>
		public abstract List<OfferStatusDetails> DropDown();
		/// <summary>
		/// Insert
		/// Calls [usp_insert_OfferStatus]
		/// </summary>
		public abstract Int32 Insert(System.String name);
		/// <summary>
		/// Get
		/// Calls [usp_select_OfferStatus]
		/// </summary>
		public abstract OfferStatusDetails Get(System.Int32? offerStatusId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_OfferStatus]
		/// </summary>
		public abstract List<OfferStatusDetails> GetList();
		/// <summary>
		/// Update
		/// Calls [usp_update_OfferStatus]
		/// </summary>
		public abstract bool Update(System.String name, System.Int32? offerStatusId);

		#endregion
				
		/// <summary>
		/// Returns a new OfferStatusDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual OfferStatusDetails GetOfferStatusFromReader(DbDataReader reader) {
			OfferStatusDetails offerStatus = new OfferStatusDetails();
			if (reader.HasRows) {
				offerStatus.OfferStatusId = GetReaderValue_Int32(reader, "OfferStatusId", 0); //From: [Table]
				offerStatus.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
			}
			return offerStatus;
		}
	
		/// <summary>
		/// Returns a collection of OfferStatusDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<OfferStatusDetails> GetOfferStatusCollectionFromReader(DbDataReader reader) {
			List<OfferStatusDetails> offerStatuss = new List<OfferStatusDetails>();
			while (reader.Read()) offerStatuss.Add(GetOfferStatusFromReader(reader));
			return offerStatuss;
		}
		
		
	}
}