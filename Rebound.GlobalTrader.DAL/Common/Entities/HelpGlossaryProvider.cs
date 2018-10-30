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
	
	public abstract class HelpGlossaryProvider : DataAccess {
		static private HelpGlossaryProvider _instance = null;
		/// <summary>
		/// Returns an instance of the provider type specified in the config file
		/// </summary>       
		static public HelpGlossaryProvider Instance {
			get {
				if (_instance == null) _instance = (HelpGlossaryProvider)Activator.CreateInstance(Type.GetType(Globals.Settings.HelpGlossarys.ProviderType));
				return _instance;
			}
		}
		public HelpGlossaryProvider() {
			this.ConnectionString = Globals.Settings.HelpGlossarys.ConnectionString;
		}

		#region Method Registrations
		
		/// <summary>
		/// Get
		/// Calls [usp_select_HelpGlossary]
		/// </summary>
		public abstract HelpGlossaryDetails Get(System.Int32? helpGlossaryId);
		/// <summary>
		/// GetList
		/// Calls [usp_selectAll_HelpGlossary]
		/// </summary>
		public abstract List<HelpGlossaryDetails> GetList();
		/// <summary>
		/// GetListByFirstLetter
		/// Calls [usp_selectAll_HelpGlossary_by_FirstLetter]
		/// </summary>
		public abstract List<HelpGlossaryDetails> GetListByFirstLetter(System.String firstLetter);

		#endregion
				
		/// <summary>
		/// Returns a new HelpGlossaryDetails instance filled with the DataReader's current record data
		/// </summary>        
		protected virtual HelpGlossaryDetails GetHelpGlossaryFromReader(DbDataReader reader) {
			HelpGlossaryDetails helpGlossary = new HelpGlossaryDetails();
			if (reader.HasRows) {
				helpGlossary.HelpGlossaryId = GetReaderValue_Int32(reader, "HelpGlossaryId", 0); //From: [Table]
				helpGlossary.Title = GetReaderValue_String(reader, "Title", ""); //From: [Table]
				helpGlossary.HTMLText = GetReaderValue_String(reader, "HTMLText", ""); //From: [Table]
			}
			return helpGlossary;
		}
	
		/// <summary>
		/// Returns a collection of HelpGlossaryDetails objects with the data read from the input DataReader
		/// </summary>                
		protected virtual List<HelpGlossaryDetails> GetHelpGlossaryCollectionFromReader(DbDataReader reader) {
			List<HelpGlossaryDetails> helpGlossarys = new List<HelpGlossaryDetails>();
			while (reader.Read()) helpGlossarys.Add(GetHelpGlossaryFromReader(reader));
			return helpGlossarys;
		}
		
		
	}
}