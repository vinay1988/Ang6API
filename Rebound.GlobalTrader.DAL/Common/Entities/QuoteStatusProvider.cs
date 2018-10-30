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
	
	public abstract class QuoteStatusProvider : DataAccess {
		static private QuoteStatusProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public QuoteStatusProvider Instance {
			get {
				if (_instance == null) _instance = (QuoteStatusProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.QuoteStatuss.ProviderType));
				return _instance;
			}
		}
		public QuoteStatusProvider() {
			this.ConnectionString = Globals.Settings.QuoteStatuss.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Delete
		/// Calls [usp_delete_QuoteStatus]
		/// </summary>
		public abstract bool Delete(System.Int32? quoteStatusId);
		/// <summary>
		/// DropDown
		/// Calls [usp_dropdown_QuoteStatus]
		/// </summary>
		public abstract List<QuoteStatusDetails> DropDown();
		/// <summary>
		/// Insert
		/// Calls [usp_insert_QuoteStatus]
		/// </summary>
		public abstract Int32 Insert(System.String name);
		/// <summary>
		/// Get
		/// Calls [usp_select_QuoteStatus]
		/// </summary>
		public abstract QuoteStatusDetails Get(System.Int32? quoteStatusId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_QuoteStatus]
		/// </summary>
		public abstract List<QuoteStatusDetails> GetList();
		/// <summary>
		/// Update
		/// Calls [usp_update_QuoteStatus]
		/// </summary>
		public abstract bool Update(System.String name, System.Int32? quoteStatusId);

		#endregion
				
		/// <summary>
		/// Returns a new QuoteStatusDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual QuoteStatusDetails GetQuoteStatusFromReader(DbDataReader reader) {
			QuoteStatusDetails quoteStatus = new QuoteStatusDetails();
			if (reader.HasRows) {
				quoteStatus.QuoteStatusId = GetReaderValue_Int32(reader, "QuoteStatusId", 0); //From: [Table]
				quoteStatus.Name = GetReaderValue_String(reader, "Name", ""); //From: [Table]
			}
			return quoteStatus;
		}
	
		/// <summary>
		/// Returns a collection of QuoteStatusDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<QuoteStatusDetails> GetQuoteStatusCollectionFromReader(DbDataReader reader) {
			List<QuoteStatusDetails> quoteStatuss = new List<QuoteStatusDetails>();
			while (reader.Read()) quoteStatuss.Add(GetQuoteStatusFromReader(reader));
			return quoteStatuss;
		}
		
		
	}
}